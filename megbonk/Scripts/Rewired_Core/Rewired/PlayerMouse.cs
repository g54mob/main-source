using System;
using Rewired.UI;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public sealed class PlayerMouse : PlayerController, IPlayerMouse, IPlayerController, IMouseInputSource
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

			private static PlayerMouse LdlzyEzgmZaDVBNxLfNwFcCnIAHVA(int P_0, int P_1)
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
		private sealed class eSLNoDucCfTZbLYMEBaivWXtwIpE
		{
			public static readonly eSLNoDucCfTZbLYMEBaivWXtwIpE _003C_003E9;

			public static Predicate<Axis> _003C_003E9__18_0;

			public static Predicate<Axis> _003C_003E9__18_1;

			internal bool epfuDKQeMlGQYgMUiLXTacgBfHrjc(Axis P_0)
			{
				return false;
			}

			internal bool TOWDbIHBukpLCdehRUgiqlSluREkA(Axis P_0)
			{
				return false;
			}
		}

		internal const bool zOThhKUPATOrbfFqPNPuTTVXhZCp = true;

		internal const float EIKwKUxXXqbyFvFjNBfHpYPbxegT = 1f;

		internal const bool GQYJfDHEVRLoTCGlMTWXDUiHErEi = true;

		internal const bool mpTphRLjSnCsXxunAyKoytxtsgZK = true;

		internal const MovementAreaUnit YNYevsoLVEbGmrpKoJbAnFKYRNau = MovementAreaUnit.Screen;

		internal static readonly ScreenRect KyAGvDQHiWlbufnchERazoLjHUADA;

		private const int ZQhgVJKvdUSdSLMPTitvZysjTCSA = 3;

		private const int qtOGGpwYJHuWpEeToOAvheaVnvcr = 3;

		internal const string OFIFGlgBwJnnMNFUpBzPFRreseuQA = "Movement";

		internal const string lphyUQgodEVyXFkfDwFPErrtaHDy = "Horizontal";

		internal const string LyKCePksKqUtysEzVKAmCdHBpDdHA = "Vertical";

		internal const string lHNPpODkaIkFtxFHigCKUWuLSBio = "Wheel";

		internal const string GkHUNfoixqeknPMyuwEFVajYcQMR = "Wheel Horizontal";

		internal const string MhlhsjcWvqOVIyRvuksStJoIFLrY = "Wheel Vertical";

		internal const string UvVhgGTNshAnncYMDsWwQDMJDTKt = "Left Button";

		internal const string fYuOEHoIHkAavNgUdmJLCrCwfLYT = "Right Button";

		internal const string wdvsMiOATOJopvGWWqEXpdDmHjJY = "Middle Button";

		private readonly int zoTBJNKKvrnECwJTcriMfrAZFsKpA;

		private readonly int OXYfjRWJZwqKbkFoOZPvumuRJMzf;

		private readonly int TnrknZJaWVYEKxyAjhjIckLWqPMl;

		private readonly int bLceVAnyRCdeHwwokXEsfeWvTTML;

		private readonly int fEMboZpZkKCPfPLFfJxBoEzdNTac;

		private readonly int FDhRDOfqJVBDryjRqQQsEimqrUpE;

		private bool kmWmInnEJSyrzqmTTeOGyvJoibIU;

		private Vector2 XufPqYXCUcDKdkOfmIUgixuGSvPKA;

		private Vector2 COUXLwBjzdXylLTMDhcOuPXjFewJA;

		private Vector2 nRuLuQPSVTWUVWhiBJbDUwVCMVxI;

		private Vector2 XzKcesXCPKkJfUpOOkWGrpFyTEng;

		private Vector2 JxmdFMmpuXcqjszSlmDwIBocpCeN;

		private float dXfPESJpMgabTUiOkfcrEYMgowKjA;

		private bool FtHVcljMmcpofwnopEDselWrIJoqA;

		private Action<Vector2> HmoTkmmyBbSPtpKkaGgwgCtGgToBA;

		private bool nrxsSJYxzLAJTTqkocXhoTJkYusv;

		private ScreenRect GzCGhoaplahyyYyiueeWTSZudxbBA;

		private bool xIGkvlKLUGmTCBKREUieOgIQlHNy;

		private MovementAreaUnit dNipanQmlMqbTrHFJPGXBdmSxNyD;

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

		private void xrhBLYdfCeJRGjdHqWDJQozPNeBqA(Vector2 P_0)
		{
		}

		private ScreenRect OdueVpgcgiVKxFqZYRHfmrwZSLnO()
		{
			return default(ScreenRect);
		}

		private void pDBePebZzgzHSqMTdQHPeXzIRMRy()
		{
		}

		private static float wLNRmgbGKJmVryPkFaEAffqHOwgf(Axis P_0, float P_1, float P_2)
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
