using FullInspector.Generated.SharedInstance;
using UnityEngine;

namespace TH20
{
	public class MapPinUnlockMe : MapPin
	{
		[SerializeField]
		protected MeshRenderer _meshIcon;

		[SerializeField]
		private Material _materialDefault;

		[SerializeField]
		private Material _materialHighlighted;

		[SerializeField]
		private SharedInstance_TH20TH20_DLCItemDefinition _requiredDLC;

		[SerializeField]
		private SharedInstance_TH20TH20_LevelConfig _showAfterLevelConfig;

		[SerializeField]
		private int _showAfterLevelRequiredStars;

		[SerializeField]
		private SharedInstance_TH20TH20_LevelConfig _hideAfterLevelConfig;

		[SerializeField]
		private int _hideAfterLevelRequiredStars;

		[SerializeField]
		private LocalisedString _guiName;

		[SerializeField]
		private LocalisedString _guiDescription;

		[SerializeField]
		private SharedInstance_TH20TH20_LevelConfig _levelConfigOfCutscene;

		[SerializeField]
		private string _unlockMeTriggerTag;

		private const int MaxLevelStars = 3;

		protected bool _cursorOver;

		protected Metagame _metagame;

		protected MetagameMap _metagameMap;

		protected HUD _hud;

		private MetagameHospitalRecord _hospitalShowAfterLevelRecord;

		private MetagameHospitalRecord _hospitalHideAfterLevelRecord;

		protected const string AudioEventNameOnSelected = "PopOut3:UI";

		public LocalisedString GUIName => _guiName;

		public LocalisedString GUIDescription => _guiDescription;

		public string UnlockMeTag => _unlockMeTriggerTag;

		public LevelConfig LevelConfigOfCutsceneToPlay
		{
			get
			{
				if (!_levelConfigOfCutscene.IsNull())
				{
					return _levelConfigOfCutscene.Instance;
				}
				return null;
			}
		}

		public DLCItemDefinition RequiredDLC
		{
			get
			{
				if (!_requiredDLC.IsNull())
				{
					return _requiredDLC.Instance;
				}
				return null;
			}
		}

		public void Initialise(Metagame metagame, MetagameMap metagameMap, SaveSystem saveSystem)
		{
			_metagame = metagame;
			_metagameMap = metagameMap;
			_hud = metagameMap.HUD;
			_hospitalShowAfterLevelRecord = _metagame.GetHospitalRecord(_showAfterLevelConfig.Instance);
			_hospitalHideAfterLevelRecord = _metagame.GetHospitalRecord(_hideAfterLevelConfig.Instance);
			RefreshMaterial();
		}

		public override void Refresh(bool refreshVisuals = true)
		{
			if (_metagame == null)
			{
				return;
			}
			if (!PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.DLCPurchase))
			{
				GameObjectUtils.SetActive(_meshIcon.gameObject, isActive: false);
				return;
			}
			bool num = _showAfterLevelConfig.Instance.IsPlayable(_metagame);
			bool flag = _hideAfterLevelConfig.Instance.IsPlayable(_metagame);
			bool num2 = num && _hospitalShowAfterLevelRecord.TotalStars() >= _showAfterLevelRequiredStars;
			bool flag2 = flag && _hospitalHideAfterLevelRecord.TotalStars() >= _hideAfterLevelRequiredStars;
			bool flag3 = _metagame.IsUnlockMeTagTriggered(_unlockMeTriggerTag) && _hideAfterLevelRequiredStars <= 3;
			if (num2 && !flag2 && !flag3)
			{
				GameObjectUtils.SetActive(_meshIcon.gameObject, isActive: true);
			}
			else
			{
				GameObjectUtils.SetActive(_meshIcon.gameObject, isActive: false);
			}
		}

		public override void OnSelected()
		{
			base.OnSelected();
			AudioManager.Instance.Play("PopOut3:UI");
			SelectedHospitalMenu selectedHospitalMenu = _hud.FindMenu<SelectedHospitalMenu>();
			if (selectedHospitalMenu == null)
			{
				selectedHospitalMenu = _hud.CreateMenu<SelectedHospitalMenu>();
			}
			selectedHospitalMenu.OpenMenu();
			selectedHospitalMenu.SetupUnlockMe(this, _metagameMap);
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
			SelectedHospitalMenu selectedHospitalMenu = _hud.FindMenu<SelectedHospitalMenu>(includeInactive: false);
			if (selectedHospitalMenu != null)
			{
				selectedHospitalMenu.CloseMenu();
			}
		}

		protected virtual void RefreshMaterial()
		{
			if (_metagame != null)
			{
				_meshIcon.material = (_cursorOver ? _materialHighlighted : _materialDefault);
			}
		}
	}
}
