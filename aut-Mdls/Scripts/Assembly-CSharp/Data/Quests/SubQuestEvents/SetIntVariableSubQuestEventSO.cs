using Data.Variables;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Set Int Variable Event", fileName = "SetIntVariableEvent", order = 3)]
	public class SetIntVariableSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private IntVariableSO _intVariable;

		[SerializeField]
		private int _value;

		public override void Execute()
		{
			_intVariable.SetValue(_value);
		}
	}
}
