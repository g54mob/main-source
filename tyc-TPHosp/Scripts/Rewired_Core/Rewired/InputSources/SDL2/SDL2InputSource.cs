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
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class SDL2InputSource : IDisposable, IInputSource
	{
		public delegate void uVmgFYYFQjztmevHwwqxNkJhiduI(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void RlJwPvGeRtbuPCixYtChsIcZhhXe(int joystickIndex);

		public delegate void XJMgROGbPjSuRJlDMiWJiizNhsqi(int joystickId);

		public delegate void txNVUOVfKoNqmVKJwoYsMFiqSk(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int nyjDAbzfBFDifIamLqeqzXSqCuc = 32;

		private bool rTBZChsWvIMJDvQUVMrHNOniKIa;

		private bool iODHYbsGKMLPjkeomNdBalSJfGf;

		private bool JVFQwLOrbFHJoUHgbzVjTHEeAPd;

		private bool qFuapJVYWeknrVjEMYqXTUbYADM;

		private bool XrAXpRFFCZWxSkTUXpVlgetwinP;

		private ADictionary<int, miYPRdzpNwBIJFioiKeZgxqNyJM> GpKTUjLMGVeIHJzINAjLhtehdVC;

		private ADictionary<int, YMYWVPDduFAwBdGdBVHfUOQZhjkq> iPmDafVwesaQYEJvZCsibIshjfLL;

		private BiWWxqvSWmGXOmGGsphCczktuxZ.YFqtwNGUUoEKXCqJcbwBvogYIBuF JtfYTUUutlMBGXGHIPuiHIWlbpG;

		private NativeBuffer kXhvsrCOOJdRrvVLyZXEdQuVMBe;

		private Action maEPdrTSQzoCHGkcDALYNtjhwEI;

		private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

		public bool initialized => XrAXpRFFCZWxSkTUXpVlgetwinP;

		private event Action _DeviceChangedEvent
		{
			add
			{
				Action action = maEPdrTSQzoCHGkcDALYNtjhwEI;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref maEPdrTSQzoCHGkcDALYNtjhwEI, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = maEPdrTSQzoCHGkcDALYNtjhwEI;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref maEPdrTSQzoCHGkcDALYNtjhwEI, value2, action2);
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

		public SDL2InputSource(UpdateLoopSetting updateLoop, bool handleJoysticks, bool handleGamepads, bool handleUnifiedMouse, bool handleUnifiedKeyboard)
		{
			rTBZChsWvIMJDvQUVMrHNOniKIa = handleJoysticks;
			iODHYbsGKMLPjkeomNdBalSJfGf = handleGamepads;
			JVFQwLOrbFHJoUHgbzVjTHEeAPd = handleUnifiedMouse;
			qFuapJVYWeknrVjEMYqXTUbYADM = handleUnifiedKeyboard;
			GpKTUjLMGVeIHJzINAjLhtehdVC = new ADictionary<int, miYPRdzpNwBIJFioiKeZgxqNyJM>();
			iPmDafVwesaQYEJvZCsibIshjfLL = new ADictionary<int, YMYWVPDduFAwBdGdBVHfUOQZhjkq>();
			int num = ((!UnityTools.isEditor || UnityTools.editorPlatform != EditorPlatform.OSX) ? 29184 : 25088);
			try
			{
				BiWWxqvSWmGXOmGGsphCczktuxZ.kAAhDJLXPgEyHPRiWNtoDvhWaEf(UnityTools.effectivePlatform);
				if (BiWWxqvSWmGXOmGGsphCczktuxZ.ssCGEcMNNYoNEJPlyqtwLRtvzio((uint)num) < 0)
				{
					throw new Exception("Failed initialize SDL2!");
				}
				XrAXpRFFCZWxSkTUXpVlgetwinP = true;
				if (handleGamepads)
				{
					YxIXCQJupjGUhlvbejJIWkiAPVE();
				}
				UElFeSnzKLCZXzVhxrIwydUXFbt();
				kXhvsrCOOJdRrvVLyZXEdQuVMBe = new NativeBuffer(56);
			}
			catch
			{
				XrAXpRFFCZWxSkTUXpVlgetwinP = false;
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
			_ = XrAXpRFFCZWxSkTUXpVlgetwinP;
		}

		public void UpdateDevices(UpdateLoopType updateLoop)
		{
			if (XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				DEQHmZMXsSmmgsznzOdSmXxuBNb();
			}
		}

		public void UpdateFinished()
		{
			_ = XrAXpRFFCZWxSkTUXpVlgetwinP;
		}

		public IList<T> GetJoysticks<T>() where T : class
		{
			if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				return null;
			}
			List<foibGJXqBDBdLqGLpNATeBHsIxT> list = new List<foibGJXqBDBdLqGLpNATeBHsIxT>();
			if (rTBZChsWvIMJDvQUVMrHNOniKIa)
			{
				foreach (KeyValuePair<int, miYPRdzpNwBIJFioiKeZgxqNyJM> item in GpKTUjLMGVeIHJzINAjLhtehdVC)
				{
					miYPRdzpNwBIJFioiKeZgxqNyJM value = item.Value;
					if (value.IsValid)
					{
						list.Add(item.Value);
					}
				}
			}
			if (iODHYbsGKMLPjkeomNdBalSJfGf)
			{
				foreach (KeyValuePair<int, YMYWVPDduFAwBdGdBVHfUOQZhjkq> item2 in iPmDafVwesaQYEJvZCsibIshjfLL)
				{
					YMYWVPDduFAwBdGdBVHfUOQZhjkq value2 = item2.Value;
					if (value2.IsValid)
					{
						list.Add(value2);
					}
				}
			}
			return list as IList<T>;
		}

		private int wLJjaQElxaeqyjjUzaKHTLDYSZmo()
		{
			if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				return 0;
			}
			return Math.Min(BiWWxqvSWmGXOmGGsphCczktuxZ.UFgRPPLFrTgtmJHHRckgUYCjxCr(), 32);
		}

		private int aIctXajACuGCLgOAqxfyLvzgLvj()
		{
			if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				return 0;
			}
			int num = wLJjaQElxaeqyjjUzaKHTLDYSZmo();
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				if (!BiWWxqvSWmGXOmGGsphCczktuxZ.fxeDAJkfLgXGETqpGLwKcJNigDpA(i))
				{
					num2++;
				}
			}
			return num2;
		}

		private miYPRdzpNwBIJFioiKeZgxqNyJM BgHPaVmtWjjcfncCAZlKciEddWe(int P_0)
		{
			IntPtr intPtr = BiWWxqvSWmGXOmGGsphCczktuxZ.EvKcFuuGJNcjOJVmagWtomzjLZg(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			vKXepeHBBNWxQbCMEHitIcgRiAlb vKXepeHBBNWxQbCMEHitIcgRiAlb2 = new vKXepeHBBNWxQbCMEHitIcgRiAlb(intPtr);
			HLdBxKWeCCnyYemLsKrebKcAXOS hLdBxKWeCCnyYemLsKrebKcAXOS = SOBCMekpitgXBTsswaVPDaBtARZY(P_0, vKXepeHBBNWxQbCMEHitIcgRiAlb2);
			if (hLdBxKWeCCnyYemLsKrebKcAXOS == null)
			{
				BiWWxqvSWmGXOmGGsphCczktuxZ.VWeogUlnoUvJwzMEGtbMyWQxGzt(intPtr);
				return null;
			}
			return new miYPRdzpNwBIJFioiKeZgxqNyJM(vKXepeHBBNWxQbCMEHitIcgRiAlb2, hLdBxKWeCCnyYemLsKrebKcAXOS);
		}

		private YMYWVPDduFAwBdGdBVHfUOQZhjkq nMgXZzefvmMfytkEBMrwYaVfjVx(int P_0)
		{
			IntPtr intPtr = BiWWxqvSWmGXOmGGsphCczktuxZ.HNkwQKbHfyLHrOIEbcdozKqpXmY(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			ulgNYPRNtBfPsQxIxuFHtvwjPPk ulgNYPRNtBfPsQxIxuFHtvwjPPk2 = new ulgNYPRNtBfPsQxIxuFHtvwjPPk(intPtr);
			HLdBxKWeCCnyYemLsKrebKcAXOS hLdBxKWeCCnyYemLsKrebKcAXOS = MIolrIiVHHaOmqCwLcBCrdwBddx(P_0, ulgNYPRNtBfPsQxIxuFHtvwjPPk2);
			if (hLdBxKWeCCnyYemLsKrebKcAXOS == null)
			{
				return null;
			}
			if (!hLdBxKWeCCnyYemLsKrebKcAXOS.nwuFkwuKZJNUmRNBHlHkaVmWisU)
			{
				BiWWxqvSWmGXOmGGsphCczktuxZ.XhAhNOOzwxItKjShAMaInaHIHAbI(intPtr);
				return null;
			}
			hLdBxKWeCCnyYemLsKrebKcAXOS.AvyftLzUyJglwYQfpfUwBlMFDvlF = BiWWxqvSWmGXOmGGsphCczktuxZ.jEfAVxFgxaxWaSFPcQbypMlFHnZh(ulgNYPRNtBfPsQxIxuFHtvwjPPk2);
			return new YMYWVPDduFAwBdGdBVHfUOQZhjkq(ulgNYPRNtBfPsQxIxuFHtvwjPPk2, hLdBxKWeCCnyYemLsKrebKcAXOS);
		}

		private HLdBxKWeCCnyYemLsKrebKcAXOS SOBCMekpitgXBTsswaVPDaBtARZY(int P_0, vKXepeHBBNWxQbCMEHitIcgRiAlb P_1)
		{
			if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
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
			HLdBxKWeCCnyYemLsKrebKcAXOS hLdBxKWeCCnyYemLsKrebKcAXOS = new HLdBxKWeCCnyYemLsKrebKcAXOS();
			hLdBxKWeCCnyYemLsKrebKcAXOS.uiOHwBrYNOLBuZUwvPRpKAvvNnQ = P_0;
			hLdBxKWeCCnyYemLsKrebKcAXOS.OxaYhfaGlOIumOWmOozrcdXdBYi = BiWWxqvSWmGXOmGGsphCczktuxZ.qTxdbAnqVuDLoHOcPUaLLEHFyAL(P_1);
			hLdBxKWeCCnyYemLsKrebKcAXOS.nwuFkwuKZJNUmRNBHlHkaVmWisU = BiWWxqvSWmGXOmGGsphCczktuxZ.fxeDAJkfLgXGETqpGLwKcJNigDpA(P_0);
			hLdBxKWeCCnyYemLsKrebKcAXOS.smokGOBqcHhadIuTGoOisYEsZev = BiWWxqvSWmGXOmGGsphCczktuxZ.epOLvbcvrpGweTCjnDlxIutmstn(P_1);
			hLdBxKWeCCnyYemLsKrebKcAXOS.oHcUxJjAVizMmWpVgzoSjEmmGSV = BiWWxqvSWmGXOmGGsphCczktuxZ.QsxdOTqVVYAuOVqszUpAoWKHCla(P_1);
			hLdBxKWeCCnyYemLsKrebKcAXOS.oMiTtujRXgajflzsMflJRQlODId = BiWWxqvSWmGXOmGGsphCczktuxZ.IkcaFVAQsLZckJRlIqvkliyeDti(P_0);
			hLdBxKWeCCnyYemLsKrebKcAXOS.CtHmgLQvreiWMWnBZZLsTLZpuCY = BiWWxqvSWmGXOmGGsphCczktuxZ.inkvGbfsgGiZWOiKAjvUsMPrKsv(P_1);
			hLdBxKWeCCnyYemLsKrebKcAXOS.JDyNNdOScJLywOHcbmcaJdgZeIE = BiWWxqvSWmGXOmGGsphCczktuxZ.CqaTJpfLXrWckutuyqVBTRpypdq(P_1);
			hLdBxKWeCCnyYemLsKrebKcAXOS.ujudIdEbcBxpOOEDEHDZQOoRtUi = BiWWxqvSWmGXOmGGsphCczktuxZ.OAiWjhFgBWJHJrcZVPkikHAgxmp(P_1);
			hLdBxKWeCCnyYemLsKrebKcAXOS.quIzUGyDpRHLEYNLWYPNqooevEE = BiWWxqvSWmGXOmGGsphCczktuxZ.sDBDPrHZxQHdWaMmdncYVjDKqcas(P_1);
			return hLdBxKWeCCnyYemLsKrebKcAXOS;
		}

		private HLdBxKWeCCnyYemLsKrebKcAXOS MIolrIiVHHaOmqCwLcBCrdwBddx(int P_0, ulgNYPRNtBfPsQxIxuFHtvwjPPk P_1)
		{
			if (P_1 == null || !P_1.IsValid)
			{
				return null;
			}
			vKXepeHBBNWxQbCMEHitIcgRiAlb vKXepeHBBNWxQbCMEHitIcgRiAlb2 = new vKXepeHBBNWxQbCMEHitIcgRiAlb(BiWWxqvSWmGXOmGGsphCczktuxZ.TQNHrgBfEjlkuulPCdXLfaQxtFL(P_1));
			if (!vKXepeHBBNWxQbCMEHitIcgRiAlb2.IsValid)
			{
				return null;
			}
			return SOBCMekpitgXBTsswaVPDaBtARZY(P_0, vKXepeHBBNWxQbCMEHitIcgRiAlb2);
		}

		private void UElFeSnzKLCZXzVhxrIwydUXFbt()
		{
			for (int i = 0; i < wLJjaQElxaeqyjjUzaKHTLDYSZmo(); i++)
			{
				if (rTBZChsWvIMJDvQUVMrHNOniKIa)
				{
					ByLRMWSEaQYOtQxguVzbYinZLhi(i);
				}
				if (iODHYbsGKMLPjkeomNdBalSJfGf)
				{
					HvVKJCPAIuOLtmOtUIQsDNVnBKxk(i);
				}
			}
		}

		private void cronnhtounSFvnJVBMblZocOjSG()
		{
			if (iODHYbsGKMLPjkeomNdBalSJfGf)
			{
				foreach (KeyValuePair<int, YMYWVPDduFAwBdGdBVHfUOQZhjkq> item in iPmDafVwesaQYEJvZCsibIshjfLL)
				{
					YMYWVPDduFAwBdGdBVHfUOQZhjkq value = item.Value;
					value.zUvaQcfOtGUqlqKAxIsVhsqxVhqp();
					value.Dispose();
				}
				iPmDafVwesaQYEJvZCsibIshjfLL.Clear();
			}
			if (!rTBZChsWvIMJDvQUVMrHNOniKIa)
			{
				return;
			}
			foreach (KeyValuePair<int, miYPRdzpNwBIJFioiKeZgxqNyJM> item2 in GpKTUjLMGVeIHJzINAjLhtehdVC)
			{
				miYPRdzpNwBIJFioiKeZgxqNyJM value2 = item2.Value;
				value2.zUvaQcfOtGUqlqKAxIsVhsqxVhqp();
				value2.Dispose();
			}
			GpKTUjLMGVeIHJzINAjLhtehdVC.Clear();
		}

		private bool ByLRMWSEaQYOtQxguVzbYinZLhi(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (iODHYbsGKMLPjkeomNdBalSJfGf && BiWWxqvSWmGXOmGGsphCczktuxZ.fxeDAJkfLgXGETqpGLwKcJNigDpA(P_0))
			{
				return false;
			}
			miYPRdzpNwBIJFioiKeZgxqNyJM miYPRdzpNwBIJFioiKeZgxqNyJM2 = BgHPaVmtWjjcfncCAZlKciEddWe(P_0);
			if (miYPRdzpNwBIJFioiKeZgxqNyJM2 == null)
			{
				return false;
			}
			int lJXEHEIoXwILvMHVRPupoRnYJuSW = miYPRdzpNwBIJFioiKeZgxqNyJM2.LJXEHEIoXwILvMHVRPupoRnYJuSW;
			if (GpKTUjLMGVeIHJzINAjLhtehdVC.ContainsKey(lJXEHEIoXwILvMHVRPupoRnYJuSW))
			{
				GpKTUjLMGVeIHJzINAjLhtehdVC[lJXEHEIoXwILvMHVRPupoRnYJuSW].zUvaQcfOtGUqlqKAxIsVhsqxVhqp();
				GpKTUjLMGVeIHJzINAjLhtehdVC[lJXEHEIoXwILvMHVRPupoRnYJuSW] = miYPRdzpNwBIJFioiKeZgxqNyJM2;
			}
			else
			{
				GpKTUjLMGVeIHJzINAjLhtehdVC.Add(lJXEHEIoXwILvMHVRPupoRnYJuSW, miYPRdzpNwBIJFioiKeZgxqNyJM2);
			}
			miYPRdzpNwBIJFioiKeZgxqNyJM2.EJpmrTgGvrhKjJnkpXbomYBpQTQ();
			return true;
		}

		private void nwaJKAsevjXsebhXFWcqRNNGQia(int P_0)
		{
			if (GpKTUjLMGVeIHJzINAjLhtehdVC.ContainsKey(P_0))
			{
				GpKTUjLMGVeIHJzINAjLhtehdVC[P_0].zUvaQcfOtGUqlqKAxIsVhsqxVhqp();
				GpKTUjLMGVeIHJzINAjLhtehdVC.Remove(P_0);
			}
		}

		private bool HvVKJCPAIuOLtmOtUIQsDNVnBKxk(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (!BiWWxqvSWmGXOmGGsphCczktuxZ.fxeDAJkfLgXGETqpGLwKcJNigDpA(P_0))
			{
				return false;
			}
			YMYWVPDduFAwBdGdBVHfUOQZhjkq yMYWVPDduFAwBdGdBVHfUOQZhjkq = nMgXZzefvmMfytkEBMrwYaVfjVx(P_0);
			if (yMYWVPDduFAwBdGdBVHfUOQZhjkq == null)
			{
				return false;
			}
			int lJXEHEIoXwILvMHVRPupoRnYJuSW = yMYWVPDduFAwBdGdBVHfUOQZhjkq.LJXEHEIoXwILvMHVRPupoRnYJuSW;
			if (iPmDafVwesaQYEJvZCsibIshjfLL.ContainsKey(lJXEHEIoXwILvMHVRPupoRnYJuSW))
			{
				iPmDafVwesaQYEJvZCsibIshjfLL[lJXEHEIoXwILvMHVRPupoRnYJuSW].zUvaQcfOtGUqlqKAxIsVhsqxVhqp();
				iPmDafVwesaQYEJvZCsibIshjfLL[lJXEHEIoXwILvMHVRPupoRnYJuSW] = yMYWVPDduFAwBdGdBVHfUOQZhjkq;
			}
			else
			{
				iPmDafVwesaQYEJvZCsibIshjfLL.Add(lJXEHEIoXwILvMHVRPupoRnYJuSW, yMYWVPDduFAwBdGdBVHfUOQZhjkq);
			}
			yMYWVPDduFAwBdGdBVHfUOQZhjkq.EJpmrTgGvrhKjJnkpXbomYBpQTQ();
			return true;
		}

		private void zUzkYoEsfPCPjSFjvynIzsywRWq(int P_0)
		{
			if (iPmDafVwesaQYEJvZCsibIshjfLL.ContainsKey(P_0))
			{
				iPmDafVwesaQYEJvZCsibIshjfLL[P_0].zUvaQcfOtGUqlqKAxIsVhsqxVhqp();
				iPmDafVwesaQYEJvZCsibIshjfLL.Remove(P_0);
			}
		}

		private miYPRdzpNwBIJFioiKeZgxqNyJM CwaHpAMAkclBRrKdgBEgKvCVItS(int P_0)
		{
			if (!GpKTUjLMGVeIHJzINAjLhtehdVC.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private YMYWVPDduFAwBdGdBVHfUOQZhjkq GVLTEbVGKKptgNbFbMGzzZOmKlS(int P_0)
		{
			if (!iPmDafVwesaQYEJvZCsibIshjfLL.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private void DEQHmZMXsSmmgsznzOdSmXxuBNb()
		{
			while (BiWWxqvSWmGXOmGGsphCczktuxZ.GxQQzMVmOpSINMwiGqrJsYLlofG(kXhvsrCOOJdRrvVLyZXEdQuVMBe) != 0)
			{
				JtfYTUUutlMBGXGHIPuiHIWlbpG.VSPhKBECuSachfLatpmDPnvkFae(kXhvsrCOOJdRrvVLyZXEdQuVMBe);
				BiWWxqvSWmGXOmGGsphCczktuxZ.yGCPcYgYZYDvHzzPeoFHUaxDefK nKrRavQzBncjnBNomJbbjeXhgCD = JtfYTUUutlMBGXGHIPuiHIWlbpG.NKrRavQzBncjnBNomJbbjeXhgCD;
				double realTime = ReInput.realTime;
				switch (nKrRavQzBncjnBNomJbbjeXhgCD)
				{
				case BiWWxqvSWmGXOmGGsphCczktuxZ.yGCPcYgYZYDvHzzPeoFHUaxDefK.MYmYLjFRECNlrRaHffwQMIdQfhqe:
					fDxIuYAhFeshkuNdwsYPuwrRoZk(ref JtfYTUUutlMBGXGHIPuiHIWlbpG.JUguBUpCzoMSsrobiFdHcxRsTlLq, realTime);
					break;
				case BiWWxqvSWmGXOmGGsphCczktuxZ.yGCPcYgYZYDvHzzPeoFHUaxDefK.casSWHiuyicUTCNvLBkOxhrUXgs:
				case BiWWxqvSWmGXOmGGsphCczktuxZ.yGCPcYgYZYDvHzzPeoFHUaxDefK.GlUpmudTLpngowZnnexDOZkruIN:
					YHUFbBHqcKBscbBBPIwazrljlwTN(ref JtfYTUUutlMBGXGHIPuiHIWlbpG.jGvTYReHQMJkYrWjsHNzkAcjxBb, realTime);
					break;
				case BiWWxqvSWmGXOmGGsphCczktuxZ.yGCPcYgYZYDvHzzPeoFHUaxDefK.TavPuGYXJqTFgtxiZmfiocIBEjiJ:
					wxdDwdKXCGhABsJFbblvdppXrHFa(ref JtfYTUUutlMBGXGHIPuiHIWlbpG.uUClaiLDttXXrJACFENcGuzoktCe);
					break;
				case BiWWxqvSWmGXOmGGsphCczktuxZ.yGCPcYgYZYDvHzzPeoFHUaxDefK.MPEcrQcdPfLNiooyRpQVuMOqNSfH:
					pUywaBrHGWHeQJXBJmJGirfLlNwi(ref JtfYTUUutlMBGXGHIPuiHIWlbpG.laTQOrfDRQwCTfuXonRSNXALeTZ, realTime);
					break;
				case BiWWxqvSWmGXOmGGsphCczktuxZ.yGCPcYgYZYDvHzzPeoFHUaxDefK.VhGbIeORUskoDZLQBpsFWLxWFTF:
				case BiWWxqvSWmGXOmGGsphCczktuxZ.yGCPcYgYZYDvHzzPeoFHUaxDefK.sdARyxKqYuLCBBTLpYroBiknjfl:
					lGHDabwxlozwyPzjMOVbMbsbmXV(ref JtfYTUUutlMBGXGHIPuiHIWlbpG.NagoqbRukeEJWCCdrOaOTaIuLux, realTime);
					break;
				case BiWWxqvSWmGXOmGGsphCczktuxZ.yGCPcYgYZYDvHzzPeoFHUaxDefK.kvAdugnmXkzmoaKmRoZximNWURR:
					YmNelsKWYwCtoAyIdQQCfmzGLCHf(ref JtfYTUUutlMBGXGHIPuiHIWlbpG.lXRpIRUbHHxoBzkaMUpTiNjDdObJ, realTime);
					break;
				case BiWWxqvSWmGXOmGGsphCczktuxZ.yGCPcYgYZYDvHzzPeoFHUaxDefK.piBojMTnVLERIcCcQEGOTBcJAMdm:
					EhUgIARWVtxTgWmBKGmpqGdQxAC(ref JtfYTUUutlMBGXGHIPuiHIWlbpG.dJiAgseGaJwiuqHgoClVTkmoYpM, realTime);
					break;
				case BiWWxqvSWmGXOmGGsphCczktuxZ.yGCPcYgYZYDvHzzPeoFHUaxDefK.BWIUpGarUQfzPztFtvqqniWceqnB:
					AkCWLkLTKTnqpeiNMbClMWQUxQP(ref JtfYTUUutlMBGXGHIPuiHIWlbpG.WFcNEVPctMEitIdPtHoyAiozVQgg);
					break;
				case BiWWxqvSWmGXOmGGsphCczktuxZ.yGCPcYgYZYDvHzzPeoFHUaxDefK.ktOoshqhhRoZmdotGJXLrlZrKnp:
					OvKpmWBUUbusCpNhZtyBtQENkbT(ref JtfYTUUutlMBGXGHIPuiHIWlbpG.WFcNEVPctMEitIdPtHoyAiozVQgg);
					break;
				case BiWWxqvSWmGXOmGGsphCczktuxZ.yGCPcYgYZYDvHzzPeoFHUaxDefK.hvxZMLHrgaYgpebbUjjfdrDUMNb:
					rjxEGNEgExsKyiLMeVYBBHoTDlkG(ref JtfYTUUutlMBGXGHIPuiHIWlbpG.uUClaiLDttXXrJACFENcGuzoktCe);
					break;
				case BiWWxqvSWmGXOmGGsphCczktuxZ.yGCPcYgYZYDvHzzPeoFHUaxDefK.EpBnoYsSwlJSeelsDPMfwnXpaRD:
					FrEVhOncDNWCyBakOduilnOFCtm(ref JtfYTUUutlMBGXGHIPuiHIWlbpG.uUClaiLDttXXrJACFENcGuzoktCe);
					break;
				}
			}
		}

		private void pUywaBrHGWHeQJXBJmJGirfLlNwi(ref BiWWxqvSWmGXOmGGsphCczktuxZ.QYOCXcbXYyuXOKqREPkgSFXdHowC P_0, double P_1)
		{
			if (rTBZChsWvIMJDvQUVMrHNOniKIa)
			{
				nFQGLaIHYsOZpltjnBgtZtiasqAh(P_0.kMttnGsAhTMtwJvbsTFZvaszHRd, pWCuWOCOMjTBfvspqDFuAKrmWrL.ZEpADHaQXaPbbdiPXFeEtXVONrIe, P_0.vfmfGOfhyxYSRFIgAsmGIowjLLEp, P_0.HpxePuhaScltgSCBmgsrsCpjliL, P_1);
			}
		}

		private void lGHDabwxlozwyPzjMOVbMbsbmXV(ref BiWWxqvSWmGXOmGGsphCczktuxZ.gWAUASsPPdcYNafyvuknOxzjeLHA P_0, double P_1)
		{
			if (rTBZChsWvIMJDvQUVMrHNOniKIa)
			{
				nFQGLaIHYsOZpltjnBgtZtiasqAh(P_0.kMttnGsAhTMtwJvbsTFZvaszHRd, pWCuWOCOMjTBfvspqDFuAKrmWrL.MSkOFxndGdlYTXhRRInvAJPFWqV, P_0.LXUnVmysfgqdkiGnDpvQJSzNarE, P_0.hldjmLLhRFbldypJyNprJPlbZSg, P_1);
			}
		}

		private void YmNelsKWYwCtoAyIdQQCfmzGLCHf(ref BiWWxqvSWmGXOmGGsphCczktuxZ.OszPfQamHKkHNicvouikJZOObSX P_0, double P_1)
		{
			if (rTBZChsWvIMJDvQUVMrHNOniKIa)
			{
				nFQGLaIHYsOZpltjnBgtZtiasqAh(P_0.kMttnGsAhTMtwJvbsTFZvaszHRd, pWCuWOCOMjTBfvspqDFuAKrmWrL.rKdSFgrHJoOfrtyiXMxbskeUTru, P_0.KOXXZxTxQEPoSroKpFGjRglvEIjD, P_0.HpxePuhaScltgSCBmgsrsCpjliL, P_1);
			}
		}

		private void EhUgIARWVtxTgWmBKGmpqGdQxAC(ref BiWWxqvSWmGXOmGGsphCczktuxZ.VMVkbUIPFcjObaOftNzHgFXbFDI P_0, double P_1)
		{
			_ = rTBZChsWvIMJDvQUVMrHNOniKIa;
		}

		private void AkCWLkLTKTnqpeiNMbClMWQUxQP(ref BiWWxqvSWmGXOmGGsphCczktuxZ.rRlEfJmTeoKXxSQpmhCSudULaDk P_0)
		{
			if (rTBZChsWvIMJDvQUVMrHNOniKIa)
			{
				ByLRMWSEaQYOtQxguVzbYinZLhi(P_0.kMttnGsAhTMtwJvbsTFZvaszHRd);
				if (maEPdrTSQzoCHGkcDALYNtjhwEI != null)
				{
					maEPdrTSQzoCHGkcDALYNtjhwEI();
				}
			}
		}

		private void OvKpmWBUUbusCpNhZtyBtQENkbT(ref BiWWxqvSWmGXOmGGsphCczktuxZ.rRlEfJmTeoKXxSQpmhCSudULaDk P_0)
		{
			if (rTBZChsWvIMJDvQUVMrHNOniKIa)
			{
				nwaJKAsevjXsebhXFWcqRNNGQia(P_0.kMttnGsAhTMtwJvbsTFZvaszHRd);
				if (maEPdrTSQzoCHGkcDALYNtjhwEI != null)
				{
					maEPdrTSQzoCHGkcDALYNtjhwEI();
				}
			}
		}

		private void fDxIuYAhFeshkuNdwsYPuwrRoZk(ref BiWWxqvSWmGXOmGGsphCczktuxZ.chmHmypnYpZkNYVtugjohomPDWL P_0, double P_1)
		{
			if (iODHYbsGKMLPjkeomNdBalSJfGf)
			{
				byte vfmfGOfhyxYSRFIgAsmGIowjLLEp = P_0.vfmfGOfhyxYSRFIgAsmGIowjLLEp;
				if (vfmfGOfhyxYSRFIgAsmGIowjLLEp != 6)
				{
					gVqKDfMeOFdrFvxlQFMsGTvuqAjc(P_0.kMttnGsAhTMtwJvbsTFZvaszHRd, pWCuWOCOMjTBfvspqDFuAKrmWrL.ZEpADHaQXaPbbdiPXFeEtXVONrIe, P_0.vfmfGOfhyxYSRFIgAsmGIowjLLEp, P_0.HpxePuhaScltgSCBmgsrsCpjliL, P_1);
				}
			}
		}

		private void YHUFbBHqcKBscbBBPIwazrljlwTN(ref BiWWxqvSWmGXOmGGsphCczktuxZ.iLbdGUbEBEiZeehEnALsOrvazRd P_0, double P_1)
		{
			if (iODHYbsGKMLPjkeomNdBalSJfGf)
			{
				byte lXUnVmysfgqdkiGnDpvQJSzNarE = P_0.LXUnVmysfgqdkiGnDpvQJSzNarE;
				if (lXUnVmysfgqdkiGnDpvQJSzNarE != 15)
				{
					gVqKDfMeOFdrFvxlQFMsGTvuqAjc(P_0.kMttnGsAhTMtwJvbsTFZvaszHRd, pWCuWOCOMjTBfvspqDFuAKrmWrL.MSkOFxndGdlYTXhRRInvAJPFWqV, P_0.LXUnVmysfgqdkiGnDpvQJSzNarE, P_0.hldjmLLhRFbldypJyNprJPlbZSg, P_1);
				}
			}
		}

		private void rjxEGNEgExsKyiLMeVYBBHoTDlkG(ref BiWWxqvSWmGXOmGGsphCczktuxZ.gtXcCWgJyjnlXbDkaQhaoWJcbVXS P_0)
		{
			if (iODHYbsGKMLPjkeomNdBalSJfGf)
			{
				HvVKJCPAIuOLtmOtUIQsDNVnBKxk(P_0.kMttnGsAhTMtwJvbsTFZvaszHRd);
				if (maEPdrTSQzoCHGkcDALYNtjhwEI != null)
				{
					maEPdrTSQzoCHGkcDALYNtjhwEI();
				}
			}
		}

		private void FrEVhOncDNWCyBakOduilnOFCtm(ref BiWWxqvSWmGXOmGGsphCczktuxZ.gtXcCWgJyjnlXbDkaQhaoWJcbVXS P_0)
		{
			if (iODHYbsGKMLPjkeomNdBalSJfGf)
			{
				zUzkYoEsfPCPjSFjvynIzsywRWq(P_0.kMttnGsAhTMtwJvbsTFZvaszHRd);
				if (maEPdrTSQzoCHGkcDALYNtjhwEI != null)
				{
					maEPdrTSQzoCHGkcDALYNtjhwEI();
				}
			}
		}

		private void wxdDwdKXCGhABsJFbblvdppXrHFa(ref BiWWxqvSWmGXOmGGsphCczktuxZ.gtXcCWgJyjnlXbDkaQhaoWJcbVXS P_0)
		{
			_ = iODHYbsGKMLPjkeomNdBalSJfGf;
		}

		private void nFQGLaIHYsOZpltjnBgtZtiasqAh(int P_0, pWCuWOCOMjTBfvspqDFuAKrmWrL P_1, byte P_2, short P_3, double P_4)
		{
			CwaHpAMAkclBRrKdgBEgKvCVItS(P_0)?.GcIuKOHgXujXqCTdAuwBBVguUoX(P_1, P_2, P_3, P_4);
		}

		private void gVqKDfMeOFdrFvxlQFMsGTvuqAjc(int P_0, pWCuWOCOMjTBfvspqDFuAKrmWrL P_1, byte P_2, short P_3, double P_4)
		{
			GVLTEbVGKKptgNbFbMGzzZOmKlS(P_0)?.GcIuKOHgXujXqCTdAuwBBVguUoX(P_1, P_2, P_3, P_4);
		}

		private void YxIXCQJupjGUhlvbejJIWkiAPVE()
		{
			string[] array = XGpHDNfhoVwTKrLcybXFIrjBawb.qgRlxdnACEEBvotlyavsoLMudSQ();
			if (array == null)
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]) && array[i].Length > 32 && !(BiWWxqvSWmGXOmGGsphCczktuxZ.HfYFPmwtPUbzHbWMdFmTovtSqLda(new Guid(array[i].Substring(0, 32))) != string.Empty))
				{
					BiWWxqvSWmGXOmGGsphCczktuxZ.mxqoIYJsajEmhIoztWZDkRnBENx(array[i]);
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
			if (jgbpvYJovPcfzmcAEJzdxdrBmcm)
			{
				return;
			}
			if (disposing)
			{
				if (kXhvsrCOOJdRrvVLyZXEdQuVMBe != null)
				{
					kXhvsrCOOJdRrvVLyZXEdQuVMBe.Dispose();
				}
				cronnhtounSFvnJVBMblZocOjSG();
			}
			BiWWxqvSWmGXOmGGsphCczktuxZ.gCRXtGilJfNblbxnMlaTPITHeHdB();
			XrAXpRFFCZWxSkTUXpVlgetwinP = false;
			jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
		}
	}
}
