using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TMPEffects.Tags;
using TMPro;

namespace TMPEffects.TextProcessing
{
	public class TMPEffectsTextProcessor : ITextPreprocessor, ITagProcessorManager, IEnumerable<TagProcessor>, IEnumerable
	{
		public delegate void TMPTextProcessorEventHandler(string text);

		private class Indices
		{
			public int start;

			public int end;

			public bool startSet;

			public bool endSet;

			public readonly TMPEffectTagIndices indices;

			public Indices(TMPEffectTagIndices indices)
			{
				start = indices.StartIndex;
				end = indices.EndIndex;
				startSet = false;
				endSet = false;
				this.indices = indices;
			}
		}

		private TagProcessorManager processors;

		private StringBuilder sb;

		private Stack<TMP_Style> styles = new Stack<TMP_Style>();

		public TMP_Text TextComponent { get; private set; }

		public ReadOnlyDictionary<char, ReadOnlyCollection<TagProcessor>> TagProcessors => ((ITagProcessorManager)processors).TagProcessors;

		public event TMPTextProcessorEventHandler BeginPreProcess;

		public event TMPTextProcessorEventHandler FinishPreProcess;

		public event TMPTextProcessorEventHandler BeginAdjustIndices;

		public event TMPTextProcessorEventHandler FinishAdjustIndices;

		public TMPEffectsTextProcessor(TMP_Text text)
		{
			sb = new StringBuilder();
			processors = new TagProcessorManager();
			TextComponent = text;
		}

		public void AddProcessor(char prefix, TagProcessor processor, int priority = 0)
		{
			processors.AddProcessor(prefix, processor, priority);
		}

		public bool RemoveProcessor(char prefix, TagProcessor processor)
		{
			return processors.RemoveProcessor(prefix, processor);
		}

		public IEnumerator<TagProcessor> GetEnumerator()
		{
			return processors.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return processors.GetEnumerator();
		}

		public string PreprocessText(string text)
		{
			this.BeginPreProcess?.Invoke(text);
			styles.Clear();
			foreach (TagProcessor processor in processors)
			{
				processor.Reset();
			}
			if (string.IsNullOrEmpty(text))
			{
				return " ";
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			sb = new StringBuilder();
			ParsingUtility.TagInfo tag = new ParsingUtility.TagInfo();
			bool flag = true;
			TMP_StyleSheet tMP_StyleSheet = ((TextComponent.styleSheet != null) ? TextComponent.styleSheet : TMP_Settings.defaultStyleSheet);
			while (ParsingUtility.GetNextTag(text, num2, ref tag))
			{
				if (num2 != tag.startIndex)
				{
					num = 0;
					sb.Append(text.AsSpan(num2, tag.startIndex - num2));
				}
				if (tag.name == "noparse" || tag.name == "NOPARSE")
				{
					if (tag.type == ParsingUtility.TagType.Open)
					{
						sb.Append("<noparse>");
						flag = false;
					}
					else
					{
						sb.Append("</noparse>");
						flag = true;
					}
					num2 = tag.endIndex + 1;
					continue;
				}
				if (tag.name == "sprite" || tag.name == "SPRITE")
				{
					Dictionary<string, string> tagParametersDict = ParsingUtility.GetTagParametersDict(tag.parameterString);
					if (tagParametersDict.ContainsKey("anim"))
					{
						string[] array = tagParametersDict["anim"].Split(',');
						if (array.Length == 3)
						{
							if (!HandleTag(ref tag, tag.startIndex + num3, num))
							{
								sb.Append(" <color=red>!NATIVE SPRITE ANIMATIONS NOT SUPPORTED; ADD TMPANIMATOR!</color> ");
							}
							else
							{
								num3 -= tag.endIndex - tag.startIndex + 1;
								num++;
								StringBuilder stringBuilder = new StringBuilder();
								stringBuilder.Append("<sprite");
								foreach (KeyValuePair<string, string> item in tagParametersDict)
								{
									switch (item.Key)
									{
									case "name":
									case "NAME":
									case "tint":
									case "TINT":
									case "color":
									case "COLOR":
										stringBuilder.Append(" " + item.Key + "=\"" + item.Value + "\"");
										break;
									case "":
										if (!string.IsNullOrWhiteSpace(item.Value))
										{
											stringBuilder.Append(item.Key + "=\"" + item.Value + "\"");
										}
										break;
									}
								}
								stringBuilder.Append(" index=" + array[0]);
								stringBuilder.Append("></sprite>");
								text = text.Insert(tag.endIndex + 1, stringBuilder.ToString());
							}
							num2 = tag.endIndex + 1;
							continue;
						}
					}
				}
				else if (tMP_StyleSheet != null && (tag.name == "style" || tag.name == "STYLE"))
				{
					if (tag.type == ParsingUtility.TagType.Close)
					{
						text = text.Remove(tag.startIndex, tag.endIndex - tag.startIndex + 1);
						if (styles.Count > 0)
						{
							text = text.Insert(tag.startIndex, styles.Pop().styleClosingDefinition);
						}
						num2 = tag.startIndex;
						continue;
					}
					if (tag.parameterString.Length > 6)
					{
						int num4 = 6;
						int num5 = tag.parameterString.Length - 1;
						if (num4 != num5 && tag.parameterString[num4] == '"')
						{
							num4++;
						}
						if (tag.parameterString[num5] == '"')
						{
							num5--;
						}
						TMP_Style style = tMP_StyleSheet.GetStyle(tag.parameterString.Substring(num4, num5 - num4 + 1));
						if (style != null)
						{
							text = text.Remove(tag.startIndex, tag.endIndex - tag.startIndex + 1);
							text = text.Insert(tag.startIndex, style.styleOpeningDefinition);
							styles.Push(style);
							num2 = tag.startIndex;
							continue;
						}
					}
				}
				if (!flag)
				{
					num = 0;
					sb.Append(text.AsSpan(tag.startIndex, tag.endIndex - tag.startIndex + 1));
					num2 = tag.endIndex + 1;
					continue;
				}
				if (!HandleTag(ref tag, tag.startIndex + num3, num))
				{
					sb.Append(text.AsSpan(tag.startIndex, tag.endIndex - tag.startIndex + 1));
				}
				else
				{
					num3 -= tag.endIndex - tag.startIndex + 1;
					num++;
				}
				num2 = tag.endIndex + 1;
			}
			sb.Append(text.AsSpan(num2, text.Length - num2));
			sb.Append(' ');
			string text2 = sb.ToString();
			this.FinishPreProcess?.Invoke(text2);
			return text2;
		}

		public void AdjustIndices()
		{
			TMP_TextInfo textInfo = TextComponent.textInfo;
			this.BeginAdjustIndices?.Invoke(textInfo.textComponent.text);
			Dictionary<TagProcessor, List<KeyValuePair<Indices, TMPEffectTag>>> dictionary = new Dictionary<TagProcessor, List<KeyValuePair<Indices, TMPEffectTag>>>();
			foreach (TagProcessor processor in processors)
			{
				dictionary.Add(processor, new List<KeyValuePair<Indices, TMPEffectTag>>());
				foreach (KeyValuePair<TMPEffectTagIndices, TMPEffectTag> processedTag in processor.ProcessedTags)
				{
					dictionary[processor].Add(new KeyValuePair<Indices, TMPEffectTag>(new Indices(processedTag.Key), processedTag.Value));
				}
			}
			foreach (KeyValuePair<TagProcessor, List<KeyValuePair<Indices, TMPEffectTag>>> item in dictionary)
			{
				foreach (KeyValuePair<Indices, TMPEffectTag> item2 in item.Value)
				{
					for (int i = 0; i < textInfo.characterCount; i++)
					{
						TMP_CharacterInfo tMP_CharacterInfo = textInfo.characterInfo[i];
						if (!item2.Key.startSet && item2.Key.start <= tMP_CharacterInfo.index)
						{
							item2.Key.start = i;
							item2.Key.startSet = true;
						}
						if (item2.Key.end != -1 && !item2.Key.endSet && item2.Key.end <= tMP_CharacterInfo.index)
						{
							item2.Key.end = i;
							item2.Key.endSet = true;
						}
						if (item2.Key.startSet && (item2.Key.end == -1 || item2.Key.endSet))
						{
							break;
						}
					}
				}
			}
			foreach (KeyValuePair<TagProcessor, List<KeyValuePair<Indices, TMPEffectTag>>> item3 in dictionary)
			{
				foreach (KeyValuePair<Indices, TMPEffectTag> item4 in item3.Value)
				{
					item3.Key.AdjustIndices(new KeyValuePair<TMPEffectTagIndices, TMPEffectTag>(item4.Key.indices, item4.Value), new KeyValuePair<TMPEffectTagIndices, TMPEffectTag>(new TMPEffectTagIndices(item4.Key.start, item4.Key.end, item4.Key.indices.OrderAtIndex), item4.Value));
				}
			}
			this.FinishAdjustIndices?.Invoke(textInfo.textComponent.text);
		}

		private bool HandleTag(ref ParsingUtility.TagInfo tagInfo, int textIndex, int order)
		{
			if (!processors.TagProcessors.TryGetValue(tagInfo.prefix, out var value))
			{
				return false;
			}
			if (value.Count == 1)
			{
				return value[0].Process(tagInfo, textIndex, order);
			}
			for (int i = 0; i < value.Count; i++)
			{
				if (value[i].Process(tagInfo, textIndex, order))
				{
					return true;
				}
			}
			return false;
		}
	}
}
