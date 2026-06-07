using UI.Common;

namespace UI.SpriteEditor
{
	public struct DrawToolState
	{
		public SESelectionShapes shape;

		public bool fill;

		public DrawToolState(SESelectionShapes shape, bool fill)
		{
			this.shape = default(SESelectionShapes);
			this.fill = false;
		}
	}
}
