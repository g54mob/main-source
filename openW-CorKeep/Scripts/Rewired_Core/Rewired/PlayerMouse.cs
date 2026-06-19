using System;
using System.Collections.Generic;
using Rewired.UI;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public sealed class PlayerMouse : PlayerController, IPlayerMouse, IPlayerController, IMouseInputSource
	{
		public new sealed class Definition : PlayerController.Definition
		{
			public bool defaultToCenter = true;

			public bool clampToMovementArea = true;

			public ScreenRect movementArea = JEvNVcODiZlyZexrOlXuFBxwvXdJ;

			public MovementAreaUnit movementAreaUnit;

			public float pointerSpeed = 1f;

			public bool useHardwarePointerPosition = true;

			internal Definition()
			{
			}
		}

		public new static class Factory
		{
			public static PlayerMouse Create()
			{
				return GmGeWrbOiKzEeMOkminuGWaexdgjA(3, 3);
			}

			private static PlayerMouse GmGeWrbOiKzEeMOkminuGWaexdgjA(int P_0, int P_1)
			{
				if (P_0 < 0)
				{
					P_0 = 0;
				}
				if (P_1 < 0)
				{
					P_1 = 0;
				}
				List<Element.Definition> list = new List<Element.Definition>(P_0 + P_1);
				if (P_1 >= 1)
				{
					list.Add(new MouseAxis2D.Definition
					{
						name = "Movement",
						xAxis = new MouseAxis.Definition
						{
							name = "Horizontal"
						},
						yAxis = new MouseAxis.Definition
						{
							name = "Vertical"
						}
					});
				}
				if (P_1 >= 3)
				{
					list.Add(new MouseWheel.Definition
					{
						name = "Wheel",
						xAxis = new MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal"
						},
						yAxis = new MouseWheelAxis.Definition
						{
							name = "Wheel Vertical"
						}
					});
				}
				for (int i = 4; i < P_1; i++)
				{
					list.Add(new Axis.Definition
					{
						coordinateMode = AxisCoordinateMode.Relative
					});
				}
				if (P_0 >= 1)
				{
					list.Add(new Button.Definition
					{
						name = "Left Button"
					});
				}
				if (P_0 >= 2)
				{
					list.Add(new Button.Definition
					{
						name = "Right Button"
					});
				}
				if (P_0 >= 3)
				{
					list.Add(new Button.Definition
					{
						name = "Middle Button"
					});
				}
				for (int j = 3; j < P_0; j++)
				{
					list.Add(new Button.Definition());
				}
				return new PlayerMouse(new Definition
				{
					elements = list
				});
			}

			public static PlayerMouse Create(Definition definition)
			{
				return new PlayerMouse(definition);
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
			public static readonly pymxBoiafyWxGSNqlzOmZwIyLXME _003C_003E9 = new pymxBoiafyWxGSNqlzOmZwIyLXME();

			public static Predicate<Axis> _003C_003E9__18_0;

			public static Predicate<Axis> _003C_003E9__18_1;

			internal bool baSIbnjICkqLtfZNCNtHWKUnumAYb(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.RqFMzefgLvcrkHcahUASVRYomsRJ;
				}
				return false;
			}

			internal bool SKbzDfZgwpCMpCtqaiIohRmeyqlkA(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.RqFMzefgLvcrkHcahUASVRYomsRJ;
				}
				return false;
			}
		}

		internal const bool eHkrHlWOAQOsKsehwovuhbnIvypO = true;

		internal const float ThdgipbdPbYzekookZZHFRngtFXt = 1f;

		internal const bool DzDvcXVJGjCaWNifArLFtGjGpvNB = true;

		internal const bool dHwkHqDESgCraktuzUgqSnXcMBix = true;

		internal const MovementAreaUnit VYpQVTgmVLbJDyvPZHFCJmgXGmPu = MovementAreaUnit.Screen;

		internal static readonly ScreenRect JEvNVcODiZlyZexrOlXuFBxwvXdJ = new ScreenRect(0f, 0f, 1f, 1f);

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

		private readonly int kRuzlwIMbqEFtKUGLSGASLoOETxOA = -1;

		private readonly int BlPVyTINvIhYPvtjchrmQWMHcMNA = -1;

		private readonly int CtSUAcNuDQNrvkpVGZuKYpCJDprD = -1;

		private readonly int aHHYWdnORBaeqpqfPvHuTzeeiubh = -1;

		private readonly int yOnTaRpbPjROwClWYnebIfqkIasU = -1;

		private readonly int AMCxcdxFmQUoMzjoJwOsyXWtKiIJ = -1;

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

		bool IPlayerMouse.defaultToCenter
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return false;
				}
				return yyMEqocKrUXEwJWrZbvtJSblwTLHA;
			}
			set
			{
				yyMEqocKrUXEwJWrZbvtJSblwTLHA = value;
			}
		}

		public bool clampToMovementArea
		{
			get
			{
				return wMdpVKEJUBmUhMLEvwIcalmTmgcy;
			}
			set
			{
				wMdpVKEJUBmUhMLEvwIcalmTmgcy = value;
			}
		}

		ScreenRect IPlayerMouse.movementArea
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return default(ScreenRect);
				}
				return JQnuJLfTzrprPtFbJHQEvQrheYMp;
			}
			set
			{
				JQnuJLfTzrprPtFbJHQEvQrheYMp = value;
			}
		}

		MovementAreaUnit IPlayerMouse.movementAreaUnit
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return MovementAreaUnit.Screen;
				}
				return ejHFMIOwERjLMaYYmxjDxBXBAjLD;
			}
			set
			{
				ejHFMIOwERjLMaYYmxjDxBXBAjLD = value;
			}
		}

		Vector2 IPlayerMouse.screenPosition
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return siTbGtLeTGbDuFZtopnZslnXJnCt;
			}
			set
			{
				syIznxbdGblUlghSZwlFKhNKsJsr(value);
			}
		}

		Vector2 IPlayerMouse.screenPositionPrev
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return OrjSqJZMjDdwCNclnWiGRXUtqbUD;
			}
		}

		Vector2 IPlayerMouse.screenPositionDelta
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return MmXtdncuwAjCGhmNIbraqCubrxXD;
			}
		}

		MouseAxis IPlayerMouse.xAxis
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return null;
				}
				if (BlPVyTINvIhYPvtjchrmQWMHcMNA < 0)
				{
					return null;
				}
				return (MouseAxis)base.Rewired_002EIPlayerController_002Eaxes[BlPVyTINvIhYPvtjchrmQWMHcMNA];
			}
		}

		MouseAxis IPlayerMouse.yAxis
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return null;
				}
				if (CtSUAcNuDQNrvkpVGZuKYpCJDprD < 0)
				{
					return null;
				}
				return (MouseAxis)base.Rewired_002EIPlayerController_002Eaxes[CtSUAcNuDQNrvkpVGZuKYpCJDprD];
			}
		}

		MouseWheel IPlayerMouse.wheel
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return null;
				}
				if (kRuzlwIMbqEFtKUGLSGASLoOETxOA < 0)
				{
					return null;
				}
				return (MouseWheel)base.Rewired_002EIPlayerController_002Eelements[kRuzlwIMbqEFtKUGLSGASLoOETxOA];
			}
		}

		Button IPlayerMouse.leftButton
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return null;
				}
				if (aHHYWdnORBaeqpqfPvHuTzeeiubh < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[aHHYWdnORBaeqpqfPvHuTzeeiubh];
			}
		}

		Button IPlayerMouse.rightButton
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return null;
				}
				if (yOnTaRpbPjROwClWYnebIfqkIasU < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[yOnTaRpbPjROwClWYnebIfqkIasU];
			}
		}

		Button IPlayerMouse.middleButton
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return null;
				}
				if (AMCxcdxFmQUoMzjoJwOsyXWtKiIJ < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[AMCxcdxFmQUoMzjoJwOsyXWtKiIJ];
			}
		}

		float IPlayerMouse.pointerSpeed
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return 0f;
				}
				return wEKiejDvMbaykTUFXVEfixabiBfn;
			}
			set
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return;
				}
				if (value < 0f)
				{
					value = 0f;
				}
				wEKiejDvMbaykTUFXVEfixabiBfn = value;
			}
		}

		bool IPlayerMouse.useHardwarePointerPosition
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return false;
				}
				return MdadAAexidNpKKzbKududVqaniRqA;
			}
			set
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return;
				}
				MdadAAexidNpKKzbKududVqaniRqA = value;
				if (!value)
				{
					usgWrFBAbrpIrjGGWsxPQqVTPneY();
				}
			}
		}

		bool IMouseInputSource.enabled => base.Rewired_002EIPlayerController_002Eenabled;

		Vector2 IMouseInputSource.screenPosition => siTbGtLeTGbDuFZtopnZslnXJnCt;

		Vector2 IMouseInputSource.screenPositionDelta => MmXtdncuwAjCGhmNIbraqCubrxXD;

		Vector2 IMouseInputSource.wheelDelta
		{
			get
			{
				if (((IPlayerMouse)this).wheel == null)
				{
					return Vector2.zero;
				}
				return ((IPlayerMouse)this).wheel.value;
			}
		}

		bool IMouseInputSource.locked => false;

		event Action<Vector2> IPlayerMouse.ScreenPositionChangedEvent
		{
			add
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
				}
				else
				{
					StFgIDGaTqnMELypNdUoeGBBgqLoA = (Action<Vector2>)Delegate.Combine(StFgIDGaTqnMELypNdUoeGBBgqLoA, value);
				}
			}
			remove
			{
				StFgIDGaTqnMELypNdUoeGBBgqLoA = (Action<Vector2>)Delegate.Remove(StFgIDGaTqnMELypNdUoeGBBgqLoA, value);
			}
		}

		private PlayerMouse(Definition P_0)
			: base(P_0)
		{
			yyMEqocKrUXEwJWrZbvtJSblwTLHA = P_0.defaultToCenter;
			wMdpVKEJUBmUhMLEvwIcalmTmgcy = P_0.clampToMovementArea;
			JQnuJLfTzrprPtFbJHQEvQrheYMp = P_0.movementArea;
			ejHFMIOwERjLMaYYmxjDxBXBAjLD = P_0.movementAreaUnit;
			wEKiejDvMbaykTUFXVEfixabiBfn = P_0.pointerSpeed;
			MdadAAexidNpKKzbKududVqaniRqA = P_0.useHardwarePointerPosition;
			int num = base.Rewired_002EIPlayerController_002EelementCount;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				if (num2 < 2 && (object)base.Rewired_002EIPlayerController_002Eelements[i].GetType() == typeof(MouseAxis))
				{
					if (num2 == 0)
					{
						BlPVyTINvIhYPvtjchrmQWMHcMNA = base.Rewired_002EIPlayerController_002Eaxes.IndexOf((MouseAxis)base.Rewired_002EIPlayerController_002Eelements[i]);
					}
					else
					{
						CtSUAcNuDQNrvkpVGZuKYpCJDprD = base.Rewired_002EIPlayerController_002Eaxes.IndexOf((MouseAxis)base.Rewired_002EIPlayerController_002Eelements[i]);
					}
					num2++;
				}
				else if (kRuzlwIMbqEFtKUGLSGASLoOETxOA < 0 && base.Rewired_002EIPlayerController_002Eelements[i] is MouseWheel)
				{
					kRuzlwIMbqEFtKUGLSGASLoOETxOA = i;
				}
				else if (num3 < 3 && (object)base.Rewired_002EIPlayerController_002Eelements[i].GetType() == typeof(Button))
				{
					switch (num3)
					{
					case 0:
						aHHYWdnORBaeqpqfPvHuTzeeiubh = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					case 1:
						yOnTaRpbPjROwClWYnebIfqkIasU = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					case 2:
						AMCxcdxFmQUoMzjoJwOsyXWtKiIJ = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					}
					num3++;
				}
			}
			if (kRuzlwIMbqEFtKUGLSGASLoOETxOA < 0)
			{
				int num4 = PlayerController.vtkwMwYTZycPtaVGqtFzwJswUMYr(base.Rewired_002EIPlayerController_002Eaxes, pymxBoiafyWxGSNqlzOmZwIyLXME._003C_003E9.baSIbnjICkqLtfZNCNtHWKUnumAYb, 1);
				int num5 = PlayerController.vtkwMwYTZycPtaVGqtFzwJswUMYr(base.Rewired_002EIPlayerController_002Eaxes, pymxBoiafyWxGSNqlzOmZwIyLXME._003C_003E9.SKbzDfZgwpCMpCtqaiIohRmeyqlkA, 2);
				if (num4 >= 0 || num5 >= 0)
				{
					MouseWheel mouseWheel = new MouseWheel(this, new MouseWheel.Definition
					{
						name = "Wheel"
					});
					hUoiCXvSYHMKMzjAuBSHbvmFxWMz(mouseWheel);
					kRuzlwIMbqEFtKUGLSGASLoOETxOA = base.Rewired_002EIPlayerController_002Eelements.Count - 1;
					if (num4 < 0 || num5 < 0)
					{
						Element element = new MouseWheelAxis(this, new MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal",
							coordinateMode = AxisCoordinateMode.Relative
						});
						hUoiCXvSYHMKMzjAuBSHbvmFxWMz(element);
						mouseWheel.dzirdOZVpgwhAywrJHHzVzmYfYZH(element);
						mouseWheel.dzirdOZVpgwhAywrJHHzVzmYfYZH((num4 < 0) ? base.Rewired_002EIPlayerController_002Eaxes[num5] : base.Rewired_002EIPlayerController_002Eaxes[num4]);
					}
					else
					{
						mouseWheel.dzirdOZVpgwhAywrJHHzVzmYfYZH(base.Rewired_002EIPlayerController_002Eaxes[num4]);
						mouseWheel.dzirdOZVpgwhAywrJHHzVzmYfYZH(base.Rewired_002EIPlayerController_002Eaxes[num5]);
					}
				}
			}
			if (yyMEqocKrUXEwJWrZbvtJSblwTLHA)
			{
				ScreenRect screenRect = XpLQvKmegdVNKSOKrrlnUZKSKkYo();
				siTbGtLeTGbDuFZtopnZslnXJnCt = new Vector2(screenRect.center.x, screenRect.center.y);
			}
			else
			{
				siTbGtLeTGbDuFZtopnZslnXJnCt = Vector2.zero;
			}
		}

		protected override bool Update(UpdateLoopType updateLoop)
		{
			if (!base.Update(updateLoop))
			{
				return false;
			}
			if (updateLoop != UpdateLoopType.Update)
			{
				return false;
			}
			if (BlPVyTINvIhYPvtjchrmQWMHcMNA >= 0)
			{
				siTbGtLeTGbDuFZtopnZslnXJnCt.x = fuobaVdWQEvjOrQgoIuAVGMQfCBf(base.Rewired_002EIPlayerController_002Eaxes[BlPVyTINvIhYPvtjchrmQWMHcMNA], siTbGtLeTGbDuFZtopnZslnXJnCt.x, wEKiejDvMbaykTUFXVEfixabiBfn);
			}
			if (CtSUAcNuDQNrvkpVGZuKYpCJDprD >= 0)
			{
				siTbGtLeTGbDuFZtopnZslnXJnCt.y = fuobaVdWQEvjOrQgoIuAVGMQfCBf(base.Rewired_002EIPlayerController_002Eaxes[CtSUAcNuDQNrvkpVGZuKYpCJDprD], siTbGtLeTGbDuFZtopnZslnXJnCt.y, wEKiejDvMbaykTUFXVEfixabiBfn);
			}
			Player player;
			if (MdadAAexidNpKKzbKududVqaniRqA && (player = base.FJqAmuJWVSTbDOtWMyWBapBlIonGA) != null)
			{
				if (!player.controllers.hasMouse)
				{
					usgWrFBAbrpIrjGGWsxPQqVTPneY();
				}
				else
				{
					UYGzDpRIUjDNWznmTGqgJDELjScxA = ReInput.controllers.Mouse.screenPosition;
					if (UYGzDpRIUjDNWznmTGqgJDELjScxA.x != HHtajBIFxyJvUExNcCKGJAtsDBTib.x || UYGzDpRIUjDNWznmTGqgJDELjScxA.y != HHtajBIFxyJvUExNcCKGJAtsDBTib.y)
					{
						siTbGtLeTGbDuFZtopnZslnXJnCt.x = UYGzDpRIUjDNWznmTGqgJDELjScxA.x;
						siTbGtLeTGbDuFZtopnZslnXJnCt.y = UYGzDpRIUjDNWznmTGqgJDELjScxA.y;
					}
					HHtajBIFxyJvUExNcCKGJAtsDBTib.x = UYGzDpRIUjDNWznmTGqgJDELjScxA.x;
					HHtajBIFxyJvUExNcCKGJAtsDBTib.y = UYGzDpRIUjDNWznmTGqgJDELjScxA.y;
				}
			}
			syIznxbdGblUlghSZwlFKhNKsJsr(siTbGtLeTGbDuFZtopnZslnXJnCt);
			MmXtdncuwAjCGhmNIbraqCubrxXD.x = siTbGtLeTGbDuFZtopnZslnXJnCt.x - OrjSqJZMjDdwCNclnWiGRXUtqbUD.x;
			MmXtdncuwAjCGhmNIbraqCubrxXD.y = siTbGtLeTGbDuFZtopnZslnXJnCt.y - OrjSqJZMjDdwCNclnWiGRXUtqbUD.y;
			jQzJiCjlJVyoShIKigiGYNpreAtU = siTbGtLeTGbDuFZtopnZslnXJnCt.x != OrjSqJZMjDdwCNclnWiGRXUtqbUD.x || siTbGtLeTGbDuFZtopnZslnXJnCt.y != OrjSqJZMjDdwCNclnWiGRXUtqbUD.y;
			OrjSqJZMjDdwCNclnWiGRXUtqbUD.x = siTbGtLeTGbDuFZtopnZslnXJnCt.x;
			OrjSqJZMjDdwCNclnWiGRXUtqbUD.y = siTbGtLeTGbDuFZtopnZslnXJnCt.y;
			return true;
		}

		protected override void UpdateFinished()
		{
			base.UpdateFinished();
			if (jQzJiCjlJVyoShIKigiGYNpreAtU && StFgIDGaTqnMELypNdUoeGBBgqLoA != null)
			{
				try
				{
					StFgIDGaTqnMELypNdUoeGBBgqLoA(siTbGtLeTGbDuFZtopnZslnXJnCt);
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n" + ex);
				}
				jQzJiCjlJVyoShIKigiGYNpreAtU = false;
			}
		}

		protected override void ClearVars()
		{
			base.ClearVars();
			OrjSqJZMjDdwCNclnWiGRXUtqbUD = siTbGtLeTGbDuFZtopnZslnXJnCt;
			MmXtdncuwAjCGhmNIbraqCubrxXD = Vector2.zero;
			usgWrFBAbrpIrjGGWsxPQqVTPneY();
			jQzJiCjlJVyoShIKigiGYNpreAtU = false;
		}

		private void syIznxbdGblUlghSZwlFKhNKsJsr(Vector2 P_0)
		{
			if (!wMdpVKEJUBmUhMLEvwIcalmTmgcy)
			{
				siTbGtLeTGbDuFZtopnZslnXJnCt = P_0;
				return;
			}
			if (ejHFMIOwERjLMaYYmxjDxBXBAjLD == MovementAreaUnit.Screen)
			{
				float num = Screen.width;
				float num2 = Screen.height;
				siTbGtLeTGbDuFZtopnZslnXJnCt.x = Mathf.Clamp(P_0.x, JQnuJLfTzrprPtFbJHQEvQrheYMp.xMin * num, JQnuJLfTzrprPtFbJHQEvQrheYMp.xMax * num);
				siTbGtLeTGbDuFZtopnZslnXJnCt.y = Mathf.Clamp(P_0.y, JQnuJLfTzrprPtFbJHQEvQrheYMp.yMin * num2, JQnuJLfTzrprPtFbJHQEvQrheYMp.yMax * num2);
				return;
			}
			if (ejHFMIOwERjLMaYYmxjDxBXBAjLD == MovementAreaUnit.Pixel)
			{
				siTbGtLeTGbDuFZtopnZslnXJnCt.x = Mathf.Clamp(P_0.x, JQnuJLfTzrprPtFbJHQEvQrheYMp.xMin, JQnuJLfTzrprPtFbJHQEvQrheYMp.xMax);
				siTbGtLeTGbDuFZtopnZslnXJnCt.y = Mathf.Clamp(P_0.y, JQnuJLfTzrprPtFbJHQEvQrheYMp.yMin, JQnuJLfTzrprPtFbJHQEvQrheYMp.yMax);
				return;
			}
			throw new NotImplementedException();
		}

		private ScreenRect XpLQvKmegdVNKSOKrrlnUZKSKkYo()
		{
			if (ejHFMIOwERjLMaYYmxjDxBXBAjLD == MovementAreaUnit.Screen)
			{
				return new ScreenRect(JQnuJLfTzrprPtFbJHQEvQrheYMp.xMin * (float)Screen.width, JQnuJLfTzrprPtFbJHQEvQrheYMp.yMin * (float)Screen.height, JQnuJLfTzrprPtFbJHQEvQrheYMp.width * (float)Screen.width, JQnuJLfTzrprPtFbJHQEvQrheYMp.height * (float)Screen.height);
			}
			if (ejHFMIOwERjLMaYYmxjDxBXBAjLD == MovementAreaUnit.Pixel)
			{
				return JQnuJLfTzrprPtFbJHQEvQrheYMp;
			}
			throw new NotImplementedException();
		}

		private void usgWrFBAbrpIrjGGWsxPQqVTPneY()
		{
			UYGzDpRIUjDNWznmTGqgJDELjScxA = Vector2.zero;
			HHtajBIFxyJvUExNcCKGJAtsDBTib = Vector2.zero;
		}

		private static float fuobaVdWQEvjOrQgoIuAVGMQfCBf(Axis P_0, float P_1, float P_2)
		{
			if (P_0 == null)
			{
				return P_1;
			}
			return P_0.coordinateMode switch
			{
				AxisCoordinateMode.Absolute => P_0.value, 
				AxisCoordinateMode.Relative => P_1 + P_0.value * P_2, 
				_ => throw new NotImplementedException(), 
			};
		}

		bool IMouseInputSource.GetButtonDown(int button)
		{
			return GetButtonDown(button);
		}

		bool IMouseInputSource.GetButtonUp(int button)
		{
			return GetButtonUp(button);
		}

		bool IMouseInputSource.GetButton(int button)
		{
			return GetButton(button);
		}
	}
}
