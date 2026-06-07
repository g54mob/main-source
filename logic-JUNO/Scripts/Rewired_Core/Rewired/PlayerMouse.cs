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

			public ScreenRect movementArea = NezXlRccEwpzPjOXAsmmFNsEISqI;

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
				return YsWaCMJtQzQToJpWucSoSafWdUhW(3, 3);
			}

			private static PlayerMouse YsWaCMJtQzQToJpWucSoSafWdUhW(int P_0, int P_1)
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
		private sealed class vjuDvTKfOZjFSIFbtZuquFdCqcVmA
		{
			public static readonly vjuDvTKfOZjFSIFbtZuquFdCqcVmA _003C_003E9 = new vjuDvTKfOZjFSIFbtZuquFdCqcVmA();

			public static Predicate<Axis> _003C_003E9__18_0;

			public static Predicate<Axis> _003C_003E9__18_1;

			internal bool dhEtpEugaFEYfOJzLdwXCsRObHLP(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.JRFXSVPvdMttiCEMrjFGfRBUMVCYA;
				}
				return false;
			}

			internal bool AEjDPInMGKXUfsjQmTTiZtbMJpmj(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.JRFXSVPvdMttiCEMrjFGfRBUMVCYA;
				}
				return false;
			}
		}

		internal const bool qboLjGcfqfviQjcPgDimbOcuGJuP = true;

		internal const float LZtuqIBidGkogpMUgdITKRiAmiEbb = 1f;

		internal const bool ZBhkzHzrtzRJaSvOrbmXfWHclKcR = true;

		internal const bool haoTRWdoNPskQdMRdtihYULEavQc = true;

		internal const MovementAreaUnit FfdNmoAhMgYuNtvzBYtCLxkfVmId = MovementAreaUnit.Screen;

		internal static readonly ScreenRect NezXlRccEwpzPjOXAsmmFNsEISqI = new ScreenRect(0f, 0f, 1f, 1f);

		private const int IFxLEHyVTPkCOZwjwJHpbbNZYNmx = 3;

		private const int pzjqxrKdxzUJUQanDpFfFcRmdRKg = 3;

		internal const string TmdyurYOsrtbrNnnQGKDfAtNktAC = "Movement";

		internal const string evABwAELNmdakLlYckkFiYIOcRtv = "Horizontal";

		internal const string GHvGvBGmkGjNZQnEsfAsRXmyZpPL = "Vertical";

		internal const string owkipQdhOwbsADjgFlfWwuXcBLSYA = "Wheel";

		internal const string HUcUehKaPGnkUTiFHHXLtpMfyGeU = "Wheel Horizontal";

		internal const string LzASLlINMKVLjmEGFTIGFJHpZZFI = "Wheel Vertical";

		internal const string DhyISGhJWLjmEiPxqVwyumncTPwl = "Left Button";

		internal const string kJPVuHKKxUQyQHkzGtoJsYfNDsyK = "Right Button";

		internal const string btKuEseqdoaeWDpzxihTVBwPyxzLA = "Middle Button";

		private readonly int eQibBPwNLZIOdJiaLLXQJvWuofyG = -1;

		private readonly int FTvjFXyihKseGqKTnPavMOFwOXDP = -1;

		private readonly int OEWeIThEKlvWnvbFUpUQAmmlqqgT = -1;

		private readonly int sHXUAMVbhkhbuHqDLwwkNGhIbBkfA = -1;

		private readonly int wHrNHwVmxIXEoZzcWuWnUcbChLtr = -1;

		private readonly int IzANnEZAYjeDIamOPlpkiRNHfpFaA = -1;

		private bool lbFajpVjwOxGtaqskpKAKykRdeOb;

		private Vector2 SLEuhYxHqIMKCsvYBdnaFcBtEppN;

		private Vector2 BUfBlwbeNLwsMVDhwaVKeKcGrmGUA;

		private Vector2 ybDidMcpptrIcPUTqcuDOyutpYPRA;

		private Vector2 WRlsSknnoitcEYlOzpPUZKQZUBXQ;

		private Vector2 KmHYfCKWUtSwAemdCkimijXVLSEO;

		private float kfSifGhqUQzeRMdaLHttydEBsgqC;

		private bool GeybAlLpGQhwWqmLKXyoJStYHxAK;

		private Action<Vector2> GSVQoyEflJaZUhtLFNNmKkExfDUbA;

		private bool iDSgLRqcPfEJmFrTBBevOocJokCy;

		private ScreenRect XJzFbgXXRUoOTksXLBeIxuwVjvDi;

		private bool aTzFfzwHkiZqbXKqpBrwibhvVrfj;

		private MovementAreaUnit ocRtDzqPYeynSrvmimnVxjOrxLKm;

		bool IPlayerMouse.defaultToCenter
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return false;
				}
				return iDSgLRqcPfEJmFrTBBevOocJokCy;
			}
			set
			{
				iDSgLRqcPfEJmFrTBBevOocJokCy = value;
			}
		}

		public bool clampToMovementArea
		{
			get
			{
				return aTzFfzwHkiZqbXKqpBrwibhvVrfj;
			}
			set
			{
				aTzFfzwHkiZqbXKqpBrwibhvVrfj = value;
			}
		}

		ScreenRect IPlayerMouse.movementArea
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return default(ScreenRect);
				}
				return XJzFbgXXRUoOTksXLBeIxuwVjvDi;
			}
			set
			{
				XJzFbgXXRUoOTksXLBeIxuwVjvDi = value;
			}
		}

		MovementAreaUnit IPlayerMouse.movementAreaUnit
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return MovementAreaUnit.Screen;
				}
				return ocRtDzqPYeynSrvmimnVxjOrxLKm;
			}
			set
			{
				ocRtDzqPYeynSrvmimnVxjOrxLKm = value;
			}
		}

		Vector2 IPlayerMouse.screenPosition
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return ybDidMcpptrIcPUTqcuDOyutpYPRA;
			}
			set
			{
				kECfFEHpgUZzvjoqNucRWgWmhsxP(value);
			}
		}

		Vector2 IPlayerMouse.screenPositionPrev
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return WRlsSknnoitcEYlOzpPUZKQZUBXQ;
			}
		}

		Vector2 IPlayerMouse.screenPositionDelta
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return KmHYfCKWUtSwAemdCkimijXVLSEO;
			}
		}

		MouseAxis IPlayerMouse.xAxis
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return null;
				}
				if (FTvjFXyihKseGqKTnPavMOFwOXDP < 0)
				{
					return null;
				}
				return (MouseAxis)base.Rewired_002EIPlayerController_002Eaxes[FTvjFXyihKseGqKTnPavMOFwOXDP];
			}
		}

		MouseAxis IPlayerMouse.yAxis
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return null;
				}
				if (OEWeIThEKlvWnvbFUpUQAmmlqqgT < 0)
				{
					return null;
				}
				return (MouseAxis)base.Rewired_002EIPlayerController_002Eaxes[OEWeIThEKlvWnvbFUpUQAmmlqqgT];
			}
		}

		MouseWheel IPlayerMouse.wheel
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return null;
				}
				if (eQibBPwNLZIOdJiaLLXQJvWuofyG < 0)
				{
					return null;
				}
				return (MouseWheel)base.Rewired_002EIPlayerController_002Eelements[eQibBPwNLZIOdJiaLLXQJvWuofyG];
			}
		}

		Button IPlayerMouse.leftButton
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return null;
				}
				if (sHXUAMVbhkhbuHqDLwwkNGhIbBkfA < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[sHXUAMVbhkhbuHqDLwwkNGhIbBkfA];
			}
		}

		Button IPlayerMouse.rightButton
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return null;
				}
				if (wHrNHwVmxIXEoZzcWuWnUcbChLtr < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[wHrNHwVmxIXEoZzcWuWnUcbChLtr];
			}
		}

		Button IPlayerMouse.middleButton
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return null;
				}
				if (IzANnEZAYjeDIamOPlpkiRNHfpFaA < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[IzANnEZAYjeDIamOPlpkiRNHfpFaA];
			}
		}

		float IPlayerMouse.pointerSpeed
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return 0f;
				}
				return kfSifGhqUQzeRMdaLHttydEBsgqC;
			}
			set
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return;
				}
				if (value < 0f)
				{
					value = 0f;
				}
				kfSifGhqUQzeRMdaLHttydEBsgqC = value;
			}
		}

		bool IPlayerMouse.useHardwarePointerPosition
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return false;
				}
				return GeybAlLpGQhwWqmLKXyoJStYHxAK;
			}
			set
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return;
				}
				GeybAlLpGQhwWqmLKXyoJStYHxAK = value;
				if (!value)
				{
					mFwbPefuRMDKlsZeMuMHSVQrUYlI();
				}
			}
		}

		bool IMouseInputSource.enabled => base.Rewired_002EIPlayerController_002Eenabled;

		Vector2 IMouseInputSource.screenPosition => ybDidMcpptrIcPUTqcuDOyutpYPRA;

		Vector2 IMouseInputSource.screenPositionDelta => KmHYfCKWUtSwAemdCkimijXVLSEO;

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
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
				}
				else
				{
					GSVQoyEflJaZUhtLFNNmKkExfDUbA = (Action<Vector2>)Delegate.Combine(GSVQoyEflJaZUhtLFNNmKkExfDUbA, value);
				}
			}
			remove
			{
				GSVQoyEflJaZUhtLFNNmKkExfDUbA = (Action<Vector2>)Delegate.Remove(GSVQoyEflJaZUhtLFNNmKkExfDUbA, value);
			}
		}

		private PlayerMouse(Definition P_0)
			: base(P_0)
		{
			iDSgLRqcPfEJmFrTBBevOocJokCy = P_0.defaultToCenter;
			aTzFfzwHkiZqbXKqpBrwibhvVrfj = P_0.clampToMovementArea;
			XJzFbgXXRUoOTksXLBeIxuwVjvDi = P_0.movementArea;
			ocRtDzqPYeynSrvmimnVxjOrxLKm = P_0.movementAreaUnit;
			kfSifGhqUQzeRMdaLHttydEBsgqC = P_0.pointerSpeed;
			GeybAlLpGQhwWqmLKXyoJStYHxAK = P_0.useHardwarePointerPosition;
			int num = base.Rewired_002EIPlayerController_002EelementCount;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				if (num2 < 2 && (object)base.Rewired_002EIPlayerController_002Eelements[i].GetType() == typeof(MouseAxis))
				{
					if (num2 == 0)
					{
						FTvjFXyihKseGqKTnPavMOFwOXDP = base.Rewired_002EIPlayerController_002Eaxes.IndexOf((MouseAxis)base.Rewired_002EIPlayerController_002Eelements[i]);
					}
					else
					{
						OEWeIThEKlvWnvbFUpUQAmmlqqgT = base.Rewired_002EIPlayerController_002Eaxes.IndexOf((MouseAxis)base.Rewired_002EIPlayerController_002Eelements[i]);
					}
					num2++;
				}
				else if (eQibBPwNLZIOdJiaLLXQJvWuofyG < 0 && base.Rewired_002EIPlayerController_002Eelements[i] is MouseWheel)
				{
					eQibBPwNLZIOdJiaLLXQJvWuofyG = i;
				}
				else if (num3 < 3 && (object)base.Rewired_002EIPlayerController_002Eelements[i].GetType() == typeof(Button))
				{
					switch (num3)
					{
					case 0:
						sHXUAMVbhkhbuHqDLwwkNGhIbBkfA = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					case 1:
						wHrNHwVmxIXEoZzcWuWnUcbChLtr = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					case 2:
						IzANnEZAYjeDIamOPlpkiRNHfpFaA = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					}
					num3++;
				}
			}
			if (eQibBPwNLZIOdJiaLLXQJvWuofyG < 0)
			{
				int num4 = PlayerController.bHwURNkVdDYhdzxesQhhqttMvZZF(base.Rewired_002EIPlayerController_002Eaxes, vjuDvTKfOZjFSIFbtZuquFdCqcVmA._003C_003E9.dhEtpEugaFEYfOJzLdwXCsRObHLP, 1);
				int num5 = PlayerController.bHwURNkVdDYhdzxesQhhqttMvZZF(base.Rewired_002EIPlayerController_002Eaxes, vjuDvTKfOZjFSIFbtZuquFdCqcVmA._003C_003E9.AEjDPInMGKXUfsjQmTTiZtbMJpmj, 2);
				if (num4 >= 0 || num5 >= 0)
				{
					MouseWheel mouseWheel = new MouseWheel(this, new MouseWheel.Definition
					{
						name = "Wheel"
					});
					hiyMgiVoJcFSJysckXNgbxortREc(mouseWheel);
					eQibBPwNLZIOdJiaLLXQJvWuofyG = base.Rewired_002EIPlayerController_002Eelements.Count - 1;
					if (num4 < 0 || num5 < 0)
					{
						Element element = new MouseWheelAxis(this, new MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal",
							coordinateMode = AxisCoordinateMode.Relative
						});
						hiyMgiVoJcFSJysckXNgbxortREc(element);
						mouseWheel.zgyYhzrsDBVfGjCVLLUbRqhoKQWR(element);
						mouseWheel.zgyYhzrsDBVfGjCVLLUbRqhoKQWR((num4 < 0) ? base.Rewired_002EIPlayerController_002Eaxes[num5] : base.Rewired_002EIPlayerController_002Eaxes[num4]);
					}
					else
					{
						mouseWheel.zgyYhzrsDBVfGjCVLLUbRqhoKQWR(base.Rewired_002EIPlayerController_002Eaxes[num4]);
						mouseWheel.zgyYhzrsDBVfGjCVLLUbRqhoKQWR(base.Rewired_002EIPlayerController_002Eaxes[num5]);
					}
				}
			}
			if (iDSgLRqcPfEJmFrTBBevOocJokCy)
			{
				ScreenRect screenRect = TOPrMvQWkICJUJcCpgHpScJcXZRI();
				ybDidMcpptrIcPUTqcuDOyutpYPRA = new Vector2(screenRect.center.x, screenRect.center.y);
			}
			else
			{
				ybDidMcpptrIcPUTqcuDOyutpYPRA = Vector2.zero;
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
			Player player;
			if (GeybAlLpGQhwWqmLKXyoJStYHxAK && (player = base.PXgboTkZzlEkFsUiSrFJitKXuHkW) != null)
			{
				if (!player.controllers.hasMouse)
				{
					mFwbPefuRMDKlsZeMuMHSVQrUYlI();
				}
				else
				{
					SLEuhYxHqIMKCsvYBdnaFcBtEppN = ReInput.controllers.Mouse.screenPosition;
					if (SLEuhYxHqIMKCsvYBdnaFcBtEppN.x != BUfBlwbeNLwsMVDhwaVKeKcGrmGUA.x || SLEuhYxHqIMKCsvYBdnaFcBtEppN.y != BUfBlwbeNLwsMVDhwaVKeKcGrmGUA.y)
					{
						ybDidMcpptrIcPUTqcuDOyutpYPRA.x = SLEuhYxHqIMKCsvYBdnaFcBtEppN.x;
						ybDidMcpptrIcPUTqcuDOyutpYPRA.y = SLEuhYxHqIMKCsvYBdnaFcBtEppN.y;
					}
					BUfBlwbeNLwsMVDhwaVKeKcGrmGUA.x = SLEuhYxHqIMKCsvYBdnaFcBtEppN.x;
					BUfBlwbeNLwsMVDhwaVKeKcGrmGUA.y = SLEuhYxHqIMKCsvYBdnaFcBtEppN.y;
				}
			}
			if (FTvjFXyihKseGqKTnPavMOFwOXDP >= 0)
			{
				ybDidMcpptrIcPUTqcuDOyutpYPRA.x = vFsezmJtitGuQmQgurLWPdXaZEAN(base.Rewired_002EIPlayerController_002Eaxes[FTvjFXyihKseGqKTnPavMOFwOXDP], ybDidMcpptrIcPUTqcuDOyutpYPRA.x, kfSifGhqUQzeRMdaLHttydEBsgqC);
			}
			if (OEWeIThEKlvWnvbFUpUQAmmlqqgT >= 0)
			{
				ybDidMcpptrIcPUTqcuDOyutpYPRA.y = vFsezmJtitGuQmQgurLWPdXaZEAN(base.Rewired_002EIPlayerController_002Eaxes[OEWeIThEKlvWnvbFUpUQAmmlqqgT], ybDidMcpptrIcPUTqcuDOyutpYPRA.y, kfSifGhqUQzeRMdaLHttydEBsgqC);
			}
			kECfFEHpgUZzvjoqNucRWgWmhsxP(ybDidMcpptrIcPUTqcuDOyutpYPRA);
			KmHYfCKWUtSwAemdCkimijXVLSEO.x = ybDidMcpptrIcPUTqcuDOyutpYPRA.x - WRlsSknnoitcEYlOzpPUZKQZUBXQ.x;
			KmHYfCKWUtSwAemdCkimijXVLSEO.y = ybDidMcpptrIcPUTqcuDOyutpYPRA.y - WRlsSknnoitcEYlOzpPUZKQZUBXQ.y;
			lbFajpVjwOxGtaqskpKAKykRdeOb = ybDidMcpptrIcPUTqcuDOyutpYPRA.x != WRlsSknnoitcEYlOzpPUZKQZUBXQ.x || ybDidMcpptrIcPUTqcuDOyutpYPRA.y != WRlsSknnoitcEYlOzpPUZKQZUBXQ.y;
			WRlsSknnoitcEYlOzpPUZKQZUBXQ.x = ybDidMcpptrIcPUTqcuDOyutpYPRA.x;
			WRlsSknnoitcEYlOzpPUZKQZUBXQ.y = ybDidMcpptrIcPUTqcuDOyutpYPRA.y;
			return true;
		}

		protected override void UpdateFinished()
		{
			base.UpdateFinished();
			if (lbFajpVjwOxGtaqskpKAKykRdeOb && GSVQoyEflJaZUhtLFNNmKkExfDUbA != null)
			{
				try
				{
					GSVQoyEflJaZUhtLFNNmKkExfDUbA(ybDidMcpptrIcPUTqcuDOyutpYPRA);
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n" + ex);
				}
				lbFajpVjwOxGtaqskpKAKykRdeOb = false;
			}
		}

		protected override void ClearVars()
		{
			base.ClearVars();
			WRlsSknnoitcEYlOzpPUZKQZUBXQ = ybDidMcpptrIcPUTqcuDOyutpYPRA;
			KmHYfCKWUtSwAemdCkimijXVLSEO = Vector2.zero;
			mFwbPefuRMDKlsZeMuMHSVQrUYlI();
			lbFajpVjwOxGtaqskpKAKykRdeOb = false;
		}

		private void kECfFEHpgUZzvjoqNucRWgWmhsxP(Vector2 P_0)
		{
			if (!aTzFfzwHkiZqbXKqpBrwibhvVrfj)
			{
				ybDidMcpptrIcPUTqcuDOyutpYPRA = P_0;
				return;
			}
			if (ocRtDzqPYeynSrvmimnVxjOrxLKm == MovementAreaUnit.Screen)
			{
				float num = Screen.width;
				float num2 = Screen.height;
				ybDidMcpptrIcPUTqcuDOyutpYPRA.x = Mathf.Clamp(P_0.x, XJzFbgXXRUoOTksXLBeIxuwVjvDi.xMin * num, XJzFbgXXRUoOTksXLBeIxuwVjvDi.xMax * num);
				ybDidMcpptrIcPUTqcuDOyutpYPRA.y = Mathf.Clamp(P_0.y, XJzFbgXXRUoOTksXLBeIxuwVjvDi.yMin * num2, XJzFbgXXRUoOTksXLBeIxuwVjvDi.yMax * num2);
				return;
			}
			if (ocRtDzqPYeynSrvmimnVxjOrxLKm == MovementAreaUnit.Pixel)
			{
				ybDidMcpptrIcPUTqcuDOyutpYPRA.x = Mathf.Clamp(P_0.x, XJzFbgXXRUoOTksXLBeIxuwVjvDi.xMin, XJzFbgXXRUoOTksXLBeIxuwVjvDi.xMax);
				ybDidMcpptrIcPUTqcuDOyutpYPRA.y = Mathf.Clamp(P_0.y, XJzFbgXXRUoOTksXLBeIxuwVjvDi.yMin, XJzFbgXXRUoOTksXLBeIxuwVjvDi.yMax);
				return;
			}
			throw new NotImplementedException();
		}

		private ScreenRect TOPrMvQWkICJUJcCpgHpScJcXZRI()
		{
			if (ocRtDzqPYeynSrvmimnVxjOrxLKm == MovementAreaUnit.Screen)
			{
				return new ScreenRect(XJzFbgXXRUoOTksXLBeIxuwVjvDi.xMin * (float)Screen.width, XJzFbgXXRUoOTksXLBeIxuwVjvDi.yMin * (float)Screen.height, XJzFbgXXRUoOTksXLBeIxuwVjvDi.width * (float)Screen.width, XJzFbgXXRUoOTksXLBeIxuwVjvDi.height * (float)Screen.height);
			}
			if (ocRtDzqPYeynSrvmimnVxjOrxLKm == MovementAreaUnit.Pixel)
			{
				return XJzFbgXXRUoOTksXLBeIxuwVjvDi;
			}
			throw new NotImplementedException();
		}

		private void mFwbPefuRMDKlsZeMuMHSVQrUYlI()
		{
			SLEuhYxHqIMKCsvYBdnaFcBtEppN = Vector2.zero;
			BUfBlwbeNLwsMVDhwaVKeKcGrmGUA = Vector2.zero;
		}

		private static float vFsezmJtitGuQmQgurLWPdXaZEAN(Axis P_0, float P_1, float P_2)
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
