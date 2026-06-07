using System;
using Jundroo.Common.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.LevelMenuVR
{
	public class MenuSliderScript : MonoBehaviour
	{
		public Func<float, string> Formatter { get; set; } = (float x) => Utilities.FormatPercentage(x);

		public Slider Slider { get; private set; }

		public float Value
		{
			get
			{
				return Slider.value;
			}
			set
			{
				Slider.value = value;
				string text = Formatter(value);
				if (ValueText != null)
				{
					ValueText.text = text;
				}
				else
				{
					ValueTextMeshPro.text = text;
				}
			}
		}

		private Text ValueText { get; set; }

		private TextMeshProUGUI ValueTextMeshPro { get; set; }

		protected virtual void Awake()
		{
			Slider = GetComponentInChildren<Slider>();
			ValueText = Utilities.FindFirstGameObjectMyselfOrChildren("ValueText", base.gameObject).GetComponent<Text>();
			ValueTextMeshPro = Utilities.FindFirstGameObjectMyselfOrChildren("ValueText", base.gameObject).GetComponent<TextMeshProUGUI>();
		}
	}
}
