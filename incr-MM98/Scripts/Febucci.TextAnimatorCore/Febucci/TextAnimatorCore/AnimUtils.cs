using System;
using System.Collections.Generic;
using Febucci.Numbers;

namespace Febucci.TextAnimatorCore
{
	public static class AnimUtils
	{
		private static Vector3[] fakeRandoms;

		public const int FakeRandomsCount = 25;

		private static bool initialized;

		public static Vector3[] FakeRandoms => fakeRandoms;

		public static void Initialize()
		{
			if (!initialized)
			{
				initialized = true;
				List<Vector3> list = new List<Vector3>();
				for (float num = 0f; num < 360f; num += 14.4f)
				{
					float num2 = num * (MathF.PI / 180f);
					list.Add(new Vector3((float)Math.Sin(num2), (float)Math.Cos(num2), 0f).normalized);
				}
				fakeRandoms = new Vector3[25];
				Random random = new Random(0);
				for (int i = 0; i < fakeRandoms.Length; i++)
				{
					int index = random.Next(0, list.Count);
					fakeRandoms[i] = list[index] * Math.Sign((float)Math.Sin(i));
					list.RemoveAt(index);
				}
			}
		}

		public static Vector3 RotateAround(this Vector3 vec, Vector2 center, float rotDegrees)
		{
			rotDegrees *= MathF.PI / 180f;
			float num = vec.X - center.X;
			float num2 = vec.Y - center.Y;
			float num3 = num * (float)Math.Cos(rotDegrees) - num2 * (float)Math.Sin(rotDegrees);
			float num4 = num * (float)Math.Sin(rotDegrees) + num2 * (float)Math.Cos(rotDegrees);
			vec.X = num3 + center.X;
			vec.Y = num4 + center.Y;
			return vec;
		}
	}
}
