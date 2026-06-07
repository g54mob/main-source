using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Console
{
	public class CommandHelp : Command
	{
		private static readonly string[] HELP_1 = new string[4] { "Input <command> followed by pairs of <parameter> <value>", "For example: destroy name Cube", "", "Commands:" };

		private static readonly string[] HELP_2 = new string[2] { "Add values between quotes if the value requires a space", "For example: destroy name \"My Player\"" };

		public override string Name => "help";

		public override string Description => string.Empty;

		public override bool IsHidden => true;

		public override Output[] Run(Input input)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string[] hELP_ = HELP_1;
			foreach (string value in hELP_)
			{
				stringBuilder.AppendLine(value);
			}
			List<Command> list = new List<Command>(Database.Get.Values);
			list.Sort(CompareCommands);
			foreach (Command item in list)
			{
				if (item.IsHidden)
				{
					continue;
				}
				stringBuilder.AppendLine(string.Empty);
				stringBuilder.AppendLine(item.Name + ":");
				if (!string.IsNullOrEmpty(item.Description))
				{
					stringBuilder.AppendLine("  " + item.Description);
				}
				List<IAction> list2 = new List<IAction>(item.Actions);
				list2.Sort(CompareActions);
				foreach (IAction item2 in list2)
				{
					stringBuilder.AppendLine("- " + item2.Name + ": " + item2.Description);
				}
			}
			stringBuilder.AppendLine(string.Empty);
			hELP_ = HELP_2;
			foreach (string value2 in hELP_)
			{
				stringBuilder.AppendLine(value2);
			}
			return new Output[1] { Output.Success(stringBuilder.ToString()) };
		}

		private static int CompareCommands(Command x, Command y)
		{
			return string.Compare(x.Name, y.Name, StringComparison.InvariantCulture);
		}

		private static int CompareActions(IAction x, IAction y)
		{
			return string.Compare(x.Name, y.Name, StringComparison.InvariantCulture);
		}
	}
}
