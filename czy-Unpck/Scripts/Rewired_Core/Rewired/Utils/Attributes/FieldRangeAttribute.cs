using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FieldRangeAttribute : PropertyAttribute
	{
		private float UAEjUoEmrUFXiVOegIdXolUidLHG;

		private float NdlfmidRYmfDzOXMFuZngrMECCvE;

		private int VGMniFwmnQWcOMoEyTcmiFeZcRh;

		private int OeCZVBPplunhDIfEgAgLhzvhNky;

		public float minFloat => UAEjUoEmrUFXiVOegIdXolUidLHG;

		public float maxFloat => NdlfmidRYmfDzOXMFuZngrMECCvE;

		public int minInt => VGMniFwmnQWcOMoEyTcmiFeZcRh;

		public int maxInt => OeCZVBPplunhDIfEgAgLhzvhNky;

		public FieldRangeAttribute(float min, float max)
		{
			UAEjUoEmrUFXiVOegIdXolUidLHG = min;
			NdlfmidRYmfDzOXMFuZngrMECCvE = max;
			VGMniFwmnQWcOMoEyTcmiFeZcRh = (int)min;
			OeCZVBPplunhDIfEgAgLhzvhNky = (int)max;
		}

		public FieldRangeAttribute(int min, int max)
		{
			while (true)
			{
				int num = 1234861713;
				while (true)
				{
					switch (num ^ 0x499A7E90)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0024;
					case 2:
						return;
					}
					break;
					IL_0024:
					VGMniFwmnQWcOMoEyTcmiFeZcRh = min;
					OeCZVBPplunhDIfEgAgLhzvhNky = max;
					UAEjUoEmrUFXiVOegIdXolUidLHG = min;
					NdlfmidRYmfDzOXMFuZngrMECCvE = max;
					num = 1234861714;
				}
			}
		}
	}
}
