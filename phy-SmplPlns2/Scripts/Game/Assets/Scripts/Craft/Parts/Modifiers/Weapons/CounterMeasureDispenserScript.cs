using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Levels;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class CounterMeasureDispenserScript : PartModifierScript, IVariableOutput
	{
		private GameObject _countermeasurePrefab;

		private float _failureChance;

		private bool _launchInputLastFrame;

		private CounterMeasureDispenserData _modifier;

		private float _timeSinceLastDispension = 1f;

		public int Ammo
		{
			get
			{
				return _modifier.Ammo;
			}
			set
			{
				_modifier.Ammo = value;
			}
		}

		public bool IsArmed
		{
			get
			{
				if (_modifier.ActivationGroup != 0)
				{
					return base.Controls.GetActivationState(_modifier.ActivationGroup);
				}
				return true;
			}
		}

		[VariableOutput("Ammo")]
		private float ammo => Ammo;

		public void Dispense()
		{
			if (!(Random.value < _failureChance))
			{
				Transform transform = Object.Instantiate(_countermeasurePrefab, FlightSceneScript.Instance.transform).transform;
				transform.position = base.transform.position;
				transform.LookAt(base.transform.position - base.transform.forward);
				Vector3 velocity = base.PartScript.Body.RigidBody.velocity;
				Vector3? angularVelocity = null;
				float drag = 1f;
				float gravityMultiplier = 0f;
				SignatureType signatureType = SignatureType.None;
				bool audioLoops = false;
				AudioSource component = GetComponent<AudioSource>();
				switch (_modifier.CountermeasureType)
				{
				case CounterMeasureType.Chaff:
					signatureType = SignatureType.Radar;
					transform.position += base.transform.up * 5f;
					drag = 1.5f;
					component.Play();
					break;
				case CounterMeasureType.Flares:
					signatureType = SignatureType.Infrared;
					audioLoops = true;
					transform.position += base.transform.up * (transform.transform.localScale.y + 0.1f);
					transform.up = base.transform.up;
					velocity += base.transform.up * _modifier.LaunchForce;
					velocity += Random.insideUnitSphere * 2f;
					angularVelocity = new Vector3(Random.Range(-5000, 5000), Random.Range(-5000, 5000), Random.Range(-5000, 5000));
					gravityMultiplier = 0.3f;
					drag = 0.5f;
					component.volume = _modifier.LaunchForce / 100f;
					component.Play();
					break;
				}
				transform.GetComponent<CounterMeasureScript>().SetupAndBegin(signatureType, base.PartScript.Aircraft, _modifier.BreakLockChance, _modifier.EvadeLockChance, velocity, drag, angularVelocity, gravityMultiplier, audioLoops);
			}
		}

		public void Initialize(CounterMeasureDispenserData dispenser)
		{
			_modifier = dispenser;
			string text = "Flight/Combat/CounterMeasures/";
			switch (_modifier.CountermeasureType)
			{
			case CounterMeasureType.Chaff:
				text += "ChaffBurst";
				break;
			case CounterMeasureType.Flares:
				text += "Flares";
				break;
			}
			_countermeasurePrefab = Resources.Load<GameObject>(text);
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level > PartDamageLevel.Light)
			{
				_failureChance += (float)level / (Random.value * 10f + (float)level);
			}
		}

		public void UpdateOutputs()
		{
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightUnpaused);
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (LevelBase.CurrentLevel.DisableCountermeasures)
			{
				return;
			}
			_timeSinceLastDispension += frame.DeltaTime;
			if (IsArmed)
			{
				bool launchCountermeasures = frame.Craft.Controls.LaunchCountermeasures;
				if (((launchCountermeasures && _timeSinceLastDispension >= _modifier.AutoDispenseDelay) || (launchCountermeasures && !_launchInputLastFrame)) && Ammo > 0)
				{
					_timeSinceLastDispension = 0f;
					Dispense();
					Ammo--;
				}
				_launchInputLastFrame = launchCountermeasures;
			}
		}
	}
}
