using UnityEngine;

namespace PG
{
	public class AITrigger : MonoBehaviour
	{
		[Range(0f, 1f)]
		public float BoostProbability;

		public bool Boost => false;
	}
}
