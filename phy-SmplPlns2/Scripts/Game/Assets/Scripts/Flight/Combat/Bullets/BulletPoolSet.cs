using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat.Bullets
{
	public class BulletPoolSet : IDisposable
	{
		private static class Profile
		{
			public static readonly ProfilerMarker<int, int> AddPendingBullets = new ProfilerMarker<int, int>("BulletPoolSet.AddPendingBullets", "Previous Bullet Count", "Bullet Added");
		}

		private bool _disposed;

		private NativeList<Bullet> _pendingBulletAdds;

		public int BulletCount { get; private set; }

		public NativeList<BulletHitInfo> BulletHits { get; private set; }

		public NativeArray<Matrix4x4> BulletMatrices { get; private set; }

		public NativeArray<Bullet> Bullets { get; private set; }

		public Color Color { get; private set; }

		public int CurrentJobBulletCount { get; set; }

		public JobHandle CurrentJobHandle { get; set; }

		public NativeList<int> DestroyedBulletIndices { get; private set; }

		public float DisposalTime { get; private set; }

		public Material Material { get; private set; }

		public Mesh Mesh { get; private set; }

		public List<BulletPool> Pools { get; private set; }

		public Vector3 Scale { get; private set; }

		public NativeArray<SpherecastCommand> SpherecastCommands { get; private set; }

		public NativeArray<RaycastHit> SpherecastHits { get; private set; }

		public BulletPoolSet(Color color, Vector3 scale, Material material, Mesh mesh)
		{
			Pools = new List<BulletPool>();
			Color = color;
			Scale = scale;
			Material = material;
			Mesh = mesh;
			color.a = 1f;
			Color[] colors = mesh.colors;
			for (int i = 0; i < colors.Length; i++)
			{
				colors[i] *= color;
			}
			mesh.colors = colors;
			Bullets = new NativeArray<Bullet>(64, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			SpherecastCommands = new NativeArray<SpherecastCommand>(64, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			SpherecastHits = new NativeArray<RaycastHit>(64, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			BulletHits = new NativeList<BulletHitInfo>(64, Allocator.Persistent);
			DestroyedBulletIndices = new NativeList<int>(64, Allocator.Persistent);
			BulletMatrices = new NativeArray<Matrix4x4>(64, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			_pendingBulletAdds = new NativeList<Bullet>(64, Allocator.Persistent);
		}

		public void AddBullet(float3 position, float3 velocity, float3 direction, BulletData bulletData, IntPtr bulletDataPtr)
		{
			Bullet value = new Bullet
			{
				BulletData = bulletDataPtr,
				IsNew = true,
				Lifetime = bulletData.Lifetime,
				StartPosition = position + direction * 0.5f,
				Position = position + direction * (10f * bulletData.Scale.z),
				Velocity = velocity,
				Rotation = quaternion.LookRotation(direction, new float3(0f, 1f, 0f))
			};
			_pendingBulletAdds.Add(in value);
		}

		public void AddPendingBullets()
		{
			if (_pendingBulletAdds.Length == 0)
			{
				return;
			}
			using (Profile.AddPendingBullets.Auto(BulletCount, _pendingBulletAdds.Length))
			{
				while (Bullets.Length < BulletCount + _pendingBulletAdds.Length)
				{
					ResizeCollections(Bullets.Length * 2);
				}
				Bullets.Slice(BulletCount, _pendingBulletAdds.Length).CopyFrom(_pendingBulletAdds.AsArray());
				BulletCount += _pendingBulletAdds.Length;
				_pendingBulletAdds.Clear();
			}
		}

		public void AddPool(BulletPool pool)
		{
			Pools.Add(pool);
		}

		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
				UnityEngine.Object.Destroy(Mesh);
				UnityEngine.Object.Destroy(Material);
				CurrentJobHandle.Complete();
				CurrentJobHandle = default(JobHandle);
				Bullets.Dispose();
				SpherecastCommands.Dispose();
				SpherecastHits.Dispose();
				BulletHits.Dispose();
				DestroyedBulletIndices.Dispose();
				BulletMatrices.Dispose();
				_pendingBulletAdds.Dispose();
			}
		}

		public unsafe void RemoveBullet(int index)
		{
			if (index < 0 || index >= BulletCount)
			{
				throw new ArgumentOutOfRangeException("index", "Index is out of range of active bullets.");
			}
			Bullet* unsafeBufferPointerWithoutChecks = (Bullet*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(Bullets);
			unsafeBufferPointerWithoutChecks[index] = unsafeBufferPointerWithoutChecks[BulletCount - 1];
			BulletCount--;
		}

		public unsafe void RemoveBullets(NativeList<int> indices)
		{
			Bullet* unsafeBufferPointerWithoutChecks = (Bullet*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(Bullets);
			indices.Sort();
			for (int num = indices.Length - 1; num >= 0; num--)
			{
				unsafeBufferPointerWithoutChecks[indices[num]] = unsafeBufferPointerWithoutChecks[BulletCount - 1];
				BulletCount--;
			}
		}

		public void RemovePool(BulletPool pool)
		{
			Pools.Remove(pool);
			if (Pools.Count == 0)
			{
				DisposalTime = Time.realtimeSinceStartup + 20f;
			}
		}

		private static NativeArray<T> ResizeNativeArray<T>(NativeArray<T> array, int newSize) where T : struct
		{
			NativeArray<T> nativeArray = new NativeArray<T>(newSize, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			NativeArray<T>.Copy(array, nativeArray, math.min(array.Length, nativeArray.Length));
			array.Dispose();
			return nativeArray;
		}

		private static NativeList<T> ResizeNativeList<T>(NativeList<T> list, int newSize) where T : unmanaged
		{
			NativeList<T> result = new NativeList<T>(newSize, Allocator.Persistent);
			result.CopyFrom(in list);
			list.Dispose();
			return result;
		}

		private void ResizeCollections(int size)
		{
			Bullets = ResizeNativeArray(Bullets, size);
			SpherecastCommands = ResizeNativeArray(SpherecastCommands, size);
			SpherecastHits = ResizeNativeArray(SpherecastHits, size);
			BulletHits = ResizeNativeList(BulletHits, size);
			DestroyedBulletIndices = ResizeNativeList(DestroyedBulletIndices, size);
			BulletMatrices = ResizeNativeArray(BulletMatrices, size);
		}
	}
}
