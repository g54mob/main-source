namespace ShellanderGames.WeaponWheel
{
	public struct SgWeaponWheelEvent
	{
		public readonly SgWeaponWheelEventType type;

		public readonly SgSliceController slice;

		public SgWeaponWheelEvent(SgWeaponWheelEventType type, SgSliceController slice)
		{
			this.type = default(SgWeaponWheelEventType);
			this.slice = null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
