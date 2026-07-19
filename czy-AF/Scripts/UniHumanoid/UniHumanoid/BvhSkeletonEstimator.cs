using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UniHumanoid
{
	public class BvhSkeletonEstimator : ISkeletonDetector
	{
		private struct Arm
		{
			public IBone Shoulder;

			public IBone UpperArm;

			public IBone LowerArm;

			public IBone Hand;
		}

		private struct Leg
		{
			public IBone UpperLeg;

			public IBone LowerLeg;

			public IBone Foot;

			public IBone Toes;
		}

		private static IBone GetRoot(IList<IBone> bones)
		{
			IBone[] array = bones.Where((IBone x) => x.Parent == null).ToArray();
			if (array.Length != 1)
			{
				throw new Exception("Require unique root");
			}
			return array[0];
		}

		private static IBone SelectBone(Func<IBone, IBone, IBone> selector, IList<IBone> bones)
		{
			if (bones == null || bones.Count == 0)
			{
				throw new Exception("no bones");
			}
			IBone bone = bones[0];
			for (int i = 1; i < bones.Count; i++)
			{
				bone = selector(bone, bones[i]);
			}
			return bone;
		}

		private static void GetSpineAndHips(IBone hips, out IBone spine, out IBone leg_L, out IBone leg_R)
		{
			if (hips.Children.Count != 3)
			{
				throw new Exception("Hips require 3 children");
			}
			spine = SelectBone((IBone l, IBone r) => (!(l.CenterOfDescendant().y > r.CenterOfDescendant().y)) ? r : l, hips.Children);
			leg_L = SelectBone((IBone l, IBone r) => (!(l.CenterOfDescendant().x < r.CenterOfDescendant().x)) ? r : l, hips.Children);
			leg_R = SelectBone((IBone l, IBone r) => (!(l.CenterOfDescendant().x > r.CenterOfDescendant().x)) ? r : l, hips.Children);
		}

		private static void GetNeckAndArms(IBone chest, out IBone neck, out IBone arm_L, out IBone arm_R)
		{
			if (chest.Children.Count != 3)
			{
				throw new Exception("Chest require 3 children");
			}
			neck = SelectBone((IBone l, IBone r) => (!(l.CenterOfDescendant().y > r.CenterOfDescendant().y)) ? r : l, chest.Children);
			arm_L = SelectBone((IBone l, IBone r) => (!(l.CenterOfDescendant().x < r.CenterOfDescendant().x)) ? r : l, chest.Children);
			arm_R = SelectBone((IBone l, IBone r) => (!(l.CenterOfDescendant().x > r.CenterOfDescendant().x)) ? r : l, chest.Children);
		}

		private Arm GetArm(IBone shoulder)
		{
			IBone[] array = shoulder.Traverse().ToArray();
			int num = array.Length;
			if ((uint)num <= 3u)
			{
				throw new NotImplementedException();
			}
			return new Arm
			{
				Shoulder = array[0],
				UpperArm = array[1],
				LowerArm = array[2],
				Hand = array[3]
			};
		}

		private Leg GetLeg(IBone leg)
		{
			IBone[] array = (from x in leg.Traverse()
				where !x.Name.ToLower().Contains("buttock")
				select x).ToArray();
			switch (array.Length)
			{
			case 0:
			case 1:
			case 2:
				throw new NotImplementedException();
			case 3:
				return new Leg
				{
					UpperLeg = array[0],
					LowerLeg = array[1],
					Foot = array[2]
				};
			default:
				return new Leg
				{
					UpperLeg = array[^4],
					LowerLeg = array[^3],
					Foot = array[^2],
					Toes = array[^1]
				};
			}
		}

		public Skeleton Detect(IList<IBone> bones)
		{
			IBone bone = GetRoot(bones).Traverse().First((IBone x) => x.Children.Count == 3);
			GetSpineAndHips(bone, out var spine, out var leg_L, out var leg_R);
			Leg leg = GetLeg(leg_L);
			Leg leg2 = GetLeg(leg_R);
			List<IBone> list = new List<IBone>();
			foreach (IBone item in spine.Traverse())
			{
				list.Add(item);
				if (item.Children.Count == 3)
				{
					break;
				}
			}
			GetNeckAndArms(list.Last(), out var neck, out var arm_L, out var arm_R);
			Arm arm = GetArm(arm_L);
			Arm arm2 = GetArm(arm_R);
			IBone[] array = neck.Traverse().ToArray();
			Skeleton result = default(Skeleton);
			result.Set(HumanBodyBones.Hips, bones, bone);
			switch (list.Count)
			{
			case 0:
				throw new Exception();
			case 1:
				result.Set(HumanBodyBones.Spine, bones, list[0]);
				break;
			case 2:
				result.Set(HumanBodyBones.Spine, bones, list[0]);
				result.Set(HumanBodyBones.Chest, bones, list[1]);
				break;
			case 3:
				result.Set(HumanBodyBones.Spine, bones, list[0]);
				result.Set(HumanBodyBones.Chest, bones, list[1]);
				result.Set(HumanBodyBones.UpperChest, bones, list[2]);
				break;
			default:
				result.Set(HumanBodyBones.Spine, bones, list[0]);
				result.Set(HumanBodyBones.Chest, bones, list[1]);
				result.Set(HumanBodyBones.UpperChest, bones, list.Last());
				break;
			}
			switch (array.Length)
			{
			case 0:
				throw new Exception();
			case 1:
				result.Set(HumanBodyBones.Head, bones, array[0]);
				break;
			case 2:
				result.Set(HumanBodyBones.Neck, bones, array[0]);
				result.Set(HumanBodyBones.Head, bones, array[1]);
				break;
			default:
				result.Set(HumanBodyBones.Neck, bones, array[0]);
				result.Set(HumanBodyBones.Head, bones, array.Where((IBone x) => x.Parent.Children.Count == 1).Last());
				break;
			}
			result.Set(HumanBodyBones.LeftUpperLeg, bones, leg.UpperLeg);
			result.Set(HumanBodyBones.LeftLowerLeg, bones, leg.LowerLeg);
			result.Set(HumanBodyBones.LeftFoot, bones, leg.Foot);
			result.Set(HumanBodyBones.LeftToes, bones, leg.Toes);
			result.Set(HumanBodyBones.RightUpperLeg, bones, leg2.UpperLeg);
			result.Set(HumanBodyBones.RightLowerLeg, bones, leg2.LowerLeg);
			result.Set(HumanBodyBones.RightFoot, bones, leg2.Foot);
			result.Set(HumanBodyBones.RightToes, bones, leg2.Toes);
			result.Set(HumanBodyBones.LeftShoulder, bones, arm.Shoulder);
			result.Set(HumanBodyBones.LeftUpperArm, bones, arm.UpperArm);
			result.Set(HumanBodyBones.LeftLowerArm, bones, arm.LowerArm);
			result.Set(HumanBodyBones.LeftHand, bones, arm.Hand);
			result.Set(HumanBodyBones.RightShoulder, bones, arm2.Shoulder);
			result.Set(HumanBodyBones.RightUpperArm, bones, arm2.UpperArm);
			result.Set(HumanBodyBones.RightLowerArm, bones, arm2.LowerArm);
			result.Set(HumanBodyBones.RightHand, bones, arm2.Hand);
			return result;
		}

		public Skeleton Detect(Bvh bvh)
		{
			BvhBone bvhBone = new BvhBone(bvh.Root.Name, Vector3.zero);
			bvhBone.Build(bvh.Root);
			return Detect(bvhBone.Traverse().Select((Func<BvhBone, IBone>)((BvhBone x) => x)).ToList());
		}

		public Skeleton Detect(Transform t)
		{
			BvhBone bvhBone = new BvhBone(t.name, Vector3.zero);
			bvhBone.Build(t);
			return Detect(bvhBone.Traverse().Select((Func<BvhBone, IBone>)((BvhBone x) => x)).ToList());
		}
	}
}
