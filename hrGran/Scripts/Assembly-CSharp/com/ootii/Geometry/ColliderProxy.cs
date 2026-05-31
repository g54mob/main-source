using System.Reflection;
using UnityEngine;

namespace com.ootii.Geometry
{
	public class ColliderProxy : MonoBehaviour
	{
		public GameObject _Target;

		protected Component mTarget;

		protected MethodInfo mOnTriggerEnter;

		protected MethodInfo mOnTriggerStay;

		protected MethodInfo mOnTriggerExit;

		public GameObject Target
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected virtual void Awake()
		{
		}

		public virtual void Reset()
		{
		}

		public virtual void EnableColliders(bool rEnable, float rSpeed = 0f)
		{
		}

		protected void BindTarget(GameObject rTarget)
		{
		}

		protected virtual void OnTriggerEnter(Collider rCollider)
		{
		}

		protected virtual void OnTriggerStay(Collider rCollider)
		{
		}

		protected virtual void OnTriggerExit(Collider rCollider)
		{
		}
	}
}
