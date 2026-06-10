using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Goap;
using UnityEngine;

namespace NSMedieval.Controllers
{
	public class AnimationController : MonoSingleton<AnimationController>
	{
		public delegate void AgentHandler(IGoapAgentOwner agentOwner, string trigger);

		public delegate void AgentOnlyHandler(IGoapAgentOwner agentOwner);

		public delegate void ParameterIntHandler(IGoapAgentOwner agentOwner, string parameterName, int value);

		public delegate void ParameterFloatHandler(IGoapAgentOwner agentOwner, string parameterName, float value);

		public delegate void ParameterBoolHandler(IGoapAgentOwner agentOwner, string parameterName, bool value);

		private const string ForceQuitTriggerName = "ForceQuit";

		public event AgentHandler TriggerAnimationEvent;

		public event AgentHandler FailAnimationEvent;

		public event AgentOnlyHandler ResetTriggersAnimationEvent;

		public event AgentHandler ForeQuitAnimationEvent;

		public event ParameterIntHandler ParameterIntChangeEvent;

		public event ParameterFloatHandler ParameterFloatChangeEvent;

		public event ParameterBoolHandler ParameterBoolChangeEvent;

		public event AgentHandler OnAnimationGoapEvent;

		public event AgentOnlyHandler AnimationEndedEvent;

		public void TriggerAgentAnimation(IGoapAgentOwner agentOwner, string trigger)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\AnimationController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Trigger Agent Animation: ");
				messageBuilder.AppendFormatted(trigger);
			}
			Log.Trace(messageBuilder);
			if (agentOwner != null)
			{
				this.TriggerAnimationEvent?.Invoke(agentOwner, trigger);
			}
		}

		public void ResetTriggers(IGoapAgentOwner agentOwner)
		{
			if (agentOwner != null)
			{
				this.ResetTriggersAnimationEvent?.Invoke(agentOwner);
			}
		}

		public void ForceQuitAgentAnimation(IGoapAgentOwner agentOwner)
		{
			if (agentOwner != null)
			{
				this.ForeQuitAnimationEvent?.Invoke(agentOwner, "ForceQuit");
			}
		}

		public void FailAgentAnimation(IGoapAgentOwner agentOwner, string trigger)
		{
			this.FailAnimationEvent?.Invoke(agentOwner, trigger);
		}

		public void OnAnimationEnded(IGoapAgentOwner agentOwner)
		{
			if (agentOwner != null)
			{
				this.AnimationEndedEvent?.Invoke(agentOwner);
			}
		}

		public void OnAnimationGoapEventFired(IGoapAgentOwner agentOwner, string eventName)
		{
			this.OnAnimationGoapEvent?.Invoke(agentOwner, eventName);
		}

		public void GenerateNewAnimationRnd(IGoapAgentOwner agentOwner)
		{
			SetAnimatorParameter(agentOwner, "GenericRnd", Random.value);
		}

		public void SetAnimatorParameter(IGoapAgentOwner agentOwner, string parameterName, int value)
		{
			this.ParameterIntChangeEvent?.Invoke(agentOwner, parameterName, value);
		}

		public void SetAnimatorParameter(IGoapAgentOwner agentOwner, string parameterName, float value)
		{
			this.ParameterFloatChangeEvent?.Invoke(agentOwner, parameterName, value);
		}

		public void SetAnimatorParameter(IGoapAgentOwner agentOwner, string parameterName, bool value)
		{
			this.ParameterBoolChangeEvent?.Invoke(agentOwner, parameterName, value);
		}
	}
}
