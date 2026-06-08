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
		internal CustomController controller => TAPfjlgREenQuGvVOUpFiufnACp() as CustomController;

		internal override bool hasController => TAPfjlgREenQuGvVOUpFiufnACp() as CustomController != null;

		[CustomObfuscation(rename = false)]
		internal CustomControllerControl()
		{
		}

		internal override void NjkGaTSbjeAmPqdpyKMonMbyiMJ()
		{
			base.NjkGaTSbjeAmPqdpyKMonMbyiMJ();
			if (hasController)
			{
				erHIwspAqyvfsFjxpigiGUNoawW();
				controller.InputSourceUpdateEvent += BXQsbpKHyppebcFJcWPFnvOGNLH;
			}
		}

		internal override void erHIwspAqyvfsFjxpigiGUNoawW()
		{
			base.erHIwspAqyvfsFjxpigiGUNoawW();
			if (hasController)
			{
				controller.InputSourceUpdateEvent -= BXQsbpKHyppebcFJcWPFnvOGNLH;
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

		internal void fcpMokSOSPSkfIoeTHjUJvvymMbi(CustomControllerElementTargetSet P_0, float P_1, float P_2)
		{
			if (!hasController)
			{
				return;
			}
			CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean = default(CustomControllerElementTargetSetForBoolean);
			while (P_0 != null)
			{
				while (true)
				{
					IL_00ba:
					CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat = P_0 as CustomControllerElementTargetSetForFloat;
					int num = -712378300;
					while (true)
					{
						switch (num ^ -712378302)
						{
						case 2:
							num = -712378298;
							continue;
						default:
							return;
						case 4:
							break;
						case 6:
							if (customControllerElementTargetSetForFloat != null)
							{
								if (!customControllerElementTargetSetForFloat.splitValue)
								{
									fcpMokSOSPSkfIoeTHjUJvvymMbi(customControllerElementTargetSetForFloat.target, P_1, P_2);
									return;
								}
								goto case 1;
							}
							goto case 0;
						case 7:
							if (customControllerElementTargetSetForBoolean != null)
							{
								fcpMokSOSPSkfIoeTHjUJvvymMbi(customControllerElementTargetSetForBoolean.target, P_1, P_2);
								num = -712378303;
								continue;
							}
							return;
						case 1:
							fcpMokSOSPSkfIoeTHjUJvvymMbi(customControllerElementTargetSetForFloat.positiveTarget, P_1, P_2);
							fcpMokSOSPSkfIoeTHjUJvvymMbi(customControllerElementTargetSetForFloat.negativeTarget, P_1, P_2);
							return;
						case 0:
							customControllerElementTargetSetForBoolean = P_0 as CustomControllerElementTargetSetForBoolean;
							num = -712378299;
							continue;
						case 5:
							goto IL_00ba;
						case 3:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		internal void fcpMokSOSPSkfIoeTHjUJvvymMbi(CustomControllerElementTargetSet P_0, bool P_1)
		{
			if (!hasController)
			{
				return;
			}
			while (P_0 != null)
			{
				while (true)
				{
					IL_0098:
					if (!(P_0 is CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean))
					{
						while (true)
						{
							IL_005d:
							if (!(P_0 is CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat))
							{
								return;
							}
							int num;
							int num2;
							if (customControllerElementTargetSetForFloat.splitValue)
							{
								num = -478165217;
								num2 = num;
							}
							else
							{
								num = -478165222;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ -478165220)
								{
								case 0:
									num = -478165221;
									continue;
								default:
									return;
								case 7:
									break;
								case 1:
									fcpMokSOSPSkfIoeTHjUJvvymMbi(customControllerElementTargetSetForFloat.negativeTarget, P_1);
									num = -478165218;
									continue;
								case 5:
									goto IL_005d;
								case 6:
									fcpMokSOSPSkfIoeTHjUJvvymMbi(customControllerElementTargetSetForFloat.target, P_1);
									return;
								case 4:
									goto IL_0098;
								case 3:
									fcpMokSOSPSkfIoeTHjUJvvymMbi(customControllerElementTargetSetForFloat.positiveTarget, P_1);
									num = -478165219;
									continue;
								case 2:
									return;
								}
								break;
							}
							break;
						}
						break;
					}
					fcpMokSOSPSkfIoeTHjUJvvymMbi(customControllerElementTargetSetForBoolean.target, P_1);
					return;
				}
			}
		}

		internal abstract void KhATpHHLaxfVykPnYPwsOWKYpr();

		private void fcpMokSOSPSkfIoeTHjUJvvymMbi(CustomControllerElementTarget P_0, float P_1, float P_2)
		{
			if (P_0 == null)
			{
				return;
			}
			CustomControllerElementTarget.ValueRange valueRange2 = default(CustomControllerElementTarget.ValueRange);
			CustomControllerElementTarget.ValueRange valueRange = default(CustomControllerElementTarget.ValueRange);
			while (true)
			{
				CustomControllerElementSelector.ElementType elementType = P_0.element.elementType;
				int num = -182082307;
				while (true)
				{
					int num4;
					switch (num ^ -182082317)
					{
					case 13:
						num = -182082334;
						continue;
					case 12:
						switch (P_0.valueRange)
						{
						case CustomControllerElementTarget.ValueRange.Negative:
							goto IL_0129;
						case CustomControllerElementTarget.ValueRange.Full:
							goto IL_016f;
						case CustomControllerElementTarget.ValueRange.Positive:
							goto IL_0228;
						}
						num = -182082311;
						continue;
					case 14:
						switch (elementType)
						{
						case CustomControllerElementSelector.ElementType.Button:
							break;
						default:
							goto IL_00a7;
						case CustomControllerElementSelector.ElementType.Axis:
							goto IL_00b1;
						}
						goto case 12;
					case 7:
						goto IL_00b1;
					case 20:
					{
						int num3;
						if (P_1 >= 0f)
						{
							num = -182082336;
							num3 = num;
						}
						else
						{
							num = -182082319;
							num3 = num;
						}
						continue;
					}
					case 1:
						P_1 *= -1f;
						num = -182082317;
						continue;
					case 5:
						goto IL_00f1;
					case 6:
						switch (valueRange2)
						{
						case CustomControllerElementTarget.ValueRange.Positive:
							break;
						case CustomControllerElementTarget.ValueRange.Full:
							goto IL_00f1;
						default:
							goto IL_011f;
						case CustomControllerElementTarget.ValueRange.Negative:
							goto IL_01f3;
						}
						goto case 20;
					case 18:
						goto IL_0129;
					case 0:
						controller.SetAxisValue(P_0.element, P_1);
						return;
					case 11:
						valueRange2 = valueRange;
						num = -182082315;
						continue;
					case 3:
						goto IL_016f;
					case 4:
						P_1 = 0f;
						num = -182082320;
						continue;
					case 2:
						P_1 = 0f;
						num = -182082336;
						continue;
					case 19:
						if (P_0.valueContribution == Pole.Negative)
						{
							P_1 *= -1f;
							num = -182082317;
							continue;
						}
						goto case 0;
					case 17:
						break;
					case 15:
						goto IL_01f3;
					case 9:
					{
						int num2;
						if (P_0.valueContribution != Pole.Positive)
						{
							num = -182082317;
							num2 = num;
						}
						else
						{
							num = -182082318;
							num2 = num;
						}
						continue;
					}
					case 8:
						goto IL_0228;
					case 10:
						num = -182082320;
						continue;
					default:
						{
							throw new NotImplementedException();
						}
						IL_00b1:
						valueRange = P_0.valueRange;
						num = -182082312;
						continue;
						IL_01f3:
						if (P_1 > 0f)
						{
							P_1 = 0f;
							num = -182082310;
							continue;
						}
						goto case 9;
						IL_00a7:
						num = -182082333;
						continue;
						IL_0228:
						if (P_1 < 0f)
						{
							P_1 = 0f;
							num = -182082320;
							continue;
						}
						goto IL_016f;
						IL_011f:
						num = -182082317;
						continue;
						IL_00f1:
						if (P_0.invert)
						{
							P_1 *= -1f;
							num = -182082317;
							continue;
						}
						goto case 0;
						IL_016f:
						controller.SetButtonValue(P_0.element, MathTools.Abs(P_1) >= MathTools.Abs(P_2));
						return;
						IL_0129:
						if (P_1 <= 0f)
						{
							num = -182082320;
							num4 = num;
						}
						else
						{
							num = -182082313;
							num4 = num;
						}
						continue;
					}
					break;
				}
			}
		}

		private void fcpMokSOSPSkfIoeTHjUJvvymMbi(CustomControllerElementTarget P_0, bool P_1)
		{
			if (P_0 == null)
			{
				goto IL_0006;
			}
			goto IL_012b;
			IL_0006:
			int num = -1337754047;
			goto IL_000b;
			IL_000b:
			float num2 = default(float);
			CustomControllerElementSelector.ElementType elementType = default(CustomControllerElementSelector.ElementType);
			while (true)
			{
				float num3;
				switch (num ^ -1337754035)
				{
				case 6:
					break;
				case 5:
					num3 = 0f;
					goto IL_0063;
				case 10:
					num2 *= -1f;
					num = -1337754035;
					continue;
				case 14:
					if (P_1)
					{
						num3 = 1f;
						goto IL_0063;
					}
					num = -1337754040;
					continue;
				case 3:
					return;
				case 0:
					controller.SetAxisValue(P_0.element, num2);
					num = -1337754034;
					continue;
				case 1:
					return;
				case 11:
					switch (elementType)
					{
					case CustomControllerElementSelector.ElementType.Axis:
						break;
					default:
						goto IL_00c4;
					case CustomControllerElementSelector.ElementType.Button:
						goto IL_00e8;
					}
					goto case 14;
				case 4:
					if (P_0.invert)
					{
						num2 *= -1f;
						num = -1337754035;
						continue;
					}
					goto case 0;
				case 2:
					goto IL_00e8;
				case 8:
					goto IL_0104;
				case 12:
					return;
				case 7:
					goto IL_012b;
				case 9:
					goto IL_0143;
				default:
					{
						throw new NotImplementedException();
					}
					IL_00e8:
					controller.SetButtonValue(P_0.element, P_1);
					num = -1337754036;
					continue;
					IL_00c4:
					num = -1337754048;
					continue;
					IL_0063:
					num2 = num3;
					num = -1337754043;
					continue;
				}
				break;
				IL_0143:
				int num4;
				if (P_0.valueContribution == Pole.Negative)
				{
					num = -1337754041;
					num4 = num;
				}
				else
				{
					num = -1337754035;
					num4 = num;
				}
				continue;
				IL_0104:
				int num5;
				if (P_0.valueRange == CustomControllerElementTarget.ValueRange.Full)
				{
					num = -1337754039;
					num5 = num;
				}
				else
				{
					num = -1337754044;
					num5 = num;
				}
			}
			goto IL_0006;
			IL_012b:
			CustomControllerElementSelector.ElementType elementType2 = P_0.element.elementType;
			elementType = elementType2;
			num = -1337754042;
			goto IL_000b;
		}

		private void BXQsbpKHyppebcFJcWPFnvOGNLH()
		{
			if (sAoctQjASyGxKJKUXfHqVIbIHCY())
			{
				return;
			}
			if (!pmYjhUyltIKROfKAKRLTAORpQYO())
			{
				while (true)
				{
					switch (-1371600925 ^ -1371600926)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			KhATpHHLaxfVykPnYPwsOWKYpr();
		}
	}
}
