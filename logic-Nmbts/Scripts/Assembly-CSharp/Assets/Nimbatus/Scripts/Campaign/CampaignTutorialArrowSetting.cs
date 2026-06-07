using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Campaign
{
	[Serializable]
	public class CampaignTutorialArrowSetting
	{
		public float ArrowAngle;

		public ETutorialPositionTarget ArrowTarget;

		[ShowIf("ArrowTarget", ETutorialPositionTarget.Absolute, true)]
		public Vector3 ArrowPosition;

		[ShowIf("ArrowTarget", ETutorialPositionTarget.UiTransform, true)]
		public Transform ArrowUiTransform;

		public bool AddArrowOffset;

		[ShowIf("AddArrowOffset", true)]
		public Vector3 ArrowOffset;
	}
}
