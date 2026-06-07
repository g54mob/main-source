using System;
using System.Runtime.CompilerServices;
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

			private static PlayerMouse byjpFPaNIphrKciIajhIxYJzCeOY(int P_0, int P_1)
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

		internal const bool aIvXwpMfTAclwiEbJlPeYzNRUnv = true;

		internal const float GzIHxdtTYoGEccbVWmwopjGXtVJ = 1f;

		internal const bool BCvhBOECiiHkgDkjRZgkIspEDss = true;

		internal const bool QamhZQWjCfmeAHzKRvRYRVccGYs = true;

		internal const MovementAreaUnit ppznCdNgpAjSCGncHwMXXmETRrl = MovementAreaUnit.Screen;

		private const int WBeFNypogjHLCUhaudxMDexzfsR = 3;

		private const int KODbEVZWduAgVwdUdrMTZVCDpab = 3;

		internal const string UYMhZvOPmngqSdzJxMCvyeMkBmo = "Movement";

		internal const string bfiApPQfMZaHiFiCPxFgBDpAqCa = "Horizontal";

		internal const string YIAlnaOzHHzCyEzGEqPnLDoDGxq = "Vertical";

		internal const string OnZEqqopbBAVTiYcUknAoUPVcnpI = "Wheel";

		internal const string bhlAwSJMCTfNGWMzIqxecVtQwgU = "Wheel Horizontal";

		internal const string wWGzHLBSIqWgApCuyEJnCdaprkCj = "Wheel Vertical";

		internal const string pBKMqbYchZbaLgagXPrhhFbzlGEt = "Left Button";

		internal const string cpSsVmLGvKBkYxkrqvubfbuajFd = "Right Button";

		internal const string KFXxZGMdmDTpJvmpfhOdDkzvWuSE = "Middle Button";

		internal static readonly ScreenRect vRLSTjPIBZbmKELOXBJTGugaqpIA;

		private readonly int pmyHxVgzNQzKTklFdxkFWotkqCr;

		private readonly int DiSXMuYgqodBjtPzTQifXKhIEyR;

		private readonly int tldQyKRiPSczqeQYNkVtiIAsOgv;

		private readonly int pimcgXUVGqfYNiYhMYpNdXSNoZN;

		private readonly int BOFwipdMMBXvDeQIhHwKAAvdAkwb;

		private readonly int UqxnGTHdseaVVbYQxpPEAkgAses;

		private bool fbPQAiPhoEXSFxNiTqkePUIQGWB;

		private Vector2 yBzCcgeMRSZqzVKFbGqSbGLjrkdH;

		private Vector2 xmbPgQlztHstDxKkFPowXAmIbmT;

		private Vector2 VRbcdLalkKGjCsRWbXxsEaTsNyMn;

		private Vector2 FWcSoFrmJQAtbExJYxWBbMlOthlj;

		private Vector2 MXiRuXKkHcFfJTAXbIMJlVnFDTi;

		private float IiPezTdsChPiGapClllkYdnaAUcr;

		private bool XZEhCXoAatmyBsHkYyZgwiFVpWB;

		private Action<Vector2> bwbJgIjXymrjGLCsuGfCtxasdPj;

		private bool qXqLAjelzXZGYaDsmgPMkAtgjndJ;

		private ScreenRect vPqErjUHnURPdJvNhJLIpdZNQNl;

		private bool pavPMWAsaCvNLiIADnZXBffHmHm;

		private MovementAreaUnit UPEUVsNCgzELcharJYupIGgAyyug;

		[CompilerGenerated]
		private static Predicate<Axis> GUtEutEEzltmqOpNYrKXdcztHioU;

		[CompilerGenerated]
		private static Predicate<Axis> eeshfSnjdakpwyldchITaKDVJgk;

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

		private PlayerMouse(Definition definition)
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

		private void tQbQOAVPSmVpnOlAEFkBZqyygqpa(Vector2 P_0)
		{
		}

		private ScreenRect JTWyLvoqggcFqsTpHfPRfkzpyclC()
		{
			return default(ScreenRect);
		}

		private void NlkpCNvelOTmCVavDCdjBssCfZW()
		{
		}

		private static float avgXTWDMGOnKSbuBsMhWjeLjdsMC(Axis P_0, float P_1, float P_2)
		{
			return 0f;
		}

		private bool RvowvmVIpsuXeKpLWHlyknDJalu(int P_0)
		{
			return false;
		}

		bool IMouseInputSource.GetButtonDown(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in RvowvmVIpsuXeKpLWHlyknDJalu
			return this.RvowvmVIpsuXeKpLWHlyknDJalu(P_0);
		}

		private bool wPcYcQHJoKBRaYkHCPBeEtyETFk(int P_0)
		{
			return false;
		}

		bool IMouseInputSource.GetButtonUp(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in wPcYcQHJoKBRaYkHCPBeEtyETFk
			return this.wPcYcQHJoKBRaYkHCPBeEtyETFk(P_0);
		}

		private bool MqWZSDyDHvhwKPBEzsKxZYscjoe(int P_0)
		{
			return false;
		}

		bool IMouseInputSource.GetButton(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MqWZSDyDHvhwKPBEzsKxZYscjoe
			return this.MqWZSDyDHvhwKPBEzsKxZYscjoe(P_0);
		}

		[CompilerGenerated]
		private static bool pAKNvjFTOFKFtnExWcOJCZtnKTnG(Axis P_0)
		{
			return false;
		}

		[CompilerGenerated]
		private static bool UvwIIIXhUQMbypLKCohAvZJTvXX(Axis P_0)
		{
			return false;
		}
	}
}
