using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class HardwareJoystickMap : ScriptableObject, IHardwareControllerMap, IHardwareControllerMap_Internal
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Platform : IDeepCloneable
		{
			private sealed class pKPwNQbsEqdjnjcVEbFNkORvCbrh : IDisposable, IEnumerator, IEnumerable<Platform>, IEnumerator<Platform>, IEnumerable
			{
				private Platform RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public IList<Platform> VdzAnpgfVEARlSlOCMJnXHYiFPgT;

				public int qTFEIHicfdaGbjDisSQLDXnpmPS;

				Platform IEnumerator<Platform>.Current
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
				IEnumerator<Platform> IEnumerable<Platform>.GetEnumerator()
				{
					pKPwNQbsEqdjnjcVEbFNkORvCbrh pKPwNQbsEqdjnjcVEbFNkORvCbrh2;
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						pKPwNQbsEqdjnjcVEbFNkORvCbrh2 = this;
					}
					else
					{
						while (true)
						{
							pKPwNQbsEqdjnjcVEbFNkORvCbrh2 = new pKPwNQbsEqdjnjcVEbFNkORvCbrh(0);
							pKPwNQbsEqdjnjcVEbFNkORvCbrh2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
							int num = -1280587315;
							while (true)
							{
								switch (num ^ -1280587316)
								{
								case 0:
									num = -1280587314;
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
					return pKPwNQbsEqdjnjcVEbFNkORvCbrh2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 0:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						VdzAnpgfVEARlSlOCMJnXHYiFPgT = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.variants_base;
						if (VdzAnpgfVEARlSlOCMJnXHYiFPgT == null)
						{
							break;
						}
						qTFEIHicfdaGbjDisSQLDXnpmPS = 0;
						num = 483264781;
						goto IL_001f;
					case 1:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							num = 483264780;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x1CCE090A)
							{
							case 3:
								num = 483264779;
								continue;
							case 1:
								break;
							case 6:
								qTFEIHicfdaGbjDisSQLDXnpmPS++;
								num = 483264776;
								continue;
							case 2:
								goto IL_0095;
							case 7:
								num = 483264776;
								continue;
							case 5:
								RDkWcsTpvDaNZojjIZONnoEBXPC = VdzAnpgfVEARlSlOCMJnXHYiFPgT[qTFEIHicfdaGbjDisSQLDXnpmPS];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							case 0:
								goto IL_00f7;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00f7:
							int num2;
							if (VdzAnpgfVEARlSlOCMJnXHYiFPgT[qTFEIHicfdaGbjDisSQLDXnpmPS] == null)
							{
								num = 483264780;
								num2 = num;
							}
							else
							{
								num = 483264783;
								num2 = num;
							}
							continue;
							IL_0095:
							int num3;
							if (qTFEIHicfdaGbjDisSQLDXnpmPS < VdzAnpgfVEARlSlOCMJnXHYiFPgT.Count)
							{
								num = 483264778;
								num3 = num;
							}
							else
							{
								num = 483264782;
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
				public pKPwNQbsEqdjnjcVEbFNkORvCbrh(int _003C_003E1__state)
				{
					while (true)
					{
						int num = -764089983;
						while (true)
						{
							switch (num ^ -764089984)
							{
							case 0:
								break;
							case 1:
								goto IL_0024;
							default:
								iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
								return;
							}
							break;
							IL_0024:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
							num = -764089982;
						}
					}
				}
			}

			public string description;

			internal abstract InputPlatform platform { get; }

			public abstract int assignedButtonCount { get; }

			public abstract int assignedAxisCount { get; }

			internal abstract Elements_Base elements_base { get; }

			internal virtual bool isAllowed
			{
				get
				{
					if (!disabled)
					{
						if (assignedButtonCount <= 0)
						{
							return assignedAxisCount > 0;
						}
						return true;
					}
					return false;
				}
			}

			internal abstract bool hasData { get; }

			internal abstract bool disabled { get; }

			internal abstract IList<Platform> variants_base { get; }

			internal IEnumerable<Platform> Variants
			{
				get
				{
					pKPwNQbsEqdjnjcVEbFNkORvCbrh pKPwNQbsEqdjnjcVEbFNkORvCbrh2 = new pKPwNQbsEqdjnjcVEbFNkORvCbrh(-2);
					pKPwNQbsEqdjnjcVEbFNkORvCbrh2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return pKPwNQbsEqdjnjcVEbFNkORvCbrh2;
				}
			}

			internal bool hasVariants
			{
				get
				{
					return variantCount > 0;
				}
			}

			[CustomObfuscation(rename = false)]
			internal int variantCount
			{
				get
				{
					if (variants_base == null)
					{
						return 0;
					}
					return variants_base.Count;
				}
			}

			internal bool selfOrVariantHasData
			{
				get
				{
					if (hasData)
					{
						return true;
					}
					foreach (Platform variant in Variants)
					{
						if (variant.hasData)
						{
							return true;
						}
					}
					return false;
				}
			}

			internal bool selfOrVariantIsValid
			{
				get
				{
					if (!selfOrVariantHasData)
					{
						return false;
					}
					if (isAllowed && hasData)
					{
						return true;
					}
					foreach (Platform variant in Variants)
					{
						if (variant.isAllowed && variant.hasData)
						{
							return true;
						}
					}
					return false;
				}
			}

			internal bool selfOrVariantIsAllowed
			{
				get
				{
					if (isAllowed)
					{
						return true;
					}
					using (IEnumerator<Platform> enumerator = Variants.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							while (true)
							{
								Platform current = enumerator.Current;
								int num = 688676558;
								while (true)
								{
									switch (num ^ 0x290C5ECF)
									{
									case 4:
										num = 688676556;
										continue;
									case 2:
										return true;
									case 1:
										break;
									case 3:
										goto end_IL_001d;
									default:
										goto end_IL_0062;
									}
									int num2;
									if (!current.isAllowed)
									{
										num = 688676559;
										num2 = num;
									}
									else
									{
										num = 688676557;
										num2 = num;
									}
									continue;
									end_IL_001d:
									break;
								}
								continue;
								end_IL_0062:
								break;
							}
						}
					}
					return false;
				}
			}

			internal abstract bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap);

			internal abstract string[] GetAxisNames(ControllerElementIdentifier[] identifiers);

			internal abstract string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers);

			internal abstract void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes);

			internal abstract bool IsElementIdentifierMapped(int elementIdentifierId);

			internal Platform GetFirstValidPlatformMap(out int variantIndex)
			{
				variantIndex = -1;
				if (!selfOrVariantIsValid)
				{
					goto IL_000e;
				}
				IList<Platform> list = default(IList<Platform>);
				int num;
				if (!isAllowed || !hasData)
				{
					list = variants_base;
					num = -2039617071;
				}
				else
				{
					num = -2039617067;
				}
				goto IL_0013;
				IL_0013:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ -2039617065)
					{
					case 4:
						break;
					case 7:
					{
						Platform platform = list[num2];
						if (platform != null && platform.isAllowed && platform.hasData)
						{
							variantIndex = num2;
							return platform;
						}
						num2++;
						num = -2039617070;
						continue;
					}
					case 3:
						num2 = 0;
						num = -2039617070;
						continue;
					case 6:
					{
						int num4;
						if (list != null)
						{
							num = -2039617068;
							num4 = num;
						}
						else
						{
							num = -2039617065;
							num4 = num;
						}
						continue;
					}
					case 2:
						variantIndex = -1;
						return this;
					case 5:
					{
						int num3;
						if (num2 < list.Count)
						{
							num = -2039617072;
							num3 = num;
						}
						else
						{
							num = -2039617065;
							num3 = num;
						}
						continue;
					}
					case 1:
						return null;
					default:
						return null;
					}
					break;
				}
				goto IL_000e;
				IL_000e:
				num = -2039617066;
				goto IL_0013;
			}

			internal int IndexOfElementIdentifier(ControllerElementIdentifier[] elementIdentifiers, int id)
			{
				if (elementIdentifiers == null)
				{
					return -1;
				}
				int num = 0;
				while (true)
				{
					int num2 = 866212109;
					while (true)
					{
						switch (num2 ^ 0x33A1590C)
						{
						case 0:
							break;
						case 1:
							num2 = 866212111;
							continue;
						case 2:
							if (elementIdentifiers[num].id == id)
							{
								return num;
							}
							num++;
							num2 = 866212111;
							continue;
						default:
							if (num >= elementIdentifiers.Length)
							{
								return -1;
							}
							goto case 2;
						}
						break;
					}
				}
			}

			internal abstract AxisCalibrationData[] GetAxisCalibrationData();

			internal abstract void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos);

			internal abstract void GetButtonData(out HardwareButtonInfo[] buttonInfos);

			internal abstract ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier);

			internal abstract bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange);

			internal Platform GetPlatformMap(int variantIndex)
			{
				if (variantIndex < 0)
				{
					goto IL_0004;
				}
				int num;
				if (!hasVariants)
				{
					num = 1237526978;
					goto IL_0009;
				}
				IList<Platform> list = variants_base;
				if (variantCount <= variantIndex)
				{
					return null;
				}
				return list[variantIndex];
				IL_0009:
				switch (num ^ 0x49C329C0)
				{
				case 0:
					break;
				case 1:
					return this;
				default:
					return null;
				}
				goto IL_0004;
				IL_0004:
				num = 1237526977;
				goto IL_0009;
			}

			internal HardwareJoystickMap_InputManager ToHardwareJoystickMap_InputManager(HardwareJoystickMap hardwareJoystickMap, InputSource inputSource, InputPlatform actualInputPlatform, int variantIndex)
			{
				if (hardwareJoystickMap == null)
				{
					goto IL_000c;
				}
				Platform platform = MiscTools.DeepClone(this);
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = new HardwareJoystickMap_InputManager(new HardwareControllerMapIdentifier(hardwareJoystickMap.Guid, inputSource, actualInputPlatform, variantIndex), hardwareJoystickMap.joystickTypes, platform, hardwareJoystickMap.controllerName, platform.assignedButtonCount, platform.assignedAxisCount, hardwareJoystickMap.elementIdentifiers.Length, hardwareJoystickMap.compoundElements);
				int num = 485617620;
				goto IL_0011;
				IL_0011:
				int num4 = default(int);
				int num2 = default(int);
				int num3 = default(int);
				ControllerElementIdentifier[] elementIdentifiers = default(ControllerElementIdentifier[]);
				int elementIdentifierCount = default(int);
				while (true)
				{
					switch (num ^ 0x1CF1EFF1)
					{
					case 33:
						break;
					case 15:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "cross button";
						num = 485617658;
						continue;
					case 42:
						goto IL_0102;
					case 3:
						goto IL_011f;
					case 39:
						num2 = 0;
						num = 485617617;
						continue;
					case 4:
						goto IL_0149;
					case 24:
						num = 485617658;
						continue;
					case 22:
						goto IL_0170;
					case 23:
						goto IL_018d;
					case 47:
						goto IL_01aa;
					case 18:
						goto IL_01ed;
					case 35:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].positiveName = hardwareJoystickMap_InputManager.elementIdentifiers[num2].name + " +";
						num = 485617629;
						continue;
					case 0:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3] = new ControllerElementIdentifier(elementIdentifiers[num3], hardwareJoystickMap_InputManager.map.IsElementIdentifierMapped(elementIdentifiers[num3].id), hardwareJoystickMap_InputManager.map.GetEffectiveElementIdentifierType(elementIdentifiers[num3]));
						num3++;
						num = 485617640;
						continue;
					case 26:
						goto IL_027f;
					case 19:
						goto IL_029c;
					case 21:
						goto IL_02b9;
					case 25:
					{
						int num8;
						if (num3 >= elementIdentifierCount)
						{
							num = 485617642;
							num8 = num;
						}
						else
						{
							num = 485617649;
							num8 = num;
						}
						continue;
					}
					case 34:
						num2++;
						num = 485617617;
						continue;
					case 30:
						if (hardwareJoystickMap_InputManager.elementIdentifiers[num2].elementType == ControllerElementType.Axis)
						{
							int num7;
							if (string.IsNullOrEmpty(hardwareJoystickMap_InputManager.elementIdentifiers[num2].positiveName))
							{
								num = 485617618;
								num7 = num;
							}
							else
							{
								num = 485617629;
								num7 = num;
							}
							continue;
						}
						goto case 34;
					case 16:
						goto IL_0338;
					case 7:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].negativeName = hardwareJoystickMap_InputManager.elementIdentifiers[num2].name + " -";
						num = 485617619;
						continue;
					case 48:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].negativeName = "left stick left";
						num = 485617658;
						continue;
					case 13:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].positiveName = "left stick right";
						num = 485617601;
						continue;
					case 27:
						if (inputSource == InputSource.PS4 && hardwareJoystickMap.Guid == Consts.joystickGuid_SonyDualShock4)
						{
							num4 = 0;
							num = 485617624;
							continue;
						}
						goto case 39;
					case 1:
						goto IL_03e9;
					case 44:
					{
						int num6;
						if (string.IsNullOrEmpty(hardwareJoystickMap_InputManager.elementIdentifiers[num2].negativeName))
						{
							num = 485617654;
							num6 = num;
						}
						else
						{
							num = 485617619;
							num6 = num;
						}
						continue;
					}
					case 10:
						goto IL_042f;
					case 40:
						switch (elementIdentifiers[num4].id)
						{
						case 6:
							break;
						case 0:
							goto IL_0102;
						case 9:
							goto IL_011f;
						case 18:
							goto IL_0149;
						case 16:
							goto IL_0170;
						case 15:
							goto IL_018d;
						case 1:
							goto IL_01aa;
						case 20:
							goto IL_01ed;
						case 12:
							goto IL_027f;
						case 21:
							goto IL_029c;
						case 8:
							goto IL_02b9;
						case 13:
							goto IL_0338;
						case 4:
							goto IL_03e9;
						case 5:
							goto IL_042f;
						default:
							goto IL_04c9;
						case 7:
							goto IL_04d3;
						case 14:
							goto IL_050a;
						case 10:
							goto IL_05a3;
						case 11:
							goto IL_05e5;
						case 3:
							goto IL_0602;
						case 19:
							goto IL_0645;
						case 2:
							goto IL_06b0;
						case 17:
							goto IL_06e0;
						}
						goto case 15;
					case 5:
						goto IL_04d3;
					case 12:
						num = 485617658;
						continue;
					case 11:
						num4++;
						num = 485617624;
						continue;
					case 38:
						goto IL_050a;
					case 6:
						num = 485617658;
						continue;
					case 41:
					{
						int num5;
						if (num4 < elementIdentifierCount)
						{
							num = 485617625;
							num5 = num;
						}
						else
						{
							num = 485617622;
							num5 = num;
						}
						continue;
					}
					case 28:
						num = 485617658;
						continue;
					case 29:
						return null;
					case 31:
						goto IL_05a3;
					case 20:
						num = 485617640;
						continue;
					case 37:
						elementIdentifiers = hardwareJoystickMap.elementIdentifiers;
						elementIdentifierCount = hardwareJoystickMap.elementIdentifierCount;
						num3 = 0;
						num = 485617637;
						continue;
					case 14:
						goto IL_05e5;
					case 17:
						goto IL_0602;
					case 43:
						goto IL_0645;
					case 8:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].negativeName = "right stick left";
						num = 485617645;
						continue;
					case 36:
						num = 485617658;
						continue;
					case 45:
						num = 485617658;
						continue;
					case 2:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].positiveName = "L2 button";
						num = 485617658;
						continue;
					case 9:
						goto IL_06b0;
					case 46:
						goto IL_06e0;
					default:
						{
							if (num2 >= elementIdentifierCount)
							{
								return hardwareJoystickMap_InputManager;
							}
							goto case 30;
						}
						IL_01ed:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "down button";
						num = 485617655;
						continue;
						IL_06e0:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "R3 button";
						num = 485617658;
						continue;
						IL_06b0:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "right stick x";
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].positiveName = "right stick right";
						num = 485617657;
						continue;
						IL_0645:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "right button";
						num = 485617658;
						continue;
						IL_0602:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "right stick y";
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].positiveName = "right stick up";
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].negativeName = "right stick down";
						num = 485617658;
						continue;
						IL_05e5:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "R1 button";
						num = 485617621;
						continue;
						IL_05a3:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "L1 button";
						num = 485617658;
						continue;
						IL_050a:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "PS button";
						num = 485617658;
						continue;
						IL_04d3:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "circle button";
						num = 485617658;
						continue;
						IL_04c9:
						num = 485617658;
						continue;
						IL_042f:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "R2 button";
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].positiveName = "R2 button";
						num = 485617641;
						continue;
						IL_01aa:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "left stick y";
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].positiveName = "left stick up";
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].negativeName = "left stick down";
						num = 485617658;
						continue;
						IL_018d:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "touch pad button";
						num = 485617658;
						continue;
						IL_03e9:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "L2 button";
						num = 485617651;
						continue;
						IL_0170:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "L3 button";
						num = 485617661;
						continue;
						IL_0338:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "OPTIONS button";
						num = 485617658;
						continue;
						IL_0149:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "up button";
						num = 485617658;
						continue;
						IL_011f:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "triangle button";
						num = 485617658;
						continue;
						IL_0102:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "left stick x";
						num = 485617660;
						continue;
						IL_02b9:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "square button";
						num = 485617628;
						continue;
						IL_029c:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "left button";
						num = 485617658;
						continue;
						IL_027f:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4].name = "SHARE button";
						num = 485617658;
						continue;
					}
					break;
				}
				goto IL_000c;
				IL_000c:
				num = 485617644;
				goto IL_0011;
			}

			public abstract object DeepClone();

			internal abstract void CopyVars(Platform destination);
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Elements_Base : IDeepCloneable
		{
			public abstract int buttonCount { get; }

			public abstract int axisCount { get; }

			internal virtual void CopyVars(Elements_Base destination)
			{
			}

			internal abstract ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier);

			internal abstract bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange);

			public abstract object DeepClone();
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class MatchingCriteria_Base : IDeepCloneable
		{
			[Serializable]
			public class ElementCount_Base : IDeepCloneable
			{
				public int axisCount;

				public int buttonCount;

				public virtual object DeepClone()
				{
					ElementCount_Base elementCount_Base = new ElementCount_Base();
					CopyVars(elementCount_Base);
					return elementCount_Base;
				}

				internal virtual void CopyVars(ElementCount_Base P_0)
				{
					if (P_0 == null)
					{
						while (true)
						{
							switch (0x6E94442 ^ 0x6E94443)
							{
							case 0:
								continue;
							case 1:
								return;
							}
							break;
						}
					}
					P_0.axisCount = axisCount;
					P_0.buttonCount = buttonCount;
				}

				internal virtual bool Matches(BridgedControllerHWInfo P_0)
				{
					if (P_0 == null)
					{
						goto IL_0003;
					}
					int num;
					if (axisCount >= 0)
					{
						if (axisCount == P_0.hardwareAxisCount)
						{
							num = -1675700425;
							goto IL_0008;
						}
						return false;
					}
					goto IL_0045;
					IL_0008:
					switch (num ^ -1675700425)
					{
					case 3:
						break;
					case 1:
						return false;
					case 0:
						goto IL_0045;
					default:
						return buttonCount == P_0.hardwareButtonCount;
					}
					goto IL_0003;
					IL_0003:
					num = -1675700426;
					goto IL_0008;
					IL_0045:
					if (buttonCount >= 0)
					{
						num = -1675700427;
						goto IL_0008;
					}
					return true;
				}
			}

			public int axisCount;

			public int buttonCount;

			public bool disabled;

			public string tag;

			internal abstract bool hasData { get; }

			internal virtual bool isAllowed
			{
				get
				{
					if (disabled)
					{
						return false;
					}
					return true;
				}
			}

			internal abstract int alternateElementCount { get; }

			internal virtual bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch)
			{
				if (disabled)
				{
					return false;
				}
				if (!isAllowed)
				{
					goto IL_0012;
				}
				bool alternateMatched;
				if (!ElementCountsMatch(BridgedControllerHWInfo, out alternateMatched))
				{
					return false;
				}
				int num;
				if (!string.IsNullOrEmpty(BridgedControllerHWInfo.definitionMatchTag))
				{
					num = -968438887;
					goto IL_0017;
				}
				goto IL_0069;
				IL_0012:
				num = -968438886;
				goto IL_0017;
				IL_0017:
				switch (num ^ -968438888)
				{
				case 0:
					break;
				case 2:
					return false;
				default:
					goto IL_0053;
				}
				goto IL_0012;
				IL_0053:
				if (!BridgedControllerHWInfo.definitionMatchTag.Equals(tag, StringComparison.OrdinalIgnoreCase))
				{
					return false;
				}
				goto IL_0069;
				IL_0069:
				return true;
			}

			internal abstract ElementCount_Base GetAlternateElementCount(int index);

			internal virtual bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
			{
				alternateMatched = false;
				if (bridgedControllerHWInfo == null)
				{
					return false;
				}
				int num = alternateElementCount;
				ElementCount_Base elementCount_Base = default(ElementCount_Base);
				int num3 = default(int);
				while (true)
				{
					int num2 = -479865254;
					while (true)
					{
						switch (num2 ^ -479865252)
						{
						case 9:
							break;
						case 10:
							if (axisCount == bridgedControllerHWInfo.hardwareAxisCount)
							{
								num2 = -479865250;
								continue;
							}
							return false;
						case 1:
							return true;
						case 4:
							elementCount_Base = GetAlternateElementCount(num3);
							num2 = -479865252;
							continue;
						case 8:
						{
							int num5;
							if (axisCount >= 0)
							{
								num2 = -479865258;
								num5 = num2;
							}
							else
							{
								num2 = -479865250;
								num5 = num2;
							}
							continue;
						}
						case 0:
							if (elementCount_Base == null || !elementCount_Base.Matches(bridgedControllerHWInfo))
							{
								num3++;
								num2 = -479865253;
							}
							else
							{
								num2 = -479865249;
							}
							continue;
						case 7:
						{
							int num4;
							if (num3 >= num)
							{
								num2 = -479865260;
								num4 = num2;
							}
							else
							{
								num2 = -479865256;
								num4 = num2;
							}
							continue;
						}
						case 3:
							alternateMatched = true;
							num2 = -479865251;
							continue;
						case 2:
							if (buttonCount >= 0)
							{
								num2 = -479865255;
								continue;
							}
							return true;
						case 6:
							num3 = 0;
							num2 = -479865253;
							continue;
						default:
							return buttonCount == bridgedControllerHWInfo.hardwareButtonCount;
						}
						break;
					}
				}
			}

			internal virtual void CopyVars(MatchingCriteria_Base destination)
			{
				destination.axisCount = axisCount;
				destination.buttonCount = buttonCount;
				destination.disabled = disabled;
				destination.tag = tag;
			}

			internal static bool StringMatches(string searchIn, string searchFor, bool useRegex)
			{
				if (searchIn == null)
				{
					goto IL_0003;
				}
				goto IL_0045;
				IL_0003:
				int num = -787671591;
				goto IL_0008;
				IL_0008:
				while (true)
				{
					switch (num ^ -787671590)
					{
					case 0:
						break;
					case 3:
						searchIn = string.Empty;
						num = -787671592;
						continue;
					case 4:
						searchFor = string.Empty;
						num = -787671589;
						continue;
					case 2:
						goto IL_0045;
					default:
						goto IL_0059;
					}
					break;
				}
				goto IL_0003;
				IL_0045:
				int num2;
				if (searchFor != null)
				{
					num = -787671589;
					num2 = num;
				}
				else
				{
					num = -787671586;
					num2 = num;
				}
				goto IL_0008;
				IL_0059:
				if (useRegex)
				{
					return Regex.IsMatch(searchIn, searchFor, RegexOptions.IgnoreCase);
				}
				return searchFor.Trim().Equals(searchIn.Trim(), StringComparison.OrdinalIgnoreCase);
			}

			public abstract object DeepClone();
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class CompoundElement : IDeepCloneable
		{
			public CompoundControllerElementType type;

			public int elementIdentifier = -1;

			public int[] componentElementIdentifiers = new int[0];

			public int elementCount
			{
				get
				{
					if (componentElementIdentifiers == null)
					{
						return 0;
					}
					return componentElementIdentifiers.Length;
				}
			}

			public CompoundElement()
			{
				while (true)
				{
					int num = 147443775;
					while (true)
					{
						switch (num ^ 0x8C9D03E)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							if (componentElementIdentifiers == null)
							{
								goto IL_003f;
							}
							return;
						case 0:
							return;
						}
						break;
						IL_003f:
						componentElementIdentifiers = new int[0];
						num = 147443774;
					}
				}
			}

			public CompoundElement(CompoundElement original)
			{
				ImportVars(original);
			}

			public int GetComponentElementIdentifierId(int index)
			{
				if (index < 0 || index >= elementCount)
				{
					return -1;
				}
				return componentElementIdentifiers[index];
			}

			public virtual object DeepClone()
			{
				return new CompoundElement(this);
			}

			protected virtual void ImportVars(CompoundElement source)
			{
				type = source.type;
				elementIdentifier = source.elementIdentifier;
				componentElementIdentifiers = ArrayTools.ShallowCopy(source.componentElementIdentifiers);
			}

			internal static void SortHatElementsClockwise(CompoundElement element)
			{
				if (element == null)
				{
					goto IL_0006;
				}
				goto IL_009d;
				IL_0006:
				int num = -1009975103;
				goto IL_000b;
				IL_000b:
				int[] array = default(int[]);
				while (true)
				{
					switch (num ^ -1009975099)
					{
					case 7:
						break;
					default:
						return;
					case 1:
						array = new int[8]
						{
							element.componentElementIdentifiers[0],
							element.componentElementIdentifiers[4],
							element.componentElementIdentifiers[1],
							element.componentElementIdentifiers[5],
							element.componentElementIdentifiers[2],
							element.componentElementIdentifiers[6],
							element.componentElementIdentifiers[3],
							0
						};
						num = -1009975104;
						continue;
					case 8:
						goto IL_009d;
					case 4:
						return;
					case 0:
						if (element.componentElementIdentifiers.Length != 8)
						{
							return;
						}
						goto case 1;
					case 6:
						return;
					case 2:
						goto IL_00e1;
					case 5:
						array[7] = element.componentElementIdentifiers[7];
						Array.Copy(array, element.componentElementIdentifiers, array.Length);
						num = -1009975098;
						continue;
					case 3:
						return;
					}
					break;
				}
				goto IL_0006;
				IL_009d:
				if (element.type != CompoundControllerElementType.Hat)
				{
					return;
				}
				goto IL_00e1;
				IL_00e1:
				int num2;
				if (element.componentElementIdentifiers == null)
				{
					num = -1009975101;
					num2 = num;
				}
				else
				{
					num = -1009975099;
					num2 = num;
				}
				goto IL_000b;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class VidPid
		{
			public int vendorId;

			public int productId;
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class AxisCalibrationInfoEntry : IDeepCloneable
		{
			[SerializeField]
			internal AlternateAxisCalibrationType key;

			[SerializeField]
			internal AxisCalibrationInfo calibration;

			public AxisCalibrationInfoEntry(AxisCalibrationInfoEntry original)
			{
				ImportVars(original);
			}

			public virtual object DeepClone()
			{
				return new AxisCalibrationInfoEntry(this);
			}

			protected virtual void ImportVars(AxisCalibrationInfoEntry source)
			{
				key = source.key;
				calibration = MiscTools.DeepClone(source.calibration);
			}

			public static Dictionary<int, AxisCalibrationInfo> ToDictionary(AxisCalibrationInfoEntry[] calibrations, bool deepClone)
			{
				if (calibrations == null)
				{
					goto IL_0006;
				}
				Dictionary<int, AxisCalibrationInfo> dictionary = new Dictionary<int, AxisCalibrationInfo>();
				int num = 0;
				int num2 = 71311457;
				goto IL_000b;
				IL_000b:
				AxisCalibrationInfoEntry axisCalibrationInfoEntry = default(AxisCalibrationInfoEntry);
				while (true)
				{
					switch (num2 ^ 0x4402060)
					{
					case 7:
						break;
					case 6:
						num2 = 71311460;
						continue;
					case 1:
						num2 = 71311458;
						continue;
					case 0:
						if (dictionary.ContainsKey((int)axisCalibrationInfoEntry.key))
						{
							Logger.LogError("A duplicate key was found in AxisCalibrationInfoEntry array in HardwareJoystickMap. Skipping.");
							num2 = 71311460;
							continue;
						}
						goto case 3;
					case 9:
						axisCalibrationInfoEntry = calibrations[num];
						if (axisCalibrationInfoEntry != null && axisCalibrationInfoEntry.calibration != null)
						{
							int num3;
							if (Enum.IsDefined(typeof(AlternateAxisCalibrationType), axisCalibrationInfoEntry.key))
							{
								num2 = 71311456;
								num3 = num2;
							}
							else
							{
								num2 = 71311460;
								num3 = num2;
							}
							continue;
						}
						goto case 4;
					case 8:
						dictionary.Add((int)axisCalibrationInfoEntry.key, axisCalibrationInfoEntry.calibration);
						num2 = 71311460;
						continue;
					case 3:
						if (deepClone)
						{
							dictionary.Add((int)axisCalibrationInfoEntry.key, (AxisCalibrationInfo)axisCalibrationInfoEntry.calibration.DeepClone());
							num2 = 71311462;
							continue;
						}
						goto case 8;
					case 4:
						num++;
						num2 = 71311458;
						continue;
					case 5:
						return new Dictionary<int, AxisCalibrationInfo>();
					default:
						if (num >= calibrations.Length)
						{
							return dictionary;
						}
						goto case 9;
					}
					break;
				}
				goto IL_0006;
				IL_0006:
				num2 = 71311461;
				goto IL_000b;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Platform_RawOrDirectInput : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				[Serializable]
				public sealed class ElementCount : ElementCount_Base
				{
					public int hatCount;

					public override object DeepClone()
					{
						ElementCount elementCount = new ElementCount();
						CopyVars(elementCount);
						return elementCount;
					}

					internal override void CopyVars(ElementCount_Base P_0)
					{
						base.CopyVars(P_0);
						ElementCount elementCount = P_0 as ElementCount;
						if (elementCount == null)
						{
							return;
						}
						while (true)
						{
							elementCount.hatCount = hatCount;
							int num = 155502890;
							while (true)
							{
								switch (num ^ 0x944C92B)
								{
								case 0:
									goto IL_0012;
								default:
									return;
								case 2:
									break;
								case 1:
									return;
								}
								break;
								IL_0012:
								num = 155502889;
							}
						}
					}

					internal override bool Matches(BridgedControllerHWInfo P_0)
					{
						if (!base.Matches(P_0))
						{
							goto IL_0009;
						}
						int num;
						if (hatCount >= 0)
						{
							num = -298779405;
							goto IL_000e;
						}
						return true;
						IL_0009:
						num = -298779406;
						goto IL_000e;
						IL_000e:
						switch (num ^ -298779405)
						{
						case 2:
							break;
						case 1:
							return false;
						default:
							return hatCount == P_0.hardwareHatCount;
						}
						goto IL_0009;
					}
				}

				public int hatCount;

				public ElementCount[] alternateElementCounts;

				public bool productName_useRegex;

				public string[] productName;

				public string[] productGUID;

				public int[] productId;

				public DeviceType deviceType;

				internal override bool hasData
				{
					get
					{
						if (disabled)
						{
							goto IL_0008;
						}
						int num;
						if (productGUID != null)
						{
							num = 980115941;
							goto IL_000d;
						}
						goto IL_004c;
						IL_006f:
						return false;
						IL_004c:
						if (productName != null)
						{
							num = 980115939;
							goto IL_000d;
						}
						goto IL_006f;
						IL_0008:
						num = 980115938;
						goto IL_000d;
						IL_000d:
						while (true)
						{
							switch (num ^ 0x3A6B61E1)
							{
							case 0:
								break;
							case 3:
								return false;
							case 4:
								goto IL_003f;
							case 2:
								goto IL_005b;
							default:
								return true;
							}
							break;
							IL_005b:
							if (productName.Length > 0)
							{
								num = 980115936;
								continue;
							}
							goto IL_006f;
						}
						goto IL_0008;
						IL_003f:
						if (productGUID.Length > 0)
						{
							return true;
						}
						goto IL_004c;
					}
				}

				internal override bool isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						return true;
					}
				}

				internal override int alternateElementCount
				{
					get
					{
						if (alternateElementCounts == null)
						{
							return 0;
						}
						return alternateElementCounts.Length;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					bool flag = default(bool);
					int num;
					if (strictMatch)
					{
						if (PidVid.ArrayContains(productGUID, ref bridgedControllerHWInfo.hw_pidVid))
						{
							goto IL_003f;
						}
						flag = ProductNameMatches(bridgedControllerHWInfo);
						num = -1425057974;
						goto IL_0044;
					}
					return ProductNameMatches(bridgedControllerHWInfo);
					IL_003f:
					num = -1425057973;
					goto IL_0044;
					IL_0044:
					while (true)
					{
						switch (num ^ -1425057974)
						{
						case 2:
							break;
						case 0:
							if (!flag)
							{
								num = -1425057975;
								continue;
							}
							return true;
						case 4:
							return true;
						case 1:
							if (!ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
							{
								return true;
							}
							if (productName != null)
							{
								if (productName.Length != 0)
								{
									return ProductNameMatches(bridgedControllerHWInfo);
								}
								num = -1425057970;
								continue;
							}
							goto case 4;
						default:
							return false;
						}
						break;
					}
					goto IL_003f;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					if (alternateElementCounts != null && index >= 0)
					{
						while (true)
						{
							int num = -1503016846;
							while (true)
							{
								switch (num ^ -1503016845)
								{
								case 0:
									break;
								case 1:
									goto IL_002a;
								default:
									goto end_IL_000c;
								}
								break;
								IL_002a:
								if (index >= alternateElementCounts.Length)
								{
									num = -1503016847;
									continue;
								}
								return alternateElementCounts[index];
							}
							continue;
							end_IL_000c:
							break;
						}
					}
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						return false;
					}
					if (alternateMatched)
					{
						return true;
					}
					if (hatCount >= 0)
					{
						return bridgedControllerHWInfo.hardwareHatCount == hatCount;
					}
					return true;
				}

				private bool ProductNameMatches(BridgedControllerHWInfo controller)
				{
					if (controller.hw_isBluetoothDevice && !string.IsNullOrEmpty(controller.hw_bluetoothDeviceName))
					{
						while (true)
						{
							int num = 1956190550;
							while (true)
							{
								switch (num ^ 0x74991957)
								{
								case 0:
									break;
								case 1:
									if (!ProductNameMatches(controller.hw_productName))
									{
										if (ProductNameMatches(controller.hw_bluetoothDeviceName))
										{
											goto IL_004f;
										}
										return false;
									}
									goto default;
								default:
									return true;
								}
								break;
								IL_004f:
								num = 1956190549;
							}
						}
					}
					return ProductNameMatches(controller.hw_productName);
				}

				private bool ProductNameMatches(string name)
				{
					string searchIn = default(string);
					int num;
					if (!string.IsNullOrEmpty(name))
					{
						if (productName == null)
						{
							goto IL_0010;
						}
						searchIn = name.Trim();
						num = 1906474478;
						goto IL_0015;
					}
					goto IL_003a;
					IL_0015:
					int num2 = default(int);
					while (true)
					{
						switch (num ^ 0x71A27DEE)
						{
						case 5:
							break;
						case 1:
							goto IL_003a;
						case 3:
							goto IL_004a;
						case 0:
							num2 = 0;
							num = 1906474476;
							continue;
						case 4:
							goto IL_0076;
						default:
							if (num2 >= productName.Length)
							{
								return false;
							}
							goto IL_0076;
						}
						break;
						IL_0076:
						if (productName[num2] != null && !(productName[num2] == string.Empty))
						{
							num = 1906474477;
							continue;
						}
						goto IL_0062;
						IL_004a:
						if (MatchingCriteria_Base.StringMatches(searchIn, productName[num2], productName_useRegex))
						{
							return true;
						}
						goto IL_0062;
						IL_0062:
						num2++;
						num = 1906474476;
					}
					goto IL_0010;
					IL_003a:
					return false;
					IL_0010:
					num = 1906474479;
					goto IL_0015;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					MatchingCriteria matchingCriteria = destination as MatchingCriteria;
					while (true)
					{
						int num = -867185693;
						while (true)
						{
							switch (num ^ -867185695)
							{
							case 4:
								break;
							default:
								return;
							case 2:
							{
								int num2;
								if (matchingCriteria != null)
								{
									num = -867185695;
									num2 = num;
								}
								else
								{
									num = -867185692;
									num2 = num;
								}
								continue;
							}
							case 5:
								return;
							case 3:
								matchingCriteria.productName_useRegex = productName_useRegex;
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
								matchingCriteria.productId = ArrayTools.ShallowCopy(productId);
								matchingCriteria.deviceType = deviceType;
								num = -867185696;
								continue;
							case 0:
								matchingCriteria.hatCount = hatCount;
								num = -867185694;
								continue;
							case 1:
								return;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Elements_Platform_Base : Elements_Base
			{
				internal abstract IEnumerable<Axis_Base> Axes { get; }

				internal abstract IEnumerable<Button_Base> Buttons { get; }

				internal abstract Axis_Base GetAxis(int axisIndex);
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class CustomCalculationSourceData : IDeepCloneable
			{
				public int sourceType;

				public int sourceAxis;

				public int sourceButton;

				public int sourceOtherAxis;

				public AxisRange sourceAxisRange;

				public float axisDeadZone;

				public bool invert;

				public AxisCalibrationType axisCalibrationType;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public object DeepClone()
				{
					CustomCalculationSourceData customCalculationSourceData = new CustomCalculationSourceData();
					customCalculationSourceData.sourceType = sourceType;
					while (true)
					{
						int num = 422954525;
						while (true)
						{
							switch (num ^ 0x1935C61F)
							{
							case 0:
								break;
							case 2:
								customCalculationSourceData.sourceAxis = sourceAxis;
								customCalculationSourceData.sourceButton = sourceButton;
								customCalculationSourceData.sourceOtherAxis = sourceOtherAxis;
								customCalculationSourceData.sourceAxisRange = sourceAxisRange;
								customCalculationSourceData.axisDeadZone = axisDeadZone;
								customCalculationSourceData.invert = invert;
								customCalculationSourceData.axisCalibrationType = axisCalibrationType;
								num = 422954524;
								continue;
							case 3:
								customCalculationSourceData.axisZero = axisZero;
								customCalculationSourceData.axisMin = axisMin;
								num = 422954526;
								continue;
							default:
								customCalculationSourceData.axisMax = axisMax;
								return customCalculationSourceData;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Element : IDeepCloneable
			{
				public CustomCalculation customCalculation;

				public CustomCalculationSourceData[] customCalculationSourceData;

				public abstract object DeepClone();

				protected void ImportVars(Element source)
				{
					customCalculation = source.customCalculation;
					customCalculationSourceData = ArrayTools.DeepClone(source.customCalculationSourceData);
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Button_Base : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceButton;

				public int sourceAxis;

				public Pole sourceAxisPole;

				public float axisDeadZone;

				public int sourceHat;

				public HatType sourceHatType;

				public HatDirection sourceHatDirection;

				public bool requireMultipleButtons;

				public int[] requiredButtons;

				public bool ignoreIfButtonsActive;

				public int[] ignoreIfButtonsActiveButtons;

				public HardwareButtonInfo buttonInfo;

				public Button_Base()
				{
					sourceType = HardwareElementSourceTypeWithHat.Button;
				}

				protected void ImportVars(Button_Base source)
				{
					ImportVars((Element)source);
					elementIdentifier = source.elementIdentifier;
					while (true)
					{
						int num = -298040478;
						while (true)
						{
							switch (num ^ -298040473)
							{
							case 3:
								break;
							default:
								return;
							case 1:
								requiredButtons = ArrayTools.ShallowCopy(source.requiredButtons);
								ignoreIfButtonsActive = source.ignoreIfButtonsActive;
								ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(source.ignoreIfButtonsActiveButtons);
								num = -298040480;
								continue;
							case 7:
								buttonInfo = MiscTools.DeepClone(source.buttonInfo);
								num = -298040479;
								continue;
							case 8:
								sourceHatDirection = source.sourceHatDirection;
								num = -298040477;
								continue;
							case 2:
								sourceHat = source.sourceHat;
								sourceHatType = source.sourceHatType;
								num = -298040465;
								continue;
							case 5:
								sourceType = source.sourceType;
								sourceButton = source.sourceButton;
								num = -298040473;
								continue;
							case 4:
								requireMultipleButtons = source.requireMultipleButtons;
								num = -298040474;
								continue;
							case 0:
								sourceAxis = source.sourceAxis;
								sourceAxisPole = source.sourceAxisPole;
								axisDeadZone = source.axisDeadZone;
								num = -298040475;
								continue;
							case 6:
								return;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Axis_Base : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceAxis;

				public AxisRange sourceAxisRange;

				public bool invert;

				public float axisDeadZone;

				public bool calibrateAxis;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public HardwareAxisInfo axisInfo;

				public AxisCalibrationInfoEntry[] alternateCalibrations;

				public int sourceButton;

				public Pole buttonAxisContribution;

				public int sourceHat;

				public AxisDirection sourceHatDirection;

				public AxisRange sourceHatRange;

				public Axis_Base()
				{
					sourceType = HardwareElementSourceTypeWithHat.Axis;
				}

				protected void ImportVars(Axis_Base source)
				{
					ImportVars((Element)source);
					elementIdentifier = source.elementIdentifier;
					sourceType = source.sourceType;
					sourceAxis = source.sourceAxis;
					while (true)
					{
						int num = -563365226;
						while (true)
						{
							switch (num ^ -563365228)
							{
							case 4:
								break;
							case 0:
								axisMax = source.axisMax;
								axisInfo = MiscTools.DeepClone(source.axisInfo);
								num = -563365227;
								continue;
							case 7:
								invert = source.invert;
								axisDeadZone = source.axisDeadZone;
								calibrateAxis = source.calibrateAxis;
								axisZero = source.axisZero;
								num = -563365230;
								continue;
							case 2:
								sourceAxisRange = source.sourceAxisRange;
								num = -563365229;
								continue;
							case 6:
								axisMin = source.axisMin;
								num = -563365228;
								continue;
							case 1:
								sourceButton = source.sourceButton;
								num = -563365225;
								continue;
							case 3:
								buttonAxisContribution = source.buttonAxisContribution;
								sourceHat = source.sourceHat;
								sourceHatDirection = source.sourceHatDirection;
								sourceHatRange = source.sourceHatRange;
								num = -563365231;
								continue;
							default:
								alternateCalibrations = MiscTools.DeepClone(source.alternateCalibrations);
								return;
							}
							break;
						}
					}
				}
			}

			public enum DeviceType
			{
				Any = 0,
				Device = 17,
				Mouse = 18,
				Keyboard = 19,
				Joystick = 20,
				Gamepad = 21,
				Driving = 22,
				Flight = 23,
				FirstPerson = 24,
				ControlDevice = 25,
				ScreenPointer = 26,
				Remote = 27,
				Supplemental = 28
			}

			public MatchingCriteria matchingCriteria;

			internal override bool hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedAxisCount == 0 && assignedButtonCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			internal override bool disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			internal override bool isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal abstract IEnumerable<Axis_Base> IterateAxes();

			internal abstract IEnumerable<Button_Base> IterateButtons();

			internal override void CopyVars(Platform destination)
			{
				Platform_RawOrDirectInput platform_RawOrDirectInput = destination as Platform_RawOrDirectInput;
				while (true)
				{
					int num = 893264270;
					while (true)
					{
						switch (num ^ 0x353E218D)
						{
						case 0:
							break;
						default:
							return;
						case 3:
							if (platform_RawOrDirectInput != null)
							{
								goto IL_0034;
							}
							return;
						case 2:
							goto IL_0034;
						case 1:
							return;
						}
						break;
						IL_0034:
						platform_RawOrDirectInput.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
						num = 893264268;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_DirectInput_Base : Platform_RawOrDirectInput
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Platform_Base
			{
				private sealed class aTUUiyjFfPtHUpIPxXfSaFbtFdz : IDisposable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>, IEnumerable
				{
					private Axis_Base RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public Elements ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public int syuORrDGdIjOOxJWigsHnxVfeBB;

					Axis_Base IEnumerator<Axis_Base>.Current
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
					IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
					{
						aTUUiyjFfPtHUpIPxXfSaFbtFdz aTUUiyjFfPtHUpIPxXfSaFbtFdz2;
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							aTUUiyjFfPtHUpIPxXfSaFbtFdz2 = this;
							goto IL_0025;
						}
						goto IL_004e;
						IL_002a:
						int num;
						while (true)
						{
							switch (num ^ -1924364555)
							{
							case 0:
								break;
							case 3:
								num = -1924364553;
								continue;
							case 1:
								goto IL_004e;
							default:
								return aTUUiyjFfPtHUpIPxXfSaFbtFdz2;
							}
							break;
						}
						goto IL_0025;
						IL_004e:
						aTUUiyjFfPtHUpIPxXfSaFbtFdz2 = new aTUUiyjFfPtHUpIPxXfSaFbtFdz(0);
						aTUUiyjFfPtHUpIPxXfSaFbtFdz2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = -1924364553;
						goto IL_002a;
						IL_0025:
						num = -1924364554;
						goto IL_002a;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int num;
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						default:
							num = 1186580960;
							goto IL_001a;
						case 0:
							goto IL_0082;
						case 1:
							{
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								syuORrDGdIjOOxJWigsHnxVfeBB++;
								num = 1186580962;
								goto IL_001a;
							}
							IL_001a:
							while (true)
							{
								switch (num ^ 0x46B9C9E3)
								{
								case 5:
									break;
								case 6:
									syuORrDGdIjOOxJWigsHnxVfeBB = 0;
									num = 1186580967;
									continue;
								case 1:
									goto IL_005c;
								case 7:
									goto IL_0082;
								case 3:
									num = 1186580963;
									continue;
								case 2:
									goto IL_0097;
								case 8:
									RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.axes[syuORrDGdIjOOxJWigsHnxVfeBB];
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
									return true;
								case 4:
									num = 1186580962;
									continue;
								default:
									return false;
								}
								break;
								IL_0097:
								int num2;
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.axes == null)
								{
									num = 1186580963;
									num2 = num;
								}
								else
								{
									num = 1186580965;
									num2 = num;
								}
								continue;
								IL_005c:
								int num3;
								if (syuORrDGdIjOOxJWigsHnxVfeBB < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.axes.Length)
								{
									num = 1186580971;
									num3 = num;
								}
								else
								{
									num = 1186580963;
									num3 = num;
								}
							}
							goto default;
							IL_0082:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							num = 1186580961;
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
					public aTUUiyjFfPtHUpIPxXfSaFbtFdz(int _003C_003E1__state)
					{
						while (true)
						{
							int num = 363017502;
							while (true)
							{
								switch (num ^ 0x15A3351F)
								{
								case 0:
									break;
								default:
									return;
								case 1:
									goto IL_0024;
								case 2:
									return;
								}
								break;
								IL_0024:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
								iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
								num = 363017501;
							}
						}
					}
				}

				private sealed class UEILbNcMnfFjTDGvmjPQbqeIkgDd : IDisposable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>, IEnumerable
				{
					private Button_Base RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public Elements ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public int FhXKqWjbzBGGMaBtHIJtwjVybaxf;

					Button_Base IEnumerator<Button_Base>.Current
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
					IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
						{
							goto IL_0012;
						}
						goto IL_0058;
						IL_0012:
						int num = -237092460;
						goto IL_0017;
						IL_0017:
						UEILbNcMnfFjTDGvmjPQbqeIkgDd uEILbNcMnfFjTDGvmjPQbqeIkgDd = default(UEILbNcMnfFjTDGvmjPQbqeIkgDd);
						while (true)
						{
							switch (num ^ -237092459)
							{
							case 2:
								break;
							case 3:
								uEILbNcMnfFjTDGvmjPQbqeIkgDd.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
								num = -237092463;
								continue;
							case 0:
								uEILbNcMnfFjTDGvmjPQbqeIkgDd = this;
								num = -237092463;
								continue;
							case 5:
								goto IL_0058;
							case 1:
								if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
								{
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
									num = -237092459;
									continue;
								}
								goto IL_0058;
							default:
								return uEILbNcMnfFjTDGvmjPQbqeIkgDd;
							}
							break;
						}
						goto IL_0012;
						IL_0058:
						uEILbNcMnfFjTDGvmjPQbqeIkgDd = new UEILbNcMnfFjTDGvmjPQbqeIkgDd(0);
						num = -237092458;
						goto IL_0017;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button_Base>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int num;
						int num3;
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						default:
							num = 1772509234;
							goto IL_001a;
						case 0:
							goto IL_007b;
						case 1:
							{
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								FhXKqWjbzBGGMaBtHIJtwjVybaxf++;
								num = 1772509238;
								goto IL_001a;
							}
							IL_001a:
							while (true)
							{
								switch (num ^ 0x69A65830)
								{
								case 8:
									break;
								case 5:
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
									num = 1772509235;
									continue;
								case 0:
									RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttons[FhXKqWjbzBGGMaBtHIJtwjVybaxf];
									num = 1772509237;
									continue;
								case 1:
									goto IL_007b;
								case 7:
									FhXKqWjbzBGGMaBtHIJtwjVybaxf = 0;
									num = 1772509238;
									continue;
								case 2:
									num = 1772509236;
									continue;
								case 3:
									return true;
								case 6:
									goto IL_00df;
								default:
									return false;
								}
								break;
								IL_00df:
								int num2;
								if (FhXKqWjbzBGGMaBtHIJtwjVybaxf < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttons.Length)
								{
									num = 1772509232;
									num2 = num;
								}
								else
								{
									num = 1772509236;
									num2 = num;
								}
							}
							goto default;
							IL_007b:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttons != null)
							{
								num = 1772509239;
								num3 = num;
							}
							else
							{
								num = 1772509236;
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
					public UEILbNcMnfFjTDGvmjPQbqeIkgDd(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				public override int axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override IEnumerable<Axis_Base> Axes
				{
					get
					{
						aTUUiyjFfPtHUpIPxXfSaFbtFdz aTUUiyjFfPtHUpIPxXfSaFbtFdz2 = new aTUUiyjFfPtHUpIPxXfSaFbtFdz(-2);
						aTUUiyjFfPtHUpIPxXfSaFbtFdz2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
						return aTUUiyjFfPtHUpIPxXfSaFbtFdz2;
					}
				}

				internal override IEnumerable<Button_Base> Buttons
				{
					get
					{
						UEILbNcMnfFjTDGvmjPQbqeIkgDd uEILbNcMnfFjTDGvmjPQbqeIkgDd = new UEILbNcMnfFjTDGvmjPQbqeIkgDd(-2);
						uEILbNcMnfFjTDGvmjPQbqeIkgDd.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
						return uEILbNcMnfFjTDGvmjPQbqeIkgDd;
					}
				}

				internal override Axis_Base GetAxis(int axisIndex)
				{
					if (axes != null)
					{
						while (true)
						{
							int num = -1922917688;
							while (true)
							{
								switch (num ^ -1922917686)
								{
								case 0:
									break;
								case 2:
									goto IL_0026;
								default:
									goto end_IL_0008;
								}
								break;
								IL_0026:
								if (axisIndex < 0)
								{
									goto end_IL_0008;
								}
								if (axisIndex >= axes.Length)
								{
									num = -1922917685;
									continue;
								}
								return axes[axisIndex];
							}
							continue;
							end_IL_0008:
							break;
						}
					}
					return null;
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					int num = 0;
					int num4 = default(int);
					while (true)
					{
						int num2;
						int num3;
						if (num < axisCount)
						{
							num2 = 1704188695;
							num3 = num2;
						}
						else
						{
							num2 = 1704188690;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x6593DB13)
							{
							case 2:
								num2 = 1704188695;
								continue;
							case 3:
								if (buttons[num4].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num4++;
								num2 = 1704188694;
								continue;
							case 1:
								num4 = 0;
								num2 = 1704188694;
								continue;
							case 0:
								break;
							case 4:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = 1704188691;
								continue;
							default:
								if (num4 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								goto case 3;
							}
							break;
						}
					}
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					HardwareElementSourceTypeWithHat sourceType = default(HardwareElementSourceTypeWithHat);
					while (true)
					{
						int num2;
						int num3;
						if (num < axisCount)
						{
							num2 = -630628824;
							num3 = num2;
						}
						else
						{
							num2 = -630628831;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -630628823)
							{
							case 7:
								num2 = -630628824;
								continue;
							case 10:
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -630628821;
									continue;
								}
								goto case 2;
							case 3:
								axisRange = axes[num].sourceAxisRange;
								num2 = -630628829;
								continue;
							case 4:
								switch (sourceType)
								{
								case HardwareElementSourceTypeWithHat.Axis:
									break;
								default:
									goto IL_0096;
								case HardwareElementSourceTypeWithHat.Button:
									axisRange = AxisRange.Positive;
									return true;
								case HardwareElementSourceTypeWithHat.Hat:
									goto IL_0131;
								}
								goto case 3;
							case 11:
								return true;
							case 0:
								throw new NotImplementedException();
							case 9:
								break;
							case 5:
								sourceType = axes[num].sourceType;
								num2 = -630628819;
								continue;
							case 6:
								num++;
								num2 = -630628832;
								continue;
							case 1:
							{
								int num4;
								if (axes[num].elementIdentifier != elementIdentifier.id)
								{
									num2 = -630628817;
									num4 = num2;
								}
								else
								{
									num2 = -630628820;
									num4 = num2;
								}
								continue;
							}
							case 2:
								return true;
							default:
								{
									axisRange = AxisRange.Full;
									return false;
								}
								IL_0131:
								axisRange = axes[num].sourceHatRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -630628830;
									continue;
								}
								goto case 11;
								IL_0096:
								num2 = -630628823;
								continue;
							}
							break;
						}
					}
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					Elements elements = default(Elements);
					while (true)
					{
						int num = -1890269306;
						while (true)
						{
							switch (num ^ -1890269305)
							{
							case 0:
								break;
							case 1:
							{
								elements = destination as Elements;
								int num2;
								if (elements != null)
								{
									num = -1890269307;
									num2 = num;
								}
								else
								{
									num = -1890269308;
									num2 = num;
								}
								continue;
							}
							case 3:
								return;
							default:
								elements.axes = ArrayTools.DeepClone(axes);
								elements.buttons = ArrayTools.DeepClone(buttons);
								return;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Button : Button_Base
			{
				public override object DeepClone()
				{
					Button button = new Button();
					button.ImportVars(this);
					return button;
				}

				private void ImportVars(Button source)
				{
					ImportVars((Button_Base)source);
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Axis : Axis_Base
			{
				public override object DeepClone()
				{
					Axis axis = new Axis();
					axis.ImportVars(this);
					return axis;
				}

				private void ImportVars(Axis source)
				{
					ImportVars((Axis_Base)source);
				}
			}

			private sealed class LGVWMxOwgPHcqWcMyTmANvbtuar : IDisposable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>, IEnumerable
			{
				private Axis_Base RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_DirectInput_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int kPfAfaIGcwVIGYqNwaDSDWKQOky;

				public int VGLBtMqpOYwwlXdeobZcRnBEtaU;

				Axis_Base IEnumerator<Axis_Base>.Current
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
				IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						goto IL_001c;
					}
					goto IL_0065;
					IL_0065:
					LGVWMxOwgPHcqWcMyTmANvbtuar lGVWMxOwgPHcqWcMyTmANvbtuar = new LGVWMxOwgPHcqWcMyTmANvbtuar(0);
					int num = 140512314;
					goto IL_0021;
					IL_001c:
					num = 140512312;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ 0x8600C3A)
						{
						case 3:
							break;
						case 2:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							lGVWMxOwgPHcqWcMyTmANvbtuar = this;
							num = 140512315;
							continue;
						case 0:
							lGVWMxOwgPHcqWcMyTmANvbtuar.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
							num = 140512315;
							continue;
						case 4:
							goto IL_0065;
						default:
							return lGVWMxOwgPHcqWcMyTmANvbtuar;
						}
						break;
					}
					goto IL_001c;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 1:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = 1061919049;
						goto IL_001f;
					case 0:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements == null)
							{
								break;
							}
							int num3;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes == null)
							{
								num = 1061919055;
								num3 = num;
							}
							else
							{
								num = 1061919052;
								num3 = num;
							}
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x3F4B994C)
							{
							case 2:
								num = 1061919053;
								continue;
							case 4:
								num = 1061919050;
								continue;
							case 7:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes[VGLBtMqpOYwwlXdeobZcRnBEtaU];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							case 6:
								break;
							case 5:
								VGLBtMqpOYwwlXdeobZcRnBEtaU++;
								num = 1061919050;
								continue;
							case 0:
								kPfAfaIGcwVIGYqNwaDSDWKQOky = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes.Length;
								VGLBtMqpOYwwlXdeobZcRnBEtaU = 0;
								num = 1061919048;
								continue;
							case 1:
								goto end_IL_001f;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (VGLBtMqpOYwwlXdeobZcRnBEtaU < kPfAfaIGcwVIGYqNwaDSDWKQOky)
							{
								num = 1061919051;
								num2 = num;
							}
							else
							{
								num = 1061919055;
								num2 = num;
							}
							continue;
							end_IL_001f:
							break;
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
				public LGVWMxOwgPHcqWcMyTmANvbtuar(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class BhGOLDCgmPrBqVJHjcyJXtYMhGZ : IDisposable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>, IEnumerable
			{
				private Button_Base RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_DirectInput_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int tKLArenkVRViNPlYhCMcgihVovP;

				public int jlMvTvxfwvCZlEduHkrByVsyFJq;

				Button_Base IEnumerator<Button_Base>.Current
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
				IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
				{
					BhGOLDCgmPrBqVJHjcyJXtYMhGZ bhGOLDCgmPrBqVJHjcyJXtYMhGZ;
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						bhGOLDCgmPrBqVJHjcyJXtYMhGZ = this;
					}
					else
					{
						while (true)
						{
							bhGOLDCgmPrBqVJHjcyJXtYMhGZ = new BhGOLDCgmPrBqVJHjcyJXtYMhGZ(0);
							bhGOLDCgmPrBqVJHjcyJXtYMhGZ.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
							int num = 423651116;
							while (true)
							{
								switch (num ^ 0x1940672D)
								{
								case 0:
									num = 423651119;
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
					return bhGOLDCgmPrBqVJHjcyJXtYMhGZ;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button_Base>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
					while (true)
					{
						int num = -181633333;
						while (true)
						{
							switch (num ^ -181633335)
							{
							case 4:
								break;
							case 2:
								switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
								{
								default:
									num = -181633336;
									continue;
								case 0:
									break;
								case 1:
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
									jlMvTvxfwvCZlEduHkrByVsyFJq++;
									num = -181633335;
									continue;
								}
								goto case 5;
							case 5:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements != null && ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons != null)
								{
									tKLArenkVRViNPlYhCMcgihVovP = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons.Length;
									jlMvTvxfwvCZlEduHkrByVsyFJq = 0;
									num = -181633335;
									continue;
								}
								goto default;
							case 3:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons[jlMvTvxfwvCZlEduHkrByVsyFJq];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							case 0:
							{
								int num2;
								if (jlMvTvxfwvCZlEduHkrByVsyFJq < tKLArenkVRViNPlYhCMcgihVovP)
								{
									num = -181633334;
									num2 = num;
								}
								else
								{
									num = -181633336;
									num2 = num;
								}
								continue;
							}
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
				public BhGOLDCgmPrBqVJHjcyJXtYMhGZ(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public Elements elements;

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.GqzyAlVbsTJEJeHcVvIVueUVgOh;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			internal override IList<Platform> variants_base
			{
				get
				{
					return null;
				}
			}

			public override int assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			public override int assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			internal override Elements_Base elements_base
			{
				get
				{
					return elements;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				int num = identifiers.Length;
				int num3 = default(int);
				int num5 = default(int);
				int num4 = default(int);
				string[] array = default(string[]);
				while (true)
				{
					int num2 = 2035682357;
					while (true)
					{
						switch (num2 ^ 0x79560C32)
						{
						case 2:
							break;
						case 6:
							num3++;
							num2 = 2035682353;
							continue;
						case 3:
						{
							int num6;
							if (num3 < num5)
							{
								num2 = 2035682359;
								num6 = num2;
							}
							else
							{
								num2 = 2035682358;
								num6 = num2;
							}
							continue;
						}
						case 9:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = 2035682356;
							continue;
						case 0:
							if (num4 >= 0)
							{
								int num7;
								if (num4 >= num)
								{
									num2 = 2035682363;
									num7 = num2;
								}
								else
								{
									num2 = 2035682355;
									num7 = num2;
								}
								continue;
							}
							goto case 9;
						case 7:
							if (num < elements.axisCount)
							{
								Logger.LogError("You have too few element identifiers!");
								return new string[0];
							}
							array = new string[elements.axisCount];
							num5 = array.Length;
							num3 = 0;
							num2 = 2035682362;
							continue;
						case 1:
							array[num3] = identifiers[num4].name;
							num2 = 2035682356;
							continue;
						case 5:
						{
							int elementIdentifier = elements.axes[num3].elementIdentifier;
							num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num2 = 2035682354;
							continue;
						}
						case 8:
							num2 = 2035682353;
							continue;
						default:
							return array;
						}
						break;
					}
				}
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				int num5 = default(int);
				string[] array = default(string[]);
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					int num = 1062147618;
					while (true)
					{
						switch (num ^ 0x3F4F1624)
						{
						case 0:
							break;
						case 6:
							num5 = identifiers.Length;
							if (num5 < buttonCount)
							{
								Logger.LogError("You have too few element identifiers!");
								return new string[0];
							}
							array = new string[buttonCount];
							num2 = 0;
							num = 1062147616;
							continue;
						case 3:
							num = 1062147629;
							continue;
						case 9:
							num2++;
							num = 1062147622;
							continue;
						case 8:
						{
							int num6;
							if (num3 < num5)
							{
								num = 1062147619;
								num6 = num;
							}
							else
							{
								num = 1062147617;
								num6 = num;
							}
							continue;
						}
						case 7:
							array[num2] = identifiers[num3].name;
							num = 1062147629;
							continue;
						case 5:
							Logger.LogError("Element identifier index is out of bounds!");
							num = 1062147623;
							continue;
						case 4:
							num = 1062147622;
							continue;
						case 1:
						{
							int elementIdentifier = elements.buttons[num2].elementIdentifier;
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							int num4;
							if (num3 >= 0)
							{
								num = 1062147628;
								num4 = num;
							}
							else
							{
								num = 1062147617;
								num4 = num;
							}
							continue;
						}
						default:
							if (num2 >= buttonCount)
							{
								return array;
							}
							goto case 1;
						}
						break;
					}
				}
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				IEnumerator<Axis_Base> enumerator = IterateAxes().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator.Current;
							int num = -1418252283;
							while (true)
							{
								switch (num ^ -1418252284)
								{
								case 3:
									num = -1418252282;
									continue;
								case 4:
									return true;
								case 1:
									break;
								case 2:
									goto end_IL_0013;
								default:
									goto end_IL_005c;
								}
								int num2;
								if (axis.elementIdentifier == elementIdentifierId)
								{
									num = -1418252288;
									num2 = num;
								}
								else
								{
									num = -1418252284;
									num2 = num;
								}
								continue;
								end_IL_0013:
								break;
							}
							continue;
							end_IL_005c:
							break;
						}
					}
				}
				finally
				{
					if (enumerator != null)
					{
						while (true)
						{
							IL_007c:
							int num3 = -1418252282;
							while (true)
							{
								switch (num3 ^ -1418252284)
								{
								case 0:
									break;
								default:
									goto end_IL_0081;
								case 2:
									goto IL_009a;
								case 1:
									goto end_IL_0081;
								}
								goto IL_007c;
								IL_009a:
								enumerator.Dispose();
								num3 = -1418252283;
								continue;
								end_IL_0081:
								break;
							}
							break;
						}
					}
				}
				foreach (Button item in IterateButtons())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				using (IEnumerator<Button_Base> enumerator = IterateButtons().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Button button = (Button)enumerator.Current;
							buttons[num] = button.elementIdentifier;
							int num2 = 2108019123;
							while (true)
							{
								switch (num2 ^ 0x7DA5D1B3)
								{
								case 2:
									num2 = 2108019122;
									continue;
								case 1:
									break;
								case 0:
									num++;
									num2 = 2108019120;
									continue;
								default:
									goto end_IL_004c;
								}
								break;
							}
							continue;
							end_IL_004c:
							break;
						}
					}
				}
				num = 0;
				IEnumerator<Axis_Base> enumerator2 = IterateAxes().GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator2.Current;
							int num3 = 2108019122;
							while (true)
							{
								switch (num3 ^ 0x7DA5D1B3)
								{
								case 3:
									num3 = 2108019121;
									continue;
								case 2:
									break;
								case 1:
									axes[num] = axis.elementIdentifier;
									num++;
									num3 = 2108019123;
									continue;
								default:
									goto end_IL_00bb;
								}
								break;
							}
							continue;
							end_IL_00bb:
							break;
						}
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						while (true)
						{
							IL_00f3:
							int num4 = 2108019121;
							while (true)
							{
								switch (num4 ^ 0x7DA5D1B3)
								{
								case 0:
									break;
								default:
									goto end_IL_00f8;
								case 2:
									goto IL_0111;
								case 1:
									goto end_IL_00f8;
								}
								goto IL_00f3;
								IL_0111:
								enumerator2.Dispose();
								num4 = 2108019122;
								continue;
								end_IL_00f8:
								break;
							}
							break;
						}
					}
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				int num2 = default(int);
				while (true)
				{
					int num = 350704654;
					while (true)
					{
						switch (num ^ 0x14E7540D)
						{
						case 9:
							break;
						case 8:
							throw new NotImplementedException();
						case 1:
							array[num2] = AxisCalibrationData.Default;
							num = 350704651;
							continue;
						case 2:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num2++;
							num = 350704647;
							continue;
						case 4:
							num = 350704655;
							continue;
						case 0:
							array[num2] = AxisCalibrationData.Default;
							num = 350704655;
							continue;
						case 11:
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num3;
								if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Custom)
								{
									num = 350704652;
									num3 = num;
								}
								else
								{
									num = 350704648;
									num3 = num;
								}
								continue;
							}
							goto case 1;
						case 3:
							num2 = 0;
							num = 350704647;
							continue;
						case 5:
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num5;
								if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Hat)
								{
									num = 350704653;
									num5 = num;
								}
								else
								{
									num = 350704645;
									num5 = num;
								}
								continue;
							}
							goto case 0;
						case 7:
							array[num2].zero = axes_orig[num2].axisZero;
							array[num2].min = axes_orig[num2].axisMin;
							array[num2].max = axes_orig[num2].axisMax;
							num = 350704649;
							continue;
						case 6:
						{
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							int num4;
							if (!Axes_orig[num2].calibrateAxis)
							{
								num = 350704655;
								num4 = num;
							}
							else
							{
								num = 350704650;
								num4 = num;
							}
							continue;
						}
						default:
							if (num2 >= axes_orig.Length)
							{
								return array;
							}
							goto case 11;
						}
						break;
					}
				}
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				int num2 = default(int);
				while (true)
				{
					int num = -1019479915;
					while (true)
					{
						switch (num ^ -1019479916)
						{
						case 2:
							break;
						default:
							return;
						case 4:
							throw new Exception();
						case 9:
							num2++;
							num = -1019479913;
							continue;
						case 7:
						{
							int num6;
							if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Hat)
							{
								num = -1019479916;
								num6 = num;
							}
							else
							{
								num = -1019479920;
								num6 = num;
							}
							continue;
						}
						case 5:
						{
							int num7;
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								num = -1019479917;
								num7 = num;
							}
							else
							{
								num = -1019479916;
								num7 = num;
							}
							continue;
						}
						case 1:
						{
							int num4;
							if (Axes_orig == null)
							{
								num = -1019479911;
								num4 = num;
							}
							else
							{
								num = -1019479905;
								num4 = num;
							}
							continue;
						}
						case 8:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							num = -1019479918;
							continue;
						case 0:
							axisRanges[num2] = AxisRange.Full;
							num = -1019479907;
							continue;
						case 13:
							return;
						case 10:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -1019479907;
							continue;
						case 6:
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num5;
								if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									num = -1019479919;
									num5 = num;
								}
								else
								{
									num = -1019479906;
									num5 = num;
								}
								continue;
							}
							goto case 10;
						case 11:
							axisRanges = new AxisRange[Axes_orig.Length];
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = -1019479913;
							continue;
						case 3:
						{
							int num3;
							if (num2 < Axes_orig.Length)
							{
								num = -1019479908;
								num3 = num;
							}
							else
							{
								num = -1019479912;
								num3 = num;
							}
							continue;
						}
						case 12:
							return;
						}
						break;
					}
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig == null)
				{
					goto IL_000b;
				}
				goto IL_0042;
				IL_000b:
				int num = -134984845;
				goto IL_0010;
				IL_0010:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ -134984842)
					{
					case 0:
						break;
					case 4:
						num2 = 0;
						num = -134984844;
						continue;
					case 6:
						goto IL_0042;
					case 3:
						buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
						num2++;
						num = -134984841;
						continue;
					case 5:
						return;
					case 2:
						num = -134984841;
						continue;
					default:
						if (num2 >= Buttons_orig.Length)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
				goto IL_000b;
				IL_0042:
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				num = -134984846;
				goto IL_0010;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				LGVWMxOwgPHcqWcMyTmANvbtuar lGVWMxOwgPHcqWcMyTmANvbtuar = new LGVWMxOwgPHcqWcMyTmANvbtuar(-2);
				lGVWMxOwgPHcqWcMyTmANvbtuar.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return lGVWMxOwgPHcqWcMyTmANvbtuar;
			}

			internal override IEnumerable<Button_Base> IterateButtons()
			{
				BhGOLDCgmPrBqVJHjcyJXtYMhGZ bhGOLDCgmPrBqVJHjcyJXtYMhGZ = new BhGOLDCgmPrBqVJHjcyJXtYMhGZ(-2);
				bhGOLDCgmPrBqVJHjcyJXtYMhGZ.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return bhGOLDCgmPrBqVJHjcyJXtYMhGZ;
			}

			public override object DeepClone()
			{
				Platform_DirectInput_Base platform_DirectInput_Base = new Platform_DirectInput_Base();
				CopyVars(platform_DirectInput_Base);
				return platform_DirectInput_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_DirectInput_Base platform_DirectInput_Base = default(Platform_DirectInput_Base);
				while (true)
				{
					switch (-1041452469 ^ -1041452470)
					{
					case 2:
						continue;
					case 1:
						platform_DirectInput_Base = destination as Platform_DirectInput_Base;
						if (platform_DirectInput_Base == null)
						{
							return;
						}
						break;
					}
					break;
				}
				platform_DirectInput_Base.elements = MiscTools.DeepClone(elements);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_DirectInput : Platform_DirectInput_Base
		{
			public Platform_DirectInput_Base[] variants;

			internal override IList<Platform> variants_base
			{
				get
				{
					return variants;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					goto IL_000d;
				}
				int num = default(int);
				int num2;
				if (base.hasVariants)
				{
					num = 0;
					num2 = -1491153189;
					goto IL_0012;
				}
				goto IL_009f;
				IL_0012:
				while (true)
				{
					switch (num2 ^ -1491153192)
					{
					case 0:
						break;
					case 5:
						return true;
					case 4:
						goto IL_004a;
					case 2:
						goto IL_005b;
					case 3:
						goto IL_0080;
					default:
						goto IL_009f;
					}
					break;
					IL_0080:
					int num3;
					if (num >= variants.Length)
					{
						num2 = -1491153191;
						num3 = num2;
					}
					else
					{
						num2 = -1491153188;
						num3 = num2;
					}
					continue;
					IL_0075:
					num++;
					num2 = -1491153189;
					continue;
					IL_004a:
					if (variants[num] != null)
					{
						num2 = -1491153190;
						continue;
					}
					goto IL_0075;
					IL_005b:
					int variantIndex2;
					if (variants[num].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
					{
						variantIndex = num;
						return true;
					}
					goto IL_0075;
				}
				goto IL_000d;
				IL_009f:
				return false;
				IL_000d:
				num2 = -1491153187;
				goto IL_0012;
			}

			public override object DeepClone()
			{
				Platform_DirectInput platform_DirectInput = new Platform_DirectInput();
				CopyVars(platform_DirectInput);
				return platform_DirectInput;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_DirectInput platform_DirectInput = destination as Platform_DirectInput;
				if (platform_DirectInput == null)
				{
					return;
				}
				while (true)
				{
					platform_DirectInput.variants = MiscTools.DeepClone(variants);
					int num = -164946716;
					while (true)
					{
						switch (num ^ -164946714)
						{
						case 0:
							goto IL_0012;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_0012:
						num = -164946713;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_RawInput_Base : Platform_RawOrDirectInput
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Platform_Base
			{
				private sealed class ZGxmgbvrCOhdQvrSroogxorsPlU : IDisposable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>, IEnumerable
				{
					private Axis_Base RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public Elements ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public int vzrCiFGNDyojQumVNRXvZZNGJNw;

					Axis_Base IEnumerator<Axis_Base>.Current
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
					IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
						{
							goto IL_0012;
						}
						goto IL_0050;
						IL_0012:
						int num = -1188275584;
						goto IL_0017;
						IL_0017:
						ZGxmgbvrCOhdQvrSroogxorsPlU zGxmgbvrCOhdQvrSroogxorsPlU = default(ZGxmgbvrCOhdQvrSroogxorsPlU);
						while (true)
						{
							switch (num ^ -1188275583)
							{
							case 0:
								break;
							case 1:
								if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
								{
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
									num = -1188275582;
									continue;
								}
								goto IL_0050;
							case 4:
								goto IL_0050;
							case 3:
								zGxmgbvrCOhdQvrSroogxorsPlU = this;
								num = -1188275581;
								continue;
							default:
								return zGxmgbvrCOhdQvrSroogxorsPlU;
							}
							break;
						}
						goto IL_0012;
						IL_0050:
						zGxmgbvrCOhdQvrSroogxorsPlU = new ZGxmgbvrCOhdQvrSroogxorsPlU(0);
						zGxmgbvrCOhdQvrSroogxorsPlU.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = -1188275581;
						goto IL_0017;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int num;
						int num3;
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						default:
							num = 149845710;
							goto IL_001a;
						case 0:
							goto IL_006c;
						case 1:
							{
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								vzrCiFGNDyojQumVNRXvZZNGJNw++;
								num = 149845709;
								goto IL_001a;
							}
							IL_001a:
							while (true)
							{
								switch (num ^ 0x8EE76CF)
								{
								case 5:
									break;
								case 2:
									goto IL_0046;
								case 0:
									goto IL_006c;
								case 4:
									vzrCiFGNDyojQumVNRXvZZNGJNw = 0;
									num = 149845709;
									continue;
								case 6:
									RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.axes[vzrCiFGNDyojQumVNRXvZZNGJNw];
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
									return true;
								case 1:
									num = 149845708;
									continue;
								default:
									return false;
								}
								break;
								IL_0046:
								int num2;
								if (vzrCiFGNDyojQumVNRXvZZNGJNw >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.axes.Length)
								{
									num = 149845708;
									num2 = num;
								}
								else
								{
									num = 149845705;
									num2 = num;
								}
							}
							goto default;
							IL_006c:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.axes != null)
							{
								num = 149845707;
								num3 = num;
							}
							else
							{
								num = 149845708;
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
					public ZGxmgbvrCOhdQvrSroogxorsPlU(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class WOTpiSkTxqhgkGLLxJjGmGAiwPy : IDisposable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>, IEnumerable
				{
					private Button_Base RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public Elements ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public int cFnDlgdVuspTwJakgPGsRmHyDwXn;

					Button_Base IEnumerator<Button_Base>.Current
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
					IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
					{
						WOTpiSkTxqhgkGLLxJjGmGAiwPy wOTpiSkTxqhgkGLLxJjGmGAiwPy;
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							wOTpiSkTxqhgkGLLxJjGmGAiwPy = this;
						}
						else
						{
							while (true)
							{
								wOTpiSkTxqhgkGLLxJjGmGAiwPy = new WOTpiSkTxqhgkGLLxJjGmGAiwPy(0);
								int num = -322560205;
								while (true)
								{
									switch (num ^ -322560205)
									{
									case 3:
										num = -322560206;
										continue;
									case 1:
										break;
									case 0:
										wOTpiSkTxqhgkGLLxJjGmGAiwPy.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
										num = -322560207;
										continue;
									default:
										goto end_IL_0049;
									}
									break;
								}
								continue;
								end_IL_0049:
								break;
							}
						}
						return wOTpiSkTxqhgkGLLxJjGmGAiwPy;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button_Base>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
						while (true)
						{
							int num = 2094620459;
							while (true)
							{
								switch (num ^ 0x7CD95F28)
								{
								case 0:
									break;
								case 3:
									switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
									{
									default:
										num = 2094620457;
										continue;
									case 1:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
										cFnDlgdVuspTwJakgPGsRmHyDwXn++;
										num = 2094620463;
										continue;
									case 0:
										break;
									}
									goto case 2;
								case 4:
									return true;
								case 5:
									cFnDlgdVuspTwJakgPGsRmHyDwXn = 0;
									num = 2094620463;
									continue;
								case 6:
									RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttons[cFnDlgdVuspTwJakgPGsRmHyDwXn];
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
									num = 2094620460;
									continue;
								case 2:
								{
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
									int num3;
									if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttons == null)
									{
										num = 2094620457;
										num3 = num;
									}
									else
									{
										num = 2094620461;
										num3 = num;
									}
									continue;
								}
								case 7:
								{
									int num2;
									if (cFnDlgdVuspTwJakgPGsRmHyDwXn >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttons.Length)
									{
										num = 2094620457;
										num2 = num;
									}
									else
									{
										num = 2094620462;
										num2 = num;
									}
									continue;
								}
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
					public WOTpiSkTxqhgkGLLxJjGmGAiwPy(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				public override int axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override IEnumerable<Axis_Base> Axes
				{
					get
					{
						ZGxmgbvrCOhdQvrSroogxorsPlU zGxmgbvrCOhdQvrSroogxorsPlU = new ZGxmgbvrCOhdQvrSroogxorsPlU(-2);
						zGxmgbvrCOhdQvrSroogxorsPlU.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
						return zGxmgbvrCOhdQvrSroogxorsPlU;
					}
				}

				internal override IEnumerable<Button_Base> Buttons
				{
					get
					{
						WOTpiSkTxqhgkGLLxJjGmGAiwPy wOTpiSkTxqhgkGLLxJjGmGAiwPy = new WOTpiSkTxqhgkGLLxJjGmGAiwPy(-2);
						wOTpiSkTxqhgkGLLxJjGmGAiwPy.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
						return wOTpiSkTxqhgkGLLxJjGmGAiwPy;
					}
				}

				internal override Axis_Base GetAxis(int axisIndex)
				{
					if (axes != null && axisIndex >= 0)
					{
						while (true)
						{
							int num = -1996500953;
							while (true)
							{
								switch (num ^ -1996500954)
								{
								case 2:
									break;
								case 1:
									goto IL_002a;
								default:
									goto end_IL_000c;
								}
								break;
								IL_002a:
								if (axisIndex >= axes.Length)
								{
									num = -1996500954;
									continue;
								}
								return axes[axisIndex];
							}
							continue;
							end_IL_000c:
							break;
						}
					}
					return null;
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					int num = 0;
					int num3 = default(int);
					while (true)
					{
						int num2 = 706482054;
						while (true)
						{
							switch (num2 ^ 0x2A1C0F82)
							{
							case 3:
								break;
							case 5:
								if (buttons[num3].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num3++;
								num2 = 706482048;
								continue;
							case 0:
								return ControllerElementType.Axis;
							case 7:
							{
								int num4;
								if (num < axisCount)
								{
									num2 = 706482051;
									num4 = num2;
								}
								else
								{
									num2 = 706482052;
									num4 = num2;
								}
								continue;
							}
							case 6:
								num3 = 0;
								num2 = 706482048;
								continue;
							case 1:
								if (axes[num].elementIdentifier != elementIdentifier.id)
								{
									num++;
									num2 = 706482053;
								}
								else
								{
									num2 = 706482050;
								}
								continue;
							case 4:
								num2 = 706482053;
								continue;
							default:
								if (num3 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								goto case 5;
							}
							break;
						}
					}
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					HardwareElementSourceTypeWithHat sourceType = default(HardwareElementSourceTypeWithHat);
					while (true)
					{
						IL_0048:
						int num2;
						if (num >= axisCount)
						{
							axisRange = AxisRange.Full;
							num2 = -104426653;
							goto IL_0009;
						}
						goto IL_00a2;
						IL_003d:
						num++;
						num2 = -104426645;
						goto IL_0009;
						IL_00a2:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							sourceType = axes[num].sourceType;
							switch (sourceType)
							{
							case HardwareElementSourceTypeWithHat.Button:
								axisRange = AxisRange.Positive;
								return true;
							case HardwareElementSourceTypeWithHat.Hat:
								break;
							default:
								goto IL_00d7;
							case HardwareElementSourceTypeWithHat.Axis:
								goto IL_00f3;
							}
							axisRange = axes[num].sourceHatRange;
							if (!axes[num].invert)
							{
								break;
							}
							axisRange = InputTools.InvertAxisRange(axisRange);
							num2 = -104426643;
							goto IL_0009;
						}
						goto IL_003d;
						IL_0009:
						while (true)
						{
							switch (num2 ^ -104426645)
							{
							case 2:
								num2 = -104426646;
								continue;
							case 5:
								break;
							case 0:
								goto IL_0048;
							case 3:
								goto IL_005b;
							case 7:
								goto IL_0093;
							case 1:
								goto IL_00a2;
							case 6:
								goto end_IL_0048;
							case 4:
								goto IL_00f3;
							default:
								return false;
							}
							break;
							IL_0093:
							if (sourceType == HardwareElementSourceTypeWithHat.Custom)
							{
								num2 = -104426641;
								continue;
							}
							throw new NotImplementedException();
						}
						goto IL_003d;
						IL_00d7:
						num2 = -104426644;
						goto IL_0009;
						IL_00f3:
						axisRange = axes[num].sourceAxisRange;
						if (axes[num].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
							num2 = -104426648;
							goto IL_0009;
						}
						goto IL_005b;
						IL_005b:
						return true;
						continue;
						end_IL_0048:
						break;
					}
					return true;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					Elements elements = default(Elements);
					while (true)
					{
						int num = 1987864274;
						while (true)
						{
							switch (num ^ 0x767C66D3)
							{
							case 3:
								break;
							default:
								return;
							case 1:
								elements = destination as Elements;
								if (elements != null)
								{
									goto IL_003b;
								}
								return;
							case 0:
								goto IL_003b;
							case 2:
								return;
							}
							break;
							IL_003b:
							elements.axes = ArrayTools.DeepClone(axes);
							elements.buttons = ArrayTools.DeepClone(buttons);
							num = 1987864273;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Button : Button_Base
			{
				public int sourceOtherAxis;

				public override object DeepClone()
				{
					Button button = new Button();
					button.ImportVars(this);
					return button;
				}

				private void ImportVars(Button source)
				{
					ImportVars((Button_Base)source);
					sourceOtherAxis = source.sourceOtherAxis;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Axis : Axis_Base
			{
				public int sourceOtherAxis;

				public override object DeepClone()
				{
					Axis axis = new Axis();
					axis.ImportVars(this);
					return axis;
				}

				private void ImportVars(Axis source)
				{
					ImportVars((Axis_Base)source);
					sourceOtherAxis = source.sourceOtherAxis;
				}
			}

			private sealed class EWRsiqYrnSjedZwcMbyVwmZwohZ : IDisposable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>, IEnumerable
			{
				private Axis_Base RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_RawInput_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int HqfyHSXrJbveYbJWlmtykIUWrmA;

				public int kKcPRQRCZCdVjdsPLZlYnTnCotb;

				Axis_Base IEnumerator<Axis_Base>.Current
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
				IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
					{
						goto IL_0012;
					}
					goto IL_003c;
					IL_0012:
					int num = 538115689;
					goto IL_0017;
					IL_0017:
					EWRsiqYrnSjedZwcMbyVwmZwohZ eWRsiqYrnSjedZwcMbyVwmZwohZ = default(EWRsiqYrnSjedZwcMbyVwmZwohZ);
					while (true)
					{
						switch (num ^ 0x2012FE6B)
						{
						case 0:
							break;
						case 1:
							goto IL_003c;
						case 5:
							eWRsiqYrnSjedZwcMbyVwmZwohZ.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
							num = 538115688;
							continue;
						case 2:
							goto IL_005d;
						case 4:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							eWRsiqYrnSjedZwcMbyVwmZwohZ = this;
							num = 538115688;
							continue;
						default:
							return eWRsiqYrnSjedZwcMbyVwmZwohZ;
						}
						break;
						IL_005d:
						int num2;
						if (LzqgRXjFXvJPbHjfzyAmNfcqezXL != -2)
						{
							num = 538115690;
							num2 = num;
						}
						else
						{
							num = 538115695;
							num2 = num;
						}
					}
					goto IL_0012;
					IL_003c:
					eWRsiqYrnSjedZwcMbyVwmZwohZ = new EWRsiqYrnSjedZwcMbyVwmZwohZ(0);
					num = 538115694;
					goto IL_0017;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 1:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						kKcPRQRCZCdVjdsPLZlYnTnCotb++;
						num = 1088047139;
						goto IL_001f;
					case 0:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements == null || ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes == null)
							{
								break;
							}
							HqfyHSXrJbveYbJWlmtykIUWrmA = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes.Length;
							kKcPRQRCZCdVjdsPLZlYnTnCotb = 0;
							num = 1088047139;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x40DA4822)
							{
							case 0:
								num = 1088047142;
								continue;
							case 1:
								break;
							case 2:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes[kKcPRQRCZCdVjdsPLZlYnTnCotb];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							case 4:
								goto end_IL_001f;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (kKcPRQRCZCdVjdsPLZlYnTnCotb < HqfyHSXrJbveYbJWlmtykIUWrmA)
							{
								num = 1088047136;
								num2 = num;
							}
							else
							{
								num = 1088047137;
								num2 = num;
							}
							continue;
							end_IL_001f:
							break;
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
				public EWRsiqYrnSjedZwcMbyVwmZwohZ(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class PbJABaCqBoptBXvwxkDPvabAjgq : IDisposable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>, IEnumerable
			{
				private Button_Base RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_RawInput_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int qIBJOWhkRdNJnycSlOwdwgeKAEh;

				public int qoHgijEzgSqHQhszJSXwslTvBDY;

				Button_Base IEnumerator<Button_Base>.Current
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
				IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						goto IL_0023;
					}
					goto IL_0049;
					IL_0028:
					int num;
					PbJABaCqBoptBXvwxkDPvabAjgq pbJABaCqBoptBXvwxkDPvabAjgq = default(PbJABaCqBoptBXvwxkDPvabAjgq);
					while (true)
					{
						switch (num ^ 0x48559F89)
						{
						case 2:
							break;
						case 3:
							goto IL_0049;
						case 4:
							num = 1213570953;
							continue;
						case 1:
							pbJABaCqBoptBXvwxkDPvabAjgq = this;
							num = 1213570957;
							continue;
						default:
							return pbJABaCqBoptBXvwxkDPvabAjgq;
						}
						break;
					}
					goto IL_0023;
					IL_0049:
					pbJABaCqBoptBXvwxkDPvabAjgq = new PbJABaCqBoptBXvwxkDPvabAjgq(0);
					pbJABaCqBoptBXvwxkDPvabAjgq.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
					num = 1213570953;
					goto IL_0028;
					IL_0023:
					num = 1213570952;
					goto IL_0028;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button_Base>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 0:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements == null || ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons == null)
						{
							break;
						}
						qIBJOWhkRdNJnycSlOwdwgeKAEh = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons.Length;
						qoHgijEzgSqHQhszJSXwslTvBDY = 0;
						num = 301544202;
						goto IL_001f;
					case 1:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							qoHgijEzgSqHQhszJSXwslTvBDY++;
							num = 301544202;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x11F93308)
							{
							case 5:
								num = 301544201;
								continue;
							case 1:
								break;
							case 3:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons[qoHgijEzgSqHQhszJSXwslTvBDY];
								num = 301544204;
								continue;
							case 2:
								goto IL_00c0;
							case 4:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00c0:
							int num2;
							if (qoHgijEzgSqHQhszJSXwslTvBDY < qIBJOWhkRdNJnycSlOwdwgeKAEh)
							{
								num = 301544203;
								num2 = num;
							}
							else
							{
								num = 301544200;
								num2 = num;
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
				public PbJABaCqBoptBXvwxkDPvabAjgq(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public Elements elements;

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.cZjaGiccoOfQMydNsMdhkKrlxCba;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			internal override IList<Platform> variants_base
			{
				get
				{
					return null;
				}
			}

			public override int assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			public override int assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			internal override Elements_Base elements_base
			{
				get
				{
					return elements;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				int num = identifiers.Length;
				if (num < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					goto IL_001c;
				}
				string[] array = new string[elements.axisCount];
				int num2 = 1173553782;
				goto IL_0021;
				IL_0021:
				int num3 = default(int);
				int num5 = default(int);
				int num4 = default(int);
				while (true)
				{
					switch (num2 ^ 0x45F3027E)
					{
					case 0:
						break;
					case 2:
						return new string[0];
					case 3:
						num3++;
						num2 = 1173553786;
						continue;
					case 9:
					{
						int num6;
						if (num5 >= num)
						{
							num2 = 1173553787;
							num6 = num2;
						}
						else
						{
							num2 = 1173553791;
							num6 = num2;
						}
						continue;
					}
					case 6:
					{
						int elementIdentifier = elements.axes[num3].elementIdentifier;
						num5 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						int num7;
						if (num5 < 0)
						{
							num2 = 1173553787;
							num7 = num2;
						}
						else
						{
							num2 = 1173553783;
							num7 = num2;
						}
						continue;
					}
					case 7:
						num3 = 0;
						num2 = 1173553786;
						continue;
					case 1:
						array[num3] = identifiers[num5].name;
						num2 = 1173553789;
						continue;
					case 8:
						num4 = array.Length;
						num2 = 1173553785;
						continue;
					case 5:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = 1173553789;
						continue;
					default:
						if (num3 >= num4)
						{
							return array;
						}
						goto case 6;
					}
					break;
				}
				goto IL_001c;
				IL_001c:
				num2 = 1173553788;
				goto IL_0021;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				int num = identifiers.Length;
				if (num < buttonCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[buttonCount];
				int num3 = default(int);
				int num4 = default(int);
				while (true)
				{
					int num2 = -2047782149;
					while (true)
					{
						switch (num2 ^ -2047782151)
						{
						case 0:
							break;
						case 2:
							num3 = 0;
							num2 = -2047782145;
							continue;
						case 5:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = -2047782152;
							continue;
						case 4:
							array[num3] = identifiers[num4].name;
							num2 = -2047782152;
							continue;
						case 7:
						{
							int elementIdentifier = elements.buttons[num3].elementIdentifier;
							num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num2 = -2047782150;
							continue;
						}
						case 3:
							if (num4 >= 0)
							{
								int num5;
								if (num4 < num)
								{
									num2 = -2047782147;
									num5 = num2;
								}
								else
								{
									num2 = -2047782148;
									num5 = num2;
								}
								continue;
							}
							goto case 5;
						case 1:
							num3++;
							num2 = -2047782145;
							continue;
						default:
							if (num3 >= buttonCount)
							{
								return array;
							}
							goto case 7;
						}
						break;
					}
				}
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				IEnumerator<Axis_Base> enumerator = IterateAxes().GetEnumerator();
				try
				{
					while (true)
					{
						IL_0053:
						int num;
						int num2;
						if (!enumerator.MoveNext())
						{
							num = -946462676;
							num2 = num;
						}
						else
						{
							num = -946462674;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -946462675)
							{
							case 2:
								goto IL_000e;
							default:
								goto end_IL_0013;
							case 3:
							{
								Axis axis = (Axis)enumerator.Current;
								if (axis.elementIdentifier == elementIdentifierId)
								{
									return true;
								}
								break;
							}
							case 0:
								break;
							case 1:
								goto end_IL_0013;
							}
							goto IL_0053;
							IL_000e:
							num = -946462674;
							continue;
							end_IL_0013:
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
							IL_0071:
							int num3 = -946462673;
							while (true)
							{
								switch (num3 ^ -946462675)
								{
								case 0:
									break;
								default:
									goto end_IL_0076;
								case 2:
									goto IL_008f;
								case 1:
									goto end_IL_0076;
								}
								goto IL_0071;
								IL_008f:
								enumerator.Dispose();
								num3 = -946462676;
								continue;
								end_IL_0076:
								break;
							}
							break;
						}
					}
				}
				using (IEnumerator<Button_Base> enumerator2 = IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Button button = (Button)enumerator2.Current;
							int num4 = -946462675;
							while (true)
							{
								switch (num4 ^ -946462675)
								{
								case 2:
									num4 = -946462674;
									continue;
								case 3:
									break;
								case 0:
									if (button.elementIdentifier == elementIdentifierId)
									{
										return true;
									}
									goto end_IL_00ce;
								default:
									goto end_IL_00ce;
								}
								break;
							}
							continue;
							end_IL_00ce:
							break;
						}
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				using (IEnumerator<Button_Base> enumerator = IterateButtons().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Button button = (Button)enumerator.Current;
							buttons[num] = button.elementIdentifier;
							num++;
							int num2 = 1144726850;
							while (true)
							{
								switch (num2 ^ 0x443B2543)
								{
								case 0:
									num2 = 1144726849;
									continue;
								case 2:
									break;
								default:
									goto end_IL_0048;
								}
								break;
							}
							continue;
							end_IL_0048:
							break;
						}
					}
				}
				num = 0;
				IEnumerator<Axis_Base> enumerator2 = IterateAxes().GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator2.Current;
							axes[num] = axis.elementIdentifier;
							int num3 = 1144726848;
							while (true)
							{
								switch (num3 ^ 0x443B2543)
								{
								case 2:
									num3 = 1144726850;
									continue;
								case 1:
									break;
								case 3:
									num++;
									num3 = 1144726851;
									continue;
								default:
									goto end_IL_00b0;
								}
								break;
							}
							continue;
							end_IL_00b0:
							break;
						}
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						while (true)
						{
							IL_00e8:
							int num4 = 1144726849;
							while (true)
							{
								switch (num4 ^ 0x443B2543)
								{
								case 0:
									break;
								default:
									goto end_IL_00ed;
								case 2:
									goto IL_0106;
								case 1:
									goto end_IL_00ed;
								}
								goto IL_00e8;
								IL_0106:
								enumerator2.Dispose();
								num4 = 1144726850;
								continue;
								end_IL_00ed:
								break;
							}
							break;
						}
					}
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				AxisCalibrationData[] array = default(AxisCalibrationData[]);
				int num2 = default(int);
				while (true)
				{
					int num = 995412720;
					while (true)
					{
						switch (num ^ 0x3B54CAFA)
						{
						case 11:
							break;
						case 9:
							array[num2] = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							if (Axes_orig[num2].calibrateAxis)
							{
								array[num2].zero = axes_orig[num2].axisZero;
								array[num2].min = axes_orig[num2].axisMin;
								array[num2].max = axes_orig[num2].axisMax;
								num = 995412731;
								continue;
							}
							goto case 4;
						case 8:
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num5;
								if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Hat)
								{
									num = 995412733;
									num5 = num;
								}
								else
								{
									num = 995412728;
									num5 = num;
								}
								continue;
							}
							goto case 2;
						case 10:
							if (axes_orig == null)
							{
								return null;
							}
							array = new AxisCalibrationData[axes_orig.Length];
							num2 = 0;
							num = 995412732;
							continue;
						case 4:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num = 995412729;
							continue;
						case 7:
							throw new NotImplementedException();
						case 1:
							num = 995412734;
							continue;
						case 5:
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num4;
								if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									num = 995412722;
									num4 = num;
								}
								else
								{
									num = 995412723;
									num4 = num;
								}
								continue;
							}
							goto case 9;
						case 2:
							array[num2] = AxisCalibrationData.Default;
							num = 995412734;
							continue;
						case 6:
						{
							int num3;
							if (num2 >= axes_orig.Length)
							{
								num = 995412730;
								num3 = num;
							}
							else
							{
								num = 995412735;
								num3 = num;
							}
							continue;
						}
						case 3:
							num2++;
							num = 995412732;
							continue;
						default:
							return array;
						}
						break;
					}
				}
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				int num2 = default(int);
				while (true)
				{
					int num = 606267748;
					while (true)
					{
						switch (num ^ 0x2422E961)
						{
						case 0:
							break;
						case 3:
							throw new Exception();
						case 9:
						{
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							int num6;
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								num = 606267744;
								num6 = num;
							}
							else
							{
								num = 606267755;
								num6 = num;
							}
							continue;
						}
						case 4:
							axisRanges = new AxisRange[Axes_orig.Length];
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = 606267750;
							continue;
						case 12:
							return;
						case 5:
						{
							int num5;
							if (Axes_orig == null)
							{
								num = 606267757;
								num5 = num;
							}
							else
							{
								num = 606267749;
								num5 = num;
							}
							continue;
						}
						case 10:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = 606267753;
							continue;
						case 2:
						{
							int num7;
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Hat)
							{
								num = 606267746;
								num7 = num;
							}
							else
							{
								num = 606267754;
								num7 = num;
							}
							continue;
						}
						case 1:
						{
							int num4;
							if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Custom)
							{
								num = 606267755;
								num4 = num;
							}
							else
							{
								num = 606267751;
								num4 = num;
							}
							continue;
						}
						case 6:
						{
							int num3;
							if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Button)
							{
								num = 606267754;
								num3 = num;
							}
							else
							{
								num = 606267747;
								num3 = num;
							}
							continue;
						}
						case 11:
							axisRanges[num2] = AxisRange.Full;
							num = 606267753;
							continue;
						case 8:
							num2++;
							num = 606267750;
							continue;
						default:
							if (num2 >= Axes_orig.Length)
							{
								return;
							}
							goto case 9;
						}
						break;
					}
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig == null)
				{
					return;
				}
				while (true)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					int num = 0;
					int num2 = -1440883999;
					while (true)
					{
						switch (num2 ^ -1440883999)
						{
						case 2:
							num2 = -1440884000;
							continue;
						case 3:
							buttonInfos[num] = MiscTools.DeepClone(Buttons_orig[num].buttonInfo, true);
							num++;
							num2 = -1440883995;
							continue;
						case 0:
							num2 = -1440883995;
							continue;
						case 1:
							break;
						default:
							if (num >= Buttons_orig.Length)
							{
								return;
							}
							goto case 3;
						}
						break;
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				EWRsiqYrnSjedZwcMbyVwmZwohZ eWRsiqYrnSjedZwcMbyVwmZwohZ = new EWRsiqYrnSjedZwcMbyVwmZwohZ(-2);
				while (true)
				{
					int num = 1058388188;
					while (true)
					{
						switch (num ^ 0x3F15B8DE)
						{
						case 0:
							break;
						case 2:
							goto IL_0026;
						default:
							return eWRsiqYrnSjedZwcMbyVwmZwohZ;
						}
						break;
						IL_0026:
						eWRsiqYrnSjedZwcMbyVwmZwohZ.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
						num = 1058388191;
					}
				}
			}

			internal override IEnumerable<Button_Base> IterateButtons()
			{
				PbJABaCqBoptBXvwxkDPvabAjgq pbJABaCqBoptBXvwxkDPvabAjgq = new PbJABaCqBoptBXvwxkDPvabAjgq(-2);
				pbJABaCqBoptBXvwxkDPvabAjgq.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return pbJABaCqBoptBXvwxkDPvabAjgq;
			}

			public override object DeepClone()
			{
				Platform_RawInput_Base platform_RawInput_Base = new Platform_RawInput_Base();
				CopyVars(platform_RawInput_Base);
				return platform_RawInput_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_RawInput_Base platform_RawInput_Base = destination as Platform_RawInput_Base;
				while (true)
				{
					int num = -903533756;
					while (true)
					{
						switch (num ^ -903533755)
						{
						case 0:
							break;
						case 1:
						{
							int num2;
							if (platform_RawInput_Base == null)
							{
								num = -903533754;
								num2 = num;
							}
							else
							{
								num = -903533753;
								num2 = num;
							}
							continue;
						}
						case 3:
							return;
						default:
							platform_RawInput_Base.elements = MiscTools.DeepClone(elements);
							return;
						}
						break;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_RawInput : Platform_RawInput_Base
		{
			public Platform_RawInput_Base[] variants;

			internal override IList<Platform> variants_base
			{
				get
				{
					return variants;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					int num = 0;
					while (true)
					{
						int num2;
						int num3;
						if (num < variants.Length)
						{
							num2 = -853648797;
							num3 = num2;
						}
						else
						{
							num2 = -853648798;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -853648798)
							{
							case 3:
								num2 = -853648797;
								continue;
							case 1:
								break;
							case 2:
								goto end_IL_0020;
							default:
								goto end_IL_006c;
							}
							int variantIndex2;
							if (variants[num] != null && variants[num].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
							{
								variantIndex = num;
								return true;
							}
							num++;
							num2 = -853648800;
							continue;
							end_IL_0020:
							break;
						}
						continue;
						end_IL_006c:
						break;
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_RawInput platform_RawInput = new Platform_RawInput();
				CopyVars(platform_RawInput);
				return platform_RawInput;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_RawInput platform_RawInput = default(Platform_RawInput);
				while (true)
				{
					switch (0x5BD6AC6B ^ 0x5BD6AC6A)
					{
					case 0:
						continue;
					case 1:
						platform_RawInput = destination as Platform_RawInput;
						if (platform_RawInput == null)
						{
							return;
						}
						break;
					}
					break;
				}
				platform_RawInput.variants = MiscTools.DeepClone(variants);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_XInput_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				public XInputDeviceSubType[] subType;

				internal override bool hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (subType.Length == 0)
						{
							return false;
						}
						return true;
					}
				}

				internal override bool isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						return true;
					}
				}

				internal override int alternateElementCount
				{
					get
					{
						return 0;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (disabled)
					{
						return false;
					}
					if (!isAllowed)
					{
						return false;
					}
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						goto IL_002c;
					}
					int num = 0;
					int num2 = 1783917369;
					goto IL_0031;
					IL_0031:
					while (true)
					{
						switch (num2 ^ 0x6A546B3A)
						{
						case 2:
							break;
						case 4:
							return true;
						case 1:
							return true;
						case 0:
							if (subType[num] != bridgedControllerHWInfo.hw_xInputSubType)
							{
								num++;
								num2 = 1783917369;
							}
							else
							{
								num2 = 1783917371;
							}
							continue;
						default:
							if (num >= subType.Length)
							{
								return false;
							}
							goto case 0;
						}
						break;
					}
					goto IL_002c;
					IL_002c:
					num2 = 1783917374;
					goto IL_0031;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched);
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					MatchingCriteria matchingCriteria = default(MatchingCriteria);
					while (true)
					{
						switch (-912427860 ^ -912427859)
						{
						case 2:
							continue;
						case 1:
							matchingCriteria = destination as MatchingCriteria;
							if (matchingCriteria == null)
							{
								return;
							}
							break;
						}
						break;
					}
					matchingCriteria.subType = ArrayTools.ShallowCopy(subType);
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				public override int axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					Elements elements = destination as Elements;
					if (elements != null)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					int num = 0;
					int num2 = default(int);
					while (true)
					{
						IL_0092:
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = 1354352205;
							goto IL_000c;
						}
						goto IL_0031;
						IL_000c:
						while (true)
						{
							switch (num3 ^ 0x50B9C648)
							{
							case 2:
								num3 = 1354352204;
								continue;
							case 4:
								break;
							case 1:
								goto IL_0053;
							case 5:
								goto IL_0075;
							case 0:
								goto IL_0092;
							default:
								return elementIdentifier.elementType;
							}
							break;
							IL_0075:
							int num4;
							if (num2 < buttonCount)
							{
								num3 = 1354352201;
								num4 = num3;
							}
							else
							{
								num3 = 1354352203;
								num4 = num3;
							}
							continue;
							IL_0053:
							if (buttons[num2].elementIdentifier == elementIdentifier.id)
							{
								return ControllerElementType.Button;
							}
							num2++;
							num3 = 1354352205;
						}
						goto IL_0031;
						IL_0031:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							break;
						}
						num++;
						num3 = 1354352200;
						goto IL_000c;
					}
					return ControllerElementType.Axis;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					while (num < axisCount)
					{
						while (true)
						{
							IL_0077:
							int num2;
							if (axes[num].elementIdentifier == elementIdentifier.id)
							{
								switch (axes[num].sourceType)
								{
								case HardwareElementSourceType.Custom:
									break;
								case HardwareElementSourceType.Button:
									axisRange = AxisRange.Positive;
									return true;
								default:
									throw new NotImplementedException();
								case HardwareElementSourceType.Axis:
									goto IL_00ce;
								}
								num2 = 1223414320;
								goto IL_000c;
							}
							goto IL_005c;
							IL_000c:
							while (true)
							{
								switch (num2 ^ 0x48EBD235)
								{
								case 0:
									num2 = 1223414326;
									continue;
								case 7:
									break;
								case 6:
									goto end_IL_000c;
								case 1:
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 1223414327;
									continue;
								case 3:
									goto IL_0077;
								case 2:
									return true;
								case 5:
									goto IL_00ce;
								default:
									goto end_IL_0077;
								}
								int num3;
								if (axes[num].invert)
								{
									num2 = 1223414324;
									num3 = num2;
								}
								else
								{
									num2 = 1223414327;
									num3 = num2;
								}
								continue;
								end_IL_000c:
								break;
							}
							goto IL_005c;
							IL_00ce:
							axisRange = axes[num].sourceAxisRange;
							num2 = 1223414322;
							goto IL_000c;
							IL_005c:
							num++;
							num2 = 1223414321;
							goto IL_000c;
							continue;
							end_IL_0077:
							break;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Element : IDeepCloneable
			{
				public int elementIdentifier;

				public HardwareElementSourceType sourceType;

				public XInputButton sourceButton;

				public XInputAxis sourceAxis;

				public float axisDeadZone;

				public abstract object DeepClone();

				internal virtual void CopyVars(Element destination)
				{
					destination.elementIdentifier = elementIdentifier;
					destination.sourceType = sourceType;
					destination.sourceButton = sourceButton;
					destination.sourceAxis = sourceAxis;
					destination.axisDeadZone = axisDeadZone;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Button : Element
			{
				public Pole sourceAxisPole;

				public HardwareButtonInfo buttonInfo;

				public Button()
				{
					sourceType = HardwareElementSourceType.Button;
				}

				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Button button = destination as Button;
					if (button == null)
					{
						goto IL_0011;
					}
					goto IL_003b;
					IL_0011:
					int num = 1879147713;
					goto IL_0016;
					IL_0016:
					switch (num ^ 0x700184C0)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						return;
					case 0:
						goto IL_003b;
					case 2:
						return;
					}
					goto IL_0011;
					IL_003b:
					button.sourceAxisPole = sourceAxisPole;
					button.buttonInfo = MiscTools.DeepClone(buttonInfo);
					num = 1879147714;
					goto IL_0016;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Axis : Element
			{
				public bool invert;

				public Pole buttonAxisContribution;

				public AxisRange sourceAxisRange;

				public bool calibrateAxis;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public AxisCalibrationInfoEntry[] alternateCalibrations;

				public HardwareAxisInfo axisInfo;

				public Axis()
				{
					sourceType = HardwareElementSourceType.Axis;
				}

				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Axis axis = destination as Axis;
					while (true)
					{
						int num = 118950834;
						while (true)
						{
							switch (num ^ 0x7170BB0)
							{
							case 4:
								break;
							case 3:
								axis.axisInfo = MiscTools.DeepClone(axisInfo);
								num = 118950832;
								continue;
							case 1:
								axis.invert = invert;
								axis.buttonAxisContribution = buttonAxisContribution;
								num = 118950837;
								continue;
							case 5:
								axis.sourceAxisRange = sourceAxisRange;
								axis.calibrateAxis = calibrateAxis;
								axis.axisZero = axisZero;
								axis.axisMin = axisMin;
								axis.axisMax = axisMax;
								num = 118950835;
								continue;
							case 2:
								if (axis == null)
								{
									return;
								}
								goto case 1;
							default:
								axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
								return;
							}
							break;
						}
					}
				}
			}

			private sealed class VZVWhQDiaLvJKhNaNDSBdPnseFMM : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_XInput_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int MSPgoQjIpPBaxDzTmISLdHRyeqFq;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
					{
						goto IL_0012;
					}
					goto IL_0052;
					IL_0012:
					int num = 2101797137;
					goto IL_0017;
					IL_0017:
					VZVWhQDiaLvJKhNaNDSBdPnseFMM vZVWhQDiaLvJKhNaNDSBdPnseFMM = default(VZVWhQDiaLvJKhNaNDSBdPnseFMM);
					while (true)
					{
						switch (num ^ 0x7D46E113)
						{
						case 0:
							break;
						case 2:
							if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
							{
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
								vZVWhQDiaLvJKhNaNDSBdPnseFMM = this;
								num = 2101797136;
								continue;
							}
							goto IL_0052;
						case 4:
							goto IL_0052;
						case 1:
							vZVWhQDiaLvJKhNaNDSBdPnseFMM.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
							num = 2101797136;
							continue;
						default:
							return vZVWhQDiaLvJKhNaNDSBdPnseFMM;
						}
						break;
					}
					goto IL_0012;
					IL_0052:
					vZVWhQDiaLvJKhNaNDSBdPnseFMM = new VZVWhQDiaLvJKhNaNDSBdPnseFMM(0);
					num = 2101797138;
					goto IL_0017;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
					while (true)
					{
						int num = 392761634;
						while (true)
						{
							switch (num ^ 0x17691120)
							{
							case 3:
								break;
							case 2:
								switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
								{
								default:
									num = 392761638;
									continue;
								case 0:
									break;
								case 1:
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
									MSPgoQjIpPBaxDzTmISLdHRyeqFq++;
									num = 392761633;
									continue;
								}
								goto case 8;
							case 4:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes[MSPgoQjIpPBaxDzTmISLdHRyeqFq];
								num = 392761637;
								continue;
							case 0:
								MSPgoQjIpPBaxDzTmISLdHRyeqFq = 0;
								num = 392761639;
								continue;
							case 8:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements != null)
								{
									int num3;
									if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes != null)
									{
										num = 392761632;
										num3 = num;
									}
									else
									{
										num = 392761638;
										num3 = num;
									}
									continue;
								}
								goto default;
							case 1:
							{
								int num2;
								if (MSPgoQjIpPBaxDzTmISLdHRyeqFq >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes.Length)
								{
									num = 392761638;
									num2 = num;
								}
								else
								{
									num = 392761636;
									num2 = num;
								}
								continue;
							}
							case 5:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							case 7:
								num = 392761633;
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
				public VZVWhQDiaLvJKhNaNDSBdPnseFMM(int _003C_003E1__state)
				{
					while (true)
					{
						int num = 499633902;
						while (true)
						{
							switch (num ^ 0x1DC7CEEC)
							{
							case 0:
								break;
							default:
								return;
							case 2:
								goto IL_0024;
							case 1:
								return;
							}
							break;
							IL_0024:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
							iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
							num = 499633901;
						}
					}
				}
			}

			private sealed class sWShxPIhkSinPbfPQKQzbTPzKUY : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_XInput_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int dlWDYQiJImjJjyjgcyJuJJqCaEtA;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					sWShxPIhkSinPbfPQKQzbTPzKUY sWShxPIhkSinPbfPQKQzbTPzKUY2;
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						sWShxPIhkSinPbfPQKQzbTPzKUY2 = this;
					}
					else
					{
						while (true)
						{
							sWShxPIhkSinPbfPQKQzbTPzKUY2 = new sWShxPIhkSinPbfPQKQzbTPzKUY(0);
							int num = 1853494202;
							while (true)
							{
								switch (num ^ 0x6E7A13B8)
								{
								case 3:
									num = 1853494201;
									continue;
								case 1:
									break;
								case 2:
									sWShxPIhkSinPbfPQKQzbTPzKUY2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
									num = 1853494200;
									continue;
								default:
									goto end_IL_0049;
								}
								break;
							}
							continue;
							end_IL_0049:
							break;
						}
					}
					return sWShxPIhkSinPbfPQKQzbTPzKUY2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
					while (true)
					{
						int num = 147790176;
						while (true)
						{
							switch (num ^ 0x8CF1965)
							{
							case 2:
								break;
							case 6:
							{
								int num2;
								if (dlWDYQiJImjJjyjgcyJuJJqCaEtA < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons.Length)
								{
									num = 147790181;
									num2 = num;
								}
								else
								{
									num = 147790180;
									num2 = num;
								}
								continue;
							}
							case 3:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements != null && ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons != null)
								{
									dlWDYQiJImjJjyjgcyJuJJqCaEtA = 0;
									num = 147790179;
									continue;
								}
								goto default;
							case 4:
								return true;
							case 5:
								switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
								{
								case 0:
									break;
								case 1:
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
									dlWDYQiJImjJjyjgcyJuJJqCaEtA++;
									num = 147790179;
									continue;
								default:
									num = 147790180;
									continue;
								}
								goto case 3;
							case 0:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons[dlWDYQiJImjJjyjgcyJuJJqCaEtA];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 147790177;
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
				public sWShxPIhkSinPbfPQKQzbTPzKUY(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public override int assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			public override int assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.ovCPWlBsEvuzkIMqmgTZqxNDFgV;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			internal override bool hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedAxisCount == 0 && assignedButtonCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			internal override bool disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			internal override bool isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						goto IL_0008;
					}
					int num;
					if (matchingCriteria == null)
					{
						num = 717168208;
						goto IL_000d;
					}
					return matchingCriteria.isAllowed;
					IL_0008:
					num = 717168211;
					goto IL_000d;
					IL_000d:
					switch (num ^ 0x2ABF1E51)
					{
					case 0:
						break;
					case 2:
						return false;
					default:
						return false;
					}
					goto IL_0008;
				}
			}

			internal override Elements_Base elements_base
			{
				get
				{
					return elements;
				}
			}

			internal override IList<Platform> variants_base
			{
				get
				{
					return null;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			internal IEnumerable<Axis> IterateAxes()
			{
				VZVWhQDiaLvJKhNaNDSBdPnseFMM vZVWhQDiaLvJKhNaNDSBdPnseFMM = new VZVWhQDiaLvJKhNaNDSBdPnseFMM(-2);
				while (true)
				{
					int num = -1409108332;
					while (true)
					{
						switch (num ^ -1409108330)
						{
						case 0:
							break;
						case 2:
							goto IL_0026;
						default:
							return vZVWhQDiaLvJKhNaNDSBdPnseFMM;
						}
						break;
						IL_0026:
						vZVWhQDiaLvJKhNaNDSBdPnseFMM.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
						num = -1409108329;
					}
				}
			}

			internal IEnumerable<Button> IterateButtons()
			{
				sWShxPIhkSinPbfPQKQzbTPzKUY sWShxPIhkSinPbfPQKQzbTPzKUY2 = new sWShxPIhkSinPbfPQKQzbTPzKUY(-2);
				sWShxPIhkSinPbfPQKQzbTPzKUY2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return sWShxPIhkSinPbfPQKQzbTPzKUY2;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				int num = 0;
				int elementIdentifier = default(int);
				while (true)
				{
					int num2;
					int num3;
					if (num >= array.Length)
					{
						num2 = 2049675754;
						num3 = num2;
					}
					else
					{
						num2 = 2049675756;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x7A2B91EF)
						{
						case 7:
							num2 = 2049675756;
							continue;
						case 4:
						{
							int num5;
							if (elementIdentifier < identifiers.Length)
							{
								num2 = 2049675751;
								num5 = num2;
							}
							else
							{
								num2 = 2049675753;
								num5 = num2;
							}
							continue;
						}
						case 8:
							array[num] = identifiers[elementIdentifier].name;
							num2 = 2049675758;
							continue;
						case 0:
							break;
						case 2:
						{
							int num4;
							if (elementIdentifier >= 0)
							{
								num2 = 2049675755;
								num4 = num2;
							}
							else
							{
								num2 = 2049675753;
								num4 = num2;
							}
							continue;
						}
						case 1:
							num++;
							num2 = 2049675759;
							continue;
						case 6:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = 2049675758;
							continue;
						case 3:
							elementIdentifier = elements.axes[num].elementIdentifier;
							num2 = 2049675757;
							continue;
						default:
							return array;
						}
						break;
					}
				}
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				string[] array = default(string[]);
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					int num = 1109156594;
					while (true)
					{
						switch (num ^ 0x421C62F6)
						{
						case 2:
							break;
						case 7:
							array[num2] = identifiers[num3].name;
							num = 1109156599;
							continue;
						case 5:
						{
							int elementIdentifier = elements.buttons[num2].elementIdentifier;
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							if (num3 >= 0)
							{
								int num4;
								if (num3 >= identifiers.Length)
								{
									num = 1109156592;
									num4 = num;
								}
								else
								{
									num = 1109156593;
									num4 = num;
								}
								continue;
							}
							goto case 6;
						}
						case 4:
							if (identifiers.Length < buttonCount)
							{
								Logger.LogError("You have too few element identifiers!");
								return new string[0];
							}
							array = new string[buttonCount];
							num2 = 0;
							num = 1109156598;
							continue;
						case 6:
							Logger.LogError("Element identifier index is out of bounds!");
							num = 1109156597;
							continue;
						case 1:
							num2++;
							num = 1109156598;
							continue;
						case 3:
							num = 1109156599;
							continue;
						default:
							if (num2 >= array.Length)
							{
								return array;
							}
							goto case 5;
						}
						break;
					}
				}
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				IEnumerator<Axis> enumerator = IterateAxes().GetEnumerator();
				bool result = default(bool);
				try
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Axis current = enumerator.Current;
							if (current.elementIdentifier != elementIdentifierId)
							{
								break;
							}
							result = true;
							int num = -512260398;
							while (true)
							{
								switch (num ^ -512260398)
								{
								case 2:
									num = -512260399;
									continue;
								case 3:
									break;
								default:
									goto end_IL_0030;
								case 0:
									goto IL_0140;
								}
								break;
							}
							continue;
							end_IL_0030:
							break;
						}
					}
				}
				finally
				{
					if (enumerator != null)
					{
						while (true)
						{
							IL_0062:
							int num2 = -512260400;
							while (true)
							{
								switch (num2 ^ -512260398)
								{
								case 0:
									break;
								default:
									goto end_IL_0067;
								case 2:
									goto IL_0080;
								case 1:
									goto end_IL_0067;
								}
								goto IL_0062;
								IL_0080:
								enumerator.Dispose();
								num2 = -512260397;
								continue;
								end_IL_0067:
								break;
							}
							break;
						}
					}
				}
				IEnumerator<Button> enumerator2 = IterateButtons().GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Button current2 = enumerator2.Current;
							int num3 = -512260399;
							while (true)
							{
								switch (num3 ^ -512260398)
								{
								case 4:
									num3 = -512260400;
									continue;
								case 2:
									break;
								case 3:
									goto IL_00d6;
								case 5:
									result = true;
									num3 = -512260398;
									continue;
								default:
									goto end_IL_00c7;
								case 0:
									goto IL_0140;
								}
								break;
								IL_00d6:
								int num4;
								if (current2.elementIdentifier != elementIdentifierId)
								{
									num3 = -512260397;
									num4 = num3;
								}
								else
								{
									num3 = -512260393;
									num4 = num3;
								}
							}
							continue;
							end_IL_00c7:
							break;
						}
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						while (true)
						{
							IL_0111:
							int num5 = -512260400;
							while (true)
							{
								switch (num5 ^ -512260398)
								{
								case 0:
									break;
								default:
									goto end_IL_0116;
								case 2:
									goto IL_012f;
								case 1:
									goto end_IL_0116;
								}
								goto IL_0111;
								IL_012f:
								enumerator2.Dispose();
								num5 = -512260397;
								continue;
								end_IL_0116:
								break;
							}
							break;
						}
					}
				}
				return false;
				IL_0140:
				return result;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				while (true)
				{
					int num = -2118638322;
					while (true)
					{
						switch (num ^ -2118638321)
						{
						case 0:
							break;
						case 1:
							goto IL_002b;
						default:
						{
							int num2 = 0;
							using (IEnumerator<Button> enumerator = IterateButtons().GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										Button current = enumerator.Current;
										int num3 = -2118638322;
										while (true)
										{
											switch (num3 ^ -2118638321)
											{
											case 0:
												num3 = -2118638325;
												continue;
											case 4:
												break;
											case 2:
												num2++;
												num3 = -2118638324;
												continue;
											case 1:
												buttons[num2] = current.elementIdentifier;
												num3 = -2118638323;
												continue;
											default:
												goto end_IL_0075;
											}
											break;
										}
										continue;
										end_IL_0075:
										break;
									}
								}
							}
							num2 = 0;
							using (IEnumerator<Axis> enumerator2 = IterateAxes().GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									while (true)
									{
										Axis current2 = enumerator2.Current;
										axes[num2] = current2.elementIdentifier;
										int num4 = -2118638321;
										while (true)
										{
											switch (num4 ^ -2118638321)
											{
											case 2:
												num4 = -2118638322;
												continue;
											case 1:
												break;
											case 0:
												num2++;
												num4 = -2118638324;
												continue;
											default:
												goto end_IL_00e6;
											}
											break;
										}
										continue;
										end_IL_00e6:
										break;
									}
								}
								return;
							}
						}
						}
						break;
						IL_002b:
						axes = new int[assignedAxisCount];
						num = -2118638323;
					}
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					goto IL_000a;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				int num = 0;
				int num2 = 1159626420;
				goto IL_000f;
				IL_000f:
				while (true)
				{
					switch (num2 ^ 0x451E7EB1)
					{
					case 8:
						break;
					case 6:
						return null;
					case 0:
						if (Axes_orig[num].calibrateAxis)
						{
							array[num].zero = axes_orig[num].axisZero;
							array[num].min = axes_orig[num].axisMin;
							array[num].max = axes_orig[num].axisMax;
							num2 = 1159626421;
							continue;
						}
						goto case 9;
					case 3:
					{
						int num3;
						if (axes_orig[num].sourceType != HardwareElementSourceType.Button)
						{
							num2 = 1159626422;
							num3 = num2;
						}
						else
						{
							num2 = 1159626427;
							num3 = num2;
						}
						continue;
					}
					case 7:
						throw new NotImplementedException();
					case 4:
						num2 = 1159626424;
						continue;
					case 9:
						array[num].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num].alternateCalibrations, true);
						num++;
						num2 = 1159626420;
						continue;
					case 10:
						array[num] = AxisCalibrationData.Default;
						num2 = 1159626424;
						continue;
					case 1:
						array[num] = AxisCalibrationData.Default;
						array[num].invert = axes_orig[num].invert;
						array[num].deadZone = axes_orig[num].axisDeadZone;
						num2 = 1159626417;
						continue;
					case 2:
						if (axes_orig[num].sourceType != HardwareElementSourceType.Axis)
						{
							int num4;
							if (axes_orig[num].sourceType == HardwareElementSourceType.Custom)
							{
								num2 = 1159626416;
								num4 = num2;
							}
							else
							{
								num2 = 1159626418;
								num4 = num2;
							}
							continue;
						}
						goto case 1;
					default:
						if (num >= axes_orig.Length)
						{
							return array;
						}
						goto case 2;
					}
					break;
				}
				goto IL_000a;
				IL_000a:
				num2 = 1159626423;
				goto IL_000f;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				int num2 = default(int);
				while (true)
				{
					int num = -981607182;
					while (true)
					{
						switch (num ^ -981607183)
						{
						case 5:
							break;
						case 0:
							throw new Exception();
						case 7:
							axisRanges = new AxisRange[Axes_orig.Length];
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = -981607177;
							continue;
						case 3:
							if (Axes_orig == null)
							{
								return;
							}
							goto case 7;
						case 2:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -981607184;
							continue;
						case 8:
							if (Axes_orig[num2].sourceType == HardwareElementSourceType.Button)
							{
								axisRanges[num2] = AxisRange.Full;
								num = -981607184;
								continue;
							}
							goto case 0;
						case 9:
						{
							int num4;
							if (Axes_orig[num2].sourceType == HardwareElementSourceType.Custom)
							{
								num = -981607181;
								num4 = num;
							}
							else
							{
								num = -981607175;
								num4 = num;
							}
							continue;
						}
						case 1:
							num2++;
							num = -981607177;
							continue;
						case 4:
						{
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							int num3;
							if (Axes_orig[num2].sourceType == HardwareElementSourceType.Axis)
							{
								num = -981607181;
								num3 = num;
							}
							else
							{
								num = -981607176;
								num3 = num;
							}
							continue;
						}
						default:
							if (num2 >= Axes_orig.Length)
							{
								return;
							}
							goto case 4;
						}
						break;
					}
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				int num2 = default(int);
				while (true)
				{
					int num = -1299778177;
					while (true)
					{
						switch (num ^ -1299778178)
						{
						case 3:
							break;
						case 2:
							num = -1299778183;
							continue;
						case 4:
							return;
						case 6:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
							num = -1299778178;
							continue;
						case 1:
						{
							int num3;
							if (Buttons_orig == null)
							{
								num = -1299778182;
								num3 = num;
							}
							else
							{
								num = -1299778181;
								num3 = num;
							}
							continue;
						}
						case 0:
							num2++;
							num = -1299778183;
							continue;
						case 5:
							buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
							num2 = 0;
							num = -1299778180;
							continue;
						default:
							if (num2 >= Buttons_orig.Length)
							{
								return;
							}
							goto case 6;
						}
						break;
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_XInput_Base platform_XInput_Base = new Platform_XInput_Base();
				CopyVars(platform_XInput_Base);
				return platform_XInput_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				Platform_XInput_Base platform_XInput_Base = destination as Platform_XInput_Base;
				while (true)
				{
					int num = -1952260054;
					while (true)
					{
						switch (num ^ -1952260050)
						{
						case 3:
							break;
						default:
							return;
						case 0:
							platform_XInput_Base.elements = MiscTools.DeepClone(elements);
							num = -1952260052;
							continue;
						case 1:
							platform_XInput_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
							num = -1952260050;
							continue;
						case 4:
							if (platform_XInput_Base == null)
							{
								return;
							}
							goto case 1;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_XInput : Platform_XInput_Base
		{
			public Platform_XInput_Base[] variants;

			internal override IList<Platform> variants_base
			{
				get
				{
					return variants;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					goto IL_0010;
				}
				int num;
				int num2;
				if (base.hasVariants)
				{
					num = -911772510;
					num2 = num;
				}
				else
				{
					num = -911772507;
					num2 = num;
				}
				goto IL_0015;
				IL_0010:
				num = -911772509;
				goto IL_0015;
				IL_0015:
				int num3 = default(int);
				while (true)
				{
					switch (num ^ -911772505)
					{
					case 0:
						break;
					case 3:
					{
						int variantIndex2;
						if (variants[num3] != null && variants[num3].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
						{
							variantIndex = num3;
							return true;
						}
						num3++;
						num = -911772506;
						continue;
					}
					case 5:
						num3 = 0;
						num = -911772506;
						continue;
					case 1:
					{
						int num4;
						if (num3 >= variants.Length)
						{
							num = -911772507;
							num4 = num;
						}
						else
						{
							num = -911772508;
							num4 = num;
						}
						continue;
					}
					case 4:
						return true;
					default:
						return false;
					}
					break;
				}
				goto IL_0010;
			}

			public override object DeepClone()
			{
				Platform_XInput platform_XInput = new Platform_XInput();
				CopyVars(platform_XInput);
				return platform_XInput;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_XInput platform_XInput = destination as Platform_XInput;
				if (platform_XInput != null)
				{
					platform_XInput.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_OSX_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				[Serializable]
				public sealed class ElementCount : ElementCount_Base
				{
					public int hatCount;

					public override object DeepClone()
					{
						ElementCount elementCount = new ElementCount();
						CopyVars(elementCount);
						return elementCount;
					}

					internal override void CopyVars(ElementCount_Base P_0)
					{
						base.CopyVars(P_0);
						ElementCount elementCount = P_0 as ElementCount;
						while (true)
						{
							switch (0x797016D7 ^ 0x797016D6)
							{
							case 2:
								continue;
							case 1:
								if (elementCount == null)
								{
									return;
								}
								break;
							}
							break;
						}
						elementCount.hatCount = hatCount;
					}

					internal override bool Matches(BridgedControllerHWInfo P_0)
					{
						if (!base.Matches(P_0))
						{
							return false;
						}
						if (hatCount >= 0)
						{
							return hatCount == P_0.hardwareHatCount;
						}
						return true;
					}
				}

				public int hatCount;

				public ElementCount[] alternateElementCounts;

				public bool productName_useRegex;

				public string[] productName;

				public string[] manufacturer;

				public int[] productId;

				public int[] vendorId;

				internal override bool hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (productName != null && productName.Length > 0)
						{
							return true;
						}
						if (productId != null && productId.Length > 0 && vendorId != null && vendorId.Length > 0)
						{
							return true;
						}
						return false;
					}
				}

				internal override bool isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						return true;
					}
				}

				internal override int alternateElementCount
				{
					get
					{
						if (alternateElementCounts == null)
						{
							return 0;
						}
						return alternateElementCounts.Length;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock)
					{
						goto IL_000b;
					}
					goto IL_009d;
					IL_000b:
					int num = 1041272910;
					goto IL_0010;
					IL_0010:
					int num2 = default(int);
					bool flag = default(bool);
					string name = default(string);
					while (true)
					{
						switch (num ^ 0x3E109048)
						{
						case 4:
							break;
						case 0:
							num2++;
							num = 1041272905;
							continue;
						case 1:
							if (num2 >= vendorId.Length)
							{
								goto IL_0056;
							}
							goto case 2;
						case 3:
							flag = false;
							num2 = 0;
							num = 1041272905;
							continue;
						case 7:
							return true;
						case 6:
							goto IL_00b6;
						case 2:
							if (vendorId[num2] == bridgedControllerHWInfo.hw_vendorId && num2 < productId.Length && productId[num2] == bridgedControllerHWInfo.hw_productId)
							{
								flag = true;
								num = 1041272904;
								continue;
							}
							goto case 0;
						default:
							goto IL_0110;
						}
						break;
						IL_0110:
						if (!ProductNameMatches(name))
						{
							return false;
						}
						goto IL_011b;
						IL_011b:
						return true;
						IL_00b6:
						if (hasData && isAllowed)
						{
							num = 1041272911;
							continue;
						}
						goto IL_009d;
						IL_0056:
						if (!flag)
						{
							return false;
						}
						if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
						{
							name = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
							num = 1041272909;
							continue;
						}
						goto IL_011b;
					}
					goto IL_000b;
					IL_009d:
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (strictMatch)
					{
						num = 1041272907;
						goto IL_0010;
					}
					string text = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
					text = text.Trim();
					if (!ProductNameMatches(text))
					{
						return false;
					}
					return true;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					if (alternateElementCounts == null || index < 0 || index >= alternateElementCounts.Length)
					{
						return null;
					}
					return alternateElementCounts[index];
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						return false;
					}
					if (alternateMatched)
					{
						return true;
					}
					if (hatCount >= 0)
					{
						return bridgedControllerHWInfo.hardwareHatCount == hatCount;
					}
					return true;
				}

				private bool ProductNameMatches(string name)
				{
					if (productName == null)
					{
						return false;
					}
					int num = 0;
					while (true)
					{
						int num2 = 1557902620;
						while (true)
						{
							switch (num2 ^ 0x5CDBB51D)
							{
							case 2:
								break;
							case 1:
								num2 = 1557902622;
								continue;
							case 0:
							{
								string text = ((productName[num] == null) ? string.Empty : productName[num]);
								text = text.Trim();
								if (MatchingCriteria_Base.StringMatches(name, text, productName_useRegex))
								{
									return true;
								}
								num++;
								num2 = 1557902622;
								continue;
							}
							default:
								if (num >= productName.Length)
								{
									return false;
								}
								goto case 0;
							}
							break;
						}
					}
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					MatchingCriteria matchingCriteria = destination as MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					while (true)
					{
						matchingCriteria.hatCount = hatCount;
						int num = 1316001450;
						while (true)
						{
							switch (num ^ 0x4E7096AA)
							{
							case 3:
								num = 1316001455;
								continue;
							case 5:
								break;
							case 2:
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
								num = 1316001451;
								continue;
							case 0:
								matchingCriteria.productName_useRegex = productName_useRegex;
								num = 1316001448;
								continue;
							case 1:
								matchingCriteria.productId = ArrayTools.ShallowCopy(productId);
								num = 1316001454;
								continue;
							default:
								matchingCriteria.vendorId = ArrayTools.ShallowCopy(vendorId);
								return;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class PPaUiEUmhJTEEQNEokzvepQqPTm : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
				{
					private Axis RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public Elements ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public Axis xcaQwsKnuVTVwSqtQugXSMaysdY;

					public Axis[] fwdMoIvljYAjJQTHvFslgBsuUrI;

					public int eNNIOUoLJjTEJgagrOTPVEfdZhO;

					Axis IEnumerator<Axis>.Current
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
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
						{
							goto IL_0012;
						}
						goto IL_004e;
						IL_0012:
						int num = -1123666949;
						goto IL_0017;
						IL_0017:
						PPaUiEUmhJTEEQNEokzvepQqPTm pPaUiEUmhJTEEQNEokzvepQqPTm = default(PPaUiEUmhJTEEQNEokzvepQqPTm);
						while (true)
						{
							switch (num ^ -1123666951)
							{
							case 3:
								break;
							case 2:
								if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
								{
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
									pPaUiEUmhJTEEQNEokzvepQqPTm = this;
									num = -1123666951;
									continue;
								}
								goto IL_004e;
							case 1:
								goto IL_004e;
							default:
								return pPaUiEUmhJTEEQNEokzvepQqPTm;
							}
							break;
						}
						goto IL_0012;
						IL_004e:
						pPaUiEUmhJTEEQNEokzvepQqPTm = new PPaUiEUmhJTEEQNEokzvepQqPTm(0);
						pPaUiEUmhJTEEQNEokzvepQqPTm.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = -1123666951;
						goto IL_0017;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							int num;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 2:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 2090255471;
								goto IL_0023;
							case 0:
								goto IL_0091;
								IL_0023:
								while (true)
								{
									switch (num ^ 0x7C96C46F)
									{
									case 7:
										num = 2090255462;
										continue;
									case 2:
										break;
									case 4:
										num = 2090255470;
										continue;
									case 3:
										RDkWcsTpvDaNZojjIZONnoEBXPC = xcaQwsKnuVTVwSqtQugXSMaysdY;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										return true;
									case 9:
										goto IL_0091;
									case 6:
										fwdMoIvljYAjJQTHvFslgBsuUrI = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.axes;
										eNNIOUoLJjTEJgagrOTPVEfdZhO = 0;
										num = 2090255467;
										continue;
									case 0:
										eNNIOUoLJjTEJgagrOTPVEfdZhO++;
										num = 2090255470;
										continue;
									case 1:
										if (eNNIOUoLJjTEJgagrOTPVEfdZhO >= fwdMoIvljYAjJQTHvFslgBsuUrI.Length)
										{
											cOLRTBRTldDteWWhgJzLWCVwKdm();
											num = 2090255466;
											continue;
										}
										goto case 8;
									case 8:
										xcaQwsKnuVTVwSqtQugXSMaysdY = fwdMoIvljYAjJQTHvFslgBsuUrI[eNNIOUoLJjTEJgagrOTPVEfdZhO];
										num = 2090255468;
										continue;
									default:
										goto end_IL_0008;
									}
									break;
								}
								goto case 2;
								IL_0091:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.axes == null)
								{
									break;
								}
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 2090255465;
								goto IL_0023;
								end_IL_0008:
								break;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
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
						int num;
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						default:
							num = 1295016208;
							goto IL_001c;
						case 1:
						case 2:
							goto IL_0041;
							IL_001c:
							switch (num ^ 0x4D306112)
							{
							case 0:
								break;
							default:
								return;
							case 2:
								return;
							case 3:
								goto IL_0041;
							case 1:
								return;
							}
							goto default;
							IL_0041:
							cOLRTBRTldDteWWhgJzLWCVwKdm();
							num = 1295016211;
							goto IL_001c;
						}
					}

					[DebuggerHidden]
					public PPaUiEUmhJTEEQNEokzvepQqPTm(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void cOLRTBRTldDteWWhgJzLWCVwKdm()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					}
				}

				private sealed class pHiZzhtzljJYWfSSuoHIprjHIXC : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
				{
					private Button RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public Elements ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public Button nCNQYhdHlAFgfOlDzXNNNsgzHuN;

					public Button[] kLMMbjMGmzewiwsYMcfVmygfHWE;

					public int gHVuxPHaZDHJpDaLxPGcTnJSjIy;

					Button IEnumerator<Button>.Current
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
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						pHiZzhtzljJYWfSSuoHIprjHIXC pHiZzhtzljJYWfSSuoHIprjHIXC2;
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							pHiZzhtzljJYWfSSuoHIprjHIXC2 = this;
						}
						else
						{
							while (true)
							{
								pHiZzhtzljJYWfSSuoHIprjHIXC2 = new pHiZzhtzljJYWfSSuoHIprjHIXC(0);
								pHiZzhtzljJYWfSSuoHIprjHIXC2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
								int num = -1182524468;
								while (true)
								{
									switch (num ^ -1182524468)
									{
									case 2:
										num = -1182524467;
										continue;
									case 1:
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
						return pHiZzhtzljJYWfSSuoHIprjHIXC2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							int num;
							int num2;
							switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							default:
								num = 1874389481;
								goto IL_001e;
							case 2:
								goto IL_00ce;
							case 0:
								goto IL_00df;
							case 1:
								break;
								IL_001e:
								while (true)
								{
									switch (num ^ 0x6FB8E9E8)
									{
									case 4:
										break;
									case 1:
										num = 1874389486;
										continue;
									case 5:
										gHVuxPHaZDHJpDaLxPGcTnJSjIy++;
										num = 1874389483;
										continue;
									case 0:
										nCNQYhdHlAFgfOlDzXNNNsgzHuN = kLMMbjMGmzewiwsYMcfVmygfHWE[gHVuxPHaZDHJpDaLxPGcTnJSjIy];
										RDkWcsTpvDaNZojjIZONnoEBXPC = nCNQYhdHlAFgfOlDzXNNNsgzHuN;
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
										return true;
									case 8:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
										kLMMbjMGmzewiwsYMcfVmygfHWE = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttons;
										gHVuxPHaZDHJpDaLxPGcTnJSjIy = 0;
										num = 1874389483;
										continue;
									case 7:
										goto IL_00ce;
									case 2:
										goto IL_00df;
									case 3:
										if (gHVuxPHaZDHJpDaLxPGcTnJSjIy >= kLMMbjMGmzewiwsYMcfVmygfHWE.Length)
										{
											ajjPgVwWkpjLgxeHPIQtjqVjNqeM();
											num = 1874389486;
											continue;
										}
										goto case 0;
									default:
										goto end_IL_0008;
									}
									break;
								}
								goto default;
								IL_00df:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttons != null)
								{
									num = 1874389472;
									num2 = num;
								}
								else
								{
									num = 1874389486;
									num2 = num;
								}
								goto IL_001e;
								IL_00ce:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 1874389485;
								goto IL_001e;
								end_IL_0008:
								break;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
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
						int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
						while (true)
						{
							int num = 1371557377;
							while (true)
							{
								switch (num ^ 0x51C04E02)
								{
								case 2:
									break;
								case 3:
									switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
									{
									default:
										goto IL_0039;
									case 1:
									case 2:
										break;
									}
									goto default;
								case 0:
									return;
								default:
									ajjPgVwWkpjLgxeHPIQtjqVjNqeM();
									return;
								}
								break;
								IL_0039:
								num = 1371557378;
							}
						}
					}

					[DebuggerHidden]
					public pHiZzhtzljJYWfSSuoHIprjHIXC(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}

					private void ajjPgVwWkpjLgxeHPIQtjqVjNqeM()
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				public override int axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				public IEnumerable<Axis> IterateAxes()
				{
					PPaUiEUmhJTEEQNEokzvepQqPTm pPaUiEUmhJTEEQNEokzvepQqPTm = new PPaUiEUmhJTEEQNEokzvepQqPTm(-2);
					pPaUiEUmhJTEEQNEokzvepQqPTm.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return pPaUiEUmhJTEEQNEokzvepQqPTm;
				}

				public IEnumerable<Button> IterateButtons()
				{
					pHiZzhtzljJYWfSSuoHIprjHIXC pHiZzhtzljJYWfSSuoHIprjHIXC2 = new pHiZzhtzljJYWfSSuoHIprjHIXC(-2);
					pHiZzhtzljJYWfSSuoHIprjHIXC2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					return pHiZzhtzljJYWfSSuoHIprjHIXC2;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					Elements elements = default(Elements);
					while (true)
					{
						switch (-661693659 ^ -661693660)
						{
						case 0:
							continue;
						case 1:
							elements = destination as Elements;
							if (elements == null)
							{
								return;
							}
							break;
						}
						break;
					}
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					int num = 0;
					int num3 = default(int);
					while (true)
					{
						int num2 = -344709677;
						while (true)
						{
							switch (num2 ^ -344709680)
							{
							case 6:
								break;
							case 3:
								num2 = -344709679;
								continue;
							case 5:
								if (buttons[num3].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num3++;
								num2 = -344709673;
								continue;
							case 0:
								num2 = -344709673;
								continue;
							case 4:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									num2 = -344709678;
									continue;
								}
								num++;
								num2 = -344709679;
								continue;
							case 2:
								return ControllerElementType.Axis;
							case 1:
								if (num >= axisCount)
								{
									num3 = 0;
									num2 = -344709680;
									continue;
								}
								goto case 4;
							default:
								if (num3 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								goto case 5;
							}
							break;
						}
					}
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					HardwareElementSourceTypeWithHat sourceType = default(HardwareElementSourceTypeWithHat);
					while (true)
					{
						int num2;
						int num3;
						if (num < axisCount)
						{
							num2 = 2089670818;
							num3 = num2;
						}
						else
						{
							num2 = 2089670823;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x7C8DD8A0)
							{
							case 0:
								num2 = 2089670818;
								continue;
							case 1:
								axisRange = InputTools.InvertAxisRange(axisRange);
								num2 = 2089670826;
								continue;
							case 3:
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 2089670825;
									continue;
								}
								goto case 9;
							case 4:
								num++;
								num2 = 2089670827;
								continue;
							case 2:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									sourceType = axes[num].sourceType;
									num2 = 2089670822;
									continue;
								}
								goto case 4;
							case 11:
								break;
							case 10:
								return true;
							case 6:
								switch (sourceType)
								{
								case HardwareElementSourceTypeWithHat.Button:
									axisRange = AxisRange.Positive;
									return true;
								case HardwareElementSourceTypeWithHat.Hat:
									axisRange = axes[num].sourceHatRange;
									num2 = 2089670819;
									continue;
								case HardwareElementSourceTypeWithHat.Custom:
									num2 = 2089670824;
									continue;
								default:
									throw new NotImplementedException();
								case HardwareElementSourceTypeWithHat.Axis:
									break;
								}
								goto case 8;
							case 9:
								return true;
							case 7:
								axisRange = AxisRange.Full;
								num2 = 2089670821;
								continue;
							case 8:
							{
								axisRange = axes[num].sourceAxisRange;
								int num4;
								if (!axes[num].invert)
								{
									num2 = 2089670826;
									num4 = num2;
								}
								else
								{
									num2 = 2089670817;
									num4 = num2;
								}
								continue;
							}
							default:
								return false;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Element : IDeepCloneable
			{
				public abstract object DeepClone();
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Button : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceButton;

				public int sourceStick;

				public OSXAxis sourceAxis;

				public int sourceOtherAxis;

				public Pole sourceAxisPole;

				public float axisDeadZone;

				public int sourceHat;

				public HatType sourceHatType;

				public HatDirection sourceHatDirection;

				public bool requireMultipleButtons;

				public int[] requiredButtons;

				public bool ignoreIfButtonsActive;

				public int[] ignoreIfButtonsActiveButtons;

				public HardwareButtonInfo buttonInfo;

				public Button()
				{
					sourceType = HardwareElementSourceTypeWithHat.Button;
				}

				public override object DeepClone()
				{
					Button button = new Button();
					while (true)
					{
						int num = 1098673160;
						while (true)
						{
							switch (num ^ 0x417C6C09)
							{
							case 5:
								break;
							case 2:
								button.requireMultipleButtons = requireMultipleButtons;
								button.requiredButtons = ArrayTools.ShallowCopy(requiredButtons);
								num = 1098673165;
								continue;
							case 6:
								button.sourceType = sourceType;
								button.sourceButton = sourceButton;
								num = 1098673161;
								continue;
							case 7:
								button.sourceAxisPole = sourceAxisPole;
								button.axisDeadZone = axisDeadZone;
								num = 1098673162;
								continue;
							case 1:
								button.elementIdentifier = elementIdentifier;
								num = 1098673167;
								continue;
							case 3:
								button.sourceHat = sourceHat;
								button.sourceHatType = sourceHatType;
								button.sourceHatDirection = sourceHatDirection;
								num = 1098673163;
								continue;
							case 0:
								button.sourceStick = sourceStick;
								button.sourceAxis = sourceAxis;
								button.sourceOtherAxis = sourceOtherAxis;
								num = 1098673166;
								continue;
							default:
								button.ignoreIfButtonsActive = ignoreIfButtonsActive;
								button.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons);
								button.buttonInfo = MiscTools.DeepClone(buttonInfo);
								return button;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Axis : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceStick;

				public OSXAxis sourceAxis;

				public int sourceOtherAxis;

				public AxisRange sourceAxisRange;

				public bool invert;

				public float axisDeadZone;

				public bool calibrateAxis;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public AxisCalibrationInfoEntry[] alternateCalibrations;

				public HardwareAxisInfo axisInfo;

				public int sourceButton;

				public Pole buttonAxisContribution;

				public int sourceHat;

				public AxisDirection sourceHatDirection;

				public AxisRange sourceHatRange;

				public Axis()
				{
					sourceType = HardwareElementSourceTypeWithHat.Axis;
					axisZero = 0f;
					axisMin = -1f;
					axisMax = 1f;
				}

				public override object DeepClone()
				{
					Axis axis = new Axis();
					while (true)
					{
						int num = 1341409246;
						while (true)
						{
							switch (num ^ 0x4FF447DF)
							{
							case 2:
								break;
							case 1:
								axis.elementIdentifier = elementIdentifier;
								axis.sourceType = sourceType;
								axis.sourceStick = sourceStick;
								axis.sourceAxis = sourceAxis;
								axis.sourceOtherAxis = sourceOtherAxis;
								axis.sourceAxisRange = sourceAxisRange;
								axis.invert = invert;
								axis.axisDeadZone = axisDeadZone;
								axis.calibrateAxis = calibrateAxis;
								axis.axisZero = axisZero;
								axis.axisMin = axisMin;
								axis.axisMax = axisMax;
								num = 1341409244;
								continue;
							case 3:
								axis.axisInfo = MiscTools.DeepClone(axisInfo);
								axis.sourceButton = sourceButton;
								axis.buttonAxisContribution = buttonAxisContribution;
								num = 1341409247;
								continue;
							default:
								axis.sourceHat = sourceHat;
								axis.sourceHatDirection = sourceHatDirection;
								axis.sourceHatRange = sourceHatRange;
								axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
								return axis;
							}
							break;
						}
					}
				}
			}

			private sealed class VLvtTetiYoeWGZyJXVtzXkJoxTA : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_OSX_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int fhEpmzGzqbBDTCFxbOtvekHdgBT;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
					{
						goto IL_0012;
					}
					goto IL_0067;
					IL_0012:
					int num = 1465489907;
					goto IL_0017;
					IL_0017:
					VLvtTetiYoeWGZyJXVtzXkJoxTA vLvtTetiYoeWGZyJXVtzXkJoxTA = default(VLvtTetiYoeWGZyJXVtzXkJoxTA);
					while (true)
					{
						switch (num ^ 0x575999F2)
						{
						case 0:
							break;
						case 3:
							vLvtTetiYoeWGZyJXVtzXkJoxTA = this;
							num = 1465489911;
							continue;
						case 5:
							num = 1465489910;
							continue;
						case 7:
							vLvtTetiYoeWGZyJXVtzXkJoxTA.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
							num = 1465489910;
							continue;
						case 2:
							goto IL_0067;
						case 6:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							num = 1465489905;
							continue;
						case 1:
							goto IL_0083;
						default:
							return vLvtTetiYoeWGZyJXVtzXkJoxTA;
						}
						break;
						IL_0083:
						int num2;
						if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							num = 1465489908;
							num2 = num;
						}
						else
						{
							num = 1465489904;
							num2 = num;
						}
					}
					goto IL_0012;
					IL_0067:
					vLvtTetiYoeWGZyJXVtzXkJoxTA = new VLvtTetiYoeWGZyJXVtzXkJoxTA(0);
					num = 1465489909;
					goto IL_0017;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
					while (true)
					{
						int num = -838040116;
						while (true)
						{
							switch (num ^ -838040120)
							{
							case 5:
								break;
							case 6:
							{
								int num3;
								if (fhEpmzGzqbBDTCFxbOtvekHdgBT < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes.Length)
								{
									num = -838040120;
									num3 = num;
								}
								else
								{
									num = -838040113;
									num3 = num;
								}
								continue;
							}
							case 3:
								fhEpmzGzqbBDTCFxbOtvekHdgBT++;
								num = -838040114;
								continue;
							case 8:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements != null)
								{
									int num2;
									if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes == null)
									{
										num = -838040113;
										num2 = num;
									}
									else
									{
										num = -838040119;
										num2 = num;
									}
									continue;
								}
								goto default;
							case 0:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes[fhEpmzGzqbBDTCFxbOtvekHdgBT];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							case 2:
								num = -838040113;
								continue;
							case 1:
								fhEpmzGzqbBDTCFxbOtvekHdgBT = 0;
								num = -838040114;
								continue;
							case 4:
								switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
								{
								case 0:
									break;
								case 1:
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
									num = -838040117;
									continue;
								default:
									num = -838040118;
									continue;
								}
								goto case 8;
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
				public VLvtTetiYoeWGZyJXVtzXkJoxTA(int _003C_003E1__state)
				{
					while (true)
					{
						int num = 1693735556;
						while (true)
						{
							switch (num ^ 0x64F45A85)
							{
							case 2:
								break;
							case 1:
								goto IL_0024;
							default:
								iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
								return;
							}
							break;
							IL_0024:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
							num = 1693735557;
						}
					}
				}
			}

			private sealed class kxOGvcPozFuhLpbOMTTeKtwPqgk : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_OSX_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int FJlQBPbsPMGjYFIKzdwBBPSdenv;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
					{
						goto IL_0012;
					}
					goto IL_0061;
					IL_0012:
					int num = -822539732;
					goto IL_0017;
					IL_0017:
					kxOGvcPozFuhLpbOMTTeKtwPqgk kxOGvcPozFuhLpbOMTTeKtwPqgk2 = default(kxOGvcPozFuhLpbOMTTeKtwPqgk);
					while (true)
					{
						switch (num ^ -822539735)
						{
						case 2:
							break;
						case 5:
							if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
							{
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
								num = -822539729;
								continue;
							}
							goto IL_0061;
						case 6:
							kxOGvcPozFuhLpbOMTTeKtwPqgk2 = this;
							num = -822539731;
							continue;
						case 3:
							goto IL_0061;
						case 1:
							kxOGvcPozFuhLpbOMTTeKtwPqgk2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
							num = -822539735;
							continue;
						case 4:
							num = -822539735;
							continue;
						default:
							return kxOGvcPozFuhLpbOMTTeKtwPqgk2;
						}
						break;
					}
					goto IL_0012;
					IL_0061:
					kxOGvcPozFuhLpbOMTTeKtwPqgk2 = new kxOGvcPozFuhLpbOMTTeKtwPqgk(0);
					num = -822539736;
					goto IL_0017;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 1:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = 325877564;
						goto IL_001f;
					case 0:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							num = 325877560;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x136C7F38)
							{
							case 8:
								num = 325877566;
								continue;
							case 7:
								num = 325877553;
								continue;
							case 3:
								return true;
							case 4:
								FJlQBPbsPMGjYFIKzdwBBPSdenv++;
								num = 325877553;
								continue;
							case 6:
								break;
							case 9:
								goto IL_0091;
							case 0:
								goto IL_00bf;
							case 5:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons[FJlQBPbsPMGjYFIKzdwBBPSdenv];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 325877563;
								continue;
							case 1:
								FJlQBPbsPMGjYFIKzdwBBPSdenv = 0;
								num = 325877567;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00bf:
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements == null)
							{
								goto end_IL_0008;
							}
							int num2;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons == null)
							{
								num = 325877562;
								num2 = num;
							}
							else
							{
								num = 325877561;
								num2 = num;
							}
							continue;
							IL_0091:
							int num3;
							if (FJlQBPbsPMGjYFIKzdwBBPSdenv >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons.Length)
							{
								num = 325877562;
								num3 = num;
							}
							else
							{
								num = 325877565;
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
				public kxOGvcPozFuhLpbOMTTeKtwPqgk(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public override int assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			public override int assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.qzTTwsqmkFsXzptVNiHLyLYTdWR;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal override bool hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						goto IL_0008;
					}
					int num;
					if (!matchingCriteria.hasData)
					{
						num = -396404486;
					}
					else
					{
						if (assignedAxisCount != 0 || assignedButtonCount != 0)
						{
							return true;
						}
						num = -396404488;
					}
					goto IL_000d;
					IL_0008:
					num = -396404485;
					goto IL_000d;
					IL_000d:
					switch (num ^ -396404487)
					{
					case 0:
						break;
					case 2:
						return false;
					case 3:
						return false;
					default:
						return false;
					}
					goto IL_0008;
				}
			}

			internal override bool disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			internal override bool isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal override Elements_Base elements_base
			{
				get
				{
					return elements;
				}
			}

			internal override IList<Platform> variants_base
			{
				get
				{
					return null;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			internal IEnumerable<Axis> IterateAxes()
			{
				VLvtTetiYoeWGZyJXVtzXkJoxTA vLvtTetiYoeWGZyJXVtzXkJoxTA = new VLvtTetiYoeWGZyJXVtzXkJoxTA(-2);
				vLvtTetiYoeWGZyJXVtzXkJoxTA.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return vLvtTetiYoeWGZyJXVtzXkJoxTA;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				kxOGvcPozFuhLpbOMTTeKtwPqgk kxOGvcPozFuhLpbOMTTeKtwPqgk2 = new kxOGvcPozFuhLpbOMTTeKtwPqgk(-2);
				kxOGvcPozFuhLpbOMTTeKtwPqgk2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return kxOGvcPozFuhLpbOMTTeKtwPqgk2;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				List<Axis> list = new List<Axis>();
				IEnumerator<Axis> enumerator = elements.IterateAxes().GetEnumerator();
				try
				{
					while (true)
					{
						IL_0084:
						int num;
						int num2;
						if (!enumerator.MoveNext())
						{
							num = 1240470883;
							num2 = num;
						}
						else
						{
							num = 1240470882;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x49F01563)
							{
							case 2:
								num = 1240470882;
								continue;
							default:
								goto end_IL_0051;
							case 1:
							{
								Axis current = enumerator.Current;
								list.Add(current);
								num = 1240470880;
								continue;
							}
							case 3:
								break;
							case 0:
								goto end_IL_0051;
							}
							goto IL_0084;
							continue;
							end_IL_0051:
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
							IL_00a4:
							int num3 = 1240470881;
							while (true)
							{
								switch (num3 ^ 0x49F01563)
								{
								case 0:
									break;
								default:
									goto end_IL_00a9;
								case 2:
									goto IL_00c2;
								case 1:
									goto end_IL_00a9;
								}
								goto IL_00a4;
								IL_00c2:
								enumerator.Dispose();
								num3 = 1240470882;
								continue;
								end_IL_00a9:
								break;
							}
							break;
						}
					}
				}
				int num4 = 0;
				while (num4 < array.Length)
				{
					while (true)
					{
						int elementIdentifier = list[num4].elementIdentifier;
						int num5 = 1240470882;
						while (true)
						{
							switch (num5 ^ 0x49F01563)
							{
							case 3:
								num5 = 1240470885;
								continue;
							case 6:
								break;
							case 2:
								array[num4] = identifiers[elementIdentifier].name;
								num5 = 1240470883;
								continue;
							case 1:
								if (elementIdentifier >= 0)
								{
									goto IL_0133;
								}
								goto case 5;
							case 0:
								num4++;
								num5 = 1240470887;
								continue;
							case 5:
								Logger.LogError("Element identifier index is out of bounds!");
								num5 = 1240470883;
								continue;
							default:
								goto end_IL_0106;
							}
							break;
							IL_0133:
							int num6;
							if (elementIdentifier >= identifiers.Length)
							{
								num5 = 1240470886;
								num6 = num5;
							}
							else
							{
								num5 = 1240470881;
								num6 = num5;
							}
						}
						continue;
						end_IL_0106:
						break;
					}
				}
				return array;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				if (identifiers.Length < buttonCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[buttonCount];
				int num2 = default(int);
				int num4 = default(int);
				while (true)
				{
					int num = 749315985;
					while (true)
					{
						switch (num ^ 0x2CA9A795)
						{
						case 6:
							break;
						case 0:
							num2++;
							num = 749315988;
							continue;
						case 7:
						{
							int elementIdentifier = elements.buttons[num2].elementIdentifier;
							num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num = 749315997;
							continue;
						}
						case 5:
							array[num2] = identifiers[num4].name;
							num = 749315989;
							continue;
						case 4:
							num2 = 0;
							num = 749315988;
							continue;
						case 2:
							Logger.LogError("Element identifier index is out of bounds!");
							num = 749315989;
							continue;
						case 8:
							if (num4 >= 0)
							{
								int num5;
								if (num4 < identifiers.Length)
								{
									num = 749315984;
									num5 = num;
								}
								else
								{
									num = 749315991;
									num5 = num;
								}
								continue;
							}
							goto case 2;
						case 1:
						{
							int num3;
							if (num2 < buttonCount)
							{
								num = 749315986;
								num3 = num;
							}
							else
							{
								num = 749315990;
								num3 = num;
							}
							continue;
						}
						default:
							return array;
						}
						break;
					}
				}
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				bool result = default(bool);
				using (IEnumerator<Axis> enumerator = IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Axis current = enumerator.Current;
							int num;
							int num2;
							if (current.elementIdentifier != elementIdentifierId)
							{
								num = 2136516734;
								num2 = num;
							}
							else
							{
								num = 2136516732;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ 0x7F58A87C)
								{
								case 3:
									num = 2136516733;
									continue;
								case 1:
									break;
								case 0:
									result = true;
									goto IL_0110;
								default:
									goto end_IL_0030;
								}
								break;
							}
							continue;
							end_IL_0030:
							break;
						}
					}
				}
				IEnumerator<Button> enumerator2 = IterateButtons().GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Button current2 = enumerator2.Current;
							int num3 = 2136516733;
							while (true)
							{
								switch (num3 ^ 0x7F58A87C)
								{
								case 0:
									num3 = 2136516734;
									continue;
								case 2:
									break;
								case 1:
									if (current2.elementIdentifier == elementIdentifierId)
									{
										result = true;
										num3 = 2136516735;
										continue;
									}
									goto end_IL_00a8;
								default:
									goto end_IL_00a8;
								case 3:
									goto IL_0110;
								}
								break;
							}
							continue;
							end_IL_00a8:
							break;
						}
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						while (true)
						{
							IL_00e1:
							int num4 = 2136516734;
							while (true)
							{
								switch (num4 ^ 0x7F58A87C)
								{
								case 0:
									break;
								default:
									goto end_IL_00e6;
								case 2:
									goto IL_00ff;
								case 1:
									goto end_IL_00e6;
								}
								goto IL_00e1;
								IL_00ff:
								enumerator2.Dispose();
								num4 = 2136516733;
								continue;
								end_IL_00e6:
								break;
							}
							break;
						}
					}
				}
				return false;
				IL_0110:
				return result;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				using (IEnumerator<Button> enumerator = IterateButtons().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Button current = enumerator.Current;
							int num2 = 1131955291;
							while (true)
							{
								switch (num2 ^ 0x43784458)
								{
								case 2:
									num2 = 1131955289;
									continue;
								case 1:
									break;
								case 3:
									buttons[num] = current.elementIdentifier;
									num++;
									num2 = 1131955288;
									continue;
								default:
									goto end_IL_004c;
								}
								break;
							}
							continue;
							end_IL_004c:
							break;
						}
					}
				}
				num = 0;
				IEnumerator<Axis> enumerator2 = IterateAxes().GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Axis current2 = enumerator2.Current;
							axes[num] = current2.elementIdentifier;
							num++;
							int num3 = 1131955289;
							while (true)
							{
								switch (num3 ^ 0x43784458)
								{
								case 0:
									num3 = 1131955290;
									continue;
								case 2:
									break;
								default:
									goto end_IL_00b2;
								}
								break;
							}
							continue;
							end_IL_00b2:
							break;
						}
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						while (true)
						{
							IL_00de:
							int num4 = 1131955290;
							while (true)
							{
								switch (num4 ^ 0x43784458)
								{
								case 0:
									break;
								default:
									goto end_IL_00e3;
								case 2:
									goto IL_00fc;
								case 1:
									goto end_IL_00e3;
								}
								goto IL_00de;
								IL_00fc:
								enumerator2.Dispose();
								num4 = 1131955289;
								continue;
								end_IL_00e3:
								break;
							}
							break;
						}
					}
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				int num2 = default(int);
				AxisCalibrationData[] array = default(AxisCalibrationData[]);
				while (true)
				{
					int num = 1311787846;
					while (true)
					{
						switch (num ^ 0x4E304B4D)
						{
						case 13:
							break;
						case 0:
						{
							int num4;
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								num = 1311787847;
								num4 = num;
							}
							else
							{
								num = 1311787854;
								num4 = num;
							}
							continue;
						}
						case 5:
							num2++;
							num = 1311787844;
							continue;
						case 2:
							num = 1311787844;
							continue;
						case 7:
							throw new NotImplementedException();
						case 6:
							num = 1311787841;
							continue;
						case 3:
							array[num2] = AxisCalibrationData.Default;
							num = 1311787841;
							continue;
						case 8:
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num5;
								if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									num = 1311787853;
									num5 = num;
								}
								else
								{
									num = 1311787852;
									num5 = num;
								}
								continue;
							}
							goto case 1;
						case 12:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num = 1311787848;
							continue;
						case 1:
							array[num2] = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							if (Axes_orig[num2].calibrateAxis)
							{
								array[num2].zero = axes_orig[num2].axisZero;
								array[num2].min = axes_orig[num2].axisMin;
								array[num2].max = axes_orig[num2].axisMax;
								num = 1311787851;
								continue;
							}
							goto case 12;
						case 11:
							if (axes_orig == null)
							{
								return null;
							}
							array = new AxisCalibrationData[axes_orig.Length];
							num = 1311787849;
							continue;
						case 10:
						{
							int num3;
							if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Hat)
							{
								num = 1311787854;
								num3 = num;
							}
							else
							{
								num = 1311787850;
								num3 = num;
							}
							continue;
						}
						case 4:
							num2 = 0;
							num = 1311787855;
							continue;
						default:
							if (num2 >= axes_orig.Length)
							{
								return array;
							}
							goto case 8;
						}
						break;
					}
				}
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				while (true)
				{
					axisRanges = new AxisRange[Axes_orig.Length];
					axisInfos = new HardwareAxisInfo[Axes_orig.Length];
					int num = 0;
					int num2 = -458972639;
					while (true)
					{
						switch (num2 ^ -458972631)
						{
						case 0:
							num2 = -458972630;
							continue;
						case 9:
							num++;
							num2 = -458972639;
							continue;
						case 5:
							axisRanges[num] = Axes_orig[num].sourceAxisRange;
							num2 = -458972640;
							continue;
						case 7:
							axisRanges[num] = AxisRange.Full;
							num2 = -458972640;
							continue;
						case 6:
						{
							int num4;
							if (Axes_orig[num].sourceType == HardwareElementSourceTypeWithHat.Hat)
							{
								num2 = -458972626;
								num4 = num2;
							}
							else
							{
								num2 = -458972627;
								num4 = num2;
							}
							continue;
						}
						case 3:
							break;
						case 1:
							axisInfos[num] = MiscTools.DeepClone(Axes_orig[num].axisInfo, true);
							if (Axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num5;
								if (Axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									num2 = -458972629;
									num5 = num2;
								}
								else
								{
									num2 = -458972628;
									num5 = num2;
								}
								continue;
							}
							goto case 5;
						case 4:
							throw new Exception();
						case 2:
						{
							int num3;
							if (Axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								num2 = -458972625;
								num3 = num2;
							}
							else
							{
								num2 = -458972626;
								num3 = num2;
							}
							continue;
						}
						default:
							if (num >= Axes_orig.Length)
							{
								return;
							}
							goto case 1;
						}
						break;
					}
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig == null)
				{
					return;
				}
				while (true)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					int num = 0;
					int num2 = 119689259;
					while (true)
					{
						switch (num2 ^ 0x722502F)
						{
						case 0:
							num2 = 119689258;
							continue;
						case 2:
							num++;
							num2 = 119689260;
							continue;
						case 1:
							buttonInfos[num] = MiscTools.DeepClone(Buttons_orig[num].buttonInfo, true);
							num2 = 119689261;
							continue;
						case 4:
							num2 = 119689260;
							continue;
						case 5:
							break;
						default:
							if (num >= Buttons_orig.Length)
							{
								return;
							}
							goto case 1;
						}
						break;
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_OSX_Base platform_OSX_Base = new Platform_OSX_Base();
				CopyVars(platform_OSX_Base);
				return platform_OSX_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				Platform_OSX_Base platform_OSX_Base = destination as Platform_OSX_Base;
				if (platform_OSX_Base == null)
				{
					return;
				}
				while (true)
				{
					platform_OSX_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_OSX_Base.elements = MiscTools.DeepClone(elements);
					int num = -124535285;
					while (true)
					{
						switch (num ^ -124535285)
						{
						case 2:
							goto IL_000b;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_000b:
						num = -124535286;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_OSX : Platform_OSX_Base
		{
			public Platform_OSX_Base[] variants;

			internal override IList<Platform> variants_base
			{
				get
				{
					return variants;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					goto IL_000d;
				}
				int num = default(int);
				int num2;
				if (base.hasVariants)
				{
					num = 0;
					num2 = 235495788;
					goto IL_0012;
				}
				goto IL_0091;
				IL_0012:
				while (true)
				{
					switch (num2 ^ 0xE09616F)
					{
					case 0:
						break;
					case 4:
						return true;
					case 3:
						goto IL_0046;
					case 2:
						goto IL_0062;
					default:
						goto IL_0091;
					}
					break;
					IL_0062:
					int variantIndex2;
					if (variants[num] != null && variants[num].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
					{
						variantIndex = num;
						return true;
					}
					num++;
					num2 = 235495788;
					continue;
					IL_0046:
					int num3;
					if (num < variants.Length)
					{
						num2 = 235495789;
						num3 = num2;
					}
					else
					{
						num2 = 235495790;
						num3 = num2;
					}
				}
				goto IL_000d;
				IL_0091:
				return false;
				IL_000d:
				num2 = 235495787;
				goto IL_0012;
			}

			public override object DeepClone()
			{
				Platform_OSX platform_OSX = new Platform_OSX();
				CopyVars(platform_OSX);
				return platform_OSX;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_OSX platform_OSX = destination as Platform_OSX;
				if (platform_OSX != null)
				{
					platform_OSX.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_Linux_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				[Serializable]
				public sealed class ElementCount : ElementCount_Base
				{
					public int hatCount;

					public override object DeepClone()
					{
						ElementCount elementCount = new ElementCount();
						while (true)
						{
							int num = -1222759394;
							while (true)
							{
								switch (num ^ -1222759396)
								{
								case 0:
									break;
								case 2:
									goto IL_0024;
								default:
									return elementCount;
								}
								break;
								IL_0024:
								CopyVars(elementCount);
								num = -1222759395;
							}
						}
					}

					internal override void CopyVars(ElementCount_Base P_0)
					{
						base.CopyVars(P_0);
						ElementCount elementCount = P_0 as ElementCount;
						if (elementCount != null)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal override bool Matches(BridgedControllerHWInfo P_0)
					{
						if (!base.Matches(P_0))
						{
							return false;
						}
						if (hatCount >= 0)
						{
							return hatCount == P_0.hardwareHatCount;
						}
						return true;
					}
				}

				public int hatCount;

				public ElementCount[] alternateElementCounts;

				public bool manufacturer_useRegex;

				public bool productName_useRegex;

				public bool systemName_useRegex;

				public string[] manufacturer;

				public string[] productName;

				public string[] systemName;

				public string[] productGUID;

				internal override bool hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (productGUID != null)
						{
							goto IL_0012;
						}
						goto IL_003d;
						IL_004c:
						if (productName.Length > 0)
						{
							return true;
						}
						goto IL_0059;
						IL_0012:
						int num = -1359370891;
						goto IL_0017;
						IL_0017:
						switch (num ^ -1359370889)
						{
						case 0:
							break;
						case 2:
							goto IL_0030;
						default:
							goto IL_004c;
						}
						goto IL_0012;
						IL_0030:
						if (productGUID.Length > 0)
						{
							return true;
						}
						goto IL_003d;
						IL_003d:
						if (productName != null)
						{
							num = -1359370890;
							goto IL_0017;
						}
						goto IL_0059;
						IL_0059:
						return false;
					}
				}

				internal override bool isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						return true;
					}
				}

				internal override int alternateElementCount
				{
					get
					{
						if (alternateElementCounts == null)
						{
							return 0;
						}
						return alternateElementCounts.Length;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						goto IL_0024;
					}
					int num;
					if (strictMatch)
					{
						num = -2071704257;
						goto IL_0029;
					}
					return AnyNameMatches(bridgedControllerHWInfo);
					IL_0024:
					num = -2071704262;
					goto IL_0029;
					IL_0029:
					while (true)
					{
						switch (num ^ -2071704261)
						{
						case 2:
							break;
						case 0:
							return true;
						case 4:
							if (PidVid.ArrayContains(productGUID, ref bridgedControllerHWInfo.hw_pidVid))
							{
								if (!ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
								{
									return true;
								}
								if (productName == null)
								{
									goto case 0;
								}
								if (productName.Length == 0)
								{
									num = -2071704261;
									continue;
								}
							}
							if (!AnyNameMatches(bridgedControllerHWInfo))
							{
								num = -2071704264;
								continue;
							}
							return true;
						case 1:
							return false;
						default:
							return false;
						}
						break;
					}
					goto IL_0024;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					if (alternateElementCounts == null || index < 0 || index >= alternateElementCounts.Length)
					{
						return null;
					}
					return alternateElementCounts[index];
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						return false;
					}
					if (alternateMatched)
					{
						return true;
					}
					if (hatCount >= 0)
					{
						return bridgedControllerHWInfo.hardwareHatCount == hatCount;
					}
					return true;
				}

				private bool AnyNameMatches(BridgedControllerHWInfo bridgedControllerHWInfo)
				{
					if (NameMatches(bridgedControllerHWInfo.hw_productName, productName, productName_useRegex))
					{
						return true;
					}
					if (NameMatches(bridgedControllerHWInfo.hw_systemDeviceName, systemName, systemName_useRegex))
					{
						return true;
					}
					return false;
				}

				private bool NameMatches(string name, string[] names, bool useRegex)
				{
					if (!string.IsNullOrEmpty(name))
					{
						int num2 = default(int);
						string searchIn = default(string);
						while (true)
						{
							int num = -239643651;
							while (true)
							{
								switch (num ^ -239643650)
								{
								case 5:
									break;
								case 1:
									num = -239643652;
									continue;
								case 0:
									goto end_IL_0008;
								case 3:
									goto IL_004b;
								case 4:
									goto IL_0055;
								default:
									if (num2 >= names.Length)
									{
										return false;
									}
									goto IL_0055;
								}
								break;
								IL_0055:
								if (!string.IsNullOrEmpty(names[num2]) && MatchingCriteria_Base.StringMatches(searchIn, names[num2], useRegex))
								{
									return true;
								}
								num2++;
								num = -239643652;
								continue;
								IL_004b:
								if (names != null)
								{
									searchIn = name.Trim();
									num2 = 0;
									num = -239643649;
								}
								else
								{
									num = -239643650;
								}
							}
							continue;
							end_IL_0008:
							break;
						}
					}
					return false;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					MatchingCriteria matchingCriteria = default(MatchingCriteria);
					while (true)
					{
						int num = -2098199561;
						while (true)
						{
							switch (num ^ -2098199564)
							{
							case 2:
								break;
							case 3:
								matchingCriteria = destination as MatchingCriteria;
								if (matchingCriteria != null)
								{
									goto IL_003b;
								}
								return;
							case 0:
								goto IL_003b;
							default:
								matchingCriteria.productName_useRegex = productName_useRegex;
								matchingCriteria.systemName_useRegex = systemName_useRegex;
								matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								matchingCriteria.systemName = ArrayTools.ShallowCopy(systemName);
								matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
								return;
							}
							break;
							IL_003b:
							matchingCriteria.hatCount = hatCount;
							matchingCriteria.manufacturer_useRegex = manufacturer_useRegex;
							num = -2098199563;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class wUAebauWYaiSpFoMhzBIvjDOHMJc : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
				{
					private Axis RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public Elements ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public int MZLbUYnVFIwZlftZmBTusScNpNX;

					Axis IEnumerator<Axis>.Current
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
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							goto IL_001c;
						}
						goto IL_005b;
						IL_005b:
						wUAebauWYaiSpFoMhzBIvjDOHMJc wUAebauWYaiSpFoMhzBIvjDOHMJc2 = new wUAebauWYaiSpFoMhzBIvjDOHMJc(0);
						wUAebauWYaiSpFoMhzBIvjDOHMJc2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						int num = 46573947;
						goto IL_0021;
						IL_001c:
						num = 46573948;
						goto IL_0021;
						IL_0021:
						while (true)
						{
							switch (num ^ 0x2C6A979)
							{
							case 0:
								break;
							case 5:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
								num = 46573944;
								continue;
							case 3:
								num = 46573947;
								continue;
							case 4:
								goto IL_005b;
							case 1:
								wUAebauWYaiSpFoMhzBIvjDOHMJc2 = this;
								num = 46573946;
								continue;
							default:
								return wUAebauWYaiSpFoMhzBIvjDOHMJc2;
							}
							break;
						}
						goto IL_001c;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int num;
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 0:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							num = -950289414;
							goto IL_001f;
						case 1:
							{
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								MZLbUYnVFIwZlftZmBTusScNpNX++;
								num = -950289409;
								goto IL_001f;
							}
							IL_001f:
							while (true)
							{
								switch (num ^ -950289409)
								{
								case 2:
									num = -950289412;
									continue;
								case 3:
									break;
								case 5:
									if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.axes != null)
									{
										MZLbUYnVFIwZlftZmBTusScNpNX = 0;
										num = -950289409;
										continue;
									}
									goto end_IL_0008;
								case 0:
									goto IL_0070;
								case 1:
									RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.axes[MZLbUYnVFIwZlftZmBTusScNpNX];
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
									return true;
								default:
									goto end_IL_0008;
								}
								break;
								IL_0070:
								int num2;
								if (MZLbUYnVFIwZlftZmBTusScNpNX < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.axes.Length)
								{
									num = -950289410;
									num2 = num;
								}
								else
								{
									num = -950289413;
									num2 = num;
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
					public wUAebauWYaiSpFoMhzBIvjDOHMJc(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class KROltdfJkrOmcwbHWebYVtwZMYY : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
				{
					private Button RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public Elements ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public int adLGYYmnTcTvjkdenaYCyfQnYyG;

					Button IEnumerator<Button>.Current
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
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						KROltdfJkrOmcwbHWebYVtwZMYY kROltdfJkrOmcwbHWebYVtwZMYY;
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							kROltdfJkrOmcwbHWebYVtwZMYY = this;
							goto IL_0025;
						}
						goto IL_004e;
						IL_002a:
						int num;
						while (true)
						{
							switch (num ^ 0x2A1434E2)
							{
							case 0:
								break;
							case 2:
								num = 705967329;
								continue;
							case 1:
								goto IL_004e;
							default:
								return kROltdfJkrOmcwbHWebYVtwZMYY;
							}
							break;
						}
						goto IL_0025;
						IL_004e:
						kROltdfJkrOmcwbHWebYVtwZMYY = new KROltdfJkrOmcwbHWebYVtwZMYY(0);
						kROltdfJkrOmcwbHWebYVtwZMYY.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = 705967329;
						goto IL_002a;
						IL_0025:
						num = 705967328;
						goto IL_002a;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int num;
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 0:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttons == null)
							{
								break;
							}
							adLGYYmnTcTvjkdenaYCyfQnYyG = 0;
							num = 620026826;
							goto IL_001f;
						case 1:
							{
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								adLGYYmnTcTvjkdenaYCyfQnYyG++;
								num = 620026826;
								goto IL_001f;
							}
							IL_001f:
							while (true)
							{
								switch (num ^ 0x24F4DBCA)
								{
								case 3:
									num = 620026830;
									continue;
								case 4:
									break;
								case 1:
									RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttons[adLGYYmnTcTvjkdenaYCyfQnYyG];
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
									return true;
								case 0:
									goto IL_00a5;
								default:
									goto end_IL_0008;
								}
								break;
								IL_00a5:
								int num2;
								if (adLGYYmnTcTvjkdenaYCyfQnYyG < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttons.Length)
								{
									num = 620026827;
									num2 = num;
								}
								else
								{
									num = 620026824;
									num2 = num;
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
					public KROltdfJkrOmcwbHWebYVtwZMYY(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				public override int axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal IEnumerable<Axis> Axes
				{
					get
					{
						wUAebauWYaiSpFoMhzBIvjDOHMJc wUAebauWYaiSpFoMhzBIvjDOHMJc2 = new wUAebauWYaiSpFoMhzBIvjDOHMJc(-2);
						wUAebauWYaiSpFoMhzBIvjDOHMJc2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
						return wUAebauWYaiSpFoMhzBIvjDOHMJc2;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					get
					{
						KROltdfJkrOmcwbHWebYVtwZMYY kROltdfJkrOmcwbHWebYVtwZMYY = new KROltdfJkrOmcwbHWebYVtwZMYY(-2);
						kROltdfJkrOmcwbHWebYVtwZMYY.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
						return kROltdfJkrOmcwbHWebYVtwZMYY;
					}
				}

				internal Axis GetAxis(int axisIndex)
				{
					if (axes != null)
					{
						while (true)
						{
							int num = -815340721;
							while (true)
							{
								switch (num ^ -815340722)
								{
								case 2:
									break;
								case 1:
									goto IL_0026;
								default:
									goto end_IL_0008;
								}
								break;
								IL_0026:
								if (axisIndex < 0)
								{
									goto end_IL_0008;
								}
								if (axisIndex >= axes.Length)
								{
									num = -815340722;
									continue;
								}
								return axes[axisIndex];
							}
							continue;
							end_IL_0008:
							break;
						}
					}
					return null;
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					int num = 0;
					int num2 = default(int);
					while (true)
					{
						IL_006c:
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = 67901501;
							goto IL_0009;
						}
						goto IL_002e;
						IL_0009:
						while (true)
						{
							switch (num3 ^ 0x40C183D)
							{
							case 3:
								num3 = 67901500;
								continue;
							case 1:
								break;
							case 5:
								goto IL_004a;
							case 2:
								goto IL_006c;
							case 4:
								return ControllerElementType.Axis;
							default:
								if (num2 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								goto IL_004a;
							}
							break;
							IL_004a:
							if (buttons[num2].elementIdentifier == elementIdentifier.id)
							{
								return ControllerElementType.Button;
							}
							num2++;
							num3 = 67901501;
						}
						goto IL_002e;
						IL_002e:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							num3 = 67901497;
						}
						else
						{
							num++;
							num3 = 67901503;
						}
						goto IL_0009;
					}
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					HardwareElementSourceTypeWithHat sourceType = default(HardwareElementSourceTypeWithHat);
					while (num < axisCount)
					{
						while (true)
						{
							IL_0093:
							int num2;
							if (axes[num].elementIdentifier == elementIdentifier.id)
							{
								sourceType = axes[num].sourceType;
								num2 = -353397512;
								goto IL_000c;
							}
							goto IL_0085;
							IL_000c:
							while (true)
							{
								switch (num2 ^ -353397505)
								{
								case 9:
									num2 = -353397509;
									continue;
								case 1:
									break;
								case 8:
									return true;
								case 0:
									goto end_IL_000c;
								case 4:
									goto IL_0093;
								case 5:
									if (axes[num].invert)
									{
										axisRange = InputTools.InvertAxisRange(axisRange);
										num2 = -353397513;
										continue;
									}
									goto case 8;
								case 3:
									goto IL_00e2;
								case 7:
									goto IL_00f1;
								case 10:
									goto IL_010d;
								case 6:
									return true;
								default:
									goto end_IL_0093;
								}
								goto IL_0048;
								IL_010d:
								if (sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									throw new NotImplementedException();
								}
								num2 = -353397506;
								continue;
								IL_0048:
								axisRange = axes[num].sourceAxisRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -353397508;
									continue;
								}
								goto IL_00e2;
								IL_00e2:
								return true;
								IL_00f1:
								switch (sourceType)
								{
								case HardwareElementSourceTypeWithHat.Axis:
									break;
								case HardwareElementSourceTypeWithHat.Button:
									axisRange = AxisRange.Positive;
									num2 = -353397511;
									continue;
								default:
									num2 = -353397515;
									continue;
								case HardwareElementSourceTypeWithHat.Hat:
									axisRange = axes[num].sourceHatRange;
									num2 = -353397510;
									continue;
								}
								goto IL_0048;
								continue;
								end_IL_000c:
								break;
							}
							goto IL_0085;
							IL_0085:
							num++;
							num2 = -353397507;
							goto IL_000c;
							continue;
							end_IL_0093:
							break;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					Elements elements = destination as Elements;
					if (elements == null)
					{
						return;
					}
					while (true)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						int num = 1479813731;
						while (true)
						{
							switch (num ^ 0x58342A63)
							{
							case 2:
								num = 1479813728;
								continue;
							default:
								return;
							case 3:
								break;
							case 0:
								elements.buttons = ArrayTools.DeepClone(buttons);
								num = 1479813730;
								continue;
							case 1:
								return;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Element : IDeepCloneable
			{
				public abstract object DeepClone();

				protected virtual void ImportVars(Element source)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class Button : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceButton;

				public int sourceAxis;

				public Pole sourceAxisPole;

				public float axisDeadZone;

				public int sourceHat;

				public HatType sourceHatType;

				public HatDirection sourceHatDirection;

				public bool requireMultipleButtons;

				public int[] requiredButtons;

				public bool ignoreIfButtonsActive;

				public int[] ignoreIfButtonsActiveButtons;

				public HardwareButtonInfo buttonInfo;

				public Button()
				{
					sourceType = HardwareElementSourceTypeWithHat.Button;
				}

				public override object DeepClone()
				{
					Button button = new Button();
					button.ImportVars(this);
					return button;
				}

				protected override void ImportVars(Element source)
				{
					base.ImportVars(source);
					Button button = source as Button;
					if (button == null)
					{
						goto IL_0014;
					}
					goto IL_00df;
					IL_0014:
					int num = -1655329541;
					goto IL_0019;
					IL_0019:
					while (true)
					{
						switch (num ^ -1655329542)
						{
						case 0:
							break;
						case 4:
							sourceAxis = button.sourceAxis;
							num = -1655329543;
							continue;
						case 3:
							sourceAxisPole = button.sourceAxisPole;
							axisDeadZone = button.axisDeadZone;
							sourceHat = button.sourceHat;
							sourceHatType = button.sourceHatType;
							sourceHatDirection = button.sourceHatDirection;
							requireMultipleButtons = button.requireMultipleButtons;
							requiredButtons = ArrayTools.ShallowCopy(button.requiredButtons);
							ignoreIfButtonsActive = button.ignoreIfButtonsActive;
							ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(button.ignoreIfButtonsActiveButtons);
							num = -1655329537;
							continue;
						case 1:
							return;
						case 2:
							goto IL_00df;
						default:
							buttonInfo = MiscTools.DeepClone(button.buttonInfo);
							return;
						}
						break;
					}
					goto IL_0014;
					IL_00df:
					elementIdentifier = button.elementIdentifier;
					sourceType = button.sourceType;
					sourceButton = button.sourceButton;
					num = -1655329538;
					goto IL_0019;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class Axis : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceAxis;

				public AxisRange sourceAxisRange;

				public bool invert;

				public float axisDeadZone;

				public bool calibrateAxis;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public AxisCalibrationInfoEntry[] alternateCalibrations;

				public HardwareAxisInfo axisInfo;

				public int sourceButton;

				public Pole buttonAxisContribution;

				public int sourceHat;

				public AxisDirection sourceHatDirection;

				public AxisRange sourceHatRange;

				public Axis()
				{
					sourceType = HardwareElementSourceTypeWithHat.Axis;
				}

				public override object DeepClone()
				{
					Axis axis = new Axis();
					while (true)
					{
						int num = -60242935;
						while (true)
						{
							switch (num ^ -60242933)
							{
							case 0:
								break;
							case 2:
								goto IL_0024;
							default:
								return axis;
							}
							break;
							IL_0024:
							axis.ImportVars(this);
							num = -60242934;
						}
					}
				}

				protected override void ImportVars(Element source)
				{
					base.ImportVars(source);
					Axis axis = source as Axis;
					if (axis == null)
					{
						return;
					}
					while (true)
					{
						elementIdentifier = axis.elementIdentifier;
						sourceType = axis.sourceType;
						sourceAxis = axis.sourceAxis;
						sourceAxisRange = axis.sourceAxisRange;
						invert = axis.invert;
						axisDeadZone = axis.axisDeadZone;
						int num = 2054602754;
						while (true)
						{
							switch (num ^ 0x7A76C004)
							{
							case 2:
								num = 2054602757;
								continue;
							case 4:
								axisMax = axis.axisMax;
								axisInfo = MiscTools.DeepClone(axis.axisInfo);
								num = 2054602753;
								continue;
							case 5:
								sourceButton = axis.sourceButton;
								buttonAxisContribution = axis.buttonAxisContribution;
								num = 2054602756;
								continue;
							case 1:
								break;
							case 3:
								axisZero = axis.axisZero;
								axisMin = axis.axisMin;
								num = 2054602752;
								continue;
							case 6:
								calibrateAxis = axis.calibrateAxis;
								num = 2054602759;
								continue;
							default:
								sourceHat = axis.sourceHat;
								sourceHatDirection = axis.sourceHatDirection;
								sourceHatRange = axis.sourceHatRange;
								alternateCalibrations = MiscTools.DeepClone(axis.alternateCalibrations);
								return;
							}
							break;
						}
					}
				}
			}

			private sealed class eHQXScuMfHUBgQChGkUkhDdButI : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_Linux_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int yejuMJPeLMGxtupgoaxyOZaMdbd;

				public int oeHmYErrvzcFTCWsplIIXOdLDlh;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					eHQXScuMfHUBgQChGkUkhDdButI eHQXScuMfHUBgQChGkUkhDdButI2;
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						eHQXScuMfHUBgQChGkUkhDdButI2 = this;
					}
					else
					{
						while (true)
						{
							eHQXScuMfHUBgQChGkUkhDdButI2 = new eHQXScuMfHUBgQChGkUkhDdButI(0);
							eHQXScuMfHUBgQChGkUkhDdButI2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
							int num = -1111044655;
							while (true)
							{
								switch (num ^ -1111044656)
								{
								case 0:
									num = -1111044654;
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
					return eHQXScuMfHUBgQChGkUkhDdButI2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 0:
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements == null)
						{
							break;
						}
						int num2;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes == null)
						{
							num = 1499510269;
							num2 = num;
						}
						else
						{
							num = 1499510270;
							num2 = num;
						}
						goto IL_001f;
					}
					case 1:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							num = 1499510268;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x5960B5FD)
							{
							case 5:
								num = 1499510265;
								continue;
							case 4:
								break;
							case 2:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes[oeHmYErrvzcFTCWsplIIXOdLDlh];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							case 1:
								oeHmYErrvzcFTCWsplIIXOdLDlh++;
								num = 1499510267;
								continue;
							case 6:
								goto IL_00d4;
							case 3:
								yejuMJPeLMGxtupgoaxyOZaMdbd = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes.Length;
								oeHmYErrvzcFTCWsplIIXOdLDlh = 0;
								num = 1499510267;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00d4:
							int num3;
							if (oeHmYErrvzcFTCWsplIIXOdLDlh >= yejuMJPeLMGxtupgoaxyOZaMdbd)
							{
								num = 1499510269;
								num3 = num;
							}
							else
							{
								num = 1499510271;
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
				public eHQXScuMfHUBgQChGkUkhDdButI(int _003C_003E1__state)
				{
					while (true)
					{
						int num = 1093298647;
						while (true)
						{
							switch (num ^ 0x412A69D6)
							{
							case 0:
								break;
							default:
								return;
							case 1:
								goto IL_0024;
							case 2:
								return;
							}
							break;
							IL_0024:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
							iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
							num = 1093298644;
						}
					}
				}
			}

			private sealed class FyoqPeQPDmUxcsSRLhMaHKFdiJhd : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_Linux_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int NmzbtvicQYHnXVMuJacYbItDndgz;

				public int FpuCTLgVfKTFdzLExbOvlHymYb;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						goto IL_001c;
					}
					goto IL_004e;
					IL_004e:
					FyoqPeQPDmUxcsSRLhMaHKFdiJhd fyoqPeQPDmUxcsSRLhMaHKFdiJhd = new FyoqPeQPDmUxcsSRLhMaHKFdiJhd(0);
					fyoqPeQPDmUxcsSRLhMaHKFdiJhd.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
					int num = -1445064194;
					goto IL_0021;
					IL_001c:
					num = -1445064193;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ -1445064194)
						{
						case 3:
							break;
						case 1:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							fyoqPeQPDmUxcsSRLhMaHKFdiJhd = this;
							num = -1445064194;
							continue;
						case 2:
							goto IL_004e;
						default:
							return fyoqPeQPDmUxcsSRLhMaHKFdiJhd;
						}
						break;
					}
					goto IL_001c;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					default:
						num = 248663663;
						goto IL_001a;
					case 1:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						FpuCTLgVfKTFdzLExbOvlHymYb++;
						num = 248663662;
						goto IL_001a;
					case 0:
						goto IL_0125;
						IL_001a:
						while (true)
						{
							switch (num ^ 0xED24E6E)
							{
							case 2:
								break;
							case 3:
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons != null)
								{
									NmzbtvicQYHnXVMuJacYbItDndgz = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons.Length;
									FpuCTLgVfKTFdzLExbOvlHymYb = 0;
									num = 248663662;
									continue;
								}
								goto default;
							case 4:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons[FpuCTLgVfKTFdzLExbOvlHymYb];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 248663656;
								continue;
							case 8:
								goto IL_00b7;
							case 1:
								num = 248663659;
								continue;
							case 6:
								return true;
							case 0:
								goto IL_0103;
							case 7:
								goto IL_0125;
							default:
								return false;
							}
							break;
							IL_0103:
							int num2;
							if (FpuCTLgVfKTFdzLExbOvlHymYb >= NmzbtvicQYHnXVMuJacYbItDndgz)
							{
								num = 248663659;
								num2 = num;
							}
							else
							{
								num = 248663658;
								num2 = num;
							}
							continue;
							IL_00b7:
							int num3;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements == null)
							{
								num = 248663659;
								num3 = num;
							}
							else
							{
								num = 248663661;
								num3 = num;
							}
						}
						goto default;
						IL_0125:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = 248663654;
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
				public FyoqPeQPDmUxcsSRLhMaHKFdiJhd(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.enTXCIFwxjKGOTdUNPCUNyQZEQr;
				}
			}

			internal override bool hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						goto IL_0008;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					int num;
					if (assignedAxisCount == 0)
					{
						num = -1362860511;
						goto IL_000d;
					}
					goto IL_0050;
					IL_0008:
					num = -1362860510;
					goto IL_000d;
					IL_0050:
					return true;
					IL_0046:
					if (assignedButtonCount == 0)
					{
						return false;
					}
					goto IL_0050;
					IL_000d:
					switch (num ^ -1362860512)
					{
					case 0:
						break;
					case 2:
						return false;
					default:
						goto IL_0046;
					}
					goto IL_0008;
				}
			}

			internal override bool disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			internal override bool isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			internal override IList<Platform> variants_base
			{
				get
				{
					return null;
				}
			}

			public override int assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			public override int assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			internal override Elements_Base elements_base
			{
				get
				{
					return elements;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				int num = identifiers.Length;
				string[] array = default(string[]);
				int num4 = default(int);
				int num3 = default(int);
				int num5 = default(int);
				while (true)
				{
					int num2 = 1423621853;
					while (true)
					{
						switch (num2 ^ 0x54DABED8)
						{
						case 3:
							break;
						case 5:
							if (num < elements.axisCount)
							{
								num2 = 1423621840;
								continue;
							}
							array = new string[elements.axisCount];
							num4 = array.Length;
							num2 = 1423621848;
							continue;
						case 6:
						{
							int elementIdentifier = elements.axes[num3].elementIdentifier;
							num5 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num2 = 1423621855;
							continue;
						}
						case 0:
							num3 = 0;
							num2 = 1423621842;
							continue;
						case 9:
							num3++;
							num2 = 1423621849;
							continue;
						case 2:
							num2 = 1423621841;
							continue;
						case 7:
							if (num5 >= 0)
							{
								int num6;
								if (num5 >= num)
								{
									num2 = 1423621843;
									num6 = num2;
								}
								else
								{
									num2 = 1423621852;
									num6 = num2;
								}
								continue;
							}
							goto case 11;
						case 8:
							Logger.LogError("You have too few element identifiers!");
							return new string[0];
						case 11:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = 1423621850;
							continue;
						case 10:
							num2 = 1423621849;
							continue;
						case 4:
							array[num3] = identifiers[num5].name;
							num2 = 1423621841;
							continue;
						default:
							if (num3 >= num4)
							{
								return array;
							}
							goto case 6;
						}
						break;
					}
				}
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				int num = identifiers.Length;
				if (num < buttonCount)
				{
					goto IL_0017;
				}
				string[] array = new string[buttonCount];
				int num2 = 0;
				int num3 = 2045491438;
				goto IL_001c;
				IL_001c:
				int num4 = default(int);
				while (true)
				{
					switch (num3 ^ 0x79EBB8EE)
					{
					case 7:
						break;
					case 2:
						if (num4 >= 0)
						{
							int num5;
							if (num4 >= num)
							{
								num3 = 2045491435;
								num5 = num3;
							}
							else
							{
								num3 = 2045491439;
								num5 = num3;
							}
							continue;
						}
						goto case 5;
					case 5:
						Logger.LogError("Element identifier index is out of bounds!");
						num3 = 2045491430;
						continue;
					case 4:
					{
						int elementIdentifier = elements.buttons[num2].elementIdentifier;
						num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						num3 = 2045491436;
						continue;
					}
					case 6:
						Logger.LogError("You have too few element identifiers!");
						return new string[0];
					case 0:
						num3 = 2045491437;
						continue;
					case 8:
						num2++;
						num3 = 2045491437;
						continue;
					case 1:
						array[num2] = identifiers[num4].name;
						num3 = 2045491430;
						continue;
					default:
						if (num2 >= buttonCount)
						{
							return array;
						}
						goto case 4;
					}
					break;
				}
				goto IL_0017;
				IL_0017:
				num3 = 2045491432;
				goto IL_001c;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				bool result;
				using (IEnumerator<Axis> enumerator = IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Axis current = enumerator.Current;
							if (current.elementIdentifier != elementIdentifierId)
							{
								break;
							}
							result = true;
							int num = 1493913793;
							while (true)
							{
								switch (num ^ 0x590B50C2)
								{
								case 0:
									num = 1493913792;
									continue;
								case 2:
									break;
								default:
									goto end_IL_0030;
								case 3:
									goto IL_00c8;
								}
								break;
							}
							continue;
							end_IL_0030:
							break;
						}
					}
				}
				foreach (Button item in IterateButtons())
				{
					if (item.elementIdentifier != elementIdentifierId)
					{
						continue;
					}
					result = true;
					goto IL_00c8;
				}
				return false;
				IL_00c8:
				return result;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				while (true)
				{
					int num = 880704499;
					while (true)
					{
						switch (num ^ 0x347E7BF1)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
						{
							int num2 = 0;
							using (IEnumerator<Button> enumerator = IterateButtons().GetEnumerator())
							{
								while (true)
								{
									IL_008d:
									int num3;
									int num4;
									if (enumerator.MoveNext())
									{
										num3 = 880704496;
										num4 = num3;
									}
									else
									{
										num3 = 880704499;
										num4 = num3;
									}
									while (true)
									{
										switch (num3 ^ 0x347E7BF1)
										{
										case 0:
											num3 = 880704496;
											continue;
										default:
											goto end_IL_0054;
										case 1:
										{
											Button current = enumerator.Current;
											buttons[num2] = current.elementIdentifier;
											num2++;
											num3 = 880704498;
											continue;
										}
										case 3:
											break;
										case 2:
											goto end_IL_0054;
										}
										goto IL_008d;
										continue;
										end_IL_0054:
										break;
									}
									break;
								}
							}
							num2 = 0;
							using (IEnumerator<Axis> enumerator2 = IterateAxes().GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									while (true)
									{
										Axis current2 = enumerator2.Current;
										axes[num2] = current2.elementIdentifier;
										num2++;
										int num5 = 880704497;
										while (true)
										{
											switch (num5 ^ 0x347E7BF1)
											{
											case 2:
												num5 = 880704496;
												continue;
											case 1:
												break;
											default:
												goto end_IL_00e1;
											}
											break;
										}
										continue;
										end_IL_00e1:
										break;
									}
								}
								return;
							}
						}
						}
						break;
						IL_002b:
						axes = new int[assignedAxisCount];
						num = 880704496;
					}
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				int num2 = default(int);
				while (true)
				{
					int num = 1501914531;
					while (true)
					{
						switch (num ^ 0x598565A7)
						{
						case 9:
							break;
						case 5:
							throw new NotImplementedException();
						case 8:
						{
							int num6;
							if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Hat)
							{
								num = 1501914534;
								num6 = num;
							}
							else
							{
								num = 1501914530;
								num6 = num;
							}
							continue;
						}
						case 10:
						{
							int num5;
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								num = 1501914543;
								num5 = num;
							}
							else
							{
								num = 1501914534;
								num5 = num;
							}
							continue;
						}
						case 1:
							array[num2] = AxisCalibrationData.Default;
							num = 1501914535;
							continue;
						case 6:
							if (Axes_orig[num2].calibrateAxis)
							{
								array[num2].zero = axes_orig[num2].axisZero;
								array[num2].min = axes_orig[num2].axisMin;
								array[num2].max = axes_orig[num2].axisMax;
								num = 1501914535;
								continue;
							}
							goto case 0;
						case 2:
							array[num2] = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							num = 1501914529;
							continue;
						case 0:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num2++;
							num = 1501914528;
							continue;
						case 3:
						{
							int num4;
							if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Axis)
							{
								num = 1501914533;
								num4 = num;
							}
							else
							{
								num = 1501914540;
								num4 = num;
							}
							continue;
						}
						case 4:
							num2 = 0;
							num = 1501914528;
							continue;
						case 11:
						{
							int num3;
							if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Custom)
							{
								num = 1501914533;
								num3 = num;
							}
							else
							{
								num = 1501914541;
								num3 = num;
							}
							continue;
						}
						default:
							if (num2 >= axes_orig.Length)
							{
								return array;
							}
							goto case 3;
						}
						break;
					}
				}
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				int num2 = default(int);
				while (true)
				{
					int num = -1336948188;
					while (true)
					{
						switch (num ^ -1336948187)
						{
						case 0:
							break;
						default:
							return;
						case 9:
							num2++;
							num = -1336948186;
							continue;
						case 5:
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = -1336948186;
							continue;
						case 2:
							axisRanges = new AxisRange[Axes_orig.Length];
							num = -1336948192;
							continue;
						case 11:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -1336948180;
							continue;
						case 10:
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num5;
								if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Hat)
								{
									num = -1336948191;
									num5 = num;
								}
								else
								{
									num = -1336948179;
									num5 = num;
								}
								continue;
							}
							goto case 4;
						case 7:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num4;
								if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									num = -1336948177;
									num4 = num;
								}
								else
								{
									num = -1336948178;
									num4 = num;
								}
								continue;
							}
							goto case 11;
						case 8:
							throw new Exception();
						case 3:
						{
							int num3;
							if (num2 < Axes_orig.Length)
							{
								num = -1336948190;
								num3 = num;
							}
							else
							{
								num = -1336948189;
								num3 = num;
							}
							continue;
						}
						case 4:
							axisRanges[num2] = AxisRange.Full;
							num = -1336948180;
							continue;
						case 1:
							axisInfos = null;
							if (Axes_orig == null)
							{
								return;
							}
							goto case 2;
						case 6:
							return;
						}
						break;
					}
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				int num2 = default(int);
				while (true)
				{
					int num = 1197362675;
					while (true)
					{
						switch (num ^ 0x475E4DF0)
						{
						case 0:
							break;
						default:
							return;
						case 5:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
							num2++;
							num = 1197362674;
							continue;
						case 4:
							buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
							num2 = 0;
							num = 1197362674;
							continue;
						case 2:
						{
							int num3;
							if (num2 < Buttons_orig.Length)
							{
								num = 1197362677;
								num3 = num;
							}
							else
							{
								num = 1197362673;
								num3 = num;
							}
							continue;
						}
						case 3:
							if (Buttons_orig == null)
							{
								return;
							}
							goto case 4;
						case 1:
							return;
						}
						break;
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					while (true)
					{
						int num = -166426883;
						while (true)
						{
							switch (num ^ -166426884)
							{
							case 2:
								break;
							case 1:
								goto IL_0026;
							default:
								return false;
							}
							break;
							IL_0026:
							axisRange = AxisRange.Full;
							num = -166426884;
						}
					}
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			internal IEnumerable<Axis> IterateAxes()
			{
				eHQXScuMfHUBgQChGkUkhDdButI eHQXScuMfHUBgQChGkUkhDdButI2 = new eHQXScuMfHUBgQChGkUkhDdButI(-2);
				eHQXScuMfHUBgQChGkUkhDdButI2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return eHQXScuMfHUBgQChGkUkhDdButI2;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				FyoqPeQPDmUxcsSRLhMaHKFdiJhd fyoqPeQPDmUxcsSRLhMaHKFdiJhd = new FyoqPeQPDmUxcsSRLhMaHKFdiJhd(-2);
				fyoqPeQPDmUxcsSRLhMaHKFdiJhd.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return fyoqPeQPDmUxcsSRLhMaHKFdiJhd;
			}

			public override object DeepClone()
			{
				Platform_Linux_Base platform_Linux_Base = new Platform_Linux_Base();
				CopyVars(platform_Linux_Base);
				return platform_Linux_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				Platform_Linux_Base platform_Linux_Base = destination as Platform_Linux_Base;
				if (platform_Linux_Base == null)
				{
					return;
				}
				while (true)
				{
					platform_Linux_Base.elements = MiscTools.DeepClone(elements);
					int num = 1638051142;
					while (true)
					{
						switch (num ^ 0x61A2AD44)
						{
						case 0:
							goto IL_000b;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_000b:
						num = 1638051141;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_Linux : Platform_Linux_Base
		{
			public Platform_Linux_Base[] variants;

			internal override IList<Platform> variants_base
			{
				get
				{
					return variants;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					int num2 = default(int);
					while (true)
					{
						int num = -299091486;
						while (true)
						{
							switch (num ^ -299091487)
							{
							case 6:
								break;
							case 3:
								num2 = 0;
								num = -299091485;
								continue;
							case 0:
								goto IL_0055;
							case 1:
								goto IL_0071;
							case 5:
								goto IL_0082;
							case 7:
								variantIndex = num2;
								return true;
							case 2:
								num = -299091484;
								continue;
							default:
								goto end_IL_001a;
							}
							break;
							IL_0082:
							int num3;
							if (num2 >= variants.Length)
							{
								num = -299091483;
								num3 = num;
							}
							else
							{
								num = -299091488;
								num3 = num;
							}
							continue;
							IL_00a3:
							num2++;
							num = -299091484;
							continue;
							IL_0055:
							int variantIndex2;
							if (variants[num2].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
							{
								num = -299091482;
								continue;
							}
							goto IL_00a3;
							IL_0071:
							if (variants[num2] != null)
							{
								num = -299091487;
								continue;
							}
							goto IL_00a3;
						}
						continue;
						end_IL_001a:
						break;
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_Linux platform_Linux = new Platform_Linux();
				CopyVars(platform_Linux);
				return platform_Linux;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_Linux platform_Linux = destination as Platform_Linux;
				while (true)
				{
					switch (0x291B3D04 ^ 0x291B3D06)
					{
					case 0:
						continue;
					case 2:
						if (platform_Linux == null)
						{
							return;
						}
						break;
					}
					break;
				}
				platform_Linux.variants = MiscTools.DeepClone(variants);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_WindowsUWP_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				[Serializable]
				public sealed class ElementCount : ElementCount_Base
				{
					public int hatCount;

					public override object DeepClone()
					{
						ElementCount elementCount = new ElementCount();
						CopyVars(elementCount);
						return elementCount;
					}

					internal override void CopyVars(ElementCount_Base P_0)
					{
						base.CopyVars(P_0);
						ElementCount elementCount = P_0 as ElementCount;
						if (elementCount == null)
						{
							while (true)
							{
								switch (-2116968436 ^ -2116968435)
								{
								case 2:
									continue;
								case 1:
									return;
								}
								break;
							}
						}
						elementCount.hatCount = hatCount;
					}

					internal override bool Matches(BridgedControllerHWInfo P_0)
					{
						if (!base.Matches(P_0))
						{
							return false;
						}
						if (hatCount >= 0)
						{
							return hatCount == P_0.hardwareHatCount;
						}
						return true;
					}
				}

				public int hatCount;

				public ElementCount[] alternateElementCounts;

				public bool manufacturer_useRegex;

				public bool productName_useRegex;

				public string[] manufacturer;

				public string[] productName;

				public string[] productGUID;

				internal override bool hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (productGUID != null)
						{
							goto IL_0012;
						}
						goto IL_003d;
						IL_003d:
						int num;
						if (productName != null && productName.Length > 0)
						{
							num = 530795900;
							goto IL_0017;
						}
						return false;
						IL_0012:
						num = 530795903;
						goto IL_0017;
						IL_0017:
						switch (num ^ 0x1FA34D7E)
						{
						case 0:
							break;
						case 1:
							goto IL_0030;
						default:
							return true;
						}
						goto IL_0012;
						IL_0030:
						if (productGUID.Length > 0)
						{
							return true;
						}
						goto IL_003d;
					}
				}

				internal override bool isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						return true;
					}
				}

				internal override int alternateElementCount
				{
					get
					{
						if (alternateElementCounts == null)
						{
							return 0;
						}
						return alternateElementCounts.Length;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock)
					{
						goto IL_0008;
					}
					goto IL_0043;
					IL_0008:
					int num = -1995925860;
					goto IL_000d;
					IL_000d:
					while (true)
					{
						switch (num ^ -1995925859)
						{
						case 3:
							break;
						case 1:
							goto IL_002a;
						case 2:
							goto IL_0039;
						default:
							goto IL_0095;
						}
						break;
						IL_0039:
						if (isAllowed)
						{
							return true;
						}
						goto IL_0043;
						IL_002a:
						if (hasData)
						{
							num = -1995925857;
							continue;
						}
						goto IL_0043;
					}
					goto IL_0008;
					IL_0095:
					return true;
					IL_0043:
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (strictMatch)
					{
						if (PidVid.ArrayContains(productGUID, ref bridgedControllerHWInfo.hw_pidVid))
						{
							if (!ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
							{
								return true;
							}
							if (productName == null)
							{
								goto IL_0095;
							}
							if (productName.Length == 0)
							{
								num = -1995925859;
								goto IL_000d;
							}
						}
						if (!AnyNameMatches(bridgedControllerHWInfo))
						{
							return false;
						}
						return true;
					}
					return AnyNameMatches(bridgedControllerHWInfo);
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					if (alternateElementCounts == null || index < 0 || index >= alternateElementCounts.Length)
					{
						return null;
					}
					return alternateElementCounts[index];
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						return false;
					}
					if (alternateMatched)
					{
						return true;
					}
					if (hatCount >= 0)
					{
						return bridgedControllerHWInfo.hardwareHatCount == hatCount;
					}
					return true;
				}

				private bool AnyNameMatches(BridgedControllerHWInfo bridgedControllerHWInfo)
				{
					if (NameMatches(bridgedControllerHWInfo.hw_productName, productName, productName_useRegex))
					{
						return true;
					}
					return false;
				}

				private bool NameMatches(string name, string[] names, bool useRegex)
				{
					string searchIn = default(string);
					int num = default(int);
					int num2;
					if (!string.IsNullOrEmpty(name))
					{
						if (names == null)
						{
							goto IL_000b;
						}
						searchIn = name.Trim();
						num = 0;
						num2 = -1012564719;
						goto IL_0010;
					}
					goto IL_0031;
					IL_0010:
					while (true)
					{
						switch (num2 ^ -1012564718)
						{
						case 2:
							break;
						case 4:
							goto IL_0031;
						case 0:
							goto IL_0043;
						case 3:
							num2 = -1012564717;
							continue;
						default:
							if (num >= names.Length)
							{
								return false;
							}
							goto IL_0043;
						}
						break;
						IL_0043:
						if (!string.IsNullOrEmpty(names[num]) && MatchingCriteria_Base.StringMatches(searchIn, names[num], useRegex))
						{
							return true;
						}
						num++;
						num2 = -1012564717;
					}
					goto IL_000b;
					IL_0031:
					return false;
					IL_000b:
					num2 = -1012564714;
					goto IL_0010;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					MatchingCriteria matchingCriteria = destination as MatchingCriteria;
					if (matchingCriteria == null)
					{
						goto IL_0011;
					}
					goto IL_0052;
					IL_0011:
					int num = -2142365398;
					goto IL_0016;
					IL_0016:
					while (true)
					{
						switch (num ^ -2142365397)
						{
						case 4:
							break;
						case 1:
							return;
						case 0:
							matchingCriteria.manufacturer_useRegex = manufacturer_useRegex;
							num = -2142365400;
							continue;
						case 2:
							goto IL_0052;
						default:
							matchingCriteria.productName_useRegex = productName_useRegex;
							matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
							matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
							matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
							return;
						}
						break;
					}
					goto IL_0011;
					IL_0052:
					matchingCriteria.hatCount = hatCount;
					num = -2142365397;
					goto IL_0016;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class UjBhHopLrCwwbeCzNEKucpeIabr : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
				{
					private Axis RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public Elements ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public int TFRJRAxoYGcPWYHubABHzzkJQIQ;

					Axis IEnumerator<Axis>.Current
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
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
						{
							goto IL_0012;
						}
						goto IL_004e;
						IL_0012:
						int num = -1523069270;
						goto IL_0017;
						IL_0017:
						UjBhHopLrCwwbeCzNEKucpeIabr ujBhHopLrCwwbeCzNEKucpeIabr = default(UjBhHopLrCwwbeCzNEKucpeIabr);
						while (true)
						{
							switch (num ^ -1523069272)
							{
							case 3:
								break;
							case 2:
								if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
								{
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
									ujBhHopLrCwwbeCzNEKucpeIabr = this;
									num = -1523069272;
									continue;
								}
								goto IL_004e;
							case 1:
								goto IL_004e;
							default:
								return ujBhHopLrCwwbeCzNEKucpeIabr;
							}
							break;
						}
						goto IL_0012;
						IL_004e:
						ujBhHopLrCwwbeCzNEKucpeIabr = new UjBhHopLrCwwbeCzNEKucpeIabr(0);
						ujBhHopLrCwwbeCzNEKucpeIabr.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = -1523069272;
						goto IL_0017;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
						while (true)
						{
							int num = -947765836;
							while (true)
							{
								switch (num ^ -947765840)
								{
								case 5:
									break;
								case 4:
									switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
									{
									default:
										num = -947765840;
										continue;
									case 0:
										break;
									case 1:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
										num = -947765839;
										continue;
									}
									goto case 3;
								case 3:
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
									if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.axes != null)
									{
										TFRJRAxoYGcPWYHubABHzzkJQIQ = 0;
										num = -947765838;
										continue;
									}
									goto default;
								case 6:
									RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.axes[TFRJRAxoYGcPWYHubABHzzkJQIQ];
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
									return true;
								case 2:
								{
									int num2;
									if (TFRJRAxoYGcPWYHubABHzzkJQIQ < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.axes.Length)
									{
										num = -947765834;
										num2 = num;
									}
									else
									{
										num = -947765840;
										num2 = num;
									}
									continue;
								}
								case 1:
									TFRJRAxoYGcPWYHubABHzzkJQIQ++;
									num = -947765838;
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
					public UjBhHopLrCwwbeCzNEKucpeIabr(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class mdisZyvrXXtskDBjKvzJIuIhRxB : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
				{
					private Button RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public Elements ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public int xMNdmTAtTGlxezdIBgCHeHZzSTu;

					Button IEnumerator<Button>.Current
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
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						mdisZyvrXXtskDBjKvzJIuIhRxB mdisZyvrXXtskDBjKvzJIuIhRxB2;
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							mdisZyvrXXtskDBjKvzJIuIhRxB2 = this;
						}
						else
						{
							while (true)
							{
								mdisZyvrXXtskDBjKvzJIuIhRxB2 = new mdisZyvrXXtskDBjKvzJIuIhRxB(0);
								int num = 448428683;
								while (true)
								{
									switch (num ^ 0x1ABA7A8B)
									{
									case 3:
										num = 448428682;
										continue;
									case 1:
										break;
									case 0:
										mdisZyvrXXtskDBjKvzJIuIhRxB2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
										num = 448428681;
										continue;
									default:
										goto end_IL_0049;
									}
									break;
								}
								continue;
								end_IL_0049:
								break;
							}
						}
						return mdisZyvrXXtskDBjKvzJIuIhRxB2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
						while (true)
						{
							int num = -962704214;
							while (true)
							{
								switch (num ^ -962704211)
								{
								case 6:
									break;
								case 7:
									switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
									{
									default:
										num = -962704210;
										continue;
									case 1:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
										xMNdmTAtTGlxezdIBgCHeHZzSTu++;
										num = -962704216;
										continue;
									case 0:
										break;
									}
									goto case 2;
								case 4:
									return true;
								case 0:
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
									num = -962704215;
									continue;
								case 5:
								{
									int num2;
									if (xMNdmTAtTGlxezdIBgCHeHZzSTu < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttons.Length)
									{
										num = -962704212;
										num2 = num;
									}
									else
									{
										num = -962704219;
										num2 = num;
									}
									continue;
								}
								case 2:
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
									if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttons != null)
									{
										xMNdmTAtTGlxezdIBgCHeHZzSTu = 0;
										num = -962704220;
										continue;
									}
									goto default;
								case 3:
									num = -962704219;
									continue;
								case 9:
									num = -962704216;
									continue;
								case 1:
									RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttons[xMNdmTAtTGlxezdIBgCHeHZzSTu];
									num = -962704211;
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
					public mdisZyvrXXtskDBjKvzJIuIhRxB(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				public override int axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal IEnumerable<Axis> Axes
				{
					get
					{
						UjBhHopLrCwwbeCzNEKucpeIabr ujBhHopLrCwwbeCzNEKucpeIabr = new UjBhHopLrCwwbeCzNEKucpeIabr(-2);
						ujBhHopLrCwwbeCzNEKucpeIabr.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
						return ujBhHopLrCwwbeCzNEKucpeIabr;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					get
					{
						mdisZyvrXXtskDBjKvzJIuIhRxB mdisZyvrXXtskDBjKvzJIuIhRxB2 = new mdisZyvrXXtskDBjKvzJIuIhRxB(-2);
						mdisZyvrXXtskDBjKvzJIuIhRxB2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
						return mdisZyvrXXtskDBjKvzJIuIhRxB2;
					}
				}

				internal Axis GetAxis(int axisIndex)
				{
					if (axes == null || axisIndex < 0 || axisIndex >= axes.Length)
					{
						return null;
					}
					return axes[axisIndex];
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					int num = 0;
					int num2 = default(int);
					while (true)
					{
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = -139851015;
							goto IL_0009;
						}
						goto IL_0069;
						IL_0009:
						while (true)
						{
							switch (num3 ^ -139851011)
							{
							case 5:
								num3 = -139851012;
								continue;
							case 0:
								break;
							case 2:
								goto end_IL_0009;
							case 4:
								num3 = -139851010;
								continue;
							case 1:
								goto IL_0069;
							default:
								if (num2 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								break;
							}
							if (buttons[num2].elementIdentifier == elementIdentifier.id)
							{
								return ControllerElementType.Button;
							}
							num2++;
							num3 = -139851010;
							continue;
							end_IL_0009:
							break;
						}
						continue;
						IL_0069:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							break;
						}
						num++;
						num3 = -139851009;
						goto IL_0009;
					}
					return ControllerElementType.Axis;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					HardwareElementSourceTypeWithHat sourceType = default(HardwareElementSourceTypeWithHat);
					while (num < axisCount)
					{
						while (true)
						{
							int num2;
							if (axes[num].elementIdentifier == elementIdentifier.id)
							{
								sourceType = axes[num].sourceType;
								switch (sourceType)
								{
								case HardwareElementSourceTypeWithHat.Button:
									axisRange = AxisRange.Positive;
									return true;
								case HardwareElementSourceTypeWithHat.Hat:
									goto IL_00c2;
								case HardwareElementSourceTypeWithHat.Axis:
									goto IL_00f3;
								}
								num2 = -1585107362;
								goto IL_000c;
							}
							goto IL_009e;
							IL_000c:
							while (true)
							{
								switch (num2 ^ -1585107367)
								{
								case 0:
									num2 = -1585107364;
									continue;
								case 5:
									break;
								case 3:
									if (axes[num].invert)
									{
										axisRange = InputTools.InvertAxisRange(axisRange);
										num2 = -1585107363;
										continue;
									}
									goto case 4;
								case 6:
									goto IL_009e;
								case 7:
									goto IL_00ac;
								case 4:
									return true;
								case 2:
									goto IL_00f3;
								case 8:
									goto IL_010c;
								default:
									goto end_IL_0040;
								}
								break;
								IL_00ac:
								if (sourceType == HardwareElementSourceTypeWithHat.Custom)
								{
									num2 = -1585107365;
									continue;
								}
								throw new NotImplementedException();
							}
							continue;
							IL_00c2:
							axisRange = axes[num].sourceHatRange;
							if (axes[num].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
								num2 = -1585107375;
								goto IL_000c;
							}
							goto IL_010c;
							IL_00f3:
							axisRange = axes[num].sourceAxisRange;
							num2 = -1585107366;
							goto IL_000c;
							IL_010c:
							return true;
							IL_009e:
							num++;
							num2 = -1585107368;
							goto IL_000c;
							continue;
							end_IL_0040:
							break;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					Elements elements = default(Elements);
					while (true)
					{
						int num = 349852340;
						while (true)
						{
							switch (num ^ 0x14DA52B6)
							{
							case 0:
								break;
							case 3:
								return;
							case 5:
							{
								int num2;
								if (elements == null)
								{
									num = 349852341;
									num2 = num;
								}
								else
								{
									num = 349852338;
									num2 = num;
								}
								continue;
							}
							case 2:
								elements = destination as Elements;
								num = 349852339;
								continue;
							case 4:
								elements.axes = ArrayTools.DeepClone(axes);
								num = 349852343;
								continue;
							default:
								elements.buttons = ArrayTools.DeepClone(buttons);
								return;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Element : IDeepCloneable
			{
				public abstract object DeepClone();

				protected virtual void ImportVars(Element source)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class Button : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceButton;

				public int sourceAxis;

				public Pole sourceAxisPole;

				public float axisDeadZone;

				public int sourceHat;

				public HatType sourceHatType;

				public HatDirection sourceHatDirection;

				public bool requireMultipleButtons;

				public int[] requiredButtons;

				public bool ignoreIfButtonsActive;

				public int[] ignoreIfButtonsActiveButtons;

				public HardwareButtonInfo buttonInfo;

				public Button()
				{
					sourceType = HardwareElementSourceTypeWithHat.Button;
				}

				public override object DeepClone()
				{
					Button button = new Button();
					button.ImportVars(this);
					return button;
				}

				protected override void ImportVars(Element source)
				{
					base.ImportVars(source);
					Button button = source as Button;
					if (button == null)
					{
						return;
					}
					while (true)
					{
						elementIdentifier = button.elementIdentifier;
						sourceType = button.sourceType;
						sourceButton = button.sourceButton;
						sourceAxis = button.sourceAxis;
						int num = -1396378832;
						while (true)
						{
							switch (num ^ -1396378827)
							{
							case 0:
								num = -1396378825;
								continue;
							case 4:
								sourceHat = button.sourceHat;
								num = -1396378830;
								continue;
							case 1:
								requiredButtons = ArrayTools.ShallowCopy(button.requiredButtons);
								ignoreIfButtonsActive = button.ignoreIfButtonsActive;
								num = -1396378829;
								continue;
							case 6:
								ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(button.ignoreIfButtonsActiveButtons);
								num = -1396378826;
								continue;
							case 7:
								sourceHatType = button.sourceHatType;
								sourceHatDirection = button.sourceHatDirection;
								requireMultipleButtons = button.requireMultipleButtons;
								num = -1396378828;
								continue;
							case 5:
								sourceAxisPole = button.sourceAxisPole;
								axisDeadZone = button.axisDeadZone;
								num = -1396378831;
								continue;
							case 2:
								break;
							default:
								buttonInfo = MiscTools.DeepClone(button.buttonInfo);
								return;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class Axis : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceAxis;

				public AxisRange sourceAxisRange;

				public bool invert;

				public float axisDeadZone;

				public bool calibrateAxis;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public AxisCalibrationInfoEntry[] alternateCalibrations;

				public HardwareAxisInfo axisInfo;

				public int sourceButton;

				public Pole buttonAxisContribution;

				public int sourceHat;

				public AxisDirection sourceHatDirection;

				public AxisRange sourceHatRange;

				public Axis()
				{
					sourceType = HardwareElementSourceTypeWithHat.Axis;
				}

				public override object DeepClone()
				{
					Axis axis = new Axis();
					while (true)
					{
						int num = -986883680;
						while (true)
						{
							switch (num ^ -986883679)
							{
							case 2:
								break;
							case 1:
								goto IL_0024;
							default:
								return axis;
							}
							break;
							IL_0024:
							axis.ImportVars(this);
							num = -986883679;
						}
					}
				}

				protected override void ImportVars(Element source)
				{
					base.ImportVars(source);
					Axis axis = source as Axis;
					if (axis == null)
					{
						goto IL_0014;
					}
					goto IL_00db;
					IL_0014:
					int num = 2059553643;
					goto IL_0019;
					IL_0019:
					while (true)
					{
						switch (num ^ 0x7AC24B6A)
						{
						case 0:
							break;
						default:
							return;
						case 3:
							axisMin = axis.axisMin;
							num = 2059553640;
							continue;
						case 10:
							alternateCalibrations = MiscTools.DeepClone(axis.alternateCalibrations);
							num = 2059553644;
							continue;
						case 2:
							axisMax = axis.axisMax;
							num = 2059553633;
							continue;
						case 7:
							sourceType = axis.sourceType;
							num = 2059553635;
							continue;
						case 9:
							sourceAxis = axis.sourceAxis;
							sourceAxisRange = axis.sourceAxisRange;
							invert = axis.invert;
							num = 2059553634;
							continue;
						case 5:
							goto IL_00db;
						case 8:
							axisDeadZone = axis.axisDeadZone;
							calibrateAxis = axis.calibrateAxis;
							num = 2059553646;
							continue;
						case 11:
							axisInfo = MiscTools.DeepClone(axis.axisInfo);
							sourceButton = axis.sourceButton;
							buttonAxisContribution = axis.buttonAxisContribution;
							sourceHat = axis.sourceHat;
							sourceHatDirection = axis.sourceHatDirection;
							sourceHatRange = axis.sourceHatRange;
							num = 2059553632;
							continue;
						case 1:
							return;
						case 4:
							axisZero = axis.axisZero;
							num = 2059553641;
							continue;
						case 6:
							return;
						}
						break;
					}
					goto IL_0014;
					IL_00db:
					elementIdentifier = axis.elementIdentifier;
					num = 2059553645;
					goto IL_0019;
				}
			}

			private sealed class IexfUbSLGeaycfqmxThIIDBIvIo : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_WindowsUWP_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int oEeLPaZTeqTtmONcJpqunLUKyGP;

				public int GhXwphEGDtCzsNTPQcgRYATPhTA;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					IexfUbSLGeaycfqmxThIIDBIvIo iexfUbSLGeaycfqmxThIIDBIvIo;
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						iexfUbSLGeaycfqmxThIIDBIvIo = this;
					}
					else
					{
						while (true)
						{
							iexfUbSLGeaycfqmxThIIDBIvIo = new IexfUbSLGeaycfqmxThIIDBIvIo(0);
							iexfUbSLGeaycfqmxThIIDBIvIo.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
							int num = 846357810;
							while (true)
							{
								switch (num ^ 0x32726530)
								{
								case 0:
									num = 846357809;
									continue;
								case 1:
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
					return iexfUbSLGeaycfqmxThIIDBIvIo;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
					while (true)
					{
						int num = -333747809;
						while (true)
						{
							switch (num ^ -333747810)
							{
							case 3:
								break;
							case 1:
								switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
								{
								default:
									num = -333747812;
									continue;
								case 1:
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
									GhXwphEGDtCzsNTPQcgRYATPhTA++;
									num = -333747814;
									continue;
								case 0:
									break;
								}
								goto case 0;
							case 5:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes[GhXwphEGDtCzsNTPQcgRYATPhTA];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							case 0:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements != null)
								{
									int num3;
									if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes != null)
									{
										num = -333747816;
										num3 = num;
									}
									else
									{
										num = -333747812;
										num3 = num;
									}
									continue;
								}
								goto default;
							case 6:
								oEeLPaZTeqTtmONcJpqunLUKyGP = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes.Length;
								num = -333747815;
								continue;
							case 4:
							{
								int num2;
								if (GhXwphEGDtCzsNTPQcgRYATPhTA >= oEeLPaZTeqTtmONcJpqunLUKyGP)
								{
									num = -333747812;
									num2 = num;
								}
								else
								{
									num = -333747813;
									num2 = num;
								}
								continue;
							}
							case 7:
								GhXwphEGDtCzsNTPQcgRYATPhTA = 0;
								num = -333747814;
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
				public IexfUbSLGeaycfqmxThIIDBIvIo(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class ARsxuAqjlVxcAyGgkWXFRWCXbaF : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_WindowsUWP_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int kVTNGTSQCLkmFfRFaHZmfypnnGQv;

				public int iIAddCaiasmnbnVPRGFMWAhbCmTd;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						goto IL_001c;
					}
					goto IL_0056;
					IL_0056:
					ARsxuAqjlVxcAyGgkWXFRWCXbaF aRsxuAqjlVxcAyGgkWXFRWCXbaF = new ARsxuAqjlVxcAyGgkWXFRWCXbaF(0);
					int num = -1633540862;
					goto IL_0021;
					IL_001c:
					num = -1633540864;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ -1633540862)
						{
						case 3:
							break;
						case 2:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							aRsxuAqjlVxcAyGgkWXFRWCXbaF = this;
							num = -1633540861;
							continue;
						case 4:
							goto IL_0056;
						case 0:
							aRsxuAqjlVxcAyGgkWXFRWCXbaF.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
							num = -1633540857;
							continue;
						case 1:
							num = -1633540857;
							continue;
						default:
							return aRsxuAqjlVxcAyGgkWXFRWCXbaF;
						}
						break;
					}
					goto IL_001c;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 1:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						iIAddCaiasmnbnVPRGFMWAhbCmTd++;
						num = 1579425699;
						goto IL_001f;
					case 0:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							int num3;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements == null)
							{
								num = 1579425696;
								num3 = num;
							}
							else
							{
								num = 1579425697;
								num3 = num;
							}
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x5E241FA3)
							{
							case 4:
								num = 1579425698;
								continue;
							case 0:
								break;
							case 5:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons[iIAddCaiasmnbnVPRGFMWAhbCmTd];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							case 2:
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons != null)
								{
									kVTNGTSQCLkmFfRFaHZmfypnnGQv = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons.Length;
									iIAddCaiasmnbnVPRGFMWAhbCmTd = 0;
									num = 1579425699;
									continue;
								}
								goto end_IL_0008;
							case 1:
								goto end_IL_001f;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (iIAddCaiasmnbnVPRGFMWAhbCmTd < kVTNGTSQCLkmFfRFaHZmfypnnGQv)
							{
								num = 1579425702;
								num2 = num;
							}
							else
							{
								num = 1579425696;
								num2 = num;
							}
							continue;
							end_IL_001f:
							break;
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
				public ARsxuAqjlVxcAyGgkWXFRWCXbaF(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.lVqnUVyYsKsHZMKeqoJPZENWgClF;
				}
			}

			internal override bool hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedAxisCount == 0 && assignedButtonCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			internal override bool disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			internal override bool isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						goto IL_0008;
					}
					int num;
					if (matchingCriteria == null)
					{
						num = 15772699;
						goto IL_000d;
					}
					return matchingCriteria.isAllowed;
					IL_0008:
					num = 15772696;
					goto IL_000d;
					IL_000d:
					switch (num ^ 0xF0AC1A)
					{
					case 0:
						break;
					case 2:
						return false;
					default:
						return false;
					}
					goto IL_0008;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			internal override IList<Platform> variants_base
			{
				get
				{
					return null;
				}
			}

			public override int assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			public override int assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			internal override Elements_Base elements_base
			{
				get
				{
					return elements;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				while (true)
				{
					int num = 901341385;
					while (true)
					{
						switch (num ^ 0x35B960C8)
						{
						case 2:
							break;
						case 1:
							platformMap = null;
							if (matchingCriteria != null)
							{
								goto IL_002d;
							}
							goto IL_0049;
						default:
							{
								if (matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
								{
									platformMap = this;
									return true;
								}
								goto IL_0049;
							}
							IL_0049:
							return false;
						}
						break;
						IL_002d:
						num = 901341384;
					}
				}
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				int num = identifiers.Length;
				int num5 = default(int);
				int num3 = default(int);
				string[] array = default(string[]);
				int num4 = default(int);
				while (true)
				{
					int num2 = -63467771;
					while (true)
					{
						switch (num2 ^ -63467773)
						{
						case 4:
							break;
						case 7:
						{
							int num7;
							if (num5 < num)
							{
								num2 = -63467770;
								num7 = num2;
							}
							else
							{
								num2 = -63467775;
								num7 = num2;
							}
							continue;
						}
						case 8:
							num3 = 0;
							num2 = -63467776;
							continue;
						case 6:
							if (num < elements.axisCount)
							{
								Logger.LogError("You have too few element identifiers!");
								return new string[0];
							}
							array = new string[elements.axisCount];
							num4 = array.Length;
							num2 = -63467765;
							continue;
						case 5:
							array[num3] = identifiers[num5].name;
							num2 = -63467773;
							continue;
						case 0:
							num3++;
							num2 = -63467776;
							continue;
						case 1:
						{
							int elementIdentifier = elements.axes[num3].elementIdentifier;
							num5 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							int num6;
							if (num5 < 0)
							{
								num2 = -63467775;
								num6 = num2;
							}
							else
							{
								num2 = -63467772;
								num6 = num2;
							}
							continue;
						}
						case 2:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = -63467773;
							continue;
						default:
							if (num3 >= num4)
							{
								return array;
							}
							goto case 1;
						}
						break;
					}
				}
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				int num = identifiers.Length;
				if (num < buttonCount)
				{
					goto IL_0017;
				}
				string[] array = new string[buttonCount];
				int num2 = 1029633233;
				goto IL_001c;
				IL_001c:
				int num3 = default(int);
				int num5 = default(int);
				while (true)
				{
					switch (num2 ^ 0x3D5EF4D5)
					{
					case 5:
						break;
					case 2:
					{
						int elementIdentifier = elements.buttons[num3].elementIdentifier;
						num5 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						int num6;
						if (num5 >= 0)
						{
							num2 = 1029633245;
							num6 = num2;
						}
						else
						{
							num2 = 1029633237;
							num6 = num2;
						}
						continue;
					}
					case 4:
						num3 = 0;
						num2 = 1029633244;
						continue;
					case 8:
					{
						int num7;
						if (num5 >= num)
						{
							num2 = 1029633237;
							num7 = num2;
						}
						else
						{
							num2 = 1029633234;
							num7 = num2;
						}
						continue;
					}
					case 1:
						num3++;
						num2 = 1029633244;
						continue;
					case 0:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = 1029633235;
						continue;
					case 7:
						array[num3] = identifiers[num5].name;
						num2 = 1029633236;
						continue;
					case 9:
					{
						int num4;
						if (num3 >= buttonCount)
						{
							num2 = 1029633238;
							num4 = num2;
						}
						else
						{
							num2 = 1029633239;
							num4 = num2;
						}
						continue;
					}
					case 10:
						Logger.LogError("You have too few element identifiers!");
						return new string[0];
					case 6:
						num2 = 1029633236;
						continue;
					default:
						return array;
					}
					break;
				}
				goto IL_0017;
				IL_0017:
				num2 = 1029633247;
				goto IL_001c;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				using (IEnumerator<Button> enumerator2 = IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Button current2 = enumerator2.Current;
							int num = -1798985613;
							while (true)
							{
								switch (num ^ -1798985615)
								{
								case 0:
									num = -1798985616;
									continue;
								case 1:
									break;
								case 2:
									if (current2.elementIdentifier == elementIdentifierId)
									{
										return true;
									}
									goto end_IL_008f;
								default:
									goto end_IL_008f;
								}
								break;
							}
							continue;
							end_IL_008f:
							break;
						}
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				using (IEnumerator<Button> enumerator = IterateButtons().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Button current = enumerator.Current;
							buttons[num] = current.elementIdentifier;
							int num2 = -155111228;
							while (true)
							{
								switch (num2 ^ -155111225)
								{
								case 0:
									num2 = -155111227;
									continue;
								case 2:
									break;
								case 3:
									num++;
									num2 = -155111226;
									continue;
								default:
									goto end_IL_004c;
								}
								break;
							}
							continue;
							end_IL_004c:
							break;
						}
					}
				}
				num = 0;
				IEnumerator<Axis> enumerator2 = IterateAxes().GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Axis current2 = enumerator2.Current;
							int num3 = -155111227;
							while (true)
							{
								switch (num3 ^ -155111225)
								{
								case 0:
									num3 = -155111228;
									continue;
								case 3:
									break;
								case 2:
									axes[num] = current2.elementIdentifier;
									num++;
									num3 = -155111226;
									continue;
								default:
									goto end_IL_00b6;
								}
								break;
							}
							continue;
							end_IL_00b6:
							break;
						}
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						while (true)
						{
							IL_00e9:
							int num4 = -155111227;
							while (true)
							{
								switch (num4 ^ -155111225)
								{
								case 0:
									break;
								default:
									goto end_IL_00ee;
								case 2:
									goto IL_0107;
								case 1:
									goto end_IL_00ee;
								}
								goto IL_00e9;
								IL_0107:
								enumerator2.Dispose();
								num4 = -155111226;
								continue;
								end_IL_00ee:
								break;
							}
							break;
						}
					}
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				int num2 = default(int);
				AxisCalibrationData[] array = default(AxisCalibrationData[]);
				while (true)
				{
					int num = -1016978025;
					while (true)
					{
						switch (num ^ -1016978029)
						{
						case 2:
							break;
						case 10:
						{
							int num6;
							if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Custom)
							{
								num = -1016978030;
								num6 = num;
							}
							else
							{
								num = -1016978032;
								num6 = num;
							}
							continue;
						}
						case 7:
							array[num2].zero = axes_orig[num2].axisZero;
							array[num2].min = axes_orig[num2].axisMin;
							array[num2].max = axes_orig[num2].axisMax;
							num = -1016978029;
							continue;
						case 4:
							if (axes_orig == null)
							{
								num = -1016978024;
								continue;
							}
							array = new AxisCalibrationData[axes_orig.Length];
							num2 = 0;
							num = -1016978018;
							continue;
						case 5:
						{
							int num4;
							if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Axis)
							{
								num = -1016978030;
								num4 = num;
							}
							else
							{
								num = -1016978023;
								num4 = num;
							}
							continue;
						}
						case 13:
							num = -1016978022;
							continue;
						case 1:
						{
							array[num2] = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							int num5;
							if (!Axes_orig[num2].calibrateAxis)
							{
								num = -1016978017;
								num5 = num;
							}
							else
							{
								num = -1016978028;
								num5 = num;
							}
							continue;
						}
						case 3:
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num3;
								if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Hat)
								{
									num = -1016978021;
									num3 = num;
								}
								else
								{
									num = -1016978027;
									num3 = num;
								}
								continue;
							}
							goto case 6;
						case 6:
							array[num2] = AxisCalibrationData.Default;
							num = -1016978017;
							continue;
						case 0:
							num = -1016978017;
							continue;
						case 8:
							throw new NotImplementedException();
						case 12:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num2++;
							num = -1016978022;
							continue;
						case 11:
							return null;
						default:
							if (num2 >= axes_orig.Length)
							{
								return array;
							}
							goto case 5;
						}
						break;
					}
				}
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				int num2 = default(int);
				while (true)
				{
					axisRanges = new AxisRange[Axes_orig.Length];
					int num = 1779514453;
					while (true)
					{
						switch (num ^ 0x6A113C54)
						{
						case 5:
							num = 1779514461;
							continue;
						case 11:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = 1779514460;
							continue;
						case 7:
						{
							int num5;
							if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Hat)
							{
								num = 1779514462;
								num5 = num;
							}
							else
							{
								num = 1779514450;
								num5 = num;
							}
							continue;
						}
						case 3:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num4;
								if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Custom)
								{
									num = 1779514463;
									num4 = num;
								}
								else
								{
									num = 1779514452;
									num4 = num;
								}
								continue;
							}
							goto case 11;
						case 0:
						{
							int num3;
							if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Button)
							{
								num = 1779514462;
								num3 = num;
							}
							else
							{
								num = 1779514451;
								num3 = num;
							}
							continue;
						}
						case 9:
							break;
						case 6:
							throw new Exception();
						case 1:
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = 1779514454;
							continue;
						case 4:
							num = 1779514460;
							continue;
						case 10:
							axisRanges[num2] = AxisRange.Full;
							num = 1779514448;
							continue;
						case 8:
							num2++;
							num = 1779514454;
							continue;
						default:
							if (num2 >= Axes_orig.Length)
							{
								return;
							}
							goto case 3;
						}
						break;
					}
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				int num2 = default(int);
				while (true)
				{
					int num = 361538292;
					while (true)
					{
						switch (num ^ 0x158CA2F7)
						{
						case 0:
							break;
						case 4:
							buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
							num2 = 0;
							num = 361538294;
							continue;
						case 5:
							return;
						case 3:
						{
							int num3;
							if (Buttons_orig != null)
							{
								num = 361538291;
								num3 = num;
							}
							else
							{
								num = 361538290;
								num3 = num;
							}
							continue;
						}
						case 2:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
							num2++;
							num = 361538294;
							continue;
						default:
							if (num2 >= Buttons_orig.Length)
							{
								return;
							}
							goto case 2;
						}
						break;
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			internal IEnumerable<Axis> IterateAxes()
			{
				IexfUbSLGeaycfqmxThIIDBIvIo iexfUbSLGeaycfqmxThIIDBIvIo = new IexfUbSLGeaycfqmxThIIDBIvIo(-2);
				iexfUbSLGeaycfqmxThIIDBIvIo.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return iexfUbSLGeaycfqmxThIIDBIvIo;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				ARsxuAqjlVxcAyGgkWXFRWCXbaF aRsxuAqjlVxcAyGgkWXFRWCXbaF = new ARsxuAqjlVxcAyGgkWXFRWCXbaF(-2);
				aRsxuAqjlVxcAyGgkWXFRWCXbaF.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return aRsxuAqjlVxcAyGgkWXFRWCXbaF;
			}

			public override object DeepClone()
			{
				Platform_WindowsUWP_Base platform_WindowsUWP_Base = new Platform_WindowsUWP_Base();
				CopyVars(platform_WindowsUWP_Base);
				return platform_WindowsUWP_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				Platform_WindowsUWP_Base platform_WindowsUWP_Base = destination as Platform_WindowsUWP_Base;
				if (platform_WindowsUWP_Base != null)
				{
					platform_WindowsUWP_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_WindowsUWP : Platform_WindowsUWP_Base
		{
			public Platform_WindowsUWP_Base[] variants;

			internal override IList<Platform> variants_base
			{
				get
				{
					return variants;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					int num2 = default(int);
					while (true)
					{
						int num = 130796017;
						while (true)
						{
							switch (num ^ 0x7CBC9F5)
							{
							case 3:
								break;
							case 6:
								goto IL_0048;
							case 1:
								variantIndex = num2;
								return true;
							case 4:
								num2 = 0;
								num = 130796019;
								continue;
							case 2:
								goto IL_007d;
							case 5:
								goto IL_008e;
							default:
								goto end_IL_001a;
							}
							break;
							IL_008e:
							int variantIndex2;
							if (variants[num2].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
							{
								num = 130796020;
								continue;
							}
							goto IL_0069;
							IL_0069:
							num2++;
							num = 130796019;
							continue;
							IL_007d:
							if (variants[num2] != null)
							{
								num = 130796016;
								continue;
							}
							goto IL_0069;
							IL_0048:
							int num3;
							if (num2 < variants.Length)
							{
								num = 130796023;
								num3 = num;
							}
							else
							{
								num = 130796021;
								num3 = num;
							}
						}
						continue;
						end_IL_001a:
						break;
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_WindowsUWP platform_WindowsUWP = new Platform_WindowsUWP();
				CopyVars(platform_WindowsUWP);
				return platform_WindowsUWP;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_WindowsUWP platform_WindowsUWP = default(Platform_WindowsUWP);
				while (true)
				{
					int num = -1190394797;
					while (true)
					{
						switch (num ^ -1190394800)
						{
						case 4:
							break;
						case 3:
							platform_WindowsUWP = destination as Platform_WindowsUWP;
							num = -1190394800;
							continue;
						case 1:
							return;
						case 0:
						{
							int num2;
							if (platform_WindowsUWP == null)
							{
								num = -1190394799;
								num2 = num;
							}
							else
							{
								num = -1190394798;
								num2 = num;
							}
							continue;
						}
						default:
							platform_WindowsUWP.variants = MiscTools.DeepClone(variants);
							return;
						}
						break;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_Fallback_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				public bool alwaysMatch;

				public bool productName_useRegex;

				public string[] productName;

				public bool matchUnityVersion;

				public string matchUnityVersion_min;

				public string matchUnityVersion_max;

				public bool matchSysVersion;

				public string matchSysVersion_min;

				public string matchSysVersion_max;

				internal override bool hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (alwaysMatch)
						{
							return true;
						}
						if (productName != null && productName.Length > 0)
						{
							return true;
						}
						return false;
					}
				}

				internal override bool isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							goto IL_0008;
						}
						int num;
						if (matchUnityVersion && !UnityTools.IsUnityVersionInRange(matchUnityVersion_min, matchUnityVersion_max))
						{
							num = -764950627;
							goto IL_000d;
						}
						if (matchSysVersion && !PlatformTools.IsSysVersionInRange(matchSysVersion_min, matchSysVersion_max))
						{
							return false;
						}
						return true;
						IL_0008:
						num = -764950626;
						goto IL_000d;
						IL_000d:
						switch (num ^ -764950625)
						{
						case 0:
							break;
						case 1:
							return false;
						default:
							return false;
						}
						goto IL_0008;
					}
				}

				internal override int alternateElementCount
				{
					get
					{
						return 0;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!isAllowed)
					{
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					int num2 = default(int);
					while (true)
					{
						int num = 58061852;
						while (true)
						{
							switch (num ^ 0x375F41D)
							{
							case 4:
								break;
							case 2:
							{
								int num3;
								if (num2 >= productName.Length)
								{
									num = 58061854;
									num3 = num;
								}
								else
								{
									num = 58061853;
									num3 = num;
								}
								continue;
							}
							case 0:
							{
								string searchFor = productName[num2];
								if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
								{
									return true;
								}
								num2++;
								num = 58061855;
								continue;
							}
							case 5:
								text = text.Trim();
								if (productName != null)
								{
									num2 = 0;
									num = 58061851;
									continue;
								}
								goto default;
							case 6:
								num = 58061855;
								continue;
							case 1:
								if (text == null)
								{
									text = string.Empty;
									num = 58061848;
									continue;
								}
								goto case 5;
							default:
								return false;
							}
							break;
						}
					}
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched);
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					MatchingCriteria matchingCriteria = default(MatchingCriteria);
					while (true)
					{
						int num = -1245976368;
						while (true)
						{
							switch (num ^ -1245976362)
							{
							case 4:
								break;
							case 6:
							{
								matchingCriteria = destination as MatchingCriteria;
								int num2;
								if (matchingCriteria == null)
								{
									num = -1245976364;
									num2 = num;
								}
								else
								{
									num = -1245976361;
									num2 = num;
								}
								continue;
							}
							case 5:
								matchingCriteria.matchUnityVersion_max = matchUnityVersion_max;
								matchingCriteria.matchSysVersion = matchSysVersion;
								matchingCriteria.matchSysVersion_min = matchSysVersion_min;
								num = -1245976363;
								continue;
							case 0:
								matchingCriteria.matchUnityVersion_min = matchUnityVersion_min;
								num = -1245976365;
								continue;
							case 1:
								matchingCriteria.alwaysMatch = alwaysMatch;
								matchingCriteria.productName_useRegex = productName_useRegex;
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								matchingCriteria.matchUnityVersion = matchUnityVersion;
								num = -1245976362;
								continue;
							case 2:
								return;
							default:
								matchingCriteria.matchSysVersion_max = matchSysVersion_max;
								return;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				public override int axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					int num = 0;
					int num2 = default(int);
					while (true)
					{
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = 8048558;
							goto IL_0009;
						}
						goto IL_0069;
						IL_0009:
						while (true)
						{
							switch (num3 ^ 0x7ACFAD)
							{
							case 4:
								num3 = 8048552;
								continue;
							case 3:
								num3 = 8048556;
								continue;
							case 0:
								break;
							case 2:
								goto IL_0047;
							case 5:
								goto IL_0069;
							default:
								if (num2 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								goto IL_0047;
							}
							break;
							IL_0047:
							if (buttons[num2].elementIdentifier == elementIdentifier.id)
							{
								return ControllerElementType.Button;
							}
							num2++;
							num3 = 8048556;
						}
						continue;
						IL_0069:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							break;
						}
						num++;
						num3 = 8048557;
						goto IL_0009;
					}
					return ControllerElementType.Axis;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					while (num < axisCount)
					{
						while (true)
						{
							IL_0062:
							if (axes[num].elementIdentifier == elementIdentifier.id)
							{
								switch (axes[num].sourceType)
								{
								case HardwareElementSourceTypeWithHat.Axis:
									break;
								case HardwareElementSourceTypeWithHat.Custom:
									goto IL_0098;
								case HardwareElementSourceTypeWithHat.Button:
									axisRange = AxisRange.Positive;
									return true;
								default:
									throw new NotImplementedException();
								}
								goto IL_004c;
							}
							goto IL_00a2;
							IL_004c:
							axisRange = axes[num].sourceAxisRange;
							int num2 = -1255458045;
							goto IL_000c;
							IL_0098:
							num2 = -1255458042;
							goto IL_000c;
							IL_00a2:
							num++;
							num2 = -1255458041;
							goto IL_000c;
							IL_000c:
							while (true)
							{
								switch (num2 ^ -1255458046)
								{
								case 2:
									num2 = -1255458047;
									continue;
								case 6:
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -1255458046;
									continue;
								case 4:
									break;
								case 3:
									goto IL_0062;
								case 7:
									goto IL_00a2;
								case 0:
									return true;
								case 1:
									goto IL_00c7;
								default:
									goto end_IL_0062;
								}
								break;
								IL_00c7:
								int num3;
								if (axes[num].invert)
								{
									num2 = -1255458044;
									num3 = num2;
								}
								else
								{
									num2 = -1255458046;
									num3 = num2;
								}
							}
							goto IL_004c;
							continue;
							end_IL_0062:
							break;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					Elements elements = default(Elements);
					while (true)
					{
						int num = 1131699354;
						while (true)
						{
							switch (num ^ 0x43745C99)
							{
							case 0:
								break;
							case 3:
								elements = destination as Elements;
								if (elements != null)
								{
									goto IL_003b;
								}
								return;
							case 1:
								goto IL_003b;
							default:
								elements.buttons = ArrayTools.DeepClone(buttons);
								return;
							}
							break;
							IL_003b:
							elements.axes = ArrayTools.DeepClone(axes);
							num = 1131699355;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class CustomCalculationSourceData : IDeepCloneable
			{
				public int sourceType;

				public int sourceElement;

				public AxisRange sourceAxisRange;

				public float deadzone;

				public bool invert;

				public object DeepClone()
				{
					CustomCalculationSourceData customCalculationSourceData = new CustomCalculationSourceData();
					customCalculationSourceData.sourceType = sourceType;
					customCalculationSourceData.sourceElement = sourceElement;
					customCalculationSourceData.sourceAxisRange = sourceAxisRange;
					customCalculationSourceData.deadzone = deadzone;
					customCalculationSourceData.invert = invert;
					return customCalculationSourceData;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Element : IDeepCloneable
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public UnityAxis sourceAxis;

				public float axisDeadZone;

				public UnityButton sourceButton;

				public KeyCode sourceKeyCode;

				public CustomCalculation customCalculation;

				public CustomCalculationSourceData[] customCalculationSourceData;

				public abstract object DeepClone();

				protected virtual void CopyVars(Element destination)
				{
					if (destination == null)
					{
						goto IL_0006;
					}
					goto IL_0091;
					IL_0006:
					int num = -1615959;
					goto IL_000b;
					IL_000b:
					while (true)
					{
						switch (num ^ -1615955)
						{
						case 3:
							break;
						default:
							return;
						case 1:
							destination.sourceButton = sourceButton;
							destination.sourceKeyCode = sourceKeyCode;
							destination.customCalculation = customCalculation;
							destination.customCalculationSourceData = ArrayTools.DeepClone(customCalculationSourceData);
							num = -1615960;
							continue;
						case 2:
							destination.sourceAxis = sourceAxis;
							destination.axisDeadZone = axisDeadZone;
							num = -1615956;
							continue;
						case 0:
							goto IL_0091;
						case 4:
							return;
						case 5:
							return;
						}
						break;
					}
					goto IL_0006;
					IL_0091:
					destination.elementIdentifier = elementIdentifier;
					destination.sourceType = sourceType;
					num = -1615953;
					goto IL_000b;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Button : Element
			{
				public Pole sourceAxisPole;

				public UnityAxis unityHat_sourceAxis1;

				public UnityAxis unityHat_sourceAxis2;

				public Vector2 unityHat_isActiveAxisValues1;

				public Vector2 unityHat_isActiveAxisValues2;

				public Vector2 unityHat_isActiveAxisValues3;

				public Vector2 unityHat_zeroValues;

				public bool unityHat_checkNeverPressed;

				public Vector2 unityHat_neverPressedZeroValues;

				public bool requireMultipleButtons;

				public UnityButton[] requiredButtons;

				public bool ignoreIfButtonsActive;

				public UnityButton[] ignoreIfButtonsActiveButtons;

				public HardwareButtonInfo buttonInfo;

				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				protected override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Button button = destination as Button;
					while (true)
					{
						int num = 18295559;
						while (true)
						{
							switch (num ^ 0x1172B04)
							{
							case 6:
								break;
							case 4:
								button.ignoreIfButtonsActive = ignoreIfButtonsActive;
								button.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons);
								num = 18295553;
								continue;
							case 0:
								button.unityHat_zeroValues = unityHat_zeroValues;
								button.unityHat_checkNeverPressed = unityHat_checkNeverPressed;
								button.unityHat_neverPressedZeroValues = unityHat_neverPressedZeroValues;
								button.requireMultipleButtons = requireMultipleButtons;
								num = 18295557;
								continue;
							case 2:
								button.unityHat_isActiveAxisValues3 = unityHat_isActiveAxisValues3;
								num = 18295556;
								continue;
							case 7:
								button.sourceAxisPole = sourceAxisPole;
								button.unityHat_sourceAxis1 = unityHat_sourceAxis1;
								button.unityHat_sourceAxis2 = unityHat_sourceAxis2;
								button.unityHat_isActiveAxisValues1 = unityHat_isActiveAxisValues1;
								button.unityHat_isActiveAxisValues2 = unityHat_isActiveAxisValues2;
								num = 18295558;
								continue;
							case 3:
								if (button == null)
								{
									return;
								}
								goto case 7;
							case 1:
								button.requiredButtons = ArrayTools.ShallowCopy(requiredButtons);
								num = 18295552;
								continue;
							default:
								button.buttonInfo = MiscTools.DeepClone(buttonInfo);
								return;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Axis : Element
			{
				public bool invert;

				public AxisRange sourceAxisRange;

				public Pole buttonAxisContribution;

				public bool calibrateAxis;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public AxisCalibrationInfoEntry[] alternateCalibrations;

				public HardwareAxisInfo axisInfo;

				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				protected override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Axis axis = destination as Axis;
					while (true)
					{
						int num = 1086263011;
						while (true)
						{
							switch (num ^ 0x40BF0EE0)
							{
							case 0:
								break;
							case 3:
								if (axis == null)
								{
									return;
								}
								goto case 4;
							case 1:
								axis.axisZero = axisZero;
								num = 1086263010;
								continue;
							case 4:
								axis.invert = invert;
								axis.sourceAxisRange = sourceAxisRange;
								axis.buttonAxisContribution = buttonAxisContribution;
								axis.calibrateAxis = calibrateAxis;
								num = 1086263009;
								continue;
							default:
								axis.axisMin = axisMin;
								axis.axisMax = axisMax;
								axis.axisInfo = MiscTools.DeepClone(axisInfo);
								axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
								return;
							}
							break;
						}
					}
				}
			}

			private sealed class jfGhBhfEXZXNxxicBOauIVsUsZV : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_Fallback_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int AxSOZdsuLDDxHbqlBsBOZgkHspG;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
					{
						goto IL_0012;
					}
					goto IL_004c;
					IL_0012:
					int num = -1481734229;
					goto IL_0017;
					IL_0017:
					jfGhBhfEXZXNxxicBOauIVsUsZV jfGhBhfEXZXNxxicBOauIVsUsZV2 = default(jfGhBhfEXZXNxxicBOauIVsUsZV);
					while (true)
					{
						switch (num ^ -1481734232)
						{
						case 4:
							break;
						case 1:
							num = -1481734230;
							continue;
						case 0:
							jfGhBhfEXZXNxxicBOauIVsUsZV2 = this;
							num = -1481734231;
							continue;
						case 5:
							goto IL_004c;
						case 3:
							if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
							{
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
								num = -1481734232;
								continue;
							}
							goto IL_004c;
						default:
							return jfGhBhfEXZXNxxicBOauIVsUsZV2;
						}
						break;
					}
					goto IL_0012;
					IL_004c:
					jfGhBhfEXZXNxxicBOauIVsUsZV2 = new jfGhBhfEXZXNxxicBOauIVsUsZV(0);
					jfGhBhfEXZXNxxicBOauIVsUsZV2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
					num = -1481734230;
					goto IL_0017;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
					while (true)
					{
						int num = 50318254;
						while (true)
						{
							switch (num ^ 0x2FFCBAF)
							{
							case 7:
								break;
							case 1:
								switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
								{
								default:
									num = 50318246;
									continue;
								case 1:
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
									AxSOZdsuLDDxHbqlBsBOZgkHspG++;
									num = 50318247;
									continue;
								case 0:
									break;
								}
								goto case 6;
							case 5:
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes != null)
								{
									AxSOZdsuLDDxHbqlBsBOZgkHspG = 0;
									num = 50318253;
									continue;
								}
								goto default;
							case 8:
							{
								int num3;
								if (AxSOZdsuLDDxHbqlBsBOZgkHspG < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes.Length)
								{
									num = 50318251;
									num3 = num;
								}
								else
								{
									num = 50318255;
									num3 = num;
								}
								continue;
							}
							case 4:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes[AxSOZdsuLDDxHbqlBsBOZgkHspG];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							case 6:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								num = 50318252;
								continue;
							case 2:
								num = 50318247;
								continue;
							case 3:
							{
								int num2;
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements != null)
								{
									num = 50318250;
									num2 = num;
								}
								else
								{
									num = 50318255;
									num2 = num;
								}
								continue;
							}
							case 9:
								num = 50318255;
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
				public jfGhBhfEXZXNxxicBOauIVsUsZV(int _003C_003E1__state)
				{
					while (true)
					{
						int num = 2119654815;
						while (true)
						{
							switch (num ^ 0x7E575D9E)
							{
							case 0:
								break;
							case 1:
								goto IL_0024;
							default:
								iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
								return;
							}
							break;
							IL_0024:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
							num = 2119654812;
						}
					}
				}
			}

			private sealed class stEAcIFdbmLilLijEqIOJDTMcCu : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_Fallback_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int WZeLtUrcUfHoeIjKEkFRYUDPgRP;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					stEAcIFdbmLilLijEqIOJDTMcCu stEAcIFdbmLilLijEqIOJDTMcCu2;
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						stEAcIFdbmLilLijEqIOJDTMcCu2 = this;
						goto IL_0025;
					}
					goto IL_004e;
					IL_002a:
					int num;
					while (true)
					{
						switch (num ^ -1456490051)
						{
						case 0:
							break;
						case 1:
							num = -1456490049;
							continue;
						case 3:
							goto IL_004e;
						default:
							return stEAcIFdbmLilLijEqIOJDTMcCu2;
						}
						break;
					}
					goto IL_0025;
					IL_004e:
					stEAcIFdbmLilLijEqIOJDTMcCu2 = new stEAcIFdbmLilLijEqIOJDTMcCu(0);
					stEAcIFdbmLilLijEqIOJDTMcCu2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
					num = -1456490049;
					goto IL_002a;
					IL_0025:
					num = -1456490052;
					goto IL_002a;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 1:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						WZeLtUrcUfHoeIjKEkFRYUDPgRP++;
						num = 774065932;
						goto IL_001f;
					case 0:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements == null)
							{
								break;
							}
							int num3;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons == null)
							{
								num = 774065934;
								num3 = num;
							}
							else
							{
								num = 774065933;
								num3 = num;
							}
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x2E234F08)
							{
							case 0:
								num = 774065930;
								continue;
							case 1:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							case 4:
								break;
							case 5:
								WZeLtUrcUfHoeIjKEkFRYUDPgRP = 0;
								num = 774065932;
								continue;
							case 2:
								goto end_IL_001f;
							case 3:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons[WZeLtUrcUfHoeIjKEkFRYUDPgRP];
								num = 774065929;
								continue;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (WZeLtUrcUfHoeIjKEkFRYUDPgRP < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons.Length)
							{
								num = 774065931;
								num2 = num;
							}
							else
							{
								num = 774065934;
								num2 = num;
							}
							continue;
							end_IL_001f:
							break;
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
				public stEAcIFdbmLilLijEqIOJDTMcCu(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public override int assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			public override int assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.lQJYCJKxUxlRFVSnejxjlgJeAjCe;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			internal override bool hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						goto IL_0017;
					}
					int num;
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						num = 1945455447;
						goto IL_001c;
					}
					return true;
					IL_0017:
					num = 1945455444;
					goto IL_001c;
					IL_001c:
					switch (num ^ 0x73F54B55)
					{
					case 0:
						break;
					case 1:
						return false;
					default:
						return false;
					}
					goto IL_0017;
				}
			}

			internal override bool disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			internal override bool isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal override Elements_Base elements_base
			{
				get
				{
					return elements;
				}
			}

			internal override IList<Platform> variants_base
			{
				get
				{
					return null;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				while (true)
				{
					int num = -1315226658;
					while (true)
					{
						switch (num ^ -1315226660)
						{
						case 0:
							break;
						case 2:
							platformMap = null;
							if (matchingCriteria != null)
							{
								goto IL_002d;
							}
							goto IL_0049;
						default:
							{
								if (matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
								{
									platformMap = this;
									return true;
								}
								goto IL_0049;
							}
							IL_0049:
							return false;
						}
						break;
						IL_002d:
						num = -1315226659;
					}
				}
			}

			internal IEnumerable<Axis> IterateAxes()
			{
				jfGhBhfEXZXNxxicBOauIVsUsZV jfGhBhfEXZXNxxicBOauIVsUsZV2 = new jfGhBhfEXZXNxxicBOauIVsUsZV(-2);
				jfGhBhfEXZXNxxicBOauIVsUsZV2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return jfGhBhfEXZXNxxicBOauIVsUsZV2;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				stEAcIFdbmLilLijEqIOJDTMcCu stEAcIFdbmLilLijEqIOJDTMcCu2 = new stEAcIFdbmLilLijEqIOJDTMcCu(-2);
				stEAcIFdbmLilLijEqIOJDTMcCu2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return stEAcIFdbmLilLijEqIOJDTMcCu2;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					goto IL_001d;
				}
				string[] array = new string[elements.axisCount];
				int num = 0;
				int num2 = 314617765;
				goto IL_0022;
				IL_0022:
				int num3 = default(int);
				while (true)
				{
					switch (num2 ^ 0x12C0AFA6)
					{
					case 0:
						break;
					case 8:
					{
						int num5;
						if (num3 >= identifiers.Length)
						{
							num2 = 314617763;
							num5 = num2;
						}
						else
						{
							num2 = 314617764;
							num5 = num2;
						}
						continue;
					}
					case 5:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = 314617761;
						continue;
					case 7:
						num2 = 314617760;
						continue;
					case 2:
						array[num] = identifiers[num3].name;
						num2 = 314617760;
						continue;
					case 1:
						return new string[0];
					case 4:
					{
						int elementIdentifier = elements.axes[num].elementIdentifier;
						num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						int num4;
						if (num3 >= 0)
						{
							num2 = 314617774;
							num4 = num2;
						}
						else
						{
							num2 = 314617763;
							num4 = num2;
						}
						continue;
					}
					case 6:
						num++;
						num2 = 314617765;
						continue;
					default:
						if (num >= array.Length)
						{
							return array;
						}
						goto case 4;
					}
					break;
				}
				goto IL_001d;
				IL_001d:
				num2 = 314617767;
				goto IL_0022;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				if (identifiers.Length < buttonCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[buttonCount];
				int num = 0;
				int num4 = default(int);
				while (true)
				{
					int num2;
					int num3;
					if (num >= array.Length)
					{
						num2 = -1350482906;
						num3 = num2;
					}
					else
					{
						num2 = -1350482912;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1350482910)
						{
						case 6:
							num2 = -1350482912;
							continue;
						case 0:
							break;
						case 3:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = -1350482909;
							continue;
						case 7:
						{
							int num6;
							if (num4 < identifiers.Length)
							{
								num2 = -1350482905;
								num6 = num2;
							}
							else
							{
								num2 = -1350482911;
								num6 = num2;
							}
							continue;
						}
						case 1:
							num++;
							num2 = -1350482910;
							continue;
						case 5:
							array[num] = identifiers[num4].name;
							num2 = -1350482909;
							continue;
						case 2:
						{
							int elementIdentifier = elements.buttons[num].elementIdentifier;
							num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							int num5;
							if (num4 >= 0)
							{
								num2 = -1350482907;
								num5 = num2;
							}
							else
							{
								num2 = -1350482911;
								num5 = num2;
							}
							continue;
						}
						default:
							return array;
						}
						break;
					}
				}
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				bool result = default(bool);
				using (IEnumerator<Axis> enumerator = IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Axis current = enumerator.Current;
							int num;
							int num2;
							if (current.elementIdentifier == elementIdentifierId)
							{
								num = 426293238;
								num2 = num;
							}
							else
							{
								num = 426293239;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ 0x1968B7F6)
								{
								case 2:
									num = 426293237;
									continue;
								case 3:
									break;
								case 0:
									result = true;
									goto IL_00f5;
								default:
									goto end_IL_0030;
								}
								break;
							}
							continue;
							end_IL_0030:
							break;
						}
					}
				}
				using (IEnumerator<Button> enumerator2 = IterateButtons().GetEnumerator())
				{
					while (true)
					{
						IL_00cb:
						int num3;
						int num4;
						if (!enumerator2.MoveNext())
						{
							num3 = 426293238;
							num4 = num3;
						}
						else
						{
							num3 = 426293236;
							num4 = num3;
						}
						while (true)
						{
							switch (num3 ^ 0x1968B7F6)
							{
							case 4:
								num3 = 426293236;
								continue;
							default:
								goto end_IL_0087;
							case 2:
							{
								Button current2 = enumerator2.Current;
								if (current2.elementIdentifier == elementIdentifierId)
								{
									result = true;
									num3 = 426293237;
									continue;
								}
								break;
							}
							case 1:
								break;
							case 0:
								goto end_IL_0087;
							case 3:
								goto IL_00f5;
							}
							goto IL_00cb;
							continue;
							end_IL_0087:
							break;
						}
						break;
					}
				}
				return false;
				IL_00f5:
				return result;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				using (IEnumerator<Button> enumerator = IterateButtons().GetEnumerator())
				{
					Button current = default(Button);
					while (true)
					{
						IL_0050:
						int num2;
						int num3;
						if (enumerator.MoveNext())
						{
							num2 = -552555498;
							num3 = num2;
						}
						else
						{
							num2 = -552555504;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -552555502)
							{
							case 3:
								num2 = -552555498;
								continue;
							default:
								goto end_IL_002f;
							case 0:
								break;
							case 1:
								buttons[num] = current.elementIdentifier;
								num++;
								num2 = -552555502;
								continue;
							case 4:
								current = enumerator.Current;
								num2 = -552555501;
								continue;
							case 2:
								goto end_IL_002f;
							}
							goto IL_0050;
							continue;
							end_IL_002f:
							break;
						}
						break;
					}
				}
				num = 0;
				using (IEnumerator<Axis> enumerator2 = IterateAxes().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Axis current2 = enumerator2.Current;
							axes[num] = current2.elementIdentifier;
							num++;
							int num4 = -552555501;
							while (true)
							{
								switch (num4 ^ -552555502)
								{
								case 0:
									num4 = -552555504;
									continue;
								case 2:
									break;
								default:
									goto end_IL_00c7;
								}
								break;
							}
							continue;
							end_IL_00c7:
							break;
						}
					}
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				AxisCalibrationData[] array = default(AxisCalibrationData[]);
				int num2 = default(int);
				while (true)
				{
					int num = 1271878666;
					while (true)
					{
						switch (num ^ 0x4BCF540E)
						{
						case 3:
							break;
						case 0:
							throw new NotImplementedException();
						case 9:
							array[num2] = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							num = 1271878662;
							continue;
						case 8:
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							if (Axes_orig[num2].calibrateAxis)
							{
								array[num2].zero = axes_orig[num2].axisZero;
								array[num2].min = axes_orig[num2].axisMin;
								array[num2].max = axes_orig[num2].axisMax;
								num = 1271878671;
								continue;
							}
							goto case 1;
						case 6:
							array[num2] = AxisCalibrationData.Default;
							num = 1271878671;
							continue;
						case 5:
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num3;
								if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Custom)
								{
									num = 1271878663;
									num3 = num;
								}
								else
								{
									num = 1271878668;
									num3 = num;
								}
								continue;
							}
							goto case 9;
						case 1:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num2++;
							num = 1271878665;
							continue;
						case 4:
							if (axes_orig == null)
							{
								return null;
							}
							array = new AxisCalibrationData[axes_orig.Length];
							num2 = 0;
							num = 1271878665;
							continue;
						case 2:
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num4;
								if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Hat)
								{
									num = 1271878670;
									num4 = num;
								}
								else
								{
									num = 1271878664;
									num4 = num;
								}
								continue;
							}
							goto case 6;
						default:
							if (num2 >= axes_orig.Length)
							{
								return array;
							}
							goto case 5;
						}
						break;
					}
				}
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					goto IL_0011;
				}
				goto IL_00dd;
				IL_0011:
				int num = 1354678701;
				goto IL_0016;
				IL_0016:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ 0x50BEC1A0)
					{
					case 3:
						break;
					case 9:
						if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
						{
							goto IL_0074;
						}
						goto case 14;
					case 8:
						axisInfos = new HardwareAxisInfo[Axes_orig.Length];
						num = 1354678690;
						continue;
					case 10:
						axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
						num = 1354678688;
						continue;
					case 5:
						num = 1354678700;
						continue;
					case 0:
						num = 1354678695;
						continue;
					case 11:
						goto IL_00dd;
					case 13:
						return;
					case 2:
						num2 = 0;
						num = 1354678693;
						continue;
					case 4:
						throw new Exception();
					case 1:
						if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Axis)
						{
							goto case 10;
						}
						goto IL_012d;
					case 14:
						axisRanges[num2] = AxisRange.Full;
						num = 1354678695;
						continue;
					case 7:
						num2++;
						num = 1354678700;
						continue;
					case 6:
						axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
						num = 1354678689;
						continue;
					default:
						if (num2 >= Axes_orig.Length)
						{
							return;
						}
						goto case 6;
					}
					break;
					IL_012d:
					int num3;
					if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Custom)
					{
						num = 1354678697;
						num3 = num;
					}
					else
					{
						num = 1354678698;
						num3 = num;
					}
					continue;
					IL_0074:
					int num4;
					if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Hat)
					{
						num = 1354678692;
						num4 = num;
					}
					else
					{
						num = 1354678702;
						num4 = num;
					}
				}
				goto IL_0011;
				IL_00dd:
				axisRanges = new AxisRange[Axes_orig.Length];
				num = 1354678696;
				goto IL_0016;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				int num2 = default(int);
				while (true)
				{
					int num = 999914346;
					while (true)
					{
						switch (num ^ 0x3B997B6B)
						{
						case 4:
							break;
						case 2:
							buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
							num2 = 0;
							num = 999914350;
							continue;
						case 3:
							return;
						case 1:
						{
							int num3;
							if (Buttons_orig == null)
							{
								num = 999914344;
								num3 = num;
							}
							else
							{
								num = 999914345;
								num3 = num;
							}
							continue;
						}
						case 0:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
							num2++;
							num = 999914350;
							continue;
						default:
							if (num2 >= Buttons_orig.Length)
							{
								return;
							}
							goto case 0;
						}
						break;
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_Fallback_Base platform_Fallback_Base = new Platform_Fallback_Base();
				CopyVars(platform_Fallback_Base);
				return platform_Fallback_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				Platform_Fallback_Base platform_Fallback_Base = destination as Platform_Fallback_Base;
				if (platform_Fallback_Base != null)
				{
					platform_Fallback_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_Fallback_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_Fallback : Platform_Fallback_Base
		{
			public Platform_Fallback_Base[] variants;

			internal override IList<Platform> variants_base
			{
				get
				{
					return variants;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					int num2 = default(int);
					while (true)
					{
						int num = -1631724888;
						while (true)
						{
							switch (num ^ -1631724882)
							{
							case 7:
								break;
							case 4:
								goto IL_004c;
							case 0:
								num = -1631724886;
								continue;
							case 2:
								return true;
							case 1:
								goto IL_007c;
							case 5:
								goto IL_009b;
							case 6:
								num2 = 0;
								num = -1631724882;
								continue;
							default:
								goto end_IL_001a;
							}
							break;
							IL_009b:
							if (variants[num2] != null)
							{
								num = -1631724881;
								continue;
							}
							goto IL_0071;
							IL_0071:
							num2++;
							num = -1631724886;
							continue;
							IL_007c:
							int variantIndex2;
							if (variants[num2].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
							{
								variantIndex = num2;
								num = -1631724884;
								continue;
							}
							goto IL_0071;
							IL_004c:
							int num3;
							if (num2 < variants.Length)
							{
								num = -1631724885;
								num3 = num;
							}
							else
							{
								num = -1631724883;
								num3 = num;
							}
						}
						continue;
						end_IL_001a:
						break;
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_Fallback platform_Fallback = new Platform_Fallback();
				CopyVars(platform_Fallback);
				return platform_Fallback;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_Fallback platform_Fallback = destination as Platform_Fallback;
				while (true)
				{
					int num = -5615449;
					while (true)
					{
						switch (num ^ -5615450)
						{
						case 3:
							break;
						default:
							return;
						case 1:
							if (platform_Fallback != null)
							{
								goto IL_003b;
							}
							return;
						case 2:
							goto IL_003b;
						case 0:
							return;
						}
						break;
						IL_003b:
						platform_Fallback.variants = MiscTools.DeepClone(variants);
						num = -5615450;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Platform_Custom : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class MatchingCriteria : MatchingCriteria_Base
			{
				public bool alwaysMatch;

				internal override bool hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (alwaysMatch)
						{
							return true;
						}
						return false;
					}
				}

				internal override bool isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						return true;
					}
				}

				internal override int alternateElementCount
				{
					get
					{
						return 0;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						goto IL_0018;
					}
					int num;
					if (disabled)
					{
						num = -1486854081;
					}
					else
					{
						if (isAllowed)
						{
							if (alwaysMatch)
							{
								return true;
							}
							return true;
						}
						num = -1486854083;
					}
					goto IL_001d;
					IL_0018:
					num = -1486854082;
					goto IL_001d;
					IL_001d:
					switch (num ^ -1486854081)
					{
					case 3:
						break;
					case 1:
						return true;
					case 0:
						return false;
					default:
						return false;
					}
					goto IL_0018;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched);
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					MatchingCriteria matchingCriteria = destination as MatchingCriteria;
					while (true)
					{
						int num = 1336790936;
						while (true)
						{
							switch (num ^ 0x4FADCF9A)
							{
							case 0:
								break;
							default:
								return;
							case 2:
								if (matchingCriteria != null)
								{
									goto IL_003b;
								}
								return;
							case 1:
								goto IL_003b;
							case 3:
								return;
							}
							break;
							IL_003b:
							matchingCriteria.alwaysMatch = alwaysMatch;
							num = 1336790937;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Elements : Elements_Base
			{
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class CustomCalculationSourceData : IDeepCloneable
			{
				public int sourceType;

				public int sourceAxis;

				public int sourceButton;

				public int sourceOtherAxis;

				public AxisRange sourceAxisRange;

				public float axisDeadZone;

				public bool invert;

				public AxisCalibrationType axisCalibrationType;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public object DeepClone()
				{
					CustomCalculationSourceData customCalculationSourceData = new CustomCalculationSourceData();
					customCalculationSourceData.sourceType = sourceType;
					customCalculationSourceData.sourceAxis = sourceAxis;
					customCalculationSourceData.sourceButton = sourceButton;
					customCalculationSourceData.sourceOtherAxis = sourceOtherAxis;
					customCalculationSourceData.sourceAxisRange = sourceAxisRange;
					customCalculationSourceData.axisDeadZone = axisDeadZone;
					customCalculationSourceData.invert = invert;
					customCalculationSourceData.axisCalibrationType = axisCalibrationType;
					customCalculationSourceData.axisZero = axisZero;
					customCalculationSourceData.axisMin = axisMin;
					customCalculationSourceData.axisMax = axisMax;
					return customCalculationSourceData;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Element : IDeepCloneable
			{
				public int elementIdentifier;

				public int sourceType;

				public int sourceAxis;

				public float axisDeadZone;

				public int sourceButton;

				public CustomCalculation customCalculation;

				public CustomCalculationSourceData[] customCalculationSourceData;

				internal virtual void CopyVars(Element destination)
				{
					destination.elementIdentifier = elementIdentifier;
					destination.sourceType = sourceType;
					destination.sourceAxis = sourceAxis;
					destination.axisDeadZone = axisDeadZone;
					destination.sourceButton = sourceButton;
					destination.customCalculation = customCalculation;
					destination.customCalculationSourceData = ArrayTools.DeepClone(customCalculationSourceData);
				}

				public abstract object DeepClone();
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Button : Element
			{
				public Pole sourceAxisPole;

				public bool requireMultipleButtons;

				public int[] requiredButtons;

				public bool ignoreIfButtonsActive;

				public int[] ignoreIfButtonsActiveButtons;

				public HardwareButtonInfo buttonInfo;

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Button button = destination as Button;
					if (button == null)
					{
						goto IL_0011;
					}
					goto IL_003b;
					IL_0011:
					int num = 874089190;
					goto IL_0016;
					IL_0016:
					switch (num ^ 0x34198AE5)
					{
					case 0:
						break;
					case 3:
						return;
					case 2:
						goto IL_003b;
					default:
						button.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons);
						button.buttonInfo = MiscTools.DeepClone(buttonInfo);
						return;
					}
					goto IL_0011;
					IL_003b:
					button.sourceAxisPole = sourceAxisPole;
					button.requireMultipleButtons = requireMultipleButtons;
					button.requiredButtons = ArrayTools.ShallowCopy(requiredButtons);
					button.ignoreIfButtonsActive = ignoreIfButtonsActive;
					num = 874089188;
					goto IL_0016;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Axis : Element
			{
				public bool invert;

				public AxisRange sourceAxisRange;

				public Pole buttonAxisContribution;

				public bool calibrateAxis;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public AxisCalibrationInfoEntry[] alternateCalibrations;

				public HardwareAxisInfo axisInfo;

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Axis axis = default(Axis);
					while (true)
					{
						int num = -574563820;
						while (true)
						{
							switch (num ^ -574563824)
							{
							case 3:
								break;
							case 0:
								axis.axisZero = axisZero;
								axis.axisMin = axisMin;
								axis.axisMax = axisMax;
								num = -574563823;
								continue;
							case 2:
								axis.invert = invert;
								axis.sourceAxisRange = sourceAxisRange;
								axis.buttonAxisContribution = buttonAxisContribution;
								axis.calibrateAxis = calibrateAxis;
								num = -574563824;
								continue;
							case 4:
								axis = destination as Axis;
								if (axis == null)
								{
									return;
								}
								goto case 2;
							default:
								axis.axisInfo = MiscTools.DeepClone(axisInfo);
								axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
								return;
							}
							break;
						}
					}
				}
			}

			internal abstract Axis[] Axes { get; }

			internal abstract Button[] Buttons { get; }

			internal abstract IEnumerable<Axis> IterateAxes();

			internal abstract IEnumerable<Button> IterateButtons();

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_Ouya_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				internal override bool hasData
				{
					get
					{
						if (base.hasData)
						{
							return true;
						}
						return false;
					}
				}

				internal override bool isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						if (disabled)
						{
							return false;
						}
						return true;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData)
					{
						goto IL_0010;
					}
					goto IL_003c;
					IL_003c:
					int num;
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						num = -1131103130;
					}
					else
					{
						if (alwaysMatch)
						{
							return true;
						}
						num = -1131103129;
					}
					goto IL_0015;
					IL_0010:
					num = -1131103131;
					goto IL_0015;
					IL_0015:
					switch (num ^ -1131103132)
					{
					case 0:
						break;
					case 1:
						goto IL_0032;
					case 2:
						return false;
					default:
						return false;
					}
					goto IL_0010;
					IL_0032:
					if (isAllowed)
					{
						return true;
					}
					goto IL_003c;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					while (true)
					{
						int num = 1188187169;
						while (true)
						{
							switch (num ^ 0x46D24C20)
							{
							case 2:
								break;
							case 1:
								goto IL_0024;
							default:
								return matchingCriteria;
							}
							break;
							IL_0024:
							CopyVars(matchingCriteria);
							num = 1188187168;
						}
					}
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					MatchingCriteria matchingCriteria = destination as MatchingCriteria;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				public override int axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					int num = 0;
					int num3 = default(int);
					while (true)
					{
						int num2 = -848924700;
						while (true)
						{
							switch (num2 ^ -848924704)
							{
							case 6:
								break;
							case 1:
								if (num >= axisCount)
								{
									num3 = 0;
									num2 = -848924699;
									continue;
								}
								goto case 3;
							case 3:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = -848924703;
								continue;
							case 4:
								num2 = -848924703;
								continue;
							case 5:
							{
								int num4;
								if (num3 >= buttonCount)
								{
									num2 = -848924704;
									num4 = num2;
								}
								else
								{
									num2 = -848924702;
									num4 = num2;
								}
								continue;
							}
							case 2:
								if (buttons[num3].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num3++;
								num2 = -848924699;
								continue;
							default:
								return elementIdentifier.elementType;
							}
							break;
						}
					}
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					int sourceType = default(int);
					while (num < axisCount)
					{
						while (true)
						{
							IL_00a1:
							int num2;
							if (axes[num].elementIdentifier == elementIdentifier.id)
							{
								sourceType = axes[num].sourceType;
								num2 = 1245379012;
								goto IL_000c;
							}
							goto IL_003c;
							IL_000c:
							while (true)
							{
								switch (num2 ^ 0x4A3AF9C7)
								{
								case 5:
									num2 = 1245379008;
									continue;
								case 6:
									break;
								case 2:
									goto IL_0047;
								case 0:
									goto IL_0075;
								case 3:
									goto IL_0089;
								case 7:
									goto IL_00a1;
								case 4:
									goto IL_00ce;
								default:
									goto end_IL_00a1;
								}
								break;
								IL_00ce:
								if (sourceType != 100)
								{
									throw new NotImplementedException();
								}
								num2 = 1245379013;
								continue;
								IL_0047:
								axisRange = axes[num].sourceAxisRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 1245379015;
									continue;
								}
								goto IL_0075;
								IL_0075:
								return true;
								IL_0089:
								switch (sourceType)
								{
								case 1:
									break;
								case 0:
									axisRange = AxisRange.Positive;
									return true;
								default:
									num2 = 1245379011;
									continue;
								}
								goto IL_0047;
							}
							goto IL_003c;
							IL_003c:
							num++;
							num2 = 1245379014;
							goto IL_000c;
							continue;
							end_IL_00a1:
							break;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					Elements elements = default(Elements);
					while (true)
					{
						int num = 165303258;
						while (true)
						{
							switch (num ^ 0x9DA53D9)
							{
							case 0:
								break;
							case 3:
								goto IL_0029;
							case 1:
								if (elements == null)
								{
									return;
								}
								goto default;
							default:
								elements.axes = ArrayTools.DeepClone(axes);
								elements.buttons = ArrayTools.DeepClone(buttons);
								return;
							}
							break;
							IL_0029:
							elements = destination as Elements;
							num = 165303256;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Button : Platform_Custom.Button
			{
				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					while (true)
					{
						int num = 1933566259;
						while (true)
						{
							switch (num ^ 0x733FE132)
							{
							case 0:
								break;
							default:
								return;
							case 1:
								goto IL_0025;
							case 2:
								return;
							}
							break;
							IL_0025:
							Button button = destination as Button;
							num = 1933566256;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					while (true)
					{
						int num = -372253500;
						while (true)
						{
							switch (num ^ -372253499)
							{
							case 0:
								break;
							default:
								return;
							case 1:
								goto IL_0025;
							case 2:
								return;
							}
							break;
							IL_0025:
							Axis axis = destination as Axis;
							num = -372253497;
						}
					}
				}
			}

			private sealed class LeMdTuBaLoPJIASnavyxtdzCcxrT : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_Ouya_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int eCMkEiHkFCkiQfcBtnOzxJNLHVN;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						goto IL_0023;
					}
					goto IL_0059;
					IL_0028:
					int num;
					LeMdTuBaLoPJIASnavyxtdzCcxrT leMdTuBaLoPJIASnavyxtdzCcxrT = default(LeMdTuBaLoPJIASnavyxtdzCcxrT);
					while (true)
					{
						switch (num ^ 0x52719D6B)
						{
						case 0:
							break;
						case 2:
							leMdTuBaLoPJIASnavyxtdzCcxrT = this;
							num = 1383177576;
							continue;
						case 3:
							num = 1383177578;
							continue;
						case 4:
							goto IL_0059;
						default:
							return leMdTuBaLoPJIASnavyxtdzCcxrT;
						}
						break;
					}
					goto IL_0023;
					IL_0059:
					leMdTuBaLoPJIASnavyxtdzCcxrT = new LeMdTuBaLoPJIASnavyxtdzCcxrT(0);
					leMdTuBaLoPJIASnavyxtdzCcxrT.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
					num = 1383177578;
					goto IL_0028;
					IL_0023:
					num = 1383177577;
					goto IL_0028;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 0:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements == null || ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes == null)
						{
							break;
						}
						eCMkEiHkFCkiQfcBtnOzxJNLHVN = 0;
						num = -707365572;
						goto IL_001f;
					case 1:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							eCMkEiHkFCkiQfcBtnOzxJNLHVN++;
							num = -707365573;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -707365574)
							{
							case 3:
								num = -707365569;
								continue;
							case 2:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes[eCMkEiHkFCkiQfcBtnOzxJNLHVN];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -707365574;
								continue;
							case 1:
								break;
							case 5:
								goto end_IL_001f;
							case 6:
								num = -707365573;
								continue;
							case 0:
								return true;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (eCMkEiHkFCkiQfcBtnOzxJNLHVN < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes.Length)
							{
								num = -707365576;
								num2 = num;
							}
							else
							{
								num = -707365570;
								num2 = num;
							}
							continue;
							end_IL_001f:
							break;
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
				public LeMdTuBaLoPJIASnavyxtdzCcxrT(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class yFHjgvHNpSmlZCECioCBaqkplvS : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_Ouya_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int BBrEZMtGKhciDqNocMMtuqfVRHe;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					yFHjgvHNpSmlZCECioCBaqkplvS yFHjgvHNpSmlZCECioCBaqkplvS2;
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						yFHjgvHNpSmlZCECioCBaqkplvS2 = this;
						goto IL_0025;
					}
					goto IL_004e;
					IL_002a:
					int num;
					while (true)
					{
						switch (num ^ 0x136ECF0F)
						{
						case 3:
							break;
						case 1:
							num = 326029069;
							continue;
						case 0:
							goto IL_004e;
						default:
							return yFHjgvHNpSmlZCECioCBaqkplvS2;
						}
						break;
					}
					goto IL_0025;
					IL_004e:
					yFHjgvHNpSmlZCECioCBaqkplvS2 = new yFHjgvHNpSmlZCECioCBaqkplvS(0);
					yFHjgvHNpSmlZCECioCBaqkplvS2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
					num = 326029069;
					goto IL_002a;
					IL_0025:
					num = 326029070;
					goto IL_002a;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 0:
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements == null)
						{
							break;
						}
						int num2;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons == null)
						{
							num = -1885836253;
							num2 = num;
						}
						else
						{
							num = -1885836254;
							num2 = num;
						}
						goto IL_001f;
					}
					case 1:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							BBrEZMtGKhciDqNocMMtuqfVRHe++;
							num = -1885836255;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -1885836255)
							{
							case 5:
								num = -1885836256;
								continue;
							case 0:
								break;
							case 3:
								BBrEZMtGKhciDqNocMMtuqfVRHe = 0;
								num = -1885836255;
								continue;
							case 1:
								goto end_IL_001f;
							case 4:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons[BBrEZMtGKhciDqNocMMtuqfVRHe];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							default:
								goto end_IL_0008;
							}
							int num3;
							if (BBrEZMtGKhciDqNocMMtuqfVRHe < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons.Length)
							{
								num = -1885836251;
								num3 = num;
							}
							else
							{
								num = -1885836253;
								num3 = num;
							}
							continue;
							end_IL_001f:
							break;
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
				public yFHjgvHNpSmlZCECioCBaqkplvS(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			public override int assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			public override int assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.gGGEnVSWvgaFbdVaVnlfMbOTkJsO;
				}
			}

			internal override Platform_Custom.Axis[] Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = default(Axis[]);
						int num2 = default(int);
						while (true)
						{
							int num = -1696200146;
							while (true)
							{
								switch (num ^ -1696200145)
								{
								case 0:
									break;
								case 2:
									goto IL_0032;
								case 3:
									num = -1696200147;
									continue;
								case 1:
									axes_orig = Axes_orig;
									if (axes_orig != null)
									{
										_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
										num2 = 0;
										num = -1696200148;
										continue;
									}
									goto end_IL_0008;
								case 4:
									_axesOrigGame[num2] = axes_orig[num2];
									num2++;
									num = -1696200147;
									continue;
								default:
									goto end_IL_0008;
								}
								break;
								IL_0032:
								int num3;
								if (num2 >= axes_orig.Length)
								{
									num = -1696200150;
									num3 = num;
								}
								else
								{
									num = -1696200149;
									num3 = num;
								}
							}
							continue;
							end_IL_0008:
							break;
						}
					}
					return _axesOrigGame;
				}
			}

			internal override Platform_Custom.Button[] Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							int num = 0;
							while (true)
							{
								int num2;
								int num3;
								if (num >= buttons_orig.Length)
								{
									num2 = -2047746223;
									num3 = num2;
								}
								else
								{
									num2 = -2047746220;
									num3 = num2;
								}
								while (true)
								{
									switch (num2 ^ -2047746219)
									{
									case 0:
										num2 = -2047746220;
										continue;
									case 1:
										_buttonsOrigGame[num] = buttons_orig[num];
										num2 = -2047746218;
										continue;
									case 3:
										num++;
										num2 = -2047746217;
										continue;
									case 2:
										break;
									default:
										goto end_IL_0067;
									}
									break;
								}
								continue;
								end_IL_0067:
								break;
							}
						}
					}
					return _buttonsOrigGame;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			internal override bool hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			internal override bool disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			internal override bool isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal override Elements_Base elements_base
			{
				get
				{
					return elements;
				}
			}

			internal override IList<Platform> variants_base
			{
				get
				{
					return null;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				while (true)
				{
					int num = 218164904;
					while (true)
					{
						switch (num ^ 0xD00EEAA)
						{
						case 0:
							break;
						case 2:
							platformMap = null;
							if (matchingCriteria != null)
							{
								goto IL_002d;
							}
							goto IL_0049;
						default:
							{
								if (matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
								{
									platformMap = this;
									return true;
								}
								goto IL_0049;
							}
							IL_0049:
							return false;
						}
						break;
						IL_002d:
						num = 218164907;
					}
				}
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				LeMdTuBaLoPJIASnavyxtdzCcxrT leMdTuBaLoPJIASnavyxtdzCcxrT = new LeMdTuBaLoPJIASnavyxtdzCcxrT(-2);
				leMdTuBaLoPJIASnavyxtdzCcxrT.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return leMdTuBaLoPJIASnavyxtdzCcxrT;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				yFHjgvHNpSmlZCECioCBaqkplvS yFHjgvHNpSmlZCECioCBaqkplvS2 = new yFHjgvHNpSmlZCECioCBaqkplvS(-2);
				yFHjgvHNpSmlZCECioCBaqkplvS2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return yFHjgvHNpSmlZCECioCBaqkplvS2;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				int num = 0;
				while (num < array.Length)
				{
					while (true)
					{
						IL_007f:
						int elementIdentifier = elements.axes[num].elementIdentifier;
						int num2 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						int num3;
						if (num2 >= 0)
						{
							int num4;
							if (num2 < identifiers.Length)
							{
								num3 = 1564035638;
								num4 = num3;
							}
							else
							{
								num3 = 1564035637;
								num4 = num3;
							}
							goto IL_003e;
						}
						goto IL_006e;
						IL_003e:
						while (true)
						{
							switch (num3 ^ 0x5D394A35)
							{
							case 4:
								num3 = 1564035636;
								continue;
							case 5:
								num3 = 1564035635;
								continue;
							case 0:
								break;
							case 1:
								goto IL_007f;
							case 3:
								array[num] = identifiers[num2].name;
								num3 = 1564035635;
								continue;
							case 6:
								num++;
								num3 = 1564035639;
								continue;
							default:
								goto end_IL_007f;
							}
							break;
						}
						goto IL_006e;
						IL_006e:
						Logger.LogError("Element identifier index is out of bounds!");
						num3 = 1564035632;
						goto IL_003e;
						continue;
						end_IL_007f:
						break;
					}
				}
				return array;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				int num2 = default(int);
				int num4 = default(int);
				string[] array = default(string[]);
				while (true)
				{
					int num = 412151765;
					while (true)
					{
						switch (num ^ 0x1890EFD3)
						{
						case 0:
							break;
						case 5:
							num2++;
							num = 412151761;
							continue;
						case 4:
						{
							int elementIdentifier = elements.buttons[num2].elementIdentifier;
							num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							if (num4 >= 0)
							{
								int num5;
								if (num4 >= identifiers.Length)
								{
									num = 412151771;
									num5 = num;
								}
								else
								{
									num = 412151762;
									num5 = num;
								}
								continue;
							}
							goto case 8;
						}
						case 7:
							return new string[0];
						case 6:
							if (identifiers.Length >= buttonCount)
							{
								array = new string[buttonCount];
								num2 = 0;
								num = 412151761;
							}
							else
							{
								Logger.LogError("You have too few element identifiers!");
								num = 412151764;
							}
							continue;
						case 8:
							Logger.LogError("Element identifier index is out of bounds!");
							num = 412151766;
							continue;
						case 1:
							array[num2] = identifiers[num4].name;
							num = 412151766;
							continue;
						case 2:
						{
							int num3;
							if (num2 >= array.Length)
							{
								num = 412151760;
								num3 = num;
							}
							else
							{
								num = 412151767;
								num3 = num;
							}
							continue;
						}
						default:
							return array;
						}
						break;
					}
				}
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				bool result = default(bool);
				using (IEnumerator<Platform_Custom.Axis> enumerator = IterateAxes().GetEnumerator())
				{
					Axis axis = default(Axis);
					while (true)
					{
						IL_006b:
						int num;
						int num2;
						if (enumerator.MoveNext())
						{
							num = 1031740539;
							num2 = num;
						}
						else
						{
							num = 1031740536;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x3D7F1C7A)
							{
							case 6:
								num = 1031740539;
								continue;
							default:
								goto end_IL_0013;
							case 5:
								result = true;
								num = 1031740542;
								continue;
							case 3:
							{
								int num3;
								if (axis.elementIdentifier != elementIdentifierId)
								{
									num = 1031740538;
									num3 = num;
								}
								else
								{
									num = 1031740543;
									num3 = num;
								}
								continue;
							}
							case 0:
								break;
							case 1:
								axis = (Axis)enumerator.Current;
								num = 1031740537;
								continue;
							case 2:
								goto end_IL_0013;
							case 4:
								goto IL_010d;
							}
							goto IL_006b;
							continue;
							end_IL_0013:
							break;
						}
						break;
					}
				}
				foreach (Button item in IterateButtons())
				{
					if (item.elementIdentifier != elementIdentifierId)
					{
						continue;
					}
					result = true;
					goto IL_010d;
				}
				return false;
				IL_010d:
				return result;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				using (IEnumerator<Platform_Custom.Button> enumerator = IterateButtons().GetEnumerator())
				{
					while (true)
					{
						IL_0050:
						int num2;
						int num3;
						if (!enumerator.MoveNext())
						{
							num2 = -810070329;
							num3 = num2;
						}
						else
						{
							num2 = -810070335;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -810070333)
							{
							case 0:
								num2 = -810070335;
								continue;
							default:
								goto end_IL_002f;
							case 3:
								break;
							case 1:
								num++;
								num2 = -810070336;
								continue;
							case 2:
							{
								Button button = (Button)enumerator.Current;
								buttons[num] = button.elementIdentifier;
								num2 = -810070334;
								continue;
							}
							case 4:
								goto end_IL_002f;
							}
							goto IL_0050;
							continue;
							end_IL_002f:
							break;
						}
						break;
					}
				}
				num = 0;
				using (IEnumerator<Platform_Custom.Axis> enumerator2 = IterateAxes().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator2.Current;
							axes[num] = axis.elementIdentifier;
							num++;
							int num4 = -810070334;
							while (true)
							{
								switch (num4 ^ -810070333)
								{
								case 0:
									num4 = -810070335;
									continue;
								case 2:
									break;
								default:
									goto end_IL_00cc;
								}
								break;
							}
							continue;
							end_IL_00cc:
							break;
						}
					}
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				AxisCalibrationData[] array = default(AxisCalibrationData[]);
				int num2 = default(int);
				while (true)
				{
					int num = -732498830;
					while (true)
					{
						switch (num ^ -732498826)
						{
						case 8:
							break;
						case 4:
							if (axes_orig == null)
							{
								return null;
							}
							array = new AxisCalibrationData[axes_orig.Length];
							num2 = 0;
							num = -732498817;
							continue;
						case 2:
							array[num2] = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							if (Axes_orig[num2].calibrateAxis)
							{
								array[num2].zero = axes_orig[num2].axisZero;
								array[num2].min = axes_orig[num2].axisMin;
								num = -732498831;
								continue;
							}
							goto case 6;
						case 5:
							throw new NotImplementedException();
						case 3:
						{
							int num4;
							if (axes_orig[num2].sourceType != 100)
							{
								num = -732498826;
								num4 = num;
							}
							else
							{
								num = -732498828;
								num4 = num;
							}
							continue;
						}
						case 1:
						{
							int num3;
							if (axes_orig[num2].sourceType == 1)
							{
								num = -732498828;
								num3 = num;
							}
							else
							{
								num = -732498827;
								num3 = num;
							}
							continue;
						}
						case 0:
							if (axes_orig[num2].sourceType == 0)
							{
								array[num2] = AxisCalibrationData.Default;
								num = -732498832;
								continue;
							}
							goto case 5;
						case 7:
							array[num2].max = axes_orig[num2].axisMax;
							num = -732498832;
							continue;
						case 6:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num2++;
							num = -732498817;
							continue;
						default:
							if (num2 >= axes_orig.Length)
							{
								return array;
							}
							goto case 1;
						}
						break;
					}
				}
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				int num2 = default(int);
				while (true)
				{
					int num = -1051558415;
					while (true)
					{
						switch (num ^ -1051558413)
						{
						case 5:
							break;
						default:
							return;
						case 2:
							axisInfos = null;
							if (Axes_orig == null)
							{
								return;
							}
							goto case 4;
						case 4:
							axisRanges = new AxisRange[Axes_orig.Length];
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = -1051558413;
							continue;
						case 1:
							throw new Exception();
						case 9:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							if (Axes_orig[num2].sourceType != 1)
							{
								int num4;
								if (Axes_orig[num2].sourceType != 100)
								{
									num = -1051558412;
									num4 = num;
								}
								else
								{
									num = -1051558411;
									num4 = num;
								}
								continue;
							}
							goto case 6;
						case 10:
							num2++;
							num = -1051558405;
							continue;
						case 6:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -1051558407;
							continue;
						case 8:
						{
							int num3;
							if (num2 < Axes_orig.Length)
							{
								num = -1051558406;
								num3 = num;
							}
							else
							{
								num = -1051558408;
								num3 = num;
							}
							continue;
						}
						case 7:
							if (Axes_orig[num2].sourceType == 0)
							{
								axisRanges[num2] = AxisRange.Full;
								num = -1051558416;
								continue;
							}
							goto case 1;
						case 3:
							num = -1051558407;
							continue;
						case 0:
							num = -1051558405;
							continue;
						case 11:
							return;
						}
						break;
					}
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig == null)
				{
					return;
				}
				while (true)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					int num = 0;
					int num2 = 1816614166;
					while (true)
					{
						switch (num2 ^ 0x6C475517)
						{
						case 3:
							num2 = 1816614163;
							continue;
						case 4:
							break;
						case 0:
							num++;
							num2 = 1816614166;
							continue;
						case 2:
							buttonInfos[num] = MiscTools.DeepClone(Buttons_orig[num].buttonInfo, true);
							num2 = 1816614167;
							continue;
						default:
							if (num >= Buttons_orig.Length)
							{
								return;
							}
							goto case 2;
						}
						break;
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_Ouya_Base platform_Ouya_Base = new Platform_Ouya_Base();
				CopyVars(platform_Ouya_Base);
				return platform_Ouya_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_Ouya_Base platform_Ouya_Base = destination as Platform_Ouya_Base;
				if (platform_Ouya_Base != null)
				{
					platform_Ouya_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_Ouya_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_Ouya : Platform_Ouya_Base
		{
			public Platform_Ouya_Base[] variants;

			internal override IList<Platform> variants_base
			{
				get
				{
					return variants;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					int num = 0;
					while (true)
					{
						int num2;
						int num3;
						if (num >= variants.Length)
						{
							num2 = 853340355;
							num3 = num2;
						}
						else
						{
							num2 = 853340354;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x32DCF0C3)
							{
							case 3:
								num2 = 853340354;
								continue;
							case 1:
								break;
							case 2:
								goto end_IL_0020;
							default:
								goto end_IL_006c;
							}
							int variantIndex2;
							if (variants[num] != null && variants[num].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
							{
								variantIndex = num;
								return true;
							}
							num++;
							num2 = 853340353;
							continue;
							end_IL_0020:
							break;
						}
						continue;
						end_IL_006c:
						break;
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_Ouya platform_Ouya = new Platform_Ouya();
				CopyVars(platform_Ouya);
				return platform_Ouya;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_Ouya platform_Ouya = destination as Platform_Ouya;
				if (platform_Ouya == null)
				{
					return;
				}
				while (true)
				{
					platform_Ouya.variants = MiscTools.DeepClone(variants);
					int num = -1603963117;
					while (true)
					{
						switch (num ^ -1603963119)
						{
						case 0:
							goto IL_0012;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_0012:
						num = -1603963120;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_XboxOne_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				internal override bool hasData
				{
					get
					{
						if (base.hasData)
						{
							return true;
						}
						if (productName != null && productName.Length > 0)
						{
							return true;
						}
						return false;
					}
				}

				internal override bool isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						if (disabled)
						{
							return false;
						}
						return true;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock)
					{
						goto IL_000b;
					}
					goto IL_0090;
					IL_000b:
					int num = 1013775279;
					goto IL_0010;
					IL_0010:
					int num2 = default(int);
					string text = default(string);
					while (true)
					{
						switch (num ^ 0x3C6CFBAB)
						{
						case 6:
							break;
						case 0:
							goto IL_0040;
						case 7:
							goto IL_005c;
						case 4:
							goto IL_0077;
						case 3:
							goto IL_0086;
						case 1:
							return false;
						case 5:
							goto IL_00ca;
						default:
							goto IL_00f2;
						}
						break;
						IL_00ca:
						string searchFor = productName[num2];
						if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
						{
							return true;
						}
						num2++;
						num = 1013775275;
						continue;
						IL_0040:
						int num3;
						if (num2 < productName.Length)
						{
							num = 1013775278;
							num3 = num;
						}
						else
						{
							num = 1013775273;
							num3 = num;
						}
						continue;
						IL_0077:
						if (hasData)
						{
							num = 1013775272;
							continue;
						}
						goto IL_0090;
						IL_0086:
						if (isAllowed)
						{
							return true;
						}
						goto IL_0090;
					}
					goto IL_000b;
					IL_005c:
					text = text.Trim();
					if (productName != null)
					{
						num2 = 0;
						num = 1013775275;
						goto IL_0010;
					}
					goto IL_00f2;
					IL_00f2:
					return false;
					IL_0090:
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						num = 1013775274;
					}
					else
					{
						if (alwaysMatch)
						{
							return true;
						}
						text = bridgedControllerHWInfo.hw_productName;
						if (text != null)
						{
							goto IL_005c;
						}
						text = string.Empty;
						num = 1013775276;
					}
					goto IL_0010;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					MatchingCriteria matchingCriteria = default(MatchingCriteria);
					while (true)
					{
						int num = 1855326673;
						while (true)
						{
							switch (num ^ 0x6E9609D3)
							{
							case 0:
								break;
							case 3:
								matchingCriteria.productName_useRegex = productName_useRegex;
								num = 1855326674;
								continue;
							case 4:
								if (matchingCriteria == null)
								{
									return;
								}
								goto case 3;
							case 2:
								matchingCriteria = destination as MatchingCriteria;
								num = 1855326679;
								continue;
							default:
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								return;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				public override int axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					int num = 0;
					int num3 = default(int);
					while (true)
					{
						int num2 = 1758387125;
						while (true)
						{
							switch (num2 ^ 0x68CEDBB3)
							{
							case 4:
								break;
							case 6:
								num2 = 1758387126;
								continue;
							case 0:
								num2 = 1758387122;
								continue;
							case 5:
								if (num >= axisCount)
								{
									num3 = 0;
									num2 = 1758387123;
									continue;
								}
								goto case 2;
							case 2:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = 1758387126;
								continue;
							case 3:
								if (buttons[num3].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num3++;
								num2 = 1758387122;
								continue;
							default:
								if (num3 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								goto case 3;
							}
							break;
						}
					}
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					while (true)
					{
						int num2 = -2139117533;
						while (true)
						{
							switch (num2 ^ -2139117525)
							{
							case 0:
								break;
							case 7:
								return true;
							case 3:
							{
								int num3;
								if (axes[num].invert)
								{
									num2 = -2139117523;
									num3 = num2;
								}
								else
								{
									num2 = -2139117524;
									num3 = num2;
								}
								continue;
							}
							case 1:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									switch (axes[num].sourceType)
									{
									case 0:
										axisRange = AxisRange.Positive;
										return true;
									default:
										throw new NotImplementedException();
									case 100:
										num2 = -2139117521;
										continue;
									case 1:
										break;
									}
									goto case 4;
								}
								goto case 2;
							case 4:
								axisRange = axes[num].sourceAxisRange;
								num2 = -2139117528;
								continue;
							case 6:
								axisRange = InputTools.InvertAxisRange(axisRange);
								num2 = -2139117524;
								continue;
							case 8:
								num2 = -2139117522;
								continue;
							case 2:
								num++;
								num2 = -2139117522;
								continue;
							default:
								if (num >= axisCount)
								{
									axisRange = AxisRange.Full;
									return false;
								}
								goto case 1;
							}
							break;
						}
					}
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					Elements elements = destination as Elements;
					while (true)
					{
						switch (-1486598043 ^ -1486598044)
						{
						case 0:
							continue;
						case 1:
							if (elements == null)
							{
								return;
							}
							break;
						}
						break;
					}
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Button : Platform_Custom.Button
			{
				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					while (true)
					{
						int num = -2052175840;
						while (true)
						{
							switch (num ^ -2052175839)
							{
							case 2:
								break;
							default:
								return;
							case 1:
								goto IL_0025;
							case 0:
								return;
							}
							break;
							IL_0025:
							Button button = destination as Button;
							num = -2052175839;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Axis axis = destination as Axis;
				}
			}

			private sealed class kPtVWAYRUGIPGJisEoKcnKaZbVm : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_XboxOne_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int qfXdwbUgHaUCJEwqCboHxXusjxH;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						goto IL_001c;
					}
					goto IL_0059;
					IL_0059:
					kPtVWAYRUGIPGJisEoKcnKaZbVm kPtVWAYRUGIPGJisEoKcnKaZbVm2 = new kPtVWAYRUGIPGJisEoKcnKaZbVm(0);
					kPtVWAYRUGIPGJisEoKcnKaZbVm2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
					int num = -1685519947;
					goto IL_0021;
					IL_001c:
					num = -1685519945;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ -1685519948)
						{
						case 0:
							break;
						case 3:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							kPtVWAYRUGIPGJisEoKcnKaZbVm2 = this;
							num = -1685519952;
							continue;
						case 4:
							num = -1685519947;
							continue;
						case 2:
							goto IL_0059;
						default:
							return kPtVWAYRUGIPGJisEoKcnKaZbVm2;
						}
						break;
					}
					goto IL_001c;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					default:
						num = 1078736158;
						goto IL_001a;
					case 1:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = 1078736159;
						goto IL_001a;
					case 0:
						goto IL_0065;
						IL_001a:
						while (true)
						{
							switch (num ^ 0x404C351A)
							{
							case 0:
								break;
							case 4:
								num = 1078736146;
								continue;
							case 6:
								return true;
							case 2:
								goto IL_0065;
							case 3:
								goto IL_00a2;
							case 7:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes[qfXdwbUgHaUCJEwqCboHxXusjxH];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 1078736156;
								continue;
							case 1:
								num = 1078736153;
								continue;
							case 5:
								qfXdwbUgHaUCJEwqCboHxXusjxH++;
								num = 1078736153;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00a2:
							int num2;
							if (qfXdwbUgHaUCJEwqCboHxXusjxH < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes.Length)
							{
								num = 1078736157;
								num2 = num;
							}
							else
							{
								num = 1078736146;
								num2 = num;
							}
						}
						goto default;
						IL_0065:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements == null || ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes == null)
						{
							break;
						}
						qfXdwbUgHaUCJEwqCboHxXusjxH = 0;
						num = 1078736155;
						goto IL_001a;
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
				public kPtVWAYRUGIPGJisEoKcnKaZbVm(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class olskDkwGZAhVPCPFWqNFuQzwuEAf : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_XboxOne_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int VHHsQqhoaPNKVeEAfVmfaAtyJeE;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
					{
						goto IL_0012;
					}
					goto IL_003c;
					IL_0012:
					int num = -79450101;
					goto IL_0017;
					IL_0017:
					olskDkwGZAhVPCPFWqNFuQzwuEAf olskDkwGZAhVPCPFWqNFuQzwuEAf2 = default(olskDkwGZAhVPCPFWqNFuQzwuEAf);
					while (true)
					{
						switch (num ^ -79450102)
						{
						case 3:
							break;
						case 2:
							goto IL_003c;
						case 4:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							olskDkwGZAhVPCPFWqNFuQzwuEAf2 = this;
							num = -79450102;
							continue;
						case 5:
							olskDkwGZAhVPCPFWqNFuQzwuEAf2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
							num = -79450102;
							continue;
						case 1:
							goto IL_006d;
						default:
							return olskDkwGZAhVPCPFWqNFuQzwuEAf2;
						}
						break;
						IL_006d:
						int num2;
						if (LzqgRXjFXvJPbHjfzyAmNfcqezXL != -2)
						{
							num = -79450104;
							num2 = num;
						}
						else
						{
							num = -79450098;
							num2 = num;
						}
					}
					goto IL_0012;
					IL_003c:
					olskDkwGZAhVPCPFWqNFuQzwuEAf2 = new olskDkwGZAhVPCPFWqNFuQzwuEAf(0);
					num = -79450097;
					goto IL_0017;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
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
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements == null)
						{
							num = 475116242;
							num2 = num;
						}
						else
						{
							num = 475116241;
							num2 = num;
						}
						goto IL_001f;
					}
					case 1:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							num = 475116246;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x1C51B2D4)
							{
							case 7:
								num = 475116247;
								continue;
							case 3:
								break;
							case 4:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons[VHHsQqhoaPNKVeEAfVmfaAtyJeE];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 475116245;
								continue;
							case 1:
								return true;
							case 0:
								goto IL_00b2;
							case 5:
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons != null)
								{
									VHHsQqhoaPNKVeEAfVmfaAtyJeE = 0;
									num = 475116244;
									continue;
								}
								goto end_IL_0008;
							case 2:
								VHHsQqhoaPNKVeEAfVmfaAtyJeE++;
								num = 475116244;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00b2:
							int num3;
							if (VHHsQqhoaPNKVeEAfVmfaAtyJeE >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons.Length)
							{
								num = 475116242;
								num3 = num;
							}
							else
							{
								num = 475116240;
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
				public olskDkwGZAhVPCPFWqNFuQzwuEAf(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			public override int assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			public override int assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.pZrRySJpwHiBEaxxGokWuXWJhUS;
				}
			}

			internal override Platform_Custom.Axis[] Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							int num = 0;
							while (true)
							{
								int num2;
								int num3;
								if (num >= axes_orig.Length)
								{
									num2 = 1687227230;
									num3 = num2;
								}
								else
								{
									num2 = 1687227231;
									num3 = num2;
								}
								while (true)
								{
									switch (num2 ^ 0x64910B5C)
									{
									case 0:
										num2 = 1687227231;
										continue;
									case 3:
										_axesOrigGame[num] = axes_orig[num];
										num++;
										num2 = 1687227229;
										continue;
									case 1:
										break;
									default:
										goto end_IL_005c;
									}
									break;
								}
								continue;
								end_IL_005c:
								break;
							}
						}
					}
					return _axesOrigGame;
				}
			}

			internal override Platform_Custom.Button[] Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						int num2 = default(int);
						Button[] buttons_orig = default(Button[]);
						while (true)
						{
							int num = -1909907019;
							while (true)
							{
								switch (num ^ -1909907021)
								{
								case 4:
									break;
								case 3:
									_buttonsOrigGame[num2] = buttons_orig[num2];
									num2++;
									num = -1909907018;
									continue;
								case 1:
									_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
									num = -1909907021;
									continue;
								case 0:
									num2 = 0;
									num = -1909907018;
									continue;
								case 6:
									goto IL_006d;
								case 5:
									goto IL_0088;
								default:
									goto end_IL_000b;
								}
								break;
								IL_0088:
								int num3;
								if (num2 < buttons_orig.Length)
								{
									num = -1909907024;
									num3 = num;
								}
								else
								{
									num = -1909907023;
									num3 = num;
								}
								continue;
								IL_006d:
								buttons_orig = Buttons_orig;
								int num4;
								if (buttons_orig != null)
								{
									num = -1909907022;
									num4 = num;
								}
								else
								{
									num = -1909907023;
									num4 = num;
								}
							}
							continue;
							end_IL_000b:
							break;
						}
					}
					return _buttonsOrigGame;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			internal override bool hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			internal override bool disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			internal override bool isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal override Elements_Base elements_base
			{
				get
				{
					return elements;
				}
			}

			internal override IList<Platform> variants_base
			{
				get
				{
					return null;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				kPtVWAYRUGIPGJisEoKcnKaZbVm kPtVWAYRUGIPGJisEoKcnKaZbVm2 = new kPtVWAYRUGIPGJisEoKcnKaZbVm(-2);
				kPtVWAYRUGIPGJisEoKcnKaZbVm2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return kPtVWAYRUGIPGJisEoKcnKaZbVm2;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				olskDkwGZAhVPCPFWqNFuQzwuEAf olskDkwGZAhVPCPFWqNFuQzwuEAf2 = new olskDkwGZAhVPCPFWqNFuQzwuEAf(-2);
				olskDkwGZAhVPCPFWqNFuQzwuEAf2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return olskDkwGZAhVPCPFWqNFuQzwuEAf2;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				int num = 0;
				int num3 = default(int);
				while (true)
				{
					int num2 = -153628049;
					while (true)
					{
						switch (num2 ^ -153628055)
						{
						case 3:
							break;
						case 6:
							num2 = -153628052;
							continue;
						case 4:
							array[num] = identifiers[num3].name;
							num2 = -153628053;
							continue;
						case 1:
						{
							int elementIdentifier = elements.axes[num].elementIdentifier;
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num2 = -153628050;
							continue;
						}
						case 7:
							if (num3 >= 0)
							{
								int num4;
								if (num3 >= identifiers.Length)
								{
									num2 = -153628055;
									num4 = num2;
								}
								else
								{
									num2 = -153628051;
									num4 = num2;
								}
								continue;
							}
							goto case 0;
						case 2:
							num++;
							num2 = -153628052;
							continue;
						case 0:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = -153628053;
							continue;
						default:
							if (num >= array.Length)
							{
								return array;
							}
							goto case 1;
						}
						break;
					}
				}
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				if (identifiers.Length < buttonCount)
				{
					goto IL_0012;
				}
				string[] array = new string[buttonCount];
				int num = 0;
				int num2 = -726065210;
				goto IL_0017;
				IL_0017:
				int num3 = default(int);
				while (true)
				{
					switch (num2 ^ -726065201)
					{
					case 8:
						break;
					case 3:
						Logger.LogError("You have too few element identifiers!");
						return new string[0];
					case 2:
						array[num] = identifiers[num3].name;
						num2 = -726065205;
						continue;
					case 7:
					{
						int elementIdentifier = elements.buttons[num].elementIdentifier;
						num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						int num5;
						if (num3 < 0)
						{
							num2 = -726065206;
							num5 = num2;
						}
						else
						{
							num2 = -726065207;
							num5 = num2;
						}
						continue;
					}
					case 1:
					{
						int num6;
						if (num < array.Length)
						{
							num2 = -726065208;
							num6 = num2;
						}
						else
						{
							num2 = -726065211;
							num6 = num2;
						}
						continue;
					}
					case 4:
						num++;
						num2 = -726065202;
						continue;
					case 6:
					{
						int num4;
						if (num3 < identifiers.Length)
						{
							num2 = -726065203;
							num4 = num2;
						}
						else
						{
							num2 = -726065206;
							num4 = num2;
						}
						continue;
					}
					case 9:
						num2 = -726065202;
						continue;
					case 5:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = -726065201;
						continue;
					case 0:
						num2 = -726065205;
						continue;
					default:
						return array;
					}
					break;
				}
				goto IL_0012;
				IL_0012:
				num2 = -726065204;
				goto IL_0017;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				bool result = default(bool);
				using (IEnumerator<Platform_Custom.Axis> enumerator = IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator.Current;
							int num = 1316786443;
							while (true)
							{
								switch (num ^ 0x4E7C9108)
								{
								case 0:
									num = 1316786441;
									continue;
								case 1:
									break;
								case 3:
									if (axis.elementIdentifier != elementIdentifierId)
									{
										goto end_IL_0030;
									}
									result = true;
									goto IL_012f;
								default:
									goto end_IL_0030;
								}
								break;
							}
							continue;
							end_IL_0030:
							break;
						}
					}
				}
				IEnumerator<Platform_Custom.Button> enumerator2 = IterateButtons().GetEnumerator();
				try
				{
					while (true)
					{
						IL_00a7:
						int num2;
						int num3;
						if (!enumerator2.MoveNext())
						{
							num2 = 1316786440;
							num3 = num2;
						}
						else
						{
							num2 = 1316786441;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x4E7C9108)
							{
							case 2:
								num2 = 1316786441;
								continue;
							default:
								goto end_IL_0082;
							case 3:
								break;
							case 5:
								result = true;
								num2 = 1316786444;
								continue;
							case 1:
							{
								Button button = (Button)enumerator2.Current;
								int num4;
								if (button.elementIdentifier == elementIdentifierId)
								{
									num2 = 1316786445;
									num4 = num2;
								}
								else
								{
									num2 = 1316786443;
									num4 = num2;
								}
								continue;
							}
							case 0:
								goto end_IL_0082;
							case 4:
								goto IL_012f;
							}
							goto IL_00a7;
							continue;
							end_IL_0082:
							break;
						}
						break;
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						while (true)
						{
							IL_0100:
							int num5 = 1316786441;
							while (true)
							{
								switch (num5 ^ 0x4E7C9108)
								{
								case 0:
									break;
								default:
									goto end_IL_0105;
								case 1:
									goto IL_011e;
								case 2:
									goto end_IL_0105;
								}
								goto IL_0100;
								IL_011e:
								enumerator2.Dispose();
								num5 = 1316786442;
								continue;
								end_IL_0105:
								break;
							}
							break;
						}
					}
				}
				return false;
				IL_012f:
				return result;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				using (IEnumerator<Platform_Custom.Button> enumerator = IterateButtons().GetEnumerator())
				{
					while (true)
					{
						IL_006d:
						int num2;
						int num3;
						if (enumerator.MoveNext())
						{
							num2 = 245780502;
							num3 = num2;
						}
						else
						{
							num2 = 245780501;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0xEA65014)
							{
							case 0:
								num2 = 245780502;
								continue;
							default:
								goto end_IL_002f;
							case 2:
							{
								Button button = (Button)enumerator.Current;
								buttons[num] = button.elementIdentifier;
								num++;
								num2 = 245780503;
								continue;
							}
							case 3:
								break;
							case 1:
								goto end_IL_002f;
							}
							goto IL_006d;
							continue;
							end_IL_002f:
							break;
						}
						break;
					}
				}
				num = 0;
				IEnumerator<Platform_Custom.Axis> enumerator2 = IterateAxes().GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator2.Current;
							axes[num] = axis.elementIdentifier;
							num++;
							int num4 = 245780502;
							while (true)
							{
								switch (num4 ^ 0xEA65014)
								{
								case 0:
									num4 = 245780501;
									continue;
								case 1:
									break;
								default:
									goto end_IL_00c1;
								}
								break;
							}
							continue;
							end_IL_00c1:
							break;
						}
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						while (true)
						{
							IL_00f2:
							int num5 = 245780501;
							while (true)
							{
								switch (num5 ^ 0xEA65014)
								{
								case 2:
									break;
								default:
									goto end_IL_00f7;
								case 1:
									goto IL_0110;
								case 0:
									goto end_IL_00f7;
								}
								goto IL_00f2;
								IL_0110:
								enumerator2.Dispose();
								num5 = 245780500;
								continue;
								end_IL_00f7:
								break;
							}
							break;
						}
					}
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				int num2 = default(int);
				AxisCalibrationData[] array = default(AxisCalibrationData[]);
				while (true)
				{
					int num = 778507761;
					while (true)
					{
						switch (num ^ 0x2E6715F0)
						{
						case 6:
							break;
						case 2:
						{
							int num5;
							if (axes_orig[num2].sourceType == 100)
							{
								num = 778507772;
								num5 = num;
							}
							else
							{
								num = 778507744;
								num5 = num;
							}
							continue;
						}
						case 7:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num = 778507771;
							continue;
						case 12:
							array[num2] = AxisCalibrationData.Default;
							num = 778507773;
							continue;
						case 4:
							array[num2] = AxisCalibrationData.Default;
							num = 778507767;
							continue;
						case 16:
						{
							int num3;
							if (axes_orig[num2].sourceType == 0)
							{
								num = 778507764;
								num3 = num;
							}
							else
							{
								num = 778507775;
								num3 = num;
							}
							continue;
						}
						case 15:
							throw new NotImplementedException();
						case 5:
							array[num2].max = axes_orig[num2].axisMax;
							num = 778507767;
							continue;
						case 14:
						{
							int num6;
							if (axes_orig[num2].sourceType != 1)
							{
								num = 778507762;
								num6 = num;
							}
							else
							{
								num = 778507772;
								num6 = num;
							}
							continue;
						}
						case 3:
							num2 = 0;
							num = 778507769;
							continue;
						case 0:
						{
							int num4;
							if (!Axes_orig[num2].calibrateAxis)
							{
								num = 778507767;
								num4 = num;
							}
							else
							{
								num = 778507770;
								num4 = num;
							}
							continue;
						}
						case 11:
							num2++;
							num = 778507768;
							continue;
						case 1:
							if (axes_orig == null)
							{
								return null;
							}
							array = new AxisCalibrationData[axes_orig.Length];
							num = 778507763;
							continue;
						case 10:
							array[num2].zero = axes_orig[num2].axisZero;
							array[num2].min = axes_orig[num2].axisMin;
							num = 778507765;
							continue;
						case 9:
							num = 778507768;
							continue;
						case 13:
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							num = 778507760;
							continue;
						default:
							if (num2 >= axes_orig.Length)
							{
								return array;
							}
							goto case 14;
						}
						break;
					}
				}
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				int num2 = default(int);
				while (true)
				{
					axisRanges = new AxisRange[Axes_orig.Length];
					int num = 2119989123;
					while (true)
					{
						switch (num ^ 0x7E5C7785)
						{
						case 10:
							num = 2119989126;
							continue;
						case 4:
							throw new Exception();
						case 13:
						{
							int num4;
							if (Axes_orig[num2].sourceType == 1)
							{
								num = 2119989134;
								num4 = num;
							}
							else
							{
								num = 2119989125;
								num4 = num;
							}
							continue;
						}
						case 1:
							num2++;
							num = 2119989133;
							continue;
						case 12:
							num = 2119989124;
							continue;
						case 11:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = 2119989129;
							continue;
						case 7:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							num = 2119989128;
							continue;
						case 5:
							num = 2119989124;
							continue;
						case 3:
							break;
						case 2:
						{
							int num5;
							if (Axes_orig[num2].sourceType == 0)
							{
								num = 2119989132;
								num5 = num;
							}
							else
							{
								num = 2119989121;
								num5 = num;
							}
							continue;
						}
						case 6:
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = 2119989133;
							continue;
						case 0:
						{
							int num3;
							if (Axes_orig[num2].sourceType == 100)
							{
								num = 2119989134;
								num3 = num;
							}
							else
							{
								num = 2119989127;
								num3 = num;
							}
							continue;
						}
						case 9:
							axisRanges[num2] = AxisRange.Full;
							num = 2119989120;
							continue;
						default:
							if (num2 >= Axes_orig.Length)
							{
								return;
							}
							goto case 7;
						}
						break;
					}
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig == null)
				{
					return;
				}
				int num2 = default(int);
				while (true)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					int num = -285306764;
					while (true)
					{
						switch (num ^ -285306764)
						{
						case 4:
							num = -285306763;
							continue;
						default:
							return;
						case 1:
							break;
						case 0:
							num2 = 0;
							num = -285306762;
							continue;
						case 2:
						{
							int num3;
							if (num2 >= Buttons_orig.Length)
							{
								num = -285306767;
								num3 = num;
							}
							else
							{
								num = -285306761;
								num3 = num;
							}
							continue;
						}
						case 3:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
							num2++;
							num = -285306762;
							continue;
						case 5:
							return;
						}
						break;
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_XboxOne_Base platform_XboxOne_Base = new Platform_XboxOne_Base();
				CopyVars(platform_XboxOne_Base);
				return platform_XboxOne_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_XboxOne_Base platform_XboxOne_Base = destination as Platform_XboxOne_Base;
				if (platform_XboxOne_Base == null)
				{
					while (true)
					{
						switch (0x375BACC7 ^ 0x375BACC5)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				platform_XboxOne_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				platform_XboxOne_Base.elements = MiscTools.DeepClone(elements);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_XboxOne : Platform_XboxOne_Base
		{
			public Platform_XboxOne_Base[] variants;

			internal override IList<Platform> variants_base
			{
				get
				{
					return variants;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					int num2 = default(int);
					while (true)
					{
						int num = 1268941762;
						while (true)
						{
							switch (num ^ 0x4BA283C6)
							{
							case 3:
								break;
							case 0:
								goto IL_003d;
							case 1:
								goto IL_0059;
							case 4:
								num2 = 0;
								num = 1268941766;
								continue;
							default:
								goto end_IL_0017;
							}
							break;
							IL_0059:
							int variantIndex2;
							if (variants[num2] != null && variants[num2].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
							{
								variantIndex = num2;
								return true;
							}
							num2++;
							num = 1268941766;
							continue;
							IL_003d:
							int num3;
							if (num2 >= variants.Length)
							{
								num = 1268941764;
								num3 = num;
							}
							else
							{
								num = 1268941767;
								num3 = num;
							}
						}
						continue;
						end_IL_0017:
						break;
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_XboxOne platform_XboxOne = new Platform_XboxOne();
				CopyVars(platform_XboxOne);
				return platform_XboxOne;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_XboxOne platform_XboxOne = destination as Platform_XboxOne;
				while (true)
				{
					int num = 418298172;
					while (true)
					{
						switch (num ^ 0x18EEB93D)
						{
						case 3:
							break;
						case 1:
						{
							int num2;
							if (platform_XboxOne == null)
							{
								num = 418298175;
								num2 = num;
							}
							else
							{
								num = 418298173;
								num2 = num;
							}
							continue;
						}
						case 2:
							return;
						default:
							platform_XboxOne.variants = MiscTools.DeepClone(variants);
							return;
						}
						break;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_PS4_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				internal override bool hasData
				{
					get
					{
						if (base.hasData)
						{
							return true;
						}
						if (productName != null && productName.Length > 0)
						{
							return true;
						}
						return false;
					}
				}

				internal override bool isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						if (disabled)
						{
							return false;
						}
						return true;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData)
					{
						goto IL_0016;
					}
					goto IL_00fa;
					IL_00b5:
					string text = text.Trim();
					int num = -2130390454;
					goto IL_001b;
					IL_0016:
					num = -2130390458;
					goto IL_001b;
					IL_001b:
					int num2 = default(int);
					while (true)
					{
						switch (num ^ -2130390452)
						{
						case 2:
							break;
						case 10:
							goto IL_0057;
						case 0:
							return true;
						case 7:
							goto IL_0082;
						case 6:
							if (productName != null)
							{
								num2 = 0;
								num = -2130390453;
								continue;
							}
							goto default;
						case 8:
							goto IL_00b5;
						case 9:
							goto IL_00c6;
						case 4:
							return true;
						case 5:
							return true;
						case 1:
							return false;
						default:
							return false;
						}
						break;
						IL_00c6:
						string searchFor = productName[num2];
						if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
						{
							num = -2130390456;
							continue;
						}
						num2++;
						num = -2130390453;
						continue;
						IL_0082:
						int num3;
						if (num2 < productName.Length)
						{
							num = -2130390459;
							num3 = num;
						}
						else
						{
							num = -2130390449;
							num3 = num;
						}
						continue;
						IL_0057:
						if (isAllowed)
						{
							num = -2130390455;
							continue;
						}
						goto IL_00fa;
					}
					goto IL_0016;
					IL_00fa:
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						num = -2130390451;
					}
					else if (!alwaysMatch)
					{
						text = bridgedControllerHWInfo.hw_productName;
						if (text != null)
						{
							goto IL_00b5;
						}
						text = string.Empty;
						num = -2130390460;
					}
					else
					{
						num = -2130390452;
					}
					goto IL_001b;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					while (true)
					{
						int num = 1510418852;
						while (true)
						{
							switch (num ^ 0x5A0729A5)
							{
							case 0:
								break;
							case 1:
								goto IL_0024;
							default:
								return matchingCriteria;
							}
							break;
							IL_0024:
							CopyVars(matchingCriteria);
							num = 1510418855;
						}
					}
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					MatchingCriteria matchingCriteria = destination as MatchingCriteria;
					if (matchingCriteria == null)
					{
						while (true)
						{
							switch (-1875770850 ^ -1875770852)
							{
							case 0:
								continue;
							case 2:
								return;
							}
							break;
						}
					}
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				public override int axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					int num = 0;
					int num3 = default(int);
					while (true)
					{
						int num2 = 1948428494;
						while (true)
						{
							switch (num2 ^ 0x7422A8CC)
							{
							case 4:
								break;
							case 2:
								num2 = 1948428492;
								continue;
							case 1:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = 1948428492;
								continue;
							case 0:
								if (num >= axisCount)
								{
									num3 = 0;
									num2 = 1948428495;
									continue;
								}
								goto case 1;
							case 5:
								if (buttons[num3].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num3++;
								num2 = 1948428495;
								continue;
							default:
								if (num3 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								goto case 5;
							}
							break;
						}
					}
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					while (num < axisCount)
					{
						while (true)
						{
							int num2;
							int num3;
							if (axes[num].elementIdentifier == elementIdentifier.id)
							{
								num2 = 868757922;
								num3 = num2;
							}
							else
							{
								num2 = 868757927;
								num3 = num2;
							}
							while (true)
							{
								switch (num2 ^ 0x33C831A3)
								{
								case 7:
									num2 = 868757931;
									continue;
								case 3:
									if (axes[num].invert)
									{
										axisRange = InputTools.InvertAxisRange(axisRange);
										num2 = 868757921;
										continue;
									}
									goto case 2;
								case 6:
									break;
								case 0:
									return true;
								case 4:
									num++;
									num2 = 868757926;
									continue;
								case 8:
									goto end_IL_000c;
								case 1:
									goto IL_00be;
								case 2:
									return true;
								default:
									goto end_IL_0095;
								}
								goto IL_0062;
								IL_00be:
								switch (axes[num].sourceType)
								{
								case 1:
									break;
								default:
									throw new NotImplementedException();
								case 100:
									num2 = 868757925;
									continue;
								case 0:
									axisRange = AxisRange.Positive;
									num2 = 868757923;
									continue;
								}
								goto IL_0062;
								IL_0062:
								axisRange = axes[num].sourceAxisRange;
								num2 = 868757920;
								continue;
								end_IL_000c:
								break;
							}
							continue;
							end_IL_0095:
							break;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					Elements elements = destination as Elements;
					if (elements != null)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Button : Platform_Custom.Button
			{
				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Button button = destination as Button;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Axis axis = destination as Axis;
					while (true)
					{
						int num = 659138408;
						while (true)
						{
							switch (num ^ 0x2749A769)
							{
							case 0:
								break;
							default:
								return;
							case 1:
								goto IL_002c;
							case 2:
								return;
							}
							break;
							IL_002c:
							num = 659138411;
						}
					}
				}
			}

			private sealed class kiArANKdEMOJpNXxyuEFOCaYprA : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_PS4_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int TfAJsFugTQDhHkhxAVDwSNmRnsId;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
					{
						goto IL_0012;
					}
					goto IL_0059;
					IL_0012:
					int num = -826624544;
					goto IL_0017;
					IL_0017:
					kiArANKdEMOJpNXxyuEFOCaYprA kiArANKdEMOJpNXxyuEFOCaYprA2 = default(kiArANKdEMOJpNXxyuEFOCaYprA);
					while (true)
					{
						switch (num ^ -826624540)
						{
						case 0:
							break;
						case 4:
							if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
							{
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
								num = -826624537;
								continue;
							}
							goto IL_0059;
						case 3:
							kiArANKdEMOJpNXxyuEFOCaYprA2 = this;
							num = -826624538;
							continue;
						case 1:
							goto IL_0059;
						default:
							return kiArANKdEMOJpNXxyuEFOCaYprA2;
						}
						break;
					}
					goto IL_0012;
					IL_0059:
					kiArANKdEMOJpNXxyuEFOCaYprA2 = new kiArANKdEMOJpNXxyuEFOCaYprA(0);
					kiArANKdEMOJpNXxyuEFOCaYprA2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
					num = -826624538;
					goto IL_0017;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 0:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = -1350766978;
						goto IL_001f;
					case 1:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							TfAJsFugTQDhHkhxAVDwSNmRnsId++;
							num = -1350766977;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -1350766984)
							{
							case 0:
								num = -1350766979;
								continue;
							case 3:
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes != null)
								{
									TfAJsFugTQDhHkhxAVDwSNmRnsId = 0;
									num = -1350766977;
									continue;
								}
								goto end_IL_0008;
							case 1:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes[TfAJsFugTQDhHkhxAVDwSNmRnsId];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -1350766980;
								continue;
							case 5:
								break;
							case 4:
								return true;
							case 6:
								goto IL_00cf;
							case 7:
								goto IL_00f0;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00f0:
							int num2;
							if (TfAJsFugTQDhHkhxAVDwSNmRnsId >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes.Length)
							{
								num = -1350766982;
								num2 = num;
							}
							else
							{
								num = -1350766983;
								num2 = num;
							}
							continue;
							IL_00cf:
							int num3;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements == null)
							{
								num = -1350766982;
								num3 = num;
							}
							else
							{
								num = -1350766981;
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
				public kiArANKdEMOJpNXxyuEFOCaYprA(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class kFEBpRPFbSAoxilNOolkHRdUcgZr : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_PS4_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int nAoxDZClQhrVcyuBglUnAHoULJl;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						goto IL_001c;
					}
					goto IL_004e;
					IL_004e:
					kFEBpRPFbSAoxilNOolkHRdUcgZr kFEBpRPFbSAoxilNOolkHRdUcgZr2 = new kFEBpRPFbSAoxilNOolkHRdUcgZr(0);
					kFEBpRPFbSAoxilNOolkHRdUcgZr2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
					int num = 1647907504;
					goto IL_0021;
					IL_001c:
					num = 1647907505;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ 0x623912B2)
						{
						case 0:
							break;
						case 3:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							kFEBpRPFbSAoxilNOolkHRdUcgZr2 = this;
							num = 1647907504;
							continue;
						case 1:
							goto IL_004e;
						default:
							return kFEBpRPFbSAoxilNOolkHRdUcgZr2;
						}
						break;
					}
					goto IL_001c;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 0:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = 231974587;
						goto IL_001f;
					case 1:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							num = 231974584;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0xDD3A6BA)
							{
							case 0:
								num = 231974590;
								continue;
							case 4:
								break;
							case 1:
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements != null && ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons != null)
								{
									nAoxDZClQhrVcyuBglUnAHoULJl = 0;
									num = 231974588;
									continue;
								}
								goto end_IL_0008;
							case 6:
								goto IL_008c;
							case 2:
								nAoxDZClQhrVcyuBglUnAHoULJl++;
								num = 231974588;
								continue;
							case 3:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons[nAoxDZClQhrVcyuBglUnAHoULJl];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							default:
								goto end_IL_0008;
							}
							break;
							IL_008c:
							int num2;
							if (nAoxDZClQhrVcyuBglUnAHoULJl < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons.Length)
							{
								num = 231974585;
								num2 = num;
							}
							else
							{
								num = 231974591;
								num2 = num;
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
				public kFEBpRPFbSAoxilNOolkHRdUcgZr(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			public override int assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			public override int assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.ehbCQljLDvgiNbFTeUQYWfWVaDsb;
				}
			}

			internal override Platform_Custom.Axis[] Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						int num2 = default(int);
						while (true)
						{
							int num = -1993908294;
							while (true)
							{
								switch (num ^ -1993908295)
								{
								case 5:
									break;
								case 3:
									if (axes_orig != null)
									{
										_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
										num = -1993908289;
										continue;
									}
									goto end_IL_0012;
								case 1:
									num = -1993908293;
									continue;
								case 4:
									_axesOrigGame[num2] = axes_orig[num2];
									num2++;
									num = -1993908293;
									continue;
								case 6:
									num2 = 0;
									num = -1993908296;
									continue;
								case 2:
									goto IL_007e;
								default:
									goto end_IL_0012;
								}
								break;
								IL_007e:
								int num3;
								if (num2 >= axes_orig.Length)
								{
									num = -1993908295;
									num3 = num;
								}
								else
								{
									num = -1993908291;
									num3 = num;
								}
							}
							continue;
							end_IL_0012:
							break;
						}
					}
					return _axesOrigGame;
				}
			}

			internal override Platform_Custom.Button[] Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							int num2 = default(int);
							while (true)
							{
								int num = 202839925;
								while (true)
								{
									switch (num ^ 0xC171776)
									{
									case 5:
										break;
									case 3:
										_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
										num2 = 0;
										num = 202839922;
										continue;
									case 2:
										_buttonsOrigGame[num2] = buttons_orig[num2];
										num = 202839927;
										continue;
									case 4:
										goto IL_0065;
									case 1:
										num2++;
										num = 202839922;
										continue;
									default:
										goto end_IL_0012;
									}
									break;
									IL_0065:
									int num3;
									if (num2 < buttons_orig.Length)
									{
										num = 202839924;
										num3 = num;
									}
									else
									{
										num = 202839926;
										num3 = num;
									}
								}
								continue;
								end_IL_0012:
								break;
							}
						}
					}
					return _buttonsOrigGame;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			internal override bool hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			internal override bool disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			internal override bool isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal override Elements_Base elements_base
			{
				get
				{
					return elements;
				}
			}

			internal override IList<Platform> variants_base
			{
				get
				{
					return null;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				kiArANKdEMOJpNXxyuEFOCaYprA kiArANKdEMOJpNXxyuEFOCaYprA2 = new kiArANKdEMOJpNXxyuEFOCaYprA(-2);
				kiArANKdEMOJpNXxyuEFOCaYprA2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return kiArANKdEMOJpNXxyuEFOCaYprA2;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				kFEBpRPFbSAoxilNOolkHRdUcgZr kFEBpRPFbSAoxilNOolkHRdUcgZr2 = new kFEBpRPFbSAoxilNOolkHRdUcgZr(-2);
				kFEBpRPFbSAoxilNOolkHRdUcgZr2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return kFEBpRPFbSAoxilNOolkHRdUcgZr2;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				int num3 = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = 522014351;
					while (true)
					{
						switch (num ^ 0x1F1D4E8E)
						{
						case 7:
							break;
						case 4:
						{
							int num5;
							if (num3 < 0)
							{
								num = 522014344;
								num5 = num;
							}
							else
							{
								num = 522014350;
								num5 = num;
							}
							continue;
						}
						case 6:
							Logger.LogError("Element identifier index is out of bounds!");
							num = 522014347;
							continue;
						case 1:
							num2 = 0;
							num = 522014349;
							continue;
						case 2:
							array[num2] = identifiers[num3].name;
							num = 522014347;
							continue;
						case 8:
						{
							int elementIdentifier = elements.axes[num2].elementIdentifier;
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num = 522014346;
							continue;
						}
						case 0:
						{
							int num4;
							if (num3 < identifiers.Length)
							{
								num = 522014348;
								num4 = num;
							}
							else
							{
								num = 522014344;
								num4 = num;
							}
							continue;
						}
						case 5:
							num2++;
							num = 522014349;
							continue;
						default:
							if (num2 >= array.Length)
							{
								return array;
							}
							goto case 8;
						}
						break;
					}
				}
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				string[] array = default(string[]);
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					int num = -476657639;
					while (true)
					{
						switch (num ^ -476657636)
						{
						case 2:
							break;
						case 5:
							if (identifiers.Length < buttonCount)
							{
								Logger.LogError("You have too few element identifiers!");
								return new string[0];
							}
							array = new string[buttonCount];
							num2 = 0;
							num = -476657640;
							continue;
						case 0:
							num2++;
							num = -476657640;
							continue;
						case 7:
						{
							int elementIdentifier = elements.buttons[num2].elementIdentifier;
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							int num4;
							if (num3 >= 0)
							{
								num = -476657638;
								num4 = num;
							}
							else
							{
								num = -476657633;
								num4 = num;
							}
							continue;
						}
						case 3:
							Logger.LogError("Element identifier index is out of bounds!");
							num = -476657636;
							continue;
						case 6:
						{
							int num5;
							if (num3 >= identifiers.Length)
							{
								num = -476657633;
								num5 = num;
							}
							else
							{
								num = -476657635;
								num5 = num;
							}
							continue;
						}
						case 1:
							array[num2] = identifiers[num3].name;
							num = -476657636;
							continue;
						default:
							if (num2 >= array.Length)
							{
								return array;
							}
							goto case 7;
						}
						break;
					}
				}
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				bool result;
				using (IEnumerator<Platform_Custom.Axis> enumerator = IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator.Current;
							if (axis.elementIdentifier != elementIdentifierId)
							{
								break;
							}
							result = true;
							int num = -286917;
							while (true)
							{
								switch (num ^ -286920)
								{
								case 0:
									num = -286918;
									continue;
								case 2:
									break;
								default:
									goto end_IL_0030;
								case 3:
									goto IL_00d5;
								}
								break;
							}
							continue;
							end_IL_0030:
							break;
						}
					}
				}
				foreach (Button item in IterateButtons())
				{
					if (item.elementIdentifier != elementIdentifierId)
					{
						continue;
					}
					result = true;
					goto IL_00d5;
				}
				return false;
				IL_00d5:
				return result;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				using (IEnumerator<Platform_Custom.Button> enumerator = IterateButtons().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Button button = (Button)enumerator.Current;
							buttons[num] = button.elementIdentifier;
							num++;
							int num2 = -255871336;
							while (true)
							{
								switch (num2 ^ -255871335)
								{
								case 0:
									num2 = -255871333;
									continue;
								case 2:
									break;
								default:
									goto end_IL_0048;
								}
								break;
							}
							continue;
							end_IL_0048:
							break;
						}
					}
				}
				num = 0;
				using (IEnumerator<Platform_Custom.Axis> enumerator2 = IterateAxes().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator2.Current;
							axes[num] = axis.elementIdentifier;
							num++;
							int num3 = -255871335;
							while (true)
							{
								switch (num3 ^ -255871335)
								{
								case 2:
									num3 = -255871336;
									continue;
								case 1:
									break;
								default:
									goto end_IL_00ac;
								}
								break;
							}
							continue;
							end_IL_00ac:
							break;
						}
					}
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				int num = 0;
				while (num < axes_orig.Length)
				{
					while (true)
					{
						IL_016e:
						int num2;
						if (axes_orig[num].sourceType != 1)
						{
							int num3;
							if (axes_orig[num].sourceType != 100)
							{
								num2 = -650687891;
								num3 = num2;
							}
							else
							{
								num2 = -650687901;
								num3 = num2;
							}
							goto IL_0021;
						}
						goto IL_0108;
						IL_0021:
						while (true)
						{
							switch (num2 ^ -650687899)
							{
							case 7:
								num2 = -650687900;
								continue;
							case 11:
								throw new NotImplementedException();
							case 5:
								array[num].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num].alternateCalibrations, true);
								num++;
								num2 = -650687903;
								continue;
							case 10:
								array[num].min = axes_orig[num].axisMin;
								array[num].max = axes_orig[num].axisMax;
								num2 = -650687897;
								continue;
							case 0:
								array[num] = AxisCalibrationData.Default;
								num2 = -650687904;
								continue;
							case 9:
								array[num].zero = axes_orig[num].axisZero;
								num2 = -650687889;
								continue;
							case 2:
								num2 = -650687904;
								continue;
							case 6:
								break;
							case 3:
								goto IL_0123;
							case 1:
								goto IL_016e;
							case 8:
								goto IL_0199;
							default:
								goto end_IL_016e;
							}
							break;
							IL_0199:
							int num4;
							if (axes_orig[num].sourceType == 0)
							{
								num2 = -650687899;
								num4 = num2;
							}
							else
							{
								num2 = -650687890;
								num4 = num2;
							}
							continue;
							IL_0123:
							array[num].invert = axes_orig[num].invert;
							array[num].deadZone = axes_orig[num].axisDeadZone;
							int num5;
							if (Axes_orig[num].calibrateAxis)
							{
								num2 = -650687892;
								num5 = num2;
							}
							else
							{
								num2 = -650687904;
								num5 = num2;
							}
						}
						goto IL_0108;
						IL_0108:
						array[num] = AxisCalibrationData.Default;
						num2 = -650687898;
						goto IL_0021;
						continue;
						end_IL_016e:
						break;
					}
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				int num2 = default(int);
				while (true)
				{
					int num = 377121862;
					while (true)
					{
						switch (num ^ 0x167A6C47)
						{
						case 7:
							break;
						case 8:
							throw new Exception();
						case 2:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = 377121860;
							continue;
						case 5:
							if (Axes_orig[num2].sourceType != 1)
							{
								int num3;
								if (Axes_orig[num2].sourceType == 100)
								{
									num = 377121861;
									num3 = num;
								}
								else
								{
									num = 377121859;
									num3 = num;
								}
								continue;
							}
							goto case 2;
						case 3:
							num2++;
							num = 377121870;
							continue;
						case 1:
							axisInfos = null;
							if (Axes_orig == null)
							{
								return;
							}
							goto case 6;
						case 6:
							axisRanges = new AxisRange[Axes_orig.Length];
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num = 377121863;
							continue;
						case 10:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							num = 377121858;
							continue;
						case 0:
							num2 = 0;
							num = 377121870;
							continue;
						case 4:
							if (Axes_orig[num2].sourceType == 0)
							{
								axisRanges[num2] = AxisRange.Full;
								num = 377121860;
								continue;
							}
							goto case 8;
						default:
							if (num2 >= Axes_orig.Length)
							{
								return;
							}
							goto case 10;
						}
						break;
					}
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig == null)
				{
					return;
				}
				int num2 = default(int);
				while (true)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					int num = -2132786101;
					while (true)
					{
						switch (num ^ -2132786097)
						{
						case 5:
							num = -2132786098;
							continue;
						default:
							return;
						case 1:
							break;
						case 3:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
							num2++;
							num = -2132786097;
							continue;
						case 0:
						{
							int num3;
							if (num2 >= Buttons_orig.Length)
							{
								num = -2132786099;
								num3 = num;
							}
							else
							{
								num = -2132786100;
								num3 = num;
							}
							continue;
						}
						case 4:
							num2 = 0;
							num = -2132786097;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_PS4_Base platform_PS4_Base = new Platform_PS4_Base();
				while (true)
				{
					int num = -68180282;
					while (true)
					{
						switch (num ^ -68180281)
						{
						case 0:
							break;
						case 1:
							goto IL_0024;
						default:
							return platform_PS4_Base;
						}
						break;
						IL_0024:
						CopyVars(platform_PS4_Base);
						num = -68180283;
					}
				}
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_PS4_Base platform_PS4_Base = destination as Platform_PS4_Base;
				if (platform_PS4_Base != null)
				{
					platform_PS4_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_PS4_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_PS4 : Platform_PS4_Base
		{
			public Platform_PS4_Base[] variants;

			internal override IList<Platform> variants_base
			{
				get
				{
					return variants;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					int num2 = default(int);
					while (true)
					{
						int num = 1619761940;
						while (true)
						{
							switch (num ^ 0x608B9B16)
							{
							case 4:
								break;
							case 0:
								goto IL_003d;
							case 1:
								goto IL_0059;
							case 2:
								num2 = 0;
								num = 1619761942;
								continue;
							default:
								goto end_IL_0017;
							}
							break;
							IL_0059:
							int variantIndex2;
							if (variants[num2] != null && variants[num2].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
							{
								variantIndex = num2;
								return true;
							}
							num2++;
							num = 1619761942;
							continue;
							IL_003d:
							int num3;
							if (num2 < variants.Length)
							{
								num = 1619761943;
								num3 = num;
							}
							else
							{
								num = 1619761941;
								num3 = num;
							}
						}
						continue;
						end_IL_0017:
						break;
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_PS4 platform_PS = new Platform_PS4();
				CopyVars(platform_PS);
				return platform_PS;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_PS4 platform_PS = destination as Platform_PS4;
				if (platform_PS == null)
				{
					return;
				}
				while (true)
				{
					platform_PS.variants = MiscTools.DeepClone(variants);
					int num = 1595754983;
					while (true)
					{
						switch (num ^ 0x5F1D49E7)
						{
						case 2:
							goto IL_0012;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_0012:
						num = 1595754982;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_NintendoSwitch_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				internal override bool hasData
				{
					get
					{
						if (base.hasData)
						{
							return true;
						}
						if (productName != null && productName.Length > 0)
						{
							return true;
						}
						return false;
					}
				}

				internal override bool isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							goto IL_0008;
						}
						int num;
						if (disabled)
						{
							num = 104984514;
							goto IL_000d;
						}
						return true;
						IL_0008:
						num = 104984513;
						goto IL_000d;
						IL_000d:
						switch (num ^ 0x641EFC3)
						{
						case 0:
							break;
						case 2:
							return false;
						default:
							return false;
						}
						goto IL_0008;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						goto IL_0021;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					string text = default(string);
					int num;
					if (!alwaysMatch)
					{
						text = bridgedControllerHWInfo.hw_productName;
						if (text != null)
						{
							goto IL_005a;
						}
						text = string.Empty;
						num = -928867171;
					}
					else
					{
						num = -928867172;
					}
					goto IL_0026;
					IL_0106:
					return false;
					IL_0026:
					string searchFor = default(string);
					int num2 = default(int);
					while (true)
					{
						switch (num ^ -928867171)
						{
						case 7:
							break;
						case 0:
							goto IL_005a;
						case 6:
							searchFor = productName[num2];
							num = -928867179;
							continue;
						case 8:
							goto IL_0085;
						case 1:
							return true;
						case 5:
							goto IL_00bd;
						case 4:
							return true;
						case 2:
							num = -928867176;
							continue;
						default:
							goto IL_0106;
						}
						break;
						IL_00bd:
						int num3;
						if (num2 < productName.Length)
						{
							num = -928867173;
							num3 = num;
						}
						else
						{
							num = -928867170;
							num3 = num;
						}
						continue;
						IL_0085:
						if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
						{
							return true;
						}
						num2++;
						num = -928867176;
					}
					goto IL_0021;
					IL_005a:
					text = text.Trim();
					if (productName != null)
					{
						num2 = 0;
						num = -928867169;
						goto IL_0026;
					}
					goto IL_0106;
					IL_0021:
					num = -928867175;
					goto IL_0026;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					MatchingCriteria matchingCriteria = destination as MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					while (true)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						int num = -1161323881;
						while (true)
						{
							switch (num ^ -1161323882)
							{
							case 0:
								goto IL_0012;
							case 2:
								break;
							default:
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								return;
							}
							break;
							IL_0012:
							num = -1161323884;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				public override int axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					int num = 0;
					int num3 = default(int);
					while (true)
					{
						int num2 = -899300282;
						while (true)
						{
							switch (num2 ^ -899300285)
							{
							case 6:
								break;
							case 5:
								num2 = -899300285;
								continue;
							case 1:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = -899300285;
								continue;
							case 2:
								if (buttons[num3].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num3++;
								num2 = -899300288;
								continue;
							case 0:
							{
								int num4;
								if (num < axisCount)
								{
									num2 = -899300286;
									num4 = num2;
								}
								else
								{
									num2 = -899300281;
									num4 = num2;
								}
								continue;
							}
							case 4:
								num3 = 0;
								num2 = -899300288;
								continue;
							default:
								if (num3 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								goto case 2;
							}
							break;
						}
					}
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					while (true)
					{
						int num2;
						int num3;
						if (num < axisCount)
						{
							num2 = -23489504;
							num3 = num2;
						}
						else
						{
							num2 = -23489501;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -23489499)
							{
							case 2:
								num2 = -23489504;
								continue;
							case 5:
								if (axes[num].elementIdentifier != elementIdentifier.id)
								{
									goto case 3;
								}
								switch (axes[num].sourceType)
								{
								case 100:
									num2 = -23489503;
									continue;
								case 0:
									axisRange = AxisRange.Positive;
									return true;
								default:
									throw new NotImplementedException();
								case 1:
									break;
								}
								goto case 4;
							case 3:
								num++;
								num2 = -23489500;
								continue;
							case 1:
								break;
							case 0:
								return true;
							case 4:
								axisRange = axes[num].sourceAxisRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -23489499;
									continue;
								}
								goto case 0;
							default:
								axisRange = AxisRange.Full;
								return false;
							}
							break;
						}
					}
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					Elements elements = default(Elements);
					while (true)
					{
						int num = -1835987120;
						while (true)
						{
							switch (num ^ -1835987118)
							{
							case 4:
								break;
							case 0:
								return;
							case 1:
							{
								int num2;
								if (elements == null)
								{
									num = -1835987118;
									num2 = num;
								}
								else
								{
									num = -1835987119;
									num2 = num;
								}
								continue;
							}
							case 2:
								elements = destination as Elements;
								num = -1835987117;
								continue;
							default:
								elements.axes = ArrayTools.DeepClone(axes);
								elements.buttons = ArrayTools.DeepClone(buttons);
								return;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Button : Platform_Custom.Button
			{
				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Button button = destination as Button;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Axis axis = destination as Axis;
				}
			}

			private sealed class afstenQAlfCSZfAgpMtflYJHyQH : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_NintendoSwitch_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int xgnbhqdEpwGogHsWuaQPekbvjlvd;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						goto IL_0023;
					}
					goto IL_0059;
					IL_0028:
					int num;
					afstenQAlfCSZfAgpMtflYJHyQH afstenQAlfCSZfAgpMtflYJHyQH2 = default(afstenQAlfCSZfAgpMtflYJHyQH);
					while (true)
					{
						switch (num ^ -1173189186)
						{
						case 0:
							break;
						case 3:
							afstenQAlfCSZfAgpMtflYJHyQH2 = this;
							num = -1173189185;
							continue;
						case 1:
							num = -1173189190;
							continue;
						case 2:
							goto IL_0059;
						default:
							return afstenQAlfCSZfAgpMtflYJHyQH2;
						}
						break;
					}
					goto IL_0023;
					IL_0059:
					afstenQAlfCSZfAgpMtflYJHyQH2 = new afstenQAlfCSZfAgpMtflYJHyQH(0);
					afstenQAlfCSZfAgpMtflYJHyQH2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
					num = -1173189190;
					goto IL_0028;
					IL_0023:
					num = -1173189187;
					goto IL_0028;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 0:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = 307643827;
						goto IL_001f;
					case 1:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							xgnbhqdEpwGogHsWuaQPekbvjlvd++;
							num = 307643830;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x125645B6)
							{
							case 2:
								num = 307643829;
								continue;
							case 3:
								break;
							case 5:
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements != null && ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes != null)
								{
									xgnbhqdEpwGogHsWuaQPekbvjlvd = 0;
									num = 307643830;
									continue;
								}
								goto end_IL_0008;
							case 6:
								return true;
							case 0:
								goto IL_00ad;
							case 1:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes[xgnbhqdEpwGogHsWuaQPekbvjlvd];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 307643824;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00ad:
							int num2;
							if (xgnbhqdEpwGogHsWuaQPekbvjlvd >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes.Length)
							{
								num = 307643826;
								num2 = num;
							}
							else
							{
								num = 307643831;
								num2 = num;
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
				public afstenQAlfCSZfAgpMtflYJHyQH(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class CUIcAxulcQFSHFUJykXWbJiFIVNh : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_NintendoSwitch_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int DXlTeyHpuSNeprLFdDRKcYemcYOt;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						goto IL_001c;
					}
					goto IL_0042;
					IL_0042:
					CUIcAxulcQFSHFUJykXWbJiFIVNh cUIcAxulcQFSHFUJykXWbJiFIVNh = new CUIcAxulcQFSHFUJykXWbJiFIVNh(0);
					cUIcAxulcQFSHFUJykXWbJiFIVNh.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
					int num = 536554700;
					goto IL_0021;
					IL_001c:
					num = 536554697;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ 0x1FFB2CC8)
						{
						case 0:
							break;
						case 3:
							goto IL_0042;
						case 2:
							num = 536554700;
							continue;
						case 1:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							cUIcAxulcQFSHFUJykXWbJiFIVNh = this;
							num = 536554698;
							continue;
						default:
							return cUIcAxulcQFSHFUJykXWbJiFIVNh;
						}
						break;
					}
					goto IL_001c;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					int num3;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					default:
						num = 192966890;
						goto IL_001a;
					case 0:
						goto IL_00ec;
					case 1:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							DXlTeyHpuSNeprLFdDRKcYemcYOt++;
							num = 192966880;
							goto IL_001a;
						}
						IL_001a:
						while (true)
						{
							switch (num ^ 0xB8070E8)
							{
							case 7:
								break;
							case 3:
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons != null)
								{
									DXlTeyHpuSNeprLFdDRKcYemcYOt = 0;
									num = 192966892;
									continue;
								}
								goto default;
							case 5:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons[DXlTeyHpuSNeprLFdDRKcYemcYOt];
								num = 192966889;
								continue;
							case 2:
								num = 192966881;
								continue;
							case 4:
								num = 192966880;
								continue;
							case 1:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 192966888;
								continue;
							case 8:
								goto IL_00be;
							case 6:
								goto IL_00ec;
							case 0:
								return true;
							default:
								return false;
							}
							break;
							IL_00be:
							int num2;
							if (DXlTeyHpuSNeprLFdDRKcYemcYOt >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons.Length)
							{
								num = 192966881;
								num2 = num;
							}
							else
							{
								num = 192966893;
								num2 = num;
							}
						}
						goto default;
						IL_00ec:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements == null)
						{
							num = 192966881;
							num3 = num;
						}
						else
						{
							num = 192966891;
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
				public CUIcAxulcQFSHFUJykXWbJiFIVNh(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			public override int assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			public override int assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.nbOhDhcnKQfYJsEjsPifPczVJFzj;
				}
			}

			internal override Platform_Custom.Axis[] Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						int num2 = default(int);
						Axis[] axes_orig = default(Axis[]);
						while (true)
						{
							int num = -902638552;
							while (true)
							{
								switch (num ^ -902638549)
								{
								case 4:
									break;
								case 1:
									goto IL_002e;
								case 0:
									_axesOrigGame[num2] = axes_orig[num2];
									num2++;
									num = -902638550;
									continue;
								case 3:
									axes_orig = Axes_orig;
									if (axes_orig != null)
									{
										_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
										num2 = 0;
										num = -902638550;
										continue;
									}
									goto end_IL_0008;
								default:
									goto end_IL_0008;
								}
								break;
								IL_002e:
								int num3;
								if (num2 < axes_orig.Length)
								{
									num = -902638549;
									num3 = num;
								}
								else
								{
									num = -902638551;
									num3 = num;
								}
							}
							continue;
							end_IL_0008:
							break;
						}
					}
					return _axesOrigGame;
				}
			}

			internal override Platform_Custom.Button[] Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							int num2 = default(int);
							while (true)
							{
								int num = -1620736762;
								while (true)
								{
									switch (num ^ -1620736761)
									{
									case 0:
										break;
									case 1:
										num2 = 0;
										num = -1620736763;
										continue;
									case 3:
										_buttonsOrigGame[num2] = buttons_orig[num2];
										num2++;
										num = -1620736763;
										continue;
									case 2:
										goto IL_0065;
									default:
										goto end_IL_0020;
									}
									break;
									IL_0065:
									int num3;
									if (num2 >= buttons_orig.Length)
									{
										num = -1620736765;
										num3 = num;
									}
									else
									{
										num = -1620736764;
										num3 = num;
									}
								}
								continue;
								end_IL_0020:
								break;
							}
						}
					}
					return _buttonsOrigGame;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			internal override bool hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						return false;
					}
					return true;
				}
			}

			internal override bool disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			internal override bool isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal override Elements_Base elements_base
			{
				get
				{
					return elements;
				}
			}

			internal override IList<Platform> variants_base
			{
				get
				{
					return null;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				while (true)
				{
					int num = 1872150204;
					while (true)
					{
						switch (num ^ 0x6F96BEB8)
						{
						case 2:
							break;
						case 4:
							platformMap = null;
							num = 1872150200;
							continue;
						case 3:
							if (matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
							{
								platformMap = this;
								num = 1872150201;
								continue;
							}
							goto IL_005f;
						case 0:
							if (matchingCriteria != null)
							{
								num = 1872150203;
								continue;
							}
							goto IL_005f;
						default:
							{
								return true;
							}
							IL_005f:
							return false;
						}
						break;
					}
				}
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				afstenQAlfCSZfAgpMtflYJHyQH afstenQAlfCSZfAgpMtflYJHyQH2 = new afstenQAlfCSZfAgpMtflYJHyQH(-2);
				afstenQAlfCSZfAgpMtflYJHyQH2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return afstenQAlfCSZfAgpMtflYJHyQH2;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				CUIcAxulcQFSHFUJykXWbJiFIVNh cUIcAxulcQFSHFUJykXWbJiFIVNh = new CUIcAxulcQFSHFUJykXWbJiFIVNh(-2);
				cUIcAxulcQFSHFUJykXWbJiFIVNh.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return cUIcAxulcQFSHFUJykXWbJiFIVNh;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				int num = 0;
				while (num < array.Length)
				{
					while (true)
					{
						int elementIdentifier = elements.axes[num].elementIdentifier;
						int num2 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						int num3;
						if (num2 >= 0)
						{
							int num4;
							if (num2 < identifiers.Length)
							{
								num3 = -400758401;
								num4 = num3;
							}
							else
							{
								num3 = -400758402;
								num4 = num3;
							}
							goto IL_003e;
						}
						goto IL_009a;
						IL_003e:
						while (true)
						{
							switch (num3 ^ -400758401)
							{
							case 5:
								num3 = -400758405;
								continue;
							case 4:
								break;
							case 1:
								goto IL_009a;
							case 0:
								array[num] = identifiers[num2].name;
								num3 = -400758403;
								continue;
							case 2:
								num++;
								num3 = -400758404;
								continue;
							default:
								goto end_IL_0063;
							}
							break;
						}
						continue;
						IL_009a:
						Logger.LogError("Element identifier index is out of bounds!");
						num3 = -400758403;
						goto IL_003e;
						continue;
						end_IL_0063:
						break;
					}
				}
				return array;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				if (identifiers.Length < buttonCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[buttonCount];
				int num = 0;
				int num3 = default(int);
				while (true)
				{
					int num2 = -1694235130;
					while (true)
					{
						switch (num2 ^ -1694235136)
						{
						case 7:
							break;
						case 4:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = -1694235133;
							continue;
						case 2:
						{
							int elementIdentifier = elements.buttons[num].elementIdentifier;
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							int num5;
							if (num3 < 0)
							{
								num2 = -1694235132;
								num5 = num2;
							}
							else
							{
								num2 = -1694235131;
								num5 = num2;
							}
							continue;
						}
						case 3:
							num++;
							num2 = -1694235136;
							continue;
						case 5:
						{
							int num4;
							if (num3 < identifiers.Length)
							{
								num2 = -1694235135;
								num4 = num2;
							}
							else
							{
								num2 = -1694235132;
								num4 = num2;
							}
							continue;
						}
						case 1:
							array[num] = identifiers[num3].name;
							num2 = -1694235133;
							continue;
						case 6:
							num2 = -1694235136;
							continue;
						default:
							if (num >= array.Length)
							{
								return array;
							}
							goto case 2;
						}
						break;
					}
				}
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				bool result;
				using (IEnumerator<Platform_Custom.Axis> enumerator = IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator.Current;
							if (axis.elementIdentifier != elementIdentifierId)
							{
								break;
							}
							result = true;
							int num = -404207977;
							while (true)
							{
								switch (num ^ -404207978)
								{
								case 0:
									num = -404207979;
									continue;
								case 3:
									break;
								default:
									goto end_IL_0030;
								case 1:
									goto IL_00d5;
								}
								break;
							}
							continue;
							end_IL_0030:
							break;
						}
					}
				}
				foreach (Button item in IterateButtons())
				{
					if (item.elementIdentifier != elementIdentifierId)
					{
						continue;
					}
					result = true;
					goto IL_00d5;
				}
				return false;
				IL_00d5:
				return result;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				int num2 = default(int);
				Axis axis = default(Axis);
				while (true)
				{
					int num = 1337990143;
					while (true)
					{
						switch (num ^ 0x4FC01BFE)
						{
						case 2:
							break;
						case 1:
							goto IL_002b;
						default:
						{
							using (IEnumerator<Platform_Custom.Button> enumerator = IterateButtons().GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										Button button = (Button)enumerator.Current;
										buttons[num2] = button.elementIdentifier;
										num2++;
										int num3 = 1337990140;
										while (true)
										{
											switch (num3 ^ 0x4FC01BFE)
											{
											case 0:
												num3 = 1337990143;
												continue;
											case 1:
												break;
											default:
												goto end_IL_006d;
											}
											break;
										}
										continue;
										end_IL_006d:
										break;
									}
								}
							}
							num2 = 0;
							using (IEnumerator<Platform_Custom.Axis> enumerator2 = IterateAxes().GetEnumerator())
							{
								while (true)
								{
									int num4;
									int num5;
									if (!enumerator2.MoveNext())
									{
										num4 = 1337990143;
										num5 = num4;
									}
									else
									{
										num4 = 1337990138;
										num5 = num4;
									}
									while (true)
									{
										switch (num4 ^ 0x4FC01BFE)
										{
										case 2:
											num4 = 1337990138;
											continue;
										default:
											return;
										case 4:
											axis = (Axis)enumerator2.Current;
											num4 = 1337990141;
											continue;
										case 0:
											break;
										case 3:
											axes[num2] = axis.elementIdentifier;
											num2++;
											num4 = 1337990142;
											continue;
										case 1:
											return;
										}
										break;
									}
								}
							}
						}
						}
						break;
						IL_002b:
						axes = new int[assignedAxisCount];
						num2 = 0;
						num = 1337990142;
					}
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				AxisCalibrationData[] array = default(AxisCalibrationData[]);
				int num2 = default(int);
				while (true)
				{
					int num = 2010614711;
					while (true)
					{
						switch (num ^ 0x77D78BBD)
						{
						case 2:
							break;
						case 1:
							throw new NotImplementedException();
						case 7:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num2++;
							num = 2010614708;
							continue;
						case 3:
							array[num2].max = axes_orig[num2].axisMax;
							num = 2010614714;
							continue;
						case 5:
						{
							int num4;
							if (axes_orig[num2].sourceType != 100)
							{
								num = 2010614717;
								num4 = num;
							}
							else
							{
								num = 2010614713;
								num4 = num;
							}
							continue;
						}
						case 4:
							array[num2] = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							if (Axes_orig[num2].calibrateAxis)
							{
								array[num2].zero = axes_orig[num2].axisZero;
								array[num2].min = axes_orig[num2].axisMin;
								num = 2010614718;
								continue;
							}
							goto case 7;
						case 0:
							if (axes_orig[num2].sourceType == 0)
							{
								array[num2] = AxisCalibrationData.Default;
								num = 2010614709;
								continue;
							}
							goto case 1;
						case 6:
						{
							int num3;
							if (axes_orig[num2].sourceType != 1)
							{
								num = 2010614712;
								num3 = num;
							}
							else
							{
								num = 2010614713;
								num3 = num;
							}
							continue;
						}
						case 10:
							if (axes_orig == null)
							{
								return null;
							}
							array = new AxisCalibrationData[axes_orig.Length];
							num2 = 0;
							num = 2010614708;
							continue;
						case 8:
							num = 2010614714;
							continue;
						default:
							if (num2 >= axes_orig.Length)
							{
								return array;
							}
							goto case 6;
						}
						break;
					}
				}
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					goto IL_0011;
				}
				goto IL_00a0;
				IL_0011:
				int num = -1262122936;
				goto IL_0016;
				IL_0016:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ -1262122935)
					{
					case 6:
						break;
					case 0:
						axisRanges[num2] = AxisRange.Full;
						num = -1262122933;
						continue;
					case 10:
						axisInfos = new HardwareAxisInfo[Axes_orig.Length];
						num2 = 0;
						num = -1262122944;
						continue;
					case 7:
						axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
						num = -1262122932;
						continue;
					case 2:
						num2++;
						num = -1262122944;
						continue;
					case 11:
						goto IL_00a0;
					case 5:
						num = -1262122933;
						continue;
					case 4:
						axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
						if (Axes_orig[num2].sourceType == 1)
						{
							goto case 7;
						}
						goto IL_00ea;
					case 3:
						throw new Exception();
					case 8:
						goto IL_011f;
					case 1:
						return;
					default:
						if (num2 >= Axes_orig.Length)
						{
							return;
						}
						goto case 4;
					}
					break;
					IL_011f:
					int num3;
					if (Axes_orig[num2].sourceType == 0)
					{
						num = -1262122935;
						num3 = num;
					}
					else
					{
						num = -1262122934;
						num3 = num;
					}
					continue;
					IL_00ea:
					int num4;
					if (Axes_orig[num2].sourceType == 100)
					{
						num = -1262122930;
						num4 = num;
					}
					else
					{
						num = -1262122943;
						num4 = num;
					}
				}
				goto IL_0011;
				IL_00a0:
				axisRanges = new AxisRange[Axes_orig.Length];
				num = -1262122941;
				goto IL_0016;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				int num2 = default(int);
				while (true)
				{
					int num = 828508781;
					while (true)
					{
						switch (num ^ 0x31620A68)
						{
						case 0:
							break;
						default:
							return;
						case 5:
							if (Buttons_orig == null)
							{
								return;
							}
							goto case 6;
						case 2:
						{
							int num3;
							if (num2 >= Buttons_orig.Length)
							{
								num = 828508779;
								num3 = num;
							}
							else
							{
								num = 828508780;
								num3 = num;
							}
							continue;
						}
						case 6:
							buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
							num = 828508783;
							continue;
						case 7:
							num2 = 0;
							num = 828508778;
							continue;
						case 4:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
							num = 828508777;
							continue;
						case 1:
							num2++;
							num = 828508778;
							continue;
						case 3:
							return;
						}
						break;
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_NintendoSwitch_Base platform_NintendoSwitch_Base = new Platform_NintendoSwitch_Base();
				CopyVars(platform_NintendoSwitch_Base);
				return platform_NintendoSwitch_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_NintendoSwitch_Base platform_NintendoSwitch_Base = default(Platform_NintendoSwitch_Base);
				while (true)
				{
					switch (0x24676395 ^ 0x24676394)
					{
					case 2:
						continue;
					case 1:
						platform_NintendoSwitch_Base = destination as Platform_NintendoSwitch_Base;
						if (platform_NintendoSwitch_Base == null)
						{
							return;
						}
						break;
					}
					break;
				}
				platform_NintendoSwitch_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				platform_NintendoSwitch_Base.elements = MiscTools.DeepClone(elements);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_NintendoSwitch : Platform_NintendoSwitch_Base
		{
			public Platform_NintendoSwitch_Base[] variants;

			internal override IList<Platform> variants_base
			{
				get
				{
					return variants;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					int num = 0;
					while (true)
					{
						int num2 = -2036443625;
						while (true)
						{
							switch (num2 ^ -2036443629)
							{
							case 0:
								break;
							case 6:
								goto IL_004a;
							case 1:
								variantIndex = num;
								num2 = -2036443632;
								continue;
							case 2:
								goto IL_0070;
							case 3:
								return true;
							case 4:
								num2 = -2036443627;
								continue;
							default:
								goto end_IL_001c;
							}
							break;
							IL_0070:
							int variantIndex2;
							if (variants[num] != null && variants[num].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
							{
								num2 = -2036443630;
								continue;
							}
							num++;
							num2 = -2036443627;
							continue;
							IL_004a:
							int num3;
							if (num < variants.Length)
							{
								num2 = -2036443631;
								num3 = num2;
							}
							else
							{
								num2 = -2036443626;
								num3 = num2;
							}
						}
						continue;
						end_IL_001c:
						break;
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_NintendoSwitch platform_NintendoSwitch = new Platform_NintendoSwitch();
				CopyVars(platform_NintendoSwitch);
				return platform_NintendoSwitch;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_NintendoSwitch platform_NintendoSwitch = destination as Platform_NintendoSwitch;
				if (platform_NintendoSwitch == null)
				{
					while (true)
					{
						switch (0x659521D0 ^ 0x659521D2)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				platform_NintendoSwitch.variants = MiscTools.DeepClone(variants);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_InternalDriver_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				public VidPid[] vidPid;

				public int hatCount;

				internal override bool hasData
				{
					get
					{
						if (base.hasData)
						{
							return true;
						}
						if (productName != null)
						{
							goto IL_0012;
						}
						goto IL_003d;
						IL_004c:
						if (vidPid.Length > 0)
						{
							return true;
						}
						goto IL_0059;
						IL_0012:
						int num = 713143084;
						goto IL_0017;
						IL_0017:
						switch (num ^ 0x2A81B32D)
						{
						case 2:
							break;
						case 1:
							goto IL_0030;
						default:
							goto IL_004c;
						}
						goto IL_0012;
						IL_0030:
						if (productName.Length > 0)
						{
							return true;
						}
						goto IL_003d;
						IL_003d:
						if (vidPid != null)
						{
							num = 713143085;
							goto IL_0017;
						}
						goto IL_0059;
						IL_0059:
						return false;
					}
				}

				internal override bool isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						if (disabled)
						{
							return false;
						}
						return true;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						goto IL_0027;
					}
					if (alwaysMatch)
					{
						return true;
					}
					bool alternateMatched;
					if (!ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						return false;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					int num;
					int num2;
					if (text == null)
					{
						num = -407331428;
						num2 = num;
					}
					else
					{
						num = -407331435;
						num2 = num;
					}
					goto IL_002c;
					IL_0027:
					num = -407331432;
					goto IL_002c;
					IL_002c:
					int productId = default(int);
					int vendorId = default(int);
					int num3 = default(int);
					while (true)
					{
						switch (num ^ -407331428)
						{
						case 8:
							break;
						case 2:
							if (bridgedControllerHWInfo.hw_productId == productId)
							{
								return true;
							}
							goto IL_0078;
						case 11:
							vendorId = vidPid[num3].vendorId;
							num = -407331431;
							continue;
						case 10:
							if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
							{
								string name = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
								if (!ProductNameMatches(name))
								{
									return false;
								}
							}
							if (bridgedControllerHWInfo.hw_vendorId == vendorId)
							{
								num = -407331426;
								continue;
							}
							goto IL_0078;
						case 0:
							text = string.Empty;
							num = -407331435;
							continue;
						case 3:
							if (!strictMatch)
							{
								goto default;
							}
							if (vidPid != null)
							{
								num3 = 0;
								num = -407331427;
								continue;
							}
							goto case 7;
						case 9:
							text = text.Trim();
							num = -407331425;
							continue;
						case 4:
							return false;
						case 5:
							productId = vidPid[num3].productId;
							num = -407331434;
							continue;
						case 1:
						{
							int num4;
							if (num3 < vidPid.Length)
							{
								num = -407331433;
								num4 = num;
							}
							else
							{
								num = -407331429;
								num4 = num;
							}
							continue;
						}
						default:
							return ProductNameMatches(text);
						case 7:
							{
								return false;
							}
							IL_0078:
							num3++;
							num = -407331427;
							continue;
						}
						break;
					}
					goto IL_0027;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						return false;
					}
					if (alternateMatched)
					{
						return true;
					}
					if (hatCount >= 0)
					{
						return bridgedControllerHWInfo.hardwareHatCount == hatCount;
					}
					return true;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					MatchingCriteria matchingCriteria = destination as MatchingCriteria;
					if (matchingCriteria != null)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.vidPid = ArrayTools.ShallowCopy(vidPid);
						matchingCriteria.hatCount = hatCount;
					}
				}

				private bool ProductNameMatches(string name)
				{
					if (productName == null)
					{
						goto IL_0008;
					}
					int num = 0;
					int num2 = 1975789941;
					goto IL_000d;
					IL_000d:
					while (true)
					{
						switch (num2 ^ 0x75C42977)
						{
						case 3:
							break;
						case 1:
							return false;
						case 0:
						{
							string searchFor = productName[num];
							if (!MatchingCriteria_Base.StringMatches(name, searchFor, productName_useRegex))
							{
								goto IL_004f;
							}
							return true;
						}
						default:
							if (num >= productName.Length)
							{
								return false;
							}
							goto case 0;
						}
						break;
						IL_004f:
						num++;
						num2 = 1975789941;
					}
					goto IL_0008;
					IL_0008:
					num2 = 1975789942;
					goto IL_000d;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				public override int axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					int num = 0;
					int num3 = default(int);
					while (true)
					{
						int num2 = 937980957;
						while (true)
						{
							switch (num2 ^ 0x37E8741C)
							{
							case 0:
								break;
							case 3:
								if (num >= axisCount)
								{
									num3 = 0;
									num2 = 937980952;
									continue;
								}
								goto case 5;
							case 5:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									num2 = 937980954;
									continue;
								}
								num++;
								num2 = 937980959;
								continue;
							case 1:
								num2 = 937980959;
								continue;
							case 2:
								if (buttons[num3].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num3++;
								num2 = 937980952;
								continue;
							case 6:
								return ControllerElementType.Axis;
							default:
								if (num3 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								goto case 2;
							}
							break;
						}
					}
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					int sourceType = default(int);
					while (true)
					{
						int num2 = 974835743;
						while (true)
						{
							switch (num2 ^ 0x3A1AD017)
							{
							case 0:
								break;
							case 5:
								num++;
								num2 = 974835732;
								continue;
							case 7:
								sourceType = axes[num].sourceType;
								num2 = 974835729;
								continue;
							case 4:
							{
								int num4;
								if (axes[num].elementIdentifier != elementIdentifier.id)
								{
									num2 = 974835730;
									num4 = num2;
								}
								else
								{
									num2 = 974835728;
									num4 = num2;
								}
								continue;
							}
							case 1:
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 974835740;
									continue;
								}
								goto case 11;
							case 8:
								num2 = 974835732;
								continue;
							case 6:
								switch (sourceType)
								{
								case 100:
									num2 = 974835741;
									continue;
								default:
									throw new NotImplementedException();
								case 0:
									axisRange = AxisRange.Positive;
									return true;
								case 2:
									axisRange = axes[num].sourceHatRange;
									num2 = 974835734;
									continue;
								case 1:
									break;
								}
								goto case 10;
							case 3:
							{
								int num3;
								if (num < axisCount)
								{
									num2 = 974835731;
									num3 = num2;
								}
								else
								{
									num2 = 974835742;
									num3 = num2;
								}
								continue;
							}
							case 11:
								return true;
							case 2:
								return true;
							case 10:
								axisRange = axes[num].sourceAxisRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 974835733;
									continue;
								}
								goto case 2;
							default:
								axisRange = AxisRange.Full;
								return false;
							}
							break;
						}
					}
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					Elements elements = destination as Elements;
					while (true)
					{
						int num = 1679378163;
						while (true)
						{
							switch (num ^ 0x641946F2)
							{
							case 3:
								break;
							default:
								return;
							case 1:
							{
								int num2;
								if (elements == null)
								{
									num = 1679378160;
									num2 = num;
								}
								else
								{
									num = 1679378162;
									num2 = num;
								}
								continue;
							}
							case 0:
								elements.axes = ArrayTools.DeepClone(axes);
								elements.buttons = ArrayTools.DeepClone(buttons);
								num = 1679378166;
								continue;
							case 2:
								return;
							case 4:
								return;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Button : Platform_Custom.Button
			{
				public int sourceHat;

				public HatDirection sourceHatDirection;

				public HatType sourceHatType;

				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Button button = destination as Button;
					while (true)
					{
						int num = 210588193;
						while (true)
						{
							switch (num ^ 0xC8D5220)
							{
							case 3:
								break;
							default:
								return;
							case 1:
							{
								int num2;
								if (button == null)
								{
									num = 210588194;
									num2 = num;
								}
								else
								{
									num = 210588197;
									num2 = num;
								}
								continue;
							}
							case 2:
								return;
							case 5:
								button.sourceHat = sourceHat;
								num = 210588192;
								continue;
							case 0:
								button.sourceHatDirection = sourceHatDirection;
								button.sourceHatType = sourceHatType;
								num = 210588196;
								continue;
							case 4:
								return;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public int sourceHat;

				public AxisDirection sourceHatDirection;

				public HatType sourceHatType;

				public AxisRange sourceHatRange;

				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Axis axis = destination as Axis;
					while (true)
					{
						int num = 1722939236;
						while (true)
						{
							switch (num ^ 0x66B1F766)
							{
							case 0:
								break;
							case 2:
								if (axis != null)
								{
									goto IL_003b;
								}
								return;
							case 1:
								goto IL_003b;
							default:
								axis.sourceHatRange = sourceHatRange;
								return;
							}
							break;
							IL_003b:
							axis.sourceHat = sourceHat;
							axis.sourceHatDirection = sourceHatDirection;
							axis.sourceHatType = sourceHatType;
							num = 1722939237;
						}
					}
				}
			}

			private sealed class PLYBTPIqWJkkJPjOqZrJnkgAjUBz : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_InternalDriver_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int EsCRwApoDSnuRmwiYRfschLFBCQ;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
					{
						goto IL_0012;
					}
					goto IL_0072;
					IL_0012:
					int num = 1655566681;
					goto IL_0017;
					IL_0017:
					PLYBTPIqWJkkJPjOqZrJnkgAjUBz pLYBTPIqWJkkJPjOqZrJnkgAjUBz = default(PLYBTPIqWJkkJPjOqZrJnkgAjUBz);
					while (true)
					{
						switch (num ^ 0x62ADF15C)
						{
						case 0:
							break;
						case 5:
							goto IL_0040;
						case 2:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							num = 1655566687;
							continue;
						case 3:
							pLYBTPIqWJkkJPjOqZrJnkgAjUBz = this;
							num = 1655566685;
							continue;
						case 4:
							goto IL_0072;
						case 1:
							num = 1655566682;
							continue;
						default:
							return pLYBTPIqWJkkJPjOqZrJnkgAjUBz;
						}
						break;
						IL_0040:
						int num2;
						if (LzqgRXjFXvJPbHjfzyAmNfcqezXL != -2)
						{
							num = 1655566680;
							num2 = num;
						}
						else
						{
							num = 1655566686;
							num2 = num;
						}
					}
					goto IL_0012;
					IL_0072:
					pLYBTPIqWJkkJPjOqZrJnkgAjUBz = new PLYBTPIqWJkkJPjOqZrJnkgAjUBz(0);
					pLYBTPIqWJkkJPjOqZrJnkgAjUBz.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
					num = 1655566682;
					goto IL_0017;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
					while (true)
					{
						int num = 1238514858;
						while (true)
						{
							switch (num ^ 0x49D23CA9)
							{
							case 5:
								break;
							case 0:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes[EsCRwApoDSnuRmwiYRfschLFBCQ];
								num = 1238514861;
								continue;
							case 4:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							case 7:
							{
								int num2;
								if (EsCRwApoDSnuRmwiYRfschLFBCQ >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes.Length)
								{
									num = 1238514863;
									num2 = num;
								}
								else
								{
									num = 1238514857;
									num2 = num;
								}
								continue;
							}
							case 3:
								switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
								{
								case 1:
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
									EsCRwApoDSnuRmwiYRfschLFBCQ++;
									num = 1238514862;
									continue;
								default:
									num = 1238514856;
									continue;
								case 0:
									break;
								}
								goto case 2;
							case 2:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements != null && ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes != null)
								{
									EsCRwApoDSnuRmwiYRfschLFBCQ = 0;
									num = 1238514862;
									continue;
								}
								goto default;
							case 1:
								num = 1238514863;
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
				public PLYBTPIqWJkkJPjOqZrJnkgAjUBz(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class IypTQfhlaNkeAqEBdlLmcVofEtl : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_InternalDriver_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int fbdtoxOeayymfwhwxuCdNFiKFpsD;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						goto IL_001c;
					}
					goto IL_006b;
					IL_006b:
					IypTQfhlaNkeAqEBdlLmcVofEtl iypTQfhlaNkeAqEBdlLmcVofEtl = new IypTQfhlaNkeAqEBdlLmcVofEtl(0);
					int num = -1042212662;
					goto IL_0021;
					IL_001c:
					num = -1042212660;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ -1042212657)
						{
						case 6:
							break;
						case 3:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							num = -1042212659;
							continue;
						case 5:
							iypTQfhlaNkeAqEBdlLmcVofEtl.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
							num = -1042212657;
							continue;
						case 1:
							goto IL_006b;
						case 4:
							num = -1042212657;
							continue;
						case 2:
							iypTQfhlaNkeAqEBdlLmcVofEtl = this;
							num = -1042212661;
							continue;
						default:
							return iypTQfhlaNkeAqEBdlLmcVofEtl;
						}
						break;
					}
					goto IL_001c;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					int num3;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					default:
						num = 411907621;
						goto IL_001a;
					case 1:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						fbdtoxOeayymfwhwxuCdNFiKFpsD++;
						num = 411907619;
						goto IL_001a;
					case 0:
						goto IL_00c1;
						IL_001a:
						while (true)
						{
							switch (num ^ 0x188D3622)
							{
							case 2:
								break;
							case 4:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons[fbdtoxOeayymfwhwxuCdNFiKFpsD];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							case 0:
								num = 411907619;
								continue;
							case 1:
								goto IL_0093;
							case 5:
								goto IL_00c1;
							case 7:
								num = 411907617;
								continue;
							case 6:
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons != null)
								{
									fbdtoxOeayymfwhwxuCdNFiKFpsD = 0;
									num = 411907618;
									continue;
								}
								goto default;
							default:
								return false;
							}
							break;
							IL_0093:
							int num2;
							if (fbdtoxOeayymfwhwxuCdNFiKFpsD < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons.Length)
							{
								num = 411907622;
								num2 = num;
							}
							else
							{
								num = 411907617;
								num2 = num;
							}
						}
						goto default;
						IL_00c1:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements != null)
						{
							num = 411907620;
							num3 = num;
						}
						else
						{
							num = 411907617;
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
				public IypTQfhlaNkeAqEBdlLmcVofEtl(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			public override int assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			public override int assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.sstGbYqotnUAodZSsTwHEEbgiSR;
				}
			}

			internal override Platform_Custom.Axis[] Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = default(Axis[]);
						int num2 = default(int);
						while (true)
						{
							int num = 1384178435;
							while (true)
							{
								switch (num ^ 0x5280E300)
								{
								case 0:
									break;
								case 1:
									_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
									num2 = 0;
									num = 1384178434;
									continue;
								case 7:
									goto IL_0054;
								case 3:
									axes_orig = Axes_orig;
									num = 1384178438;
									continue;
								case 5:
									_axesOrigGame[num2] = axes_orig[num2];
									num2++;
									num = 1384178439;
									continue;
								case 6:
									goto IL_008f;
								case 2:
									num = 1384178439;
									continue;
								default:
									goto end_IL_000b;
								}
								break;
								IL_008f:
								int num3;
								if (axes_orig != null)
								{
									num = 1384178433;
									num3 = num;
								}
								else
								{
									num = 1384178436;
									num3 = num;
								}
								continue;
								IL_0054:
								int num4;
								if (num2 < axes_orig.Length)
								{
									num = 1384178437;
									num4 = num;
								}
								else
								{
									num = 1384178436;
									num4 = num;
								}
							}
							continue;
							end_IL_000b:
							break;
						}
					}
					return _axesOrigGame;
				}
			}

			internal override Platform_Custom.Button[] Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							int num2 = default(int);
							while (true)
							{
								int num = -1464363609;
								while (true)
								{
									switch (num ^ -1464363613)
									{
									case 0:
										break;
									case 1:
										num2++;
										num = -1464363610;
										continue;
									case 3:
										_buttonsOrigGame[num2] = buttons_orig[num2];
										num = -1464363614;
										continue;
									case 5:
										goto IL_0059;
									case 4:
										_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
										num2 = 0;
										num = -1464363610;
										continue;
									default:
										goto end_IL_0012;
									}
									break;
									IL_0059:
									int num3;
									if (num2 < buttons_orig.Length)
									{
										num = -1464363616;
										num3 = num;
									}
									else
									{
										num = -1464363615;
										num3 = num;
									}
								}
								continue;
								end_IL_0012:
								break;
							}
						}
					}
					return _buttonsOrigGame;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			internal override bool hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						goto IL_0008;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					int num;
					if (assignedButtonCount == 0)
					{
						num = -717390600;
						goto IL_000d;
					}
					goto IL_005b;
					IL_0008:
					num = -717390597;
					goto IL_000d;
					IL_000d:
					while (true)
					{
						switch (num ^ -717390600)
						{
						case 2:
							break;
						case 3:
							return false;
						case 0:
							goto IL_004a;
						default:
							return false;
						}
						break;
						IL_004a:
						if (assignedAxisCount == 0)
						{
							num = -717390599;
							continue;
						}
						goto IL_005b;
					}
					goto IL_0008;
					IL_005b:
					return true;
				}
			}

			internal override bool disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			internal override bool isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal override Elements_Base elements_base
			{
				get
				{
					return elements;
				}
			}

			internal override IList<Platform> variants_base
			{
				get
				{
					return null;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					while (true)
					{
						int num = 81685808;
						while (true)
						{
							switch (num ^ 0x4DE6D32)
							{
							case 0:
								break;
							case 2:
								goto IL_003c;
							default:
								return true;
							}
							break;
							IL_003c:
							platformMap = this;
							num = 81685811;
						}
					}
				}
				return false;
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				PLYBTPIqWJkkJPjOqZrJnkgAjUBz pLYBTPIqWJkkJPjOqZrJnkgAjUBz = new PLYBTPIqWJkkJPjOqZrJnkgAjUBz(-2);
				pLYBTPIqWJkkJPjOqZrJnkgAjUBz.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return pLYBTPIqWJkkJPjOqZrJnkgAjUBz;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				IypTQfhlaNkeAqEBdlLmcVofEtl iypTQfhlaNkeAqEBdlLmcVofEtl = new IypTQfhlaNkeAqEBdlLmcVofEtl(-2);
				iypTQfhlaNkeAqEBdlLmcVofEtl.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return iypTQfhlaNkeAqEBdlLmcVofEtl;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				int num3 = default(int);
				int elementIdentifier = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = -179836900;
					while (true)
					{
						switch (num ^ -179836897)
						{
						case 5:
							break;
						case 1:
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num = -179836901;
							continue;
						case 2:
							num2++;
							num = -179836897;
							continue;
						case 7:
							Logger.LogError("Element identifier index is out of bounds!");
							num = -179836899;
							continue;
						case 4:
							if (num3 >= 0)
							{
								int num4;
								if (num3 < identifiers.Length)
								{
									num = -179836905;
									num4 = num;
								}
								else
								{
									num = -179836904;
									num4 = num;
								}
								continue;
							}
							goto case 7;
						case 3:
							num2 = 0;
							num = -179836897;
							continue;
						case 6:
							elementIdentifier = elements.axes[num2].elementIdentifier;
							num = -179836898;
							continue;
						case 8:
							array[num2] = identifiers[num3].name;
							num = -179836899;
							continue;
						default:
							if (num2 >= array.Length)
							{
								return array;
							}
							goto case 6;
						}
						break;
					}
				}
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				if (identifiers.Length < buttonCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[buttonCount];
				int num = 0;
				while (num < array.Length)
				{
					while (true)
					{
						int elementIdentifier = elements.buttons[num].elementIdentifier;
						int num2 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						int num3 = -718887606;
						while (true)
						{
							switch (num3 ^ -718887601)
							{
							case 4:
								num3 = -718887602;
								continue;
							case 1:
								break;
							case 0:
								Logger.LogError("Element identifier index is out of bounds!");
								num3 = -718887603;
								continue;
							case 2:
								num3 = -718887604;
								continue;
							case 7:
								array[num] = identifiers[num2].name;
								num3 = -718887604;
								continue;
							case 5:
								if (num2 < 0)
								{
									goto case 0;
								}
								goto IL_00b7;
							case 3:
								num++;
								num3 = -718887607;
								continue;
							default:
								goto end_IL_0063;
							}
							break;
							IL_00b7:
							int num4;
							if (num2 >= identifiers.Length)
							{
								num3 = -718887601;
								num4 = num3;
							}
							else
							{
								num3 = -718887608;
								num4 = num3;
							}
						}
						continue;
						end_IL_0063:
						break;
					}
				}
				return array;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				IEnumerator<Platform_Custom.Axis> enumerator = IterateAxes().GetEnumerator();
				bool result = default(bool);
				try
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator.Current;
							int num = 1553398452;
							while (true)
							{
								switch (num ^ 0x5C96FAB0)
								{
								case 0:
									num = 1553398451;
									continue;
								case 3:
									break;
								case 4:
									if (axis.elementIdentifier == elementIdentifierId)
									{
										result = true;
										num = 1553398450;
										continue;
									}
									goto end_IL_0034;
								default:
									goto end_IL_0034;
								case 2:
									goto IL_0125;
								}
								break;
							}
							continue;
							end_IL_0034:
							break;
						}
					}
				}
				finally
				{
					if (enumerator != null)
					{
						while (true)
						{
							IL_0072:
							int num2 = 1553398449;
							while (true)
							{
								switch (num2 ^ 0x5C96FAB0)
								{
								case 2:
									break;
								default:
									goto end_IL_0077;
								case 1:
									goto IL_0090;
								case 0:
									goto end_IL_0077;
								}
								goto IL_0072;
								IL_0090:
								enumerator.Dispose();
								num2 = 1553398448;
								continue;
								end_IL_0077:
								break;
							}
							break;
						}
					}
				}
				using (IEnumerator<Platform_Custom.Button> enumerator2 = IterateButtons().GetEnumerator())
				{
					Button button = default(Button);
					while (true)
					{
						IL_00fb:
						int num3;
						int num4;
						if (enumerator2.MoveNext())
						{
							num3 = 1553398450;
							num4 = num3;
						}
						else
						{
							num3 = 1553398451;
							num4 = num3;
						}
						while (true)
						{
							switch (num3 ^ 0x5C96FAB0)
							{
							case 4:
								num3 = 1553398450;
								continue;
							default:
								goto end_IL_00b2;
							case 2:
								button = (Button)enumerator2.Current;
								num3 = 1553398449;
								continue;
							case 1:
								if (button.elementIdentifier != elementIdentifierId)
								{
									break;
								}
								result = true;
								goto IL_0125;
							case 0:
								break;
							case 3:
								goto end_IL_00b2;
							}
							goto IL_00fb;
							continue;
							end_IL_00b2:
							break;
						}
						break;
					}
				}
				return false;
				IL_0125:
				return result;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				using (IEnumerator<Platform_Custom.Button> enumerator = IterateButtons().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Button button = (Button)enumerator.Current;
							buttons[num] = button.elementIdentifier;
							num++;
							int num2 = -2081492796;
							while (true)
							{
								switch (num2 ^ -2081492796)
								{
								case 2:
									num2 = -2081492795;
									continue;
								case 1:
									break;
								default:
									goto end_IL_0048;
								}
								break;
							}
							continue;
							end_IL_0048:
							break;
						}
					}
				}
				num = 0;
				using (IEnumerator<Platform_Custom.Axis> enumerator2 = IterateAxes().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator2.Current;
							axes[num] = axis.elementIdentifier;
							num++;
							int num3 = -2081492796;
							while (true)
							{
								switch (num3 ^ -2081492796)
								{
								case 2:
									num3 = -2081492795;
									continue;
								case 1:
									break;
								default:
									goto end_IL_00ac;
								}
								break;
							}
							continue;
							end_IL_00ac:
							break;
						}
					}
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				AxisCalibrationData[] array = default(AxisCalibrationData[]);
				int num2 = default(int);
				while (true)
				{
					int num = -382029223;
					while (true)
					{
						switch (num ^ -382029224)
						{
						case 7:
							break;
						case 0:
							array[num2].max = axes_orig[num2].axisMax;
							num = -382029219;
							continue;
						case 11:
							array[num2] = AxisCalibrationData.Default;
							num = -382029222;
							continue;
						case 10:
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							if (Axes_orig[num2].calibrateAxis)
							{
								array[num2].zero = axes_orig[num2].axisZero;
								array[num2].min = axes_orig[num2].axisMin;
								num = -382029224;
								continue;
							}
							goto case 6;
						case 9:
							throw new NotImplementedException();
						case 1:
							if (axes_orig == null)
							{
								return null;
							}
							array = new AxisCalibrationData[axes_orig.Length];
							num2 = 0;
							num = -382029221;
							continue;
						case 8:
							array[num2] = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							num = -382029230;
							continue;
						case 2:
							num = -382029218;
							continue;
						case 12:
							if (axes_orig[num2].sourceType != 1)
							{
								int num4;
								if (axes_orig[num2].sourceType != 100)
								{
									num = -382029220;
									num4 = num;
								}
								else
								{
									num = -382029232;
									num4 = num;
								}
								continue;
							}
							goto case 8;
						case 6:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num2++;
							num = -382029221;
							continue;
						case 5:
							num = -382029218;
							continue;
						case 4:
							if (axes_orig[num2].sourceType != 0)
							{
								int num3;
								if (axes_orig[num2].sourceType == 2)
								{
									num = -382029229;
									num3 = num;
								}
								else
								{
									num = -382029231;
									num3 = num;
								}
								continue;
							}
							goto case 11;
						default:
							if (num2 >= axes_orig.Length)
							{
								return array;
							}
							goto case 12;
						}
						break;
					}
				}
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				int num2 = default(int);
				while (true)
				{
					axisRanges = new AxisRange[Axes_orig.Length];
					axisInfos = new HardwareAxisInfo[Axes_orig.Length];
					int num = 1501057473;
					while (true)
					{
						switch (num ^ 0x597851C1)
						{
						case 10:
							num = 1501057482;
							continue;
						case 6:
							num = 1501057480;
							continue;
						case 4:
						{
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							int num5;
							if (Axes_orig[num2].sourceType != 1)
							{
								num = 1501057476;
								num5 = num;
							}
							else
							{
								num = 1501057475;
								num5 = num;
							}
							continue;
						}
						case 11:
							break;
						case 0:
							num2 = 0;
							num = 1501057478;
							continue;
						case 9:
							num2++;
							num = 1501057485;
							continue;
						case 2:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = 1501057479;
							continue;
						case 8:
							if (Axes_orig[num2].sourceType != 0)
							{
								int num4;
								if (Axes_orig[num2].sourceType != 2)
								{
									num = 1501057474;
									num4 = num;
								}
								else
								{
									num = 1501057472;
									num4 = num;
								}
								continue;
							}
							goto case 1;
						case 3:
							throw new Exception();
						case 7:
							num = 1501057485;
							continue;
						case 5:
						{
							int num3;
							if (Axes_orig[num2].sourceType != 100)
							{
								num = 1501057481;
								num3 = num;
							}
							else
							{
								num = 1501057475;
								num3 = num;
							}
							continue;
						}
						case 1:
							axisRanges[num2] = AxisRange.Full;
							num = 1501057480;
							continue;
						default:
							if (num2 >= Axes_orig.Length)
							{
								return;
							}
							goto case 4;
						}
						break;
					}
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig == null)
				{
					return;
				}
				while (true)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					int num = 0;
					int num2 = -1656896512;
					while (true)
					{
						switch (num2 ^ -1656896507)
						{
						case 3:
							num2 = -1656896505;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
							buttonInfos[num] = MiscTools.DeepClone(Buttons_orig[num].buttonInfo, true);
							num2 = -1656896507;
							continue;
						case 0:
							num++;
							num2 = -1656896512;
							continue;
						case 5:
						{
							int num3;
							if (num >= Buttons_orig.Length)
							{
								num2 = -1656896511;
								num3 = num2;
							}
							else
							{
								num2 = -1656896508;
								num3 = num2;
							}
							continue;
						}
						case 4:
							return;
						}
						break;
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_InternalDriver_Base platform_InternalDriver_Base = new Platform_InternalDriver_Base();
				CopyVars(platform_InternalDriver_Base);
				return platform_InternalDriver_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_InternalDriver_Base platform_InternalDriver_Base = destination as Platform_InternalDriver_Base;
				if (platform_InternalDriver_Base == null)
				{
					return;
				}
				while (true)
				{
					platform_InternalDriver_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					int num = 160357745;
					while (true)
					{
						switch (num ^ 0x98EDD70)
						{
						case 0:
							goto IL_0012;
						case 2:
							break;
						default:
							platform_InternalDriver_Base.elements = MiscTools.DeepClone(elements);
							return;
						}
						break;
						IL_0012:
						num = 160357746;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_InternalDriver : Platform_InternalDriver_Base
		{
			public Platform_InternalDriver_Base[] variants;

			internal override IList<Platform> variants_base
			{
				get
				{
					return variants;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					goto IL_000d;
				}
				int num = default(int);
				int num2;
				if (base.hasVariants)
				{
					num = 0;
					num2 = -387843919;
					goto IL_0012;
				}
				goto IL_00a2;
				IL_0012:
				while (true)
				{
					switch (num2 ^ -387843920)
					{
					case 3:
						break;
					case 5:
						return true;
					case 2:
						goto IL_004a;
					case 0:
						goto IL_0066;
					case 1:
						num2 = -387843918;
						continue;
					default:
						goto IL_00a2;
					}
					break;
					IL_0066:
					int variantIndex2;
					if (variants[num] != null && variants[num].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
					{
						variantIndex = num;
						return true;
					}
					num++;
					num2 = -387843918;
					continue;
					IL_004a:
					int num3;
					if (num >= variants.Length)
					{
						num2 = -387843916;
						num3 = num2;
					}
					else
					{
						num2 = -387843920;
						num3 = num2;
					}
				}
				goto IL_000d;
				IL_00a2:
				return false;
				IL_000d:
				num2 = -387843915;
				goto IL_0012;
			}

			public override object DeepClone()
			{
				Platform_InternalDriver platform_InternalDriver = new Platform_InternalDriver();
				CopyVars(platform_InternalDriver);
				return platform_InternalDriver;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_InternalDriver platform_InternalDriver = destination as Platform_InternalDriver;
				if (platform_InternalDriver != null)
				{
					platform_InternalDriver.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_SDL2_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				[Serializable]
				public sealed class ElementCount : ElementCount_Base
				{
					public int hatCount;

					public override object DeepClone()
					{
						ElementCount elementCount = new ElementCount();
						CopyVars(elementCount);
						return elementCount;
					}

					internal override void CopyVars(ElementCount_Base P_0)
					{
						base.CopyVars(P_0);
						ElementCount elementCount = default(ElementCount);
						while (true)
						{
							int num = 715214529;
							while (true)
							{
								switch (num ^ 0x2AA14EC2)
								{
								case 0:
									break;
								default:
									return;
								case 3:
									elementCount = P_0 as ElementCount;
									if (elementCount != null)
									{
										goto IL_003b;
									}
									return;
								case 2:
									goto IL_003b;
								case 1:
									return;
								}
								break;
								IL_003b:
								elementCount.hatCount = hatCount;
								num = 715214531;
							}
						}
					}

					internal override bool Matches(BridgedControllerHWInfo P_0)
					{
						if (!base.Matches(P_0))
						{
							return false;
						}
						if (hatCount >= 0)
						{
							return hatCount == P_0.hardwareHatCount;
						}
						return true;
					}
				}

				public int hatCount;

				public bool manufacturer_useRegex;

				public bool productName_useRegex;

				public bool systemName_useRegex;

				public string[] manufacturer;

				public string[] productName;

				public string[] systemName;

				public string[] productGUID;

				internal override bool hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (productGUID != null && productGUID.Length > 0)
						{
							return true;
						}
						if (productName != null && productName.Length > 0)
						{
							return true;
						}
						return false;
					}
				}

				internal override bool isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						return true;
					}
				}

				internal override int alternateElementCount
				{
					get
					{
						return 0;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						goto IL_0018;
					}
					int num;
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						num = -361743930;
					}
					else
					{
						if (!strictMatch)
						{
							return AnyNameMatches(bridgedControllerHWInfo);
						}
						if (!PidVid.ArrayContains(productGUID, ref bridgedControllerHWInfo.hw_pidVid))
						{
							goto IL_0092;
						}
						num = -361743935;
					}
					goto IL_001d;
					IL_001d:
					while (true)
					{
						switch (num ^ -361743933)
						{
						case 6:
							break;
						case 1:
							return true;
						case 5:
							return false;
						case 7:
							goto IL_007f;
						case 4:
							return true;
						case 3:
							return true;
						case 2:
							goto IL_00c3;
						default:
							return false;
						}
						break;
						IL_00c3:
						if (ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
						{
							int num2;
							if (productName != null)
							{
								num = -361743932;
								num2 = num;
							}
							else
							{
								num = -361743929;
								num2 = num;
							}
						}
						else
						{
							num = -361743936;
						}
						continue;
						IL_007f:
						if (productName.Length == 0)
						{
							num = -361743929;
							continue;
						}
						goto IL_0092;
					}
					goto IL_0018;
					IL_0018:
					num = -361743934;
					goto IL_001d;
					IL_0092:
					if (!AnyNameMatches(bridgedControllerHWInfo))
					{
						num = -361743933;
						goto IL_001d;
					}
					return true;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						return false;
					}
					if (alternateMatched)
					{
						return true;
					}
					if (hatCount >= 0)
					{
						return bridgedControllerHWInfo.hardwareHatCount == hatCount;
					}
					return true;
				}

				private bool AnyNameMatches(BridgedControllerHWInfo bridgedControllerHWInfo)
				{
					if (NameMatches(bridgedControllerHWInfo.hw_productName, productName, productName_useRegex))
					{
						return true;
					}
					if (NameMatches(bridgedControllerHWInfo.hw_systemDeviceName, systemName, systemName_useRegex))
					{
						return true;
					}
					return false;
				}

				private bool NameMatches(string name, string[] names, bool useRegex)
				{
					if (!string.IsNullOrEmpty(name))
					{
						int num2 = default(int);
						string searchIn = default(string);
						while (true)
						{
							int num = 953699773;
							while (true)
							{
								switch (num ^ 0x38D84DBC)
								{
								case 0:
									break;
								case 1:
									goto IL_003a;
								case 3:
									return true;
								case 7:
									goto end_IL_0008;
								case 6:
									goto IL_0061;
								case 4:
									num2 = 0;
									num = 953699769;
									continue;
								case 5:
									num = 953699774;
									continue;
								default:
									if (num2 >= names.Length)
									{
										return false;
									}
									goto IL_0061;
								}
								break;
								IL_0061:
								if (string.IsNullOrEmpty(names[num2]) || !MatchingCriteria_Base.StringMatches(searchIn, names[num2], useRegex))
								{
									num2++;
									num = 953699774;
								}
								else
								{
									num = 953699775;
								}
								continue;
								IL_003a:
								if (names == null)
								{
									num = 953699771;
									continue;
								}
								searchIn = name.Trim();
								num = 953699768;
							}
							continue;
							end_IL_0008:
							break;
						}
					}
					return false;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					MatchingCriteria matchingCriteria = destination as MatchingCriteria;
					if (matchingCriteria == null)
					{
						return;
					}
					while (true)
					{
						matchingCriteria.hatCount = hatCount;
						int num = -2050242107;
						while (true)
						{
							switch (num ^ -2050242112)
							{
							case 4:
								num = -2050242111;
								continue;
							case 1:
								break;
							case 0:
								matchingCriteria.systemName_useRegex = systemName_useRegex;
								matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
								num = -2050242109;
								continue;
							case 5:
								matchingCriteria.manufacturer_useRegex = manufacturer_useRegex;
								num = -2050242110;
								continue;
							case 2:
								matchingCriteria.productName_useRegex = productName_useRegex;
								num = -2050242112;
								continue;
							default:
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								matchingCriteria.systemName = ArrayTools.ShallowCopy(systemName);
								matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
								return;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class dZytMXeRgchMeqlUJaHjgdUNvlm : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
				{
					private Axis RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public Elements ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public int sRlUHYVYIenTtjplcEeHuxDZOGn;

					Axis IEnumerator<Axis>.Current
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
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
						{
							goto IL_0012;
						}
						goto IL_0059;
						IL_0012:
						int num = 1873956703;
						goto IL_0017;
						IL_0017:
						dZytMXeRgchMeqlUJaHjgdUNvlm dZytMXeRgchMeqlUJaHjgdUNvlm2 = default(dZytMXeRgchMeqlUJaHjgdUNvlm);
						while (true)
						{
							switch (num ^ 0x6FB24F5E)
							{
							case 4:
								break;
							case 1:
								if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
								{
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
									dZytMXeRgchMeqlUJaHjgdUNvlm2 = this;
									num = 1873956701;
									continue;
								}
								goto IL_0059;
							case 3:
								num = 1873956702;
								continue;
							case 2:
								goto IL_0059;
							default:
								return dZytMXeRgchMeqlUJaHjgdUNvlm2;
							}
							break;
						}
						goto IL_0012;
						IL_0059:
						dZytMXeRgchMeqlUJaHjgdUNvlm2 = new dZytMXeRgchMeqlUJaHjgdUNvlm(0);
						dZytMXeRgchMeqlUJaHjgdUNvlm2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = 1873956702;
						goto IL_0017;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int num;
						switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						default:
							num = 1939591546;
							goto IL_001a;
						case 1:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							num = 1939591536;
							goto IL_001a;
						case 0:
							goto IL_00e4;
							IL_001a:
							while (true)
							{
								switch (num ^ 0x739BD178)
								{
								case 10:
									break;
								case 9:
									goto IL_0056;
								case 8:
									sRlUHYVYIenTtjplcEeHuxDZOGn++;
									num = 1939591545;
									continue;
								case 2:
									num = 1939591548;
									continue;
								case 0:
									num = 1939591545;
									continue;
								case 1:
									goto IL_0097;
								case 6:
									return true;
								case 7:
									sRlUHYVYIenTtjplcEeHuxDZOGn = 0;
									num = 1939591544;
									continue;
								case 3:
									goto IL_00e4;
								case 5:
									RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.axes[sRlUHYVYIenTtjplcEeHuxDZOGn];
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
									num = 1939591550;
									continue;
								default:
									return false;
								}
								break;
								IL_0097:
								int num2;
								if (sRlUHYVYIenTtjplcEeHuxDZOGn < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.axes.Length)
								{
									num = 1939591549;
									num2 = num;
								}
								else
								{
									num = 1939591548;
									num2 = num;
								}
								continue;
								IL_0056:
								int num3;
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.axes != null)
								{
									num = 1939591551;
									num3 = num;
								}
								else
								{
									num = 1939591548;
									num3 = num;
								}
							}
							goto default;
							IL_00e4:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							num = 1939591537;
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
					public dZytMXeRgchMeqlUJaHjgdUNvlm(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class RetqZaFKlFBlxjkNHIqhbqwKafYQ : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerable, IEnumerator<Button>
				{
					private Button RDkWcsTpvDaNZojjIZONnoEBXPC;

					private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

					private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

					public Elements ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

					public int uMLGJtCNxCeellrBbHehjClMimfA;

					Button IEnumerator<Button>.Current
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
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							goto IL_0023;
						}
						goto IL_0059;
						IL_0028:
						int num;
						RetqZaFKlFBlxjkNHIqhbqwKafYQ retqZaFKlFBlxjkNHIqhbqwKafYQ = default(RetqZaFKlFBlxjkNHIqhbqwKafYQ);
						while (true)
						{
							switch (num ^ -1824073488)
							{
							case 2:
								break;
							case 1:
								retqZaFKlFBlxjkNHIqhbqwKafYQ = this;
								num = -1824073484;
								continue;
							case 4:
								num = -1824073488;
								continue;
							case 3:
								goto IL_0059;
							default:
								return retqZaFKlFBlxjkNHIqhbqwKafYQ;
							}
							break;
						}
						goto IL_0023;
						IL_0059:
						retqZaFKlFBlxjkNHIqhbqwKafYQ = new RetqZaFKlFBlxjkNHIqhbqwKafYQ(0);
						retqZaFKlFBlxjkNHIqhbqwKafYQ.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = -1824073488;
						goto IL_0028;
						IL_0023:
						num = -1824073487;
						goto IL_0028;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
						while (true)
						{
							int num = -623201684;
							while (true)
							{
								switch (num ^ -623201682)
								{
								case 0:
									break;
								case 6:
								{
									int num2;
									if (uMLGJtCNxCeellrBbHehjClMimfA >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttons.Length)
									{
										num = -623201681;
										num2 = num;
									}
									else
									{
										num = -623201686;
										num2 = num;
									}
									continue;
								}
								case 5:
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
									num = -623201683;
									continue;
								case 4:
									RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttons[uMLGJtCNxCeellrBbHehjClMimfA];
									LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
									return true;
								case 3:
									if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.buttons != null)
									{
										uMLGJtCNxCeellrBbHehjClMimfA = 0;
										num = -623201688;
										continue;
									}
									goto default;
								case 2:
									switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
									{
									case 0:
										break;
									case 1:
										LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
										uMLGJtCNxCeellrBbHehjClMimfA++;
										num = -623201688;
										continue;
									default:
										num = -623201681;
										continue;
									}
									goto case 5;
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
					public RetqZaFKlFBlxjkNHIqhbqwKafYQ(int _003C_003E1__state)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				public override int axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal IEnumerable<Axis> Axes
				{
					get
					{
						dZytMXeRgchMeqlUJaHjgdUNvlm dZytMXeRgchMeqlUJaHjgdUNvlm2 = new dZytMXeRgchMeqlUJaHjgdUNvlm(-2);
						dZytMXeRgchMeqlUJaHjgdUNvlm2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
						return dZytMXeRgchMeqlUJaHjgdUNvlm2;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					get
					{
						RetqZaFKlFBlxjkNHIqhbqwKafYQ retqZaFKlFBlxjkNHIqhbqwKafYQ = new RetqZaFKlFBlxjkNHIqhbqwKafYQ(-2);
						retqZaFKlFBlxjkNHIqhbqwKafYQ.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
						return retqZaFKlFBlxjkNHIqhbqwKafYQ;
					}
				}

				internal Axis GetAxis(int axisIndex)
				{
					if (axes == null || axisIndex < 0 || axisIndex >= axes.Length)
					{
						return null;
					}
					return axes[axisIndex];
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					int num = 0;
					int num2 = default(int);
					while (true)
					{
						IL_0068:
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = 906763817;
							goto IL_0009;
						}
						goto IL_0032;
						IL_0009:
						while (true)
						{
							switch (num3 ^ 0x360C1E2C)
							{
							case 2:
								num3 = 906763816;
								continue;
							case 4:
								break;
							case 5:
								num3 = 906763823;
								continue;
							case 6:
								return ControllerElementType.Button;
							case 0:
								goto IL_0068;
							case 1:
								goto IL_007a;
							default:
								if (num2 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								goto IL_007a;
							}
							break;
							IL_007a:
							if (buttons[num2].elementIdentifier != elementIdentifier.id)
							{
								num2++;
								num3 = 906763823;
							}
							else
							{
								num3 = 906763818;
							}
						}
						goto IL_0032;
						IL_0032:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							break;
						}
						num++;
						num3 = 906763820;
						goto IL_0009;
					}
					return ControllerElementType.Axis;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					while (true)
					{
						IL_0088:
						int num2;
						if (num >= axisCount)
						{
							axisRange = AxisRange.Full;
							num2 = 1947501208;
							goto IL_000c;
						}
						goto IL_0044;
						IL_000c:
						while (true)
						{
							switch (num2 ^ 0x7414829C)
							{
							case 3:
								num2 = 1947501209;
								continue;
							case 5:
								break;
							case 6:
								goto IL_0088;
							case 7:
								return true;
							case 8:
								return true;
							case 0:
								goto end_IL_0088;
							case 9:
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 1947501204;
									continue;
								}
								goto case 8;
							case 1:
								goto IL_0114;
							case 2:
								goto IL_0122;
							default:
								return false;
							}
							break;
						}
						goto IL_0044;
						IL_0044:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							switch (axes[num].sourceType)
							{
							case HardwareElementSourceTypeWithHat.Custom:
								break;
							case HardwareElementSourceTypeWithHat.Hat:
								goto IL_00a0;
							case HardwareElementSourceTypeWithHat.Button:
								goto IL_00d3;
							default:
								throw new NotImplementedException();
							case HardwareElementSourceTypeWithHat.Axis:
								goto IL_0122;
							}
							num2 = 1947501214;
							goto IL_000c;
						}
						goto IL_0114;
						IL_0114:
						num++;
						num2 = 1947501210;
						goto IL_000c;
						IL_00d3:
						axisRange = AxisRange.Positive;
						num2 = 1947501211;
						goto IL_000c;
						IL_00a0:
						axisRange = axes[num].sourceHatRange;
						if (!axes[num].invert)
						{
							break;
						}
						axisRange = InputTools.InvertAxisRange(axisRange);
						num2 = 1947501212;
						goto IL_000c;
						IL_0122:
						axisRange = axes[num].sourceAxisRange;
						num2 = 1947501205;
						goto IL_000c;
						continue;
						end_IL_0088:
						break;
					}
					return true;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					Elements elements = destination as Elements;
					if (elements == null)
					{
						while (true)
						{
							switch (-1996560819 ^ -1996560820)
							{
							case 0:
								continue;
							case 1:
								return;
							}
							break;
						}
					}
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class Element : IDeepCloneable
			{
				public abstract object DeepClone();

				protected virtual void ImportVars(Element source)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class Button : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceButton;

				public int sourceAxis;

				public Pole sourceAxisPole;

				public float axisDeadZone;

				public int sourceHat;

				public HatType sourceHatType;

				public HatDirection sourceHatDirection;

				public bool requireMultipleButtons;

				public int[] requiredButtons;

				public bool ignoreIfButtonsActive;

				public int[] ignoreIfButtonsActiveButtons;

				public HardwareButtonInfo buttonInfo;

				public Button()
				{
					sourceType = HardwareElementSourceTypeWithHat.Button;
				}

				public override object DeepClone()
				{
					Button button = new Button();
					button.ImportVars(this);
					return button;
				}

				protected override void ImportVars(Element source)
				{
					base.ImportVars(source);
					Button button = source as Button;
					if (button == null)
					{
						return;
					}
					while (true)
					{
						elementIdentifier = button.elementIdentifier;
						sourceType = button.sourceType;
						sourceButton = button.sourceButton;
						sourceAxis = button.sourceAxis;
						sourceAxisPole = button.sourceAxisPole;
						axisDeadZone = button.axisDeadZone;
						sourceHat = button.sourceHat;
						sourceHatType = button.sourceHatType;
						int num = -1315214958;
						while (true)
						{
							switch (num ^ -1315214957)
							{
							case 5:
								num = -1315214953;
								continue;
							case 2:
								ignoreIfButtonsActive = button.ignoreIfButtonsActive;
								num = -1315214957;
								continue;
							case 1:
								sourceHatDirection = button.sourceHatDirection;
								requireMultipleButtons = button.requireMultipleButtons;
								num = -1315214960;
								continue;
							case 3:
								requiredButtons = ArrayTools.ShallowCopy(button.requiredButtons);
								num = -1315214959;
								continue;
							case 4:
								break;
							default:
								ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(button.ignoreIfButtonsActiveButtons);
								buttonInfo = MiscTools.DeepClone(button.buttonInfo);
								return;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public class Axis : Element
			{
				public int elementIdentifier;

				public HardwareElementSourceTypeWithHat sourceType;

				public int sourceAxis;

				public AxisRange sourceAxisRange;

				public bool invert;

				public float axisDeadZone;

				public bool calibrateAxis;

				public float axisZero;

				public float axisMin;

				public float axisMax;

				public AxisCalibrationInfoEntry[] alternateCalibrations;

				public HardwareAxisInfo axisInfo;

				public int sourceButton;

				public Pole buttonAxisContribution;

				public int sourceHat;

				public AxisDirection sourceHatDirection;

				public AxisRange sourceHatRange;

				public Axis()
				{
					sourceType = HardwareElementSourceTypeWithHat.Axis;
				}

				public override object DeepClone()
				{
					Axis axis = new Axis();
					axis.ImportVars(this);
					return axis;
				}

				protected override void ImportVars(Element source)
				{
					base.ImportVars(source);
					Axis axis = default(Axis);
					while (true)
					{
						int num = -1030476256;
						while (true)
						{
							switch (num ^ -1030476252)
							{
							case 3:
								break;
							case 0:
								sourceType = axis.sourceType;
								sourceAxis = axis.sourceAxis;
								sourceAxisRange = axis.sourceAxisRange;
								invert = axis.invert;
								axisDeadZone = axis.axisDeadZone;
								calibrateAxis = axis.calibrateAxis;
								axisZero = axis.axisZero;
								axisMin = axis.axisMin;
								num = -1030476254;
								continue;
							case 1:
								sourceHatDirection = axis.sourceHatDirection;
								num = -1030476250;
								continue;
							case 4:
								axis = source as Axis;
								if (axis == null)
								{
									return;
								}
								goto case 5;
							case 6:
								axisMax = axis.axisMax;
								axisInfo = MiscTools.DeepClone(axis.axisInfo);
								sourceButton = axis.sourceButton;
								buttonAxisContribution = axis.buttonAxisContribution;
								sourceHat = axis.sourceHat;
								num = -1030476251;
								continue;
							case 5:
								elementIdentifier = axis.elementIdentifier;
								num = -1030476252;
								continue;
							default:
								sourceHatRange = axis.sourceHatRange;
								alternateCalibrations = MiscTools.DeepClone(axis.alternateCalibrations);
								return;
							}
							break;
						}
					}
				}
			}

			private sealed class DIteTKtGSHsPpbGvwgxaGKnlqRsi : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_SDL2_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int BxCtRVWKiNIcmTqUmmsOxVPIErk;

				public int mqMTudncpxHikCFNZRzlThKRqhbG;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						goto IL_001c;
					}
					goto IL_0046;
					IL_0046:
					DIteTKtGSHsPpbGvwgxaGKnlqRsi dIteTKtGSHsPpbGvwgxaGKnlqRsi = new DIteTKtGSHsPpbGvwgxaGKnlqRsi(0);
					int num = -1123197419;
					goto IL_0021;
					IL_001c:
					num = -1123197422;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ -1123197424)
						{
						case 0:
							break;
						case 1:
							goto IL_0046;
						case 4:
							num = -1123197421;
							continue;
						case 5:
							dIteTKtGSHsPpbGvwgxaGKnlqRsi.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
							num = -1123197421;
							continue;
						case 2:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							dIteTKtGSHsPpbGvwgxaGKnlqRsi = this;
							num = -1123197420;
							continue;
						default:
							return dIteTKtGSHsPpbGvwgxaGKnlqRsi;
						}
						break;
					}
					goto IL_001c;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 1:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						mqMTudncpxHikCFNZRzlThKRqhbG++;
						num = -1270092936;
						goto IL_001f;
					case 0:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements == null)
							{
								break;
							}
							int num3;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes != null)
							{
								num = -1270092933;
								num3 = num;
							}
							else
							{
								num = -1270092929;
								num3 = num;
							}
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -1270092931)
							{
							case 4:
								num = -1270092932;
								continue;
							case 0:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							case 6:
								BxCtRVWKiNIcmTqUmmsOxVPIErk = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes.Length;
								mqMTudncpxHikCFNZRzlThKRqhbG = 0;
								num = -1270092936;
								continue;
							case 3:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes[mqMTudncpxHikCFNZRzlThKRqhbG];
								num = -1270092931;
								continue;
							case 5:
								break;
							case 1:
								goto end_IL_001f;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (mqMTudncpxHikCFNZRzlThKRqhbG >= BxCtRVWKiNIcmTqUmmsOxVPIErk)
							{
								num = -1270092929;
								num2 = num;
							}
							else
							{
								num = -1270092930;
								num2 = num;
							}
							continue;
							end_IL_001f:
							break;
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
				public DIteTKtGSHsPpbGvwgxaGKnlqRsi(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class trSvZccixerNpKDAhYEoISSHiEE : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerable, IEnumerator<Button>
			{
				private Button RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_SDL2_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int OJAiHPYagrRiBMLNDTiAgxMpnSm;

				public int AtUtpwPqTODMYBMydNAGQLlgwMy;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						goto IL_0023;
					}
					goto IL_0052;
					IL_0028:
					int num;
					trSvZccixerNpKDAhYEoISSHiEE trSvZccixerNpKDAhYEoISSHiEE2 = default(trSvZccixerNpKDAhYEoISSHiEE);
					while (true)
					{
						switch (num ^ -1113236128)
						{
						case 4:
							break;
						case 3:
							trSvZccixerNpKDAhYEoISSHiEE2 = this;
							num = -1113236128;
							continue;
						case 1:
							goto IL_0052;
						case 0:
							num = -1113236126;
							continue;
						default:
							return trSvZccixerNpKDAhYEoISSHiEE2;
						}
						break;
					}
					goto IL_0023;
					IL_0052:
					trSvZccixerNpKDAhYEoISSHiEE2 = new trSvZccixerNpKDAhYEoISSHiEE(0);
					trSvZccixerNpKDAhYEoISSHiEE2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
					num = -1113236126;
					goto IL_0028;
					IL_0023:
					num = -1113236125;
					goto IL_0028;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 1:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						AtUtpwPqTODMYBMydNAGQLlgwMy++;
						num = -482080644;
						goto IL_001f;
					case 0:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements == null)
							{
								break;
							}
							int num3;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons == null)
							{
								num = -482080645;
								num3 = num;
							}
							else
							{
								num = -482080643;
								num3 = num;
							}
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -482080643)
							{
							case 3:
								num = -482080647;
								continue;
							case 2:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons[AtUtpwPqTODMYBMydNAGQLlgwMy];
								num = -482080646;
								continue;
							case 0:
								OJAiHPYagrRiBMLNDTiAgxMpnSm = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons.Length;
								AtUtpwPqTODMYBMydNAGQLlgwMy = 0;
								num = -482080644;
								continue;
							case 5:
								return true;
							case 4:
								break;
							case 7:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = -482080648;
								continue;
							case 1:
								goto IL_0105;
							default:
								goto end_IL_0008;
							}
							break;
							IL_0105:
							int num2;
							if (AtUtpwPqTODMYBMydNAGQLlgwMy >= OJAiHPYagrRiBMLNDTiAgxMpnSm)
							{
								num = -482080645;
								num2 = num;
							}
							else
							{
								num = -482080641;
								num2 = num;
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
				public trSvZccixerNpKDAhYEoISSHiEE(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.IxbHVCPxPdNPRUkNUofPdkkhUmv;
				}
			}

			internal override bool hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						goto IL_0008;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					int num;
					if (assignedAxisCount == 0 && assignedButtonCount == 0)
					{
						num = 1234344333;
						goto IL_000d;
					}
					return true;
					IL_0008:
					num = 1234344334;
					goto IL_000d;
					IL_000d:
					switch (num ^ 0x4992998F)
					{
					case 0:
						break;
					case 1:
						return false;
					default:
						return false;
					}
					goto IL_0008;
				}
			}

			internal override bool disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			internal override bool isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						goto IL_0008;
					}
					int num;
					if (matchingCriteria == null)
					{
						num = 1818639460;
						goto IL_000d;
					}
					return matchingCriteria.isAllowed;
					IL_0008:
					num = 1818639461;
					goto IL_000d;
					IL_000d:
					switch (num ^ 0x6C663C64)
					{
					case 2:
						break;
					case 1:
						return false;
					default:
						return false;
					}
					goto IL_0008;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			internal override IList<Platform> variants_base
			{
				get
				{
					return null;
				}
			}

			public override int assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			public override int assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			internal override Elements_Base elements_base
			{
				get
				{
					return elements;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				int num = identifiers.Length;
				string[] array = default(string[]);
				int num4 = default(int);
				int num3 = default(int);
				int num5 = default(int);
				while (true)
				{
					int num2 = -806836511;
					while (true)
					{
						switch (num2 ^ -806836510)
						{
						case 6:
							break;
						case 3:
							if (num < elements.axisCount)
							{
								Logger.LogError("You have too few element identifiers!");
								return new string[0];
							}
							array = new string[elements.axisCount];
							num4 = array.Length;
							num3 = 0;
							num2 = -806836510;
							continue;
						case 4:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = -806836505;
							continue;
						case 2:
							array[num3] = identifiers[num5].name;
							num2 = -806836505;
							continue;
						case 5:
							num3++;
							num2 = -806836510;
							continue;
						case 1:
						{
							int elementIdentifier = elements.axes[num3].elementIdentifier;
							num5 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							if (num5 >= 0)
							{
								int num6;
								if (num5 >= num)
								{
									num2 = -806836506;
									num6 = num2;
								}
								else
								{
									num2 = -806836512;
									num6 = num2;
								}
								continue;
							}
							goto case 4;
						}
						default:
							if (num3 >= num4)
							{
								return array;
							}
							goto case 1;
						}
						break;
					}
				}
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				int num2 = default(int);
				int num3 = default(int);
				string[] array = default(string[]);
				int num4 = default(int);
				while (true)
				{
					int num = -39432786;
					while (true)
					{
						switch (num ^ -39432790)
						{
						case 2:
							break;
						case 1:
							num = -39432790;
							continue;
						case 7:
							Logger.LogError("You have too few element identifiers!");
							return new string[0];
						case 0:
							num2++;
							num = -39432791;
							continue;
						case 4:
							num3 = identifiers.Length;
							if (num3 >= buttonCount)
							{
								array = new string[buttonCount];
								num2 = 0;
								num = -39432791;
							}
							else
							{
								num = -39432787;
							}
							continue;
						case 8:
						{
							int elementIdentifier = elements.buttons[num2].elementIdentifier;
							num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							if (num4 >= 0)
							{
								int num5;
								if (num4 >= num3)
								{
									num = -39432785;
									num5 = num;
								}
								else
								{
									num = -39432788;
									num5 = num;
								}
								continue;
							}
							goto case 5;
						}
						case 5:
							Logger.LogError("Element identifier index is out of bounds!");
							num = -39432789;
							continue;
						case 6:
							array[num2] = identifiers[num4].name;
							num = -39432790;
							continue;
						default:
							if (num2 >= buttonCount)
							{
								return array;
							}
							goto case 8;
						}
						break;
					}
				}
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<Axis> enumerator = IterateAxes().GetEnumerator())
				{
					while (true)
					{
						IL_004e:
						int num;
						int num2;
						if (!enumerator.MoveNext())
						{
							num = -2041077630;
							num2 = num;
						}
						else
						{
							num = -2041077629;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -2041077630)
							{
							case 2:
								goto IL_000e;
							default:
								goto end_IL_0013;
							case 1:
							{
								Axis current = enumerator.Current;
								if (current.elementIdentifier == elementIdentifierId)
								{
									return true;
								}
								break;
							}
							case 3:
								break;
							case 0:
								goto end_IL_0013;
							}
							goto IL_004e;
							IL_000e:
							num = -2041077629;
							continue;
							end_IL_0013:
							break;
						}
						break;
					}
				}
				using (IEnumerator<Button> enumerator2 = IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Button current2 = enumerator2.Current;
							int num3;
							int num4;
							if (current2.elementIdentifier != elementIdentifierId)
							{
								num3 = -2041077631;
								num4 = num3;
							}
							else
							{
								num3 = -2041077630;
								num4 = num3;
							}
							while (true)
							{
								switch (num3 ^ -2041077630)
								{
								case 2:
									num3 = -2041077629;
									continue;
								case 1:
									break;
								case 0:
									return true;
								default:
									goto end_IL_00a4;
								}
								break;
							}
							continue;
							end_IL_00a4:
							break;
						}
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				using (IEnumerator<Button> enumerator = IterateButtons().GetEnumerator())
				{
					while (true)
					{
						IL_0073:
						int num2;
						int num3;
						if (enumerator.MoveNext())
						{
							num2 = 1970134247;
							num3 = num2;
						}
						else
						{
							num2 = 1970134242;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x756DDCE3)
							{
							case 2:
								num2 = 1970134247;
								continue;
							default:
								goto end_IL_002f;
							case 4:
							{
								Button current = enumerator.Current;
								buttons[num] = current.elementIdentifier;
								num2 = 1970134243;
								continue;
							}
							case 0:
								num++;
								num2 = 1970134240;
								continue;
							case 3:
								break;
							case 1:
								goto end_IL_002f;
							}
							goto IL_0073;
							continue;
							end_IL_002f:
							break;
						}
						break;
					}
				}
				num = 0;
				using (IEnumerator<Axis> enumerator2 = IterateAxes().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Axis current2 = enumerator2.Current;
							int num4 = 1970134247;
							while (true)
							{
								switch (num4 ^ 0x756DDCE3)
								{
								case 3:
									num4 = 1970134242;
									continue;
								case 0:
									num++;
									num4 = 1970134241;
									continue;
								case 4:
									axes[num] = current2.elementIdentifier;
									num4 = 1970134243;
									continue;
								case 1:
									break;
								default:
									goto end_IL_00eb;
								}
								break;
							}
							continue;
							end_IL_00eb:
							break;
						}
					}
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				int num2 = default(int);
				while (true)
				{
					int num = -873009887;
					while (true)
					{
						switch (num ^ -873009886)
						{
						case 10:
							break;
						case 6:
							num = -873009878;
							continue;
						case 2:
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num4;
								if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Hat)
								{
									num = -873009885;
									num4 = num;
								}
								else
								{
									num = -873009883;
									num4 = num;
								}
								continue;
							}
							goto case 1;
						case 9:
							array[num2] = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							if (Axes_orig[num2].calibrateAxis)
							{
								array[num2].zero = axes_orig[num2].axisZero;
								array[num2].min = axes_orig[num2].axisMin;
								array[num2].max = axes_orig[num2].axisMax;
								num = -873009884;
								continue;
							}
							goto case 8;
						case 8:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num2++;
							num = -873009886;
							continue;
						case 4:
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num3;
								if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Custom)
								{
									num = -873009877;
									num3 = num;
								}
								else
								{
									num = -873009888;
									num3 = num;
								}
								continue;
							}
							goto case 9;
						case 7:
							throw new NotImplementedException();
						case 5:
							num = -873009886;
							continue;
						case 1:
							array[num2] = AxisCalibrationData.Default;
							num = -873009878;
							continue;
						case 3:
							num2 = 0;
							num = -873009881;
							continue;
						default:
							if (num2 >= axes_orig.Length)
							{
								return array;
							}
							goto case 4;
						}
						break;
					}
				}
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				int num2 = default(int);
				while (true)
				{
					axisRanges = new AxisRange[Axes_orig.Length];
					axisInfos = new HardwareAxisInfo[Axes_orig.Length];
					int num = -622942728;
					while (true)
					{
						switch (num ^ -622942732)
						{
						case 7:
							num = -622942730;
							continue;
						case 11:
							throw new Exception();
						case 6:
						{
							int num5;
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Hat)
							{
								num = -622942721;
								num5 = num;
							}
							else
							{
								num = -622942731;
								num5 = num;
							}
							continue;
						}
						case 12:
							num2 = 0;
							num = -622942732;
							continue;
						case 10:
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num4;
								if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Custom)
								{
									num = -622942736;
									num4 = num;
								}
								else
								{
									num = -622942727;
									num4 = num;
								}
								continue;
							}
							goto case 4;
						case 4:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -622942724;
							continue;
						case 3:
							num = -622942723;
							continue;
						case 9:
							num2++;
							num = -622942732;
							continue;
						case 5:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							num = -622942722;
							continue;
						case 8:
							num = -622942723;
							continue;
						case 1:
							axisRanges[num2] = AxisRange.Full;
							num = -622942729;
							continue;
						case 2:
							break;
						case 13:
						{
							int num3;
							if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Button)
							{
								num = -622942731;
								num3 = num;
							}
							else
							{
								num = -622942734;
								num3 = num;
							}
							continue;
						}
						default:
							if (num2 >= Axes_orig.Length)
							{
								return;
							}
							goto case 5;
						}
						break;
					}
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig == null)
				{
					return;
				}
				while (true)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					int num = 0;
					int num2 = -348788244;
					while (true)
					{
						switch (num2 ^ -348788241)
						{
						case 0:
							num2 = -348788242;
							continue;
						default:
							return;
						case 3:
						{
							int num3;
							if (num >= Buttons_orig.Length)
							{
								num2 = -348788245;
								num3 = num2;
							}
							else
							{
								num2 = -348788243;
								num3 = num2;
							}
							continue;
						}
						case 2:
							buttonInfos[num] = MiscTools.DeepClone(Buttons_orig[num].buttonInfo, true);
							num++;
							num2 = -348788244;
							continue;
						case 1:
							break;
						case 4:
							return;
						}
						break;
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			internal IEnumerable<Axis> IterateAxes()
			{
				DIteTKtGSHsPpbGvwgxaGKnlqRsi dIteTKtGSHsPpbGvwgxaGKnlqRsi = new DIteTKtGSHsPpbGvwgxaGKnlqRsi(-2);
				dIteTKtGSHsPpbGvwgxaGKnlqRsi.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return dIteTKtGSHsPpbGvwgxaGKnlqRsi;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				trSvZccixerNpKDAhYEoISSHiEE trSvZccixerNpKDAhYEoISSHiEE2 = new trSvZccixerNpKDAhYEoISSHiEE(-2);
				trSvZccixerNpKDAhYEoISSHiEE2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return trSvZccixerNpKDAhYEoISSHiEE2;
			}

			public override object DeepClone()
			{
				Platform_SDL2_Base platform_SDL2_Base = new Platform_SDL2_Base();
				CopyVars(platform_SDL2_Base);
				return platform_SDL2_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				Platform_SDL2_Base platform_SDL2_Base = destination as Platform_SDL2_Base;
				while (true)
				{
					int num = 1930727086;
					while (true)
					{
						switch (num ^ 0x73148EAC)
						{
						case 4:
							break;
						default:
							return;
						case 1:
							platform_SDL2_Base.elements = MiscTools.DeepClone(elements);
							num = 1930727084;
							continue;
						case 3:
							return;
						case 2:
						{
							int num2;
							if (platform_SDL2_Base != null)
							{
								num = 1930727085;
								num2 = num;
							}
							else
							{
								num = 1930727087;
								num2 = num;
							}
							continue;
						}
						case 0:
							return;
						}
						break;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_SDL2 : Platform_SDL2_Base
		{
			public Platform_SDL2_Base[] variants;

			internal override IList<Platform> variants_base
			{
				get
				{
					return variants;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					goto IL_000d;
				}
				int num = default(int);
				int num2;
				if (base.hasVariants)
				{
					num = 0;
					num2 = -1036566479;
					goto IL_0012;
				}
				goto IL_009f;
				IL_0012:
				while (true)
				{
					switch (num2 ^ -1036566476)
					{
					case 2:
						break;
					case 5:
						goto IL_0037;
					case 0:
						goto IL_0053;
					case 3:
						return true;
					case 4:
						return true;
					default:
						goto IL_009f;
					}
					break;
					IL_0053:
					int variantIndex2;
					if (variants[num] != null && variants[num].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
					{
						variantIndex = num;
						num2 = -1036566473;
					}
					else
					{
						num++;
						num2 = -1036566479;
					}
					continue;
					IL_0037:
					int num3;
					if (num >= variants.Length)
					{
						num2 = -1036566475;
						num3 = num2;
					}
					else
					{
						num2 = -1036566476;
						num3 = num2;
					}
				}
				goto IL_000d;
				IL_009f:
				return false;
				IL_000d:
				num2 = -1036566480;
				goto IL_0012;
			}

			public override object DeepClone()
			{
				Platform_SDL2 platform_SDL = new Platform_SDL2();
				CopyVars(platform_SDL);
				return platform_SDL;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_SDL2 platform_SDL = destination as Platform_SDL2;
				if (platform_SDL == null)
				{
					return;
				}
				while (true)
				{
					platform_SDL.variants = MiscTools.DeepClone(variants);
					int num = 1027857845;
					while (true)
					{
						switch (num ^ 0x3D43DDB7)
						{
						case 0:
							goto IL_0012;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_0012:
						num = 1027857846;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_Steam_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				internal override bool hasData
				{
					get
					{
						return true;
					}
				}

				internal override bool isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						return true;
					}
				}

				internal override int alternateElementCount
				{
					get
					{
						return 0;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (disabled)
					{
						return false;
					}
					if (!isAllowed)
					{
						return false;
					}
					return true;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched);
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					MatchingCriteria matchingCriteria = destination as MatchingCriteria;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				public override int buttonCount
				{
					get
					{
						return 0;
					}
				}

				public override int axisCount
				{
					get
					{
						return 0;
					}
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					Elements elements = destination as Elements;
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = AxisRange.Full;
					return false;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public override int assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			public override int assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.ZANtQEkaOaQcYhPlpfZCiDwahfr;
				}
			}

			internal override bool hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						goto IL_0017;
					}
					int num;
					if (assignedAxisCount == 0)
					{
						num = -979881547;
						goto IL_001c;
					}
					goto IL_0050;
					IL_001c:
					switch (num ^ -979881545)
					{
					case 0:
						break;
					case 1:
						return false;
					default:
						goto IL_0046;
					}
					goto IL_0017;
					IL_0046:
					if (assignedButtonCount == 0)
					{
						return false;
					}
					goto IL_0050;
					IL_0050:
					return true;
					IL_0017:
					num = -979881546;
					goto IL_001c;
				}
			}

			internal override bool disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			internal override bool isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal override Elements_Base elements_base
			{
				get
				{
					return elements;
				}
			}

			internal override IList<Platform> variants_base
			{
				get
				{
					return null;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return new string[0];
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return new string[0];
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[0];
				axes = new int[0];
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return new AxisCalibrationData[0];
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = new AxisRange[0];
				axisInfos = new HardwareAxisInfo[0];
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = new HardwareButtonInfo[0];
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					while (true)
					{
						int num = 1387519844;
						while (true)
						{
							switch (num ^ 0x52B3DF65)
							{
							case 0:
								break;
							case 1:
								goto IL_0026;
							default:
								return false;
							}
							break;
							IL_0026:
							axisRange = AxisRange.Full;
							num = 1387519847;
						}
					}
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_Steam_Base platform_Steam_Base = new Platform_Steam_Base();
				CopyVars(platform_Steam_Base);
				return platform_Steam_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				Platform_Steam_Base platform_Steam_Base = destination as Platform_Steam_Base;
				if (platform_Steam_Base != null)
				{
					platform_Steam_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_Steam_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_Steam : Platform_Steam_Base
		{
			public Platform_Steam_Base[] variants;

			internal override IList<Platform> variants_base
			{
				get
				{
					return variants;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					int num = 0;
					while (true)
					{
						int num2;
						int num3;
						if (num < variants.Length)
						{
							num2 = -707373087;
							num3 = num2;
						}
						else
						{
							num2 = -707373085;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -707373088)
							{
							case 0:
								num2 = -707373087;
								continue;
							case 1:
								break;
							case 2:
								goto end_IL_0020;
							default:
								goto end_IL_006c;
							}
							int variantIndex2;
							if (variants[num] != null && variants[num].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
							{
								variantIndex = num;
								return true;
							}
							num++;
							num2 = -707373086;
							continue;
							end_IL_0020:
							break;
						}
						continue;
						end_IL_006c:
						break;
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_Steam platform_Steam = new Platform_Steam();
				CopyVars(platform_Steam);
				return platform_Steam;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_Steam platform_Steam = destination as Platform_Steam;
				if (platform_Steam == null)
				{
					goto IL_0011;
				}
				goto IL_003b;
				IL_0011:
				int num = -1335577956;
				goto IL_0016;
				IL_0016:
				switch (num ^ -1335577955)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					return;
				case 0:
					goto IL_003b;
				case 2:
					return;
				}
				goto IL_0011;
				IL_003b:
				platform_Steam.variants = MiscTools.DeepClone(variants);
				num = -1335577953;
				goto IL_0016;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_WebGL_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				[Serializable]
				public sealed class ClientInfo : IDeepCloneable
				{
					public int browser;

					public string browserVersionMin;

					public string browserVersionMax;

					public int os;

					public string osVersionMin;

					public string osVersionMax;

					public object DeepClone()
					{
						ClientInfo clientInfo = new ClientInfo();
						while (true)
						{
							int num = 2134773108;
							while (true)
							{
								switch (num ^ 0x7F3E0D70)
								{
								case 3:
									break;
								case 0:
									clientInfo.browserVersionMax = browserVersionMax;
									clientInfo.os = os;
									clientInfo.osVersionMin = osVersionMin;
									num = 2134773106;
									continue;
								case 1:
									clientInfo.browserVersionMin = browserVersionMin;
									num = 2134773104;
									continue;
								case 4:
									clientInfo.browser = browser;
									num = 2134773105;
									continue;
								default:
									clientInfo.osVersionMax = osVersionMax;
									return clientInfo;
								}
								break;
							}
						}
					}
				}

				public bool productName_useRegex;

				public string[] productName;

				public string[] productGUID;

				public int[] mapping;

				public ElementCount_Base[] elementCount;

				public ClientInfo[] clientInfo;

				internal override bool hasData
				{
					get
					{
						if (base.hasData)
						{
							goto IL_0008;
						}
						if (productName != null && productName.Length > 0)
						{
							return true;
						}
						int num;
						if (mapping != null)
						{
							num = 90048653;
							goto IL_000d;
						}
						goto IL_0073;
						IL_0008:
						num = 90048651;
						goto IL_000d;
						IL_0066:
						if (mapping.Length > 0)
						{
							return true;
						}
						goto IL_0073;
						IL_000d:
						while (true)
						{
							switch (num ^ 0x55E088F)
							{
							case 0:
								break;
							case 4:
								return true;
							case 3:
								goto IL_0054;
							case 2:
								goto IL_0066;
							default:
								return true;
							}
							break;
							IL_0054:
							if (elementCount.Length > 0)
							{
								num = 90048654;
								continue;
							}
							goto IL_009c;
						}
						goto IL_0008;
						IL_009c:
						if (clientInfo != null && clientInfo.Length > 0)
						{
							return true;
						}
						return false;
						IL_0073:
						if (productGUID != null && productGUID.Length > 0)
						{
							return true;
						}
						if (elementCount != null)
						{
							num = 90048652;
							goto IL_000d;
						}
						goto IL_009c;
					}
				}

				internal override bool isAllowed
				{
					get
					{
						if (!base.isAllowed)
						{
							return false;
						}
						if (disabled)
						{
							return false;
						}
						return true;
					}
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						goto IL_0027;
					}
					if (alwaysMatch)
					{
						return true;
					}
					bool result = false;
					string text = StringTools.Trim(tag);
					int num;
					bool flag = default(bool);
					int num2 = default(int);
					if (!string.IsNullOrEmpty(text) && !string.Equals(bridgedControllerHWInfo.definitionMatchTag, text, StringComparison.OrdinalIgnoreCase))
					{
						num = -849202145;
					}
					else
					{
						if (this.clientInfo == null || this.clientInfo.Length <= 0)
						{
							goto IL_048c;
						}
						flag = false;
						num2 = 0;
						num = -849202151;
					}
					goto IL_002c;
					IL_002c:
					int num3 = default(int);
					bool flag5 = default(bool);
					bool flag2 = default(bool);
					int num6 = default(int);
					int num4 = default(int);
					string text2 = default(string);
					bool flag4 = default(bool);
					bool flag3 = default(bool);
					int num5 = default(int);
					ElementCount_Base elementCount_Base = default(ElementCount_Base);
					while (true)
					{
						switch (num ^ -849202150)
						{
						case 15:
							break;
						case 22:
							num3++;
							num = -849202149;
							continue;
						case 19:
							flag5 = true;
							num = -849202168;
							continue;
						case 14:
							if (elementCount.Length > 0)
							{
								flag2 = false;
								num6 = 0;
								num = -849202146;
								continue;
							}
							goto IL_04a8;
						case 32:
						{
							string searchFor = productName[num4];
							if (MatchingCriteria_Base.StringMatches(text2, searchFor, productName_useRegex))
							{
								flag4 = true;
								num = -849202169;
								continue;
							}
							goto case 24;
						}
						case 9:
							goto IL_0143;
						case 8:
							goto IL_0154;
						case 0:
						{
							int num7 = mapping[num3];
							if (num7 == (int)bridgedControllerHWInfo.webGL_mappingType)
							{
								flag3 = true;
								num = -849202164;
								continue;
							}
							goto case 22;
						}
						case 20:
							goto IL_01a2;
						case 34:
							goto IL_01b3;
						case 12:
							goto IL_01ef;
						case 39:
							if (bridgedControllerHWInfo.hw_pidVid.Equals(productGUID[num5]))
							{
								flag4 = true;
								num = -849202157;
								continue;
							}
							goto case 11;
						case 31:
							goto IL_0233;
						case 4:
							goto IL_02c9;
						case 10:
							goto IL_02e9;
						case 30:
							num6++;
							num = -849202146;
							continue;
						case 33:
							elementCount_Base = elementCount[num6];
							if (elementCount_Base == null)
							{
								goto case 30;
							}
							goto IL_0328;
						case 18:
							num5 = 0;
							num = -849202160;
							continue;
						case 37:
							num = -849202149;
							continue;
						case 36:
							return true;
						case 28:
							goto IL_0396;
						case 11:
							num5++;
							num = -849202160;
							continue;
						case 35:
							return false;
						case 23:
							if (mapping.Length > 0)
							{
								flag3 = false;
								num = -849202148;
								continue;
							}
							goto case 38;
						case 16:
							goto IL_03e1;
						case 26:
							return false;
						case 25:
							goto IL_0400;
						case 17:
							return false;
						case 2:
							goto IL_044f;
						case 21:
							flag2 = true;
							num = -849202172;
							continue;
						case 24:
							num4++;
							num = -849202152;
							continue;
						case 13:
							goto IL_048c;
						case 27:
							goto IL_04a8;
						case 3:
							goto IL_04c4;
						case 38:
							flag4 = false;
							flag5 = false;
							num = -849202120;
							continue;
						case 1:
							goto IL_04f3;
						case 6:
							num3 = 0;
							num = -849202113;
							continue;
						case 7:
							goto IL_0520;
						case 5:
							return false;
						default:
							goto IL_056c;
						}
						break;
						IL_0520:
						int num8;
						if (elementCount_Base.axisCount != bridgedControllerHWInfo.hardwareAxisCount)
						{
							num = -849202172;
							num8 = num;
						}
						else
						{
							num = -849202161;
							num8 = num;
						}
						continue;
						IL_0328:
						if (elementCount_Base.buttonCount >= 0)
						{
							int num9;
							if (elementCount_Base.buttonCount != bridgedControllerHWInfo.hardwareButtonCount)
							{
								num = -849202172;
								num9 = num;
							}
							else
							{
								num = -849202154;
								num9 = num;
							}
							continue;
						}
						goto IL_01ef;
						IL_01ef:
						int num10;
						if (elementCount_Base.axisCount < 0)
						{
							num = -849202161;
							num10 = num;
						}
						else
						{
							num = -849202147;
							num10 = num;
						}
						continue;
						IL_04f3:
						int num11;
						if (num3 < mapping.Length)
						{
							num = -849202150;
							num11 = num;
						}
						else
						{
							num = -849202170;
							num11 = num;
						}
						continue;
						IL_02e9:
						int num12;
						if (num5 < productGUID.Length)
						{
							num = -849202115;
							num12 = num;
						}
						else
						{
							num = -849202157;
							num12 = num;
						}
						continue;
						IL_0143:
						if (flag4)
						{
							num = -849202114;
							continue;
						}
						text2 = StringTools.Trim(bridgedControllerHWInfo.hw_productName);
						if (text2 == null)
						{
							text2 = string.Empty;
							num = -849202158;
							continue;
						}
						goto IL_0154;
						IL_04c4:
						int num13;
						if (num2 >= this.clientInfo.Length)
						{
							num = -849202166;
							num13 = num;
						}
						else
						{
							num = -849202171;
							num13 = num;
						}
						continue;
						IL_0154:
						if (productName != null && productName.Length > 0)
						{
							flag5 = true;
							num4 = 0;
							num = -849202152;
							continue;
						}
						goto IL_056c;
						IL_02c9:
						int num14;
						if (num6 < elementCount.Length)
						{
							num = -849202117;
							num14 = num;
						}
						else
						{
							num = -849202162;
							num14 = num;
						}
						continue;
						IL_044f:
						int num15;
						if (num4 >= productName.Length)
						{
							num = -849202169;
							num15 = num;
						}
						else
						{
							num = -849202118;
							num15 = num;
						}
						continue;
						IL_0233:
						ClientInfo clientInfo = this.clientInfo[num2];
						if (clientInfo != null)
						{
							if (clientInfo.browser != 0)
							{
								if (clientInfo.browser != (int)bridgedControllerHWInfo.webGL_webBrowserType)
								{
									goto IL_0400;
								}
								if (!CheckBrowserVersion(clientInfo.browser, clientInfo.browserVersionMin, clientInfo.browserVersionMax, bridgedControllerHWInfo.webGL_webBrowserVersionSplit))
								{
									return false;
								}
							}
							if (clientInfo.os != 0)
							{
								if (clientInfo.os != (int)bridgedControllerHWInfo.webGL_osType)
								{
									goto IL_0400;
								}
								if (!CheckOSVersion(clientInfo.osVersionMin, clientInfo.osVersionMax, bridgedControllerHWInfo.webGL_osVersionSplit))
								{
									num = -849202176;
									continue;
								}
							}
							flag = true;
							num = -849202166;
							continue;
						}
						goto IL_0400;
						IL_0400:
						num2++;
						num = -849202151;
						continue;
						IL_03e1:
						if (!flag)
						{
							return false;
						}
						result = true;
						num = -849202153;
						continue;
						IL_01a2:
						if (!flag2)
						{
							num = -849202119;
							continue;
						}
						result = true;
						num = -849202175;
						continue;
						IL_04a8:
						int num16;
						if (mapping == null)
						{
							num = -849202116;
							num16 = num;
						}
						else
						{
							num = -849202163;
							num16 = num;
						}
						continue;
						IL_0396:
						if (!flag3)
						{
							return false;
						}
						result = true;
						num = -849202116;
						continue;
						IL_01b3:
						if (productGUID != null && productGUID.Length > 0)
						{
							int num17;
							if (ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
							{
								num = -849202157;
								num17 = num;
							}
							else
							{
								num = -849202167;
								num17 = num;
							}
							continue;
						}
						goto IL_0143;
					}
					goto IL_0027;
					IL_0027:
					num = -849202165;
					goto IL_002c;
					IL_048c:
					int num18;
					if (elementCount != null)
					{
						num = -849202156;
						num18 = num;
					}
					else
					{
						num = -849202175;
						num18 = num;
					}
					goto IL_002c;
					IL_056c:
					if (flag4)
					{
						return true;
					}
					if (flag5)
					{
						return false;
					}
					return result;
				}

				private static bool CheckBrowserVersion(int browser, string versionMin, string versionMax, string[] currentVersion)
				{
					versionMin = StringTools.Trim(versionMin);
					versionMax = StringTools.Trim(versionMax);
					bool flag = !string.IsNullOrEmpty(versionMin);
					bool flag2 = !string.IsNullOrEmpty(versionMax);
					string[] array2 = default(string[]);
					int num5 = default(int);
					bool flag6 = default(bool);
					int num2 = default(int);
					bool flag8 = default(bool);
					int num4 = default(int);
					int result4 = default(int);
					bool flag7 = default(bool);
					int result3 = default(int);
					int num3 = default(int);
					bool flag4 = default(bool);
					string[] array = default(string[]);
					int result2 = default(int);
					int num7 = default(int);
					bool flag5 = default(bool);
					while (true)
					{
						int num = -353628287;
						while (true)
						{
							switch (num ^ -353628286)
							{
							case 8:
								break;
							case 1:
								array2 = versionMin.Split('.');
								num5 = MathTools.Min(array2.Length, currentVersion.Length);
								flag6 = false;
								num = -353628280;
								continue;
							case 6:
								return true;
							case 17:
								num2++;
								num = -353628288;
								continue;
							case 16:
								flag8 = int.TryParse(array2[num4], out result4);
								flag7 = int.TryParse(currentVersion[num4], out result3);
								if (flag8)
								{
									num = -353628282;
									continue;
								}
								goto IL_010e;
							case 10:
								num4 = 0;
								num = -353628277;
								continue;
							case 4:
								if (!flag7)
								{
									return false;
								}
								goto IL_010e;
							case 5:
								switch (num3)
								{
								case -1:
								case 0:
									break;
								default:
									goto IL_00b3;
								}
								goto case 6;
							case 0:
								flag4 = int.TryParse(array[num2], out result2);
								num = -353628274;
								continue;
							case 14:
								return false;
							case 13:
								return true;
							case 7:
								if (!flag6)
								{
									return false;
								}
								goto IL_01a3;
							case 3:
								if (flag || flag2)
								{
									if (currentVersion != null)
									{
										if (currentVersion.Length != 0)
										{
											num3 = browser;
											num = -353628281;
										}
										else
										{
											num = -353628276;
										}
										continue;
									}
									goto case 14;
								}
								num = -353628273;
								continue;
							case 2:
							{
								int num8;
								if (num2 >= num7)
								{
									num = -353628275;
									num8 = num;
								}
								else
								{
									num = -353628286;
									num8 = num;
								}
								continue;
							}
							case 11:
								num4++;
								num = -353628277;
								continue;
							case 9:
							{
								int num6;
								if (num4 < num5)
								{
									num = -353628270;
									num6 = num;
								}
								else
								{
									num = -353628283;
									num6 = num;
								}
								continue;
							}
							case 12:
							{
								int result;
								bool flag3 = int.TryParse(currentVersion[num2], out result);
								if (flag4 && !flag3)
								{
									return false;
								}
								if (flag4)
								{
									if (result > result2)
									{
										return false;
									}
									flag5 = true;
									num = -353628269;
									continue;
								}
								goto default;
							}
							default:
								{
									if (!flag5)
									{
										return false;
									}
									goto IL_0268;
								}
								IL_0268:
								return true;
								IL_00b3:
								if (flag)
								{
									num = -353628285;
									continue;
								}
								goto IL_01a3;
								IL_01a3:
								if (flag2)
								{
									array = versionMax.Split('.');
									num7 = MathTools.Min(array.Length, currentVersion.Length);
									flag5 = false;
									num2 = 0;
									num = -353628288;
									continue;
								}
								goto IL_0268;
								IL_010e:
								if (flag8)
								{
									if (result3 < result4)
									{
										return false;
									}
									flag6 = true;
									num = -353628279;
									continue;
								}
								goto case 7;
							}
							break;
						}
					}
				}

				private static bool CheckOSVersion(string versionMin, string versionMax, string[] currentVersion)
				{
					versionMin = StringTools.Trim(versionMin);
					versionMax = StringTools.Trim(versionMax);
					bool flag = !string.IsNullOrEmpty(versionMin);
					int num3 = default(int);
					string[] array = default(string[]);
					bool flag4 = default(bool);
					int num2 = default(int);
					bool flag5 = default(bool);
					string[] array2 = default(string[]);
					int num5 = default(int);
					bool flag6 = default(bool);
					int num6 = default(int);
					while (true)
					{
						int num = -20016072;
						while (true)
						{
							int num4;
							switch (num ^ -20016068)
							{
							case 11:
								break;
							case 17:
								return false;
							case 5:
								return true;
							case 14:
								num3 = MathTools.Min(array.Length, currentVersion.Length);
								flag4 = false;
								num2 = 0;
								num = -20016079;
								continue;
							case 4:
								flag5 = !string.IsNullOrEmpty(versionMax);
								if (!flag)
								{
									num = -20016065;
									continue;
								}
								goto IL_008c;
							case 7:
								num = -20016084;
								continue;
							case 1:
								if (currentVersion.Length != 0)
								{
									if (flag)
									{
										num = -20016074;
										continue;
									}
									goto IL_01b7;
								}
								num = -20016083;
								continue;
							case 9:
								if (!flag4)
								{
									num = -20016080;
									continue;
								}
								goto IL_0256;
							case 0:
							{
								int result3;
								bool flag7 = int.TryParse(array2[num5], out result3);
								int result4;
								bool flag8 = int.TryParse(currentVersion[num5], out result4);
								if (flag7 && !flag8)
								{
									return false;
								}
								if (flag7)
								{
									if (result4 < result3)
									{
										return false;
									}
									flag6 = true;
									num = -20016070;
									continue;
								}
								goto case 2;
							}
							case 10:
								array2 = versionMin.Split('.');
								num6 = MathTools.Min(array2.Length, currentVersion.Length);
								flag6 = false;
								num = -20016082;
								continue;
							case 3:
								if (!flag5)
								{
									num = -20016071;
									continue;
								}
								goto IL_008c;
							case 8:
								return false;
							case 13:
							{
								int num8;
								if (num2 < num3)
								{
									num = -20016077;
									num8 = num;
								}
								else
								{
									num = -20016075;
									num8 = num;
								}
								continue;
							}
							case 2:
								if (!flag6)
								{
									return false;
								}
								goto IL_01b7;
							case 18:
								num5 = 0;
								num = -20016069;
								continue;
							case 16:
							{
								int num7;
								if (num5 >= num6)
								{
									num = -20016066;
									num7 = num;
								}
								else
								{
									num = -20016068;
									num7 = num;
								}
								continue;
							}
							case 6:
								num5++;
								num = -20016084;
								continue;
							case 15:
							{
								int result;
								bool flag2 = int.TryParse(array[num2], out result);
								int result2;
								bool flag3 = int.TryParse(currentVersion[num2], out result2);
								if (flag2 && !flag3)
								{
									return false;
								}
								if (flag2)
								{
									if (result2 <= result)
									{
										flag4 = true;
										num2++;
										num = -20016079;
									}
									else
									{
										num = -20016076;
									}
									continue;
								}
								goto case 9;
							}
							default:
								{
									return false;
								}
								IL_008c:
								if (currentVersion == null)
								{
									num = -20016083;
									num4 = num;
								}
								else
								{
									num = -20016067;
									num4 = num;
								}
								continue;
								IL_01b7:
								if (flag5)
								{
									array = versionMax.Split('.');
									num = -20016078;
									continue;
								}
								goto IL_0256;
								IL_0256:
								return true;
							}
							break;
						}
					}
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					CopyVars(matchingCriteria);
					return matchingCriteria;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					MatchingCriteria matchingCriteria = default(MatchingCriteria);
					while (true)
					{
						int num = -1874246981;
						while (true)
						{
							switch (num ^ -1874246982)
							{
							case 3:
								break;
							default:
								return;
							case 1:
								matchingCriteria = destination as MatchingCriteria;
								if (matchingCriteria == null)
								{
									return;
								}
								goto case 4;
							case 0:
								matchingCriteria.mapping = ArrayTools.ShallowCopy(mapping);
								matchingCriteria.elementCount = ArrayTools.DeepClone(elementCount);
								matchingCriteria.clientInfo = ArrayTools.DeepClone(clientInfo);
								num = -1874246984;
								continue;
							case 4:
								matchingCriteria.productName_useRegex = productName_useRegex;
								num = -1874246977;
								continue;
							case 5:
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
								num = -1874246982;
								continue;
							case 2:
								return;
							}
							break;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount
				{
					get
					{
						if (buttons == null)
						{
							return 0;
						}
						return buttons.Length;
					}
				}

				public override int axisCount
				{
					get
					{
						if (axes == null)
						{
							return 0;
						}
						return axes.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					int num = 0;
					int num2 = default(int);
					while (true)
					{
						IL_00a1:
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = -475496600;
							goto IL_000c;
						}
						goto IL_0072;
						IL_000c:
						while (true)
						{
							switch (num3 ^ -475496595)
							{
							case 7:
								num3 = -475496596;
								continue;
							case 4:
								break;
							case 6:
								goto IL_0058;
							case 1:
								goto end_IL_000c;
							case 5:
								num3 = -475496597;
								continue;
							case 3:
								goto IL_00a1;
							case 0:
								return ControllerElementType.Button;
							default:
								return elementIdentifier.elementType;
							}
							if (buttons[num2].elementIdentifier == elementIdentifier.id)
							{
								num3 = -475496595;
								continue;
							}
							num2++;
							num3 = -475496597;
							continue;
							IL_0058:
							int num4;
							if (num2 < buttonCount)
							{
								num3 = -475496599;
								num4 = num3;
							}
							else
							{
								num3 = -475496593;
								num4 = num3;
							}
							continue;
							end_IL_000c:
							break;
						}
						goto IL_0072;
						IL_0072:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							break;
						}
						num++;
						num3 = -475496594;
						goto IL_000c;
					}
					return ControllerElementType.Axis;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					int sourceType = default(int);
					while (num < axisCount)
					{
						while (true)
						{
							int num2;
							int num3;
							if (axes[num].elementIdentifier != elementIdentifier.id)
							{
								num2 = 1076363557;
								num3 = num2;
							}
							else
							{
								num2 = 1076363554;
								num3 = num2;
							}
							while (true)
							{
								switch (num2 ^ 0x40280127)
								{
								case 6:
									num2 = 1076363567;
									continue;
								case 4:
									return true;
								case 7:
									break;
								case 3:
									goto IL_007d;
								case 0:
									goto IL_0089;
								case 2:
									num++;
									num2 = 1076363558;
									continue;
								case 8:
									goto end_IL_000c;
								case 5:
									goto IL_00cf;
								default:
									goto end_IL_00a6;
								}
								goto IL_004f;
								IL_00cf:
								sourceType = axes[num].sourceType;
								switch (sourceType)
								{
								case 1:
									break;
								case 0:
									axisRange = AxisRange.Positive;
									num2 = 1076363555;
									continue;
								default:
									num2 = 1076363559;
									continue;
								}
								goto IL_004f;
								IL_0089:
								if (sourceType != 100)
								{
									throw new NotImplementedException();
								}
								num2 = 1076363552;
								continue;
								IL_004f:
								axisRange = axes[num].sourceAxisRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 1076363556;
									continue;
								}
								goto IL_007d;
								IL_007d:
								return true;
								continue;
								end_IL_000c:
								break;
							}
							continue;
							end_IL_00a6:
							break;
						}
					}
					axisRange = AxisRange.Full;
					return false;
				}

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					Elements elements = destination as Elements;
					if (elements != null)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Button : Platform_Custom.Button
			{
				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Button button = destination as Button;
					while (true)
					{
						int num = -315792988;
						while (true)
						{
							switch (num ^ -315792987)
							{
							case 0:
								break;
							default:
								return;
							case 1:
								goto IL_002c;
							case 2:
								return;
							}
							break;
							IL_002c:
							num = -315792985;
						}
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public override object DeepClone()
				{
					Axis axis = new Axis();
					CopyVars(axis);
					return axis;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					while (true)
					{
						int num = 337243844;
						while (true)
						{
							switch (num ^ 0x1419EEC5)
							{
							case 2:
								break;
							default:
								return;
							case 1:
								goto IL_0025;
							case 0:
								return;
							}
							break;
							IL_0025:
							Axis axis = destination as Axis;
							num = 337243845;
						}
					}
				}
			}

			private sealed class dnpkiNtLLiBereCCyOsozBfsHrW : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_WebGL_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int yONttBUsAhMRaGKIZEAVwWGbEEA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					dnpkiNtLLiBereCCyOsozBfsHrW dnpkiNtLLiBereCCyOsozBfsHrW2;
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						dnpkiNtLLiBereCCyOsozBfsHrW2 = this;
					}
					else
					{
						while (true)
						{
							dnpkiNtLLiBereCCyOsozBfsHrW2 = new dnpkiNtLLiBereCCyOsozBfsHrW(0);
							dnpkiNtLLiBereCCyOsozBfsHrW2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
							int num = -1109259879;
							while (true)
							{
								switch (num ^ -1109259879)
								{
								case 2:
									num = -1109259880;
									continue;
								case 1:
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
					return dnpkiNtLLiBereCCyOsozBfsHrW2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 0:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements == null || ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes == null)
						{
							break;
						}
						yONttBUsAhMRaGKIZEAVwWGbEEA = 0;
						num = 1418846578;
						goto IL_001f;
					case 1:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							yONttBUsAhMRaGKIZEAVwWGbEEA++;
							num = 1418846578;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x5491E176)
							{
							case 0:
								num = 1418846581;
								continue;
							case 3:
								break;
							case 1:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes[yONttBUsAhMRaGKIZEAVwWGbEEA];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							case 4:
								goto IL_00c2;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00c2:
							int num2;
							if (yONttBUsAhMRaGKIZEAVwWGbEEA >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.axes.Length)
							{
								num = 1418846580;
								num2 = num;
							}
							else
							{
								num = 1418846583;
								num2 = num;
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
				public dnpkiNtLLiBereCCyOsozBfsHrW(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class kPtOdzrnPfVBXquhgUhSuXQSALY : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button RDkWcsTpvDaNZojjIZONnoEBXPC;

				private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

				private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

				public Platform_WebGL_Base ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

				public int PUMRGOkKJmiAiftmnOLRBXHMfKAe;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						goto IL_001c;
					}
					goto IL_007b;
					IL_007b:
					kPtOdzrnPfVBXquhgUhSuXQSALY kPtOdzrnPfVBXquhgUhSuXQSALY2 = new kPtOdzrnPfVBXquhgUhSuXQSALY(0);
					int num = -189978762;
					goto IL_0021;
					IL_001c:
					num = -189978763;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ -189978765)
						{
						case 0:
							break;
						case 6:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							num = -189978767;
							continue;
						case 2:
							kPtOdzrnPfVBXquhgUhSuXQSALY2 = this;
							num = -189978768;
							continue;
						case 5:
							kPtOdzrnPfVBXquhgUhSuXQSALY2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
							num = -189978761;
							continue;
						case 3:
							num = -189978761;
							continue;
						case 1:
							goto IL_007b;
						default:
							return kPtOdzrnPfVBXquhgUhSuXQSALY2;
						}
						break;
					}
					goto IL_001c;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					default:
						num = -346626401;
						goto IL_001a;
					case 0:
						goto IL_007d;
					case 1:
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							PUMRGOkKJmiAiftmnOLRBXHMfKAe++;
							num = -346626402;
							goto IL_001a;
						}
						IL_001a:
						while (true)
						{
							switch (num ^ -346626405)
							{
							case 0:
								break;
							case 7:
								if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements != null && ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons != null)
								{
									PUMRGOkKJmiAiftmnOLRBXHMfKAe = 0;
									num = -346626406;
									continue;
								}
								goto default;
							case 2:
								goto IL_007d;
							case 5:
								goto IL_008b;
							case 4:
								num = -346626403;
								continue;
							case 1:
								num = -346626402;
								continue;
							case 3:
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons[PUMRGOkKJmiAiftmnOLRBXHMfKAe];
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							default:
								return false;
							}
							break;
							IL_008b:
							int num2;
							if (PUMRGOkKJmiAiftmnOLRBXHMfKAe >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elements.buttons.Length)
							{
								num = -346626403;
								num2 = num;
							}
							else
							{
								num = -346626408;
								num2 = num;
							}
						}
						goto default;
						IL_007d:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = -346626404;
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
				public kPtOdzrnPfVBXquhgUhSuXQSALY(int _003C_003E1__state)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
					iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			public override int assignedButtonCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.buttonCount;
				}
			}

			public override int assignedAxisCount
			{
				get
				{
					if (elements == null)
					{
						return 0;
					}
					return elements.axisCount;
				}
			}

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.TxrUiyPjtJdznKpsXcVgtexpIzI;
				}
			}

			internal override Platform_Custom.Axis[] Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							int num2 = default(int);
							while (true)
							{
								int num = 350035881;
								while (true)
								{
									switch (num ^ 0x14DD1FA8)
									{
									case 2:
										break;
									case 5:
										goto IL_003c;
									case 0:
										num = 350035885;
										continue;
									case 4:
										_axesOrigGame[num2] = axes_orig[num2];
										num2++;
										num = 350035885;
										continue;
									case 1:
										_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
										num2 = 0;
										num = 350035880;
										continue;
									default:
										goto end_IL_0012;
									}
									break;
									IL_003c:
									int num3;
									if (num2 >= axes_orig.Length)
									{
										num = 350035883;
										num3 = num;
									}
									else
									{
										num = 350035884;
										num3 = num;
									}
								}
								continue;
								end_IL_0012:
								break;
							}
						}
					}
					return _axesOrigGame;
				}
			}

			internal override Platform_Custom.Button[] Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						int num2 = default(int);
						while (true)
						{
							int num = -349401399;
							while (true)
							{
								switch (num ^ -349401400)
								{
								case 6:
									break;
								case 1:
									if (buttons_orig != null)
									{
										_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
										num = -349401395;
										continue;
									}
									goto end_IL_0012;
								case 0:
									_buttonsOrigGame[num2] = buttons_orig[num2];
									num2++;
									num = -349401397;
									continue;
								case 2:
									num = -349401397;
									continue;
								case 3:
									goto IL_0075;
								case 5:
									num2 = 0;
									num = -349401398;
									continue;
								default:
									goto end_IL_0012;
								}
								break;
								IL_0075:
								int num3;
								if (num2 >= buttons_orig.Length)
								{
									num = -349401396;
									num3 = num;
								}
								else
								{
									num = -349401400;
									num3 = num;
								}
							}
							continue;
							end_IL_0012:
							break;
						}
					}
					return _buttonsOrigGame;
				}
			}

			internal Axis[] Axes_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.axes;
				}
			}

			internal Button[] Buttons_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.buttons;
				}
			}

			internal override bool hasData
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					if (!matchingCriteria.hasData)
					{
						return false;
					}
					if (assignedButtonCount == 0)
					{
						while (true)
						{
							int num = -982773062;
							while (true)
							{
								switch (num ^ -982773061)
								{
								case 2:
									break;
								case 1:
									goto IL_003f;
								default:
									return false;
								}
								break;
								IL_003f:
								if (assignedAxisCount != 0)
								{
									goto end_IL_0021;
								}
								num = -982773061;
							}
							continue;
							end_IL_0021:
							break;
						}
					}
					return true;
				}
			}

			internal override bool disabled
			{
				get
				{
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.disabled;
				}
			}

			internal override bool isAllowed
			{
				get
				{
					if (!base.isAllowed)
					{
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal override Elements_Base elements_base
			{
				get
				{
					return elements;
				}
			}

			internal override IList<Platform> variants_base
			{
				get
				{
					return null;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				while (true)
				{
					int num = -1425390483;
					while (true)
					{
						switch (num ^ -1425390484)
						{
						case 2:
							break;
						case 1:
							if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
							{
								goto IL_003c;
							}
							return false;
						default:
							platformMap = this;
							return true;
						}
						break;
						IL_003c:
						num = -1425390484;
					}
				}
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				dnpkiNtLLiBereCCyOsozBfsHrW dnpkiNtLLiBereCCyOsozBfsHrW2 = new dnpkiNtLLiBereCCyOsozBfsHrW(-2);
				dnpkiNtLLiBereCCyOsozBfsHrW2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return dnpkiNtLLiBereCCyOsozBfsHrW2;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				kPtOdzrnPfVBXquhgUhSuXQSALY kPtOdzrnPfVBXquhgUhSuXQSALY2 = new kPtOdzrnPfVBXquhgUhSuXQSALY(-2);
				kPtOdzrnPfVBXquhgUhSuXQSALY2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return kPtOdzrnPfVBXquhgUhSuXQSALY2;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				int num = 0;
				int num3 = default(int);
				int elementIdentifier = default(int);
				while (true)
				{
					int num2 = -957811467;
					while (true)
					{
						switch (num2 ^ -957811469)
						{
						case 0:
							break;
						case 6:
							num2 = -957811466;
							continue;
						case 8:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = -957811465;
							continue;
						case 4:
							num2 = -957811472;
							continue;
						case 7:
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							if (num3 >= 0)
							{
								int num4;
								if (num3 >= identifiers.Length)
								{
									num2 = -957811461;
									num4 = num2;
								}
								else
								{
									num2 = -957811470;
									num4 = num2;
								}
								continue;
							}
							goto case 8;
						case 1:
							array[num] = identifiers[num3].name;
							num2 = -957811472;
							continue;
						case 2:
							elementIdentifier = elements.axes[num].elementIdentifier;
							num2 = -957811468;
							continue;
						case 3:
							num++;
							num2 = -957811466;
							continue;
						default:
							if (num >= array.Length)
							{
								return array;
							}
							goto case 2;
						}
						break;
					}
				}
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				int num2 = default(int);
				int num3 = default(int);
				string[] array = default(string[]);
				while (true)
				{
					int num = -931759792;
					while (true)
					{
						switch (num ^ -931759786)
						{
						case 4:
							break;
						case 0:
							return new string[0];
						case 5:
							num2++;
							num = -931759788;
							continue;
						case 1:
						{
							int elementIdentifier = elements.buttons[num2].elementIdentifier;
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num = -931759777;
							continue;
						}
						case 7:
							num2 = 0;
							num = -931759788;
							continue;
						case 3:
							Logger.LogError("Element identifier index is out of bounds!");
							num = -931759789;
							continue;
						case 9:
							if (num3 >= 0)
							{
								int num4;
								if (num3 >= identifiers.Length)
								{
									num = -931759787;
									num4 = num;
								}
								else
								{
									num = -931759778;
									num4 = num;
								}
								continue;
							}
							goto case 3;
						case 6:
							if (identifiers.Length >= buttonCount)
							{
								array = new string[buttonCount];
								num = -931759791;
							}
							else
							{
								num = -931759780;
							}
							continue;
						case 10:
							Logger.LogError("You have too few element identifiers!");
							num = -931759786;
							continue;
						case 8:
							array[num2] = identifiers[num3].name;
							num = -931759789;
							continue;
						default:
							if (num2 >= array.Length)
							{
								return array;
							}
							goto case 1;
						}
						break;
					}
				}
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				using (IEnumerator<Platform_Custom.Button> enumerator2 = IterateButtons().GetEnumerator())
				{
					Button button = default(Button);
					while (true)
					{
						IL_00d5:
						int num;
						int num2;
						if (enumerator2.MoveNext())
						{
							num = 2124129971;
							num2 = num;
						}
						else
						{
							num = 2124129972;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x7E9BA6B6)
							{
							case 4:
								num = 2124129971;
								continue;
							default:
								goto end_IL_0077;
							case 5:
								button = (Button)enumerator2.Current;
								num = 2124129975;
								continue;
							case 3:
								return true;
							case 1:
							{
								int num3;
								if (button.elementIdentifier == elementIdentifierId)
								{
									num = 2124129973;
									num3 = num;
								}
								else
								{
									num = 2124129974;
									num3 = num;
								}
								continue;
							}
							case 0:
								break;
							case 2:
								goto end_IL_0077;
							}
							goto IL_00d5;
							continue;
							end_IL_0077:
							break;
						}
						break;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				Axis axis = default(Axis);
				while (true)
				{
					int num = -1884202449;
					while (true)
					{
						switch (num ^ -1884202451)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
						{
							int num2 = 0;
							IEnumerator<Platform_Custom.Button> enumerator = IterateButtons().GetEnumerator();
							try
							{
								while (true)
								{
									IL_0092:
									int num3;
									int num4;
									if (!enumerator.MoveNext())
									{
										num3 = -1884202449;
										num4 = num3;
									}
									else
									{
										num3 = -1884202452;
										num4 = num3;
									}
									while (true)
									{
										switch (num3 ^ -1884202451)
										{
										case 3:
											num3 = -1884202452;
											continue;
										default:
											goto end_IL_0054;
										case 1:
										{
											Button button = (Button)enumerator.Current;
											buttons[num2] = button.elementIdentifier;
											num2++;
											num3 = -1884202451;
											continue;
										}
										case 0:
											break;
										case 2:
											goto end_IL_0054;
										}
										goto IL_0092;
										continue;
										end_IL_0054:
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
										IL_00b0:
										int num5 = -1884202452;
										while (true)
										{
											switch (num5 ^ -1884202451)
											{
											case 0:
												break;
											default:
												goto end_IL_00b5;
											case 1:
												goto IL_00ce;
											case 2:
												goto end_IL_00b5;
											}
											goto IL_00b0;
											IL_00ce:
											enumerator.Dispose();
											num5 = -1884202449;
											continue;
											end_IL_00b5:
											break;
										}
										break;
									}
								}
							}
							num2 = 0;
							using (IEnumerator<Platform_Custom.Axis> enumerator2 = IterateAxes().GetEnumerator())
							{
								while (true)
								{
									int num6;
									int num7;
									if (enumerator2.MoveNext())
									{
										num6 = -1884202450;
										num7 = num6;
									}
									else
									{
										num6 = -1884202452;
										num7 = num6;
									}
									while (true)
									{
										switch (num6 ^ -1884202451)
										{
										case 2:
											num6 = -1884202450;
											continue;
										default:
											return;
										case 4:
											break;
										case 0:
											axes[num2] = axis.elementIdentifier;
											num2++;
											num6 = -1884202455;
											continue;
										case 3:
											axis = (Axis)enumerator2.Current;
											num6 = -1884202451;
											continue;
										case 1:
											return;
										}
										break;
									}
								}
							}
						}
						}
						break;
						IL_002b:
						axes = new int[assignedAxisCount];
						num = -1884202452;
					}
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				int num2 = default(int);
				AxisCalibrationData[] array = default(AxisCalibrationData[]);
				while (true)
				{
					int num = 1970016351;
					while (true)
					{
						switch (num ^ 0x756C105C)
						{
						case 11:
							break;
						case 4:
							if (axes_orig[num2].sourceType != 1)
							{
								int num4;
								if (axes_orig[num2].sourceType == 100)
								{
									num = 1970016339;
									num4 = num;
								}
								else
								{
									num = 1970016349;
									num4 = num;
								}
								continue;
							}
							goto case 15;
						case 1:
							if (axes_orig[num2].sourceType == 0)
							{
								array[num2] = AxisCalibrationData.Default;
								num = 1970016346;
								continue;
							}
							goto case 14;
						case 5:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num = 1970016342;
							continue;
						case 15:
							array[num2] = AxisCalibrationData.Default;
							num = 1970016341;
							continue;
						case 9:
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							num = 1970016350;
							continue;
						case 12:
							array[num2].min = axes_orig[num2].axisMin;
							array[num2].max = axes_orig[num2].axisMax;
							num = 1970016345;
							continue;
						case 2:
							if (Axes_orig[num2].calibrateAxis)
							{
								array[num2].zero = axes_orig[num2].axisZero;
								num = 1970016336;
								continue;
							}
							goto case 5;
						case 10:
							num2++;
							num = 1970016340;
							continue;
						case 13:
							return null;
						case 6:
							num = 1970016345;
							continue;
						case 14:
							throw new NotImplementedException();
						case 7:
							num = 1970016340;
							continue;
						case 3:
							if (axes_orig != null)
							{
								array = new AxisCalibrationData[axes_orig.Length];
								num2 = 0;
								num = 1970016347;
							}
							else
							{
								num = 1970016337;
							}
							continue;
						case 8:
						{
							int num3;
							if (num2 >= axes_orig.Length)
							{
								num = 1970016348;
								num3 = num;
							}
							else
							{
								num = 1970016344;
								num3 = num;
							}
							continue;
						}
						default:
							return array;
						}
						break;
					}
				}
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				if (Axes_orig == null)
				{
					goto IL_000e;
				}
				goto IL_0063;
				IL_000e:
				int num = -55627423;
				goto IL_0013;
				IL_0013:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ -55627424)
					{
					case 7:
						break;
					case 9:
						axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
						num = -55627421;
						continue;
					case 0:
						goto IL_0063;
					case 8:
						if (Axes_orig[num2].sourceType == 0)
						{
							axisRanges[num2] = AxisRange.Full;
							num = -55627421;
							continue;
						}
						goto case 4;
					case 1:
						return;
					case 2:
						axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
						num = -55627418;
						continue;
					case 3:
						num2++;
						num = -55627419;
						continue;
					case 4:
						throw new Exception();
					case 6:
						if (Axes_orig[num2].sourceType == 1)
						{
							goto case 9;
						}
						goto IL_0105;
					default:
						if (num2 >= Axes_orig.Length)
						{
							return;
						}
						goto case 2;
					}
					break;
					IL_0105:
					int num3;
					if (Axes_orig[num2].sourceType == 100)
					{
						num = -55627415;
						num3 = num;
					}
					else
					{
						num = -55627416;
						num3 = num;
					}
				}
				goto IL_000e;
				IL_0063:
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				num2 = 0;
				num = -55627419;
				goto IL_0013;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig == null)
				{
					return;
				}
				int num2 = default(int);
				while (true)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					int num = -922271147;
					while (true)
					{
						switch (num ^ -922271146)
						{
						case 2:
							num = -922271150;
							continue;
						case 0:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
							num2++;
							num = -922271145;
							continue;
						case 3:
							num2 = 0;
							num = -922271145;
							continue;
						case 4:
							break;
						default:
							if (num2 >= Buttons_orig.Length)
							{
								return;
							}
							goto case 0;
						}
						break;
					}
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				if (elements == null)
				{
					return ControllerElementType.Axis;
				}
				return elements.GetEffectiveElementIdentifierType(elementIdentifier);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				if (elements == null)
				{
					axisRange = AxisRange.Full;
					return false;
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			public override object DeepClone()
			{
				Platform_WebGL_Base platform_WebGL_Base = new Platform_WebGL_Base();
				CopyVars(platform_WebGL_Base);
				return platform_WebGL_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_WebGL_Base platform_WebGL_Base = default(Platform_WebGL_Base);
				while (true)
				{
					int num = 1388818193;
					while (true)
					{
						switch (num ^ 0x52C7AF10)
						{
						case 0:
							break;
						case 1:
							goto IL_0029;
						case 3:
							if (platform_WebGL_Base == null)
							{
								return;
							}
							goto default;
						default:
							platform_WebGL_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
							platform_WebGL_Base.elements = MiscTools.DeepClone(elements);
							return;
						}
						break;
						IL_0029:
						platform_WebGL_Base = destination as Platform_WebGL_Base;
						num = 1388818195;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_WebGL : Platform_WebGL_Base
		{
			public Platform_WebGL_Base[] variants;

			internal override IList<Platform> variants_base
			{
				get
				{
					return variants;
				}
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					int num = 0;
					while (true)
					{
						int num2 = 563133055;
						while (true)
						{
							switch (num2 ^ 0x2190BA7C)
							{
							case 5:
								break;
							case 3:
								num2 = 563133053;
								continue;
							case 0:
								goto IL_004d;
							case 4:
								return true;
							case 1:
								goto IL_0083;
							default:
								goto end_IL_001c;
							}
							break;
							IL_0083:
							int num3;
							if (num < variants.Length)
							{
								num2 = 563133052;
								num3 = num2;
							}
							else
							{
								num2 = 563133054;
								num3 = num2;
							}
							continue;
							IL_004d:
							int variantIndex2;
							if (variants[num] != null && variants[num].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
							{
								variantIndex = num;
								num2 = 563133048;
							}
							else
							{
								num++;
								num2 = 563133053;
							}
						}
						continue;
						end_IL_001c:
						break;
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_WebGL platform_WebGL = new Platform_WebGL();
				CopyVars(platform_WebGL);
				return platform_WebGL;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_WebGL platform_WebGL = destination as Platform_WebGL;
				if (platform_WebGL != null)
				{
					platform_WebGL.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		private sealed class YuAuqzbZgWDDYEvbdbtrBsulmPj : IDisposable, IEnumerator, IEnumerable, IEnumerable<Guid>, IEnumerator<Guid>
		{
			private Guid RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public HardwareJoystickMap ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int cxajIdvHgWRVzXfSJnEbjHXsCoJi;

			Guid IEnumerator<Guid>.Current
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
			IEnumerator<Guid> IEnumerable<Guid>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
				{
					goto IL_0012;
				}
				goto IL_0049;
				IL_0012:
				int num = -1267146994;
				goto IL_0017;
				IL_0017:
				YuAuqzbZgWDDYEvbdbtrBsulmPj yuAuqzbZgWDDYEvbdbtrBsulmPj = default(YuAuqzbZgWDDYEvbdbtrBsulmPj);
				while (true)
				{
					switch (num ^ -1267146997)
					{
					case 2:
						break;
					case 0:
						yuAuqzbZgWDDYEvbdbtrBsulmPj = this;
						num = -1267146993;
						continue;
					case 6:
						goto IL_0049;
					case 5:
						goto IL_0057;
					case 3:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						num = -1267146997;
						continue;
					case 1:
						yuAuqzbZgWDDYEvbdbtrBsulmPj.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = -1267146993;
						continue;
					default:
						return yuAuqzbZgWDDYEvbdbtrBsulmPj;
					}
					break;
					IL_0057:
					int num2;
					if (LzqgRXjFXvJPbHjfzyAmNfcqezXL != -2)
					{
						num = -1267146995;
						num2 = num;
					}
					else
					{
						num = -1267147000;
						num2 = num;
					}
				}
				goto IL_0012;
				IL_0049:
				yuAuqzbZgWDDYEvbdbtrBsulmPj = new YuAuqzbZgWDDYEvbdbtrBsulmPj(0);
				num = -1267146998;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Guid>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 1:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					cxajIdvHgWRVzXfSJnEbjHXsCoJi++;
					num = -873038773;
					goto IL_001f;
				case 0:
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = -873038775;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -873038776)
						{
						case 0:
							num = -873038772;
							continue;
						case 2:
							RDkWcsTpvDaNZojjIZONnoEBXPC = StringTools.ToGuid(ZzSaCQHlhEgTijsOQGwUlyKTOzqG.templateGuids[cxajIdvHgWRVzXfSJnEbjHXsCoJi]);
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						case 1:
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.templateGuids != null)
							{
								cxajIdvHgWRVzXfSJnEbjHXsCoJi = 0;
								num = -873038773;
								continue;
							}
							goto end_IL_0008;
						case 4:
							break;
						case 3:
							goto IL_00b8;
						default:
							goto end_IL_0008;
						}
						break;
						IL_00b8:
						int num2;
						if (cxajIdvHgWRVzXfSJnEbjHXsCoJi < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.templateGuids.Length)
						{
							num = -873038774;
							num2 = num;
						}
						else
						{
							num = -873038771;
							num2 = num;
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
			public YuAuqzbZgWDDYEvbdbtrBsulmPj(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class BFmRfBFfRWOemwopfcfDeLDTGbO : IDisposable, IEnumerable<ControllerElementIdentifier>, IEnumerator<ControllerElementIdentifier>, IEnumerator, IEnumerable
		{
			private ControllerElementIdentifier RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public HardwareJoystickMap ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int svZTdoqdxtiuAiaKSfUWXjcgcXUC;

			ControllerElementIdentifier IEnumerator<ControllerElementIdentifier>.Current
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
			IEnumerator<ControllerElementIdentifier> IEnumerable<ControllerElementIdentifier>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
				{
					goto IL_0012;
				}
				goto IL_0063;
				IL_0012:
				int num = 1064422870;
				goto IL_0017;
				IL_0017:
				BFmRfBFfRWOemwopfcfDeLDTGbO bFmRfBFfRWOemwopfcfDeLDTGbO = default(BFmRfBFfRWOemwopfcfDeLDTGbO);
				while (true)
				{
					switch (num ^ 0x3F71CDD2)
					{
					case 3:
						break;
					case 4:
						goto IL_0038;
					case 1:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						bFmRfBFfRWOemwopfcfDeLDTGbO = this;
						num = 1064422864;
						continue;
					case 0:
						goto IL_0063;
					default:
						return bFmRfBFfRWOemwopfcfDeLDTGbO;
					}
					break;
					IL_0038:
					int num2;
					if (LzqgRXjFXvJPbHjfzyAmNfcqezXL != -2)
					{
						num = 1064422866;
						num2 = num;
					}
					else
					{
						num = 1064422867;
						num2 = num;
					}
				}
				goto IL_0012;
				IL_0063:
				bFmRfBFfRWOemwopfcfDeLDTGbO = new BFmRfBFfRWOemwopfcfDeLDTGbO(0);
				bFmRfBFfRWOemwopfcfDeLDTGbO.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = 1064422864;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerElementIdentifier>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
				while (true)
				{
					int num = 774239163;
					while (true)
					{
						switch (num ^ 0x2E25F3B9)
						{
						case 7:
							break;
						case 3:
						{
							int num2;
							if (svZTdoqdxtiuAiaKSfUWXjcgcXUC < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elementIdentifiers.Length)
							{
								num = 774239160;
								num2 = num;
							}
							else
							{
								num = 774239167;
								num2 = num;
							}
							continue;
						}
						case 1:
							RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elementIdentifiers[svZTdoqdxtiuAiaKSfUWXjcgcXUC];
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						case 5:
							num = 774239167;
							continue;
						case 0:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							num = 774239165;
							continue;
						case 4:
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elementIdentifiers != null)
							{
								svZTdoqdxtiuAiaKSfUWXjcgcXUC = 0;
								num = 774239162;
								continue;
							}
							goto default;
						case 2:
							switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 1:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								svZTdoqdxtiuAiaKSfUWXjcgcXUC++;
								num = 774239162;
								continue;
							case 0:
								break;
							default:
								num = 774239164;
								continue;
							}
							goto case 0;
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
			public BFmRfBFfRWOemwopfcfDeLDTGbO(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class LtJFpSiytwDYlsqTfXHDgjIoFDRF : IDisposable, IEnumerator, IEnumerable, IEnumerable<JoystickType>, IEnumerator<JoystickType>
		{
			private JoystickType RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public HardwareJoystickMap ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int zvhWcxjEpEsfKFnQaCupmndkcpL;

			JoystickType IEnumerator<JoystickType>.Current
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
			IEnumerator<JoystickType> IEnumerable<JoystickType>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					goto IL_0023;
				}
				goto IL_004e;
				IL_0028:
				int num;
				LtJFpSiytwDYlsqTfXHDgjIoFDRF ltJFpSiytwDYlsqTfXHDgjIoFDRF = default(LtJFpSiytwDYlsqTfXHDgjIoFDRF);
				while (true)
				{
					switch (num ^ 0x6642857)
					{
					case 3:
						break;
					case 1:
						ltJFpSiytwDYlsqTfXHDgjIoFDRF = this;
						num = 107227223;
						continue;
					case 2:
						goto IL_004e;
					default:
						return ltJFpSiytwDYlsqTfXHDgjIoFDRF;
					}
					break;
				}
				goto IL_0023;
				IL_004e:
				ltJFpSiytwDYlsqTfXHDgjIoFDRF = new LtJFpSiytwDYlsqTfXHDgjIoFDRF(0);
				ltJFpSiytwDYlsqTfXHDgjIoFDRF.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = 107227223;
				goto IL_0028;
				IL_0023:
				num = 107227222;
				goto IL_0028;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JoystickType>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				default:
					num = 532634403;
					goto IL_001a;
				case 1:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					zvhWcxjEpEsfKFnQaCupmndkcpL++;
					num = 532634402;
					goto IL_001a;
				case 0:
					goto IL_00ea;
					IL_001a:
					while (true)
					{
						switch (num ^ 0x1FBF5B20)
						{
						case 0:
							break;
						case 8:
							num = 532634402;
							continue;
						case 2:
							goto IL_0055;
						case 6:
							return true;
						case 7:
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.joystickTypes != null)
							{
								zvhWcxjEpEsfKFnQaCupmndkcpL = 0;
								num = 532634408;
								continue;
							}
							goto default;
						case 5:
							RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.joystickTypes[zvhWcxjEpEsfKFnQaCupmndkcpL];
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							num = 532634406;
							continue;
						case 3:
							num = 532634401;
							continue;
						case 4:
							goto IL_00ea;
						default:
							return false;
						}
						break;
						IL_0055:
						int num2;
						if (zvhWcxjEpEsfKFnQaCupmndkcpL >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.joystickTypes.Length)
						{
							num = 532634401;
							num2 = num;
						}
						else
						{
							num = 532634405;
							num2 = num;
						}
					}
					goto default;
					IL_00ea:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					num = 532634407;
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
			public LtJFpSiytwDYlsqTfXHDgjIoFDRF(int _003C_003E1__state)
			{
				while (true)
				{
					int num = 1717810490;
					while (true)
					{
						switch (num ^ 0x6663B538)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0024;
						case 1:
							return;
						}
						break;
						IL_0024:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
						num = 1717810489;
					}
				}
			}
		}

		private sealed class ZHsmIWiMzAtCbkDjlbNfxrMHVMA : IDisposable, IEnumerator, IEnumerable, IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerator<IControllerElementIdentifierCommon_Internal>
		{
			private IControllerElementIdentifierCommon_Internal RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public HardwareJoystickMap ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int vidBsJgUgwPQGicOAyGUeZfUYaEu;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
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
			IEnumerator<IControllerElementIdentifierCommon_Internal> IEnumerable<IControllerElementIdentifierCommon_Internal>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					goto IL_001c;
				}
				goto IL_0067;
				IL_0067:
				ZHsmIWiMzAtCbkDjlbNfxrMHVMA zHsmIWiMzAtCbkDjlbNfxrMHVMA = new ZHsmIWiMzAtCbkDjlbNfxrMHVMA(0);
				int num = -1934099895;
				goto IL_0021;
				IL_001c:
				num = -1934099893;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ -1934099896)
					{
					case 0:
						break;
					case 3:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						num = -1934099891;
						continue;
					case 1:
						zHsmIWiMzAtCbkDjlbNfxrMHVMA.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = -1934099894;
						continue;
					case 4:
						goto IL_0067;
					case 5:
						zHsmIWiMzAtCbkDjlbNfxrMHVMA = this;
						num = -1934099894;
						continue;
					default:
						return zHsmIWiMzAtCbkDjlbNfxrMHVMA;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<IControllerElementIdentifierCommon_Internal>)this).GetEnumerator();
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
					if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elementIdentifiers == null)
					{
						num = 388143132;
						num2 = num;
					}
					else
					{
						num = 388143129;
						num2 = num;
					}
					goto IL_001f;
				}
				case 1:
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						vidBsJgUgwPQGicOAyGUeZfUYaEu++;
						num = 388143130;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ 0x17229818)
						{
						case 3:
							num = 388143133;
							continue;
						case 5:
							break;
						case 1:
							vidBsJgUgwPQGicOAyGUeZfUYaEu = 0;
							num = 388143130;
							continue;
						case 0:
							RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elementIdentifiers[vidBsJgUgwPQGicOAyGUeZfUYaEu];
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						case 2:
							goto IL_00ba;
						default:
							goto end_IL_0008;
						}
						break;
						IL_00ba:
						int num3;
						if (vidBsJgUgwPQGicOAyGUeZfUYaEu < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elementIdentifiers.Length)
						{
							num = 388143128;
							num3 = num;
						}
						else
						{
							num = 388143132;
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
			public ZHsmIWiMzAtCbkDjlbNfxrMHVMA(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string controllerName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string editorControllerName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string description;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string controllerGuid;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string[] templateGuids;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool hideInLists;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private JoystickType[] joystickTypes;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ControllerElementIdentifier[] elementIdentifiers;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CompoundElement[] compoundElements;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_DirectInput directInput;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_RawInput rawInput;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_XInput xInput;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_OSX osx;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Linux linux;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_WindowsUWP windowsUWP;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_Windows;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_WindowsUWP;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_OSX;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_Linux;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_Linux_PreConfigured;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_Android;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_iOS;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_Blackberry;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_WindowsPhone8;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_XBox360;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_XBoxOne;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_PS3;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_PS4;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_PSM;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_PSVita;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_Wii;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_WiiU;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_AmazonFireTV;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_RazerForgeTV;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_WebGL webGL;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Ouya ouya;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_XboxOne xboxOne;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_PS4 ps4;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_NintendoSwitch nintendoSwitch;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_InternalDriver internalDriver;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_SDL2 sdl2_Linux;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_SDL2 sdl2_Windows;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_SDL2 sdl2_OSX;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int elementIdentifierIdCounter;

		public string ControllerName
		{
			get
			{
				return controllerName;
			}
		}

		public string EditorControllerName
		{
			get
			{
				return editorControllerName;
			}
		}

		public Guid Guid
		{
			get
			{
				return StringTools.ToGuid(controllerGuid);
			}
		}

		public IEnumerable<Guid> TemplateGuids
		{
			get
			{
				YuAuqzbZgWDDYEvbdbtrBsulmPj yuAuqzbZgWDDYEvbdbtrBsulmPj = new YuAuqzbZgWDDYEvbdbtrBsulmPj(-2);
				yuAuqzbZgWDDYEvbdbtrBsulmPj.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return yuAuqzbZgWDDYEvbdbtrBsulmPj;
			}
		}

		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				BFmRfBFfRWOemwopfcfDeLDTGbO bFmRfBFfRWOemwopfcfDeLDTGbO = new BFmRfBFfRWOemwopfcfDeLDTGbO(-2);
				bFmRfBFfRWOemwopfcfDeLDTGbO.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return bFmRfBFfRWOemwopfcfDeLDTGbO;
			}
		}

		public int elementIdentifierCount
		{
			get
			{
				if (elementIdentifiers == null)
				{
					return 0;
				}
				return elementIdentifiers.Length;
			}
		}

		public bool HideInLists
		{
			get
			{
				return hideInLists;
			}
		}

		internal IEnumerable<JoystickType> JoystickTypes
		{
			get
			{
				LtJFpSiytwDYlsqTfXHDgjIoFDRF ltJFpSiytwDYlsqTfXHDgjIoFDRF = new LtJFpSiytwDYlsqTfXHDgjIoFDRF(-2);
				ltJFpSiytwDYlsqTfXHDgjIoFDRF.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return ltJFpSiytwDYlsqTfXHDgjIoFDRF;
			}
		}

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			get
			{
				ZHsmIWiMzAtCbkDjlbNfxrMHVMA zHsmIWiMzAtCbkDjlbNfxrMHVMA = new ZHsmIWiMzAtCbkDjlbNfxrMHVMA(-2);
				zHsmIWiMzAtCbkDjlbNfxrMHVMA.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return zHsmIWiMzAtCbkDjlbNfxrMHVMA;
			}
		}

		public HardwareJoystickMap()
		{
			if (joystickTypes == null || joystickTypes.Length == 0)
			{
				JoystickType[] array = new JoystickType[1];
				joystickTypes = array;
			}
			if (directInput == null)
			{
				directInput = new Platform_DirectInput();
			}
			if (rawInput == null)
			{
				rawInput = new Platform_RawInput();
			}
			if (xInput == null)
			{
				xInput = new Platform_XInput();
			}
			if (osx == null)
			{
				osx = new Platform_OSX();
			}
			if (linux == null)
			{
				linux = new Platform_Linux();
			}
			if (windowsUWP == null)
			{
				windowsUWP = new Platform_WindowsUWP();
			}
			if (fallback_Android == null)
			{
				fallback_Android = new Platform_Fallback();
			}
			if (fallback_Blackberry == null)
			{
				fallback_Blackberry = new Platform_Fallback();
			}
			if (fallback_iOS == null)
			{
				fallback_iOS = new Platform_Fallback();
			}
			if (fallback_Linux == null)
			{
				fallback_Linux = new Platform_Fallback();
			}
			if (fallback_Linux_PreConfigured == null)
			{
				fallback_Linux_PreConfigured = new Platform_Fallback();
			}
			if (fallback_OSX == null)
			{
				fallback_OSX = new Platform_Fallback();
			}
			if (fallback_PS3 == null)
			{
				fallback_PS3 = new Platform_Fallback();
			}
			if (fallback_PS4 == null)
			{
				fallback_PS4 = new Platform_Fallback();
			}
			if (fallback_PSM == null)
			{
				fallback_PSM = new Platform_Fallback();
			}
			if (fallback_PSVita == null)
			{
				fallback_PSVita = new Platform_Fallback();
			}
			if (fallback_Windows == null)
			{
				fallback_Windows = new Platform_Fallback();
			}
			if (fallback_WindowsUWP == null)
			{
				fallback_WindowsUWP = new Platform_Fallback();
			}
			if (fallback_WindowsPhone8 == null)
			{
				fallback_WindowsPhone8 = new Platform_Fallback();
			}
			if (fallback_XBox360 == null)
			{
				fallback_XBox360 = new Platform_Fallback();
			}
			if (fallback_XBoxOne == null)
			{
				fallback_XBoxOne = new Platform_Fallback();
			}
			if (fallback_Wii == null)
			{
				fallback_Wii = new Platform_Fallback();
			}
			if (fallback_WiiU == null)
			{
				fallback_WiiU = new Platform_Fallback();
			}
			if (fallback_AmazonFireTV == null)
			{
				fallback_AmazonFireTV = new Platform_Fallback();
			}
			if (fallback_RazerForgeTV == null)
			{
				fallback_RazerForgeTV = new Platform_Fallback();
			}
			if (webGL == null)
			{
				webGL = new Platform_WebGL();
			}
			if (ouya == null)
			{
				ouya = new Platform_Ouya();
			}
			if (xboxOne == null)
			{
				xboxOne = new Platform_XboxOne();
			}
			if (ps4 == null)
			{
				ps4 = new Platform_PS4();
			}
			if (nintendoSwitch == null)
			{
				nintendoSwitch = new Platform_NintendoSwitch();
			}
			if (internalDriver == null)
			{
				internalDriver = new Platform_InternalDriver();
			}
			if (sdl2_Linux == null)
			{
				sdl2_Linux = new Platform_SDL2();
			}
			if (sdl2_Windows == null)
			{
				sdl2_Windows = new Platform_SDL2();
			}
			if (sdl2_OSX == null)
			{
				sdl2_OSX = new Platform_SDL2();
			}
		}

		public HardwareJoystickMap(HardwareJoystickMap source)
			: this()
		{
			int num4 = default(int);
			int num19 = default(int);
			int num8 = default(int);
			int num5 = default(int);
			int num6 = default(int);
			int num14 = default(int);
			while (true)
			{
				int num = 806718347;
				while (true)
				{
					switch (num ^ 0x30158B98)
					{
					case 29:
						break;
					default:
						return;
					case 36:
					{
						int num16;
						if (source.ps4 == null)
						{
							num = 806718340;
							num16 = num;
						}
						else
						{
							num = 806718372;
							num16 = num;
						}
						continue;
					}
					case 30:
					{
						int num2;
						if (source.fallback_WindowsUWP != null)
						{
							num = 806718359;
							num2 = num;
						}
						else
						{
							num = 806718386;
							num2 = num;
						}
						continue;
					}
					case 32:
					{
						int num20;
						if (num4 < num19)
						{
							num = 806718390;
							num20 = num;
						}
						else
						{
							num = 806718381;
							num20 = num;
						}
						continue;
					}
					case 37:
						if (source.sdl2_Windows != null)
						{
							sdl2_Windows = MiscTools.DeepClone(source.sdl2_Windows);
							num = 806718353;
							continue;
						}
						goto case 9;
					case 8:
						if (source.osx != null)
						{
							osx = MiscTools.DeepClone(source.osx);
							num = 806718395;
							continue;
						}
						goto case 35;
					case 24:
					{
						int num22;
						if (source.fallback_WiiU != null)
						{
							num = 806718351;
							num22 = num;
						}
						else
						{
							num = 806718349;
							num22 = num;
						}
						continue;
					}
					case 6:
						fallback_PS3 = MiscTools.DeepClone(fallback_PS3);
						num = 806718354;
						continue;
					case 48:
					{
						int num13;
						if (source.fallback_PS3 != null)
						{
							num = 806718366;
							num13 = num;
						}
						else
						{
							num = 806718354;
							num13 = num;
						}
						continue;
					}
					case 12:
						if (source.fallback_Blackberry != null)
						{
							fallback_Blackberry = MiscTools.DeepClone(fallback_Blackberry);
							num = 806718382;
							continue;
						}
						goto case 54;
					case 54:
						if (source.fallback_iOS != null)
						{
							fallback_iOS = MiscTools.DeepClone(fallback_iOS);
							num = 806718362;
							continue;
						}
						goto case 2;
					case 28:
						if (source.internalDriver != null)
						{
							internalDriver = MiscTools.DeepClone(source.internalDriver);
							num = 806718358;
							continue;
						}
						goto case 14;
					case 51:
						if (source.fallback_PSM != null)
						{
							fallback_PSM = MiscTools.DeepClone(fallback_PSM);
							num = 806718343;
							continue;
						}
						goto case 31;
					case 41:
						elementIdentifierIdCounter = source.elementIdentifierIdCounter;
						if (source.compoundElements != null)
						{
							num8 = source.compoundElements.Length;
							num = 806718365;
							continue;
						}
						goto case 57;
					case 52:
						fallback_AmazonFireTV = MiscTools.DeepClone(fallback_AmazonFireTV);
						num = 806718350;
						continue;
					case 19:
						controllerGuid = source.controllerGuid;
						if (source.templateGuids != null)
						{
							num19 = source.templateGuids.Length;
							num = 806718346;
							continue;
						}
						goto case 53;
					case 34:
						windowsUWP = MiscTools.DeepClone(source.windowsUWP);
						num = 806718363;
						continue;
					case 10:
						if (source.fallback_PS4 != null)
						{
							fallback_PS4 = MiscTools.DeepClone(fallback_PS4);
							num = 806718379;
							continue;
						}
						goto case 51;
					case 60:
						ps4 = MiscTools.DeepClone(source.ps4);
						num = 806718340;
						continue;
					case 25:
						fallback_Android = MiscTools.DeepClone(fallback_Android);
						num = 806718356;
						continue;
					case 18:
						templateGuids = new string[num19];
						num4 = 0;
						num = 806718392;
						continue;
					case 1:
					{
						int num23;
						if (num5 >= num8)
						{
							num = 806718369;
							num23 = num;
						}
						else
						{
							num = 806718398;
							num23 = num;
						}
						continue;
					}
					case 42:
						if (source.fallback_OSX != null)
						{
							fallback_OSX = MiscTools.DeepClone(fallback_OSX);
							num = 806718368;
							continue;
						}
						goto case 56;
					case 31:
						if (source.fallback_PSVita != null)
						{
							fallback_PSVita = MiscTools.DeepClone(fallback_PSVita);
							num = 806718367;
							continue;
						}
						goto case 7;
					case 5:
						compoundElements = new CompoundElement[num8];
						num = 806718371;
						continue;
					case 15:
						fallback_WindowsUWP = MiscTools.DeepClone(fallback_WindowsUWP);
						num = 806718386;
						continue;
					case 50:
						rawInput = MiscTools.DeepClone(rawInput);
						num = 806718387;
						continue;
					case 55:
					{
						int num17;
						if (source.rawInput != null)
						{
							num = 806718378;
							num17 = num;
						}
						else
						{
							num = 806718387;
							num17 = num;
						}
						continue;
					}
					case 4:
						directInput = MiscTools.DeepClone(source.directInput);
						num = 806718383;
						continue;
					case 39:
					{
						int num15;
						if (num6 < num14)
						{
							num = 806718370;
							num15 = num;
						}
						else
						{
							num = 806718385;
							num15 = num;
						}
						continue;
					}
					case 13:
						if (source.fallback_Linux_PreConfigured != null)
						{
							fallback_Linux_PreConfigured = MiscTools.DeepClone(fallback_Linux_PreConfigured);
							num = 806718376;
							continue;
						}
						goto case 48;
					case 57:
					{
						joystickTypes = ArrayTools.ShallowCopy(source.joystickTypes);
						int num10;
						if (source.directInput == null)
						{
							num = 806718383;
							num10 = num;
						}
						else
						{
							num = 806718364;
							num10 = num;
						}
						continue;
					}
					case 0:
						num14 = source.elementIdentifiers.Length;
						elementIdentifiers = new ControllerElementIdentifier[num14];
						num6 = 0;
						num = 806718399;
						continue;
					case 49:
						linux = MiscTools.DeepClone(source.linux);
						num = 806718355;
						continue;
					case 23:
						fallback_WiiU = MiscTools.DeepClone(fallback_WiiU);
						num = 806718349;
						continue;
					case 9:
						if (source.sdl2_OSX != null)
						{
							sdl2_OSX = MiscTools.DeepClone(source.sdl2_OSX);
							num = 806718391;
							continue;
						}
						return;
					case 3:
						if (source.fallback_Windows != null)
						{
							fallback_Windows = MiscTools.DeepClone(fallback_Windows);
							num = 806718342;
							continue;
						}
						goto case 30;
					case 43:
					{
						int num11;
						if (source.xInput != null)
						{
							num = 806718348;
							num11 = num;
						}
						else
						{
							num = 806718352;
							num11 = num;
						}
						continue;
					}
					case 16:
						if (source.fallback_Wii != null)
						{
							fallback_Wii = MiscTools.DeepClone(fallback_Wii);
							num = 806718336;
							continue;
						}
						goto case 24;
					case 7:
						if (source.fallback_WindowsPhone8 != null)
						{
							fallback_WindowsPhone8 = MiscTools.DeepClone(fallback_WindowsPhone8);
							num = 806718345;
							continue;
						}
						goto case 17;
					case 40:
						if (source.fallback_XBoxOne != null)
						{
							fallback_XBoxOne = MiscTools.DeepClone(fallback_XBoxOne);
							num = 806718344;
							continue;
						}
						goto case 16;
					case 44:
					{
						int num9;
						if (source.fallback_AmazonFireTV == null)
						{
							num = 806718350;
							num9 = num;
						}
						else
						{
							num = 806718380;
							num9 = num;
						}
						continue;
					}
					case 11:
					{
						int num7;
						if (source.windowsUWP != null)
						{
							num = 806718394;
							num7 = num;
						}
						else
						{
							num = 806718363;
							num7 = num;
						}
						continue;
					}
					case 58:
						elementIdentifiers[num6] = elementIdentifiers[num6].Clone();
						num6++;
						num = 806718399;
						continue;
					case 20:
						xInput = MiscTools.DeepClone(source.xInput);
						num = 806718352;
						continue;
					case 38:
						compoundElements[num5] = source.compoundElements[num5].DeepClone() as CompoundElement;
						num5++;
						num = 806718361;
						continue;
					case 59:
						num5 = 0;
						num = 806718361;
						continue;
					case 46:
						templateGuids[num4] = templateGuids[num4];
						num4++;
						num = 806718392;
						continue;
					case 56:
					{
						int num21;
						if (source.fallback_Android == null)
						{
							num = 806718356;
							num21 = num;
						}
						else
						{
							num = 806718337;
							num21 = num;
						}
						continue;
					}
					case 17:
					{
						int num18;
						if (source.fallback_XBox360 == null)
						{
							num = 806718384;
							num18 = num;
						}
						else
						{
							num = 806718339;
							num18 = num;
						}
						continue;
					}
					case 21:
						if (source.nintendoSwitch != null)
						{
							nintendoSwitch = MiscTools.DeepClone(source.nintendoSwitch);
							num = 806718388;
							continue;
						}
						goto case 44;
					case 2:
						if (source.fallback_Linux != null)
						{
							fallback_Linux = MiscTools.DeepClone(fallback_Linux);
							num = 806718357;
							continue;
						}
						goto case 13;
					case 35:
					{
						int num12;
						if (source.linux != null)
						{
							num = 806718377;
							num12 = num;
						}
						else
						{
							num = 806718355;
							num12 = num;
						}
						continue;
					}
					case 33:
						if (source.webGL != null)
						{
							webGL = MiscTools.DeepClone(source.webGL);
							num = 806718389;
							continue;
						}
						goto case 45;
					case 26:
						if (source.xboxOne != null)
						{
							xboxOne = MiscTools.DeepClone(source.xboxOne);
							num = 806718396;
							continue;
						}
						goto case 36;
					case 27:
						fallback_XBox360 = MiscTools.DeepClone(fallback_XBox360);
						num = 806718384;
						continue;
					case 22:
						if (source.fallback_RazerForgeTV != null)
						{
							fallback_RazerForgeTV = MiscTools.DeepClone(fallback_RazerForgeTV);
							num = 806718393;
							continue;
						}
						goto case 33;
					case 53:
					{
						int num3;
						if (source.elementIdentifiers != null)
						{
							num = 806718360;
							num3 = num;
						}
						else
						{
							num = 806718385;
							num3 = num;
						}
						continue;
					}
					case 45:
						if (source.ouya != null)
						{
							ouya = MiscTools.DeepClone(source.ouya);
							num = 806718338;
							continue;
						}
						goto case 26;
					case 14:
						if (source.sdl2_Linux != null)
						{
							sdl2_Linux = MiscTools.DeepClone(source.sdl2_Linux);
							num = 806718397;
							continue;
						}
						goto case 37;
					case 47:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public string[] GetElementIdentifierNames()
		{
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			if (num == 0)
			{
				goto IL_0017;
			}
			string[] array = new string[num];
			int num2 = -885557544;
			goto IL_001c;
			IL_0017:
			num2 = -885557542;
			goto IL_001c;
			IL_001c:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ -885557543)
				{
				case 0:
					break;
				case 4:
					array[num3] = elementIdentifiers[num3].name;
					num3++;
					num2 = -885557541;
					continue;
				case 1:
					num3 = 0;
					num2 = -885557541;
					continue;
				case 3:
					return null;
				default:
					if (num3 >= num)
					{
						return array;
					}
					goto case 4;
				}
				break;
			}
			goto IL_0017;
		}

		[CustomObfuscation(rename = false)]
		public int[] GetElementIdentifierIds()
		{
			if (elementIdentifiers == null)
			{
				goto IL_0008;
			}
			int num = elementIdentifiers.Length;
			goto IL_0045;
			IL_003a:
			num = 0;
			goto IL_0045;
			IL_0008:
			int num2 = -1955875236;
			goto IL_000d;
			IL_000d:
			int[] array = default(int[]);
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ -1955875237)
				{
				case 4:
					break;
				case 7:
					goto IL_003a;
				case 5:
					array[num3] = elementIdentifiers[num3].id;
					num2 = -1955875237;
					continue;
				case 6:
					num3 = 0;
					num2 = -1955875239;
					continue;
				case 2:
					num2 = -1955875240;
					continue;
				case 3:
					goto IL_0080;
				case 0:
					num3++;
					num2 = -1955875240;
					continue;
				default:
					return array;
				}
				break;
				IL_0080:
				int num5;
				if (num3 >= num4)
				{
					num2 = -1955875238;
					num5 = num2;
				}
				else
				{
					num2 = -1955875234;
					num5 = num2;
				}
			}
			goto IL_0008;
			IL_0045:
			num4 = num;
			if (num4 == 0)
			{
				return null;
			}
			array = new int[num4];
			num2 = -1955875235;
			goto IL_000d;
		}

		[CustomObfuscation(rename = false)]
		public ControllerElementIdentifier GetElementIdentifier(int id)
		{
			int num = IndexOfElementIdentifier(id);
			if (num >= 0)
			{
				while (true)
				{
					int num2 = -483480561;
					while (true)
					{
						switch (num2 ^ -483480562)
						{
						case 0:
							break;
						case 1:
							goto IL_002a;
						default:
							goto end_IL_000c;
						}
						break;
						IL_002a:
						if (num >= elementIdentifiers.Length)
						{
							num2 = -483480564;
							continue;
						}
						return elementIdentifiers[num];
					}
					continue;
					end_IL_000c:
					break;
				}
			}
			return null;
		}

		[CustomObfuscation(rename = false)]
		public bool ContainsElementIdentifier(int id)
		{
			return IndexOfElementIdentifier(id) >= 0;
		}

		[CustomObfuscation(rename = false)]
		public int GetElementIdentifierInfo(ControllerElementType type, out string[] names, out int[] ids)
		{
			names = null;
			ids = null;
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			if (num == 0)
			{
				goto IL_0020;
			}
			List<ControllerElementIdentifier> list = new List<ControllerElementIdentifier>();
			int num2 = 0;
			int num3 = -1209148274;
			goto IL_0025;
			IL_0020:
			num3 = -1209148273;
			goto IL_0025;
			IL_0025:
			int count = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num3 ^ -1209148282)
				{
				case 3:
					break;
				case 10:
					if (elementIdentifiers[num2] != null && elementIdentifiers[num2].elementType == type)
					{
						list.Add(elementIdentifiers[num2]);
						num3 = -1209148281;
						continue;
					}
					goto case 1;
				case 1:
					num2++;
					num3 = -1209148282;
					continue;
				case 4:
					if (count == 0)
					{
						return 0;
					}
					names = new string[count];
					ids = new int[count];
					num3 = -1209148285;
					continue;
				case 2:
					num4++;
					num3 = -1209148287;
					continue;
				case 0:
					if (num2 >= num)
					{
						count = list.Count;
						num3 = -1209148286;
						continue;
					}
					goto case 10;
				case 9:
					return 0;
				case 8:
					num3 = -1209148282;
					continue;
				case 6:
					names[num4] = list[num4].name;
					ids[num4] = list[num4].id;
					num3 = -1209148284;
					continue;
				case 5:
					num4 = 0;
					num3 = -1209148287;
					continue;
				default:
					if (num4 >= count)
					{
						return count;
					}
					goto case 6;
				}
				break;
			}
			goto IL_0020;
		}

		[CustomObfuscation(rename = false)]
		public int GetMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			names = null;
			ids = null;
			if (elementIdentifiers == null)
			{
				goto IL_000e;
			}
			int num = elementIdentifiers.Length;
			goto IL_0062;
			IL_0062:
			int num2 = num;
			if (num2 == 0)
			{
				return 0;
			}
			List<ControllerElementIdentifier> list = new List<ControllerElementIdentifier>();
			int num3 = 0;
			int num4 = -804390432;
			goto IL_0013;
			IL_000e:
			num4 = -804390419;
			goto IL_0013;
			IL_0013:
			int num5 = default(int);
			int count = default(int);
			while (true)
			{
				switch (num4 ^ -804390425)
				{
				case 9:
					break;
				case 10:
					goto IL_0057;
				case 1:
					if (InputTools.IsMappableType(elementIdentifiers[num3].elementType))
					{
						list.Add(elementIdentifiers[num3]);
						num4 = -804390417;
						continue;
					}
					goto case 8;
				case 7:
					goto IL_00a3;
				case 4:
					ids[num5] = list[num5].id;
					num5++;
					num4 = -804390420;
					continue;
				case 8:
					num3++;
					num4 = -804390432;
					continue;
				case 0:
					return 0;
				case 12:
					ids = new int[count];
					num4 = -804390428;
					continue;
				case 5:
					names[num5] = list[num5].name;
					num4 = -804390429;
					continue;
				case 11:
					goto IL_0130;
				case 2:
					goto IL_0149;
				case 3:
					num5 = 0;
					num4 = -804390420;
					continue;
				default:
					return count;
				}
				break;
				IL_0130:
				int num6;
				if (num5 < count)
				{
					num4 = -804390430;
					num6 = num4;
				}
				else
				{
					num4 = -804390431;
					num6 = num4;
				}
				continue;
				IL_00a3:
				if (num3 >= num2)
				{
					count = list.Count;
					if (count == 0)
					{
						num4 = -804390425;
						continue;
					}
					names = new string[count];
					num4 = -804390421;
					continue;
				}
				goto IL_0149;
				IL_0149:
				int num7;
				if (elementIdentifiers[num3] != null)
				{
					num4 = -804390426;
					num7 = num4;
				}
				else
				{
					num4 = -804390417;
					num7 = num4;
				}
			}
			goto IL_000e;
			IL_0057:
			num = 0;
			goto IL_0062;
		}

		internal HardwareJoystickMap Clone()
		{
			return new HardwareJoystickMap(this);
		}

		internal int IndexOfElementIdentifier(int id)
		{
			if (elementIdentifiers == null)
			{
				return -1;
			}
			int num = 0;
			while (num < elementIdentifiers.Length)
			{
				while (true)
				{
					int num2;
					if (elementIdentifiers[num].id == id)
					{
						num2 = -573272811;
					}
					else
					{
						num++;
						num2 = -573272810;
					}
					while (true)
					{
						switch (num2 ^ -573272812)
						{
						case 0:
							num2 = -573272809;
							continue;
						case 3:
							break;
						case 1:
							return num;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return -1;
		}

		internal ControllerElementType GetEffectiveElementIdentifierType(HardwareControllerMapIdentifier hardwareMapIdentifier, int elementIdentifierId, bool isDefaultMap)
		{
			ControllerElementIdentifier elementIdentifier = GetElementIdentifier(elementIdentifierId);
			if (elementIdentifier == null)
			{
				goto IL_000b;
			}
			Platform specificPlatformMap = GetSpecificPlatformMap(hardwareMapIdentifier);
			int num = 1871625526;
			goto IL_0010;
			IL_0010:
			switch (num ^ 0x6F8EBD36)
			{
			case 2:
				break;
			case 1:
				return ControllerElementType.Axis;
			default:
				if (specificPlatformMap == null)
				{
					return ControllerElementType.Axis;
				}
				return specificPlatformMap.GetEffectiveElementIdentifierType(elementIdentifier);
			}
			goto IL_000b;
			IL_000b:
			num = 1871625527;
			goto IL_0010;
		}

		internal bool GetEffectiveAxisRange(HardwareControllerMapIdentifier hardwareMapIdentifier, int elementIdentifierId, bool isDefaultMap, out AxisRange axisRange)
		{
			axisRange = AxisRange.Full;
			ControllerElementIdentifier elementIdentifier = GetElementIdentifier(elementIdentifierId);
			if (elementIdentifier == null)
			{
				return false;
			}
			Platform specificPlatformMap = GetSpecificPlatformMap(hardwareMapIdentifier);
			if (specificPlatformMap == null)
			{
				return false;
			}
			return specificPlatformMap.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		internal void GetElementIdentifiersForControllerElements(HardwareControllerMapIdentifier hardwareMapIdentifier, bool isDefaultMap, out int[] buttons, out int[] axes)
		{
			buttons = null;
			Platform specificPlatformMap = default(Platform);
			while (true)
			{
				switch (-1570828717 ^ -1570828718)
				{
				case 0:
					continue;
				case 1:
					axes = null;
					specificPlatformMap = GetSpecificPlatformMap(hardwareMapIdentifier);
					if (specificPlatformMap == null)
					{
						return;
					}
					goto case 3;
				case 3:
					if (specificPlatformMap.assignedButtonCount <= 0)
					{
						return;
					}
					break;
				}
				break;
			}
			specificPlatformMap.GetGameElementIdentifierIdMappings(out buttons, out axes);
		}

		internal static bool Matches(Platform platform, BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (platform == null)
			{
				variantIndex = -1;
				platformMap = null;
				return false;
			}
			return platform.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
		}

		internal bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex, out Platform platformMap)
		{
			actualInputPlatform = InputPlatform.XYhwUwaOlrfFTKoMRqftWpJVYyOD;
			variantIndex = -1;
			InputSource inputSource = default(InputSource);
			while (true)
			{
				int num = -1941527231;
				while (true)
				{
					switch (num ^ -1941527226)
					{
					case 0:
						break;
					case 3:
						if (Matches(directInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
						{
							actualInputPlatform = InputPlatform.GqzyAlVbsTJEJeHcVvIVueUVgOh;
							num = -1941527230;
							continue;
						}
						if (Matches(rawInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
						{
							actualInputPlatform = InputPlatform.cZjaGiccoOfQMydNsMdhkKrlxCba;
							return true;
						}
						return false;
					case 4:
						return true;
					case 12:
						return xInput.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
					case 1:
						return false;
					case 8:
						return ps4.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
					case 9:
						return false;
					case 5:
						actualInputPlatform = InputPlatform.cZjaGiccoOfQMydNsMdhkKrlxCba;
						return true;
					case 7:
						platformMap = null;
						if (bridgedControllerHWInfo == null)
						{
							return false;
						}
						inputSource = bridgedControllerHWInfo.inputSource;
						switch (inputSource)
						{
						case InputSource.DirectInput:
							break;
						case InputSource.RawInput:
							goto IL_008c;
						case InputSource.OSX:
							goto IL_00be;
						case InputSource.NintendoSwitch:
							goto IL_00f3;
						case InputSource.Linux:
							goto IL_0141;
						case InputSource.XInput:
							goto IL_0177;
						default:
							goto IL_0207;
						case InputSource.WindowsUWP:
							goto IL_022a;
						case InputSource.Fallback:
						case InputSource.Fallback_PreConfigured:
							platformMap = FindFallbackMatch(bridgedControllerHWInfo, strictMatch, isDefaultMap, out actualInputPlatform, out variantIndex);
							return platformMap != null;
						case InputSource.WebGL:
							goto IL_0264;
						case InputSource.Ouya:
							goto IL_0285;
						case InputSource.XboxOne:
							goto IL_02a6;
						case InputSource.PS4:
							goto IL_02e5;
						case InputSource.SDL2:
							platformMap = FindSDL2Match(bridgedControllerHWInfo, strictMatch, isDefaultMap, out actualInputPlatform, out variantIndex);
							return platformMap != null;
						case InputSource.Steam:
							actualInputPlatform = InputPlatform.ZANtQEkaOaQcYhPlpfZCiDwahfr;
							return false;
						case (InputSource)10:
						case (InputSource)11:
						case (InputSource)12:
						case (InputSource)13:
						case (InputSource)14:
						case (InputSource)15:
						case (InputSource)16:
						case (InputSource)17:
						case (InputSource)23:
							goto IL_0334;
						}
						goto case 3;
					case 11:
						return false;
					case 6:
						if (inputSource == InputSource.InternalDriver)
						{
							if (internalDriver == null)
							{
								num = -1941527220;
								continue;
							}
							actualInputPlatform = InputPlatform.sstGbYqotnUAodZSsTwHEEbgiSR;
							return internalDriver.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						}
						goto IL_0334;
					case 2:
						return xboxOne.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
					default:
						{
							return false;
						}
						IL_0207:
						num = -1941527232;
						continue;
						IL_0177:
						if (xInput == null)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.ovCPWlBsEvuzkIMqmgTZqxNDFgV;
						num = -1941527222;
						continue;
						IL_008c:
						if (Matches(rawInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
						{
							num = -1941527229;
							continue;
						}
						if (Matches(directInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
						{
							actualInputPlatform = InputPlatform.GqzyAlVbsTJEJeHcVvIVueUVgOh;
							return true;
						}
						return false;
						IL_0334:
						throw new NotImplementedException();
						IL_02e5:
						if (ps4 != null)
						{
							actualInputPlatform = InputPlatform.ehbCQljLDvgiNbFTeUQYWfWVaDsb;
							num = -1941527218;
						}
						else
						{
							num = -1941527225;
						}
						continue;
						IL_0141:
						if (linux == null)
						{
							num = -1941527219;
							continue;
						}
						actualInputPlatform = InputPlatform.enTXCIFwxjKGOTdUNPCUNyQZEQr;
						return linux.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						IL_02a6:
						if (xboxOne == null)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.pZrRySJpwHiBEaxxGokWuXWJhUS;
						num = -1941527228;
						continue;
						IL_0285:
						if (ouya == null)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.gGGEnVSWvgaFbdVaVnlfMbOTkJsO;
						return ouya.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						IL_00f3:
						if (nintendoSwitch == null)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.nbOhDhcnKQfYJsEjsPifPczVJFzj;
						return nintendoSwitch.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						IL_0264:
						if (webGL == null)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.TxrUiyPjtJdznKpsXcVgtexpIzI;
						return webGL.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						IL_00be:
						if (osx == null)
						{
							num = -1941527217;
							continue;
						}
						actualInputPlatform = InputPlatform.qzTTwsqmkFsXzptVNiHLyLYTdWR;
						return osx.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						IL_022a:
						if (windowsUWP == null)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.lVqnUVyYsKsHZMKeqoJPZENWgClF;
						return windowsUWP.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
					}
					break;
				}
			}
		}

		internal HardwareJoystickMap_InputManager GetDefaultHardwareJoystickMap_InputManager(InputSource inputSource)
		{
			int num;
			Platform platform = default(Platform);
			InputPlatform actualInputPlatform = default(InputPlatform);
			int variantIndex;
			switch (inputSource)
			{
			default:
				num = 653665090;
				goto IL_0082;
			case InputSource.XInput:
				goto IL_0112;
			case InputSource.PS4:
				goto IL_0128;
			case InputSource.None:
				goto IL_013c;
			case InputSource.Steam:
			case InputSource.UnityKeyboardAndMouse:
				throw new NotImplementedException();
			case InputSource.DirectInput:
				goto IL_0158;
			case InputSource.SDL2:
				goto IL_018e;
			case InputSource.Linux:
				goto IL_01a5;
			case InputSource.NintendoSwitch:
				goto IL_01b9;
			case InputSource.WebGL:
				goto IL_01cd;
			case (InputSource)10:
			case (InputSource)11:
			case (InputSource)12:
			case (InputSource)13:
			case (InputSource)14:
			case (InputSource)15:
			case (InputSource)16:
			case (InputSource)17:
			case (InputSource)23:
				goto IL_01e1;
			case InputSource.OSX:
				goto IL_01f1;
			case InputSource.InternalDriver:
				goto IL_0204;
			case InputSource.Ouya:
				goto IL_0218;
			case InputSource.XboxOne:
				goto IL_023d;
			case InputSource.WindowsUWP:
				goto IL_0262;
			case InputSource.Fallback:
			case InputSource.Fallback_PreConfigured:
				goto IL_026e;
			case InputSource.RawInput:
				goto IL_0285;
				IL_0082:
				while (true)
				{
					switch (num ^ 0x26F62353)
					{
					case 21:
						break;
					case 25:
						num = 653665111;
						continue;
					case 12:
						num = 653665111;
						continue;
					case 6:
						goto IL_0112;
					case 18:
						num = 653665111;
						continue;
					case 0:
						goto IL_0128;
					case 11:
						goto IL_013c;
					case 26:
						num = 653665111;
						continue;
					case 10:
						goto IL_0158;
					case 2:
						num = 653665111;
						continue;
					case 9:
						num = 653665111;
						continue;
					case 17:
						goto IL_017f;
					case 20:
						goto IL_018e;
					case 22:
						goto IL_01a5;
					case 16:
						goto IL_01b9;
					case 23:
						goto IL_01cd;
					case 7:
						goto IL_01e1;
					case 19:
						goto IL_01f1;
					case 13:
						goto IL_0204;
					case 5:
						goto IL_0218;
					case 14:
						platform = xInput;
						num = 653665111;
						continue;
					case 24:
						goto IL_023d;
					case 15:
						platform = windowsUWP;
						num = 653665111;
						continue;
					case 8:
						goto IL_0262;
					case 1:
						goto IL_026e;
					case 3:
						goto IL_0285;
					default:
						goto IL_0298;
					}
					break;
					IL_017f:
					if (inputSource != InputSource.Custom)
					{
						num = 653665108;
						continue;
					}
					goto case InputSource.Steam;
				}
				goto default;
				IL_0298:
				if (platform == null)
				{
					return null;
				}
				return platform.ToHardwareJoystickMap_InputManager(this, inputSource, actualInputPlatform, -1);
				IL_0128:
				actualInputPlatform = InputPlatform.ehbCQljLDvgiNbFTeUQYWfWVaDsb;
				platform = ps4;
				num = 653665111;
				goto IL_0082;
				IL_0112:
				actualInputPlatform = InputPlatform.ovCPWlBsEvuzkIMqmgTZqxNDFgV;
				num = 653665117;
				goto IL_0082;
				IL_0285:
				actualInputPlatform = InputPlatform.cZjaGiccoOfQMydNsMdhkKrlxCba;
				platform = rawInput;
				num = 653665097;
				goto IL_0082;
				IL_026e:
				platform = FindFallbackMap(inputSource, true, out actualInputPlatform, out variantIndex);
				num = 653665119;
				goto IL_0082;
				IL_0262:
				actualInputPlatform = InputPlatform.lVqnUVyYsKsHZMKeqoJPZENWgClF;
				num = 653665116;
				goto IL_0082;
				IL_023d:
				actualInputPlatform = InputPlatform.pZrRySJpwHiBEaxxGokWuXWJhUS;
				platform = xboxOne;
				num = 653665098;
				goto IL_0082;
				IL_0218:
				actualInputPlatform = InputPlatform.gGGEnVSWvgaFbdVaVnlfMbOTkJsO;
				platform = ouya;
				num = 653665114;
				goto IL_0082;
				IL_0204:
				actualInputPlatform = InputPlatform.sstGbYqotnUAodZSsTwHEEbgiSR;
				platform = internalDriver;
				num = 653665111;
				goto IL_0082;
				IL_01f1:
				actualInputPlatform = InputPlatform.qzTTwsqmkFsXzptVNiHLyLYTdWR;
				platform = osx;
				num = 653665105;
				goto IL_0082;
				IL_01e1:
				throw new NotImplementedException();
				IL_01cd:
				actualInputPlatform = InputPlatform.TxrUiyPjtJdznKpsXcVgtexpIzI;
				platform = webGL;
				num = 653665089;
				goto IL_0082;
				IL_01b9:
				actualInputPlatform = InputPlatform.nbOhDhcnKQfYJsEjsPifPczVJFzj;
				platform = nintendoSwitch;
				num = 653665111;
				goto IL_0082;
				IL_01a5:
				actualInputPlatform = InputPlatform.enTXCIFwxjKGOTdUNPCUNyQZEQr;
				platform = linux;
				num = 653665111;
				goto IL_0082;
				IL_018e:
				platform = FindSDL2Map(inputSource, true, out actualInputPlatform, out variantIndex);
				num = 653665111;
				goto IL_0082;
				IL_0158:
				actualInputPlatform = InputPlatform.GqzyAlVbsTJEJeHcVvIVueUVgOh;
				platform = directInput;
				num = 653665111;
				goto IL_0082;
				IL_013c:
				return null;
			}
		}

		internal string[] GetTemplateGuidsOrig()
		{
			return templateGuids;
		}

		IControllerElementIdentifierCommon_Internal IHardwareControllerMap_Internal.GetElementIdentifier(int id)
		{
			return GetElementIdentifier(id);
		}

		private Platform_Fallback_Base FindFallbackMatch(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			InputSource inputSource = bridgedControllerHWInfo.inputSource;
			Rewired.Platforms.Platform platform = UnityTools.platform;
			EditorPlatform editorPlatform = UnityTools.editorPlatform;
			Rewired.Platforms.Platform platform2 = default(Rewired.Platforms.Platform);
			Platform_Fallback_Base platform_Fallback_Base = default(Platform_Fallback_Base);
			while (true)
			{
				int num = -1867852151;
				while (true)
				{
					int num5;
					switch (num ^ -1867852154)
					{
					case 20:
						break;
					case 23:
						actualInputPlatform = InputPlatform.hvteJOJvIYNkPQjlYMlvRYELJCj;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 10:
						return platform_Fallback_Base;
					case 7:
						if (platform_Fallback_Base == null)
						{
							platform_Fallback_Base = fallback_Android;
							actualInputPlatform = InputPlatform.hvteJOJvIYNkPQjlYMlvRYELJCj;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						}
						num = -1867852148;
						continue;
					case 17:
						return GetUniversalDefaultMap<Platform_Fallback_Base>(out actualInputPlatform, out variantIndex);
					case 19:
						if (platform_Fallback_Base != null)
						{
							return platform_Fallback_Base;
						}
						platform_Fallback_Base = fallback_Android;
						num = -1867852143;
						continue;
					case 11:
						actualInputPlatform = InputPlatform.GwzdkTbFocQuylCSAbRrAldwZoB;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 18:
						switch (platform2)
						{
						case Rewired.Platforms.Platform.Webplayer:
							break;
						default:
							goto IL_00f8;
						case Rewired.Platforms.Platform.RazerForgeTV:
							goto IL_0122;
						case Rewired.Platforms.Platform.Xbox360:
							goto IL_01a4;
						case Rewired.Platforms.Platform.Windows:
						case Rewired.Platforms.Platform.WindowsAppStore:
							goto IL_028b;
						case Rewired.Platforms.Platform.PSVita:
							platform_Fallback_Base = fallback_PSVita;
							actualInputPlatform = InputPlatform.hqtGxMrtQLDZyGfXPXekSiBPTBa;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.Wii:
							goto IL_02cb;
						case Rewired.Platforms.Platform.Android:
							platform_Fallback_Base = fallback_Android;
							actualInputPlatform = InputPlatform.hvteJOJvIYNkPQjlYMlvRYELJCj;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.iOS:
						case Rewired.Platforms.Platform.tvOS:
							platform_Fallback_Base = fallback_iOS;
							actualInputPlatform = InputPlatform.VdrZcVyweUFNIzNbSheVCltJDtNo;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.Blackberry:
							platform_Fallback_Base = fallback_Blackberry;
							actualInputPlatform = InputPlatform.PLWBZITRYDmOzPwdONuXhmYqiiY;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.WindowsPhone8:
							goto IL_0373;
						case Rewired.Platforms.Platform.WiiU:
							platform_Fallback_Base = fallback_WiiU;
							actualInputPlatform = InputPlatform.lQxcglqwyjmvSaspdllCCCoyxtP;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.AmazonFireTV:
							goto IL_03bf;
						case Rewired.Platforms.Platform.WindowsUWP:
							platform_Fallback_Base = fallback_WindowsUWP;
							actualInputPlatform = InputPlatform.JAzQtbHLOTHOvWCjKBtuYzhnFoW;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.OSX:
							platform_Fallback_Base = fallback_OSX;
							actualInputPlatform = InputPlatform.zqQYkhsnXyLqDuhSVwAvqSUVNyY;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.Linux:
							goto IL_0417;
						case Rewired.Platforms.Platform.PS3:
							platform_Fallback_Base = fallback_PS3;
							actualInputPlatform = InputPlatform.pvkAQXroaTtXJRXQEyCZuMOIYDy;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.PS4:
							platform_Fallback_Base = fallback_PS4;
							actualInputPlatform = InputPlatform.sUEnaBPRoRGbjFzftPXWNFCTHYrT;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.PSMobile:
							goto IL_0505;
						case Rewired.Platforms.Platform.XboxOne:
							goto IL_0547;
						}
						if (UnityTools.webplayerPlatform == WebplayerPlatform.Windows)
						{
							platform_Fallback_Base = fallback_Windows;
							actualInputPlatform = InputPlatform.lcPnzROWQvkxuEjIsRvoYRWoVXg;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						}
						if (UnityTools.webplayerPlatform == WebplayerPlatform.OSX)
						{
							platform_Fallback_Base = fallback_OSX;
							actualInputPlatform = InputPlatform.zqQYkhsnXyLqDuhSVwAvqSUVNyY;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						}
						goto IL_00f8;
					case 4:
						platform_Fallback_Base = null;
						num = -1867852139;
						continue;
					case 6:
						if (platform_Fallback_Base != null)
						{
							return platform_Fallback_Base;
						}
						goto IL_0275;
					case 25:
						goto IL_028b;
					case 16:
						actualInputPlatform = InputPlatform.BipyCxjgAgSAqipXvprsKMIDFLB;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 1:
						platform_Fallback_Base = TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						num = -1867852134;
						continue;
					case 15:
						switch (editorPlatform)
						{
						case EditorPlatform.Windows:
							goto IL_0384;
						case EditorPlatform.Linux:
							goto IL_0434;
						case EditorPlatform.OSX:
							goto IL_0440;
						}
						num = -1867852145;
						continue;
					case 8:
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 22:
						goto IL_0384;
					case 13:
						actualInputPlatform = InputPlatform.lGRAMGWQvEWJrLMuXvesWaypSQD;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 0:
						actualInputPlatform = InputPlatform.lcPnzROWQvkxuEjIsRvoYRWoVXg;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 24:
						goto IL_0434;
					case 3:
						goto IL_0440;
					case 21:
						if (platform_Fallback_Base != null)
						{
							int num6;
							if (actualInputPlatform != InputPlatform.BcegoeXnuzLZifdCXJVBpApAEkl)
							{
								num = -1867852131;
								num6 = num;
							}
							else
							{
								num = -1867852159;
								num6 = num;
							}
							continue;
						}
						goto case 7;
					case 26:
					{
						actualInputPlatform = InputPlatform.BcegoeXnuzLZifdCXJVBpApAEkl;
						platform_Fallback_Base = TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						int num4;
						if (!isDefaultMap)
						{
							num = -1867852159;
							num4 = num;
						}
						else
						{
							num = -1867852141;
							num4 = num;
						}
						continue;
					}
					case 5:
					{
						int num3;
						if (actualInputPlatform != InputPlatform.keUAQKhzfbmmrvWZLLVpjBiRDILF)
						{
							num = -1867852158;
							num3 = num;
						}
						else
						{
							num = -1867852139;
							num3 = num;
						}
						continue;
					}
					case 9:
						platform2 = platform;
						num = -1867852140;
						continue;
					case 2:
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 28:
						if (isDefaultMap && platform_Fallback_Base != null && actualInputPlatform != InputPlatform.PlRoHlHsMxRUbOLKpRxEuAkedAG)
						{
							platform_Fallback_Base = null;
							num = -1867852160;
							continue;
						}
						goto case 6;
					case 12:
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 27:
						platform_Fallback_Base = null;
						num = -1867852159;
						continue;
					case 29:
					{
						int num2;
						if (platform_Fallback_Base != null)
						{
							num = -1867852157;
							num2 = num;
						}
						else
						{
							num = -1867852139;
							num2 = num;
						}
						continue;
					}
					default:
						{
							actualInputPlatform = InputPlatform.XYhwUwaOlrfFTKoMRqftWpJVYyOD;
							return null;
						}
						IL_0275:
						platform_Fallback_Base = fallback_Linux;
						actualInputPlatform = InputPlatform.eUabiPKSSDjieZEJgxLjddewVcsF;
						num = -1867852146;
						continue;
						IL_03bf:
						platform_Fallback_Base = fallback_AmazonFireTV;
						num = -1867852132;
						continue;
						IL_0373:
						platform_Fallback_Base = fallback_WindowsPhone8;
						num = -1867852147;
						continue;
						IL_02cb:
						platform_Fallback_Base = fallback_Wii;
						num = -1867852149;
						continue;
						IL_028b:
						platform_Fallback_Base = fallback_Windows;
						num = -1867852154;
						continue;
						IL_01a4:
						platform_Fallback_Base = fallback_XBox360;
						actualInputPlatform = InputPlatform.JRyVneHjlMIxElqiQLQdnWbbsMb;
						num = -1867852150;
						continue;
						IL_0122:
						platform_Fallback_Base = fallback_RazerForgeTV;
						actualInputPlatform = InputPlatform.keUAQKhzfbmmrvWZLLVpjBiRDILF;
						platform_Fallback_Base = TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						if (isDefaultMap)
						{
							num = -1867852133;
							num5 = num;
						}
						else
						{
							num = -1867852139;
							num5 = num;
						}
						continue;
						IL_00f8:
						if (isDefaultMap)
						{
							num = -1867852137;
							continue;
						}
						variantIndex = -1;
						num = -1867852152;
						continue;
						IL_0440:
						platform = Rewired.Platforms.Platform.OSX;
						num = -1867852145;
						continue;
						IL_0434:
						platform = Rewired.Platforms.Platform.Linux;
						num = -1867852145;
						continue;
						IL_0384:
						platform = Rewired.Platforms.Platform.Windows;
						num = -1867852145;
						continue;
						IL_0547:
						platform_Fallback_Base = fallback_XBoxOne;
						actualInputPlatform = InputPlatform.ohIXpWWVnrVVdZSDmnrfcFpOiWJc;
						num = -1867852156;
						continue;
						IL_0505:
						platform_Fallback_Base = fallback_PSM;
						num = -1867852138;
						continue;
						IL_0417:
						if (inputSource == InputSource.Fallback_PreConfigured)
						{
							platform_Fallback_Base = fallback_Linux_PreConfigured;
							actualInputPlatform = InputPlatform.PlRoHlHsMxRUbOLKpRxEuAkedAG;
							num = -1867852153;
							continue;
						}
						goto IL_0275;
					}
					break;
				}
			}
		}

		private Platform_Fallback_Base FindFallbackMap(InputSource inputSource, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			Rewired.Platforms.Platform platform = UnityTools.platform;
			int num;
			Platform_Fallback_Base platform_Fallback_Base = default(Platform_Fallback_Base);
			switch (UnityTools.editorPlatform)
			{
			default:
				num = 1741698343;
				goto IL_0025;
			case EditorPlatform.Windows:
				goto IL_0374;
			case EditorPlatform.Linux:
				goto IL_0380;
			case EditorPlatform.OSX:
				goto IL_03b6;
				IL_0025:
				while (true)
				{
					switch (num ^ 0x67D03531)
					{
					case 23:
						break;
					case 20:
						actualInputPlatform = InputPlatform.BcegoeXnuzLZifdCXJVBpApAEkl;
						num = 1741698360;
						continue;
					case 18:
						goto IL_00a4;
					case 9:
						platform_Fallback_Base = TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
						num = 1741698362;
						continue;
					case 14:
						actualInputPlatform = InputPlatform.hqtGxMrtQLDZyGfXPXekSiBPTBa;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 22:
						num = 1741698361;
						continue;
					case 21:
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 6:
						goto end_IL_000f;
					case 12:
						actualInputPlatform = InputPlatform.zqQYkhsnXyLqDuhSVwAvqSUVNyY;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 19:
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 16:
						goto IL_01e1;
					case 0:
						goto IL_01fc;
					case 4:
						actualInputPlatform = InputPlatform.BipyCxjgAgSAqipXvprsKMIDFLB;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 3:
						if (actualInputPlatform != InputPlatform.PlRoHlHsMxRUbOLKpRxEuAkedAG)
						{
							platform_Fallback_Base = null;
							num = 1741698345;
							continue;
						}
						goto IL_03df;
					case 8:
						goto IL_024f;
					case 11:
						if (isDefaultMap && platform_Fallback_Base != null && actualInputPlatform != InputPlatform.BcegoeXnuzLZifdCXJVBpApAEkl)
						{
							platform_Fallback_Base = null;
							num = 1741698359;
							continue;
						}
						goto end_IL_000f;
					case 10:
						platform_Fallback_Base = TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
						num = 1741698353;
						continue;
					case 1:
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 2:
						goto IL_0374;
					case 17:
						goto IL_0380;
					case 15:
						goto IL_038c;
					case 13:
						goto IL_03b6;
					case 5:
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 24:
						goto IL_03df;
					default:
						actualInputPlatform = InputPlatform.XYhwUwaOlrfFTKoMRqftWpJVYyOD;
						return null;
					}
					break;
					IL_024f:
					switch (platform)
					{
					case Rewired.Platforms.Platform.Wii:
						platform_Fallback_Base = fallback_Wii;
						actualInputPlatform = InputPlatform.lGRAMGWQvEWJrLMuXvesWaypSQD;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.WiiU:
						platform_Fallback_Base = fallback_WiiU;
						actualInputPlatform = InputPlatform.lQxcglqwyjmvSaspdllCCCoyxtP;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.AmazonFireTV:
						break;
					case Rewired.Platforms.Platform.OSX:
						goto IL_0139;
					case Rewired.Platforms.Platform.RazerForgeTV:
						goto IL_0166;
					case Rewired.Platforms.Platform.Linux:
						goto IL_01ad;
					case Rewired.Platforms.Platform.Flash:
					case Rewired.Platforms.Platform.WebGL:
					case Rewired.Platforms.Platform.Tizen:
					case Rewired.Platforms.Platform.Xenon:
					case Rewired.Platforms.Platform.STV:
					case Rewired.Platforms.Platform.NACL:
					case Rewired.Platforms.Platform.NACL_Webplayer:
					case Rewired.Platforms.Platform.NACL_Chrome:
					case Rewired.Platforms.Platform.SamsungTV:
					case Rewired.Platforms.Platform.Pepper:
					case Rewired.Platforms.Platform.Windows81Store:
					case Rewired.Platforms.Platform.N3DS:
					case Rewired.Platforms.Platform.Switch:
						goto IL_01e1;
					case Rewired.Platforms.Platform.PSVita:
						goto IL_0229;
					default:
						goto IL_02ea;
					case Rewired.Platforms.Platform.Webplayer:
						goto IL_0337;
					case Rewired.Platforms.Platform.Windows:
					case Rewired.Platforms.Platform.WindowsAppStore:
						goto IL_038c;
					case Rewired.Platforms.Platform.WindowsUWP:
						goto IL_03a2;
					case Rewired.Platforms.Platform.PSMobile:
						goto IL_03ce;
					case Rewired.Platforms.Platform.Android:
						platform_Fallback_Base = fallback_Android;
						actualInputPlatform = InputPlatform.hvteJOJvIYNkPQjlYMlvRYELJCj;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.iOS:
					case Rewired.Platforms.Platform.tvOS:
						platform_Fallback_Base = fallback_iOS;
						actualInputPlatform = InputPlatform.VdrZcVyweUFNIzNbSheVCltJDtNo;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.Blackberry:
						platform_Fallback_Base = fallback_Blackberry;
						actualInputPlatform = InputPlatform.PLWBZITRYDmOzPwdONuXhmYqiiY;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.WindowsPhone8:
						platform_Fallback_Base = fallback_WindowsPhone8;
						actualInputPlatform = InputPlatform.GwzdkTbFocQuylCSAbRrAldwZoB;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.Xbox360:
						platform_Fallback_Base = fallback_XBox360;
						actualInputPlatform = InputPlatform.JRyVneHjlMIxElqiQLQdnWbbsMb;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.XboxOne:
						platform_Fallback_Base = fallback_XBoxOne;
						actualInputPlatform = InputPlatform.ohIXpWWVnrVVdZSDmnrfcFpOiWJc;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.PS3:
						platform_Fallback_Base = fallback_PS3;
						actualInputPlatform = InputPlatform.pvkAQXroaTtXJRXQEyCZuMOIYDy;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.PS4:
						goto IL_049c;
					}
					platform_Fallback_Base = fallback_AmazonFireTV;
					num = 1741698341;
					continue;
					IL_049c:
					platform_Fallback_Base = fallback_PS4;
					actualInputPlatform = InputPlatform.sUEnaBPRoRGbjFzftPXWNFCTHYrT;
					num = 1741698356;
					continue;
					IL_03ce:
					platform_Fallback_Base = fallback_PSM;
					num = 1741698357;
					continue;
					IL_03a2:
					platform_Fallback_Base = fallback_WindowsUWP;
					actualInputPlatform = InputPlatform.JAzQtbHLOTHOvWCjKBtuYzhnFoW;
					num = 1741698340;
					continue;
					IL_038c:
					platform_Fallback_Base = fallback_Windows;
					actualInputPlatform = InputPlatform.lcPnzROWQvkxuEjIsRvoYRWoVXg;
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					IL_0337:
					if (UnityTools.webplayerPlatform == WebplayerPlatform.Windows)
					{
						platform_Fallback_Base = fallback_Windows;
						actualInputPlatform = InputPlatform.lcPnzROWQvkxuEjIsRvoYRWoVXg;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					}
					if (UnityTools.webplayerPlatform == WebplayerPlatform.OSX)
					{
						platform_Fallback_Base = fallback_OSX;
						actualInputPlatform = InputPlatform.zqQYkhsnXyLqDuhSVwAvqSUVNyY;
						num = 1741698338;
						continue;
					}
					goto IL_01e1;
					IL_0139:
					platform_Fallback_Base = fallback_OSX;
					num = 1741698365;
					continue;
					IL_03df:
					if (platform_Fallback_Base != null)
					{
						return platform_Fallback_Base;
					}
					goto IL_03e4;
					IL_01fc:
					if (isDefaultMap)
					{
						int num2;
						if (platform_Fallback_Base != null)
						{
							num = 1741698354;
							num2 = num;
						}
						else
						{
							num = 1741698345;
							num2 = num;
						}
						continue;
					}
					goto IL_03df;
					IL_02ea:
					num = 1741698337;
					continue;
					IL_0229:
					platform_Fallback_Base = fallback_PSVita;
					num = 1741698367;
					continue;
					IL_01ad:
					if (inputSource == InputSource.Fallback_PreConfigured)
					{
						platform_Fallback_Base = fallback_Linux_PreConfigured;
						actualInputPlatform = InputPlatform.PlRoHlHsMxRUbOLKpRxEuAkedAG;
						num = 1741698363;
						continue;
					}
					goto IL_03e4;
					IL_00a4:
					if (platform_Fallback_Base != null)
					{
						return platform_Fallback_Base;
					}
					platform_Fallback_Base = fallback_Android;
					actualInputPlatform = InputPlatform.hvteJOJvIYNkPQjlYMlvRYELJCj;
					num = 1741698352;
					continue;
					IL_0166:
					platform_Fallback_Base = fallback_RazerForgeTV;
					actualInputPlatform = InputPlatform.keUAQKhzfbmmrvWZLLVpjBiRDILF;
					platform_Fallback_Base = TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					if (isDefaultMap && platform_Fallback_Base != null && actualInputPlatform != InputPlatform.keUAQKhzfbmmrvWZLLVpjBiRDILF)
					{
						platform_Fallback_Base = null;
						num = 1741698339;
						continue;
					}
					goto IL_00a4;
					IL_03e4:
					platform_Fallback_Base = fallback_Linux;
					actualInputPlatform = InputPlatform.eUabiPKSSDjieZEJgxLjddewVcsF;
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					IL_01e1:
					if (isDefaultMap)
					{
						return GetUniversalDefaultMap<Platform_Fallback_Base>(out actualInputPlatform, out variantIndex);
					}
					variantIndex = -1;
					num = 1741698358;
				}
				goto default;
				IL_03b6:
				platform = Rewired.Platforms.Platform.OSX;
				num = 1741698361;
				goto IL_0025;
				IL_0380:
				platform = Rewired.Platforms.Platform.Linux;
				num = 1741698361;
				goto IL_0025;
				IL_0374:
				platform = Rewired.Platforms.Platform.Windows;
				num = 1741698361;
				goto IL_0025;
				end_IL_000f:
				break;
			}
			if (platform_Fallback_Base != null)
			{
				return platform_Fallback_Base;
			}
			platform_Fallback_Base = fallback_Android;
			actualInputPlatform = InputPlatform.hvteJOJvIYNkPQjlYMlvRYELJCj;
			return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}

		private Platform_SDL2_Base FindSDL2Match(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			Rewired.Platforms.Platform platform = UnityTools.platform;
			Rewired.Platforms.Platform platform2 = default(Rewired.Platforms.Platform);
			Platform_SDL2_Base mainMap = default(Platform_SDL2_Base);
			while (true)
			{
				int num = -1812085261;
				while (true)
				{
					switch (num ^ -1812085263)
					{
					case 10:
						break;
					case 4:
						platform = Rewired.Platforms.Platform.Linux;
						num = -1812085257;
						continue;
					case 8:
						goto IL_0054;
					case 3:
						switch (platform2)
						{
						case Rewired.Platforms.Platform.Linux:
							mainMap = sdl2_Linux;
							actualInputPlatform = InputPlatform.keTnnOorxoGUZamFnuifvhvdNeE;
							return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.OSX:
							mainMap = sdl2_OSX;
							actualInputPlatform = InputPlatform.cbXqDazhCoFsbbpgQKVvBGuIuqco;
							num = -1812085264;
							continue;
						}
						if (isDefaultMap)
						{
							GetUniversalDefaultMap<Platform_SDL2_Base>(out actualInputPlatform, out variantIndex);
							num = -1812085258;
							continue;
						}
						goto case 7;
					case 1:
						return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 5:
						goto IL_009f;
					case 11:
						num = -1812085257;
						continue;
					case 6:
					{
						platform2 = platform;
						int num2;
						if (platform2 != Rewired.Platforms.Platform.Windows)
						{
							num = -1812085262;
							num2 = num;
						}
						else
						{
							num = -1812085263;
							num2 = num;
						}
						continue;
					}
					case 7:
						actualInputPlatform = InputPlatform.XYhwUwaOlrfFTKoMRqftWpJVYyOD;
						variantIndex = -1;
						num = -1812085256;
						continue;
					case 0:
						mainMap = sdl2_Windows;
						actualInputPlatform = InputPlatform.DgoezzHncQDPzHHSCxmmfWPYyHIt;
						return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 2:
						switch (UnityTools.editorPlatform)
						{
						case EditorPlatform.Linux:
							break;
						case EditorPlatform.Windows:
							goto IL_0054;
						case EditorPlatform.OSX:
							goto IL_009f;
						default:
							goto IL_0143;
						}
						goto case 4;
					default:
						{
							return null;
						}
						IL_0143:
						num = -1812085254;
						continue;
						IL_009f:
						platform = Rewired.Platforms.Platform.OSX;
						num = -1812085257;
						continue;
						IL_0054:
						platform = Rewired.Platforms.Platform.Windows;
						num = -1812085257;
						continue;
					}
					break;
				}
			}
		}

		private Platform_SDL2_Base FindSDL2Map(InputSource inputSource, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			Rewired.Platforms.Platform platform = UnityTools.platform;
			int num;
			Platform_SDL2_Base mainMap = default(Platform_SDL2_Base);
			Rewired.Platforms.Platform platform2 = default(Rewired.Platforms.Platform);
			int num3;
			switch (UnityTools.editorPlatform)
			{
			case EditorPlatform.OSX:
				platform = Rewired.Platforms.Platform.OSX;
				num = -172787363;
				goto IL_002a;
			case EditorPlatform.Linux:
				goto IL_0101;
			default:
				goto IL_010d;
			case EditorPlatform.Windows:
				goto IL_0127;
				IL_002a:
				while (true)
				{
					switch (num ^ -172787364)
					{
					case 2:
						num = -172787369;
						continue;
					case 3:
						actualInputPlatform = InputPlatform.cbXqDazhCoFsbbpgQKVvBGuIuqco;
						return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 8:
						actualInputPlatform = InputPlatform.XYhwUwaOlrfFTKoMRqftWpJVYyOD;
						variantIndex = -1;
						num = -172787370;
						continue;
					case 5:
						break;
					case 0:
						goto IL_00a5;
					case 4:
						mainMap = sdl2_Windows;
						actualInputPlatform = InputPlatform.DgoezzHncQDPzHHSCxmmfWPYyHIt;
						return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 9:
						GetUniversalDefaultMap<Platform_SDL2_Base>(out actualInputPlatform, out variantIndex);
						num = -172787372;
						continue;
					case 6:
						goto IL_0101;
					case 1:
						goto IL_010d;
					case 11:
						goto IL_0127;
					case 7:
						actualInputPlatform = InputPlatform.keTnnOorxoGUZamFnuifvhvdNeE;
						return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
					default:
						return null;
					}
					break;
					IL_00a5:
					switch (platform2)
					{
					case Rewired.Platforms.Platform.Linux:
						mainMap = sdl2_Linux;
						num = -172787365;
						continue;
					case Rewired.Platforms.Platform.OSX:
						mainMap = sdl2_OSX;
						num = -172787361;
						continue;
					}
					int num2;
					if (!isDefaultMap)
					{
						num = -172787372;
						num2 = num;
					}
					else
					{
						num = -172787371;
						num2 = num;
					}
				}
				goto case EditorPlatform.OSX;
				IL_0127:
				platform = Rewired.Platforms.Platform.Windows;
				num = -172787363;
				goto IL_002a;
				IL_010d:
				platform2 = platform;
				if (platform2 != Rewired.Platforms.Platform.Windows)
				{
					num = -172787364;
					num3 = num;
				}
				else
				{
					num = -172787368;
					num3 = num;
				}
				goto IL_002a;
				IL_0101:
				platform = Rewired.Platforms.Platform.Linux;
				num = -172787363;
				goto IL_002a;
			}
		}

		private T TryGetFirstValidMap<T>(T mainMap, bool isDefaultMap, ref InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
		{
			if (isDefaultMap)
			{
				if (mainMap != null)
				{
					goto IL_0011;
				}
				goto IL_0111;
			}
			int num;
			int num2;
			if (mainMap != null)
			{
				num = 671663093;
				num2 = num;
			}
			else
			{
				num = 671663099;
				num2 = num;
			}
			goto IL_0016;
			IL_0011:
			num = 671663088;
			goto IL_0016;
			IL_0111:
			return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
			IL_0016:
			int num3 = default(int);
			T result = default(T);
			Platform platform = default(Platform);
			IList<Platform> variants_base = default(IList<Platform>);
			while (true)
			{
				switch (num ^ 0x2808C3F1)
				{
				case 8:
					break;
				case 6:
					num = 671663089;
					continue;
				case 7:
					goto IL_0065;
				case 0:
					goto IL_0088;
				case 10:
					variantIndex = -1;
					num = 671663100;
					continue;
				case 12:
					num3 = 0;
					num = 671663095;
					continue;
				case 3:
					goto IL_00bf;
				case 9:
					variantIndex = -1;
					return mainMap;
				case 13:
					result = null;
					num = 671663092;
					continue;
				case 11:
					goto IL_0111;
				case 1:
					goto IL_0134;
				case 4:
					goto IL_014d;
				case 2:
					return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
				default:
					return result;
				}
				break;
				IL_014d:
				if (!mainMap.selfOrVariantIsValid)
				{
					num = 671663099;
					continue;
				}
				return mainMap.GetFirstValidPlatformMap(out variantIndex) as T;
				IL_00bf:
				platform = variants_base[num3];
				if (platform != null)
				{
					num = 671663094;
					continue;
				}
				goto IL_007d;
				IL_007d:
				num3++;
				num = 671663089;
				continue;
				IL_0134:
				if (mainMap.selfOrVariantIsAllowed)
				{
					if (!mainMap.isAllowed)
					{
						variants_base = mainMap.variants_base;
						int num4;
						if (variants_base != null)
						{
							num = 671663101;
							num4 = num;
						}
						else
						{
							num = 671663091;
							num4 = num;
						}
					}
					else
					{
						num = 671663096;
					}
				}
				else
				{
					num = 671663098;
				}
				continue;
				IL_0088:
				int num5;
				if (num3 >= variants_base.Count)
				{
					num = 671663091;
					num5 = num;
				}
				else
				{
					num = 671663090;
					num5 = num;
				}
				continue;
				IL_0065:
				if (platform.isAllowed)
				{
					variantIndex = num3;
					return platform as T;
				}
				goto IL_007d;
			}
			goto IL_0011;
		}

		private T TryGetFirstMatchingMap<T>(T mainMap, BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, ref InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
		{
			Platform platformMap = default(Platform);
			if (isDefaultMap)
			{
				if (mainMap != null)
				{
					if (mainMap.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
					{
						return platformMap as T;
					}
					return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
				}
				goto IL_000c;
			}
			T result = default(T);
			int num;
			T result2 = default(T);
			if (mainMap == null)
			{
				variantIndex = -1;
				result = null;
				num = -821010976;
			}
			else if (!mainMap.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				variantIndex = -1;
				result2 = null;
				num = -821010973;
			}
			else
			{
				num = -821010975;
			}
			goto IL_0011;
			IL_000c:
			num = -821010974;
			goto IL_0011;
			IL_0011:
			switch (num ^ -821010973)
			{
			case 4:
				break;
			case 1:
				return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
			case 2:
				return platformMap as T;
			case 3:
				return result;
			default:
				return result2;
			}
			goto IL_000c;
		}

		private T GetUniversalDefaultMap<T>(out InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
		{
			T universalDefaultMapRoot = GetUniversalDefaultMapRoot<T>(typeof(T), out actualInputPlatform);
			actualInputPlatform = InputPlatform.DgoezzHncQDPzHHSCxmmfWPYyHIt;
			variantIndex = -1;
			IList<Platform> variants_base = default(IList<Platform>);
			int num;
			if (universalDefaultMapRoot != null)
			{
				if (!universalDefaultMapRoot.selfOrVariantIsAllowed)
				{
					goto IL_0036;
				}
				if (universalDefaultMapRoot.isAllowed)
				{
					return universalDefaultMapRoot;
				}
				variants_base = universalDefaultMapRoot.variants_base;
				num = -1742285807;
				goto IL_003b;
			}
			goto IL_00d4;
			IL_003b:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1742285807)
				{
				case 2:
					break;
				case 6:
					goto IL_006f;
				case 5:
					goto IL_0089;
				case 7:
					num2 = 0;
					num = -1742285803;
					continue;
				case 0:
					goto IL_00b3;
				case 4:
					num = -1742285801;
					continue;
				case 1:
					goto IL_00d4;
				case 8:
					variantIndex = num2;
					return variants_base[num2] as T;
				default:
					return null;
				}
				break;
				IL_00b3:
				int num3;
				if (variants_base == null)
				{
					num = -1742285806;
					num3 = num;
				}
				else
				{
					num = -1742285802;
					num3 = num;
				}
				continue;
				IL_0089:
				if (variants_base[num2] != null && variants_base[num2].isAllowed)
				{
					num = -1742285799;
					continue;
				}
				num2++;
				num = -1742285801;
				continue;
				IL_006f:
				int num4;
				if (num2 >= variants_base.Count)
				{
					num = -1742285806;
					num4 = num;
				}
				else
				{
					num = -1742285804;
					num4 = num;
				}
			}
			goto IL_0036;
			IL_0036:
			num = -1742285808;
			goto IL_003b;
			IL_00d4:
			return null;
		}

		private T GetUniversalDefaultMapRoot<T>(Type type, out InputPlatform actualInputPlatform) where T : Platform
		{
			if (object.ReferenceEquals(type, typeof(Platform_Fallback_Base)))
			{
				actualInputPlatform = InputPlatform.lcPnzROWQvkxuEjIsRvoYRWoVXg;
				goto IL_0015;
			}
			int num;
			if (object.ReferenceEquals(type, typeof(Platform_SDL2_Base)))
			{
				actualInputPlatform = InputPlatform.DgoezzHncQDPzHHSCxmmfWPYyHIt;
				num = -1335478354;
				goto IL_001a;
			}
			throw new NotImplementedException();
			IL_0015:
			num = -1335478355;
			goto IL_001a;
			IL_001a:
			switch (num ^ -1335478356)
			{
			case 0:
				break;
			case 1:
				return fallback_Windows as T;
			default:
				return sdl2_Windows as T;
			}
			goto IL_0015;
		}

		private Platform GetSpecificPlatformMap(HardwareControllerMapIdentifier hardwareMapIdentifier)
		{
			Platform specificPlatformRoot = GetSpecificPlatformRoot(hardwareMapIdentifier.actualInputPlatform);
			if (specificPlatformRoot == null)
			{
				return null;
			}
			return specificPlatformRoot.GetPlatformMap(hardwareMapIdentifier.variantIndex);
		}

		private Platform GetSpecificPlatformRoot(InputPlatform exactInputPlatform)
		{
			while (true)
			{
				int num = -1838401207;
				while (true)
				{
					switch (num ^ -1838401205)
					{
					case 0:
						break;
					case 5:
						return webGL;
					case 3:
						goto IL_005c;
					case 4:
						goto IL_0122;
					case 2:
						switch (exactInputPlatform)
						{
						case InputPlatform.TxrUiyPjtJdznKpsXcVgtexpIzI:
							break;
						case InputPlatform.gGGEnVSWvgaFbdVaVnlfMbOTkJsO:
							return ouya;
						case InputPlatform.pZrRySJpwHiBEaxxGokWuXWJhUS:
							return xboxOne;
						case InputPlatform.ehbCQljLDvgiNbFTeUQYWfWVaDsb:
							return ps4;
						case InputPlatform.OSoXKRRBZfHUVjWFHAZRkYacHta:
							throw new NotImplementedException();
						case InputPlatform.GqzyAlVbsTJEJeHcVvIVueUVgOh:
							goto IL_005c;
						case InputPlatform.cZjaGiccoOfQMydNsMdhkKrlxCba:
							return rawInput;
						case InputPlatform.ovCPWlBsEvuzkIMqmgTZqxNDFgV:
							return xInput;
						case InputPlatform.lcPnzROWQvkxuEjIsRvoYRWoVXg:
							return fallback_Windows;
						case InputPlatform.lVqnUVyYsKsHZMKeqoJPZENWgClF:
							return windowsUWP;
						case InputPlatform.JAzQtbHLOTHOvWCjKBtuYzhnFoW:
							return fallback_WindowsUWP;
						case InputPlatform.qzTTwsqmkFsXzptVNiHLyLYTdWR:
							return osx;
						case InputPlatform.zqQYkhsnXyLqDuhSVwAvqSUVNyY:
							return fallback_OSX;
						case InputPlatform.enTXCIFwxjKGOTdUNPCUNyQZEQr:
							return linux;
						case InputPlatform.eUabiPKSSDjieZEJgxLjddewVcsF:
							return fallback_Linux;
						case InputPlatform.PlRoHlHsMxRUbOLKpRxEuAkedAG:
							return fallback_Linux_PreConfigured;
						case InputPlatform.hvteJOJvIYNkPQjlYMlvRYELJCj:
							return fallback_Android;
						case InputPlatform.BcegoeXnuzLZifdCXJVBpApAEkl:
							return fallback_AmazonFireTV;
						case InputPlatform.keUAQKhzfbmmrvWZLLVpjBiRDILF:
							return fallback_RazerForgeTV;
						case InputPlatform.VdrZcVyweUFNIzNbSheVCltJDtNo:
							return fallback_iOS;
						case InputPlatform.GwzdkTbFocQuylCSAbRrAldwZoB:
							return fallback_WindowsPhone8;
						case InputPlatform.PLWBZITRYDmOzPwdONuXhmYqiiY:
							return fallback_Blackberry;
						case InputPlatform.pvkAQXroaTtXJRXQEyCZuMOIYDy:
							return fallback_PS3;
						case InputPlatform.sUEnaBPRoRGbjFzftPXWNFCTHYrT:
							return fallback_PS4;
						case InputPlatform.BipyCxjgAgSAqipXvprsKMIDFLB:
							return fallback_PSM;
						case InputPlatform.hqtGxMrtQLDZyGfXPXekSiBPTBa:
							return fallback_PSVita;
						case InputPlatform.JRyVneHjlMIxElqiQLQdnWbbsMb:
							return fallback_XBox360;
						case InputPlatform.ohIXpWWVnrVVdZSDmnrfcFpOiWJc:
							return fallback_XBoxOne;
						case InputPlatform.lGRAMGWQvEWJrLMuXvesWaypSQD:
							return fallback_Wii;
						case InputPlatform.lQxcglqwyjmvSaspdllCCCoyxtP:
							return fallback_WiiU;
						case InputPlatform.nbOhDhcnKQfYJsEjsPifPczVJFzj:
							return nintendoSwitch;
						case InputPlatform.lQJYCJKxUxlRFVSnejxjlgJeAjCe:
							throw new NotImplementedException();
						case InputPlatform.DgoezzHncQDPzHHSCxmmfWPYyHIt:
							goto IL_0122;
						case InputPlatform.cbXqDazhCoFsbbpgQKVvBGuIuqco:
							return sdl2_OSX;
						case InputPlatform.keTnnOorxoGUZamFnuifvhvdNeE:
							return sdl2_Linux;
						case InputPlatform.XYhwUwaOlrfFTKoMRqftWpJVYyOD:
						case InputPlatform.ZANtQEkaOaQcYhPlpfZCiDwahfr:
							throw new NotImplementedException();
						default:
							goto IL_01ed;
						case InputPlatform.sstGbYqotnUAodZSsTwHEEbgiSR:
							goto IL_01f7;
						case InputPlatform.IxbHVCPxPdNPRUkNUofPdkkhUmv:
							throw new NotImplementedException();
						case InputPlatform.dyrBgdFyTIOJPuQBhTiunpcmXkX:
							goto IL_020e;
						}
						goto case 5;
					case 1:
						goto IL_01f7;
					default:
						goto IL_020e;
						IL_020e:
						throw new NotImplementedException();
						IL_01f7:
						return internalDriver;
						IL_0122:
						return sdl2_Windows;
						IL_005c:
						return directInput;
					}
					break;
					IL_01ed:
					num = -1838401203;
				}
			}
		}
	}
}
