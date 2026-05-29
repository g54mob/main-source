using UnityEngine;

namespace Rewired
{
	public struct ControllerPollingInfo
	{
		private bool JOveJFMWTchNOdpKhngVIpmFlkqF;

		private int VUcYiZtcJRatratRXOokIFfcdNSg;

		private int WuIXWewTRtkXNcGHNDHMpyChWRj;

		private string nkQLANamSUzCAQZqnFeBGKRcsaY;

		private ControllerType CiEHnIGrjScHYHuMEoDVXvEgwiy;

		private ControllerElementType ZcCJfoFOnfaVWPxSGABewnPoqKP;

		private int ZwgAVZCxcUqkUVeFEgwfcqhdLwxy;

		private Pole qcVSRCvLMSfMUycBQBBPJhLuSUdB;

		private string FcZlvtEnXFMiEicBtcTcDitrjYGb;

		private int TZSPqisJATrQkFfRXLKedgRIcwv;

		private KeyCode OtMwDsHLHMdIVTXOqbZZFLhUGVHJ;

		public bool success
		{
			get
			{
				return JOveJFMWTchNOdpKhngVIpmFlkqF;
			}
			internal set
			{
				JOveJFMWTchNOdpKhngVIpmFlkqF = value;
			}
		}

		public int playerId
		{
			get
			{
				return VUcYiZtcJRatratRXOokIFfcdNSg;
			}
			internal set
			{
				VUcYiZtcJRatratRXOokIFfcdNSg = value;
			}
		}

		public int controllerId
		{
			get
			{
				return WuIXWewTRtkXNcGHNDHMpyChWRj;
			}
			internal set
			{
				WuIXWewTRtkXNcGHNDHMpyChWRj = value;
			}
		}

		public string controllerName
		{
			get
			{
				return nkQLANamSUzCAQZqnFeBGKRcsaY;
			}
			internal set
			{
				nkQLANamSUzCAQZqnFeBGKRcsaY = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return CiEHnIGrjScHYHuMEoDVXvEgwiy;
			}
			internal set
			{
				CiEHnIGrjScHYHuMEoDVXvEgwiy = value;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return ZcCJfoFOnfaVWPxSGABewnPoqKP;
			}
			internal set
			{
				ZcCJfoFOnfaVWPxSGABewnPoqKP = value;
			}
		}

		public int elementIndex
		{
			get
			{
				return ZwgAVZCxcUqkUVeFEgwfcqhdLwxy;
			}
			internal set
			{
				ZwgAVZCxcUqkUVeFEgwfcqhdLwxy = value;
			}
		}

		public Pole axisPole
		{
			get
			{
				return qcVSRCvLMSfMUycBQBBPJhLuSUdB;
			}
			internal set
			{
				qcVSRCvLMSfMUycBQBBPJhLuSUdB = value;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				return FcZlvtEnXFMiEicBtcTcDitrjYGb;
			}
			internal set
			{
				FcZlvtEnXFMiEicBtcTcDitrjYGb = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return TZSPqisJATrQkFfRXLKedgRIcwv;
			}
			internal set
			{
				TZSPqisJATrQkFfRXLKedgRIcwv = value;
			}
		}

		public KeyCode keyboardKey
		{
			get
			{
				return OtMwDsHLHMdIVTXOqbZZFLhUGVHJ;
			}
			internal set
			{
				OtMwDsHLHMdIVTXOqbZZFLhUGVHJ = value;
			}
		}

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (!ReInput.lGcKTymIVPnyTtnJFgbcUzeJcSS.pAdUIyPLGgWUUEGNZNyEKBMtlXt(VUcYiZtcJRatratRXOokIFfcdNSg))
				{
					return null;
				}
				return ReInput.lGcKTymIVPnyTtnJFgbcUzeJcSS.mGsUlCssxNPJpaIPjZSPUkhxHGhB(VUcYiZtcJRatratRXOokIFfcdNSg);
			}
		}

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(CiEHnIGrjScHYHuMEoDVXvEgwiy, WuIXWewTRtkXNcGHNDHMpyChWRj);
			}
		}

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (!ReInput.isReady)
				{
					goto IL_0007;
				}
				Controller controller = this.controller;
				int num;
				if (controller == null)
				{
					num = -784694008;
					goto IL_000c;
				}
				return controller.GetElementIdentifierById(TZSPqisJATrQkFfRXLKedgRIcwv);
				IL_0007:
				num = -784694005;
				goto IL_000c;
				IL_000c:
				switch (num ^ -784694006)
				{
				case 0:
					break;
				case 1:
					return null;
				default:
					return null;
				}
				goto IL_0007;
			}
		}

		internal ControllerPollingInfo(bool success, int playerId, int controllerId, string controllerName, ControllerType controllerType, ControllerElementType elementType, int elementIndex, Pole axisPole, string elementIdentifierName, int elementIdentifierId, KeyCode keyboardKey)
		{
			JOveJFMWTchNOdpKhngVIpmFlkqF = success;
			VUcYiZtcJRatratRXOokIFfcdNSg = playerId;
			WuIXWewTRtkXNcGHNDHMpyChWRj = controllerId;
			nkQLANamSUzCAQZqnFeBGKRcsaY = controllerName;
			CiEHnIGrjScHYHuMEoDVXvEgwiy = controllerType;
			ZcCJfoFOnfaVWPxSGABewnPoqKP = elementType;
			ZwgAVZCxcUqkUVeFEgwfcqhdLwxy = elementIndex;
			qcVSRCvLMSfMUycBQBBPJhLuSUdB = axisPole;
			FcZlvtEnXFMiEicBtcTcDitrjYGb = elementIdentifierName;
			TZSPqisJATrQkFfRXLKedgRIcwv = elementIdentifierId;
			OtMwDsHLHMdIVTXOqbZZFLhUGVHJ = keyboardKey;
		}

		internal ControllerPollingInfo(ControllerPollingInfo source)
		{
			JOveJFMWTchNOdpKhngVIpmFlkqF = source.JOveJFMWTchNOdpKhngVIpmFlkqF;
			VUcYiZtcJRatratRXOokIFfcdNSg = source.VUcYiZtcJRatratRXOokIFfcdNSg;
			WuIXWewTRtkXNcGHNDHMpyChWRj = source.WuIXWewTRtkXNcGHNDHMpyChWRj;
			nkQLANamSUzCAQZqnFeBGKRcsaY = source.nkQLANamSUzCAQZqnFeBGKRcsaY;
			CiEHnIGrjScHYHuMEoDVXvEgwiy = source.CiEHnIGrjScHYHuMEoDVXvEgwiy;
			ZcCJfoFOnfaVWPxSGABewnPoqKP = source.ZcCJfoFOnfaVWPxSGABewnPoqKP;
			ZwgAVZCxcUqkUVeFEgwfcqhdLwxy = source.ZwgAVZCxcUqkUVeFEgwfcqhdLwxy;
			qcVSRCvLMSfMUycBQBBPJhLuSUdB = source.qcVSRCvLMSfMUycBQBBPJhLuSUdB;
			FcZlvtEnXFMiEicBtcTcDitrjYGb = source.FcZlvtEnXFMiEicBtcTcDitrjYGb;
			TZSPqisJATrQkFfRXLKedgRIcwv = source.TZSPqisJATrQkFfRXLKedgRIcwv;
			OtMwDsHLHMdIVTXOqbZZFLhUGVHJ = source.OtMwDsHLHMdIVTXOqbZZFLhUGVHJ;
		}

		internal static ControllerPollingInfo BasGLvYPyImwRTtaYaElepJTftA()
		{
			return new ControllerPollingInfo(false, -1, -1, string.Empty, ControllerType.Keyboard, ControllerElementType.Axis, -1, Pole.Positive, string.Empty, -1, KeyCode.None);
		}
	}
}
