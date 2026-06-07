using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CurvedUI
{
	public class CurvedUIPhysicsRaycaster : BaseRaycaster
	{
		[SerializeField]
		protected int sortOrder = 20;

		private RaycastHit hitInfo;

		private RaycastResult result;

		public int CompoundEventMask
		{
			get
			{
				if (!(eventCamera != null))
				{
					return -1;
				}
				return eventCamera.cullingMask & (int)CurvedUIInputModule.Instance.RaycastLayerMask;
			}
		}

		public override Camera eventCamera
		{
			get
			{
				if (!CurvedUIInputModule.Instance)
				{
					return null;
				}
				return CurvedUIInputModule.Instance.EventCamera;
			}
		}

		public virtual int Depth
		{
			get
			{
				if (!(eventCamera != null))
				{
					return 16777215;
				}
				return (int)eventCamera.depth;
			}
		}

		public override int sortOrderPriority => sortOrder;

		protected CurvedUIPhysicsRaycaster()
		{
		}

		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
		{
			if (!(CurvedUIInputModule.Instance == null) && !(CurvedUIInputModule.Instance.EventCamera == null) && Physics.Raycast(CurvedUIInputModule.Instance.GetEventRay(), out hitInfo, float.PositiveInfinity, CompoundEventMask) && !hitInfo.collider.GetComponentInParent<CurvedUISettings>())
			{
				result = new RaycastResult
				{
					gameObject = hitInfo.collider.gameObject,
					module = this,
					distance = hitInfo.distance,
					index = resultAppendList.Count,
					worldPosition = hitInfo.point,
					worldNormal = hitInfo.normal
				};
				resultAppendList.Add(result);
			}
		}
	}
}
