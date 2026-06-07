internal static class nTeWMHoeeeDrcnFVrUHTkDjFkqW
{
	private class hCqIIObGnOaqIgeYbjVJVZYxiDxNA
	{
		public readonly ushort WvXBrBIBgseVAULJtnygjAIrPFNWA;

		public readonly ushort IHTOcxSkXsrDFoXJgARCRBLlsZmg;

		public readonly string QPbeRRbOGahciPDTGGHLPZWeeIVo;

		public readonly bool afhVOBRoosKYsfPUbDwhPPyqsRNh;

		public readonly int RLHiNJRcyVDdHEtLHkfZvEtIecydb;

		public readonly int kllVguiNgCiVvQeJAiCZfUnvrnXBA;

		public readonly int IRsxGbxUglQAbYcsLEhWcUoGHEzSA;

		public readonly float BUHFcEEoDmkiuMVqaNniIczbsXsm;

		public hCqIIObGnOaqIgeYbjVJVZYxiDxNA(ushort P_0, ushort P_1, string P_2, bool P_3, int P_4, int P_5, int P_6, float P_7)
		{
			WvXBrBIBgseVAULJtnygjAIrPFNWA = P_0;
			IHTOcxSkXsrDFoXJgARCRBLlsZmg = P_1;
			if (string.IsNullOrEmpty(P_2))
			{
				P_2 = string.Empty;
			}
			QPbeRRbOGahciPDTGGHLPZWeeIVo = P_2;
			afhVOBRoosKYsfPUbDwhPPyqsRNh = P_3;
			RLHiNJRcyVDdHEtLHkfZvEtIecydb = P_4;
			kllVguiNgCiVvQeJAiCZfUnvrnXBA = P_5;
			IRsxGbxUglQAbYcsLEhWcUoGHEzSA = P_6;
			BUHFcEEoDmkiuMVqaNniIczbsXsm = P_7;
		}

		public bool SXfcxcMYKBqYQwtHIbUWiqfGsDLC(ushort P_0, ushort P_1)
		{
			if (WvXBrBIBgseVAULJtnygjAIrPFNWA == P_0)
			{
				return IHTOcxSkXsrDFoXJgARCRBLlsZmg == P_1;
			}
			return false;
		}

		public bool XskRBOwgdiwPWCENofnSAIwNaasN(ushort P_0, ushort P_1, string P_2)
		{
			if (WvXBrBIBgseVAULJtnygjAIrPFNWA != P_0 || IHTOcxSkXsrDFoXJgARCRBLlsZmg != P_1)
			{
				if (!string.IsNullOrEmpty(P_2))
				{
					return QPbeRRbOGahciPDTGGHLPZWeeIVo == P_2;
				}
				return false;
			}
			return true;
		}

		public bool XalTjjFNLmODjIFeESjNnENymzZj(string P_0)
		{
			if (!string.IsNullOrEmpty(P_0))
			{
				return QPbeRRbOGahciPDTGGHLPZWeeIVo == P_0;
			}
			return false;
		}
	}

	private const float moRwRMKJvoaIlKFdWOVAcZgiILxRA = 0.034f;

	private static hCqIIObGnOaqIgeYbjVJVZYxiDxNA[] guYfVBQGIwAZTnBRPFYaZqCjHdDFA = new hCqIIObGnOaqIgeYbjVJVZYxiDxNA[3]
	{
		new hCqIIObGnOaqIgeYbjVJVZYxiDxNA(1133, 50726, "SpaceNavigator", true, -350, 350, 0, 0.034f),
		new hCqIIObGnOaqIgeYbjVJVZYxiDxNA(1133, 50728, "SpaceNavigator for Notebooks", true, -350, 350, 0, 0.034f),
		new hCqIIObGnOaqIgeYbjVJVZYxiDxNA(1133, 50727, "Space Explorer", true, -350, 350, 0, 0.034f)
	};

	public static bool pXfiUJNVcdTJNwGoGbKgEgZhjpLFb(ushort P_0, ushort P_1, string P_2 = null)
	{
		return oTzurTTXpuVnrQxysmbhAqKhFOIEA(P_0, P_1, P_2)?.afhVOBRoosKYsfPUbDwhPPyqsRNh ?? false;
	}

	public static float WUktugqnNKNKpiwRZLjKXkFHFhod(ushort P_0, ushort P_1, string P_2 = null)
	{
		return oTzurTTXpuVnrQxysmbhAqKhFOIEA(P_0, P_1, P_2)?.BUHFcEEoDmkiuMVqaNniIczbsXsm ?? 0f;
	}

	public static bool gfcYzscKMbjUqfnbRrxtHgBznSDL(ushort P_0, ushort P_1, out int P_2, out int P_3, out int P_4)
	{
		return dQpmAwaxayWnzzoseTFugUUgcJQU(P_0, P_1, null, out P_2, out P_3, out P_4);
	}

	public static bool dQpmAwaxayWnzzoseTFugUUgcJQU(ushort P_0, ushort P_1, string P_2, out int P_3, out int P_4, out int P_5)
	{
		for (int i = 0; i < guYfVBQGIwAZTnBRPFYaZqCjHdDFA.Length; i++)
		{
			if (guYfVBQGIwAZTnBRPFYaZqCjHdDFA[i].SXfcxcMYKBqYQwtHIbUWiqfGsDLC(P_0, P_1) && guYfVBQGIwAZTnBRPFYaZqCjHdDFA[i].afhVOBRoosKYsfPUbDwhPPyqsRNh)
			{
				P_3 = guYfVBQGIwAZTnBRPFYaZqCjHdDFA[i].RLHiNJRcyVDdHEtLHkfZvEtIecydb;
				P_4 = guYfVBQGIwAZTnBRPFYaZqCjHdDFA[i].kllVguiNgCiVvQeJAiCZfUnvrnXBA;
				P_5 = guYfVBQGIwAZTnBRPFYaZqCjHdDFA[i].IRsxGbxUglQAbYcsLEhWcUoGHEzSA;
				return true;
			}
		}
		P_3 = 0;
		P_4 = 0;
		P_5 = 0;
		return false;
	}

	public static bool lckigNchCycMYiOpHGVBkEZgwYGTA(ushort P_0, ushort P_1, string P_2 = null)
	{
		return JznPHMVDKvEUrZZOczqPUjeuNRdG(P_0, P_1, P_2);
	}

	private static bool JznPHMVDKvEUrZZOczqPUjeuNRdG(ushort P_0, ushort P_1, string P_2 = null)
	{
		for (int i = 0; i < guYfVBQGIwAZTnBRPFYaZqCjHdDFA.Length; i++)
		{
			if (guYfVBQGIwAZTnBRPFYaZqCjHdDFA[i].XskRBOwgdiwPWCENofnSAIwNaasN(P_0, P_1, P_2))
			{
				return true;
			}
		}
		return false;
	}

	private static hCqIIObGnOaqIgeYbjVJVZYxiDxNA oTzurTTXpuVnrQxysmbhAqKhFOIEA(ushort P_0, ushort P_1, string P_2 = null)
	{
		for (int i = 0; i < guYfVBQGIwAZTnBRPFYaZqCjHdDFA.Length; i++)
		{
			if (guYfVBQGIwAZTnBRPFYaZqCjHdDFA[i].XskRBOwgdiwPWCENofnSAIwNaasN(P_0, P_1, P_2))
			{
				return guYfVBQGIwAZTnBRPFYaZqCjHdDFA[i];
			}
		}
		return null;
	}
}
