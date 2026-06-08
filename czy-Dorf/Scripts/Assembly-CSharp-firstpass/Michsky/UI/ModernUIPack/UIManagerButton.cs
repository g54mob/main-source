using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	[ExecuteInEditMode]
	public class UIManagerButton : MonoBehaviour
	{
		public enum ButtonType
		{
			BASIC = 0,
			BASIC_ONLY_ICON = 1,
			BASIC_WITH_ICON = 2,
			BASIC_OUTLINE = 3,
			BASIC_OUTLINE_ONLY_ICON = 4,
			BASIC_OUTLINE_WITH_ICON = 5,
			RADIAL_ONLY_ICON = 6,
			RADIAL_OUTLINE_ONLY_ICON = 7,
			ROUNDED = 8,
			ROUNDED_OUTLINE = 9
		}

		public UIManager UIManagerAsset;

		public ButtonType buttonType;

		private bool dynamicUpdateEnabled;

		public Image basicFilled;

		public TextMeshProUGUI basicText;

		public Image basicOnlyIconFilled;

		public Image basicOnlyIconIcon;

		public Image basicWithIconFilled;

		public Image basicWithIconIcon;

		public TextMeshProUGUI basicWithIconText;

		public Image basicOutlineBorder;

		public Image basicOutlineFilled;

		public TextMeshProUGUI basicOutlineText;

		public TextMeshProUGUI basicOutlineTextHighligted;

		public Image basicOutlineOOBorder;

		public Image basicOutlineOOFilled;

		public Image basicOutlineOOIcon;

		public Image basicOutlineOOIconHighlighted;

		public Image basicOutlineWOBorder;

		public Image basicOutlineWOFilled;

		public Image basicOutlineWOIcon;

		public Image basicOutlineWOIconHighlighted;

		public TextMeshProUGUI basicOutlineWOText;

		public TextMeshProUGUI basicOutlineWOTextHighligted;

		public Image radialOOBackground;

		public Image radialOOIcon;

		public Image radialOutlineOOBorder;

		public Image radialOutlineOOFilled;

		public Image radialOutlineOOIcon;

		public Image radialOutlineOOIconHighlighted;

		public Image roundedBackground;

		public TextMeshProUGUI roundedText;

		public Image roundedOutlineBorder;

		public Image roundedOutlineFilled;

		public TextMeshProUGUI roundedOutlineText;

		public TextMeshProUGUI roundedOutlineTextHighligted;

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
					Debug.Log("No UI Manager found. Assign it manually, otherwise you'll get errors about it.", this);
				}
			}
		}

		private void Awake()
		{
			if (!dynamicUpdateEnabled)
			{
				base.enabled = true;
				UpdateButton();
			}
		}

		private void LateUpdate()
		{
			if (Application.isEditor && UIManagerAsset != null)
			{
				if (UIManagerAsset.enableDynamicUpdate)
				{
					dynamicUpdateEnabled = true;
					UpdateButton();
				}
				else
				{
					dynamicUpdateEnabled = false;
				}
			}
		}

		private void UpdateButton()
		{
			try
			{
				if (UIManagerAsset.buttonThemeType == UIManager.ButtonThemeType.BASIC)
				{
					if (buttonType == ButtonType.BASIC)
					{
						basicFilled.color = UIManagerAsset.buttonBorderColor;
						basicText.color = UIManagerAsset.buttonFilledColor;
						basicText.font = UIManagerAsset.buttonFont;
						basicText.fontSize = UIManagerAsset.buttonFontSize;
					}
					else if (buttonType == ButtonType.BASIC_ONLY_ICON)
					{
						basicOnlyIconFilled.color = UIManagerAsset.buttonBorderColor;
						basicOnlyIconIcon.color = UIManagerAsset.buttonFilledColor;
					}
					else if (buttonType == ButtonType.BASIC_WITH_ICON)
					{
						basicWithIconFilled.color = UIManagerAsset.buttonBorderColor;
						basicWithIconIcon.color = UIManagerAsset.buttonFilledColor;
						basicWithIconText.color = UIManagerAsset.buttonFilledColor;
						basicWithIconText.font = UIManagerAsset.buttonFont;
						basicWithIconText.fontSize = UIManagerAsset.buttonFontSize;
					}
					else if (buttonType == ButtonType.BASIC_OUTLINE)
					{
						basicOutlineBorder.color = UIManagerAsset.buttonBorderColor;
						basicOutlineFilled.color = UIManagerAsset.buttonBorderColor;
						basicOutlineText.color = UIManagerAsset.buttonBorderColor;
						basicOutlineTextHighligted.color = UIManagerAsset.buttonFilledColor;
						basicOutlineText.font = UIManagerAsset.buttonFont;
						basicOutlineTextHighligted.font = UIManagerAsset.buttonFont;
						basicOutlineText.fontSize = UIManagerAsset.buttonFontSize;
						basicOutlineTextHighligted.fontSize = UIManagerAsset.buttonFontSize;
					}
					else if (buttonType == ButtonType.BASIC_OUTLINE_ONLY_ICON)
					{
						basicOutlineOOBorder.color = UIManagerAsset.buttonBorderColor;
						basicOutlineOOFilled.color = UIManagerAsset.buttonBorderColor;
						basicOutlineOOIcon.color = UIManagerAsset.buttonBorderColor;
						basicOutlineOOIconHighlighted.color = UIManagerAsset.buttonFilledColor;
					}
					else if (buttonType == ButtonType.BASIC_OUTLINE_WITH_ICON)
					{
						basicOutlineWOBorder.color = UIManagerAsset.buttonBorderColor;
						basicOutlineWOFilled.color = UIManagerAsset.buttonBorderColor;
						basicOutlineWOIcon.color = UIManagerAsset.buttonBorderColor;
						basicOutlineWOIconHighlighted.color = UIManagerAsset.buttonFilledColor;
						basicOutlineWOText.color = UIManagerAsset.buttonBorderColor;
						basicOutlineWOTextHighligted.color = UIManagerAsset.buttonFilledColor;
						basicOutlineWOText.font = UIManagerAsset.buttonFont;
						basicOutlineWOTextHighligted.font = UIManagerAsset.buttonFont;
						basicOutlineWOText.fontSize = UIManagerAsset.buttonFontSize;
						basicOutlineWOTextHighligted.fontSize = UIManagerAsset.buttonFontSize;
					}
					else if (buttonType == ButtonType.RADIAL_ONLY_ICON)
					{
						radialOOBackground.color = UIManagerAsset.buttonBorderColor;
						radialOOIcon.color = UIManagerAsset.buttonFilledColor;
					}
					else if (buttonType == ButtonType.RADIAL_OUTLINE_ONLY_ICON)
					{
						radialOutlineOOBorder.color = UIManagerAsset.buttonBorderColor;
						radialOutlineOOFilled.color = UIManagerAsset.buttonBorderColor;
						radialOutlineOOIcon.color = UIManagerAsset.buttonIconColor;
						radialOutlineOOIconHighlighted.color = UIManagerAsset.buttonFilledColor;
					}
					else if (buttonType == ButtonType.ROUNDED)
					{
						roundedBackground.color = UIManagerAsset.buttonBorderColor;
						roundedText.color = UIManagerAsset.buttonFilledColor;
						roundedText.font = UIManagerAsset.buttonFont;
						roundedText.fontSize = UIManagerAsset.buttonFontSize;
					}
					else if (buttonType == ButtonType.ROUNDED_OUTLINE)
					{
						roundedOutlineBorder.color = UIManagerAsset.buttonBorderColor;
						roundedOutlineFilled.color = UIManagerAsset.buttonBorderColor;
						roundedOutlineText.color = UIManagerAsset.buttonBorderColor;
						roundedOutlineTextHighligted.color = UIManagerAsset.buttonFilledColor;
						roundedOutlineText.font = UIManagerAsset.buttonFont;
						roundedOutlineTextHighligted.font = UIManagerAsset.buttonFont;
						roundedOutlineText.fontSize = UIManagerAsset.buttonFontSize;
						roundedOutlineTextHighligted.fontSize = UIManagerAsset.buttonFontSize;
					}
				}
				else if (UIManagerAsset.buttonThemeType == UIManager.ButtonThemeType.CUSTOM)
				{
					if (buttonType == ButtonType.BASIC)
					{
						basicFilled.color = UIManagerAsset.buttonFilledColor;
						basicText.color = UIManagerAsset.buttonTextBasicColor;
						basicText.font = UIManagerAsset.buttonFont;
						basicText.fontSize = UIManagerAsset.buttonFontSize;
					}
					else if (buttonType == ButtonType.BASIC_ONLY_ICON)
					{
						basicOnlyIconFilled.color = UIManagerAsset.buttonFilledColor;
						basicOnlyIconIcon.color = UIManagerAsset.buttonIconBasicColor;
					}
					else if (buttonType == ButtonType.BASIC_WITH_ICON)
					{
						basicWithIconFilled.color = UIManagerAsset.buttonFilledColor;
						basicWithIconIcon.color = UIManagerAsset.buttonIconBasicColor;
						basicWithIconText.color = UIManagerAsset.buttonTextBasicColor;
						basicWithIconText.font = UIManagerAsset.buttonFont;
						basicWithIconText.fontSize = UIManagerAsset.buttonFontSize;
					}
					else if (buttonType == ButtonType.BASIC_OUTLINE)
					{
						basicOutlineBorder.color = UIManagerAsset.buttonBorderColor;
						basicOutlineFilled.color = UIManagerAsset.buttonFilledColor;
						basicOutlineText.color = UIManagerAsset.buttonTextColor;
						basicOutlineTextHighligted.color = UIManagerAsset.buttonTextHighlightedColor;
						basicOutlineText.font = UIManagerAsset.buttonFont;
						basicOutlineTextHighligted.font = UIManagerAsset.buttonFont;
						basicOutlineText.fontSize = UIManagerAsset.buttonFontSize;
						basicOutlineTextHighligted.fontSize = UIManagerAsset.buttonFontSize;
					}
					else if (buttonType == ButtonType.BASIC_OUTLINE_ONLY_ICON)
					{
						basicOutlineOOBorder.color = UIManagerAsset.buttonBorderColor;
						basicOutlineOOFilled.color = UIManagerAsset.buttonFilledColor;
						basicOutlineOOIcon.color = UIManagerAsset.buttonBorderColor;
						basicOutlineOOIconHighlighted.color = UIManagerAsset.buttonFilledColor;
					}
					else if (buttonType == ButtonType.BASIC_OUTLINE_WITH_ICON)
					{
						basicOutlineWOBorder.color = UIManagerAsset.buttonBorderColor;
						basicOutlineWOFilled.color = UIManagerAsset.buttonFilledColor;
						basicOutlineWOIcon.color = UIManagerAsset.buttonIconColor;
						basicOutlineWOIconHighlighted.color = UIManagerAsset.buttonIconHighlightedColor;
						basicOutlineWOText.color = UIManagerAsset.buttonTextColor;
						basicOutlineWOTextHighligted.color = UIManagerAsset.buttonTextHighlightedColor;
						basicOutlineWOText.font = UIManagerAsset.buttonFont;
						basicOutlineWOTextHighligted.font = UIManagerAsset.buttonFont;
						basicOutlineWOText.fontSize = UIManagerAsset.buttonFontSize;
						basicOutlineWOTextHighligted.fontSize = UIManagerAsset.buttonFontSize;
					}
					else if (buttonType == ButtonType.RADIAL_ONLY_ICON)
					{
						radialOOBackground.color = UIManagerAsset.buttonFilledColor;
						radialOOIcon.color = UIManagerAsset.buttonIconBasicColor;
					}
					else if (buttonType == ButtonType.RADIAL_OUTLINE_ONLY_ICON)
					{
						radialOutlineOOBorder.color = UIManagerAsset.buttonBorderColor;
						radialOutlineOOFilled.color = UIManagerAsset.buttonFilledColor;
						radialOutlineOOIcon.color = UIManagerAsset.buttonIconColor;
						radialOutlineOOIconHighlighted.color = UIManagerAsset.buttonIconHighlightedColor;
					}
					else if (buttonType == ButtonType.ROUNDED)
					{
						roundedBackground.color = UIManagerAsset.buttonFilledColor;
						roundedText.color = UIManagerAsset.buttonTextBasicColor;
						roundedText.font = UIManagerAsset.buttonFont;
						roundedText.fontSize = UIManagerAsset.buttonFontSize;
					}
					else if (buttonType == ButtonType.ROUNDED_OUTLINE)
					{
						roundedOutlineBorder.color = UIManagerAsset.buttonBorderColor;
						roundedOutlineFilled.color = UIManagerAsset.buttonFilledColor;
						roundedOutlineText.color = UIManagerAsset.buttonTextColor;
						roundedOutlineTextHighligted.color = UIManagerAsset.buttonTextHighlightedColor;
						roundedOutlineText.font = UIManagerAsset.buttonFont;
						roundedOutlineTextHighligted.font = UIManagerAsset.buttonFont;
						roundedOutlineText.fontSize = UIManagerAsset.buttonFontSize;
						roundedOutlineTextHighligted.fontSize = UIManagerAsset.buttonFontSize;
					}
				}
			}
			catch
			{
			}
		}
	}
}
