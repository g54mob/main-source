using Timberborn.BaseComponentSystem;
using Timberborn.CoreUI;
using Timberborn.EntityPanelSystem;
using Timberborn.Localization;
using Timberborn.WaterBuildings;
using UnityEngine.UIElements;

namespace Timberborn.WaterBuildingsUI
{
	internal class ValveDebugFragment : IEntityPanelFragment
	{
		private readonly DebugFragmentFactory _debugFragmentFactory;

		private readonly ILoc _loc;

		private readonly Phrase _currentOutflowLimitPhrase = Phrase.New().Format((float value) => $"Current outflow limit: {value:F4}cms");

		private Valve _valve;

		private VisualElement _root;

		private Label _text;

		public ValveDebugFragment(DebugFragmentFactory debugFragmentFactory, ILoc loc)
		{
			_debugFragmentFactory = debugFragmentFactory;
			_loc = loc;
		}

		public VisualElement InitializeFragment()
		{
			_root = _debugFragmentFactory.Create("Valve");
			_text = _root.Q<Label>("Text");
			return _root;
		}

		public void ShowFragment(BaseComponent entity)
		{
			_valve = entity.GetComponent<Valve>();
		}

		public void ClearFragment()
		{
			_valve = null;
			UpdateFragment();
		}

		public void UpdateFragment()
		{
			if ((bool)_valve)
			{
				_text.text = (_valve.CurrentOutflowLimit.HasValue ? _loc.T(_currentOutflowLimitPhrase, _valve.CurrentOutflowLimit.Value) : "Unlimited");
				_root.ToggleDisplayStyle(visible: true);
			}
			else
			{
				_root.ToggleDisplayStyle(visible: false);
			}
		}
	}
}
