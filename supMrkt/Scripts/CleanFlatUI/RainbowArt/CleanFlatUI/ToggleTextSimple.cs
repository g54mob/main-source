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
		}

		private void Start()
		{
		}

		private void UpdateGUI()
		{
		}

		private void ToggleValueChanged(bool value)
		{
		}

		private void SetCanvasGroupAlpha(CanvasGroup obj, float alpha)
		{
		}
	}
}
