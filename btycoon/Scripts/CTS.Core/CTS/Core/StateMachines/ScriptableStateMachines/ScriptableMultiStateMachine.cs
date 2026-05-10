using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core.StateMachines.ScriptableStateMachines
{
	public abstract class ScriptableMultiStateMachine<TEnum, TAgent> : FiniteMultiStateMachine<TEnum, TAgent> where TEnum : Enum where TAgent : MonoBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private TAgent _agent;

		[SerializeField]
		private SerializableDictionary<TEnum, ScriptableState<TEnum, TAgent>> _possibleStates = new SerializableDictionary<TEnum, ScriptableState<TEnum, TAgent>>();

		protected override void OnAwake()
		{
			base.OnAwake();
			SetAgent(_agent);
			foreach (var (key, scriptableState2) in _possibleStates)
			{
				if (!(scriptableState2 == null))
				{
					AddPossibleState(key, UnityEngine.Object.Instantiate(scriptableState2));
				}
			}
		}
	}
}
