using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.Customization.Gadgets
{
	public class FlatSurfaceAttachmentOption : Mount.AttachmentOption
	{
		[SerializeField]
		private Vector2 attachmentAreaMax = new Vector2(0.5f, 0.5f);

		[SerializeField]
		private Vector2 attachmentAreaMin = new Vector2(0.25f, 0.25f);

		public Vector2 AttachmentAreaMin => attachmentAreaMin;

		public Vector2 AttachmentAreaMax => attachmentAreaMax;

		public override bool Accepts(GadgetBase gadget)
		{
			return true;
		}

		public override void GetPossibleAttachmentPositions(GadgetBase gadget, List<AttachmentPosition> destination)
		{
			Vector3 size = gadget.Bounds.size;
			Vector3 offsetNeg = gadget.Bounds.extents - gadget.Bounds.center;
			Vector3 offsetPos = gadget.Bounds.max;
			AddRotation(Vector3.forward, Vector3.up);
			AddRotation(Vector3.forward, Vector3.right);
			AddRotation(Vector3.forward, Vector3.down);
			AddRotation(Vector3.forward, Vector3.left);
			AddRotation(Vector3.up, Vector3.back);
			AddRotation(Vector3.up, Vector3.right);
			AddRotation(Vector3.up, Vector3.forward);
			AddRotation(Vector3.up, Vector3.left);
			AddRotation(Vector3.down, Vector3.back);
			AddRotation(Vector3.down, Vector3.left);
			AddRotation(Vector3.down, Vector3.forward);
			AddRotation(Vector3.down, Vector3.right);
			AddRotation(Vector3.right, Vector3.up);
			AddRotation(Vector3.right, Vector3.back);
			AddRotation(Vector3.right, Vector3.down);
			AddRotation(Vector3.right, Vector3.forward);
			AddRotation(Vector3.left, Vector3.up);
			AddRotation(Vector3.left, Vector3.forward);
			AddRotation(Vector3.left, Vector3.down);
			AddRotation(Vector3.left, Vector3.back);
			void AddRotation(Vector3 forward, Vector3 up)
			{
				if (!gadget.GadgetItem.OnlyPlaceInOneAxis || !(Vector3.Dot(forward, gadget.GadgetItem.PlacingAxis) > -0.99f))
				{
					Quaternion rotation = Quaternion.LookRotation(forward, up);
					Quaternion quaternion = Quaternion.Inverse(rotation);
					float width = GetSizeFromVector(quaternion * Vector3.right);
					float height = GetSizeFromVector(quaternion * Vector3.up);
					if (CanAttach(width, height))
					{
						float standoff = GetOffsetFromVector(quaternion * Vector3.forward);
						destination.Add(new AttachmentPosition(GetAttachmentPosition(standoff), rotation, base.transform, base.Owner.transform));
					}
				}
			}
			int GetAxis(Vector3 v)
			{
				if (!(Mathf.Abs(v.x) >= 0.1f))
				{
					if (!(Mathf.Abs(v.y) >= 0.1f))
					{
						if (!(Mathf.Abs(v.z) >= 0.1f))
						{
							throw new ArgumentOutOfRangeException();
						}
						return 2;
					}
					return 1;
				}
				return 0;
			}
			float GetOffsetFromVector(Vector3 v)
			{
				int index = GetAxis(v);
				return ((v[index] > 0f) ? offsetPos : offsetNeg)[index];
			}
			float GetSizeFromVector(Vector3 v)
			{
				int index = GetAxis(v);
				return size[index];
			}
		}

		private Vector3 GetAttachmentPosition(float standoff)
		{
			return new Vector3(0f, 0f, 0f - standoff);
		}

		public bool CanAttach(float width, float height)
		{
			if (width.IsInRange(attachmentAreaMin.x, attachmentAreaMax.x))
			{
				return height.IsInRange(attachmentAreaMin.y, attachmentAreaMax.y);
			}
			return false;
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Color color = (Gizmos.color = new Color(0f, 1f, 0f, 1f));
			Gizmos.DrawWireCube(Vector3.zero, new Vector3(attachmentAreaMin.x, attachmentAreaMin.y, 0f));
			Gizmos.DrawWireCube(Vector3.zero, new Vector3(attachmentAreaMax.x, attachmentAreaMax.y, 0f));
			color.a *= 0.25f;
			Gizmos.color = color;
			Gizmos.DrawCube(new Vector3(0f, (attachmentAreaMax.y + attachmentAreaMin.y) / 4f, 0f), new Vector3(attachmentAreaMax.x, (attachmentAreaMax.y - attachmentAreaMin.y) / 2f, 0.0001f));
			Gizmos.DrawCube(new Vector3(0f, (0f - (attachmentAreaMax.y + attachmentAreaMin.y)) / 4f, 0f), new Vector3(attachmentAreaMax.x, (attachmentAreaMax.y - attachmentAreaMin.y) / 2f, 0.0001f));
			Gizmos.DrawCube(new Vector3((attachmentAreaMax.x + attachmentAreaMin.x) / 4f, 0f, 0f), new Vector3((attachmentAreaMax.x - attachmentAreaMin.x) / 2f, attachmentAreaMin.y, 0.0001f));
			Gizmos.DrawCube(new Vector3((0f - (attachmentAreaMax.x + attachmentAreaMin.x)) / 4f, 0f, 0f), new Vector3((attachmentAreaMax.x - attachmentAreaMin.x) / 2f, attachmentAreaMin.y, 0.0001f));
		}
	}
}
