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
	internal class SDL2InputSource : IInputSource, IDisposable
	{
		public delegate void IuYxVMkbABYjMXcVFdcuZgAOvkMH(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void poluMtyLiHLUhrXCnTCcerhwrlli(int joystickIndex);

		public delegate void dhylxAaoKDZavoaTvDFEwqVcqPSE(int joystickId);

		public delegate void PJXmjKmaQwYFWLrvaOrTamGVwuIr(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int pEjvDyRpOxcplFPPjlUkZriaXPCp = 32;

		private bool OsWstCSVTJhwJQEikUAYxsBmRVgD;

		private bool DUqfBnYwgWpSgHIJAJNwVXXydxbN;

		private bool DLuDyEgcpNpHTiTyDidvjCXtAtnKA;

		private bool OKoUPaEBnNkHoSgJqIEBkriJAIfK;

		private bool LPlwRZQrNUHJoqoDDMZMGxHJjluA;

		private ADictionary<int, QDivzTHsEOrHtRXDPrcQwihoJvyh> MPVEAKdrwUsphzKAGIEOLJweAmRg;

		private ADictionary<int, akwAbTvIPdmPpleSiTKoUbPwehWgA> iGEZgSocnbrKmJBPxCpVGHuOgkxZA;

		private hfyAVwFKrQQcyFTzPqgBcwjEFqtW.mUgYuLtMrvLwYRCJtrAJrMkKBtNeA ribWpWSirvSikPLKeGdCdehmrYaLA;

		private NativeBuffer SFMGmudaGUIcfENLLISkqKwwetAVA;

		[CompilerGenerated]
		private Action AFbDXEipCkRbxDcAjQhoPLBXBoHmb;

		private bool sqpcBSWRPFjjpBeQVJInBlSetEAJb;

		public bool initialized => LPlwRZQrNUHJoqoDDMZMGxHJjluA;

		private event Action _DeviceChangedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = AFbDXEipCkRbxDcAjQhoPLBXBoHmb;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref AFbDXEipCkRbxDcAjQhoPLBXBoHmb, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = AFbDXEipCkRbxDcAjQhoPLBXBoHmb;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref AFbDXEipCkRbxDcAjQhoPLBXBoHmb, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		event Action IInputSource.DeviceChangedEvent
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
			OsWstCSVTJhwJQEikUAYxsBmRVgD = P_1;
			DUqfBnYwgWpSgHIJAJNwVXXydxbN = P_2;
			DLuDyEgcpNpHTiTyDidvjCXtAtnKA = P_3;
			OKoUPaEBnNkHoSgJqIEBkriJAIfK = P_4;
			MPVEAKdrwUsphzKAGIEOLJweAmRg = new ADictionary<int, QDivzTHsEOrHtRXDPrcQwihoJvyh>();
			iGEZgSocnbrKmJBPxCpVGHuOgkxZA = new ADictionary<int, akwAbTvIPdmPpleSiTKoUbPwehWgA>();
			int num = ((!UnityTools.isEditor || UnityTools.editorPlatform != EditorPlatform.OSX) ? 29184 : 25088);
			try
			{
				hfyAVwFKrQQcyFTzPqgBcwjEFqtW.vdeSdGRpGaGPWqIrQntOlhIAWcdj(UnityTools.effectivePlatform);
				if (hfyAVwFKrQQcyFTzPqgBcwjEFqtW.WhXQxkwSmaGXbVsvqdfDGUyZWbuk((uint)num) < 0)
				{
					throw new Exception("Failed initialize SDL2!");
				}
				LPlwRZQrNUHJoqoDDMZMGxHJjluA = true;
				if (P_2)
				{
					NVHGrpVEJbbDykMRxONrvivQEnjI();
				}
				XJcSFpwqqZXZpixwaxjpKKEOTCjj();
				SFMGmudaGUIcfENLLISkqKwwetAVA = new NativeBuffer(56);
			}
			catch
			{
				LPlwRZQrNUHJoqoDDMZMGxHJjluA = false;
				Dispose();
				throw;
			}
		}

		public void SystemDeviceConnected()
		{
			throw new NotImplementedException();
		}

		void IInputSource.SystemDeviceConnected()
		{
			//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceConnected
			this.SystemDeviceConnected();
		}

		public void SystemDeviceDisconnected()
		{
			throw new NotImplementedException();
		}

		void IInputSource.SystemDeviceDisconnected()
		{
			//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceDisconnected
			this.SystemDeviceDisconnected();
		}

		public void Update()
		{
			_ = LPlwRZQrNUHJoqoDDMZMGxHJjluA;
		}

		void IInputSource.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public void UpdateDevices(UpdateLoopType updateLoop)
		{
			if (LPlwRZQrNUHJoqoDDMZMGxHJjluA)
			{
				oDwsCPnpgwzBCYJnoQWPYquhDSVH();
			}
		}

		void IInputSource.UpdateDevices(UpdateLoopType updateLoop)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateDevices
			this.UpdateDevices(updateLoop);
		}

		public void UpdateFinished()
		{
			_ = LPlwRZQrNUHJoqoDDMZMGxHJjluA;
		}

		void IInputSource.UpdateFinished()
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateFinished
			this.UpdateFinished();
		}

		public IList<T> GetJoysticks<T>() where T : class
		{
			if (!LPlwRZQrNUHJoqoDDMZMGxHJjluA)
			{
				return null;
			}
			List<TrKPVSrmRjdoziVhIIYQgcCFPMlEB> list = new List<TrKPVSrmRjdoziVhIIYQgcCFPMlEB>();
			if (OsWstCSVTJhwJQEikUAYxsBmRVgD)
			{
				foreach (KeyValuePair<int, QDivzTHsEOrHtRXDPrcQwihoJvyh> item in MPVEAKdrwUsphzKAGIEOLJweAmRg)
				{
					if (item.Value.jXcCaQBGRGDyhlBUmWOtSMgNECtLA)
					{
						list.Add(item.Value);
					}
				}
			}
			if (DUqfBnYwgWpSgHIJAJNwVXXydxbN)
			{
				foreach (KeyValuePair<int, akwAbTvIPdmPpleSiTKoUbPwehWgA> item2 in iGEZgSocnbrKmJBPxCpVGHuOgkxZA)
				{
					akwAbTvIPdmPpleSiTKoUbPwehWgA value = item2.Value;
					if (value.jXcCaQBGRGDyhlBUmWOtSMgNECtLA)
					{
						list.Add(value);
					}
				}
			}
			return list as IList<T>;
		}

		IList<T> IInputSource.GetJoysticks<T>()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetJoysticks
			return this.GetJoysticks<T>();
		}

		private int bEnCIsyclHDDQpHrWuiOTqoIPWwf()
		{
			if (!LPlwRZQrNUHJoqoDDMZMGxHJjluA)
			{
				return 0;
			}
			return Math.Min(hfyAVwFKrQQcyFTzPqgBcwjEFqtW.zDnDFwyqQchpvDnvqMwznmQgrLFpA(), 32);
		}

		private int RrwUMfDnFwesWZcoXGBdzBjkGIoB()
		{
			if (!LPlwRZQrNUHJoqoDDMZMGxHJjluA)
			{
				return 0;
			}
			int num = bEnCIsyclHDDQpHrWuiOTqoIPWwf();
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				if (!hfyAVwFKrQQcyFTzPqgBcwjEFqtW.KycSFRHGHvEREelaLMlBOHKNipILA(i))
				{
					num2++;
				}
			}
			return num2;
		}

		private QDivzTHsEOrHtRXDPrcQwihoJvyh nWOEWxKXiWfJrwByvPyGTGnvbyeQ(int P_0)
		{
			IntPtr intPtr = hfyAVwFKrQQcyFTzPqgBcwjEFqtW.zwBoVuqJmOlxKsMsDIpmYkGImQBj(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			JjfLPgrynhOKsCdZxdUuaxcmSVVD jjfLPgrynhOKsCdZxdUuaxcmSVVD = new JjfLPgrynhOKsCdZxdUuaxcmSVVD(intPtr);
			hqPZfWsfbiiIsgJaREHtYrvfJTqoA hqPZfWsfbiiIsgJaREHtYrvfJTqoA2 = cyufqhkcDqGTOidOXovYYAGLEaDS(P_0, jjfLPgrynhOKsCdZxdUuaxcmSVVD);
			if (hqPZfWsfbiiIsgJaREHtYrvfJTqoA2 == null)
			{
				hfyAVwFKrQQcyFTzPqgBcwjEFqtW.WAHBKJipOmEBKHtWdGLfFSAQGCDdb(intPtr);
				return null;
			}
			return new QDivzTHsEOrHtRXDPrcQwihoJvyh(jjfLPgrynhOKsCdZxdUuaxcmSVVD, hqPZfWsfbiiIsgJaREHtYrvfJTqoA2);
		}

		private akwAbTvIPdmPpleSiTKoUbPwehWgA TZFnPeXfkjbsqMWwZNgDKIsMCotl(int P_0)
		{
			IntPtr intPtr = hfyAVwFKrQQcyFTzPqgBcwjEFqtW.GzxmfPxnaVkFoWpgKmTszlTJSCpf(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			KiEkVQpCFjwSXddVCUMBxpKMFQCc kiEkVQpCFjwSXddVCUMBxpKMFQCc = new KiEkVQpCFjwSXddVCUMBxpKMFQCc(intPtr);
			hqPZfWsfbiiIsgJaREHtYrvfJTqoA hqPZfWsfbiiIsgJaREHtYrvfJTqoA2 = XXFZpLZdqnPgjNepfyjjeUqvUkit(P_0, kiEkVQpCFjwSXddVCUMBxpKMFQCc);
			if (hqPZfWsfbiiIsgJaREHtYrvfJTqoA2 == null)
			{
				return null;
			}
			if (!hqPZfWsfbiiIsgJaREHtYrvfJTqoA2.BINabxjEiHuOxoxkmQvTUwvLFTMn)
			{
				hfyAVwFKrQQcyFTzPqgBcwjEFqtW.GAADKWxhDZIJuhitreAxqVHqkaxU(intPtr);
				return null;
			}
			hqPZfWsfbiiIsgJaREHtYrvfJTqoA2.TrEjXvwKerXddZGUIlHzjkztVfLf = hfyAVwFKrQQcyFTzPqgBcwjEFqtW.MjxmbpVMCKGPKxrzVbhoKdNbVPQRA(kiEkVQpCFjwSXddVCUMBxpKMFQCc);
			return new akwAbTvIPdmPpleSiTKoUbPwehWgA(kiEkVQpCFjwSXddVCUMBxpKMFQCc, hqPZfWsfbiiIsgJaREHtYrvfJTqoA2);
		}

		private hqPZfWsfbiiIsgJaREHtYrvfJTqoA cyufqhkcDqGTOidOXovYYAGLEaDS(int P_0, JjfLPgrynhOKsCdZxdUuaxcmSVVD P_1)
		{
			if (!LPlwRZQrNUHJoqoDDMZMGxHJjluA)
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
			return new hqPZfWsfbiiIsgJaREHtYrvfJTqoA
			{
				CQaIJbhvgyFSEYFljGMMiADWAajjA = P_0,
				JmvBupowbcCTTfSJlvnCnepjWgYi = hfyAVwFKrQQcyFTzPqgBcwjEFqtW.EhEwInkZsGjUGQdzKxXtSALkzION(P_1),
				BINabxjEiHuOxoxkmQvTUwvLFTMn = hfyAVwFKrQQcyFTzPqgBcwjEFqtW.KycSFRHGHvEREelaLMlBOHKNipILA(P_0),
				zylJmZBipxOVHKVKJcbVeJDfuvGD = hfyAVwFKrQQcyFTzPqgBcwjEFqtW.tllpWqIsFrjZvsfrDLbgUfYPKFLk(P_1),
				pFoIPICCxRYTyqUMBfcBpqhPYSvf = hfyAVwFKrQQcyFTzPqgBcwjEFqtW.iRnJHVkUIfcjiGMXYUUjoXieEIBw(P_1),
				uuscSrFKlkgmfNMcfWVOHFjcdxrMA = hfyAVwFKrQQcyFTzPqgBcwjEFqtW.NawvQDNSsgRNcydbgSaYaowZqvKH(P_0),
				hOQNsRShNSzckEhPNXXHNdyubLNhA = hfyAVwFKrQQcyFTzPqgBcwjEFqtW.MGmXFTmbJzcXTOaWJoiJJXqYHESg(P_1),
				LNoaUZKHNiohqJjJjICrztdiOUrf = hfyAVwFKrQQcyFTzPqgBcwjEFqtW.sTChsmwXQTbZGcMHPduAdnIeVwPMA(P_1),
				xcboHJORFPZJhzhAeFYpPalFwgET = hfyAVwFKrQQcyFTzPqgBcwjEFqtW.qrNDAXlNTHweGHJZiPaKAmMVzjnT(P_1),
				LZvoiRvXYfuqftjTMPClBWwhDmHx = hfyAVwFKrQQcyFTzPqgBcwjEFqtW.sASagGfSZWffRIcjUvviioZocxnqA(P_1)
			};
		}

		private hqPZfWsfbiiIsgJaREHtYrvfJTqoA XXFZpLZdqnPgjNepfyjjeUqvUkit(int P_0, KiEkVQpCFjwSXddVCUMBxpKMFQCc P_1)
		{
			if (P_1 == null || !P_1.IsValid)
			{
				return null;
			}
			JjfLPgrynhOKsCdZxdUuaxcmSVVD jjfLPgrynhOKsCdZxdUuaxcmSVVD = new JjfLPgrynhOKsCdZxdUuaxcmSVVD(hfyAVwFKrQQcyFTzPqgBcwjEFqtW.kZGjoAqSxzPIrNdoXhkXOyVFRJbM(P_1));
			if (!jjfLPgrynhOKsCdZxdUuaxcmSVVD.IsValid)
			{
				return null;
			}
			return cyufqhkcDqGTOidOXovYYAGLEaDS(P_0, jjfLPgrynhOKsCdZxdUuaxcmSVVD);
		}

		private void XJcSFpwqqZXZpixwaxjpKKEOTCjj()
		{
			for (int i = 0; i < bEnCIsyclHDDQpHrWuiOTqoIPWwf(); i++)
			{
				if (OsWstCSVTJhwJQEikUAYxsBmRVgD)
				{
					taOhNBhFvdnaYygqLMrwcphCogtjc(i);
				}
				if (DUqfBnYwgWpSgHIJAJNwVXXydxbN)
				{
					WudHBVOywCDKsxdAPJyWLaUsIpGL(i);
				}
			}
		}

		private void AokiFsFhyFbrrAulbspvdswIISMMA()
		{
			if (DUqfBnYwgWpSgHIJAJNwVXXydxbN)
			{
				foreach (KeyValuePair<int, akwAbTvIPdmPpleSiTKoUbPwehWgA> item in iGEZgSocnbrKmJBPxCpVGHuOgkxZA)
				{
					akwAbTvIPdmPpleSiTKoUbPwehWgA value = item.Value;
					value.KISXzmiRCJpkESCKvEgxYgrtkplr();
					value.Dispose();
				}
				iGEZgSocnbrKmJBPxCpVGHuOgkxZA.Clear();
			}
			if (!OsWstCSVTJhwJQEikUAYxsBmRVgD)
			{
				return;
			}
			foreach (KeyValuePair<int, QDivzTHsEOrHtRXDPrcQwihoJvyh> item2 in MPVEAKdrwUsphzKAGIEOLJweAmRg)
			{
				QDivzTHsEOrHtRXDPrcQwihoJvyh value2 = item2.Value;
				value2.KISXzmiRCJpkESCKvEgxYgrtkplr();
				value2.Dispose();
			}
			MPVEAKdrwUsphzKAGIEOLJweAmRg.Clear();
		}

		private bool taOhNBhFvdnaYygqLMrwcphCogtjc(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (DUqfBnYwgWpSgHIJAJNwVXXydxbN && hfyAVwFKrQQcyFTzPqgBcwjEFqtW.KycSFRHGHvEREelaLMlBOHKNipILA(P_0))
			{
				return false;
			}
			QDivzTHsEOrHtRXDPrcQwihoJvyh qDivzTHsEOrHtRXDPrcQwihoJvyh = nWOEWxKXiWfJrwByvPyGTGnvbyeQ(P_0);
			if (qDivzTHsEOrHtRXDPrcQwihoJvyh == null)
			{
				return false;
			}
			int xdFiSlAgRjbgvUEQaxytuZMwRloKA = qDivzTHsEOrHtRXDPrcQwihoJvyh.XdFiSlAgRjbgvUEQaxytuZMwRloKA;
			if (MPVEAKdrwUsphzKAGIEOLJweAmRg.ContainsKey(xdFiSlAgRjbgvUEQaxytuZMwRloKA))
			{
				MPVEAKdrwUsphzKAGIEOLJweAmRg[xdFiSlAgRjbgvUEQaxytuZMwRloKA].KISXzmiRCJpkESCKvEgxYgrtkplr();
				MPVEAKdrwUsphzKAGIEOLJweAmRg[xdFiSlAgRjbgvUEQaxytuZMwRloKA] = qDivzTHsEOrHtRXDPrcQwihoJvyh;
			}
			else
			{
				MPVEAKdrwUsphzKAGIEOLJweAmRg.Add(xdFiSlAgRjbgvUEQaxytuZMwRloKA, qDivzTHsEOrHtRXDPrcQwihoJvyh);
			}
			qDivzTHsEOrHtRXDPrcQwihoJvyh.vqilDnOpRdVUuJNTbUpqrwoOwlcO();
			return true;
		}

		private void CvdlTapfwOhYlnTYZnVDXiPrdTXAA(int P_0)
		{
			if (MPVEAKdrwUsphzKAGIEOLJweAmRg.ContainsKey(P_0))
			{
				MPVEAKdrwUsphzKAGIEOLJweAmRg[P_0].KISXzmiRCJpkESCKvEgxYgrtkplr();
				MPVEAKdrwUsphzKAGIEOLJweAmRg.Remove(P_0);
			}
		}

		private bool WudHBVOywCDKsxdAPJyWLaUsIpGL(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (!hfyAVwFKrQQcyFTzPqgBcwjEFqtW.KycSFRHGHvEREelaLMlBOHKNipILA(P_0))
			{
				return false;
			}
			akwAbTvIPdmPpleSiTKoUbPwehWgA akwAbTvIPdmPpleSiTKoUbPwehWgA2 = TZFnPeXfkjbsqMWwZNgDKIsMCotl(P_0);
			if (akwAbTvIPdmPpleSiTKoUbPwehWgA2 == null)
			{
				return false;
			}
			int xdFiSlAgRjbgvUEQaxytuZMwRloKA = akwAbTvIPdmPpleSiTKoUbPwehWgA2.XdFiSlAgRjbgvUEQaxytuZMwRloKA;
			if (iGEZgSocnbrKmJBPxCpVGHuOgkxZA.ContainsKey(xdFiSlAgRjbgvUEQaxytuZMwRloKA))
			{
				iGEZgSocnbrKmJBPxCpVGHuOgkxZA[xdFiSlAgRjbgvUEQaxytuZMwRloKA].KISXzmiRCJpkESCKvEgxYgrtkplr();
				iGEZgSocnbrKmJBPxCpVGHuOgkxZA[xdFiSlAgRjbgvUEQaxytuZMwRloKA] = akwAbTvIPdmPpleSiTKoUbPwehWgA2;
			}
			else
			{
				iGEZgSocnbrKmJBPxCpVGHuOgkxZA.Add(xdFiSlAgRjbgvUEQaxytuZMwRloKA, akwAbTvIPdmPpleSiTKoUbPwehWgA2);
			}
			akwAbTvIPdmPpleSiTKoUbPwehWgA2.vqilDnOpRdVUuJNTbUpqrwoOwlcO();
			return true;
		}

		private void aKhDnMYsLHkCLUqNEaDJEUvoyfEo(int P_0)
		{
			if (iGEZgSocnbrKmJBPxCpVGHuOgkxZA.ContainsKey(P_0))
			{
				iGEZgSocnbrKmJBPxCpVGHuOgkxZA[P_0].KISXzmiRCJpkESCKvEgxYgrtkplr();
				iGEZgSocnbrKmJBPxCpVGHuOgkxZA.Remove(P_0);
			}
		}

		private QDivzTHsEOrHtRXDPrcQwihoJvyh eIIXjIIefRWBmjXjBnmOrublxfWL(int P_0)
		{
			if (!MPVEAKdrwUsphzKAGIEOLJweAmRg.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private akwAbTvIPdmPpleSiTKoUbPwehWgA tRtixGULNWJOkMZJjirGfYcZZUYC(int P_0)
		{
			if (!iGEZgSocnbrKmJBPxCpVGHuOgkxZA.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private void oDwsCPnpgwzBCYJnoQWPYquhDSVH()
		{
			while (hfyAVwFKrQQcyFTzPqgBcwjEFqtW.bBZVbGmdwgQuOVDPdMuMUbEuqVNI(SFMGmudaGUIcfENLLISkqKwwetAVA) != 0)
			{
				ribWpWSirvSikPLKeGdCdehmrYaLA.ZDnJFoBSpvojGDHRTbtGJXRADTGCb(SFMGmudaGUIcfENLLISkqKwwetAVA);
				hfyAVwFKrQQcyFTzPqgBcwjEFqtW.hwzhwOVtGhmqPpfPjLmydoAGuQTw dxKLbyLhjNbMgXYoHOmDmazthJuE = ribWpWSirvSikPLKeGdCdehmrYaLA.dxKLbyLhjNbMgXYoHOmDmazthJuE;
				double realTime = ReInput.realTime;
				switch (dxKLbyLhjNbMgXYoHOmDmazthJuE)
				{
				case hfyAVwFKrQQcyFTzPqgBcwjEFqtW.hwzhwOVtGhmqPpfPjLmydoAGuQTw.SDL_CONTROLLERAXISMOTION:
					zwAKBsKAeQovZzzxiWsebohytHxh(ref ribWpWSirvSikPLKeGdCdehmrYaLA.oFnYdwuoOquJOcWkYUTBgdyzhOvg, realTime);
					break;
				case hfyAVwFKrQQcyFTzPqgBcwjEFqtW.hwzhwOVtGhmqPpfPjLmydoAGuQTw.SDL_CONTROLLERBUTTONDOWN:
				case hfyAVwFKrQQcyFTzPqgBcwjEFqtW.hwzhwOVtGhmqPpfPjLmydoAGuQTw.SDL_CONTROLLERBUTTONUP:
					KVLlOAJFTOokJClymkzXXuQMYYQE(ref ribWpWSirvSikPLKeGdCdehmrYaLA.hGzzncRJaHFWheOSAIoZBLGvklHU, realTime);
					break;
				case hfyAVwFKrQQcyFTzPqgBcwjEFqtW.hwzhwOVtGhmqPpfPjLmydoAGuQTw.SDL_CONTROLLERDEVICEREMAPPED:
					oEOQRXNEyXJtRhuQxrfDOMQRPdkg(ref ribWpWSirvSikPLKeGdCdehmrYaLA.sDmmkjKlbeQOVfhTUTKjDaeLbpct);
					break;
				case hfyAVwFKrQQcyFTzPqgBcwjEFqtW.hwzhwOVtGhmqPpfPjLmydoAGuQTw.SDL_JOYAXISMOTION:
					qLqFkmwttORMkkxiPBzJCEydBgbD(ref ribWpWSirvSikPLKeGdCdehmrYaLA.awlaPIGuNJJfFVeJAFmNntgNJwWd, realTime);
					break;
				case hfyAVwFKrQQcyFTzPqgBcwjEFqtW.hwzhwOVtGhmqPpfPjLmydoAGuQTw.SDL_JOYBUTTONDOWN:
				case hfyAVwFKrQQcyFTzPqgBcwjEFqtW.hwzhwOVtGhmqPpfPjLmydoAGuQTw.SDL_JOYBUTTONUP:
					KXKayHMzFhTUzcsnrNvXZEWAOiYJ(ref ribWpWSirvSikPLKeGdCdehmrYaLA.tFLBzLXiaTRfSfrgnTMeVznSkdLt, realTime);
					break;
				case hfyAVwFKrQQcyFTzPqgBcwjEFqtW.hwzhwOVtGhmqPpfPjLmydoAGuQTw.SDL_JOYHATMOTION:
					uKniNFIFDYEjNheOPIhtvCmYIvRrA(ref ribWpWSirvSikPLKeGdCdehmrYaLA.wmWCNDCNQWQPuPzoERFInxdmVWbj, realTime);
					break;
				case hfyAVwFKrQQcyFTzPqgBcwjEFqtW.hwzhwOVtGhmqPpfPjLmydoAGuQTw.SDL_JOYBALLMOTION:
					eXXETjCSSCXEcoiceSYPaCBqGwIDA(ref ribWpWSirvSikPLKeGdCdehmrYaLA.YMacKptoyHCccvERawbjXnTNBTXkA, realTime);
					break;
				case hfyAVwFKrQQcyFTzPqgBcwjEFqtW.hwzhwOVtGhmqPpfPjLmydoAGuQTw.SDL_JOYDEVICEADDED:
					uWVaboTIKfbsjZHclBHSkskPobVTA(ref ribWpWSirvSikPLKeGdCdehmrYaLA.MwjBvltceCHAXfhcZjgURHrDqbfab);
					break;
				case hfyAVwFKrQQcyFTzPqgBcwjEFqtW.hwzhwOVtGhmqPpfPjLmydoAGuQTw.SDL_JOYDEVICEREMOVED:
					TZKZUsCfWBaiobujlommgymaqqpn(ref ribWpWSirvSikPLKeGdCdehmrYaLA.MwjBvltceCHAXfhcZjgURHrDqbfab);
					break;
				case hfyAVwFKrQQcyFTzPqgBcwjEFqtW.hwzhwOVtGhmqPpfPjLmydoAGuQTw.SDL_CONTROLLERDEVICEADDED:
					ILBMnBXcnygKrjNkqdYEfTNoivpgA(ref ribWpWSirvSikPLKeGdCdehmrYaLA.sDmmkjKlbeQOVfhTUTKjDaeLbpct);
					break;
				case hfyAVwFKrQQcyFTzPqgBcwjEFqtW.hwzhwOVtGhmqPpfPjLmydoAGuQTw.SDL_CONTROLLERDEVICEREMOVED:
					zLZHXCridrXMQbhNXEFnxjgxiUhdA(ref ribWpWSirvSikPLKeGdCdehmrYaLA.sDmmkjKlbeQOVfhTUTKjDaeLbpct);
					break;
				}
			}
		}

		private void qLqFkmwttORMkkxiPBzJCEydBgbD(ref hfyAVwFKrQQcyFTzPqgBcwjEFqtW.OqkVnbCDEnCNAKZcHlnqysTaugaO P_0, double P_1)
		{
			if (OsWstCSVTJhwJQEikUAYxsBmRVgD)
			{
				ccoVobkTOQGaQSCNyWekPSjApDIM(P_0.dfedjhVPrvdQwKSknDVEfisxSunm, BYuFGAmQfVLaXMGHVtYrAeRRzSdt.Axis, P_0.qpDCUvvDmXdAhcoSIHPoMatevcmK, P_0.JmUPtkanJIHspwCiFcqbJSbJypoUA, P_1);
			}
		}

		private void KXKayHMzFhTUzcsnrNvXZEWAOiYJ(ref hfyAVwFKrQQcyFTzPqgBcwjEFqtW.oulThBPQxUTvqisHVwrrViNiataU P_0, double P_1)
		{
			if (OsWstCSVTJhwJQEikUAYxsBmRVgD)
			{
				ccoVobkTOQGaQSCNyWekPSjApDIM(P_0.ZEWqIuHdKfrrzzPKpCtQLunhljfP, BYuFGAmQfVLaXMGHVtYrAeRRzSdt.Button, P_0.bgCrhBQhkLjEhdCadvUoRhuKxinrA, P_0.SjGWRvIBpQtBvlrhCJnnkhleUbRL, P_1);
			}
		}

		private void uKniNFIFDYEjNheOPIhtvCmYIvRrA(ref hfyAVwFKrQQcyFTzPqgBcwjEFqtW.nwwTJrFRqOstZExGRHLnpmgUbxAi P_0, double P_1)
		{
			if (OsWstCSVTJhwJQEikUAYxsBmRVgD)
			{
				ccoVobkTOQGaQSCNyWekPSjApDIM(P_0.lDXLGxpotACoBuqTCaDECUsayvov, BYuFGAmQfVLaXMGHVtYrAeRRzSdt.Hat, P_0.HEOegoQKNdwgMzeNnYPYfjXgXVBJ, P_0.epGWZKlfDGExmocSmaFqMMVRuCiX, P_1);
			}
		}

		private void eXXETjCSSCXEcoiceSYPaCBqGwIDA(ref hfyAVwFKrQQcyFTzPqgBcwjEFqtW.MeOBebCMBNkiOzrXWeeLJnQGdaNS P_0, double P_1)
		{
			_ = OsWstCSVTJhwJQEikUAYxsBmRVgD;
		}

		private void uWVaboTIKfbsjZHclBHSkskPobVTA(ref hfyAVwFKrQQcyFTzPqgBcwjEFqtW.wkgfPBMvJHhKUFCXLCRoFmQGhncSb P_0)
		{
			if (OsWstCSVTJhwJQEikUAYxsBmRVgD)
			{
				taOhNBhFvdnaYygqLMrwcphCogtjc(P_0.whMMNnLDPYadlsnlEfogsKZYNuRi);
				if (AFbDXEipCkRbxDcAjQhoPLBXBoHmb != null)
				{
					AFbDXEipCkRbxDcAjQhoPLBXBoHmb();
				}
			}
		}

		private void TZKZUsCfWBaiobujlommgymaqqpn(ref hfyAVwFKrQQcyFTzPqgBcwjEFqtW.wkgfPBMvJHhKUFCXLCRoFmQGhncSb P_0)
		{
			if (OsWstCSVTJhwJQEikUAYxsBmRVgD)
			{
				CvdlTapfwOhYlnTYZnVDXiPrdTXAA(P_0.whMMNnLDPYadlsnlEfogsKZYNuRi);
				if (AFbDXEipCkRbxDcAjQhoPLBXBoHmb != null)
				{
					AFbDXEipCkRbxDcAjQhoPLBXBoHmb();
				}
			}
		}

		private void zwAKBsKAeQovZzzxiWsebohytHxh(ref hfyAVwFKrQQcyFTzPqgBcwjEFqtW.UjXkNuNwrQgtmQRqZmBBiVBVvLZw P_0, double P_1)
		{
			if (DUqfBnYwgWpSgHIJAJNwVXXydxbN && P_0.oHRKeaTitCoYZOGeCHCCmJulLuPC != 6)
			{
				dAJKuHmtIGQHkGfoaRpVnlGjDXNd(P_0.gIbwRTZavfDVLgcBZKspNZUBhPbeA, BYuFGAmQfVLaXMGHVtYrAeRRzSdt.Axis, P_0.oHRKeaTitCoYZOGeCHCCmJulLuPC, P_0.PyMblwIEDgfiTGbpMUAPCbdegELcb, P_1);
			}
		}

		private void KVLlOAJFTOokJClymkzXXuQMYYQE(ref hfyAVwFKrQQcyFTzPqgBcwjEFqtW.zPgQhjggRjaJNxCdmapWOQqdmQqr P_0, double P_1)
		{
			if (DUqfBnYwgWpSgHIJAJNwVXXydxbN && P_0.kUsfdazSftvKNWhYvghVBoFYklxrA != 15)
			{
				dAJKuHmtIGQHkGfoaRpVnlGjDXNd(P_0.MvyvqOSTyhHaRsskptsYaMDlkLhG, BYuFGAmQfVLaXMGHVtYrAeRRzSdt.Button, P_0.kUsfdazSftvKNWhYvghVBoFYklxrA, P_0.otpPWzGIMDavIuayKBRYyjKTHcoH, P_1);
			}
		}

		private void ILBMnBXcnygKrjNkqdYEfTNoivpgA(ref hfyAVwFKrQQcyFTzPqgBcwjEFqtW.PDmLzZJuYZRLUIvRxVwgNtdBWdOJ P_0)
		{
			if (DUqfBnYwgWpSgHIJAJNwVXXydxbN)
			{
				WudHBVOywCDKsxdAPJyWLaUsIpGL(P_0.TnWmWCOouCouRzhhHkPFrHZtFUchA);
				if (AFbDXEipCkRbxDcAjQhoPLBXBoHmb != null)
				{
					AFbDXEipCkRbxDcAjQhoPLBXBoHmb();
				}
			}
		}

		private void zLZHXCridrXMQbhNXEFnxjgxiUhdA(ref hfyAVwFKrQQcyFTzPqgBcwjEFqtW.PDmLzZJuYZRLUIvRxVwgNtdBWdOJ P_0)
		{
			if (DUqfBnYwgWpSgHIJAJNwVXXydxbN)
			{
				aKhDnMYsLHkCLUqNEaDJEUvoyfEo(P_0.TnWmWCOouCouRzhhHkPFrHZtFUchA);
				if (AFbDXEipCkRbxDcAjQhoPLBXBoHmb != null)
				{
					AFbDXEipCkRbxDcAjQhoPLBXBoHmb();
				}
			}
		}

		private void oEOQRXNEyXJtRhuQxrfDOMQRPdkg(ref hfyAVwFKrQQcyFTzPqgBcwjEFqtW.PDmLzZJuYZRLUIvRxVwgNtdBWdOJ P_0)
		{
			_ = DUqfBnYwgWpSgHIJAJNwVXXydxbN;
		}

		private void ccoVobkTOQGaQSCNyWekPSjApDIM(int P_0, BYuFGAmQfVLaXMGHVtYrAeRRzSdt P_1, byte P_2, short P_3, double P_4)
		{
			eIIXjIIefRWBmjXjBnmOrublxfWL(P_0)?.cDUfnJCEDlvyGteQGMoTAnnqKmmEb(P_1, P_2, P_3, P_4);
		}

		private void dAJKuHmtIGQHkGfoaRpVnlGjDXNd(int P_0, BYuFGAmQfVLaXMGHVtYrAeRRzSdt P_1, byte P_2, short P_3, double P_4)
		{
			tRtixGULNWJOkMZJjirGfYcZZUYC(P_0)?.cDUfnJCEDlvyGteQGMoTAnnqKmmEb(P_1, P_2, P_3, P_4);
		}

		private void NVHGrpVEJbbDykMRxONrvivQEnjI()
		{
			string[] array = vJNhdHZwRdjRkKiFJAaEBYgeVqDQA.pGPWUpUlrZGlDRwDwfCEpCxUZxEM();
			if (array == null)
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]) && array[i].Length > 32 && !(hfyAVwFKrQQcyFTzPqgBcwjEFqtW.vQbIKclNDOJKreZPsszVnKAMpCzO(new Guid(array[i].Substring(0, 32))) != string.Empty))
				{
					hfyAVwFKrQQcyFTzPqgBcwjEFqtW.MZYBBWJLRsprpeHxZgSRdVlfCPyU(array[i]);
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~SDL2InputSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (sqpcBSWRPFjjpBeQVJInBlSetEAJb)
			{
				return;
			}
			if (disposing)
			{
				if (SFMGmudaGUIcfENLLISkqKwwetAVA != null)
				{
					SFMGmudaGUIcfENLLISkqKwwetAVA.Dispose();
				}
				AokiFsFhyFbrrAulbspvdswIISMMA();
			}
			hfyAVwFKrQQcyFTzPqgBcwjEFqtW.NSnPiGIpRnXqYAChjWcVuhHzpXKA();
			LPlwRZQrNUHJoqoDDMZMGxHJjluA = false;
			sqpcBSWRPFjjpBeQVJInBlSetEAJb = true;
		}
	}
}
