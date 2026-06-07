using System;
using System.Collections.Generic;
using I2.Loc;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	[Serializable]
	[InlineProperty]
	public struct TranslationTerm
	{
		[HideLabel]
		[ValueDropdown("GetTerms")]
		[PropertySpace(8f)]
		public string Term;

		private readonly string _customValue;

		public TranslationTerm(string customValue)
		{
			Term = "";
			_customValue = customValue;
		}

		public string GetTranslation()
		{
			if (!string.IsNullOrEmpty(_customValue))
			{
				return _customValue;
			}
			if (!string.IsNullOrEmpty(Term) && Term != "No Text")
			{
				return LocalizationManager.GetTermTranslation(Term);
			}
			return "";
		}

		public List<string> GetTerms()
		{
			List<string> termsList = LocalizationManager.GetTermsList();
			termsList.Add("No Text");
			return termsList;
		}

		public override string ToString()
		{
			return GetTranslation();
		}
	}
}
