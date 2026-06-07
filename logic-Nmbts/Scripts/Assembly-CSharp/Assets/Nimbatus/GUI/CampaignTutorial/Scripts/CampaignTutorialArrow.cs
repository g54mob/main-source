using System.Collections;
using Assets.Nimbatus.Scripts.Campaign;
using UnityEngine;

namespace Assets.Nimbatus.GUI.CampaignTutorial.Scripts
{
	public class CampaignTutorialArrow : MonoBehaviour
	{
		public UITexture ArrowSprite;

		public float BobAmount;

		public float BobSpeed;

		private readonly Vector3 _defaultOffset = new Vector3(-50f, 0f, 0f);

		private Vector3 _startPos;

		public void Awake()
		{
			_startPos = ArrowSprite.transform.localPosition;
		}

		public void Update()
		{
			ArrowSprite.transform.localPosition = _startPos + new Vector3(0f - BobAmount, 0f, 0f) * ((Mathf.Sin(Time.time * BobSpeed) + 1f) / 2f);
		}

		public void SetActive(bool active)
		{
			StopAllCoroutines();
			base.gameObject.SetActive(active);
		}

		public void Init(CampaignTutorialArrowSetting setting)
		{
			SetActive(true);
			base.transform.localEulerAngles = new Vector3(0f, 0f, setting.ArrowAngle);
			Vector3 vector = Quaternion.Euler(0f, 0f, setting.ArrowAngle) * _defaultOffset;
			vector += (setting.AddArrowOffset ? setting.ArrowOffset : Vector3.zero);
			switch (setting.ArrowTarget)
			{
			case ETutorialPositionTarget.Absolute:
				base.transform.localPosition = setting.ArrowPosition + vector;
				break;
			case ETutorialPositionTarget.UiTransform:
				StartCoroutine(StayAnchored(setting.ArrowUiTransform, vector));
				break;
			}
		}

		private IEnumerator StayAnchored(Transform tr, Vector3 offset)
		{
			while (true)
			{
				base.transform.localPosition = base.transform.parent.InverseTransformPoint(tr.position) + offset;
				yield return null;
			}
		}
	}
}
