using UnityEngine;

namespace Simulator.Preview3D
{
	public interface IPreview3DObject
	{
		Transform transform { get; }

		Vector2 NormalizedAnchor { get; }

		void ResetRotation();

		void Rotate(Vector2 delta);
	}
}
