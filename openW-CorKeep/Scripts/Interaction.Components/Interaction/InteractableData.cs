using Pug.UnityExtensions;
using Unity.Entities;

namespace Interaction
{
	public struct InteractableData : IComponentData, IQueryTypeParameter
	{
		public float interactRadiusSqr;

		public FactionID requiredFactionToInteract;

		public float weightMultiplier;

		public FourDirectionFloat2 directionOffset;

		public bool allowToUseOnlyWhenClaimed;

		public bool ignorePlayerDirection;
	}
}
