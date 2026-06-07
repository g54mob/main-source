using ModApi;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class CollisionIgnoreScript : MonoBehaviour
	{
		private bool _fixedUpdateRan;

		private bool _isTrigger;

		private Rigidbody _tempRigidbody;

		public void OnTriggerEnter(Collider other)
		{
			PartScript parentOrSelf = Utilities.GetParentOrSelf<PartScript>(other.transform);
			if (parentOrSelf != null)
			{
				PartScript parentOrSelf2 = Utilities.GetParentOrSelf<PartScript>(base.transform);
				if (parentOrSelf.BodyScript != parentOrSelf2.BodyScript && new PartGraph(parentOrSelf.Data, breakOnRigidBodyBoundary: true).Parts.Contains(parentOrSelf.Data))
				{
					Physics.IgnoreCollision(GetComponent<Collider>(), other);
				}
			}
		}

		protected virtual void FixedUpdate()
		{
			_fixedUpdateRan = true;
		}

		protected virtual void Start()
		{
			_tempRigidbody = base.gameObject.AddComponent<Rigidbody>();
			_tempRigidbody.isKinematic = true;
			_tempRigidbody.mass = 0f;
			_tempRigidbody.useGravity = false;
			_isTrigger = GetComponent<Collider>().isTrigger;
			GetComponent<Collider>().isTrigger = true;
		}

		protected virtual void Update()
		{
			if (_fixedUpdateRan)
			{
				GetComponent<Collider>().isTrigger = _isTrigger;
				Object.Destroy(_tempRigidbody);
				Object.Destroy(this);
			}
		}
	}
}
