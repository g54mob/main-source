using UnityEngine;

namespace Simulator.GameWorld
{
	public interface IStackable
	{
		public enum EType
		{
			NONE = -1,
			PRODUCT = 0,
			TRASH = 1
		}

		Transform transform { get; }

		ClippingObjectBehaviour ClippingObjectBehaviour { get; }

		IStackableData StackableData { get; }

		Bounds Bounds { get; }

		void OnPreStackedIn(ObjectStack stack);

		void OnStackedIn(ObjectStack stack);

		void OnUnstackedFrom(ObjectStack stack);
	}
}
