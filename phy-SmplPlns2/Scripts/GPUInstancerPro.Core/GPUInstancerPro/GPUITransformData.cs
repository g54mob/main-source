using System;
using UnityEngine;

namespace GPUInstancerPro
{
	[Serializable]
	public struct GPUITransformData : IEquatable<GPUITransformData>
	{
		public Vector3 position;

		public Quaternion rotation;

		public Vector3 scale;

		public const int STRIDE = 40;

		private static readonly string TO_STRING_TEXT = "Position: {0}, Rotation: {1}, Scale: {2}";

		public void SetFromMatrix(Matrix4x4 matrix)
		{
			position = matrix.GetPosition();
			rotation = matrix.rotation;
			scale = matrix.lossyScale;
		}

		public Matrix4x4 ToMatrix()
		{
			return Matrix4x4.TRS(position, rotation, scale);
		}

		public void SetToTransform(Transform transform)
		{
			transform.SetPositionAndRotation(position, rotation);
			transform.localScale = scale;
		}

		public void SetTransformRelativeToParent(Matrix4x4 parentLTW, Matrix4x4 childLTW)
		{
			float m = parentLTW.m00;
			float m2 = parentLTW.m01;
			float m3 = parentLTW.m02;
			float m4 = parentLTW.m10;
			float m5 = parentLTW.m11;
			float m6 = parentLTW.m12;
			float m7 = parentLTW.m20;
			float m8 = parentLTW.m21;
			float m9 = parentLTW.m22;
			float num = (float)Math.Sqrt(m * m + m4 * m4 + m7 * m7);
			float num2 = (float)Math.Sqrt(m2 * m2 + m5 * m5 + m8 * m8);
			float num3 = (float)Math.Sqrt(m3 * m3 + m6 * m6 + m9 * m9);
			float num4 = 1f / num;
			float num5 = 1f / num2;
			float num6 = 1f / num3;
			float num7 = m * num4;
			float num8 = m2 * num5;
			float num9 = m3 * num6;
			float num10 = m4 * num4;
			float num11 = m5 * num5;
			float num12 = m6 * num6;
			float num13 = m7 * num4;
			float num14 = m8 * num5;
			float num15 = m9 * num6;
			float m10 = childLTW.m00;
			float m11 = childLTW.m01;
			float m12 = childLTW.m02;
			float m13 = childLTW.m10;
			float m14 = childLTW.m11;
			float m15 = childLTW.m12;
			float m16 = childLTW.m20;
			float m17 = childLTW.m21;
			float m18 = childLTW.m22;
			float num16 = (float)Math.Sqrt(m10 * m10 + m13 * m13 + m16 * m16);
			float num17 = (float)Math.Sqrt(m11 * m11 + m14 * m14 + m17 * m17);
			float num18 = (float)Math.Sqrt(m12 * m12 + m15 * m15 + m18 * m18);
			float num19 = 1f / num16;
			float num20 = 1f / num17;
			float num21 = 1f / num18;
			scale.x = num16 * num4;
			scale.y = num17 * num5;
			scale.z = num18 * num6;
			float num22 = m10 * num19;
			float num23 = m11 * num20;
			float num24 = m12 * num21;
			float num25 = m13 * num19;
			float num26 = m14 * num20;
			float num27 = m15 * num21;
			float num28 = m16 * num19;
			float num29 = m17 * num20;
			float num30 = m18 * num21;
			float num31 = num7;
			float num32 = num10;
			float num33 = num13;
			float num34 = num8;
			float num35 = num11;
			float num36 = num14;
			float num37 = num9;
			float num38 = num12;
			float num39 = num15;
			float num40 = num31 * num22 + num32 * num25 + num33 * num28;
			float num41 = num31 * num23 + num32 * num26 + num33 * num29;
			float num42 = num31 * num24 + num32 * num27 + num33 * num30;
			float num43 = num34 * num22 + num35 * num25 + num36 * num28;
			float num44 = num34 * num23 + num35 * num26 + num36 * num29;
			float num45 = num34 * num24 + num35 * num27 + num36 * num30;
			float num46 = num37 * num22 + num38 * num25 + num39 * num28;
			float num47 = num37 * num23 + num38 * num26 + num39 * num29;
			float num48 = num37 * num24 + num38 * num27 + num39 * num30;
			float num49 = num40 + num44 + num48;
			float w;
			float x;
			float y;
			float z;
			if (num49 > 0f)
			{
				float num50 = (float)Math.Sqrt(num49 + 1f) * 0.5f;
				float num51 = 0.25f / num50;
				w = num50;
				x = (num47 - num45) * num51;
				y = (num42 - num46) * num51;
				z = (num43 - num41) * num51;
			}
			else if (num40 > num44 && num40 > num48)
			{
				float num52 = (float)Math.Sqrt(1f + num40 - num44 - num48) * 0.5f;
				float num53 = 0.25f / num52;
				w = (num47 - num45) * num53;
				x = num52;
				y = (num41 + num43) * num53;
				z = (num42 + num46) * num53;
			}
			else if (num44 > num48)
			{
				float num54 = (float)Math.Sqrt(1f + num44 - num40 - num48) * 0.5f;
				float num55 = 0.25f / num54;
				w = (num42 - num46) * num55;
				x = (num41 + num43) * num55;
				y = num54;
				z = (num45 + num47) * num55;
			}
			else
			{
				float num56 = (float)Math.Sqrt(1f + num48 - num40 - num44) * 0.5f;
				float num57 = 0.25f / num56;
				w = (num43 - num41) * num57;
				x = (num42 + num46) * num57;
				y = (num45 + num47) * num57;
				z = num56;
			}
			rotation.x = x;
			rotation.y = y;
			rotation.z = z;
			rotation.w = w;
			float num58 = childLTW.m03 - parentLTW.m03;
			float num59 = childLTW.m13 - parentLTW.m13;
			float num60 = childLTW.m23 - parentLTW.m23;
			position.x = (num31 * num58 + num32 * num59 + num33 * num60) * num4;
			position.y = (num34 * num58 + num35 * num59 + num36 * num60) * num5;
			position.z = (num37 * num58 + num38 * num59 + num39 * num60) * num6;
		}

		public bool Equals(GPUITransformData other)
		{
			if (position == other.position && rotation == other.rotation)
			{
				return scale == other.scale;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is GPUITransformData other)
			{
				return Equals(other);
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return GPUIUtility.GenerateHash(position.GetHashCode(), rotation.GetHashCode(), scale.GetHashCode());
		}

		public static bool operator ==(GPUITransformData left, GPUITransformData right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(GPUITransformData left, GPUITransformData right)
		{
			return !(left == right);
		}

		public override string ToString()
		{
			return string.Format(TO_STRING_TEXT, position.ToString("F4"), rotation.ToString("F4"), scale.ToString("F4"));
		}
	}
}
