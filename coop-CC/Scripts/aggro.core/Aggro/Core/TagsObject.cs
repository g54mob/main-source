using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Aggro.Core
{
	[CreateAssetMenu(menuName = "Data/Tags", fileName = "tags-NAME")]
	public class TagsObject : ScriptableObject, ISerializationCallbackReceiver
	{
		[Serializable]
		internal class ContextEntry
		{
			public string label;

			public TagContext id;

			public Color bgColor;

			public Color textColor;

			public string[] tags = new string[32];
		}

		private struct DebugContext : IComparable<DebugContext>
		{
			public TagContext context;

			public string label;

			public int CompareTo(DebugContext other)
			{
				return string.Compare(label, other.label, StringComparison.InvariantCultureIgnoreCase);
			}
		}

		[SerializeField]
		private List<ContextEntry> _contexts = new List<ContextEntry>();

		[HideInInspector]
		[SerializeField]
		internal int nextContextId = 1;

		internal Dictionary<TagContext, ContextEntry> contextToEntry = new Dictionary<TagContext, ContextEntry>();

		[NonSerialized]
		internal int version = 1;

		internal const int TAG_COUNT = 32;

		private const string TAG_STRING_PATTERN = "^(?<context>[\\S]+)/(?<tag>[\\S]+)$";

		private const string TAG_GENERIC_BIT_PATTERN = "^<Tag (?<bit>[0-9]+)>$";

		public void OnBeforeSerialize()
		{
			_contexts.Clear();
			_contexts.Capacity = contextToEntry.Count;
			foreach (ContextEntry value in contextToEntry.Values)
			{
				_contexts.Add(value);
			}
		}

		public void OnAfterDeserialize()
		{
			contextToEntry.Clear();
			int count = _contexts.Count;
			contextToEntry.EnsureCapacity(count);
			for (int i = 0; i < count; i++)
			{
				ContextEntry contextEntry = _contexts[i];
				contextToEntry[contextEntry.id] = contextEntry;
			}
		}

		public Tag FindTag(string contextLabel, string tagLabel)
		{
			TagContext context = FindContext(contextLabel);
			if (!context.isValid)
			{
				Debug.LogError("Could not find tag context! Context: " + contextLabel + " Tag: " + tagLabel);
				return Tag.invalid;
			}
			int num = FindTagBit(context, tagLabel);
			if (num < 0)
			{
				Debug.LogError("Could not find tag label! Context: " + contextLabel + " Tag: " + tagLabel);
				return Tag.invalid;
			}
			return new Tag(context, num);
		}

		public Tag DebugTagFromString(string str)
		{
			Match match = Regex.Match(str, "^(?<context>[\\S]+)/(?<tag>[\\S]+)$");
			if (!match.Success)
			{
				Debug.LogWarning("Invalid tag string (" + str + ")");
				return Tag.invalid;
			}
			string value = match.Groups["context"].Value;
			TagContext tagContext = FindContext(value);
			if (tagContext == TagContext.invalid)
			{
				Debug.LogWarning("Invalid tag context (" + value + ")");
				return Tag.invalid;
			}
			string value2 = match.Groups["tag"].Value;
			Match match2 = Regex.Match(value2, "^<Tag (?<bit>[0-9]+)>$");
			if (match2.Success)
			{
				int num = int.Parse(match2.Groups["bit"].Value);
				if (num < 0 || num >= 32)
				{
					Debug.LogWarning($"Bit out of range ({num})");
					return Tag.invalid;
				}
				return new Tag(tagContext, num);
			}
			int num2 = FindTagBit(tagContext, value2);
			if (num2 >= 0)
			{
				return new Tag(tagContext, num2);
			}
			Debug.LogWarning("Invalid tag label (" + value2 + ")");
			return Tag.invalid;
		}

		public TagContext FindContext(string contextLabel)
		{
			if (contextLabel == null)
			{
				return TagContext.invalid;
			}
			foreach (ContextEntry value in contextToEntry.Values)
			{
				if (value.label == contextLabel)
				{
					return value.id;
				}
			}
			return TagContext.invalid;
		}

		private int FindTagBit(TagContext context, string tagLabel)
		{
			ContextEntry contextEntry = contextToEntry[context];
			for (int i = 0; i < contextEntry.tags.Length; i++)
			{
				if (contextEntry.tags[i] == tagLabel)
				{
					return i;
				}
			}
			return -1;
		}

		public TagContext[] DebugGetContexts()
		{
			List<DebugContext> list = new List<DebugContext>();
			foreach (ContextEntry value in contextToEntry.Values)
			{
				list.Add(new DebugContext
				{
					context = value.id,
					label = value.label
				});
			}
			list.Sort();
			TagContext[] array = new TagContext[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				array[i] = list[i].context;
			}
			return array;
		}

		public Tag[] DebugGetTags()
		{
			List<Tag> list = new List<Tag>();
			foreach (ContextEntry value in contextToEntry.Values)
			{
				for (int i = 0; i < value.tags.Length; i++)
				{
					if (!string.IsNullOrWhiteSpace(value.tags[i]))
					{
						list.Add(new Tag
						{
							context = value.id,
							bit = i
						});
					}
				}
			}
			Tags.DebugSortByLabel(list);
			return list.ToArray();
		}

		public string DebugGetTagLabel(Tag tag)
		{
			if (DebugHasContext(tag.context))
			{
				string text = DebugGetContextLabel(tag.context);
				string text2 = contextToEntry[tag.context].tags[tag.bit];
				if (string.IsNullOrWhiteSpace(text2))
				{
					text2 = $"<Tag {tag.bit}>";
				}
				return text + "/" + text2;
			}
			return $"<NONE>/<Tag {tag.bit}>";
		}

		public bool DebugHasContext(TagContext context)
		{
			if (!context.isValid)
			{
				return false;
			}
			return contextToEntry.ContainsKey(context);
		}

		public string DebugGetContextLabel(TagContext context)
		{
			string text = DebugGetContextLabelRaw(context);
			if (string.IsNullOrWhiteSpace(text))
			{
				return $"<CONTEXT {context.contextId}>";
			}
			return text;
		}

		public string DebugGetContextLabelRaw(TagContext context)
		{
			return contextToEntry[context].label;
		}
	}
}
