using System;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class ButtonLoopSet : UpdateLoopDataSet<ButtonLoopSet.ButtonData>
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public class ButtonData
		{
			public readonly UpdateLoopType updateLoop;

			public readonly bool[] values;

			public readonly bool[] wasTrueThisFrame;

			private bool[] hzTSFnqrIXckvwvkPsVkTBuojXi;

			private int sbGFHscUNYuLueCujdpZsnDRyNre;

			private readonly bool[] PngmVOqYEQCDljhpjWSazgEQcBBv;

			private readonly bool[] mwDfejrGtiJBBUGqAaSUbQopuSkqA;

			public bool[] effectiveValue
			{
				get
				{
					if (updateLoop == UpdateLoopType.FixedUpdate)
					{
						EZZqNyrGDvTjpwRrXdNiDYYGvuul();
					}
					return hzTSFnqrIXckvwvkPsVkTBuojXi;
				}
			}

			public ButtonData(int P_0, UpdateLoopType P_1)
			{
				updateLoop = P_1;
				values = new bool[P_0];
				mwDfejrGtiJBBUGqAaSUbQopuSkqA = new bool[P_0];
				wasTrueThisFrame = new bool[P_0];
				PngmVOqYEQCDljhpjWSazgEQcBBv = new bool[P_0];
				hzTSFnqrIXckvwvkPsVkTBuojXi = new bool[P_0];
				sbGFHscUNYuLueCujdpZsnDRyNre = ReInput.timeScalePauseChangedCount;
			}

			public void SetValue(int index, bool value)
			{
				if (updateLoop == UpdateLoopType.FixedUpdate)
				{
					EZZqNyrGDvTjpwRrXdNiDYYGvuul();
				}
				values[index] = value;
				if (value)
				{
					wasTrueThisFrame[index] = true;
					if (!mwDfejrGtiJBBUGqAaSUbQopuSkqA[index])
					{
						PngmVOqYEQCDljhpjWSazgEQcBBv[index] = true;
					}
				}
				hzTSFnqrIXckvwvkPsVkTBuojXi[index] = value | PngmVOqYEQCDljhpjWSazgEQcBBv[index];
				mwDfejrGtiJBBUGqAaSUbQopuSkqA[index] = value;
			}

			public void ClearWasTrueThisFrame()
			{
				for (int i = 0; i < values.Length; i++)
				{
					wasTrueThisFrame[i] = false;
					PngmVOqYEQCDljhpjWSazgEQcBBv[i] = false;
					hzTSFnqrIXckvwvkPsVkTBuojXi[i] = values[i];
				}
			}

			public void Clear()
			{
				Array.Clear(values, 0, values.Length);
				Array.Clear(mwDfejrGtiJBBUGqAaSUbQopuSkqA, 0, values.Length);
				Array.Clear(wasTrueThisFrame, 0, wasTrueThisFrame.Length);
				Array.Clear(PngmVOqYEQCDljhpjWSazgEQcBBv, 0, PngmVOqYEQCDljhpjWSazgEQcBBv.Length);
				Array.Clear(hzTSFnqrIXckvwvkPsVkTBuojXi, 0, hzTSFnqrIXckvwvkPsVkTBuojXi.Length);
				sbGFHscUNYuLueCujdpZsnDRyNre = ReInput.timeScalePauseChangedCount;
			}

			public void Import(ButtonData source)
			{
				if (source != null)
				{
					int num = MathTools.Min(values.Length, source.values.Length);
					for (int i = 0; i < num; i++)
					{
						values[i] = source.values[i];
						mwDfejrGtiJBBUGqAaSUbQopuSkqA[i] = source.mwDfejrGtiJBBUGqAaSUbQopuSkqA[i];
						wasTrueThisFrame[i] = source.wasTrueThisFrame[i];
						PngmVOqYEQCDljhpjWSazgEQcBBv[i] = source.PngmVOqYEQCDljhpjWSazgEQcBBv[i];
						hzTSFnqrIXckvwvkPsVkTBuojXi[i] = source.hzTSFnqrIXckvwvkPsVkTBuojXi[i];
						sbGFHscUNYuLueCujdpZsnDRyNre = source.sbGFHscUNYuLueCujdpZsnDRyNre;
					}
				}
			}

			private void EZZqNyrGDvTjpwRrXdNiDYYGvuul()
			{
				if (ReInput.timeScalePauseChangedCount != sbGFHscUNYuLueCujdpZsnDRyNre)
				{
					ClearWasTrueThisFrame();
					sbGFHscUNYuLueCujdpZsnDRyNre = ReInput.timeScalePauseChangedCount;
				}
			}
		}

		public readonly int buttonCount;

		public ButtonLoopSet(UpdateLoopSetting P_0, int P_1)
			: base(P_0)
		{
			buttonCount = P_1;
			for (int i = 0; i < base.Count; i++)
			{
				base[i] = new ButtonData(P_1, GetUpdateLoopType(i));
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
