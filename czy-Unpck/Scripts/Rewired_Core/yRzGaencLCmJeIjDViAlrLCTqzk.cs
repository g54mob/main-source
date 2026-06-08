internal class yRzGaencLCmJeIjDViAlrLCTqzk
{
	private float WHyPkZXWIMOPBljFvibybCcEpKjH;

	private float CQhJRxynzUWyMbfNtsGtfQlxIEW;

	private float xvmwEmXxGPIrrVMBENqpNUfFLuN;

	private bool gTyLLvDyPFrZEpsrKvookvvbBvf;

	private double bbAzXbTKHckGyRxoHHwNHchbXzf;

	private double rtPjMHIsaqNiGAsgvgHflWBynNz;

	private bool DpFECeSMfDAYHHKIFDCuKZKDUsY;

	private bool IfrNfGJhCLNqgLHTaYyhWFbfjPMA;

	public bool state => IfrNfGJhCLNqgLHTaYyhWFbfjPMA;

	public yRzGaencLCmJeIjDViAlrLCTqzk(float delay, float ratePerSecond)
	{
		YmQKpDZSDaehbhQpnWGplAtoplN(delay, ratePerSecond);
	}

	public void GzCliicOSMFLMvKajLgvnmGSSrh(bool P_0, bool P_1, float P_2, float P_3, double P_4)
	{
		if (!gTyLLvDyPFrZEpsrKvookvvbBvf && !P_0)
		{
			return;
		}
		while (true)
		{
			int num;
			if (IfrNfGJhCLNqgLHTaYyhWFbfjPMA)
			{
				FHatHlOKEhjrHzsuIuNZHSjuWTL(false, P_4);
				num = -300161597;
				goto IL_0011;
			}
			goto IL_00aa;
			IL_0075:
			YmQKpDZSDaehbhQpnWGplAtoplN(P_2, P_3);
			NoiITHOkBgdirKSZopWLLfLYZOJ(P_4);
			FHatHlOKEhjrHzsuIuNZHSjuWTL(true, P_4);
			num = -300161595;
			goto IL_0011;
			IL_00aa:
			if (P_1)
			{
				goto IL_0116;
			}
			if (!gTyLLvDyPFrZEpsrKvookvvbBvf)
			{
				break;
			}
			goto IL_014b;
			IL_0011:
			while (true)
			{
				switch (num ^ -300161599)
				{
				case 10:
					num = -300161592;
					continue;
				default:
					return;
				case 9:
					break;
				case 8:
					FHatHlOKEhjrHzsuIuNZHSjuWTL(true, P_4);
					num = -300161594;
					continue;
				case 6:
					goto IL_0075;
				case 7:
					DpFECeSMfDAYHHKIFDCuKZKDUsY = true;
					num = -300161596;
					continue;
				case 2:
					goto IL_00aa;
				case 5:
					if (P_4 - rtPjMHIsaqNiGAsgvgHflWBynNz >= (double)xvmwEmXxGPIrrVMBENqpNUfFLuN)
					{
						FHatHlOKEhjrHzsuIuNZHSjuWTL(true, P_4);
						num = -300161598;
						continue;
					}
					return;
				case 4:
					if (P_2 > 0f && !DpFECeSMfDAYHHKIFDCuKZKDUsY)
					{
						if (P_4 - bbAzXbTKHckGyRxoHHwNHchbXzf <= (double)P_2)
						{
							return;
						}
						goto case 8;
					}
					goto case 5;
				case 1:
					goto IL_0116;
				case 0:
					goto IL_014b;
				case 3:
					return;
				}
				break;
			}
			continue;
			IL_0116:
			if (gTyLLvDyPFrZEpsrKvookvvbBvf && P_2 == WHyPkZXWIMOPBljFvibybCcEpKjH)
			{
				int num2;
				if (P_3 == CQhJRxynzUWyMbfNtsGtfQlxIEW)
				{
					num = -300161595;
					num2 = num;
				}
				else
				{
					num = -300161593;
					num2 = num;
				}
				goto IL_0011;
			}
			goto IL_0075;
			IL_014b:
			CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
			break;
		}
	}

	public void YmQKpDZSDaehbhQpnWGplAtoplN(float P_0, float P_1)
	{
		WHyPkZXWIMOPBljFvibybCcEpKjH = P_0;
		CQhJRxynzUWyMbfNtsGtfQlxIEW = P_1;
		xvmwEmXxGPIrrVMBENqpNUfFLuN = 1f / P_1;
	}

	public void CHWDoIJFbUPiCCQqjvBLnPoSWjTy()
	{
		gTyLLvDyPFrZEpsrKvookvvbBvf = false;
		DpFECeSMfDAYHHKIFDCuKZKDUsY = false;
		rtPjMHIsaqNiGAsgvgHflWBynNz = 0.0;
		IfrNfGJhCLNqgLHTaYyhWFbfjPMA = false;
	}

	private void NoiITHOkBgdirKSZopWLLfLYZOJ(double P_0)
	{
		CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
		bbAzXbTKHckGyRxoHHwNHchbXzf = P_0;
		gTyLLvDyPFrZEpsrKvookvvbBvf = true;
	}

	private void FHatHlOKEhjrHzsuIuNZHSjuWTL(bool P_0, double P_1)
	{
		if (P_0)
		{
			IfrNfGJhCLNqgLHTaYyhWFbfjPMA = true;
			rtPjMHIsaqNiGAsgvgHflWBynNz = P_1;
		}
		else
		{
			IfrNfGJhCLNqgLHTaYyhWFbfjPMA = false;
		}
	}
}
