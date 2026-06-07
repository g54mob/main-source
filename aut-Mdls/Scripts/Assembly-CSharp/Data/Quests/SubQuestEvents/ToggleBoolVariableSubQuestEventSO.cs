using Data.Variables;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Toggle Bool Variable SO", fileName = "ToggleBoolVariableSO", order = 29)]
	public class ToggleBoolVariableSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private BoolVariableSO _boolVariable;

		[SerializeField]
		private bool _toggle;

		public override void Execute()
		{
			_boolVariable.SetValue(_toggle);
		}
	}
}
