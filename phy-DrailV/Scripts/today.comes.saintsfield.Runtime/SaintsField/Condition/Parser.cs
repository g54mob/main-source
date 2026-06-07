using System;
using System.Collections.Generic;
using System.Reflection;

namespace SaintsField.Condition
{
	public static class Parser
	{
		public static IEnumerable<ConditionInfo> Parse(IReadOnlyList<object> rawConditions)
		{
			int totalLength = rawConditions.Count;
			bool skipNext = false;
			for (int index = 0; index < totalLength; index++)
			{
				if (skipNext)
				{
					skipNext = false;
					continue;
				}
				object obj = rawConditions[index];
				if (obj is EMode eMode)
				{
					yield return new ConditionInfo
					{
						Target = eMode,
						Compare = LogicCompare.EditorMode,
						Value = null,
						ValueIsCallback = false,
						Reverse = false
					};
					continue;
				}
				if (!(obj is string text))
				{
					yield return new ConditionInfo
					{
						Target = obj,
						Compare = LogicCompare.Truly,
						Value = null,
						ValueIsCallback = false,
						Reverse = false
					};
					continue;
				}
				bool reverse = false;
				object value = null;
				if (text.StartsWith("!"))
				{
					reverse = true;
					text = text.Substring(1);
				}
				else if (text.StartsWith("$"))
				{
					text = text.Substring(1);
				}
				LogicCompare compare = LogicCompare.Truly;
				bool valueIsCallback = false;
				object obj2;
				if (text.EndsWith("&"))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 1);
					compare = LogicCompare.BitAnd;
					value = rawConditions[index + 1];
				}
				else if (text.EndsWith("&$"))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 2);
					compare = LogicCompare.BitAnd;
					value = rawConditions[index + 1];
					valueIsCallback = true;
				}
				else if (text.EndsWith("^"))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 1);
					compare = LogicCompare.BitXor;
					value = rawConditions[index + 1];
				}
				else if (text.EndsWith("^$"))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 2);
					compare = LogicCompare.BitXor;
					value = rawConditions[index + 1];
					valueIsCallback = true;
				}
				else if (text.EndsWith("&=="))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 3);
					compare = LogicCompare.BitHasFlag;
					value = rawConditions[index + 1];
				}
				else if (text.EndsWith("&==$"))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 4);
					compare = LogicCompare.BitHasFlag;
					value = rawConditions[index + 1];
					valueIsCallback = true;
				}
				else if (text.EndsWith("=="))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 2);
					compare = LogicCompare.Equal;
					value = rawConditions[index + 1];
				}
				else if (text.EndsWith("==$"))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 3);
					compare = LogicCompare.Equal;
					value = rawConditions[index + 1];
					valueIsCallback = true;
				}
				else if (text.EndsWith("!="))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 2);
					compare = LogicCompare.NotEqual;
					value = rawConditions[index + 1];
				}
				else if (text.EndsWith("!=$"))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 3);
					compare = LogicCompare.NotEqual;
					value = rawConditions[index + 1];
					valueIsCallback = true;
				}
				else if (text.EndsWith(">"))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 1);
					compare = LogicCompare.GreaterThan;
					value = rawConditions[index + 1];
				}
				else if (text.EndsWith(">$"))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 2);
					compare = LogicCompare.GreaterThan;
					value = rawConditions[index + 1];
					valueIsCallback = true;
				}
				else if (text.EndsWith(">="))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 2);
					compare = LogicCompare.GreaterEqual;
					value = rawConditions[index + 1];
				}
				else if (text.EndsWith(">=$"))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 3);
					compare = LogicCompare.GreaterEqual;
					value = rawConditions[index + 1];
					valueIsCallback = true;
				}
				else if (text.EndsWith("<"))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 1);
					compare = LogicCompare.LessThan;
					value = rawConditions[index + 1];
				}
				else if (text.EndsWith("<$"))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 2);
					compare = LogicCompare.LessThan;
					value = rawConditions[index + 1];
					valueIsCallback = true;
				}
				else if (text.EndsWith("<="))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 2);
					compare = LogicCompare.LessEqual;
					value = rawConditions[index + 1];
				}
				else if (text.EndsWith("<=$"))
				{
					skipNext = true;
					text = text.Substring(0, text.Length - 3);
					compare = LogicCompare.LessEqual;
					value = rawConditions[index + 1];
					valueIsCallback = true;
				}
				else if (index + 1 < totalLength)
				{
					obj2 = rawConditions[index + 1];
					object obj3 = obj2;
					if (obj3 == null)
					{
						goto IL_067c;
					}
					if (!(obj3 is string))
					{
						if (!(obj3 is Enum obj4))
						{
							goto IL_067c;
						}
						skipNext = true;
						compare = ((obj4.GetType().GetCustomAttribute<FlagsAttribute>() != null) ? LogicCompare.BitHasFlag : LogicCompare.Equal);
						value = obj4;
					}
				}
				goto IL_068a;
				IL_067c:
				skipNext = true;
				value = obj2;
				compare = LogicCompare.Equal;
				goto IL_068a;
				IL_068a:
				yield return new ConditionInfo
				{
					Target = text,
					Compare = compare,
					Value = value,
					ValueIsCallback = valueIsCallback,
					Reverse = reverse
				};
			}
		}
	}
}
