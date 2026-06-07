namespace Presentation.FactoryFloor
{
	public class PreviewingObject
	{
		public int ObjectId;

		public FactoryObjectView FactoryObjectView;

		public PreviewingObject(int objectId, FactoryObjectView factoryObjectView)
		{
			ObjectId = objectId;
			FactoryObjectView = factoryObjectView;
		}
	}
}
