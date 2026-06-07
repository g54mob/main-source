namespace Noesis
{
	public struct SamplerState
	{
		private readonly byte v;

		public WrapMode WrapMode => default(WrapMode);

		public MinMagFilter MinMagFilter => default(MinMagFilter);

		public MipFilter MipFilter => default(MipFilter);

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
