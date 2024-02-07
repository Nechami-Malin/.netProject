using homeSchool.core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using School.model.Response;
using Subsciber.CORE.DTO;
using Subsciber.CORE.interface_DAL;
using Subscriber.Data;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.DAL
{
    public class CardSubscriberRepository : ICardSubscriberRepository
    {
        readonly WeightWatcherContext _w;
        public CardSubscriberRepository(WeightWatcherContext w)
        {
            _w = w;
        }
        public async Task<BaseResponseGeneral<int>> Login(string email, string password)
        {
            try
            {
                Subscribers subscriber = _w.Subscribers.Where(p => p.Email == email && p.Password == password).FirstOrDefault();
                if (subscriber != null)
                {
                    // התחברות הצליחה, נחזיר את אובייקט הכרטיס
                    return new BaseResponseGeneral<int>
                    {
                        Success = true,
                        Message = "התחברות הצליחה",
                        Data = subscriber.Id
                    };
                }
                else
                {
                    // התחברות נכשלה, נחזיר הודעת שגיאה
                    return new BaseResponseGeneral<int>
                    {
                        Success = false,
                        Message = "שם משתמש או סיסמה שגויים",
                        Data = -1
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(" error 401 Login Failed");
            }
        }
        public async Task<BaseResponseGeneral<CardSubscriberResponse>> GetSubscriberById(int id)
        {

            try
            {
                BaseResponseGeneral<CardSubscriberResponse> response = new BaseResponseGeneral<CardSubscriberResponse>();
                Card card = _w.Card.Where(p => p.Id == id).FirstOrDefault();
                Subscribers subscribers = _w.Subscribers.Where(p => p.Id == card.SubscriberId).FirstOrDefault();
                response.Success = true;
                response.Message = "התחברות הצליחה";
                response.Data = new CardSubscriberResponse();
                response.Data.FirstName = subscribers.FirstName;
                response.Data.LastName = subscribers.LastName;
                response.Data.weight = card.Weight;
                response.Data.height = card.Height;
                response.Data.BMI = card.BMI;

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Get card Failed");
            }
        }
        public async Task<BaseResponseGeneral<bool>> Register(Subscribers subscribers, double height)
        {
            try
            {
                BaseResponseGeneral<bool> response = new BaseResponseGeneral<bool>();
                _w.Subscribers.AddAsync(subscribers);
                await _w.SaveChangesAsync();
                Card newCard = new Card
                {
                    OpenDate = DateTime.Now,
                    UpDate = DateTime.Now,
                    SubscriberId = subscribers.Id,
                    BMI = 0,
                    Height = height,
                };
                _w.Card.AddAsync(newCard);
                await _w.SaveChangesAsync();
                response.Success = true;
                response.Message = "המנוי נוסף בהצלחה";
                response.Data = true;

                return response;
            }
            catch (Exception)
            {
                throw new Exception("Register Failed");
            }
        }
        public bool IsEmailExists(string email)
        {
            return  _w.Subscribers.Any(p => p.Email == email);
        }
        public  bool IsIdCardExists(int id)
        {
            return  _w.Subscribers.Any(p => p.Id == id);
        }

    }


}

