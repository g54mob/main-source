using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSMedieval;
using NSMedieval.GameEventSystem;

namespace ChatGraphSystem
{
	[Serializable]
	public class ChoiceNode : BaseNode
	{
		public string Text = "";

		public string EffectIds = "";

		public string DestinationDialogId
		{
			get
			{
				return NextNodeIds[0];
			}
			set
			{
				NextNodeIds[0] = value;
			}
		}

		public ChoiceNode()
			: base(NodeType.Choice)
		{
			NextNodeIds = new List<string>();
			NextNodeIds.Add(null);
		}

		public string Validate()
		{
			if (EffectIds.Trim().Length == 0)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (Text.Trim().Length == 0)
			{
				stringBuilder.Append("Invalid choice text (can't be empty)");
			}
			if (!TryParseOptionEffects(out var _))
			{
				stringBuilder.Append("One or more invalid choice option effect IDs (choice text = '" + Text + "')\n");
			}
			if (stringBuilder.Length != 0)
			{
				return stringBuilder.ToString();
			}
			return null;
		}

		public bool TryParseOptionEffects(out List<GameEventOptionEffect> result)
		{
			result = new List<GameEventOptionEffect>();
			IEnumerable<string> enumerable = from t in EffectIds.Split(",")
				select t.Trim();
			GameEventOptionEffect[] gameEventOptionEffects = EnumValues.GameEventOptionEffects;
			foreach (string item in enumerable)
			{
				if (!int.TryParse(item, out var result2))
				{
					return false;
				}
				GameEventOptionEffect gameEventOptionEffect = (GameEventOptionEffect)result2;
				if (!gameEventOptionEffects.Contains(gameEventOptionEffect))
				{
					return false;
				}
				result.Add(gameEventOptionEffect);
			}
			return true;
		}
	}
}
