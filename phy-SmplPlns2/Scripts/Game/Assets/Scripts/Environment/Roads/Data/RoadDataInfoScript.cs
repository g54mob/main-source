using UnityEngine;

namespace Assets.Scripts.Environment.Roads.Data
{
	public class RoadDataInfoScript : MonoBehaviour
	{
		[SerializeField]
		private float _speedMultiplier = 1f;

		public float SpeedMultiplier => _speedMultiplier;
	}
}
