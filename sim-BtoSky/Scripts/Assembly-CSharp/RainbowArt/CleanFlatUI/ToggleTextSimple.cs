using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ToggleTextSimple : MonoBehaviour
	{
		[SerializeField]
		private Toggle toggle;

		[SerializeField]
		private RectTransform on;

		[SerializeField]
		private RectTransform off;

		private CanvasGroup canvasGroupOn;

		private CanvasGroup canvasGroupOff;

		private void Awake()
		{
			toggle = GetComponent<Toggle>();
			toggle.onValueChanged.AddListener(ToggleValueChanged);
			canvasGroupOn = on.gameObject.GetComponent<CanvasGroup>();
			canvasGroupOff = off.gameObject.GetComponent<CanvasGroup>();
		}

		private void Start()
		{
			UpdateGUI();
		}

		private void UpdateGUI()
		{
			if (toggle.isOn)
			{
				SetCanvasGroupAlpha(canvasGroupOn, 1f);
				SetCanvasGroupAlpha(canvasGroupOff, 0f);
			}
			else
			{
				SetCanvasGroupAlpha(canvasGroupOn, 0f);
				SetCanvasGroupAlpha(canvasGroupOff, 1f);
			}
		}

		private void ToggleValueChanged(bool value)
		{
			if (value)
			{
				SetCanvasGroupAlpha(canvasGroupOn, 1f);
				SetCanvasGroupAlpha(canvasGroupOff, 0f);
			}
			else
			{
				SetCanvasGroupAlpha(canvasGroupOn, 0f);
				SetCanvasGroupAlpha(canvasGroupOff, 1f);
			}
		}

		private void SetCanvasGroupAlpha(CanvasGroup obj, float alpha)
		{
			obj.alpha = alpha;
		}
	}
}
