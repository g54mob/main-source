using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Brewery.UI.Components
{
	public sealed class BadgeManager
	{
		private readonly Dictionary<string, VisualElement> badges;

		private readonly Dictionary<string, Label> badgeLabels;

		private readonly List<BadgeDefinition> definitions;

		public void Initialize(VisualElement root, IEnumerable<BadgeDefinition> badgeDefinitions)
		{
		}

		public void Refresh()
		{
		}
	}
}
