using System;
using Febucci.UI.Core;
using UnityEngine;

namespace Febucci.UI.Effects
{
	[Serializable]
	public class AnimationData
	{
		[FloatCurveProperty]
		public FloatCurve movementX = new FloatCurve(1f, 0f, 0f);

		[FloatCurveProperty]
		public FloatCurve movementY = new FloatCurve(1f, 0f, 0f);

		[FloatCurveProperty]
		public FloatCurve movementZ = new FloatCurve(1f, 0f, 0f);

		[FloatCurveProperty]
		public FloatCurve scaleX = new FloatCurve(2f, 0f, 1f);

		[FloatCurveProperty]
		public FloatCurve scaleY = new FloatCurve(2f, 0f, 1f);

		[FloatCurveProperty]
		public FloatCurve rotX = new FloatCurve(45f, 0f, 0f);

		[FloatCurveProperty]
		public FloatCurve rotY = new FloatCurve(45f, 0f, 0f);

		[FloatCurveProperty]
		public FloatCurve rotZ = new FloatCurve(45f, 0f, 0f);

		[ColorCurveProperty]
		public ColorCurve colorCurve = new ColorCurve(0f);

		private Vector3 movement;

		private Vector2 scale;

		private Quaternion rot;

		public bool TryCalculatingMatrix(CharacterData character, float timePassed, float weight, out Matrix4x4 matrix, out Vector3 offset)
		{
			matrix = default(Matrix4x4);
			if (!movementX.enabled && !movementY.enabled && !movementZ.enabled && !rotX.enabled && !rotY.enabled && !rotZ.enabled && !scaleX.enabled && !scaleY.enabled)
			{
				offset = Vector2.zero;
				return false;
			}
			offset = (character.current.positions[0] + character.current.positions[2]) / 2f;
			rot = Quaternion.Euler(Mathf.LerpUnclamped(0f, rotX.Evaluate(timePassed, character.index), weight), Mathf.LerpUnclamped(0f, rotY.Evaluate(timePassed, character.index), weight), Mathf.LerpUnclamped(0f, rotZ.Evaluate(timePassed, character.index), weight));
			movement = new Vector3(Mathf.LerpUnclamped(0f, movementX.Evaluate(timePassed, character.index), weight), Mathf.LerpUnclamped(0f, movementY.Evaluate(timePassed, character.index), weight), Mathf.LerpUnclamped(0f, movementZ.Evaluate(timePassed, character.index), weight));
			scale = new Vector2(Mathf.LerpUnclamped(1f, scaleX.Evaluate(timePassed, character.index), weight), Mathf.LerpUnclamped(1f, scaleY.Evaluate(timePassed, character.index), weight));
			matrix.SetTRS(movement, rot, scale);
			return true;
		}

		public bool TryCalculatingColor(CharacterData character, float timePassed, float weight, out Color32 color)
		{
			if (!colorCurve.enabled)
			{
				color = Color.white;
				return false;
			}
			color = colorCurve.Evaluate(timePassed, character.index);
			return true;
		}
	}
}
