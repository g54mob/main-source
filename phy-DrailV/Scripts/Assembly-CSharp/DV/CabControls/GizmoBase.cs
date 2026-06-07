using DV.CabControls.Spec;
using DV.Interaction;
using UnityEngine;

namespace DV.CabControls
{
	public abstract class GizmoBase : ControlImplBase
	{
		protected Gizmo spec;

		private Vector3? originalLocalScale;

		protected override InteractionHandPoses GenericHandPoses { get; } = new InteractionHandPoses(HandPose.PreGrab, HandPose.PreGrab, HandPose.Grab);

		protected virtual void Awake()
		{
			originalLocalScale = base.transform.localScale;
			spec = GetComponent<Gizmo>();
			if ((bool)spec.collision)
			{
				CollisionSound collisionSound = base.gameObject.AddComponent<CollisionSound>();
				collisionSound.sound = spec.collision;
				collisionSound.InitializeCollisionSoundCategory(spec.itemCollisionSoundCategory, spec.ignoredCollisionSoundCategory);
			}
		}

		protected override void FireGrabbed()
		{
			base.FireGrabbed();
			ResetScale();
		}

		protected override void FireUngrabbed()
		{
			base.FireUngrabbed();
			ResetScale();
		}

		protected void ResetScale()
		{
			if (originalLocalScale.HasValue)
			{
				base.transform.localScale = originalLocalScale.Value;
			}
		}
	}
}
