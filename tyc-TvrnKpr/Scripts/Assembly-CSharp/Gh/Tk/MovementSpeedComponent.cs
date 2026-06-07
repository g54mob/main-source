using System.Collections.Generic;

namespace Gh.Tk
{
	public class MovementSpeedComponent : AiValueWithModifiers
	{
		private static Dictionary<string, float> _raceBaseMovementSpeeds;

		private float movementSpeedOverride;

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
		public float MovementSpeedOverride
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MovementSpeedF => 0f;

		private static float GetFallbackSpeedForRace(string race)
		{
			return 0f;
		}

		protected MovementSpeedComponent()
		{
		}

		public MovementSpeedComponent(Actor owner)
		{
		}

		public override void Init()
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}

		public override void Update()
		{
		}

		protected override void OnEffectiveValueChanged()
		{
		}

		public override string GetCurrentValueLabelKey()
		{
			return null;
		}
	}
}
