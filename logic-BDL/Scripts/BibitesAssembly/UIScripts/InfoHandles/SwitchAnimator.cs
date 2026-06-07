using LeanTween.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.InfoHandles
{
	public class SwitchAnimator : MonoBehaviour
	{
		[SerializeField]
		private Toggle toggle;

		[SerializeField]
		private GameObject knob;

		[SerializeField]
		private TextMeshProUGUI option1Text;

		[SerializeField]
		private TextMeshProUGUI option2Text;

		[SerializeField]
		private float time;

		[SerializeField]
		private float offAlpha = 0.5f;

		private Color text1ColorOn;

		private Color text1ColorOff;

		private Color text2ColorOn;

		private Color text2ColorOff;

		private float d;

		private void Awake()
		{
			bool isOn = toggle.isOn;
			d = base.transform.GetComponent<RectTransform>().sizeDelta.y / 2f;
			knob.transform.localPosition = d * (float)(isOn ? 1 : (-1)) * Vector3.right;
			text1ColorOn = (text1ColorOff = option1Text.color);
			text2ColorOn = (text2ColorOff = option2Text.color);
			text1ColorOff.a = offAlpha;
			text2ColorOff.a = offAlpha;
			option1Text.color = (isOn ? text1ColorOff : text1ColorOn);
			option2Text.color = (isOn ? text2ColorOn : text2ColorOff);
		}

		public void Toggle(bool val)
		{
			knob.LeanMoveLocalX(d * (float)(val ? 1 : (-1)), time).setIgnoreTimeScale(useUnScaledTime: true);
			LeanTween.Framework.LeanTween.value(option1Text.gameObject, delegate(Color a)
			{
				option1Text.color = a;
			}, val ? text1ColorOn : text1ColorOff, val ? text1ColorOff : text1ColorOn, time).setIgnoreTimeScale(useUnScaledTime: true);
			LeanTween.Framework.LeanTween.value(option2Text.gameObject, delegate(Color a)
			{
				option2Text.color = a;
			}, val ? text2ColorOff : text2ColorOn, val ? text2ColorOn : text2ColorOff, time).setIgnoreTimeScale(useUnScaledTime: true);
		}

		private void OnRectTransformDimensionsChange()
		{
			bool isOn = toggle.isOn;
			d = base.transform.GetComponent<RectTransform>().sizeDelta.y / 2f;
			knob.transform.localPosition = d * (float)(isOn ? 1 : (-1)) * Vector3.right;
		}
	}
}
