using System.Collections.Generic;
using Rewired.Platforms.Custom;

namespace Rewired.Platforms.XboxOne
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal sealed class XboxOneInputSource : CustomInputSource, IXboxOneInputSource
	{
		[CustomObfuscation]
		private enum BadConnectionReason
		{
			[CustomObfuscation]
			None = 0,
			[CustomObfuscation]
			GamepadNotActive = 1,
			[CustomObfuscation]
			InvalidName = 2
		}

		private struct LHranhjgcYahoLHHqOjsfZVPsMjjb
		{
			public uint MoaYEjrLFoYkBemAelbFTXOAMzBT;

			public uint fqFJlKjOHjVtrnNTuPAENkyiUuHs;

			public LHranhjgcYahoLHHqOjsfZVPsMjjb(uint P_0, uint P_1)
			{
				MoaYEjrLFoYkBemAelbFTXOAMzBT = 0u;
				fqFJlKjOHjVtrnNTuPAENkyiUuHs = 0u;
			}
		}

		private class rujIRYAcHgTrblxQgsVFVBGfilC : Joystick
		{
			private const int hTtWFqoKfkIVSdGOWffSHmWvCWjfA = 6;

			private const int BhCbgrefAhFSrJIISsNLWhvlnnANA = 14;

			private const string QWXsbbOKXViOJereSHAFWqMwgUGr = "Xbox One Controller";

			private const int pUNoZFjhAbRtbyRCcLbzgHRImitf = 0;

			private const int AMikShWKFTMdvXKDYvpCAXTLFtSS = 1;

			private const int hxuztowzSKPMFZirIyruyikzmSPs = 2;

			private const int YOWFyZOFSHRaLQZXHeoVldsrpbXi = 3;

			private const int VKANNVTLrAbYQDnrZsvsDWvzQcbNA = 4;

			private const int cvidxnvIZypxxKgBeVnzBetggZIy = 5;

			private const int WnPVqGdMqyWziEuNCLDZSvxWtLeU = 6;

			private const int tBCbJMJCkGaFpsCrwyVzCJLwNJtl = 7;

			private const int VxgaBwBCHQnFfYeXqWFixWQuqibuA = 8;

			private const int xVRMqnlXpFLXvdLNWocqfssMQgNL = 9;

			private const int QdkiJReJpCMLoUpwSiuXQbqOMgDk = 12;

			private const int VggjtiILbwgLnYULsnBwnFxQASah = 13;

			private const int lwrEoAEQHDMKTSSnyKgvGXLjxSyU = 14;

			private const int tuSwyqfQwEBxzbFfpbeojDCcAizR = 15;

			private const int zpyQuPBZTVWrfMTTrLIAHbiuMRqc = 0;

			private const int EzPfYrptdzhtAmWhFScyELDkTFSc = 1;

			private const int DVoHVLpIVhSWbXFAsulbDkMwyOKT = 3;

			private const int QjxfepdVfeMxBgiApWtdaJhmTWWtA = 4;

			private const int nnFAggwrlNFnvGVbGdxvfgudccLLA = 8;

			private const int KeEZsvohyekdNFRSIlHOGIYitWHs = 9;

			private readonly IXboxOneInputSource ieYluIwipVjyjzLjHAiijAxmNxsP;

			private int xlzwqHtwYBSMRvLFABJfHAkXCpwFA;

			private ulong oDJJfhmKlWFgtRawLVCCKHBEewKEA;

			private string[] NKNDXQanYWbRlGTUvsgYvJETCIUm;

			public ulong lhvDsQPcLZOThRXxyjheiSPWTvpT => 0uL;

			public rujIRYAcHgTrblxQgsVFVBGfilC(IXboxOneInputSource P_0, ulong P_1, int P_2, bool P_3)
				: base(null, null, 0, 0, 0)
			{
			}

			public override void Update()
			{
			}

			public void gUxczTgMdKUcYRnCXamteWaCXJodc(ulong P_0)
			{
			}

			private void XgwbhwHygfckKPbCmHYWDLomAXsc()
			{
			}

			private bool PKxzXBSMXndnnwoVrPblHLVDZExv(int P_0)
			{
				return false;
			}

			private void eqCErkQjJzeZQbwnFzuClGTXiiar()
			{
			}
		}

		private const int uZtyPIlJauCmfVvHgfRVRuZomYlQ = 8;

		private readonly bool qumTafanxrjKbDduWdypwIzXqmiP;

		private bool HnCfKzJTZtvFvdLbXzfTLPfLrnkpA;

		private Queue<LHranhjgcYahoLHHqOjsfZVPsMjjb> sYWnIHxKZbXfXgnwCQTkMqzxybWR;

		private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

		public override bool isReady => false;

		public XboxOneInputSource()
			: base(0)
		{
		}

		public override void Update()
		{
		}

		private void gArKfWdiwKdfIEQOTJlyNbijJpkp(uint P_0, bool P_1)
		{
		}

		private void EWrRYZIpjhOHaVdVPbaZGvChAKFDA(uint P_0, bool P_1)
		{
		}

		private void vtOgxOYCiXieoboCpugDoJSkUCihA()
		{
		}

		private bool YyhnGclWdyuLrNCGpPoxCZRCbjHA(uint P_0, bool P_1, out BadConnectionReason P_2)
		{
			P_2 = default(BadConnectionReason);
			return false;
		}

		private void GMbrTnnZRTBiLXkqzzZhHAuiYfCn()
		{
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			return 0;
		}

		public void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
		}

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, ZCUdBedUUjmCBSWhOAJNcgvTbdyn vibration)
		{
			return false;
		}

		public override void Dispose()
		{
		}

		~XboxOneInputSource()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
