using System;
using TMPro;
using UnityEngine;

namespace DV.Localization
{
	[RequireComponent(typeof(TMP_Text))]
	public class LocalizedNumber : MonoBehaviour
	{
		private enum Format : byte
		{
			WholeNumber = 0,
			OneDecimal = 1,
			TwoDecimals = 2,
			XDecimals = 3,
			Money = 4,
			ShortMoney = 5
		}

		[SerializeField]
		private float value;

		[SerializeField]
		private Format format;

		[SerializeField]
		private string suffix;

		public TMP_Text text;

		private void Awake()
		{
			UpdateText();
		}

		public void UpdateText()
		{
			string text;
			switch (format)
			{
			case Format.WholeNumber:
				text = "N0";
				break;
			case Format.OneDecimal:
				text = "N1";
				break;
			case Format.TwoDecimals:
				text = "N2";
				break;
			case Format.XDecimals:
				text = "#,0.#";
				break;
			case Format.Money:
				text = "N2";
				break;
			case Format.ShortMoney:
				text = "N0";
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			string text2 = value.ToString(text, LocalizationAPI.CC);
			if (!string.IsNullOrWhiteSpace(suffix))
			{
				text2 += suffix;
			}
			this.text.text = text2;
		}
	}
}
