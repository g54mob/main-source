using System;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public sealed class Structure
	{
		[Tooltip("Determines where the corresponding 'Receptor' has got its anchor.")]
		public Vector3 Position = Vector3.zero;

		[Tooltip("Defines the direction the corresponding 'Receptor' is oriented towards.")]
		public Vector3 Direction = Vector3.up;

		[Tooltip("Can be seen as weight of the corresponding 'Receptor' used for writing objective values to a 'Problem' belonging to a 'Context'.")]
		public float Magnitude = 1f;

		[Tooltip("Influences how sensitive the corresponding 'Receptor' perceives the environment. So within a 'SteeringBehaviour', it is used as threshold angle for deciding when to write objective values to a 'Problem' belonging to a 'Context'.")]
		public float Sensitivity = 90f;

		public static void Lerp(Structure a, Structure b, float t, Structure result)
		{
			result.Position = Vector3.Lerp(a.Position, b.Position, t);
			result.Direction = Vector3.Lerp(a.Direction, b.Direction, t);
			result.Magnitude = Mathf.Lerp(a.Magnitude, b.Magnitude, t);
			result.Sensitivity = Mathf.Lerp(a.Sensitivity, b.Sensitivity, t);
		}

		public void RoundVectors(int decimalPlaces = 6)
		{
			Position.x = (float)Math.Round(Position.x, decimalPlaces);
			Position.y = (float)Math.Round(Position.y, decimalPlaces);
			Position.z = (float)Math.Round(Position.z, decimalPlaces);
			Direction.x = (float)Math.Round(Direction.x, decimalPlaces);
			Direction.y = (float)Math.Round(Direction.y, decimalPlaces);
			Direction.z = (float)Math.Round(Direction.z, decimalPlaces);
		}

		public void Copy(Structure other)
		{
			Position = other.Position;
			Direction = other.Direction;
			Magnitude = other.Magnitude;
			Sensitivity = other.Sensitivity;
		}
	}
}
