namespace XGamingRuntime.Interop
{
	public struct XblMultiplayerSessionQuery
	{
		public unsafe fixed sbyte Scid[40];

		public uint MaxItems;

		public bool IncludePrivateSessions;

		public bool IncludeReservations;

		public bool IncludeInactiveSessions;

		public unsafe ulong* XuidFilters;

		public SizeT XuidFiltersCount;

		public unsafe sbyte* KeywordFilter;

		public unsafe fixed sbyte SessionTemplateNameFilter[100];

		public XblMultiplayerSessionVisibility VisibilityFilter;

		public uint ContractVersionFilter;
	}
}
