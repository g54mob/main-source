using System;
using UnityEngine;

namespace Vehicles
{
	public class EngineSocket : MonoBehaviour
	{
		private EngineFunctionHandler _currentHandler;

		public IEngine CurrentEngine { get; private set; }

		public event Action OnSystemsRefreshRequired;

		public void SetEngine(IEngine engine)
		{
			if (CurrentEngine is MonoBehaviour monoBehaviour)
			{
				EngineFunctionHandler component = monoBehaviour.GetComponent<EngineFunctionHandler>();
				if (component != null)
				{
					component.OnEngineLogicChanged -= HandleLogicChange;
				}
			}
			CurrentEngine = engine;
			if (engine is MonoBehaviour monoBehaviour2)
			{
				EngineFunctionHandler engineFunctionHandler = (_currentHandler = monoBehaviour2.GetComponent<EngineFunctionHandler>());
				if (engineFunctionHandler != null)
				{
					engineFunctionHandler.OnEngineLogicChanged += HandleLogicChange;
				}
			}
			HandleLogicChange();
		}

		private void HandleLogicChange()
		{
			this.OnSystemsRefreshRequired?.Invoke();
		}

		public bool CheckSystem(PartFunction function)
		{
			if (_currentHandler == null)
			{
				return false;
			}
			return _currentHandler.IsFunctionActive(function);
		}
	}
}
