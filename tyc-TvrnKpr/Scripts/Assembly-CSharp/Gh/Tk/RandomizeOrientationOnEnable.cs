using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class RandomizeOrientationOnEnable : MonoBehaviour
	{
		public List<Vector3> rotations;

		public List<Vector3> scales;

		public Transform targetTransform;

		private void OnEnable()
		{
		}
	}
}
