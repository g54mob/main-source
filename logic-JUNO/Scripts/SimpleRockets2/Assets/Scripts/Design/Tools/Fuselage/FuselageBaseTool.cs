using ModApi.Audio;
using UnityEngine;

namespace Assets.Scripts.Design.Tools.Fuselage
{
	public abstract class FuselageBaseTool : MovementTool
	{
		public bool GizmosActive
		{
			get
			{
				if (GizmosParent != null)
				{
					return GizmosParent.gameObject.activeSelf;
				}
				return false;
			}
		}

		public Transform GizmosParent { get; private set; }

		protected override bool UsePartSelection => false;

		public FuselageBaseTool(DesignerScript designer)
			: base(designer)
		{
			base.Movement = MovementType.Self;
		}

		protected virtual void CreateGizmos(bool localOrientation, bool playGizmoFlyout)
		{
			CreateGizmosParent(base.SelectedPart.Transform, playGizmoFlyout);
		}

		protected Transform CreateGizmosParent(Transform partTransform, bool playGizmoFlyout)
		{
			if (playGizmoFlyout)
			{
				Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Design.GizmoFlyout);
			}
			if (GizmosActive)
			{
				Debug.LogWarning("Gizmos already active, call DestroyGizmos before calling CreateGizmos");
				DestroyGizmos();
			}
			GizmosParent = new GameObject("FuselageGizmos").transform;
			GizmosParent.SetParent(partTransform, worldPositionStays: false);
			GizmosParent.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			Vector3 lossyScale = GizmosParent.lossyScale;
			GizmosParent.localScale = new Vector3(1f / lossyScale.x, 1f / lossyScale.y, 1f / lossyScale.z);
			return GizmosParent;
		}

		protected virtual void DestroyGizmos()
		{
			if (GizmosParent != null)
			{
				Object.Destroy(GizmosParent.gameObject);
				GizmosParent = null;
			}
		}

		protected override void ProcessSelectedTransformChanged(Transform newTransform, bool justAddedPart, bool notifyGizmo)
		{
			base.ProcessSelectedTransformChanged(newTransform, justAddedPart, notifyGizmo);
			if (base.Active && notifyGizmo)
			{
				if (GizmosActive)
				{
					DestroyGizmos();
				}
				CreateGizmos(base.LocalOrientation, !justAddedPart);
			}
		}
	}
}
