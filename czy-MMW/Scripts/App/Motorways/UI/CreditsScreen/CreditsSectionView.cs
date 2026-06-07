using System;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.UI.CreditsScreen
{
	public class CreditsSectionView : MonoBehaviour
	{
		[SerializeField]
		private CreditsSectionStyle _style;

		[ShowIf("ShouldShowHeader")]
		[SerializeField]
		private TextMeshProUGUI _header;

		[ShowIf("ShouldShowContent")]
		[SerializeField]
		private TextMeshProUGUI _content;

		[ShowIf("ShouldShowColumns")]
		[SerializeField]
		private TextMeshProUGUI _contentLeftColumn;

		[ShowIf("ShouldShowColumns")]
		[SerializeField]
		private TextMeshProUGUI _contentRightColumn;

		[ShowIf("ShouldShowLogo")]
		[SerializeField]
		private Image LogoImage;

		public CreditsSectionStyle Style => _style;

		public void SetHeaderText(string text, string localizationId)
		{
			_header.text = text;
			if (string.IsNullOrEmpty(localizationId))
			{
				localizationId = "None";
			}
			_header.GetComponent<LocalizedTextUI>().startingStringIdString = localizationId;
		}

		public void SetContentText(string text, bool alphabetize)
		{
			string[] array = text.Split('\n');
			if (alphabetize)
			{
				Array.Sort(array);
			}
			if (UseColumns())
			{
				(string[], string[]) tuple = SeparateEvenly(array);
				_contentLeftColumn.text = string.Join("\n", tuple.Item1);
				_contentRightColumn.text = string.Join("\n", tuple.Item2);
			}
			else
			{
				_content.text = string.Join("\n", array);
			}
		}

		public void SetLogoSprite(Sprite logoSprite)
		{
			if (LogoImage != null)
			{
				LogoImage.sprite = logoSprite;
			}
			else
			{
				GetComponentInChildren<Image>().sprite = logoSprite;
			}
		}

		private bool UseColumns()
		{
			if (_content != null)
			{
				return false;
			}
			if (_contentLeftColumn != null && _contentRightColumn != null)
			{
				return true;
			}
			Diagnostics.FailAssert("Credits Section View is set up incorrectly! Either the Content, (exclusive) or both of the ContentColumns should be assigned.");
			return false;
		}

		private (string[], string[]) SeparateEvenly(string[] strings)
		{
			int num = strings.Length;
			int num2 = ((num % 2 == 0) ? (num / 2) : (num / 2 + 1));
			int num3 = num / 2;
			string[] array = new string[num2];
			string[] array2 = new string[num3];
			bool flag = true;
			for (int i = 0; i < num; i++)
			{
				(flag ? array : array2)[i / 2] = strings[i];
				flag = !flag;
			}
			return (array, array2);
		}

		private bool ShouldShowHeader()
		{
			if (Style != CreditsSectionStyle.License && Style != CreditsSectionStyle.JumboHeader && Style != CreditsSectionStyle.SmallHeader && Style != CreditsSectionStyle.StandardCredits)
			{
				return Style == CreditsSectionStyle.TwoColumnCredits;
			}
			return true;
		}

		private bool ShouldShowContent()
		{
			if (Style != CreditsSectionStyle.License)
			{
				return Style == CreditsSectionStyle.StandardCredits;
			}
			return true;
		}

		private bool ShouldShowColumns()
		{
			return Style == CreditsSectionStyle.TwoColumnCredits;
		}

		private bool ShouldShowLogo()
		{
			return Style == CreditsSectionStyle.Logo;
		}
	}
}
