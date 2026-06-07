using UnityEngine;

namespace Assets.Scripts.Design.Symmetry
{
	public readonly struct SymmetryTransform
	{
		public Vector3 Position { get; }

		public Quaternion Rotation { get; }

		public SymmetryTransform(Vector3 position, Quaternion rotation)
		{
			Position = position;
			Rotation = rotation;
		}
	}
}
