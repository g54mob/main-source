using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace LeTai.Asset.TranslucentImage
{
	public class VPMatrixCache : IDisposable
	{
		public readonly struct Index
		{
			public static readonly Index INVALID = new Index(-1);

			internal readonly int index;

			public Index(int index)
			{
				this.index = index;
			}

			public bool IsValid()
			{
				return index >= 0;
			}
		}

		private readonly List<Camera> cameras = new List<Camera>(2);

		public NativeList<Matrix4x4> VpMatrices { get; } = new NativeList<Matrix4x4>(2, Allocator.Persistent);

		public Index IndexOf(Camera camera)
		{
			return new Index(cameras.IndexOf(camera));
		}

		public Index Add(Camera camera)
		{
			Matrix4x4 vpMatrix = camera.projectionMatrix * camera.worldToCameraMatrix;
			return Add(camera, vpMatrix);
		}

		public Index Add(Camera camera, Matrix4x4 vpMatrix)
		{
			int count = cameras.Count;
			cameras.Add(camera);
			VpMatrices.Add(in vpMatrix);
			return new Index(count);
		}

		public void Clear()
		{
			cameras.Clear();
			VpMatrices.Clear();
		}

		public void Dispose()
		{
			VpMatrices.Dispose();
		}
	}
}
