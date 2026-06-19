namespace Aggro.Core
{
	public struct PlatformGameJoin
	{
		public PlatformError result;

		public string joinData;

		public PlatformGameJoin(PlatformError result, string joinData = null)
		{
			this.result = result;
			this.joinData = joinData;
		}
	}
}
