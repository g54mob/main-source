using UnityEngine;

namespace VRTK
{
	public class VRTK_PlayAreaCollider : MonoBehaviour
	{
		protected VRTK_PlayAreaCursor parent;

		protected VRTK_PolicyList targetListPolicy;

		public virtual void SetParent(VRTK_PlayAreaCursor setParent)
		{
			parent = setParent;
		}

		public virtual void SetIgnoreTarget(VRTK_PolicyList list = null)
		{
			targetListPolicy = list;
		}

		protected virtual void OnDisable()
		{
			if (parent != null)
			{
				parent.SetPlayAreaCursorCollision(state: false);
			}
		}

		protected virtual void OnTriggerStay(Collider collider)
		{
			if (parent != null && parent.enabled && parent.gameObject.activeInHierarchy && ValidTarget(collider))
			{
				parent.SetPlayAreaCursorCollision(state: true, collider);
			}
		}

		protected virtual void OnTriggerExit(Collider collider)
		{
			if (parent != null && ValidTarget(collider))
			{
				parent.SetPlayAreaCursorCollision(state: false, collider);
			}
		}

		protected virtual bool ValidTarget(Collider collider)
		{
			if (!collider.isTrigger && !VRTK_PlayerObject.IsPlayerObject(collider.gameObject))
			{
				return !VRTK_PolicyList.Check(collider.gameObject, targetListPolicy);
			}
			return false;
		}
	}
}
