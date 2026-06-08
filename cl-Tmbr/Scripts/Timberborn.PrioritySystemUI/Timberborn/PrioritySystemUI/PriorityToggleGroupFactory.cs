using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.CoreUI;
using Timberborn.InputSystem;
using Timberborn.Localization;
using Timberborn.PrioritySystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace Timberborn.PrioritySystemUI
{
	public class PriorityToggleGroupFactory
	{
		private readonly InputService _inputService;

		private readonly ILoc _loc;

		private readonly PriorityToggleFactory _priorityToggleFactory;

		private readonly VisualElementLoader _visualElementLoader;

		public PriorityToggleGroupFactory(InputService inputService, ILoc loc, PriorityToggleFactory priorityToggleFactory, VisualElementLoader visualElementLoader)
		{
			_inputService = inputService;
			_loc = loc;
			_priorityToggleFactory = priorityToggleFactory;
			_visualElementLoader = visualElementLoader;
		}

		public PriorityToggleGroup Create(VisualElement parent, string labelLocKey, IPrioritySpriteLoader prioritySpriteLoader, string decreasePriorityKey, string increasePriorityKey)
		{
			VisualElement visualElement = _visualElementLoader.LoadVisualElement("Game/EntityPanel/PriorityToggleGroup");
			parent.Add(visualElement);
			visualElement.Q<Label>("Label").text = _loc.T(labelLocKey);
			IEnumerable<PriorityToggle> toggles = CreateToggles(visualElement.Q<VisualElement>("TogglesWrapper"), prioritySpriteLoader);
			return new PriorityToggleGroup(_inputService, toggles, decreasePriorityKey, increasePriorityKey);
		}

		private IEnumerable<PriorityToggle> CreateToggles(VisualElement prioritiesWrapper, IPrioritySpriteLoader prioritySpriteLoader)
		{
			ImmutableArray<Priority>.Enumerator enumerator = Priorities.Ascending.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Priority current = enumerator.Current;
				Sprite sprite = prioritySpriteLoader.LoadSprite(current);
				yield return _priorityToggleFactory.Create(current, prioritiesWrapper, sprite);
			}
		}
	}
}
