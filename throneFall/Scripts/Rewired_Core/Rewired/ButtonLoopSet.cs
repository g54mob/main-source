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

			private bool[] upcwZpXeRxsoxahLLUAFoIruCGhg;

			private int mqDhqbdzSTCAgFuJLhsuDhmmCeYfA;

			private readonly bool[] RhRXIuyKPFoHkzFsHFHZUYYQUtfj;

			private readonly bool[] ZtBDlGDeilWhrQgNjTSCtLifHOSj;

			public bool[] effectiveValue
			{
				get
				{
					if (updateLoop == UpdateLoopType.FixedUpdate)
					{
						BDMggtjMhgnUqKjgARGteceMppGHb();
					}
					return upcwZpXeRxsoxahLLUAFoIruCGhg;
				}
			}

			public ButtonData(int P_0, UpdateLoopType P_1)
			{
				updateLoop = P_1;
				values = new bool[P_0];
				ZtBDlGDeilWhrQgNjTSCtLifHOSj = new bool[P_0];
				wasTrueThisFrame = new bool[P_0];
				RhRXIuyKPFoHkzFsHFHZUYYQUtfj = new bool[P_0];
				upcwZpXeRxsoxahLLUAFoIruCGhg = new bool[P_0];
				mqDhqbdzSTCAgFuJLhsuDhmmCeYfA = ReInput.timeScalePauseChangedCount;
			}

			public void SetValue(int index, bool value)
			{
				if (updateLoop == UpdateLoopType.FixedUpdate)
				{
					BDMggtjMhgnUqKjgARGteceMppGHb();
				}
				values[index] = value;
				if (value)
				{
					wasTrueThisFrame[index] = true;
					if (!ZtBDlGDeilWhrQgNjTSCtLifHOSj[index])
					{
						RhRXIuyKPFoHkzFsHFHZUYYQUtfj[index] = true;
					}
				}
				upcwZpXeRxsoxahLLUAFoIruCGhg[index] = value | RhRXIuyKPFoHkzFsHFHZUYYQUtfj[index];
				ZtBDlGDeilWhrQgNjTSCtLifHOSj[index] = value;
			}

			public void ClearWasTrueThisFrame()
			{
				for (int i = 0; i < values.Length; i++)
				{
					wasTrueThisFrame[i] = false;
					RhRXIuyKPFoHkzFsHFHZUYYQUtfj[i] = false;
					upcwZpXeRxsoxahLLUAFoIruCGhg[i] = values[i];
				}
			}

			public void Clear()
			{
				Array.Clear(values, 0, values.Length);
				Array.Clear(ZtBDlGDeilWhrQgNjTSCtLifHOSj, 0, values.Length);
				Array.Clear(wasTrueThisFrame, 0, wasTrueThisFrame.Length);
				Array.Clear(RhRXIuyKPFoHkzFsHFHZUYYQUtfj, 0, RhRXIuyKPFoHkzFsHFHZUYYQUtfj.Length);
				Array.Clear(upcwZpXeRxsoxahLLUAFoIruCGhg, 0, upcwZpXeRxsoxahLLUAFoIruCGhg.Length);
				mqDhqbdzSTCAgFuJLhsuDhmmCeYfA = ReInput.timeScalePauseChangedCount;
			}

			public void Import(ButtonData source)
			{
				if (source != null)
				{
					int num = MathTools.Min(values.Length, source.values.Length);
					for (int i = 0; i < num; i++)
					{
						values[i] = source.values[i];
						ZtBDlGDeilWhrQgNjTSCtLifHOSj[i] = source.ZtBDlGDeilWhrQgNjTSCtLifHOSj[i];
						wasTrueThisFrame[i] = source.wasTrueThisFrame[i];
						RhRXIuyKPFoHkzFsHFHZUYYQUtfj[i] = source.RhRXIuyKPFoHkzFsHFHZUYYQUtfj[i];
						upcwZpXeRxsoxahLLUAFoIruCGhg[i] = source.upcwZpXeRxsoxahLLUAFoIruCGhg[i];
						mqDhqbdzSTCAgFuJLhsuDhmmCeYfA = source.mqDhqbdzSTCAgFuJLhsuDhmmCeYfA;
					}
				}
			}

			private void BDMggtjMhgnUqKjgARGteceMppGHb()
			{
				if (ReInput.timeScalePauseChangedCount != mqDhqbdzSTCAgFuJLhsuDhmmCeYfA)
				{
					ClearWasTrueThisFrame();
					mqDhqbdzSTCAgFuJLhsuDhmmCeYfA = ReInput.timeScalePauseChangedCount;
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
