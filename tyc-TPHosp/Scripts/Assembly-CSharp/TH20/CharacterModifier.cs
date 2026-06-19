using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace TH20
{
	public abstract class CharacterModifier
	{
		[SerializeField]
		private bool _showInTooltip = true;

		public virtual void Add(Character character)
		{
		}

		public virtual void Update(Character character)
		{
		}

		public virtual void Remove(Character character)
		{
		}

		public virtual string Description()
		{
			return string.Empty;
		}

		public void SetShowInTooltip(bool var)
		{
			_showInTooltip = var;
		}

		public static string GetTooltipText(string prefix, CharacterModifier[] modifiers, string delimiter = "\n")
		{
			List<string> list = new List<string>();
			foreach (CharacterModifier characterModifier in modifiers)
			{
				if (characterModifier._showInTooltip)
				{
					string text = characterModifier.Description();
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(text);
					}
				}
			}
			bool flag = true;
			StringBuilder stringBuilder = new StringBuilder();
			if (string.IsNullOrEmpty(prefix))
			{
				flag = false;
			}
			else
			{
				stringBuilder.Append(prefix);
			}
			for (int j = 0; j < list.Count; j++)
			{
				string value = list[j];
				if (flag)
				{
					flag = false;
					stringBuilder.Append(delimiter);
				}
				stringBuilder.Append(value);
				if (j < list.Count - 1)
				{
					stringBuilder.Append(delimiter);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
