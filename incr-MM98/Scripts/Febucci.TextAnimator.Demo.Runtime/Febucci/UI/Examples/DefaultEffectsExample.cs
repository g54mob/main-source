using System.Collections.Generic;
using System.Text;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.Settings;
using Febucci.TextAnimatorForUnity;
using UnityEngine;

namespace Febucci.UI.Examples
{
	[AddComponentMenu("")]
	public class DefaultEffectsExample : MonoBehaviour
	{
		public TypewriterComponent typewriter;

		private TextAnimatorSettings settings;

		private void Awake()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("Here are the currently recognized (global) effects: \n\n");
			GlobalSettingsBase globalSettingsBase = TextAnimatorSettings.Instance.Settings;
			foreach (KeyValuePair<string, IEffect> item in globalSettingsBase.GlobalEffectsDatabase.Database)
			{
				string key = item.Key;
				OpenTag(globalSettingsBase.parsingAppearances, key);
				OpenTag(globalSettingsBase.parsingBehaviors, key);
				OpenTag(globalSettingsBase.parsingDisappearances, key);
				builder.Append(key);
				CloseTag(globalSettingsBase.parsingAppearances, key);
				CloseTag(globalSettingsBase.parsingBehaviors, key);
				CloseTag(globalSettingsBase.parsingDisappearances, key);
				builder.Append(' ');
			}
			builder.Append("\n\nHave fun customizing them or create yours both from the inspector or c#!");
			typewriter.ShowText(builder.ToString());
			typewriter.StartShowingText();
			void CloseTag(ParsingInfo parsing, string tagId)
			{
				builder.Append(parsing.openingBracket);
				builder.Append('/');
				if (!char.IsWhiteSpace(parsing.middleSymbol) && parsing.middleSymbol != '\n' && parsing.middleSymbol != 0)
				{
					builder.Append(parsing.middleSymbol);
				}
				builder.Append(tagId);
				builder.Append(parsing.closingBracket);
			}
			void OpenTag(ParsingInfo parsing, string tagId)
			{
				builder.Append(parsing.openingBracket);
				if (!char.IsWhiteSpace(parsing.middleSymbol) && parsing.middleSymbol != '\n' && parsing.middleSymbol != 0)
				{
					builder.Append(parsing.middleSymbol);
				}
				builder.Append(tagId);
				builder.Append(parsing.closingBracket);
			}
		}
	}
}
