using System;
using Rewired.Config;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class HIDControllerElementWithDataSet : HIDControllerElement
	{
		internal abstract class rZZopsCONEjDBzXsfIOkTAibxer
		{
			private int gzGfWMXUWrnaZFKoWWTcXObcvyo;

			private int[] VdXMZTXHfpbDBhFlxBxZTfGUXwJ;

			protected ReLcOqdSZnQWUohlKcliSEYkNGb[] GrZfYEkTEvFfsrQqENXvXJLTbTq;

			public ReLcOqdSZnQWUohlKcliSEYkNGb DNsUOSgZQrgrzaoVIbqmnEQQRth;

			private int bjflEjOceXoNSbWyZHEtmnfxUuN;

			private int jjQGkKiJZUcpHvqNiAQVtjTfEtI;

			private bool yguPpeqEjThrBNXEFhOahcAYtXtO;

			protected int dataCount => 0;

			protected int[] updateLoopIndex => null;

			public UpdateLoopType updateLoop
			{
				set
				{
				}
			}

			public rZZopsCONEjDBzXsfIOkTAibxer()
			{
			}

			public void smyDvsBdQzVENdngxmjCEKXFcwcE(UpdateLoopSetting P_0, Func<UpdateLoopType, ReLcOqdSZnQWUohlKcliSEYkNGb> P_1)
			{
			}

			private void LKAHOPtmmUlPqYnnDKRmlaxTgCs(UpdateLoopType P_0, ReLcOqdSZnQWUohlKcliSEYkNGb P_1)
			{
			}

			public virtual void oDVbwUgIfbSDvfmIInVcyfSKnKRm(UpdateLoopType P_0)
			{
			}

			public void wcDfhuvvIloonVFErZkAXwihlbn()
			{
			}
		}

		internal abstract class ReLcOqdSZnQWUohlKcliSEYkNGb
		{
			public readonly UpdateLoopType OtdyoVgHZlkVzcXpmFOkbCpToVK;

			public ReLcOqdSZnQWUohlKcliSEYkNGb(UpdateLoopType updateLoop)
			{
			}

			public abstract void wcDfhuvvIloonVFErZkAXwihlbn();
		}

		internal rZZopsCONEjDBzXsfIOkTAibxer dataSet;

		public HIDControllerElementWithDataSet(rZZopsCONEjDBzXsfIOkTAibxer dataSet, byte reportId, HIDInfo hidInfo)
			: base(0, null)
		{
		}

		public virtual void Update(UpdateLoopType updateLoop)
		{
		}
	}
}
