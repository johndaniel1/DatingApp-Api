using AutoMapper;
using DatingApp.Dtos;
using DatingApp.Helper;
using DatingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingApp
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.Age, opt =>
                opt.MapFrom(src => src.DateOfBirth.CalculateAge()));

                config.CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.Age, opt =>
                opt.MapFrom(src => src.DateOfBirth.CalculateAge()));

                config.CreateMap<Photo, PhotosForDetailedDto>();
                config.CreateMap<UserForUpdateDto, User>();
            });
        }        
    }
}