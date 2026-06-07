using UnityEngine;

namespace DV.Interaction
{
	public class SnapperTargetReassigner : MonoBehaviour
	{
		public AHandPoseSnapper snapper;

		private TrainCarInteriorObject lastInterior;

		private void OnEnable()
		{
			TrainCarInteriorObject componentInParent = GetComponentInParent<TrainCarInteriorObject>();
			if (!componentInParent)
			{
				Debug.LogError("TrainCarInteriorObject not found in parents, not doing anything.", base.gameObject);
			}
			else if (!(lastInterior == componentInParent))
			{
				lastInterior = componentInParent;
				Transform newRoot = componentInParent.actualTrainCar.transform;
				if (snapper is LineHandSnapper lineHandSnapper)
				{
					Reassign(ref lineHandSnapper.lineStart, newRoot);
				}
				else if (snapper is CircleHandSnapper circleHandSnapper)
				{
					Reassign(ref circleHandSnapper.centerUpward, newRoot);
				}
				else if (snapper is PointHandSnapper pointHandSnapper)
				{
					Reassign(ref pointHandSnapper.pointMarker, newRoot);
				}
				else if (snapper is ValveHandSnapper valveHandSnapper)
				{
					Reassign(ref valveHandSnapper.axis, newRoot);
				}
				else
				{
					Debug.LogError("SnapperTargetReassigner doesn't support a snapper of type " + snapper.GetType().Name + ", not doing anything to it.", snapper);
				}
			}
		}

		private void Reassign(ref Transform targetField, Transform newRoot)
		{
			if (targetField == null)
			{
				Debug.LogError("SnapperTargetReassigner on " + base.gameObject.name + " has no target field assigned, can't reassign it!", this);
				return;
			}
			Transform transform = newRoot.FindChildRecursive(targetField.name);
			if (transform != null)
			{
				targetField = transform;
				return;
			}
			Debug.LogError("SnapperTargetReassigner on " + base.gameObject.name + " couldn't find target field " + targetField.name + " in " + newRoot.name + ", leaving it as-is.", newRoot);
		}
	}
}
