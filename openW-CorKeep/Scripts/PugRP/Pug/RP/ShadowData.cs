namespace Pug.RP
{
	public struct ShadowData
	{
		public ShadowType type;

		public int atlasIndex;

		public static ShadowData invalid => new ShadowData
		{
			type = ShadowType.Invalid,
			atlasIndex = -1
		};
	}
}
