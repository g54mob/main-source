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

			private bool[] OHhFDGCxVffTHxhiAtDuLQgtQsLv;

			private int IeWBREqVELvKUSwQKfLJmFQtIWmk;

			private readonly bool[] rwQycBxYIBLHMujhWEOoCtkHYuHQA;

			private readonly bool[] pOYAuneCqtJpBeXEgeItBAAAwzuOb;

			public bool[] effectiveValue
			{
				get
				{
					if (updateLoop == UpdateLoopType.FixedUpdate)
					{
						toJRyQNhmsngWcdtPRyCVYaRXGah();
					}
					return OHhFDGCxVffTHxhiAtDuLQgtQsLv;
				}
			}

			public ButtonData(int P_0, UpdateLoopType P_1)
			{
				updateLoop = P_1;
				values = new bool[P_0];
				pOYAuneCqtJpBeXEgeItBAAAwzuOb = new bool[P_0];
				wasTrueThisFrame = new bool[P_0];
				rwQycBxYIBLHMujhWEOoCtkHYuHQA = new bool[P_0];
				OHhFDGCxVffTHxhiAtDuLQgtQsLv = new bool[P_0];
				IeWBREqVELvKUSwQKfLJmFQtIWmk = ReInput.timeScalePauseChangedCount;
			}

			public void SetValue(int index, bool value)
			{
				if (updateLoop == UpdateLoopType.FixedUpdate)
				{
					toJRyQNhmsngWcdtPRyCVYaRXGah();
				}
				values[index] = value;
				if (value)
				{
					wasTrueThisFrame[index] = true;
					if (!pOYAuneCqtJpBeXEgeItBAAAwzuOb[index])
					{
						rwQycBxYIBLHMujhWEOoCtkHYuHQA[index] = true;
					}
				}
				OHhFDGCxVffTHxhiAtDuLQgtQsLv[index] = value | rwQycBxYIBLHMujhWEOoCtkHYuHQA[index];
				pOYAuneCqtJpBeXEgeItBAAAwzuOb[index] = value;
			}

			public void ClearWasTrueThisFrame()
			{
				for (int i = 0; i < values.Length; i++)
				{
					wasTrueThisFrame[i] = false;
					rwQycBxYIBLHMujhWEOoCtkHYuHQA[i] = false;
					OHhFDGCxVffTHxhiAtDuLQgtQsLv[i] = values[i];
				}
			}

			public void Clear()
			{
				Array.Clear(values, 0, values.Length);
				Array.Clear(pOYAuneCqtJpBeXEgeItBAAAwzuOb, 0, values.Length);
				Array.Clear(wasTrueThisFrame, 0, wasTrueThisFrame.Length);
				Array.Clear(rwQycBxYIBLHMujhWEOoCtkHYuHQA, 0, rwQycBxYIBLHMujhWEOoCtkHYuHQA.Length);
				Array.Clear(OHhFDGCxVffTHxhiAtDuLQgtQsLv, 0, OHhFDGCxVffTHxhiAtDuLQgtQsLv.Length);
				IeWBREqVELvKUSwQKfLJmFQtIWmk = ReInput.timeScalePauseChangedCount;
			}

			public void Import(ButtonData source)
			{
				if (source != null)
				{
					int num = MathTools.Min(values.Length, source.values.Length);
					for (int i = 0; i < num; i++)
					{
						values[i] = source.values[i];
						pOYAuneCqtJpBeXEgeItBAAAwzuOb[i] = source.pOYAuneCqtJpBeXEgeItBAAAwzuOb[i];
						wasTrueThisFrame[i] = source.wasTrueThisFrame[i];
						rwQycBxYIBLHMujhWEOoCtkHYuHQA[i] = source.rwQycBxYIBLHMujhWEOoCtkHYuHQA[i];
						OHhFDGCxVffTHxhiAtDuLQgtQsLv[i] = source.OHhFDGCxVffTHxhiAtDuLQgtQsLv[i];
						IeWBREqVELvKUSwQKfLJmFQtIWmk = source.IeWBREqVELvKUSwQKfLJmFQtIWmk;
					}
				}
			}

			private void toJRyQNhmsngWcdtPRyCVYaRXGah()
			{
				if (ReInput.timeScalePauseChangedCount != IeWBREqVELvKUSwQKfLJmFQtIWmk)
				{
					ClearWasTrueThisFrame();
					IeWBREqVELvKUSwQKfLJmFQtIWmk = ReInput.timeScalePauseChangedCount;
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
