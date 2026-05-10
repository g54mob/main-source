using System.Collections.Generic;
using CTS.DevConsole;

namespace CTS
{
	public class CommandPrestige : SelectionCommand<Prestige>
	{
		private enum EType
		{
			Default = 0,
			DebugHigh = 1,
			DebugLow = 2
		}

		private static readonly Resource<PrestigeLevelsData> DebugDataHigh = new Resource<PrestigeLevelsData>("Scriptables/DebugPrestige_High");

		private static readonly Resource<PrestigeLevelsData> DebugDataLow = new Resource<PrestigeLevelsData>("Scriptables/DebugPrestige_Low");

		public override string Command { get; } = "Prestige";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { typeof(EType) };

		protected override bool CanSearchObjectInSceneIfNothingSelected { get; } = true;

		protected override void RunCommandOnSelection(Prestige selection, List<object> args, string[] rawArgs)
		{
			object obj = args[0];
			if (obj is EType)
			{
				switch ((EType)obj)
				{
				case EType.Default:
					selection.ResetPrestigeData();
					break;
				case EType.DebugHigh:
					selection.SetPrestigeData(DebugDataHigh);
					break;
				case EType.DebugLow:
					selection.SetPrestigeData(DebugDataLow);
					break;
				}
			}
		}

		public override string GetCommandDescription()
		{
			return "Sets the current Prestige Level Data";
		}
	}
}
