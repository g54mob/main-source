using System;
using System.Collections.Generic;
using System.Linq;
using AssembleSystem;
using UnityEngine;

namespace Vehicles
{
	public class EngineFunctionHandler : MonoBehaviour
	{
		[SerializeField]
		private List<FunctionMap> _mappings = new List<FunctionMap>();

		public event Action OnEngineLogicChanged;

		public void NotifyEngineStatusChanged()
		{
			this.OnEngineLogicChanged?.Invoke();
		}

		public bool IsFunctionActive(PartFunction function)
		{
			FunctionMap functionMap = _mappings.FirstOrDefault((FunctionMap m) => m.Function == function);
			if (functionMap.Part == null)
			{
				return false;
			}
			return functionMap.Part.StateMachine.Tightened;
		}

		public T GetPartAs<T>(PartFunction function) where T : class
		{
			PartObject part = _mappings.FirstOrDefault((FunctionMap m) => m.Function == function).Part;
			if ((object)part == null)
			{
				return null;
			}
			return part.GetComponent<T>();
		}
	}
}
