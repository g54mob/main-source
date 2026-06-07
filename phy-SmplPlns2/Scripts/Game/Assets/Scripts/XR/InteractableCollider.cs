using System.Text;
using Assets.Scripts.Craft.Parts.Modifiers;
using Jundroo.Common.Utils;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.XR
{
	[RequireComponent(typeof(Collider))]
	public class InteractableCollider : MonoBehaviour
	{
		public TextMeshPro debugText;

		protected Collider _collider;

		[SerializeField]
		[Range(0f, 3f)]
		protected float _constantWeight;

		[SerializeField]
		[Range(0f, 3f)]
		protected float _depthWeight;

		[SerializeField]
		[Range(0f, 3f)]
		protected float _directionWeight;

		[SerializeField]
		[Range(0f, 3f)]
		protected float _offsetWeight;

		[SerializeField]
		protected Vector3 _surfaceNormal;

		[SerializeField]
		[Range(0f, 3f)]
		protected float _triggerWeight;

		public float CurrentTriggerValue { get; set; }

		public IInteractablePartModifier InteractablePart { get; private set; }

		public virtual float CalculateGripScore(FlightHand hand, Pose fingerTip)
		{
			Vector3 vector = base.transform.TransformDirection(_surfaceNormal);
			Vector3 position = fingerTip.position;
			Vector3 vector2 = _collider.ClosestPoint(position);
			Vector3 vector3 = position - vector2;
			float num = Vector3.Dot(vector3, vector);
			float magnitude = (vector3 - num * vector).magnitude;
			float constantWeight = _constantWeight;
			constantWeight += _depthWeight * (1f - num / 0.05f);
			constantWeight += _offsetWeight * (0f - magnitude) * 100f;
			constantWeight += _directionWeight * Vector3.Dot(-vector, fingerTip.forward);
			constantWeight += _triggerWeight * CurrentTriggerValue;
			if (debugText != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine($"Score: {constantWeight:0.00}");
				stringBuilder.AppendLine($"Depth: {_depthWeight * (1f - num / 0.05f):0.00}");
				stringBuilder.AppendLine($"Offst: {_offsetWeight * (0f - magnitude) * 100f:0.00}");
				stringBuilder.AppendLine($"Direc: {_directionWeight * Vector3.Dot(-vector, fingerTip.forward):0.00}");
				stringBuilder.AppendLine($"Trigr: {_triggerWeight * CurrentTriggerValue}");
				debugText.text = stringBuilder.ToString();
				debugText.enabled = true;
			}
			return constantWeight;
		}

		public virtual void InteractionEnd()
		{
			if (debugText != null)
			{
				debugText.enabled = false;
			}
		}

		public virtual void InteractionUpdate(ref Pose fingertipPose, float fingertipRadius, float triggerPull, out float? forcePoint, FlightHand hand)
		{
			Vector3 vector = _collider.ClosestPoint(fingertipPose.position);
			vector += (fingertipPose.position - vector).normalized * fingertipRadius;
			forcePoint = 1f;
			if (triggerPull < 0.8f)
			{
				fingertipPose.position = Vector3.Lerp(fingertipPose.position, vector, triggerPull / 0.8f);
			}
			else
			{
				fingertipPose.position = vector;
			}
		}

		protected virtual void Start()
		{
			InteractablePart = Utilities.GetComponentWithInterfaceInParent<IInteractablePartModifier>(base.gameObject);
			if (InteractablePart == null)
			{
				Debug.LogError("InteractableCollider does not have a parent IInteractablePartModifier: " + Utilities.GetFullObjectHierarchy(base.transform), base.gameObject);
			}
			_collider = GetComponent<Collider>();
			_surfaceNormal = _surfaceNormal.normalized;
			if (debugText != null)
			{
				debugText.enabled = false;
			}
		}
	}
}
