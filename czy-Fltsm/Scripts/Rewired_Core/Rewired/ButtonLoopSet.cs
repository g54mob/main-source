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

			private bool[] DbSZfJZgOtkhqZrwdRycwJhOGWuq;

			private int PdtIPXhMFVsPhmkIlwITRUHKMaXw;

			private readonly bool[] qrHgGkpXDArvGApjpjgLUfwLYuLA;

			private readonly bool[] qUbgowNHrxZxkraETzeffyRNXeFk;

			public bool[] effectiveValue
			{
				get
				{
					if (updateLoop == UpdateLoopType.FixedUpdate)
					{
						epweXJOVyyYRjWjfqWyKioDwdnDr();
					}
					return DbSZfJZgOtkhqZrwdRycwJhOGWuq;
				}
			}

			public ButtonData(int P_0, UpdateLoopType P_1)
			{
				updateLoop = P_1;
				values = new bool[P_0];
				qUbgowNHrxZxkraETzeffyRNXeFk = new bool[P_0];
				wasTrueThisFrame = new bool[P_0];
				qrHgGkpXDArvGApjpjgLUfwLYuLA = new bool[P_0];
				DbSZfJZgOtkhqZrwdRycwJhOGWuq = new bool[P_0];
				PdtIPXhMFVsPhmkIlwITRUHKMaXw = ReInput.timeScalePauseChangedCount;
			}

			public void SetValue(int index, bool value)
			{
				if (updateLoop == UpdateLoopType.FixedUpdate)
				{
					epweXJOVyyYRjWjfqWyKioDwdnDr();
				}
				values[index] = value;
				if (value)
				{
					wasTrueThisFrame[index] = true;
					if (!qUbgowNHrxZxkraETzeffyRNXeFk[index])
					{
						qrHgGkpXDArvGApjpjgLUfwLYuLA[index] = true;
					}
				}
				DbSZfJZgOtkhqZrwdRycwJhOGWuq[index] = value | qrHgGkpXDArvGApjpjgLUfwLYuLA[index];
				qUbgowNHrxZxkraETzeffyRNXeFk[index] = value;
			}

			public void ClearWasTrueThisFrame()
			{
				for (int i = 0; i < values.Length; i++)
				{
					wasTrueThisFrame[i] = false;
					qrHgGkpXDArvGApjpjgLUfwLYuLA[i] = false;
					DbSZfJZgOtkhqZrwdRycwJhOGWuq[i] = values[i];
				}
			}

			public void Clear()
			{
				Array.Clear(values, 0, values.Length);
				Array.Clear(qUbgowNHrxZxkraETzeffyRNXeFk, 0, values.Length);
				Array.Clear(wasTrueThisFrame, 0, wasTrueThisFrame.Length);
				Array.Clear(qrHgGkpXDArvGApjpjgLUfwLYuLA, 0, qrHgGkpXDArvGApjpjgLUfwLYuLA.Length);
				Array.Clear(DbSZfJZgOtkhqZrwdRycwJhOGWuq, 0, DbSZfJZgOtkhqZrwdRycwJhOGWuq.Length);
				PdtIPXhMFVsPhmkIlwITRUHKMaXw = ReInput.timeScalePauseChangedCount;
			}

			public void Import(ButtonData source)
			{
				if (source != null)
				{
					int num = MathTools.Min(values.Length, source.values.Length);
					for (int i = 0; i < num; i++)
					{
						values[i] = source.values[i];
						qUbgowNHrxZxkraETzeffyRNXeFk[i] = source.qUbgowNHrxZxkraETzeffyRNXeFk[i];
						wasTrueThisFrame[i] = source.wasTrueThisFrame[i];
						qrHgGkpXDArvGApjpjgLUfwLYuLA[i] = source.qrHgGkpXDArvGApjpjgLUfwLYuLA[i];
						DbSZfJZgOtkhqZrwdRycwJhOGWuq[i] = source.DbSZfJZgOtkhqZrwdRycwJhOGWuq[i];
						PdtIPXhMFVsPhmkIlwITRUHKMaXw = source.PdtIPXhMFVsPhmkIlwITRUHKMaXw;
					}
				}
			}

			private void epweXJOVyyYRjWjfqWyKioDwdnDr()
			{
				if (ReInput.timeScalePauseChangedCount != PdtIPXhMFVsPhmkIlwITRUHKMaXw)
				{
					ClearWasTrueThisFrame();
					PdtIPXhMFVsPhmkIlwITRUHKMaXw = ReInput.timeScalePauseChangedCount;
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
