using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class ActorVariable : QuestVariableBase
	{
		[SerializeField]
		private DialogueContext.ActorType _actorType;

		[SerializeField]
		private AgentProfile _actorProfile;

		public override QuestVariableType Type => QuestVariableType.Actor;

		public DialogueContext.ActorType ActorType => _actorType;

		public ActorVariable()
		{
		}

		private ActorVariable(ActorVariable other)
			: base(other)
		{
			_actorType = other._actorType;
			_actorProfile = other._actorProfile;
		}

		public override object Clone()
		{
			return new ActorVariable(this);
		}

		public override bool Initialize()
		{
			return true;
		}

		public override bool Validate()
		{
			return true;
		}

		protected override T Get<T>()
		{
			AgentProfile actorProfile = _actorProfile;
			if (actorProfile is T)
			{
				return (T)(object)((actorProfile is T) ? actorProfile : null);
			}
			AgentDescriptor descriptor = _actorProfile.GetDescriptor();
			if (descriptor is T)
			{
				return (T)(object)((descriptor is T) ? descriptor : null);
			}
			return default(T);
		}

		public bool TryGetActorDescriptor(DialogueContext.ActorType actorType, out AgentDescriptor actorDescriptor)
		{
			actorDescriptor = ((actorType == _actorType && _actorProfile != null) ? _actorProfile.GetDescriptor() : null);
			return actorDescriptor != null;
		}

		public override bool ConditionsAreMet(QuestProperties questProperties)
		{
			if (_actorProfile == null)
			{
				Debug.LogError($"Actor variable conditions for quest '{questProperties}' are not met, Actor Profile is NULL!");
				return false;
			}
			return true;
		}

		public override bool TryGetPersistentData(out IPersistentData persistentData)
		{
			persistentData = null;
			return false;
		}

		public override bool TryRestorePersistentData(IPersistentData persistentData)
		{
			persistentData = null;
			return false;
		}
	}
}
