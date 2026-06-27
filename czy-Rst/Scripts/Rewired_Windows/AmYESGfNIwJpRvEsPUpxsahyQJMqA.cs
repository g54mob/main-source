using System;
using Rewired.Utils;

internal class AmYESGfNIwJpRvEsPUpxsahyQJMqA : IDisposable
{
	private readonly WCkkisRdteszJrItqAKVBwrIDACB ivNWWrpJLeyHWdGgqesfnCfCNZrn;

	private readonly int THEfmFgRZgftzIkgBtbfFceisDbq;

	private long zPQCIzMTXUVDkgILWfghnFfLSUwu;

	private long JSDhFvCMPkOJCVYDLypUMCNZIMzO;

	private int PzjREXYIDjIDJqgZLzOjdMOJHgxg;

	private bool GeNJGdrfrCCztUevJLElcdLWUSZb;

	private uint rIaHJAEJfHFaFVtXWGFcgZFMghmn;

	private bool IpywOYemkCLQNAmpXNefOHMCFAUcA;

	public int bmqLPRDaHpzZXhcpgtdrQWdmEdwP => THEfmFgRZgftzIkgBtbfFceisDbq;

	public int scgQftixQvAioGciFeYeLDkbQGGw => PzjREXYIDjIDJqgZLzOjdMOJHgxg;

	public bool yfdGheNjIBuRZbNkWgGJUdfnsCRv => GeNJGdrfrCCztUevJLElcdLWUSZb;

	public AmYESGfNIwJpRvEsPUpxsahyQJMqA(int P_0)
	{
		THEfmFgRZgftzIkgBtbfFceisDbq = P_0;
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("sizeInBytes");
		}
		ivNWWrpJLeyHWdGgqesfnCfCNZrn = new WCkkisRdteszJrItqAKVBwrIDACB(P_0);
	}

	public unsafe int oCXdCWeYmMwkrvMGmtQihsOPTZDuA(byte* P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		P_3 = (int)zPQCIzMTXUVDkgILWfghnFfLSUwu;
		P_4 = rIaHJAEJfHFaFVtXWGFcgZFMghmn;
		if (P_0 == null || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		int num = ivNWWrpJLeyHWdGgqesfnCfCNZrn.dEGzBZyfznXpjeGjYisyVbUwZQGb(P_0, P_1, P_2, (int)zPQCIzMTXUVDkgILWfghnFfLSUwu);
		if (num == 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += ivNWWrpJLeyHWdGgqesfnCfCNZrn.dEGzBZyfznXpjeGjYisyVbUwZQGb(P_0 + num, P_1 - num, P_2 - num);
		}
		iYoAIynIMByiIpdPAwdAldLZIWRi(num);
		return num;
	}

	public unsafe int yKGjFSyZUUdadsrNmtsFCtuyaJDz(IntPtr P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			P_3 = (int)zPQCIzMTXUVDkgILWfghnFfLSUwu;
			P_4 = rIaHJAEJfHFaFVtXWGFcgZFMghmn;
			return 0;
		}
		return oCXdCWeYmMwkrvMGmtQihsOPTZDuA((byte*)(void*)P_0, P_1, P_2, out P_3, out P_4);
	}

	public unsafe int OdCCiYhDXRvjroPURmeSIVlcaSAAb(byte[] P_0, int P_1, out int P_2, out uint P_3)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = (int)zPQCIzMTXUVDkgILWfghnFfLSUwu;
			P_3 = rIaHJAEJfHFaFVtXWGFcgZFMghmn;
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return oCXdCWeYmMwkrvMGmtQihsOPTZDuA(ptr, P_0.Length, P_1, out P_2, out P_3);
		}
	}

	public unsafe int ijzAIIsMoXsqFszfsiYQwkuXbvkv(byte* P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return oCXdCWeYmMwkrvMGmtQihsOPTZDuA(P_0, P_1, P_2, out num, out num2);
	}

	public int SiUkKhGnHtjEWBRxdzziGtGQlRNBA(IntPtr P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return yKGjFSyZUUdadsrNmtsFCtuyaJDz(P_0, P_1, P_2, out num, out num2);
	}

	public int qsCkhsUjteNDWUbQUeJeEndHiAeq(byte[] P_0, int P_1)
	{
		int num;
		uint num2;
		return OdCCiYhDXRvjroPURmeSIVlcaSAAb(P_0, P_1, out num, out num2);
	}

	public unsafe int kNGRJGPLGFwJHzAbHHTDDvrjtBvU(byte* P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || PzjREXYIDjIDJqgZLzOjdMOJHgxg == 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > PzjREXYIDjIDJqgZLzOjdMOJHgxg)
		{
			P_2 = PzjREXYIDjIDJqgZLzOjdMOJHgxg;
		}
		int num = ivNWWrpJLeyHWdGgqesfnCfCNZrn.hinNKUAzxSiNEYlDvdlDuDdqDGwF(P_0, P_1, P_2, (int)JSDhFvCMPkOJCVYDLypUMCNZIMzO);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += ivNWWrpJLeyHWdGgqesfnCfCNZrn.hinNKUAzxSiNEYlDvdlDuDdqDGwF(P_0 + num, P_1 - num, P_2 - num);
		}
		hypxUzCrzORghakUfXFdoFcrmmqG(num);
		return num;
	}

	public unsafe int lAQwSKSLnoFinJzHtPFEmOfGJjle(byte[] P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return kNGRJGPLGFwJHzAbHHTDDvrjtBvU(ptr, P_0.Length, P_1);
		}
	}

	public unsafe int rJMDCiIHKZhuWiUCwMklrybQbcybA(IntPtr P_0, int P_1, int P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		return kNGRJGPLGFwJHzAbHHTDDvrjtBvU((byte*)(void*)P_0, P_1, P_2);
	}

	public unsafe int GOTaZQAjiKiPKNmKPAULysiQfnFX(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || PzjREXYIDjIDJqgZLzOjdMOJHgxg == 0 || P_3 < 0 || P_3 >= THEfmFgRZgftzIkgBtbfFceisDbq)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > PzjREXYIDjIDJqgZLzOjdMOJHgxg)
		{
			P_2 = PzjREXYIDjIDJqgZLzOjdMOJHgxg;
		}
		int num = ivNWWrpJLeyHWdGgqesfnCfCNZrn.hinNKUAzxSiNEYlDvdlDuDdqDGwF(P_0, P_1, P_2, P_3);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += ivNWWrpJLeyHWdGgqesfnCfCNZrn.hinNKUAzxSiNEYlDvdlDuDdqDGwF(P_0 + num, P_1 - num, P_2 - num);
		}
		return num;
	}

	public unsafe int DrOfFkCZPQCCooAtYJYFebseRrkl(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return GOTaZQAjiKiPKNmKPAULysiQfnFX(ptr, P_0.Length, P_1, P_2);
		}
	}

	public unsafe int CVtWizKjtFvamJHndEfaBCKqGGqOA(IntPtr P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_3 <= 0)
		{
			return 0;
		}
		return GOTaZQAjiKiPKNmKPAULysiQfnFX((byte*)(void*)P_0, P_1, P_2, P_3);
	}

	public bool xZEUScjOvpTfAfFzOlrzWRMdyOeC(int P_0, uint P_1)
	{
		if (P_0 < 0 || P_0 >= THEfmFgRZgftzIkgBtbfFceisDbq)
		{
			return false;
		}
		if (P_0 < zPQCIzMTXUVDkgILWfghnFfLSUwu)
		{
			if (P_1 == rIaHJAEJfHFaFVtXWGFcgZFMghmn)
			{
				return true;
			}
		}
		else if (P_0 >= zPQCIzMTXUVDkgILWfghnFfLSUwu)
		{
			if (rIaHJAEJfHFaFVtXWGFcgZFMghmn == 0)
			{
				return false;
			}
			if (rIaHJAEJfHFaFVtXWGFcgZFMghmn - 1 == P_1)
			{
				return true;
			}
		}
		return false;
	}

	public void KnfJVCpXKyvWxPtCUqFHQRpSQozD()
	{
		zPQCIzMTXUVDkgILWfghnFfLSUwu = 0L;
		JSDhFvCMPkOJCVYDLypUMCNZIMzO = 0L;
		PzjREXYIDjIDJqgZLzOjdMOJHgxg = 0;
		GeNJGdrfrCCztUevJLElcdLWUSZb = false;
		rIaHJAEJfHFaFVtXWGFcgZFMghmn = 0u;
	}

	private void iYoAIynIMByiIpdPAwdAldLZIWRi(int P_0)
	{
		if (P_0 <= 0)
		{
			return;
		}
		int num = (int)zPQCIzMTXUVDkgILWfghnFfLSUwu;
		zPQCIzMTXUVDkgILWfghnFfLSUwu += P_0;
		bool flag = false;
		if (num < JSDhFvCMPkOJCVYDLypUMCNZIMzO)
		{
			if (zPQCIzMTXUVDkgILWfghnFfLSUwu > JSDhFvCMPkOJCVYDLypUMCNZIMzO)
			{
				flag = true;
			}
		}
		else if (num > JSDhFvCMPkOJCVYDLypUMCNZIMzO)
		{
			if (zPQCIzMTXUVDkgILWfghnFfLSUwu - THEfmFgRZgftzIkgBtbfFceisDbq > JSDhFvCMPkOJCVYDLypUMCNZIMzO)
			{
				flag = true;
			}
		}
		else if (PzjREXYIDjIDJqgZLzOjdMOJHgxg > 0)
		{
			flag = true;
		}
		if (flag)
		{
			GeNJGdrfrCCztUevJLElcdLWUSZb = true;
			JSDhFvCMPkOJCVYDLypUMCNZIMzO = zPQCIzMTXUVDkgILWfghnFfLSUwu;
			if (JSDhFvCMPkOJCVYDLypUMCNZIMzO >= THEfmFgRZgftzIkgBtbfFceisDbq)
			{
				JSDhFvCMPkOJCVYDLypUMCNZIMzO -= THEfmFgRZgftzIkgBtbfFceisDbq;
			}
		}
		if (zPQCIzMTXUVDkgILWfghnFfLSUwu >= THEfmFgRZgftzIkgBtbfFceisDbq)
		{
			zPQCIzMTXUVDkgILWfghnFfLSUwu -= THEfmFgRZgftzIkgBtbfFceisDbq;
			rMqiUOVIQouMfDjTWzcfDenblwin();
		}
		PzjREXYIDjIDJqgZLzOjdMOJHgxg = (int)MathTools.Clamp((long)PzjREXYIDjIDJqgZLzOjdMOJHgxg + (long)P_0, 0L, THEfmFgRZgftzIkgBtbfFceisDbq);
	}

	private void hypxUzCrzORghakUfXFdoFcrmmqG(int P_0)
	{
		if (P_0 > 0)
		{
			if (GeNJGdrfrCCztUevJLElcdLWUSZb)
			{
				GeNJGdrfrCCztUevJLElcdLWUSZb = false;
			}
			JSDhFvCMPkOJCVYDLypUMCNZIMzO += P_0;
			if (JSDhFvCMPkOJCVYDLypUMCNZIMzO >= THEfmFgRZgftzIkgBtbfFceisDbq)
			{
				JSDhFvCMPkOJCVYDLypUMCNZIMzO -= THEfmFgRZgftzIkgBtbfFceisDbq;
			}
			long num = (long)PzjREXYIDjIDJqgZLzOjdMOJHgxg - (long)P_0;
			PzjREXYIDjIDJqgZLzOjdMOJHgxg = (int)((num >= 0) ? num : 0);
		}
	}

	private void rMqiUOVIQouMfDjTWzcfDenblwin()
	{
		if (rIaHJAEJfHFaFVtXWGFcgZFMghmn == uint.MaxValue)
		{
			rIaHJAEJfHFaFVtXWGFcgZFMghmn = 0u;
		}
		else
		{
			rIaHJAEJfHFaFVtXWGFcgZFMghmn++;
		}
	}

	public void Dispose()
	{
		dKsqIRKSGLwFjXEVemuSwZqRVuDI(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void SPTJrtYJkUpoPmPIMqYLYZCmCYFG()
	{
		try
		{
			dKsqIRKSGLwFjXEVemuSwZqRVuDI(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void dKsqIRKSGLwFjXEVemuSwZqRVuDI(bool P_0)
	{
		if (!IpywOYemkCLQNAmpXNefOHMCFAUcA)
		{
			if (P_0 && ivNWWrpJLeyHWdGgqesfnCfCNZrn != null)
			{
				ivNWWrpJLeyHWdGgqesfnCfCNZrn.Dispose();
			}
			IpywOYemkCLQNAmpXNefOHMCFAUcA = true;
		}
	}
}
