using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Config;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired.InputSources.SDL2
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class SDL2InputSource : IDisposable, IInputSource
	{
		public delegate void CHQrUrLdwdQlNNCLWLtGzYEQSIXT(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void ttdtyMHaxliZybrngJtYYGdoExui(int joystickIndex);

		public delegate void zBsOIxXfjpbcgFgLiXFaIEyivZNRA(int joystickId);

		public delegate void RrZEknPTkGoMTBUgjlpdOMJXLCRG(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int FQRKXtiTkTBKxvcGdbcRTOORhFHd = 32;

		private bool FmjIfSbbZQGmwOGQxbLsdNcTtdJv;

		private bool WGlNBIhJcIGDWjLeSNucZQTmthIZ;

		private bool xNlCJqFHDDPBFbzaNwmArLLBCiYx;

		private bool MqObAwOsakkeKyBGuZsgrIetfdvr;

		private bool vzsCKgEyOZYnMHSYbeEpEieJXjoE;

		private ADictionary<int, EWshIWwXvahCaXPqIkpqMmbaegrM> uhsZTQOPiTWQesgStEowZrhIaYfdA;

		private ADictionary<int, ycgdCueUMBVeyjpfbvKGDyBioIHIA> GDGvlUWBYaGIhiTpxYrZuyvMGCot;

		private predoReysgkDbMHWQjyxbMtjCRqMc.cbkJFcYdqXkZPVtygRIhJigOeUGhA jNvHzRRQdFWpqdSyVUZjiXOcQtgA;

		private NativeBuffer WjLgfAcHoXHXYREFYbYbCZhhucBMB;

		[CompilerGenerated]
		private Action WkyGkICOmpKKyrmoxsMhfScSuttv;

		private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

		public bool initialized => vzsCKgEyOZYnMHSYbeEpEieJXjoE;

		private event Action _DeviceChangedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = WkyGkICOmpKKyrmoxsMhfScSuttv;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref WkyGkICOmpKKyrmoxsMhfScSuttv, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = WkyGkICOmpKKyrmoxsMhfScSuttv;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref WkyGkICOmpKKyrmoxsMhfScSuttv, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public event Action DeviceChangedEvent
		{
			add
			{
				_DeviceChangedEvent += value;
			}
			remove
			{
				_DeviceChangedEvent -= value;
			}
		}

		public SDL2InputSource(UpdateLoopSetting P_0, bool P_1, bool P_2, bool P_3, bool P_4)
		{
			FmjIfSbbZQGmwOGQxbLsdNcTtdJv = P_1;
			WGlNBIhJcIGDWjLeSNucZQTmthIZ = P_2;
			xNlCJqFHDDPBFbzaNwmArLLBCiYx = P_3;
			MqObAwOsakkeKyBGuZsgrIetfdvr = P_4;
			uhsZTQOPiTWQesgStEowZrhIaYfdA = new ADictionary<int, EWshIWwXvahCaXPqIkpqMmbaegrM>();
			GDGvlUWBYaGIhiTpxYrZuyvMGCot = new ADictionary<int, ycgdCueUMBVeyjpfbvKGDyBioIHIA>();
			int num = ((!UnityTools.isEditor || UnityTools.editorPlatform != EditorPlatform.OSX) ? 29184 : 25088);
			try
			{
				predoReysgkDbMHWQjyxbMtjCRqMc.YJgaIeKAxiKmBsVJiYfKhVujRdGJ(UnityTools.effectivePlatform);
				if (predoReysgkDbMHWQjyxbMtjCRqMc.SHkLhNNFhGwUfaihGFnTjViASELX((uint)num) < 0)
				{
					throw new Exception("Failed initialize SDL2!");
				}
				vzsCKgEyOZYnMHSYbeEpEieJXjoE = true;
				if (P_2)
				{
					snogJrEYHfBAOGWzSiIbdmxjUariA();
				}
				eoTLvzgOkBfNifOnFqgBDEVcmoIoc();
				WjLgfAcHoXHXYREFYbYbCZhhucBMB = new NativeBuffer(56);
			}
			catch
			{
				vzsCKgEyOZYnMHSYbeEpEieJXjoE = false;
				Dispose();
				throw;
			}
		}

		public void SystemDeviceConnected()
		{
			throw new NotImplementedException();
		}

		public void SystemDeviceDisconnected()
		{
			throw new NotImplementedException();
		}

		public void Update()
		{
			_ = vzsCKgEyOZYnMHSYbeEpEieJXjoE;
		}

		public void UpdateDevices(UpdateLoopType updateLoop)
		{
			if (vzsCKgEyOZYnMHSYbeEpEieJXjoE)
			{
				fQyNbsHhYMDwJBsrZeevEsqNkRIk();
			}
		}

		public void UpdateFinished()
		{
			_ = vzsCKgEyOZYnMHSYbeEpEieJXjoE;
		}

		public IList<T> GetJoysticks<T>() where T : class
		{
			if (!vzsCKgEyOZYnMHSYbeEpEieJXjoE)
			{
				return null;
			}
			List<HaOkodQgKHTDiFuGZKtkAaEJxnaG> list = new List<HaOkodQgKHTDiFuGZKtkAaEJxnaG>();
			if (FmjIfSbbZQGmwOGQxbLsdNcTtdJv)
			{
				foreach (KeyValuePair<int, EWshIWwXvahCaXPqIkpqMmbaegrM> uhsZTQOPiTWQesgStEowZrhIaYfdum in uhsZTQOPiTWQesgStEowZrhIaYfdA)
				{
					if (uhsZTQOPiTWQesgStEowZrhIaYfdum.Value.LOAKUriHGZEbByAroDTyQAHhOjqU)
					{
						list.Add(uhsZTQOPiTWQesgStEowZrhIaYfdum.Value);
					}
				}
			}
			if (WGlNBIhJcIGDWjLeSNucZQTmthIZ)
			{
				foreach (KeyValuePair<int, ycgdCueUMBVeyjpfbvKGDyBioIHIA> item in GDGvlUWBYaGIhiTpxYrZuyvMGCot)
				{
					ycgdCueUMBVeyjpfbvKGDyBioIHIA value = item.Value;
					if (value.LOAKUriHGZEbByAroDTyQAHhOjqU)
					{
						list.Add(value);
					}
				}
			}
			return list as IList<T>;
		}

		private int KvpRzjFhVcLcJWrKJSRollEvSmTn()
		{
			if (!vzsCKgEyOZYnMHSYbeEpEieJXjoE)
			{
				return 0;
			}
			return Math.Min(predoReysgkDbMHWQjyxbMtjCRqMc.aqAYygUbNJkdLubJlenBioXUrvKv(), 32);
		}

		private int WYWyDPqSauAeaJRCGgPFxGgLDCSv()
		{
			if (!vzsCKgEyOZYnMHSYbeEpEieJXjoE)
			{
				return 0;
			}
			int num = KvpRzjFhVcLcJWrKJSRollEvSmTn();
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				if (!predoReysgkDbMHWQjyxbMtjCRqMc.HfWxXmmyrukChZxrmIxhYPKXFuQQ(i))
				{
					num2++;
				}
			}
			return num2;
		}

		private EWshIWwXvahCaXPqIkpqMmbaegrM dzwGcRrDhJnMFQQqFWpEABIUhFLB(int P_0)
		{
			IntPtr intPtr = predoReysgkDbMHWQjyxbMtjCRqMc.wjctbLlpfDzsvedcWfFECZeCqoJx(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			TWdnkNUefXafpcUIoWzOuWtkApCMA tWdnkNUefXafpcUIoWzOuWtkApCMA = new TWdnkNUefXafpcUIoWzOuWtkApCMA(intPtr);
			jDJENvVUyUxQxVFZSXsXZjxliNpi jDJENvVUyUxQxVFZSXsXZjxliNpi2 = czvPSFzNUrTKmgBaAAboShSSHsaq(P_0, tWdnkNUefXafpcUIoWzOuWtkApCMA);
			if (jDJENvVUyUxQxVFZSXsXZjxliNpi2 == null)
			{
				predoReysgkDbMHWQjyxbMtjCRqMc.rhUkthsvUMpRPQpAcDajAUZYxWApA(intPtr);
				return null;
			}
			return new EWshIWwXvahCaXPqIkpqMmbaegrM(tWdnkNUefXafpcUIoWzOuWtkApCMA, jDJENvVUyUxQxVFZSXsXZjxliNpi2);
		}

		private ycgdCueUMBVeyjpfbvKGDyBioIHIA DCMSoIdZPuGHZSCQhhHRgsMGEGWm(int P_0)
		{
			IntPtr intPtr = predoReysgkDbMHWQjyxbMtjCRqMc.jFScHjJmXaLRKDbWcDwNdXtVURhDB(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			MZAfPwQRXLIZVbSAPDWiLRrIMyFs mZAfPwQRXLIZVbSAPDWiLRrIMyFs = new MZAfPwQRXLIZVbSAPDWiLRrIMyFs(intPtr);
			jDJENvVUyUxQxVFZSXsXZjxliNpi jDJENvVUyUxQxVFZSXsXZjxliNpi2 = kAWmtvrZlRchNRvajbovXftkMOKg(P_0, mZAfPwQRXLIZVbSAPDWiLRrIMyFs);
			if (jDJENvVUyUxQxVFZSXsXZjxliNpi2 == null)
			{
				return null;
			}
			if (!jDJENvVUyUxQxVFZSXsXZjxliNpi2.HmCmdLxgdPwMVulRbiOFYktdkVvs)
			{
				predoReysgkDbMHWQjyxbMtjCRqMc.vzinAhZUSnflrKCvmttxRMCptlIu(intPtr);
				return null;
			}
			jDJENvVUyUxQxVFZSXsXZjxliNpi2.snGLuuyMCPOtXxLfVtXHzWVouQKy = predoReysgkDbMHWQjyxbMtjCRqMc.JuNGOOzXBcYSBgFJEMcRwIcyPUaR(mZAfPwQRXLIZVbSAPDWiLRrIMyFs);
			return new ycgdCueUMBVeyjpfbvKGDyBioIHIA(mZAfPwQRXLIZVbSAPDWiLRrIMyFs, jDJENvVUyUxQxVFZSXsXZjxliNpi2);
		}

		private jDJENvVUyUxQxVFZSXsXZjxliNpi czvPSFzNUrTKmgBaAAboShSSHsaq(int P_0, TWdnkNUefXafpcUIoWzOuWtkApCMA P_1)
		{
			if (!vzsCKgEyOZYnMHSYbeEpEieJXjoE)
			{
				return null;
			}
			if (P_0 < 0 || P_0 >= 32)
			{
				return null;
			}
			if (P_1 == null || !P_1.IsValid)
			{
				return null;
			}
			return new jDJENvVUyUxQxVFZSXsXZjxliNpi
			{
				YXyldoyQhUuTDivwXCYGwboYLCvO = P_0,
				wESBCUpTmMCEPjoZerGMOOxYgJLe = predoReysgkDbMHWQjyxbMtjCRqMc.MkRkYraxduDOXeihnrGevJSovtqh(P_1),
				HmCmdLxgdPwMVulRbiOFYktdkVvs = predoReysgkDbMHWQjyxbMtjCRqMc.HfWxXmmyrukChZxrmIxhYPKXFuQQ(P_0),
				SBUfCrEEGLzQHfBaenjdUQXNsdQj = predoReysgkDbMHWQjyxbMtjCRqMc.GwKZKnKNxSyZyHUVGqEyqzJVzMI(P_1),
				SrIZLqwdzqtpNxHXKoQtBzvTzEml = predoReysgkDbMHWQjyxbMtjCRqMc.seDokzpajWWeHgyuTTACAIDwdhEx(P_1),
				GYGAHqhkqubAYxXauhmpJTriMWk = predoReysgkDbMHWQjyxbMtjCRqMc.mTKdHgXxWVDSPulzitWPNofRkLRK(P_0),
				alpbKwLALkCahrtZbQONzDYKzPjn = predoReysgkDbMHWQjyxbMtjCRqMc.AFQDFYgsGWkNjHpAkjgjYIUSnPQHb(P_1),
				hPGYvOJyGRFAXlayNclRbQbgBrho = predoReysgkDbMHWQjyxbMtjCRqMc.kBECEWiOppIQFZLwEbNmldgXaYLQ(P_1),
				GlJwIjJIPZnHArhQuCAwcYBiCWFp = predoReysgkDbMHWQjyxbMtjCRqMc.aICXGIMrOQZspATntSBkYLvBQWRb(P_1),
				ScycAvdxNTPWxdRXyYbeGenTtXti = predoReysgkDbMHWQjyxbMtjCRqMc.ELvUIQGjVQRnbniwVqzjNbOthHJAA(P_1)
			};
		}

		private jDJENvVUyUxQxVFZSXsXZjxliNpi kAWmtvrZlRchNRvajbovXftkMOKg(int P_0, MZAfPwQRXLIZVbSAPDWiLRrIMyFs P_1)
		{
			if (P_1 == null || !P_1.IsValid)
			{
				return null;
			}
			TWdnkNUefXafpcUIoWzOuWtkApCMA tWdnkNUefXafpcUIoWzOuWtkApCMA = new TWdnkNUefXafpcUIoWzOuWtkApCMA(predoReysgkDbMHWQjyxbMtjCRqMc.vCtqiPAjghDqDfLJsAKiOBHUOgggA(P_1));
			if (!tWdnkNUefXafpcUIoWzOuWtkApCMA.IsValid)
			{
				return null;
			}
			return czvPSFzNUrTKmgBaAAboShSSHsaq(P_0, tWdnkNUefXafpcUIoWzOuWtkApCMA);
		}

		private void eoTLvzgOkBfNifOnFqgBDEVcmoIoc()
		{
			for (int i = 0; i < KvpRzjFhVcLcJWrKJSRollEvSmTn(); i++)
			{
				if (FmjIfSbbZQGmwOGQxbLsdNcTtdJv)
				{
					bOfjNpPBGKqYUbSmQagEqFqkaQLaA(i);
				}
				if (WGlNBIhJcIGDWjLeSNucZQTmthIZ)
				{
					fndrQlEfkuERCDTnukPHtjIAJhMsA(i);
				}
			}
		}

		private void YhIEaWwvCnCVSCOPbiwMtxtpcvpY()
		{
			if (WGlNBIhJcIGDWjLeSNucZQTmthIZ)
			{
				foreach (KeyValuePair<int, ycgdCueUMBVeyjpfbvKGDyBioIHIA> item in GDGvlUWBYaGIhiTpxYrZuyvMGCot)
				{
					ycgdCueUMBVeyjpfbvKGDyBioIHIA value = item.Value;
					value.VfNXUZwkTSaZUVgSTzjcKEzKWETh();
					value.Dispose();
				}
				GDGvlUWBYaGIhiTpxYrZuyvMGCot.Clear();
			}
			if (!FmjIfSbbZQGmwOGQxbLsdNcTtdJv)
			{
				return;
			}
			foreach (KeyValuePair<int, EWshIWwXvahCaXPqIkpqMmbaegrM> uhsZTQOPiTWQesgStEowZrhIaYfdum in uhsZTQOPiTWQesgStEowZrhIaYfdA)
			{
				EWshIWwXvahCaXPqIkpqMmbaegrM value2 = uhsZTQOPiTWQesgStEowZrhIaYfdum.Value;
				value2.VfNXUZwkTSaZUVgSTzjcKEzKWETh();
				value2.Dispose();
			}
			uhsZTQOPiTWQesgStEowZrhIaYfdA.Clear();
		}

		private bool bOfjNpPBGKqYUbSmQagEqFqkaQLaA(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (WGlNBIhJcIGDWjLeSNucZQTmthIZ && predoReysgkDbMHWQjyxbMtjCRqMc.HfWxXmmyrukChZxrmIxhYPKXFuQQ(P_0))
			{
				return false;
			}
			EWshIWwXvahCaXPqIkpqMmbaegrM eWshIWwXvahCaXPqIkpqMmbaegrM = dzwGcRrDhJnMFQQqFWpEABIUhFLB(P_0);
			if (eWshIWwXvahCaXPqIkpqMmbaegrM == null)
			{
				return false;
			}
			int dyrwQhtCzquFMozPbnrCxDshlZdr = eWshIWwXvahCaXPqIkpqMmbaegrM.dyrwQhtCzquFMozPbnrCxDshlZdr;
			if (uhsZTQOPiTWQesgStEowZrhIaYfdA.ContainsKey(dyrwQhtCzquFMozPbnrCxDshlZdr))
			{
				uhsZTQOPiTWQesgStEowZrhIaYfdA[dyrwQhtCzquFMozPbnrCxDshlZdr].VfNXUZwkTSaZUVgSTzjcKEzKWETh();
				uhsZTQOPiTWQesgStEowZrhIaYfdA[dyrwQhtCzquFMozPbnrCxDshlZdr] = eWshIWwXvahCaXPqIkpqMmbaegrM;
			}
			else
			{
				uhsZTQOPiTWQesgStEowZrhIaYfdA.Add(dyrwQhtCzquFMozPbnrCxDshlZdr, eWshIWwXvahCaXPqIkpqMmbaegrM);
			}
			eWshIWwXvahCaXPqIkpqMmbaegrM.sXJldihOTtQuAobmFasPIcWImTtk();
			return true;
		}

		private void FOISMnrGSvBYHEpMfZDPdiQvjPPl(int P_0)
		{
			if (uhsZTQOPiTWQesgStEowZrhIaYfdA.ContainsKey(P_0))
			{
				uhsZTQOPiTWQesgStEowZrhIaYfdA[P_0].VfNXUZwkTSaZUVgSTzjcKEzKWETh();
				uhsZTQOPiTWQesgStEowZrhIaYfdA.Remove(P_0);
			}
		}

		private bool fndrQlEfkuERCDTnukPHtjIAJhMsA(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (!predoReysgkDbMHWQjyxbMtjCRqMc.HfWxXmmyrukChZxrmIxhYPKXFuQQ(P_0))
			{
				return false;
			}
			ycgdCueUMBVeyjpfbvKGDyBioIHIA ycgdCueUMBVeyjpfbvKGDyBioIHIA2 = DCMSoIdZPuGHZSCQhhHRgsMGEGWm(P_0);
			if (ycgdCueUMBVeyjpfbvKGDyBioIHIA2 == null)
			{
				return false;
			}
			int dyrwQhtCzquFMozPbnrCxDshlZdr = ycgdCueUMBVeyjpfbvKGDyBioIHIA2.dyrwQhtCzquFMozPbnrCxDshlZdr;
			if (GDGvlUWBYaGIhiTpxYrZuyvMGCot.ContainsKey(dyrwQhtCzquFMozPbnrCxDshlZdr))
			{
				GDGvlUWBYaGIhiTpxYrZuyvMGCot[dyrwQhtCzquFMozPbnrCxDshlZdr].VfNXUZwkTSaZUVgSTzjcKEzKWETh();
				GDGvlUWBYaGIhiTpxYrZuyvMGCot[dyrwQhtCzquFMozPbnrCxDshlZdr] = ycgdCueUMBVeyjpfbvKGDyBioIHIA2;
			}
			else
			{
				GDGvlUWBYaGIhiTpxYrZuyvMGCot.Add(dyrwQhtCzquFMozPbnrCxDshlZdr, ycgdCueUMBVeyjpfbvKGDyBioIHIA2);
			}
			ycgdCueUMBVeyjpfbvKGDyBioIHIA2.sXJldihOTtQuAobmFasPIcWImTtk();
			return true;
		}

		private void NnHbbZTIXPDSYbFfHFjbLxnTcuPDA(int P_0)
		{
			if (GDGvlUWBYaGIhiTpxYrZuyvMGCot.ContainsKey(P_0))
			{
				GDGvlUWBYaGIhiTpxYrZuyvMGCot[P_0].VfNXUZwkTSaZUVgSTzjcKEzKWETh();
				GDGvlUWBYaGIhiTpxYrZuyvMGCot.Remove(P_0);
			}
		}

		private EWshIWwXvahCaXPqIkpqMmbaegrM aiGqkhRPCyFPyEChUQBPbyFoZxzQ(int P_0)
		{
			if (!uhsZTQOPiTWQesgStEowZrhIaYfdA.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private ycgdCueUMBVeyjpfbvKGDyBioIHIA aLtZVIIJmKfzXgoRPCZIbFTaLOfCc(int P_0)
		{
			if (!GDGvlUWBYaGIhiTpxYrZuyvMGCot.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private void fQyNbsHhYMDwJBsrZeevEsqNkRIk()
		{
			while (predoReysgkDbMHWQjyxbMtjCRqMc.eliKodGVmpCAmpbgypouSkCSxKpo(WjLgfAcHoXHXYREFYbYbCZhhucBMB) != 0)
			{
				jNvHzRRQdFWpqdSyVUZjiXOcQtgA.tGhggoZVAKsWQAxoRhgatScXLLLL(WjLgfAcHoXHXYREFYbYbCZhhucBMB);
				predoReysgkDbMHWQjyxbMtjCRqMc.VFHPmxQjbYXPizXtBAONYuPamMAx vwXQQHFBJrsmGgoRIAbOFEOWEDyP = jNvHzRRQdFWpqdSyVUZjiXOcQtgA.vwXQQHFBJrsmGgoRIAbOFEOWEDyP;
				double realTime = ReInput.realTime;
				switch (vwXQQHFBJrsmGgoRIAbOFEOWEDyP)
				{
				case predoReysgkDbMHWQjyxbMtjCRqMc.VFHPmxQjbYXPizXtBAONYuPamMAx.SDL_CONTROLLERAXISMOTION:
					PMDZNjNaxehqJJvzMBtwAEeyeFVcA(ref jNvHzRRQdFWpqdSyVUZjiXOcQtgA.zkOaKxDkVkNYDoYlMmykODYHJEwUA, realTime);
					break;
				case predoReysgkDbMHWQjyxbMtjCRqMc.VFHPmxQjbYXPizXtBAONYuPamMAx.SDL_CONTROLLERBUTTONDOWN:
				case predoReysgkDbMHWQjyxbMtjCRqMc.VFHPmxQjbYXPizXtBAONYuPamMAx.SDL_CONTROLLERBUTTONUP:
					ircmyuSxAMjcFoXJzUfLZmoCDVuJ(ref jNvHzRRQdFWpqdSyVUZjiXOcQtgA.TPDaNoExoSyqniKtOjOIbEhCAkEuB, realTime);
					break;
				case predoReysgkDbMHWQjyxbMtjCRqMc.VFHPmxQjbYXPizXtBAONYuPamMAx.SDL_CONTROLLERDEVICEREMAPPED:
					UjHOdIFnuEZSiJHJFQuYVUoeEguS(ref jNvHzRRQdFWpqdSyVUZjiXOcQtgA.IjuEnDUnBtHHSytIdGQTIqqRSOzy);
					break;
				case predoReysgkDbMHWQjyxbMtjCRqMc.VFHPmxQjbYXPizXtBAONYuPamMAx.SDL_JOYAXISMOTION:
					RGEfxiCcyUaurNoXzYIvqXgyMuNuA(ref jNvHzRRQdFWpqdSyVUZjiXOcQtgA.BqbPTAmizQcCqKBeQGqxdmGuBJyiA, realTime);
					break;
				case predoReysgkDbMHWQjyxbMtjCRqMc.VFHPmxQjbYXPizXtBAONYuPamMAx.SDL_JOYBUTTONDOWN:
				case predoReysgkDbMHWQjyxbMtjCRqMc.VFHPmxQjbYXPizXtBAONYuPamMAx.SDL_JOYBUTTONUP:
					XsnmnKxpNmslRapzifTEigzGSBssA(ref jNvHzRRQdFWpqdSyVUZjiXOcQtgA.xkYHxKElEknRrbSnHQdjzpRJBDWv, realTime);
					break;
				case predoReysgkDbMHWQjyxbMtjCRqMc.VFHPmxQjbYXPizXtBAONYuPamMAx.SDL_JOYHATMOTION:
					yChVmXRZgsFhJRqAkXPxGPiiixMu(ref jNvHzRRQdFWpqdSyVUZjiXOcQtgA.NFjjRyZebPdwyUMomaoqGCiePtKQA, realTime);
					break;
				case predoReysgkDbMHWQjyxbMtjCRqMc.VFHPmxQjbYXPizXtBAONYuPamMAx.SDL_JOYBALLMOTION:
					qgUfrgGurHnRApyiQJWBUJrDIpwA(ref jNvHzRRQdFWpqdSyVUZjiXOcQtgA.VXElaNzPKXuUDTHkSkMsrpzJMgxh, realTime);
					break;
				case predoReysgkDbMHWQjyxbMtjCRqMc.VFHPmxQjbYXPizXtBAONYuPamMAx.SDL_JOYDEVICEADDED:
					sciAZVUlmTDxMRMVwemWoGTfuUyy(ref jNvHzRRQdFWpqdSyVUZjiXOcQtgA.qVMWWiGyBMwTChbZNjOFYAfCnmXH);
					break;
				case predoReysgkDbMHWQjyxbMtjCRqMc.VFHPmxQjbYXPizXtBAONYuPamMAx.SDL_JOYDEVICEREMOVED:
					mdcjbpMRcdBklWlhtfboHpZkFMuu(ref jNvHzRRQdFWpqdSyVUZjiXOcQtgA.qVMWWiGyBMwTChbZNjOFYAfCnmXH);
					break;
				case predoReysgkDbMHWQjyxbMtjCRqMc.VFHPmxQjbYXPizXtBAONYuPamMAx.SDL_CONTROLLERDEVICEADDED:
					TxRwRgbgupaGBecCdqJifdvuRQXeA(ref jNvHzRRQdFWpqdSyVUZjiXOcQtgA.IjuEnDUnBtHHSytIdGQTIqqRSOzy);
					break;
				case predoReysgkDbMHWQjyxbMtjCRqMc.VFHPmxQjbYXPizXtBAONYuPamMAx.SDL_CONTROLLERDEVICEREMOVED:
					pbwECdcphJEcZiHwcxiLJuLkERNF(ref jNvHzRRQdFWpqdSyVUZjiXOcQtgA.IjuEnDUnBtHHSytIdGQTIqqRSOzy);
					break;
				}
			}
		}

		private void RGEfxiCcyUaurNoXzYIvqXgyMuNuA(ref predoReysgkDbMHWQjyxbMtjCRqMc.CjkacWGpDNLyNvWNQwnEfARggDpBb P_0, double P_1)
		{
			if (FmjIfSbbZQGmwOGQxbLsdNcTtdJv)
			{
				ZwmVMDIbmylLYGXjTNvGHhhNqFfU(P_0.MJqtWpgNLANGejlIActZjSPeKFb, BEultZLyaxPADMiYOWRewNKBfupc.Axis, P_0.LwGWRliUIhWMczncofrdQExMXadq, P_0.pWRdAJigDslyLjNIYbVMMkTWOPgC, P_1);
			}
		}

		private void XsnmnKxpNmslRapzifTEigzGSBssA(ref predoReysgkDbMHWQjyxbMtjCRqMc.UEbjEBpiuscPGhEYyZvGazhvSgNbA P_0, double P_1)
		{
			if (FmjIfSbbZQGmwOGQxbLsdNcTtdJv)
			{
				ZwmVMDIbmylLYGXjTNvGHhhNqFfU(P_0.MJqtWpgNLANGejlIActZjSPeKFb, BEultZLyaxPADMiYOWRewNKBfupc.Button, P_0.nFkJEBboJowlFJzptQmrhJesFGrw, P_0.PSXmUcWexXbxODmXGsTWpIwAjFVi, P_1);
			}
		}

		private void yChVmXRZgsFhJRqAkXPxGPiiixMu(ref predoReysgkDbMHWQjyxbMtjCRqMc.iGRVzfUTBMpQjAmFBzQGdltxSmzw P_0, double P_1)
		{
			if (FmjIfSbbZQGmwOGQxbLsdNcTtdJv)
			{
				ZwmVMDIbmylLYGXjTNvGHhhNqFfU(P_0.MJqtWpgNLANGejlIActZjSPeKFb, BEultZLyaxPADMiYOWRewNKBfupc.Hat, P_0.wabjYEbIcYSapuIYFIVAUbyOljQvA, P_0.pWRdAJigDslyLjNIYbVMMkTWOPgC, P_1);
			}
		}

		private void qgUfrgGurHnRApyiQJWBUJrDIpwA(ref predoReysgkDbMHWQjyxbMtjCRqMc.chIlQQIbXaVHUbwTzpYYGeOlsPzC P_0, double P_1)
		{
			_ = FmjIfSbbZQGmwOGQxbLsdNcTtdJv;
		}

		private void sciAZVUlmTDxMRMVwemWoGTfuUyy(ref predoReysgkDbMHWQjyxbMtjCRqMc.fXzwslMRmbbDedpdrZzCySlPgiWQ P_0)
		{
			if (FmjIfSbbZQGmwOGQxbLsdNcTtdJv)
			{
				bOfjNpPBGKqYUbSmQagEqFqkaQLaA(P_0.MJqtWpgNLANGejlIActZjSPeKFb);
				if (WkyGkICOmpKKyrmoxsMhfScSuttv != null)
				{
					WkyGkICOmpKKyrmoxsMhfScSuttv();
				}
			}
		}

		private void mdcjbpMRcdBklWlhtfboHpZkFMuu(ref predoReysgkDbMHWQjyxbMtjCRqMc.fXzwslMRmbbDedpdrZzCySlPgiWQ P_0)
		{
			if (FmjIfSbbZQGmwOGQxbLsdNcTtdJv)
			{
				FOISMnrGSvBYHEpMfZDPdiQvjPPl(P_0.MJqtWpgNLANGejlIActZjSPeKFb);
				if (WkyGkICOmpKKyrmoxsMhfScSuttv != null)
				{
					WkyGkICOmpKKyrmoxsMhfScSuttv();
				}
			}
		}

		private void PMDZNjNaxehqJJvzMBtwAEeyeFVcA(ref predoReysgkDbMHWQjyxbMtjCRqMc.tjiGYSbjSyHDTSibbToBPVkgpYBt P_0, double P_1)
		{
			if (WGlNBIhJcIGDWjLeSNucZQTmthIZ && P_0.LwGWRliUIhWMczncofrdQExMXadq != 6)
			{
				ALYQKYJlyRlPmSfbuaRDzQeJwnWp(P_0.MJqtWpgNLANGejlIActZjSPeKFb, BEultZLyaxPADMiYOWRewNKBfupc.Axis, P_0.LwGWRliUIhWMczncofrdQExMXadq, P_0.pWRdAJigDslyLjNIYbVMMkTWOPgC, P_1);
			}
		}

		private void ircmyuSxAMjcFoXJzUfLZmoCDVuJ(ref predoReysgkDbMHWQjyxbMtjCRqMc.hcarzAJFMZaFEjUQpmnuwvkxVbjW P_0, double P_1)
		{
			if (WGlNBIhJcIGDWjLeSNucZQTmthIZ && P_0.nFkJEBboJowlFJzptQmrhJesFGrw != 15)
			{
				ALYQKYJlyRlPmSfbuaRDzQeJwnWp(P_0.MJqtWpgNLANGejlIActZjSPeKFb, BEultZLyaxPADMiYOWRewNKBfupc.Button, P_0.nFkJEBboJowlFJzptQmrhJesFGrw, P_0.PSXmUcWexXbxODmXGsTWpIwAjFVi, P_1);
			}
		}

		private void TxRwRgbgupaGBecCdqJifdvuRQXeA(ref predoReysgkDbMHWQjyxbMtjCRqMc.TOoEheoDLhuaPMezuPPKfhQLnGTe P_0)
		{
			if (WGlNBIhJcIGDWjLeSNucZQTmthIZ)
			{
				fndrQlEfkuERCDTnukPHtjIAJhMsA(P_0.MJqtWpgNLANGejlIActZjSPeKFb);
				if (WkyGkICOmpKKyrmoxsMhfScSuttv != null)
				{
					WkyGkICOmpKKyrmoxsMhfScSuttv();
				}
			}
		}

		private void pbwECdcphJEcZiHwcxiLJuLkERNF(ref predoReysgkDbMHWQjyxbMtjCRqMc.TOoEheoDLhuaPMezuPPKfhQLnGTe P_0)
		{
			if (WGlNBIhJcIGDWjLeSNucZQTmthIZ)
			{
				NnHbbZTIXPDSYbFfHFjbLxnTcuPDA(P_0.MJqtWpgNLANGejlIActZjSPeKFb);
				if (WkyGkICOmpKKyrmoxsMhfScSuttv != null)
				{
					WkyGkICOmpKKyrmoxsMhfScSuttv();
				}
			}
		}

		private void UjHOdIFnuEZSiJHJFQuYVUoeEguS(ref predoReysgkDbMHWQjyxbMtjCRqMc.TOoEheoDLhuaPMezuPPKfhQLnGTe P_0)
		{
			_ = WGlNBIhJcIGDWjLeSNucZQTmthIZ;
		}

		private void ZwmVMDIbmylLYGXjTNvGHhhNqFfU(int P_0, BEultZLyaxPADMiYOWRewNKBfupc P_1, byte P_2, short P_3, double P_4)
		{
			aiGqkhRPCyFPyEChUQBPbyFoZxzQ(P_0)?.uqcjdwWGLmpPBtHzkpeQnIbXtmIb(P_1, P_2, P_3, P_4);
		}

		private void ALYQKYJlyRlPmSfbuaRDzQeJwnWp(int P_0, BEultZLyaxPADMiYOWRewNKBfupc P_1, byte P_2, short P_3, double P_4)
		{
			aLtZVIIJmKfzXgoRPCZIbFTaLOfCc(P_0)?.uqcjdwWGLmpPBtHzkpeQnIbXtmIb(P_1, P_2, P_3, P_4);
		}

		private void snogJrEYHfBAOGWzSiIbdmxjUariA()
		{
			string[] array = xXjKqXoMZKcrcYmCXaumygcUVGhA.QWlsFQuSiWBPARdzCgmXMRHNafrU();
			if (array == null)
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]) && array[i].Length > 32 && !(predoReysgkDbMHWQjyxbMtjCRqMc.tVuUWFjQlMvjmxNUPvzaVbyjRyYm(new Guid(array[i].Substring(0, 32))) != string.Empty))
				{
					predoReysgkDbMHWQjyxbMtjCRqMc.OjUCvbQiOnjEUAfvRfXowIgiRnQOA(array[i]);
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~SDL2InputSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (JWXwfaUAOJsMCNExsMKmFgNcBZSc)
			{
				return;
			}
			if (disposing)
			{
				if (WjLgfAcHoXHXYREFYbYbCZhhucBMB != null)
				{
					WjLgfAcHoXHXYREFYbYbCZhhucBMB.Dispose();
				}
				YhIEaWwvCnCVSCOPbiwMtxtpcvpY();
			}
			predoReysgkDbMHWQjyxbMtjCRqMc.IUzDsnAzhjEpSMMbkufwwbSyQmYKA();
			vzsCKgEyOZYnMHSYbeEpEieJXjoE = false;
			JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
		}
	}
}
