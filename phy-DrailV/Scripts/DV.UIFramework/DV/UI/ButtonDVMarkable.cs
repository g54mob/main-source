using DV.UIFramework;

namespace DV.UI
{
	public class ButtonDVMarkable : ButtonDV, IMarkable, IClickable, IHoverable
	{
		public bool IsMarked { get; private set; }

		public event MarkDelegate MarkChanged;

		public void ToggleMarked(bool marked)
		{
			if (IsMarked != marked)
			{
				IsMarked = marked;
				this.MarkChanged?.Invoke(this);
			}
		}
	}
}
