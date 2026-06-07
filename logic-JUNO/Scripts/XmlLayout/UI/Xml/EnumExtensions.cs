namespace UI.Xml
{
	public static class EnumExtensions
	{
		public static bool IsSlideAnimation(this HideAnimation hideAnimation)
		{
			if ((uint)(hideAnimation - 1) <= 3u)
			{
				return true;
			}
			return false;
		}

		public static bool IsSlideAnimation(this ShowAnimation showAnimation)
		{
			if ((uint)(showAnimation - 1) <= 3u)
			{
				return true;
			}
			return false;
		}

		public static SlideDirection ToSlideDirection(this HideAnimation hideAnimation)
		{
			return hideAnimation switch
			{
				HideAnimation.SlideOut_Bottom => SlideDirection.Bottom, 
				HideAnimation.SlideOut_Top => SlideDirection.Top, 
				HideAnimation.SlideOut_Left => SlideDirection.Left, 
				HideAnimation.SlideOut_Right => SlideDirection.Right, 
				_ => SlideDirection.Top, 
			};
		}

		public static SlideDirection ToSlideDirection(this ShowAnimation showAnimation)
		{
			return showAnimation switch
			{
				ShowAnimation.SlideIn_Bottom => SlideDirection.Bottom, 
				ShowAnimation.SlideIn_Top => SlideDirection.Top, 
				ShowAnimation.SlideIn_Left => SlideDirection.Left, 
				ShowAnimation.SlideIn_Right => SlideDirection.Right, 
				_ => SlideDirection.Top, 
			};
		}
	}
}
