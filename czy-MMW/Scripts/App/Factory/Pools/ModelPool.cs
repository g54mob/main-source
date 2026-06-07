using Server;

namespace Factory.Pools
{
	public class ModelPool<T> : ObjectPool<T> where T : IModel, new()
	{
		protected override void OnObjectReleased(T obj, IScope context)
		{
			base.OnObjectReleased(obj, context);
		}

		public override void InspectEntry(object entryInstance)
		{
			base.InspectEntry(entryInstance);
		}
	}
}
