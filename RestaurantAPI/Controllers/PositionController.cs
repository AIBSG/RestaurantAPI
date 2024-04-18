using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PositionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PositionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var TypesData = new Models.Type[] {
               new Models.Type { Id = Guid.NewGuid(), Name = "Бургеры" } ,
               new Models.Type { Id = Guid.NewGuid(), Name = "Cупы" },
               new Models.Type { Id = Guid.NewGuid(), Name = "Напитки" },
               new Models.Type { Id = Guid.NewGuid(), Name = "Горячее" },
               new Models.Type { Id = Guid.NewGuid(), Name = "Закуски" },
               new Models.Type { Id = Guid.NewGuid(), Name = "Салаты" }
            };
            var PositionsData = new Models.Position[]
            {
                new Position {Id = Guid.NewGuid(), Name = "Чизбургер", Price = 150, Type = TypesData[0], Image = "https://bkmenu.ru/files/2021/06/chizburger-menu-bk.png" },
                new Position {Id = Guid.NewGuid(), Name = "Маленький Мак", Price = 450, Type = TypesData[0], Image = "https://makdonalds-ceni-i-menyu.ru/wp-content/uploads/big-mak.png" },
                new Position {Id = Guid.NewGuid(), Name = "Борщ", Price = 249, Type = TypesData[1] , Image = "https://xn--80aauks4g.xn----8sbbsvbbe0abb0f.xn--p1ai/wp-content/uploads/2016/08/%D0%91%D0%BE%D1%80%D1%89-500x500.png"},
                new Position {Id = Guid.NewGuid(), Name = "Щи", Price = 450, Type = TypesData[1] , Image = "https://xn--80aauks4g.xn----8sbbsvbbe0abb0f.xn--p1ai/wp-content/uploads/2016/08/%D0%A9%D0%B8.png"},
                new Position {Id = Guid.NewGuid(), Name = "Куриный суп", Price = 679, Type = TypesData[1], Image = "https://darpizza.com/image/cache/catalog/products/pervie_bluda/lapsha-500x500.png" },
                new Position {Id = Guid.NewGuid(), Name = "Добрый кола", Price = 100, Type = TypesData[2], Image = "https://pizza-roma.ru/image/cache/catalog/napitki/coca-cola-05-500x500.png" },
                new Position {Id = Guid.NewGuid(), Name = "Пиво", Price = 10, Type = TypesData[2], Image = "https://xn----jtbzuinr8d.xn--p1ai/storage/.thumbs/preview500x500_zhigulevskoe-1978-1-3l.png" },
                new Position {Id = Guid.NewGuid(), Name = "Водка", Price = 5, Type = TypesData[2], Image = "https://xn--80aaa5athr.xn--p1ai/wp-content/uploads/2017/11/standard-500x500.png" },
                new Position {Id = Guid.NewGuid(), Name = "Пельмени", Price = 100, Type = TypesData[3], Image = "https://shop.kt-trapeza.ru/image/cache/catalog/nasha_prod/gotovie_bluda/pelmeni_ki-500x500.png" },
                new Position {Id = Guid.NewGuid(), Name = "Паста какая-то", Price = 150, Type = TypesData[3], Image = "https://ika.md/files/2023-03-29/images/medium/f_b_i11898-_-1680095222.png" },
                new Position {Id = Guid.NewGuid(), Name = "Вода", Price = 999, Type = TypesData[2], Image = "https://naturelia.net/image/cache/catalog/%D0%A2%D0%BE%D0%B2%D0%B0%D1%80%D1%8B/%D0%91%D0%B5%D0%BB%D0%B0%D1%80%D1%83%D1%81%D1%8C%20%D1%81%D0%BE%D0%BA%D0%B8/sg15gz-500x500.png" },
                new Position {Id = Guid.NewGuid(), Name = "Грибной суп", Price = 100, Type = TypesData[1], Image = "https://edavidnoe.ru/image/cache/catalog/gribnoj-500x500.png" },
                new Position {Id = Guid.NewGuid(), Name = "Воппер", Price = 1500, Type = TypesData[0], Image = "https://lh3.googleusercontent.com/proxy/YudNbAA26PLTXrg1h9ew8zhGu_bdaTZGDbh84XUlEmqG9EtPBgoFkNSc6Roh3omrAKj8fCALekVYxQGW4-JpGISBlfV62tRSJ4Eqi1PFfHMT7nMGXW2-DqGNxvx33lscckRjsyc_kro9LYgjy8gdF3_imrkGOfTXqZJdqjH_IO2mwBQroDL0IQqVFhte" },
                new Position {Id = Guid.NewGuid(), Name = "Картошка фри", Price = 178, Type = TypesData[4], Image = "https://darpizza.com/image/cache/catalog/free-500x500.png" },
                new Position {Id = Guid.NewGuid(), Name = "Чай", Price = 50, Type = TypesData[2], Image = "https://cdn-ru.bitrix24.by/b17280752/landing/778/778c4fa8ceb70d0d8c76aff7f4e7c70d/chashka-s-chaem_1x.png"},
                new Position {Id = Guid.NewGuid(), Name = "Кура гриль", Price = 500, Type = TypesData[3], Image = "https://imgproxy.sbermarket.ru/imgproxy/size-500-500/czM6Ly9jb250ZW50LWltYWdlcy1wcm9kL3Byb2R1Y3RzLzEzMzAwNy9vcmlnaW5hbC8yLzIwMjItMDgtMjNUMTMlM0E1NiUzQTExLjkyMTAwMCUyQjAwJTNBMDAvMTMzMDA3XzIucG5n.png"},
                new Position {Id = Guid.NewGuid(), Name = "Начос", Price = 190, Type = TypesData[4], Image = "https://novoaltaisk.grilnica.ru/cdn/5539bc88460fdfe4f6bfeffe2c62f8f2_1hah5zyqbr8.png"},
                new Position {Id = Guid.NewGuid(), Name = "Бутерброд", Price = 200, Type = TypesData[4], Image = "https://metropolis-online.ru/upload/iblock/06f/06fc5c2c052b62f847cb82282e9a0eb7.png"},
                new Position {Id = Guid.NewGuid(), Name = "Семга с сыром", Price = 250, Type = TypesData[3], Image = "https://imgproxy.sbermarket.ru/imgproxy/size-500-500/czM6Ly9jb250ZW50LWltYWdlcy1wcm9kL3Byb2R1Y3RzLzEzODk4Njkvb3JpZ2luYWwvMS8yMDIyLTA4LTIzVDA5JTNBNDYlM0ExMS44MjkwMDAlMkIwMCUzQTAwLzEzODk4NjlfMS5wbmc=.png"},
                new Position {Id = Guid.NewGuid(), Name = "Цезарь", Price = 560, Type = TypesData[5], Image = "https://lh4.googleusercontent.com/proxy/kIOx85Tb_P64q7GOG4uQJzXG7AvlK9dPVeqvAuYRcHyC_kCNHQPgNTPCYEAYztS6MNSHeRFBz1vuzhhJfEYmsDlgyyqvE4dMF-xuMG8RZ9546_n2-1akEWjJwk8gD5a8DJ6R54x13g"},
                new Position {Id = Guid.NewGuid(), Name = "Сельдь под шубой", Price = 279, Type = TypesData[5], Image = "https://darpizza.com/image/cache/catalog/products/salats/seldpodshuboj-500x500.png"}
            };

            if (!_context.Positions.ToListAsync().Result.Any())
            {
                await _context.Positions.AddRangeAsync(PositionsData);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest("Позиции и типы уже заполненны");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Set<Position>().Include(x=> x.Type).ToListAsync();
            return Ok(result);

        }


    }
}
