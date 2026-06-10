using NSEipix.Base;
using NSEipix.ObjectMapper;

namespace NSEipix.Repository
{
	public abstract class DynamicJsonRepository<T, TM> : DynamicJsonData<T, TM> where T : Repository<T, TM> where TM : NSEipix.Base.Model
	{
		protected override ISerializer<RepositoryDto<TM>> Serializer()
		{
			return new JsonSerializer<RepositoryDto<TM>>.Builder(JsonFilePathRegistry).BuildWithoutSerializerMultiple();
		}
	}
}
