using UnityEngine;

namespace Motorways.Views
{
	public class DestinationVisualVariant : MonoBehaviour
	{
		public DestinationLevel Level0Square;

		public DestinationLevel Level0StationHorizontal;

		public DestinationLevel Level0StationVertical;

		public DestinationLevel Level1;

		public DestinationPinAnimatorView PinAnimator;

		public DestinationPinAnimatorView StationPinAnimator;

		public DestinationPinAnimatorView StationPinAnimatorVertical;

		public ParticleSystem DisconnectedParticles_Square;

		public ParticleSystem DisconnectedParticles_Circle;

		public ParticleSystem DisconnectedParticles_TrainStation;
	}
}
