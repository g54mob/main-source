namespace Services
{
	public interface ISceneItemIdGenerator
	{
		string Generate(string gameObjectName);

		void Release(string id);
	}
}
