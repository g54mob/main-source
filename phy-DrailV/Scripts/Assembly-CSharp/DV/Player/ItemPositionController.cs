using System.Collections.Generic;
using DV.Items;
using DV.Utils;
using UnityEngine;

namespace DV.Player
{
	public class ItemPositionController : SingletonBehaviour<ItemPositionController>, ItemPositionController.IPositionProvider
	{
		public interface IPositionProvider
		{
			int Priority { get; }

			(Vector3 pos, Quaternion rot, float overridePreviousPerc) GetPose(Vector3 pos, Quaternion rot);
		}

		public struct OGPoseAnimationHelper
		{
			public Transform animationTarget;

			public Vector3 localPos;

			public Quaternion localRot;

			public void SetAnimationStartValues()
			{
				localPos = animationTarget.InverseTransformPoint(SingletonBehaviour<ItemPositionController>.Instance.itemAnchor.position);
				localRot = Quaternion.Inverse(animationTarget.rotation) * SingletonBehaviour<ItemPositionController>.Instance.itemAnchor.rotation;
			}

			public void SetAnimationStopValues(Vector3 pos, Quaternion rot)
			{
				localPos = animationTarget.InverseTransformPoint(pos);
				localRot = Quaternion.Inverse(animationTarget.rotation) * rot;
			}

			public (Vector3 pos, Quaternion rot, float overridePreviousPerc) GetPose(Transform interactionPoint, ItemWorkingAnimation itemWorkingAnimation)
			{
				if (animationTarget == null)
				{
					return default((Vector3, Quaternion, float));
				}
				float num = ItemWorkingAnimation.EaseInCubic(itemWorkingAnimation.MoveToWorkProgress);
				if (itemWorkingAnimation.WorkDone)
				{
					(Vector3, Quaternion) tuple = TransformUtils.CalculateAlignmentTargets(SingletonBehaviour<ItemPositionController>.Instance.itemAnchor, animationTarget.TransformPoint(localPos), animationTarget.rotation * localRot, interactionPoint);
					return (pos: tuple.Item1, rot: tuple.Item2, overridePreviousPerc: num);
				}
				(Vector3, Quaternion) tuple2 = TransformUtils.CalculateAlignmentTargets(SingletonBehaviour<ItemPositionController>.Instance.itemAnchor, animationTarget, interactionPoint);
				Vector3 a = animationTarget.TransformPoint(localPos);
				Quaternion a2 = animationTarget.rotation * localRot;
				tuple2.Item1 = Vector3.Lerp(a, tuple2.Item1, num);
				tuple2.Item2 = Quaternion.Slerp(a2, tuple2.Item2, num);
				return (pos: tuple2.Item1, rot: tuple2.Item2, overridePreviousPerc: 1f);
			}
		}

		private readonly List<IPositionProvider> providers = new List<IPositionProvider>();

		public Transform itemAnchor;

		public int Priority => -1;

		public new static string AllowAutoCreate()
		{
			return null;
		}

		protected override void Awake()
		{
			base.Awake();
			Add(this);
		}

		private void LateUpdate()
		{
			RefreshPose();
		}

		private void RefreshPose()
		{
			Vector3 vector = base.transform.position;
			Quaternion quaternion = base.transform.rotation;
			foreach (IPositionProvider provider in providers)
			{
				(Vector3 pos, Quaternion rot, float overridePreviousPerc) pose = provider.GetPose(vector, quaternion);
				Vector3 item = pose.pos;
				Quaternion item2 = pose.rot;
				float item3 = pose.overridePreviousPerc;
				vector = Vector3.Lerp(vector, item, item3);
				quaternion = Quaternion.Slerp(quaternion, item2, item3);
			}
			itemAnchor.SetPositionAndRotation(vector, quaternion);
		}

		public void UpdatePriorityOrder()
		{
			providers.Sort((IPositionProvider a, IPositionProvider b) => a.Priority.CompareTo(b.Priority));
		}

		public void Add(IPositionProvider provider)
		{
			providers.Add(provider);
			UpdatePriorityOrder();
		}

		public void Remove(IPositionProvider provider)
		{
			providers.Remove(provider);
		}

		public (Vector3 pos, Quaternion rot, float overridePreviousPerc) GetPose(Vector3 pos, Quaternion rot)
		{
			return (pos: pos, rot: rot, overridePreviousPerc: 0f);
		}
	}
}
