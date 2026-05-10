using System;
using CTS.Core;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_SandboxToggle : CTSBehaviour
	{
		[SerializeField]
		private CTSToggle _toggle;

		[SerializeField]
		private Image _logoContainer;

		[SerializeField]
		private Sprite _loadingSprite;

		[SerializeField]
		private Sprite _emptySprite;

		[SerializeField]
		private Image _profileImageContainer;

		private readonly LockToggle _toggleLock = new LockToggle();

		public string ProfileName { get; set; }

		public FreemodeProfile Profile { get; private set; }

		public ToggleGroup Group
		{
			get
			{
				return _toggle.group;
			}
			set
			{
				_toggle.group = value;
			}
		}

		public static event Action<UI_SandboxToggle> ToggledOn;

		public event Action Loaded;

		protected override void OnAwake()
		{
			base.OnAwake();
			_toggleLock.Add(_toggle);
			_toggle.onValueChanged.AddListener(OnToggleValueChanged);
		}

		public void SetLoading()
		{
			_toggleLock.Lock();
			_profileImageContainer.gameObject.SetActive(value: false);
			_logoContainer.overrideSprite = _loadingSprite;
		}

		public void Load()
		{
			_toggleLock.Unlock();
			ES3Settings globalFolderSettings = SaveSettings.GetGlobalFolderSettings("Freemode_" + ProfileName + "/profile");
			if (!TryLoad(out var outProfile))
			{
				Profile = new FreemodeProfile(ProfileName);
				_logoContainer.overrideSprite = _emptySprite;
				_profileImageContainer.gameObject.SetActive(value: false);
				this.Loaded?.Invoke();
				return;
			}
			Profile = outProfile;
			Profile.LoadScreenshot();
			_profileImageContainer.gameObject.SetActive(value: true);
			if ((bool)Profile.Screenshot)
			{
				_profileImageContainer.overrideSprite = Profile.Screenshot;
			}
			else
			{
				_profileImageContainer.overrideSprite = Profile.MapInfo.MapIcon;
			}
			this.Loaded?.Invoke();
			bool TryLoad(out FreemodeProfile reference)
			{
				if (!ES3.FileExists(globalFolderSettings))
				{
					reference = null;
					return false;
				}
				reference = ES3.Load("Progress", (FreemodeProfile)null, globalFolderSettings);
				return reference != null;
			}
		}

		private void OnToggleValueChanged(bool isOn)
		{
			if (isOn)
			{
				UI_SandboxToggle.ToggledOn?.Invoke(this);
			}
		}
	}
}
