using UnityEngine;

namespace Restory.Data.Soldering
{
	[CreateAssetMenu(fileName = "SolderingProcessSettings", menuName = "Restory/Soldering/SolderingProcessSettings")]
	public class SolderingProcessSettings : ScriptableObject
	{
		[SerializeField]
		[Range(0.1f, 2f)]
		private float cleanedTracesTransitionDurationInSeconds = 1f;

		[SerializeField]
		private DisappearingTraceTransitionSettings disappearingTraceTransition = new DisappearingTraceTransitionSettings();

		[SerializeField]
		[Range(0.001f, 0.004f)]
		private float solderingAffectionDistance = 0.0025f;

		public float CleanedTracesTransitionDurationInSeconds => cleanedTracesTransitionDurationInSeconds;

		public DisappearingTraceTransitionSettings DisappearingTraceTransition => disappearingTraceTransition;

		public float SolderingAffectionDistance => solderingAffectionDistance;
	}
}
