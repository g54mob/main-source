using UnityEngine.UIElements;

namespace Restory.UI.Views
{
	public abstract class View : IView
	{
		protected VisualElement root;

		public VisualElement Root => root;
	}
}
