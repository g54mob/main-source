using System;
using Rewired.UI;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public sealed class PlayerMouse : PlayerController, IPlayerController, IPlayerMouse, IMouseInputSource
	{
		public new sealed class Definition : PlayerController.Definition
		{
			public bool defaultToCenter;

			public bool clampToMovementArea;

			public ScreenRect movementArea;

			public MovementAreaUnit movementAreaUnit;

			public float pointerSpeed;

			public bool useHardwarePointerPosition;

			internal Definition()
			{
			}
		}

		public new static class Factory
		{
			public static PlayerMouse Create()
			{
				return null;
			}

			private static PlayerMouse goGesjEFofcTayLyzynfoITRPCBk(int P_0, int P_1)
			{
				return null;
			}

			public static PlayerMouse Create(Definition definition)
			{
				return null;
			}
		}

		public enum MovementAreaUnit
		{
			Screen = 0,
			Pixel = 1
		}

		[Serializable]
		private sealed class JQUhhHLddIEMgGJChcuaTIHgwNPSA
		{
			public static readonly JQUhhHLddIEMgGJChcuaTIHgwNPSA _003C_003E9;

			public static Predicate<Axis> _003C_003E9__18_0;

			public static Predicate<Axis> _003C_003E9__18_1;

			internal bool mmyHjISlDoMXkdXfbNguuMIIZlUO(Axis P_0)
			{
				return false;
			}

			internal bool OGlSkPZhCHbaEEreGeXQXFldjnBOA(Axis P_0)
			{
				return false;
			}
		}

		internal const bool dSWAqHKsdOKgYhmXMgSHTsFpsQcbb = true;

		internal const float JjjyiZTYcmqVOaLbHdpTdDOfBEMjb = 1f;

		internal const bool WZYYKeuDSctjELkJABvVqejaRLrS = true;

		internal const bool DDqbeknynfBqPnkUKEzvUaEdApk = true;

		internal const MovementAreaUnit qzAxSHdNLMeZudIKCvPwjlUzzMoZ = MovementAreaUnit.Screen;

		internal static readonly ScreenRect wHicjJlMdHxzwNcNMKzoAePSQBXf;

		private const int VLHTsEHlUppQqIsMdiVnderNHCER = 3;

		private const int JYehQthdygfZtbissPuavrUxnMklA = 3;

		internal const string XUpqSFodxtthwtGTwXFAOMmWFabaA = "Movement";

		internal const string gnWijJgOPSyrtDbQHQaspSJVqNNN = "Horizontal";

		internal const string VgzdYIuUvBfmEeYoFTrIwhubovtAb = "Vertical";

		internal const string DEsBCMIBLLIrVMUqVervwXMtYgKB = "Wheel";

		internal const string gdIazuxgwZvugOYHXKhXWFZaJPPq = "Wheel Horizontal";

		internal const string vAdwBnhyumxIovtWnESGLSuXBPDl = "Wheel Vertical";

		internal const string eFnZGVgDINnobwEhIcuAbxNLnWHE = "Left Button";

		internal const string xYzALQFjZCTfsqvTvobKYZoUtuuSA = "Right Button";

		internal const string DxsyTgoVMHcxfhVJyNGECzfJVfXH = "Middle Button";

		private readonly int iwBlmrYTJWHcmywVqPouwsqIxXoU;

		private readonly int MevNeOeHWeuwJvvfEsLGfrMmmpUn;

		private readonly int epEPbclKpOwMYmEgOIQOYCIMRxyE;

		private readonly int amPBgvuCogHTlGOZZiNyVbYvdkWP;

		private readonly int UsgVbHRqmLkFleUkuzEluflBiPtm;

		private readonly int NNUcOrCfGinWjtsaaEQdjwgipDbAA;

		private bool wsofnKbSwMJFpjjYWlGNlVOgdgYk;

		private Vector2 lFWPICmzzKtBVSwhctofqGXDDnel;

		private Vector2 qwGxyaXxJLIdnpKUCJYJjimoRKCW;

		private Vector2 IjYAEdNZIIrgmPNomOmDKnVCEFLBA;

		private Vector2 YmBZIlLSvMypLnbwJRCemKxeWyqJ;

		private Vector2 HBFNsxaBbosljLIniFKkZilvuOpH;

		private float HmmEqnMfqxJjsrqayBmRcXnIXfnWA;

		private bool QgieMoYtmeqbGiBfXEfeiSifYGPLA;

		private Action<Vector2> ggAkkgXxbaqckZYwjpBbBivEGUwFA;

		private bool dBNzoFUVAPDVucYrlGrbcxeCYdoG;

		private ScreenRect ihLIBumLsYWRsDniqSzXPHkreanc;

		private bool urQthugGxOMihwbiMGTqjjntwRjF;

		private MovementAreaUnit JhzeQQrSQfACCwYBIjoWiMuaJNvg;

		public bool defaultToCenter
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool clampToMovementArea
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ScreenRect movementArea
		{
			get
			{
				return default(ScreenRect);
			}
			set
			{
			}
		}

		public MovementAreaUnit movementAreaUnit
		{
			get
			{
				return default(MovementAreaUnit);
			}
			set
			{
			}
		}

		public Vector2 screenPosition
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Vector2 screenPositionPrev => default(Vector2);

		public Vector2 screenPositionDelta => default(Vector2);

		public MouseAxis xAxis => null;

		public MouseAxis yAxis => null;

		public MouseWheel wheel => null;

		public Button leftButton => null;

		public Button rightButton => null;

		public Button middleButton => null;

		public float pointerSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool useHardwarePointerPosition
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		bool IMouseInputSource.enabled => false;

		Vector2 IMouseInputSource.screenPosition => default(Vector2);

		Vector2 IMouseInputSource.screenPositionDelta => default(Vector2);

		Vector2 IMouseInputSource.wheelDelta => default(Vector2);

		bool IMouseInputSource.locked => false;

		public event Action<Vector2> ScreenPositionChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		private PlayerMouse(Definition P_0)
			: base(null)
		{
		}

		protected override bool Update(UpdateLoopType updateLoop)
		{
			return false;
		}

		protected override void UpdateFinished()
		{
		}

		protected override void ClearVars()
		{
		}

		private void wtYdykpqpgoeNICyHjhyrsaIBkgk(Vector2 P_0)
		{
		}

		private ScreenRect UxvslNCuSeQLUmFvCIZaAzcJNaif()
		{
			return default(ScreenRect);
		}

		private void GuNmIlJmNSCKygRZEacWRlmeNaPSA()
		{
		}

		private static float fXJiIkxOuYFuwxCjdaVnZiNFPPJH(Axis P_0, float P_1, float P_2)
		{
			return 0f;
		}

		bool IMouseInputSource.GetButtonDown(int button)
		{
			return false;
		}

		bool IMouseInputSource.GetButtonUp(int button)
		{
			return false;
		}

		bool IMouseInputSource.GetButton(int button)
		{
			return false;
		}
	}
}
