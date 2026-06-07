internal class YRGgzqGPDhlGloNBrbdfHxcjAAR
{
	private float kGZjGYghYbeEpJSRPqWweQHsPdW;

	private float oRGqnkJXtvjxyXQNDHlnXXAFtrx;

	private float NVBIeXeFtmDOXfKAumbqxqnduPZ;

	private bool GTSnoVqwoWkmoBesRSutKEZJuEs;

	private double DCnGtoEqXXFJULpgdrXRbfCHyGIM;

	private double HYWHtZziSFIoCsmgTRZrDnICYmS;

	private bool dgMarBJYqOTngfSskoZGmqhwjRL;

	private bool sEKGJFmKEggfOgdTEhZjakKaJmvA;

	public bool state => sEKGJFmKEggfOgdTEhZjakKaJmvA;

	public YRGgzqGPDhlGloNBrbdfHxcjAAR(float delay, float ratePerSecond)
	{
		ymnrNCikJLroNVqlDEhnXmIQYUc(delay, ratePerSecond);
	}

	public void iAnBBfDdWbgOiFHwNWqxFDtiXzYA(bool P_0, bool P_1, float P_2, float P_3, double P_4)
	{
		if (!GTSnoVqwoWkmoBesRSutKEZJuEs && !P_0)
		{
			return;
		}
		if (sEKGJFmKEggfOgdTEhZjakKaJmvA)
		{
			rIHajqHnUEiwtuPucoiXMrOANcqd(false, P_4);
		}
		if (!P_1)
		{
			if (GTSnoVqwoWkmoBesRSutKEZJuEs)
			{
				agvWMBoHtblzmgSmVloJbsDkfGk();
			}
			return;
		}
		if (!GTSnoVqwoWkmoBesRSutKEZJuEs || P_2 != kGZjGYghYbeEpJSRPqWweQHsPdW || P_3 != oRGqnkJXtvjxyXQNDHlnXXAFtrx)
		{
			ymnrNCikJLroNVqlDEhnXmIQYUc(P_2, P_3);
			xNRqfCbZrFcpJcVLMCeHrbgeubc(P_4);
			rIHajqHnUEiwtuPucoiXMrOANcqd(true, P_4);
		}
		if (P_2 > 0f && !dgMarBJYqOTngfSskoZGmqhwjRL)
		{
			if (P_4 - DCnGtoEqXXFJULpgdrXRbfCHyGIM <= (double)P_2)
			{
				return;
			}
			rIHajqHnUEiwtuPucoiXMrOANcqd(true, P_4);
			dgMarBJYqOTngfSskoZGmqhwjRL = true;
		}
		if (P_4 - HYWHtZziSFIoCsmgTRZrDnICYmS >= (double)NVBIeXeFtmDOXfKAumbqxqnduPZ)
		{
			rIHajqHnUEiwtuPucoiXMrOANcqd(true, P_4);
		}
	}

	public void ymnrNCikJLroNVqlDEhnXmIQYUc(float P_0, float P_1)
	{
		kGZjGYghYbeEpJSRPqWweQHsPdW = P_0;
		oRGqnkJXtvjxyXQNDHlnXXAFtrx = P_1;
		NVBIeXeFtmDOXfKAumbqxqnduPZ = 1f / P_1;
	}

	public void agvWMBoHtblzmgSmVloJbsDkfGk()
	{
		GTSnoVqwoWkmoBesRSutKEZJuEs = false;
		dgMarBJYqOTngfSskoZGmqhwjRL = false;
		HYWHtZziSFIoCsmgTRZrDnICYmS = 0.0;
		sEKGJFmKEggfOgdTEhZjakKaJmvA = false;
	}

	private void xNRqfCbZrFcpJcVLMCeHrbgeubc(double P_0)
	{
		agvWMBoHtblzmgSmVloJbsDkfGk();
		DCnGtoEqXXFJULpgdrXRbfCHyGIM = P_0;
		GTSnoVqwoWkmoBesRSutKEZJuEs = true;
	}

	private void rIHajqHnUEiwtuPucoiXMrOANcqd(bool P_0, double P_1)
	{
		if (P_0)
		{
			sEKGJFmKEggfOgdTEhZjakKaJmvA = true;
			HYWHtZziSFIoCsmgTRZrDnICYmS = P_1;
		}
		else
		{
			sEKGJFmKEggfOgdTEhZjakKaJmvA = false;
		}
	}
}
