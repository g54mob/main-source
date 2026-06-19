using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace QFSW.QC.Suggestors
{
	public class GlobalCommandSuggestor : BasicCachedQcSuggestor<GlobalCommand>
	{
		private static readonly List<GlobalCommand> s_commandIndex = new List<GlobalCommand>();

		private static bool s_isInitialized = false;

		private void InitializeCommandIndex()
		{
			if (s_isInitialized)
			{
				return;
			}
			s_isInitialized = true;
			IQcSuggestor[] array = new InjectionLoader<IQcSuggestor>().GetInjectedInstances().ToArray();
			IQcSuggestionFilter[] array2 = new InjectionLoader<IQcSuggestionFilter>().GetInjectedInstances().ToArray();
			SuggestorOptions options = default(SuggestorOptions);
			List<GlobalCommand> list = new List<GlobalCommand>();
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			foreach (CommandData allCommand in QuantumConsoleProcessor.GetAllCommands())
			{
				if (allCommand.ParamsInGlobalSuggestions == 0)
				{
					continue;
				}
				list2.Clear();
				list2.Add(allCommand.CommandName);
				int num = 0;
				int num2 = Math.Min((int)allCommand.ParamsInGlobalSuggestions, allCommand.ParamCount);
				for (int i = 0; i < num2; i++)
				{
					ParameterInfo parameterInfo = allCommand.MethodParamData[i];
					SuggestionContext context = new SuggestionContext
					{
						TargetType = parameterInfo.ParameterType,
						Prompt = "",
						Depth = 0,
						Tags = parameterInfo.GetCustomAttributes<SuggestorTagAttribute>().SelectMany((SuggestorTagAttribute x) => x.GetSuggestorTags()).ToArray()
					};
					HashSet<string> hashSet = new HashSet<string>();
					IQcSuggestor[] array3 = array;
					foreach (IQcSuggestor qcSuggestor in array3)
					{
						if (qcSuggestor is GlobalCommandSuggestor)
						{
							continue;
						}
						foreach (IQcSuggestion suggestion in qcSuggestor.GetSuggestions(context, options))
						{
							bool flag = true;
							IQcSuggestionFilter[] array4 = array2;
							for (int num4 = 0; num4 < array4.Length; num4++)
							{
								if (!array4[num4].IsSuggestionPermitted(suggestion, context))
								{
									flag = false;
									break;
								}
							}
							if (flag)
							{
								hashSet.Add(suggestion.PrimarySignature);
							}
						}
					}
					if (hashSet.Count <= 0)
					{
						break;
					}
					list3.Clear();
					foreach (string item in list2)
					{
						foreach (string item2 in hashSet)
						{
							string text = item2;
							if (text.Contains(" ") && !text.StartsWith("\""))
							{
								text = "\"" + text + "\"";
							}
							list3.Add(item + " " + text);
						}
					}
					List<string> list4 = list2;
					list2 = list3;
					list3 = list4;
					num++;
				}
				if (num <= 0)
				{
					continue;
				}
				foreach (string item3 in list2)
				{
					list.Add(new GlobalCommand(allCommand, item3, num));
				}
			}
			IEnumerable<IGrouping<string, GlobalCommand>> enumerable = from x in list
				group x by x.ExpandedSignature;
			Stack<GlobalCommand> stack = new Stack<GlobalCommand>();
			foreach (IGrouping<string, GlobalCommand> item4 in enumerable)
			{
				List<GlobalCommand> list5 = item4.OrderBy((GlobalCommand x) => x.Command.ParamCount).ToList();
				stack.Clear();
				foreach (GlobalCommand item5 in list5)
				{
					GlobalCommand current5 = item5;
					if (stack.Count > 0)
					{
						GlobalCommand globalCommand = stack.Peek();
						CommandData command = current5.Command;
						CommandData command2 = globalCommand.Command;
						if (command.ParamCount == command2.ParamCount + 1 && command.ParameterSignature.StartsWith(command2.ParameterSignature))
						{
							stack.Pop();
							current5.NumOptionalParams += 1 + globalCommand.NumOptionalParams;
						}
					}
					stack.Push(current5);
				}
				foreach (GlobalCommand item6 in stack)
				{
					s_commandIndex.Add(item6);
				}
			}
		}

		protected override bool CanProvideSuggestions(SuggestionContext context, SuggestorOptions options)
		{
			if (context.Depth == 0)
			{
				return !string.IsNullOrEmpty(context.Prompt);
			}
			return false;
		}

		protected override IQcSuggestion ItemToSuggestion(GlobalCommand globalCommand)
		{
			return new CommandSuggestion(globalCommand.Command, globalCommand.NumOptionalParams, globalCommand.ExpandedSignature, globalCommand.BakedParamCount);
		}

		protected override IEnumerable<GlobalCommand> GetItems(SuggestionContext context, SuggestorOptions options)
		{
			InitializeCommandIndex();
			return s_commandIndex;
		}

		public static void InvalidateSuggestionCache()
		{
			s_commandIndex.Clear();
			s_isInitialized = false;
		}
	}
}
