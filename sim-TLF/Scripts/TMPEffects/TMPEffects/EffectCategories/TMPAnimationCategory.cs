using System;
using System.Collections.Generic;
using TMPEffects.Databases;
using TMPEffects.TMPAnimations;
using TMPEffects.Tags;
using TMPEffects.TextProcessing;

namespace TMPEffects.EffectCategories
{
	internal class TMPAnimationCategory : TMPEffectCategory<ITMPAnimation>
	{
		private ITMPEffectDatabase<ITMPAnimation> database;

		private ITMPKeywordDatabase keywordDatabase;

		public TMPAnimationCategory(char prefix, ITMPEffectDatabase<ITMPAnimation> database, ITMPKeywordDatabase keywordDatabase)
			: base(prefix)
		{
			this.database = database;
			this.keywordDatabase = keywordDatabase;
		}

		public override bool ContainsEffect(string name)
		{
			return database.ContainsEffect(name);
		}

		public override ITMPAnimation GetEffect(string name)
		{
			return database.GetEffect(name);
		}

		public override bool ValidateOpenTag(ParsingUtility.TagInfo tagInfo, out TMPEffectTag data, out int endIndex)
		{
			data = null;
			endIndex = -1;
			if (tagInfo.type != ParsingUtility.TagType.Open)
			{
				throw new ArgumentException("type");
			}
			if (tagInfo.prefix != base.Prefix)
			{
				return false;
			}
			if (database == null || !database.ContainsEffect(tagInfo.name))
			{
				return false;
			}
			Dictionary<string, string> tagParametersDict = ParsingUtility.GetTagParametersDict(tagInfo.parameterString);
			if (!database.GetEffect(tagInfo.name).ValidateParameters(tagParametersDict, keywordDatabase))
			{
				return false;
			}
			TMPEffectTag tMPEffectTag = new TMPEffectTag(tagInfo.name, tagInfo.prefix, tagParametersDict);
			data = tMPEffectTag;
			return true;
		}

		public override bool ValidateTag(TMPEffectTag tag)
		{
			if (tag.Prefix != base.Prefix)
			{
				return false;
			}
			if (database == null || !database.ContainsEffect(tag.Name))
			{
				return false;
			}
			if (!database.GetEffect(tag.Name).ValidateParameters(tag.Parameters, keywordDatabase))
			{
				return false;
			}
			return true;
		}

		public override bool ValidateTag(ParsingUtility.TagInfo tagInfo)
		{
			if (tagInfo.prefix != base.Prefix)
			{
				return false;
			}
			if (database == null || !database.ContainsEffect(tagInfo.name))
			{
				return false;
			}
			if (tagInfo.type == ParsingUtility.TagType.Open)
			{
				Dictionary<string, string> tagParametersDict = ParsingUtility.GetTagParametersDict(tagInfo.parameterString);
				if (!database.GetEffect(tagInfo.name).ValidateParameters(tagParametersDict, keywordDatabase))
				{
					return false;
				}
			}
			return true;
		}
	}
}
