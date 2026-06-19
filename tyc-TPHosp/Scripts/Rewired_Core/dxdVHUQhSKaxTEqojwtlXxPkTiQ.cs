using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class dxdVHUQhSKaxTEqojwtlXxPkTiQ
{
	private class nErtzAXQOqRkmWSyORPpUOPPbkh
	{
		private class ZCJhCeKpPVkNBiENpbrLGSSilrjY
		{
			private int uiOHwBrYNOLBuZUwvPRpKAvvNnQ;

			private XkgiQMJKkgcfMsogiyQoOxsmtkZ[] KgNDeofgOGnDWISzFibSmnVDlhDY;

			private gcotoXmxxXlRYgJDdPeGKuHrMde[] ReTfQYcjCClrSfRODjReSSrvAkjB;

			public ZCJhCeKpPVkNBiENpbrLGSSilrjY(int index)
			{
				uiOHwBrYNOLBuZUwvPRpKAvvNnQ = index;
				KgNDeofgOGnDWISzFibSmnVDlhDY = new XkgiQMJKkgcfMsogiyQoOxsmtkZ[20];
				for (int i = 0; i < KgNDeofgOGnDWISzFibSmnVDlhDY.Length; i++)
				{
					KgNDeofgOGnDWISzFibSmnVDlhDY[i] = new XkgiQMJKkgcfMsogiyQoOxsmtkZ();
				}
				ReTfQYcjCClrSfRODjReSSrvAkjB = new gcotoXmxxXlRYgJDdPeGKuHrMde[29];
				for (int j = 0; j < ReTfQYcjCClrSfRODjReSSrvAkjB.Length; j++)
				{
					ReTfQYcjCClrSfRODjReSSrvAkjB[j] = new gcotoXmxxXlRYgJDdPeGKuHrMde(j);
				}
			}

			public void BQWVwztidFDoKSonWGAEASTWFMHb()
			{
				for (int i = 0; i < KgNDeofgOGnDWISzFibSmnVDlhDY.Length; i++)
				{
					bool joystickButtonValueByJoystickIndex = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(uiOHwBrYNOLBuZUwvPRpKAvvNnQ, i);
					KgNDeofgOGnDWISzFibSmnVDlhDY[i].BQWVwztidFDoKSonWGAEASTWFMHb(joystickButtonValueByJoystickIndex);
				}
				for (int j = 0; j < ReTfQYcjCClrSfRODjReSSrvAkjB.Length; j++)
				{
					float joystickAxisRawValueByJoystickIndex = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(uiOHwBrYNOLBuZUwvPRpKAvvNnQ, j);
					ReTfQYcjCClrSfRODjReSSrvAkjB[j].BQWVwztidFDoKSonWGAEASTWFMHb(joystickAxisRawValueByJoystickIndex);
				}
			}

			public void QTPiZFmnRsxmyQYmMuIoBQkOtfg()
			{
				for (int i = 0; i < KgNDeofgOGnDWISzFibSmnVDlhDY.Length; i++)
				{
					KgNDeofgOGnDWISzFibSmnVDlhDY[i].value = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(uiOHwBrYNOLBuZUwvPRpKAvvNnQ, i);
				}
				for (int j = 0; j < ReTfQYcjCClrSfRODjReSSrvAkjB.Length; j++)
				{
					ReTfQYcjCClrSfRODjReSSrvAkjB[j].value = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(uiOHwBrYNOLBuZUwvPRpKAvvNnQ, j);
				}
			}

			public bool tczGrLoSLQRKAWwrReBmbHatjKF(int P_0)
			{
				if (P_0 < 0 || P_0 >= KgNDeofgOGnDWISzFibSmnVDlhDY.Length)
				{
					return false;
				}
				return KgNDeofgOGnDWISzFibSmnVDlhDY[P_0].value;
			}

			public bool wyMTjzWuSYHxxwaQSHqUbLUGgKg(int P_0)
			{
				if (P_0 < 0 || P_0 >= KgNDeofgOGnDWISzFibSmnVDlhDY.Length)
				{
					return false;
				}
				return KgNDeofgOGnDWISzFibSmnVDlhDY[P_0].justPressed;
			}

			public bool KsQmhhakoIMsmFFssFWZgAtACAmj(int P_0)
			{
				if (P_0 < 0 || P_0 >= KgNDeofgOGnDWISzFibSmnVDlhDY.Length)
				{
					return false;
				}
				return KgNDeofgOGnDWISzFibSmnVDlhDY[P_0].justReleased;
			}

			public float aKtyyQJXaksGFdepXiicilcqmAz(int P_0)
			{
				if (P_0 < 0 || P_0 >= ReTfQYcjCClrSfRODjReSSrvAkjB.Length)
				{
					return 0f;
				}
				return ReTfQYcjCClrSfRODjReSSrvAkjB[P_0].value;
			}

			public bool BvioiQDbvqbQcehRheZUuJVxzBP(int P_0, bool P_1)
			{
				if (P_0 < 0 || P_0 >= ReTfQYcjCClrSfRODjReSSrvAkjB.Length)
				{
					return false;
				}
				return ReTfQYcjCClrSfRODjReSSrvAkjB[P_0].GVdTEbCGUhjDluCgHPTnyOZtsgt(P_1);
			}

			public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
			{
				for (int i = 0; i < KgNDeofgOGnDWISzFibSmnVDlhDY.Length; i++)
				{
					KgNDeofgOGnDWISzFibSmnVDlhDY[i].dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
				}
				for (int j = 0; j < ReTfQYcjCClrSfRODjReSSrvAkjB.Length; j++)
				{
					ReTfQYcjCClrSfRODjReSSrvAkjB[j].dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
				}
			}
		}

		private class WcXaeHZPoZOxWFYzJRUkiGHQIFg
		{
			private XkgiQMJKkgcfMsogiyQoOxsmtkZ[] KgNDeofgOGnDWISzFibSmnVDlhDY;

			public WcXaeHZPoZOxWFYzJRUkiGHQIFg()
			{
				KgNDeofgOGnDWISzFibSmnVDlhDY = new XkgiQMJKkgcfMsogiyQoOxsmtkZ[7];
				for (int i = 0; i < KgNDeofgOGnDWISzFibSmnVDlhDY.Length; i++)
				{
					KgNDeofgOGnDWISzFibSmnVDlhDY[i] = new XkgiQMJKkgcfMsogiyQoOxsmtkZ();
				}
			}

			public void QTPiZFmnRsxmyQYmMuIoBQkOtfg()
			{
				for (int i = 0; i < KgNDeofgOGnDWISzFibSmnVDlhDY.Length; i++)
				{
					KgNDeofgOGnDWISzFibSmnVDlhDY[i].value = Input.GetButton("MouseButton" + i);
				}
			}

			public bool tczGrLoSLQRKAWwrReBmbHatjKF(int P_0)
			{
				if (P_0 < 0 || P_0 >= KgNDeofgOGnDWISzFibSmnVDlhDY.Length)
				{
					return false;
				}
				return KgNDeofgOGnDWISzFibSmnVDlhDY[P_0].value;
			}

			public bool wyMTjzWuSYHxxwaQSHqUbLUGgKg(int P_0)
			{
				if (P_0 < 0 || P_0 >= KgNDeofgOGnDWISzFibSmnVDlhDY.Length)
				{
					return false;
				}
				return KgNDeofgOGnDWISzFibSmnVDlhDY[P_0].justPressed;
			}

			public bool KsQmhhakoIMsmFFssFWZgAtACAmj(int P_0)
			{
				if (P_0 < 0 || P_0 >= KgNDeofgOGnDWISzFibSmnVDlhDY.Length)
				{
					return false;
				}
				return KgNDeofgOGnDWISzFibSmnVDlhDY[P_0].justReleased;
			}

			public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
			{
				for (int i = 0; i < KgNDeofgOGnDWISzFibSmnVDlhDY.Length; i++)
				{
					KgNDeofgOGnDWISzFibSmnVDlhDY[i].dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
				}
			}
		}

		private class XkgiQMJKkgcfMsogiyQoOxsmtkZ
		{
			private bool BUlTlwnOYIYrMrbKigONinVIGlB;

			private bool cXmaOZTxqFArkEcgcZnyeUpbFofm;

			public bool value
			{
				get
				{
					return BUlTlwnOYIYrMrbKigONinVIGlB;
				}
				set
				{
					cXmaOZTxqFArkEcgcZnyeUpbFofm = BUlTlwnOYIYrMrbKigONinVIGlB;
					BUlTlwnOYIYrMrbKigONinVIGlB = value;
				}
			}

			public bool justPressed
			{
				get
				{
					if (BUlTlwnOYIYrMrbKigONinVIGlB)
					{
						return !cXmaOZTxqFArkEcgcZnyeUpbFofm;
					}
					return false;
				}
			}

			public bool justReleased
			{
				get
				{
					if (cXmaOZTxqFArkEcgcZnyeUpbFofm)
					{
						return !BUlTlwnOYIYrMrbKigONinVIGlB;
					}
					return false;
				}
			}

			public void BQWVwztidFDoKSonWGAEASTWFMHb(bool P_0)
			{
				BUlTlwnOYIYrMrbKigONinVIGlB = P_0;
				cXmaOZTxqFArkEcgcZnyeUpbFofm = P_0;
			}

			public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
			{
				BUlTlwnOYIYrMrbKigONinVIGlB = false;
				cXmaOZTxqFArkEcgcZnyeUpbFofm = false;
			}
		}

		private class gcotoXmxxXlRYgJDdPeGKuHrMde
		{
			private int PTdCvUhpaBXdSBPOwrfGgHfBQda;

			private float BUlTlwnOYIYrMrbKigONinVIGlB;

			private float irpOgzcLsMhXNMlUsjtFcXKzrAK;

			public float value
			{
				get
				{
					return BUlTlwnOYIYrMrbKigONinVIGlB;
				}
				set
				{
					BUlTlwnOYIYrMrbKigONinVIGlB = value;
				}
			}

			public gcotoXmxxXlRYgJDdPeGKuHrMde(int axisIndex)
			{
				PTdCvUhpaBXdSBPOwrfGgHfBQda = axisIndex;
			}

			public void BQWVwztidFDoKSonWGAEASTWFMHb(float P_0)
			{
				irpOgzcLsMhXNMlUsjtFcXKzrAK = P_0;
				BUlTlwnOYIYrMrbKigONinVIGlB = P_0;
			}

			public bool GVdTEbCGUhjDluCgHPTnyOZtsgt(bool P_0)
			{
				float num = BUlTlwnOYIYrMrbKigONinVIGlB - irpOgzcLsMhXNMlUsjtFcXKzrAK;
				if (P_0 && num < 0f)
				{
					return false;
				}
				if (MathTools.Abs(num) > 0.7f)
				{
					return true;
				}
				return false;
			}

			public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
			{
				BUlTlwnOYIYrMrbKigONinVIGlB = 0f;
				irpOgzcLsMhXNMlUsjtFcXKzrAK = 0f;
			}
		}

		private ZCJhCeKpPVkNBiENpbrLGSSilrjY[] GpKTUjLMGVeIHJzINAjLhtehdVC;

		private WcXaeHZPoZOxWFYzJRUkiGHQIFg MiFwUrdVVdOrWSSAMcWZRrLShqF;

		public nErtzAXQOqRkmWSyORPpUOPPbkh()
		{
			GpKTUjLMGVeIHJzINAjLhtehdVC = new ZCJhCeKpPVkNBiENpbrLGSSilrjY[16];
			for (int i = 0; i < GpKTUjLMGVeIHJzINAjLhtehdVC.Length; i++)
			{
				GpKTUjLMGVeIHJzINAjLhtehdVC[i] = new ZCJhCeKpPVkNBiENpbrLGSSilrjY(i);
			}
			MiFwUrdVVdOrWSSAMcWZRrLShqF = new WcXaeHZPoZOxWFYzJRUkiGHQIFg();
		}

		public void BQWVwztidFDoKSonWGAEASTWFMHb()
		{
			for (int i = 0; i < GpKTUjLMGVeIHJzINAjLhtehdVC.Length; i++)
			{
				GpKTUjLMGVeIHJzINAjLhtehdVC[i].BQWVwztidFDoKSonWGAEASTWFMHb();
			}
		}

		public void QTPiZFmnRsxmyQYmMuIoBQkOtfg()
		{
			for (int i = 0; i < GpKTUjLMGVeIHJzINAjLhtehdVC.Length; i++)
			{
				GpKTUjLMGVeIHJzINAjLhtehdVC[i].QTPiZFmnRsxmyQYmMuIoBQkOtfg();
			}
			MiFwUrdVVdOrWSSAMcWZRrLShqF.QTPiZFmnRsxmyQYmMuIoBQkOtfg();
		}

		public bool hTQgNxbUFQwdvhXVnSfgoAKVJRi(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= GpKTUjLMGVeIHJzINAjLhtehdVC.Length)
			{
				return false;
			}
			return GpKTUjLMGVeIHJzINAjLhtehdVC[P_0].tczGrLoSLQRKAWwrReBmbHatjKF(P_1);
		}

		public bool MrDDmvTbGRImOEGdthEGcvYkPQwI(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= GpKTUjLMGVeIHJzINAjLhtehdVC.Length)
			{
				return false;
			}
			return GpKTUjLMGVeIHJzINAjLhtehdVC[P_0].wyMTjzWuSYHxxwaQSHqUbLUGgKg(P_1);
		}

		public bool pTtNssujsvdZlgQxgzEnGpGpKg(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= GpKTUjLMGVeIHJzINAjLhtehdVC.Length)
			{
				return false;
			}
			return GpKTUjLMGVeIHJzINAjLhtehdVC[P_0].KsQmhhakoIMsmFFssFWZgAtACAmj(P_1);
		}

		public bool ushGfLoAVXAJqWwtRwZSjmKqKdT(int P_0, int P_1, bool P_2)
		{
			if (P_0 < 0 || P_0 >= GpKTUjLMGVeIHJzINAjLhtehdVC.Length)
			{
				return false;
			}
			return GpKTUjLMGVeIHJzINAjLhtehdVC[P_0].BvioiQDbvqbQcehRheZUuJVxzBP(P_1, P_2);
		}

		public bool kGsJjtIMbxjjpDVSuihAbupGqTi(int P_0)
		{
			return MiFwUrdVVdOrWSSAMcWZRrLShqF.tczGrLoSLQRKAWwrReBmbHatjKF(P_0);
		}

		public bool bwqeAxxRfkxSuHJadkbGROMTmmf(int P_0)
		{
			return MiFwUrdVVdOrWSSAMcWZRrLShqF.wyMTjzWuSYHxxwaQSHqUbLUGgKg(P_0);
		}

		public bool gmryJjwqLMNUyctLqHSluTRLCTi(int P_0)
		{
			return MiFwUrdVVdOrWSSAMcWZRrLShqF.KsQmhhakoIMsmFFssFWZgAtACAmj(P_0);
		}

		public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
		{
			for (int i = 0; i < GpKTUjLMGVeIHJzINAjLhtehdVC.Length; i++)
			{
				GpKTUjLMGVeIHJzINAjLhtehdVC[i].dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			}
			MiFwUrdVVdOrWSSAMcWZRrLShqF.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
		}
	}

	private UpdateLoopType jmBSaJJBPATONArmmooyFDkJURE;

	private nErtzAXQOqRkmWSyORPpUOPPbkh myoqKqgLYfTibxcUgPbJwOUqyoj;

	private IndexedDictionary<int, nErtzAXQOqRkmWSyORPpUOPPbkh> aYLjkEtchHYfxmcPaRErlbyjaeW;

	public dxdVHUQhSKaxTEqojwtlXxPkTiQ(UpdateLoopSetting updateLoopSetting)
	{
		aYLjkEtchHYfxmcPaRErlbyjaeW = new IndexedDictionary<int, nErtzAXQOqRkmWSyORPpUOPPbkh>();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			for (int i = 0; i < list.Count; i++)
			{
				aYLjkEtchHYfxmcPaRErlbyjaeW.Add((int)list[i], new nErtzAXQOqRkmWSyORPpUOPPbkh());
			}
		}
		jmBSaJJBPATONArmmooyFDkJURE = UpdateLoopType.Update;
		myoqKqgLYfTibxcUgPbJwOUqyoj = aYLjkEtchHYfxmcPaRErlbyjaeW.GetValue(0);
	}

	public void BQWVwztidFDoKSonWGAEASTWFMHb()
	{
		vXZBmondemhUaaeABkMgfyCcDouO(ReInput.currentUpdateLoop);
		myoqKqgLYfTibxcUgPbJwOUqyoj.BQWVwztidFDoKSonWGAEASTWFMHb();
	}

	public void QTPiZFmnRsxmyQYmMuIoBQkOtfg(UpdateLoopType P_0)
	{
		vXZBmondemhUaaeABkMgfyCcDouO(P_0);
		myoqKqgLYfTibxcUgPbJwOUqyoj.QTPiZFmnRsxmyQYmMuIoBQkOtfg();
	}

	public bool hTQgNxbUFQwdvhXVnSfgoAKVJRi(int P_0, int P_1)
	{
		return myoqKqgLYfTibxcUgPbJwOUqyoj.hTQgNxbUFQwdvhXVnSfgoAKVJRi(P_0, P_1);
	}

	public bool MrDDmvTbGRImOEGdthEGcvYkPQwI(int P_0, int P_1)
	{
		return myoqKqgLYfTibxcUgPbJwOUqyoj.MrDDmvTbGRImOEGdthEGcvYkPQwI(P_0, P_1);
	}

	public bool pTtNssujsvdZlgQxgzEnGpGpKg(int P_0, int P_1)
	{
		return myoqKqgLYfTibxcUgPbJwOUqyoj.pTtNssujsvdZlgQxgzEnGpGpKg(P_0, P_1);
	}

	public bool ushGfLoAVXAJqWwtRwZSjmKqKdT(int P_0, int P_1, bool P_2)
	{
		return myoqKqgLYfTibxcUgPbJwOUqyoj.ushGfLoAVXAJqWwtRwZSjmKqKdT(P_0, P_1, P_2);
	}

	public bool kGsJjtIMbxjjpDVSuihAbupGqTi(int P_0)
	{
		return myoqKqgLYfTibxcUgPbJwOUqyoj.kGsJjtIMbxjjpDVSuihAbupGqTi(P_0);
	}

	public bool bwqeAxxRfkxSuHJadkbGROMTmmf(int P_0)
	{
		return myoqKqgLYfTibxcUgPbJwOUqyoj.bwqeAxxRfkxSuHJadkbGROMTmmf(P_0);
	}

	public bool gmryJjwqLMNUyctLqHSluTRLCTi(int P_0)
	{
		return myoqKqgLYfTibxcUgPbJwOUqyoj.gmryJjwqLMNUyctLqHSluTRLCTi(P_0);
	}

	public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
	{
		for (int i = 0; i < aYLjkEtchHYfxmcPaRErlbyjaeW.Count; i++)
		{
			aYLjkEtchHYfxmcPaRErlbyjaeW[i].dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
		}
	}

	private void vXZBmondemhUaaeABkMgfyCcDouO(UpdateLoopType P_0)
	{
		if (jmBSaJJBPATONArmmooyFDkJURE != P_0)
		{
			jmBSaJJBPATONArmmooyFDkJURE = P_0;
			myoqKqgLYfTibxcUgPbJwOUqyoj = aYLjkEtchHYfxmcPaRErlbyjaeW.GetValue((int)P_0);
		}
	}
}
