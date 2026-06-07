using System.Collections;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.CampaignTutorial.Scripts
{
	public class CampaignTutorialTextbox : MonoBehaviour
	{
		public UILabel TextLabel;

		public UIButton ContinueButton;

		public void SetActive(bool active)
		{
			StopAllCoroutines();
			base.gameObject.SetActive(active);
		}

		public virtual void Init(CampaignTutorialTextboxSetting textSetting, CampaignTutorialSetting setting)
		{
			SetActive(true);
			TextLabel.text = textSetting.Text.GetTranslation();
			Vector3 localPosition = TextLabel.transform.localPosition;
			float num = ((!setting.CloseWithButton) ? 0f : (ContinueButton.GetComponent<Collider>().bounds.size.y + 20f));
			switch (textSetting.Alignment)
			{
			case ETextboxTutorialAlignment.TopLeft:
				localPosition += new Vector3((float)(-TextLabel.width) / 2f, (float)TextLabel.height / 2f, 0f);
				break;
			case ETextboxTutorialAlignment.TopCenter:
				localPosition += new Vector3(0f, (float)TextLabel.height / 2f, 0f);
				break;
			case ETextboxTutorialAlignment.TopRight:
				localPosition += new Vector3((float)TextLabel.width / 2f, (float)TextLabel.height / 2f, 0f);
				break;
			case ETextboxTutorialAlignment.Left:
				localPosition += new Vector3((float)(-TextLabel.width) / 2f, 0f, 0f);
				break;
			case ETextboxTutorialAlignment.Right:
				localPosition += new Vector3((float)TextLabel.width / 2f, 0f, 0f);
				break;
			case ETextboxTutorialAlignment.BottomLeft:
				localPosition += new Vector3((float)(-TextLabel.width) / 2f, (float)(-TextLabel.height) / 2f - num, 0f);
				break;
			case ETextboxTutorialAlignment.BottomCenter:
				localPosition += new Vector3(0f, (float)(-TextLabel.height) / 2f - num, 0f);
				break;
			case ETextboxTutorialAlignment.BottomRight:
				localPosition += new Vector3((float)TextLabel.width / 2f, (float)(-TextLabel.height) / 2f - num, 0f);
				break;
			}
			Vector3 vector = TextLabel.transform.localPosition - localPosition;
			vector += (textSetting.AddTextboxOffset ? textSetting.TextboxOffset : Vector3.zero);
			switch (textSetting.TextboxTarget)
			{
			case ETutorialPositionTarget.Absolute:
				base.transform.localPosition = textSetting.TextboxPosition + vector;
				break;
			case ETutorialPositionTarget.UiTransform:
				StartCoroutine(StayAnchored(textSetting.TextboxUiTransform, vector));
				break;
			}
			if (!setting.CloseWithButton)
			{
				ContinueButton.gameObject.SetActive(false);
				ContinueButton.transform.localPosition = TextLabel.transform.localPosition + new Vector3(0f, (float)(-TextLabel.height) / 2f + 20f, 0f);
			}
			else
			{
				ContinueButton.gameObject.SetActive(true);
				ContinueButton.transform.localPosition = TextLabel.transform.localPosition + new Vector3(0f, (float)(-TextLabel.height) / 2f - 40f, 0f);
			}
		}

		public IEnumerator StayAnchored(Transform tr, Vector3 offset)
		{
			while (true)
			{
				base.transform.localPosition = base.transform.parent.InverseTransformPoint(tr.position) + offset;
				yield return null;
			}
		}

		public void Next()
		{
			SerializableMonobehaviour<CampaignTutorialManager, CampaignTutorialSaveData>.Instance.Next();
		}
	}
}
