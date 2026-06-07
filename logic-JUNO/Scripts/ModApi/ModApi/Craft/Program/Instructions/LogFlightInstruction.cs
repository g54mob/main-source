using System;
using ModApi.Flight.UI;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class LogFlightInstruction : ProgramInstruction
	{
		private int _logId = -1;

		public override ProgramInstruction Execute(IThreadContext context)
		{
			string textValue = GetExpression(0).Evaluate(context).TextValue;
			if (_logId == -1)
			{
				bool boolValue = GetExpression(1).Evaluate(context).BoolValue;
				FlightLogEntry flightLogEntry = Game.Instance.FlightScene.FlightSceneUI.FlightLog.AddLog(textValue, FlightLogEntryCategory.Vizzy, boolValue);
				_logId = (boolValue ? flightLogEntry.Id : (-2));
			}
			else if (_logId == -2)
			{
				Game.Instance.FlightScene.FlightSceneUI.FlightLog.AddLog(textValue, FlightLogEntryCategory.Vizzy);
			}
			else
			{
				Game.Instance.FlightScene.FlightSceneUI.FlightLog.UpdateLogEntry(_logId, textValue);
			}
			return base.Execute(context);
		}
	}
}
