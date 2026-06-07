using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Campaign
{
	[Serializable]
	public class CampaignTutorialVignetteSetting
	{
		public bool BlockAll;

		public ETutorialPositionTarget VignetteCutoutTarget;

		[ShowIf("VignetteCutoutTarget", ETutorialPositionTarget.Absolute, true)]
		public Vector3 VignetteCutoutPosition;

		[ShowIf("VignetteCutoutTarget", ETutorialPositionTarget.UiTransform, true)]
		public Transform VignetteCutoutUiTransform;

		public Vector2 VignetteCutoutSize;

		[Range(0f, 1f)]
		public float VignetteFeather;
	}
}
