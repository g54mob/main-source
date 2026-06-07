using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Brewery.Minigames.UI
{
	public class UIElementPool
	{
		private readonly VisualElement parent;

		private readonly string baseClassName;

		private readonly Stack<VisualElement> available;

		private readonly List<VisualElement> active;

		public int ActiveCount => 0;

		public int AvailableCount => 0;

		public int TotalCount => 0;

		public UIElementPool(VisualElement parent, string baseClassName, int initialCapacity = 0)
		{
		}

		public VisualElement Get()
		{
			return null;
		}

		public void Release(VisualElement elem)
		{
		}

		public void ReleaseAll()
		{
		}

		public void Destroy()
		{
		}

		private VisualElement CreateElement()
		{
			return null;
		}
	}
}
