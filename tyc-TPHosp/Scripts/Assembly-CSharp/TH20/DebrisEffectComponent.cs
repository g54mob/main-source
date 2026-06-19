using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class DebrisEffectComponent : EntityTickComponent
	{
		[Serializable]
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		private class Config
		{
			public float _dropHeight = 2f;

			public float _dropSpeed = 0.1f;

			public float _dropDelay = 2f;

			public GameObject _impactEffect;

			public string _debrisSoundEvent;
		}

		[SerializeField]
		private Config _config;

		private RoomItem _roomItem;

		private float _spawnTime;

		[DontSave]
		private GameObject _impactEffectInstance;

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_spawnTime = GameTime.time;
			_roomItem = GetOwner<RoomItem>();
		}

		public override void LateTick()
		{
			base.LateTick();
			if (_roomItem.FloorPlan is BlueprintFloorPlan)
			{
				Destroy();
			}
			else
			{
				if (_roomItem.Visual == null)
				{
					return;
				}
				if (_config._impactEffect != null && _impactEffectInstance == null)
				{
					_impactEffectInstance = UnityEngine.Object.Instantiate(_config._impactEffect, _roomItem.WorldPosition, Quaternion.identity);
					AudioManager.Instance.Play("CeilingDebris:Earthquake", _impactEffectInstance);
					float num = 0f;
					ParticleSystem[] componentsInChildren = _impactEffectInstance.GetComponentsInChildren<ParticleSystem>();
					foreach (ParticleSystem particleSystem in componentsInChildren)
					{
						if (particleSystem.main.duration > num)
						{
							num = particleSystem.main.duration;
						}
					}
					UnityEngine.Object.Destroy(_impactEffectInstance, num);
				}
				float num2 = GameTime.time - _spawnTime;
				if (num2 < _config._dropDelay)
				{
					_roomItem.Visual.SetActive(active: false);
					return;
				}
				num2 -= _config._dropDelay;
				float num3 = Mathf.Clamp01(num2 * _config._dropSpeed);
				Vector3 worldPosition = _roomItem.Visual.WorldPosition;
				worldPosition.y = _config._dropHeight * Mathf.Cos(num3 * (float)Math.PI * 0.5f);
				if (!_roomItem.Visual.ActiveSelf)
				{
					_roomItem.Visual.SetActive(active: true);
				}
				_roomItem.Visual.WorldPosition = worldPosition;
				if (worldPosition.y <= 0f)
				{
					if (!_config._debrisSoundEvent.IsNullOrEmpty())
					{
						AudioManager.Instance.Play(_config._debrisSoundEvent, _roomItem.Visual.GameObject);
					}
					Destroy();
				}
			}
		}
	}
}
