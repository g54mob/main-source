using ScheduleOne.PlayerScripts;

namespace ScheduleOne.Variables
{
	public class BoolVariable : Variable<bool>
	{
		public BoolVariable(string name, EVariableReplicationMode replicationMode, bool persistent, EVariableMode mode, Player owner, bool value)
			: base((string)null, default(EVariableReplicationMode), false, default(EVariableMode), (Player)null, (byte)(int)default(_00210) != 0)
		{
		}//IL_0024: Expected I4, but got O


		public override bool TryDeserialize(string valueString, out bool value)
		{
			value = default(bool);
			return false;
		}

		public override bool EvaluateCondition(Condition.EConditionType operation, string value)
		{
			return false;
		}
	}
}
