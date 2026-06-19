using System;
using BehaviorDesigner.Runtime;

namespace TH20
{
	public abstract class MetagameCutsceneInstance
	{
		[NonSerialized]
		[DontSave]
		protected MetagameMap MetagameMap;

		[DontSave]
		private bool _wasSkipped;

		private readonly MetagameCutsceneDefinition _definition;

		public ExternalBehavior CutsceneBehaviour => _definition.CutsceneBehaviour;

		public bool WasSkipped => _wasSkipped;

		protected MetagameCutsceneInstance(MetagameMap metagameMap, MetagameCutsceneDefinition definition)
		{
			MetagameMap = metagameMap;
			_definition = definition;
		}

		public virtual void RestoreFromSave(MetagameMap metagameMap)
		{
			MetagameMap = metagameMap;
		}

		public virtual void OnCutsceneStart()
		{
		}

		public virtual void OnCutsceneSequenceStart(MetagameBehaviorTree behaviour)
		{
		}

		public virtual void OnCutsceneSequenceEnd()
		{
		}

		public virtual void OnSkip()
		{
			_wasSkipped = true;
		}
	}
}
