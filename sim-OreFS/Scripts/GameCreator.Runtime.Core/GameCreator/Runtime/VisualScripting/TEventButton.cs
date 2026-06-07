using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Button", "The button that triggers the event")]
	[Parameter("Min Distance", "If set to None, the input acts globally. If set to Game Object, the event only fires if the target object is within the specified radius")]
	public abstract class TEventButton : Event
	{
		[SerializeField]
		private InputPropertyButton m_Button = InputButtonJump.Create();

		[SerializeField]
		private CompareMinDistanceOrNone m_MinDistance = new CompareMinDistanceOrNone();

		protected internal override void OnAwake(Trigger trigger)
		{
			base.OnAwake(trigger);
			m_Button.OnStartup();
		}

		protected internal override void OnEnable(Trigger trigger)
		{
			base.OnEnable(trigger);
			m_Button.RegisterPerform(OnInput);
		}

		protected internal override void OnDisable(Trigger trigger)
		{
			base.OnDisable(trigger);
			m_Button.ForgetPerform(OnInput);
		}

		protected internal override void OnDestroy(Trigger trigger)
		{
			base.OnDestroy(trigger);
			m_Button.OnDispose();
		}

		protected internal override void OnUpdate(Trigger trigger)
		{
			base.OnUpdate(trigger);
			m_Button.OnUpdate();
		}

		protected void Execute()
		{
			if (m_MinDistance.Match(m_Trigger.transform, new Args(base.Self)))
			{
				m_Trigger.Execute(base.Self);
			}
		}

		protected virtual void OnInput()
		{
		}

		protected internal override void OnDrawGizmosSelected(Trigger trigger)
		{
			base.OnDrawGizmosSelected(trigger);
			m_MinDistance.OnDrawGizmos(trigger.transform, new Args(trigger.gameObject));
		}
	}
}
