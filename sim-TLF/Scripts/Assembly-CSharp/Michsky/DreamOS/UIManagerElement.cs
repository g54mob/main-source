using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[AddComponentMenu("DreamOS/UI Manager/UI Manager Element")]
	public class UIManagerElement : MonoBehaviour
	{
		public enum ObjectType
		{
			Text = 0,
			Image = 1
		}

		public enum ColorType
		{
			WindowBackground = 0,
			Background = 1,
			Primary = 2,
			Secondary = 3,
			Accent = 4,
			AccentReversed = 5,
			Taskbar = 6
		}

		public enum FontType
		{
			Thin = 0,
			Light = 1,
			Regular = 2,
			Semibold = 3,
			Bold = 4
		}

		public UIManager themeManagerAsset;

		public ObjectType objectType;

		public ColorType colorType = ColorType.Primary;

		public FontType fontType = FontType.Regular;

		public bool keepAlphaValue;

		public bool useCustomFont;

		public bool useCustomColor;

		private Image imageObject;

		private TextMeshProUGUI textObject;

		private void Awake()
		{
			base.enabled = true;
			if (themeManagerAsset == null)
			{
				themeManagerAsset = Resources.Load<UIManager>("UI Manager/DreamOS UI Manager");
			}
			if (objectType == ObjectType.Image && imageObject == null)
			{
				imageObject = base.gameObject.GetComponent<Image>();
			}
			else if (objectType == ObjectType.Text && textObject == null)
			{
				textObject = base.gameObject.GetComponent<TextMeshProUGUI>();
			}
			if (!themeManagerAsset.enableDynamicUpdate)
			{
				UpdateElement();
				base.enabled = false;
			}
		}

		private void Update()
		{
			if (!(themeManagerAsset == null) && themeManagerAsset.enableDynamicUpdate)
			{
				UpdateElement();
			}
		}

		public void UpdateElement()
		{
			if (objectType == ObjectType.Image && imageObject != null)
			{
				if (!keepAlphaValue)
				{
					if (colorType == ColorType.Primary)
					{
						imageObject.color = themeManagerAsset.primaryColorDark;
					}
					else if (colorType == ColorType.Secondary)
					{
						imageObject.color = themeManagerAsset.secondaryColorDark;
					}
					else if (colorType == ColorType.WindowBackground)
					{
						imageObject.color = themeManagerAsset.windowBGColorDark;
					}
					else if (colorType == ColorType.Background)
					{
						imageObject.color = themeManagerAsset.backgroundColorDark;
					}
					else if (colorType == ColorType.Taskbar)
					{
						imageObject.color = themeManagerAsset.taskBarColorDark;
					}
					if (themeManagerAsset.selectedTheme == UIManager.SelectedTheme.Default)
					{
						if (colorType == ColorType.Accent)
						{
							imageObject.color = themeManagerAsset.highlightedColorDark;
						}
						else if (colorType == ColorType.AccentReversed)
						{
							imageObject.color = themeManagerAsset.highlightedColorSecondaryDark;
						}
					}
					else if (themeManagerAsset.selectedTheme == UIManager.SelectedTheme.Custom)
					{
						if (colorType == ColorType.Accent)
						{
							imageObject.color = themeManagerAsset.highlightedColorCustom;
						}
						else if (colorType == ColorType.AccentReversed)
						{
							imageObject.color = themeManagerAsset.highlightedColorSecondaryCustom;
						}
					}
					return;
				}
				if (colorType == ColorType.WindowBackground)
				{
					imageObject.color = new Color(themeManagerAsset.windowBGColorDark.r, themeManagerAsset.windowBGColorDark.g, themeManagerAsset.windowBGColorDark.b, imageObject.color.a);
				}
				else if (colorType == ColorType.Background)
				{
					imageObject.color = new Color(themeManagerAsset.backgroundColorDark.r, themeManagerAsset.backgroundColorDark.g, themeManagerAsset.backgroundColorDark.b, imageObject.color.a);
				}
				else if (colorType == ColorType.Primary)
				{
					imageObject.color = new Color(themeManagerAsset.primaryColorDark.r, themeManagerAsset.primaryColorDark.g, themeManagerAsset.primaryColorDark.b, imageObject.color.a);
				}
				else if (colorType == ColorType.Secondary)
				{
					imageObject.color = new Color(themeManagerAsset.secondaryColorDark.r, themeManagerAsset.secondaryColorDark.g, themeManagerAsset.secondaryColorDark.b, imageObject.color.a);
				}
				if (themeManagerAsset.selectedTheme == UIManager.SelectedTheme.Default)
				{
					if (colorType == ColorType.Accent)
					{
						imageObject.color = new Color(themeManagerAsset.highlightedColorDark.r, themeManagerAsset.highlightedColorDark.g, themeManagerAsset.highlightedColorDark.b, imageObject.color.a);
					}
					else if (colorType == ColorType.AccentReversed)
					{
						imageObject.color = new Color(themeManagerAsset.highlightedColorSecondaryDark.r, themeManagerAsset.highlightedColorSecondaryDark.g, themeManagerAsset.highlightedColorSecondaryDark.b, imageObject.color.a);
					}
				}
				else if (themeManagerAsset.selectedTheme == UIManager.SelectedTheme.Custom)
				{
					if (colorType == ColorType.Accent)
					{
						imageObject.color = new Color(themeManagerAsset.highlightedColorCustom.r, themeManagerAsset.highlightedColorCustom.g, themeManagerAsset.highlightedColorCustom.b, imageObject.color.a);
					}
					else if (colorType == ColorType.AccentReversed)
					{
						imageObject.color = new Color(themeManagerAsset.highlightedColorSecondaryCustom.r, themeManagerAsset.highlightedColorSecondaryCustom.g, themeManagerAsset.highlightedColorSecondaryCustom.b, imageObject.color.a);
					}
				}
			}
			else
			{
				if (objectType != ObjectType.Text || !(textObject != null))
				{
					return;
				}
				if (!useCustomColor)
				{
					if (!keepAlphaValue)
					{
						if (colorType == ColorType.WindowBackground)
						{
							textObject.color = themeManagerAsset.windowBGColorDark;
						}
						else if (colorType == ColorType.Background)
						{
							textObject.color = themeManagerAsset.backgroundColorDark;
						}
						else if (colorType == ColorType.Primary)
						{
							textObject.color = themeManagerAsset.primaryColorDark;
						}
						else if (colorType == ColorType.Secondary)
						{
							textObject.color = themeManagerAsset.secondaryColorDark;
						}
						if (themeManagerAsset.selectedTheme == UIManager.SelectedTheme.Default)
						{
							if (colorType == ColorType.Accent)
							{
								textObject.color = themeManagerAsset.highlightedColorDark;
							}
							else if (colorType == ColorType.AccentReversed)
							{
								textObject.color = themeManagerAsset.highlightedColorSecondaryDark;
							}
						}
						else if (themeManagerAsset.selectedTheme == UIManager.SelectedTheme.Custom)
						{
							if (colorType == ColorType.Accent)
							{
								textObject.color = themeManagerAsset.highlightedColorCustom;
							}
							else if (colorType == ColorType.AccentReversed)
							{
								textObject.color = themeManagerAsset.highlightedColorSecondaryCustom;
							}
						}
					}
					else
					{
						if (colorType == ColorType.WindowBackground)
						{
							textObject.color = new Color(themeManagerAsset.windowBGColorDark.r, themeManagerAsset.windowBGColorDark.g, themeManagerAsset.windowBGColorDark.b, textObject.color.a);
						}
						else if (colorType == ColorType.Background)
						{
							textObject.color = new Color(themeManagerAsset.backgroundColorDark.r, themeManagerAsset.backgroundColorDark.g, themeManagerAsset.backgroundColorDark.b, textObject.color.a);
						}
						else if (colorType == ColorType.Primary)
						{
							textObject.color = new Color(themeManagerAsset.primaryColorDark.r, themeManagerAsset.primaryColorDark.g, themeManagerAsset.primaryColorDark.b, textObject.color.a);
						}
						else if (colorType == ColorType.Secondary)
						{
							textObject.color = new Color(themeManagerAsset.secondaryColorDark.r, themeManagerAsset.secondaryColorDark.g, themeManagerAsset.secondaryColorDark.b, textObject.color.a);
						}
						if (themeManagerAsset.selectedTheme == UIManager.SelectedTheme.Default)
						{
							if (colorType == ColorType.Accent)
							{
								textObject.color = new Color(themeManagerAsset.highlightedColorDark.r, themeManagerAsset.highlightedColorDark.g, themeManagerAsset.highlightedColorDark.b, textObject.color.a);
							}
							else if (colorType == ColorType.AccentReversed)
							{
								textObject.color = new Color(themeManagerAsset.highlightedColorSecondaryDark.r, themeManagerAsset.highlightedColorSecondaryDark.g, themeManagerAsset.highlightedColorSecondaryDark.b, textObject.color.a);
							}
						}
						else if (themeManagerAsset.selectedTheme == UIManager.SelectedTheme.Custom)
						{
							if (colorType == ColorType.Accent)
							{
								textObject.color = new Color(themeManagerAsset.highlightedColorCustom.r, themeManagerAsset.highlightedColorCustom.g, themeManagerAsset.highlightedColorCustom.b, textObject.color.a);
							}
							else if (colorType == ColorType.AccentReversed)
							{
								textObject.color = new Color(themeManagerAsset.highlightedColorSecondaryCustom.r, themeManagerAsset.highlightedColorSecondaryCustom.g, themeManagerAsset.highlightedColorSecondaryCustom.b, textObject.color.a);
							}
						}
					}
				}
				if (!useCustomFont)
				{
					if (fontType == FontType.Thin)
					{
						textObject.font = themeManagerAsset.systemFontThin;
					}
					else if (fontType == FontType.Light)
					{
						textObject.font = themeManagerAsset.systemFontLight;
					}
					else if (fontType == FontType.Regular)
					{
						textObject.font = themeManagerAsset.systemFontRegular;
					}
					else if (fontType == FontType.Semibold)
					{
						textObject.font = themeManagerAsset.systemFontSemiBold;
					}
					else if (fontType == FontType.Bold)
					{
						textObject.font = themeManagerAsset.systemFontBold;
					}
				}
			}
		}
	}
}
