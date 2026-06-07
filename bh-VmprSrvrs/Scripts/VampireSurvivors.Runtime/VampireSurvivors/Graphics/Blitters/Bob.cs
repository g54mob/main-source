using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace VampireSurvivors.Graphics.Blitters
{
	[Serializable]
	public class Bob : IDisposable
	{
		private const int GrowAmount = 256;

		private static Stack<Bob> emptyBobs;

		private float2 _position;

		private float2 _scale;

		private Sprite _sprite;

		private static Color32 _white;

		[NonSerialized]
		internal BobVertexData[] vertexData;

		private BobData _bobData;

		private bool _disposed;

		[NonSerialized]
		public float2 halfSize;

		private Rect spriteRect;

		public float2 Position
		{
			get
			{
				return default(float2);
			}
			set
			{
			}
		}

		public float2 Scale
		{
			get
			{
				return default(float2);
			}
			set
			{
			}
		}

		public Sprite Sprite => null;

		public BobData BobData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		internal ref BobVertexData GetVertexData(int id)
		{
			throw null;
		}

		private Bob()
		{
		}

		private void Reset(Vector2 position, Sprite sprite, Color32 tint1, Color32 tint2, Color32 tint3, Color32 tint4)
		{
		}

		private Bob(Vector2 position, Sprite sprite, Color32 tint1, Color32 tint2, Color32 tint3, Color32 tint4)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Bob Create(Vector2 position, Sprite sprite)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Bob Create(Vector2 position, Sprite sprite, Color32 tint)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Bob Create(Vector2 position, Sprite sprite, Color32 tint1, Color32 tint2, Color32 tint3, Color32 tint4)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void LoadUVs()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		public void SetAlpha(float alpha)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		public void SetAlpha(float alpha, int vertIndex)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		public void SetTint(Color32 tint)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		public void SetTint(Color32 tint1, Color32 tint2, Color32 tint3, Color32 tint4)
		{
		}

		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		public void SetTint(Color32 tint, int vertIndex)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		public Color32 GetTint()
		{
			return default(Color32);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		public float GetAlpha()
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		public Color32 GetTint(int vertIndex)
		{
			return default(Color32);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		public void Dispose()
		{
		}
	}
}
