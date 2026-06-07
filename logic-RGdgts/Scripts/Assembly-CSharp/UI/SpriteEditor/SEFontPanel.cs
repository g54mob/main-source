using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class SEFontPanel : MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField fontString;

		private string assetFontString;

		private UIFont uiFont;

		private int nMaxFont;

		[SerializeField]
		private TextMeshProUGUI textOnUI;

		private Coroutine showRedCharCo;

		private Action<string> OnValueChange;

		public void Init(FontPanelParameters par)
		{
		}

		public void SetAssetFont(int nMaxFont, string assetFontString)
		{
		}

		public void RefreshPanel(int nMaxFont, string assetFontString)
		{
		}

		public void OnGridSizeChange(int nMaxFont)
		{
		}

		private void InvokeOnValueChange()
		{
		}

		public void SetUIFont(string unique)
		{
		}

		private void ValueChangeCheck()
		{
		}

		private bool DoubleChar(string unique, char lastChar)
		{
			return false;
		}

		public void ActivatePanel(int nMaxFont, string assetFontString)
		{
		}

		public void DeactivatePanel()
		{
		}

		public void TooManyChar()
		{
		}

		private void ColorChar(int start, int end, Color color)
		{
		}

		public IEnumerator ShowRedCharCO()
		{
			return null;
		}
	}
}
