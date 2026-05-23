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
				return LKDXaxXfiiwGAVtjdSCKBcNgYPZ() as CustomController;
			}
		}

		internal override bool hasController
		{
			get
			{
				return LKDXaxXfiiwGAVtjdSCKBcNgYPZ() as CustomController != null;
			}
		}

		[CustomObfuscation(rename = false)]
		internal CustomControllerControl()
		{
		}

		internal override void OnSubscribeEvents()
		{
			base.OnSubscribeEvents();
			while (true)
			{
				switch (0x31190EA9 ^ 0x31190EA8)
				{
				case 2:
					continue;
				case 1:
					if (!hasController)
					{
						return;
					}
					break;
				}
				break;
			}
			OnUnsubscribeEvents();
			controller.InputSourceUpdateEvent += PiCJAnAbJpYtVlajDkqOEdsBgDb;
		}

		internal override void OnUnsubscribeEvents()
		{
			base.OnUnsubscribeEvents();
			if (!hasController)
			{
				return;
			}
			while (true)
			{
				controller.InputSourceUpdateEvent -= PiCJAnAbJpYtVlajDkqOEdsBgDb;
				int num = -1058986491;
				while (true)
				{
					switch (num ^ -1058986489)
					{
					case 0:
						goto IL_000f;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_000f:
					num = -1058986490;
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

		internal void jdvcKcWQnHxAXPvCkvKHWiFjvWV(CustomControllerElementTargetSet P_0, float P_1, float P_2)
		{
			if (!hasController)
			{
				goto IL_000b;
			}
			goto IL_00ef;
			IL_000b:
			int num = 1102948119;
			goto IL_0010;
			IL_0010:
			CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean = default(CustomControllerElementTargetSetForBoolean);
			CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat = default(CustomControllerElementTargetSetForFloat);
			while (true)
			{
				switch (num ^ 0x41BDA71D)
				{
				case 5:
					break;
				default:
					return;
				case 11:
					return;
				case 6:
					customControllerElementTargetSetForBoolean = P_0 as CustomControllerElementTargetSetForBoolean;
					num = 1102948116;
					continue;
				case 10:
					return;
				case 3:
					if (!customControllerElementTargetSetForFloat.splitValue)
					{
						jdvcKcWQnHxAXPvCkvKHWiFjvWV(customControllerElementTargetSetForFloat.target, P_1, P_2);
						return;
					}
					goto case 8;
				case 7:
					goto IL_008c;
				case 9:
					if (customControllerElementTargetSetForBoolean != null)
					{
						jdvcKcWQnHxAXPvCkvKHWiFjvWV(customControllerElementTargetSetForBoolean.target, P_1, P_2);
						num = 1102948127;
						continue;
					}
					return;
				case 8:
					jdvcKcWQnHxAXPvCkvKHWiFjvWV(customControllerElementTargetSetForFloat.positiveTarget, P_1, P_2);
					num = 1102948121;
					continue;
				case 4:
					jdvcKcWQnHxAXPvCkvKHWiFjvWV(customControllerElementTargetSetForFloat.negativeTarget, P_1, P_2);
					return;
				case 1:
					goto IL_00ef;
				case 0:
					customControllerElementTargetSetForFloat = P_0 as CustomControllerElementTargetSetForFloat;
					num = 1102948122;
					continue;
				case 2:
					return;
				}
				break;
				IL_008c:
				int num2;
				if (customControllerElementTargetSetForFloat == null)
				{
					num = 1102948123;
					num2 = num;
				}
				else
				{
					num = 1102948126;
					num2 = num;
				}
			}
			goto IL_000b;
			IL_00ef:
			int num3;
			if (P_0 != null)
			{
				num = 1102948125;
				num3 = num;
			}
			else
			{
				num = 1102948118;
				num3 = num;
			}
			goto IL_0010;
		}

		internal void jdvcKcWQnHxAXPvCkvKHWiFjvWV(CustomControllerElementTargetSet P_0, bool P_1)
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
					num = -1370474572;
					num2 = num;
				}
				else
				{
					num = -1370474573;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1370474572)
					{
					case 5:
						num = -1370474576;
						continue;
					default:
						return;
					case 4:
						break;
					case 2:
						if (customControllerElementTargetSetForFloat != null)
						{
							if (!customControllerElementTargetSetForFloat.splitValue)
							{
								jdvcKcWQnHxAXPvCkvKHWiFjvWV(customControllerElementTargetSetForFloat.target, P_1);
								return;
							}
							goto case 9;
						}
						return;
					case 7:
						customControllerElementTargetSetForBoolean = P_0 as CustomControllerElementTargetSetForBoolean;
						num = -1370474564;
						continue;
					case 1:
						customControllerElementTargetSetForFloat = P_0 as CustomControllerElementTargetSetForFloat;
						num = -1370474570;
						continue;
					case 9:
						jdvcKcWQnHxAXPvCkvKHWiFjvWV(customControllerElementTargetSetForFloat.positiveTarget, P_1);
						jdvcKcWQnHxAXPvCkvKHWiFjvWV(customControllerElementTargetSetForFloat.negativeTarget, P_1);
						num = -1370474574;
						continue;
					case 3:
						jdvcKcWQnHxAXPvCkvKHWiFjvWV(customControllerElementTargetSetForBoolean.target, P_1);
						return;
					case 8:
					{
						int num3;
						if (customControllerElementTargetSetForBoolean != null)
						{
							num = -1370474569;
							num3 = num;
						}
						else
						{
							num = -1370474571;
							num3 = num;
						}
						continue;
					}
					case 0:
						return;
					case 6:
						return;
					}
					break;
				}
			}
		}

		internal abstract void OnCustomControllerUpdate();

		private void jdvcKcWQnHxAXPvCkvKHWiFjvWV(CustomControllerElementTarget P_0, float P_1, float P_2)
		{
			if (P_0 == null)
			{
				goto IL_0006;
			}
			goto IL_0087;
			IL_0006:
			int num = 72518570;
			goto IL_000b;
			IL_000b:
			CustomControllerElementTarget.ValueRange valueRange = default(CustomControllerElementTarget.ValueRange);
			CustomControllerElementTarget.ValueRange valueRange2 = default(CustomControllerElementTarget.ValueRange);
			while (true)
			{
				switch (num ^ 0x4528BAB)
				{
				case 8:
					break;
				case 5:
					return;
				case 12:
					P_1 *= -1f;
					num = 72518571;
					continue;
				case 18:
					goto IL_0087;
				case 1:
					return;
				case 6:
					goto IL_00b8;
				case 3:
					if (P_1 < 0f)
					{
						P_1 = 0f;
						num = 72518591;
						continue;
					}
					goto IL_0184;
				case 9:
					goto IL_00f0;
				case 14:
					if (P_0.valueContribution == Pole.Positive)
					{
						P_1 *= -1f;
						num = 72518571;
						continue;
					}
					goto case 0;
				case 10:
					goto IL_0135;
				case 13:
					goto IL_0146;
				case 15:
					P_1 = 0f;
					num = 72518565;
					continue;
				case 20:
					goto IL_0184;
				case 2:
					goto IL_01a1;
				case 19:
					valueRange = valueRange2;
					num = 72518560;
					continue;
				case 7:
					goto IL_01c7;
				case 4:
					num = 72518566;
					continue;
				case 17:
					goto IL_01ec;
				case 11:
					switch (valueRange)
					{
					case CustomControllerElementTarget.ValueRange.Positive:
						break;
					case CustomControllerElementTarget.ValueRange.Full:
						goto IL_01c7;
					case CustomControllerElementTarget.ValueRange.Negative:
						goto IL_01ec;
					default:
						goto IL_021b;
					}
					goto case 3;
				case 0:
					controller.SetAxisValue(P_0.element, P_1);
					num = 72518574;
					continue;
				default:
					{
						throw new NotImplementedException();
					}
					IL_021b:
					num = 72518571;
					continue;
					IL_01c7:
					if (P_0.invert)
					{
						P_1 *= -1f;
						num = 72518571;
						continue;
					}
					goto case 0;
				}
				break;
				IL_01ec:
				int num2;
				if (P_1 > 0f)
				{
					num = 72518564;
					num2 = num;
				}
				else
				{
					num = 72518565;
					num2 = num;
				}
				continue;
				IL_0184:
				int num3;
				if (P_0.valueContribution == Pole.Negative)
				{
					num = 72518567;
					num3 = num;
				}
				else
				{
					num = 72518571;
					num3 = num;
				}
			}
			goto IL_0006;
			IL_0087:
			switch (P_0.element.elementType)
			{
			case CustomControllerElementSelector.ElementType.Button:
				goto IL_00f0;
			case CustomControllerElementSelector.ElementType.Axis:
				goto IL_0135;
			}
			num = 72518587;
			goto IL_000b;
			IL_0146:
			controller.SetButtonValue(P_0.element, MathTools.Abs(P_1) >= MathTools.Abs(P_2));
			return;
			IL_010d:
			num = 72518566;
			goto IL_000b;
			IL_0135:
			valueRange2 = P_0.valueRange;
			num = 72518584;
			goto IL_000b;
			IL_01a1:
			if (P_1 < 0f)
			{
				P_1 = 0f;
				num = 72518575;
				goto IL_000b;
			}
			goto IL_0146;
			IL_00f0:
			switch (P_0.valueRange)
			{
			case CustomControllerElementTarget.ValueRange.Negative:
				break;
			default:
				goto IL_010d;
			case CustomControllerElementTarget.ValueRange.Full:
				goto IL_0146;
			case CustomControllerElementTarget.ValueRange.Positive:
				goto IL_01a1;
			}
			goto IL_00b8;
			IL_00b8:
			if (P_1 > 0f)
			{
				P_1 = 0f;
				num = 72518566;
				goto IL_000b;
			}
			goto IL_0146;
		}

		private void jdvcKcWQnHxAXPvCkvKHWiFjvWV(CustomControllerElementTarget P_0, bool P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			float num2 = default(float);
			while (true)
			{
				CustomControllerElementSelector.ElementType elementType = P_0.element.elementType;
				CustomControllerElementSelector.ElementType elementType2 = elementType;
				int num = 1896381643;
				while (true)
				{
					switch (num ^ 0x71087CC8)
					{
					case 2:
						num = 1896381641;
						continue;
					case 6:
						controller.SetAxisValue(P_0.element, num2);
						return;
					case 0:
						num = 1896381645;
						continue;
					case 7:
						controller.SetButtonValue(P_0.element, P_1);
						return;
					case 3:
						switch (elementType2)
						{
						case CustomControllerElementSelector.ElementType.Button:
							break;
						default:
							goto IL_0089;
						case CustomControllerElementSelector.ElementType.Axis:
							goto IL_00c6;
						}
						goto case 7;
					case 1:
						break;
					case 4:
						if (P_0.valueContribution == Pole.Negative)
						{
							num2 *= -1f;
							num = 1896381646;
							continue;
						}
						goto case 6;
					case 8:
						goto IL_00c6;
					default:
						{
							throw new NotImplementedException();
						}
						IL_00c6:
						num2 = (P_1 ? 1f : 0f);
						if (P_0.valueRange == CustomControllerElementTarget.ValueRange.Full)
						{
							if (P_0.invert)
							{
								num2 *= -1f;
								num = 1896381646;
								continue;
							}
							goto case 6;
						}
						goto case 4;
						IL_0089:
						num = 1896381640;
						continue;
					}
					break;
				}
			}
		}

		private void PiCJAnAbJpYtVlajDkqOEdsBgDb()
		{
			if (umueQObHjgIFkfOkmqetfqLVJGol())
			{
				return;
			}
			if (!vWWTQEuzSAtwkwTidoREbMzaAEi())
			{
				while (true)
				{
					switch (0xDAF52DC ^ 0xDAF52DE)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			OnCustomControllerUpdate();
		}
	}
}
