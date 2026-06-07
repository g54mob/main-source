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
			public static readonly Index INVALID;

			internal readonly int index;

			public Index(int index)
			{
				this.index = 0;
			}

			public bool IsValid()
			{
				return false;
			}
		}

		private readonly List<Camera> cameras;

		public NativeList<Matrix4x4> VpMatrices { get; }

		public Index IndexOf(Camera camera)
		{
			return default(Index);
		}

		public Index Add(Camera camera)
		{
			return default(Index);
		}

		public Index Add(Camera camera, Matrix4x4 vpMatrix)
		{
			return default(Index);
		}

		public void Clear()
		{
		}

		public void Dispose()
		{
		}
	}
}
