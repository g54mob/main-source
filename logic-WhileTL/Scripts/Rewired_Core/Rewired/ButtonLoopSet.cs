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

			private bool[] OAvhEQHOXCggSMMFBoflzzobNiZW;

			private int ByCjOnWKyMgHIgLcOKHplfQOTeviA;

			private readonly bool[] kWuBdDdYcSItZoIRMNcCPqvNaTHMA;

			private readonly bool[] FFZXoeDzBesyvrdGvjakFkVqYCeM;

			public bool[] effectiveValue
			{
				get
				{
					if (updateLoop == UpdateLoopType.FixedUpdate)
					{
						tCPWSrLjrpUlHTbFuvNAYydBlOug();
					}
					return OAvhEQHOXCggSMMFBoflzzobNiZW;
				}
			}

			public ButtonData(int P_0, UpdateLoopType P_1)
			{
				updateLoop = P_1;
				values = new bool[P_0];
				FFZXoeDzBesyvrdGvjakFkVqYCeM = new bool[P_0];
				wasTrueThisFrame = new bool[P_0];
				kWuBdDdYcSItZoIRMNcCPqvNaTHMA = new bool[P_0];
				OAvhEQHOXCggSMMFBoflzzobNiZW = new bool[P_0];
				ByCjOnWKyMgHIgLcOKHplfQOTeviA = ReInput.timeScalePauseChangedCount;
			}

			public void SetValue(int index, bool value)
			{
				if (updateLoop == UpdateLoopType.FixedUpdate)
				{
					tCPWSrLjrpUlHTbFuvNAYydBlOug();
				}
				values[index] = value;
				if (value)
				{
					wasTrueThisFrame[index] = true;
					if (!FFZXoeDzBesyvrdGvjakFkVqYCeM[index])
					{
						kWuBdDdYcSItZoIRMNcCPqvNaTHMA[index] = true;
					}
				}
				OAvhEQHOXCggSMMFBoflzzobNiZW[index] = value | kWuBdDdYcSItZoIRMNcCPqvNaTHMA[index];
				FFZXoeDzBesyvrdGvjakFkVqYCeM[index] = value;
			}

			public void ClearWasTrueThisFrame()
			{
				for (int i = 0; i < values.Length; i++)
				{
					wasTrueThisFrame[i] = false;
					kWuBdDdYcSItZoIRMNcCPqvNaTHMA[i] = false;
					OAvhEQHOXCggSMMFBoflzzobNiZW[i] = values[i];
				}
			}

			public void Clear()
			{
				Array.Clear(values, 0, values.Length);
				Array.Clear(FFZXoeDzBesyvrdGvjakFkVqYCeM, 0, values.Length);
				Array.Clear(wasTrueThisFrame, 0, wasTrueThisFrame.Length);
				Array.Clear(kWuBdDdYcSItZoIRMNcCPqvNaTHMA, 0, kWuBdDdYcSItZoIRMNcCPqvNaTHMA.Length);
				Array.Clear(OAvhEQHOXCggSMMFBoflzzobNiZW, 0, OAvhEQHOXCggSMMFBoflzzobNiZW.Length);
				ByCjOnWKyMgHIgLcOKHplfQOTeviA = ReInput.timeScalePauseChangedCount;
			}

			public void Import(ButtonData source)
			{
				if (source != null)
				{
					int num = MathTools.Min(values.Length, source.values.Length);
					for (int i = 0; i < num; i++)
					{
						values[i] = source.values[i];
						FFZXoeDzBesyvrdGvjakFkVqYCeM[i] = source.FFZXoeDzBesyvrdGvjakFkVqYCeM[i];
						wasTrueThisFrame[i] = source.wasTrueThisFrame[i];
						kWuBdDdYcSItZoIRMNcCPqvNaTHMA[i] = source.kWuBdDdYcSItZoIRMNcCPqvNaTHMA[i];
						OAvhEQHOXCggSMMFBoflzzobNiZW[i] = source.OAvhEQHOXCggSMMFBoflzzobNiZW[i];
						ByCjOnWKyMgHIgLcOKHplfQOTeviA = source.ByCjOnWKyMgHIgLcOKHplfQOTeviA;
					}
				}
			}

			private void tCPWSrLjrpUlHTbFuvNAYydBlOug()
			{
				if (ReInput.timeScalePauseChangedCount != ByCjOnWKyMgHIgLcOKHplfQOTeviA)
				{
					ClearWasTrueThisFrame();
					ByCjOnWKyMgHIgLcOKHplfQOTeviA = ReInput.timeScalePauseChangedCount;
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
