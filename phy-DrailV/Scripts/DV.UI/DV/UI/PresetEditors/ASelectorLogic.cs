using DV.UIFramework;

namespace DV.UI.PresetEditors
{
	public abstract class ASelectorLogic : NullCheckingMonoBehaviour
	{
		[NullCheck]
		public Selector selector;

		protected virtual void OnEnable()
		{
			selector.SelectionChanged += OnSelectionChanged;
		}

		protected virtual void OnDisable()
		{
			selector.SelectionChanged -= OnSelectionChanged;
		}

		protected abstract void OnSelectionChanged(IClickable clickable, int selectedIndex);
	}
}
