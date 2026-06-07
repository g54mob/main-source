using System.Collections.Generic;
using System.Text;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public abstract class ActorSkill : AiValueWithModifiers
	{
		private static readonly float[] _maxStars;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public new Actor Owner
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public int Tier { get; internal set; }

		public float EffectiveStarLevel => 0f;

		public float ProgressAcrossAllTiersF => 0f;

		public float ProgressWithinTierF => 0f;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void Actor_AttributeChanged(object sender, Actor.ActorEventArgs<ActorAttribute> e)
		{
		}

		protected ActorSkill()
		{
		}

		protected ActorSkill(Actor owner)
		{
		}

		public ActorSkill(Actor owner, string name, string displayNameKey, string descriptionKey)
		{
		}

		public override void FirstInit()
		{
		}

		private void UpdateBaseValue()
		{
		}

		public virtual float GetModifierForTargetTier(int tier)
		{
			return 0f;
		}

		private IEnumerable<ActorAttributeDependencyAttribute> GetAttributeDependencies()
		{
			return null;
		}

		public override string GetCurrentValueLabelKey()
		{
			return null;
		}

		protected override void AppendBaseValueDescription(StringBuilder sb)
		{
		}
	}
}
