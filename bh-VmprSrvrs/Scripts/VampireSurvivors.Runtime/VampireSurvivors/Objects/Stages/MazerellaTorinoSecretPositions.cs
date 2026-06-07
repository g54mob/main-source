using UnityEngine;

namespace VampireSurvivors.Objects.Stages
{
	public class MazerellaTorinoSecretPositions : MonoBehaviour
	{
		[SerializeField]
		private float _colossusOutsideMapYThreshold;

		[SerializeField]
		private Bounds _unlockTorinoPlayerBounds;

		public Bounds UnlockTorinoPlayerBounds => default(Bounds);

		public float ColossusOutsideMapYThreshold()
		{
			return 0f;
		}
	}
}
