namespace Noesis
{
	public struct RenderState
	{
		private readonly byte v;

		public bool ColorEnable => false;

		public BlendMode BlendMode => default(BlendMode);

		public StencilMode StencilMode => default(StencilMode);

		public bool Wireframe => false;

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
