using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public abstract class ScenarioTriggerableBase
	{
		[SerializeReference]
		[InstantiateSerializeReference]
		private IScenarioTriggerableCondition[] _conditions;

		[SerializeField]
		private bool _isRetriggerable;

		public virtual bool WasTriggered { get; private set; }

		protected bool IsRetriggerable => _isRetriggerable;

		public void Initialize()
		{
			WasTriggered = !_isRetriggerable && (WasTriggered || GetWasTriggered());
		}

		public bool ConditionsAreMet()
		{
			IScenarioTriggerableCondition[] conditions = _conditions;
			for (int i = 0; i < conditions.Length; i++)
			{
				if (!conditions[i].IsMet())
				{
					return false;
				}
			}
			return true;
		}

		public bool TryTrigger(AgentDescriptor actorDescriptor = null)
		{
			if (!WasTriggered && ConditionsAreMet() && Trigger(actorDescriptor))
			{
				WasTriggered = !_isRetriggerable;
				return true;
			}
			return false;
		}

		protected abstract bool Trigger(AgentDescriptor actorDescriptor);

		protected virtual bool GetWasTriggered()
		{
			return false;
		}

		protected void Reset()
		{
			WasTriggered = false;
		}

		internal virtual void RestoreWasTriggered()
		{
			WasTriggered = !_isRetriggerable;
		}
	}
}
