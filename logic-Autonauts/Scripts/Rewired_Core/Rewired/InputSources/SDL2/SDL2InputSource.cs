using System;
using System.Collections.Generic;
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
		public delegate void FbxtJkwcMVEQVkyOEoydpvjcNiG(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void eQGTGPaFHXqHmAugirAbKyUSoFl(int joystickIndex);

		public delegate void qZBzOmkDEVJWgBKTkYrNWJJOINS(int joystickId);

		public delegate void ArwMlowJzwDBZFeRlemGVUhlTGMR(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int UYgPdqTqhpmmOAFjrAqkaFdzGqCo = 32;

		private bool GFOBjFaStuGtqdhXChMRrxXGhaGJ;

		private bool XUOkwXECnauQSqdUWvtDGoPEwwB;

		private bool wRKFazdkphScTnCtRJlrOfqlPrVc;

		private bool HTbuCzrVISVHITgLmqOPxlHXTus;

		private bool uvRIxvvRCxrfpiSXpAlvYqJtnEz;

		private ADictionary<int, TrPtHvDNhUzaBqlyMmTMOEWQxyO> jkFiqNnyAtbymFOLlvWZRfYeLku;

		private ADictionary<int, jcXazxtpglhNkCEyvOXbwbgAELMb> HZlCiFfmsKnmrPrizexqaxYkHBz;

		private ghVaXMJBYQVankSHALdOAwQaFIx.JRnNbdEuWlLfxtzRrdJFnlRUEaO kdoFmwqTcDJjvFlVcQLmxCswZJe;

		private NativeBuffer TcocALcOGpBgAzoCUAHMLmGSFlSk;

		private Action BJPDHydIRNniwIzhTROFdVjqueY;

		private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

		public bool initialized
		{
			get
			{
				return uvRIxvvRCxrfpiSXpAlvYqJtnEz;
			}
		}

		private event Action _DeviceChangedEvent
		{
			add
			{
				Action action = BJPDHydIRNniwIzhTROFdVjqueY;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref BJPDHydIRNniwIzhTROFdVjqueY, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = BJPDHydIRNniwIzhTROFdVjqueY;
				Action value2 = default(Action);
				Action action2 = default(Action);
				while (true)
				{
					int num = -508221029;
					while (true)
					{
						switch (num ^ -508221032)
						{
						case 4:
							break;
						default:
							return;
						case 2:
							action = Interlocked.CompareExchange(ref BJPDHydIRNniwIzhTROFdVjqueY, value2, action2);
							num = -508221032;
							continue;
						case 1:
							value2 = (Action)Delegate.Remove(action2, value3);
							num = -508221030;
							continue;
						case 0:
						{
							int num2;
							if ((object)action == action2)
							{
								num = -508221027;
								num2 = num;
							}
							else
							{
								num = -508221029;
								num2 = num;
							}
							continue;
						}
						case 3:
							action2 = action;
							num = -508221031;
							continue;
						case 5:
							return;
						}
						break;
					}
				}
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

		public SDL2InputSource(UpdateLoopSetting updateLoop, bool handleJoysticks, bool handleGamepads, bool handleUnifiedMouse, bool handleUnifiedKeyboard)
		{
			GFOBjFaStuGtqdhXChMRrxXGhaGJ = handleJoysticks;
			XUOkwXECnauQSqdUWvtDGoPEwwB = handleGamepads;
			wRKFazdkphScTnCtRJlrOfqlPrVc = handleUnifiedMouse;
			HTbuCzrVISVHITgLmqOPxlHXTus = handleUnifiedKeyboard;
			jkFiqNnyAtbymFOLlvWZRfYeLku = new ADictionary<int, TrPtHvDNhUzaBqlyMmTMOEWQxyO>();
			HZlCiFfmsKnmrPrizexqaxYkHBz = new ADictionary<int, jcXazxtpglhNkCEyvOXbwbgAELMb>();
			int num = ((!UnityTools.isEditor || UnityTools.editorPlatform != EditorPlatform.OSX) ? 29184 : 25088);
			try
			{
				ghVaXMJBYQVankSHALdOAwQaFIx.BLVNBrpPVYghRHXUwGZhEnTVbCTG(UnityTools.effectivePlatform);
				if (ghVaXMJBYQVankSHALdOAwQaFIx.VjTByEBaJwnBneVsGeiyIxJEyRMb((uint)num) < 0)
				{
					throw new Exception("Failed initialize SDL2!");
				}
				uvRIxvvRCxrfpiSXpAlvYqJtnEz = true;
				if (handleGamepads)
				{
					fSLcqqbyjVLjGtUoMfBAkNCTJng();
				}
				xTiGuyZEYpomincoVhooWqCQxjZ();
				TcocALcOGpBgAzoCUAHMLmGSFlSk = new NativeBuffer(56);
			}
			catch
			{
				uvRIxvvRCxrfpiSXpAlvYqJtnEz = false;
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
			bool uvRIxvvRCxrfpiSXpAlvYqJtnEz2 = uvRIxvvRCxrfpiSXpAlvYqJtnEz;
		}

		public void UpdateDevices(UpdateLoopType updateLoop)
		{
			if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				return;
			}
			while (true)
			{
				kfDMHpeJmuXMPoBcXnTKIbHlIvB();
				int num = 1966692898;
				while (true)
				{
					switch (num ^ 0x75395A23)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0009:
					num = 1966692897;
				}
			}
		}

		public void UpdateFinished()
		{
			bool uvRIxvvRCxrfpiSXpAlvYqJtnEz2 = uvRIxvvRCxrfpiSXpAlvYqJtnEz;
		}

		public IList<T> GetJoysticks<T>() where T : class
		{
			if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				return null;
			}
			List<CjjRDclXuvjouyeLLeBBHCfpqqbM> list = new List<CjjRDclXuvjouyeLLeBBHCfpqqbM>();
			if (GFOBjFaStuGtqdhXChMRrxXGhaGJ)
			{
				using (ADictionary<int, TrPtHvDNhUzaBqlyMmTMOEWQxyO>.Enumerator enumerator = jkFiqNnyAtbymFOLlvWZRfYeLku.GetEnumerator())
				{
					KeyValuePair<int, TrPtHvDNhUzaBqlyMmTMOEWQxyO> current = default(KeyValuePair<int, TrPtHvDNhUzaBqlyMmTMOEWQxyO>);
					while (true)
					{
						IL_005f:
						int num;
						int num2;
						if (enumerator.MoveNext())
						{
							num = 3195799;
							num2 = num;
						}
						else
						{
							num = 3195797;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x30C394)
							{
							case 2:
								num = 3195799;
								continue;
							default:
								goto end_IL_002f;
							case 3:
								current = enumerator.Current;
								num = 3195796;
								continue;
							case 4:
								break;
							case 0:
							{
								TrPtHvDNhUzaBqlyMmTMOEWQxyO value = current.Value;
								if (value.IsValid)
								{
									list.Add(current.Value);
									num = 3195792;
									continue;
								}
								break;
							}
							case 1:
								goto end_IL_002f;
							}
							goto IL_005f;
							continue;
							end_IL_002f:
							break;
						}
						break;
					}
				}
			}
			if (XUOkwXECnauQSqdUWvtDGoPEwwB)
			{
				using (ADictionary<int, jcXazxtpglhNkCEyvOXbwbgAELMb>.Enumerator enumerator2 = HZlCiFfmsKnmrPrizexqaxYkHBz.GetEnumerator())
				{
					KeyValuePair<int, jcXazxtpglhNkCEyvOXbwbgAELMb> current2 = default(KeyValuePair<int, jcXazxtpglhNkCEyvOXbwbgAELMb>);
					while (true)
					{
						IL_00fc:
						int num3;
						int num4;
						if (!enumerator2.MoveNext())
						{
							num3 = 3195796;
							num4 = num3;
						}
						else
						{
							num3 = 3195799;
							num4 = num3;
						}
						while (true)
						{
							switch (num3 ^ 0x30C394)
							{
							case 4:
								num3 = 3195799;
								continue;
							default:
								goto end_IL_00cc;
							case 3:
								current2 = enumerator2.Current;
								num3 = 3195798;
								continue;
							case 1:
								break;
							case 2:
							{
								jcXazxtpglhNkCEyvOXbwbgAELMb value2 = current2.Value;
								if (value2.IsValid)
								{
									list.Add(value2);
									num3 = 3195797;
									continue;
								}
								break;
							}
							case 0:
								goto end_IL_00cc;
							}
							goto IL_00fc;
							continue;
							end_IL_00cc:
							break;
						}
						break;
					}
				}
			}
			return list as IList<T>;
		}

		private int DbWOTaoAhUVrVxoPZYILfKjHnJW()
		{
			if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				return 0;
			}
			return Math.Min(ghVaXMJBYQVankSHALdOAwQaFIx.vtnTndbenrVDJXFIbmwmutwgpcN(), 32);
		}

		private int JervFQLkCMEhksoBEcxaGhBzQLPa()
		{
			if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				goto IL_0008;
			}
			int num = DbWOTaoAhUVrVxoPZYILfKjHnJW();
			int num2 = -662910504;
			goto IL_000d;
			IL_000d:
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ -662910499)
				{
				case 4:
					break;
				case 0:
					if (!ghVaXMJBYQVankSHALdOAwQaFIx.WfjkclXFJAhrbensoNgQUGfjPdL(num3))
					{
						num4++;
						num2 = -662910500;
						continue;
					}
					goto case 1;
				case 5:
					num4 = 0;
					num2 = -662910497;
					continue;
				case 3:
					num2 = -662910501;
					continue;
				case 7:
					return 0;
				case 2:
					num3 = 0;
					num2 = -662910498;
					continue;
				case 1:
					num3++;
					num2 = -662910501;
					continue;
				default:
					if (num3 >= num)
					{
						return num4;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -662910502;
			goto IL_000d;
		}

		private TrPtHvDNhUzaBqlyMmTMOEWQxyO cgEgrrOvlBpAWnWPifTGGNqcTiG(int P_0)
		{
			IntPtr intPtr = ghVaXMJBYQVankSHALdOAwQaFIx.jGLtIQCpPlQCnHHhExGrGGDgEhEc(P_0);
			YlWFkSrNjhWjdvjHemdfYAMOisT ylWFkSrNjhWjdvjHemdfYAMOisT = default(YlWFkSrNjhWjdvjHemdfYAMOisT);
			while (true)
			{
				int num = -528120476;
				while (true)
				{
					switch (num ^ -528120474)
					{
					case 0:
						break;
					case 2:
						if (!(intPtr == IntPtr.Zero))
						{
							goto IL_0034;
						}
						return null;
					default:
					{
						qNsaluFiUoLEvSsAIYUscPCZLjmQ qNsaluFiUoLEvSsAIYUscPCZLjmQ2 = nYKzgEIRsBCagFhzMMHTILvqWjv(P_0, ylWFkSrNjhWjdvjHemdfYAMOisT);
						if (qNsaluFiUoLEvSsAIYUscPCZLjmQ2 == null)
						{
							ghVaXMJBYQVankSHALdOAwQaFIx.mafUiXPeXuwDxxLicrOvOgLuTDS(intPtr);
							return null;
						}
						return new TrPtHvDNhUzaBqlyMmTMOEWQxyO(ylWFkSrNjhWjdvjHemdfYAMOisT, qNsaluFiUoLEvSsAIYUscPCZLjmQ2);
					}
					}
					break;
					IL_0034:
					ylWFkSrNjhWjdvjHemdfYAMOisT = new YlWFkSrNjhWjdvjHemdfYAMOisT(intPtr);
					num = -528120473;
				}
			}
		}

		private jcXazxtpglhNkCEyvOXbwbgAELMb IplZpPYelEUlNzgLraOsByvgjBXs(int P_0)
		{
			IntPtr intPtr = ghVaXMJBYQVankSHALdOAwQaFIx.kzhmPkJDtMGsQAIFBabsNuKwtAg(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			JAfkxdvdQnyFyALnVRHRXQkPlEy jAfkxdvdQnyFyALnVRHRXQkPlEy = new JAfkxdvdQnyFyALnVRHRXQkPlEy(intPtr);
			qNsaluFiUoLEvSsAIYUscPCZLjmQ qNsaluFiUoLEvSsAIYUscPCZLjmQ2 = febDLeCILjrZNLslhosEqRAIUBPh(P_0, jAfkxdvdQnyFyALnVRHRXQkPlEy);
			if (qNsaluFiUoLEvSsAIYUscPCZLjmQ2 == null)
			{
				return null;
			}
			if (!qNsaluFiUoLEvSsAIYUscPCZLjmQ2.ECdATEULlbnCZNYlfPVyYElFMSg)
			{
				ghVaXMJBYQVankSHALdOAwQaFIx.icRvXyukGFCbzpwamidULnfXqZX(intPtr);
				return null;
			}
			qNsaluFiUoLEvSsAIYUscPCZLjmQ2.tbpVRpBintMlFYmEBYAejKmUJRZ = ghVaXMJBYQVankSHALdOAwQaFIx.MlgbxFGcpONnTFfEGDzwaiXGZRll(jAfkxdvdQnyFyALnVRHRXQkPlEy);
			return new jcXazxtpglhNkCEyvOXbwbgAELMb(jAfkxdvdQnyFyALnVRHRXQkPlEy, qNsaluFiUoLEvSsAIYUscPCZLjmQ2);
		}

		private qNsaluFiUoLEvSsAIYUscPCZLjmQ nYKzgEIRsBCagFhzMMHTILvqWjv(int P_0, YlWFkSrNjhWjdvjHemdfYAMOisT P_1)
		{
			if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				goto IL_0008;
			}
			int num;
			int num2;
			if (P_0 < 0)
			{
				num = -781323038;
				num2 = num;
			}
			else
			{
				num = -781323033;
				num2 = num;
			}
			goto IL_000d;
			IL_0008:
			num = -781323040;
			goto IL_000d;
			IL_000d:
			qNsaluFiUoLEvSsAIYUscPCZLjmQ qNsaluFiUoLEvSsAIYUscPCZLjmQ2 = default(qNsaluFiUoLEvSsAIYUscPCZLjmQ);
			while (true)
			{
				switch (num ^ -781323034)
				{
				case 0:
					break;
				case 6:
					return null;
				case 1:
					if (P_0 >= 32)
					{
						num = -781323038;
						continue;
					}
					if (P_1 != null)
					{
						if (P_1.IsValid)
						{
							qNsaluFiUoLEvSsAIYUscPCZLjmQ2 = new qNsaluFiUoLEvSsAIYUscPCZLjmQ();
							num = -781323039;
						}
						else
						{
							num = -781323026;
						}
						continue;
					}
					goto case 8;
				case 2:
					qNsaluFiUoLEvSsAIYUscPCZLjmQ2.LZfmAivKotoKXSdjmhyAbQsjphNu = ghVaXMJBYQVankSHALdOAwQaFIx.FJFfzZATjBnlRVXZBKFjcTIpmMD(P_1);
					qNsaluFiUoLEvSsAIYUscPCZLjmQ2.HutaqfcRTUhQZfMEkChCaNSNzozi = ghVaXMJBYQVankSHALdOAwQaFIx.jEkRFmCtDqHpBLejJbWzGEeMpmRo(P_1);
					qNsaluFiUoLEvSsAIYUscPCZLjmQ2.VLlFtUPFDQMZYbCugdzTrzwVafN = ghVaXMJBYQVankSHALdOAwQaFIx.fRtBEvAwabCkJrXykiewuNSpTjOt(P_0);
					qNsaluFiUoLEvSsAIYUscPCZLjmQ2.vgSbQnhkfGJDrjOShKPojdhsCSkQ = ghVaXMJBYQVankSHALdOAwQaFIx.JZpaLLZfyaDexWHLwHpYWtfqfGB(P_1);
					num = -781323035;
					continue;
				case 3:
					qNsaluFiUoLEvSsAIYUscPCZLjmQ2.ijxelHigybruBiYdNSiiNzGQTwsf = ghVaXMJBYQVankSHALdOAwQaFIx.bkpfjXBXDZerJRopQcmXUrRjrVMu(P_1);
					qNsaluFiUoLEvSsAIYUscPCZLjmQ2.LkoNLyiGljUAOYiLwFBXFsySPZWE = ghVaXMJBYQVankSHALdOAwQaFIx.plhHcJrrBuIacfNSddZqKtehIZP(P_1);
					num = -781323037;
					continue;
				case 8:
					return null;
				case 7:
					qNsaluFiUoLEvSsAIYUscPCZLjmQ2.RDBCHpRATqkKDTZrBXQzswJqBKy = P_0;
					qNsaluFiUoLEvSsAIYUscPCZLjmQ2.jcnkaPSoteabRKQloFgpXSzqPnCu = ghVaXMJBYQVankSHALdOAwQaFIx.PTuYToPFBMZmNJAfxGeXGfhOnilU(P_1);
					qNsaluFiUoLEvSsAIYUscPCZLjmQ2.ECdATEULlbnCZNYlfPVyYElFMSg = ghVaXMJBYQVankSHALdOAwQaFIx.WfjkclXFJAhrbensoNgQUGfjPdL(P_0);
					num = -781323036;
					continue;
				case 4:
					return null;
				default:
					qNsaluFiUoLEvSsAIYUscPCZLjmQ2.LiJyBgKhjxmyhQbWqaNTKEOpkweF = ghVaXMJBYQVankSHALdOAwQaFIx.PlOhqTbSzmWxlSTdVsUIXfrXWwA(P_1);
					return qNsaluFiUoLEvSsAIYUscPCZLjmQ2;
				}
				break;
			}
			goto IL_0008;
		}

		private qNsaluFiUoLEvSsAIYUscPCZLjmQ febDLeCILjrZNLslhosEqRAIUBPh(int P_0, JAfkxdvdQnyFyALnVRHRXQkPlEy P_1)
		{
			YlWFkSrNjhWjdvjHemdfYAMOisT ylWFkSrNjhWjdvjHemdfYAMOisT = default(YlWFkSrNjhWjdvjHemdfYAMOisT);
			int num;
			if (P_1 != null)
			{
				if (!P_1.IsValid)
				{
					goto IL_000b;
				}
				ylWFkSrNjhWjdvjHemdfYAMOisT = new YlWFkSrNjhWjdvjHemdfYAMOisT(ghVaXMJBYQVankSHALdOAwQaFIx.ogEZUGzhUNPUZgnEuRJZTqOurxf(P_1));
				num = 633530730;
				goto IL_0010;
			}
			goto IL_0029;
			IL_0029:
			return null;
			IL_0043:
			if (!ylWFkSrNjhWjdvjHemdfYAMOisT.IsValid)
			{
				return null;
			}
			return nYKzgEIRsBCagFhzMMHTILvqWjv(P_0, ylWFkSrNjhWjdvjHemdfYAMOisT);
			IL_000b:
			num = 633530729;
			goto IL_0010;
			IL_0010:
			switch (num ^ 0x25C2E96B)
			{
			case 0:
				break;
			case 2:
				goto IL_0029;
			default:
				goto IL_0043;
			}
			goto IL_000b;
		}

		private void xTiGuyZEYpomincoVhooWqCQxjZ()
		{
			int num = 0;
			while (true)
			{
				int num2 = -667700011;
				while (true)
				{
					switch (num2 ^ -667700015)
					{
					case 3:
						break;
					default:
						return;
					case 5:
						num++;
						num2 = -667700015;
						continue;
					case 0:
					{
						int num4;
						if (num >= DbWOTaoAhUVrVxoPZYILfKjHnJW())
						{
							num2 = -667700016;
							num4 = num2;
						}
						else
						{
							num2 = -667700010;
							num4 = num2;
						}
						continue;
					}
					case 2:
						mpUlqopIQCsPWuqeqKduhgfwJaJ(num);
						num2 = -667700012;
						continue;
					case 7:
						if (GFOBjFaStuGtqdhXChMRrxXGhaGJ)
						{
							smUkDayiHihrGSbHIdshwNmKRmC(num);
							num2 = -667700009;
							continue;
						}
						goto case 6;
					case 4:
						num2 = -667700015;
						continue;
					case 6:
					{
						int num3;
						if (XUOkwXECnauQSqdUWvtDGoPEwwB)
						{
							num2 = -667700013;
							num3 = num2;
						}
						else
						{
							num2 = -667700012;
							num3 = num2;
						}
						continue;
					}
					case 1:
						return;
					}
					break;
				}
			}
		}

		private void RpaHVHraDlkWfxSvBjfvSIHNou()
		{
			if (XUOkwXECnauQSqdUWvtDGoPEwwB)
			{
				using (ADictionary<int, jcXazxtpglhNkCEyvOXbwbgAELMb>.Enumerator enumerator = HZlCiFfmsKnmrPrizexqaxYkHBz.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							KeyValuePair<int, jcXazxtpglhNkCEyvOXbwbgAELMb> current = enumerator.Current;
							int num = -1387986856;
							while (true)
							{
								switch (num ^ -1387986853)
								{
								case 2:
									num = -1387986854;
									continue;
								case 1:
									break;
								case 3:
								{
									jcXazxtpglhNkCEyvOXbwbgAELMb value = current.Value;
									value.EfuzcGRTdwMXMiyHPSiDOFQiGVYF();
									value.Dispose();
									num = -1387986853;
									continue;
								}
								default:
									goto end_IL_003c;
								}
								break;
							}
							continue;
							end_IL_003c:
							break;
						}
					}
				}
				HZlCiFfmsKnmrPrizexqaxYkHBz.Clear();
				goto IL_008a;
			}
			goto IL_00a8;
			IL_008f:
			int num2;
			switch (num2 ^ -1387986853)
			{
			case 0:
				break;
			case 1:
				goto IL_00a8;
			default:
			{
				using (ADictionary<int, TrPtHvDNhUzaBqlyMmTMOEWQxyO>.Enumerator enumerator2 = jkFiqNnyAtbymFOLlvWZRfYeLku.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							TrPtHvDNhUzaBqlyMmTMOEWQxyO value2 = enumerator2.Current.Value;
							value2.EfuzcGRTdwMXMiyHPSiDOFQiGVYF();
							value2.Dispose();
							int num3 = -1387986855;
							while (true)
							{
								switch (num3 ^ -1387986853)
								{
								case 0:
									num3 = -1387986854;
									continue;
								case 1:
									break;
								default:
									goto end_IL_00e4;
								}
								break;
							}
							continue;
							end_IL_00e4:
							break;
						}
					}
				}
				jkFiqNnyAtbymFOLlvWZRfYeLku.Clear();
				return;
			}
			}
			goto IL_008a;
			IL_00a8:
			if (GFOBjFaStuGtqdhXChMRrxXGhaGJ)
			{
				num2 = -1387986855;
				goto IL_008f;
			}
			return;
			IL_008a:
			num2 = -1387986854;
			goto IL_008f;
		}

		private bool smUkDayiHihrGSbHIdshwNmKRmC(int P_0)
		{
			int num;
			if (P_0 >= 0)
			{
				if (P_0 >= 32)
				{
					goto IL_000f;
				}
				if (XUOkwXECnauQSqdUWvtDGoPEwwB)
				{
					num = 1911263462;
					goto IL_0014;
				}
				goto IL_0042;
			}
			goto IL_0099;
			IL_0042:
			TrPtHvDNhUzaBqlyMmTMOEWQxyO trPtHvDNhUzaBqlyMmTMOEWQxyO = cgEgrrOvlBpAWnWPifTGGNqcTiG(P_0);
			if (trPtHvDNhUzaBqlyMmTMOEWQxyO == null)
			{
				return false;
			}
			int qSUtKeYrVQsKSLtKzacvtYVJQgg = trPtHvDNhUzaBqlyMmTMOEWQxyO.qSUtKeYrVQsKSLtKzacvtYVJQgg;
			if (jkFiqNnyAtbymFOLlvWZRfYeLku.ContainsKey(qSUtKeYrVQsKSLtKzacvtYVJQgg))
			{
				jkFiqNnyAtbymFOLlvWZRfYeLku[qSUtKeYrVQsKSLtKzacvtYVJQgg].EfuzcGRTdwMXMiyHPSiDOFQiGVYF();
				jkFiqNnyAtbymFOLlvWZRfYeLku[qSUtKeYrVQsKSLtKzacvtYVJQgg] = trPtHvDNhUzaBqlyMmTMOEWQxyO;
				num = 1911263457;
				goto IL_0014;
			}
			goto IL_00ad;
			IL_00ad:
			jkFiqNnyAtbymFOLlvWZRfYeLku.Add(qSUtKeYrVQsKSLtKzacvtYVJQgg, trPtHvDNhUzaBqlyMmTMOEWQxyO);
			num = 1911263457;
			goto IL_0014;
			IL_0099:
			return false;
			IL_000f:
			num = 1911263456;
			goto IL_0014;
			IL_0014:
			while (true)
			{
				switch (num ^ 0x71EB90E3)
				{
				case 4:
					break;
				case 1:
					return false;
				case 2:
					trPtHvDNhUzaBqlyMmTMOEWQxyO.dFyvOnKBbTYzKLbxHBbiIGdcrpeH();
					num = 1911263459;
					continue;
				case 3:
					goto IL_0099;
				case 6:
					goto IL_00ad;
				case 5:
					goto IL_00c4;
				default:
					return true;
				}
				break;
				IL_00c4:
				if (ghVaXMJBYQVankSHALdOAwQaFIx.WfjkclXFJAhrbensoNgQUGfjPdL(P_0))
				{
					num = 1911263458;
					continue;
				}
				goto IL_0042;
			}
			goto IL_000f;
		}

		private void OofrlqURwBfyXhkklkQophvJZqM(int P_0)
		{
			if (!jkFiqNnyAtbymFOLlvWZRfYeLku.ContainsKey(P_0))
			{
				return;
			}
			while (true)
			{
				jkFiqNnyAtbymFOLlvWZRfYeLku[P_0].EfuzcGRTdwMXMiyHPSiDOFQiGVYF();
				int num = 1805734293;
				while (true)
				{
					switch (num ^ 0x6BA15195)
					{
					case 2:
						goto IL_000f;
					case 1:
						break;
					default:
						jkFiqNnyAtbymFOLlvWZRfYeLku.Remove(P_0);
						return;
					}
					break;
					IL_000f:
					num = 1805734292;
				}
			}
		}

		private bool mpUlqopIQCsPWuqeqKduhgfwJaJ(int P_0)
		{
			jcXazxtpglhNkCEyvOXbwbgAELMb jcXazxtpglhNkCEyvOXbwbgAELMb2 = default(jcXazxtpglhNkCEyvOXbwbgAELMb);
			int num;
			if (P_0 >= 0)
			{
				if (P_0 >= 32)
				{
					goto IL_0009;
				}
				if (!ghVaXMJBYQVankSHALdOAwQaFIx.WfjkclXFJAhrbensoNgQUGfjPdL(P_0))
				{
					return false;
				}
				jcXazxtpglhNkCEyvOXbwbgAELMb2 = IplZpPYelEUlNzgLraOsByvgjBXs(P_0);
				num = -1483091126;
				goto IL_000e;
			}
			goto IL_003a;
			IL_000e:
			int qSUtKeYrVQsKSLtKzacvtYVJQgg = default(int);
			while (true)
			{
				switch (num ^ -1483091121)
				{
				case 3:
					break;
				case 4:
					goto IL_003a;
				case 0:
					jcXazxtpglhNkCEyvOXbwbgAELMb2.dFyvOnKBbTYzKLbxHBbiIGdcrpeH();
					num = -1483091122;
					continue;
				case 6:
					goto IL_0062;
				case 2:
					num = -1483091121;
					continue;
				case 5:
					goto IL_007d;
				default:
					return true;
				}
				break;
				IL_007d:
				if (jcXazxtpglhNkCEyvOXbwbgAELMb2 == null)
				{
					return false;
				}
				qSUtKeYrVQsKSLtKzacvtYVJQgg = jcXazxtpglhNkCEyvOXbwbgAELMb2.qSUtKeYrVQsKSLtKzacvtYVJQgg;
				if (HZlCiFfmsKnmrPrizexqaxYkHBz.ContainsKey(qSUtKeYrVQsKSLtKzacvtYVJQgg))
				{
					HZlCiFfmsKnmrPrizexqaxYkHBz[qSUtKeYrVQsKSLtKzacvtYVJQgg].EfuzcGRTdwMXMiyHPSiDOFQiGVYF();
					HZlCiFfmsKnmrPrizexqaxYkHBz[qSUtKeYrVQsKSLtKzacvtYVJQgg] = jcXazxtpglhNkCEyvOXbwbgAELMb2;
					num = -1483091123;
					continue;
				}
				goto IL_0062;
				IL_0062:
				HZlCiFfmsKnmrPrizexqaxYkHBz.Add(qSUtKeYrVQsKSLtKzacvtYVJQgg, jcXazxtpglhNkCEyvOXbwbgAELMb2);
				num = -1483091121;
			}
			goto IL_0009;
			IL_0009:
			num = -1483091125;
			goto IL_000e;
			IL_003a:
			return false;
		}

		private void YsmGEMdulhDdWAYugTcWaHOozjYx(int P_0)
		{
			if (!HZlCiFfmsKnmrPrizexqaxYkHBz.ContainsKey(P_0))
			{
				goto IL_000e;
			}
			goto IL_0038;
			IL_000e:
			int num = 1895958740;
			goto IL_0013;
			IL_0013:
			switch (num ^ 0x710208D6)
			{
			case 0:
				break;
			case 2:
				return;
			case 3:
				goto IL_0038;
			default:
				HZlCiFfmsKnmrPrizexqaxYkHBz.Remove(P_0);
				return;
			}
			goto IL_000e;
			IL_0038:
			HZlCiFfmsKnmrPrizexqaxYkHBz[P_0].EfuzcGRTdwMXMiyHPSiDOFQiGVYF();
			num = 1895958743;
			goto IL_0013;
		}

		private TrPtHvDNhUzaBqlyMmTMOEWQxyO xAlDSakduEshspYiMCsskFkAoke(int P_0)
		{
			TrPtHvDNhUzaBqlyMmTMOEWQxyO value;
			if (!jkFiqNnyAtbymFOLlvWZRfYeLku.TryGetValue(P_0, out value))
			{
				return null;
			}
			return value;
		}

		private jcXazxtpglhNkCEyvOXbwbgAELMb pgEyPRddMcfWHZAALoCbJyeffVa(int P_0)
		{
			jcXazxtpglhNkCEyvOXbwbgAELMb value;
			if (!HZlCiFfmsKnmrPrizexqaxYkHBz.TryGetValue(P_0, out value))
			{
				return null;
			}
			return value;
		}

		private void kfDMHpeJmuXMPoBcXnTKIbHlIvB()
		{
			float realTime = default(float);
			ghVaXMJBYQVankSHALdOAwQaFIx.QdZiliaATGcWZcvnfGWERdfRvcD qdZiliaATGcWZcvnfGWERdfRvcD = default(ghVaXMJBYQVankSHALdOAwQaFIx.QdZiliaATGcWZcvnfGWERdfRvcD);
			while (ghVaXMJBYQVankSHALdOAwQaFIx.lPBBckpKOFxewSjeknkZOneiJaw(TcocALcOGpBgAzoCUAHMLmGSFlSk) != 0)
			{
				while (true)
				{
					kdoFmwqTcDJjvFlVcQLmxCswZJe.ajMSBrqFikwJIxYhLcuNrzJzMqO(TcocALcOGpBgAzoCUAHMLmGSFlSk);
					int num = 31676045;
					while (true)
					{
						switch (num ^ 0x1E35682)
						{
						case 2:
							num = 31676049;
							continue;
						case 17:
							num = 31676036;
							continue;
						case 5:
							jeHGjchYVRJfppoMleQLVaPOZij(ref kdoFmwqTcDJjvFlVcQLmxCswZJe.nWrDxbivbuMNKFGQXAmebGUaewWT);
							num = 31676036;
							continue;
						case 4:
							goto IL_0089;
						case 16:
							goto IL_00a5;
						case 18:
							goto IL_00c0;
						case 11:
							goto IL_00dc;
						case 1:
							goto IL_00f8;
						case 7:
							num = 31676036;
							continue;
						case 12:
							goto IL_011d;
						case 10:
							num = 31676036;
							continue;
						case 3:
							goto IL_0143;
						case 0:
							goto IL_015e;
						case 15:
						{
							ghVaXMJBYQVankSHALdOAwQaFIx.QdZiliaATGcWZcvnfGWERdfRvcD oZwQlYcarNzBEFVQMCHtFEzaYMx = kdoFmwqTcDJjvFlVcQLmxCswZJe.oZwQlYcarNzBEFVQMCHtFEzaYMx;
							realTime = ReInput.realTime;
							qdZiliaATGcWZcvnfGWERdfRvcD = oZwQlYcarNzBEFVQMCHtFEzaYMx;
							num = 31676042;
							continue;
						}
						case 9:
							goto IL_0198;
						case 8:
							switch (qdZiliaATGcWZcvnfGWERdfRvcD)
							{
							case ghVaXMJBYQVankSHALdOAwQaFIx.QdZiliaATGcWZcvnfGWERdfRvcD.TNcNYUUBdjHPgdEtelJTPJLaeiHd:
								break;
							case ghVaXMJBYQVankSHALdOAwQaFIx.QdZiliaATGcWZcvnfGWERdfRvcD.RktcdlQqmIfNaAcNfkTQDTlBGOu:
							case ghVaXMJBYQVankSHALdOAwQaFIx.QdZiliaATGcWZcvnfGWERdfRvcD.xAPUGjHPsBTNkkodLgFVgWniEct:
								goto IL_0089;
							case ghVaXMJBYQVankSHALdOAwQaFIx.QdZiliaATGcWZcvnfGWERdfRvcD.oCRRNqAfEcCKmhgCFGosDTepVKXQ:
								goto IL_00a5;
							case ghVaXMJBYQVankSHALdOAwQaFIx.QdZiliaATGcWZcvnfGWERdfRvcD.TUHYYERhFMKPNywbrmJvMGbDdnz:
								goto IL_00c0;
							case ghVaXMJBYQVankSHALdOAwQaFIx.QdZiliaATGcWZcvnfGWERdfRvcD.YbKDeLpHDtofnIvAoMIFtAPMaXE:
								goto IL_00dc;
							case ghVaXMJBYQVankSHALdOAwQaFIx.QdZiliaATGcWZcvnfGWERdfRvcD.ezsOawiDcOeRaxzvnpsEYwnMPIv:
								goto IL_00f8;
							case ghVaXMJBYQVankSHALdOAwQaFIx.QdZiliaATGcWZcvnfGWERdfRvcD.iEJNJwyvBIJPLBiYhvfgsqzPNrj:
							case ghVaXMJBYQVankSHALdOAwQaFIx.QdZiliaATGcWZcvnfGWERdfRvcD.TILGrXqggWvsoNLWNtYsjvSkuJZ:
								goto IL_011d;
							case ghVaXMJBYQVankSHALdOAwQaFIx.QdZiliaATGcWZcvnfGWERdfRvcD.UhyEbbbdoWYzMtkcoAvtwRlHAvBB:
								goto IL_0143;
							case ghVaXMJBYQVankSHALdOAwQaFIx.QdZiliaATGcWZcvnfGWERdfRvcD.dJRRckDVJTuvJcphvAgJmfipKmL:
								goto IL_015e;
							case ghVaXMJBYQVankSHALdOAwQaFIx.QdZiliaATGcWZcvnfGWERdfRvcD.fAwEqYzaBkfDgxtflWpOXliirl:
								goto IL_0198;
							default:
								goto IL_01ff;
							case ghVaXMJBYQVankSHALdOAwQaFIx.QdZiliaATGcWZcvnfGWERdfRvcD.tOzCjBvRQqqQSNNIHWgCcJZZKFI:
								goto IL_0213;
							}
							goto case 5;
						case 13:
							num = 31676036;
							continue;
						case 14:
							goto IL_0213;
						case 19:
							break;
						default:
							goto end_IL_022f;
							IL_0213:
							IyuaeeHiPOCRJQggYugBHQVYIOUi(ref kdoFmwqTcDJjvFlVcQLmxCswZJe.ehtdqwXGfGKrVtcmEIzLBsfbDRnb, realTime);
							num = 31676036;
							continue;
							IL_01ff:
							num = 31676037;
							continue;
							IL_0198:
							uFJkfcHHBbEhLcBtohmiBPsWSTOj(ref kdoFmwqTcDJjvFlVcQLmxCswZJe.XDALKzulFeLYLDRnBSmMbZzBfi);
							num = 31676036;
							continue;
							IL_015e:
							OfrdShNMUoHXlTcKpAXYDANQexAd(ref kdoFmwqTcDJjvFlVcQLmxCswZJe.GMWqyFPZXmETcrprIypMtwvIsMp, realTime);
							num = 31676036;
							continue;
							IL_0143:
							StusLbOMORxqRFfNlUqRtAIUVmQ(ref kdoFmwqTcDJjvFlVcQLmxCswZJe.XDALKzulFeLYLDRnBSmMbZzBfi);
							num = 31676036;
							continue;
							IL_011d:
							IPIOpZChCMMoFFqgaImraQakCNb(ref kdoFmwqTcDJjvFlVcQLmxCswZJe.aJjUTsdwBKszZWkDXuYVnwEtEPl, realTime);
							num = 31676047;
							continue;
							IL_00f8:
							JmkIbZmdEcvMmsoKZvmtNEFWjad(ref kdoFmwqTcDJjvFlVcQLmxCswZJe.XDALKzulFeLYLDRnBSmMbZzBfi);
							num = 31676036;
							continue;
							IL_00dc:
							fRVeMifpAZBQLeOlikWdKKqFgLuO(ref kdoFmwqTcDJjvFlVcQLmxCswZJe.EFhwMWQLujkVVeilMzuDzhApiLo, realTime);
							num = 31676036;
							continue;
							IL_00c0:
							laYPKKgsWEOMBmeRoKGOUmHEgtX(ref kdoFmwqTcDJjvFlVcQLmxCswZJe.MBQofzgXxxBumtttcxFXMLcEwZr, realTime);
							num = 31676040;
							continue;
							IL_00a5:
							jCPccAFjEfdEAesAIynjEosPHTpW(ref kdoFmwqTcDJjvFlVcQLmxCswZJe.nWrDxbivbuMNKFGQXAmebGUaewWT);
							num = 31676036;
							continue;
							IL_0089:
							tQDLSjzodiPhTPKCdqIaPWLoAlv(ref kdoFmwqTcDJjvFlVcQLmxCswZJe.EvecSxUZQuFPhlBgGJhfQYAytOZ, realTime);
							num = 31676051;
							continue;
						}
						break;
					}
					continue;
					end_IL_022f:
					break;
				}
			}
		}

		private void OfrdShNMUoHXlTcKpAXYDANQexAd(ref ghVaXMJBYQVankSHALdOAwQaFIx.peVnWIqwUOskTAoBYXOuFqKgBgGk P_0, float P_1)
		{
			if (GFOBjFaStuGtqdhXChMRrxXGhaGJ)
			{
				QuDlPAlQYMqAMfnwNusbZQKtAwq(P_0.HmcEZwKvOddGTHumCDKPFPMufOB, OpPHOecnOFEyUhUbCJxiojmzacz.wKybpxkoZWaYEapGxBsAGbjTuDaO, P_0.IUzwGoPtaHfYiMvlucKYMBMoIla, P_0.kXoKOSZJMKwATOiGMaylYIDqdDnb, P_1);
			}
		}

		private void IPIOpZChCMMoFFqgaImraQakCNb(ref ghVaXMJBYQVankSHALdOAwQaFIx.PKTOPUaSezsJfFEeBCKJYdEchQC P_0, float P_1)
		{
			if (GFOBjFaStuGtqdhXChMRrxXGhaGJ)
			{
				QuDlPAlQYMqAMfnwNusbZQKtAwq(P_0.HmcEZwKvOddGTHumCDKPFPMufOB, OpPHOecnOFEyUhUbCJxiojmzacz.tGxrHTDCkRdlaRMIzxipqdsMQjr, P_0.mBPfBEUnhYYKVouGnbAIniLULCa, P_0.GQmuXztxHjqMAaBUMWpbxOBsTgO, P_1);
			}
		}

		private void laYPKKgsWEOMBmeRoKGOUmHEgtX(ref ghVaXMJBYQVankSHALdOAwQaFIx.dcsSNJQblBEJmMSAtSLlNQGjLxn P_0, float P_1)
		{
			if (GFOBjFaStuGtqdhXChMRrxXGhaGJ)
			{
				QuDlPAlQYMqAMfnwNusbZQKtAwq(P_0.HmcEZwKvOddGTHumCDKPFPMufOB, OpPHOecnOFEyUhUbCJxiojmzacz.WQofIGFEPMfSSrmflNjtUyWRexS, P_0.vYMbvHbTMuHLtdoXNgWlzLHiooR, P_0.kXoKOSZJMKwATOiGMaylYIDqdDnb, P_1);
			}
		}

		private void fRVeMifpAZBQLeOlikWdKKqFgLuO(ref ghVaXMJBYQVankSHALdOAwQaFIx.zzRYcZAuMFqrdCvUIWCzdgPSynz P_0, float P_1)
		{
			bool gFOBjFaStuGtqdhXChMRrxXGhaGJ = GFOBjFaStuGtqdhXChMRrxXGhaGJ;
		}

		private void jCPccAFjEfdEAesAIynjEosPHTpW(ref ghVaXMJBYQVankSHALdOAwQaFIx.knboRfEdwcDbUATXlxvIiwStbOL P_0)
		{
			if (!GFOBjFaStuGtqdhXChMRrxXGhaGJ)
			{
				return;
			}
			while (true)
			{
				smUkDayiHihrGSbHIdshwNmKRmC(P_0.HmcEZwKvOddGTHumCDKPFPMufOB);
				int num = -68051522;
				while (true)
				{
					switch (num ^ -68051523)
					{
					case 0:
						num = -68051524;
						continue;
					default:
						return;
					case 1:
						break;
					case 3:
						if (BJPDHydIRNniwIzhTROFdVjqueY != null)
						{
							BJPDHydIRNniwIzhTROFdVjqueY();
							num = -68051521;
							continue;
						}
						return;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void jeHGjchYVRJfppoMleQLVaPOZij(ref ghVaXMJBYQVankSHALdOAwQaFIx.knboRfEdwcDbUATXlxvIiwStbOL P_0)
		{
			if (!GFOBjFaStuGtqdhXChMRrxXGhaGJ)
			{
				return;
			}
			while (true)
			{
				OofrlqURwBfyXhkklkQophvJZqM(P_0.HmcEZwKvOddGTHumCDKPFPMufOB);
				if (BJPDHydIRNniwIzhTROFdVjqueY == null)
				{
					break;
				}
				BJPDHydIRNniwIzhTROFdVjqueY();
				int num = 1185243085;
				while (true)
				{
					switch (num ^ 0x46A55FCD)
					{
					case 2:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0009:
					num = 1185243084;
				}
			}
		}

		private void IyuaeeHiPOCRJQggYugBHQVYIOUi(ref ghVaXMJBYQVankSHALdOAwQaFIx.ZjMCRXUEKeuGkuPWmCSOGEzCRDqH P_0, float P_1)
		{
			if (!XUOkwXECnauQSqdUWvtDGoPEwwB)
			{
				return;
			}
			while (true)
			{
				byte iUzwGoPtaHfYiMvlucKYMBMoIla = P_0.IUzwGoPtaHfYiMvlucKYMBMoIla;
				int num = 2130809070;
				while (true)
				{
					switch (num ^ 0x7F0190EC)
					{
					case 4:
						num = 2130809069;
						continue;
					default:
						return;
					case 0:
						TrzrpJeiIvAwupdueYOydmTfkQF(P_0.HmcEZwKvOddGTHumCDKPFPMufOB, OpPHOecnOFEyUhUbCJxiojmzacz.wKybpxkoZWaYEapGxBsAGbjTuDaO, P_0.IUzwGoPtaHfYiMvlucKYMBMoIla, P_0.kXoKOSZJMKwATOiGMaylYIDqdDnb, P_1);
						num = 2130809071;
						continue;
					case 2:
					{
						int num2;
						if (iUzwGoPtaHfYiMvlucKYMBMoIla == 6)
						{
							num = 2130809071;
							num2 = num;
						}
						else
						{
							num = 2130809068;
							num2 = num;
						}
						continue;
					}
					case 1:
						break;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void tQDLSjzodiPhTPKCdqIaPWLoAlv(ref ghVaXMJBYQVankSHALdOAwQaFIx.ruhSXFittVaiLJBcayohmDStUOc P_0, float P_1)
		{
			if (!XUOkwXECnauQSqdUWvtDGoPEwwB)
			{
				return;
			}
			while (true)
			{
				byte mBPfBEUnhYYKVouGnbAIniLULCa = P_0.mBPfBEUnhYYKVouGnbAIniLULCa;
				int num;
				int num2;
				if (mBPfBEUnhYYKVouGnbAIniLULCa != 15)
				{
					num = 1075014778;
					num2 = num;
				}
				else
				{
					num = 1075014779;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x40136C79)
					{
					case 0:
						num = 1075014776;
						continue;
					default:
						return;
					case 1:
						break;
					case 3:
						TrzrpJeiIvAwupdueYOydmTfkQF(P_0.HmcEZwKvOddGTHumCDKPFPMufOB, OpPHOecnOFEyUhUbCJxiojmzacz.tGxrHTDCkRdlaRMIzxipqdsMQjr, P_0.mBPfBEUnhYYKVouGnbAIniLULCa, P_0.GQmuXztxHjqMAaBUMWpbxOBsTgO, P_1);
						num = 1075014779;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void StusLbOMORxqRFfNlUqRtAIUVmQ(ref ghVaXMJBYQVankSHALdOAwQaFIx.KWhlJMqrfbvSYjBrsssVretqTb P_0)
		{
			if (!XUOkwXECnauQSqdUWvtDGoPEwwB)
			{
				return;
			}
			while (true)
			{
				mpUlqopIQCsPWuqeqKduhgfwJaJ(P_0.HmcEZwKvOddGTHumCDKPFPMufOB);
				if (BJPDHydIRNniwIzhTROFdVjqueY == null)
				{
					break;
				}
				BJPDHydIRNniwIzhTROFdVjqueY();
				int num = 2117519491;
				while (true)
				{
					switch (num ^ 0x7E36C881)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0009:
					num = 2117519488;
				}
			}
		}

		private void uFJkfcHHBbEhLcBtohmiBPsWSTOj(ref ghVaXMJBYQVankSHALdOAwQaFIx.KWhlJMqrfbvSYjBrsssVretqTb P_0)
		{
			if (!XUOkwXECnauQSqdUWvtDGoPEwwB)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = -1102665704;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1102665703)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				return;
			case 3:
				goto IL_0032;
			case 0:
				return;
			}
			goto IL_0008;
			IL_0032:
			YsmGEMdulhDdWAYugTcWaHOozjYx(P_0.HmcEZwKvOddGTHumCDKPFPMufOB);
			if (BJPDHydIRNniwIzhTROFdVjqueY != null)
			{
				BJPDHydIRNniwIzhTROFdVjqueY();
				num = -1102665703;
				goto IL_000d;
			}
		}

		private void JmkIbZmdEcvMmsoKZvmtNEFWjad(ref ghVaXMJBYQVankSHALdOAwQaFIx.KWhlJMqrfbvSYjBrsssVretqTb P_0)
		{
			bool xUOkwXECnauQSqdUWvtDGoPEwwB = XUOkwXECnauQSqdUWvtDGoPEwwB;
		}

		private void QuDlPAlQYMqAMfnwNusbZQKtAwq(int P_0, OpPHOecnOFEyUhUbCJxiojmzacz P_1, byte P_2, short P_3, float P_4)
		{
			TrPtHvDNhUzaBqlyMmTMOEWQxyO trPtHvDNhUzaBqlyMmTMOEWQxyO = xAlDSakduEshspYiMCsskFkAoke(P_0);
			while (true)
			{
				switch (-1238042442 ^ -1238042444)
				{
				case 0:
					continue;
				case 2:
					if (trPtHvDNhUzaBqlyMmTMOEWQxyO == null)
					{
						return;
					}
					break;
				}
				break;
			}
			trPtHvDNhUzaBqlyMmTMOEWQxyO.zxLhCcrlwKIIJANOaByFjYpjSot(P_1, P_2, P_3, P_4);
		}

		private void TrzrpJeiIvAwupdueYOydmTfkQF(int P_0, OpPHOecnOFEyUhUbCJxiojmzacz P_1, byte P_2, short P_3, float P_4)
		{
			jcXazxtpglhNkCEyvOXbwbgAELMb jcXazxtpglhNkCEyvOXbwbgAELMb2 = pgEyPRddMcfWHZAALoCbJyeffVa(P_0);
			while (true)
			{
				int num = 888412881;
				while (true)
				{
					switch (num ^ 0x34F41AD3)
					{
					case 0:
						break;
					case 2:
					{
						int num2;
						if (jcXazxtpglhNkCEyvOXbwbgAELMb2 != null)
						{
							num = 888412880;
							num2 = num;
						}
						else
						{
							num = 888412882;
							num2 = num;
						}
						continue;
					}
					case 1:
						return;
					default:
						jcXazxtpglhNkCEyvOXbwbgAELMb2.zxLhCcrlwKIIJANOaByFjYpjSot(P_1, P_2, P_3, P_4);
						return;
					}
					break;
				}
			}
		}

		private void fSLcqqbyjVLjGtUoMfBAkNCTJng()
		{
			string[] array = iCyHxnBeqvNPzzfjKifRbaNQHYRA.TgGvNRFWCmGcSmfeSNpiCayhugw();
			int num2 = default(int);
			while (true)
			{
				int num = -80012479;
				while (true)
				{
					switch (num ^ -80012476)
					{
					case 9:
						break;
					default:
						return;
					case 5:
					{
						int num6;
						if (array != null)
						{
							num = -80012466;
							num6 = num;
						}
						else
						{
							num = -80012473;
							num6 = num;
						}
						continue;
					}
					case 4:
						num = -80012474;
						continue;
					case 3:
						return;
					case 1:
						if (!string.IsNullOrEmpty(array[num2]))
						{
							int num4;
							if (array[num2].Length > 32)
							{
								num = -80012478;
								num4 = num;
							}
							else
							{
								num = -80012476;
								num4 = num;
							}
							continue;
						}
						goto case 0;
					case 2:
					{
						int num5;
						if (num2 >= array.Length)
						{
							num = -80012468;
							num5 = num;
						}
						else
						{
							num = -80012475;
							num5 = num;
						}
						continue;
					}
					case 10:
						num2 = 0;
						num = -80012480;
						continue;
					case 0:
						num2++;
						num = -80012474;
						continue;
					case 6:
					{
						int num3;
						if (!(ghVaXMJBYQVankSHALdOAwQaFIx.wUPhRSYKPeKauUvXNagVBkZVhcD(new Guid(array[num2].Substring(0, 32))) != string.Empty))
						{
							num = -80012477;
							num3 = num;
						}
						else
						{
							num = -80012476;
							num3 = num;
						}
						continue;
					}
					case 7:
						ghVaXMJBYQVankSHALdOAwQaFIx.RCfFMcizuBavUCCqETUHwWHDUsPd(array[num2]);
						num = -80012476;
						continue;
					case 8:
						return;
					}
					break;
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~SDL2InputSource()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (QQqHByfwytAJSuMZiCPjJlZYHKG)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!disposing)
				{
					num = -1904223990;
					num2 = num;
				}
				else
				{
					num = -1904223992;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1904223991)
					{
					case 4:
						num = -1904223989;
						continue;
					case 5:
						RpaHVHraDlkWfxSvBjfvSIHNou();
						num = -1904223990;
						continue;
					case 3:
						ghVaXMJBYQVankSHALdOAwQaFIx.XxEFWoYxRNGJUrNcmkrRpmhCzPZ();
						uvRIxvvRCxrfpiSXpAlvYqJtnEz = false;
						num = -1904223991;
						continue;
					case 2:
						break;
					case 1:
						if (TcocALcOGpBgAzoCUAHMLmGSFlSk != null)
						{
							TcocALcOGpBgAzoCUAHMLmGSFlSk.Dispose();
							num = -1904223988;
							continue;
						}
						goto case 5;
					default:
						QQqHByfwytAJSuMZiCPjJlZYHKG = true;
						return;
					}
					break;
				}
			}
		}
	}
}
