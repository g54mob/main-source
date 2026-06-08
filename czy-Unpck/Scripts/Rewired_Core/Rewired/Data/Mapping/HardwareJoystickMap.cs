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
			private sealed class IDVwPtPfVaaqoMgCXqcUUfyyuNG : IDisposable, IEnumerator, IEnumerable<Platform>, IEnumerator<Platform>, IEnumerable
			{
				private Platform ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public IList<Platform> owxOHiLkeUEumAfLVoCeTcexUdH;

				public int XAXgvQDSWhNpyDSPnvbYCFPIudvB;

				Platform IEnumerator<Platform>.Current
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
				IEnumerator<Platform> IEnumerable<Platform>.GetEnumerator()
				{
					IDVwPtPfVaaqoMgCXqcUUfyyuNG iDVwPtPfVaaqoMgCXqcUUfyyuNG;
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						iDVwPtPfVaaqoMgCXqcUUfyyuNG = this;
					}
					else
					{
						while (true)
						{
							iDVwPtPfVaaqoMgCXqcUUfyyuNG = new IDVwPtPfVaaqoMgCXqcUUfyyuNG(0);
							iDVwPtPfVaaqoMgCXqcUUfyyuNG.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
							int num = -1825072661;
							while (true)
							{
								switch (num ^ -1825072662)
								{
								case 0:
									num = -1825072664;
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
					return iDVwPtPfVaaqoMgCXqcUUfyyuNG;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = 1265804666;
						while (true)
						{
							switch (num2 ^ 0x4B72A57E)
							{
							case 0:
								break;
							case 3:
							{
								int num3;
								if (XAXgvQDSWhNpyDSPnvbYCFPIudvB < owxOHiLkeUEumAfLVoCeTcexUdH.Count)
								{
									num2 = 1265804668;
									num3 = num2;
								}
								else
								{
									num2 = 1265804671;
									num3 = num2;
								}
								continue;
							}
							case 7:
								num2 = 1265804671;
								continue;
							case 6:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								owxOHiLkeUEumAfLVoCeTcexUdH = syCPfFbHYMDOvEPjTnPLBqiOhsPv.variants_base;
								if (owxOHiLkeUEumAfLVoCeTcexUdH != null)
								{
									XAXgvQDSWhNpyDSPnvbYCFPIudvB = 0;
									num2 = 1265804669;
									continue;
								}
								goto default;
							case 4:
								switch (num)
								{
								case 0:
									break;
								default:
									num2 = 1265804665;
									continue;
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									num2 = 1265804667;
									continue;
								}
								goto case 6;
							case 5:
								XAXgvQDSWhNpyDSPnvbYCFPIudvB++;
								num2 = 1265804669;
								continue;
							case 2:
								if (owxOHiLkeUEumAfLVoCeTcexUdH[XAXgvQDSWhNpyDSPnvbYCFPIudvB] != null)
								{
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = owxOHiLkeUEumAfLVoCeTcexUdH[XAXgvQDSWhNpyDSPnvbYCFPIudvB];
									isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
									return true;
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
				public IDVwPtPfVaaqoMgCXqcUUfyyuNG(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public string description;

			internal abstract InputPlatform platform { get; }

			public abstract int assignedButtonCount { get; }

			public abstract int assignedAxisCount { get; }

			public virtual string controllerNameOverride => null;

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
					IDVwPtPfVaaqoMgCXqcUUfyyuNG iDVwPtPfVaaqoMgCXqcUUfyyuNG = new IDVwPtPfVaaqoMgCXqcUUfyyuNG(-2);
					iDVwPtPfVaaqoMgCXqcUUfyyuNG.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					return iDVwPtPfVaaqoMgCXqcUUfyyuNG;
				}
			}

			internal bool hasVariants => variantCount > 0;

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
					using (IEnumerator<Platform> enumerator = Variants.GetEnumerator())
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
								int num = 749339479;
								while (true)
								{
									switch (num ^ 0x2CAA0357)
									{
									case 2:
										num = 749339478;
										continue;
									case 1:
										break;
									default:
										goto end_IL_003a;
									case 0:
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
						Platform current = default(Platform);
						while (true)
						{
							IL_0050:
							int num;
							int num2;
							if (!enumerator.MoveNext())
							{
								num = 2106474474;
								num2 = num;
							}
							else
							{
								num = 2106474472;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ 0x7D8E3FE9)
								{
								case 4:
									num = 2106474472;
									continue;
								default:
									goto end_IL_002f;
								case 0:
									break;
								case 2:
									if (current.isAllowed && current.hasData)
									{
										return true;
									}
									break;
								case 1:
									current = enumerator.Current;
									num = 2106474475;
									continue;
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
						bool result = default(bool);
						while (enumerator.MoveNext())
						{
							while (true)
							{
								Platform current = enumerator.Current;
								int num = -73666943;
								while (true)
								{
									switch (num ^ -73666943)
									{
									case 3:
										num = -73666944;
										continue;
									case 0:
										if (current.isAllowed)
										{
											result = true;
											num = -73666941;
											continue;
										}
										goto end_IL_0058;
									case 1:
										break;
									default:
										goto end_IL_0058;
									case 2:
										return result;
									}
									break;
								}
								continue;
								end_IL_0058:
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
					return null;
				}
				if (isAllowed)
				{
					goto IL_0018;
				}
				goto IL_009c;
				IL_009c:
				IList<Platform> list = variants_base;
				int num;
				int num2;
				if (list == null)
				{
					num = -550132144;
					num2 = num;
				}
				else
				{
					num = -550132138;
					num2 = num;
				}
				goto IL_001d;
				IL_0018:
				num = -550132141;
				goto IL_001d;
				IL_001d:
				int num3 = default(int);
				Platform platform = default(Platform);
				while (true)
				{
					switch (num ^ -550132143)
					{
					case 3:
						break;
					case 5:
						goto IL_004d;
					case 7:
						num3 = 0;
						num = -550132137;
						continue;
					case 0:
						platform = list[num3];
						num = -550132140;
						continue;
					case 4:
						goto IL_0077;
					case 2:
						goto IL_008f;
					case 6:
						goto IL_00ba;
					default:
						return null;
					}
					break;
					IL_00ba:
					int num4;
					if (num3 >= list.Count)
					{
						num = -550132144;
						num4 = num;
					}
					else
					{
						num = -550132143;
						num4 = num;
					}
					continue;
					IL_0084:
					num3++;
					num = -550132137;
					continue;
					IL_004d:
					if (platform != null && platform.isAllowed)
					{
						num = -550132139;
						continue;
					}
					goto IL_0084;
					IL_0077:
					if (platform.hasData)
					{
						variantIndex = num3;
						return platform;
					}
					goto IL_0084;
				}
				goto IL_0018;
				IL_008f:
				if (hasData)
				{
					variantIndex = -1;
					return this;
				}
				goto IL_009c;
			}

			internal int IndexOfElementIdentifier(ControllerElementIdentifier[] elementIdentifiers, int id)
			{
				if (elementIdentifiers == null)
				{
					goto IL_0003;
				}
				int num = 0;
				int num2 = 305540475;
				goto IL_0008;
				IL_0008:
				while (true)
				{
					switch (num2 ^ 0x12362D78)
					{
					case 2:
						break;
					case 0:
						if (elementIdentifiers[num].id == id)
						{
							return num;
						}
						num++;
						num2 = 305540476;
						continue;
					case 3:
						num2 = 305540476;
						continue;
					case 1:
						return -1;
					default:
						if (num >= elementIdentifiers.Length)
						{
							return -1;
						}
						goto case 0;
					}
					break;
				}
				goto IL_0003;
				IL_0003:
				num2 = 305540473;
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
					return null;
				}
				Platform platform = MiscTools.DeepClone(this);
				string controllerName = platform.controllerNameOverride;
				if (string.IsNullOrEmpty(controllerName))
				{
					controllerName = hardwareJoystickMap.controllerName;
					goto IL_002b;
				}
				goto IL_03a4;
				IL_0030:
				int num;
				int elementIdentifierCount = default(int);
				int num4 = default(int);
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = default(HardwareJoystickMap_InputManager);
				int num3 = default(int);
				ControllerElementIdentifier[] elementIdentifiers = default(ControllerElementIdentifier[]);
				int num2 = default(int);
				while (true)
				{
					switch (num ^ -1515551129)
					{
					case 39:
						break;
					case 19:
						goto IL_0118;
					case 51:
						elementIdentifierCount = hardwareJoystickMap.elementIdentifierCount;
						num4 = 0;
						num = -1515551159;
						continue;
					case 15:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "R2 button";
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].positiveName = "R2 button";
						num = -1515551115;
						continue;
					case 21:
						goto IL_0177;
					case 43:
						num = -1515551120;
						continue;
					case 36:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "touch pad button";
						num = -1515551120;
						continue;
					case 10:
						goto IL_01bb;
					case 31:
						hardwareJoystickMap_InputManager.elementIdentifiers[num4] = new ControllerElementIdentifier(elementIdentifiers[num4], hardwareJoystickMap_InputManager.map.IsElementIdentifierMapped(elementIdentifiers[num4].id), hardwareJoystickMap_InputManager.map.GetEffectiveElementIdentifierType(elementIdentifiers[num4]));
						num = -1515551133;
						continue;
					case 17:
						num3 = 0;
						num = -1515551117;
						continue;
					case 47:
						switch (elementIdentifiers[num3].id)
						{
						case 5:
							break;
						case 20:
							goto IL_0177;
						case 14:
							goto IL_01bb;
						default:
							goto IL_028e;
						case 17:
							goto IL_02a2;
						case 19:
							goto IL_02bf;
						case 8:
							goto IL_0313;
						case 6:
							goto IL_0360;
						case 10:
							goto IL_037d;
						case 3:
							goto IL_03ec;
						case 0:
							goto IL_04a7;
						case 12:
							goto IL_04ea;
						case 4:
							goto IL_0511;
						case 18:
							goto IL_052e;
						case 7:
							goto IL_054b;
						case 11:
							goto IL_062a;
						case 1:
							goto IL_0651;
						case 21:
							goto IL_066e;
						case 15:
							goto IL_068b;
						case 13:
							goto IL_06c5;
						case 16:
							goto IL_06ec;
						case 2:
							goto IL_0709;
						case 9:
							goto IL_0787;
						}
						goto case 15;
					case 46:
						num = -1515551121;
						continue;
					case 12:
						goto IL_02a2;
					case 25:
						goto IL_02bf;
					case 13:
						num2++;
						num = -1515551166;
						continue;
					case 38:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].negativeName = "left stick down";
						num = -1515551120;
						continue;
					case 7:
						num = -1515551120;
						continue;
					case 34:
						goto IL_0313;
					case 26:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].positiveName = "right stick right";
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].negativeName = "right stick left";
						num = -1515551120;
						continue;
					case 24:
						goto IL_0360;
					case 3:
						goto IL_037d;
					case 52:
						num = -1515551120;
						continue;
					case 1:
						goto IL_03a4;
					case 16:
						goto IL_03ec;
					case 23:
						num3++;
						num = -1515551116;
						continue;
					case 18:
						num = -1515551120;
						continue;
					case 35:
						hardwareJoystickMap_InputManager.elementIdentifiers[num2].negativeName = hardwareJoystickMap_InputManager.elementIdentifiers[num2].name + " -";
						num = -1515551126;
						continue;
					case 22:
						if (inputSource == InputSource.PS4)
						{
							goto IL_0481;
						}
						goto case 11;
					case 9:
						goto IL_04a7;
					case 48:
						goto IL_04ea;
					case 53:
						num = -1515551120;
						continue;
					case 29:
						goto IL_0511;
					case 27:
						goto IL_052e;
					case 6:
						goto IL_054b;
					case 8:
						if (num4 < elementIdentifierCount)
						{
							goto case 31;
						}
						if (inputSource != InputSource.PS4)
						{
							goto case 22;
						}
						goto IL_0579;
					case 20:
						num = -1515551116;
						continue;
					case 14:
						if (hardwareJoystickMap_InputManager.elementIdentifiers[num2].elementType != ControllerElementType.Axis)
						{
							goto case 13;
						}
						if (string.IsNullOrEmpty(hardwareJoystickMap_InputManager.elementIdentifiers[num2].positiveName))
						{
							hardwareJoystickMap_InputManager.elementIdentifiers[num2].positiveName = hardwareJoystickMap_InputManager.elementIdentifiers[num2].name + " +";
							num = -1515551154;
							continue;
						}
						goto IL_0601;
					case 41:
						goto IL_0601;
					case 5:
						goto IL_062a;
					case 0:
						num = -1515551120;
						continue;
					case 2:
						goto IL_0651;
					case 40:
						goto IL_066e;
					case 50:
						goto IL_068b;
					case 42:
						goto IL_06c5;
					case 28:
						num = -1515551120;
						continue;
					case 30:
						goto IL_06ec;
					case 32:
						goto IL_0709;
					case 44:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].positiveName = "L2 button";
						num = -1515551109;
						continue;
					case 49:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].positiveName = "left stick up";
						num = -1515551167;
						continue;
					case 4:
						num4++;
						num = -1515551121;
						continue;
					case 11:
						num2 = 0;
						num = -1515551166;
						continue;
					case 45:
						num = -1515551120;
						continue;
					case 33:
						goto IL_0787;
					default:
						{
							if (num2 >= elementIdentifierCount)
							{
								return hardwareJoystickMap_InputManager;
							}
							goto case 14;
						}
						IL_01bb:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "PS button";
						num = -1515551158;
						continue;
						IL_0177:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "down button";
						num = -1515551120;
						continue;
						IL_0787:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "triangle button";
						num = -1515551136;
						continue;
						IL_0709:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "right stick x";
						num = -1515551107;
						continue;
						IL_06ec:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "L3 button";
						num = -1515551120;
						continue;
						IL_06c5:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "OPTIONS button";
						num = -1515551120;
						continue;
						IL_068b:
						if (inputSource == InputSource.PS4 && hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4AimController)
						{
							hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "pad button";
							num = -1515551150;
							continue;
						}
						goto case 36;
						IL_066e:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "left button";
						num = -1515551120;
						continue;
						IL_0651:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "left stick y";
						num = -1515551146;
						continue;
						IL_062a:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "R1 button";
						num = -1515551120;
						continue;
						IL_054b:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "circle button";
						num = -1515551120;
						continue;
						IL_052e:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "up button";
						num = -1515551129;
						continue;
						IL_0511:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "L2 button";
						num = -1515551157;
						continue;
						IL_04ea:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "SHARE button";
						num = -1515551120;
						continue;
						IL_04a7:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "left stick x";
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].positiveName = "left stick right";
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].negativeName = "left stick left";
						num = -1515551120;
						continue;
						IL_03ec:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "right stick y";
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].positiveName = "right stick up";
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].negativeName = "right stick down";
						num = -1515551156;
						continue;
						IL_037d:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "L1 button";
						num = -1515551120;
						continue;
						IL_0360:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "cross button";
						num = -1515551120;
						continue;
						IL_0313:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "square button";
						num = -1515551120;
						continue;
						IL_02bf:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "right button";
						num = -1515551120;
						continue;
						IL_02a2:
						hardwareJoystickMap_InputManager.elementIdentifiers[num3].name = "R3 button";
						num = -1515551120;
						continue;
						IL_028e:
						num = -1515551149;
						continue;
					}
					break;
					IL_0601:
					int num5;
					if (string.IsNullOrEmpty(hardwareJoystickMap_InputManager.elementIdentifiers[num2].negativeName))
					{
						num = -1515551164;
						num5 = num;
					}
					else
					{
						num = -1515551126;
						num5 = num;
					}
					continue;
					IL_0481:
					int num6;
					if (!(hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4AimController))
					{
						num = -1515551124;
						num6 = num;
					}
					else
					{
						num = -1515551114;
						num6 = num;
					}
					continue;
					IL_0118:
					int num7;
					if (num3 < elementIdentifierCount)
					{
						num = -1515551160;
						num7 = num;
					}
					else
					{
						num = -1515551124;
						num7 = num;
					}
					continue;
					IL_0579:
					int num8;
					if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyDualShock4)
					{
						num = -1515551114;
						num8 = num;
					}
					else
					{
						num = -1515551119;
						num8 = num;
					}
				}
				goto IL_002b;
				IL_03a4:
				hardwareJoystickMap_InputManager = new HardwareJoystickMap_InputManager(new HardwareControllerMapIdentifier(hardwareJoystickMap.Guid, inputSource, actualInputPlatform, variantIndex), hardwareJoystickMap.joystickTypes, platform, controllerName, platform.assignedButtonCount, platform.assignedAxisCount, hardwareJoystickMap.elementIdentifiers.Length, hardwareJoystickMap.compoundElements);
				elementIdentifiers = hardwareJoystickMap.elementIdentifiers;
				num = -1515551148;
				goto IL_0030;
				IL_002b:
				num = -1515551130;
				goto IL_0030;
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
					dRRcHzjfmpPQmjfIpMUExpcDkuyC(elementCount_Base);
					return elementCount_Base;
				}

				internal virtual void dRRcHzjfmpPQmjfIpMUExpcDkuyC(ElementCount_Base P_0)
				{
					if (P_0 == null)
					{
						goto IL_0003;
					}
					goto IL_0031;
					IL_0003:
					int num = -257794400;
					goto IL_0008;
					IL_0008:
					while (true)
					{
						switch (num ^ -257794399)
						{
						case 3:
							break;
						default:
							return;
						case 1:
							return;
						case 4:
							goto IL_0031;
						case 0:
							P_0.buttonCount = buttonCount;
							num = -257794397;
							continue;
						case 2:
							return;
						}
						break;
					}
					goto IL_0003;
					IL_0031:
					P_0.axisCount = axisCount;
					num = -257794399;
					goto IL_0008;
				}

				internal virtual bool YfzaYuFFeAGpZYIlhOCKodCcBwd(BridgedControllerHWInfo P_0)
				{
					if (P_0 == null)
					{
						return false;
					}
					if (axisCount >= 0)
					{
						goto IL_000e;
					}
					goto IL_0045;
					IL_0045:
					int num;
					if (buttonCount >= 0)
					{
						num = 952317385;
						goto IL_0013;
					}
					return true;
					IL_000e:
					num = 952317387;
					goto IL_0013;
					IL_0013:
					while (true)
					{
						switch (num ^ 0x38C335C9)
						{
						case 3:
							break;
						case 2:
							goto IL_0030;
						case 1:
							goto IL_0045;
						default:
							return buttonCount == P_0.hardwareButtonCount;
						}
						break;
						IL_0030:
						if (axisCount == P_0.hardwareAxisCount)
						{
							num = 952317384;
							continue;
						}
						return false;
					}
					goto IL_000e;
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
				if (!ElementCountsMatch(BridgedControllerHWInfo, out var _))
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
				int num2 = 0;
				ElementCount_Base elementCount_Base = default(ElementCount_Base);
				while (true)
				{
					IL_006a:
					int num3;
					if (num2 >= num)
					{
						if (axisCount >= 0)
						{
							if (axisCount != bridgedControllerHWInfo.hardwareAxisCount)
							{
								break;
							}
							num3 = -1666575300;
							goto IL_0018;
						}
						goto IL_0041;
					}
					goto IL_005b;
					IL_005b:
					elementCount_Base = GetAlternateElementCount(num2);
					num3 = -1666575301;
					goto IL_0018;
					IL_0018:
					while (true)
					{
						switch (num3 ^ -1666575299)
						{
						case 0:
							num3 = -1666575303;
							continue;
						case 1:
							break;
						case 6:
							goto IL_0051;
						case 4:
							goto IL_005b;
						case 2:
							goto IL_006a;
						case 3:
							goto IL_008c;
						default:
							return buttonCount == bridgedControllerHWInfo.hardwareButtonCount;
						}
						break;
						IL_008c:
						if (elementCount_Base.YfzaYuFFeAGpZYIlhOCKodCcBwd(bridgedControllerHWInfo))
						{
							alternateMatched = true;
							return true;
						}
						goto IL_009a;
						IL_009a:
						num2++;
						num3 = -1666575297;
						continue;
						IL_0051:
						if (elementCount_Base != null)
						{
							num3 = -1666575298;
							continue;
						}
						goto IL_009a;
					}
					goto IL_0041;
					IL_0041:
					if (buttonCount >= 0)
					{
						num3 = -1666575304;
						goto IL_0018;
					}
					return true;
				}
				return false;
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
				goto IL_0028;
				IL_0039:
				if (useRegex)
				{
					return Regex.IsMatch(searchIn, searchFor, RegexOptions.IgnoreCase);
				}
				return searchFor.Trim().Equals(searchIn.Trim(), StringComparison.OrdinalIgnoreCase);
				IL_000a:
				int num = -2074719959;
				goto IL_000f;
				IL_000f:
				switch (num ^ -2074719957)
				{
				case 0:
					break;
				case 2:
					goto IL_0028;
				default:
					goto IL_0039;
				}
				goto IL_000a;
				IL_0028:
				if (searchFor == null)
				{
					searchFor = string.Empty;
					num = -2074719958;
					goto IL_000f;
				}
				goto IL_0039;
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
				if (index >= 0)
				{
					while (true)
					{
						int num = -2030858127;
						while (true)
						{
							switch (num ^ -2030858125)
							{
							case 0:
								break;
							case 2:
								goto IL_0022;
							default:
								goto end_IL_0004;
							}
							break;
							IL_0022:
							if (index >= elementCount)
							{
								num = -2030858126;
								continue;
							}
							return componentElementIdentifiers[index];
						}
						continue;
						end_IL_0004:
						break;
					}
				}
				return -1;
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
					return;
				}
				int[] array = default(int[]);
				while (element.type == CompoundControllerElementType.Hat)
				{
					while (true)
					{
						IL_0090:
						if (element.componentElementIdentifiers == null)
						{
							return;
						}
						while (true)
						{
							IL_005f:
							int num;
							int num2;
							if (element.componentElementIdentifiers.Length != 8)
							{
								num = 1423664307;
								num2 = num;
							}
							else
							{
								num = 1423664304;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ 0x54DB64B2)
								{
								case 0:
									num = 1423664305;
									continue;
								case 3:
									break;
								case 1:
									return;
								case 9:
									goto IL_005f;
								case 6:
									array[0] = element.componentElementIdentifiers[0];
									num = 1423664311;
									continue;
								case 8:
									goto IL_0090;
								case 7:
									array[4] = element.componentElementIdentifiers[2];
									num = 1423664312;
									continue;
								case 2:
									array = new int[8];
									num = 1423664308;
									continue;
								case 10:
									array[5] = element.componentElementIdentifiers[6];
									num = 1423664310;
									continue;
								case 5:
									array[1] = element.componentElementIdentifiers[4];
									array[2] = element.componentElementIdentifiers[1];
									array[3] = element.componentElementIdentifiers[5];
									num = 1423664309;
									continue;
								default:
									array[6] = element.componentElementIdentifiers[3];
									array[7] = element.componentElementIdentifiers[7];
									Array.Copy(array, element.componentElementIdentifiers, array.Length);
									return;
								}
								break;
							}
							break;
						}
						break;
					}
				}
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
				while (true)
				{
					int num = 1535026384;
					while (true)
					{
						switch (num ^ 0x5B7EA4D1)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_002a;
						case 0:
							return;
						}
						break;
						IL_002a:
						calibration = MiscTools.DeepClone(source.calibration);
						num = 1535026385;
					}
				}
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
					int num = -1125395535;
					while (true)
					{
						switch (num ^ -1125395531)
						{
						case 7:
							break;
						case 4:
							num2 = 0;
							num = -1125395533;
							continue;
						case 5:
							axisCalibrationInfoEntry = calibrations[num2];
							num = -1125395530;
							continue;
						case 8:
							if (!Enum.IsDefined(typeof(AlternateAxisCalibrationType), axisCalibrationInfoEntry.key))
							{
								goto case 0;
							}
							if (dictionary.ContainsKey((int)axisCalibrationInfoEntry.key))
							{
								Logger.LogError("A duplicate key was found in AxisCalibrationInfoEntry array in HardwareJoystickMap. Skipping.");
								num = -1125395531;
								continue;
							}
							goto case 1;
						case 0:
							num2++;
							num = -1125395533;
							continue;
						case 3:
							if (axisCalibrationInfoEntry != null)
							{
								int num3;
								if (axisCalibrationInfoEntry.calibration == null)
								{
									num = -1125395531;
									num3 = num;
								}
								else
								{
									num = -1125395523;
									num3 = num;
								}
								continue;
							}
							goto case 0;
						case 2:
							dictionary.Add((int)axisCalibrationInfoEntry.key, axisCalibrationInfoEntry.calibration);
							num = -1125395531;
							continue;
						case 1:
							if (deepClone)
							{
								dictionary.Add((int)axisCalibrationInfoEntry.key, (AxisCalibrationInfo)axisCalibrationInfoEntry.calibration.DeepClone());
								num = -1125395531;
								continue;
							}
							goto case 2;
						default:
							if (num2 >= calibrations.Length)
							{
								return dictionary;
							}
							goto case 5;
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
						dRRcHzjfmpPQmjfIpMUExpcDkuyC(elementCount);
						return elementCount;
					}

					internal override void dRRcHzjfmpPQmjfIpMUExpcDkuyC(ElementCount_Base P_0)
					{
						base.dRRcHzjfmpPQmjfIpMUExpcDkuyC(P_0);
						ElementCount elementCount = default(ElementCount);
						while (true)
						{
							int num = -483792870;
							while (true)
							{
								switch (num ^ -483792869)
								{
								case 0:
									break;
								case 1:
									goto IL_0029;
								case 3:
									if (elementCount == null)
									{
										return;
									}
									goto default;
								default:
									elementCount.hatCount = hatCount;
									return;
								}
								break;
								IL_0029:
								elementCount = P_0 as ElementCount;
								num = -483792872;
							}
						}
					}

					internal override bool YfzaYuFFeAGpZYIlhOCKodCcBwd(BridgedControllerHWInfo P_0)
					{
						if (!base.YfzaYuFFeAGpZYIlhOCKodCcBwd(P_0))
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
							num = 1665994657;
							goto IL_0017;
						}
						return false;
						IL_0012:
						num = 1665994656;
						goto IL_0017;
						IL_0017:
						switch (num ^ 0x634D0FA1)
						{
						case 2:
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
					goto IL_0080;
					IL_0008:
					int num = -1048385440;
					goto IL_000d;
					IL_000d:
					while (true)
					{
						switch (num ^ -1048385438)
						{
						case 4:
							break;
						case 1:
							return false;
						case 3:
							goto IL_0076;
						case 2:
							goto IL_0094;
						default:
							goto IL_00a6;
						}
						break;
						IL_0094:
						if (hasData)
						{
							num = -1048385439;
							continue;
						}
						goto IL_0080;
						IL_0076:
						if (isAllowed)
						{
							return true;
						}
						goto IL_0080;
					}
					goto IL_0008;
					IL_00a6:
					return true;
					IL_0080:
					if (base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						if (!strictMatch)
						{
							return ProductNameMatches(bridgedControllerHWInfo);
						}
						if (!PidVid.ArrayContains(productGUID, ref bridgedControllerHWInfo.hw_pidVid))
						{
							if (!ProductNameMatches(bridgedControllerHWInfo))
							{
								return false;
							}
							return true;
						}
						if (!ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
						{
							return true;
						}
						if (productName == null)
						{
							goto IL_00a6;
						}
						if (productName.Length != 0)
						{
							return ProductNameMatches(bridgedControllerHWInfo);
						}
						num = -1048385438;
					}
					else
					{
						num = -1048385437;
					}
					goto IL_000d;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					if (alternateElementCounts != null)
					{
						while (true)
						{
							int num = -1427067775;
							while (true)
							{
								switch (num ^ -1427067774)
								{
								case 0:
									break;
								case 3:
									goto IL_002a;
								case 1:
									goto IL_003f;
								default:
									goto end_IL_0008;
								}
								break;
								IL_003f:
								if (index >= alternateElementCounts.Length)
								{
									num = -1427067776;
									continue;
								}
								return alternateElementCounts[index];
								IL_002a:
								int num2;
								if (index < 0)
								{
									num = -1427067776;
									num2 = num;
								}
								else
								{
									num = -1427067773;
									num2 = num;
								}
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

				private bool ProductNameMatches(BridgedControllerHWInfo controller)
				{
					if (controller.hw_isBluetoothDevice && !string.IsNullOrEmpty(controller.hw_bluetoothDeviceName))
					{
						while (true)
						{
							int num = -1705971923;
							while (true)
							{
								switch (num ^ -1705971924)
								{
								case 2:
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
								num = -1705971924;
							}
						}
					}
					return ProductNameMatches(controller.hw_productName);
				}

				private bool ProductNameMatches(string name)
				{
					string searchIn = default(string);
					int num = default(int);
					int num2;
					if (!string.IsNullOrEmpty(name))
					{
						if (productName == null)
						{
							goto IL_0010;
						}
						searchIn = name.Trim();
						num = 0;
						num2 = -1276010172;
						goto IL_0015;
					}
					goto IL_0036;
					IL_0015:
					while (true)
					{
						switch (num2 ^ -1276010176)
						{
						case 3:
							break;
						case 1:
							goto IL_0036;
						case 2:
							goto IL_0048;
						case 0:
							goto IL_0059;
						default:
							if (num >= productName.Length)
							{
								return false;
							}
							goto IL_0048;
						}
						break;
						IL_0059:
						if (!(productName[num] == string.Empty) && MatchingCriteria_Base.StringMatches(searchIn, productName[num], productName_useRegex))
						{
							return true;
						}
						goto IL_0085;
						IL_0048:
						if (productName[num] != null)
						{
							num2 = -1276010176;
							continue;
						}
						goto IL_0085;
						IL_0085:
						num++;
						num2 = -1276010172;
					}
					goto IL_0010;
					IL_0036:
					return false;
					IL_0010:
					num2 = -1276010175;
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
					if (matchingCriteria == null)
					{
						while (true)
						{
							switch (0x5A9B7ADA ^ 0x5A9B7ADB)
							{
							case 0:
								continue;
							case 1:
								return;
							}
							break;
						}
					}
					matchingCriteria.hatCount = hatCount;
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
					matchingCriteria.productId = ArrayTools.ShallowCopy(productId);
					matchingCriteria.deviceType = deviceType;
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
					while (true)
					{
						int num = 1062371807;
						while (true)
						{
							switch (num ^ 0x3F5281DE)
							{
							case 2:
								break;
							case 1:
								customCalculationSourceData.sourceOtherAxis = sourceOtherAxis;
								customCalculationSourceData.sourceAxisRange = sourceAxisRange;
								customCalculationSourceData.axisDeadZone = axisDeadZone;
								customCalculationSourceData.invert = invert;
								num = 1062371805;
								continue;
							case 3:
								customCalculationSourceData.axisCalibrationType = axisCalibrationType;
								num = 1062371806;
								continue;
							default:
								customCalculationSourceData.axisZero = axisZero;
								customCalculationSourceData.axisMin = axisMin;
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
					while (true)
					{
						int num = 1478923944;
						while (true)
						{
							switch (num ^ 0x582696A9)
							{
							case 5:
								break;
							case 3:
								sourceHat = source.sourceHat;
								sourceHatType = source.sourceHatType;
								sourceHatDirection = source.sourceHatDirection;
								num = 1478923945;
								continue;
							case 4:
								sourceType = source.sourceType;
								sourceButton = source.sourceButton;
								sourceAxis = source.sourceAxis;
								sourceAxisPole = source.sourceAxisPole;
								axisDeadZone = source.axisDeadZone;
								num = 1478923946;
								continue;
							case 0:
								requireMultipleButtons = source.requireMultipleButtons;
								requiredButtons = ArrayTools.ShallowCopy(source.requiredButtons);
								num = 1478923951;
								continue;
							case 6:
								ignoreIfButtonsActive = source.ignoreIfButtonsActive;
								ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(source.ignoreIfButtonsActiveButtons);
								num = 1478923947;
								continue;
							case 1:
								elementIdentifier = source.elementIdentifier;
								num = 1478923949;
								continue;
							default:
								buttonInfo = MiscTools.DeepClone(source.buttonInfo);
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
						int num = -1915224603;
						while (true)
						{
							switch (num ^ -1915224605)
							{
							case 0:
								break;
							case 5:
								axisMin = source.axisMin;
								axisMax = source.axisMax;
								axisInfo = MiscTools.DeepClone(source.axisInfo);
								sourceButton = source.sourceButton;
								buttonAxisContribution = source.buttonAxisContribution;
								sourceHat = source.sourceHat;
								sourceHatDirection = source.sourceHatDirection;
								num = -1915224606;
								continue;
							case 2:
								invert = source.invert;
								axisDeadZone = source.axisDeadZone;
								calibrateAxis = source.calibrateAxis;
								num = -1915224608;
								continue;
							case 6:
								sourceAxisRange = source.sourceAxisRange;
								num = -1915224607;
								continue;
							case 1:
								sourceHatRange = source.sourceHatRange;
								num = -1915224601;
								continue;
							case 3:
								axisZero = source.axisZero;
								num = -1915224602;
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
				if (destination is Platform_RawOrDirectInput platform_RawOrDirectInput)
				{
					platform_RawOrDirectInput.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
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
				private sealed class RaYHpvFPMTYqXfSuopeZmyPqRgCv : IDisposable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>, IEnumerable
				{
					private Axis_Base ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public Elements syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public int HXeojklNSWtNHIhnfsDEfzbwbYu;

					Axis_Base IEnumerator<Axis_Base>.Current
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
					IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
						{
							goto IL_0012;
						}
						goto IL_0067;
						IL_0012:
						int num = 1015110288;
						goto IL_0017;
						IL_0017:
						RaYHpvFPMTYqXfSuopeZmyPqRgCv raYHpvFPMTYqXfSuopeZmyPqRgCv = default(RaYHpvFPMTYqXfSuopeZmyPqRgCv);
						while (true)
						{
							switch (num ^ 0x3C815A92)
							{
							case 0:
								break;
							case 6:
								raYHpvFPMTYqXfSuopeZmyPqRgCv = this;
								num = 1015110295;
								continue;
							case 5:
								num = 1015110289;
								continue;
							case 1:
								raYHpvFPMTYqXfSuopeZmyPqRgCv.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
								num = 1015110289;
								continue;
							case 7:
								goto IL_0067;
							case 4:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								num = 1015110292;
								continue;
							case 2:
								goto IL_0083;
							default:
								return raYHpvFPMTYqXfSuopeZmyPqRgCv;
							}
							break;
							IL_0083:
							int num2;
							if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
							{
								num = 1015110294;
								num2 = num;
							}
							else
							{
								num = 1015110293;
								num2 = num;
							}
						}
						goto IL_0012;
						IL_0067:
						raYHpvFPMTYqXfSuopeZmyPqRgCv = new RaYHpvFPMTYqXfSuopeZmyPqRgCv(0);
						num = 1015110291;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 0:
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.axes == null)
							{
								break;
							}
							HXeojklNSWtNHIhnfsDEfzbwbYu = 0;
							num = 1982381707;
							goto IL_001f;
						case 1:
							{
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num = 1982381705;
								goto IL_001f;
							}
							IL_001f:
							while (true)
							{
								switch (num ^ 0x7628BE8D)
								{
								case 0:
									num = 1982381710;
									continue;
								case 3:
									break;
								case 6:
									goto IL_0070;
								case 4:
									HXeojklNSWtNHIhnfsDEfzbwbYu++;
									num = 1982381707;
									continue;
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
									return true;
								case 2:
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.axes[HXeojklNSWtNHIhnfsDEfzbwbYu];
									num = 1982381708;
									continue;
								default:
									goto end_IL_0008;
								}
								break;
								IL_0070:
								int num2;
								if (HXeojklNSWtNHIhnfsDEfzbwbYu >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.axes.Length)
								{
									num = 1982381704;
									num2 = num;
								}
								else
								{
									num = 1982381711;
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
					public RaYHpvFPMTYqXfSuopeZmyPqRgCv(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class tFUQgIEjYtGoSxOYbhwNkOYpDlu : IDisposable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>, IEnumerable
				{
					private Button_Base ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public Elements syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public int kjDhhFGLEBRHRrFSKQkiDafnPxMD;

					Button_Base IEnumerator<Button_Base>.Current
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
					IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
					{
						tFUQgIEjYtGoSxOYbhwNkOYpDlu tFUQgIEjYtGoSxOYbhwNkOYpDlu2;
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							tFUQgIEjYtGoSxOYbhwNkOYpDlu2 = this;
						}
						else
						{
							while (true)
							{
								tFUQgIEjYtGoSxOYbhwNkOYpDlu2 = new tFUQgIEjYtGoSxOYbhwNkOYpDlu(0);
								tFUQgIEjYtGoSxOYbhwNkOYpDlu2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
								int num = -61804137;
								while (true)
								{
									switch (num ^ -61804137)
									{
									case 2:
										num = -61804138;
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
						return tFUQgIEjYtGoSxOYbhwNkOYpDlu2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button_Base>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int num;
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 0:
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							num = -1112025698;
							goto IL_001f;
						case 1:
							{
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								kjDhhFGLEBRHRrFSKQkiDafnPxMD++;
								num = -1112025702;
								goto IL_001f;
							}
							IL_001f:
							while (true)
							{
								switch (num ^ -1112025698)
								{
								case 5:
									num = -1112025697;
									continue;
								case 4:
									break;
								case 0:
									if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttons != null)
									{
										kjDhhFGLEBRHRrFSKQkiDafnPxMD = 0;
										num = -1112025702;
										continue;
									}
									goto end_IL_0008;
								case 1:
									goto end_IL_001f;
								case 2:
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttons[kjDhhFGLEBRHRrFSKQkiDafnPxMD];
									isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
									return true;
								default:
									goto end_IL_0008;
								}
								int num2;
								if (kjDhhFGLEBRHRrFSKQkiDafnPxMD >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttons.Length)
								{
									num = -1112025699;
									num2 = num;
								}
								else
								{
									num = -1112025700;
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
					public tFUQgIEjYtGoSxOYbhwNkOYpDlu(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
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
						RaYHpvFPMTYqXfSuopeZmyPqRgCv raYHpvFPMTYqXfSuopeZmyPqRgCv = new RaYHpvFPMTYqXfSuopeZmyPqRgCv(-2);
						raYHpvFPMTYqXfSuopeZmyPqRgCv.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
						return raYHpvFPMTYqXfSuopeZmyPqRgCv;
					}
				}

				internal override IEnumerable<Button_Base> Buttons
				{
					get
					{
						tFUQgIEjYtGoSxOYbhwNkOYpDlu tFUQgIEjYtGoSxOYbhwNkOYpDlu2 = new tFUQgIEjYtGoSxOYbhwNkOYpDlu(-2);
						tFUQgIEjYtGoSxOYbhwNkOYpDlu2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
						return tFUQgIEjYtGoSxOYbhwNkOYpDlu2;
					}
				}

				internal override Axis_Base GetAxis(int axisIndex)
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
						IL_0079:
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = -379523800;
							goto IL_0009;
						}
						goto IL_005d;
						IL_0009:
						while (true)
						{
							switch (num3 ^ -379523798)
							{
							case 0:
								num3 = -379523793;
								continue;
							case 4:
								break;
							case 3:
								return ControllerElementType.Axis;
							case 5:
								goto end_IL_0009;
							case 1:
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
							num3 = -379523800;
							continue;
							end_IL_0009:
							break;
						}
						goto IL_005d;
						IL_005d:
						if (axes[num].elementIdentifier != elementIdentifier.id)
						{
							num++;
							num3 = -379523797;
						}
						else
						{
							num3 = -379523799;
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
							int num2;
							if (axes[num].elementIdentifier == elementIdentifier.id)
							{
								sourceType = axes[num].sourceType;
								num2 = 1339891501;
								goto IL_000c;
							}
							goto IL_00cd;
							IL_000c:
							while (true)
							{
								switch (num2 ^ 0x4FDD1F2D)
								{
								case 2:
									num2 = 1339891500;
									continue;
								case 7:
									if (axes[num].invert)
									{
										axisRange = InputTools.InvertAxisRange(axisRange);
										num2 = 1339891502;
										continue;
									}
									goto case 3;
								case 0:
									break;
								case 5:
									goto IL_0080;
								case 1:
									goto end_IL_000c;
								case 6:
									goto IL_00cd;
								case 4:
									goto IL_00db;
								case 3:
									return true;
								default:
									goto end_IL_00a0;
								}
								switch (sourceType)
								{
								case HardwareElementSourceTypeWithHat.Button:
									axisRange = AxisRange.Positive;
									return true;
								case HardwareElementSourceTypeWithHat.Hat:
									axisRange = axes[num].sourceHatRange;
									num2 = 1339891498;
									continue;
								case HardwareElementSourceTypeWithHat.Axis:
									break;
								default:
									throw new NotImplementedException();
								}
								goto IL_00db;
								IL_0080:
								return true;
								IL_00db:
								axisRange = axes[num].sourceAxisRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 1339891496;
									continue;
								}
								goto IL_0080;
								continue;
								end_IL_000c:
								break;
							}
							continue;
							IL_00cd:
							num++;
							num2 = 1339891493;
							goto IL_000c;
							continue;
							end_IL_00a0:
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
					if (!(destination is Elements elements))
					{
						return;
					}
					while (true)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						int num = -1815728353;
						while (true)
						{
							switch (num ^ -1815728353)
							{
							case 3:
								num = -1815728354;
								continue;
							default:
								return;
							case 1:
								break;
							case 0:
								elements.buttons = ArrayTools.DeepClone(buttons);
								num = -1815728355;
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

			private sealed class yIPvfJwDZJMKbhFLzhuxiZXigxCo : IDisposable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>, IEnumerable
			{
				private Axis_Base ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_DirectInput_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int HsjXzpsKvuqSRjfDjwZFLMuHnZL;

				public int gKDqUJWSxQavaaMJvAudLSzBVnz;

				Axis_Base IEnumerator<Axis_Base>.Current
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
				IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						goto IL_001c;
					}
					goto IL_0054;
					IL_0054:
					yIPvfJwDZJMKbhFLzhuxiZXigxCo yIPvfJwDZJMKbhFLzhuxiZXigxCo2 = new yIPvfJwDZJMKbhFLzhuxiZXigxCo(0);
					int num = -1147553995;
					goto IL_0021;
					IL_001c:
					num = -1147553997;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ -1147553993)
						{
						case 0:
							break;
						case 4:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							num = -1147553994;
							continue;
						case 3:
							goto IL_0054;
						case 2:
							yIPvfJwDZJMKbhFLzhuxiZXigxCo2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
							num = -1147553998;
							continue;
						case 1:
							yIPvfJwDZJMKbhFLzhuxiZXigxCo2 = this;
							num = -1147553998;
							continue;
						default:
							return yIPvfJwDZJMKbhFLzhuxiZXigxCo2;
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
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = -49804480;
						while (true)
						{
							switch (num2 ^ -49804475)
							{
							case 6:
								break;
							case 5:
								switch (num)
								{
								default:
									num2 = -49804475;
									continue;
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									gKDqUJWSxQavaaMJvAudLSzBVnz++;
									num2 = -49804479;
									continue;
								case 0:
									break;
								}
								goto case 1;
							case 2:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes[gKDqUJWSxQavaaMJvAudLSzBVnz];
								num2 = -49804474;
								continue;
							case 3:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 4:
							{
								int num3;
								if (gKDqUJWSxQavaaMJvAudLSzBVnz < HsjXzpsKvuqSRjfDjwZFLMuHnZL)
								{
									num2 = -49804473;
									num3 = num2;
								}
								else
								{
									num2 = -49804475;
									num3 = num2;
								}
								continue;
							}
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null && syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes != null)
								{
									HsjXzpsKvuqSRjfDjwZFLMuHnZL = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes.Length;
									gKDqUJWSxQavaaMJvAudLSzBVnz = 0;
									num2 = -49804479;
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
				public yIPvfJwDZJMKbhFLzhuxiZXigxCo(int _003C_003E1__state)
				{
					while (true)
					{
						int num = 1223715953;
						while (true)
						{
							switch (num ^ 0x48F06C73)
							{
							case 0:
								break;
							case 2:
								goto IL_0024;
							default:
								TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
								return;
							}
							break;
							IL_0024:
							isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
							num = 1223715954;
						}
					}
				}
			}

			private sealed class koWarYBsZZSyvluiugTOXNLXAosD : IDisposable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>, IEnumerable
			{
				private Button_Base ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_DirectInput_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int YONOOjXIcByxAmFtoLxrcpJEJmk;

				public int OpENMaVCDfrKehMRUBAOoaSfnWJ;

				Button_Base IEnumerator<Button_Base>.Current
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
				IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						goto IL_0023;
					}
					goto IL_0065;
					IL_0028:
					int num;
					koWarYBsZZSyvluiugTOXNLXAosD koWarYBsZZSyvluiugTOXNLXAosD2 = default(koWarYBsZZSyvluiugTOXNLXAosD);
					while (true)
					{
						switch (num ^ -1536188562)
						{
						case 4:
							break;
						case 3:
							koWarYBsZZSyvluiugTOXNLXAosD2 = this;
							num = -1536188562;
							continue;
						case 2:
							koWarYBsZZSyvluiugTOXNLXAosD2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
							num = -1536188562;
							continue;
						case 1:
							goto IL_0065;
						default:
							return koWarYBsZZSyvluiugTOXNLXAosD2;
						}
						break;
					}
					goto IL_0023;
					IL_0065:
					koWarYBsZZSyvluiugTOXNLXAosD2 = new koWarYBsZZSyvluiugTOXNLXAosD(0);
					num = -1536188564;
					goto IL_0028;
					IL_0023:
					num = -1536188563;
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
					int num3;
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					default:
						num = -617887103;
						goto IL_001a;
					case 0:
						goto IL_0069;
					case 1:
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							num = -617887100;
							goto IL_001a;
						}
						IL_001a:
						while (true)
						{
							switch (num ^ -617887104)
							{
							case 0:
								break;
							case 2:
								goto IL_004a;
							case 7:
								goto IL_0069;
							case 3:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons != null)
								{
									YONOOjXIcByxAmFtoLxrcpJEJmk = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons.Length;
									OpENMaVCDfrKehMRUBAOoaSfnWJ = 0;
									num = -617887102;
									continue;
								}
								goto default;
							case 6:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons[OpENMaVCDfrKehMRUBAOoaSfnWJ];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 4:
								OpENMaVCDfrKehMRUBAOoaSfnWJ++;
								num = -617887102;
								continue;
							case 1:
								num = -617887099;
								continue;
							default:
								return false;
							}
							break;
							IL_004a:
							int num2;
							if (OpENMaVCDfrKehMRUBAOoaSfnWJ < YONOOjXIcByxAmFtoLxrcpJEJmk)
							{
								num = -617887098;
								num2 = num;
							}
							else
							{
								num = -617887099;
								num2 = num;
							}
						}
						goto default;
						IL_0069:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements == null)
						{
							num = -617887099;
							num3 = num;
						}
						else
						{
							num = -617887101;
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
				public koWarYBsZZSyvluiugTOXNLXAosD(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public Elements elements;

			internal override InputPlatform platform => InputPlatform.nxzcJmevYVMAWQJHQoCKKweYMfMv;

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

			internal override IList<Platform> variants_base => null;

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

			internal override Elements_Base elements_base => elements;

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
				int num6 = default(int);
				string[] array = default(string[]);
				int num3 = default(int);
				int num4 = default(int);
				while (true)
				{
					int num2 = -904937892;
					while (true)
					{
						switch (num2 ^ -904937894)
						{
						case 8:
							break;
						case 2:
						{
							int num8;
							if (num6 < 0)
							{
								num2 = -904937904;
								num8 = num2;
							}
							else
							{
								num2 = -904937901;
								num8 = num2;
							}
							continue;
						}
						case 1:
							array[num3] = identifiers[num6].name;
							num2 = -904937898;
							continue;
						case 10:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = -904937898;
							continue;
						case 3:
						{
							int num5;
							if (num3 < num4)
							{
								num2 = -904937903;
								num5 = num2;
							}
							else
							{
								num2 = -904937894;
								num5 = num2;
							}
							continue;
						}
						case 9:
						{
							int num7;
							if (num6 >= num)
							{
								num2 = -904937904;
								num7 = num2;
							}
							else
							{
								num2 = -904937893;
								num7 = num2;
							}
							continue;
						}
						case 4:
							num3 = 0;
							num2 = -904937895;
							continue;
						case 7:
							return new string[0];
						case 5:
							num4 = array.Length;
							num2 = -904937890;
							continue;
						case 11:
						{
							int elementIdentifier = elements.axes[num3].elementIdentifier;
							num6 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num2 = -904937896;
							continue;
						}
						case 12:
							num3++;
							num2 = -904937895;
							continue;
						case 6:
							if (num >= elements.axisCount)
							{
								array = new string[elements.axisCount];
								num2 = -904937889;
							}
							else
							{
								Logger.LogError("You have too few element identifiers!");
								num2 = -904937891;
							}
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
				int num = identifiers.Length;
				if (num < buttonCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[buttonCount];
				int num2 = 0;
				int num4 = default(int);
				int elementIdentifier = default(int);
				while (true)
				{
					int num3 = -1014408136;
					while (true)
					{
						switch (num3 ^ -1014408135)
						{
						case 8:
							break;
						case 2:
							array[num2] = identifiers[num4].name;
							num3 = -1014408134;
							continue;
						case 4:
						{
							int num6;
							if (num2 < buttonCount)
							{
								num3 = -1014408135;
								num6 = num3;
							}
							else
							{
								num3 = -1014408132;
								num6 = num3;
							}
							continue;
						}
						case 7:
							num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							if (num4 >= 0)
							{
								int num5;
								if (num4 < num)
								{
									num3 = -1014408133;
									num5 = num3;
								}
								else
								{
									num3 = -1014408129;
									num5 = num3;
								}
								continue;
							}
							goto case 6;
						case 6:
							Logger.LogError("Element identifier index is out of bounds!");
							num3 = -1014408134;
							continue;
						case 3:
							num2++;
							num3 = -1014408131;
							continue;
						case 1:
							num3 = -1014408131;
							continue;
						case 0:
							elementIdentifier = elements.buttons[num2].elementIdentifier;
							num3 = -1014408130;
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
				using (IEnumerator<Axis_Base> enumerator = IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator.Current;
							int num;
							int num2;
							if (axis.elementIdentifier != elementIdentifierId)
							{
								num = -917297374;
								num2 = num;
							}
							else
							{
								num = -917297370;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ -917297370)
								{
								case 2:
									num = -917297369;
									continue;
								case 1:
									break;
								case 0:
									result = true;
									num = -917297371;
									continue;
								default:
									goto end_IL_0034;
								case 3:
									goto IL_0100;
								}
								break;
							}
							continue;
							end_IL_0034:
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
							int num3 = -917297371;
							while (true)
							{
								switch (num3 ^ -917297370)
								{
								case 0:
									num3 = -917297369;
									continue;
								case 1:
									break;
								case 3:
									if (button.elementIdentifier == elementIdentifierId)
									{
										result = true;
										num3 = -917297374;
										continue;
									}
									goto end_IL_00b8;
								default:
									goto end_IL_00b8;
								case 4:
									goto IL_0100;
								}
								break;
							}
							continue;
							end_IL_00b8:
							break;
						}
					}
				}
				return false;
				IL_0100:
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
							int num2 = -213723023;
							while (true)
							{
								switch (num2 ^ -213723024)
								{
								case 0:
									num2 = -213723022;
									continue;
								case 2:
									break;
								case 1:
									buttons[num] = button.elementIdentifier;
									num++;
									num2 = -213723021;
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
							axes[num] = axis.elementIdentifier;
							int num3 = -213723022;
							while (true)
							{
								switch (num3 ^ -213723024)
								{
								case 0:
									num3 = -213723021;
									continue;
								case 3:
									break;
								case 2:
									num++;
									num3 = -213723023;
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
							int num4 = -213723022;
							while (true)
							{
								switch (num4 ^ -213723024)
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
								num4 = -213723023;
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
				AxisCalibrationData[] array = default(AxisCalibrationData[]);
				int num2 = default(int);
				while (true)
				{
					int num = -1063784265;
					while (true)
					{
						switch (num ^ -1063784268)
						{
						case 8:
							break;
						case 2:
						{
							ref AxisCalibrationData reference = ref array[num2];
							reference = AxisCalibrationData.Default;
							num = -1063784257;
							continue;
						}
						case 11:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, deepClone: true);
							num2++;
							num = -1063784271;
							continue;
						case 3:
							if (axes_orig == null)
							{
								return null;
							}
							array = new AxisCalibrationData[axes_orig.Length];
							num2 = 0;
							num = -1063784271;
							continue;
						case 9:
						{
							int num6;
							if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Custom)
							{
								num = -1063784267;
								num6 = num;
							}
							else
							{
								num = -1063784270;
								num6 = num;
							}
							continue;
						}
						case 7:
							array[num2].min = axes_orig[num2].axisMin;
							array[num2].max = axes_orig[num2].axisMax;
							num = -1063784257;
							continue;
						case 0:
						{
							int num3;
							if (!Axes_orig[num2].calibrateAxis)
							{
								num = -1063784257;
								num3 = num;
							}
							else
							{
								num = -1063784264;
								num3 = num;
							}
							continue;
						}
						case 6:
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num5;
								if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Hat)
								{
									num = -1063784266;
									num5 = num;
								}
								else
								{
									num = -1063784272;
									num5 = num;
								}
								continue;
							}
							goto case 2;
						case 1:
						{
							ref AxisCalibrationData reference2 = ref array[num2];
							reference2 = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							num = -1063784268;
							continue;
						}
						case 12:
							array[num2].zero = axes_orig[num2].axisZero;
							num = -1063784269;
							continue;
						case 10:
						{
							int num4;
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								num = -1063784259;
								num4 = num;
							}
							else
							{
								num = -1063784267;
								num4 = num;
							}
							continue;
						}
						case 4:
							throw new NotImplementedException();
						default:
							if (num2 >= axes_orig.Length)
							{
								return array;
							}
							goto case 10;
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
					int num = -2027812009;
					while (true)
					{
						switch (num ^ -2027812001)
						{
						case 4:
							break;
						case 8:
						{
							int num5;
							if (Axes_orig != null)
							{
								num = -2027812011;
								num5 = num;
							}
							else
							{
								num = -2027812001;
								num5 = num;
							}
							continue;
						}
						case 2:
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num4;
								if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Hat)
								{
									num = -2027812010;
									num4 = num;
								}
								else
								{
									num = -2027812004;
									num4 = num;
								}
								continue;
							}
							goto case 9;
						case 9:
							axisRanges[num2] = AxisRange.Full;
							num = -2027812002;
							continue;
						case 3:
							throw new Exception();
						case 11:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -2027812002;
							continue;
						case 10:
							axisRanges = new AxisRange[Axes_orig.Length];
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = -2027812008;
							continue;
						case 0:
							return;
						case 1:
							num2++;
							num = -2027812008;
							continue;
						case 5:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, createIfNull: true);
							num = -2027812007;
							continue;
						case 6:
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num3;
								if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Custom)
								{
									num = -2027812012;
									num3 = num;
								}
								else
								{
									num = -2027812003;
									num3 = num;
								}
								continue;
							}
							goto case 11;
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
					goto IL_000b;
				}
				goto IL_003d;
				IL_000b:
				int num = -2000462028;
				goto IL_0010;
				IL_0010:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ -2000462025)
					{
					case 0:
						break;
					case 3:
						return;
					case 2:
						goto IL_003d;
					case 1:
						num = -2000462030;
						continue;
					case 4:
						buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, createIfNull: true);
						num2++;
						num = -2000462030;
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
				num2 = 0;
				num = -2000462026;
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
				yIPvfJwDZJMKbhFLzhuxiZXigxCo yIPvfJwDZJMKbhFLzhuxiZXigxCo2 = new yIPvfJwDZJMKbhFLzhuxiZXigxCo(-2);
				yIPvfJwDZJMKbhFLzhuxiZXigxCo2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return yIPvfJwDZJMKbhFLzhuxiZXigxCo2;
			}

			internal override IEnumerable<Button_Base> IterateButtons()
			{
				koWarYBsZZSyvluiugTOXNLXAosD koWarYBsZZSyvluiugTOXNLXAosD2 = new koWarYBsZZSyvluiugTOXNLXAosD(-2);
				koWarYBsZZSyvluiugTOXNLXAosD2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return koWarYBsZZSyvluiugTOXNLXAosD2;
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
					switch (-1638922961 ^ -1638922962)
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

			internal override IList<Platform> variants_base => variants;

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
					num2 = 1643536712;
					goto IL_0012;
				}
				goto IL_00aa;
				IL_0012:
				while (true)
				{
					switch (num2 ^ 0x61F6614C)
					{
					case 0:
						break;
					case 1:
						return true;
					case 6:
						variantIndex = num;
						num2 = 1643536719;
						continue;
					case 3:
						return true;
					case 4:
						goto IL_0065;
					case 5:
						goto IL_0081;
					default:
						goto IL_00aa;
					}
					break;
					IL_0081:
					if (variants[num] == null || !variants[num].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						num++;
						num2 = 1643536712;
					}
					else
					{
						num2 = 1643536714;
					}
					continue;
					IL_0065:
					int num3;
					if (num < variants.Length)
					{
						num2 = 1643536713;
						num3 = num2;
					}
					else
					{
						num2 = 1643536718;
						num3 = num2;
					}
				}
				goto IL_000d;
				IL_00aa:
				return false;
				IL_000d:
				num2 = 1643536717;
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
				while (true)
				{
					int num = 1493684570;
					while (true)
					{
						switch (num ^ 0x5907D158)
						{
						case 3:
							break;
						default:
							return;
						case 2:
						{
							int num2;
							if (platform_DirectInput == null)
							{
								num = 1493684569;
								num2 = num;
							}
							else
							{
								num = 1493684568;
								num2 = num;
							}
							continue;
						}
						case 1:
							return;
						case 0:
							platform_DirectInput.variants = MiscTools.DeepClone(variants);
							num = 1493684572;
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
		public class Platform_RawInput_Base : Platform_RawOrDirectInput
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Platform_Base
			{
				private sealed class ehExRhBFYERksQaSqAVrBvMxXIGJ : IDisposable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>, IEnumerable
				{
					private Axis_Base ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public Elements syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public int IDtjpWkFeiXvBBSFUpsyTepDVUT;

					Axis_Base IEnumerator<Axis_Base>.Current
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
					IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
						{
							goto IL_0012;
						}
						goto IL_0038;
						IL_0012:
						int num = -521851402;
						goto IL_0017;
						IL_0017:
						ehExRhBFYERksQaSqAVrBvMxXIGJ ehExRhBFYERksQaSqAVrBvMxXIGJ2 = default(ehExRhBFYERksQaSqAVrBvMxXIGJ);
						while (true)
						{
							switch (num ^ -521851406)
							{
							case 2:
								break;
							case 0:
								goto IL_0038;
							case 3:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								ehExRhBFYERksQaSqAVrBvMxXIGJ2 = this;
								num = -521851405;
								continue;
							case 4:
								goto IL_0062;
							default:
								return ehExRhBFYERksQaSqAVrBvMxXIGJ2;
							}
							break;
							IL_0062:
							int num2;
							if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
							{
								num = -521851407;
								num2 = num;
							}
							else
							{
								num = -521851406;
								num2 = num;
							}
						}
						goto IL_0012;
						IL_0038:
						ehExRhBFYERksQaSqAVrBvMxXIGJ2 = new ehExRhBFYERksQaSqAVrBvMxXIGJ(0);
						ehExRhBFYERksQaSqAVrBvMxXIGJ2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = -521851405;
						goto IL_0017;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
						while (true)
						{
							int num2 = 61821069;
							while (true)
							{
								switch (num2 ^ 0x3AF508E)
								{
								case 2:
									break;
								case 4:
								{
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									int num4;
									if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.axes == null)
									{
										num2 = 61821062;
										num4 = num2;
									}
									else
									{
										num2 = 61821064;
										num4 = num2;
									}
									continue;
								}
								case 5:
								{
									int num3;
									if (IDtjpWkFeiXvBBSFUpsyTepDVUT >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.axes.Length)
									{
										num2 = 61821062;
										num3 = num2;
									}
									else
									{
										num2 = 61821071;
										num3 = num2;
									}
									continue;
								}
								case 3:
									switch (num)
									{
									case 0:
										break;
									default:
										num2 = 61821065;
										continue;
									case 1:
										isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
										IDtjpWkFeiXvBBSFUpsyTepDVUT++;
										num2 = 61821067;
										continue;
									}
									goto case 4;
								case 6:
									IDtjpWkFeiXvBBSFUpsyTepDVUT = 0;
									num2 = 61821070;
									continue;
								case 0:
									num2 = 61821067;
									continue;
								case 1:
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.axes[IDtjpWkFeiXvBBSFUpsyTepDVUT];
									isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
									return true;
								case 7:
									num2 = 61821062;
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
					public ehExRhBFYERksQaSqAVrBvMxXIGJ(int _003C_003E1__state)
					{
						while (true)
						{
							int num = 2117910977;
							while (true)
							{
								switch (num ^ 0x7E3CC1C0)
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
								isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
								TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
								num = 2117910976;
							}
						}
					}
				}

				private sealed class vKFaLJWZOmHvdlGemtSFgqevEQL : IDisposable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>, IEnumerable
				{
					private Button_Base ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public Elements syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public int JDjUHjhfLgOypBPTdjuxmrxdfas;

					Button_Base IEnumerator<Button_Base>.Current
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
					IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							goto IL_001c;
						}
						goto IL_0050;
						IL_0050:
						vKFaLJWZOmHvdlGemtSFgqevEQL vKFaLJWZOmHvdlGemtSFgqevEQL2 = new vKFaLJWZOmHvdlGemtSFgqevEQL(0);
						vKFaLJWZOmHvdlGemtSFgqevEQL2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						int num = -669208086;
						goto IL_0021;
						IL_001c:
						num = -669208088;
						goto IL_0021;
						IL_0021:
						while (true)
						{
							switch (num ^ -669208085)
							{
							case 0:
								break;
							case 3:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								num = -669208087;
								continue;
							case 4:
								goto IL_0050;
							case 2:
								vKFaLJWZOmHvdlGemtSFgqevEQL2 = this;
								num = -669208086;
								continue;
							default:
								return vKFaLJWZOmHvdlGemtSFgqevEQL2;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 0:
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttons == null)
							{
								break;
							}
							JDjUHjhfLgOypBPTdjuxmrxdfas = 0;
							num = -1205649973;
							goto IL_001f;
						case 1:
							{
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								JDjUHjhfLgOypBPTdjuxmrxdfas++;
								num = -1205649970;
								goto IL_001f;
							}
							IL_001f:
							while (true)
							{
								switch (num ^ -1205649970)
								{
								case 4:
									num = -1205649972;
									continue;
								case 0:
									break;
								case 5:
									num = -1205649970;
									continue;
								case 2:
									goto end_IL_001f;
								case 3:
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttons[JDjUHjhfLgOypBPTdjuxmrxdfas];
									isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
									return true;
								default:
									goto end_IL_0008;
								}
								int num2;
								if (JDjUHjhfLgOypBPTdjuxmrxdfas < syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttons.Length)
								{
									num = -1205649971;
									num2 = num;
								}
								else
								{
									num = -1205649969;
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
					public vKFaLJWZOmHvdlGemtSFgqevEQL(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
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
						ehExRhBFYERksQaSqAVrBvMxXIGJ ehExRhBFYERksQaSqAVrBvMxXIGJ2 = new ehExRhBFYERksQaSqAVrBvMxXIGJ(-2);
						ehExRhBFYERksQaSqAVrBvMxXIGJ2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
						return ehExRhBFYERksQaSqAVrBvMxXIGJ2;
					}
				}

				internal override IEnumerable<Button_Base> Buttons
				{
					get
					{
						vKFaLJWZOmHvdlGemtSFgqevEQL vKFaLJWZOmHvdlGemtSFgqevEQL2 = new vKFaLJWZOmHvdlGemtSFgqevEQL(-2);
						vKFaLJWZOmHvdlGemtSFgqevEQL2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
						return vKFaLJWZOmHvdlGemtSFgqevEQL2;
					}
				}

				internal override Axis_Base GetAxis(int axisIndex)
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
					int num4 = default(int);
					while (true)
					{
						int num2;
						int num3;
						if (num >= axisCount)
						{
							num2 = 1390263321;
							num3 = num2;
						}
						else
						{
							num2 = 1390263323;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x52DDBC1A)
							{
							case 4:
								num2 = 1390263323;
								continue;
							case 3:
								num4 = 0;
								num2 = 1390263322;
								continue;
							case 2:
								break;
							case 6:
								if (buttons[num4].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num4++;
								num2 = 1390263327;
								continue;
							case 1:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = 1390263320;
								continue;
							case 0:
								num2 = 1390263327;
								continue;
							default:
								if (num4 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								goto case 6;
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
						int num2 = 1323462463;
						while (true)
						{
							switch (num2 ^ 0x4EE26F3A)
							{
							case 6:
								break;
							case 1:
								axisRange = InputTools.InvertAxisRange(axisRange);
								num2 = 1323462461;
								continue;
							case 9:
							{
								axisRange = axes[num].sourceAxisRange;
								int num3;
								if (!axes[num].invert)
								{
									num2 = 1323462461;
									num3 = num2;
								}
								else
								{
									num2 = 1323462459;
									num3 = num2;
								}
								continue;
							}
							case 5:
								num2 = 1323462457;
								continue;
							case 0:
								return true;
							case 2:
								if (sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									throw new NotImplementedException();
								}
								num2 = 1323462451;
								continue;
							case 4:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									sourceType = axes[num].sourceType;
									switch (sourceType)
									{
									case HardwareElementSourceTypeWithHat.Axis:
										break;
									default:
										goto IL_00db;
									case HardwareElementSourceTypeWithHat.Button:
										axisRange = AxisRange.Positive;
										return true;
									case HardwareElementSourceTypeWithHat.Hat:
										goto IL_00fa;
									}
									goto case 9;
								}
								goto case 8;
							case 8:
								num++;
								num2 = 1323462457;
								continue;
							case 7:
								return true;
							default:
								{
									if (num >= axisCount)
									{
										axisRange = AxisRange.Full;
										return false;
									}
									goto case 4;
								}
								IL_00fa:
								axisRange = axes[num].sourceHatRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 1323462458;
									continue;
								}
								goto case 0;
								IL_00db:
								num2 = 1323462456;
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
					Elements elements = destination as Elements;
					while (true)
					{
						switch (-518583476 ^ -518583475)
						{
						case 2:
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

			private sealed class lDFbNdJoGQnqiysLRaSElmIxwjqo : IDisposable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>, IEnumerable
			{
				private Axis_Base ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_RawInput_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int ejdqTWfgcpjXRWlyiCfSoqvNzzY;

				public int RsEtoWuLzFcgOIbRSZwoUexmlrW;

				Axis_Base IEnumerator<Axis_Base>.Current
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
				IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						goto IL_0023;
					}
					goto IL_0065;
					IL_0028:
					int num;
					lDFbNdJoGQnqiysLRaSElmIxwjqo lDFbNdJoGQnqiysLRaSElmIxwjqo2 = default(lDFbNdJoGQnqiysLRaSElmIxwjqo);
					while (true)
					{
						switch (num ^ -1812453761)
						{
						case 4:
							break;
						case 1:
							lDFbNdJoGQnqiysLRaSElmIxwjqo2 = this;
							num = -1812453764;
							continue;
						case 2:
							lDFbNdJoGQnqiysLRaSElmIxwjqo2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
							num = -1812453764;
							continue;
						case 0:
							goto IL_0065;
						default:
							return lDFbNdJoGQnqiysLRaSElmIxwjqo2;
						}
						break;
					}
					goto IL_0023;
					IL_0065:
					lDFbNdJoGQnqiysLRaSElmIxwjqo2 = new lDFbNdJoGQnqiysLRaSElmIxwjqo(0);
					num = -1812453763;
					goto IL_0028;
					IL_0023:
					num = -1812453762;
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
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					case 1:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = 1801632002;
						goto IL_001f;
					case 0:
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements == null || syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes == null)
							{
								break;
							}
							ejdqTWfgcpjXRWlyiCfSoqvNzzY = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes.Length;
							num = 1801632001;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x6B62B904)
							{
							case 3:
								num = 1801632006;
								continue;
							case 1:
								break;
							case 4:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes[RsEtoWuLzFcgOIbRSZwoUexmlrW];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 5:
								RsEtoWuLzFcgOIbRSZwoUexmlrW = 0;
								num = 1801632005;
								continue;
							case 2:
								goto end_IL_001f;
							case 6:
								RsEtoWuLzFcgOIbRSZwoUexmlrW++;
								num = 1801632005;
								continue;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (RsEtoWuLzFcgOIbRSZwoUexmlrW < ejdqTWfgcpjXRWlyiCfSoqvNzzY)
							{
								num = 1801632000;
								num2 = num;
							}
							else
							{
								num = 1801632004;
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
				public lDFbNdJoGQnqiysLRaSElmIxwjqo(int _003C_003E1__state)
				{
					while (true)
					{
						int num = 303349829;
						while (true)
						{
							switch (num ^ 0x1214C044)
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
							isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
							TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
							num = 303349830;
						}
					}
				}
			}

			private sealed class gDZIhvbywaiiQRaQouPQGhNXpeVw : IDisposable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>, IEnumerable
			{
				private Button_Base ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_RawInput_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int FqHxyVDOXbGGGJSXBhjlyHUVFPp;

				public int FSVLPsqlVSNhZSvMSrzdyBtydGd;

				Button_Base IEnumerator<Button_Base>.Current
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
				IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						goto IL_0023;
					}
					goto IL_004e;
					IL_0028:
					int num;
					gDZIhvbywaiiQRaQouPQGhNXpeVw gDZIhvbywaiiQRaQouPQGhNXpeVw2 = default(gDZIhvbywaiiQRaQouPQGhNXpeVw);
					while (true)
					{
						switch (num ^ -301123888)
						{
						case 0:
							break;
						case 3:
							gDZIhvbywaiiQRaQouPQGhNXpeVw2 = this;
							num = -301123887;
							continue;
						case 2:
							goto IL_004e;
						default:
							return gDZIhvbywaiiQRaQouPQGhNXpeVw2;
						}
						break;
					}
					goto IL_0023;
					IL_004e:
					gDZIhvbywaiiQRaQouPQGhNXpeVw2 = new gDZIhvbywaiiQRaQouPQGhNXpeVw(0);
					gDZIhvbywaiiQRaQouPQGhNXpeVw2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					num = -301123887;
					goto IL_0028;
					IL_0023:
					num = -301123885;
					goto IL_0028;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button_Base>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = -735198172;
						while (true)
						{
							switch (num2 ^ -735198173)
							{
							case 0:
								break;
							case 7:
								switch (num)
								{
								default:
									num2 = -735198176;
									continue;
								case 0:
									break;
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									FSVLPsqlVSNhZSvMSrzdyBtydGd++;
									num2 = -735198174;
									continue;
								}
								goto case 2;
							case 2:
							{
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								int num5;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements == null)
								{
									num2 = -735198176;
									num5 = num2;
								}
								else
								{
									num2 = -735198165;
									num5 = num2;
								}
								continue;
							}
							case 5:
								num2 = -735198174;
								continue;
							case 4:
								FqHxyVDOXbGGGJSXBhjlyHUVFPp = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons.Length;
								FSVLPsqlVSNhZSvMSrzdyBtydGd = 0;
								num2 = -735198170;
								continue;
							case 1:
							{
								int num4;
								if (FSVLPsqlVSNhZSvMSrzdyBtydGd < FqHxyVDOXbGGGJSXBhjlyHUVFPp)
								{
									num2 = -735198171;
									num4 = num2;
								}
								else
								{
									num2 = -735198176;
									num4 = num2;
								}
								continue;
							}
							case 8:
							{
								int num3;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons == null)
								{
									num2 = -735198176;
									num3 = num2;
								}
								else
								{
									num2 = -735198169;
									num3 = num2;
								}
								continue;
							}
							case 6:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons[FSVLPsqlVSNhZSvMSrzdyBtydGd];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
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
				public gDZIhvbywaiiQRaQouPQGhNXpeVw(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public Elements elements;

			internal override InputPlatform platform => InputPlatform.TxthorEPmOLBHYyZxIReALnmNeM;

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

			internal override IList<Platform> variants_base => null;

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

			internal override Elements_Base elements_base => elements;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null)
				{
					while (true)
					{
						int num = -178373817;
						while (true)
						{
							switch (num ^ -178373820)
							{
							case 2:
								break;
							case 3:
								goto IL_0031;
							case 0:
								platformMap = this;
								num = -178373819;
								continue;
							default:
								return true;
							}
							break;
							IL_0031:
							if (!matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
							{
								goto end_IL_000f;
							}
							num = -178373820;
						}
						continue;
						end_IL_000f:
						break;
					}
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
				int num4 = default(int);
				int num5 = default(int);
				while (true)
				{
					int num3 = -2039424464;
					while (true)
					{
						switch (num3 ^ -2039424458)
						{
						case 0:
							break;
						case 8:
						{
							int num7;
							if (num4 >= num2)
							{
								num3 = -2039424459;
								num7 = num3;
							}
							else
							{
								num3 = -2039424460;
								num7 = num3;
							}
							continue;
						}
						case 1:
							Logger.LogError("Element identifier index is out of bounds!");
							num3 = -2039424461;
							continue;
						case 5:
							num4++;
							num3 = -2039424450;
							continue;
						case 2:
						{
							int elementIdentifier = elements.axes[num4].elementIdentifier;
							num5 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							int num8;
							if (num5 < 0)
							{
								num3 = -2039424457;
								num8 = num3;
							}
							else
							{
								num3 = -2039424462;
								num8 = num3;
							}
							continue;
						}
						case 4:
						{
							int num6;
							if (num5 >= num)
							{
								num3 = -2039424457;
								num6 = num3;
							}
							else
							{
								num3 = -2039424463;
								num6 = num3;
							}
							continue;
						}
						case 6:
							num4 = 0;
							num3 = -2039424449;
							continue;
						case 9:
							num3 = -2039424450;
							continue;
						case 7:
							array[num4] = identifiers[num5].name;
							num3 = -2039424461;
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
				int num = identifiers.Length;
				if (num < buttonCount)
				{
					goto IL_0017;
				}
				string[] array = new string[buttonCount];
				int num2 = 0;
				int num3 = 777102317;
				goto IL_001c;
				IL_001c:
				int num4 = default(int);
				int elementIdentifier = default(int);
				while (true)
				{
					switch (num3 ^ 0x2E51A3EB)
					{
					case 5:
						break;
					case 7:
						Logger.LogError("Element identifier index is out of bounds!");
						num3 = 777102319;
						continue;
					case 4:
						num3 = 777102307;
						continue;
					case 8:
						num2++;
						num3 = 777102317;
						continue;
					case 3:
						num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						if (num4 >= 0)
						{
							int num5;
							if (num4 < num)
							{
								num3 = 777102313;
								num5 = num3;
							}
							else
							{
								num3 = 777102316;
								num5 = num3;
							}
							continue;
						}
						goto case 7;
					case 0:
						elementIdentifier = elements.buttons[num2].elementIdentifier;
						num3 = 777102312;
						continue;
					case 1:
						Logger.LogError("You have too few element identifiers!");
						return new string[0];
					case 2:
						array[num2] = identifiers[num4].name;
						num3 = 777102307;
						continue;
					default:
						if (num2 >= buttonCount)
						{
							return array;
						}
						goto case 0;
					}
					break;
				}
				goto IL_0017;
				IL_0017:
				num3 = 777102314;
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
				using (IEnumerator<Button_Base> enumerator2 = IterateButtons().GetEnumerator())
				{
					while (true)
					{
						IL_00bf:
						int num;
						int num2;
						if (enumerator2.MoveNext())
						{
							num = -150215831;
							num2 = num;
						}
						else
						{
							num = -150215830;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -150215832)
							{
							case 3:
								num = -150215831;
								continue;
							default:
								goto end_IL_0077;
							case 1:
							{
								Button button = (Button)enumerator2.Current;
								int num3;
								if (button.elementIdentifier != elementIdentifierId)
								{
									num = -150215828;
									num3 = num;
								}
								else
								{
									num = -150215832;
									num3 = num;
								}
								continue;
							}
							case 4:
								break;
							case 0:
								return true;
							case 2:
								goto end_IL_0077;
							}
							goto IL_00bf;
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
							buttons[num] = button.elementIdentifier;
							int num2 = 1385457922;
							while (true)
							{
								switch (num2 ^ 0x52946903)
								{
								case 0:
									num2 = 1385457920;
									continue;
								case 3:
									break;
								case 1:
									num++;
									num2 = 1385457921;
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
							int num3 = 1385457920;
							while (true)
							{
								switch (num3 ^ 0x52946903)
								{
								case 0:
									num3 = 1385457921;
									continue;
								case 2:
									break;
								case 3:
									axes[num] = axis.elementIdentifier;
									num++;
									num3 = 1385457922;
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
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				Axis[] axes_orig = Axes_orig;
				AxisCalibrationData[] array = default(AxisCalibrationData[]);
				int num2 = default(int);
				while (true)
				{
					int num = -867253594;
					while (true)
					{
						switch (num ^ -867253600)
						{
						case 4:
							break;
						case 1:
						{
							ref AxisCalibrationData reference = ref array[num2];
							reference = AxisCalibrationData.Default;
							num = -867253589;
							continue;
						}
						case 8:
						{
							ref AxisCalibrationData reference2 = ref array[num2];
							reference2 = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							num = -867253597;
							continue;
						}
						case 7:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, deepClone: true);
							num2++;
							num = -867253600;
							continue;
						case 10:
							throw new NotImplementedException();
						case 6:
							if (axes_orig == null)
							{
								return null;
							}
							array = new AxisCalibrationData[axes_orig.Length];
							num2 = 0;
							num = -867253600;
							continue;
						case 2:
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num4;
								if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Hat)
								{
									num = -867253599;
									num4 = num;
								}
								else
								{
									num = -867253590;
									num4 = num;
								}
								continue;
							}
							goto case 1;
						case 9:
							array[num2].max = axes_orig[num2].axisMax;
							num = -867253593;
							continue;
						case 5:
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num3;
								if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Custom)
								{
									num = -867253592;
									num3 = num;
								}
								else
								{
									num = -867253598;
									num3 = num;
								}
								continue;
							}
							goto case 8;
						case 3:
							if (Axes_orig[num2].calibrateAxis)
							{
								array[num2].zero = axes_orig[num2].axisZero;
								array[num2].min = axes_orig[num2].axisMin;
								num = -867253591;
								continue;
							}
							goto case 7;
						case 11:
							num = -867253593;
							continue;
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
					axisInfos = new HardwareAxisInfo[Axes_orig.Length];
					int num = 1583198612;
					while (true)
					{
						switch (num ^ 0x5E5DB191)
						{
						case 2:
							num = 1583198617;
							continue;
						case 4:
							throw new Exception();
						case 5:
							num2 = 0;
							num = 1583198608;
							continue;
						case 3:
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num4;
								if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Hat)
								{
									num = 1583198613;
									num4 = num;
								}
								else
								{
									num = 1583198614;
									num4 = num;
								}
								continue;
							}
							goto case 7;
						case 8:
							break;
						case 6:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = 1583198616;
							continue;
						case 9:
							num2++;
							num = 1583198608;
							continue;
						case 7:
							axisRanges[num2] = AxisRange.Full;
							num = 1583198616;
							continue;
						case 0:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, createIfNull: true);
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num3;
								if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Custom)
								{
									num = 1583198615;
									num3 = num;
								}
								else
								{
									num = 1583198610;
									num3 = num;
								}
								continue;
							}
							goto case 6;
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
					int num2 = 1264966792;
					while (true)
					{
						switch (num2 ^ 0x4B65DC8B)
						{
						case 0:
							num2 = 1264966799;
							continue;
						case 4:
							break;
						case 2:
							buttonInfos[num] = MiscTools.DeepClone(Buttons_orig[num].buttonInfo, createIfNull: true);
							num++;
							num2 = 1264966794;
							continue;
						case 3:
							num2 = 1264966794;
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
					while (true)
					{
						int num = 513121392;
						while (true)
						{
							switch (num ^ 0x1E959C72)
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
							num = 513121395;
						}
					}
				}
				return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
			}

			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				lDFbNdJoGQnqiysLRaSElmIxwjqo lDFbNdJoGQnqiysLRaSElmIxwjqo2 = new lDFbNdJoGQnqiysLRaSElmIxwjqo(-2);
				lDFbNdJoGQnqiysLRaSElmIxwjqo2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return lDFbNdJoGQnqiysLRaSElmIxwjqo2;
			}

			internal override IEnumerable<Button_Base> IterateButtons()
			{
				gDZIhvbywaiiQRaQouPQGhNXpeVw gDZIhvbywaiiQRaQouPQGhNXpeVw2 = new gDZIhvbywaiiQRaQouPQGhNXpeVw(-2);
				gDZIhvbywaiiQRaQouPQGhNXpeVw2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return gDZIhvbywaiiQRaQouPQGhNXpeVw2;
			}

			public override object DeepClone()
			{
				Platform_RawInput_Base platform_RawInput_Base = new Platform_RawInput_Base();
				while (true)
				{
					int num = 1303153111;
					while (true)
					{
						switch (num ^ 0x4DAC89D6)
						{
						case 2:
							break;
						case 1:
							goto IL_0024;
						default:
							return platform_RawInput_Base;
						}
						break;
						IL_0024:
						CopyVars(platform_RawInput_Base);
						num = 1303153110;
					}
				}
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_RawInput_Base platform_RawInput_Base = default(Platform_RawInput_Base);
				while (true)
				{
					int num = -866537393;
					while (true)
					{
						switch (num ^ -866537394)
						{
						case 3:
							break;
						default:
							return;
						case 1:
							platform_RawInput_Base = destination as Platform_RawInput_Base;
							if (platform_RawInput_Base != null)
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
						platform_RawInput_Base.elements = MiscTools.DeepClone(elements);
						num = -866537396;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_RawInput : Platform_RawInput_Base
		{
			public Platform_RawInput_Base[] variants;

			internal override IList<Platform> variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					goto IL_000d;
				}
				int num;
				int num2;
				if (base.hasVariants)
				{
					num = -137503318;
					num2 = num;
				}
				else
				{
					num = -137503313;
					num2 = num;
				}
				goto IL_0012;
				IL_000d:
				num = -137503319;
				goto IL_0012;
				IL_0012:
				int num3 = default(int);
				while (true)
				{
					switch (num ^ -137503318)
					{
					case 6:
						break;
					case 3:
						return true;
					case 4:
					{
						if (variants[num3] != null && variants[num3].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							num = -137503315;
							continue;
						}
						num3++;
						num = -137503320;
						continue;
					}
					case 1:
						return true;
					case 7:
						variantIndex = num3;
						num = -137503317;
						continue;
					case 0:
						num3 = 0;
						num = -137503320;
						continue;
					case 2:
					{
						int num4;
						if (num3 >= variants.Length)
						{
							num = -137503313;
							num4 = num;
						}
						else
						{
							num = -137503314;
							num4 = num;
						}
						continue;
					}
					default:
						return false;
					}
					break;
				}
				goto IL_000d;
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
					int num = 749909271;
					while (true)
					{
						switch (num ^ 0x2CB2B515)
						{
						case 0:
							break;
						case 2:
							goto IL_0029;
						case 1:
							if (platform_RawInput == null)
							{
								return;
							}
							goto default;
						default:
							platform_RawInput.variants = MiscTools.DeepClone(variants);
							return;
						}
						break;
						IL_0029:
						platform_RawInput = destination as Platform_RawInput;
						num = 749909268;
					}
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

				internal override int alternateElementCount => 0;

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
					goto IL_0078;
					IL_0021:
					int num;
					int num2 = default(int);
					while (true)
					{
						switch (num ^ 0x695C7578)
						{
						case 3:
							break;
						case 2:
							goto IL_0042;
						case 0:
							goto IL_0059;
						case 1:
							return true;
						default:
							if (num2 >= subType.Length)
							{
								return false;
							}
							goto IL_0059;
						}
						break;
						IL_0059:
						if (subType[num2] == bridgedControllerHWInfo.hw_xInputSubType)
						{
							return true;
						}
						num2++;
						num = 1767667068;
						continue;
						IL_0042:
						if (hasData && isAllowed)
						{
							num = 1767667065;
							continue;
						}
						goto IL_0078;
					}
					goto IL_001c;
					IL_0078:
					num2 = 0;
					num = 1767667068;
					goto IL_0021;
					IL_001c:
					num = 1767667066;
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
					MatchingCriteria matchingCriteria = default(MatchingCriteria);
					while (true)
					{
						switch (-910779452 ^ -910779451)
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
					while (true)
					{
						int num = -486073415;
						while (true)
						{
							switch (num ^ -486073416)
							{
							case 2:
								break;
							case 1:
								goto IL_0024;
							default:
								return elements;
							}
							break;
							IL_0024:
							CopyVars(elements);
							num = -486073416;
						}
					}
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					Elements elements = default(Elements);
					while (true)
					{
						int num = -1764424697;
						while (true)
						{
							switch (num ^ -1764424698)
							{
							case 3:
								break;
							default:
								return;
							case 1:
								elements = destination as Elements;
								num = -1764424700;
								continue;
							case 5:
								elements.axes = ArrayTools.DeepClone(axes);
								elements.buttons = ArrayTools.DeepClone(buttons);
								num = -1764424698;
								continue;
							case 4:
								return;
							case 2:
							{
								int num2;
								if (elements == null)
								{
									num = -1764424702;
									num2 = num;
								}
								else
								{
									num = -1764424701;
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
							num3 = -1995999572;
							goto IL_0009;
						}
						goto IL_002a;
						IL_0009:
						while (true)
						{
							switch (num3 ^ -1995999571)
							{
							case 3:
								num3 = -1995999569;
								continue;
							case 2:
								break;
							case 4:
								goto IL_004c;
							case 0:
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
							num3 = -1995999572;
						}
						goto IL_002a;
						IL_002a:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							break;
						}
						num++;
						num3 = -1995999575;
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
							int num2;
							if (axes[num].elementIdentifier == elementIdentifier.id)
							{
								switch (axes[num].sourceType)
								{
								case HardwareElementSourceType.Custom:
									break;
								case HardwareElementSourceType.Axis:
									goto IL_0071;
								case HardwareElementSourceType.Button:
									axisRange = AxisRange.Positive;
									return true;
								default:
									throw new NotImplementedException();
								}
								num2 = -1007004890;
								goto IL_000c;
							}
							goto IL_00b9;
							IL_0071:
							axisRange = axes[num].sourceAxisRange;
							if (axes[num].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
								num2 = -1007004891;
								goto IL_000c;
							}
							goto IL_00a2;
							IL_00a2:
							return true;
							IL_00b9:
							num++;
							num2 = -1007004895;
							goto IL_000c;
							IL_000c:
							while (true)
							{
								switch (num2 ^ -1007004891)
								{
								case 5:
									num2 = -1007004892;
									continue;
								case 1:
									break;
								case 3:
									goto IL_0071;
								case 0:
									goto IL_00a2;
								case 2:
									goto IL_00b9;
								default:
									goto end_IL_0034;
								}
								break;
							}
							continue;
							end_IL_0034:
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
					while (true)
					{
						int num = -1971142299;
						while (true)
						{
							switch (num ^ -1971142300)
							{
							case 0:
								break;
							case 1:
								destination.sourceType = sourceType;
								num = -1971142297;
								continue;
							case 3:
								destination.sourceButton = sourceButton;
								destination.sourceAxis = sourceAxis;
								num = -1971142298;
								continue;
							default:
								destination.axisDeadZone = axisDeadZone;
								return;
							}
							break;
						}
					}
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
					while (true)
					{
						int num = 711673029;
						while (true)
						{
							switch (num ^ 0x2A6B44C7)
							{
							case 3:
								break;
							default:
								return;
							case 2:
							{
								int num2;
								if (button != null)
								{
									num = 711673031;
									num2 = num;
								}
								else
								{
									num = 711673027;
									num2 = num;
								}
								continue;
							}
							case 4:
								return;
							case 0:
								button.sourceAxisPole = sourceAxisPole;
								button.buttonInfo = MiscTools.DeepClone(buttonInfo);
								num = 711673030;
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
					if (!(destination is Axis axis))
					{
						return;
					}
					while (true)
					{
						axis.invert = invert;
						axis.buttonAxisContribution = buttonAxisContribution;
						axis.sourceAxisRange = sourceAxisRange;
						int num = 454038808;
						while (true)
						{
							switch (num ^ 0x1B10151A)
							{
							case 3:
								num = 454038811;
								continue;
							case 1:
								break;
							case 2:
								axis.calibrateAxis = calibrateAxis;
								num = 454038810;
								continue;
							default:
								axis.axisZero = axisZero;
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

			private sealed class kSPWBLfRRHMXpEVDSpIvTDEzGtf : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_XInput_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int lTXBKDJLCXdPiCwqfryEPhdnlNc;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						goto IL_001c;
					}
					goto IL_0059;
					IL_0059:
					kSPWBLfRRHMXpEVDSpIvTDEzGtf kSPWBLfRRHMXpEVDSpIvTDEzGtf2 = new kSPWBLfRRHMXpEVDSpIvTDEzGtf(0);
					int num = -1867440874;
					goto IL_0021;
					IL_001c:
					num = -1867440878;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ -1867440877)
						{
						case 4:
							break;
						case 5:
							kSPWBLfRRHMXpEVDSpIvTDEzGtf2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
							num = -1867440880;
							continue;
						case 2:
							goto IL_0059;
						case 0:
							num = -1867440880;
							continue;
						case 1:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							kSPWBLfRRHMXpEVDSpIvTDEzGtf2 = this;
							num = -1867440877;
							continue;
						default:
							return kSPWBLfRRHMXpEVDSpIvTDEzGtf2;
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
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					case 1:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = -1987124053;
						goto IL_001f;
					case 0:
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements == null || syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes == null)
							{
								break;
							}
							lTXBKDJLCXdPiCwqfryEPhdnlNc = 0;
							num = -1987124050;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -1987124054)
							{
							case 2:
								num = -1987124055;
								continue;
							case 1:
								lTXBKDJLCXdPiCwqfryEPhdnlNc++;
								num = -1987124050;
								continue;
							case 0:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes[lTXBKDJLCXdPiCwqfryEPhdnlNc];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 3:
								break;
							case 4:
								goto IL_00c7;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00c7:
							int num2;
							if (lTXBKDJLCXdPiCwqfryEPhdnlNc < syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes.Length)
							{
								num = -1987124054;
								num2 = num;
							}
							else
							{
								num = -1987124049;
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
				public kSPWBLfRRHMXpEVDSpIvTDEzGtf(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class ZAAhKIupPGwlOOFyPczeEthabHxt : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_XInput_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int OGYpYTSctkIKaNgDnCmdPuMTSTA;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
					{
						goto IL_0012;
					}
					goto IL_003c;
					IL_0012:
					int num = -1763988536;
					goto IL_0017;
					IL_0017:
					ZAAhKIupPGwlOOFyPczeEthabHxt zAAhKIupPGwlOOFyPczeEthabHxt = default(ZAAhKIupPGwlOOFyPczeEthabHxt);
					while (true)
					{
						switch (num ^ -1763988535)
						{
						case 3:
							break;
						case 5:
							goto IL_003c;
						case 4:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							zAAhKIupPGwlOOFyPczeEthabHxt = this;
							num = -1763988535;
							continue;
						case 2:
							zAAhKIupPGwlOOFyPczeEthabHxt.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
							num = -1763988535;
							continue;
						case 1:
							goto IL_006d;
						default:
							return zAAhKIupPGwlOOFyPczeEthabHxt;
						}
						break;
						IL_006d:
						int num2;
						if (isaqVUvqwfWYqOUtovbpbCbxgPc != -2)
						{
							num = -1763988532;
							num2 = num;
						}
						else
						{
							num = -1763988531;
							num2 = num;
						}
					}
					goto IL_0012;
					IL_003c:
					zAAhKIupPGwlOOFyPczeEthabHxt = new ZAAhKIupPGwlOOFyPczeEthabHxt(0);
					num = -1763988533;
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
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					default:
						num = -752435152;
						goto IL_001a;
					case 1:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						OGYpYTSctkIKaNgDnCmdPuMTSTA++;
						num = -752435145;
						goto IL_001a;
					case 0:
						goto IL_00bf;
						IL_001a:
						while (true)
						{
							switch (num ^ -752435151)
							{
							case 4:
								break;
							case 1:
								num = -752435150;
								continue;
							case 5:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons[OGYpYTSctkIKaNgDnCmdPuMTSTA];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 2:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null && syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons != null)
								{
									OGYpYTSctkIKaNgDnCmdPuMTSTA = 0;
									num = -752435145;
									continue;
								}
								goto default;
							case 0:
								goto IL_00bf;
							case 6:
								goto IL_00d0;
							default:
								return false;
							}
							break;
							IL_00d0:
							int num2;
							if (OGYpYTSctkIKaNgDnCmdPuMTSTA < syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons.Length)
							{
								num = -752435148;
								num2 = num;
							}
							else
							{
								num = -752435150;
								num2 = num;
							}
						}
						goto default;
						IL_00bf:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = -752435149;
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
				public ZAAhKIupPGwlOOFyPczeEthabHxt(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.ZrSavanyxdsgnhdTbscQkWtEAzy;

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
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal override Elements_Base elements_base => elements;

			internal override IList<Platform> variants_base => null;

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
				kSPWBLfRRHMXpEVDSpIvTDEzGtf kSPWBLfRRHMXpEVDSpIvTDEzGtf2 = new kSPWBLfRRHMXpEVDSpIvTDEzGtf(-2);
				kSPWBLfRRHMXpEVDSpIvTDEzGtf2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return kSPWBLfRRHMXpEVDSpIvTDEzGtf2;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				ZAAhKIupPGwlOOFyPczeEthabHxt zAAhKIupPGwlOOFyPczeEthabHxt = new ZAAhKIupPGwlOOFyPczeEthabHxt(-2);
				zAAhKIupPGwlOOFyPczeEthabHxt.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return zAAhKIupPGwlOOFyPczeEthabHxt;
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
					if (num < array.Length)
					{
						num2 = 1307969593;
						num3 = num2;
					}
					else
					{
						num2 = 1307969594;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x4DF6083A)
						{
						case 7:
							num2 = 1307969593;
							continue;
						case 2:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = 1307969598;
							continue;
						case 5:
							if (elementIdentifier >= 0)
							{
								int num4;
								if (elementIdentifier < identifiers.Length)
								{
									num2 = 1307969596;
									num4 = num2;
								}
								else
								{
									num2 = 1307969592;
									num4 = num2;
								}
								continue;
							}
							goto case 2;
						case 3:
							elementIdentifier = elements.axes[num].elementIdentifier;
							num2 = 1307969599;
							continue;
						case 1:
							break;
						case 4:
							num++;
							num2 = 1307969595;
							continue;
						case 6:
							array[num] = identifiers[elementIdentifier].name;
							num2 = 1307969598;
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
						int num2 = 435816672;
						while (true)
						{
							switch (num2 ^ 0x19FA08E5)
							{
							case 0:
								num2 = 435816675;
								continue;
							case 4:
								num++;
								num2 = 435816676;
								continue;
							case 2:
								Logger.LogError("Element identifier index is out of bounds!");
								num2 = 435816673;
								continue;
							case 3:
								array[num] = identifiers[num3].name;
								num2 = 435816673;
								continue;
							case 5:
								num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
								if (num3 < 0)
								{
									goto case 2;
								}
								goto IL_009d;
							case 6:
								break;
							default:
								goto end_IL_00b5;
							}
							break;
							IL_009d:
							int num4;
							if (num3 < identifiers.Length)
							{
								num2 = 435816678;
								num4 = num2;
							}
							else
							{
								num2 = 435816679;
								num4 = num2;
							}
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
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				using (IEnumerator<Button> enumerator2 = IterateButtons().GetEnumerator())
				{
					while (true)
					{
						IL_00ab:
						int num;
						int num2;
						if (!enumerator2.MoveNext())
						{
							num = 1980539887;
							num2 = num;
						}
						else
						{
							num = 1980539886;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x760CA3EC)
							{
							case 0:
								goto IL_006d;
							default:
								goto end_IL_0072;
							case 2:
							{
								Button current2 = enumerator2.Current;
								if (current2.elementIdentifier == elementIdentifierId)
								{
									return true;
								}
								break;
							}
							case 1:
								break;
							case 3:
								goto end_IL_0072;
							}
							goto IL_00ab;
							IL_006d:
							num = 1980539886;
							continue;
							end_IL_0072:
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
				int num2 = default(int);
				while (true)
				{
					int num = -1243582915;
					while (true)
					{
						switch (num ^ -1243582913)
						{
						case 0:
							break;
						case 2:
							goto IL_0038;
						default:
						{
							using (IEnumerator<Button> enumerator = IterateButtons().GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										Button current = enumerator.Current;
										buttons[num2] = current.elementIdentifier;
										num2++;
										int num3 = -1243582914;
										while (true)
										{
											switch (num3 ^ -1243582913)
											{
											case 0:
												num3 = -1243582915;
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
							num2 = 0;
							IEnumerator<Axis> enumerator2 = IterateAxes().GetEnumerator();
							try
							{
								while (true)
								{
									int num4;
									int num5;
									if (enumerator2.MoveNext())
									{
										num4 = -1243582915;
										num5 = num4;
									}
									else
									{
										num4 = -1243582913;
										num5 = num4;
									}
									while (true)
									{
										switch (num4 ^ -1243582913)
										{
										case 4:
											num4 = -1243582915;
											continue;
										default:
											return;
										case 2:
										{
											Axis current2 = enumerator2.Current;
											axes[num2] = current2.elementIdentifier;
											num4 = -1243582914;
											continue;
										}
										case 1:
											num2++;
											num4 = -1243582916;
											continue;
										case 3:
											break;
										case 0:
											return;
										}
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
										IL_0118:
										int num6 = -1243582914;
										while (true)
										{
											switch (num6 ^ -1243582913)
											{
											case 2:
												break;
											default:
												goto end_IL_011d;
											case 1:
												goto IL_0136;
											case 0:
												goto end_IL_011d;
											}
											goto IL_0118;
											IL_0136:
											enumerator2.Dispose();
											num6 = -1243582913;
											continue;
											end_IL_011d:
											break;
										}
										break;
									}
								}
							}
						}
						}
						break;
						IL_0038:
						num2 = 0;
						num = -1243582914;
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
					int num = -1087484427;
					while (true)
					{
						switch (num ^ -1087484432)
						{
						case 3:
							break;
						case 0:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, deepClone: true);
							num2++;
							num = -1087484424;
							continue;
						case 6:
							array[num2].zero = axes_orig[num2].axisZero;
							array[num2].min = axes_orig[num2].axisMin;
							array[num2].max = axes_orig[num2].axisMax;
							num = -1087484432;
							continue;
						case 5:
							num2 = 0;
							num = -1087484424;
							continue;
						case 2:
							throw new NotImplementedException();
						case 4:
						{
							int num3;
							if (Axes_orig[num2].calibrateAxis)
							{
								num = -1087484426;
								num3 = num;
							}
							else
							{
								num = -1087484432;
								num3 = num;
							}
							continue;
						}
						case 7:
							if (axes_orig[num2].sourceType == HardwareElementSourceType.Button)
							{
								ref AxisCalibrationData reference2 = ref array[num2];
								reference2 = AxisCalibrationData.Default;
								num = -1087484432;
								continue;
							}
							goto case 2;
						case 1:
							if (axes_orig[num2].sourceType != HardwareElementSourceType.Axis)
							{
								int num4;
								if (axes_orig[num2].sourceType != HardwareElementSourceType.Custom)
								{
									num = -1087484425;
									num4 = num;
								}
								else
								{
									num = -1087484423;
									num4 = num;
								}
								continue;
							}
							goto case 9;
						case 9:
						{
							ref AxisCalibrationData reference = ref array[num2];
							reference = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							num = -1087484428;
							continue;
						}
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
					int num = -1813937309;
					while (true)
					{
						switch (num ^ -1813937306)
						{
						case 9:
							break;
						case 2:
							num2++;
							num = -1813937307;
							continue;
						case 13:
							num = -1813937308;
							continue;
						case 4:
							return;
						case 5:
						{
							axisInfos = null;
							int num4;
							if (Axes_orig == null)
							{
								num = -1813937310;
								num4 = num;
							}
							else
							{
								num = -1813937298;
								num4 = num;
							}
							continue;
						}
						case 7:
							num = -1813937308;
							continue;
						case 8:
							axisRanges = new AxisRange[Axes_orig.Length];
							num = -1813937302;
							continue;
						case 1:
							num2 = 0;
							num = -1813937307;
							continue;
						case 11:
						{
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, createIfNull: true);
							int num5;
							if (Axes_orig[num2].sourceType != HardwareElementSourceType.Axis)
							{
								num = -1813937300;
								num5 = num;
							}
							else
							{
								num = -1813937312;
								num5 = num;
							}
							continue;
						}
						case 0:
							throw new Exception();
						case 6:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -1813937311;
							continue;
						case 14:
							if (Axes_orig[num2].sourceType == HardwareElementSourceType.Button)
							{
								axisRanges[num2] = AxisRange.Full;
								num = -1813937301;
								continue;
							}
							goto case 0;
						case 12:
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num = -1813937305;
							continue;
						case 10:
						{
							int num3;
							if (Axes_orig[num2].sourceType == HardwareElementSourceType.Custom)
							{
								num = -1813937312;
								num3 = num;
							}
							else
							{
								num = -1813937304;
								num3 = num;
							}
							continue;
						}
						default:
							if (num2 >= Axes_orig.Length)
							{
								return;
							}
							goto case 11;
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
					int num2 = 1253290401;
					while (true)
					{
						switch (num2 ^ 0x4AB3B1A0)
						{
						case 0:
							num2 = 1253290404;
							continue;
						case 4:
							break;
						case 2:
							buttonInfos[num] = MiscTools.DeepClone(Buttons_orig[num].buttonInfo, createIfNull: true);
							num2 = 1253290403;
							continue;
						case 3:
							num++;
							num2 = 1253290401;
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
				Platform_XInput_Base platform_XInput_Base = new Platform_XInput_Base();
				CopyVars(platform_XInput_Base);
				return platform_XInput_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				if (!(destination is Platform_XInput_Base platform_XInput_Base))
				{
					return;
				}
				while (true)
				{
					platform_XInput_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					int num = -1285529568;
					while (true)
					{
						switch (num ^ -1285529566)
						{
						case 3:
							num = -1285529565;
							continue;
						default:
							return;
						case 1:
							break;
						case 2:
							platform_XInput_Base.elements = MiscTools.DeepClone(elements);
							num = -1285529566;
							continue;
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
		public sealed class Platform_XInput : Platform_XInput_Base
		{
			public Platform_XInput_Base[] variants;

			internal override IList<Platform> variants_base => variants;

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
							num2 = -1623434235;
							num3 = num2;
						}
						else
						{
							num2 = -1623434233;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -1623434235)
							{
							case 3:
								num2 = -1623434233;
								continue;
							case 2:
								break;
							case 1:
								goto IL_0059;
							case 5:
								return true;
							case 4:
								goto end_IL_0023;
							default:
								goto end_IL_0085;
							}
							if (variants[num] != null)
							{
								num2 = -1623434236;
								continue;
							}
							goto IL_007a;
							IL_0059:
							if (variants[num].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
							{
								variantIndex = num;
								num2 = -1623434240;
								continue;
							}
							goto IL_007a;
							IL_007a:
							num++;
							num2 = -1623434239;
							continue;
							end_IL_0023:
							break;
						}
						continue;
						end_IL_0085:
						break;
					}
				}
				return false;
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
				Platform_XInput platform_XInput = default(Platform_XInput);
				while (true)
				{
					switch (0x2D4C4834 ^ 0x2D4C4836)
					{
					case 0:
						continue;
					case 2:
						platform_XInput = destination as Platform_XInput;
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
						dRRcHzjfmpPQmjfIpMUExpcDkuyC(elementCount);
						return elementCount;
					}

					internal override void dRRcHzjfmpPQmjfIpMUExpcDkuyC(ElementCount_Base P_0)
					{
						base.dRRcHzjfmpPQmjfIpMUExpcDkuyC(P_0);
						ElementCount elementCount = P_0 as ElementCount;
						if (elementCount == null)
						{
							while (true)
							{
								switch (-1712803252 ^ -1712803251)
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

					internal override bool YfzaYuFFeAGpZYIlhOCKodCcBwd(BridgedControllerHWInfo P_0)
					{
						if (!base.YfzaYuFFeAGpZYIlhOCKodCcBwd(P_0))
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
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						goto IL_0027;
					}
					bool flag = default(bool);
					int num = default(int);
					int num2;
					if (strictMatch)
					{
						flag = false;
						num = 0;
						num2 = 387938782;
						goto IL_002c;
					}
					string text = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
					text = text.Trim();
					if (!ProductNameMatches(text))
					{
						return false;
					}
					return true;
					IL_002c:
					while (true)
					{
						switch (num2 ^ 0x171F79DE)
						{
						case 7:
							break;
						case 1:
							num++;
							num2 = 387938782;
							continue;
						case 0:
							if (num >= vendorId.Length)
							{
								if (!flag)
								{
									num2 = 387938776;
									continue;
								}
								if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
								{
									string name = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
									if (!ProductNameMatches(name))
									{
										return false;
									}
								}
								return true;
							}
							goto case 3;
						case 4:
							flag = true;
							num2 = 387938783;
							continue;
						case 2:
							if (num < productId.Length)
							{
								int num3;
								if (productId[num] == bridgedControllerHWInfo.hw_productId)
								{
									num2 = 387938778;
									num3 = num2;
								}
								else
								{
									num2 = 387938783;
									num3 = num2;
								}
								continue;
							}
							goto case 1;
						case 5:
							return false;
						case 3:
						{
							int num4;
							if (vendorId[num] == bridgedControllerHWInfo.hw_vendorId)
							{
								num2 = 387938780;
								num4 = num2;
							}
							else
							{
								num2 = 387938783;
								num4 = num2;
							}
							continue;
						}
						default:
							return false;
						}
						break;
					}
					goto IL_0027;
					IL_0027:
					num2 = 387938779;
					goto IL_002c;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					if (alternateElementCounts != null)
					{
						while (true)
						{
							int num = 250369939;
							while (true)
							{
								switch (num ^ 0xEEC5791)
								{
								case 0:
									break;
								case 2:
									goto IL_002a;
								case 3:
									goto IL_003f;
								default:
									goto end_IL_0008;
								}
								break;
								IL_003f:
								if (index >= alternateElementCounts.Length)
								{
									num = 250369936;
									continue;
								}
								return alternateElementCounts[index];
								IL_002a:
								int num2;
								if (index >= 0)
								{
									num = 250369938;
									num2 = num;
								}
								else
								{
									num = 250369936;
									num2 = num;
								}
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
						goto IL_0010;
					}
					int num;
					if (hatCount >= 0)
					{
						num = 952226928;
						goto IL_0015;
					}
					return true;
					IL_0015:
					switch (num ^ 0x38C1D471)
					{
					case 0:
						break;
					case 2:
						return true;
					default:
						return bridgedControllerHWInfo.hardwareHatCount == hatCount;
					}
					goto IL_0010;
					IL_0010:
					num = 952226931;
					goto IL_0015;
				}

				private bool ProductNameMatches(string name)
				{
					if (productName == null)
					{
						goto IL_0008;
					}
					int num = 0;
					int num2 = -23679471;
					goto IL_000d;
					IL_000d:
					while (true)
					{
						object obj;
						string text;
						switch (num2 ^ -23679471)
						{
						case 3:
							break;
						case 1:
							return false;
						case 4:
							obj = productName[num];
							goto IL_0048;
						case 2:
							if (productName[num] == null)
							{
								obj = string.Empty;
								goto IL_0048;
							}
							num2 = -23679467;
							continue;
						default:
							{
								if (num >= productName.Length)
								{
									return false;
								}
								goto case 2;
							}
							IL_0048:
							text = (string)obj;
							text = text.Trim();
							if (MatchingCriteria_Base.StringMatches(name, text, productName_useRegex))
							{
								return true;
							}
							num++;
							num2 = -23679471;
							continue;
						}
						break;
					}
					goto IL_0008;
					IL_0008:
					num2 = -23679472;
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
						int num = -628285360;
						while (true)
						{
							switch (num ^ -628285353)
							{
							case 6:
								break;
							default:
								return;
							case 4:
								matchingCriteria.vendorId = ArrayTools.ShallowCopy(vendorId);
								num = -628285355;
								continue;
							case 3:
								if (matchingCriteria == null)
								{
									return;
								}
								goto case 1;
							case 0:
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
								matchingCriteria.productId = ArrayTools.ShallowCopy(productId);
								num = -628285357;
								continue;
							case 1:
								matchingCriteria.hatCount = hatCount;
								num = -628285358;
								continue;
							case 5:
								matchingCriteria.productName_useRegex = productName_useRegex;
								num = -628285353;
								continue;
							case 7:
								matchingCriteria = destination as MatchingCriteria;
								num = -628285356;
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
			public sealed class Elements : Elements_Base
			{
				private sealed class cscZvBykTFWSVtFwnBFkiyLpzKN : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
				{
					private Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public Elements syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public Axis UdmbZjotNPTIzbGMDCJMArYvUcf;

					public Axis[] KsfZQXVaACAwMtxmmLsgyhAjgox;

					public int HPRZlTAPkjmYUJDHsnjKXgDsqYt;

					Axis IEnumerator<Axis>.Current
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
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							goto IL_001c;
						}
						goto IL_0059;
						IL_0059:
						cscZvBykTFWSVtFwnBFkiyLpzKN cscZvBykTFWSVtFwnBFkiyLpzKN2 = new cscZvBykTFWSVtFwnBFkiyLpzKN(0);
						cscZvBykTFWSVtFwnBFkiyLpzKN2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						int num = -1207724819;
						goto IL_0021;
						IL_001c:
						num = -1207724824;
						goto IL_0021;
						IL_0021:
						while (true)
						{
							switch (num ^ -1207724820)
							{
							case 0:
								break;
							case 4:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								cscZvBykTFWSVtFwnBFkiyLpzKN2 = this;
								num = -1207724817;
								continue;
							case 3:
								num = -1207724819;
								continue;
							case 2:
								goto IL_0059;
							default:
								return cscZvBykTFWSVtFwnBFkiyLpzKN2;
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
						bool result = default(bool);
						try
						{
							int num;
							switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
							{
							case 2:
								goto IL_0094;
							case 0:
								goto IL_00f7;
								IL_0094:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								HPRZlTAPkjmYUJDHsnjKXgDsqYt++;
								num = -2003040650;
								goto IL_0023;
								IL_0023:
								while (true)
								{
									switch (num ^ -2003040649)
									{
									case 0:
										num = -2003040653;
										continue;
									case 8:
										break;
									case 5:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										result = true;
										num = -2003040641;
										continue;
									case 1:
										if (HPRZlTAPkjmYUJDHsnjKXgDsqYt >= KsfZQXVaACAwMtxmmLsgyhAjgox.Length)
										{
											JSPjmGbEMheKxvrEpYaESVrlHTN();
											num = -2003040652;
											continue;
										}
										goto case 9;
									case 2:
										goto IL_0094;
									case 6:
										HPRZlTAPkjmYUJDHsnjKXgDsqYt = 0;
										num = -2003040650;
										continue;
									case 9:
										UdmbZjotNPTIzbGMDCJMArYvUcf = KsfZQXVaACAwMtxmmLsgyhAjgox[HPRZlTAPkjmYUJDHsnjKXgDsqYt];
										num = -2003040656;
										continue;
									case 7:
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = UdmbZjotNPTIzbGMDCJMArYvUcf;
										num = -2003040654;
										continue;
									case 4:
										goto IL_00f7;
									default:
										goto end_IL_0008;
									}
									break;
								}
								goto end_IL_0000;
								IL_00f7:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.axes == null)
								{
									break;
								}
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								KsfZQXVaACAwMtxmmLsgyhAjgox = syCPfFbHYMDOvEPjTnPLBqiOhsPv.axes;
								num = -2003040655;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							JSPjmGbEMheKxvrEpYaESVrlHTN();
							break;
						}
					}

					[DebuggerHidden]
					public cscZvBykTFWSVtFwnBFkiyLpzKN(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void JSPjmGbEMheKxvrEpYaESVrlHTN()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					}
				}

				private sealed class MFcCgiFUZpYCHYxqjNkRzDjUNyp : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
				{
					private Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public Elements syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public Button KDJbbeLSSSFtqdoegpiANqEwMtk;

					public Button[] FpFSrkqldeAdbjTLJJJuDuEjpYlB;

					public int XlNDDOhxmPlGuuPacxgnFMhNgcT;

					Button IEnumerator<Button>.Current
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
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
						{
							goto IL_0012;
						}
						goto IL_004f;
						IL_0012:
						int num = -1811458109;
						goto IL_0017;
						IL_0017:
						MFcCgiFUZpYCHYxqjNkRzDjUNyp mFcCgiFUZpYCHYxqjNkRzDjUNyp = default(MFcCgiFUZpYCHYxqjNkRzDjUNyp);
						while (true)
						{
							switch (num ^ -1811458112)
							{
							case 0:
								break;
							case 2:
								mFcCgiFUZpYCHYxqjNkRzDjUNyp.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
								num = -1811458107;
								continue;
							case 4:
								goto IL_004f;
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								mFcCgiFUZpYCHYxqjNkRzDjUNyp = this;
								num = -1811458107;
								continue;
							case 3:
								goto IL_006d;
							default:
								return mFcCgiFUZpYCHYxqjNkRzDjUNyp;
							}
							break;
							IL_006d:
							int num2;
							if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
							{
								num = -1811458111;
								num2 = num;
							}
							else
							{
								num = -1811458108;
								num2 = num;
							}
						}
						goto IL_0012;
						IL_004f:
						mFcCgiFUZpYCHYxqjNkRzDjUNyp = new MFcCgiFUZpYCHYxqjNkRzDjUNyp(0);
						num = -1811458110;
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
							switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
							{
							default:
								num = -1184226637;
								goto IL_001e;
							case 0:
								goto IL_0121;
							case 2:
								goto IL_0132;
							case 1:
								break;
								IL_001e:
								while (true)
								{
									switch (num ^ -1184226635)
									{
									case 0:
										break;
									case 6:
										num = -1184226638;
										continue;
									case 2:
										KDJbbeLSSSFtqdoegpiANqEwMtk = FpFSrkqldeAdbjTLJJJuDuEjpYlB[XlNDDOhxmPlGuuPacxgnFMhNgcT];
										num = -1184226636;
										continue;
									case 11:
										goto end_IL_0000;
									case 4:
										FpFSrkqldeAdbjTLJJJuDuEjpYlB = syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttons;
										XlNDDOhxmPlGuuPacxgnFMhNgcT = 0;
										num = -1184226628;
										continue;
									case 3:
										goto IL_00ad;
									case 1:
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = KDJbbeLSSSFtqdoegpiANqEwMtk;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										result = true;
										num = -1184226626;
										continue;
									case 8:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num = -1184226639;
										continue;
									case 9:
										if (XlNDDOhxmPlGuuPacxgnFMhNgcT >= FpFSrkqldeAdbjTLJJJuDuEjpYlB.Length)
										{
											DkvaFYOVTzjSnOweAtxiuIzoItH();
											num = -1184226638;
											continue;
										}
										goto case 2;
									case 10:
										goto IL_0121;
									case 5:
										goto IL_0132;
									default:
										goto end_IL_0008;
									}
									break;
									IL_00ad:
									int num2;
									if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttons == null)
									{
										num = -1184226638;
										num2 = num;
									}
									else
									{
										num = -1184226627;
										num2 = num;
									}
								}
								goto default;
								IL_0132:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								XlNDDOhxmPlGuuPacxgnFMhNgcT++;
								num = -1184226628;
								goto IL_001e;
								IL_0121:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num = -1184226634;
								goto IL_001e;
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
						int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
						while (true)
						{
							int num2 = -415606673;
							while (true)
							{
								switch (num2 ^ -415606674)
								{
								case 2:
									break;
								case 1:
									switch (num)
									{
									default:
										goto IL_0039;
									case 1:
									case 2:
										break;
									}
									goto default;
								case 3:
									return;
								default:
									DkvaFYOVTzjSnOweAtxiuIzoItH();
									return;
								}
								break;
								IL_0039:
								num2 = -415606675;
							}
						}
					}

					[DebuggerHidden]
					public MFcCgiFUZpYCHYxqjNkRzDjUNyp(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void DkvaFYOVTzjSnOweAtxiuIzoItH()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
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
					cscZvBykTFWSVtFwnBFkiyLpzKN cscZvBykTFWSVtFwnBFkiyLpzKN2 = new cscZvBykTFWSVtFwnBFkiyLpzKN(-2);
					cscZvBykTFWSVtFwnBFkiyLpzKN2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					return cscZvBykTFWSVtFwnBFkiyLpzKN2;
				}

				public IEnumerable<Button> IterateButtons()
				{
					MFcCgiFUZpYCHYxqjNkRzDjUNyp mFcCgiFUZpYCHYxqjNkRzDjUNyp = new MFcCgiFUZpYCHYxqjNkRzDjUNyp(-2);
					while (true)
					{
						int num = -1230902011;
						while (true)
						{
							switch (num ^ -1230902009)
							{
							case 0:
								break;
							case 2:
								goto IL_0026;
							default:
								return mFcCgiFUZpYCHYxqjNkRzDjUNyp;
							}
							break;
							IL_0026:
							mFcCgiFUZpYCHYxqjNkRzDjUNyp.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
							num = -1230902010;
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
						int num = 373283734;
						while (true)
						{
							switch (num ^ 0x163FDB97)
							{
							case 3:
								break;
							case 1:
								elements = destination as Elements;
								num = 373283731;
								continue;
							case 4:
							{
								int num2;
								if (elements == null)
								{
									num = 373283733;
									num2 = num;
								}
								else
								{
									num = 373283735;
									num2 = num;
								}
								continue;
							}
							case 2:
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
							num3 = -837038246;
							goto IL_0009;
						}
						goto IL_0062;
						IL_0009:
						while (true)
						{
							switch (num3 ^ -837038241)
							{
							case 4:
								num3 = -837038243;
								continue;
							case 3:
								break;
							case 1:
								goto end_IL_0009;
							case 2:
								goto IL_0062;
							case 5:
								goto IL_0084;
							default:
								return elementIdentifier.elementType;
							}
							if (buttons[num2].elementIdentifier == elementIdentifier.id)
							{
								return ControllerElementType.Button;
							}
							num2++;
							num3 = -837038246;
							continue;
							IL_0084:
							int num4;
							if (num2 >= buttonCount)
							{
								num3 = -837038241;
								num4 = num3;
							}
							else
							{
								num3 = -837038244;
								num4 = num3;
							}
							continue;
							end_IL_0009:
							break;
						}
						continue;
						IL_0062:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							break;
						}
						num++;
						num3 = -837038242;
						goto IL_0009;
					}
					return ControllerElementType.Axis;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					while (true)
					{
						int num2 = 1958871205;
						while (true)
						{
							switch (num2 ^ 0x74C200A2)
							{
							case 5:
								break;
							case 2:
								axisRange = axes[num].sourceAxisRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 1958871202;
									continue;
								}
								goto case 0;
							case 3:
								num++;
								num2 = 1958871206;
								continue;
							case 7:
								num2 = 1958871206;
								continue;
							case 0:
								return true;
							case 1:
								return true;
							case 8:
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 1958871203;
									continue;
								}
								goto case 1;
							case 6:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									switch (axes[num].sourceType)
									{
									case HardwareElementSourceTypeWithHat.Axis:
										break;
									case HardwareElementSourceTypeWithHat.Button:
										axisRange = AxisRange.Positive;
										return true;
									case HardwareElementSourceTypeWithHat.Hat:
										axisRange = axes[num].sourceHatRange;
										num2 = 1958871210;
										continue;
									default:
										throw new NotImplementedException();
									case HardwareElementSourceTypeWithHat.Custom:
										num2 = 1958871200;
										continue;
									}
									goto case 2;
								}
								goto case 3;
							default:
								if (num >= axisCount)
								{
									axisRange = AxisRange.Full;
									return false;
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
					button.elementIdentifier = elementIdentifier;
					while (true)
					{
						int num = -1105636288;
						while (true)
						{
							switch (num ^ -1105636283)
							{
							case 0:
								break;
							case 6:
								button.sourceAxisPole = sourceAxisPole;
								button.axisDeadZone = axisDeadZone;
								num = -1105636287;
								continue;
							case 1:
								button.requiredButtons = ArrayTools.ShallowCopy(requiredButtons);
								num = -1105636282;
								continue;
							case 5:
								button.sourceType = sourceType;
								num = -1105636281;
								continue;
							case 2:
								button.sourceButton = sourceButton;
								button.sourceStick = sourceStick;
								button.sourceAxis = sourceAxis;
								button.sourceOtherAxis = sourceOtherAxis;
								num = -1105636285;
								continue;
							case 4:
								button.sourceHat = sourceHat;
								button.sourceHatType = sourceHatType;
								button.sourceHatDirection = sourceHatDirection;
								button.requireMultipleButtons = requireMultipleButtons;
								num = -1105636284;
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
						int num = -1576170428;
						while (true)
						{
							switch (num ^ -1576170425)
							{
							case 2:
								break;
							case 1:
								axis.sourceHat = sourceHat;
								axis.sourceHatDirection = sourceHatDirection;
								axis.sourceHatRange = sourceHatRange;
								axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
								num = -1576170430;
								continue;
							case 0:
								axis.axisMax = axisMax;
								axis.axisInfo = MiscTools.DeepClone(axisInfo);
								num = -1576170429;
								continue;
							case 3:
								axis.axisZero = axisZero;
								axis.axisMin = axisMin;
								num = -1576170425;
								continue;
							case 4:
								axis.sourceButton = sourceButton;
								axis.buttonAxisContribution = buttonAxisContribution;
								num = -1576170426;
								continue;
							default:
								return axis;
							}
							break;
						}
					}
				}
			}

			private sealed class oPxnOfTdpeLnVurkGKoqTjdxxmn : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_OSX_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int GoQaMyeyKhEOAfhqielmYsAoulck;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					oPxnOfTdpeLnVurkGKoqTjdxxmn oPxnOfTdpeLnVurkGKoqTjdxxmn2;
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						oPxnOfTdpeLnVurkGKoqTjdxxmn2 = this;
						goto IL_0025;
					}
					goto IL_0065;
					IL_002a:
					int num;
					while (true)
					{
						switch (num ^ 0x5D81B60A)
						{
						case 4:
							break;
						case 1:
							num = 1568781833;
							continue;
						case 0:
							oPxnOfTdpeLnVurkGKoqTjdxxmn2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
							num = 1568781833;
							continue;
						case 2:
							goto IL_0065;
						default:
							return oPxnOfTdpeLnVurkGKoqTjdxxmn2;
						}
						break;
					}
					goto IL_0025;
					IL_0065:
					oPxnOfTdpeLnVurkGKoqTjdxxmn2 = new oPxnOfTdpeLnVurkGKoqTjdxxmn(0);
					num = 1568781834;
					goto IL_002a;
					IL_0025:
					num = 1568781835;
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
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					default:
						num = 1642330582;
						goto IL_001a;
					case 1:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						GoQaMyeyKhEOAfhqielmYsAoulck++;
						num = 1642330578;
						goto IL_001a;
					case 0:
						goto IL_0109;
						IL_001a:
						while (true)
						{
							switch (num ^ 0x61E3F9D1)
							{
							case 0:
								break;
							case 5:
								return true;
							case 8:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = 1642330580;
								continue;
							case 6:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes[GoQaMyeyKhEOAfhqielmYsAoulck];
								num = 1642330585;
								continue;
							case 3:
								goto IL_00a1;
							case 4:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null && syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes != null)
								{
									GoQaMyeyKhEOAfhqielmYsAoulck = 0;
									num = 1642330578;
									continue;
								}
								goto default;
							case 7:
								num = 1642330579;
								continue;
							case 1:
								goto IL_0109;
							default:
								return false;
							}
							break;
							IL_00a1:
							int num2;
							if (GoQaMyeyKhEOAfhqielmYsAoulck < syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes.Length)
							{
								num = 1642330583;
								num2 = num;
							}
							else
							{
								num = 1642330579;
								num2 = num;
							}
						}
						goto default;
						IL_0109:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = 1642330581;
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
				public oPxnOfTdpeLnVurkGKoqTjdxxmn(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class RPptlundFnlhgIcEDMqASIVdwvP : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_OSX_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int sIvfzINesWPJPmSjekSINUomOhG;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						goto IL_0023;
					}
					goto IL_004e;
					IL_0028:
					int num;
					RPptlundFnlhgIcEDMqASIVdwvP rPptlundFnlhgIcEDMqASIVdwvP = default(RPptlundFnlhgIcEDMqASIVdwvP);
					while (true)
					{
						switch (num ^ -240832089)
						{
						case 2:
							break;
						case 3:
							rPptlundFnlhgIcEDMqASIVdwvP = this;
							num = -240832090;
							continue;
						case 0:
							goto IL_004e;
						default:
							return rPptlundFnlhgIcEDMqASIVdwvP;
						}
						break;
					}
					goto IL_0023;
					IL_004e:
					rPptlundFnlhgIcEDMqASIVdwvP = new RPptlundFnlhgIcEDMqASIVdwvP(0);
					rPptlundFnlhgIcEDMqASIVdwvP.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					num = -240832090;
					goto IL_0028;
					IL_0023:
					num = -240832092;
					goto IL_0028;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = -169913869;
						while (true)
						{
							switch (num2 ^ -169913872)
							{
							case 6:
								break;
							case 8:
								return true;
							case 7:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null && syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons != null)
								{
									sIvfzINesWPJPmSjekSINUomOhG = 0;
									num2 = -169913867;
									continue;
								}
								goto default;
							case 2:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num2 = -169913865;
								continue;
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num2 = -169913864;
								continue;
							case 3:
								switch (num)
								{
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									sIvfzINesWPJPmSjekSINUomOhG++;
									num2 = -169913867;
									continue;
								case 0:
									break;
								default:
									num2 = -169913872;
									continue;
								}
								goto case 2;
							case 5:
							{
								int num3;
								if (sIvfzINesWPJPmSjekSINUomOhG < syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons.Length)
								{
									num2 = -169913868;
									num3 = num2;
								}
								else
								{
									num2 = -169913872;
									num3 = num2;
								}
								continue;
							}
							case 4:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons[sIvfzINesWPJPmSjekSINUomOhG];
								num2 = -169913871;
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
				public RPptlundFnlhgIcEDMqASIVdwvP(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.PFLTzcYFaBOghAebEsCXymESHdk;

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
						goto IL_0017;
					}
					int num;
					if (assignedAxisCount == 0 && assignedButtonCount == 0)
					{
						num = 1307812704;
						goto IL_001c;
					}
					return true;
					IL_0017:
					num = 1307812705;
					goto IL_001c;
					IL_001c:
					switch (num ^ 0x4DF3A360)
					{
					case 2:
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

			internal override Elements_Base elements_base => elements;

			internal override IList<Platform> variants_base => null;

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
				oPxnOfTdpeLnVurkGKoqTjdxxmn oPxnOfTdpeLnVurkGKoqTjdxxmn2 = new oPxnOfTdpeLnVurkGKoqTjdxxmn(-2);
				oPxnOfTdpeLnVurkGKoqTjdxxmn2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return oPxnOfTdpeLnVurkGKoqTjdxxmn2;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				RPptlundFnlhgIcEDMqASIVdwvP rPptlundFnlhgIcEDMqASIVdwvP = new RPptlundFnlhgIcEDMqASIVdwvP(-2);
				rPptlundFnlhgIcEDMqASIVdwvP.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return rPptlundFnlhgIcEDMqASIVdwvP;
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
					Axis current = default(Axis);
					while (true)
					{
						IL_0081:
						int num;
						int num2;
						if (!enumerator.MoveNext())
						{
							num = 904317374;
							num2 = num;
						}
						else
						{
							num = 904317375;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x35E6C9BC)
							{
							case 0:
								num = 904317375;
								continue;
							default:
								goto end_IL_0051;
							case 3:
								current = enumerator.Current;
								num = 904317373;
								continue;
							case 4:
								break;
							case 1:
								list.Add(current);
								num = 904317368;
								continue;
							case 2:
								goto end_IL_0051;
							}
							goto IL_0081;
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
					int num4;
					int num5;
					if (num3 < array.Length)
					{
						num4 = 904317374;
						num5 = num4;
					}
					else
					{
						num4 = 904317372;
						num5 = num4;
					}
					while (true)
					{
						switch (num4 ^ 0x35E6C9BC)
						{
						case 6:
							num4 = 904317374;
							continue;
						case 2:
							elementIdentifier = list[num3].elementIdentifier;
							num4 = 904317373;
							continue;
						case 7:
							array[num3] = identifiers[elementIdentifier].name;
							num4 = 904317375;
							continue;
						case 3:
							num3++;
							num4 = 904317368;
							continue;
						case 4:
							break;
						case 1:
							if (elementIdentifier >= 0)
							{
								int num6;
								if (elementIdentifier < identifiers.Length)
								{
									num4 = 904317371;
									num6 = num4;
								}
								else
								{
									num4 = 904317369;
									num6 = num4;
								}
								continue;
							}
							goto case 5;
						case 5:
							Logger.LogError("Element identifier index is out of bounds!");
							num4 = 904317375;
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
					return new string[0];
				}
				string[] array = new string[buttonCount];
				int num2 = default(int);
				int num3 = default(int);
				int elementIdentifier = default(int);
				while (true)
				{
					int num = -1661168064;
					while (true)
					{
						switch (num ^ -1661168062)
						{
						case 5:
							break;
						case 3:
							num2++;
							num = -1661168054;
							continue;
						case 9:
							if (num3 >= 0)
							{
								int num5;
								if (num3 >= identifiers.Length)
								{
									num = -1661168060;
									num5 = num;
								}
								else
								{
									num = -1661168058;
									num5 = num;
								}
								continue;
							}
							goto case 6;
						case 4:
							array[num2] = identifiers[num3].name;
							num = -1661168063;
							continue;
						case 8:
						{
							int num4;
							if (num2 >= buttonCount)
							{
								num = -1661168062;
								num4 = num;
							}
							else
							{
								num = -1661168061;
								num4 = num;
							}
							continue;
						}
						case 6:
							Logger.LogError("Element identifier index is out of bounds!");
							num = -1661168063;
							continue;
						case 7:
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num = -1661168053;
							continue;
						case 2:
							num2 = 0;
							num = -1661168054;
							continue;
						case 1:
							elementIdentifier = elements.buttons[num2].elementIdentifier;
							num = -1661168059;
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
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
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
				IEnumerator<Button> enumerator = IterateButtons().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Button current = enumerator.Current;
							int num2 = 660917235;
							while (true)
							{
								switch (num2 ^ 0x2764CBF0)
								{
								case 2:
									num2 = 660917236;
									continue;
								case 4:
									break;
								case 0:
									num++;
									num2 = 660917233;
									continue;
								case 3:
									buttons[num] = current.elementIdentifier;
									num2 = 660917232;
									continue;
								default:
									goto end_IL_0050;
								}
								break;
							}
							continue;
							end_IL_0050:
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
							IL_0087:
							int num3 = 660917234;
							while (true)
							{
								switch (num3 ^ 0x2764CBF0)
								{
								case 0:
									break;
								default:
									goto end_IL_008c;
								case 2:
									goto IL_00a5;
								case 1:
									goto end_IL_008c;
								}
								goto IL_0087;
								IL_00a5:
								enumerator.Dispose();
								num3 = 660917233;
								continue;
								end_IL_008c:
								break;
							}
							break;
						}
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
							int num4 = 660917234;
							while (true)
							{
								switch (num4 ^ 0x2764CBF0)
								{
								case 0:
									num4 = 660917233;
									continue;
								case 1:
									break;
								default:
									goto end_IL_00e2;
								}
								break;
							}
							continue;
							end_IL_00e2:
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
					int num = 992548688;
					while (true)
					{
						switch (num ^ 0x3B29175B)
						{
						case 12:
							break;
						case 3:
						{
							ref AxisCalibrationData reference2 = ref array[num2];
							reference2 = AxisCalibrationData.Default;
							num = 992548689;
							continue;
						}
						case 5:
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num4;
								if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Hat)
								{
									num = 992548701;
									num4 = num;
								}
								else
								{
									num = 992548700;
									num4 = num;
								}
								continue;
							}
							goto case 6;
						case 7:
							throw new NotImplementedException();
						case 9:
							return null;
						case 8:
							num = 992548699;
							continue;
						case 6:
						{
							ref AxisCalibrationData reference = ref array[num2];
							reference = AxisCalibrationData.Default;
							num = 992548697;
							continue;
						}
						case 1:
							if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num3;
								if (axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									num = 992548702;
									num3 = num;
								}
								else
								{
									num = 992548696;
									num3 = num;
								}
								continue;
							}
							goto case 3;
						case 4:
							array[num2].min = axes_orig[num2].axisMin;
							array[num2].max = axes_orig[num2].axisMax;
							num = 992548697;
							continue;
						case 2:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, deepClone: true);
							num2++;
							num = 992548699;
							continue;
						case 11:
							if (axes_orig != null)
							{
								array = new AxisCalibrationData[axes_orig.Length];
								num2 = 0;
								num = 992548691;
							}
							else
							{
								num = 992548690;
							}
							continue;
						case 10:
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							if (Axes_orig[num2].calibrateAxis)
							{
								array[num2].zero = axes_orig[num2].axisZero;
								num = 992548703;
								continue;
							}
							goto case 2;
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
					int num = -1648912775;
					while (true)
					{
						switch (num ^ -1648912776)
						{
						case 8:
							break;
						case 2:
							throw new Exception();
						case 11:
							num = -1648912770;
							continue;
						case 7:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, createIfNull: true);
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num4;
								if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Custom)
								{
									num = -1648912773;
									num4 = num;
								}
								else
								{
									num = -1648912782;
									num4 = num;
								}
								continue;
							}
							goto case 3;
						case 5:
							axisRanges[num2] = AxisRange.Full;
							num = -1648912781;
							continue;
						case 0:
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = -1648912772;
							continue;
						case 1:
							axisInfos = null;
							if (Axes_orig == null)
							{
								return;
							}
							goto case 9;
						case 6:
							num2++;
							num = -1648912772;
							continue;
						case 9:
							axisRanges = new AxisRange[Axes_orig.Length];
							num = -1648912776;
							continue;
						case 3:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -1648912770;
							continue;
						case 10:
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num3;
								if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Hat)
								{
									num = -1648912774;
									num3 = num;
								}
								else
								{
									num = -1648912771;
									num3 = num;
								}
								continue;
							}
							goto case 5;
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
				while (true)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					int num = 0;
					int num2 = -67164028;
					while (true)
					{
						switch (num2 ^ -67164026)
						{
						case 4:
							num2 = -67164027;
							continue;
						case 3:
							break;
						case 2:
							num2 = -67164026;
							continue;
						case 5:
							num++;
							num2 = -67164026;
							continue;
						case 1:
							buttonInfos[num] = MiscTools.DeepClone(Buttons_orig[num].buttonInfo, createIfNull: true);
							num2 = -67164029;
							continue;
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
				while (true)
				{
					int num = -1698069477;
					while (true)
					{
						switch (num ^ -1698069480)
						{
						case 0:
							break;
						default:
							return;
						case 3:
							if (platform_OSX_Base != null)
							{
								goto IL_0034;
							}
							return;
						case 1:
							goto IL_0034;
						case 2:
							return;
						}
						break;
						IL_0034:
						platform_OSX_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
						platform_OSX_Base.elements = MiscTools.DeepClone(elements);
						num = -1698069478;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_OSX : Platform_OSX_Base
		{
			public Platform_OSX_Base[] variants;

			internal override IList<Platform> variants_base => variants;

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
					num2 = 395472881;
					goto IL_0012;
				}
				goto IL_00aa;
				IL_0012:
				while (true)
				{
					switch (num2 ^ 0x17926FF2)
					{
					case 2:
						break;
					case 4:
						return true;
					case 6:
						goto IL_004e;
					case 3:
						goto IL_005f;
					case 5:
						return true;
					case 1:
						goto IL_0088;
					default:
						goto IL_00aa;
					}
					break;
					IL_0088:
					if (variants[num].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = num;
						num2 = 395472887;
						continue;
					}
					goto IL_007d;
					IL_007d:
					num++;
					num2 = 395472881;
					continue;
					IL_005f:
					int num3;
					if (num < variants.Length)
					{
						num2 = 395472884;
						num3 = num2;
					}
					else
					{
						num2 = 395472882;
						num3 = num2;
					}
					continue;
					IL_004e:
					if (variants[num] != null)
					{
						num2 = 395472883;
						continue;
					}
					goto IL_007d;
				}
				goto IL_000d;
				IL_00aa:
				return false;
				IL_000d:
				num2 = 395472886;
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
				if (platform_OSX == null)
				{
					while (true)
					{
						switch (0x40FEC40E ^ 0x40FEC40C)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
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
						dRRcHzjfmpPQmjfIpMUExpcDkuyC(elementCount);
						return elementCount;
					}

					internal override void dRRcHzjfmpPQmjfIpMUExpcDkuyC(ElementCount_Base P_0)
					{
						base.dRRcHzjfmpPQmjfIpMUExpcDkuyC(P_0);
						ElementCount elementCount = default(ElementCount);
						while (true)
						{
							int num = 1482547627;
							while (true)
							{
								switch (num ^ 0x585DE1AA)
								{
								case 3:
									break;
								case 1:
								{
									elementCount = P_0 as ElementCount;
									int num2;
									if (elementCount == null)
									{
										num = 1482547624;
										num2 = num;
									}
									else
									{
										num = 1482547626;
										num2 = num;
									}
									continue;
								}
								case 2:
									return;
								default:
									elementCount.hatCount = hatCount;
									return;
								}
								break;
							}
						}
					}

					internal override bool YfzaYuFFeAGpZYIlhOCKodCcBwd(BridgedControllerHWInfo P_0)
					{
						if (!base.YfzaYuFFeAGpZYIlhOCKodCcBwd(P_0))
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
					goto IL_003c;
					IL_0008:
					int num = 387779333;
					goto IL_000d;
					IL_000d:
					switch (num ^ 0x171D0B06)
					{
					case 0:
						break;
					case 3:
						goto IL_002a;
					case 2:
						return false;
					default:
						goto IL_0095;
					}
					goto IL_0008;
					IL_0095:
					return true;
					IL_002a:
					if (hasData && isAllowed)
					{
						return true;
					}
					goto IL_003c;
					IL_003c:
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						num = 387779332;
						goto IL_000d;
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
								num = 387779335;
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
						goto IL_000a;
					}
					int num;
					if (alternateMatched)
					{
						num = -1484813037;
						goto IL_000f;
					}
					if (hatCount >= 0)
					{
						return bridgedControllerHWInfo.hardwareHatCount == hatCount;
					}
					return true;
					IL_000f:
					switch (num ^ -1484813039)
					{
					case 0:
						break;
					case 1:
						return false;
					default:
						return true;
					}
					goto IL_000a;
					IL_000a:
					num = -1484813040;
					goto IL_000f;
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
						num2 = -1440697736;
						goto IL_0010;
					}
					goto IL_0053;
					IL_0010:
					while (true)
					{
						switch (num2 ^ -1440697733)
						{
						case 2:
							break;
						case 0:
							goto IL_0035;
						case 3:
							num2 = -1440697733;
							continue;
						case 5:
							goto IL_0053;
						case 4:
							goto IL_0065;
						default:
							return false;
						}
						break;
						IL_0065:
						if (!string.IsNullOrEmpty(names[num]) && MatchingCriteria_Base.StringMatches(searchIn, names[num], useRegex))
						{
							return true;
						}
						num++;
						num2 = -1440697733;
						continue;
						IL_0035:
						int num3;
						if (num < names.Length)
						{
							num2 = -1440697729;
							num3 = num2;
						}
						else
						{
							num2 = -1440697734;
							num3 = num2;
						}
					}
					goto IL_000b;
					IL_0053:
					return false;
					IL_000b:
					num2 = -1440697730;
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
					goto IL_006c;
					IL_0011:
					int num = -1712557701;
					goto IL_0016;
					IL_0016:
					while (true)
					{
						switch (num ^ -1712557697)
						{
						case 2:
							break;
						case 0:
							matchingCriteria.systemName_useRegex = systemName_useRegex;
							matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
							matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
							num = -1712557698;
							continue;
						case 3:
							goto IL_006c;
						case 4:
							return;
						default:
							matchingCriteria.systemName = ArrayTools.ShallowCopy(systemName);
							matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
							return;
						}
						break;
					}
					goto IL_0011;
					IL_006c:
					matchingCriteria.hatCount = hatCount;
					matchingCriteria.manufacturer_useRegex = manufacturer_useRegex;
					matchingCriteria.productName_useRegex = productName_useRegex;
					num = -1712557697;
					goto IL_0016;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class LrMUYjOdtyJduuadgekXbubLoLu : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
				{
					private Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public Elements syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public int fcNIAReLyEovyoOSdMkpeRsWvuw;

					Axis IEnumerator<Axis>.Current
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
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							goto IL_0023;
						}
						goto IL_0070;
						IL_0028:
						int num;
						LrMUYjOdtyJduuadgekXbubLoLu lrMUYjOdtyJduuadgekXbubLoLu = default(LrMUYjOdtyJduuadgekXbubLoLu);
						while (true)
						{
							switch (num ^ 0x69101866)
							{
							case 3:
								break;
							case 5:
								lrMUYjOdtyJduuadgekXbubLoLu.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
								num = 1762662500;
								continue;
							case 1:
								num = 1762662500;
								continue;
							case 4:
								lrMUYjOdtyJduuadgekXbubLoLu = this;
								num = 1762662503;
								continue;
							case 0:
								goto IL_0070;
							default:
								return lrMUYjOdtyJduuadgekXbubLoLu;
							}
							break;
						}
						goto IL_0023;
						IL_0070:
						lrMUYjOdtyJduuadgekXbubLoLu = new LrMUYjOdtyJduuadgekXbubLoLu(0);
						num = 1762662499;
						goto IL_0028;
						IL_0023:
						num = 1762662498;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							fcNIAReLyEovyoOSdMkpeRsWvuw++;
							num = 399454549;
							goto IL_001f;
						case 0:
							{
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								int num3;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.axes == null)
								{
									num = 399454550;
									num3 = num;
								}
								else
								{
									num = 399454548;
									num3 = num;
								}
								goto IL_001f;
							}
							IL_001f:
							while (true)
							{
								switch (num ^ 0x17CF3155)
								{
								case 4:
									num = 399454544;
									continue;
								case 2:
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.axes[fcNIAReLyEovyoOSdMkpeRsWvuw];
									isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
									return true;
								case 0:
									break;
								case 5:
									goto end_IL_001f;
								case 1:
									fcNIAReLyEovyoOSdMkpeRsWvuw = 0;
									num = 399454549;
									continue;
								default:
									goto end_IL_0008;
								}
								int num2;
								if (fcNIAReLyEovyoOSdMkpeRsWvuw >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.axes.Length)
								{
									num = 399454550;
									num2 = num;
								}
								else
								{
									num = 399454551;
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
					public LrMUYjOdtyJduuadgekXbubLoLu(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class dzEbOwbHcbcPdjNEhTJLLPRsWZhb : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
				{
					private Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public Elements syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public int DeBhIRAlcwUUiLdLcbaJgRuyjKv;

					Button IEnumerator<Button>.Current
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
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						dzEbOwbHcbcPdjNEhTJLLPRsWZhb dzEbOwbHcbcPdjNEhTJLLPRsWZhb2;
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							dzEbOwbHcbcPdjNEhTJLLPRsWZhb2 = this;
						}
						else
						{
							while (true)
							{
								dzEbOwbHcbcPdjNEhTJLLPRsWZhb2 = new dzEbOwbHcbcPdjNEhTJLLPRsWZhb(0);
								int num = 1551030646;
								while (true)
								{
									switch (num ^ 0x5C72D977)
									{
									case 0:
										num = 1551030645;
										continue;
									case 2:
										break;
									case 1:
										dzEbOwbHcbcPdjNEhTJLLPRsWZhb2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
										num = 1551030644;
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
						return dzEbOwbHcbcPdjNEhTJLLPRsWZhb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						int num;
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 0:
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							int num2;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttons == null)
							{
								num = 539826563;
								num2 = num;
							}
							else
							{
								num = 539826565;
								num2 = num;
							}
							goto IL_001f;
						}
						case 1:
							{
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								DeBhIRAlcwUUiLdLcbaJgRuyjKv++;
								num = 539826564;
								goto IL_001f;
							}
							IL_001f:
							while (true)
							{
								switch (num ^ 0x202D1981)
								{
								case 3:
									num = 539826560;
									continue;
								case 1:
									break;
								case 0:
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttons[DeBhIRAlcwUUiLdLcbaJgRuyjKv];
									isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
									return true;
								case 5:
									goto IL_00ac;
								case 4:
									DeBhIRAlcwUUiLdLcbaJgRuyjKv = 0;
									num = 539826564;
									continue;
								default:
									goto end_IL_0008;
								}
								break;
								IL_00ac:
								int num3;
								if (DeBhIRAlcwUUiLdLcbaJgRuyjKv >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttons.Length)
								{
									num = 539826563;
									num3 = num;
								}
								else
								{
									num = 539826561;
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
					public dzEbOwbHcbcPdjNEhTJLLPRsWZhb(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
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
						LrMUYjOdtyJduuadgekXbubLoLu lrMUYjOdtyJduuadgekXbubLoLu = new LrMUYjOdtyJduuadgekXbubLoLu(-2);
						while (true)
						{
							int num = 1751688655;
							while (true)
							{
								switch (num ^ 0x6868A5CE)
								{
								case 2:
									break;
								case 1:
									goto IL_0026;
								default:
									return lrMUYjOdtyJduuadgekXbubLoLu;
								}
								break;
								IL_0026:
								lrMUYjOdtyJduuadgekXbubLoLu.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
								num = 1751688654;
							}
						}
					}
				}

				internal IEnumerable<Button> Buttons
				{
					get
					{
						dzEbOwbHcbcPdjNEhTJLLPRsWZhb dzEbOwbHcbcPdjNEhTJLLPRsWZhb2 = new dzEbOwbHcbcPdjNEhTJLLPRsWZhb(-2);
						dzEbOwbHcbcPdjNEhTJLLPRsWZhb2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
						return dzEbOwbHcbcPdjNEhTJLLPRsWZhb2;
					}
				}

				internal Axis GetAxis(int axisIndex)
				{
					if (axes != null && axisIndex >= 0)
					{
						while (true)
						{
							int num = 1035985473;
							while (true)
							{
								switch (num ^ 0x3DBFE240)
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
									num = 1035985472;
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
							num3 = -1877470039;
							goto IL_0009;
						}
						goto IL_005e;
						IL_0009:
						while (true)
						{
							switch (num3 ^ -1877470040)
							{
							case 6:
								num3 = -1877470037;
								continue;
							case 1:
								break;
							case 2:
								goto end_IL_0009;
							case 3:
								goto IL_005e;
							case 4:
								return ControllerElementType.Button;
							case 5:
								goto IL_0090;
							default:
								return elementIdentifier.elementType;
							}
							int num4;
							if (num2 >= buttonCount)
							{
								num3 = -1877470040;
								num4 = num3;
							}
							else
							{
								num3 = -1877470035;
								num4 = num3;
							}
							continue;
							IL_0090:
							if (buttons[num2].elementIdentifier != elementIdentifier.id)
							{
								num2++;
								num3 = -1877470039;
							}
							else
							{
								num3 = -1877470036;
							}
							continue;
							end_IL_0009:
							break;
						}
						continue;
						IL_005e:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							break;
						}
						num++;
						num3 = -1877470038;
						goto IL_0009;
					}
					return ControllerElementType.Axis;
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
							num2 = -1469330558;
							num3 = num2;
						}
						else
						{
							num2 = -1469330556;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -1469330556)
							{
							case 9:
								num2 = -1469330558;
								continue;
							case 6:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									sourceType = axes[num].sourceType;
									num2 = -1469330560;
									continue;
								}
								goto case 7;
							case 1:
								if (sourceType == HardwareElementSourceTypeWithHat.Custom)
								{
									num2 = -1469330554;
									continue;
								}
								throw new NotImplementedException();
							case 5:
								return true;
							case 8:
								return true;
							case 7:
								num++;
								num2 = -1469330553;
								continue;
							case 2:
								goto IL_00cf;
							case 3:
								break;
							case 4:
								switch (sourceType)
								{
								case HardwareElementSourceTypeWithHat.Button:
									axisRange = AxisRange.Positive;
									return true;
								case HardwareElementSourceTypeWithHat.Hat:
									break;
								case HardwareElementSourceTypeWithHat.Axis:
									goto IL_00cf;
								default:
									goto IL_012f;
								}
								axisRange = axes[num].sourceHatRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -1469330559;
									continue;
								}
								goto case 5;
							default:
								{
									axisRange = AxisRange.Full;
									return false;
								}
								IL_012f:
								num2 = -1469330555;
								continue;
								IL_00cf:
								axisRange = axes[num].sourceAxisRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -1469330548;
									continue;
								}
								goto case 8;
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
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
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
					Button button = default(Button);
					while (true)
					{
						int num = -731852011;
						while (true)
						{
							switch (num ^ -731852003)
							{
							case 4:
								break;
							case 8:
							{
								button = source as Button;
								int num2;
								if (button == null)
								{
									num = -731852012;
									num2 = num;
								}
								else
								{
									num = -731852003;
									num2 = num;
								}
								continue;
							}
							case 6:
								sourceAxis = button.sourceAxis;
								sourceAxisPole = button.sourceAxisPole;
								axisDeadZone = button.axisDeadZone;
								num = -731852006;
								continue;
							case 7:
								sourceHat = button.sourceHat;
								num = -731852001;
								continue;
							case 0:
								elementIdentifier = button.elementIdentifier;
								num = -731852002;
								continue;
							case 2:
								sourceHatType = button.sourceHatType;
								num = -731852008;
								continue;
							case 9:
								return;
							case 5:
								sourceHatDirection = button.sourceHatDirection;
								requireMultipleButtons = button.requireMultipleButtons;
								requiredButtons = ArrayTools.ShallowCopy(button.requiredButtons);
								ignoreIfButtonsActive = button.ignoreIfButtonsActive;
								ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(button.ignoreIfButtonsActiveButtons);
								num = -731852004;
								continue;
							case 3:
								sourceType = button.sourceType;
								sourceButton = button.sourceButton;
								num = -731852005;
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
					while (true)
					{
						int num = 1487326097;
						while (true)
						{
							switch (num ^ 0x58A6CB92)
							{
							case 0:
								break;
							case 5:
								sourceButton = axis.sourceButton;
								num = 1487326096;
								continue;
							case 1:
								calibrateAxis = axis.calibrateAxis;
								axisZero = axis.axisZero;
								axisMin = axis.axisMin;
								axisMax = axis.axisMax;
								axisInfo = MiscTools.DeepClone(axis.axisInfo);
								num = 1487326103;
								continue;
							case 4:
								elementIdentifier = axis.elementIdentifier;
								sourceType = axis.sourceType;
								sourceAxis = axis.sourceAxis;
								sourceAxisRange = axis.sourceAxisRange;
								invert = axis.invert;
								axisDeadZone = axis.axisDeadZone;
								num = 1487326099;
								continue;
							case 3:
								if (axis == null)
								{
									return;
								}
								goto case 4;
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
					}
				}
			}

			private sealed class DGQjwxAWKTiFtbKIHtzhtGBOaun : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_Linux_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int NItMHStqaUtemRaFhOTlMgUFWgS;

				public int BiZINFHUIdvpCnoRygOVbVRUeOQW;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						goto IL_001c;
					}
					goto IL_004e;
					IL_004e:
					DGQjwxAWKTiFtbKIHtzhtGBOaun dGQjwxAWKTiFtbKIHtzhtGBOaun = new DGQjwxAWKTiFtbKIHtzhtGBOaun(0);
					dGQjwxAWKTiFtbKIHtzhtGBOaun.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					int num = -1835886713;
					goto IL_0021;
					IL_001c:
					num = -1835886715;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ -1835886714)
						{
						case 0:
							break;
						case 3:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							dGQjwxAWKTiFtbKIHtzhtGBOaun = this;
							num = -1835886713;
							continue;
						case 2:
							goto IL_004e;
						default:
							return dGQjwxAWKTiFtbKIHtzhtGBOaun;
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
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = 729995358;
						while (true)
						{
							switch (num2 ^ 0x2B82D85C)
							{
							case 0:
								break;
							case 6:
								NItMHStqaUtemRaFhOTlMgUFWgS = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes.Length;
								BiZINFHUIdvpCnoRygOVbVRUeOQW = 0;
								num2 = 729995357;
								continue;
							case 5:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes[BiZINFHUIdvpCnoRygOVbVRUeOQW];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 2:
								switch (num)
								{
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									BiZINFHUIdvpCnoRygOVbVRUeOQW++;
									num2 = 729995357;
									continue;
								default:
									num2 = 729995355;
									continue;
								case 0:
									break;
								}
								goto case 3;
							case 4:
							{
								int num5;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes != null)
								{
									num2 = 729995354;
									num5 = num2;
								}
								else
								{
									num2 = 729995355;
									num5 = num2;
								}
								continue;
							}
							case 1:
							{
								int num3;
								if (BiZINFHUIdvpCnoRygOVbVRUeOQW >= NItMHStqaUtemRaFhOTlMgUFWgS)
								{
									num2 = 729995355;
									num3 = num2;
								}
								else
								{
									num2 = 729995353;
									num3 = num2;
								}
								continue;
							}
							case 3:
							{
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								int num4;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null)
								{
									num2 = 729995352;
									num4 = num2;
								}
								else
								{
									num2 = 729995355;
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
				public DGQjwxAWKTiFtbKIHtzhtGBOaun(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class uTmcqjaOkiuetZzuQErhXIhcOWY : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_Linux_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int kkjMWgEdESuFMfgNOFmPMfLoemN;

				public int klpTfExmcfnKIWaaLECVbsjxgFYk;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					uTmcqjaOkiuetZzuQErhXIhcOWY uTmcqjaOkiuetZzuQErhXIhcOWY2;
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						uTmcqjaOkiuetZzuQErhXIhcOWY2 = this;
					}
					else
					{
						while (true)
						{
							uTmcqjaOkiuetZzuQErhXIhcOWY2 = new uTmcqjaOkiuetZzuQErhXIhcOWY(0);
							uTmcqjaOkiuetZzuQErhXIhcOWY2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
							int num = -1340849506;
							while (true)
							{
								switch (num ^ -1340849505)
								{
								case 0:
									num = -1340849507;
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
					return uTmcqjaOkiuetZzuQErhXIhcOWY2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = 1640103761;
						while (true)
						{
							switch (num2 ^ 0x61C1FF57)
							{
							case 0:
								break;
							case 4:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons[klpTfExmcfnKIWaaLECVbsjxgFYk];
								num2 = 1640103765;
								continue;
							case 1:
							{
								int num3;
								if (klpTfExmcfnKIWaaLECVbsjxgFYk >= kkjMWgEdESuFMfgNOFmPMfLoemN)
								{
									num2 = 1640103762;
									num3 = num2;
								}
								else
								{
									num2 = 1640103763;
									num3 = num2;
								}
								continue;
							}
							case 6:
								switch (num)
								{
								default:
									num2 = 1640103775;
									continue;
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									klpTfExmcfnKIWaaLECVbsjxgFYk++;
									num2 = 1640103766;
									continue;
								case 0:
									break;
								}
								goto case 7;
							case 3:
								num2 = 1640103766;
								continue;
							case 2:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 7:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null && syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons != null)
								{
									kkjMWgEdESuFMfgNOFmPMfLoemN = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons.Length;
									klpTfExmcfnKIWaaLECVbsjxgFYk = 0;
									num2 = 1640103764;
									continue;
								}
								goto default;
							case 8:
								num2 = 1640103762;
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
				public uTmcqjaOkiuetZzuQErhXIhcOWY(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform => InputPlatform.LpFemRBnLvpZJDqbCUqPHDmhIPES;

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

			internal override IList<Platform> variants_base => null;

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

			internal override Elements_Base elements_base => elements;

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
					goto IL_0012;
				}
				string[] array = new string[elements.axisCount];
				int num2 = array.Length;
				int num3 = 0;
				int num4 = -278221409;
				goto IL_0017;
				IL_0017:
				int num5 = default(int);
				while (true)
				{
					switch (num4 ^ -278221410)
					{
					case 9:
						break;
					case 8:
					{
						int num7;
						if (num5 < num)
						{
							num4 = -278221410;
							num7 = num4;
						}
						else
						{
							num4 = -278221415;
							num7 = num4;
						}
						continue;
					}
					case 5:
						return new string[0];
					case 0:
						array[num3] = identifiers[num5].name;
						num4 = -278221416;
						continue;
					case 1:
					{
						int num8;
						if (num3 >= num2)
						{
							num4 = -278221412;
							num8 = num4;
						}
						else
						{
							num4 = -278221414;
							num8 = num4;
						}
						continue;
					}
					case 3:
						Logger.LogError("You have too few element identifiers!");
						num4 = -278221413;
						continue;
					case 6:
						num3++;
						num4 = -278221409;
						continue;
					case 7:
						Logger.LogError("Element identifier index is out of bounds!");
						num4 = -278221416;
						continue;
					case 4:
					{
						int elementIdentifier = elements.axes[num3].elementIdentifier;
						num5 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						int num6;
						if (num5 >= 0)
						{
							num4 = -278221418;
							num6 = num4;
						}
						else
						{
							num4 = -278221415;
							num6 = num4;
						}
						continue;
					}
					default:
						return array;
					}
					break;
				}
				goto IL_0012;
				IL_0012:
				num4 = -278221411;
				goto IL_0017;
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
				int num5 = default(int);
				while (true)
				{
					int num3;
					int num4;
					if (num2 < buttonCount)
					{
						num3 = 136845050;
						num4 = num3;
					}
					else
					{
						num3 = 136845046;
						num4 = num3;
					}
					while (true)
					{
						switch (num3 ^ 0x82816FE)
						{
						case 0:
							num3 = 136845050;
							continue;
						case 4:
						{
							int elementIdentifier = elements.buttons[num2].elementIdentifier;
							num5 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num3 = 136845049;
							continue;
						}
						case 5:
							num2++;
							num3 = 136845048;
							continue;
						case 1:
							array[num2] = identifiers[num5].name;
							num3 = 136845051;
							continue;
						case 7:
						{
							int num7;
							if (num5 < 0)
							{
								num3 = 136845052;
								num7 = num3;
							}
							else
							{
								num3 = 136845053;
								num7 = num3;
							}
							continue;
						}
						case 3:
						{
							int num6;
							if (num5 >= num)
							{
								num3 = 136845052;
								num6 = num3;
							}
							else
							{
								num3 = 136845055;
								num6 = num3;
							}
							continue;
						}
						case 2:
							Logger.LogError("Element identifier index is out of bounds!");
							num3 = 136845051;
							continue;
						case 6:
							break;
						default:
							return array;
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
							int num = -53608340;
							while (true)
							{
								switch (num ^ -53608340)
								{
								case 3:
									num = -53608339;
									continue;
								case 1:
									break;
								case 0:
									if (current.elementIdentifier != elementIdentifierId)
									{
										goto end_IL_0030;
									}
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
				finally
				{
					if (enumerator != null)
					{
						while (true)
						{
							IL_0062:
							int num2 = -53608339;
							while (true)
							{
								switch (num2 ^ -53608340)
								{
								case 0:
									break;
								default:
									goto end_IL_0067;
								case 1:
									goto IL_0080;
								case 2:
									goto end_IL_0067;
								}
								goto IL_0062;
								IL_0080:
								enumerator.Dispose();
								num2 = -53608338;
								continue;
								end_IL_0067:
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
							int num3;
							int num4;
							if (current2.elementIdentifier != elementIdentifierId)
							{
								num3 = -53608339;
								num4 = num3;
							}
							else
							{
								num3 = -53608338;
								num4 = num3;
							}
							while (true)
							{
								switch (num3 ^ -53608340)
								{
								case 0:
									num3 = -53608344;
									continue;
								case 2:
									result = true;
									num3 = -53608337;
									continue;
								case 4:
									break;
								default:
									goto end_IL_00d5;
								case 3:
									goto IL_0110;
								}
								break;
							}
							continue;
							end_IL_00d5:
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
					while (true)
					{
						IL_0068:
						int num2;
						int num3;
						if (enumerator.MoveNext())
						{
							num2 = -227905100;
							num3 = num2;
						}
						else
						{
							num2 = -227905098;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -227905098)
							{
							case 3:
								num2 = -227905100;
								continue;
							default:
								goto end_IL_002f;
							case 2:
							{
								Button current = enumerator.Current;
								buttons[num] = current.elementIdentifier;
								num++;
								num2 = -227905097;
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
							int num4 = -227905098;
							while (true)
							{
								switch (num4 ^ -227905098)
								{
								case 2:
									num4 = -227905099;
									continue;
								case 3:
									break;
								case 0:
									axes[num] = current2.elementIdentifier;
									num++;
									num4 = -227905097;
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
								num2 = -396041658;
								num3 = num2;
							}
							else
							{
								num2 = -396041664;
								num3 = num2;
							}
							goto IL_0021;
						}
						goto IL_0089;
						IL_0021:
						while (true)
						{
							switch (num2 ^ -396041661)
							{
							case 6:
								num2 = -396041663;
								continue;
							case 2:
								break;
							case 5:
								goto IL_0089;
							case 11:
								array[num].deadZone = axes_orig[num].axisDeadZone;
								num2 = -396041660;
								continue;
							case 10:
								throw new NotImplementedException();
							case 8:
								array[num].min = axes_orig[num].axisMin;
								array[num].max = axes_orig[num].axisMax;
								num2 = -396041661;
								continue;
							case 0:
								array[num].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num].alternateCalibrations, deepClone: true);
								num++;
								num2 = -396041654;
								continue;
							case 7:
								if (Axes_orig[num].calibrateAxis)
								{
									array[num].zero = axes_orig[num].axisZero;
									num2 = -396041653;
									continue;
								}
								goto case 0;
							case 4:
							{
								ref AxisCalibrationData reference = ref array[num];
								reference = AxisCalibrationData.Default;
								num2 = -396041661;
								continue;
							}
							case 3:
								goto IL_0188;
							case 1:
								goto IL_01a6;
							default:
								goto end_IL_0061;
							}
							break;
							IL_01a6:
							int num4;
							if (axes_orig[num].sourceType == HardwareElementSourceTypeWithHat.Hat)
							{
								num2 = -396041657;
								num4 = num2;
							}
							else
							{
								num2 = -396041655;
								num4 = num2;
							}
							continue;
							IL_0188:
							int num5;
							if (axes_orig[num].sourceType == HardwareElementSourceTypeWithHat.Button)
							{
								num2 = -396041657;
								num5 = num2;
							}
							else
							{
								num2 = -396041662;
								num5 = num2;
							}
						}
						continue;
						IL_0089:
						ref AxisCalibrationData reference2 = ref array[num];
						reference2 = AxisCalibrationData.Default;
						array[num].invert = axes_orig[num].invert;
						num2 = -396041656;
						goto IL_0021;
						continue;
						end_IL_0061:
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
					int num = 971185053;
					while (true)
					{
						switch (num ^ 0x39E31B9C)
						{
						case 6:
							break;
						default:
							return;
						case 2:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = 971185045;
							continue;
						case 0:
							throw new Exception();
						case 3:
							axisRanges[num2] = AxisRange.Full;
							num = 971185048;
							continue;
						case 12:
						{
							int num5;
							if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Hat)
							{
								num = 971185055;
								num5 = num;
							}
							else
							{
								num = 971185052;
								num5 = num;
							}
							continue;
						}
						case 4:
							num = 971185045;
							continue;
						case 8:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, createIfNull: true);
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num6;
								if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									num = 971185047;
									num6 = num;
								}
								else
								{
									num = 971185054;
									num6 = num;
								}
								continue;
							}
							goto case 2;
						case 11:
						{
							int num4;
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								num = 971185040;
								num4 = num;
							}
							else
							{
								num = 971185055;
								num4 = num;
							}
							continue;
						}
						case 5:
						{
							int num3;
							if (num2 >= Axes_orig.Length)
							{
								num = 971185051;
								num3 = num;
							}
							else
							{
								num = 971185044;
								num3 = num;
							}
							continue;
						}
						case 10:
							axisRanges = new AxisRange[Axes_orig.Length];
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = 971185049;
							continue;
						case 1:
							if (Axes_orig == null)
							{
								return;
							}
							goto case 10;
						case 9:
							num2++;
							num = 971185049;
							continue;
						case 7:
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
					int num2 = -326415768;
					while (true)
					{
						switch (num2 ^ -326415768)
						{
						case 3:
							num2 = -326415766;
							continue;
						case 2:
							break;
						case 1:
							buttonInfos[num] = MiscTools.DeepClone(Buttons_orig[num].buttonInfo, createIfNull: true);
							num++;
							num2 = -326415768;
							continue;
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

			internal IEnumerable<Axis> IterateAxes()
			{
				DGQjwxAWKTiFtbKIHtzhtGBOaun dGQjwxAWKTiFtbKIHtzhtGBOaun = new DGQjwxAWKTiFtbKIHtzhtGBOaun(-2);
				dGQjwxAWKTiFtbKIHtzhtGBOaun.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return dGQjwxAWKTiFtbKIHtzhtGBOaun;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				uTmcqjaOkiuetZzuQErhXIhcOWY uTmcqjaOkiuetZzuQErhXIhcOWY2 = new uTmcqjaOkiuetZzuQErhXIhcOWY(-2);
				uTmcqjaOkiuetZzuQErhXIhcOWY2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return uTmcqjaOkiuetZzuQErhXIhcOWY2;
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
				while (true)
				{
					int num = 309093720;
					while (true)
					{
						switch (num ^ 0x126C6559)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							if (platform_Linux_Base != null)
							{
								goto IL_0034;
							}
							return;
						case 0:
							goto IL_0034;
						case 3:
							return;
						}
						break;
						IL_0034:
						platform_Linux_Base.elements = MiscTools.DeepClone(elements);
						num = 309093722;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_Linux : Platform_Linux_Base
		{
			public Platform_Linux_Base[] variants;

			internal override IList<Platform> variants_base => variants;

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
							num2 = -959634003;
							num3 = num2;
						}
						else
						{
							num2 = -959634008;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -959634004)
							{
							case 2:
								num2 = -959634003;
								continue;
							case 3:
								break;
							case 0:
								return true;
							case 1:
								goto IL_006a;
							default:
								goto end_IL_0041;
							}
							break;
							IL_006a:
							if (variants[num] == null || !variants[num].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
							{
								num++;
								num2 = -959634001;
							}
							else
							{
								variantIndex = num;
								num2 = -959634004;
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
					int num = -13554783;
					while (true)
					{
						switch (num ^ -13554781)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							if (platform_Linux != null)
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
						platform_Linux.variants = MiscTools.DeepClone(variants);
						num = -13554784;
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
						dRRcHzjfmpPQmjfIpMUExpcDkuyC(elementCount);
						return elementCount;
					}

					internal override void dRRcHzjfmpPQmjfIpMUExpcDkuyC(ElementCount_Base P_0)
					{
						base.dRRcHzjfmpPQmjfIpMUExpcDkuyC(P_0);
						ElementCount elementCount = default(ElementCount);
						while (true)
						{
							int num = 1766625048;
							while (true)
							{
								switch (num ^ 0x694C8F19)
								{
								case 0:
									break;
								case 1:
								{
									elementCount = P_0 as ElementCount;
									int num2;
									if (elementCount != null)
									{
										num = 1766625050;
										num2 = num;
									}
									else
									{
										num = 1766625051;
										num2 = num;
									}
									continue;
								}
								case 2:
									return;
								default:
									elementCount.hatCount = hatCount;
									return;
								}
								break;
							}
						}
					}

					internal override bool YfzaYuFFeAGpZYIlhOCKodCcBwd(BridgedControllerHWInfo P_0)
					{
						if (!base.YfzaYuFFeAGpZYIlhOCKodCcBwd(P_0))
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
							goto IL_0008;
						}
						int num;
						if (productGUID != null)
						{
							num = -30929294;
							goto IL_000d;
						}
						goto IL_0048;
						IL_0048:
						if (productName != null && productName.Length > 0)
						{
							num = -30929293;
							goto IL_000d;
						}
						return false;
						IL_003b:
						if (productGUID.Length > 0)
						{
							return true;
						}
						goto IL_0048;
						IL_0008:
						num = -30929295;
						goto IL_000d;
						IL_000d:
						switch (num ^ -30929296)
						{
						case 0:
							break;
						case 1:
							return false;
						case 2:
							goto IL_003b;
						default:
							return true;
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
					goto IL_0040;
					IL_0008:
					int num = -1407753799;
					goto IL_000d;
					IL_000d:
					while (true)
					{
						switch (num ^ -1407753795)
						{
						case 2:
							break;
						case 4:
							goto IL_002e;
						case 0:
							return false;
						case 3:
							goto IL_0099;
						default:
							return true;
						}
						break;
						IL_0099:
						if (productName.Length == 0)
						{
							num = -1407753796;
							continue;
						}
						goto IL_00af;
					}
					goto IL_0008;
					IL_00af:
					if (!AnyNameMatches(bridgedControllerHWInfo))
					{
						return false;
					}
					return true;
					IL_002e:
					if (hasData && isAllowed)
					{
						return true;
					}
					goto IL_0040;
					IL_0040:
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						num = -1407753795;
					}
					else
					{
						if (!strictMatch)
						{
							return AnyNameMatches(bridgedControllerHWInfo);
						}
						if (!PidVid.ArrayContains(productGUID, ref bridgedControllerHWInfo.hw_pidVid))
						{
							goto IL_00af;
						}
						if (!ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
						{
							return true;
						}
						int num2;
						if (productName != null)
						{
							num = -1407753794;
							num2 = num;
						}
						else
						{
							num = -1407753796;
							num2 = num;
						}
					}
					goto IL_000d;
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
					int num;
					if (!string.IsNullOrEmpty(name))
					{
						if (names == null)
						{
							goto IL_000b;
						}
						searchIn = name.Trim();
						num = 749225915;
						goto IL_0010;
					}
					goto IL_0031;
					IL_0010:
					int num2 = default(int);
					while (true)
					{
						switch (num ^ 0x2CA847BF)
						{
						case 0:
							break;
						case 3:
							goto IL_0031;
						case 4:
							num2 = 0;
							num = 749225918;
							continue;
						case 2:
							goto IL_004a;
						default:
							if (num2 >= names.Length)
							{
								return false;
							}
							goto IL_004a;
						}
						break;
						IL_004a:
						if (!string.IsNullOrEmpty(names[num2]) && MatchingCriteria_Base.StringMatches(searchIn, names[num2], useRegex))
						{
							return true;
						}
						num2++;
						num = 749225918;
					}
					goto IL_000b;
					IL_0031:
					return false;
					IL_000b:
					num = 749225916;
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
					goto IL_003b;
					IL_0011:
					int num = 1845838853;
					goto IL_0016;
					IL_0016:
					switch (num ^ 0x6E054404)
					{
					case 0:
						break;
					case 1:
						return;
					case 2:
						goto IL_003b;
					default:
						matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
						return;
					}
					goto IL_0011;
					IL_003b:
					matchingCriteria.hatCount = hatCount;
					matchingCriteria.manufacturer_useRegex = manufacturer_useRegex;
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					num = 1845838855;
					goto IL_0016;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class xqDZGrNCiMGduKJrUghNZoTZWrSm : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
				{
					private Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public Elements syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public int chPicHTyjAUlRfUBqakElWUAZMt;

					Axis IEnumerator<Axis>.Current
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
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							goto IL_001c;
						}
						goto IL_0054;
						IL_0054:
						xqDZGrNCiMGduKJrUghNZoTZWrSm xqDZGrNCiMGduKJrUghNZoTZWrSm2 = new xqDZGrNCiMGduKJrUghNZoTZWrSm(0);
						int num = 659489152;
						goto IL_0021;
						IL_001c:
						num = 659489157;
						goto IL_0021;
						IL_0021:
						while (true)
						{
							switch (num ^ 0x274F0180)
							{
							case 4:
								break;
							case 5:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								num = 659489155;
								continue;
							case 2:
								goto IL_0054;
							case 0:
								xqDZGrNCiMGduKJrUghNZoTZWrSm2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
								num = 659489153;
								continue;
							case 3:
								xqDZGrNCiMGduKJrUghNZoTZWrSm2 = this;
								num = 659489153;
								continue;
							default:
								return xqDZGrNCiMGduKJrUghNZoTZWrSm2;
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
						int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
						while (true)
						{
							int num2 = -758048024;
							while (true)
							{
								switch (num2 ^ -758048020)
								{
								case 0:
									break;
								case 3:
									chPicHTyjAUlRfUBqakElWUAZMt++;
									num2 = -758048023;
									continue;
								case 2:
									isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
									return true;
								case 8:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.axes != null)
									{
										chPicHTyjAUlRfUBqakElWUAZMt = 0;
										num2 = -758048022;
										continue;
									}
									goto default;
								case 1:
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.axes[chPicHTyjAUlRfUBqakElWUAZMt];
									num2 = -758048018;
									continue;
								case 6:
									num2 = -758048023;
									continue;
								case 4:
									switch (num)
									{
									case 1:
										isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
										num2 = -758048017;
										continue;
									case 0:
										break;
									default:
										num2 = -758048021;
										continue;
									}
									goto case 8;
								case 5:
								{
									int num3;
									if (chPicHTyjAUlRfUBqakElWUAZMt >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.axes.Length)
									{
										num2 = -758048021;
										num3 = num2;
									}
									else
									{
										num2 = -758048019;
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
					public xqDZGrNCiMGduKJrUghNZoTZWrSm(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class TficHxPUOTxijqBsDPSiKYMueEY : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
				{
					private Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public Elements syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public int YLFGSKwOgGNuvWJhMHVGaqjsmHHd;

					Button IEnumerator<Button>.Current
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
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							goto IL_0023;
						}
						goto IL_004e;
						IL_0028:
						int num;
						TficHxPUOTxijqBsDPSiKYMueEY tficHxPUOTxijqBsDPSiKYMueEY = default(TficHxPUOTxijqBsDPSiKYMueEY);
						while (true)
						{
							switch (num ^ 0x1DD701D8)
							{
							case 0:
								break;
							case 1:
								tficHxPUOTxijqBsDPSiKYMueEY = this;
								num = 500629979;
								continue;
							case 2:
								goto IL_004e;
							default:
								return tficHxPUOTxijqBsDPSiKYMueEY;
							}
							break;
						}
						goto IL_0023;
						IL_004e:
						tficHxPUOTxijqBsDPSiKYMueEY = new TficHxPUOTxijqBsDPSiKYMueEY(0);
						tficHxPUOTxijqBsDPSiKYMueEY.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = 500629979;
						goto IL_0028;
						IL_0023:
						num = 500629977;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 0:
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							num = 154749294;
							goto IL_001f;
						case 1:
							{
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								YLFGSKwOgGNuvWJhMHVGaqjsmHHd++;
								num = 154749292;
								goto IL_001f;
							}
							IL_001f:
							while (true)
							{
								switch (num ^ 0x939496B)
								{
								case 3:
									num = 154749295;
									continue;
								case 1:
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttons[YLFGSKwOgGNuvWJhMHVGaqjsmHHd];
									num = 154749293;
									continue;
								case 0:
									YLFGSKwOgGNuvWJhMHVGaqjsmHHd = 0;
									num = 154749292;
									continue;
								case 7:
									break;
								case 4:
									goto end_IL_001f;
								case 5:
									goto IL_00b6;
								case 6:
									isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
									return true;
								default:
									goto end_IL_0008;
								}
								int num2;
								if (YLFGSKwOgGNuvWJhMHVGaqjsmHHd >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttons.Length)
								{
									num = 154749289;
									num2 = num;
								}
								else
								{
									num = 154749290;
									num2 = num;
								}
								continue;
								IL_00b6:
								int num3;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttons != null)
								{
									num = 154749291;
									num3 = num;
								}
								else
								{
									num = 154749289;
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
					public TficHxPUOTxijqBsDPSiKYMueEY(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
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
						xqDZGrNCiMGduKJrUghNZoTZWrSm xqDZGrNCiMGduKJrUghNZoTZWrSm2 = new xqDZGrNCiMGduKJrUghNZoTZWrSm(-2);
						xqDZGrNCiMGduKJrUghNZoTZWrSm2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
						return xqDZGrNCiMGduKJrUghNZoTZWrSm2;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					get
					{
						TficHxPUOTxijqBsDPSiKYMueEY tficHxPUOTxijqBsDPSiKYMueEY = new TficHxPUOTxijqBsDPSiKYMueEY(-2);
						tficHxPUOTxijqBsDPSiKYMueEY.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
						return tficHxPUOTxijqBsDPSiKYMueEY;
					}
				}

				internal Axis GetAxis(int axisIndex)
				{
					if (axes != null && axisIndex >= 0)
					{
						while (true)
						{
							int num = 369456638;
							while (true)
							{
								switch (num ^ 0x160575FF)
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
									num = 369456639;
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
							num3 = 1035558393;
							goto IL_0009;
						}
						goto IL_0097;
						IL_0009:
						while (true)
						{
							switch (num3 ^ 0x3DB95DF9)
							{
							case 6:
								num3 = 1035558395;
								continue;
							case 7:
								break;
							case 5:
								return ControllerElementType.Axis;
							case 3:
								goto IL_0058;
							case 4:
								goto IL_007a;
							case 2:
								goto IL_0097;
							case 0:
								num3 = 1035558397;
								continue;
							default:
								return elementIdentifier.elementType;
							}
							break;
							IL_007a:
							int num4;
							if (num2 < buttonCount)
							{
								num3 = 1035558394;
								num4 = num3;
							}
							else
							{
								num3 = 1035558392;
								num4 = num3;
							}
							continue;
							IL_0058:
							if (buttons[num2].elementIdentifier == elementIdentifier.id)
							{
								return ControllerElementType.Button;
							}
							num2++;
							num3 = 1035558397;
						}
						continue;
						IL_0097:
						if (axes[num].elementIdentifier != elementIdentifier.id)
						{
							num++;
							num3 = 1035558398;
						}
						else
						{
							num3 = 1035558396;
						}
						goto IL_0009;
					}
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					while (true)
					{
						IL_0048:
						int num2;
						if (num >= axisCount)
						{
							axisRange = AxisRange.Full;
							num2 = 772156606;
							goto IL_0009;
						}
						goto IL_00a5;
						IL_003d:
						num++;
						num2 = 772156603;
						goto IL_0009;
						IL_00a5:
						if (axes[num].elementIdentifier != elementIdentifier.id)
						{
							goto IL_003d;
						}
						switch (axes[num].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Axis:
							break;
						default:
							throw new NotImplementedException();
						case HardwareElementSourceTypeWithHat.Custom:
							goto IL_00df;
						case HardwareElementSourceTypeWithHat.Button:
							axisRange = AxisRange.Positive;
							return true;
						case HardwareElementSourceTypeWithHat.Hat:
							goto IL_00f0;
						}
						goto IL_005b;
						IL_0009:
						while (true)
						{
							switch (num2 ^ 0x2E062CBF)
							{
							case 0:
								num2 = 772156605;
								continue;
							case 8:
								break;
							case 4:
								goto IL_0048;
							case 7:
								goto IL_005b;
							case 3:
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 772156601;
									continue;
								}
								goto case 6;
							case 5:
								goto end_IL_0048;
							case 2:
								goto IL_00a5;
							case 6:
								return true;
							default:
								return false;
							}
							break;
						}
						goto IL_003d;
						IL_00f0:
						axisRange = axes[num].sourceHatRange;
						if (!axes[num].invert)
						{
							break;
						}
						axisRange = InputTools.InvertAxisRange(axisRange);
						num2 = 772156602;
						goto IL_0009;
						IL_005b:
						axisRange = axes[num].sourceAxisRange;
						num2 = 772156604;
						goto IL_0009;
						IL_00df:
						num2 = 772156600;
						goto IL_0009;
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
						switch (-1911136825 ^ -1911136826)
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
					Button button = default(Button);
					while (true)
					{
						int num = 1548488365;
						while (true)
						{
							switch (num ^ 0x5C4C0EA4)
							{
							case 2:
								break;
							default:
								return;
							case 7:
								buttonInfo = MiscTools.DeepClone(button.buttonInfo);
								num = 1548488359;
								continue;
							case 0:
								elementIdentifier = button.elementIdentifier;
								num = 1548488357;
								continue;
							case 1:
								sourceType = button.sourceType;
								num = 1548488353;
								continue;
							case 5:
								sourceButton = button.sourceButton;
								sourceAxis = button.sourceAxis;
								sourceAxisPole = button.sourceAxisPole;
								num = 1548488354;
								continue;
							case 8:
								ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(button.ignoreIfButtonsActiveButtons);
								num = 1548488355;
								continue;
							case 6:
								axisDeadZone = button.axisDeadZone;
								sourceHat = button.sourceHat;
								sourceHatType = button.sourceHatType;
								sourceHatDirection = button.sourceHatDirection;
								num = 1548488352;
								continue;
							case 9:
								button = source as Button;
								if (button == null)
								{
									return;
								}
								goto case 0;
							case 4:
								requireMultipleButtons = button.requireMultipleButtons;
								requiredButtons = ArrayTools.ShallowCopy(button.requiredButtons);
								ignoreIfButtonsActive = button.ignoreIfButtonsActive;
								num = 1548488364;
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
						int num = -226777354;
						while (true)
						{
							switch (num ^ -226777353)
							{
							case 2:
								break;
							default:
								return;
							case 4:
								sourceType = axis.sourceType;
								sourceAxis = axis.sourceAxis;
								sourceAxisRange = axis.sourceAxisRange;
								invert = axis.invert;
								axisDeadZone = axis.axisDeadZone;
								calibrateAxis = axis.calibrateAxis;
								axisZero = axis.axisZero;
								axisMin = axis.axisMin;
								axisMax = axis.axisMax;
								num = -226777356;
								continue;
							case 3:
								axisInfo = MiscTools.DeepClone(axis.axisInfo);
								sourceButton = axis.sourceButton;
								buttonAxisContribution = axis.buttonAxisContribution;
								sourceHat = axis.sourceHat;
								num = -226777358;
								continue;
							case 7:
								elementIdentifier = axis.elementIdentifier;
								num = -226777357;
								continue;
							case 1:
							{
								axis = source as Axis;
								int num2;
								if (axis != null)
								{
									num = -226777360;
									num2 = num;
								}
								else
								{
									num = -226777353;
									num2 = num;
								}
								continue;
							}
							case 5:
								sourceHatDirection = axis.sourceHatDirection;
								sourceHatRange = axis.sourceHatRange;
								alternateCalibrations = MiscTools.DeepClone(axis.alternateCalibrations);
								num = -226777359;
								continue;
							case 0:
								return;
							case 6:
								return;
							}
							break;
						}
					}
				}
			}

			private sealed class hilICimonwGzjMgDwdiDYTzPNcR : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_WindowsUWP_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int ZFqiFhpfZefgbhLFSXVhxruBrTe;

				public int jjDhTodkwdaBlEooaLLSoAnAUKer;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
					{
						goto IL_0012;
					}
					goto IL_0040;
					IL_0012:
					int num = 27775598;
					goto IL_0017;
					IL_0017:
					hilICimonwGzjMgDwdiDYTzPNcR hilICimonwGzjMgDwdiDYTzPNcR2 = default(hilICimonwGzjMgDwdiDYTzPNcR);
					while (true)
					{
						switch (num ^ 0x1A7D26C)
						{
						case 3:
							break;
						case 6:
							goto IL_0040;
						case 4:
							hilICimonwGzjMgDwdiDYTzPNcR2 = this;
							num = 27775596;
							continue;
						case 5:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							num = 27775592;
							continue;
						case 0:
							num = 27775597;
							continue;
						case 2:
							goto IL_0078;
						default:
							return hilICimonwGzjMgDwdiDYTzPNcR2;
						}
						break;
						IL_0078:
						int num2;
						if (isaqVUvqwfWYqOUtovbpbCbxgPc != -2)
						{
							num = 27775594;
							num2 = num;
						}
						else
						{
							num = 27775593;
							num2 = num;
						}
					}
					goto IL_0012;
					IL_0040:
					hilICimonwGzjMgDwdiDYTzPNcR2 = new hilICimonwGzjMgDwdiDYTzPNcR(0);
					hilICimonwGzjMgDwdiDYTzPNcR2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					num = 27775597;
					goto IL_0017;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = -831941331;
						while (true)
						{
							switch (num2 ^ -831941335)
							{
							case 0:
								break;
							case 1:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes[jjDhTodkwdaBlEooaLLSoAnAUKer];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 6:
							{
								int num4;
								if (jjDhTodkwdaBlEooaLLSoAnAUKer < ZFqiFhpfZefgbhLFSXVhxruBrTe)
								{
									num2 = -831941336;
									num4 = num2;
								}
								else
								{
									num2 = -831941332;
									num4 = num2;
								}
								continue;
							}
							case 2:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null)
								{
									int num3;
									if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes == null)
									{
										num2 = -831941332;
										num3 = num2;
									}
									else
									{
										num2 = -831941334;
										num3 = num2;
									}
									continue;
								}
								goto default;
							case 4:
								switch (num)
								{
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									jjDhTodkwdaBlEooaLLSoAnAUKer++;
									num2 = -831941329;
									continue;
								case 0:
									break;
								default:
									num2 = -831941332;
									continue;
								}
								goto case 2;
							case 3:
								ZFqiFhpfZefgbhLFSXVhxruBrTe = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes.Length;
								jjDhTodkwdaBlEooaLLSoAnAUKer = 0;
								num2 = -831941329;
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
				public hilICimonwGzjMgDwdiDYTzPNcR(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class fpoZdFCYOTtBTTZYxsSHBkiAdoE : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_WindowsUWP_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int JRFnVKiivRhzOKkgtuqdmCVuUDh;

				public int PBYSURCXEiyCkyyrKwdNWGBepli;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						goto IL_001c;
					}
					goto IL_0065;
					IL_0065:
					fpoZdFCYOTtBTTZYxsSHBkiAdoE fpoZdFCYOTtBTTZYxsSHBkiAdoE2 = new fpoZdFCYOTtBTTZYxsSHBkiAdoE(0);
					int num = -1450764243;
					goto IL_0021;
					IL_001c:
					num = -1450764242;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ -1450764241)
						{
						case 4:
							break;
						case 1:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							fpoZdFCYOTtBTTZYxsSHBkiAdoE2 = this;
							num = -1450764244;
							continue;
						case 2:
							fpoZdFCYOTtBTTZYxsSHBkiAdoE2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
							num = -1450764244;
							continue;
						case 0:
							goto IL_0065;
						default:
							return fpoZdFCYOTtBTTZYxsSHBkiAdoE2;
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
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					case 0:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements == null)
						{
							break;
						}
						int num2;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons == null)
						{
							num = 2086225440;
							num2 = num;
						}
						else
						{
							num = 2086225446;
							num2 = num;
						}
						goto IL_001f;
					}
					case 1:
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							PBYSURCXEiyCkyyrKwdNWGBepli++;
							num = 2086225445;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x7C594623)
							{
							case 0:
								num = 2086225442;
								continue;
							case 1:
								break;
							case 5:
								JRFnVKiivRhzOKkgtuqdmCVuUDh = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons.Length;
								num = 2086225441;
								continue;
							case 6:
								goto IL_00a7;
							case 2:
								PBYSURCXEiyCkyyrKwdNWGBepli = 0;
								num = 2086225445;
								continue;
							case 4:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons[PBYSURCXEiyCkyyrKwdNWGBepli];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00a7:
							int num3;
							if (PBYSURCXEiyCkyyrKwdNWGBepli < JRFnVKiivRhzOKkgtuqdmCVuUDh)
							{
								num = 2086225447;
								num3 = num;
							}
							else
							{
								num = 2086225440;
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
				public fpoZdFCYOTtBTTZYxsSHBkiAdoE(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform => InputPlatform.YRqjNMGyPIGPClpJpmPGREvRRcG;

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

			internal override IList<Platform> variants_base => null;

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

			internal override Elements_Base elements_base => elements;

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
					goto IL_001f;
				}
				string[] array = new string[elements.axisCount];
				int num2 = 1939254296;
				goto IL_0024;
				IL_0024:
				int num3 = default(int);
				int num5 = default(int);
				int num4 = default(int);
				while (true)
				{
					switch (num2 ^ 0x7396AC1C)
					{
					case 3:
						break;
					case 7:
						array[num3] = identifiers[num5].name;
						num2 = 1939254300;
						continue;
					case 0:
						num3++;
						num2 = 1939254298;
						continue;
					case 4:
						num4 = array.Length;
						num3 = 0;
						num2 = 1939254298;
						continue;
					case 5:
					{
						int elementIdentifier = elements.axes[num3].elementIdentifier;
						num5 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						if (num5 >= 0)
						{
							int num6;
							if (num5 >= num)
							{
								num2 = 1939254302;
								num6 = num2;
							}
							else
							{
								num2 = 1939254299;
								num6 = num2;
							}
							continue;
						}
						goto case 2;
					}
					case 1:
						return new string[0];
					case 2:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = 1939254300;
						continue;
					default:
						if (num3 >= num4)
						{
							return array;
						}
						goto case 5;
					}
					break;
				}
				goto IL_001f;
				IL_001f:
				num2 = 1939254301;
				goto IL_0024;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				int num = identifiers.Length;
				string[] array = default(string[]);
				int num3 = default(int);
				int num5 = default(int);
				while (true)
				{
					int num2 = 2105543904;
					while (true)
					{
						switch (num2 ^ 0x7D800CE6)
						{
						case 4:
							break;
						case 6:
							if (num < buttonCount)
							{
								Logger.LogError("You have too few element identifiers!");
								return new string[0];
							}
							array = new string[buttonCount];
							num3 = 0;
							num2 = 2105543911;
							continue;
						case 8:
							num3++;
							num2 = 2105543910;
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
									num2 = 2105543907;
									num6 = num2;
								}
								else
								{
									num2 = 2105543905;
									num6 = num2;
								}
								continue;
							}
							goto case 7;
						}
						case 5:
							array[num3] = identifiers[num5].name;
							num2 = 2105543918;
							continue;
						case 7:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = 2105543918;
							continue;
						case 1:
							num2 = 2105543910;
							continue;
						case 0:
						{
							int num4;
							if (num3 >= buttonCount)
							{
								num2 = 2105543909;
								num4 = num2;
							}
							else
							{
								num2 = 2105543908;
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
				using (IEnumerator<Axis> enumerator = IterateAxes().GetEnumerator())
				{
					Axis current = default(Axis);
					while (true)
					{
						IL_0054:
						int num;
						int num2;
						if (enumerator.MoveNext())
						{
							num = -1876963292;
							num2 = num;
						}
						else
						{
							num = -1876963290;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -1876963291)
							{
							case 2:
								num = -1876963292;
								continue;
							default:
								goto end_IL_0013;
							case 1:
								current = enumerator.Current;
								num = -1876963296;
								continue;
							case 4:
								return true;
							case 0:
								break;
							case 5:
							{
								int num3;
								if (current.elementIdentifier != elementIdentifierId)
								{
									num = -1876963291;
									num3 = num;
								}
								else
								{
									num = -1876963295;
									num3 = num;
								}
								continue;
							}
							case 3:
								goto end_IL_0013;
							}
							goto IL_0054;
							continue;
							end_IL_0013:
							break;
						}
						break;
					}
				}
				IEnumerator<Button> enumerator2 = IterateButtons().GetEnumerator();
				try
				{
					while (true)
					{
						IL_00f5:
						int num4;
						int num5;
						if (enumerator2.MoveNext())
						{
							num4 = -1876963290;
							num5 = num4;
						}
						else
						{
							num4 = -1876963295;
							num5 = num4;
						}
						while (true)
						{
							switch (num4 ^ -1876963291)
							{
							case 0:
								num4 = -1876963290;
								continue;
							default:
								goto end_IL_00a7;
							case 3:
							{
								Button current2 = enumerator2.Current;
								int num6;
								if (current2.elementIdentifier != elementIdentifierId)
								{
									num4 = -1876963289;
									num6 = num4;
								}
								else
								{
									num4 = -1876963292;
									num6 = num4;
								}
								continue;
							}
							case 1:
								return true;
							case 2:
								break;
							case 4:
								goto end_IL_00a7;
							}
							goto IL_00f5;
							continue;
							end_IL_00a7:
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
							IL_0115:
							int num7 = -1876963292;
							while (true)
							{
								switch (num7 ^ -1876963291)
								{
								case 0:
									break;
								default:
									goto end_IL_011a;
								case 1:
									goto IL_0133;
								case 2:
									goto end_IL_011a;
								}
								goto IL_0115;
								IL_0133:
								enumerator2.Dispose();
								num7 = -1876963289;
								continue;
								end_IL_011a:
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
				axes = new int[assignedAxisCount];
				int num2 = default(int);
				while (true)
				{
					int num = -812796913;
					while (true)
					{
						switch (num ^ -812796914)
						{
						case 2:
							break;
						case 1:
							goto IL_0038;
						default:
						{
							using (IEnumerator<Button> enumerator = IterateButtons().GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										Button current = enumerator.Current;
										buttons[num2] = current.elementIdentifier;
										int num3 = -812796913;
										while (true)
										{
											switch (num3 ^ -812796914)
											{
											case 0:
												num3 = -812796915;
												continue;
											case 3:
												break;
											case 1:
												num2++;
												num3 = -812796916;
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
							IEnumerator<Axis> enumerator2 = IterateAxes().GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									while (true)
									{
										Axis current2 = enumerator2.Current;
										int num4 = -812796915;
										while (true)
										{
											switch (num4 ^ -812796914)
											{
											case 2:
												num4 = -812796913;
												continue;
											case 1:
												break;
											case 3:
												axes[num2] = current2.elementIdentifier;
												num2++;
												num4 = -812796914;
												continue;
											default:
												goto end_IL_00db;
											}
											break;
										}
										continue;
										end_IL_00db:
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
										IL_010e:
										int num5 = -812796913;
										while (true)
										{
											switch (num5 ^ -812796914)
											{
											case 2:
												break;
											default:
												goto end_IL_0113;
											case 1:
												goto IL_012c;
											case 0:
												goto end_IL_0113;
											}
											goto IL_010e;
											IL_012c:
											enumerator2.Dispose();
											num5 = -812796914;
											continue;
											end_IL_0113:
											break;
										}
										break;
									}
								}
							}
						}
						}
						break;
						IL_0038:
						num2 = 0;
						num = -812796914;
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
				int num2 = 751393647;
				goto IL_0012;
				IL_0012:
				while (true)
				{
					switch (num2 ^ 0x2CC95B6B)
					{
					case 8:
						break;
					case 5:
					{
						ref AxisCalibrationData reference = ref array[num];
						reference = AxisCalibrationData.Default;
						array[num].invert = axes_orig[num].invert;
						num2 = 751393632;
						continue;
					}
					case 11:
						array[num].deadZone = axes_orig[num].axisDeadZone;
						num2 = 751393640;
						continue;
					case 12:
						return null;
					case 10:
						array[num].min = axes_orig[num].axisMin;
						array[num].max = axes_orig[num].axisMax;
						num2 = 751393634;
						continue;
					case 1:
						throw new NotImplementedException();
					case 13:
						if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Button)
						{
							int num4;
							if (axes_orig[num].sourceType == HardwareElementSourceTypeWithHat.Hat)
							{
								num2 = 751393644;
								num4 = num2;
							}
							else
							{
								num2 = 751393642;
								num4 = num2;
							}
							continue;
						}
						goto case 7;
					case 4:
					{
						int num6;
						if (num >= axes_orig.Length)
						{
							num2 = 751393643;
							num6 = num2;
						}
						else
						{
							num2 = 751393641;
							num6 = num2;
						}
						continue;
					}
					case 3:
					{
						int num5;
						if (Axes_orig[num].calibrateAxis)
						{
							num2 = 751393645;
							num5 = num2;
						}
						else
						{
							num2 = 751393634;
							num5 = num2;
						}
						continue;
					}
					case 9:
						array[num].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num].alternateCalibrations, deepClone: true);
						num++;
						num2 = 751393647;
						continue;
					case 6:
						array[num].zero = axes_orig[num].axisZero;
						num2 = 751393633;
						continue;
					case 2:
						if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Axis)
						{
							int num3;
							if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Custom)
							{
								num2 = 751393638;
								num3 = num2;
							}
							else
							{
								num2 = 751393646;
								num3 = num2;
							}
							continue;
						}
						goto case 5;
					case 7:
					{
						ref AxisCalibrationData reference2 = ref array[num];
						reference2 = AxisCalibrationData.Default;
						num2 = 751393634;
						continue;
					}
					default:
						return array;
					}
					break;
				}
				goto IL_000d;
				IL_000d:
				num2 = 751393639;
				goto IL_0012;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
				int num2 = default(int);
				while (true)
				{
					int num = 564966579;
					while (true)
					{
						switch (num ^ 0x21ACB4B7)
						{
						case 11:
							break;
						case 8:
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = 564966577;
							continue;
						case 9:
							num2++;
							num = 564966589;
							continue;
						case 4:
							if (Axes_orig == null)
							{
								return;
							}
							goto case 3;
						case 1:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = 564966590;
							continue;
						case 7:
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num4;
								if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Hat)
								{
									num = 564966583;
									num4 = num;
								}
								else
								{
									num = 564966578;
									num4 = num;
								}
								continue;
							}
							goto case 0;
						case 2:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, createIfNull: true);
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num3;
								if (Axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Custom)
								{
									num = 564966582;
									num3 = num;
								}
								else
								{
									num = 564966576;
									num3 = num;
								}
								continue;
							}
							goto case 1;
						case 3:
							axisRanges = new AxisRange[Axes_orig.Length];
							num = 564966591;
							continue;
						case 6:
							num = 564966589;
							continue;
						case 5:
							throw new Exception();
						case 0:
							axisRanges[num2] = AxisRange.Full;
							num = 564966590;
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
					return;
				}
				while (true)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					int num = 0;
					int num2 = 1104593198;
					while (true)
					{
						switch (num2 ^ 0x41D6C12E)
						{
						case 4:
							num2 = 1104593199;
							continue;
						default:
							return;
						case 1:
							break;
						case 0:
						{
							int num3;
							if (num < Buttons_orig.Length)
							{
								num2 = 1104593197;
								num3 = num2;
							}
							else
							{
								num2 = 1104593196;
								num3 = num2;
							}
							continue;
						}
						case 3:
							buttonInfos[num] = MiscTools.DeepClone(Buttons_orig[num].buttonInfo, createIfNull: true);
							num++;
							num2 = 1104593198;
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

			internal IEnumerable<Axis> IterateAxes()
			{
				hilICimonwGzjMgDwdiDYTzPNcR hilICimonwGzjMgDwdiDYTzPNcR2 = new hilICimonwGzjMgDwdiDYTzPNcR(-2);
				hilICimonwGzjMgDwdiDYTzPNcR2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return hilICimonwGzjMgDwdiDYTzPNcR2;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				fpoZdFCYOTtBTTZYxsSHBkiAdoE fpoZdFCYOTtBTTZYxsSHBkiAdoE2 = new fpoZdFCYOTtBTTZYxsSHBkiAdoE(-2);
				fpoZdFCYOTtBTTZYxsSHBkiAdoE2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return fpoZdFCYOTtBTTZYxsSHBkiAdoE2;
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
				while (true)
				{
					int num = -1550532372;
					while (true)
					{
						switch (num ^ -1550532371)
						{
						case 3:
							break;
						default:
							return;
						case 1:
							if (platform_WindowsUWP_Base != null)
							{
								goto IL_0034;
							}
							return;
						case 2:
							goto IL_0034;
						case 0:
							return;
						}
						break;
						IL_0034:
						platform_WindowsUWP_Base.elements = MiscTools.DeepClone(elements);
						num = -1550532371;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_WindowsUWP : Platform_WindowsUWP_Base
		{
			public Platform_WindowsUWP_Base[] variants;

			internal override IList<Platform> variants_base => variants;

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
							num2 = -668438864;
							num3 = num2;
						}
						else
						{
							num2 = -668438861;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -668438862)
							{
							case 0:
								num2 = -668438864;
								continue;
							case 2:
								break;
							case 3:
								goto end_IL_0020;
							default:
								goto end_IL_006c;
							}
							if (variants[num] != null && variants[num].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
							{
								variantIndex = num;
								return true;
							}
							num++;
							num2 = -668438863;
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
					switch (0x1291500B ^ 0x12915009)
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

				internal override int alternateElementCount => 0;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData)
					{
						goto IL_0010;
					}
					goto IL_007e;
					IL_010a:
					return false;
					IL_0010:
					int num = -2007225880;
					goto IL_0015;
					IL_0015:
					string searchFor = default(string);
					int num2 = default(int);
					string text = default(string);
					while (true)
					{
						switch (num ^ -2007225878)
						{
						case 6:
							break;
						case 3:
							searchFor = productName[num2];
							num = -2007225878;
							continue;
						case 7:
							goto IL_0059;
						case 2:
							goto IL_0074;
						case 5:
							return true;
						case 1:
							return false;
						case 0:
							goto IL_00cc;
						case 4:
							goto IL_00eb;
						default:
							goto IL_010a;
						}
						break;
						IL_00eb:
						int num3;
						if (num2 < productName.Length)
						{
							num = -2007225879;
							num3 = num;
						}
						else
						{
							num = -2007225886;
							num3 = num;
						}
						continue;
						IL_00cc:
						if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
						{
							return true;
						}
						num2++;
						num = -2007225874;
					}
					goto IL_0010;
					IL_007e:
					if (!isAllowed)
					{
						return false;
					}
					if (alwaysMatch)
					{
						num = -2007225873;
					}
					else if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						num = -2007225877;
					}
					else
					{
						text = bridgedControllerHWInfo.hw_productName;
						if (text != null)
						{
							goto IL_0059;
						}
						text = string.Empty;
						num = -2007225875;
					}
					goto IL_0015;
					IL_0074:
					if (isAllowed)
					{
						return true;
					}
					goto IL_007e;
					IL_0059:
					text = text.Trim();
					if (productName != null)
					{
						num2 = 0;
						num = -2007225874;
						goto IL_0015;
					}
					goto IL_010a;
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
						int num = 912161000;
						while (true)
						{
							switch (num ^ 0x365E78E9)
							{
							case 3:
								break;
							case 1:
								matchingCriteria = destination as MatchingCriteria;
								if (matchingCriteria == null)
								{
									return;
								}
								goto case 2;
							case 2:
								matchingCriteria.alwaysMatch = alwaysMatch;
								matchingCriteria.productName_useRegex = productName_useRegex;
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								num = 912161005;
								continue;
							case 4:
								matchingCriteria.matchUnityVersion = matchUnityVersion;
								matchingCriteria.matchUnityVersion_min = matchUnityVersion_min;
								matchingCriteria.matchUnityVersion_max = matchUnityVersion_max;
								matchingCriteria.matchSysVersion = matchSysVersion;
								num = 912161001;
								continue;
							default:
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
					int num3 = default(int);
					while (true)
					{
						int num2 = 441655543;
						while (true)
						{
							switch (num2 ^ 0x1A5320F4)
							{
							case 0:
								break;
							case 1:
								if (num >= axisCount)
								{
									num3 = 0;
									num2 = 441655537;
									continue;
								}
								goto case 4;
							case 4:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = 441655541;
								continue;
							case 2:
								if (buttons[num3].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num3++;
								num2 = 441655537;
								continue;
							case 3:
								num2 = 441655541;
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
					while (num < axisCount)
					{
						while (true)
						{
							int num2;
							int num3;
							if (axes[num].elementIdentifier != elementIdentifier.id)
							{
								num2 = 1813506162;
								num3 = num2;
							}
							else
							{
								num2 = 1813506166;
								num3 = num2;
							}
							while (true)
							{
								switch (num2 ^ 0x6C17E877)
								{
								case 0:
									num2 = 1813506165;
									continue;
								case 2:
									break;
								case 6:
									goto IL_0062;
								case 3:
									return true;
								case 4:
									if (axes[num].invert)
									{
										axisRange = InputTools.InvertAxisRange(axisRange);
										num2 = 1813506164;
										continue;
									}
									goto case 3;
								case 1:
									goto IL_00ae;
								case 5:
									num++;
									num2 = 1813506160;
									continue;
								default:
									goto end_IL_003c;
								}
								break;
								IL_00ae:
								switch (axes[num].sourceType)
								{
								case HardwareElementSourceTypeWithHat.Axis:
									break;
								case HardwareElementSourceTypeWithHat.Button:
									axisRange = AxisRange.Positive;
									return true;
								default:
									throw new NotImplementedException();
								case HardwareElementSourceTypeWithHat.Custom:
									num2 = 1813506161;
									continue;
								}
								goto IL_0062;
								IL_0062:
								axisRange = axes[num].sourceAxisRange;
								num2 = 1813506163;
							}
							continue;
							end_IL_003c:
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
						int num = 1916304152;
						while (true)
						{
							switch (num ^ 0x72387B19)
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
							num = 1916304155;
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
						goto IL_0003;
					}
					goto IL_002d;
					IL_0003:
					int num = -1046042986;
					goto IL_0008;
					IL_0008:
					switch (num ^ -1046042985)
					{
					case 2:
						break;
					case 1:
						return;
					case 3:
						goto IL_002d;
					default:
						destination.customCalculation = customCalculation;
						destination.customCalculationSourceData = ArrayTools.DeepClone(customCalculationSourceData);
						return;
					}
					goto IL_0003;
					IL_002d:
					destination.elementIdentifier = elementIdentifier;
					destination.sourceType = sourceType;
					destination.sourceAxis = sourceAxis;
					destination.axisDeadZone = axisDeadZone;
					destination.sourceButton = sourceButton;
					destination.sourceKeyCode = sourceKeyCode;
					num = -1046042985;
					goto IL_0008;
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
					while (true)
					{
						int num = -848147965;
						while (true)
						{
							switch (num ^ -848147966)
							{
							case 0:
								break;
							case 1:
								goto IL_0024;
							default:
								return button;
							}
							break;
							IL_0024:
							CopyVars(button);
							num = -848147968;
						}
					}
				}

				protected override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (!(destination is Button button))
					{
						return;
					}
					while (true)
					{
						button.sourceAxisPole = sourceAxisPole;
						int num = -1941135281;
						while (true)
						{
							switch (num ^ -1941135288)
							{
							case 3:
								num = -1941135287;
								continue;
							case 2:
								button.ignoreIfButtonsActive = ignoreIfButtonsActive;
								button.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons);
								num = -1941135288;
								continue;
							case 6:
								button.unityHat_sourceAxis2 = unityHat_sourceAxis2;
								num = -1941135284;
								continue;
							case 8:
								button.unityHat_zeroValues = unityHat_zeroValues;
								button.unityHat_checkNeverPressed = unityHat_checkNeverPressed;
								button.unityHat_neverPressedZeroValues = unityHat_neverPressedZeroValues;
								button.requireMultipleButtons = requireMultipleButtons;
								num = -1941135283;
								continue;
							case 5:
								button.requiredButtons = ArrayTools.ShallowCopy(requiredButtons);
								num = -1941135286;
								continue;
							case 4:
								button.unityHat_isActiveAxisValues1 = unityHat_isActiveAxisValues1;
								button.unityHat_isActiveAxisValues2 = unityHat_isActiveAxisValues2;
								button.unityHat_isActiveAxisValues3 = unityHat_isActiveAxisValues3;
								num = -1941135296;
								continue;
							case 7:
								button.unityHat_sourceAxis1 = unityHat_sourceAxis1;
								num = -1941135282;
								continue;
							case 1:
								break;
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
					if (destination is Axis axis)
					{
						axis.invert = invert;
						axis.sourceAxisRange = sourceAxisRange;
						axis.buttonAxisContribution = buttonAxisContribution;
						axis.calibrateAxis = calibrateAxis;
						axis.axisZero = axisZero;
						axis.axisMin = axisMin;
						axis.axisMax = axisMax;
						axis.axisInfo = MiscTools.DeepClone(axisInfo);
						axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
					}
				}
			}

			private sealed class CmKcUugJyZEGqEIZdCrpjUOQHvcD : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_Fallback_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int zYMCdyCtPPeWUDKXClFTDNQIQpzj;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					CmKcUugJyZEGqEIZdCrpjUOQHvcD cmKcUugJyZEGqEIZdCrpjUOQHvcD;
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						cmKcUugJyZEGqEIZdCrpjUOQHvcD = this;
						goto IL_0025;
					}
					goto IL_005e;
					IL_002a:
					int num;
					while (true)
					{
						switch (num ^ -834265200)
						{
						case 0:
							break;
						case 1:
							cmKcUugJyZEGqEIZdCrpjUOQHvcD.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
							num = -834265198;
							continue;
						case 4:
							goto IL_005e;
						case 3:
							num = -834265198;
							continue;
						default:
							return cmKcUugJyZEGqEIZdCrpjUOQHvcD;
						}
						break;
					}
					goto IL_0025;
					IL_005e:
					cmKcUugJyZEGqEIZdCrpjUOQHvcD = new CmKcUugJyZEGqEIZdCrpjUOQHvcD(0);
					num = -834265199;
					goto IL_002a;
					IL_0025:
					num = -834265197;
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
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					default:
						num = -1126909103;
						goto IL_001a;
					case 1:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						zYMCdyCtPPeWUDKXClFTDNQIQpzj++;
						num = -1126909104;
						goto IL_001a;
					case 0:
						goto IL_00e1;
						IL_001a:
						while (true)
						{
							switch (num ^ -1126909097)
							{
							case 4:
								break;
							case 7:
								goto IL_004e;
							case 2:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null)
								{
									goto IL_0089;
								}
								goto default;
							case 0:
								zYMCdyCtPPeWUDKXClFTDNQIQpzj = 0;
								num = -1126909104;
								continue;
							case 3:
								return true;
							case 8:
								goto IL_00e1;
							case 5:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes[zYMCdyCtPPeWUDKXClFTDNQIQpzj];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = -1126909100;
								continue;
							case 6:
								num = -1126909098;
								continue;
							default:
								return false;
							}
							break;
							IL_0089:
							int num2;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes == null)
							{
								num = -1126909098;
								num2 = num;
							}
							else
							{
								num = -1126909097;
								num2 = num;
							}
							continue;
							IL_004e:
							int num3;
							if (zYMCdyCtPPeWUDKXClFTDNQIQpzj < syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes.Length)
							{
								num = -1126909102;
								num3 = num;
							}
							else
							{
								num = -1126909098;
								num3 = num;
							}
						}
						goto default;
						IL_00e1:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = -1126909099;
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
				public CmKcUugJyZEGqEIZdCrpjUOQHvcD(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class JaSZxZzdKkuAaopKDiLVNCnFFDTk : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_Fallback_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int vBsjiXIDfbvOzDzzDBkCmWvUtOwC;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						goto IL_001c;
					}
					goto IL_0054;
					IL_0054:
					JaSZxZzdKkuAaopKDiLVNCnFFDTk jaSZxZzdKkuAaopKDiLVNCnFFDTk = new JaSZxZzdKkuAaopKDiLVNCnFFDTk(0);
					jaSZxZzdKkuAaopKDiLVNCnFFDTk.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					int num = 1125721348;
					goto IL_0021;
					IL_001c:
					num = 1125721344;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ 0x43192501)
						{
						case 2:
							break;
						case 1:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							num = 1125721349;
							continue;
						case 3:
							goto IL_0054;
						case 0:
							num = 1125721348;
							continue;
						case 4:
							jaSZxZzdKkuAaopKDiLVNCnFFDTk = this;
							num = 1125721345;
							continue;
						default:
							return jaSZxZzdKkuAaopKDiLVNCnFFDTk;
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
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = 1415722010;
						while (true)
						{
							switch (num2 ^ 0x54623419)
							{
							case 2:
								break;
							case 3:
								switch (num)
								{
								default:
									num2 = 1415722013;
									continue;
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									vBsjiXIDfbvOzDzzDBkCmWvUtOwC++;
									num2 = 1415722012;
									continue;
								case 0:
									break;
								}
								goto case 6;
							case 4:
								num2 = 1415722008;
								continue;
							case 5:
							{
								int num3;
								if (vBsjiXIDfbvOzDzzDBkCmWvUtOwC >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons.Length)
								{
									num2 = 1415722008;
									num3 = num2;
								}
								else
								{
									num2 = 1415722009;
									num3 = num2;
								}
								continue;
							}
							case 0:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons[vBsjiXIDfbvOzDzzDBkCmWvUtOwC];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 6:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null && syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons != null)
								{
									vBsjiXIDfbvOzDzzDBkCmWvUtOwC = 0;
									num2 = 1415722012;
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
				public JaSZxZzdKkuAaopKDiLVNCnFFDTk(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.IOPdHWmrObUEwmObrCgWvfxfehz;

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

			internal override Elements_Base elements_base => elements;

			internal override IList<Platform> variants_base => null;

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
				CmKcUugJyZEGqEIZdCrpjUOQHvcD cmKcUugJyZEGqEIZdCrpjUOQHvcD = new CmKcUugJyZEGqEIZdCrpjUOQHvcD(-2);
				while (true)
				{
					int num = 1899240475;
					while (true)
					{
						switch (num ^ 0x71341C1A)
						{
						case 0:
							break;
						case 1:
							goto IL_0026;
						default:
							return cmKcUugJyZEGqEIZdCrpjUOQHvcD;
						}
						break;
						IL_0026:
						cmKcUugJyZEGqEIZdCrpjUOQHvcD.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
						num = 1899240472;
					}
				}
			}

			internal IEnumerable<Button> IterateButtons()
			{
				JaSZxZzdKkuAaopKDiLVNCnFFDTk jaSZxZzdKkuAaopKDiLVNCnFFDTk = new JaSZxZzdKkuAaopKDiLVNCnFFDTk(-2);
				jaSZxZzdKkuAaopKDiLVNCnFFDTk.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return jaSZxZzdKkuAaopKDiLVNCnFFDTk;
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
					int num2 = -294032295;
					while (true)
					{
						switch (num2 ^ -294032292)
						{
						case 2:
							break;
						case 5:
							num2 = -294032296;
							continue;
						case 6:
							array[num] = identifiers[num3].name;
							num2 = -294032291;
							continue;
						case 0:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = -294032291;
							continue;
						case 3:
						{
							int elementIdentifier = elements.axes[num].elementIdentifier;
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							if (num3 >= 0)
							{
								int num4;
								if (num3 < identifiers.Length)
								{
									num2 = -294032294;
									num4 = num2;
								}
								else
								{
									num2 = -294032292;
									num4 = num2;
								}
								continue;
							}
							goto case 0;
						}
						case 1:
							num++;
							num2 = -294032296;
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
						if (num2 >= 0)
						{
							int num4;
							if (num2 < identifiers.Length)
							{
								num3 = -1615401708;
								num4 = num3;
							}
							else
							{
								num3 = -1615401707;
								num4 = num3;
							}
							goto IL_0036;
						}
						goto IL_00a0;
						IL_0036:
						while (true)
						{
							switch (num3 ^ -1615401706)
							{
							case 4:
								num3 = -1615401705;
								continue;
							case 1:
								break;
							case 0:
								num++;
								num3 = -1615401709;
								continue;
							case 3:
								goto IL_00a0;
							case 2:
								array[num] = identifiers[num2].name;
								num3 = -1615401706;
								continue;
							default:
								goto end_IL_005b;
							}
							break;
						}
						continue;
						IL_00a0:
						Logger.LogError("Element identifier index is out of bounds!");
						num3 = -1615401706;
						goto IL_0036;
						continue;
						end_IL_005b:
						break;
					}
				}
				return array;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				IEnumerator<Axis> enumerator = IterateAxes().GetEnumerator();
				bool result;
				try
				{
					while (enumerator.MoveNext())
					{
						Axis current = enumerator.Current;
						if (current.elementIdentifier != elementIdentifierId)
						{
							continue;
						}
						result = true;
						goto IL_00f0;
					}
				}
				finally
				{
					if (enumerator != null)
					{
						while (true)
						{
							IL_0057:
							int num = -1910848860;
							while (true)
							{
								switch (num ^ -1910848859)
								{
								case 0:
									break;
								default:
									goto end_IL_005c;
								case 1:
									goto IL_0075;
								case 2:
									goto end_IL_005c;
								}
								goto IL_0057;
								IL_0075:
								enumerator.Dispose();
								num = -1910848857;
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
							if (current2.elementIdentifier != elementIdentifierId)
							{
								break;
							}
							result = true;
							int num2 = -1910848858;
							while (true)
							{
								switch (num2 ^ -1910848859)
								{
								case 0:
									num2 = -1910848857;
									continue;
								case 2:
									break;
								default:
									goto end_IL_00b4;
								case 3:
									goto IL_00f0;
								}
								break;
							}
							continue;
							end_IL_00b4:
							break;
						}
					}
				}
				return false;
				IL_00f0:
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
							num2 = 1905432076;
							num3 = num2;
						}
						else
						{
							num2 = 1905432077;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x7192960F)
							{
							case 0:
								num2 = 1905432077;
								continue;
							default:
								goto end_IL_002f;
							case 2:
							{
								Button current = enumerator.Current;
								buttons[num] = current.elementIdentifier;
								num2 = 1905432078;
								continue;
							}
							case 4:
								break;
							case 1:
								num++;
								num2 = 1905432075;
								continue;
							case 3:
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
							int num4 = 1905432078;
							while (true)
							{
								switch (num4 ^ 0x7192960F)
								{
								case 0:
									num4 = 1905432077;
									continue;
								case 3:
									num++;
									num4 = 1905432075;
									continue;
								case 1:
									axes[num] = current2.elementIdentifier;
									num4 = 1905432076;
									continue;
								case 2:
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
				int num = 0;
				while (true)
				{
					int num2 = -1752022004;
					while (true)
					{
						switch (num2 ^ -1752022012)
						{
						case 3:
							break;
						case 4:
							num2 = -1752022013;
							continue;
						case 10:
							array[num].max = axes_orig[num].axisMax;
							num2 = -1752022016;
							continue;
						case 8:
							num2 = -1752022003;
							continue;
						case 1:
							throw new NotImplementedException();
						case 6:
							if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num4;
								if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Hat)
								{
									num2 = -1752022011;
									num4 = num2;
								}
								else
								{
									num2 = -1752022015;
									num4 = num2;
								}
								continue;
							}
							goto case 5;
						case 2:
						{
							ref AxisCalibrationData reference2 = ref array[num];
							reference2 = AxisCalibrationData.Default;
							array[num].invert = axes_orig[num].invert;
							array[num].deadZone = axes_orig[num].axisDeadZone;
							if (Axes_orig[num].calibrateAxis)
							{
								array[num].zero = axes_orig[num].axisZero;
								array[num].min = axes_orig[num].axisMin;
								num2 = -1752022002;
								continue;
							}
							goto case 7;
						}
						case 7:
							array[num].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num].alternateCalibrations, deepClone: true);
							num++;
							num2 = -1752022003;
							continue;
						case 0:
							if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num3;
								if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									num2 = -1752022014;
									num3 = num2;
								}
								else
								{
									num2 = -1752022010;
									num3 = num2;
								}
								continue;
							}
							goto case 2;
						case 5:
						{
							ref AxisCalibrationData reference = ref array[num];
							reference = AxisCalibrationData.Default;
							num2 = -1752022013;
							continue;
						}
						default:
							if (num >= axes_orig.Length)
							{
								return array;
							}
							goto case 0;
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
					int num = -150937472;
					while (true)
					{
						switch (num ^ -150937464)
						{
						case 0:
							break;
						case 10:
							num = -150937462;
							continue;
						case 12:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -150937470;
							continue;
						case 1:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, createIfNull: true);
							num = -150937460;
							continue;
						case 7:
							axisRanges = new AxisRange[Axes_orig.Length];
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = -150937459;
							continue;
						case 2:
							num2++;
							num = -150937459;
							continue;
						case 9:
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num4;
								if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Hat)
								{
									num = -150937469;
									num4 = num;
								}
								else
								{
									num = -150937458;
									num4 = num;
								}
								continue;
							}
							goto case 6;
						case 3:
							num = -150937462;
							continue;
						case 8:
							axisInfos = null;
							if (Axes_orig == null)
							{
								return;
							}
							goto case 7;
						case 6:
							axisRanges[num2] = AxisRange.Full;
							num = -150937461;
							continue;
						case 11:
							throw new Exception();
						case 4:
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num3;
								if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Custom)
								{
									num = -150937471;
									num3 = num;
								}
								else
								{
									num = -150937468;
									num3 = num;
								}
								continue;
							}
							goto case 12;
						default:
							if (num2 >= Axes_orig.Length)
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
				int num2 = default(int);
				while (true)
				{
					int num = -1044465256;
					while (true)
					{
						switch (num ^ -1044465255)
						{
						case 5:
							break;
						default:
							return;
						case 2:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, createIfNull: true);
							num = -1044465249;
							continue;
						case 4:
							buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
							num2 = 0;
							num = -1044465254;
							continue;
						case 3:
						{
							int num3;
							if (num2 < Buttons_orig.Length)
							{
								num = -1044465253;
								num3 = num;
							}
							else
							{
								num = -1044465255;
								num3 = num;
							}
							continue;
						}
						case 6:
							num2++;
							num = -1044465254;
							continue;
						case 1:
							if (Buttons_orig == null)
							{
								return;
							}
							goto case 4;
						case 0:
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
				Platform_Fallback_Base platform_Fallback_Base = new Platform_Fallback_Base();
				CopyVars(platform_Fallback_Base);
				return platform_Fallback_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				if (!(destination is Platform_Fallback_Base platform_Fallback_Base))
				{
					return;
				}
				while (true)
				{
					platform_Fallback_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_Fallback_Base.elements = MiscTools.DeepClone(elements);
					int num = 2000120013;
					while (true)
					{
						switch (num ^ 0x773768CD)
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
						num = 2000120012;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_Fallback : Platform_Fallback_Base
		{
			public Platform_Fallback_Base[] variants;

			internal override IList<Platform> variants_base => variants;

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
							num2 = 665768916;
							num3 = num2;
						}
						else
						{
							num2 = 665768919;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x27AED3D6)
							{
							case 3:
								num2 = 665768919;
								continue;
							case 1:
								break;
							case 4:
								variantIndex = num;
								return true;
							case 0:
								goto end_IL_0020;
							default:
								goto end_IL_0077;
							}
							if (variants[num] != null && variants[num].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
							{
								num2 = 665768914;
								continue;
							}
							num++;
							num2 = 665768918;
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
				Platform_Fallback platform_Fallback = new Platform_Fallback();
				CopyVars(platform_Fallback);
				return platform_Fallback;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_Fallback platform_Fallback)
				{
					platform_Fallback.variants = MiscTools.DeepClone(variants);
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

				internal override int alternateElementCount => 0;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock)
					{
						goto IL_0008;
					}
					goto IL_003c;
					IL_0008:
					int num = 1876079879;
					goto IL_000d;
					IL_000d:
					switch (num ^ 0x6FD2B505)
					{
					case 0:
						break;
					case 2:
						goto IL_002a;
					case 1:
						return false;
					default:
						return true;
					}
					goto IL_0008;
					IL_003c:
					if (disabled)
					{
						return false;
					}
					if (!isAllowed)
					{
						num = 1876079876;
					}
					else
					{
						if (!alwaysMatch)
						{
							return true;
						}
						num = 1876079878;
					}
					goto IL_000d;
					IL_002a:
					if (hasData && isAllowed)
					{
						return true;
					}
					goto IL_003c;
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
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.alwaysMatch = alwaysMatch;
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
					while (true)
					{
						int num = -1977077732;
						while (true)
						{
							switch (num ^ -1977077729)
							{
							case 5:
								break;
							case 3:
								customCalculationSourceData.sourceAxisRange = sourceAxisRange;
								num = -1977077730;
								continue;
							case 4:
								customCalculationSourceData.invert = invert;
								num = -1977077731;
								continue;
							case 1:
								customCalculationSourceData.axisDeadZone = axisDeadZone;
								num = -1977077733;
								continue;
							case 2:
								customCalculationSourceData.axisCalibrationType = axisCalibrationType;
								customCalculationSourceData.axisZero = axisZero;
								customCalculationSourceData.axisMin = axisMin;
								customCalculationSourceData.axisMax = axisMax;
								num = -1977077729;
								continue;
							default:
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
					destination.axisDeadZone = axisDeadZone;
					while (true)
					{
						int num = 1922239606;
						while (true)
						{
							switch (num ^ 0x72930C77)
							{
							case 2:
								break;
							case 1:
								goto IL_004e;
							default:
								destination.customCalculation = customCalculation;
								destination.customCalculationSourceData = ArrayTools.DeepClone(customCalculationSourceData);
								return;
							}
							break;
							IL_004e:
							destination.sourceButton = sourceButton;
							num = 1922239607;
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
						int num = -589980657;
						while (true)
						{
							switch (num ^ -589980658)
							{
							case 3:
								break;
							default:
								return;
							case 1:
								button = destination as Button;
								if (button == null)
								{
									return;
								}
								goto case 2;
							case 2:
								button.sourceAxisPole = sourceAxisPole;
								button.requireMultipleButtons = requireMultipleButtons;
								num = -589980661;
								continue;
							case 0:
								button.buttonInfo = MiscTools.DeepClone(buttonInfo);
								num = -589980662;
								continue;
							case 5:
								button.requiredButtons = ArrayTools.ShallowCopy(requiredButtons);
								button.ignoreIfButtonsActive = ignoreIfButtonsActive;
								button.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons);
								num = -589980658;
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
					if (!(destination is Axis axis))
					{
						return;
					}
					while (true)
					{
						axis.invert = invert;
						int num = 642409009;
						while (true)
						{
							switch (num ^ 0x264A6232)
							{
							case 2:
								num = 642409014;
								continue;
							default:
								return;
							case 5:
								axis.buttonAxisContribution = buttonAxisContribution;
								num = 642409012;
								continue;
							case 3:
								axis.sourceAxisRange = sourceAxisRange;
								num = 642409015;
								continue;
							case 0:
								axis.axisMax = axisMax;
								num = 642409013;
								continue;
							case 7:
								axis.axisInfo = MiscTools.DeepClone(axisInfo);
								axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
								num = 642409011;
								continue;
							case 4:
								break;
							case 6:
								axis.calibrateAxis = calibrateAxis;
								axis.axisZero = axisZero;
								axis.axisMin = axisMin;
								num = 642409010;
								continue;
							case 1:
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
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						goto IL_0024;
					}
					int num;
					if (!alwaysMatch)
					{
						num = -773025132;
						goto IL_0029;
					}
					return true;
					IL_0024:
					num = -773025129;
					goto IL_0029;
					IL_0029:
					switch (num ^ -773025130)
					{
					case 0:
						break;
					case 1:
						return false;
					default:
						return false;
					}
					goto IL_0024;
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
					int num2 = default(int);
					while (true)
					{
						IL_0079:
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = -1684654583;
							goto IL_0009;
						}
						goto IL_0057;
						IL_0009:
						while (true)
						{
							switch (num3 ^ -1684654584)
							{
							case 0:
								num3 = -1684654581;
								continue;
							case 1:
								num3 = -1684654579;
								continue;
							case 4:
								break;
							case 3:
								goto end_IL_0009;
							case 2:
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
							num3 = -1684654579;
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
						num3 = -1684654582;
						goto IL_0009;
					}
					return ControllerElementType.Axis;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					while (true)
					{
						int num2;
						int num3;
						if (num >= axisCount)
						{
							num2 = 749579828;
							num3 = num2;
						}
						else
						{
							num2 = 749579827;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x2CADAE32)
							{
							case 3:
								num2 = 749579827;
								continue;
							case 5:
								num++;
								num2 = 749579826;
								continue;
							case 7:
								axisRange = axes[num].sourceAxisRange;
								num2 = 749579824;
								continue;
							case 1:
								if (axes[num].elementIdentifier != elementIdentifier.id)
								{
									goto case 5;
								}
								switch (axes[num].sourceType)
								{
								case 1:
									break;
								case 100:
									num2 = 749579829;
									continue;
								case 0:
									axisRange = AxisRange.Positive;
									return true;
								default:
									throw new NotImplementedException();
								}
								goto case 7;
							case 0:
								break;
							case 2:
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 749579830;
									continue;
								}
								goto case 4;
							case 4:
								return true;
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
						int num = -1197277853;
						while (true)
						{
							switch (num ^ -1197277854)
							{
							case 2:
								break;
							case 1:
								elements = destination as Elements;
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
							num = -1197277855;
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
					while (true)
					{
						int num = -631427294;
						while (true)
						{
							switch (num ^ -631427293)
							{
							case 0:
								break;
							case 1:
								goto IL_0024;
							default:
								return button;
							}
							break;
							IL_0024:
							CopyVars(button);
							num = -631427295;
						}
					}
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Button button = destination as Button;
					while (true)
					{
						int num = 2099387806;
						while (true)
						{
							switch (num ^ 0x7D221D9F)
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
							num = 2099387805;
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
						int num = 459625661;
						while (true)
						{
							switch (num ^ 0x1B6554BC)
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
							num = 459625662;
						}
					}
				}
			}

			private sealed class wBKkyzMeBsUDBlMBqPdcpEVfmXI : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_Ouya_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int DDYxBxxbmWJbNSYkgbfofyjOaMo;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					wBKkyzMeBsUDBlMBqPdcpEVfmXI wBKkyzMeBsUDBlMBqPdcpEVfmXI2;
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						wBKkyzMeBsUDBlMBqPdcpEVfmXI2 = this;
					}
					else
					{
						while (true)
						{
							wBKkyzMeBsUDBlMBqPdcpEVfmXI2 = new wBKkyzMeBsUDBlMBqPdcpEVfmXI(0);
							int num = 2055544379;
							while (true)
							{
								switch (num ^ 0x7A851E38)
								{
								case 2:
									num = 2055544377;
									continue;
								case 1:
									break;
								case 3:
									wBKkyzMeBsUDBlMBqPdcpEVfmXI2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
									num = 2055544376;
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
					return wBKkyzMeBsUDBlMBqPdcpEVfmXI2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					case 1:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						DDYxBxxbmWJbNSYkgbfofyjOaMo++;
						num = -2068700171;
						goto IL_001f;
					case 0:
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements == null || syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes == null)
							{
								break;
							}
							DDYxBxxbmWJbNSYkgbfofyjOaMo = 0;
							num = -2068700175;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -2068700169)
							{
							case 3:
								num = -2068700170;
								continue;
							case 0:
								return true;
							case 5:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes[DDYxBxxbmWJbNSYkgbfofyjOaMo];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = -2068700169;
								continue;
							case 2:
								break;
							case 1:
								goto end_IL_001f;
							case 6:
								num = -2068700171;
								continue;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (DDYxBxxbmWJbNSYkgbfofyjOaMo >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes.Length)
							{
								num = -2068700173;
								num2 = num;
							}
							else
							{
								num = -2068700174;
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
				public wBKkyzMeBsUDBlMBqPdcpEVfmXI(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class FfFfYuxKUIzsQpBtfcJMauGcvyh : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_Ouya_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int qaruaLVpdtBfCXoDrejqinXCGQXE;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						goto IL_0023;
					}
					goto IL_0059;
					IL_0028:
					int num;
					FfFfYuxKUIzsQpBtfcJMauGcvyh ffFfYuxKUIzsQpBtfcJMauGcvyh = default(FfFfYuxKUIzsQpBtfcJMauGcvyh);
					while (true)
					{
						switch (num ^ -1800998282)
						{
						case 3:
							break;
						case 1:
							ffFfYuxKUIzsQpBtfcJMauGcvyh = this;
							num = -1800998282;
							continue;
						case 0:
							num = -1800998284;
							continue;
						case 4:
							goto IL_0059;
						default:
							return ffFfYuxKUIzsQpBtfcJMauGcvyh;
						}
						break;
					}
					goto IL_0023;
					IL_0059:
					ffFfYuxKUIzsQpBtfcJMauGcvyh = new FfFfYuxKUIzsQpBtfcJMauGcvyh(0);
					ffFfYuxKUIzsQpBtfcJMauGcvyh.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					num = -1800998284;
					goto IL_0028;
					IL_0023:
					num = -1800998281;
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
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					case 0:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						int num2;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null)
						{
							num = -687369436;
							num2 = num;
						}
						else
						{
							num = -687369439;
							num2 = num;
						}
						goto IL_001f;
					}
					case 1:
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							qaruaLVpdtBfCXoDrejqinXCGQXE++;
							num = -687369435;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -687369439)
							{
							case 2:
								num = -687369440;
								continue;
							case 1:
								break;
							case 4:
								goto IL_006c;
							case 3:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons[qaruaLVpdtBfCXoDrejqinXCGQXE];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 5:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons != null)
								{
									qaruaLVpdtBfCXoDrejqinXCGQXE = 0;
									num = -687369435;
									continue;
								}
								goto end_IL_0008;
							default:
								goto end_IL_0008;
							}
							break;
							IL_006c:
							int num3;
							if (qaruaLVpdtBfCXoDrejqinXCGQXE >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons.Length)
							{
								num = -687369439;
								num3 = num;
							}
							else
							{
								num = -687369438;
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
				public FfFfYuxKUIzsQpBtfcJMauGcvyh(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.RZICaWagIuKgaolDMOOypgwWFMH;

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
									num2 = -1328081422;
									num3 = num2;
								}
								else
								{
									num2 = -1328081417;
									num3 = num2;
								}
								while (true)
								{
									switch (num2 ^ -1328081421)
									{
									case 2:
										num2 = -1328081422;
										continue;
									case 1:
										_axesOrigGame[num] = axes_orig[num];
										num2 = -1328081421;
										continue;
									case 0:
										num++;
										num2 = -1328081424;
										continue;
									case 3:
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
								int num = -648804675;
								while (true)
								{
									switch (num ^ -648804674)
									{
									case 2:
										break;
									case 3:
										_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
										num2 = 0;
										num = -648804674;
										continue;
									case 0:
										num = -648804677;
										continue;
									case 1:
										_buttonsOrigGame[num2] = buttons_orig[num2];
										num2++;
										num = -648804677;
										continue;
									case 5:
										goto IL_0070;
									default:
										goto end_IL_0012;
									}
									break;
									IL_0070:
									int num3;
									if (num2 < buttons_orig.Length)
									{
										num = -648804673;
										num3 = num;
									}
									else
									{
										num = -648804678;
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
						goto IL_0008;
					}
					int num;
					if (matchingCriteria == null)
					{
						num = 465368929;
						goto IL_000d;
					}
					return matchingCriteria.isAllowed;
					IL_0008:
					num = 465368928;
					goto IL_000d;
					IL_000d:
					switch (num ^ 0x1BBCF761)
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

			internal override Elements_Base elements_base => elements;

			internal override IList<Platform> variants_base => null;

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
				wBKkyzMeBsUDBlMBqPdcpEVfmXI wBKkyzMeBsUDBlMBqPdcpEVfmXI2 = new wBKkyzMeBsUDBlMBqPdcpEVfmXI(-2);
				while (true)
				{
					int num = -1944019253;
					while (true)
					{
						switch (num ^ -1944019254)
						{
						case 0:
							break;
						case 1:
							goto IL_0026;
						default:
							return wBKkyzMeBsUDBlMBqPdcpEVfmXI2;
						}
						break;
						IL_0026:
						wBKkyzMeBsUDBlMBqPdcpEVfmXI2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
						num = -1944019256;
					}
				}
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				FfFfYuxKUIzsQpBtfcJMauGcvyh ffFfYuxKUIzsQpBtfcJMauGcvyh = new FfFfYuxKUIzsQpBtfcJMauGcvyh(-2);
				while (true)
				{
					int num = -1415141796;
					while (true)
					{
						switch (num ^ -1415141795)
						{
						case 2:
							break;
						case 1:
							goto IL_0026;
						default:
							return ffFfYuxKUIzsQpBtfcJMauGcvyh;
						}
						break;
						IL_0026:
						ffFfYuxKUIzsQpBtfcJMauGcvyh.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
						num = -1415141795;
					}
				}
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					goto IL_001d;
				}
				string[] array = new string[elements.axisCount];
				int num = -748818124;
				goto IL_0022;
				IL_0022:
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					switch (num ^ -748818121)
					{
					case 0:
						break;
					case 5:
					{
						int elementIdentifier = elements.axes[num2].elementIdentifier;
						num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						if (num3 >= 0)
						{
							int num4;
							if (num3 < identifiers.Length)
							{
								num = -748818128;
								num4 = num;
							}
							else
							{
								num = -748818127;
								num4 = num;
							}
							continue;
						}
						goto case 6;
					}
					case 6:
						Logger.LogError("Element identifier index is out of bounds!");
						num = -748818123;
						continue;
					case 1:
						return new string[0];
					case 7:
						array[num2] = identifiers[num3].name;
						num = -748818123;
						continue;
					case 3:
						num2 = 0;
						num = -748818125;
						continue;
					case 2:
						num2++;
						num = -748818125;
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
				goto IL_001d;
				IL_001d:
				num = -748818122;
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
				int num3 = default(int);
				while (num < array.Length)
				{
					while (true)
					{
						int elementIdentifier = elements.buttons[num].elementIdentifier;
						int num2 = -1012318457;
						while (true)
						{
							switch (num2 ^ -1012318457)
							{
							case 5:
								num2 = -1012318464;
								continue;
							case 3:
								break;
							case 2:
								array[num] = identifiers[num3].name;
								num2 = -1012318461;
								continue;
							case 7:
								goto end_IL_0036;
							case 1:
								Logger.LogError("Element identifier index is out of bounds!");
								num2 = -1012318461;
								continue;
							case 4:
								num++;
								num2 = -1012318463;
								continue;
							case 0:
								goto IL_00cd;
							default:
								goto end_IL_0091;
							}
							int num4;
							if (num3 < identifiers.Length)
							{
								num2 = -1012318459;
								num4 = num2;
							}
							else
							{
								num2 = -1012318458;
								num4 = num2;
							}
							continue;
							IL_00cd:
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							int num5;
							if (num3 >= 0)
							{
								num2 = -1012318460;
								num5 = num2;
							}
							else
							{
								num2 = -1012318458;
								num5 = num2;
							}
							continue;
							end_IL_0036:
							break;
						}
						continue;
						end_IL_0091:
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
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator.Current;
							int num;
							int num2;
							if (axis.elementIdentifier != elementIdentifierId)
							{
								num = -74383550;
								num2 = num;
							}
							else
							{
								num = -74383547;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ -74383551)
								{
								case 2:
									num = -74383552;
									continue;
								case 1:
									break;
								case 4:
									result = true;
									num = -74383551;
									continue;
								default:
									goto end_IL_0034;
								case 0:
									goto IL_0124;
								}
								break;
							}
							continue;
							end_IL_0034:
							break;
						}
					}
				}
				IEnumerator<Platform_Custom.Button> enumerator2 = IterateButtons().GetEnumerator();
				try
				{
					while (true)
					{
						IL_00d5:
						int num3;
						int num4;
						if (enumerator2.MoveNext())
						{
							num3 = -74383552;
							num4 = num3;
						}
						else
						{
							num3 = -74383550;
							num4 = num3;
						}
						while (true)
						{
							switch (num3 ^ -74383551)
							{
							case 0:
								goto IL_0092;
							default:
								goto end_IL_0097;
							case 1:
							{
								Button button = (Button)enumerator2.Current;
								if (button.elementIdentifier != elementIdentifierId)
								{
									break;
								}
								result = true;
								goto IL_0124;
							}
							case 2:
								break;
							case 3:
								goto end_IL_0097;
							}
							goto IL_00d5;
							IL_0092:
							num3 = -74383552;
							continue;
							end_IL_0097:
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
							IL_00f5:
							int num5 = -74383552;
							while (true)
							{
								switch (num5 ^ -74383551)
								{
								case 2:
									break;
								default:
									goto end_IL_00fa;
								case 1:
									goto IL_0113;
								case 0:
									goto end_IL_00fa;
								}
								goto IL_00f5;
								IL_0113:
								enumerator2.Dispose();
								num5 = -74383551;
								continue;
								end_IL_00fa:
								break;
							}
							break;
						}
					}
				}
				return false;
				IL_0124:
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
							num2 = 1930343985;
							num3 = num2;
						}
						else
						{
							num2 = 1930343987;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x730EB633)
							{
							case 4:
								num2 = 1930343985;
								continue;
							default:
								goto end_IL_002f;
							case 2:
							{
								Button button = (Button)enumerator.Current;
								buttons[num] = button.elementIdentifier;
								num2 = 1930343986;
								continue;
							}
							case 3:
								break;
							case 1:
								num++;
								num2 = 1930343984;
								continue;
							case 0:
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
							int num4 = 1930343985;
							while (true)
							{
								switch (num4 ^ 0x730EB633)
								{
								case 0:
									num4 = 1930343986;
									continue;
								case 1:
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
				finally
				{
					if (enumerator2 != null)
					{
						while (true)
						{
							IL_00fd:
							int num5 = 1930343986;
							while (true)
							{
								switch (num5 ^ 0x730EB633)
								{
								case 2:
									break;
								default:
									goto end_IL_0102;
								case 1:
									goto IL_011b;
								case 0:
									goto end_IL_0102;
								}
								goto IL_00fd;
								IL_011b:
								enumerator2.Dispose();
								num5 = 1930343987;
								continue;
								end_IL_0102:
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
				while (true)
				{
					int num2;
					int num3;
					if (num >= axes_orig.Length)
					{
						num2 = 1686817525;
						num3 = num2;
					}
					else
					{
						num2 = 1686817528;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x648ACAF1)
						{
						case 8:
							num2 = 1686817528;
							continue;
						case 9:
						{
							int num6;
							if (axes_orig[num].sourceType == 1)
							{
								num2 = 1686817521;
								num6 = num2;
							}
							else
							{
								num2 = 1686817531;
								num6 = num2;
							}
							continue;
						}
						case 3:
							throw new NotImplementedException();
						case 1:
							break;
						case 5:
							array[num].zero = axes_orig[num].axisZero;
							array[num].min = axes_orig[num].axisMin;
							array[num].max = axes_orig[num].axisMax;
							num2 = 1686817523;
							continue;
						case 0:
						{
							ref AxisCalibrationData reference2 = ref array[num];
							reference2 = AxisCalibrationData.Default;
							array[num].invert = axes_orig[num].invert;
							array[num].deadZone = axes_orig[num].axisDeadZone;
							num2 = 1686817527;
							continue;
						}
						case 6:
						{
							int num5;
							if (!Axes_orig[num].calibrateAxis)
							{
								num2 = 1686817523;
								num5 = num2;
							}
							else
							{
								num2 = 1686817524;
								num5 = num2;
							}
							continue;
						}
						case 2:
							array[num].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num].alternateCalibrations, deepClone: true);
							num++;
							num2 = 1686817520;
							continue;
						case 10:
						{
							int num4;
							if (axes_orig[num].sourceType == 100)
							{
								num2 = 1686817521;
								num4 = num2;
							}
							else
							{
								num2 = 1686817526;
								num4 = num2;
							}
							continue;
						}
						case 7:
							if (axes_orig[num].sourceType == 0)
							{
								ref AxisCalibrationData reference = ref array[num];
								reference = AxisCalibrationData.Default;
								num2 = 1686817523;
								continue;
							}
							goto case 3;
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
					int num = 228742173;
					while (true)
					{
						switch (num ^ 0xDA25417)
						{
						case 5:
							break;
						case 8:
						{
							int num4;
							if (Axes_orig[num2].sourceType != 0)
							{
								num = 228742166;
								num4 = num;
							}
							else
							{
								num = 228742172;
								num4 = num;
							}
							continue;
						}
						case 9:
							num2++;
							num = 228742160;
							continue;
						case 3:
							num = 228742160;
							continue;
						case 11:
							axisRanges[num2] = AxisRange.Full;
							num = 228742174;
							continue;
						case 1:
							throw new Exception();
						case 12:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, createIfNull: true);
							if (Axes_orig[num2].sourceType != 1)
							{
								int num3;
								if (Axes_orig[num2].sourceType == 100)
								{
									num = 228742163;
									num3 = num;
								}
								else
								{
									num = 228742175;
									num3 = num;
								}
								continue;
							}
							goto case 4;
						case 0:
							num2 = 0;
							num = 228742164;
							continue;
						case 4:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = 228742174;
							continue;
						case 10:
							if (Axes_orig == null)
							{
								return;
							}
							goto case 6;
						case 2:
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num = 228742167;
							continue;
						case 6:
							axisRanges = new AxisRange[Axes_orig.Length];
							num = 228742165;
							continue;
						default:
							if (num2 >= Axes_orig.Length)
							{
								return;
							}
							goto case 12;
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
					int num2 = -1563427267;
					while (true)
					{
						switch (num2 ^ -1563427268)
						{
						case 2:
							num2 = -1563427272;
							continue;
						case 0:
							num++;
							num2 = -1563427267;
							continue;
						case 3:
							buttonInfos[num] = MiscTools.DeepClone(Buttons_orig[num].buttonInfo, createIfNull: true);
							num2 = -1563427268;
							continue;
						case 4:
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

			public override object DeepClone()
			{
				Platform_Ouya_Base platform_Ouya_Base = new Platform_Ouya_Base();
				CopyVars(platform_Ouya_Base);
				return platform_Ouya_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (!(destination is Platform_Ouya_Base platform_Ouya_Base))
				{
					return;
				}
				while (true)
				{
					platform_Ouya_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					int num = 735327948;
					while (true)
					{
						switch (num ^ 0x2BD436CE)
						{
						case 0:
							num = 735327951;
							continue;
						default:
							return;
						case 1:
							break;
						case 2:
							platform_Ouya_Base.elements = MiscTools.DeepClone(elements);
							num = 735327949;
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
		public sealed class Platform_Ouya : Platform_Ouya_Base
		{
			public Platform_Ouya_Base[] variants;

			internal override IList<Platform> variants_base => variants;

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
						int num2 = -1830530841;
						while (true)
						{
							switch (num2 ^ -1830530844)
							{
							case 4:
								break;
							case 3:
								num2 = -1830530843;
								continue;
							case 0:
								goto IL_0046;
							case 1:
								goto IL_0075;
							default:
								goto end_IL_0019;
							}
							break;
							IL_0075:
							int num3;
							if (num < variants.Length)
							{
								num2 = -1830530844;
								num3 = num2;
							}
							else
							{
								num2 = -1830530842;
								num3 = num2;
							}
							continue;
							IL_0046:
							if (variants[num] != null && variants[num].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
							{
								variantIndex = num;
								return true;
							}
							num++;
							num2 = -1830530843;
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
				Platform_Ouya platform_Ouya = new Platform_Ouya();
				CopyVars(platform_Ouya);
				return platform_Ouya;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_Ouya platform_Ouya = destination as Platform_Ouya;
				while (true)
				{
					switch (0x2D5E40B1 ^ 0x2D5E40B0)
					{
					case 0:
						continue;
					case 1:
						if (platform_Ouya == null)
						{
							return;
						}
						break;
					}
					break;
				}
				platform_Ouya.variants = MiscTools.DeepClone(variants);
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
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						goto IL_0021;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					int num = -1889535991;
					goto IL_0026;
					IL_0021:
					num = -1889535998;
					goto IL_0026;
					IL_0026:
					string searchFor = default(string);
					int num2 = default(int);
					while (true)
					{
						switch (num ^ -1889535990)
						{
						case 0:
							break;
						case 7:
							searchFor = productName[num2];
							num = -1889535988;
							continue;
						case 9:
						{
							int num4;
							if (productName == null)
							{
								num = -1889535989;
								num4 = num;
							}
							else
							{
								num = -1889535992;
								num4 = num;
							}
							continue;
						}
						case 6:
							if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
							{
								return true;
							}
							num2++;
							num = -1889535986;
							continue;
						case 3:
							if (text == null)
							{
								text = string.Empty;
								num = -1889535985;
								continue;
							}
							goto case 5;
						case 2:
							num2 = 0;
							num = -1889535986;
							continue;
						case 5:
							text = text.Trim();
							num = -1889535997;
							continue;
						case 8:
							return true;
						case 4:
						{
							int num3;
							if (num2 < productName.Length)
							{
								num = -1889535987;
								num3 = num;
							}
							else
							{
								num = -1889535989;
								num3 = num;
							}
							continue;
						}
						default:
							return false;
						}
						break;
					}
					goto IL_0021;
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
						int num = 1385844528;
						while (true)
						{
							switch (num ^ 0x529A4F31)
							{
							case 3:
								break;
							default:
								return;
							case 1:
								matchingCriteria = destination as MatchingCriteria;
								num = 1385844531;
								continue;
							case 0:
								return;
							case 5:
								matchingCriteria.productName_useRegex = productName_useRegex;
								num = 1385844533;
								continue;
							case 2:
							{
								int num2;
								if (matchingCriteria != null)
								{
									num = 1385844532;
									num2 = num;
								}
								else
								{
									num = 1385844529;
									num2 = num;
								}
								continue;
							}
							case 4:
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								num = 1385844535;
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
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = 1112269314;
							goto IL_0009;
						}
						goto IL_0069;
						IL_0009:
						while (true)
						{
							switch (num3 ^ 0x424BE200)
							{
							case 0:
								num3 = 1112269316;
								continue;
							case 2:
								num3 = 1112269315;
								continue;
							case 1:
								break;
							case 5:
								goto IL_0047;
							case 4:
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
							num3 = 1112269315;
						}
						continue;
						IL_0069:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							break;
						}
						num++;
						num3 = 1112269313;
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
						IL_00f1:
						int num2;
						if (num >= axisCount)
						{
							axisRange = AxisRange.Full;
							num2 = 484058959;
							goto IL_000c;
						}
						goto IL_0040;
						IL_000c:
						while (true)
						{
							switch (num2 ^ 0x1CDA274D)
							{
							case 0:
								num2 = 484058949;
								continue;
							case 8:
								break;
							case 6:
								goto IL_0066;
							case 1:
								num++;
								num2 = 484058952;
								continue;
							case 4:
								goto IL_00a5;
							case 3:
								goto IL_00bc;
							case 7:
								goto IL_00e2;
							case 5:
								goto IL_00f1;
							default:
								return false;
							}
							break;
							IL_00e2:
							if (sourceType != 100)
							{
								throw new NotImplementedException();
							}
							num2 = 484058955;
							continue;
							IL_0066:
							axisRange = axes[num].sourceAxisRange;
							if (axes[num].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
								num2 = 484058953;
								continue;
							}
							goto IL_00a5;
							IL_00a5:
							return true;
							IL_00bc:
							sourceType = axes[num].sourceType;
							switch (sourceType)
							{
							case 1:
								break;
							case 0:
								axisRange = AxisRange.Positive;
								return true;
							default:
								num2 = 484058954;
								continue;
							}
							goto IL_0066;
						}
						goto IL_0040;
						IL_0040:
						int num3;
						if (axes[num].elementIdentifier != elementIdentifier.id)
						{
							num2 = 484058956;
							num3 = num2;
						}
						else
						{
							num2 = 484058958;
							num3 = num2;
						}
						goto IL_000c;
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
					if (!(destination is Elements elements))
					{
						return;
					}
					while (true)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						int num = 801425460;
						while (true)
						{
							switch (num ^ 0x2FC4C835)
							{
							case 3:
								num = 801425463;
								continue;
							default:
								return;
							case 2:
								break;
							case 1:
								elements.buttons = ArrayTools.DeepClone(buttons);
								num = 801425461;
								continue;
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

			private sealed class DxzCaRKciSHTLeaJFLLbQtudGoJP : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_XboxOne_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int HjVrVeefywRLCrhBVPZGnmSdfiw;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
					{
						goto IL_0012;
					}
					goto IL_0052;
					IL_0012:
					int num = 1121212158;
					goto IL_0017;
					IL_0017:
					DxzCaRKciSHTLeaJFLLbQtudGoJP dxzCaRKciSHTLeaJFLLbQtudGoJP = default(DxzCaRKciSHTLeaJFLLbQtudGoJP);
					while (true)
					{
						switch (num ^ 0x42D456FD)
						{
						case 2:
							break;
						case 3:
							if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
							{
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								dxzCaRKciSHTLeaJFLLbQtudGoJP = this;
								num = 1121212153;
								continue;
							}
							goto IL_0052;
						case 1:
							goto IL_0052;
						case 4:
							num = 1121212157;
							continue;
						default:
							return dxzCaRKciSHTLeaJFLLbQtudGoJP;
						}
						break;
					}
					goto IL_0012;
					IL_0052:
					dxzCaRKciSHTLeaJFLLbQtudGoJP = new DxzCaRKciSHTLeaJFLLbQtudGoJP(0);
					dxzCaRKciSHTLeaJFLLbQtudGoJP.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					num = 1121212157;
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
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					case 1:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = -208634569;
						goto IL_001f;
					case 0:
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							num = -208634572;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -208634570)
							{
							case 3:
								num = -208634576;
								continue;
							case 7:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 2:
								break;
							case 4:
								goto IL_0088;
							case 6:
								goto end_IL_001f;
							case 8:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes != null)
								{
									HjVrVeefywRLCrhBVPZGnmSdfiw = 0;
									num = -208634574;
									continue;
								}
								goto end_IL_0008;
							case 1:
								HjVrVeefywRLCrhBVPZGnmSdfiw++;
								num = -208634574;
								continue;
							case 0:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes[HjVrVeefywRLCrhBVPZGnmSdfiw];
								num = -208634575;
								continue;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null)
							{
								num = -208634562;
								num2 = num;
							}
							else
							{
								num = -208634573;
								num2 = num;
							}
							continue;
							IL_0088:
							int num3;
							if (HjVrVeefywRLCrhBVPZGnmSdfiw >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes.Length)
							{
								num = -208634573;
								num3 = num;
							}
							else
							{
								num = -208634570;
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
				public DxzCaRKciSHTLeaJFLLbQtudGoJP(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class FmeaBvIbuUHIWcMwHfaGQdDlFFvi : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_XboxOne_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int mkBWHVPNPJzYQPpfeUsqkmmxbYh;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					FmeaBvIbuUHIWcMwHfaGQdDlFFvi fmeaBvIbuUHIWcMwHfaGQdDlFFvi;
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						fmeaBvIbuUHIWcMwHfaGQdDlFFvi = this;
					}
					else
					{
						while (true)
						{
							fmeaBvIbuUHIWcMwHfaGQdDlFFvi = new FmeaBvIbuUHIWcMwHfaGQdDlFFvi(0);
							int num = -1921257911;
							while (true)
							{
								switch (num ^ -1921257910)
								{
								case 0:
									num = -1921257912;
									continue;
								case 2:
									break;
								case 3:
									fmeaBvIbuUHIWcMwHfaGQdDlFFvi.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
									num = -1921257909;
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
					return fmeaBvIbuUHIWcMwHfaGQdDlFFvi;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = -2032458172;
						while (true)
						{
							switch (num2 ^ -2032458173)
							{
							case 2:
								break;
							case 7:
								switch (num)
								{
								default:
									num2 = -2032458174;
									continue;
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									mkBWHVPNPJzYQPpfeUsqkmmxbYh++;
									num2 = -2032458171;
									continue;
								case 0:
									break;
								}
								goto case 3;
							case 4:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons[mkBWHVPNPJzYQPpfeUsqkmmxbYh];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 5:
								mkBWHVPNPJzYQPpfeUsqkmmxbYh = 0;
								num2 = -2032458173;
								continue;
							case 6:
							{
								int num3;
								if (mkBWHVPNPJzYQPpfeUsqkmmxbYh < syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons.Length)
								{
									num2 = -2032458169;
									num3 = num2;
								}
								else
								{
									num2 = -2032458174;
									num3 = num2;
								}
								continue;
							}
							case 0:
								num2 = -2032458171;
								continue;
							case 3:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null)
								{
									int num4;
									if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons != null)
									{
										num2 = -2032458170;
										num4 = num2;
									}
									else
									{
										num2 = -2032458174;
										num4 = num2;
									}
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
				public FmeaBvIbuUHIWcMwHfaGQdDlFFvi(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.QAbfXJnvPJiIZJfOVOFDonsOFob;

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
							int num = -1921553213;
							while (true)
							{
								switch (num ^ -1921553210)
								{
								case 4:
									break;
								case 0:
									goto IL_0032;
								case 1:
									_axesOrigGame[num2] = axes_orig[num2];
									num = -1921553212;
									continue;
								case 5:
									axes_orig = Axes_orig;
									if (axes_orig != null)
									{
										_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
										num2 = 0;
										num = -1921553210;
										continue;
									}
									goto end_IL_0008;
								case 2:
									num2++;
									num = -1921553210;
									continue;
								default:
									goto end_IL_0008;
								}
								break;
								IL_0032:
								int num3;
								if (num2 >= axes_orig.Length)
								{
									num = -1921553211;
									num3 = num;
								}
								else
								{
									num = -1921553209;
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
						Button[] buttons_orig = default(Button[]);
						int num2 = default(int);
						while (true)
						{
							int num = 1814622666;
							while (true)
							{
								switch (num ^ 0x6C28F1CB)
								{
								case 0:
									break;
								case 1:
									buttons_orig = Buttons_orig;
									if (buttons_orig != null)
									{
										_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
										num2 = 0;
										num = 1814622664;
										continue;
									}
									goto end_IL_0008;
								case 3:
									goto IL_004f;
								case 4:
									_buttonsOrigGame[num2] = buttons_orig[num2];
									num2++;
									num = 1814622664;
									continue;
								default:
									goto end_IL_0008;
								}
								break;
								IL_004f:
								int num3;
								if (num2 >= buttons_orig.Length)
								{
									num = 1814622665;
									num3 = num;
								}
								else
								{
									num = 1814622671;
									num3 = num;
								}
							}
							continue;
							end_IL_0008:
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

			internal override Elements_Base elements_base => elements;

			internal override IList<Platform> variants_base => null;

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
				DxzCaRKciSHTLeaJFLLbQtudGoJP dxzCaRKciSHTLeaJFLLbQtudGoJP = new DxzCaRKciSHTLeaJFLLbQtudGoJP(-2);
				dxzCaRKciSHTLeaJFLLbQtudGoJP.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return dxzCaRKciSHTLeaJFLLbQtudGoJP;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				FmeaBvIbuUHIWcMwHfaGQdDlFFvi fmeaBvIbuUHIWcMwHfaGQdDlFFvi = new FmeaBvIbuUHIWcMwHfaGQdDlFFvi(-2);
				fmeaBvIbuUHIWcMwHfaGQdDlFFvi.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return fmeaBvIbuUHIWcMwHfaGQdDlFFvi;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					goto IL_0010;
				}
				string[] array = new string[elements.axisCount];
				int num = -1590874441;
				goto IL_0015;
				IL_0015:
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					switch (num ^ -1590874446)
					{
					case 6:
						break;
					case 2:
						Logger.LogError("You have too few element identifiers!");
						return new string[0];
					case 7:
					{
						int elementIdentifier = elements.axes[num2].elementIdentifier;
						num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						if (num3 >= 0)
						{
							int num4;
							if (num3 >= identifiers.Length)
							{
								num = -1590874442;
								num4 = num;
							}
							else
							{
								num = -1590874445;
								num4 = num;
							}
							continue;
						}
						goto case 4;
					}
					case 0:
						num2++;
						num = -1590874447;
						continue;
					case 5:
						num2 = 0;
						num = -1590874447;
						continue;
					case 1:
						array[num2] = identifiers[num3].name;
						num = -1590874446;
						continue;
					case 4:
						Logger.LogError("Element identifier index is out of bounds!");
						num = -1590874446;
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
				goto IL_0010;
				IL_0010:
				num = -1590874448;
				goto IL_0015;
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
				int elementIdentifier = default(int);
				int num4 = default(int);
				while (true)
				{
					int num2;
					int num3;
					if (num < array.Length)
					{
						num2 = 1281859344;
						num3 = num2;
					}
					else
					{
						num2 = 1281859357;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x4C679F19)
						{
						case 8:
							num2 = 1281859344;
							continue;
						case 9:
							elementIdentifier = elements.buttons[num].elementIdentifier;
							num2 = 1281859355;
							continue;
						case 7:
							num++;
							num2 = 1281859359;
							continue;
						case 1:
						{
							int num6;
							if (num4 >= identifiers.Length)
							{
								num2 = 1281859354;
								num6 = num2;
							}
							else
							{
								num2 = 1281859356;
								num6 = num2;
							}
							continue;
						}
						case 0:
						{
							int num5;
							if (num4 < 0)
							{
								num2 = 1281859354;
								num5 = num2;
							}
							else
							{
								num2 = 1281859352;
								num5 = num2;
							}
							continue;
						}
						case 6:
							break;
						case 3:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = 1281859358;
							continue;
						case 5:
							array[num] = identifiers[num4].name;
							num2 = 1281859358;
							continue;
						case 2:
							num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num2 = 1281859353;
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
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				foreach (Button item2 in IterateButtons())
				{
					if (item2.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				int num2 = default(int);
				while (true)
				{
					int num = -527691082;
					while (true)
					{
						switch (num ^ -527691081)
						{
						case 2:
							break;
						case 1:
							axes = new int[assignedAxisCount];
							num = -527691081;
							continue;
						case 0:
							num2 = 0;
							num = -527691084;
							continue;
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
										int num3 = -527691082;
										while (true)
										{
											switch (num3 ^ -527691081)
											{
											case 3:
												num3 = -527691083;
												continue;
											case 2:
												break;
											case 1:
												num2++;
												num3 = -527691081;
												continue;
											default:
												goto end_IL_007c;
											}
											break;
										}
										continue;
										end_IL_007c:
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
										axes[num2] = axis.elementIdentifier;
										num2++;
										int num4 = -527691082;
										while (true)
										{
											switch (num4 ^ -527691081)
											{
											case 0:
												num4 = -527691083;
												continue;
											case 2:
												break;
											default:
												goto end_IL_00e7;
											}
											break;
										}
										continue;
										end_IL_00e7:
										break;
									}
								}
								return;
							}
						}
						}
						break;
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
				int num = -351907637;
				goto IL_0012;
				IL_0012:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ -351907647)
					{
					case 7:
						break;
					case 5:
						if (Axes_orig[num2].calibrateAxis)
						{
							array[num2].zero = axes_orig[num2].axisZero;
							array[num2].min = axes_orig[num2].axisMin;
							array[num2].max = axes_orig[num2].axisMax;
							num = -351907647;
							continue;
						}
						goto case 9;
					case 6:
						if (axes_orig[num2].sourceType == 0)
						{
							ref AxisCalibrationData reference2 = ref array[num2];
							reference2 = AxisCalibrationData.Default;
							num = -351907640;
							continue;
						}
						goto case 4;
					case 9:
						array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, deepClone: true);
						num2++;
						num = -351907646;
						continue;
					case 0:
						num = -351907640;
						continue;
					case 1:
						return null;
					case 4:
						throw new NotImplementedException();
					case 10:
						num2 = 0;
						num = -351907646;
						continue;
					case 8:
					{
						int num4;
						if (axes_orig[num2].sourceType != 100)
						{
							num = -351907641;
							num4 = num;
						}
						else
						{
							num = -351907645;
							num4 = num;
						}
						continue;
					}
					case 11:
					{
						int num3;
						if (axes_orig[num2].sourceType != 1)
						{
							num = -351907639;
							num3 = num;
						}
						else
						{
							num = -351907645;
							num3 = num;
						}
						continue;
					}
					case 2:
					{
						ref AxisCalibrationData reference = ref array[num2];
						reference = AxisCalibrationData.Default;
						array[num2].invert = axes_orig[num2].invert;
						array[num2].deadZone = axes_orig[num2].axisDeadZone;
						num = -351907644;
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
				goto IL_000d;
				IL_000d:
				num = -351907648;
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
					int num = -931470250;
					while (true)
					{
						switch (num ^ -931470241)
						{
						case 8:
							num = -931470245;
							continue;
						default:
							return;
						case 2:
							num2++;
							num = -931470244;
							continue;
						case 1:
						{
							int num5;
							if (Axes_orig[num2].sourceType != 0)
							{
								num = -931470246;
								num5 = num;
							}
							else
							{
								num = -931470248;
								num5 = num;
							}
							continue;
						}
						case 9:
							num2 = 0;
							num = -931470244;
							continue;
						case 4:
							break;
						case 7:
							axisRanges[num2] = AxisRange.Full;
							num = -931470243;
							continue;
						case 10:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, createIfNull: true);
							if (Axes_orig[num2].sourceType != 1)
							{
								int num4;
								if (Axes_orig[num2].sourceType == 100)
								{
									num = -931470247;
									num4 = num;
								}
								else
								{
									num = -931470242;
									num4 = num;
								}
								continue;
							}
							goto case 6;
						case 5:
							throw new Exception();
						case 3:
						{
							int num3;
							if (num2 >= Axes_orig.Length)
							{
								num = -931470241;
								num3 = num;
							}
							else
							{
								num = -931470251;
								num3 = num;
							}
							continue;
						}
						case 6:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -931470243;
							continue;
						case 0:
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
					int num2 = -1510090225;
					while (true)
					{
						switch (num2 ^ -1510090226)
						{
						case 3:
							num2 = -1510090228;
							continue;
						case 4:
							buttonInfos[num] = MiscTools.DeepClone(Buttons_orig[num].buttonInfo, createIfNull: true);
							num++;
							num2 = -1510090226;
							continue;
						case 1:
							num2 = -1510090226;
							continue;
						case 2:
							break;
						default:
							if (num >= Buttons_orig.Length)
							{
								return;
							}
							goto case 4;
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
						switch (-1869055959 ^ -1869055960)
						{
						case 2:
							continue;
						case 1:
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

			internal override IList<Platform> variants_base => variants;

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
						int num = 1032594954;
						while (true)
						{
							switch (num ^ 0x3D8C2609)
							{
							case 2:
								break;
							case 1:
								goto IL_003d;
							case 0:
								goto IL_0059;
							case 3:
								num2 = 0;
								num = 1032594952;
								continue;
							default:
								goto end_IL_0017;
							}
							break;
							IL_0059:
							if (variants[num2] != null && variants[num2].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
							{
								variantIndex = num2;
								return true;
							}
							num2++;
							num = 1032594952;
							continue;
							IL_003d:
							int num3;
							if (num2 >= variants.Length)
							{
								num = 1032594957;
								num3 = num;
							}
							else
							{
								num = 1032594953;
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
				while (true)
				{
					int num = -2000514309;
					while (true)
					{
						switch (num ^ -2000514311)
						{
						case 0:
							break;
						case 2:
							goto IL_0024;
						default:
							return platform_XboxOne;
						}
						break;
						IL_0024:
						CopyVars(platform_XboxOne);
						num = -2000514312;
					}
				}
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (!(destination is Platform_XboxOne platform_XboxOne))
				{
					return;
				}
				while (true)
				{
					platform_XboxOne.variants = MiscTools.DeepClone(variants);
					int num = -1036754870;
					while (true)
					{
						switch (num ^ -1036754870)
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
						num = -1036754869;
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
							goto IL_0008;
						}
						int num;
						if (productName != null && productName.Length > 0)
						{
							num = -1055379570;
							goto IL_000d;
						}
						return false;
						IL_000d:
						switch (num ^ -1055379570)
						{
						case 2:
							break;
						case 1:
							return true;
						default:
							return true;
						}
						goto IL_0008;
						IL_0008:
						num = -1055379569;
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
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						goto IL_0024;
					}
					int num;
					string text = default(string);
					if (alwaysMatch)
					{
						num = 1843356007;
					}
					else
					{
						text = bridgedControllerHWInfo.hw_productName;
						num = 1843356005;
					}
					goto IL_0029;
					IL_0024:
					num = 1843356002;
					goto IL_0029;
					IL_0029:
					int num2 = default(int);
					while (true)
					{
						switch (num ^ 0x6DDF6165)
						{
						case 8:
							break;
						case 7:
							return false;
						case 0:
							if (text == null)
							{
								text = string.Empty;
								num = 1843356001;
								continue;
							}
							goto case 4;
						case 5:
							num = 1843356004;
							continue;
						case 2:
							return true;
						case 1:
						{
							int num3;
							if (num2 < productName.Length)
							{
								num = 1843356006;
								num3 = num;
							}
							else
							{
								num = 1843356003;
								num3 = num;
							}
							continue;
						}
						case 3:
						{
							string searchFor = productName[num2];
							if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
							{
								return true;
							}
							num2++;
							num = 1843356004;
							continue;
						}
						case 4:
							text = text.Trim();
							if (productName != null)
							{
								num2 = 0;
								num = 1843356000;
								continue;
							}
							goto default;
						default:
							return false;
						}
						break;
					}
					goto IL_0024;
				}

				public override object DeepClone()
				{
					MatchingCriteria matchingCriteria = new MatchingCriteria();
					while (true)
					{
						int num = -1389817510;
						while (true)
						{
							switch (num ^ -1389817512)
							{
							case 0:
								break;
							case 2:
								goto IL_0024;
							default:
								return matchingCriteria;
							}
							break;
							IL_0024:
							CopyVars(matchingCriteria);
							num = -1389817511;
						}
					}
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
					base.CopyVars(destination);
					if (!(destination is MatchingCriteria matchingCriteria))
					{
						return;
					}
					while (true)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						int num = -1819546294;
						while (true)
						{
							switch (num ^ -1819546294)
							{
							case 2:
								num = -1819546293;
								continue;
							default:
								return;
							case 1:
								break;
							case 0:
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								num = -1819546295;
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
							num2 = 1133731865;
							num3 = num2;
						}
						else
						{
							num2 = 1133731871;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x4393601C)
							{
							case 0:
								num2 = 1133731871;
								continue;
							case 5:
								num4 = 0;
								num2 = 1133731870;
								continue;
							case 2:
							{
								int num5;
								if (num4 < buttonCount)
								{
									num2 = 1133731869;
									num5 = num2;
								}
								else
								{
									num2 = 1133731864;
									num5 = num2;
								}
								continue;
							}
							case 3:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = 1133731866;
								continue;
							case 1:
								if (buttons[num4].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num4++;
								num2 = 1133731870;
								continue;
							case 6:
								break;
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
							IL_0057:
							int num2;
							if (axes[num].elementIdentifier == elementIdentifier.id)
							{
								sourceType = axes[num].sourceType;
								num2 = 73470739;
								goto IL_000c;
							}
							goto IL_004c;
							IL_000c:
							while (true)
							{
								switch (num2 ^ 0x4611313)
								{
								case 8:
									num2 = 73470741;
									continue;
								case 4:
									return true;
								case 1:
									break;
								case 6:
									goto IL_0057;
								case 2:
									goto IL_0081;
								case 7:
									return true;
								case 5:
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 73470743;
									continue;
								case 0:
									goto IL_00d8;
								default:
									goto end_IL_0057;
								}
								break;
								IL_00d8:
								switch (sourceType)
								{
								case 0:
									axisRange = AxisRange.Positive;
									num2 = 73470740;
									continue;
								case 1:
									break;
								default:
									throw new NotImplementedException();
								case 100:
									num2 = 73470737;
									continue;
								}
								goto IL_0081;
								IL_0081:
								axisRange = axes[num].sourceAxisRange;
								int num3;
								if (!axes[num].invert)
								{
									num2 = 73470743;
									num3 = num2;
								}
								else
								{
									num2 = 73470742;
									num3 = num2;
								}
							}
							goto IL_004c;
							IL_004c:
							num++;
							num2 = 73470736;
							goto IL_000c;
							continue;
							end_IL_0057:
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
						int num = -1016569415;
						while (true)
						{
							switch (num ^ -1016569413)
							{
							case 0:
								break;
							case 2:
								elements = destination as Elements;
								if (elements != null)
								{
									goto IL_003b;
								}
								return;
							case 3:
								goto IL_003b;
							default:
								elements.buttons = ArrayTools.DeepClone(buttons);
								return;
							}
							break;
							IL_003b:
							elements.axes = ArrayTools.DeepClone(axes);
							num = -1016569414;
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

			private sealed class RjABdMsenEpAeqGOzpTEWGCTSsz : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_PS4_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int qgMRwCEtqGaOUINGNwqvNASGhbh;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						goto IL_0023;
					}
					goto IL_0049;
					IL_0028:
					int num;
					RjABdMsenEpAeqGOzpTEWGCTSsz rjABdMsenEpAeqGOzpTEWGCTSsz = default(RjABdMsenEpAeqGOzpTEWGCTSsz);
					while (true)
					{
						switch (num ^ 0x3B676E17)
						{
						case 0:
							break;
						case 1:
							goto IL_0049;
						case 2:
							num = 996634132;
							continue;
						case 4:
							rjABdMsenEpAeqGOzpTEWGCTSsz = this;
							num = 996634133;
							continue;
						default:
							return rjABdMsenEpAeqGOzpTEWGCTSsz;
						}
						break;
					}
					goto IL_0023;
					IL_0049:
					rjABdMsenEpAeqGOzpTEWGCTSsz = new RjABdMsenEpAeqGOzpTEWGCTSsz(0);
					rjABdMsenEpAeqGOzpTEWGCTSsz.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					num = 996634132;
					goto IL_0028;
					IL_0023:
					num = 996634131;
					goto IL_0028;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = -1413727599;
						while (true)
						{
							switch (num2 ^ -1413727600)
							{
							case 0:
								break;
							case 1:
								switch (num)
								{
								default:
									num2 = -1413727595;
									continue;
								case 0:
									break;
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									qgMRwCEtqGaOUINGNwqvNASGhbh++;
									num2 = -1413727597;
									continue;
								}
								goto case 2;
							case 2:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null)
								{
									int num4;
									if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes == null)
									{
										num2 = -1413727595;
										num4 = num2;
									}
									else
									{
										num2 = -1413727593;
										num4 = num2;
									}
									continue;
								}
								goto default;
							case 3:
							{
								int num3;
								if (qgMRwCEtqGaOUINGNwqvNASGhbh >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes.Length)
								{
									num2 = -1413727595;
									num3 = num2;
								}
								else
								{
									num2 = -1413727596;
									num3 = num2;
								}
								continue;
							}
							case 6:
								return true;
							case 4:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes[qgMRwCEtqGaOUINGNwqvNASGhbh];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num2 = -1413727594;
								continue;
							case 7:
								qgMRwCEtqGaOUINGNwqvNASGhbh = 0;
								num2 = -1413727597;
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
				public RjABdMsenEpAeqGOzpTEWGCTSsz(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class ZJOQQQxGISahcGEoJUYjuXDVJlqp : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_PS4_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int KTmuSayhrnYdBDuflrKcWYLDQQU;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					ZJOQQQxGISahcGEoJUYjuXDVJlqp zJOQQQxGISahcGEoJUYjuXDVJlqp;
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						zJOQQQxGISahcGEoJUYjuXDVJlqp = this;
					}
					else
					{
						while (true)
						{
							zJOQQQxGISahcGEoJUYjuXDVJlqp = new ZJOQQQxGISahcGEoJUYjuXDVJlqp(0);
							zJOQQQxGISahcGEoJUYjuXDVJlqp.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
							int num = -887790480;
							while (true)
							{
								switch (num ^ -887790478)
								{
								case 0:
									num = -887790477;
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
					return zJOQQQxGISahcGEoJUYjuXDVJlqp;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					case 0:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements == null)
						{
							break;
						}
						int num2;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons == null)
						{
							num = -1415443544;
							num2 = num;
						}
						else
						{
							num = -1415443538;
							num2 = num;
						}
						goto IL_001f;
					}
					case 1:
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							KTmuSayhrnYdBDuflrKcWYLDQQU++;
							num = -1415443541;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -1415443541)
							{
							case 4:
								num = -1415443543;
								continue;
							case 2:
								break;
							case 1:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons[KTmuSayhrnYdBDuflrKcWYLDQQU];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 5:
								KTmuSayhrnYdBDuflrKcWYLDQQU = 0;
								num = -1415443541;
								continue;
							case 0:
								goto IL_00d7;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00d7:
							int num3;
							if (KTmuSayhrnYdBDuflrKcWYLDQQU < syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons.Length)
							{
								num = -1415443542;
								num3 = num;
							}
							else
							{
								num = -1415443544;
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
				public ZJOQQQxGISahcGEoJUYjuXDVJlqp(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.HglRpaPpklgbSOuqnDvBSmwGtUX;

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
							int num = -352932962;
							while (true)
							{
								switch (num ^ -352932963)
								{
								case 4:
									break;
								case 0:
									goto IL_0032;
								case 2:
									num2 = 0;
									num = -352932963;
									continue;
								case 3:
									axes_orig = Axes_orig;
									if (axes_orig != null)
									{
										_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
										num = -352932961;
										continue;
									}
									goto end_IL_0008;
								case 5:
									_axesOrigGame[num2] = axes_orig[num2];
									num2++;
									num = -352932963;
									continue;
								default:
									goto end_IL_0008;
								}
								break;
								IL_0032:
								int num3;
								if (num2 >= axes_orig.Length)
								{
									num = -352932964;
									num3 = num;
								}
								else
								{
									num = -352932968;
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
						int num2 = default(int);
						Button[] buttons_orig = default(Button[]);
						while (true)
						{
							int num = 487995329;
							while (true)
							{
								switch (num ^ 0x1D1637C7)
								{
								case 0:
									break;
								case 2:
									_buttonsOrigGame[num2] = buttons_orig[num2];
									num = 487995334;
									continue;
								case 5:
									if (buttons_orig != null)
									{
										_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
										num2 = 0;
										num = 487995332;
										continue;
									}
									goto end_IL_000b;
								case 1:
									num2++;
									num = 487995332;
									continue;
								case 3:
									goto IL_0070;
								case 6:
									buttons_orig = Buttons_orig;
									num = 487995330;
									continue;
								default:
									goto end_IL_000b;
								}
								break;
								IL_0070:
								int num3;
								if (num2 >= buttons_orig.Length)
								{
									num = 487995331;
									num3 = num;
								}
								else
								{
									num = 487995333;
									num3 = num;
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
						goto IL_0017;
					}
					int num;
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						num = -1210273621;
						goto IL_001c;
					}
					return true;
					IL_0017:
					num = -1210273624;
					goto IL_001c;
					IL_001c:
					switch (num ^ -1210273623)
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

			internal override Elements_Base elements_base => elements;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null)
				{
					while (true)
					{
						int num = 560890845;
						while (true)
						{
							switch (num ^ 0x216E83DC)
							{
							case 2:
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
							num = 560890844;
						}
						continue;
						end_IL_000f:
						break;
					}
				}
				return false;
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				RjABdMsenEpAeqGOzpTEWGCTSsz rjABdMsenEpAeqGOzpTEWGCTSsz = new RjABdMsenEpAeqGOzpTEWGCTSsz(-2);
				rjABdMsenEpAeqGOzpTEWGCTSsz.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return rjABdMsenEpAeqGOzpTEWGCTSsz;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				ZJOQQQxGISahcGEoJUYjuXDVJlqp zJOQQQxGISahcGEoJUYjuXDVJlqp = new ZJOQQQxGISahcGEoJUYjuXDVJlqp(-2);
				zJOQQQxGISahcGEoJUYjuXDVJlqp.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return zJOQQQxGISahcGEoJUYjuXDVJlqp;
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
				int num2 = 152904570;
				goto IL_001f;
				IL_001f:
				int num3 = default(int);
				while (true)
				{
					switch (num2 ^ 0x91D237C)
					{
					case 3:
						break;
					case 7:
						return new string[0];
					case 5:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = 152904574;
						continue;
					case 0:
					{
						int num4;
						if (num3 >= identifiers.Length)
						{
							num2 = 152904569;
							num4 = num2;
						}
						else
						{
							num2 = 152904564;
							num4 = num2;
						}
						continue;
					}
					case 1:
						num++;
						num2 = 152904570;
						continue;
					case 2:
						num2 = 152904573;
						continue;
					case 4:
					{
						int elementIdentifier = elements.axes[num].elementIdentifier;
						num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						int num5;
						if (num3 < 0)
						{
							num2 = 152904569;
							num5 = num2;
						}
						else
						{
							num2 = 152904572;
							num5 = num2;
						}
						continue;
					}
					case 8:
						array[num] = identifiers[num3].name;
						num2 = 152904573;
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
				goto IL_001a;
				IL_001a:
				num2 = 152904571;
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
				while (num < array.Length)
				{
					while (true)
					{
						int elementIdentifier = elements.buttons[num].elementIdentifier;
						int num2 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						int num3 = -55611273;
						while (true)
						{
							switch (num3 ^ -55611275)
							{
							case 4:
								num3 = -55611276;
								continue;
							case 7:
								Logger.LogError("Element identifier index is out of bounds!");
								num3 = -55611274;
								continue;
							case 2:
								break;
							case 8:
								goto IL_0091;
							case 0:
								num++;
								num3 = -55611280;
								continue;
							case 3:
								num3 = -55611275;
								continue;
							case 1:
								goto end_IL_0036;
							case 6:
								array[num] = identifiers[num2].name;
								num3 = -55611275;
								continue;
							default:
								goto end_IL_00be;
							}
							int num4;
							if (num2 < 0)
							{
								num3 = -55611278;
								num4 = num3;
							}
							else
							{
								num3 = -55611267;
								num4 = num3;
							}
							continue;
							IL_0091:
							int num5;
							if (num2 < identifiers.Length)
							{
								num3 = -55611277;
								num5 = num3;
							}
							else
							{
								num3 = -55611278;
								num5 = num3;
							}
							continue;
							end_IL_0036:
							break;
						}
						continue;
						end_IL_00be:
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
						IL_0057:
						int num;
						int num2;
						if (!enumerator.MoveNext())
						{
							num = 1146218364;
							num2 = num;
						}
						else
						{
							num = 1146218367;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x4451E77E)
							{
							case 3:
								num = 1146218367;
								continue;
							default:
								goto end_IL_0013;
							case 1:
								axis = (Axis)enumerator.Current;
								num = 1146218362;
								continue;
							case 0:
								break;
							case 4:
								if (axis.elementIdentifier == elementIdentifierId)
								{
									result = true;
									num = 1146218363;
									continue;
								}
								break;
							case 2:
								goto end_IL_0013;
							case 5:
								goto IL_00f5;
							}
							goto IL_0057;
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
				using (IEnumerator<Platform_Custom.Button> enumerator = IterateButtons().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Button button = (Button)enumerator.Current;
							buttons[num] = button.elementIdentifier;
							num++;
							int num2 = 704340457;
							while (true)
							{
								switch (num2 ^ 0x29FB61E9)
								{
								case 2:
									num2 = 704340456;
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
							int num3 = 704340456;
							while (true)
							{
								switch (num3 ^ 0x29FB61E9)
								{
								case 0:
									num3 = 704340459;
									continue;
								case 2:
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
						int num2;
						int num3;
						if (axes_orig[num].sourceType != 1)
						{
							num2 = -2104317881;
							num3 = num2;
						}
						else
						{
							num2 = -2104317883;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -2104317883)
							{
							case 6:
								num2 = -2104317884;
								continue;
							case 1:
								break;
							case 7:
								if (axes_orig[num].sourceType == 0)
								{
									ref AxisCalibrationData reference2 = ref array[num];
									reference2 = AxisCalibrationData.Default;
									num2 = -2104317887;
									continue;
								}
								goto case 10;
							case 3:
								if (Axes_orig[num].calibrateAxis)
								{
									array[num].zero = axes_orig[num].axisZero;
									num2 = -2104317888;
									continue;
								}
								goto case 4;
							case 0:
							{
								ref AxisCalibrationData reference = ref array[num];
								reference = AxisCalibrationData.Default;
								array[num].invert = axes_orig[num].invert;
								array[num].deadZone = axes_orig[num].axisDeadZone;
								num2 = -2104317882;
								continue;
							}
							case 10:
								throw new NotImplementedException();
							case 5:
								array[num].min = axes_orig[num].axisMin;
								array[num].max = axes_orig[num].axisMax;
								num2 = -2104317876;
								continue;
							case 2:
								goto IL_0153;
							case 4:
								array[num].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num].alternateCalibrations, deepClone: true);
								num++;
								num2 = -2104317875;
								continue;
							case 9:
								num2 = -2104317887;
								continue;
							default:
								goto end_IL_005d;
							}
							break;
							IL_0153:
							int num4;
							if (axes_orig[num].sourceType == 100)
							{
								num2 = -2104317883;
								num4 = num2;
							}
							else
							{
								num2 = -2104317886;
								num4 = num2;
							}
						}
						continue;
						end_IL_005d:
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
					int num = 2136639089;
					while (true)
					{
						switch (num ^ 0x7F5A8678)
						{
						case 10:
							break;
						case 3:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = 2136639103;
							continue;
						case 5:
							axisRanges = new AxisRange[Axes_orig.Length];
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = 2136639102;
							continue;
						case 4:
							throw new Exception();
						case 0:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, createIfNull: true);
							num = 2136639088;
							continue;
						case 2:
							num2++;
							num = 2136639102;
							continue;
						case 1:
							if (Axes_orig[num2].sourceType == 0)
							{
								axisRanges[num2] = AxisRange.Full;
								num = 2136639091;
								continue;
							}
							goto case 4;
						case 11:
							num = 2136639098;
							continue;
						case 8:
							if (Axes_orig[num2].sourceType != 1)
							{
								int num3;
								if (Axes_orig[num2].sourceType != 100)
								{
									num = 2136639097;
									num3 = num;
								}
								else
								{
									num = 2136639099;
									num3 = num;
								}
								continue;
							}
							goto case 3;
						case 9:
							if (Axes_orig == null)
							{
								return;
							}
							goto case 5;
						case 7:
							num = 2136639098;
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
					int num2 = 1514964534;
					while (true)
					{
						switch (num2 ^ 0x5A4C8634)
						{
						case 0:
							num2 = 1514964533;
							continue;
						case 1:
							break;
						case 3:
							buttonInfos[num] = MiscTools.DeepClone(Buttons_orig[num].buttonInfo, createIfNull: true);
							num++;
							num2 = 1514964534;
							continue;
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

			public override object DeepClone()
			{
				Platform_PS4_Base platform_PS4_Base = new Platform_PS4_Base();
				CopyVars(platform_PS4_Base);
				return platform_PS4_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (!(destination is Platform_PS4_Base platform_PS4_Base))
				{
					return;
				}
				while (true)
				{
					platform_PS4_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_PS4_Base.elements = MiscTools.DeepClone(elements);
					int num = 329113766;
					while (true)
					{
						switch (num ^ 0x139DE0A6)
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
						num = 329113767;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_PS4 : Platform_PS4_Base
		{
			public Platform_PS4_Base[] variants;

			internal override IList<Platform> variants_base => variants;

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
					num2 = -428714880;
					goto IL_0012;
				}
				goto IL_00b8;
				IL_0012:
				while (true)
				{
					switch (num2 ^ -428714873)
					{
					case 6:
						break;
					case 1:
						return true;
					case 5:
						return true;
					case 3:
						variantIndex = num;
						num2 = -428714878;
						continue;
					case 2:
						goto IL_0069;
					case 4:
						goto IL_0085;
					case 7:
						goto IL_0099;
					default:
						goto IL_00b8;
					}
					break;
					IL_0099:
					int num3;
					if (num < variants.Length)
					{
						num2 = -428714877;
						num3 = num2;
					}
					else
					{
						num2 = -428714873;
						num3 = num2;
					}
					continue;
					IL_0054:
					num++;
					num2 = -428714880;
					continue;
					IL_0069:
					if (variants[num].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						num2 = -428714876;
						continue;
					}
					goto IL_0054;
					IL_0085:
					if (variants[num] != null)
					{
						num2 = -428714875;
						continue;
					}
					goto IL_0054;
				}
				goto IL_000d;
				IL_00b8:
				return false;
				IL_000d:
				num2 = -428714874;
				goto IL_0012;
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
				if (destination is Platform_PS4 platform_PS)
				{
					platform_PS.variants = MiscTools.DeepClone(variants);
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
							goto IL_0008;
						}
						int num;
						if (productName != null)
						{
							num = 1068230319;
							goto IL_000d;
						}
						goto IL_0044;
						IL_0044:
						return false;
						IL_0037:
						if (productName.Length > 0)
						{
							return true;
						}
						goto IL_0044;
						IL_0008:
						num = 1068230316;
						goto IL_000d;
						IL_000d:
						switch (num ^ 0x3FABE6AD)
						{
						case 0:
							break;
						case 1:
							return true;
						default:
							goto IL_0037;
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
							goto IL_0008;
						}
						int num;
						if (disabled)
						{
							num = 1691043553;
							goto IL_000d;
						}
						return true;
						IL_0008:
						num = 1691043552;
						goto IL_000d;
						IL_000d:
						switch (num ^ 0x64CB46E1)
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
					if (alwaysMatch)
					{
						goto IL_0031;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					int num;
					int num2;
					if (text != null)
					{
						num = -412109458;
						num2 = num;
					}
					else
					{
						num = -412109461;
						num2 = num;
					}
					goto IL_0036;
					IL_0031:
					num = -412109469;
					goto IL_0036;
					IL_0036:
					int num3 = default(int);
					string searchFor = default(string);
					while (true)
					{
						switch (num ^ -412109463)
						{
						case 9:
							break;
						case 6:
						{
							int num5;
							if (productName == null)
							{
								num = -412109459;
								num5 = num;
							}
							else
							{
								num = -412109463;
								num5 = num;
							}
							continue;
						}
						case 5:
						{
							int num4;
							if (num3 < productName.Length)
							{
								num = -412109464;
								num4 = num;
							}
							else
							{
								num = -412109459;
								num4 = num;
							}
							continue;
						}
						case 7:
							text = text.Trim();
							num = -412109457;
							continue;
						case 3:
							num = -412109460;
							continue;
						case 10:
							return true;
						case 0:
							num3 = 0;
							num = -412109462;
							continue;
						case 8:
							if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
							{
								return true;
							}
							num3++;
							num = -412109460;
							continue;
						case 2:
							text = string.Empty;
							num = -412109458;
							continue;
						case 1:
							searchFor = productName[num3];
							num = -412109471;
							continue;
						default:
							return false;
						}
						break;
					}
					goto IL_0031;
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
						int num = -1618957735;
						while (true)
						{
							switch (num ^ -1618957734)
							{
							case 0:
								break;
							default:
								return;
							case 3:
								matchingCriteria = destination as MatchingCriteria;
								num = -1618957736;
								continue;
							case 2:
								if (matchingCriteria == null)
								{
									return;
								}
								goto case 1;
							case 1:
								matchingCriteria.productName_useRegex = productName_useRegex;
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								num = -1618957730;
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
						if (num < axisCount)
						{
							num2 = -1838397636;
							num3 = num2;
						}
						else
						{
							num2 = -1838397635;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -1838397639)
							{
							case 2:
								num2 = -1838397636;
								continue;
							case 5:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = -1838397639;
								continue;
							case 0:
								break;
							case 3:
								if (buttons[num4].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num4++;
								num2 = -1838397640;
								continue;
							case 4:
								num4 = 0;
								num2 = -1838397640;
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
					while (num < axisCount)
					{
						while (true)
						{
							int num2;
							int num3;
							if (axes[num].elementIdentifier != elementIdentifier.id)
							{
								num2 = 2100363935;
								num3 = num2;
							}
							else
							{
								num2 = 2100363934;
								num3 = num2;
							}
							while (true)
							{
								switch (num2 ^ 0x7D31029B)
								{
								case 7:
									num2 = 2100363933;
									continue;
								case 6:
									break;
								case 0:
									goto IL_0062;
								case 1:
									return true;
								case 2:
									if (axes[num].invert)
									{
										axisRange = InputTools.InvertAxisRange(axisRange);
										num2 = 2100363930;
										continue;
									}
									goto case 1;
								case 4:
									num++;
									num2 = 2100363928;
									continue;
								case 5:
									goto IL_00bc;
								default:
									goto end_IL_003c;
								}
								break;
								IL_00bc:
								switch (axes[num].sourceType)
								{
								case 1:
									break;
								case 0:
									axisRange = AxisRange.Positive;
									return true;
								default:
									throw new NotImplementedException();
								case 100:
									num2 = 2100363931;
									continue;
								}
								goto IL_0062;
								IL_0062:
								axisRange = axes[num].sourceAxisRange;
								num2 = 2100363929;
							}
							continue;
							end_IL_003c:
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
					if (!(destination is Elements elements))
					{
						return;
					}
					while (true)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
						int num = -390686353;
						while (true)
						{
							switch (num ^ -390686354)
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
							num = -390686356;
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

			private sealed class LmeeEeJaGtTJAuMTeIxkApjdCpkh : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_NintendoSwitch_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int YkbQIrJiWeGnzCunnlnCjsNaToMd;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					LmeeEeJaGtTJAuMTeIxkApjdCpkh lmeeEeJaGtTJAuMTeIxkApjdCpkh;
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						lmeeEeJaGtTJAuMTeIxkApjdCpkh = this;
					}
					else
					{
						while (true)
						{
							lmeeEeJaGtTJAuMTeIxkApjdCpkh = new LmeeEeJaGtTJAuMTeIxkApjdCpkh(0);
							int num = 771756870;
							while (true)
							{
								switch (num ^ 0x2E001346)
								{
								case 3:
									num = 771756871;
									continue;
								case 1:
									break;
								case 0:
									lmeeEeJaGtTJAuMTeIxkApjdCpkh.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
									num = 771756868;
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
					return lmeeEeJaGtTJAuMTeIxkApjdCpkh;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = -1136344493;
						while (true)
						{
							switch (num2 ^ -1136344490)
							{
							case 7:
								break;
							case 5:
								switch (num)
								{
								default:
									num2 = -1136344491;
									continue;
								case 0:
									break;
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									YkbQIrJiWeGnzCunnlnCjsNaToMd++;
									num2 = -1136344496;
									continue;
								}
								goto case 1;
							case 2:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes[YkbQIrJiWeGnzCunnlnCjsNaToMd];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num2 = -1136344494;
								continue;
							case 1:
							{
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								int num4;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements == null)
								{
									num2 = -1136344491;
									num4 = num2;
								}
								else
								{
									num2 = -1136344490;
									num4 = num2;
								}
								continue;
							}
							case 4:
								return true;
							case 0:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes != null)
								{
									YkbQIrJiWeGnzCunnlnCjsNaToMd = 0;
									num2 = -1136344496;
									continue;
								}
								goto default;
							case 6:
							{
								int num3;
								if (YkbQIrJiWeGnzCunnlnCjsNaToMd < syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes.Length)
								{
									num2 = -1136344492;
									num3 = num2;
								}
								else
								{
									num2 = -1136344491;
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
				public LmeeEeJaGtTJAuMTeIxkApjdCpkh(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class jYKqzkSCVOCHMIzufmqNPfYAiEuz : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_NintendoSwitch_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int wjCZdPtXWyfchOqsCwPxEGnVBzK;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
					{
						goto IL_0012;
					}
					goto IL_0052;
					IL_0012:
					int num = -42826753;
					goto IL_0017;
					IL_0017:
					jYKqzkSCVOCHMIzufmqNPfYAiEuz jYKqzkSCVOCHMIzufmqNPfYAiEuz2 = default(jYKqzkSCVOCHMIzufmqNPfYAiEuz);
					while (true)
					{
						switch (num ^ -42826754)
						{
						case 3:
							break;
						case 1:
							if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
							{
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								jYKqzkSCVOCHMIzufmqNPfYAiEuz2 = this;
								num = -42826756;
								continue;
							}
							goto IL_0052;
						case 0:
							goto IL_0052;
						case 2:
							num = -42826758;
							continue;
						default:
							return jYKqzkSCVOCHMIzufmqNPfYAiEuz2;
						}
						break;
					}
					goto IL_0012;
					IL_0052:
					jYKqzkSCVOCHMIzufmqNPfYAiEuz2 = new jYKqzkSCVOCHMIzufmqNPfYAiEuz(0);
					jYKqzkSCVOCHMIzufmqNPfYAiEuz2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					num = -42826758;
					goto IL_0017;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = 361331648;
						while (true)
						{
							switch (num2 ^ 0x15897BC4)
							{
							case 8:
								break;
							case 6:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons != null)
								{
									wjCZdPtXWyfchOqsCwPxEGnVBzK = 0;
									num2 = 361331651;
									continue;
								}
								goto default;
							case 7:
							{
								int num4;
								if (wjCZdPtXWyfchOqsCwPxEGnVBzK < syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons.Length)
								{
									num2 = 361331652;
									num4 = num2;
								}
								else
								{
									num2 = 361331654;
									num4 = num2;
								}
								continue;
							}
							case 4:
								switch (num)
								{
								default:
									num2 = 361331654;
									continue;
								case 0:
									break;
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									num2 = 361331653;
									continue;
								}
								goto case 5;
							case 3:
							{
								int num3;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements == null)
								{
									num2 = 361331654;
									num3 = num2;
								}
								else
								{
									num2 = 361331650;
									num3 = num2;
								}
								continue;
							}
							case 1:
								wjCZdPtXWyfchOqsCwPxEGnVBzK++;
								num2 = 361331651;
								continue;
							case 5:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num2 = 361331655;
								continue;
							case 0:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons[wjCZdPtXWyfchOqsCwPxEGnVBzK];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
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
				public jYKqzkSCVOCHMIzufmqNPfYAiEuz(int _003C_003E1__state)
				{
					while (true)
					{
						int num = 1714922617;
						while (true)
						{
							switch (num ^ 0x6637A478)
							{
							case 2:
								break;
							default:
								return;
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
								num = 1714922616;
								continue;
							case 0:
								TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
								num = 1714922619;
								continue;
							case 3:
								return;
							}
							break;
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

			internal override InputPlatform platform => InputPlatform.SzWkkyLAdSLqShzUrBqqoRHKOhW;

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
								int num = -613910586;
								while (true)
								{
									switch (num ^ -613910585)
									{
									case 0:
										break;
									case 3:
										goto IL_0046;
									case 2:
										_axesOrigGame[num2] = axes_orig[num2];
										num2++;
										num = -613910588;
										continue;
									case 1:
										num2 = 0;
										num = -613910588;
										continue;
									default:
										goto end_IL_0020;
									}
									break;
									IL_0046:
									int num3;
									if (num2 < axes_orig.Length)
									{
										num = -613910587;
										num3 = num;
									}
									else
									{
										num = -613910589;
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
						Button[] buttons_orig = default(Button[]);
						int num2 = default(int);
						while (true)
						{
							int num = -1460701103;
							while (true)
							{
								switch (num ^ -1460701099)
								{
								case 0:
									break;
								case 4:
									buttons_orig = Buttons_orig;
									if (buttons_orig != null)
									{
										_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
										num2 = 0;
										num = -1460701098;
										continue;
									}
									goto end_IL_0008;
								case 2:
									_buttonsOrigGame[num2] = buttons_orig[num2];
									num2++;
									num = -1460701098;
									continue;
								case 3:
									goto IL_0065;
								default:
									goto end_IL_0008;
								}
								break;
								IL_0065:
								int num3;
								if (num2 < buttons_orig.Length)
								{
									num = -1460701097;
									num3 = num;
								}
								else
								{
									num = -1460701100;
									num3 = num;
								}
							}
							continue;
							end_IL_0008:
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

			internal override Elements_Base elements_base => elements;

			internal override IList<Platform> variants_base => null;

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
				LmeeEeJaGtTJAuMTeIxkApjdCpkh lmeeEeJaGtTJAuMTeIxkApjdCpkh = new LmeeEeJaGtTJAuMTeIxkApjdCpkh(-2);
				lmeeEeJaGtTJAuMTeIxkApjdCpkh.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return lmeeEeJaGtTJAuMTeIxkApjdCpkh;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				jYKqzkSCVOCHMIzufmqNPfYAiEuz jYKqzkSCVOCHMIzufmqNPfYAiEuz2 = new jYKqzkSCVOCHMIzufmqNPfYAiEuz(-2);
				jYKqzkSCVOCHMIzufmqNPfYAiEuz2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return jYKqzkSCVOCHMIzufmqNPfYAiEuz2;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					goto IL_0010;
				}
				string[] array = new string[elements.axisCount];
				int num = 0;
				int num2 = -442784789;
				goto IL_0015;
				IL_0015:
				int num3 = default(int);
				while (true)
				{
					switch (num2 ^ -442784790)
					{
					case 3:
						break;
					case 7:
						Logger.LogError("You have too few element identifiers!");
						num2 = -442784785;
						continue;
					case 8:
						array[num] = identifiers[num3].name;
						num2 = -442784788;
						continue;
					case 2:
						if (num3 >= 0)
						{
							int num4;
							if (num3 >= identifiers.Length)
							{
								num2 = -442784790;
								num4 = num2;
							}
							else
							{
								num2 = -442784798;
								num4 = num2;
							}
							continue;
						}
						goto case 0;
					case 5:
						return new string[0];
					case 0:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = -442784788;
						continue;
					case 4:
					{
						int elementIdentifier = elements.axes[num].elementIdentifier;
						num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						num2 = -442784792;
						continue;
					}
					case 6:
						num++;
						num2 = -442784789;
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
				goto IL_0010;
				IL_0010:
				num2 = -442784787;
				goto IL_0015;
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
					if (num < array.Length)
					{
						num2 = 886944197;
						num3 = num2;
					}
					else
					{
						num2 = 886944195;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x34DDB1C4)
						{
						case 4:
							num2 = 886944197;
							continue;
						case 5:
							num++;
							num2 = 886944196;
							continue;
						case 6:
							if (num4 >= 0)
							{
								int num5;
								if (num4 >= identifiers.Length)
								{
									num2 = 886944198;
									num5 = num2;
								}
								else
								{
									num2 = 886944199;
									num5 = num2;
								}
								continue;
							}
							goto case 2;
						case 3:
							array[num] = identifiers[num4].name;
							num2 = 886944193;
							continue;
						case 1:
						{
							int elementIdentifier = elements.buttons[num].elementIdentifier;
							num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num2 = 886944194;
							continue;
						}
						case 0:
							break;
						case 2:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = 886944193;
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
				foreach (Axis item in IterateAxes())
				{
					if (item.elementIdentifier == elementIdentifierId)
					{
						return true;
					}
				}
				using (IEnumerator<Platform_Custom.Button> enumerator2 = IterateButtons().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Button button = (Button)enumerator2.Current;
							int num = 2066923031;
							while (true)
							{
								switch (num ^ 0x7B32BE17)
								{
								case 3:
									num = 2066923030;
									continue;
								case 1:
									break;
								case 0:
									if (button.elementIdentifier == elementIdentifierId)
									{
										return true;
									}
									goto end_IL_0094;
								default:
									goto end_IL_0094;
								}
								break;
							}
							continue;
							end_IL_0094:
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
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Button button = (Button)enumerator.Current;
							buttons[num] = button.elementIdentifier;
							int num2 = -2113749392;
							while (true)
							{
								switch (num2 ^ -2113749391)
								{
								case 0:
									num2 = -2113749390;
									continue;
								case 3:
									break;
								case 1:
									num++;
									num2 = -2113749389;
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
				using (IEnumerator<Platform_Custom.Axis> enumerator2 = IterateAxes().GetEnumerator())
				{
					while (true)
					{
						int num3;
						int num4;
						if (enumerator2.MoveNext())
						{
							num3 = -2113749389;
							num4 = num3;
						}
						else
						{
							num3 = -2113749391;
							num4 = num3;
						}
						while (true)
						{
							switch (num3 ^ -2113749391)
							{
							case 3:
								num3 = -2113749389;
								continue;
							default:
								return;
							case 2:
							{
								Axis axis = (Axis)enumerator2.Current;
								axes[num] = axis.elementIdentifier;
								num++;
								num3 = -2113749392;
								continue;
							}
							case 1:
								break;
							case 0:
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
				int num = 0;
				while (true)
				{
					int num2 = -1465003173;
					while (true)
					{
						switch (num2 ^ -1465003172)
						{
						case 5:
							break;
						case 8:
							array[num].max = axes_orig[num].axisMax;
							num2 = -1465003170;
							continue;
						case 2:
							array[num].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num].alternateCalibrations, deepClone: true);
							num2 = -1465003177;
							continue;
						case 6:
							num2 = -1465003170;
							continue;
						case 10:
							array[num].deadZone = axes_orig[num].axisDeadZone;
							if (Axes_orig[num].calibrateAxis)
							{
								array[num].zero = axes_orig[num].axisZero;
								array[num].min = axes_orig[num].axisMin;
								num2 = -1465003180;
								continue;
							}
							goto case 2;
						case 7:
							num2 = -1465003171;
							continue;
						case 9:
							if (axes_orig[num].sourceType != 1)
							{
								int num3;
								if (axes_orig[num].sourceType == 100)
								{
									num2 = -1465003169;
									num3 = num2;
								}
								else
								{
									num2 = -1465003176;
									num3 = num2;
								}
								continue;
							}
							goto case 3;
						case 3:
						{
							ref AxisCalibrationData reference2 = ref array[num];
							reference2 = AxisCalibrationData.Default;
							array[num].invert = axes_orig[num].invert;
							num2 = -1465003178;
							continue;
						}
						case 0:
							throw new NotImplementedException();
						case 4:
							if (axes_orig[num].sourceType == 0)
							{
								ref AxisCalibrationData reference = ref array[num];
								reference = AxisCalibrationData.Default;
								num2 = -1465003174;
								continue;
							}
							goto case 0;
						case 11:
							num++;
							num2 = -1465003171;
							continue;
						default:
							if (num >= axes_orig.Length)
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
					axisInfos = new HardwareAxisInfo[Axes_orig.Length];
					int num = 1416758044;
					while (true)
					{
						switch (num ^ 0x5472031D)
						{
						case 11:
							num = 1416758043;
							continue;
						default:
							return;
						case 2:
						{
							int num5;
							if (num2 >= Axes_orig.Length)
							{
								num = 1416758041;
								num5 = num;
							}
							else
							{
								num = 1416758040;
								num5 = num;
							}
							continue;
						}
						case 10:
							axisRanges[num2] = AxisRange.Full;
							num = 1416758037;
							continue;
						case 5:
						{
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, createIfNull: true);
							int num4;
							if (Axes_orig[num2].sourceType == 1)
							{
								num = 1416758036;
								num4 = num;
							}
							else
							{
								num = 1416758046;
								num4 = num;
							}
							continue;
						}
						case 8:
							num2++;
							num = 1416758047;
							continue;
						case 3:
						{
							int num6;
							if (Axes_orig[num2].sourceType == 100)
							{
								num = 1416758036;
								num6 = num;
							}
							else
							{
								num = 1416758042;
								num6 = num;
							}
							continue;
						}
						case 0:
							throw new Exception();
						case 9:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = 1416758037;
							continue;
						case 1:
							num2 = 0;
							num = 1416758047;
							continue;
						case 7:
						{
							int num3;
							if (Axes_orig[num2].sourceType == 0)
							{
								num = 1416758039;
								num3 = num;
							}
							else
							{
								num = 1416758045;
								num3 = num;
							}
							continue;
						}
						case 6:
							break;
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
					goto IL_000b;
				}
				goto IL_005e;
				IL_000b:
				int num = -1811109446;
				goto IL_0010;
				IL_0010:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ -1811109445)
					{
					case 3:
						break;
					case 5:
						buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, createIfNull: true);
						num = -1811109443;
						continue;
					case 2:
						num = -1811109441;
						continue;
					case 0:
						goto IL_005e;
					case 1:
						return;
					case 6:
						num2++;
						num = -1811109441;
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
				goto IL_000b;
				IL_005e:
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				num2 = 0;
				num = -1811109447;
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
				Platform_NintendoSwitch_Base platform_NintendoSwitch_Base = new Platform_NintendoSwitch_Base();
				CopyVars(platform_NintendoSwitch_Base);
				return platform_NintendoSwitch_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_NintendoSwitch_Base platform_NintendoSwitch_Base = destination as Platform_NintendoSwitch_Base;
				while (true)
				{
					int num = -1785859357;
					while (true)
					{
						switch (num ^ -1785859360)
						{
						case 0:
							break;
						default:
							return;
						case 3:
						{
							int num2;
							if (platform_NintendoSwitch_Base == null)
							{
								num = -1785859358;
								num2 = num;
							}
							else
							{
								num = -1785859356;
								num2 = num;
							}
							continue;
						}
						case 4:
							platform_NintendoSwitch_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
							platform_NintendoSwitch_Base.elements = MiscTools.DeepClone(elements);
							num = -1785859359;
							continue;
						case 2:
							return;
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
		public sealed class Platform_NintendoSwitch : Platform_NintendoSwitch_Base
		{
			public Platform_NintendoSwitch_Base[] variants;

			internal override IList<Platform> variants_base => variants;

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
					num2 = 2012583960;
					goto IL_0012;
				}
				goto IL_0091;
				IL_0012:
				while (true)
				{
					switch (num2 ^ 0x77F59819)
					{
					case 0:
						break;
					case 2:
						return true;
					case 3:
						goto IL_0046;
					case 1:
						goto IL_0075;
					default:
						goto IL_0091;
					}
					break;
					IL_0075:
					int num3;
					if (num >= variants.Length)
					{
						num2 = 2012583965;
						num3 = num2;
					}
					else
					{
						num2 = 2012583962;
						num3 = num2;
					}
					continue;
					IL_0046:
					if (variants[num] != null && variants[num].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = num;
						return true;
					}
					num++;
					num2 = 2012583960;
				}
				goto IL_000d;
				IL_0091:
				return false;
				IL_000d:
				num2 = 2012583963;
				goto IL_0012;
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
				while (true)
				{
					switch (-894143701 ^ -894143703)
					{
					case 0:
						continue;
					case 2:
						if (platform_NintendoSwitch == null)
						{
							return;
						}
						break;
					}
					break;
				}
				platform_NintendoSwitch.variants = MiscTools.DeepClone(variants);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_Stadia_Base : Platform_Custom
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
					goto IL_00b1;
					IL_00b1:
					string text = default(string);
					int num;
					if (base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						if (alwaysMatch)
						{
							return true;
						}
						text = bridgedControllerHWInfo.hw_productName;
						int num2;
						if (text != null)
						{
							num = -1539918429;
							num2 = num;
						}
						else
						{
							num = -1539918425;
							num2 = num;
						}
					}
					else
					{
						num = -1539918428;
					}
					goto IL_001b;
					IL_0016:
					num = -1539918432;
					goto IL_001b;
					IL_001b:
					int num3 = default(int);
					while (true)
					{
						switch (num ^ -1539918427)
						{
						case 0:
							break;
						case 2:
							text = string.Empty;
							num = -1539918429;
							continue;
						case 1:
							return false;
						case 3:
							goto IL_007f;
						case 5:
							goto IL_00a7;
						case 4:
							goto IL_00c5;
						case 6:
							text = text.Trim();
							if (productName != null)
							{
								num3 = 0;
								num = -1539918431;
								continue;
							}
							goto default;
						default:
							return false;
						}
						break;
						IL_00c5:
						int num4;
						if (num3 >= productName.Length)
						{
							num = -1539918430;
							num4 = num;
						}
						else
						{
							num = -1539918426;
							num4 = num;
						}
						continue;
						IL_007f:
						string searchFor = productName[num3];
						if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
						{
							return true;
						}
						num3++;
						num = -1539918431;
					}
					goto IL_0016;
					IL_00a7:
					if (isAllowed)
					{
						return true;
					}
					goto IL_00b1;
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
						switch (-701829616 ^ -701829615)
						{
						case 2:
							continue;
						case 1:
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
					int num3 = default(int);
					while (true)
					{
						int num2 = 227498994;
						while (true)
						{
							switch (num2 ^ 0xD8F5BF1)
							{
							case 6:
								break;
							case 3:
								num2 = 227498996;
								continue;
							case 2:
								if (buttons[num3].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num3++;
								num2 = 227498997;
								continue;
							case 1:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Axis;
								}
								num++;
								num2 = 227498996;
								continue;
							case 0:
								num2 = 227498997;
								continue;
							case 5:
								if (num >= axisCount)
								{
									num3 = 0;
									num2 = 227498993;
									continue;
								}
								goto case 1;
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
						int num2 = -1643977629;
						while (true)
						{
							switch (num2 ^ -1643977627)
							{
							case 2:
								break;
							case 0:
								return true;
							case 5:
								if (axes[num].elementIdentifier != elementIdentifier.id)
								{
									goto case 3;
								}
								sourceType = axes[num].sourceType;
								switch (sourceType)
								{
								case 0:
									axisRange = AxisRange.Positive;
									return true;
								default:
									num2 = -1643977630;
									continue;
								case 1:
									break;
								}
								goto case 1;
							case 6:
								num2 = -1643977631;
								continue;
							case 3:
								num++;
								num2 = -1643977631;
								continue;
							case 7:
								if (sourceType != 100)
								{
									throw new NotImplementedException();
								}
								num2 = -1643977628;
								continue;
							case 1:
								axisRange = axes[num].sourceAxisRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -1643977627;
									continue;
								}
								goto case 0;
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
					while (true)
					{
						switch (-1236984849 ^ -1236984850)
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

			private sealed class ncuCwwRmTiMpPtQQdwZMRHPKFON : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_Stadia_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int zQCJsVDugMSwODIJVuctcppSIDl;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						goto IL_001c;
					}
					goto IL_004e;
					IL_004e:
					ncuCwwRmTiMpPtQQdwZMRHPKFON ncuCwwRmTiMpPtQQdwZMRHPKFON2 = new ncuCwwRmTiMpPtQQdwZMRHPKFON(0);
					ncuCwwRmTiMpPtQQdwZMRHPKFON2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					int num = 1838053473;
					goto IL_0021;
					IL_001c:
					num = 1838053475;
					goto IL_0021;
					IL_0021:
					while (true)
					{
						switch (num ^ 0x6D8E7862)
						{
						case 2:
							break;
						case 1:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							ncuCwwRmTiMpPtQQdwZMRHPKFON2 = this;
							num = 1838053473;
							continue;
						case 0:
							goto IL_004e;
						default:
							return ncuCwwRmTiMpPtQQdwZMRHPKFON2;
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
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					case 0:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						int num2;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements == null)
						{
							num = -737680675;
							num2 = num;
						}
						else
						{
							num = -737680674;
							num2 = num;
						}
						goto IL_001f;
					}
					case 1:
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							zQCJsVDugMSwODIJVuctcppSIDl++;
							num = -737680677;
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -737680673)
							{
							case 3:
								num = -737680679;
								continue;
							case 6:
								break;
							case 0:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 1:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes != null)
								{
									zQCJsVDugMSwODIJVuctcppSIDl = 0;
									num = -737680677;
									continue;
								}
								goto end_IL_0008;
							case 5:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes[zQCJsVDugMSwODIJVuctcppSIDl];
								num = -737680673;
								continue;
							case 4:
								goto IL_00df;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00df:
							int num3;
							if (zQCJsVDugMSwODIJVuctcppSIDl >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes.Length)
							{
								num = -737680675;
								num3 = num;
							}
							else
							{
								num = -737680678;
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
				public ncuCwwRmTiMpPtQQdwZMRHPKFON(int _003C_003E1__state)
				{
					while (true)
					{
						int num = -936809863;
						while (true)
						{
							switch (num ^ -936809861)
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
							isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
							TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
							num = -936809862;
						}
					}
				}
			}

			private sealed class VNyGsSpujmAPvchYAeckkQPCGuv : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_Stadia_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int YBpDNayCTeWpqFJNuDtyNXGZLqV;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
					{
						goto IL_0012;
					}
					goto IL_0065;
					IL_0012:
					int num = -1443321133;
					goto IL_0017;
					IL_0017:
					VNyGsSpujmAPvchYAeckkQPCGuv vNyGsSpujmAPvchYAeckkQPCGuv = default(VNyGsSpujmAPvchYAeckkQPCGuv);
					while (true)
					{
						switch (num ^ -1443321135)
						{
						case 3:
							break;
						case 2:
							if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
							{
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								vNyGsSpujmAPvchYAeckkQPCGuv = this;
								num = -1443321135;
								continue;
							}
							goto IL_0065;
						case 4:
							vNyGsSpujmAPvchYAeckkQPCGuv.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
							num = -1443321135;
							continue;
						case 1:
							goto IL_0065;
						default:
							return vNyGsSpujmAPvchYAeckkQPCGuv;
						}
						break;
					}
					goto IL_0012;
					IL_0065:
					vNyGsSpujmAPvchYAeckkQPCGuv = new VNyGsSpujmAPvchYAeckkQPCGuv(0);
					num = -1443321131;
					goto IL_0017;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = -1931852415;
						while (true)
						{
							switch (num2 ^ -1931852411)
							{
							case 0:
								break;
							case 4:
								switch (num)
								{
								default:
									num2 = -1931852409;
									continue;
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									num2 = -1931852414;
									continue;
								case 0:
									break;
								}
								goto case 6;
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 8:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons[YBpDNayCTeWpqFJNuDtyNXGZLqV];
								num2 = -1931852412;
								continue;
							case 7:
								YBpDNayCTeWpqFJNuDtyNXGZLqV++;
								num2 = -1931852404;
								continue;
							case 3:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null && syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons != null)
								{
									YBpDNayCTeWpqFJNuDtyNXGZLqV = 0;
									num2 = -1931852404;
									continue;
								}
								goto default;
							case 6:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num2 = -1931852410;
								continue;
							case 9:
							{
								int num3;
								if (YBpDNayCTeWpqFJNuDtyNXGZLqV >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons.Length)
								{
									num2 = -1931852416;
									num3 = num2;
								}
								else
								{
									num2 = -1931852403;
									num3 = num2;
								}
								continue;
							}
							case 2:
								num2 = -1931852416;
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
				public VNyGsSpujmAPvchYAeckkQPCGuv(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public string controllerName;

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

			public override string controllerNameOverride => controllerName;

			internal override InputPlatform platform => InputPlatform.tDSEXVttzObSTRvKkzvQqSrZkMJ;

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
								int num = -430173242;
								while (true)
								{
									switch (num ^ -430173245)
									{
									case 4:
										break;
									case 1:
										num2++;
										num = -430173245;
										continue;
									case 2:
										_axesOrigGame[num2] = axes_orig[num2];
										num = -430173246;
										continue;
									case 0:
										goto IL_0059;
									case 5:
										_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
										num2 = 0;
										num = -430173245;
										continue;
									default:
										goto end_IL_0012;
									}
									break;
									IL_0059:
									int num3;
									if (num2 >= axes_orig.Length)
									{
										num = -430173248;
										num3 = num;
									}
									else
									{
										num = -430173247;
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
							int num2 = default(int);
							while (true)
							{
								int num = 838205392;
								while (true)
								{
									switch (num ^ 0x31F5FFD5)
									{
									case 2:
										break;
									case 5:
										num2 = 0;
										num = 838205398;
										continue;
									case 3:
										goto IL_0053;
									case 4:
										num2++;
										num = 838205398;
										continue;
									case 0:
										_buttonsOrigGame[num2] = buttons_orig[num2];
										num = 838205393;
										continue;
									default:
										goto end_IL_0020;
									}
									break;
									IL_0053:
									int num3;
									if (num2 >= buttons_orig.Length)
									{
										num = 838205396;
										num3 = num;
									}
									else
									{
										num = 838205397;
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

			internal override Elements_Base elements_base => elements;

			internal override IList<Platform> variants_base => null;

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
				ncuCwwRmTiMpPtQQdwZMRHPKFON ncuCwwRmTiMpPtQQdwZMRHPKFON2 = new ncuCwwRmTiMpPtQQdwZMRHPKFON(-2);
				ncuCwwRmTiMpPtQQdwZMRHPKFON2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return ncuCwwRmTiMpPtQQdwZMRHPKFON2;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				VNyGsSpujmAPvchYAeckkQPCGuv vNyGsSpujmAPvchYAeckkQPCGuv = new VNyGsSpujmAPvchYAeckkQPCGuv(-2);
				vNyGsSpujmAPvchYAeckkQPCGuv.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return vNyGsSpujmAPvchYAeckkQPCGuv;
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
						num2 = 1933717321;
						num3 = num2;
					}
					else
					{
						num2 = 1933717325;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x73422F4E)
						{
						case 6:
							num2 = 1933717321;
							continue;
						case 7:
							elementIdentifier = elements.axes[num].elementIdentifier;
							num2 = 1933717327;
							continue;
						case 2:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = 1933717326;
							continue;
						case 4:
							break;
						case 0:
							num++;
							num2 = 1933717322;
							continue;
						case 1:
							num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							if (num4 >= 0)
							{
								int num5;
								if (num4 >= identifiers.Length)
								{
									num2 = 1933717324;
									num5 = num2;
								}
								else
								{
									num2 = 1933717323;
									num5 = num2;
								}
								continue;
							}
							goto case 2;
						case 5:
							array[num] = identifiers[num4].name;
							num2 = 1933717326;
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
					return new string[0];
				}
				string[] array = new string[buttonCount];
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					int num = -1761815961;
					while (true)
					{
						switch (num ^ -1761815966)
						{
						case 0:
							break;
						case 5:
							num2 = 0;
							num = -1761815964;
							continue;
						case 3:
							array[num2] = identifiers[num3].name;
							num = -1761815962;
							continue;
						case 2:
							Logger.LogError("Element identifier index is out of bounds!");
							num = -1761815962;
							continue;
						case 1:
						{
							int elementIdentifier = elements.buttons[num2].elementIdentifier;
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							if (num3 >= 0)
							{
								int num4;
								if (num3 >= identifiers.Length)
								{
									num = -1761815968;
									num4 = num;
								}
								else
								{
									num = -1761815967;
									num4 = num;
								}
								continue;
							}
							goto case 2;
						}
						case 4:
							num2++;
							num = -1761815964;
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
				bool result;
				using (IEnumerator<Platform_Custom.Axis> enumerator = IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator.Current;
							int num = 1216456394;
							while (true)
							{
								switch (num ^ 0x4881A6C9)
								{
								case 0:
									num = 1216456392;
									continue;
								case 1:
									break;
								case 3:
									if (axis.elementIdentifier != elementIdentifierId)
									{
										goto end_IL_0030;
									}
									result = true;
									goto IL_00e0;
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
							int num2 = 1216456393;
							while (true)
							{
								switch (num2 ^ 0x4881A6C9)
								{
								case 2:
									num2 = 1216456394;
									continue;
								case 3:
									break;
								default:
									goto end_IL_009f;
								case 0:
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
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Button button = (Button)enumerator.Current;
							buttons[num] = button.elementIdentifier;
							num++;
							int num2 = -119102392;
							while (true)
							{
								switch (num2 ^ -119102392)
								{
								case 2:
									num2 = -119102391;
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
				finally
				{
					if (enumerator != null)
					{
						while (true)
						{
							IL_0076:
							int num3 = -119102390;
							while (true)
							{
								switch (num3 ^ -119102392)
								{
								case 0:
									break;
								default:
									goto end_IL_007b;
								case 2:
									goto IL_0094;
								case 1:
									goto end_IL_007b;
								}
								goto IL_0076;
								IL_0094:
								enumerator.Dispose();
								num3 = -119102391;
								continue;
								end_IL_007b:
								break;
							}
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
							int num4 = -119102392;
							while (true)
							{
								switch (num4 ^ -119102392)
								{
								case 2:
									num4 = -119102391;
									continue;
								case 1:
									break;
								default:
									goto end_IL_00d1;
								}
								break;
							}
							continue;
							end_IL_00d1:
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
					int num = 1122527640;
					while (true)
					{
						switch (num ^ 0x42E8699A)
						{
						case 11:
							break;
						case 4:
						{
							ref AxisCalibrationData reference = ref array[num2];
							reference = AxisCalibrationData.Default;
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							int num5;
							if (!Axes_orig[num2].calibrateAxis)
							{
								num = 1122527644;
								num5 = num;
							}
							else
							{
								num = 1122527634;
								num5 = num;
							}
							continue;
						}
						case 0:
						{
							int num4;
							if (axes_orig[num2].sourceType == 0)
							{
								num = 1122527645;
								num4 = num;
							}
							else
							{
								num = 1122527643;
								num4 = num;
							}
							continue;
						}
						case 8:
							array[num2].zero = axes_orig[num2].axisZero;
							array[num2].min = axes_orig[num2].axisMin;
							num = 1122527641;
							continue;
						case 3:
							array[num2].max = axes_orig[num2].axisMax;
							num = 1122527632;
							continue;
						case 10:
							num = 1122527644;
							continue;
						case 7:
						{
							ref AxisCalibrationData reference2 = ref array[num2];
							reference2 = AxisCalibrationData.Default;
							num = 1122527644;
							continue;
						}
						case 9:
							if (axes_orig[num2].sourceType != 1)
							{
								int num3;
								if (axes_orig[num2].sourceType == 100)
								{
									num = 1122527646;
									num3 = num;
								}
								else
								{
									num = 1122527642;
									num3 = num;
								}
								continue;
							}
							goto case 4;
						case 1:
							throw new NotImplementedException();
						case 2:
							num2 = 0;
							num = 1122527647;
							continue;
						case 6:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, deepClone: true);
							num2++;
							num = 1122527647;
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
				while (true)
				{
					axisRanges = new AxisRange[Axes_orig.Length];
					axisInfos = new HardwareAxisInfo[Axes_orig.Length];
					int num = 0;
					int num2 = -741197907;
					while (true)
					{
						switch (num2 ^ -741197913)
						{
						case 0:
							num2 = -741197918;
							continue;
						case 6:
							if (Axes_orig[num].sourceType == 0)
							{
								axisRanges[num] = AxisRange.Full;
								num2 = -741197914;
								continue;
							}
							goto case 7;
						case 9:
							num++;
							num2 = -741197907;
							continue;
						case 2:
							if (Axes_orig[num].sourceType != 1)
							{
								int num3;
								if (Axes_orig[num].sourceType != 100)
								{
									num2 = -741197919;
									num3 = num2;
								}
								else
								{
									num2 = -741197916;
									num3 = num2;
								}
								continue;
							}
							goto case 3;
						case 3:
							axisRanges[num] = Axes_orig[num].sourceAxisRange;
							num2 = -741197905;
							continue;
						case 5:
							break;
						case 7:
							throw new Exception();
						case 8:
							num2 = -741197906;
							continue;
						case 1:
							num2 = -741197906;
							continue;
						case 4:
							axisInfos[num] = MiscTools.DeepClone(Axes_orig[num].axisInfo, createIfNull: true);
							num2 = -741197915;
							continue;
						default:
							if (num >= Axes_orig.Length)
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
					int num = 2034085527;
					while (true)
					{
						switch (num ^ 0x793DAE91)
						{
						case 3:
							break;
						default:
							return;
						case 2:
						{
							int num3;
							if (num2 >= Buttons_orig.Length)
							{
								num = 2034085525;
								num3 = num;
							}
							else
							{
								num = 2034085520;
								num3 = num;
							}
							continue;
						}
						case 0:
							buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
							num = 2034085524;
							continue;
						case 1:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, createIfNull: true);
							num2++;
							num = 2034085523;
							continue;
						case 6:
							if (Buttons_orig == null)
							{
								return;
							}
							goto case 0;
						case 5:
							num2 = 0;
							num = 2034085523;
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
				Platform_Stadia_Base platform_Stadia_Base = new Platform_Stadia_Base();
				CopyVars(platform_Stadia_Base);
				return platform_Stadia_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_Stadia_Base platform_Stadia_Base)
				{
					platform_Stadia_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_Stadia_Base.elements = MiscTools.DeepClone(elements);
					platform_Stadia_Base.controllerName = controllerName;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_Stadia : Platform_Stadia_Base
		{
			public Platform_Stadia_Base[] variants;

			internal override IList<Platform> variants_base => variants;

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
					num2 = -1926648169;
					goto IL_0012;
				}
				goto IL_0091;
				IL_0012:
				while (true)
				{
					switch (num2 ^ -1926648173)
					{
					case 0:
						break;
					case 1:
						return true;
					case 3:
						goto IL_0046;
					case 4:
						goto IL_0075;
					default:
						goto IL_0091;
					}
					break;
					IL_0075:
					int num3;
					if (num < variants.Length)
					{
						num2 = -1926648176;
						num3 = num2;
					}
					else
					{
						num2 = -1926648175;
						num3 = num2;
					}
					continue;
					IL_0046:
					if (variants[num] != null && variants[num].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = num;
						return true;
					}
					num++;
					num2 = -1926648169;
				}
				goto IL_000d;
				IL_0091:
				return false;
				IL_000d:
				num2 = -1926648174;
				goto IL_0012;
			}

			public override object DeepClone()
			{
				Platform_Stadia platform_Stadia = new Platform_Stadia();
				CopyVars(platform_Stadia);
				return platform_Stadia;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (!(destination is Platform_Stadia platform_Stadia))
				{
					return;
				}
				while (true)
				{
					platform_Stadia.variants = MiscTools.DeepClone(variants);
					int num = 1826887912;
					while (true)
					{
						switch (num ^ 0x6CE418EA)
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
						num = 1826887915;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_GameCore_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				public VidPid[] vidPid;

				public DeviceType deviceType;

				public GamepadSubType gamepadSubType;

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
							return true;
						}
						if (deviceType != DeviceType.None)
						{
							return true;
						}
						if (vidPid != null && vidPid.Length > 0)
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

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						return false;
					}
					if (hatCount >= 0)
					{
						return hatCount == bridgedControllerHWInfo.hardwareHatCount;
					}
					return true;
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock)
					{
						goto IL_000b;
					}
					goto IL_008f;
					IL_000b:
					int num = 263757975;
					goto IL_0010;
					IL_0010:
					string text = default(string);
					int num2 = default(int);
					int vendorId = default(int);
					int productId = default(int);
					string name = default(string);
					while (true)
					{
						switch (num ^ 0xFB8A091)
						{
						case 3:
							break;
						case 15:
							text = text.Trim();
							if (!strictMatch)
							{
								goto default;
							}
							if (vidPid != null)
							{
								num2 = 0;
								num = 263757971;
								continue;
							}
							goto case 13;
						case 12:
							goto IL_0085;
						case 10:
							goto IL_00a1;
						case 1:
							vendorId = vidPid[num2].vendorId;
							num = 263757953;
							continue;
						case 8:
							return true;
						case 5:
							return true;
						case 9:
							goto IL_0135;
						case 16:
							productId = vidPid[num2].productId;
							num = 263757979;
							continue;
						case 2:
							goto IL_0171;
						case 4:
							text = string.Empty;
							num = 263757982;
							continue;
						case 0:
							return false;
						case 7:
							goto IL_01fa;
						case 6:
							goto IL_0216;
						case 11:
							goto IL_022b;
						default:
							return ProductNameMatches(text);
						case 13:
							return false;
						}
						break;
						IL_022b:
						if (!ProductNameMatches(name))
						{
							return false;
						}
						goto IL_0237;
						IL_00a1:
						if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
						{
							name = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
							num = 263757978;
							continue;
						}
						goto IL_0237;
						IL_0216:
						if (hasData)
						{
							num = 263757981;
							continue;
						}
						goto IL_008f;
						IL_0085:
						if (isAllowed)
						{
							return true;
						}
						goto IL_008f;
						IL_01fa:
						int num3;
						if (vidPid != null)
						{
							num = 263757976;
							num3 = num;
						}
						else
						{
							num = 263757972;
							num3 = num;
						}
						continue;
						IL_0135:
						if (vidPid.Length == 0)
						{
							num = 263757972;
							continue;
						}
						goto IL_0117;
						IL_0237:
						if (bridgedControllerHWInfo.hw_vendorId == vendorId && bridgedControllerHWInfo.hw_productId == productId)
						{
							return true;
						}
						num2++;
						num = 263757971;
						continue;
						IL_0171:
						int num4;
						if (num2 < vidPid.Length)
						{
							num = 263757968;
							num4 = num;
						}
						else
						{
							num = 263757980;
							num4 = num;
						}
					}
					goto IL_000b;
					IL_0117:
					text = bridgedControllerHWInfo.hw_productName;
					int num5;
					if (text != null)
					{
						num = 263757982;
						num5 = num;
					}
					else
					{
						num = 263757973;
						num5 = num;
					}
					goto IL_0010;
					IL_008f:
					if (alwaysMatch)
					{
						num = 263757977;
					}
					else
					{
						if (!base.Matches(bridgedControllerHWInfo, strictMatch))
						{
							return false;
						}
						if (!ElementCountsMatch(bridgedControllerHWInfo, out var _))
						{
							num = 263757969;
						}
						else
						{
							if (deviceType == DeviceType.None)
							{
								goto IL_0117;
							}
							if (deviceType != (DeviceType)bridgedControllerHWInfo.deviceType)
							{
								return false;
							}
							if (deviceType == DeviceType.Gamepad && gamepadSubType != GamepadSubType.None && gamepadSubType != (GamepadSubType)bridgedControllerHWInfo.hw_xInputSubType)
							{
								return false;
							}
							int num6;
							if (HasProductName())
							{
								num = 263757976;
								num6 = num;
							}
							else
							{
								num = 263757974;
								num6 = num;
							}
						}
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
					MatchingCriteria matchingCriteria = destination as MatchingCriteria;
					while (true)
					{
						int num = -1318383397;
						while (true)
						{
							switch (num ^ -1318383399)
							{
							case 4:
								break;
							default:
								return;
							case 0:
								matchingCriteria.gamepadSubType = gamepadSubType;
								matchingCriteria.hatCount = hatCount;
								num = -1318383398;
								continue;
							case 1:
								matchingCriteria.productName_useRegex = productName_useRegex;
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								matchingCriteria.deviceType = deviceType;
								num = -1318383399;
								continue;
							case 3:
								matchingCriteria.vidPid = ArrayTools.ShallowCopy(vidPid);
								num = -1318383396;
								continue;
							case 2:
								if (matchingCriteria == null)
								{
									return;
								}
								goto case 1;
							case 5:
								return;
							}
							break;
						}
					}
				}

				private bool HasProductName()
				{
					if (productName == null)
					{
						return false;
					}
					int num = 0;
					while (true)
					{
						int num2 = -917324313;
						while (true)
						{
							switch (num2 ^ -917324315)
							{
							case 3:
								break;
							case 5:
								return true;
							case 1:
								if (string.IsNullOrEmpty(productName[num]))
								{
									num++;
									num2 = -917324315;
								}
								else
								{
									num2 = -917324320;
								}
								continue;
							case 2:
								num2 = -917324315;
								continue;
							case 0:
							{
								int num3;
								if (num >= productName.Length)
								{
									num2 = -917324319;
									num3 = num2;
								}
								else
								{
									num2 = -917324316;
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

				private bool ProductNameMatches(string name)
				{
					if (productName == null)
					{
						goto IL_0008;
					}
					int num = 0;
					int num2 = 2074517458;
					goto IL_000d;
					IL_000d:
					while (true)
					{
						switch (num2 ^ 0x7BA69FD1)
						{
						case 0:
							break;
						case 2:
							return false;
						case 1:
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
							goto case 1;
						}
						break;
						IL_004f:
						num++;
						num2 = 2074517458;
					}
					goto IL_0008;
					IL_0008:
					num2 = 2074517459;
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
					int num2 = default(int);
					while (true)
					{
						IL_0087:
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = -782818106;
							goto IL_000c;
						}
						goto IL_0065;
						IL_000c:
						while (true)
						{
							switch (num3 ^ -782818108)
							{
							case 0:
								num3 = -782818112;
								continue;
							case 6:
								break;
							case 2:
								num3 = -782818107;
								continue;
							case 3:
								return ControllerElementType.Button;
							case 4:
								goto end_IL_000c;
							case 5:
								goto IL_0087;
							default:
								if (num2 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								break;
							}
							if (buttons[num2].elementIdentifier == elementIdentifier.id)
							{
								num3 = -782818105;
								continue;
							}
							num2++;
							num3 = -782818107;
							continue;
							end_IL_000c:
							break;
						}
						goto IL_0065;
						IL_0065:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							break;
						}
						num++;
						num3 = -782818111;
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
							if (axes[num].elementIdentifier == elementIdentifier.id)
							{
								sourceType = axes[num].sourceType;
								num2 = -231577130;
								goto IL_000c;
							}
							goto IL_0117;
							IL_000c:
							while (true)
							{
								switch (num2 ^ -231577136)
								{
								case 5:
									num2 = -231577135;
									continue;
								case 4:
									return true;
								case 7:
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -231577132;
									continue;
								case 0:
									break;
								case 6:
									goto IL_0097;
								case 8:
									goto IL_00b8;
								case 1:
									goto end_IL_000c;
								case 3:
									goto IL_0117;
								default:
									goto end_IL_00ea;
								}
								goto IL_0085;
								IL_0097:
								switch (sourceType)
								{
								case 0:
									axisRange = AxisRange.Positive;
									return true;
								case 2:
									break;
								default:
									throw new NotImplementedException();
								case 100:
									goto IL_00ae;
								case 1:
									goto IL_00b8;
								}
								axisRange = axes[num].sourceHatRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -231577136;
									continue;
								}
								goto IL_0085;
								IL_00b8:
								axisRange = axes[num].sourceAxisRange;
								int num3;
								if (axes[num].invert)
								{
									num2 = -231577129;
									num3 = num2;
								}
								else
								{
									num2 = -231577132;
									num3 = num2;
								}
								continue;
								IL_00ae:
								num2 = -231577128;
								continue;
								IL_0085:
								return true;
								continue;
								end_IL_000c:
								break;
							}
							continue;
							IL_0117:
							num++;
							num2 = -231577134;
							goto IL_000c;
							continue;
							end_IL_00ea:
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
						int num = 1216333679;
						while (true)
						{
							switch (num ^ 0x487FC76E)
							{
							case 0:
								break;
							default:
								return;
							case 1:
								elements = destination as Elements;
								if (elements == null)
								{
									return;
								}
								goto case 4;
							case 2:
								elements.buttons = ArrayTools.DeepClone(buttons);
								num = 1216333677;
								continue;
							case 4:
								elements.axes = ArrayTools.DeepClone(axes);
								num = 1216333676;
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
			public new sealed class Button : Platform_Custom.Button
			{
				public int sourceHat;

				public HatDirection sourceHatDirection;

				public HatType sourceHatType;

				public override object DeepClone()
				{
					Button button = new Button();
					while (true)
					{
						int num = -357364493;
						while (true)
						{
							switch (num ^ -357364495)
							{
							case 0:
								break;
							case 2:
								goto IL_0024;
							default:
								return button;
							}
							break;
							IL_0024:
							CopyVars(button);
							num = -357364496;
						}
					}
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Button button = destination as Button;
					while (true)
					{
						int num = -1124755553;
						while (true)
						{
							switch (num ^ -1124755554)
							{
							case 3:
								break;
							case 1:
								if (button != null)
								{
									goto IL_003b;
								}
								return;
							case 2:
								goto IL_003b;
							default:
								button.sourceHatDirection = sourceHatDirection;
								button.sourceHatType = sourceHatType;
								return;
							}
							break;
							IL_003b:
							button.sourceHat = sourceHat;
							num = -1124755554;
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
					if (destination is Axis axis)
					{
						axis.sourceHat = sourceHat;
						axis.sourceHatDirection = sourceHatDirection;
						axis.sourceHatType = sourceHatType;
						axis.sourceHatRange = sourceHatRange;
					}
				}
			}

			public enum DeviceType
			{
				None = 0,
				Gamepad = 1,
				ArcadeStick = 2,
				FlightStick = 3,
				RacingWheel = 4,
				Raw = 6
			}

			public enum GamepadSubType
			{
				None = 0,
				Xbox360 = 1,
				XboxOne = 2,
				DualShock = 3,
				NintendoProController = 4,
				Unknown = 1000
			}

			private sealed class JPVGudUXosTQQtBpdFCICAkQXASF : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_GameCore_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int OzbTIFYoyBCAPVsMZRYBOYbfOyL;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
					{
						goto IL_0012;
					}
					goto IL_004e;
					IL_0012:
					int num = -1223883763;
					goto IL_0017;
					IL_0017:
					JPVGudUXosTQQtBpdFCICAkQXASF jPVGudUXosTQQtBpdFCICAkQXASF = default(JPVGudUXosTQQtBpdFCICAkQXASF);
					while (true)
					{
						switch (num ^ -1223883764)
						{
						case 3:
							break;
						case 1:
							if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
							{
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								jPVGudUXosTQQtBpdFCICAkQXASF = this;
								num = -1223883762;
								continue;
							}
							goto IL_004e;
						case 0:
							goto IL_004e;
						default:
							return jPVGudUXosTQQtBpdFCICAkQXASF;
						}
						break;
					}
					goto IL_0012;
					IL_004e:
					jPVGudUXosTQQtBpdFCICAkQXASF = new JPVGudUXosTQQtBpdFCICAkQXASF(0);
					jPVGudUXosTQQtBpdFCICAkQXASF.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					num = -1223883762;
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
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					default:
						num = -327304447;
						goto IL_001a;
					case 1:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						OzbTIFYoyBCAPVsMZRYBOYbfOyL++;
						num = -327304444;
						goto IL_001a;
					case 0:
						goto IL_00b2;
						IL_001a:
						while (true)
						{
							switch (num ^ -327304443)
							{
							case 2:
								break;
							case 1:
								goto IL_0042;
							case 5:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes[OzbTIFYoyBCAPVsMZRYBOYbfOyL];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 3:
								goto IL_00b2;
							case 4:
								num = -327304443;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_0042:
							int num2;
							if (OzbTIFYoyBCAPVsMZRYBOYbfOyL < syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes.Length)
							{
								num = -327304448;
								num2 = num;
							}
							else
							{
								num = -327304443;
								num2 = num;
							}
						}
						goto default;
						IL_00b2:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements == null || syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes == null)
						{
							break;
						}
						OzbTIFYoyBCAPVsMZRYBOYbfOyL = 0;
						num = -327304444;
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
				public JPVGudUXosTQQtBpdFCICAkQXASF(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class wAibwtUQuhRpaiOXYPnLtJYwBaVD : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_GameCore_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int AQZjXLhYbzLdBBiTTqOscBjIDoYB;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					wAibwtUQuhRpaiOXYPnLtJYwBaVD wAibwtUQuhRpaiOXYPnLtJYwBaVD2;
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						wAibwtUQuhRpaiOXYPnLtJYwBaVD2 = this;
					}
					else
					{
						while (true)
						{
							wAibwtUQuhRpaiOXYPnLtJYwBaVD2 = new wAibwtUQuhRpaiOXYPnLtJYwBaVD(0);
							int num = 1855166631;
							while (true)
							{
								switch (num ^ 0x6E9398A7)
								{
								case 2:
									num = 1855166628;
									continue;
								case 3:
									break;
								case 0:
									wAibwtUQuhRpaiOXYPnLtJYwBaVD2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
									num = 1855166630;
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
					return wAibwtUQuhRpaiOXYPnLtJYwBaVD2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					case 1:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						AQZjXLhYbzLdBBiTTqOscBjIDoYB++;
						num = 1927071114;
						goto IL_001f;
					case 0:
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements == null)
							{
								break;
							}
							int num3;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons != null)
							{
								num = 1927071119;
								num3 = num;
							}
							else
							{
								num = 1927071113;
								num3 = num;
							}
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ 0x72DCC58C)
							{
							case 0:
								num = 1927071112;
								continue;
							case 6:
								break;
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 3:
								AQZjXLhYbzLdBBiTTqOscBjIDoYB = 0;
								num = 1927071114;
								continue;
							case 2:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons[AQZjXLhYbzLdBBiTTqOscBjIDoYB];
								num = 1927071117;
								continue;
							case 4:
								goto end_IL_001f;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (AQZjXLhYbzLdBBiTTqOscBjIDoYB < syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons.Length)
							{
								num = 1927071118;
								num2 = num;
							}
							else
							{
								num = 1927071113;
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
				public wAibwtUQuhRpaiOXYPnLtJYwBaVD(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public string controllerName;

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

			public override string controllerNameOverride => controllerName;

			internal override InputPlatform platform => InputPlatform.AkZZquMxhXIVvnmCRwxaVZYYTek;

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
								int num2 = -1143475385;
								while (true)
								{
									switch (num2 ^ -1143475386)
									{
									case 2:
										break;
									case 4:
										goto IL_0048;
									case 3:
										_axesOrigGame[num] = axes_orig[num];
										num++;
										num2 = -1143475390;
										continue;
									case 1:
										num2 = -1143475390;
										continue;
									default:
										goto end_IL_0022;
									}
									break;
									IL_0048:
									int num3;
									if (num < axes_orig.Length)
									{
										num2 = -1143475387;
										num3 = num2;
									}
									else
									{
										num2 = -1143475386;
										num3 = num2;
									}
								}
								continue;
								end_IL_0022:
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
							int num2 = default(int);
							while (true)
							{
								int num = 756511936;
								while (true)
								{
									switch (num ^ 0x2D1774C6)
									{
									case 4:
										break;
									case 6:
										_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
										num = 756511941;
										continue;
									case 2:
										goto IL_005b;
									case 3:
										num2 = 0;
										num = 756511940;
										continue;
									case 5:
										_buttonsOrigGame[num2] = buttons_orig[num2];
										num = 756511942;
										continue;
									case 0:
										num2++;
										num = 756511940;
										continue;
									default:
										goto end_IL_0018;
									}
									break;
									IL_005b:
									int num3;
									if (num2 < buttons_orig.Length)
									{
										num = 756511939;
										num3 = num;
									}
									else
									{
										num = 756511943;
										num3 = num;
									}
								}
								continue;
								end_IL_0018:
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
						num = -1858310766;
						goto IL_000d;
					}
					goto IL_0050;
					IL_0008:
					num = -1858310767;
					goto IL_000d;
					IL_0050:
					return true;
					IL_0046:
					if (assignedAxisCount == 0)
					{
						return false;
					}
					goto IL_0050;
					IL_000d:
					switch (num ^ -1858310768)
					{
					case 0:
						break;
					case 1:
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

			internal override Elements_Base elements_base => elements;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null)
				{
					while (true)
					{
						int num = 867753415;
						while (true)
						{
							switch (num ^ 0x33B8DDC5)
							{
							case 0:
								break;
							case 2:
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
							num = 867753412;
						}
						continue;
						end_IL_000f:
						break;
					}
				}
				return false;
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				JPVGudUXosTQQtBpdFCICAkQXASF jPVGudUXosTQQtBpdFCICAkQXASF = new JPVGudUXosTQQtBpdFCICAkQXASF(-2);
				jPVGudUXosTQQtBpdFCICAkQXASF.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return jPVGudUXosTQQtBpdFCICAkQXASF;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				wAibwtUQuhRpaiOXYPnLtJYwBaVD wAibwtUQuhRpaiOXYPnLtJYwBaVD2 = new wAibwtUQuhRpaiOXYPnLtJYwBaVD(-2);
				wAibwtUQuhRpaiOXYPnLtJYwBaVD2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return wAibwtUQuhRpaiOXYPnLtJYwBaVD2;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					goto IL_0013;
				}
				string[] array = new string[elements.axisCount];
				int num = -2076737505;
				goto IL_0018;
				IL_0018:
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					switch (num ^ -2076737507)
					{
					case 4:
						break;
					case 8:
					{
						int elementIdentifier = elements.axes[num2].elementIdentifier;
						num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						int num5;
						if (num3 < 0)
						{
							num = -2076737507;
							num5 = num;
						}
						else
						{
							num = -2076737512;
							num5 = num;
						}
						continue;
					}
					case 2:
						num2 = 0;
						num = -2076737516;
						continue;
					case 0:
						Logger.LogError("Element identifier index is out of bounds!");
						num = -2076737508;
						continue;
					case 5:
					{
						int num6;
						if (num3 < identifiers.Length)
						{
							num = -2076737509;
							num6 = num;
						}
						else
						{
							num = -2076737507;
							num6 = num;
						}
						continue;
					}
					case 9:
					{
						int num4;
						if (num2 >= array.Length)
						{
							num = -2076737510;
							num4 = num;
						}
						else
						{
							num = -2076737515;
							num4 = num;
						}
						continue;
					}
					case 6:
						array[num2] = identifiers[num3].name;
						num = -2076737508;
						continue;
					case 1:
						num2++;
						num = -2076737516;
						continue;
					case 3:
						Logger.LogError("You have too few element identifiers!");
						return new string[0];
					default:
						return array;
					}
					break;
				}
				goto IL_0013;
				IL_0013:
				num = -2076737506;
				goto IL_0018;
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
						num2 = 487847994;
						num3 = num2;
					}
					else
					{
						num2 = 487847993;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x1D13F83C)
						{
						case 3:
							num2 = 487847993;
							continue;
						case 7:
							num++;
							num2 = 487847997;
							continue;
						case 2:
							array[num] = identifiers[num4].name;
							num2 = 487847995;
							continue;
						case 5:
						{
							int elementIdentifier = elements.buttons[num].elementIdentifier;
							num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num2 = 487847992;
							continue;
						}
						case 4:
							if (num4 >= 0)
							{
								int num5;
								if (num4 >= identifiers.Length)
								{
									num2 = 487847996;
									num5 = num2;
								}
								else
								{
									num2 = 487847998;
									num5 = num2;
								}
								continue;
							}
							goto case 0;
						case 1:
							break;
						case 0:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = 487847995;
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
							int num = 459446209;
							while (true)
							{
								switch (num ^ 0x1B6297C1)
								{
								case 2:
									num = 459446210;
									continue;
								case 3:
									break;
								default:
									goto end_IL_0030;
								case 0:
									goto IL_010f;
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
							int num2 = 459446208;
							while (true)
							{
								switch (num2 ^ 0x1B6297C1)
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
								num2 = 459446209;
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
					while (true)
					{
						IL_00e5:
						int num3;
						int num4;
						if (enumerator2.MoveNext())
						{
							num3 = 459446211;
							num4 = num3;
						}
						else
						{
							num3 = 459446208;
							num4 = num3;
						}
						while (true)
						{
							switch (num3 ^ 0x1B6297C1)
							{
							case 0:
								goto IL_00a2;
							default:
								goto end_IL_00a7;
							case 2:
							{
								Button button = (Button)enumerator2.Current;
								if (button.elementIdentifier != elementIdentifierId)
								{
									break;
								}
								result = true;
								goto IL_010f;
							}
							case 3:
								break;
							case 1:
								goto end_IL_00a7;
							}
							goto IL_00e5;
							IL_00a2:
							num3 = 459446211;
							continue;
							end_IL_00a7:
							break;
						}
						break;
					}
				}
				return false;
				IL_010f:
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
							int num2 = 1293443755;
							while (true)
							{
								switch (num2 ^ 0x4D1862AA)
								{
								case 0:
									num2 = 1293443752;
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
					while (true)
					{
						int num3;
						int num4;
						if (!enumerator2.MoveNext())
						{
							num3 = 1293443753;
							num4 = num3;
						}
						else
						{
							num3 = 1293443755;
							num4 = num3;
						}
						while (true)
						{
							switch (num3 ^ 0x4D1862AA)
							{
							case 0:
								num3 = 1293443755;
								continue;
							default:
								return;
							case 1:
							{
								Axis axis = (Axis)enumerator2.Current;
								axes[num] = axis.elementIdentifier;
								num++;
								num3 = 1293443752;
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
					return null;
				}
				AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
				int num = 0;
				while (true)
				{
					int num2 = -1723468896;
					while (true)
					{
						switch (num2 ^ -1723468891)
						{
						case 2:
							break;
						case 1:
							num2 = -1723468884;
							continue;
						case 3:
							if (axes_orig[num].sourceType != 1)
							{
								int num3;
								if (axes_orig[num].sourceType != 100)
								{
									num2 = -1723468883;
									num3 = num2;
								}
								else
								{
									num2 = -1723468891;
									num3 = num2;
								}
								continue;
							}
							goto case 0;
						case 0:
						{
							ref AxisCalibrationData reference = ref array[num];
							reference = AxisCalibrationData.Default;
							array[num].invert = axes_orig[num].invert;
							array[num].deadZone = axes_orig[num].axisDeadZone;
							if (Axes_orig[num].calibrateAxis)
							{
								array[num].zero = axes_orig[num].axisZero;
								array[num].min = axes_orig[num].axisMin;
								array[num].max = axes_orig[num].axisMax;
								num2 = -1723468884;
								continue;
							}
							goto case 9;
						}
						case 8:
							if (axes_orig[num].sourceType != 0)
							{
								int num4;
								if (axes_orig[num].sourceType != 2)
								{
									num2 = -1723468895;
									num4 = num2;
								}
								else
								{
									num2 = -1723468893;
									num4 = num2;
								}
								continue;
							}
							goto case 6;
						case 5:
							num2 = -1723468894;
							continue;
						case 6:
						{
							ref AxisCalibrationData reference2 = ref array[num];
							reference2 = AxisCalibrationData.Default;
							num2 = -1723468892;
							continue;
						}
						case 4:
							throw new NotImplementedException();
						case 9:
							array[num].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num].alternateCalibrations, deepClone: true);
							num++;
							num2 = -1723468894;
							continue;
						default:
							if (num >= axes_orig.Length)
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
				axisInfos = null;
				if (Axes_orig == null)
				{
					goto IL_0011;
				}
				goto IL_00f8;
				IL_0011:
				int num = -1400142660;
				goto IL_0016;
				IL_0016:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ -1400142662)
					{
					case 7:
						break;
					case 8:
						num2++;
						num = -1400142658;
						continue;
					case 11:
						axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
						num = -1400142670;
						continue;
					case 2:
						goto IL_0079;
					case 5:
					{
						axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, createIfNull: true);
						int num3;
						if (Axes_orig[num2].sourceType == 1)
						{
							num = -1400142671;
							num3 = num;
						}
						else
						{
							num = -1400142664;
							num3 = num;
						}
						continue;
					}
					case 9:
						axisRanges[num2] = AxisRange.Full;
						num = -1400142670;
						continue;
					case 3:
						throw new Exception();
					case 1:
						goto IL_00f8;
					case 10:
						if (Axes_orig[num2].sourceType == 0)
						{
							goto case 9;
						}
						goto IL_0120;
					case 0:
						axisInfos = new HardwareAxisInfo[Axes_orig.Length];
						num2 = 0;
						num = -1400142658;
						continue;
					case 6:
						return;
					default:
						if (num2 >= Axes_orig.Length)
						{
							return;
						}
						goto case 5;
					}
					break;
					IL_0120:
					int num4;
					if (Axes_orig[num2].sourceType == 2)
					{
						num = -1400142669;
						num4 = num;
					}
					else
					{
						num = -1400142663;
						num4 = num;
					}
					continue;
					IL_0079:
					int num5;
					if (Axes_orig[num2].sourceType == 100)
					{
						num = -1400142671;
						num5 = num;
					}
					else
					{
						num = -1400142672;
						num5 = num;
					}
				}
				goto IL_0011;
				IL_00f8:
				axisRanges = new AxisRange[Axes_orig.Length];
				num = -1400142662;
				goto IL_0016;
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
					int num = -242756525;
					while (true)
					{
						switch (num ^ -242756525)
						{
						case 2:
							num = -242756521;
							continue;
						default:
							return;
						case 4:
							break;
						case 1:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, createIfNull: true);
							num2++;
							num = -242756528;
							continue;
						case 3:
						{
							int num3;
							if (num2 < Buttons_orig.Length)
							{
								num = -242756526;
								num3 = num;
							}
							else
							{
								num = -242756522;
								num3 = num;
							}
							continue;
						}
						case 0:
							num2 = 0;
							num = -242756528;
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
				Platform_GameCore_Base platform_GameCore_Base = new Platform_GameCore_Base();
				CopyVars(platform_GameCore_Base);
				return platform_GameCore_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_GameCore_Base platform_GameCore_Base = destination as Platform_GameCore_Base;
				if (platform_GameCore_Base == null)
				{
					goto IL_0011;
				}
				goto IL_003b;
				IL_0011:
				int num = -1722960779;
				goto IL_0016;
				IL_0016:
				switch (num ^ -1722960778)
				{
				case 2:
					break;
				default:
					return;
				case 3:
					return;
				case 0:
					goto IL_003b;
				case 1:
					return;
				}
				goto IL_0011;
				IL_003b:
				platform_GameCore_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				platform_GameCore_Base.elements = MiscTools.DeepClone(elements);
				platform_GameCore_Base.controllerName = controllerName;
				num = -1722960777;
				goto IL_0016;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_GameCore : Platform_GameCore_Base
		{
			public Platform_GameCore_Base[] variants;

			internal override IList<Platform> variants_base => variants;

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
						int num = -1653495801;
						while (true)
						{
							switch (num ^ -1653495803)
							{
							case 0:
								break;
							case 1:
								goto IL_0048;
							case 3:
								goto IL_0064;
							case 5:
								goto IL_0075;
							case 2:
								num2 = 0;
								num = -1653495804;
								continue;
							case 4:
								variantIndex = num2;
								return true;
							default:
								goto end_IL_001a;
							}
							break;
							IL_0075:
							if (variants[num2].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
							{
								num = -1653495807;
								continue;
							}
							goto IL_009f;
							IL_009f:
							num2++;
							num = -1653495804;
							continue;
							IL_0064:
							if (variants[num2] != null)
							{
								num = -1653495808;
								continue;
							}
							goto IL_009f;
							IL_0048:
							int num3;
							if (num2 >= variants.Length)
							{
								num = -1653495805;
								num3 = num;
							}
							else
							{
								num = -1653495802;
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
				Platform_GameCore platform_GameCore = new Platform_GameCore();
				CopyVars(platform_GameCore);
				return platform_GameCore;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_GameCore platform_GameCore = destination as Platform_GameCore;
				if (platform_GameCore == null)
				{
					while (true)
					{
						switch (-1670620762 ^ -1670620761)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				platform_GameCore.variants = MiscTools.DeepClone(variants);
			}

			internal static Platform_GameCore CreateDefaultMap(BridgedControllerHWInfo bridgedController)
			{
				Platform_GameCore platform_GameCore = new Platform_GameCore();
				_ = Consts.unknownJoystickElementIdentifiers_orig;
				int num9 = default(int);
				int num8 = default(int);
				int num5 = default(int);
				int num13 = default(int);
				Axis axis = default(Axis);
				int num6 = default(int);
				int num12 = default(int);
				Elements elements = default(Elements);
				int num4 = default(int);
				Button button = default(Button);
				Button button2 = default(Button);
				int num7 = default(int);
				bool flag = default(bool);
				int num11 = default(int);
				int num10 = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = -1531001268;
					while (true)
					{
						switch (num ^ -1531001254)
						{
						case 18:
							break;
						case 20:
							num9++;
							num = -1531001267;
							continue;
						case 23:
							if (num9 >= num8)
							{
								num5 = 128;
								num13 = 2;
								num = -1531001253;
								continue;
							}
							goto case 6;
						case 8:
							axis.sourceAxis = num9;
							num = -1531001258;
							continue;
						case 1:
							num6 = num13 * 8;
							num = -1531001263;
							continue;
						case 7:
							axis.axisDeadZone = 0.1f;
							num = -1531001249;
							continue;
						case 9:
							axis.calibrateAxis = false;
							axis.buttonAxisContribution = Pole.Positive;
							axis.elementIdentifier = num9;
							axis.invert = false;
							num = -1531001262;
							continue;
						case 0:
							num12 = 0;
							num = -1531001264;
							continue;
						case 22:
							platform_GameCore.controllerName = "Unknown Controller";
							num = -1531001269;
							continue;
						case 14:
							elements.buttons[num4++] = button;
							button.buttonInfo = new HardwareButtonInfo(excludeFromPolling: false, isPressureSensitive: false);
							num = -1531001270;
							continue;
						case 24:
							button2.sourceType = 0;
							num7++;
							num = -1531001255;
							continue;
						case 16:
							button.elementIdentifier = (flag ? num11++ : num10++);
							button.sourceHat = num2;
							button.sourceType = 2;
							button.sourceHatDirection = (HatDirection)(flag ? (num12 / 2) : (4 + num12 / 2));
							num12++;
							num = -1531001264;
							continue;
						case 25:
							axis.sourceType = 1;
							num = -1531001266;
							continue;
						case 19:
							button2 = new Button();
							elements.buttons[num7] = button2;
							button2.buttonInfo = new HardwareButtonInfo(excludeFromPolling: false, isPressureSensitive: false);
							button2.elementIdentifier = 32 + num7;
							num = -1531001257;
							continue;
						case 6:
							axis = new Axis();
							elements.axes[num9] = axis;
							num = -1531001251;
							continue;
						case 13:
							button2.sourceButton = num7;
							num = -1531001278;
							continue;
						case 10:
							if (num12 >= 8)
							{
								num2++;
								num = -1531001250;
								continue;
							}
							goto case 2;
						case 3:
							if (num7 >= num5)
							{
								num4 = num5;
								num11 = 160;
								num = -1531001265;
								continue;
							}
							goto case 19;
						case 21:
							num10 = 224;
							num2 = 0;
							num = -1531001250;
							continue;
						case 12:
							axis.sourceAxisRange = AxisRange.Full;
							num = -1531001277;
							continue;
						case 17:
							platform_GameCore.description = "";
							elements = (platform_GameCore.elements = new Elements());
							num8 = 32;
							elements.axes = new Axis[num8];
							num9 = 0;
							num = -1531001267;
							continue;
						case 11:
							elements.buttons = new Button[num5 + num6];
							num7 = 0;
							num = -1531001255;
							continue;
						case 4:
						{
							int num3;
							if (num2 < 2)
							{
								num = -1531001254;
								num3 = num;
							}
							else
							{
								num = -1531001259;
								num3 = num;
							}
							continue;
						}
						case 5:
							axis.axisInfo = HardwareAxisInfo.Default;
							axis.axisMin = -1f;
							axis.axisMax = 1f;
							axis.axisZero = 0f;
							num = -1531001261;
							continue;
						case 2:
							flag = num12 % 2 == 0;
							button = new Button();
							num = -1531001260;
							continue;
						default:
						{
							MatchingCriteria matchingCriteria = new MatchingCriteria();
							platform_GameCore.matchingCriteria = matchingCriteria;
							platform_GameCore.variants = new Platform_GameCore_Base[0];
							return platform_GameCore;
						}
						}
						break;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_PS5_Base : Platform_Custom
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
							num = 1890096981;
							goto IL_000d;
						}
						return false;
						IL_000d:
						switch (num ^ 0x70A89754)
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
						num = 1890096982;
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
					if (bridgedControllerHWInfo.isMock)
					{
						goto IL_000b;
					}
					goto IL_00eb;
					IL_000b:
					int num = 2129997490;
					goto IL_0010;
					IL_0010:
					string text = default(string);
					string searchFor = default(string);
					int num2 = default(int);
					while (true)
					{
						switch (num ^ 0x7EF52EB5)
						{
						case 6:
							break;
						case 3:
							goto IL_0048;
						case 8:
							text = string.Empty;
							num = 2129997492;
							continue;
						case 5:
							goto IL_0071;
						case 9:
							searchFor = productName[num2];
							num = 2129997494;
							continue;
						case 4:
							num2 = 0;
							num = 2129997495;
							continue;
						case 1:
							text = text.Trim();
							num = 2129997488;
							continue;
						case 2:
							goto IL_00ba;
						case 7:
							goto IL_00d9;
						default:
							return false;
						}
						break;
						IL_00ba:
						int num3;
						if (num2 >= productName.Length)
						{
							num = 2129997493;
							num3 = num;
						}
						else
						{
							num = 2129997500;
							num3 = num;
						}
						continue;
						IL_0071:
						int num4;
						if (productName == null)
						{
							num = 2129997493;
							num4 = num;
						}
						else
						{
							num = 2129997489;
							num4 = num;
						}
						continue;
						IL_0048:
						if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
						{
							return true;
						}
						num2++;
						num = 2129997495;
					}
					goto IL_000b;
					IL_00eb:
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					text = bridgedControllerHWInfo.hw_productName;
					int num5;
					if (text != null)
					{
						num = 2129997492;
						num5 = num;
					}
					else
					{
						num = 2129997501;
						num5 = num;
					}
					goto IL_0010;
					IL_00d9:
					if (hasData && isAllowed)
					{
						return true;
					}
					goto IL_00eb;
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
						while (true)
						{
							switch (0x294A01D1 ^ 0x294A01D0)
							{
							case 0:
								continue;
							case 1:
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
					int num2 = default(int);
					while (true)
					{
						IL_0057:
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = 871641788;
							goto IL_0009;
						}
						goto IL_002e;
						IL_0009:
						while (true)
						{
							switch (num3 ^ 0x33F432B9)
							{
							case 3:
								num3 = 871641789;
								continue;
							case 4:
								break;
							case 2:
								return ControllerElementType.Axis;
							case 0:
								goto IL_0057;
							case 1:
								goto IL_0069;
							default:
								if (num2 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								goto IL_0069;
							}
							break;
							IL_0069:
							if (buttons[num2].elementIdentifier == elementIdentifier.id)
							{
								return ControllerElementType.Button;
							}
							num2++;
							num3 = 871641788;
						}
						goto IL_002e;
						IL_002e:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							num3 = 871641787;
						}
						else
						{
							num++;
							num3 = 871641785;
						}
						goto IL_0009;
					}
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					while (true)
					{
						int num2 = -487231724;
						while (true)
						{
							switch (num2 ^ -487231723)
							{
							case 6:
								break;
							case 0:
								axisRange = axes[num].sourceAxisRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -487231722;
									continue;
								}
								goto case 3;
							case 3:
								return true;
							case 1:
								num2 = -487231721;
								continue;
							case 4:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									switch (axes[num].sourceType)
									{
									case 1:
										break;
									case 0:
										axisRange = AxisRange.Positive;
										return true;
									default:
										throw new NotImplementedException();
									case 100:
										num2 = -487231723;
										continue;
									}
									goto case 0;
								}
								goto case 5;
							case 5:
								num++;
								num2 = -487231721;
								continue;
							default:
								if (num >= axisCount)
								{
									axisRange = AxisRange.Full;
									return false;
								}
								goto case 4;
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
						int num = 1207284584;
						while (true)
						{
							switch (num ^ 0x47F5B369)
							{
							case 0:
								break;
							case 1:
								goto IL_0029;
							case 2:
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
							num = 1207284587;
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
					while (true)
					{
						int num = -1537529529;
						while (true)
						{
							switch (num ^ -1537529530)
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
							CopyVars(axis);
							num = -1537529530;
						}
					}
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Axis axis = destination as Axis;
				}
			}

			private sealed class KrstBZJxkFUSFBDTGGViPJlFtsr : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_PS5_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int FWxVzsXbssPpGselAbvXGEKfsLm;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
					{
						goto IL_0012;
					}
					goto IL_0038;
					IL_0012:
					int num = -702460763;
					goto IL_0017;
					IL_0017:
					KrstBZJxkFUSFBDTGGViPJlFtsr krstBZJxkFUSFBDTGGViPJlFtsr = default(KrstBZJxkFUSFBDTGGViPJlFtsr);
					while (true)
					{
						switch (num ^ -702460767)
						{
						case 0:
							break;
						case 3:
							goto IL_0038;
						case 2:
							num = -702460768;
							continue;
						case 4:
							if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
							{
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								krstBZJxkFUSFBDTGGViPJlFtsr = this;
								num = -702460765;
								continue;
							}
							goto IL_0038;
						default:
							return krstBZJxkFUSFBDTGGViPJlFtsr;
						}
						break;
					}
					goto IL_0012;
					IL_0038:
					krstBZJxkFUSFBDTGGViPJlFtsr = new KrstBZJxkFUSFBDTGGViPJlFtsr(0);
					krstBZJxkFUSFBDTGGViPJlFtsr.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					num = -702460768;
					goto IL_0017;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = 2124349157;
						while (true)
						{
							switch (num2 ^ 0x7E9EFEED)
							{
							case 6:
								break;
							case 4:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null)
								{
									int num4;
									if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes == null)
									{
										num2 = 2124349160;
										num4 = num2;
									}
									else
									{
										num2 = 2124349162;
										num4 = num2;
									}
									continue;
								}
								goto default;
							case 2:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 1:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes[FWxVzsXbssPpGselAbvXGEKfsLm];
								num2 = 2124349167;
								continue;
							case 0:
							{
								int num3;
								if (FWxVzsXbssPpGselAbvXGEKfsLm >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes.Length)
								{
									num2 = 2124349160;
									num3 = num2;
								}
								else
								{
									num2 = 2124349164;
									num3 = num2;
								}
								continue;
							}
							case 8:
								switch (num)
								{
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									FWxVzsXbssPpGselAbvXGEKfsLm++;
									num2 = 2124349165;
									continue;
								default:
									num2 = 2124349160;
									continue;
								case 0:
									break;
								}
								goto case 3;
							case 3:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num2 = 2124349161;
								continue;
							case 7:
								FWxVzsXbssPpGselAbvXGEKfsLm = 0;
								num2 = 2124349165;
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
				public KrstBZJxkFUSFBDTGGViPJlFtsr(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class QzLfMwggiyIphdAXzqLOBHuHOzvy : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_PS5_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int ZeSmQKbciveAYvyRaziIxuyAjuI;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					QzLfMwggiyIphdAXzqLOBHuHOzvy qzLfMwggiyIphdAXzqLOBHuHOzvy;
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						qzLfMwggiyIphdAXzqLOBHuHOzvy = this;
					}
					else
					{
						while (true)
						{
							qzLfMwggiyIphdAXzqLOBHuHOzvy = new QzLfMwggiyIphdAXzqLOBHuHOzvy(0);
							int num = -1453584649;
							while (true)
							{
								switch (num ^ -1453584649)
								{
								case 2:
									num = -1453584650;
									continue;
								case 1:
									break;
								case 0:
									qzLfMwggiyIphdAXzqLOBHuHOzvy.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
									num = -1453584652;
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
					return qzLfMwggiyIphdAXzqLOBHuHOzvy;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					default:
						num = -1984154854;
						goto IL_001a;
					case 1:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						ZeSmQKbciveAYvyRaziIxuyAjuI++;
						num = -1984154849;
						goto IL_001a;
					case 0:
						goto IL_006b;
						IL_001a:
						while (true)
						{
							switch (num ^ -1984154855)
							{
							case 5:
								break;
							case 4:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 2:
								goto IL_006b;
							case 6:
								goto IL_00a5;
							case 3:
								num = -1984154855;
								continue;
							case 1:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons[ZeSmQKbciveAYvyRaziIxuyAjuI];
								num = -1984154851;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00a5:
							int num2;
							if (ZeSmQKbciveAYvyRaziIxuyAjuI < syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons.Length)
							{
								num = -1984154856;
								num2 = num;
							}
							else
							{
								num = -1984154855;
								num2 = num;
							}
						}
						goto default;
						IL_006b:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements == null || syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons == null)
						{
							break;
						}
						ZeSmQKbciveAYvyRaziIxuyAjuI = 0;
						num = -1984154849;
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
				public QzLfMwggiyIphdAXzqLOBHuHOzvy(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public string controllerName;

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

			public override string controllerNameOverride => controllerName;

			internal override InputPlatform platform => InputPlatform.svmFLfAwcmvduLqYnidKumuhopX;

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
							int num = -516248748;
							while (true)
							{
								switch (num ^ -516248747)
								{
								case 3:
									break;
								case 2:
									goto IL_002e;
								case 0:
									_axesOrigGame[num2] = axes_orig[num2];
									num2++;
									num = -516248745;
									continue;
								case 1:
									axes_orig = Axes_orig;
									if (axes_orig != null)
									{
										_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
										num2 = 0;
										num = -516248745;
										continue;
									}
									goto end_IL_0008;
								default:
									goto end_IL_0008;
								}
								break;
								IL_002e:
								int num3;
								if (num2 >= axes_orig.Length)
								{
									num = -516248751;
									num3 = num;
								}
								else
								{
									num = -516248747;
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
							int num2 = default(int);
							while (true)
							{
								int num = -1759186431;
								while (true)
								{
									switch (num ^ -1759186428)
									{
									case 3:
										break;
									case 1:
										goto IL_003c;
									case 0:
										num = -1759186427;
										continue;
									case 2:
										_buttonsOrigGame[num2] = buttons_orig[num2];
										num2++;
										num = -1759186427;
										continue;
									case 5:
										_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
										num2 = 0;
										num = -1759186428;
										continue;
									default:
										goto end_IL_0012;
									}
									break;
									IL_003c:
									int num3;
									if (num2 < buttons_orig.Length)
									{
										num = -1759186426;
										num3 = num;
									}
									else
									{
										num = -1759186432;
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

			internal override Elements_Base elements_base => elements;

			internal override IList<Platform> variants_base => null;

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
				KrstBZJxkFUSFBDTGGViPJlFtsr krstBZJxkFUSFBDTGGViPJlFtsr = new KrstBZJxkFUSFBDTGGViPJlFtsr(-2);
				krstBZJxkFUSFBDTGGViPJlFtsr.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return krstBZJxkFUSFBDTGGViPJlFtsr;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				QzLfMwggiyIphdAXzqLOBHuHOzvy qzLfMwggiyIphdAXzqLOBHuHOzvy = new QzLfMwggiyIphdAXzqLOBHuHOzvy(-2);
				qzLfMwggiyIphdAXzqLOBHuHOzvy.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return qzLfMwggiyIphdAXzqLOBHuHOzvy;
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
				int num4 = default(int);
				while (true)
				{
					int num2;
					int num3;
					if (num >= array.Length)
					{
						num2 = -849917453;
						num3 = num2;
					}
					else
					{
						num2 = -849917456;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -849917450)
						{
						case 8:
							num2 = -849917456;
							continue;
						case 0:
							Logger.LogError("Element identifier index is out of bounds!");
							num2 = -849917455;
							continue;
						case 3:
						{
							int num6;
							if (num4 >= 0)
							{
								num2 = -849917454;
								num6 = num2;
							}
							else
							{
								num2 = -849917450;
								num6 = num2;
							}
							continue;
						}
						case 6:
						{
							int elementIdentifier = elements.axes[num].elementIdentifier;
							num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num2 = -849917451;
							continue;
						}
						case 7:
							num++;
							num2 = -849917449;
							continue;
						case 2:
							array[num] = identifiers[num4].name;
							num2 = -849917455;
							continue;
						case 1:
							break;
						case 4:
						{
							int num5;
							if (num4 >= identifiers.Length)
							{
								num2 = -849917450;
								num5 = num2;
							}
							else
							{
								num2 = -849917452;
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

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				int num2 = default(int);
				int num3 = default(int);
				string[] array = default(string[]);
				while (true)
				{
					int num = -1141606444;
					while (true)
					{
						switch (num ^ -1141606445)
						{
						case 6:
							break;
						case 2:
							num2++;
							num = -1141606437;
							continue;
						case 1:
							return new string[0];
						case 0:
						{
							int elementIdentifier = elements.buttons[num2].elementIdentifier;
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							if (num3 >= 0)
							{
								int num4;
								if (num3 >= identifiers.Length)
								{
									num = -1141606442;
									num4 = num;
								}
								else
								{
									num = -1141606448;
									num4 = num;
								}
								continue;
							}
							goto case 5;
						}
						case 3:
							array[num2] = identifiers[num3].name;
							num = -1141606447;
							continue;
						case 7:
							if (identifiers.Length >= buttonCount)
							{
								array = new string[buttonCount];
								num = -1141606441;
							}
							else
							{
								Logger.LogError("You have too few element identifiers!");
								num = -1141606446;
							}
							continue;
						case 5:
							Logger.LogError("Element identifier index is out of bounds!");
							num = -1141606447;
							continue;
						case 4:
							num2 = 0;
							num = -1141606437;
							continue;
						default:
							if (num2 >= array.Length)
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
				using (IEnumerator<Platform_Custom.Axis> enumerator = IterateAxes().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator.Current;
							int num = -1432728405;
							while (true)
							{
								switch (num ^ -1432728406)
								{
								case 0:
									num = -1432728402;
									continue;
								case 4:
									break;
								case 3:
									return true;
								case 1:
									goto IL_0055;
								default:
									goto end_IL_0034;
								}
								break;
								IL_0055:
								int num2;
								if (axis.elementIdentifier != elementIdentifierId)
								{
									num = -1432728408;
									num2 = num;
								}
								else
								{
									num = -1432728407;
									num2 = num;
								}
							}
							continue;
							end_IL_0034:
							break;
						}
					}
				}
				IEnumerator<Platform_Custom.Button> enumerator2 = IterateButtons().GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Button button = (Button)enumerator2.Current;
							int num3 = -1432728407;
							while (true)
							{
								switch (num3 ^ -1432728406)
								{
								case 0:
									num3 = -1432728405;
									continue;
								case 1:
									break;
								case 3:
									if (button.elementIdentifier == elementIdentifierId)
									{
										return true;
									}
									goto end_IL_00b4;
								default:
									goto end_IL_00b4;
								}
								break;
							}
							continue;
							end_IL_00b4:
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
							IL_00eb:
							int num4 = -1432728405;
							while (true)
							{
								switch (num4 ^ -1432728406)
								{
								case 2:
									break;
								default:
									goto end_IL_00f0;
								case 1:
									goto IL_0109;
								case 0:
									goto end_IL_00f0;
								}
								goto IL_00eb;
								IL_0109:
								enumerator2.Dispose();
								num4 = -1432728406;
								continue;
								end_IL_00f0:
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
				axes = new int[assignedAxisCount];
				int num = 0;
				IEnumerator<Platform_Custom.Button> enumerator = IterateButtons().GetEnumerator();
				try
				{
					while (true)
					{
						IL_006d:
						int num2;
						int num3;
						if (!enumerator.MoveNext())
						{
							num2 = -2134472908;
							num3 = num2;
						}
						else
						{
							num2 = -2134472906;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -2134472905)
							{
							case 0:
								num2 = -2134472906;
								continue;
							default:
								goto end_IL_002f;
							case 1:
							{
								Button button = (Button)enumerator.Current;
								buttons[num] = button.elementIdentifier;
								num++;
								num2 = -2134472907;
								continue;
							}
							case 2:
								break;
							case 3:
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
				finally
				{
					if (enumerator != null)
					{
						while (true)
						{
							IL_008b:
							int num4 = -2134472906;
							while (true)
							{
								switch (num4 ^ -2134472905)
								{
								case 2:
									break;
								default:
									goto end_IL_0090;
								case 1:
									goto IL_00a9;
								case 0:
									goto end_IL_0090;
								}
								goto IL_008b;
								IL_00a9:
								enumerator.Dispose();
								num4 = -2134472905;
								continue;
								end_IL_0090:
								break;
							}
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
							int num5 = -2134472908;
							while (true)
							{
								switch (num5 ^ -2134472905)
								{
								case 2:
									num5 = -2134472906;
									continue;
								case 1:
									break;
								case 3:
									axes[num] = axis.elementIdentifier;
									num++;
									num5 = -2134472905;
									continue;
								default:
									goto end_IL_00ea;
								}
								break;
							}
							continue;
							end_IL_00ea:
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
					int num = 11635622;
					while (true)
					{
						switch (num ^ 0xB18BA7)
						{
						case 10:
							break;
						case 5:
							if (Axes_orig[num2].calibrateAxis)
							{
								array[num2].zero = axes_orig[num2].axisZero;
								array[num2].min = axes_orig[num2].axisMin;
								num = 11635623;
								continue;
							}
							goto case 7;
						case 8:
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							num = 11635618;
							continue;
						case 6:
							if (axes_orig[num2].sourceType == 0)
							{
								ref AxisCalibrationData reference2 = ref array[num2];
								reference2 = AxisCalibrationData.Default;
								num = 11635616;
								continue;
							}
							goto case 9;
						case 11:
							if (axes_orig[num2].sourceType != 1)
							{
								int num3;
								if (axes_orig[num2].sourceType != 100)
								{
									num = 11635617;
									num3 = num;
								}
								else
								{
									num = 11635619;
									num3 = num;
								}
								continue;
							}
							goto case 4;
						case 9:
							throw new NotImplementedException();
						case 4:
						{
							ref AxisCalibrationData reference = ref array[num2];
							reference = AxisCalibrationData.Default;
							num = 11635631;
							continue;
						}
						case 0:
							array[num2].max = axes_orig[num2].axisMax;
							num = 11635620;
							continue;
						case 3:
							num = 11635616;
							continue;
						case 1:
							if (axes_orig == null)
							{
								return null;
							}
							array = new AxisCalibrationData[axes_orig.Length];
							num2 = 0;
							num = 11635621;
							continue;
						case 7:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, deepClone: true);
							num2++;
							num = 11635621;
							continue;
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
					int num = 1829241487;
					while (true)
					{
						switch (num ^ 0x6D080287)
						{
						case 9:
							break;
						case 8:
							if (Axes_orig == null)
							{
								return;
							}
							goto case 1;
						case 7:
							num2++;
							num = 1829241474;
							continue;
						case 1:
							axisRanges = new AxisRange[Axes_orig.Length];
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = 1829241474;
							continue;
						case 3:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, createIfNull: true);
							if (Axes_orig[num2].sourceType != 1)
							{
								int num3;
								if (Axes_orig[num2].sourceType == 100)
								{
									num = 1829241477;
									num3 = num;
								}
								else
								{
									num = 1829241479;
									num3 = num;
								}
								continue;
							}
							goto case 2;
						case 4:
							throw new Exception();
						case 2:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = 1829241473;
							continue;
						case 0:
							if (Axes_orig[num2].sourceType == 0)
							{
								axisRanges[num2] = AxisRange.Full;
								num = 1829241472;
								continue;
							}
							goto case 4;
						case 6:
							num = 1829241472;
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
					int num = 245577118;
					while (true)
					{
						switch (num ^ 0xEA3359F)
						{
						case 3:
							break;
						case 1:
							if (Buttons_orig == null)
							{
								return;
							}
							goto case 0;
						case 2:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, createIfNull: true);
							num2++;
							num = 245577115;
							continue;
						case 0:
							buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
							num2 = 0;
							num = 245577115;
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
				Platform_PS5_Base platform_PS5_Base = new Platform_PS5_Base();
				CopyVars(platform_PS5_Base);
				return platform_PS5_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (!(destination is Platform_PS5_Base platform_PS5_Base))
				{
					return;
				}
				while (true)
				{
					platform_PS5_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_PS5_Base.elements = MiscTools.DeepClone(elements);
					platform_PS5_Base.controllerName = controllerName;
					int num = -728391270;
					while (true)
					{
						switch (num ^ -728391270)
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
						num = -728391269;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_PS5 : Platform_PS5_Base
		{
			public Platform_PS5_Base[] variants;

			internal override IList<Platform> variants_base => variants;

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
						int num = -1883808410;
						while (true)
						{
							switch (num ^ -1883808414)
							{
							case 2:
								break;
							case 6:
								goto IL_0048;
							case 5:
								goto IL_0064;
							case 4:
								num2 = 0;
								num = -1883808415;
								continue;
							case 3:
								goto IL_007e;
							case 1:
								variantIndex = num2;
								return true;
							default:
								goto end_IL_001a;
							}
							break;
							IL_007e:
							int num3;
							if (num2 < variants.Length)
							{
								num = -1883808409;
								num3 = num;
							}
							else
							{
								num = -1883808414;
								num3 = num;
							}
							continue;
							IL_009f:
							num2++;
							num = -1883808415;
							continue;
							IL_0048:
							if (variants[num2].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
							{
								num = -1883808413;
								continue;
							}
							goto IL_009f;
							IL_0064:
							if (variants[num2] != null)
							{
								num = -1883808412;
								continue;
							}
							goto IL_009f;
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
				Platform_PS5 platform_PS = new Platform_PS5();
				CopyVars(platform_PS);
				return platform_PS;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_PS5 platform_PS = destination as Platform_PS5;
				while (true)
				{
					int num = -144192768;
					while (true)
					{
						switch (num ^ -144192765)
						{
						case 2:
							break;
						default:
							return;
						case 3:
							if (platform_PS != null)
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
						platform_PS.variants = MiscTools.DeepClone(variants);
						num = -144192766;
					}
				}
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
							goto IL_0008;
						}
						if (productName != null && productName.Length > 0)
						{
							return true;
						}
						int num;
						if (vidPid != null && vidPid.Length > 0)
						{
							num = -371171916;
							goto IL_000d;
						}
						return false;
						IL_0008:
						num = -371171913;
						goto IL_000d;
						IL_000d:
						switch (num ^ -371171915)
						{
						case 0:
							break;
						case 2:
							return true;
						default:
							return true;
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
					goto IL_00da;
					IL_000b:
					int num = -110547196;
					goto IL_0010;
					IL_0010:
					int num2 = default(int);
					int vendorId = default(int);
					int productId = default(int);
					while (true)
					{
						switch (num ^ -110547197)
						{
						case 5:
							break;
						case 1:
							if (num2 < vidPid.Length)
							{
								goto case 2;
							}
							goto IL_0163;
						case 2:
							vendorId = vidPid[num2].vendorId;
							productId = vidPid[num2].productId;
							num = -110547197;
							continue;
						case 8:
							return false;
						case 0:
							goto IL_00a4;
						case 7:
							goto IL_00c8;
						case 4:
							goto IL_0117;
						case 3:
							goto IL_0135;
						default:
							goto IL_015b;
						}
						break;
						IL_0135:
						string text = bridgedControllerHWInfo.hw_productName;
						goto IL_0142;
						IL_00a4:
						if (!ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
						{
							goto IL_0081;
						}
						if (bridgedControllerHWInfo.hw_productName != null)
						{
							num = -110547200;
							continue;
						}
						text = string.Empty;
						goto IL_0142;
						IL_0081:
						if (bridgedControllerHWInfo.hw_vendorId == vendorId && bridgedControllerHWInfo.hw_productId == productId)
						{
							return true;
						}
						num2++;
						num = -110547198;
						continue;
						IL_0142:
						string name = text;
						if (!ProductNameMatches(name))
						{
							num = -110547189;
							continue;
						}
						goto IL_0081;
					}
					goto IL_000b;
					IL_0163:
					return false;
					IL_00da:
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					if (!ElementCountsMatch(bridgedControllerHWInfo, out var _))
					{
						return false;
					}
					string text2 = bridgedControllerHWInfo.hw_productName;
					if (text2 == null)
					{
						text2 = string.Empty;
						num = -110547193;
						goto IL_0010;
					}
					goto IL_0117;
					IL_00c8:
					if (hasData && isAllowed)
					{
						return true;
					}
					goto IL_00da;
					IL_0117:
					text2 = text2.Trim();
					if (!strictMatch)
					{
						goto IL_015b;
					}
					if (vidPid != null)
					{
						num2 = 0;
						num = -110547198;
						goto IL_0010;
					}
					goto IL_0163;
					IL_015b:
					return ProductNameMatches(text2);
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						goto IL_000a;
					}
					int num;
					if (alternateMatched)
					{
						num = 1789114930;
						goto IL_000f;
					}
					if (hatCount >= 0)
					{
						return bridgedControllerHWInfo.hardwareHatCount == hatCount;
					}
					return true;
					IL_000f:
					switch (num ^ 0x6AA3BA33)
					{
					case 0:
						break;
					case 2:
						return false;
					default:
						return true;
					}
					goto IL_000a;
					IL_000a:
					num = 1789114929;
					goto IL_000f;
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
						switch (-2079181848 ^ -2079181847)
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
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					matchingCriteria.vidPid = ArrayTools.ShallowCopy(vidPid);
					matchingCriteria.hatCount = hatCount;
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
						int num2 = -1066694707;
						while (true)
						{
							switch (num2 ^ -1066694706)
							{
							case 0:
								break;
							case 3:
								num2 = -1066694705;
								continue;
							case 2:
							{
								string searchFor = productName[num];
								if (MatchingCriteria_Base.StringMatches(name, searchFor, productName_useRegex))
								{
									return true;
								}
								num++;
								num2 = -1066694705;
								continue;
							}
							default:
								if (num >= productName.Length)
								{
									return false;
								}
								goto case 2;
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
						IL_0055:
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = 447856716;
							goto IL_0009;
						}
						goto IL_0032;
						IL_0009:
						while (true)
						{
							switch (num3 ^ 0x1AB1C04F)
							{
							case 4:
								num3 = 447856713;
								continue;
							case 6:
								break;
							case 3:
								num3 = 447856718;
								continue;
							case 0:
								goto IL_0055;
							case 5:
								goto IL_0067;
							case 2:
								return ControllerElementType.Axis;
							default:
								if (num2 >= buttonCount)
								{
									return elementIdentifier.elementType;
								}
								goto IL_0067;
							}
							break;
							IL_0067:
							if (buttons[num2].elementIdentifier == elementIdentifier.id)
							{
								return ControllerElementType.Button;
							}
							num2++;
							num3 = 447856718;
						}
						goto IL_0032;
						IL_0032:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							num3 = 447856717;
						}
						else
						{
							num++;
							num3 = 447856719;
						}
						goto IL_0009;
					}
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					int sourceType = default(int);
					while (true)
					{
						IL_00ca:
						int num2;
						if (num >= axisCount)
						{
							axisRange = AxisRange.Full;
							num2 = 188114189;
							goto IL_000c;
						}
						goto IL_0048;
						IL_000c:
						while (true)
						{
							switch (num2 ^ 0xB366504)
							{
							case 3:
								num2 = 188114190;
								continue;
							case 10:
								break;
							case 4:
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = 188114179;
									continue;
								}
								goto case 7;
							case 1:
								goto end_IL_00ca;
							case 7:
								return true;
							case 5:
								goto IL_00ca;
							case 6:
								goto IL_00e3;
							case 2:
								goto IL_00f2;
							case 0:
								goto IL_0100;
							case 8:
								return true;
							default:
								return false;
							}
							break;
							IL_00e3:
							if (sourceType != 100)
							{
								throw new NotImplementedException();
							}
							num2 = 188114180;
						}
						goto IL_0048;
						IL_0048:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							sourceType = axes[num].sourceType;
							switch (sourceType)
							{
							case 0:
								goto IL_00bd;
							case 1:
								goto IL_0100;
							case 2:
								goto IL_011b;
							}
							num2 = 188114178;
							goto IL_000c;
						}
						goto IL_00f2;
						IL_00f2:
						num++;
						num2 = 188114177;
						goto IL_000c;
						IL_011b:
						axisRange = axes[num].sourceHatRange;
						if (!axes[num].invert)
						{
							break;
						}
						axisRange = InputTools.InvertAxisRange(axisRange);
						num2 = 188114181;
						goto IL_000c;
						IL_0100:
						axisRange = axes[num].sourceAxisRange;
						num2 = 188114176;
						goto IL_000c;
						IL_00bd:
						axisRange = AxisRange.Positive;
						num2 = 188114188;
						goto IL_000c;
						continue;
						end_IL_00ca:
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
					if (destination is Elements elements)
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
					Button button = default(Button);
					while (true)
					{
						int num = 728972734;
						while (true)
						{
							switch (num ^ 0x2B733DBD)
							{
							case 0:
								break;
							default:
								return;
							case 3:
							{
								button = destination as Button;
								int num2;
								if (button != null)
								{
									num = 728972732;
									num2 = num;
								}
								else
								{
									num = 728972735;
									num2 = num;
								}
								continue;
							}
							case 1:
								button.sourceHat = sourceHat;
								num = 728972728;
								continue;
							case 2:
								return;
							case 5:
								button.sourceHatDirection = sourceHatDirection;
								button.sourceHatType = sourceHatType;
								num = 728972729;
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
					while (true)
					{
						int num = -1299106229;
						while (true)
						{
							switch (num ^ -1299106230)
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
							CopyVars(axis);
							num = -1299106230;
						}
					}
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					Axis axis = destination as Axis;
					while (true)
					{
						int num = 67708507;
						while (true)
						{
							switch (num ^ 0x4092658)
							{
							case 2:
								break;
							case 3:
								if (axis != null)
								{
									goto IL_003b;
								}
								return;
							case 0:
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
							num = 67708505;
						}
					}
				}
			}

			private sealed class AmfpCyApnUdrUETwrFYKmpMojhz : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_InternalDriver_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int GcodFlAmHuuHutvOOwqYiTffbQe;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					AmfpCyApnUdrUETwrFYKmpMojhz amfpCyApnUdrUETwrFYKmpMojhz;
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						amfpCyApnUdrUETwrFYKmpMojhz = this;
						goto IL_0025;
					}
					goto IL_004e;
					IL_002a:
					int num;
					while (true)
					{
						switch (num ^ 0x13FCBE5A)
						{
						case 0:
							break;
						case 1:
							num = 335330904;
							continue;
						case 3:
							goto IL_004e;
						default:
							return amfpCyApnUdrUETwrFYKmpMojhz;
						}
						break;
					}
					goto IL_0025;
					IL_004e:
					amfpCyApnUdrUETwrFYKmpMojhz = new AmfpCyApnUdrUETwrFYKmpMojhz(0);
					amfpCyApnUdrUETwrFYKmpMojhz.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					num = 335330904;
					goto IL_002a;
					IL_0025:
					num = 335330907;
					goto IL_002a;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num;
					int num3;
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					default:
						num = 503580207;
						goto IL_001a;
					case 1:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = 503580200;
						goto IL_001a;
					case 0:
						goto IL_00ff;
						IL_001a:
						while (true)
						{
							switch (num ^ 0x1E04062B)
							{
							case 0:
								break;
							case 6:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes[GcodFlAmHuuHutvOOwqYiTffbQe];
								num = 503580202;
								continue;
							case 2:
								goto IL_0072;
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 3:
								GcodFlAmHuuHutvOOwqYiTffbQe++;
								num = 503580201;
								continue;
							case 4:
								num = 503580206;
								continue;
							case 7:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes != null)
								{
									GcodFlAmHuuHutvOOwqYiTffbQe = 0;
									num = 503580201;
									continue;
								}
								goto default;
							case 8:
								goto IL_00ff;
							default:
								return false;
							}
							break;
							IL_0072:
							int num2;
							if (GcodFlAmHuuHutvOOwqYiTffbQe < syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes.Length)
							{
								num = 503580205;
								num2 = num;
							}
							else
							{
								num = 503580206;
								num2 = num;
							}
						}
						goto default;
						IL_00ff:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null)
						{
							num = 503580204;
							num3 = num;
						}
						else
						{
							num = 503580206;
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
				public AmfpCyApnUdrUETwrFYKmpMojhz(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class FZmAEIlDscxIIdKpnyNLZUgEKTn : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_InternalDriver_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int mlqjEcVAQGclPsgnTyyGuEffWdD;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
					{
						goto IL_0012;
					}
					goto IL_004b;
					IL_0012:
					int num = 1476878048;
					goto IL_0017;
					IL_0017:
					FZmAEIlDscxIIdKpnyNLZUgEKTn fZmAEIlDscxIIdKpnyNLZUgEKTn = default(FZmAEIlDscxIIdKpnyNLZUgEKTn);
					while (true)
					{
						switch (num ^ 0x58075EE1)
						{
						case 4:
							break;
						case 2:
							fZmAEIlDscxIIdKpnyNLZUgEKTn.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
							num = 1476878050;
							continue;
						case 0:
							goto IL_004b;
						case 1:
							if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
							{
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								fZmAEIlDscxIIdKpnyNLZUgEKTn = this;
								num = 1476878050;
								continue;
							}
							goto IL_004b;
						default:
							return fZmAEIlDscxIIdKpnyNLZUgEKTn;
						}
						break;
					}
					goto IL_0012;
					IL_004b:
					fZmAEIlDscxIIdKpnyNLZUgEKTn = new FZmAEIlDscxIIdKpnyNLZUgEKTn(0);
					num = 1476878051;
					goto IL_0017;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = -468431671;
						while (true)
						{
							switch (num2 ^ -468431670)
							{
							case 2:
								break;
							case 0:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 5:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null && syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons != null)
								{
									mlqjEcVAQGclPsgnTyyGuEffWdD = 0;
									num2 = -468431666;
									continue;
								}
								goto default;
							case 3:
								switch (num)
								{
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									mlqjEcVAQGclPsgnTyyGuEffWdD++;
									num2 = -468431666;
									continue;
								case 0:
									break;
								default:
									num2 = -468431668;
									continue;
								}
								goto case 5;
							case 4:
							{
								int num3;
								if (mlqjEcVAQGclPsgnTyyGuEffWdD < syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons.Length)
								{
									num2 = -468431669;
									num3 = num2;
								}
								else
								{
									num2 = -468431668;
									num3 = num2;
								}
								continue;
							}
							case 1:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons[mlqjEcVAQGclPsgnTyyGuEffWdD];
								num2 = -468431670;
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
				public FZmAEIlDscxIIdKpnyNLZUgEKTn(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.ZttKGDSUEbTObEfblEyIYTXbRoc;

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
							int num = 1103407904;
							while (true)
							{
								switch (num ^ 0x41C4AB23)
								{
								case 0:
									break;
								case 4:
									goto IL_0035;
								case 2:
									_axesOrigGame[num2] = axes_orig[num2];
									num2++;
									num = 1103407911;
									continue;
								case 3:
									if (axes_orig != null)
									{
										_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
										num2 = 0;
										num = 1103407911;
										continue;
									}
									goto end_IL_000f;
								default:
									goto end_IL_000f;
								}
								break;
								IL_0035:
								int num3;
								if (num2 >= axes_orig.Length)
								{
									num = 1103407906;
									num3 = num;
								}
								else
								{
									num = 1103407905;
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
								if (num < buttons_orig.Length)
								{
									num2 = -1653715296;
									num3 = num2;
								}
								else
								{
									num2 = -1653715294;
									num3 = num2;
								}
								while (true)
								{
									switch (num2 ^ -1653715295)
									{
									case 2:
										num2 = -1653715296;
										continue;
									case 1:
										_buttonsOrigGame[num] = buttons_orig[num];
										num2 = -1653715295;
										continue;
									case 4:
										break;
									case 0:
										num++;
										num2 = -1653715291;
										continue;
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
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						num = 1238337342;
						goto IL_000d;
					}
					return true;
					IL_0008:
					num = 1238337341;
					goto IL_000d;
					IL_000d:
					switch (num ^ 0x49CF873C)
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
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal override Elements_Base elements_base => elements;

			internal override IList<Platform> variants_base => null;

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
				AmfpCyApnUdrUETwrFYKmpMojhz amfpCyApnUdrUETwrFYKmpMojhz = new AmfpCyApnUdrUETwrFYKmpMojhz(-2);
				while (true)
				{
					int num = -287103857;
					while (true)
					{
						switch (num ^ -287103859)
						{
						case 0:
							break;
						case 2:
							goto IL_0026;
						default:
							return amfpCyApnUdrUETwrFYKmpMojhz;
						}
						break;
						IL_0026:
						amfpCyApnUdrUETwrFYKmpMojhz.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
						num = -287103860;
					}
				}
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				FZmAEIlDscxIIdKpnyNLZUgEKTn fZmAEIlDscxIIdKpnyNLZUgEKTn = new FZmAEIlDscxIIdKpnyNLZUgEKTn(-2);
				fZmAEIlDscxIIdKpnyNLZUgEKTn.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return fZmAEIlDscxIIdKpnyNLZUgEKTn;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					goto IL_0013;
				}
				string[] array = new string[elements.axisCount];
				int num = 0;
				int num2 = -200635109;
				goto IL_0018;
				IL_0018:
				int num3 = default(int);
				while (true)
				{
					switch (num2 ^ -200635106)
					{
					case 6:
						break;
					case 9:
					{
						int elementIdentifier = elements.axes[num].elementIdentifier;
						num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						num2 = -200635105;
						continue;
					}
					case 3:
						num++;
						num2 = -200635110;
						continue;
					case 1:
						if (num3 >= 0)
						{
							int num5;
							if (num3 < identifiers.Length)
							{
								num2 = -200635106;
								num5 = num2;
							}
							else
							{
								num2 = -200635108;
								num5 = num2;
							}
							continue;
						}
						goto case 2;
					case 8:
						Logger.LogError("You have too few element identifiers!");
						return new string[0];
					case 4:
					{
						int num4;
						if (num < array.Length)
						{
							num2 = -200635113;
							num4 = num2;
						}
						else
						{
							num2 = -200635111;
							num4 = num2;
						}
						continue;
					}
					case 0:
						array[num] = identifiers[num3].name;
						num2 = -200635107;
						continue;
					case 5:
						num2 = -200635110;
						continue;
					case 2:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = -200635107;
						continue;
					default:
						return array;
					}
					break;
				}
				goto IL_0013;
				IL_0013:
				num2 = -200635114;
				goto IL_0018;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				string[] array = default(string[]);
				int num2 = default(int);
				int num3 = default(int);
				int elementIdentifier = default(int);
				while (true)
				{
					int num = 1578868656;
					while (true)
					{
						switch (num ^ 0x5E1B9FB8)
						{
						case 5:
							break;
						case 6:
							array[num2] = identifiers[num3].name;
							num = 1578868671;
							continue;
						case 0:
							Logger.LogError("You have too few element identifiers!");
							return new string[0];
						case 8:
							if (identifiers.Length >= buttonCount)
							{
								array = new string[buttonCount];
								num = 1578868668;
							}
							else
							{
								num = 1578868664;
							}
							continue;
						case 3:
							elementIdentifier = elements.buttons[num2].elementIdentifier;
							num = 1578868666;
							continue;
						case 2:
							num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							if (num3 >= 0)
							{
								int num4;
								if (num3 >= identifiers.Length)
								{
									num = 1578868657;
									num4 = num;
								}
								else
								{
									num = 1578868670;
									num4 = num;
								}
								continue;
							}
							goto case 9;
						case 4:
							num2 = 0;
							num = 1578868665;
							continue;
						case 9:
							Logger.LogError("Element identifier index is out of bounds!");
							num = 1578868671;
							continue;
						case 7:
							num2++;
							num = 1578868665;
							continue;
						default:
							if (num2 >= array.Length)
							{
								return array;
							}
							goto case 3;
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
						Axis axis = (Axis)enumerator.Current;
						if (axis.elementIdentifier == elementIdentifierId)
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
							IL_005c:
							int num = 274642693;
							while (true)
							{
								switch (num ^ 0x105EB707)
								{
								case 0:
									break;
								default:
									goto end_IL_0061;
								case 2:
									goto IL_007a;
								case 1:
									goto end_IL_0061;
								}
								goto IL_005c;
								IL_007a:
								enumerator.Dispose();
								num = 274642694;
								continue;
								end_IL_0061:
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
							int num2;
							int num3;
							if (button.elementIdentifier == elementIdentifierId)
							{
								num2 = 274642694;
								num3 = num2;
							}
							else
							{
								num2 = 274642692;
								num3 = num2;
							}
							while (true)
							{
								switch (num2 ^ 0x105EB707)
								{
								case 0:
									num2 = 274642693;
									continue;
								case 2:
									break;
								case 1:
									return true;
								default:
									goto end_IL_00b9;
								}
								break;
							}
							continue;
							end_IL_00b9:
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
						IL_006d:
						int num2;
						int num3;
						if (!enumerator.MoveNext())
						{
							num2 = -1587307133;
							num3 = num2;
						}
						else
						{
							num2 = -1587307134;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -1587307133)
							{
							case 2:
								num2 = -1587307134;
								continue;
							default:
								goto end_IL_002f;
							case 1:
							{
								Button button = (Button)enumerator.Current;
								buttons[num] = button.elementIdentifier;
								num++;
								num2 = -1587307136;
								continue;
							}
							case 3:
								break;
							case 0:
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
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator2.Current;
							axes[num] = axis.elementIdentifier;
							num++;
							int num4 = -1587307133;
							while (true)
							{
								switch (num4 ^ -1587307133)
								{
								case 2:
									num4 = -1587307134;
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
					int num = -148418795;
					while (true)
					{
						switch (num ^ -148418791)
						{
						case 8:
							break;
						case 12:
							num2 = 0;
							num = -148418789;
							continue;
						case 5:
						{
							ref AxisCalibrationData reference2 = ref array[num2];
							reference2 = AxisCalibrationData.Default;
							num = -148418785;
							continue;
						}
						case 11:
							throw new NotImplementedException();
						case 4:
						{
							ref AxisCalibrationData reference = ref array[num2];
							reference = AxisCalibrationData.Default;
							num = -148418797;
							continue;
						}
						case 9:
						{
							int num5;
							if (Axes_orig[num2].calibrateAxis)
							{
								num = -148418791;
								num5 = num;
							}
							else
							{
								num = -148418785;
								num5 = num;
							}
							continue;
						}
						case 7:
							if (axes_orig[num2].sourceType != 0)
							{
								int num6;
								if (axes_orig[num2].sourceType != 2)
								{
									num = -148418798;
									num6 = num;
								}
								else
								{
									num = -148418788;
									num6 = num;
								}
								continue;
							}
							goto case 5;
						case 3:
						{
							int num4;
							if (axes_orig[num2].sourceType == 100)
							{
								num = -148418787;
								num4 = num;
							}
							else
							{
								num = -148418786;
								num4 = num;
							}
							continue;
						}
						case 0:
							array[num2].zero = axes_orig[num2].axisZero;
							array[num2].min = axes_orig[num2].axisMin;
							array[num2].max = axes_orig[num2].axisMax;
							num = -148418785;
							continue;
						case 6:
							array[num2].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num2].alternateCalibrations, deepClone: true);
							num2++;
							num = -148418789;
							continue;
						case 10:
							array[num2].invert = axes_orig[num2].invert;
							array[num2].deadZone = axes_orig[num2].axisDeadZone;
							num = -148418800;
							continue;
						case 1:
						{
							int num3;
							if (axes_orig[num2].sourceType == 1)
							{
								num = -148418787;
								num3 = num;
							}
							else
							{
								num = -148418790;
								num3 = num;
							}
							continue;
						}
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
				axisInfos = null;
				if (Axes_orig == null)
				{
					return;
				}
				int num2 = default(int);
				while (true)
				{
					axisRanges = new AxisRange[Axes_orig.Length];
					int num = 1637296030;
					while (true)
					{
						switch (num ^ 0x6197279D)
						{
						case 0:
							num = 1637296031;
							continue;
						case 6:
							axisRanges[num2] = AxisRange.Full;
							num = 1637296020;
							continue;
						case 3:
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num = 1637296025;
							continue;
						case 1:
							throw new Exception();
						case 9:
							num = 1637296026;
							continue;
						case 7:
							num2++;
							num = 1637296022;
							continue;
						case 4:
							num2 = 0;
							num = 1637296022;
							continue;
						case 12:
							num = 1637296026;
							continue;
						case 8:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = 1637296017;
							continue;
						case 5:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, createIfNull: true);
							if (Axes_orig[num2].sourceType != 1)
							{
								int num4;
								if (Axes_orig[num2].sourceType == 100)
								{
									num = 1637296021;
									num4 = num;
								}
								else
								{
									num = 1637296023;
									num4 = num;
								}
								continue;
							}
							goto case 8;
						case 10:
							if (Axes_orig[num2].sourceType != 0)
							{
								int num3;
								if (Axes_orig[num2].sourceType != 2)
								{
									num = 1637296028;
									num3 = num;
								}
								else
								{
									num = 1637296027;
									num3 = num;
								}
								continue;
							}
							goto case 6;
						case 2:
							break;
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
					int num = 230674752;
					while (true)
					{
						switch (num ^ 0xDBFD142)
						{
						case 3:
							break;
						case 2:
							if (Buttons_orig == null)
							{
								return;
							}
							goto case 4;
						case 0:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, createIfNull: true);
							num2++;
							num = 230674755;
							continue;
						case 4:
							buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
							num2 = 0;
							num = 230674755;
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
				Platform_InternalDriver_Base platform_InternalDriver_Base = new Platform_InternalDriver_Base();
				CopyVars(platform_InternalDriver_Base);
				return platform_InternalDriver_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (!(destination is Platform_InternalDriver_Base platform_InternalDriver_Base))
				{
					return;
				}
				while (true)
				{
					platform_InternalDriver_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_InternalDriver_Base.elements = MiscTools.DeepClone(elements);
					int num = 1800551450;
					while (true)
					{
						switch (num ^ 0x6B523C18)
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
						num = 1800551449;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_InternalDriver : Platform_InternalDriver_Base
		{
			public Platform_InternalDriver_Base[] variants;

			internal override IList<Platform> variants_base => variants;

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
							num2 = -766886977;
							num3 = num2;
						}
						else
						{
							num2 = -766886979;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -766886979)
							{
							case 4:
								num2 = -766886977;
								continue;
							case 2:
								break;
							case 1:
								goto IL_0052;
							case 3:
								goto end_IL_0020;
							default:
								goto end_IL_0077;
							}
							if (variants[num] != null)
							{
								num2 = -766886980;
								continue;
							}
							goto IL_006c;
							IL_0052:
							if (variants[num].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
							{
								variantIndex = num;
								return true;
							}
							goto IL_006c;
							IL_006c:
							num++;
							num2 = -766886978;
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
				Platform_InternalDriver platform_InternalDriver = new Platform_InternalDriver();
				CopyVars(platform_InternalDriver);
				return platform_InternalDriver;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_InternalDriver platform_InternalDriver = default(Platform_InternalDriver);
				while (true)
				{
					switch (-2069343082 ^ -2069343081)
					{
					case 2:
						continue;
					case 1:
						platform_InternalDriver = destination as Platform_InternalDriver;
						if (platform_InternalDriver == null)
						{
							return;
						}
						break;
					}
					break;
				}
				platform_InternalDriver.variants = MiscTools.DeepClone(variants);
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
						dRRcHzjfmpPQmjfIpMUExpcDkuyC(elementCount);
						return elementCount;
					}

					internal override void dRRcHzjfmpPQmjfIpMUExpcDkuyC(ElementCount_Base P_0)
					{
						base.dRRcHzjfmpPQmjfIpMUExpcDkuyC(P_0);
						if (!(P_0 is ElementCount elementCount))
						{
							return;
						}
						while (true)
						{
							elementCount.hatCount = hatCount;
							int num = -1260551253;
							while (true)
							{
								switch (num ^ -1260551254)
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
								num = -1260551256;
							}
						}
					}

					internal override bool YfzaYuFFeAGpZYIlhOCKodCcBwd(BridgedControllerHWInfo P_0)
					{
						if (!base.YfzaYuFFeAGpZYIlhOCKodCcBwd(P_0))
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

				internal override int alternateElementCount => 0;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						goto IL_001b;
					}
					int num;
					if (base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						if (!strictMatch)
						{
							return AnyNameMatches(bridgedControllerHWInfo);
						}
						if (!PidVid.ArrayContains(productGUID, ref bridgedControllerHWInfo.hw_pidVid))
						{
							goto IL_00a2;
						}
						if (ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
						{
							if (productName == null)
							{
								goto IL_00a0;
							}
							if (productName.Length != 0)
							{
								goto IL_00a2;
							}
							num = 1143329980;
						}
						else
						{
							num = 1143329981;
						}
					}
					else
					{
						num = 1143329977;
					}
					goto IL_0020;
					IL_00a2:
					if (!AnyNameMatches(bridgedControllerHWInfo))
					{
						return false;
					}
					return true;
					IL_0020:
					switch (num ^ 0x4425D4BD)
					{
					case 3:
						break;
					case 0:
						return true;
					case 4:
						return false;
					case 2:
						return true;
					default:
						goto IL_00a0;
					}
					goto IL_001b;
					IL_00a0:
					return true;
					IL_001b:
					num = 1143329983;
					goto IL_0020;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
					{
						goto IL_000a;
					}
					int num;
					if (alternateMatched)
					{
						num = -1037700450;
						goto IL_000f;
					}
					if (hatCount >= 0)
					{
						return bridgedControllerHWInfo.hardwareHatCount == hatCount;
					}
					return true;
					IL_000f:
					switch (num ^ -1037700452)
					{
					case 0:
						break;
					case 1:
						return false;
					default:
						return true;
					}
					goto IL_000a;
					IL_000a:
					num = -1037700451;
					goto IL_000f;
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
						num2 = 579629869;
						goto IL_0010;
					}
					goto IL_002d;
					IL_0010:
					while (true)
					{
						switch (num2 ^ 0x228C732E)
						{
						case 2:
							break;
						case 1:
							goto IL_002d;
						case 0:
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
						num2 = 579629869;
					}
					goto IL_000b;
					IL_002d:
					return false;
					IL_000b:
					num2 = 579629871;
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
					if (!(destination is MatchingCriteria matchingCriteria))
					{
						return;
					}
					while (true)
					{
						matchingCriteria.hatCount = hatCount;
						int num = -2094410748;
						while (true)
						{
							switch (num ^ -2094410745)
							{
							case 2:
								num = -2094410746;
								continue;
							case 1:
								break;
							case 3:
								matchingCriteria.manufacturer_useRegex = manufacturer_useRegex;
								matchingCriteria.productName_useRegex = productName_useRegex;
								matchingCriteria.systemName_useRegex = systemName_useRegex;
								matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
								num = -2094410745;
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
				private sealed class xaAZEvMhpCSUTVbnaRrctbxfzIZ : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
				{
					private Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public Elements syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public int CQGbSHCYLJucGTWghEBAGAlUSgy;

					Axis IEnumerator<Axis>.Current
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
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
						{
							goto IL_0012;
						}
						goto IL_004e;
						IL_0012:
						int num = 8716483;
						goto IL_0017;
						IL_0017:
						xaAZEvMhpCSUTVbnaRrctbxfzIZ xaAZEvMhpCSUTVbnaRrctbxfzIZ2 = default(xaAZEvMhpCSUTVbnaRrctbxfzIZ);
						while (true)
						{
							switch (num ^ 0x8500C1)
							{
							case 0:
								break;
							case 2:
								if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
								{
									isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
									xaAZEvMhpCSUTVbnaRrctbxfzIZ2 = this;
									num = 8716482;
									continue;
								}
								goto IL_004e;
							case 1:
								goto IL_004e;
							default:
								return xaAZEvMhpCSUTVbnaRrctbxfzIZ2;
							}
							break;
						}
						goto IL_0012;
						IL_004e:
						xaAZEvMhpCSUTVbnaRrctbxfzIZ2 = new xaAZEvMhpCSUTVbnaRrctbxfzIZ(0);
						xaAZEvMhpCSUTVbnaRrctbxfzIZ2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = 8716482;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 0:
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							int num2;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.axes != null)
							{
								num = -1261981928;
								num2 = num;
							}
							else
							{
								num = -1261981922;
								num2 = num;
							}
							goto IL_001f;
						}
						case 1:
							{
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								CQGbSHCYLJucGTWghEBAGAlUSgy++;
								num = -1261981925;
								goto IL_001f;
							}
							IL_001f:
							while (true)
							{
								switch (num ^ -1261981925)
								{
								case 2:
									num = -1261981926;
									continue;
								case 0:
									break;
								case 3:
									CQGbSHCYLJucGTWghEBAGAlUSgy = 0;
									num = -1261981925;
									continue;
								case 1:
									goto end_IL_001f;
								case 4:
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.axes[CQGbSHCYLJucGTWghEBAGAlUSgy];
									isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
									return true;
								default:
									goto end_IL_0008;
								}
								int num3;
								if (CQGbSHCYLJucGTWghEBAGAlUSgy < syCPfFbHYMDOvEPjTnPLBqiOhsPv.axes.Length)
								{
									num = -1261981921;
									num3 = num;
								}
								else
								{
									num = -1261981922;
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
					public xaAZEvMhpCSUTVbnaRrctbxfzIZ(int _003C_003E1__state)
					{
						while (true)
						{
							int num = -129628095;
							while (true)
							{
								switch (num ^ -129628096)
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
								isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
								TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
								num = -129628094;
							}
						}
					}
				}

				private sealed class KWzagksLyBuETrmDPDQzklXJwTKl : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerable, IEnumerator<Button>
				{
					private Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public Elements syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public int AYPevFBYmADqNpsNwPhcDkPMavO;

					Button IEnumerator<Button>.Current
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
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							goto IL_001c;
						}
						goto IL_0052;
						IL_0052:
						KWzagksLyBuETrmDPDQzklXJwTKl kWzagksLyBuETrmDPDQzklXJwTKl = new KWzagksLyBuETrmDPDQzklXJwTKl(0);
						int num = -53061082;
						goto IL_0021;
						IL_001c:
						num = -53061084;
						goto IL_0021;
						IL_0021:
						while (true)
						{
							switch (num ^ -53061082)
							{
							case 3:
								break;
							case 2:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								kWzagksLyBuETrmDPDQzklXJwTKl = this;
								num = -53061081;
								continue;
							case 4:
								goto IL_0052;
							case 0:
								kWzagksLyBuETrmDPDQzklXJwTKl.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
								num = -53061081;
								continue;
							default:
								return kWzagksLyBuETrmDPDQzklXJwTKl;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						default:
							num = -1360352035;
							goto IL_001a;
						case 1:
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							num = -1360352040;
							goto IL_001a;
						case 0:
							goto IL_0079;
							IL_001a:
							while (true)
							{
								switch (num ^ -1360352039)
								{
								case 7:
									break;
								case 5:
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttons[AYPevFBYmADqNpsNwPhcDkPMavO];
									isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
									return true;
								case 2:
									goto IL_0079;
								case 4:
									num = -1360352033;
									continue;
								case 3:
									num = -1360352039;
									continue;
								case 1:
									AYPevFBYmADqNpsNwPhcDkPMavO++;
									num = -1360352039;
									continue;
								case 0:
									goto IL_00ca;
								default:
									goto end_IL_0008;
								}
								break;
								IL_00ca:
								int num2;
								if (AYPevFBYmADqNpsNwPhcDkPMavO < syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttons.Length)
								{
									num = -1360352036;
									num2 = num;
								}
								else
								{
									num = -1360352033;
									num2 = num;
								}
							}
							goto default;
							IL_0079:
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttons == null)
							{
								break;
							}
							AYPevFBYmADqNpsNwPhcDkPMavO = 0;
							num = -1360352038;
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
					public KWzagksLyBuETrmDPDQzklXJwTKl(int _003C_003E1__state)
					{
						while (true)
						{
							int num = 508760576;
							while (true)
							{
								switch (num ^ 0x1E531202)
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
								isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
								TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
								num = 508760579;
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

				internal IEnumerable<Axis> Axes
				{
					get
					{
						xaAZEvMhpCSUTVbnaRrctbxfzIZ xaAZEvMhpCSUTVbnaRrctbxfzIZ2 = new xaAZEvMhpCSUTVbnaRrctbxfzIZ(-2);
						xaAZEvMhpCSUTVbnaRrctbxfzIZ2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
						return xaAZEvMhpCSUTVbnaRrctbxfzIZ2;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					get
					{
						KWzagksLyBuETrmDPDQzklXJwTKl kWzagksLyBuETrmDPDQzklXJwTKl = new KWzagksLyBuETrmDPDQzklXJwTKl(-2);
						kWzagksLyBuETrmDPDQzklXJwTKl.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
						return kWzagksLyBuETrmDPDQzklXJwTKl;
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
					int num3 = default(int);
					while (true)
					{
						int num2 = -379097329;
						while (true)
						{
							switch (num2 ^ -379097335)
							{
							case 4:
								break;
							case 5:
								return ControllerElementType.Axis;
							case 0:
								if (num >= axisCount)
								{
									num3 = 0;
									num2 = -379097336;
									continue;
								}
								goto case 2;
							case 3:
								if (buttons[num3].elementIdentifier == elementIdentifier.id)
								{
									return ControllerElementType.Button;
								}
								num3++;
								num2 = -379097336;
								continue;
							case 2:
								if (axes[num].elementIdentifier != elementIdentifier.id)
								{
									num++;
									num2 = -379097335;
								}
								else
								{
									num2 = -379097332;
								}
								continue;
							case 6:
								num2 = -379097335;
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
					HardwareElementSourceTypeWithHat sourceType = default(HardwareElementSourceTypeWithHat);
					while (num < axisCount)
					{
						while (true)
						{
							int num2;
							int num3;
							if (axes[num].elementIdentifier != elementIdentifier.id)
							{
								num2 = -417628515;
								num3 = num2;
							}
							else
							{
								num2 = -417628520;
								num3 = num2;
							}
							while (true)
							{
								switch (num2 ^ -417628518)
								{
								case 0:
									num2 = -417628525;
									continue;
								case 3:
									return true;
								case 5:
									break;
								case 2:
									sourceType = axes[num].sourceType;
									num2 = -417628526;
									continue;
								case 7:
									num++;
									num2 = -417628528;
									continue;
								case 4:
									goto IL_00bc;
								case 8:
									goto IL_00ce;
								case 1:
									goto IL_00ef;
								case 9:
									goto end_IL_000c;
								case 6:
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -417628519;
									continue;
								default:
									goto end_IL_0112;
								}
								goto IL_007d;
								IL_00ef:
								int num4;
								if (axes[num].invert)
								{
									num2 = -417628516;
									num4 = num2;
								}
								else
								{
									num2 = -417628519;
									num4 = num2;
								}
								continue;
								IL_00bc:
								return true;
								IL_007d:
								axisRange = axes[num].sourceAxisRange;
								num2 = -417628517;
								continue;
								IL_00ce:
								switch (sourceType)
								{
								case HardwareElementSourceTypeWithHat.Button:
									axisRange = AxisRange.Positive;
									return true;
								case HardwareElementSourceTypeWithHat.Hat:
									break;
								case HardwareElementSourceTypeWithHat.Axis:
									goto IL_007d;
								default:
									throw new NotImplementedException();
								case HardwareElementSourceTypeWithHat.Custom:
									goto IL_00e5;
								}
								axisRange = axes[num].sourceHatRange;
								if (axes[num].invert)
								{
									axisRange = InputTools.InvertAxisRange(axisRange);
									num2 = -417628514;
									continue;
								}
								goto IL_00bc;
								IL_00e5:
								num2 = -417628513;
								continue;
								end_IL_000c:
								break;
							}
							continue;
							end_IL_0112:
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
					if (!(destination is Elements elements))
					{
						return;
					}
					while (true)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
						int num = -1915328477;
						while (true)
						{
							switch (num ^ -1915328477)
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
							num = -1915328478;
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
					while (true)
					{
						int num = 495060418;
						while (true)
						{
							switch (num ^ 0x1D8205C4)
							{
							case 0:
								break;
							default:
								return;
							case 4:
								buttonInfo = MiscTools.DeepClone(button.buttonInfo);
								num = 495060419;
								continue;
							case 2:
								elementIdentifier = button.elementIdentifier;
								num = 495060423;
								continue;
							case 8:
								requiredButtons = ArrayTools.ShallowCopy(button.requiredButtons);
								ignoreIfButtonsActive = button.ignoreIfButtonsActive;
								ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(button.ignoreIfButtonsActiveButtons);
								num = 495060416;
								continue;
							case 5:
								sourceAxis = button.sourceAxis;
								num = 495060421;
								continue;
							case 1:
								sourceAxisPole = button.sourceAxisPole;
								axisDeadZone = button.axisDeadZone;
								sourceHat = button.sourceHat;
								sourceHatType = button.sourceHatType;
								sourceHatDirection = button.sourceHatDirection;
								requireMultipleButtons = button.requireMultipleButtons;
								num = 495060428;
								continue;
							case 6:
								if (button == null)
								{
									return;
								}
								goto case 2;
							case 3:
								sourceType = button.sourceType;
								sourceButton = button.sourceButton;
								num = 495060417;
								continue;
							case 7:
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
					while (true)
					{
						int num = 1092147580;
						while (true)
						{
							switch (num ^ 0x4118D97E)
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
							num = 1092147583;
						}
					}
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
						int num = 760310436;
						while (true)
						{
							switch (num ^ 0x2D516AA2)
							{
							case 9:
								break;
							case 1:
								axisMax = axis.axisMax;
								axisInfo = MiscTools.DeepClone(axis.axisInfo);
								num = 760310433;
								continue;
							case 0:
								calibrateAxis = axis.calibrateAxis;
								axisZero = axis.axisZero;
								num = 760310437;
								continue;
							case 8:
								sourceType = axis.sourceType;
								sourceAxis = axis.sourceAxis;
								sourceAxisRange = axis.sourceAxisRange;
								invert = axis.invert;
								axisDeadZone = axis.axisDeadZone;
								num = 760310434;
								continue;
							case 7:
								axisMin = axis.axisMin;
								num = 760310435;
								continue;
							case 4:
								return;
							case 5:
								elementIdentifier = axis.elementIdentifier;
								num = 760310442;
								continue;
							case 3:
								sourceButton = axis.sourceButton;
								num = 760310432;
								continue;
							case 6:
							{
								int num2;
								if (axis == null)
								{
									num = 760310438;
									num2 = num;
								}
								else
								{
									num = 760310439;
									num2 = num;
								}
								continue;
							}
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
					}
				}
			}

			private sealed class HNphZgVRnNMnzUZCylHixsAsUMK : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_SDL2_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int pmNAmRBHVLgTddlWcwSchGvQNzcV;

				public int SGdGLseJeCJVDqKVAFqzXhJInWZX;

				Axis IEnumerator<Axis>.Current
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						goto IL_0023;
					}
					goto IL_004e;
					IL_0028:
					int num;
					HNphZgVRnNMnzUZCylHixsAsUMK hNphZgVRnNMnzUZCylHixsAsUMK = default(HNphZgVRnNMnzUZCylHixsAsUMK);
					while (true)
					{
						switch (num ^ 0x627B0A42)
						{
						case 0:
							break;
						case 2:
							hNphZgVRnNMnzUZCylHixsAsUMK = this;
							num = 1652230723;
							continue;
						case 3:
							goto IL_004e;
						default:
							return hNphZgVRnNMnzUZCylHixsAsUMK;
						}
						break;
					}
					goto IL_0023;
					IL_004e:
					hNphZgVRnNMnzUZCylHixsAsUMK = new HNphZgVRnNMnzUZCylHixsAsUMK(0);
					hNphZgVRnNMnzUZCylHixsAsUMK.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					num = 1652230723;
					goto IL_0028;
					IL_0023:
					num = 1652230720;
					goto IL_0028;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = -1420740969;
						while (true)
						{
							switch (num2 ^ -1420740975)
							{
							case 4:
								break;
							case 6:
								switch (num)
								{
								default:
									num2 = -1420740973;
									continue;
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									num2 = -1420740972;
									continue;
								case 0:
									break;
								}
								goto case 3;
							case 7:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 3:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null)
								{
									int num4;
									if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes != null)
									{
										num2 = -1420740975;
										num4 = num2;
									}
									else
									{
										num2 = -1420740973;
										num4 = num2;
									}
									continue;
								}
								goto default;
							case 0:
								pmNAmRBHVLgTddlWcwSchGvQNzcV = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes.Length;
								SGdGLseJeCJVDqKVAFqzXhJInWZX = 0;
								num2 = -1420740976;
								continue;
							case 1:
							{
								int num3;
								if (SGdGLseJeCJVDqKVAFqzXhJInWZX < pmNAmRBHVLgTddlWcwSchGvQNzcV)
								{
									num2 = -1420740967;
									num3 = num2;
								}
								else
								{
									num2 = -1420740973;
									num3 = num2;
								}
								continue;
							}
							case 8:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes[SGdGLseJeCJVDqKVAFqzXhJInWZX];
								num2 = -1420740970;
								continue;
							case 5:
								SGdGLseJeCJVDqKVAFqzXhJInWZX++;
								num2 = -1420740976;
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
				public HNphZgVRnNMnzUZCylHixsAsUMK(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class NhZAeQGSAXckBJvdocLFxEVOIdPE : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerable, IEnumerator<Button>
			{
				private Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_SDL2_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int UoLCGYMLwHZOomsaqSGhcvVORSJ;

				public int zkDVSAgxRRpzqmQNlSYLXpbeoLY;

				Button IEnumerator<Button>.Current
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						goto IL_0023;
					}
					goto IL_004e;
					IL_0028:
					int num;
					NhZAeQGSAXckBJvdocLFxEVOIdPE nhZAeQGSAXckBJvdocLFxEVOIdPE = default(NhZAeQGSAXckBJvdocLFxEVOIdPE);
					while (true)
					{
						switch (num ^ 0x1A1181AE)
						{
						case 2:
							break;
						case 1:
							nhZAeQGSAXckBJvdocLFxEVOIdPE = this;
							num = 437354925;
							continue;
						case 0:
							goto IL_004e;
						default:
							return nhZAeQGSAXckBJvdocLFxEVOIdPE;
						}
						break;
					}
					goto IL_0023;
					IL_004e:
					nhZAeQGSAXckBJvdocLFxEVOIdPE = new NhZAeQGSAXckBJvdocLFxEVOIdPE(0);
					nhZAeQGSAXckBJvdocLFxEVOIdPE.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					num = 437354925;
					goto IL_0028;
					IL_0023:
					num = 437354927;
					goto IL_0028;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = 745084794;
						while (true)
						{
							switch (num2 ^ 0x2C69177D)
							{
							case 5:
								break;
							case 7:
								switch (num)
								{
								default:
									num2 = 745084789;
									continue;
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									zkDVSAgxRRpzqmQNlSYLXpbeoLY++;
									num2 = 745084799;
									continue;
								case 0:
									break;
								}
								goto case 1;
							case 3:
								return true;
							case 2:
							{
								int num3;
								if (zkDVSAgxRRpzqmQNlSYLXpbeoLY < UoLCGYMLwHZOomsaqSGhcvVORSJ)
								{
									num2 = 745084788;
									num3 = num2;
								}
								else
								{
									num2 = 745084795;
									num3 = num2;
								}
								continue;
							}
							case 8:
								num2 = 745084795;
								continue;
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num2 = 745084793;
								continue;
							case 4:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null && syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons != null)
								{
									UoLCGYMLwHZOomsaqSGhcvVORSJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons.Length;
									zkDVSAgxRRpzqmQNlSYLXpbeoLY = 0;
									num2 = 745084797;
									continue;
								}
								goto default;
							case 0:
								num2 = 745084799;
								continue;
							case 9:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons[zkDVSAgxRRpzqmQNlSYLXpbeoLY];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num2 = 745084798;
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
				public NhZAeQGSAXckBJvdocLFxEVOIdPE(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform => InputPlatform.hzbbqXbtQbxKAebJVOPUbWKsXBI;

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

			internal override IList<Platform> variants_base => null;

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

			internal override Elements_Base elements_base => elements;

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
				int num2 = -364783622;
				goto IL_001a;
				IL_001a:
				int num5 = default(int);
				int elementIdentifier = default(int);
				int num3 = default(int);
				int num4 = default(int);
				while (true)
				{
					switch (num2 ^ -364783632)
					{
					case 8:
						break;
					case 5:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = -364783626;
						continue;
					case 7:
						num5 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						if (num5 >= 0)
						{
							int num6;
							if (num5 < num)
							{
								num2 = -364783623;
								num6 = num2;
							}
							else
							{
								num2 = -364783627;
								num6 = num2;
							}
							continue;
						}
						goto case 5;
					case 2:
						elementIdentifier = elements.axes[num3].elementIdentifier;
						num2 = -364783625;
						continue;
					case 0:
						return new string[0];
					case 4:
						num2 = -364783631;
						continue;
					case 6:
						num3++;
						num2 = -364783631;
						continue;
					case 9:
						array[num3] = identifiers[num5].name;
						num2 = -364783626;
						continue;
					case 3:
						Logger.LogError("You have too few element identifiers!");
						num2 = -364783632;
						continue;
					case 10:
						num4 = array.Length;
						num3 = 0;
						num2 = -364783628;
						continue;
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
				num2 = -364783629;
				goto IL_001a;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				int num = identifiers.Length;
				if (num < buttonCount)
				{
					goto IL_0014;
				}
				string[] array = new string[buttonCount];
				int num2 = 0;
				int num3 = 1096089114;
				goto IL_0019;
				IL_0019:
				int num4 = default(int);
				int elementIdentifier = default(int);
				while (true)
				{
					switch (num3 ^ 0x4154FE19)
					{
					case 5:
						break;
					case 1:
						Logger.LogError("You have too few element identifiers!");
						return new string[0];
					case 6:
						array[num2] = identifiers[num4].name;
						num3 = 1096089113;
						continue;
					case 0:
						num2++;
						num3 = 1096089114;
						continue;
					case 7:
						num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						if (num4 >= 0)
						{
							int num5;
							if (num4 < num)
							{
								num3 = 1096089119;
								num5 = num3;
							}
							else
							{
								num3 = 1096089115;
								num5 = num3;
							}
							continue;
						}
						goto case 2;
					case 2:
						Logger.LogError("Element identifier index is out of bounds!");
						num3 = 1096089113;
						continue;
					case 4:
						elementIdentifier = elements.buttons[num2].elementIdentifier;
						num3 = 1096089118;
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
				goto IL_0014;
				IL_0014:
				num3 = 1096089112;
				goto IL_0019;
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
							int num = -1649050759;
							while (true)
							{
								switch (num ^ -1649050755)
								{
								case 0:
									num = -1649050756;
									continue;
								case 4:
									if (current.elementIdentifier == elementIdentifierId)
									{
										result = true;
										num = -1649050754;
										continue;
									}
									goto end_IL_0052;
								case 1:
									break;
								default:
									goto end_IL_0052;
								case 3:
									goto IL_00f6;
								}
								break;
							}
							continue;
							end_IL_0052:
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
							int num2;
							int num3;
							if (current2.elementIdentifier != elementIdentifierId)
							{
								num2 = -1649050759;
								num3 = num2;
							}
							else
							{
								num2 = -1649050754;
								num3 = num2;
							}
							while (true)
							{
								switch (num2 ^ -1649050755)
								{
								case 0:
									num2 = -1649050756;
									continue;
								case 1:
									break;
								case 3:
									result = true;
									num2 = -1649050753;
									continue;
								default:
									goto end_IL_00a9;
								case 2:
									goto IL_00f6;
								}
								break;
							}
							continue;
							end_IL_00a9:
							break;
						}
					}
				}
				return false;
				IL_00f6:
				return result;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				axes = new int[assignedAxisCount];
				int num = 0;
				IEnumerator<Button> enumerator = IterateButtons().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Button current = enumerator.Current;
							buttons[num] = current.elementIdentifier;
							num++;
							int num2 = -1112744600;
							while (true)
							{
								switch (num2 ^ -1112744598)
								{
								case 0:
									num2 = -1112744597;
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
				finally
				{
					if (enumerator != null)
					{
						while (true)
						{
							IL_0071:
							int num3 = -1112744597;
							while (true)
							{
								switch (num3 ^ -1112744598)
								{
								case 0:
									break;
								default:
									goto end_IL_0076;
								case 1:
									goto IL_008f;
								case 2:
									goto end_IL_0076;
								}
								goto IL_0071;
								IL_008f:
								enumerator.Dispose();
								num3 = -1112744600;
								continue;
								end_IL_0076:
								break;
							}
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
							int num4 = -1112744597;
							while (true)
							{
								switch (num4 ^ -1112744598)
								{
								case 0:
									num4 = -1112744600;
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
				finally
				{
					if (enumerator2 != null)
					{
						while (true)
						{
							IL_00f8:
							int num5 = -1112744597;
							while (true)
							{
								switch (num5 ^ -1112744598)
								{
								case 0:
									break;
								default:
									goto end_IL_00fd;
								case 1:
									goto IL_0116;
								case 2:
									goto end_IL_00fd;
								}
								goto IL_00f8;
								IL_0116:
								enumerator2.Dispose();
								num5 = -1112744600;
								continue;
								end_IL_00fd:
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
				while (true)
				{
					int num2 = 296190824;
					while (true)
					{
						switch (num2 ^ 0x11A7836E)
						{
						case 9:
							break;
						case 6:
							num2 = 296190825;
							continue;
						case 4:
							throw new NotImplementedException();
						case 5:
							if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								int num4;
								if (axes_orig[num].sourceType == HardwareElementSourceTypeWithHat.Custom)
								{
									num2 = 296190831;
									num4 = num2;
								}
								else
								{
									num2 = 296190821;
									num4 = num2;
								}
								continue;
							}
							goto case 1;
						case 8:
							array[num].max = axes_orig[num].axisMax;
							num2 = 296190828;
							continue;
						case 10:
						{
							ref AxisCalibrationData reference2 = ref array[num];
							reference2 = AxisCalibrationData.Default;
							num2 = 296190830;
							continue;
						}
						case 0:
							num2 = 296190829;
							continue;
						case 1:
						{
							ref AxisCalibrationData reference = ref array[num];
							reference = AxisCalibrationData.Default;
							array[num].invert = axes_orig[num].invert;
							array[num].deadZone = axes_orig[num].axisDeadZone;
							if (Axes_orig[num].calibrateAxis)
							{
								array[num].zero = axes_orig[num].axisZero;
								array[num].min = axes_orig[num].axisMin;
								num2 = 296190822;
								continue;
							}
							goto case 3;
						}
						case 2:
							num2 = 296190829;
							continue;
						case 3:
							array[num].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num].alternateCalibrations, deepClone: true);
							num++;
							num2 = 296190825;
							continue;
						case 11:
							if (axes_orig[num].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								int num3;
								if (axes_orig[num].sourceType == HardwareElementSourceTypeWithHat.Hat)
								{
									num2 = 296190820;
									num3 = num2;
								}
								else
								{
									num2 = 296190826;
									num3 = num2;
								}
								continue;
							}
							goto case 10;
						default:
							if (num >= axes_orig.Length)
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
				int num2 = default(int);
				while (true)
				{
					int num = 638213978;
					while (true)
					{
						switch (num ^ 0x260A5F50)
						{
						case 11:
							break;
						case 0:
							num2 = 0;
							num = 638213973;
							continue;
						case 8:
							axisRanges[num2] = AxisRange.Full;
							num = 638213974;
							continue;
						case 9:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = 638213974;
							continue;
						case 12:
						{
							int num5;
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Hat)
							{
								num = 638213975;
								num5 = num;
							}
							else
							{
								num = 638213976;
								num5 = num;
							}
							continue;
						}
						case 10:
							axisInfos = null;
							if (Axes_orig == null)
							{
								return;
							}
							goto case 1;
						case 2:
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num = 638213968;
							continue;
						case 6:
							num2++;
							num = 638213973;
							continue;
						case 7:
							throw new Exception();
						case 4:
						{
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, createIfNull: true);
							int num6;
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Axis)
							{
								num = 638213981;
								num6 = num;
							}
							else
							{
								num = 638213977;
								num6 = num;
							}
							continue;
						}
						case 3:
						{
							int num4;
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Button)
							{
								num = 638213980;
								num4 = num;
							}
							else
							{
								num = 638213976;
								num4 = num;
							}
							continue;
						}
						case 13:
						{
							int num3;
							if (Axes_orig[num2].sourceType != HardwareElementSourceTypeWithHat.Custom)
							{
								num = 638213971;
								num3 = num;
							}
							else
							{
								num = 638213977;
								num3 = num;
							}
							continue;
						}
						case 1:
							axisRanges = new AxisRange[Axes_orig.Length];
							num = 638213970;
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
				int num2 = default(int);
				while (true)
				{
					int num = -1657778781;
					while (true)
					{
						switch (num ^ -1657778782)
						{
						case 4:
							break;
						case 2:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, createIfNull: true);
							num2++;
							num = -1657778783;
							continue;
						case 5:
							buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
							num2 = 0;
							num = -1657778783;
							continue;
						case 0:
							return;
						case 1:
						{
							int num3;
							if (Buttons_orig != null)
							{
								num = -1657778777;
								num3 = num;
							}
							else
							{
								num = -1657778782;
								num3 = num;
							}
							continue;
						}
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
				HNphZgVRnNMnzUZCylHixsAsUMK hNphZgVRnNMnzUZCylHixsAsUMK = new HNphZgVRnNMnzUZCylHixsAsUMK(-2);
				hNphZgVRnNMnzUZCylHixsAsUMK.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return hNphZgVRnNMnzUZCylHixsAsUMK;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				NhZAeQGSAXckBJvdocLFxEVOIdPE nhZAeQGSAXckBJvdocLFxEVOIdPE = new NhZAeQGSAXckBJvdocLFxEVOIdPE(-2);
				nhZAeQGSAXckBJvdocLFxEVOIdPE.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return nhZAeQGSAXckBJvdocLFxEVOIdPE;
			}

			public override object DeepClone()
			{
				Platform_SDL2_Base platform_SDL2_Base = new Platform_SDL2_Base();
				CopyVars(platform_SDL2_Base);
				return platform_SDL2_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				if (!(destination is Platform_SDL2_Base platform_SDL2_Base))
				{
					return;
				}
				while (true)
				{
					platform_SDL2_Base.elements = MiscTools.DeepClone(elements);
					int num = 1067035907;
					while (true)
					{
						switch (num ^ 0x3F99AD02)
						{
						case 0:
							goto IL_000b;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_000b:
						num = 1067035904;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_SDL2 : Platform_SDL2_Base
		{
			public Platform_SDL2_Base[] variants;

			internal override IList<Platform> variants_base => variants;

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
						int num = -1605442397;
						while (true)
						{
							switch (num ^ -1605442393)
							{
							case 0:
								break;
							case 5:
								variantIndex = num2;
								return true;
							case 3:
								goto IL_0054;
							case 4:
								num2 = 0;
								num = -1605442396;
								continue;
							case 2:
								goto IL_0079;
							default:
								goto end_IL_001a;
							}
							break;
							IL_0079:
							if (variants[num2] == null || !variants[num2].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
							{
								num2++;
								num = -1605442396;
							}
							else
							{
								num = -1605442398;
							}
							continue;
							IL_0054:
							int num3;
							if (num2 >= variants.Length)
							{
								num = -1605442394;
								num3 = num;
							}
							else
							{
								num = -1605442395;
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
				Platform_SDL2 platform_SDL = new Platform_SDL2();
				CopyVars(platform_SDL);
				return platform_SDL;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_SDL2 platform_SDL)
				{
					platform_SDL.variants = MiscTools.DeepClone(variants);
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
				internal override bool hasData => true;

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

				internal override int alternateElementCount => 0;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (disabled)
					{
						goto IL_0022;
					}
					int num;
					if (!isAllowed)
					{
						num = 1320743504;
						goto IL_0027;
					}
					return true;
					IL_0022:
					num = 1320743507;
					goto IL_0027;
					IL_0027:
					switch (num ^ 0x4EB8F252)
					{
					case 0:
						break;
					case 1:
						return false;
					default:
						return false;
					}
					goto IL_0022;
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
					while (true)
					{
						int num = 1364847510;
						while (true)
						{
							switch (num ^ 0x5159EB97)
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
							num = 1364847509;
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
			public sealed class Elements : Elements_Base
			{
				public override int buttonCount => 0;

				public override int axisCount => 0;

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

			internal override InputPlatform platform => InputPlatform.wHPBYVcSPaWTXCAyolOVCijkbqIm;

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
						num = 1345999815;
						goto IL_000d;
					}
					if (assignedAxisCount == 0 && assignedButtonCount == 0)
					{
						return false;
					}
					return true;
					IL_0008:
					num = 1345999812;
					goto IL_000d;
					IL_000d:
					switch (num ^ 0x503A53C5)
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
						return false;
					}
					if (matchingCriteria == null)
					{
						return false;
					}
					return matchingCriteria.isAllowed;
				}
			}

			internal override Elements_Base elements_base => elements;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				platformMap = null;
				if (matchingCriteria != null)
				{
					while (true)
					{
						int num = 360866203;
						while (true)
						{
							switch (num ^ 0x1582619A)
							{
							case 2:
								break;
							case 1:
								goto IL_002d;
							default:
								return true;
							}
							break;
							IL_002d:
							if (!matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
							{
								goto end_IL_000f;
							}
							platformMap = this;
							num = 360866202;
						}
						continue;
						end_IL_000f:
						break;
					}
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
					axisRange = AxisRange.Full;
					return false;
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
				while (true)
				{
					int num = 1485760686;
					while (true)
					{
						switch (num ^ 0x588EE8AD)
						{
						case 0:
							break;
						case 3:
							if (platform_Steam_Base != null)
							{
								goto IL_0034;
							}
							return;
						case 1:
							goto IL_0034;
						default:
							platform_Steam_Base.elements = MiscTools.DeepClone(elements);
							return;
						}
						break;
						IL_0034:
						platform_Steam_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
						num = 1485760687;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_Steam : Platform_Steam_Base
		{
			public Platform_Steam_Base[] variants;

			internal override IList<Platform> variants_base => variants;

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
							num2 = -610343236;
							num3 = num2;
						}
						else
						{
							num2 = -610343240;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -610343235)
							{
							case 4:
								num2 = -610343240;
								continue;
							case 0:
								return true;
							case 2:
								break;
							case 5:
								goto IL_0074;
							case 3:
								goto end_IL_0023;
							default:
								goto end_IL_0085;
							}
							if (variants[num].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
							{
								variantIndex = num;
								num2 = -610343235;
								continue;
							}
							goto IL_004a;
							IL_0074:
							if (variants[num] != null)
							{
								num2 = -610343233;
								continue;
							}
							goto IL_004a;
							IL_004a:
							num++;
							num2 = -610343234;
							continue;
							end_IL_0023:
							break;
						}
						continue;
						end_IL_0085:
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
				if (destination is Platform_Steam platform_Steam)
				{
					platform_Steam.variants = MiscTools.DeepClone(variants);
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
							int num = -105573675;
							while (true)
							{
								switch (num ^ -105573674)
								{
								case 0:
									break;
								case 3:
									clientInfo.browserVersionMin = browserVersionMin;
									num = -105573673;
									continue;
								case 1:
									clientInfo.browserVersionMax = browserVersionMax;
									clientInfo.os = os;
									clientInfo.osVersionMin = osVersionMin;
									clientInfo.osVersionMax = osVersionMax;
									num = -105573676;
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
							return true;
						}
						if (productName != null)
						{
							goto IL_0012;
						}
						goto IL_0053;
						IL_0084:
						int num;
						if (elementCount != null && elementCount.Length > 0)
						{
							num = 1539683895;
						}
						else
						{
							if (clientInfo == null || clientInfo.Length <= 0)
							{
								return false;
							}
							num = 1539683892;
						}
						goto IL_0017;
						IL_0012:
						num = 1539683894;
						goto IL_0017;
						IL_0017:
						while (true)
						{
							switch (num ^ 0x5BC5B637)
							{
							case 4:
								break;
							case 1:
								goto IL_003f;
							case 5:
								return true;
							case 2:
								goto IL_0077;
							case 0:
								return true;
							default:
								return true;
							}
							break;
							IL_003f:
							if (productName.Length > 0)
							{
								num = 1539683890;
								continue;
							}
							goto IL_0053;
						}
						goto IL_0012;
						IL_0053:
						if (mapping != null && mapping.Length > 0)
						{
							return true;
						}
						if (productGUID != null)
						{
							num = 1539683893;
							goto IL_0017;
						}
						goto IL_0084;
						IL_0077:
						if (productGUID.Length > 0)
						{
							return true;
						}
						goto IL_0084;
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
					goto IL_04a3;
					IL_04a3:
					bool result = default(bool);
					int num;
					if (base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						if (alwaysMatch)
						{
							return true;
						}
						result = false;
						num = -143409045;
					}
					else
					{
						num = -143409084;
					}
					goto IL_001b;
					IL_0016:
					num = -143409075;
					goto IL_001b;
					IL_001b:
					bool flag3 = default(bool);
					int num4 = default(int);
					int num5 = default(int);
					bool flag = default(bool);
					int num3 = default(int);
					int num6 = default(int);
					bool flag2 = default(bool);
					ElementCount_Base elementCount_Base = default(ElementCount_Base);
					int num2 = default(int);
					string text2 = default(string);
					string text = default(string);
					bool flag4 = default(bool);
					bool flag5 = default(bool);
					int num7 = default(int);
					ClientInfo clientInfo = default(ClientInfo);
					while (true)
					{
						switch (num ^ -143409080)
						{
						case 21:
							break;
						case 19:
							goto IL_00e3;
						case 2:
							flag3 = false;
							num = -143409051;
							continue;
						case 34:
							flag3 = true;
							num = -143409086;
							continue;
						case 16:
							num4 = mapping[num5];
							num = -143409061;
							continue;
						case 15:
							goto IL_0130;
						case 41:
							goto IL_0141;
						case 17:
							if (productGUID != null && productGUID.Length > 0 && !ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
							{
								flag = true;
								num = -143409069;
								continue;
							}
							goto IL_033f;
						case 37:
							goto IL_01a5;
						case 32:
							flag = true;
							num3 = 0;
							num = -143409068;
							continue;
						case 5:
							goto IL_01d1;
						case 39:
							if (bridgedControllerHWInfo.hw_pidVid.Equals(productGUID[num6]))
							{
								flag2 = true;
								num = -143409074;
								continue;
							}
							goto case 40;
						case 9:
							goto IL_020c;
						case 36:
							goto IL_022c;
						case 38:
							goto IL_023a;
						case 42:
							goto IL_025a;
						case 25:
							goto IL_02ce;
						case 1:
							goto IL_02f8;
						case 4:
							goto IL_0310;
						case 27:
							num6 = 0;
							num = -143409042;
							continue;
						case 10:
							num5++;
							num = -143409087;
							continue;
						case 6:
							goto IL_033f;
						case 28:
							num = -143409070;
							continue;
						case 23:
							num = -143409077;
							continue;
						case 26:
							goto IL_037e;
						case 43:
							elementCount_Base = elementCount[num2];
							if (elementCount_Base != null)
							{
								if (elementCount_Base.buttonCount >= 0)
								{
									goto IL_03ba;
								}
								goto case 11;
							}
							goto case 33;
						case 11:
							if (elementCount_Base.axisCount >= 0)
							{
								goto IL_03ea;
							}
							goto case 31;
						case 29:
							goto IL_040d;
						case 18:
							goto IL_0434;
						case 8:
							goto IL_0453;
						case 45:
							num5 = 0;
							num = -143409087;
							continue;
						case 14:
							num = -143409088;
							continue;
						case 12:
							return false;
						case 7:
							return true;
						case 40:
							num6++;
							num = -143409042;
							continue;
						case 30:
							num3++;
							num = -143409070;
							continue;
						case 35:
							text2 = StringTools.Trim(tag);
							num = -143409060;
							continue;
						case 22:
						{
							string searchFor = productName[num3];
							if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
							{
								flag2 = true;
								num = -143409079;
								continue;
							}
							goto case 30;
						}
						case 44:
							return false;
						case 20:
							goto IL_0524;
						case 0:
							goto IL_0564;
						case 31:
							flag4 = true;
							num = -143409047;
							continue;
						case 24:
							flag = false;
							num = -143409063;
							continue;
						case 33:
							num2++;
							num = -143409077;
							continue;
						case 3:
							if (num2 < elementCount.Length)
							{
								goto case 43;
							}
							goto IL_05aa;
						default:
							return result;
						}
						break;
						IL_05aa:
						if (flag4)
						{
							result = true;
							num = -143409071;
						}
						else
						{
							num = -143409052;
						}
						continue;
						IL_0310:
						if (!flag3)
						{
							return false;
						}
						result = true;
						num = -143409080;
						continue;
						IL_0564:
						flag2 = false;
						num = -143409072;
						continue;
						IL_0524:
						if (!string.IsNullOrEmpty(text2) && !string.Equals(bridgedControllerHWInfo.definitionMatchTag, text2, StringComparison.OrdinalIgnoreCase))
						{
							return false;
						}
						if (this.clientInfo != null && this.clientInfo.Length > 0)
						{
							flag5 = false;
							num7 = 0;
							num = -143409082;
							continue;
						}
						goto IL_0141;
						IL_02f8:
						if (flag2)
						{
							return true;
						}
						if (flag)
						{
							return false;
						}
						num = -143409083;
						continue;
						IL_020c:
						int num8;
						if (num5 < mapping.Length)
						{
							num = -143409064;
							num8 = num;
						}
						else
						{
							num = -143409076;
							num8 = num;
						}
						continue;
						IL_022c:
						num7++;
						num = -143409088;
						continue;
						IL_0141:
						if (elementCount != null && elementCount.Length > 0)
						{
							flag4 = false;
							num2 = 0;
							num = -143409057;
							continue;
						}
						goto IL_02ce;
						IL_0130:
						if (!flag5)
						{
							return false;
						}
						result = true;
						num = -143409055;
						continue;
						IL_0453:
						int num9;
						if (num7 >= this.clientInfo.Length)
						{
							num = -143409081;
							num9 = num;
						}
						else
						{
							num = -143409067;
							num9 = num;
						}
						continue;
						IL_01d1:
						if (isAllowed)
						{
							num = -143409073;
							continue;
						}
						goto IL_04a3;
						IL_025a:
						if (clientInfo.browser != (int)bridgedControllerHWInfo.webGL_webBrowserType)
						{
							goto IL_022c;
						}
						if (!CheckBrowserVersion(clientInfo.browser, clientInfo.browserVersionMin, clientInfo.browserVersionMax, bridgedControllerHWInfo.webGL_webBrowserVersionSplit))
						{
							return false;
						}
						goto IL_028d;
						IL_0434:
						int num10;
						if (productName.Length > 0)
						{
							num = -143409048;
							num10 = num;
						}
						else
						{
							num = -143409079;
							num10 = num;
						}
						continue;
						IL_00e3:
						int num11;
						if (num4 != (int)bridgedControllerHWInfo.webGL_mappingType)
						{
							num = -143409086;
							num11 = num;
						}
						else
						{
							num = -143409046;
							num11 = num;
						}
						continue;
						IL_033f:
						if (flag2)
						{
							return true;
						}
						text = StringTools.Trim(bridgedControllerHWInfo.hw_productName);
						if (text == null)
						{
							text = string.Empty;
							num = -143409043;
							continue;
						}
						goto IL_01a5;
						IL_040d:
						clientInfo = this.clientInfo[num7];
						if (clientInfo == null)
						{
							goto IL_022c;
						}
						if (clientInfo.browser != 0)
						{
							num = -143409054;
							continue;
						}
						goto IL_028d;
						IL_028d:
						if (clientInfo.os != 0)
						{
							if (clientInfo.os != (int)bridgedControllerHWInfo.webGL_osType)
							{
								goto IL_022c;
							}
							if (!CheckOSVersion(clientInfo.osVersionMin, clientInfo.osVersionMax, bridgedControllerHWInfo.webGL_osVersionSplit))
							{
								return false;
							}
						}
						flag5 = true;
						num = -143409081;
						continue;
						IL_023a:
						int num12;
						if (num6 >= productGUID.Length)
						{
							num = -143409074;
							num12 = num;
						}
						else
						{
							num = -143409041;
							num12 = num;
						}
						continue;
						IL_03ba:
						int num13;
						if (elementCount_Base.buttonCount == bridgedControllerHWInfo.hardwareButtonCount)
						{
							num = -143409085;
							num13 = num;
						}
						else
						{
							num = -143409047;
							num13 = num;
						}
						continue;
						IL_02ce:
						if (mapping != null)
						{
							int num14;
							if (mapping.Length <= 0)
							{
								num = -143409080;
								num14 = num;
							}
							else
							{
								num = -143409078;
								num14 = num;
							}
							continue;
						}
						goto IL_0564;
						IL_01a5:
						int num15;
						if (productName != null)
						{
							num = -143409062;
							num15 = num;
						}
						else
						{
							num = -143409079;
							num15 = num;
						}
						continue;
						IL_03ea:
						int num16;
						if (elementCount_Base.axisCount == bridgedControllerHWInfo.hardwareAxisCount)
						{
							num = -143409065;
							num16 = num;
						}
						else
						{
							num = -143409047;
							num16 = num;
						}
						continue;
						IL_037e:
						int num17;
						if (num3 >= productName.Length)
						{
							num = -143409079;
							num17 = num;
						}
						else
						{
							num = -143409058;
							num17 = num;
						}
					}
					goto IL_0016;
				}

				private static bool CheckBrowserVersion(int browser, string versionMin, string versionMax, string[] currentVersion)
				{
					versionMin = StringTools.Trim(versionMin);
					versionMax = StringTools.Trim(versionMax);
					bool flag3 = default(bool);
					int num6 = default(int);
					int num2 = default(int);
					int num4 = default(int);
					int result2 = default(int);
					int result = default(int);
					bool flag7 = default(bool);
					bool flag6 = default(bool);
					int result3 = default(int);
					int result4 = default(int);
					int num8 = default(int);
					bool flag8 = default(bool);
					string[] array2 = default(string[]);
					string[] array = default(string[]);
					while (true)
					{
						int num = -707535942;
						while (true)
						{
							switch (num ^ -707535957)
							{
							case 14:
								break;
							case 20:
								flag3 = false;
								num6 = 0;
								num = -707535965;
								continue;
							case 10:
								return true;
							case 3:
							{
								int num5;
								if (num2 >= num4)
								{
									num = -707535961;
									num5 = num;
								}
								else
								{
									num = -707535966;
									num5 = num;
								}
								continue;
							}
							case 13:
								if (result2 < result)
								{
									num = -707535953;
									continue;
								}
								flag7 = true;
								num = -707535955;
								continue;
							case 16:
								return false;
							case 1:
								num2 = 0;
								num = -707535960;
								continue;
							case 11:
								if (!flag6)
								{
									return true;
								}
								goto IL_0115;
							case 2:
								if (result3 <= result4)
								{
									flag3 = true;
									num6++;
									num = -707535965;
								}
								else
								{
									num = -707535941;
								}
								continue;
							case 0:
								if (!flag3)
								{
									num = -707535954;
									continue;
								}
								goto IL_02c0;
							case 8:
							{
								int num9;
								if (num6 < num8)
								{
									num = -707535938;
									num9 = num;
								}
								else
								{
									num = -707535957;
									num9 = num;
								}
								continue;
							}
							case 18:
								return false;
							case 7:
								if (!flag8)
								{
									num = -707535968;
									continue;
								}
								goto IL_0115;
							case 12:
								if (!flag7)
								{
									return false;
								}
								goto IL_0195;
							case 6:
								num2++;
								num = -707535960;
								continue;
							case 17:
								flag8 = !string.IsNullOrEmpty(versionMin);
								flag6 = !string.IsNullOrEmpty(versionMax);
								num = -707535956;
								continue;
							case 4:
								return false;
							case 21:
							{
								bool flag4 = int.TryParse(array2[num6], out result4);
								bool flag5 = int.TryParse(currentVersion[num6], out result3);
								int num7;
								if (flag4 && !flag5)
								{
									num = -707535944;
								}
								else if (!flag4)
								{
									num = -707535957;
									num7 = num;
								}
								else
								{
									num = -707535959;
									num7 = num;
								}
								continue;
							}
							case 15:
								return false;
							case 9:
							{
								bool flag = int.TryParse(array[num2], out result);
								bool flag2 = int.TryParse(currentVersion[num2], out result2);
								if (!flag || flag2)
								{
									int num3;
									if (flag)
									{
										num = -707535962;
										num3 = num;
									}
									else
									{
										num = -707535961;
										num3 = num;
									}
								}
								else
								{
									num = -707535943;
								}
								continue;
							}
							case 19:
								return false;
							default:
								{
									return false;
								}
								IL_02c0:
								return true;
								IL_0115:
								if (currentVersion != null)
								{
									if (currentVersion.Length == 0)
									{
										num = -707535964;
										continue;
									}
									switch (browser)
									{
									case -1:
									case 0:
										break;
									default:
										goto IL_008c;
									}
									goto case 10;
								}
								goto case 15;
								IL_008c:
								if (flag8)
								{
									array = versionMin.Split('.');
									num4 = MathTools.Min(array.Length, currentVersion.Length);
									flag7 = false;
									num = -707535958;
									continue;
								}
								goto IL_0195;
								IL_0195:
								if (flag6)
								{
									array2 = versionMax.Split('.');
									num8 = MathTools.Min(array2.Length, currentVersion.Length);
									num = -707535937;
									continue;
								}
								goto IL_02c0;
							}
							break;
						}
					}
				}

				private static bool CheckOSVersion(string versionMin, string versionMax, string[] currentVersion)
				{
					versionMin = StringTools.Trim(versionMin);
					versionMax = StringTools.Trim(versionMax);
					int num3 = default(int);
					int num2 = default(int);
					string[] array = default(string[]);
					bool flag3 = default(bool);
					int num6 = default(int);
					bool flag4 = default(bool);
					int result = default(int);
					bool flag5 = default(bool);
					int result2 = default(int);
					bool flag6 = default(bool);
					string[] array2 = default(string[]);
					int num4 = default(int);
					bool flag2 = default(bool);
					while (true)
					{
						int num = 529031994;
						while (true)
						{
							switch (num ^ 0x1F886335)
							{
							case 12:
								break;
							case 11:
							{
								int num5;
								if (num3 < num2)
								{
									num = 529031985;
									num5 = num;
								}
								else
								{
									num = 529031990;
									num5 = num;
								}
								continue;
							}
							case 6:
								array = versionMin.Split('.');
								num2 = MathTools.Min(array.Length, currentVersion.Length);
								flag3 = false;
								num3 = 0;
								num = 529031998;
								continue;
							case 5:
								return true;
							case 0:
								num6 = 0;
								num = 529031995;
								continue;
							case 4:
								flag4 = int.TryParse(array[num3], out result);
								flag5 = int.TryParse(currentVersion[num3], out result2);
								num = 529031972;
								continue;
							case 10:
								if (!flag5)
								{
									num = 529031992;
									continue;
								}
								goto IL_01f3;
							case 1:
								flag6 = false;
								num = 529031989;
								continue;
							case 16:
							{
								int result3;
								bool flag7 = int.TryParse(array2[num6], out result3);
								int result4;
								bool flag8 = int.TryParse(currentVersion[num6], out result4);
								if (flag7 && !flag8)
								{
									return false;
								}
								if (flag7)
								{
									if (result4 > result3)
									{
										num = 529031996;
										continue;
									}
									flag6 = true;
									num6++;
									num = 529031995;
									continue;
								}
								goto case 7;
							}
							case 7:
								if (!flag6)
								{
									num = 529031991;
									continue;
								}
								goto IL_023e;
							case 8:
								return false;
							case 17:
								if (flag4)
								{
									num = 529031999;
									continue;
								}
								goto IL_01f3;
							case 9:
								return false;
							case 3:
								if (!flag3)
								{
									return false;
								}
								goto IL_01a1;
							case 14:
							{
								int num7;
								if (num6 < num4)
								{
									num = 529031973;
									num7 = num;
								}
								else
								{
									num = 529031986;
									num7 = num;
								}
								continue;
							}
							case 13:
								return false;
							case 15:
							{
								bool flag = !string.IsNullOrEmpty(versionMin);
								flag2 = !string.IsNullOrEmpty(versionMax);
								if (flag || flag2)
								{
									if (currentVersion == null)
									{
										goto case 8;
									}
									if (currentVersion.Length == 0)
									{
										num = 529031997;
										continue;
									}
									if (flag)
									{
										num = 529031987;
										continue;
									}
									goto IL_01a1;
								}
								num = 529031984;
								continue;
							}
							default:
								{
									return false;
								}
								IL_01a1:
								if (flag2)
								{
									array2 = versionMax.Split('.');
									num4 = MathTools.Min(array2.Length, currentVersion.Length);
									num = 529031988;
									continue;
								}
								goto IL_023e;
								IL_023e:
								return true;
								IL_01f3:
								if (flag4)
								{
									if (result2 < result)
									{
										return false;
									}
									flag3 = true;
									num3++;
									num = 529031998;
									continue;
								}
								goto case 3;
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
						int num = -586424821;
						while (true)
						{
							switch (num ^ -586424823)
							{
							case 0:
								break;
							case 2:
								matchingCriteria = destination as MatchingCriteria;
								if (matchingCriteria == null)
								{
									return;
								}
								goto case 1;
							case 1:
								matchingCriteria.productName_useRegex = productName_useRegex;
								matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
								num = -586424822;
								continue;
							case 3:
								matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
								matchingCriteria.mapping = ArrayTools.ShallowCopy(mapping);
								num = -586424819;
								continue;
							default:
								matchingCriteria.elementCount = ArrayTools.DeepClone(elementCount);
								matchingCriteria.clientInfo = ArrayTools.DeepClone(clientInfo);
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
						IL_0092:
						int num3;
						if (num >= axisCount)
						{
							num2 = 0;
							num3 = 1628998042;
							goto IL_000c;
						}
						goto IL_0031;
						IL_000c:
						while (true)
						{
							switch (num3 ^ 0x61188998)
							{
							case 4:
								num3 = 1628998043;
								continue;
							case 3:
								break;
							case 1:
								goto IL_0053;
							case 2:
								goto IL_0075;
							case 0:
								goto IL_0092;
							default:
								return elementIdentifier.elementType;
							}
							break;
							IL_0075:
							int num4;
							if (num2 >= buttonCount)
							{
								num3 = 1628998045;
								num4 = num3;
							}
							else
							{
								num3 = 1628998041;
								num4 = num3;
							}
							continue;
							IL_0053:
							if (buttons[num2].elementIdentifier == elementIdentifier.id)
							{
								return ControllerElementType.Button;
							}
							num2++;
							num3 = 1628998042;
						}
						goto IL_0031;
						IL_0031:
						if (axes[num].elementIdentifier == elementIdentifier.id)
						{
							break;
						}
						num++;
						num3 = 1628998040;
						goto IL_000c;
					}
					return ControllerElementType.Axis;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					int num = 0;
					int sourceType = default(int);
					while (true)
					{
						int num2 = 1025086647;
						while (true)
						{
							switch (num2 ^ 0x3D1994B5)
							{
							case 0:
								break;
							case 9:
								return true;
							case 7:
								if (num >= axisCount)
								{
									axisRange = AxisRange.Full;
									num2 = 1025086654;
									continue;
								}
								goto case 10;
							case 6:
								switch (sourceType)
								{
								case 0:
									axisRange = AxisRange.Positive;
									num2 = 1025086653;
									continue;
								case 100:
									num2 = 1025086641;
									continue;
								default:
									throw new NotImplementedException();
								case 1:
									break;
								}
								goto case 4;
							case 3:
							{
								int num3;
								if (!axes[num].invert)
								{
									num2 = 1025086652;
									num3 = num2;
								}
								else
								{
									num2 = 1025086640;
									num3 = num2;
								}
								continue;
							}
							case 5:
								axisRange = InputTools.InvertAxisRange(axisRange);
								num2 = 1025086652;
								continue;
							case 8:
								return true;
							case 2:
								num2 = 1025086642;
								continue;
							case 4:
								axisRange = axes[num].sourceAxisRange;
								num2 = 1025086646;
								continue;
							case 10:
								if (axes[num].elementIdentifier == elementIdentifier.id)
								{
									sourceType = axes[num].sourceType;
									num2 = 1025086643;
									continue;
								}
								goto case 1;
							case 1:
								num++;
								num2 = 1025086642;
								continue;
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
					if (!(destination is Elements elements))
					{
						return;
					}
					while (true)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						int num = -981321093;
						while (true)
						{
							switch (num ^ -981321095)
							{
							case 3:
								num = -981321096;
								continue;
							default:
								return;
							case 1:
								break;
							case 2:
								elements.buttons = ArrayTools.DeepClone(buttons);
								num = -981321095;
								continue;
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

			private sealed class EeXtXFbZLcikuDzKyDxJyAUAbgE : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_WebGL_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int QlrdOPHCJQaWSRjZyqBhTZcWAV;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
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
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
					{
						goto IL_0012;
					}
					goto IL_0065;
					IL_0012:
					int num = 208299899;
					goto IL_0017;
					IL_0017:
					EeXtXFbZLcikuDzKyDxJyAUAbgE eeXtXFbZLcikuDzKyDxJyAUAbgE = default(EeXtXFbZLcikuDzKyDxJyAUAbgE);
					while (true)
					{
						switch (num ^ 0xC6A677A)
						{
						case 3:
							break;
						case 1:
							if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
							{
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								eeXtXFbZLcikuDzKyDxJyAUAbgE = this;
								num = 208299896;
								continue;
							}
							goto IL_0065;
						case 0:
							eeXtXFbZLcikuDzKyDxJyAUAbgE.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
							num = 208299896;
							continue;
						case 4:
							goto IL_0065;
						default:
							return eeXtXFbZLcikuDzKyDxJyAUAbgE;
						}
						break;
					}
					goto IL_0012;
					IL_0065:
					eeXtXFbZLcikuDzKyDxJyAUAbgE = new EeXtXFbZLcikuDzKyDxJyAUAbgE(0);
					num = 208299898;
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
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					case 1:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = -1299310022;
						goto IL_001f;
					case 0:
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							int num3;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements != null)
							{
								num = -1299310024;
								num3 = num;
							}
							else
							{
								num = -1299310020;
								num3 = num;
							}
							goto IL_001f;
						}
						IL_001f:
						while (true)
						{
							switch (num ^ -1299310020)
							{
							case 2:
								num = -1299310019;
								continue;
							case 6:
								QlrdOPHCJQaWSRjZyqBhTZcWAV++;
								num = -1299310023;
								continue;
							case 4:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes != null)
								{
									QlrdOPHCJQaWSRjZyqBhTZcWAV = 0;
									num = -1299310023;
									continue;
								}
								goto end_IL_0008;
							case 5:
								break;
							case 3:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes[QlrdOPHCJQaWSRjZyqBhTZcWAV];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							case 1:
								goto end_IL_001f;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (QlrdOPHCJQaWSRjZyqBhTZcWAV < syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.axes.Length)
							{
								num = -1299310017;
								num2 = num;
							}
							else
							{
								num = -1299310020;
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
				public EeXtXFbZLcikuDzKyDxJyAUAbgE(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class hkxltixJJfBDYEcBAJHXrdJZrJT : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Platform_WebGL_Base syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int euuPoDPobvfGQnnNVUOekgjYQcd;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
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
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						goto IL_0023;
					}
					goto IL_004e;
					IL_0028:
					int num;
					hkxltixJJfBDYEcBAJHXrdJZrJT hkxltixJJfBDYEcBAJHXrdJZrJT2 = default(hkxltixJJfBDYEcBAJHXrdJZrJT);
					while (true)
					{
						switch (num ^ 0x7FB2A14D)
						{
						case 0:
							break;
						case 3:
							hkxltixJJfBDYEcBAJHXrdJZrJT2 = this;
							num = 2142413135;
							continue;
						case 1:
							goto IL_004e;
						default:
							return hkxltixJJfBDYEcBAJHXrdJZrJT2;
						}
						break;
					}
					goto IL_0023;
					IL_004e:
					hkxltixJJfBDYEcBAJHXrdJZrJT2 = new hkxltixJJfBDYEcBAJHXrdJZrJT(0);
					hkxltixJJfBDYEcBAJHXrdJZrJT2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					num = 2142413135;
					goto IL_0028;
					IL_0023:
					num = 2142413134;
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
					int num4;
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					default:
						num = -1103394288;
						goto IL_001a;
					case 1:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						euuPoDPobvfGQnnNVUOekgjYQcd++;
						num = -1103394286;
						goto IL_001a;
					case 0:
						goto IL_0114;
						IL_001a:
						while (true)
						{
							switch (num ^ -1103394285)
							{
							case 5:
								break;
							case 6:
								euuPoDPobvfGQnnNVUOekgjYQcd = 0;
								num = -1103394286;
								continue;
							case 7:
								return true;
							case 9:
								goto IL_007e;
							case 3:
								num = -1103394287;
								continue;
							case 4:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons[euuPoDPobvfGQnnNVUOekgjYQcd];
								num = -1103394285;
								continue;
							case 0:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = -1103394284;
								continue;
							case 1:
								goto IL_00e6;
							case 8:
								goto IL_0114;
							default:
								return false;
							}
							break;
							IL_00e6:
							int num2;
							if (euuPoDPobvfGQnnNVUOekgjYQcd < syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons.Length)
							{
								num = -1103394281;
								num2 = num;
							}
							else
							{
								num = -1103394287;
								num2 = num;
							}
							continue;
							IL_007e:
							int num3;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements.buttons != null)
							{
								num = -1103394283;
								num3 = num;
							}
							else
							{
								num = -1103394287;
								num3 = num;
							}
						}
						goto default;
						IL_0114:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elements == null)
						{
							num = -1103394287;
							num4 = num;
						}
						else
						{
							num = -1103394278;
							num4 = num;
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
				public hkxltixJJfBDYEcBAJHXrdJZrJT(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.mvnXduzIcJqcHpJHCcDjxXAwuzv;

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
							int num = -346875979;
							while (true)
							{
								switch (num ^ -346875977)
								{
								case 0:
									break;
								case 1:
									_axesOrigGame[num2] = axes_orig[num2];
									num2++;
									num = -346875981;
									continue;
								case 6:
									num2 = 0;
									num = -346875981;
									continue;
								case 3:
									_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
									num = -346875983;
									continue;
								case 2:
									goto IL_006d;
								case 4:
									goto IL_0088;
								default:
									goto end_IL_000b;
								}
								break;
								IL_0088:
								int num3;
								if (num2 >= axes_orig.Length)
								{
									num = -346875982;
									num3 = num;
								}
								else
								{
									num = -346875978;
									num3 = num;
								}
								continue;
								IL_006d:
								axes_orig = Axes_orig;
								int num4;
								if (axes_orig != null)
								{
									num = -346875980;
									num4 = num;
								}
								else
								{
									num = -346875982;
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
								int num = -1082202216;
								while (true)
								{
									switch (num ^ -1082202212)
									{
									case 5:
										break;
									case 3:
										_buttonsOrigGame[num2] = buttons_orig[num2];
										num2++;
										num = -1082202211;
										continue;
									case 0:
										num = -1082202211;
										continue;
									case 1:
										goto IL_0059;
									case 4:
										_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
										num2 = 0;
										num = -1082202212;
										continue;
									default:
										goto end_IL_0012;
									}
									break;
									IL_0059:
									int num3;
									if (num2 < buttons_orig.Length)
									{
										num = -1082202209;
										num3 = num;
									}
									else
									{
										num = -1082202210;
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
						goto IL_0017;
					}
					int num;
					if (assignedButtonCount == 0 && assignedAxisCount == 0)
					{
						num = -72658443;
						goto IL_001c;
					}
					return true;
					IL_0017:
					num = -72658444;
					goto IL_001c;
					IL_001c:
					switch (num ^ -72658443)
					{
					case 2:
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

			internal override Elements_Base elements_base => elements;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = -1;
				while (true)
				{
					int num = -1161592348;
					while (true)
					{
						switch (num ^ -1161592347)
						{
						case 0:
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
						num = -1161592345;
					}
				}
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				EeXtXFbZLcikuDzKyDxJyAUAbgE eeXtXFbZLcikuDzKyDxJyAUAbgE = new EeXtXFbZLcikuDzKyDxJyAUAbgE(-2);
				eeXtXFbZLcikuDzKyDxJyAUAbgE.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return eeXtXFbZLcikuDzKyDxJyAUAbgE;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				hkxltixJJfBDYEcBAJHXrdJZrJT hkxltixJJfBDYEcBAJHXrdJZrJT2 = new hkxltixJJfBDYEcBAJHXrdJZrJT(-2);
				hkxltixJJfBDYEcBAJHXrdJZrJT2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return hkxltixJJfBDYEcBAJHXrdJZrJT2;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					goto IL_0013;
				}
				string[] array = new string[elements.axisCount];
				int num = 0;
				int num2 = 2144068031;
				goto IL_0018;
				IL_0018:
				int num3 = default(int);
				while (true)
				{
					switch (num2 ^ 0x7FCBE1B9)
					{
					case 7:
						break;
					case 4:
						if (num3 >= 0)
						{
							int num4;
							if (num3 < identifiers.Length)
							{
								num2 = 2144068028;
								num4 = num2;
							}
							else
							{
								num2 = 2144068027;
								num4 = num2;
							}
							continue;
						}
						goto case 2;
					case 0:
						num++;
						num2 = 2144068031;
						continue;
					case 2:
						Logger.LogError("Element identifier index is out of bounds!");
						num2 = 2144068025;
						continue;
					case 1:
						Logger.LogError("You have too few element identifiers!");
						num2 = 2144068017;
						continue;
					case 3:
					{
						int elementIdentifier = elements.axes[num].elementIdentifier;
						num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
						num2 = 2144068029;
						continue;
					}
					case 8:
						return new string[0];
					case 5:
						array[num] = identifiers[num3].name;
						num2 = 2144068025;
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
				goto IL_0013;
				IL_0013:
				num2 = 2144068024;
				goto IL_0018;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				int buttonCount = elements.buttonCount;
				string[] array = default(string[]);
				int num2 = default(int);
				int num4 = default(int);
				while (true)
				{
					int num = -1976290506;
					while (true)
					{
						switch (num ^ -1976290512)
						{
						case 7:
							break;
						case 5:
							array[num2] = identifiers[num4].name;
							num = -1976290509;
							continue;
						case 3:
							num2++;
							num = -1976290504;
							continue;
						case 6:
							if (identifiers.Length < buttonCount)
							{
								Logger.LogError("You have too few element identifiers!");
								num = -1976290510;
							}
							else
							{
								array = new string[buttonCount];
								num2 = 0;
								num = -1976290504;
							}
							continue;
						case 1:
							Logger.LogError("Element identifier index is out of bounds!");
							num = -1976290509;
							continue;
						case 0:
							if (num4 >= 0)
							{
								int num5;
								if (num4 >= identifiers.Length)
								{
									num = -1976290511;
									num5 = num;
								}
								else
								{
									num = -1976290507;
									num5 = num;
								}
								continue;
							}
							goto case 1;
						case 9:
						{
							int elementIdentifier = elements.buttons[num2].elementIdentifier;
							num4 = IndexOfElementIdentifier(identifiers, elementIdentifier);
							num = -1976290512;
							continue;
						}
						case 8:
						{
							int num3;
							if (num2 < array.Length)
							{
								num = -1976290503;
								num3 = num;
							}
							else
							{
								num = -1976290508;
								num3 = num;
							}
							continue;
						}
						case 2:
							return new string[0];
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
					while (enumerator.MoveNext())
					{
						while (true)
						{
							Axis axis = (Axis)enumerator.Current;
							int num;
							int num2;
							if (axis.elementIdentifier != elementIdentifierId)
							{
								num = 687321548;
								num2 = num;
							}
							else
							{
								num = 687321544;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ 0x28F7B1C8)
								{
								case 2:
									num = 687321547;
									continue;
								case 3:
									break;
								case 0:
									result = true;
									num = 687321545;
									continue;
								default:
									goto end_IL_0034;
								case 1:
									goto IL_00ea;
								}
								break;
							}
							continue;
							end_IL_0034:
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
					goto IL_00ea;
				}
				return false;
				IL_00ea:
				return result;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = new int[assignedButtonCount];
				while (true)
				{
					int num = 738204880;
					while (true)
					{
						switch (num ^ 0x2C001CD1)
						{
						case 2:
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
										buttons[num2] = button.elementIdentifier;
										num2++;
										int num3 = 738204880;
										while (true)
										{
											switch (num3 ^ 0x2C001CD1)
											{
											case 0:
												num3 = 738204883;
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
							num2 = 0;
							using (IEnumerator<Platform_Custom.Axis> enumerator2 = IterateAxes().GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									while (true)
									{
										Axis axis = (Axis)enumerator2.Current;
										int num4 = 738204880;
										while (true)
										{
											switch (num4 ^ 0x2C001CD1)
											{
											case 0:
												num4 = 738204883;
												continue;
											case 2:
												break;
											case 4:
												num2++;
												num4 = 738204882;
												continue;
											case 1:
												axes[num2] = axis.elementIdentifier;
												num4 = 738204885;
												continue;
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
								return;
							}
						}
						}
						break;
						IL_002b:
						axes = new int[assignedAxisCount];
						num = 738204881;
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
				int num2 = -2116426346;
				goto IL_0012;
				IL_0012:
				while (true)
				{
					switch (num2 ^ -2116426346)
					{
					case 8:
						break;
					case 6:
						array[num].zero = axes_orig[num].axisZero;
						array[num].min = axes_orig[num].axisMin;
						array[num].max = axes_orig[num].axisMax;
						num2 = -2116426349;
						continue;
					case 7:
						if (axes_orig[num].sourceType != 1)
						{
							int num4;
							if (axes_orig[num].sourceType != 100)
							{
								num2 = -2116426348;
								num4 = num2;
							}
							else
							{
								num2 = -2116426347;
								num4 = num2;
							}
							continue;
						}
						goto case 3;
					case 5:
						array[num].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[num].alternateCalibrations, deepClone: true);
						num++;
						num2 = -2116426346;
						continue;
					case 2:
						if (axes_orig[num].sourceType == 0)
						{
							ref AxisCalibrationData reference = ref array[num];
							reference = AxisCalibrationData.Default;
							num2 = -2116426349;
							continue;
						}
						goto case 1;
					case 1:
						throw new NotImplementedException();
					case 3:
					{
						ref AxisCalibrationData reference2 = ref array[num];
						reference2 = AxisCalibrationData.Default;
						array[num].invert = axes_orig[num].invert;
						array[num].deadZone = axes_orig[num].axisDeadZone;
						int num3;
						if (Axes_orig[num].calibrateAxis)
						{
							num2 = -2116426352;
							num3 = num2;
						}
						else
						{
							num2 = -2116426349;
							num3 = num2;
						}
						continue;
					}
					case 4:
						return null;
					default:
						if (num >= axes_orig.Length)
						{
							return array;
						}
						goto case 7;
					}
					break;
				}
				goto IL_000d;
				IL_000d:
				num2 = -2116426350;
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
					int num = -464557907;
					while (true)
					{
						switch (num ^ -464557906)
						{
						case 6:
							num = -464557914;
							continue;
						case 8:
							break;
						case 7:
							throw new Exception();
						case 0:
							axisInfos[num2] = MiscTools.DeepClone(Axes_orig[num2].axisInfo, createIfNull: true);
							if (Axes_orig[num2].sourceType != 1)
							{
								int num3;
								if (Axes_orig[num2].sourceType == 100)
								{
									num = -464557909;
									num3 = num;
								}
								else
								{
									num = -464557908;
									num3 = num;
								}
								continue;
							}
							goto case 5;
						case 2:
							if (Axes_orig[num2].sourceType == 0)
							{
								axisRanges[num2] = AxisRange.Full;
								num = -464557910;
								continue;
							}
							goto case 7;
						case 3:
							axisInfos = new HardwareAxisInfo[Axes_orig.Length];
							num2 = 0;
							num = -464557905;
							continue;
						case 5:
							axisRanges[num2] = Axes_orig[num2].sourceAxisRange;
							num = -464557910;
							continue;
						case 4:
							num2++;
							num = -464557905;
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
				int num2 = default(int);
				while (true)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					int num = 1839632308;
					while (true)
					{
						switch (num ^ 0x6DA68FB5)
						{
						case 5:
							num = 1839632310;
							continue;
						default:
							return;
						case 3:
							break;
						case 1:
							num2 = 0;
							num = 1839632309;
							continue;
						case 0:
						{
							int num3;
							if (num2 < Buttons_orig.Length)
							{
								num = 1839632311;
								num3 = num;
							}
							else
							{
								num = 1839632305;
								num3 = num;
							}
							continue;
						}
						case 2:
							buttonInfos[num2] = MiscTools.DeepClone(Buttons_orig[num2].buttonInfo, createIfNull: true);
							num2++;
							num = 1839632309;
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
				Platform_WebGL_Base platform_WebGL_Base = new Platform_WebGL_Base();
				while (true)
				{
					int num = -1963737390;
					while (true)
					{
						switch (num ^ -1963737389)
						{
						case 0:
							break;
						case 1:
							goto IL_0024;
						default:
							return platform_WebGL_Base;
						}
						break;
						IL_0024:
						CopyVars(platform_WebGL_Base);
						num = -1963737391;
					}
				}
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_WebGL_Base platform_WebGL_Base = default(Platform_WebGL_Base);
				while (true)
				{
					int num = -734126495;
					while (true)
					{
						switch (num ^ -734126491)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							platform_WebGL_Base.elements = MiscTools.DeepClone(elements);
							num = -734126492;
							continue;
						case 3:
							platform_WebGL_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
							num = -734126489;
							continue;
						case 4:
							platform_WebGL_Base = destination as Platform_WebGL_Base;
							if (platform_WebGL_Base == null)
							{
								return;
							}
							goto case 3;
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
		public sealed class Platform_WebGL : Platform_WebGL_Base
		{
			public Platform_WebGL_Base[] variants;

			internal override IList<Platform> variants_base => variants;

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
							num2 = -1546442093;
							num3 = num2;
						}
						else
						{
							num2 = -1546442096;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -1546442094)
							{
							case 3:
								num2 = -1546442093;
								continue;
							case 1:
								break;
							case 0:
								goto end_IL_0020;
							default:
								goto end_IL_006c;
							}
							if (variants[num] != null && variants[num].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
							{
								variantIndex = num;
								return true;
							}
							num++;
							num2 = -1546442094;
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
				Platform_WebGL platform_WebGL = new Platform_WebGL();
				CopyVars(platform_WebGL);
				return platform_WebGL;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				Platform_WebGL platform_WebGL = default(Platform_WebGL);
				while (true)
				{
					int num = -755732958;
					while (true)
					{
						switch (num ^ -755732960)
						{
						case 0:
							break;
						case 2:
						{
							platform_WebGL = destination as Platform_WebGL;
							int num2;
							if (platform_WebGL != null)
							{
								num = -755732957;
								num2 = num;
							}
							else
							{
								num = -755732959;
								num2 = num;
							}
							continue;
						}
						case 1:
							return;
						default:
							platform_WebGL.variants = MiscTools.DeepClone(variants);
							return;
						}
						break;
					}
				}
			}
		}

		private sealed class rTSmNsPfJIGOXHtKmiYiKPOcLpSh : IDisposable, IEnumerator, IEnumerable, IEnumerable<Guid>, IEnumerator<Guid>
		{
			private Guid ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public HardwareJoystickMap syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int PSmjXiTtTWKPkmLbUbHkvOzjvZk;

			Guid IEnumerator<Guid>.Current
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
			IEnumerator<Guid> IEnumerable<Guid>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
				{
					goto IL_0012;
				}
				goto IL_0054;
				IL_0012:
				int num = 444018835;
				goto IL_0017;
				IL_0017:
				rTSmNsPfJIGOXHtKmiYiKPOcLpSh rTSmNsPfJIGOXHtKmiYiKPOcLpSh2 = default(rTSmNsPfJIGOXHtKmiYiKPOcLpSh);
				while (true)
				{
					switch (num ^ 0x1A773091)
					{
					case 0:
						break;
					case 2:
						if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							num = 444018834;
							continue;
						}
						goto IL_0054;
					case 5:
						goto IL_0054;
					case 3:
						rTSmNsPfJIGOXHtKmiYiKPOcLpSh2 = this;
						num = 444018837;
						continue;
					case 1:
						rTSmNsPfJIGOXHtKmiYiKPOcLpSh2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = 444018837;
						continue;
					default:
						return rTSmNsPfJIGOXHtKmiYiKPOcLpSh2;
					}
					break;
				}
				goto IL_0012;
				IL_0054:
				rTSmNsPfJIGOXHtKmiYiKPOcLpSh2 = new rTSmNsPfJIGOXHtKmiYiKPOcLpSh(0);
				num = 444018832;
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
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 1:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					PSmjXiTtTWKPkmLbUbHkvOzjvZk++;
					num = 2147022530;
					goto IL_001f;
				case 0:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						int num3;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.templateGuids == null)
						{
							num = 2147022535;
							num3 = num;
						}
						else
						{
							num = 2147022529;
							num3 = num;
						}
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ 0x7FF8F6C2)
						{
						case 6:
							num = 2147022533;
							continue;
						case 0:
							break;
						case 3:
							PSmjXiTtTWKPkmLbUbHkvOzjvZk = 0;
							num = 2147022528;
							continue;
						case 1:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							return true;
						case 4:
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = StringTools.ToGuid(syCPfFbHYMDOvEPjTnPLBqiOhsPv.templateGuids[PSmjXiTtTWKPkmLbUbHkvOzjvZk]);
							num = 2147022531;
							continue;
						case 7:
							goto end_IL_001f;
						case 2:
							num = 2147022530;
							continue;
						default:
							goto end_IL_0008;
						}
						int num2;
						if (PSmjXiTtTWKPkmLbUbHkvOzjvZk >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.templateGuids.Length)
						{
							num = 2147022535;
							num2 = num;
						}
						else
						{
							num = 2147022534;
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
			public rTSmNsPfJIGOXHtKmiYiKPOcLpSh(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class gMqUcktuYWrNlHoVqeBeycvYVZr : IDisposable, IEnumerable<ControllerElementIdentifier>, IEnumerator<ControllerElementIdentifier>, IEnumerator, IEnumerable
		{
			private ControllerElementIdentifier ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public HardwareJoystickMap syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int ZuNkwfSRMbmzFVdbHjzFDuIxWOr;

			ControllerElementIdentifier IEnumerator<ControllerElementIdentifier>.Current
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
			IEnumerator<ControllerElementIdentifier> IEnumerable<ControllerElementIdentifier>.GetEnumerator()
			{
				gMqUcktuYWrNlHoVqeBeycvYVZr gMqUcktuYWrNlHoVqeBeycvYVZr2;
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					gMqUcktuYWrNlHoVqeBeycvYVZr2 = this;
					goto IL_0025;
				}
				goto IL_004e;
				IL_002a:
				int num;
				while (true)
				{
					switch (num ^ -792483374)
					{
					case 3:
						break;
					case 1:
						num = -792483376;
						continue;
					case 0:
						goto IL_004e;
					default:
						return gMqUcktuYWrNlHoVqeBeycvYVZr2;
					}
					break;
				}
				goto IL_0025;
				IL_004e:
				gMqUcktuYWrNlHoVqeBeycvYVZr2 = new gMqUcktuYWrNlHoVqeBeycvYVZr(0);
				gMqUcktuYWrNlHoVqeBeycvYVZr2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				num = -792483376;
				goto IL_002a;
				IL_0025:
				num = -792483373;
				goto IL_002a;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerElementIdentifier>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				default:
					num = 964130623;
					goto IL_001a;
				case 1:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					ZuNkwfSRMbmzFVdbHjzFDuIxWOr++;
					num = 964130618;
					goto IL_001a;
				case 0:
					goto IL_006b;
					IL_001a:
					while (true)
					{
						switch (num ^ 0x3977773B)
						{
						case 0:
							break;
						case 2:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							return true;
						case 6:
							goto IL_006b;
						case 1:
							goto IL_008d;
						case 5:
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elementIdentifiers[ZuNkwfSRMbmzFVdbHjzFDuIxWOr];
							num = 964130617;
							continue;
						case 4:
							num = 964130616;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
						IL_008d:
						int num2;
						if (ZuNkwfSRMbmzFVdbHjzFDuIxWOr >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.elementIdentifiers.Length)
						{
							num = 964130616;
							num2 = num;
						}
						else
						{
							num = 964130622;
							num2 = num;
						}
					}
					goto default;
					IL_006b:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elementIdentifiers == null)
					{
						break;
					}
					ZuNkwfSRMbmzFVdbHjzFDuIxWOr = 0;
					num = 964130618;
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
			public gMqUcktuYWrNlHoVqeBeycvYVZr(int _003C_003E1__state)
			{
				while (true)
				{
					int num = -883785606;
					while (true)
					{
						switch (num ^ -883785605)
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
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
						num = -883785605;
					}
				}
			}
		}

		private sealed class oQTWlZSEQaLocNLyuyeMuNkpCNo : IDisposable, IEnumerator, IEnumerable, IEnumerable<JoystickType>, IEnumerator<JoystickType>
		{
			private JoystickType ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public HardwareJoystickMap syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int AOvPuJJImAsLKkhEzRBiwNLxqce;

			JoystickType IEnumerator<JoystickType>.Current
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
			IEnumerator<JoystickType> IEnumerable<JoystickType>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					goto IL_001c;
				}
				goto IL_004e;
				IL_004e:
				oQTWlZSEQaLocNLyuyeMuNkpCNo oQTWlZSEQaLocNLyuyeMuNkpCNo2 = new oQTWlZSEQaLocNLyuyeMuNkpCNo(0);
				oQTWlZSEQaLocNLyuyeMuNkpCNo2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				int num = -1520079241;
				goto IL_0021;
				IL_001c:
				num = -1520079243;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ -1520079242)
					{
					case 2:
						break;
					case 3:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						oQTWlZSEQaLocNLyuyeMuNkpCNo2 = this;
						num = -1520079241;
						continue;
					case 0:
						goto IL_004e;
					default:
						return oQTWlZSEQaLocNLyuyeMuNkpCNo2;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JoystickType>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 1:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					AOvPuJJImAsLKkhEzRBiwNLxqce++;
					num = -938830332;
					goto IL_001f;
				case 0:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						int num3;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.joystickTypes != null)
						{
							num = -938830334;
							num3 = num;
						}
						else
						{
							num = -938830330;
							num3 = num;
						}
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -938830334)
						{
						case 3:
							num = -938830333;
							continue;
						case 2:
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.joystickTypes[AOvPuJJImAsLKkhEzRBiwNLxqce];
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							return true;
						case 5:
							num = -938830332;
							continue;
						case 6:
							break;
						case 1:
							goto end_IL_001f;
						case 0:
							AOvPuJJImAsLKkhEzRBiwNLxqce = 0;
							num = -938830329;
							continue;
						default:
							goto end_IL_0008;
						}
						int num2;
						if (AOvPuJJImAsLKkhEzRBiwNLxqce < syCPfFbHYMDOvEPjTnPLBqiOhsPv.joystickTypes.Length)
						{
							num = -938830336;
							num2 = num;
						}
						else
						{
							num = -938830330;
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
			public oQTWlZSEQaLocNLyuyeMuNkpCNo(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class ehkgBRUYOMhkgFrEyAisnLgSaZfB : IDisposable, IEnumerator, IEnumerable, IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerator<IControllerElementIdentifierCommon_Internal>
		{
			private IControllerElementIdentifierCommon_Internal ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public HardwareJoystickMap syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int GbrRRGsNcyFRLJzpJvBrBHZZvbz;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
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
			IEnumerator<IControllerElementIdentifierCommon_Internal> IEnumerable<IControllerElementIdentifierCommon_Internal>.GetEnumerator()
			{
				ehkgBRUYOMhkgFrEyAisnLgSaZfB ehkgBRUYOMhkgFrEyAisnLgSaZfB2;
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					ehkgBRUYOMhkgFrEyAisnLgSaZfB2 = this;
				}
				else
				{
					while (true)
					{
						ehkgBRUYOMhkgFrEyAisnLgSaZfB2 = new ehkgBRUYOMhkgFrEyAisnLgSaZfB(0);
						ehkgBRUYOMhkgFrEyAisnLgSaZfB2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						int num = -324399947;
						while (true)
						{
							switch (num ^ -324399947)
							{
							case 2:
								num = -324399948;
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
				return ehkgBRUYOMhkgFrEyAisnLgSaZfB2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<IControllerElementIdentifierCommon_Internal>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 0:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elementIdentifiers == null)
					{
						break;
					}
					GbrRRGsNcyFRLJzpJvBrBHZZvbz = 0;
					num = -380253136;
					goto IL_001f;
				case 1:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = -380253135;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -380253136)
						{
						case 2:
							num = -380253132;
							continue;
						case 4:
							break;
						case 6:
							goto IL_0074;
						case 0:
							num = -380253130;
							continue;
						case 1:
							GbrRRGsNcyFRLJzpJvBrBHZZvbz++;
							num = -380253130;
							continue;
						case 3:
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elementIdentifiers[GbrRRGsNcyFRLJzpJvBrBHZZvbz];
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							num = -380253129;
							continue;
						case 7:
							return true;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0074:
						int num2;
						if (GbrRRGsNcyFRLJzpJvBrBHZZvbz >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.elementIdentifiers.Length)
						{
							num = -380253131;
							num2 = num;
						}
						else
						{
							num = -380253133;
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
			public ehkgBRUYOMhkgFrEyAisnLgSaZfB(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string controllerName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string editorControllerName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string description;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string controllerGuid;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private CompoundElement[] compoundElements;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_DirectInput directInput;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_RawInput rawInput;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_Windows;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_WindowsUWP;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_OSX;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_Linux;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_Linux_PreConfigured;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_Android;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_iOS;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_Blackberry;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_PS5 ps5;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_PSM;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_PSVita;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_Wii;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_WiiU;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_AmazonFireTV;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_RazerForgeTV;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_WebGL webGL;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Ouya ouya;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_XboxOne xboxOne;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_GameCore gameCore;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_PS4 ps4;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_NintendoSwitch nintendoSwitch;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Stadia stadia;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_InternalDriver internalDriver;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_SDL2 sdl2_Linux;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_SDL2 sdl2_Windows;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_SDL2 sdl2_OSX;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int elementIdentifierIdCounter;

		public string ControllerName => controllerName;

		public string EditorControllerName => editorControllerName;

		public Guid Guid => StringTools.ToGuid(controllerGuid);

		public IEnumerable<Guid> TemplateGuids
		{
			get
			{
				rTSmNsPfJIGOXHtKmiYiKPOcLpSh rTSmNsPfJIGOXHtKmiYiKPOcLpSh2 = new rTSmNsPfJIGOXHtKmiYiKPOcLpSh(-2);
				rTSmNsPfJIGOXHtKmiYiKPOcLpSh2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return rTSmNsPfJIGOXHtKmiYiKPOcLpSh2;
			}
		}

		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				gMqUcktuYWrNlHoVqeBeycvYVZr gMqUcktuYWrNlHoVqeBeycvYVZr2 = new gMqUcktuYWrNlHoVqeBeycvYVZr(-2);
				gMqUcktuYWrNlHoVqeBeycvYVZr2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return gMqUcktuYWrNlHoVqeBeycvYVZr2;
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

		public bool HideInLists => hideInLists;

		internal IEnumerable<JoystickType> JoystickTypes
		{
			get
			{
				oQTWlZSEQaLocNLyuyeMuNkpCNo oQTWlZSEQaLocNLyuyeMuNkpCNo2 = new oQTWlZSEQaLocNLyuyeMuNkpCNo(-2);
				oQTWlZSEQaLocNLyuyeMuNkpCNo2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return oQTWlZSEQaLocNLyuyeMuNkpCNo2;
			}
		}

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			get
			{
				ehkgBRUYOMhkgFrEyAisnLgSaZfB ehkgBRUYOMhkgFrEyAisnLgSaZfB2 = new ehkgBRUYOMhkgFrEyAisnLgSaZfB(-2);
				ehkgBRUYOMhkgFrEyAisnLgSaZfB2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return ehkgBRUYOMhkgFrEyAisnLgSaZfB2;
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
			if (gameCore == null)
			{
				gameCore = new Platform_GameCore();
			}
			if (ps4 == null)
			{
				ps4 = new Platform_PS4();
			}
			if (ps5 == null)
			{
				ps5 = new Platform_PS5();
			}
			if (nintendoSwitch == null)
			{
				nintendoSwitch = new Platform_NintendoSwitch();
			}
			if (stadia == null)
			{
				stadia = new Platform_Stadia();
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
			if (source.stadia != null)
			{
				stadia = MiscTools.DeepClone(source.stadia);
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
			if (source.gameCore != null)
			{
				gameCore = MiscTools.DeepClone(source.gameCore);
			}
			if (source.ps4 != null)
			{
				ps4 = MiscTools.DeepClone(source.ps4);
			}
			if (source.ps5 != null)
			{
				ps5 = MiscTools.DeepClone(source.ps5);
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
			if (elementIdentifiers == null)
			{
				goto IL_0008;
			}
			int num = elementIdentifiers.Length;
			goto IL_0035;
			IL_0035:
			int num2 = num;
			if (num2 == 0)
			{
				return null;
			}
			string[] array = new string[num2];
			int num3 = 0;
			int num4 = -176237497;
			goto IL_000d;
			IL_0008:
			num4 = -176237500;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num4 ^ -176237499)
				{
				case 0:
					break;
				case 1:
					goto IL_002a;
				case 3:
					array[num3] = elementIdentifiers[num3].name;
					num3++;
					num4 = -176237497;
					continue;
				default:
					if (num3 >= num2)
					{
						return array;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0008;
			IL_002a:
			num = 0;
			goto IL_0035;
		}

		[CustomObfuscation(rename = false)]
		public int[] GetElementIdentifierIds()
		{
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			if (num == 0)
			{
				return null;
			}
			int[] array = new int[num];
			int num2 = 0;
			while (true)
			{
				int num3 = -308312612;
				while (true)
				{
					switch (num3 ^ -308312611)
					{
					case 4:
						break;
					case 2:
						num2++;
						num3 = -308312610;
						continue;
					case 0:
						array[num2] = elementIdentifiers[num2].id;
						num3 = -308312609;
						continue;
					case 1:
						num3 = -308312610;
						continue;
					default:
						if (num2 >= num)
						{
							return array;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public ControllerElementIdentifier GetElementIdentifier(int id)
		{
			int num = IndexOfElementIdentifier(id);
			if (num < 0 || num >= elementIdentifiers.Length)
			{
				return null;
			}
			return elementIdentifiers[num];
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
			int num2 = default(int);
			List<ControllerElementIdentifier> list = default(List<ControllerElementIdentifier>);
			int num4 = default(int);
			int num3 = default(int);
			int count = default(int);
			while (true)
			{
				int num = -627561825;
				while (true)
				{
					switch (num ^ -627561831)
					{
					case 9:
						break;
					case 0:
						ids[num2] = list[num2].id;
						num2++;
						num = -627561839;
						continue;
					case 2:
						num = -627561830;
						continue;
					case 5:
						if (elementIdentifiers[num4] != null && elementIdentifiers[num4].elementType == type)
						{
							list.Add(elementIdentifiers[num4]);
							num = -627561837;
							continue;
						}
						goto case 10;
					case 3:
						if (num4 >= num3)
						{
							count = list.Count;
							if (count == 0)
							{
								return 0;
							}
							names = new string[count];
							num = -627561826;
							continue;
						}
						goto case 5;
					case 7:
						ids = new int[count];
						num2 = 0;
						num = -627561832;
						continue;
					case 10:
						num4++;
						num = -627561830;
						continue;
					case 1:
						num = -627561839;
						continue;
					case 6:
						num3 = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
						if (num3 == 0)
						{
							return 0;
						}
						list = new List<ControllerElementIdentifier>();
						num4 = 0;
						num = -627561829;
						continue;
					case 4:
						names[num2] = list[num2].name;
						num = -627561831;
						continue;
					default:
						if (num2 >= count)
						{
							return count;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public int GetMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			names = null;
			int num2 = default(int);
			List<ControllerElementIdentifier> list = default(List<ControllerElementIdentifier>);
			int num3 = default(int);
			int num4 = default(int);
			int count = default(int);
			while (true)
			{
				int num = 505637662;
				while (true)
				{
					switch (num ^ 0x1E236B1C)
					{
					case 5:
						break;
					case 7:
						if (elementIdentifiers[num2] != null && InputTools.IsMappableType(elementIdentifiers[num2].elementType))
						{
							list.Add(elementIdentifiers[num2]);
							num = 505637652;
							continue;
						}
						goto case 8;
					case 1:
						if (num3 == 0)
						{
							return 0;
						}
						list = new List<ControllerElementIdentifier>();
						num2 = 0;
						num = 505637660;
						continue;
					case 2:
						ids = null;
						num3 = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
						num = 505637661;
						continue;
					case 9:
						names[num4] = list[num4].name;
						num = 505637658;
						continue;
					case 3:
						if (count == 0)
						{
							num = 505637656;
							continue;
						}
						names = new string[count];
						ids = new int[count];
						num4 = 0;
						num = 505637654;
						continue;
					case 6:
						ids[num4] = list[num4].id;
						num4++;
						num = 505637654;
						continue;
					case 4:
						return 0;
					case 8:
						num2++;
						num = 505637660;
						continue;
					case 10:
					{
						int num5;
						if (num4 >= count)
						{
							num = 505637655;
							num5 = num;
						}
						else
						{
							num = 505637653;
							num5 = num;
						}
						continue;
					}
					case 0:
						if (num2 >= num3)
						{
							count = list.Count;
							num = 505637663;
							continue;
						}
						goto case 7;
					default:
						return count;
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
			while (num < elementIdentifiers.Length)
			{
				while (true)
				{
					if (elementIdentifiers[num].id == id)
					{
						return num;
					}
					num++;
					int num2 = -454683301;
					while (true)
					{
						switch (num2 ^ -454683303)
						{
						case 0:
							num2 = -454683304;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return -1;
		}

		internal ControllerElementType GetEffectiveElementIdentifierType(HardwareControllerMapIdentifier hardwareMapIdentifier, int elementIdentifierId, bool isDefaultMap)
		{
			ControllerElementIdentifier elementIdentifier = GetElementIdentifier(elementIdentifierId);
			Platform specificPlatformMap = default(Platform);
			while (true)
			{
				int num = 1609710360;
				while (true)
				{
					switch (num ^ 0x5FF23B19)
					{
					case 0:
						break;
					case 1:
						if (elementIdentifier != null)
						{
							goto IL_002b;
						}
						return ControllerElementType.Axis;
					default:
						return specificPlatformMap?.GetEffectiveElementIdentifierType(elementIdentifier) ?? ControllerElementType.Axis;
					}
					break;
					IL_002b:
					specificPlatformMap = GetSpecificPlatformMap(hardwareMapIdentifier);
					num = 1609710363;
				}
			}
		}

		internal bool GetEffectiveAxisRange(HardwareControllerMapIdentifier hardwareMapIdentifier, int elementIdentifierId, bool isDefaultMap, out AxisRange axisRange)
		{
			axisRange = AxisRange.Full;
			ControllerElementIdentifier elementIdentifier = default(ControllerElementIdentifier);
			Platform specificPlatformMap = default(Platform);
			while (true)
			{
				int num = -2032414752;
				while (true)
				{
					switch (num ^ -2032414750)
					{
					case 0:
						break;
					case 2:
						elementIdentifier = GetElementIdentifier(elementIdentifierId);
						num = -2032414751;
						continue;
					case 3:
						if (elementIdentifier == null)
						{
							return false;
						}
						specificPlatformMap = GetSpecificPlatformMap(hardwareMapIdentifier);
						num = -2032414749;
						continue;
					default:
						return specificPlatformMap?.GetEffectiveAxisRange(elementIdentifier, out axisRange) ?? false;
					}
					break;
				}
			}
		}

		internal void GetElementIdentifiersForControllerElements(HardwareControllerMapIdentifier hardwareMapIdentifier, bool isDefaultMap, out int[] buttons, out int[] axes)
		{
			buttons = null;
			axes = null;
			Platform specificPlatformMap = GetSpecificPlatformMap(hardwareMapIdentifier);
			while (true)
			{
				int num = 2040713040;
				while (true)
				{
					switch (num ^ 0x79A2CF51)
					{
					case 2:
						break;
					default:
						return;
					case 5:
						if (specificPlatformMap.assignedButtonCount <= 0)
						{
							return;
						}
						goto case 4;
					case 4:
						specificPlatformMap.GetGameElementIdentifierIdMappings(out buttons, out axes);
						num = 2040713042;
						continue;
					case 1:
					{
						int num2;
						if (specificPlatformMap == null)
						{
							num = 2040713041;
							num2 = num;
						}
						else
						{
							num = 2040713044;
							num2 = num;
						}
						continue;
					}
					case 0:
						return;
					case 3:
						return;
					}
					break;
				}
			}
		}

		internal static bool Matches(Platform platform, BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (platform == null)
			{
				while (true)
				{
					int num = 1298303764;
					while (true)
					{
						switch (num ^ 0x4D628B17)
						{
						case 2:
							break;
						case 3:
							variantIndex = -1;
							num = 1298303767;
							continue;
						case 0:
							platformMap = null;
							num = 1298303766;
							continue;
						default:
							return false;
						}
						break;
					}
				}
			}
			return platform.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
		}

		internal bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex, out Platform platformMap)
		{
			actualInputPlatform = InputPlatform.mWddvsAGGdWECRlxCOhehpBItyh;
			variantIndex = -1;
			platformMap = null;
			InputSource inputSource = default(InputSource);
			while (true)
			{
				int num = 1111007786;
				while (true)
				{
					switch (num ^ 0x4238A22B)
					{
					case 10:
						break;
					case 7:
						return linux.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
					case 9:
						switch (inputSource)
						{
						case InputSource.WindowsUWP:
							break;
						case InputSource.Fallback:
						case InputSource.Fallback_PreConfigured:
							platformMap = FindFallbackMatch(bridgedControllerHWInfo, strictMatch, isDefaultMap, out actualInputPlatform, out variantIndex);
							return platformMap != null;
						case InputSource.WebGL:
							goto IL_00a9;
						case InputSource.Ouya:
							goto IL_00ca;
						case InputSource.XboxOne:
							goto IL_00eb;
						case InputSource.GameCoreXboxOne:
						case InputSource.GameCoreScarlett:
							goto IL_010c;
						case InputSource.PS4:
							goto IL_012d;
						case InputSource.PS5:
							goto IL_014e;
						default:
							goto IL_01ea;
						case InputSource.NintendoSwitch:
							goto IL_0217;
						case InputSource.XInput:
							goto IL_0244;
						case InputSource.OSX:
							goto IL_0264;
						case InputSource.Linux:
							goto IL_0284;
						case InputSource.DirectInput:
							goto IL_029d;
						case InputSource.RawInput:
							goto IL_02d1;
						case InputSource.Stadia:
							goto IL_0300;
						case InputSource.SDL2:
							platformMap = FindSDL2Match(bridgedControllerHWInfo, strictMatch, isDefaultMap, out actualInputPlatform, out variantIndex);
							return platformMap != null;
						case InputSource.Steam:
							actualInputPlatform = InputPlatform.wHPBYVcSPaWTXCAyolOVCijkbqIm;
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
							goto IL_03c3;
						}
						if (windowsUWP == null)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.YRqjNMGyPIGPClpJpmPGREvRRcG;
						return windowsUWP.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
					case 0:
						return false;
					case 2:
						return ps5.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
					case 1:
						if (bridgedControllerHWInfo == null)
						{
							num = 1111007790;
							continue;
						}
						inputSource = bridgedControllerHWInfo.inputSource;
						num = 1111007778;
						continue;
					case 8:
						return true;
					case 3:
						goto IL_029d;
					case 11:
						return nintendoSwitch.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
					case 6:
						if (inputSource == InputSource.InternalDriver)
						{
							if (internalDriver == null)
							{
								return false;
							}
							actualInputPlatform = InputPlatform.ZttKGDSUEbTObEfblEyIYTXbRoc;
							num = 1111007783;
						}
						else
						{
							num = 1111007782;
						}
						continue;
					case 14:
						return true;
					case 5:
						return false;
					case 4:
						actualInputPlatform = InputPlatform.TxthorEPmOLBHYyZxIReALnmNeM;
						num = 1111007781;
						continue;
					default:
						return internalDriver.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
					case 13:
						goto IL_03c3;
						IL_01ea:
						num = 1111007789;
						continue;
						IL_0264:
						if (osx == null)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.PFLTzcYFaBOghAebEsCXymESHdk;
						return osx.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						IL_014e:
						if (ps5 == null)
						{
							num = 1111007787;
							continue;
						}
						actualInputPlatform = InputPlatform.svmFLfAwcmvduLqYnidKumuhopX;
						num = 1111007785;
						continue;
						IL_0284:
						if (linux == null)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.LpFemRBnLvpZJDqbCUqPHDmhIPES;
						num = 1111007788;
						continue;
						IL_00eb:
						if (xboxOne == null)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.QAbfXJnvPJiIZJfOVOFDonsOFob;
						return xboxOne.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						IL_03c3:
						throw new NotImplementedException();
						IL_0300:
						if (stadia == null)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.tDSEXVttzObSTRvKkzvQqSrZkMJ;
						return stadia.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						IL_010c:
						if (gameCore == null)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.AkZZquMxhXIVvnmCRwxaVZYYTek;
						return gameCore.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						IL_0244:
						if (xInput == null)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.ZrSavanyxdsgnhdTbscQkWtEAzy;
						return xInput.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						IL_02d1:
						if (Matches(rawInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
						{
							num = 1111007791;
							continue;
						}
						if (!Matches(directInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
						{
							return false;
						}
						actualInputPlatform = InputPlatform.nxzcJmevYVMAWQJHQoCKKweYMfMv;
						num = 1111007779;
						continue;
						IL_00ca:
						if (ouya == null)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.RZICaWagIuKgaolDMOOypgwWFMH;
						return ouya.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						IL_012d:
						if (ps4 == null)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.HglRpaPpklgbSOuqnDvBSmwGtUX;
						return ps4.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						IL_0217:
						if (nintendoSwitch == null)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.SzWkkyLAdSLqShzUrBqqoRHKOhW;
						num = 1111007776;
						continue;
						IL_00a9:
						if (webGL == null)
						{
							return false;
						}
						actualInputPlatform = InputPlatform.mvnXduzIcJqcHpJHCcDjxXAwuzv;
						return webGL.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
						IL_029d:
						if (Matches(directInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
						{
							actualInputPlatform = InputPlatform.nxzcJmevYVMAWQJHQoCKKweYMfMv;
							return true;
						}
						if (Matches(rawInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
						{
							actualInputPlatform = InputPlatform.TxthorEPmOLBHYyZxIReALnmNeM;
							return true;
						}
						return false;
					}
					break;
				}
			}
		}

		internal HardwareJoystickMap_InputManager GetDefaultHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			InputSource inputSource = bridgedController.inputSource;
			int num;
			Platform platform = default(Platform);
			InputPlatform actualInputPlatform = default(InputPlatform);
			int variantIndex;
			switch (inputSource)
			{
			default:
				num = -993663431;
				goto IL_00a5;
			case InputSource.PS4:
				goto IL_012d;
			case InputSource.DirectInput:
				goto IL_0141;
			case InputSource.None:
				goto IL_015e;
			case InputSource.Steam:
			case InputSource.UnityKeyboardAndMouse:
			case InputSource.Custom:
				throw new NotImplementedException();
			case InputSource.SDL2:
				goto IL_0170;
			case InputSource.XInput:
				goto IL_0187;
			case InputSource.Linux:
				goto IL_019a;
			case InputSource.Fallback:
			case InputSource.Fallback_PreConfigured:
				goto IL_01b8;
			case InputSource.WindowsUWP:
				goto IL_01d9;
			case InputSource.GameCoreXboxOne:
			case InputSource.GameCoreScarlett:
				goto IL_01ec;
			case InputSource.Stadia:
				goto IL_0210;
			case InputSource.NintendoSwitch:
				goto IL_0224;
			case InputSource.InternalDriver:
				goto IL_0238;
			case InputSource.WebGL:
				goto IL_024c;
			case InputSource.RawInput:
				goto IL_0259;
			case InputSource.PS5:
				goto IL_027d;
			case InputSource.XboxOne:
				goto IL_0291;
			case (InputSource)10:
			case (InputSource)11:
			case (InputSource)12:
			case (InputSource)13:
			case (InputSource)14:
			case (InputSource)15:
			case (InputSource)16:
			case (InputSource)17:
			case (InputSource)23:
				break;
			case InputSource.OSX:
				goto IL_02cf;
			case InputSource.Ouya:
				goto IL_030e;
				IL_00a5:
				while (true)
				{
					switch (num ^ -993663441)
					{
					case 25:
						break;
					case 12:
						goto IL_012d;
					case 18:
						goto IL_0141;
					case 29:
						num = -993663452;
						continue;
					case 26:
						goto IL_015e;
					case 24:
						goto IL_0170;
					case 8:
						goto IL_0187;
					case 9:
						goto IL_019a;
					case 22:
						num = -993663428;
						continue;
					case 15:
						goto IL_01b8;
					case 2:
						num = -993663452;
						continue;
					case 5:
						goto IL_01d9;
					case 27:
						goto IL_01ec;
					case 11:
						goto IL_0200;
					case 3:
						goto IL_0210;
					case 10:
						goto IL_0224;
					case 20:
						goto IL_0238;
					case 6:
						goto IL_024c;
					case 13:
						goto IL_0259;
					case 23:
						platform = xboxOne;
						num = -993663443;
						continue;
					case 14:
						goto IL_027d;
					case 7:
						goto IL_0291;
					case 1:
						goto IL_029e;
					case 19:
						goto end_IL_000c;
					case 28:
						goto IL_02cf;
					case 0:
						platform = webGL;
						num = -993663452;
						continue;
					case 4:
						platform = Platform_GameCore.CreateDefaultMap(bridgedController);
						num = -993663452;
						continue;
					case 16:
						num = -993663452;
						continue;
					case 21:
						goto IL_030e;
					default:
						return null;
					}
					break;
					IL_029e:
					int num2;
					if (!gameCore.hasData)
					{
						num = -993663445;
						num2 = num;
					}
					else
					{
						num = -993663452;
						num2 = num;
					}
					continue;
					IL_0200:
					if (platform == null)
					{
						num = -993663426;
						continue;
					}
					return platform.ToHardwareJoystickMap_InputManager(this, inputSource, actualInputPlatform, -1);
				}
				goto default;
				IL_030e:
				actualInputPlatform = InputPlatform.RZICaWagIuKgaolDMOOypgwWFMH;
				platform = ouya;
				num = -993663452;
				goto IL_00a5;
				IL_02cf:
				actualInputPlatform = InputPlatform.PFLTzcYFaBOghAebEsCXymESHdk;
				platform = osx;
				num = -993663452;
				goto IL_00a5;
				IL_0291:
				actualInputPlatform = InputPlatform.QAbfXJnvPJiIZJfOVOFDonsOFob;
				num = -993663432;
				goto IL_00a5;
				IL_027d:
				actualInputPlatform = InputPlatform.svmFLfAwcmvduLqYnidKumuhopX;
				platform = ps5;
				num = -993663425;
				goto IL_00a5;
				IL_0259:
				actualInputPlatform = InputPlatform.TxthorEPmOLBHYyZxIReALnmNeM;
				platform = rawInput;
				num = -993663452;
				goto IL_00a5;
				IL_024c:
				actualInputPlatform = InputPlatform.mvnXduzIcJqcHpJHCcDjxXAwuzv;
				num = -993663441;
				goto IL_00a5;
				IL_0238:
				actualInputPlatform = InputPlatform.ZttKGDSUEbTObEfblEyIYTXbRoc;
				platform = internalDriver;
				num = -993663438;
				goto IL_00a5;
				IL_0224:
				actualInputPlatform = InputPlatform.SzWkkyLAdSLqShzUrBqqoRHKOhW;
				platform = nintendoSwitch;
				num = -993663452;
				goto IL_00a5;
				IL_0210:
				actualInputPlatform = InputPlatform.tDSEXVttzObSTRvKkzvQqSrZkMJ;
				platform = stadia;
				num = -993663452;
				goto IL_00a5;
				IL_01ec:
				actualInputPlatform = InputPlatform.AkZZquMxhXIVvnmCRwxaVZYYTek;
				platform = gameCore;
				num = -993663442;
				goto IL_00a5;
				IL_01d9:
				actualInputPlatform = InputPlatform.YRqjNMGyPIGPClpJpmPGREvRRcG;
				platform = windowsUWP;
				num = -993663452;
				goto IL_00a5;
				IL_01b8:
				platform = FindFallbackMap(inputSource, isDefaultMap: true, out actualInputPlatform, out variantIndex);
				num = -993663452;
				goto IL_00a5;
				IL_019a:
				actualInputPlatform = InputPlatform.LpFemRBnLvpZJDqbCUqPHDmhIPES;
				platform = linux;
				num = -993663452;
				goto IL_00a5;
				IL_0187:
				actualInputPlatform = InputPlatform.ZrSavanyxdsgnhdTbscQkWtEAzy;
				platform = xInput;
				num = -993663452;
				goto IL_00a5;
				IL_0170:
				platform = FindSDL2Map(inputSource, isDefaultMap: true, out actualInputPlatform, out variantIndex);
				num = -993663452;
				goto IL_00a5;
				IL_015e:
				return null;
				IL_0141:
				actualInputPlatform = InputPlatform.nxzcJmevYVMAWQJHQoCKKweYMfMv;
				platform = directInput;
				num = -993663452;
				goto IL_00a5;
				IL_012d:
				actualInputPlatform = InputPlatform.HglRpaPpklgbSOuqnDvBSmwGtUX;
				platform = ps4;
				num = -993663452;
				goto IL_00a5;
				end_IL_000c:
				break;
			}
			throw new NotImplementedException();
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
			Platform_Fallback_Base platform_Fallback_Base = default(Platform_Fallback_Base);
			while (true)
			{
				int num = -1434949758;
				while (true)
				{
					switch (num ^ -1434949747)
					{
					case 28:
						break;
					case 23:
						if (isDefaultMap && platform_Fallback_Base != null && actualInputPlatform != InputPlatform.ihHkUizAxnFTofebgOcNeIKdjDdD)
						{
							platform_Fallback_Base = null;
							num = -1434949730;
							continue;
						}
						goto case 19;
					case 12:
						actualInputPlatform = InputPlatform.YzmOpGLKJXakWuQxDJNYoikTWXV;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 24:
						actualInputPlatform = InputPlatform.BfEQfLyOjlOdysiRbIaosBjRLpg;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 27:
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 10:
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 20:
						if (isDefaultMap && platform_Fallback_Base != null && actualInputPlatform != InputPlatform.JdIptPBVWljvyIXqApempcOWYPa)
						{
							platform_Fallback_Base = null;
							num = -1434949737;
							continue;
						}
						goto case 26;
					case 0:
						actualInputPlatform = InputPlatform.MUAhruUHigYSGBDKEDFejoaAIKbu;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 17:
						platform_Fallback_Base = TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						num = -1434949735;
						continue;
					case 6:
						platform = Rewired.Platforms.Platform.Linux;
						num = -1434949729;
						continue;
					case 15:
						platform = UnityTools.platform;
						switch (UnityTools.editorPlatform)
						{
						case EditorPlatform.Linux:
							break;
						default:
							goto IL_0252;
						case EditorPlatform.Windows:
							goto IL_02b7;
						case EditorPlatform.OSX:
							goto IL_0536;
						}
						goto case 6;
					case 19:
						if (platform_Fallback_Base != null)
						{
							return platform_Fallback_Base;
						}
						goto IL_0261;
					case 21:
						actualInputPlatform = InputPlatform.ArpgvXxCfOlVSvkIJEIwRKgOTcG;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 22:
						goto IL_02b7;
					case 8:
						actualInputPlatform = InputPlatform.ArpgvXxCfOlVSvkIJEIwRKgOTcG;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 18:
						switch (platform)
						{
						case Rewired.Platforms.Platform.PS4:
							break;
						case Rewired.Platforms.Platform.PS3:
							goto IL_00f4;
						case Rewired.Platforms.Platform.Webplayer:
							goto IL_0114;
						default:
							goto IL_0158;
						case Rewired.Platforms.Platform.Xbox360:
							platform_Fallback_Base = fallback_XBox360;
							actualInputPlatform = InputPlatform.uvinkbnCOUhiBIQPTivyCtHAuXUk;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.XboxOne:
							goto IL_019e;
						case Rewired.Platforms.Platform.Linux:
							goto IL_01e4;
						case Rewired.Platforms.Platform.Android:
							goto IL_027c;
						case Rewired.Platforms.Platform.RazerForgeTV:
							goto IL_02a1;
						case Rewired.Platforms.Platform.iOS:
						case Rewired.Platforms.Platform.tvOS:
							goto IL_02d7;
						case Rewired.Platforms.Platform.Blackberry:
							goto IL_03a9;
						case Rewired.Platforms.Platform.PSMobile:
							platform_Fallback_Base = fallback_PSM;
							actualInputPlatform = InputPlatform.spryPJJRZoNXpNHWwjQrYqqOcQaE;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.PSVita:
							platform_Fallback_Base = fallback_PSVita;
							actualInputPlatform = InputPlatform.OIhUrHBapNKofzWuGXdbWpfEYqL;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.Wii:
							goto IL_03ff;
						case Rewired.Platforms.Platform.WindowsUWP:
							goto IL_0435;
						case Rewired.Platforms.Platform.WiiU:
							platform_Fallback_Base = fallback_WiiU;
							actualInputPlatform = InputPlatform.AUxRFgGXRnMmNDDYccYLHOChnqyL;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						case Rewired.Platforms.Platform.AmazonFireTV:
							goto IL_0475;
						case Rewired.Platforms.Platform.WindowsPhone8:
							goto IL_04c6;
						case Rewired.Platforms.Platform.Windows:
						case Rewired.Platforms.Platform.WindowsAppStore:
							goto IL_04e4;
						case Rewired.Platforms.Platform.OSX:
							goto IL_0516;
						}
						platform_Fallback_Base = fallback_PS4;
						actualInputPlatform = InputPlatform.VVULNUzeBDKyeIXYqiPFHOiKRFQ;
						num = -1434949760;
						continue;
					case 4:
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 13:
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 29:
						if (platform_Fallback_Base != null)
						{
							return platform_Fallback_Base;
						}
						platform_Fallback_Base = fallback_Android;
						num = -1434949736;
						continue;
					case 5:
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 14:
						actualInputPlatform = InputPlatform.UNTAzLDwrIRHwWirSuYtaEQeELys;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 11:
						actualInputPlatform = InputPlatform.ePYPwNnorHLXgaZGXMLQtvarFfn;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 26:
						if (platform_Fallback_Base != null)
						{
							num = -1434949740;
							continue;
						}
						platform_Fallback_Base = fallback_Android;
						actualInputPlatform = InputPlatform.ArpgvXxCfOlVSvkIJEIwRKgOTcG;
						num = -1434949738;
						continue;
					case 9:
						goto IL_04e4;
					case 3:
						num = -1434949729;
						continue;
					case 7:
						actualInputPlatform = InputPlatform.sEjjrezmdTWEmzaCLMCrIvBsKtv;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 16:
						actualInputPlatform = InputPlatform.rypEUYaHNuXFnaKpDREuGUThbUgF;
						num = -1434949753;
						continue;
					case 2:
						goto IL_0536;
					case 25:
						return platform_Fallback_Base;
					default:
						{
							actualInputPlatform = InputPlatform.mWddvsAGGdWECRlxCOhehpBItyh;
							return null;
						}
						IL_0516:
						platform_Fallback_Base = fallback_OSX;
						num = -1434949747;
						continue;
						IL_04e4:
						platform_Fallback_Base = fallback_Windows;
						actualInputPlatform = InputPlatform.EyNWaUwBjrKkvnlxbfIvCGetaIFY;
						num = -1434949752;
						continue;
						IL_04c6:
						platform_Fallback_Base = fallback_WindowsPhone8;
						num = -1434949731;
						continue;
						IL_0475:
						platform_Fallback_Base = fallback_AmazonFireTV;
						actualInputPlatform = InputPlatform.weyUTntvYvSMCYMOQToKrFyLWLT;
						platform_Fallback_Base = TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						if (isDefaultMap && platform_Fallback_Base != null && actualInputPlatform != InputPlatform.weyUTntvYvSMCYMOQToKrFyLWLT)
						{
							platform_Fallback_Base = null;
							num = -1434949744;
							continue;
						}
						goto case 29;
						IL_0435:
						platform_Fallback_Base = fallback_WindowsUWP;
						num = -1434949750;
						continue;
						IL_03ff:
						platform_Fallback_Base = fallback_Wii;
						num = -1434949757;
						continue;
						IL_03a9:
						platform_Fallback_Base = fallback_Blackberry;
						num = -1434949754;
						continue;
						IL_02d7:
						platform_Fallback_Base = fallback_iOS;
						actualInputPlatform = InputPlatform.owpHBIMXRSAHRIGaFHvWdFAQwYa;
						num = -1434949751;
						continue;
						IL_02a1:
						platform_Fallback_Base = fallback_RazerForgeTV;
						actualInputPlatform = InputPlatform.JdIptPBVWljvyIXqApempcOWYPa;
						num = -1434949732;
						continue;
						IL_027c:
						platform_Fallback_Base = fallback_Android;
						num = -1434949755;
						continue;
						IL_01e4:
						if (inputSource == InputSource.Fallback_PreConfigured)
						{
							platform_Fallback_Base = fallback_Linux_PreConfigured;
							actualInputPlatform = InputPlatform.ihHkUizAxnFTofebgOcNeIKdjDdD;
							platform_Fallback_Base = TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
							num = -1434949734;
							continue;
						}
						goto IL_0261;
						IL_019e:
						platform_Fallback_Base = fallback_XBoxOne;
						num = -1434949739;
						continue;
						IL_0114:
						if (UnityTools.webplayerPlatform == WebplayerPlatform.Windows)
						{
							platform_Fallback_Base = fallback_Windows;
							actualInputPlatform = InputPlatform.EyNWaUwBjrKkvnlxbfIvCGetaIFY;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						}
						if (UnityTools.webplayerPlatform == WebplayerPlatform.OSX)
						{
							platform_Fallback_Base = fallback_OSX;
							actualInputPlatform = InputPlatform.MUAhruUHigYSGBDKEDFejoaAIKbu;
							return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						}
						goto IL_0158;
						IL_0158:
						if (isDefaultMap)
						{
							return GetUniversalDefaultMap<Platform_Fallback_Base>(out actualInputPlatform, out variantIndex);
						}
						variantIndex = -1;
						num = -1434949748;
						continue;
						IL_0261:
						platform_Fallback_Base = fallback_Linux;
						actualInputPlatform = InputPlatform.ZsaDxCopXVftxhaUhaeehEFdpYT;
						return TryGetFirstMatchingMap(platform_Fallback_Base, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
						IL_00f4:
						platform_Fallback_Base = fallback_PS3;
						num = -1434949759;
						continue;
						IL_0536:
						platform = Rewired.Platforms.Platform.OSX;
						num = -1434949746;
						continue;
						IL_02b7:
						platform = Rewired.Platforms.Platform.Windows;
						num = -1434949729;
						continue;
						IL_0252:
						num = -1434949729;
						continue;
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
				num = 1724136556;
				goto IL_0025;
			case EditorPlatform.OSX:
				goto IL_02c8;
			case EditorPlatform.Linux:
				goto IL_02fb;
			case EditorPlatform.Windows:
				goto IL_0307;
				IL_0025:
				while (true)
				{
					switch (num ^ 0x66C43C7A)
					{
					case 23:
						break;
					case 11:
						actualInputPlatform = InputPlatform.EyNWaUwBjrKkvnlxbfIvCGetaIFY;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 10:
						actualInputPlatform = InputPlatform.ArpgvXxCfOlVSvkIJEIwRKgOTcG;
						num = 1724136568;
						continue;
					case 12:
						actualInputPlatform = InputPlatform.VVULNUzeBDKyeIXYqiPFHOiKRFQ;
						num = 1724136570;
						continue;
					case 21:
						platform_Fallback_Base = null;
						num = 1724136563;
						continue;
					case 5:
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 18:
						actualInputPlatform = InputPlatform.uvinkbnCOUhiBIQPTivyCtHAuXUk;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 17:
						actualInputPlatform = InputPlatform.YzmOpGLKJXakWuQxDJNYoikTWXV;
						num = 1724136554;
						continue;
					case 24:
						goto IL_01cd;
					case 1:
						goto IL_01f3;
					case 16:
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 26:
						actualInputPlatform = InputPlatform.ZsaDxCopXVftxhaUhaeehEFdpYT;
						num = 1724136574;
						continue;
					case 19:
						goto IL_02c8;
					case 8:
						goto IL_02d4;
					case 9:
						goto IL_02e5;
					case 14:
						goto IL_02fb;
					case 6:
						goto IL_0307;
					case 29:
						platform_Fallback_Base = fallback_Windows;
						actualInputPlatform = InputPlatform.EyNWaUwBjrKkvnlxbfIvCGetaIFY;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 22:
						num = 1724136571;
						continue;
					case 28:
						actualInputPlatform = InputPlatform.ArpgvXxCfOlVSvkIJEIwRKgOTcG;
						num = 1724136545;
						continue;
					case 13:
						goto IL_0356;
					case 0:
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 4:
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 2:
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 25:
						platform_Fallback_Base = fallback_OSX;
						actualInputPlatform = InputPlatform.MUAhruUHigYSGBDKEDFejoaAIKbu;
						num = 1724136573;
						continue;
					case 15:
						actualInputPlatform = InputPlatform.spryPJJRZoNXpNHWwjQrYqqOcQaE;
						num = 1724136575;
						continue;
					case 27:
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 3:
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 20:
						goto IL_04c4;
					default:
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					}
					break;
					IL_01f3:
					switch (platform)
					{
					case Rewired.Platforms.Platform.WindowsUWP:
						platform_Fallback_Base = fallback_WindowsUWP;
						actualInputPlatform = InputPlatform.sEjjrezmdTWEmzaCLMCrIvBsKtv;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.OSX:
						platform_Fallback_Base = fallback_OSX;
						actualInputPlatform = InputPlatform.MUAhruUHigYSGBDKEDFejoaAIKbu;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.Linux:
						break;
					case Rewired.Platforms.Platform.PSVita:
						platform_Fallback_Base = fallback_PSVita;
						actualInputPlatform = InputPlatform.OIhUrHBapNKofzWuGXdbWpfEYqL;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.Wii:
						platform_Fallback_Base = fallback_Wii;
						actualInputPlatform = InputPlatform.UNTAzLDwrIRHwWirSuYtaEQeELys;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.WiiU:
						goto IL_0172;
					case Rewired.Platforms.Platform.XboxOne:
						platform_Fallback_Base = fallback_XBoxOne;
						actualInputPlatform = InputPlatform.BfEQfLyOjlOdysiRbIaosBjRLpg;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.PS3:
						goto IL_01ae;
					case Rewired.Platforms.Platform.PS4:
						goto IL_02a9;
					case Rewired.Platforms.Platform.Windows:
					case Rewired.Platforms.Platform.WindowsAppStore:
						goto IL_02d4;
					case Rewired.Platforms.Platform.PSMobile:
						goto IL_0378;
					case Rewired.Platforms.Platform.Android:
						platform_Fallback_Base = fallback_Android;
						actualInputPlatform = InputPlatform.ArpgvXxCfOlVSvkIJEIwRKgOTcG;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.iOS:
					case Rewired.Platforms.Platform.tvOS:
						platform_Fallback_Base = fallback_iOS;
						actualInputPlatform = InputPlatform.owpHBIMXRSAHRIGaFHvWdFAQwYa;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.Blackberry:
						platform_Fallback_Base = fallback_Blackberry;
						actualInputPlatform = InputPlatform.ePYPwNnorHLXgaZGXMLQtvarFfn;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.WindowsPhone8:
						platform_Fallback_Base = fallback_WindowsPhone8;
						actualInputPlatform = InputPlatform.rypEUYaHNuXFnaKpDREuGUThbUgF;
						return TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.Xbox360:
						goto IL_03f1;
					case Rewired.Platforms.Platform.RazerForgeTV:
						goto IL_040e;
					case Rewired.Platforms.Platform.Webplayer:
						goto IL_0474;
					case Rewired.Platforms.Platform.AmazonFireTV:
						goto IL_0495;
					default:
						goto end_IL_000f;
					}
					if (inputSource == InputSource.Fallback_PreConfigured)
					{
						platform_Fallback_Base = fallback_Linux_PreConfigured;
						actualInputPlatform = InputPlatform.ihHkUizAxnFTofebgOcNeIKdjDdD;
						platform_Fallback_Base = TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
						num = 1724136546;
						continue;
					}
					goto IL_02ea;
					IL_0495:
					platform_Fallback_Base = fallback_AmazonFireTV;
					actualInputPlatform = InputPlatform.weyUTntvYvSMCYMOQToKrFyLWLT;
					platform_Fallback_Base = TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					if (isDefaultMap && platform_Fallback_Base != null && actualInputPlatform != InputPlatform.weyUTntvYvSMCYMOQToKrFyLWLT)
					{
						platform_Fallback_Base = null;
						num = 1724136558;
						continue;
					}
					goto IL_04c4;
					IL_02e5:
					if (platform_Fallback_Base != null)
					{
						return platform_Fallback_Base;
					}
					goto IL_02ea;
					IL_02ea:
					platform_Fallback_Base = fallback_Linux;
					num = 1724136544;
					continue;
					IL_03f1:
					platform_Fallback_Base = fallback_XBox360;
					num = 1724136552;
					continue;
					IL_04c4:
					if (platform_Fallback_Base != null)
					{
						return platform_Fallback_Base;
					}
					platform_Fallback_Base = fallback_Android;
					num = 1724136560;
					continue;
					IL_0356:
					if (platform_Fallback_Base != null)
					{
						return platform_Fallback_Base;
					}
					platform_Fallback_Base = fallback_Android;
					num = 1724136550;
					continue;
					IL_01cd:
					if (isDefaultMap && platform_Fallback_Base != null)
					{
						int num2;
						if (actualInputPlatform == InputPlatform.ihHkUizAxnFTofebgOcNeIKdjDdD)
						{
							num = 1724136563;
							num2 = num;
						}
						else
						{
							num = 1724136559;
							num2 = num;
						}
						continue;
					}
					goto IL_02e5;
					IL_0474:
					if (UnityTools.webplayerPlatform != WebplayerPlatform.Windows)
					{
						if (UnityTools.webplayerPlatform != WebplayerPlatform.OSX)
						{
							goto end_IL_000f;
						}
						num = 1724136547;
					}
					else
					{
						num = 1724136551;
					}
					continue;
					IL_0378:
					platform_Fallback_Base = fallback_PSM;
					num = 1724136565;
					continue;
					IL_02d4:
					platform_Fallback_Base = fallback_Windows;
					num = 1724136561;
					continue;
					IL_02a9:
					platform_Fallback_Base = fallback_PS4;
					num = 1724136566;
					continue;
					IL_040e:
					platform_Fallback_Base = fallback_RazerForgeTV;
					actualInputPlatform = InputPlatform.JdIptPBVWljvyIXqApempcOWYPa;
					platform_Fallback_Base = TryGetFirstValidMap(platform_Fallback_Base, isDefaultMap, ref actualInputPlatform, out variantIndex);
					if (isDefaultMap && platform_Fallback_Base != null && actualInputPlatform != InputPlatform.JdIptPBVWljvyIXqApempcOWYPa)
					{
						platform_Fallback_Base = null;
						num = 1724136567;
						continue;
					}
					goto IL_0356;
					IL_01ae:
					platform_Fallback_Base = fallback_PS3;
					num = 1724136555;
					continue;
					IL_0172:
					platform_Fallback_Base = fallback_WiiU;
					actualInputPlatform = InputPlatform.AUxRFgGXRnMmNDDYccYLHOChnqyL;
					num = 1724136569;
				}
				goto default;
				IL_0307:
				platform = Rewired.Platforms.Platform.Windows;
				num = 1724136571;
				goto IL_0025;
				IL_02fb:
				platform = Rewired.Platforms.Platform.Linux;
				num = 1724136571;
				goto IL_0025;
				IL_02c8:
				platform = Rewired.Platforms.Platform.OSX;
				num = 1724136571;
				goto IL_0025;
				end_IL_000f:
				break;
			}
			if (isDefaultMap)
			{
				return GetUniversalDefaultMap<Platform_Fallback_Base>(out actualInputPlatform, out variantIndex);
			}
			variantIndex = -1;
			actualInputPlatform = InputPlatform.mWddvsAGGdWECRlxCOhehpBItyh;
			return null;
		}

		private Platform_SDL2_Base FindSDL2Match(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			Rewired.Platforms.Platform platform = UnityTools.platform;
			Rewired.Platforms.Platform platform2 = default(Rewired.Platforms.Platform);
			int num;
			Platform_SDL2_Base mainMap = default(Platform_SDL2_Base);
			switch (UnityTools.editorPlatform)
			{
			default:
			{
				platform2 = platform;
				int num2;
				if (platform2 != Rewired.Platforms.Platform.Windows)
				{
					num = -1557925027;
					num2 = num;
				}
				else
				{
					num = -1557925028;
					num2 = num;
				}
				goto IL_0027;
			}
			case EditorPlatform.OSX:
				goto IL_0099;
			case EditorPlatform.Linux:
				goto IL_010d;
			case EditorPlatform.Windows:
				goto IL_0119;
				IL_010d:
				platform = Rewired.Platforms.Platform.Linux;
				num = -1557925039;
				goto IL_0027;
				IL_0099:
				platform = Rewired.Platforms.Platform.OSX;
				num = -1557925039;
				goto IL_0027;
				IL_0027:
				while (true)
				{
					switch (num ^ -1557925030)
					{
					case 3:
						num = -1557925040;
						continue;
					case 11:
						break;
					case 1:
						return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 5:
						goto IL_0099;
					case 8:
						actualInputPlatform = InputPlatform.PWHiXxDBzketsYwZBiVoACMtEdP;
						return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 4:
						return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 7:
						goto IL_00ed;
					case 0:
						goto IL_010d;
					case 10:
						goto IL_0119;
					case 6:
						mainMap = sdl2_Windows;
						actualInputPlatform = InputPlatform.oDiIcinIBGOOyqKvDBdnWsbZGMv;
						num = -1557925026;
						continue;
					case 2:
						actualInputPlatform = InputPlatform.ZlXwEiQKEmyTNTNLkgHhdkHiqKF;
						num = -1557925029;
						continue;
					default:
						goto IL_014a;
					}
					break;
					IL_00ed:
					switch (platform2)
					{
					case Rewired.Platforms.Platform.OSX:
						mainMap = sdl2_OSX;
						num = -1557925038;
						continue;
					case Rewired.Platforms.Platform.Linux:
						mainMap = sdl2_Linux;
						num = -1557925032;
						continue;
					}
					if (isDefaultMap)
					{
						GetUniversalDefaultMap<Platform_SDL2_Base>(out actualInputPlatform, out variantIndex);
						num = -1557925037;
						continue;
					}
					goto IL_014a;
					IL_014a:
					actualInputPlatform = InputPlatform.mWddvsAGGdWECRlxCOhehpBItyh;
					variantIndex = -1;
					return null;
				}
				goto default;
				IL_0119:
				platform = Rewired.Platforms.Platform.Windows;
				num = -1557925039;
				goto IL_0027;
			}
		}

		private Platform_SDL2_Base FindSDL2Map(InputSource inputSource, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			Rewired.Platforms.Platform platform = UnityTools.platform;
			Rewired.Platforms.Platform platform2 = default(Rewired.Platforms.Platform);
			int num;
			Platform_SDL2_Base mainMap = default(Platform_SDL2_Base);
			switch (UnityTools.editorPlatform)
			{
			default:
			{
				platform2 = platform;
				int num2;
				if (platform2 != Rewired.Platforms.Platform.Windows)
				{
					num = -1039168084;
					num2 = num;
				}
				else
				{
					num = -1039168092;
					num2 = num;
				}
				goto IL_0027;
			}
			case EditorPlatform.Linux:
				goto IL_00ef;
			case EditorPlatform.Windows:
				goto IL_00fb;
			case EditorPlatform.OSX:
				goto IL_0107;
				IL_00fb:
				platform = Rewired.Platforms.Platform.Windows;
				num = -1039168082;
				goto IL_0027;
				IL_00ef:
				platform = Rewired.Platforms.Platform.Linux;
				num = -1039168082;
				goto IL_0027;
				IL_0027:
				while (true)
				{
					switch (num ^ -1039168090)
					{
					case 4:
						num = -1039168089;
						continue;
					case 8:
						break;
					case 2:
						mainMap = sdl2_Windows;
						actualInputPlatform = InputPlatform.oDiIcinIBGOOyqKvDBdnWsbZGMv;
						return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 10:
						goto IL_00c5;
					case 7:
						num = -1039168082;
						continue;
					case 3:
						goto IL_00ef;
					case 1:
						goto IL_00fb;
					case 5:
						goto IL_0107;
					case 12:
						return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case 11:
						actualInputPlatform = InputPlatform.mWddvsAGGdWECRlxCOhehpBItyh;
						num = -1039168096;
						continue;
					case 6:
						variantIndex = -1;
						num = -1039168081;
						continue;
					case 0:
						GetUniversalDefaultMap<Platform_SDL2_Base>(out actualInputPlatform, out variantIndex);
						num = -1039168083;
						continue;
					default:
						return null;
					}
					break;
					IL_00c5:
					switch (platform2)
					{
					case Rewired.Platforms.Platform.Linux:
						mainMap = sdl2_Linux;
						actualInputPlatform = InputPlatform.ZlXwEiQKEmyTNTNLkgHhdkHiqKF;
						return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
					case Rewired.Platforms.Platform.OSX:
						mainMap = sdl2_OSX;
						actualInputPlatform = InputPlatform.PWHiXxDBzketsYwZBiVoACMtEdP;
						num = -1039168086;
						continue;
					}
					int num3;
					if (isDefaultMap)
					{
						num = -1039168090;
						num3 = num;
					}
					else
					{
						num = -1039168083;
						num3 = num;
					}
				}
				goto default;
				IL_0107:
				platform = Rewired.Platforms.Platform.OSX;
				num = -1039168095;
				goto IL_0027;
			}
		}

		private T TryGetFirstValidMap<T>(T mainMap, bool isDefaultMap, ref InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
		{
			if (isDefaultMap)
			{
				if (mainMap != null)
				{
					goto IL_000e;
				}
				goto IL_0056;
			}
			int num;
			if (mainMap != null)
			{
				if (!mainMap.selfOrVariantIsValid)
				{
					num = -1535118584;
					goto IL_0013;
				}
				return mainMap.GetFirstValidPlatformMap(out variantIndex) as T;
			}
			goto IL_004b;
			IL_000e:
			num = -1535118587;
			goto IL_0013;
			IL_0013:
			int num2 = default(int);
			IList<Platform> variants_base = default(IList<Platform>);
			while (true)
			{
				switch (num ^ -1535118591)
				{
				case 2:
					break;
				case 9:
					goto IL_004b;
				case 5:
					goto IL_0056;
				case 4:
					goto IL_0076;
				case 3:
					goto IL_008c;
				case 6:
					variantIndex = -1;
					return mainMap;
				case 1:
					goto IL_00e0;
				case 7:
					num = -1535118583;
					continue;
				case 8:
					goto IL_0118;
				default:
					return null;
				}
				break;
				IL_0118:
				int num3;
				if (num2 < variants_base.Count)
				{
					num = -1535118590;
					num3 = num;
				}
				else
				{
					num = -1535118592;
					num3 = num;
				}
				continue;
				IL_0076:
				if (mainMap.selfOrVariantIsAllowed)
				{
					if (mainMap.isAllowed)
					{
						num = -1535118585;
						continue;
					}
					variants_base = mainMap.variants_base;
					if (variants_base != null)
					{
						num2 = 0;
						num = -1535118586;
						continue;
					}
					goto IL_00e0;
				}
				num = -1535118588;
				continue;
				IL_00e0:
				return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
				IL_008c:
				Platform platform = variants_base[num2];
				if (platform != null && platform.isAllowed)
				{
					variantIndex = num2;
					return platform as T;
				}
				num2++;
				num = -1535118583;
			}
			goto IL_000e;
			IL_0056:
			return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
			IL_004b:
			variantIndex = -1;
			num = -1535118591;
			goto IL_0013;
		}

		private T TryGetFirstMatchingMap<T>(T mainMap, BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, ref InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
		{
			if (isDefaultMap)
			{
				goto IL_0004;
			}
			if (mainMap == null)
			{
				variantIndex = -1;
				return null;
			}
			Platform platformMap = default(Platform);
			int num;
			T result = default(T);
			if (mainMap.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				num = -479150681;
			}
			else
			{
				variantIndex = -1;
				result = null;
				num = -479150684;
			}
			goto IL_0009;
			IL_0009:
			switch (num ^ -479150683)
			{
			case 0:
				break;
			case 3:
				if (mainMap == null)
				{
					return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
				}
				if (mainMap.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return platformMap as T;
				}
				return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
			case 2:
				return platformMap as T;
			default:
				return result;
			}
			goto IL_0004;
			IL_0004:
			num = -479150682;
			goto IL_0009;
		}

		private T GetUniversalDefaultMap<T>(out InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
		{
			T universalDefaultMapRoot = GetUniversalDefaultMapRoot<T>(typeof(T), out actualInputPlatform);
			actualInputPlatform = InputPlatform.oDiIcinIBGOOyqKvDBdnWsbZGMv;
			variantIndex = -1;
			int num2 = default(int);
			IList<Platform> variants_base = default(IList<Platform>);
			while (true)
			{
				int num = -1463813286;
				while (true)
				{
					switch (num ^ -1463813293)
					{
					case 6:
						break;
					case 1:
						variantIndex = num2;
						return variants_base[num2] as T;
					case 2:
						return null;
					case 10:
					{
						int num4;
						if (variants_base == null)
						{
							num = -1463813296;
							num4 = num;
						}
						else
						{
							num = -1463813293;
							num4 = num;
						}
						continue;
					}
					case 7:
						if (variants_base[num2].isAllowed)
						{
							num = -1463813294;
							continue;
						}
						goto IL_006f;
					case 9:
					{
						int num3;
						if (universalDefaultMapRoot == null)
						{
							num = -1463813295;
							num3 = num;
						}
						else
						{
							num = -1463813285;
							num3 = num;
						}
						continue;
					}
					case 0:
						num2 = 0;
						num = -1463813289;
						continue;
					case 4:
					{
						int num5;
						if (num2 >= variants_base.Count)
						{
							num = -1463813296;
							num5 = num;
						}
						else
						{
							num = -1463813290;
							num5 = num;
						}
						continue;
					}
					case 5:
						if (variants_base[num2] != null)
						{
							num = -1463813292;
							continue;
						}
						goto IL_006f;
					case 8:
						if (universalDefaultMapRoot.selfOrVariantIsAllowed)
						{
							if (universalDefaultMapRoot.isAllowed)
							{
								return universalDefaultMapRoot;
							}
							variants_base = universalDefaultMapRoot.variants_base;
							num = -1463813287;
						}
						else
						{
							num = -1463813295;
						}
						continue;
					default:
						{
							return null;
						}
						IL_006f:
						num2++;
						num = -1463813289;
						continue;
					}
					break;
				}
			}
		}

		private T GetUniversalDefaultMapRoot<T>(Type type, out InputPlatform actualInputPlatform) where T : Platform
		{
			if (object.ReferenceEquals(type, typeof(Platform_Fallback_Base)))
			{
				actualInputPlatform = InputPlatform.EyNWaUwBjrKkvnlxbfIvCGetaIFY;
				return fallback_Windows as T;
			}
			if (object.ReferenceEquals(type, typeof(Platform_SDL2_Base)))
			{
				actualInputPlatform = InputPlatform.oDiIcinIBGOOyqKvDBdnWsbZGMv;
				return sdl2_Windows as T;
			}
			throw new NotImplementedException();
		}

		private Platform GetSpecificPlatformMap(HardwareControllerMapIdentifier hardwareMapIdentifier)
		{
			return GetSpecificPlatformRoot(hardwareMapIdentifier.actualInputPlatform)?.GetPlatformMap(hardwareMapIdentifier.variantIndex);
		}

		private Platform GetSpecificPlatformRoot(InputPlatform exactInputPlatform)
		{
			switch (exactInputPlatform)
			{
			default:
				while (true)
				{
					int num = 1368610297;
					while (true)
					{
						switch (num ^ 0x519355FA)
						{
						case 2:
							break;
						case 5:
							goto end_IL_00b4;
						case 0:
							goto IL_011c;
						case 3:
							num = 1368610299;
							continue;
						case 4:
							goto IL_01f3;
						case 6:
							goto IL_020a;
						default:
							goto end_IL_0003;
						}
						break;
					}
					continue;
					end_IL_00b4:
					break;
				}
				goto case InputPlatform.mvnXduzIcJqcHpJHCcDjxXAwuzv;
			case InputPlatform.mvnXduzIcJqcHpJHCcDjxXAwuzv:
				return webGL;
			case InputPlatform.RZICaWagIuKgaolDMOOypgwWFMH:
				return ouya;
			case InputPlatform.QAbfXJnvPJiIZJfOVOFDonsOFob:
				return xboxOne;
			case InputPlatform.AkZZquMxhXIVvnmCRwxaVZYYTek:
				return gameCore;
			case InputPlatform.HglRpaPpklgbSOuqnDvBSmwGtUX:
				return ps4;
			case InputPlatform.svmFLfAwcmvduLqYnidKumuhopX:
				return ps5;
			case InputPlatform.nWmlkIpvopTHEIQiYbcEoLWzsmD:
				throw new NotImplementedException();
			case InputPlatform.nxzcJmevYVMAWQJHQoCKKweYMfMv:
				goto IL_011c;
			case InputPlatform.TxthorEPmOLBHYyZxIReALnmNeM:
				return rawInput;
			case InputPlatform.ZrSavanyxdsgnhdTbscQkWtEAzy:
				return xInput;
			case InputPlatform.EyNWaUwBjrKkvnlxbfIvCGetaIFY:
				return fallback_Windows;
			case InputPlatform.YRqjNMGyPIGPClpJpmPGREvRRcG:
				return windowsUWP;
			case InputPlatform.sEjjrezmdTWEmzaCLMCrIvBsKtv:
				return fallback_WindowsUWP;
			case InputPlatform.PFLTzcYFaBOghAebEsCXymESHdk:
				return osx;
			case InputPlatform.MUAhruUHigYSGBDKEDFejoaAIKbu:
				return fallback_OSX;
			case InputPlatform.LpFemRBnLvpZJDqbCUqPHDmhIPES:
				return linux;
			case InputPlatform.ZsaDxCopXVftxhaUhaeehEFdpYT:
				return fallback_Linux;
			case InputPlatform.ihHkUizAxnFTofebgOcNeIKdjDdD:
				return fallback_Linux_PreConfigured;
			case InputPlatform.ArpgvXxCfOlVSvkIJEIwRKgOTcG:
				return fallback_Android;
			case InputPlatform.weyUTntvYvSMCYMOQToKrFyLWLT:
				return fallback_AmazonFireTV;
			case InputPlatform.JdIptPBVWljvyIXqApempcOWYPa:
				return fallback_RazerForgeTV;
			case InputPlatform.owpHBIMXRSAHRIGaFHvWdFAQwYa:
				return fallback_iOS;
			case InputPlatform.rypEUYaHNuXFnaKpDREuGUThbUgF:
				return fallback_WindowsPhone8;
			case InputPlatform.ePYPwNnorHLXgaZGXMLQtvarFfn:
				return fallback_Blackberry;
			case InputPlatform.YzmOpGLKJXakWuQxDJNYoikTWXV:
				return fallback_PS3;
			case InputPlatform.VVULNUzeBDKyeIXYqiPFHOiKRFQ:
				return fallback_PS4;
			case InputPlatform.spryPJJRZoNXpNHWwjQrYqqOcQaE:
				return fallback_PSM;
			case InputPlatform.OIhUrHBapNKofzWuGXdbWpfEYqL:
				return fallback_PSVita;
			case InputPlatform.uvinkbnCOUhiBIQPTivyCtHAuXUk:
				return fallback_XBox360;
			case InputPlatform.BfEQfLyOjlOdysiRbIaosBjRLpg:
				return fallback_XBoxOne;
			case InputPlatform.UNTAzLDwrIRHwWirSuYtaEQeELys:
				return fallback_Wii;
			case InputPlatform.AUxRFgGXRnMmNDDYccYLHOChnqyL:
				return fallback_WiiU;
			case InputPlatform.SzWkkyLAdSLqShzUrBqqoRHKOhW:
				return nintendoSwitch;
			case InputPlatform.tDSEXVttzObSTRvKkzvQqSrZkMJ:
				return stadia;
			case InputPlatform.IOPdHWmrObUEwmObrCgWvfxfehz:
				throw new NotImplementedException();
			case InputPlatform.ZttKGDSUEbTObEfblEyIYTXbRoc:
				goto IL_01f3;
			case InputPlatform.hzbbqXbtQbxKAebJVOPUbWKsXBI:
				throw new NotImplementedException();
			case InputPlatform.oDiIcinIBGOOyqKvDBdnWsbZGMv:
				goto IL_020a;
			case InputPlatform.PWHiXxDBzketsYwZBiVoACMtEdP:
				return sdl2_OSX;
			case InputPlatform.ZlXwEiQKEmyTNTNLkgHhdkHiqKF:
				return sdl2_Linux;
			case InputPlatform.mWddvsAGGdWECRlxCOhehpBItyh:
			case InputPlatform.wHPBYVcSPaWTXCAyolOVCijkbqIm:
				throw new NotImplementedException();
			case InputPlatform.AftxmphNLUuHCDzhgsurtHDpiKs:
				break;
				IL_020a:
				return sdl2_Windows;
				IL_01f3:
				return internalDriver;
				IL_011c:
				return directInput;
				end_IL_0003:
				break;
			}
			throw new NotImplementedException();
		}
	}
}
