using LeanTween.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.UIReferences
{
	public class LoadingPanel : MonoBehaviour
	{
		public CanvasGroup CG;

		public Transform Spinner;

		public Transform pellet;

		public Slider LoadingBar;

		public TextMeshProUGUI progressText;

		public float spinnerSpeed = 180f;

		public void SetActive(bool active, float delay = 0f)
		{
			if (delay > 0f)
			{
				if (active)
				{
					LeanTween.Framework.LeanTween.alphaCanvas(CG, 1f, delay).setEaseInSine().setOnComplete(Open);
				}
				else
				{
					LeanTween.Framework.LeanTween.alphaCanvas(CG, 0f, delay).setEaseInSine().setOnComplete(Close);
				}
			}
			else
			{
				base.gameObject.SetActive(active);
			}
		}

		private void Open()
		{
			base.gameObject.SetActive(value: true);
		}

		private void Close()
		{
			base.gameObject.SetActive(value: false);
		}

		private void Update()
		{
			Spinner.Rotate(0f, 0f, (0f - spinnerSpeed) * Time.unscaledDeltaTime);
			pellet.rotation = Quaternion.Euler(0f, 0f, 0f - Spinner.rotation.z);
		}

		public void UpdateProgress(float _progress)
		{
			LoadingBar.value = _progress;
			progressText.text = (_progress * 100f).ToString("F2") + "%";
		}
	}
}
