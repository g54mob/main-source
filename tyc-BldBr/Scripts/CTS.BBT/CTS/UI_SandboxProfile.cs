using CTS.Core;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class UI_SandboxProfile : CTSBehaviour
	{
		[SerializeField]
		private ObjectToggleGroupByKey _toggleGroup;

		[SerializeField]
		private StringKey _createProfileMode;

		[SerializeField]
		private StringKey _continueProfileMode;

		[InjectScope(EGetScope.Children)]
		[Inject(false)]
		private UI_SandboxFeature[] _sandboxFeatures;

		public UI_SandboxToggle CurrentProfile { get; private set; }

		protected override void OnAwake()
		{
			base.OnAwake();
			UI_SandboxToggle.ToggledOn += OnProfileSelected;
		}

		private void OnDestroy()
		{
			UI_SandboxToggle.ToggledOn -= OnProfileSelected;
		}

		private void OnProfileSelected(UI_SandboxToggle obj)
		{
			if ((object)obj != CurrentProfile)
			{
				if ((bool)CurrentProfile)
				{
					CurrentProfile.Loaded -= OnProfileLoaded;
				}
				CurrentProfile = obj;
				if ((bool)CurrentProfile)
				{
					CurrentProfile.Loaded += OnProfileLoaded;
				}
				Repaint();
			}
		}

		public void PlayProfile()
		{
			if (CTSSingleton<ProfileManager>.Instance.CurrentProfile != CurrentProfile.Profile)
			{
				CTSSingleton<ProfileManager>.Instance.SetCurrentProfile(CurrentProfile.Profile);
			}
			CurrentProfile.Profile.PlayProfile();
		}

		private void OnProfileLoaded()
		{
			Repaint();
		}

		public void Repaint()
		{
			if ((object)CurrentProfile == null)
			{
				return;
			}
			FreemodeProfile profile = CurrentProfile.Profile;
			if (profile == null || !profile.MapInfo || !profile.IsValid())
			{
				_toggleGroup.Swap(_createProfileMode);
			}
			else
			{
				_toggleGroup.Swap(_continueProfileMode);
			}
			UI_SandboxFeature[] sandboxFeatures = _sandboxFeatures;
			foreach (UI_SandboxFeature uI_SandboxFeature in sandboxFeatures)
			{
				if (uI_SandboxFeature.isActiveAndEnabled)
				{
					uI_SandboxFeature.Repaint();
				}
			}
		}
	}
}
