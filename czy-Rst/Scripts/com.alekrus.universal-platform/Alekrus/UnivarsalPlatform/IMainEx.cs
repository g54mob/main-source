namespace Alekrus.UnivarsalPlatform
{
	public static class IMainEx
	{
		public static TSubInterface GetSubInterface<TSubInterface>(this IMain parMain) where TSubInterface : ISubInterface<IMain>
		{
			return SubSustemProvider.Get<TSubInterface>(parMain);
		}

		public static bool TryGetSubInterface<TSubInterface>(this IMain parMain, out TSubInterface outSubInterface) where TSubInterface : ISubInterface<IMain>
		{
			return SubSustemProvider.TryGet<TSubInterface>(parMain, out outSubInterface);
		}
	}
}
