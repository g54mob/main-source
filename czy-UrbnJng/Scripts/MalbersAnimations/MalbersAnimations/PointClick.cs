using System;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/AI/Point Click")]
	public class PointClick : MonoBehaviour
	{
		public PointClickData pointClickData;

		[Tooltip("UI to intantiate on the Hit Point ")]
		public GameObject PointUI;

		[Tooltip("What mouse button to use for the joystick ")]
		public PointerEventData.InputButton Button;

		[Tooltip("Radius to find <AI Targets> on the Hit Point")]
		public float radius = 0.2f;

		private const float navMeshSampleDistance = 4f;

		[Tooltip("If its hit a point on an empty space, it will clear the Current Target")]
		public bool ClearTarget = true;

		[Tooltip("How many AI Targets can be found on the SphereCast ")]
		[Min(2f)]
		public int AITargetsSize = 10;

		public LayerReference FindTargets = new LayerReference(-1);

		[Header("Events")]
		public Vector3Event OnPointClick = new Vector3Event();

		[FormerlySerializedAs("OnInteractableClick")]
		public TransformEvent OnAITargetClick = new TransformEvent();

		protected Collider[] AITargets;

		public IAIControl AIControl;

		private Vector3 destinationPosition;

		private void OnEnable()
		{
			if ((bool)pointClickData)
			{
				PointClickData obj = pointClickData;
				obj.baseDataPointerClick = (Action<BaseEventData>)Delegate.Combine(obj.baseDataPointerClick, new Action<BaseEventData>(OnGroundClick));
			}
			IObjectCore objectCore = this.FindInterface<IObjectCore>();
			if (objectCore != null)
			{
				AIControl = objectCore.transform.FindInterface<IAIControl>();
			}
			AITargets = new Collider[AITargetsSize];
		}

		private void OnDisable()
		{
			if ((bool)pointClickData)
			{
				PointClickData obj = pointClickData;
				obj.baseDataPointerClick = (Action<BaseEventData>)Delegate.Remove(obj.baseDataPointerClick, new Action<BaseEventData>(OnGroundClick));
			}
		}

		public virtual void OnGroundClick(BaseEventData data)
		{
			PointerEventData pointerEventData = (PointerEventData)data;
			if (ClearTarget)
			{
				AIControl?.SetTarget(null, move: true);
			}
			if (pointerEventData == null || pointerEventData.button != Button)
			{
				return;
			}
			if (NavMesh.SamplePosition(pointerEventData.pointerCurrentRaycast.worldPosition, out var hit, 4f, -1))
			{
				destinationPosition = hit.position;
			}
			else
			{
				destinationPosition = pointerEventData.pointerCurrentRaycast.worldPosition;
			}
			MDebug.DrawWireSphere(destinationPosition, Color.red, radius, 1f);
			int num = Physics.OverlapSphereNonAlloc(destinationPosition, radius, AITargets, FindTargets.Value);
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					Collider collider = AITargets[i];
					if (collider == null)
					{
						break;
					}
					if (!collider.transform.SameHierarchy(base.transform) && collider.transform.FindInterface<IAITarget>() != null)
					{
						OnAITargetClick.Invoke(collider.transform);
						if ((bool)PointUI)
						{
							UnityEngine.Object.Instantiate(PointUI, collider.transform.position, Quaternion.FromToRotation(PointUI.transform.up, pointerEventData.pointerCurrentRaycast.worldNormal));
						}
						return;
					}
				}
			}
			if ((bool)PointUI)
			{
				UnityEngine.Object.Instantiate(PointUI, destinationPosition, Quaternion.FromToRotation(PointUI.transform.up, pointerEventData.pointerCurrentRaycast.worldNormal));
			}
			OnPointClick.Invoke(destinationPosition);
		}
	}
}
