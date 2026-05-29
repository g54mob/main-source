using System;
using CTS.Core;
using CTS.Core.Utilities;
using CareBoo.Serially;
using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(1)]
	public class ToggleBasedOnFSM : CTSBehaviour
	{
		[SerializeField]
		private FSM _fsmToMonitor;

		[SerializeField]
		private MonoBehaviour _componentToEnable;

		[SerializeField]
		private CareBoo.Serially.SerializableType[] _correctTypes;

		protected override void OnEnabled()
		{
			if ((bool)_fsmToMonitor)
			{
				_fsmToMonitor.StateChanged += OnStateChanged;
				_fsmToMonitor.TryGetProperty<object>("CurrentState", out var outObject);
				OnStateChanged(outObject);
			}
		}

		protected override void OnDisabled()
		{
			if ((bool)_fsmToMonitor)
			{
				_fsmToMonitor.StateChanged -= OnStateChanged;
			}
		}

		private void OnStateChanged(object state)
		{
			if (state == null)
			{
				_componentToEnable.enabled = false;
				return;
			}
			Type type = state.GetType();
			CareBoo.Serially.SerializableType[] correctTypes = _correctTypes;
			for (int i = 0; i < correctTypes.Length; i++)
			{
				if (!(correctTypes[i].Type != type))
				{
					_componentToEnable.enabled = true;
					return;
				}
			}
			_componentToEnable.enabled = false;
		}
	}
}
