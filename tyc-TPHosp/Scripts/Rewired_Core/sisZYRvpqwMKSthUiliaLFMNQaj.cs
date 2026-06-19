internal class sisZYRvpqwMKSthUiliaLFMNQaj
{
	private float CTpUlqVcvmrntSCbQiOlmTgCHpyj;

	private float GYmFCGagIoSMkCrpMEbsaFjjebDW;

	private float xcnbrjRjCvSoBqugxnqztiGHwav;

	private bool sFnYxABJDbPleWSKfAybWTjhabq;

	private double vfFRUIPUoKMeIeOScHBAvptzXYo;

	private double dOwacnKNFOFfMvwMUHJaBxIkNQe;

	private bool XmsBOzeFrVcmmqgkzGiDHsLQszdb;

	private bool KLevmlRcjnCMSiqnHiPsGwdAleZj;

	public bool state => KLevmlRcjnCMSiqnHiPsGwdAleZj;

	public sisZYRvpqwMKSthUiliaLFMNQaj(float delay, float ratePerSecond)
	{
		KCZjasJJaYPTHmIZCqnuAVrBuYGJ(delay, ratePerSecond);
	}

	public void QTPiZFmnRsxmyQYmMuIoBQkOtfg(bool P_0, bool P_1, float P_2, float P_3, double P_4)
	{
		if (!sFnYxABJDbPleWSKfAybWTjhabq && !P_0)
		{
			return;
		}
		if (KLevmlRcjnCMSiqnHiPsGwdAleZj)
		{
			ZVfLKOKEpFyTpCwYnuaOhupiTsK(false, P_4);
		}
		if (!P_1)
		{
			if (sFnYxABJDbPleWSKfAybWTjhabq)
			{
				QjNHfjHnCmaQyvCGKbwODraSxUWC();
			}
			return;
		}
		if (!sFnYxABJDbPleWSKfAybWTjhabq || P_2 != CTpUlqVcvmrntSCbQiOlmTgCHpyj || P_3 != GYmFCGagIoSMkCrpMEbsaFjjebDW)
		{
			KCZjasJJaYPTHmIZCqnuAVrBuYGJ(P_2, P_3);
			PUfBGkQEoKKPRrTrZNGGdNNSToS(P_4);
			ZVfLKOKEpFyTpCwYnuaOhupiTsK(true, P_4);
		}
		if (P_2 > 0f && !XmsBOzeFrVcmmqgkzGiDHsLQszdb)
		{
			if (P_4 - vfFRUIPUoKMeIeOScHBAvptzXYo <= (double)P_2)
			{
				return;
			}
			ZVfLKOKEpFyTpCwYnuaOhupiTsK(true, P_4);
			XmsBOzeFrVcmmqgkzGiDHsLQszdb = true;
		}
		if (P_4 - dOwacnKNFOFfMvwMUHJaBxIkNQe >= (double)xcnbrjRjCvSoBqugxnqztiGHwav)
		{
			ZVfLKOKEpFyTpCwYnuaOhupiTsK(true, P_4);
		}
	}

	public void KCZjasJJaYPTHmIZCqnuAVrBuYGJ(float P_0, float P_1)
	{
		CTpUlqVcvmrntSCbQiOlmTgCHpyj = P_0;
		GYmFCGagIoSMkCrpMEbsaFjjebDW = P_1;
		xcnbrjRjCvSoBqugxnqztiGHwav = 1f / P_1;
	}

	public void QjNHfjHnCmaQyvCGKbwODraSxUWC()
	{
		sFnYxABJDbPleWSKfAybWTjhabq = false;
		XmsBOzeFrVcmmqgkzGiDHsLQszdb = false;
		dOwacnKNFOFfMvwMUHJaBxIkNQe = 0.0;
		KLevmlRcjnCMSiqnHiPsGwdAleZj = false;
	}

	private void PUfBGkQEoKKPRrTrZNGGdNNSToS(double P_0)
	{
		QjNHfjHnCmaQyvCGKbwODraSxUWC();
		vfFRUIPUoKMeIeOScHBAvptzXYo = P_0;
		sFnYxABJDbPleWSKfAybWTjhabq = true;
	}

	private void ZVfLKOKEpFyTpCwYnuaOhupiTsK(bool P_0, double P_1)
	{
		if (P_0)
		{
			KLevmlRcjnCMSiqnHiPsGwdAleZj = true;
			dOwacnKNFOFfMvwMUHJaBxIkNQe = P_1;
		}
		else
		{
			KLevmlRcjnCMSiqnHiPsGwdAleZj = false;
		}
	}
}
