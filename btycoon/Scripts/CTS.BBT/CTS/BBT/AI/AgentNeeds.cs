using System;
using CTS.DevConsole.Variables;
using UnityEngine;

namespace CTS.BBT.AI
{
	public class AgentNeeds : MonoBehaviour
	{
		private Agent _agentRef;

		[SerializeField]
		private CVarEnumDictionaryReference<ENeedType, CVarBool> _cVarIndividualNeedsTick;

		private static CVarBoolReference _cVarDoNeedsTick;

		public event Action<ENeedType, float> OnNeedChange;

		private void Awake()
		{
			_agentRef = GetComponent<Agent>();
		}

		public bool TryGetValue(ENeedType p_needType, out float p_value)
		{
			p_value = 0f;
			return true;
		}

		public bool TryGetRawValue(ENeedType needType, out int value, out int maxValue)
		{
			value = 0;
			maxValue = 0;
			return true;
		}

		public void SetNeedValue(ENeedType p_needType, float p_percent = 1f)
		{
		}

		public void SetNeedRawValue(ENeedType needType, int value)
		{
		}

		public void SetNeedTarget(ENeedType needType, float target)
		{
		}

		public void AddToNeed(ENeedType p_needType, float p_valueToAdd)
		{
		}

		public void AddRawToNeed(ENeedType needType, int value)
		{
		}
	}
}
