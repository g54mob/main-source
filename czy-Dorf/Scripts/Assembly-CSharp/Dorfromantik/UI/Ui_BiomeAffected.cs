using System;
using LeTai.Asset.TranslucentImage;
using UnityEngine;

namespace Dorfromantik.UI
{
	public class Ui_BiomeAffected : MonoBehaviour
	{
		[SerializeField]
		private TranslucentImage translucentImage;

		[SerializeField]
		private bool shouldAlwaysUseUiColorModifier;

		[SerializeField]
		private UiColorModifier uiColorModifier;

		[SerializeField]
		private bool useHighlightFontColor;

		[SerializeField]
		private Material textHighlightMaterial;

		[SerializeField]
		private bool overwriteSpriteBlending;

		[SerializeField]
		private float spriteBlendingValue;

		[SerializeField]
		private Color currentBackgroundColor;

		[SerializeField]
		private Color currentBackgroundColorDuplicate;

		[SerializeField]
		private Color currentModifiedBackgroundColor;

		[SerializeField]
		private Color currentModifiedBackgroundColorDuplicate;

		[SerializeField]
		private Color currentHighlightColor;

		private ChangeUIBasedOnFocus uiChanger;

		private string backgroundColorKey = "background";

		private string textHighlightColorKey = "textHighlight";

		private void Awake()
		{
			AssignTranslucentImageReference();
			if ((bool)OverwritingSingleton<IngameUi>.Instance)
			{
				ChangeScene(OverwritingSingleton<IngameUi>.Instance);
			}
			IngameUi.OnSceneChanged += ChangeScene;
		}

		private void OnEnable()
		{
			ChangeUIBasedOnFocus.OnFocusBiomeChanged += ApplyBiomeAffectedModifiers;
			ChangeUIBasedOnFocus.ApplyBiomeTo(this);
		}

		private void OnDisable()
		{
			ChangeUIBasedOnFocus.OnFocusBiomeChanged -= ApplyBiomeAffectedModifiers;
		}

		private void OnDestroy()
		{
			IngameUi.OnSceneChanged -= ChangeScene;
		}

		private void OnValidate()
		{
			AssignTranslucentImageReference();
			if (!shouldAlwaysUseUiColorModifier)
			{
				uiColorModifier = UiColorModifier.None;
			}
		}

		private void AssignTranslucentImageReference()
		{
			if (translucentImage == null)
			{
				translucentImage = GetComponent<TranslucentImage>();
			}
		}

		private void ChangeScene(IngameUi newIngameUi)
		{
			if (translucentImage == null)
			{
				Debug.LogError(base.name + " has no translucent image", this);
			}
			translucentImage.source = newIngameUi.translucentImageSource;
		}

		public void ApplyNewColorModifier(UiColorModifier uiColorModifier)
		{
			this.uiColorModifier = uiColorModifier;
			ApplyBiomeAffectedModifiers();
		}

		public void ApplyBiomeAffectedModifiers(BiomeObjectConfiguration targetConfiguration = null)
		{
			if (targetConfiguration != null)
			{
				currentBackgroundColor = targetConfiguration.GetEffectValue<Color>(backgroundColorKey);
				currentHighlightColor = targetConfiguration.GetEffectValue<Color>(textHighlightColorKey);
			}
			if (translucentImage == null)
			{
				AssignTranslucentImageReference();
			}
			currentModifiedBackgroundColor = ApplyColorModifier(currentBackgroundColor, uiColorModifier, translucentImage.color.a);
			translucentImage.color = currentModifiedBackgroundColor;
			currentBackgroundColorDuplicate = currentBackgroundColor;
			currentModifiedBackgroundColorDuplicate = currentModifiedBackgroundColor;
			if (overwriteSpriteBlending)
			{
				translucentImage.spriteBlending = spriteBlendingValue;
			}
			if (useHighlightFontColor)
			{
				textHighlightMaterial.color = currentHighlightColor;
			}
		}

		internal Color ApplyColorModifier(Color color, UiColorModifier modifier, float alpha = 1f)
		{
			switch (modifier)
			{
			case UiColorModifier.None:
			case UiColorModifier.Reset:
				color = currentBackgroundColor;
				break;
			case UiColorModifier.Darker:
				color -= Constants.UI.ColorModifier.Black75Percent;
				break;
			case UiColorModifier.LightDarker:
				color -= Constants.UI.ColorModifier.Black95Percent;
				break;
			case UiColorModifier.Lighter:
				color += Constants.UI.ColorModifier.Black75Percent;
				break;
			default:
				throw new ArgumentOutOfRangeException("modifier", modifier, null);
			}
			color.a = alpha;
			return color;
		}
	}
}
