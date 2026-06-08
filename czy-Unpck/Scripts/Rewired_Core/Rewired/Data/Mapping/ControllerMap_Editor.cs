using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Rewired.Interfaces;
using Rewired.Utils;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public sealed class ControllerMap_Editor
	{
		private sealed class dPZLREBsQvxpgRVOQQjljunccsE : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public ControllerMap_Editor syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int PSmjXiTtTWKPkmLbUbHkvOzjvZk;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				dPZLREBsQvxpgRVOQQjljunccsE dPZLREBsQvxpgRVOQQjljunccsE2;
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					dPZLREBsQvxpgRVOQQjljunccsE2 = this;
					goto IL_0025;
				}
				goto IL_004e;
				IL_002a:
				int num;
				while (true)
				{
					switch (num ^ 0x4F43F786)
					{
					case 0:
						break;
					case 3:
						num = 1329854340;
						continue;
					case 1:
						goto IL_004e;
					default:
						return dPZLREBsQvxpgRVOQQjljunccsE2;
					}
					break;
				}
				goto IL_0025;
				IL_004e:
				dPZLREBsQvxpgRVOQQjljunccsE2 = new dPZLREBsQvxpgRVOQQjljunccsE(0);
				dPZLREBsQvxpgRVOQQjljunccsE2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				num = 1329854340;
				goto IL_002a;
				IL_0025:
				num = 1329854341;
				goto IL_002a;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				int num3;
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				default:
					num = 1099630250;
					goto IL_001a;
				case 1:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					PSmjXiTtTWKPkmLbUbHkvOzjvZk++;
					num = 1099630248;
					goto IL_001a;
				case 0:
					goto IL_00d6;
					IL_001a:
					while (true)
					{
						switch (num ^ 0x418B06AB)
						{
						case 7:
							break;
						case 1:
							num = 1099630254;
							continue;
						case 2:
							PSmjXiTtTWKPkmLbUbHkvOzjvZk = 0;
							num = 1099630248;
							continue;
						case 6:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							return true;
						case 4:
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionElementMaps[PSmjXiTtTWKPkmLbUbHkvOzjvZk];
							num = 1099630253;
							continue;
						case 3:
							goto IL_00aa;
						case 0:
							goto IL_00d6;
						default:
							return false;
						}
						break;
						IL_00aa:
						int num2;
						if (PSmjXiTtTWKPkmLbUbHkvOzjvZk >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionElementMaps.Count)
						{
							num = 1099630254;
							num2 = num;
						}
						else
						{
							num = 1099630255;
							num2 = num;
						}
					}
					goto default;
					IL_00d6:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionElementMaps == null)
					{
						num = 1099630254;
						num3 = num;
					}
					else
					{
						num = 1099630249;
						num3 = num;
					}
					goto IL_001a;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public dPZLREBsQvxpgRVOQQjljunccsE(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		public int id;

		public int categoryId;

		public int layoutId;

		public string name;

		public string hardwareGuidString;

		public int customControllerUid;

		public List<ActionElementMap> actionElementMaps;

		public IEnumerable<ActionElementMap> ActionElementMaps
		{
			get
			{
				dPZLREBsQvxpgRVOQQjljunccsE dPZLREBsQvxpgRVOQQjljunccsE2 = new dPZLREBsQvxpgRVOQQjljunccsE(-2);
				dPZLREBsQvxpgRVOQQjljunccsE2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return dPZLREBsQvxpgRVOQQjljunccsE2;
			}
		}

		public Guid hardwareGuid => StringTools.ToGuid(hardwareGuidString);

		public ControllerMap_Editor()
		{
			actionElementMaps = new List<ActionElementMap>();
		}

		public ControllerMap_Editor Clone()
		{
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = id;
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			controllerMap_Editor.name = name;
			controllerMap_Editor.hardwareGuidString = hardwareGuidString;
			int num2 = default(int);
			while (true)
			{
				int num = 1599274861;
				while (true)
				{
					switch (num ^ 0x5F52FF6C)
					{
					case 2:
						break;
					case 3:
					{
						int num3;
						if (num2 >= actionElementMaps.Count)
						{
							num = 1599274857;
							num3 = num;
						}
						else
						{
							num = 1599274860;
							num3 = num;
						}
						continue;
					}
					case 4:
						num = 1599274863;
						continue;
					case 6:
						if (actionElementMaps != null)
						{
							controllerMap_Editor.actionElementMaps = new List<ActionElementMap>();
							num2 = 0;
							num = 1599274856;
							continue;
						}
						goto default;
					case 1:
						controllerMap_Editor.customControllerUid = customControllerUid;
						num = 1599274858;
						continue;
					case 0:
						controllerMap_Editor.actionElementMaps.Add(new ActionElementMap(actionElementMaps[num2]));
						num2++;
						num = 1599274863;
						continue;
					default:
						return controllerMap_Editor;
					}
					break;
				}
			}
		}

		public ActionElementMap GetActionElementMap(int index)
		{
			if (index < 0 || index >= actionElementMaps.Count)
			{
				return null;
			}
			return actionElementMaps[index];
		}

		internal JoystickMap VBSqrvDMnHWQrGAHHGgQMkxDWLx(Func<int, bool> P_0, HardwareControllerMapIdentifier P_1, HardwareJoystickMap P_2, bool P_3)
		{
			JoystickMap joystickMap = new JoystickMap();
			while (true)
			{
				int num = 2108000939;
				while (true)
				{
					switch (num ^ 0x7DA58AAA)
					{
					case 2:
						break;
					case 1:
						goto IL_0024;
					default:
						return joystickMap;
					}
					break;
					IL_0024:
					FDGaeHegFytyHMcqIBqCPcrBNmy(P_0, joystickMap, P_1, P_2, P_3);
					num = 2108000938;
				}
			}
		}

		internal KeyboardMap WemcRkNxcNeYUDQGmfpkctxNHTu(Func<int, bool> P_0)
		{
			KeyboardMap keyboardMap = new KeyboardMap();
			FDGaeHegFytyHMcqIBqCPcrBNmy(P_0, keyboardMap, default(HardwareControllerMapIdentifier), null, false);
			return keyboardMap;
		}

		internal MouseMap JssclkKWoJeoDnDTqRbfzmxMBpq(Func<int, bool> P_0)
		{
			MouseMap mouseMap = new MouseMap();
			while (true)
			{
				int num = 770948639;
				while (true)
				{
					switch (num ^ 0x2DF3BE1E)
					{
					case 2:
						break;
					case 1:
						goto IL_0024;
					default:
						return mouseMap;
					}
					break;
					IL_0024:
					FDGaeHegFytyHMcqIBqCPcrBNmy(P_0, mouseMap, default(HardwareControllerMapIdentifier), null, false);
					num = 770948638;
				}
			}
		}

		internal CustomControllerMap nkhnzynaOXhPKaCqfUYNoxfFfKnc(Func<int, bool> P_0, CustomController_Editor P_1)
		{
			CustomControllerMap customControllerMap = new CustomControllerMap();
			while (true)
			{
				int num = -224163520;
				while (true)
				{
					switch (num ^ -224163518)
					{
					case 0:
						break;
					case 2:
						goto IL_0024;
					default:
						return customControllerMap;
					}
					break;
					IL_0024:
					QNjbDiJhZMeNSFyKHNDAcmfpAPHK(P_0, InputSource.Custom, customControllerMap, P_1);
					num = -224163517;
				}
			}
		}

		internal ControllerTemplateMap MKKPohgDyVlGheCiiHancGvCDlHE()
		{
			if (!(ReInput.pSLHqenYotlZJRwsFYENzaJIYfl(hardwareGuid) is IHardwareControllerTemplateMap_Internal))
			{
				goto IL_0014;
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(hardwareGuid, categoryId, layoutId, id);
			int num = -625446637;
			goto IL_0019;
			IL_0019:
			int num2 = default(int);
			ControllerTemplateActionElementMap controllerTemplateActionElementMap = default(ControllerTemplateActionElementMap);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -625446639)
				{
				case 9:
					break;
				case 3:
					return null;
				case 4:
					num2++;
					num = -625446636;
					continue;
				case 6:
					controllerTemplateMap.AddElementMap(controllerTemplateActionElementMap);
					num = -625446635;
					continue;
				case 7:
				{
					ActionElementMap actionElementMap = actionElementMaps[num2];
					if (actionElementMap != null && InputTools.IsMappableType(actionElementMap._elementType))
					{
						controllerTemplateActionElementMap = ControllerTemplateActionElementMap.GIHuiEkmFihgdjpqkqIhwXanlmm(actionElementMap);
						num = -625446639;
						continue;
					}
					goto case 4;
				}
				case 8:
					num = -625446636;
					continue;
				case 0:
				{
					int num5;
					if (controllerTemplateActionElementMap != null)
					{
						num = -625446633;
						num5 = num;
					}
					else
					{
						num = -625446635;
						num5 = num;
					}
					continue;
				}
				case 10:
					num2 = 0;
					num = -625446631;
					continue;
				case 2:
					num3 = ((actionElementMaps != null) ? actionElementMaps.Count : 0);
					num = -625446629;
					continue;
				case 5:
				{
					int num4;
					if (num2 < num3)
					{
						num = -625446634;
						num4 = num;
					}
					else
					{
						num = -625446640;
						num4 = num;
					}
					continue;
				}
				default:
					return controllerTemplateMap;
				}
				break;
			}
			goto IL_0014;
			IL_0014:
			num = -625446638;
			goto IL_0019;
		}

		private void FDGaeHegFytyHMcqIBqCPcrBNmy(Func<int, bool> P_0, ControllerMap P_1, HardwareControllerMapIdentifier P_2, HardwareJoystickMap P_3, bool P_4)
		{
			P_1.sourceMapId = id;
			P_1.categoryId = categoryId;
			ActionElementMap actionElementMap = default(ActionElementMap);
			ControllerElementType effectiveElementIdentifierType = default(ControllerElementType);
			int num2 = default(int);
			ControllerElementIdentifier elementIdentifier = default(ControllerElementIdentifier);
			bool effectiveAxisRange = default(bool);
			AxisRange axisRange = default(AxisRange);
			while (true)
			{
				int num = -749772621;
				while (true)
				{
					switch (num ^ -749772622)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						actionElementMap._invert = false;
						num = -749772615;
						continue;
					case 20:
						if (effectiveElementIdentifierType == actionElementMaps[num2].elementType)
						{
							goto case 11;
						}
						actionElementMap._elementType = effectiveElementIdentifierType;
						if (effectiveElementIdentifierType != ControllerElementType.Axis)
						{
							goto case 14;
						}
						if (elementIdentifier.elementType == ControllerElementType.Button)
						{
							actionElementMap._axisRange = AxisRange.Positive;
							num = -749772623;
							continue;
						}
						goto case 13;
					case 14:
					{
						int num6;
						if (effectiveElementIdentifierType == ControllerElementType.Button)
						{
							num = -749772619;
							num6 = num;
						}
						else
						{
							num = -749772639;
							num6 = num;
						}
						continue;
					}
					case 2:
						num2 = 0;
						num = -749772640;
						continue;
					case 11:
						P_1.IXqmncltgmkzpGDZegTRdilkcDa(actionElementMap);
						num = -749772614;
						continue;
					case 13:
						effectiveAxisRange = P_3.GetEffectiveAxisRange(P_2, actionElementMaps[num2].elementIdentifierId, P_4, out axisRange);
						num = -749772613;
						continue;
					case 5:
						num = -749772615;
						continue;
					case 10:
						actionElementMap._axisRange = axisRange;
						num = -749772623;
						continue;
					case 1:
						P_1.name = name;
						P_1.hardwareGuid = StringTools.ToGuid(hardwareGuidString);
						if (actionElementMaps == null)
						{
							return;
						}
						goto case 2;
					case 18:
					{
						int num4;
						if (num2 >= actionElementMaps.Count)
						{
							num = -749772610;
							num4 = num;
						}
						else
						{
							num = -749772611;
							num4 = num;
						}
						continue;
					}
					case 17:
						actionElementMap._axisRange = AxisRange.Positive;
						num = -749772623;
						continue;
					case 8:
						num2++;
						num = -749772640;
						continue;
					case 7:
						if (actionElementMap._axisRange == AxisRange.Full)
						{
							actionElementMap._axisContribution = (actionElementMap._invert ? Pole.Negative : Pole.Positive);
							num = -749772620;
							continue;
						}
						goto case 6;
					case 9:
					{
						int num5;
						if (!effectiveAxisRange)
						{
							num = -749772638;
							num5 = num;
						}
						else
						{
							num = -749772616;
							num5 = num;
						}
						continue;
					}
					case 16:
						if (actionElementMap.axisContribution == Pole.Negative)
						{
							actionElementMap._axisRange = AxisRange.Negative;
							num = -749772623;
							continue;
						}
						goto case 17;
					case 4:
						effectiveElementIdentifierType = P_3.GetEffectiveElementIdentifierType(P_2, actionElementMaps[num2].elementIdentifierId, P_4);
						_ = elementIdentifier.elementType;
						num = -749772634;
						continue;
					case 15:
						if (P_0(actionElementMaps[num2].actionId))
						{
							actionElementMap = new ActionElementMap(actionElementMaps[num2]);
							if (P_3 != null)
							{
								elementIdentifier = P_3.GetElementIdentifier(actionElementMaps[num2].elementIdentifierId);
								int num3;
								if (elementIdentifier != null)
								{
									num = -749772618;
									num3 = num;
								}
								else
								{
									num = -749772615;
									num3 = num;
								}
								continue;
							}
							goto case 11;
						}
						goto case 8;
					case 19:
						throw new NotImplementedException();
					case 6:
						actionElementMap._invert = false;
						actionElementMap._axisRange = AxisRange.Full;
						num = -749772617;
						continue;
					case 12:
						return;
					}
					break;
				}
			}
		}

		private void QNjbDiJhZMeNSFyKHNDAcmfpAPHK(Func<int, bool> P_0, InputSource P_1, CustomControllerMap P_2, CustomController_Editor P_3)
		{
			P_2.sourceMapId = id;
			P_2.categoryId = categoryId;
			P_2.name = name;
			P_2.sourceControllerId = customControllerUid;
			ControllerElementType controllerElementType = default(ControllerElementType);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num2 = default(int);
			ControllerElementIdentifier elementIdentifier = default(ControllerElementIdentifier);
			bool flag = default(bool);
			AxisRange axisRange = default(AxisRange);
			while (true)
			{
				int num = -1247697379;
				while (true)
				{
					switch (num ^ -1247697380)
					{
					case 2:
						break;
					case 12:
						if (controllerElementType != ControllerElementType.Button)
						{
							goto case 14;
						}
						if (actionElementMap.axisRange == AxisRange.Full)
						{
							actionElementMap.axisContribution = (actionElementMap.invert ? Pole.Negative : Pole.Positive);
							num = -1247697389;
							continue;
						}
						goto case 15;
					case 18:
						num2++;
						num = -1247697385;
						continue;
					case 13:
						if (!P_0(actionElementMaps[num2].actionId))
						{
							goto case 18;
						}
						actionElementMap = new ActionElementMap(actionElementMaps[num2]);
						if (P_3 != null)
						{
							elementIdentifier = P_3.GetElementIdentifier(actionElementMaps[num2].elementIdentifierId);
							num = -1247697387;
							continue;
						}
						goto case 6;
					case 16:
						flag = P_3.tbkpOYXsyLsKGmqGKIoZzbeoYEK(actionElementMaps[num2].elementIdentifierId, out axisRange);
						num = -1247697380;
						continue;
					case 14:
						throw new NotImplementedException();
					case 3:
						num = -1247697383;
						continue;
					case 8:
						num = -1247697383;
						continue;
					case 9:
					{
						int num3;
						if (elementIdentifier != null)
						{
							num = -1247697395;
							num3 = num;
						}
						else
						{
							num = -1247697382;
							num3 = num;
						}
						continue;
					}
					case 4:
						actionElementMap.axisRange = AxisRange.Positive;
						num = -1247697383;
						continue;
					case 19:
						actionElementMap.axisRange = AxisRange.Full;
						num = -1247697382;
						continue;
					case 5:
						actionElementMap.invert = false;
						num = -1247697382;
						continue;
					case 10:
						if (actionElementMap.axisContribution == Pole.Negative)
						{
							actionElementMap.axisRange = AxisRange.Negative;
							num = -1247697377;
							continue;
						}
						goto case 4;
					case 17:
						controllerElementType = P_3.loiHwkZMyULPlmMqMwZHkOrXnOI(actionElementMaps[num2].elementIdentifierId);
						_ = elementIdentifier.elementType;
						if (controllerElementType != actionElementMaps[num2].elementType)
						{
							actionElementMap.elementType = controllerElementType;
							if (controllerElementType != ControllerElementType.Axis)
							{
								goto case 12;
							}
							if (elementIdentifier.elementType == ControllerElementType.Button)
							{
								actionElementMap.axisRange = AxisRange.Positive;
								num = -1247697388;
								continue;
							}
							goto case 16;
						}
						goto case 6;
					case 1:
						if (actionElementMaps == null)
						{
							return;
						}
						goto case 7;
					case 15:
						actionElementMap.invert = false;
						num = -1247697393;
						continue;
					case 6:
						P_2.IXqmncltgmkzpGDZegTRdilkcDa(actionElementMap);
						num = -1247697394;
						continue;
					case 0:
						if (flag)
						{
							actionElementMap.axisRange = axisRange;
							num = -1247697383;
							continue;
						}
						goto case 10;
					case 7:
						num2 = 0;
						num = -1247697385;
						continue;
					default:
						if (num2 >= actionElementMaps.Count)
						{
							return;
						}
						goto case 13;
					}
					break;
				}
			}
		}

		public void CreateElementsFromHardwareMap(IHardwareControllerMap hardwareJoystickMap)
		{
			if (hardwareJoystickMap == null)
			{
				return;
			}
			int num = 0;
			using (IEnumerator<IControllerElementIdentifierCommon_Internal> enumerator = (hardwareJoystickMap as IHardwareControllerMap_Internal).ElementIdentifiers.GetEnumerator())
			{
				IControllerElementIdentifierCommon_Internal current = default(IControllerElementIdentifierCommon_Internal);
				ActionElementMap item = default(ActionElementMap);
				while (true)
				{
					int num2;
					int num3;
					if (!enumerator.MoveNext())
					{
						num2 = 1549717558;
						num3 = num2;
					}
					else
					{
						num2 = 1549717552;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x5C5ED034)
						{
						case 5:
							num2 = 1549717552;
							continue;
						default:
							return;
						case 3:
							break;
						case 0:
							if (InputTools.IsMappableControllerElementType(current.elementType))
							{
								item = new ActionElementMap(-1, zRJHFfVYpYamSokTjXZVUKlCnAG.bfOOOfvhbAfeUGROtAICBZCUJgir(current.elementType), current.id);
								num2 = 1549717557;
								continue;
							}
							break;
						case 1:
							actionElementMaps.Add(item);
							num++;
							num2 = 1549717559;
							continue;
						case 4:
							current = enumerator.Current;
							num2 = 1549717556;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		public void CreateElementsFromHardwareMap(CustomController_Editor customController)
		{
			if (customController == null)
			{
				return;
			}
			List<ActionElementMap> list = new List<ActionElementMap>();
			List<ActionElementMap> list2 = new List<ActionElementMap>();
			using (IEnumerator<ControllerElementIdentifier> enumerator = customController.ElementIdentifiers.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					while (true)
					{
						IL_0077:
						ControllerElementIdentifier current = enumerator.Current;
						ActionElementMap item = new ActionElementMap(-1, current.elementType, current.id);
						int num;
						if (current.elementType == ControllerElementType.Axis)
						{
							list2.Add(item);
							num = -247418280;
							goto IL_0027;
						}
						goto IL_0059;
						IL_0027:
						while (true)
						{
							switch (num ^ -247418277)
							{
							case 0:
								num = -247418278;
								continue;
							case 4:
								break;
							case 2:
								goto IL_0059;
							case 3:
								num = -247418274;
								continue;
							case 1:
								goto IL_0077;
							default:
								goto end_IL_0077;
							}
							break;
						}
						goto IL_004c;
						IL_0059:
						if (current.elementType == ControllerElementType.Button)
						{
							list.Add(item);
							num = -247418274;
							goto IL_0027;
						}
						goto IL_004c;
						IL_004c:
						throw new NotImplementedException();
						continue;
						end_IL_0077:
						break;
					}
				}
			}
			int num2 = 0;
			int num5 = default(int);
			while (true)
			{
				int num3;
				int num4;
				if (num2 < list2.Count)
				{
					num3 = -247418280;
					num4 = num3;
				}
				else
				{
					num3 = -247418285;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ -247418277)
					{
					case 0:
						num3 = -247418280;
						continue;
					default:
						return;
					case 3:
						actionElementMaps.Add(list2[num2]);
						num2++;
						num3 = -247418276;
						continue;
					case 1:
						num3 = -247418273;
						continue;
					case 2:
						num5++;
						num3 = -247418273;
						continue;
					case 8:
						num5 = 0;
						num3 = -247418278;
						continue;
					case 7:
						break;
					case 6:
						actionElementMaps.Add(list[num5]);
						num3 = -247418279;
						continue;
					case 4:
					{
						int num6;
						if (num5 >= list.Count)
						{
							num3 = -247418274;
							num6 = num3;
						}
						else
						{
							num3 = -247418275;
							num6 = num3;
						}
						continue;
					}
					case 5:
						return;
					}
					break;
				}
			}
		}

		public void AddActionElementMap()
		{
			actionElementMaps.Add(cTtyCroGKEpRdoCIICOVJgzXlqHG());
		}

		public void InsertActionElementMap(int index)
		{
			if (index < 0)
			{
				goto IL_0034;
			}
			if (index >= actionElementMaps.Count)
			{
				goto IL_0012;
			}
			goto IL_0046;
			IL_0046:
			actionElementMaps.Insert(index, cTtyCroGKEpRdoCIICOVJgzXlqHG());
			int num = -1011897443;
			goto IL_0017;
			IL_0012:
			num = -1011897444;
			goto IL_0017;
			IL_0017:
			switch (num ^ -1011897443)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				goto IL_0034;
			case 3:
				goto IL_0046;
			case 0:
				return;
			}
			goto IL_0012;
			IL_0034:
			throw new ArgumentOutOfRangeException("index");
		}

		public void DeleteActionElementMap(int index)
		{
			if (actionElementMaps != null && index >= 0)
			{
				if (index < actionElementMaps.Count)
				{
					goto IL_004a;
				}
				while (true)
				{
					switch (-353304553 ^ -353304554)
					{
					case 0:
						break;
					case 1:
						goto end_IL_001a;
					default:
						goto IL_004a;
					}
					continue;
					end_IL_001a:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_004a:
			actionElementMaps.RemoveAt(index);
		}

		public bool ReorderActionElementMap(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(actionElementMaps, index, offsetDown, offsetNow);
		}

		public void DuplicateActionElementMap(int index)
		{
			if (actionElementMaps != null)
			{
				ActionElementMap item = default(ActionElementMap);
				while (true)
				{
					int num = -429287222;
					while (true)
					{
						switch (num ^ -429287217)
						{
						case 4:
							break;
						case 5:
							goto IL_0035;
						case 2:
							goto end_IL_0008;
						case 3:
							goto IL_006a;
						case 0:
							actionElementMaps.Add(item);
							return;
						default:
							actionElementMaps.Insert(index + 1, item);
							return;
						}
						break;
						IL_006a:
						item = new ActionElementMap(actionElementMaps[index]);
						int num2;
						if (index == actionElementMaps.Count - 1)
						{
							num = -429287217;
							num2 = num;
						}
						else
						{
							num = -429287218;
							num2 = num;
						}
						continue;
						IL_0035:
						if (index < 0)
						{
							goto end_IL_0008;
						}
						int num3;
						if (index < actionElementMaps.Count)
						{
							num = -429287220;
							num3 = num;
						}
						else
						{
							num = -429287219;
							num3 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		private ActionElementMap cTtyCroGKEpRdoCIICOVJgzXlqHG()
		{
			ActionElementMap actionElementMap = new ActionElementMap();
			actionElementMap.elementType = ControllerElementType.Button;
			return actionElementMap;
		}
	}
}
