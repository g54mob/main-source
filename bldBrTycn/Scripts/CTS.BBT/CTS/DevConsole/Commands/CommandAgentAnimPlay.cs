using System;
using System.Collections;
using System.Collections.Generic;
using Animancer;
using CTS.BBT;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	public class CommandAgentAnimPlay : SelectionCommand<AgentAnimator>, ISubCommand<CommandAgentAnim>, ISubCommand
	{
		public override string Command { get; } = "Play";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.String };

		protected override bool CanSearchObjectInSceneIfNothingSelected { get; }

		public override string GetCommandDescription()
		{
			return "Plays a specified one-shot animation on a selected agent";
		}

		protected override void RunCommandOnSelection(AgentAnimator selection, List<object> args, string[] rawArgs)
		{
			AnimKey[] array = new AnimKey[rawArgs.Length];
			for (int i = 0; i < rawArgs.Length; i++)
			{
				string text = rawArgs[i];
				for (int j = 0; j < AgentAnimData.VarNames.Length; j++)
				{
					string text2 = AgentAnimData.VarNames[j];
					if (text == text2 || string.Equals(text, text2, StringComparison.CurrentCultureIgnoreCase))
					{
						array[i] = AgentAnimData.Values[j];
						break;
					}
				}
				if (array[i].Id == 0)
				{
					DeveloperConsole.LogError("Couldn't find anim " + rawArgs[i] + ".");
					return;
				}
			}
			selection.StopAllCoroutines();
			selection.StartCoroutine(ActionSequence(selection, array));
		}

		private static IEnumerator ActionSequence(AgentAnimator animator, AnimKey[] keys)
		{
			foreach (AnimKey animation in keys)
			{
				yield return animator.PlayPunctual(animation, FadeMode.FromStart);
			}
		}

		protected override bool IsArgumentIndexOutOfBounds(int argIndex)
		{
			return false;
		}

		protected override EValidity CheckArgumentValidity(ref DeveloperConsole.InputReport inputReport, string arg, int argIndex, bool isLastArg)
		{
			if (argIndex < 0)
			{
				return base.CheckArgumentValidity(ref inputReport, arg, argIndex, isLastArg);
			}
			inputReport.CommandArgMatches.Clear();
			EValidity eValidity = EValidity.Invalid;
			string[] varNames = AgentAnimData.VarNames;
			foreach (string text in varNames)
			{
				if (text == "None")
				{
					continue;
				}
				if (string.Equals(arg, text, StringComparison.InvariantCultureIgnoreCase))
				{
					eValidity = EValidity.Valid;
				}
				if (inputReport.CommandArgMatches.Count <= 30 && DeveloperConsole.ArgIsContainedIn(arg, text, caseSensitive: false))
				{
					if (eValidity < EValidity.Incomplete)
					{
						eValidity = EValidity.Incomplete;
					}
					inputReport.CommandArgMatches.Add(text);
				}
			}
			inputReport.ErrorMessage = "Invalid Animation Key";
			return eValidity;
		}
	}
}
