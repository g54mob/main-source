using ScheduleOne.PlayerScripts;

namespace ScheduleOne.Variables
{
	public class NumberVariable : Variable<float>
	{
		public NumberVariable(string name, EVariableReplicationMode replicationMode, bool persistent, EVariableMode mode, Player owner, float value)
			: base((string)null, default(EVariableReplicationMode), false, default(EVariableMode), (Player)null, (float)default(_00210))
		{
		}//IL_0024: Expected F4, but got O


		public override bool TryDeserialize(string valueString, out float value)
		{
			value = default(float);
			return false;
		}

		public override bool EvaluateCondition(Condition.EConditionType operation, string value)
		{
			return false;
		}
	}
}
