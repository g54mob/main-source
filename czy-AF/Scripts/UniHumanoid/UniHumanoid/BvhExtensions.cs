using System;
using System.Linq;
using UnityEngine;

namespace UniHumanoid
{
	public static class BvhExtensions
	{
		public static Func<float, float, float, Quaternion> GetEulerToRotation(this BvhNode bvh)
		{
			Channel[] order = bvh.Channels.Where((Channel x) => x == Channel.Xrotation || x == Channel.Yrotation || x == Channel.Zrotation).ToArray();
			return delegate(float x, float y, float z)
			{
				Quaternion quaternion = Quaternion.Euler(x, 0f, 0f);
				Quaternion quaternion2 = Quaternion.Euler(0f, y, 0f);
				Quaternion quaternion3 = Quaternion.Euler(0f, 0f, z);
				Quaternion identity = Quaternion.identity;
				Channel[] array = order;
				for (int i = 0; i < array.Length; i++)
				{
					switch (array[i])
					{
					case Channel.Xrotation:
						identity *= quaternion;
						break;
					case Channel.Yrotation:
						identity *= quaternion2;
						break;
					case Channel.Zrotation:
						identity *= quaternion3;
						break;
					default:
						throw new BvhException("no rotation");
					}
				}
				return identity;
			};
		}

		public static Vector3 ToVector3(this Single3 s3)
		{
			return new Vector3(s3.x, s3.y, s3.z);
		}

		public static Vector3 ToXReversedVector3(this Single3 s3)
		{
			return new Vector3(0f - s3.x, s3.y, s3.z);
		}
	}
}
