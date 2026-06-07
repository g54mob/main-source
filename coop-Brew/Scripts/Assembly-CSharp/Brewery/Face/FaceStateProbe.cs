using UnityEngine;

namespace Brewery.Face
{
	public abstract class FaceStateProbe : MonoBehaviour, IFaceStateProbe
	{
		public abstract string ProbeId { get; }

		public abstract float Evaluate01();
	}
}
