using AutoMapper;
using Subscriber.Data.DTO;
using Subscriber.Data.Entities;

namespace Subscriber.WebApi.Config
{
    public class WWProfile:Profile
    {
        public WWProfile()
        {
            CreateMap<CardDTO, Card>().ReverseMap();
            CreateMap<SubscriberDTO,Subscribers>().ReverseMap();
        }
    }
}
