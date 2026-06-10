using NSEipix.Base;
using NSEipix.ObjectMapper;

namespace NSEipix.Repository
{
	public abstract class JsonRepository<T, TM> : Repository<T, TM> where T : Repository<T, TM> where TM : NSEipix.Base.Model
	{
		public bool IsInitialized { get; private set; }

		public JsonRepository()
		{
		}

		protected abstract string JsonFile();

		protected override ISerializer<RepositoryDto<TM>> Serializer()
		{
			return GetSerializer(JsonFile());
		}

		protected virtual ISerializer<RepositoryDto<TM>> GetSerializer(string path)
		{
			return new JsonSerializer<RepositoryDto<TM>>.Builder(path).BuildWithoutSerializer();
		}

		protected override void Initialize()
		{
			if (repository.Count == 0)
			{
				Deserialize();
				IsInitialized = true;
			}
		}

		public override void Deserialize()
		{
			RemoveAll();
			base.Deserialize();
		}
	}
}
