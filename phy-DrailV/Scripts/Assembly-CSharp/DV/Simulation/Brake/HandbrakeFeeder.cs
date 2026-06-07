using System;
using DV.CabControls;
using UnityEngine;

namespace DV.Simulation.Brake
{
	public class HandbrakeFeeder : MonoBehaviour
	{
		[NonSerialized]
		public ControlImplBase control;

		private bool justMoved;

		private Action<float> controlMovedAction;

		public void Init(float startValue, Action<float> controlMovedAction)
		{
			control = GetComponent<ControlImplBase>();
			if (control == null)
			{
				Debug.LogError("Unexpected state: Can't find ControlImplBase on " + base.gameObject.name + ". Destroying self", base.gameObject);
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				control.SetValue(startValue);
				this.controlMovedAction = controlMovedAction;
			}
		}

		public void SetupControlChangedListeners()
		{
			control.ValueChanged += OnHandbrakeControlChange;
		}

		public void Deinit()
		{
			if (control != null)
			{
				control.ValueChanged -= OnHandbrakeControlChange;
			}
		}

		public void PropagateValue(float value, bool forced)
		{
			if (forced)
			{
				control.SetValue(value);
			}
			else if (!justMoved)
			{
				control.SetValue(value);
			}
		}

		private void OnHandbrakeControlChange(ValueChangedEventArgs valueChangedArgs)
		{
			justMoved = true;
			controlMovedAction(valueChangedArgs.newValue);
			justMoved = false;
		}
	}
}
