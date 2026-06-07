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
		private sealed class MQLejZvcndcvfiHvBHEczoLxVhr : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public ControllerMap_Editor ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int cxajIdvHgWRVzXfSJnEbjHXsCoJi;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
				{
					goto IL_0012;
				}
				goto IL_004e;
				IL_0012:
				int num = -715338082;
				goto IL_0017;
				IL_0017:
				MQLejZvcndcvfiHvBHEczoLxVhr mQLejZvcndcvfiHvBHEczoLxVhr = default(MQLejZvcndcvfiHvBHEczoLxVhr);
				while (true)
				{
					switch (num ^ -715338081)
					{
					case 2:
						break;
					case 1:
						if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							mQLejZvcndcvfiHvBHEczoLxVhr = this;
							num = -715338084;
							continue;
						}
						goto IL_004e;
					case 0:
						goto IL_004e;
					default:
						return mQLejZvcndcvfiHvBHEczoLxVhr;
					}
					break;
				}
				goto IL_0012;
				IL_004e:
				mQLejZvcndcvfiHvBHEczoLxVhr = new MQLejZvcndcvfiHvBHEczoLxVhr(0);
				mQLejZvcndcvfiHvBHEczoLxVhr.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = -715338084;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 0:
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					int num2;
					if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionElementMaps == null)
					{
						num = -245709807;
						num2 = num;
					}
					else
					{
						num = -245709801;
						num2 = num;
					}
					goto IL_001f;
				}
				case 1:
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						cxajIdvHgWRVzXfSJnEbjHXsCoJi++;
						num = -245709808;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -245709805)
						{
						case 5:
							num = -245709806;
							continue;
						case 1:
							break;
						case 4:
							cxajIdvHgWRVzXfSJnEbjHXsCoJi = 0;
							num = -245709808;
							continue;
						case 3:
							goto IL_007a;
						case 0:
							RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionElementMaps[cxajIdvHgWRVzXfSJnEbjHXsCoJi];
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						default:
							goto end_IL_0008;
						}
						break;
						IL_007a:
						int num3;
						if (cxajIdvHgWRVzXfSJnEbjHXsCoJi < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.actionElementMaps.Count)
						{
							num = -245709805;
							num3 = num;
						}
						else
						{
							num = -245709807;
							num3 = num;
						}
					}
					goto case 0;
					end_IL_0008:
					break;
				}
				return false;
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
			public MQLejZvcndcvfiHvBHEczoLxVhr(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
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
				MQLejZvcndcvfiHvBHEczoLxVhr mQLejZvcndcvfiHvBHEczoLxVhr = new MQLejZvcndcvfiHvBHEczoLxVhr(-2);
				mQLejZvcndcvfiHvBHEczoLxVhr.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return mQLejZvcndcvfiHvBHEczoLxVhr;
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
			controllerMap_Editor.name = name;
			controllerMap_Editor.hardwareGuidString = hardwareGuidString;
			int num2 = default(int);
			while (true)
			{
				int num = 1081772177;
				while (true)
				{
					switch (num ^ 0x407A8892)
					{
					case 4:
						break;
					case 3:
						controllerMap_Editor.customControllerUid = customControllerUid;
						if (actionElementMaps != null)
						{
							controllerMap_Editor.actionElementMaps = new List<ActionElementMap>();
							num2 = 0;
							num = 1081772176;
							continue;
						}
						goto default;
					case 1:
						controllerMap_Editor.actionElementMaps.Add(new ActionElementMap(actionElementMaps[num2]));
						num2++;
						num = 1081772176;
						continue;
					case 2:
					{
						int num3;
						if (num2 < actionElementMaps.Count)
						{
							num = 1081772179;
							num3 = num;
						}
						else
						{
							num = 1081772178;
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
			if (index >= 0)
			{
				while (true)
				{
					int num = 844769622;
					while (true)
					{
						switch (num ^ 0x325A2957)
						{
						case 2:
							break;
						case 1:
							goto IL_0022;
						default:
							goto end_IL_0004;
						}
						break;
						IL_0022:
						if (index >= actionElementMaps.Count)
						{
							num = 844769623;
							continue;
						}
						return actionElementMaps[index];
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			return null;
		}

		internal JoystickMap kCAcOinlULTTujekMkLRQhDUTUQ(Func<int, bool> P_0, HardwareControllerMapIdentifier P_1, HardwareJoystickMap P_2, bool P_3)
		{
			JoystickMap joystickMap = new JoystickMap();
			kWENEYEuHyfQEFBPZTPTiBRGlsN(P_0, joystickMap, P_1, P_2, P_3);
			return joystickMap;
		}

		internal KeyboardMap ndoqsxdYVLcHLqznrKTfuEDIfGL(Func<int, bool> P_0)
		{
			KeyboardMap keyboardMap = new KeyboardMap();
			kWENEYEuHyfQEFBPZTPTiBRGlsN(P_0, keyboardMap, default(HardwareControllerMapIdentifier), null, false);
			return keyboardMap;
		}

		internal MouseMap krsRIxqaVDrrAMPqbGWejyVTGsP(Func<int, bool> P_0)
		{
			MouseMap mouseMap = new MouseMap();
			kWENEYEuHyfQEFBPZTPTiBRGlsN(P_0, mouseMap, default(HardwareControllerMapIdentifier), null, false);
			return mouseMap;
		}

		internal CustomControllerMap YKtMNhFjlLIOLjZPscrQaUFCTuE(Func<int, bool> P_0, CustomController_Editor P_1)
		{
			CustomControllerMap customControllerMap = new CustomControllerMap();
			dRxJEphAcMFSRHupIuiNUiVkpIyy(P_0, InputSource.Custom, customControllerMap, P_1);
			return customControllerMap;
		}

		internal ControllerTemplateMap tJImcqErHZwRyNYLzBIacCZByma()
		{
			IHardwareControllerTemplateMap_Internal hardwareControllerTemplateMap_Internal = ReInput.MWJmuxJUDhogOmPBQHfSBzzBXHM(hardwareGuid) as IHardwareControllerTemplateMap_Internal;
			if (hardwareControllerTemplateMap_Internal == null)
			{
				return null;
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(hardwareGuid, categoryId, layoutId, id);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num = -2128297279;
				while (true)
				{
					switch (num ^ -2128297275)
					{
					case 5:
						break;
					case 3:
					{
						int num4;
						if (actionElementMap == null)
						{
							num = -2128297277;
							num4 = num;
						}
						else
						{
							num = -2128297276;
							num4 = num;
						}
						continue;
					}
					case 2:
						actionElementMap = actionElementMaps[num2];
						num = -2128297274;
						continue;
					case 4:
						num3 = ((actionElementMaps != null) ? actionElementMaps.Count : 0);
						num2 = 0;
						num = -2128297275;
						continue;
					case 1:
						if (InputTools.IsMappableType(actionElementMap._elementType))
						{
							ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.rHXUBQoqejbkONabpWgwEqatBJ(actionElementMap);
							if (controllerTemplateActionElementMap != null)
							{
								controllerTemplateMap.AddElementMap(controllerTemplateActionElementMap);
								num = -2128297277;
								continue;
							}
						}
						goto case 6;
					case 6:
						num2++;
						num = -2128297275;
						continue;
					default:
						if (num2 >= num3)
						{
							return controllerTemplateMap;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		private void kWENEYEuHyfQEFBPZTPTiBRGlsN(Func<int, bool> P_0, ControllerMap P_1, HardwareControllerMapIdentifier P_2, HardwareJoystickMap P_3, bool P_4)
		{
			P_1.sourceMapId = id;
			ControllerElementIdentifier elementIdentifier = default(ControllerElementIdentifier);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num2 = default(int);
			ControllerElementType effectiveElementIdentifierType = default(ControllerElementType);
			while (true)
			{
				int num = 1669571318;
				while (true)
				{
					switch (num ^ 0x6383A2FD)
					{
					case 0:
						break;
					case 13:
						if (elementIdentifier.elementType == ControllerElementType.Button)
						{
							actionElementMap._axisRange = AxisRange.Positive;
							num = 1669571322;
							continue;
						}
						goto case 8;
					case 18:
						P_1.AddActionMapping_BeforeBake(actionElementMap);
						num = 1669571314;
						continue;
					case 3:
						throw new NotImplementedException();
					case 9:
						actionElementMap._invert = false;
						actionElementMap._axisRange = AxisRange.Full;
						num = 1669571313;
						continue;
					case 15:
						num2++;
						num = 1669571315;
						continue;
					case 4:
						actionElementMap._axisRange = AxisRange.Positive;
						num = 1669571322;
						continue;
					case 10:
						if (actionElementMap.axisContribution == Pole.Negative)
						{
							actionElementMap._axisRange = AxisRange.Negative;
							num = 1669571322;
							continue;
						}
						goto case 4;
					case 17:
						if (effectiveElementIdentifierType != ControllerElementType.Button)
						{
							goto case 3;
						}
						if (actionElementMap._axisRange == AxisRange.Full)
						{
							actionElementMap._axisContribution = (actionElementMap._invert ? Pole.Negative : Pole.Positive);
							num = 1669571316;
							continue;
						}
						goto case 9;
					case 7:
						actionElementMap._invert = false;
						num = 1669571309;
						continue;
					case 12:
						num = 1669571311;
						continue;
					case 16:
						num = 1669571311;
						continue;
					case 8:
					{
						AxisRange axisRange;
						if (P_3.GetEffectiveAxisRange(P_2, actionElementMaps[num2].elementIdentifierId, P_4, out axisRange))
						{
							actionElementMap._axisRange = axisRange;
							num = 1669571322;
							continue;
						}
						goto case 10;
					}
					case 5:
						num2 = 0;
						num = 1669571315;
						continue;
					case 11:
						P_1.categoryId = categoryId;
						num = 1669571324;
						continue;
					case 2:
						if (P_0(actionElementMaps[num2].actionId))
						{
							actionElementMap = new ActionElementMap(actionElementMaps[num2]);
							if (P_3 != null)
							{
								elementIdentifier = P_3.GetElementIdentifier(actionElementMaps[num2].elementIdentifierId);
								if (elementIdentifier != null)
								{
									effectiveElementIdentifierType = P_3.GetEffectiveElementIdentifierType(P_2, actionElementMaps[num2].elementIdentifierId, P_4);
									ControllerElementType elementType = elementIdentifier.elementType;
									int num4;
									if (effectiveElementIdentifierType != actionElementMaps[num2].elementType)
									{
										num = 1669571323;
										num4 = num;
									}
									else
									{
										num = 1669571311;
										num4 = num;
									}
									continue;
								}
							}
							goto case 18;
						}
						goto case 15;
					case 1:
						P_1.name = name;
						P_1.hardwareGuid = StringTools.ToGuid(hardwareGuidString);
						if (actionElementMaps == null)
						{
							return;
						}
						goto case 5;
					case 6:
					{
						actionElementMap._elementType = effectiveElementIdentifierType;
						int num3;
						if (effectiveElementIdentifierType != ControllerElementType.Axis)
						{
							num = 1669571308;
							num3 = num;
						}
						else
						{
							num = 1669571312;
							num3 = num;
						}
						continue;
					}
					default:
						if (num2 >= actionElementMaps.Count)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		private void dRxJEphAcMFSRHupIuiNUiVkpIyy(Func<int, bool> P_0, InputSource P_1, CustomControllerMap P_2, CustomController_Editor P_3)
		{
			P_2.sourceMapId = id;
			ActionElementMap actionElementMap = default(ActionElementMap);
			AxisRange axisRange = default(AxisRange);
			int num2 = default(int);
			ControllerElementType controllerElementType = default(ControllerElementType);
			ControllerElementIdentifier elementIdentifier = default(ControllerElementIdentifier);
			while (true)
			{
				int num = 1240793906;
				while (true)
				{
					switch (num ^ 0x49F50333)
					{
					case 11:
						break;
					case 24:
						actionElementMap.axisRange = axisRange;
						num = 1240793916;
						continue;
					case 22:
						num2 = 0;
						num = 1240793918;
						continue;
					case 15:
						actionElementMap.invert = false;
						num = 1240793917;
						continue;
					case 7:
						if (controllerElementType != ControllerElementType.Axis)
						{
							goto case 9;
						}
						if (elementIdentifier.elementType == ControllerElementType.Button)
						{
							actionElementMap.axisRange = AxisRange.Positive;
							num = 1240793916;
							continue;
						}
						goto case 4;
					case 19:
						actionElementMap.axisRange = AxisRange.Full;
						num = 1240793904;
						continue;
					case 5:
						actionElementMap.axisRange = AxisRange.Negative;
						num = 1240793916;
						continue;
					case 21:
					{
						int num4;
						if (elementIdentifier != null)
						{
							num = 1240793919;
							num4 = num;
						}
						else
						{
							num = 1240793917;
							num4 = num;
						}
						continue;
					}
					case 12:
					{
						controllerElementType = P_3.ItkSghdMnqxMWVEzfMJAkdmieon(actionElementMaps[num2].elementIdentifierId);
						ControllerElementType elementType = elementIdentifier.elementType;
						if (controllerElementType != actionElementMaps[num2].elementType)
						{
							actionElementMap.elementType = controllerElementType;
							num = 1240793908;
							continue;
						}
						goto case 14;
					}
					case 18:
						throw new NotImplementedException();
					case 9:
					{
						int num7;
						if (controllerElementType != ControllerElementType.Button)
						{
							num = 1240793889;
							num7 = num;
						}
						else
						{
							num = 1240793895;
							num7 = num;
						}
						continue;
					}
					case 16:
						actionElementMap.axisRange = AxisRange.Positive;
						num = 1240793916;
						continue;
					case 8:
						num2++;
						num = 1240793913;
						continue;
					case 0:
						if (!P_0(actionElementMaps[num2].actionId))
						{
							goto case 8;
						}
						actionElementMap = new ActionElementMap(actionElementMaps[num2]);
						if (P_3 != null)
						{
							elementIdentifier = P_3.GetElementIdentifier(actionElementMaps[num2].elementIdentifierId);
							num = 1240793894;
							continue;
						}
						goto case 14;
					case 3:
						num = 1240793917;
						continue;
					case 17:
					{
						P_2.name = name;
						P_2.sourceControllerId = customControllerUid;
						int num6;
						if (actionElementMaps == null)
						{
							num = 1240793905;
							num6 = num;
						}
						else
						{
							num = 1240793893;
							num6 = num;
						}
						continue;
					}
					case 14:
						P_2.AddActionMapping_BeforeBake(actionElementMap);
						num = 1240793915;
						continue;
					case 6:
					{
						int num5;
						if (actionElementMap.axisContribution == Pole.Negative)
						{
							num = 1240793910;
							num5 = num;
						}
						else
						{
							num = 1240793891;
							num5 = num;
						}
						continue;
					}
					case 13:
						num = 1240793913;
						continue;
					case 20:
						if (actionElementMap.axisRange == AxisRange.Full)
						{
							actionElementMap.axisContribution = (actionElementMap.invert ? Pole.Negative : Pole.Positive);
							num = 1240793892;
							continue;
						}
						goto case 23;
					case 23:
						actionElementMap.invert = false;
						num = 1240793888;
						continue;
					case 2:
						return;
					case 4:
					{
						int num3;
						if (P_3.EfyHKDjALBdxNBXzNJhGqlShqPla(actionElementMaps[num2].elementIdentifierId, out axisRange))
						{
							num = 1240793899;
							num3 = num;
						}
						else
						{
							num = 1240793909;
							num3 = num;
						}
						continue;
					}
					case 1:
						P_2.categoryId = categoryId;
						num = 1240793890;
						continue;
					default:
						if (num2 >= actionElementMaps.Count)
						{
							return;
						}
						goto case 0;
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
				while (enumerator.MoveNext())
				{
					while (true)
					{
						IControllerElementIdentifierCommon_Internal current = enumerator.Current;
						int num2;
						int num3;
						if (!InputTools.IsMappableControllerElementType(current.elementType))
						{
							num2 = -1070932735;
							num3 = num2;
						}
						else
						{
							num2 = -1070932734;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -1070932733)
							{
							case 0:
								num2 = -1070932736;
								continue;
							case 3:
								break;
							case 1:
							{
								ActionElementMap item = new ActionElementMap(-1, KVNLqybISELdZVRJeMgGCnyHIcv.GbAArqJlIQEtJddnaipTXTcVclHP(current.elementType), current.id);
								actionElementMaps.Add(item);
								num++;
								num2 = -1070932735;
								continue;
							}
							default:
								goto end_IL_003b;
							}
							break;
						}
						continue;
						end_IL_003b:
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
			ControllerElementIdentifier current = default(ControllerElementIdentifier);
			ActionElementMap item = default(ActionElementMap);
			int num6 = default(int);
			while (true)
			{
				List<ActionElementMap> list = new List<ActionElementMap>();
				List<ActionElementMap> list2 = new List<ActionElementMap>();
				int num = -1112692793;
				while (true)
				{
					switch (num ^ -1112692794)
					{
					case 0:
						goto IL_0004;
					case 2:
						break;
					default:
					{
						using (IEnumerator<ControllerElementIdentifier> enumerator = customController.ElementIdentifiers.GetEnumerator())
						{
							while (true)
							{
								IL_00eb:
								int num2;
								int num3;
								if (enumerator.MoveNext())
								{
									num2 = -1112692795;
									num3 = num2;
								}
								else
								{
									num2 = -1112692799;
									num3 = num2;
								}
								while (true)
								{
									switch (num2 ^ -1112692794)
									{
									case 8:
										num2 = -1112692795;
										continue;
									default:
										goto end_IL_004c;
									case 2:
										throw new NotImplementedException();
									case 5:
										num2 = -1112692800;
										continue;
									case 0:
										if (current.elementType == ControllerElementType.Button)
										{
											list.Add(item);
											num2 = -1112692800;
											continue;
										}
										goto case 2;
									case 4:
									{
										item = new ActionElementMap(-1, current.elementType, current.id);
										int num4;
										if (current.elementType == ControllerElementType.Axis)
										{
											num2 = -1112692793;
											num4 = num2;
										}
										else
										{
											num2 = -1112692794;
											num4 = num2;
										}
										continue;
									}
									case 1:
										list2.Add(item);
										num2 = -1112692797;
										continue;
									case 6:
										break;
									case 3:
										current = enumerator.Current;
										num2 = -1112692798;
										continue;
									case 7:
										goto end_IL_004c;
									}
									goto IL_00eb;
									continue;
									end_IL_004c:
									break;
								}
								break;
							}
						}
						int num5 = 0;
						while (true)
						{
							int num7;
							if (num5 >= list2.Count)
							{
								num6 = 0;
								num7 = -1112692795;
								goto IL_0132;
							}
							goto IL_0192;
							IL_0132:
							while (true)
							{
								switch (num7 ^ -1112692794)
								{
								case 0:
									num7 = -1112692797;
									continue;
								case 4:
									actionElementMaps.Add(list[num6]);
									num6++;
									num7 = -1112692793;
									continue;
								case 2:
									break;
								case 3:
									num7 = -1112692793;
									continue;
								case 5:
									goto IL_0192;
								default:
									if (num6 >= list.Count)
									{
										return;
									}
									goto case 4;
								}
								break;
							}
							continue;
							IL_0192:
							actionElementMaps.Add(list2[num5]);
							num5++;
							num7 = -1112692796;
							goto IL_0132;
						}
					}
					}
					break;
					IL_0004:
					num = -1112692796;
				}
			}
		}

		public void AddActionElementMap()
		{
			actionElementMaps.Add(XmnnwwMnHOMfaRzSVxhIiRqWpEm());
		}

		public void InsertActionElementMap(int index)
		{
			if (index >= 0)
			{
				if (index < actionElementMaps.Count)
				{
					goto IL_0042;
				}
				while (true)
				{
					switch (0x78C32851 ^ 0x78C32850)
					{
					case 2:
						break;
					case 1:
						goto end_IL_0012;
					default:
						goto IL_0042;
					}
					continue;
					end_IL_0012:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_0042:
			actionElementMaps.Insert(index, XmnnwwMnHOMfaRzSVxhIiRqWpEm());
		}

		public void DeleteActionElementMap(int index)
		{
			if (actionElementMaps != null)
			{
				while (true)
				{
					int num = -1001797984;
					while (true)
					{
						switch (num ^ -1001797982)
						{
						case 0:
							break;
						case 2:
							goto IL_002a;
						case 1:
							goto end_IL_0008;
						default:
							actionElementMaps.RemoveAt(index);
							return;
						}
						break;
						IL_002a:
						if (index < 0)
						{
							goto end_IL_0008;
						}
						int num2;
						if (index < actionElementMaps.Count)
						{
							num = -1001797983;
							num2 = num;
						}
						else
						{
							num = -1001797981;
							num2 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public bool ReorderActionElementMap(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(actionElementMaps, index, offsetDown, offsetNow);
		}

		public void DuplicateActionElementMap(int index)
		{
			if (actionElementMaps != null && index >= 0)
			{
				if (index < actionElementMaps.Count)
				{
					goto IL_004e;
				}
				while (true)
				{
					switch (0x6AA4254F ^ 0x6AA4254E)
					{
					case 3:
						break;
					case 1:
						goto end_IL_001a;
					case 2:
						goto IL_004e;
					default:
						goto IL_0084;
					}
					continue;
					end_IL_001a:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_0084:
			ActionElementMap item = default(ActionElementMap);
			actionElementMaps.Insert(index + 1, item);
			return;
			IL_004e:
			item = new ActionElementMap(actionElementMaps[index]);
			if (index == actionElementMaps.Count - 1)
			{
				actionElementMaps.Add(item);
				return;
			}
			goto IL_0084;
		}

		private ActionElementMap XmnnwwMnHOMfaRzSVxhIiRqWpEm()
		{
			ActionElementMap actionElementMap = new ActionElementMap();
			actionElementMap.elementType = ControllerElementType.Button;
			return actionElementMap;
		}
	}
}
