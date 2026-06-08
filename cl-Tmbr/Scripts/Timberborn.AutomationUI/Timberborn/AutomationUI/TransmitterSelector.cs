using System;
using System.Diagnostics;
using Timberborn.Automation;
using Timberborn.BaseComponentSystem;
using Timberborn.CoreUI;
using Timberborn.DropdownSystem;
using Timberborn.EntitySystem;
using Timberborn.Localization;
using Timberborn.SingletonSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace Timberborn.AutomationUI
{
	[UxmlElement]
	public class TransmitterSelector : VisualElement, ILocalizableElement
	{
		[Serializable]
		public new class UxmlSerializedData : VisualElement.UxmlSerializedData
		{
			[UxmlAttribute("label-loc-key")]
			[SerializeField]
			private string _labelLocKey;

			[SerializeField]
			[UxmlIgnore]
			[HideInInspector]
			private UxmlAttributeFlags _labelLocKey_UxmlAttributeFlags;

			[RegisterUxmlCache]
			[Conditional("UNITY_EDITOR")]
			public new static void Register()
			{
				UxmlDescriptionCache.RegisterType(typeof(UxmlSerializedData), new UxmlAttributeNames[1]
				{
					new UxmlAttributeNames("_labelLocKey", "label-loc-key", null)
				});
			}

			public override object CreateInstance()
			{
				return new TransmitterSelector();
			}

			public override void Deserialize(object obj)
			{
				base.Deserialize(obj);
				TransmitterSelector transmitterSelector = (TransmitterSelector)obj;
				if (UnityEngine.UIElements.UxmlSerializedData.ShouldWriteAttributeValue(_labelLocKey_UxmlAttributeFlags))
				{
					transmitterSelector._labelLocKey = _labelLocKey;
				}
			}
		}

		private DropdownItemsSetter _dropdownItemsSetter;

		private EventBus _eventBus;

		private TransmitterPickerTool _transmitterPickerTool;

		private readonly Dropdown _dropdown;

		private TransmitterDropdownProvider _transmitterDropdownProvider;

		private AutomationStateIcon _automationStateIcon;

		[UxmlAttribute("label-loc-key")]
		private string _labelLocKey;

		private BaseComponent _owner;

		private Action<Automator> _setter;

		public bool IsSet => true;

		public TransmitterSelector()
		{
			Resources.Load<VisualTreeAsset>("UI/Views/Game/TransmitterSelector").CloneTree(this);
			_dropdown = this.Q<Dropdown>("TransmitterDropdown");
			_dropdown.Showed += OnDropdownShowed;
		}

		public void Initialize(DropdownItemsSetter dropdownItemsSetter, EventBus eventBus, TransmitterPickerTool transmitterPickerTool, TransmitterDropdownProvider transmitterDropdownProvider, AutomationStateIcon automationStateIcon, Action<Automator> setter)
		{
			_dropdownItemsSetter = dropdownItemsSetter;
			_eventBus = eventBus;
			_transmitterPickerTool = transmitterPickerTool;
			_transmitterDropdownProvider = transmitterDropdownProvider;
			_automationStateIcon = automationStateIcon;
			_setter = setter;
		}

		public void Localize(ILoc loc)
		{
			_dropdown.OverrideLabelLocKey(_labelLocKey);
		}

		public void Show(BaseComponent owner)
		{
			_owner = owner;
			_dropdownItemsSetter.SetItems(_dropdown, _transmitterDropdownProvider);
			_eventBus.Register(this);
		}

		public void UpdateStateIcon()
		{
			_automationStateIcon.Update();
		}

		public void UpdateSelectedValue()
		{
			_dropdown.UpdateSelectedValue();
		}

		public void ClearItems()
		{
			_owner = null;
			_dropdown.ClearItems();
			_eventBus.Unregister(this);
		}

		[OnEvent]
		public void OnEntityInitialized(EntityInitializedEvent entityInitializedEvent)
		{
			UpdateItems(entityInitializedEvent.Entity);
		}

		[OnEvent]
		public void OnEntityDeleted(EntityDeletedEvent entityDeletedEvent)
		{
			UpdateItems(entityDeletedEvent.Entity);
		}

		private void OnDropdownShowed(object sender, EventArgs args)
		{
			_transmitterPickerTool.SwitchTo(_owner, _dropdown, _setter);
		}

		private void UpdateItems(BaseComponent entity)
		{
			if ((bool)_owner && entity.HasComponent<Automator>())
			{
				_dropdown.ClearItems();
				_dropdownItemsSetter.SetItems(_dropdown, _transmitterDropdownProvider);
			}
		}
	}
}
