using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Assets.Scripts.Achievements;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Flight.Damage;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Levels;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Flight.Combat.Bullets
{
	[BurstCompile(CompileSynchronously = true)]
	public class BulletPoolManager : MonoBehaviour
	{
		[BurstCompile(CompileSynchronously = true, DisableSafetyChecks = true)]
		public struct ProcessBulletHitsJob : IJobParallelFor
		{
			public int BulletCount;

			public NativeList<BulletHitInfo>.ParallelWriter BulletHits;

			[NoAlias]
			public NativeArray<RaycastHit> SpherecastHits;

			public void Execute(int index)
			{
				RaycastHit hit = SpherecastHits[index];
				if (hit.colliderInstanceID != 0)
				{
					BulletHitInfo value = new BulletHitInfo
					{
						BulletIndex = index,
						Hit = hit
					};
					BulletHits.AddNoResize(value);
				}
			}
		}

		[BurstCompile(CompileSynchronously = true, DisableSafetyChecks = true)]
		public struct UpdateBulletsJob : IJobParallelFor
		{
			public int BulletCount;

			[NoAlias]
			public NativeArray<Bullet> Bullets;

			public float DeltaTime;

			public NativeList<int>.ParallelWriter DestroyedBulletIndices;

			public QueryParameters QueryParametersDefault;

			public QueryParameters QueryParametersDestroyed;

			public float SeaLevel;

			[NoAlias]
			public NativeArray<SpherecastCommand> SpherecastCommands;

			public float SpherecastRadius;

			public void Execute(int index)
			{
				Bullet value = Bullets[index];
				float3 float5 = value.Position;
				float3 float6 = value.Velocity * DeltaTime;
				value.Position += float6;
				value.Lifetime -= DeltaTime;
				if (value.Lifetime <= 0f || value.Position.y < SeaLevel || math.lengthsq(value.Position) > 1E+10f)
				{
					DestroyedBulletIndices.AddNoResize(index);
					SpherecastCommands[index] = new SpherecastCommand(float5, 0.001f, math.normalize(float6), QueryParametersDestroyed, 0f);
				}
				else
				{
					float radius = SpherecastRadius;
					if (value.IsNew)
					{
						value.IsNew = false;
						radius = 0.001f;
						float6 = value.Position - value.StartPosition;
						float5 = value.StartPosition;
					}
					float num = math.length(float6);
					float3 float7 = float6 / num;
					SpherecastCommands[index] = new SpherecastCommand(float5, radius, float7, QueryParametersDefault, num);
				}
				Bullets[index] = value;
			}
		}

		[BurstCompile(CompileSynchronously = true, DisableSafetyChecks = true)]
		private struct SetupBulletRenderingJob : IJobParallelFor
		{
			[NoAlias]
			[ReadOnly]
			public NativeArray<Bullet> Bullets;

			[NoAlias]
			[WriteOnly]
			[NativeDisableUnsafePtrRestriction]
			public unsafe float4x4* Matrices;

			public float3 Scale;

			public unsafe void Execute(int index)
			{
				Bullet bullet = Bullets[index];
				Matrices[index] = float4x4.TRS(bullet.Position, bullet.Rotation, Scale);
			}
		}

		private static class Profile
		{
			public static readonly ProfilerMarker FloatingOriginChanged = new ProfilerMarker("BulletPoolManager.FloatingOriginChanged");

			public static readonly ProfilerMarker OnBulletHit = new ProfilerMarker("BulletPoolManager.OnBulletHit");

			public static readonly ProfilerMarker OnPostFixedUpdate = new ProfilerMarker("BulletPoolManager.OnPostFixedUpdate");

			public static readonly ProfilerMarker OnPostLateUpdate = new ProfilerMarker("BulletPoolManager.OnPostLateUpdate");

			public static readonly ProfilerMarker<int, int> OnPreFixedUpdate = new ProfilerMarker<int, int>("BulletPoolManager.OnPreFixedUpdate", "Pool Count", "Bullet Count");

			public static readonly ProfilerMarker<int, int> OnPreUpdate = new ProfilerMarker<int, int>("BulletPoolManager.OnPreUpdate", "Pool Count", "Bullet Count");

			public static readonly ProfilerMarker<int> ProcessBulletHits = new ProfilerMarker<int>("BulletPoolManager.OnPostFixedUpdate - Process Bullet Hits", "Bullet Hits");

			public static readonly ProfilerMarker RenderMeshInstanced = new ProfilerMarker("BulletPoolManager.OnPostLateUpdate - Render Mesh Instanced");
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void RepositionAllBullets_00003B71_0024PostfixBurstDelegate([NoAlias] Bullet* bullets, int bulletCount, float3* delta);

		internal static class RepositionAllBullets_00003B71_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RepositionAllBullets_00003B71_0024PostfixBurstDelegate>(RepositionAllBullets).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke([NoAlias] Bullet* bullets, int bulletCount, float3* delta)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<Bullet*, int, float3*, void>)functionPointer)(bullets, bulletCount, delta);
						return;
					}
				}
				RepositionAllBullets_0024BurstManaged(bullets, bulletCount, delta);
			}
		}

		private static BulletPoolManager _instance;

		private int _bulletHitMask;

		private Material _material;

		private Mesh _mesh;

		private List<BulletPoolSet> _poolSets;

		public static BulletPoolManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GameObject("BulletPoolManager").AddComponent<BulletPoolManager>();
				}
				return _instance;
			}
		}

		public int BulletCount
		{
			get
			{
				int num = 0;
				int count = _poolSets.Count;
				for (int i = 0; i < count; i++)
				{
					num += _poolSets[i].BulletCount;
				}
				return num;
			}
		}

		[BurstCompile(CompileSynchronously = true, DisableSafetyChecks = true)]
		[MonoPInvokeCallback(typeof(Assets_002EScripts_002EFlight_002ECombat_002EBullets_002ERepositionAllBullets_00003B71_0024PostfixBurstDelegate))]
		public unsafe static void RepositionAllBullets([NoAlias] Bullet* bullets, int bulletCount, float3* delta)
		{
			RepositionAllBullets_00003B71_0024BurstDirectCall.Invoke(bullets, bulletCount, delta);
		}

		public BulletPool CreatePool(BulletData bulletData)
		{
			BulletPoolSet bulletPoolSet = null;
			foreach (BulletPoolSet poolSet in _poolSets)
			{
				if (poolSet.Color == bulletData.Color && poolSet.Scale == bulletData.Scale)
				{
					bulletPoolSet = poolSet;
					break;
				}
			}
			if (bulletPoolSet == null)
			{
				Material material = UnityEngine.Object.Instantiate(_material);
				Mesh mesh = UnityEngine.Object.Instantiate(_mesh);
				bulletPoolSet = new BulletPoolSet(bulletData.Color, bulletData.Scale, material, mesh);
				_poolSets.Add(bulletPoolSet);
			}
			return new BulletPool(bulletPoolSet, bulletData);
		}

		protected virtual void Awake()
		{
			_poolSets = new List<BulletPoolSet>();
			_mesh = Resources.Load<Mesh>("Flight/Combat/Meshes/Bullet");
			_material = Resources.Load<Material>("Flight/Combat/Materials/BulletMaterial");
			_bulletHitMask = -1 & ~LayerMask.GetMask("WorldSpaceUI");
			GameWorld.Instance.FloatingOriginChanged += FloatingOriginChanged;
		}

		protected virtual void OnDestroy()
		{
			GameWorld.Instance.FloatingOriginChanged -= FloatingOriginChanged;
			foreach (BulletPoolSet poolSet in _poolSets)
			{
				poolSet.Dispose();
			}
			_poolSets.Clear();
		}

		protected virtual void OnDisable()
		{
			GamePlayerLoop.UnregisterPreFixedUpdate(OnPreFixedUpdate);
			GamePlayerLoop.UnregisterPostFixedUpdate(OnPostFixedUpdate);
			GamePlayerLoop.UnregisterPreUpdate(OnPreUpdate);
			GamePlayerLoop.UnregisterPostLateUpdate(OnPostLateUpdate);
		}

		protected virtual void OnEnable()
		{
			GamePlayerLoop.RegisterPreFixedUpdate(OnPreFixedUpdate);
			GamePlayerLoop.RegisterPostFixedUpdate(OnPostFixedUpdate);
			GamePlayerLoop.RegisterPreUpdate(OnPreUpdate);
			GamePlayerLoop.RegisterPostLateUpdate(OnPostLateUpdate);
		}

		private unsafe void FloatingOriginChanged(object sender, FloatingOriginChangedEventArgs e)
		{
			using (Profile.FloatingOriginChanged.Auto())
			{
				Vector3 vector = e.OldFloatingOriginOffset - e.NewFloatingOriginOffset;
				for (int i = 0; i < _poolSets.Count; i++)
				{
					BulletPoolSet bulletPoolSet = _poolSets[i];
					Bullet* unsafeBufferPointerWithoutChecks = (Bullet*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(bulletPoolSet.Bullets);
					RepositionAllBullets(unsafeBufferPointerWithoutChecks, bulletPoolSet.BulletCount, (float3*)(&vector));
				}
			}
		}

		private bool OnBulletHit(in Bullet bullet, Collider collider, Vector3 hitPosition, Vector3 hitNormal)
		{
			using (Profile.OnBulletHit.Auto())
			{
				bool flag = true;
				Rigidbody rigidbody = null;
				BulletData bulletData = (BulletData)GCHandle.FromIntPtr(bullet.BulletData).Target;
				PartScript componentInParent = collider.GetComponentInParent<PartScript>();
				if (componentInParent != null)
				{
					if (bulletData.DisableOwnerCollisions && bulletData.Owner == componentInParent.Aircraft)
					{
						flag = false;
					}
					else
					{
						if (!bulletData.RemoteBullet && !FlightSceneScript.IsPeacefulMode)
						{
							OnBulletHitPart(componentInParent, bulletData, collider, hitPosition, hitNormal);
						}
						AudioFile bulletHitPartAudio = AudioStore.BulletHitPartAudio;
						float pitch = UnityEngine.Random.Range(0.75f, 1.25f);
						AudioManager.PlaySound(bulletHitPartAudio, componentInParent.transform.position, bulletHitPartAudio.DefaultVolume, 0f, pitch);
						rigidbody = componentInParent.Body.RigidBody.PhysxRigidBody;
					}
				}
				else
				{
					IDamageableObject componentInParent2 = collider.GetComponentInParent<IDamageableObject>();
					if (componentInParent2 != null)
					{
						if (!bulletData.RemoteBullet && !FlightSceneScript.IsPeacefulMode)
						{
							componentInParent2.OnStandardBulletHit(bulletData.Damage, bulletData.Owner?.NetworkAircraft.PlayerId, hitPosition, hitNormal);
						}
						rigidbody = componentInParent2.RigidBody;
					}
					else
					{
						IBulletImpact componentInParent3 = collider.GetComponentInParent<IBulletImpact>();
						if (componentInParent3 != null)
						{
							flag = componentInParent3.OnBulletImpact(in bullet, bulletData);
							if (flag)
							{
								rigidbody = GetComponentInParent<Rigidbody>();
							}
						}
						else
						{
							rigidbody = GetComponentInParent<Rigidbody>();
						}
					}
				}
				if (flag)
				{
					if (rigidbody != null && !FlightSceneScript.IsPeacefulMode)
					{
						rigidbody.AddForceAtPosition(bulletData.ImpactForce * -hitNormal, hitPosition, ForceMode.Impulse);
					}
					Transform obj = LevelBase.CurrentLevel.BulletHitEffectPool.Create();
					obj.gameObject.SetActive(value: true);
					obj.position = hitPosition;
				}
				return flag;
			}
		}

		private void OnBulletHitPart(PartScript part, BulletData bulletData, Collider partCollider, Vector3 hitPosition, Vector3 hitNormal)
		{
			AircraftScript aircraft = part.Aircraft;
			AircraftScript owner = bulletData.Owner;
			if (owner == aircraft)
			{
				AchievementHelper.OnSelfInflictedGunshot(aircraft);
			}
			else if (owner != null)
			{
				AchievementHelper.OnAircraftAttacked(aircraft, owner);
			}
			if (part.Aircraft.RemoteAircraft)
			{
				part.Aircraft.NetworkAircraft.DamagePart(bulletData.Owner?.NetworkAircraft?.PlayerId, part, bulletData.Damage, hitPosition, hitNormal);
			}
			else
			{
				part.OnDamaged(null, bulletData.Damage, hitPosition, hitNormal);
			}
		}

		private void OnPostFixedUpdate()
		{
			using (Profile.OnPostFixedUpdate.Auto())
			{
				for (int i = 0; i < _poolSets.Count; i++)
				{
					BulletPoolSet bulletPoolSet = _poolSets[i];
					int currentJobBulletCount = bulletPoolSet.CurrentJobBulletCount;
					if (currentJobBulletCount != 0)
					{
						bulletPoolSet.CurrentJobHandle.Complete();
						bulletPoolSet.CurrentJobHandle = default(JobHandle);
						NativeArray<Bullet> subArray = bulletPoolSet.Bullets.GetSubArray(0, currentJobBulletCount);
						NativeList<int> destroyedBulletIndices = bulletPoolSet.DestroyedBulletIndices;
						NativeList<BulletHitInfo> bulletHits = bulletPoolSet.BulletHits;
						if (bulletHits.Length > 0)
						{
							ProcessBulletHits(bulletHits, subArray, destroyedBulletIndices);
						}
						if (destroyedBulletIndices.Length > 0)
						{
							bulletPoolSet.RemoveBullets(destroyedBulletIndices);
						}
					}
				}
			}
		}

		private void OnPostLateUpdate()
		{
			using (Profile.OnPostLateUpdate.Auto())
			{
				RenderParams rparams = new RenderParams
				{
					layer = 0,
					renderingLayerMask = RenderingLayerMask.defaultRenderingLayerMask,
					receiveShadows = false,
					reflectionProbeUsage = ReflectionProbeUsage.Off,
					shadowCastingMode = ShadowCastingMode.Off,
					instanceID = GetInstanceID()
				};
				for (int i = 0; i < _poolSets.Count; i++)
				{
					BulletPoolSet bulletPoolSet = _poolSets[i];
					int currentJobBulletCount = bulletPoolSet.CurrentJobBulletCount;
					if (currentJobBulletCount == 0)
					{
						continue;
					}
					bulletPoolSet.CurrentJobHandle.Complete();
					bulletPoolSet.CurrentJobHandle = default(JobHandle);
					rparams.material = bulletPoolSet.Material;
					NativeArray<Matrix4x4> subArray = bulletPoolSet.BulletMatrices.GetSubArray(0, currentJobBulletCount);
					int num = (currentJobBulletCount + 511 - 1) / 511;
					for (int j = 0; j < num; j++)
					{
						using (Profile.RenderMeshInstanced.Auto())
						{
							int num2 = j * 511;
							int instanceCount = Math.Min(511, currentJobBulletCount - num2);
							Graphics.RenderMeshInstanced(rparams, bulletPoolSet.Mesh, 0, subArray, instanceCount, num2);
						}
					}
				}
			}
		}

		private void OnPreFixedUpdate()
		{
			for (int i = 0; i < _poolSets.Count; i++)
			{
				BulletPoolSet bulletPoolSet = _poolSets[i];
				bulletPoolSet.AddPendingBullets();
				int num = (bulletPoolSet.CurrentJobBulletCount = bulletPoolSet.BulletCount);
				if (num != 0)
				{
					NativeArray<Bullet> subArray = bulletPoolSet.Bullets.GetSubArray(0, num);
					NativeArray<SpherecastCommand> subArray2 = bulletPoolSet.SpherecastCommands.GetSubArray(0, num);
					NativeArray<RaycastHit> subArray3 = bulletPoolSet.SpherecastHits.GetSubArray(0, num);
					NativeList<int> destroyedBulletIndices = bulletPoolSet.DestroyedBulletIndices;
					NativeList<BulletHitInfo> bulletHits = bulletPoolSet.BulletHits;
					destroyedBulletIndices.Clear();
					bulletHits.Clear();
					QueryParameters queryParametersDefault = new QueryParameters(_bulletHitMask, hitMultipleFaces: false, QueryTriggerInteraction.Ignore);
					QueryParameters queryParametersDestroyed = new QueryParameters(0, hitMultipleFaces: false, QueryTriggerInteraction.Ignore);
					UpdateBulletsJob jobData = new UpdateBulletsJob
					{
						DeltaTime = Time.fixedDeltaTime,
						SeaLevel = GameWorld.Instance.FloatingOriginSeaLevel.GetValueOrDefault(),
						SpherecastRadius = 0.25f * math.max(bulletPoolSet.Scale.x, bulletPoolSet.Scale.y),
						QueryParametersDefault = queryParametersDefault,
						QueryParametersDestroyed = queryParametersDestroyed,
						BulletCount = num,
						Bullets = subArray,
						SpherecastCommands = subArray2,
						DestroyedBulletIndices = destroyedBulletIndices.AsParallelWriter()
					};
					ProcessBulletHitsJob jobData2 = new ProcessBulletHitsJob
					{
						BulletCount = num,
						SpherecastHits = subArray3,
						BulletHits = bulletHits.AsParallelWriter()
					};
					JobHandle dependsOn = IJobParallelForExtensions.Schedule(jobData, num, 32);
					JobHandle dependsOn2 = SpherecastCommand.ScheduleBatch(subArray2, subArray3, 32, dependsOn);
					bulletPoolSet.CurrentJobHandle = IJobParallelForExtensions.Schedule(jobData2, num, 32, dependsOn2);
				}
			}
		}

		private unsafe void OnPreUpdate()
		{
			for (int num = _poolSets.Count - 1; num >= 0; num--)
			{
				BulletPoolSet bulletPoolSet = _poolSets[num];
				bulletPoolSet.AddPendingBullets();
				int num2 = (bulletPoolSet.CurrentJobBulletCount = bulletPoolSet.BulletCount);
				if (num2 == 0)
				{
					if (bulletPoolSet.Pools.Count == 0 && Time.realtimeSinceStartup >= bulletPoolSet.DisposalTime)
					{
						bulletPoolSet.Dispose();
						_poolSets.RemoveAt(num);
					}
				}
				else
				{
					Vector3 scale = bulletPoolSet.Scale;
					float4x4* unsafeBufferPointerWithoutChecks = (float4x4*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(bulletPoolSet.BulletMatrices.GetSubArray(0, num2));
					SetupBulletRenderingJob jobData = new SetupBulletRenderingJob
					{
						Bullets = bulletPoolSet.Bullets.GetSubArray(0, num2),
						Scale = scale,
						Matrices = unsafeBufferPointerWithoutChecks
					};
					bulletPoolSet.CurrentJobHandle = IJobParallelForExtensions.Schedule(jobData, num2, 32);
				}
			}
		}

		private void ProcessBulletHits(NativeList<BulletHitInfo> bulletHits, NativeArray<Bullet> bullets, NativeList<int> destroyedBulletIndices)
		{
			int length = bulletHits.Length;
			using (Profile.ProcessBulletHits.Auto(length))
			{
				for (int i = 0; i < length; i++)
				{
					Bullet bullet = bullets[bulletHits[i].BulletIndex];
					RaycastHit hit = bulletHits[i].Hit;
					if (OnBulletHit(in bullet, hit.collider, hit.point, hit.normal))
					{
						destroyedBulletIndices.AddNoResize(bulletHits[i].BulletIndex);
					}
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile(CompileSynchronously = true, DisableSafetyChecks = true)]
		internal unsafe static void RepositionAllBullets_0024BurstManaged([NoAlias] Bullet* bullets, int bulletCount, float3* delta)
		{
			float3 float5 = *delta;
			for (int i = 0; i < bulletCount; i++)
			{
				bullets[i].Position += float5;
			}
		}
	}
}
