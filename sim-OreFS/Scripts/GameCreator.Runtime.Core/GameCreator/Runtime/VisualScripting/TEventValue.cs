using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Keywords(new string[] { "Left", "Right", "Down", "Up", "Press", "Move", "Direction" })]
	[Keywords(new string[] { "Keyboard", "Mouse", "Button", "Gamepad", "Controller", "Joystick" })]
	[Parameter("Value", "The Input value read")]
	[Parameter("Compare", "The comparison applied to the input value")]
	[Parameter("Min Distance", "If set to None, the input acts globally. If set to Game Object, the event only fires if the target object is within the specified radius")]
	public abstract class TEventValue : Event
	{
		private const float EPSILON = 0.01f;

		[NonSerialized]
		private Args m_Args;

		[NonSerialized]
		private bool m_Used;

		protected abstract float Value { get; }

		protected abstract CompareMinDistanceOrNone MinDistance { get; }

		protected internal override void OnAwake(Trigger trigger)
		{
			base.OnAwake(trigger);
			m_Args = new Args(trigger);
		}

		protected void CheckExecute()
		{
			if (Math.Abs(Value) >= 0.01f)
			{
				Execute();
			}
			else
			{
				m_Used = false;
			}
		}

		private void Execute()
		{
			if (!m_Used && MinDistance.Match(m_Trigger.transform, m_Args))
			{
				m_Used = true;
				m_Trigger.Execute(base.Self);
			}
		}

		protected internal override void OnDrawGizmosSelected(Trigger trigger)
		{
			base.OnDrawGizmosSelected(trigger);
			MinDistance.OnDrawGizmos(trigger.transform, m_Args);
		}
	}
}
