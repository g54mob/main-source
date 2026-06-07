using System.Collections.Generic;
using Assets.Scripts.Audio;
using Assets.Scripts.Multiplayer;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class PartDamageEffects
	{
		public enum DamageEffectType
		{
			Fire = 0,
			FireSmall = 1,
			SmokeLight = 2,
			FuelLeak = 3
		}

		private Queue<PartDamageEffect> _currentEffects;

		private PartDamageEffect _firePrefab;

		private PartDamageEffect _fireSmallPrefab;

		private PartDamageEffect _fuelLeak;

		private PartDamageEffect _lightSmoke;

		private INetworkAircraft _networkAircraft;

		public int MaxNumberOfEffects { get; set; }

		public PartDamageEffects(INetworkAircraft networkAircraft)
		{
			_networkAircraft = networkAircraft;
			_firePrefab = Resources.Load<GameObject>("ParticleEffects/PartDamage/Fire").GetComponent<PartDamageEffect>();
			_fireSmallPrefab = Resources.Load<GameObject>("ParticleEffects/PartDamage/FireSmall").GetComponent<PartDamageEffect>();
			_lightSmoke = Resources.Load<GameObject>("ParticleEffects/PartDamage/LightSmoke").GetComponent<PartDamageEffect>();
			_fuelLeak = Resources.Load<GameObject>("ParticleEffects/PartDamage/FuelLeak").GetComponent<PartDamageEffect>();
			_currentEffects = new Queue<PartDamageEffect>();
			MaxNumberOfEffects = (Game.Instance.Device.IsMobileBuild ? 6 : 12);
		}

		public PartDamageEffect CreateEffect(DamageEffectType effectType, PartScript part, Vector3? position, Vector3? direction = null)
		{
			PartDamageEffect partDamageEffect = null;
			switch (effectType)
			{
			case DamageEffectType.Fire:
				partDamageEffect = CreateEffect(_firePrefab, AudioStore.FireLoopAudio, part, position);
				break;
			case DamageEffectType.FireSmall:
				partDamageEffect = CreateEffect(_fireSmallPrefab, AudioStore.FireLoopAudio, part, position);
				break;
			case DamageEffectType.SmokeLight:
				partDamageEffect = CreateEffect(_lightSmoke, null, part, position);
				break;
			case DamageEffectType.FuelLeak:
				partDamageEffect = CreateEffect(_fuelLeak, null, part, position);
				partDamageEffect.transform.LookAt(direction ?? Vector3.down);
				break;
			}
			INetworkAircraft networkAircraft = _networkAircraft;
			if (networkAircraft != null && networkAircraft.IsOwner)
			{
				Vector3? localPosition = (position.HasValue ? new Vector3?(part.transform.InverseTransformPoint(position.Value)) : ((Vector3?)null));
				Vector3? localDirection = (direction.HasValue ? new Vector3?(part.transform.InverseTransformDirection(direction.Value)) : ((Vector3?)null));
				_networkAircraft.CreateDamageEffect(effectType, part.Part.Id, localPosition, localDirection);
			}
			return partDamageEffect;
		}

		public PartDamageEffect CreateFire(PartScript part, Vector3? position)
		{
			return CreateEffect(DamageEffectType.Fire, part, position);
		}

		public PartDamageEffect CreateFireSmall(PartScript part, Vector3? position)
		{
			return CreateEffect(DamageEffectType.FireSmall, part, position);
		}

		public PartDamageEffect CreateFuelLeak(PartScript part, Vector3? position, Vector3? direction)
		{
			return CreateEffect(DamageEffectType.FuelLeak, part, position, direction);
		}

		public PartDamageEffect CreateLightSmoke(PartScript part, Vector3? position)
		{
			return CreateEffect(DamageEffectType.SmokeLight, part, position);
		}

		public void DestroyAndOrphanEffects(GameObject root)
		{
			List<PartDamageEffect> value;
			using (CollectionPool<List<PartDamageEffect>, PartDamageEffect>.Get(out value))
			{
				root.GetComponentsInChildren(value);
				foreach (PartDamageEffect item in value)
				{
					item.DestroyEffect();
					item.transform.SetParent(null, worldPositionStays: true);
				}
			}
		}

		private PartDamageEffect CreateEffect(PartDamageEffect prefab, AudioFile audioFile, PartScript part, Vector3? position)
		{
			PartDamageEffect partDamageEffect = Object.Instantiate(prefab);
			if (!position.HasValue)
			{
				PartDamageEffectPosition componentInChildren = part.GetComponentInChildren<PartDamageEffectPosition>();
				if (componentInChildren != null)
				{
					position = componentInChildren.transform.position;
				}
			}
			Transform transform = partDamageEffect.transform;
			transform.position = position ?? part.transform.position;
			transform.SetParent(part.transform, worldPositionStays: true);
			transform.localScale = new Vector3(1f, 1f, 1f);
			partDamageEffect.Initialize(part, audioFile);
			_currentEffects.Enqueue(partDamageEffect);
			if (_currentEffects.Count > MaxNumberOfEffects)
			{
				PartDamageEffect partDamageEffect2 = _currentEffects.Dequeue();
				if (partDamageEffect2 != null && !partDamageEffect2.Destroyed)
				{
					partDamageEffect2.DestroyEffect();
				}
			}
			return partDamageEffect;
		}
	}
}
