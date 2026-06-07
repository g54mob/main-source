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

			private static PlayerMouse GmGeWrbOiKzEeMOkminuGWaexdgjA(int P_0, int P_1)
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
		private sealed class pymxBoiafyWxGSNqlzOmZwIyLXME
		{
			public static readonly pymxBoiafyWxGSNqlzOmZwIyLXME _003C_003E9;

			public static Predicate<Axis> _003C_003E9__18_0;

			public static Predicate<Axis> _003C_003E9__18_1;

			internal bool baSIbnjICkqLtfZNCNtHWKUnumAYb(Axis P_0)
			{
				return false;
			}

			internal bool SKbzDfZgwpCMpCtqaiIohRmeyqlkA(Axis P_0)
			{
				return false;
			}
		}

		internal const bool eHkrHlWOAQOsKsehwovuhbnIvypO = true;

		internal const float ThdgipbdPbYzekookZZHFRngtFXt = 1f;

		internal const bool DzDvcXVJGjCaWNifArLFtGjGpvNB = true;

		internal const bool dHwkHqDESgCraktuzUgqSnXcMBix = true;

		internal const MovementAreaUnit VYpQVTgmVLbJDyvPZHFCJmgXGmPu = MovementAreaUnit.Screen;

		internal static readonly ScreenRect JEvNVcODiZlyZexrOlXuFBxwvXdJ;

		private const int KTdMLoOGjqRvUEBTmYvvtEEfaRxh = 3;

		private const int pZlLgCyUJAuVWTCEXpezLMESfUFr = 3;

		internal const string BnzRgGcfwGnkpWjZMYVZlkVjMJRs = "Movement";

		internal const string chEAstFovVqtsqIkefxXLaZihecKA = "Horizontal";

		internal const string CirvGuyoShXuNPyuqpcuThhOheAV = "Vertical";

		internal const string wIudjmBwpFnGqaGaPiIcgAxUoRHB = "Wheel";

		internal const string RPieBIegxxenECLrBIWFzHDZDrhR = "Wheel Horizontal";

		internal const string PECrSIaXvtOSzpoqPmWOJCIFjkKY = "Wheel Vertical";

		internal const string PGoOGrXhsmAoArxDyWsscWiUoAtL = "Left Button";

		internal const string uQZigigtJtxRYSCLOtJTqbkxcavh = "Right Button";

		internal const string rMWCATKwVXfKAeEPlEyZVjbjxKcM = "Middle Button";

		private readonly int kRuzlwIMbqEFtKUGLSGASLoOETxOA;

		private readonly int BlPVyTINvIhYPvtjchrmQWMHcMNA;

		private readonly int CtSUAcNuDQNrvkpVGZuKYpCJDprD;

		private readonly int aHHYWdnORBaeqpqfPvHuTzeeiubh;

		private readonly int yOnTaRpbPjROwClWYnebIfqkIasU;

		private readonly int AMCxcdxFmQUoMzjoJwOsyXWtKiIJ;

		private bool jQzJiCjlJVyoShIKigiGYNpreAtU;

		private Vector2 UYGzDpRIUjDNWznmTGqgJDELjScxA;

		private Vector2 HHtajBIFxyJvUExNcCKGJAtsDBTib;

		private Vector2 siTbGtLeTGbDuFZtopnZslnXJnCt;

		private Vector2 OrjSqJZMjDdwCNclnWiGRXUtqbUD;

		private Vector2 MmXtdncuwAjCGhmNIbraqCubrxXD;

		private float wEKiejDvMbaykTUFXVEfixabiBfn;

		private bool MdadAAexidNpKKzbKududVqaniRqA;

		private Action<Vector2> StFgIDGaTqnMELypNdUoeGBBgqLoA;

		private bool yyMEqocKrUXEwJWrZbvtJSblwTLHA;

		private ScreenRect JQnuJLfTzrprPtFbJHQEvQrheYMp;

		private bool wMdpVKEJUBmUhMLEvwIcalmTmgcy;

		private MovementAreaUnit ejHFMIOwERjLMaYYmxjDxBXBAjLD;

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

		private void syIznxbdGblUlghSZwlFKhNKsJsr(Vector2 P_0)
		{
		}

		private ScreenRect XpLQvKmegdVNKSOKrrlnUZKSKkYo()
		{
			return default(ScreenRect);
		}

		private void usgWrFBAbrpIrjGGWsxPQqVTPneY()
		{
		}

		private static float fuobaVdWQEvjOrQgoIuAVGMQfCBf(Axis P_0, float P_1, float P_2)
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
