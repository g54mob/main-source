using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class pgLfuJytUzHNywlhBuSxXGsrwvQS : PlatformInputManager, INativePlatformHelper
{
	private class qXLQjnwQjHivKSbhLPcyjmEuroSl
	{
		private class QrKrmTkCJgQriYVdUlmrVlTlETtB
		{
			public int SsqEtzpOjEGzxNDVvmXXmCnXHKHk;

			public int xjqaGKbTeCvkgHdQeUDcxztIDYdAb;

			public int beEqTWmqSSFEOekqvkjSbGQlffaaA;

			public InputSource PZDuHnDnOKtOEeQLdfJquXnadVXCA;

			public QrKrmTkCJgQriYVdUlmrVlTlETtB(int P_0, int P_1, int P_2, InputSource P_3)
			{
				SsqEtzpOjEGzxNDVvmXXmCnXHKHk = P_0;
				xjqaGKbTeCvkgHdQeUDcxztIDYdAb = P_1;
				beEqTWmqSSFEOekqvkjSbGQlffaaA = P_2;
				PZDuHnDnOKtOEeQLdfJquXnadVXCA = P_3;
			}

			public void MBgXLXqcWsMAiCPIxdEcXtJXXAve(int P_0)
			{
				xjqaGKbTeCvkgHdQeUDcxztIDYdAb = P_0;
			}

			public hKZUdVWLGClISfMVCdQlzeJIbGPeA pdnjveOwKYwfmtKzyWpGciNBkjYm()
			{
				return new hKZUdVWLGClISfMVCdQlzeJIbGPeA(SsqEtzpOjEGzxNDVvmXXmCnXHKHk, xjqaGKbTeCvkgHdQeUDcxztIDYdAb, PZDuHnDnOKtOEeQLdfJquXnadVXCA);
			}

			public static int mCldgmgUPDqWcYGVhrxghUANZcSiA(QrKrmTkCJgQriYVdUlmrVlTlETtB P_0, QrKrmTkCJgQriYVdUlmrVlTlETtB P_1)
			{
				if (P_0.SsqEtzpOjEGzxNDVvmXXmCnXHKHk < P_1.SsqEtzpOjEGzxNDVvmXXmCnXHKHk)
				{
					return -1;
				}
				if (P_0.SsqEtzpOjEGzxNDVvmXXmCnXHKHk > P_1.SsqEtzpOjEGzxNDVvmXXmCnXHKHk)
				{
					return 1;
				}
				return 0;
			}
		}

		public struct hKZUdVWLGClISfMVCdQlzeJIbGPeA
		{
			public int DWciQLPzNIhErLoojVTyCMHsANML;

			public int cgsvLscukHlCfukUxBqLHwgiDRwaA;

			public InputSource fvCcvlHvwkWGvDseFsVZOQkwIsSC;

			public hKZUdVWLGClISfMVCdQlzeJIbGPeA(int P_0, int P_1, InputSource P_2)
			{
				DWciQLPzNIhErLoojVTyCMHsANML = P_0;
				cgsvLscukHlCfukUxBqLHwgiDRwaA = P_1;
				fvCcvlHvwkWGvDseFsVZOQkwIsSC = P_2;
			}
		}

		public enum cwXlCXNoaYwjEOSUOEkHRmSxXhdP
		{
			Connected = 0,
			Disconnected = 1
		}

		private List<QrKrmTkCJgQriYVdUlmrVlTlETtB> XifCmmLPNQtZSfNfYhZnbKRmAraR;

		private List<QrKrmTkCJgQriYVdUlmrVlTlETtB> MGzyVohwqKMZsUzythWQpAkvdYhA;

		public int SZxUaGoYxTRYrcdWbKIwbTlTpynn => MGzyVohwqKMZsUzythWQpAkvdYhA.Count;

		public qXLQjnwQjHivKSbhLPcyjmEuroSl()
		{
			MGzyVohwqKMZsUzythWQpAkvdYhA = new List<QrKrmTkCJgQriYVdUlmrVlTlETtB>();
			XifCmmLPNQtZSfNfYhZnbKRmAraR = new List<QrKrmTkCJgQriYVdUlmrVlTlETtB>();
		}

		public void zYlGDhYgRqSkXYNmtfQhBHPIdukiA(BridgedController P_0)
		{
			if (P_0 == null || P_0.sourceJoystick == null)
			{
				return;
			}
			IInputManagerJoystickPublic sourceJoystick = P_0.sourceJoystick;
			int num = SzNimueXqdvudUomKKMmnqpDlyBH(sourceJoystick.rewiredId, cwXlCXNoaYwjEOSUOEkHRmSxXhdP.Connected);
			QrKrmTkCJgQriYVdUlmrVlTlETtB qrKrmTkCJgQriYVdUlmrVlTlETtB;
			if (num >= 0)
			{
				qrKrmTkCJgQriYVdUlmrVlTlETtB = MGzyVohwqKMZsUzythWQpAkvdYhA[num];
				qrKrmTkCJgQriYVdUlmrVlTlETtB.MBgXLXqcWsMAiCPIxdEcXtJXXAve(sourceJoystick.inputManagerId);
				P_0.sourceJoystick = new fkOgjiqnQDItvQBjONzFGCyWoiyL(sourceJoystick, qrKrmTkCJgQriYVdUlmrVlTlETtB.SsqEtzpOjEGzxNDVvmXXmCnXHKHk);
				return;
			}
			num = SzNimueXqdvudUomKKMmnqpDlyBH(sourceJoystick.rewiredId, cwXlCXNoaYwjEOSUOEkHRmSxXhdP.Disconnected);
			if (num >= 0)
			{
				qrKrmTkCJgQriYVdUlmrVlTlETtB = XifCmmLPNQtZSfNfYhZnbKRmAraR[num];
				XifCmmLPNQtZSfNfYhZnbKRmAraR.RemoveAt(num);
				int ssqEtzpOjEGzxNDVvmXXmCnXHKHk = DeVeGPqBxJBoZePTiqglqhzGtpii(qrKrmTkCJgQriYVdUlmrVlTlETtB.SsqEtzpOjEGzxNDVvmXXmCnXHKHk);
				qrKrmTkCJgQriYVdUlmrVlTlETtB.SsqEtzpOjEGzxNDVvmXXmCnXHKHk = ssqEtzpOjEGzxNDVvmXXmCnXHKHk;
			}
			else
			{
				qrKrmTkCJgQriYVdUlmrVlTlETtB = new QrKrmTkCJgQriYVdUlmrVlTlETtB(zpRTjGLChgzomVeJlctlRMDLbjal(), sourceJoystick.inputManagerId, sourceJoystick.rewiredId, P_0.inputManagerSource);
			}
			P_0.sourceJoystick = new fkOgjiqnQDItvQBjONzFGCyWoiyL(sourceJoystick, qrKrmTkCJgQriYVdUlmrVlTlETtB.SsqEtzpOjEGzxNDVvmXXmCnXHKHk);
			MGzyVohwqKMZsUzythWQpAkvdYhA.Add(qrKrmTkCJgQriYVdUlmrVlTlETtB);
			MGzyVohwqKMZsUzythWQpAkvdYhA.Sort(QrKrmTkCJgQriYVdUlmrVlTlETtB.mCldgmgUPDqWcYGVhrxghUANZcSiA);
		}

		public void ZdBPePViVcEEpBaErdbTlEJvFbcyA(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				int num = SzNimueXqdvudUomKKMmnqpDlyBH(P_0.rewiredId, cwXlCXNoaYwjEOSUOEkHRmSxXhdP.Connected);
				if (num < 0)
				{
					Logger.LogError("Device was not in connected list! Cannot remove!");
					return;
				}
				QrKrmTkCJgQriYVdUlmrVlTlETtB item = MGzyVohwqKMZsUzythWQpAkvdYhA[num];
				MGzyVohwqKMZsUzythWQpAkvdYhA.RemoveAt(num);
				XifCmmLPNQtZSfNfYhZnbKRmAraR.Add(item);
			}
		}

		public void yxalfWWBUTFBEvpzBnhJlUMXWakM(int P_0, int P_1)
		{
			int num = SzNimueXqdvudUomKKMmnqpDlyBH(P_0, cwXlCXNoaYwjEOSUOEkHRmSxXhdP.Connected);
			if (num >= 0)
			{
				MGzyVohwqKMZsUzythWQpAkvdYhA[num].MBgXLXqcWsMAiCPIxdEcXtJXXAve(P_1);
				return;
			}
			num = SzNimueXqdvudUomKKMmnqpDlyBH(P_0, cwXlCXNoaYwjEOSUOEkHRmSxXhdP.Disconnected);
			if (num >= 0)
			{
				XifCmmLPNQtZSfNfYhZnbKRmAraR[num].MBgXLXqcWsMAiCPIxdEcXtJXXAve(P_1);
			}
		}

		public bool RimWAGCFWPNIKOdXFekccnfReHkE(int P_0, cwXlCXNoaYwjEOSUOEkHRmSxXhdP P_1)
		{
			if (SzNimueXqdvudUomKKMmnqpDlyBH(P_0, P_1) < 0)
			{
				return false;
			}
			return true;
		}

		public int SzNimueXqdvudUomKKMmnqpDlyBH(int P_0, cwXlCXNoaYwjEOSUOEkHRmSxXhdP P_1)
		{
			switch (P_1)
			{
			case cwXlCXNoaYwjEOSUOEkHRmSxXhdP.Connected:
			{
				int count2 = MGzyVohwqKMZsUzythWQpAkvdYhA.Count;
				for (int j = 0; j < count2; j++)
				{
					if (MGzyVohwqKMZsUzythWQpAkvdYhA[j].beEqTWmqSSFEOekqvkjSbGQlffaaA == P_0)
					{
						return j;
					}
				}
				break;
			}
			case cwXlCXNoaYwjEOSUOEkHRmSxXhdP.Disconnected:
			{
				int count = XifCmmLPNQtZSfNfYhZnbKRmAraR.Count;
				for (int i = 0; i < count; i++)
				{
					if (XifCmmLPNQtZSfNfYhZnbKRmAraR[i].beEqTWmqSSFEOekqvkjSbGQlffaaA == P_0)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public int aBqYzXESYkPozeBJyYBptiHQxEVr(int P_0, InputSource P_1, cwXlCXNoaYwjEOSUOEkHRmSxXhdP P_2)
		{
			switch (P_2)
			{
			case cwXlCXNoaYwjEOSUOEkHRmSxXhdP.Connected:
			{
				int count2 = MGzyVohwqKMZsUzythWQpAkvdYhA.Count;
				for (int j = 0; j < count2; j++)
				{
					if (MGzyVohwqKMZsUzythWQpAkvdYhA[j].SsqEtzpOjEGzxNDVvmXXmCnXHKHk == P_0 && MGzyVohwqKMZsUzythWQpAkvdYhA[j].PZDuHnDnOKtOEeQLdfJquXnadVXCA == P_1)
					{
						return j;
					}
				}
				break;
			}
			case cwXlCXNoaYwjEOSUOEkHRmSxXhdP.Disconnected:
			{
				int count = XifCmmLPNQtZSfNfYhZnbKRmAraR.Count;
				for (int i = 0; i < count; i++)
				{
					if (XifCmmLPNQtZSfNfYhZnbKRmAraR[i].SsqEtzpOjEGzxNDVvmXXmCnXHKHk == P_0 && XifCmmLPNQtZSfNfYhZnbKRmAraR[i].PZDuHnDnOKtOEeQLdfJquXnadVXCA == P_1)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public hKZUdVWLGClISfMVCdQlzeJIbGPeA RHWUYcgcMgLvKSjgunvpEAuTZopD(int P_0, cwXlCXNoaYwjEOSUOEkHRmSxXhdP P_1)
		{
			if (P_1 == cwXlCXNoaYwjEOSUOEkHRmSxXhdP.Connected)
			{
				if (P_0 < 0 || P_0 >= MGzyVohwqKMZsUzythWQpAkvdYhA.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				return MGzyVohwqKMZsUzythWQpAkvdYhA[P_0].pdnjveOwKYwfmtKzyWpGciNBkjYm();
			}
			if (P_0 < 0 || P_0 >= XifCmmLPNQtZSfNfYhZnbKRmAraR.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return XifCmmLPNQtZSfNfYhZnbKRmAraR[P_0].pdnjveOwKYwfmtKzyWpGciNBkjYm();
		}

		public int UliSDmjoRHjByAVSLKaEVCImRsDi(int P_0, InputSource P_1, cwXlCXNoaYwjEOSUOEkHRmSxXhdP P_2)
		{
			int num = aBqYzXESYkPozeBJyYBptiHQxEVr(P_0, P_1, P_2);
			if (num < 0)
			{
				return -1;
			}
			return P_2 switch
			{
				cwXlCXNoaYwjEOSUOEkHRmSxXhdP.Connected => MGzyVohwqKMZsUzythWQpAkvdYhA[num].xjqaGKbTeCvkgHdQeUDcxztIDYdAb, 
				cwXlCXNoaYwjEOSUOEkHRmSxXhdP.Disconnected => XifCmmLPNQtZSfNfYhZnbKRmAraR[num].xjqaGKbTeCvkgHdQeUDcxztIDYdAb, 
				_ => -1, 
			};
		}

		private int DeVeGPqBxJBoZePTiqglqhzGtpii(int P_0)
		{
			int count = MGzyVohwqKMZsUzythWQpAkvdYhA.Count;
			for (int i = 0; i < count; i++)
			{
				if (MGzyVohwqKMZsUzythWQpAkvdYhA[i].SsqEtzpOjEGzxNDVvmXXmCnXHKHk == P_0)
				{
					return zpRTjGLChgzomVeJlctlRMDLbjal();
				}
			}
			return P_0;
		}

		private int zpRTjGLChgzomVeJlctlRMDLbjal()
		{
			int count = MGzyVohwqKMZsUzythWQpAkvdYhA.Count;
			int num = 0;
			while (true)
			{
				bool flag = false;
				for (int i = 0; i < count; i++)
				{
					if (MGzyVohwqKMZsUzythWQpAkvdYhA[i].SsqEtzpOjEGzxNDVvmXXmCnXHKHk == num)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
				num++;
			}
			return num;
		}
	}

	private class fkOgjiqnQDItvQBjONzFGCyWoiyL : IInputManagerJoystickPublic
	{
		private IInputManagerJoystickPublic sHibuWWssIdrQWSgMYBfBlCagbSS;

		private int WiZRXXoEAjOLMCmIFClEAxCwTpXmA;

		int IInputManagerJoystickPublic.rewiredId => sHibuWWssIdrQWSgMYBfBlCagbSS.rewiredId;

		int IInputManagerJoystickPublic.inputManagerId => WiZRXXoEAjOLMCmIFClEAxCwTpXmA;

		string IInputManagerJoystickPublic.name => sHibuWWssIdrQWSgMYBfBlCagbSS.name;

		long? IInputManagerJoystickPublic.systemId => sHibuWWssIdrQWSgMYBfBlCagbSS.systemId;

		int IInputManagerJoystickPublic.unityId => sHibuWWssIdrQWSgMYBfBlCagbSS.unityId;

		Guid IInputManagerJoystickPublic.instanceGuid => sHibuWWssIdrQWSgMYBfBlCagbSS.instanceGuid;

		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		Controller.Extension IInputManagerJoystickPublic.extension => sHibuWWssIdrQWSgMYBfBlCagbSS.extension;

		public fkOgjiqnQDItvQBjONzFGCyWoiyL(IInputManagerJoystickPublic P_0, int P_1)
		{
			sHibuWWssIdrQWSgMYBfBlCagbSS = P_0;
			WiZRXXoEAjOLMCmIFClEAxCwTpXmA = P_1;
		}

		public void SetVibration(float amount, int motorIndex)
		{
			sHibuWWssIdrQWSgMYBfBlCagbSS.SetVibration(amount, motorIndex);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		public void StopVibration()
		{
			sHibuWWssIdrQWSgMYBfBlCagbSS.StopVibration();
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}
	}

	private sealed class ogSFrKBgWBFebCZoPgmDlPNWhBFvA
	{
		public int CQjewfgizQuJjqeHbfaYIVICBsQY;

		internal int TKRjtDlUBoWAYwKXaSlUfqHvGlso()
		{
			return CQjewfgizQuJjqeHbfaYIVICBsQY++;
		}
	}

	private const bool cHjxDNFXPkUpqxefmmwweBVNIDBm = false;

	private const bool AtWeDvYFsbWSpESvVBPPMYCoPcmI = false;

	private const bool sGKQZohsnvHsdHHwKAZwEOKfoSIBA = false;

	private const bool nNfUwyzDyYcnlSTXPeyGKLepaaLFA = false;

	private const bool LasHxYiRmFfFBLYQLRyBfttFMRmS = false;

	private bool spoTywsgQVMPRUCMlbJufHLOFIrV;

	private object PKWcopGQGifHBXMfUYXFsJQxudMd;

	private IndexedDictionary<int, PlatformInputManager> UdDVajqHjAUeFUZEiPyApPDsnpTJ;

	private qXLQjnwQjHivKSbhLPcyjmEuroSl iftHPbeEppCFKPlUMZduNDukntYDA;

	private Action<int, ControllerDataUpdater> uVOrNnkkLllmpDmvOUWKlNNZlxtT;

	private WindowsStandalonePrimaryInputSource JOQsWrfJDAGTZJxHVNoQYFehTEWm;

	private bool TSUBrOFQGHrXcTNDvNMpwRaBcmBZ;

	private PlatformInputManager zmfFHiCPTYbyEONdryEPDDKQBpfB;

	private bool EaXsswlwXuhdSMsBxjKELMfOHAAhA;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> ppCwHUroExQzcfJJNHeqzNejQYnU;

	private Func<int> zJayxUMyrRpvDhxteklTZuahjdWm;

	[CustomObfuscation(rename = false)]
	private int counter;

	bool INativePlatformHelper.isApplicationFocused
	{
		get
		{
			IntPtr intPtr = FTdbbIUhAgYSHUHmiEJUirkRZXhf.DusapxwwStwmAFEWSdmyAkcNCjJcb();
			IntPtr intPtr2 = FTdbbIUhAgYSHUHmiEJUirkRZXhf.NwoSuizDgFairJkCGeEaeWUEahWaB();
			if (intPtr2 != IntPtr.Zero)
			{
				return intPtr == intPtr2;
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => iftHPbeEppCFKPlUMZduNDukntYDA.SZxUaGoYxTRYrcdWbKIwbTlTpynn;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => zmfFHiCPTYbyEONdryEPDDKQBpfB;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => zmfFHiCPTYbyEONdryEPDDKQBpfB.inputSource;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType
	{
		get
		{
			if (zmfFHiCPTYbyEONdryEPDDKQBpfB == null)
			{
				return InputSource.None;
			}
			return zmfFHiCPTYbyEONdryEPDDKQBpfB.inputSourceType;
		}
	}

	public pgLfuJytUzHNywlhBuSxXGsrwvQS(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2)
	{
		JOQsWrfJDAGTZJxHVNoQYFehTEWm = P_0.windowsStandalonePrimaryInputSource;
		TSUBrOFQGHrXcTNDvNMpwRaBcmBZ = P_0.useXInput;
		ppCwHUroExQzcfJJNHeqzNejQYnU = P_1;
		zJayxUMyrRpvDhxteklTZuahjdWm = P_2;
		bool flag = false;
		UdDVajqHjAUeFUZEiPyApPDsnpTJ = new IndexedDictionary<int, PlatformInputManager>();
		if (UnityTools.platform != Platform.WindowsAppStore)
		{
			try
			{
				lOimudEEADkCsfXveaIQPguQeEbk.wSehDJUGscGiTKfpCfwnpqOXPkfaA();
				kBlORBrVkJHCZIVleGtNzzXesTUe kBlORBrVkJHCZIVleGtNzzXesTUe2 = (kBlORBrVkJHCZIVleGtNzzXesTUe)(PKWcopGQGifHBXMfUYXFsJQxudMd = new kBlORBrVkJHCZIVleGtNzzXesTUe());
				bool flag2 = false;
				if (JOQsWrfJDAGTZJxHVNoQYFehTEWm == WindowsStandalonePrimaryInputSource.DirectInput)
				{
					flag2 = FnCgoNgSQlfxLVtFOOoJizsUyURZ(P_0, kBlORBrVkJHCZIVleGtNzzXesTUe2);
					if (!flag2)
					{
						Logger.Log("Attempting to fallback to Raw Input...");
						flag2 = qqRoLKyfFrxWZjIbSQWJEVuvoGqm(P_0, kBlORBrVkJHCZIVleGtNzzXesTUe2);
						if (flag2)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							JOQsWrfJDAGTZJxHVNoQYFehTEWm = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized!");
						}
					}
				}
				else if (JOQsWrfJDAGTZJxHVNoQYFehTEWm == WindowsStandalonePrimaryInputSource.RawInput)
				{
					flag2 = qqRoLKyfFrxWZjIbSQWJEVuvoGqm(P_0, kBlORBrVkJHCZIVleGtNzzXesTUe2);
					if (!flag2)
					{
						Logger.Log("Attempting to fallback to Direct Input...");
						flag2 = FnCgoNgSQlfxLVtFOOoJizsUyURZ(P_0, kBlORBrVkJHCZIVleGtNzzXesTUe2);
						if (flag2)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.DirectInput;
							JOQsWrfJDAGTZJxHVNoQYFehTEWm = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Direct Input initialized!");
						}
					}
				}
				else if (JOQsWrfJDAGTZJxHVNoQYFehTEWm == WindowsStandalonePrimaryInputSource.XInput)
				{
					flag2 = HbghNSHGUpjuKKUrSBZgXnruffIMA(P_0, false);
					if (flag2)
					{
						mslGzCjaqPmbMbyhJWUOEKDJaPMj(P_0, kBlORBrVkJHCZIVleGtNzzXesTUe2);
					}
					flag = flag2;
				}
				if (!flag2)
				{
					throw new Exception();
				}
				kBlORBrVkJHCZIVleGtNzzXesTUe2.yQIhocMfasARSdMKdFWsLsmNxpsX += TWCxLAClndjKveaSxizSNJWRPJSdA;
				kBlORBrVkJHCZIVleGtNzzXesTUe2.OnSwlSsdmCpQOgAAAdKNilDNmUQDb += sAbeDzZMVmehKsitgohDZkzDPjNw;
				for (int i = 0; i < UdDVajqHjAUeFUZEiPyApPDsnpTJ.Count; i++)
				{
					PlatformInputManager platformInputManager = UdDVajqHjAUeFUZEiPyApPDsnpTJ[i];
					platformInputManager.DeviceConnectedEvent += tDKRBsEvxJLceylWXLEbrbdzKZGl;
					platformInputManager.DeviceDisconnectedEvent += ZSJajJHctWoIzQKpWsnIBpuelhzi;
					platformInputManager.UpdateControllerInfoEvent += PAYHunnThMLvqtKxlDNrzbOCYGnR;
				}
			}
			catch (Exception ex)
			{
				OnDestroy();
				Logger.LogWarning("Unable to initialize input source!\n" + ex.Message);
				throw;
			}
		}
		if (!flag)
		{
			HbghNSHGUpjuKKUrSBZgXnruffIMA(P_0, true);
		}
		uVOrNnkkLllmpDmvOUWKlNNZlxtT = UpdateControllerData;
	}

	private bool FnCgoNgSQlfxLVtFOOoJizsUyURZ(ConfigVars P_0, kBlORBrVkJHCZIVleGtNzzXesTUe P_1)
	{
		XoJWVHmvFGVWtgGarqHGvosriryD xoJWVHmvFGVWtgGarqHGvosriryD = null;
		jSzyivpKikIcKFnbBCmdglPWWQPZA jSzyivpKikIcKFnbBCmdglPWWQPZA2 = null;
		try
		{
			xoJWVHmvFGVWtgGarqHGvosriryD = new XoJWVHmvFGVWtgGarqHGvosriryD(P_0, false, null, null, false, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			jSzyivpKikIcKFnbBCmdglPWWQPZA2 = (jSzyivpKikIcKFnbBCmdglPWWQPZA)(zmfFHiCPTYbyEONdryEPDDKQBpfB = new jSzyivpKikIcKFnbBCmdglPWWQPZA(P_0.updateLoop, TSUBrOFQGHrXcTNDvNMpwRaBcmBZ, ((kBlORBrVkJHCZIVleGtNzzXesTUe)PKWcopGQGifHBXMfUYXFsJQxudMd).jXnwQZUHrSWwQtatWPOoXMoxiOCe, ppCwHUroExQzcfJJNHeqzNejQYnU, zJayxUMyrRpvDhxteklTZuahjdWm));
			UdDVajqHjAUeFUZEiPyApPDsnpTJ.Add(5, xoJWVHmvFGVWtgGarqHGvosriryD);
			UdDVajqHjAUeFUZEiPyApPDsnpTJ.Add(1, zmfFHiCPTYbyEONdryEPDDKQBpfB);
			P_1.nvuEDymPzvpakfARCeaWFmBdgAOhA += xoJWVHmvFGVWtgGarqHGvosriryD.uoQqxwrHHVRsWcgmPnNBAbzIFmnH;
			return true;
		}
		catch (Exception)
		{
			jSzyivpKikIcKFnbBCmdglPWWQPZA2?.OnDestroy();
			xoJWVHmvFGVWtgGarqHGvosriryD?.OnDestroy();
			Logger.LogWarning("Unable to initialize Direct Input! Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
		}
		return false;
	}

	private bool qqRoLKyfFrxWZjIbSQWJEVuvoGqm(ConfigVars P_0, kBlORBrVkJHCZIVleGtNzzXesTUe P_1)
	{
		XoJWVHmvFGVWtgGarqHGvosriryD xoJWVHmvFGVWtgGarqHGvosriryD = null;
		try
		{
			xoJWVHmvFGVWtgGarqHGvosriryD = new XoJWVHmvFGVWtgGarqHGvosriryD(P_0, P_0.useXInput, ppCwHUroExQzcfJJNHeqzNejQYnU, zJayxUMyrRpvDhxteklTZuahjdWm, true, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			UdDVajqHjAUeFUZEiPyApPDsnpTJ.Add(5, xoJWVHmvFGVWtgGarqHGvosriryD);
			P_1.nvuEDymPzvpakfARCeaWFmBdgAOhA += xoJWVHmvFGVWtgGarqHGvosriryD.uoQqxwrHHVRsWcgmPnNBAbzIFmnH;
			zmfFHiCPTYbyEONdryEPDDKQBpfB = xoJWVHmvFGVWtgGarqHGvosriryD;
			return true;
		}
		catch (Exception)
		{
			Logger.LogWarning("Unable to initialize Raw Input! This error can be caused by running Unity sandboxed.");
			xoJWVHmvFGVWtgGarqHGvosriryD?.OnDestroy();
		}
		return false;
	}

	private bool mslGzCjaqPmbMbyhJWUOEKDJaPMj(ConfigVars P_0, kBlORBrVkJHCZIVleGtNzzXesTUe P_1)
	{
		bool platformVar_useNativeMouse = P_0.GetPlatformVar_useNativeMouse();
		bool platformVar_useNativeKeyboard = P_0.GetPlatformVar_useNativeKeyboard();
		if (!platformVar_useNativeMouse && !platformVar_useNativeKeyboard)
		{
			return false;
		}
		XoJWVHmvFGVWtgGarqHGvosriryD xoJWVHmvFGVWtgGarqHGvosriryD = null;
		try
		{
			xoJWVHmvFGVWtgGarqHGvosriryD = new XoJWVHmvFGVWtgGarqHGvosriryD(P_0, false, null, null, false, platformVar_useNativeMouse, platformVar_useNativeKeyboard, P_0.GetPlatformVar_useEnhancedDeviceSupport());
			P_1.nvuEDymPzvpakfARCeaWFmBdgAOhA += xoJWVHmvFGVWtgGarqHGvosriryD.uoQqxwrHHVRsWcgmPnNBAbzIFmnH;
			UdDVajqHjAUeFUZEiPyApPDsnpTJ.Add(5, xoJWVHmvFGVWtgGarqHGvosriryD);
			return true;
		}
		catch
		{
			Logger.LogWarning("Unable to initialize Raw Input for native mouse handling! Unity mouse input will be used instead.");
			xoJWVHmvFGVWtgGarqHGvosriryD?.OnDestroy();
			xoJWVHmvFGVWtgGarqHGvosriryD = null;
			return false;
		}
	}

	private bool HbghNSHGUpjuKKUrSBZgXnruffIMA(ConfigVars P_0, bool P_1)
	{
		UpdateLoopSetting updateLoop = P_0.updateLoop;
		bool useXInput = P_0.useXInput;
		bool flag = zmfFHiCPTYbyEONdryEPDDKQBpfB == null;
		bool num = useXInput || flag || ReInput.currentPlatform == Platform.WindowsAppStore;
		bool flag2 = false;
		if (!num)
		{
			return false;
		}
		try
		{
			if (flag2)
			{
				ogSFrKBgWBFebCZoPgmDlPNWhBFvA ogSFrKBgWBFebCZoPgmDlPNWhBFvA2 = new ogSFrKBgWBFebCZoPgmDlPNWhBFvA();
				ogSFrKBgWBFebCZoPgmDlPNWhBFvA2.CQjewfgizQuJjqeHbfaYIVICBsQY = 0;
				iJBgwMICNtsxCQITcDMiEfutRJOA value = new iJBgwMICNtsxCQITcDMiEfutRJOA(flag2, updateLoop, ppCwHUroExQzcfJJNHeqzNejQYnU, ogSFrKBgWBFebCZoPgmDlPNWhBFvA2.TKRjtDlUBoWAYwKXaSlUfqHvGlso);
				UdDVajqHjAUeFUZEiPyApPDsnpTJ.Add(2, value);
			}
			else
			{
				iJBgwMICNtsxCQITcDMiEfutRJOA iJBgwMICNtsxCQITcDMiEfutRJOA2 = new iJBgwMICNtsxCQITcDMiEfutRJOA(flag2, updateLoop, ppCwHUroExQzcfJJNHeqzNejQYnU, zJayxUMyrRpvDhxteklTZuahjdWm);
				if (flag)
				{
					zmfFHiCPTYbyEONdryEPDDKQBpfB = iJBgwMICNtsxCQITcDMiEfutRJOA2;
				}
				UdDVajqHjAUeFUZEiPyApPDsnpTJ.Add(2, iJBgwMICNtsxCQITcDMiEfutRJOA2);
				if (P_1)
				{
					iJBgwMICNtsxCQITcDMiEfutRJOA2.DeviceConnectedEvent += tDKRBsEvxJLceylWXLEbrbdzKZGl;
					iJBgwMICNtsxCQITcDMiEfutRJOA2.DeviceDisconnectedEvent += ZSJajJHctWoIzQKpWsnIBpuelhzi;
					iJBgwMICNtsxCQITcDMiEfutRJOA2.UpdateControllerInfoEvent += PAYHunnThMLvqtKxlDNrzbOCYGnR;
				}
			}
			return true;
		}
		catch (Exception)
		{
			if (flag)
			{
				OnDestroy();
				Logger.LogWarning("Unable to initialize XInput!");
				throw;
			}
			if (!flag2)
			{
				Logger.LogWarning("Unable to initialize XInput! XInput controllers will be handled by " + JOQsWrfJDAGTZJxHVNoQYFehTEWm.ToString() + " instead. The L/R triggers are treated as a single axis and input cannot be detected when both are pressed simultaneously. Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
				P_0.useXInput = false;
				for (int i = 0; i < UdDVajqHjAUeFUZEiPyApPDsnpTJ.Count; i++)
				{
					if (UdDVajqHjAUeFUZEiPyApPDsnpTJ[i] != null && UdDVajqHjAUeFUZEiPyApPDsnpTJ[i] is gcpwKCRbatOImQkjFmQXegHCctcx gcpwKCRbatOImQkjFmQXegHCctcx2)
					{
						gcpwKCRbatOImQkjFmQXegHCctcx2.pWHVLXJvtZaNjMbaMDeQcrLhbtlAA = false;
					}
				}
				Logger.LogWarning("Unable to initialize XInput! Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		spoTywsgQVMPRUCMlbJufHLOFIrV = true;
		iftHPbeEppCFKPlUMZduNDukntYDA = new qXLQjnwQjHivKSbhLPcyjmEuroSl();
		for (int i = 0; i < UdDVajqHjAUeFUZEiPyApPDsnpTJ.Count; i++)
		{
			UdDVajqHjAUeFUZEiPyApPDsnpTJ[i].Initialize();
		}
	}

	public virtual void GpofRpHCKDLRfAjgPVlCQNGzZLyl(UpdateLoopType P_0)
	{
		for (int i = 0; i < UdDVajqHjAUeFUZEiPyApPDsnpTJ.Count; i++)
		{
			UdDVajqHjAUeFUZEiPyApPDsnpTJ[i].Update(P_0);
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		for (int num = UdDVajqHjAUeFUZEiPyApPDsnpTJ.Count - 1; num >= 0; num--)
		{
			UdDVajqHjAUeFUZEiPyApPDsnpTJ[num].OnDestroy();
		}
		if (PKWcopGQGifHBXMfUYXFsJQxudMd != null)
		{
			((kBlORBrVkJHCZIVleGtNzzXesTUe)PKWcopGQGifHBXMfUYXFsJQxudMd).UoMlRmNkfuxnujxVcBdJpKecVKZL();
			PKWcopGQGifHBXMfUYXFsJQxudMd = null;
		}
		lOimudEEADkCsfXveaIQPguQeEbk.mTQDlluQGHiXnqIhSRvnemGJEsTM();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return uVOrNnkkLllmpDmvOUWKlNNZlxtT;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int controllerId, ControllerDataUpdater data)
	{
		UdDVajqHjAUeFUZEiPyApPDsnpTJ.GetValue((int)data.source).UpdateControllerData(iftHPbeEppCFKPlUMZduNDukntYDA.UliSDmjoRHjByAVSLKaEVCImRsDi(controllerId, data.source, qXLQjnwQjHivKSbhLPcyjmEuroSl.cwXlCXNoaYwjEOSUOEkHRmSxXhdP.Connected), data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		for (int i = 0; i < UdDVajqHjAUeFUZEiPyApPDsnpTJ.Count; i++)
		{
			IUnifiedMouseSource unifiedMouseSource = UdDVajqHjAUeFUZEiPyApPDsnpTJ[i].GetUnifiedMouseSource();
			if (unifiedMouseSource != null)
			{
				return unifiedMouseSource;
			}
		}
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		for (int i = 0; i < UdDVajqHjAUeFUZEiPyApPDsnpTJ.Count; i++)
		{
			IUnifiedKeyboardSource unifiedKeyboardSource = UdDVajqHjAUeFUZEiPyApPDsnpTJ[i].GetUnifiedKeyboardSource();
			if (unifiedKeyboardSource != null)
			{
				return unifiedKeyboardSource;
			}
		}
		return null;
	}

	private void tDKRBsEvxJLceylWXLEbrbdzKZGl(BridgedController P_0)
	{
		if (P_0 != null)
		{
			iftHPbeEppCFKPlUMZduNDukntYDA.zYlGDhYgRqSkXYNmtfQhBHPIdukiA(P_0);
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0);
			}
		}
	}

	private void ZSJajJHctWoIzQKpWsnIBpuelhzi(ControllerDisconnectedEventArgs P_0)
	{
		if (P_0 != null)
		{
			iftHPbeEppCFKPlUMZduNDukntYDA.ZdBPePViVcEEpBaErdbTlEJvFbcyA(P_0);
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(P_0);
			}
		}
	}

	private void TWCxLAClndjKveaSxizSNJWRPJSdA(EventArgs P_0)
	{
		if (spoTywsgQVMPRUCMlbJufHLOFIrV)
		{
			for (int i = 0; i < UdDVajqHjAUeFUZEiPyApPDsnpTJ.Count; i++)
			{
				UdDVajqHjAUeFUZEiPyApPDsnpTJ[i].SystemDeviceConnected();
			}
		}
	}

	private void sAbeDzZMVmehKsitgohDZkzDPjNw(EventArgs P_0)
	{
		if (spoTywsgQVMPRUCMlbJufHLOFIrV)
		{
			for (int i = 0; i < UdDVajqHjAUeFUZEiPyApPDsnpTJ.Count; i++)
			{
				UdDVajqHjAUeFUZEiPyApPDsnpTJ[i].SystemDeviceDisconnected();
			}
		}
	}

	private void PAYHunnThMLvqtKxlDNrzbOCYGnR(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 == null || P_0.sourceJoystick == null)
		{
			return;
		}
		iftHPbeEppCFKPlUMZduNDukntYDA.yxalfWWBUTFBEvpzBnhJlUMXWakM(P_0.sourceJoystick.rewiredId, P_0.sourceJoystick.inputManagerId);
		qXLQjnwQjHivKSbhLPcyjmEuroSl.cwXlCXNoaYwjEOSUOEkHRmSxXhdP cwXlCXNoaYwjEOSUOEkHRmSxXhdP = qXLQjnwQjHivKSbhLPcyjmEuroSl.cwXlCXNoaYwjEOSUOEkHRmSxXhdP.Connected;
		int num = iftHPbeEppCFKPlUMZduNDukntYDA.SzNimueXqdvudUomKKMmnqpDlyBH(P_0.sourceJoystick.rewiredId, cwXlCXNoaYwjEOSUOEkHRmSxXhdP);
		if (num < 0)
		{
			cwXlCXNoaYwjEOSUOEkHRmSxXhdP = qXLQjnwQjHivKSbhLPcyjmEuroSl.cwXlCXNoaYwjEOSUOEkHRmSxXhdP.Disconnected;
			num = iftHPbeEppCFKPlUMZduNDukntYDA.SzNimueXqdvudUomKKMmnqpDlyBH(P_0.sourceJoystick.rewiredId, cwXlCXNoaYwjEOSUOEkHRmSxXhdP);
		}
		if (num >= 0)
		{
			qXLQjnwQjHivKSbhLPcyjmEuroSl.hKZUdVWLGClISfMVCdQlzeJIbGPeA hKZUdVWLGClISfMVCdQlzeJIbGPeA = iftHPbeEppCFKPlUMZduNDukntYDA.RHWUYcgcMgLvKSjgunvpEAuTZopD(num, cwXlCXNoaYwjEOSUOEkHRmSxXhdP);
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(new fkOgjiqnQDItvQBjONzFGCyWoiyL(P_0.sourceJoystick, hKZUdVWLGClISfMVCdQlzeJIbGPeA.DWciQLPzNIhErLoojVTyCMHsANML)));
			}
		}
	}
}
