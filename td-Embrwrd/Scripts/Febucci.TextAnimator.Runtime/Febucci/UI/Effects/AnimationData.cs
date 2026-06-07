using System;
using Febucci.UI.Core;
using UnityEngine;

namespace Febucci.UI.Effects
{
	[Serializable]
	public class AnimationData
	{
		[FloatCurveProperty]
		public FloatCurve movementX;

		[FloatCurveProperty]
		public FloatCurve movementY;

		[FloatCurveProperty]
		public FloatCurve movementZ;

		[FloatCurveProperty]
		public FloatCurve scaleX;

		[FloatCurveProperty]
		public FloatCurve scaleY;

		[FloatCurveProperty]
		public FloatCurve rotX;

		[FloatCurveProperty]
		public FloatCurve rotY;

		[FloatCurveProperty]
		public FloatCurve rotZ;

		[ColorCurveProperty]
		public ColorCurve colorCurve;

		private Vector3 movement;

		private Vector2 scale;

		private Quaternion rot;

		public bool TryCalculatingMatrix(CharacterData character, float timePassed, float weight, out Matrix4x4 matrix, out Vector3 offset)
		{
			matrix = default(Matrix4x4);
			offset = default(Vector3);
			return false;
		}

		public bool TryCalculatingColor(CharacterData character, float timePassed, float weight, out Color32 color)
		{
			color = default(Color32);
			return false;
		}
	}
}
