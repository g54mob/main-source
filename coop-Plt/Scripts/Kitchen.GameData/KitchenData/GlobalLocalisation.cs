using System.Collections.Generic;
using Platforms;
using TMPro;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Global Localisation", menuName = "Kitchen/Localisation/Global")]
	public class GlobalLocalisation : DictionaryLocalisation
	{
		public Dictionary<DisplayedPatienceFactor, string> PatienceFactorIcons;

		public Dictionary<PatienceReason, string> PatienceReasonIcons;

		public Dictionary<DecorationType, string> DecorationIcons;

		[SerializeField]
		public NewsItemFallbackLocalisation NewsItemFallbackLocalisation;

		[SerializeField]
		public StartDayWarningLocalisation StartDayWarningLocalisation;

		[SerializeField]
		public PopupTextLocalisation PopupTextLocalisation;

		[SerializeField]
		public RecipeLocalisation Recipes;

		[SerializeField]
		public Dictionary<Font, TMP_FontAsset> Fonts;

		[SerializeField]
		public ControllerIcons ControllerIcons;

		public override string this[string i]
		{
			get
			{
				if (Text.TryGetValue(i, out var value))
				{
					return value;
				}
				Debug.LogWarning("No localisation for " + i);
				return i;
			}
		}

		public string this[int id] => Recipes[id];

		public PopupDetails this[PopupType popup_type] => PopupTextLocalisation[popup_type];

		public PopupDetails this[PopupType popup_type, float f] => PopupTextLocalisation[popup_type, f];

		public string GetIcon(DisplayedPatienceFactor f)
		{
			if (PatienceFactorIcons.TryGetValue(f, out var value))
			{
				return value;
			}
			return "?";
		}

		public string GetIcon(PatienceReason f)
		{
			if (PatienceReasonIcons.TryGetValue(f, out var value))
			{
				return value;
			}
			return "?";
		}

		public string GetIcon(DecorationType f)
		{
			if (DecorationIcons.TryGetValue(f, out var value))
			{
				return value;
			}
			return "?";
		}

		protected override void InitialiseDefaults()
		{
		}

		public string NewLocalisationNeeded(string i)
		{
			if (Text.TryGetValue(i, out var _))
			{
				Debug.LogError("New localisation no longer needed for " + i);
			}
			return i;
		}

		public string GetPlatformPrompt(string i)
		{
			string text = PlatformSettings.CurrentPlatformType.ToString().ToUpper();
			if (Text.TryGetValue(i + "_" + text, out var value))
			{
				return value;
			}
			return this[i];
		}
	}
}
