using System.Collections.Generic;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Damage;
using Assets.Scripts.Flight.Simulation;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Unique
{
	public class PyramidScript : MonoBehaviour
	{
		public class PyramidEngine : Target
		{
			private bool _isDead;

			public DamageableBody DamageableBody { get; }

			public override bool IsDead => _isDead;

			public ParticleSystem ParticleSystem { get; }

			public override Vector3 Position => DamageableBody.transform.position;

			public PyramidScript Pyramid { get; }

			public override bool SupportsOcclusion => false;

			public override TargetType TargetType => TargetType.Air;

			public override Vector3 Velocity => Vector3.zero;

			public PyramidEngine(PyramidScript pyramid, DamageableBody damageableBody)
				: base(1)
			{
				DamageableBody = damageableBody;
				DamageableBody.DamageReceived += DamageableBody_DamageReceived;
				DamageableBody.DamageThresholdReached += DamageableBody_DamageThresholdReached;
				ParticleSystem = damageableBody.GetComponentInChildren<ParticleSystem>(includeInactive: true);
				Pyramid = pyramid;
				base.Name = "Alien Engine";
			}

			private void DamageableBody_DamageReceived(object sender, DamageEventArgs e)
			{
			}

			private void DamageableBody_DamageThresholdReached(object sender, DamageThresholdEventArgs e)
			{
				ParticleSystem.EmissionModule emission = ParticleSystem.emission;
				emission.rateOverTime = 0f;
				_isDead = true;
				Pyramid.OnEngineDied(this);
			}
		}

		private float _climbHeight;

		private bool _engaged;

		private float _engageTimer = 10f;

		private List<PyramidEngine> _engines = new List<PyramidEngine>();

		private float _speed;

		[SerializeField]
		private GameObject _surprise;

		[SerializeField]
		private PartVolumeScript _triggerVolume;

		protected virtual void Update()
		{
			if (_engaged)
			{
				if (_climbHeight >= 0f)
				{
					int count = _engines.Count;
					if (count > 0)
					{
						_speed += (float)count * Time.deltaTime;
					}
					else
					{
						_speed -= 9.8f * Time.deltaTime;
					}
					float num = _speed * Time.deltaTime;
					_climbHeight += num;
					base.transform.Translate(Vector3.up * num);
					base.transform.Rotate(Vector3.up, _speed * 0.1f * Time.deltaTime);
				}
			}
			else if (Game.Instance.CurrentLevel.IsSandbox)
			{
				if (_triggerVolume.HasAnyParts())
				{
					_engageTimer -= Time.deltaTime;
				}
				else if (_engageTimer < 0f)
				{
					Engage();
				}
			}
		}

		private void Engage()
		{
			if (!(FlightSceneScript.Instance.LocalPlayer?.Aircraft == null))
			{
				DamageableBody[] componentsInChildren = GetComponentsInChildren<DamageableBody>(includeInactive: true);
				foreach (DamageableBody damageableBody in componentsInChildren)
				{
					PyramidEngine pyramidEngine = new PyramidEngine(this, damageableBody);
					_engines.Add(pyramidEngine);
					FlightSceneScript.Instance.TargetRegistry.RegisterTarget(pyramidEngine);
				}
				_engaged = true;
				_surprise.SetActive(value: true);
				FlightSceneScript.Instance.FlightUI.ShowMessage("Something ancient has awoken...");
			}
		}

		private void OnEngineDied(PyramidEngine engine)
		{
			_engines.Remove(engine);
			if (_engines.Count == 0)
			{
				FlightSceneScript.Instance.FlightUI.ShowMessage("You have defeated...whatever that thing was.");
			}
		}
	}
}
