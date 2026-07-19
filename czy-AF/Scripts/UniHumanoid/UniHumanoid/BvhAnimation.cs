using System;
using System.Collections.Generic;
using UnityEngine;

namespace UniHumanoid
{
	public static class BvhAnimation
	{
		private class CurveSet
		{
			private BvhNode Node;

			private Func<float, float, float, Quaternion> EulerToRotation;

			public ChannelCurve PositionX;

			public ChannelCurve PositionY;

			public ChannelCurve PositionZ;

			public ChannelCurve RotationX;

			public ChannelCurve RotationY;

			public ChannelCurve RotationZ;

			public CurveSet(BvhNode node)
			{
				Node = node;
			}

			public Vector3 GetPosition(int i)
			{
				return new Vector3(PositionX.Keys[i], PositionY.Keys[i], PositionZ.Keys[i]);
			}

			public Quaternion GetRotation(int i)
			{
				if (EulerToRotation == null)
				{
					EulerToRotation = Node.GetEulerToRotation();
				}
				return EulerToRotation(RotationX.Keys[i], RotationY.Keys[i], RotationZ.Keys[i]);
			}

			private static void AddCurve(Bvh bvh, AnimationClip clip, ChannelCurve ch, float scaling)
			{
				if (ch != null)
				{
					Bvh.PathWithProperty pathWithProp = default(Bvh.PathWithProperty);
					bvh.TryGetPathWithPropertyFromChannel(ch, out pathWithProp);
					AnimationCurve animationCurve = new AnimationCurve();
					for (int i = 0; i < bvh.FrameCount; i++)
					{
						float time = (float)((double)i * bvh.FrameTime.TotalSeconds);
						float value = ch.Keys[i] * scaling;
						animationCurve.AddKey(time, value);
					}
					clip.SetCurve(pathWithProp.Path, typeof(Transform), pathWithProp.Property, animationCurve);
				}
			}

			public void AddCurves(Bvh bvh, AnimationClip clip, float scaling)
			{
				AddCurve(bvh, clip, PositionX, 0f - scaling);
				AddCurve(bvh, clip, PositionY, scaling);
				AddCurve(bvh, clip, PositionZ, scaling);
				Bvh.PathWithProperty pathWithProp = default(Bvh.PathWithProperty);
				bvh.TryGetPathWithPropertyFromChannel(RotationX, out pathWithProp);
				AnimationCurve animationCurve = new AnimationCurve();
				AnimationCurve animationCurve2 = new AnimationCurve();
				AnimationCurve animationCurve3 = new AnimationCurve();
				AnimationCurve animationCurve4 = new AnimationCurve();
				for (int i = 0; i < bvh.FrameCount; i++)
				{
					float time = (float)((double)i * bvh.FrameTime.TotalSeconds);
					Quaternion quaternion = GetRotation(i).ReverseX();
					animationCurve.AddKey(time, quaternion.x);
					animationCurve2.AddKey(time, quaternion.y);
					animationCurve3.AddKey(time, quaternion.z);
					animationCurve4.AddKey(time, quaternion.w);
				}
				clip.SetCurve(pathWithProp.Path, typeof(Transform), "localRotation.x", animationCurve);
				clip.SetCurve(pathWithProp.Path, typeof(Transform), "localRotation.y", animationCurve2);
				clip.SetCurve(pathWithProp.Path, typeof(Transform), "localRotation.z", animationCurve3);
				clip.SetCurve(pathWithProp.Path, typeof(Transform), "localRotation.w", animationCurve4);
			}
		}

		public static AnimationClip CreateAnimationClip(Bvh bvh, float scaling)
		{
			AnimationClip animationClip = new AnimationClip();
			animationClip.legacy = true;
			Dictionary<BvhNode, CurveSet> dictionary = new Dictionary<BvhNode, CurveSet>();
			int num = 0;
			foreach (BvhNode item in bvh.Root.Traverse())
			{
				CurveSet curveSet = (dictionary[item] = new CurveSet(item));
				int num2 = 0;
				while (num2 < item.Channels.Length)
				{
					ChannelCurve channelCurve = bvh.Channels[num];
					switch (item.Channels[num2])
					{
					case Channel.Xposition:
						curveSet.PositionX = channelCurve;
						break;
					case Channel.Yposition:
						curveSet.PositionY = channelCurve;
						break;
					case Channel.Zposition:
						curveSet.PositionZ = channelCurve;
						break;
					case Channel.Xrotation:
						curveSet.RotationX = channelCurve;
						break;
					case Channel.Yrotation:
						curveSet.RotationY = channelCurve;
						break;
					case Channel.Zrotation:
						curveSet.RotationZ = channelCurve;
						break;
					default:
						throw new Exception();
					}
					num2++;
					num++;
				}
			}
			foreach (KeyValuePair<BvhNode, CurveSet> item2 in dictionary)
			{
				item2.Value.AddCurves(bvh, animationClip, scaling);
			}
			animationClip.EnsureQuaternionContinuity();
			return animationClip;
		}
	}
}
