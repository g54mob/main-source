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
		private sealed class rmFfKYFudtPtCEiwzUGcQoRviYk : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public ControllerMap_Editor iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int JgkqHoXbaGSqSpATxoAvQPPuCvQ;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				rmFfKYFudtPtCEiwzUGcQoRviYk rmFfKYFudtPtCEiwzUGcQoRviYk2;
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
					rmFfKYFudtPtCEiwzUGcQoRviYk2 = this;
				}
				else
				{
					while (true)
					{
						rmFfKYFudtPtCEiwzUGcQoRviYk2 = new rmFfKYFudtPtCEiwzUGcQoRviYk(0);
						rmFfKYFudtPtCEiwzUGcQoRviYk2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						int num = 1251538543;
						while (true)
						{
							switch (num ^ 0x4A98F66E)
							{
							case 0:
								num = 1251538540;
								continue;
							case 2:
								break;
							default:
								goto end_IL_0045;
							}
							break;
						}
						continue;
						end_IL_0045:
						break;
					}
				}
				return rmFfKYFudtPtCEiwzUGcQoRviYk2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
				while (true)
				{
					int num2 = -457883478;
					while (true)
					{
						switch (num2 ^ -457883473)
						{
						case 2:
							break;
						case 5:
							switch (num)
							{
							default:
								num2 = -457883479;
								continue;
							case 1:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								JgkqHoXbaGSqSpATxoAvQPPuCvQ++;
								num2 = -457883480;
								continue;
							case 0:
								break;
							}
							goto case 0;
						case 1:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							return true;
						case 9:
							JgkqHoXbaGSqSpATxoAvQPPuCvQ = 0;
							num2 = -457883481;
							continue;
						case 4:
						{
							int num4;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actionElementMaps == null)
							{
								num2 = -457883479;
								num4 = num2;
							}
							else
							{
								num2 = -457883482;
								num4 = num2;
							}
							continue;
						}
						case 7:
						{
							int num3;
							if (JgkqHoXbaGSqSpATxoAvQPPuCvQ >= iKQXbXnVtIaMZEJNeigQJWAHqUx.actionElementMaps.Count)
							{
								num2 = -457883479;
								num3 = num2;
							}
							else
							{
								num2 = -457883476;
								num3 = num2;
							}
							continue;
						}
						case 3:
							aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.actionElementMaps[JgkqHoXbaGSqSpATxoAvQPPuCvQ];
							num2 = -457883474;
							continue;
						case 8:
							num2 = -457883480;
							continue;
						case 0:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							num2 = -457883477;
							continue;
						default:
							return false;
						}
						break;
					}
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
			public rmFfKYFudtPtCEiwzUGcQoRviYk(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
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
				rmFfKYFudtPtCEiwzUGcQoRviYk rmFfKYFudtPtCEiwzUGcQoRviYk2 = new rmFfKYFudtPtCEiwzUGcQoRviYk(-2);
				rmFfKYFudtPtCEiwzUGcQoRviYk2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return rmFfKYFudtPtCEiwzUGcQoRviYk2;
			}
		}

		public Guid hardwareGuid
		{
			get
			{
				return StringTools.ToGuid(hardwareGuidString);
			}
		}

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
			int num2 = default(int);
			while (true)
			{
				int num = -365817376;
				while (true)
				{
					switch (num ^ -365817371)
					{
					case 2:
						break;
					case 1:
						num = -365817374;
						continue;
					case 4:
						controllerMap_Editor.customControllerUid = customControllerUid;
						if (actionElementMaps != null)
						{
							controllerMap_Editor.actionElementMaps = new List<ActionElementMap>();
							num2 = 0;
							num = -365817372;
							continue;
						}
						goto default;
					case 6:
						controllerMap_Editor.actionElementMaps.Add(new ActionElementMap(actionElementMaps[num2]));
						num = -365817370;
						continue;
					case 5:
						controllerMap_Editor.name = name;
						controllerMap_Editor.hardwareGuidString = hardwareGuidString;
						num = -365817375;
						continue;
					case 3:
						num2++;
						num = -365817374;
						continue;
					case 7:
					{
						int num3;
						if (num2 >= actionElementMaps.Count)
						{
							num = -365817371;
							num3 = num;
						}
						else
						{
							num = -365817373;
							num3 = num;
						}
						continue;
					}
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

		internal JoystickMap TyUTxlDNKLwRFZInoPVPjtZOZoL(Func<int, bool> P_0, HardwareControllerMapIdentifier P_1, HardwareJoystickMap P_2, bool P_3)
		{
			JoystickMap joystickMap = new JoystickMap();
			while (true)
			{
				int num = 337026794;
				while (true)
				{
					switch (num ^ 0x14169EE8)
					{
					case 0:
						break;
					case 2:
						goto IL_0024;
					default:
						return joystickMap;
					}
					break;
					IL_0024:
					FBOEnJucvmQAxhIxjRxTRPyKeDK(P_0, joystickMap, P_1, P_2, P_3);
					num = 337026793;
				}
			}
		}

		internal KeyboardMap SdulnsJvJXcicAJaRRIxFADCpHO(Func<int, bool> P_0)
		{
			KeyboardMap keyboardMap = new KeyboardMap();
			FBOEnJucvmQAxhIxjRxTRPyKeDK(P_0, keyboardMap, default(HardwareControllerMapIdentifier), null, false);
			return keyboardMap;
		}

		internal MouseMap ZuyHHsYuJPhMvykrNfAaAsRJVhK(Func<int, bool> P_0)
		{
			MouseMap mouseMap = new MouseMap();
			FBOEnJucvmQAxhIxjRxTRPyKeDK(P_0, mouseMap, default(HardwareControllerMapIdentifier), null, false);
			return mouseMap;
		}

		internal CustomControllerMap tWxTCuxQtTvCiNyEQtHSPhPKIKL(Func<int, bool> P_0, CustomController_Editor P_1)
		{
			CustomControllerMap customControllerMap = new CustomControllerMap();
			while (true)
			{
				int num = 343447386;
				while (true)
				{
					switch (num ^ 0x14789758)
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
					IRjODmJcqADnuKUkyMgZgJVwRXhh(P_0, InputSource.Custom, customControllerMap, P_1);
					num = 343447385;
				}
			}
		}

		internal ControllerTemplateMap GaAHbtiqBLdJLjtKRuPwZbTDYbv()
		{
			IHardwareControllerTemplateMap_Internal hardwareControllerTemplateMap_Internal = ReInput.tHBHtolwXhpDjQmEcGjECOnZjMBA(hardwareGuid) as IHardwareControllerTemplateMap_Internal;
			if (hardwareControllerTemplateMap_Internal == null)
			{
				return null;
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(hardwareGuid, categoryId, layoutId, id);
			if (actionElementMaps == null)
			{
				goto IL_003c;
			}
			int num = actionElementMaps.Count;
			goto IL_00c1;
			IL_00c1:
			int num2 = num;
			int num3 = 0;
			int num4 = 1247439555;
			goto IL_0041;
			IL_00b3:
			num = 0;
			goto IL_00c1;
			IL_003c:
			num4 = 1247439559;
			goto IL_0041;
			IL_0041:
			ControllerTemplateActionElementMap controllerTemplateActionElementMap = default(ControllerTemplateActionElementMap);
			while (true)
			{
				ActionElementMap actionElementMap;
				switch (num4 ^ 0x4A5A6AC6)
				{
				case 2:
					break;
				case 3:
					controllerTemplateMap.AddElementMap(controllerTemplateActionElementMap);
					num4 = 1247439554;
					continue;
				case 0:
					actionElementMap = actionElementMaps[num3];
					if (actionElementMap != null && InputTools.IsMappableType(actionElementMap._elementType))
					{
						goto IL_0095;
					}
					goto case 4;
				case 1:
					goto IL_00b3;
				case 4:
					num3++;
					num4 = 1247439555;
					continue;
				default:
					if (num3 >= num2)
					{
						return controllerTemplateMap;
					}
					goto case 0;
				}
				break;
				IL_0095:
				controllerTemplateActionElementMap = ControllerTemplateActionElementMap.MdLShCgeucAqBomYFlMaHVWokJC(actionElementMap);
				int num5;
				if (controllerTemplateActionElementMap != null)
				{
					num4 = 1247439557;
					num5 = num4;
				}
				else
				{
					num4 = 1247439554;
					num5 = num4;
				}
			}
			goto IL_003c;
		}

		private void FBOEnJucvmQAxhIxjRxTRPyKeDK(Func<int, bool> P_0, ControllerMap P_1, HardwareControllerMapIdentifier P_2, HardwareJoystickMap P_3, bool P_4)
		{
			P_1.sourceMapId = id;
			P_1.categoryId = categoryId;
			P_1.name = name;
			ControllerElementType effectiveElementIdentifierType = default(ControllerElementType);
			ActionElementMap actionElementMap = default(ActionElementMap);
			ControllerElementIdentifier elementIdentifier = default(ControllerElementIdentifier);
			int num2 = default(int);
			while (true)
			{
				int num = 1663767430;
				while (true)
				{
					switch (num ^ 0x632B138E)
					{
					case 11:
						break;
					case 9:
						num = 1663767452;
						continue;
					case 16:
						if (effectiveElementIdentifierType != ControllerElementType.Button)
						{
							goto case 5;
						}
						if (actionElementMap._axisRange == AxisRange.Full)
						{
							actionElementMap._axisContribution = (actionElementMap._invert ? Pole.Negative : Pole.Positive);
							num = 1663767425;
							continue;
						}
						goto case 15;
					case 6:
						if (P_3 != null)
						{
							elementIdentifier = P_3.GetElementIdentifier(actionElementMaps[num2].elementIdentifierId);
							if (elementIdentifier != null)
							{
								effectiveElementIdentifierType = P_3.GetEffectiveElementIdentifierType(P_2, actionElementMaps[num2].elementIdentifierId, P_4);
								ControllerElementType elementType = elementIdentifier.elementType;
								if (effectiveElementIdentifierType != actionElementMaps[num2].elementType)
								{
									actionElementMap._elementType = effectiveElementIdentifierType;
									num = 1663767438;
									continue;
								}
							}
						}
						goto case 18;
					case 8:
						P_1.hardwareGuid = StringTools.ToGuid(hardwareGuidString);
						if (actionElementMaps == null)
						{
							return;
						}
						goto case 10;
					case 7:
						actionElementMap._axisRange = AxisRange.Positive;
						num = 1663767436;
						continue;
					case 19:
						num2++;
						num = 1663767434;
						continue;
					case 3:
						num = 1663767452;
						continue;
					case 14:
						actionElementMap._axisRange = AxisRange.Full;
						num = 1663767437;
						continue;
					case 12:
						actionElementMap = new ActionElementMap(actionElementMaps[num2]);
						num = 1663767432;
						continue;
					case 13:
					{
						int num3;
						if (P_0(actionElementMaps[num2].actionId))
						{
							num = 1663767426;
							num3 = num;
						}
						else
						{
							num = 1663767453;
							num3 = num;
						}
						continue;
					}
					case 17:
					{
						AxisRange axisRange;
						if (P_3.GetEffectiveAxisRange(P_2, actionElementMaps[num2].elementIdentifierId, P_4, out axisRange))
						{
							actionElementMap._axisRange = axisRange;
							num = 1663767436;
							continue;
						}
						goto case 1;
					}
					case 1:
						if (actionElementMap.axisContribution == Pole.Negative)
						{
							actionElementMap._axisRange = AxisRange.Negative;
							num = 1663767436;
							continue;
						}
						goto case 7;
					case 0:
						if (effectiveElementIdentifierType != ControllerElementType.Axis)
						{
							goto case 16;
						}
						if (elementIdentifier.elementType == ControllerElementType.Button)
						{
							actionElementMap._axisRange = AxisRange.Positive;
							num = 1663767436;
							continue;
						}
						goto case 17;
					case 10:
						num2 = 0;
						num = 1663767434;
						continue;
					case 5:
						throw new NotImplementedException();
					case 15:
						actionElementMap._invert = false;
						num = 1663767424;
						continue;
					case 18:
						P_1.AddActionMapping_BeforeBake(actionElementMap);
						num = 1663767453;
						continue;
					case 2:
						actionElementMap._invert = false;
						num = 1663767431;
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

		private void IRjODmJcqADnuKUkyMgZgJVwRXhh(Func<int, bool> P_0, InputSource P_1, CustomControllerMap P_2, CustomController_Editor P_3)
		{
			P_2.sourceMapId = id;
			P_2.categoryId = categoryId;
			ControllerElementType controllerElementType = default(ControllerElementType);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num2 = default(int);
			ControllerElementIdentifier elementIdentifier = default(ControllerElementIdentifier);
			AxisRange axisRange = default(AxisRange);
			while (true)
			{
				int num = -1088338087;
				while (true)
				{
					switch (num ^ -1088338097)
					{
					case 14:
						break;
					case 21:
						if (controllerElementType != ControllerElementType.Button)
						{
							goto case 11;
						}
						if (actionElementMap.axisRange == AxisRange.Full)
						{
							actionElementMap.axisContribution = (actionElementMap.invert ? Pole.Negative : Pole.Positive);
							num = -1088338109;
							continue;
						}
						goto case 12;
					case 4:
						num = -1088338105;
						continue;
					case 20:
					{
						int num4;
						if (controllerElementType != actionElementMaps[num2].elementType)
						{
							num = -1088338102;
							num4 = num;
						}
						else
						{
							num = -1088338105;
							num4 = num;
						}
						continue;
					}
					case 7:
						num = -1088338112;
						continue;
					case 3:
						if (actionElementMap.axisContribution == Pole.Negative)
						{
							actionElementMap.axisRange = AxisRange.Negative;
							num = -1088338106;
							continue;
						}
						goto case 0;
					case 16:
						num = -1088338106;
						continue;
					case 22:
						P_2.name = name;
						P_2.sourceControllerId = customControllerUid;
						num = -1088338107;
						continue;
					case 11:
						throw new NotImplementedException();
					case 1:
						if (P_3 != null)
						{
							elementIdentifier = P_3.GetElementIdentifier(actionElementMaps[num2].elementIdentifierId);
							int num5;
							if (elementIdentifier != null)
							{
								num = -1088338084;
								num5 = num;
							}
							else
							{
								num = -1088338105;
								num5 = num;
							}
							continue;
						}
						goto case 8;
					case 0:
						actionElementMap.axisRange = AxisRange.Positive;
						num = -1088338106;
						continue;
					case 10:
						if (actionElementMaps == null)
						{
							return;
						}
						goto case 13;
					case 17:
						if (P_0(actionElementMaps[num2].actionId))
						{
							actionElementMap = new ActionElementMap(actionElementMaps[num2]);
							num = -1088338098;
							continue;
						}
						goto case 2;
					case 13:
						num2 = 0;
						num = -1088338104;
						continue;
					case 6:
						actionElementMap.axisRange = axisRange;
						num = -1088338081;
						continue;
					case 9:
						actionElementMap.invert = false;
						num = -1088338101;
						continue;
					case 2:
						num2++;
						num = -1088338112;
						continue;
					case 8:
						P_2.AddActionMapping_BeforeBake(actionElementMap);
						num = -1088338099;
						continue;
					case 19:
					{
						controllerElementType = P_3.nPiClkKTjgGtnbhecTFAsHefaluP(actionElementMaps[num2].elementIdentifierId);
						ControllerElementType elementType = elementIdentifier.elementType;
						num = -1088338085;
						continue;
					}
					case 18:
					{
						int num3;
						if (P_3.fEwMNGJEXLDKgbjybglSRKStSQuf(actionElementMaps[num2].elementIdentifierId, out axisRange))
						{
							num = -1088338103;
							num3 = num;
						}
						else
						{
							num = -1088338100;
							num3 = num;
						}
						continue;
					}
					case 12:
						actionElementMap.invert = false;
						actionElementMap.axisRange = AxisRange.Full;
						num = -1088338105;
						continue;
					case 5:
						actionElementMap.elementType = controllerElementType;
						if (controllerElementType != ControllerElementType.Axis)
						{
							goto case 21;
						}
						if (elementIdentifier.elementType == ControllerElementType.Button)
						{
							actionElementMap.axisRange = AxisRange.Positive;
							num = -1088338106;
							continue;
						}
						goto case 18;
					default:
						if (num2 >= actionElementMaps.Count)
						{
							return;
						}
						goto case 17;
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
			while (true)
			{
				int num = 0;
				int num2 = 1724281348;
				while (true)
				{
					switch (num2 ^ 0x66C67204)
					{
					case 2:
						goto IL_0004;
					case 1:
						break;
					default:
					{
						IEnumerator<IControllerElementIdentifierCommon_Internal> enumerator = (hardwareJoystickMap as IHardwareControllerMap_Internal).ElementIdentifiers.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								while (true)
								{
									IControllerElementIdentifierCommon_Internal current = enumerator.Current;
									int num3 = 1724281351;
									while (true)
									{
										switch (num3 ^ 0x66C67204)
										{
										case 0:
											num3 = 1724281350;
											continue;
										case 2:
											break;
										case 3:
											if (InputTools.IsMappableControllerElementType(current.elementType))
											{
												ActionElementMap item = new ActionElementMap(-1, jHLGlrXjGMMIuxAEONcGlnwHltw.dESgFzzjUASSsXqyQnTPkfkTyAG(current.elementType), current.id);
												actionElementMaps.Add(item);
												num3 = 1724281344;
												continue;
											}
											goto end_IL_0064;
										case 4:
											num++;
											num3 = 1724281349;
											continue;
										default:
											goto end_IL_0064;
										}
										break;
									}
									continue;
									end_IL_0064:
									break;
								}
							}
							return;
						}
						finally
						{
							if (enumerator != null)
							{
								while (true)
								{
									IL_00c2:
									int num4 = 1724281349;
									while (true)
									{
										switch (num4 ^ 0x66C67204)
										{
										case 0:
											break;
										default:
											goto end_IL_00c7;
										case 1:
											goto IL_00e0;
										case 2:
											goto end_IL_00c7;
										}
										goto IL_00c2;
										IL_00e0:
										enumerator.Dispose();
										num4 = 1724281350;
										continue;
										end_IL_00c7:
										break;
									}
									break;
								}
							}
						}
					}
					}
					break;
					IL_0004:
					num2 = 1724281349;
				}
			}
		}

		public void CreateElementsFromHardwareMap(CustomController_Editor customController)
		{
			if (customController == null)
			{
				while (true)
				{
					switch (-1444801392 ^ -1444801391)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			List<ActionElementMap> list = new List<ActionElementMap>();
			List<ActionElementMap> list2 = new List<ActionElementMap>();
			IEnumerator<ControllerElementIdentifier> enumerator = customController.ElementIdentifiers.GetEnumerator();
			try
			{
				ControllerElementIdentifier current = default(ControllerElementIdentifier);
				ActionElementMap item = default(ActionElementMap);
				while (true)
				{
					IL_009e:
					int num;
					int num2;
					if (enumerator.MoveNext())
					{
						num = -1444801386;
						num2 = num;
					}
					else
					{
						num = -1444801387;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1444801391)
						{
						case 0:
							num = -1444801386;
							continue;
						default:
							goto end_IL_0049;
						case 7:
							current = enumerator.Current;
							num = -1444801390;
							continue;
						case 1:
							if (current.elementType == ControllerElementType.Axis)
							{
								list2.Add(item);
								num = -1444801388;
								continue;
							}
							goto case 2;
						case 5:
							break;
						case 6:
							throw new NotImplementedException();
						case 3:
							item = new ActionElementMap(-1, current.elementType, current.id);
							num = -1444801392;
							continue;
						case 2:
							if (current.elementType == ControllerElementType.Button)
							{
								list.Add(item);
								num = -1444801388;
								continue;
							}
							goto case 6;
						case 4:
							goto end_IL_0049;
						}
						goto IL_009e;
						continue;
						end_IL_0049:
						break;
					}
					break;
				}
			}
			finally
			{
				if (enumerator != null)
				{
					while (true)
					{
						IL_0102:
						int num3 = -1444801392;
						while (true)
						{
							switch (num3 ^ -1444801391)
							{
							case 0:
								break;
							default:
								goto end_IL_0107;
							case 1:
								goto IL_0120;
							case 2:
								goto end_IL_0107;
							}
							goto IL_0102;
							IL_0120:
							enumerator.Dispose();
							num3 = -1444801389;
							continue;
							end_IL_0107:
							break;
						}
						break;
					}
				}
			}
			int num4 = 0;
			int num6 = default(int);
			while (true)
			{
				int num5 = -1444801392;
				while (true)
				{
					switch (num5 ^ -1444801391)
					{
					case 0:
						break;
					case 2:
						if (num4 >= list2.Count)
						{
							num6 = 0;
							num5 = -1444801390;
							continue;
						}
						goto case 4;
					case 4:
						actionElementMaps.Add(list2[num4]);
						num4++;
						num5 = -1444801389;
						continue;
					case 5:
						actionElementMaps.Add(list[num6]);
						num6++;
						num5 = -1444801390;
						continue;
					case 1:
						num5 = -1444801389;
						continue;
					default:
						if (num6 >= list.Count)
						{
							return;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		public void AddActionElementMap()
		{
			actionElementMaps.Add(gQxuyvidnCtEHpexhfCSHDLCgKb());
		}

		public void InsertActionElementMap(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = -1143230774;
					while (true)
					{
						switch (num ^ -1143230773)
						{
						case 2:
							break;
						case 1:
							goto IL_0026;
						case 3:
							goto end_IL_0004;
						default:
							actionElementMaps.Insert(index, gQxuyvidnCtEHpexhfCSHDLCgKb());
							return;
						}
						break;
						IL_0026:
						int num2;
						if (index >= actionElementMaps.Count)
						{
							num = -1143230776;
							num2 = num;
						}
						else
						{
							num = -1143230773;
							num2 = num;
						}
					}
					continue;
					end_IL_0004:
					break;
				}
			}
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
					switch (0x270490 ^ 0x270492)
					{
					case 0:
						break;
					case 2:
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
			if (actionElementMaps != null && index >= 0)
			{
				ActionElementMap item = default(ActionElementMap);
				while (true)
				{
					int num = -345370195;
					while (true)
					{
						switch (num ^ -345370199)
						{
						case 6:
							break;
						default:
							return;
						case 3:
							if (index == actionElementMaps.Count - 1)
							{
								actionElementMaps.Add(item);
								return;
							}
							goto case 0;
						case 1:
							item = new ActionElementMap(actionElementMaps[index]);
							num = -345370198;
							continue;
						case 2:
							goto end_IL_000c;
						case 4:
							goto IL_008c;
						case 0:
							actionElementMaps.Insert(index + 1, item);
							num = -345370196;
							continue;
						case 5:
							return;
						}
						break;
						IL_008c:
						int num2;
						if (index >= actionElementMaps.Count)
						{
							num = -345370197;
							num2 = num;
						}
						else
						{
							num = -345370200;
							num2 = num;
						}
					}
					continue;
					end_IL_000c:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		private ActionElementMap gQxuyvidnCtEHpexhfCSHDLCgKb()
		{
			ActionElementMap actionElementMap = new ActionElementMap();
			actionElementMap.elementType = ControllerElementType.Button;
			return actionElementMap;
		}
	}
}
