using FullInspector;
using TMPro;
using UnityEngine;

namespace TH20.UI
{
	[fiInspectorOnly]
	public class PanelItem : MonoBehaviour
	{
		[SerializeField]
		private LocalisedString TitleString;

		private TMP_Text _cachedTitleText;

		private bool _bHasBeenSetup;

		public bool HasBeenSetup => _bHasBeenSetup;

		public virtual void Setup()
		{
			SetTitleText(TitleString.Translation);
			_bHasBeenSetup = true;
		}

		public string GetTitleText()
		{
			return TitleString.Translation;
		}

		public void UpdateLocalisedTitleTextForValueCount(int valueCount)
		{
			SetTitleText(TitleString.TranslationPlural(valueCount));
		}

		public void SetTitleText(string theText)
		{
			if (_cachedTitleText == null)
			{
				TMP_Text[] componentsInChildren = GetComponentsInChildren<TMP_Text>(includeInactive: true);
				foreach (TMP_Text tMP_Text in componentsInChildren)
				{
					if (tMP_Text.name == "Title")
					{
						_cachedTitleText = tMP_Text;
						break;
					}
				}
			}
			if (_cachedTitleText != null)
			{
				_cachedTitleText.text = theText;
			}
		}

		public virtual void UpdateStat(LevelStatsDatabase levelStatsDatabase)
		{
		}
	}
}
