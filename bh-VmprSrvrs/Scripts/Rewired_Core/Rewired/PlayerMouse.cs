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

			private static PlayerMouse CuMvgXFlhthHFQjkTvzdZCAEWUcc(int P_0, int P_1)
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
		private sealed class vHgBInaYhRnbhFUYzXjtSCOCKycX
		{
			public static readonly vHgBInaYhRnbhFUYzXjtSCOCKycX _003C_003E9;

			public static Predicate<Axis> _003C_003E9__18_0;

			public static Predicate<Axis> _003C_003E9__18_1;

			internal bool fUDWqkHZFScYBdOXApEBDqGRLecA(Axis P_0)
			{
				return false;
			}

			internal bool MvngnanhDIhCEldvkQblGbGAHqPL(Axis P_0)
			{
				return false;
			}
		}

		internal const bool eYwwTosiTjTYxackcrLfarRqZHHg = true;

		internal const float RlQZaVDWGoSFcgzapJKDOVUGatOA = 1f;

		internal const bool DKnfElEbIhwjDqHbfXvUTagiaODCb = true;

		internal const bool dYwqidhaJXFKFabrnSwtXYjKJgSw = true;

		internal const MovementAreaUnit PhlmGUYlGggQespEJDTVOeUzLxdF = MovementAreaUnit.Screen;

		internal static readonly ScreenRect BBrkZduUziDiekiuSrHfQtNWMpXg;

		private const int UmfTdjsaiJBevHOAovQmGamXNNNib = 3;

		private const int rgjHeDIcAjhaxDjLRFgyIOcwhphq = 3;

		internal const string FtvVVVSErnVKYAgQQVoSirjJumzJ = "Movement";

		internal const string gzODieAoemEETWebknTMtGrABWYI = "Horizontal";

		internal const string GyxlDhKgTYFSuZhdaaEzMfTmCZet = "Vertical";

		internal const string ixmcGabfjwrKvUmFDnoLelmowTzmA = "Wheel";

		internal const string TqyKDVADeEDEtfSuRCSOawnnLGXfb = "Wheel Horizontal";

		internal const string RbUrQZAleAzMExLhVKNZSUolPTcg = "Wheel Vertical";

		internal const string RzszgmdNxBBklthQyCTxbUUmTcDj = "Left Button";

		internal const string opJODvYqYMIEpESYEgdAvDUHQLXs = "Right Button";

		internal const string ttQlbGsZEkjKnuqYtXkKKpBXMvOn = "Middle Button";

		private readonly int uoeYrhwyiZuFOQcZVGNPIgYiwCDh;

		private readonly int FnzFqvFiIGxGhkfmnmxgjZeoeXcAb;

		private readonly int GnUbfzGtbhkkEimoWuPDILZihkVpB;

		private readonly int iYTnhcHXEocZRfkePdWhQiCSkXTq;

		private readonly int krhWaSVhSWeyJGZVAKjqLkMKXVOr;

		private readonly int ITWWSkRXxllnhvAbRdkxvdeVoxkN;

		private bool bPjVFVLxCyXbzfRFgmiHNrTXnZZE;

		private Vector2 OhMLYqroJMRozthzZkirYMohjxAaA;

		private Vector2 ZybEkSrmWHOjrCQReWAHHPEMgjrh;

		private Vector2 qXPJCebeCheoJgZyeExCtNJxYIcV;

		private Vector2 UOzxfErjXoNGpNmhzAETJQtBzTsAA;

		private Vector2 STDrKmAcddQAzvaSAhhnAjcZrApdA;

		private float ibMcLwncZOLLHZZODLSgnHANswNM;

		private bool SCqzgZRduWYcjfmwYzBrMYsWLHld;

		private Action<Vector2> QFJpUjQANfbfPiiLMKbfLthJNzbA;

		private bool gQmNjkKovvRVQyaRvKcVnVRwutj;

		private ScreenRect BPhqMYTDqWMrwbCyLQbJwOFZpuiF;

		private bool itlkkVwOTentSUjTlUpjjEQzNNGL;

		private MovementAreaUnit axBYmRaGbqGQxAqFkCdEskbpQddbA;

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

		private void qHKCNqPLoKfgUaeXBjaKFztuwDYi(Vector2 P_0)
		{
		}

		private ScreenRect NQJCDPMQrGsNvUYHrdBeLUcoJDuI()
		{
			return default(ScreenRect);
		}

		private void kNmWZErqRWvWFxTAWvCVZbVtUIsb()
		{
		}

		private static float bmybWGhLBdIWtInJuQCZiKsunEtyA(Axis P_0, float P_1, float P_2)
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
