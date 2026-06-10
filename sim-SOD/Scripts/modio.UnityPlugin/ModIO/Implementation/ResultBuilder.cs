namespace ModIO.Implementation
{
	internal static class ResultBuilder
	{
		public static readonly Result Success;

		public static readonly Result Unknown;

		public static Result Create(uint resultCode, uint apiCode = 0u)
		{
			return default(Result);
		}
	}
}
