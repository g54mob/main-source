using Data.FactoryFloor.Resources;

namespace Data.FactoryFloor.Behaviours
{
	public abstract class SplitterBehaviorAbstract : ResourceHolderBehaviour
	{
		public bool HasResource => IsInputBufferFull();

		protected abstract void TryOutputShapeInternal();

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			SetShouldClearInputBufferOnOutput();
		}

		public override void RemoveResource(Resource resource)
		{
		}

		public override void Update()
		{
			if (IsInputBufferFull())
			{
				TryOutputShapeInternal();
			}
		}

		protected bool TryOutputResourceToIndex(int index)
		{
			if (!HasOutputResourceHolder(index) || IsTryingToOutputAtIndex(index))
			{
				return false;
			}
			return TryOutput(GetResourceInInputBuffer(), index);
		}
	}
}
