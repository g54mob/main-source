using System;
using TMPro;
using UnityEngine;

namespace Dorfromantik.UI.Components
{
	public class UiInputFieldBiomeAffected : MonoBehaviour
	{
		[SerializeField]
		private bool shouldAlwaysUseUiColorModifier;

		[SerializeField]
		private UiColorModifier uiColorModifier;

		[SerializeField]
		private TMP_InputField inputField;

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

		private string backgroundColorKey = "background";

		private string textHighlightColorKey = "textHighlight";

		private void Awake()
		{
			if ((object)inputField == null)
			{
				inputField = GetComponent<TMP_InputField>();
			}
			ChangeUIBasedOnFocus.OnFocusBiomeChanged += ApplyBiomeAffectedModifiers;
			ChangeUIBasedOnFocus.ApplyBiomeTo(this);
		}

		private void OnDestroy()
		{
			ChangeUIBasedOnFocus.OnFocusBiomeChanged -= ApplyBiomeAffectedModifiers;
		}

		internal void ApplyBiomeAffectedModifiers(BiomeObjectConfiguration targetConfiguration = null)
		{
			if (targetConfiguration != null)
			{
				currentBackgroundColor = targetConfiguration.GetEffectValue<Color>(backgroundColorKey);
				currentHighlightColor = targetConfiguration.GetEffectValue<Color>(textHighlightColorKey);
			}
			currentModifiedBackgroundColor = ApplyColorModifier(currentBackgroundColor, uiColorModifier, inputField.selectionColor.a);
			inputField.selectionColor = currentModifiedBackgroundColor;
			currentBackgroundColorDuplicate = currentBackgroundColor;
			currentModifiedBackgroundColorDuplicate = currentModifiedBackgroundColor;
		}

		private Color ApplyColorModifier(Color color, UiColorModifier modifier, float alpha = 1f)
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
