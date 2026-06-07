using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Campaign
{
	[Serializable]
	public class CampaignTutorialTextboxSetting
	{
		public TranslationTerm Text;

		public ETutorialPositionTarget TextboxTarget;

		[ShowIf("TextboxTarget", ETutorialPositionTarget.Absolute, true)]
		public Vector3 TextboxPosition;

		[ShowIf("TextboxTarget", ETutorialPositionTarget.UiTransform, true)]
		public Transform TextboxUiTransform;

		public ETextboxTutorialAlignment Alignment = ETextboxTutorialAlignment.Center;

		public bool AddTextboxOffset;

		[ShowIf("AddTextboxOffset", true)]
		public Vector3 TextboxOffset;
	}
}
