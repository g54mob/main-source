using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HeathenEngineering.SteamworksIntegration.UI
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/unity-engine/ui-components/clan-profile")]
	public class ClanProfile : MonoBehaviour
	{
		[SerializeField]
		private RawImage icon;

		[SerializeField]
		private TextMeshProUGUI displayName;

		[SerializeField]
		private TextMeshProUGUI clanTag;

		private ClanData currentClan;

		public ClanData Clan
		{
			get
			{
				return currentClan;
			}
			set
			{
				Apply(value);
			}
		}

		private void OnEnable()
		{
			Friends.Client.EventPersonaStateChange.AddListener(HandlePersonaStateChange);
		}

		private void OnDisable()
		{
			Friends.Client.EventPersonaStateChange.RemoveListener(HandlePersonaStateChange);
		}

		private void HandlePersonaStateChange(PersonaStateChange arg)
		{
			if (Friends.Client.PersonaChangeHasFlag(arg.Flags, EPersonaChange.k_EPersonaChangeAvatar) && arg.SubjectId == currentClan)
			{
				Apply(currentClan);
			}
		}

		public void Apply(ClanData clan)
		{
			currentClan = clan;
			if (displayName != null)
			{
				displayName.text = clan.Name;
			}
			if (clanTag != null)
			{
				clanTag.text = clan.Tag;
			}
			if (icon != null)
			{
				clan.LoadIcon(delegate(Texture2D r)
				{
					icon.texture = r;
				});
			}
		}
	}
}
