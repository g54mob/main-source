using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ItemSlot : CTSBehaviour
	{
		private static readonly Color GizmoColorGameplay = new Color(0.35f, 1f, 0.35f);

		private static readonly Color GizmoColorGameplayUsed = new Color(0.5f, 0.5f, 0f);

		private static readonly Color GizmoColorDecoration = new Color(0.35f, 0.35f, 1f);

		private static readonly Color GizmoColorDecorationUsed = new Color(0.5f, 0f, 0.5f);

		private static readonly Vector3 GizmoSize = Vector3.one * 0.05f;

		public bool InUse { get; private set; }

		internal Item InSlot { get; private set; }

		[field: SerializeField]
		public SlotType Type { get; private set; }

		public void SetUsed(Item item)
		{
			if (!InUse)
			{
				OnSetUsed(item);
			}
		}

		protected virtual void OnSetUsed(Item item)
		{
			InUse = true;
			InSlot = item;
		}

		public void SetUnused()
		{
			if (InUse)
			{
				OnSetUnused();
			}
		}

		protected virtual void OnSetUnused()
		{
			InUse = false;
			InSlot = null;
		}

		public virtual void ClearSlot()
		{
			if ((bool)InSlot)
			{
				InSlot.Clear();
			}
			SetUnused();
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = ((Type != SlotType.Decoration) ? (InUse ? GizmoColorGameplayUsed : GizmoColorGameplay) : (InUse ? GizmoColorDecorationUsed : GizmoColorDecoration));
			Gizmos.DrawCube(base.transform.position, GizmoSize);
		}
	}
}
