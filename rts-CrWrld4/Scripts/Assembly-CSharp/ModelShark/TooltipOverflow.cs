namespace ModelShark
{
	public class TooltipOverflow
	{
		public bool IsAny => false;

		public bool TopEdge => false;

		public bool RightEdge => false;

		public bool LeftEdge => false;

		public bool BottomEdge => false;

		public bool TopRightCorner { get; set; }

		public bool TopLeftCorner { get; set; }

		public bool BottomRightCorner { get; set; }

		public bool BottomLeftCorner { get; set; }

		public TipPosition SuggestNewPosition(TipPosition fromPosition)
		{
			return default(TipPosition);
		}
	}
}
