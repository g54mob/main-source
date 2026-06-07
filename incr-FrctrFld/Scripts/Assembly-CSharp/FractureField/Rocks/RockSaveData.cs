using Reactivity;

namespace FractureField.Rocks
{
	public class RockSaveData : IConvertableSaveData
	{
		public long Id { get; set; }

		public Ref<RockLayerType> CurrentLayerType { get; set; }

		public Ref<RockLayerType> StartingLayerType { get; set; }

		public RFloat Health { get; set; }

		public RFloat MaxHealth { get; set; }

		public RFloat Hardness { get; set; }

		public float[] PosSaveData { get; set; }

		public RInt BombHitCount { get; set; }

		public bool CountsTowardsCapacity { get; set; }

		protected RockSaveData Save(Rock data)
		{
			return null;
		}
	}
}
