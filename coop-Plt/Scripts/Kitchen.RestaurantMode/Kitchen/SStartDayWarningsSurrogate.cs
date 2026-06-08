using Unity.Entities;

namespace Kitchen
{
	public struct SStartDayWarningsSurrogate : TypeHash.ISurrogate<SStartDayWarnings>, TypeHash.ISurrogate, IComponentData
	{
		public WarningLevel PopupsOpen;

		public WarningLevel SellingRequiredAppliance;

		public WarningLevel TableSize;

		public WarningLevel PlayersNotReady;

		public WarningLevel PostUnopened;

		public WarningLevel MoreThanOneTable;

		public IComponentData Convert()
		{
			return default(SStartDayWarnings);
		}
	}
}
