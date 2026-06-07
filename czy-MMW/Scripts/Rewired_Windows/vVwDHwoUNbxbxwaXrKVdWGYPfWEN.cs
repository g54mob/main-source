using System;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class vVwDHwoUNbxbxwaXrKVdWGYPfWEN : IDisposable
{
	public delegate void bsDLjuXjhKSPoOuWiSOyQhJJqbGd(IntPtr reportPointer, int reportByteLength, int reportCount, double timestamp);

	private readonly bsDLjuXjhKSPoOuWiSOyQhJJqbGd xJxgTAJlHclItJJGluTgsRaTsmGj;

	private readonly rKncZWjZVnHvUSaVNIQaTXaDDRnm fUbXKKKyuTEuFTadPjXucseXKYEdA;

	private readonly ThreadHelper YPfNfsYMNzHyGfMAqKQUTokAOEztA;

	private readonly int uAWZwNfhiSBPAZgKFafVMEVSgmMv;

	private readonly int RVvkKgWuOZdQaZgYtJBVCuowVQmr;

	private readonly string WDQzRknDcwEmoXwDyIEwbiYveaUpA;

	private readonly byte[] UWUEquQWriQVXjMMGTgYUcFfgNhgA;

	private readonly byte[] hNXOxVUkUaMYkbklzcDrCGEVAZCJ;

	private int ZFKeoinkcQLSDsQCPGHcHyBATcRoA;

	private jHRGOisWsUgSmOfjKIPdpeVWEWMP MHneTEAviYYPCzKYchSNhjlSJdBeA;

	private jHRGOisWsUgSmOfjKIPdpeVWEWMP zCnBzHJPUEgwJHjduvCAJHKQZwih;

	private bool ZoPfLaOXJEgoaMmBPbcsIAfHiQUNA;

	public vVwDHwoUNbxbxwaXrKVdWGYPfWEN(string P_0, int P_1, string P_2, bsDLjuXjhKSPoOuWiSOyQhJJqbGd P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("hidDevicePath");
		}
		if (P_3 == null)
		{
			throw new ArgumentNullException("processReportDelegate");
		}
		RVvkKgWuOZdQaZgYtJBVCuowVQmr = P_1;
		if (RVvkKgWuOZdQaZgYtJBVCuowVQmr <= 0)
		{
			RVvkKgWuOZdQaZgYtJBVCuowVQmr = 512;
		}
		uAWZwNfhiSBPAZgKFafVMEVSgmMv = P_1 + 8;
		WDQzRknDcwEmoXwDyIEwbiYveaUpA = P_2;
		xJxgTAJlHclItJJGluTgsRaTsmGj = P_3;
		int num = uAWZwNfhiSBPAZgKFafVMEVSgmMv * 60;
		if (num <= 0)
		{
			Logger.LogError("Invalid report buffer size. This device \"" + P_2 + "\" will not function.");
			throw new Exception();
		}
		try
		{
			fUbXKKKyuTEuFTadPjXucseXKYEdA = new rKncZWjZVnHvUSaVNIQaTXaDDRnm(P_0, P_1, 250);
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			MHneTEAviYYPCzKYchSNhjlSJdBeA = new jHRGOisWsUgSmOfjKIPdpeVWEWMP(num);
			zCnBzHJPUEgwJHjduvCAJHKQZwih = new jHRGOisWsUgSmOfjKIPdpeVWEWMP(num);
			UWUEquQWriQVXjMMGTgYUcFfgNhgA = new byte[uAWZwNfhiSBPAZgKFafVMEVSgmMv];
			hNXOxVUkUaMYkbklzcDrCGEVAZCJ = new byte[uAWZwNfhiSBPAZgKFafVMEVSgmMv];
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			YPfNfsYMNzHyGfMAqKQUTokAOEztA = ThreadHelper.Create();
			YPfNfsYMNzHyGfMAqKQUTokAOEztA.ThreadUpdateEvent += ypprjfjsbduUlrigfWPwOZnptIti;
			YPfNfsYMNzHyGfMAqKQUTokAOEztA.Start(wait: false);
		}
		catch (Exception)
		{
			Logger.LogError("Error creating thread. This device \"" + P_2 + "\" will not function.");
			throw;
		}
	}

	public unsafe void bqvWkdRjTPgopSCWzqsSkeRWPZjv()
	{
		try
		{
			if (vYtWSomrncnsTDjpBKhrHeGuMuvt())
			{
				return;
			}
			ZfkoQzqilFukwveXdMMNyJzahuDe();
			int num = 0;
			byte[] uWUEquQWriQVXjMMGTgYUcFfgNhgA = UWUEquQWriQVXjMMGTgYUcFfgNhgA;
			fixed (byte* ptr = uWUEquQWriQVXjMMGTgYUcFfgNhgA)
			{
				while (MHneTEAviYYPCzKYchSNhjlSJdBeA.NYfwANKHSSiTHXNlMjYpTnQKClfHA(uWUEquQWriQVXjMMGTgYUcFfgNhgA, uAWZwNfhiSBPAZgKFafVMEVSgmMv) > 0)
				{
					xJxgTAJlHclItJJGluTgsRaTsmGj((IntPtr)ptr, RVvkKgWuOZdQaZgYtJBVCuowVQmr, 1, *(double*)(ptr + RVvkKgWuOZdQaZgYtJBVCuowVQmr));
					num++;
				}
			}
		}
		catch
		{
		}
	}

	private void ZfkoQzqilFukwveXdMMNyJzahuDe()
	{
		lock (MHneTEAviYYPCzKYchSNhjlSJdBeA)
		{
			lock (zCnBzHJPUEgwJHjduvCAJHKQZwih)
			{
				MiscTools.Swap(ref MHneTEAviYYPCzKYchSNhjlSJdBeA, ref zCnBzHJPUEgwJHjduvCAJHKQZwih);
			}
		}
	}

	private void ypprjfjsbduUlrigfWPwOZnptIti()
	{
		if (ZFKeoinkcQLSDsQCPGHcHyBATcRoA != 0)
		{
			Thread.Sleep(500);
			return;
		}
		try
		{
			byte[] array = hNXOxVUkUaMYkbklzcDrCGEVAZCJ;
			if (!rBwdaTrqJWMfOyzRRAkCqPEoakxK(array))
			{
				return;
			}
			lock (zCnBzHJPUEgwJHjduvCAJHKQZwih)
			{
				zCnBzHJPUEgwJHjduvCAJHKQZwih.yMmBQZGWBVpqbrweHXhWBPBAOKUpA(array, array.Length);
			}
		}
		catch
		{
		}
	}

	private bool rBwdaTrqJWMfOyzRRAkCqPEoakxK(byte[] P_0)
	{
		switch (fUbXKKKyuTEuFTadPjXucseXKYEdA.CBLtzOfRynOhSZMJLmHAUhcMjHxJ(P_0))
		{
		case rKncZWjZVnHvUSaVNIQaTXaDDRnm.MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Success:
			return true;
		case rKncZWjZVnHvUSaVNIQaTXaDDRnm.MAYBLejVoAYEMfgKvpnVbKGjcFEfb.Error:
			Thread.Sleep(500);
			break;
		case rKncZWjZVnHvUSaVNIQaTXaDDRnm.MAYBLejVoAYEMfgKvpnVbKGjcFEfb.CriticalError:
			ZFKeoinkcQLSDsQCPGHcHyBATcRoA = 1;
			break;
		}
		return false;
	}

	private bool vYtWSomrncnsTDjpBKhrHeGuMuvt()
	{
		if (ZFKeoinkcQLSDsQCPGHcHyBATcRoA != 0)
		{
			if (ZFKeoinkcQLSDsQCPGHcHyBATcRoA == 1)
			{
				Logger.LogError("Error communicating with HID device. This device \"" + WDQzRknDcwEmoXwDyIEwbiYveaUpA + "\" will not function.");
				ZFKeoinkcQLSDsQCPGHcHyBATcRoA = 2;
				try
				{
					YPfNfsYMNzHyGfMAqKQUTokAOEztA.Stop(wait: false);
				}
				catch
				{
				}
			}
			return true;
		}
		return false;
	}

	public void Dispose()
	{
		UBJHkzoaDeiGhlOrycfxgakIgxbh(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void DBeNqycYPIzrajLklnVRPyxqAgUB()
	{
		try
		{
			UBJHkzoaDeiGhlOrycfxgakIgxbh(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void UBJHkzoaDeiGhlOrycfxgakIgxbh(bool P_0)
	{
		if (ZoPfLaOXJEgoaMmBPbcsIAfHiQUNA)
		{
			return;
		}
		if (P_0)
		{
			if (YPfNfsYMNzHyGfMAqKQUTokAOEztA != null)
			{
				YPfNfsYMNzHyGfMAqKQUTokAOEztA.Dispose();
			}
			if (fUbXKKKyuTEuFTadPjXucseXKYEdA != null)
			{
				fUbXKKKyuTEuFTadPjXucseXKYEdA.Dispose();
			}
		}
		ZoPfLaOXJEgoaMmBPbcsIAfHiQUNA = true;
	}
}
