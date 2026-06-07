using System;
using Assets.Nimbatus.GUI.MissionControl.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Video;

namespace Assets.Nimbatus.Scripts.Campaign
{
	[Serializable]
	public class CampaignTutorialSetting
	{
		[Serializable]
		public class MiCoTutorialSetting
		{
			public bool BlockMapMovement = true;

			public EMiCoTutorialTarget Target;

			[HideIf("Target", EMiCoTutorialTarget.None, true)]
			public GalaxyMapUiManager Manager;

			[ShowIf("Target", EMiCoTutorialTarget.InfluenceLabel, true)]
			public int InfIndex;

			[ShowIf("Target", EMiCoTutorialTarget.SpecificLocation, true)]
			public int LocIndex;

			[HideIf("Target", EMiCoTutorialTarget.None, true)]
			[HideIf("Target", EMiCoTutorialTarget.InfluenceLabel, true)]
			public bool SelectLocation;

			public bool OverrideZoom;

			[ShowIf("OverrideZoom", true)]
			public float TargetZoom;
		}

		public string UniqueId;

		public string RequireFlag;

		[Header("Arrow")]
		public bool HasArrow = true;

		[ShowIf("HasArrow", true)]
		public CampaignTutorialArrowSetting ArrowSetting = new CampaignTutorialArrowSetting();

		[Header("Textbox")]
		public bool HasText = true;

		[ShowIf("HasText", true)]
		public CampaignTutorialTextboxSetting TextboxSetting = new CampaignTutorialTextboxSetting();

		[Header("Vignette")]
		public bool HasVignette = true;

		[ShowIf("HasVignette", true)]
		public CampaignTutorialVignetteSetting VignetteSetting = new CampaignTutorialVignetteSetting();

		[Header("Other")]
		public bool CloseWithButton = true;

		public string WaitForFlag;

		[HideIf("IsWorkshop", true)]
		public bool IsMissionControl;

		[ShowIf("IsMissionControl", true)]
		public MiCoTutorialSetting MiCoSettings = new MiCoTutorialSetting();

		[HideIf("IsMissionControl", true)]
		public bool IsWorkshop;

		[ShowIf("IsWorkshop", true)]
		public Texture Image;

		[ShowIf("IsWorkshop", true)]
		public VideoClip Video;

		public bool IsAllowed()
		{
			if (!SerializableMonobehaviour<CampaignTutorialManager, CampaignTutorialSaveData>.Instance.CheckFlag(UniqueId))
			{
				if (!string.IsNullOrEmpty(RequireFlag))
				{
					return SerializableMonobehaviour<CampaignTutorialManager, CampaignTutorialSaveData>.Instance.CheckFlag(RequireFlag);
				}
				return true;
			}
			return false;
		}
	}
}
