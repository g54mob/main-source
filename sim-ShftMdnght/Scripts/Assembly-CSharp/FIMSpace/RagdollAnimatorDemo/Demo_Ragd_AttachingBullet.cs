using System.Collections.Generic;
using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_AttachingBullet : Demo_Ragd_Bullet
	{
		private struct Attached
		{
			public RagdollAnimator2BoneIndicator indicator;

			public Vector3 localOffset;
		}

		public class AttachementMarker : MonoBehaviour
		{
		}

		private List<Attached> attached;

		public bool KinematicAttach = true;

		public bool AllowAttachMultipleEnemies;

		public bool AllowAttachAlreadyRagdolled;

		private RaycastHit[] hitAlloc = new RaycastHit[8];

		private int hits;

		private bool doUpdate = true;

		protected override void Start()
		{
			base.Start();
			attached = new List<Attached>();
		}

		private bool AlreadyAttached(RagdollAnimator2BoneIndicator indic)
		{
			foreach (Attached item in attached)
			{
				if (item.indicator.ParentHandler == indic.ParentHandler)
				{
					return true;
				}
			}
			return false;
		}

		protected override bool DoRaycast(Vector3 newPosition)
		{
			bool result = false;
			Vector3 vector = newPosition - base.transform.position;
			hits = Physics.RaycastNonAlloc(new Ray(base.transform.position, vector.normalized), hitAlloc, vector.magnitude, ProjectiletHitMask, QueryTriggerInteraction.Ignore);
			if (hits > 0)
			{
				for (int i = 0; i < hits; i++)
				{
					RagdollAnimator2BoneIndicator component = hitAlloc[i].collider.GetComponent<RagdollAnimator2BoneIndicator>();
					if (!(component != null) || !AlreadyAttached(component))
					{
						bulletHit = hitAlloc[i];
						break;
					}
				}
				result = true;
			}
			else
			{
				bulletHit = default(RaycastHit);
			}
			return result;
		}

		protected override void Update()
		{
			if (doUpdate)
			{
				base.Update();
			}
		}

		private void LateUpdate()
		{
			if (KinematicAttach)
			{
				foreach (Attached item in attached)
				{
					Vector3 position = base.transform.TransformPoint(item.localOffset);
					RagdollHandlerUtilities.SwitchKinematicAndProjection(item.indicator.DummyBoneRigidbody, item.indicator.ParentHandler);
					item.indicator.DummyBoneRigidbody.position = position;
				}
				return;
			}
			foreach (Attached item2 in attached)
			{
				Vector3 worldPosition = base.transform.TransformPoint(item2.localOffset);
				item2.indicator.DummyBoneRigidbody.mass = item2.indicator.ParentHandler.ReferenceMass * 1000f;
				item2.indicator.DummyBoneRigidbody.DragRigidbodyTowards(worldPosition, 1.4f);
			}
		}

		private void OnAttachIndicator(Attached attach)
		{
			RagdollHandler parentHandler = attach.indicator.ParentHandler;
			parentHandler.RigidbodyDragValue = 0f;
			parentHandler.User_UpdateRigidbodyParametersForAllBones();
		}

		protected override void OnHitEnd()
		{
			if (bulletHit.transform == null)
			{
				return;
			}
			RagdollAnimator2BoneIndicator component = bulletHit.collider.GetComponent<RagdollAnimator2BoneIndicator>();
			if (component == null)
			{
				base.transform.position = bulletHit.point - base.transform.forward * 0.15f;
				doUpdate = false;
				KinematicAttach = true;
			}
			else
			{
				if ((!AllowAttachMultipleEnemies && this.attached.Count > 1) || AlreadyAttached(component))
				{
					return;
				}
				if (!AllowAttachAlreadyRagdolled)
				{
					if ((bool)component.ParentHandler.Dummy_Container.GetComponent<AttachementMarker>())
					{
						return;
					}
					component.ParentHandler.Dummy_Container.gameObject.AddComponent<AttachementMarker>();
				}
				component.ParentHandler.User_SwitchFallState();
				Attached attached = new Attached
				{
					indicator = component
				};
				base.transform.position = bulletHit.point;
				attached.localOffset = base.transform.InverseTransformPoint(component.transform.position - base.transform.forward * 0.2f);
				this.attached.Add(attached);
				if (!KinematicAttach)
				{
					OnAttachIndicator(attached);
				}
			}
		}
	}
}
