using UnityEngine;

namespace Simulator.GameWorld
{
	public class TrashData : DirtData, IStackableData
	{
		public IStackable.EType StackableType => IStackable.EType.TRASH;

		public Bounds Bounds
		{
			get
			{
				if (!(base.Prefab != null))
				{
					return default(Bounds);
				}
				return (base.Prefab as Trash).Bounds;
			}
		}
	}
}
