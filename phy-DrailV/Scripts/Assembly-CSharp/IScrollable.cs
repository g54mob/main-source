public interface IScrollable
{
	void Scroll(ScrollAction action, ScrollSource source = ScrollSource.Mouse);

	bool IsAtEnd(ScrollAction action);
}
