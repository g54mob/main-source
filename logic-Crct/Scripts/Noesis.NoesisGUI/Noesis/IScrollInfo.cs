namespace Noesis
{
	public interface IScrollInfo
	{
		bool CanVerticallyScroll { get; set; }

		bool CanHorizontallyScroll { get; set; }

		float ExtentWidth { get; }

		float ExtentHeight { get; }

		float ViewportWidth { get; }

		float ViewportHeight { get; }

		float HorizontalOffset { get; }

		float VerticalOffset { get; }

		ScrollViewer ScrollOwner { get; set; }

		void LineUp();

		void LineDown();

		void LineLeft();

		void LineRight();

		void PageUp();

		void PageDown();

		void PageLeft();

		void PageRight();

		void MouseWheelUp(float delta);

		void MouseWheelUp();

		void MouseWheelDown(float delta);

		void MouseWheelDown();

		void MouseWheelLeft(float delta);

		void MouseWheelLeft();

		void MouseWheelRight(float delta);

		void MouseWheelRight();

		void SetHorizontalOffset(float offset);

		void SetVerticalOffset(float offset);

		Rect MakeVisible(Visual visual, Rect rectangle);
	}
}
