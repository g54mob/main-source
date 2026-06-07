using System;
using TMPro;
using UI.Elements;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class SESettingsPanel : MonoBehaviour
	{
		[SerializeField]
		private UIButton filterColorButton;

		[SerializeField]
		private UIButton bkgColorButton1;

		[SerializeField]
		private UIButton bkgColorButton2;

		[SerializeField]
		private UIButton gridColorButton;

		[SerializeField]
		private UIButton zoomColorButton;

		[SerializeField]
		private UIButton resetFilterButton;

		[SerializeField]
		private UIButton resetGridButton;

		[SerializeField]
		private UIButton resetZoomGridButton;

		[SerializeField]
		private UIButton resetBackgroundButton;

		[SerializeField]
		private UIToggle zoomGridToggle;

		public TMP_InputField filterAlpha;

		public TMP_InputField gridAlpha;

		public TMP_InputField zoomAlpha;

		private Action<float> OnGridAlphaChange;

		private Action<float> OnFilterAlphaChange;

		private Action<float> OnZoomAlphaChange;

		public void Init(SettingPanelParameters par)
		{
		}

		public void SetButtonsColors(Color grid, Color zoomGrid, Color bkg1, Color bkg2, Color filter)
		{
		}

		public void SetGridButtonsColors(Color grid, Color zoomGrid, Color filter)
		{
		}

		public void SetButtonsBKGColors(Color bkg1, Color bkg2)
		{
		}

		public void SetAlphasValues(float filter, float grid, float zoom)
		{
		}

		public void SetFilterAlpha(TMP_InputField inputField)
		{
		}

		public void SetGridAlpha(TMP_InputField inputField)
		{
		}

		public void SetZoomAlpha(TMP_InputField inputField)
		{
		}

		public void ActivatePanel()
		{
		}

		public void DeactivatePanel()
		{
		}
	}
}
