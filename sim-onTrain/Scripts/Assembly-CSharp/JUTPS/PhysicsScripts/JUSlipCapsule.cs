using UnityEngine;

namespace JUTPS.PhysicsScripts
{
	[AddComponentMenu("JU TPS/Third Person System/Additionals/Slip Capsule")]
	public class JUSlipCapsule : MonoBehaviour
	{
		[SerializeField]
		private Vector3 Center = new Vector3(0f, 0.85f, 0f);

		[SerializeField]
		private float Radius = 0.5f;

		[SerializeField]
		private float Height = 1.25f;

		private CapsuleCollider defaultCapsuleCollider;

		private CapsuleCollider slipCapsule;

		private void Awake()
		{
			defaultCapsuleCollider = GetComponent<CapsuleCollider>();
			GenerateSlipCapsuleCollider(base.gameObject, Center, Radius, Height, out slipCapsule);
		}

		private void Update()
		{
			if (!(defaultCapsuleCollider == null) && !(slipCapsule == null))
			{
				slipCapsule.isTrigger = defaultCapsuleCollider.isTrigger;
				slipCapsule.enabled = defaultCapsuleCollider.enabled;
			}
		}

		public static void GenerateSlipCapsuleCollider(GameObject target, Vector3 Center, float Radius, float Height, out CapsuleCollider outCapsuleCollider)
		{
			CapsuleCollider capsuleCollider = target.AddComponent<CapsuleCollider>();
			capsuleCollider.center = Center;
			capsuleCollider.radius = Radius;
			capsuleCollider.height = Height;
			capsuleCollider.material = (PhysicMaterial)Resources.Load("Slip");
			outCapsuleCollider = capsuleCollider;
		}
	}
}
