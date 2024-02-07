using homeSchool.core;
using School.model.Response;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsciber.CORE.interface_DAL
{
    public interface ICardSubscriberRepository
    {
        Task<BaseResponseGeneral<int>> Login(string email, string password);
        Task<BaseResponseGeneral<CardSubscriberResponse>> GetSubscriberById(int id);
        Task<BaseResponseGeneral<bool>> Register(Subscribers subscribers, double height);
        bool IsIdCardExists(int id);
        bool IsEmailExists(string email);
    }
}
