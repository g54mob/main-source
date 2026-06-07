using Assets.Scripts.Craft.Parts.Modifiers.Powertrain;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public abstract class EngineScript : PartModifierScript, IVariableOutput, ICraftEngine, IDesignerThrust
	{
		protected bool _applyEngineTorque;

		protected PartScript _part;

		private InputControllerScript _throttleInput;

		public Transform CenterOfThrust { get; set; }

		Vector3 IDesignerThrust.DesignerCenterOfThrust => CenterOfThrust.position;

		float IDesignerThrust.DesignerThrust => Engine.Power;

		public virtual DesignerThrustTypes DesignerThrustType
		{
			get
			{
				if (!Engine.DuctedThrust)
				{
					return DesignerThrustTypes.LegacyEngine;
				}
				return DesignerThrustTypes.None;
			}
		}

		public EngineData Engine { get; set; }

		public bool EngineDestroyed { get; set; }

		public float EngineThrottle { get; set; }

		public float EngineThrottleFunctionalHealth { get; set; }

		public virtual CraftEngineType EngineType => CraftEngineType.InternalCombustion;

		public abstract float IRSignature { get; }

		public virtual IPowertrain Powertrain => null;

		public InputControllerScript ThrottleInput
		{
			get
			{
				return _throttleInput;
			}
			protected set
			{
				_throttleInput = value;
			}
		}

		protected Rigidbody Body => base.PartScript.Body.RigidBody.PhysxRigidBody;

		[VariableOutput("Thrust")]
		public virtual float Thrust { get; set; }

		public void AddForceAndTorque(Vector3 force, Vector3 position)
		{
			Body.AddForceAtPosition(force, position);
			Thrust = force.magnitude / 0.01f;
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			switch (level)
			{
			case PartDamageLevel.Light:
				return;
			case PartDamageLevel.Moderate:
				base.PartScript.Aircraft.DamageEffects.CreateFire(base.PartScript, null);
				break;
			}
			if (!EngineDestroyed)
			{
				if (Random.value < 0.3f * (float)level)
				{
					EngineDestroyed = true;
					OnEngineDestroyed();
				}
				else
				{
					OnEngineDamaged();
				}
			}
		}

		public virtual void OnModifierInitialized()
		{
			_part = base.transform.GetComponentInParent<PartScript>(includeInactive: true);
			EngineThrottleFunctionalHealth = 1f;
		}

		protected virtual void Awake()
		{
		}

		protected virtual void OnEngineDamaged()
		{
			Engine.FuelConsumptionRate *= 10f;
			EngineThrottleFunctionalHealth *= 0.25f;
		}

		protected virtual void OnEngineDestroyed()
		{
		}

		void IVariableOutput.UpdateOutputs()
		{
		}
	}
}
