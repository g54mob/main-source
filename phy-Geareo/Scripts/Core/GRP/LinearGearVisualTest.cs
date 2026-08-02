using UnityEngine;

namespace GRP
{
	public class LinearGearVisualTest : MonoBehaviour
	{
		[Range(-0.4f, 0.4f)]
		public float mag;

		public int tooth;

		public LinearGearVisual visual;

		public LinearGearVisualOptions options;

		private void OnValidate()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
