using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class TorpedoScript : PartModifierScript
	{
		private const float FuelTime = 120f;

		private BombScript _bombScript;

		private float _fuelSpent;

		private bool _hasTouchedWater;

		private ParticleSystem _particleSystem;

		private Transform _propBlades;

		public void Initialize()
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				_bombScript = GetComponent<BombScript>();
				_particleSystem = base.transform.Find("ParticleSystem").GetComponent<ParticleSystem>();
				_propBlades = base.transform.Find("Mesh/Propeller");
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightDefault);
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightDefault);
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (_bombScript.Fired && !(_fuelSpent >= 120f) && base.PartScript.EstimateOfUnderwaterPercent > 0.1f)
			{
				_fuelSpent += Time.fixedDeltaTime;
				if (!_hasTouchedWater)
				{
					_hasTouchedWater = true;
					OnTouchedWater();
				}
				if (!_particleSystem.gameObject.activeInHierarchy)
				{
					_particleSystem.gameObject.SetActive(value: true);
				}
				if (base.PartScript.EstimateOfUnderwaterPercent > 1f && !_particleSystem.isPaused)
				{
					_particleSystem.Pause();
				}
				else if (_particleSystem.isPaused)
				{
					_particleSystem.Play();
				}
				IRigidBody rigidBody = base.PartScript.Body.RigidBody;
				float value = GameWorld.Instance.FloatingOriginSeaLevel.Value;
				Quaternion to = Quaternion.Euler(new Vector3(0f, rigidBody.rotation.eulerAngles.y, 0f));
				rigidBody.MoveRotation(Quaternion.RotateTowards(rigidBody.rotation, to, 100f * Time.fixedDeltaTime));
				rigidBody.AddForce(-Physics.gravity * rigidBody.mass);
				rigidBody.AddForce(Vector3.up * ((0f - (base.transform.position.y - (value + 0.15f) + rigidBody.velocity.y)) * (base.PartScript.EstimateOfUnderwaterPercent + 10f)));
				Vector3 vector = base.transform.InverseTransformDirection(rigidBody.velocity);
				if (vector.z < 45f)
				{
					rigidBody.AddForce(base.transform.forward * 20f);
				}
				else
				{
					rigidBody.AddForce(base.transform.forward * (0f - (25f + vector.z)));
				}
			}
		}

		private void OnTouchedWater()
		{
			_bombScript.ScaleBlastForce(1.5f);
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (_bombScript.Fired && !(_fuelSpent >= 120f))
			{
				_propBlades.Rotate(new Vector3(0f, 0f, -1800f * frame.DeltaTime), Space.Self);
			}
		}
	}
}
