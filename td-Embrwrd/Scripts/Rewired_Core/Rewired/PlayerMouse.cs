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

			private static PlayerMouse IjagBQciAKeGDhLwoxxCcaQZMjMG(int P_0, int P_1)
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
		private sealed class jbQBRFFpWsHolDdFilhMSbGiZqksB
		{
			public static readonly jbQBRFFpWsHolDdFilhMSbGiZqksB _003C_003E9;

			public static Predicate<Axis> _003C_003E9__18_0;

			public static Predicate<Axis> _003C_003E9__18_1;

			internal bool jUoLJCNDespOOucBXdtzscyNnRcr(Axis P_0)
			{
				return false;
			}

			internal bool UEVjIXACzdoCQOoOuYAQdGgHHPqB(Axis P_0)
			{
				return false;
			}
		}

		internal const bool gEGbjARckObChIZzwEfWFBFxPJFcb = true;

		internal const float RbFQKUeAdfXjDBmouDipbCTTkidp = 1f;

		internal const bool XzHtPLOftCyuRoayxIbzXeaveWLfA = true;

		internal const bool teStUVInmmRhLXVufcLMcxbToLQg = true;

		internal const MovementAreaUnit XVRdjsljdNCtaeHZLVFklhAaoHdeb = MovementAreaUnit.Screen;

		internal static readonly ScreenRect LBXafLRbUTUKoRQrYtdIjIJNhORbA;

		private const int OxBgsRABZyUflpfDwEMNuHwWILLxA = 3;

		private const int vWNGptjWbWfzbaRCHuLNbzglnWbf = 3;

		internal const string XkVBQxpqKYMYWlBVQuRbBIzQIefq = "Movement";

		internal const string abwKtArHLTXZNngHkzczYAvPFQMf = "Horizontal";

		internal const string KBJeXwvmSlAmNqsKmuCGjHwjNgpb = "Vertical";

		internal const string soCvZAOOSVSJxLnCTwRkSEydgBhp = "Wheel";

		internal const string XPGIUpzpLfEZhhrjZsAbLrfkpILV = "Wheel Horizontal";

		internal const string BCwdexbLBjfgSEmmTHAyrKqmfNwAA = "Wheel Vertical";

		internal const string BESkSKOzYeWvpOiZmKmIEoQdRJPH = "Left Button";

		internal const string gRvhSJpnzzWLvjNJSdzfQvWWBNXFA = "Right Button";

		internal const string hMcjicXvfBWFtPPLhsuhryHIfJAm = "Middle Button";

		private readonly int uNWVbZJROmtLOzWRZQsmjUGvyXTc;

		private readonly int ZVPTlHRPtrDVvQExnAzLqFqpNuyL;

		private readonly int CWqYqDGkQIChYLHjAbTwwEHwIqJEA;

		private readonly int milKwGgybJOYXQvhBNbMdlSHmBDR;

		private readonly int wULepkEidpntVzhGImdLxuEJdTUdb;

		private readonly int YsaEZOGcSWHexDMmBNgCcOoUbvwxA;

		private bool lNVWsduqbZUxdAKSkgmymZiKhgJg;

		private Vector2 QzejJUERihebjEMkZOgCjhaoydYO;

		private Vector2 JBTHSoMNukRatrNdsMPseHoDkdjD;

		private Vector2 gKxmVEOrfCerRwMpoJbbOkVegMsu;

		private Vector2 IuRZuaClsLBZjapyfxIsjGtYePiZ;

		private Vector2 KpdETUbCCSDFxCCJQPfYSUkWAWdZ;

		private float qEoAMUKtarCBJiVFNAjZCOWSkIBj;

		private bool YWUeujiCRrJExWjKIzGUrWaXTCve;

		private Action<Vector2> WNzoikhajecwvZQbVOKKsabsFMbL;

		private bool aSeUPPVCPAquDnbxTrhPiHRCothF;

		private ScreenRect HRadeKiZjENoEOzIHMqIZXwGbsYB;

		private bool gnZbRdLyuXmJKdDExAQWCKKsLjAF;

		private MovementAreaUnit qOfbvhcPWNOVrhBQcffvQLfeavxVA;

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

		private void oUcDCOykFxgmGXIiPvHzeEjjcXMJ(Vector2 P_0)
		{
		}

		private ScreenRect PMfdFzrdIbizpnIEpzpPiWwbhRcM()
		{
			return default(ScreenRect);
		}

		private void uOIJsBEPLteGSAEXEbdcwvrsMEPB()
		{
		}

		private static float xaSbPibgaSXFnjIMsQYeThivyExAA(Axis P_0, float P_1, float P_2)
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
