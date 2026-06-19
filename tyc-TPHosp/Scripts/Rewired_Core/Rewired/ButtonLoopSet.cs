using System;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal class ButtonLoopSet : UpdateLoopDataSet<ButtonLoopSet.ButtonData>
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public class ButtonData
		{
			public readonly UpdateLoopType updateLoop;

			public readonly bool[] values;

			public readonly bool[] wasTrueThisFrame;

			private bool[] wzzLEodVqvYdqqxWjocODPkBktT;

			private int lQLynqcqxnlnrKdcONiHfBgsCZ;

			private readonly bool[] CpqdaLgjolGPwIsvcTdJEQIdoXjS;

			private readonly bool[] fxVnwcnHZVAmCHVkPdyrrJcMEGI;

			public bool[] effectiveValue
			{
				get
				{
					if (updateLoop == UpdateLoopType.FixedUpdate)
					{
						TzPMHvnTvCHmszTdKFaXckEfjtEI();
					}
					return wzzLEodVqvYdqqxWjocODPkBktT;
				}
			}

			public ButtonData(int count, UpdateLoopType updateLoop)
			{
				this.updateLoop = updateLoop;
				values = new bool[count];
				fxVnwcnHZVAmCHVkPdyrrJcMEGI = new bool[count];
				wasTrueThisFrame = new bool[count];
				CpqdaLgjolGPwIsvcTdJEQIdoXjS = new bool[count];
				wzzLEodVqvYdqqxWjocODPkBktT = new bool[count];
				lQLynqcqxnlnrKdcONiHfBgsCZ = ReInput.timeScalePauseChangedCount;
			}

			public void SetValue(int index, bool value)
			{
				if (updateLoop == UpdateLoopType.FixedUpdate)
				{
					TzPMHvnTvCHmszTdKFaXckEfjtEI();
				}
				values[index] = value;
				if (value)
				{
					wasTrueThisFrame[index] = true;
					if (!fxVnwcnHZVAmCHVkPdyrrJcMEGI[index])
					{
						CpqdaLgjolGPwIsvcTdJEQIdoXjS[index] = true;
					}
				}
				wzzLEodVqvYdqqxWjocODPkBktT[index] = value | CpqdaLgjolGPwIsvcTdJEQIdoXjS[index];
				fxVnwcnHZVAmCHVkPdyrrJcMEGI[index] = value;
			}

			public void ClearWasTrueThisFrame()
			{
				for (int i = 0; i < values.Length; i++)
				{
					wasTrueThisFrame[i] = false;
					CpqdaLgjolGPwIsvcTdJEQIdoXjS[i] = false;
					wzzLEodVqvYdqqxWjocODPkBktT[i] = values[i];
				}
			}

			public void Clear()
			{
				Array.Clear(values, 0, values.Length);
				Array.Clear(fxVnwcnHZVAmCHVkPdyrrJcMEGI, 0, values.Length);
				Array.Clear(wasTrueThisFrame, 0, wasTrueThisFrame.Length);
				Array.Clear(CpqdaLgjolGPwIsvcTdJEQIdoXjS, 0, CpqdaLgjolGPwIsvcTdJEQIdoXjS.Length);
				Array.Clear(wzzLEodVqvYdqqxWjocODPkBktT, 0, wzzLEodVqvYdqqxWjocODPkBktT.Length);
				lQLynqcqxnlnrKdcONiHfBgsCZ = ReInput.timeScalePauseChangedCount;
			}

			public void Import(ButtonData source)
			{
				if (source != null)
				{
					int num = MathTools.Min(values.Length, source.values.Length);
					for (int i = 0; i < num; i++)
					{
						values[i] = source.values[i];
						fxVnwcnHZVAmCHVkPdyrrJcMEGI[i] = source.fxVnwcnHZVAmCHVkPdyrrJcMEGI[i];
						wasTrueThisFrame[i] = source.wasTrueThisFrame[i];
						CpqdaLgjolGPwIsvcTdJEQIdoXjS[i] = source.CpqdaLgjolGPwIsvcTdJEQIdoXjS[i];
						wzzLEodVqvYdqqxWjocODPkBktT[i] = source.wzzLEodVqvYdqqxWjocODPkBktT[i];
						lQLynqcqxnlnrKdcONiHfBgsCZ = source.lQLynqcqxnlnrKdcONiHfBgsCZ;
					}
				}
			}

			private void TzPMHvnTvCHmszTdKFaXckEfjtEI()
			{
				if (ReInput.timeScalePauseChangedCount != lQLynqcqxnlnrKdcONiHfBgsCZ)
				{
					ClearWasTrueThisFrame();
					lQLynqcqxnlnrKdcONiHfBgsCZ = ReInput.timeScalePauseChangedCount;
				}
			}
		}

		public readonly int buttonCount;

		public ButtonLoopSet(UpdateLoopSetting updateLoops, int buttonCount)
			: base(updateLoops)
		{
			this.buttonCount = buttonCount;
			for (int i = 0; i < base.Count; i++)
			{
				base[i] = new ButtonData(buttonCount, GetUpdateLoopType(i));
			}
		}

		public void SetValue(int index, bool value, double timestamp)
		{
			int count = base.Count;
			for (int i = 0; i < count; i++)
			{
				base[i].SetValue(index, value);
			}
		}

		public void Clear()
		{
			int count = base.Count;
			for (int i = 0; i < count; i++)
			{
				base[i].Clear();
			}
		}

		public void Import(ButtonLoopSet set)
		{
			if (set == null)
			{
				throw new ArgumentNullException("set");
			}
			if (set.buttonCount != buttonCount)
			{
				throw new Exception("Cannot import from a set with a different button count.");
			}
			for (int i = 0; i < base.Count; i++)
			{
				base[i].Import(set[i]);
			}
		}
	}
}
