

namespace Models.Mappers.Base.Interfaces
{
    public interface IBaseMapper<Model, Entity>
    {
        public Entity ToEntity(Model model);    
        public Model Map(Entity entity);
    }
}
