namespace Assets.Source.World
{
	public class WorldAnchor
	{
		public readonly WorldAnchorType AnchorType;

		public readonly int Slot;

		public WorldAnchor(WorldAnchorType type, int slot)
		{
			AnchorType = type;
			Slot = slot;
		}

		public override bool Equals(object obj)
		{
			if (obj is WorldAnchor worldAnchor)
			{
				if (worldAnchor.AnchorType == AnchorType)
				{
					return worldAnchor.Slot == Slot;
				}
				return false;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (int)AnchorType * 100 + Slot;
		}
	}
}
