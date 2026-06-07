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

			private bool[] HjOsDzLVYIooGnJqqbkZAnsPdadOA;

			private int RVxCPjjcVwmYPACQyAxyCdARFOGy;

			private readonly bool[] wgzCaubuJsviNdslymvBMNgvIezYA;

			private readonly bool[] aFpYyWFZfIYoUVCIMjrKuhWWetMo;

			public bool[] effectiveValue
			{
				get
				{
					if (updateLoop == UpdateLoopType.FixedUpdate)
					{
						codHbwQiDDWTJgdhkihMxGlJBWqA();
					}
					return HjOsDzLVYIooGnJqqbkZAnsPdadOA;
				}
			}

			public ButtonData(int P_0, UpdateLoopType P_1)
			{
				updateLoop = P_1;
				values = new bool[P_0];
				aFpYyWFZfIYoUVCIMjrKuhWWetMo = new bool[P_0];
				wasTrueThisFrame = new bool[P_0];
				wgzCaubuJsviNdslymvBMNgvIezYA = new bool[P_0];
				HjOsDzLVYIooGnJqqbkZAnsPdadOA = new bool[P_0];
				RVxCPjjcVwmYPACQyAxyCdARFOGy = ReInput.timeScalePauseChangedCount;
			}

			public void SetValue(int index, bool value)
			{
				if (updateLoop == UpdateLoopType.FixedUpdate)
				{
					codHbwQiDDWTJgdhkihMxGlJBWqA();
				}
				values[index] = value;
				if (value)
				{
					wasTrueThisFrame[index] = true;
					if (!aFpYyWFZfIYoUVCIMjrKuhWWetMo[index])
					{
						wgzCaubuJsviNdslymvBMNgvIezYA[index] = true;
					}
				}
				HjOsDzLVYIooGnJqqbkZAnsPdadOA[index] = value | wgzCaubuJsviNdslymvBMNgvIezYA[index];
				aFpYyWFZfIYoUVCIMjrKuhWWetMo[index] = value;
			}

			public void ClearWasTrueThisFrame()
			{
				for (int i = 0; i < values.Length; i++)
				{
					wasTrueThisFrame[i] = false;
					wgzCaubuJsviNdslymvBMNgvIezYA[i] = false;
					HjOsDzLVYIooGnJqqbkZAnsPdadOA[i] = values[i];
				}
			}

			public void Clear()
			{
				Array.Clear(values, 0, values.Length);
				Array.Clear(aFpYyWFZfIYoUVCIMjrKuhWWetMo, 0, values.Length);
				Array.Clear(wasTrueThisFrame, 0, wasTrueThisFrame.Length);
				Array.Clear(wgzCaubuJsviNdslymvBMNgvIezYA, 0, wgzCaubuJsviNdslymvBMNgvIezYA.Length);
				Array.Clear(HjOsDzLVYIooGnJqqbkZAnsPdadOA, 0, HjOsDzLVYIooGnJqqbkZAnsPdadOA.Length);
				RVxCPjjcVwmYPACQyAxyCdARFOGy = ReInput.timeScalePauseChangedCount;
			}

			public void Import(ButtonData source)
			{
				if (source != null)
				{
					int num = MathTools.Min(values.Length, source.values.Length);
					for (int i = 0; i < num; i++)
					{
						values[i] = source.values[i];
						aFpYyWFZfIYoUVCIMjrKuhWWetMo[i] = source.aFpYyWFZfIYoUVCIMjrKuhWWetMo[i];
						wasTrueThisFrame[i] = source.wasTrueThisFrame[i];
						wgzCaubuJsviNdslymvBMNgvIezYA[i] = source.wgzCaubuJsviNdslymvBMNgvIezYA[i];
						HjOsDzLVYIooGnJqqbkZAnsPdadOA[i] = source.HjOsDzLVYIooGnJqqbkZAnsPdadOA[i];
						RVxCPjjcVwmYPACQyAxyCdARFOGy = source.RVxCPjjcVwmYPACQyAxyCdARFOGy;
					}
				}
			}

			private void codHbwQiDDWTJgdhkihMxGlJBWqA()
			{
				if (ReInput.timeScalePauseChangedCount != RVxCPjjcVwmYPACQyAxyCdARFOGy)
				{
					ClearWasTrueThisFrame();
					RVxCPjjcVwmYPACQyAxyCdARFOGy = ReInput.timeScalePauseChangedCount;
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
