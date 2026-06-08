using Timberborn.BaseComponentSystem;
using Timberborn.Common;
using Timberborn.CoreUI;
using Timberborn.EntityPanelSystem;
using Timberborn.Hauling;
using Timberborn.InputSystemUI;
using Timberborn.Workshops;
using UnityEngine.UIElements;

namespace Timberborn.HaulingUI
{
	internal class HaulCandidateFragment : IEntityPanelFragment
	{
		private static readonly string ToggleHaulingPriorityKey = "ToggleHaulingPriority";

		private readonly VisualElementLoader _visualElementLoader;

		private readonly BindableToggleFactory _bindableToggleFactory;

		private BindableToggle _priorityToggle;

		private HaulCandidate _haulCandidate;

		private HaulPrioritizable _haulPrioritizable;

		private VisualElement _root;

		public HaulCandidateFragment(VisualElementLoader visualElementLoader, BindableToggleFactory bindableToggleFactory)
		{
			_visualElementLoader = visualElementLoader;
			_bindableToggleFactory = bindableToggleFactory;
		}

		public VisualElement InitializeFragment()
		{
			_root = _visualElementLoader.LoadVisualElement("Game/EntityPanel/HaulCandidateFragment");
			_priorityToggle = _bindableToggleFactory.Create(_root.Q<Toggle>("Toggle"), ToggleHaulingPriorityKey, delegate(bool value)
			{
				_haulPrioritizable.Prioritized = value;
			}, () => _haulPrioritizable.Prioritized);
			_root.ToggleDisplayStyle(visible: false);
			return _root;
		}

		public void ShowFragment(BaseComponent entity)
		{
			HaulCandidate component = entity.GetComponent<HaulCandidate>();
			if ((bool)component && !component.GetComponent<HaulingBlocker>())
			{
				_haulCandidate = component;
				_haulPrioritizable = entity.GetComponent<HaulPrioritizable>();
				Manufactory component2 = entity.GetComponent<Manufactory>();
				if ((bool)component2 && component2.ProductionRecipes.FastAll((RecipeSpec recipe) => !recipe.ConsumesIngredients && !recipe.ProducesProducts))
				{
					_root.ToggleDisplayStyle(visible: false);
					return;
				}
				_priorityToggle.Bind();
				_priorityToggle.Enable();
				_root.ToggleDisplayStyle(visible: true);
			}
		}

		public void ClearFragment()
		{
			_root.ToggleDisplayStyle(visible: false);
			_priorityToggle.Disable();
			_priorityToggle.Unbind();
			_haulPrioritizable = null;
			_haulCandidate = null;
		}

		public void UpdateFragment()
		{
			if ((bool)_haulCandidate)
			{
				_priorityToggle.Update();
			}
		}
	}
}
