using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	[AddComponentMenu(null)]
	[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
	public class CinemachineHardLookAt : CinemachineComponentBase
	{
		public override bool IsValid => false;

		public override CinemachineCore.Stage Stage => default(CinemachineCore.Stage);

		public override void MutateCameraState(ref CameraState curState, float deltaTime)
		{
		}
	}
}
