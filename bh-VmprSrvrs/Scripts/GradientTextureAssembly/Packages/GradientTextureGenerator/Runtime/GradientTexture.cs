using System;
using System.Diagnostics;
using UnityEngine;

namespace Packages.GradientTextureGenerator.Runtime
{
	[CreateAssetMenu(fileName = "NewGradientName", menuName = "Texture/Gradient")]
	public class GradientTexture : ScriptableObject, IEquatable<Texture2D>, ISerializationCallbackReceiver
	{
		[SerializeField]
		private Vector2Int _resolution;

		[Range(0f, 1f)]
		[SerializeField]
		private float _dithering;

		[SerializeField]
		private AnimationCurve _verticalLerp;

		[SerializeField]
		[GradientUsage(true)]
		private Gradient _horizontalTop;

		[SerializeField]
		[GradientUsage(true)]
		private Gradient _horizontalBottom;

		[HideInInspector]
		[SerializeField]
		private Texture2D _texture;

		private int _width => 0;

		private int _height => 0;

		public Texture2D GetTexture()
		{
			return null;
		}

		private static Gradient GetDefaultGradient()
		{
			return null;
		}

		public void FillColors()
		{
		}

		public bool Equals(Texture2D other)
		{
			return false;
		}

		[Conditional("UNITY_EDITOR")]
		private void SetDirtyTexture()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public void OnBeforeSerialize()
		{
		}
	}
}
