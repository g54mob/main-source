using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.HID;
using Rewired.HID.Drivers;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class YkKIPPiCWZeAzAfNMTiDRgJXluDN : IDisposable, IInputSource
{
	private class lSAktsHdQgImZAEBfTGvitJGhA
	{
		public ushort FBgoHDDONaucfYfClsJQmgJRgl;

		public ushort FWQRxpNIbdqGOeuqmJHMPKVZrZs;

		public lSAktsHdQgImZAEBfTGvitJGhA(ushort usagePage, ushort usage)
		{
			FBgoHDDONaucfYfClsJQmgJRgl = usagePage;
			FWQRxpNIbdqGOeuqmJHMPKVZrZs = usage;
		}
	}

	internal class SQYxQCXyTaQaUetxSLvklCTicRF : IDisposable, OzVqfYeaMNEXzwFiuZOmGiQFiUf
	{
		public const int PPLCZxBNDppwRwkfOhLtHoQrRJTj = 255;

		private IntPtr oklegakhkrnLmGxLRjCTwtDQrIjC;

		private IntPtr FizVJdopVGpnhZEYbhRCJuEKmrcR;

		private BNbkHUFhjdAedbtJHojnbgVaVcMu voFbbLJDwLpwjmHycAkoCanlRhV;

		private readonly string zxJIAknObhysZdUkBlezisEjtCd;

		private readonly string htaMilNTPYUsZhoBbkevwTQQsLi;

		private readonly string xbEnskRsccmEptUTDiTZmJcjNsG;

		private readonly string TDSsDXrDcmOPWbTmgULNLRhBxfy;

		private readonly dzVhIZOTenKYAmfDrihEMTpdTgp SCkWaNzohrbOotDmDXZFqEAIohz;

		private readonly string XBTCCFufXjDQzBHhJvBmamdXyjA;

		private readonly int fKXYKMyyeLIhaxOOxyodYGTZinZ;

		private readonly int azoOCPNfubFPylKrEHhKMqzoBMQ;

		private readonly bool zQPvBbHEnslNongMYYSBubQdjPK;

		private readonly string ZkMpRkciOXNsLXSDBzriEMusxKS;

		private readonly bool pfWZoRZAPZcfnDAxucPxBkifuFIv;

		private readonly BNbkHUFhjdAedbtJHojnbgVaVcMu KwKWhKDOjmeUUiqEnjBSVVbRKvD;

		private readonly mdTgcjlxDwqQpMCDAGKoxqtMZzX[] YLiaHFofRHQvcRgQkHPAsSkGkNW;

		private readonly VnJBlCjBghUdCNDzwTDxPtAjFeic[] WBcEsjfDjOHNNdBlKZgPlqVpVJzb;

		private wLgsatiSRzspXBQkeKrpifqDJhM TfGistfWrlnHTavjWaOkLnKLVje;

		private wLgsatiSRzspXBQkeKrpifqDJhM OvkTUIfPSLBvUeNOUBIyxAdaSIJK;

		private BMCNTBcjsZQtxeCrqrsRAMjlkcH yjWpUQqKFViciEfBfeHVFkJAMLia;

		private QliZNXTTmYgTYEgrHvrzHtAqkKF GQTUuXbDlUhvXAkmlXYLsahcMvBf;

		[CompilerGenerated]
		private bool XIADmMgMZoRyxtcOeBcdSfyLJdx;

		public IntPtr Handle => FizVJdopVGpnhZEYbhRCJuEKmrcR;

		public bool IsOpen
		{
			[CompilerGenerated]
			get
			{
				return XIADmMgMZoRyxtcOeBcdSfyLJdx;
			}
			[CompilerGenerated]
			private set
			{
				XIADmMgMZoRyxtcOeBcdSfyLJdx = value;
			}
		}

		public bool IsConnected => true;

		public string Description => "";

		public BNbkHUFhjdAedbtJHojnbgVaVcMu Capabilities => voFbbLJDwLpwjmHycAkoCanlRhV;

		public dzVhIZOTenKYAmfDrihEMTpdTgp Attributes => SCkWaNzohrbOotDmDXZFqEAIohz;

		public string DevicePath => htaMilNTPYUsZhoBbkevwTQQsLi;

		public bool MonitorDeviceEvents
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public mdTgcjlxDwqQpMCDAGKoxqtMZzX[] ButtonCapabilities => YLiaHFofRHQvcRgQkHPAsSkGkNW;

		public VnJBlCjBghUdCNDzwTDxPtAjFeic[] ValueCapabilities => WBcEsjfDjOHNNdBlKZgPlqVpVJzb;

		public string DevicePathStripped => xbEnskRsccmEptUTDiTZmJcjNsG;

		public string InstanceId => TDSsDXrDcmOPWbTmgULNLRhBxfy;

		public string Manufacturer => XBTCCFufXjDQzBHhJvBmamdXyjA;

		public int HubId => fKXYKMyyeLIhaxOOxyodYGTZinZ;

		public int PortId => azoOCPNfubFPylKrEHhKMqzoBMQ;

		public bool IsBluetoothDevice => zQPvBbHEnslNongMYYSBubQdjPK;

		public string BluetoothDeviceName => ZkMpRkciOXNsLXSDBzriEMusxKS;

		public bool HasLocationInfo => false;

		public event BMCNTBcjsZQtxeCrqrsRAMjlkcH Inserted
		{
			add
			{
				BMCNTBcjsZQtxeCrqrsRAMjlkcH bMCNTBcjsZQtxeCrqrsRAMjlkcH = yjWpUQqKFViciEfBfeHVFkJAMLia;
				BMCNTBcjsZQtxeCrqrsRAMjlkcH bMCNTBcjsZQtxeCrqrsRAMjlkcH2;
				do
				{
					bMCNTBcjsZQtxeCrqrsRAMjlkcH2 = bMCNTBcjsZQtxeCrqrsRAMjlkcH;
					BMCNTBcjsZQtxeCrqrsRAMjlkcH value2 = (BMCNTBcjsZQtxeCrqrsRAMjlkcH)Delegate.Combine(bMCNTBcjsZQtxeCrqrsRAMjlkcH2, value);
					bMCNTBcjsZQtxeCrqrsRAMjlkcH = Interlocked.CompareExchange(ref yjWpUQqKFViciEfBfeHVFkJAMLia, value2, bMCNTBcjsZQtxeCrqrsRAMjlkcH2);
				}
				while ((object)bMCNTBcjsZQtxeCrqrsRAMjlkcH != bMCNTBcjsZQtxeCrqrsRAMjlkcH2);
			}
			remove
			{
				BMCNTBcjsZQtxeCrqrsRAMjlkcH bMCNTBcjsZQtxeCrqrsRAMjlkcH = yjWpUQqKFViciEfBfeHVFkJAMLia;
				BMCNTBcjsZQtxeCrqrsRAMjlkcH bMCNTBcjsZQtxeCrqrsRAMjlkcH2;
				do
				{
					bMCNTBcjsZQtxeCrqrsRAMjlkcH2 = bMCNTBcjsZQtxeCrqrsRAMjlkcH;
					BMCNTBcjsZQtxeCrqrsRAMjlkcH value2 = (BMCNTBcjsZQtxeCrqrsRAMjlkcH)Delegate.Remove(bMCNTBcjsZQtxeCrqrsRAMjlkcH2, value);
					bMCNTBcjsZQtxeCrqrsRAMjlkcH = Interlocked.CompareExchange(ref yjWpUQqKFViciEfBfeHVFkJAMLia, value2, bMCNTBcjsZQtxeCrqrsRAMjlkcH2);
				}
				while ((object)bMCNTBcjsZQtxeCrqrsRAMjlkcH != bMCNTBcjsZQtxeCrqrsRAMjlkcH2);
			}
		}

		public event QliZNXTTmYgTYEgrHvrzHtAqkKF Removed
		{
			add
			{
				QliZNXTTmYgTYEgrHvrzHtAqkKF qliZNXTTmYgTYEgrHvrzHtAqkKF = GQTUuXbDlUhvXAkmlXYLsahcMvBf;
				QliZNXTTmYgTYEgrHvrzHtAqkKF qliZNXTTmYgTYEgrHvrzHtAqkKF2;
				do
				{
					qliZNXTTmYgTYEgrHvrzHtAqkKF2 = qliZNXTTmYgTYEgrHvrzHtAqkKF;
					QliZNXTTmYgTYEgrHvrzHtAqkKF value2 = (QliZNXTTmYgTYEgrHvrzHtAqkKF)Delegate.Combine(qliZNXTTmYgTYEgrHvrzHtAqkKF2, value);
					qliZNXTTmYgTYEgrHvrzHtAqkKF = Interlocked.CompareExchange(ref GQTUuXbDlUhvXAkmlXYLsahcMvBf, value2, qliZNXTTmYgTYEgrHvrzHtAqkKF2);
				}
				while ((object)qliZNXTTmYgTYEgrHvrzHtAqkKF != qliZNXTTmYgTYEgrHvrzHtAqkKF2);
			}
			remove
			{
				QliZNXTTmYgTYEgrHvrzHtAqkKF qliZNXTTmYgTYEgrHvrzHtAqkKF = GQTUuXbDlUhvXAkmlXYLsahcMvBf;
				QliZNXTTmYgTYEgrHvrzHtAqkKF qliZNXTTmYgTYEgrHvrzHtAqkKF2;
				do
				{
					qliZNXTTmYgTYEgrHvrzHtAqkKF2 = qliZNXTTmYgTYEgrHvrzHtAqkKF;
					QliZNXTTmYgTYEgrHvrzHtAqkKF value2 = (QliZNXTTmYgTYEgrHvrzHtAqkKF)Delegate.Remove(qliZNXTTmYgTYEgrHvrzHtAqkKF2, value);
					qliZNXTTmYgTYEgrHvrzHtAqkKF = Interlocked.CompareExchange(ref GQTUuXbDlUhvXAkmlXYLsahcMvBf, value2, qliZNXTTmYgTYEgrHvrzHtAqkKF2);
				}
				while ((object)qliZNXTTmYgTYEgrHvrzHtAqkKF != qliZNXTTmYgTYEgrHvrzHtAqkKF2);
			}
		}

		public static SQYxQCXyTaQaUetxSLvklCTicRF wATWsQinaQgtyfhaGakrKFkTqfxU(IntPtr P_0, string P_1)
		{
			return new SQYxQCXyTaQaUetxSLvklCTicRF(P_0, P_1, P_1, "", "", 0, 0, isBluetoothDevice: false, "");
		}

		public SQYxQCXyTaQaUetxSLvklCTicRF(IntPtr rawInputDeviceHandle, string devicePath, string instanceId, string description, string manufacturer, int hubId, int portId, bool isBluetoothDevice, string bluetoothDeviceName)
		{
			oklegakhkrnLmGxLRjCTwtDQrIjC = rawInputDeviceHandle;
			try
			{
				htaMilNTPYUsZhoBbkevwTQQsLi = devicePath;
				xbEnskRsccmEptUTDiTZmJcjNsG = fTvFFMKHyahmXrAOzQxsmenVpjI.bAsiNcmvQWMiTuiNtHATkYhgXzTP(devicePath);
				TDSsDXrDcmOPWbTmgULNLRhBxfy = instanceId;
				zxJIAknObhysZdUkBlezisEjtCd = StringTools.SanitizeDeviceString(description);
				XBTCCFufXjDQzBHhJvBmamdXyjA = StringTools.SanitizeDeviceString(manufacturer);
				fKXYKMyyeLIhaxOOxyodYGTZinZ = hubId;
				azoOCPNfubFPylKrEHhKMqzoBMQ = portId;
				zQPvBbHEnslNongMYYSBubQdjPK = isBluetoothDevice;
				ZkMpRkciOXNsLXSDBzriEMusxKS = StringTools.SanitizeDeviceString(bluetoothDeviceName);
				if (!IsOpen)
				{
					pfWZoRZAPZcfnDAxucPxBkifuFIv = true;
					FizVJdopVGpnhZEYbhRCJuEKmrcR = rawInputDeviceHandle;
					IsOpen = true;
				}
				IntPtr fizVJdopVGpnhZEYbhRCJuEKmrcR = FizVJdopVGpnhZEYbhRCJuEKmrcR;
				voFbbLJDwLpwjmHycAkoCanlRhV = awBDVVAQrVojolizTQZQDabqRnX.scuEzsqVoZKOmYQarjmPrsFlSgv(fizVJdopVGpnhZEYbhRCJuEKmrcR);
				SCkWaNzohrbOotDmDXZFqEAIohz = awBDVVAQrVojolizTQZQDabqRnX.gOEXCrqArtlvSlmtgQbfmaCgEtE(fizVJdopVGpnhZEYbhRCJuEKmrcR);
				KwKWhKDOjmeUUiqEnjBSVVbRKvD = awBDVVAQrVojolizTQZQDabqRnX.scuEzsqVoZKOmYQarjmPrsFlSgv(fizVJdopVGpnhZEYbhRCJuEKmrcR);
				YLiaHFofRHQvcRgQkHPAsSkGkNW = awBDVVAQrVojolizTQZQDabqRnX.MEpETQgEzGnZDhERbAgrnHnPdBuG(fizVJdopVGpnhZEYbhRCJuEKmrcR, 0, KwKWhKDOjmeUUiqEnjBSVVbRKvD.NumberInputButtonCaps);
				WBcEsjfDjOHNNdBlKZgPlqVpVJzb = awBDVVAQrVojolizTQZQDabqRnX.ngOprxTXpEJvhNxdKfvVNqbxAug(fizVJdopVGpnhZEYbhRCJuEKmrcR, 0, KwKWhKDOjmeUUiqEnjBSVVbRKvD.NumberInputValueCaps);
				_ = SCkWaNzohrbOotDmDXZFqEAIohz;
				_ = KwKWhKDOjmeUUiqEnjBSVVbRKvD;
				_ = YLiaHFofRHQvcRgQkHPAsSkGkNW;
				_ = WBcEsjfDjOHNNdBlKZgPlqVpVJzb;
			}
			catch (Exception ex)
			{
				throw new Exception($"Error querying HID device \"{devicePath}\" at location {FizVJdopVGpnhZEYbhRCJuEKmrcR}.\nException Message: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
			}
			finally
			{
				try
				{
					WOLsmFNlIJeAQHmPXjSXWDEbbnA();
				}
				catch
				{
				}
			}
		}

		public void zFpTVuGwUUqyhvLbABufQdrgGKAA()
		{
			zFpTVuGwUUqyhvLbABufQdrgGKAA(wLgsatiSRzspXBQkeKrpifqDJhM.gnLHwEdBbfhRiUtWjjcmmKdeGsy, wLgsatiSRzspXBQkeKrpifqDJhM.gnLHwEdBbfhRiUtWjjcmmKdeGsy, rUSAwXbYObnIJBpUJPClFxhEcTAH.VsdksCukYWYYZgKCNnHZCjNeZgx);
		}

		void OzVqfYeaMNEXzwFiuZOmGiQFiUf.zFpTVuGwUUqyhvLbABufQdrgGKAA()
		{
			//ILSpy generated this explicit interface implementation from .override directive in zFpTVuGwUUqyhvLbABufQdrgGKAA
			this.zFpTVuGwUUqyhvLbABufQdrgGKAA();
		}

		public void zFpTVuGwUUqyhvLbABufQdrgGKAA(wLgsatiSRzspXBQkeKrpifqDJhM P_0, wLgsatiSRzspXBQkeKrpifqDJhM P_1, rUSAwXbYObnIJBpUJPClFxhEcTAH P_2)
		{
			if (pfWZoRZAPZcfnDAxucPxBkifuFIv)
			{
				IsOpen = true;
				return;
			}
			TfGistfWrlnHTavjWaOkLnKLVje = P_0;
			OvkTUIfPSLBvUeNOUBIyxAdaSIJK = P_1;
			try
			{
				FizVJdopVGpnhZEYbhRCJuEKmrcR = awBDVVAQrVojolizTQZQDabqRnX.HKjJtpjhmoeUfTKHQqKHasPJhgi(htaMilNTPYUsZhoBbkevwTQQsLi, P_0, 2147483648u, P_2);
			}
			catch (Exception innerException)
			{
				IsOpen = false;
				throw new Exception("Error opening HID device.", innerException);
			}
			IsOpen = FizVJdopVGpnhZEYbhRCJuEKmrcR.ToInt32() != -1;
			_ = IsOpen;
		}

		void OzVqfYeaMNEXzwFiuZOmGiQFiUf.zFpTVuGwUUqyhvLbABufQdrgGKAA(wLgsatiSRzspXBQkeKrpifqDJhM P_0, wLgsatiSRzspXBQkeKrpifqDJhM P_1, rUSAwXbYObnIJBpUJPClFxhEcTAH P_2)
		{
			//ILSpy generated this explicit interface implementation from .override directive in zFpTVuGwUUqyhvLbABufQdrgGKAA
			this.zFpTVuGwUUqyhvLbABufQdrgGKAA(P_0, P_1, P_2);
		}

		public void WOLsmFNlIJeAQHmPXjSXWDEbbnA()
		{
			if (pfWZoRZAPZcfnDAxucPxBkifuFIv)
			{
				IsOpen = false;
				return;
			}
			while (IsOpen)
			{
				while (true)
				{
					int num;
					if (FizVJdopVGpnhZEYbhRCJuEKmrcR != IntPtr.Zero)
					{
						awBDVVAQrVojolizTQZQDabqRnX.OpSooMXoJcVRevXVvKUuePnULpV(FizVJdopVGpnhZEYbhRCJuEKmrcR);
						num = -995823462;
						goto IL_0015;
					}
					goto IL_0080;
					IL_0015:
					while (true)
					{
						switch (num ^ -995823461)
						{
						case 0:
							num = -995823458;
							continue;
						default:
							return;
						case 4:
							FizVJdopVGpnhZEYbhRCJuEKmrcR = IntPtr.Zero;
							num = -995823463;
							continue;
						case 3:
							break;
						case 5:
							goto end_IL_004c;
						case 1:
							goto IL_0080;
						case 2:
							return;
						}
						break;
					}
					continue;
					IL_0080:
					IsOpen = false;
					num = -995823457;
					goto IL_0015;
					continue;
					end_IL_004c:
					break;
				}
			}
		}

		void OzVqfYeaMNEXzwFiuZOmGiQFiUf.WOLsmFNlIJeAQHmPXjSXWDEbbnA()
		{
			//ILSpy generated this explicit interface implementation from .override directive in WOLsmFNlIJeAQHmPXjSXWDEbbnA
			this.WOLsmFNlIJeAQHmPXjSXWDEbbnA();
		}

		public OFtWxwvQaCIdBMAlbBrAEqpvclJ AFeHJojxqfbjmBllWvAWerjcLiqH()
		{
			return null;
		}

		OFtWxwvQaCIdBMAlbBrAEqpvclJ OzVqfYeaMNEXzwFiuZOmGiQFiUf.AFeHJojxqfbjmBllWvAWerjcLiqH()
		{
			//ILSpy generated this explicit interface implementation from .override directive in AFeHJojxqfbjmBllWvAWerjcLiqH
			return this.AFeHJojxqfbjmBllWvAWerjcLiqH();
		}

		public void AFeHJojxqfbjmBllWvAWerjcLiqH(AUaUBBXSbbJpKBhcrBlUkcXFNNQW P_0)
		{
		}

		void OzVqfYeaMNEXzwFiuZOmGiQFiUf.AFeHJojxqfbjmBllWvAWerjcLiqH(AUaUBBXSbbJpKBhcrBlUkcXFNNQW P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in AFeHJojxqfbjmBllWvAWerjcLiqH
			this.AFeHJojxqfbjmBllWvAWerjcLiqH(P_0);
		}

		public OFtWxwvQaCIdBMAlbBrAEqpvclJ AFeHJojxqfbjmBllWvAWerjcLiqH(int P_0)
		{
			return null;
		}

		OFtWxwvQaCIdBMAlbBrAEqpvclJ OzVqfYeaMNEXzwFiuZOmGiQFiUf.AFeHJojxqfbjmBllWvAWerjcLiqH(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in AFeHJojxqfbjmBllWvAWerjcLiqH
			return this.AFeHJojxqfbjmBllWvAWerjcLiqH(P_0);
		}

		public void qQsYWLTqxWLHpYHgzwIipXJOfdg(yzcrzEoCqZBvykcldEkurWvBhZS P_0)
		{
		}

		void OzVqfYeaMNEXzwFiuZOmGiQFiUf.qQsYWLTqxWLHpYHgzwIipXJOfdg(yzcrzEoCqZBvykcldEkurWvBhZS P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in qQsYWLTqxWLHpYHgzwIipXJOfdg
			this.qQsYWLTqxWLHpYHgzwIipXJOfdg(P_0);
		}

		public bJdArpFKhPHGqYwVeHitnnoUJsNt qQsYWLTqxWLHpYHgzwIipXJOfdg(int P_0)
		{
			return null;
		}

		bJdArpFKhPHGqYwVeHitnnoUJsNt OzVqfYeaMNEXzwFiuZOmGiQFiUf.qQsYWLTqxWLHpYHgzwIipXJOfdg(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in qQsYWLTqxWLHpYHgzwIipXJOfdg
			return this.qQsYWLTqxWLHpYHgzwIipXJOfdg(P_0);
		}

		public bJdArpFKhPHGqYwVeHitnnoUJsNt qQsYWLTqxWLHpYHgzwIipXJOfdg()
		{
			return null;
		}

		bJdArpFKhPHGqYwVeHitnnoUJsNt OzVqfYeaMNEXzwFiuZOmGiQFiUf.qQsYWLTqxWLHpYHgzwIipXJOfdg()
		{
			//ILSpy generated this explicit interface implementation from .override directive in qQsYWLTqxWLHpYHgzwIipXJOfdg
			return this.qQsYWLTqxWLHpYHgzwIipXJOfdg();
		}

		public bool eORGHcmAYkszIHTpmsAAikxhgUt(out byte[] P_0, byte P_1 = 0)
		{
			if (pfWZoRZAPZcfnDAxucPxBkifuFIv)
			{
				goto IL_0008;
			}
			if (KwKWhKDOjmeUUiqEnjBSVVbRKvD.FeatureReportByteLength <= 0)
			{
				P_0 = new byte[0];
				return false;
			}
			P_0 = new byte[KwKWhKDOjmeUUiqEnjBSVVbRKvD.FeatureReportByteLength];
			byte[] array = zgAFYcNOmuyzdqKkCjgBGAwGiYJ();
			int num = 423525559;
			goto IL_000d;
			IL_0008:
			num = 423525557;
			goto IL_000d;
			IL_000d:
			IntPtr intPtr = default(IntPtr);
			while (true)
			{
				switch (num ^ 0x193E7CB6)
				{
				case 4:
					break;
				case 3:
					P_0 = null;
					num = 423525555;
					continue;
				case 1:
					array[0] = P_1;
					num = 423525558;
					continue;
				case 0:
					intPtr = IntPtr.Zero;
					num = 423525556;
					continue;
				case 5:
					return false;
				default:
				{
					bool flag = false;
					try
					{
						if (IsOpen)
						{
							goto IL_009b;
						}
						goto IL_0106;
						IL_009b:
						int num2 = 423525554;
						goto IL_00a0;
						IL_00a0:
						while (true)
						{
							switch (num2 ^ 0x193E7CB6)
							{
							case 2:
								break;
							default:
								goto end_IL_0093;
							case 4:
								intPtr = Handle;
								num2 = 423525559;
								continue;
							case 1:
								flag = UvOafjjHDydfBDHpjrlzeDLuZok.TVTheKhhoPfkMPCuoUmNxGJYccf(intPtr, array, array.Length);
								if (flag)
								{
									Array.Copy(array, 0, P_0, 0, Math.Min(P_0.Length, KwKWhKDOjmeUUiqEnjBSVVbRKvD.FeatureReportByteLength));
									num2 = 423525557;
									continue;
								}
								goto end_IL_0093;
							case 5:
								goto IL_0106;
							case 0:
								return false;
							case 3:
								goto end_IL_0093;
							}
							break;
						}
						goto IL_009b;
						IL_0106:
						intPtr = awBDVVAQrVojolizTQZQDabqRnX.HKjJtpjhmoeUfTKHQqKHasPJhgi(htaMilNTPYUsZhoBbkevwTQQsLi, 0u);
						int num3;
						if (intPtr.ToInt32() == -1)
						{
							num2 = 423525558;
							num3 = num2;
						}
						else
						{
							num2 = 423525559;
							num3 = num2;
						}
						goto IL_00a0;
						end_IL_0093:;
					}
					catch (Exception innerException)
					{
						throw new Exception($"Error accessing HID device '{htaMilNTPYUsZhoBbkevwTQQsLi}'.", innerException);
					}
					finally
					{
						if (!IsOpen && intPtr.ToInt32() != -1)
						{
							awBDVVAQrVojolizTQZQDabqRnX.OpSooMXoJcVRevXVvKUuePnULpV(intPtr);
						}
					}
					return flag;
				}
				}
				break;
			}
			goto IL_0008;
		}

		bool OzVqfYeaMNEXzwFiuZOmGiQFiUf.eORGHcmAYkszIHTpmsAAikxhgUt(out byte[] P_0, byte P_1 = 0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in eORGHcmAYkszIHTpmsAAikxhgUt
			return this.eORGHcmAYkszIHTpmsAAikxhgUt(out P_0, P_1);
		}

		public string yFxOGXcaegbEFjxkNZdqsTwHOBxe()
		{
			if (pfWZoRZAPZcfnDAxucPxBkifuFIv)
			{
				return string.Empty;
			}
			string result = default(string);
			try
			{
				if (yFxOGXcaegbEFjxkNZdqsTwHOBxe(out var bytes))
				{
					goto IL_0050;
				}
				while (true)
				{
					int num = -1506669400;
					while (true)
					{
						switch (num ^ -1506669398)
						{
						case 0:
							break;
						case 2:
							result = string.Empty;
							num = -1506669399;
							continue;
						case 3:
							goto end_IL_0018;
						default:
							goto IL_0050;
						}
						break;
					}
					continue;
					end_IL_0018:
					break;
				}
				goto end_IL_000e;
				IL_0050:
				result = StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
				end_IL_000e:;
			}
			catch (Exception)
			{
				result = string.Empty;
			}
			return result;
		}

		string OzVqfYeaMNEXzwFiuZOmGiQFiUf.yFxOGXcaegbEFjxkNZdqsTwHOBxe()
		{
			//ILSpy generated this explicit interface implementation from .override directive in yFxOGXcaegbEFjxkNZdqsTwHOBxe
			return this.yFxOGXcaegbEFjxkNZdqsTwHOBxe();
		}

		public unsafe bool yFxOGXcaegbEFjxkNZdqsTwHOBxe(out byte[] P_0)
		{
			//The blocks IL_00be, IL_00c3, IL_00e4 are reachable both inside and outside the pinned region starting at IL_0107. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			if (pfWZoRZAPZcfnDAxucPxBkifuFIv)
			{
				goto IL_0008;
			}
			P_0 = new byte[255];
			int num = 1682186812;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x6444223C)
			{
			case 2:
				break;
			case 1:
				P_0 = null;
				return false;
			default:
			{
				IntPtr intPtr = IntPtr.Zero;
				bool result = false;
				try
				{
					if (IsOpen)
					{
						goto IL_004e;
					}
					goto IL_0082;
					IL_004e:
					int num2 = 1682186814;
					goto IL_0053;
					IL_0053:
					while (true)
					{
						switch (num2 ^ 0x6444223C)
						{
						case 0:
							break;
						case 2:
							intPtr = Handle;
							num2 = 1682186815;
							continue;
						case 4:
							goto IL_0082;
						default:
							return false;
						case 3:
							goto IL_00b1;
						}
						break;
					}
					goto IL_004e;
					IL_00b1:
					ref IntPtr reference = default(ref IntPtr);
					try
					{
						byte[] array;
						if ((array = P_0) != null)
						{
							if (array.Length == 0)
							{
								goto IL_00be;
							}
							goto IL_00ff;
						}
						goto IL_010f;
						IL_00ff:
						int num3;
						while (true)
						{
							IL_00ff_2:
							fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<byte, IntPtr>(ref array[0]))
							{
								num3 = 1682186808;
								while (true)
								{
									switch (num3 ^ 0x6444223C)
									{
									case 0:
										num3 = 1682186813;
										continue;
									case 4:
										result = UvOafjjHDydfBDHpjrlzeDLuZok.UDTtnhOfceJTkszROnKNHoHrARhc(intPtr, (IntPtr)ptr, P_0.Length);
										num3 = 1682186814;
										continue;
									case 3:
										goto IL_00ff_2;
									case 1:
										goto end_IL_00ff;
									case 2:
										break;
									}
									break;
								}
							}
							goto end_IL_00b1;
							continue;
							end_IL_00ff:
							break;
						}
						goto IL_010f;
						IL_00be:
						num3 = 1682186813;
						goto IL_00c3_2;
						IL_00c3_2:
						while (true)
						{
							switch (num3 ^ 0x6444223C)
							{
							case 0:
								break;
							default:
								goto end_IL_00b1;
							case 4:
								result = UvOafjjHDydfBDHpjrlzeDLuZok.UDTtnhOfceJTkszROnKNHoHrARhc(intPtr, (IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference), P_0.Length);
								num3 = 1682186814;
								continue;
							case 3:
								goto IL_00ff;
							case 1:
								goto IL_010f;
							case 2:
								goto end_IL_00b1;
							}
							break;
						}
						goto IL_00be;
						IL_010f:
						reference = ref *(IntPtr*)null;
						num3 = 1682186808;
						goto IL_00c3_2;
						end_IL_00b1:;
					}
					finally
					{
						reference = ref *(IntPtr*)null;
					}
					goto end_IL_0046;
					IL_0082:
					intPtr = awBDVVAQrVojolizTQZQDabqRnX.HKjJtpjhmoeUfTKHQqKHasPJhgi(htaMilNTPYUsZhoBbkevwTQQsLi, 0u);
					if (intPtr.ToInt32() == -1)
					{
						num2 = 1682186813;
						goto IL_0053;
					}
					goto IL_00b1;
					end_IL_0046:;
				}
				catch (Exception innerException)
				{
					throw new Exception($"Error accessing HID device '{htaMilNTPYUsZhoBbkevwTQQsLi}'.", innerException);
				}
				finally
				{
					if (!IsOpen)
					{
						while (true)
						{
							IL_0143:
							int num4 = 1682186813;
							while (true)
							{
								switch (num4 ^ 0x6444223C)
								{
								case 0:
									break;
								default:
									goto end_IL_0148;
								case 1:
									if (intPtr.ToInt32() != -1)
									{
										goto IL_016b;
									}
									goto end_IL_0148;
								case 2:
									goto end_IL_0148;
								}
								goto IL_0143;
								IL_016b:
								awBDVVAQrVojolizTQZQDabqRnX.OpSooMXoJcVRevXVvKUuePnULpV(intPtr);
								num4 = 1682186814;
								continue;
								end_IL_0148:
								break;
							}
							break;
						}
					}
				}
				return result;
			}
			}
			goto IL_0008;
			IL_0008:
			num = 1682186813;
			goto IL_000d;
		}

		bool OzVqfYeaMNEXzwFiuZOmGiQFiUf.yFxOGXcaegbEFjxkNZdqsTwHOBxe(out byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in yFxOGXcaegbEFjxkNZdqsTwHOBxe
			return this.yFxOGXcaegbEFjxkNZdqsTwHOBxe(out P_0);
		}

		public string qndLldKpjRqINyWyQhSIXAPjRbm()
		{
			if (pfWZoRZAPZcfnDAxucPxBkifuFIv)
			{
				return string.Empty;
			}
			qndLldKpjRqINyWyQhSIXAPjRbm(out var bytes);
			return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
		}

		string OzVqfYeaMNEXzwFiuZOmGiQFiUf.qndLldKpjRqINyWyQhSIXAPjRbm()
		{
			//ILSpy generated this explicit interface implementation from .override directive in qndLldKpjRqINyWyQhSIXAPjRbm
			return this.qndLldKpjRqINyWyQhSIXAPjRbm();
		}

		public bool qndLldKpjRqINyWyQhSIXAPjRbm(out byte[] P_0)
		{
			if (pfWZoRZAPZcfnDAxucPxBkifuFIv)
			{
				goto IL_0008;
			}
			P_0 = new byte[255];
			int num = 1903242550;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x71712D35)
				{
				case 0:
					break;
				case 2:
					goto IL_002a;
				case 1:
					return false;
				default:
				{
					IntPtr intPtr = IntPtr.Zero;
					bool flag = false;
					try
					{
						if (IsOpen)
						{
							intPtr = Handle;
						}
						else
						{
							while (true)
							{
								intPtr = awBDVVAQrVojolizTQZQDabqRnX.HKjJtpjhmoeUfTKHQqKHasPJhgi(htaMilNTPYUsZhoBbkevwTQQsLi, 0u);
								if (intPtr.ToInt32() != -1)
								{
									break;
								}
								bool result = false;
								int num2 = 1903242548;
								while (true)
								{
									switch (num2 ^ 0x71712D35)
									{
									case 0:
										num2 = 1903242550;
										continue;
									case 3:
										break;
									default:
										goto end_IL_0084;
									case 1:
										return result;
									}
									break;
								}
								continue;
								end_IL_0084:
								break;
							}
						}
						GCHandle gCHandle = GCHandle.Alloc(P_0, GCHandleType.Pinned);
						flag = UvOafjjHDydfBDHpjrlzeDLuZok.GIuFzFdIQdaLsjKyaEjAGEresLTl(intPtr, gCHandle.AddrOfPinnedObject(), P_0.Length);
						GC.KeepAlive(gCHandle);
						gCHandle.Free();
						return flag;
					}
					catch (Exception innerException)
					{
						throw new Exception($"Error accessing HID device '{htaMilNTPYUsZhoBbkevwTQQsLi}'.", innerException);
					}
					finally
					{
						if (!IsOpen && intPtr.ToInt32() != -1)
						{
							awBDVVAQrVojolizTQZQDabqRnX.OpSooMXoJcVRevXVvKUuePnULpV(intPtr);
						}
					}
				}
				}
				break;
				IL_002a:
				P_0 = null;
				num = 1903242548;
			}
			goto IL_0008;
			IL_0008:
			num = 1903242551;
			goto IL_000d;
		}

		bool OzVqfYeaMNEXzwFiuZOmGiQFiUf.qndLldKpjRqINyWyQhSIXAPjRbm(out byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in qndLldKpjRqINyWyQhSIXAPjRbm
			return this.qndLldKpjRqINyWyQhSIXAPjRbm(out P_0);
		}

		public string NYcwJindAhRkFWwnCqKYYgxzixr()
		{
			if (pfWZoRZAPZcfnDAxucPxBkifuFIv)
			{
				return string.Empty;
			}
			NYcwJindAhRkFWwnCqKYYgxzixr(out var bytes);
			return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
		}

		string OzVqfYeaMNEXzwFiuZOmGiQFiUf.NYcwJindAhRkFWwnCqKYYgxzixr()
		{
			//ILSpy generated this explicit interface implementation from .override directive in NYcwJindAhRkFWwnCqKYYgxzixr
			return this.NYcwJindAhRkFWwnCqKYYgxzixr();
		}

		public bool NYcwJindAhRkFWwnCqKYYgxzixr(out byte[] P_0)
		{
			if (pfWZoRZAPZcfnDAxucPxBkifuFIv)
			{
				P_0 = null;
				return false;
			}
			IntPtr intPtr = IntPtr.Zero;
			bool flag = false;
			try
			{
				if (IsOpen)
				{
					intPtr = Handle;
					while (true)
					{
						int num = 1876571158;
						while (true)
						{
							switch (num ^ 0x6FDA3414)
							{
							case 3:
								break;
							case 2:
								num = 1876571156;
								continue;
							case 1:
								goto end_IL_0024;
							default:
								goto IL_0072;
							}
							break;
						}
						continue;
						end_IL_0024:
						break;
					}
				}
				intPtr = awBDVVAQrVojolizTQZQDabqRnX.HKjJtpjhmoeUfTKHQqKHasPJhgi(htaMilNTPYUsZhoBbkevwTQQsLi, 0u);
				if (intPtr.ToInt32() == -1)
				{
					P_0 = null;
					return false;
				}
				goto IL_0072;
				IL_0072:
				return awBDVVAQrVojolizTQZQDabqRnX.NYcwJindAhRkFWwnCqKYYgxzixr(intPtr, out P_0);
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{htaMilNTPYUsZhoBbkevwTQQsLi}'.", innerException);
			}
			finally
			{
				if (!IsOpen)
				{
					while (true)
					{
						IL_009e:
						int num2 = 1876571158;
						while (true)
						{
							switch (num2 ^ 0x6FDA3414)
							{
							case 0:
								break;
							default:
								goto end_IL_00a3;
							case 2:
								if (intPtr.ToInt32() != -1)
								{
									goto IL_00c6;
								}
								goto end_IL_00a3;
							case 1:
								goto end_IL_00a3;
							}
							goto IL_009e;
							IL_00c6:
							awBDVVAQrVojolizTQZQDabqRnX.OpSooMXoJcVRevXVvKUuePnULpV(intPtr);
							num2 = 1876571157;
							continue;
							end_IL_00a3:
							break;
						}
						break;
					}
				}
			}
		}

		bool OzVqfYeaMNEXzwFiuZOmGiQFiUf.NYcwJindAhRkFWwnCqKYYgxzixr(out byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NYcwJindAhRkFWwnCqKYYgxzixr
			return this.NYcwJindAhRkFWwnCqKYYgxzixr(out P_0);
		}

		public string VpAmYlJClbCoAueaizThPXrqwpu()
		{
			return "";
		}

		string OzVqfYeaMNEXzwFiuZOmGiQFiUf.VpAmYlJClbCoAueaizThPXrqwpu()
		{
			//ILSpy generated this explicit interface implementation from .override directive in VpAmYlJClbCoAueaizThPXrqwpu
			return this.VpAmYlJClbCoAueaizThPXrqwpu();
		}

		public bool VpAmYlJClbCoAueaizThPXrqwpu(out byte[] P_0)
		{
			P_0 = null;
			return false;
		}

		bool OzVqfYeaMNEXzwFiuZOmGiQFiUf.VpAmYlJClbCoAueaizThPXrqwpu(out byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in VpAmYlJClbCoAueaizThPXrqwpu
			return this.VpAmYlJClbCoAueaizThPXrqwpu(out P_0);
		}

		public void pqcPIshdVNrBiKWuGFpklSuavkZ(byte[] P_0, LIvMzSENdUPIGjBmLpIwSZkHKtw P_1)
		{
		}

		void OzVqfYeaMNEXzwFiuZOmGiQFiUf.pqcPIshdVNrBiKWuGFpklSuavkZ(byte[] P_0, LIvMzSENdUPIGjBmLpIwSZkHKtw P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in pqcPIshdVNrBiKWuGFpklSuavkZ
			this.pqcPIshdVNrBiKWuGFpklSuavkZ(P_0, P_1);
		}

		public bool pqcPIshdVNrBiKWuGFpklSuavkZ(byte[] P_0)
		{
			return false;
		}

		bool OzVqfYeaMNEXzwFiuZOmGiQFiUf.pqcPIshdVNrBiKWuGFpklSuavkZ(byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in pqcPIshdVNrBiKWuGFpklSuavkZ
			return this.pqcPIshdVNrBiKWuGFpklSuavkZ(P_0);
		}

		public bool pqcPIshdVNrBiKWuGFpklSuavkZ(byte[] P_0, int P_1)
		{
			return false;
		}

		bool OzVqfYeaMNEXzwFiuZOmGiQFiUf.pqcPIshdVNrBiKWuGFpklSuavkZ(byte[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in pqcPIshdVNrBiKWuGFpklSuavkZ
			return this.pqcPIshdVNrBiKWuGFpklSuavkZ(P_0, P_1);
		}

		public void bDFKamTZZIGrWDlvzxkfdgmmxXe(bJdArpFKhPHGqYwVeHitnnoUJsNt P_0, LIvMzSENdUPIGjBmLpIwSZkHKtw P_1)
		{
		}

		void OzVqfYeaMNEXzwFiuZOmGiQFiUf.bDFKamTZZIGrWDlvzxkfdgmmxXe(bJdArpFKhPHGqYwVeHitnnoUJsNt P_0, LIvMzSENdUPIGjBmLpIwSZkHKtw P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in bDFKamTZZIGrWDlvzxkfdgmmxXe
			this.bDFKamTZZIGrWDlvzxkfdgmmxXe(P_0, P_1);
		}

		public bool bDFKamTZZIGrWDlvzxkfdgmmxXe(bJdArpFKhPHGqYwVeHitnnoUJsNt P_0)
		{
			return false;
		}

		bool OzVqfYeaMNEXzwFiuZOmGiQFiUf.bDFKamTZZIGrWDlvzxkfdgmmxXe(bJdArpFKhPHGqYwVeHitnnoUJsNt P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in bDFKamTZZIGrWDlvzxkfdgmmxXe
			return this.bDFKamTZZIGrWDlvzxkfdgmmxXe(P_0);
		}

		public bool bDFKamTZZIGrWDlvzxkfdgmmxXe(bJdArpFKhPHGqYwVeHitnnoUJsNt P_0, int P_1)
		{
			return false;
		}

		bool OzVqfYeaMNEXzwFiuZOmGiQFiUf.bDFKamTZZIGrWDlvzxkfdgmmxXe(bJdArpFKhPHGqYwVeHitnnoUJsNt P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in bDFKamTZZIGrWDlvzxkfdgmmxXe
			return this.bDFKamTZZIGrWDlvzxkfdgmmxXe(P_0, P_1);
		}

		public bJdArpFKhPHGqYwVeHitnnoUJsNt JrBXjuOyuCSMWCyJJHGnxOHUyPH()
		{
			return null;
		}

		bJdArpFKhPHGqYwVeHitnnoUJsNt OzVqfYeaMNEXzwFiuZOmGiQFiUf.JrBXjuOyuCSMWCyJJHGnxOHUyPH()
		{
			//ILSpy generated this explicit interface implementation from .override directive in JrBXjuOyuCSMWCyJJHGnxOHUyPH
			return this.JrBXjuOyuCSMWCyJJHGnxOHUyPH();
		}

		public bool WzjEGfskGHnFYFKLhMpxNTIeNop(byte[] P_0)
		{
			return false;
		}

		bool OzVqfYeaMNEXzwFiuZOmGiQFiUf.WzjEGfskGHnFYFKLhMpxNTIeNop(byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in WzjEGfskGHnFYFKLhMpxNTIeNop
			return this.WzjEGfskGHnFYFKLhMpxNTIeNop(P_0);
		}

		public void Dispose()
		{
		}

		public bool ThCBYvbcvHbKBcbWFoWasTHMqDWi(OutputReport P_0)
		{
			return false;
		}

		bool OzVqfYeaMNEXzwFiuZOmGiQFiUf.ThCBYvbcvHbKBcbWFoWasTHMqDWi(OutputReport P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ThCBYvbcvHbKBcbWFoWasTHMqDWi
			return this.ThCBYvbcvHbKBcbWFoWasTHMqDWi(P_0);
		}

		private byte[] aEGtzPYEtPuuPVkdqAVkZSlcLmt()
		{
			return UcboCKQlcUprmmqOFdIDfUHsoazR(Capabilities.InputReportByteLength - 1);
		}

		private byte[] FftiNaOMpUdGkLfPePeWmigRpJO()
		{
			return UcboCKQlcUprmmqOFdIDfUHsoazR(Capabilities.OutputReportByteLength - 1);
		}

		private byte[] zgAFYcNOmuyzdqKkCjgBGAwGiYJ()
		{
			return UcboCKQlcUprmmqOFdIDfUHsoazR(Capabilities.FeatureReportByteLength - 1);
		}

		private static byte[] UcboCKQlcUprmmqOFdIDfUHsoazR(int P_0)
		{
			byte[] array = null;
			Array.Resize(ref array, P_0 + 1);
			return array;
		}
	}

	private sealed class maMEuFlKkCnUlYWUxHRsLlHhaBq
	{
		public IList<xJrcpabxFNJEeLKxzDoQfzegzEjy.HgZMwhsohjWIBboQuvWWFfRgqgD> GkVsBWErbpRMQuJRLfGZmQcjMLD;
	}

	private sealed class XkpSoMzBWrjwHXyBbrXWShfYboE
	{
		public maMEuFlKkCnUlYWUxHRsLlHhaBq TwFGIonUPKlwPFboAbFGZdhKLtr;

		public int XZPCSfwdMWYhFdBcAnWAbWLNeEC;

		public bool QuiaNwyiGHoKdAQrKuAIujqogzy(string P_0)
		{
			return P_0.Equals(TwFGIonUPKlwPFboAbFGZdhKLtr.GkVsBWErbpRMQuJRLfGZmQcjMLD[XZPCSfwdMWYhFdBcAnWAbWLNeEC].NgwLeHXsiNEuQFNaUGBBFKnPZsm, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class coXNVgzlUkmqXqShQAztpzVLhec
	{
		public TPOFglCEUenQueqhakDnrjLmVbgq RrqRSNwXejBavSbadAAmkjSAVycm;

		public bool nMXUVQuCcApcoebtidYASJlyMOg(TPOFglCEUenQueqhakDnrjLmVbgq P_0)
		{
			return P_0.InstanceGuid == RrqRSNwXejBavSbadAAmkjSAVycm.InstanceGuid;
		}
	}

	private sealed class pQzieCfhhenHDFiCkEmiJCzVKBgm
	{
		public OzVqfYeaMNEXzwFiuZOmGiQFiUf xwJLxrglVphteBhatdJSapIqbEaF;

		public byte[] PHKkroQhpYliCMOMfBpWzNidneX(byte P_0)
		{
			xwJLxrglVphteBhatdJSapIqbEaF.eORGHcmAYkszIHTpmsAAikxhgUt(out var result, P_0);
			return result;
		}
	}

	private sealed class GyTCZqFnTtPlqKgcTkHEcvJWJMGC
	{
		public bool XewSQgMjCFaDNJiRryZdwxsRawl;

		public YkKIPPiCWZeAzAfNMTiDRgJXluDN xvYPGRaXRVZlwecANemUYNIlHnq;

		public void YpYhglsBmdfIbdiaFEDrnTnGkCA()
		{
			try
			{
				MqTiLaFHDtnFUlOZwClsCzFjNOeu.BRxQVckbIdJRGeNXSbjYpcTefbr((qIbMLJZATiXoZkJFsjBRfhcWBevI)1, (HnEKTVdMYbbGrySWPQiZMYNvwN)4, gKkKUCzoRCsPZVnmEixRrSJwEiK.cGRXaGOyiobrTtSieHkvjdIHewu | gKkKUCzoRCsPZVnmEixRrSJwEiK.UEBnULvchzYnyCEBvdrZgmoedljh, xvYPGRaXRVZlwecANemUYNIlHnq.RQdPJSbvvMdPhNVeOTTxzTpjUat.Handle);
				MqTiLaFHDtnFUlOZwClsCzFjNOeu.BRxQVckbIdJRGeNXSbjYpcTefbr((qIbMLJZATiXoZkJFsjBRfhcWBevI)1, (HnEKTVdMYbbGrySWPQiZMYNvwN)5, gKkKUCzoRCsPZVnmEixRrSJwEiK.cGRXaGOyiobrTtSieHkvjdIHewu | gKkKUCzoRCsPZVnmEixRrSJwEiK.UEBnULvchzYnyCEBvdrZgmoedljh, xvYPGRaXRVZlwecANemUYNIlHnq.RQdPJSbvvMdPhNVeOTTxzTpjUat.Handle);
				MqTiLaFHDtnFUlOZwClsCzFjNOeu.BRxQVckbIdJRGeNXSbjYpcTefbr((qIbMLJZATiXoZkJFsjBRfhcWBevI)1, (HnEKTVdMYbbGrySWPQiZMYNvwN)8, gKkKUCzoRCsPZVnmEixRrSJwEiK.cGRXaGOyiobrTtSieHkvjdIHewu | gKkKUCzoRCsPZVnmEixRrSJwEiK.UEBnULvchzYnyCEBvdrZgmoedljh, xvYPGRaXRVZlwecANemUYNIlHnq.RQdPJSbvvMdPhNVeOTTxzTpjUat.Handle);
				MqTiLaFHDtnFUlOZwClsCzFjNOeu.BRxQVckbIdJRGeNXSbjYpcTefbr((qIbMLJZATiXoZkJFsjBRfhcWBevI)12, (HnEKTVdMYbbGrySWPQiZMYNvwN)1, gKkKUCzoRCsPZVnmEixRrSJwEiK.cGRXaGOyiobrTtSieHkvjdIHewu | gKkKUCzoRCsPZVnmEixRrSJwEiK.UEBnULvchzYnyCEBvdrZgmoedljh, xvYPGRaXRVZlwecANemUYNIlHnq.RQdPJSbvvMdPhNVeOTTxzTpjUat.Handle);
			}
			catch
			{
				XewSQgMjCFaDNJiRryZdwxsRawl = true;
			}
		}
	}

	private sealed class hcUabNFLIdRXclfxcPlHiXjCxeDd
	{
		public bool XewSQgMjCFaDNJiRryZdwxsRawl;

		public void kYDWPITsNonbtdvCVVEZvKJTtTN()
		{
			try
			{
				MqTiLaFHDtnFUlOZwClsCzFjNOeu.aVHTpmIgbNEHVLayecwFmnsDupe((qIbMLJZATiXoZkJFsjBRfhcWBevI)1, (HnEKTVdMYbbGrySWPQiZMYNvwN)4);
				MqTiLaFHDtnFUlOZwClsCzFjNOeu.aVHTpmIgbNEHVLayecwFmnsDupe((qIbMLJZATiXoZkJFsjBRfhcWBevI)1, (HnEKTVdMYbbGrySWPQiZMYNvwN)5);
				MqTiLaFHDtnFUlOZwClsCzFjNOeu.aVHTpmIgbNEHVLayecwFmnsDupe((qIbMLJZATiXoZkJFsjBRfhcWBevI)1, (HnEKTVdMYbbGrySWPQiZMYNvwN)8);
				MqTiLaFHDtnFUlOZwClsCzFjNOeu.aVHTpmIgbNEHVLayecwFmnsDupe((qIbMLJZATiXoZkJFsjBRfhcWBevI)12, (HnEKTVdMYbbGrySWPQiZMYNvwN)1);
			}
			catch
			{
				XewSQgMjCFaDNJiRryZdwxsRawl = true;
			}
		}
	}

	private sealed class OJhGFhJMtmdDtmkWCaDDEFpwoPZb
	{
		public bool XewSQgMjCFaDNJiRryZdwxsRawl;

		public void NipDimQEbEttBAjoPCPLSVhaqla()
		{
			try
			{
				MqTiLaFHDtnFUlOZwClsCzFjNOeu.aVHTpmIgbNEHVLayecwFmnsDupe((qIbMLJZATiXoZkJFsjBRfhcWBevI)1, (HnEKTVdMYbbGrySWPQiZMYNvwN)2);
			}
			catch
			{
				XewSQgMjCFaDNJiRryZdwxsRawl = true;
			}
		}
	}

	private sealed class bTJHZCnFpyTiOTkFMKOktpThDbG
	{
		public bool XewSQgMjCFaDNJiRryZdwxsRawl;

		public YkKIPPiCWZeAzAfNMTiDRgJXluDN xvYPGRaXRVZlwecANemUYNIlHnq;

		public void CHRqtONoeWOhazfpCZCQoNkpgxb()
		{
			try
			{
				MqTiLaFHDtnFUlOZwClsCzFjNOeu.BRxQVckbIdJRGeNXSbjYpcTefbr((qIbMLJZATiXoZkJFsjBRfhcWBevI)1, (HnEKTVdMYbbGrySWPQiZMYNvwN)2, gKkKUCzoRCsPZVnmEixRrSJwEiK.cGRXaGOyiobrTtSieHkvjdIHewu, xvYPGRaXRVZlwecANemUYNIlHnq.RQdPJSbvvMdPhNVeOTTxzTpjUat.Handle);
			}
			catch
			{
				XewSQgMjCFaDNJiRryZdwxsRawl = true;
			}
		}
	}

	private sealed class TegzNhYcFIBrgwEmaGCKbsDmMTfH
	{
		public bool XewSQgMjCFaDNJiRryZdwxsRawl;

		public YkKIPPiCWZeAzAfNMTiDRgJXluDN xvYPGRaXRVZlwecANemUYNIlHnq;

		public void igzBsVTXcbzJKiiVVAeVailAJLZ()
		{
			try
			{
				MqTiLaFHDtnFUlOZwClsCzFjNOeu.BRxQVckbIdJRGeNXSbjYpcTefbr((qIbMLJZATiXoZkJFsjBRfhcWBevI)1, (HnEKTVdMYbbGrySWPQiZMYNvwN)6, gKkKUCzoRCsPZVnmEixRrSJwEiK.cGRXaGOyiobrTtSieHkvjdIHewu, xvYPGRaXRVZlwecANemUYNIlHnq.RQdPJSbvvMdPhNVeOTTxzTpjUat.Handle);
			}
			catch
			{
				XewSQgMjCFaDNJiRryZdwxsRawl = true;
			}
		}
	}

	private sealed class GKopLJhmdTjAeVRnFHSYbyKXmXz
	{
		public bool XewSQgMjCFaDNJiRryZdwxsRawl;

		public void fSeHGHtSIEKmVjmZrutPRsJKjAR()
		{
			try
			{
				MqTiLaFHDtnFUlOZwClsCzFjNOeu.aVHTpmIgbNEHVLayecwFmnsDupe((qIbMLJZATiXoZkJFsjBRfhcWBevI)1, (HnEKTVdMYbbGrySWPQiZMYNvwN)6);
			}
			catch
			{
				XewSQgMjCFaDNJiRryZdwxsRawl = true;
			}
		}
	}

	private sealed class smutEwBmDzlyhioZwQTiBksitBv
	{
		public bool XewSQgMjCFaDNJiRryZdwxsRawl;

		public YkKIPPiCWZeAzAfNMTiDRgJXluDN xvYPGRaXRVZlwecANemUYNIlHnq;

		public hcawtLidRDRbqsbLAzMHVaINGfZ.FOuGhnqYlTUeadpnVWrBsIzYFWx udicPZKSFjJtuPaiMskGfpqKPOd;

		public void pVuckOHQgliLBugNjqRfgSzSdzd()
		{
			try
			{
				xvYPGRaXRVZlwecANemUYNIlHnq.RQdPJSbvvMdPhNVeOTTxzTpjUat = ruhqADbIPoVHWRPRGVhzYJszbgLd(udicPZKSFjJtuPaiMskGfpqKPOd);
				while (true)
				{
					switch (-427463438 ^ -427463440)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						if (xvYPGRaXRVZlwecANemUYNIlHnq.RQdPJSbvvMdPhNVeOTTxzTpjUat == null)
						{
							throw new Exception();
						}
						return;
					case 1:
						return;
					}
				}
			}
			catch
			{
				XewSQgMjCFaDNJiRryZdwxsRawl = true;
			}
		}
	}

	private const float taOoTmHdKpAKcxZqjFDypVJRer = 0.25f;

	private const float LHXuDwIGcfewbDyIlGIokLRBfuU = 1f;

	private List<TPOFglCEUenQueqhakDnrjLmVbgq> DhZbdMKNkujxkBYZovsLjyUUFhq;

	private List<TPOFglCEUenQueqhakDnrjLmVbgq> ujclMHgZBSufZZQgPvqAhfxUDbPc;

	private ReadOnlyCollection<TPOFglCEUenQueqhakDnrjLmVbgq> mQysYMoqGgKJhphNVcrHAvmChbvV;

	private UcjcCicwSOnbqeWIgHcOdekypFs dYGYigZHQLDxociHhyaSrGzXEUv;

	private uXmfJyNysxkJVMfVjUMqRSBUjHs GRolUKdfCrfyXltJwHEsDBEFexK;

	private ConfigVars ZlGbTCkxQRChOIofeffCYHRKxiuW;

	private UpdateLoopSetting BnNkbgybnGDKKbEtlthkxBlHLlXR;

	private readonly bool CnyaXxVpxASVfEjYRIkwedmEeQt;

	private readonly bool yCIfoAipTphniepDsrKPaDRNhiMJ;

	private readonly bool UNCDhikBVajwTkKrWKjlDBeTSzFD;

	private readonly bool pxdVJyAGwTQNGJDRzUSBDhXjucu;

	private readonly bool siSJeNGZdOVsVQoUSFTHNlfuJCb;

	private bool VoodlmKWYkBIcFdDQhKahZjCTAcc;

	private bool bQkxPpnAfRwlFYUCstXQcrarWbi;

	private bool rxLszQCXaawihnkDRMKZYNgwfqZ;

	private bool jOjtcktBibmhaTFZqMnJlLjfqAA;

	private int CWmCEPYIgUXCxKGQWVHoUPuxRlN;

	private readonly object jjLEEEFLvmsJLpKePirapzQBKQTH = new object();

	private readonly mUBVcHMAjvIHOEpZspoiRvjuqCkb rHccTXHaQHKgJspYXChoCFSBEVlf;

	private int mZPblCaonGfFNpAbwrdxIGAubRsD = -1;

	private lNVvsSWimiJoZjXIfLuDnlayxeb utNJDnvgtjyQuECjZnzMZfRDGij;

	private IntPtr NoatZUCGfWQDABlGSjSzJjqRKVrg;

	private IntPtr FZiGxbOkqzdsegVqpLGakKTGith;

	private ValueWatcher<IntPtr> BGYuTJmILidJmDNYViZXhFpmdBGH;

	private ValueWatcher[] xLMDqQIYXvVUFaJsLUAZDnTPaup;

	private double bGYFtaiaaIhedSXWUujtkmmKiUt;

	private hcawtLidRDRbqsbLAzMHVaINGfZ RQdPJSbvvMdPhNVeOTTxzTpjUat;

	private AbwSGmHmruFRfCAAVKJFheGpYrd BNowjvMfInZcNhDLgPskNJcMnCr;

	private static VqSFccEqDGfGMgdwzjgzGopfoSNj.BzpkqAlNnjifsUzvebxAiHHmeIi rKniTAhBAmHHsAzTytClBGfKgoJ;

	private VqSFccEqDGfGMgdwzjgzGopfoSNj.DDdvrlpyFzimmHfZzxNowIasOxF FZqzKykEocMbliKGtbZEWkufFPRf;

	private NativeBuffer wemVerhbzOcuIoLsucNIvVJbxxJ;

	private static Rewired.Internal.GUIText AOVaCyfFqvyVxcgzLYywGvdQOfkG;

	private static lSAktsHdQgImZAEBfTGvitJGhA[] ynFnLhcMEIvmOEUUVQZSzzGuUtY;

	private readonly DhzqteWsbvTGlVNuNgSKoKlJtmF tBLLIBxnGVrxdlYvuDZWPyDFvzD = new DhzqteWsbvTGlVNuNgSKoKlJtmF();

	private readonly aTdyQHLUTWxtxOewXyYbXIrqYcL ofavyyIyiYSzFSqsMQRPgAdnfGD = new aTdyQHLUTWxtxOewXyYbXIrqYcL();

	private bool inweGjIgYacXYohFlYRlpMFkgKMi;

	[CompilerGenerated]
	private static Action<TPOFglCEUenQueqhakDnrjLmVbgq> JxZgKFfmhskZqxAhyBEFdgqiQNiw;

	public static Rewired.Internal.GUIText guiText
	{
		get
		{
			if (AOVaCyfFqvyVxcgzLYywGvdQOfkG != null)
			{
				return AOVaCyfFqvyVxcgzLYywGvdQOfkG;
			}
			GameObject gameObject = GameObject.Find("DebugScreenLog");
			if (gameObject != null)
			{
				goto IL_002a;
			}
			goto IL_00bf;
			IL_00bf:
			gameObject = new GameObject("DebugScreenLog");
			gameObject.transform.position = Vector3.zero;
			int num = 133876443;
			goto IL_002f;
			IL_002a:
			num = 133876447;
			goto IL_002f;
			IL_002f:
			while (true)
			{
				switch (num ^ 0x7FACAD9)
				{
				case 0:
					break;
				case 6:
					AOVaCyfFqvyVxcgzLYywGvdQOfkG = gameObject.GetComponent<Rewired.Internal.GUIText>();
					num = 133876442;
					continue;
				case 1:
					AOVaCyfFqvyVxcgzLYywGvdQOfkG.anchor = TextAnchor.LowerLeft;
					AOVaCyfFqvyVxcgzLYywGvdQOfkG.alignment = TextAlignment.Left;
					num = 133876444;
					continue;
				case 2:
					AOVaCyfFqvyVxcgzLYywGvdQOfkG = gameObject.AddComponent<Rewired.Internal.GUIText>();
					num = 133876440;
					continue;
				case 5:
					AOVaCyfFqvyVxcgzLYywGvdQOfkG.pixelOffset = new Vector2(1200f, 0f);
					num = 133876442;
					continue;
				case 4:
					goto IL_00bf;
				default:
					return AOVaCyfFqvyVxcgzLYywGvdQOfkG;
				}
				break;
			}
			goto IL_002a;
		}
	}

	public event Action DeviceChangedEvent
	{
		add
		{
			throw new NotImplementedException();
		}
		remove
		{
			throw new NotImplementedException();
		}
	}

	public YkKIPPiCWZeAzAfNMTiDRgJXluDN(ConfigVars configVars, bool handleJoysticks, bool useCustomDrivers, UcjcCicwSOnbqeWIgHcOdekypFs unifiedMouse, uXmfJyNysxkJVMfVjUMqRSBUjHs unifiedKeyboard)
	{
		try
		{
			ZlGbTCkxQRChOIofeffCYHRKxiuW = configVars;
			BnNkbgybnGDKKbEtlthkxBlHLlXR = configVars.updateLoop;
			BGYuTJmILidJmDNYViZXhFpmdBGH = new ValueWatcher<IntPtr>(YksGHYKteMuhDXToEsEFZvCVfCJ.AUFWjjIkwWerQKSUjdsylUuMVyM(), YksGHYKteMuhDXToEsEFZvCVfCJ.AUFWjjIkwWerQKSUjdsylUuMVyM, autoTriggerEvent: true);
			BGYuTJmILidJmDNYViZXhFpmdBGH.ChangedEvent += LRdOqslXVCRVbZnbQQQlyiMRPJy;
			xLMDqQIYXvVUFaJsLUAZDnTPaup = new ValueWatcher[1] { BGYuTJmILidJmDNYViZXhFpmdBGH };
			yCIfoAipTphniepDsrKPaDRNhiMJ = handleJoysticks;
			siSJeNGZdOVsVQoUSFTHNlfuJCb = useCustomDrivers;
			dYGYigZHQLDxociHhyaSrGzXEUv = unifiedMouse;
			GRolUKdfCrfyXltJwHEsDBEFexK = unifiedKeyboard;
			UNCDhikBVajwTkKrWKjlDBeTSzFD = unifiedMouse != null;
			pxdVJyAGwTQNGJDRzUSBDhXjucu = unifiedKeyboard != null;
			CnyaXxVpxASVfEjYRIkwedmEeQt = ReInput.isEditor;
			DhZbdMKNkujxkBYZovsLjyUUFhq = new List<TPOFglCEUenQueqhakDnrjLmVbgq>();
			mQysYMoqGgKJhphNVcrHAvmChbvV = new ReadOnlyCollection<TPOFglCEUenQueqhakDnrjLmVbgq>(DhZbdMKNkujxkBYZovsLjyUUFhq);
			ujclMHgZBSufZZQgPvqAhfxUDbPc = new List<TPOFglCEUenQueqhakDnrjLmVbgq>();
			rKniTAhBAmHHsAzTytClBGfKgoJ = new VqSFccEqDGfGMgdwzjgzGopfoSNj.BzpkqAlNnjifsUzvebxAiHHmeIi
			{
				ZlwsNMmOwDtgQDskVCVzbvPohFF = (uint)Marshal.SizeOf(typeof(VqSFccEqDGfGMgdwzjgzGopfoSNj.BzpkqAlNnjifsUzvebxAiHHmeIi)),
				VdsBvUMNQkKoXKbokltaMqpxEew = true,
				AQxWTkCCzQknGcWWqrVRNXtILFh = true,
				yCrBsLUIbJGRTOOBndhvEwWRzZo = false,
				FyvtZIWfDgPZdQzAJeIeEIGcGAo = true,
				lbNblCPSPMZZkdYlduYWnqBVgqX = IntPtr.Zero
			};
			FZqzKykEocMbliKGtbZEWkufFPRf = VqSFccEqDGfGMgdwzjgzGopfoSNj.DDdvrlpyFzimmHfZzxNowIasOxF.ZyDMIRfUdtdyWWZsNvkwCISqzBR();
			wemVerhbzOcuIoLsucNIvVJbxxJ = new NativeBuffer((int)FZqzKykEocMbliKGtbZEWkufFPRf.ZlwsNMmOwDtgQDskVCVzbvPohFF);
			wemVerhbzOcuIoLsucNIvVJbxxJ.Write(FZqzKykEocMbliKGtbZEWkufFPRf.ZlwsNMmOwDtgQDskVCVzbvPohFF, 0);
			if (rHccTXHaQHKgJspYXChoCFSBEVlf == mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
			{
				cFLSCyatcazkzhENOEFuYqNcRPl(UeJwAFZBRXUmpWqkpXpTmRxhklJ);
				UBKjzbhqKIIzSTQkRlSuAiKFFSPQ();
			}
			if (handleJoysticks)
			{
				try
				{
					INaXaDHFVRAFNLXXTDgLCTrNFiua();
					YGYdhgSowikPsbOYLZzBOJThvWy(ref DhZbdMKNkujxkBYZovsLjyUUFhq, bVfvLqacePuaRPmfIxvTjQcwpeP(true));
				}
				catch (Exception ex)
				{
					if (ex.Data != null && ex.Data.Contains(1))
					{
						string text = ex.Data[1] as string;
						if (text == "sandbox")
						{
							Rewired.Logger.LogWarning("Detected possible sandbox. Raw Input does not work correctly in a sandbox with default security settings.");
						}
					}
					throw;
				}
			}
			tGVxomEHIjaBHEbQFiTxagakgYuL();
			ReInput.ApplicationIsFullScreenChangedEvent += YKqmoqZCInuKpHQtBUSbdSMmAKI;
			ReInput.ApplicationFullScreenModeChangedEvent += GsvmkLflhSjJdDfZtTTFjZClmvfh;
		}
		catch (Exception ex2)
		{
			Dispose();
			throw ex2;
		}
	}

	public void INaXaDHFVRAFNLXXTDgLCTrNFiua()
	{
	}

	public void fUuxtFvkFydskviGBsYizrMCeMj()
	{
		if (yCIfoAipTphniepDsrKPaDRNhiMJ)
		{
			lock (jjLEEEFLvmsJLpKePirapzQBKQTH)
			{
				YGYdhgSowikPsbOYLZzBOJThvWy(ref DhZbdMKNkujxkBYZovsLjyUUFhq, ujclMHgZBSufZZQgPvqAhfxUDbPc);
				while (true)
				{
					IL_0026:
					int num = -2099792373;
					while (true)
					{
						switch (num ^ -2099792374)
						{
						case 2:
							break;
						default:
							goto end_IL_002b;
						case 1:
							goto IL_0044;
						case 0:
							goto end_IL_002b;
						}
						goto IL_0026;
						IL_0044:
						ujclMHgZBSufZZQgPvqAhfxUDbPc.Clear();
						num = -2099792374;
						continue;
						end_IL_002b:
						break;
					}
					break;
				}
			}
		}
		if (pxdVJyAGwTQNGJDRzUSBDhXjucu)
		{
			nepBqwsCxIBfqpkKKysTMuTakZf();
			goto IL_006d;
		}
		goto IL_008b;
		IL_0072:
		int num2;
		switch (num2 ^ -2099792374)
		{
		case 0:
			break;
		default:
			return;
		case 2:
			goto IL_008b;
		case 1:
			return;
		}
		goto IL_006d;
		IL_006d:
		num2 = -2099792376;
		goto IL_0072;
		IL_008b:
		rxLszQCXaawihnkDRMKZYNgwfqZ = false;
		num2 = -2099792373;
		goto IL_0072;
	}

	public bool ZHnfziDQiQxToFwsnsRUKtaeiUpD()
	{
		lock (jjLEEEFLvmsJLpKePirapzQBKQTH)
		{
			if (ReJvInbBGFIOkILYWtjgnsCzoKCg())
			{
				Thread.Sleep(250);
			}
			ujclMHgZBSufZZQgPvqAhfxUDbPc = bVfvLqacePuaRPmfIxvTjQcwpeP(false);
			return true;
		}
	}

	public bool tFFgYAdaQhinKkFvHMyMHGcGcZJS()
	{
		int num = VALpBlQZpCIluQnRYtVKkCgseExH();
		if (num == CWmCEPYIgUXCxKGQWVHoUPuxRlN)
		{
			return false;
		}
		CWmCEPYIgUXCxKGQWVHoUPuxRlN = num;
		return true;
	}

	public bool ReJvInbBGFIOkILYWtjgnsCzoKCg()
	{
		try
		{
			return xJrcpabxFNJEeLKxzDoQfzegzEjy.ReJvInbBGFIOkILYWtjgnsCzoKCg();
		}
		catch
		{
		}
		return false;
	}

	public bool RdolmFtiYxRtXQsWHnoHzcUZsHk(bool P_0)
	{
		bool result = jOjtcktBibmhaTFZqMnJlLjfqAA;
		if (P_0)
		{
			jOjtcktBibmhaTFZqMnJlLjfqAA = false;
		}
		return result;
	}

	public void SystemDeviceDisconnected()
	{
		if (yCIfoAipTphniepDsrKPaDRNhiMJ)
		{
			rxLszQCXaawihnkDRMKZYNgwfqZ = true;
		}
	}

	public void SystemDeviceConnected()
	{
		if (yCIfoAipTphniepDsrKPaDRNhiMJ)
		{
			rxLszQCXaawihnkDRMKZYNgwfqZ = true;
		}
	}

	public void Update()
	{
		int num = 0;
		while (true)
		{
			int num2 = -1081718685;
			while (true)
			{
				switch (num2 ^ -1081718682)
				{
				case 0:
					break;
				default:
					return;
				case 5:
					num2 = -1081718674;
					continue;
				case 6:
					gIeGOlbTCwOqngsQPBCXEPpnTZfZ();
					num2 = -1081718684;
					continue;
				case 4:
					if (!pxdVJyAGwTQNGJDRzUSBDhXjucu)
					{
						int num6;
						if (!UNCDhikBVajwTkKrWKjlDBeTSzFD)
						{
							num2 = -1081718684;
							num6 = num2;
						}
						else
						{
							num2 = -1081718688;
							num6 = num2;
						}
						continue;
					}
					goto case 6;
				case 1:
					if (CnyaXxVpxASVfEjYRIkwedmEeQt)
					{
						int num4;
						if (mZPblCaonGfFNpAbwrdxIGAubRsD >= 0)
						{
							num2 = -1081718684;
							num4 = num2;
						}
						else
						{
							num2 = -1081718676;
							num4 = num2;
						}
						continue;
					}
					goto case 4;
				case 8:
					if (num >= xLMDqQIYXvVUFaJsLUAZDnTPaup.Length)
					{
						int num5;
						if (mZPblCaonGfFNpAbwrdxIGAubRsD < 0)
						{
							num2 = -1081718681;
							num5 = num2;
						}
						else
						{
							num2 = -1081718687;
							num5 = num2;
						}
						continue;
					}
					goto case 9;
				case 3:
					OwGojoMsEKNSlIXhtNyGfyxZFfS();
					return;
				case 10:
					if (!pxdVJyAGwTQNGJDRzUSBDhXjucu)
					{
						int num3;
						if (!UNCDhikBVajwTkKrWKjlDBeTSzFD)
						{
							num2 = -1081718684;
							num3 = num2;
						}
						else
						{
							num2 = -1081718683;
							num3 = num2;
						}
						continue;
					}
					goto case 3;
				case 7:
					fmMiJjVGXnGTxpplqIQTirVAuIJU();
					num2 = -1081718681;
					continue;
				case 9:
					xLMDqQIYXvVUFaJsLUAZDnTPaup[num].Update();
					num++;
					num2 = -1081718674;
					continue;
				case 2:
					return;
				}
				break;
			}
		}
	}

	public void UpdateDevices(UpdateLoopType updateLoop)
	{
		if (!yCIfoAipTphniepDsrKPaDRNhiMJ)
		{
			goto IL_0008;
		}
		goto IL_0050;
		IL_0008:
		int num = -133336482;
		goto IL_000d;
		IL_000d:
		int num2 = default(int);
		int count = default(int);
		while (true)
		{
			switch (num ^ -133336483)
			{
			case 4:
				break;
			case 1:
			{
				HjEeADgBkBgKtjfHEBuMcIVikmys hjEeADgBkBgKtjfHEBuMcIVikmys = DhZbdMKNkujxkBYZovsLjyUUFhq[num2];
				if (hjEeADgBkBgKtjfHEBuMcIVikmys != null)
				{
					hjEeADgBkBgKtjfHEBuMcIVikmys.FFYEDujhZPZIRSsDbLkeXQkxTZI(updateLoop);
					num = -133336481;
					continue;
				}
				goto case 2;
			}
			case 5:
				goto IL_0050;
			case 3:
				return;
			case 2:
				num2++;
				num = -133336483;
				continue;
			default:
				if (num2 >= count)
				{
					return;
				}
				goto case 1;
			}
			break;
		}
		goto IL_0008;
		IL_0050:
		count = DhZbdMKNkujxkBYZovsLjyUUFhq.Count;
		num2 = 0;
		num = -133336483;
		goto IL_000d;
	}

	public void UpdateFinished()
	{
		if (!yCIfoAipTphniepDsrKPaDRNhiMJ)
		{
			goto IL_0008;
		}
		goto IL_005b;
		IL_0008:
		int num = 1598144644;
		goto IL_000d;
		IL_000d:
		int num2 = default(int);
		int count = default(int);
		while (true)
		{
			switch (num ^ 0x5F41C080)
			{
			case 2:
				break;
			case 4:
				return;
			case 5:
			{
				HjEeADgBkBgKtjfHEBuMcIVikmys hjEeADgBkBgKtjfHEBuMcIVikmys = DhZbdMKNkujxkBYZovsLjyUUFhq[num2];
				if (hjEeADgBkBgKtjfHEBuMcIVikmys != null)
				{
					hjEeADgBkBgKtjfHEBuMcIVikmys.fHvlAyzcxwcbEJYkeBnphlWsGSD();
					num = 1598144641;
					continue;
				}
				goto case 1;
			}
			case 0:
				goto IL_005b;
			case 1:
				num2++;
				num = 1598144646;
				continue;
			case 3:
				num2 = 0;
				num = 1598144646;
				continue;
			default:
				if (num2 >= count)
				{
					return;
				}
				goto case 5;
			}
			break;
		}
		goto IL_0008;
		IL_005b:
		count = DhZbdMKNkujxkBYZovsLjyUUFhq.Count;
		num = 1598144643;
		goto IL_000d;
	}

	public IList<T> GetJoysticks<T>() where T : class
	{
		return mQysYMoqGgKJhphNVcrHAvmChbvV as IList<T>;
	}

	private List<TPOFglCEUenQueqhakDnrjLmVbgq> bVfvLqacePuaRPmfIxvTjQcwpeP(bool P_0)
	{
		maMEuFlKkCnUlYWUxHRsLlHhaBq maMEuFlKkCnUlYWUxHRsLlHhaBq2 = new maMEuFlKkCnUlYWUxHRsLlHhaBq();
		if (!yCIfoAipTphniepDsrKPaDRNhiMJ)
		{
			goto IL_000f;
		}
		DaEbHAPZwfTZBYzVQOhplfuewae();
		List<gEWwYLSxPEAKISAVsGBuSNYvGrOE> list = null;
		List<TPOFglCEUenQueqhakDnrjLmVbgq> list2 = new List<TPOFglCEUenQueqhakDnrjLmVbgq>();
		CWmCEPYIgUXCxKGQWVHoUPuxRlN = MRhgYYHOweuvAInIHkBvoaxwUcWn();
		int num = 1581754468;
		goto IL_0014;
		IL_0014:
		Predicate<string> predicate = default(Predicate<string>);
		XkpSoMzBWrjwHXyBbrXWShfYboE xkpSoMzBWrjwHXyBbrXWShfYboE = default(XkpSoMzBWrjwHXyBbrXWShfYboE);
		while (true)
		{
			switch (num ^ 0x5E47A864)
			{
			case 2:
				break;
			case 1:
				return new List<TPOFglCEUenQueqhakDnrjLmVbgq>();
			case 0:
				if (0 == 0)
				{
					list = MqTiLaFHDtnFUlOZwClsCzFjNOeu.mWaBVmHDGRsAnnQWUJOVZDSsDGAA(P_0);
					num = 1581754464;
					continue;
				}
				goto default;
			case 4:
			{
				bool flag = true;
				num = 1581754471;
				continue;
			}
			default:
			{
				if (list == null)
				{
					list = new List<gEWwYLSxPEAKISAVsGBuSNYvGrOE>();
				}
				try
				{
					maMEuFlKkCnUlYWUxHRsLlHhaBq2.GkVsBWErbpRMQuJRLfGZmQcjMLD = xJrcpabxFNJEeLKxzDoQfzegzEjy.ZFlFaOdoCSUuDlakJUzJGrreFGC();
				}
				catch (Exception ex)
				{
					maMEuFlKkCnUlYWUxHRsLlHhaBq2.GkVsBWErbpRMQuJRLfGZmQcjMLD = new List<xJrcpabxFNJEeLKxzDoQfzegzEjy.HgZMwhsohjWIBboQuvWWFfRgqgD>();
					Rewired.Logger.LogError("Exception getting HID device list.\n" + ex);
				}
				List<string> list3 = new List<string>();
				int num2 = 0;
				int num3 = 0;
				while (true)
				{
					IL_01f5:
					if (num3 < list.Count)
					{
						TPOFglCEUenQueqhakDnrjLmVbgq tPOFglCEUenQueqhakDnrjLmVbgq = null;
						try
						{
							gEWwYLSxPEAKISAVsGBuSNYvGrOE gEWwYLSxPEAKISAVsGBuSNYvGrOE2 = list[num3];
							if (list[num3] != null)
							{
								while (gEWwYLSxPEAKISAVsGBuSNYvGrOE2.DeviceType == QTBMtemSTKEFyypUdDxnYBkZCjsF.BdxbQpdhxedMbOCtPJkbSeZAwWGg)
								{
									while (true)
									{
										IL_0124:
										mIFFTdrbNcbzbukmuqHJRmmAKeH mIFFTdrbNcbzbukmuqHJRmmAKeH2 = gEWwYLSxPEAKISAVsGBuSNYvGrOE2 as mIFFTdrbNcbzbukmuqHJRmmAKeH;
										int num4 = 1581754470;
										while (true)
										{
											switch (num4 ^ 0x5E47A864)
											{
											case 0:
												num4 = 1581754467;
												continue;
											case 4:
												break;
											case 6:
												goto IL_0124;
											case 3:
												tPOFglCEUenQueqhakDnrjLmVbgq = sxPAeIAFcHyEBkGATGrYiyDuyxe(gEWwYLSxPEAKISAVsGBuSNYvGrOE2.Handle, mIFFTdrbNcbzbukmuqHJRmmAKeH2, maMEuFlKkCnUlYWUxHRsLlHhaBq2.GkVsBWErbpRMQuJRLfGZmQcjMLD, list3, num2);
												num4 = 1581754476;
												continue;
											case 5:
												list2.Add(tPOFglCEUenQueqhakDnrjLmVbgq);
												num4 = 1581754469;
												continue;
											case 8:
												goto IL_0169;
											case 7:
												goto IL_0181;
											case 2:
												if (mIFFTdrbNcbzbukmuqHJRmmAKeH2 == null)
												{
													break;
												}
												goto case 3;
											default:
												num2++;
												break;
											}
											break;
											IL_0169:
											int num5;
											if (tPOFglCEUenQueqhakDnrjLmVbgq == null)
											{
												num4 = 1581754464;
												num5 = num4;
											}
											else
											{
												num4 = 1581754465;
												num5 = num4;
											}
										}
										break;
									}
									break;
									IL_0181:;
								}
							}
						}
						catch (Exception ex2)
						{
							Rewired.Logger.LogError("An exception occurred while initializing HID device! This device will be non-functional.\n" + ex2.Message);
						}
						num3++;
						goto IL_01cf;
					}
					if (ZlGbTCkxQRChOIofeffCYHRKxiuW.useXInput)
					{
						break;
					}
					predicate = null;
					xkpSoMzBWrjwHXyBbrXWShfYboE = new XkpSoMzBWrjwHXyBbrXWShfYboE();
					int num6 = 1581754469;
					goto IL_01d4;
					IL_01d4:
					while (true)
					{
						int num9;
						switch (num6 ^ 0x5E47A864)
						{
						case 4:
							break;
						case 2:
							goto IL_01f5;
						case 1:
							xkpSoMzBWrjwHXyBbrXWShfYboE.TwFGIonUPKlwPFboAbFGZdhKLtr = maMEuFlKkCnUlYWUxHRsLlHhaBq2;
							xkpSoMzBWrjwHXyBbrXWShfYboE.XZPCSfwdMWYhFdBcAnWAbWLNeEC = 0;
							num6 = 1581754468;
							continue;
						default:
						{
							TPOFglCEUenQueqhakDnrjLmVbgq tPOFglCEUenQueqhakDnrjLmVbgq2 = null;
							try
							{
								if (predicate == null)
								{
									predicate = xkpSoMzBWrjwHXyBbrXWShfYboE.QuiaNwyiGHoKdAQrKuAIujqogzy;
								}
								if (string.IsNullOrEmpty(list3.Find(predicate)))
								{
									while (true)
									{
										IL_02b6:
										tPOFglCEUenQueqhakDnrjLmVbgq2 = UGULpDnGYhqUzvMHpqlBfeZirxV(maMEuFlKkCnUlYWUxHRsLlHhaBq2.GkVsBWErbpRMQuJRLfGZmQcjMLD[xkpSoMzBWrjwHXyBbrXWShfYboE.XZPCSfwdMWYhFdBcAnWAbWLNeEC], num2);
										int num7 = 1581754464;
										while (true)
										{
											switch (num7 ^ 0x5E47A864)
											{
											case 3:
												num7 = 1581754470;
												continue;
											case 0:
												goto end_IL_0277;
											case 4:
											{
												int num8;
												if (tPOFglCEUenQueqhakDnrjLmVbgq2 != null)
												{
													num7 = 1581754469;
													num8 = num7;
												}
												else
												{
													num7 = 1581754468;
													num8 = num7;
												}
												continue;
											}
											case 2:
												break;
											default:
												list2.Add(tPOFglCEUenQueqhakDnrjLmVbgq2);
												num2++;
												goto end_IL_0277;
											}
											goto IL_02b6;
											continue;
											end_IL_0277:
											break;
										}
										break;
									}
								}
							}
							catch (Exception ex3)
							{
								Rewired.Logger.LogError("An exception occurred while initializing HID device! This device will be non-functional." + ex3.Message);
							}
							xkpSoMzBWrjwHXyBbrXWShfYboE.XZPCSfwdMWYhFdBcAnWAbWLNeEC++;
							goto IL_0313;
						}
						case 0:
							goto IL_0331;
							IL_0313:
							num9 = 1581754470;
							goto IL_0318;
							IL_0318:
							switch (num9 ^ 0x5E47A864)
							{
							case 0:
								break;
							case 2:
								goto IL_0331;
							default:
								goto end_IL_01f5;
							}
							goto IL_0313;
							IL_0331:
							if (xkpSoMzBWrjwHXyBbrXWShfYboE.XZPCSfwdMWYhFdBcAnWAbWLNeEC < maMEuFlKkCnUlYWUxHRsLlHhaBq2.GkVsBWErbpRMQuJRLfGZmQcjMLD.Count)
							{
								goto default;
							}
							num9 = 1581754469;
							goto IL_0318;
						}
						break;
					}
					goto IL_01cf;
					IL_01cf:
					num6 = 1581754470;
					goto IL_01d4;
					continue;
					end_IL_01f5:
					break;
				}
				return list2;
			}
			}
			break;
		}
		goto IL_000f;
		IL_000f:
		num = 1581754469;
		goto IL_0014;
	}

	private static void YGYdhgSowikPsbOYLZzBOJThvWy(ref List<TPOFglCEUenQueqhakDnrjLmVbgq> P_0, List<TPOFglCEUenQueqhakDnrjLmVbgq> P_1)
	{
		if (P_0 == null)
		{
			P_0 = new List<TPOFglCEUenQueqhakDnrjLmVbgq>();
			goto IL_000e;
		}
		goto IL_0126;
		IL_0126:
		int num;
		int num2;
		if (P_1 != null)
		{
			num = -730793851;
			num2 = num;
		}
		else
		{
			num = -730793849;
			num2 = num;
		}
		goto IL_0013;
		IL_000e:
		num = -730793843;
		goto IL_0013;
		IL_0013:
		int count = default(int);
		int count2 = default(int);
		TPOFglCEUenQueqhakDnrjLmVbgq[] array = default(TPOFglCEUenQueqhakDnrjLmVbgq[]);
		int num4 = default(int);
		int num3 = default(int);
		while (true)
		{
			switch (num ^ -730793842)
			{
			case 13:
				break;
			default:
				return;
			case 0:
				count = P_1.Count;
				count2 = P_0.Count;
				array = P_1.ToArray();
				if (array.Length > 0)
				{
					Array.Sort(array, WezLgdtWhXAxSkBBAcvyNbSLacEc);
					num = -730793847;
					continue;
				}
				goto case 7;
			case 2:
				num4++;
				num = -730793845;
				continue;
			case 9:
				P_1 = new List<TPOFglCEUenQueqhakDnrjLmVbgq>();
				num = -730793851;
				continue;
			case 8:
				num3 = 0;
				num = -730793852;
				continue;
			case 10:
				goto IL_00c6;
			case 1:
				num3++;
				num = -730793852;
				continue;
			case 14:
				if (array[num3] != null)
				{
					array[num3].bGLkBDHnpemvyBRWVRTaJLBCCpw(num3);
					P_0.Add(array[num3]);
					num = -730793841;
					continue;
				}
				goto case 1;
			case 4:
				P_0.Clear();
				num = -730793850;
				continue;
			case 3:
				goto IL_0126;
			case 6:
			{
				coXNVgzlUkmqXqShQAztpzVLhec coXNVgzlUkmqXqShQAztpzVLhec2 = new coXNVgzlUkmqXqShQAztpzVLhec();
				coXNVgzlUkmqXqShQAztpzVLhec2.RrqRSNwXejBavSbadAAmkjSAVycm = P_0[num4];
				if (coXNVgzlUkmqXqShQAztpzVLhec2.RrqRSNwXejBavSbadAAmkjSAVycm != null && Array.Find(array, coXNVgzlUkmqXqShQAztpzVLhec2.nMXUVQuCcApcoebtidYASJlyMOg) == null)
				{
					coXNVgzlUkmqXqShQAztpzVLhec2.RrqRSNwXejBavSbadAAmkjSAVycm.Dispose();
					num = -730793844;
					continue;
				}
				goto case 2;
			}
			case 11:
				if (P_1.Count == 0)
				{
					P_0.ForEach(delegate(TPOFglCEUenQueqhakDnrjLmVbgq tPOFglCEUenQueqhakDnrjLmVbgq)
					{
						tPOFglCEUenQueqhakDnrjLmVbgq.Dispose();
					});
					P_0.Clear();
					return;
				}
				goto case 0;
			case 5:
				goto IL_01ce;
			case 7:
				num4 = 0;
				num = -730793845;
				continue;
			case 12:
				return;
			}
			break;
			IL_01ce:
			int num5;
			if (num4 < count2)
			{
				num = -730793848;
				num5 = num;
			}
			else
			{
				num = -730793846;
				num5 = num;
			}
			continue;
			IL_00c6:
			int num6;
			if (num3 < count)
			{
				num = -730793856;
				num6 = num;
			}
			else
			{
				num = -730793854;
				num6 = num;
			}
		}
		goto IL_000e;
	}

	private List<gEWwYLSxPEAKISAVsGBuSNYvGrOE> lDMjNLdsvSqITaHodmxzMvadAgkK()
	{
		List<gEWwYLSxPEAKISAVsGBuSNYvGrOE> list = new List<gEWwYLSxPEAKISAVsGBuSNYvGrOE>();
		try
		{
			foreach (awBDVVAQrVojolizTQZQDabqRnX item in xJrcpabxFNJEeLKxzDoQfzegzEjy.KEDOmRnnXcsqMQcpTJzkEnSKMMs())
			{
				try
				{
					list.Add(new mIFFTdrbNcbzbukmuqHJRmmAKeH
					{
						DeviceName = fTvFFMKHyahmXrAOzQxsmenVpjI.bAsiNcmvQWMiTuiNtHATkYhgXzTP(item.DevicePath),
						DeviceType = QTBMtemSTKEFyypUdDxnYBkZCjsF.BdxbQpdhxedMbOCtPJkbSeZAwWGg,
						Handle = IntPtr.Zero,
						ProductId = item.Attributes.ProductId,
						VendorId = item.Attributes.VendorId,
						VersionNumber = item.Attributes.Version,
						UsagePage = (qIbMLJZATiXoZkJFsjBRfhcWBevI)item.Capabilities.UsagePage,
						Usage = (HnEKTVdMYbbGrySWPQiZMYNvwN)item.Capabilities.Usage
					});
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		return list;
	}

	private TPOFglCEUenQueqhakDnrjLmVbgq sxPAeIAFcHyEBkGATGrYiyDuyxe(IntPtr P_0, mIFFTdrbNcbzbukmuqHJRmmAKeH P_1, IList<xJrcpabxFNJEeLKxzDoQfzegzEjy.HgZMwhsohjWIBboQuvWWFfRgqgD> P_2, List<string> P_3, int P_4)
	{
		ushort num = (ushort)P_1.UsagePage;
		ushort num2 = (ushort)P_1.Usage;
		string deviceName = P_1.DeviceName;
		if (!eBLyxyvdmOrqBsHCGKNbSCSuDVg(num, num2))
		{
			return null;
		}
		string text = fTvFFMKHyahmXrAOzQxsmenVpjI.bAsiNcmvQWMiTuiNtHATkYhgXzTP(deviceName);
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		P_3.Add(text);
		OzVqfYeaMNEXzwFiuZOmGiQFiUf ozVqfYeaMNEXzwFiuZOmGiQFiUf = xJrcpabxFNJEeLKxzDoQfzegzEjy.nUIrDsrLbmAPfismjizkwjhdDsH(P_2, text, StringComparison.OrdinalIgnoreCase);
		if (ozVqfYeaMNEXzwFiuZOmGiQFiUf == null)
		{
			ozVqfYeaMNEXzwFiuZOmGiQFiUf = SQYxQCXyTaQaUetxSLvklCTicRF.wATWsQinaQgtyfhaGakrKFkTqfxU(P_0, deviceName);
		}
		if (num == 1 && (num2 == 4 || num2 == 5))
		{
			string text2 = ozVqfYeaMNEXzwFiuZOmGiQFiUf.yFxOGXcaegbEFjxkNZdqsTwHOBxe();
			string bluetoothDeviceName = ozVqfYeaMNEXzwFiuZOmGiQFiUf.BluetoothDeviceName;
			Guid guid = MiscTools.CreateHIDProductGuid(ozVqfYeaMNEXzwFiuZOmGiQFiUf.Attributes.VendorId, ozVqfYeaMNEXzwFiuZOmGiQFiUf.Attributes.ProductId);
			if (YdyMnIcwNBPdrenZBGWhZdOBHpZh.EredcQKydBpZmabzqbkjxmmHdtjf(guid, text2, bluetoothDeviceName))
			{
				P_3.RemoveAt(P_3.Count - 1);
				return null;
			}
		}
		return bbUocgDoJKHCOdDcKYXySofQIqKS(dBNoePwdKYyWerGenDMKaakIaLZh.zWzEPHbAHbpGVHtrMXDgFRmSdpHl, ozVqfYeaMNEXzwFiuZOmGiQFiUf, P_0, num, num2, P_4);
	}

	private TPOFglCEUenQueqhakDnrjLmVbgq UGULpDnGYhqUzvMHpqlBfeZirxV(xJrcpabxFNJEeLKxzDoQfzegzEjy.HgZMwhsohjWIBboQuvWWFfRgqgD P_0, int P_1)
	{
		awBDVVAQrVojolizTQZQDabqRnX awBDVVAQrVojolizTQZQDabqRnX2 = xJrcpabxFNJEeLKxzDoQfzegzEjy.liDgMZIvvyEcQqPySiFyJpfcchOf(P_0);
		if (awBDVVAQrVojolizTQZQDabqRnX2 == null)
		{
			return null;
		}
		ushort num = (ushort)awBDVVAQrVojolizTQZQDabqRnX2.Capabilities.UsagePage;
		ushort num2 = (ushort)awBDVVAQrVojolizTQZQDabqRnX2.Capabilities.Usage;
		if (!eBLyxyvdmOrqBsHCGKNbSCSuDVg(num, num2))
		{
			return null;
		}
		bool flag = false;
		if (num == 1 && (num2 == 4 || num2 == 5))
		{
			flag = YdyMnIcwNBPdrenZBGWhZdOBHpZh.EredcQKydBpZmabzqbkjxmmHdtjf(MiscTools.CreateHIDProductGuid(awBDVVAQrVojolizTQZQDabqRnX2.Attributes.VendorId, awBDVVAQrVojolizTQZQDabqRnX2.Attributes.ProductId), awBDVVAQrVojolizTQZQDabqRnX2.yFxOGXcaegbEFjxkNZdqsTwHOBxe(), awBDVVAQrVojolizTQZQDabqRnX2.BluetoothDeviceName);
		}
		if (!flag)
		{
			return null;
		}
		return bbUocgDoJKHCOdDcKYXySofQIqKS(dBNoePwdKYyWerGenDMKaakIaLZh.FjwHpPmKTwjrHXNHzkJWBHwYlYN, awBDVVAQrVojolizTQZQDabqRnX2, IntPtr.Zero, num, num2, P_1);
	}

	private TPOFglCEUenQueqhakDnrjLmVbgq bbUocgDoJKHCOdDcKYXySofQIqKS(dBNoePwdKYyWerGenDMKaakIaLZh P_0, OzVqfYeaMNEXzwFiuZOmGiQFiUf P_1, IntPtr P_2, ushort P_3, ushort P_4, int P_5)
	{
		bool flag = P_3 != 1 || !RZiUqimtzQCfzsOYcVmYjWAZWPR.PsKdoDrovZzjqJBEzLcbdrndsuQ.RKREBSilKbZMLKViWyEvVzXwkPsm(P_4);
		if (ZlGbTCkxQRChOIofeffCYHRKxiuW.useXInput && P_3 == 1 && (P_4 == 4 || P_4 == 5))
		{
			string text = P_1.yFxOGXcaegbEFjxkNZdqsTwHOBxe();
			string bluetoothDeviceName = P_1.BluetoothDeviceName;
			Guid guid = MiscTools.CreateHIDProductGuid(P_1.Attributes.VendorId, P_1.Attributes.ProductId);
			if (zzOqSwMfghlPxHdUtRXPrOVahKl.MaQsCwUpHxzwhotZWnHQMwdFcRm(P_1.DevicePath, text, bluetoothDeviceName, guid))
			{
				return null;
			}
		}
		TPOFglCEUenQueqhakDnrjLmVbgq tPOFglCEUenQueqhakDnrjLmVbgq = ODInkuxiJQaUAzORvJHYcVcMigY(P_0, P_2, P_5, P_1, DhZbdMKNkujxkBYZovsLjyUUFhq, flag);
		if (tPOFglCEUenQueqhakDnrjLmVbgq == null || !tPOFglCEUenQueqhakDnrjLmVbgq.HasElements)
		{
			if (tPOFglCEUenQueqhakDnrjLmVbgq != null && !tPOFglCEUenQueqhakDnrjLmVbgq.HasElements)
			{
				tPOFglCEUenQueqhakDnrjLmVbgq.Dispose();
			}
			return null;
		}
		return tPOFglCEUenQueqhakDnrjLmVbgq;
	}

	private bool eBLyxyvdmOrqBsHCGKNbSCSuDVg(ushort P_0, ushort P_1)
	{
		int num = 0;
		while (num < ynFnLhcMEIvmOEUUVQZSzzGuUtY.Length)
		{
			while (true)
			{
				int num2;
				if (ynFnLhcMEIvmOEUUVQZSzzGuUtY[num].FBgoHDDONaucfYfClsJQmgJRgl == P_0)
				{
					num2 = 508064742;
					goto IL_0009;
				}
				goto IL_004d;
				IL_003c:
				if (ynFnLhcMEIvmOEUUVQZSzzGuUtY[num].FWQRxpNIbdqGOeuqmJHMPKVZrZs == P_1)
				{
					return true;
				}
				goto IL_004d;
				IL_004d:
				num++;
				num2 = 508064741;
				goto IL_0009;
				IL_0009:
				while (true)
				{
					switch (num2 ^ 0x1E4873E4)
					{
					case 0:
						num2 = 508064743;
						continue;
					case 3:
						break;
					case 2:
						goto IL_003c;
					default:
						goto end_IL_0026;
					}
					break;
				}
				continue;
				end_IL_0026:
				break;
			}
		}
		return false;
	}

	private int MRhgYYHOweuvAInIHkBvoaxwUcWn()
	{
		try
		{
			return xJrcpabxFNJEeLKxzDoQfzegzEjy.IEXPmNlUXBsTuJqdeOElowtTGYY();
		}
		catch
		{
			return 0;
		}
	}

	private int VALpBlQZpCIluQnRYtVKkCgseExH()
	{
		try
		{
			return xJrcpabxFNJEeLKxzDoQfzegzEjy.IEXPmNlUXBsTuJqdeOElowtTGYY(ref rKniTAhBAmHHsAzTytClBGfKgoJ, wemVerhbzOcuIoLsucNIvVJbxxJ);
		}
		catch (Exception)
		{
			return 0;
		}
	}

	private TPOFglCEUenQueqhakDnrjLmVbgq ODInkuxiJQaUAzORvJHYcVcMigY(dBNoePwdKYyWerGenDMKaakIaLZh P_0, IntPtr P_1, int P_2, OzVqfYeaMNEXzwFiuZOmGiQFiUf P_3, List<TPOFglCEUenQueqhakDnrjLmVbgq> P_4, bool P_5)
	{
		pQzieCfhhenHDFiCkEmiJCzVKBgm pQzieCfhhenHDFiCkEmiJCzVKBgm2 = new pQzieCfhhenHDFiCkEmiJCzVKBgm();
		pQzieCfhhenHDFiCkEmiJCzVKBgm2.xwJLxrglVphteBhatdJSapIqbEaF = P_3;
		if (P_5 && !siSJeNGZdOVsVQoUSFTHNlfuJCb)
		{
			return null;
		}
		try
		{
			if (siSJeNGZdOVsVQoUSFTHNlfuJCb)
			{
				if (P_4 != null)
				{
					for (int i = 0; i < P_4.Count; i++)
					{
						if (P_4[i] is mAktYGdXOBtSOXijAIoQcISyNuj mAktYGdXOBtSOXijAIoQcISyNuj2 && mAktYGdXOBtSOXijAIoQcISyNuj2.Driver != null && !(pQzieCfhhenHDFiCkEmiJCzVKBgm2.xwJLxrglVphteBhatdJSapIqbEaF.InstanceId != mAktYGdXOBtSOXijAIoQcISyNuj2.HidDevice.InstanceId))
						{
							mAktYGdXOBtSOXijAIoQcISyNuj2.bGLkBDHnpemvyBRWVRTaJLBCCpw(P_2);
							return mAktYGdXOBtSOXijAIoQcISyNuj2;
						}
					}
				}
				HIDDeviceDriver.DriverType driverType = HIDDeviceDriver.FindDriverId(pQzieCfhhenHDFiCkEmiJCzVKBgm2.xwJLxrglVphteBhatdJSapIqbEaF.Attributes.VendorId, pQzieCfhhenHDFiCkEmiJCzVKBgm2.xwJLxrglVphteBhatdJSapIqbEaF.Attributes.ProductId);
				if (driverType != HIDDeviceDriver.DriverType.XHUTYEIfTgeCBgXrVRVbPfGzuhN)
				{
					HidOutputReportHandler hidOutputReportHandler = new HidOutputReportHandler(pQzieCfhhenHDFiCkEmiJCzVKBgm2.xwJLxrglVphteBhatdJSapIqbEaF.ThCBYvbcvHbKBcbWFoWasTHMqDWi);
					HIDDeviceDriver driver = HIDDeviceDriver.GetDriver(driverType, new HIDDeviceDriver.InitArgs(BnNkbgybnGDKKbEtlthkxBlHLlXR, (!pQzieCfhhenHDFiCkEmiJCzVKBgm2.xwJLxrglVphteBhatdJSapIqbEaF.IsBluetoothDevice) ? DeviceConnectionType.AUFMEslnTcAdZkQNSggaAEcbCtYd : DeviceConnectionType.sFJAQBfZHNpXaWTCudNqcxaaCMg, 65535, -65535, -1, 4500, pQzieCfhhenHDFiCkEmiJCzVKBgm2.xwJLxrglVphteBhatdJSapIqbEaF.Capabilities.InputReportByteLength, pQzieCfhhenHDFiCkEmiJCzVKBgm2.xwJLxrglVphteBhatdJSapIqbEaF.Capabilities.OutputReportByteLength, pQzieCfhhenHDFiCkEmiJCzVKBgm2.xwJLxrglVphteBhatdJSapIqbEaF.ThCBYvbcvHbKBcbWFoWasTHMqDWi, hidOutputReportHandler.WriteReport, pQzieCfhhenHDFiCkEmiJCzVKBgm2.PHKkroQhpYliCMOMfBpWzNidneX));
					if (driver != null)
					{
						return new mAktYGdXOBtSOXijAIoQcISyNuj(P_2, P_0, P_1, pQzieCfhhenHDFiCkEmiJCzVKBgm2.xwJLxrglVphteBhatdJSapIqbEaF, driver, hidOutputReportHandler);
					}
				}
				if (P_5)
				{
					return null;
				}
			}
		}
		catch
		{
			Rewired.Logger.LogWarning("Exception creating custom driver joystick. Will fall back to normal HID joystick.");
		}
		try
		{
			if (P_4 != null)
			{
				for (int j = 0; j < P_4.Count; j++)
				{
					if (P_4[j] is vbkjNjHATCWdCHIMnyXZzpSXcCp vbkjNjHATCWdCHIMnyXZzpSXcCp2 && !(pQzieCfhhenHDFiCkEmiJCzVKBgm2.xwJLxrglVphteBhatdJSapIqbEaF.InstanceId != vbkjNjHATCWdCHIMnyXZzpSXcCp2.HidDevice.InstanceId))
					{
						vbkjNjHATCWdCHIMnyXZzpSXcCp2.bGLkBDHnpemvyBRWVRTaJLBCCpw(P_2);
						return vbkjNjHATCWdCHIMnyXZzpSXcCp2;
					}
				}
			}
			return new vbkjNjHATCWdCHIMnyXZzpSXcCp(P_2, P_0, P_1, pQzieCfhhenHDFiCkEmiJCzVKBgm2.xwJLxrglVphteBhatdJSapIqbEaF);
		}
		catch
		{
			return null;
		}
	}

	private TPOFglCEUenQueqhakDnrjLmVbgq tHoqVZjuKaYSABWtGjMbKFqzcXh(dBNoePwdKYyWerGenDMKaakIaLZh P_0, IntPtr P_1)
	{
		if (DhZbdMKNkujxkBYZovsLjyUUFhq == null)
		{
			goto IL_0008;
		}
		int num = 0;
		int num2 = -1761767698;
		goto IL_000d;
		IL_000d:
		TPOFglCEUenQueqhakDnrjLmVbgq tPOFglCEUenQueqhakDnrjLmVbgq = default(TPOFglCEUenQueqhakDnrjLmVbgq);
		while (true)
		{
			switch (num2 ^ -1761767702)
			{
			case 0:
				break;
			case 3:
				return null;
			case 2:
				tPOFglCEUenQueqhakDnrjLmVbgq = DhZbdMKNkujxkBYZovsLjyUUFhq[num];
				num2 = -1761767697;
				continue;
			case 1:
				if (!(tPOFglCEUenQueqhakDnrjLmVbgq.JoystickSourceHandle != P_1))
				{
					return tPOFglCEUenQueqhakDnrjLmVbgq;
				}
				goto IL_0061;
			case 5:
				if (tPOFglCEUenQueqhakDnrjLmVbgq.JoystickSourceType == P_0)
				{
					num2 = -1761767701;
					continue;
				}
				goto IL_0061;
			default:
				{
					if (num >= DhZbdMKNkujxkBYZovsLjyUUFhq.Count)
					{
						return null;
					}
					goto case 2;
				}
				IL_0061:
				num++;
				num2 = -1761767698;
				continue;
			}
			break;
		}
		goto IL_0008;
		IL_0008:
		num2 = -1761767703;
		goto IL_000d;
	}

	private unsafe TPOFglCEUenQueqhakDnrjLmVbgq aWPeYKTyGIMZfSvQPNjGlmqBEYJ(IntPtr P_0)
	{
		YksGHYKteMuhDXToEsEFZvCVfCJ.EIhrJeuUdIWMmYoqcprGGywjUIL(P_0, 536870919u, IntPtr.Zero, out var num);
		if (num == 0)
		{
			return null;
		}
		char* value = stackalloc char[(int)num];
		TPOFglCEUenQueqhakDnrjLmVbgq tPOFglCEUenQueqhakDnrjLmVbgq = default(TPOFglCEUenQueqhakDnrjLmVbgq);
		string text = default(string);
		int num3 = default(int);
		int length = default(int);
		while (true)
		{
			int num2 = -797536702;
			while (true)
			{
				int num4;
				switch (num2 ^ -797536696)
				{
				case 8:
					break;
				case 11:
					num2 = -797536689;
					continue;
				case 0:
					return null;
				case 2:
					if (tPOFglCEUenQueqhakDnrjLmVbgq.JoystickSourceType == dBNoePwdKYyWerGenDMKaakIaLZh.zWzEPHbAHbpGVHtrMXDgFRmSdpHl && tPOFglCEUenQueqhakDnrjLmVbgq.HidDevice.DevicePathStripped.Equals(text, StringComparison.OrdinalIgnoreCase))
					{
						num2 = -797536700;
						continue;
					}
					num3++;
					num2 = -797536689;
					continue;
				case 10:
					YksGHYKteMuhDXToEsEFZvCVfCJ.EIhrJeuUdIWMmYoqcprGGywjUIL(P_0, 536870919u, new IntPtr(value), out num);
					if ((int)num <= 0)
					{
						num2 = -797536703;
						continue;
					}
					num4 = (int)(num - 1);
					goto IL_015c;
				case 5:
					if (DhZbdMKNkujxkBYZovsLjyUUFhq != null)
					{
						text = fTvFFMKHyahmXrAOzQxsmenVpjI.bAsiNcmvQWMiTuiNtHATkYhgXzTP(text);
						num3 = 0;
						num2 = -797536701;
					}
					else
					{
						num2 = -797536696;
					}
					continue;
				case 12:
					tPOFglCEUenQueqhakDnrjLmVbgq.YiOIgfGkkpPDYepmwZfBIvBxhXC(P_0);
					return tPOFglCEUenQueqhakDnrjLmVbgq;
				case 1:
					text = string.Empty;
					num2 = -797536691;
					continue;
				case 6:
					tPOFglCEUenQueqhakDnrjLmVbgq = DhZbdMKNkujxkBYZovsLjyUUFhq[num3];
					num2 = -797536694;
					continue;
				case 4:
					text = new string(value, 0, length);
					num2 = -797536693;
					continue;
				case 3:
				{
					int num5;
					if (text.Length != 0)
					{
						num2 = -797536691;
						num5 = num2;
					}
					else
					{
						num2 = -797536695;
						num5 = num2;
					}
					continue;
				}
				case 9:
					num4 = 0;
					goto IL_015c;
				default:
					{
						if (num3 >= DhZbdMKNkujxkBYZovsLjyUUFhq.Count)
						{
							return null;
						}
						goto case 6;
					}
					IL_015c:
					length = num4;
					num2 = -797536692;
					continue;
				}
				break;
			}
		}
	}

	private static int WezLgdtWhXAxSkBBAcvyNbSLacEc(TPOFglCEUenQueqhakDnrjLmVbgq P_0, TPOFglCEUenQueqhakDnrjLmVbgq P_1)
	{
		if (!P_0.HidDevice.HasLocationInfo)
		{
			return 1;
		}
		if (!P_1.HidDevice.HasLocationInfo)
		{
			return -1;
		}
		int hubId = P_0.HidDevice.HubId;
		int hubId2 = P_1.HidDevice.HubId;
		if (hubId < hubId2)
		{
			goto IL_003a;
		}
		if (hubId > hubId2)
		{
			return 1;
		}
		int portId = P_0.HidDevice.PortId;
		int portId2 = P_1.HidDevice.PortId;
		int num = 884307001;
		goto IL_003f;
		IL_003f:
		while (true)
		{
			switch (num ^ 0x34B57439)
			{
			case 3:
				break;
			case 1:
				return -1;
			case 0:
				if (portId < portId2)
				{
					return -1;
				}
				if (portId > portId2)
				{
					goto IL_008d;
				}
				return 0;
			default:
				return 1;
			}
			break;
			IL_008d:
			num = 884307003;
		}
		goto IL_003a;
		IL_003a:
		num = 884307000;
		goto IL_003f;
	}

	private void DaEbHAPZwfTZBYzVQOhplfuewae()
	{
		GyTCZqFnTtPlqKgcTkHEcvJWJMGC gyTCZqFnTtPlqKgcTkHEcvJWJMGC = new GyTCZqFnTtPlqKgcTkHEcvJWJMGC();
		gyTCZqFnTtPlqKgcTkHEcvJWJMGC.xvYPGRaXRVZlwecANemUYNIlHnq = this;
		while (true)
		{
			int num = 458173198;
			while (true)
			{
				switch (num ^ 0x1B4F2B0D)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					if (rHccTXHaQHKgJspYXChoCFSBEVlf != mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
					{
						return;
					}
					goto case 2;
				case 2:
					gyTCZqFnTtPlqKgcTkHEcvJWJMGC.XewSQgMjCFaDNJiRryZdwxsRawl = false;
					mAQuhJhPOMChsAYOiuJgfFwykpyr(gyTCZqFnTtPlqKgcTkHEcvJWJMGC.YpYhglsBmdfIbdiaFEDrnTnGkCA, true);
					if (gyTCZqFnTtPlqKgcTkHEcvJWJMGC.XewSQgMjCFaDNJiRryZdwxsRawl)
					{
						goto IL_0061;
					}
					return;
				case 1:
					return;
				}
				break;
				IL_0061:
				Rewired.Logger.LogError("Failed to register HID devices.", requiredThreadSafety: true);
				num = 458173196;
			}
		}
	}

	private void DfXezXOigVceheHRnYuCDVoaFGZN()
	{
		hcUabNFLIdRXclfxcPlHiXjCxeDd hcUabNFLIdRXclfxcPlHiXjCxeDd2 = new hcUabNFLIdRXclfxcPlHiXjCxeDd();
		if (rHccTXHaQHKgJspYXChoCFSBEVlf != mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
		{
			goto IL_000e;
		}
		goto IL_0038;
		IL_000e:
		int num = 839221198;
		goto IL_0013;
		IL_0013:
		switch (num ^ 0x32057FCC)
		{
		case 0:
			break;
		default:
			return;
		case 2:
			return;
		case 1:
			goto IL_0038;
		case 3:
			return;
		}
		goto IL_000e;
		IL_0038:
		hcUabNFLIdRXclfxcPlHiXjCxeDd2.XewSQgMjCFaDNJiRryZdwxsRawl = false;
		mAQuhJhPOMChsAYOiuJgfFwykpyr(hcUabNFLIdRXclfxcPlHiXjCxeDd2.kYDWPITsNonbtdvCVVEZvKJTtTN, true);
		if (hcUabNFLIdRXclfxcPlHiXjCxeDd2.XewSQgMjCFaDNJiRryZdwxsRawl)
		{
			Rewired.Logger.LogError("Failed to unregister HID devices.", requiredThreadSafety: true);
			num = 839221199;
			goto IL_0013;
		}
	}

	private void OwGojoMsEKNSlIXhtNyGfyxZFfS()
	{
		uint num = default(uint);
		if (ReInput.isAllowedEditorWindowFocused)
		{
			if (rHccTXHaQHKgJspYXChoCFSBEVlf != mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
			{
				goto IL_00bc;
			}
			kCAXFYidwvFFfAGvqsKCviGEfdu(utNJDnvgtjyQuECjZnzMZfRDGij, out num);
			if (UNCDhikBVajwTkKrWKjlDBeTSzFD)
			{
				goto IL_002e;
			}
			goto IL_0121;
		}
		goto IL_017b;
		IL_017b:
		int num2;
		if (VoodlmKWYkBIcFdDQhKahZjCTAcc)
		{
			RmNhwHHYpUKqhveizaNycSxZhAOE();
			num2 = 972476350;
			goto IL_0033;
		}
		goto IL_01ab;
		IL_01ab:
		int num3;
		if (!bQkxPpnAfRwlFYUCstXQcrarWbi)
		{
			num2 = 972476343;
			num3 = num2;
		}
		else
		{
			num2 = 972476341;
			num3 = num2;
		}
		goto IL_0033;
		IL_002e:
		num2 = 972476344;
		goto IL_0033;
		IL_0033:
		IntPtr fZiGxbOkqzdsegVqpLGakKTGith = default(IntPtr);
		IntPtr noatZUCGfWQDABlGSjSzJjqRKVrg = default(IntPtr);
		bool flag = default(bool);
		bool flag2 = default(bool);
		while (true)
		{
			switch (num2 ^ 0x39F6CFBF)
			{
			case 0:
				break;
			default:
				return;
			case 11:
				if (fZiGxbOkqzdsegVqpLGakKTGith == IntPtr.Zero)
				{
					fZiGxbOkqzdsegVqpLGakKTGith = FZiGxbOkqzdsegVqpLGakKTGith;
					num2 = 972476349;
					continue;
				}
				goto case 2;
			case 5:
				if (VoodlmKWYkBIcFdDQhKahZjCTAcc)
				{
					goto IL_00a5;
				}
				goto case 14;
			case 13:
				goto IL_00bc;
			case 4:
				oEZeOTHXNlyMTlRjuWjoqxejiXe(noatZUCGfWQDABlGSjSzJjqRKVrg);
				num2 = 972476345;
				continue;
			case 14:
				if (noatZUCGfWQDABlGSjSzJjqRKVrg == IntPtr.Zero)
				{
					noatZUCGfWQDABlGSjSzJjqRKVrg = NoatZUCGfWQDABlGSjSzJjqRKVrg;
					num2 = 972476347;
					continue;
				}
				goto case 4;
			case 10:
				yXqDZcnOIyEjpzBqLHzgfUFcNSB();
				num2 = 972476343;
				continue;
			case 6:
				goto IL_0121;
			case 7:
				flag = !isRzzjqbTXPruoQOlSiHBQsIAkP(ControllerType.Mouse, utNJDnvgtjyQuECjZnzMZfRDGij, num, out noatZUCGfWQDABlGSjSzJjqRKVrg);
				num2 = 972476346;
				continue;
			case 9:
				goto IL_017b;
			case 3:
				goto IL_0193;
			case 1:
				goto IL_01ab;
			case 12:
				goto IL_01c7;
			case 2:
				JgyXYXTgFOAZHHCJtMLGOUiKTWw(fZiGxbOkqzdsegVqpLGakKTGith);
				return;
			case 8:
				return;
			}
			break;
			IL_0193:
			int num4;
			if (flag2)
			{
				num2 = 972476343;
				num4 = num2;
			}
			else
			{
				num2 = 972476340;
				num4 = num2;
			}
			continue;
			IL_00a5:
			int num5;
			if (flag)
			{
				num2 = 972476345;
				num5 = num2;
			}
			else
			{
				num2 = 972476337;
				num5 = num2;
			}
		}
		goto IL_002e;
		IL_0121:
		if (pxdVJyAGwTQNGJDRzUSBDhXjucu)
		{
			flag2 = !isRzzjqbTXPruoQOlSiHBQsIAkP(ControllerType.Keyboard, utNJDnvgtjyQuECjZnzMZfRDGij, num, out fZiGxbOkqzdsegVqpLGakKTGith);
			int num6;
			if (!bQkxPpnAfRwlFYUCstXQcrarWbi)
			{
				num2 = 972476340;
				num6 = num2;
			}
			else
			{
				num2 = 972476348;
				num6 = num2;
			}
			goto IL_0033;
		}
		return;
		IL_01c7:
		if (pxdVJyAGwTQNGJDRzUSBDhXjucu && !bQkxPpnAfRwlFYUCstXQcrarWbi)
		{
			nepBqwsCxIBfqpkKKysTMuTakZf();
		}
		return;
		IL_00bc:
		if (UNCDhikBVajwTkKrWKjlDBeTSzFD && !VoodlmKWYkBIcFdDQhKahZjCTAcc)
		{
			xmbDrUCeGHHFlfcceXtOZgstyWdC();
			num2 = 972476339;
			goto IL_0033;
		}
		goto IL_01c7;
	}

	private void gIeGOlbTCwOqngsQPBCXEPpnTZfZ()
	{
		double realTime = ReInput.realTime;
		if (realTime < bGYFtaiaaIhedSXWUujtkmmKiUt + 1.0)
		{
			goto IL_0019;
		}
		goto IL_0085;
		IL_0019:
		int num = -1271630309;
		goto IL_001e;
		IL_001e:
		IntPtr noatZUCGfWQDABlGSjSzJjqRKVrg = default(IntPtr);
		uint num2 = default(uint);
		IntPtr fZiGxbOkqzdsegVqpLGakKTGith = default(IntPtr);
		bool flag2 = default(bool);
		while (true)
		{
			bool flag;
			switch (num ^ -1271630306)
			{
			case 12:
				break;
			default:
				return;
			case 10:
				if (noatZUCGfWQDABlGSjSzJjqRKVrg == IntPtr.Zero)
				{
					noatZUCGfWQDABlGSjSzJjqRKVrg = NoatZUCGfWQDABlGSjSzJjqRKVrg;
					num = -1271630320;
					continue;
				}
				goto case 14;
			case 7:
				goto IL_0085;
			case 11:
				goto IL_0093;
			case 5:
				return;
			case 6:
				atajYjffcRjqhXvxzQtEMELRbrj();
				return;
			case 14:
				JKaWHnYRLJDFiDzAmSUXbBSygnQ();
				num = -1271630315;
				continue;
			case 9:
				nepBqwsCxIBfqpkKKysTMuTakZf();
				num = -1271630305;
				continue;
			case 3:
				goto IL_010b;
			case 4:
				goto IL_0132;
			case 8:
				flag = !isRzzjqbTXPruoQOlSiHBQsIAkP(ControllerType.Mouse, utNJDnvgtjyQuECjZnzMZfRDGij, num2, out noatZUCGfWQDABlGSjSzJjqRKVrg);
				if (!VoodlmKWYkBIcFdDQhKahZjCTAcc)
				{
					goto case 10;
				}
				goto IL_0169;
			case 2:
				if (fZiGxbOkqzdsegVqpLGakKTGith == IntPtr.Zero)
				{
					fZiGxbOkqzdsegVqpLGakKTGith = FZiGxbOkqzdsegVqpLGakKTGith;
					num = -1271630312;
					continue;
				}
				goto case 6;
			case 13:
				if (rHccTXHaQHKgJspYXChoCFSBEVlf == mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
				{
					goto IL_01ab;
				}
				goto case 0;
			case 0:
				if (UNCDhikBVajwTkKrWKjlDBeTSzFD && !VoodlmKWYkBIcFdDQhKahZjCTAcc)
				{
					xmbDrUCeGHHFlfcceXtOZgstyWdC();
					num = -1271630307;
					continue;
				}
				goto IL_010b;
			case 1:
				return;
			}
			break;
			IL_01ab:
			kCAXFYidwvFFfAGvqsKCviGEfdu(utNJDnvgtjyQuECjZnzMZfRDGij, out num2);
			int num3;
			if (UNCDhikBVajwTkKrWKjlDBeTSzFD)
			{
				num = -1271630314;
				num3 = num;
			}
			else
			{
				num = -1271630315;
				num3 = num;
			}
			continue;
			IL_010b:
			if (pxdVJyAGwTQNGJDRzUSBDhXjucu)
			{
				int num4;
				if (!bQkxPpnAfRwlFYUCstXQcrarWbi)
				{
					num = -1271630313;
					num4 = num;
				}
				else
				{
					num = -1271630305;
					num4 = num;
				}
				continue;
			}
			return;
			IL_0093:
			if (pxdVJyAGwTQNGJDRzUSBDhXjucu)
			{
				flag2 = !isRzzjqbTXPruoQOlSiHBQsIAkP(ControllerType.Keyboard, utNJDnvgtjyQuECjZnzMZfRDGij, num2, out fZiGxbOkqzdsegVqpLGakKTGith);
				int num5;
				if (bQkxPpnAfRwlFYUCstXQcrarWbi)
				{
					num = -1271630310;
					num5 = num;
				}
				else
				{
					num = -1271630308;
					num5 = num;
				}
				continue;
			}
			return;
			IL_0169:
			int num6;
			if (flag)
			{
				num = -1271630315;
				num6 = num;
			}
			else
			{
				num = -1271630316;
				num6 = num;
			}
			continue;
			IL_0132:
			int num7;
			if (!flag2)
			{
				num = -1271630308;
				num7 = num;
			}
			else
			{
				num = -1271630305;
				num7 = num;
			}
		}
		goto IL_0019;
		IL_0085:
		bGYFtaiaaIhedSXWUujtkmmKiUt = realTime;
		num = -1271630317;
		goto IL_001e;
	}

	private void JJJtSixpnCXriLqHxbntKFnVHNKD()
	{
		uint num = default(uint);
		if (rHccTXHaQHKgJspYXChoCFSBEVlf == mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
		{
			kCAXFYidwvFFfAGvqsKCviGEfdu(utNJDnvgtjyQuECjZnzMZfRDGij, out num);
			if (!UNCDhikBVajwTkKrWKjlDBeTSzFD)
			{
				return;
			}
			goto IL_0024;
		}
		goto IL_00a7;
		IL_00a7:
		int num2;
		if (UNCDhikBVajwTkKrWKjlDBeTSzFD)
		{
			int num3;
			if (VoodlmKWYkBIcFdDQhKahZjCTAcc)
			{
				num2 = 2109708389;
				num3 = num2;
			}
			else
			{
				num2 = 2109708386;
				num3 = num2;
			}
			goto IL_0029;
		}
		return;
		IL_0024:
		num2 = 2109708388;
		goto IL_0029;
		IL_0029:
		while (true)
		{
			switch (num2 ^ 0x7DBF9861)
			{
			case 0:
				break;
			default:
				return;
			case 5:
				goto IL_0055;
			case 3:
				xmbDrUCeGHHFlfcceXtOZgstyWdC();
				num2 = 2109708389;
				continue;
			case 1:
				VoodlmKWYkBIcFdDQhKahZjCTAcc = false;
				dYGYigZHQLDxociHhyaSrGzXEUv.yRdrULZFsagIEVrPsPcWDOWjCdhH(false);
				num2 = 2109708387;
				continue;
			case 6:
				goto IL_00a7;
			case 2:
				JKaWHnYRLJDFiDzAmSUXbBSygnQ();
				return;
			case 4:
				return;
			}
			break;
			IL_0055:
			if (isRzzjqbTXPruoQOlSiHBQsIAkP(ControllerType.Mouse, utNJDnvgtjyQuECjZnzMZfRDGij, num, out var _))
			{
				int num4;
				if (!VoodlmKWYkBIcFdDQhKahZjCTAcc)
				{
					num2 = 2109708387;
					num4 = num2;
				}
				else
				{
					num2 = 2109708384;
					num4 = num2;
				}
				continue;
			}
			return;
		}
		goto IL_0024;
	}

	private void RmNhwHHYpUKqhveizaNycSxZhAOE()
	{
		if (rHccTXHaQHKgJspYXChoCFSBEVlf == mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
		{
			ZSApAFaZOBjDuhAfJJXCcWSHPaw.llLzaKjdOIchsaknQtBzDRFMwBY(false);
			YKTeNObdSeptBWdRTlUdynmQmXyi();
			goto IL_0014;
		}
		goto IL_0032;
		IL_0032:
		VoodlmKWYkBIcFdDQhKahZjCTAcc = false;
		int num = 1812837191;
		goto IL_0019;
		IL_0014:
		num = 1812837188;
		goto IL_0019;
		IL_0019:
		switch (num ^ 0x6C0DB346)
		{
		case 0:
			break;
		case 2:
			goto IL_0032;
		default:
			dYGYigZHQLDxociHhyaSrGzXEUv.yRdrULZFsagIEVrPsPcWDOWjCdhH(false);
			return;
		}
		goto IL_0014;
	}

	private void YKTeNObdSeptBWdRTlUdynmQmXyi()
	{
		if (!UNCDhikBVajwTkKrWKjlDBeTSzFD)
		{
			return;
		}
		IntPtr intPtr = default(IntPtr);
		IntPtr noatZUCGfWQDABlGSjSzJjqRKVrg = default(IntPtr);
		uint num3 = default(uint);
		while (true)
		{
			int num = -411300700;
			while (true)
			{
				int num5;
				int num6;
				switch (num ^ -411300698)
				{
				case 9:
					break;
				case 6:
					if (intPtr != IntPtr.Zero)
					{
						num = -411300698;
						continue;
					}
					goto IL_013b;
				case 3:
					intPtr = NoatZUCGfWQDABlGSjSzJjqRKVrg;
					num = -411300704;
					continue;
				case 8:
					NoatZUCGfWQDABlGSjSzJjqRKVrg = noatZUCGfWQDABlGSjSzJjqRKVrg;
					num = -411300699;
					continue;
				case 1:
					intPtr = YksGHYKteMuhDXToEsEFZvCVfCJ.AUFWjjIkwWerQKSUjdsylUuMVyM();
					num = -411300704;
					continue;
				case 7:
					if (CnyaXxVpxASVfEjYRIkwedmEeQt)
					{
						kCAXFYidwvFFfAGvqsKCviGEfdu(utNJDnvgtjyQuECjZnzMZfRDGij, out num3);
						num = -411300702;
						continue;
					}
					goto case 1;
				case 4:
				{
					int num4;
					if (!isRzzjqbTXPruoQOlSiHBQsIAkP(ControllerType.Mouse, utNJDnvgtjyQuECjZnzMZfRDGij, num3, out noatZUCGfWQDABlGSjSzJjqRKVrg))
					{
						num = -411300699;
						num4 = num;
					}
					else
					{
						num = -411300690;
						num4 = num;
					}
					continue;
				}
				case 5:
					return;
				case 2:
				{
					int num2;
					if (rHccTXHaQHKgJspYXChoCFSBEVlf == mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
					{
						num = -411300703;
						num2 = num;
					}
					else
					{
						num = -411300701;
						num2 = num;
					}
					continue;
				}
				default:
					{
						bool flag = false;
						try
						{
							MqTiLaFHDtnFUlOZwClsCzFjNOeu.BRxQVckbIdJRGeNXSbjYpcTefbr((qIbMLJZATiXoZkJFsjBRfhcWBevI)1, (HnEKTVdMYbbGrySWPQiZMYNvwN)2, gKkKUCzoRCsPZVnmEixRrSJwEiK.cGRXaGOyiobrTtSieHkvjdIHewu, intPtr);
						}
						catch
						{
							flag = true;
						}
						if (!flag)
						{
							return;
						}
						goto IL_0111;
					}
					IL_0111:
					num5 = -411300700;
					goto IL_0116;
					IL_013b:
					if (VoodlmKWYkBIcFdDQhKahZjCTAcc)
					{
						num5 = -411300697;
						num6 = num5;
					}
					else
					{
						num5 = -411300702;
						num6 = num5;
					}
					goto IL_0116;
					IL_0116:
					while (true)
					{
						switch (num5 ^ -411300698)
						{
						case 0:
							break;
						default:
							return;
						case 3:
							goto IL_013b;
						case 5:
							return;
						case 1:
						{
							OJhGFhJMtmdDtmkWCaDDEFpwoPZb oJhGFhJMtmdDtmkWCaDDEFpwoPZb = new OJhGFhJMtmdDtmkWCaDDEFpwoPZb();
							oJhGFhJMtmdDtmkWCaDDEFpwoPZb.XewSQgMjCFaDNJiRryZdwxsRawl = false;
							mAQuhJhPOMChsAYOiuJgfFwykpyr(oJhGFhJMtmdDtmkWCaDDEFpwoPZb.NipDimQEbEttBAjoPCPLSVhaqla, true);
							if (oJhGFhJMtmdDtmkWCaDDEFpwoPZb.XewSQgMjCFaDNJiRryZdwxsRawl)
							{
								Rewired.Logger.LogError("Failed to unregister mouse.", requiredThreadSafety: true);
								num5 = -411300702;
								continue;
							}
							return;
						}
						case 2:
							Rewired.Logger.LogError("Failed to unregister mouse.", requiredThreadSafety: true);
							num5 = -411300701;
							continue;
						case 4:
							return;
						}
						break;
					}
					goto IL_0111;
				}
				break;
			}
		}
	}

	private void oEZeOTHXNlyMTlRjuWjoqxejiXe(IntPtr P_0)
	{
		if (rHccTXHaQHKgJspYXChoCFSBEVlf != mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
		{
			goto IL_0008;
		}
		goto IL_0032;
		IL_0008:
		int num = 876052377;
		goto IL_000d;
		IL_000d:
		switch (num ^ 0x34377F98)
		{
		case 0:
			break;
		default:
			return;
		case 1:
			return;
		case 2:
			goto IL_0032;
		case 3:
			return;
		}
		goto IL_0008;
		IL_0032:
		xmbDrUCeGHHFlfcceXtOZgstyWdC();
		if (P_0 != IntPtr.Zero && P_0 != RQdPJSbvvMdPhNVeOTTxzTpjUat.Handle)
		{
			NoatZUCGfWQDABlGSjSzJjqRKVrg = P_0;
			ZSApAFaZOBjDuhAfJJXCcWSHPaw.JmIDkIFPTDsicVzuxKvgTVbAMCeW(NoatZUCGfWQDABlGSjSzJjqRKVrg, true);
			num = 876052379;
			goto IL_000d;
		}
	}

	private void JKaWHnYRLJDFiDzAmSUXbBSygnQ()
	{
		if (rHccTXHaQHKgJspYXChoCFSBEVlf != mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
		{
			return;
		}
		while (true)
		{
			xmbDrUCeGHHFlfcceXtOZgstyWdC();
			ZSApAFaZOBjDuhAfJJXCcWSHPaw.JmIDkIFPTDsicVzuxKvgTVbAMCeW(BGYuTJmILidJmDNYViZXhFpmdBGH.value, true);
			int num = -674491314;
			while (true)
			{
				switch (num ^ -674491314)
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
				num = -674491313;
			}
		}
	}

	private void xmbDrUCeGHHFlfcceXtOZgstyWdC()
	{
		bTJHZCnFpyTiOTkFMKOktpThDbG bTJHZCnFpyTiOTkFMKOktpThDbG2 = default(bTJHZCnFpyTiOTkFMKOktpThDbG);
		if (rHccTXHaQHKgJspYXChoCFSBEVlf == mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
		{
			bTJHZCnFpyTiOTkFMKOktpThDbG2 = new bTJHZCnFpyTiOTkFMKOktpThDbG();
			bTJHZCnFpyTiOTkFMKOktpThDbG2.xvYPGRaXRVZlwecANemUYNIlHnq = this;
			goto IL_0015;
		}
		goto IL_0064;
		IL_0064:
		int num;
		int num2;
		if (!VoodlmKWYkBIcFdDQhKahZjCTAcc)
		{
			num = -2006090320;
			num2 = num;
		}
		else
		{
			num = -2006090315;
			num2 = num;
		}
		goto IL_001a;
		IL_0015:
		num = -2006090314;
		goto IL_001a;
		IL_001a:
		while (true)
		{
			switch (num ^ -2006090319)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				VoodlmKWYkBIcFdDQhKahZjCTAcc = true;
				dYGYigZHQLDxociHhyaSrGzXEUv.yRdrULZFsagIEVrPsPcWDOWjCdhH(true);
				num = -2006090315;
				continue;
			case 2:
				goto IL_0064;
			case 5:
				return;
			case 7:
				bTJHZCnFpyTiOTkFMKOktpThDbG2.XewSQgMjCFaDNJiRryZdwxsRawl = false;
				num = -2006090313;
				continue;
			case 6:
				goto IL_0093;
			case 0:
				Rewired.Logger.LogError("Failed to register mouse.", requiredThreadSafety: true);
				VoodlmKWYkBIcFdDQhKahZjCTAcc = false;
				dYGYigZHQLDxociHhyaSrGzXEUv.yRdrULZFsagIEVrPsPcWDOWjCdhH(false);
				num = -2006090316;
				continue;
			case 4:
				return;
			}
			break;
			IL_0093:
			mAQuhJhPOMChsAYOiuJgfFwykpyr(bTJHZCnFpyTiOTkFMKOktpThDbG2.CHRqtONoeWOhazfpCZCQoNkpgxb, true);
			int num3;
			if (!bTJHZCnFpyTiOTkFMKOktpThDbG2.XewSQgMjCFaDNJiRryZdwxsRawl)
			{
				num = -2006090317;
				num3 = num;
			}
			else
			{
				num = -2006090319;
				num3 = num;
			}
		}
		goto IL_0015;
	}

	public static bool kCAXFYidwvFFfAGvqsKCviGEfdu(lNVvsSWimiJoZjXIfLuDnlayxeb P_0, out uint P_1)
	{
		P_1 = 0u;
		if (P_0 == null)
		{
			return false;
		}
		uint maxDevices = (uint)P_0.maxDevices;
		P_1 = YksGHYKteMuhDXToEsEFZvCVfCJ.kCAXFYidwvFFfAGvqsKCviGEfdu(P_0, ref maxDevices, (uint)P_0.structSize);
		return P_1 != 0;
	}

	private unsafe bool isRzzjqbTXPruoQOlSiHBQsIAkP(ControllerType P_0, lNVvsSWimiJoZjXIfLuDnlayxeb P_1, uint P_2, out IntPtr P_3)
	{
		P_3 = IntPtr.Zero;
		int num2 = default(int);
		kGTfKeiNEmRTxUKLBasPByqWWNX* ptr = default(kGTfKeiNEmRTxUKLBasPByqWWNX*);
		ControllerType controllerType = default(ControllerType);
		while (true)
		{
			int num = -1274736100;
			while (true)
			{
				switch (num ^ -1274736099)
				{
				case 4:
					break;
				case 7:
					return true;
				case 8:
					goto IL_0062;
				case 2:
				{
					IntPtr pointer = P_1.GetPointer(num2 * P_1.structSize);
					ptr = (kGTfKeiNEmRTxUKLBasPByqWWNX*)(void*)pointer;
					num = -1274736105;
					continue;
				}
				case 6:
					switch (controllerType)
					{
					case ControllerType.Mouse:
						break;
					case ControllerType.Keyboard:
						goto IL_0062;
					default:
						goto IL_013a;
					}
					if (ptr->FgKkOHNNkzQFpuhUVJkqfwmjUHL == 1)
					{
						num = -1274736104;
						continue;
					}
					goto IL_013a;
				case 5:
					if (ptr->BSWAbdsjQrbLzxWaXzLKFQNwRml == 2 && ptr->BpPKsTHlyHucinYYUGahwmbFBDI != IntPtr.Zero && ptr->BpPKsTHlyHucinYYUGahwmbFBDI != RQdPJSbvvMdPhNVeOTTxzTpjUat.Handle)
					{
						P_3 = ptr->BpPKsTHlyHucinYYUGahwmbFBDI;
						num = -1274736099;
						continue;
					}
					goto IL_013a;
				case 0:
					return true;
				case 1:
					if (P_1 == null)
					{
						return false;
					}
					num2 = 0;
					num = -1274736108;
					continue;
				case 3:
					P_3 = ptr->BpPKsTHlyHucinYYUGahwmbFBDI;
					num = -1274736102;
					continue;
				case 10:
					controllerType = P_0;
					num = -1274736101;
					continue;
				default:
					{
						if (num2 >= P_2)
						{
							return false;
						}
						goto case 2;
					}
					IL_0062:
					if (ptr->FgKkOHNNkzQFpuhUVJkqfwmjUHL == 1 && ptr->BSWAbdsjQrbLzxWaXzLKFQNwRml == 6 && ptr->BpPKsTHlyHucinYYUGahwmbFBDI != IntPtr.Zero && ptr->BpPKsTHlyHucinYYUGahwmbFBDI != RQdPJSbvvMdPhNVeOTTxzTpjUat.Handle)
					{
						num = -1274736098;
						continue;
					}
					goto IL_013a;
					IL_013a:
					num2++;
					num = -1274736108;
					continue;
				}
				break;
			}
		}
	}

	private unsafe IntPtr nJAgYxmmrApGALvUVFkWjjljTEv()
	{
		lNVvsSWimiJoZjXIfLuDnlayxeb lNVvsSWimiJoZjXIfLuDnlayxeb2 = null;
		IntPtr result = default(IntPtr);
		try
		{
			lNVvsSWimiJoZjXIfLuDnlayxeb2 = new lNVvsSWimiJoZjXIfLuDnlayxeb(kGTfKeiNEmRTxUKLBasPByqWWNX.SizeInBytes, 100);
			uint maxDevices = (uint)lNVvsSWimiJoZjXIfLuDnlayxeb2.maxDevices;
			uint num = YksGHYKteMuhDXToEsEFZvCVfCJ.kCAXFYidwvFFfAGvqsKCviGEfdu(lNVvsSWimiJoZjXIfLuDnlayxeb2, ref maxDevices, (uint)lNVvsSWimiJoZjXIfLuDnlayxeb2.structSize);
			int num4 = default(int);
			kGTfKeiNEmRTxUKLBasPByqWWNX* ptr = default(kGTfKeiNEmRTxUKLBasPByqWWNX*);
			while (true)
			{
				IL_002a:
				int num2 = 167326055;
				while (true)
				{
					switch (num2 ^ 0x9F93164)
					{
					case 12:
						break;
					default:
						goto end_IL_002f;
					case 0:
					{
						IntPtr pointer = lNVvsSWimiJoZjXIfLuDnlayxeb2.GetPointer(num4 * lNVvsSWimiJoZjXIfLuDnlayxeb2.structSize);
						ptr = (kGTfKeiNEmRTxUKLBasPByqWWNX*)(void*)pointer;
						Rewired.Logger.Log("RI DEVICE " + num4);
						Rewired.Logger.Log("usage = " + ptr->BSWAbdsjQrbLzxWaXzLKFQNwRml);
						num2 = 167326049;
						continue;
					}
					case 6:
						result = IntPtr.Zero;
						goto end_IL_002f;
					case 5:
						Rewired.Logger.Log("usagePage = " + ptr->FgKkOHNNkzQFpuhUVJkqfwmjUHL);
						num2 = 167326058;
						continue;
					case 14:
					{
						Rewired.Logger.Log("flags = " + ptr->kukmWglJDUvMDZhbIGzDAcBZJRG);
						Rewired.Logger.Log("target = " + ptr->BpPKsTHlyHucinYYUGahwmbFBDI);
						int num8;
						if (ptr->FgKkOHNNkzQFpuhUVJkqfwmjUHL == 1)
						{
							num2 = 167326054;
							num8 = num2;
						}
						else
						{
							num2 = 167326057;
							num8 = num2;
						}
						continue;
					}
					case 4:
						result = IntPtr.Zero;
						num2 = 167326060;
						continue;
					case 3:
					{
						int num5;
						if (num == 0)
						{
							num2 = 167326050;
							num5 = num2;
						}
						else
						{
							num2 = 167326062;
							num5 = num2;
						}
						continue;
					}
					case 13:
						num4++;
						num2 = 167326063;
						continue;
					case 2:
					{
						int num7;
						if (ptr->BSWAbdsjQrbLzxWaXzLKFQNwRml == 2)
						{
							num2 = 167326053;
							num7 = num2;
						}
						else
						{
							num2 = 167326057;
							num7 = num2;
						}
						continue;
					}
					case 9:
						goto end_IL_002f;
					case 10:
						num4 = 0;
						num2 = 167326063;
						continue;
					case 7:
						if (ptr->BpPKsTHlyHucinYYUGahwmbFBDI != RQdPJSbvvMdPhNVeOTTxzTpjUat.Handle)
						{
							result = ptr->BpPKsTHlyHucinYYUGahwmbFBDI;
							num2 = 167326061;
							continue;
						}
						goto case 13;
					case 11:
					{
						int num6;
						if (num4 >= num)
						{
							num2 = 167326048;
							num6 = num2;
						}
						else
						{
							num2 = 167326052;
							num6 = num2;
						}
						continue;
					}
					case 1:
					{
						int num3;
						if (!(ptr->BpPKsTHlyHucinYYUGahwmbFBDI != IntPtr.Zero))
						{
							num2 = 167326057;
							num3 = num2;
						}
						else
						{
							num2 = 167326051;
							num3 = num2;
						}
						continue;
					}
					case 8:
						goto end_IL_002f;
					}
					goto IL_002a;
					continue;
					end_IL_002f:
					break;
				}
				break;
			}
		}
		catch
		{
			result = IntPtr.Zero;
		}
		finally
		{
			if (lNVvsSWimiJoZjXIfLuDnlayxeb2 != null)
			{
				while (true)
				{
					IL_024c:
					int num9 = 167326053;
					while (true)
					{
						switch (num9 ^ 0x9F93164)
						{
						case 0:
							break;
						default:
							goto end_IL_0251;
						case 1:
							goto IL_026a;
						case 2:
							goto end_IL_0251;
						}
						goto IL_024c;
						IL_026a:
						lNVvsSWimiJoZjXIfLuDnlayxeb2.Dispose();
						num9 = 167326054;
						continue;
						end_IL_0251:
						break;
					}
					break;
				}
			}
		}
		return result;
	}

	private void JgyXYXTgFOAZHHCJtMLGOUiKTWw(IntPtr P_0)
	{
		if (rHccTXHaQHKgJspYXChoCFSBEVlf != mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
		{
			return;
		}
		while (true)
		{
			nepBqwsCxIBfqpkKKysTMuTakZf();
			if (!(P_0 != IntPtr.Zero))
			{
				break;
			}
			int num;
			int num2;
			if (!(P_0 != RQdPJSbvvMdPhNVeOTTxzTpjUat.Handle))
			{
				num = -490082599;
				num2 = num;
			}
			else
			{
				num = -490082600;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ -490082600)
				{
				case 2:
					num = -490082597;
					continue;
				default:
					return;
				case 3:
					break;
				case 0:
					FZiGxbOkqzdsegVqpLGakKTGith = P_0;
					num = -490082599;
					continue;
				case 1:
					return;
				}
				break;
			}
		}
	}

	private void atajYjffcRjqhXvxzQtEMELRbrj()
	{
		if (rHccTXHaQHKgJspYXChoCFSBEVlf == mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
		{
			nepBqwsCxIBfqpkKKysTMuTakZf();
		}
	}

	private void nepBqwsCxIBfqpkKKysTMuTakZf()
	{
		if (rHccTXHaQHKgJspYXChoCFSBEVlf == mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
		{
			goto IL_000b;
		}
		goto IL_0090;
		IL_000b:
		int num = -596171490;
		goto IL_0010;
		IL_0010:
		TegzNhYcFIBrgwEmaGCKbsDmMTfH tegzNhYcFIBrgwEmaGCKbsDmMTfH = default(TegzNhYcFIBrgwEmaGCKbsDmMTfH);
		while (true)
		{
			switch (num ^ -596171489)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				tegzNhYcFIBrgwEmaGCKbsDmMTfH = new TegzNhYcFIBrgwEmaGCKbsDmMTfH();
				tegzNhYcFIBrgwEmaGCKbsDmMTfH.xvYPGRaXRVZlwecANemUYNIlHnq = this;
				tegzNhYcFIBrgwEmaGCKbsDmMTfH.XewSQgMjCFaDNJiRryZdwxsRawl = false;
				num = -596171493;
				continue;
			case 4:
				mAQuhJhPOMChsAYOiuJgfFwykpyr(tegzNhYcFIBrgwEmaGCKbsDmMTfH.igzBsVTXcbzJKiiVVAeVailAJLZ, true);
				if (tegzNhYcFIBrgwEmaGCKbsDmMTfH.XewSQgMjCFaDNJiRryZdwxsRawl)
				{
					Rewired.Logger.LogError("Failed to register keyboard.", requiredThreadSafety: true);
					bQkxPpnAfRwlFYUCstXQcrarWbi = false;
					GRolUKdfCrfyXltJwHEsDBEFexK.yRdrULZFsagIEVrPsPcWDOWjCdhH(false);
					return;
				}
				goto IL_0090;
			case 2:
				goto IL_0090;
			case 3:
				return;
			}
			break;
		}
		goto IL_000b;
		IL_0090:
		if (!bQkxPpnAfRwlFYUCstXQcrarWbi)
		{
			bQkxPpnAfRwlFYUCstXQcrarWbi = true;
			GRolUKdfCrfyXltJwHEsDBEFexK.yRdrULZFsagIEVrPsPcWDOWjCdhH(true);
			num = -596171492;
			goto IL_0010;
		}
	}

	private void yXqDZcnOIyEjpzBqLHzgfUFcNSB()
	{
		if (rHccTXHaQHKgJspYXChoCFSBEVlf == mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
		{
			yhqVglmVQPsmHOOSpNxGxcyIRGp();
			goto IL_000e;
		}
		goto IL_0030;
		IL_0030:
		bQkxPpnAfRwlFYUCstXQcrarWbi = false;
		int num = -457776689;
		goto IL_0013;
		IL_000e:
		num = -457776690;
		goto IL_0013;
		IL_0013:
		while (true)
		{
			switch (num ^ -457776689)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				goto IL_0030;
			case 0:
				GRolUKdfCrfyXltJwHEsDBEFexK.yRdrULZFsagIEVrPsPcWDOWjCdhH(false);
				num = -457776691;
				continue;
			case 2:
				return;
			}
			break;
		}
		goto IL_000e;
	}

	private void yhqVglmVQPsmHOOSpNxGxcyIRGp()
	{
		if (pxdVJyAGwTQNGJDRzUSBDhXjucu)
		{
			if (rHccTXHaQHKgJspYXChoCFSBEVlf != mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
			{
				goto IL_0010;
			}
			goto IL_007c;
		}
		return;
		IL_007c:
		uint num = default(uint);
		int num2;
		if (CnyaXxVpxASVfEjYRIkwedmEeQt)
		{
			kCAXFYidwvFFfAGvqsKCviGEfdu(utNJDnvgtjyQuECjZnzMZfRDGij, out num);
			num2 = 963826772;
			goto IL_0015;
		}
		goto IL_0058;
		IL_0010:
		num2 = 963826770;
		goto IL_0015;
		IL_0015:
		IntPtr intPtr = default(IntPtr);
		while (true)
		{
			int num3;
			switch (num2 ^ 0x3972D455)
			{
			case 0:
				break;
			case 7:
				return;
			case 3:
				intPtr = FZiGxbOkqzdsegVqpLGakKTGith;
				num2 = 963826771;
				continue;
			case 5:
				goto IL_0058;
			case 6:
				if (intPtr != IntPtr.Zero)
				{
					num2 = 963826775;
					continue;
				}
				goto IL_010d;
			case 4:
				goto IL_007c;
			case 1:
			{
				if (isRzzjqbTXPruoQOlSiHBQsIAkP(ControllerType.Keyboard, utNJDnvgtjyQuECjZnzMZfRDGij, num, out var fZiGxbOkqzdsegVqpLGakKTGith))
				{
					FZiGxbOkqzdsegVqpLGakKTGith = fZiGxbOkqzdsegVqpLGakKTGith;
					num2 = 963826774;
					continue;
				}
				goto case 3;
			}
			default:
				{
					bool flag = false;
					try
					{
						MqTiLaFHDtnFUlOZwClsCzFjNOeu.BRxQVckbIdJRGeNXSbjYpcTefbr((qIbMLJZATiXoZkJFsjBRfhcWBevI)1, (HnEKTVdMYbbGrySWPQiZMYNvwN)6, gKkKUCzoRCsPZVnmEixRrSJwEiK.cGRXaGOyiobrTtSieHkvjdIHewu, intPtr);
					}
					catch
					{
						flag = true;
					}
					if (flag)
					{
						Rewired.Logger.LogError("Failed to unregister keyboard.", requiredThreadSafety: true);
						goto IL_00e3;
					}
					return;
				}
				IL_010d:
				if (bQkxPpnAfRwlFYUCstXQcrarWbi)
				{
					GKopLJhmdTjAeVRnFHSYbyKXmXz gKopLJhmdTjAeVRnFHSYbyKXmXz = new GKopLJhmdTjAeVRnFHSYbyKXmXz();
					gKopLJhmdTjAeVRnFHSYbyKXmXz.XewSQgMjCFaDNJiRryZdwxsRawl = false;
					mAQuhJhPOMChsAYOiuJgfFwykpyr(gKopLJhmdTjAeVRnFHSYbyKXmXz.fSeHGHtSIEKmVjmZrutPRsJKjAR, true);
					if (gKopLJhmdTjAeVRnFHSYbyKXmXz.XewSQgMjCFaDNJiRryZdwxsRawl)
					{
						Rewired.Logger.LogError("Failed to unregister keyboard.", requiredThreadSafety: true);
						num3 = 963826772;
						goto IL_00e8;
					}
					return;
				}
				return;
				IL_00e3:
				num3 = 963826774;
				goto IL_00e8;
				IL_00e8:
				switch (num3 ^ 0x3972D455)
				{
				case 2:
					break;
				default:
					return;
				case 3:
					return;
				case 0:
					goto IL_010d;
				case 1:
					return;
				}
				goto IL_00e3;
			}
			break;
		}
		goto IL_0010;
		IL_0058:
		intPtr = YksGHYKteMuhDXToEsEFZvCVfCJ.AUFWjjIkwWerQKSUjdsylUuMVyM();
		num2 = 963826771;
		goto IL_0015;
	}

	private void TpwYaCYUuJivXNAIKbrfIFiamHn()
	{
		if (rHccTXHaQHKgJspYXChoCFSBEVlf != mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
		{
			goto IL_0036;
		}
		if (UNCDhikBVajwTkKrWKjlDBeTSzFD)
		{
			goto IL_0010;
		}
		goto IL_004b;
		IL_0036:
		int num;
		if (UNCDhikBVajwTkKrWKjlDBeTSzFD)
		{
			RmNhwHHYpUKqhveizaNycSxZhAOE();
			num = 290602809;
			goto IL_0015;
		}
		return;
		IL_0010:
		num = 290602812;
		goto IL_0015;
		IL_0015:
		while (true)
		{
			switch (num ^ 0x11523F38)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				goto IL_0036;
			case 2:
				goto IL_004b;
			case 4:
				RmNhwHHYpUKqhveizaNycSxZhAOE();
				num = 290602810;
				continue;
			case 1:
				return;
			}
			break;
		}
		goto IL_0010;
		IL_004b:
		DfXezXOigVceheHRnYuCDVoaFGZN();
		if (pxdVJyAGwTQNGJDRzUSBDhXjucu)
		{
			yXqDZcnOIyEjpzBqLHzgfUFcNSB();
		}
	}

	private void tGVxomEHIjaBHEbQFiTxagakgYuL()
	{
		if (yCIfoAipTphniepDsrKPaDRNhiMJ)
		{
			goto IL_0008;
		}
		goto IL_0059;
		IL_0008:
		int num = 1497840464;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x59473B53)
			{
			case 4:
				break;
			default:
				return;
			case 2:
				MqTiLaFHDtnFUlOZwClsCzFjNOeu.KeyboardInput += aJhHyohyoVmgSbUrxBcEtAfbWHZ;
				num = 1497840467;
				continue;
			case 5:
				goto IL_0059;
			case 7:
				if (!UNCDhikBVajwTkKrWKjlDBeTSzFD)
				{
					goto IL_0081;
				}
				goto case 1;
			case 6:
				goto IL_009d;
			case 1:
				MqTiLaFHDtnFUlOZwClsCzFjNOeu.DeviceConnectedEvent += wKYyFtRQVzBVSfVCpPWhHTTKcVg;
				MqTiLaFHDtnFUlOZwClsCzFjNOeu.DeviceDisconnectedEvent += vzwGcjnDEOmCBoFIklCfwZNifrE;
				num = 1497840475;
				continue;
			case 3:
				MqTiLaFHDtnFUlOZwClsCzFjNOeu.RawInput += EoNQgADarCjcgjpgsEWQFzSXRHyl;
				num = 1497840470;
				continue;
			case 0:
				goto IL_0100;
			case 8:
				return;
			}
			break;
			IL_0100:
			int num2;
			if (yCIfoAipTphniepDsrKPaDRNhiMJ)
			{
				num = 1497840466;
				num2 = num;
			}
			else
			{
				num = 1497840468;
				num2 = num;
			}
			continue;
			IL_0081:
			int num3;
			if (!pxdVJyAGwTQNGJDRzUSBDhXjucu)
			{
				num = 1497840475;
				num3 = num;
			}
			else
			{
				num = 1497840466;
				num3 = num;
			}
		}
		goto IL_0008;
		IL_0059:
		if (UNCDhikBVajwTkKrWKjlDBeTSzFD)
		{
			MqTiLaFHDtnFUlOZwClsCzFjNOeu.MouseInput += EuTbGxeLfGaFfywTIWwOeubgINNe;
			num = 1497840469;
			goto IL_000d;
		}
		goto IL_009d;
		IL_009d:
		int num4;
		if (pxdVJyAGwTQNGJDRzUSBDhXjucu)
		{
			num = 1497840465;
			num4 = num;
		}
		else
		{
			num = 1497840467;
			num4 = num;
		}
		goto IL_000d;
	}

	private void OAwecadieMdGJVeAljYncxPGwFCF()
	{
		if (yCIfoAipTphniepDsrKPaDRNhiMJ)
		{
			MqTiLaFHDtnFUlOZwClsCzFjNOeu.RawInput -= EoNQgADarCjcgjpgsEWQFzSXRHyl;
			goto IL_0019;
		}
		goto IL_004a;
		IL_00c0:
		int num;
		if (!yCIfoAipTphniepDsrKPaDRNhiMJ && !UNCDhikBVajwTkKrWKjlDBeTSzFD)
		{
			int num2;
			if (pxdVJyAGwTQNGJDRzUSBDhXjucu)
			{
				num = -37048860;
				num2 = num;
			}
			else
			{
				num = -37048864;
				num2 = num;
			}
			goto IL_001e;
		}
		goto IL_008a;
		IL_0019:
		num = -37048863;
		goto IL_001e;
		IL_001e:
		while (true)
		{
			switch (num ^ -37048859)
			{
			case 0:
				break;
			default:
				return;
			case 4:
				goto IL_004a;
			case 3:
				goto IL_006a;
			case 1:
				goto IL_008a;
			case 2:
				MqTiLaFHDtnFUlOZwClsCzFjNOeu.DeviceDisconnectedEvent -= vzwGcjnDEOmCBoFIklCfwZNifrE;
				num = -37048864;
				continue;
			case 6:
				goto IL_00c0;
			case 5:
				return;
			}
			break;
		}
		goto IL_0019;
		IL_008a:
		MqTiLaFHDtnFUlOZwClsCzFjNOeu.DeviceConnectedEvent -= wKYyFtRQVzBVSfVCpPWhHTTKcVg;
		num = -37048857;
		goto IL_001e;
		IL_004a:
		if (UNCDhikBVajwTkKrWKjlDBeTSzFD)
		{
			MqTiLaFHDtnFUlOZwClsCzFjNOeu.MouseInput -= EuTbGxeLfGaFfywTIWwOeubgINNe;
			num = -37048858;
			goto IL_001e;
		}
		goto IL_006a;
		IL_006a:
		if (pxdVJyAGwTQNGJDRzUSBDhXjucu)
		{
			MqTiLaFHDtnFUlOZwClsCzFjNOeu.KeyboardInput -= aJhHyohyoVmgSbUrxBcEtAfbWHZ;
			num = -37048861;
			goto IL_001e;
		}
		goto IL_00c0;
	}

	private void cFLSCyatcazkzhENOEFuYqNcRPl(hcawtLidRDRbqsbLAzMHVaINGfZ.FOuGhnqYlTUeadpnVWrBsIzYFWx P_0)
	{
		smutEwBmDzlyhioZwQTiBksitBv smutEwBmDzlyhioZwQTiBksitBv2 = new smutEwBmDzlyhioZwQTiBksitBv();
		smutEwBmDzlyhioZwQTiBksitBv2.udicPZKSFjJtuPaiMskGfpqKPOd = P_0;
		smutEwBmDzlyhioZwQTiBksitBv2.xvYPGRaXRVZlwecANemUYNIlHnq = this;
		while (true)
		{
			int num = -97868727;
			while (true)
			{
				switch (num ^ -97868726)
				{
				case 2:
					break;
				default:
					return;
				case 3:
					goto IL_0036;
				case 0:
					mAQuhJhPOMChsAYOiuJgfFwykpyr(smutEwBmDzlyhioZwQTiBksitBv2.pVuckOHQgliLBugNjqRfgSzSdzd, true);
					if (smutEwBmDzlyhioZwQTiBksitBv2.XewSQgMjCFaDNJiRryZdwxsRawl)
					{
						throw new Exception("Error creating message window.");
					}
					return;
				case 1:
					return;
				}
				break;
				IL_0036:
				smutEwBmDzlyhioZwQTiBksitBv2.XewSQgMjCFaDNJiRryZdwxsRawl = false;
				num = -97868726;
			}
		}
	}

	private static hcawtLidRDRbqsbLAzMHVaINGfZ ruhqADbIPoVHWRPRGVhzYJszbgLd(hcawtLidRDRbqsbLAzMHVaINGfZ.FOuGhnqYlTUeadpnVWrBsIzYFWx P_0)
	{
		hcawtLidRDRbqsbLAzMHVaINGfZ hcawtLidRDRbqsbLAzMHVaINGfZ2 = new hcawtLidRDRbqsbLAzMHVaINGfZ("RewiredMesssageWindow", createMessageOnlyWindow: true, P_0);
		if (hcawtLidRDRbqsbLAzMHVaINGfZ2.Handle == IntPtr.Zero)
		{
			hcawtLidRDRbqsbLAzMHVaINGfZ2.Dispose();
			return null;
		}
		return hcawtLidRDRbqsbLAzMHVaINGfZ2;
	}

	private void UBKjzbhqKIIzSTQkRlSuAiKFFSPQ()
	{
		if (rHccTXHaQHKgJspYXChoCFSBEVlf != mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
		{
			goto IL_0008;
		}
		goto IL_007a;
		IL_0008:
		int num = -981369912;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ -981369910)
			{
			case 8:
				break;
			case 11:
				if (UNCDhikBVajwTkKrWKjlDBeTSzFD)
				{
					JKaWHnYRLJDFiDzAmSUXbBSygnQ();
					num = -981369920;
					continue;
				}
				goto IL_0104;
			case 0:
				if (yCIfoAipTphniepDsrKPaDRNhiMJ)
				{
					DaEbHAPZwfTZBYzVQOhplfuewae();
					num = -981369908;
					continue;
				}
				goto case 6;
			case 7:
				goto IL_007a;
			case 6:
				if (!UNCDhikBVajwTkKrWKjlDBeTSzFD)
				{
					goto IL_008e;
				}
				goto case 3;
			case 2:
				return;
			case 4:
				atajYjffcRjqhXvxzQtEMELRbrj();
				num = -981369905;
				continue;
			case 9:
				if (CnyaXxVpxASVfEjYRIkwedmEeQt)
				{
					mZPblCaonGfFNpAbwrdxIGAubRsD = 1;
					num = -981369909;
					continue;
				}
				goto case 11;
			case 1:
				num = -981369905;
				continue;
			case 3:
				utNJDnvgtjyQuECjZnzMZfRDGij = new lNVvsSWimiJoZjXIfLuDnlayxeb(kGTfKeiNEmRTxUKLBasPByqWWNX.SizeInBytes, 100);
				num = -981369917;
				continue;
			case 10:
				goto IL_0104;
			default:
				BNowjvMfInZcNhDLgPskNJcMnCr = ZSApAFaZOBjDuhAfJJXCcWSHPaw.aNBHqQklZGMVPDolOzlvKpwGbvt();
				return;
			}
			break;
			IL_008e:
			int num2;
			if (!pxdVJyAGwTQNGJDRzUSBDhXjucu)
			{
				num = -981369905;
				num2 = num;
			}
			else
			{
				num = -981369911;
				num2 = num;
			}
			continue;
			IL_0104:
			int num3;
			if (pxdVJyAGwTQNGJDRzUSBDhXjucu)
			{
				num = -981369906;
				num3 = num;
			}
			else
			{
				num = -981369905;
				num3 = num;
			}
		}
		goto IL_0008;
		IL_007a:
		ZSApAFaZOBjDuhAfJJXCcWSHPaw.XcqbVqdtLKNrEHBlIGziwanWbzsI();
		num = -981369910;
		goto IL_000d;
	}

	private void fmMiJjVGXnGTxpplqIQTirVAuIJU()
	{
		if (!CnyaXxVpxASVfEjYRIkwedmEeQt)
		{
			return;
		}
		uint num3 = default(uint);
		IntPtr intPtr = default(IntPtr);
		while (rHccTXHaQHKgJspYXChoCFSBEVlf == mUBVcHMAjvIHOEpZspoiRvjuqCkb.MlzdhtMpbOibgIDOLOBDofRzjzi)
		{
			while (true)
			{
				IL_00a2:
				int num;
				int num2;
				if (mZPblCaonGfFNpAbwrdxIGAubRsD <= 0)
				{
					num = 356064199;
					num2 = num;
				}
				else
				{
					num = 356064192;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x15391BC7)
					{
					case 3:
						num = 356064194;
						continue;
					default:
						return;
					case 0:
						kCAXFYidwvFFfAGvqsKCviGEfdu(utNJDnvgtjyQuECjZnzMZfRDGij, out num3);
						if (UNCDhikBVajwTkKrWKjlDBeTSzFD)
						{
							isRzzjqbTXPruoQOlSiHBQsIAkP(ControllerType.Mouse, utNJDnvgtjyQuECjZnzMZfRDGij, num3, out intPtr);
							num = 356064207;
							continue;
						}
						goto case 1;
					case 8:
						oEZeOTHXNlyMTlRjuWjoqxejiXe(intPtr);
						num = 356064198;
						continue;
					case 4:
						mZPblCaonGfFNpAbwrdxIGAubRsD = -1;
						num = 356064193;
						continue;
					case 5:
						break;
					case 2:
						goto IL_00a2;
					case 1:
						if (pxdVJyAGwTQNGJDRzUSBDhXjucu)
						{
							isRzzjqbTXPruoQOlSiHBQsIAkP(ControllerType.Keyboard, utNJDnvgtjyQuECjZnzMZfRDGij, num3, out var intPtr2);
							JgyXYXTgFOAZHHCJtMLGOUiKTWw(intPtr2);
							num = 356064195;
							continue;
						}
						goto case 4;
					case 7:
						mZPblCaonGfFNpAbwrdxIGAubRsD--;
						return;
					case 6:
						return;
					}
					break;
				}
				break;
			}
		}
	}

	private void YKqmoqZCInuKpHQtBUSbdSMmAKI(bool P_0)
	{
		if (UNCDhikBVajwTkKrWKjlDBeTSzFD)
		{
			JKaWHnYRLJDFiDzAmSUXbBSygnQ();
			goto IL_000e;
		}
		goto IL_002c;
		IL_002c:
		int num;
		if (pxdVJyAGwTQNGJDRzUSBDhXjucu)
		{
			nepBqwsCxIBfqpkKKysTMuTakZf();
			num = 1613022284;
			goto IL_0013;
		}
		return;
		IL_000e:
		num = 1613022287;
		goto IL_0013;
		IL_0013:
		switch (num ^ 0x6024C44E)
		{
		case 0:
			break;
		default:
			return;
		case 1:
			goto IL_002c;
		case 2:
			return;
		}
		goto IL_000e;
	}

	private void GsvmkLflhSjJdDfZtTTFjZClmvfh(FullScreenMode P_0)
	{
		if (UNCDhikBVajwTkKrWKjlDBeTSzFD)
		{
			JJJtSixpnCXriLqHxbntKFnVHNKD();
		}
	}

	private void LRdOqslXVCRVbZnbQQQlyiMRPJy(IntPtr P_0)
	{
		if (CnyaXxVpxASVfEjYRIkwedmEeQt)
		{
			return;
		}
		while (true)
		{
			int num = 409472842;
			while (true)
			{
				switch (num ^ 0x18680F49)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					if (UNCDhikBVajwTkKrWKjlDBeTSzFD)
					{
						JKaWHnYRLJDFiDzAmSUXbBSygnQ();
						num = 409472843;
						continue;
					}
					goto case 2;
				case 2:
					if (pxdVJyAGwTQNGJDRzUSBDhXjucu)
					{
						atajYjffcRjqhXvxzQtEMELRbrj();
						num = 409472840;
						continue;
					}
					return;
				case 1:
					return;
				}
				break;
			}
		}
	}

	private IntPtr UeJwAFZBRXUmpWqkpXpTmRxhklJ(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (inweGjIgYacXYohFlYRlpMFkgKMi)
		{
			return IntPtr.Zero;
		}
		if (BNowjvMfInZcNhDLgPskNJcMnCr != null)
		{
			while (true)
			{
				int num = 992291330;
				while (true)
				{
					switch (num ^ 0x3B252A00)
					{
					case 0:
						break;
					case 2:
						BNowjvMfInZcNhDLgPskNJcMnCr(P_0, P_1, P_2, P_3);
						num = 992291329;
						continue;
					default:
						goto end_IL_0016;
					}
					break;
				}
				continue;
				end_IL_0016:
				break;
			}
		}
		return IntPtr.Zero;
	}

	private void mAQuhJhPOMChsAYOiuJgfFwykpyr(Action P_0, bool P_1)
	{
		P_0?.Invoke();
	}

	private void EoNQgADarCjcgjpgsEWQFzSXRHyl(bppzUMfHYaaKkmhJvTLXUKJAsLl P_0, double P_1)
	{
		try
		{
			tHoqVZjuKaYSABWtGjMbKFqzcXh(dBNoePwdKYyWerGenDMKaakIaLZh.zWzEPHbAHbpGVHtrMXDgFRmSdpHl, P_0.UdOaQKIUzemBrlkcmDTMEJLHkeko)?.GUXOVkFRBjCKbujBlYXzZnxHnTZ(P_0.RawDataPtr, P_0.RawDataBytes, P_0.DsrADThdkIpdIsTRXpmynAoAlaK, P_0.ihzsSYSJIANMfliVGXdPBmBKJbN, P_1);
		}
		catch
		{
		}
	}

	private void ruBEzOaOBgitOWzQBjhLIBwCkHlK(LhmdAeVDmUoGytlCDFftKpGWfGC P_0)
	{
		try
		{
			TPOFglCEUenQueqhakDnrjLmVbgq tPOFglCEUenQueqhakDnrjLmVbgq = tHoqVZjuKaYSABWtGjMbKFqzcXh(dBNoePwdKYyWerGenDMKaakIaLZh.zWzEPHbAHbpGVHtrMXDgFRmSdpHl, P_0.RZxeRXiRMdGVXExVYrFfKSLGcgO);
			if (tPOFglCEUenQueqhakDnrjLmVbgq == null)
			{
				while (true)
				{
					switch (-465007330 ^ -465007329)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			tPOFglCEUenQueqhakDnrjLmVbgq.GUXOVkFRBjCKbujBlYXzZnxHnTZ(P_0.rawDataPtr, P_0.xewHldJrTjLrAsdjMrVgiYVAVYQR, P_0.UaLjEPWmqQWsTdOsIYpzlleKhHQ, P_0.DwePWDYmJRIaVoaXbZBTjMUCXwb, P_0.xdmAJsfTsGwAFbRaKbbziORJkMWx);
		}
		catch
		{
		}
	}

	private void EuTbGxeLfGaFfywTIWwOeubgINNe(DDDnIKMgweztToiqpPbwGXlIauz P_0, double P_1)
	{
		tBLLIBxnGVrxdlYvuDZWPyDFvzD.WilpheradKREcjoLhhcMLOKbDOaC(ref P_0);
		mPHmxlPlYaZtFVSVBEPMJDjLNsq(tBLLIBxnGVrxdlYvuDZWPyDFvzD, P_1);
	}

	private void mPHmxlPlYaZtFVSVBEPMJDjLNsq(DhzqteWsbvTGlVNuNgSKoKlJtmF P_0, double P_1)
	{
		try
		{
			dYGYigZHQLDxociHhyaSrGzXEUv.nDwGSGWCnHAfhkghamaOrLWTAxcn(P_0);
		}
		catch (Exception)
		{
		}
	}

	private void aJhHyohyoVmgSbUrxBcEtAfbWHZ(yihoKCagFrSpiFOthbLUOXYMCZQ P_0, double P_1)
	{
		ofavyyIyiYSzFSqsMQRPgAdnfGD.WilpheradKREcjoLhhcMLOKbDOaC(ref P_0);
		npKQyNeEgbnmPblSUpsuxkZXiLX(ofavyyIyiYSzFSqsMQRPgAdnfGD, P_1);
	}

	private void npKQyNeEgbnmPblSUpsuxkZXiLX(aTdyQHLUTWxtxOewXyYbXIrqYcL P_0, double P_1)
	{
		try
		{
			GRolUKdfCrfyXltJwHEsDBEFexK.nDwGSGWCnHAfhkghamaOrLWTAxcn(P_0);
		}
		catch
		{
		}
	}

	private void wKYyFtRQVzBVSfVCpPWhHTTKcVg(IntPtr P_0)
	{
		jOjtcktBibmhaTFZqMnJlLjfqAA = true;
	}

	private void vzwGcjnDEOmCBoFIklCfwZNifrE()
	{
		jOjtcktBibmhaTFZqMnJlLjfqAA = true;
	}

	public void Dispose()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
		GC.SuppressFinalize(this);
	}

	~YkKIPPiCWZeAzAfNMTiDRgJXluDN()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
	}

	protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (inweGjIgYacXYohFlYRlpMFkgKMi)
		{
			return;
		}
		int num4 = default(int);
		while (true)
		{
			OAwecadieMdGJVeAljYncxPGwFCF();
			int num = -330525403;
			while (true)
			{
				int num7;
				switch (num ^ -330525403)
				{
				case 2:
					goto IL_0009;
				case 1:
					break;
				default:
					{
						ReInput.ApplicationIsFullScreenChangedEvent -= YKqmoqZCInuKpHQtBUSbdSMmAKI;
						ReInput.ApplicationFullScreenModeChangedEvent -= GsvmkLflhSjJdDfZtTTFjZClmvfh;
						lock (jjLEEEFLvmsJLpKePirapzQBKQTH)
						{
							if (P_0 && DhZbdMKNkujxkBYZovsLjyUUFhq != null)
							{
								goto IL_0074;
							}
							goto IL_0172;
							IL_0172:
							TpwYaCYUuJivXNAIKbrfIFiamHn();
							int num2;
							int num3;
							if (RQdPJSbvvMdPhNVeOTTxzTpjUat == null)
							{
								num2 = -330525402;
								num3 = num2;
							}
							else
							{
								num2 = -330525399;
								num3 = num2;
							}
							goto IL_0079;
							IL_0074:
							num2 = -330525407;
							goto IL_0079;
							IL_0079:
							while (true)
							{
								switch (num2 ^ -330525403)
								{
								case 6:
									break;
								default:
									goto end_IL_0063;
								case 4:
									num4 = 0;
									num2 = -330525393;
									continue;
								case 11:
									num4++;
									num2 = -330525406;
									continue;
								case 7:
									goto IL_00d1;
								case 2:
									if (DhZbdMKNkujxkBYZovsLjyUUFhq[num4] != null)
									{
										DhZbdMKNkujxkBYZovsLjyUUFhq[num4].UWOOMlZOWZtWbNikUvqswMufgfx();
										DhZbdMKNkujxkBYZovsLjyUUFhq[num4].Dispose();
										num2 = -330525394;
										continue;
									}
									goto case 11;
								case 5:
									ZSApAFaZOBjDuhAfJJXCcWSHPaw.WYoEhOBxiSjIYKwbsCHdGOUBXDbi();
									num2 = -330525404;
									continue;
								case 8:
									GRolUKdfCrfyXltJwHEsDBEFexK.Dispose();
									num2 = -330525408;
									continue;
								case 9:
									if (!pxdVJyAGwTQNGJDRzUSBDhXjucu)
									{
										goto case 5;
									}
									goto IL_0156;
								case 0:
									goto IL_0172;
								case 3:
									if (UNCDhikBVajwTkKrWKjlDBeTSzFD && dYGYigZHQLDxociHhyaSrGzXEUv != null)
									{
										dYGYigZHQLDxociHhyaSrGzXEUv.Dispose();
										num2 = -330525396;
										continue;
									}
									goto case 9;
								case 10:
									num2 = -330525406;
									continue;
								case 12:
									RQdPJSbvvMdPhNVeOTTxzTpjUat.Dispose();
									RQdPJSbvvMdPhNVeOTTxzTpjUat = null;
									num2 = -330525402;
									continue;
								case 1:
									goto end_IL_0063;
								}
								break;
								IL_0156:
								int num5;
								if (GRolUKdfCrfyXltJwHEsDBEFexK != null)
								{
									num2 = -330525395;
									num5 = num2;
								}
								else
								{
									num2 = -330525408;
									num5 = num2;
								}
								continue;
								IL_00d1:
								int num6;
								if (num4 >= DhZbdMKNkujxkBYZovsLjyUUFhq.Count)
								{
									num2 = -330525403;
									num6 = num2;
								}
								else
								{
									num2 = -330525401;
									num6 = num2;
								}
							}
							goto IL_0074;
							end_IL_0063:;
						}
						if (utNJDnvgtjyQuECjZnzMZfRDGij != null)
						{
							utNJDnvgtjyQuECjZnzMZfRDGij.Dispose();
							goto IL_01fb;
						}
						goto IL_0219;
					}
					IL_0200:
					switch (num7 ^ -330525403)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0219;
					case 2:
						return;
					}
					goto IL_01fb;
					IL_01fb:
					num7 = -330525404;
					goto IL_0200;
					IL_0219:
					inweGjIgYacXYohFlYRlpMFkgKMi = true;
					num7 = -330525401;
					goto IL_0200;
				}
				break;
				IL_0009:
				num = -330525404;
			}
		}
	}

	public unsafe static bool hbViCuxTSCahxePjlnRUwRUZuRvK(QTBMtemSTKEFyypUdDxnYBkZCjsF P_0, out int P_1)
	{
		P_1 = 0;
		uint num = 0u;
		YksGHYKteMuhDXToEsEFZvCVfCJ.IxiRznNLccenLgseDrJPlJNbHPI(IntPtr.Zero, ref num, (uint)Marshal.SizeOf(typeof(StoefIABSsMqhewHfXAHNOAILfl)));
		if (num == 0)
		{
			return false;
		}
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		StoefIABSsMqhewHfXAHNOAILfl* ptr = stackalloc StoefIABSsMqhewHfXAHNOAILfl[(int)num];
		YksGHYKteMuhDXToEsEFZvCVfCJ.IxiRznNLccenLgseDrJPlJNbHPI((IntPtr)ptr, ref num, (uint)Marshal.SizeOf(typeof(StoefIABSsMqhewHfXAHNOAILfl)));
		for (int i = 0; i < num; i++)
		{
			IntPtr udOaQKIUzemBrlkcmDTMEJLHkeko = ptr[i].UdOaQKIUzemBrlkcmDTMEJLHkeko;
			int num5 = 0;
			int num6 = tPBjZZpAtSQYcuGDlfDVOARrNX.iQnRybWcRmvuFPuoyUcrJruCuhM(udOaQKIUzemBrlkcmDTMEJLHkeko, gkbFimuvDpjWkMhCqsGoDzviJIQ.ORWYtJdjGudKfnNVexZorOLJXVN, IntPtr.Zero, ref num5);
			if (num5 == 0)
			{
				num4++;
				continue;
			}
			num3++;
			byte* ptr2 = stackalloc byte[(int)(uint)num5];
			*(int*)ptr2 = num5;
			num6 = tPBjZZpAtSQYcuGDlfDVOARrNX.iQnRybWcRmvuFPuoyUcrJruCuhM(udOaQKIUzemBrlkcmDTMEJLHkeko, gkbFimuvDpjWkMhCqsGoDzviJIQ.ORWYtJdjGudKfnNVexZorOLJXVN, (IntPtr)ptr2, ref num5);
			if (num6 >= 0)
			{
				coTdQBHIinEwNHUXyMqDcnzUPAno coTdQBHIinEwNHUXyMqDcnzUPAno2 = *(coTdQBHIinEwNHUXyMqDcnzUPAno*)ptr2;
				if (coTdQBHIinEwNHUXyMqDcnzUPAno2.YTPnvkUhAkJQzxOddhUvMmmVSrU == P_0)
				{
					num2++;
				}
			}
		}
		if (num4 > 0 && num3 == 0)
		{
			return false;
		}
		P_1 = num2;
		return true;
	}

	[CompilerGenerated]
	private static void EmiGNxfWEhzjCEIeJXtyCdBJenv(TPOFglCEUenQueqhakDnrjLmVbgq P_0)
	{
		P_0.Dispose();
	}

	static YkKIPPiCWZeAzAfNMTiDRgJXluDN()
	{
		lSAktsHdQgImZAEBfTGvitJGhA[] array = new lSAktsHdQgImZAEBfTGvitJGhA[4]
		{
			new lSAktsHdQgImZAEBfTGvitJGhA(1, 4),
			null,
			null,
			null
		};
		while (true)
		{
			int num = -1370045805;
			while (true)
			{
				switch (num ^ -1370045808)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					array[1] = new lSAktsHdQgImZAEBfTGvitJGhA(1, 5);
					num = -1370045807;
					continue;
				case 1:
					array[2] = new lSAktsHdQgImZAEBfTGvitJGhA(1, 8);
					array[3] = new lSAktsHdQgImZAEBfTGvitJGhA(12, 1);
					ynFnLhcMEIvmOEUUVQZSzzGuUtY = array;
					num = -1370045806;
					continue;
				case 2:
					return;
				}
				break;
			}
		}
	}
}
