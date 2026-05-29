using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FieldRangeAttribute : PropertyAttribute
	{
		private float dTEzPzYGYQQdvfeHjUPIdmelYAe;

		private float sbrPMpdFrwIOowAzMfkkxWyJoXY;

		private int gKWGEWMJCECFHxNlphmrCgSKdIQj;

		private int biCJwWxgOsVeUhZjzbXWtsTssvT;

		public float minFloat
		{
			get
			{
				return dTEzPzYGYQQdvfeHjUPIdmelYAe;
			}
		}

		public float maxFloat
		{
			get
			{
				return sbrPMpdFrwIOowAzMfkkxWyJoXY;
			}
		}

		public int minInt
		{
			get
			{
				return gKWGEWMJCECFHxNlphmrCgSKdIQj;
			}
		}

		public int maxInt
		{
			get
			{
				return biCJwWxgOsVeUhZjzbXWtsTssvT;
			}
		}

		public FieldRangeAttribute(float min, float max)
		{
			dTEzPzYGYQQdvfeHjUPIdmelYAe = min;
			sbrPMpdFrwIOowAzMfkkxWyJoXY = max;
			gKWGEWMJCECFHxNlphmrCgSKdIQj = (int)min;
			biCJwWxgOsVeUhZjzbXWtsTssvT = (int)max;
		}

		public FieldRangeAttribute(int min, int max)
		{
			gKWGEWMJCECFHxNlphmrCgSKdIQj = min;
			biCJwWxgOsVeUhZjzbXWtsTssvT = max;
			dTEzPzYGYQQdvfeHjUPIdmelYAe = min;
			sbrPMpdFrwIOowAzMfkkxWyJoXY = max;
		}
	}
}
