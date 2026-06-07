using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ToggleText : MonoBehaviour
	{
		[SerializeField]
		private Toggle toggle;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private RectTransform on;

		[SerializeField]
		private RectTransform off;

		private CanvasGroup canvasGroupOn;

		private CanvasGroup canvasGroupOff;

		private void Start()
		{
			UpdateGUI();
		}

		private void UpdateGUI()
		{
			if (animator != null)
			{
				animator.enabled = false;
			}
			if (toggle == null)
			{
				toggle = GetComponent<Toggle>();
			}
			toggle.onValueChanged.AddListener(ToggleValueChanged);
			if (canvasGroupOn == null)
			{
				canvasGroupOn = on.gameObject.GetComponent<CanvasGroup>();
			}
			if (canvasGroupOff == null)
			{
				canvasGroupOff = off.gameObject.GetComponent<CanvasGroup>();
			}
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
			if (animator != null)
			{
				if (!animator.enabled)
				{
					animator.enabled = true;
				}
				if (value)
				{
					animator.Play("On", 0, 0f);
				}
				else
				{
					animator.Play("Off", 0, 0f);
				}
			}
		}

		private void SetCanvasGroupAlpha(CanvasGroup obj, float alpha)
		{
			obj.alpha = alpha;
		}
	}
}
