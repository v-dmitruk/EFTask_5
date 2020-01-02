using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BL
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            //CreateMap<IEnumerable<Product>, List<DAL.Product>>();
            //CreateMap<IEnumerable<DAL.Product>, List<Product>>();
            //CreateMap<IEnumerable<Category>, List<DAL.Category>>();
            //CreateMap<IEnumerable<DAL.Category>, List<Category>>();
            //CreateMap<IEnumerable<Provider>, List<DAL.Provider>>();
            //CreateMap<IEnumerable<DAL.Provider>, List<Provider>>();
            CreateMap<Category, DAL.Category>()
                .ForMember(dest => dest.ID, source => source.MapFrom(map => map.ID))
                .ForMember(dest => dest.Name, source => source.MapFrom(map => map.Name))
                .ForMember(dest => dest.Description, source => source.MapFrom(map => map.Description))
                .ForMember(dest => dest.Products, source => source.MapFrom(map => map.Products));
            CreateMap<DAL.Category, Category>()
                .ForMember(dest => dest.ID, source => source.MapFrom(map => map.ID))
                .ForMember(dest => dest.Name, source => source.MapFrom(map => map.Name))
                .ForMember(dest => dest.Description, source => source.MapFrom(map => map.Description))
                .ForMember(dest => dest.Products, source => source.MapFrom(map => map.Products));
            CreateMap<Provider, DAL.Provider>();
            CreateMap<DAL.Provider, Provider>();
            //CreateMap<Product, DAL.Product>().ForMember(dest => dest.Categories, source => source.MapFrom(map => { new List<Category>() = map.Categories; }));
            CreateMap<Product, DAL.Product>().ForMember(dest => dest.Categories, source => source.MapFrom(map => map.Categories));
            CreateMap<DAL.Product, Product>().ForMember(dest => dest.Categories, source => source.MapFrom(map => map.Categories));
        }

        public static MapperConfiguration Configured()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
            return config;
        }

        //public static void Initialize()
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddProfile<MapperProfile>();
        //    });
        //}



        //public static IMapper GetMapper()
        //{
        //    var config = new MapperConfiguration(
        //    cfg =>
        //    {
        //        cfg.CreateMap<DAL.Product, Product>().ForMember(destination => destination.Provider, map => map.MapFrom(
        //        source => new Provider
        //        {
        //            ID = source.Provider.ID,
        //            Name = source.Provider.Name,
        //            Description = source.Provider.Description
        //        })
        //          ).ForMember(dest => dest.Categories, map => map.MapFrom(
        //              source => new List<Category> { }));
        //    });

        //    IMapper mapper = config.CreateMapper();
        //    return mapper;
        //}
    }
}
