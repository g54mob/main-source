namespace Noesis
{
	public static class ContextMenuService
	{
		public static DependencyProperty ContextMenuProperty => null;

		public static DependencyProperty HasDropShadowProperty => null;

		public static DependencyProperty HorizontalOffsetProperty => null;

		public static DependencyProperty IsEnabledProperty => null;

		public static DependencyProperty PlacementProperty => null;

		public static DependencyProperty PlacementRectangleProperty => null;

		public static DependencyProperty PlacementTargetProperty => null;

		public static DependencyProperty ShowOnDisabledProperty => null;

		public static DependencyProperty VerticalOffsetProperty => null;

		public static RoutedEvent ContextMenuClosingEvent => null;

		public static RoutedEvent ContextMenuOpeningEvent => null;

		public static ContextMenu GetContextMenu(DependencyObject obj)
		{
			return null;
		}

		public static void SetContextMenu(DependencyObject obj, ContextMenu contextMenu)
		{
		}

		public static bool GetHasDropShadow(DependencyObject obj)
		{
			return false;
		}

		public static void SetHasDropShadow(DependencyObject obj, bool hasDropShadow)
		{
		}

		public static float GetHorizontalOffset(DependencyObject obj)
		{
			return 0f;
		}

		public static void SetHorizontalOffset(DependencyObject obj, float offset)
		{
		}

		public static bool GetIsEnabled(DependencyObject obj)
		{
			return false;
		}

		public static void SetIsEnabled(DependencyObject obj, bool isEnabled)
		{
		}

		public static PlacementMode GetPlacement(DependencyObject obj)
		{
			return default(PlacementMode);
		}

		public static void SetPlacement(DependencyObject obj, PlacementMode mode)
		{
		}

		public static Rect GetPlacementRectangle(DependencyObject obj)
		{
			return default(Rect);
		}

		public static void SetPlacementRectangle(DependencyObject obj, Rect rect)
		{
		}

		public static UIElement GetPlacementTarget(DependencyObject obj)
		{
			return null;
		}

		public static void SetPlacementTarget(DependencyObject obj, UIElement target)
		{
		}

		public static bool GetShowOnDisabled(DependencyObject obj)
		{
			return false;
		}

		public static void SetShowOnDisabled(DependencyObject obj, bool showOnDisable)
		{
		}

		public static float GetVerticalOffset(DependencyObject obj)
		{
			return 0f;
		}

		public static void SetVerticalOffset(DependencyObject obj, float offset)
		{
		}
	}
}
