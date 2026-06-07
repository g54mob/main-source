using Jundroo.Common.Math;
using UnityEngine;

namespace Assets.Scripts.Flight.Proximity.Occlusion
{
	public class OrientedBoundingBoxScript : MonoBehaviour
	{
		private OrientedBoundingBox _obb;

		protected void OnDrawGizmosSelected()
		{
			if (_obb == null)
			{
				_obb = OrientedBoundingBox.CalculateOBB(base.gameObject.GetComponentsInChildren<MeshRenderer>());
			}
			if (_obb != null)
			{
				_obb.Draw();
			}
		}
	}
}
