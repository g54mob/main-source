using Cysharp.Threading.Tasks;
using JSAM;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace UI.HUD
{
	public class InfoCursorsViewModel : ViewModelBase
	{
		public ObservableProperty<bool> Visible = new ObservableProperty<bool>();

		private InteractionRequest<Notification> _infoCursorChangedRequest;

		private InteractionRequest<Notification> _tickEnabledRequest;

		private InteractionRequest<SeparateHintsArgs> _useEnableSeparatellyRequest;

		private bool _equipEnabled;

		private bool _equipExternallyEnabled;

		private bool _pickupEnabled;

		private bool _useEnabled;

		private bool _useExternallyEnabled;

		private bool _toWorldEnabled;

		private bool _toWorldExternallyEnabled;

		private bool _holdEnabled;

		private bool _holdExternallyEnabled;

		private bool _dropEnabled;

		private bool _dropExternallyEnabled;

		private bool _upEnabled;

		private bool _upExternallyEnabled;

		private bool _downEnabled;

		private bool _downExternallyEnabled;

		private bool _scrollUpEnabled;

		private bool _scrollUpExternallyEnabled;

		private bool _scrollDownEnabled;

		private bool _scrollDownExternallyEnabled;

		private bool _tickEnabled;

		private bool _bgEnabled;

		private bool _bgExternallyEnabled;

		private string _useExtraText;

		private bool _useExtraTextEnabled;

		private bool _useHintSeparatelyEnabled;

		private string _useHintSeparatelyText = "";

		private bool _vehicleEnterEnabled;

		private string _itemName;

		public IInteractionRequest InfoCursorChangedRequest => _infoCursorChangedRequest;

		public IInteractionRequest TickEnabledRequest => _tickEnabledRequest;

		public IInteractionRequest UseEnableSeparatellyRequest => _useEnableSeparatellyRequest;

		public bool BGEnabled
		{
			get
			{
				return _bgEnabled;
			}
			set
			{
				Set(ref _bgEnabled, value, "BGEnabled");
			}
		}

		public bool EquipEnabled
		{
			get
			{
				return _equipEnabled;
			}
			set
			{
				Set(ref _equipEnabled, value, "EquipEnabled");
			}
		}

		public bool PickupEnabled
		{
			get
			{
				return _pickupEnabled;
			}
			set
			{
				Set(ref _pickupEnabled, value, "PickupEnabled");
			}
		}

		public bool UseEnabled
		{
			get
			{
				return _useEnabled;
			}
			set
			{
				Set(ref _useEnabled, value, "UseEnabled");
			}
		}

		public bool TickEnabled
		{
			get
			{
				return _tickEnabled;
			}
			set
			{
				Set(ref _tickEnabled, value, "TickEnabled");
			}
		}

		public string UseExtraText
		{
			get
			{
				return _useExtraText;
			}
			set
			{
				Set(ref _useExtraText, value, "UseExtraText");
			}
		}

		public bool UseExtraTextEnabled
		{
			get
			{
				return _useExtraTextEnabled;
			}
			set
			{
				Set(ref _useExtraTextEnabled, value, "UseExtraTextEnabled");
			}
		}

		public bool VehicleEnterEnabled
		{
			get
			{
				return _vehicleEnterEnabled;
			}
			set
			{
				Set(ref _vehicleEnterEnabled, value, "VehicleEnterEnabled");
			}
		}

		public bool ToWorldEnabled
		{
			get
			{
				return _toWorldEnabled;
			}
			set
			{
				Set(ref _toWorldEnabled, value, "ToWorldEnabled");
			}
		}

		public bool DropEnabled
		{
			get
			{
				return _dropEnabled;
			}
			set
			{
				Set(ref _dropEnabled, value, "DropEnabled");
			}
		}

		public bool UpEnabled
		{
			get
			{
				return _upEnabled;
			}
			set
			{
				Set(ref _upEnabled, value, "UpEnabled");
			}
		}

		public bool DownEnabled
		{
			get
			{
				return _downEnabled;
			}
			set
			{
				Set(ref _downEnabled, value, "DownEnabled");
			}
		}

		public bool ScrollUpEnabled
		{
			get
			{
				return _scrollUpEnabled;
			}
			set
			{
				Set(ref _scrollUpEnabled, value, "ScrollUpEnabled");
			}
		}

		public bool ScrollDownEnabled
		{
			get
			{
				return _scrollDownEnabled;
			}
			set
			{
				Set(ref _scrollDownEnabled, value, "ScrollDownEnabled");
			}
		}

		public bool HoldEnabled
		{
			get
			{
				return _holdEnabled;
			}
			set
			{
				Set(ref _holdEnabled, value, "HoldEnabled");
			}
		}

		public string ItemName
		{
			get
			{
				return _itemName;
			}
			set
			{
				Set(ref _itemName, value, "ItemName");
			}
		}

		public bool UseHintSeparatelyEnabled => _useHintSeparatelyEnabled;

		public string UseHintSeparatelyText => _useHintSeparatelyText;

		public InfoCursorsViewModel()
		{
			_infoCursorChangedRequest = new InteractionRequest<Notification>(this);
			_tickEnabledRequest = new InteractionRequest<Notification>(this);
			_useEnableSeparatellyRequest = new InteractionRequest<SeparateHintsArgs>(this);
		}

		public void EnableTickFor(float sec)
		{
			EnableAndDisableTick(sec);
		}

		public void EnablePickupHint(bool value)
		{
			if (PickupEnabled != value)
			{
				_infoCursorChangedRequest.Raise(new Notification("Note"));
			}
			PickupEnabled = value;
			if (!_bgExternallyEnabled)
			{
				BGEnabled = value;
			}
		}

		public void EnableUseHint(bool value)
		{
			if (!_useExternallyEnabled)
			{
				if (UseEnabled != value)
				{
					_infoCursorChangedRequest.Raise(new Notification("Note"));
				}
				UseEnabled = value;
				if (!_bgExternallyEnabled)
				{
					BGEnabled = value;
				}
			}
		}

		public void EnableUseHintExternally(bool value)
		{
			_useExternallyEnabled = value;
			_bgExternallyEnabled = value;
			Debug.Log($"EnableUseHintExternally: {value}");
			if (UseEnabled != value)
			{
				_infoCursorChangedRequest.Raise(new Notification("Note"));
			}
			UseEnabled = value;
			BGEnabled = value;
		}

		public void EnableEquipHint(bool value)
		{
			if (!_equipExternallyEnabled)
			{
				if (EquipEnabled != value)
				{
					_infoCursorChangedRequest.Raise(new Notification("Note"));
				}
				EquipEnabled = value;
				if (!_bgExternallyEnabled)
				{
					BGEnabled = value;
				}
			}
		}

		public void EnableEquipHintExternally(bool value)
		{
			_equipExternallyEnabled = value;
			_bgExternallyEnabled = value;
			_infoCursorChangedRequest.Raise(new Notification("Note"));
			EquipEnabled = value;
			BGEnabled = value;
		}

		public void EnableToWorldHint(bool value)
		{
			if (!_toWorldExternallyEnabled)
			{
				if (ToWorldEnabled != value)
				{
					_infoCursorChangedRequest.Raise(new Notification("Note"));
				}
				ToWorldEnabled = value;
				if (!_bgExternallyEnabled)
				{
					BGEnabled = value;
				}
			}
		}

		public void EnableHoldHint(bool value)
		{
			if (!_holdExternallyEnabled)
			{
				if (HoldEnabled != value)
				{
					_infoCursorChangedRequest.Raise(new Notification("Note"));
				}
				HoldEnabled = value;
				if (!_bgExternallyEnabled)
				{
					BGEnabled = value;
				}
			}
		}

		public void EnableDropHint(bool value)
		{
			if (!_dropExternallyEnabled)
			{
				if (DropEnabled != value)
				{
					_infoCursorChangedRequest.Raise(new Notification("Note"));
				}
				DropEnabled = value;
				if (!_bgExternallyEnabled)
				{
					BGEnabled = value;
				}
			}
		}

		public void EnableUpHint(bool value)
		{
			if (!_upExternallyEnabled)
			{
				if (UpEnabled != value)
				{
					_infoCursorChangedRequest.Raise(new Notification("Note"));
				}
				UpEnabled = value;
				if (!_bgExternallyEnabled)
				{
					BGEnabled = value;
				}
			}
		}

		public void EnableDownHint(bool value)
		{
			if (!_downExternallyEnabled)
			{
				if (DownEnabled != value)
				{
					_infoCursorChangedRequest.Raise(new Notification("Note"));
				}
				DownEnabled = value;
				if (!_bgExternallyEnabled)
				{
					BGEnabled = value;
				}
			}
		}

		public void EnableScrollUpHint(bool value)
		{
			if (!_scrollUpExternallyEnabled)
			{
				if (ScrollUpEnabled != value)
				{
					_infoCursorChangedRequest.Raise(new Notification("Note"));
				}
				ScrollUpEnabled = value;
				if (!_bgExternallyEnabled)
				{
					BGEnabled = value;
				}
			}
		}

		public void EnableScrollDownHint(bool value)
		{
			if (!_scrollDownExternallyEnabled)
			{
				if (ScrollDownEnabled != value)
				{
					_infoCursorChangedRequest.Raise(new Notification("Note"));
				}
				ScrollDownEnabled = value;
				if (!_bgExternallyEnabled)
				{
					BGEnabled = value;
				}
			}
		}

		public void SetUseExtraText(string text)
		{
			UseExtraText = text;
			UseExtraTextEnabled = !string.IsNullOrEmpty(text);
		}

		private async void EnableAndDisableTick(float sec)
		{
			_tickEnabled = true;
			await UniTask.WaitForSeconds(sec);
			_tickEnabled = false;
		}

		internal void EnableVehicleEnter(bool value)
		{
			VehicleEnterEnabled = value;
		}

		public void EnableUseHintSeperately(bool value, string additionalText = "")
		{
			_useHintSeparatelyEnabled = value;
			_useHintSeparatelyText = additionalText;
			SeparateHintsArgs context = new SeparateHintsArgs
			{
				Enabled = value,
				AdditionalText = additionalText
			};
			_useEnableSeparatellyRequest.Raise(context);
		}

		private void PlayPopupSound()
		{
			AudioManager.StopSoundIfPlaying(UILibrarySounds.UIClick);
			AudioManager.PlaySound(UILibrarySounds.UIClick);
		}
	}
}
