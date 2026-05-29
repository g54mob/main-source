using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.Twine
{
	public class TwineImporter
	{
		public class TwineHook
		{
			public string prefix;

			public string text;

			public List<string> links;

			public TwineHook(string prefix, string text, List<string> links)
			{
				this.prefix = prefix;
				this.text = text;
				this.links = links;
			}
		}

		protected HashSet<int> playerActorIDs = new HashSet<int>();

		protected const string LinkRegexPattern = "\\[\\[.*?\\]\\]";

		protected static Regex LinkRegex = new Regex("\\[\\[.*?\\]\\]");

		protected static Regex PrefixedHookRegex = new Regex("\\(.+\\)\\[.+\\]");

		protected static Regex GlobalVariableRegex = new Regex("\\$\\w+");

		protected static Regex LocalVariableRegex = new Regex("_\\w+");

		protected static Regex MacroRegex = new Regex("\\(\\w+:.+\\)");

		protected DialogueDatabase database { get; set; }

		protected Template template { get; set; }

		public virtual void ConvertStoryToConversation(DialogueDatabase database, Template template, TwineStory story, int actorID, int conversantID, bool splitPipesIntoEntries, bool useTwineNodePositions = false)
		{
			this.database = database;
			this.template = template;
			Conversation conversation = database.GetConversation(story.name);
			if (conversation == null)
			{
				conversation = template.CreateConversation(template.GetNextConversationID(database), story.name);
				database.conversations.Add(conversation);
			}
			conversation.ActorID = actorID;
			conversation.ConversantID = conversantID;
			playerActorIDs.Clear();
			playerActorIDs.Add(actorID);
			database.actors.ForEach(delegate(Actor actor)
			{
				if (actor.IsPlayer)
				{
					playerActorIDs.Add(actor.id);
				}
			});
			conversation.dialogueEntries.Clear();
			DialogueEntry dialogueEntry = template.CreateDialogueEntry(0, conversation.id, "START");
			conversation.dialogueEntries.Add(dialogueEntry);
			int num = 0;
			TwinePassage[] passages = story.passages;
			foreach (TwinePassage twinePassage in passages)
			{
				num = Mathf.Max(num, SafeConvert.ToInt(twinePassage.pid));
			}
			bool flag = true;
			Dictionary<TwinePassage, List<TwineHook>> dictionary = new Dictionary<TwinePassage, List<TwineHook>>();
			passages = story.passages;
			foreach (TwinePassage twinePassage2 in passages)
			{
				int num3 = SafeConvert.ToInt(twinePassage2.pid);
				if (num3 == 0)
				{
					num3 = ++num;
				}
				DialogueEntry entry = template.CreateDialogueEntry(num3, conversation.id, twinePassage2.name);
				if (useTwineNodePositions)
				{
					SetEntryPosition(entry, twinePassage2.position);
					if (flag)
					{
						flag = false;
						SetEntryPosition(dialogueEntry, new TwinePosition(Mathf.Max(1f, twinePassage2.position.x - 40f), Mathf.Max(1f, twinePassage2.position.y - 45f)));
					}
				}
				ExtractParticipants(twinePassage2.text, actorID, conversantID, isLinkEntry: false, out var dialogueText, out var entryActorID, out var _);
				ExtractSequenceConditionsScriptDescription(ref dialogueText, out var sequence, out var conditions, out var script, out var description);
				ExtractHooks(ref dialogueText, out var hooks);
				dictionary.Add(twinePassage2, hooks);
				dialogueText = RemoveAllLinksFromText(dialogueText);
				ExtractMacros(ref dialogueText, ref entry);
				dialogueText = ReplaceFormatting(dialogueText);
				entry.DialogueText = dialogueText.Trim();
				entry.ActorID = entryActorID;
				entry.ConversantID = conversantID;
				entry.Sequence = AppendCode(entry.Sequence, sequence);
				CheckConditionsForPassthrough(conditions, out conditions, out var falseConditionAction);
				entry.conditionsString = AppendCode(entry.conditionsString, conditions);
				entry.falseConditionAction = falseConditionAction;
				entry.userScript = AppendCode(entry.userScript, script);
				Field.SetValue(entry.fields, "Description", description);
				conversation.dialogueEntries.Add(entry);
			}
			int destinationDialogueID = SafeConvert.ToInt(story.startnode);
			dialogueEntry.outgoingLinks.Add(new Link(conversation.id, dialogueEntry.id, conversation.id, destinationDialogueID));
			int num4 = 0;
			passages = story.passages;
			foreach (TwinePassage twinePassage3 in passages)
			{
				if (twinePassage3.links == null)
				{
					continue;
				}
				int num5 = SafeConvert.ToInt(twinePassage3.pid);
				DialogueEntry dialogueEntry2 = conversation.GetDialogueEntry(num5);
				TwineLink[] links = twinePassage3.links;
				foreach (TwineLink twineLink in links)
				{
					if (twineLink == null)
					{
						continue;
					}
					bool flag2 = IsLinkInHooks(twineLink.link, dictionary[twinePassage3]);
					int destinationDialogueID2 = SafeConvert.ToInt(twineLink.pid);
					if (IsLinkImplicit(twineLink))
					{
						if (!flag2)
						{
							dialogueEntry2.outgoingLinks.Add(new Link(conversation.id, num5, conversation.id, destinationDialogueID2));
						}
						continue;
					}
					DialogueEntry dialogueEntry3 = conversation.GetDialogueEntry(twineLink.name);
					if (dialogueEntry3 != null && playerActorIDs.Contains(dialogueEntry3.ActorID))
					{
						DialogueEntry dialogueEntry4 = dialogueEntry3;
						if (useTwineNodePositions)
						{
							SetEntryPosition(dialogueEntry4, new TwinePosition(twinePassage3.position.x + 40f + (float)num4 * 168f, twinePassage3.position.y + 45f));
							num4++;
						}
						ExtractParticipants(twineLink.name, actorID, conversantID, isLinkEntry: true, out var dialogueText2, out var entryActorID2, out var entryConversantID2);
						ExtractSequenceConditionsScriptDescription(ref dialogueText2, out var sequence2, out var conditions2, out var script2, out var _);
						dialogueEntry4.DialogueText = ReplaceFormatting(dialogueText2);
						dialogueEntry4.ActorID = entryActorID2;
						dialogueEntry4.ConversantID = entryConversantID2;
						dialogueEntry4.Sequence = sequence2;
						dialogueEntry4.conditionsString = AppendCode(dialogueEntry4.conditionsString, conditions2);
						dialogueEntry4.userScript = AppendCode(dialogueEntry4.userScript, script2);
						dialogueEntry2.outgoingLinks.Add(new Link(conversation.id, num5, conversation.id, dialogueEntry4.id));
						continue;
					}
					string linkEntryTitle = GetLinkEntryTitle(twineLink.name, num5);
					DialogueEntry dialogueEntry5 = conversation.GetDialogueEntry(linkEntryTitle);
					if (dialogueEntry5 == null)
					{
						dialogueEntry5 = template.CreateDialogueEntry(++num, conversation.id, linkEntryTitle);
						if (useTwineNodePositions)
						{
							SetEntryPosition(dialogueEntry5, new TwinePosition(twinePassage3.position.x + 40f + (float)num4 * 168f, twinePassage3.position.y + 45f));
							num4++;
						}
						ExtractParticipants(twineLink.name, actorID, conversantID, isLinkEntry: true, out var dialogueText3, out var entryActorID3, out var entryConversantID3);
						ExtractSequenceConditionsScriptDescription(ref dialogueText3, out var sequence3, out var conditions3, out var script3, out var _);
						dialogueEntry5.DialogueText = ReplaceFormatting(dialogueText3);
						dialogueEntry5.ActorID = entryActorID3;
						dialogueEntry5.ConversantID = entryConversantID3;
						dialogueEntry5.Sequence = sequence3;
						dialogueEntry5.conditionsString = AppendCode(dialogueEntry5.conditionsString, conditions3);
						dialogueEntry5.userScript = AppendCode(dialogueEntry5.userScript, script3);
					}
					conversation.dialogueEntries.Add(dialogueEntry5);
					if (!flag2)
					{
						dialogueEntry2.outgoingLinks.Add(new Link(conversation.id, num5, conversation.id, dialogueEntry5.id));
					}
					dialogueEntry5.outgoingLinks.Add(new Link(conversation.id, dialogueEntry5.id, conversation.id, destinationDialogueID2));
				}
			}
			passages = story.passages;
			foreach (TwinePassage twinePassage4 in passages)
			{
				int num7 = SafeConvert.ToInt(twinePassage4.pid);
				DialogueEntry dialogueEntry6 = conversation.GetDialogueEntry(num7);
				_ = Vector2.zero;
				foreach (TwineHook item in dictionary[twinePassage4])
				{
					ExtractParticipants(item.text, dialogueEntry6.ActorID, dialogueEntry6.ConversantID, isLinkEntry: true, out item.text, out var entryActorID4, out var entryConversantID4);
					string conditions4 = (item.prefix.StartsWith("(if:") ? ConvertIfMacro(item.prefix) : string.Empty);
					if (item.links.Count == 0)
					{
						DialogueEntry dialogueEntry7 = conversation.GetDialogueEntry(GetLinkEntryTitle(item.text, num7));
						if (dialogueEntry7 != null)
						{
							dialogueEntry7.conditionsString = conditions4;
						}
						continue;
					}
					foreach (string link in item.links)
					{
						DialogueEntry dialogueEntry8 = conversation.GetDialogueEntry(GetLinkEntryTitle(link, num7));
						if (!string.IsNullOrEmpty(item.text))
						{
							DialogueEntry dialogueEntry9 = template.CreateDialogueEntry(++num, conversation.id, item.text);
							if (useTwineNodePositions)
							{
								SetEntryPosition(dialogueEntry8, new TwinePosition(twinePassage4.position.x + 40f + (float)num4 * 168f, twinePassage4.position.y + 45f));
								num4++;
							}
							dialogueEntry9.DialogueText = item.text;
							dialogueEntry9.ActorID = entryActorID4;
							dialogueEntry9.ConversantID = entryConversantID4;
							CheckConditionsForPassthrough(conditions4, out conditions4, out var falseConditionAction2);
							dialogueEntry9.conditionsString = AppendCode(dialogueEntry9.conditionsString, conditions4);
							dialogueEntry9.falseConditionAction = falseConditionAction2;
							conversation.dialogueEntries.Add(dialogueEntry9);
							dialogueEntry6.outgoingLinks.Add(new Link(conversation.id, dialogueEntry6.id, conversation.id, dialogueEntry9.id));
						}
						else
						{
							dialogueEntry8.conditionsString = conditions4;
							dialogueEntry6.outgoingLinks.Add(new Link(conversation.id, dialogueEntry6.id, conversation.id, dialogueEntry8.id));
						}
					}
				}
			}
			if (splitPipesIntoEntries)
			{
				conversation.SplitPipesIntoEntries();
			}
		}

		protected virtual void SetEntryPosition(DialogueEntry entry, TwinePosition position)
		{
			entry.canvasRect = new Rect(position.x, position.y, 160f, 30f);
		}

		protected string GetLinkEntryTitle(string linkName, int originPassageID)
		{
			return linkName + " Link " + originPassageID;
		}

		protected virtual void ExtractParticipants(string text, int actorID, int conversantID, bool isLinkEntry, out string dialogueText, out int entryActorID, out int entryConversantID)
		{
			ExtractActor(text, actorID, conversantID, isLinkEntry, out dialogueText, out entryActorID);
			if (entryActorID == -1)
			{
				entryActorID = (isLinkEntry ? actorID : conversantID);
			}
			entryConversantID = ((entryActorID == actorID) ? conversantID : actorID);
		}

		protected virtual void ExtractActor(string text, int actorID, int conversantID, bool isLinkEntry, out string dialogueText, out int entryActorID)
		{
			entryActorID = (isLinkEntry ? actorID : conversantID);
			dialogueText = text;
			int num = text.IndexOf(':');
			if (num != -1)
			{
				string actorName = text.Substring(0, num);
				string text2 = text.Substring(num + 1).TrimStart(' ', '\n', '\t');
				Actor actor = database.GetActor(actorName);
				if (actor != null)
				{
					entryActorID = actor.id;
					dialogueText = text2;
				}
			}
			dialogueText = dialogueText.Trim();
		}

		protected virtual void ExtractSequenceConditionsScriptDescription(ref string text, out string sequence, out string conditions, out string script, out string description)
		{
			ExtractBlock("Sequence:", ref text, out sequence);
			ExtractBlock("Conditions:", ref text, out conditions);
			ExtractBlock("Script:", ref text, out script);
			ExtractBlock("Description:", ref text, out description);
		}

		protected virtual void ExtractBlock(string heading, ref string text, out string block)
		{
			int num = text.IndexOf(heading);
			if (num != -1)
			{
				int num2 = num + heading.Length;
				int a = FindBlockIndex(text, num2, "Sequence:");
				int a2 = FindBlockIndex(text, num2, "Conditions:");
				int b = FindBlockIndex(text, num2, "Script:");
				FindBlockIndex(text, num2, "Description:");
				int num3 = Mathf.Min(a, Mathf.Min(a2, b));
				block = text.Substring(num2, num3 - num2).Trim();
				string text2 = text.Substring(0, num);
				if (num3 < text.Length)
				{
					text2 += text.Substring(num3);
				}
				text = text2.Trim();
			}
			else
			{
				block = string.Empty;
			}
		}

		protected int FindBlockIndex(string text, int startIndex, string heading)
		{
			int num = text.IndexOf(heading, startIndex);
			if (num != -1)
			{
				return num;
			}
			return text.Length;
		}

		protected void CheckConditionsForPassthrough(string originalConditions, out string conditions, out string falseConditionAction)
		{
			bool flag = false;
			if (!string.IsNullOrEmpty(originalConditions) && originalConditions.StartsWith("(passthrough)"))
			{
				flag = true;
				conditions = originalConditions.Substring("(passthrough)".Length);
			}
			else
			{
				conditions = originalConditions;
			}
			falseConditionAction = (flag ? "Passthrough" : "Block");
		}

		protected string AppendCode(string block, string extra)
		{
			if (string.IsNullOrEmpty(extra))
			{
				return block;
			}
			if (string.IsNullOrEmpty(block))
			{
				return extra;
			}
			return block + ";\n" + extra;
		}

		protected virtual void ExtractHooks(ref string text, out List<TwineHook> hooks)
		{
			hooks = new List<TwineHook>();
			foreach (Match item in PrefixedHookRegex.Matches(text).Cast<Match>().Reverse())
			{
				int num = item.Value.IndexOf(")[");
				if (num == -1)
				{
					continue;
				}
				string text2 = item.Value.Substring(0, num + 1);
				string text3 = item.Value.Substring(num + 2, item.Length - (text2.Length + 2)).Trim();
				bool num2 = text3.StartsWith("[");
				if (text3.StartsWith("["))
				{
					text3 = text3.Substring(1);
				}
				if (text3.EndsWith("]"))
				{
					text3 = text3.Substring(0, text3.Length - 1);
				}
				ExtractLinksFromText(ref text3, out var links);
				text3 = ReplaceFormatting(text3);
				hooks.Add(new TwineHook(text2, text3, links));
				int num3 = item.Index + item.Length;
				bool flag = 0 <= num3 && num3 < text.Length && text[num3] == '\n';
				string replacement = string.Empty;
				if (!num2 && !string.IsNullOrEmpty(text3))
				{
					string text4 = ConvertIfMacro(text2);
					string text5 = text3.Replace("\"", "\\\"");
					if (flag)
					{
						text5 += "\\n";
					}
					replacement = "[lua(Conditional(" + text4 + ", \"" + text5 + "\"))]";
				}
				text = Replace(text, item.Index, item.Length + (flag ? 1 : 0), replacement);
			}
		}

		protected virtual void ExtractLinksFromText(ref string text, out List<string> links)
		{
			links = new List<string>();
			foreach (Match item in LinkRegex.Matches(text).Cast<Match>().Reverse())
			{
				links.Add(item.Value.Substring(2, item.Value.Length - 4));
				text = Replace(text, item.Index, item.Length, string.Empty);
			}
			text = text.Trim();
		}

		protected virtual string RemoveAllLinksFromText(string text)
		{
			return Regex.Replace(text, "\\[\\[.*?\\]\\]", string.Empty).Trim();
		}

		protected bool IsLinkInHooks(string link, List<TwineHook> hooks)
		{
			foreach (TwineHook hook in hooks)
			{
				if (hook.links.Contains(link))
				{
					return true;
				}
			}
			return false;
		}

		protected bool IsLinkImplicit(TwineLink link)
		{
			if (link.name == null)
			{
				return true;
			}
			if (link.name.Length > 2 && link.name[0] == '(')
			{
				return link.name[link.name.Length - 1] == ')';
			}
			return false;
		}

		protected virtual string RemoveFormatting(string s)
		{
			return Regex.Replace(Regex.Replace(s, "\\/\\/.*?\\/\\/|\\'\\'.*?\\'\\'|\\*\\*.*?\\*\\*|\\*.*?\\*", string.Empty), "==>|=><=|<==", string.Empty).Trim();
		}

		protected virtual string ReplaceFormatting(string s)
		{
			s = ReplaceFormattingCode(s, "//", "<i>", "</i>");
			s = ReplaceFormattingCode(s, "''", "<b>", "</b>");
			s = ReplaceFormattingCode(s, "**", "<b>", "</b>");
			s = ReplaceFormattingCode(s, "*", "<i>", "</i>");
			s = ReplaceVariables(s);
			return s;
		}

		protected virtual string ReplaceFormattingCode(string s, string formatCode, string richCodeOpen, string richCodeClose)
		{
			int num = 0;
			while (s.Contains(formatCode) && num++ < 999)
			{
				int num2 = s.IndexOf(formatCode);
				int num3 = ((num2 + formatCode.Length < s.Length) ? s.IndexOf(formatCode, num2 + 2) : (-1));
				if (num3 == -1)
				{
					break;
				}
				s = s.Substring(0, num2) + richCodeOpen + s.Substring(num2 + formatCode.Length, num3 - (num2 + formatCode.Length)) + richCodeClose + s.Substring(num3 + formatCode.Length);
			}
			return s;
		}

		protected virtual string ReplaceVariables(string s)
		{
			foreach (Match item in GlobalVariableRegex.Matches(s).Cast<Match>().Reverse())
			{
				string replacement = "[var=" + item.Value.Substring(1) + "]";
				s = Replace(s, item.Index, item.Length, replacement);
			}
			foreach (Match item2 in LocalVariableRegex.Matches(s).Cast<Match>().Reverse())
			{
				string replacement2 = "[lua(" + item2.Value.Substring(1) + ")]";
				s = Replace(s, item2.Index, item2.Length, replacement2);
			}
			return s;
		}

		protected string Replace(string s, int index, int length, string replacement)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(s.Substring(0, index));
			stringBuilder.Append(replacement);
			stringBuilder.Append(s.Substring(index + length));
			return stringBuilder.ToString();
		}

		protected void ExtractMacros(ref string s, ref DialogueEntry entry)
		{
			foreach (Match item in MacroRegex.Matches(s).Cast<Match>().Reverse())
			{
				entry.userScript = AppendCode(entry.userScript, ConvertMacro(item.Value));
				s = Replace(s, item.Index, item.Length, string.Empty);
			}
			s.Trim();
		}

		protected string ConvertMacro(string macro)
		{
			if (string.IsNullOrEmpty(macro))
			{
				return macro;
			}
			if (macro.StartsWith("(set:"))
			{
				return ConvertSetMacro(macro);
			}
			Debug.LogWarning("This Twine macro is not supported yet: " + macro);
			return "UnhandledTwineMacro(" + macro + ")";
		}

		protected string ConvertSetMacro(string macro)
		{
			string text = macro.Trim();
			text = text.Substring(0, text.Length - 1);
			string[] array = text.Split(' ');
			if (array.Length < 4)
			{
				return macro;
			}
			string text2 = string.Empty;
			bool flag = true;
			for (int i = 1; i < array.Length; i++)
			{
				string text3 = array[i];
				if (text3 == "to")
				{
					text3 = "=";
				}
				if (flag)
				{
					if (!string.IsNullOrEmpty(text2))
					{
						text2 += ";\n";
					}
					text2 += ConvertVariableToLua(text3);
					flag = false;
				}
				else
				{
					if (text3.EndsWith(","))
					{
						text3 = text3.Substring(0, text3.Length - 1);
						flag = true;
					}
					text2 = text2 + " " + ConvertVariableToLua(text3);
				}
			}
			return text2;
		}

		protected string ConvertIfMacro(string macro)
		{
			string text = macro.Trim();
			text = text.Substring(0, text.Length - 1);
			int num = text.IndexOf(':');
			if (num != -1 && !text.Contains(": "))
			{
				text = text.Substring(0, num + 1) + " " + text.Substring(num + 1);
			}
			string[] array = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length < 4)
			{
				return macro;
			}
			string text2 = ConvertVariableToLua(array[1]) + " ==";
			for (int i = 3; i < array.Length; i++)
			{
				text2 = text2 + " " + ConvertVariableToLua(array[i]);
			}
			return text2;
		}

		protected string ConvertVariableToLua(string variable)
		{
			if (variable.StartsWith("$"))
			{
				return "Variable[\"" + variable.Substring(1) + "\"]";
			}
			if (variable.StartsWith("_"))
			{
				return variable.Substring(1);
			}
			return variable;
		}
	}
}
