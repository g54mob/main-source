using System;
using Rewired.ComponentControls.Data;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class CustomControllerControl : ComponentControl
	{
		internal CustomController controller
		{
			get
			{
				return uTBWYexvbgNovlylPUvYgROmXuM() as CustomController;
			}
		}

		internal override bool hasController
		{
			get
			{
				return uTBWYexvbgNovlylPUvYgROmXuM() as CustomController != null;
			}
		}

		[CustomObfuscation(rename = false)]
		internal CustomControllerControl()
		{
		}

		internal override void OnSubscribeEvents()
		{
			base.OnSubscribeEvents();
			if (!hasController)
			{
				return;
			}
			while (true)
			{
				OnUnsubscribeEvents();
				int num = -719567960;
				while (true)
				{
					switch (num ^ -719567959)
					{
					case 0:
						goto IL_000f;
					case 2:
						break;
					default:
						controller.InputSourceUpdateEvent += yEBUioqLlAtamFyvbaGVtgDsSwS;
						return;
					}
					break;
					IL_000f:
					num = -719567957;
				}
			}
		}

		internal override void OnUnsubscribeEvents()
		{
			base.OnUnsubscribeEvents();
			while (true)
			{
				int num = 668794964;
				while (true)
				{
					switch (num ^ 0x27DD0056)
					{
					case 0:
						break;
					case 2:
					{
						int num2;
						if (!hasController)
						{
							num = 668794965;
							num2 = num;
						}
						else
						{
							num = 668794967;
							num2 = num;
						}
						continue;
					}
					case 3:
						return;
					default:
						controller.InputSourceUpdateEvent -= yEBUioqLlAtamFyvbaGVtgDsSwS;
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal override IComponentController FindController()
		{
			return UnityTools.GetComponentInSelfOrParents<CustomController>(base.transform);
		}

		[CustomObfuscation(rename = false)]
		internal override Type GetRequiredControllerType()
		{
			return typeof(CustomController);
		}

		internal void KyhNArefdFIxsvhHWTOXrRXnSZY(CustomControllerElementTargetSet P_0, float P_1, float P_2)
		{
			if (!hasController)
			{
				return;
			}
			CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean = default(CustomControllerElementTargetSetForBoolean);
			CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat = default(CustomControllerElementTargetSetForFloat);
			while (true)
			{
				int num;
				int num2;
				if (P_0 != null)
				{
					num = 194813789;
					num2 = num;
				}
				else
				{
					num = 194813787;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0xB9C9F5E)
					{
					case 8:
						num = 194813786;
						continue;
					default:
						return;
					case 7:
					{
						customControllerElementTargetSetForBoolean = P_0 as CustomControllerElementTargetSetForBoolean;
						int num4;
						if (customControllerElementTargetSetForBoolean == null)
						{
							num = 194813791;
							num4 = num;
						}
						else
						{
							num = 194813784;
							num4 = num;
						}
						continue;
					}
					case 9:
						if (!customControllerElementTargetSetForFloat.splitValue)
						{
							KyhNArefdFIxsvhHWTOXrRXnSZY(customControllerElementTargetSetForFloat.target, P_1, P_2);
							return;
						}
						goto case 0;
					case 0:
						KyhNArefdFIxsvhHWTOXrRXnSZY(customControllerElementTargetSetForFloat.positiveTarget, P_1, P_2);
						KyhNArefdFIxsvhHWTOXrRXnSZY(customControllerElementTargetSetForFloat.negativeTarget, P_1, P_2);
						return;
					case 6:
						KyhNArefdFIxsvhHWTOXrRXnSZY(customControllerElementTargetSetForBoolean.target, P_1, P_2);
						num = 194813791;
						continue;
					case 5:
						return;
					case 3:
						customControllerElementTargetSetForFloat = P_0 as CustomControllerElementTargetSetForFloat;
						num = 194813788;
						continue;
					case 2:
					{
						int num3;
						if (customControllerElementTargetSetForFloat != null)
						{
							num = 194813783;
							num3 = num;
						}
						else
						{
							num = 194813785;
							num3 = num;
						}
						continue;
					}
					case 4:
						break;
					case 1:
						return;
					}
					break;
				}
			}
		}

		internal void KyhNArefdFIxsvhHWTOXrRXnSZY(CustomControllerElementTargetSet P_0, bool P_1)
		{
			if (!hasController)
			{
				return;
			}
			CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat = default(CustomControllerElementTargetSetForFloat);
			CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean = default(CustomControllerElementTargetSetForBoolean);
			while (true)
			{
				int num;
				int num2;
				if (P_0 == null)
				{
					num = 2145024263;
					num2 = num;
				}
				else
				{
					num = 2145024268;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x7FDA790E)
					{
					case 0:
						num = 2145024264;
						continue;
					default:
						return;
					case 5:
						KyhNArefdFIxsvhHWTOXrRXnSZY(customControllerElementTargetSetForFloat.positiveTarget, P_1);
						KyhNArefdFIxsvhHWTOXrRXnSZY(customControllerElementTargetSetForFloat.negativeTarget, P_1);
						num = 2145024265;
						continue;
					case 9:
						return;
					case 2:
					{
						customControllerElementTargetSetForBoolean = P_0 as CustomControllerElementTargetSetForBoolean;
						int num3;
						if (customControllerElementTargetSetForBoolean != null)
						{
							num = 2145024266;
							num3 = num;
						}
						else
						{
							num = 2145024262;
							num3 = num;
						}
						continue;
					}
					case 3:
						return;
					case 4:
						KyhNArefdFIxsvhHWTOXrRXnSZY(customControllerElementTargetSetForBoolean.target, P_1);
						return;
					case 8:
					{
						customControllerElementTargetSetForFloat = P_0 as CustomControllerElementTargetSetForFloat;
						int num4;
						if (customControllerElementTargetSetForFloat != null)
						{
							num = 2145024271;
							num4 = num;
						}
						else
						{
							num = 2145024265;
							num4 = num;
						}
						continue;
					}
					case 6:
						break;
					case 1:
						if (!customControllerElementTargetSetForFloat.splitValue)
						{
							KyhNArefdFIxsvhHWTOXrRXnSZY(customControllerElementTargetSetForFloat.target, P_1);
							num = 2145024269;
							continue;
						}
						goto case 5;
					case 7:
						return;
					}
					break;
				}
			}
		}

		internal abstract void OnCustomControllerUpdate();

		private void KyhNArefdFIxsvhHWTOXrRXnSZY(CustomControllerElementTarget P_0, float P_1, float P_2)
		{
			if (P_0 == null)
			{
				goto IL_0006;
			}
			goto IL_0156;
			IL_0006:
			int num = 1570657899;
			goto IL_000b;
			IL_000b:
			CustomControllerElementTarget.ValueRange valueRange = default(CustomControllerElementTarget.ValueRange);
			while (true)
			{
				switch (num ^ 0x5D9E5662)
				{
				case 11:
					break;
				case 15:
					goto IL_0063;
				case 8:
					switch (valueRange)
					{
					case CustomControllerElementTarget.ValueRange.Negative:
						goto IL_017c;
					case CustomControllerElementTarget.ValueRange.Positive:
						goto IL_01ac;
					case CustomControllerElementTarget.ValueRange.Full:
						goto IL_01cf;
					}
					num = 1570657906;
					continue;
				case 4:
					goto IL_009a;
				case 9:
					return;
				case 2:
					goto IL_00c1;
				case 1:
					goto IL_00e8;
				case 7:
					goto IL_0101;
				case 13:
					goto IL_011f;
				case 5:
					goto IL_0138;
				case 6:
					goto IL_0156;
				case 14:
					goto IL_017c;
				case 10:
					goto IL_0198;
				case 12:
					goto IL_01ac;
				case 17:
					num = 1570657906;
					continue;
				case 16:
					goto IL_01cf;
				case 3:
					P_1 = 0f;
					num = 1570657906;
					continue;
				default:
					{
						throw new NotImplementedException();
					}
					IL_01ac:
					if (P_1 < 0f)
					{
						P_1 = 0f;
						num = 1570657907;
						continue;
					}
					goto IL_01cf;
					IL_01cf:
					controller.SetButtonValue(P_0.element, MathTools.Abs(P_1) >= MathTools.Abs(P_2));
					return;
				}
				break;
				IL_017c:
				int num2;
				if (P_1 <= 0f)
				{
					num = 1570657906;
					num2 = num;
				}
				else
				{
					num = 1570657889;
					num2 = num;
				}
			}
			goto IL_0006;
			IL_0198:
			CustomControllerElementTarget.ValueRange valueRange2 = P_0.valueRange;
			valueRange = valueRange2;
			num = 1570657898;
			goto IL_000b;
			IL_0156:
			switch (P_0.element.elementType)
			{
			case CustomControllerElementSelector.ElementType.Axis:
				break;
			default:
				goto IL_0172;
			case CustomControllerElementSelector.ElementType.Button:
				goto IL_0198;
			}
			goto IL_00c1;
			IL_00c1:
			switch (P_0.valueRange)
			{
			case CustomControllerElementTarget.ValueRange.Positive:
				goto IL_00e8;
			case CustomControllerElementTarget.ValueRange.Negative:
				goto IL_011f;
			case CustomControllerElementTarget.ValueRange.Full:
				goto IL_0138;
			}
			num = 1570657901;
			goto IL_000b;
			IL_0138:
			if (P_0.invert)
			{
				P_1 *= -1f;
				num = 1570657901;
				goto IL_000b;
			}
			goto IL_0063;
			IL_0063:
			controller.SetAxisValue(P_0.element, P_1);
			return;
			IL_00e8:
			if (P_1 < 0f)
			{
				P_1 = 0f;
				num = 1570657894;
				goto IL_000b;
			}
			goto IL_009a;
			IL_009a:
			if (P_0.valueContribution == Pole.Negative)
			{
				P_1 *= -1f;
				num = 1570657901;
				goto IL_000b;
			}
			goto IL_0063;
			IL_011f:
			if (P_1 > 0f)
			{
				P_1 = 0f;
				num = 1570657893;
				goto IL_000b;
			}
			goto IL_0101;
			IL_0101:
			if (P_0.valueContribution == Pole.Positive)
			{
				P_1 *= -1f;
				num = 1570657901;
				goto IL_000b;
			}
			goto IL_0063;
			IL_0172:
			num = 1570657890;
			goto IL_000b;
		}

		private void KyhNArefdFIxsvhHWTOXrRXnSZY(CustomControllerElementTarget P_0, bool P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			float num2 = default(float);
			while (true)
			{
				IL_00d5:
				int num;
				switch (P_0.element.elementType)
				{
				case CustomControllerElementSelector.ElementType.Button:
					break;
				case CustomControllerElementSelector.ElementType.Axis:
					num2 = (P_1 ? 1f : 0f);
					num = -1379914855;
					goto IL_000c;
				default:
					{
						num = -1379914849;
						goto IL_000c;
					}
					IL_000c:
					while (true)
					{
						switch (num ^ -1379914854)
						{
						case 8:
							num = -1379914853;
							continue;
						case 2:
							if (P_0.valueContribution == Pole.Negative)
							{
								num2 *= -1f;
								num = -1379914854;
								continue;
							}
							goto case 0;
						case 3:
							if (P_0.valueRange != CustomControllerElementTarget.ValueRange.Full)
							{
								goto case 2;
							}
							if (P_0.invert)
							{
								num2 *= -1f;
								num = -1379914851;
								continue;
							}
							goto case 0;
						case 0:
							controller.SetAxisValue(P_0.element, num2);
							return;
						case 4:
							break;
						case 7:
							num = -1379914854;
							continue;
						case 6:
							goto end_IL_000c;
						case 1:
							goto IL_00d5;
						default:
							throw new NotImplementedException();
						}
						goto end_IL_00e4;
						continue;
						end_IL_000c:
						break;
					}
					goto case CustomControllerElementSelector.ElementType.Axis;
					end_IL_00e4:
					break;
				}
				break;
			}
			controller.SetButtonValue(P_0.element, P_1);
		}

		private void yEBUioqLlAtamFyvbaGVtgDsSwS()
		{
			if (NZeLTHDjxyfcTdsfWcwpAHDDJXtD())
			{
				return;
			}
			if (!WMOIUVAoMMEQPQHrJmvWWfvqFVh())
			{
				while (true)
				{
					switch (0x2AEB2359 ^ 0x2AEB2358)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			OnCustomControllerUpdate();
		}
	}
}
