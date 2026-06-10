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

			private static PlayerMouse ocIbkoMmgHsnOyMMcObcgEoKEsQ(int P_0, int P_1)
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

		internal const bool tCGIfYyWjiKegaRvBFsQgRgusrz = true;

		internal const float NunndMZKmOeFcgzPSJBGLslejbB = 1f;

		internal const bool QlMNRtcEWGXfmVWnVuDGcBSvsog = true;

		internal const bool LtRtRjqguZFlMDfQZBcwevDVTEqd = true;

		internal const MovementAreaUnit ukEmFMtxHsfZMADyDAdbGbrokjnM = MovementAreaUnit.Screen;

		private const int NXHNtHVuUFfWECScmTMgxfMAqlX = 3;

		private const int RMsBFmedeCHTJfqEchGbzflikzpH = 3;

		internal const string PIfWJSiflRxtUbajhulTQqNPqZg = "Movement";

		internal const string eDGiqMcaTkPfBwDwETQvvdkCrkKL = "Horizontal";

		internal const string LQlILHmpnjLyeCKKQeBDlDPuHKuC = "Vertical";

		internal const string PTebKFSJRhGOJfYcARCgDkoyOnvH = "Wheel";

		internal const string wpWOovhAmbHcKeGjWpNELAupXwWB = "Wheel Horizontal";

		internal const string zLjfpkniGIjPGfoOiaiHDILUiwI = "Wheel Vertical";

		internal const string cufUIWsyDnzIDsbkTQvXrYGGQoO = "Left Button";

		internal const string njjICXhyLskrSjSviPLLDFBVNNd = "Right Button";

		internal const string HiepddeBIrevPjizrpEFUOCMgoS = "Middle Button";

		internal static readonly ScreenRect qvghtIlixpvwMLlKVgExAsFHrqI;

		private readonly int cJLYlqGMBsbiUgRdjhEhjeDRRmlk;

		private readonly int SSrYxTsAKSzcxpHLDvfFxMvhaKTa;

		private readonly int acUADbfRzkguimRYPumZIKzPmDp;

		private readonly int qwZQoFculWHHbYzdGYcrLrOmJcP;

		private readonly int MeeWLQJexryDVseWdXFowQOOaJk;

		private readonly int DyOJHwffWWcMTDfIvtachgJltug;

		private bool sfewTHrsCmVbTxGePAZUfpprjOB;

		private Vector2 rqQKNYmjqkbjcGPyxBkoqkGYafR;

		private Vector2 kHULzvPBFxyxXfwmHrqUnxPttbX;

		private Vector2 YtUNbqZGnkskMBQgbSDOQHkDukG;

		private Vector2 SZJMQgNjXigjzfAPUjxfouMhdTx;

		private Vector2 NoJQwoehrYoGRJgRdFxhNrSegLa;

		private float XwiTszKkDtlCBpAdlUEjLQILMmo;

		private bool MvieXlENcSdlqaoRUXNpJIFsGlMY;

		private Action<Vector2> ouIaddAZdUBgILBUoqlyQBKVaxnC;

		private bool xOJyrGGxVjZNCiEeoccykqAPBjdg;

		private ScreenRect ewNbHWqaXmjUbVdTdpugRCecVFx;

		private bool qeGiOtsqOmICXuOWRsgbrtOsHzm;

		private MovementAreaUnit BtzdoTfcWTSQukpSPHaXaCXdeho;

		[CompilerGenerated]
		private static Predicate<Axis> HMOMQkhRNslmnsRSdjdErMIPeq;

		[CompilerGenerated]
		private static Predicate<Axis> rWTPQhLeNWbucoWbsCbtCauqryk;

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

		private void eHOaFbhOoUyqzINIILgjzcXBFar(Vector2 P_0)
		{
		}

		private ScreenRect YihhxYAOHCGQikpuFakpIOLIghd()
		{
			return default(ScreenRect);
		}

		private void MIZxTsXuTaBAALLnLjQHbqZvhVE()
		{
		}

		private static float lkLjTvfaswDcIncXaUjwJqwIoxY(Axis P_0, float P_1, float P_2)
		{
			return 0f;
		}

		private bool QGXcSGBtmWXxTDOlMryPkOEcYytD(int P_0)
		{
			return false;
		}

		bool IMouseInputSource.GetButtonDown(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in QGXcSGBtmWXxTDOlMryPkOEcYytD
			return this.QGXcSGBtmWXxTDOlMryPkOEcYytD(P_0);
		}

		private bool rEJGllpYwoOueGVaUcLOmTAjLco(int P_0)
		{
			return false;
		}

		bool IMouseInputSource.GetButtonUp(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in rEJGllpYwoOueGVaUcLOmTAjLco
			return this.rEJGllpYwoOueGVaUcLOmTAjLco(P_0);
		}

		private bool PbrapwBUtZesYsHVrHXFTxpHXfwK(int P_0)
		{
			return false;
		}

		bool IMouseInputSource.GetButton(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in PbrapwBUtZesYsHVrHXFTxpHXfwK
			return this.PbrapwBUtZesYsHVrHXFTxpHXfwK(P_0);
		}

		[CompilerGenerated]
		private static bool gszDNAjqifGmfjOxMdsljKGQZLx(Axis P_0)
		{
			return false;
		}

		[CompilerGenerated]
		private static bool ThPcutahRslXbBrPcKRDITmGkhbH(Axis P_0)
		{
			return false;
		}
	}
}
