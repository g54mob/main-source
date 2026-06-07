using Assets.ThirdParty.SplineTools;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Campaign
{
	public class FinalLocationBarrier : BaseMeshBender
	{
		public PhysicMaterial Material;

		public override void OnMeshCreated(GameObject go, CubicBezierCurve curve)
		{
			MeshCollider meshCollider = go.AddComponent<MeshCollider>();
			meshCollider.sharedMesh = go.GetComponent<MeshFilter>().sharedMesh;
			meshCollider.sharedMaterial = Material;
			go.layer = 11;
			foreach (Transform item in go.transform)
			{
				item.gameObject.layer = 11;
			}
		}
	}
}
