using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[Constructor("Construct")]
	public class UI_ProfileManager : CTSSingleton<UI_ProfileManager>, IRepaint
	{
		[SerializeField]
		private int _profileCount = 3;

		[SerializeField]
		private UI_Profile _profilePrefab;

		private readonly List<UI_Profile> _profiles = new List<UI_Profile>();

		private void Construct()
		{
			for (int i = 0; i < _profileCount; i++)
			{
				UI_Profile uI_Profile = CTSFactory.Instantiate(_profilePrefab, base.transform, instantiateInWorldSpace: false, false);
				uI_Profile.ProfileIndex = i;
				uI_Profile.gameObject.SetActive(value: true);
				_profiles.Add(uI_Profile);
			}
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		public void Repaint()
		{
			foreach (UI_Profile profile in _profiles)
			{
				profile.ClearProfileData();
				profile.Repaint();
			}
		}

		public void PlayOrShowProfiles()
		{
			foreach (UI_Profile profile in _profiles)
			{
				if (!profile.HasProfile())
				{
					profile.SetCurrentIndex();
					BBTUI.Instance.OpenCanvas(BBTUI.Instance.PanelID_Difficulty);
					return;
				}
			}
			BBTUI.Instance.OpenCanvas(BBTUI.Instance.PanelID_Profiles);
		}

		public void PlayNewGameOnCurrentProfile()
		{
			UI_Profile uI_Profile = _profiles[UI_Profile.CurrentProfileIndex];
			uI_Profile.ClearProfile();
			uI_Profile.NewGame();
		}
	}
}
