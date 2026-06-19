using UnityEngine;

namespace SiphonMana.Components
{
	public interface ISiphonManaPresenter
	{
		void ShowSiphonToOwnerBeam(Vector3 ownerPositionWorld);

		void HideSiphonToOwnerBeam();

		void ShowSiphonTargetBeam(int beamIndex, Vector3 targetPositionWorld);

		void HideSiphonTargetBeam(int beamIndex);
	}
}
