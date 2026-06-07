using Client;
using Motorways.Themes;
using Motorways.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Motorways
{
	public class NewUpgradeButton : TouchButton, IThemeComponent
	{
		public UpgradeType primaryUpgradeType;

		public Image imageRenderer;

		public LocalizedTextUI buttonName;

		public LocalizedTextUI buttonAdditionalConcrete;

		public LocalizedTextUI buttonDescription;

		public UpgradeIcon[] icons;

		public NumberBubble[] numberBubbles;

		public RectTransform iconParent;

		public float disabledScale = 0.7f;

		public ThemedComponent[] nestedThemeComponents;

		private Theme _currentTheme;

		public UpgradeIcon PrimaryIcon => icons[0];

		public UpgradeIcon SecondaryIcon => icons[1];

		public NumberBubble PrimaryNumberBubble => numberBubbles[0];

		public NumberBubble SecondaryNumberBubble => numberBubbles[1];

		public Sprite Sprite
		{
			get
			{
				return imageRenderer.sprite;
			}
			set
			{
				imageRenderer.sprite = value;
			}
		}

		public RectTransform GetIconRect(int index)
		{
			return icons[index].GetComponent<RectTransform>();
		}

		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
			SetHighlighted(isHighlighted: true);
		}

		public override void OnDeselect(BaseEventData eventData)
		{
			base.OnDeselect(eventData);
			SetHighlighted(isHighlighted: false);
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			SetHighlighted(isHighlighted: true);
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			SetHighlighted(isHighlighted: false);
		}

		private void SetHighlighted(bool isHighlighted)
		{
			for (int i = 0; i < icons.Length; i++)
			{
				icons[i].IsHighlighted = isHighlighted;
			}
		}

		public void InitializeTheme(IThemeDatabase themeDatabase)
		{
		}

		public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			ThemeBlendingResult result = ThemeBlendingResult.StopBlending;
			_currentTheme = newTheme as Theme;
			for (int i = 0; i < icons.Length; i++)
			{
				if (icons[i].ApplyBlendedTheme(oldTheme, newTheme, progress) == ThemeBlendingResult.ContinueBlending)
				{
					result = ThemeBlendingResult.ContinueBlending;
				}
			}
			return result;
		}

		public void ApplyTheme(ITheme newTheme)
		{
			_currentTheme = newTheme as Theme;
			for (int i = 0; i < icons.Length; i++)
			{
				icons[i].ApplyTheme(newTheme);
			}
		}

		public void ReleaseTheme(IThemeDatabase themeDatabase)
		{
		}

		public void SetInteractable(bool isInteractable)
		{
			base.interactable = isInteractable;
			base.transform.localScale = Vector3.one;
			if (!base.interactable)
			{
				base.transform.localScale *= disabledScale;
			}
			UpgradeIcon[] array = icons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].IsDisabled = !isInteractable;
			}
			ThemedComponent[] array2 = nestedThemeComponents;
			foreach (ThemedComponent themedComponent in array2)
			{
				if (isInteractable)
				{
					themedComponent.ApplyTheme(_currentTheme);
				}
				else
				{
					themedComponent.SetColor(_currentTheme.GetColor(ThemedMaterialType.DisabledUpgradeOption));
				}
			}
		}
	}
}
