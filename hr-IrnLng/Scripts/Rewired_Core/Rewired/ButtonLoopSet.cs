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

			private bool[] YVFuTySuaqxLdzkVauPvJUyfiAV;

			private int XsgsYXNHVqGClshozYQvLpOYcpd;

			private readonly bool[] qSCPPnVeRqwlwlFFtfvSYAnVHLDB;

			private readonly bool[] TKtWMmIiaCvQjYMaUveovLqyGcx;

			public bool[] effectiveValue
			{
				get
				{
					if (updateLoop == UpdateLoopType.FixedUpdate)
					{
						hppDiXaOCBsBcPgRRHwYBibNpdeq();
					}
					return YVFuTySuaqxLdzkVauPvJUyfiAV;
				}
			}

			public ButtonData(int count, UpdateLoopType updateLoop)
			{
				this.updateLoop = updateLoop;
				values = new bool[count];
				TKtWMmIiaCvQjYMaUveovLqyGcx = new bool[count];
				wasTrueThisFrame = new bool[count];
				qSCPPnVeRqwlwlFFtfvSYAnVHLDB = new bool[count];
				YVFuTySuaqxLdzkVauPvJUyfiAV = new bool[count];
				XsgsYXNHVqGClshozYQvLpOYcpd = ReInput.timeScalePauseChangedCount;
			}

			public void SetValue(int index, bool value)
			{
				if (updateLoop == UpdateLoopType.FixedUpdate)
				{
					hppDiXaOCBsBcPgRRHwYBibNpdeq();
				}
				values[index] = value;
				if (value)
				{
					wasTrueThisFrame[index] = true;
					if (!TKtWMmIiaCvQjYMaUveovLqyGcx[index])
					{
						qSCPPnVeRqwlwlFFtfvSYAnVHLDB[index] = true;
					}
				}
				YVFuTySuaqxLdzkVauPvJUyfiAV[index] = value | qSCPPnVeRqwlwlFFtfvSYAnVHLDB[index];
				TKtWMmIiaCvQjYMaUveovLqyGcx[index] = value;
			}

			public void ClearWasTrueThisFrame()
			{
				for (int i = 0; i < values.Length; i++)
				{
					wasTrueThisFrame[i] = false;
					qSCPPnVeRqwlwlFFtfvSYAnVHLDB[i] = false;
					YVFuTySuaqxLdzkVauPvJUyfiAV[i] = values[i];
				}
			}

			public void Clear()
			{
				Array.Clear(values, 0, values.Length);
				Array.Clear(TKtWMmIiaCvQjYMaUveovLqyGcx, 0, values.Length);
				Array.Clear(wasTrueThisFrame, 0, wasTrueThisFrame.Length);
				Array.Clear(qSCPPnVeRqwlwlFFtfvSYAnVHLDB, 0, qSCPPnVeRqwlwlFFtfvSYAnVHLDB.Length);
				Array.Clear(YVFuTySuaqxLdzkVauPvJUyfiAV, 0, YVFuTySuaqxLdzkVauPvJUyfiAV.Length);
				XsgsYXNHVqGClshozYQvLpOYcpd = ReInput.timeScalePauseChangedCount;
			}

			public void Import(ButtonData source)
			{
				if (source != null)
				{
					int num = MathTools.Min(values.Length, source.values.Length);
					for (int i = 0; i < num; i++)
					{
						values[i] = source.values[i];
						TKtWMmIiaCvQjYMaUveovLqyGcx[i] = source.TKtWMmIiaCvQjYMaUveovLqyGcx[i];
						wasTrueThisFrame[i] = source.wasTrueThisFrame[i];
						qSCPPnVeRqwlwlFFtfvSYAnVHLDB[i] = source.qSCPPnVeRqwlwlFFtfvSYAnVHLDB[i];
						YVFuTySuaqxLdzkVauPvJUyfiAV[i] = source.YVFuTySuaqxLdzkVauPvJUyfiAV[i];
						XsgsYXNHVqGClshozYQvLpOYcpd = source.XsgsYXNHVqGClshozYQvLpOYcpd;
					}
				}
			}

			private void hppDiXaOCBsBcPgRRHwYBibNpdeq()
			{
				if (ReInput.timeScalePauseChangedCount != XsgsYXNHVqGClshozYQvLpOYcpd)
				{
					ClearWasTrueThisFrame();
					XsgsYXNHVqGClshozYQvLpOYcpd = ReInput.timeScalePauseChangedCount;
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
