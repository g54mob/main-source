using System;
using System.Text;
using Febucci.UI.Effects;
using UnityEngine;

namespace Febucci.UI.Core.Parsing
{
	public class AnimationRegion : RegionBase
	{
		private readonly VisibilityMode visibilityMode;

		public readonly AnimationScriptableBase animation;

		public AnimationRegion(string tagId, VisibilityMode visibilityMode, AnimationScriptableBase animation)
			: base(tagId)
		{
			this.visibilityMode = visibilityMode;
			this.animation = animation;
		}

		public bool IsVisibilityPolicySatisfied(bool visible)
		{
			if (visibilityMode != VisibilityMode.Persistent)
			{
				return visibilityMode.HasFlag(VisibilityMode.OnVisible) == visible;
			}
			return true;
		}

		public void OpenNewRange(int startIndex)
		{
			OpenNewRange(startIndex, Array.Empty<string>());
		}

		public void OpenNewRange(int startIndex, string[] tagWords)
		{
			Array.Resize(ref ranges, ranges.Length + 1);
			TagRange tagRange = new TagRange(new Vector2Int(startIndex, int.MaxValue));
			for (int i = 1; i < tagWords.Length; i++)
			{
				string text = tagWords[i];
				int num = text.IndexOf('=');
				if (num > 0 && FormatUtils.TryGetFloat(text.Substring(num + 1), 0f, out var result))
				{
					Array.Resize(ref tagRange.modifiers, tagRange.modifiers.Length + 1);
					tagRange.modifiers[tagRange.modifiers.Length - 1] = new ModifierInfo(text.Substring(0, num), result);
				}
			}
			ranges[ranges.Length - 1] = tagRange;
		}

		public void TryClosingRange(int endIndex)
		{
			if (ranges.Length == 0)
			{
				return;
			}
			for (int num = ranges.Length - 1; num >= 0; num--)
			{
				if (ranges[num].indexes.y == int.MaxValue)
				{
					TagRange tagRange = ranges[num];
					tagRange.indexes.y = endIndex;
					ranges[num] = tagRange;
					break;
				}
			}
		}

		public void CloseAllOpenedRanges(int endIndex)
		{
			if (ranges.Length == 0)
			{
				return;
			}
			for (int num = ranges.Length - 1; num >= 0; num--)
			{
				if (ranges[num].indexes.y == int.MaxValue)
				{
					TagRange tagRange = ranges[num];
					tagRange.indexes.y = endIndex;
					ranges[num] = tagRange;
				}
			}
		}

		public virtual void SetupContextFor(TAnimCore animator, ModifierInfo[] modifiers)
		{
			animation.ResetContext(animator);
			foreach (ModifierInfo modifier in modifiers)
			{
				animation.SetModifier(modifier);
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("tag: ");
			stringBuilder.Append(tagId);
			if (ranges.Length == 0)
			{
				stringBuilder.Append("\nNo ranges");
			}
			else
			{
				for (int i = 0; i < ranges.Length; i++)
				{
					stringBuilder.Append('\n');
					stringBuilder.Append('-');
					stringBuilder.Append('-');
					stringBuilder.Append(ranges[i]);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
