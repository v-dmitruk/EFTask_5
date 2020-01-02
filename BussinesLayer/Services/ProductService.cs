using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BL
{
    public class ProductService
    {
        private DAL.UnitOfWork _uow = new DAL.UnitOfWork(); 
        public bool AddProduct(Product item)
        {
            //IMapper mapper = new MapperConfiguration(x => x.CreateMap<Product, DAL.Product>()).CreateMapper();
            //IMapper mapper = new MapperConfiguration(x => x.CreateMap<Product, DAL.Product>().
            //ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories)).
            //ForMember(dest => dest.Provider, opt1 => opt1.MapFrom(y => y.Provider))).
            //CreateMapper();
            var mapper = new Mapper(MapperProfile.Configured());
            _uow.ProductRepository.Create(mapper.Map<Product, DAL.Product>(item));
            return true;
        }

        public Product Get(int ID)
        {
            var mapper = new Mapper(MapperProfile.Configured());
            //IMapper mapper = new MapperConfiguration(x => x.CreateMap<DAL.Product, Product>()).CreateMapper();
            return mapper.Map<DAL.Product, Product>(_uow.ProductRepository.Get(ID));
        }

        public List<Product> GetAll()
        {
            IMapper mapper = new MapperConfiguration(x => x.CreateMap<IEnumerable<DAL.Product>, List<Product>>()).CreateMapper();
            return mapper.Map<IEnumerable<DAL.Product>, List<Product>>(_uow.ProductRepository.GetList());
        }

        public void DeleteProduct(int ID)
        {
            _uow.ProductRepository.Delete(ID);
        }

        public void Save()
        {
            _uow.ProductRepository.Save();
            _uow.ProviderRepository.Save();
            _uow.CategoryRepository.Save();
        }


    }
}
