using Timberborn.Automation;
using Timberborn.AutomationBuildings;
using Timberborn.AutomationUI;
using Timberborn.BaseComponentSystem;
using Timberborn.CoreUI;
using Timberborn.DropdownSystem;
using Timberborn.EntityPanelSystem;
using UnityEngine.UIElements;

namespace Timberborn.AutomationBuildingsUI
{
	internal class RelayFragment : IEntityPanelFragment
	{
		private static readonly string RelayModeLocKeyPrefix = "Building.Relay.Mode.";

		private readonly VisualElementLoader _visualElementLoader;

		private readonly DropdownItemsSetter _dropdownItemsSetter;

		private readonly EnumDropdownProviderFactory _enumDropdownProviderFactory;

		private readonly TransmitterSelectorInitializer _transmitterSelectorInitializer;

		private readonly RelayModeDescriptions _relayModeDescriptions;

		private EnumDropdownProvider<RelayMode> _modeDropdownProvider;

		private TransmitterSelector _inputASelector;

		private TransmitterSelector _inputBSelector;

		private VisualElement _root;

		private Dropdown _modeDropdown;

		private Label _modeDescription;

		private Relay _relay;

		private bool _showInputB;

		private Automator _lastInputB;

		public RelayFragment(VisualElementLoader visualElementLoader, DropdownItemsSetter dropdownItemsSetter, EnumDropdownProviderFactory enumDropdownProviderFactory, TransmitterSelectorInitializer transmitterSelectorInitializer, RelayModeDescriptions relayModeDescriptions)
		{
			_visualElementLoader = visualElementLoader;
			_dropdownItemsSetter = dropdownItemsSetter;
			_enumDropdownProviderFactory = enumDropdownProviderFactory;
			_transmitterSelectorInitializer = transmitterSelectorInitializer;
			_relayModeDescriptions = relayModeDescriptions;
		}

		public VisualElement InitializeFragment()
		{
			string elementName = "Game/EntityPanel/RelayFragment";
			_root = _visualElementLoader.LoadVisualElement(elementName);
			_modeDropdown = _root.Q<Dropdown>("Mode");
			_modeDropdownProvider = _enumDropdownProviderFactory.CreateLocalized(() => _relay.Mode, delegate(RelayMode relayMode)
			{
				_relay.SetMode(relayMode);
			}, RelayModeLocKeyPrefix);
			_inputASelector = _root.Q<TransmitterSelector>("InputA");
			_transmitterSelectorInitializer.Initialize(_inputASelector, () => _relay.InputA, delegate(Automator automator)
			{
				_relay.SetInputA(automator);
			});
			_inputBSelector = _root.Q<TransmitterSelector>("InputB");
			_transmitterSelectorInitializer.Initialize(_inputBSelector, () => _relay.InputB, delegate(Automator automator)
			{
				_relay.SetInputB(automator);
			});
			_modeDescription = _root.Q<Label>("ModeDescription");
			_root.ToggleDisplayStyle(visible: false);
			return _root;
		}

		public void ShowFragment(BaseComponent entity)
		{
			if (entity.TryGetComponent<Relay>(out _relay))
			{
				_root.ToggleDisplayStyle(visible: true);
				_dropdownItemsSetter.SetItems(_modeDropdown, _modeDropdownProvider);
				_inputASelector.Show(_relay);
				_inputBSelector.Show(_relay);
				_showInputB = _relay.UsesInputB;
			}
		}

		public void UpdateFragment()
		{
			if (!_relay)
			{
				return;
			}
			_inputASelector.UpdateStateIcon();
			if (_showInputB != _relay.UsesInputB)
			{
				_showInputB = _relay.UsesInputB;
				if (_showInputB)
				{
					if ((bool)_lastInputB)
					{
						_relay.SetInputB(_lastInputB);
					}
					_inputBSelector.UpdateSelectedValue();
				}
			}
			if (_showInputB)
			{
				_inputBSelector.ToggleDisplayStyle(visible: true);
				_inputBSelector.UpdateStateIcon();
				_lastInputB = _relay.InputB;
			}
			else
			{
				_inputBSelector.ToggleDisplayStyle(visible: false);
			}
			_modeDescription.text = _relayModeDescriptions.GetDescription(_relay.Mode);
		}

		public void ClearFragment()
		{
			_relay = null;
			_lastInputB = null;
			_modeDropdown.ClearItems();
			_inputASelector.ClearItems();
			_inputBSelector.ClearItems();
			_root.ToggleDisplayStyle(visible: false);
		}
	}
}
