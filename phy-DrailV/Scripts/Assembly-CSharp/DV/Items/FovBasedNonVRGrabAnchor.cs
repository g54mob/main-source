using UnityEngine;

namespace DV.Items
{
	public class FovBasedNonVRGrabAnchor : MonoBehaviour, ICustomNonVRGrabAnchor
	{
		public Vector3 localPosition;

		public Vector3 localRotation;

		public AnimationCurve fovRotationXOffset;

		public AnimationCurve fovDistanceOffset;

		public (Vector3 localPos, Quaternion localRot) GetGrabAnchor()
		{
			float time = GamePreferences.Get<float>(Preferences.FieldOfView);
			Quaternion quaternion = Quaternion.AngleAxis(fovRotationXOffset.Evaluate(time), Vector3.right);
			Vector3 item = localPosition;
			item.z += fovDistanceOffset.Evaluate(time);
			return (localPos: item, localRot: quaternion * Quaternion.Euler(localRotation));
		}

		private void Reset()
		{
			if (TryGetComponent<CustomNonVrGrabAnchor>(out var component))
			{
				localPosition = component.customLocalPosition;
				localRotation = component.customLocalRotation;
				Object.DestroyImmediate(component);
			}
			fovRotationXOffset = new AnimationCurve();
			fovDistanceOffset = new AnimationCurve();
			fovRotationXOffset.keys = new Keyframe[2]
			{
				new Keyframe(30f, 0f),
				new Keyframe(120f, 0f)
			};
			fovDistanceOffset.keys = new Keyframe[2]
			{
				new Keyframe(30f, 0f),
				new Keyframe(120f, 0f)
			};
		}
	}
}
