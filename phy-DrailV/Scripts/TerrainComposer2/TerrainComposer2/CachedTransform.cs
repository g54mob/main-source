using System;
using UnityEngine;

namespace TerrainComposer2
{
	[Serializable]
	public class CachedTransform
	{
		public Vector3 position;

		public Vector3 posOffset;

		public Quaternion rotation;

		public Vector3 scale;

		public float positionYOld;

		public void CopySpecial(TC_ItemBehaviour item)
		{
			TC_Node tC_Node = item as TC_Node;
			bool flag = false;
			if (tC_Node != null && tC_Node.nodeType == NodeGroupType.Mask)
			{
				flag = true;
			}
			posOffset = item.posOffset;
			bool lockPosParent = item.lockPosParent;
			if (item.lockTransform || lockPosParent)
			{
				Vector3 zero = Vector3.zero;
				Vector3 zero2 = Vector3.zero;
				if (!(item.lockPosX || lockPosParent))
				{
					zero.x = item.t.position.x;
				}
				else
				{
					zero.x = position.x;
				}
				if (!(item.lockPosY || lockPosParent))
				{
					zero.y = item.posY * scale.y;
				}
				else
				{
					zero.y = position.y;
				}
				if (!(item.lockPosZ || lockPosParent))
				{
					zero.z = item.t.position.z;
				}
				else
				{
					zero.z = position.z;
				}
				Quaternion quaternion = ((item.lockRotY && item.lockTransform) ? rotation : Quaternion.Euler(0f, item.t.eulerAngles.y, 0f));
				if (!item.lockScaleX || !item.lockTransform)
				{
					zero2.x = item.t.lossyScale.x;
				}
				else
				{
					zero2.x = scale.x;
				}
				if (!item.lockScaleY || !item.lockTransform)
				{
					if (flag)
					{
						zero2.y = item.t.localScale.y;
					}
					else
					{
						zero2.y = item.t.lossyScale.y * item.opacity;
					}
				}
				else
				{
					zero2.y = scale.y;
				}
				if (!item.lockScaleZ || !item.lockTransform)
				{
					zero2.z = item.t.lossyScale.z;
				}
				else
				{
					zero2.z = scale.z;
				}
				position = zero;
				rotation = quaternion;
				scale = zero2;
				if (item.t.position != position)
				{
					item.t.position = position;
				}
				if (item.t.rotation != rotation)
				{
					item.t.rotation = rotation;
				}
				item.t.hasChanged = false;
			}
			else
			{
				rotation = Quaternion.Euler(0f, item.t.eulerAngles.y, 0f);
				scale.x = item.t.lossyScale.x;
				scale.z = item.t.lossyScale.z;
				if (flag)
				{
					scale.y = item.t.localScale.y;
				}
				else
				{
					scale.y = item.t.lossyScale.y;
				}
				scale.y *= item.opacity;
				position = item.t.position;
				position.y = item.posY * scale.y;
			}
		}

		public void Copy(TC_ItemBehaviour item)
		{
			position.x = item.t.position.x;
			position.z = item.t.position.z;
			posOffset = item.posOffset;
			rotation = item.t.rotation;
			scale = item.t.lossyScale;
			positionYOld = item.posY;
		}

		public void Copy(Transform t)
		{
			position = t.position;
			rotation = t.rotation;
			scale = t.lossyScale;
		}

		public bool hasChanged(Transform t)
		{
			if (t == null)
			{
				return false;
			}
			if (position != t.position || rotation != t.rotation || scale != t.lossyScale)
			{
				return true;
			}
			return false;
		}

		public bool hasChanged(TC_ItemBehaviour item)
		{
			if (position.x != item.t.position.x || position.z != item.t.position.z || item.posY != positionYOld)
			{
				return true;
			}
			if (rotation != item.t.rotation)
			{
				return true;
			}
			if (scale != item.t.lossyScale)
			{
				return true;
			}
			return false;
		}
	}
}
