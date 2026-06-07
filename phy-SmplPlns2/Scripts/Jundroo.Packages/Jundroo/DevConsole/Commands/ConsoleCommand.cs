using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jundroo.DevConsole.Commands
{
	internal class ConsoleCommand
	{
		private static char[] _commandSegmentArgumentCharacters = new char[1] { ' ' };

		private static char[] _commandSegmentCharacters = new char[5] { '/', '\\', '>', '.', ' ' };

		public List<ConsoleCommandSegment> CommandSegments { get; private set; }

		public ConsoleCommand()
		{
			CommandSegments = new List<ConsoleCommandSegment>();
		}

		public ConsoleCommand Clone()
		{
			ConsoleCommand consoleCommand = new ConsoleCommand();
			bool flag = false;
			consoleCommand.CommandSegments = new List<ConsoleCommandSegment>(CommandSegments.Count);
			for (int i = 0; i < CommandSegments.Count; i++)
			{
				ConsoleCommandSegment consoleCommandSegment = CommandSegments[i];
				ConsoleCommandSegment consoleCommandSegment2 = consoleCommandSegment.Clone(flag);
				consoleCommand.CommandSegments.Add(consoleCommandSegment2);
				flag = flag || !consoleCommandSegment2.Evaluated;
				if (flag && i > 0 && (consoleCommandSegment.CommandType == ConsoleCommandSegmentType.GameObjectSelector || consoleCommandSegment.CommandType == ConsoleCommandSegmentType.ComponentSelector))
				{
					consoleCommand.CommandSegments[i - 1].Evaluated = false;
				}
			}
			return consoleCommand;
		}

		public void Evaluate()
		{
			CommandEvaluator.Evaluate(this);
		}

		public List<LogEntry> Execute()
		{
			if (CommandSegments.Count > 0 && string.IsNullOrEmpty(CommandSegments.Last().CommandText))
			{
				CommandSegments.RemoveAt(CommandSegments.Count - 1);
			}
			return CommandEvaluator.Execute(this);
		}

		public void ParseAndUpdate(string command)
		{
			List<string> segments = GetSegments(command ?? string.Empty);
			if (segments.Count == 0)
			{
				CommandSegments.Clear();
			}
			if (segments.Count < CommandSegments.Count)
			{
				CommandSegments.RemoveRange(segments.Count, CommandSegments.Count - segments.Count);
			}
			ConsoleCommandSegmentType? previousSegmentType = null;
			for (int i = 0; i < segments.Count; i++)
			{
				string text = segments[i];
				ConsoleCommandSegmentType segmentType = GetSegmentType(text, previousSegmentType);
				bool flag = true;
				if (i < CommandSegments.Count)
				{
					ConsoleCommandSegment consoleCommandSegment = CommandSegments[i];
					if (consoleCommandSegment.CommandType != segmentType || consoleCommandSegment.CommandText != text)
					{
						CommandSegments.RemoveRange(i, CommandSegments.Count - i);
					}
					else
					{
						flag = false;
					}
				}
				if (flag)
				{
					CommandSegments.Add(ConsoleCommandSegment.Create(text, segmentType));
				}
				previousSegmentType = segmentType;
			}
		}

		public override string ToString()
		{
			return ToString(CommandSegments.Count);
		}

		public string ToString(int numberOfSegments)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < Math.Min(numberOfSegments, CommandSegments.Count); i++)
			{
				ConsoleCommandSegment consoleCommandSegment = CommandSegments[i];
				if (consoleCommandSegment.CommandType == ConsoleCommandSegmentType.Argument)
				{
					stringBuilder.Append(' ');
				}
				if (consoleCommandSegment.CommandText.Contains(' '))
				{
					stringBuilder.Append('"');
					stringBuilder.Append(consoleCommandSegment.CommandText);
					stringBuilder.Append('"');
				}
				else
				{
					stringBuilder.Append(consoleCommandSegment.CommandText);
				}
			}
			return stringBuilder.ToString();
		}

		private static ConsoleCommandSegmentType GetSegmentType(string segment, ConsoleCommandSegmentType? previousSegmentType)
		{
			if (previousSegmentType.HasValue)
			{
				switch (previousSegmentType.Value)
				{
				case ConsoleCommandSegmentType.FindAllChildGameObjects:
				case ConsoleCommandSegmentType.FindChildGameObjects:
					return ConsoleCommandSegmentType.GameObjectSelector;
				case ConsoleCommandSegmentType.FindChildComponents:
				case ConsoleCommandSegmentType.FindAllChildComponents:
					return ConsoleCommandSegmentType.ComponentSelector;
				case ConsoleCommandSegmentType.FindMembers:
				case ConsoleCommandSegmentType.FindAllMembers:
					return ConsoleCommandSegmentType.MemberSelector;
				case ConsoleCommandSegmentType.GameObjectSelector:
				case ConsoleCommandSegmentType.ComponentSelector:
					switch (segment)
					{
					case "\\\\":
					case "//":
					case "\\/":
					case "/\\":
						return ConsoleCommandSegmentType.FindAllChildGameObjects;
					case "/":
					case "\\":
						return ConsoleCommandSegmentType.FindChildGameObjects;
					case ">>":
						return ConsoleCommandSegmentType.FindAllChildComponents;
					case ">":
						return ConsoleCommandSegmentType.FindChildComponents;
					case "..":
						return ConsoleCommandSegmentType.FindAllMembers;
					case ".":
						return ConsoleCommandSegmentType.FindMembers;
					default:
						return ConsoleCommandSegmentType.Unknown;
					}
				case ConsoleCommandSegmentType.MemberSelector:
				case ConsoleCommandSegmentType.Command:
				case ConsoleCommandSegmentType.Argument:
					return ConsoleCommandSegmentType.Argument;
				default:
					return ConsoleCommandSegmentType.Unknown;
				}
			}
			switch (segment)
			{
			case "\\\\":
			case "//":
			case "\\/":
			case "/\\":
				return ConsoleCommandSegmentType.FindAllChildGameObjects;
			case "/":
			case "\\":
				return ConsoleCommandSegmentType.FindChildGameObjects;
			case ">>":
				return ConsoleCommandSegmentType.FindAllChildComponents;
			case ">":
				return ConsoleCommandSegmentType.FindChildComponents;
			default:
				return ConsoleCommandSegmentType.Command;
			}
		}

		private List<string> GetSegments(string command)
		{
			List<string> list = new List<string>();
			int num = 0;
			bool flag = false;
			while (num < command.Length)
			{
				if (command[num] == ' ')
				{
					num++;
					if (list.Count > 0)
					{
						flag = true;
					}
				}
				else if (!flag && (command[num] == '/' || command[num] == '\\'))
				{
					int num2 = num + 1;
					if (num2 < command.Length && (command[num2] == '/' || command[num2] == '\\'))
					{
						list.Add(command.Substring(num, 2));
						num += 2;
					}
					else
					{
						list.Add(command.Substring(num, 1));
						num++;
					}
				}
				else if (!flag && command[num] == '>')
				{
					int num3 = num + 1;
					if (num3 < command.Length && command[num3] == '>')
					{
						list.Add(command.Substring(num, 2));
						num += 2;
					}
					else
					{
						list.Add(command.Substring(num, 1));
						num++;
					}
				}
				else if (!flag && command[num] == '.')
				{
					int num4 = num + 1;
					if (num4 < command.Length && command[num4] == '.')
					{
						list.Add(command.Substring(num, 2));
						num += 2;
					}
					else
					{
						list.Add(command.Substring(num, 1));
						num++;
					}
				}
				else if (command[num] == '"')
				{
					int num5 = command.IndexOf('"', num + 1);
					if (num5 == -1)
					{
						list.Add(command.Substring(num + 1));
						num = command.Length;
					}
					else
					{
						list.Add(command.Substring(num + 1, num5 - num - 1));
						num = num5 + 1;
					}
				}
				else
				{
					int num6 = command.IndexOfAny(flag ? _commandSegmentArgumentCharacters : _commandSegmentCharacters, num);
					if (num6 == -1)
					{
						list.Add(command.Substring(num));
						num = command.Length;
					}
					else
					{
						list.Add(command.Substring(num, num6 - num));
						num = num6;
					}
				}
			}
			return list;
		}
	}
}
