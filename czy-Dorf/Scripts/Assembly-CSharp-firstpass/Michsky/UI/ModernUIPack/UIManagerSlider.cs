using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	[ExecuteInEditMode]
	public class UIManagerSlider : MonoBehaviour
	{
		public UIManager UIManagerAsset;

		public bool hasLabel;

		public bool hasPopupLabel;

		public Image background;

		public Image bar;

		public Image handle;

		public TextMeshProUGUI label;

		public TextMeshProUGUI popupLabel;

		private bool dynamicUpdateEnabled;

		private void OnEnable()
		{
			if (UIManagerAsset == null)
			{
				try
				{
					UIManagerAsset = Resources.Load<UIManager>("MUIP Manager");
				}
				catch
				{
					Debug.LogWarning("No UI Manager found. Assign it manually, otherwise you'll get errors about it.", this);
				}
			}
		}

		private void Awake()
		{
			if (!dynamicUpdateEnabled)
			{
				base.enabled = true;
				UpdateSlider();
			}
		}

		private void LateUpdate()
		{
			if (UIManagerAsset != null)
			{
				if (Application.isEditor && UIManagerAsset != null)
				{
					dynamicUpdateEnabled = true;
					UpdateSlider();
				}
				else
				{
					dynamicUpdateEnabled = false;
				}
			}
		}

		private void UpdateSlider()
		{
			try
			{
				if (UIManagerAsset.sliderThemeType == UIManager.SliderThemeType.BASIC)
				{
					background.color = UIManagerAsset.sliderBackgroundColor;
					bar.color = UIManagerAsset.sliderColor;
					handle.color = UIManagerAsset.sliderColor;
					if (hasLabel)
					{
						label.color = new Color(UIManagerAsset.sliderColor.r, UIManagerAsset.sliderColor.g, UIManagerAsset.sliderColor.b, label.color.a);
						label.font = UIManagerAsset.sliderLabelFont;
						label.fontSize = UIManagerAsset.sliderLabelFontSize;
					}
					if (hasPopupLabel)
					{
						popupLabel.color = new Color(UIManagerAsset.sliderPopupLabelColor.r, UIManagerAsset.sliderPopupLabelColor.g, UIManagerAsset.sliderPopupLabelColor.b, popupLabel.color.a);
						popupLabel.font = UIManagerAsset.sliderLabelFont;
					}
				}
				else if (UIManagerAsset.sliderThemeType == UIManager.SliderThemeType.CUSTOM)
				{
					background.color = UIManagerAsset.sliderBackgroundColor;
					bar.color = UIManagerAsset.sliderColor;
					handle.color = UIManagerAsset.sliderHandleColor;
					if (hasLabel)
					{
						label.color = new Color(UIManagerAsset.sliderLabelColor.r, UIManagerAsset.sliderLabelColor.g, UIManagerAsset.sliderLabelColor.b, label.color.a);
						label.font = UIManagerAsset.sliderLabelFont;
						label.font = UIManagerAsset.sliderLabelFont;
					}
					if (hasPopupLabel)
					{
						popupLabel.color = new Color(UIManagerAsset.sliderPopupLabelColor.r, UIManagerAsset.sliderPopupLabelColor.g, UIManagerAsset.sliderPopupLabelColor.b, popupLabel.color.a);
						popupLabel.font = UIManagerAsset.sliderLabelFont;
					}
				}
			}
			catch
			{
			}
		}
	}
}
