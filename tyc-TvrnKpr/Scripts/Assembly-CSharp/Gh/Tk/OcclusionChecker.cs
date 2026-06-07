using UnityEngine;

namespace Gh.Tk
{
	public class OcclusionChecker : BaseOcclusionChecker
	{
		public LayerMask layerMask;

		private Transform _headBone;

		private Transform _mainCam;

		private SetOccluderTransparency _currentSot;

		private readonly RaycastHit[] _hitResult;

		public override void Start()
		{
		}

		protected override void UpdateInternal()
		{
		}

		protected override void DisableOcclusions()
		{
		}

		private void SetCurrentOcclusion(SetOccluderTransparency sot)
		{
		}
	}
}
