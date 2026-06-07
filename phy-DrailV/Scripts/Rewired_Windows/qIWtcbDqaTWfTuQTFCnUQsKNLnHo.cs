using System.Collections.Generic;
using Rewired.Utils;

internal class qIWtcbDqaTWfTuQTFCnUQsKNLnHo : WErDDYThxcbBFEvbBtlzKjaefNqXA
{
	private List<ZIeBKuImobgJGILDYjgbDiRQIQbB> oVEmpxaxChhRYcvwhbAQQVUIiwqo;

	private ZIeBKuImobgJGILDYjgbDiRQIQbB[] vNbLXpdriUEhrSYYrnSXqSmOlDSO;

	private bool oxjLOIfwbHnYPSUnaiOoXXQlncI;

	public qIWtcbDqaTWfTuQTFCnUQsKNLnHo()
	{
		oVEmpxaxChhRYcvwhbAQQVUIiwqo = new List<ZIeBKuImobgJGILDYjgbDiRQIQbB>();
	}

	public override void FVoJqePFpjwsiVDMSgtXBtUfroYv(ZIeBKuImobgJGILDYjgbDiRQIQbB P_0)
	{
		oVEmpxaxChhRYcvwhbAQQVUIiwqo.Add(P_0);
	}

	public float mkqEwjEWKTccoblNpohIPzhMuvaL(int P_0)
	{
		if (P_0 < 0 || P_0 >= vNbLXpdriUEhrSYYrnSXqSmOlDSO.Length)
		{
			return 0f;
		}
		return XkqINHLcERmXREsNUNSKIBnJXSoW(vNbLXpdriUEhrSYYrnSXqSmOlDSO[P_0].pWRdAJigDslyLjNIYbVMMkTWOPgC);
	}

	public int UjBkmnDCfQvJySSLDxrAehDCKEbp(int P_0)
	{
		if (P_0 < 0 || P_0 >= vNbLXpdriUEhrSYYrnSXqSmOlDSO.Length)
		{
			return 0;
		}
		return (int)vNbLXpdriUEhrSYYrnSXqSmOlDSO[P_0].QGEPzKgIedvthGPliWOduwXNjWui;
	}

	public override void dNfeBnqeUWgYyRNVQKxEzMDuermR()
	{
		if (!oxjLOIfwbHnYPSUnaiOoXXQlncI)
		{
			oxjLOIfwbHnYPSUnaiOoXXQlncI = true;
			vNbLXpdriUEhrSYYrnSXqSmOlDSO = oVEmpxaxChhRYcvwhbAQQVUIiwqo.ToArray();
			oVEmpxaxChhRYcvwhbAQQVUIiwqo = null;
		}
	}

	private static float XkqINHLcERmXREsNUNSKIBnJXSoW(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
