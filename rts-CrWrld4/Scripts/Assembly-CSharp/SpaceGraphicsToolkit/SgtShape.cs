using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public abstract class SgtShape : MonoBehaviour
	{
		public abstract float GetDensity(Vector3 worldPoint);
	}
}
