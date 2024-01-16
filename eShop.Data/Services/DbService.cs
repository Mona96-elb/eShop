
using AutoMapper;
using eShop.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace eShop.Data.Services;

public class DbService : IDbService
{

    //_ istället för this. som vissar att de är en class variabel. 
    private readonly EShopContext _db;
    private readonly IMapper _mapper; 

    public DbService(EShopContext db,IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public virtual async Task<List<TDto>> GetAsync<TEntity, TDto>()
        where TEntity : class
        where TDto : class
    {
        //IncludeNavigationsFor<Filter>();
       var entities = await _db.Set<TEntity>().ToListAsync();
        return _mapper.Map<List<TDto>>(entities);


    }
}
