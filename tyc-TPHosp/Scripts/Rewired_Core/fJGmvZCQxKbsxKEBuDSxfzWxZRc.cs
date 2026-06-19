using Rewired;
using Rewired.Utils;

internal class fJGmvZCQxKbsxKEBuDSxfzWxZRc
{
	private class GTfUcigxRSgNqJDFhRSzyUjfUpN
	{
		public bool rkAjkyfvoRxILmntHviwzcLqjma;

		public bool hldjmLLhRFbldypJyNprJPlbZSg;

		public double YaNikuiCGBjKtibFhmHuzxkYrtMU;

		public bool SotGsUYYKnleeAlZcVTMaYRISsz;

		public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
		{
			rkAjkyfvoRxILmntHviwzcLqjma = false;
			SotGsUYYKnleeAlZcVTMaYRISsz = false;
		}
	}

	private const int LYjEKzbapaiTQbDcHKjzMQazyFNW = 2;

	private bool BUlTlwnOYIYrMrbKigONinVIGlB;

	private bool lTXqnFxCLMLFCCCrYEHQKDIGclg;

	private bool eexEzkQwARqNeEMqcWFUYqhxhIqh;

	private float TdUbOjEFnvABBnDSodrgOXgZhOb;

	private readonly GTfUcigxRSgNqJDFhRSzyUjfUpN[] uNDCxqZBlieKIudoPpqmTFtMpjA;

	private bool pKYZxedsCWkAAknKtAEYpbGVMaE;

	private bool QoASJSMUiNjIghKKtDLiDwHbthVL;

	public bool doublePressHold => BUlTlwnOYIYrMrbKigONinVIGlB;

	public bool doublePressUp
	{
		get
		{
			if (!BUlTlwnOYIYrMrbKigONinVIGlB)
			{
				return lTXqnFxCLMLFCCCrYEHQKDIGclg;
			}
			return false;
		}
	}

	public bool doublePressDown
	{
		get
		{
			if (BUlTlwnOYIYrMrbKigONinVIGlB)
			{
				return !lTXqnFxCLMLFCCCrYEHQKDIGclg;
			}
			return false;
		}
	}

	public float speed => TdUbOjEFnvABBnDSodrgOXgZhOb;

	public bool singlePressHold => QoASJSMUiNjIghKKtDLiDwHbthVL;

	public bool singlePressDown
	{
		get
		{
			if (QoASJSMUiNjIghKKtDLiDwHbthVL)
			{
				return !pKYZxedsCWkAAknKtAEYpbGVMaE;
			}
			return false;
		}
	}

	public bool singlePressUp
	{
		get
		{
			if (!QoASJSMUiNjIghKKtDLiDwHbthVL)
			{
				return pKYZxedsCWkAAknKtAEYpbGVMaE;
			}
			return false;
		}
	}

	public fJGmvZCQxKbsxKEBuDSxfzWxZRc(float speed)
	{
		TdUbOjEFnvABBnDSodrgOXgZhOb = speed;
		uNDCxqZBlieKIudoPpqmTFtMpjA = new GTfUcigxRSgNqJDFhRSzyUjfUpN[2];
		ArrayTools.Populate(uNDCxqZBlieKIudoPpqmTFtMpjA);
	}

	public void QTPiZFmnRsxmyQYmMuIoBQkOtfg(float P_0, bool P_1, bool P_2)
	{
		bool flag = ((!eexEzkQwARqNeEMqcWFUYqhxhIqh) ? P_1 : P_2);
		if (P_0 != speed)
		{
			jzVpePliHKDUCFsxHIbpdhfBvnj(P_0);
		}
		pKYZxedsCWkAAknKtAEYpbGVMaE = QoASJSMUiNjIghKKtDLiDwHbthVL;
		lTXqnFxCLMLFCCCrYEHQKDIGclg = BUlTlwnOYIYrMrbKigONinVIGlB;
		if (!BUlTlwnOYIYrMrbKigONinVIGlB)
		{
			if (!flag && pKYZxedsCWkAAknKtAEYpbGVMaE)
			{
				QoASJSMUiNjIghKKtDLiDwHbthVL = false;
			}
			for (int num = 1; num >= 0; num--)
			{
				if (uNDCxqZBlieKIudoPpqmTFtMpjA[num].rkAjkyfvoRxILmntHviwzcLqjma && uNDCxqZBlieKIudoPpqmTFtMpjA[num].hldjmLLhRFbldypJyNprJPlbZSg && !uNDCxqZBlieKIudoPpqmTFtMpjA[num].SotGsUYYKnleeAlZcVTMaYRISsz)
				{
					if (!QoASJSMUiNjIghKKtDLiDwHbthVL && ReInput.unscaledTime - uNDCxqZBlieKIudoPpqmTFtMpjA[num].YaNikuiCGBjKtibFhmHuzxkYrtMU > (double)P_0)
					{
						QoASJSMUiNjIghKKtDLiDwHbthVL = true;
						uNDCxqZBlieKIudoPpqmTFtMpjA[num].SotGsUYYKnleeAlZcVTMaYRISsz = true;
					}
					break;
				}
			}
		}
		if (eexEzkQwARqNeEMqcWFUYqhxhIqh == flag)
		{
			return;
		}
		eexEzkQwARqNeEMqcWFUYqhxhIqh = flag;
		if (!flag)
		{
			if (BUlTlwnOYIYrMrbKigONinVIGlB)
			{
				BUlTlwnOYIYrMrbKigONinVIGlB = false;
			}
			return;
		}
		if (QoASJSMUiNjIghKKtDLiDwHbthVL)
		{
			QoASJSMUiNjIghKKtDLiDwHbthVL = false;
		}
		double unscaledTime = ReInput.unscaledTime;
		for (int i = 0; i < 2; i++)
		{
			if (uNDCxqZBlieKIudoPpqmTFtMpjA[i].rkAjkyfvoRxILmntHviwzcLqjma && unscaledTime - uNDCxqZBlieKIudoPpqmTFtMpjA[i].YaNikuiCGBjKtibFhmHuzxkYrtMU > (double)TdUbOjEFnvABBnDSodrgOXgZhOb)
			{
				uNDCxqZBlieKIudoPpqmTFtMpjA[i].dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			}
		}
		if (!uNDCxqZBlieKIudoPpqmTFtMpjA[0].rkAjkyfvoRxILmntHviwzcLqjma)
		{
			MiscTools.Swap(ref uNDCxqZBlieKIudoPpqmTFtMpjA[0], ref uNDCxqZBlieKIudoPpqmTFtMpjA[1]);
		}
		int num2 = 0;
		for (int j = 0; j < 2; j++)
		{
			if (uNDCxqZBlieKIudoPpqmTFtMpjA[j].rkAjkyfvoRxILmntHviwzcLqjma)
			{
				num2++;
				continue;
			}
			uNDCxqZBlieKIudoPpqmTFtMpjA[j].rkAjkyfvoRxILmntHviwzcLqjma = true;
			uNDCxqZBlieKIudoPpqmTFtMpjA[j].hldjmLLhRFbldypJyNprJPlbZSg = flag;
			uNDCxqZBlieKIudoPpqmTFtMpjA[j].YaNikuiCGBjKtibFhmHuzxkYrtMU = unscaledTime;
			num2++;
			break;
		}
		if (num2 >= 2)
		{
			if (!BUlTlwnOYIYrMrbKigONinVIGlB)
			{
				BUlTlwnOYIYrMrbKigONinVIGlB = true;
				QoASJSMUiNjIghKKtDLiDwHbthVL = false;
			}
			for (int k = 0; k < 2; k++)
			{
				uNDCxqZBlieKIudoPpqmTFtMpjA[k].dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			}
		}
	}

	public void jzVpePliHKDUCFsxHIbpdhfBvnj(float P_0)
	{
		QjNHfjHnCmaQyvCGKbwODraSxUWC();
		TdUbOjEFnvABBnDSodrgOXgZhOb = P_0;
	}

	public void QjNHfjHnCmaQyvCGKbwODraSxUWC()
	{
		eexEzkQwARqNeEMqcWFUYqhxhIqh = false;
		BUlTlwnOYIYrMrbKigONinVIGlB = false;
		QoASJSMUiNjIghKKtDLiDwHbthVL = false;
		pKYZxedsCWkAAknKtAEYpbGVMaE = false;
		for (int i = 0; i < 2; i++)
		{
			uNDCxqZBlieKIudoPpqmTFtMpjA[i].dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
		}
	}
}
