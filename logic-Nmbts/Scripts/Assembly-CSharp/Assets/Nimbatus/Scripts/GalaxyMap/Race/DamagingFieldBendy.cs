using Assets.ThirdParty.SplineTools;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race
{
	public class DamagingFieldBendy : ProximityMeshBender
	{
		public float Damage;

		public string DamageSound;

		public override void OnMeshCreated(GameObject go, CubicBezierCurve curve)
		{
			float num = curve.Length / 10f;
			for (float num2 = num; num2 < curve.Length - 0.1f; num2 += num)
			{
				GameObject obj = new GameObject("ColliderObject");
				obj.transform.parent = go.transform;
				obj.transform.localPosition = curve.GetLocationAtDistance(num2);
				obj.transform.localRotation = CubicBezierCurve.GetRotationFromTangent(curve.GetTangentAtDistance(num2));
				obj.transform.localScale = Vector3.one;
				BoxCollider boxCollider = obj.AddComponent<BoxCollider>();
				boxCollider.isTrigger = true;
				boxCollider.size = new Vector3(ScaleX * 0.95f, 10f, num * 2f);
			}
			DamagingField damagingField = go.AddComponent<DamagingField>();
			damagingField.Damage = Damage;
			damagingField.DamageSound = DamageSound;
			go.layer = 30;
			foreach (Transform item in go.transform)
			{
				item.gameObject.layer = 30;
			}
		}
	}
}
