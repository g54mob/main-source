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
			private sealed class MUXAEJaZMexKOrTMiUHVVlDlGckn : IDisposable, IEnumerator, IEnumerable<Platform>, IEnumerator<Platform>, IEnumerable
			{
				private Platform aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public IList<Platform> uCfggchHDWjiEiDDbeDjjeIGqYIj;

				public int ZkPTJAOzebDnAXdzWKDLivPtrGR;

				Platform IEnumerator<Platform>.Current
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
				IEnumerator<Platform> IEnumerable<Platform>.GetEnumerator()
				{
					MUXAEJaZMexKOrTMiUHVVlDlGckn mUXAEJaZMexKOrTMiUHVVlDlGckn;
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						mUXAEJaZMexKOrTMiUHVVlDlGckn = this;
					}
					else
					{
						while (true)
						{
							mUXAEJaZMexKOrTMiUHVVlDlGckn = new MUXAEJaZMexKOrTMiUHVVlDlGckn(0);
							mUXAEJaZMexKOrTMiUHVVlDlGckn.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
							int num = -1033687402;
							while (true)
							{
								switch (num ^ -1033687402)
								{
								case 2:
									num = -1033687401;
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
					return mUXAEJaZMexKOrTMiUHVVlDlGckn;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 0:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						uCfggchHDWjiEiDDbeDjjeIGqYIj = iKQXbXnVtIaMZEJNeigQJWAHqUx.variants_base;
						int num2;
						if (uCfggchHDWjiEiDDbeDjjeIGqYIj == null)
						{
							num = 1843613116;
							num2 = num;
						}
						else
						{
							num = 1843613117;
							num2 = num;
						}
						goto IL_001f;
					}
					case 1:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							num = 1843613119;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x6DE34DBF)
							{
							case 7:
								num = 1843613118;
								continue;
							case 1:
								break;
							case 4:
								if (uCfggchHDWjiEiDDbeDjjeIGqYIj[ZkPTJAOzebDnAXdzWKDLivPtrGR] != null)
								{
									aimBzjfQfPyaeQqysAQJISCBhELB = uCfggchHDWjiEiDDbeDjjeIGqYIj[ZkPTJAOzebDnAXdzWKDLivPtrGR];
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
									num = 1843613114;
									continue;
								}
								goto case 0;
							case 2:
								ZkPTJAOzebDnAXdzWKDLivPtrGR = 0;
								num = 1843613113;
								continue;
							case 6:
								goto IL_00cc;
							case 5:
								return true;
							case 0:
								ZkPTJAOzebDnAXdzWKDLivPtrGR++;
								num = 1843613113;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00cc:
							int num3;
							if (ZkPTJAOzebDnAXdzWKDLivPtrGR >= uCfggchHDWjiEiDDbeDjjeIGqYIj.Count)
							{
								num = 1843613116;
								num3 = num;
							}
							else
							{
								num = 1843613115;
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
				public MUXAEJaZMexKOrTMiUHVVlDlGckn(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
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
					MUXAEJaZMexKOrTMiUHVVlDlGckn mUXAEJaZMexKOrTMiUHVVlDlGckn = new MUXAEJaZMexKOrTMiUHVVlDlGckn(-2);
					mUXAEJaZMexKOrTMiUHVVlDlGckn.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return mUXAEJaZMexKOrTMiUHVVlDlGckn;
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
					IEnumerator<Platform> enumerator = Variants.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							while (true)
							{
								Platform current = enumerator.Current;
								if (!current.hasData)
								{
									break;
								}
								bool result = true;
								int num = 1499471403;
								while (true)
								{
									switch (num ^ 0x59601E2A)
									{
									case 0:
										num = 1499471401;
										continue;
									case 3:
										break;
									default:
										goto end_IL_003a;
									case 1:
										return result;
									}
									break;
								}
								continue;
								end_IL_003a:
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
								IL_0068:
								int num2 = 1499471400;
								while (true)
								{
									switch (num2 ^ 0x59601E2A)
									{
									case 0:
										break;
									default:
										goto end_IL_006d;
									case 2:
										goto IL_0086;
									case 1:
										goto end_IL_006d;
									}
									goto IL_0068;
									IL_0086:
									enumerator.Dispose();
									num2 = 1499471403;
									continue;
									end_IL_006d:
									break;
								}
								break;
							}
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
					using (IEnumerator<Platform> enumerator = Variants.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							while (true)
							{
								Platform current = enumerator.Current;
								int num = -1163310813;
								while (true)
								{
									switch (num ^ -1163310813)
									{
									case 4:
										num = -1163310814;
										continue;
									case 2:
										return true;
									case 3:
										break;
									case 0:
										goto IL_0078;
									case 1:
										goto end_IL_002f;
									default:
										goto end_IL_0091;
									}
									int num2;
									if (current.hasData)
									{
										num = -1163310815;
										num2 = num;
									}
									else
									{
										num = -1163310810;
										num2 = num;
									}
									continue;
									IL_0078:
									int num3;
									if (current.isAllowed)
									{
										num = -1163310816;
										num3 = num;
									}
									else
									{
										num = -1163310810;
										num3 = num;
									}
									continue;
									end_IL_002f:
									break;
								}
								continue;
								end_IL_0091:
								break;
							}
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
					foreach (Platform variant in Variants)
					{
						if (variant.isAllowed)
						{
							return true;
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
					return null;
				}
				if (isAllowed)
				{
					goto IL_0018;
				}
				goto IL_009e;
				IL_00d0:
				return null;
				IL_0018:
				int num = -203891912;
				goto IL_001d;
				IL_001d:
				int num2 = default(int);
				Platform platform = default(Platform);
				IList<Platform> list = default(IList<Platform>);
				while (true)
				{
					switch (num ^ -203891910)
					{
					case 4:
						break;
					case 0:
						goto IL_004d;
					case 1:
						variantIndex = num2;
						return platform;
					case 7:
						goto IL_0077;
					case 2:
						goto IL_0091;
					case 5:
						num = -203891907;
						continue;
					case 6:
						goto IL_00be;
					default:
						goto IL_00d0;
					}
					break;
					IL_00be:
					if (platform.hasData)
					{
						num = -203891909;
						continue;
					}
					goto IL_006c;
					IL_006c:
					num2++;
					num = -203891907;
					continue;
					IL_0077:
					int num3;
					if (num2 < list.Count)
					{
						num = -203891910;
						num3 = num;
					}
					else
					{
						num = -203891911;
						num3 = num;
					}
					continue;
					IL_004d:
					platform = list[num2];
					if (platform != null && platform.isAllowed)
					{
						num = -203891908;
						continue;
					}
					goto IL_006c;
				}
				goto IL_0018;
				IL_0091:
				if (hasData)
				{
					variantIndex = -1;
					return this;
				}
				goto IL_009e;
				IL_009e:
				list = variants_base;
				if (list != null)
				{
					num2 = 0;
					num = -203891905;
					goto IL_001d;
				}
				goto IL_00d0;
			}

			internal int IndexOfElementIdentifier(ControllerElementIdentifier[] elementIdentifiers, int id)
			{
				if (elementIdentifiers == null)
				{
					goto IL_0003;
				}
				int num = 0;
				int num2 = -311625730;
				goto IL_0008;
				IL_0008:
				while (true)
				{
					switch (num2 ^ -311625734)
					{
					case 0:
						break;
					case 1:
						return num;
					case 2:
						if (elementIdentifiers[num].id != id)
						{
							num++;
							num2 = -311625730;
						}
						else
						{
							num2 = -311625733;
						}
						continue;
					case 3:
						return -1;
					default:
						if (num >= elementIdentifiers.Length)
						{
							return -1;
						}
						goto case 2;
					}
					break;
				}
				goto IL_0003;
				IL_0003:
				num2 = -311625735;
				goto IL_0008;
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
					return this;
				}
				if (!hasVariants)
				{
					return null;
				}
				IList<Platform> list = variants_base;
				if (variantCount <= variantIndex)
				{
					return null;
				}
				return list[variantIndex];
			}

			internal HardwareJoystickMap_InputManager ToHardwareJoystickMap_InputManager(HardwareJoystickMap hardwareJoystickMap, InputSource inputSource, InputPlatform actualInputPlatform, int variantIndex)
			{
				if (hardwareJoystickMap == null)
				{
					goto IL_000c;
				}
				Platform platform = MiscTools.DeepClone(this);
				int num = 1325024702;
				goto IL_0011;
				IL_0011:
				int num3 = default(int);
				int elementIdentifierCount = default(int);
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = default(HardwareJoystickMap_InputManager);
				int num2 = default(int);
				ControllerElementIdentifier[] elementIdentifiers = default(ControllerElementIdentifier[]);
				int num4 = default(int);
				while (true)
				{
					switch (num ^ 0x4EFA459A)
					{
					case 5:
						break;
					case 40:
					{
						int num8;
						if (num3 < elementIdentifierCount)
						{
							num = 1325024688;
							num8 = num;
						}
						else
						{
							num = 1325024646;
							num8 = num;
						}
						continue;
					}
					case 31:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].negativeName = "left stick down";
						num = 1325024651;
						continue;
					case 42:
						if (hardwareJoystickMap_InputManager.elementIdentifiers[num3].elementType == ControllerElementType.Axis)
						{
							int num7;
							if (string.IsNullOrEmpty(hardwareJoystickMap_InputManager.elementIdentifiers[num3].positiveName))
							{
								num = 1325024698;
								num7 = num;
							}
							else
							{
								num = 1325024659;
								num7 = num;
							}
							continue;
						}
						goto case 45;
					case 19:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "R2 button";
						num = 1325024668;
						continue;
					case 11:
						switch (elementIdentifiers[num2].id)
						{
						case 5:
							break;
						default:
							goto IL_01d2;
						case 7:
							goto IL_01dc;
						case 13:
							goto IL_01f9;
						case 0:
							goto IL_0216;
						case 4:
							goto IL_02b2;
						case 6:
							goto IL_02cf;
						case 19:
							goto IL_02ec;
						case 10:
							goto IL_0375;
						case 18:
							goto IL_0392;
						case 3:
							goto IL_03bc;
						case 9:
							goto IL_0432;
						case 1:
							goto IL_04d6;
						case 8:
							goto IL_0572;
						case 14:
							goto IL_058f;
						case 15:
							goto IL_05b6;
						case 21:
							goto IL_05d3;
						case 16:
							goto IL_05f0;
						case 17:
							goto IL_0647;
						case 20:
							goto IL_0664;
						case 11:
							goto IL_0681;
						case 12:
							goto IL_069e;
						case 2:
							goto IL_06bb;
						}
						goto case 19;
					case 1:
						goto IL_01dc;
					case 16:
						goto IL_01f9;
					case 44:
						goto IL_0216;
					case 43:
						num = 1325024651;
						continue;
					case 26:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4] = new ControllerElementIdentifier(elementIdentifiers[num4], hardwareJoystickMap_InputManager.map.IsElementIdentifierMapped(elementIdentifiers[num4].id), hardwareJoystickMap_InputManager.map.GetEffectiveElementIdentifierType(elementIdentifiers[num4]));
						num4++;
						num = 1325024655;
						continue;
					case 35:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].positiveName = "right stick right";
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].negativeName = "right stick left";
						num = 1325024651;
						continue;
					case 22:
						goto IL_02b2;
					case 33:
						goto IL_02cf;
					case 27:
						goto IL_02ec;
					case 9:
						if (string.IsNullOrEmpty(hardwareJoystickMap_InputManager.elementIdentifiers[num3].negativeName))
						{
							hardwareJoystickMap_InputManager.elementIdentifiers[num3].negativeName = hardwareJoystickMap_InputManager.elementIdentifiers[num3].name + " -";
							num = 1325024695;
							continue;
						}
						goto case 45;
					case 4:
						if (inputSource == InputSource.PS4 && hardwareJoystickMap.Guid == Consts.joystickGuid_SonyDualShock4)
						{
							num2 = 0;
							num = 1325024701;
							continue;
						}
						goto case 7;
					case 13:
						goto IL_0375;
					case 12:
						goto IL_0392;
					case 7:
						num3 = 0;
						num = 1325024690;
						continue;
					case 10:
						goto IL_03bc;
					case 45:
						num3++;
						num = 1325024690;
						continue;
					case 25:
						return null;
					case 17:
						num2++;
						num = 1325024701;
						continue;
					case 34:
						goto IL_0432;
					case 36:
						hardwareJoystickMap_InputManager = new HardwareJoystickMap_InputManager(new HardwareControllerMapIdentifier(hardwareJoystickMap.Guid, inputSource, actualInputPlatform, variantIndex), hardwareJoystickMap.joystickTypes, platform, hardwareJoystickMap.controllerName, platform.assignedButtonCount, platform.assignedAxisCount, hardwareJoystickMap.elementIdentifiers.Length, hardwareJoystickMap.compoundElements);
						elementIdentifiers = hardwareJoystickMap.elementIdentifiers;
						elementIdentifierCount = hardwareJoystickMap.elementIdentifierCount;
						num4 = 0;
						num = 1325024655;
						continue;
					case 14:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].positiveName = "left stick right";
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].negativeName = "left stick left";
						num = 1325024651;
						continue;
					case 0:
						goto IL_04d6;
					case 39:
					{
						int num6;
						if (num2 < elementIdentifierCount)
						{
							num = 1325024657;
							num6 = num;
						}
						else
						{
							num = 1325024669;
							num6 = num;
						}
						continue;
					}
					case 21:
					{
						int num5;
						if (num4 >= elementIdentifierCount)
						{
							num = 1325024670;
							num5 = num;
						}
						else
						{
							num = 1325024640;
							num5 = num;
						}
						continue;
					}
					case 29:
						num = 1325024651;
						continue;
					case 32:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].positiveName = hardwareJoystickMap_InputManager.elementIdentifiers[num3].name + " +";
						num = 1325024659;
						continue;
					case 18:
						goto IL_0572;
					case 3:
						goto IL_058f;
					case 2:
						num = 1325024651;
						continue;
					case 8:
						goto IL_05b6;
					case 24:
						goto IL_05d3;
					case 20:
						goto IL_05f0;
					case 23:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].positiveName = "L2 button";
						num = 1325024651;
						continue;
					case 6:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].positiveName = "R2 button";
						num = 1325024651;
						continue;
					case 38:
						goto IL_0647;
					case 37:
						goto IL_0664;
					case 30:
						goto IL_0681;
					case 15:
						goto IL_069e;
					case 41:
						goto IL_06bb;
					default:
						{
							return hardwareJoystickMap_InputManager;
						}
						IL_01dc:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "circle button";
						num = 1325024651;
						continue;
						IL_01d2:
						num = 1325024651;
						continue;
						IL_06bb:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "right stick x";
						num = 1325024697;
						continue;
						IL_069e:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "SHARE button";
						num = 1325024651;
						continue;
						IL_0681:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "R1 button";
						num = 1325024664;
						continue;
						IL_0664:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "down button";
						num = 1325024647;
						continue;
						IL_0647:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "R3 button";
						num = 1325024651;
						continue;
						IL_05f0:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "L3 button";
						num = 1325024651;
						continue;
						IL_05d3:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "left button";
						num = 1325024651;
						continue;
						IL_05b6:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "touch pad button";
						num = 1325024651;
						continue;
						IL_058f:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "PS button";
						num = 1325024651;
						continue;
						IL_0572:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "square button";
						num = 1325024651;
						continue;
						IL_04d6:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "left stick y";
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].positiveName = "left stick up";
						num = 1325024645;
						continue;
						IL_0432:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "triangle button";
						num = 1325024651;
						continue;
						IL_03bc:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "right stick y";
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].positiveName = "right stick up";
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].negativeName = "right stick down";
						num = 1325024651;
						continue;
						IL_0392:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "up button";
						num = 1325024651;
						continue;
						IL_0375:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "L1 button";
						num = 1325024689;
						continue;
						IL_02ec:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "right button";
						num = 1325024651;
						continue;
						IL_02cf:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "cross button";
						num = 1325024651;
						continue;
						IL_02b2:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "L2 button";
						num = 1325024653;
						continue;
						IL_0216:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "left stick x";
						num = 1325024660;
						continue;
						IL_01f9:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].name = "OPTIONS button";
						num = 1325024651;
						continue;
					}
					break;
				}
				goto IL_000c;
				IL_000c:
				num = 1325024643;
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
							switch (-500851523 ^ -500851524)
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
						return false;
					}
					if (axisCount < 0 || axisCount == P_0.hardwareAxisCount)
					{
						if (buttonCount >= 0)
						{
							return buttonCount == P_0.hardwareButtonCount;
						}
						return true;
					}
					return false;
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
					return false;
				}
				bool alternateMatched;
				if (!ElementCountsMatch(BridgedControllerHWInfo, out alternateMatched))
				{
					return false;
				}
				if (!string.IsNullOrEmpty(BridgedControllerHWInfo.definitionMatchTag) && !BridgedControllerHWInfo.definitionMatchTag.Equals(tag, StringComparison.OrdinalIgnoreCase))
				{
					return false;
				}
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
				int num3 = default(int);
				ElementCount_Base elementCount_Base = default(ElementCount_Base);
				while (true)
				{
					int num2 = -1225921342;
					while (true)
					{
						switch (num2 ^ -1225921337)
						{
						case 4:
							break;
						case 5:
							num3 = 0;
							num2 = -1225921338;
							continue;
						case 6:
							return true;
						case 0:
							elementCount_Base = GetAlternateElementCount(num3);
							if (elementCount_Base != null)
							{
								num2 = -1225921340;
								continue;
							}
							goto IL_0048;
						case 3:
							if (elementCount_Base.Matches(bridgedControllerHWInfo))
							{
								alternateMatched = true;
								num2 = -1225921343;
								continue;
							}
							goto IL_0048;
						case 1:
							if (num3 < num)
							{
								goto case 0;
							}
							if (axisCount >= 0)
							{
								if (axisCount == bridgedControllerHWInfo.hardwareAxisCount)
								{
									num2 = -1225921339;
									continue;
								}
								return false;
							}
							goto default;
						default:
							{
								if (buttonCount >= 0)
								{
									return buttonCount == bridgedControllerHWInfo.hardwareButtonCount;
								}
								return true;
							}
							IL_0048:
							num3++;
							num2 = -1225921338;
							continue;
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
					searchIn = string.Empty;
					goto IL_000a;
				}
				goto IL_0030;
				IL_0030:
				int num;
				int num2;
				if (searchFor == null)
				{
					num = 2094824719;
					num2 = num;
				}
				else
				{
					num = 2094824712;
					num2 = num;
				}
				goto IL_000f;
				IL_000a:
				num = 2094824714;
				goto IL_000f;
				IL_000f:
				while (true)
				{
					switch (num ^ 0x7CDC7D0B)
					{
					case 0:
						break;
					case 1:
						goto IL_0030;
					case 3:
						goto IL_0044;
					case 4:
						searchFor = string.Empty;
						num = 2094824712;
						continue;
					default:
						return Regex.IsMatch(searchIn, searchFor, RegexOptions.IgnoreCase);
					}
					break;
					IL_0044:
					if (useRegex)
					{
						num = 2094824713;
						continue;
					}
					return searchFor.Trim().Equals(searchIn.Trim(), StringComparison.OrdinalIgnoreCase);
				}
				goto IL_000a;
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
				if (componentElementIdentifiers == null)
				{
					componentElementIdentifiers = new int[0];
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
					goto IL_0003;
				}
				goto IL_004c;
				IL_0003:
				int num = -924140138;
				goto IL_0008;
				IL_0008:
				int[] array = default(int[]);
				while (true)
				{
					switch (num ^ -924140132)
					{
					case 8:
						break;
					case 9:
						return;
					case 7:
						goto IL_004c;
					case 6:
						if (element.componentElementIdentifiers.Length != 8)
						{
							return;
						}
						goto case 0;
					case 3:
						return;
					case 2:
						array[1] = element.componentElementIdentifiers[4];
						array[2] = element.componentElementIdentifiers[1];
						array[3] = element.componentElementIdentifiers[5];
						num = -924140131;
						continue;
					case 4:
						goto IL_00ad;
					case 0:
						array = new int[8];
						num = -924140135;
						continue;
					case 10:
						return;
					case 5:
						array[0] = element.componentElementIdentifiers[0];
						num = -924140130;
						continue;
					default:
						array[4] = element.componentElementIdentifiers[2];
						array[5] = element.componentElementIdentifiers[6];
						array[6] = element.componentElementIdentifiers[3];
						array[7] = element.componentElementIdentifiers[7];
						Array.Copy(array, element.componentElementIdentifiers, array.Length);
						return;
					}
					break;
					IL_00ad:
					int num2;
					if (element.componentElementIdentifiers != null)
					{
						num = -924140134;
						num2 = num;
					}
					else
					{
						num = -924140129;
						num2 = num;
					}
				}
				goto IL_0003;
				IL_004c:
				int num3;
				if (element.type == CompoundControllerElementType.Hat)
				{
					num = -924140136;
					num3 = num;
				}
				else
				{
					num = -924140139;
					num3 = num;
				}
				goto IL_0008;
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
					return new Dictionary<int, AxisCalibrationInfo>();
				}
				Dictionary<int, AxisCalibrationInfo> dictionary = new Dictionary<int, AxisCalibrationInfo>();
				int num2 = default(int);
				AxisCalibrationInfoEntry axisCalibrationInfoEntry = default(AxisCalibrationInfoEntry);
				while (true)
				{
					int num = -1959736490;
					while (true)
					{
						switch (num ^ -1959736492)
						{
						case 4:
							break;
						case 2:
							num2 = 0;
							num = -1959736482;
							continue;
						case 6:
							axisCalibrationInfoEntry = calibrations[num2];
							if (axisCalibrationInfoEntry != null && axisCalibrationInfoEntry.calibration != null && Enum.IsDefined(typeof(AlternateAxisCalibrationType), axisCalibrationInfoEntry.key))
							{
								int num3;
								if (dictionary.ContainsKey((int)axisCalibrationInfoEntry.key))
								{
									num = -1959736492;
									num3 = num;
								}
								else
								{
									num = -1959736483;
									num3 = num;
								}
								continue;
							}
							goto case 3;
						case 3:
							num2++;
							num = -1959736493;
							continue;
						case 10:
							num = -1959736493;
							continue;
						case 9:
							if (deepClone)
							{
								dictionary.Add((int)axisCalibrationInfoEntry.key, (AxisCalibrationInfo)axisCalibrationInfoEntry.calibration.DeepClone());
								num = -1959736495;
								continue;
							}
							goto case 1;
						case 1:
							dictionary.Add((int)axisCalibrationInfoEntry.key, axisCalibrationInfoEntry.calibration);
							num = -1959736489;
							continue;
						case 5:
							num = -1959736489;
							continue;
						case 0:
							Logger.LogError("A duplicate key was found in AxisCalibrationInfoEntry array in HardwareJoystickMap. Skipping.");
							num = -1959736484;
							continue;
						case 8:
							num = -1959736489;
							continue;
						default:
							if (num2 >= calibrations.Length)
							{
								return dictionary;
							}
							goto case 6;
						}
						break;
					}
				}
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
						while (true)
						{
							int num = -1798335193;
							while (true)
							{
								switch (num ^ -1798335194)
								{
								case 0:
									break;
								case 1:
									goto IL_0024;
								default:
									return elementCount;
								}
								break;
								IL_0024:
								CopyVars(elementCount);
								num = -1798335196;
							}
						}
					}

					internal override void CopyVars(ElementCount_Base P_0)
					{
						base.CopyVars(P_0);
						ElementCount elementCount = P_0 as ElementCount;
						if (elementCount == null)
						{
							goto IL_0011;
						}
						goto IL_003b;
						IL_0011:
						int num = 1664970062;
						goto IL_0016;
						IL_0016:
						switch (num ^ 0x633D6D4C)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							return;
						case 1:
							goto IL_003b;
						case 3:
							return;
						}
						goto IL_0011;
						IL_003b:
						elementCount.hatCount = hatCount;
						num = 1664970063;
						goto IL_0016;
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

				public string[] productGUID;

				public int[] productId;

				public DeviceType deviceType;

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
							num = -1292098544;
							goto IL_0017;
						}
						return false;
						IL_0012:
						num = -1292098541;
						goto IL_0017;
						IL_0017:
						switch (num ^ -1292098543)
						{
						case 0:
							break;
						case 2:
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
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						goto IL_0024;
					}
					int num;
					bool flag = default(bool);
					if (strictMatch)
					{
						if (PidVid.ArrayContains(productGUID, ref bridgedControllerHWInfo.hw_pidVid))
						{
							if (!ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
							{
								return true;
							}
							int num2;
							if (productName != null)
							{
								num = 1740143936;
								num2 = num;
							}
							else
							{
								num = 1740143940;
								num2 = num;
							}
						}
						else
						{
							flag = ProductNameMatches(bridgedControllerHWInfo);
							num = 1740143943;
						}
						goto IL_0029;
					}
					return ProductNameMatches(bridgedControllerHWInfo);
					IL_0029:
					while (true)
					{
						switch (num ^ 0x67B87D44)
						{
						case 2:
							break;
						case 1:
							return false;
						case 0:
							return true;
						case 4:
							if (productName.Length == 0)
							{
								goto IL_00b7;
							}
							return ProductNameMatches(bridgedControllerHWInfo);
						default:
							if (!flag)
							{
								return false;
							}
							return true;
						}
						break;
						IL_00b7:
						num = 1740143940;
					}
					goto IL_0024;
					IL_0024:
					num = 1740143941;
					goto IL_0029;
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

				private bool ProductNameMatches(BridgedControllerHWInfo controller)
				{
					if (controller.hw_isBluetoothDevice)
					{
						while (true)
						{
							int num = -1408184359;
							while (true)
							{
								switch (num ^ -1408184357)
								{
								case 0:
									break;
								case 2:
									goto IL_0026;
								default:
									goto IL_0056;
								}
								break;
								IL_0026:
								if (string.IsNullOrEmpty(controller.hw_bluetoothDeviceName))
								{
									goto end_IL_0008;
								}
								if (!ProductNameMatches(controller.hw_productName))
								{
									if (ProductNameMatches(controller.hw_bluetoothDeviceName))
									{
										num = -1408184358;
										continue;
									}
									return false;
								}
								goto IL_0056;
								IL_0056:
								return true;
							}
							continue;
							end_IL_0008:
							break;
						}
					}
					return ProductNameMatches(controller.hw_productName);
				}

				private bool ProductNameMatches(string name)
				{
					if (!string.IsNullOrEmpty(name))
					{
						string searchIn = default(string);
						int num2 = default(int);
						while (true)
						{
							int num = 2096331264;
							while (true)
							{
								switch (num ^ 0x7CF37A06)
								{
								case 0:
									break;
								case 3:
									return true;
								case 4:
									goto IL_004d;
								case 7:
									goto IL_0069;
								case 1:
									num = 2096331266;
									continue;
								case 6:
									goto IL_00b1;
								case 5:
									goto end_IL_000b;
								default:
									return false;
								}
								break;
								IL_00b1:
								if (productName == null)
								{
									num = 2096331267;
									continue;
								}
								searchIn = name.Trim();
								num2 = 0;
								num = 2096331271;
								continue;
								IL_0069:
								if (productName[num2] == null || productName[num2] == string.Empty || !MatchingCriteria_Base.StringMatches(searchIn, productName[num2], productName_useRegex))
								{
									num2++;
									num = 2096331266;
								}
								else
								{
									num = 2096331269;
								}
								continue;
								IL_004d:
								int num3;
								if (num2 < productName.Length)
								{
									num = 2096331265;
									num3 = num;
								}
								else
								{
									num = 2096331268;
									num3 = num;
								}
							}
							continue;
							end_IL_000b:
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
						matchingCriteria.productName_useRegex = productName_useRegex;
						int num = 987932997;
						while (true)
						{
							switch (num ^ 0x3AE2A945)
							{
							case 2:
								num = 987932996;
								continue;
							case 1:
								break;
							case 0:
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
								matchingCriteria.productId = ArrayTools.ShallowCopy(productId);
								num = 987932998;
								continue;
							default:
								matchingCriteria.deviceType = deviceType;
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
					while (true)
					{
						int num = -923910105;
						while (true)
						{
							switch (num ^ -923910106)
							{
							case 5:
								break;
							default:
								return;
							case 1:
								elementIdentifier = source.elementIdentifier;
								sourceType = source.sourceType;
								sourceButton = source.sourceButton;
								sourceAxis = source.sourceAxis;
								sourceAxisPole = source.sourceAxisPole;
								num = -923910108;
								continue;
							case 2:
								axisDeadZone = source.axisDeadZone;
								sourceHat = source.sourceHat;
								sourceHatType = source.sourceHatType;
								sourceHatDirection = source.sourceHatDirection;
								num = -923910106;
								continue;
							case 0:
								requireMultipleButtons = source.requireMultipleButtons;
								num = -923910107;
								continue;
							case 3:
								requiredButtons = ArrayTools.ShallowCopy(source.requiredButtons);
								ignoreIfButtonsActive = source.ignoreIfButtonsActive;
								ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(source.ignoreIfButtonsActiveButtons);
								buttonInfo = MiscTools.DeepClone(source.buttonInfo);
								num = -923910110;
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
					while (true)
					{
						int num = -807105725;
						while (true)
						{
							switch (num ^ -807105727)
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
							sourceType = HardwareElementSourceTypeWithHat.Axis;
							num = -807105728;
						}
					}
				}

				protected void ImportVars(Axis_Base source)
				{
					ImportVars((Element)source);
					while (true)
					{
						int num = 1622924401;
						while (true)
						{
							switch (num ^ 0x60BBDC75)
							{
							case 3:
								break;
							case 4:
								elementIdentifier = source.elementIdentifier;
								sourceType = source.sourceType;
								num = 1622924405;
								continue;
							case 1:
								axisZero = source.axisZero;
								axisMin = source.axisMin;
								axisMax = source.axisMax;
								num = 1622924407;
								continue;
							case 5:
								axisDeadZone = source.axisDeadZone;
								calibrateAxis = source.calibrateAxis;
								num = 1622924404;
								continue;
							case 0:
								sourceAxis = source.sourceAxis;
								sourceAxisRange = source.sourceAxisRange;
								invert = source.invert;
								num = 1622924400;
								continue;
							default:
								axisInfo = MiscTools.DeepClone(source.axisInfo);
								sourceButton = source.sourceButton;
								buttonAxisContribution = source.buttonAxisContribution;
								sourceHat = source.sourceHat;
								sourceHatDirection = source.sourceHatDirection;
								sourceHatRange = source.sourceHatRange;
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
					switch (-62557578 ^ -62557577)
					{
					case 2:
						continue;
					case 1:
						if (platform_RawOrDirectInput == null)
						{
							return;
						}
						break;
					}
					break;
				}
				platform_RawOrDirectInput.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
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
				private sealed class BgGVdXDddTCKfJQETDrMZfppwko : IDisposable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>, IEnumerable
				{
					private Axis_Base aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public Elements iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public int NkkHtkrtrSxLxJBLYEoBGGBvSQQ;

					Axis_Base IEnumerator<Axis_Base>.Current
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
					IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
						{
							goto IL_0012;
						}
						goto IL_004b;
						IL_0012:
						int num = 2000886588;
						goto IL_0017;
						IL_0017:
						BgGVdXDddTCKfJQETDrMZfppwko bgGVdXDddTCKfJQETDrMZfppwko = default(BgGVdXDddTCKfJQETDrMZfppwko);
						while (true)
						{
							switch (num ^ 0x77431B38)
							{
							case 0:
								break;
							case 3:
								bgGVdXDddTCKfJQETDrMZfppwko.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								num = 2000886585;
								continue;
							case 2:
								goto IL_004b;
							case 4:
								if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
								{
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
									bgGVdXDddTCKfJQETDrMZfppwko = this;
									num = 2000886585;
									continue;
								}
								goto IL_004b;
							default:
								return bgGVdXDddTCKfJQETDrMZfppwko;
							}
							break;
						}
						goto IL_0012;
						IL_004b:
						bgGVdXDddTCKfJQETDrMZfppwko = new BgGVdXDddTCKfJQETDrMZfppwko(0);
						num = 2000886587;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						default:
							num = -41788436;
							goto IL_001a;
						case 0:
							goto IL_0068;
						case 1:
							{
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								NkkHtkrtrSxLxJBLYEoBGGBvSQQ++;
								num = -41788433;
								goto IL_001a;
							}
							IL_001a:
							while (true)
							{
								switch (num ^ -41788434)
								{
								case 3:
									break;
								case 1:
									goto IL_0042;
								case 4:
									goto IL_0068;
								case 5:
									aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.axes[NkkHtkrtrSxLxJBLYEoBGGBvSQQ];
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
									return true;
								case 2:
									num = -41788434;
									continue;
								default:
									goto end_IL_0008;
								}
								break;
								IL_0042:
								int num2;
								if (NkkHtkrtrSxLxJBLYEoBGGBvSQQ >= iKQXbXnVtIaMZEJNeigQJWAHqUx.axes.Length)
								{
									num = -41788434;
									num2 = num;
								}
								else
								{
									num = -41788437;
									num2 = num;
								}
							}
							goto default;
							IL_0068:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.axes == null)
							{
								break;
							}
							NkkHtkrtrSxLxJBLYEoBGGBvSQQ = 0;
							num = -41788433;
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
					public BgGVdXDddTCKfJQETDrMZfppwko(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class pEOGcKCQhfIKwGasKsXCcDumlzW : IDisposable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>, IEnumerable
				{
					private Button_Base aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public Elements iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public int wsJPHLXtQBdAnIgNtRFjVNCitFu;

					Button_Base IEnumerator<Button_Base>.Current
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
					IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
					{
						pEOGcKCQhfIKwGasKsXCcDumlzW pEOGcKCQhfIKwGasKsXCcDumlzW2;
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							pEOGcKCQhfIKwGasKsXCcDumlzW2 = this;
						}
						else
						{
							while (true)
							{
								pEOGcKCQhfIKwGasKsXCcDumlzW2 = new pEOGcKCQhfIKwGasKsXCcDumlzW(0);
								pEOGcKCQhfIKwGasKsXCcDumlzW2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								int num = -1907312771;
								while (true)
								{
									switch (num ^ -1907312769)
									{
									case 0:
										num = -1907312770;
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
						return pEOGcKCQhfIKwGasKsXCcDumlzW2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button_Base>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int num;
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							num = 1568557894;
							goto IL_001f;
						case 0:
							{
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.buttons == null)
								{
									break;
								}
								wsJPHLXtQBdAnIgNtRFjVNCitFu = 0;
								num = 1568557892;
								goto IL_001f;
							}
							IL_001f:
							while (true)
							{
								switch (num ^ 0x5D7E4B47)
								{
								case 5:
									num = 1568557893;
									continue;
								case 1:
									wsJPHLXtQBdAnIgNtRFjVNCitFu++;
									num = 1568557892;
									continue;
								case 4:
									aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.buttons[wsJPHLXtQBdAnIgNtRFjVNCitFu];
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
									num = 1568557889;
									continue;
								case 6:
									return true;
								case 2:
									break;
								case 3:
									goto IL_00bb;
								default:
									goto end_IL_0008;
								}
								break;
								IL_00bb:
								int num2;
								if (wsJPHLXtQBdAnIgNtRFjVNCitFu >= iKQXbXnVtIaMZEJNeigQJWAHqUx.buttons.Length)
								{
									num = 1568557895;
									num2 = num;
								}
								else
								{
									num = 1568557891;
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
					public pEOGcKCQhfIKwGasKsXCcDumlzW(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
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
						BgGVdXDddTCKfJQETDrMZfppwko bgGVdXDddTCKfJQETDrMZfppwko = new BgGVdXDddTCKfJQETDrMZfppwko(-2);
						bgGVdXDddTCKfJQETDrMZfppwko.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
						return bgGVdXDddTCKfJQETDrMZfppwko;
					}
				}

				internal override IEnumerable<Button_Base> Buttons
				{
					get
					{
						pEOGcKCQhfIKwGasKsXCcDumlzW pEOGcKCQhfIKwGasKsXCcDumlzW2 = new pEOGcKCQhfIKwGasKsXCcDumlzW(-2);
						pEOGcKCQhfIKwGasKsXCcDumlzW2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
						return pEOGcKCQhfIKwGasKsXCcDumlzW2;
					}
				}

				internal override Axis_Base GetAxis(int axisIndex)
				{
					if (axes != null)
					{
						while (true)
						{
							int num = -1598488160;
							while (true)
							{
								switch (num ^ -1598488159)
								{
								case 0:
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
									num = -1598488157;
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
							num2 = -1378139416;
							num3 = num2;
						}
						else
						{
							num2 = -1378139412;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -1378139411)
							{
							case 0:
								num2 = -1378139416;
								continue;
							case 1:
								num4 = 0;
								num2 = -1378139410;
								continue;
							case 4:
								break;
							case 2:
								if (buttons[num4].elementIdentifier == elementIdentifier.id)
								{
									num2 = -1378139413;
									continue;
								}
								num4++;
								num2 = -1378139410;
								continue;
							case 6:
								return ControllerElementType.Button;
							case 5:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = -1378139415;
								continue;
							default:
								if (num4 >= buttonCount)
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
						int num2 = -1193988864;
						while (true)
						{
							switch (num2 ^ -1193988862)
							{
							case 7:
								break;
							case 4:
								num++;
								num2 = -1193988862;
								continue;
							case 5:
							{
								int num4;
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									num2 = -1193988854;
									num4 = num2;
								}
								else
								{
									num2 = -1193988858;
									num4 = num2;
								}
								continue;
							}
							case 2:
								num2 = -1193988862;
								continue;
							case 6:
								axisRange = axes[num].sourceAxisRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -1193988861;
									continue;
								}
								goto case 1;
							case 10:
								return true;
							case 3:
								axisRange = InputTools.InvertAxisRange(axisRange);
								num2 = -1193988856;
								continue;
							case 8:
								switch (axes[num].sourceType)
								{
								case HardwareElementSourceTypeWithHat.Axis:
									break;
								default:
									throw new NotImplementedException();
								case HardwareElementSourceTypeWithHat.Button:
									axisRange = AxisRange.Positive;
									return true;
								case HardwareElementSourceTypeWithHat.Hat:
									axisRange = axes[num].sourceHatRange;
									num2 = -1193988853;
									continue;
								}
								goto case 6;
							case 1:
								return true;
							case 9:
							{
								int num3;
								if (!axes[num].invert)
								{
									num2 = -1193988856;
									num3 = num2;
								}
								else
								{
									num2 = -1193988863;
									num3 = num2;
								}
								continue;
							}
							default:
								if (num >= axisCount)
								{
									axisRange = AxisRange.Full;
									return false;
								}
								goto case 5;
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
					if (elements == null)
					{
						return;
					}
					while (true)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
						int num = -321082531;
						while (true)
						{
							switch (num ^ -321082529)
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
							num = -321082530;
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
					while (true)
					{
						int num = -1991406385;
						while (true)
						{
							switch (num ^ -1991406386)
							{
							case 0:
								break;
							case 1:
								goto IL_0024;
							default:
								return axis;
							}
							break;
							IL_0024:
							axis.ImportVars(this);
							num = -1991406388;
						}
					}
				}

				private void ImportVars(Axis source)
				{
					ImportVars((Axis_Base)source);
				}
			}

			private sealed class aQFDQHeojXgcDiFvYTiyuYlhtIu : IDisposable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>, IEnumerable
			{
				private Axis_Base aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_DirectInput_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int RPrHbhcBCgaEhkbjMKqSuqUEEJfc;

				public int wWFoxFIxEWZMUxGhKVPeqdXCdMH;

				Axis_Base IEnumerator<Axis_Base>.Current
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
				IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
				{
					aQFDQHeojXgcDiFvYTiyuYlhtIu aQFDQHeojXgcDiFvYTiyuYlhtIu2;
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						aQFDQHeojXgcDiFvYTiyuYlhtIu2 = this;
						goto IL_0025;
					}
					goto IL_0065;
					IL_002a:
					int num;
					while (true)
					{
						switch (num ^ -305623557)
						{
						case 0:
							break;
						case 1:
							num = -305623553;
							continue;
						case 2:
							aQFDQHeojXgcDiFvYTiyuYlhtIu2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
							num = -305623553;
							continue;
						case 3:
							goto IL_0065;
						default:
							return aQFDQHeojXgcDiFvYTiyuYlhtIu2;
						}
						break;
					}
					goto IL_0025;
					IL_0065:
					aQFDQHeojXgcDiFvYTiyuYlhtIu2 = new aQFDQHeojXgcDiFvYTiyuYlhtIu(0);
					num = -305623559;
					goto IL_002a;
					IL_0025:
					num = -305623558;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 1:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						wWFoxFIxEWZMUxGhKVPeqdXCdMH++;
						num = 1635945416;
						goto IL_001f;
					case 0:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements == null || iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes == null)
							{
								break;
							}
							RPrHbhcBCgaEhkbjMKqSuqUEEJfc = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes.Length;
							wWFoxFIxEWZMUxGhKVPeqdXCdMH = 0;
							num = 1635945420;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x61828BCD)
							{
							case 0:
								num = 1635945423;
								continue;
							case 3:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes[wWFoxFIxEWZMUxGhKVPeqdXCdMH];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 1:
								num = 1635945416;
								continue;
							case 2:
								break;
							case 5:
								goto IL_00df;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00df:
							int num2;
							if (wWFoxFIxEWZMUxGhKVPeqdXCdMH < RPrHbhcBCgaEhkbjMKqSuqUEEJfc)
							{
								num = 1635945422;
								num2 = num;
							}
							else
							{
								num = 1635945417;
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
				public aQFDQHeojXgcDiFvYTiyuYlhtIu(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class mMLJSAkqIBQJYbUsDeLykxPMuMZ : IDisposable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>, IEnumerable
			{
				private Button_Base aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_DirectInput_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int KoJgFdTMVNVOytBBHKWmNrRVmaK;

				public int UNIizaTiexgWYkgpjhWZXiceAEd;

				Button_Base IEnumerator<Button_Base>.Current
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
				IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						goto IL_001c;
					}
					goto IL_0052;
					IL_0052:
					mMLJSAkqIBQJYbUsDeLykxPMuMZ mMLJSAkqIBQJYbUsDeLykxPMuMZ2 = new mMLJSAkqIBQJYbUsDeLykxPMuMZ(0);
					int num = -530320089;
					goto IL_0021;
					IL_001c:
					num = -530320095;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ -530320091)
						{
						case 0:
							break;
						case 4:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							mMLJSAkqIBQJYbUsDeLykxPMuMZ2 = this;
							num = -530320092;
							continue;
						case 3:
							goto IL_0052;
						case 2:
							mMLJSAkqIBQJYbUsDeLykxPMuMZ2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
							num = -530320092;
							continue;
						default:
							return mMLJSAkqIBQJYbUsDeLykxPMuMZ2;
						}
						break;
					}
					goto IL_001c;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button_Base>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 0:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = 1335483397;
						goto IL_001f;
					case 1:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							num = 1335483395;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x4F99DC04)
							{
							case 0:
								num = 1335483394;
								continue;
							case 5:
								break;
							case 7:
								UNIizaTiexgWYkgpjhWZXiceAEd++;
								num = 1335483393;
								continue;
							case 8:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons[UNIizaTiexgWYkgpjhWZXiceAEd];
								num = 1335483399;
								continue;
							case 4:
								UNIizaTiexgWYkgpjhWZXiceAEd = 0;
								num = 1335483393;
								continue;
							case 6:
								goto end_IL_001f;
							case 1:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements != null && iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons != null)
								{
									KoJgFdTMVNVOytBBHKWmNrRVmaK = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons.Length;
									num = 1335483392;
									continue;
								}
								goto end_IL_0008;
							case 3:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (UNIizaTiexgWYkgpjhWZXiceAEd >= KoJgFdTMVNVOytBBHKWmNrRVmaK)
							{
								num = 1335483398;
								num2 = num;
							}
							else
							{
								num = 1335483404;
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
				public mMLJSAkqIBQJYbUsDeLykxPMuMZ(int _003C_003E1__state)
				{
					while (true)
					{
						int num = 2134356428;
						while (true)
						{
							switch (num ^ 0x7F37B1CE)
							{
							case 0:
								break;
							case 2:
								goto IL_0024;
							default:
								HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
								return;
							}
							break;
							IL_0024:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
							num = 2134356431;
						}
					}
				}
			}

			public Elements elements;

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.hQxvcadrrPaLqOjHlvDNLCWZlDw;
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
					int num = -311825448;
					while (true)
					{
						switch (num ^ -311825447)
						{
						case 3:
							break;
						case 1:
							platformMap = null;
							if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
							{
								num = -311825447;
								continue;
							}
							return false;
						case 0:
							platformMap = this;
							num = -311825445;
							continue;
						default:
							return true;
						}
						break;
					}
				}
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				int num = identifiers.Length;
				if (num < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				int num3 = default(int);
				int elementIdentifier = default(int);
				int num5 = default(int);
				int num4 = default(int);
				while (true)
				{
					int num2 = 721254029;
					while (true)
					{
						switch (num2 ^ 0x2AFD768C)
						{
						case 2:
							break;
						case 0:
							num3++;
							num2 = 721254024;
							continue;
						case 6:
							elementIdentifier = elements.axes[num3].elementIdentifier;
							num2 = 721254027;
							continue;
						case 3:
							array[num3] = identifiers[num5].name;
							num2 = 721254028;
							continue;
						case 5:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = 721254028;
							continue;
						case 7:
							num5 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							if (num5 >= 0)
							{
								int num6;
								if (num5 >= num)
								{
									num2 = 721254025;
									num6 = num2;
								}
								else
								{
									num2 = 721254031;
									num6 = num2;
								}
								continue;
							}
							goto case 5;
						case 1:
							num4 = array.Length;
							num3 = 0;
							num2 = 721254024;
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
				int num3 = default(int);
				string[] array = default(string[]);
				int num5 = default(int);
				while (true)
				{
					int num2 = 246362986;
					while (true)
					{
						switch (num2 ^ 0xEAF336F)
						{
						case 4:
							break;
						case 3:
							num3++;
							num2 = 246362989;
							continue;
						case 7:
							array[num3] = identifiers[num5].name;
							num2 = 246362988;
							continue;
						case 8:
						{
							int num6;
							if (num5 >= 0)
							{
								num2 = 246362981;
								num6 = num2;
							}
							else
							{
								num2 = 246362991;
								num6 = num2;
							}
							continue;
						}
						case 9:
						{
							int elementIdentifier = elements.buttons[num3].elementIdentifier;
							num5 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num2 = 246362983;
							continue;
						}
						case 6:
							Logger.LogError("You have too few element identifiers!");
							return new string[0];
						case 0:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = 246362988;
							continue;
						case 10:
						{
							int num7;
							if (num5 >= num)
							{
								num2 = 246362991;
								num7 = num2;
							}
							else
							{
								num2 = 246362984;
								num7 = num2;
							}
							continue;
						}
						case 5:
							if (num >= buttonCount)
							{
								array = new string[buttonCount];
								num3 = 0;
								num2 = 246362989;
							}
							else
							{
								num2 = 246362985;
							}
							continue;
						case 2:
						{
							int num4;
							if (num3 >= buttonCount)
							{
								num2 = 246362990;
								num4 = num2;
							}
							else
							{
								num2 = 246362982;
								num4 = num2;
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
				IEnumerator<Axis_Base> enumerator = IterateAxes().GetEnumerator();
				bool result = default(bool);
				try
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
							int num = -92877331;
							while (true)
							{
								switch (num ^ -92877330)
								{
								case 0:
									num = -92877332;
									continue;
								case 2:
									break;
								default:
									goto end_IL_0030;
								case 3:
									goto IL_011a;
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
							IL_0067:
							int num2 = -92877332;
							while (true)
							{
								switch (num2 ^ -92877330)
								{
								case 0:
									break;
								default:
									goto end_IL_006c;
								case 2:
									goto IL_0085;
								case 1:
									goto end_IL_006c;
								}
								goto IL_0067;
								IL_0085:
								enumerator.Dispose();
								num2 = -92877329;
								continue;
								end_IL_006c:
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
							int num3;
							int num4;
							if (button.elementIdentifier != elementIdentifierId)
							{
								num3 = -92877331;
								num4 = num3;
							}
							else
							{
								num3 = -92877334;
								num4 = num3;
							}
							while (true)
							{
								switch (num3 ^ -92877330)
								{
								case 0:
									num3 = -92877329;
									continue;
								case 1:
									break;
								case 4:
									result = true;
									num3 = -92877332;
									continue;
								default:
									goto end_IL_00c8;
								case 2:
									goto IL_011a;
								}
								break;
							}
							continue;
							end_IL_00c8:
							break;
						}
					}
				}
				return false;
				IL_011a:
				return result;
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
							int num2 = 1448059393;
							while (true)
							{
								switch (num2 ^ 0x564FA203)
								{
								case 3:
									num2 = 1448059394;
									continue;
								case 1:
									break;
								case 2:
									num++;
									num2 = 1448059395;
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
				using (IEnumerator<Axis_Base> enumerator2 = IterateAxes().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator2.Current;
							int num3 = 1448059395;
							while (true)
							{
								switch (num3 ^ 0x564FA203)
								{
								case 4:
									num3 = 1448059392;
									continue;
								case 3:
									break;
								case 1:
									num++;
									num3 = 1448059393;
									continue;
								case 0:
									axes[num] = axis.elementIdentifier;
									num3 = 1448059394;
									continue;
								default:
									goto end_IL_00bf;
								}
								break;
							}
							continue;
							end_IL_00bf:
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
						int num2;
						if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Axis)
						{
							int num3;
							if (axes_orig[num].sourceType == HardwareElementSourceTypeWithHat.Custom)
							{
								num2 = 694232665;
								num3 = num2;
							}
							else
							{
								num2 = 694232661;
								num3 = num2;
							}
							goto IL_0021;
						}
						goto IL_0197;
						IL_0021:
						while (true)
						{
							switch (num2 ^ 0x29612652)
							{
							case 9:
								num2 = 694232670;
								continue;
							case 10:
								array[num].zero = axes_orig[num].axisZero;
								num2 = 694232656;
								continue;
							case 7:
								if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Button)
								{
									goto IL_0091;
								}
								goto case 0;
							case 2:
								array[num].min = axes_orig[num].axisMin;
								num2 = 694232666;
								continue;
							case 13:
								break;
							case 12:
								goto end_IL_0021;
							case 6:
								throw new NotImplementedException();
							case 8:
								array[num].max = axes_orig[num].axisMax;
								num2 = 694232657;
								continue;
							case 3:
								num2 = 694232663;
								continue;
							case 0:
								array[num] = AxisCalibrationData.Default;
								num2 = 694232663;
								continue;
							case 11:
								goto IL_0197;
							case 1:
								num++;
								num2 = 694232662;
								continue;
							case 5:
								array[num].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num].alternateCalibrations, true);
								num2 = 694232659;
								continue;
							default:
								goto end_IL_0119;
							}
							array[num].invert = axes_orig[num].invert;
							array[num].deadZone = axes_orig[num].axisDeadZone;
							int num4;
							if (Axes_orig[num].calibrateAxis)
							{
								num2 = 694232664;
								num4 = num2;
							}
							else
							{
								num2 = 694232663;
								num4 = num2;
							}
							continue;
							IL_0091:
							int num5;
							if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Hat)
							{
								num2 = 694232660;
								num5 = num2;
							}
							else
							{
								num2 = 694232658;
								num5 = num2;
							}
							continue;
							end_IL_0021:
							break;
						}
						continue;
						IL_0197:
						array[num] = AxisCalibrationData.Default;
						num2 = 694232671;
						goto IL_0021;
						continue;
						end_IL_0119:
						break;
					}
				}
				return array;
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
					int num2 = -397811034;
					while (true)
					{
						switch (num2 ^ -397811025)
						{
						case 0:
							num2 = -397811029;
							continue;
						default:
							return;
						case 6:
						{
							int num4;
							if (Axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								num2 = -397811033;
								num4 = num2;
							}
							else
							{
								num2 = -397811030;
								num4 = num2;
							}
							continue;
						}
						case 1:
							num2 = -397811027;
							continue;
						case 11:
							throw new Exception();
						case 3:
							axisInfos[num] = MiscTools.DeepClone(Axes_orig[num].axisInfo, true);
							if (Axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num6;
								if (Axes_orig[num].sourceType == HardwareElementSourceTypeWithHat.Custom)
								{
									num2 = -397811032;
									num6 = num2;
								}
								else
								{
									num2 = -397811031;
									num6 = num2;
								}
								continue;
							}
							goto case 7;
						case 5:
							axisRanges[num] = AxisRange.Full;
							num2 = -397811027;
							continue;
						case 7:
							axisRanges[num] = Axes_orig[num].sourceAxisRange;
							num2 = -397811026;
							continue;
						case 4:
							break;
						case 9:
						{
							int num5;
							if (num < Axes_orig.Length)
							{
								num2 = -397811028;
								num5 = num2;
							}
							else
							{
								num2 = -397811035;
								num5 = num2;
							}
							continue;
						}
						case 8:
						{
							int num3;
							if (Axes_orig[num].sourceType == HardwareElementSourceTypeWithHat.Hat)
							{
								num2 = -397811030;
								num3 = num2;
							}
							else
							{
								num2 = -397811036;
								num3 = num2;
							}
							continue;
						}
						case 2:
							num++;
							num2 = -397811034;
							continue;
						case 10:
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
				int num2 = default(int);
				while (true)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					int num = -785346789;
					while (true)
					{
						switch (num ^ -785346791)
						{
						case 0:
							num = -785346788;
							continue;
						default:
							return;
						case 4:
						{
							int num3;
							if (num2 < Buttons_orig.Length)
							{
								num = -785346792;
								num3 = num;
							}
							else
							{
								num = -785346790;
								num3 = num;
							}
							continue;
						}
						case 2:
							num2 = 0;
							num = -785346787;
							continue;
						case 5:
							break;
						case 1:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
							num2++;
							num = -785346787;
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

			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				aQFDQHeojXgcDiFvYTiyuYlhtIu aQFDQHeojXgcDiFvYTiyuYlhtIu2 = new aQFDQHeojXgcDiFvYTiyuYlhtIu(-2);
				aQFDQHeojXgcDiFvYTiyuYlhtIu2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return aQFDQHeojXgcDiFvYTiyuYlhtIu2;
			}

			internal override IEnumerable<Button_Base> IterateButtons()
			{
				mMLJSAkqIBQJYbUsDeLykxPMuMZ mMLJSAkqIBQJYbUsDeLykxPMuMZ2 = new mMLJSAkqIBQJYbUsDeLykxPMuMZ(-2);
				mMLJSAkqIBQJYbUsDeLykxPMuMZ2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return mMLJSAkqIBQJYbUsDeLykxPMuMZ2;
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
				Platform_DirectInput_Base platform_DirectInput_Base = destination as Platform_DirectInput_Base;
				if (platform_DirectInput_Base == null)
				{
					return;
				}
				while (true)
				{
					platform_DirectInput_Base.elements = MiscTools.DeepClone(elements);
					int num = -1863395458;
					while (true)
					{
						switch (num ^ -1863395457)
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
						num = -1863395459;
					}
				}
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
				int num;
				int num2;
				if (!base.hasVariants)
				{
					num = -1134900891;
					num2 = num;
				}
				else
				{
					num = -1134900889;
					num2 = num;
				}
				goto IL_0012;
				IL_000d:
				num = -1134900890;
				goto IL_0012;
				IL_0012:
				int num3 = default(int);
				while (true)
				{
					switch (num ^ -1134900889)
					{
					case 6:
						break;
					case 4:
					{
						int num4;
						if (num3 >= variants.Length)
						{
							num = -1134900891;
							num4 = num;
						}
						else
						{
							num = -1134900892;
							num4 = num;
						}
						continue;
					}
					case 3:
						if (variants[num3] != null)
						{
							num = -1134900894;
							continue;
						}
						goto IL_00a6;
					case 0:
						num3 = 0;
						num = -1134900893;
						continue;
					case 1:
						return true;
					case 5:
					{
						int variantIndex2;
						if (variants[num3].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
						{
							variantIndex = num3;
							return true;
						}
						goto IL_00a6;
					}
					default:
						{
							return false;
						}
						IL_00a6:
						num3++;
						num = -1134900893;
						continue;
					}
					break;
				}
				goto IL_000d;
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
				while (true)
				{
					switch (0x48EF310D ^ 0x48EF310C)
					{
					case 2:
						continue;
					case 1:
						if (platform_DirectInput == null)
						{
							return;
						}
						break;
					}
					break;
				}
				platform_DirectInput.variants = MiscTools.DeepClone(variants);
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
				private sealed class oEIftjDjPWGcQHauXuUoWsikEGk : IDisposable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>, IEnumerable
				{
					private Axis_Base aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public Elements iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public int IBnDTKcIJyzFjIkzvYZjiMZOBMl;

					Axis_Base IEnumerator<Axis_Base>.Current
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
					IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							goto IL_0023;
						}
						goto IL_004e;
						IL_0028:
						int num;
						oEIftjDjPWGcQHauXuUoWsikEGk oEIftjDjPWGcQHauXuUoWsikEGk2 = default(oEIftjDjPWGcQHauXuUoWsikEGk);
						while (true)
						{
							switch (num ^ -1243091619)
							{
							case 2:
								break;
							case 3:
								oEIftjDjPWGcQHauXuUoWsikEGk2 = this;
								num = -1243091620;
								continue;
							case 0:
								goto IL_004e;
							default:
								return oEIftjDjPWGcQHauXuUoWsikEGk2;
							}
							break;
						}
						goto IL_0023;
						IL_004e:
						oEIftjDjPWGcQHauXuUoWsikEGk2 = new oEIftjDjPWGcQHauXuUoWsikEGk(0);
						oEIftjDjPWGcQHauXuUoWsikEGk2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = -1243091620;
						goto IL_0028;
						IL_0023:
						num = -1243091618;
						goto IL_0028;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int num;
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							IBnDTKcIJyzFjIkzvYZjiMZOBMl++;
							num = -1046069470;
							goto IL_001f;
						case 0:
							{
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								int num3;
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.axes != null)
								{
									num = -1046069471;
									num3 = num;
								}
								else
								{
									num = -1046069469;
									num3 = num;
								}
								goto IL_001f;
							}
							IL_001f:
							while (true)
							{
								switch (num ^ -1046069472)
								{
								case 5:
									num = -1046069468;
									continue;
								case 2:
									break;
								case 1:
									IBnDTKcIJyzFjIkzvYZjiMZOBMl = 0;
									num = -1046069470;
									continue;
								case 0:
									aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.axes[IBnDTKcIJyzFjIkzvYZjiMZOBMl];
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
									return true;
								case 4:
									goto end_IL_001f;
								default:
									goto end_IL_0008;
								}
								int num2;
								if (IBnDTKcIJyzFjIkzvYZjiMZOBMl < iKQXbXnVtIaMZEJNeigQJWAHqUx.axes.Length)
								{
									num = -1046069472;
									num2 = num;
								}
								else
								{
									num = -1046069469;
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
					public oEIftjDjPWGcQHauXuUoWsikEGk(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class bNDFhXCZrcJTReMKPgfQTxKuJYv : IDisposable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>, IEnumerable
				{
					private Button_Base aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public Elements iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public int XifusthcmwrsPIdrADMqDBBaftYe;

					Button_Base IEnumerator<Button_Base>.Current
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
					IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
					{
						bNDFhXCZrcJTReMKPgfQTxKuJYv bNDFhXCZrcJTReMKPgfQTxKuJYv2;
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							bNDFhXCZrcJTReMKPgfQTxKuJYv2 = this;
							goto IL_0025;
						}
						goto IL_0065;
						IL_002a:
						int num;
						while (true)
						{
							switch (num ^ -577068589)
							{
							case 2:
								break;
							case 3:
								num = -577068589;
								continue;
							case 1:
								bNDFhXCZrcJTReMKPgfQTxKuJYv2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								num = -577068589;
								continue;
							case 4:
								goto IL_0065;
							default:
								return bNDFhXCZrcJTReMKPgfQTxKuJYv2;
							}
							break;
						}
						goto IL_0025;
						IL_0065:
						bNDFhXCZrcJTReMKPgfQTxKuJYv2 = new bNDFhXCZrcJTReMKPgfQTxKuJYv(0);
						num = -577068590;
						goto IL_002a;
						IL_0025:
						num = -577068592;
						goto IL_002a;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button_Base>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
						while (true)
						{
							int num2 = -579428997;
							while (true)
							{
								switch (num2 ^ -579428999)
								{
								case 6:
									break;
								case 2:
									switch (num)
									{
									default:
										num2 = -579428996;
										continue;
									case 1:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
										XifusthcmwrsPIdrADMqDBBaftYe++;
										num2 = -579428995;
										continue;
									case 0:
										break;
									}
									goto case 1;
								case 4:
								{
									int num3;
									if (XifusthcmwrsPIdrADMqDBBaftYe < iKQXbXnVtIaMZEJNeigQJWAHqUx.buttons.Length)
									{
										num2 = -579428999;
										num3 = num2;
									}
									else
									{
										num2 = -579428996;
										num3 = num2;
									}
									continue;
								}
								case 0:
									aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.buttons[XifusthcmwrsPIdrADMqDBBaftYe];
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
									return true;
								case 3:
									num2 = -579428995;
									continue;
								case 1:
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
									if (iKQXbXnVtIaMZEJNeigQJWAHqUx.buttons != null)
									{
										XifusthcmwrsPIdrADMqDBBaftYe = 0;
										num2 = -579428998;
										continue;
									}
									goto default;
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
					public bNDFhXCZrcJTReMKPgfQTxKuJYv(int _003C_003E1__state)
					{
						while (true)
						{
							int num = 726183841;
							while (true)
							{
								switch (num ^ 0x2B48AFA0)
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
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
								HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
								num = 726183842;
							}
						}
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
						oEIftjDjPWGcQHauXuUoWsikEGk oEIftjDjPWGcQHauXuUoWsikEGk2 = new oEIftjDjPWGcQHauXuUoWsikEGk(-2);
						oEIftjDjPWGcQHauXuUoWsikEGk2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
						return oEIftjDjPWGcQHauXuUoWsikEGk2;
					}
				}

				internal override IEnumerable<Button_Base> Buttons
				{
					get
					{
						bNDFhXCZrcJTReMKPgfQTxKuJYv bNDFhXCZrcJTReMKPgfQTxKuJYv2 = new bNDFhXCZrcJTReMKPgfQTxKuJYv(-2);
						bNDFhXCZrcJTReMKPgfQTxKuJYv2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
						return bNDFhXCZrcJTReMKPgfQTxKuJYv2;
					}
				}

				internal override Axis_Base GetAxis(int axisIndex)
				{
					if (axes != null)
					{
						while (true)
						{
							int num = 1581827915;
							while (true)
							{
								switch (num ^ 0x5E48C74A)
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
									num = 1581827914;
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
							num2 = -893427453;
							num3 = num2;
						}
						else
						{
							num2 = -893427452;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -893427456)
							{
							case 5:
								num2 = -893427453;
								continue;
							case 4:
								num4 = 0;
								num2 = -893427456;
								continue;
							case 1:
								break;
							case 2:
								if (buttons[num4].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num4++;
								num2 = -893427456;
								continue;
							case 3:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = -893427455;
								continue;
							default:
								if (num4 >= buttonCount)
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
					HardwareElementSourceTypeWithHat sourceType = default(HardwareElementSourceTypeWithHat);
					while (true)
					{
						int num2 = 167885154;
						while (true)
						{
							switch (num2 ^ 0xA01B966)
							{
							case 0:
								break;
							case 3:
								axisRange = axes[num].sourceAxisRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 167885155;
									continue;
								}
								goto case 5;
							case 8:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									sourceType = axes[num].sourceType;
									switch (sourceType)
									{
									case HardwareElementSourceTypeWithHat.Axis:
										break;
									default:
										goto IL_009e;
									case HardwareElementSourceTypeWithHat.Button:
										axisRange = AxisRange.Positive;
										return true;
									case HardwareElementSourceTypeWithHat.Hat:
										goto IL_00bd;
									}
									goto case 3;
								}
								goto case 1;
							case 1:
								num++;
								num2 = 167885156;
								continue;
							case 5:
								return true;
							case 6:
								return true;
							case 7:
								if (sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									throw new NotImplementedException();
								}
								num2 = 167885157;
								continue;
							case 4:
								num2 = 167885156;
								continue;
							default:
								{
									if (num >= axisCount)
									{
										axisRange = AxisRange.Full;
										return false;
									}
									goto case 8;
								}
								IL_009e:
								num2 = 167885153;
								continue;
								IL_00bd:
								axisRange = axes[num].sourceHatRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 167885152;
									continue;
								}
								goto case 6;
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
						int num = 1639190250;
						while (true)
						{
							switch (num ^ 0x61B40EE8)
							{
							case 3:
								break;
							case 2:
							{
								int num2;
								if (elements != null)
								{
									num = 1639190248;
									num2 = num;
								}
								else
								{
									num = 1639190249;
									num2 = num;
								}
								continue;
							}
							case 1:
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
					while (true)
					{
						int num = 338394913;
						while (true)
						{
							switch (num ^ 0x142B7F20)
							{
							case 0:
								break;
							case 1:
								goto IL_0024;
							default:
								return axis;
							}
							break;
							IL_0024:
							axis.ImportVars(this);
							num = 338394914;
						}
					}
				}

				private void ImportVars(Axis source)
				{
					ImportVars((Axis_Base)source);
					sourceOtherAxis = source.sourceOtherAxis;
				}
			}

			private sealed class vbVrtnidbMEyEtUzwhBDHTcmzCK : IDisposable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>, IEnumerable
			{
				private Axis_Base aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_RawInput_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int sZrCCLfxJvfHbNZRRyvoEVSWAvPC;

				public int NnEGXWuCeDAUoFxuzLbbxRJxdMk;

				Axis_Base IEnumerator<Axis_Base>.Current
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
				IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						goto IL_001c;
					}
					goto IL_0050;
					IL_0050:
					vbVrtnidbMEyEtUzwhBDHTcmzCK vbVrtnidbMEyEtUzwhBDHTcmzCK2 = new vbVrtnidbMEyEtUzwhBDHTcmzCK(0);
					vbVrtnidbMEyEtUzwhBDHTcmzCK2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					int num = 231611934;
					goto IL_0021;
					IL_001c:
					num = 231611931;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ 0xDCE1E1A)
						{
						case 2:
							break;
						case 1:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							num = 231611930;
							continue;
						case 3:
							goto IL_0050;
						case 0:
							vbVrtnidbMEyEtUzwhBDHTcmzCK2 = this;
							num = 231611934;
							continue;
						default:
							return vbVrtnidbMEyEtUzwhBDHTcmzCK2;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 0:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements == null || iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes == null)
						{
							break;
						}
						sZrCCLfxJvfHbNZRRyvoEVSWAvPC = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes.Length;
						num = 611436125;
						goto IL_001f;
					case 1:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							num = 611436127;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x2471C65C)
							{
							case 4:
								num = 611436122;
								continue;
							case 6:
								break;
							case 0:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes[NnEGXWuCeDAUoFxuzLbbxRJxdMk];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 2:
								goto IL_00cd;
							case 1:
								NnEGXWuCeDAUoFxuzLbbxRJxdMk = 0;
								num = 611436126;
								continue;
							case 3:
								NnEGXWuCeDAUoFxuzLbbxRJxdMk++;
								num = 611436126;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00cd:
							int num2;
							if (NnEGXWuCeDAUoFxuzLbbxRJxdMk >= sZrCCLfxJvfHbNZRRyvoEVSWAvPC)
							{
								num = 611436121;
								num2 = num;
							}
							else
							{
								num = 611436124;
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
				public vbVrtnidbMEyEtUzwhBDHTcmzCK(int _003C_003E1__state)
				{
					while (true)
					{
						int num = -962889056;
						while (true)
						{
							switch (num ^ -962889055)
							{
							case 2:
								break;
							default:
								return;
							case 1:
								goto IL_0024;
							case 0:
								return;
							}
							break;
							IL_0024:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
							HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
							num = -962889055;
						}
					}
				}
			}

			private sealed class izRTligNSyOgRzkbPwLQGjbManO : IDisposable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>, IEnumerable
			{
				private Button_Base aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_RawInput_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int JnLUSLDuklgVaWrdmUOiRwyKBKB;

				public int XoJvjiqomGVHxVsmvCQmVWRrCpF;

				Button_Base IEnumerator<Button_Base>.Current
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
				IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						goto IL_0023;
					}
					goto IL_0049;
					IL_0028:
					int num;
					izRTligNSyOgRzkbPwLQGjbManO izRTligNSyOgRzkbPwLQGjbManO2 = default(izRTligNSyOgRzkbPwLQGjbManO);
					while (true)
					{
						switch (num ^ -1447583080)
						{
						case 0:
							break;
						case 1:
							goto IL_0049;
						case 2:
							num = -1447583077;
							continue;
						case 4:
							izRTligNSyOgRzkbPwLQGjbManO2 = this;
							num = -1447583078;
							continue;
						default:
							return izRTligNSyOgRzkbPwLQGjbManO2;
						}
						break;
					}
					goto IL_0023;
					IL_0049:
					izRTligNSyOgRzkbPwLQGjbManO2 = new izRTligNSyOgRzkbPwLQGjbManO(0);
					izRTligNSyOgRzkbPwLQGjbManO2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					num = -1447583077;
					goto IL_0028;
					IL_0023:
					num = -1447583076;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 1:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						XoJvjiqomGVHxVsmvCQmVWRrCpF++;
						num = 30168253;
						goto IL_001f;
					case 0:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							num = 30168252;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x1CC54BA)
							{
							case 0:
								num = 30168254;
								continue;
							case 5:
								JnLUSLDuklgVaWrdmUOiRwyKBKB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons.Length;
								XoJvjiqomGVHxVsmvCQmVWRrCpF = 0;
								num = 30168248;
								continue;
							case 1:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 7:
								break;
							case 6:
								goto IL_00c0;
							case 8:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons[XoJvjiqomGVHxVsmvCQmVWRrCpF];
								num = 30168251;
								continue;
							case 2:
								num = 30168253;
								continue;
							case 4:
								goto end_IL_001f;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (XoJvjiqomGVHxVsmvCQmVWRrCpF < JnLUSLDuklgVaWrdmUOiRwyKBKB)
							{
								num = 30168242;
								num2 = num;
							}
							else
							{
								num = 30168249;
								num2 = num;
							}
							continue;
							IL_00c0:
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements == null)
							{
								goto end_IL_0008;
							}
							int num3;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons != null)
							{
								num = 30168255;
								num3 = num;
							}
							else
							{
								num = 30168249;
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
				public izRTligNSyOgRzkbPwLQGjbManO(int _003C_003E1__state)
				{
					while (true)
					{
						int num = 3670419;
						while (true)
						{
							switch (num ^ 0x380191)
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
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
							HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
							num = 3670416;
						}
					}
				}
			}

			public Elements elements;

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.PmnSHpCUoGadlRLWMAbfdlxfwVg;
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
					goto IL_0015;
				}
				string[] array = new string[elements.axisCount];
				int num2 = array.Length;
				int num3 = 0;
				int num4 = 742825522;
				goto IL_001a;
				IL_001a:
				int num5 = default(int);
				while (true)
				{
					switch (num4 ^ 0x2C469E3A)
					{
					case 2:
						break;
					case 1:
						Logger.LogError("You have too few element identifiers!");
						num4 = 742825532;
						continue;
					case 7:
						Logger.LogError("Element identifier index is out of bounds!");
						num4 = 742825530;
						continue;
					case 5:
						array[num3] = identifiers[num5].name;
						num4 = 742825530;
						continue;
					case 8:
						num4 = 742825534;
						continue;
					case 0:
						num3++;
						num4 = 742825534;
						continue;
					case 3:
					{
						int elementIdentifier = elements.axes[num3].elementIdentifier;
						num5 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						if (num5 >= 0)
						{
							int num6;
							if (num5 >= num)
							{
								num4 = 742825533;
								num6 = num4;
							}
							else
							{
								num4 = 742825535;
								num6 = num4;
							}
							continue;
						}
						goto case 7;
					}
					case 6:
						return new string[0];
					default:
						if (num3 >= num2)
						{
							return array;
						}
						goto case 3;
					}
					break;
				}
				goto IL_0015;
				IL_0015:
				num4 = 742825531;
				goto IL_001a;
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
				int num2 = 0;
				int num4 = default(int);
				while (true)
				{
					int num3 = -1119001339;
					while (true)
					{
						switch (num3 ^ -1119001343)
						{
						case 6:
							break;
						case 4:
							num3 = -1119001340;
							continue;
						case 3:
							array[num2] = identifiers[num4].name;
							num3 = -1119001341;
							continue;
						case 2:
							num2++;
							num3 = -1119001340;
							continue;
						case 1:
							Logger.LogError("Element identifier index is out of bounds!");
							num3 = -1119001341;
							continue;
						case 0:
						{
							int elementIdentifier = elements.buttons[num2].elementIdentifier;
							num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							if (num4 >= 0)
							{
								int num5;
								if (num4 >= num)
								{
									num3 = -1119001344;
									num5 = num3;
								}
								else
								{
									num3 = -1119001342;
									num5 = num3;
								}
								continue;
							}
							goto case 1;
						}
						default:
							if (num2 >= buttonCount)
							{
								return array;
							}
							goto case 0;
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
				using (IEnumerator<Button_Base> enumerator2 = IterateButtons().GetEnumerator())
				{
					while (true)
					{
						IL_00b5:
						int num;
						int num2;
						if (enumerator2.MoveNext())
						{
							num = 161940814;
							num2 = num;
						}
						else
						{
							num = 161940815;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x9A7054C)
							{
							case 0:
								goto IL_0072;
							default:
								goto end_IL_0077;
							case 2:
							{
								Button button = (Button)enumerator2.Current;
								if (button.elementIdentifier == elementIdentifierId)
								{
									return true;
								}
								break;
							}
							case 1:
								break;
							case 3:
								goto end_IL_0077;
							}
							goto IL_00b5;
							IL_0072:
							num = 161940814;
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
				axes = new int[assignedAxisCount];
				int num = 0;
				using (IEnumerator<Button_Base> enumerator = IterateButtons().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Button button = (Button)enumerator.Current;
							int num2 = 566961507;
							while (true)
							{
								switch (num2 ^ 0x21CB2561)
								{
								case 0:
									num2 = 566961506;
									continue;
								case 3:
									break;
								case 2:
									buttons[num] = button.elementIdentifier;
									num++;
									num2 = 566961504;
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
				using (IEnumerator<Axis_Base> enumerator2 = IterateAxes().GetEnumerator())
				{
					while (true)
					{
						int num3;
						int num4;
						if (enumerator2.MoveNext())
						{
							num3 = 566961504;
							num4 = num3;
						}
						else
						{
							num3 = 566961509;
							num4 = num3;
						}
						while (true)
						{
							switch (num3 ^ 0x21CB2561)
							{
							case 2:
								num3 = 566961504;
								continue;
							default:
								return;
							case 1:
							{
								Axis axis = (Axis)enumerator2.Current;
								axes[num] = axis.elementIdentifier;
								num3 = 566961505;
								continue;
							}
							case 3:
								break;
							case 0:
								num++;
								num3 = 566961506;
								continue;
							case 4:
								return;
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
					int num = 629951310;
					while (true)
					{
						switch (num ^ 0x258C4B4F)
						{
						case 8:
							break;
						case 6:
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num5;
								if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Hat)
								{
									num = 629951302;
									num5 = num;
								}
								else
								{
									num = 629951311;
									num5 = num;
								}
								continue;
							}
							goto case 9;
						case 2:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num2++;
							num = 629951300;
							continue;
						case 9:
							array[num2] = AxisCalibrationData.Default;
							num = 629951309;
							continue;
						case 7:
						{
							int num3;
							if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Axis)
							{
								num = 629951306;
								num3 = num;
							}
							else
							{
								num = 629951301;
								num3 = num;
							}
							continue;
						}
						case 0:
							throw new NotImplementedException();
						case 4:
							if (Axes_orig[num2].calibrateAxis)
							{
								array[num2].zero = axes_orig[num2].axisZero;
								num = 629951308;
								continue;
							}
							goto case 2;
						case 3:
							array[num2].min = axes_orig[num2].axisMin;
							array[num2].max = axes_orig[num2].axisMax;
							num = 629951309;
							continue;
						case 5:
							array[num2] = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							num = 629951307;
							continue;
						case 1:
							num2 = 0;
							num = 629951300;
							continue;
						case 10:
						{
							int num4;
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Custom)
							{
								num = 629951305;
								num4 = num;
							}
							else
							{
								num = 629951306;
								num4 = num;
							}
							continue;
						}
						default:
							if (num2 >= axes_orig.Length)
							{
								return array;
							}
							goto case 7;
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
					int num = -556409062;
					while (true)
					{
						switch (num ^ -556409072)
						{
						case 0:
							break;
						case 8:
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num4;
								if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Hat)
								{
									num = -556409070;
									num4 = num;
								}
								else
								{
									num = -556409071;
									num4 = num;
								}
								continue;
							}
							goto case 2;
						case 9:
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num3;
								if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									num = -556409064;
									num3 = num;
								}
								else
								{
									num = -556409069;
									num3 = num;
								}
								continue;
							}
							goto case 3;
						case 5:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							num = -556409063;
							continue;
						case 3:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -556409065;
							continue;
						case 2:
							axisRanges[num2] = AxisRange.Full;
							num = -556409061;
							continue;
						case 10:
							if (Axes_orig == null)
							{
								return;
							}
							goto case 6;
						case 1:
							throw new Exception();
						case 11:
							num = -556409065;
							continue;
						case 6:
							axisRanges = new AxisRange[Axes_orig.Length];
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = -556409068;
							continue;
						case 7:
							num2++;
							num = -556409068;
							continue;
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
				int num2 = default(int);
				while (true)
				{
					int num = -454064603;
					while (true)
					{
						switch (num ^ -454064604)
						{
						case 0:
							break;
						case 3:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
							num2++;
							num = -454064602;
							continue;
						case 4:
							buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
							num = -454064607;
							continue;
						case 5:
							num2 = 0;
							num = -454064602;
							continue;
						case 1:
							if (Buttons_orig == null)
							{
								return;
							}
							goto case 4;
						default:
							if (num2 >= Buttons_orig.Length)
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
				vbVrtnidbMEyEtUzwhBDHTcmzCK vbVrtnidbMEyEtUzwhBDHTcmzCK2 = new vbVrtnidbMEyEtUzwhBDHTcmzCK(-2);
				vbVrtnidbMEyEtUzwhBDHTcmzCK2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return vbVrtnidbMEyEtUzwhBDHTcmzCK2;
			}

			internal override IEnumerable<Button_Base> IterateButtons()
			{
				izRTligNSyOgRzkbPwLQGjbManO izRTligNSyOgRzkbPwLQGjbManO2 = new izRTligNSyOgRzkbPwLQGjbManO(-2);
				izRTligNSyOgRzkbPwLQGjbManO2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return izRTligNSyOgRzkbPwLQGjbManO2;
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
					switch (-130606020 ^ -130606018)
					{
					case 0:
						continue;
					case 2:
						if (platform_RawInput_Base == null)
						{
							return;
						}
						break;
					}
					break;
				}
				platform_RawInput_Base.elements = MiscTools.DeepClone(elements);
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
					goto IL_000d;
				}
				int num = default(int);
				int num2;
				if (base.hasVariants)
				{
					num = 0;
					num2 = -1443531942;
					goto IL_0012;
				}
				goto IL_0091;
				IL_0012:
				while (true)
				{
					switch (num2 ^ -1443531943)
					{
					case 0:
						break;
					case 3:
						goto IL_0033;
					case 1:
						goto IL_004f;
					case 2:
						return true;
					default:
						goto IL_0091;
					}
					break;
					IL_004f:
					int variantIndex2;
					if (variants[num] != null && variants[num].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
					{
						variantIndex = num;
						return true;
					}
					num++;
					num2 = -1443531942;
					continue;
					IL_0033:
					int num3;
					if (num >= variants.Length)
					{
						num2 = -1443531939;
						num3 = num2;
					}
					else
					{
						num2 = -1443531944;
						num3 = num2;
					}
				}
				goto IL_000d;
				IL_0091:
				return false;
				IL_000d:
				num2 = -1443531941;
				goto IL_0012;
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
				Platform_RawInput platform_RawInput = destination as Platform_RawInput;
				if (platform_RawInput != null)
				{
					platform_RawInput.variants = MiscTools.DeepClone(variants);
				}
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
							goto IL_0008;
						}
						int num;
						if (subType.Length == 0)
						{
							num = -2034841081;
							goto IL_000d;
						}
						return true;
						IL_0008:
						num = -2034841084;
						goto IL_000d;
						IL_000d:
						switch (num ^ -2034841082)
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
					if (bridgedControllerHWInfo.isMock)
					{
						goto IL_001c;
					}
					goto IL_008c;
					IL_008c:
					int num = 0;
					int num2 = 1240089128;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num2 ^ 0x49EA422A)
						{
						case 5:
							break;
						case 2:
							num2 = 1240089132;
							continue;
						case 0:
							goto IL_0055;
						case 3:
							goto IL_006c;
						case 4:
							goto IL_007b;
						case 1:
							return true;
						case 7:
							return true;
						default:
							if (num >= subType.Length)
							{
								return false;
							}
							goto IL_0055;
						}
						break;
						IL_007b:
						if (hasData)
						{
							num2 = 1240089129;
							continue;
						}
						goto IL_008c;
						IL_0055:
						if (subType[num] == bridgedControllerHWInfo.hw_xInputSubType)
						{
							num2 = 1240089133;
							continue;
						}
						num++;
						num2 = 1240089132;
						continue;
						IL_006c:
						if (isAllowed)
						{
							num2 = 1240089131;
							continue;
						}
						goto IL_008c;
					}
					goto IL_001c;
					IL_001c:
					num2 = 1240089134;
					goto IL_0021;
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
					while (true)
					{
						int num = -41063659;
						while (true)
						{
							switch (num ^ -41063658)
							{
							case 2:
								break;
							default:
								return;
							case 3:
								if (matchingCriteria != null)
								{
									goto IL_003b;
								}
								return;
							case 0:
								goto IL_003b;
							case 1:
								return;
							}
							break;
							IL_003b:
							matchingCriteria.subType = ArrayTools.ShallowCopy(subType);
							num = -41063657;
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
							switch (0x66BB539B ^ 0x66BB539A)
							{
							case 2:
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

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					int num = 0;
					int num2 = default(int);
					while (true)
					{
						IL_0079:
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = 1959013992;
							goto IL_0009;
						}
						goto IL_0057;
						IL_0009:
						while (true)
						{
							switch (num3 ^ 0x74C42E6C)
							{
							case 2:
								num3 = 1959013997;
								continue;
							case 4:
								num3 = 1959013996;
								continue;
							case 3:
								break;
							case 1:
								goto end_IL_0009;
							case 5:
								goto IL_0079;
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
							num3 = 1959013996;
							continue;
							end_IL_0009:
							break;
						}
						goto IL_0057;
						IL_0057:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							break;
						}
						num++;
						num3 = 1959013993;
						goto IL_0009;
					}
					return ControllerElementType.Axis;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					HardwareElementSourceType sourceType = default(HardwareElementSourceType);
					while (true)
					{
						IL_0102:
						int num2;
						if (num >= axisCount)
						{
							axisRange = AxisRange.Full;
							num2 = -837243261;
							goto IL_000c;
						}
						goto IL_0048;
						IL_011b:
						num++;
						num2 = -837243250;
						goto IL_000c;
						IL_0048:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							sourceType = axes[num].sourceType;
							num2 = -837243254;
							goto IL_000c;
						}
						goto IL_011b;
						IL_000c:
						while (true)
						{
							switch (num2 ^ -837243254)
							{
							case 5:
								num2 = -837243251;
								continue;
							case 7:
								break;
							case 2:
								goto IL_0075;
							case 3:
								return true;
							case 6:
								goto IL_00b9;
							case 8:
								return true;
							case 10:
								axisRange = InputTools.InvertAxisRange(axisRange);
								num2 = -837243262;
								continue;
							case 0:
								goto IL_00ea;
							case 4:
								goto IL_0102;
							case 1:
								goto IL_011b;
							default:
								return false;
							}
							break;
							IL_00ea:
							switch (sourceType)
							{
							case HardwareElementSourceType.Axis:
								break;
							case HardwareElementSourceType.Button:
								axisRange = AxisRange.Positive;
								num2 = -837243255;
								continue;
							default:
								num2 = -837243252;
								continue;
							}
							goto IL_0075;
							IL_00b9:
							if (sourceType != HardwareElementSourceType.Custom)
							{
								throw new NotImplementedException();
							}
							num2 = -837243256;
							continue;
							IL_0075:
							axisRange = axes[num].sourceAxisRange;
							int num3;
							if (!axes[num].invert)
							{
								num2 = -837243262;
								num3 = num2;
							}
							else
							{
								num2 = -837243264;
								num3 = num2;
							}
						}
						goto IL_0048;
					}
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
					Button button = default(Button);
					while (true)
					{
						int num = 434517317;
						while (true)
						{
							switch (num ^ 0x19E63547)
							{
							case 3:
								break;
							case 2:
							{
								button = destination as Button;
								int num2;
								if (button == null)
								{
									num = 434517318;
									num2 = num;
								}
								else
								{
									num = 434517319;
									num2 = num;
								}
								continue;
							}
							case 1:
								return;
							default:
								button.sourceAxisPole = sourceAxisPole;
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
					Axis axis = default(Axis);
					while (true)
					{
						int num = -884672044;
						while (true)
						{
							switch (num ^ -884672048)
							{
							case 6:
								break;
							case 2:
								axis.calibrateAxis = calibrateAxis;
								axis.axisZero = axisZero;
								axis.axisMin = axisMin;
								axis.axisMax = axisMax;
								num = -884672048;
								continue;
							case 5:
							{
								int num2;
								if (axis == null)
								{
									num = -884672045;
									num2 = num;
								}
								else
								{
									num = -884672047;
									num2 = num;
								}
								continue;
							}
							case 4:
								axis = destination as Axis;
								num = -884672043;
								continue;
							case 1:
								axis.invert = invert;
								axis.buttonAxisContribution = buttonAxisContribution;
								axis.sourceAxisRange = sourceAxisRange;
								num = -884672046;
								continue;
							case 3:
								return;
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

			private sealed class kMZgcLEpgNHaxWVntJWHbchufCPH : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_XInput_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int juTPvJNHdBaHEcZYSUUDNkVgdrYB;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
					{
						goto IL_0012;
					}
					goto IL_0063;
					IL_0012:
					int num = -546652260;
					goto IL_0017;
					IL_0017:
					kMZgcLEpgNHaxWVntJWHbchufCPH kMZgcLEpgNHaxWVntJWHbchufCPH2 = default(kMZgcLEpgNHaxWVntJWHbchufCPH);
					while (true)
					{
						switch (num ^ -546652257)
						{
						case 4:
							break;
						case 3:
							goto IL_0038;
						case 0:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							kMZgcLEpgNHaxWVntJWHbchufCPH2 = this;
							num = -546652259;
							continue;
						case 1:
							goto IL_0063;
						default:
							return kMZgcLEpgNHaxWVntJWHbchufCPH2;
						}
						break;
						IL_0038:
						int num2;
						if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg != -2)
						{
							num = -546652258;
							num2 = num;
						}
						else
						{
							num = -546652257;
							num2 = num;
						}
					}
					goto IL_0012;
					IL_0063:
					kMZgcLEpgNHaxWVntJWHbchufCPH2 = new kMZgcLEpgNHaxWVntJWHbchufCPH(0);
					kMZgcLEpgNHaxWVntJWHbchufCPH2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					num = -546652259;
					goto IL_0017;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
					while (true)
					{
						int num2 = 38690591;
						while (true)
						{
							switch (num2 ^ 0x24E5F1D)
							{
							case 7:
								break;
							case 8:
							{
								int num4;
								if (juTPvJNHdBaHEcZYSUUDNkVgdrYB >= iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes.Length)
								{
									num2 = 38690585;
									num4 = num2;
								}
								else
								{
									num2 = 38690590;
									num4 = num2;
								}
								continue;
							}
							case 9:
								return true;
							case 3:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes[juTPvJNHdBaHEcZYSUUDNkVgdrYB];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num2 = 38690580;
								continue;
							case 0:
							{
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								int num3;
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements != null)
								{
									num2 = 38690584;
									num3 = num2;
								}
								else
								{
									num2 = 38690585;
									num3 = num2;
								}
								continue;
							}
							case 5:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes != null)
								{
									juTPvJNHdBaHEcZYSUUDNkVgdrYB = 0;
									num2 = 38690581;
									continue;
								}
								goto default;
							case 6:
								juTPvJNHdBaHEcZYSUUDNkVgdrYB++;
								num2 = 38690581;
								continue;
							case 1:
								num2 = 38690585;
								continue;
							case 2:
								switch (num)
								{
								case 1:
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
									num2 = 38690587;
									continue;
								case 0:
									break;
								default:
									num2 = 38690588;
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
				public kMZgcLEpgNHaxWVntJWHbchufCPH(int _003C_003E1__state)
				{
					while (true)
					{
						int num = -1157154403;
						while (true)
						{
							switch (num ^ -1157154404)
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
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
							HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
							num = -1157154402;
						}
					}
				}
			}

			private sealed class ZKYgFCkGoKGBaTbUmdSbiAZlFPBs : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_XInput_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int KXWlBXAXOgHeCKjdKBLkjeyEhBsh;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
					{
						goto IL_0012;
					}
					goto IL_0052;
					IL_0012:
					int num = -597515227;
					goto IL_0017;
					IL_0017:
					ZKYgFCkGoKGBaTbUmdSbiAZlFPBs zKYgFCkGoKGBaTbUmdSbiAZlFPBs = default(ZKYgFCkGoKGBaTbUmdSbiAZlFPBs);
					while (true)
					{
						switch (num ^ -597515228)
						{
						case 3:
							break;
						case 1:
							if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
							{
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
								zKYgFCkGoKGBaTbUmdSbiAZlFPBs = this;
								num = -597515232;
								continue;
							}
							goto IL_0052;
						case 2:
							goto IL_0052;
						case 4:
							num = -597515228;
							continue;
						default:
							return zKYgFCkGoKGBaTbUmdSbiAZlFPBs;
						}
						break;
					}
					goto IL_0012;
					IL_0052:
					zKYgFCkGoKGBaTbUmdSbiAZlFPBs = new ZKYgFCkGoKGBaTbUmdSbiAZlFPBs(0);
					zKYgFCkGoKGBaTbUmdSbiAZlFPBs.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					num = -597515228;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 0:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements == null || iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons == null)
						{
							break;
						}
						KXWlBXAXOgHeCKjdKBLkjeyEhBsh = 0;
						num = -2142241156;
						goto IL_001f;
					case 1:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							KXWlBXAXOgHeCKjdKBLkjeyEhBsh++;
							num = -2142241155;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -2142241160)
							{
							case 6:
								num = -2142241159;
								continue;
							case 1:
								break;
							case 2:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 5:
								goto IL_00ad;
							case 4:
								num = -2142241155;
								continue;
							case 0:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons[KXWlBXAXOgHeCKjdKBLkjeyEhBsh];
								num = -2142241158;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00ad:
							int num2;
							if (KXWlBXAXOgHeCKjdKBLkjeyEhBsh >= iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons.Length)
							{
								num = -2142241157;
								num2 = num;
							}
							else
							{
								num = -2142241160;
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
				public ZKYgFCkGoKGBaTbUmdSbiAZlFPBs(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
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
					return InputPlatform.VqUKRozySjqEFelrCfPDPBJTuhE;
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
					if (assignedAxisCount == 0)
					{
						while (true)
						{
							int num = -1449275144;
							while (true)
							{
								switch (num ^ -1449275142)
								{
								case 0:
									break;
								case 2:
									goto IL_003f;
								default:
									return false;
								}
								break;
								IL_003f:
								if (assignedButtonCount != 0)
								{
									goto end_IL_0021;
								}
								num = -1449275141;
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
				if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
				{
					platformMap = this;
					return true;
				}
				return false;
			}

			internal IEnumerable<Axis> IterateAxes()
			{
				kMZgcLEpgNHaxWVntJWHbchufCPH kMZgcLEpgNHaxWVntJWHbchufCPH2 = new kMZgcLEpgNHaxWVntJWHbchufCPH(-2);
				kMZgcLEpgNHaxWVntJWHbchufCPH2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return kMZgcLEpgNHaxWVntJWHbchufCPH2;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				ZKYgFCkGoKGBaTbUmdSbiAZlFPBs zKYgFCkGoKGBaTbUmdSbiAZlFPBs = new ZKYgFCkGoKGBaTbUmdSbiAZlFPBs(-2);
				while (true)
				{
					int num = 1508520311;
					while (true)
					{
						switch (num ^ 0x59EA3176)
						{
						case 0:
							break;
						case 1:
							goto IL_0026;
						default:
							return zKYgFCkGoKGBaTbUmdSbiAZlFPBs;
						}
						break;
						IL_0026:
						zKYgFCkGoKGBaTbUmdSbiAZlFPBs.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
						num = 1508520308;
					}
				}
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				int num2 = default(int);
				int elementIdentifier = default(int);
				while (true)
				{
					int num = 1138105110;
					while (true)
					{
						switch (num ^ 0x43D61B10)
						{
						case 0:
							break;
						case 7:
							array[num2] = identifiers[elementIdentifier].name;
							num = 1138105107;
							continue;
						case 8:
							Logger.LogError("Element identifier index is out of bounds!");
							num = 1138105106;
							continue;
						case 5:
							elementIdentifier = elements.axes[num2].elementIdentifier;
							if (elementIdentifier >= 0)
							{
								int num4;
								if (elementIdentifier < identifiers.Length)
								{
									num = 1138105111;
									num4 = num;
								}
								else
								{
									num = 1138105112;
									num4 = num;
								}
								continue;
							}
							goto case 8;
						case 6:
							num2 = 0;
							num = 1138105105;
							continue;
						case 3:
							num2++;
							num = 1138105105;
							continue;
						case 1:
						{
							int num3;
							if (num2 < array.Length)
							{
								num = 1138105109;
								num3 = num;
							}
							else
							{
								num = 1138105108;
								num3 = num;
							}
							continue;
						}
						case 2:
							num = 1138105107;
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
				if (identifiers.Length < buttonCount)
				{
					goto IL_0015;
				}
				string[] array = new string[buttonCount];
				int num = 0;
				int num2 = -1001388050;
				goto IL_001a;
				IL_001a:
				int num4 = default(int);
				while (true)
				{
					switch (num2 ^ -1001388049)
					{
					case 2:
						break;
					case 7:
						num++;
						num2 = -1001388050;
						continue;
					case 6:
						array[num] = identifiers[num4].name;
						num2 = -1001388056;
						continue;
					case 3:
					{
						int elementIdentifier = elements.buttons[num].elementIdentifier;
						num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						int num5;
						if (num4 < 0)
						{
							num2 = -1001388049;
							num5 = num2;
						}
						else
						{
							num2 = -1001388053;
							num5 = num2;
						}
						continue;
					}
					case 4:
					{
						int num6;
						if (num4 < identifiers.Length)
						{
							num2 = -1001388055;
							num6 = num2;
						}
						else
						{
							num2 = -1001388049;
							num6 = num2;
						}
						continue;
					}
					case 0:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = -1001388056;
						continue;
					case 1:
					{
						int num3;
						if (num >= array.Length)
						{
							num2 = -1001388057;
							num3 = num2;
						}
						else
						{
							num2 = -1001388052;
							num3 = num2;
						}
						continue;
					}
					case 5:
						Logger.LogError("You have too few element identifiers!");
						return new string[0];
					default:
						return array;
					}
					break;
				}
				goto IL_0015;
				IL_0015:
				num2 = -1001388054;
				goto IL_001a;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
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
								num = -399839772;
								num2 = num;
							}
							else
							{
								num = -399839769;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ -399839772)
								{
								case 2:
									num = -399839771;
									continue;
								case 1:
									break;
								case 0:
									return true;
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
				using (IEnumerator<Button> enumerator = IterateButtons().GetEnumerator())
				{
					Button current = default(Button);
					while (true)
					{
						IL_0050:
						int num2;
						int num3;
						if (!enumerator.MoveNext())
						{
							num2 = 2024183017;
							num3 = num2;
						}
						else
						{
							num2 = 2024183016;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x78A694EB)
							{
							case 0:
								num2 = 2024183016;
								continue;
							default:
								goto end_IL_002f;
							case 4:
								break;
							case 1:
								buttons[num] = current.elementIdentifier;
								num++;
								num2 = 2024183023;
								continue;
							case 3:
								current = enumerator.Current;
								num2 = 2024183018;
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
							int num4 = 2024183018;
							while (true)
							{
								switch (num4 ^ 0x78A694EB)
								{
								case 0:
									num4 = 2024183017;
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
				int num2 = default(int);
				AxisCalibrationData[] array = default(AxisCalibrationData[]);
				while (true)
				{
					int num = -1057315734;
					while (true)
					{
						switch (num ^ -1057315731)
						{
						case 14:
							break;
						case 10:
							if (axes_orig[num2].sourceType == HardwareElementSourceType.Button)
							{
								array[num2] = AxisCalibrationData.Default;
								num = -1057315739;
								continue;
							}
							goto case 0;
						case 3:
							num = -1057315744;
							continue;
						case 11:
							if (axes_orig[num2].sourceType != HardwareElementSourceType.Axis)
							{
								int num3;
								if (axes_orig[num2].sourceType == HardwareElementSourceType.Custom)
								{
									num = -1057315736;
									num3 = num;
								}
								else
								{
									num = -1057315737;
									num3 = num;
								}
								continue;
							}
							goto case 5;
						case 6:
						{
							int num5;
							if (Axes_orig[num2].calibrateAxis)
							{
								num = -1057315735;
								num5 = num;
							}
							else
							{
								num = -1057315739;
								num5 = num;
							}
							continue;
						}
						case 1:
							num2++;
							num = -1057315744;
							continue;
						case 12:
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							num = -1057315733;
							continue;
						case 8:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num = -1057315732;
							continue;
						case 13:
						{
							int num4;
							if (num2 < axes_orig.Length)
							{
								num = -1057315738;
								num4 = num;
							}
							else
							{
								num = -1057315729;
								num4 = num;
							}
							continue;
						}
						case 5:
							array[num2] = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							num = -1057315743;
							continue;
						case 0:
							throw new NotImplementedException();
						case 9:
							num = -1057315739;
							continue;
						case 4:
							array[num2].zero = axes_orig[num2].axisZero;
							array[num2].min = axes_orig[num2].axisMin;
							array[num2].max = axes_orig[num2].axisMax;
							num = -1057315740;
							continue;
						case 7:
							if (axes_orig == null)
							{
								return null;
							}
							array = new AxisCalibrationData[axes_orig.Length];
							num2 = 0;
							num = -1057315730;
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
				int num2 = default(int);
				while (true)
				{
					int num = -1407258336;
					while (true)
					{
						switch (num ^ -1407258335)
						{
						case 2:
							break;
						case 3:
							if (Axes_orig[num2].sourceType == HardwareElementSourceType.Button)
							{
								axisRanges[num2] = AxisRange.Full;
								num = -1407258327;
								continue;
							}
							goto case 6;
						case 6:
							throw new Exception();
						case 4:
							axisRanges = new AxisRange[Axes_orig.Length];
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = -1407258330;
							continue;
						case 10:
						{
							int num4;
							if (Axes_orig[num2].sourceType == HardwareElementSourceType.Custom)
							{
								num = -1407258328;
								num4 = num;
							}
							else
							{
								num = -1407258334;
								num4 = num;
							}
							continue;
						}
						case 0:
						{
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							int num3;
							if (Axes_orig[num2].sourceType == HardwareElementSourceType.Axis)
							{
								num = -1407258328;
								num3 = num;
							}
							else
							{
								num = -1407258325;
								num3 = num;
							}
							continue;
						}
						case 8:
							num2++;
							num = -1407258332;
							continue;
						case 1:
							axisInfos = null;
							if (Axes_orig == null)
							{
								return;
							}
							goto case 4;
						case 9:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -1407258327;
							continue;
						case 7:
							num = -1407258332;
							continue;
						default:
							if (num2 >= Axes_orig.Length)
							{
								return;
							}
							goto case 0;
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
					int num2 = -871215085;
					while (true)
					{
						switch (num2 ^ -871215086)
						{
						case 0:
							num2 = -871215088;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
						{
							int num3;
							if (num >= Buttons_orig.Length)
							{
								num2 = -871215082;
								num3 = num2;
							}
							else
							{
								num2 = -871215087;
								num3 = num2;
							}
							continue;
						}
						case 3:
							buttonInfos[num] = MiscTools.DeepClone(Buttons_orig[num].buttonInfo, true);
							num++;
							num2 = -871215085;
							continue;
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
				Platform_XInput_Base platform_XInput_Base = new Platform_XInput_Base();
				CopyVars(platform_XInput_Base);
				return platform_XInput_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				Platform_XInput_Base platform_XInput_Base = destination as Platform_XInput_Base;
				while (true)
				{
					int num = 464403635;
					while (true)
					{
						switch (num ^ 0x1BAE3CB0)
						{
						case 0:
							break;
						default:
							return;
						case 3:
							if (platform_XInput_Base != null)
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
						platform_XInput_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
						platform_XInput_Base.elements = MiscTools.DeepClone(elements);
						num = 464403633;
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
					goto IL_000d;
				}
				int num = default(int);
				int num2;
				if (base.hasVariants)
				{
					num = 0;
					num2 = -836913968;
					goto IL_0012;
				}
				goto IL_009f;
				IL_0012:
				while (true)
				{
					switch (num2 ^ -836913966)
					{
					case 0:
						break;
					case 3:
						return true;
					case 4:
						goto IL_0044;
					case 1:
						return true;
					case 2:
						goto IL_0080;
					default:
						goto IL_009f;
					}
					break;
					IL_0080:
					int num3;
					if (num >= variants.Length)
					{
						num2 = -836913961;
						num3 = num2;
					}
					else
					{
						num2 = -836913962;
						num3 = num2;
					}
					continue;
					IL_0044:
					int variantIndex2;
					if (variants[num] == null || !variants[num].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
					{
						num++;
						num2 = -836913968;
					}
					else
					{
						variantIndex = num;
						num2 = -836913967;
					}
				}
				goto IL_000d;
				IL_009f:
				return false;
				IL_000d:
				num2 = -836913965;
				goto IL_0012;
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
				while (true)
				{
					switch (-1369451516 ^ -1369451515)
					{
					case 0:
						continue;
					case 1:
						if (platform_XInput == null)
						{
							return;
						}
						break;
					}
					break;
				}
				platform_XInput.variants = MiscTools.DeepClone(variants);
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
						if (elementCount != null)
						{
							elementCount.hatCount = hatCount;
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
							num = -26764241;
							goto IL_000e;
						}
						return true;
						IL_0009:
						num = -26764242;
						goto IL_000e;
						IL_000e:
						switch (num ^ -26764241)
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
						if (productName != null)
						{
							goto IL_0012;
						}
						goto IL_003d;
						IL_004c:
						if (productId.Length > 0 && vendorId != null && vendorId.Length > 0)
						{
							return true;
						}
						goto IL_006c;
						IL_0012:
						int num = -316475962;
						goto IL_0017;
						IL_0017:
						switch (num ^ -316475964)
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
						if (productName.Length > 0)
						{
							return true;
						}
						goto IL_003d;
						IL_003d:
						if (productId != null)
						{
							num = -316475963;
							goto IL_0017;
						}
						goto IL_006c;
						IL_006c:
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
					bool flag = default(bool);
					int num = default(int);
					int num2;
					string text = default(string);
					if (strictMatch)
					{
						flag = false;
						num = 0;
						num2 = -1997465988;
					}
					else
					{
						text = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
						num2 = -1997465999;
					}
					goto IL_0029;
					IL_0029:
					string name = default(string);
					while (true)
					{
						switch (num2 ^ -1997465991)
						{
						case 4:
							break;
						case 2:
							return false;
						case 3:
							if (!ProductNameMatches(name))
							{
								num2 = -1997465985;
								continue;
							}
							goto IL_00b9;
						case 0:
							num++;
							num2 = -1997465988;
							continue;
						case 1:
							if (vendorId[num] == bridgedControllerHWInfo.hw_vendorId)
							{
								int num3;
								if (num < productId.Length)
								{
									num2 = -1997465986;
									num3 = num2;
								}
								else
								{
									num2 = -1997465991;
									num3 = num2;
								}
								continue;
							}
							goto case 0;
						case 6:
							return false;
						case 5:
							if (num < vendorId.Length)
							{
								goto case 1;
							}
							if (!flag)
							{
								return false;
							}
							if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
							{
								name = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
								num2 = -1997465990;
								continue;
							}
							goto IL_00b9;
						case 7:
							if (productId[num] == bridgedControllerHWInfo.hw_productId)
							{
								flag = true;
								num2 = -1997465991;
								continue;
							}
							goto case 0;
						default:
							{
								text = text.Trim();
								if (!ProductNameMatches(text))
								{
									return false;
								}
								return true;
							}
							IL_00b9:
							return true;
						}
						break;
					}
					goto IL_0024;
					IL_0024:
					num2 = -1997465989;
					goto IL_0029;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					if (alternateElementCounts != null && index >= 0)
					{
						while (true)
						{
							int num = 861109448;
							while (true)
							{
								switch (num ^ 0x33537CCA)
								{
								case 0:
									break;
								case 2:
									goto IL_002a;
								default:
									goto end_IL_000c;
								}
								break;
								IL_002a:
								if (index >= alternateElementCounts.Length)
								{
									num = 861109451;
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

				private bool ProductNameMatches(string name)
				{
					if (productName == null)
					{
						return false;
					}
					int num = 0;
					while (num < productName.Length)
					{
						while (true)
						{
							string text = ((productName[num] == null) ? string.Empty : productName[num]);
							text = text.Trim();
							int num2 = -962906112;
							while (true)
							{
								switch (num2 ^ -962906110)
								{
								case 3:
									num2 = -962906106;
									continue;
								case 0:
									return true;
								case 2:
									break;
								case 4:
									goto end_IL_0013;
								default:
									goto end_IL_0057;
								}
								if (!MatchingCriteria_Base.StringMatches(name, text, productName_useRegex))
								{
									num++;
									num2 = -962906109;
								}
								else
								{
									num2 = -962906110;
								}
								continue;
								end_IL_0013:
								break;
							}
							continue;
							end_IL_0057:
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
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						int num = 1915027151;
						while (true)
						{
							switch (num ^ 0x7224FECD)
							{
							case 3:
								num = 1915027148;
								continue;
							case 1:
								break;
							case 2:
								matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
								matchingCriteria.productId = ArrayTools.ShallowCopy(productId);
								num = 1915027149;
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
				private sealed class mPgZGHifaXaavksGSyOnTNjiSCx : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
				{
					private Axis aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public Elements iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public Axis WCoLvrkroJVgPebqyCaNfloiOmRb;

					public Axis[] OhnHvHXMvMCrecGQLaXhXZwugjF;

					public int LIHFHcWDShekWElDLCPIehsvEBR;

					Axis IEnumerator<Axis>.Current
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
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
						{
							goto IL_0012;
						}
						goto IL_0038;
						IL_0012:
						int num = -1715327058;
						goto IL_0017;
						IL_0017:
						mPgZGHifaXaavksGSyOnTNjiSCx mPgZGHifaXaavksGSyOnTNjiSCx2 = default(mPgZGHifaXaavksGSyOnTNjiSCx);
						while (true)
						{
							switch (num ^ -1715327057)
							{
							case 3:
								break;
							case 4:
								goto IL_0038;
							case 2:
								num = -1715327057;
								continue;
							case 1:
								if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
								{
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
									mPgZGHifaXaavksGSyOnTNjiSCx2 = this;
									num = -1715327059;
									continue;
								}
								goto IL_0038;
							default:
								return mPgZGHifaXaavksGSyOnTNjiSCx2;
							}
							break;
						}
						goto IL_0012;
						IL_0038:
						mPgZGHifaXaavksGSyOnTNjiSCx2 = new mPgZGHifaXaavksGSyOnTNjiSCx(0);
						mPgZGHifaXaavksGSyOnTNjiSCx2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = -1715327057;
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
							int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
							while (true)
							{
								int num2 = -1839113396;
								while (true)
								{
									switch (num2 ^ -1839113394)
									{
									case 5:
										break;
									case 3:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										return true;
									case 4:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
										if (iKQXbXnVtIaMZEJNeigQJWAHqUx.axes != null)
										{
											oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
											OhnHvHXMvMCrecGQLaXhXZwugjF = iKQXbXnVtIaMZEJNeigQJWAHqUx.axes;
											LIHFHcWDShekWElDLCPIehsvEBR = 0;
											num2 = -1839113393;
											continue;
										}
										goto IL_0115;
									case 2:
										switch (num)
										{
										case 0:
											break;
										default:
											goto IL_00a3;
										case 2:
											goto IL_00f6;
										case 1:
											goto IL_0115;
										}
										goto case 4;
									case 1:
										if (LIHFHcWDShekWElDLCPIehsvEBR >= OhnHvHXMvMCrecGQLaXhXZwugjF.Length)
										{
											RSVQsWlfdfgoTqAcCnNPnbJapFr();
											num2 = -1839113400;
											continue;
										}
										goto case 7;
									case 7:
										WCoLvrkroJVgPebqyCaNfloiOmRb = OhnHvHXMvMCrecGQLaXhXZwugjF[LIHFHcWDShekWElDLCPIehsvEBR];
										aimBzjfQfPyaeQqysAQJISCBhELB = WCoLvrkroJVgPebqyCaNfloiOmRb;
										num2 = -1839113395;
										continue;
									case 0:
										goto IL_00f6;
									default:
										goto IL_0115;
										IL_0115:
										return false;
										IL_00f6:
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
										LIHFHcWDShekWElDLCPIehsvEBR++;
										num2 = -1839113393;
										continue;
										IL_00a3:
										num2 = -1839113400;
										continue;
									}
									break;
								}
							}
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
						case 2:
							RSVQsWlfdfgoTqAcCnNPnbJapFr();
							break;
						}
					}

					[DebuggerHidden]
					public mPgZGHifaXaavksGSyOnTNjiSCx(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void RSVQsWlfdfgoTqAcCnNPnbJapFr()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					}
				}

				private sealed class WzoGciNWtjDozETDEPsQfUncPDNN : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
				{
					private Button aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public Elements iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public Button GCDLFqTPfAGDYoEYJzJTmiizffM;

					public Button[] RkJHcgudCkBOLATpumovRDgeKMZ;

					public int PzDvKIpaLPAwOfnYVhHsiPNWKon;

					Button IEnumerator<Button>.Current
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
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
						{
							goto IL_0012;
						}
						goto IL_0053;
						IL_0012:
						int num = 205006457;
						goto IL_0017;
						IL_0017:
						WzoGciNWtjDozETDEPsQfUncPDNN wzoGciNWtjDozETDEPsQfUncPDNN = default(WzoGciNWtjDozETDEPsQfUncPDNN);
						while (true)
						{
							switch (num ^ 0xC38267B)
							{
							case 4:
								break;
							case 2:
								goto IL_0038;
							case 0:
								goto IL_0053;
							case 1:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
								wzoGciNWtjDozETDEPsQfUncPDNN = this;
								num = 205006456;
								continue;
							default:
								return wzoGciNWtjDozETDEPsQfUncPDNN;
							}
							break;
							IL_0038:
							int num2;
							if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
							{
								num = 205006458;
								num2 = num;
							}
							else
							{
								num = 205006459;
								num2 = num;
							}
						}
						goto IL_0012;
						IL_0053:
						wzoGciNWtjDozETDEPsQfUncPDNN = new WzoGciNWtjDozETDEPsQfUncPDNN(0);
						wzoGciNWtjDozETDEPsQfUncPDNN.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = 205006456;
						goto IL_0017;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						bool result = default(bool);
						try
						{
							int num;
							switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
							{
							case 0:
								goto IL_00a9;
							case 2:
								goto IL_00ea;
								IL_00a9:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num = -1690068166;
								goto IL_0023;
								IL_0023:
								while (true)
								{
									switch (num ^ -1690068161)
									{
									case 4:
										num = -1690068163;
										continue;
									case 1:
										result = true;
										num = -1690068167;
										continue;
									case 6:
										break;
									case 5:
										if (iKQXbXnVtIaMZEJNeigQJWAHqUx.buttons != null)
										{
											oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
											RkJHcgudCkBOLATpumovRDgeKMZ = iKQXbXnVtIaMZEJNeigQJWAHqUx.buttons;
											PzDvKIpaLPAwOfnYVhHsiPNWKon = 0;
											num = -1690068161;
											continue;
										}
										goto end_IL_0008;
									case 2:
										goto IL_00a9;
									case 7:
										GCDLFqTPfAGDYoEYJzJTmiizffM = RkJHcgudCkBOLATpumovRDgeKMZ[PzDvKIpaLPAwOfnYVhHsiPNWKon];
										aimBzjfQfPyaeQqysAQJISCBhELB = GCDLFqTPfAGDYoEYJzJTmiizffM;
										oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
										num = -1690068162;
										continue;
									case 3:
										goto IL_00ea;
									case 0:
										num = -1690068170;
										continue;
									case 9:
										if (PzDvKIpaLPAwOfnYVhHsiPNWKon >= RkJHcgudCkBOLATpumovRDgeKMZ.Length)
										{
											FVtFjMSXqjHqDPRIrSOdVMTlCdrj();
											num = -1690068169;
											continue;
										}
										goto case 7;
									default:
										goto end_IL_0008;
									}
									break;
								}
								goto end_IL_0000;
								IL_00ea:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								PzDvKIpaLPAwOfnYVhHsiPNWKon++;
								num = -1690068170;
								goto IL_0023;
								end_IL_0008:
								break;
							}
							result = false;
							end_IL_0000:;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
						return result;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						default:
							return;
						case 1:
						case 2:
							break;
						}
						while (true)
						{
							FVtFjMSXqjHqDPRIrSOdVMTlCdrj();
							int num = -1668748192;
							while (true)
							{
								switch (num ^ -1668748190)
								{
								case 0:
									goto IL_0018;
								default:
									return;
								case 1:
									break;
								case 2:
									return;
								}
								break;
								IL_0018:
								num = -1668748189;
							}
						}
					}

					[DebuggerHidden]
					public WzoGciNWtjDozETDEPsQfUncPDNN(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}

					private void FVtFjMSXqjHqDPRIrSOdVMTlCdrj()
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
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
					mPgZGHifaXaavksGSyOnTNjiSCx mPgZGHifaXaavksGSyOnTNjiSCx2 = new mPgZGHifaXaavksGSyOnTNjiSCx(-2);
					mPgZGHifaXaavksGSyOnTNjiSCx2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return mPgZGHifaXaavksGSyOnTNjiSCx2;
				}

				public IEnumerable<Button> IterateButtons()
				{
					WzoGciNWtjDozETDEPsQfUncPDNN wzoGciNWtjDozETDEPsQfUncPDNN = new WzoGciNWtjDozETDEPsQfUncPDNN(-2);
					wzoGciNWtjDozETDEPsQfUncPDNN.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					return wzoGciNWtjDozETDEPsQfUncPDNN;
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
						int num = 924859831;
						while (true)
						{
							switch (num ^ 0x37203DB3)
							{
							case 3:
								break;
							case 4:
							{
								elements = destination as Elements;
								int num2;
								if (elements != null)
								{
									num = 924859827;
									num2 = num;
								}
								else
								{
									num = 924859825;
									num2 = num;
								}
								continue;
							}
							case 0:
								elements.axes = ArrayTools.DeepClone(axes);
								num = 924859826;
								continue;
							case 2:
								return;
							default:
								elements.buttons = ArrayTools.DeepClone(buttons);
								return;
							}
							break;
						}
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					int num = 0;
					int num4 = default(int);
					while (true)
					{
						int num2;
						int num3;
						if (num >= axisCount)
						{
							num2 = -922804531;
							num3 = num2;
						}
						else
						{
							num2 = -922804535;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -922804529)
							{
							case 5:
								num2 = -922804535;
								continue;
							case 4:
								if (buttons[num4].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num4++;
								num2 = -922804529;
								continue;
							case 1:
								break;
							case 2:
								num4 = 0;
								num2 = -922804529;
								continue;
							case 6:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = -922804530;
								continue;
							case 0:
							{
								int num5;
								if (num4 < buttonCount)
								{
									num2 = -922804533;
									num5 = num2;
								}
								else
								{
									num2 = -922804532;
									num5 = num2;
								}
								continue;
							}
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
					while (num < axisCount)
					{
						while (true)
						{
							IL_00d9:
							int num2;
							if (axes[num].elementIdentifier == elementIdentifier.id)
							{
								switch (axes[num].sourceType)
								{
								case HardwareElementSourceTypeWithHat.Button:
									axisRange = AxisRange.Positive;
									return true;
								case HardwareElementSourceTypeWithHat.Hat:
									break;
								case HardwareElementSourceTypeWithHat.Axis:
									goto IL_0086;
								case HardwareElementSourceTypeWithHat.Custom:
									goto IL_0113;
								default:
									throw new NotImplementedException();
								}
								axisRange = axes[num].sourceHatRange;
								int num3;
								if (axes[num].invert)
								{
									num2 = -1548181007;
									num3 = num2;
								}
								else
								{
									num2 = -1548181004;
									num3 = num2;
								}
								goto IL_000c;
							}
							goto IL_00cb;
							IL_0086:
							axisRange = axes[num].sourceAxisRange;
							int num4;
							if (!axes[num].invert)
							{
								num2 = -1548181001;
								num4 = num2;
							}
							else
							{
								num2 = -1548181002;
								num4 = num2;
							}
							goto IL_000c;
							IL_0113:
							num2 = -1548181005;
							goto IL_000c;
							IL_00cb:
							num++;
							num2 = -1548181006;
							goto IL_000c;
							IL_000c:
							while (true)
							{
								switch (num2 ^ -1548181005)
								{
								case 6:
									num2 = -1548180997;
									continue;
								case 2:
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -1548181004;
									continue;
								case 4:
									return true;
								case 0:
									break;
								case 5:
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -1548181001;
									continue;
								case 3:
									goto IL_00cb;
								case 8:
									goto IL_00d9;
								case 7:
									return true;
								default:
									goto end_IL_00d9;
								}
								break;
							}
							goto IL_0086;
							continue;
							end_IL_00d9:
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
						int num = 150647996;
						while (true)
						{
							switch (num ^ 0x8FAB4BE)
							{
							case 0:
								break;
							case 1:
								button.requiredButtons = ArrayTools.ShallowCopy(requiredButtons);
								button.ignoreIfButtonsActive = ignoreIfButtonsActive;
								button.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons);
								num = 150647997;
								continue;
							case 7:
								button.sourceType = sourceType;
								button.sourceButton = sourceButton;
								button.sourceStick = sourceStick;
								num = 150647995;
								continue;
							case 6:
								button.sourceHatDirection = sourceHatDirection;
								button.requireMultipleButtons = requireMultipleButtons;
								num = 150647999;
								continue;
							case 5:
								button.sourceAxis = sourceAxis;
								button.sourceOtherAxis = sourceOtherAxis;
								button.sourceAxisPole = sourceAxisPole;
								button.axisDeadZone = axisDeadZone;
								button.sourceHat = sourceHat;
								num = 150647994;
								continue;
							case 2:
								button.elementIdentifier = elementIdentifier;
								num = 150647993;
								continue;
							case 4:
								button.sourceHatType = sourceHatType;
								num = 150647992;
								continue;
							default:
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
					axis.elementIdentifier = elementIdentifier;
					axis.sourceType = sourceType;
					axis.sourceStick = sourceStick;
					axis.sourceAxis = sourceAxis;
					axis.sourceOtherAxis = sourceOtherAxis;
					axis.sourceAxisRange = sourceAxisRange;
					axis.invert = invert;
					axis.axisDeadZone = axisDeadZone;
					axis.calibrateAxis = calibrateAxis;
					while (true)
					{
						int num = 441926762;
						while (true)
						{
							switch (num ^ 0x1A574469)
							{
							case 0:
								break;
							case 1:
								axis.buttonAxisContribution = buttonAxisContribution;
								axis.sourceHat = sourceHat;
								axis.sourceHatDirection = sourceHatDirection;
								num = 441926765;
								continue;
							case 2:
								axis.axisMax = axisMax;
								axis.axisInfo = MiscTools.DeepClone(axisInfo);
								axis.sourceButton = sourceButton;
								num = 441926760;
								continue;
							case 3:
								axis.axisZero = axisZero;
								axis.axisMin = axisMin;
								num = 441926763;
								continue;
							default:
								axis.sourceHatRange = sourceHatRange;
								axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
								return axis;
							}
							break;
						}
					}
				}
			}

			private sealed class kObkzvVDGcPprdcIjJnnkfJiDaJ : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_OSX_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int YOLeqCqbbtegcmGjPOepDgKfbdW;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						goto IL_001c;
					}
					goto IL_0052;
					IL_0052:
					kObkzvVDGcPprdcIjJnnkfJiDaJ kObkzvVDGcPprdcIjJnnkfJiDaJ2 = new kObkzvVDGcPprdcIjJnnkfJiDaJ(0);
					int num = 89928447;
					goto IL_0021;
					IL_001c:
					num = 89928443;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ 0x55C32FF)
						{
						case 2:
							break;
						case 4:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							kObkzvVDGcPprdcIjJnnkfJiDaJ2 = this;
							num = 89928446;
							continue;
						case 3:
							goto IL_0052;
						case 0:
							kObkzvVDGcPprdcIjJnnkfJiDaJ2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
							num = 89928446;
							continue;
						default:
							return kObkzvVDGcPprdcIjJnnkfJiDaJ2;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 0:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = -2000979732;
						goto IL_001f;
					case 1:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							num = -2000979729;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -2000979734)
							{
							case 0:
								num = -2000979736;
								continue;
							case 2:
								break;
							case 4:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes[YOLeqCqbbtegcmGjPOepDgKfbdW];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = -2000979731;
								continue;
							case 5:
								YOLeqCqbbtegcmGjPOepDgKfbdW++;
								num = -2000979735;
								continue;
							case 3:
								goto IL_009d;
							case 6:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements != null && iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes != null)
								{
									YOLeqCqbbtegcmGjPOepDgKfbdW = 0;
									num = -2000979735;
									continue;
								}
								goto end_IL_0008;
							case 7:
								return true;
							default:
								goto end_IL_0008;
							}
							break;
							IL_009d:
							int num2;
							if (YOLeqCqbbtegcmGjPOepDgKfbdW >= iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes.Length)
							{
								num = -2000979733;
								num2 = num;
							}
							else
							{
								num = -2000979730;
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
				public kObkzvVDGcPprdcIjJnnkfJiDaJ(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class DlpVXsdkhdLhABAmsXsVpFtmjnn : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_OSX_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int axzJkALHZAFtzfyFBKhDqZQnTve;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						goto IL_001c;
					}
					goto IL_0046;
					IL_0046:
					DlpVXsdkhdLhABAmsXsVpFtmjnn dlpVXsdkhdLhABAmsXsVpFtmjnn = new DlpVXsdkhdLhABAmsXsVpFtmjnn(0);
					int num = -1233046679;
					goto IL_0021;
					IL_001c:
					num = -1233046673;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ -1233046676)
						{
						case 4:
							break;
						case 2:
							goto IL_0046;
						case 1:
							num = -1233046676;
							continue;
						case 5:
							dlpVXsdkhdLhABAmsXsVpFtmjnn.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
							num = -1233046676;
							continue;
						case 3:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							dlpVXsdkhdLhABAmsXsVpFtmjnn = this;
							num = -1233046675;
							continue;
						default:
							return dlpVXsdkhdLhABAmsXsVpFtmjnn;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 0:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = -711970534;
						goto IL_001f;
					case 1:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							axzJkALHZAFtzfyFBKhDqZQnTve++;
							num = -711970532;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -711970535)
							{
							case 0:
								num = -711970536;
								continue;
							case 1:
								break;
							case 3:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements != null && iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons != null)
								{
									axzJkALHZAFtzfyFBKhDqZQnTve = 0;
									num = -711970532;
									continue;
								}
								goto end_IL_0008;
							case 2:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons[axzJkALHZAFtzfyFBKhDqZQnTve];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 5:
								goto IL_00cd;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00cd:
							int num2;
							if (axzJkALHZAFtzfyFBKhDqZQnTve >= iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons.Length)
							{
								num = -711970531;
								num2 = num;
							}
							else
							{
								num = -711970533;
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
				public DlpVXsdkhdLhABAmsXsVpFtmjnn(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
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
					return InputPlatform.XnBBtfDGsHOaIaHObPJBJNGTMJOh;
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
						int num = 2141538133;
						while (true)
						{
							switch (num ^ 0x7FA54754)
							{
							case 2:
								break;
							case 1:
								goto IL_003c;
							default:
								return true;
							}
							break;
							IL_003c:
							platformMap = this;
							num = 2141538132;
						}
					}
				}
				return false;
			}

			internal IEnumerable<Axis> IterateAxes()
			{
				kObkzvVDGcPprdcIjJnnkfJiDaJ kObkzvVDGcPprdcIjJnnkfJiDaJ2 = new kObkzvVDGcPprdcIjJnnkfJiDaJ(-2);
				kObkzvVDGcPprdcIjJnnkfJiDaJ2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return kObkzvVDGcPprdcIjJnnkfJiDaJ2;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				DlpVXsdkhdLhABAmsXsVpFtmjnn dlpVXsdkhdLhABAmsXsVpFtmjnn = new DlpVXsdkhdLhABAmsXsVpFtmjnn(-2);
				dlpVXsdkhdLhABAmsXsVpFtmjnn.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return dlpVXsdkhdLhABAmsXsVpFtmjnn;
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
				using (IEnumerator<Axis> enumerator = elements.IterateAxes().GetEnumerator())
				{
					while (true)
					{
						IL_0084:
						int num;
						int num2;
						if (!enumerator.MoveNext())
						{
							num = -645571672;
							num2 = num;
						}
						else
						{
							num = -645571671;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -645571672)
							{
							case 2:
								num = -645571671;
								continue;
							default:
								goto end_IL_0051;
							case 1:
							{
								Axis current = enumerator.Current;
								list.Add(current);
								num = -645571669;
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
				int num3 = 0;
				int elementIdentifier = default(int);
				while (true)
				{
					int num4 = -645571665;
					while (true)
					{
						switch (num4 ^ -645571672)
						{
						case 4:
							break;
						case 0:
							num3++;
							num4 = -645571667;
							continue;
						case 8:
							num4 = -645571672;
							continue;
						case 2:
							array[num3] = identifiers[elementIdentifier].name;
							num4 = -645571672;
							continue;
						case 1:
							elementIdentifier = list[num3].elementIdentifier;
							if (elementIdentifier >= 0)
							{
								int num6;
								if (elementIdentifier < identifiers.Length)
								{
									num4 = -645571670;
									num6 = num4;
								}
								else
								{
									num4 = -645571666;
									num6 = num4;
								}
								continue;
							}
							goto case 6;
						case 5:
						{
							int num5;
							if (num3 < array.Length)
							{
								num4 = -645571671;
								num5 = num4;
							}
							else
							{
								num4 = -645571669;
								num5 = num4;
							}
							continue;
						}
						case 6:
							Logger.LogError("Element identifier index is out of bounds!");
							num4 = -645571680;
							continue;
						case 7:
							num4 = -645571667;
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
				if (identifiers.Length < buttonCount)
				{
					Logger.LogError("You have too few element identifiers!");
					goto IL_001c;
				}
				string[] array = new string[buttonCount];
				int num = 0;
				int num2 = -1102033687;
				goto IL_0021;
				IL_0021:
				int num3 = default(int);
				while (true)
				{
					switch (num2 ^ -1102033684)
					{
					case 3:
						break;
					case 1:
						return new string[0];
					case 2:
						num++;
						num2 = -1102033687;
						continue;
					case 4:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = -1102033682;
						continue;
					case 0:
					{
						int elementIdentifier = elements.buttons[num].elementIdentifier;
						num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						if (num3 >= 0)
						{
							int num4;
							if (num3 < identifiers.Length)
							{
								num2 = -1102033686;
								num4 = num2;
							}
							else
							{
								num2 = -1102033688;
								num4 = num2;
							}
							continue;
						}
						goto case 4;
					}
					case 6:
						array[num] = identifiers[num3].name;
						num2 = -1102033682;
						continue;
					default:
						if (num >= buttonCount)
						{
							return array;
						}
						goto case 0;
					}
					break;
				}
				goto IL_001c;
				IL_001c:
				num2 = -1102033683;
				goto IL_0021;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				using (IEnumerator<Axis> enumerator = IterateAxes().GetEnumerator())
				{
					Axis current = default(Axis);
					while (true)
					{
						IL_0042:
						int num;
						int num2;
						if (!enumerator.MoveNext())
						{
							num = -886873451;
							num2 = num;
						}
						else
						{
							num = -886873449;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -886873452)
							{
							case 2:
								num = -886873449;
								continue;
							default:
								goto end_IL_0013;
							case 3:
								current = enumerator.Current;
								num = -886873452;
								continue;
							case 4:
								break;
							case 0:
								if (current.elementIdentifier == elementIdentifierId)
								{
									return true;
								}
								break;
							case 1:
								goto end_IL_0013;
							}
							goto IL_0042;
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
							int num3 = -886873450;
							while (true)
							{
								switch (num3 ^ -886873452)
								{
								case 4:
									num3 = -886873449;
									continue;
								case 3:
									break;
								case 1:
									return true;
								case 2:
									goto IL_00cd;
								default:
									goto end_IL_00b3;
								}
								break;
								IL_00cd:
								int num4;
								if (current2.elementIdentifier != elementIdentifierId)
								{
									num3 = -886873452;
									num4 = num3;
								}
								else
								{
									num3 = -886873451;
									num4 = num3;
								}
							}
							continue;
							end_IL_00b3:
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
						IL_0068:
						int num2;
						int num3;
						if (enumerator.MoveNext())
						{
							num2 = 619243669;
							num3 = num2;
						}
						else
						{
							num2 = 619243670;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x24E8E894)
							{
							case 0:
								num2 = 619243669;
								continue;
							default:
								goto end_IL_002f;
							case 1:
							{
								Button current = enumerator.Current;
								buttons[num] = current.elementIdentifier;
								num++;
								num2 = 619243671;
								continue;
							}
							case 3:
								break;
							case 2:
								goto end_IL_002f;
							}
							goto IL_0068;
							continue;
							end_IL_002f:
							break;
						}
						break;
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
							int num4 = 619243664;
							while (true)
							{
								switch (num4 ^ 0x24E8E894)
								{
								case 0:
									num4 = 619243671;
									continue;
								case 3:
									break;
								case 1:
									num++;
									num4 = 619243670;
									continue;
								case 4:
									axes[num] = current2.elementIdentifier;
									num4 = 619243669;
									continue;
								default:
									goto end_IL_00c4;
								}
								break;
							}
							continue;
							end_IL_00c4:
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
							IL_00fe:
							int num5 = 619243670;
							while (true)
							{
								switch (num5 ^ 0x24E8E894)
								{
								case 0:
									break;
								default:
									goto end_IL_0103;
								case 2:
									goto IL_011c;
								case 1:
									goto end_IL_0103;
								}
								goto IL_00fe;
								IL_011c:
								enumerator2.Dispose();
								num5 = 619243669;
								continue;
								end_IL_0103:
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
					int num = -1019875771;
					while (true)
					{
						switch (num ^ -1019875772)
						{
						case 6:
							break;
						case 3:
						{
							int num4;
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								num = -1019875775;
								num4 = num;
							}
							else
							{
								num = -1019875762;
								num4 = num;
							}
							continue;
						}
						case 4:
							throw new NotImplementedException();
						case 0:
							array[num2] = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							num = -1019875773;
							continue;
						case 1:
							num2 = 0;
							num = -1019875770;
							continue;
						case 7:
							if (Axes_orig[num2].calibrateAxis)
							{
								array[num2].zero = axes_orig[num2].axisZero;
								array[num2].min = axes_orig[num2].axisMin;
								array[num2].max = axes_orig[num2].axisMax;
								num = -1019875764;
								continue;
							}
							goto case 8;
						case 9:
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num5;
								if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									num = -1019875769;
									num5 = num;
								}
								else
								{
									num = -1019875772;
									num5 = num;
								}
								continue;
							}
							goto case 0;
						case 5:
						{
							int num3;
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Hat)
							{
								num = -1019875776;
								num3 = num;
							}
							else
							{
								num = -1019875762;
								num3 = num;
							}
							continue;
						}
						case 8:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num2++;
							num = -1019875770;
							continue;
						case 10:
							array[num2] = AxisCalibrationData.Default;
							num = -1019875764;
							continue;
						default:
							if (num2 >= axes_orig.Length)
							{
								return array;
							}
							goto case 9;
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
					int num = 496920516;
					while (true)
					{
						switch (num ^ 0x1D9E67CD)
						{
						case 10:
							num = 496920527;
							continue;
						case 2:
							break;
						case 9:
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = 496920520;
							continue;
						case 6:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							num = 496920524;
							continue;
						case 4:
						{
							int num4;
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Custom)
							{
								num = 496920518;
								num4 = num;
							}
							else
							{
								num = 496920525;
								num4 = num;
							}
							continue;
						}
						case 3:
							num2++;
							num = 496920520;
							continue;
						case 0:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = 496920526;
							continue;
						case 1:
						{
							int num5;
							if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Axis)
							{
								num = 496920525;
								num5 = num;
							}
							else
							{
								num = 496920521;
								num5 = num;
							}
							continue;
						}
						case 11:
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num3;
								if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Hat)
								{
									num = 496920517;
									num3 = num;
								}
								else
								{
									num = 496920522;
									num3 = num;
								}
								continue;
							}
							goto case 7;
						case 8:
							throw new Exception();
						case 7:
							axisRanges[num2] = AxisRange.Full;
							num = 496920526;
							continue;
						default:
							if (num2 >= Axes_orig.Length)
							{
								return;
							}
							goto case 6;
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
					int num = -1521607667;
					while (true)
					{
						switch (num ^ -1521607666)
						{
						case 0:
							num = -1521607665;
							continue;
						case 1:
							break;
						case 3:
							num2 = 0;
							num = -1521607670;
							continue;
						case 2:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
							num2++;
							num = -1521607670;
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
					while (true)
					{
						switch (-1190290915 ^ -1190290913)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				platform_OSX_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				platform_OSX_Base.elements = MiscTools.DeepClone(elements);
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
							num2 = 1142016257;
							num3 = num2;
						}
						else
						{
							num2 = 1142016258;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x4411C903)
							{
							case 3:
								num2 = 1142016258;
								continue;
							case 0:
								break;
							case 4:
								return true;
							case 1:
								goto IL_006a;
							default:
								goto end_IL_0041;
							}
							break;
							IL_006a:
							int variantIndex2;
							if (variants[num] == null || !variants[num].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
							{
								num++;
								num2 = 1142016259;
							}
							else
							{
								variantIndex = num;
								num2 = 1142016263;
							}
						}
						continue;
						end_IL_0041:
						break;
					}
				}
				return false;
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
				while (true)
				{
					switch (-1765446981 ^ -1765446983)
					{
					case 0:
						continue;
					case 2:
						if (platform_OSX == null)
						{
							return;
						}
						break;
					}
					break;
				}
				platform_OSX.variants = MiscTools.DeepClone(variants);
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
						CopyVars(elementCount);
						return elementCount;
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
							while (true)
							{
								int num = -910730300;
								while (true)
								{
									switch (num ^ -910730299)
									{
									case 2:
										break;
									case 1:
										goto IL_0030;
									default:
										return true;
									}
									break;
									IL_0030:
									if (productGUID.Length <= 0)
									{
										goto end_IL_0012;
									}
									num = -910730299;
								}
								continue;
								end_IL_0012:
								break;
							}
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
						goto IL_0018;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					int num;
					if (strictMatch)
					{
						num = -1261359981;
						goto IL_001d;
					}
					return AnyNameMatches(bridgedControllerHWInfo);
					IL_0018:
					num = -1261359982;
					goto IL_001d;
					IL_001d:
					while (true)
					{
						switch (num ^ -1261359984)
						{
						case 5:
							break;
						case 1:
							if (productName.Length == 0)
							{
								num = -1261359984;
								continue;
							}
							goto IL_0055;
						case 0:
							return true;
						case 2:
							return true;
						case 3:
							if (PidVid.ArrayContains(productGUID, ref bridgedControllerHWInfo.hw_pidVid))
							{
								if (!ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
								{
									return true;
								}
								int num2;
								if (productName == null)
								{
									num = -1261359984;
									num2 = num;
								}
								else
								{
									num = -1261359983;
									num2 = num;
								}
								continue;
							}
							goto IL_0055;
						default:
							{
								return false;
							}
							IL_0055:
							if (!AnyNameMatches(bridgedControllerHWInfo))
							{
								num = -1261359980;
								continue;
							}
							return true;
						}
						break;
					}
					goto IL_0018;
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
						num2 = 1223363282;
						goto IL_0010;
					}
					goto IL_005b;
					IL_0010:
					while (true)
					{
						switch (num2 ^ 0x48EB0AD1)
						{
						case 4:
							break;
						case 1:
							goto IL_0031;
						case 3:
							num2 = 1223363281;
							continue;
						case 2:
							goto IL_005b;
						default:
							if (num >= names.Length)
							{
								return false;
							}
							goto IL_0031;
						}
						break;
						IL_0031:
						if (!string.IsNullOrEmpty(names[num]) && MatchingCriteria_Base.StringMatches(searchIn, names[num], useRegex))
						{
							return true;
						}
						num++;
						num2 = 1223363281;
					}
					goto IL_000b;
					IL_005b:
					return false;
					IL_000b:
					num2 = 1223363283;
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
						int num = 351452197;
						while (true)
						{
							switch (num ^ 0x14F2BC27)
							{
							case 3:
								break;
							default:
								return;
							case 2:
								matchingCriteria = destination as MatchingCriteria;
								if (matchingCriteria == null)
								{
									return;
								}
								goto case 1;
							case 0:
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								matchingCriteria.systemName = ArrayTools.ShallowCopy(systemName);
								matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
								num = 351452195;
								continue;
							case 1:
								matchingCriteria.hatCount = hatCount;
								num = 351452194;
								continue;
							case 5:
								matchingCriteria.manufacturer_useRegex = manufacturer_useRegex;
								matchingCriteria.productName_useRegex = productName_useRegex;
								matchingCriteria.systemName_useRegex = systemName_useRegex;
								matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
								num = 351452199;
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
			public sealed class Elements : Elements_Base
			{
				private sealed class XiQNyrYNSsIrWhcDPCDCkGLUOXWd : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
				{
					private Axis aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public Elements iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public int nyJqTkZBDERgQPkkARAeRGUHkMO;

					Axis IEnumerator<Axis>.Current
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
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							goto IL_0023;
						}
						goto IL_004e;
						IL_0028:
						int num;
						XiQNyrYNSsIrWhcDPCDCkGLUOXWd xiQNyrYNSsIrWhcDPCDCkGLUOXWd = default(XiQNyrYNSsIrWhcDPCDCkGLUOXWd);
						while (true)
						{
							switch (num ^ 0x188151FF)
							{
							case 0:
								break;
							case 1:
								xiQNyrYNSsIrWhcDPCDCkGLUOXWd = this;
								num = 411128317;
								continue;
							case 3:
								goto IL_004e;
							default:
								return xiQNyrYNSsIrWhcDPCDCkGLUOXWd;
							}
							break;
						}
						goto IL_0023;
						IL_004e:
						xiQNyrYNSsIrWhcDPCDCkGLUOXWd = new XiQNyrYNSsIrWhcDPCDCkGLUOXWd(0);
						xiQNyrYNSsIrWhcDPCDCkGLUOXWd.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = 411128317;
						goto IL_0028;
						IL_0023:
						num = 411128318;
						goto IL_0028;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int num;
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							num = 248369595;
							goto IL_001f;
						case 0:
							{
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num = 248369593;
								goto IL_001f;
							}
							IL_001f:
							while (true)
							{
								switch (num ^ 0xECDD1BF)
								{
								case 0:
									num = 248369597;
									continue;
								case 1:
									return true;
								case 3:
									aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.axes[nyJqTkZBDERgQPkkARAeRGUHkMO];
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
									num = 248369598;
									continue;
								case 6:
									if (iKQXbXnVtIaMZEJNeigQJWAHqUx.axes != null)
									{
										nyJqTkZBDERgQPkkARAeRGUHkMO = 0;
										num = 248369594;
										continue;
									}
									goto end_IL_0008;
								case 5:
									break;
								case 4:
									nyJqTkZBDERgQPkkARAeRGUHkMO++;
									num = 248369594;
									continue;
								case 2:
									goto end_IL_001f;
								default:
									goto end_IL_0008;
								}
								int num2;
								if (nyJqTkZBDERgQPkkARAeRGUHkMO >= iKQXbXnVtIaMZEJNeigQJWAHqUx.axes.Length)
								{
									num = 248369592;
									num2 = num;
								}
								else
								{
									num = 248369596;
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
					public XiQNyrYNSsIrWhcDPCDCkGLUOXWd(int _003C_003E1__state)
					{
						while (true)
						{
							int num = -1823299683;
							while (true)
							{
								switch (num ^ -1823299684)
								{
								case 3:
									break;
								default:
									return;
								case 1:
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
									num = -1823299682;
									continue;
								case 2:
									HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
									num = -1823299684;
									continue;
								case 0:
									return;
								}
								break;
							}
						}
					}
				}

				private sealed class zHCwoGHDEznHJAsGisUWcnFVHgN : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
				{
					private Button aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public Elements iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public int VHNLBTKTZkkqOWFfBBCKFiSnwpV;

					Button IEnumerator<Button>.Current
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
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						zHCwoGHDEznHJAsGisUWcnFVHgN zHCwoGHDEznHJAsGisUWcnFVHgN2;
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							zHCwoGHDEznHJAsGisUWcnFVHgN2 = this;
							goto IL_0025;
						}
						goto IL_005e;
						IL_002a:
						int num;
						while (true)
						{
							switch (num ^ 0x3447AF1F)
							{
							case 2:
								break;
							case 1:
								zHCwoGHDEznHJAsGisUWcnFVHgN2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								num = 877113116;
								continue;
							case 0:
								goto IL_005e;
							case 4:
								num = 877113116;
								continue;
							default:
								return zHCwoGHDEznHJAsGisUWcnFVHgN2;
							}
							break;
						}
						goto IL_0025;
						IL_005e:
						zHCwoGHDEznHJAsGisUWcnFVHgN2 = new zHCwoGHDEznHJAsGisUWcnFVHgN(0);
						num = 877113118;
						goto IL_002a;
						IL_0025:
						num = 877113115;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							num = 833226594;
							goto IL_001f;
						case 0:
							{
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num = 833226592;
								goto IL_001f;
							}
							IL_001f:
							while (true)
							{
								switch (num ^ 0x31AA0765)
								{
								case 2:
									num = 833226593;
									continue;
								case 3:
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
									return true;
								case 7:
									VHNLBTKTZkkqOWFfBBCKFiSnwpV++;
									num = 833226595;
									continue;
								case 8:
									VHNLBTKTZkkqOWFfBBCKFiSnwpV = 0;
									num = 833226595;
									continue;
								case 1:
									aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.buttons[VHNLBTKTZkkqOWFfBBCKFiSnwpV];
									num = 833226598;
									continue;
								case 4:
									break;
								case 5:
									goto IL_00c0;
								case 6:
									goto IL_00e1;
								default:
									goto end_IL_0008;
								}
								break;
								IL_00e1:
								int num2;
								if (VHNLBTKTZkkqOWFfBBCKFiSnwpV >= iKQXbXnVtIaMZEJNeigQJWAHqUx.buttons.Length)
								{
									num = 833226597;
									num2 = num;
								}
								else
								{
									num = 833226596;
									num2 = num;
								}
								continue;
								IL_00c0:
								int num3;
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.buttons != null)
								{
									num = 833226605;
									num3 = num;
								}
								else
								{
									num = 833226597;
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
					public zHCwoGHDEznHJAsGisUWcnFVHgN(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
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
						XiQNyrYNSsIrWhcDPCDCkGLUOXWd xiQNyrYNSsIrWhcDPCDCkGLUOXWd = new XiQNyrYNSsIrWhcDPCDCkGLUOXWd(-2);
						xiQNyrYNSsIrWhcDPCDCkGLUOXWd.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
						return xiQNyrYNSsIrWhcDPCDCkGLUOXWd;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					get
					{
						zHCwoGHDEznHJAsGisUWcnFVHgN zHCwoGHDEznHJAsGisUWcnFVHgN2 = new zHCwoGHDEznHJAsGisUWcnFVHgN(-2);
						zHCwoGHDEznHJAsGisUWcnFVHgN2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
						return zHCwoGHDEznHJAsGisUWcnFVHgN2;
					}
				}

				internal Axis GetAxis(int axisIndex)
				{
					if (axes != null && axisIndex >= 0)
					{
						while (true)
						{
							int num = 1865094388;
							while (true)
							{
								switch (num ^ 0x6F2B14F5)
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
								if (axisIndex >= axes.Length)
								{
									num = 1865094391;
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
					int num2 = default(int);
					while (true)
					{
						IL_006e:
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = -119796475;
							goto IL_0009;
						}
						goto IL_002a;
						IL_0009:
						while (true)
						{
							switch (num3 ^ -119796476)
							{
							case 3:
								num3 = -119796480;
								continue;
							case 4:
								break;
							case 2:
								goto IL_004c;
							case 0:
								goto IL_006e;
							default:
								if (num2 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								goto IL_004c;
							}
							break;
							IL_004c:
							if (buttons[num2].elementIdentifier == elementIdentifier.id)
							{
								return ControllerElementType.Button;
							}
							num2++;
							num3 = -119796475;
						}
						goto IL_002a;
						IL_002a:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							break;
						}
						num++;
						num3 = -119796476;
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
							int num3;
							if (axes[num].elementIdentifier != elementIdentifier.id)
							{
								num2 = -255622116;
								num3 = num2;
							}
							else
							{
								num2 = -255622128;
								num3 = num2;
							}
							while (true)
							{
								switch (num2 ^ -255622123)
								{
								case 7:
									num2 = -255622113;
									continue;
								case 10:
									break;
								case 0:
									goto IL_006e;
								case 6:
									goto IL_009f;
								case 2:
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -255622122;
									continue;
								case 8:
									goto IL_00d2;
								case 4:
									goto IL_00f5;
								case 9:
									num++;
									num2 = -255622124;
									continue;
								case 3:
									return true;
								case 5:
									sourceType = axes[num].sourceType;
									num2 = -255622127;
									continue;
								default:
									goto end_IL_0048;
								}
								break;
								IL_00f5:
								switch (sourceType)
								{
								case HardwareElementSourceTypeWithHat.Axis:
									break;
								case HardwareElementSourceTypeWithHat.Button:
									axisRange = AxisRange.Positive;
									return true;
								case HardwareElementSourceTypeWithHat.Hat:
									axisRange = axes[num].sourceHatRange;
									num2 = -255622115;
									continue;
								case HardwareElementSourceTypeWithHat.Custom:
									num2 = -255622123;
									continue;
								default:
									throw new NotImplementedException();
								}
								goto IL_006e;
								IL_00d2:
								int num4;
								if (!axes[num].invert)
								{
									num2 = -255622122;
									num4 = num2;
								}
								else
								{
									num2 = -255622121;
									num4 = num2;
								}
								continue;
								IL_006e:
								axisRange = axes[num].sourceAxisRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -255622125;
									continue;
								}
								goto IL_009f;
								IL_009f:
								return true;
							}
							continue;
							end_IL_0048:
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
						goto IL_0011;
					}
					goto IL_003b;
					IL_0011:
					int num = -283611660;
					goto IL_0016;
					IL_0016:
					switch (num ^ -283611659)
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
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
					num = -283611657;
					goto IL_0016;
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
					while (true)
					{
						int num = -622418424;
						while (true)
						{
							switch (num ^ -622418423)
							{
							case 2:
								break;
							default:
								return;
							case 1:
								goto IL_0024;
							case 0:
								return;
							}
							break;
							IL_0024:
							sourceType = HardwareElementSourceTypeWithHat.Button;
							num = -622418423;
						}
					}
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
					Button button = default(Button);
					while (true)
					{
						int num = -1391508183;
						while (true)
						{
							switch (num ^ -1391508184)
							{
							case 5:
								break;
							case 3:
								sourceButton = button.sourceButton;
								sourceAxis = button.sourceAxis;
								num = -1391508182;
								continue;
							case 4:
								if (button == null)
								{
									return;
								}
								goto case 0;
							case 1:
								button = source as Button;
								num = -1391508180;
								continue;
							case 0:
								elementIdentifier = button.elementIdentifier;
								sourceType = button.sourceType;
								num = -1391508181;
								continue;
							default:
								sourceAxisPole = button.sourceAxisPole;
								axisDeadZone = button.axisDeadZone;
								sourceHat = button.sourceHat;
								sourceHatType = button.sourceHatType;
								sourceHatDirection = button.sourceHatDirection;
								requireMultipleButtons = button.requireMultipleButtons;
								requiredButtons = ArrayTools.ShallowCopy(button.requiredButtons);
								ignoreIfButtonsActive = button.ignoreIfButtonsActive;
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
					Axis axis = source as Axis;
					while (true)
					{
						int num = -1495782952;
						while (true)
						{
							switch (num ^ -1495782951)
							{
							case 3:
								break;
							case 1:
								if (axis == null)
								{
									return;
								}
								goto case 4;
							case 6:
								sourceType = axis.sourceType;
								num = -1495782951;
								continue;
							case 0:
								sourceAxis = axis.sourceAxis;
								sourceAxisRange = axis.sourceAxisRange;
								invert = axis.invert;
								num = -1495782948;
								continue;
							case 4:
								elementIdentifier = axis.elementIdentifier;
								num = -1495782945;
								continue;
							case 5:
								axisDeadZone = axis.axisDeadZone;
								calibrateAxis = axis.calibrateAxis;
								num = -1495782949;
								continue;
							default:
								axisZero = axis.axisZero;
								axisMin = axis.axisMin;
								axisMax = axis.axisMax;
								axisInfo = MiscTools.DeepClone(axis.axisInfo);
								sourceButton = axis.sourceButton;
								buttonAxisContribution = axis.buttonAxisContribution;
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

			private sealed class BvMbAjILhRqdJoEekSYqYvxPfcR : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_Linux_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int FEzlLOzVTYInCCwfKehilUsQyNc;

				public int TVPcjRDSxvuNqsvpHuxQmpdBcEo;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
					{
						goto IL_0012;
					}
					goto IL_0044;
					IL_0012:
					int num = 196858320;
					goto IL_0017;
					IL_0017:
					BvMbAjILhRqdJoEekSYqYvxPfcR bvMbAjILhRqdJoEekSYqYvxPfcR = default(BvMbAjILhRqdJoEekSYqYvxPfcR);
					while (true)
					{
						switch (num ^ 0xBBBD1D6)
						{
						case 3:
							break;
						case 5:
							goto IL_0044;
						case 7:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							num = 196858322;
							continue;
						case 2:
							num = 196858326;
							continue;
						case 4:
							bvMbAjILhRqdJoEekSYqYvxPfcR = this;
							num = 196858324;
							continue;
						case 1:
							bvMbAjILhRqdJoEekSYqYvxPfcR.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
							num = 196858326;
							continue;
						case 6:
							goto IL_0083;
						default:
							return bvMbAjILhRqdJoEekSYqYvxPfcR;
						}
						break;
						IL_0083:
						int num2;
						if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg != -2)
						{
							num = 196858323;
							num2 = num;
						}
						else
						{
							num = 196858321;
							num2 = num;
						}
					}
					goto IL_0012;
					IL_0044:
					bvMbAjILhRqdJoEekSYqYvxPfcR = new BvMbAjILhRqdJoEekSYqYvxPfcR(0);
					num = 196858327;
					goto IL_0017;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
					while (true)
					{
						int num2 = -270413158;
						while (true)
						{
							switch (num2 ^ -270413159)
							{
							case 4:
								break;
							case 2:
								return true;
							case 6:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements != null && iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes != null)
								{
									FEzlLOzVTYInCCwfKehilUsQyNc = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes.Length;
									TVPcjRDSxvuNqsvpHuxQmpdBcEo = 0;
									num2 = -270413160;
									continue;
								}
								goto default;
							case 1:
							{
								int num3;
								if (TVPcjRDSxvuNqsvpHuxQmpdBcEo >= FEzlLOzVTYInCCwfKehilUsQyNc)
								{
									num2 = -270413159;
									num3 = num2;
								}
								else
								{
									num2 = -270413156;
									num3 = num2;
								}
								continue;
							}
							case 5:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes[TVPcjRDSxvuNqsvpHuxQmpdBcEo];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num2 = -270413157;
								continue;
							case 3:
								switch (num)
								{
								case 1:
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
									TVPcjRDSxvuNqsvpHuxQmpdBcEo++;
									num2 = -270413160;
									continue;
								case 0:
									break;
								default:
									num2 = -270413159;
									continue;
								}
								goto case 6;
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
				public BvMbAjILhRqdJoEekSYqYvxPfcR(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class sgwIMxuOJuPCJQTQxFIegMXdFMqg : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_Linux_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int yCtwsaUbIWxWmsvfrWeUvzfxgUv;

				public int yVvBTIjZnnsnmTGlcbEAMPZyNRg;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					sgwIMxuOJuPCJQTQxFIegMXdFMqg sgwIMxuOJuPCJQTQxFIegMXdFMqg2;
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						sgwIMxuOJuPCJQTQxFIegMXdFMqg2 = this;
					}
					else
					{
						while (true)
						{
							sgwIMxuOJuPCJQTQxFIegMXdFMqg2 = new sgwIMxuOJuPCJQTQxFIegMXdFMqg(0);
							int num = 961501741;
							while (true)
							{
								switch (num ^ 0x394F5A2D)
								{
								case 3:
									num = 961501740;
									continue;
								case 1:
									break;
								case 0:
									sgwIMxuOJuPCJQTQxFIegMXdFMqg2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
									num = 961501743;
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
					return sgwIMxuOJuPCJQTQxFIegMXdFMqg2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 1:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = 1662805926;
						goto IL_001f;
					case 0:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements == null)
							{
								break;
							}
							int num3;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons == null)
							{
								num = 1662805920;
								num3 = num;
							}
							else
							{
								num = 1662805925;
								num3 = num;
							}
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x631C67A5)
							{
							case 4:
								num = 1662805924;
								continue;
							case 6:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons[yVvBTIjZnnsnmTGlcbEAMPZyNRg];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 7:
								break;
							case 1:
								goto end_IL_001f;
							case 3:
								yVvBTIjZnnsnmTGlcbEAMPZyNRg++;
								num = 1662805922;
								continue;
							case 2:
								yVvBTIjZnnsnmTGlcbEAMPZyNRg = 0;
								num = 1662805922;
								continue;
							case 0:
								yCtwsaUbIWxWmsvfrWeUvzfxgUv = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons.Length;
								num = 1662805927;
								continue;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (yVvBTIjZnnsnmTGlcbEAMPZyNRg >= yCtwsaUbIWxWmsvfrWeUvzfxgUv)
							{
								num = 1662805920;
								num2 = num;
							}
							else
							{
								num = 1662805923;
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
				public sgwIMxuOJuPCJQTQxFIegMXdFMqg(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.JTFQFctybCbrhbHanPIAsCqFHew;
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
				if (num < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				int num2 = array.Length;
				int num3 = 0;
				int num5 = default(int);
				int elementIdentifier = default(int);
				while (true)
				{
					int num4 = -119983023;
					while (true)
					{
						switch (num4 ^ -119983024)
						{
						case 2:
							break;
						case 5:
							num3++;
							num4 = -119983018;
							continue;
						case 0:
						{
							num5 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							int num7;
							if (num5 >= 0)
							{
								num4 = -119983020;
								num7 = num4;
							}
							else
							{
								num4 = -119983017;
								num7 = num4;
							}
							continue;
						}
						case 7:
							Logger.LogError("Element identifier index is out of bounds!");
							num4 = -119983019;
							continue;
						case 1:
							num4 = -119983018;
							continue;
						case 8:
							elementIdentifier = elements.axes[num3].elementIdentifier;
							num4 = -119983024;
							continue;
						case 3:
							array[num3] = identifiers[num5].name;
							num4 = -119983019;
							continue;
						case 4:
						{
							int num6;
							if (num5 >= num)
							{
								num4 = -119983017;
								num6 = num4;
							}
							else
							{
								num4 = -119983021;
								num6 = num4;
							}
							continue;
						}
						default:
							if (num3 >= num2)
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
				int num = identifiers.Length;
				int num3 = default(int);
				string[] array = default(string[]);
				int num5 = default(int);
				while (true)
				{
					int num2 = 1342559225;
					while (true)
					{
						switch (num2 ^ 0x5005D3FF)
						{
						case 5:
							break;
						case 1:
						{
							int num4;
							if (num3 < buttonCount)
							{
								num2 = 1342559229;
								num4 = num2;
							}
							else
							{
								num2 = 1342559227;
								num4 = num2;
							}
							continue;
						}
						case 3:
							array[num3] = identifiers[num5].name;
							num2 = 1342559231;
							continue;
						case 0:
							num3++;
							num2 = 1342559230;
							continue;
						case 2:
						{
							int elementIdentifier = elements.buttons[num3].elementIdentifier;
							num5 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							if (num5 >= 0)
							{
								int num6;
								if (num5 < num)
								{
									num2 = 1342559228;
									num6 = num2;
								}
								else
								{
									num2 = 1342559224;
									num6 = num2;
								}
								continue;
							}
							goto case 7;
						}
						case 6:
							if (num < buttonCount)
							{
								Logger.LogError("You have too few element identifiers!");
								return new string[0];
							}
							array = new string[buttonCount];
							num3 = 0;
							num2 = 1342559230;
							continue;
						case 7:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = 1342559231;
							continue;
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
					while (true)
					{
						IL_0065:
						int num;
						int num2;
						if (enumerator.MoveNext())
						{
							num = 761116747;
							num2 = num;
						}
						else
						{
							num = 761116750;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x2D5DB84F)
							{
							case 0:
								num = 761116747;
								continue;
							default:
								goto end_IL_0013;
							case 4:
							{
								Axis current = enumerator.Current;
								int num3;
								if (current.elementIdentifier != elementIdentifierId)
								{
									num = 761116748;
									num3 = num;
								}
								else
								{
									num = 761116749;
									num3 = num;
								}
								continue;
							}
							case 3:
								break;
							case 2:
								result = true;
								num = 761116746;
								continue;
							case 1:
								goto end_IL_0013;
							case 5:
								goto IL_00f5;
							}
							goto IL_0065;
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
					goto IL_00f5;
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
					while (true)
					{
						IL_0068:
						int num2;
						int num3;
						if (!enumerator.MoveNext())
						{
							num2 = 605755563;
							num3 = num2;
						}
						else
						{
							num2 = 605755561;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x241B18AB)
							{
							case 3:
								num2 = 605755561;
								continue;
							default:
								goto end_IL_002f;
							case 2:
							{
								Button current = enumerator.Current;
								buttons[num] = current.elementIdentifier;
								num++;
								num2 = 605755562;
								continue;
							}
							case 1:
								break;
							case 0:
								goto end_IL_002f;
							}
							goto IL_0068;
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
							int num4 = 605755563;
							while (true)
							{
								switch (num4 ^ 0x241B18AB)
								{
								case 2:
									num4 = 605755562;
									continue;
								case 1:
									break;
								case 0:
									num++;
									num4 = 605755560;
									continue;
								default:
									goto end_IL_00c0;
								}
								break;
							}
							continue;
							end_IL_00c0:
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
					goto IL_000a;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				int num = 0;
				int num2 = 1581684406;
				goto IL_000f;
				IL_000f:
				while (true)
				{
					switch (num2 ^ 0x5E4696B4)
					{
					case 5:
						break;
					case 11:
						return null;
					case 2:
						num2 = 1581684402;
						continue;
					case 3:
						array[num].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num].alternateCalibrations, true);
						num2 = 1581684408;
						continue;
					case 9:
						array[num] = AxisCalibrationData.Default;
						num2 = 1581684407;
						continue;
					case 0:
						array[num].invert = axes_orig[num].invert;
						array[num].deadZone = axes_orig[num].axisDeadZone;
						if (Axes_orig[num].calibrateAxis)
						{
							array[num].zero = axes_orig[num].axisZero;
							num2 = 1581684405;
							continue;
						}
						goto case 3;
					case 1:
						array[num].min = axes_orig[num].axisMin;
						array[num].max = axes_orig[num].axisMax;
						num2 = 1581684407;
						continue;
					case 12:
						num++;
						num2 = 1581684402;
						continue;
					case 7:
						if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Axis)
						{
							int num4;
							if (axes_orig[num].sourceType == HardwareElementSourceTypeWithHat.Custom)
							{
								num2 = 1581684400;
								num4 = num2;
							}
							else
							{
								num2 = 1581684414;
								num4 = num2;
							}
							continue;
						}
						goto case 4;
					case 8:
						throw new NotImplementedException();
					case 4:
						array[num] = AxisCalibrationData.Default;
						num2 = 1581684404;
						continue;
					case 10:
						if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Button)
						{
							int num3;
							if (axes_orig[num].sourceType == HardwareElementSourceTypeWithHat.Hat)
							{
								num2 = 1581684413;
								num3 = num2;
							}
							else
							{
								num2 = 1581684412;
								num3 = num2;
							}
							continue;
						}
						goto case 9;
					default:
						if (num >= axes_orig.Length)
						{
							return array;
						}
						goto case 7;
					}
					break;
				}
				goto IL_000a;
				IL_000a:
				num2 = 1581684415;
				goto IL_000f;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				int num2 = default(int);
				while (true)
				{
					int num = -952691037;
					while (true)
					{
						switch (num ^ -952691038)
						{
						case 10:
							break;
						default:
							return;
						case 7:
						{
							int num4;
							if (num2 >= Axes_orig.Length)
							{
								num = -952691040;
								num4 = num;
							}
							else
							{
								num = -952691036;
								num4 = num;
							}
							continue;
						}
						case 5:
							axisRanges = new AxisRange[Axes_orig.Length];
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = -952691034;
							continue;
						case 11:
							axisRanges[num2] = AxisRange.Full;
							num = -952691030;
							continue;
						case 9:
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num5;
								if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Hat)
								{
									num = -952691038;
									num5 = num;
								}
								else
								{
									num = -952691031;
									num5 = num;
								}
								continue;
							}
							goto case 11;
						case 3:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -952691030;
							continue;
						case 1:
							if (Axes_orig == null)
							{
								return;
							}
							goto case 5;
						case 8:
							num2++;
							num = -952691035;
							continue;
						case 4:
							num = -952691035;
							continue;
						case 6:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num3;
								if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									num = -952691029;
									num3 = num;
								}
								else
								{
									num = -952691039;
									num3 = num;
								}
								continue;
							}
							goto case 3;
						case 0:
							throw new Exception();
						case 2:
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
				goto IL_003d;
				IL_000b:
				int num = 417875987;
				goto IL_0010;
				IL_0010:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ 0x18E84812)
					{
					case 0:
						break;
					case 1:
						return;
					case 5:
						goto IL_003d;
					case 2:
						num2++;
						num = 417875990;
						continue;
					case 3:
						buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
						num = 417875984;
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
				IL_003d:
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				num2 = 0;
				num = 417875990;
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

			internal IEnumerable<Axis> IterateAxes()
			{
				BvMbAjILhRqdJoEekSYqYvxPfcR bvMbAjILhRqdJoEekSYqYvxPfcR = new BvMbAjILhRqdJoEekSYqYvxPfcR(-2);
				bvMbAjILhRqdJoEekSYqYvxPfcR.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return bvMbAjILhRqdJoEekSYqYvxPfcR;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				sgwIMxuOJuPCJQTQxFIegMXdFMqg sgwIMxuOJuPCJQTQxFIegMXdFMqg2 = new sgwIMxuOJuPCJQTQxFIegMXdFMqg(-2);
				sgwIMxuOJuPCJQTQxFIegMXdFMqg2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return sgwIMxuOJuPCJQTQxFIegMXdFMqg2;
			}

			public override object DeepClone()
			{
				Platform_Linux_Base platform_Linux_Base = new Platform_Linux_Base();
				while (true)
				{
					int num = -881170918;
					while (true)
					{
						switch (num ^ -881170917)
						{
						case 0:
							break;
						case 1:
							goto IL_0024;
						default:
							return platform_Linux_Base;
						}
						break;
						IL_0024:
						CopyVars(platform_Linux_Base);
						num = -881170919;
					}
				}
			}

			internal override void CopyVars(Platform destination)
			{
				Platform_Linux_Base platform_Linux_Base = destination as Platform_Linux_Base;
				while (true)
				{
					switch (0x5FF4C93F ^ 0x5FF4C93E)
					{
					case 0:
						continue;
					case 1:
						if (platform_Linux_Base == null)
						{
							return;
						}
						break;
					}
					break;
				}
				platform_Linux_Base.elements = MiscTools.DeepClone(elements);
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
					goto IL_000d;
				}
				int num = default(int);
				int num2;
				if (base.hasVariants)
				{
					num = 0;
					num2 = 1566492694;
					goto IL_0012;
				}
				goto IL_0091;
				IL_0012:
				while (true)
				{
					switch (num2 ^ 0x5D5EC815)
					{
					case 2:
						break;
					case 3:
						goto IL_0033;
					case 4:
						goto IL_004f;
					case 1:
						return true;
					default:
						goto IL_0091;
					}
					break;
					IL_004f:
					int variantIndex2;
					if (variants[num] != null && variants[num].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
					{
						variantIndex = num;
						return true;
					}
					num++;
					num2 = 1566492694;
					continue;
					IL_0033:
					int num3;
					if (num < variants.Length)
					{
						num2 = 1566492689;
						num3 = num2;
					}
					else
					{
						num2 = 1566492693;
						num3 = num2;
					}
				}
				goto IL_000d;
				IL_0091:
				return false;
				IL_000d:
				num2 = 1566492692;
				goto IL_0012;
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
				if (platform_Linux == null)
				{
					return;
				}
				while (true)
				{
					platform_Linux.variants = MiscTools.DeepClone(variants);
					int num = -1732853390;
					while (true)
					{
						switch (num ^ -1732853389)
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
						num = -1732853391;
					}
				}
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
						ElementCount elementCount = default(ElementCount);
						while (true)
						{
							int num = 996091561;
							while (true)
							{
								switch (num ^ 0x3B5F26AA)
								{
								case 0:
									break;
								default:
									return;
								case 2:
									elementCount.hatCount = hatCount;
									num = 996091566;
									continue;
								case 1:
									if (elementCount == null)
									{
										return;
									}
									goto case 2;
								case 3:
									elementCount = P_0 as ElementCount;
									num = 996091563;
									continue;
								case 4:
									return;
								}
								break;
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
					goto IL_006c;
					IL_0008:
					int num = 1027343962;
					goto IL_000d;
					IL_000d:
					while (true)
					{
						switch (num ^ 0x3D3C065B)
						{
						case 2:
							break;
						case 3:
							goto IL_002e;
						case 4:
							return true;
						case 1:
							goto IL_005a;
						default:
							return true;
						}
						break;
						IL_002e:
						if (productName.Length == 0)
						{
							num = 1027343963;
							continue;
						}
						goto IL_00ac;
					}
					goto IL_0008;
					IL_005a:
					if (hasData && isAllowed)
					{
						return true;
					}
					goto IL_006c;
					IL_00ac:
					if (!AnyNameMatches(bridgedControllerHWInfo))
					{
						return false;
					}
					return true;
					IL_006c:
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (strictMatch)
					{
						if (PidVid.ArrayContains(productGUID, ref bridgedControllerHWInfo.hw_pidVid))
						{
							if (ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
							{
								int num2;
								if (productName != null)
								{
									num = 1027343960;
									num2 = num;
								}
								else
								{
									num = 1027343963;
									num2 = num;
								}
							}
							else
							{
								num = 1027343967;
							}
							goto IL_000d;
						}
						goto IL_00ac;
					}
					return AnyNameMatches(bridgedControllerHWInfo);
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					if (alternateElementCounts != null)
					{
						while (true)
						{
							int num = -1773378769;
							while (true)
							{
								switch (num ^ -1773378770)
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
								if (index < 0)
								{
									goto end_IL_0008;
								}
								if (index >= alternateElementCounts.Length)
								{
									num = -1773378770;
									continue;
								}
								return alternateElementCounts[index];
							}
							continue;
							end_IL_0008:
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
						num2 = 1252993845;
						goto IL_0010;
					}
					goto IL_002d;
					IL_0010:
					while (true)
					{
						switch (num2 ^ 0x4AAF2B36)
						{
						case 0:
							break;
						case 2:
							goto IL_002d;
						case 1:
							goto IL_003f;
						default:
							if (num >= names.Length)
							{
								return false;
							}
							goto IL_003f;
						}
						break;
						IL_003f:
						if (!string.IsNullOrEmpty(names[num]) && MatchingCriteria_Base.StringMatches(searchIn, names[num], useRegex))
						{
							return true;
						}
						num++;
						num2 = 1252993845;
					}
					goto IL_000b;
					IL_002d:
					return false;
					IL_000b:
					num2 = 1252993844;
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
						return;
					}
					while (true)
					{
						matchingCriteria.hatCount = hatCount;
						matchingCriteria.manufacturer_useRegex = manufacturer_useRegex;
						matchingCriteria.productName_useRegex = productName_useRegex;
						int num = -416747937;
						while (true)
						{
							switch (num ^ -416747938)
							{
							case 0:
								num = -416747939;
								continue;
							case 3:
								break;
							case 1:
								matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
								num = -416747940;
								continue;
							default:
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
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
				private sealed class jXHkgrFJNYHhCCRLvApKThnWves : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
				{
					private Axis aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public Elements iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public int oyNrSTXkEACkdoNvLBFDQziFtFJ;

					Axis IEnumerator<Axis>.Current
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
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							goto IL_0023;
						}
						goto IL_0052;
						IL_0028:
						int num;
						jXHkgrFJNYHhCCRLvApKThnWves jXHkgrFJNYHhCCRLvApKThnWves2 = default(jXHkgrFJNYHhCCRLvApKThnWves);
						while (true)
						{
							switch (num ^ -1269870573)
							{
							case 2:
								break;
							case 3:
								jXHkgrFJNYHhCCRLvApKThnWves2 = this;
								num = -1269870573;
								continue;
							case 4:
								goto IL_0052;
							case 1:
								jXHkgrFJNYHhCCRLvApKThnWves2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								num = -1269870573;
								continue;
							default:
								return jXHkgrFJNYHhCCRLvApKThnWves2;
							}
							break;
						}
						goto IL_0023;
						IL_0052:
						jXHkgrFJNYHhCCRLvApKThnWves2 = new jXHkgrFJNYHhCCRLvApKThnWves(0);
						num = -1269870574;
						goto IL_0028;
						IL_0023:
						num = -1269870576;
						goto IL_0028;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int num;
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 0:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.axes == null)
							{
								break;
							}
							oyNrSTXkEACkdoNvLBFDQziFtFJ = 0;
							num = -1697886566;
							goto IL_001f;
						case 1:
							{
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								oyNrSTXkEACkdoNvLBFDQziFtFJ++;
								num = -1697886566;
								goto IL_001f;
							}
							IL_001f:
							while (true)
							{
								switch (num ^ -1697886566)
								{
								case 4:
									num = -1697886565;
									continue;
								case 0:
									break;
								case 3:
									aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.axes[oyNrSTXkEACkdoNvLBFDQziFtFJ];
									num = -1697886568;
									continue;
								case 1:
									goto end_IL_001f;
								case 2:
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
									return true;
								default:
									goto end_IL_0008;
								}
								int num2;
								if (oyNrSTXkEACkdoNvLBFDQziFtFJ >= iKQXbXnVtIaMZEJNeigQJWAHqUx.axes.Length)
								{
									num = -1697886561;
									num2 = num;
								}
								else
								{
									num = -1697886567;
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
					public jXHkgrFJNYHhCCRLvApKThnWves(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class RejNdLpnRQsJtEKwdehveEzAyq : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
				{
					private Button aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public Elements iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public int WmPkKIsGDIFKNPsFrvqFNXBbFxj;

					Button IEnumerator<Button>.Current
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
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
						{
							goto IL_0012;
						}
						goto IL_0038;
						IL_0012:
						int num = 641547661;
						goto IL_0017;
						IL_0017:
						RejNdLpnRQsJtEKwdehveEzAyq rejNdLpnRQsJtEKwdehveEzAyq = default(RejNdLpnRQsJtEKwdehveEzAyq);
						while (true)
						{
							switch (num ^ 0x263D3D8F)
							{
							case 0:
								break;
							case 1:
								goto IL_0038;
							case 3:
								rejNdLpnRQsJtEKwdehveEzAyq = this;
								num = 641547659;
								continue;
							case 2:
								if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
								{
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
									num = 641547660;
									continue;
								}
								goto IL_0038;
							default:
								return rejNdLpnRQsJtEKwdehveEzAyq;
							}
							break;
						}
						goto IL_0012;
						IL_0038:
						rejNdLpnRQsJtEKwdehveEzAyq = new RejNdLpnRQsJtEKwdehveEzAyq(0);
						rejNdLpnRQsJtEKwdehveEzAyq.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = 641547659;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						default:
							num = 1930430495;
							goto IL_001a;
						case 1:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							WmPkKIsGDIFKNPsFrvqFNXBbFxj++;
							num = 1930430491;
							goto IL_001a;
						case 0:
							goto IL_0083;
							IL_001a:
							while (true)
							{
								switch (num ^ 0x7310081B)
								{
								case 5:
									break;
								case 1:
									aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.buttons[WmPkKIsGDIFKNPsFrvqFNXBbFxj];
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
									return true;
								case 6:
									goto IL_0083;
								case 2:
									num = 1930430491;
									continue;
								case 0:
									goto IL_00b2;
								case 4:
									num = 1930430488;
									continue;
								default:
									goto end_IL_0008;
								}
								break;
								IL_00b2:
								int num2;
								if (WmPkKIsGDIFKNPsFrvqFNXBbFxj >= iKQXbXnVtIaMZEJNeigQJWAHqUx.buttons.Length)
								{
									num = 1930430488;
									num2 = num;
								}
								else
								{
									num = 1930430490;
									num2 = num;
								}
							}
							goto default;
							IL_0083:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.buttons == null)
							{
								break;
							}
							WmPkKIsGDIFKNPsFrvqFNXBbFxj = 0;
							num = 1930430489;
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
					public RejNdLpnRQsJtEKwdehveEzAyq(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
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
						jXHkgrFJNYHhCCRLvApKThnWves jXHkgrFJNYHhCCRLvApKThnWves2 = new jXHkgrFJNYHhCCRLvApKThnWves(-2);
						while (true)
						{
							int num = -2114998700;
							while (true)
							{
								switch (num ^ -2114998698)
								{
								case 0:
									break;
								case 2:
									goto IL_0026;
								default:
									return jXHkgrFJNYHhCCRLvApKThnWves2;
								}
								break;
								IL_0026:
								jXHkgrFJNYHhCCRLvApKThnWves2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
								num = -2114998697;
							}
						}
					}
				}

				internal IEnumerable<Button> Buttons
				{
					get
					{
						RejNdLpnRQsJtEKwdehveEzAyq rejNdLpnRQsJtEKwdehveEzAyq = new RejNdLpnRQsJtEKwdehveEzAyq(-2);
						rejNdLpnRQsJtEKwdehveEzAyq.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
						return rejNdLpnRQsJtEKwdehveEzAyq;
					}
				}

				internal Axis GetAxis(int axisIndex)
				{
					if (axes != null && axisIndex >= 0)
					{
						while (true)
						{
							int num = 1044083981;
							while (true)
							{
								switch (num ^ 0x3E3B750C)
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
									num = 1044083980;
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
					int num2 = default(int);
					while (true)
					{
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = 1573362619;
							goto IL_0009;
						}
						goto IL_007a;
						IL_0009:
						while (true)
						{
							switch (num3 ^ 0x5DC79BBA)
							{
							case 4:
								num3 = 1573362617;
								continue;
							case 5:
								break;
							case 2:
								goto end_IL_0009;
							case 1:
								goto IL_0060;
							case 3:
								goto IL_007a;
							case 0:
								return ControllerElementType.Button;
							default:
								return elementIdentifier.elementType;
							}
							if (buttons[num2].elementIdentifier == elementIdentifier.id)
							{
								num3 = 1573362618;
								continue;
							}
							num2++;
							num3 = 1573362619;
							continue;
							IL_0060:
							int num4;
							if (num2 >= buttonCount)
							{
								num3 = 1573362620;
								num4 = num3;
							}
							else
							{
								num3 = 1573362623;
								num4 = num3;
							}
							continue;
							end_IL_0009:
							break;
						}
						continue;
						IL_007a:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							break;
						}
						num++;
						num3 = 1573362616;
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
							IL_0091:
							if (axes[num].elementIdentifier != elementIdentifier.id)
							{
								goto IL_003c;
							}
							sourceType = axes[num].sourceType;
							switch (sourceType)
							{
							case HardwareElementSourceTypeWithHat.Button:
								axisRange = AxisRange.Positive;
								return true;
							case HardwareElementSourceTypeWithHat.Hat:
								break;
							default:
								goto IL_00c6;
							case HardwareElementSourceTypeWithHat.Axis:
								goto IL_00d0;
							}
							axisRange = axes[num].sourceHatRange;
							int num2;
							if (axes[num].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
								num2 = 2121238829;
								goto IL_000c;
							}
							goto IL_0104;
							IL_0104:
							return true;
							IL_00c6:
							num2 = 2121238830;
							goto IL_000c;
							IL_00d0:
							axisRange = axes[num].sourceAxisRange;
							if (axes[num].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
								num2 = 2121238827;
								goto IL_000c;
							}
							goto IL_0056;
							IL_0056:
							return true;
							IL_003c:
							num++;
							num2 = 2121238825;
							goto IL_000c;
							IL_000c:
							while (true)
							{
								switch (num2 ^ 0x7E6F8928)
								{
								case 0:
									num2 = 2121238831;
									continue;
								case 2:
									break;
								case 6:
									goto IL_0047;
								case 3:
									goto IL_0056;
								case 7:
									goto IL_0091;
								case 4:
									goto IL_00d0;
								case 5:
									goto IL_0104;
								default:
									goto end_IL_0091;
								}
								break;
								IL_0047:
								if (sourceType == HardwareElementSourceTypeWithHat.Custom)
								{
									num2 = 2121238828;
									continue;
								}
								throw new NotImplementedException();
							}
							goto IL_003c;
							continue;
							end_IL_0091:
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
						elements.buttons = ArrayTools.DeepClone(buttons);
						int num = 1747639391;
						while (true)
						{
							switch (num ^ 0x682ADC5E)
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
							num = 1747639388;
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
					goto IL_00a7;
					IL_0014:
					int num = 801115198;
					goto IL_0019;
					IL_0019:
					while (true)
					{
						switch (num ^ 0x2FC00C3A)
						{
						case 5:
							break;
						case 4:
							return;
						case 0:
							sourceType = button.sourceType;
							sourceButton = button.sourceButton;
							sourceAxis = button.sourceAxis;
							sourceAxisPole = button.sourceAxisPole;
							axisDeadZone = button.axisDeadZone;
							sourceHat = button.sourceHat;
							sourceHatType = button.sourceHatType;
							num = 801115195;
							continue;
						case 2:
							goto IL_00a7;
						case 1:
							sourceHatDirection = button.sourceHatDirection;
							requireMultipleButtons = button.requireMultipleButtons;
							requiredButtons = ArrayTools.ShallowCopy(button.requiredButtons);
							ignoreIfButtonsActive = button.ignoreIfButtonsActive;
							num = 801115193;
							continue;
						default:
							ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(button.ignoreIfButtonsActiveButtons);
							buttonInfo = MiscTools.DeepClone(button.buttonInfo);
							return;
						}
						break;
					}
					goto IL_0014;
					IL_00a7:
					elementIdentifier = button.elementIdentifier;
					num = 801115194;
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
					axis.ImportVars(this);
					return axis;
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
						calibrateAxis = axis.calibrateAxis;
						axisZero = axis.axisZero;
						axisMin = axis.axisMin;
						axisMax = axis.axisMax;
						axisInfo = MiscTools.DeepClone(axis.axisInfo);
						int num = -125964603;
						while (true)
						{
							switch (num ^ -125964604)
							{
							case 3:
								num = -125964602;
								continue;
							case 2:
								break;
							case 0:
								buttonAxisContribution = axis.buttonAxisContribution;
								num = -125964608;
								continue;
							case 1:
								sourceButton = axis.sourceButton;
								num = -125964604;
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

			private sealed class zVtBycaeKgfJRPyhVcJCxoHWIuv : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_WindowsUWP_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int VEsGMnhosqQERaDbrXuqELWKVHK;

				public int vsJbhqkNAftePhECgkbZpdRLJUB;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						goto IL_0023;
					}
					goto IL_004e;
					IL_0028:
					int num;
					zVtBycaeKgfJRPyhVcJCxoHWIuv zVtBycaeKgfJRPyhVcJCxoHWIuv2 = default(zVtBycaeKgfJRPyhVcJCxoHWIuv);
					while (true)
					{
						switch (num ^ -215863744)
						{
						case 3:
							break;
						case 1:
							zVtBycaeKgfJRPyhVcJCxoHWIuv2 = this;
							num = -215863744;
							continue;
						case 2:
							goto IL_004e;
						default:
							return zVtBycaeKgfJRPyhVcJCxoHWIuv2;
						}
						break;
					}
					goto IL_0023;
					IL_004e:
					zVtBycaeKgfJRPyhVcJCxoHWIuv2 = new zVtBycaeKgfJRPyhVcJCxoHWIuv(0);
					zVtBycaeKgfJRPyhVcJCxoHWIuv2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					num = -215863744;
					goto IL_0028;
					IL_0023:
					num = -215863743;
					goto IL_0028;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
					while (true)
					{
						int num2 = -1462244888;
						while (true)
						{
							switch (num2 ^ -1462244882)
							{
							case 3:
								break;
							case 4:
							{
								int num3;
								if (vsJbhqkNAftePhECgkbZpdRLJUB >= VEsGMnhosqQERaDbrXuqELWKVHK)
								{
									num2 = -1462244881;
									num3 = num2;
								}
								else
								{
									num2 = -1462244884;
									num3 = num2;
								}
								continue;
							}
							case 0:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num2 = -1462244885;
								continue;
							case 5:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements != null && iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes != null)
								{
									VEsGMnhosqQERaDbrXuqELWKVHK = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes.Length;
									vsJbhqkNAftePhECgkbZpdRLJUB = 0;
									num2 = -1462244886;
									continue;
								}
								goto default;
							case 2:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes[vsJbhqkNAftePhECgkbZpdRLJUB];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 6:
								switch (num)
								{
								case 0:
									break;
								case 1:
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
									vsJbhqkNAftePhECgkbZpdRLJUB++;
									num2 = -1462244886;
									continue;
								default:
									num2 = -1462244881;
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
				public zVtBycaeKgfJRPyhVcJCxoHWIuv(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class rwqcnTIErNuXfkUfYDXJPuQXKvSq : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_WindowsUWP_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int BRVINQoROLjByXMIMgDkhBhpnHVM;

				public int DGYSyDKjeoeMOdPKvdNIffnlHtUc;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					rwqcnTIErNuXfkUfYDXJPuQXKvSq rwqcnTIErNuXfkUfYDXJPuQXKvSq2;
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						rwqcnTIErNuXfkUfYDXJPuQXKvSq2 = this;
					}
					else
					{
						while (true)
						{
							rwqcnTIErNuXfkUfYDXJPuQXKvSq2 = new rwqcnTIErNuXfkUfYDXJPuQXKvSq(0);
							rwqcnTIErNuXfkUfYDXJPuQXKvSq2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
							int num = -1581222347;
							while (true)
							{
								switch (num ^ -1581222345)
								{
								case 0:
									num = -1581222346;
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
					return rwqcnTIErNuXfkUfYDXJPuQXKvSq2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
					while (true)
					{
						int num2 = -939343243;
						while (true)
						{
							switch (num2 ^ -939343245)
							{
							case 2:
								break;
							case 0:
								num2 = -939343248;
								continue;
							case 1:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons[DGYSyDKjeoeMOdPKvdNIffnlHtUc];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 6:
								switch (num)
								{
								case 1:
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
									DGYSyDKjeoeMOdPKvdNIffnlHtUc++;
									num2 = -939343248;
									continue;
								default:
									num2 = -939343241;
									continue;
								case 0:
									break;
								}
								goto case 5;
							case 3:
							{
								int num3;
								if (DGYSyDKjeoeMOdPKvdNIffnlHtUc >= BRVINQoROLjByXMIMgDkhBhpnHVM)
								{
									num2 = -939343241;
									num3 = num2;
								}
								else
								{
									num2 = -939343246;
									num3 = num2;
								}
								continue;
							}
							case 5:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements != null && iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons != null)
								{
									BRVINQoROLjByXMIMgDkhBhpnHVM = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons.Length;
									DGYSyDKjeoeMOdPKvdNIffnlHtUc = 0;
									num2 = -939343245;
									continue;
								}
								goto default;
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
				public rwqcnTIErNuXfkUfYDXJPuQXKvSq(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.IHkiTQGteWsegyfjGnNBuPLSILmD;
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
				if (num < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				int num2 = array.Length;
				int num3 = 0;
				int num5 = default(int);
				while (true)
				{
					int num4 = -1280757376;
					while (true)
					{
						switch (num4 ^ -1280757370)
						{
						case 9:
							break;
						case 0:
						{
							int num7;
							if (num3 < num2)
							{
								num4 = -1280757374;
								num7 = num4;
							}
							else
							{
								num4 = -1280757372;
								num7 = num4;
							}
							continue;
						}
						case 3:
							array[num3] = identifiers[num5].name;
							num4 = -1280757369;
							continue;
						case 1:
							num3++;
							num4 = -1280757370;
							continue;
						case 8:
							Logger.LogError("Element identifier index is out of bounds!");
							num4 = -1280757375;
							continue;
						case 5:
							if (num5 >= 0)
							{
								int num6;
								if (num5 < num)
								{
									num4 = -1280757371;
									num6 = num4;
								}
								else
								{
									num4 = -1280757362;
									num6 = num4;
								}
								continue;
							}
							goto case 8;
						case 7:
							num4 = -1280757369;
							continue;
						case 4:
						{
							int elementIdentifier = elements.axes[num3].elementIdentifier;
							num5 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num4 = -1280757373;
							continue;
						}
						case 6:
							num4 = -1280757370;
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
				int elementIdentifier = default(int);
				int num3 = default(int);
				while (true)
				{
					int num = 605897821;
					while (true)
					{
						switch (num ^ 0x241D4454)
						{
						case 4:
							break;
						case 9:
							num5 = identifiers.Length;
							if (num5 < buttonCount)
							{
								num = 605897809;
								continue;
							}
							array = new string[buttonCount];
							num2 = 0;
							num = 605897813;
							continue;
						case 8:
							num2++;
							num = 605897813;
							continue;
						case 7:
							elementIdentifier = elements.buttons[num2].elementIdentifier;
							num = 605897823;
							continue;
						case 5:
							Logger.LogError("You have too few element identifiers!");
							num = 605897812;
							continue;
						case 0:
							return new string[0];
						case 10:
							array[num2] = identifiers[num3].name;
							num = 605897820;
							continue;
						case 6:
						{
							int num6;
							if (num3 >= num5)
							{
								num = 605897815;
								num6 = num;
							}
							else
							{
								num = 605897822;
								num6 = num;
							}
							continue;
						}
						case 3:
							Logger.LogError("Element identifier index is out of bounds!");
							num = 605897814;
							continue;
						case 2:
							num = 605897820;
							continue;
						case 11:
						{
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							int num4;
							if (num3 < 0)
							{
								num = 605897815;
								num4 = num;
							}
							else
							{
								num = 605897810;
								num4 = num;
							}
							continue;
						}
						default:
							if (num2 >= buttonCount)
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
				IEnumerator<Axis> enumerator = IterateAxes().GetEnumerator();
				try
				{
					while (true)
					{
						IL_004e:
						int num;
						int num2;
						if (enumerator.MoveNext())
						{
							num = 284784456;
							num2 = num;
						}
						else
						{
							num = 284784458;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x10F97749)
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
							case 0:
								break;
							case 3:
								goto end_IL_0013;
							}
							goto IL_004e;
							IL_000e:
							num = 284784456;
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
							IL_006c:
							int num3 = 284784456;
							while (true)
							{
								switch (num3 ^ 0x10F97749)
								{
								case 2:
									break;
								default:
									goto end_IL_0071;
								case 1:
									goto IL_008a;
								case 0:
									goto end_IL_0071;
								}
								goto IL_006c;
								IL_008a:
								enumerator.Dispose();
								num3 = 284784457;
								continue;
								end_IL_0071:
								break;
							}
							break;
						}
					}
				}
				using (IEnumerator<Button> enumerator2 = IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Button current2 = enumerator2.Current;
							int num4 = 284784458;
							while (true)
							{
								switch (num4 ^ 0x10F97749)
								{
								case 0:
									num4 = 284784459;
									continue;
								case 1:
									return true;
								case 3:
									break;
								case 2:
									goto end_IL_00ac;
								default:
									goto end_IL_00f2;
								}
								int num5;
								if (current2.elementIdentifier != elementIdentifierId)
								{
									num4 = 284784461;
									num5 = num4;
								}
								else
								{
									num4 = 284784456;
									num5 = num4;
								}
								continue;
								end_IL_00ac:
								break;
							}
							continue;
							end_IL_00f2:
							break;
						}
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				while (true)
				{
					int num = 525775127;
					while (true)
					{
						switch (num ^ 0x1F56B116)
						{
						case 0:
							break;
						case 1:
							goto IL_002b;
						default:
						{
							int num2 = 0;
							IEnumerator<Button> enumerator = IterateButtons().GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										Button current = enumerator.Current;
										buttons[num2] = current.elementIdentifier;
										num2++;
										int num3 = 525775127;
										while (true)
										{
											switch (num3 ^ 0x1F56B116)
											{
											case 0:
												num3 = 525775124;
												continue;
											case 2:
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
							finally
							{
								if (enumerator != null)
								{
									while (true)
									{
										IL_0096:
										int num4 = 525775127;
										while (true)
										{
											switch (num4 ^ 0x1F56B116)
											{
											case 0:
												break;
											default:
												goto end_IL_009b;
											case 1:
												goto IL_00b4;
											case 2:
												goto end_IL_009b;
											}
											goto IL_0096;
											IL_00b4:
											enumerator.Dispose();
											num4 = 525775124;
											continue;
											end_IL_009b:
											break;
										}
										break;
									}
								}
							}
							num2 = 0;
							IEnumerator<Axis> enumerator2 = IterateAxes().GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									while (true)
									{
										Axis current2 = enumerator2.Current;
										axes[num2] = current2.elementIdentifier;
										int num5 = 525775126;
										while (true)
										{
											switch (num5 ^ 0x1F56B116)
											{
											case 2:
												num5 = 525775127;
												continue;
											case 1:
												break;
											case 0:
												num2++;
												num5 = 525775125;
												continue;
											default:
												goto end_IL_00f5;
											}
											break;
										}
										continue;
										end_IL_00f5:
										break;
									}
								}
								return;
							}
							finally
							{
								if (enumerator2 != null)
								{
									while (true)
									{
										IL_0128:
										int num6 = 525775127;
										while (true)
										{
											switch (num6 ^ 0x1F56B116)
											{
											case 2:
												break;
											default:
												goto end_IL_012d;
											case 1:
												goto IL_0146;
											case 0:
												goto end_IL_012d;
											}
											goto IL_0128;
											IL_0146:
											enumerator2.Dispose();
											num6 = 525775126;
											continue;
											end_IL_012d:
											break;
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
						num = 525775124;
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
				int num2 = 182278858;
				goto IL_000f;
				IL_000f:
				while (true)
				{
					switch (num2 ^ 0xADD5ACF)
					{
					case 9:
						break;
					case 6:
						return null;
					case 10:
						throw new NotImplementedException();
					case 11:
						array[num] = AxisCalibrationData.Default;
						num2 = 182278862;
						continue;
					case 0:
						num2 = 182278860;
						continue;
					case 1:
						num2 = 182278860;
						continue;
					case 3:
						array[num].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num].alternateCalibrations, true);
						num++;
						num2 = 182278856;
						continue;
					case 8:
						if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Button)
						{
							int num4;
							if (axes_orig[num].sourceType == HardwareElementSourceTypeWithHat.Hat)
							{
								num2 = 182278852;
								num4 = num2;
							}
							else
							{
								num2 = 182278853;
								num4 = num2;
							}
							continue;
						}
						goto case 11;
					case 2:
						if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Axis)
						{
							int num3;
							if (axes_orig[num].sourceType == HardwareElementSourceTypeWithHat.Custom)
							{
								num2 = 182278859;
								num3 = num2;
							}
							else
							{
								num2 = 182278855;
								num3 = num2;
							}
							continue;
						}
						goto case 4;
					case 5:
						num2 = 182278856;
						continue;
					case 4:
						array[num] = AxisCalibrationData.Default;
						array[num].invert = axes_orig[num].invert;
						array[num].deadZone = axes_orig[num].axisDeadZone;
						if (Axes_orig[num].calibrateAxis)
						{
							array[num].zero = axes_orig[num].axisZero;
							array[num].min = axes_orig[num].axisMin;
							array[num].max = axes_orig[num].axisMax;
							num2 = 182278863;
							continue;
						}
						goto case 3;
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
				num2 = 182278857;
				goto IL_000f;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				int num2 = default(int);
				while (true)
				{
					int num = -2023721430;
					while (true)
					{
						switch (num ^ -2023721429)
						{
						case 5:
							break;
						case 2:
							throw new Exception();
						case 3:
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num4;
								if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Hat)
								{
									num = -2023721438;
									num4 = num;
								}
								else
								{
									num = -2023721431;
									num4 = num;
								}
								continue;
							}
							goto case 9;
						case 11:
							axisRanges = new AxisRange[Axes_orig.Length];
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = -2023721429;
							continue;
						case 9:
							axisRanges[num2] = AxisRange.Full;
							num = -2023721437;
							continue;
						case 4:
						{
							int num5;
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Custom)
							{
								num = -2023721432;
								num5 = num;
							}
							else
							{
								num = -2023721439;
								num5 = num;
							}
							continue;
						}
						case 10:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -2023721437;
							continue;
						case 7:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							num = -2023721427;
							continue;
						case 6:
						{
							int num3;
							if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Axis)
							{
								num = -2023721439;
								num3 = num;
							}
							else
							{
								num = -2023721425;
								num3 = num;
							}
							continue;
						}
						case 8:
							num2++;
							num = -2023721429;
							continue;
						case 1:
							axisInfos = null;
							if (Axes_orig == null)
							{
								return;
							}
							goto case 11;
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
				int num2 = default(int);
				while (true)
				{
					int num = -1270767525;
					while (true)
					{
						switch (num ^ -1270767528)
						{
						case 6:
							break;
						case 0:
							num = -1270767524;
							continue;
						case 7:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
							num2++;
							num = -1270767524;
							continue;
						case 1:
							return;
						case 3:
						{
							int num3;
							if (Buttons_orig == null)
							{
								num = -1270767527;
								num3 = num;
							}
							else
							{
								num = -1270767526;
								num3 = num;
							}
							continue;
						}
						case 5:
							num2 = 0;
							num = -1270767528;
							continue;
						case 2:
							buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
							num = -1270767523;
							continue;
						default:
							if (num2 >= Buttons_orig.Length)
							{
								return;
							}
							goto case 7;
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
				zVtBycaeKgfJRPyhVcJCxoHWIuv zVtBycaeKgfJRPyhVcJCxoHWIuv2 = new zVtBycaeKgfJRPyhVcJCxoHWIuv(-2);
				zVtBycaeKgfJRPyhVcJCxoHWIuv2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return zVtBycaeKgfJRPyhVcJCxoHWIuv2;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				rwqcnTIErNuXfkUfYDXJPuQXKvSq rwqcnTIErNuXfkUfYDXJPuQXKvSq2 = new rwqcnTIErNuXfkUfYDXJPuQXKvSq(-2);
				rwqcnTIErNuXfkUfYDXJPuQXKvSq2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return rwqcnTIErNuXfkUfYDXJPuQXKvSq2;
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
				if (platform_WindowsUWP_Base == null)
				{
					return;
				}
				while (true)
				{
					platform_WindowsUWP_Base.elements = MiscTools.DeepClone(elements);
					int num = -1445988523;
					while (true)
					{
						switch (num ^ -1445988523)
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
						num = -1445988524;
					}
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
					int num = 0;
					while (true)
					{
						int num2;
						int num3;
						if (num >= variants.Length)
						{
							num2 = 1657389534;
							num3 = num2;
						}
						else
						{
							num2 = 1657389529;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x62C9C1DB)
							{
							case 4:
								num2 = 1657389529;
								continue;
							case 2:
								break;
							case 0:
								goto end_IL_0023;
							case 1:
								return true;
							case 3:
								goto IL_0082;
							default:
								goto end_IL_0059;
							}
							if (variants[num] != null)
							{
								num2 = 1657389528;
								continue;
							}
							goto IL_0077;
							IL_0082:
							int variantIndex2;
							if (variants[num].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
							{
								variantIndex = num;
								num2 = 1657389530;
								continue;
							}
							goto IL_0077;
							IL_0077:
							num++;
							num2 = 1657389531;
							continue;
							end_IL_0023:
							break;
						}
						continue;
						end_IL_0059:
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
					switch (-239400865 ^ -239400867)
					{
					case 0:
						continue;
					case 2:
						platform_WindowsUWP = destination as Platform_WindowsUWP;
						if (platform_WindowsUWP == null)
						{
							return;
						}
						break;
					}
					break;
				}
				platform_WindowsUWP.variants = MiscTools.DeepClone(variants);
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
							return false;
						}
						if (matchUnityVersion && !UnityTools.IsUnityVersionInRange(matchUnityVersion_min, matchUnityVersion_max))
						{
							return false;
						}
						if (matchSysVersion && !PlatformTools.IsSysVersionInRange(matchSysVersion_min, matchSysVersion_max))
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
					if (!isAllowed)
					{
						return false;
					}
					if (alwaysMatch)
					{
						goto IL_002f;
					}
					string text = default(string);
					int num;
					if (base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						text = bridgedControllerHWInfo.hw_productName;
						int num2;
						if (text == null)
						{
							num = 554003045;
							num2 = num;
						}
						else
						{
							num = 554003041;
							num2 = num;
						}
					}
					else
					{
						num = 554003043;
					}
					goto IL_0034;
					IL_0034:
					int num3 = default(int);
					while (true)
					{
						switch (num ^ 0x21056A67)
						{
						case 0:
							break;
						case 6:
							text = text.Trim();
							if (productName != null)
							{
								num3 = 0;
								num = 554003044;
								continue;
							}
							goto default;
						case 8:
						{
							int num4;
							if (num3 < productName.Length)
							{
								num = 554003046;
								num4 = num;
							}
							else
							{
								num = 554003042;
								num4 = num;
							}
							continue;
						}
						case 4:
							return false;
						case 1:
						{
							string searchFor = productName[num3];
							if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
							{
								return true;
							}
							num3++;
							num = 554003055;
							continue;
						}
						case 2:
							text = string.Empty;
							num = 554003041;
							continue;
						case 7:
							return true;
						case 3:
							num = 554003055;
							continue;
						default:
							return false;
						}
						break;
					}
					goto IL_002f;
					IL_002f:
					num = 554003040;
					goto IL_0034;
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
						int num = -1581693272;
						while (true)
						{
							switch (num ^ -1581693271)
							{
							case 4:
								break;
							case 1:
								matchingCriteria = destination as MatchingCriteria;
								if (matchingCriteria == null)
								{
									return;
								}
								goto case 0;
							case 0:
								matchingCriteria.alwaysMatch = alwaysMatch;
								matchingCriteria.productName_useRegex = productName_useRegex;
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								num = -1581693269;
								continue;
							case 2:
								matchingCriteria.matchUnityVersion = matchUnityVersion;
								num = -1581693270;
								continue;
							default:
								matchingCriteria.matchUnityVersion_min = matchUnityVersion_min;
								matchingCriteria.matchUnityVersion_max = matchUnityVersion_max;
								matchingCriteria.matchSysVersion = matchSysVersion;
								matchingCriteria.matchSysVersion_min = matchSysVersion_min;
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
					int num4 = default(int);
					while (true)
					{
						int num2;
						int num3;
						if (num >= axisCount)
						{
							num2 = -1740297199;
							num3 = num2;
						}
						else
						{
							num2 = -1740297200;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -1740297193)
							{
							case 3:
								num2 = -1740297200;
								continue;
							case 2:
								break;
							case 6:
								num4 = 0;
								num2 = -1740297197;
								continue;
							case 1:
								if (buttons[num4].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num4++;
								num2 = -1740297198;
								continue;
							case 4:
								num2 = -1740297198;
								continue;
							case 0:
								return ControllerElementType.Axis;
							case 7:
								if (axes[num].elementIdentifier != elementIdentifier.id)
								{
									num++;
									num2 = -1740297195;
								}
								else
								{
									num2 = -1740297193;
								}
								continue;
							default:
								if (num4 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								goto case 1;
							}
							break;
						}
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
							IL_0066:
							int num2;
							if (axes[num].elementIdentifier == elementIdentifier.id)
							{
								sourceType = axes[num].sourceType;
								num2 = -1345223465;
								goto IL_000c;
							}
							goto IL_004c;
							IL_000c:
							while (true)
							{
								switch (num2 ^ -1345223470)
								{
								case 0:
									num2 = -1345223472;
									continue;
								case 1:
									break;
								case 3:
									goto end_IL_000c;
								case 6:
									return true;
								case 2:
									goto IL_0066;
								case 8:
									goto IL_0093;
								case 7:
									goto IL_00a2;
								case 5:
									goto IL_00d3;
								default:
									goto end_IL_0066;
								}
								goto IL_0040;
								IL_00d3:
								switch (sourceType)
								{
								case HardwareElementSourceTypeWithHat.Button:
									axisRange = AxisRange.Positive;
									num2 = -1345223468;
									continue;
								case HardwareElementSourceTypeWithHat.Axis:
									break;
								default:
									num2 = -1345223462;
									continue;
								}
								goto IL_00a2;
								IL_00a2:
								axisRange = axes[num].sourceAxisRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -1345223469;
									continue;
								}
								goto IL_0040;
								IL_0040:
								return true;
								IL_0093:
								if (sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									throw new NotImplementedException();
								}
								num2 = -1345223467;
								continue;
								end_IL_000c:
								break;
							}
							goto IL_004c;
							IL_004c:
							num++;
							num2 = -1345223466;
							goto IL_000c;
							continue;
							end_IL_0066:
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
						while (true)
						{
							switch (-2106310217 ^ -2106310218)
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
						return;
					}
					while (true)
					{
						destination.elementIdentifier = elementIdentifier;
						destination.sourceType = sourceType;
						destination.sourceAxis = sourceAxis;
						destination.axisDeadZone = axisDeadZone;
						int num = 638186250;
						while (true)
						{
							switch (num ^ 0x2609F30B)
							{
							case 0:
								goto IL_0004;
							case 2:
								break;
							default:
								destination.sourceButton = sourceButton;
								destination.sourceKeyCode = sourceKeyCode;
								destination.customCalculation = customCalculation;
								destination.customCalculationSourceData = ArrayTools.DeepClone(customCalculationSourceData);
								return;
							}
							break;
							IL_0004:
							num = 638186249;
						}
					}
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
					if (button == null)
					{
						return;
					}
					while (true)
					{
						button.sourceAxisPole = sourceAxisPole;
						int num = 1611794262;
						while (true)
						{
							switch (num ^ 0x60120752)
							{
							case 0:
								num = 1611794256;
								continue;
							case 2:
								break;
							case 4:
								button.unityHat_sourceAxis1 = unityHat_sourceAxis1;
								button.unityHat_sourceAxis2 = unityHat_sourceAxis2;
								button.unityHat_isActiveAxisValues1 = unityHat_isActiveAxisValues1;
								button.unityHat_isActiveAxisValues2 = unityHat_isActiveAxisValues2;
								button.unityHat_isActiveAxisValues3 = unityHat_isActiveAxisValues3;
								button.unityHat_zeroValues = unityHat_zeroValues;
								button.unityHat_checkNeverPressed = unityHat_checkNeverPressed;
								num = 1611794259;
								continue;
							case 1:
								button.unityHat_neverPressedZeroValues = unityHat_neverPressedZeroValues;
								num = 1611794257;
								continue;
							default:
								button.requireMultipleButtons = requireMultipleButtons;
								button.requiredButtons = ArrayTools.ShallowCopy(requiredButtons);
								button.ignoreIfButtonsActive = ignoreIfButtonsActive;
								button.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons);
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
					Axis axis = default(Axis);
					while (true)
					{
						int num = 715790778;
						while (true)
						{
							switch (num ^ 0x2AAA19BB)
							{
							case 5:
								break;
							case 0:
								axis.sourceAxisRange = sourceAxisRange;
								num = 715790776;
								continue;
							case 2:
								axis.axisMin = axisMin;
								num = 715790781;
								continue;
							case 1:
								axis = destination as Axis;
								if (axis == null)
								{
									return;
								}
								goto case 4;
							case 3:
								axis.buttonAxisContribution = buttonAxisContribution;
								axis.calibrateAxis = calibrateAxis;
								axis.axisZero = axisZero;
								num = 715790777;
								continue;
							case 4:
								axis.invert = invert;
								num = 715790779;
								continue;
							default:
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

			private sealed class SSlowsXXNtkIwLhbTMadhcCglYE : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_Fallback_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int rICFDyUogJiAaBldlsGCyaiHjZJ;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					SSlowsXXNtkIwLhbTMadhcCglYE sSlowsXXNtkIwLhbTMadhcCglYE;
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						sSlowsXXNtkIwLhbTMadhcCglYE = this;
						goto IL_0025;
					}
					goto IL_004e;
					IL_002a:
					int num;
					while (true)
					{
						switch (num ^ 0x465AEEBA)
						{
						case 0:
							break;
						case 3:
							num = 1180364475;
							continue;
						case 2:
							goto IL_004e;
						default:
							return sSlowsXXNtkIwLhbTMadhcCglYE;
						}
						break;
					}
					goto IL_0025;
					IL_004e:
					sSlowsXXNtkIwLhbTMadhcCglYE = new SSlowsXXNtkIwLhbTMadhcCglYE(0);
					sSlowsXXNtkIwLhbTMadhcCglYE.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					num = 1180364475;
					goto IL_002a;
					IL_0025:
					num = 1180364473;
					goto IL_002a;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 0:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements == null)
						{
							break;
						}
						int num2;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes == null)
						{
							num = -1095605484;
							num2 = num;
						}
						else
						{
							num = -1095605486;
							num2 = num;
						}
						goto IL_001f;
					}
					case 1:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							num = -1095605485;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -1095605488)
							{
							case 0:
								num = -1095605483;
								continue;
							case 6:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes[rICFDyUogJiAaBldlsGCyaiHjZJ];
								num = -1095605481;
								continue;
							case 1:
								break;
							case 5:
								goto end_IL_001f;
							case 7:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 3:
								rICFDyUogJiAaBldlsGCyaiHjZJ++;
								num = -1095605487;
								continue;
							case 2:
								rICFDyUogJiAaBldlsGCyaiHjZJ = 0;
								num = -1095605487;
								continue;
							default:
								goto end_IL_0008;
							}
							int num3;
							if (rICFDyUogJiAaBldlsGCyaiHjZJ >= iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes.Length)
							{
								num = -1095605484;
								num3 = num;
							}
							else
							{
								num = -1095605482;
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
				public SSlowsXXNtkIwLhbTMadhcCglYE(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class VhIDnPzgnmwgOpUiqaBKmALOcTx : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_Fallback_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int tycSDcJOzbgJryLMuBXNnDCLAOp;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					VhIDnPzgnmwgOpUiqaBKmALOcTx vhIDnPzgnmwgOpUiqaBKmALOcTx;
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						vhIDnPzgnmwgOpUiqaBKmALOcTx = this;
						goto IL_0025;
					}
					goto IL_004e;
					IL_002a:
					int num;
					while (true)
					{
						switch (num ^ -1305095253)
						{
						case 0:
							break;
						case 1:
							num = -1305095255;
							continue;
						case 3:
							goto IL_004e;
						default:
							return vhIDnPzgnmwgOpUiqaBKmALOcTx;
						}
						break;
					}
					goto IL_0025;
					IL_004e:
					vhIDnPzgnmwgOpUiqaBKmALOcTx = new VhIDnPzgnmwgOpUiqaBKmALOcTx(0);
					vhIDnPzgnmwgOpUiqaBKmALOcTx.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					num = -1305095255;
					goto IL_002a;
					IL_0025:
					num = -1305095254;
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
					int num3;
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					default:
						num = -1644159703;
						goto IL_001a;
					case 0:
						goto IL_0083;
					case 1:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							num = -1644159706;
							goto IL_001a;
						}
						IL_001a:
						while (true)
						{
							switch (num ^ -1644159698)
							{
							case 5:
								break;
							case 2:
								num = -1644159697;
								continue;
							case 8:
								tycSDcJOzbgJryLMuBXNnDCLAOp++;
								num = -1644159697;
								continue;
							case 7:
								num = -1644159702;
								continue;
							case 6:
								tycSDcJOzbgJryLMuBXNnDCLAOp = 0;
								num = -1644159700;
								continue;
							case 0:
								goto IL_0083;
							case 1:
								goto IL_00c0;
							case 3:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons[tycSDcJOzbgJryLMuBXNnDCLAOp];
								num = -1644159705;
								continue;
							case 9:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00c0:
							int num2;
							if (tycSDcJOzbgJryLMuBXNnDCLAOp >= iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons.Length)
							{
								num = -1644159702;
								num2 = num;
							}
							else
							{
								num = -1644159699;
								num2 = num;
							}
						}
						goto default;
						IL_0083:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements == null)
						{
							break;
						}
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons != null)
						{
							num = -1644159704;
							num3 = num;
						}
						else
						{
							num = -1644159702;
							num3 = num;
						}
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
				public VhIDnPzgnmwgOpUiqaBKmALOcTx(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
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
					return InputPlatform.EVZdDKgoYzTsgudyOpbfAYPsMaVf;
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
						num = 552654988;
						goto IL_001c;
					}
					return true;
					IL_0017:
					num = 552654991;
					goto IL_001c;
					IL_001c:
					switch (num ^ 0x20F0D88D)
					{
					case 0:
						break;
					case 2:
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
				platformMap = null;
				if (matchingCriteria != null)
				{
					while (true)
					{
						int num = 1400098415;
						while (true)
						{
							switch (num ^ 0x5373CE6E)
							{
							case 0:
								break;
							case 1:
								goto IL_002d;
							default:
								platformMap = this;
								return true;
							}
							break;
							IL_002d:
							if (!matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
							{
								goto end_IL_000f;
							}
							num = 1400098412;
						}
						continue;
						end_IL_000f:
						break;
					}
				}
				return false;
			}

			internal IEnumerable<Axis> IterateAxes()
			{
				SSlowsXXNtkIwLhbTMadhcCglYE sSlowsXXNtkIwLhbTMadhcCglYE = new SSlowsXXNtkIwLhbTMadhcCglYE(-2);
				sSlowsXXNtkIwLhbTMadhcCglYE.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return sSlowsXXNtkIwLhbTMadhcCglYE;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				VhIDnPzgnmwgOpUiqaBKmALOcTx vhIDnPzgnmwgOpUiqaBKmALOcTx = new VhIDnPzgnmwgOpUiqaBKmALOcTx(-2);
				vhIDnPzgnmwgOpUiqaBKmALOcTx.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return vhIDnPzgnmwgOpUiqaBKmALOcTx;
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
				int num4 = default(int);
				while (true)
				{
					int num2;
					int num3;
					if (num < array.Length)
					{
						num2 = -1742847781;
						num3 = num2;
					}
					else
					{
						num2 = -1742847784;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1742847783)
						{
						case 5:
							num2 = -1742847781;
							continue;
						case 2:
							elementIdentifier = elements.axes[num].elementIdentifier;
							num2 = -1742847779;
							continue;
						case 6:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = -1742847778;
							continue;
						case 8:
							break;
						case 4:
							num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num2 = -1742847782;
							continue;
						case 0:
							array[num] = identifiers[num4].name;
							num2 = -1742847778;
							continue;
						case 3:
							if (num4 >= 0)
							{
								int num5;
								if (num4 >= identifiers.Length)
								{
									num2 = -1742847777;
									num5 = num2;
								}
								else
								{
									num2 = -1742847783;
									num5 = num2;
								}
								continue;
							}
							goto case 6;
						case 7:
							num++;
							num2 = -1742847791;
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
				if (identifiers.Length < buttonCount)
				{
					goto IL_0012;
				}
				string[] array = new string[buttonCount];
				int num = 0;
				int num2 = -701534547;
				goto IL_0017;
				IL_0017:
				int num3 = default(int);
				while (true)
				{
					switch (num2 ^ -701534556)
					{
					case 5:
						break;
					case 10:
						Logger.LogError("You have too few element identifiers!");
						return new string[0];
					case 6:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = -701534560;
						continue;
					case 7:
						num++;
						num2 = -701534553;
						continue;
					case 2:
						array[num] = identifiers[num3].name;
						num2 = -701534557;
						continue;
					case 8:
					{
						int elementIdentifier = elements.buttons[num].elementIdentifier;
						num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						num2 = -701534555;
						continue;
					}
					case 9:
						num2 = -701534553;
						continue;
					case 1:
					{
						int num5;
						if (num3 >= 0)
						{
							num2 = -701534556;
							num5 = num2;
						}
						else
						{
							num2 = -701534558;
							num5 = num2;
						}
						continue;
					}
					case 4:
						num2 = -701534557;
						continue;
					case 0:
					{
						int num4;
						if (num3 < identifiers.Length)
						{
							num2 = -701534554;
							num4 = num2;
						}
						else
						{
							num2 = -701534558;
							num4 = num2;
						}
						continue;
					}
					default:
						if (num >= array.Length)
						{
							return array;
						}
						goto case 8;
					}
					break;
				}
				goto IL_0012;
				IL_0012:
				num2 = -701534546;
				goto IL_0017;
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
							int num = -1659373648;
							while (true)
							{
								switch (num ^ -1659373648)
								{
								case 2:
									num = -1659373647;
									continue;
								case 1:
									break;
								default:
									goto end_IL_0030;
								case 0:
									goto IL_011a;
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
					while (true)
					{
						IL_00cb:
						int num2;
						int num3;
						if (!enumerator2.MoveNext())
						{
							num2 = -1659373646;
							num3 = num2;
						}
						else
						{
							num2 = -1659373647;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -1659373648)
							{
							case 3:
								num2 = -1659373647;
								continue;
							default:
								goto end_IL_007d;
							case 1:
							{
								Button current2 = enumerator2.Current;
								int num4;
								if (current2.elementIdentifier == elementIdentifierId)
								{
									num2 = -1659373648;
									num4 = num2;
								}
								else
								{
									num2 = -1659373644;
									num4 = num2;
								}
								continue;
							}
							case 0:
								result = true;
								goto IL_011a;
							case 4:
								break;
							case 2:
								goto end_IL_007d;
							}
							goto IL_00cb;
							continue;
							end_IL_007d:
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
							IL_00eb:
							int num5 = -1659373646;
							while (true)
							{
								switch (num5 ^ -1659373648)
								{
								case 0:
									break;
								default:
									goto end_IL_00f0;
								case 2:
									goto IL_0109;
								case 1:
									goto end_IL_00f0;
								}
								goto IL_00eb;
								IL_0109:
								enumerator2.Dispose();
								num5 = -1659373647;
								continue;
								end_IL_00f0:
								break;
							}
							break;
						}
					}
				}
				return false;
				IL_011a:
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
							buttons[num] = current.elementIdentifier;
							int num2 = 619754940;
							while (true)
							{
								switch (num2 ^ 0x24F0B5BD)
								{
								case 0:
									num2 = 619754943;
									continue;
								case 2:
									break;
								case 1:
									num++;
									num2 = 619754942;
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
							int num3 = 619754942;
							while (true)
							{
								switch (num3 ^ 0x24F0B5BD)
								{
								case 4:
									num3 = 619754940;
									continue;
								case 1:
									break;
								case 3:
									axes[num] = current2.elementIdentifier;
									num3 = 619754943;
									continue;
								case 2:
									num++;
									num3 = 619754941;
									continue;
								default:
									goto end_IL_00ba;
								}
								break;
							}
							continue;
							end_IL_00ba:
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
							IL_00f4:
							int num4 = 619754940;
							while (true)
							{
								switch (num4 ^ 0x24F0B5BD)
								{
								case 2:
									break;
								default:
									goto end_IL_00f9;
								case 1:
									goto IL_0112;
								case 0:
									goto end_IL_00f9;
								}
								goto IL_00f4;
								IL_0112:
								enumerator2.Dispose();
								num4 = 619754941;
								continue;
								end_IL_00f9:
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
					goto IL_000d;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				int num = 0;
				int num2 = -1154895585;
				goto IL_0012;
				IL_0012:
				while (true)
				{
					switch (num2 ^ -1154895588)
					{
					case 4:
						break;
					case 2:
						array[num].zero = axes_orig[num].axisZero;
						array[num].min = axes_orig[num].axisMin;
						array[num].max = axes_orig[num].axisMax;
						num2 = -1154895593;
						continue;
					case 7:
					{
						int num7;
						if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Custom)
						{
							num2 = -1154895588;
							num7 = num2;
						}
						else
						{
							num2 = -1154895594;
							num7 = num2;
						}
						continue;
					}
					case 9:
						array[num] = AxisCalibrationData.Default;
						num2 = -1154895599;
						continue;
					case 12:
						throw new NotImplementedException();
					case 13:
						num2 = -1154895587;
						continue;
					case 5:
						return null;
					case 11:
						num2 = -1154895587;
						continue;
					case 1:
						array[num].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num].alternateCalibrations, true);
						num++;
						num2 = -1154895585;
						continue;
					case 10:
					{
						array[num] = AxisCalibrationData.Default;
						array[num].invert = axes_orig[num].invert;
						array[num].deadZone = axes_orig[num].axisDeadZone;
						int num6;
						if (Axes_orig[num].calibrateAxis)
						{
							num2 = -1154895586;
							num6 = num2;
						}
						else
						{
							num2 = -1154895587;
							num6 = num2;
						}
						continue;
					}
					case 0:
					{
						int num5;
						if (axes_orig[num].sourceType == HardwareElementSourceTypeWithHat.Button)
						{
							num2 = -1154895595;
							num5 = num2;
						}
						else
						{
							num2 = -1154895596;
							num5 = num2;
						}
						continue;
					}
					case 6:
					{
						int num4;
						if (axes_orig[num].sourceType == HardwareElementSourceTypeWithHat.Axis)
						{
							num2 = -1154895594;
							num4 = num2;
						}
						else
						{
							num2 = -1154895589;
							num4 = num2;
						}
						continue;
					}
					case 8:
					{
						int num3;
						if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							num2 = -1154895600;
							num3 = num2;
						}
						else
						{
							num2 = -1154895595;
							num3 = num2;
						}
						continue;
					}
					default:
						if (num >= axes_orig.Length)
						{
							return array;
						}
						goto case 6;
					}
					break;
				}
				goto IL_000d;
				IL_000d:
				num2 = -1154895591;
				goto IL_0012;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				int num2 = default(int);
				while (true)
				{
					int num = 337755537;
					while (true)
					{
						switch (num ^ 0x1421BD99)
						{
						case 2:
							break;
						default:
							return;
						case 4:
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = 337755551;
							continue;
						case 9:
							num2++;
							num = 337755551;
							continue;
						case 0:
							axisRanges[num2] = AxisRange.Full;
							num = 337755536;
							continue;
						case 5:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = 337755536;
							continue;
						case 7:
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num6;
								if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									num = 337755546;
									num6 = num;
								}
								else
								{
									num = 337755548;
									num6 = num;
								}
								continue;
							}
							goto case 5;
						case 6:
						{
							int num4;
							if (num2 < Axes_orig.Length)
							{
								num = 337755541;
								num4 = num;
							}
							else
							{
								num = 337755540;
								num4 = num;
							}
							continue;
						}
						case 8:
						{
							int num7;
							if (Axes_orig != null)
							{
								num = 337755544;
								num7 = num;
							}
							else
							{
								num = 337755543;
								num7 = num;
							}
							continue;
						}
						case 11:
							throw new Exception();
						case 3:
						{
							int num5;
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								num = 337755539;
								num5 = num;
							}
							else
							{
								num = 337755545;
								num5 = num;
							}
							continue;
						}
						case 10:
						{
							int num3;
							if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Hat)
							{
								num = 337755545;
								num3 = num;
							}
							else
							{
								num = 337755538;
								num3 = num;
							}
							continue;
						}
						case 1:
							axisRanges = new AxisRange[Axes_orig.Length];
							num = 337755549;
							continue;
						case 12:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							num = 337755550;
							continue;
						case 14:
							return;
						case 13:
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
					int num = -945915153;
					while (true)
					{
						switch (num ^ -945915156)
						{
						case 0:
							break;
						case 5:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
							num2++;
							num = -945915155;
							continue;
						case 2:
							buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
							num2 = 0;
							num = -945915160;
							continue;
						case 3:
							if (Buttons_orig == null)
							{
								return;
							}
							goto case 2;
						case 4:
							num = -945915155;
							continue;
						default:
							if (num2 >= Buttons_orig.Length)
							{
								return;
							}
							goto case 5;
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
				while (true)
				{
					int num = 1197590127;
					while (true)
					{
						switch (num ^ 0x4761C66E)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							if (platform_Fallback_Base != null)
							{
								goto IL_0034;
							}
							return;
						case 2:
							goto IL_0034;
						case 3:
							return;
						}
						break;
						IL_0034:
						platform_Fallback_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
						platform_Fallback_Base.elements = MiscTools.DeepClone(elements);
						num = 1197590125;
					}
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
						int num = 1652200758;
						while (true)
						{
							switch (num ^ 0x627A9537)
							{
							case 3:
								break;
							case 2:
								goto IL_003d;
							case 4:
								goto IL_0059;
							case 1:
								num2 = 0;
								num = 1652200757;
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
							num = 1652200757;
							continue;
							IL_003d:
							int num3;
							if (num2 >= variants.Length)
							{
								num = 1652200759;
								num3 = num;
							}
							else
							{
								num = 1652200755;
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
				Platform_Fallback platform_Fallback = new Platform_Fallback();
				CopyVars(platform_Fallback);
				return platform_Fallback;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_Fallback platform_Fallback = destination as Platform_Fallback;
				if (platform_Fallback == null)
				{
					while (true)
					{
						switch (-212921780 ^ -212921778)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				platform_Fallback.variants = MiscTools.DeepClone(variants);
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
					if (disabled)
					{
						return false;
					}
					int num;
					if (!isAllowed)
					{
						num = 445657837;
						goto IL_001d;
					}
					if (alwaysMatch)
					{
						return true;
					}
					return true;
					IL_0018:
					num = 445657838;
					goto IL_001d;
					IL_001d:
					switch (num ^ 0x1A9032EC)
					{
					case 0:
						break;
					case 2:
						return true;
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
					MatchingCriteria matchingCriteria = default(MatchingCriteria);
					while (true)
					{
						int num = -1829788803;
						while (true)
						{
							switch (num ^ -1829788804)
							{
							case 3:
								break;
							case 1:
							{
								matchingCriteria = destination as MatchingCriteria;
								int num2;
								if (matchingCriteria != null)
								{
									num = -1829788802;
									num2 = num;
								}
								else
								{
									num = -1829788804;
									num2 = num;
								}
								continue;
							}
							case 0:
								return;
							default:
								matchingCriteria.alwaysMatch = alwaysMatch;
								return;
							}
							break;
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
					while (true)
					{
						int num = 468427075;
						while (true)
						{
							switch (num ^ 0x1BEBA142)
							{
							case 3:
								break;
							case 1:
								customCalculationSourceData.sourceOtherAxis = sourceOtherAxis;
								customCalculationSourceData.sourceAxisRange = sourceAxisRange;
								num = 468427072;
								continue;
							case 2:
								customCalculationSourceData.axisDeadZone = axisDeadZone;
								customCalculationSourceData.invert = invert;
								customCalculationSourceData.axisCalibrationType = axisCalibrationType;
								customCalculationSourceData.axisZero = axisZero;
								customCalculationSourceData.axisMin = axisMin;
								num = 468427074;
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
					while (true)
					{
						int num = -2131266390;
						while (true)
						{
							switch (num ^ -2131266389)
							{
							case 0:
								break;
							case 1:
								goto IL_0042;
							default:
								destination.sourceButton = sourceButton;
								destination.customCalculation = customCalculation;
								destination.customCalculationSourceData = ArrayTools.DeepClone(customCalculationSourceData);
								return;
							}
							break;
							IL_0042:
							destination.axisDeadZone = axisDeadZone;
							num = -2131266391;
						}
					}
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
					Button button = default(Button);
					while (true)
					{
						int num = 575426726;
						while (true)
						{
							switch (num ^ 0x224C50A7)
							{
							case 3:
								break;
							case 4:
								button.ignoreIfButtonsActive = ignoreIfButtonsActive;
								button.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons);
								num = 575426727;
								continue;
							case 2:
								button.sourceAxisPole = sourceAxisPole;
								button.requireMultipleButtons = requireMultipleButtons;
								button.requiredButtons = ArrayTools.ShallowCopy(requiredButtons);
								num = 575426723;
								continue;
							case 1:
								button = destination as Button;
								if (button == null)
								{
									return;
								}
								goto case 2;
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
						int num = 1787875522;
						while (true)
						{
							switch (num ^ 0x6A90D0C7)
							{
							case 0:
								break;
							case 5:
								axis = destination as Axis;
								num = 1787875526;
								continue;
							case 1:
								if (axis == null)
								{
									return;
								}
								goto case 4;
							case 2:
								axis.axisInfo = MiscTools.DeepClone(axisInfo);
								num = 1787875524;
								continue;
							case 4:
								axis.invert = invert;
								axis.sourceAxisRange = sourceAxisRange;
								axis.buttonAxisContribution = buttonAxisContribution;
								axis.calibrateAxis = calibrateAxis;
								axis.axisZero = axisZero;
								axis.axisMin = axisMin;
								axis.axisMax = axisMax;
								num = 1787875525;
								continue;
							default:
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
					if (bridgedControllerHWInfo.isMock)
					{
						while (true)
						{
							int num = -307036589;
							while (true)
							{
								switch (num ^ -307036590)
								{
								case 2:
									break;
								case 1:
									goto IL_0026;
								default:
									goto IL_0035;
								}
								break;
								IL_0035:
								if (!isAllowed)
								{
									goto end_IL_0008;
								}
								return true;
								IL_0026:
								if (!hasData)
								{
									goto end_IL_0008;
								}
								num = -307036590;
							}
							continue;
							end_IL_0008:
							break;
						}
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (!alwaysMatch)
					{
						return false;
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
					int num4 = default(int);
					while (true)
					{
						int num2;
						int num3;
						if (num >= axisCount)
						{
							num2 = 629799505;
							num3 = num2;
						}
						else
						{
							num2 = 629799508;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x2589FA50)
							{
							case 7:
								num2 = 629799508;
								continue;
							case 2:
								num2 = 629799504;
								continue;
							case 5:
								if (buttons[num4].elementIdentifier == elementIdentifier.id)
								{
									num2 = 629799510;
									continue;
								}
								num4++;
								num2 = 629799504;
								continue;
							case 4:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = 629799507;
								continue;
							case 1:
								num4 = 0;
								num2 = 629799506;
								continue;
							case 6:
								return ControllerElementType.Button;
							case 3:
								break;
							default:
								if (num4 >= buttonCount)
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
					int sourceType = default(int);
					while (num < axisCount)
					{
						while (true)
						{
							IL_0084:
							int num2;
							if (axes[num].elementIdentifier == elementIdentifier.id)
							{
								sourceType = axes[num].sourceType;
								num2 = 568727816;
								goto IL_000c;
							}
							goto IL_003c;
							IL_000c:
							while (true)
							{
								switch (num2 ^ 0x21E61908)
								{
								case 7:
									num2 = 568727817;
									continue;
								case 4:
									break;
								case 6:
									return true;
								case 5:
									goto IL_0056;
								case 1:
									goto IL_0084;
								case 0:
									goto IL_00b1;
								case 2:
									goto IL_00ce;
								default:
									goto end_IL_0084;
								}
								break;
								IL_00b1:
								switch (sourceType)
								{
								default:
									throw new NotImplementedException();
								case 1:
									break;
								case 100:
									num2 = 568727821;
									continue;
								case 0:
									axisRange = AxisRange.Positive;
									num2 = 568727822;
									continue;
								}
								goto IL_0056;
								IL_0056:
								axisRange = axes[num].sourceAxisRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 568727818;
									continue;
								}
								goto IL_00ce;
								IL_00ce:
								return true;
							}
							goto IL_003c;
							IL_003c:
							num++;
							num2 = 568727819;
							goto IL_000c;
							continue;
							end_IL_0084:
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
					while (true)
					{
						int num = -1658285724;
						while (true)
						{
							switch (num ^ -1658285723)
							{
							case 2:
								break;
							case 1:
								if (elements != null)
								{
									goto IL_003b;
								}
								return;
							case 0:
								goto IL_003b;
							default:
								elements.buttons = ArrayTools.DeepClone(buttons);
								return;
							}
							break;
							IL_003b:
							elements.axes = ArrayTools.DeepClone(axes);
							num = -1658285722;
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

			private sealed class gHStAfOjRcVafekqZWmnGSpajgm : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_Ouya_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int BeUTZjlbTUGDvFQMDOShCQPPfAE;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
					{
						goto IL_0012;
					}
					goto IL_0059;
					IL_0012:
					int num = 1070454462;
					goto IL_0017;
					IL_0017:
					gHStAfOjRcVafekqZWmnGSpajgm gHStAfOjRcVafekqZWmnGSpajgm2 = default(gHStAfOjRcVafekqZWmnGSpajgm);
					while (true)
					{
						switch (num ^ 0x3FCDD6BF)
						{
						case 4:
							break;
						case 1:
							if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
							{
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
								num = 1070454463;
								continue;
							}
							goto IL_0059;
						case 0:
							gHStAfOjRcVafekqZWmnGSpajgm2 = this;
							num = 1070454460;
							continue;
						case 2:
							goto IL_0059;
						default:
							return gHStAfOjRcVafekqZWmnGSpajgm2;
						}
						break;
					}
					goto IL_0012;
					IL_0059:
					gHStAfOjRcVafekqZWmnGSpajgm2 = new gHStAfOjRcVafekqZWmnGSpajgm(0);
					gHStAfOjRcVafekqZWmnGSpajgm2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					num = 1070454460;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					default:
						num = -2061715420;
						goto IL_001a;
					case 1:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						BeUTZjlbTUGDvFQMDOShCQPPfAE++;
						num = -2061715423;
						goto IL_001a;
					case 0:
						goto IL_00bd;
						IL_001a:
						while (true)
						{
							switch (num ^ -2061715424)
							{
							case 6:
								break;
							case 4:
								num = -2061715424;
								continue;
							case 3:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes[BeUTZjlbTUGDvFQMDOShCQPPfAE];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 1:
								goto IL_008f;
							case 5:
								goto IL_00bd;
							case 2:
								num = -2061715423;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_008f:
							int num2;
							if (BeUTZjlbTUGDvFQMDOShCQPPfAE < iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes.Length)
							{
								num = -2061715421;
								num2 = num;
							}
							else
							{
								num = -2061715424;
								num2 = num;
							}
						}
						goto default;
						IL_00bd:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements == null || iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes == null)
						{
							break;
						}
						BeUTZjlbTUGDvFQMDOShCQPPfAE = 0;
						num = -2061715422;
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
				public gHStAfOjRcVafekqZWmnGSpajgm(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class FdTAcahXbYaPuuQVENcXTNclciBc : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_Ouya_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int sZlKnHBtGjNNqWTjIAJdDMlPYEx;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					FdTAcahXbYaPuuQVENcXTNclciBc fdTAcahXbYaPuuQVENcXTNclciBc;
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						fdTAcahXbYaPuuQVENcXTNclciBc = this;
					}
					else
					{
						while (true)
						{
							fdTAcahXbYaPuuQVENcXTNclciBc = new FdTAcahXbYaPuuQVENcXTNclciBc(0);
							fdTAcahXbYaPuuQVENcXTNclciBc.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
							int num = -1299716404;
							while (true)
							{
								switch (num ^ -1299716404)
								{
								case 2:
									num = -1299716403;
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
					return fdTAcahXbYaPuuQVENcXTNclciBc;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
					while (true)
					{
						int num2 = 763838682;
						while (true)
						{
							switch (num2 ^ 0x2D8740DB)
							{
							case 0:
								break;
							case 2:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons[sZlKnHBtGjNNqWTjIAJdDMlPYEx];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num2 = 763838687;
								continue;
							case 4:
								return true;
							case 5:
							{
								int num3;
								if (sZlKnHBtGjNNqWTjIAJdDMlPYEx < iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons.Length)
								{
									num2 = 763838681;
									num3 = num2;
								}
								else
								{
									num2 = 763838685;
									num3 = num2;
								}
								continue;
							}
							case 3:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements != null && iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons != null)
								{
									sZlKnHBtGjNNqWTjIAJdDMlPYEx = 0;
									num2 = 763838686;
									continue;
								}
								goto default;
							case 1:
								switch (num)
								{
								case 1:
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
									sZlKnHBtGjNNqWTjIAJdDMlPYEx++;
									num2 = 763838686;
									continue;
								case 0:
									break;
								default:
									num2 = 763838685;
									continue;
								}
								goto case 3;
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
				public FdTAcahXbYaPuuQVENcXTNclciBc(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
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
					return InputPlatform.RBYZuIoTfgdiCjovvTtnANAPAAn;
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
							int num = -744940021;
							while (true)
							{
								switch (num ^ -744940022)
								{
								case 0:
									break;
								case 1:
									if (axes_orig != null)
									{
										_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
										num = -744940020;
										continue;
									}
									goto end_IL_0012;
								case 3:
									_axesOrigGame[num2] = axes_orig[num2];
									num = -744940018;
									continue;
								case 4:
									num2++;
									num = -744940024;
									continue;
								case 6:
									num2 = 0;
									num = -744940024;
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
									num = -744940017;
									num3 = num;
								}
								else
								{
									num = -744940023;
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
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							int num = 0;
							while (true)
							{
								int num2;
								int num3;
								if (num >= buttons_orig.Length)
								{
									num2 = 1779479337;
									num3 = num2;
								}
								else
								{
									num2 = 1779479340;
									num3 = num2;
								}
								while (true)
								{
									switch (num2 ^ 0x6A10B328)
									{
									case 2:
										num2 = 1779479340;
										continue;
									case 4:
										_buttonsOrigGame[num] = buttons_orig[num];
										num2 = 1779479339;
										continue;
									case 3:
										num++;
										num2 = 1779479336;
										continue;
									case 0:
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
				platformMap = null;
				while (true)
				{
					int num = -1004491194;
					while (true)
					{
						switch (num ^ -1004491193)
						{
						case 0:
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
						num = -1004491195;
					}
				}
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				gHStAfOjRcVafekqZWmnGSpajgm gHStAfOjRcVafekqZWmnGSpajgm2 = new gHStAfOjRcVafekqZWmnGSpajgm(-2);
				gHStAfOjRcVafekqZWmnGSpajgm2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return gHStAfOjRcVafekqZWmnGSpajgm2;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				FdTAcahXbYaPuuQVENcXTNclciBc fdTAcahXbYaPuuQVENcXTNclciBc = new FdTAcahXbYaPuuQVENcXTNclciBc(-2);
				fdTAcahXbYaPuuQVENcXTNclciBc.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return fdTAcahXbYaPuuQVENcXTNclciBc;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					goto IL_001a;
				}
				string[] array = new string[elements.axisCount];
				int num = 0;
				int num2 = 2013306790;
				goto IL_001f;
				IL_001f:
				int num3 = default(int);
				while (true)
				{
					switch (num2 ^ 0x78009FA7)
					{
					case 6:
						break;
					case 4:
						return new string[0];
					case 0:
						num++;
						num2 = 2013306790;
						continue;
					case 5:
						array[num] = identifiers[num3].name;
						num2 = 2013306791;
						continue;
					case 7:
						num2 = 2013306791;
						continue;
					case 2:
					{
						int elementIdentifier = elements.axes[num].elementIdentifier;
						num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						if (num3 >= 0)
						{
							int num4;
							if (num3 < identifiers.Length)
							{
								num2 = 2013306786;
								num4 = num2;
							}
							else
							{
								num2 = 2013306788;
								num4 = num2;
							}
							continue;
						}
						goto case 3;
					}
					case 3:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = 2013306784;
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
				goto IL_001a;
				IL_001a:
				num2 = 2013306787;
				goto IL_001f;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				string[] array = default(string[]);
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					int num = 1384026761;
					while (true)
					{
						switch (num ^ 0x527E928E)
						{
						case 6:
							break;
						case 7:
							if (identifiers.Length < buttonCount)
							{
								Logger.LogError("You have too few element identifiers!");
								return new string[0];
							}
							array = new string[buttonCount];
							num2 = 0;
							num = 1384026763;
							continue;
						case 0:
							num2++;
							num = 1384026765;
							continue;
						case 4:
						{
							int elementIdentifier = elements.buttons[num2].elementIdentifier;
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							if (num3 >= 0)
							{
								int num4;
								if (num3 >= identifiers.Length)
								{
									num = 1384026764;
									num4 = num;
								}
								else
								{
									num = 1384026767;
									num4 = num;
								}
								continue;
							}
							goto case 2;
						}
						case 2:
							Logger.LogError("Element identifier index is out of bounds!");
							num = 1384026766;
							continue;
						case 5:
							num = 1384026765;
							continue;
						case 1:
							array[num2] = identifiers[num3].name;
							num = 1384026766;
							continue;
						default:
							if (num2 >= array.Length)
							{
								return array;
							}
							goto case 4;
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
				IEnumerator<Platform_Custom.Button> enumerator2 = IterateButtons().GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						Button button = (Button)enumerator2.Current;
						if (button.elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						while (true)
						{
							IL_00c0:
							int num = 783510490;
							while (true)
							{
								switch (num ^ 0x2EB36BDB)
								{
								case 0:
									break;
								default:
									goto end_IL_00c5;
								case 1:
									goto IL_00de;
								case 2:
									goto end_IL_00c5;
								}
								goto IL_00c0;
								IL_00de:
								enumerator2.Dispose();
								num = 783510489;
								continue;
								end_IL_00c5:
								break;
							}
							break;
						}
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				while (true)
				{
					int num = -685583473;
					while (true)
					{
						switch (num ^ -685583474)
						{
						case 0:
							break;
						case 1:
							goto IL_002b;
						default:
						{
							int num2 = 0;
							using (IEnumerator<Platform_Custom.Button> enumerator = IterateButtons().GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										Button button = (Button)enumerator.Current;
										int num3 = -685583476;
										while (true)
										{
											switch (num3 ^ -685583474)
											{
											case 3:
												num3 = -685583473;
												continue;
											case 1:
												break;
											case 2:
												buttons[num2] = button.elementIdentifier;
												num2++;
												num3 = -685583474;
												continue;
											default:
												goto end_IL_0071;
											}
											break;
										}
										continue;
										end_IL_0071:
										break;
									}
								}
							}
							num2 = 0;
							IEnumerator<Platform_Custom.Axis> enumerator2 = IterateAxes().GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									while (true)
									{
										Axis axis = (Axis)enumerator2.Current;
										axes[num2] = axis.elementIdentifier;
										num2++;
										int num4 = -685583473;
										while (true)
										{
											switch (num4 ^ -685583474)
											{
											case 0:
												num4 = -685583476;
												continue;
											case 2:
												break;
											default:
												goto end_IL_00dc;
											}
											break;
										}
										continue;
										end_IL_00dc:
										break;
									}
								}
								return;
							}
							finally
							{
								if (enumerator2 != null)
								{
									while (true)
									{
										IL_010d:
										int num5 = -685583473;
										while (true)
										{
											switch (num5 ^ -685583474)
											{
											case 2:
												break;
											default:
												goto end_IL_0112;
											case 1:
												goto IL_012b;
											case 0:
												goto end_IL_0112;
											}
											goto IL_010d;
											IL_012b:
											enumerator2.Dispose();
											num5 = -685583474;
											continue;
											end_IL_0112:
											break;
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
						num = -685583476;
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
					int num = -1024280621;
					while (true)
					{
						switch (num ^ -1024280620)
						{
						case 0:
							break;
						case 7:
							if (axes_orig == null)
							{
								return null;
							}
							array = new AxisCalibrationData[axes_orig.Length];
							num2 = 0;
							num = -1024280622;
							continue;
						case 10:
							throw new NotImplementedException();
						case 4:
							if (axes_orig[num2].sourceType != 1)
							{
								int num4;
								if (axes_orig[num2].sourceType != 100)
								{
									num = -1024280618;
									num4 = num;
								}
								else
								{
									num = -1024280611;
									num4 = num;
								}
								continue;
							}
							goto case 9;
						case 3:
							array[num2] = AxisCalibrationData.Default;
							num = -1024280623;
							continue;
						case 9:
							array[num2] = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							num = -1024280619;
							continue;
						case 5:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num2++;
							num = -1024280622;
							continue;
						case 2:
						{
							int num5;
							if (axes_orig[num2].sourceType == 0)
							{
								num = -1024280617;
								num5 = num;
							}
							else
							{
								num = -1024280610;
								num5 = num;
							}
							continue;
						}
						case 1:
						{
							int num3;
							if (!Axes_orig[num2].calibrateAxis)
							{
								num = -1024280623;
								num3 = num;
							}
							else
							{
								num = -1024280612;
								num3 = num;
							}
							continue;
						}
						case 8:
							array[num2].zero = axes_orig[num2].axisZero;
							num = -1024280609;
							continue;
						case 11:
							array[num2].min = axes_orig[num2].axisMin;
							array[num2].max = axes_orig[num2].axisMax;
							num = -1024280623;
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
					int num = -2119277947;
					while (true)
					{
						switch (num ^ -2119277945)
						{
						case 6:
							num = -2119277946;
							continue;
						default:
							return;
						case 5:
							num = -2119277942;
							continue;
						case 3:
							num2 = 0;
							num = -2119277944;
							continue;
						case 9:
						{
							int num5;
							if (Axes_orig[num2].sourceType != 100)
							{
								num = -2119277945;
								num5 = num;
							}
							else
							{
								num = -2119277949;
								num5 = num;
							}
							continue;
						}
						case 14:
						{
							int num6;
							if (Axes_orig[num2].sourceType != 1)
							{
								num = -2119277938;
								num6 = num;
							}
							else
							{
								num = -2119277949;
								num6 = num;
							}
							continue;
						}
						case 8:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							num = -2119277943;
							continue;
						case 0:
						{
							int num4;
							if (Axes_orig[num2].sourceType != 0)
							{
								num = -2119277952;
								num4 = num;
							}
							else
							{
								num = -2119277939;
								num4 = num;
							}
							continue;
						}
						case 15:
							num = -2119277941;
							continue;
						case 7:
							throw new Exception();
						case 1:
							break;
						case 10:
							axisRanges[num2] = AxisRange.Full;
							num = -2119277942;
							continue;
						case 12:
						{
							int num3;
							if (num2 < Axes_orig.Length)
							{
								num = -2119277937;
								num3 = num;
							}
							else
							{
								num = -2119277940;
								num3 = num;
							}
							continue;
						}
						case 2:
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num = -2119277948;
							continue;
						case 13:
							num2++;
							num = -2119277941;
							continue;
						case 4:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -2119277950;
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
					goto IL_000b;
				}
				goto IL_003d;
				IL_000b:
				int num = -1751666216;
				goto IL_0010;
				IL_0010:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ -1751666214)
					{
					case 3:
						break;
					case 2:
						return;
					case 1:
						goto IL_003d;
					case 4:
						buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
						num2++;
						num = -1751666214;
						continue;
					case 5:
						num2 = 0;
						num = -1751666214;
						continue;
					default:
						if (num2 >= Buttons_orig.Length)
						{
							return;
						}
						goto case 4;
					}
					break;
				}
				goto IL_000b;
				IL_003d:
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				num = -1751666209;
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
				if (platform_Ouya_Base == null)
				{
					return;
				}
				while (true)
				{
					platform_Ouya_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					int num = -1547551167;
					while (true)
					{
						switch (num ^ -1547551168)
						{
						case 0:
							goto IL_0012;
						case 2:
							break;
						default:
							platform_Ouya_Base.elements = MiscTools.DeepClone(elements);
							return;
						}
						break;
						IL_0012:
						num = -1547551166;
					}
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
					goto IL_000d;
				}
				int num = default(int);
				int num2;
				if (base.hasVariants)
				{
					num = 0;
					num2 = 394763144;
					goto IL_0012;
				}
				goto IL_00aa;
				IL_0012:
				while (true)
				{
					switch (num2 ^ 0x17879B88)
					{
					case 2:
						break;
					case 1:
						return true;
					case 4:
						return true;
					case 6:
						goto IL_005b;
					case 5:
						goto IL_007a;
					case 0:
						goto IL_008b;
					default:
						goto IL_00aa;
					}
					break;
					IL_008b:
					int num3;
					if (num < variants.Length)
					{
						num2 = 394763149;
						num3 = num2;
					}
					else
					{
						num2 = 394763147;
						num3 = num2;
					}
					continue;
					IL_0050:
					num++;
					num2 = 394763144;
					continue;
					IL_005b:
					int variantIndex2;
					if (variants[num].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
					{
						variantIndex = num;
						num2 = 394763148;
						continue;
					}
					goto IL_0050;
					IL_007a:
					if (variants[num] != null)
					{
						num2 = 394763150;
						continue;
					}
					goto IL_0050;
				}
				goto IL_000d;
				IL_00aa:
				return false;
				IL_000d:
				num2 = 394763145;
				goto IL_0012;
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
				if (platform_Ouya != null)
				{
					platform_Ouya.variants = MiscTools.DeepClone(variants);
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
						goto IL_0008;
					}
					goto IL_0056;
					IL_0008:
					int num = -115203174;
					goto IL_000d;
					IL_000d:
					int num2 = default(int);
					string text = default(string);
					while (true)
					{
						switch (num ^ -115203173)
						{
						case 4:
							break;
						case 1:
							goto IL_003d;
						case 3:
							goto IL_004c;
						case 2:
							return false;
						case 0:
							goto IL_008a;
						case 5:
							goto IL_00a9;
						case 7:
							goto IL_00c4;
						default:
							goto IL_00ec;
						}
						break;
						IL_00c4:
						string searchFor = productName[num2];
						if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
						{
							return true;
						}
						num2++;
						num = -115203173;
						continue;
						IL_004c:
						if (isAllowed)
						{
							return true;
						}
						goto IL_0056;
						IL_003d:
						if (hasData)
						{
							num = -115203176;
							continue;
						}
						goto IL_0056;
						IL_008a:
						int num3;
						if (num2 >= productName.Length)
						{
							num = -115203171;
							num3 = num;
						}
						else
						{
							num = -115203172;
							num3 = num;
						}
					}
					goto IL_0008;
					IL_0056:
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						num = -115203175;
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
							goto IL_00a9;
						}
						text = string.Empty;
						num = -115203170;
					}
					goto IL_000d;
					IL_00ec:
					return false;
					IL_00a9:
					text = text.Trim();
					if (productName != null)
					{
						num2 = 0;
						num = -115203173;
						goto IL_000d;
					}
					goto IL_00ec;
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
						switch (-45479231 ^ -45479232)
						{
						case 0:
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
					int num2 = default(int);
					while (true)
					{
						IL_004c:
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = -629613147;
							goto IL_0009;
						}
						goto IL_002a;
						IL_0009:
						while (true)
						{
							switch (num3 ^ -629613151)
							{
							case 2:
								num3 = -629613152;
								continue;
							case 1:
								break;
							case 0:
								goto IL_004c;
							case 3:
								goto IL_005e;
							default:
								if (num2 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								goto IL_005e;
							}
							break;
							IL_005e:
							if (buttons[num2].elementIdentifier == elementIdentifier.id)
							{
								return ControllerElementType.Button;
							}
							num2++;
							num3 = -629613147;
						}
						goto IL_002a;
						IL_002a:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							break;
						}
						num++;
						num3 = -629613151;
						goto IL_0009;
					}
					return ControllerElementType.Axis;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					int sourceType = default(int);
					while (true)
					{
						int num2;
						int num3;
						if (num < axisCount)
						{
							num2 = -1965484180;
							num3 = num2;
						}
						else
						{
							num2 = -1965484185;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -1965484179)
							{
							case 2:
								num2 = -1965484180;
								continue;
							case 4:
								return true;
							case 7:
								num++;
								num2 = -1965484184;
								continue;
							case 3:
								if (sourceType == 100)
								{
									num2 = -1965484179;
									continue;
								}
								throw new NotImplementedException();
							case 1:
								if (axes[num].elementIdentifier != elementIdentifier.id)
								{
									goto case 7;
								}
								sourceType = axes[num].sourceType;
								switch (sourceType)
								{
								case 0:
									axisRange = AxisRange.Positive;
									num2 = -1965484181;
									continue;
								default:
									num2 = -1965484178;
									continue;
								case 1:
									break;
								}
								goto case 0;
							case 0:
								axisRange = axes[num].sourceAxisRange;
								num2 = -1965484187;
								continue;
							case 8:
							{
								int num4;
								if (axes[num].invert)
								{
									num2 = -1965484188;
									num4 = num2;
								}
								else
								{
									num2 = -1965484183;
									num4 = num2;
								}
								continue;
							}
							case 5:
								break;
							case 6:
								return true;
							case 9:
								axisRange = InputTools.InvertAxisRange(axisRange);
								num2 = -1965484183;
								continue;
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
					if (elements == null)
					{
						return;
					}
					while (true)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						int num = 982213125;
						while (true)
						{
							switch (num ^ 0x3A8B6205)
							{
							case 2:
								goto IL_0012;
							case 1:
								break;
							default:
								elements.buttons = ArrayTools.DeepClone(buttons);
								return;
							}
							break;
							IL_0012:
							num = 982213124;
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
						int num = -1296140957;
						while (true)
						{
							switch (num ^ -1296140958)
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
							num = -1296140960;
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

			private sealed class RPlGAZaXeEjGlxbbggLsYaUJbox : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_XboxOne_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int DwXtCqueXqDbqwohkEsBEgumJqA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
					{
						goto IL_0012;
					}
					goto IL_0052;
					IL_0012:
					int num = -1431859737;
					goto IL_0017;
					IL_0017:
					RPlGAZaXeEjGlxbbggLsYaUJbox rPlGAZaXeEjGlxbbggLsYaUJbox = default(RPlGAZaXeEjGlxbbggLsYaUJbox);
					while (true)
					{
						switch (num ^ -1431859738)
						{
						case 4:
							break;
						case 1:
							if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
							{
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
								rPlGAZaXeEjGlxbbggLsYaUJbox = this;
								num = -1431859739;
								continue;
							}
							goto IL_0052;
						case 0:
							goto IL_0052;
						case 3:
							num = -1431859740;
							continue;
						default:
							return rPlGAZaXeEjGlxbbggLsYaUJbox;
						}
						break;
					}
					goto IL_0012;
					IL_0052:
					rPlGAZaXeEjGlxbbggLsYaUJbox = new RPlGAZaXeEjGlxbbggLsYaUJbox(0);
					rPlGAZaXeEjGlxbbggLsYaUJbox.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					num = -1431859740;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 1:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = 1320538953;
						goto IL_001f;
					case 0:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements == null || iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes == null)
							{
								break;
							}
							DwXtCqueXqDbqwohkEsBEgumJqA = 0;
							num = 1320538952;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x4EB5D34B)
							{
							case 5:
								num = 1320538959;
								continue;
							case 2:
								DwXtCqueXqDbqwohkEsBEgumJqA++;
								num = 1320538952;
								continue;
							case 6:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 1:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes[DwXtCqueXqDbqwohkEsBEgumJqA];
								num = 1320538957;
								continue;
							case 4:
								break;
							case 3:
								goto IL_00d2;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00d2:
							int num2;
							if (DwXtCqueXqDbqwohkEsBEgumJqA < iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes.Length)
							{
								num = 1320538954;
								num2 = num;
							}
							else
							{
								num = 1320538955;
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
				public RPlGAZaXeEjGlxbbggLsYaUJbox(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class ZzypAtYiLEhqudbIipRXtfdyvLVQ : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_XboxOne_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int oRRbxTDksByMoALSRXEhTAjeQgR;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						goto IL_001c;
					}
					goto IL_0055;
					IL_0055:
					ZzypAtYiLEhqudbIipRXtfdyvLVQ zzypAtYiLEhqudbIipRXtfdyvLVQ = new ZzypAtYiLEhqudbIipRXtfdyvLVQ(0);
					int num = 1748379618;
					goto IL_0021;
					IL_001c:
					num = 1748379616;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ 0x683627E1)
						{
						case 0:
							break;
						case 3:
							zzypAtYiLEhqudbIipRXtfdyvLVQ.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
							num = 1748379619;
							continue;
						case 4:
							goto IL_0055;
						case 1:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							zzypAtYiLEhqudbIipRXtfdyvLVQ = this;
							num = 1748379619;
							continue;
						default:
							return zzypAtYiLEhqudbIipRXtfdyvLVQ;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 0:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						int num2;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements != null)
						{
							num = -1327772090;
							num2 = num;
						}
						else
						{
							num = -1327772093;
							num2 = num;
						}
						goto IL_001f;
					}
					case 1:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							oRRbxTDksByMoALSRXEhTAjeQgR++;
							num = -1327772094;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -1327772093)
							{
							case 2:
								num = -1327772089;
								continue;
							case 4:
								break;
							case 3:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons[oRRbxTDksByMoALSRXEhTAjeQgR];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 5:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons != null)
								{
									oRRbxTDksByMoALSRXEhTAjeQgR = 0;
									num = -1327772094;
									continue;
								}
								goto end_IL_0008;
							case 1:
								goto IL_00d4;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00d4:
							int num3;
							if (oRRbxTDksByMoALSRXEhTAjeQgR >= iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons.Length)
							{
								num = -1327772093;
								num3 = num;
							}
							else
							{
								num = -1327772096;
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
				public ZzypAtYiLEhqudbIipRXtfdyvLVQ(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
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
					return InputPlatform.GdzkbPzfoHvypKbmmdwEXhUPKcR;
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
							int num2 = default(int);
							while (true)
							{
								int num = -2145816971;
								while (true)
								{
									switch (num ^ -2145816969)
									{
									case 4:
										break;
									case 2:
										num2 = 0;
										num = -2145816970;
										continue;
									case 3:
										_axesOrigGame[num2] = axes_orig[num2];
										num2++;
										num = -2145816970;
										continue;
									case 1:
										goto IL_0065;
									default:
										goto end_IL_0020;
									}
									break;
									IL_0065:
									int num3;
									if (num2 >= axes_orig.Length)
									{
										num = -2145816969;
										num3 = num;
									}
									else
									{
										num = -2145816972;
										num3 = num;
									}
								}
								continue;
								end_IL_0020:
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
							int num = 2096947215;
							while (true)
							{
								switch (num ^ 0x7CFCE009)
								{
								case 2:
									break;
								case 3:
									num = 2096947213;
									continue;
								case 0:
									num2 = 0;
									num = 2096947210;
									continue;
								case 4:
									goto IL_0050;
								case 5:
									_buttonsOrigGame[num2] = buttons_orig[num2];
									num2++;
									num = 2096947213;
									continue;
								case 6:
									if (buttons_orig != null)
									{
										_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
										num = 2096947209;
										continue;
									}
									goto end_IL_0012;
								default:
									goto end_IL_0012;
								}
								break;
								IL_0050:
								int num3;
								if (num2 >= buttons_orig.Length)
								{
									num = 2096947208;
									num3 = num;
								}
								else
								{
									num = 2096947212;
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
					int num = 1838636083;
					while (true)
					{
						switch (num ^ 0x6D975C37)
						{
						case 2:
							break;
						case 4:
							platformMap = null;
							num = 1838636087;
							continue;
						case 0:
							if (matchingCriteria != null)
							{
								num = 1838636084;
								continue;
							}
							goto IL_005f;
						case 3:
							if (matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
							{
								platformMap = this;
								num = 1838636086;
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
				RPlGAZaXeEjGlxbbggLsYaUJbox rPlGAZaXeEjGlxbbggLsYaUJbox = new RPlGAZaXeEjGlxbbggLsYaUJbox(-2);
				rPlGAZaXeEjGlxbbggLsYaUJbox.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return rPlGAZaXeEjGlxbbggLsYaUJbox;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				ZzypAtYiLEhqudbIipRXtfdyvLVQ zzypAtYiLEhqudbIipRXtfdyvLVQ = new ZzypAtYiLEhqudbIipRXtfdyvLVQ(-2);
				zzypAtYiLEhqudbIipRXtfdyvLVQ.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return zzypAtYiLEhqudbIipRXtfdyvLVQ;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				int elementIdentifier = default(int);
				int num4 = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = -1962596985;
					while (true)
					{
						switch (num ^ -1962596977)
						{
						case 3:
							break;
						case 6:
							Logger.LogError("Element identifier index is out of bounds!");
							num = -1962596979;
							continue;
						case 7:
							elementIdentifier = elements.axes[num4].elementIdentifier;
							num = -1962596981;
							continue;
						case 8:
							num4 = 0;
							num = -1962596978;
							continue;
						case 1:
						{
							int num5;
							if (num4 < array.Length)
							{
								num = -1962596984;
								num5 = num;
							}
							else
							{
								num = -1962596977;
								num5 = num;
							}
							continue;
						}
						case 2:
							num = -1962596982;
							continue;
						case 9:
							array[num4] = identifiers[num2].name;
							num = -1962596982;
							continue;
						case 5:
							num4++;
							num = -1962596978;
							continue;
						case 4:
							num2 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							if (num2 >= 0)
							{
								int num3;
								if (num2 >= identifiers.Length)
								{
									num = -1962596983;
									num3 = num;
								}
								else
								{
									num = -1962596986;
									num3 = num;
								}
								continue;
							}
							goto case 6;
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
						int num3;
						int num4;
						if (num2 >= 0)
						{
							num3 = -476774464;
							num4 = num3;
						}
						else
						{
							num3 = -476774462;
							num4 = num3;
						}
						while (true)
						{
							switch (num3 ^ -476774461)
							{
							case 6:
								num3 = -476774457;
								continue;
							case 1:
								Logger.LogError("Element identifier index is out of bounds!");
								num3 = -476774463;
								continue;
							case 3:
								break;
							case 4:
								goto end_IL_0036;
							case 2:
								num++;
								num3 = -476774461;
								continue;
							case 5:
								array[num] = identifiers[num2].name;
								num3 = -476774463;
								continue;
							default:
								goto end_IL_008b;
							}
							int num5;
							if (num2 >= identifiers.Length)
							{
								num3 = -476774462;
								num5 = num3;
							}
							else
							{
								num3 = -476774458;
								num5 = num3;
							}
							continue;
							end_IL_0036:
							break;
						}
						continue;
						end_IL_008b:
						break;
					}
				}
				return array;
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
							int num = -462249460;
							while (true)
							{
								switch (num ^ -462249460)
								{
								case 3:
									num = -462249459;
									continue;
								case 1:
									break;
								default:
									goto end_IL_0030;
								case 0:
									goto IL_00e0;
								}
								break;
							}
							continue;
							end_IL_0030:
							break;
						}
					}
				}
				using (IEnumerator<Platform_Custom.Button> enumerator2 = IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Button button = (Button)enumerator2.Current;
							if (button.elementIdentifier != elementIdentifierId)
							{
								break;
							}
							result = true;
							int num2 = -462249458;
							while (true)
							{
								switch (num2 ^ -462249460)
								{
								case 0:
									num2 = -462249457;
									continue;
								case 3:
									break;
								default:
									goto end_IL_009f;
								case 2:
									goto IL_00e0;
								}
								break;
							}
							continue;
							end_IL_009f:
							break;
						}
					}
				}
				return false;
				IL_00e0:
				return result;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				IEnumerator<Platform_Custom.Button> enumerator = IterateButtons().GetEnumerator();
				try
				{
					while (true)
					{
						IL_0050:
						int num2;
						int num3;
						if (!enumerator.MoveNext())
						{
							num2 = -1570721196;
							num3 = num2;
						}
						else
						{
							num2 = -1570721194;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -1570721193)
							{
							case 4:
								num2 = -1570721194;
								continue;
							default:
								goto end_IL_002f;
							case 2:
								break;
							case 0:
								num++;
								num2 = -1570721195;
								continue;
							case 1:
							{
								Button button = (Button)enumerator.Current;
								buttons[num] = button.elementIdentifier;
								num2 = -1570721193;
								continue;
							}
							case 3:
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
				finally
				{
					if (enumerator != null)
					{
						while (true)
						{
							IL_0096:
							int num4 = -1570721195;
							while (true)
							{
								switch (num4 ^ -1570721193)
								{
								case 0:
									break;
								default:
									goto end_IL_009b;
								case 2:
									goto IL_00b4;
								case 1:
									goto end_IL_009b;
								}
								goto IL_0096;
								IL_00b4:
								enumerator.Dispose();
								num4 = -1570721194;
								continue;
								end_IL_009b:
								break;
							}
							break;
						}
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
							int num5 = -1570721194;
							while (true)
							{
								switch (num5 ^ -1570721193)
								{
								case 0:
									num5 = -1570721195;
									continue;
								case 2:
									break;
								default:
									goto end_IL_00f1;
								}
								break;
							}
							continue;
							end_IL_00f1:
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
							IL_0122:
							int num6 = -1570721194;
							while (true)
							{
								switch (num6 ^ -1570721193)
								{
								case 2:
									break;
								default:
									goto end_IL_0127;
								case 1:
									goto IL_0140;
								case 0:
									goto end_IL_0127;
								}
								goto IL_0122;
								IL_0140:
								enumerator2.Dispose();
								num6 = -1570721193;
								continue;
								end_IL_0127:
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
					int num = -1652139193;
					while (true)
					{
						switch (num ^ -1652139195)
						{
						case 0:
							break;
						case 9:
							num = -1652139196;
							continue;
						case 6:
							num = -1652139199;
							continue;
						case 3:
							num = -1652139196;
							continue;
						case 10:
							if (axes_orig[num2].sourceType == 0)
							{
								array[num2] = AxisCalibrationData.Default;
								num = -1652139194;
								continue;
							}
							goto case 7;
						case 1:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num2++;
							num = -1652139199;
							continue;
						case 2:
							if (axes_orig == null)
							{
								return null;
							}
							array = new AxisCalibrationData[axes_orig.Length];
							num2 = 0;
							num = -1652139197;
							continue;
						case 8:
							array[num2] = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							if (Axes_orig[num2].calibrateAxis)
							{
								array[num2].zero = axes_orig[num2].axisZero;
								num = -1652139200;
								continue;
							}
							goto case 1;
						case 5:
							array[num2].min = axes_orig[num2].axisMin;
							array[num2].max = axes_orig[num2].axisMax;
							num = -1652139188;
							continue;
						case 12:
							if (axes_orig[num2].sourceType != 1)
							{
								int num4;
								if (axes_orig[num2].sourceType == 100)
								{
									num = -1652139187;
									num4 = num;
								}
								else
								{
									num = -1652139185;
									num4 = num;
								}
								continue;
							}
							goto case 8;
						case 7:
							throw new NotImplementedException();
						case 4:
						{
							int num3;
							if (num2 >= axes_orig.Length)
							{
								num = -1652139186;
								num3 = num;
							}
							else
							{
								num = -1652139191;
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
					return;
				}
				while (true)
				{
					axisRanges = new AxisRange[Axes_orig.Length];
					axisInfos = new HardwareAxisInfo[Axes_orig.Length];
					int num = 0;
					int num2 = -881630961;
					while (true)
					{
						switch (num2 ^ -881630965)
						{
						case 7:
							num2 = -881630962;
							continue;
						case 5:
							break;
						case 3:
							num++;
							num2 = -881630961;
							continue;
						case 6:
							throw new Exception();
						case 0:
							if (Axes_orig[num].sourceType == 0)
							{
								axisRanges[num] = AxisRange.Full;
								num2 = -881630968;
								continue;
							}
							goto case 6;
						case 2:
							axisRanges[num] = Axes_orig[num].sourceAxisRange;
							num2 = -881630968;
							continue;
						case 1:
							axisInfos[num] = MiscTools.DeepClone(Axes_orig[num].axisInfo, true);
							if (Axes_orig[num].sourceType != 1)
							{
								int num3;
								if (Axes_orig[num].sourceType == 100)
								{
									num2 = -881630967;
									num3 = num2;
								}
								else
								{
									num2 = -881630965;
									num3 = num2;
								}
								continue;
							}
							goto case 2;
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
					int num2 = 1135645090;
					while (true)
					{
						switch (num2 ^ 0x43B091A2)
						{
						case 4:
							num2 = 1135645089;
							continue;
						case 2:
							num++;
							num2 = 1135645090;
							continue;
						case 1:
							buttonInfos[num] = MiscTools.DeepClone(Buttons_orig[num].buttonInfo, true);
							num2 = 1135645088;
							continue;
						case 3:
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
				Platform_XboxOne_Base platform_XboxOne_Base = new Platform_XboxOne_Base();
				CopyVars(platform_XboxOne_Base);
				return platform_XboxOne_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_XboxOne_Base platform_XboxOne_Base = destination as Platform_XboxOne_Base;
				if (platform_XboxOne_Base != null)
				{
					platform_XboxOne_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_XboxOne_Base.elements = MiscTools.DeepClone(elements);
				}
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
						int num = 2115416931;
						while (true)
						{
							switch (num ^ 0x7E16B360)
							{
							case 0:
								break;
							case 3:
								num2 = 0;
								num = 2115416930;
								continue;
							case 1:
								goto IL_0046;
							case 2:
								goto IL_0075;
							default:
								goto end_IL_0017;
							}
							break;
							IL_0075:
							int num3;
							if (num2 < variants.Length)
							{
								num = 2115416929;
								num3 = num;
							}
							else
							{
								num = 2115416932;
								num3 = num;
							}
							continue;
							IL_0046:
							int variantIndex2;
							if (variants[num2] != null && variants[num2].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
							{
								variantIndex = num2;
								return true;
							}
							num2++;
							num = 2115416930;
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
				if (platform_XboxOne != null)
				{
					platform_XboxOne.variants = MiscTools.DeepClone(variants);
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
							goto IL_0008;
						}
						int num;
						if (productName != null && productName.Length > 0)
						{
							num = 664142965;
							goto IL_000d;
						}
						return false;
						IL_000d:
						switch (num ^ 0x27960474)
						{
						case 0:
							break;
						case 2:
							return true;
						default:
							return true;
						}
						goto IL_0008;
						IL_0008:
						num = 664142966;
						goto IL_000d;
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
					goto IL_004f;
					IL_00ec:
					return false;
					IL_0010:
					int num = 2121820497;
					goto IL_0015;
					IL_0015:
					int num2 = default(int);
					string text = default(string);
					while (true)
					{
						switch (num ^ 0x7E786952)
						{
						case 0:
							break;
						case 3:
							goto IL_0045;
						case 7:
							goto IL_0060;
						case 6:
							return true;
						case 2:
							return false;
						case 1:
							goto IL_00af;
						case 5:
							goto IL_00d1;
						default:
							goto IL_00ec;
						}
						break;
						IL_00af:
						string searchFor = productName[num2];
						if (!MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
						{
							num2++;
							num = 2121820501;
						}
						else
						{
							num = 2121820500;
						}
						continue;
						IL_0060:
						int num3;
						if (num2 < productName.Length)
						{
							num = 2121820499;
							num3 = num;
						}
						else
						{
							num = 2121820502;
							num3 = num;
						}
					}
					goto IL_0010;
					IL_0045:
					if (isAllowed)
					{
						return true;
					}
					goto IL_004f;
					IL_00d1:
					text = text.Trim();
					if (productName != null)
					{
						num2 = 0;
						num = 2121820501;
						goto IL_0015;
					}
					goto IL_00ec;
					IL_004f:
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						num = 2121820496;
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
							goto IL_00d1;
						}
						text = string.Empty;
						num = 2121820503;
					}
					goto IL_0015;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					while (true)
					{
						int num = -1994523767;
						while (true)
						{
							switch (num ^ -1994523768)
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
							num = -1994523768;
						}
					}
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					MatchingCriteria matchingCriteria = destination as MatchingCriteria;
					if (matchingCriteria == null)
					{
						goto IL_0011;
					}
					goto IL_003b;
					IL_0011:
					int num = 1866543555;
					goto IL_0016;
					IL_0016:
					switch (num ^ 0x6F4131C0)
					{
					case 0:
						break;
					case 3:
						return;
					case 2:
						goto IL_003b;
					default:
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						return;
					}
					goto IL_0011;
					IL_003b:
					matchingCriteria.productName_useRegex = productName_useRegex;
					num = 1866543553;
					goto IL_0016;
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
					int num4 = default(int);
					while (true)
					{
						int num2;
						int num3;
						if (num >= axisCount)
						{
							num2 = 301039177;
							num3 = num2;
						}
						else
						{
							num2 = 301039182;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x11F17E4C)
							{
							case 0:
								num2 = 301039182;
								continue;
							case 2:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = 301039181;
								continue;
							case 1:
								break;
							case 3:
								if (buttons[num4].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num4++;
								num2 = 301039176;
								continue;
							case 5:
								num4 = 0;
								num2 = 301039176;
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
					while (true)
					{
						int num2 = -514783214;
						while (true)
						{
							switch (num2 ^ -514783216)
							{
							case 6:
								break;
							case 3:
								return true;
							case 5:
								num++;
								num2 = -514783212;
								continue;
							case 8:
								return true;
							case 1:
								if (axes[num].elementIdentifier != elementIdentifier.id)
								{
									goto case 5;
								}
								switch (axes[num].sourceType)
								{
								default:
									throw new NotImplementedException();
								case 0:
									axisRange = AxisRange.Positive;
									num2 = -514783213;
									continue;
								case 100:
									num2 = -514783216;
									continue;
								case 1:
									break;
								}
								goto case 0;
							case 7:
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -514783208;
									continue;
								}
								goto case 8;
							case 2:
								num2 = -514783212;
								continue;
							case 0:
								axisRange = axes[num].sourceAxisRange;
								num2 = -514783209;
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
					Elements elements = default(Elements);
					while (true)
					{
						int num = -363610304;
						while (true)
						{
							switch (num ^ -363610303)
							{
							case 2:
								break;
							case 1:
							{
								elements = destination as Elements;
								int num2;
								if (elements != null)
								{
									num = -363610302;
									num2 = num;
								}
								else
								{
									num = -363610303;
									num2 = num;
								}
								continue;
							}
							case 0:
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

			private sealed class VyWjZCouSKccSxKkYOyDlNyWssL : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_PS4_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int cXWQvACAFWfCmKJaeyBshmwHinFC;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						goto IL_001c;
					}
					goto IL_0065;
					IL_0065:
					VyWjZCouSKccSxKkYOyDlNyWssL vyWjZCouSKccSxKkYOyDlNyWssL = new VyWjZCouSKccSxKkYOyDlNyWssL(0);
					int num = -808784983;
					goto IL_0021;
					IL_001c:
					num = -808784982;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ -808784984)
						{
						case 0:
							break;
						case 2:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							vyWjZCouSKccSxKkYOyDlNyWssL = this;
							num = -808784980;
							continue;
						case 1:
							vyWjZCouSKccSxKkYOyDlNyWssL.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
							num = -808784980;
							continue;
						case 3:
							goto IL_0065;
						default:
							return vyWjZCouSKccSxKkYOyDlNyWssL;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 1:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						cXWQvACAFWfCmKJaeyBshmwHinFC++;
						num = -831940349;
						goto IL_001f;
					case 0:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements == null || iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes == null)
							{
								break;
							}
							cXWQvACAFWfCmKJaeyBshmwHinFC = 0;
							num = -831940349;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -831940350)
							{
							case 2:
								num = -831940346;
								continue;
							case 1:
								break;
							case 5:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes[cXWQvACAFWfCmKJaeyBshmwHinFC];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = -831940350;
								continue;
							case 0:
								return true;
							case 4:
								goto end_IL_001f;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (cXWQvACAFWfCmKJaeyBshmwHinFC >= iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes.Length)
							{
								num = -831940351;
								num2 = num;
							}
							else
							{
								num = -831940345;
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
				public VyWjZCouSKccSxKkYOyDlNyWssL(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class FWEuWQxNbYBnKNUYqlNgiflSzaM : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_PS4_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int AosEGSFqCnQkNVIAGKShejqbUUky;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						goto IL_001c;
					}
					goto IL_004e;
					IL_004e:
					FWEuWQxNbYBnKNUYqlNgiflSzaM fWEuWQxNbYBnKNUYqlNgiflSzaM = new FWEuWQxNbYBnKNUYqlNgiflSzaM(0);
					fWEuWQxNbYBnKNUYqlNgiflSzaM.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					int num = 1533050272;
					goto IL_0021;
					IL_001c:
					num = 1533050273;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ 0x5B607DA0)
						{
						case 3:
							break;
						case 1:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							fWEuWQxNbYBnKNUYqlNgiflSzaM = this;
							num = 1533050272;
							continue;
						case 2:
							goto IL_004e;
						default:
							return fWEuWQxNbYBnKNUYqlNgiflSzaM;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					default:
						num = 1764562650;
						goto IL_001a;
					case 1:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						AosEGSFqCnQkNVIAGKShejqbUUky++;
						num = 1764562651;
						goto IL_001a;
					case 0:
						goto IL_00c4;
						IL_001a:
						while (true)
						{
							switch (num ^ 0x692D16D8)
							{
							case 5:
								break;
							case 1:
								return true;
							case 3:
								goto IL_0064;
							case 2:
								num = 1764562652;
								continue;
							case 0:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons[AosEGSFqCnQkNVIAGKShejqbUUky];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = 1764562649;
								continue;
							case 6:
								goto IL_00c4;
							default:
								goto end_IL_0008;
							}
							break;
							IL_0064:
							int num2;
							if (AosEGSFqCnQkNVIAGKShejqbUUky >= iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons.Length)
							{
								num = 1764562652;
								num2 = num;
							}
							else
							{
								num = 1764562648;
								num2 = num;
							}
						}
						goto default;
						IL_00c4:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements == null || iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons == null)
						{
							break;
						}
						AosEGSFqCnQkNVIAGKShejqbUUky = 0;
						num = 1764562651;
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
				public FWEuWQxNbYBnKNUYqlNgiflSzaM(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
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
					return InputPlatform.DtbPZmFOLnHQmXPWMCnIdwEBAah;
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
							int num = 1953385653;
							while (true)
							{
								switch (num ^ 0x746E4CB0)
								{
								case 4:
									break;
								case 0:
									_axesOrigGame[num2] = axes_orig[num2];
									num2++;
									num = 1953385649;
									continue;
								case 1:
									goto IL_004f;
								case 6:
									_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
									num2 = 0;
									num = 1953385651;
									continue;
								case 5:
									goto IL_007d;
								case 3:
									num = 1953385649;
									continue;
								default:
									goto end_IL_000b;
								}
								break;
								IL_007d:
								axes_orig = Axes_orig;
								int num3;
								if (axes_orig == null)
								{
									num = 1953385650;
									num3 = num;
								}
								else
								{
									num = 1953385654;
									num3 = num;
								}
								continue;
								IL_004f:
								int num4;
								if (num2 < axes_orig.Length)
								{
									num = 1953385648;
									num4 = num;
								}
								else
								{
									num = 1953385650;
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
						Button[] buttons_orig = default(Button[]);
						int num2 = default(int);
						while (true)
						{
							int num = -1636929275;
							while (true)
							{
								switch (num ^ -1636929276)
								{
								case 5:
									break;
								case 1:
									buttons_orig = Buttons_orig;
									num = -1636929274;
									continue;
								case 2:
									goto IL_0047;
								case 4:
									_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
									num2 = 0;
									num = -1636929273;
									continue;
								case 6:
									_buttonsOrigGame[num2] = buttons_orig[num2];
									num2++;
									num = -1636929273;
									continue;
								case 3:
									goto IL_0088;
								default:
									goto end_IL_000b;
								}
								break;
								IL_0088:
								int num3;
								if (num2 >= buttons_orig.Length)
								{
									num = -1636929276;
									num3 = num;
								}
								else
								{
									num = -1636929278;
									num3 = num;
								}
								continue;
								IL_0047:
								int num4;
								if (buttons_orig != null)
								{
									num = -1636929280;
									num4 = num;
								}
								else
								{
									num = -1636929276;
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
				VyWjZCouSKccSxKkYOyDlNyWssL vyWjZCouSKccSxKkYOyDlNyWssL = new VyWjZCouSKccSxKkYOyDlNyWssL(-2);
				vyWjZCouSKccSxKkYOyDlNyWssL.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return vyWjZCouSKccSxKkYOyDlNyWssL;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				FWEuWQxNbYBnKNUYqlNgiflSzaM fWEuWQxNbYBnKNUYqlNgiflSzaM = new FWEuWQxNbYBnKNUYqlNgiflSzaM(-2);
				fWEuWQxNbYBnKNUYqlNgiflSzaM.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return fWEuWQxNbYBnKNUYqlNgiflSzaM;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					goto IL_0010;
				}
				string[] array = new string[elements.axisCount];
				int num = -1718146524;
				goto IL_0015;
				IL_0015:
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					switch (num ^ -1718146525)
					{
					case 0:
						break;
					case 5:
						num2++;
						num = -1718146528;
						continue;
					case 7:
						num2 = 0;
						num = -1718146517;
						continue;
					case 6:
						return new string[0];
					case 4:
						num = -1718146522;
						continue;
					case 9:
						array[num2] = identifiers[num3].name;
						num = -1718146522;
						continue;
					case 2:
						Logger.LogError("You have too few element identifiers!");
						num = -1718146523;
						continue;
					case 8:
						num = -1718146528;
						continue;
					case 1:
						Logger.LogError("Element identifier index is out of bounds!");
						num = -1718146521;
						continue;
					case 10:
					{
						int elementIdentifier = elements.axes[num2].elementIdentifier;
						num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						if (num3 >= 0)
						{
							int num4;
							if (num3 >= identifiers.Length)
							{
								num = -1718146526;
								num4 = num;
							}
							else
							{
								num = -1718146518;
								num4 = num;
							}
							continue;
						}
						goto case 1;
					}
					default:
						if (num2 >= array.Length)
						{
							return array;
						}
						goto case 10;
					}
					break;
				}
				goto IL_0010;
				IL_0010:
				num = -1718146527;
				goto IL_0015;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				string[] array = default(string[]);
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					int num = 1277461452;
					while (true)
					{
						switch (num ^ 0x4C2483CD)
						{
						case 8:
							break;
						case 1:
							if (identifiers.Length < buttonCount)
							{
								Logger.LogError("You have too few element identifiers!");
								return new string[0];
							}
							array = new string[buttonCount];
							num = 1277461449;
							continue;
						case 0:
							array[num2] = identifiers[num3].name;
							num = 1277461454;
							continue;
						case 6:
						{
							int elementIdentifier = elements.buttons[num2].elementIdentifier;
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							if (num3 >= 0)
							{
								int num4;
								if (num3 >= identifiers.Length)
								{
									num = 1277461448;
									num4 = num;
								}
								else
								{
									num = 1277461453;
									num4 = num;
								}
								continue;
							}
							goto case 5;
						}
						case 4:
							num2 = 0;
							num = 1277461450;
							continue;
						case 3:
							num2++;
							num = 1277461455;
							continue;
						case 7:
							num = 1277461455;
							continue;
						case 5:
							Logger.LogError("Element identifier index is out of bounds!");
							num = 1277461454;
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

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				IEnumerator<Platform_Custom.Axis> enumerator = IterateAxes().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator.Current;
							int num = 1674815114;
							while (true)
							{
								switch (num ^ 0x63D3A689)
								{
								case 0:
									num = 1674815115;
									continue;
								case 2:
									break;
								case 1:
									return true;
								case 3:
									goto IL_0055;
								default:
									goto end_IL_0034;
								}
								break;
								IL_0055:
								int num2;
								if (axis.elementIdentifier == elementIdentifierId)
								{
									num = 1674815112;
									num2 = num;
								}
								else
								{
									num = 1674815117;
									num2 = num;
								}
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
							IL_007c:
							int num3 = 1674815115;
							while (true)
							{
								switch (num3 ^ 0x63D3A689)
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
								num3 = 1674815112;
								continue;
								end_IL_0081:
								break;
							}
							break;
						}
					}
				}
				using (IEnumerator<Platform_Custom.Button> enumerator2 = IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Button button = (Button)enumerator2.Current;
							int num4 = 1674815112;
							while (true)
							{
								switch (num4 ^ 0x63D3A689)
								{
								case 3:
									num4 = 1674815115;
									continue;
								case 2:
									break;
								case 1:
									if (button.elementIdentifier == elementIdentifierId)
									{
										return true;
									}
									goto end_IL_00d9;
								default:
									goto end_IL_00d9;
								}
								break;
							}
							continue;
							end_IL_00d9:
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
				using (IEnumerator<Platform_Custom.Button> enumerator = IterateButtons().GetEnumerator())
				{
					while (true)
					{
						IL_0078:
						int num2;
						int num3;
						if (!enumerator.MoveNext())
						{
							num2 = -64533378;
							num3 = num2;
						}
						else
						{
							num2 = -64533379;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -64533378)
							{
							case 4:
								num2 = -64533379;
								continue;
							default:
								goto end_IL_002f;
							case 3:
							{
								Button button = (Button)enumerator.Current;
								buttons[num] = button.elementIdentifier;
								num2 = -64533380;
								continue;
							}
							case 2:
								num++;
								num2 = -64533377;
								continue;
							case 1:
								break;
							case 0:
								goto end_IL_002f;
							}
							goto IL_0078;
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
							int num4 = -64533379;
							while (true)
							{
								switch (num4 ^ -64533378)
								{
								case 2:
									num4 = -64533377;
									continue;
								case 1:
									break;
								case 3:
									axes[num] = axis.elementIdentifier;
									num++;
									num4 = -64533378;
									continue;
								default:
									goto end_IL_00d0;
								}
								break;
							}
							continue;
							end_IL_00d0:
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
							IL_0108:
							int num5 = -64533377;
							while (true)
							{
								switch (num5 ^ -64533378)
								{
								case 0:
									break;
								default:
									goto end_IL_010d;
								case 1:
									goto IL_0126;
								case 2:
									goto end_IL_010d;
								}
								goto IL_0108;
								IL_0126:
								enumerator2.Dispose();
								num5 = -64533380;
								continue;
								end_IL_010d:
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
				int num = 0;
				while (num < axes_orig.Length)
				{
					while (true)
					{
						IL_0147:
						int num2;
						if (axes_orig[num].sourceType != 1)
						{
							int num3;
							if (axes_orig[num].sourceType == 100)
							{
								num2 = -128745683;
								num3 = num2;
							}
							else
							{
								num2 = -128745682;
								num3 = num2;
							}
							goto IL_0021;
						}
						goto IL_00fa;
						IL_0021:
						while (true)
						{
							switch (num2 ^ -128745681)
							{
							case 4:
								num2 = -128745688;
								continue;
							case 0:
								array[num].invert = axes_orig[num].invert;
								array[num].deadZone = axes_orig[num].axisDeadZone;
								if (Axes_orig[num].calibrateAxis)
								{
									array[num].zero = axes_orig[num].axisZero;
									num2 = -128745690;
									continue;
								}
								goto case 8;
							case 1:
								break;
							case 6:
								throw new NotImplementedException();
							case 5:
								array[num] = AxisCalibrationData.Default;
								num2 = -128745689;
								continue;
							case 2:
								goto end_IL_0021;
							case 9:
								array[num].min = axes_orig[num].axisMin;
								array[num].max = axes_orig[num].axisMax;
								num2 = -128745689;
								continue;
							case 7:
								goto IL_0147;
							case 8:
								array[num].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num].alternateCalibrations, true);
								num++;
								num2 = -128745684;
								continue;
							default:
								goto end_IL_0147;
							}
							int num4;
							if (axes_orig[num].sourceType != 0)
							{
								num2 = -128745687;
								num4 = num2;
							}
							else
							{
								num2 = -128745686;
								num4 = num2;
							}
							continue;
							end_IL_0021:
							break;
						}
						goto IL_00fa;
						IL_00fa:
						array[num] = AxisCalibrationData.Default;
						num2 = -128745681;
						goto IL_0021;
						continue;
						end_IL_0147:
						break;
					}
				}
				return array;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				int num2 = default(int);
				while (true)
				{
					int num = -739317103;
					while (true)
					{
						switch (num ^ -739317104)
						{
						case 0:
							break;
						case 1:
						{
							int num4;
							if (Axes_orig != null)
							{
								num = -739317097;
								num4 = num;
							}
							else
							{
								num = -739317101;
								num4 = num;
							}
							continue;
						}
						case 5:
							num2++;
							num = -739317093;
							continue;
						case 7:
							axisRanges = new AxisRange[Axes_orig.Length];
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = -739317093;
							continue;
						case 10:
							if (Axes_orig[num2].sourceType == 0)
							{
								axisRanges[num2] = AxisRange.Full;
								num = -739317099;
								continue;
							}
							goto case 4;
						case 3:
							return;
						case 9:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -739317096;
							continue;
						case 4:
							throw new Exception();
						case 2:
						{
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							int num5;
							if (Axes_orig[num2].sourceType != 1)
							{
								num = -739317098;
								num5 = num;
							}
							else
							{
								num = -739317095;
								num5 = num;
							}
							continue;
						}
						case 6:
						{
							int num3;
							if (Axes_orig[num2].sourceType == 100)
							{
								num = -739317095;
								num3 = num;
							}
							else
							{
								num = -739317094;
								num3 = num;
							}
							continue;
						}
						case 8:
							num = -739317099;
							continue;
						default:
							if (num2 >= Axes_orig.Length)
							{
								return;
							}
							goto case 2;
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
				goto IL_003e;
				IL_000b:
				int num = 1896407608;
				goto IL_0010;
				IL_0010:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ 0x7108E23D)
					{
					case 4:
						break;
					case 0:
						num2 = 0;
						num = 1896407612;
						continue;
					case 2:
						goto IL_003e;
					case 5:
						return;
					case 3:
						buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
						num2++;
						num = 1896407612;
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
				IL_003e:
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				num = 1896407613;
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

			public override object DeepClone()
			{
				Platform_PS4_Base platform_PS4_Base = new Platform_PS4_Base();
				CopyVars(platform_PS4_Base);
				return platform_PS4_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_PS4_Base platform_PS4_Base = default(Platform_PS4_Base);
				while (true)
				{
					int num = -172304998;
					while (true)
					{
						switch (num ^ -172304997)
						{
						case 3:
							break;
						case 1:
							platform_PS4_Base = destination as Platform_PS4_Base;
							if (platform_PS4_Base != null)
							{
								goto IL_003b;
							}
							return;
						case 2:
							goto IL_003b;
						default:
							platform_PS4_Base.elements = MiscTools.DeepClone(elements);
							return;
						}
						break;
						IL_003b:
						platform_PS4_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
						num = -172304997;
					}
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
					int num = 0;
					while (true)
					{
						int num2;
						int num3;
						if (num >= variants.Length)
						{
							num2 = -848124839;
							num3 = num2;
						}
						else
						{
							num2 = -848124838;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -848124837)
							{
							case 3:
								num2 = -848124838;
								continue;
							case 1:
								break;
							case 0:
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
							num2 = -848124837;
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
				Platform_PS4 platform_PS = new Platform_PS4();
				CopyVars(platform_PS);
				return platform_PS;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_PS4 platform_PS = default(Platform_PS4);
				while (true)
				{
					switch (-243701878 ^ -243701877)
					{
					case 0:
						continue;
					case 1:
						platform_PS = destination as Platform_PS4;
						if (platform_PS == null)
						{
							return;
						}
						break;
					}
					break;
				}
				platform_PS.variants = MiscTools.DeepClone(variants);
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
							num = 1910542474;
							goto IL_000d;
						}
						return true;
						IL_0008:
						num = 1910542473;
						goto IL_000d;
						IL_000d:
						switch (num ^ 0x71E0908B)
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
					if (bridgedControllerHWInfo.isMock)
					{
						goto IL_0008;
					}
					goto IL_0053;
					IL_0008:
					int num = 600848915;
					goto IL_000d;
					IL_000d:
					string text = default(string);
					int num2 = default(int);
					while (true)
					{
						switch (num ^ 0x23D03A12)
						{
						case 3:
							break;
						case 1:
							goto IL_0041;
						case 6:
							goto IL_0077;
						case 5:
							goto IL_0096;
						case 7:
							return true;
						case 2:
							goto IL_00c8;
						case 4:
							text = text.Trim();
							if (productName != null)
							{
								num2 = 0;
								num = 600848916;
								continue;
							}
							goto default;
						case 8:
							text = string.Empty;
							num = 600848918;
							continue;
						default:
							return false;
						}
						break;
						IL_00c8:
						int num3;
						if (text == null)
						{
							num = 600848922;
							num3 = num;
						}
						else
						{
							num = 600848918;
							num3 = num;
						}
						continue;
						IL_0096:
						string searchFor = productName[num2];
						if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
						{
							num = 600848917;
							continue;
						}
						num2++;
						num = 600848916;
						continue;
						IL_0077:
						int num4;
						if (num2 >= productName.Length)
						{
							num = 600848914;
							num4 = num;
						}
						else
						{
							num = 600848919;
							num4 = num;
						}
					}
					goto IL_0008;
					IL_0041:
					if (hasData && isAllowed)
					{
						return true;
					}
					goto IL_0053;
					IL_0053:
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					text = bridgedControllerHWInfo.hw_productName;
					num = 600848912;
					goto IL_000d;
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
						int num = 1580822985;
						while (true)
						{
							switch (num ^ 0x5E3971CD)
							{
							case 0:
								break;
							case 1:
								matchingCriteria.productName_useRegex = productName_useRegex;
								num = 1580822991;
								continue;
							case 3:
								if (matchingCriteria == null)
								{
									return;
								}
								goto case 1;
							case 4:
								matchingCriteria = destination as MatchingCriteria;
								num = 1580822990;
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
					int num4 = default(int);
					while (true)
					{
						int num2;
						int num3;
						if (num >= axisCount)
						{
							num2 = 1062730026;
							num3 = num2;
						}
						else
						{
							num2 = 1062730024;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x3F57F929)
							{
							case 6:
								num2 = 1062730024;
								continue;
							case 2:
								if (buttons[num4].elementIdentifier == elementIdentifier.id)
								{
									num2 = 1062730029;
									continue;
								}
								num4++;
								num2 = 1062730028;
								continue;
							case 0:
								break;
							case 4:
								return ControllerElementType.Button;
							case 1:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = 1062730025;
								continue;
							case 3:
								num4 = 0;
								num2 = 1062730028;
								continue;
							default:
								if (num4 >= buttonCount)
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
						int num2 = 1401253498;
						while (true)
						{
							switch (num2 ^ 0x53856E7B)
							{
							case 2:
								break;
							case 6:
								num++;
								num2 = 1401253490;
								continue;
							case 3:
								axisRange = InputTools.InvertAxisRange(axisRange);
								num2 = 1401253502;
								continue;
							case 8:
								axisRange = axes[num].sourceAxisRange;
								num2 = 1401253500;
								continue;
							case 4:
								if (axes[num].elementIdentifier != elementIdentifier.id)
								{
									goto case 6;
								}
								switch (axes[num].sourceType)
								{
								case 1:
									break;
								case 100:
									num2 = 1401253491;
									continue;
								case 0:
									axisRange = AxisRange.Positive;
									return true;
								default:
									throw new NotImplementedException();
								}
								goto case 8;
							case 9:
								if (num >= axisCount)
								{
									axisRange = AxisRange.Full;
									num2 = 1401253499;
									continue;
								}
								goto case 4;
							case 7:
							{
								int num3;
								if (!axes[num].invert)
								{
									num2 = 1401253502;
									num3 = num2;
								}
								else
								{
									num2 = 1401253496;
									num3 = num2;
								}
								continue;
							}
							case 1:
								num2 = 1401253490;
								continue;
							case 5:
								return true;
							default:
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
					if (elements == null)
					{
						return;
					}
					while (true)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						int num = -943248817;
						while (true)
						{
							switch (num ^ -943248818)
							{
							case 0:
								goto IL_0012;
							case 2:
								break;
							default:
								elements.buttons = ArrayTools.DeepClone(buttons);
								return;
							}
							break;
							IL_0012:
							num = -943248820;
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

			private sealed class LsLgcVghpdlovNrRwGzMYBJatIp : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_NintendoSwitch_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int ExrourJphmFEZvyROUsJPDzzeUc;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						goto IL_001c;
					}
					goto IL_004e;
					IL_004e:
					LsLgcVghpdlovNrRwGzMYBJatIp lsLgcVghpdlovNrRwGzMYBJatIp = new LsLgcVghpdlovNrRwGzMYBJatIp(0);
					lsLgcVghpdlovNrRwGzMYBJatIp.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					int num = 470157952;
					goto IL_0021;
					IL_001c:
					num = 470157955;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ 0x1C060A82)
						{
						case 3:
							break;
						case 1:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							lsLgcVghpdlovNrRwGzMYBJatIp = this;
							num = 470157952;
							continue;
						case 0:
							goto IL_004e;
						default:
							return lsLgcVghpdlovNrRwGzMYBJatIp;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 1:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = -1982483916;
						goto IL_001f;
					case 0:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							int num3;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements == null)
							{
								num = -1982483917;
								num3 = num;
							}
							else
							{
								num = -1982483913;
								num3 = num;
							}
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -1982483915)
							{
							case 5:
								num = -1982483914;
								continue;
							case 0:
								break;
							case 4:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes[ExrourJphmFEZvyROUsJPDzzeUc];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 1:
								ExrourJphmFEZvyROUsJPDzzeUc++;
								num = -1982483915;
								continue;
							case 2:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes != null)
								{
									ExrourJphmFEZvyROUsJPDzzeUc = 0;
									num = -1982483915;
									continue;
								}
								goto end_IL_0008;
							case 3:
								goto end_IL_001f;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (ExrourJphmFEZvyROUsJPDzzeUc >= iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes.Length)
							{
								num = -1982483917;
								num2 = num;
							}
							else
							{
								num = -1982483919;
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
				public LsLgcVghpdlovNrRwGzMYBJatIp(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class nHMBzmUvwAnOsoRCWHPEIPqJYZA : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_NintendoSwitch_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int wkbDfxffsEkFAxLKToJYbvqfyHDJ;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						goto IL_0023;
					}
					goto IL_004e;
					IL_0028:
					int num;
					nHMBzmUvwAnOsoRCWHPEIPqJYZA nHMBzmUvwAnOsoRCWHPEIPqJYZA2 = default(nHMBzmUvwAnOsoRCWHPEIPqJYZA);
					while (true)
					{
						switch (num ^ 0x7F9B6B77)
						{
						case 3:
							break;
						case 1:
							nHMBzmUvwAnOsoRCWHPEIPqJYZA2 = this;
							num = 2140892023;
							continue;
						case 2:
							goto IL_004e;
						default:
							return nHMBzmUvwAnOsoRCWHPEIPqJYZA2;
						}
						break;
					}
					goto IL_0023;
					IL_004e:
					nHMBzmUvwAnOsoRCWHPEIPqJYZA2 = new nHMBzmUvwAnOsoRCWHPEIPqJYZA(0);
					nHMBzmUvwAnOsoRCWHPEIPqJYZA2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					num = 2140892023;
					goto IL_0028;
					IL_0023:
					num = 2140892022;
					goto IL_0028;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 0:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						int num2;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements != null)
						{
							num = -432240296;
							num2 = num;
						}
						else
						{
							num = -432240291;
							num2 = num;
						}
						goto IL_001f;
					}
					case 1:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							wkbDfxffsEkFAxLKToJYbvqfyHDJ++;
							num = -432240293;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -432240294)
							{
							case 0:
								num = -432240295;
								continue;
							case 5:
								wkbDfxffsEkFAxLKToJYbvqfyHDJ = 0;
								num = -432240292;
								continue;
							case 2:
								break;
							case 3:
								goto end_IL_001f;
							case 6:
								num = -432240293;
								continue;
							case 4:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons[wkbDfxffsEkFAxLKToJYbvqfyHDJ];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 1:
								goto IL_00f7;
							default:
								goto end_IL_0008;
							}
							int num3;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons == null)
							{
								num = -432240291;
								num3 = num;
							}
							else
							{
								num = -432240289;
								num3 = num;
							}
							continue;
							IL_00f7:
							int num4;
							if (wkbDfxffsEkFAxLKToJYbvqfyHDJ < iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons.Length)
							{
								num = -432240290;
								num4 = num;
							}
							else
							{
								num = -432240291;
								num4 = num;
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
				public nHMBzmUvwAnOsoRCWHPEIPqJYZA(int _003C_003E1__state)
				{
					while (true)
					{
						int num = 1128051255;
						while (true)
						{
							switch (num ^ 0x433CB236)
							{
							case 2:
								break;
							case 1:
								goto IL_0024;
							default:
								HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
								return;
							}
							break;
							IL_0024:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
							num = 1128051254;
						}
					}
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
					return InputPlatform.MEQxKcJyEOIzwyouWrqjNydTDGq;
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
								int num = 1138911552;
								while (true)
								{
									switch (num ^ 0x43E26943)
									{
									case 2:
										break;
									case 3:
										_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
										num2 = 0;
										num = 1138911554;
										continue;
									case 0:
										_axesOrigGame[num2] = axes_orig[num2];
										num2++;
										num = 1138911554;
										continue;
									case 1:
										goto IL_0065;
									default:
										goto end_IL_0012;
									}
									break;
									IL_0065:
									int num3;
									if (num2 >= axes_orig.Length)
									{
										num = 1138911559;
										num3 = num;
									}
									else
									{
										num = 1138911555;
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
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							int num = 0;
							while (true)
							{
								int num2 = 840331063;
								while (true)
								{
									switch (num2 ^ 0x32166F36)
									{
									case 3:
										break;
									case 1:
										num2 = 840331062;
										continue;
									case 4:
										_buttonsOrigGame[num] = buttons_orig[num];
										num2 = 840331060;
										continue;
									case 2:
										num++;
										num2 = 840331062;
										continue;
									case 0:
										goto IL_0070;
									default:
										goto end_IL_0022;
									}
									break;
									IL_0070:
									int num3;
									if (num >= buttons_orig.Length)
									{
										num2 = 840331059;
										num3 = num2;
									}
									else
									{
										num2 = 840331058;
										num3 = num2;
									}
								}
								continue;
								end_IL_0022:
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
				LsLgcVghpdlovNrRwGzMYBJatIp lsLgcVghpdlovNrRwGzMYBJatIp = new LsLgcVghpdlovNrRwGzMYBJatIp(-2);
				lsLgcVghpdlovNrRwGzMYBJatIp.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return lsLgcVghpdlovNrRwGzMYBJatIp;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				nHMBzmUvwAnOsoRCWHPEIPqJYZA nHMBzmUvwAnOsoRCWHPEIPqJYZA2 = new nHMBzmUvwAnOsoRCWHPEIPqJYZA(-2);
				nHMBzmUvwAnOsoRCWHPEIPqJYZA2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return nHMBzmUvwAnOsoRCWHPEIPqJYZA2;
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
				int num2 = -398216881;
				goto IL_0022;
				IL_0022:
				int num3 = default(int);
				while (true)
				{
					switch (num2 ^ -398216883)
					{
					case 0:
						break;
					case 7:
					{
						int num5;
						if (num3 >= identifiers.Length)
						{
							num2 = -398216888;
							num5 = num2;
						}
						else
						{
							num2 = -398216882;
							num5 = num2;
						}
						continue;
					}
					case 1:
					{
						int elementIdentifier = elements.axes[num].elementIdentifier;
						num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						num2 = -398216891;
						continue;
					}
					case 4:
						num++;
						num2 = -398216881;
						continue;
					case 6:
						return new string[0];
					case 5:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = -398216887;
						continue;
					case 8:
					{
						int num4;
						if (num3 < 0)
						{
							num2 = -398216888;
							num4 = num2;
						}
						else
						{
							num2 = -398216886;
							num4 = num2;
						}
						continue;
					}
					case 3:
						array[num] = identifiers[num3].name;
						num2 = -398216887;
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
				goto IL_001d;
				IL_001d:
				num2 = -398216885;
				goto IL_0022;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				if (identifiers.Length < buttonCount)
				{
					goto IL_0015;
				}
				string[] array = new string[buttonCount];
				int num = 0;
				int num2 = 2072240886;
				goto IL_001a;
				IL_001a:
				int num3 = default(int);
				while (true)
				{
					switch (num2 ^ 0x7B83E2F0)
					{
					case 0:
						break;
					case 4:
						num++;
						num2 = 2072240886;
						continue;
					case 3:
					{
						int elementIdentifier = elements.buttons[num].elementIdentifier;
						num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						if (num3 >= 0)
						{
							int num4;
							if (num3 < identifiers.Length)
							{
								num2 = 2072240885;
								num4 = num2;
							}
							else
							{
								num2 = 2072240881;
								num4 = num2;
							}
							continue;
						}
						goto case 1;
					}
					case 5:
						array[num] = identifiers[num3].name;
						num2 = 2072240884;
						continue;
					case 2:
						Logger.LogError("You have too few element identifiers!");
						return new string[0];
					case 1:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = 2072240884;
						continue;
					default:
						if (num >= array.Length)
						{
							return array;
						}
						goto case 3;
					}
					break;
				}
				goto IL_0015;
				IL_0015:
				num2 = 2072240882;
				goto IL_001a;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				IEnumerator<Platform_Custom.Axis> enumerator = IterateAxes().GetEnumerator();
				bool result;
				try
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
							int num = 2080639669;
							while (true)
							{
								switch (num ^ 0x7C040AB7)
								{
								case 0:
									num = 2080639668;
									continue;
								case 3:
									break;
								default:
									goto end_IL_0030;
								case 2:
									goto IL_011a;
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
							IL_0067:
							int num2 = 2080639670;
							while (true)
							{
								switch (num2 ^ 0x7C040AB7)
								{
								case 2:
									break;
								default:
									goto end_IL_006c;
								case 1:
									goto IL_0085;
								case 0:
									goto end_IL_006c;
								}
								goto IL_0067;
								IL_0085:
								enumerator.Dispose();
								num2 = 2080639671;
								continue;
								end_IL_006c:
								break;
							}
							break;
						}
					}
				}
				using (IEnumerator<Platform_Custom.Button> enumerator2 = IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Button button = (Button)enumerator2.Current;
							int num3 = 2080639669;
							while (true)
							{
								switch (num3 ^ 0x7C040AB7)
								{
								case 4:
									num3 = 2080639670;
									continue;
								case 3:
									result = true;
									goto IL_011a;
								case 2:
									break;
								case 1:
									goto end_IL_00a7;
								default:
									goto end_IL_00ed;
								}
								int num4;
								if (button.elementIdentifier == elementIdentifierId)
								{
									num3 = 2080639668;
									num4 = num3;
								}
								else
								{
									num3 = 2080639671;
									num4 = num3;
								}
								continue;
								end_IL_00a7:
								break;
							}
							continue;
							end_IL_00ed:
							break;
						}
					}
				}
				return false;
				IL_011a:
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
							int num2 = 94090365;
							while (true)
							{
								switch (num2 ^ 0x59BB47F)
								{
								case 0:
									num2 = 94090366;
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
							int num3 = 94090367;
							while (true)
							{
								switch (num3 ^ 0x59BB47F)
								{
								case 2:
									num3 = 94090366;
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
				int num2 = default(int);
				AxisCalibrationData[] array = default(AxisCalibrationData[]);
				while (true)
				{
					int num = -254933545;
					while (true)
					{
						switch (num ^ -254933540)
						{
						case 8:
							break;
						case 0:
							throw new NotImplementedException();
						case 4:
							return null;
						case 10:
							if (axes_orig[num2].sourceType == 0)
							{
								array[num2] = AxisCalibrationData.Default;
								num = -254933547;
								continue;
							}
							goto case 0;
						case 3:
							if (axes_orig[num2].sourceType != 1)
							{
								int num4;
								if (axes_orig[num2].sourceType == 100)
								{
									num = -254933542;
									num4 = num;
								}
								else
								{
									num = -254933546;
									num4 = num;
								}
								continue;
							}
							goto case 6;
						case 2:
							num2 = 0;
							num = -254933541;
							continue;
						case 5:
							array[num2].max = axes_orig[num2].axisMax;
							num = -254933547;
							continue;
						case 7:
						{
							int num3;
							if (num2 >= axes_orig.Length)
							{
								num = -254933539;
								num3 = num;
							}
							else
							{
								num = -254933537;
								num3 = num;
							}
							continue;
						}
						case 9:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num2++;
							num = -254933541;
							continue;
						case 6:
							array[num2] = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							if (Axes_orig[num2].calibrateAxis)
							{
								array[num2].zero = axes_orig[num2].axisZero;
								array[num2].min = axes_orig[num2].axisMin;
								num = -254933543;
								continue;
							}
							goto case 9;
						case 11:
							if (axes_orig != null)
							{
								array = new AxisCalibrationData[axes_orig.Length];
								num = -254933538;
							}
							else
							{
								num = -254933544;
							}
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
				if (Axes_orig == null)
				{
					return;
				}
				int num2 = default(int);
				while (true)
				{
					axisRanges = new AxisRange[Axes_orig.Length];
					int num = 1945367551;
					while (true)
					{
						switch (num ^ 0x73F3F3FA)
						{
						case 2:
							num = 1945367547;
							continue;
						default:
							return;
						case 1:
							break;
						case 7:
							num2++;
							num = 1945367539;
							continue;
						case 6:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = 1945367549;
							continue;
						case 10:
							throw new Exception();
						case 3:
						{
							int num4;
							if (Axes_orig[num2].sourceType == 100)
							{
								num = 1945367548;
								num4 = num;
							}
							else
							{
								num = 1945367546;
								num4 = num;
							}
							continue;
						}
						case 0:
							if (Axes_orig[num2].sourceType == 0)
							{
								axisRanges[num2] = AxisRange.Full;
								num = 1945367549;
								continue;
							}
							goto case 10;
						case 11:
						{
							int num5;
							if (Axes_orig[num2].sourceType == 1)
							{
								num = 1945367548;
								num5 = num;
							}
							else
							{
								num = 1945367545;
								num5 = num;
							}
							continue;
						}
						case 5:
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = 1945367539;
							continue;
						case 4:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							num = 1945367537;
							continue;
						case 9:
						{
							int num3;
							if (num2 < Axes_orig.Length)
							{
								num = 1945367550;
								num3 = num;
							}
							else
							{
								num = 1945367538;
								num3 = num;
							}
							continue;
						}
						case 8:
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
				goto IL_0053;
				IL_000b:
				int num = 188555820;
				goto IL_0010;
				IL_0010:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ 0xB3D222E)
					{
					case 4:
						break;
					case 3:
						buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
						num2++;
						num = 188555822;
						continue;
					case 1:
						goto IL_0053;
					case 2:
						return;
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
				IL_0053:
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				num2 = 0;
				num = 188555822;
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
					while (true)
					{
						int num = 741184634;
						while (true)
						{
							switch (num ^ 0x2C2D947B)
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
							num = 741184633;
						}
					}
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
					int num = 719429245;
					while (true)
					{
						switch (num ^ 0x2AE19E7C)
						{
						case 2:
							break;
						case 1:
						{
							platform_NintendoSwitch_Base = destination as Platform_NintendoSwitch_Base;
							int num2;
							if (platform_NintendoSwitch_Base == null)
							{
								num = 719429240;
								num2 = num;
							}
							else
							{
								num = 719429247;
								num2 = num;
							}
							continue;
						}
						case 4:
							return;
						case 3:
							platform_NintendoSwitch_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
							num = 719429244;
							continue;
						default:
							platform_NintendoSwitch_Base.elements = MiscTools.DeepClone(elements);
							return;
						}
						break;
					}
				}
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
					int num2 = default(int);
					while (true)
					{
						int num = 1133964529;
						while (true)
						{
							switch (num ^ 0x4396ECF5)
							{
							case 5:
								break;
							case 6:
								goto IL_0048;
							case 2:
								variantIndex = num2;
								return true;
							case 4:
								num2 = 0;
								num = 1133964532;
								continue;
							case 0:
								goto IL_0087;
							case 1:
								num = 1133964533;
								continue;
							default:
								goto end_IL_001a;
							}
							break;
							IL_0087:
							int num3;
							if (num2 >= variants.Length)
							{
								num = 1133964534;
								num3 = num;
							}
							else
							{
								num = 1133964531;
								num3 = num;
							}
							continue;
							IL_0048:
							int variantIndex2;
							if (variants[num2] != null && variants[num2].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
							{
								num = 1133964535;
								continue;
							}
							num2++;
							num = 1133964533;
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
						switch (0x2926F472 ^ 0x2926F470)
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
						if (productName != null && productName.Length > 0)
						{
							goto IL_001d;
						}
						int num;
						if (vidPid != null && vidPid.Length > 0)
						{
							num = -1977081120;
							goto IL_0022;
						}
						return false;
						IL_0022:
						switch (num ^ -1977081119)
						{
						case 0:
							break;
						case 2:
							return true;
						default:
							return true;
						}
						goto IL_001d;
						IL_001d:
						num = -1977081117;
						goto IL_0022;
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
						goto IL_0021;
					}
					int num;
					string text = default(string);
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						num = -625939328;
					}
					else if (!alwaysMatch)
					{
						bool alternateMatched;
						if (!ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
						{
							num = -625939321;
						}
						else
						{
							text = bridgedControllerHWInfo.hw_productName;
							if (text != null)
							{
								goto IL_0076;
							}
							text = string.Empty;
							num = -625939314;
						}
					}
					else
					{
						num = -625939319;
					}
					goto IL_0026;
					IL_0076:
					text = text.Trim();
					num = -625939323;
					goto IL_0026;
					IL_0026:
					int num2 = default(int);
					int vendorId = default(int);
					int productId = default(int);
					while (true)
					{
						switch (num ^ -625939325)
						{
						case 7:
							break;
						case 13:
							goto IL_0076;
						case 10:
							return true;
						case 1:
							goto IL_0098;
						case 4:
							return false;
						case 9:
							return true;
						case 0:
							goto IL_00f8;
						case 11:
							num2 = 0;
							num = -625939316;
							continue;
						case 5:
							goto IL_0116;
						case 8:
							if (vidPid != null)
							{
								num = -625939320;
								continue;
							}
							goto IL_01d8;
						case 3:
							return false;
						case 14:
							return false;
						case 15:
							if (num2 < vidPid.Length)
							{
								goto case 12;
							}
							goto IL_01d8;
						case 6:
							goto IL_01a1;
						case 12:
							vendorId = vidPid[num2].vendorId;
							num = -625939326;
							continue;
						default:
							{
								return ProductNameMatches(text);
							}
							IL_01d8:
							return false;
						}
						break;
						IL_01a1:
						int num3;
						if (!strictMatch)
						{
							num = -625939327;
							num3 = num;
						}
						else
						{
							num = -625939317;
							num3 = num;
						}
						continue;
						IL_0098:
						productId = vidPid[num2].productId;
						if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
						{
							num = -625939325;
							continue;
						}
						goto IL_0167;
						IL_0123:
						string text2;
						string name = (string)text2;
						if (!ProductNameMatches(name))
						{
							num = -625939315;
							continue;
						}
						goto IL_0167;
						IL_0116:
						text2 = bridgedControllerHWInfo.hw_productName;
						goto IL_0123;
						IL_00f8:
						if (bridgedControllerHWInfo.hw_productName != null)
						{
							num = -625939322;
							continue;
						}
						text2 = string.Empty;
						goto IL_0123;
						IL_0167:
						if (bridgedControllerHWInfo.hw_vendorId == vendorId && bridgedControllerHWInfo.hw_productId == productId)
						{
							return true;
						}
						num2++;
						num = -625939316;
					}
					goto IL_0021;
					IL_0021:
					num = -625939318;
					goto IL_0026;
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
					MatchingCriteria matchingCriteria = default(MatchingCriteria);
					while (true)
					{
						int num = 213067175;
						while (true)
						{
							switch (num ^ 0xCB325A6)
							{
							case 2:
								break;
							case 4:
								return;
							case 3:
							{
								int num2;
								if (matchingCriteria != null)
								{
									num = 213067174;
									num2 = num;
								}
								else
								{
									num = 213067170;
									num2 = num;
								}
								continue;
							}
							case 1:
								matchingCriteria = destination as MatchingCriteria;
								num = 213067173;
								continue;
							default:
								matchingCriteria.productName_useRegex = productName_useRegex;
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								matchingCriteria.vidPid = ArrayTools.ShallowCopy(vidPid);
								matchingCriteria.hatCount = hatCount;
								return;
							}
							break;
						}
					}
				}

				private bool ProductNameMatches(string name)
				{
					if (productName == null)
					{
						goto IL_0008;
					}
					int num = 0;
					int num2 = -1877403167;
					goto IL_000d;
					IL_000d:
					while (true)
					{
						switch (num2 ^ -1877403166)
						{
						case 0:
							break;
						case 1:
							return false;
						case 2:
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
							goto case 2;
						}
						break;
						IL_004f:
						num++;
						num2 = -1877403167;
					}
					goto IL_0008;
					IL_0008:
					num2 = -1877403165;
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
						int num2 = -225382475;
						while (true)
						{
							switch (num2 ^ -225382474)
							{
							case 2:
								break;
							case 0:
							{
								int num4;
								if (num3 < buttonCount)
								{
									num2 = -225382480;
									num4 = num2;
								}
								else
								{
									num2 = -225382473;
									num4 = num2;
								}
								continue;
							}
							case 5:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = -225382478;
								continue;
							case 6:
								if (buttons[num3].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num3++;
								num2 = -225382474;
								continue;
							case 4:
								if (num >= axisCount)
								{
									num3 = 0;
									num2 = -225382474;
									continue;
								}
								goto case 5;
							case 3:
								num2 = -225382478;
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
					while (true)
					{
						IL_0103:
						int num2;
						if (num >= axisCount)
						{
							axisRange = AxisRange.Full;
							num2 = -1658268507;
							goto IL_000c;
						}
						goto IL_00a2;
						IL_0048:
						num++;
						num2 = -1658268505;
						goto IL_000c;
						IL_00a2:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							sourceType = axes[num].sourceType;
							num2 = -1658268508;
							goto IL_000c;
						}
						goto IL_0048;
						IL_000c:
						while (true)
						{
							switch (num2 ^ -1658268505)
							{
							case 5:
								num2 = -1658268512;
								continue;
							case 10:
								break;
							case 1:
								goto IL_0053;
							case 4:
								goto IL_005f;
							case 8:
								return true;
							case 7:
								goto IL_00a2;
							case 6:
								axisRange = InputTools.InvertAxisRange(axisRange);
								num2 = -1658268497;
								continue;
							case 3:
								goto IL_00e2;
							case 0:
								goto IL_0103;
							case 9:
								return true;
							default:
								return false;
							}
							break;
							IL_00e2:
							switch (sourceType)
							{
							case 0:
								axisRange = AxisRange.Positive;
								num2 = -1658268498;
								continue;
							case 1:
								break;
							default:
								throw new NotImplementedException();
							case 100:
								num2 = -1658268509;
								continue;
							case 2:
							{
								axisRange = axes[num].sourceHatRange;
								int num3;
								if (axes[num].invert)
								{
									num2 = -1658268511;
									num3 = num2;
								}
								else
								{
									num2 = -1658268497;
									num3 = num2;
								}
								continue;
							}
							}
							goto IL_005f;
							IL_005f:
							axisRange = axes[num].sourceAxisRange;
							if (axes[num].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
								num2 = -1658268506;
								continue;
							}
							goto IL_0053;
							IL_0053:
							return true;
						}
						goto IL_0048;
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
					if (button == null)
					{
						return;
					}
					while (true)
					{
						button.sourceHat = sourceHat;
						button.sourceHatDirection = sourceHatDirection;
						int num = -1378229800;
						while (true)
						{
							switch (num ^ -1378229800)
							{
							case 3:
								num = -1378229799;
								continue;
							default:
								return;
							case 1:
								break;
							case 0:
								button.sourceHatType = sourceHatType;
								num = -1378229798;
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
					if (axis == null)
					{
						return;
					}
					while (true)
					{
						axis.sourceHat = sourceHat;
						axis.sourceHatDirection = sourceHatDirection;
						axis.sourceHatType = sourceHatType;
						int num = -720141958;
						while (true)
						{
							switch (num ^ -720141957)
							{
							case 0:
								goto IL_0012;
							case 2:
								break;
							default:
								axis.sourceHatRange = sourceHatRange;
								return;
							}
							break;
							IL_0012:
							num = -720141959;
						}
					}
				}
			}

			private sealed class aCExOWKhOFaZmCPFQhnPlLqSjTMG : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_InternalDriver_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int dsICvRJZRYCRkATjoRagTxVNFxT;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
					{
						goto IL_0012;
					}
					goto IL_0038;
					IL_0012:
					int num = 1001660249;
					goto IL_0017;
					IL_0017:
					aCExOWKhOFaZmCPFQhnPlLqSjTMG aCExOWKhOFaZmCPFQhnPlLqSjTMG2 = default(aCExOWKhOFaZmCPFQhnPlLqSjTMG);
					while (true)
					{
						switch (num ^ 0x3BB41F58)
						{
						case 2:
							break;
						case 4:
							goto IL_0038;
						case 0:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							aCExOWKhOFaZmCPFQhnPlLqSjTMG2 = this;
							num = 1001660251;
							continue;
						case 1:
							goto IL_0062;
						default:
							return aCExOWKhOFaZmCPFQhnPlLqSjTMG2;
						}
						break;
						IL_0062:
						int num2;
						if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg != -2)
						{
							num = 1001660252;
							num2 = num;
						}
						else
						{
							num = 1001660248;
							num2 = num;
						}
					}
					goto IL_0012;
					IL_0038:
					aCExOWKhOFaZmCPFQhnPlLqSjTMG2 = new aCExOWKhOFaZmCPFQhnPlLqSjTMG(0);
					aCExOWKhOFaZmCPFQhnPlLqSjTMG2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					num = 1001660251;
					goto IL_0017;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
					while (true)
					{
						int num2 = 600402069;
						while (true)
						{
							switch (num2 ^ 0x23C96894)
							{
							case 6:
								break;
							case 3:
								return true;
							case 4:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements != null && iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes != null)
								{
									dsICvRJZRYCRkATjoRagTxVNFxT = 0;
									num2 = 600402070;
									continue;
								}
								goto default;
							case 7:
								num2 = 600402068;
								continue;
							case 1:
								switch (num)
								{
								case 1:
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
									dsICvRJZRYCRkATjoRagTxVNFxT++;
									num2 = 600402070;
									continue;
								case 0:
									break;
								default:
									num2 = 600402067;
									continue;
								}
								goto case 4;
							case 5:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes[dsICvRJZRYCRkATjoRagTxVNFxT];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num2 = 600402071;
								continue;
							case 2:
							{
								int num3;
								if (dsICvRJZRYCRkATjoRagTxVNFxT >= iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes.Length)
								{
									num2 = 600402068;
									num3 = num2;
								}
								else
								{
									num2 = 600402065;
									num3 = num2;
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
				public aCExOWKhOFaZmCPFQhnPlLqSjTMG(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class dlxdRiFViLHFvFEGHZFeNtcnXPq : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_InternalDriver_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int EEnjjioauuyZYCBhLQGnwvmYQip;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					dlxdRiFViLHFvFEGHZFeNtcnXPq dlxdRiFViLHFvFEGHZFeNtcnXPq2;
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						dlxdRiFViLHFvFEGHZFeNtcnXPq2 = this;
					}
					else
					{
						while (true)
						{
							dlxdRiFViLHFvFEGHZFeNtcnXPq2 = new dlxdRiFViLHFvFEGHZFeNtcnXPq(0);
							int num = 1856851494;
							while (true)
							{
								switch (num ^ 0x6EAD4E27)
								{
								case 0:
									num = 1856851492;
									continue;
								case 3:
									break;
								case 1:
									dlxdRiFViLHFvFEGHZFeNtcnXPq2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
									num = 1856851493;
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
					return dlxdRiFViLHFvFEGHZFeNtcnXPq2;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					default:
						num = 314088306;
						goto IL_001a;
					case 1:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = 314088309;
						goto IL_001a;
					case 0:
						goto IL_00ab;
						IL_001a:
						while (true)
						{
							switch (num ^ 0x12B89B76)
							{
							case 7:
								break;
							case 6:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons[EEnjjioauuyZYCBhLQGnwvmYQip];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 3:
								EEnjjioauuyZYCBhLQGnwvmYQip++;
								num = 314088311;
								continue;
							case 4:
								num = 314088308;
								continue;
							case 5:
								EEnjjioauuyZYCBhLQGnwvmYQip = 0;
								num = 314088311;
								continue;
							case 0:
								goto IL_00ab;
							case 1:
								goto IL_00e5;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00e5:
							int num2;
							if (EEnjjioauuyZYCBhLQGnwvmYQip < iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons.Length)
							{
								num = 314088304;
								num2 = num;
							}
							else
							{
								num = 314088308;
								num2 = num;
							}
						}
						goto default;
						IL_00ab:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements == null)
						{
							break;
						}
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons == null)
						{
							num = 314088308;
							num3 = num;
						}
						else
						{
							num = 314088307;
							num3 = num;
						}
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
				public dlxdRiFViLHFvFEGHZFeNtcnXPq(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
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
					return InputPlatform.DUbQuJCDfrUzNLyHOFGFbNvqDqG;
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
							int num = 874691051;
							while (true)
							{
								switch (num ^ 0x3422B9EA)
								{
								case 3:
									break;
								case 5:
									goto IL_0039;
								case 2:
									_axesOrigGame[num2] = axes_orig[num2];
									num = 874691050;
									continue;
								case 1:
									if (axes_orig != null)
									{
										_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
										num2 = 0;
										num = 874691055;
										continue;
									}
									goto end_IL_000f;
								case 0:
									num2++;
									num = 874691055;
									continue;
								default:
									goto end_IL_000f;
								}
								break;
								IL_0039:
								int num3;
								if (num2 >= axes_orig.Length)
								{
									num = 874691054;
									num3 = num;
								}
								else
								{
									num = 874691048;
									num3 = num;
								}
							}
							continue;
							end_IL_000f:
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
									num2 = 1501550597;
									num3 = num2;
								}
								else
								{
									num2 = 1501550599;
									num3 = num2;
								}
								while (true)
								{
									switch (num2 ^ 0x597FD806)
									{
									case 0:
										num2 = 1501550599;
										continue;
									case 1:
										_buttonsOrigGame[num] = buttons_orig[num];
										num++;
										num2 = 1501550596;
										continue;
									case 2:
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
						num = 954294909;
						goto IL_000d;
					}
					goto IL_005b;
					IL_0008:
					num = 954294910;
					goto IL_000d;
					IL_000d:
					while (true)
					{
						switch (num ^ 0x38E1627C)
						{
						case 3:
							break;
						case 2:
							return false;
						case 1:
							goto IL_004a;
						default:
							return false;
						}
						break;
						IL_004a:
						if (assignedAxisCount == 0)
						{
							num = 954294908;
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
					platformMap = this;
					return true;
				}
				return false;
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				aCExOWKhOFaZmCPFQhnPlLqSjTMG aCExOWKhOFaZmCPFQhnPlLqSjTMG2 = new aCExOWKhOFaZmCPFQhnPlLqSjTMG(-2);
				aCExOWKhOFaZmCPFQhnPlLqSjTMG2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return aCExOWKhOFaZmCPFQhnPlLqSjTMG2;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				dlxdRiFViLHFvFEGHZFeNtcnXPq dlxdRiFViLHFvFEGHZFeNtcnXPq2 = new dlxdRiFViLHFvFEGHZFeNtcnXPq(-2);
				dlxdRiFViLHFvFEGHZFeNtcnXPq2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return dlxdRiFViLHFvFEGHZFeNtcnXPq2;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					goto IL_001a;
				}
				string[] array = new string[elements.axisCount];
				int num = 925850981;
				goto IL_001f;
				IL_001f:
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					switch (num ^ 0x372F5D67)
					{
					case 5:
						break;
					case 6:
						return new string[0];
					case 3:
					{
						int elementIdentifier = elements.axes[num2].elementIdentifier;
						num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						int num5;
						if (num3 >= 0)
						{
							num = 925850983;
							num5 = num;
						}
						else
						{
							num = 925850979;
							num5 = num;
						}
						continue;
					}
					case 2:
						num2 = 0;
						num = 925850990;
						continue;
					case 7:
						array[num2] = identifiers[num3].name;
						num = 925850991;
						continue;
					case 8:
						num2++;
						num = 925850982;
						continue;
					case 9:
						num = 925850982;
						continue;
					case 4:
						Logger.LogError("Element identifier index is out of bounds!");
						num = 925850991;
						continue;
					case 0:
					{
						int num4;
						if (num3 >= identifiers.Length)
						{
							num = 925850979;
							num4 = num;
						}
						else
						{
							num = 925850976;
							num4 = num;
						}
						continue;
					}
					default:
						if (num2 >= array.Length)
						{
							return array;
						}
						goto case 3;
					}
					break;
				}
				goto IL_001a;
				IL_001a:
				num = 925850977;
				goto IL_001f;
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
				while (num < array.Length)
				{
					while (true)
					{
						int elementIdentifier = elements.buttons[num].elementIdentifier;
						int num2 = 254994197;
						while (true)
						{
							switch (num2 ^ 0xF32E711)
							{
							case 2:
								num2 = 254994192;
								continue;
							case 7:
								array[num] = identifiers[num3].name;
								num2 = 254994196;
								continue;
							case 4:
								break;
							case 3:
								Logger.LogError("Element identifier index is out of bounds!");
								num2 = 254994196;
								continue;
							case 5:
								num++;
								num2 = 254994199;
								continue;
							case 1:
								goto end_IL_0036;
							case 0:
								goto IL_00d2;
							default:
								goto end_IL_00b5;
							}
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							int num4;
							if (num3 < 0)
							{
								num2 = 254994194;
								num4 = num2;
							}
							else
							{
								num2 = 254994193;
								num4 = num2;
							}
							continue;
							IL_00d2:
							int num5;
							if (num3 >= identifiers.Length)
							{
								num2 = 254994194;
								num5 = num2;
							}
							else
							{
								num2 = 254994198;
								num5 = num2;
							}
							continue;
							end_IL_0036:
							break;
						}
						continue;
						end_IL_00b5:
						break;
					}
				}
				return array;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				bool result = default(bool);
				using (IEnumerator<Platform_Custom.Axis> enumerator = IterateAxes().GetEnumerator())
				{
					Axis axis = default(Axis);
					while (true)
					{
						IL_0047:
						int num;
						int num2;
						if (enumerator.MoveNext())
						{
							num = 776220587;
							num2 = num;
						}
						else
						{
							num = 776220585;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x2E442FA9)
							{
							case 4:
								num = 776220587;
								continue;
							default:
								goto end_IL_0013;
							case 2:
								axis = (Axis)enumerator.Current;
								num = 776220586;
								continue;
							case 1:
								break;
							case 3:
								if (axis.elementIdentifier != elementIdentifierId)
								{
									break;
								}
								result = true;
								goto IL_010a;
							case 0:
								goto end_IL_0013;
							}
							goto IL_0047;
							continue;
							end_IL_0013:
							break;
						}
						break;
					}
				}
				using (IEnumerator<Platform_Custom.Button> enumerator2 = IterateButtons().GetEnumerator())
				{
					while (true)
					{
						IL_00d7:
						int num3;
						int num4;
						if (enumerator2.MoveNext())
						{
							num3 = 776220584;
							num4 = num3;
						}
						else
						{
							num3 = 776220589;
							num4 = num3;
						}
						while (true)
						{
							switch (num3 ^ 0x2E442FA9)
							{
							case 2:
								num3 = 776220584;
								continue;
							default:
								goto end_IL_0097;
							case 1:
							{
								Button button = (Button)enumerator2.Current;
								if (button.elementIdentifier == elementIdentifierId)
								{
									result = true;
									num3 = 776220586;
									continue;
								}
								break;
							}
							case 0:
								break;
							case 4:
								goto end_IL_0097;
							case 3:
								goto IL_010a;
							}
							goto IL_00d7;
							continue;
							end_IL_0097:
							break;
						}
						break;
					}
				}
				return false;
				IL_010a:
				return result;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				int num2 = default(int);
				while (true)
				{
					int num = 920910709;
					while (true)
					{
						switch (num ^ 0x36E3FB77)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
						{
							IEnumerator<Platform_Custom.Button> enumerator = IterateButtons().GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										Button button = (Button)enumerator.Current;
										buttons[num2] = button.elementIdentifier;
										int num3 = 920910710;
										while (true)
										{
											switch (num3 ^ 0x36E3FB77)
											{
											case 0:
												num3 = 920910709;
												continue;
											case 2:
												break;
											case 1:
												num2++;
												num3 = 920910708;
												continue;
											default:
												goto end_IL_0071;
											}
											break;
										}
										continue;
										end_IL_0071:
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
										IL_00a6:
										int num4 = 920910710;
										while (true)
										{
											switch (num4 ^ 0x36E3FB77)
											{
											case 2:
												break;
											default:
												goto end_IL_00ab;
											case 1:
												goto IL_00c4;
											case 0:
												goto end_IL_00ab;
											}
											goto IL_00a6;
											IL_00c4:
											enumerator.Dispose();
											num4 = 920910711;
											continue;
											end_IL_00ab:
											break;
										}
										break;
									}
								}
							}
							num2 = 0;
							using (IEnumerator<Platform_Custom.Axis> enumerator2 = IterateAxes().GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									while (true)
									{
										Axis axis = (Axis)enumerator2.Current;
										int num5 = 920910708;
										while (true)
										{
											switch (num5 ^ 0x36E3FB77)
											{
											case 2:
												num5 = 920910710;
												continue;
											case 1:
												break;
											case 3:
												axes[num2] = axis.elementIdentifier;
												num2++;
												num5 = 920910711;
												continue;
											default:
												goto end_IL_0105;
											}
											break;
										}
										continue;
										end_IL_0105:
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
						num2 = 0;
						num = 920910710;
					}
				}
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig == null)
				{
					goto IL_000d;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				int num = 0;
				int num2 = -1955492667;
				goto IL_0012;
				IL_0012:
				while (true)
				{
					switch (num2 ^ -1955492666)
					{
					case 0:
						break;
					case 2:
						array[num].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num].alternateCalibrations, true);
						num++;
						num2 = -1955492669;
						continue;
					case 1:
						if (axes_orig[num].sourceType != 1)
						{
							int num4;
							if (axes_orig[num].sourceType == 100)
							{
								num2 = -1955492672;
								num4 = num2;
							}
							else
							{
								num2 = -1955492660;
								num4 = num2;
							}
							continue;
						}
						goto case 6;
					case 4:
						num2 = -1955492668;
						continue;
					case 3:
						num2 = -1955492669;
						continue;
					case 7:
						array[num] = AxisCalibrationData.Default;
						num2 = -1955492670;
						continue;
					case 6:
						array[num] = AxisCalibrationData.Default;
						array[num].invert = axes_orig[num].invert;
						array[num].deadZone = axes_orig[num].axisDeadZone;
						num2 = -1955492658;
						continue;
					case 8:
						if (Axes_orig[num].calibrateAxis)
						{
							array[num].zero = axes_orig[num].axisZero;
							array[num].min = axes_orig[num].axisMin;
							array[num].max = axes_orig[num].axisMax;
							num2 = -1955492668;
							continue;
						}
						goto case 2;
					case 10:
						if (axes_orig[num].sourceType != 0)
						{
							int num3;
							if (axes_orig[num].sourceType == 2)
							{
								num2 = -1955492671;
								num3 = num2;
							}
							else
							{
								num2 = -1955492659;
								num3 = num2;
							}
							continue;
						}
						goto case 7;
					case 11:
						throw new NotImplementedException();
					case 9:
						return null;
					default:
						if (num >= axes_orig.Length)
						{
							return array;
						}
						goto case 1;
					}
					break;
				}
				goto IL_000d;
				IL_000d:
				num2 = -1955492657;
				goto IL_0012;
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
					int num = -842718275;
					while (true)
					{
						switch (num ^ -842718281)
						{
						case 6:
							num = -842718286;
							continue;
						case 5:
							break;
						case 7:
							axisRanges[num2] = AxisRange.Full;
							num = -842718277;
							continue;
						case 8:
							throw new Exception();
						case 2:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -842718282;
							continue;
						case 10:
							num2 = 0;
							num = -842718285;
							continue;
						case 11:
						{
							int num5;
							if (Axes_orig[num2].sourceType != 1)
							{
								num = -842718284;
								num5 = num;
							}
							else
							{
								num = -842718283;
								num5 = num;
							}
							continue;
						}
						case 9:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							num = -842718276;
							continue;
						case 1:
							num2++;
							num = -842718285;
							continue;
						case 3:
						{
							int num4;
							if (Axes_orig[num2].sourceType != 100)
							{
								num = -842718281;
								num4 = num;
							}
							else
							{
								num = -842718283;
								num4 = num;
							}
							continue;
						}
						case 12:
							num = -842718282;
							continue;
						case 0:
							if (Axes_orig[num2].sourceType != 0)
							{
								int num3;
								if (Axes_orig[num2].sourceType != 2)
								{
									num = -842718273;
									num3 = num;
								}
								else
								{
									num = -842718288;
									num3 = num;
								}
								continue;
							}
							goto case 7;
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
				int num2 = default(int);
				while (true)
				{
					int num = 891555365;
					while (true)
					{
						switch (num ^ 0x35240E24)
						{
						case 5:
							break;
						case 0:
							num2 = 0;
							num = 891555360;
							continue;
						case 3:
							buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
							num = 891555364;
							continue;
						case 2:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
							num2++;
							num = 891555360;
							continue;
						case 1:
							if (Buttons_orig == null)
							{
								return;
							}
							goto case 3;
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
					while (true)
					{
						int num = 1761199335;
						while (true)
						{
							switch (num ^ 0x68F9C4E5)
							{
							case 0:
								break;
							case 2:
								goto IL_0026;
							default:
								return false;
							}
							break;
							IL_0026:
							axisRange = AxisRange.Full;
							num = 1761199332;
						}
					}
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
				if (platform_InternalDriver_Base != null)
				{
					platform_InternalDriver_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_InternalDriver_Base.elements = MiscTools.DeepClone(elements);
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
					return true;
				}
				if (base.hasVariants)
				{
					int num = 0;
					while (true)
					{
						int num2 = 419254723;
						while (true)
						{
							switch (num2 ^ 0x18FD51C1)
							{
							case 0:
								break;
							case 2:
								num2 = 419254722;
								continue;
							case 1:
								goto IL_0046;
							case 3:
								goto IL_0075;
							default:
								goto end_IL_0019;
							}
							break;
							IL_0075:
							int num3;
							if (num >= variants.Length)
							{
								num2 = 419254725;
								num3 = num2;
							}
							else
							{
								num2 = 419254720;
								num3 = num2;
							}
							continue;
							IL_0046:
							int variantIndex2;
							if (variants[num] != null && variants[num].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
							{
								variantIndex = num;
								return true;
							}
							num++;
							num2 = 419254722;
						}
						continue;
						end_IL_0019:
						break;
					}
				}
				return false;
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
				if (platform_InternalDriver == null)
				{
					return;
				}
				while (true)
				{
					platform_InternalDriver.variants = MiscTools.DeepClone(variants);
					int num = 1763207653;
					while (true)
					{
						switch (num ^ 0x691869E7)
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
						num = 1763207654;
					}
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
							while (true)
							{
								int num = 1545203047;
								while (true)
								{
									switch (num ^ 0x5C19ED66)
									{
									case 2:
										break;
									case 1:
										goto IL_0030;
									default:
										return true;
									}
									break;
									IL_0030:
									if (productGUID.Length <= 0)
									{
										goto end_IL_0012;
									}
									num = 1545203046;
								}
								continue;
								end_IL_0012:
								break;
							}
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
						return true;
					}
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
							if (productName == null || productName.Length == 0)
							{
								return true;
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
						num2 = 836554824;
						goto IL_0010;
					}
					goto IL_0039;
					IL_0010:
					while (true)
					{
						switch (num2 ^ 0x31DCD04E)
						{
						case 0:
							break;
						case 4:
							goto IL_0039;
						case 2:
							return true;
						case 5:
							goto IL_0058;
						case 3:
							goto IL_006f;
						case 6:
							num2 = 836554827;
							continue;
						default:
							return false;
						}
						break;
						IL_006f:
						if (string.IsNullOrEmpty(names[num]) || !MatchingCriteria_Base.StringMatches(searchIn, names[num], useRegex))
						{
							num++;
							num2 = 836554827;
						}
						else
						{
							num2 = 836554828;
						}
						continue;
						IL_0058:
						int num3;
						if (num >= names.Length)
						{
							num2 = 836554831;
							num3 = num2;
						}
						else
						{
							num2 = 836554829;
							num3 = num2;
						}
					}
					goto IL_000b;
					IL_0039:
					return false;
					IL_000b:
					num2 = 836554826;
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
					while (true)
					{
						int num = -51780205;
						while (true)
						{
							switch (num ^ -51780207)
							{
							case 3:
								break;
							default:
								return;
							case 2:
								if (matchingCriteria == null)
								{
									return;
								}
								goto case 1;
							case 0:
								matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								matchingCriteria.systemName = ArrayTools.ShallowCopy(systemName);
								matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
								num = -51780203;
								continue;
							case 1:
								matchingCriteria.hatCount = hatCount;
								matchingCriteria.manufacturer_useRegex = manufacturer_useRegex;
								matchingCriteria.productName_useRegex = productName_useRegex;
								matchingCriteria.systemName_useRegex = systemName_useRegex;
								num = -51780207;
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
			public sealed class Elements : Elements_Base
			{
				private sealed class KbuoYJGgDkQtrCmUnohDJGdVcFa : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
				{
					private Axis aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public Elements iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public int NIfRjTdlOuMUOBkXASBXJiLXFjy;

					Axis IEnumerator<Axis>.Current
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
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
						{
							goto IL_0012;
						}
						goto IL_0038;
						IL_0012:
						int num = 276229458;
						goto IL_0017;
						IL_0017:
						KbuoYJGgDkQtrCmUnohDJGdVcFa kbuoYJGgDkQtrCmUnohDJGdVcFa = default(KbuoYJGgDkQtrCmUnohDJGdVcFa);
						while (true)
						{
							switch (num ^ 0x1076ED51)
							{
							case 4:
								break;
							case 1:
								goto IL_0038;
							case 2:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
								kbuoYJGgDkQtrCmUnohDJGdVcFa = this;
								num = 276229457;
								continue;
							case 3:
								goto IL_0062;
							default:
								return kbuoYJGgDkQtrCmUnohDJGdVcFa;
							}
							break;
							IL_0062:
							int num2;
							if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg != -2)
							{
								num = 276229456;
								num2 = num;
							}
							else
							{
								num = 276229459;
								num2 = num;
							}
						}
						goto IL_0012;
						IL_0038:
						kbuoYJGgDkQtrCmUnohDJGdVcFa = new KbuoYJGgDkQtrCmUnohDJGdVcFa(0);
						kbuoYJGgDkQtrCmUnohDJGdVcFa.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = 276229457;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						case 1:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							NIfRjTdlOuMUOBkXASBXJiLXFjy++;
							num = 230545264;
							goto IL_001f;
						case 0:
							{
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num = 230545266;
								goto IL_001f;
							}
							IL_001f:
							while (true)
							{
								switch (num ^ 0xDBDD772)
								{
								case 3:
									num = 230545270;
									continue;
								case 6:
									aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.axes[NIfRjTdlOuMUOBkXASBXJiLXFjy];
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
									return true;
								case 0:
									break;
								case 5:
									NIfRjTdlOuMUOBkXASBXJiLXFjy = 0;
									num = 230545264;
									continue;
								case 4:
									goto end_IL_001f;
								case 2:
									goto IL_00cb;
								default:
									goto end_IL_0008;
								}
								int num2;
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.axes != null)
								{
									num = 230545271;
									num2 = num;
								}
								else
								{
									num = 230545267;
									num2 = num;
								}
								continue;
								IL_00cb:
								int num3;
								if (NIfRjTdlOuMUOBkXASBXJiLXFjy >= iKQXbXnVtIaMZEJNeigQJWAHqUx.axes.Length)
								{
									num = 230545267;
									num3 = num;
								}
								else
								{
									num = 230545268;
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
					public KbuoYJGgDkQtrCmUnohDJGdVcFa(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class garlAnpadRRYEHdAzEmbdFuQwmFr : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerable, IEnumerator<Button>
				{
					private Button aimBzjfQfPyaeQqysAQJISCBhELB;

					private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

					private int HbSVCfYbFQknCSDIuBJpKcqKonb;

					public Elements iKQXbXnVtIaMZEJNeigQJWAHqUx;

					public int LRNLKecJjYHZETQMLIanETpATzm;

					Button IEnumerator<Button>.Current
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
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
						{
							goto IL_0012;
						}
						goto IL_0040;
						IL_0012:
						int num = 1072211002;
						goto IL_0017;
						IL_0017:
						garlAnpadRRYEHdAzEmbdFuQwmFr garlAnpadRRYEHdAzEmbdFuQwmFr2 = default(garlAnpadRRYEHdAzEmbdFuQwmFr);
						while (true)
						{
							switch (num ^ 0x3FE8A43B)
							{
							case 3:
								break;
							case 4:
								goto IL_0040;
							case 2:
								garlAnpadRRYEHdAzEmbdFuQwmFr2 = this;
								num = 1072211003;
								continue;
							case 5:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
								num = 1072211001;
								continue;
							case 0:
								num = 1072211005;
								continue;
							case 1:
								goto IL_0078;
							default:
								return garlAnpadRRYEHdAzEmbdFuQwmFr2;
							}
							break;
							IL_0078:
							int num2;
							if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg != -2)
							{
								num = 1072211007;
								num2 = num;
							}
							else
							{
								num = 1072211006;
								num2 = num;
							}
						}
						goto IL_0012;
						IL_0040:
						garlAnpadRRYEHdAzEmbdFuQwmFr2 = new garlAnpadRRYEHdAzEmbdFuQwmFr(0);
						garlAnpadRRYEHdAzEmbdFuQwmFr2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = 1072211005;
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
						switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
						{
						default:
							num = -1468494229;
							goto IL_001a;
						case 0:
							goto IL_0067;
						case 1:
							{
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num = -1468494239;
								goto IL_001a;
							}
							IL_001a:
							while (true)
							{
								switch (num ^ -1468494232)
								{
								case 4:
									break;
								case 9:
									LRNLKecJjYHZETQMLIanETpATzm++;
									num = -1468494225;
									continue;
								case 8:
									goto IL_0067;
								case 3:
									num = -1468494227;
									continue;
								case 6:
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
									return true;
								case 2:
									num = -1468494225;
									continue;
								case 1:
									if (iKQXbXnVtIaMZEJNeigQJWAHqUx.buttons != null)
									{
										LRNLKecJjYHZETQMLIanETpATzm = 0;
										num = -1468494230;
										continue;
									}
									goto default;
								case 7:
									goto IL_00b8;
								case 0:
									aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.buttons[LRNLKecJjYHZETQMLIanETpATzm];
									num = -1468494226;
									continue;
								default:
									return false;
								}
								break;
								IL_00b8:
								int num2;
								if (LRNLKecJjYHZETQMLIanETpATzm < iKQXbXnVtIaMZEJNeigQJWAHqUx.buttons.Length)
								{
									num = -1468494232;
									num2 = num;
								}
								else
								{
									num = -1468494227;
									num2 = num;
								}
							}
							goto default;
							IL_0067:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							num = -1468494231;
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
					public garlAnpadRRYEHdAzEmbdFuQwmFr(int _003C_003E1__state)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
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
						KbuoYJGgDkQtrCmUnohDJGdVcFa kbuoYJGgDkQtrCmUnohDJGdVcFa = new KbuoYJGgDkQtrCmUnohDJGdVcFa(-2);
						kbuoYJGgDkQtrCmUnohDJGdVcFa.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
						return kbuoYJGgDkQtrCmUnohDJGdVcFa;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					get
					{
						garlAnpadRRYEHdAzEmbdFuQwmFr garlAnpadRRYEHdAzEmbdFuQwmFr2 = new garlAnpadRRYEHdAzEmbdFuQwmFr(-2);
						garlAnpadRRYEHdAzEmbdFuQwmFr2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
						return garlAnpadRRYEHdAzEmbdFuQwmFr2;
					}
				}

				internal Axis GetAxis(int axisIndex)
				{
					if (axes != null)
					{
						while (true)
						{
							int num = -208532173;
							while (true)
							{
								switch (num ^ -208532175)
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
									num = -208532176;
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
						IL_004c:
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = -451141246;
							goto IL_0009;
						}
						goto IL_002a;
						IL_0009:
						while (true)
						{
							switch (num3 ^ -451141246)
							{
							case 4:
								num3 = -451141245;
								continue;
							case 1:
								break;
							case 3:
								goto IL_004c;
							case 2:
								goto IL_005e;
							default:
								if (num2 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								goto IL_005e;
							}
							break;
							IL_005e:
							if (buttons[num2].elementIdentifier == elementIdentifier.id)
							{
								return ControllerElementType.Button;
							}
							num2++;
							num3 = -451141246;
						}
						goto IL_002a;
						IL_002a:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							break;
						}
						num++;
						num3 = -451141247;
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
							IL_00c6:
							int num2;
							if (axes[num].elementIdentifier == elementIdentifier.id)
							{
								switch (axes[num].sourceType)
								{
								case HardwareElementSourceTypeWithHat.Button:
									break;
								case HardwareElementSourceTypeWithHat.Axis:
									goto IL_0048;
								default:
									throw new NotImplementedException();
								case HardwareElementSourceTypeWithHat.Hat:
									goto IL_0095;
								case HardwareElementSourceTypeWithHat.Custom:
									goto IL_0100;
								}
								axisRange = AxisRange.Positive;
								num2 = 1442057824;
								goto IL_000c;
							}
							goto IL_0076;
							IL_0081:
							return true;
							IL_0100:
							num2 = 1442057829;
							goto IL_000c;
							IL_0095:
							axisRange = axes[num].sourceHatRange;
							if (axes[num].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
								num2 = 1442057828;
								goto IL_000c;
							}
							goto IL_0081;
							IL_003c:
							return true;
							IL_0048:
							axisRange = axes[num].sourceAxisRange;
							if (axes[num].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
								num2 = 1442057827;
								goto IL_000c;
							}
							goto IL_003c;
							IL_0076:
							num++;
							num2 = 1442057825;
							goto IL_000c;
							IL_000c:
							while (true)
							{
								switch (num2 ^ 0x55F40E67)
								{
								case 5:
									num2 = 1442057830;
									continue;
								case 4:
									break;
								case 2:
									goto IL_0048;
								case 0:
									goto IL_0076;
								case 3:
									goto IL_0081;
								case 7:
									return true;
								case 1:
									goto IL_00c6;
								default:
									goto end_IL_00c6;
								}
								break;
							}
							goto IL_003c;
							continue;
							end_IL_00c6:
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
						int num = -1730975024;
						while (true)
						{
							switch (num ^ -1730975023)
							{
							case 0:
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
							case 2:
								goto IL_003b;
							case 3:
								return;
							}
							break;
							IL_003b:
							elements.axes = ArrayTools.DeepClone(axes);
							elements.buttons = ArrayTools.DeepClone(buttons);
							num = -1730975022;
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
						int num = 348764979;
						while (true)
						{
							switch (num ^ 0x14C9BB33)
							{
							case 2:
								num = 348764982;
								continue;
							case 3:
								ignoreIfButtonsActive = button.ignoreIfButtonsActive;
								num = 348764983;
								continue;
							case 4:
								ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(button.ignoreIfButtonsActiveButtons);
								num = 348764978;
								continue;
							case 5:
								break;
							case 0:
								sourceType = button.sourceType;
								sourceButton = button.sourceButton;
								sourceAxis = button.sourceAxis;
								sourceAxisPole = button.sourceAxisPole;
								axisDeadZone = button.axisDeadZone;
								sourceHat = button.sourceHat;
								sourceHatType = button.sourceHatType;
								sourceHatDirection = button.sourceHatDirection;
								requireMultipleButtons = button.requireMultipleButtons;
								requiredButtons = ArrayTools.ShallowCopy(button.requiredButtons);
								num = 348764976;
								continue;
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
					axis.ImportVars(this);
					return axis;
				}

				protected override void ImportVars(Element source)
				{
					base.ImportVars(source);
					Axis axis = source as Axis;
					if (axis == null)
					{
						goto IL_0014;
					}
					goto IL_00c0;
					IL_0014:
					int num = 1405360070;
					goto IL_0019;
					IL_0019:
					while (true)
					{
						switch (num ^ 0x53C417C7)
						{
						case 4:
							break;
						case 1:
							return;
						case 2:
							sourceAxisRange = axis.sourceAxisRange;
							invert = axis.invert;
							axisDeadZone = axis.axisDeadZone;
							calibrateAxis = axis.calibrateAxis;
							axisZero = axis.axisZero;
							axisMin = axis.axisMin;
							axisMax = axis.axisMax;
							axisInfo = MiscTools.DeepClone(axis.axisInfo);
							sourceButton = axis.sourceButton;
							num = 1405360071;
							continue;
						case 3:
							goto IL_00c0;
						default:
							buttonAxisContribution = axis.buttonAxisContribution;
							sourceHat = axis.sourceHat;
							sourceHatDirection = axis.sourceHatDirection;
							sourceHatRange = axis.sourceHatRange;
							alternateCalibrations = MiscTools.DeepClone(axis.alternateCalibrations);
							return;
						}
						break;
					}
					goto IL_0014;
					IL_00c0:
					elementIdentifier = axis.elementIdentifier;
					sourceType = axis.sourceType;
					sourceAxis = axis.sourceAxis;
					num = 1405360069;
					goto IL_0019;
				}
			}

			private sealed class kafoMHTCEBSuWZugUqdctSxtDWh : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_SDL2_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int mJWCQScTkRGHZcjHCxkOPSZOMufV;

				public int NRYdrkHPpfrBFstAnovltGKFNyez;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					kafoMHTCEBSuWZugUqdctSxtDWh kafoMHTCEBSuWZugUqdctSxtDWh2;
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						kafoMHTCEBSuWZugUqdctSxtDWh2 = this;
					}
					else
					{
						while (true)
						{
							kafoMHTCEBSuWZugUqdctSxtDWh2 = new kafoMHTCEBSuWZugUqdctSxtDWh(0);
							kafoMHTCEBSuWZugUqdctSxtDWh2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
							int num = 107391328;
							while (true)
							{
								switch (num ^ 0x666A960)
								{
								case 2:
									num = 107391329;
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
					return kafoMHTCEBSuWZugUqdctSxtDWh2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 0:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						int num2;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements != null)
						{
							num = 90553129;
							num2 = num;
						}
						else
						{
							num = 90553133;
							num2 = num;
						}
						goto IL_001f;
					}
					case 1:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							NRYdrkHPpfrBFstAnovltGKFNyez++;
							num = 90553130;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x565BB2F)
							{
							case 0:
								num = 90553131;
								continue;
							case 4:
								break;
							case 3:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes[NRYdrkHPpfrBFstAnovltGKFNyez];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 1:
								NRYdrkHPpfrBFstAnovltGKFNyez = 0;
								num = 90553130;
								continue;
							case 5:
								goto IL_00c6;
							case 6:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes != null)
								{
									mJWCQScTkRGHZcjHCxkOPSZOMufV = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes.Length;
									num = 90553134;
									continue;
								}
								goto end_IL_0008;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00c6:
							int num3;
							if (NRYdrkHPpfrBFstAnovltGKFNyez < mJWCQScTkRGHZcjHCxkOPSZOMufV)
							{
								num = 90553132;
								num3 = num;
							}
							else
							{
								num = 90553133;
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
				public kafoMHTCEBSuWZugUqdctSxtDWh(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class YoWglOGGycCWsmMELUUkxISRbKN : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerable, IEnumerator<Button>
			{
				private Button aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_SDL2_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int fTUMIAywcbGHwoUSfDmIFBCdZVh;

				public int leEetrbmTYepZrXwPPOrhZPmhdl;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						goto IL_001c;
					}
					goto IL_004e;
					IL_004e:
					YoWglOGGycCWsmMELUUkxISRbKN yoWglOGGycCWsmMELUUkxISRbKN = new YoWglOGGycCWsmMELUUkxISRbKN(0);
					yoWglOGGycCWsmMELUUkxISRbKN.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					int num = -531433911;
					goto IL_0021;
					IL_001c:
					num = -531433909;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ -531433912)
						{
						case 2:
							break;
						case 3:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							yoWglOGGycCWsmMELUUkxISRbKN = this;
							num = -531433911;
							continue;
						case 0:
							goto IL_004e;
						default:
							return yoWglOGGycCWsmMELUUkxISRbKN;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 0:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = -327924853;
						goto IL_001f;
					case 1:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							num = -327924860;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -327924862)
							{
							case 8:
								num = -327924858;
								continue;
							case 4:
								break;
							case 9:
								goto IL_0065;
							case 7:
								num = -327924862;
								continue;
							case 3:
								return true;
							case 1:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons != null)
								{
									fTUMIAywcbGHwoUSfDmIFBCdZVh = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons.Length;
									leEetrbmTYepZrXwPPOrhZPmhdl = 0;
									num = -327924859;
									continue;
								}
								goto end_IL_0008;
							case 0:
								goto IL_00d8;
							case 6:
								leEetrbmTYepZrXwPPOrhZPmhdl++;
								num = -327924862;
								continue;
							case 2:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons[leEetrbmTYepZrXwPPOrhZPmhdl];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = -327924863;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00d8:
							int num2;
							if (leEetrbmTYepZrXwPPOrhZPmhdl >= fTUMIAywcbGHwoUSfDmIFBCdZVh)
							{
								num = -327924857;
								num2 = num;
							}
							else
							{
								num = -327924864;
								num2 = num;
							}
							continue;
							IL_0065:
							int num3;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements != null)
							{
								num = -327924861;
								num3 = num;
							}
							else
							{
								num = -327924857;
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
				public YoWglOGGycCWsmMELUUkxISRbKN(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform
			{
				get
				{
					return InputPlatform.xzaOPbUxziNeuflqekRIWgtGJg;
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
				if (num < elements.axisCount)
				{
					goto IL_0015;
				}
				string[] array = new string[elements.axisCount];
				int num2 = -2034668745;
				goto IL_001a;
				IL_001a:
				int num3 = default(int);
				int num5 = default(int);
				int num4 = default(int);
				while (true)
				{
					switch (num2 ^ -2034668748)
					{
					case 0:
						break;
					case 4:
						array[num3] = identifiers[num5].name;
						num2 = -2034668751;
						continue;
					case 6:
						if (num5 >= 0)
						{
							int num6;
							if (num5 < num)
							{
								num2 = -2034668752;
								num6 = num2;
							}
							else
							{
								num2 = -2034668740;
								num6 = num2;
							}
							continue;
						}
						goto case 8;
					case 1:
						Logger.LogError("You have too few element identifiers!");
						num2 = -2034668739;
						continue;
					case 2:
					{
						int elementIdentifier = elements.axes[num3].elementIdentifier;
						num5 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						num2 = -2034668750;
						continue;
					}
					case 5:
						num3++;
						num2 = -2034668749;
						continue;
					case 8:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = -2034668751;
						continue;
					case 3:
						num4 = array.Length;
						num3 = 0;
						num2 = -2034668749;
						continue;
					case 9:
						return new string[0];
					default:
						if (num3 >= num4)
						{
							return array;
						}
						goto case 2;
					}
					break;
				}
				goto IL_0015;
				IL_0015:
				num2 = -2034668747;
				goto IL_001a;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				int num4 = default(int);
				string[] array = default(string[]);
				int num2 = default(int);
				int num3 = default(int);
				int elementIdentifier = default(int);
				while (true)
				{
					int num = -743598788;
					while (true)
					{
						switch (num ^ -743598794)
						{
						case 8:
							break;
						case 10:
							num4 = identifiers.Length;
							if (num4 < buttonCount)
							{
								Logger.LogError("You have too few element identifiers!");
								num = -743598796;
							}
							else
							{
								array = new string[buttonCount];
								num = -743598797;
							}
							continue;
						case 4:
							num2++;
							num = -743598785;
							continue;
						case 7:
							array[num2] = identifiers[num3].name;
							num = -743598798;
							continue;
						case 6:
						{
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							int num6;
							if (num3 >= 0)
							{
								num = -743598795;
								num6 = num;
							}
							else
							{
								num = -743598794;
								num6 = num;
							}
							continue;
						}
						case 5:
							num2 = 0;
							num = -743598785;
							continue;
						case 3:
						{
							int num5;
							if (num3 < num4)
							{
								num = -743598799;
								num5 = num;
							}
							else
							{
								num = -743598794;
								num5 = num;
							}
							continue;
						}
						case 0:
							Logger.LogError("Element identifier index is out of bounds!");
							num = -743598798;
							continue;
						case 2:
							return new string[0];
						case 1:
							elementIdentifier = elements.buttons[num2].elementIdentifier;
							num = -743598800;
							continue;
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
				IEnumerator<Axis> enumerator = IterateAxes().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Axis current = enumerator.Current;
						if (current.elementIdentifier == elementIdentifierId)
						{
							return true;
						}
					}
				}
				finally
				{
					if (enumerator != null)
					{
						while (true)
						{
							IL_0057:
							int num = -1626864496;
							while (true)
							{
								switch (num ^ -1626864495)
								{
								case 2:
									break;
								default:
									goto end_IL_005c;
								case 1:
									goto IL_0075;
								case 0:
									goto end_IL_005c;
								}
								goto IL_0057;
								IL_0075:
								enumerator.Dispose();
								num = -1626864495;
								continue;
								end_IL_005c:
								break;
							}
							break;
						}
					}
				}
				using (IEnumerator<Button> enumerator2 = IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Button current2 = enumerator2.Current;
							int num2 = -1626864496;
							while (true)
							{
								switch (num2 ^ -1626864495)
								{
								case 0:
									num2 = -1626864494;
									continue;
								case 3:
									break;
								case 4:
									return true;
								case 1:
									goto IL_00d2;
								default:
									goto end_IL_00b8;
								}
								break;
								IL_00d2:
								int num3;
								if (current2.elementIdentifier != elementIdentifierId)
								{
									num2 = -1626864493;
									num3 = num2;
								}
								else
								{
									num2 = -1626864491;
									num3 = num2;
								}
							}
							continue;
							end_IL_00b8:
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
						IL_0068:
						int num2;
						int num3;
						if (enumerator.MoveNext())
						{
							num2 = 777608121;
							num3 = num2;
						}
						else
						{
							num2 = 777608120;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x2E595BB8)
							{
							case 2:
								num2 = 777608121;
								continue;
							default:
								goto end_IL_002f;
							case 1:
							{
								Button current = enumerator.Current;
								buttons[num] = current.elementIdentifier;
								num++;
								num2 = 777608123;
								continue;
							}
							case 3:
								break;
							case 0:
								goto end_IL_002f;
							}
							goto IL_0068;
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
							int num4 = 777608122;
							while (true)
							{
								switch (num4 ^ 0x2E595BB8)
								{
								case 0:
									num4 = 777608121;
									continue;
								case 1:
									break;
								default:
									goto end_IL_00bc;
								}
								break;
							}
							continue;
							end_IL_00bc:
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
					int num = 1748930673;
					while (true)
					{
						switch (num ^ 0x683E9072)
						{
						case 6:
							break;
						case 3:
							if (axes_orig == null)
							{
								num = 1748930679;
								continue;
							}
							array = new AxisCalibrationData[axes_orig.Length];
							num2 = 0;
							num = 1748930675;
							continue;
						case 4:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
							num = 1748930681;
							continue;
						case 9:
						{
							int num5;
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								num = 1748930672;
								num5 = num;
							}
							else
							{
								num = 1748930680;
								num5 = num;
							}
							continue;
						}
						case 5:
							return null;
						case 12:
							num = 1748930678;
							continue;
						case 7:
							array[num2] = AxisCalibrationData.Default;
							num = 1748930678;
							continue;
						case 8:
						{
							int num6;
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								num = 1748930687;
								num6 = num;
							}
							else
							{
								num = 1748930677;
								num6 = num;
							}
							continue;
						}
						case 2:
						{
							int num4;
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Custom)
							{
								num = 1748930682;
								num4 = num;
							}
							else
							{
								num = 1748930680;
								num4 = num;
							}
							continue;
						}
						case 0:
							throw new NotImplementedException();
						case 11:
							num2++;
							num = 1748930675;
							continue;
						case 13:
						{
							int num3;
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Hat)
							{
								num = 1748930674;
								num3 = num;
							}
							else
							{
								num = 1748930677;
								num3 = num;
							}
							continue;
						}
						case 10:
							array[num2] = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							if (Axes_orig[num2].calibrateAxis)
							{
								array[num2].zero = axes_orig[num2].axisZero;
								array[num2].min = axes_orig[num2].axisMin;
								array[num2].max = axes_orig[num2].axisMax;
								num = 1748930686;
								continue;
							}
							goto case 4;
						default:
							if (num2 >= axes_orig.Length)
							{
								return array;
							}
							goto case 9;
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
					int num2 = 1424259486;
					while (true)
					{
						switch (num2 ^ 0x54E47998)
						{
						case 0:
							num2 = 1424259482;
							continue;
						default:
							return;
						case 2:
							break;
						case 7:
							if (Axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num5;
								if (Axes_orig[num].sourceType == HardwareElementSourceTypeWithHat.Hat)
								{
									num2 = 1424259475;
									num5 = num2;
								}
								else
								{
									num2 = 1424259476;
									num5 = num2;
								}
								continue;
							}
							goto case 11;
						case 13:
							axisRanges[num] = Axes_orig[num].sourceAxisRange;
							num2 = 1424259474;
							continue;
						case 8:
						{
							axisInfos[num] = MiscTools.DeepClone(Axes_orig[num].axisInfo, true);
							int num6;
							if (Axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								num2 = 1424259485;
								num6 = num2;
							}
							else
							{
								num2 = 1424259477;
								num6 = num2;
							}
							continue;
						}
						case 10:
							num2 = 1424259481;
							continue;
						case 12:
							throw new Exception();
						case 6:
							num2 = 1424259483;
							continue;
						case 1:
							num++;
							num2 = 1424259483;
							continue;
						case 3:
						{
							int num4;
							if (num >= Axes_orig.Length)
							{
								num2 = 1424259484;
								num4 = num2;
							}
							else
							{
								num2 = 1424259472;
								num4 = num2;
							}
							continue;
						}
						case 5:
						{
							int num3;
							if (Axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Custom)
							{
								num2 = 1424259487;
								num3 = num2;
							}
							else
							{
								num2 = 1424259477;
								num3 = num2;
							}
							continue;
						}
						case 11:
							axisRanges[num] = AxisRange.Full;
							num2 = 1424259473;
							continue;
						case 9:
							num2 = 1424259481;
							continue;
						case 4:
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
				int num2 = default(int);
				while (true)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					int num = 1365031818;
					while (true)
					{
						switch (num ^ 0x515CBB8E)
						{
						case 3:
							num = 1365031823;
							continue;
						case 1:
							break;
						case 2:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, true);
							num2++;
							num = 1365031822;
							continue;
						case 4:
							num2 = 0;
							num = 1365031822;
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
				kafoMHTCEBSuWZugUqdctSxtDWh kafoMHTCEBSuWZugUqdctSxtDWh2 = new kafoMHTCEBSuWZugUqdctSxtDWh(-2);
				kafoMHTCEBSuWZugUqdctSxtDWh2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return kafoMHTCEBSuWZugUqdctSxtDWh2;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				YoWglOGGycCWsmMELUUkxISRbKN yoWglOGGycCWsmMELUUkxISRbKN = new YoWglOGGycCWsmMELUUkxISRbKN(-2);
				yoWglOGGycCWsmMELUUkxISRbKN.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return yoWglOGGycCWsmMELUUkxISRbKN;
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
				if (platform_SDL2_Base == null)
				{
					while (true)
					{
						switch (-1880184200 ^ -1880184199)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				platform_SDL2_Base.elements = MiscTools.DeepClone(elements);
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
					return true;
				}
				if (base.hasVariants)
				{
					int num2 = default(int);
					while (true)
					{
						int num = 2059148035;
						while (true)
						{
							switch (num ^ 0x7ABC1B00)
							{
							case 0:
								break;
							case 1:
								goto IL_003d;
							case 4:
								goto IL_0059;
							case 3:
								num2 = 0;
								num = 2059148033;
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
							num = 2059148033;
							continue;
							IL_003d:
							int num3;
							if (num2 < variants.Length)
							{
								num = 2059148036;
								num3 = num;
							}
							else
							{
								num = 2059148034;
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
				Platform_SDL2 platform_SDL = new Platform_SDL2();
				CopyVars(platform_SDL);
				return platform_SDL;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_SDL2 platform_SDL = default(Platform_SDL2);
				while (true)
				{
					int num = 1189446409;
					while (true)
					{
						switch (num ^ 0x46E5830A)
						{
						case 0:
							break;
						case 3:
							platform_SDL = destination as Platform_SDL2;
							num = 1189446411;
							continue;
						case 1:
						{
							int num2;
							if (platform_SDL == null)
							{
								num = 1189446414;
								num2 = num;
							}
							else
							{
								num = 1189446408;
								num2 = num;
							}
							continue;
						}
						case 4:
							return;
						default:
							platform_SDL.variants = MiscTools.DeepClone(variants);
							return;
						}
						break;
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
					return InputPlatform.gBTkPmAyPkhrIHErFhGGXZEcsey;
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
					if (matchingCriteria.hasData)
					{
						if (assignedAxisCount != 0)
						{
							goto IL_0066;
						}
						num = 1803057853;
					}
					else
					{
						num = 1803057855;
					}
					goto IL_000d;
					IL_0008:
					num = 1803057854;
					goto IL_000d;
					IL_000d:
					while (true)
					{
						switch (num ^ 0x6B787ABC)
						{
						case 0:
							break;
						case 1:
							goto IL_002e;
						case 3:
							return false;
						case 2:
							return false;
						default:
							return false;
						}
						break;
						IL_002e:
						if (assignedButtonCount == 0)
						{
							num = 1803057848;
							continue;
						}
						goto IL_0066;
					}
					goto IL_0008;
					IL_0066:
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
					int num = 1142956641;
					while (true)
					{
						switch (num ^ 0x44202260)
						{
						case 0:
							break;
						case 1:
							platformMap = null;
							if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
							{
								goto IL_003c;
							}
							return false;
						default:
							return true;
						}
						break;
						IL_003c:
						platformMap = this;
						num = 1142956642;
					}
				}
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
						int num = -692364899;
						while (true)
						{
							switch (num ^ -692364897)
							{
							case 0:
								break;
							case 2:
								goto IL_0026;
							default:
								return false;
							}
							break;
							IL_0026:
							axisRange = AxisRange.Full;
							num = -692364898;
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
						if (num >= variants.Length)
						{
							num2 = -664845168;
							num3 = num2;
						}
						else
						{
							num2 = -664845163;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -664845167)
							{
							case 3:
								num2 = -664845163;
								continue;
							case 4:
								break;
							case 0:
								goto IL_0052;
							case 2:
								goto end_IL_0020;
							default:
								goto end_IL_0077;
							}
							if (variants[num] != null)
							{
								num2 = -664845167;
								continue;
							}
							goto IL_006c;
							IL_0052:
							int variantIndex2;
							if (variants[num].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
							{
								variantIndex = num;
								return true;
							}
							goto IL_006c;
							IL_006c:
							num++;
							num2 = -664845165;
							continue;
							end_IL_0020:
							break;
						}
						continue;
						end_IL_0077:
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
					return;
				}
				while (true)
				{
					platform_Steam.variants = MiscTools.DeepClone(variants);
					int num = -2041743156;
					while (true)
					{
						switch (num ^ -2041743155)
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
						num = -2041743153;
					}
				}
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
						clientInfo.browser = browser;
						while (true)
						{
							int num = -950175665;
							while (true)
							{
								switch (num ^ -950175667)
								{
								case 0:
									break;
								case 2:
									clientInfo.browserVersionMin = browserVersionMin;
									clientInfo.browserVersionMax = browserVersionMax;
									num = -950175668;
									continue;
								case 1:
									clientInfo.os = os;
									clientInfo.osVersionMin = osVersionMin;
									clientInfo.osVersionMax = osVersionMax;
									num = -950175666;
									continue;
								default:
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
						int num;
						if (productName != null)
						{
							num = 1353381876;
							goto IL_000d;
						}
						goto IL_0077;
						IL_0086:
						if (productGUID.Length > 0)
						{
							return true;
						}
						goto IL_0093;
						IL_004a:
						if (productGUID != null)
						{
							num = 1353381873;
							goto IL_000d;
						}
						goto IL_0093;
						IL_0008:
						num = 1353381879;
						goto IL_000d;
						IL_000d:
						while (true)
						{
							switch (num ^ 0x50AAF7F2)
							{
							case 2:
								break;
							case 1:
								goto IL_0036;
							case 0:
								return true;
							case 5:
								return true;
							case 6:
								goto IL_006a;
							case 3:
								goto IL_0086;
							default:
								return true;
							}
							break;
							IL_0036:
							if (mapping.Length > 0)
							{
								num = 1353381874;
								continue;
							}
							goto IL_004a;
						}
						goto IL_0008;
						IL_0077:
						if (mapping != null)
						{
							num = 1353381875;
							goto IL_000d;
						}
						goto IL_004a;
						IL_006a:
						if (productName.Length > 0)
						{
							return true;
						}
						goto IL_0077;
						IL_0093:
						if (elementCount != null && elementCount.Length > 0)
						{
							num = 1353381878;
							goto IL_000d;
						}
						if (clientInfo != null && clientInfo.Length > 0)
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
					goto IL_057c;
					IL_059d:
					bool flag = default(bool);
					if (flag)
					{
						return true;
					}
					bool flag2 = default(bool);
					if (flag2)
					{
						return false;
					}
					bool result = default(bool);
					return result;
					IL_0016:
					int num = 1092609730;
					goto IL_001b;
					IL_001b:
					int num4 = default(int);
					ElementCount_Base elementCount_Base = default(ElementCount_Base);
					int num7 = default(int);
					int num5 = default(int);
					string text = default(string);
					int num3 = default(int);
					bool flag3 = default(bool);
					bool flag4 = default(bool);
					ClientInfo clientInfo = default(ClientInfo);
					int num2 = default(int);
					string text2 = default(string);
					bool flag5 = default(bool);
					while (true)
					{
						switch (num ^ 0x411FE6C1)
						{
						case 6:
							break;
						case 21:
							flag2 = true;
							num4 = 0;
							num = 1092609743;
							continue;
						case 30:
							goto IL_00e7;
						case 4:
							return false;
						case 11:
							elementCount_Base = elementCount[num7];
							if (elementCount_Base != null)
							{
								goto IL_015d;
							}
							goto case 0;
						case 1:
							if (productGUID != null && productGUID.Length > 0 && !ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
							{
								flag2 = true;
								num5 = 0;
								num = 1092609755;
								continue;
							}
							goto IL_022f;
						case 32:
							flag = true;
							num = 1092609731;
							continue;
						case 40:
							goto IL_01d2;
						case 36:
							if (text == null)
							{
								text = string.Empty;
								num = 1092609754;
								continue;
							}
							goto IL_045d;
						case 42:
							goto IL_01f8;
						case 34:
							if (num7 < elementCount.Length)
							{
								goto case 11;
							}
							goto IL_021d;
						case 22:
							goto IL_022f;
						case 24:
							goto IL_024c;
						case 9:
							goto IL_025c;
						case 19:
							goto IL_028c;
						case 18:
						{
							int num6 = mapping[num3];
							if (num6 == (int)bridgedControllerHWInfo.webGL_mappingType)
							{
								flag3 = true;
								num = 1092609762;
								continue;
							}
							goto case 35;
						}
						case 16:
							goto IL_02d0;
						case 0:
							num7++;
							num = 1092609763;
							continue;
						case 8:
							goto IL_0309;
						case 38:
							flag4 = true;
							num = 1092609729;
							continue;
						case 29:
							return false;
						case 26:
							goto IL_0349;
						case 5:
							goto IL_0369;
						case 33:
							num5++;
							num = 1092609755;
							continue;
						case 28:
							return true;
						case 7:
							goto IL_03bd;
						case 41:
							goto IL_03e0;
						case 12:
							if (bridgedControllerHWInfo.hw_pidVid.Equals(productGUID[num5]))
							{
								flag = true;
								num = 1092609751;
								continue;
							}
							goto case 33;
						case 25:
							num4++;
							num = 1092609743;
							continue;
						case 23:
							goto IL_0445;
						case 27:
							goto IL_045d;
						case 15:
							flag3 = false;
							num3 = 0;
							num = 1092609749;
							continue;
						case 20:
							if (num3 < mapping.Length)
							{
								goto case 18;
							}
							goto IL_0498;
						case 17:
							clientInfo = this.clientInfo[num2];
							num = 1092609750;
							continue;
						case 35:
							num3++;
							num = 1092609749;
							continue;
						case 10:
							return false;
						case 31:
							goto IL_04db;
						case 39:
							goto IL_04fe;
						case 37:
							goto IL_0528;
						case 13:
							return false;
						case 14:
							goto IL_0552;
						case 3:
							goto IL_0572;
						default:
							goto IL_059d;
						}
						break;
						IL_0552:
						int num8;
						if (num4 >= productName.Length)
						{
							num = 1092609731;
							num8 = num;
						}
						else
						{
							num = 1092609736;
							num8 = num;
						}
						continue;
						IL_045d:
						int num9;
						if (productName != null)
						{
							num = 1092609746;
							num9 = num;
						}
						else
						{
							num = 1092609731;
							num9 = num;
						}
						continue;
						IL_025c:
						string searchFor = productName[num4];
						int num10;
						if (!MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
						{
							num = 1092609752;
							num10 = num;
						}
						else
						{
							num = 1092609761;
							num10 = num;
						}
						continue;
						IL_0528:
						if (!string.Equals(bridgedControllerHWInfo.definitionMatchTag, text2, StringComparison.OrdinalIgnoreCase))
						{
							num = 1092609756;
							continue;
						}
						goto IL_0328;
						IL_01d2:
						num2++;
						num = 1092609732;
						continue;
						IL_04db:
						int num11;
						if (elementCount_Base.axisCount == bridgedControllerHWInfo.hardwareAxisCount)
						{
							num = 1092609767;
							num11 = num;
						}
						else
						{
							num = 1092609729;
							num11 = num;
						}
						continue;
						IL_022f:
						if (flag)
						{
							return true;
						}
						text = StringTools.Trim(bridgedControllerHWInfo.hw_productName);
						num = 1092609765;
						continue;
						IL_024c:
						if (!flag5)
						{
							num = 1092609739;
							continue;
						}
						result = true;
						num = 1092609745;
						continue;
						IL_0498:
						if (!flag3)
						{
							num = 1092609740;
							continue;
						}
						result = true;
						num = 1092609737;
						continue;
						IL_028c:
						int num12;
						if (productName.Length > 0)
						{
							num = 1092609748;
							num12 = num;
						}
						else
						{
							num = 1092609731;
							num12 = num;
						}
						continue;
						IL_0107:
						if (clientInfo.os != 0)
						{
							if (clientInfo.os != (int)bridgedControllerHWInfo.webGL_osType)
							{
								goto IL_01d2;
							}
							if (!CheckOSVersion(clientInfo.osVersionMin, clientInfo.osVersionMax, bridgedControllerHWInfo.webGL_osVersionSplit))
							{
								return false;
							}
						}
						flag5 = true;
						num = 1092609753;
						continue;
						IL_0445:
						int num13;
						if (clientInfo != null)
						{
							num = 1092609771;
							num13 = num;
						}
						else
						{
							num = 1092609769;
							num13 = num;
						}
						continue;
						IL_021d:
						if (!flag4)
						{
							return false;
						}
						result = true;
						num = 1092609766;
						continue;
						IL_0349:
						int num14;
						if (num5 < productGUID.Length)
						{
							num = 1092609741;
							num14 = num;
						}
						else
						{
							num = 1092609751;
							num14 = num;
						}
						continue;
						IL_03e0:
						if (!CheckBrowserVersion(clientInfo.browser, clientInfo.browserVersionMin, clientInfo.browserVersionMax, bridgedControllerHWInfo.webGL_webBrowserVersionSplit))
						{
							num = 1092609733;
							continue;
						}
						goto IL_0107;
						IL_00e7:
						int num15;
						if (elementCount_Base.axisCount < 0)
						{
							num = 1092609767;
							num15 = num;
						}
						else
						{
							num = 1092609758;
							num15 = num;
						}
						continue;
						IL_03bd:
						int num16;
						if (clientInfo.browser != (int)bridgedControllerHWInfo.webGL_webBrowserType)
						{
							num = 1092609769;
							num16 = num;
						}
						else
						{
							num = 1092609768;
							num16 = num;
						}
						continue;
						IL_01f8:
						if (clientInfo.browser != 0)
						{
							num = 1092609734;
							continue;
						}
						goto IL_0107;
						IL_015d:
						if (elementCount_Base.buttonCount >= 0)
						{
							int num17;
							if (elementCount_Base.buttonCount != bridgedControllerHWInfo.hardwareButtonCount)
							{
								num = 1092609729;
								num17 = num;
							}
							else
							{
								num = 1092609759;
								num17 = num;
							}
							continue;
						}
						goto IL_00e7;
						IL_0369:
						int num18;
						if (num2 >= this.clientInfo.Length)
						{
							num = 1092609753;
							num18 = num;
						}
						else
						{
							num = 1092609744;
							num18 = num;
						}
					}
					goto IL_0016;
					IL_04fe:
					if (mapping != null)
					{
						int num19;
						if (mapping.Length > 0)
						{
							num = 1092609742;
							num19 = num;
						}
						else
						{
							num = 1092609737;
							num19 = num;
						}
						goto IL_001b;
					}
					goto IL_0309;
					IL_0328:
					if (this.clientInfo != null && this.clientInfo.Length > 0)
					{
						flag5 = false;
						num2 = 0;
						num = 1092609732;
						goto IL_001b;
					}
					goto IL_02d0;
					IL_02d0:
					if (elementCount != null && elementCount.Length > 0)
					{
						flag4 = false;
						num7 = 0;
						num = 1092609763;
						goto IL_001b;
					}
					goto IL_04fe;
					IL_0309:
					flag = false;
					flag2 = false;
					num = 1092609728;
					goto IL_001b;
					IL_0572:
					if (isAllowed)
					{
						return true;
					}
					goto IL_057c;
					IL_057c:
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (!alwaysMatch)
					{
						result = false;
						text2 = StringTools.Trim(tag);
						if (string.IsNullOrEmpty(text2))
						{
							goto IL_0328;
						}
						num = 1092609764;
					}
					else
					{
						num = 1092609757;
					}
					goto IL_001b;
				}

				private static bool CheckBrowserVersion(int browser, string versionMin, string versionMax, string[] currentVersion)
				{
					versionMin = StringTools.Trim(versionMin);
					bool flag = default(bool);
					bool flag2 = default(bool);
					int result2 = default(int);
					int result = default(int);
					bool flag3 = default(bool);
					int num2 = default(int);
					bool flag6 = default(bool);
					string[] array2 = default(string[]);
					int num3 = default(int);
					bool flag4 = default(bool);
					int num6 = default(int);
					int num4 = default(int);
					string[] array = default(string[]);
					while (true)
					{
						int num = -1404789709;
						while (true)
						{
							bool flag5;
							switch (num ^ -1404789705)
							{
							case 16:
								break;
							case 12:
								if (flag && !flag2)
								{
									return false;
								}
								if (flag)
								{
									if (result2 > result)
									{
										num = -1404789699;
										continue;
									}
									flag3 = true;
									num2++;
									num = -1404789708;
									continue;
								}
								goto case 14;
							case 13:
								flag5 = !string.IsNullOrEmpty(versionMin);
								flag6 = !string.IsNullOrEmpty(versionMax);
								if (!flag5 && !flag6)
								{
									num = -1404789710;
									continue;
								}
								if (currentVersion != null)
								{
									if (currentVersion.Length == 0)
									{
										num = -1404789704;
										continue;
									}
									switch (browser)
									{
									case -1:
									case 0:
										break;
									default:
										goto IL_00cc;
									}
									goto case 1;
								}
								goto case 15;
							case 2:
								num = -1404789708;
								continue;
							case 9:
								flag3 = false;
								num2 = 0;
								num = -1404789707;
								continue;
							case 1:
								return true;
							case 10:
								return false;
							case 11:
							{
								int result3;
								bool flag7 = int.TryParse(array2[num3], out result3);
								int result4;
								bool flag8 = int.TryParse(currentVersion[num3], out result4);
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
									flag4 = true;
									num3++;
									num = -1404789705;
									continue;
								}
								goto case 6;
							}
							case 3:
							{
								int num7;
								if (num2 < num6)
								{
									num = -1404789697;
									num7 = num;
								}
								else
								{
									num = -1404789703;
									num7 = num;
								}
								continue;
							}
							case 4:
								versionMax = StringTools.Trim(versionMax);
								num = -1404789702;
								continue;
							case 7:
								flag4 = false;
								num3 = 0;
								num = -1404789705;
								continue;
							case 6:
								if (!flag4)
								{
									return false;
								}
								goto IL_0199;
							case 0:
							{
								int num5;
								if (num3 >= num4)
								{
									num = -1404789711;
									num5 = num;
								}
								else
								{
									num = -1404789700;
									num5 = num;
								}
								continue;
							}
							case 8:
								flag = int.TryParse(array[num2], out result);
								flag2 = int.TryParse(currentVersion[num2], out result2);
								num = -1404789701;
								continue;
							case 5:
								return true;
							case 14:
								if (!flag3)
								{
									num = -1404789722;
									continue;
								}
								goto IL_026e;
							case 15:
								return false;
							default:
								{
									return false;
								}
								IL_026e:
								return true;
								IL_0199:
								if (flag6)
								{
									array = versionMax.Split('.');
									num6 = MathTools.Min(array.Length, currentVersion.Length);
									num = -1404789698;
									continue;
								}
								goto IL_026e;
								IL_00cc:
								if (flag5)
								{
									array2 = versionMin.Split('.');
									num4 = MathTools.Min(array2.Length, currentVersion.Length);
									num = -1404789712;
									continue;
								}
								goto IL_0199;
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
					bool flag2 = !string.IsNullOrEmpty(versionMax);
					if (!flag && !flag2)
					{
						return true;
					}
					string[] array = default(string[]);
					int num = default(int);
					bool flag3 = default(bool);
					int num2;
					if (currentVersion != null)
					{
						if (currentVersion.Length == 0)
						{
							goto IL_003a;
						}
						if (flag)
						{
							array = versionMin.Split('.');
							num = MathTools.Min(array.Length, currentVersion.Length);
							flag3 = false;
							num2 = 889611924;
							goto IL_003f;
						}
						goto IL_012d;
					}
					goto IL_0218;
					IL_003f:
					int num3 = default(int);
					bool flag6 = default(bool);
					int result2 = default(int);
					int num4 = default(int);
					bool flag5 = default(bool);
					int result = default(int);
					bool flag4 = default(bool);
					int num5 = default(int);
					string[] array2 = default(string[]);
					while (true)
					{
						switch (num2 ^ 0x35066697)
						{
						case 11:
							break;
						case 14:
							goto IL_009b;
						case 3:
							num3 = 0;
							num2 = 889611929;
							continue;
						case 17:
							goto IL_00bb;
						case 4:
							return false;
						case 16:
							flag6 = int.TryParse(array[num3], out result2);
							num2 = 889611920;
							continue;
						case 2:
							return false;
						case 1:
							goto IL_011a;
						case 8:
							return false;
						case 0:
							num4 = 0;
							num2 = 889611931;
							continue;
						case 7:
							flag5 = int.TryParse(currentVersion[num3], out result);
							num2 = 889611933;
							continue;
						case 12:
							num2 = 889611930;
							continue;
						case 15:
							goto IL_0191;
						case 10:
							goto IL_01c4;
						case 13:
							goto IL_01dc;
						case 5:
							flag4 = false;
							num2 = 889611927;
							continue;
						case 6:
							return false;
						case 18:
							goto IL_0218;
						default:
							return false;
						}
						break;
						IL_01dc:
						int num6;
						if (num4 < num5)
						{
							num2 = 889611928;
							num6 = num2;
						}
						else
						{
							num2 = 889611926;
							num6 = num2;
						}
						continue;
						IL_00bb:
						if (!flag3)
						{
							num2 = 889611935;
							continue;
						}
						goto IL_012d;
						IL_009b:
						int num7;
						if (num3 < num)
						{
							num2 = 889611911;
							num7 = num2;
						}
						else
						{
							num2 = 889611910;
							num7 = num2;
						}
						continue;
						IL_01c4:
						if (!flag6 || flag5)
						{
							if (flag6)
							{
								if (result < result2)
								{
									return false;
								}
								flag3 = true;
								num3++;
								num2 = 889611929;
								continue;
							}
							goto IL_00bb;
						}
						num2 = 889611925;
						continue;
						IL_011a:
						if (!flag4)
						{
							num2 = 889611934;
							continue;
						}
						goto IL_0252;
						IL_0191:
						int result3;
						bool flag7 = int.TryParse(array2[num4], out result3);
						int result4;
						bool flag8 = int.TryParse(currentVersion[num4], out result4);
						if (!flag7 || flag8)
						{
							if (flag7)
							{
								if (result4 > result3)
								{
									num2 = 889611921;
									continue;
								}
								flag4 = true;
								num4++;
								num2 = 889611930;
								continue;
							}
							goto IL_011a;
						}
						num2 = 889611923;
					}
					goto IL_003a;
					IL_003a:
					num2 = 889611909;
					goto IL_003f;
					IL_0218:
					return false;
					IL_0252:
					return true;
					IL_012d:
					if (flag2)
					{
						array2 = versionMax.Split('.');
						num5 = MathTools.Min(array2.Length, currentVersion.Length);
						num2 = 889611922;
						goto IL_003f;
					}
					goto IL_0252;
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
					goto IL_003b;
					IL_0011:
					int num = -759801437;
					goto IL_0016;
					IL_0016:
					switch (num ^ -759801438)
					{
					case 3:
						break;
					case 1:
						return;
					case 2:
						goto IL_003b;
					default:
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
						matchingCriteria.mapping = ArrayTools.ShallowCopy(mapping);
						matchingCriteria.elementCount = ArrayTools.DeepClone(elementCount);
						matchingCriteria.clientInfo = ArrayTools.DeepClone(clientInfo);
						return;
					}
					goto IL_0011;
					IL_003b:
					matchingCriteria.productName_useRegex = productName_useRegex;
					num = -759801438;
					goto IL_0016;
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
						int num2 = 1557858950;
						while (true)
						{
							switch (num2 ^ 0x5CDB0A85)
							{
							case 7:
								break;
							case 1:
							{
								int num4;
								if (num3 < buttonCount)
								{
									num2 = 1557858949;
									num4 = num2;
								}
								else
								{
									num2 = 1557858951;
									num4 = num2;
								}
								continue;
							}
							case 5:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = 1557858945;
								continue;
							case 0:
								if (buttons[num3].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num3++;
								num2 = 1557858948;
								continue;
							case 4:
								if (num >= axisCount)
								{
									num3 = 0;
									num2 = 1557858947;
									continue;
								}
								goto case 5;
							case 3:
								num2 = 1557858945;
								continue;
							case 6:
								num2 = 1557858948;
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
					while (num < axisCount)
					{
						while (true)
						{
							IL_0081:
							if (axes[num].elementIdentifier == elementIdentifier.id)
							{
								switch (axes[num].sourceType)
								{
								case 0:
									axisRange = AxisRange.Positive;
									return true;
								default:
									throw new NotImplementedException();
								case 1:
									break;
								case 100:
									goto IL_00b7;
								}
								goto IL_006b;
							}
							goto IL_00c1;
							IL_006b:
							axisRange = axes[num].sourceAxisRange;
							int num2 = -344417678;
							goto IL_000c;
							IL_00b7:
							num2 = -344417674;
							goto IL_000c;
							IL_00c1:
							num++;
							num2 = -344417680;
							goto IL_000c;
							IL_000c:
							while (true)
							{
								switch (num2 ^ -344417674)
								{
								case 5:
									num2 = -344417675;
									continue;
								case 1:
									return true;
								case 4:
									if (axes[num].invert)
									{
										axisRange = InputTools.InvertAxisRange(axisRange);
										num2 = -344417673;
										continue;
									}
									goto case 1;
								case 0:
									break;
								case 3:
									goto IL_0081;
								case 2:
									goto IL_00c1;
								default:
									goto end_IL_0081;
								}
								break;
							}
							goto IL_006b;
							continue;
							end_IL_0081:
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
						while (true)
						{
							switch (-1965458714 ^ -1965458716)
							{
							case 0:
								continue;
							case 2:
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

			private sealed class QmbtGIDBXcecMEqLMbAiHMrsqyVg : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_WebGL_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int DQTdwCfoEtIiNLuPlPSPmLYfjNFO;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
					{
						goto IL_0012;
					}
					goto IL_0038;
					IL_0012:
					int num = 554988511;
					goto IL_0017;
					IL_0017:
					QmbtGIDBXcecMEqLMbAiHMrsqyVg qmbtGIDBXcecMEqLMbAiHMrsqyVg = default(QmbtGIDBXcecMEqLMbAiHMrsqyVg);
					while (true)
					{
						switch (num ^ 0x211473DE)
						{
						case 2:
							break;
						case 3:
							goto IL_0038;
						case 4:
							num = 554988510;
							continue;
						case 1:
							if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
							{
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
								qmbtGIDBXcecMEqLMbAiHMrsqyVg = this;
								num = 554988506;
								continue;
							}
							goto IL_0038;
						default:
							return qmbtGIDBXcecMEqLMbAiHMrsqyVg;
						}
						break;
					}
					goto IL_0012;
					IL_0038:
					qmbtGIDBXcecMEqLMbAiHMrsqyVg = new QmbtGIDBXcecMEqLMbAiHMrsqyVg(0);
					qmbtGIDBXcecMEqLMbAiHMrsqyVg.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					num = 554988510;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 1:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						DQTdwCfoEtIiNLuPlPSPmLYfjNFO++;
						num = -930957479;
						goto IL_001f;
					case 0:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements == null)
							{
								break;
							}
							int num3;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes != null)
							{
								num = -930957480;
								num3 = num;
							}
							else
							{
								num = -930957477;
								num3 = num;
							}
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -930957479)
							{
							case 4:
								num = -930957476;
								continue;
							case 3:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes[DQTdwCfoEtIiNLuPlPSPmLYfjNFO];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 1:
								DQTdwCfoEtIiNLuPlPSPmLYfjNFO = 0;
								num = -930957479;
								continue;
							case 0:
								break;
							case 5:
								goto end_IL_001f;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (DQTdwCfoEtIiNLuPlPSPmLYfjNFO >= iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.axes.Length)
							{
								num = -930957477;
								num2 = num;
							}
							else
							{
								num = -930957478;
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
				public QmbtGIDBXcecMEqLMbAiHMrsqyVg(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class DnbADcTMHhEkkObgCuIIXhEALDF : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button aimBzjfQfPyaeQqysAQJISCBhELB;

				private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

				private int HbSVCfYbFQknCSDIuBJpKcqKonb;

				public Platform_WebGL_Base iKQXbXnVtIaMZEJNeigQJWAHqUx;

				public int giCKNLSEXsFhRdXdRdLXAaDdWZRY;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						goto IL_0023;
					}
					goto IL_0052;
					IL_0028:
					int num;
					DnbADcTMHhEkkObgCuIIXhEALDF dnbADcTMHhEkkObgCuIIXhEALDF = default(DnbADcTMHhEkkObgCuIIXhEALDF);
					while (true)
					{
						switch (num ^ 0x388B6FDD)
						{
						case 3:
							break;
						case 4:
							dnbADcTMHhEkkObgCuIIXhEALDF = this;
							num = 948662236;
							continue;
						case 0:
							goto IL_0052;
						case 1:
							num = 948662239;
							continue;
						default:
							return dnbADcTMHhEkkObgCuIIXhEALDF;
						}
						break;
					}
					goto IL_0023;
					IL_0052:
					dnbADcTMHhEkkObgCuIIXhEALDF = new DnbADcTMHhEkkObgCuIIXhEALDF(0);
					dnbADcTMHhEkkObgCuIIXhEALDF.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					num = 948662239;
					goto IL_0028;
					IL_0023:
					num = 948662233;
					goto IL_0028;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					default:
						num = -2140084549;
						goto IL_001a;
					case 1:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						giCKNLSEXsFhRdXdRdLXAaDdWZRY++;
						num = -2140084546;
						goto IL_001a;
					case 0:
						goto IL_008b;
						IL_001a:
						while (true)
						{
							switch (num ^ -2140084545)
							{
							case 5:
								break;
							case 4:
								num = -2140084545;
								continue;
							case 2:
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons[giCKNLSEXsFhRdXdRdLXAaDdWZRY];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							case 3:
								goto IL_008b;
							case 1:
								goto IL_00c2;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00c2:
							int num2;
							if (giCKNLSEXsFhRdXdRdLXAaDdWZRY >= iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons.Length)
							{
								num = -2140084545;
								num2 = num;
							}
							else
							{
								num = -2140084547;
								num2 = num;
							}
						}
						goto default;
						IL_008b:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elements == null || iKQXbXnVtIaMZEJNeigQJWAHqUx.elements.buttons == null)
						{
							break;
						}
						giCKNLSEXsFhRdXdRdLXAaDdWZRY = 0;
						num = -2140084546;
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
				public DnbADcTMHhEkkObgCuIIXhEALDF(int _003C_003E1__state)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
					HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
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
					return InputPlatform.wOtEjdlwdBaCIAeldUVaNMnbIoRs;
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
								if (num < axes_orig.Length)
								{
									num2 = 1239976615;
									num3 = num2;
								}
								else
								{
									num2 = 1239976612;
									num3 = num2;
								}
								while (true)
								{
									switch (num2 ^ 0x49E88AA6)
									{
									case 3:
										num2 = 1239976615;
										continue;
									case 1:
										_axesOrigGame[num] = axes_orig[num];
										num++;
										num2 = 1239976614;
										continue;
									case 0:
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
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							int num = 0;
							while (true)
							{
								int num2;
								int num3;
								if (num < buttons_orig.Length)
								{
									num2 = 2136612543;
									num3 = num2;
								}
								else
								{
									num2 = 2136612542;
									num3 = num2;
								}
								while (true)
								{
									switch (num2 ^ 0x7F5A1EBE)
									{
									case 3:
										num2 = 2136612543;
										continue;
									case 1:
										_buttonsOrigGame[num] = buttons_orig[num];
										num2 = 2136612538;
										continue;
									case 4:
										num++;
										num2 = 2136612540;
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
					int num = 1267758646;
					while (true)
					{
						switch (num ^ 0x4B907634)
						{
						case 0:
							break;
						case 2:
							platformMap = null;
							if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
							{
								goto IL_003c;
							}
							return false;
						default:
							return true;
						}
						break;
						IL_003c:
						platformMap = this;
						num = 1267758645;
					}
				}
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				QmbtGIDBXcecMEqLMbAiHMrsqyVg qmbtGIDBXcecMEqLMbAiHMrsqyVg = new QmbtGIDBXcecMEqLMbAiHMrsqyVg(-2);
				qmbtGIDBXcecMEqLMbAiHMrsqyVg.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return qmbtGIDBXcecMEqLMbAiHMrsqyVg;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				DnbADcTMHhEkkObgCuIIXhEALDF dnbADcTMHhEkkObgCuIIXhEALDF = new DnbADcTMHhEkkObgCuIIXhEALDF(-2);
				dnbADcTMHhEkkObgCuIIXhEALDF.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return dnbADcTMHhEkkObgCuIIXhEALDF;
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
				while (num < array.Length)
				{
					while (true)
					{
						int elementIdentifier = elements.axes[num].elementIdentifier;
						int num2 = 349053637;
						while (true)
						{
							switch (num2 ^ 0x14CE22C7)
							{
							case 6:
								num2 = 349053638;
								continue;
							case 1:
								break;
							case 5:
								num++;
								num2 = 349053632;
								continue;
							case 0:
								goto IL_0093;
							case 2:
								goto IL_00aa;
							case 4:
								Logger.LogError("Element identifier index is out of bounds!");
								num2 = 349053634;
								continue;
							case 3:
								array[num] = identifiers[num3].name;
								num2 = 349053634;
								continue;
							default:
								goto end_IL_006e;
							}
							break;
							IL_00aa:
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							int num4;
							if (num3 >= 0)
							{
								num2 = 349053639;
								num4 = num2;
							}
							else
							{
								num2 = 349053635;
								num4 = num2;
							}
							continue;
							IL_0093:
							int num5;
							if (num3 < identifiers.Length)
							{
								num2 = 349053636;
								num5 = num2;
							}
							else
							{
								num2 = 349053635;
								num5 = num2;
							}
						}
						continue;
						end_IL_006e:
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
					goto IL_0012;
				}
				string[] array = new string[buttonCount];
				int num = 0;
				int num2 = 1347655470;
				goto IL_0017;
				IL_0017:
				int num3 = default(int);
				while (true)
				{
					switch (num2 ^ 0x50539729)
					{
					case 10:
						break;
					case 9:
						num++;
						num2 = 1347655470;
						continue;
					case 1:
					{
						int elementIdentifier = elements.buttons[num].elementIdentifier;
						num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						num2 = 1347655468;
						continue;
					}
					case 3:
						return new string[0];
					case 7:
					{
						int num5;
						if (num >= array.Length)
						{
							num2 = 1347655465;
							num5 = num2;
						}
						else
						{
							num2 = 1347655464;
							num5 = num2;
						}
						continue;
					}
					case 4:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = 1347655457;
						continue;
					case 8:
						num2 = 1347655456;
						continue;
					case 2:
						Logger.LogError("You have too few element identifiers!");
						num2 = 1347655466;
						continue;
					case 6:
						array[num] = identifiers[num3].name;
						num2 = 1347655456;
						continue;
					case 5:
						if (num3 >= 0)
						{
							int num4;
							if (num3 < identifiers.Length)
							{
								num2 = 1347655471;
								num4 = num2;
							}
							else
							{
								num2 = 1347655469;
								num4 = num2;
							}
							continue;
						}
						goto case 4;
					default:
						return array;
					}
					break;
				}
				goto IL_0012;
				IL_0012:
				num2 = 1347655467;
				goto IL_0017;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				bool result = default(bool);
				using (IEnumerator<Platform_Custom.Axis> enumerator = IterateAxes().GetEnumerator())
				{
					while (true)
					{
						IL_0073:
						int num;
						int num2;
						if (!enumerator.MoveNext())
						{
							num = 282705704;
							num2 = num;
						}
						else
						{
							num = 282705705;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x10D9BF28)
							{
							case 5:
								num = 282705705;
								continue;
							default:
								goto end_IL_0013;
							case 1:
							{
								Axis axis = (Axis)enumerator.Current;
								int num3;
								if (axis.elementIdentifier == elementIdentifierId)
								{
									num = 282705706;
									num3 = num;
								}
								else
								{
									num = 282705708;
									num3 = num;
								}
								continue;
							}
							case 2:
								result = true;
								num = 282705707;
								continue;
							case 4:
								break;
							case 0:
								goto end_IL_0013;
							case 3:
								goto IL_00ff;
							}
							goto IL_0073;
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
					goto IL_00ff;
				}
				return false;
				IL_00ff:
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
						if (!enumerator.MoveNext())
						{
							num2 = 266274134;
							num3 = num2;
						}
						else
						{
							num2 = 266274135;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0xFDF0554)
							{
							case 0:
								num2 = 266274135;
								continue;
							default:
								goto end_IL_002f;
							case 3:
							{
								Button button = (Button)enumerator.Current;
								buttons[num] = button.elementIdentifier;
								num++;
								num2 = 266274133;
								continue;
							}
							case 1:
								break;
							case 2:
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
				using (IEnumerator<Platform_Custom.Axis> enumerator2 = IterateAxes().GetEnumerator())
				{
					while (true)
					{
						int num4;
						int num5;
						if (!enumerator2.MoveNext())
						{
							num4 = 266274135;
							num5 = num4;
						}
						else
						{
							num4 = 266274133;
							num5 = num4;
						}
						while (true)
						{
							switch (num4 ^ 0xFDF0554)
							{
							case 0:
								num4 = 266274133;
								continue;
							default:
								return;
							case 1:
							{
								Axis axis = (Axis)enumerator2.Current;
								axes[num] = axis.elementIdentifier;
								num++;
								num4 = 266274134;
								continue;
							}
							case 2:
								break;
							case 3:
								return;
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
					goto IL_000a;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				int num = 471524835;
				goto IL_000f;
				IL_000f:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ 0x1C1AE5E8)
					{
					case 12:
						break;
					case 1:
						return null;
					case 8:
						array[num2].invert = axes_orig[num2].invert;
						array[num2].deadZone = axes_orig[num2].axisDeadZone;
						if (Axes_orig[num2].calibrateAxis)
						{
							array[num2].zero = axes_orig[num2].axisZero;
							array[num2].min = axes_orig[num2].axisMin;
							array[num2].max = axes_orig[num2].axisMax;
							num = 471524847;
							continue;
						}
						goto case 5;
					case 11:
						num2 = 0;
						num = 471524833;
						continue;
					case 3:
						num2++;
						num = 471524842;
						continue;
					case 10:
						array[num2] = AxisCalibrationData.Default;
						num = 471524832;
						continue;
					case 9:
						num = 471524842;
						continue;
					case 6:
						if (axes_orig[num2].sourceType == 0)
						{
							array[num2] = AxisCalibrationData.Default;
							num = 471524845;
							continue;
						}
						goto case 4;
					case 7:
						num = 471524845;
						continue;
					case 4:
						throw new NotImplementedException();
					case 0:
						if (axes_orig[num2].sourceType != 1)
						{
							int num3;
							if (axes_orig[num2].sourceType == 100)
							{
								num = 471524834;
								num3 = num;
							}
							else
							{
								num = 471524846;
								num3 = num;
							}
							continue;
						}
						goto case 10;
					case 5:
						array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, true);
						num = 471524843;
						continue;
					default:
						if (num2 >= axes_orig.Length)
						{
							return array;
						}
						goto case 0;
					}
					break;
				}
				goto IL_000a;
				IL_000a:
				num = 471524841;
				goto IL_000f;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				int num2 = default(int);
				while (true)
				{
					int num = -1760032469;
					while (true)
					{
						switch (num ^ -1760032467)
						{
						case 8:
							break;
						case 6:
							axisInfos = null;
							if (Axes_orig == null)
							{
								return;
							}
							goto case 5;
						case 4:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, true);
							if (Axes_orig[num2].sourceType != 1)
							{
								int num3;
								if (Axes_orig[num2].sourceType == 100)
								{
									num = -1760032470;
									num3 = num;
								}
								else
								{
									num = -1760032465;
									num3 = num;
								}
								continue;
							}
							goto case 7;
						case 3:
							num2++;
							num = -1760032467;
							continue;
						case 7:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -1760032466;
							continue;
						case 2:
							if (Axes_orig[num2].sourceType == 0)
							{
								axisRanges[num2] = AxisRange.Full;
								num = -1760032466;
								continue;
							}
							goto case 1;
						case 5:
							axisRanges = new AxisRange[Axes_orig.Length];
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = -1760032467;
							continue;
						case 1:
							throw new Exception();
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
					int num2 = 350991306;
					while (true)
					{
						switch (num2 ^ 0x14EBB3C8)
						{
						case 0:
							num2 = 350991305;
							continue;
						default:
							return;
						case 2:
						{
							int num3;
							if (num >= Buttons_orig.Length)
							{
								num2 = 350991307;
								num3 = num2;
							}
							else
							{
								num2 = 350991308;
								num3 = num2;
							}
							continue;
						}
						case 4:
							buttonInfos[num] = MiscTools.DeepClone(Buttons_orig[num].buttonInfo, true);
							num++;
							num2 = 350991306;
							continue;
						case 1:
							break;
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
					while (true)
					{
						int num = 891611140;
						while (true)
						{
							switch (num ^ 0x3524E805)
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
							num = 891611143;
						}
					}
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
				Platform_WebGL_Base platform_WebGL_Base = destination as Platform_WebGL_Base;
				while (true)
				{
					int num = -1843177021;
					while (true)
					{
						switch (num ^ -1843177023)
						{
						case 4:
							break;
						default:
							return;
						case 2:
						{
							int num2;
							if (platform_WebGL_Base != null)
							{
								num = -1843177023;
								num2 = num;
							}
							else
							{
								num = -1843177024;
								num2 = num;
							}
							continue;
						}
						case 1:
							return;
						case 0:
							platform_WebGL_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
							platform_WebGL_Base.elements = MiscTools.DeepClone(elements);
							num = -1843177022;
							continue;
						case 3:
							return;
						}
						break;
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
					goto IL_0010;
				}
				int num;
				int num2;
				if (base.hasVariants)
				{
					num = 1714309068;
					num2 = num;
				}
				else
				{
					num = 1714309065;
					num2 = num;
				}
				goto IL_0015;
				IL_0010:
				num = 1714309066;
				goto IL_0015;
				IL_0015:
				int num3 = default(int);
				while (true)
				{
					switch (num ^ 0x662E47CF)
					{
					case 0:
						break;
					case 2:
					{
						int variantIndex2;
						if (variants[num3] != null && variants[num3].Matches(BridgedControllerHWInfo, strictMatch, out variantIndex2, out platformMap))
						{
							num = 1714309070;
							continue;
						}
						num3++;
						num = 1714309067;
						continue;
					}
					case 3:
						num3 = 0;
						num = 1714309067;
						continue;
					case 4:
					{
						int num4;
						if (num3 >= variants.Length)
						{
							num = 1714309065;
							num4 = num;
						}
						else
						{
							num = 1714309069;
							num4 = num;
						}
						continue;
					}
					case 1:
						variantIndex = num3;
						return true;
					case 5:
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
				Platform_WebGL platform_WebGL = new Platform_WebGL();
				CopyVars(platform_WebGL);
				return platform_WebGL;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_WebGL platform_WebGL = destination as Platform_WebGL;
				if (platform_WebGL == null)
				{
					while (true)
					{
						switch (-1326783086 ^ -1326783085)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				platform_WebGL.variants = MiscTools.DeepClone(variants);
			}
		}

		private sealed class rFSnRsJLmUahhopaVnzpmbchdee : IDisposable, IEnumerator, IEnumerable, IEnumerable<Guid>, IEnumerator<Guid>
		{
			private Guid aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public HardwareJoystickMap iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int JgkqHoXbaGSqSpATxoAvQPPuCvQ;

			Guid IEnumerator<Guid>.Current
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
			IEnumerator<Guid> IEnumerable<Guid>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					goto IL_001c;
				}
				goto IL_004e;
				IL_004e:
				rFSnRsJLmUahhopaVnzpmbchdee rFSnRsJLmUahhopaVnzpmbchdee2 = new rFSnRsJLmUahhopaVnzpmbchdee(0);
				rFSnRsJLmUahhopaVnzpmbchdee2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				int num = -720702405;
				goto IL_0021;
				IL_001c:
				num = -720702407;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ -720702408)
					{
					case 0:
						break;
					case 1:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						rFSnRsJLmUahhopaVnzpmbchdee2 = this;
						num = -720702405;
						continue;
					case 2:
						goto IL_004e;
					default:
						return rFSnRsJLmUahhopaVnzpmbchdee2;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Guid>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
				while (true)
				{
					int num2 = -221757927;
					while (true)
					{
						switch (num2 ^ -221757924)
						{
						case 3:
							break;
						case 5:
							switch (num)
							{
							default:
								num2 = -221757923;
								continue;
							case 0:
								break;
							case 1:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								JgkqHoXbaGSqSpATxoAvQPPuCvQ++;
								num2 = -221757922;
								continue;
							}
							goto case 8;
						case 0:
							JgkqHoXbaGSqSpATxoAvQPPuCvQ = 0;
							num2 = -221757922;
							continue;
						case 2:
						{
							int num3;
							if (JgkqHoXbaGSqSpATxoAvQPPuCvQ < iKQXbXnVtIaMZEJNeigQJWAHqUx.templateGuids.Length)
							{
								num2 = -221757928;
								num3 = num2;
							}
							else
							{
								num2 = -221757923;
								num3 = num2;
							}
							continue;
						}
						case 8:
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							int num4;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.templateGuids != null)
							{
								num2 = -221757924;
								num4 = num2;
							}
							else
							{
								num2 = -221757923;
								num4 = num2;
							}
							continue;
						}
						case 4:
							aimBzjfQfPyaeQqysAQJISCBhELB = StringTools.ToGuid(iKQXbXnVtIaMZEJNeigQJWAHqUx.templateGuids[JgkqHoXbaGSqSpATxoAvQPPuCvQ]);
							num2 = -221757926;
							continue;
						case 6:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							num2 = -221757925;
							continue;
						case 7:
							return true;
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
			public rFSnRsJLmUahhopaVnzpmbchdee(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class iugCpqxxsSvBDYhKPizhRBmTNPJ : IDisposable, IEnumerable<ControllerElementIdentifier>, IEnumerator<ControllerElementIdentifier>, IEnumerator, IEnumerable
		{
			private ControllerElementIdentifier aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public HardwareJoystickMap iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int ZeVdSxGRjjMJrWvXcGQSyIacEUNe;

			ControllerElementIdentifier IEnumerator<ControllerElementIdentifier>.Current
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
			IEnumerator<ControllerElementIdentifier> IEnumerable<ControllerElementIdentifier>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
					goto IL_0023;
				}
				goto IL_0049;
				IL_0028:
				int num;
				iugCpqxxsSvBDYhKPizhRBmTNPJ iugCpqxxsSvBDYhKPizhRBmTNPJ2 = default(iugCpqxxsSvBDYhKPizhRBmTNPJ);
				while (true)
				{
					switch (num ^ 0x677D9490)
					{
					case 3:
						break;
					case 4:
						goto IL_0049;
					case 0:
						num = 1736283282;
						continue;
					case 1:
						iugCpqxxsSvBDYhKPizhRBmTNPJ2 = this;
						num = 1736283280;
						continue;
					default:
						return iugCpqxxsSvBDYhKPizhRBmTNPJ2;
					}
					break;
				}
				goto IL_0023;
				IL_0049:
				iugCpqxxsSvBDYhKPizhRBmTNPJ2 = new iugCpqxxsSvBDYhKPizhRBmTNPJ(0);
				iugCpqxxsSvBDYhKPizhRBmTNPJ2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = 1736283282;
				goto IL_0028;
				IL_0023:
				num = 1736283281;
				goto IL_0028;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerElementIdentifier>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				default:
					num = 625399852;
					goto IL_001a;
				case 0:
					goto IL_006c;
				case 1:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = 625399848;
						goto IL_001a;
					}
					IL_001a:
					while (true)
					{
						switch (num ^ 0x2546D82D)
						{
						case 3:
							break;
						case 6:
							goto IL_0046;
						case 4:
							goto IL_006c;
						case 1:
							num = 625399855;
							continue;
						case 0:
							aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elementIdentifiers[ZeVdSxGRjjMJrWvXcGQSyIacEUNe];
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							return true;
						case 5:
							ZeVdSxGRjjMJrWvXcGQSyIacEUNe++;
							num = 625399851;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0046:
						int num2;
						if (ZeVdSxGRjjMJrWvXcGQSyIacEUNe >= iKQXbXnVtIaMZEJNeigQJWAHqUx.elementIdentifiers.Length)
						{
							num = 625399855;
							num2 = num;
						}
						else
						{
							num = 625399853;
							num2 = num;
						}
					}
					goto default;
					IL_006c:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elementIdentifiers == null)
					{
						break;
					}
					ZeVdSxGRjjMJrWvXcGQSyIacEUNe = 0;
					num = 625399851;
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
			public iugCpqxxsSvBDYhKPizhRBmTNPJ(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class sVTVwZYyhwSdKOAQXOLTLoKsdKOD : IDisposable, IEnumerator, IEnumerable, IEnumerable<JoystickType>, IEnumerator<JoystickType>
		{
			private JoystickType aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public HardwareJoystickMap iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int CsnGvaaZfErWvdsXWUqxDPbgEcO;

			JoystickType IEnumerator<JoystickType>.Current
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
			IEnumerator<JoystickType> IEnumerable<JoystickType>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
					goto IL_0023;
				}
				goto IL_004e;
				IL_0028:
				int num;
				sVTVwZYyhwSdKOAQXOLTLoKsdKOD sVTVwZYyhwSdKOAQXOLTLoKsdKOD2 = default(sVTVwZYyhwSdKOAQXOLTLoKsdKOD);
				while (true)
				{
					switch (num ^ 0x33D48081)
					{
					case 3:
						break;
					case 1:
						sVTVwZYyhwSdKOAQXOLTLoKsdKOD2 = this;
						num = 869564545;
						continue;
					case 2:
						goto IL_004e;
					default:
						return sVTVwZYyhwSdKOAQXOLTLoKsdKOD2;
					}
					break;
				}
				goto IL_0023;
				IL_004e:
				sVTVwZYyhwSdKOAQXOLTLoKsdKOD2 = new sVTVwZYyhwSdKOAQXOLTLoKsdKOD(0);
				sVTVwZYyhwSdKOAQXOLTLoKsdKOD2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = 869564545;
				goto IL_0028;
				IL_0023:
				num = 869564544;
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
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 0:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					num = 1392544822;
					goto IL_001f;
				case 1:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = 1392544816;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ 0x53008C30)
						{
						case 5:
							num = 1392544823;
							continue;
						case 0:
							CsnGvaaZfErWvdsXWUqxDPbgEcO++;
							num = 1392544818;
							continue;
						case 1:
							num = 1392544818;
							continue;
						case 6:
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.joystickTypes != null)
							{
								CsnGvaaZfErWvdsXWUqxDPbgEcO = 0;
								num = 1392544817;
								continue;
							}
							goto end_IL_0008;
						case 7:
							break;
						case 2:
							goto IL_0094;
						case 4:
							aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.joystickTypes[CsnGvaaZfErWvdsXWUqxDPbgEcO];
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							return true;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0094:
						int num2;
						if (CsnGvaaZfErWvdsXWUqxDPbgEcO < iKQXbXnVtIaMZEJNeigQJWAHqUx.joystickTypes.Length)
						{
							num = 1392544820;
							num2 = num;
						}
						else
						{
							num = 1392544819;
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
			public sVTVwZYyhwSdKOAQXOLTLoKsdKOD(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class erclJDUZtQCHUUXkHRPdGYUNVaZ : IDisposable, IEnumerator, IEnumerable, IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerator<IControllerElementIdentifierCommon_Internal>
		{
			private IControllerElementIdentifierCommon_Internal aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public HardwareJoystickMap iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int WdvWtGoywoQvjONPiACYEotWNpRB;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
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
			IEnumerator<IControllerElementIdentifierCommon_Internal> IEnumerable<IControllerElementIdentifierCommon_Internal>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
				{
					goto IL_0012;
				}
				goto IL_006e;
				IL_0012:
				int num = -657395945;
				goto IL_0017;
				IL_0017:
				erclJDUZtQCHUUXkHRPdGYUNVaZ erclJDUZtQCHUUXkHRPdGYUNVaZ2 = default(erclJDUZtQCHUUXkHRPdGYUNVaZ);
				while (true)
				{
					switch (num ^ -657395950)
					{
					case 4:
						break;
					case 5:
						goto IL_003c;
					case 2:
						num = -657395949;
						continue;
					case 0:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						erclJDUZtQCHUUXkHRPdGYUNVaZ2 = this;
						num = -657395952;
						continue;
					case 3:
						goto IL_006e;
					default:
						return erclJDUZtQCHUUXkHRPdGYUNVaZ2;
					}
					break;
					IL_003c:
					int num2;
					if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						num = -657395950;
						num2 = num;
					}
					else
					{
						num = -657395951;
						num2 = num;
					}
				}
				goto IL_0012;
				IL_006e:
				erclJDUZtQCHUUXkHRPdGYUNVaZ2 = new erclJDUZtQCHUUXkHRPdGYUNVaZ(0);
				erclJDUZtQCHUUXkHRPdGYUNVaZ2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = -657395949;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<IControllerElementIdentifierCommon_Internal>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
				while (true)
				{
					int num2 = 2021763154;
					while (true)
					{
						switch (num2 ^ 0x7881A853)
						{
						case 4:
							break;
						case 0:
						{
							int num3;
							if (WdvWtGoywoQvjONPiACYEotWNpRB >= iKQXbXnVtIaMZEJNeigQJWAHqUx.elementIdentifiers.Length)
							{
								num2 = 2021763158;
								num3 = num2;
							}
							else
							{
								num2 = 2021763153;
								num3 = num2;
							}
							continue;
						}
						case 2:
							aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elementIdentifiers[WdvWtGoywoQvjONPiACYEotWNpRB];
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							return true;
						case 3:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elementIdentifiers != null)
							{
								WdvWtGoywoQvjONPiACYEotWNpRB = 0;
								num2 = 2021763155;
								continue;
							}
							goto default;
						case 1:
							switch (num)
							{
							case 1:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								WdvWtGoywoQvjONPiACYEotWNpRB++;
								num2 = 2021763155;
								continue;
							case 0:
								break;
							default:
								num2 = 2021763158;
								continue;
							}
							goto case 3;
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
			public erclJDUZtQCHUUXkHRPdGYUNVaZ(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string controllerName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string editorControllerName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string description;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string controllerGuid;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string[] templateGuids;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool hideInLists;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private JoystickType[] joystickTypes;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerElementIdentifier[] elementIdentifiers;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private CompoundElement[] compoundElements;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_DirectInput directInput;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_RawInput rawInput;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_XInput xInput;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_OSX osx;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Linux linux;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_WindowsUWP windowsUWP;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_Windows;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_WindowsUWP;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_XBox360;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_XBoxOne;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_PS3;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_PS4;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_PSM;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_PSVita;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_Wii;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_WiiU;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_AmazonFireTV;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_RazerForgeTV;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_WebGL webGL;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Ouya ouya;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_XboxOne xboxOne;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_PS4 ps4;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_NintendoSwitch nintendoSwitch;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_InternalDriver internalDriver;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_SDL2 sdl2_Linux;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_SDL2 sdl2_Windows;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_SDL2 sdl2_OSX;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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
				rFSnRsJLmUahhopaVnzpmbchdee rFSnRsJLmUahhopaVnzpmbchdee2 = new rFSnRsJLmUahhopaVnzpmbchdee(-2);
				rFSnRsJLmUahhopaVnzpmbchdee2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return rFSnRsJLmUahhopaVnzpmbchdee2;
			}
		}

		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				iugCpqxxsSvBDYhKPizhRBmTNPJ iugCpqxxsSvBDYhKPizhRBmTNPJ2 = new iugCpqxxsSvBDYhKPizhRBmTNPJ(-2);
				iugCpqxxsSvBDYhKPizhRBmTNPJ2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return iugCpqxxsSvBDYhKPizhRBmTNPJ2;
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
				sVTVwZYyhwSdKOAQXOLTLoKsdKOD sVTVwZYyhwSdKOAQXOLTLoKsdKOD2 = new sVTVwZYyhwSdKOAQXOLTLoKsdKOD(-2);
				sVTVwZYyhwSdKOAQXOLTLoKsdKOD2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return sVTVwZYyhwSdKOAQXOLTLoKsdKOD2;
			}
		}

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			get
			{
				erclJDUZtQCHUUXkHRPdGYUNVaZ erclJDUZtQCHUUXkHRPdGYUNVaZ2 = new erclJDUZtQCHUUXkHRPdGYUNVaZ(-2);
				erclJDUZtQCHUUXkHRPdGYUNVaZ2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return erclJDUZtQCHUUXkHRPdGYUNVaZ2;
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
			controllerGuid = source.controllerGuid;
			if (source.templateGuids != null)
			{
				int num = source.templateGuids.Length;
				templateGuids = new string[num];
				for (int i = 0; i < num; i++)
				{
					templateGuids[i] = templateGuids[i];
				}
			}
			if (source.elementIdentifiers != null)
			{
				int num2 = source.elementIdentifiers.Length;
				elementIdentifiers = new ControllerElementIdentifier[num2];
				for (int j = 0; j < num2; j++)
				{
					elementIdentifiers[j] = elementIdentifiers[j].Clone();
				}
			}
			elementIdentifierIdCounter = source.elementIdentifierIdCounter;
			if (source.compoundElements != null)
			{
				int num3 = source.compoundElements.Length;
				compoundElements = new CompoundElement[num3];
				for (int k = 0; k < num3; k++)
				{
					compoundElements[k] = source.compoundElements[k].DeepClone() as CompoundElement;
				}
			}
			joystickTypes = ArrayTools.ShallowCopy(source.joystickTypes);
			if (source.directInput != null)
			{
				directInput = MiscTools.DeepClone(source.directInput);
			}
			if (source.rawInput != null)
			{
				rawInput = MiscTools.DeepClone(rawInput);
			}
			if (source.xInput != null)
			{
				xInput = MiscTools.DeepClone(source.xInput);
			}
			if (source.osx != null)
			{
				osx = MiscTools.DeepClone(source.osx);
			}
			if (source.linux != null)
			{
				linux = MiscTools.DeepClone(source.linux);
			}
			if (source.windowsUWP != null)
			{
				windowsUWP = MiscTools.DeepClone(source.windowsUWP);
			}
			if (source.fallback_Windows != null)
			{
				fallback_Windows = MiscTools.DeepClone(fallback_Windows);
			}
			if (source.fallback_WindowsUWP != null)
			{
				fallback_WindowsUWP = MiscTools.DeepClone(fallback_WindowsUWP);
			}
			if (source.fallback_OSX != null)
			{
				fallback_OSX = MiscTools.DeepClone(fallback_OSX);
			}
			if (source.fallback_Android != null)
			{
				fallback_Android = MiscTools.DeepClone(fallback_Android);
			}
			if (source.fallback_Blackberry != null)
			{
				fallback_Blackberry = MiscTools.DeepClone(fallback_Blackberry);
			}
			if (source.fallback_iOS != null)
			{
				fallback_iOS = MiscTools.DeepClone(fallback_iOS);
			}
			if (source.fallback_Linux != null)
			{
				fallback_Linux = MiscTools.DeepClone(fallback_Linux);
			}
			if (source.fallback_Linux_PreConfigured != null)
			{
				fallback_Linux_PreConfigured = MiscTools.DeepClone(fallback_Linux_PreConfigured);
			}
			if (source.fallback_PS3 != null)
			{
				fallback_PS3 = MiscTools.DeepClone(fallback_PS3);
			}
			if (source.fallback_PS4 != null)
			{
				fallback_PS4 = MiscTools.DeepClone(fallback_PS4);
			}
			if (source.fallback_PSM != null)
			{
				fallback_PSM = MiscTools.DeepClone(fallback_PSM);
			}
			if (source.fallback_PSVita != null)
			{
				fallback_PSVita = MiscTools.DeepClone(fallback_PSVita);
			}
			if (source.fallback_WindowsPhone8 != null)
			{
				fallback_WindowsPhone8 = MiscTools.DeepClone(fallback_WindowsPhone8);
			}
			if (source.fallback_XBox360 != null)
			{
				fallback_XBox360 = MiscTools.DeepClone(fallback_XBox360);
			}
			if (source.fallback_XBoxOne != null)
			{
				fallback_XBoxOne = MiscTools.DeepClone(fallback_XBoxOne);
			}
			if (source.fallback_Wii != null)
			{
				fallback_Wii = MiscTools.DeepClone(fallback_Wii);
			}
			if (source.fallback_WiiU != null)
			{
				fallback_WiiU = MiscTools.DeepClone(fallback_WiiU);
			}
			if (source.nintendoSwitch != null)
			{
				nintendoSwitch = MiscTools.DeepClone(source.nintendoSwitch);
			}
			if (source.fallback_AmazonFireTV != null)
			{
				fallback_AmazonFireTV = MiscTools.DeepClone(fallback_AmazonFireTV);
			}
			if (source.fallback_RazerForgeTV != null)
			{
				fallback_RazerForgeTV = MiscTools.DeepClone(fallback_RazerForgeTV);
			}
			if (source.webGL != null)
			{
				webGL = MiscTools.DeepClone(source.webGL);
			}
			if (source.ouya != null)
			{
				ouya = MiscTools.DeepClone(source.ouya);
			}
			if (source.xboxOne != null)
			{
				xboxOne = MiscTools.DeepClone(source.xboxOne);
			}
			if (source.ps4 != null)
			{
				ps4 = MiscTools.DeepClone(source.ps4);
			}
			if (source.internalDriver != null)
			{
				internalDriver = MiscTools.DeepClone(source.internalDriver);
			}
			if (source.sdl2_Linux != null)
			{
				sdl2_Linux = MiscTools.DeepClone(source.sdl2_Linux);
			}
			if (source.sdl2_Windows != null)
			{
				sdl2_Windows = MiscTools.DeepClone(source.sdl2_Windows);
			}
			if (source.sdl2_OSX != null)
			{
				sdl2_OSX = MiscTools.DeepClone(source.sdl2_OSX);
			}
		}

		[CustomObfuscation(rename = false)]
		public string[] GetElementIdentifierNames()
		{
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			if (num == 0)
			{
				return null;
			}
			string[] array = new string[num];
			int num3 = default(int);
			while (true)
			{
				int num2 = 733201902;
				while (true)
				{
					switch (num2 ^ 0x2BB3C5EF)
					{
					case 0:
						break;
					case 1:
						num3 = 0;
						num2 = 733201901;
						continue;
					case 3:
						array[num3] = elementIdentifiers[num3].name;
						num3++;
						num2 = 733201901;
						continue;
					default:
						if (num3 >= num)
						{
							return array;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public int[] GetElementIdentifierIds()
		{
			if (elementIdentifiers == null)
			{
				goto IL_0008;
			}
			int num = elementIdentifiers.Length;
			goto IL_0065;
			IL_005a:
			num = 0;
			goto IL_0065;
			IL_0008:
			int num2 = 252776581;
			goto IL_000d;
			IL_000d:
			int num3 = default(int);
			int[] array = default(int[]);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ 0xF111084)
				{
				case 5:
					break;
				case 0:
					num3 = 0;
					num2 = 252776582;
					continue;
				case 6:
					array[num3] = elementIdentifiers[num3].id;
					num3++;
					num2 = 252776576;
					continue;
				case 1:
					goto IL_005a;
				case 2:
					num2 = 252776576;
					continue;
				case 3:
					return null;
				default:
					if (num3 >= num4)
					{
						return array;
					}
					goto case 6;
				}
				break;
			}
			goto IL_0008;
			IL_0065:
			num4 = num;
			if (num4 == 0)
			{
				num2 = 252776583;
			}
			else
			{
				array = new int[num4];
				num2 = 252776580;
			}
			goto IL_000d;
		}

		[CustomObfuscation(rename = false)]
		public ControllerElementIdentifier GetElementIdentifier(int id)
		{
			int num = IndexOfElementIdentifier(id);
			while (true)
			{
				int num2 = -1282795334;
				while (true)
				{
					switch (num2 ^ -1282795333)
					{
					case 2:
						break;
					case 1:
						if (num >= 0)
						{
							if (num >= elementIdentifiers.Length)
							{
								goto IL_0035;
							}
							return elementIdentifiers[num];
						}
						goto default;
					default:
						return null;
					}
					break;
					IL_0035:
					num2 = -1282795333;
				}
			}
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
			int num3 = default(int);
			int count = default(int);
			List<ControllerElementIdentifier> list = default(List<ControllerElementIdentifier>);
			int num4 = default(int);
			while (true)
			{
				int num2 = 392451717;
				while (true)
				{
					switch (num2 ^ 0x1764568F)
					{
					case 3:
						break;
					case 5:
						if (num3 >= num)
						{
							count = list.Count;
							num2 = 392451720;
							continue;
						}
						goto case 0;
					case 8:
					{
						int num5;
						if (num4 < count)
						{
							num2 = 392451726;
							num5 = num2;
						}
						else
						{
							num2 = 392451718;
							num5 = num2;
						}
						continue;
					}
					case 2:
						num2 = 392451719;
						continue;
					case 6:
						num4 = 0;
						num2 = 392451725;
						continue;
					case 1:
						names[num4] = list[num4].name;
						ids[num4] = list[num4].id;
						num4++;
						num2 = 392451719;
						continue;
					case 7:
						if (count == 0)
						{
							return 0;
						}
						names = new string[count];
						ids = new int[count];
						num2 = 392451721;
						continue;
					case 0:
						if (elementIdentifiers[num3] != null && elementIdentifiers[num3].elementType == type)
						{
							list.Add(elementIdentifiers[num3]);
							num2 = 392451723;
							continue;
						}
						goto case 4;
					case 10:
						if (num == 0)
						{
							return 0;
						}
						list = new List<ControllerElementIdentifier>();
						num3 = 0;
						num2 = 392451722;
						continue;
					case 4:
						num3++;
						num2 = 392451722;
						continue;
					default:
						return count;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public int GetMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			names = null;
			ids = null;
			int count = default(int);
			List<ControllerElementIdentifier> list = default(List<ControllerElementIdentifier>);
			int num4 = default(int);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num = 1560481645;
				while (true)
				{
					switch (num ^ 0x5D030F60)
					{
					case 11:
						break;
					case 1:
						if (count == 0)
						{
							return 0;
						}
						names = new string[count];
						num = 1560481641;
						continue;
					case 12:
						list.Add(elementIdentifiers[num4]);
						num = 1560481634;
						continue;
					case 6:
						names[num2] = list[num2].name;
						ids[num2] = list[num2].id;
						num2++;
						num = 1560481642;
						continue;
					case 2:
						num4++;
						num = 1560481640;
						continue;
					case 9:
						ids = new int[count];
						num = 1560481636;
						continue;
					case 5:
						if (num3 == 0)
						{
							return 0;
						}
						list = new List<ControllerElementIdentifier>();
						num4 = 0;
						num = 1560481632;
						continue;
					case 0:
						num = 1560481640;
						continue;
					case 4:
						num2 = 0;
						num = 1560481635;
						continue;
					case 7:
						if (elementIdentifiers[num4] != null)
						{
							int num5;
							if (!InputTools.IsMappableType(elementIdentifiers[num4].elementType))
							{
								num = 1560481634;
								num5 = num;
							}
							else
							{
								num = 1560481644;
								num5 = num;
							}
							continue;
						}
						goto case 2;
					case 8:
						if (num4 >= num3)
						{
							count = list.Count;
							num = 1560481633;
							continue;
						}
						goto case 7;
					case 13:
						num3 = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
						num = 1560481637;
						continue;
					case 3:
						num = 1560481642;
						continue;
					default:
						if (num2 >= count)
						{
							return count;
						}
						goto case 6;
					}
					break;
				}
			}
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
			while (true)
			{
				int num2 = -1516875433;
				while (true)
				{
					switch (num2 ^ -1516875435)
					{
					case 4:
						break;
					case 0:
					{
						int num3;
						if (num >= elementIdentifiers.Length)
						{
							num2 = -1516875434;
							num3 = num2;
						}
						else
						{
							num2 = -1516875436;
							num3 = num2;
						}
						continue;
					}
					case 1:
						if (elementIdentifiers[num].id == id)
						{
							return num;
						}
						num++;
						num2 = -1516875435;
						continue;
					case 2:
						num2 = -1516875435;
						continue;
					default:
						return -1;
					}
					break;
				}
			}
		}

		internal ControllerElementType GetEffectiveElementIdentifierType(HardwareControllerMapIdentifier hardwareMapIdentifier, int elementIdentifierId, bool isDefaultMap)
		{
			ControllerElementIdentifier elementIdentifier = GetElementIdentifier(elementIdentifierId);
			if (elementIdentifier == null)
			{
				return ControllerElementType.Axis;
			}
			Platform specificPlatformMap = GetSpecificPlatformMap(hardwareMapIdentifier);
			if (specificPlatformMap == null)
			{
				return ControllerElementType.Axis;
			}
			return specificPlatformMap.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal bool GetEffectiveAxisRange(HardwareControllerMapIdentifier hardwareMapIdentifier, int elementIdentifierId, bool isDefaultMap, out AxisRange axisRange)
		{
			axisRange = AxisRange.Full;
			ControllerElementIdentifier elementIdentifier = GetElementIdentifier(elementIdentifierId);
			while (true)
			{
				int num = -64385628;
				while (true)
				{
					switch (num ^ -64385627)
					{
					case 2:
						break;
					case 1:
					{
						if (elementIdentifier == null)
						{
							return false;
						}
						Platform specificPlatformMap = GetSpecificPlatformMap(hardwareMapIdentifier);
						if (specificPlatformMap == null)
						{
							goto IL_003a;
						}
						return specificPlatformMap.GetEffectiveAxisRange(elementIdentifier, out axisRange);
					}
					default:
						return false;
					}
					break;
					IL_003a:
					num = -64385627;
				}
			}
		}

		internal void GetElementIdentifiersForControllerElements(HardwareControllerMapIdentifier hardwareMapIdentifier, bool isDefaultMap, out int[] buttons, out int[] axes)
		{
			buttons = null;
			Platform specificPlatformMap = default(Platform);
			while (true)
			{
				int num = 1444638464;
				while (true)
				{
					switch (num ^ 0x561B6F01)
					{
					case 0:
						break;
					case 1:
						goto IL_0029;
					case 2:
						if (specificPlatformMap.assignedButtonCount <= 0)
						{
							return;
						}
						goto default;
					case 4:
						if (specificPlatformMap == null)
						{
							return;
						}
						goto case 2;
					default:
						specificPlatformMap.GetGameElementIdentifierIdMappings(out buttons, out axes);
						return;
					}
					break;
					IL_0029:
					axes = null;
					specificPlatformMap = GetSpecificPlatformMap(hardwareMapIdentifier);
					num = 1444638469;
				}
			}
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
			actualInputPlatform = InputPlatform.srbgNzJMznryeuABhpjzUCNZxjJP;
			while (true)
			{
				int num = -157983724;
				while (true)
				{
					switch (num ^ -157983723)
					{
					case 10:
						break;
					case 1:
						variantIndex = -1;
						platformMap = null;
						if (bridgedControllerHWInfo == null)
						{
							return false;
						}
						switch (bridgedControllerHWInfo.inputSource)
						{
						case InputSource.Linux:
							if (linux == null)
							{
								num = -157983714;
								continue;
							}
							actualInputPlatform = InputPlatform.JTFQFctybCbrhbHanPIAsCqFHew;
							return linux.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						case InputSource.PS4:
							if (ps4 == null)
							{
								return false;
							}
							actualInputPlatform = InputPlatform.DtbPZmFOLnHQmXPWMCnIdwEBAah;
							num = -157983721;
							continue;
						case InputSource.XInput:
							if (xInput == null)
							{
								return false;
							}
							actualInputPlatform = InputPlatform.VqUKRozySjqEFelrCfPDPBJTuhE;
							num = -157983715;
							continue;
						case InputSource.WindowsUWP:
							if (windowsUWP == null)
							{
								return false;
							}
							actualInputPlatform = InputPlatform.IHkiTQGteWsegyfjGnNBuPLSILmD;
							return windowsUWP.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						case InputSource.Fallback:
						case InputSource.Fallback_PreConfigured:
							platformMap = FindFallbackMatch(bridgedControllerHWInfo, strictMatch, isDefaultMap, out actualInputPlatform, out variantIndex);
							return platformMap != null;
						case InputSource.WebGL:
							if (webGL == null)
							{
								return false;
							}
							actualInputPlatform = InputPlatform.wOtEjdlwdBaCIAeldUVaNMnbIoRs;
							return webGL.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						case InputSource.Ouya:
							if (ouya == null)
							{
								return false;
							}
							actualInputPlatform = InputPlatform.RBYZuIoTfgdiCjovvTtnANAPAAn;
							num = -157983716;
							continue;
						case InputSource.DirectInput:
							break;
						case InputSource.XboxOne:
							if (xboxOne == null)
							{
								return false;
							}
							actualInputPlatform = InputPlatform.GdzkbPzfoHvypKbmmdwEXhUPKcR;
							num = -157983727;
							continue;
						case InputSource.RawInput:
							if (Matches(rawInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
							{
								actualInputPlatform = InputPlatform.PmnSHpCUoGadlRLWMAbfdlxfwVg;
								return true;
							}
							if (!Matches(directInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
							{
								return false;
							}
							num = -157983725;
							continue;
						case InputSource.OSX:
							if (osx == null)
							{
								return false;
							}
							actualInputPlatform = InputPlatform.XnBBtfDGsHOaIaHObPJBJNGTMJOh;
							num = -157983723;
							continue;
						case InputSource.NintendoSwitch:
							if (nintendoSwitch == null)
							{
								return false;
							}
							actualInputPlatform = InputPlatform.MEQxKcJyEOIzwyouWrqjNydTDGq;
							return nintendoSwitch.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						case InputSource.InternalDriver:
							if (internalDriver == null)
							{
								return false;
							}
							actualInputPlatform = InputPlatform.DUbQuJCDfrUzNLyHOFGFbNvqDqG;
							return internalDriver.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						case InputSource.SDL2:
							platformMap = FindSDL2Match(bridgedControllerHWInfo, strictMatch, isDefaultMap, out actualInputPlatform, out variantIndex);
							return platformMap != null;
						case InputSource.Steam:
							actualInputPlatform = InputPlatform.gBTkPmAyPkhrIHErFhGGXZEcsey;
							return false;
						default:
							throw new NotImplementedException();
						}
						goto case 5;
					case 0:
						return osx.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
					case 4:
						return xboxOne.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
					case 7:
						return true;
					case 11:
						return false;
					case 6:
						actualInputPlatform = InputPlatform.hQxvcadrrPaLqOjHlvDNLCWZlDw;
						num = -157983726;
						continue;
					case 5:
						if (Matches(directInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
						{
							actualInputPlatform = InputPlatform.hQxvcadrrPaLqOjHlvDNLCWZlDw;
							return true;
						}
						if (Matches(rawInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
						{
							num = -157983722;
							continue;
						}
						return false;
					case 9:
						return ouya.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
					case 3:
						actualInputPlatform = InputPlatform.PmnSHpCUoGadlRLWMAbfdlxfwVg;
						return true;
					case 8:
						return xInput.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
					default:
						return ps4.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
					}
					break;
				}
			}
		}

		internal HardwareJoystickMap_InputManager GetDefaultHardwareJoystickMap_InputManager(InputSource inputSource)
		{
			InputPlatform actualInputPlatform;
			Platform platform = default(Platform);
			int num;
			int variantIndex;
			switch (inputSource)
			{
			case InputSource.WindowsUWP:
				actualInputPlatform = InputPlatform.IHkiTQGteWsegyfjGnNBuPLSILmD;
				platform = windowsUWP;
				num = 776989265;
				goto IL_008f;
			case InputSource.XboxOne:
				goto IL_0139;
			case InputSource.RawInput:
				goto IL_0146;
			case InputSource.XInput:
				goto IL_016d;
			case InputSource.Fallback:
			case InputSource.Fallback_PreConfigured:
				goto IL_0179;
			default:
				goto IL_0190;
			case InputSource.SDL2:
				goto IL_01a0;
			case InputSource.OSX:
				goto IL_01b7;
			case InputSource.Linux:
				goto IL_01db;
			case InputSource.Ouya:
				goto IL_01ef;
			case InputSource.PS4:
				goto IL_021e;
			case InputSource.None:
				goto IL_022b;
			case InputSource.Steam:
			case InputSource.UnityKeyboardAndMouse:
			case InputSource.Custom:
				throw new NotImplementedException();
			case InputSource.DirectInput:
				goto IL_024a;
			case InputSource.InternalDriver:
				goto IL_025d;
			case InputSource.WebGL:
				goto IL_0282;
			case InputSource.NintendoSwitch:
				goto IL_0296;
				IL_008f:
				while (true)
				{
					switch (num ^ 0x2E4FEA53)
					{
					case 9:
						num = 776989249;
						continue;
					case 26:
						platform = ps4;
						num = 776989250;
						continue;
					case 16:
						break;
					case 11:
						num = 776989250;
						continue;
					case 4:
						goto IL_0139;
					case 10:
						goto IL_0146;
					case 3:
						num = 776989250;
						continue;
					case 22:
						platform = nintendoSwitch;
						num = 776989250;
						continue;
					case 8:
						goto IL_016d;
					case 23:
						goto IL_0179;
					case 15:
						goto IL_0190;
					case 14:
						goto IL_01a0;
					case 13:
						goto IL_01b7;
					case 25:
						platform = rawInput;
						num = 776989250;
						continue;
					case 19:
						goto IL_01db;
					case 5:
						goto IL_01ef;
					case 2:
						num = 776989250;
						continue;
					case 12:
						platform = xboxOne;
						num = 776989250;
						continue;
					case 6:
						goto IL_021e;
					case 24:
						goto IL_022b;
					case 17:
						goto IL_023d;
					case 18:
						goto IL_024a;
					case 1:
						goto IL_025d;
					case 0:
						platform = xInput;
						num = 776989250;
						continue;
					case 20:
						goto IL_0282;
					case 7:
						goto IL_0296;
					default:
						return null;
					}
					break;
					IL_023d:
					if (platform == null)
					{
						num = 776989254;
						continue;
					}
					return platform.ToHardwareJoystickMap_InputManager(this, inputSource, actualInputPlatform, -1);
				}
				goto case InputSource.WindowsUWP;
				IL_0296:
				actualInputPlatform = InputPlatform.MEQxKcJyEOIzwyouWrqjNydTDGq;
				num = 776989253;
				goto IL_008f;
				IL_0282:
				actualInputPlatform = InputPlatform.wOtEjdlwdBaCIAeldUVaNMnbIoRs;
				platform = webGL;
				num = 776989250;
				goto IL_008f;
				IL_025d:
				actualInputPlatform = InputPlatform.DUbQuJCDfrUzNLyHOFGFbNvqDqG;
				platform = internalDriver;
				num = 776989272;
				goto IL_008f;
				IL_024a:
				actualInputPlatform = InputPlatform.hQxvcadrrPaLqOjHlvDNLCWZlDw;
				platform = directInput;
				num = 776989250;
				goto IL_008f;
				IL_022b:
				return null;
				IL_021e:
				actualInputPlatform = InputPlatform.DtbPZmFOLnHQmXPWMCnIdwEBAah;
				num = 776989257;
				goto IL_008f;
				IL_01ef:
				actualInputPlatform = InputPlatform.RBYZuIoTfgdiCjovvTtnANAPAAn;
				platform = ouya;
				num = 776989250;
				goto IL_008f;
				IL_01db:
				actualInputPlatform = InputPlatform.JTFQFctybCbrhbHanPIAsCqFHew;
				platform = linux;
				num = 776989264;
				goto IL_008f;
				IL_01b7:
				actualInputPlatform = InputPlatform.XnBBtfDGsHOaIaHObPJBJNGTMJOh;
				platform = osx;
				num = 776989250;
				goto IL_008f;
				IL_01a0:
				platform = FindSDL2Map(inputSource, true, out actualInputPlatform, out variantIndex);
				num = 776989250;
				goto IL_008f;
				IL_0190:
				throw new NotImplementedException();
				IL_0179:
				platform = FindFallbackMap(inputSource, true, out actualInputPlatform, out variantIndex);
				num = 776989250;
				goto IL_008f;
				IL_016d:
				actualInputPlatform = InputPlatform.VqUKRozySjqEFelrCfPDPBJTuhE;
				num = 776989267;
				goto IL_008f;
				IL_0146:
				actualInputPlatform = InputPlatform.PmnSHpCUoGadlRLWMAbfdlxfwVg;
				num = 776989258;
				goto IL_008f;
				IL_0139:
				actualInputPlatform = InputPlatform.GdzkbPzfoHvypKbmmdwEXhUPKcR;
				num = 776989279;
				goto IL_008f;
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
			Rewired.Platforms.Platform platform = default(Rewired.Platforms.Platform);
			Rewired.Platforms.Platform platform2 = default(Rewired.Platforms.Platform);
			Platform_Fallback_Base platform_Fallback_Base = default(Platform_Fallback_Base);
			while (true)
			{
				int num = 322603035;
				while (true)
				{
					switch (num ^ 0x133A8819)
					{
					case 13:
						break;
					case 34:
						platform = Rewired.Platforms.Platform.OSX;
						num = 322603032;
						continue;
					case 0:
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 32:
						platform_Fallback_Base = fallback_Windows;
						actualInputPlatform = InputPlatform.McFswYkXWzgANotVGtrqfIYsOjf;
						num = 322603038;
						continue;
					case 10:
						if (isDefaultMap)
						{
							int num6;
							if (platform_Fallback_Base == null)
							{
								num = 322603018;
								num6 = num;
							}
							else
							{
								num = 322603013;
								num6 = num;
							}
							continue;
						}
						goto case 19;
					case 18:
						num = 322603032;
						continue;
					case 4:
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 20:
						actualInputPlatform = InputPlatform.McFswYkXWzgANotVGtrqfIYsOjf;
						num = 322603033;
						continue;
					case 17:
						actualInputPlatform = InputPlatform.CIfoOXlWCMRNswyagQhdgfUFTLq;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 30:
						platform_Fallback_Base = fallback_OSX;
						num = 322603022;
						continue;
					case 19:
						if (platform_Fallback_Base != null)
						{
							return platform_Fallback_Base;
						}
						platform_Fallback_Base = fallback_Android;
						actualInputPlatform = InputPlatform.CIfoOXlWCMRNswyagQhdgfUFTLq;
						num = 322603036;
						continue;
					case 31:
						actualInputPlatform = InputPlatform.HKkwjUekOVZLDaSGCDRzSvemvRv;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 26:
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 16:
						if (platform_Fallback_Base != null)
						{
							return platform_Fallback_Base;
						}
						platform_Fallback_Base = fallback_Android;
						actualInputPlatform = InputPlatform.CIfoOXlWCMRNswyagQhdgfUFTLq;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 28:
					{
						int num3;
						if (actualInputPlatform == InputPlatform.aBotpnxjorwkyNsbbDILIHWMXQx)
						{
							num = 322603018;
							num3 = num;
						}
						else
						{
							num = 322603023;
							num3 = num;
						}
						continue;
					}
					case 8:
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 15:
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 14:
						if (platform_Fallback_Base != null)
						{
							return platform_Fallback_Base;
						}
						goto IL_0366;
					case 29:
						platform_Fallback_Base = null;
						num = 322603031;
						continue;
					case 12:
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 25:
						platform_Fallback_Base = TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						num = 322603027;
						continue;
					case 27:
					{
						int num5;
						if (actualInputPlatform != InputPlatform.LCEJHHFLdfBcULIYrFfvINmRZaC)
						{
							num = 322603066;
							num5 = num;
						}
						else
						{
							num = 322603017;
							num5 = num;
						}
						continue;
					}
					case 6:
						goto IL_0412;
					case 7:
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 1:
						platform2 = platform;
						switch (platform2)
						{
						case Rewired.Platforms.Platform.Windows:
						case Rewired.Platforms.Platform.WindowsAppStore:
							break;
						case Rewired.Platforms.Platform.WindowsPhone8:
							platform_Fallback_Base = fallback_WindowsPhone8;
							actualInputPlatform = InputPlatform.repgBILqjafyVDVNazChdjraWGS;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.Xbox360:
							platform_Fallback_Base = fallback_XBox360;
							actualInputPlatform = InputPlatform.kHoUOtzQtUUdfLDhidUxGcbvBZqF;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.XboxOne:
							platform_Fallback_Base = fallback_XBoxOne;
							actualInputPlatform = InputPlatform.BzEfgFGavjEcAulUOjrrSDlKQTGr;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.PS3:
							platform_Fallback_Base = fallback_PS3;
							actualInputPlatform = InputPlatform.EmeNcUDVoZWNsjdFwsjNDjWGDfj;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.PS4:
							goto IL_0193;
						case Rewired.Platforms.Platform.iOS:
						case Rewired.Platforms.Platform.tvOS:
							platform_Fallback_Base = fallback_iOS;
							actualInputPlatform = InputPlatform.uCpEvEMvgQZapNoeegiJcOxNcoQD;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.Blackberry:
							goto IL_01e1;
						case Rewired.Platforms.Platform.Android:
							goto IL_0246;
						case Rewired.Platforms.Platform.WiiU:
							goto IL_0266;
						case Rewired.Platforms.Platform.Webplayer:
							goto IL_029c;
						case Rewired.Platforms.Platform.OSX:
							platform_Fallback_Base = fallback_OSX;
							actualInputPlatform = InputPlatform.GsUbViGkFcyqyCKifsojPTKXqWF;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.Linux:
							goto IL_0321;
						case Rewired.Platforms.Platform.PSMobile:
							platform_Fallback_Base = fallback_PSM;
							actualInputPlatform = InputPlatform.owvzyNBqrgfjJOEeDdlqxCEBOlM;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.PSVita:
							platform_Fallback_Base = fallback_PSVita;
							actualInputPlatform = InputPlatform.KXhxaNHXGTGcLaaUlpiiluTTrQz;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.Wii:
							goto IL_03c8;
						case Rewired.Platforms.Platform.WindowsUWP:
							goto IL_042d;
						default:
							goto IL_04ce;
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
							goto IL_04eb;
						}
						goto case 32;
					case 23:
						actualInputPlatform = InputPlatform.GsUbViGkFcyqyCKifsojPTKXqWF;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 33:
						goto IL_04eb;
					case 9:
						goto IL_050b;
					case 11:
						switch (platform2)
						{
						case Rewired.Platforms.Platform.AmazonFireTV:
							platform_Fallback_Base = fallback_AmazonFireTV;
							actualInputPlatform = InputPlatform.aBotpnxjorwkyNsbbDILIHWMXQx;
							num = 322603008;
							break;
						default:
							num = 322603064;
							break;
						case Rewired.Platforms.Platform.RazerForgeTV:
							platform_Fallback_Base = fallback_RazerForgeTV;
							num = 322603009;
							break;
						}
						continue;
					case 22:
						platform_Fallback_Base = null;
						num = 322603018;
						continue;
					case 24:
						actualInputPlatform = InputPlatform.LCEJHHFLdfBcULIYrFfvINmRZaC;
						platform_Fallback_Base = TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						if (isDefaultMap)
						{
							int num2;
							if (platform_Fallback_Base == null)
							{
								num = 322603017;
								num2 = num;
							}
							else
							{
								num = 322603010;
								num2 = num;
							}
							continue;
						}
						goto case 16;
					case 5:
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 3:
						actualInputPlatform = InputPlatform.ZKWidWrlaThGECHiJOTMPiQDeNmy;
						num = 322603029;
						continue;
					case 2:
						platform = UnityTools.platform;
						switch (UnityTools.editorPlatform)
						{
						case EditorPlatform.OSX:
							break;
						case EditorPlatform.Windows:
							goto IL_0412;
						case EditorPlatform.Linux:
							goto IL_050b;
						default:
							goto IL_05bf;
						}
						goto case 34;
					case 35:
						platform_Fallback_Base = null;
						num = 322603017;
						continue;
					default:
						{
							return null;
						}
						IL_05bf:
						num = 322603032;
						continue;
						IL_050b:
						platform = Rewired.Platforms.Platform.Linux;
						num = 322603032;
						continue;
						IL_04ce:
						num = 322603026;
						continue;
						IL_042d:
						platform_Fallback_Base = fallback_WindowsUWP;
						actualInputPlatform = InputPlatform.sCdDNwtMYFScYiSiaApcdEhdPhV;
						num = 322603030;
						continue;
						IL_03c8:
						platform_Fallback_Base = fallback_Wii;
						actualInputPlatform = InputPlatform.QNhZJCgIiKtWplNtQhoZdsfJTGr;
						num = 322603011;
						continue;
						IL_0321:
						if (inputSource == InputSource.Fallback_PreConfigured)
						{
							platform_Fallback_Base = fallback_Linux_PreConfigured;
							actualInputPlatform = InputPlatform.gTNEAofYYjqjGgmHBDJWPyqwpNL;
							platform_Fallback_Base = TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
							if (isDefaultMap && platform_Fallback_Base != null)
							{
								int num4;
								if (actualInputPlatform == InputPlatform.gTNEAofYYjqjGgmHBDJWPyqwpNL)
								{
									num = 322603031;
									num4 = num;
								}
								else
								{
									num = 322603012;
									num4 = num;
								}
								continue;
							}
							goto case 14;
						}
						goto IL_0366;
						IL_029c:
						if (UnityTools.webplayerPlatform != WebplayerPlatform.Windows)
						{
							if (UnityTools.webplayerPlatform == WebplayerPlatform.OSX)
							{
								num = 322603015;
								continue;
							}
							goto IL_04eb;
						}
						platform_Fallback_Base = fallback_Windows;
						num = 322603021;
						continue;
						IL_04eb:
						if (isDefaultMap)
						{
							return GetUniversalDefaultMap<Platform_Fallback_Base>(out actualInputPlatform, out variantIndex);
						}
						variantIndex = -1;
						actualInputPlatform = InputPlatform.srbgNzJMznryeuABhpjzUCNZxjJP;
						num = 322603020;
						continue;
						IL_0266:
						platform_Fallback_Base = fallback_WiiU;
						actualInputPlatform = InputPlatform.WthhOcQoizQolOdiDvOAlMmegJQ;
						num = 322603025;
						continue;
						IL_0246:
						platform_Fallback_Base = fallback_Android;
						num = 322603016;
						continue;
						IL_01e1:
						platform_Fallback_Base = fallback_Blackberry;
						actualInputPlatform = InputPlatform.syUCJJftIJnPEzmtayELWiIazRZ;
						num = 322603037;
						continue;
						IL_0193:
						platform_Fallback_Base = fallback_PS4;
						num = 322603034;
						continue;
						IL_0412:
						platform = Rewired.Platforms.Platform.Windows;
						num = 322603019;
						continue;
						IL_0366:
						platform_Fallback_Base = fallback_Linux;
						num = 322603014;
						continue;
					}
					break;
				}
			}
		}

		private Platform_Fallback_Base FindFallbackMap(InputSource inputSource, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			Rewired.Platforms.Platform platform = UnityTools.platform;
			switch (UnityTools.editorPlatform)
			{
			case EditorPlatform.Linux:
				goto IL_035f;
			case EditorPlatform.Windows:
				goto IL_03ee;
			case EditorPlatform.OSX:
				goto IL_0408;
			}
			goto IL_0020;
			IL_0020:
			int num = -164996217;
			goto IL_0025;
			IL_0025:
			Platform_Fallback_Base platform_Fallback_Base = default(Platform_Fallback_Base);
			while (true)
			{
				switch (num ^ -164996200)
				{
				case 21:
					break;
				case 6:
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case 3:
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case 22:
					actualInputPlatform = InputPlatform.GsUbViGkFcyqyCKifsojPTKXqWF;
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case 27:
					goto IL_0138;
				case 34:
					if (actualInputPlatform != InputPlatform.aBotpnxjorwkyNsbbDILIHWMXQx)
					{
						platform_Fallback_Base = null;
						num = -164996165;
						continue;
					}
					goto IL_042f;
				case 29:
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case 32:
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case 33:
					actualInputPlatform = InputPlatform.sCdDNwtMYFScYiSiaApcdEhdPhV;
					num = -164996195;
					continue;
				case 17:
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case 11:
					goto IL_0219;
				case 2:
					goto IL_0233;
				case 9:
					goto IL_0256;
				case 4:
					goto IL_026d;
				case 18:
					goto IL_0317;
				case 0:
					goto IL_035f;
				case 7:
					platform_Fallback_Base = null;
					num = -164996204;
					continue;
				case 12:
					goto IL_0377;
				case 19:
					actualInputPlatform = InputPlatform.syUCJJftIJnPEzmtayELWiIazRZ;
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case 16:
					actualInputPlatform = InputPlatform.aBotpnxjorwkyNsbbDILIHWMXQx;
					num = -164996208;
					continue;
				case 24:
					goto IL_03ee;
				case 14:
					actualInputPlatform = InputPlatform.CIfoOXlWCMRNswyagQhdgfUFTLq;
					num = -164996212;
					continue;
				case 30:
					goto IL_0408;
				case 15:
					if (platform_Fallback_Base != null && actualInputPlatform != InputPlatform.gTNEAofYYjqjGgmHBDJWPyqwpNL)
					{
						platform_Fallback_Base = null;
						num = -164996214;
						continue;
					}
					goto IL_0317;
				case 35:
					goto IL_042f;
				case 10:
					actualInputPlatform = InputPlatform.McFswYkXWzgANotVGtrqfIYsOjf;
					num = -164996197;
					continue;
				case 1:
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case 25:
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case 26:
					actualInputPlatform = InputPlatform.CIfoOXlWCMRNswyagQhdgfUFTLq;
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case 5:
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case 31:
					num = -164996196;
					continue;
				case 20:
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case 28:
					num = -164996196;
					continue;
				case 13:
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case 8:
					goto IL_054d;
				default:
					return null;
				}
				break;
				IL_054d:
				platform_Fallback_Base = TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				int num2;
				if (!isDefaultMap)
				{
					num = -164996165;
					num2 = num;
				}
				else
				{
					num = -164996207;
					num2 = num;
				}
				continue;
				IL_0204:
				platform_Fallback_Base = fallback_WiiU;
				actualInputPlatform = InputPlatform.WthhOcQoizQolOdiDvOAlMmegJQ;
				num = -164996203;
				continue;
				IL_01cf:
				if (inputSource == InputSource.Fallback_PreConfigured)
				{
					platform_Fallback_Base = fallback_Linux_PreConfigured;
					actualInputPlatform = InputPlatform.gTNEAofYYjqjGgmHBDJWPyqwpNL;
					num = -164996198;
					continue;
				}
				goto IL_031c;
				IL_0317:
				if (platform_Fallback_Base != null)
				{
					return platform_Fallback_Base;
				}
				goto IL_031c;
				IL_01ae:
				platform_Fallback_Base = fallback_PSM;
				actualInputPlatform = InputPlatform.owvzyNBqrgfjJOEeDdlqxCEBOlM;
				num = -164996194;
				continue;
				IL_026d:
				switch (platform)
				{
				case Rewired.Platforms.Platform.PSVita:
					break;
				default:
					goto IL_011a;
				case Rewired.Platforms.Platform.Windows:
				case Rewired.Platforms.Platform.WindowsAppStore:
					goto IL_0138;
				case Rewired.Platforms.Platform.WindowsUWP:
					goto IL_014e;
				case Rewired.Platforms.Platform.PS3:
					platform_Fallback_Base = fallback_PS3;
					actualInputPlatform = InputPlatform.EmeNcUDVoZWNsjdFwsjNDjWGDfj;
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case Rewired.Platforms.Platform.PS4:
					platform_Fallback_Base = fallback_PS4;
					actualInputPlatform = InputPlatform.ZKWidWrlaThGECHiJOTMPiQDeNmy;
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case Rewired.Platforms.Platform.PSMobile:
					goto IL_01ae;
				case Rewired.Platforms.Platform.Linux:
					goto IL_01cf;
				case Rewired.Platforms.Platform.WiiU:
					goto IL_0204;
				case Rewired.Platforms.Platform.Android:
					platform_Fallback_Base = fallback_Android;
					actualInputPlatform = InputPlatform.CIfoOXlWCMRNswyagQhdgfUFTLq;
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case Rewired.Platforms.Platform.iOS:
				case Rewired.Platforms.Platform.tvOS:
					goto IL_034a;
				case Rewired.Platforms.Platform.WindowsPhone8:
					platform_Fallback_Base = fallback_WindowsPhone8;
					actualInputPlatform = InputPlatform.repgBILqjafyVDVNazChdjraWGS;
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case Rewired.Platforms.Platform.Xbox360:
					platform_Fallback_Base = fallback_XBox360;
					actualInputPlatform = InputPlatform.kHoUOtzQtUUdfLDhidUxGcbvBZqF;
					return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case Rewired.Platforms.Platform.XboxOne:
					goto IL_03cb;
				case Rewired.Platforms.Platform.Blackberry:
					goto IL_045e;
				case Rewired.Platforms.Platform.Wii:
					goto IL_047b;
				case Rewired.Platforms.Platform.Webplayer:
					goto IL_04a0;
				case Rewired.Platforms.Platform.OSX:
					goto IL_04c8;
				case Rewired.Platforms.Platform.RazerForgeTV:
					goto IL_04f2;
				case Rewired.Platforms.Platform.AmazonFireTV:
					goto IL_053c;
				}
				platform_Fallback_Base = fallback_PSVita;
				actualInputPlatform = InputPlatform.KXhxaNHXGTGcLaaUlpiiluTTrQz;
				num = -164996223;
				continue;
				IL_053c:
				platform_Fallback_Base = fallback_AmazonFireTV;
				num = -164996216;
				continue;
				IL_04f2:
				platform_Fallback_Base = fallback_RazerForgeTV;
				actualInputPlatform = InputPlatform.LCEJHHFLdfBcULIYrFfvINmRZaC;
				platform_Fallback_Base = TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				if (isDefaultMap)
				{
					int num3;
					if (platform_Fallback_Base != null)
					{
						num = -164996205;
						num3 = num;
					}
					else
					{
						num = -164996204;
						num3 = num;
					}
					continue;
				}
				goto IL_0377;
				IL_011a:
				if (isDefaultMap)
				{
					return GetUniversalDefaultMap<Platform_Fallback_Base>(out actualInputPlatform, out variantIndex);
				}
				variantIndex = -1;
				actualInputPlatform = InputPlatform.srbgNzJMznryeuABhpjzUCNZxjJP;
				num = -164996209;
				continue;
				IL_0233:
				platform_Fallback_Base = TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				int num4;
				if (!isDefaultMap)
				{
					num = -164996214;
					num4 = num;
				}
				else
				{
					num = -164996201;
					num4 = num;
				}
				continue;
				IL_042f:
				if (platform_Fallback_Base != null)
				{
					return platform_Fallback_Base;
				}
				platform_Fallback_Base = fallback_Android;
				num = -164996202;
				continue;
				IL_0377:
				if (platform_Fallback_Base != null)
				{
					return platform_Fallback_Base;
				}
				platform_Fallback_Base = fallback_Android;
				num = -164996222;
				continue;
				IL_0138:
				platform_Fallback_Base = fallback_Windows;
				actualInputPlatform = InputPlatform.McFswYkXWzgANotVGtrqfIYsOjf;
				return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				IL_0219:
				int num5;
				if (actualInputPlatform == InputPlatform.LCEJHHFLdfBcULIYrFfvINmRZaC)
				{
					num = -164996204;
					num5 = num;
				}
				else
				{
					num = -164996193;
					num5 = num;
				}
				continue;
				IL_04c8:
				platform_Fallback_Base = fallback_OSX;
				actualInputPlatform = InputPlatform.GsUbViGkFcyqyCKifsojPTKXqWF;
				num = -164996168;
				continue;
				IL_04a0:
				if (UnityTools.webplayerPlatform != WebplayerPlatform.Windows)
				{
					if (UnityTools.webplayerPlatform == WebplayerPlatform.OSX)
					{
						platform_Fallback_Base = fallback_OSX;
						num = -164996210;
						continue;
					}
					goto IL_011a;
				}
				platform_Fallback_Base = fallback_Windows;
				num = -164996206;
				continue;
				IL_014e:
				platform_Fallback_Base = fallback_WindowsUWP;
				num = -164996167;
				continue;
				IL_0256:
				int num6;
				if (platform_Fallback_Base == null)
				{
					num = -164996165;
					num6 = num;
				}
				else
				{
					num = -164996166;
					num6 = num;
				}
				continue;
				IL_031c:
				platform_Fallback_Base = fallback_Linux;
				actualInputPlatform = InputPlatform.HKkwjUekOVZLDaSGCDRzSvemvRv;
				return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
				IL_047b:
				platform_Fallback_Base = fallback_Wii;
				actualInputPlatform = InputPlatform.QNhZJCgIiKtWplNtQhoZdsfJTGr;
				num = -164996215;
				continue;
				IL_045e:
				platform_Fallback_Base = fallback_Blackberry;
				num = -164996213;
				continue;
				IL_03cb:
				platform_Fallback_Base = fallback_XBoxOne;
				actualInputPlatform = InputPlatform.BzEfgFGavjEcAulUOjrrSDlKQTGr;
				num = -164996219;
				continue;
				IL_034a:
				platform_Fallback_Base = fallback_iOS;
				actualInputPlatform = InputPlatform.uCpEvEMvgQZapNoeegiJcOxNcoQD;
				num = -164996199;
			}
			goto IL_0020;
			IL_035f:
			platform = Rewired.Platforms.Platform.Linux;
			num = -164996196;
			goto IL_0025;
			IL_0408:
			platform = Rewired.Platforms.Platform.OSX;
			num = -164996196;
			goto IL_0025;
			IL_03ee:
			platform = Rewired.Platforms.Platform.Windows;
			num = -164996220;
			goto IL_0025;
		}

		private Platform_SDL2_Base FindSDL2Match(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			Rewired.Platforms.Platform platform = UnityTools.platform;
			int num;
			Platform_SDL2_Base mainMap;
			switch (UnityTools.editorPlatform)
			{
			case EditorPlatform.Windows:
				platform = Rewired.Platforms.Platform.Windows;
				num = 1585818325;
				goto IL_002a;
			default:
				goto IL_00c2;
			case EditorPlatform.OSX:
				goto IL_00e8;
			case EditorPlatform.Linux:
				goto IL_00f4;
				IL_002a:
				while (true)
				{
					switch (num ^ 0x5E85AAD6)
					{
					case 0:
						num = 1585818320;
						continue;
					case 6:
						break;
					case 2:
						goto IL_005f;
					case 3:
						goto IL_00c2;
					case 4:
						goto IL_00e8;
					case 5:
						goto IL_00f4;
					default:
						goto end_IL_000f;
					}
					break;
				}
				goto case EditorPlatform.Windows;
				IL_00f4:
				platform = Rewired.Platforms.Platform.Linux;
				num = 1585818325;
				goto IL_002a;
				IL_00e8:
				platform = Rewired.Platforms.Platform.OSX;
				num = 1585818325;
				goto IL_002a;
				IL_00c2:
				switch (platform)
				{
				case Rewired.Platforms.Platform.Windows:
					break;
				case Rewired.Platforms.Platform.Linux:
					mainMap = sdl2_Linux;
					actualInputPlatform = InputPlatform.BtFqWkGfbcntjEvnTsZuElsxALh;
					return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
				case Rewired.Platforms.Platform.OSX:
					mainMap = sdl2_OSX;
					actualInputPlatform = InputPlatform.JmPIAzBjQudHUaJpsJVzbjewKnzc;
					return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
				default:
					goto IL_00aa;
				}
				goto IL_005f;
				IL_00aa:
				if (!isDefaultMap)
				{
					break;
				}
				GetUniversalDefaultMap<Platform_SDL2_Base>(out actualInputPlatform, out variantIndex);
				num = 1585818327;
				goto IL_002a;
				IL_005f:
				mainMap = sdl2_Windows;
				actualInputPlatform = InputPlatform.yjiucoxrmUBsAnnTecimEdVWxENC;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
				end_IL_000f:
				break;
			}
			actualInputPlatform = InputPlatform.srbgNzJMznryeuABhpjzUCNZxjJP;
			variantIndex = -1;
			return null;
		}

		private Platform_SDL2_Base FindSDL2Map(InputSource inputSource, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			Rewired.Platforms.Platform platform = UnityTools.platform;
			EditorPlatform editorPlatform = UnityTools.editorPlatform;
			Platform_SDL2_Base mainMap = default(Platform_SDL2_Base);
			while (true)
			{
				int num = -564830420;
				while (true)
				{
					switch (num ^ -564830417)
					{
					case 4:
						break;
					case 2:
						return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 1:
						if (isDefaultMap)
						{
							GetUniversalDefaultMap<Platform_SDL2_Base>(out actualInputPlatform, out variantIndex);
							num = -564830417;
							continue;
						}
						goto case 0;
					case 11:
						platform = Rewired.Platforms.Platform.Windows;
						num = -564830423;
						continue;
					case 8:
						actualInputPlatform = InputPlatform.yjiucoxrmUBsAnnTecimEdVWxENC;
						return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 6:
						switch (platform)
						{
						case Rewired.Platforms.Platform.iOS:
							break;
						case Rewired.Platforms.Platform.Linux:
							mainMap = sdl2_Linux;
							actualInputPlatform = InputPlatform.BtFqWkGfbcntjEvnTsZuElsxALh;
							return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.OSX:
							goto IL_00a4;
						default:
							goto IL_00d3;
						case Rewired.Platforms.Platform.Windows:
							goto IL_00dd;
						}
						goto case 1;
					case 5:
						goto IL_00dd;
					case 9:
						goto IL_00ee;
					case 3:
						switch (editorPlatform)
						{
						case EditorPlatform.Windows:
							break;
						case EditorPlatform.Linux:
							goto IL_00ee;
						default:
							goto IL_010e;
						case EditorPlatform.OSX:
							goto IL_0118;
						}
						goto case 11;
					case 7:
						goto IL_0118;
					case 0:
						actualInputPlatform = InputPlatform.srbgNzJMznryeuABhpjzUCNZxjJP;
						num = -564830427;
						continue;
					default:
						{
							variantIndex = -1;
							return null;
						}
						IL_0118:
						platform = Rewired.Platforms.Platform.OSX;
						num = -564830423;
						continue;
						IL_010e:
						num = -564830423;
						continue;
						IL_00ee:
						platform = Rewired.Platforms.Platform.Linux;
						num = -564830423;
						continue;
						IL_00dd:
						mainMap = sdl2_Windows;
						num = -564830425;
						continue;
						IL_00d3:
						num = -564830418;
						continue;
						IL_00a4:
						mainMap = sdl2_OSX;
						actualInputPlatform = InputPlatform.JmPIAzBjQudHUaJpsJVzbjewKnzc;
						num = -564830419;
						continue;
					}
					break;
				}
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
				goto IL_0116;
			}
			int num;
			if (mainMap != null)
			{
				if (!mainMap.selfOrVariantIsValid)
				{
					num = 1345636930;
					goto IL_0016;
				}
				return mainMap.GetFirstValidPlatformMap(out variantIndex) as T;
			}
			goto IL_015a;
			IL_0011:
			num = 1345636935;
			goto IL_0016;
			IL_0016:
			Platform platform = default(Platform);
			IList<Platform> variants_base = default(IList<Platform>);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x5034CA42)
				{
				case 9:
					break;
				case 11:
					platform = variants_base[num2];
					num = 1345636936;
					continue;
				case 10:
					goto IL_0065;
				case 2:
					variantIndex = num2;
					num = 1345636938;
					continue;
				case 8:
					return platform as T;
				case 1:
					num2 = 0;
					num = 1345636932;
					continue;
				case 4:
					goto IL_009d;
				case 3:
					return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
				case 5:
					goto IL_00e0;
				case 6:
					goto IL_00f9;
				case 7:
					goto IL_0116;
				default:
					goto IL_015a;
				}
				break;
				IL_00f9:
				int num3;
				if (num2 >= variants_base.Count)
				{
					num = 1345636929;
					num3 = num;
				}
				else
				{
					num = 1345636937;
					num3 = num;
				}
				continue;
				IL_0086:
				num2++;
				num = 1345636932;
				continue;
				IL_0065:
				if (platform != null)
				{
					num = 1345636934;
					continue;
				}
				goto IL_0086;
				IL_00e0:
				if (!mainMap.selfOrVariantIsAllowed)
				{
					num = 1345636933;
					continue;
				}
				if (mainMap.isAllowed)
				{
					variantIndex = -1;
					return mainMap;
				}
				variants_base = mainMap.variants_base;
				int num4;
				if (variants_base != null)
				{
					num = 1345636931;
					num4 = num;
				}
				else
				{
					num = 1345636929;
					num4 = num;
				}
				continue;
				IL_009d:
				if (platform.isAllowed)
				{
					num = 1345636928;
					continue;
				}
				goto IL_0086;
			}
			goto IL_0011;
			IL_015a:
			variantIndex = -1;
			return null;
			IL_0116:
			return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
		}

		private T TryGetFirstMatchingMap<T>(T mainMap, BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, ref InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
		{
			Platform platformMap = default(Platform);
			if (isDefaultMap)
			{
				if (mainMap == null)
				{
					return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
				}
				if (mainMap.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return platformMap as T;
				}
				return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
			}
			if (mainMap == null)
			{
				goto IL_004b;
			}
			int num;
			if (mainMap.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				num = -976181671;
			}
			else
			{
				variantIndex = -1;
				num = -976181670;
			}
			goto IL_0050;
			IL_0050:
			switch (num ^ -976181672)
			{
			case 0:
				break;
			case 3:
				variantIndex = -1;
				return null;
			case 1:
				return platformMap as T;
			default:
				return null;
			}
			goto IL_004b;
			IL_004b:
			num = -976181669;
			goto IL_0050;
		}

		private T GetUniversalDefaultMap<T>(out InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
		{
			T universalDefaultMapRoot = GetUniversalDefaultMapRoot<T>(typeof(T), out actualInputPlatform);
			actualInputPlatform = InputPlatform.yjiucoxrmUBsAnnTecimEdVWxENC;
			variantIndex = -1;
			if (universalDefaultMapRoot != null)
			{
				goto IL_0024;
			}
			goto IL_00a7;
			IL_0024:
			int num = 931118445;
			goto IL_0029;
			IL_0029:
			IList<Platform> variants_base = default(IList<Platform>);
			int num2 = default(int);
			T result = default(T);
			while (true)
			{
				switch (num ^ 0x377FBD64)
				{
				case 4:
					break;
				case 9:
					goto IL_0061;
				case 2:
					if (variants_base != null)
					{
						num2 = 0;
						num = 931118433;
						continue;
					}
					goto default;
				case 1:
					goto IL_0086;
				case 3:
					goto IL_00a7;
				case 0:
					return result;
				case 7:
					return variants_base[num2] as T;
				case 5:
					num = 931118444;
					continue;
				case 8:
					goto IL_010e;
				default:
					return null;
				}
				break;
				IL_010e:
				int num3;
				if (num2 < variants_base.Count)
				{
					num = 931118437;
					num3 = num;
				}
				else
				{
					num = 931118434;
					num3 = num;
				}
				continue;
				IL_0086:
				if (variants_base[num2] != null && variants_base[num2].isAllowed)
				{
					variantIndex = num2;
					num = 931118435;
				}
				else
				{
					num2++;
					num = 931118444;
				}
				continue;
				IL_0061:
				if (!universalDefaultMapRoot.selfOrVariantIsAllowed)
				{
					num = 931118439;
					continue;
				}
				if (universalDefaultMapRoot.isAllowed)
				{
					return universalDefaultMapRoot;
				}
				variants_base = universalDefaultMapRoot.variants_base;
				num = 931118438;
			}
			goto IL_0024;
			IL_00a7:
			result = null;
			num = 931118436;
			goto IL_0029;
		}

		private T GetUniversalDefaultMapRoot<T>(Type type, out InputPlatform actualInputPlatform) where T : Platform
		{
			if (object.ReferenceEquals(type, typeof(Platform_Fallback_Base)))
			{
				actualInputPlatform = InputPlatform.McFswYkXWzgANotVGtrqfIYsOjf;
				goto IL_0015;
			}
			int num;
			if (object.ReferenceEquals(type, typeof(Platform_SDL2_Base)))
			{
				actualInputPlatform = InputPlatform.yjiucoxrmUBsAnnTecimEdVWxENC;
				num = -607449258;
				goto IL_001a;
			}
			throw new NotImplementedException();
			IL_0015:
			num = -607449259;
			goto IL_001a;
			IL_001a:
			switch (num ^ -607449260)
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
			switch (exactInputPlatform)
			{
			case InputPlatform.hQxvcadrrPaLqOjHlvDNLCWZlDw:
				return directInput;
			case InputPlatform.PmnSHpCUoGadlRLWMAbfdlxfwVg:
				return rawInput;
			case InputPlatform.VqUKRozySjqEFelrCfPDPBJTuhE:
				return xInput;
			case InputPlatform.McFswYkXWzgANotVGtrqfIYsOjf:
				return fallback_Windows;
			case InputPlatform.IHkiTQGteWsegyfjGnNBuPLSILmD:
				return windowsUWP;
			case InputPlatform.sCdDNwtMYFScYiSiaApcdEhdPhV:
				return fallback_WindowsUWP;
			case InputPlatform.XnBBtfDGsHOaIaHObPJBJNGTMJOh:
				return osx;
			case InputPlatform.GsUbViGkFcyqyCKifsojPTKXqWF:
				return fallback_OSX;
			case InputPlatform.JTFQFctybCbrhbHanPIAsCqFHew:
				return linux;
			case InputPlatform.HKkwjUekOVZLDaSGCDRzSvemvRv:
				return fallback_Linux;
			case InputPlatform.gTNEAofYYjqjGgmHBDJWPyqwpNL:
				return fallback_Linux_PreConfigured;
			case InputPlatform.CIfoOXlWCMRNswyagQhdgfUFTLq:
				return fallback_Android;
			case InputPlatform.aBotpnxjorwkyNsbbDILIHWMXQx:
				return fallback_AmazonFireTV;
			case InputPlatform.LCEJHHFLdfBcULIYrFfvINmRZaC:
				return fallback_RazerForgeTV;
			case InputPlatform.uCpEvEMvgQZapNoeegiJcOxNcoQD:
				return fallback_iOS;
			case InputPlatform.repgBILqjafyVDVNazChdjraWGS:
				return fallback_WindowsPhone8;
			case InputPlatform.syUCJJftIJnPEzmtayELWiIazRZ:
				return fallback_Blackberry;
			case InputPlatform.EmeNcUDVoZWNsjdFwsjNDjWGDfj:
				return fallback_PS3;
			case InputPlatform.ZKWidWrlaThGECHiJOTMPiQDeNmy:
				return fallback_PS4;
			case InputPlatform.owvzyNBqrgfjJOEeDdlqxCEBOlM:
				return fallback_PSM;
			case InputPlatform.KXhxaNHXGTGcLaaUlpiiluTTrQz:
				return fallback_PSVita;
			case InputPlatform.kHoUOtzQtUUdfLDhidUxGcbvBZqF:
				return fallback_XBox360;
			case InputPlatform.BzEfgFGavjEcAulUOjrrSDlKQTGr:
				return fallback_XBoxOne;
			case InputPlatform.QNhZJCgIiKtWplNtQhoZdsfJTGr:
				return fallback_Wii;
			case InputPlatform.WthhOcQoizQolOdiDvOAlMmegJQ:
				return fallback_WiiU;
			case InputPlatform.MEQxKcJyEOIzwyouWrqjNydTDGq:
				return nintendoSwitch;
			case InputPlatform.EVZdDKgoYzTsgudyOpbfAYPsMaVf:
				throw new NotImplementedException();
			case InputPlatform.yjiucoxrmUBsAnnTecimEdVWxENC:
				return sdl2_Windows;
			case InputPlatform.JmPIAzBjQudHUaJpsJVzbjewKnzc:
				return sdl2_OSX;
			case InputPlatform.BtFqWkGfbcntjEvnTsZuElsxALh:
				return sdl2_Linux;
			case InputPlatform.srbgNzJMznryeuABhpjzUCNZxjJP:
			case InputPlatform.gBTkPmAyPkhrIHErFhGGXZEcsey:
				throw new NotImplementedException();
			case InputPlatform.DUbQuJCDfrUzNLyHOFGFbNvqDqG:
				return internalDriver;
			case InputPlatform.xzaOPbUxziNeuflqekRIWgtGJg:
				throw new NotImplementedException();
			case InputPlatform.wOtEjdlwdBaCIAeldUVaNMnbIoRs:
				return webGL;
			case InputPlatform.RBYZuIoTfgdiCjovvTtnANAPAAn:
				return ouya;
			case InputPlatform.GdzkbPzfoHvypKbmmdwEXhUPKcR:
				return xboxOne;
			case InputPlatform.DtbPZmFOLnHQmXPWMCnIdwEBAah:
				return ps4;
			case InputPlatform.djmWmEhmVdfksZwGfNzZHFuqaoh:
				throw new NotImplementedException();
			default:
				throw new NotImplementedException();
			}
		}
	}
}
