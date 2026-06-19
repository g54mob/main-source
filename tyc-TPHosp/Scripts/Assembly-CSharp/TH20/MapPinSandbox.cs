using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class MapPinSandbox : MapPin
	{
		[SerializeField]
		private Image _imagePin;

		[SerializeField]
		private Sprite _spritePinDefault;

		[SerializeField]
		private Sprite _spritePinHighlighted;

		private SandboxSettings _settings;

		private SandboxSaveManager _saveManager;

		private MetagameMap _metagameMap;

		private HUD _hud;

		private bool _cursorOver;

		private GameObject _activeHospitalEffect;

		private const string AudioEventNameOnSelected = "PopOut3:UI";

		public SandboxSettings Settings => _settings;

		public void Initialise(SandboxSettings settings, SandboxSaveManager saveManager, MetagameMap metagameMap)
		{
			_settings = settings;
			_saveManager = saveManager;
			_metagameMap = metagameMap;
			_hud = metagameMap.HUD;
			Refresh();
			RefreshMaterial();
			SandboxSettings settings2 = _settings;
			settings2.OnSettingsChanged = (Action)Delegate.Combine(settings2.OnSettingsChanged, new Action(OnSettingsChanged));
		}

		public override void PrepareForDestroy()
		{
			SandboxSettings settings = _settings;
			settings.OnSettingsChanged = (Action)Delegate.Remove(settings.OnSettingsChanged, new Action(OnSettingsChanged));
			GameObjectUtils.SafeDestroy(ref _activeHospitalEffect);
		}

		private bool IsPlayingThisLevel()
		{
			return _settings == SandboxSaveManager.CurrentSettings;
		}

		public override void OnSelected()
		{
			base.OnSelected();
			SelectedSandboxMenu selectedSandboxMenu = _hud.FindMenu<SelectedSandboxMenu>();
			if (selectedSandboxMenu == null)
			{
				selectedSandboxMenu = _hud.CreateMenu<SelectedSandboxMenu>();
			}
			selectedSandboxMenu.OpenMenu();
			selectedSandboxMenu.Setup(_settings, _metagameMap, _saveManager, _metagameMap.App.DLCManager);
			AudioManager.Instance.Play("PopOut3:UI");
		}

		public override void OnCursorOver(bool over)
		{
			base.OnCursorOver(over);
			_cursorOver = over;
			RefreshMaterial();
		}

		public override void OnUnselected()
		{
			base.OnUnselected();
			SelectedSandboxMenu selectedSandboxMenu = _hud.FindMenu<SelectedSandboxMenu>(includeInactive: false);
			if (selectedSandboxMenu != null)
			{
				selectedSandboxMenu.CloseMenu();
			}
		}

		private void OnSettingsChanged()
		{
			Refresh();
		}

		private void RefreshMaterial()
		{
			_imagePin.sprite = (_cursorOver ? _spritePinHighlighted : _spritePinDefault);
		}

		public override void Refresh(bool refreshVisuals = true)
		{
			if (_settings != null)
			{
				RefreshMaterial();
			}
		}

		public override bool IsPinUnlocked()
		{
			return true;
		}
	}
}
