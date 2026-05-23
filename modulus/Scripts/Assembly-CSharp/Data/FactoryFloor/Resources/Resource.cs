namespace Data.FactoryFloor.Resources
{
	public class Resource
	{
		public float TargetScale { get; protected set; } = 1f;

		public ResourceDataSO Data { get; private set; }

		public Resource(ResourceDataSO resourceData)
		{
			Data = resourceData;
		}
	}
}
