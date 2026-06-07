using System;
using System.Runtime.InteropServices;
using DV.Utils;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DV.DopplerEffects
{
	public class Doppler : MonoBehaviour
	{
		public enum UpdateMode
		{
			FixedUpdate = 0,
			LateUpdate = 1
		}

		[Serializable]
		public struct DopplerData : IComponentData
		{
			public float3 oldPos;

			public float3 newPos;

			public float3 velocity;

			public float desiredPitch;

			public float finalPitch;

			public byte spatialBlend;

			public byte skipFrames;
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct DopplerUpdateInFixedUpdateTag : IComponentData
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct DopplerUpdateInLateUpdateTag : IComponentData
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct DopplerPauseUpdate : IComponentData
		{
		}

		public const float DOPPLER_STRENGTH = 1f;

		public const float C = 340f;

		private static CachedArchetype lateUpdateArchetype;

		private static CachedArchetype fixedUpdateArchetype;

		public UpdateMode updateMode = UpdateMode.LateUpdate;

		public bool useSpatialBlend;

		[NonSerialized]
		public float desiredPitch;

		private AudioSource source;

		private DVConvertToEntity entity;

		private bool isEnabled;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void StaticInit()
		{
			CachedArchetype otherArchetype = new CachedArchetype(ComponentType.ReadWrite<Doppler>(), ComponentType.ReadWrite<Transform>(), ComponentType.ReadWrite<DopplerData>(), ComponentType.ReadWrite<Disabled>());
			lateUpdateArchetype = new CachedArchetype(otherArchetype, ComponentType.ReadWrite<DopplerUpdateInLateUpdateTag>());
			fixedUpdateArchetype = new CachedArchetype(otherArchetype, ComponentType.ReadWrite<DopplerUpdateInFixedUpdateTag>());
		}

		private void Awake()
		{
			source = GetComponent<AudioSource>();
			if (!source)
			{
				Debug.LogError("Missing AudioSource component on Doppler. Destroying self.");
				UnityEngine.Object.Destroy(this);
				return;
			}
			source.dopplerLevel = 0f;
			desiredPitch = source.pitch;
			entity = base.gameObject.AddComponent<DVConvertToEntity>();
			entity.DisableAutoEnableDisable = true;
			entity.OnConverted += delegate(EntityManager entityManager, Entity entity)
			{
				if (isEnabled)
				{
					entityManager.RemoveComponent<Disabled>(entity);
				}
				entityManager.AddComponentObject(entity, this);
			};
			entity.OnEnabled += delegate(EntityCommandBuffer ecb, Entity entity)
			{
				float3 float5 = base.transform.position;
				ecb.SetComponent(entity, new DopplerData
				{
					newPos = float5,
					oldPos = float5,
					skipFrames = 1
				});
			};
			entity.Initialize(((updateMode == UpdateMode.LateUpdate) ? lateUpdateArchetype : fixedUpdateArchetype).Archetype);
		}

		public void Enable()
		{
			isEnabled = true;
			if (entity.IsConverted)
			{
				DVConvertToEntity.ConvertSystem.QueueOperation(entity, DVConvertToEntitySystem.Operation.Type.Enable);
			}
		}

		public void Disable()
		{
			isEnabled = false;
			if (entity.IsConverted)
			{
				DVConvertToEntity.ConvertSystem.QueueOperation(entity, DVConvertToEntitySystem.Operation.Type.Disable);
			}
		}

		public void SetDesiredPitch(float pitch)
		{
			desiredPitch = pitch;
		}

		public void ApplyPitch(float pitch)
		{
			source.pitch = pitch;
		}

		public float GetSpatialBlend()
		{
			if (!useSpatialBlend)
			{
				return 1f;
			}
			return source.spatialBlend;
		}

		public void ChangeMode(UpdateMode newMode)
		{
			if (updateMode != newMode)
			{
				updateMode = newMode;
				DopplerChangeUpdateTypeSystem.ChangeUpdateModeList.Add((entity, newMode));
			}
		}
	}
}
