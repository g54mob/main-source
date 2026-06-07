using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;

namespace Brewery.UI.Components
{
	public sealed class TabManager
	{
		private readonly Dictionary<string, Button> buttons;

		private readonly Dictionary<string, VisualElement> contents;

		private readonly List<TabDefinition> orderedDefinitions;

		private string currentKey;

		private bool _playSounds;

		public string CurrentTabKey => null;

		public event Action<string> OnTabChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void SetSoundsEnabled(bool enabled)
		{
		}

		public void Initialize(VisualElement root, IEnumerable<TabDefinition> definitions)
		{
		}

		public void HandleKeyDown(KeyDownEvent evt)
		{
		}

		public void SelectTab(string key)
		{
		}

		public bool TryGetContent(string key, out VisualElement content)
		{
			content = null;
			return false;
		}
	}
}
