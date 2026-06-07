namespace DV.UIFramework
{
	public interface IMarkable : IClickable, IHoverable
	{
		bool IsMarked { get; }

		event MarkDelegate MarkChanged;

		void ToggleMarked(bool marked);
	}
}
