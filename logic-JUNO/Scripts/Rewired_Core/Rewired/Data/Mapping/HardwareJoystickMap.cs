using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
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
			private sealed class dUtWxNjzvWAsgvRGsqPcrWBHgepb : IEnumerable<Platform>, IEnumerable, IEnumerator<Platform>, IEnumerator, IDisposable
			{
				private int FrapAEePKDLjtiXBAjfHcRjGzLIe;

				private Platform FIpeazGTlucDVOBYFIedxsRBFbjAb;

				private int BTcPqMQEllNhcHseljtiCIwNfEWSA;

				public Platform NazUSSVHEIBiygvXOstbndeDQXqR;

				private IList<Platform> moEEHuvlvgBfrrAQNItVmQhUJrvg;

				private int aFRintoZbOiVWuCEHnUsnHYFfbKkA;

				Platform IEnumerator<Platform>.Current
				{
					[DebuggerHidden]
					get
					{
						return FIpeazGTlucDVOBYFIedxsRBFbjAb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return FIpeazGTlucDVOBYFIedxsRBFbjAb;
					}
				}

				[DebuggerHidden]
				public dUtWxNjzvWAsgvRGsqPcrWBHgepb(int P_0)
				{
					FrapAEePKDLjtiXBAjfHcRjGzLIe = P_0;
					BTcPqMQEllNhcHseljtiCIwNfEWSA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int frapAEePKDLjtiXBAjfHcRjGzLIe = FrapAEePKDLjtiXBAjfHcRjGzLIe;
					Platform nazUSSVHEIBiygvXOstbndeDQXqR = NazUSSVHEIBiygvXOstbndeDQXqR;
					if (frapAEePKDLjtiXBAjfHcRjGzLIe != 0)
					{
						if (frapAEePKDLjtiXBAjfHcRjGzLIe != 1)
						{
							return false;
						}
						FrapAEePKDLjtiXBAjfHcRjGzLIe = -1;
						goto IL_0077;
					}
					FrapAEePKDLjtiXBAjfHcRjGzLIe = -1;
					moEEHuvlvgBfrrAQNItVmQhUJrvg = nazUSSVHEIBiygvXOstbndeDQXqR.variants_base;
					if (moEEHuvlvgBfrrAQNItVmQhUJrvg == null)
					{
						return false;
					}
					aFRintoZbOiVWuCEHnUsnHYFfbKkA = 0;
					goto IL_0087;
					IL_0087:
					if (aFRintoZbOiVWuCEHnUsnHYFfbKkA < moEEHuvlvgBfrrAQNItVmQhUJrvg.Count)
					{
						if (moEEHuvlvgBfrrAQNItVmQhUJrvg[aFRintoZbOiVWuCEHnUsnHYFfbKkA] != null)
						{
							FIpeazGTlucDVOBYFIedxsRBFbjAb = moEEHuvlvgBfrrAQNItVmQhUJrvg[aFRintoZbOiVWuCEHnUsnHYFfbKkA];
							FrapAEePKDLjtiXBAjfHcRjGzLIe = 1;
							return true;
						}
						goto IL_0077;
					}
					return false;
					IL_0077:
					aFRintoZbOiVWuCEHnUsnHYFfbKkA++;
					goto IL_0087;
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

				[DebuggerHidden]
				IEnumerator<Platform> IEnumerable<Platform>.GetEnumerator()
				{
					dUtWxNjzvWAsgvRGsqPcrWBHgepb dUtWxNjzvWAsgvRGsqPcrWBHgepb2;
					if (FrapAEePKDLjtiXBAjfHcRjGzLIe == -2 && BTcPqMQEllNhcHseljtiCIwNfEWSA == Environment.CurrentManagedThreadId)
					{
						FrapAEePKDLjtiXBAjfHcRjGzLIe = 0;
						dUtWxNjzvWAsgvRGsqPcrWBHgepb2 = this;
					}
					else
					{
						dUtWxNjzvWAsgvRGsqPcrWBHgepb2 = new dUtWxNjzvWAsgvRGsqPcrWBHgepb(0);
						dUtWxNjzvWAsgvRGsqPcrWBHgepb2.NazUSSVHEIBiygvXOstbndeDQXqR = NazUSSVHEIBiygvXOstbndeDQXqR;
					}
					return dUtWxNjzvWAsgvRGsqPcrWBHgepb2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform>)this).GetEnumerator();
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
				[IteratorStateMachine(typeof(dUtWxNjzvWAsgvRGsqPcrWBHgepb))]
				get
				{
					return new dUtWxNjzvWAsgvRGsqPcrWBHgepb(-2)
					{
						NazUSSVHEIBiygvXOstbndeDQXqR = this
					};
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
				if (isAllowed && hasData)
				{
					variantIndex = -1;
					return this;
				}
				IList<Platform> list = variants_base;
				if (list != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						Platform platform = list[i];
						if (platform != null && platform.isAllowed && platform.hasData)
						{
							variantIndex = i;
							return platform;
						}
					}
				}
				return null;
			}

			internal int IndexOfElementIdentifier(ControllerElementIdentifier[] elementIdentifiers, int id)
			{
				if (elementIdentifiers == null)
				{
					return -1;
				}
				for (int i = 0; i < elementIdentifiers.Length; i++)
				{
					if (elementIdentifiers[i].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid == id)
					{
						return i;
					}
				}
				return -1;
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
				}
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = new HardwareJoystickMap_InputManager(new HardwareControllerMapIdentifier(hardwareJoystickMap.Guid, inputSource, actualInputPlatform, variantIndex), hardwareJoystickMap.joystickTypes, platform, controllerName, platform.assignedButtonCount, platform.assignedAxisCount, hardwareJoystickMap.elementIdentifiers.Length, hardwareJoystickMap.compoundElements);
				ControllerElementIdentifier[] elementIdentifiers = hardwareJoystickMap.elementIdentifiers;
				int elementIdentifierCount = hardwareJoystickMap.elementIdentifierCount;
				for (int i = 0; i < elementIdentifierCount; i++)
				{
					hardwareJoystickMap_InputManager.elementIdentifiers[i] = new ControllerElementIdentifier(elementIdentifiers[i], hardwareJoystickMap_InputManager.map.IsElementIdentifierMapped(elementIdentifiers[i].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid), hardwareJoystickMap_InputManager.map.GetEffectiveElementIdentifierType(elementIdentifiers[i]));
				}
				if (inputSource == InputSource.PS4 && (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyDualShock4 || hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4AimController))
				{
					for (int j = 0; j < elementIdentifierCount; j++)
					{
						switch (elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
						case 0:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "left stick x";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "left stick right";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName = "left stick left";
							break;
						case 1:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "left stick y";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "left stick up";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName = "left stick down";
							break;
						case 2:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "right stick x";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "right stick right";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName = "right stick left";
							break;
						case 3:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "right stick y";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "right stick up";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName = "right stick down";
							break;
						case 4:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "L2 button";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "L2 button";
							break;
						case 5:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "R2 button";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "R2 button";
							break;
						case 6:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "cross button";
							break;
						case 7:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "circle button";
							break;
						case 8:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "square button";
							break;
						case 9:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "triangle button";
							break;
						case 10:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "L1 button";
							break;
						case 11:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "R1 button";
							break;
						case 12:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "SHARE button";
							break;
						case 13:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "OPTIONS button";
							break;
						case 14:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "PS button";
							break;
						case 15:
							if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4AimController)
							{
								hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "pad button";
							}
							else
							{
								hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "touch pad button";
							}
							break;
						case 16:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "L3 button";
							break;
						case 17:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "R3 button";
							break;
						case 18:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "up button";
							break;
						case 19:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "right button";
							break;
						case 20:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "down button";
							break;
						case 21:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "left button";
							break;
						}
					}
				}
				if (inputSource == InputSource.PS5)
				{
					if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyDualSense)
					{
						for (int k = 0; k < elementIdentifierCount; k++)
						{
							switch (elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
							{
							case 0:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "left stick x";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "left stick right";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName = "left stick left";
								break;
							case 1:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "left stick y";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "left stick up";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName = "left stick down";
								break;
							case 2:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "right stick x";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "right stick right";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName = "right stick left";
								break;
							case 3:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "right stick y";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "right stick up";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName = "right stick down";
								break;
							case 4:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "L2 button";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "L2 button";
								break;
							case 5:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "R2 button";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "R2 button";
								break;
							case 6:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "cross button";
								break;
							case 7:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "circle button";
								break;
							case 8:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "square button";
								break;
							case 9:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "triangle button";
								break;
							case 10:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "L1 button";
								break;
							case 11:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "R1 button";
								break;
							case 12:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "create button";
								break;
							case 13:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "options button";
								break;
							case 14:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "PS button";
								break;
							case 15:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "touch pad button";
								break;
							case 16:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "L3 button";
								break;
							case 17:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "R3 button";
								break;
							case 18:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "up button";
								break;
							case 19:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "right button";
								break;
							case 20:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "down button";
								break;
							case 21:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "left button";
								break;
							}
						}
					}
					else if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4Drums || hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4Guitar || hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4SteeringWheel)
					{
						for (int l = 0; l < elementIdentifierCount; l++)
						{
							switch (elementIdentifiers[l].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
							{
							case 19:
								hardwareJoystickMap_InputManager.elementIdentifiers[l].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "create button";
								break;
							case 20:
								hardwareJoystickMap_InputManager.elementIdentifiers[l].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "options button";
								break;
							}
						}
					}
					else if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4FlightStick)
					{
						for (int m = 0; m < elementIdentifierCount; m++)
						{
							switch (elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
							{
							case 21:
								hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "create button";
								break;
							case 22:
								hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "options button";
								break;
							}
						}
					}
				}
				for (int n = 0; n < elementIdentifierCount; n++)
				{
					if (hardwareJoystickMap_InputManager.elementIdentifiers[n].elementType == ControllerElementType.Axis)
					{
						if (string.IsNullOrEmpty(hardwareJoystickMap_InputManager.elementIdentifiers[n].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName))
						{
							hardwareJoystickMap_InputManager.elementIdentifiers[n].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = hardwareJoystickMap_InputManager.elementIdentifiers[n].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " +";
						}
						if (string.IsNullOrEmpty(hardwareJoystickMap_InputManager.elementIdentifiers[n].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName))
						{
							hardwareJoystickMap_InputManager.elementIdentifiers[n].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName = hardwareJoystickMap_InputManager.elementIdentifiers[n].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " -";
						}
					}
				}
				return hardwareJoystickMap_InputManager;
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
					eVNCcajJzZqMRDvslhBhZyxbIPSSA(elementCount_Base);
					return elementCount_Base;
				}

				object IDeepCloneable.DeepClone()
				{
					//ILSpy generated this explicit interface implementation from .override directive in DeepClone
					return this.DeepClone();
				}

				internal virtual void eVNCcajJzZqMRDvslhBhZyxbIPSSA(ElementCount_Base P_0)
				{
					if (P_0 != null)
					{
						P_0.axisCount = axisCount;
						P_0.buttonCount = buttonCount;
					}
				}

				internal virtual bool NrIqjnTqXRldcAeRNYVJmqWNDsiO(BridgedControllerHWInfo P_0)
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
				for (int i = 0; i < num; i++)
				{
					ElementCount_Base elementCount_Base = GetAlternateElementCount(i);
					if (elementCount_Base != null && elementCount_Base.NrIqjnTqXRldcAeRNYVJmqWNDsiO(bridgedControllerHWInfo))
					{
						alternateMatched = true;
						return true;
					}
				}
				if (axisCount < 0 || axisCount == bridgedControllerHWInfo.hardwareAxisCount)
				{
					if (buttonCount >= 0)
					{
						return buttonCount == bridgedControllerHWInfo.hardwareButtonCount;
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
				}
				if (searchFor == null)
				{
					searchFor = string.Empty;
				}
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
				if (componentElementIdentifiers == null)
				{
					componentElementIdentifiers = new int[0];
				}
			}

			public CompoundElement(CompoundElement P_0)
			{
				ImportVars(P_0);
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

			object IDeepCloneable.DeepClone()
			{
				//ILSpy generated this explicit interface implementation from .override directive in DeepClone
				return this.DeepClone();
			}

			protected virtual void ImportVars(CompoundElement source)
			{
				type = source.type;
				elementIdentifier = source.elementIdentifier;
				componentElementIdentifiers = ArrayTools.ShallowCopy(source.componentElementIdentifiers);
			}

			internal static void SortHatElementsClockwise(CompoundElement element)
			{
				if (element != null && element.type == CompoundControllerElementType.Hat && element.componentElementIdentifiers != null && element.componentElementIdentifiers.Length == 8)
				{
					int[] array = new int[8]
					{
						element.componentElementIdentifiers[0],
						element.componentElementIdentifiers[4],
						element.componentElementIdentifiers[1],
						element.componentElementIdentifiers[5],
						element.componentElementIdentifiers[2],
						element.componentElementIdentifiers[6],
						element.componentElementIdentifiers[3],
						element.componentElementIdentifiers[7]
					};
					Array.Copy(array, element.componentElementIdentifiers, array.Length);
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

			public AxisCalibrationInfoEntry(AxisCalibrationInfoEntry P_0)
			{
				ImportVars(P_0);
			}

			public virtual object DeepClone()
			{
				return new AxisCalibrationInfoEntry(this);
			}

			object IDeepCloneable.DeepClone()
			{
				//ILSpy generated this explicit interface implementation from .override directive in DeepClone
				return this.DeepClone();
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
				foreach (AxisCalibrationInfoEntry axisCalibrationInfoEntry in calibrations)
				{
					if (axisCalibrationInfoEntry != null && axisCalibrationInfoEntry.calibration != null && Enum.IsDefined(typeof(AlternateAxisCalibrationType), axisCalibrationInfoEntry.key))
					{
						if (dictionary.ContainsKey((int)axisCalibrationInfoEntry.key))
						{
							Logger.LogError("A duplicate key was found in AxisCalibrationInfoEntry array in HardwareJoystickMap. Skipping.");
						}
						else if (deepClone)
						{
							dictionary.Add((int)axisCalibrationInfoEntry.key, (AxisCalibrationInfo)axisCalibrationInfoEntry.calibration.DeepClone());
						}
						else
						{
							dictionary.Add((int)axisCalibrationInfoEntry.key, axisCalibrationInfoEntry.calibration);
						}
					}
				}
				return dictionary;
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
						eVNCcajJzZqMRDvslhBhZyxbIPSSA(elementCount);
						return elementCount;
					}

					internal void kHckUUGdnJMmRbuFBtsDFyRMRuNb(ElementCount_Base P_0)
					{
						base.eVNCcajJzZqMRDvslhBhZyxbIPSSA(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool TtCfmEGTLtdHrjGiMhGsaPxEJwLiB(BridgedControllerHWInfo P_0)
					{
						if (!base.NrIqjnTqXRldcAeRNYVJmqWNDsiO(P_0))
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

				bool MatchingCriteria_Base.hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (productGUID != null && productGUID.Length != 0)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool MatchingCriteria_Base.isAllowed
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

				int MatchingCriteria_Base.alternateElementCount
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
							return ProductNameMatches(bridgedControllerHWInfo);
						}
						if (!ProductNameMatches(bridgedControllerHWInfo))
						{
							return false;
						}
						return true;
					}
					return ProductNameMatches(bridgedControllerHWInfo);
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
					if (controller.hw_isBluetoothDevice && !string.IsNullOrEmpty(controller.hw_bluetoothDeviceName))
					{
						if (ProductNameMatches(controller.hw_productName) || ProductNameMatches(controller.hw_bluetoothDeviceName))
						{
							return true;
						}
						return false;
					}
					return ProductNameMatches(controller.hw_productName);
				}

				private bool ProductNameMatches(string name)
				{
					if (string.IsNullOrEmpty(name) || productName == null)
					{
						return false;
					}
					string searchIn = name.Trim();
					for (int i = 0; i < productName.Length; i++)
					{
						if (productName[i] != null && !(productName[i] == string.Empty) && MatchingCriteria_Base.StringMatches(searchIn, productName[i], productName_useRegex))
						{
							return true;
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
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.hatCount = hatCount;
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
						matchingCriteria.productId = ArrayTools.ShallowCopy(productId);
						matchingCriteria.deviceType = deviceType;
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
					return new CustomCalculationSourceData
					{
						sourceType = sourceType,
						sourceAxis = sourceAxis,
						sourceButton = sourceButton,
						sourceOtherAxis = sourceOtherAxis,
						sourceAxisRange = sourceAxisRange,
						axisDeadZone = axisDeadZone,
						invert = invert,
						axisCalibrationType = axisCalibrationType,
						axisZero = axisZero,
						axisMin = axisMin,
						axisMax = axisMax
					};
				}

				object IDeepCloneable.DeepClone()
				{
					//ILSpy generated this explicit interface implementation from .override directive in DeepClone
					return this.DeepClone();
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
					sourceType = source.sourceType;
					sourceButton = source.sourceButton;
					sourceAxis = source.sourceAxis;
					sourceAxisPole = source.sourceAxisPole;
					axisDeadZone = source.axisDeadZone;
					sourceHat = source.sourceHat;
					sourceHatType = source.sourceHatType;
					sourceHatDirection = source.sourceHatDirection;
					requireMultipleButtons = source.requireMultipleButtons;
					requiredButtons = ArrayTools.ShallowCopy(source.requiredButtons);
					ignoreIfButtonsActive = source.ignoreIfButtonsActive;
					ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(source.ignoreIfButtonsActiveButtons);
					buttonInfo = MiscTools.DeepClone(source.buttonInfo);
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
					sourceAxisRange = source.sourceAxisRange;
					invert = source.invert;
					axisDeadZone = source.axisDeadZone;
					calibrateAxis = source.calibrateAxis;
					axisZero = source.axisZero;
					axisMin = source.axisMin;
					axisMax = source.axisMax;
					axisInfo = MiscTools.DeepClone(source.axisInfo);
					sourceButton = source.sourceButton;
					buttonAxisContribution = source.buttonAxisContribution;
					sourceHat = source.sourceHat;
					sourceHatDirection = source.sourceHatDirection;
					sourceHatRange = source.sourceHatRange;
					alternateCalibrations = MiscTools.DeepClone(source.alternateCalibrations);
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

			bool Platform.hasData
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

			bool Platform.disabled
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

			bool Platform.isAllowed
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
				private sealed class iINZZsytbKdPVbVNtJHQzuwykAKt : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int pJunGHroxoOuHhgUJEPGUbvqlRDU;

					private Axis_Base JnnKEJIjGiTkfOuUuifNKJFwSXKh;

					private int DAwVkxprTpnrhSyhungoGSvdtnSq;

					public Elements tHmelDEXhjKSHfigqUKqJOEgKhkXA;

					private int QkUmFphoySmOaaCKtWZqZSkQyarK;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return JnnKEJIjGiTkfOuUuifNKJFwSXKh;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return JnnKEJIjGiTkfOuUuifNKJFwSXKh;
						}
					}

					[DebuggerHidden]
					public iINZZsytbKdPVbVNtJHQzuwykAKt(int P_0)
					{
						pJunGHroxoOuHhgUJEPGUbvqlRDU = P_0;
						DAwVkxprTpnrhSyhungoGSvdtnSq = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = pJunGHroxoOuHhgUJEPGUbvqlRDU;
						Elements elements = tHmelDEXhjKSHfigqUKqJOEgKhkXA;
						switch (num)
						{
						default:
							return false;
						case 0:
							pJunGHroxoOuHhgUJEPGUbvqlRDU = -1;
							if (elements.axes == null)
							{
								return false;
							}
							QkUmFphoySmOaaCKtWZqZSkQyarK = 0;
							break;
						case 1:
							pJunGHroxoOuHhgUJEPGUbvqlRDU = -1;
							QkUmFphoySmOaaCKtWZqZSkQyarK++;
							break;
						}
						if (QkUmFphoySmOaaCKtWZqZSkQyarK < elements.axes.Length)
						{
							JnnKEJIjGiTkfOuUuifNKJFwSXKh = elements.axes[QkUmFphoySmOaaCKtWZqZSkQyarK];
							pJunGHroxoOuHhgUJEPGUbvqlRDU = 1;
							return true;
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

					[DebuggerHidden]
					IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
					{
						iINZZsytbKdPVbVNtJHQzuwykAKt iINZZsytbKdPVbVNtJHQzuwykAKt2;
						if (pJunGHroxoOuHhgUJEPGUbvqlRDU == -2 && DAwVkxprTpnrhSyhungoGSvdtnSq == Environment.CurrentManagedThreadId)
						{
							pJunGHroxoOuHhgUJEPGUbvqlRDU = 0;
							iINZZsytbKdPVbVNtJHQzuwykAKt2 = this;
						}
						else
						{
							iINZZsytbKdPVbVNtJHQzuwykAKt2 = new iINZZsytbKdPVbVNtJHQzuwykAKt(0);
							iINZZsytbKdPVbVNtJHQzuwykAKt2.tHmelDEXhjKSHfigqUKqJOEgKhkXA = tHmelDEXhjKSHfigqUKqJOEgKhkXA;
						}
						return iINZZsytbKdPVbVNtJHQzuwykAKt2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}
				}

				private sealed class znhJbLqEScBUcgQZdKyKQmuUwpvi : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int zByvVuFriauIaEySnMYcONrpACik;

					private Button_Base NOyCBFgcsqZTEIxSTIEPIEndATCDb;

					private int ZBQShoWxAGAHArgnAAhORzfJILTt;

					public Elements veiREtVbWMXURKiQeCarENMqvtFl;

					private int TncqiYWDTXYVqlIywbYjdHOjvdIs;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return NOyCBFgcsqZTEIxSTIEPIEndATCDb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return NOyCBFgcsqZTEIxSTIEPIEndATCDb;
						}
					}

					[DebuggerHidden]
					public znhJbLqEScBUcgQZdKyKQmuUwpvi(int P_0)
					{
						zByvVuFriauIaEySnMYcONrpACik = P_0;
						ZBQShoWxAGAHArgnAAhORzfJILTt = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = zByvVuFriauIaEySnMYcONrpACik;
						Elements elements = veiREtVbWMXURKiQeCarENMqvtFl;
						switch (num)
						{
						default:
							return false;
						case 0:
							zByvVuFriauIaEySnMYcONrpACik = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							TncqiYWDTXYVqlIywbYjdHOjvdIs = 0;
							break;
						case 1:
							zByvVuFriauIaEySnMYcONrpACik = -1;
							TncqiYWDTXYVqlIywbYjdHOjvdIs++;
							break;
						}
						if (TncqiYWDTXYVqlIywbYjdHOjvdIs < elements.buttons.Length)
						{
							NOyCBFgcsqZTEIxSTIEPIEndATCDb = elements.buttons[TncqiYWDTXYVqlIywbYjdHOjvdIs];
							zByvVuFriauIaEySnMYcONrpACik = 1;
							return true;
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

					[DebuggerHidden]
					IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
					{
						znhJbLqEScBUcgQZdKyKQmuUwpvi znhJbLqEScBUcgQZdKyKQmuUwpvi2;
						if (zByvVuFriauIaEySnMYcONrpACik == -2 && ZBQShoWxAGAHArgnAAhORzfJILTt == Environment.CurrentManagedThreadId)
						{
							zByvVuFriauIaEySnMYcONrpACik = 0;
							znhJbLqEScBUcgQZdKyKQmuUwpvi2 = this;
						}
						else
						{
							znhJbLqEScBUcgQZdKyKQmuUwpvi2 = new znhJbLqEScBUcgQZdKyKQmuUwpvi(0);
							znhJbLqEScBUcgQZdKyKQmuUwpvi2.veiREtVbWMXURKiQeCarENMqvtFl = veiREtVbWMXURKiQeCarENMqvtFl;
						}
						return znhJbLqEScBUcgQZdKyKQmuUwpvi2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button_Base>)this).GetEnumerator();
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
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

				int Elements_Base.axisCount
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

				IEnumerable<Axis_Base> Elements_Platform_Base.Axes
				{
					[IteratorStateMachine(typeof(iINZZsytbKdPVbVNtJHQzuwykAKt))]
					get
					{
						return new iINZZsytbKdPVbVNtJHQzuwykAKt(-2)
						{
							tHmelDEXhjKSHfigqUKqJOEgKhkXA = this
						};
					}
				}

				IEnumerable<Button_Base> Elements_Platform_Base.Buttons
				{
					[IteratorStateMachine(typeof(znhJbLqEScBUcgQZdKyKQmuUwpvi))]
					get
					{
						return new znhJbLqEScBUcgQZdKyKQmuUwpvi(-2)
						{
							veiREtVbWMXURKiQeCarENMqvtFl = this
						};
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Axis:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case HardwareElementSourceTypeWithHat.Button:
							axisRange = AxisRange.Positive;
							return true;
						case HardwareElementSourceTypeWithHat.Hat:
							axisRange = axes[i].sourceHatRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						default:
							throw new NotImplementedException();
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
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
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

			private sealed class rCzsNdlZOoRiWwceiwQKuRlZWLgJ : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int AGnhOsPPvKkIbUvHnTaMuPGqlQHe;

				private Axis_Base ExiuCyKNGnroxtrbHvZMhaEAoYMs;

				private int vTaIImMJdqITGFdqhqjlknvQIlShA;

				public Platform_DirectInput_Base xKSciJsJlVZdPzODOJPlSKWXvnzW;

				private int jYrzDUrrldOehAzVJJUDnCVfzaam;

				private int VXPbwgfkfdijjTLMLtmAVUzGXXrH;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return ExiuCyKNGnroxtrbHvZMhaEAoYMs;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ExiuCyKNGnroxtrbHvZMhaEAoYMs;
					}
				}

				[DebuggerHidden]
				public rCzsNdlZOoRiWwceiwQKuRlZWLgJ(int P_0)
				{
					AGnhOsPPvKkIbUvHnTaMuPGqlQHe = P_0;
					vTaIImMJdqITGFdqhqjlknvQIlShA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int aGnhOsPPvKkIbUvHnTaMuPGqlQHe = AGnhOsPPvKkIbUvHnTaMuPGqlQHe;
					Platform_DirectInput_Base platform_DirectInput_Base = xKSciJsJlVZdPzODOJPlSKWXvnzW;
					switch (aGnhOsPPvKkIbUvHnTaMuPGqlQHe)
					{
					default:
						return false;
					case 0:
						AGnhOsPPvKkIbUvHnTaMuPGqlQHe = -1;
						if (platform_DirectInput_Base.elements == null || platform_DirectInput_Base.elements.axes == null)
						{
							return false;
						}
						jYrzDUrrldOehAzVJJUDnCVfzaam = platform_DirectInput_Base.elements.axes.Length;
						VXPbwgfkfdijjTLMLtmAVUzGXXrH = 0;
						break;
					case 1:
						AGnhOsPPvKkIbUvHnTaMuPGqlQHe = -1;
						VXPbwgfkfdijjTLMLtmAVUzGXXrH++;
						break;
					}
					if (VXPbwgfkfdijjTLMLtmAVUzGXXrH < jYrzDUrrldOehAzVJJUDnCVfzaam)
					{
						ExiuCyKNGnroxtrbHvZMhaEAoYMs = platform_DirectInput_Base.elements.axes[VXPbwgfkfdijjTLMLtmAVUzGXXrH];
						AGnhOsPPvKkIbUvHnTaMuPGqlQHe = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
				{
					rCzsNdlZOoRiWwceiwQKuRlZWLgJ rCzsNdlZOoRiWwceiwQKuRlZWLgJ2;
					if (AGnhOsPPvKkIbUvHnTaMuPGqlQHe == -2 && vTaIImMJdqITGFdqhqjlknvQIlShA == Environment.CurrentManagedThreadId)
					{
						AGnhOsPPvKkIbUvHnTaMuPGqlQHe = 0;
						rCzsNdlZOoRiWwceiwQKuRlZWLgJ2 = this;
					}
					else
					{
						rCzsNdlZOoRiWwceiwQKuRlZWLgJ2 = new rCzsNdlZOoRiWwceiwQKuRlZWLgJ(0);
						rCzsNdlZOoRiWwceiwQKuRlZWLgJ2.xKSciJsJlVZdPzODOJPlSKWXvnzW = xKSciJsJlVZdPzODOJPlSKWXvnzW;
					}
					return rCzsNdlZOoRiWwceiwQKuRlZWLgJ2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}
			}

			private sealed class PotbtmbWbIbvSCzURXuZSuefMWSF : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int wQbypLzZCTCPgWppcBMLFmhLAEFbb;

				private Button_Base ASiYOxfgOAfWMrakhaZGbXRZTZni;

				private int cEUiNLqWAFFbKKCucZdGcOcNOUGgA;

				public Platform_DirectInput_Base JfaqUtkBeRpFDjNzEDtnHkyQwkvLA;

				private int GDxtmMGqgdtRxGMLZTdTFmBpaioi;

				private int EtDVivfKWpFTDKZgSirZuaOYkYuz;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return ASiYOxfgOAfWMrakhaZGbXRZTZni;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ASiYOxfgOAfWMrakhaZGbXRZTZni;
					}
				}

				[DebuggerHidden]
				public PotbtmbWbIbvSCzURXuZSuefMWSF(int P_0)
				{
					wQbypLzZCTCPgWppcBMLFmhLAEFbb = P_0;
					cEUiNLqWAFFbKKCucZdGcOcNOUGgA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = wQbypLzZCTCPgWppcBMLFmhLAEFbb;
					Platform_DirectInput_Base jfaqUtkBeRpFDjNzEDtnHkyQwkvLA = JfaqUtkBeRpFDjNzEDtnHkyQwkvLA;
					switch (num)
					{
					default:
						return false;
					case 0:
						wQbypLzZCTCPgWppcBMLFmhLAEFbb = -1;
						if (jfaqUtkBeRpFDjNzEDtnHkyQwkvLA.elements == null || jfaqUtkBeRpFDjNzEDtnHkyQwkvLA.elements.buttons == null)
						{
							return false;
						}
						GDxtmMGqgdtRxGMLZTdTFmBpaioi = jfaqUtkBeRpFDjNzEDtnHkyQwkvLA.elements.buttons.Length;
						EtDVivfKWpFTDKZgSirZuaOYkYuz = 0;
						break;
					case 1:
						wQbypLzZCTCPgWppcBMLFmhLAEFbb = -1;
						EtDVivfKWpFTDKZgSirZuaOYkYuz++;
						break;
					}
					if (EtDVivfKWpFTDKZgSirZuaOYkYuz < GDxtmMGqgdtRxGMLZTdTFmBpaioi)
					{
						ASiYOxfgOAfWMrakhaZGbXRZTZni = jfaqUtkBeRpFDjNzEDtnHkyQwkvLA.elements.buttons[EtDVivfKWpFTDKZgSirZuaOYkYuz];
						wQbypLzZCTCPgWppcBMLFmhLAEFbb = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
				{
					PotbtmbWbIbvSCzURXuZSuefMWSF potbtmbWbIbvSCzURXuZSuefMWSF;
					if (wQbypLzZCTCPgWppcBMLFmhLAEFbb == -2 && cEUiNLqWAFFbKKCucZdGcOcNOUGgA == Environment.CurrentManagedThreadId)
					{
						wQbypLzZCTCPgWppcBMLFmhLAEFbb = 0;
						potbtmbWbIbvSCzURXuZSuefMWSF = this;
					}
					else
					{
						potbtmbWbIbvSCzURXuZSuefMWSF = new PotbtmbWbIbvSCzURXuZSuefMWSF(0);
						potbtmbWbIbvSCzURXuZSuefMWSF.JfaqUtkBeRpFDjNzEDtnHkyQwkvLA = JfaqUtkBeRpFDjNzEDtnHkyQwkvLA;
					}
					return potbtmbWbIbvSCzURXuZSuefMWSF;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button_Base>)this).GetEnumerator();
				}
			}

			public Elements elements;

			InputPlatform Platform.platform => InputPlatform.WindowsDirectInput;

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

			IList<Platform> Platform.variants_base => null;

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			Elements_Base Platform.elements_base => elements;

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
				for (int i = 0; i < num2; i++)
				{
					int elementIdentifier = elements.axes[i].elementIdentifier;
					int num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num3 < 0 || num3 >= num)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num3].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
					}
				}
				return array;
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
				for (int i = 0; i < buttonCount; i++)
				{
					int elementIdentifier = elements.buttons[i].elementIdentifier;
					int num2 = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num2 < 0 || num2 >= num)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num2].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
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
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
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
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
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

			[IteratorStateMachine(typeof(rCzsNdlZOoRiWwceiwQKuRlZWLgJ))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return new rCzsNdlZOoRiWwceiwQKuRlZWLgJ(-2)
				{
					xKSciJsJlVZdPzODOJPlSKWXvnzW = this
				};
			}

			[IteratorStateMachine(typeof(PotbtmbWbIbvSCzURXuZSuefMWSF))]
			internal override IEnumerable<Button_Base> IterateButtons()
			{
				return new PotbtmbWbIbvSCzURXuZSuefMWSF(-2)
				{
					JfaqUtkBeRpFDjNzEDtnHkyQwkvLA = this
				};
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
				if (destination is Platform_DirectInput_Base platform_DirectInput_Base)
				{
					platform_DirectInput_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_DirectInput : Platform_DirectInput_Base
		{
			public Platform_DirectInput_Base[] variants;

			IList<Platform> Platform_DirectInput_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
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
				if (destination is Platform_DirectInput platform_DirectInput)
				{
					platform_DirectInput.variants = MiscTools.DeepClone(variants);
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
				private sealed class FfSePSsickFpoeScQDxHcbPbZbti : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int wbxdrkknmoKYYoaaODxRYDLBwXps;

					private Axis_Base psZfZOzTDKEEvcHRvvTVnnRQmRzab;

					private int PGdklCafNXBHFklilOqOYObEEiSi;

					public Elements leFhusfFiVHMqHyexzzAeEuMVwJz;

					private int boDEfPOdqBvozKIAUdSWbwWrxYgIA;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return psZfZOzTDKEEvcHRvvTVnnRQmRzab;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return psZfZOzTDKEEvcHRvvTVnnRQmRzab;
						}
					}

					[DebuggerHidden]
					public FfSePSsickFpoeScQDxHcbPbZbti(int P_0)
					{
						wbxdrkknmoKYYoaaODxRYDLBwXps = P_0;
						PGdklCafNXBHFklilOqOYObEEiSi = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = wbxdrkknmoKYYoaaODxRYDLBwXps;
						Elements elements = leFhusfFiVHMqHyexzzAeEuMVwJz;
						switch (num)
						{
						default:
							return false;
						case 0:
							wbxdrkknmoKYYoaaODxRYDLBwXps = -1;
							if (elements.axes == null)
							{
								return false;
							}
							boDEfPOdqBvozKIAUdSWbwWrxYgIA = 0;
							break;
						case 1:
							wbxdrkknmoKYYoaaODxRYDLBwXps = -1;
							boDEfPOdqBvozKIAUdSWbwWrxYgIA++;
							break;
						}
						if (boDEfPOdqBvozKIAUdSWbwWrxYgIA < elements.axes.Length)
						{
							psZfZOzTDKEEvcHRvvTVnnRQmRzab = elements.axes[boDEfPOdqBvozKIAUdSWbwWrxYgIA];
							wbxdrkknmoKYYoaaODxRYDLBwXps = 1;
							return true;
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

					[DebuggerHidden]
					IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
					{
						FfSePSsickFpoeScQDxHcbPbZbti ffSePSsickFpoeScQDxHcbPbZbti;
						if (wbxdrkknmoKYYoaaODxRYDLBwXps == -2 && PGdklCafNXBHFklilOqOYObEEiSi == Environment.CurrentManagedThreadId)
						{
							wbxdrkknmoKYYoaaODxRYDLBwXps = 0;
							ffSePSsickFpoeScQDxHcbPbZbti = this;
						}
						else
						{
							ffSePSsickFpoeScQDxHcbPbZbti = new FfSePSsickFpoeScQDxHcbPbZbti(0);
							ffSePSsickFpoeScQDxHcbPbZbti.leFhusfFiVHMqHyexzzAeEuMVwJz = leFhusfFiVHMqHyexzzAeEuMVwJz;
						}
						return ffSePSsickFpoeScQDxHcbPbZbti;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}
				}

				private sealed class ghyrmdNuxbGFSZeMWDnZvLoWpoyE : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int pOofyzwVCvJSEIJrGTRJxCHzJbDO;

					private Button_Base NBerbpNIRHEHvcxhKgVEMIrfeVmu;

					private int SBcxpuXPmTDOJqKPJuoZDKnOgdej;

					public Elements YayzpNBDsXsZiOslGGDSBCJdBtJA;

					private int yADEOkkiSqRTDCfbbHyQTPUGYDJW;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return NBerbpNIRHEHvcxhKgVEMIrfeVmu;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return NBerbpNIRHEHvcxhKgVEMIrfeVmu;
						}
					}

					[DebuggerHidden]
					public ghyrmdNuxbGFSZeMWDnZvLoWpoyE(int P_0)
					{
						pOofyzwVCvJSEIJrGTRJxCHzJbDO = P_0;
						SBcxpuXPmTDOJqKPJuoZDKnOgdej = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = pOofyzwVCvJSEIJrGTRJxCHzJbDO;
						Elements yayzpNBDsXsZiOslGGDSBCJdBtJA = YayzpNBDsXsZiOslGGDSBCJdBtJA;
						switch (num)
						{
						default:
							return false;
						case 0:
							pOofyzwVCvJSEIJrGTRJxCHzJbDO = -1;
							if (yayzpNBDsXsZiOslGGDSBCJdBtJA.buttons == null)
							{
								return false;
							}
							yADEOkkiSqRTDCfbbHyQTPUGYDJW = 0;
							break;
						case 1:
							pOofyzwVCvJSEIJrGTRJxCHzJbDO = -1;
							yADEOkkiSqRTDCfbbHyQTPUGYDJW++;
							break;
						}
						if (yADEOkkiSqRTDCfbbHyQTPUGYDJW < yayzpNBDsXsZiOslGGDSBCJdBtJA.buttons.Length)
						{
							NBerbpNIRHEHvcxhKgVEMIrfeVmu = yayzpNBDsXsZiOslGGDSBCJdBtJA.buttons[yADEOkkiSqRTDCfbbHyQTPUGYDJW];
							pOofyzwVCvJSEIJrGTRJxCHzJbDO = 1;
							return true;
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

					[DebuggerHidden]
					IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
					{
						ghyrmdNuxbGFSZeMWDnZvLoWpoyE ghyrmdNuxbGFSZeMWDnZvLoWpoyE2;
						if (pOofyzwVCvJSEIJrGTRJxCHzJbDO == -2 && SBcxpuXPmTDOJqKPJuoZDKnOgdej == Environment.CurrentManagedThreadId)
						{
							pOofyzwVCvJSEIJrGTRJxCHzJbDO = 0;
							ghyrmdNuxbGFSZeMWDnZvLoWpoyE2 = this;
						}
						else
						{
							ghyrmdNuxbGFSZeMWDnZvLoWpoyE2 = new ghyrmdNuxbGFSZeMWDnZvLoWpoyE(0);
							ghyrmdNuxbGFSZeMWDnZvLoWpoyE2.YayzpNBDsXsZiOslGGDSBCJdBtJA = YayzpNBDsXsZiOslGGDSBCJdBtJA;
						}
						return ghyrmdNuxbGFSZeMWDnZvLoWpoyE2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button_Base>)this).GetEnumerator();
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
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

				int Elements_Base.axisCount
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

				IEnumerable<Axis_Base> Elements_Platform_Base.Axes
				{
					[IteratorStateMachine(typeof(FfSePSsickFpoeScQDxHcbPbZbti))]
					get
					{
						return new FfSePSsickFpoeScQDxHcbPbZbti(-2)
						{
							leFhusfFiVHMqHyexzzAeEuMVwJz = this
						};
					}
				}

				IEnumerable<Button_Base> Elements_Platform_Base.Buttons
				{
					[IteratorStateMachine(typeof(ghyrmdNuxbGFSZeMWDnZvLoWpoyE))]
					get
					{
						return new ghyrmdNuxbGFSZeMWDnZvLoWpoyE(-2)
						{
							YayzpNBDsXsZiOslGGDSBCJdBtJA = this
						};
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Axis:
						case HardwareElementSourceTypeWithHat.Custom:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case HardwareElementSourceTypeWithHat.Button:
							axisRange = AxisRange.Positive;
							return true;
						case HardwareElementSourceTypeWithHat.Hat:
							axisRange = axes[i].sourceHatRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						default:
							throw new NotImplementedException();
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
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
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

			private sealed class YWgdSuDUlxJmtSmPiGXOcmqITNvHc : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int cXnmFFGYaCePWqIIfsGKcCXOJipJ;

				private Axis_Base BMlgGEaObLskXfaFsSpZmmWzTZpJA;

				private int apXaZIhHlPgeFfvOxBdEXoxypdNLA;

				public Platform_RawInput_Base anTYfjOdMZFxoOmBJeiUgzndwyRf;

				private int mVpjDIFqwvhGGhfWqkMDsFpgyCve;

				private int GRBzyRijhugUvyiJoKlRewcNOvKL;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return BMlgGEaObLskXfaFsSpZmmWzTZpJA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return BMlgGEaObLskXfaFsSpZmmWzTZpJA;
					}
				}

				[DebuggerHidden]
				public YWgdSuDUlxJmtSmPiGXOcmqITNvHc(int P_0)
				{
					cXnmFFGYaCePWqIIfsGKcCXOJipJ = P_0;
					apXaZIhHlPgeFfvOxBdEXoxypdNLA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = cXnmFFGYaCePWqIIfsGKcCXOJipJ;
					Platform_RawInput_Base platform_RawInput_Base = anTYfjOdMZFxoOmBJeiUgzndwyRf;
					switch (num)
					{
					default:
						return false;
					case 0:
						cXnmFFGYaCePWqIIfsGKcCXOJipJ = -1;
						if (platform_RawInput_Base.elements == null || platform_RawInput_Base.elements.axes == null)
						{
							return false;
						}
						mVpjDIFqwvhGGhfWqkMDsFpgyCve = platform_RawInput_Base.elements.axes.Length;
						GRBzyRijhugUvyiJoKlRewcNOvKL = 0;
						break;
					case 1:
						cXnmFFGYaCePWqIIfsGKcCXOJipJ = -1;
						GRBzyRijhugUvyiJoKlRewcNOvKL++;
						break;
					}
					if (GRBzyRijhugUvyiJoKlRewcNOvKL < mVpjDIFqwvhGGhfWqkMDsFpgyCve)
					{
						BMlgGEaObLskXfaFsSpZmmWzTZpJA = platform_RawInput_Base.elements.axes[GRBzyRijhugUvyiJoKlRewcNOvKL];
						cXnmFFGYaCePWqIIfsGKcCXOJipJ = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
				{
					YWgdSuDUlxJmtSmPiGXOcmqITNvHc yWgdSuDUlxJmtSmPiGXOcmqITNvHc;
					if (cXnmFFGYaCePWqIIfsGKcCXOJipJ == -2 && apXaZIhHlPgeFfvOxBdEXoxypdNLA == Environment.CurrentManagedThreadId)
					{
						cXnmFFGYaCePWqIIfsGKcCXOJipJ = 0;
						yWgdSuDUlxJmtSmPiGXOcmqITNvHc = this;
					}
					else
					{
						yWgdSuDUlxJmtSmPiGXOcmqITNvHc = new YWgdSuDUlxJmtSmPiGXOcmqITNvHc(0);
						yWgdSuDUlxJmtSmPiGXOcmqITNvHc.anTYfjOdMZFxoOmBJeiUgzndwyRf = anTYfjOdMZFxoOmBJeiUgzndwyRf;
					}
					return yWgdSuDUlxJmtSmPiGXOcmqITNvHc;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}
			}

			private sealed class ikOOdhFuFjcyrFcjgCFbesYXbgVNA : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int tlDhoDeGQNJOomXtlSiQQEIbYhWgA;

				private Button_Base xmQBmsmCxhLEJuPXLOZjqXYoQPRv;

				private int kXUFIxGAHEDufpTKDqDOJEjiTZrc;

				public Platform_RawInput_Base mFjfYWiZfKLkvyLXmDjyoDuHVTIk;

				private int EmcrcQMuvwJCaDaXozOIPaudbBIi;

				private int LnwuVQTJbQchVIdysblvDYuRAAOab;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return xmQBmsmCxhLEJuPXLOZjqXYoQPRv;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return xmQBmsmCxhLEJuPXLOZjqXYoQPRv;
					}
				}

				[DebuggerHidden]
				public ikOOdhFuFjcyrFcjgCFbesYXbgVNA(int P_0)
				{
					tlDhoDeGQNJOomXtlSiQQEIbYhWgA = P_0;
					kXUFIxGAHEDufpTKDqDOJEjiTZrc = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = tlDhoDeGQNJOomXtlSiQQEIbYhWgA;
					Platform_RawInput_Base platform_RawInput_Base = mFjfYWiZfKLkvyLXmDjyoDuHVTIk;
					switch (num)
					{
					default:
						return false;
					case 0:
						tlDhoDeGQNJOomXtlSiQQEIbYhWgA = -1;
						if (platform_RawInput_Base.elements == null || platform_RawInput_Base.elements.buttons == null)
						{
							return false;
						}
						EmcrcQMuvwJCaDaXozOIPaudbBIi = platform_RawInput_Base.elements.buttons.Length;
						LnwuVQTJbQchVIdysblvDYuRAAOab = 0;
						break;
					case 1:
						tlDhoDeGQNJOomXtlSiQQEIbYhWgA = -1;
						LnwuVQTJbQchVIdysblvDYuRAAOab++;
						break;
					}
					if (LnwuVQTJbQchVIdysblvDYuRAAOab < EmcrcQMuvwJCaDaXozOIPaudbBIi)
					{
						xmQBmsmCxhLEJuPXLOZjqXYoQPRv = platform_RawInput_Base.elements.buttons[LnwuVQTJbQchVIdysblvDYuRAAOab];
						tlDhoDeGQNJOomXtlSiQQEIbYhWgA = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
				{
					ikOOdhFuFjcyrFcjgCFbesYXbgVNA ikOOdhFuFjcyrFcjgCFbesYXbgVNA2;
					if (tlDhoDeGQNJOomXtlSiQQEIbYhWgA == -2 && kXUFIxGAHEDufpTKDqDOJEjiTZrc == Environment.CurrentManagedThreadId)
					{
						tlDhoDeGQNJOomXtlSiQQEIbYhWgA = 0;
						ikOOdhFuFjcyrFcjgCFbesYXbgVNA2 = this;
					}
					else
					{
						ikOOdhFuFjcyrFcjgCFbesYXbgVNA2 = new ikOOdhFuFjcyrFcjgCFbesYXbgVNA(0);
						ikOOdhFuFjcyrFcjgCFbesYXbgVNA2.mFjfYWiZfKLkvyLXmDjyoDuHVTIk = mFjfYWiZfKLkvyLXmDjyoDuHVTIk;
					}
					return ikOOdhFuFjcyrFcjgCFbesYXbgVNA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button_Base>)this).GetEnumerator();
				}
			}

			public Elements elements;

			InputPlatform Platform.platform => InputPlatform.WindowsRawInput;

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

			IList<Platform> Platform.variants_base => null;

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			Elements_Base Platform.elements_base => elements;

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
				for (int i = 0; i < num2; i++)
				{
					int elementIdentifier = elements.axes[i].elementIdentifier;
					int num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num3 < 0 || num3 >= num)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num3].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
					}
				}
				return array;
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
				for (int i = 0; i < buttonCount; i++)
				{
					int elementIdentifier = elements.buttons[i].elementIdentifier;
					int num2 = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num2 < 0 || num2 >= num)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num2].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
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
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
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
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
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

			[IteratorStateMachine(typeof(YWgdSuDUlxJmtSmPiGXOcmqITNvHc))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return new YWgdSuDUlxJmtSmPiGXOcmqITNvHc(-2)
				{
					anTYfjOdMZFxoOmBJeiUgzndwyRf = this
				};
			}

			[IteratorStateMachine(typeof(ikOOdhFuFjcyrFcjgCFbesYXbgVNA))]
			internal override IEnumerable<Button_Base> IterateButtons()
			{
				return new ikOOdhFuFjcyrFcjgCFbesYXbgVNA(-2)
				{
					mFjfYWiZfKLkvyLXmDjyoDuHVTIk = this
				};
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
				if (destination is Platform_RawInput_Base platform_RawInput_Base)
				{
					platform_RawInput_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_RawInput : Platform_RawInput_Base
		{
			public Platform_RawInput_Base[] variants;

			IList<Platform> Platform_RawInput_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
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
				if (destination is Platform_RawInput platform_RawInput)
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

				bool MatchingCriteria_Base.hasData
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

				bool MatchingCriteria_Base.isAllowed
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

				int MatchingCriteria_Base.alternateElementCount => 0;

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
						return true;
					}
					for (int i = 0; i < subType.Length; i++)
					{
						if (subType[i] == bridgedControllerHWInfo.hw_xInputSubType)
						{
							return true;
						}
					}
					return false;
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
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.subType = ArrayTools.ShallowCopy(subType);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
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

				int Elements_Base.axisCount
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
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case HardwareElementSourceType.Axis:
						case HardwareElementSourceType.Custom:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case HardwareElementSourceType.Button:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
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
					if (destination is Button button)
					{
						button.sourceAxisPole = sourceAxisPole;
						button.buttonInfo = MiscTools.DeepClone(buttonInfo);
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
					if (destination is Axis axis)
					{
						axis.invert = invert;
						axis.buttonAxisContribution = buttonAxisContribution;
						axis.sourceAxisRange = sourceAxisRange;
						axis.calibrateAxis = calibrateAxis;
						axis.axisZero = axisZero;
						axis.axisMin = axisMin;
						axis.axisMax = axisMax;
						axis.axisInfo = MiscTools.DeepClone(axisInfo);
						axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
					}
				}
			}

			private sealed class LLcZEOuecXyLUxecjfXFhuENuOATA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int JJOyUxQHgioCWzJbabnWmNjrDVIEA;

				private Axis vMalhkiPhbXEUfBzndGcHiTzGlYaA;

				private int TAgcZDYMXEbzfAzjQxbCLyGMJtMe;

				public Platform_XInput_Base OaYbIGAgIwiSXxBCZAVvENJPraKo;

				private int oAcAQqzKNiRpjWeErPwEwwJbMoQK;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vMalhkiPhbXEUfBzndGcHiTzGlYaA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vMalhkiPhbXEUfBzndGcHiTzGlYaA;
					}
				}

				[DebuggerHidden]
				public LLcZEOuecXyLUxecjfXFhuENuOATA(int P_0)
				{
					JJOyUxQHgioCWzJbabnWmNjrDVIEA = P_0;
					TAgcZDYMXEbzfAzjQxbCLyGMJtMe = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int jJOyUxQHgioCWzJbabnWmNjrDVIEA = JJOyUxQHgioCWzJbabnWmNjrDVIEA;
					Platform_XInput_Base oaYbIGAgIwiSXxBCZAVvENJPraKo = OaYbIGAgIwiSXxBCZAVvENJPraKo;
					switch (jJOyUxQHgioCWzJbabnWmNjrDVIEA)
					{
					default:
						return false;
					case 0:
						JJOyUxQHgioCWzJbabnWmNjrDVIEA = -1;
						if (oaYbIGAgIwiSXxBCZAVvENJPraKo.elements == null || oaYbIGAgIwiSXxBCZAVvENJPraKo.elements.axes == null)
						{
							return false;
						}
						oAcAQqzKNiRpjWeErPwEwwJbMoQK = 0;
						break;
					case 1:
						JJOyUxQHgioCWzJbabnWmNjrDVIEA = -1;
						oAcAQqzKNiRpjWeErPwEwwJbMoQK++;
						break;
					}
					if (oAcAQqzKNiRpjWeErPwEwwJbMoQK < oaYbIGAgIwiSXxBCZAVvENJPraKo.elements.axes.Length)
					{
						vMalhkiPhbXEUfBzndGcHiTzGlYaA = oaYbIGAgIwiSXxBCZAVvENJPraKo.elements.axes[oAcAQqzKNiRpjWeErPwEwwJbMoQK];
						JJOyUxQHgioCWzJbabnWmNjrDVIEA = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					LLcZEOuecXyLUxecjfXFhuENuOATA lLcZEOuecXyLUxecjfXFhuENuOATA;
					if (JJOyUxQHgioCWzJbabnWmNjrDVIEA == -2 && TAgcZDYMXEbzfAzjQxbCLyGMJtMe == Environment.CurrentManagedThreadId)
					{
						JJOyUxQHgioCWzJbabnWmNjrDVIEA = 0;
						lLcZEOuecXyLUxecjfXFhuENuOATA = this;
					}
					else
					{
						lLcZEOuecXyLUxecjfXFhuENuOATA = new LLcZEOuecXyLUxecjfXFhuENuOATA(0);
						lLcZEOuecXyLUxecjfXFhuENuOATA.OaYbIGAgIwiSXxBCZAVvENJPraKo = OaYbIGAgIwiSXxBCZAVvENJPraKo;
					}
					return lLcZEOuecXyLUxecjfXFhuENuOATA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class ZPvsMuXdiykYygMOGonSSaneciOz : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int gLUGFLRTfOpmNlfjnDnyGNrzexhAA;

				private Button CICNrPUPOYcMWoTNlBYbaZOWaLSFb;

				private int IIgJRxUevcBdfRmIVGobAlMnYjsz;

				public Platform_XInput_Base zUBdUDiywifeuHNiBSdZzTefuzCV;

				private int AINZwMdCJqAaktBNBFLSxISLViec;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return CICNrPUPOYcMWoTNlBYbaZOWaLSFb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return CICNrPUPOYcMWoTNlBYbaZOWaLSFb;
					}
				}

				[DebuggerHidden]
				public ZPvsMuXdiykYygMOGonSSaneciOz(int P_0)
				{
					gLUGFLRTfOpmNlfjnDnyGNrzexhAA = P_0;
					IIgJRxUevcBdfRmIVGobAlMnYjsz = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = gLUGFLRTfOpmNlfjnDnyGNrzexhAA;
					Platform_XInput_Base platform_XInput_Base = zUBdUDiywifeuHNiBSdZzTefuzCV;
					switch (num)
					{
					default:
						return false;
					case 0:
						gLUGFLRTfOpmNlfjnDnyGNrzexhAA = -1;
						if (platform_XInput_Base.elements == null || platform_XInput_Base.elements.buttons == null)
						{
							return false;
						}
						AINZwMdCJqAaktBNBFLSxISLViec = 0;
						break;
					case 1:
						gLUGFLRTfOpmNlfjnDnyGNrzexhAA = -1;
						AINZwMdCJqAaktBNBFLSxISLViec++;
						break;
					}
					if (AINZwMdCJqAaktBNBFLSxISLViec < platform_XInput_Base.elements.buttons.Length)
					{
						CICNrPUPOYcMWoTNlBYbaZOWaLSFb = platform_XInput_Base.elements.buttons[AINZwMdCJqAaktBNBFLSxISLViec];
						gLUGFLRTfOpmNlfjnDnyGNrzexhAA = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					ZPvsMuXdiykYygMOGonSSaneciOz zPvsMuXdiykYygMOGonSSaneciOz;
					if (gLUGFLRTfOpmNlfjnDnyGNrzexhAA == -2 && IIgJRxUevcBdfRmIVGobAlMnYjsz == Environment.CurrentManagedThreadId)
					{
						gLUGFLRTfOpmNlfjnDnyGNrzexhAA = 0;
						zPvsMuXdiykYygMOGonSSaneciOz = this;
					}
					else
					{
						zPvsMuXdiykYygMOGonSSaneciOz = new ZPvsMuXdiykYygMOGonSSaneciOz(0);
						zPvsMuXdiykYygMOGonSSaneciOz.zUBdUDiywifeuHNiBSdZzTefuzCV = zUBdUDiywifeuHNiBSdZzTefuzCV;
					}
					return zPvsMuXdiykYygMOGonSSaneciOz;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			InputPlatform Platform.platform => InputPlatform.WindowsXInput;

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

			bool Platform.hasData
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

			bool Platform.disabled
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

			bool Platform.isAllowed
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

			Elements_Base Platform.elements_base => elements;

			IList<Platform> Platform.variants_base => null;

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

			[IteratorStateMachine(typeof(LLcZEOuecXyLUxecjfXFhuENuOATA))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new LLcZEOuecXyLUxecjfXFhuENuOATA(-2)
				{
					OaYbIGAgIwiSXxBCZAVvENJPraKo = this
				};
			}

			[IteratorStateMachine(typeof(ZPvsMuXdiykYygMOGonSSaneciOz))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new ZPvsMuXdiykYygMOGonSSaneciOz(-2)
				{
					zUBdUDiywifeuHNiBSdZzTefuzCV = this
				};
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.axes[i].elementIdentifier;
					if (elementIdentifier < 0 || elementIdentifier >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[elementIdentifier].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.buttons[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
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
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceType.Axis || axes_orig[i].sourceType == HardwareElementSourceType.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceType.Button)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
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
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == HardwareElementSourceType.Axis || Axes_orig[i].sourceType == HardwareElementSourceType.Custom)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == HardwareElementSourceType.Button)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
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
				if (destination is Platform_XInput_Base platform_XInput_Base)
				{
					platform_XInput_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_XInput_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_XInput : Platform_XInput_Base
		{
			public Platform_XInput_Base[] variants;

			IList<Platform> Platform_XInput_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
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
				if (destination is Platform_XInput platform_XInput)
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
						eVNCcajJzZqMRDvslhBhZyxbIPSSA(elementCount);
						return elementCount;
					}

					internal void guEItvWwGvoHZLPcFhbYGVxjWSzu(ElementCount_Base P_0)
					{
						base.eVNCcajJzZqMRDvslhBhZyxbIPSSA(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool MbczuPoUMhpcLFTrjqCROIQVOtXR(BridgedControllerHWInfo P_0)
					{
						if (!base.NrIqjnTqXRldcAeRNYVJmqWNDsiO(P_0))
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

				bool MatchingCriteria_Base.hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						if (productId != null && productId.Length != 0 && vendorId != null && vendorId.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool MatchingCriteria_Base.isAllowed
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

				int MatchingCriteria_Base.alternateElementCount
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
					if (strictMatch)
					{
						bool flag = false;
						for (int i = 0; i < vendorId.Length; i++)
						{
							if (vendorId[i] == bridgedControllerHWInfo.hw_vendorId && i < productId.Length && productId[i] == bridgedControllerHWInfo.hw_productId)
							{
								flag = true;
							}
						}
						if (!flag)
						{
							return false;
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
					for (int i = 0; i < productName.Length; i++)
					{
						string text = ((productName[i] == null) ? string.Empty : productName[i]);
						text = text.Trim();
						if (MatchingCriteria_Base.StringMatches(name, text, productName_useRegex))
						{
							return true;
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
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.hatCount = hatCount;
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
						matchingCriteria.productId = ArrayTools.ShallowCopy(productId);
						matchingCriteria.vendorId = ArrayTools.ShallowCopy(vendorId);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class NOwGZmlnVusuhAPOFoWYfXzgprMU : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int fUIaoJcVSebpWNSuGgTPCOLvTIVwA;

					private Axis ymqEUhJDIRlMkbXfVgMQtiLWZYkA;

					private int vyItIKzafKGnEDKmGAowNheTzeAW;

					public Elements BebiwYkjJiHMSBKTRQuhTnUTVFsCA;

					private Axis[] gKyexyzXLTgeoDihnvXpivAToEIVA;

					private int lwYXejIECBXtUAYQDjZtxrKWncsw;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return ymqEUhJDIRlMkbXfVgMQtiLWZYkA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ymqEUhJDIRlMkbXfVgMQtiLWZYkA;
						}
					}

					[DebuggerHidden]
					public NOwGZmlnVusuhAPOFoWYfXzgprMU(int P_0)
					{
						fUIaoJcVSebpWNSuGgTPCOLvTIVwA = P_0;
						vyItIKzafKGnEDKmGAowNheTzeAW = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = fUIaoJcVSebpWNSuGgTPCOLvTIVwA;
						Elements bebiwYkjJiHMSBKTRQuhTnUTVFsCA = BebiwYkjJiHMSBKTRQuhTnUTVFsCA;
						switch (num)
						{
						default:
							return false;
						case 0:
							fUIaoJcVSebpWNSuGgTPCOLvTIVwA = -1;
							if (bebiwYkjJiHMSBKTRQuhTnUTVFsCA.axes == null)
							{
								return false;
							}
							gKyexyzXLTgeoDihnvXpivAToEIVA = bebiwYkjJiHMSBKTRQuhTnUTVFsCA.axes;
							lwYXejIECBXtUAYQDjZtxrKWncsw = 0;
							break;
						case 1:
							fUIaoJcVSebpWNSuGgTPCOLvTIVwA = -1;
							lwYXejIECBXtUAYQDjZtxrKWncsw++;
							break;
						}
						if (lwYXejIECBXtUAYQDjZtxrKWncsw < gKyexyzXLTgeoDihnvXpivAToEIVA.Length)
						{
							Axis axis = gKyexyzXLTgeoDihnvXpivAToEIVA[lwYXejIECBXtUAYQDjZtxrKWncsw];
							ymqEUhJDIRlMkbXfVgMQtiLWZYkA = axis;
							fUIaoJcVSebpWNSuGgTPCOLvTIVwA = 1;
							return true;
						}
						gKyexyzXLTgeoDihnvXpivAToEIVA = null;
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

					[DebuggerHidden]
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						NOwGZmlnVusuhAPOFoWYfXzgprMU nOwGZmlnVusuhAPOFoWYfXzgprMU;
						if (fUIaoJcVSebpWNSuGgTPCOLvTIVwA == -2 && vyItIKzafKGnEDKmGAowNheTzeAW == Environment.CurrentManagedThreadId)
						{
							fUIaoJcVSebpWNSuGgTPCOLvTIVwA = 0;
							nOwGZmlnVusuhAPOFoWYfXzgprMU = this;
						}
						else
						{
							nOwGZmlnVusuhAPOFoWYfXzgprMU = new NOwGZmlnVusuhAPOFoWYfXzgprMU(0);
							nOwGZmlnVusuhAPOFoWYfXzgprMU.BebiwYkjJiHMSBKTRQuhTnUTVFsCA = BebiwYkjJiHMSBKTRQuhTnUTVFsCA;
						}
						return nOwGZmlnVusuhAPOFoWYfXzgprMU;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class yOcYmIezIJlAGTChMQEGtAhPcwWU : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int fPADKFTDLdzrNXSycOpqvqlFgCqz;

					private Button GrPrlWXJOMtHpBkGkzLPJtADNosJ;

					private int fPrxzjRYpimOcYmbrikPnKzUKeFh;

					public Elements mbjARYsEKCaYqAleYOecaLujylaLb;

					private Button[] BhqedVwsIqGaaWfsGVXEJzxgVhLf;

					private int cspizVrSNGmUKTeSMakbkdWFlFUJA;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return GrPrlWXJOMtHpBkGkzLPJtADNosJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return GrPrlWXJOMtHpBkGkzLPJtADNosJ;
						}
					}

					[DebuggerHidden]
					public yOcYmIezIJlAGTChMQEGtAhPcwWU(int P_0)
					{
						fPADKFTDLdzrNXSycOpqvqlFgCqz = P_0;
						fPrxzjRYpimOcYmbrikPnKzUKeFh = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = fPADKFTDLdzrNXSycOpqvqlFgCqz;
						Elements elements = mbjARYsEKCaYqAleYOecaLujylaLb;
						switch (num)
						{
						default:
							return false;
						case 0:
							fPADKFTDLdzrNXSycOpqvqlFgCqz = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							BhqedVwsIqGaaWfsGVXEJzxgVhLf = elements.buttons;
							cspizVrSNGmUKTeSMakbkdWFlFUJA = 0;
							break;
						case 1:
							fPADKFTDLdzrNXSycOpqvqlFgCqz = -1;
							cspizVrSNGmUKTeSMakbkdWFlFUJA++;
							break;
						}
						if (cspizVrSNGmUKTeSMakbkdWFlFUJA < BhqedVwsIqGaaWfsGVXEJzxgVhLf.Length)
						{
							Button grPrlWXJOMtHpBkGkzLPJtADNosJ = BhqedVwsIqGaaWfsGVXEJzxgVhLf[cspizVrSNGmUKTeSMakbkdWFlFUJA];
							GrPrlWXJOMtHpBkGkzLPJtADNosJ = grPrlWXJOMtHpBkGkzLPJtADNosJ;
							fPADKFTDLdzrNXSycOpqvqlFgCqz = 1;
							return true;
						}
						BhqedVwsIqGaaWfsGVXEJzxgVhLf = null;
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

					[DebuggerHidden]
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						yOcYmIezIJlAGTChMQEGtAhPcwWU yOcYmIezIJlAGTChMQEGtAhPcwWU2;
						if (fPADKFTDLdzrNXSycOpqvqlFgCqz == -2 && fPrxzjRYpimOcYmbrikPnKzUKeFh == Environment.CurrentManagedThreadId)
						{
							fPADKFTDLdzrNXSycOpqvqlFgCqz = 0;
							yOcYmIezIJlAGTChMQEGtAhPcwWU2 = this;
						}
						else
						{
							yOcYmIezIJlAGTChMQEGtAhPcwWU2 = new yOcYmIezIJlAGTChMQEGtAhPcwWU(0);
							yOcYmIezIJlAGTChMQEGtAhPcwWU2.mbjARYsEKCaYqAleYOecaLujylaLb = mbjARYsEKCaYqAleYOecaLujylaLb;
						}
						return yOcYmIezIJlAGTChMQEGtAhPcwWU2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
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

				int Elements_Base.axisCount
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

				[IteratorStateMachine(typeof(NOwGZmlnVusuhAPOFoWYfXzgprMU))]
				public IEnumerable<Axis> IterateAxes()
				{
					return new NOwGZmlnVusuhAPOFoWYfXzgprMU(-2)
					{
						BebiwYkjJiHMSBKTRQuhTnUTVFsCA = this
					};
				}

				[IteratorStateMachine(typeof(yOcYmIezIJlAGTChMQEGtAhPcwWU))]
				public IEnumerable<Button> IterateButtons()
				{
					return new yOcYmIezIJlAGTChMQEGtAhPcwWU(-2)
					{
						mbjARYsEKCaYqAleYOecaLujylaLb = this
					};
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

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Axis:
						case HardwareElementSourceTypeWithHat.Custom:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case HardwareElementSourceTypeWithHat.Button:
							axisRange = AxisRange.Positive;
							return true;
						case HardwareElementSourceTypeWithHat.Hat:
							axisRange = axes[i].sourceHatRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						default:
							throw new NotImplementedException();
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
					return new Button
					{
						elementIdentifier = elementIdentifier,
						sourceType = sourceType,
						sourceButton = sourceButton,
						sourceStick = sourceStick,
						sourceAxis = sourceAxis,
						sourceOtherAxis = sourceOtherAxis,
						sourceAxisPole = sourceAxisPole,
						axisDeadZone = axisDeadZone,
						sourceHat = sourceHat,
						sourceHatType = sourceHatType,
						sourceHatDirection = sourceHatDirection,
						requireMultipleButtons = requireMultipleButtons,
						requiredButtons = ArrayTools.ShallowCopy(requiredButtons),
						ignoreIfButtonsActive = ignoreIfButtonsActive,
						ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons),
						buttonInfo = MiscTools.DeepClone(buttonInfo)
					};
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
					return new Axis
					{
						elementIdentifier = elementIdentifier,
						sourceType = sourceType,
						sourceStick = sourceStick,
						sourceAxis = sourceAxis,
						sourceOtherAxis = sourceOtherAxis,
						sourceAxisRange = sourceAxisRange,
						invert = invert,
						axisDeadZone = axisDeadZone,
						calibrateAxis = calibrateAxis,
						axisZero = axisZero,
						axisMin = axisMin,
						axisMax = axisMax,
						axisInfo = MiscTools.DeepClone(axisInfo),
						sourceButton = sourceButton,
						buttonAxisContribution = buttonAxisContribution,
						sourceHat = sourceHat,
						sourceHatDirection = sourceHatDirection,
						sourceHatRange = sourceHatRange,
						alternateCalibrations = MiscTools.DeepClone(alternateCalibrations)
					};
				}
			}

			private sealed class dkgeUNCUcVyPMtJSASYdNjzakqsB : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int NyrvItTxQswavckrgohNQGLONsoB;

				private Axis OSPFjoQdRtvOWSZFHFGHJHikUedS;

				private int UVgZVoCLaSKNiazEXjyWEfMymPxc;

				public Platform_OSX_Base sGqABOTILsBLJhorORongaXNJJZYA;

				private int CpIEAIDqKrCGxJeTtXUYTrtkkSeDb;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return OSPFjoQdRtvOWSZFHFGHJHikUedS;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return OSPFjoQdRtvOWSZFHFGHJHikUedS;
					}
				}

				[DebuggerHidden]
				public dkgeUNCUcVyPMtJSASYdNjzakqsB(int P_0)
				{
					NyrvItTxQswavckrgohNQGLONsoB = P_0;
					UVgZVoCLaSKNiazEXjyWEfMymPxc = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int nyrvItTxQswavckrgohNQGLONsoB = NyrvItTxQswavckrgohNQGLONsoB;
					Platform_OSX_Base platform_OSX_Base = sGqABOTILsBLJhorORongaXNJJZYA;
					switch (nyrvItTxQswavckrgohNQGLONsoB)
					{
					default:
						return false;
					case 0:
						NyrvItTxQswavckrgohNQGLONsoB = -1;
						if (platform_OSX_Base.elements == null || platform_OSX_Base.elements.axes == null)
						{
							return false;
						}
						CpIEAIDqKrCGxJeTtXUYTrtkkSeDb = 0;
						break;
					case 1:
						NyrvItTxQswavckrgohNQGLONsoB = -1;
						CpIEAIDqKrCGxJeTtXUYTrtkkSeDb++;
						break;
					}
					if (CpIEAIDqKrCGxJeTtXUYTrtkkSeDb < platform_OSX_Base.elements.axes.Length)
					{
						OSPFjoQdRtvOWSZFHFGHJHikUedS = platform_OSX_Base.elements.axes[CpIEAIDqKrCGxJeTtXUYTrtkkSeDb];
						NyrvItTxQswavckrgohNQGLONsoB = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					dkgeUNCUcVyPMtJSASYdNjzakqsB dkgeUNCUcVyPMtJSASYdNjzakqsB2;
					if (NyrvItTxQswavckrgohNQGLONsoB == -2 && UVgZVoCLaSKNiazEXjyWEfMymPxc == Environment.CurrentManagedThreadId)
					{
						NyrvItTxQswavckrgohNQGLONsoB = 0;
						dkgeUNCUcVyPMtJSASYdNjzakqsB2 = this;
					}
					else
					{
						dkgeUNCUcVyPMtJSASYdNjzakqsB2 = new dkgeUNCUcVyPMtJSASYdNjzakqsB(0);
						dkgeUNCUcVyPMtJSASYdNjzakqsB2.sGqABOTILsBLJhorORongaXNJJZYA = sGqABOTILsBLJhorORongaXNJJZYA;
					}
					return dkgeUNCUcVyPMtJSASYdNjzakqsB2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class KcvyObiTNfixAivJZVlEeBfHyXZf : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int FLgGmyuOjrLRMXxokbdOXIBOcYNAA;

				private Button hFabjUFiZNNtuCdFuQlVrawuADnX;

				private int QYACoHQSWjuIuFnVrCKODLFEXRocA;

				public Platform_OSX_Base xOQZsZCHxXCzGDkqDkwIhSgmvmtLA;

				private int NwkanNInpfGnFSyjZebqfPRyBNFsA;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return hFabjUFiZNNtuCdFuQlVrawuADnX;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return hFabjUFiZNNtuCdFuQlVrawuADnX;
					}
				}

				[DebuggerHidden]
				public KcvyObiTNfixAivJZVlEeBfHyXZf(int P_0)
				{
					FLgGmyuOjrLRMXxokbdOXIBOcYNAA = P_0;
					QYACoHQSWjuIuFnVrCKODLFEXRocA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int fLgGmyuOjrLRMXxokbdOXIBOcYNAA = FLgGmyuOjrLRMXxokbdOXIBOcYNAA;
					Platform_OSX_Base platform_OSX_Base = xOQZsZCHxXCzGDkqDkwIhSgmvmtLA;
					switch (fLgGmyuOjrLRMXxokbdOXIBOcYNAA)
					{
					default:
						return false;
					case 0:
						FLgGmyuOjrLRMXxokbdOXIBOcYNAA = -1;
						if (platform_OSX_Base.elements == null || platform_OSX_Base.elements.buttons == null)
						{
							return false;
						}
						NwkanNInpfGnFSyjZebqfPRyBNFsA = 0;
						break;
					case 1:
						FLgGmyuOjrLRMXxokbdOXIBOcYNAA = -1;
						NwkanNInpfGnFSyjZebqfPRyBNFsA++;
						break;
					}
					if (NwkanNInpfGnFSyjZebqfPRyBNFsA < platform_OSX_Base.elements.buttons.Length)
					{
						hFabjUFiZNNtuCdFuQlVrawuADnX = platform_OSX_Base.elements.buttons[NwkanNInpfGnFSyjZebqfPRyBNFsA];
						FLgGmyuOjrLRMXxokbdOXIBOcYNAA = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					KcvyObiTNfixAivJZVlEeBfHyXZf kcvyObiTNfixAivJZVlEeBfHyXZf;
					if (FLgGmyuOjrLRMXxokbdOXIBOcYNAA == -2 && QYACoHQSWjuIuFnVrCKODLFEXRocA == Environment.CurrentManagedThreadId)
					{
						FLgGmyuOjrLRMXxokbdOXIBOcYNAA = 0;
						kcvyObiTNfixAivJZVlEeBfHyXZf = this;
					}
					else
					{
						kcvyObiTNfixAivJZVlEeBfHyXZf = new KcvyObiTNfixAivJZVlEeBfHyXZf(0);
						kcvyObiTNfixAivJZVlEeBfHyXZf.xOQZsZCHxXCzGDkqDkwIhSgmvmtLA = xOQZsZCHxXCzGDkqDkwIhSgmvmtLA;
					}
					return kcvyObiTNfixAivJZVlEeBfHyXZf;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			InputPlatform Platform.platform => InputPlatform.OSXNative;

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

			bool Platform.hasData
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

			bool Platform.disabled
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

			bool Platform.isAllowed
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

			Elements_Base Platform.elements_base => elements;

			IList<Platform> Platform.variants_base => null;

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

			[IteratorStateMachine(typeof(dkgeUNCUcVyPMtJSASYdNjzakqsB))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new dkgeUNCUcVyPMtJSASYdNjzakqsB(-2)
				{
					sGqABOTILsBLJhorORongaXNJJZYA = this
				};
			}

			[IteratorStateMachine(typeof(KcvyObiTNfixAivJZVlEeBfHyXZf))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new KcvyObiTNfixAivJZVlEeBfHyXZf(-2)
				{
					xOQZsZCHxXCzGDkqDkwIhSgmvmtLA = this
				};
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
				foreach (Axis item in elements.IterateAxes())
				{
					list.Add(item);
				}
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = list[i].elementIdentifier;
					if (elementIdentifier < 0 || elementIdentifier >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[elementIdentifier].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				for (int i = 0; i < buttonCount; i++)
				{
					int elementIdentifier = elements.buttons[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
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
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
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
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
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
				if (destination is Platform_OSX_Base platform_OSX_Base)
				{
					platform_OSX_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_OSX_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_OSX : Platform_OSX_Base
		{
			public Platform_OSX_Base[] variants;

			IList<Platform> Platform_OSX_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
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
				if (destination is Platform_OSX platform_OSX)
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
						eVNCcajJzZqMRDvslhBhZyxbIPSSA(elementCount);
						return elementCount;
					}

					internal void NDCdlztJkqJNrSnXpmtvNXaGtuCm(ElementCount_Base P_0)
					{
						base.eVNCcajJzZqMRDvslhBhZyxbIPSSA(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool NyUZopYxklQwmnwAUDTutHcvVBLe(BridgedControllerHWInfo P_0)
					{
						if (!base.NrIqjnTqXRldcAeRNYVJmqWNDsiO(P_0))
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

				bool MatchingCriteria_Base.hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (productGUID != null && productGUID.Length != 0)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool MatchingCriteria_Base.isAllowed
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

				int MatchingCriteria_Base.alternateElementCount
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
					if (string.IsNullOrEmpty(name) || names == null)
					{
						return false;
					}
					string searchIn = name.Trim();
					for (int i = 0; i < names.Length; i++)
					{
						if (!string.IsNullOrEmpty(names[i]) && MatchingCriteria_Base.StringMatches(searchIn, names[i], useRegex))
						{
							return true;
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
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.hatCount = hatCount;
						matchingCriteria.manufacturer_useRegex = manufacturer_useRegex;
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.systemName_useRegex = systemName_useRegex;
						matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.systemName = ArrayTools.ShallowCopy(systemName);
						matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class HKGmTHxBYFnFiFDdOPYkSoATPwhh : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int JAIukaZCGiZGmgdsJrRDgJVcaMyu;

					private Axis ZwImQLHDZzKpXzFogWMEpiqiaeOp;

					private int zCEwuTGHPVgfRBYQLpfUfDddeExf;

					public Elements UsPfazhsMLktsgliqKsBdKdKcAebA;

					private int mQDAJmThQGpFFAnZJJoFVFjezXdn;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return ZwImQLHDZzKpXzFogWMEpiqiaeOp;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ZwImQLHDZzKpXzFogWMEpiqiaeOp;
						}
					}

					[DebuggerHidden]
					public HKGmTHxBYFnFiFDdOPYkSoATPwhh(int P_0)
					{
						JAIukaZCGiZGmgdsJrRDgJVcaMyu = P_0;
						zCEwuTGHPVgfRBYQLpfUfDddeExf = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int jAIukaZCGiZGmgdsJrRDgJVcaMyu = JAIukaZCGiZGmgdsJrRDgJVcaMyu;
						Elements usPfazhsMLktsgliqKsBdKdKcAebA = UsPfazhsMLktsgliqKsBdKdKcAebA;
						switch (jAIukaZCGiZGmgdsJrRDgJVcaMyu)
						{
						default:
							return false;
						case 0:
							JAIukaZCGiZGmgdsJrRDgJVcaMyu = -1;
							if (usPfazhsMLktsgliqKsBdKdKcAebA.axes == null)
							{
								return false;
							}
							mQDAJmThQGpFFAnZJJoFVFjezXdn = 0;
							break;
						case 1:
							JAIukaZCGiZGmgdsJrRDgJVcaMyu = -1;
							mQDAJmThQGpFFAnZJJoFVFjezXdn++;
							break;
						}
						if (mQDAJmThQGpFFAnZJJoFVFjezXdn < usPfazhsMLktsgliqKsBdKdKcAebA.axes.Length)
						{
							ZwImQLHDZzKpXzFogWMEpiqiaeOp = usPfazhsMLktsgliqKsBdKdKcAebA.axes[mQDAJmThQGpFFAnZJJoFVFjezXdn];
							JAIukaZCGiZGmgdsJrRDgJVcaMyu = 1;
							return true;
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

					[DebuggerHidden]
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						HKGmTHxBYFnFiFDdOPYkSoATPwhh hKGmTHxBYFnFiFDdOPYkSoATPwhh;
						if (JAIukaZCGiZGmgdsJrRDgJVcaMyu == -2 && zCEwuTGHPVgfRBYQLpfUfDddeExf == Environment.CurrentManagedThreadId)
						{
							JAIukaZCGiZGmgdsJrRDgJVcaMyu = 0;
							hKGmTHxBYFnFiFDdOPYkSoATPwhh = this;
						}
						else
						{
							hKGmTHxBYFnFiFDdOPYkSoATPwhh = new HKGmTHxBYFnFiFDdOPYkSoATPwhh(0);
							hKGmTHxBYFnFiFDdOPYkSoATPwhh.UsPfazhsMLktsgliqKsBdKdKcAebA = UsPfazhsMLktsgliqKsBdKdKcAebA;
						}
						return hKGmTHxBYFnFiFDdOPYkSoATPwhh;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class cIdIjFxmNUkJfJbhtMkAdBgAARIQ : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int EcfFHpCBlzNjdINiCzSAmAhOJpEoc;

					private Button zfBUBqVgJjYktWGRcogQSDBLNsld;

					private int VtcJEyZQstzVOqRmPozRMHODhYaE;

					public Elements rbfIfmMNOYzJTkFXuciLFVcBGtboA;

					private int FXUSnWbkxtHtqobDXVhCXdZHnXqI;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return zfBUBqVgJjYktWGRcogQSDBLNsld;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return zfBUBqVgJjYktWGRcogQSDBLNsld;
						}
					}

					[DebuggerHidden]
					public cIdIjFxmNUkJfJbhtMkAdBgAARIQ(int P_0)
					{
						EcfFHpCBlzNjdINiCzSAmAhOJpEoc = P_0;
						VtcJEyZQstzVOqRmPozRMHODhYaE = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int ecfFHpCBlzNjdINiCzSAmAhOJpEoc = EcfFHpCBlzNjdINiCzSAmAhOJpEoc;
						Elements elements = rbfIfmMNOYzJTkFXuciLFVcBGtboA;
						switch (ecfFHpCBlzNjdINiCzSAmAhOJpEoc)
						{
						default:
							return false;
						case 0:
							EcfFHpCBlzNjdINiCzSAmAhOJpEoc = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							FXUSnWbkxtHtqobDXVhCXdZHnXqI = 0;
							break;
						case 1:
							EcfFHpCBlzNjdINiCzSAmAhOJpEoc = -1;
							FXUSnWbkxtHtqobDXVhCXdZHnXqI++;
							break;
						}
						if (FXUSnWbkxtHtqobDXVhCXdZHnXqI < elements.buttons.Length)
						{
							zfBUBqVgJjYktWGRcogQSDBLNsld = elements.buttons[FXUSnWbkxtHtqobDXVhCXdZHnXqI];
							EcfFHpCBlzNjdINiCzSAmAhOJpEoc = 1;
							return true;
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

					[DebuggerHidden]
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						cIdIjFxmNUkJfJbhtMkAdBgAARIQ cIdIjFxmNUkJfJbhtMkAdBgAARIQ2;
						if (EcfFHpCBlzNjdINiCzSAmAhOJpEoc == -2 && VtcJEyZQstzVOqRmPozRMHODhYaE == Environment.CurrentManagedThreadId)
						{
							EcfFHpCBlzNjdINiCzSAmAhOJpEoc = 0;
							cIdIjFxmNUkJfJbhtMkAdBgAARIQ2 = this;
						}
						else
						{
							cIdIjFxmNUkJfJbhtMkAdBgAARIQ2 = new cIdIjFxmNUkJfJbhtMkAdBgAARIQ(0);
							cIdIjFxmNUkJfJbhtMkAdBgAARIQ2.rbfIfmMNOYzJTkFXuciLFVcBGtboA = rbfIfmMNOYzJTkFXuciLFVcBGtboA;
						}
						return cIdIjFxmNUkJfJbhtMkAdBgAARIQ2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
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

				int Elements_Base.axisCount
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
					[IteratorStateMachine(typeof(HKGmTHxBYFnFiFDdOPYkSoATPwhh))]
					get
					{
						return new HKGmTHxBYFnFiFDdOPYkSoATPwhh(-2)
						{
							UsPfazhsMLktsgliqKsBdKdKcAebA = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(cIdIjFxmNUkJfJbhtMkAdBgAARIQ))]
					get
					{
						return new cIdIjFxmNUkJfJbhtMkAdBgAARIQ(-2)
						{
							rbfIfmMNOYzJTkFXuciLFVcBGtboA = this
						};
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Axis:
						case HardwareElementSourceTypeWithHat.Custom:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case HardwareElementSourceTypeWithHat.Button:
							axisRange = AxisRange.Positive;
							return true;
						case HardwareElementSourceTypeWithHat.Hat:
							axisRange = axes[i].sourceHatRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						default:
							throw new NotImplementedException();
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
					if (source is Button button)
					{
						elementIdentifier = button.elementIdentifier;
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
						ignoreIfButtonsActive = button.ignoreIfButtonsActive;
						ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(button.ignoreIfButtonsActiveButtons);
						buttonInfo = MiscTools.DeepClone(button.buttonInfo);
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
					if (source is Axis axis)
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
						sourceButton = axis.sourceButton;
						buttonAxisContribution = axis.buttonAxisContribution;
						sourceHat = axis.sourceHat;
						sourceHatDirection = axis.sourceHatDirection;
						sourceHatRange = axis.sourceHatRange;
						alternateCalibrations = MiscTools.DeepClone(axis.alternateCalibrations);
					}
				}
			}

			private sealed class jiSUJTsmslMGSWkhOSObHhKEsIbn : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int ltTMGfADJvIXIMFztPIumkrLTwfL;

				private Axis TdeUZSNBSRJbcuUWlCiHLCBafaMcA;

				private int UXojxAFMBfvHmQCJCcXlwfKsGOrT;

				public Platform_Linux_Base vzYbkJPBQrPErxvDhdkQUHKBjJiu;

				private int cSQEfjlibhFbiDKFYogjeJhrUQQKA;

				private int tHQfNeABswofexygpbLtEfogmLXeb;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return TdeUZSNBSRJbcuUWlCiHLCBafaMcA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return TdeUZSNBSRJbcuUWlCiHLCBafaMcA;
					}
				}

				[DebuggerHidden]
				public jiSUJTsmslMGSWkhOSObHhKEsIbn(int P_0)
				{
					ltTMGfADJvIXIMFztPIumkrLTwfL = P_0;
					UXojxAFMBfvHmQCJCcXlwfKsGOrT = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = ltTMGfADJvIXIMFztPIumkrLTwfL;
					Platform_Linux_Base platform_Linux_Base = vzYbkJPBQrPErxvDhdkQUHKBjJiu;
					switch (num)
					{
					default:
						return false;
					case 0:
						ltTMGfADJvIXIMFztPIumkrLTwfL = -1;
						if (platform_Linux_Base.elements == null || platform_Linux_Base.elements.axes == null)
						{
							return false;
						}
						cSQEfjlibhFbiDKFYogjeJhrUQQKA = platform_Linux_Base.elements.axes.Length;
						tHQfNeABswofexygpbLtEfogmLXeb = 0;
						break;
					case 1:
						ltTMGfADJvIXIMFztPIumkrLTwfL = -1;
						tHQfNeABswofexygpbLtEfogmLXeb++;
						break;
					}
					if (tHQfNeABswofexygpbLtEfogmLXeb < cSQEfjlibhFbiDKFYogjeJhrUQQKA)
					{
						TdeUZSNBSRJbcuUWlCiHLCBafaMcA = platform_Linux_Base.elements.axes[tHQfNeABswofexygpbLtEfogmLXeb];
						ltTMGfADJvIXIMFztPIumkrLTwfL = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					jiSUJTsmslMGSWkhOSObHhKEsIbn jiSUJTsmslMGSWkhOSObHhKEsIbn2;
					if (ltTMGfADJvIXIMFztPIumkrLTwfL == -2 && UXojxAFMBfvHmQCJCcXlwfKsGOrT == Environment.CurrentManagedThreadId)
					{
						ltTMGfADJvIXIMFztPIumkrLTwfL = 0;
						jiSUJTsmslMGSWkhOSObHhKEsIbn2 = this;
					}
					else
					{
						jiSUJTsmslMGSWkhOSObHhKEsIbn2 = new jiSUJTsmslMGSWkhOSObHhKEsIbn(0);
						jiSUJTsmslMGSWkhOSObHhKEsIbn2.vzYbkJPBQrPErxvDhdkQUHKBjJiu = vzYbkJPBQrPErxvDhdkQUHKBjJiu;
					}
					return jiSUJTsmslMGSWkhOSObHhKEsIbn2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class NGPgOlYWJydQCTLkphLVBQYSwbe : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int zVfUZAFXMECIYjhphtkplnwwpJgR;

				private Button eJuYuYqOadfvWpMzOebNQuyPtIRI;

				private int eXzpPqZjxajTmRdXLYeAMNbcIQKKA;

				public Platform_Linux_Base MeQaasJCczdRjYXDFCaYSkwmhzcl;

				private int BIyirnJBOpfrOELzrxWRvHUJTbJL;

				private int KuVmxQdMqdpgFjZTCGUQmeuFlphW;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return eJuYuYqOadfvWpMzOebNQuyPtIRI;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return eJuYuYqOadfvWpMzOebNQuyPtIRI;
					}
				}

				[DebuggerHidden]
				public NGPgOlYWJydQCTLkphLVBQYSwbe(int P_0)
				{
					zVfUZAFXMECIYjhphtkplnwwpJgR = P_0;
					eXzpPqZjxajTmRdXLYeAMNbcIQKKA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = zVfUZAFXMECIYjhphtkplnwwpJgR;
					Platform_Linux_Base meQaasJCczdRjYXDFCaYSkwmhzcl = MeQaasJCczdRjYXDFCaYSkwmhzcl;
					switch (num)
					{
					default:
						return false;
					case 0:
						zVfUZAFXMECIYjhphtkplnwwpJgR = -1;
						if (meQaasJCczdRjYXDFCaYSkwmhzcl.elements == null || meQaasJCczdRjYXDFCaYSkwmhzcl.elements.buttons == null)
						{
							return false;
						}
						BIyirnJBOpfrOELzrxWRvHUJTbJL = meQaasJCczdRjYXDFCaYSkwmhzcl.elements.buttons.Length;
						KuVmxQdMqdpgFjZTCGUQmeuFlphW = 0;
						break;
					case 1:
						zVfUZAFXMECIYjhphtkplnwwpJgR = -1;
						KuVmxQdMqdpgFjZTCGUQmeuFlphW++;
						break;
					}
					if (KuVmxQdMqdpgFjZTCGUQmeuFlphW < BIyirnJBOpfrOELzrxWRvHUJTbJL)
					{
						eJuYuYqOadfvWpMzOebNQuyPtIRI = meQaasJCczdRjYXDFCaYSkwmhzcl.elements.buttons[KuVmxQdMqdpgFjZTCGUQmeuFlphW];
						zVfUZAFXMECIYjhphtkplnwwpJgR = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					NGPgOlYWJydQCTLkphLVBQYSwbe nGPgOlYWJydQCTLkphLVBQYSwbe;
					if (zVfUZAFXMECIYjhphtkplnwwpJgR == -2 && eXzpPqZjxajTmRdXLYeAMNbcIQKKA == Environment.CurrentManagedThreadId)
					{
						zVfUZAFXMECIYjhphtkplnwwpJgR = 0;
						nGPgOlYWJydQCTLkphLVBQYSwbe = this;
					}
					else
					{
						nGPgOlYWJydQCTLkphLVBQYSwbe = new NGPgOlYWJydQCTLkphLVBQYSwbe(0);
						nGPgOlYWJydQCTLkphLVBQYSwbe.MeQaasJCczdRjYXDFCaYSkwmhzcl = MeQaasJCczdRjYXDFCaYSkwmhzcl;
					}
					return nGPgOlYWJydQCTLkphLVBQYSwbe;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			InputPlatform Platform.platform => InputPlatform.LinuxNative;

			bool Platform.hasData
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

			bool Platform.disabled
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

			bool Platform.isAllowed
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

			IList<Platform> Platform.variants_base => null;

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			Elements_Base Platform.elements_base => elements;

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
				for (int i = 0; i < num2; i++)
				{
					int elementIdentifier = elements.axes[i].elementIdentifier;
					int num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num3 < 0 || num3 >= num)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num3].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
					}
				}
				return array;
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
				for (int i = 0; i < buttonCount; i++)
				{
					int elementIdentifier = elements.buttons[i].elementIdentifier;
					int num2 = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num2 < 0 || num2 >= num)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num2].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
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
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
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
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
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

			[IteratorStateMachine(typeof(jiSUJTsmslMGSWkhOSObHhKEsIbn))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new jiSUJTsmslMGSWkhOSObHhKEsIbn(-2)
				{
					vzYbkJPBQrPErxvDhdkQUHKBjJiu = this
				};
			}

			[IteratorStateMachine(typeof(NGPgOlYWJydQCTLkphLVBQYSwbe))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new NGPgOlYWJydQCTLkphLVBQYSwbe(-2)
				{
					MeQaasJCczdRjYXDFCaYSkwmhzcl = this
				};
			}

			public override object DeepClone()
			{
				Platform_Linux_Base platform_Linux_Base = new Platform_Linux_Base();
				CopyVars(platform_Linux_Base);
				return platform_Linux_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				if (destination is Platform_Linux_Base platform_Linux_Base)
				{
					platform_Linux_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_Linux : Platform_Linux_Base
		{
			public Platform_Linux_Base[] variants;

			IList<Platform> Platform_Linux_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
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
				if (destination is Platform_Linux platform_Linux)
				{
					platform_Linux.variants = MiscTools.DeepClone(variants);
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
						eVNCcajJzZqMRDvslhBhZyxbIPSSA(elementCount);
						return elementCount;
					}

					internal void KsulaKueqbDlVPuJUMZeMjwLmavx(ElementCount_Base P_0)
					{
						base.eVNCcajJzZqMRDvslhBhZyxbIPSSA(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool PPyeTRhePbYHayCTTVZVwHYWSlAw(BridgedControllerHWInfo P_0)
					{
						if (!base.NrIqjnTqXRldcAeRNYVJmqWNDsiO(P_0))
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

				bool MatchingCriteria_Base.hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (productGUID != null && productGUID.Length != 0)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool MatchingCriteria_Base.isAllowed
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

				int MatchingCriteria_Base.alternateElementCount
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
					if (string.IsNullOrEmpty(name) || names == null)
					{
						return false;
					}
					string searchIn = name.Trim();
					for (int i = 0; i < names.Length; i++)
					{
						if (!string.IsNullOrEmpty(names[i]) && MatchingCriteria_Base.StringMatches(searchIn, names[i], useRegex))
						{
							return true;
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
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.hatCount = hatCount;
						matchingCriteria.manufacturer_useRegex = manufacturer_useRegex;
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class OxnFsUvTzrxnuDCGADVCHcDaQrkGA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int PwafGNkxOCmGZYvWJwcndOKFCWrv;

					private Axis AgESLCSlrhOeLPsnihrCtHYNngMC;

					private int DqJgOotWkbQIZOZAZhcIUkVtZuhl;

					public Elements BdbMrvpzEfziDhJCtPAFaCleRmlB;

					private int MfEVGcZyojuYZIkshioNnUuTJeje;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return AgESLCSlrhOeLPsnihrCtHYNngMC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return AgESLCSlrhOeLPsnihrCtHYNngMC;
						}
					}

					[DebuggerHidden]
					public OxnFsUvTzrxnuDCGADVCHcDaQrkGA(int P_0)
					{
						PwafGNkxOCmGZYvWJwcndOKFCWrv = P_0;
						DqJgOotWkbQIZOZAZhcIUkVtZuhl = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int pwafGNkxOCmGZYvWJwcndOKFCWrv = PwafGNkxOCmGZYvWJwcndOKFCWrv;
						Elements bdbMrvpzEfziDhJCtPAFaCleRmlB = BdbMrvpzEfziDhJCtPAFaCleRmlB;
						switch (pwafGNkxOCmGZYvWJwcndOKFCWrv)
						{
						default:
							return false;
						case 0:
							PwafGNkxOCmGZYvWJwcndOKFCWrv = -1;
							if (bdbMrvpzEfziDhJCtPAFaCleRmlB.axes == null)
							{
								return false;
							}
							MfEVGcZyojuYZIkshioNnUuTJeje = 0;
							break;
						case 1:
							PwafGNkxOCmGZYvWJwcndOKFCWrv = -1;
							MfEVGcZyojuYZIkshioNnUuTJeje++;
							break;
						}
						if (MfEVGcZyojuYZIkshioNnUuTJeje < bdbMrvpzEfziDhJCtPAFaCleRmlB.axes.Length)
						{
							AgESLCSlrhOeLPsnihrCtHYNngMC = bdbMrvpzEfziDhJCtPAFaCleRmlB.axes[MfEVGcZyojuYZIkshioNnUuTJeje];
							PwafGNkxOCmGZYvWJwcndOKFCWrv = 1;
							return true;
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

					[DebuggerHidden]
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						OxnFsUvTzrxnuDCGADVCHcDaQrkGA oxnFsUvTzrxnuDCGADVCHcDaQrkGA;
						if (PwafGNkxOCmGZYvWJwcndOKFCWrv == -2 && DqJgOotWkbQIZOZAZhcIUkVtZuhl == Environment.CurrentManagedThreadId)
						{
							PwafGNkxOCmGZYvWJwcndOKFCWrv = 0;
							oxnFsUvTzrxnuDCGADVCHcDaQrkGA = this;
						}
						else
						{
							oxnFsUvTzrxnuDCGADVCHcDaQrkGA = new OxnFsUvTzrxnuDCGADVCHcDaQrkGA(0);
							oxnFsUvTzrxnuDCGADVCHcDaQrkGA.BdbMrvpzEfziDhJCtPAFaCleRmlB = BdbMrvpzEfziDhJCtPAFaCleRmlB;
						}
						return oxnFsUvTzrxnuDCGADVCHcDaQrkGA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class txkjNXLHzHgsQuMAAkrERrtCGTIcA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int wyxwcVvFNFmIqPgFBzoyagzcwWxQ;

					private Button sgavFOINaZkgbZUfAvDDSnFbdncW;

					private int MoxWuqYpRynEcdwPktIEjhSctjqb;

					public Elements TmvkJKBEwBATfTBQoYmuxktsfOKJ;

					private int LXgbnrIzsOMbzGmVAzuRRcdDNMTw;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return sgavFOINaZkgbZUfAvDDSnFbdncW;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return sgavFOINaZkgbZUfAvDDSnFbdncW;
						}
					}

					[DebuggerHidden]
					public txkjNXLHzHgsQuMAAkrERrtCGTIcA(int P_0)
					{
						wyxwcVvFNFmIqPgFBzoyagzcwWxQ = P_0;
						MoxWuqYpRynEcdwPktIEjhSctjqb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = wyxwcVvFNFmIqPgFBzoyagzcwWxQ;
						Elements tmvkJKBEwBATfTBQoYmuxktsfOKJ = TmvkJKBEwBATfTBQoYmuxktsfOKJ;
						switch (num)
						{
						default:
							return false;
						case 0:
							wyxwcVvFNFmIqPgFBzoyagzcwWxQ = -1;
							if (tmvkJKBEwBATfTBQoYmuxktsfOKJ.buttons == null)
							{
								return false;
							}
							LXgbnrIzsOMbzGmVAzuRRcdDNMTw = 0;
							break;
						case 1:
							wyxwcVvFNFmIqPgFBzoyagzcwWxQ = -1;
							LXgbnrIzsOMbzGmVAzuRRcdDNMTw++;
							break;
						}
						if (LXgbnrIzsOMbzGmVAzuRRcdDNMTw < tmvkJKBEwBATfTBQoYmuxktsfOKJ.buttons.Length)
						{
							sgavFOINaZkgbZUfAvDDSnFbdncW = tmvkJKBEwBATfTBQoYmuxktsfOKJ.buttons[LXgbnrIzsOMbzGmVAzuRRcdDNMTw];
							wyxwcVvFNFmIqPgFBzoyagzcwWxQ = 1;
							return true;
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

					[DebuggerHidden]
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						txkjNXLHzHgsQuMAAkrERrtCGTIcA txkjNXLHzHgsQuMAAkrERrtCGTIcA2;
						if (wyxwcVvFNFmIqPgFBzoyagzcwWxQ == -2 && MoxWuqYpRynEcdwPktIEjhSctjqb == Environment.CurrentManagedThreadId)
						{
							wyxwcVvFNFmIqPgFBzoyagzcwWxQ = 0;
							txkjNXLHzHgsQuMAAkrERrtCGTIcA2 = this;
						}
						else
						{
							txkjNXLHzHgsQuMAAkrERrtCGTIcA2 = new txkjNXLHzHgsQuMAAkrERrtCGTIcA(0);
							txkjNXLHzHgsQuMAAkrERrtCGTIcA2.TmvkJKBEwBATfTBQoYmuxktsfOKJ = TmvkJKBEwBATfTBQoYmuxktsfOKJ;
						}
						return txkjNXLHzHgsQuMAAkrERrtCGTIcA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
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

				int Elements_Base.axisCount
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
					[IteratorStateMachine(typeof(OxnFsUvTzrxnuDCGADVCHcDaQrkGA))]
					get
					{
						return new OxnFsUvTzrxnuDCGADVCHcDaQrkGA(-2)
						{
							BdbMrvpzEfziDhJCtPAFaCleRmlB = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(txkjNXLHzHgsQuMAAkrERrtCGTIcA))]
					get
					{
						return new txkjNXLHzHgsQuMAAkrERrtCGTIcA(-2)
						{
							TmvkJKBEwBATfTBQoYmuxktsfOKJ = this
						};
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Axis:
						case HardwareElementSourceTypeWithHat.Custom:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case HardwareElementSourceTypeWithHat.Button:
							axisRange = AxisRange.Positive;
							return true;
						case HardwareElementSourceTypeWithHat.Hat:
							axisRange = axes[i].sourceHatRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						default:
							throw new NotImplementedException();
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
					if (source is Button button)
					{
						elementIdentifier = button.elementIdentifier;
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
						ignoreIfButtonsActive = button.ignoreIfButtonsActive;
						ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(button.ignoreIfButtonsActiveButtons);
						buttonInfo = MiscTools.DeepClone(button.buttonInfo);
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
					if (source is Axis axis)
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
						sourceButton = axis.sourceButton;
						buttonAxisContribution = axis.buttonAxisContribution;
						sourceHat = axis.sourceHat;
						sourceHatDirection = axis.sourceHatDirection;
						sourceHatRange = axis.sourceHatRange;
						alternateCalibrations = MiscTools.DeepClone(axis.alternateCalibrations);
					}
				}
			}

			private sealed class ODYmOzRIyQoZFKMypDlMeSmDJnvh : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int ZPvzfCHNGDcLFKeyDIdvCmweAFSEB;

				private Axis nAGPqJZoDhYpeVGEkotRVvbeCdpU;

				private int hOZukMZPUHtAQnAQbfHVtMNnUqum;

				public Platform_WindowsUWP_Base KfXgPGgUzGRwciqhgAGrAOnmhhxdb;

				private int wSYdUofyXscDeKIIkprnLQcHKILJA;

				private int TlVFogixKBJcmPxlTXbqrZmbJywg;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return nAGPqJZoDhYpeVGEkotRVvbeCdpU;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return nAGPqJZoDhYpeVGEkotRVvbeCdpU;
					}
				}

				[DebuggerHidden]
				public ODYmOzRIyQoZFKMypDlMeSmDJnvh(int P_0)
				{
					ZPvzfCHNGDcLFKeyDIdvCmweAFSEB = P_0;
					hOZukMZPUHtAQnAQbfHVtMNnUqum = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int zPvzfCHNGDcLFKeyDIdvCmweAFSEB = ZPvzfCHNGDcLFKeyDIdvCmweAFSEB;
					Platform_WindowsUWP_Base kfXgPGgUzGRwciqhgAGrAOnmhhxdb = KfXgPGgUzGRwciqhgAGrAOnmhhxdb;
					switch (zPvzfCHNGDcLFKeyDIdvCmweAFSEB)
					{
					default:
						return false;
					case 0:
						ZPvzfCHNGDcLFKeyDIdvCmweAFSEB = -1;
						if (kfXgPGgUzGRwciqhgAGrAOnmhhxdb.elements == null || kfXgPGgUzGRwciqhgAGrAOnmhhxdb.elements.axes == null)
						{
							return false;
						}
						wSYdUofyXscDeKIIkprnLQcHKILJA = kfXgPGgUzGRwciqhgAGrAOnmhhxdb.elements.axes.Length;
						TlVFogixKBJcmPxlTXbqrZmbJywg = 0;
						break;
					case 1:
						ZPvzfCHNGDcLFKeyDIdvCmweAFSEB = -1;
						TlVFogixKBJcmPxlTXbqrZmbJywg++;
						break;
					}
					if (TlVFogixKBJcmPxlTXbqrZmbJywg < wSYdUofyXscDeKIIkprnLQcHKILJA)
					{
						nAGPqJZoDhYpeVGEkotRVvbeCdpU = kfXgPGgUzGRwciqhgAGrAOnmhhxdb.elements.axes[TlVFogixKBJcmPxlTXbqrZmbJywg];
						ZPvzfCHNGDcLFKeyDIdvCmweAFSEB = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					ODYmOzRIyQoZFKMypDlMeSmDJnvh oDYmOzRIyQoZFKMypDlMeSmDJnvh;
					if (ZPvzfCHNGDcLFKeyDIdvCmweAFSEB == -2 && hOZukMZPUHtAQnAQbfHVtMNnUqum == Environment.CurrentManagedThreadId)
					{
						ZPvzfCHNGDcLFKeyDIdvCmweAFSEB = 0;
						oDYmOzRIyQoZFKMypDlMeSmDJnvh = this;
					}
					else
					{
						oDYmOzRIyQoZFKMypDlMeSmDJnvh = new ODYmOzRIyQoZFKMypDlMeSmDJnvh(0);
						oDYmOzRIyQoZFKMypDlMeSmDJnvh.KfXgPGgUzGRwciqhgAGrAOnmhhxdb = KfXgPGgUzGRwciqhgAGrAOnmhhxdb;
					}
					return oDYmOzRIyQoZFKMypDlMeSmDJnvh;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class gWtLZbFBFldLCtcgFaQPchrulezIA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int rdoOSqITTRkNBKdMOnPPZtGljbEu;

				private Button bDGgAzbDjxpDBbjRlnucjijFvnJkA;

				private int yLJAlNJQVTQlfEAqFHDdbmSUTrIEA;

				public Platform_WindowsUWP_Base nbYMCmlVmqpNqLQeAviCzlwwAhTf;

				private int gGyokdYOByDODbxLEHvHRCTZmBBcb;

				private int hHatirrDHinzlbcKDFSUEaFutkOuA;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return bDGgAzbDjxpDBbjRlnucjijFvnJkA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return bDGgAzbDjxpDBbjRlnucjijFvnJkA;
					}
				}

				[DebuggerHidden]
				public gWtLZbFBFldLCtcgFaQPchrulezIA(int P_0)
				{
					rdoOSqITTRkNBKdMOnPPZtGljbEu = P_0;
					yLJAlNJQVTQlfEAqFHDdbmSUTrIEA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = rdoOSqITTRkNBKdMOnPPZtGljbEu;
					Platform_WindowsUWP_Base platform_WindowsUWP_Base = nbYMCmlVmqpNqLQeAviCzlwwAhTf;
					switch (num)
					{
					default:
						return false;
					case 0:
						rdoOSqITTRkNBKdMOnPPZtGljbEu = -1;
						if (platform_WindowsUWP_Base.elements == null || platform_WindowsUWP_Base.elements.buttons == null)
						{
							return false;
						}
						gGyokdYOByDODbxLEHvHRCTZmBBcb = platform_WindowsUWP_Base.elements.buttons.Length;
						hHatirrDHinzlbcKDFSUEaFutkOuA = 0;
						break;
					case 1:
						rdoOSqITTRkNBKdMOnPPZtGljbEu = -1;
						hHatirrDHinzlbcKDFSUEaFutkOuA++;
						break;
					}
					if (hHatirrDHinzlbcKDFSUEaFutkOuA < gGyokdYOByDODbxLEHvHRCTZmBBcb)
					{
						bDGgAzbDjxpDBbjRlnucjijFvnJkA = platform_WindowsUWP_Base.elements.buttons[hHatirrDHinzlbcKDFSUEaFutkOuA];
						rdoOSqITTRkNBKdMOnPPZtGljbEu = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					gWtLZbFBFldLCtcgFaQPchrulezIA gWtLZbFBFldLCtcgFaQPchrulezIA2;
					if (rdoOSqITTRkNBKdMOnPPZtGljbEu == -2 && yLJAlNJQVTQlfEAqFHDdbmSUTrIEA == Environment.CurrentManagedThreadId)
					{
						rdoOSqITTRkNBKdMOnPPZtGljbEu = 0;
						gWtLZbFBFldLCtcgFaQPchrulezIA2 = this;
					}
					else
					{
						gWtLZbFBFldLCtcgFaQPchrulezIA2 = new gWtLZbFBFldLCtcgFaQPchrulezIA(0);
						gWtLZbFBFldLCtcgFaQPchrulezIA2.nbYMCmlVmqpNqLQeAviCzlwwAhTf = nbYMCmlVmqpNqLQeAviCzlwwAhTf;
					}
					return gWtLZbFBFldLCtcgFaQPchrulezIA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			InputPlatform Platform.platform => InputPlatform.WindowsUWP;

			bool Platform.hasData
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

			bool Platform.disabled
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

			bool Platform.isAllowed
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

			IList<Platform> Platform.variants_base => null;

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			Elements_Base Platform.elements_base => elements;

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
				for (int i = 0; i < num2; i++)
				{
					int elementIdentifier = elements.axes[i].elementIdentifier;
					int num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num3 < 0 || num3 >= num)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num3].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
					}
				}
				return array;
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
				for (int i = 0; i < buttonCount; i++)
				{
					int elementIdentifier = elements.buttons[i].elementIdentifier;
					int num2 = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num2 < 0 || num2 >= num)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num2].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
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
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
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
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
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

			[IteratorStateMachine(typeof(ODYmOzRIyQoZFKMypDlMeSmDJnvh))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new ODYmOzRIyQoZFKMypDlMeSmDJnvh(-2)
				{
					KfXgPGgUzGRwciqhgAGrAOnmhhxdb = this
				};
			}

			[IteratorStateMachine(typeof(gWtLZbFBFldLCtcgFaQPchrulezIA))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new gWtLZbFBFldLCtcgFaQPchrulezIA(-2)
				{
					nbYMCmlVmqpNqLQeAviCzlwwAhTf = this
				};
			}

			public override object DeepClone()
			{
				Platform_WindowsUWP_Base platform_WindowsUWP_Base = new Platform_WindowsUWP_Base();
				CopyVars(platform_WindowsUWP_Base);
				return platform_WindowsUWP_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				if (destination is Platform_WindowsUWP_Base platform_WindowsUWP_Base)
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

			IList<Platform> Platform_WindowsUWP_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
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
				if (destination is Platform_WindowsUWP platform_WindowsUWP)
				{
					platform_WindowsUWP.variants = MiscTools.DeepClone(variants);
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

				bool MatchingCriteria_Base.hasData
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
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool MatchingCriteria_Base.isAllowed
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

				int MatchingCriteria_Base.alternateElementCount => 0;

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
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (productName != null)
					{
						for (int i = 0; i < productName.Length; i++)
						{
							string searchFor = productName[i];
							if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
							{
								return true;
							}
						}
					}
					return false;
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
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.alwaysMatch = alwaysMatch;
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.matchUnityVersion = matchUnityVersion;
						matchingCriteria.matchUnityVersion_min = matchUnityVersion_min;
						matchingCriteria.matchUnityVersion_max = matchUnityVersion_max;
						matchingCriteria.matchSysVersion = matchSysVersion;
						matchingCriteria.matchSysVersion_min = matchSysVersion_min;
						matchingCriteria.matchSysVersion_max = matchSysVersion_max;
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
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

				int Elements_Base.axisCount
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Axis:
						case HardwareElementSourceTypeWithHat.Custom:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case HardwareElementSourceTypeWithHat.Button:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
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
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
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
					return new CustomCalculationSourceData
					{
						sourceType = sourceType,
						sourceElement = sourceElement,
						sourceAxisRange = sourceAxisRange,
						deadzone = deadzone,
						invert = invert
					};
				}

				object IDeepCloneable.DeepClone()
				{
					//ILSpy generated this explicit interface implementation from .override directive in DeepClone
					return this.DeepClone();
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
					if (destination != null)
					{
						destination.elementIdentifier = elementIdentifier;
						destination.sourceType = sourceType;
						destination.sourceAxis = sourceAxis;
						destination.axisDeadZone = axisDeadZone;
						destination.sourceButton = sourceButton;
						destination.sourceKeyCode = sourceKeyCode;
						destination.customCalculation = customCalculation;
						destination.customCalculationSourceData = ArrayTools.DeepClone(customCalculationSourceData);
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
					if (destination is Button button)
					{
						button.sourceAxisPole = sourceAxisPole;
						button.unityHat_sourceAxis1 = unityHat_sourceAxis1;
						button.unityHat_sourceAxis2 = unityHat_sourceAxis2;
						button.unityHat_isActiveAxisValues1 = unityHat_isActiveAxisValues1;
						button.unityHat_isActiveAxisValues2 = unityHat_isActiveAxisValues2;
						button.unityHat_isActiveAxisValues3 = unityHat_isActiveAxisValues3;
						button.unityHat_zeroValues = unityHat_zeroValues;
						button.unityHat_checkNeverPressed = unityHat_checkNeverPressed;
						button.unityHat_neverPressedZeroValues = unityHat_neverPressedZeroValues;
						button.requireMultipleButtons = requireMultipleButtons;
						button.requiredButtons = ArrayTools.ShallowCopy(requiredButtons);
						button.ignoreIfButtonsActive = ignoreIfButtonsActive;
						button.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons);
						button.buttonInfo = MiscTools.DeepClone(buttonInfo);
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

			private sealed class XdiLQVAsjrThsrJrrRDYtmyQVmgV : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int QWxGRnWYtgHVxJFGqiQvETBcUWAz;

				private Axis VLbdZtRBXjLwmGBFScRGNaAOaDas;

				private int jaqBlzfKAwyyIsINcHuKyioynULGA;

				public Platform_Fallback_Base SQFoDnYasAmiROifRDEPJHBkDPvrA;

				private int gfoHTiNKPYKZJvKGcJmbUuMHSQnx;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return VLbdZtRBXjLwmGBFScRGNaAOaDas;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return VLbdZtRBXjLwmGBFScRGNaAOaDas;
					}
				}

				[DebuggerHidden]
				public XdiLQVAsjrThsrJrrRDYtmyQVmgV(int P_0)
				{
					QWxGRnWYtgHVxJFGqiQvETBcUWAz = P_0;
					jaqBlzfKAwyyIsINcHuKyioynULGA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int qWxGRnWYtgHVxJFGqiQvETBcUWAz = QWxGRnWYtgHVxJFGqiQvETBcUWAz;
					Platform_Fallback_Base sQFoDnYasAmiROifRDEPJHBkDPvrA = SQFoDnYasAmiROifRDEPJHBkDPvrA;
					switch (qWxGRnWYtgHVxJFGqiQvETBcUWAz)
					{
					default:
						return false;
					case 0:
						QWxGRnWYtgHVxJFGqiQvETBcUWAz = -1;
						if (sQFoDnYasAmiROifRDEPJHBkDPvrA.elements == null || sQFoDnYasAmiROifRDEPJHBkDPvrA.elements.axes == null)
						{
							return false;
						}
						gfoHTiNKPYKZJvKGcJmbUuMHSQnx = 0;
						break;
					case 1:
						QWxGRnWYtgHVxJFGqiQvETBcUWAz = -1;
						gfoHTiNKPYKZJvKGcJmbUuMHSQnx++;
						break;
					}
					if (gfoHTiNKPYKZJvKGcJmbUuMHSQnx < sQFoDnYasAmiROifRDEPJHBkDPvrA.elements.axes.Length)
					{
						VLbdZtRBXjLwmGBFScRGNaAOaDas = sQFoDnYasAmiROifRDEPJHBkDPvrA.elements.axes[gfoHTiNKPYKZJvKGcJmbUuMHSQnx];
						QWxGRnWYtgHVxJFGqiQvETBcUWAz = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					XdiLQVAsjrThsrJrrRDYtmyQVmgV xdiLQVAsjrThsrJrrRDYtmyQVmgV;
					if (QWxGRnWYtgHVxJFGqiQvETBcUWAz == -2 && jaqBlzfKAwyyIsINcHuKyioynULGA == Environment.CurrentManagedThreadId)
					{
						QWxGRnWYtgHVxJFGqiQvETBcUWAz = 0;
						xdiLQVAsjrThsrJrrRDYtmyQVmgV = this;
					}
					else
					{
						xdiLQVAsjrThsrJrrRDYtmyQVmgV = new XdiLQVAsjrThsrJrrRDYtmyQVmgV(0);
						xdiLQVAsjrThsrJrrRDYtmyQVmgV.SQFoDnYasAmiROifRDEPJHBkDPvrA = SQFoDnYasAmiROifRDEPJHBkDPvrA;
					}
					return xdiLQVAsjrThsrJrrRDYtmyQVmgV;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class CnlfrNBTrSNKmBTxPGIfsfBLRxLNA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int DBkqIYtiPeRFNhrELAsIVyfSJepx;

				private Button zKXvuRwqdTXEwuTnkhpfxOOUkNCW;

				private int FFbTMewDgjuHvxhEuDdPavaXIbGA;

				public Platform_Fallback_Base iYcjbTSkMEgHSAKudYNhfYPNudWV;

				private int tAarQInbCmWSYKPYjerfsTjaFtlp;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return zKXvuRwqdTXEwuTnkhpfxOOUkNCW;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return zKXvuRwqdTXEwuTnkhpfxOOUkNCW;
					}
				}

				[DebuggerHidden]
				public CnlfrNBTrSNKmBTxPGIfsfBLRxLNA(int P_0)
				{
					DBkqIYtiPeRFNhrELAsIVyfSJepx = P_0;
					FFbTMewDgjuHvxhEuDdPavaXIbGA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int dBkqIYtiPeRFNhrELAsIVyfSJepx = DBkqIYtiPeRFNhrELAsIVyfSJepx;
					Platform_Fallback_Base platform_Fallback_Base = iYcjbTSkMEgHSAKudYNhfYPNudWV;
					switch (dBkqIYtiPeRFNhrELAsIVyfSJepx)
					{
					default:
						return false;
					case 0:
						DBkqIYtiPeRFNhrELAsIVyfSJepx = -1;
						if (platform_Fallback_Base.elements == null || platform_Fallback_Base.elements.buttons == null)
						{
							return false;
						}
						tAarQInbCmWSYKPYjerfsTjaFtlp = 0;
						break;
					case 1:
						DBkqIYtiPeRFNhrELAsIVyfSJepx = -1;
						tAarQInbCmWSYKPYjerfsTjaFtlp++;
						break;
					}
					if (tAarQInbCmWSYKPYjerfsTjaFtlp < platform_Fallback_Base.elements.buttons.Length)
					{
						zKXvuRwqdTXEwuTnkhpfxOOUkNCW = platform_Fallback_Base.elements.buttons[tAarQInbCmWSYKPYjerfsTjaFtlp];
						DBkqIYtiPeRFNhrELAsIVyfSJepx = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					CnlfrNBTrSNKmBTxPGIfsfBLRxLNA cnlfrNBTrSNKmBTxPGIfsfBLRxLNA;
					if (DBkqIYtiPeRFNhrELAsIVyfSJepx == -2 && FFbTMewDgjuHvxhEuDdPavaXIbGA == Environment.CurrentManagedThreadId)
					{
						DBkqIYtiPeRFNhrELAsIVyfSJepx = 0;
						cnlfrNBTrSNKmBTxPGIfsfBLRxLNA = this;
					}
					else
					{
						cnlfrNBTrSNKmBTxPGIfsfBLRxLNA = new CnlfrNBTrSNKmBTxPGIfsfBLRxLNA(0);
						cnlfrNBTrSNKmBTxPGIfsfBLRxLNA.iYcjbTSkMEgHSAKudYNhfYPNudWV = iYcjbTSkMEgHSAKudYNhfYPNudWV;
					}
					return cnlfrNBTrSNKmBTxPGIfsfBLRxLNA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			InputPlatform Platform.platform => InputPlatform.Fallback;

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

			bool Platform.hasData
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

			bool Platform.disabled
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

			bool Platform.isAllowed
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

			Elements_Base Platform.elements_base => elements;

			IList<Platform> Platform.variants_base => null;

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

			[IteratorStateMachine(typeof(XdiLQVAsjrThsrJrrRDYtmyQVmgV))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new XdiLQVAsjrThsrJrrRDYtmyQVmgV(-2)
				{
					SQFoDnYasAmiROifRDEPJHBkDPvrA = this
				};
			}

			[IteratorStateMachine(typeof(CnlfrNBTrSNKmBTxPGIfsfBLRxLNA))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new CnlfrNBTrSNKmBTxPGIfsfBLRxLNA(-2)
				{
					iYcjbTSkMEgHSAKudYNhfYPNudWV = this
				};
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.axes[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.buttons[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
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
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
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
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
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
				if (destination is Platform_Fallback_Base platform_Fallback_Base)
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

			IList<Platform> Platform_Fallback_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
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

				bool MatchingCriteria_Base.hasData
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

				bool MatchingCriteria_Base.isAllowed
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

				int MatchingCriteria_Base.alternateElementCount => 0;

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
					_ = alwaysMatch;
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

				public virtual object DeepClone()
				{
					return new CustomCalculationSourceData
					{
						sourceType = sourceType,
						sourceAxis = sourceAxis,
						sourceButton = sourceButton,
						sourceOtherAxis = sourceOtherAxis,
						sourceAxisRange = sourceAxisRange,
						axisDeadZone = axisDeadZone,
						invert = invert,
						axisCalibrationType = axisCalibrationType,
						axisZero = axisZero,
						axisMin = axisMin,
						axisMax = axisMax
					};
				}

				object IDeepCloneable.DeepClone()
				{
					//ILSpy generated this explicit interface implementation from .override directive in DeepClone
					return this.DeepClone();
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
					if (destination is Button button)
					{
						button.sourceAxisPole = sourceAxisPole;
						button.requireMultipleButtons = requireMultipleButtons;
						button.requiredButtons = ArrayTools.ShallowCopy(requiredButtons);
						button.ignoreIfButtonsActive = ignoreIfButtonsActive;
						button.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons);
						button.buttonInfo = MiscTools.DeepClone(buttonInfo);
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
		public class Platform_XboxOne_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
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
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (productName != null)
					{
						for (int i = 0; i < productName.Length; i++)
						{
							string searchFor = productName[i];
							if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
							{
								return true;
							}
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
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
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

				int Elements_Base.axisCount
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
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
				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					_ = destination is Button;
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
					_ = destination is Axis;
				}
			}

			private sealed class UefBBmZOzeaqqoHPjYlRihSbSIvC : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int bLuAiXgqwzrLWdprJFcfXPUMxOfc;

				private Platform_Custom.Axis ysfbVotTdWoPhKDpdUHeBKHajlKs;

				private int yornIdckwprKkOgrivGaRTvGZYbJ;

				public Platform_XboxOne_Base FvufjmWrzwbRBctWilOUaDrGfaXFA;

				private int vOGygiiFMJpapvYuQBikDqQRKdIM;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ysfbVotTdWoPhKDpdUHeBKHajlKs;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ysfbVotTdWoPhKDpdUHeBKHajlKs;
					}
				}

				[DebuggerHidden]
				public UefBBmZOzeaqqoHPjYlRihSbSIvC(int P_0)
				{
					bLuAiXgqwzrLWdprJFcfXPUMxOfc = P_0;
					yornIdckwprKkOgrivGaRTvGZYbJ = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = bLuAiXgqwzrLWdprJFcfXPUMxOfc;
					Platform_XboxOne_Base fvufjmWrzwbRBctWilOUaDrGfaXFA = FvufjmWrzwbRBctWilOUaDrGfaXFA;
					switch (num)
					{
					default:
						return false;
					case 0:
						bLuAiXgqwzrLWdprJFcfXPUMxOfc = -1;
						if (fvufjmWrzwbRBctWilOUaDrGfaXFA.elements == null || fvufjmWrzwbRBctWilOUaDrGfaXFA.elements.axes == null)
						{
							return false;
						}
						vOGygiiFMJpapvYuQBikDqQRKdIM = 0;
						break;
					case 1:
						bLuAiXgqwzrLWdprJFcfXPUMxOfc = -1;
						vOGygiiFMJpapvYuQBikDqQRKdIM++;
						break;
					}
					if (vOGygiiFMJpapvYuQBikDqQRKdIM < fvufjmWrzwbRBctWilOUaDrGfaXFA.elements.axes.Length)
					{
						ysfbVotTdWoPhKDpdUHeBKHajlKs = fvufjmWrzwbRBctWilOUaDrGfaXFA.elements.axes[vOGygiiFMJpapvYuQBikDqQRKdIM];
						bLuAiXgqwzrLWdprJFcfXPUMxOfc = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					UefBBmZOzeaqqoHPjYlRihSbSIvC uefBBmZOzeaqqoHPjYlRihSbSIvC;
					if (bLuAiXgqwzrLWdprJFcfXPUMxOfc == -2 && yornIdckwprKkOgrivGaRTvGZYbJ == Environment.CurrentManagedThreadId)
					{
						bLuAiXgqwzrLWdprJFcfXPUMxOfc = 0;
						uefBBmZOzeaqqoHPjYlRihSbSIvC = this;
					}
					else
					{
						uefBBmZOzeaqqoHPjYlRihSbSIvC = new UefBBmZOzeaqqoHPjYlRihSbSIvC(0);
						uefBBmZOzeaqqoHPjYlRihSbSIvC.FvufjmWrzwbRBctWilOUaDrGfaXFA = FvufjmWrzwbRBctWilOUaDrGfaXFA;
					}
					return uefBBmZOzeaqqoHPjYlRihSbSIvC;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class XTjVduyExDHlmsgmVWpdtMDxbvrO : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int qvKOThAJIVWomCeGcjpVwIQScLhdA;

				private Platform_Custom.Button lvrEZfTCENTFUIKMDtMImsmnwlBN;

				private int dOoWicTqZResAxukrXjyXGqGxOPE;

				public Platform_XboxOne_Base rWsclWftsSTVEJdbclfpgwFHfoKcB;

				private int KWTjbXhlpEOKsvVSUWPcgeNNKjbW;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return lvrEZfTCENTFUIKMDtMImsmnwlBN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return lvrEZfTCENTFUIKMDtMImsmnwlBN;
					}
				}

				[DebuggerHidden]
				public XTjVduyExDHlmsgmVWpdtMDxbvrO(int P_0)
				{
					qvKOThAJIVWomCeGcjpVwIQScLhdA = P_0;
					dOoWicTqZResAxukrXjyXGqGxOPE = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = qvKOThAJIVWomCeGcjpVwIQScLhdA;
					Platform_XboxOne_Base platform_XboxOne_Base = rWsclWftsSTVEJdbclfpgwFHfoKcB;
					switch (num)
					{
					default:
						return false;
					case 0:
						qvKOThAJIVWomCeGcjpVwIQScLhdA = -1;
						if (platform_XboxOne_Base.elements == null || platform_XboxOne_Base.elements.buttons == null)
						{
							return false;
						}
						KWTjbXhlpEOKsvVSUWPcgeNNKjbW = 0;
						break;
					case 1:
						qvKOThAJIVWomCeGcjpVwIQScLhdA = -1;
						KWTjbXhlpEOKsvVSUWPcgeNNKjbW++;
						break;
					}
					if (KWTjbXhlpEOKsvVSUWPcgeNNKjbW < platform_XboxOne_Base.elements.buttons.Length)
					{
						lvrEZfTCENTFUIKMDtMImsmnwlBN = platform_XboxOne_Base.elements.buttons[KWTjbXhlpEOKsvVSUWPcgeNNKjbW];
						qvKOThAJIVWomCeGcjpVwIQScLhdA = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					XTjVduyExDHlmsgmVWpdtMDxbvrO xTjVduyExDHlmsgmVWpdtMDxbvrO;
					if (qvKOThAJIVWomCeGcjpVwIQScLhdA == -2 && dOoWicTqZResAxukrXjyXGqGxOPE == Environment.CurrentManagedThreadId)
					{
						qvKOThAJIVWomCeGcjpVwIQScLhdA = 0;
						xTjVduyExDHlmsgmVWpdtMDxbvrO = this;
					}
					else
					{
						xTjVduyExDHlmsgmVWpdtMDxbvrO = new XTjVduyExDHlmsgmVWpdtMDxbvrO(0);
						xTjVduyExDHlmsgmVWpdtMDxbvrO.rWsclWftsSTVEJdbclfpgwFHfoKcB = rWsclWftsSTVEJdbclfpgwFHfoKcB;
					}
					return xTjVduyExDHlmsgmVWpdtMDxbvrO;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			InputPlatform Platform.platform => InputPlatform.XboxOne;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
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

			bool Platform.hasData
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

			bool Platform.disabled
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

			bool Platform.isAllowed
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

			Elements_Base Platform.elements_base => elements;

			IList<Platform> Platform.variants_base => null;

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

			[IteratorStateMachine(typeof(UefBBmZOzeaqqoHPjYlRihSbSIvC))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new UefBBmZOzeaqqoHPjYlRihSbSIvC(-2)
				{
					FvufjmWrzwbRBctWilOUaDrGfaXFA = this
				};
			}

			[IteratorStateMachine(typeof(XTjVduyExDHlmsgmVWpdtMDxbvrO))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new XTjVduyExDHlmsgmVWpdtMDxbvrO(-2)
				{
					rWsclWftsSTVEJdbclfpgwFHfoKcB = this
				};
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.axes[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.buttons[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
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
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
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
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
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
				if (destination is Platform_XboxOne_Base platform_XboxOne_Base)
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

			IList<Platform> Platform_XboxOne_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
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
				if (destination is Platform_XboxOne platform_XboxOne)
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

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
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
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (productName != null)
					{
						for (int i = 0; i < productName.Length; i++)
						{
							string searchFor = productName[i];
							if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
							{
								return true;
							}
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
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
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

				int Elements_Base.axisCount
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
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
				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					_ = destination is Button;
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
					_ = destination is Axis;
				}
			}

			private sealed class warJiBHqlDDMxMlmGOWPLiNBzvGE : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int ZyBUVPuzuzldNeKuFtXhqgJmRngy;

				private Platform_Custom.Axis VSnFlaFoVzDZVGtxRiMOriMAnNUoA;

				private int HAzyoFQLTUuHbLebPGnlHSngfROx;

				public Platform_PS4_Base DwAlQrBZUtRZbdUYaiufeFRAFlAB;

				private int vXOanBHJSqmwsfHvRKNAJiMEMEFZ;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return VSnFlaFoVzDZVGtxRiMOriMAnNUoA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return VSnFlaFoVzDZVGtxRiMOriMAnNUoA;
					}
				}

				[DebuggerHidden]
				public warJiBHqlDDMxMlmGOWPLiNBzvGE(int P_0)
				{
					ZyBUVPuzuzldNeKuFtXhqgJmRngy = P_0;
					HAzyoFQLTUuHbLebPGnlHSngfROx = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int zyBUVPuzuzldNeKuFtXhqgJmRngy = ZyBUVPuzuzldNeKuFtXhqgJmRngy;
					Platform_PS4_Base dwAlQrBZUtRZbdUYaiufeFRAFlAB = DwAlQrBZUtRZbdUYaiufeFRAFlAB;
					switch (zyBUVPuzuzldNeKuFtXhqgJmRngy)
					{
					default:
						return false;
					case 0:
						ZyBUVPuzuzldNeKuFtXhqgJmRngy = -1;
						if (dwAlQrBZUtRZbdUYaiufeFRAFlAB.elements == null || dwAlQrBZUtRZbdUYaiufeFRAFlAB.elements.axes == null)
						{
							return false;
						}
						vXOanBHJSqmwsfHvRKNAJiMEMEFZ = 0;
						break;
					case 1:
						ZyBUVPuzuzldNeKuFtXhqgJmRngy = -1;
						vXOanBHJSqmwsfHvRKNAJiMEMEFZ++;
						break;
					}
					if (vXOanBHJSqmwsfHvRKNAJiMEMEFZ < dwAlQrBZUtRZbdUYaiufeFRAFlAB.elements.axes.Length)
					{
						VSnFlaFoVzDZVGtxRiMOriMAnNUoA = dwAlQrBZUtRZbdUYaiufeFRAFlAB.elements.axes[vXOanBHJSqmwsfHvRKNAJiMEMEFZ];
						ZyBUVPuzuzldNeKuFtXhqgJmRngy = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					warJiBHqlDDMxMlmGOWPLiNBzvGE warJiBHqlDDMxMlmGOWPLiNBzvGE2;
					if (ZyBUVPuzuzldNeKuFtXhqgJmRngy == -2 && HAzyoFQLTUuHbLebPGnlHSngfROx == Environment.CurrentManagedThreadId)
					{
						ZyBUVPuzuzldNeKuFtXhqgJmRngy = 0;
						warJiBHqlDDMxMlmGOWPLiNBzvGE2 = this;
					}
					else
					{
						warJiBHqlDDMxMlmGOWPLiNBzvGE2 = new warJiBHqlDDMxMlmGOWPLiNBzvGE(0);
						warJiBHqlDDMxMlmGOWPLiNBzvGE2.DwAlQrBZUtRZbdUYaiufeFRAFlAB = DwAlQrBZUtRZbdUYaiufeFRAFlAB;
					}
					return warJiBHqlDDMxMlmGOWPLiNBzvGE2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class rjbLUXgKPEAzMGFTjNLAEpirxgmu : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int VvnBVYHZvJyFfjbcCHUjiwvpvqTS;

				private Platform_Custom.Button UYXYlwbSeFhCpIJvdevqjJnaufaA;

				private int HzMivGzkhneOthptTHwmoCMXQAud;

				public Platform_PS4_Base jdXvSjbmPtDODcxAHdgRklvkqWgR;

				private int WqUhgzldcOwIXWjlQCKGRMogfyBr;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return UYXYlwbSeFhCpIJvdevqjJnaufaA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return UYXYlwbSeFhCpIJvdevqjJnaufaA;
					}
				}

				[DebuggerHidden]
				public rjbLUXgKPEAzMGFTjNLAEpirxgmu(int P_0)
				{
					VvnBVYHZvJyFfjbcCHUjiwvpvqTS = P_0;
					HzMivGzkhneOthptTHwmoCMXQAud = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int vvnBVYHZvJyFfjbcCHUjiwvpvqTS = VvnBVYHZvJyFfjbcCHUjiwvpvqTS;
					Platform_PS4_Base platform_PS4_Base = jdXvSjbmPtDODcxAHdgRklvkqWgR;
					switch (vvnBVYHZvJyFfjbcCHUjiwvpvqTS)
					{
					default:
						return false;
					case 0:
						VvnBVYHZvJyFfjbcCHUjiwvpvqTS = -1;
						if (platform_PS4_Base.elements == null || platform_PS4_Base.elements.buttons == null)
						{
							return false;
						}
						WqUhgzldcOwIXWjlQCKGRMogfyBr = 0;
						break;
					case 1:
						VvnBVYHZvJyFfjbcCHUjiwvpvqTS = -1;
						WqUhgzldcOwIXWjlQCKGRMogfyBr++;
						break;
					}
					if (WqUhgzldcOwIXWjlQCKGRMogfyBr < platform_PS4_Base.elements.buttons.Length)
					{
						UYXYlwbSeFhCpIJvdevqjJnaufaA = platform_PS4_Base.elements.buttons[WqUhgzldcOwIXWjlQCKGRMogfyBr];
						VvnBVYHZvJyFfjbcCHUjiwvpvqTS = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					rjbLUXgKPEAzMGFTjNLAEpirxgmu rjbLUXgKPEAzMGFTjNLAEpirxgmu2;
					if (VvnBVYHZvJyFfjbcCHUjiwvpvqTS == -2 && HzMivGzkhneOthptTHwmoCMXQAud == Environment.CurrentManagedThreadId)
					{
						VvnBVYHZvJyFfjbcCHUjiwvpvqTS = 0;
						rjbLUXgKPEAzMGFTjNLAEpirxgmu2 = this;
					}
					else
					{
						rjbLUXgKPEAzMGFTjNLAEpirxgmu2 = new rjbLUXgKPEAzMGFTjNLAEpirxgmu(0);
						rjbLUXgKPEAzMGFTjNLAEpirxgmu2.jdXvSjbmPtDODcxAHdgRklvkqWgR = jdXvSjbmPtDODcxAHdgRklvkqWgR;
					}
					return rjbLUXgKPEAzMGFTjNLAEpirxgmu2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			InputPlatform Platform.platform => InputPlatform.PS4;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
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

			bool Platform.hasData
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

			bool Platform.disabled
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

			bool Platform.isAllowed
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

			Elements_Base Platform.elements_base => elements;

			IList<Platform> Platform.variants_base => null;

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

			[IteratorStateMachine(typeof(warJiBHqlDDMxMlmGOWPLiNBzvGE))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new warJiBHqlDDMxMlmGOWPLiNBzvGE(-2)
				{
					DwAlQrBZUtRZbdUYaiufeFRAFlAB = this
				};
			}

			[IteratorStateMachine(typeof(rjbLUXgKPEAzMGFTjNLAEpirxgmu))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new rjbLUXgKPEAzMGFTjNLAEpirxgmu(-2)
				{
					jdXvSjbmPtDODcxAHdgRklvkqWgR = this
				};
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.axes[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.buttons[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
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
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
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
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
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
				if (destination is Platform_PS4_Base platform_PS4_Base)
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

			IList<Platform> Platform_PS4_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
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

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
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
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (productName != null)
					{
						for (int i = 0; i < productName.Length; i++)
						{
							string searchFor = productName[i];
							if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
							{
								return true;
							}
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
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
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

				int Elements_Base.axisCount
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
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
				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					_ = destination is Button;
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
					_ = destination is Axis;
				}
			}

			private sealed class FdphZsVLumYGUoZHzkYoiXdSdEJe : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int ejfoyDkUsDjixQHNfqDLukbtTxOd;

				private Platform_Custom.Axis qDiprADZGbVfCcbpJktNgdFXApJo;

				private int HlSBdiXGfAIlAqvPbpufgaXYDteAA;

				public Platform_NintendoSwitch_Base yDUDpVwtUfdNEaCpxCprJBHRKfGVA;

				private int pPAGmbjhmLpTjnawCztsAXYvnBdBA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return qDiprADZGbVfCcbpJktNgdFXApJo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return qDiprADZGbVfCcbpJktNgdFXApJo;
					}
				}

				[DebuggerHidden]
				public FdphZsVLumYGUoZHzkYoiXdSdEJe(int P_0)
				{
					ejfoyDkUsDjixQHNfqDLukbtTxOd = P_0;
					HlSBdiXGfAIlAqvPbpufgaXYDteAA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = ejfoyDkUsDjixQHNfqDLukbtTxOd;
					Platform_NintendoSwitch_Base platform_NintendoSwitch_Base = yDUDpVwtUfdNEaCpxCprJBHRKfGVA;
					switch (num)
					{
					default:
						return false;
					case 0:
						ejfoyDkUsDjixQHNfqDLukbtTxOd = -1;
						if (platform_NintendoSwitch_Base.elements == null || platform_NintendoSwitch_Base.elements.axes == null)
						{
							return false;
						}
						pPAGmbjhmLpTjnawCztsAXYvnBdBA = 0;
						break;
					case 1:
						ejfoyDkUsDjixQHNfqDLukbtTxOd = -1;
						pPAGmbjhmLpTjnawCztsAXYvnBdBA++;
						break;
					}
					if (pPAGmbjhmLpTjnawCztsAXYvnBdBA < platform_NintendoSwitch_Base.elements.axes.Length)
					{
						qDiprADZGbVfCcbpJktNgdFXApJo = platform_NintendoSwitch_Base.elements.axes[pPAGmbjhmLpTjnawCztsAXYvnBdBA];
						ejfoyDkUsDjixQHNfqDLukbtTxOd = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					FdphZsVLumYGUoZHzkYoiXdSdEJe fdphZsVLumYGUoZHzkYoiXdSdEJe;
					if (ejfoyDkUsDjixQHNfqDLukbtTxOd == -2 && HlSBdiXGfAIlAqvPbpufgaXYDteAA == Environment.CurrentManagedThreadId)
					{
						ejfoyDkUsDjixQHNfqDLukbtTxOd = 0;
						fdphZsVLumYGUoZHzkYoiXdSdEJe = this;
					}
					else
					{
						fdphZsVLumYGUoZHzkYoiXdSdEJe = new FdphZsVLumYGUoZHzkYoiXdSdEJe(0);
						fdphZsVLumYGUoZHzkYoiXdSdEJe.yDUDpVwtUfdNEaCpxCprJBHRKfGVA = yDUDpVwtUfdNEaCpxCprJBHRKfGVA;
					}
					return fdphZsVLumYGUoZHzkYoiXdSdEJe;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class TcOFQxvAgJpAqOGUPquFEKuvNrSy : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int jArfaWwRzkThrOvgXUVxgkqjrrvq;

				private Platform_Custom.Button mdEcuQyHbRVYjYGCtCoQNvronbDC;

				private int kqIDUmIadCGjmsFlgvtWAnIvZoAN;

				public Platform_NintendoSwitch_Base JOhfJTCezUvctbByuoGUdxJEwMrqb;

				private int TbIdWeetHJUcdrFsaQSdVBzabcGw;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return mdEcuQyHbRVYjYGCtCoQNvronbDC;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return mdEcuQyHbRVYjYGCtCoQNvronbDC;
					}
				}

				[DebuggerHidden]
				public TcOFQxvAgJpAqOGUPquFEKuvNrSy(int P_0)
				{
					jArfaWwRzkThrOvgXUVxgkqjrrvq = P_0;
					kqIDUmIadCGjmsFlgvtWAnIvZoAN = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = jArfaWwRzkThrOvgXUVxgkqjrrvq;
					Platform_NintendoSwitch_Base jOhfJTCezUvctbByuoGUdxJEwMrqb = JOhfJTCezUvctbByuoGUdxJEwMrqb;
					switch (num)
					{
					default:
						return false;
					case 0:
						jArfaWwRzkThrOvgXUVxgkqjrrvq = -1;
						if (jOhfJTCezUvctbByuoGUdxJEwMrqb.elements == null || jOhfJTCezUvctbByuoGUdxJEwMrqb.elements.buttons == null)
						{
							return false;
						}
						TbIdWeetHJUcdrFsaQSdVBzabcGw = 0;
						break;
					case 1:
						jArfaWwRzkThrOvgXUVxgkqjrrvq = -1;
						TbIdWeetHJUcdrFsaQSdVBzabcGw++;
						break;
					}
					if (TbIdWeetHJUcdrFsaQSdVBzabcGw < jOhfJTCezUvctbByuoGUdxJEwMrqb.elements.buttons.Length)
					{
						mdEcuQyHbRVYjYGCtCoQNvronbDC = jOhfJTCezUvctbByuoGUdxJEwMrqb.elements.buttons[TbIdWeetHJUcdrFsaQSdVBzabcGw];
						jArfaWwRzkThrOvgXUVxgkqjrrvq = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					TcOFQxvAgJpAqOGUPquFEKuvNrSy tcOFQxvAgJpAqOGUPquFEKuvNrSy;
					if (jArfaWwRzkThrOvgXUVxgkqjrrvq == -2 && kqIDUmIadCGjmsFlgvtWAnIvZoAN == Environment.CurrentManagedThreadId)
					{
						jArfaWwRzkThrOvgXUVxgkqjrrvq = 0;
						tcOFQxvAgJpAqOGUPquFEKuvNrSy = this;
					}
					else
					{
						tcOFQxvAgJpAqOGUPquFEKuvNrSy = new TcOFQxvAgJpAqOGUPquFEKuvNrSy(0);
						tcOFQxvAgJpAqOGUPquFEKuvNrSy.JOhfJTCezUvctbByuoGUdxJEwMrqb = JOhfJTCezUvctbByuoGUdxJEwMrqb;
					}
					return tcOFQxvAgJpAqOGUPquFEKuvNrSy;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			InputPlatform Platform.platform => InputPlatform.NintendoSwitch;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
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

			bool Platform.hasData
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

			bool Platform.disabled
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

			bool Platform.isAllowed
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

			Elements_Base Platform.elements_base => elements;

			IList<Platform> Platform.variants_base => null;

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

			[IteratorStateMachine(typeof(FdphZsVLumYGUoZHzkYoiXdSdEJe))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new FdphZsVLumYGUoZHzkYoiXdSdEJe(-2)
				{
					yDUDpVwtUfdNEaCpxCprJBHRKfGVA = this
				};
			}

			[IteratorStateMachine(typeof(TcOFQxvAgJpAqOGUPquFEKuvNrSy))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new TcOFQxvAgJpAqOGUPquFEKuvNrSy(-2)
				{
					JOhfJTCezUvctbByuoGUdxJEwMrqb = this
				};
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.axes[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.buttons[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
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
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
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
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
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
				if (destination is Platform_NintendoSwitch_Base platform_NintendoSwitch_Base)
				{
					platform_NintendoSwitch_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_NintendoSwitch_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_NintendoSwitch : Platform_NintendoSwitch_Base
		{
			public Platform_NintendoSwitch_Base[] variants;

			IList<Platform> Platform_NintendoSwitch_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
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
				if (destination is Platform_NintendoSwitch platform_NintendoSwitch)
				{
					platform_NintendoSwitch.variants = MiscTools.DeepClone(variants);
				}
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

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
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
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (productName != null)
					{
						for (int i = 0; i < productName.Length; i++)
						{
							string searchFor = productName[i];
							if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
							{
								return true;
							}
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
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
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

				int Elements_Base.axisCount
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
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
				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					_ = destination is Button;
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
					_ = destination is Axis;
				}
			}

			private sealed class caOXCWQCQgtwBaEbsSdZbjiVkKkN : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int SbbcTifqxpdBBXRzbBJQpGIAHjVGb;

				private Platform_Custom.Axis COXbALhEmjKtsLKhwdozKaXRGBLgA;

				private int xRvzkypnhNRmBwFctwObYrJivFKb;

				public Platform_Stadia_Base dVGWqPDDaiPypLopfIPgYHUePmOQ;

				private int fQOyjZKNlqrHcrkSKlUUdQSJDohBA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return COXbALhEmjKtsLKhwdozKaXRGBLgA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return COXbALhEmjKtsLKhwdozKaXRGBLgA;
					}
				}

				[DebuggerHidden]
				public caOXCWQCQgtwBaEbsSdZbjiVkKkN(int P_0)
				{
					SbbcTifqxpdBBXRzbBJQpGIAHjVGb = P_0;
					xRvzkypnhNRmBwFctwObYrJivFKb = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int sbbcTifqxpdBBXRzbBJQpGIAHjVGb = SbbcTifqxpdBBXRzbBJQpGIAHjVGb;
					Platform_Stadia_Base platform_Stadia_Base = dVGWqPDDaiPypLopfIPgYHUePmOQ;
					switch (sbbcTifqxpdBBXRzbBJQpGIAHjVGb)
					{
					default:
						return false;
					case 0:
						SbbcTifqxpdBBXRzbBJQpGIAHjVGb = -1;
						if (platform_Stadia_Base.elements == null || platform_Stadia_Base.elements.axes == null)
						{
							return false;
						}
						fQOyjZKNlqrHcrkSKlUUdQSJDohBA = 0;
						break;
					case 1:
						SbbcTifqxpdBBXRzbBJQpGIAHjVGb = -1;
						fQOyjZKNlqrHcrkSKlUUdQSJDohBA++;
						break;
					}
					if (fQOyjZKNlqrHcrkSKlUUdQSJDohBA < platform_Stadia_Base.elements.axes.Length)
					{
						COXbALhEmjKtsLKhwdozKaXRGBLgA = platform_Stadia_Base.elements.axes[fQOyjZKNlqrHcrkSKlUUdQSJDohBA];
						SbbcTifqxpdBBXRzbBJQpGIAHjVGb = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					caOXCWQCQgtwBaEbsSdZbjiVkKkN caOXCWQCQgtwBaEbsSdZbjiVkKkN2;
					if (SbbcTifqxpdBBXRzbBJQpGIAHjVGb == -2 && xRvzkypnhNRmBwFctwObYrJivFKb == Environment.CurrentManagedThreadId)
					{
						SbbcTifqxpdBBXRzbBJQpGIAHjVGb = 0;
						caOXCWQCQgtwBaEbsSdZbjiVkKkN2 = this;
					}
					else
					{
						caOXCWQCQgtwBaEbsSdZbjiVkKkN2 = new caOXCWQCQgtwBaEbsSdZbjiVkKkN(0);
						caOXCWQCQgtwBaEbsSdZbjiVkKkN2.dVGWqPDDaiPypLopfIPgYHUePmOQ = dVGWqPDDaiPypLopfIPgYHUePmOQ;
					}
					return caOXCWQCQgtwBaEbsSdZbjiVkKkN2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class UzioKlGHIVcOuGBYUhmBHEGUfdNx : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int OxOKmQVAZNNTqUtcKSwSdzBLLPEh;

				private Platform_Custom.Button MZdUZpcczLqcvnkGLlkzQqhpNozp;

				private int UoODqsslLlJDCAhkUcdGrzJEikuG;

				public Platform_Stadia_Base xosFfpKrHxbfTbgdjJGCgPwaFrRtc;

				private int dadIEDagTbnsBekudLaPxgnBXChN;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return MZdUZpcczLqcvnkGLlkzQqhpNozp;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return MZdUZpcczLqcvnkGLlkzQqhpNozp;
					}
				}

				[DebuggerHidden]
				public UzioKlGHIVcOuGBYUhmBHEGUfdNx(int P_0)
				{
					OxOKmQVAZNNTqUtcKSwSdzBLLPEh = P_0;
					UoODqsslLlJDCAhkUcdGrzJEikuG = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int oxOKmQVAZNNTqUtcKSwSdzBLLPEh = OxOKmQVAZNNTqUtcKSwSdzBLLPEh;
					Platform_Stadia_Base platform_Stadia_Base = xosFfpKrHxbfTbgdjJGCgPwaFrRtc;
					switch (oxOKmQVAZNNTqUtcKSwSdzBLLPEh)
					{
					default:
						return false;
					case 0:
						OxOKmQVAZNNTqUtcKSwSdzBLLPEh = -1;
						if (platform_Stadia_Base.elements == null || platform_Stadia_Base.elements.buttons == null)
						{
							return false;
						}
						dadIEDagTbnsBekudLaPxgnBXChN = 0;
						break;
					case 1:
						OxOKmQVAZNNTqUtcKSwSdzBLLPEh = -1;
						dadIEDagTbnsBekudLaPxgnBXChN++;
						break;
					}
					if (dadIEDagTbnsBekudLaPxgnBXChN < platform_Stadia_Base.elements.buttons.Length)
					{
						MZdUZpcczLqcvnkGLlkzQqhpNozp = platform_Stadia_Base.elements.buttons[dadIEDagTbnsBekudLaPxgnBXChN];
						OxOKmQVAZNNTqUtcKSwSdzBLLPEh = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					UzioKlGHIVcOuGBYUhmBHEGUfdNx uzioKlGHIVcOuGBYUhmBHEGUfdNx;
					if (OxOKmQVAZNNTqUtcKSwSdzBLLPEh == -2 && UoODqsslLlJDCAhkUcdGrzJEikuG == Environment.CurrentManagedThreadId)
					{
						OxOKmQVAZNNTqUtcKSwSdzBLLPEh = 0;
						uzioKlGHIVcOuGBYUhmBHEGUfdNx = this;
					}
					else
					{
						uzioKlGHIVcOuGBYUhmBHEGUfdNx = new UzioKlGHIVcOuGBYUhmBHEGUfdNx(0);
						uzioKlGHIVcOuGBYUhmBHEGUfdNx.xosFfpKrHxbfTbgdjJGCgPwaFrRtc = xosFfpKrHxbfTbgdjJGCgPwaFrRtc;
					}
					return uzioKlGHIVcOuGBYUhmBHEGUfdNx;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public string controllerName;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			string Platform.controllerNameOverride => controllerName;

			InputPlatform Platform.platform => InputPlatform.Stadia;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
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

			bool Platform.hasData
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

			bool Platform.disabled
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

			bool Platform.isAllowed
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

			Elements_Base Platform.elements_base => elements;

			IList<Platform> Platform.variants_base => null;

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

			[IteratorStateMachine(typeof(caOXCWQCQgtwBaEbsSdZbjiVkKkN))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new caOXCWQCQgtwBaEbsSdZbjiVkKkN(-2)
				{
					dVGWqPDDaiPypLopfIPgYHUePmOQ = this
				};
			}

			[IteratorStateMachine(typeof(UzioKlGHIVcOuGBYUhmBHEGUfdNx))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new UzioKlGHIVcOuGBYUhmBHEGUfdNx(-2)
				{
					xosFfpKrHxbfTbgdjJGCgPwaFrRtc = this
				};
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.axes[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.buttons[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
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
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
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
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
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

			IList<Platform> Platform_Stadia_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
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
				if (destination is Platform_Stadia platform_Stadia)
				{
					platform_Stadia.variants = MiscTools.DeepClone(variants);
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

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						if (deviceType != DeviceType.None)
						{
							return true;
						}
						if (vidPid != null && vidPid.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
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
					if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
					{
						return true;
					}
					if (alwaysMatch)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (!ElementCountsMatch(bridgedControllerHWInfo, out var _))
					{
						return false;
					}
					if (deviceType != DeviceType.None)
					{
						if (deviceType != (DeviceType)bridgedControllerHWInfo.deviceType)
						{
							return false;
						}
						if (deviceType == DeviceType.Gamepad && gamepadSubType != GamepadSubType.None && gamepadSubType != (GamepadSubType)bridgedControllerHWInfo.hw_xInputSubType)
						{
							return false;
						}
						if ((!HasProductName() && vidPid == null) || vidPid.Length == 0)
						{
							return true;
						}
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (strictMatch)
					{
						if (vidPid != null)
						{
							for (int i = 0; i < vidPid.Length; i++)
							{
								int vendorId = vidPid[i].vendorId;
								int productId = vidPid[i].productId;
								if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
								{
									string name = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
									if (!ProductNameMatches(name))
									{
										return false;
									}
								}
								if (bridgedControllerHWInfo.hw_vendorId == vendorId && bridgedControllerHWInfo.hw_productId == productId)
								{
									return true;
								}
							}
						}
						return false;
					}
					return ProductNameMatches(text);
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
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.deviceType = deviceType;
						matchingCriteria.gamepadSubType = gamepadSubType;
						matchingCriteria.hatCount = hatCount;
						matchingCriteria.vidPid = ArrayTools.ShallowCopy(vidPid);
					}
				}

				private bool HasProductName()
				{
					if (productName == null)
					{
						return false;
					}
					for (int i = 0; i < productName.Length; i++)
					{
						if (!string.IsNullOrEmpty(productName[i]))
						{
							return true;
						}
					}
					return false;
				}

				private bool ProductNameMatches(string name)
				{
					if (productName == null)
					{
						return false;
					}
					for (int i = 0; i < productName.Length; i++)
					{
						string searchFor = productName[i];
						if (MatchingCriteria_Base.StringMatches(name, searchFor, productName_useRegex))
						{
							return true;
						}
					}
					return false;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
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

				int Elements_Base.axisCount
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						case 2:
							axisRange = axes[i].sourceHatRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						default:
							throw new NotImplementedException();
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
					if (destination is Button button)
					{
						button.sourceHat = sourceHat;
						button.sourceHatDirection = sourceHatDirection;
						button.sourceHatType = sourceHatType;
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

			private sealed class jXiPjslFajsLXsPYbvFfKsbAlwJl : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int trSeidFvevnatFRAqeuAspkwjbfWA;

				private Platform_Custom.Axis pVknJpDBCpRBimFbDqyvvUKtXSaF;

				private int NEUQlUABKYfMIgPzKZsiakYbzoILA;

				public Platform_GameCore_Base VdVnTjSlGMooJCWMEZWBHIlrwIEl;

				private int XoeLPvNotfSrpNwFzbSTHhAeCpzHA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return pVknJpDBCpRBimFbDqyvvUKtXSaF;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return pVknJpDBCpRBimFbDqyvvUKtXSaF;
					}
				}

				[DebuggerHidden]
				public jXiPjslFajsLXsPYbvFfKsbAlwJl(int P_0)
				{
					trSeidFvevnatFRAqeuAspkwjbfWA = P_0;
					NEUQlUABKYfMIgPzKZsiakYbzoILA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = trSeidFvevnatFRAqeuAspkwjbfWA;
					Platform_GameCore_Base vdVnTjSlGMooJCWMEZWBHIlrwIEl = VdVnTjSlGMooJCWMEZWBHIlrwIEl;
					switch (num)
					{
					default:
						return false;
					case 0:
						trSeidFvevnatFRAqeuAspkwjbfWA = -1;
						if (vdVnTjSlGMooJCWMEZWBHIlrwIEl.elements == null || vdVnTjSlGMooJCWMEZWBHIlrwIEl.elements.axes == null)
						{
							return false;
						}
						XoeLPvNotfSrpNwFzbSTHhAeCpzHA = 0;
						break;
					case 1:
						trSeidFvevnatFRAqeuAspkwjbfWA = -1;
						XoeLPvNotfSrpNwFzbSTHhAeCpzHA++;
						break;
					}
					if (XoeLPvNotfSrpNwFzbSTHhAeCpzHA < vdVnTjSlGMooJCWMEZWBHIlrwIEl.elements.axes.Length)
					{
						pVknJpDBCpRBimFbDqyvvUKtXSaF = vdVnTjSlGMooJCWMEZWBHIlrwIEl.elements.axes[XoeLPvNotfSrpNwFzbSTHhAeCpzHA];
						trSeidFvevnatFRAqeuAspkwjbfWA = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					jXiPjslFajsLXsPYbvFfKsbAlwJl jXiPjslFajsLXsPYbvFfKsbAlwJl2;
					if (trSeidFvevnatFRAqeuAspkwjbfWA == -2 && NEUQlUABKYfMIgPzKZsiakYbzoILA == Environment.CurrentManagedThreadId)
					{
						trSeidFvevnatFRAqeuAspkwjbfWA = 0;
						jXiPjslFajsLXsPYbvFfKsbAlwJl2 = this;
					}
					else
					{
						jXiPjslFajsLXsPYbvFfKsbAlwJl2 = new jXiPjslFajsLXsPYbvFfKsbAlwJl(0);
						jXiPjslFajsLXsPYbvFfKsbAlwJl2.VdVnTjSlGMooJCWMEZWBHIlrwIEl = VdVnTjSlGMooJCWMEZWBHIlrwIEl;
					}
					return jXiPjslFajsLXsPYbvFfKsbAlwJl2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class BCOoxMfPvLcPUXkyGbRciutBTKIpA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int rEHrirCalZBWFhuMOgAUiNKBkmxlA;

				private Platform_Custom.Button xvSxUkonvlBLLFvgOJZCEPbhByhlc;

				private int ZsSUIeIefALHWrkqASgGljpgIuDc;

				public Platform_GameCore_Base PyjPYqJVIYMMuajVVhutLHKHvkwE;

				private int tfxXVmEBumyYrowHVSUMonDkxNoj;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return xvSxUkonvlBLLFvgOJZCEPbhByhlc;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return xvSxUkonvlBLLFvgOJZCEPbhByhlc;
					}
				}

				[DebuggerHidden]
				public BCOoxMfPvLcPUXkyGbRciutBTKIpA(int P_0)
				{
					rEHrirCalZBWFhuMOgAUiNKBkmxlA = P_0;
					ZsSUIeIefALHWrkqASgGljpgIuDc = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = rEHrirCalZBWFhuMOgAUiNKBkmxlA;
					Platform_GameCore_Base pyjPYqJVIYMMuajVVhutLHKHvkwE = PyjPYqJVIYMMuajVVhutLHKHvkwE;
					switch (num)
					{
					default:
						return false;
					case 0:
						rEHrirCalZBWFhuMOgAUiNKBkmxlA = -1;
						if (pyjPYqJVIYMMuajVVhutLHKHvkwE.elements == null || pyjPYqJVIYMMuajVVhutLHKHvkwE.elements.buttons == null)
						{
							return false;
						}
						tfxXVmEBumyYrowHVSUMonDkxNoj = 0;
						break;
					case 1:
						rEHrirCalZBWFhuMOgAUiNKBkmxlA = -1;
						tfxXVmEBumyYrowHVSUMonDkxNoj++;
						break;
					}
					if (tfxXVmEBumyYrowHVSUMonDkxNoj < pyjPYqJVIYMMuajVVhutLHKHvkwE.elements.buttons.Length)
					{
						xvSxUkonvlBLLFvgOJZCEPbhByhlc = pyjPYqJVIYMMuajVVhutLHKHvkwE.elements.buttons[tfxXVmEBumyYrowHVSUMonDkxNoj];
						rEHrirCalZBWFhuMOgAUiNKBkmxlA = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					BCOoxMfPvLcPUXkyGbRciutBTKIpA bCOoxMfPvLcPUXkyGbRciutBTKIpA;
					if (rEHrirCalZBWFhuMOgAUiNKBkmxlA == -2 && ZsSUIeIefALHWrkqASgGljpgIuDc == Environment.CurrentManagedThreadId)
					{
						rEHrirCalZBWFhuMOgAUiNKBkmxlA = 0;
						bCOoxMfPvLcPUXkyGbRciutBTKIpA = this;
					}
					else
					{
						bCOoxMfPvLcPUXkyGbRciutBTKIpA = new BCOoxMfPvLcPUXkyGbRciutBTKIpA(0);
						bCOoxMfPvLcPUXkyGbRciutBTKIpA.PyjPYqJVIYMMuajVVhutLHKHvkwE = PyjPYqJVIYMMuajVVhutLHKHvkwE;
					}
					return bCOoxMfPvLcPUXkyGbRciutBTKIpA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public string controllerName;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			string Platform.controllerNameOverride => controllerName;

			InputPlatform Platform.platform => InputPlatform.GameCore;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
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

			bool Platform.hasData
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

			bool Platform.disabled
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

			bool Platform.isAllowed
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

			Elements_Base Platform.elements_base => elements;

			IList<Platform> Platform.variants_base => null;

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

			[IteratorStateMachine(typeof(jXiPjslFajsLXsPYbvFfKsbAlwJl))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new jXiPjslFajsLXsPYbvFfKsbAlwJl(-2)
				{
					VdVnTjSlGMooJCWMEZWBHIlrwIEl = this
				};
			}

			[IteratorStateMachine(typeof(BCOoxMfPvLcPUXkyGbRciutBTKIpA))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new BCOoxMfPvLcPUXkyGbRciutBTKIpA(-2)
				{
					PyjPYqJVIYMMuajVVhutLHKHvkwE = this
				};
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.axes[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.buttons[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
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
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0 && axes_orig[i].sourceType != 2)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
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
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0 || Axes_orig[i].sourceType == 2)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
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
				if (destination is Platform_GameCore_Base platform_GameCore_Base)
				{
					platform_GameCore_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_GameCore_Base.elements = MiscTools.DeepClone(elements);
					platform_GameCore_Base.controllerName = controllerName;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_GameCore : Platform_GameCore_Base
		{
			public Platform_GameCore_Base[] variants;

			IList<Platform> Platform_GameCore_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
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
				if (destination is Platform_GameCore platform_GameCore)
				{
					platform_GameCore.variants = MiscTools.DeepClone(variants);
				}
			}

			internal static Platform_GameCore CreateDefaultMap(BridgedControllerHWInfo bridgedController)
			{
				Platform_GameCore platform_GameCore = new Platform_GameCore();
				_ = Consts.unknownJoystickElementIdentifiers_orig;
				platform_GameCore.controllerName = "Unknown Controller";
				platform_GameCore.description = "";
				Elements elements = (platform_GameCore.elements = new Elements());
				int num = 32;
				elements.axes = new Axis[num];
				for (int i = 0; i < num; i++)
				{
					Axis axis = new Axis();
					elements.axes[i] = axis;
					axis.axisDeadZone = 0.1f;
					axis.axisInfo = HardwareAxisInfo.Default;
					axis.axisMin = -1f;
					axis.axisMax = 1f;
					axis.axisZero = 0f;
					axis.calibrateAxis = false;
					axis.buttonAxisContribution = Pole.Positive;
					axis.elementIdentifier = i;
					axis.invert = false;
					axis.sourceAxis = i;
					axis.sourceAxisRange = AxisRange.Full;
					axis.sourceType = 1;
				}
				int num2 = 128;
				int num3 = 2 * 8;
				elements.buttons = new Button[num2 + num3];
				for (int j = 0; j < num2; j++)
				{
					Button button = new Button();
					elements.buttons[j] = button;
					button.buttonInfo = new HardwareButtonInfo(false, false);
					button.elementIdentifier = 32 + j;
					button.sourceButton = j;
					button.sourceType = 0;
				}
				int num4 = num2;
				int num5 = 160;
				int num6 = 224;
				for (int k = 0; k < 2; k++)
				{
					for (int l = 0; l < 8; l++)
					{
						bool flag = l % 2 == 0;
						Button button2 = new Button();
						elements.buttons[num4++] = button2;
						button2.buttonInfo = new HardwareButtonInfo(false, false);
						button2.elementIdentifier = (flag ? num5++ : num6++);
						button2.sourceHat = k;
						button2.sourceType = 2;
						button2.sourceHatDirection = (HatDirection)(flag ? (l / 2) : (4 + l / 2));
					}
				}
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				platform_GameCore.matchingCriteria = matchingCriteria;
				platform_GameCore.variants = new Platform_GameCore_Base[0];
				return platform_GameCore;
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

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
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
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (productName != null)
					{
						for (int i = 0; i < productName.Length; i++)
						{
							string searchFor = productName[i];
							if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
							{
								return true;
							}
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
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
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

				int Elements_Base.axisCount
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
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
				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					_ = destination is Button;
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
					_ = destination is Axis;
				}
			}

			private sealed class AjyPnNgzUVsrAmeokVtquJczpvgU : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int LYRYnnxWqrIJecBuFdBKCeLKzIJiA;

				private Platform_Custom.Axis ytHkpUnxZPSiEzoCwiznANHQGKPIb;

				private int blQdATHCthEiiueUikNGhyBIzmil;

				public Platform_PS5_Base EYZPAIXkoXvqtImULSKuqiSevqLG;

				private int yvlkBEHJzTskiOJHRRwVdWiMUfog;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ytHkpUnxZPSiEzoCwiznANHQGKPIb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ytHkpUnxZPSiEzoCwiznANHQGKPIb;
					}
				}

				[DebuggerHidden]
				public AjyPnNgzUVsrAmeokVtquJczpvgU(int P_0)
				{
					LYRYnnxWqrIJecBuFdBKCeLKzIJiA = P_0;
					blQdATHCthEiiueUikNGhyBIzmil = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int lYRYnnxWqrIJecBuFdBKCeLKzIJiA = LYRYnnxWqrIJecBuFdBKCeLKzIJiA;
					Platform_PS5_Base eYZPAIXkoXvqtImULSKuqiSevqLG = EYZPAIXkoXvqtImULSKuqiSevqLG;
					switch (lYRYnnxWqrIJecBuFdBKCeLKzIJiA)
					{
					default:
						return false;
					case 0:
						LYRYnnxWqrIJecBuFdBKCeLKzIJiA = -1;
						if (eYZPAIXkoXvqtImULSKuqiSevqLG.elements == null || eYZPAIXkoXvqtImULSKuqiSevqLG.elements.axes == null)
						{
							return false;
						}
						yvlkBEHJzTskiOJHRRwVdWiMUfog = 0;
						break;
					case 1:
						LYRYnnxWqrIJecBuFdBKCeLKzIJiA = -1;
						yvlkBEHJzTskiOJHRRwVdWiMUfog++;
						break;
					}
					if (yvlkBEHJzTskiOJHRRwVdWiMUfog < eYZPAIXkoXvqtImULSKuqiSevqLG.elements.axes.Length)
					{
						ytHkpUnxZPSiEzoCwiznANHQGKPIb = eYZPAIXkoXvqtImULSKuqiSevqLG.elements.axes[yvlkBEHJzTskiOJHRRwVdWiMUfog];
						LYRYnnxWqrIJecBuFdBKCeLKzIJiA = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					AjyPnNgzUVsrAmeokVtquJczpvgU ajyPnNgzUVsrAmeokVtquJczpvgU;
					if (LYRYnnxWqrIJecBuFdBKCeLKzIJiA == -2 && blQdATHCthEiiueUikNGhyBIzmil == Environment.CurrentManagedThreadId)
					{
						LYRYnnxWqrIJecBuFdBKCeLKzIJiA = 0;
						ajyPnNgzUVsrAmeokVtquJczpvgU = this;
					}
					else
					{
						ajyPnNgzUVsrAmeokVtquJczpvgU = new AjyPnNgzUVsrAmeokVtquJczpvgU(0);
						ajyPnNgzUVsrAmeokVtquJczpvgU.EYZPAIXkoXvqtImULSKuqiSevqLG = EYZPAIXkoXvqtImULSKuqiSevqLG;
					}
					return ajyPnNgzUVsrAmeokVtquJczpvgU;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class XcXmoWndbIDzdehOhYvvFEbkerwE : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int GyUdpdcEynRqVAETJxcuuqXgMQnT;

				private Platform_Custom.Button aaPgMnbGsZwURymCFVaOSnEyfpED;

				private int qsQpOdPOvsDGCeJOxdyTlXTEzivN;

				public Platform_PS5_Base WSBjfwltybXVfVJMkcqovDVfLRrF;

				private int mxgobngGfDhmetmEOdFCcIxiMixkA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return aaPgMnbGsZwURymCFVaOSnEyfpED;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return aaPgMnbGsZwURymCFVaOSnEyfpED;
					}
				}

				[DebuggerHidden]
				public XcXmoWndbIDzdehOhYvvFEbkerwE(int P_0)
				{
					GyUdpdcEynRqVAETJxcuuqXgMQnT = P_0;
					qsQpOdPOvsDGCeJOxdyTlXTEzivN = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int gyUdpdcEynRqVAETJxcuuqXgMQnT = GyUdpdcEynRqVAETJxcuuqXgMQnT;
					Platform_PS5_Base wSBjfwltybXVfVJMkcqovDVfLRrF = WSBjfwltybXVfVJMkcqovDVfLRrF;
					switch (gyUdpdcEynRqVAETJxcuuqXgMQnT)
					{
					default:
						return false;
					case 0:
						GyUdpdcEynRqVAETJxcuuqXgMQnT = -1;
						if (wSBjfwltybXVfVJMkcqovDVfLRrF.elements == null || wSBjfwltybXVfVJMkcqovDVfLRrF.elements.buttons == null)
						{
							return false;
						}
						mxgobngGfDhmetmEOdFCcIxiMixkA = 0;
						break;
					case 1:
						GyUdpdcEynRqVAETJxcuuqXgMQnT = -1;
						mxgobngGfDhmetmEOdFCcIxiMixkA++;
						break;
					}
					if (mxgobngGfDhmetmEOdFCcIxiMixkA < wSBjfwltybXVfVJMkcqovDVfLRrF.elements.buttons.Length)
					{
						aaPgMnbGsZwURymCFVaOSnEyfpED = wSBjfwltybXVfVJMkcqovDVfLRrF.elements.buttons[mxgobngGfDhmetmEOdFCcIxiMixkA];
						GyUdpdcEynRqVAETJxcuuqXgMQnT = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					XcXmoWndbIDzdehOhYvvFEbkerwE xcXmoWndbIDzdehOhYvvFEbkerwE;
					if (GyUdpdcEynRqVAETJxcuuqXgMQnT == -2 && qsQpOdPOvsDGCeJOxdyTlXTEzivN == Environment.CurrentManagedThreadId)
					{
						GyUdpdcEynRqVAETJxcuuqXgMQnT = 0;
						xcXmoWndbIDzdehOhYvvFEbkerwE = this;
					}
					else
					{
						xcXmoWndbIDzdehOhYvvFEbkerwE = new XcXmoWndbIDzdehOhYvvFEbkerwE(0);
						xcXmoWndbIDzdehOhYvvFEbkerwE.WSBjfwltybXVfVJMkcqovDVfLRrF = WSBjfwltybXVfVJMkcqovDVfLRrF;
					}
					return xcXmoWndbIDzdehOhYvvFEbkerwE;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public string controllerName;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			string Platform.controllerNameOverride => controllerName;

			InputPlatform Platform.platform => InputPlatform.PS5;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
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

			bool Platform.hasData
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

			bool Platform.disabled
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

			bool Platform.isAllowed
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

			Elements_Base Platform.elements_base => elements;

			IList<Platform> Platform.variants_base => null;

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

			[IteratorStateMachine(typeof(AjyPnNgzUVsrAmeokVtquJczpvgU))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new AjyPnNgzUVsrAmeokVtquJczpvgU(-2)
				{
					EYZPAIXkoXvqtImULSKuqiSevqLG = this
				};
			}

			[IteratorStateMachine(typeof(XcXmoWndbIDzdehOhYvvFEbkerwE))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new XcXmoWndbIDzdehOhYvvFEbkerwE(-2)
				{
					WSBjfwltybXVfVJMkcqovDVfLRrF = this
				};
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.axes[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.buttons[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
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
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
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
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
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
				if (destination is Platform_PS5_Base platform_PS5_Base)
				{
					platform_PS5_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_PS5_Base.elements = MiscTools.DeepClone(elements);
					platform_PS5_Base.controllerName = controllerName;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_PS5 : Platform_PS5_Base
		{
			public Platform_PS5_Base[] variants;

			IList<Platform> Platform_PS5_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
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
				if (destination is Platform_PS5 platform_PS)
				{
					platform_PS.variants = MiscTools.DeepClone(variants);
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

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						if (vidPid != null && vidPid.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
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
					string text = bridgedControllerHWInfo.hw_productName;
					if (text == null)
					{
						text = string.Empty;
					}
					text = text.Trim();
					if (strictMatch)
					{
						if (vidPid != null)
						{
							for (int i = 0; i < vidPid.Length; i++)
							{
								int vendorId = vidPid[i].vendorId;
								int productId = vidPid[i].productId;
								if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
								{
									string name = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
									if (!ProductNameMatches(name))
									{
										return false;
									}
								}
								if (bridgedControllerHWInfo.hw_vendorId == vendorId && bridgedControllerHWInfo.hw_productId == productId)
								{
									return true;
								}
							}
						}
						return false;
					}
					return ProductNameMatches(text);
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
					if (destination is MatchingCriteria matchingCriteria)
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
						return false;
					}
					for (int i = 0; i < productName.Length; i++)
					{
						string searchFor = productName[i];
						if (MatchingCriteria_Base.StringMatches(name, searchFor, productName_useRegex))
						{
							return true;
						}
					}
					return false;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
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

				int Elements_Base.axisCount
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						case 2:
							axisRange = axes[i].sourceHatRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						default:
							throw new NotImplementedException();
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
					if (destination is Button button)
					{
						button.sourceHat = sourceHat;
						button.sourceHatDirection = sourceHatDirection;
						button.sourceHatType = sourceHatType;
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

			private sealed class zcknMRSUTUAdrIwpXChwPSgzewEh : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int PmvcTRNOwvJMzBYdzYdTOjeLhhYg;

				private Platform_Custom.Axis pNCbRIJOfWTNBsauLglafjGJSdVjB;

				private int RWiGkmkwPuuPFKvrKHbRiaxUKxzy;

				public Platform_InternalDriver_Base JJDOJlaBFFCJGWiGMGeaGAmeuLIC;

				private int PpeiREHMuPXWlSeKvTSgaSamMcDd;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return pNCbRIJOfWTNBsauLglafjGJSdVjB;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return pNCbRIJOfWTNBsauLglafjGJSdVjB;
					}
				}

				[DebuggerHidden]
				public zcknMRSUTUAdrIwpXChwPSgzewEh(int P_0)
				{
					PmvcTRNOwvJMzBYdzYdTOjeLhhYg = P_0;
					RWiGkmkwPuuPFKvrKHbRiaxUKxzy = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int pmvcTRNOwvJMzBYdzYdTOjeLhhYg = PmvcTRNOwvJMzBYdzYdTOjeLhhYg;
					Platform_InternalDriver_Base jJDOJlaBFFCJGWiGMGeaGAmeuLIC = JJDOJlaBFFCJGWiGMGeaGAmeuLIC;
					switch (pmvcTRNOwvJMzBYdzYdTOjeLhhYg)
					{
					default:
						return false;
					case 0:
						PmvcTRNOwvJMzBYdzYdTOjeLhhYg = -1;
						if (jJDOJlaBFFCJGWiGMGeaGAmeuLIC.elements == null || jJDOJlaBFFCJGWiGMGeaGAmeuLIC.elements.axes == null)
						{
							return false;
						}
						PpeiREHMuPXWlSeKvTSgaSamMcDd = 0;
						break;
					case 1:
						PmvcTRNOwvJMzBYdzYdTOjeLhhYg = -1;
						PpeiREHMuPXWlSeKvTSgaSamMcDd++;
						break;
					}
					if (PpeiREHMuPXWlSeKvTSgaSamMcDd < jJDOJlaBFFCJGWiGMGeaGAmeuLIC.elements.axes.Length)
					{
						pNCbRIJOfWTNBsauLglafjGJSdVjB = jJDOJlaBFFCJGWiGMGeaGAmeuLIC.elements.axes[PpeiREHMuPXWlSeKvTSgaSamMcDd];
						PmvcTRNOwvJMzBYdzYdTOjeLhhYg = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					zcknMRSUTUAdrIwpXChwPSgzewEh zcknMRSUTUAdrIwpXChwPSgzewEh2;
					if (PmvcTRNOwvJMzBYdzYdTOjeLhhYg == -2 && RWiGkmkwPuuPFKvrKHbRiaxUKxzy == Environment.CurrentManagedThreadId)
					{
						PmvcTRNOwvJMzBYdzYdTOjeLhhYg = 0;
						zcknMRSUTUAdrIwpXChwPSgzewEh2 = this;
					}
					else
					{
						zcknMRSUTUAdrIwpXChwPSgzewEh2 = new zcknMRSUTUAdrIwpXChwPSgzewEh(0);
						zcknMRSUTUAdrIwpXChwPSgzewEh2.JJDOJlaBFFCJGWiGMGeaGAmeuLIC = JJDOJlaBFFCJGWiGMGeaGAmeuLIC;
					}
					return zcknMRSUTUAdrIwpXChwPSgzewEh2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class MPDeAHYYBAdCugoCYliPuOgVCyrk : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int ZBvHyVGXSIzMRsydWDwtkMBcdWLyA;

				private Platform_Custom.Button ckSpXDVRjwoDZJTIyTupesLGUCuX;

				private int tYYahopiQfKdZqPFGOltvUnMEPFh;

				public Platform_InternalDriver_Base zOEOwFyaLrnnYITKrMqYrwqHFOro;

				private int JYrZVKjeeZaHZJFghXLCTSqTkxaS;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ckSpXDVRjwoDZJTIyTupesLGUCuX;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ckSpXDVRjwoDZJTIyTupesLGUCuX;
					}
				}

				[DebuggerHidden]
				public MPDeAHYYBAdCugoCYliPuOgVCyrk(int P_0)
				{
					ZBvHyVGXSIzMRsydWDwtkMBcdWLyA = P_0;
					tYYahopiQfKdZqPFGOltvUnMEPFh = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int zBvHyVGXSIzMRsydWDwtkMBcdWLyA = ZBvHyVGXSIzMRsydWDwtkMBcdWLyA;
					Platform_InternalDriver_Base platform_InternalDriver_Base = zOEOwFyaLrnnYITKrMqYrwqHFOro;
					switch (zBvHyVGXSIzMRsydWDwtkMBcdWLyA)
					{
					default:
						return false;
					case 0:
						ZBvHyVGXSIzMRsydWDwtkMBcdWLyA = -1;
						if (platform_InternalDriver_Base.elements == null || platform_InternalDriver_Base.elements.buttons == null)
						{
							return false;
						}
						JYrZVKjeeZaHZJFghXLCTSqTkxaS = 0;
						break;
					case 1:
						ZBvHyVGXSIzMRsydWDwtkMBcdWLyA = -1;
						JYrZVKjeeZaHZJFghXLCTSqTkxaS++;
						break;
					}
					if (JYrZVKjeeZaHZJFghXLCTSqTkxaS < platform_InternalDriver_Base.elements.buttons.Length)
					{
						ckSpXDVRjwoDZJTIyTupesLGUCuX = platform_InternalDriver_Base.elements.buttons[JYrZVKjeeZaHZJFghXLCTSqTkxaS];
						ZBvHyVGXSIzMRsydWDwtkMBcdWLyA = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					MPDeAHYYBAdCugoCYliPuOgVCyrk mPDeAHYYBAdCugoCYliPuOgVCyrk;
					if (ZBvHyVGXSIzMRsydWDwtkMBcdWLyA == -2 && tYYahopiQfKdZqPFGOltvUnMEPFh == Environment.CurrentManagedThreadId)
					{
						ZBvHyVGXSIzMRsydWDwtkMBcdWLyA = 0;
						mPDeAHYYBAdCugoCYliPuOgVCyrk = this;
					}
					else
					{
						mPDeAHYYBAdCugoCYliPuOgVCyrk = new MPDeAHYYBAdCugoCYliPuOgVCyrk(0);
						mPDeAHYYBAdCugoCYliPuOgVCyrk.zOEOwFyaLrnnYITKrMqYrwqHFOro = zOEOwFyaLrnnYITKrMqYrwqHFOro;
					}
					return mPDeAHYYBAdCugoCYliPuOgVCyrk;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			InputPlatform Platform.platform => InputPlatform.InternalDriver;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
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

			bool Platform.hasData
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

			bool Platform.disabled
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

			bool Platform.isAllowed
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

			Elements_Base Platform.elements_base => elements;

			IList<Platform> Platform.variants_base => null;

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

			[IteratorStateMachine(typeof(zcknMRSUTUAdrIwpXChwPSgzewEh))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new zcknMRSUTUAdrIwpXChwPSgzewEh(-2)
				{
					JJDOJlaBFFCJGWiGMGeaGAmeuLIC = this
				};
			}

			[IteratorStateMachine(typeof(MPDeAHYYBAdCugoCYliPuOgVCyrk))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new MPDeAHYYBAdCugoCYliPuOgVCyrk(-2)
				{
					zOEOwFyaLrnnYITKrMqYrwqHFOro = this
				};
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.axes[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.buttons[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
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
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0 && axes_orig[i].sourceType != 2)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
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
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0 || Axes_orig[i].sourceType == 2)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
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
				if (destination is Platform_InternalDriver_Base platform_InternalDriver_Base)
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

			IList<Platform> Platform_InternalDriver_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
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
				if (destination is Platform_InternalDriver platform_InternalDriver)
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
						eVNCcajJzZqMRDvslhBhZyxbIPSSA(elementCount);
						return elementCount;
					}

					internal void HZEKhTePgRsXVLgmeMHvzDfqPfXe(ElementCount_Base P_0)
					{
						base.eVNCcajJzZqMRDvslhBhZyxbIPSSA(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool AOhSAvsylRRWNJccMZLBGFDtyntT(BridgedControllerHWInfo P_0)
					{
						if (!base.NrIqjnTqXRldcAeRNYVJmqWNDsiO(P_0))
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

				bool MatchingCriteria_Base.hasData
				{
					get
					{
						if (disabled)
						{
							return false;
						}
						if (productGUID != null && productGUID.Length != 0)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool MatchingCriteria_Base.isAllowed
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

				int MatchingCriteria_Base.alternateElementCount => 0;

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
					if (string.IsNullOrEmpty(name) || names == null)
					{
						return false;
					}
					string searchIn = name.Trim();
					for (int i = 0; i < names.Length; i++)
					{
						if (!string.IsNullOrEmpty(names[i]) && MatchingCriteria_Base.StringMatches(searchIn, names[i], useRegex))
						{
							return true;
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
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.hatCount = hatCount;
						matchingCriteria.manufacturer_useRegex = manufacturer_useRegex;
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.systemName_useRegex = systemName_useRegex;
						matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.systemName = ArrayTools.ShallowCopy(systemName);
						matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class QYXSOcSDKMSLwGKhfAfHIVYEiulG : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int wEvOIhvSEsrJFhjWRdMFuMQKpFpN;

					private Axis VVeclSFUZvmpYTXJEYVGAafURIPEA;

					private int MAixSBbVwPKQvKnJLEdPtbsVBDVgA;

					public Elements ubmdkbRYHicdVehKXcadEmlaVybX;

					private int HvLcAyqiuvDUgGYHRERxyTPlQxnE;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return VVeclSFUZvmpYTXJEYVGAafURIPEA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return VVeclSFUZvmpYTXJEYVGAafURIPEA;
						}
					}

					[DebuggerHidden]
					public QYXSOcSDKMSLwGKhfAfHIVYEiulG(int P_0)
					{
						wEvOIhvSEsrJFhjWRdMFuMQKpFpN = P_0;
						MAixSBbVwPKQvKnJLEdPtbsVBDVgA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = wEvOIhvSEsrJFhjWRdMFuMQKpFpN;
						Elements elements = ubmdkbRYHicdVehKXcadEmlaVybX;
						switch (num)
						{
						default:
							return false;
						case 0:
							wEvOIhvSEsrJFhjWRdMFuMQKpFpN = -1;
							if (elements.axes == null)
							{
								return false;
							}
							HvLcAyqiuvDUgGYHRERxyTPlQxnE = 0;
							break;
						case 1:
							wEvOIhvSEsrJFhjWRdMFuMQKpFpN = -1;
							HvLcAyqiuvDUgGYHRERxyTPlQxnE++;
							break;
						}
						if (HvLcAyqiuvDUgGYHRERxyTPlQxnE < elements.axes.Length)
						{
							VVeclSFUZvmpYTXJEYVGAafURIPEA = elements.axes[HvLcAyqiuvDUgGYHRERxyTPlQxnE];
							wEvOIhvSEsrJFhjWRdMFuMQKpFpN = 1;
							return true;
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

					[DebuggerHidden]
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						QYXSOcSDKMSLwGKhfAfHIVYEiulG qYXSOcSDKMSLwGKhfAfHIVYEiulG;
						if (wEvOIhvSEsrJFhjWRdMFuMQKpFpN == -2 && MAixSBbVwPKQvKnJLEdPtbsVBDVgA == Environment.CurrentManagedThreadId)
						{
							wEvOIhvSEsrJFhjWRdMFuMQKpFpN = 0;
							qYXSOcSDKMSLwGKhfAfHIVYEiulG = this;
						}
						else
						{
							qYXSOcSDKMSLwGKhfAfHIVYEiulG = new QYXSOcSDKMSLwGKhfAfHIVYEiulG(0);
							qYXSOcSDKMSLwGKhfAfHIVYEiulG.ubmdkbRYHicdVehKXcadEmlaVybX = ubmdkbRYHicdVehKXcadEmlaVybX;
						}
						return qYXSOcSDKMSLwGKhfAfHIVYEiulG;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class YmFGVEdmNvQFidPcJqppDFQPTnkl : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int uXQXwTLeEYvcdhnWaSgsFIUMncZp;

					private Button pKEDFMFGVqBsgDQibuDAfZVMqiCE;

					private int hCsEYbjKapiDEMyQJqYJcXDeIjkH;

					public Elements RBVgeOAiWVMvTtBJkJfrufZBWvYu;

					private int eREjRKbcclAkJuCgczEmglAqbpaY;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return pKEDFMFGVqBsgDQibuDAfZVMqiCE;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return pKEDFMFGVqBsgDQibuDAfZVMqiCE;
						}
					}

					[DebuggerHidden]
					public YmFGVEdmNvQFidPcJqppDFQPTnkl(int P_0)
					{
						uXQXwTLeEYvcdhnWaSgsFIUMncZp = P_0;
						hCsEYbjKapiDEMyQJqYJcXDeIjkH = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = uXQXwTLeEYvcdhnWaSgsFIUMncZp;
						Elements rBVgeOAiWVMvTtBJkJfrufZBWvYu = RBVgeOAiWVMvTtBJkJfrufZBWvYu;
						switch (num)
						{
						default:
							return false;
						case 0:
							uXQXwTLeEYvcdhnWaSgsFIUMncZp = -1;
							if (rBVgeOAiWVMvTtBJkJfrufZBWvYu.buttons == null)
							{
								return false;
							}
							eREjRKbcclAkJuCgczEmglAqbpaY = 0;
							break;
						case 1:
							uXQXwTLeEYvcdhnWaSgsFIUMncZp = -1;
							eREjRKbcclAkJuCgczEmglAqbpaY++;
							break;
						}
						if (eREjRKbcclAkJuCgczEmglAqbpaY < rBVgeOAiWVMvTtBJkJfrufZBWvYu.buttons.Length)
						{
							pKEDFMFGVqBsgDQibuDAfZVMqiCE = rBVgeOAiWVMvTtBJkJfrufZBWvYu.buttons[eREjRKbcclAkJuCgczEmglAqbpaY];
							uXQXwTLeEYvcdhnWaSgsFIUMncZp = 1;
							return true;
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

					[DebuggerHidden]
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						YmFGVEdmNvQFidPcJqppDFQPTnkl ymFGVEdmNvQFidPcJqppDFQPTnkl;
						if (uXQXwTLeEYvcdhnWaSgsFIUMncZp == -2 && hCsEYbjKapiDEMyQJqYJcXDeIjkH == Environment.CurrentManagedThreadId)
						{
							uXQXwTLeEYvcdhnWaSgsFIUMncZp = 0;
							ymFGVEdmNvQFidPcJqppDFQPTnkl = this;
						}
						else
						{
							ymFGVEdmNvQFidPcJqppDFQPTnkl = new YmFGVEdmNvQFidPcJqppDFQPTnkl(0);
							ymFGVEdmNvQFidPcJqppDFQPTnkl.RBVgeOAiWVMvTtBJkJfrufZBWvYu = RBVgeOAiWVMvTtBJkJfrufZBWvYu;
						}
						return ymFGVEdmNvQFidPcJqppDFQPTnkl;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
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

				int Elements_Base.axisCount
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
					[IteratorStateMachine(typeof(QYXSOcSDKMSLwGKhfAfHIVYEiulG))]
					get
					{
						return new QYXSOcSDKMSLwGKhfAfHIVYEiulG(-2)
						{
							ubmdkbRYHicdVehKXcadEmlaVybX = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(YmFGVEdmNvQFidPcJqppDFQPTnkl))]
					get
					{
						return new YmFGVEdmNvQFidPcJqppDFQPTnkl(-2)
						{
							RBVgeOAiWVMvTtBJkJfrufZBWvYu = this
						};
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Axis:
						case HardwareElementSourceTypeWithHat.Custom:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case HardwareElementSourceTypeWithHat.Button:
							axisRange = AxisRange.Positive;
							return true;
						case HardwareElementSourceTypeWithHat.Hat:
							axisRange = axes[i].sourceHatRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						default:
							throw new NotImplementedException();
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
					if (source is Button button)
					{
						elementIdentifier = button.elementIdentifier;
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
						ignoreIfButtonsActive = button.ignoreIfButtonsActive;
						ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(button.ignoreIfButtonsActiveButtons);
						buttonInfo = MiscTools.DeepClone(button.buttonInfo);
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
					if (source is Axis axis)
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
						sourceButton = axis.sourceButton;
						buttonAxisContribution = axis.buttonAxisContribution;
						sourceHat = axis.sourceHat;
						sourceHatDirection = axis.sourceHatDirection;
						sourceHatRange = axis.sourceHatRange;
						alternateCalibrations = MiscTools.DeepClone(axis.alternateCalibrations);
					}
				}
			}

			private sealed class YPJwfBohEPSdeuqDPksprHWPfZfS : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int YBXythxZRhVAzOcccuayMCZYlHDm;

				private Axis jJQNTwhaKJztJAtjEjSSWGUFOPTp;

				private int bNCFQyeyfCqtLekQZkojuVlKLkPu;

				public Platform_SDL2_Base cyNMGPBReuXICZgbRHexFKzLtVmi;

				private int QwhCHLzOctITLdLAUBQhMRTtRyZg;

				private int KIFAlNdMTmDSUQRDxELpMaArdjyXA;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return jJQNTwhaKJztJAtjEjSSWGUFOPTp;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return jJQNTwhaKJztJAtjEjSSWGUFOPTp;
					}
				}

				[DebuggerHidden]
				public YPJwfBohEPSdeuqDPksprHWPfZfS(int P_0)
				{
					YBXythxZRhVAzOcccuayMCZYlHDm = P_0;
					bNCFQyeyfCqtLekQZkojuVlKLkPu = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int yBXythxZRhVAzOcccuayMCZYlHDm = YBXythxZRhVAzOcccuayMCZYlHDm;
					Platform_SDL2_Base platform_SDL2_Base = cyNMGPBReuXICZgbRHexFKzLtVmi;
					switch (yBXythxZRhVAzOcccuayMCZYlHDm)
					{
					default:
						return false;
					case 0:
						YBXythxZRhVAzOcccuayMCZYlHDm = -1;
						if (platform_SDL2_Base.elements == null || platform_SDL2_Base.elements.axes == null)
						{
							return false;
						}
						QwhCHLzOctITLdLAUBQhMRTtRyZg = platform_SDL2_Base.elements.axes.Length;
						KIFAlNdMTmDSUQRDxELpMaArdjyXA = 0;
						break;
					case 1:
						YBXythxZRhVAzOcccuayMCZYlHDm = -1;
						KIFAlNdMTmDSUQRDxELpMaArdjyXA++;
						break;
					}
					if (KIFAlNdMTmDSUQRDxELpMaArdjyXA < QwhCHLzOctITLdLAUBQhMRTtRyZg)
					{
						jJQNTwhaKJztJAtjEjSSWGUFOPTp = platform_SDL2_Base.elements.axes[KIFAlNdMTmDSUQRDxELpMaArdjyXA];
						YBXythxZRhVAzOcccuayMCZYlHDm = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					YPJwfBohEPSdeuqDPksprHWPfZfS yPJwfBohEPSdeuqDPksprHWPfZfS;
					if (YBXythxZRhVAzOcccuayMCZYlHDm == -2 && bNCFQyeyfCqtLekQZkojuVlKLkPu == Environment.CurrentManagedThreadId)
					{
						YBXythxZRhVAzOcccuayMCZYlHDm = 0;
						yPJwfBohEPSdeuqDPksprHWPfZfS = this;
					}
					else
					{
						yPJwfBohEPSdeuqDPksprHWPfZfS = new YPJwfBohEPSdeuqDPksprHWPfZfS(0);
						yPJwfBohEPSdeuqDPksprHWPfZfS.cyNMGPBReuXICZgbRHexFKzLtVmi = cyNMGPBReuXICZgbRHexFKzLtVmi;
					}
					return yPJwfBohEPSdeuqDPksprHWPfZfS;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class GZqJRZRCwvgXxjEGFEqurwGTWvPA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int blLcuoVQbibHnKRTzcLNUgmfDEMHA;

				private Button PeKFAVgNqivHjPbNQZKcMNNyVwEhA;

				private int arCPeewbltGZCgYWEKCneVrskAJyA;

				public Platform_SDL2_Base wljVeZWtSuPlNsKNiOSJrsFxhEhr;

				private int ySHiyRvZmVEzaonzQbHXWNdVXrLC;

				private int OvQYkPDQXCccxiVZupGbaVNTOFhdA;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return PeKFAVgNqivHjPbNQZKcMNNyVwEhA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return PeKFAVgNqivHjPbNQZKcMNNyVwEhA;
					}
				}

				[DebuggerHidden]
				public GZqJRZRCwvgXxjEGFEqurwGTWvPA(int P_0)
				{
					blLcuoVQbibHnKRTzcLNUgmfDEMHA = P_0;
					arCPeewbltGZCgYWEKCneVrskAJyA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = blLcuoVQbibHnKRTzcLNUgmfDEMHA;
					Platform_SDL2_Base platform_SDL2_Base = wljVeZWtSuPlNsKNiOSJrsFxhEhr;
					switch (num)
					{
					default:
						return false;
					case 0:
						blLcuoVQbibHnKRTzcLNUgmfDEMHA = -1;
						if (platform_SDL2_Base.elements == null || platform_SDL2_Base.elements.buttons == null)
						{
							return false;
						}
						ySHiyRvZmVEzaonzQbHXWNdVXrLC = platform_SDL2_Base.elements.buttons.Length;
						OvQYkPDQXCccxiVZupGbaVNTOFhdA = 0;
						break;
					case 1:
						blLcuoVQbibHnKRTzcLNUgmfDEMHA = -1;
						OvQYkPDQXCccxiVZupGbaVNTOFhdA++;
						break;
					}
					if (OvQYkPDQXCccxiVZupGbaVNTOFhdA < ySHiyRvZmVEzaonzQbHXWNdVXrLC)
					{
						PeKFAVgNqivHjPbNQZKcMNNyVwEhA = platform_SDL2_Base.elements.buttons[OvQYkPDQXCccxiVZupGbaVNTOFhdA];
						blLcuoVQbibHnKRTzcLNUgmfDEMHA = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					GZqJRZRCwvgXxjEGFEqurwGTWvPA gZqJRZRCwvgXxjEGFEqurwGTWvPA;
					if (blLcuoVQbibHnKRTzcLNUgmfDEMHA == -2 && arCPeewbltGZCgYWEKCneVrskAJyA == Environment.CurrentManagedThreadId)
					{
						blLcuoVQbibHnKRTzcLNUgmfDEMHA = 0;
						gZqJRZRCwvgXxjEGFEqurwGTWvPA = this;
					}
					else
					{
						gZqJRZRCwvgXxjEGFEqurwGTWvPA = new GZqJRZRCwvgXxjEGFEqurwGTWvPA(0);
						gZqJRZRCwvgXxjEGFEqurwGTWvPA.wljVeZWtSuPlNsKNiOSJrsFxhEhr = wljVeZWtSuPlNsKNiOSJrsFxhEhr;
					}
					return gZqJRZRCwvgXxjEGFEqurwGTWvPA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			InputPlatform Platform.platform => InputPlatform.SDL2;

			bool Platform.hasData
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

			bool Platform.disabled
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

			bool Platform.isAllowed
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

			IList<Platform> Platform.variants_base => null;

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			Elements_Base Platform.elements_base => elements;

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
				for (int i = 0; i < num2; i++)
				{
					int elementIdentifier = elements.axes[i].elementIdentifier;
					int num3 = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num3 < 0 || num3 >= num)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num3].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
					}
				}
				return array;
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
				for (int i = 0; i < buttonCount; i++)
				{
					int elementIdentifier = elements.buttons[i].elementIdentifier;
					int num2 = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num2 < 0 || num2 >= num)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num2].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
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
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
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
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
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

			[IteratorStateMachine(typeof(YPJwfBohEPSdeuqDPksprHWPfZfS))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new YPJwfBohEPSdeuqDPksprHWPfZfS(-2)
				{
					cyNMGPBReuXICZgbRHexFKzLtVmi = this
				};
			}

			[IteratorStateMachine(typeof(GZqJRZRCwvgXxjEGFEqurwGTWvPA))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new GZqJRZRCwvgXxjEGFEqurwGTWvPA(-2)
				{
					wljVeZWtSuPlNsKNiOSJrsFxhEhr = this
				};
			}

			public override object DeepClone()
			{
				Platform_SDL2_Base platform_SDL2_Base = new Platform_SDL2_Base();
				CopyVars(platform_SDL2_Base);
				return platform_SDL2_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				if (destination is Platform_SDL2_Base platform_SDL2_Base)
				{
					platform_SDL2_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_SDL2 : Platform_SDL2_Base
		{
			public Platform_SDL2_Base[] variants;

			IList<Platform> Platform_SDL2_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
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
				bool MatchingCriteria_Base.hasData => true;

				bool MatchingCriteria_Base.isAllowed
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

				int MatchingCriteria_Base.alternateElementCount => 0;

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
					_ = destination is MatchingCriteria;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				int Elements_Base.buttonCount => 0;

				int Elements_Base.axisCount => 0;

				public override object DeepClone()
				{
					Elements elements = new Elements();
					CopyVars(elements);
					return elements;
				}

				internal override void CopyVars(Elements_Base destination)
				{
					base.CopyVars(destination);
					_ = destination is Elements;
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

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			InputPlatform Platform.platform => InputPlatform.Steam;

			bool Platform.hasData
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

			bool Platform.disabled
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

			bool Platform.isAllowed
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

			Elements_Base Platform.elements_base => elements;

			IList<Platform> Platform.variants_base => null;

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
				if (destination is Platform_Steam_Base platform_Steam_Base)
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

			IList<Platform> Platform_Steam_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
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
						return new ClientInfo
						{
							browser = browser,
							browserVersionMin = browserVersionMin,
							browserVersionMax = browserVersionMax,
							os = os,
							osVersionMin = osVersionMin,
							osVersionMax = osVersionMax
						};
					}

					object IDeepCloneable.DeepClone()
					{
						//ILSpy generated this explicit interface implementation from .override directive in DeepClone
						return this.DeepClone();
					}
				}

				public bool productName_useRegex;

				public string[] productName;

				public string[] productGUID;

				public int[] mapping;

				public ElementCount_Base[] elementCount;

				public ClientInfo[] clientInfo;

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productName != null && productName.Length != 0)
						{
							return true;
						}
						if (mapping != null && mapping.Length != 0)
						{
							return true;
						}
						if (productGUID != null && productGUID.Length != 0)
						{
							return true;
						}
						if (elementCount != null && elementCount.Length != 0)
						{
							return true;
						}
						if (clientInfo != null && clientInfo.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
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
						return false;
					}
					if (alwaysMatch)
					{
						return true;
					}
					bool result = false;
					string text = StringTools.Trim(tag);
					if (!string.IsNullOrEmpty(text) && !string.Equals(bridgedControllerHWInfo.definitionMatchTag, text, StringComparison.OrdinalIgnoreCase))
					{
						return false;
					}
					if (this.clientInfo != null && this.clientInfo.Length != 0)
					{
						bool flag = false;
						for (int i = 0; i < this.clientInfo.Length; i++)
						{
							ClientInfo clientInfo = this.clientInfo[i];
							if (clientInfo == null)
							{
								continue;
							}
							if (clientInfo.browser != 0)
							{
								if (clientInfo.browser != (int)bridgedControllerHWInfo.webGL_webBrowserType)
								{
									continue;
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
									continue;
								}
								if (!CheckOSVersion(clientInfo.osVersionMin, clientInfo.osVersionMax, bridgedControllerHWInfo.webGL_osVersionSplit))
								{
									return false;
								}
							}
							flag = true;
							break;
						}
						if (!flag)
						{
							return false;
						}
						result = true;
					}
					if (elementCount != null && elementCount.Length != 0)
					{
						bool flag2 = false;
						for (int j = 0; j < elementCount.Length; j++)
						{
							ElementCount_Base elementCount_Base = elementCount[j];
							if (elementCount_Base != null && (elementCount_Base.buttonCount < 0 || elementCount_Base.buttonCount == bridgedControllerHWInfo.hardwareButtonCount) && (elementCount_Base.axisCount < 0 || elementCount_Base.axisCount == bridgedControllerHWInfo.hardwareAxisCount))
							{
								flag2 = true;
							}
						}
						if (!flag2)
						{
							return false;
						}
						result = true;
					}
					if (mapping != null && mapping.Length != 0)
					{
						bool flag3 = false;
						for (int k = 0; k < mapping.Length; k++)
						{
							if (mapping[k] == (int)bridgedControllerHWInfo.webGL_mappingType)
							{
								flag3 = true;
							}
						}
						if (!flag3)
						{
							return false;
						}
						result = true;
					}
					bool flag4 = false;
					bool flag5 = false;
					if (productGUID != null && productGUID.Length != 0 && !ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
					{
						flag5 = true;
						for (int l = 0; l < productGUID.Length; l++)
						{
							if (bridgedControllerHWInfo.hw_pidVid.Equals(productGUID[l]))
							{
								flag4 = true;
								break;
							}
						}
					}
					if (flag4)
					{
						return true;
					}
					string text2 = StringTools.Trim(bridgedControllerHWInfo.hw_productName);
					if (text2 == null)
					{
						text2 = string.Empty;
					}
					if (productName != null && productName.Length != 0)
					{
						flag5 = true;
						for (int m = 0; m < productName.Length; m++)
						{
							string searchFor = productName[m];
							if (MatchingCriteria_Base.StringMatches(text2, searchFor, productName_useRegex))
							{
								flag4 = true;
								break;
							}
						}
					}
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
					if (!flag && !flag2)
					{
						return true;
					}
					if (currentVersion == null || currentVersion.Length == 0)
					{
						return false;
					}
					switch (browser)
					{
					case -1:
					case 0:
						return true;
					default:
						if (flag)
						{
							string[] array = versionMin.Split('.');
							int num = MathTools.Min(array.Length, currentVersion.Length);
							bool flag3 = false;
							for (int i = 0; i < num; i++)
							{
								int result;
								bool flag4 = int.TryParse(array[i], out result);
								int result2;
								bool flag5 = int.TryParse(currentVersion[i], out result2);
								if (flag4 && !flag5)
								{
									return false;
								}
								if (!flag4)
								{
									break;
								}
								if (result2 < result)
								{
									return false;
								}
								flag3 = true;
							}
							if (!flag3)
							{
								return false;
							}
						}
						if (flag2)
						{
							string[] array2 = versionMax.Split('.');
							int num2 = MathTools.Min(array2.Length, currentVersion.Length);
							bool flag6 = false;
							for (int j = 0; j < num2; j++)
							{
								int result3;
								bool flag7 = int.TryParse(array2[j], out result3);
								int result4;
								bool flag8 = int.TryParse(currentVersion[j], out result4);
								if (flag7 && !flag8)
								{
									return false;
								}
								if (!flag7)
								{
									break;
								}
								if (result4 > result3)
								{
									return false;
								}
								flag6 = true;
							}
							if (!flag6)
							{
								return false;
							}
						}
						return true;
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
					if (currentVersion == null || currentVersion.Length == 0)
					{
						return false;
					}
					if (flag)
					{
						string[] array = versionMin.Split('.');
						int num = MathTools.Min(array.Length, currentVersion.Length);
						bool flag3 = false;
						for (int i = 0; i < num; i++)
						{
							int result;
							bool flag4 = int.TryParse(array[i], out result);
							int result2;
							bool flag5 = int.TryParse(currentVersion[i], out result2);
							if (flag4 && !flag5)
							{
								return false;
							}
							if (!flag4)
							{
								break;
							}
							if (result2 < result)
							{
								return false;
							}
							flag3 = true;
						}
						if (!flag3)
						{
							return false;
						}
					}
					if (flag2)
					{
						string[] array2 = versionMax.Split('.');
						int num2 = MathTools.Min(array2.Length, currentVersion.Length);
						bool flag6 = false;
						for (int j = 0; j < num2; j++)
						{
							int result3;
							bool flag7 = int.TryParse(array2[j], out result3);
							int result4;
							bool flag8 = int.TryParse(currentVersion[j], out result4);
							if (flag7 && !flag8)
							{
								return false;
							}
							if (!flag7)
							{
								break;
							}
							if (result4 > result3)
							{
								return false;
							}
							flag6 = true;
						}
						if (!flag6)
						{
							return false;
						}
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
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
						matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
						matchingCriteria.mapping = ArrayTools.ShallowCopy(mapping);
						matchingCriteria.elementCount = ArrayTools.DeepClone(elementCount);
						matchingCriteria.clientInfo = ArrayTools.DeepClone(clientInfo);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				int Elements_Base.buttonCount
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

				int Elements_Base.axisCount
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
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
				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					_ = destination is Button;
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
					_ = destination is Axis;
				}
			}

			private sealed class eqFJMQFECGtGKSbGlbLrZZBKHqLs : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int GcsafDizAIkejxPqJGQbaeBpilxaA;

				private Platform_Custom.Axis RJfirTexASBsqDSDolRsTlMPEKdZ;

				private int bTktolChbZCeCwdedMZWFRHxkCPT;

				public Platform_WebGL_Base yquxbYBllAGCmkYNTNctvJCLPtnWA;

				private int GMLarmwHGbSXYrCRRpQKmgxTipWs;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return RJfirTexASBsqDSDolRsTlMPEKdZ;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return RJfirTexASBsqDSDolRsTlMPEKdZ;
					}
				}

				[DebuggerHidden]
				public eqFJMQFECGtGKSbGlbLrZZBKHqLs(int P_0)
				{
					GcsafDizAIkejxPqJGQbaeBpilxaA = P_0;
					bTktolChbZCeCwdedMZWFRHxkCPT = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int gcsafDizAIkejxPqJGQbaeBpilxaA = GcsafDizAIkejxPqJGQbaeBpilxaA;
					Platform_WebGL_Base platform_WebGL_Base = yquxbYBllAGCmkYNTNctvJCLPtnWA;
					switch (gcsafDizAIkejxPqJGQbaeBpilxaA)
					{
					default:
						return false;
					case 0:
						GcsafDizAIkejxPqJGQbaeBpilxaA = -1;
						if (platform_WebGL_Base.elements == null || platform_WebGL_Base.elements.axes == null)
						{
							return false;
						}
						GMLarmwHGbSXYrCRRpQKmgxTipWs = 0;
						break;
					case 1:
						GcsafDizAIkejxPqJGQbaeBpilxaA = -1;
						GMLarmwHGbSXYrCRRpQKmgxTipWs++;
						break;
					}
					if (GMLarmwHGbSXYrCRRpQKmgxTipWs < platform_WebGL_Base.elements.axes.Length)
					{
						RJfirTexASBsqDSDolRsTlMPEKdZ = platform_WebGL_Base.elements.axes[GMLarmwHGbSXYrCRRpQKmgxTipWs];
						GcsafDizAIkejxPqJGQbaeBpilxaA = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					eqFJMQFECGtGKSbGlbLrZZBKHqLs eqFJMQFECGtGKSbGlbLrZZBKHqLs2;
					if (GcsafDizAIkejxPqJGQbaeBpilxaA == -2 && bTktolChbZCeCwdedMZWFRHxkCPT == Environment.CurrentManagedThreadId)
					{
						GcsafDizAIkejxPqJGQbaeBpilxaA = 0;
						eqFJMQFECGtGKSbGlbLrZZBKHqLs2 = this;
					}
					else
					{
						eqFJMQFECGtGKSbGlbLrZZBKHqLs2 = new eqFJMQFECGtGKSbGlbLrZZBKHqLs(0);
						eqFJMQFECGtGKSbGlbLrZZBKHqLs2.yquxbYBllAGCmkYNTNctvJCLPtnWA = yquxbYBllAGCmkYNTNctvJCLPtnWA;
					}
					return eqFJMQFECGtGKSbGlbLrZZBKHqLs2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class psAowDFEBoRMmPffMGHibtwLavur : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int cutDbthPkTbVsPNhyQJutSGTSHXz;

				private Platform_Custom.Button zOFAnLHNpmIDNROhhiRRiBPEUdar;

				private int rOoyhgiTEaMzXWrMjJkMqAaxKyPl;

				public Platform_WebGL_Base inlmyESVimgigtmEZdOJCmMgFRlfb;

				private int YzClHOqmUXQsPGIcNpHlZlnfxKAc;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return zOFAnLHNpmIDNROhhiRRiBPEUdar;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return zOFAnLHNpmIDNROhhiRRiBPEUdar;
					}
				}

				[DebuggerHidden]
				public psAowDFEBoRMmPffMGHibtwLavur(int P_0)
				{
					cutDbthPkTbVsPNhyQJutSGTSHXz = P_0;
					rOoyhgiTEaMzXWrMjJkMqAaxKyPl = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = cutDbthPkTbVsPNhyQJutSGTSHXz;
					Platform_WebGL_Base platform_WebGL_Base = inlmyESVimgigtmEZdOJCmMgFRlfb;
					switch (num)
					{
					default:
						return false;
					case 0:
						cutDbthPkTbVsPNhyQJutSGTSHXz = -1;
						if (platform_WebGL_Base.elements == null || platform_WebGL_Base.elements.buttons == null)
						{
							return false;
						}
						YzClHOqmUXQsPGIcNpHlZlnfxKAc = 0;
						break;
					case 1:
						cutDbthPkTbVsPNhyQJutSGTSHXz = -1;
						YzClHOqmUXQsPGIcNpHlZlnfxKAc++;
						break;
					}
					if (YzClHOqmUXQsPGIcNpHlZlnfxKAc < platform_WebGL_Base.elements.buttons.Length)
					{
						zOFAnLHNpmIDNROhhiRRiBPEUdar = platform_WebGL_Base.elements.buttons[YzClHOqmUXQsPGIcNpHlZlnfxKAc];
						cutDbthPkTbVsPNhyQJutSGTSHXz = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					psAowDFEBoRMmPffMGHibtwLavur psAowDFEBoRMmPffMGHibtwLavur2;
					if (cutDbthPkTbVsPNhyQJutSGTSHXz == -2 && rOoyhgiTEaMzXWrMjJkMqAaxKyPl == Environment.CurrentManagedThreadId)
					{
						cutDbthPkTbVsPNhyQJutSGTSHXz = 0;
						psAowDFEBoRMmPffMGHibtwLavur2 = this;
					}
					else
					{
						psAowDFEBoRMmPffMGHibtwLavur2 = new psAowDFEBoRMmPffMGHibtwLavur(0);
						psAowDFEBoRMmPffMGHibtwLavur2.inlmyESVimgigtmEZdOJCmMgFRlfb = inlmyESVimgigtmEZdOJCmMgFRlfb;
					}
					return psAowDFEBoRMmPffMGHibtwLavur2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			InputPlatform Platform.platform => InputPlatform.WebGL;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
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

			bool Platform.hasData
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

			bool Platform.disabled
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

			bool Platform.isAllowed
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

			Elements_Base Platform.elements_base => elements;

			IList<Platform> Platform.variants_base => null;

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

			[IteratorStateMachine(typeof(eqFJMQFECGtGKSbGlbLrZZBKHqLs))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new eqFJMQFECGtGKSbGlbLrZZBKHqLs(-2)
				{
					yquxbYBllAGCmkYNTNctvJCLPtnWA = this
				};
			}

			[IteratorStateMachine(typeof(psAowDFEBoRMmPffMGHibtwLavur))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new psAowDFEBoRMmPffMGHibtwLavur(-2)
				{
					inlmyESVimgigtmEZdOJCmMgFRlfb = this
				};
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.axes[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.buttons[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
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
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
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
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
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
				if (destination is Platform_WebGL_Base platform_WebGL_Base)
				{
					platform_WebGL_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_WebGL_Base.elements = MiscTools.DeepClone(elements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_WebGL : Platform_WebGL_Base
		{
			public Platform_WebGL_Base[] variants;

			IList<Platform> Platform_WebGL_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
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
				if (destination is Platform_WebGL platform_WebGL)
				{
					platform_WebGL.variants = MiscTools.DeepClone(variants);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_AppleGCController_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productCategory_useRegex;

				public string[] productCategory;

				public AppleGCControllerProfileTypeFlags primaryProfileType;

				public AppleGCControllerProfileSubType[] profileSubTypes;

				bool Platform_Custom.MatchingCriteria.hasData
				{
					get
					{
						if (base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EhasData)
						{
							return true;
						}
						if (productCategory != null && productCategory.Length != 0)
						{
							return true;
						}
						if (primaryProfileType != AppleGCControllerProfileTypeFlags.None)
						{
							return true;
						}
						if (profileSubTypes != null && profileSubTypes.Length != 0)
						{
							return true;
						}
						return false;
					}
				}

				bool Platform_Custom.MatchingCriteria.isAllowed
				{
					get
					{
						if (!base.Rewired_002EData_002EMapping_002EHardwareJoystickMap_002EMatchingCriteria_Base_002EisAllowed)
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
					if (alwaysMatch)
					{
						return true;
					}
					if (!base.Matches(bridgedControllerHWInfo, strictMatch))
					{
						return false;
					}
					if (!ElementCountsMatch(bridgedControllerHWInfo, out var _))
					{
						return false;
					}
					bool flag = HasProductCategory();
					bool result = false;
					if (primaryProfileType != AppleGCControllerProfileTypeFlags.None)
					{
						if (((uint)bridgedControllerHWInfo.deviceType & (uint)primaryProfileType) == 0)
						{
							return false;
						}
						if (profileSubTypes != null && profileSubTypes.Length != 0)
						{
							bool flag2 = false;
							for (int i = 0; i < profileSubTypes.Length; i++)
							{
								if (profileSubTypes[i] == (AppleGCControllerProfileSubType)bridgedControllerHWInfo.hw_xInputSubType)
								{
									flag2 = true;
									break;
								}
							}
							if (!flag2)
							{
								return false;
							}
						}
						result = true;
					}
					if (flag && !string.IsNullOrEmpty(bridgedControllerHWInfo.hw_systemDeviceName))
					{
						if (!ProductCategoryMatches(bridgedControllerHWInfo.hw_systemDeviceName.Trim()))
						{
							return false;
						}
						result = true;
					}
					return result;
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
					if (destination is MatchingCriteria matchingCriteria)
					{
						matchingCriteria.productCategory_useRegex = productCategory_useRegex;
						matchingCriteria.productCategory = ArrayTools.ShallowCopy(productCategory);
						matchingCriteria.primaryProfileType = primaryProfileType;
						matchingCriteria.profileSubTypes = ArrayTools.ShallowCopy(profileSubTypes);
					}
				}

				private bool HasProductCategory()
				{
					if (productCategory == null)
					{
						return false;
					}
					for (int i = 0; i < productCategory.Length; i++)
					{
						if (!string.IsNullOrEmpty(productCategory[i]))
						{
							return true;
						}
					}
					return false;
				}

				private bool ProductCategoryMatches(string name)
				{
					if (productCategory == null)
					{
						return false;
					}
					for (int i = 0; i < productCategory.Length; i++)
					{
						string searchFor = productCategory[i];
						if (MatchingCriteria_Base.StringMatches(name, searchFor, productCategory_useRegex))
						{
							return true;
						}
					}
					return false;
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				public CompoundElement[] compoundElements;

				int Elements_Base.buttonCount
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

				int Elements_Base.axisCount
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

				public int compoundElementCount
				{
					get
					{
						if (compoundElements == null)
						{
							return 0;
						}
						return compoundElements.Length;
					}
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							return ControllerElementType.Button;
						}
					}
					return elementIdentifier.elementType;
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier != elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
							continue;
						}
						switch (axes[i].sourceType)
						{
						case 1:
						case 100:
							axisRange = axes[i].sourceAxisRange;
							if (axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						case 0:
							axisRange = AxisRange.Positive;
							return true;
						default:
							throw new NotImplementedException();
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
					if (destination is Elements elements)
					{
						elements.axes = ArrayTools.DeepClone(axes);
						elements.buttons = ArrayTools.DeepClone(buttons);
						elements.compoundElements = ArrayTools.DeepClone(compoundElements);
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Button : Platform_Custom.Button
			{
				public AppleGCControllerElementIdentifier sourceElementId;

				public override object DeepClone()
				{
					Button button = new Button();
					CopyVars(button);
					return button;
				}

				internal override void CopyVars(Element destination)
				{
					base.CopyVars(destination);
					if (destination is Button button)
					{
						button.sourceElementId = sourceElementId;
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public AppleGCControllerElementIdentifier sourceElementId;

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
						axis.sourceElementId = sourceElementId;
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class CompoundElement : IDeepCloneable
			{
				public int elementIdentifier;

				public int sourceElementIndex;

				public AppleGCControllerElementIdentifierCompoundElements sourceElementId;

				internal void CopyVars(CompoundElement destination)
				{
					destination.elementIdentifier = elementIdentifier;
					destination.sourceElementIndex = sourceElementIndex;
					destination.sourceElementId = sourceElementId;
				}

				public object DeepClone()
				{
					CompoundElement compoundElement = new CompoundElement();
					CopyVars(compoundElement);
					return compoundElement;
				}

				object IDeepCloneable.DeepClone()
				{
					//ILSpy generated this explicit interface implementation from .override directive in DeepClone
					return this.DeepClone();
				}
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public enum AppleGCControllerProfileTypeFlags
			{
				None = 0,
				Generic = 1,
				ExtendedGamepad = 2,
				MicroGamepad = 4,
				Unknown = int.MinValue
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public enum AppleGCControllerProfileSubType
			{
				None = 0,
				Xbox = 1,
				DualShock = 2,
				DualSense = 3,
				Unknown = -1
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public enum AppleGCControllerElementIdentifier
			{
				None = 0,
				A = 1,
				B = 2,
				X = 3,
				Y = 4,
				LeftShoulder = 5,
				RightShoulder = 6,
				Menu = 7,
				Options = 8,
				Home = 9,
				LeftStickButton = 10,
				RightStickButton = 11,
				DPadUp = 12,
				DPadRight = 13,
				DPadDown = 14,
				DPadLeft = 15,
				LeftStickX = 16,
				LeftStickY = 17,
				RightStickX = 18,
				RightStickY = 19,
				LeftTrigger = 20,
				RightTrigger = 21,
				DPadVertical = 22,
				DPadHorizontal = 23,
				TouchpadButton = 24,
				Paddle1 = 25,
				Paddle2 = 26,
				Paddle3 = 27,
				Paddle4 = 28,
				IndexedButton = 29,
				IndexedAxis = 30
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public enum AppleGCControllerElementIdentifierCompoundElements
			{
				None = 0,
				IndexedStick = 31,
				IndexedDPad = 32,
				LeftStick = 33,
				RightStick = 34,
				DPad = 35
			}

			[CustomObfuscation(rename = false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal enum AppleGCControllerElementIdentifierAxes
			{
				[CustomObfuscation(rename = false)]
				None = 0,
				[CustomObfuscation(rename = false)]
				LeftStickX = 16,
				[CustomObfuscation(rename = false)]
				LeftStickY = 17,
				[CustomObfuscation(rename = false)]
				RightStickX = 18,
				[CustomObfuscation(rename = false)]
				RightStickY = 19,
				[CustomObfuscation(rename = false)]
				DPadVertical = 22,
				[CustomObfuscation(rename = false)]
				DPadHorizontal = 23,
				[CustomObfuscation(rename = false)]
				IndexedAxis = 30
			}

			[CustomObfuscation(rename = false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal enum AppleGCControllerElementIdentifierButtons
			{
				[CustomObfuscation(rename = false)]
				None = 0,
				[CustomObfuscation(rename = false)]
				A = 1,
				[CustomObfuscation(rename = false)]
				B = 2,
				[CustomObfuscation(rename = false)]
				X = 3,
				[CustomObfuscation(rename = false)]
				Y = 4,
				[CustomObfuscation(rename = false)]
				LeftShoulder = 5,
				[CustomObfuscation(rename = false)]
				RightShoulder = 6,
				[CustomObfuscation(rename = false)]
				Menu = 7,
				[CustomObfuscation(rename = false)]
				Options = 8,
				[CustomObfuscation(rename = false)]
				Home = 9,
				[CustomObfuscation(rename = false)]
				LeftStickButton = 10,
				[CustomObfuscation(rename = false)]
				RightStickButton = 11,
				[CustomObfuscation(rename = false)]
				DPadUp = 12,
				[CustomObfuscation(rename = false)]
				DPadRight = 13,
				[CustomObfuscation(rename = false)]
				DPadDown = 14,
				[CustomObfuscation(rename = false)]
				DPadLeft = 15,
				[CustomObfuscation(rename = false)]
				LeftTrigger = 20,
				[CustomObfuscation(rename = false)]
				RightTrigger = 21,
				[CustomObfuscation(rename = false)]
				TouchpadButton = 24,
				[CustomObfuscation(rename = false)]
				Paddle1 = 25,
				[CustomObfuscation(rename = false)]
				Paddle2 = 26,
				[CustomObfuscation(rename = false)]
				Paddle3 = 27,
				[CustomObfuscation(rename = false)]
				Paddle4 = 28,
				[CustomObfuscation(rename = false)]
				IndexedButton = 29
			}

			private sealed class bawVmmUimTYPyZSZkGBkOkMcaqPR : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int KcukwwryVAuLZeunHIPifOBIaEpP;

				private Platform_Custom.Axis YssEkaaArBpfqohnYADzDssdztRLA;

				private int nJVYYCwNJqsCrqnvQhztQTRlvALy;

				public Platform_AppleGCController_Base CdNZSniQzrJPEAPPRYCCMlzFtfHw;

				private int awbqqClMdbPmqmGiBGfLfkmAsmjVA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return YssEkaaArBpfqohnYADzDssdztRLA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return YssEkaaArBpfqohnYADzDssdztRLA;
					}
				}

				[DebuggerHidden]
				public bawVmmUimTYPyZSZkGBkOkMcaqPR(int P_0)
				{
					KcukwwryVAuLZeunHIPifOBIaEpP = P_0;
					nJVYYCwNJqsCrqnvQhztQTRlvALy = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int kcukwwryVAuLZeunHIPifOBIaEpP = KcukwwryVAuLZeunHIPifOBIaEpP;
					Platform_AppleGCController_Base cdNZSniQzrJPEAPPRYCCMlzFtfHw = CdNZSniQzrJPEAPPRYCCMlzFtfHw;
					switch (kcukwwryVAuLZeunHIPifOBIaEpP)
					{
					default:
						return false;
					case 0:
						KcukwwryVAuLZeunHIPifOBIaEpP = -1;
						if (cdNZSniQzrJPEAPPRYCCMlzFtfHw.elements == null || cdNZSniQzrJPEAPPRYCCMlzFtfHw.elements.axes == null)
						{
							return false;
						}
						awbqqClMdbPmqmGiBGfLfkmAsmjVA = 0;
						break;
					case 1:
						KcukwwryVAuLZeunHIPifOBIaEpP = -1;
						awbqqClMdbPmqmGiBGfLfkmAsmjVA++;
						break;
					}
					if (awbqqClMdbPmqmGiBGfLfkmAsmjVA < cdNZSniQzrJPEAPPRYCCMlzFtfHw.elements.axes.Length)
					{
						YssEkaaArBpfqohnYADzDssdztRLA = cdNZSniQzrJPEAPPRYCCMlzFtfHw.elements.axes[awbqqClMdbPmqmGiBGfLfkmAsmjVA];
						KcukwwryVAuLZeunHIPifOBIaEpP = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					bawVmmUimTYPyZSZkGBkOkMcaqPR bawVmmUimTYPyZSZkGBkOkMcaqPR2;
					if (KcukwwryVAuLZeunHIPifOBIaEpP == -2 && nJVYYCwNJqsCrqnvQhztQTRlvALy == Environment.CurrentManagedThreadId)
					{
						KcukwwryVAuLZeunHIPifOBIaEpP = 0;
						bawVmmUimTYPyZSZkGBkOkMcaqPR2 = this;
					}
					else
					{
						bawVmmUimTYPyZSZkGBkOkMcaqPR2 = new bawVmmUimTYPyZSZkGBkOkMcaqPR(0);
						bawVmmUimTYPyZSZkGBkOkMcaqPR2.CdNZSniQzrJPEAPPRYCCMlzFtfHw = CdNZSniQzrJPEAPPRYCCMlzFtfHw;
					}
					return bawVmmUimTYPyZSZkGBkOkMcaqPR2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class KpWAprkGZCnyNgjkFGzcFdtHToGKE : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int pFeVjQbtkWRpMXWfTNiSjFXowNjX;

				private Platform_Custom.Button LvfAbhkbfOWfINxGPzNSIcBhqcguA;

				private int chsoSHCScJsDaiieFgcPCJJIqnfFb;

				public Platform_AppleGCController_Base OkZjcOykVyFqEvAUGCkSSWViEmAP;

				private int jETBGGQdsAyrejltxmNECMFfhChp;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return LvfAbhkbfOWfINxGPzNSIcBhqcguA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return LvfAbhkbfOWfINxGPzNSIcBhqcguA;
					}
				}

				[DebuggerHidden]
				public KpWAprkGZCnyNgjkFGzcFdtHToGKE(int P_0)
				{
					pFeVjQbtkWRpMXWfTNiSjFXowNjX = P_0;
					chsoSHCScJsDaiieFgcPCJJIqnfFb = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = pFeVjQbtkWRpMXWfTNiSjFXowNjX;
					Platform_AppleGCController_Base okZjcOykVyFqEvAUGCkSSWViEmAP = OkZjcOykVyFqEvAUGCkSSWViEmAP;
					switch (num)
					{
					default:
						return false;
					case 0:
						pFeVjQbtkWRpMXWfTNiSjFXowNjX = -1;
						if (okZjcOykVyFqEvAUGCkSSWViEmAP.elements == null || okZjcOykVyFqEvAUGCkSSWViEmAP.elements.buttons == null)
						{
							return false;
						}
						jETBGGQdsAyrejltxmNECMFfhChp = 0;
						break;
					case 1:
						pFeVjQbtkWRpMXWfTNiSjFXowNjX = -1;
						jETBGGQdsAyrejltxmNECMFfhChp++;
						break;
					}
					if (jETBGGQdsAyrejltxmNECMFfhChp < okZjcOykVyFqEvAUGCkSSWViEmAP.elements.buttons.Length)
					{
						LvfAbhkbfOWfINxGPzNSIcBhqcguA = okZjcOykVyFqEvAUGCkSSWViEmAP.elements.buttons[jETBGGQdsAyrejltxmNECMFfhChp];
						pFeVjQbtkWRpMXWfTNiSjFXowNjX = 1;
						return true;
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

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					KpWAprkGZCnyNgjkFGzcFdtHToGKE kpWAprkGZCnyNgjkFGzcFdtHToGKE;
					if (pFeVjQbtkWRpMXWfTNiSjFXowNjX == -2 && chsoSHCScJsDaiieFgcPCJJIqnfFb == Environment.CurrentManagedThreadId)
					{
						pFeVjQbtkWRpMXWfTNiSjFXowNjX = 0;
						kpWAprkGZCnyNgjkFGzcFdtHToGKE = this;
					}
					else
					{
						kpWAprkGZCnyNgjkFGzcFdtHToGKE = new KpWAprkGZCnyNgjkFGzcFdtHToGKE(0);
						kpWAprkGZCnyNgjkFGzcFdtHToGKE.OkZjcOykVyFqEvAUGCkSSWViEmAP = OkZjcOykVyFqEvAUGCkSSWViEmAP;
					}
					return kpWAprkGZCnyNgjkFGzcFdtHToGKE;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public string controllerName;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			private CompoundElement[] _compoundElementsOrigGame;

			int Platform.assignedButtonCount
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

			int Platform.assignedAxisCount
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

			string Platform.controllerNameOverride => controllerName;

			InputPlatform Platform.platform => InputPlatform.AppleGameController;

			Platform_Custom.Axis[] Platform_Custom.Axes
			{
				get
				{
					if (_axesOrigGame == null)
					{
						Axis[] axes_orig = Axes_orig;
						if (axes_orig != null)
						{
							_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
							}
						}
					}
					return _axesOrigGame;
				}
			}

			Platform_Custom.Button[] Platform_Custom.Buttons
			{
				get
				{
					if (_buttonsOrigGame == null)
					{
						Button[] buttons_orig = Buttons_orig;
						if (buttons_orig != null)
						{
							_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
							for (int i = 0; i < buttons_orig.Length; i++)
							{
								_buttonsOrigGame[i] = buttons_orig[i];
							}
						}
					}
					return _buttonsOrigGame;
				}
			}

			internal CompoundElement[] CompoundElements
			{
				get
				{
					if (_compoundElementsOrigGame == null)
					{
						CompoundElement[] compoundElements_orig = CompoundElements_orig;
						if (compoundElements_orig != null)
						{
							_compoundElementsOrigGame = new CompoundElement[compoundElements_orig.Length];
							for (int i = 0; i < compoundElements_orig.Length; i++)
							{
								_compoundElementsOrigGame[i] = compoundElements_orig[i];
							}
						}
					}
					return _compoundElementsOrigGame;
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

			internal CompoundElement[] CompoundElements_orig
			{
				get
				{
					if (elements == null)
					{
						return null;
					}
					return elements.compoundElements;
				}
			}

			bool Platform.hasData
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

			bool Platform.disabled
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

			bool Platform.isAllowed
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

			Elements_Base Platform.elements_base => elements;

			IList<Platform> Platform.variants_base => null;

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

			[IteratorStateMachine(typeof(bawVmmUimTYPyZSZkGBkOkMcaqPR))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new bawVmmUimTYPyZSZkGBkOkMcaqPR(-2)
				{
					CdNZSniQzrJPEAPPRYCCMlzFtfHw = this
				};
			}

			[IteratorStateMachine(typeof(KpWAprkGZCnyNgjkFGzcFdtHToGKE))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new KpWAprkGZCnyNgjkFGzcFdtHToGKE(-2)
				{
					OkZjcOykVyFqEvAUGCkSSWViEmAP = this
				};
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				if (identifiers.Length < elements.axisCount)
				{
					Logger.LogError("You have too few element identifiers!");
					return new string[0];
				}
				string[] array = new string[elements.axisCount];
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.axes[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				for (int i = 0; i < array.Length; i++)
				{
					int elementIdentifier = elements.buttons[i].elementIdentifier;
					int num = IndexOfElementIdentifier(identifiers, elementIdentifier);
					if (num < 0 || num >= identifiers.Length)
					{
						Logger.LogError("Element identifier index is out of bounds!");
					}
					else
					{
						array[i] = identifiers[num].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
				foreach (Button item in IterateButtons())
				{
					buttons[num] = item.elementIdentifier;
					num++;
				}
				num = 0;
				foreach (Axis item2 in IterateAxes())
				{
					axes[num] = item2.elementIdentifier;
					num++;
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
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
					{
						array[i] = AxisCalibrationData.Default;
						array[i].invert = axes_orig[i].invert;
						array[i].deadZone = axes_orig[i].axisDeadZone;
						if (Axes_orig[i].calibrateAxis)
						{
							array[i].zero = axes_orig[i].axisZero;
							array[i].min = axes_orig[i].axisMin;
							array[i].max = axes_orig[i].axisMax;
						}
					}
					else
					{
						if (axes_orig[i].sourceType != 0)
						{
							throw new NotImplementedException();
						}
						array[i] = AxisCalibrationData.Default;
					}
					array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
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
				axisRanges = new AxisRange[Axes_orig.Length];
				axisInfos = new HardwareAxisInfo[Axes_orig.Length];
				for (int i = 0; i < Axes_orig.Length; i++)
				{
					axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
					if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
					{
						axisRanges[i] = Axes_orig[i].sourceAxisRange;
						continue;
					}
					if (Axes_orig[i].sourceType == 0)
					{
						axisRanges[i] = AxisRange.Full;
						continue;
					}
					throw new Exception();
				}
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
				if (Buttons_orig != null)
				{
					buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
					for (int i = 0; i < Buttons_orig.Length; i++)
					{
						buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
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
				Platform_AppleGCController_Base platform_AppleGCController_Base = new Platform_AppleGCController_Base();
				CopyVars(platform_AppleGCController_Base);
				return platform_AppleGCController_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_AppleGCController_Base platform_AppleGCController_Base)
				{
					platform_AppleGCController_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_AppleGCController_Base.elements = MiscTools.DeepClone(elements);
					platform_AppleGCController_Base.controllerName = controllerName;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_AppleGCController : Platform_AppleGCController_Base
		{
			public Platform_AppleGCController_Base[] variants;

			IList<Platform> Platform_AppleGCController_Base.variants_base => variants;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					return true;
				}
				if (base.hasVariants)
				{
					for (int i = 0; i < variants.Length; i++)
					{
						if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
						{
							variantIndex = i;
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				Platform_AppleGCController platform_AppleGCController = new Platform_AppleGCController();
				CopyVars(platform_AppleGCController);
				return platform_AppleGCController;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_AppleGCController platform_AppleGCController)
				{
					platform_AppleGCController.variants = MiscTools.DeepClone(variants);
				}
			}

			internal static Platform_AppleGCController CreateDefaultMap(BridgedControllerHWInfo bridgedController)
			{
				Platform_AppleGCController platform_AppleGCController = new Platform_AppleGCController();
				_ = Consts.unknownJoystickElementIdentifiers_orig;
				platform_AppleGCController.controllerName = "Unknown Controller";
				platform_AppleGCController.description = "";
				Elements elements = (platform_AppleGCController.elements = new Elements());
				int num = 32;
				elements.axes = new Axis[num];
				for (int i = 0; i < num; i++)
				{
					Axis axis = new Axis();
					elements.axes[i] = axis;
					axis.axisDeadZone = 0.1f;
					axis.axisInfo = HardwareAxisInfo.Default;
					axis.axisMin = -1f;
					axis.axisMax = 1f;
					axis.axisZero = 0f;
					axis.calibrateAxis = false;
					axis.buttonAxisContribution = Pole.Positive;
					axis.elementIdentifier = i;
					axis.invert = false;
					axis.sourceAxis = i;
					axis.sourceAxisRange = AxisRange.Full;
					axis.sourceType = 1;
				}
				int num2 = 128;
				elements.buttons = new Button[num2];
				for (int j = 0; j < num2; j++)
				{
					Button button = new Button();
					elements.buttons[j] = button;
					button.buttonInfo = new HardwareButtonInfo(false, false);
					button.elementIdentifier = 32 + j;
					button.sourceButton = j;
					button.sourceType = 0;
				}
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				platform_AppleGCController.matchingCriteria = matchingCriteria;
				platform_AppleGCController.variants = new Platform_AppleGCController_Base[0];
				return platform_AppleGCController;
			}
		}

		private sealed class oVTvkYFVRTQudDMJqGVewlBtWiQq : IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerable, IEnumerator<IControllerElementIdentifierCommon_Internal>, IEnumerator, IDisposable
		{
			private int GfxfJkKfNXJHXwUOXcyndTNdoEGWA;

			private IControllerElementIdentifierCommon_Internal wkuhUdyjEbscWEoKcSHUMiRxsHBp;

			private int nBUmZGyNsejFSyDqtRKOsSJIGlm;

			public HardwareJoystickMap EhmoWZmpTYbBCnjHEBrGGCKlheri;

			private int goSAVFumOVftaqFfKeZDAgZeWrUy;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
			{
				[DebuggerHidden]
				get
				{
					return wkuhUdyjEbscWEoKcSHUMiRxsHBp;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return wkuhUdyjEbscWEoKcSHUMiRxsHBp;
				}
			}

			[DebuggerHidden]
			public oVTvkYFVRTQudDMJqGVewlBtWiQq(int P_0)
			{
				GfxfJkKfNXJHXwUOXcyndTNdoEGWA = P_0;
				nBUmZGyNsejFSyDqtRKOsSJIGlm = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gfxfJkKfNXJHXwUOXcyndTNdoEGWA = GfxfJkKfNXJHXwUOXcyndTNdoEGWA;
				HardwareJoystickMap ehmoWZmpTYbBCnjHEBrGGCKlheri = EhmoWZmpTYbBCnjHEBrGGCKlheri;
				switch (gfxfJkKfNXJHXwUOXcyndTNdoEGWA)
				{
				default:
					return false;
				case 0:
					GfxfJkKfNXJHXwUOXcyndTNdoEGWA = -1;
					if (ehmoWZmpTYbBCnjHEBrGGCKlheri.elementIdentifiers == null)
					{
						return false;
					}
					goSAVFumOVftaqFfKeZDAgZeWrUy = 0;
					break;
				case 1:
					GfxfJkKfNXJHXwUOXcyndTNdoEGWA = -1;
					goSAVFumOVftaqFfKeZDAgZeWrUy++;
					break;
				}
				if (goSAVFumOVftaqFfKeZDAgZeWrUy < ehmoWZmpTYbBCnjHEBrGGCKlheri.elementIdentifiers.Length)
				{
					wkuhUdyjEbscWEoKcSHUMiRxsHBp = ehmoWZmpTYbBCnjHEBrGGCKlheri.elementIdentifiers[goSAVFumOVftaqFfKeZDAgZeWrUy];
					GfxfJkKfNXJHXwUOXcyndTNdoEGWA = 1;
					return true;
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

			[DebuggerHidden]
			IEnumerator<IControllerElementIdentifierCommon_Internal> IEnumerable<IControllerElementIdentifierCommon_Internal>.GetEnumerator()
			{
				oVTvkYFVRTQudDMJqGVewlBtWiQq oVTvkYFVRTQudDMJqGVewlBtWiQq2;
				if (GfxfJkKfNXJHXwUOXcyndTNdoEGWA == -2 && nBUmZGyNsejFSyDqtRKOsSJIGlm == Environment.CurrentManagedThreadId)
				{
					GfxfJkKfNXJHXwUOXcyndTNdoEGWA = 0;
					oVTvkYFVRTQudDMJqGVewlBtWiQq2 = this;
				}
				else
				{
					oVTvkYFVRTQudDMJqGVewlBtWiQq2 = new oVTvkYFVRTQudDMJqGVewlBtWiQq(0);
					oVTvkYFVRTQudDMJqGVewlBtWiQq2.EhmoWZmpTYbBCnjHEBrGGCKlheri = EhmoWZmpTYbBCnjHEBrGGCKlheri;
				}
				return oVTvkYFVRTQudDMJqGVewlBtWiQq2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<IControllerElementIdentifierCommon_Internal>)this).GetEnumerator();
			}
		}

		private sealed class oOdgxiPxdaVbDJLkMOiwmssXfiUe : IEnumerable<ControllerElementIdentifier>, IEnumerable, IEnumerator<ControllerElementIdentifier>, IEnumerator, IDisposable
		{
			private int ngQsebcffJDrPCmFtjfIkhkZGlZI;

			private ControllerElementIdentifier TCSJhXuHCuIREFGaYfvLmnYeWMJW;

			private int ZacnTExtaUUVOBPOFvgdacFDbajz;

			public HardwareJoystickMap rJNDKniEcjoAjdxIrXnzBgtHSZEJ;

			private int cbIMptvRhttDshpXtQhpwvNvYASD;

			ControllerElementIdentifier IEnumerator<ControllerElementIdentifier>.Current
			{
				[DebuggerHidden]
				get
				{
					return TCSJhXuHCuIREFGaYfvLmnYeWMJW;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return TCSJhXuHCuIREFGaYfvLmnYeWMJW;
				}
			}

			[DebuggerHidden]
			public oOdgxiPxdaVbDJLkMOiwmssXfiUe(int P_0)
			{
				ngQsebcffJDrPCmFtjfIkhkZGlZI = P_0;
				ZacnTExtaUUVOBPOFvgdacFDbajz = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = ngQsebcffJDrPCmFtjfIkhkZGlZI;
				HardwareJoystickMap hardwareJoystickMap = rJNDKniEcjoAjdxIrXnzBgtHSZEJ;
				switch (num)
				{
				default:
					return false;
				case 0:
					ngQsebcffJDrPCmFtjfIkhkZGlZI = -1;
					if (hardwareJoystickMap.elementIdentifiers == null)
					{
						return false;
					}
					cbIMptvRhttDshpXtQhpwvNvYASD = 0;
					break;
				case 1:
					ngQsebcffJDrPCmFtjfIkhkZGlZI = -1;
					cbIMptvRhttDshpXtQhpwvNvYASD++;
					break;
				}
				if (cbIMptvRhttDshpXtQhpwvNvYASD < hardwareJoystickMap.elementIdentifiers.Length)
				{
					TCSJhXuHCuIREFGaYfvLmnYeWMJW = hardwareJoystickMap.elementIdentifiers[cbIMptvRhttDshpXtQhpwvNvYASD];
					ngQsebcffJDrPCmFtjfIkhkZGlZI = 1;
					return true;
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

			[DebuggerHidden]
			IEnumerator<ControllerElementIdentifier> IEnumerable<ControllerElementIdentifier>.GetEnumerator()
			{
				oOdgxiPxdaVbDJLkMOiwmssXfiUe oOdgxiPxdaVbDJLkMOiwmssXfiUe2;
				if (ngQsebcffJDrPCmFtjfIkhkZGlZI == -2 && ZacnTExtaUUVOBPOFvgdacFDbajz == Environment.CurrentManagedThreadId)
				{
					ngQsebcffJDrPCmFtjfIkhkZGlZI = 0;
					oOdgxiPxdaVbDJLkMOiwmssXfiUe2 = this;
				}
				else
				{
					oOdgxiPxdaVbDJLkMOiwmssXfiUe2 = new oOdgxiPxdaVbDJLkMOiwmssXfiUe(0);
					oOdgxiPxdaVbDJLkMOiwmssXfiUe2.rJNDKniEcjoAjdxIrXnzBgtHSZEJ = rJNDKniEcjoAjdxIrXnzBgtHSZEJ;
				}
				return oOdgxiPxdaVbDJLkMOiwmssXfiUe2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerElementIdentifier>)this).GetEnumerator();
			}
		}

		private sealed class JjfylEoBspCaFOavSaoWkUQjdgJY : IEnumerable<JoystickType>, IEnumerable, IEnumerator<JoystickType>, IEnumerator, IDisposable
		{
			private int AanEnPIkrXVzbBdZBMXWfwJyvPUXA;

			private JoystickType lwKbhdNcVSJtnzFsPQENYwNkBczq;

			private int jGwcPDAaCRRBZTYMkicwjjXuPETX;

			public HardwareJoystickMap mANZdHuwrDobDEQfwBtypgbfihRG;

			private int iTACkqInkQoAucVCeldijWxymZuic;

			JoystickType IEnumerator<JoystickType>.Current
			{
				[DebuggerHidden]
				get
				{
					return lwKbhdNcVSJtnzFsPQENYwNkBczq;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return lwKbhdNcVSJtnzFsPQENYwNkBczq;
				}
			}

			[DebuggerHidden]
			public JjfylEoBspCaFOavSaoWkUQjdgJY(int P_0)
			{
				AanEnPIkrXVzbBdZBMXWfwJyvPUXA = P_0;
				jGwcPDAaCRRBZTYMkicwjjXuPETX = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int aanEnPIkrXVzbBdZBMXWfwJyvPUXA = AanEnPIkrXVzbBdZBMXWfwJyvPUXA;
				HardwareJoystickMap hardwareJoystickMap = mANZdHuwrDobDEQfwBtypgbfihRG;
				switch (aanEnPIkrXVzbBdZBMXWfwJyvPUXA)
				{
				default:
					return false;
				case 0:
					AanEnPIkrXVzbBdZBMXWfwJyvPUXA = -1;
					if (hardwareJoystickMap.joystickTypes == null)
					{
						return false;
					}
					iTACkqInkQoAucVCeldijWxymZuic = 0;
					break;
				case 1:
					AanEnPIkrXVzbBdZBMXWfwJyvPUXA = -1;
					iTACkqInkQoAucVCeldijWxymZuic++;
					break;
				}
				if (iTACkqInkQoAucVCeldijWxymZuic < hardwareJoystickMap.joystickTypes.Length)
				{
					lwKbhdNcVSJtnzFsPQENYwNkBczq = hardwareJoystickMap.joystickTypes[iTACkqInkQoAucVCeldijWxymZuic];
					AanEnPIkrXVzbBdZBMXWfwJyvPUXA = 1;
					return true;
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

			[DebuggerHidden]
			IEnumerator<JoystickType> IEnumerable<JoystickType>.GetEnumerator()
			{
				JjfylEoBspCaFOavSaoWkUQjdgJY jjfylEoBspCaFOavSaoWkUQjdgJY;
				if (AanEnPIkrXVzbBdZBMXWfwJyvPUXA == -2 && jGwcPDAaCRRBZTYMkicwjjXuPETX == Environment.CurrentManagedThreadId)
				{
					AanEnPIkrXVzbBdZBMXWfwJyvPUXA = 0;
					jjfylEoBspCaFOavSaoWkUQjdgJY = this;
				}
				else
				{
					jjfylEoBspCaFOavSaoWkUQjdgJY = new JjfylEoBspCaFOavSaoWkUQjdgJY(0);
					jjfylEoBspCaFOavSaoWkUQjdgJY.mANZdHuwrDobDEQfwBtypgbfihRG = mANZdHuwrDobDEQfwBtypgbfihRG;
				}
				return jjfylEoBspCaFOavSaoWkUQjdgJY;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JoystickType>)this).GetEnumerator();
			}
		}

		private sealed class xbXWesTnyZRBvUmIyxpoVkAAmhew : IEnumerable<Guid>, IEnumerable, IEnumerator<Guid>, IEnumerator, IDisposable
		{
			private int npagAkNOMkMAfYEjIHKujuRgkrrG;

			private Guid LvmqHrWRuQJwUGDUPjskYlqRUFQr;

			private int ZtFcmNBwnsVrgmMOBhTWrapcPzdDb;

			public HardwareJoystickMap KZyBiGoCHberQtPrGvoUifpeCoUr;

			private int AiLEogeOLFgVMMAqiVxSuaExUsQtA;

			Guid IEnumerator<Guid>.Current
			{
				[DebuggerHidden]
				get
				{
					return LvmqHrWRuQJwUGDUPjskYlqRUFQr;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return LvmqHrWRuQJwUGDUPjskYlqRUFQr;
				}
			}

			[DebuggerHidden]
			public xbXWesTnyZRBvUmIyxpoVkAAmhew(int P_0)
			{
				npagAkNOMkMAfYEjIHKujuRgkrrG = P_0;
				ZtFcmNBwnsVrgmMOBhTWrapcPzdDb = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = npagAkNOMkMAfYEjIHKujuRgkrrG;
				HardwareJoystickMap kZyBiGoCHberQtPrGvoUifpeCoUr = KZyBiGoCHberQtPrGvoUifpeCoUr;
				switch (num)
				{
				default:
					return false;
				case 0:
					npagAkNOMkMAfYEjIHKujuRgkrrG = -1;
					if (kZyBiGoCHberQtPrGvoUifpeCoUr.templateGuids == null)
					{
						return false;
					}
					AiLEogeOLFgVMMAqiVxSuaExUsQtA = 0;
					break;
				case 1:
					npagAkNOMkMAfYEjIHKujuRgkrrG = -1;
					AiLEogeOLFgVMMAqiVxSuaExUsQtA++;
					break;
				}
				if (AiLEogeOLFgVMMAqiVxSuaExUsQtA < kZyBiGoCHberQtPrGvoUifpeCoUr.templateGuids.Length)
				{
					LvmqHrWRuQJwUGDUPjskYlqRUFQr = StringTools.ToGuid(kZyBiGoCHberQtPrGvoUifpeCoUr.templateGuids[AiLEogeOLFgVMMAqiVxSuaExUsQtA]);
					npagAkNOMkMAfYEjIHKujuRgkrrG = 1;
					return true;
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

			[DebuggerHidden]
			IEnumerator<Guid> IEnumerable<Guid>.GetEnumerator()
			{
				xbXWesTnyZRBvUmIyxpoVkAAmhew xbXWesTnyZRBvUmIyxpoVkAAmhew2;
				if (npagAkNOMkMAfYEjIHKujuRgkrrG == -2 && ZtFcmNBwnsVrgmMOBhTWrapcPzdDb == Environment.CurrentManagedThreadId)
				{
					npagAkNOMkMAfYEjIHKujuRgkrrG = 0;
					xbXWesTnyZRBvUmIyxpoVkAAmhew2 = this;
				}
				else
				{
					xbXWesTnyZRBvUmIyxpoVkAAmhew2 = new xbXWesTnyZRBvUmIyxpoVkAAmhew(0);
					xbXWesTnyZRBvUmIyxpoVkAAmhew2.KZyBiGoCHberQtPrGvoUifpeCoUr = KZyBiGoCHberQtPrGvoUifpeCoUr;
				}
				return xbXWesTnyZRBvUmIyxpoVkAAmhew2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Guid>)this).GetEnumerator();
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string controllerName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string editorControllerName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private JoystickType[] joystickTypes;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerElementIdentifier[] elementIdentifiers;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Linux linux;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_WindowsUWP windowsUWP;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_Windows;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_WindowsUWP;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_OSX;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_Linux;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_Linux_PreConfigured;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_Android;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_iOS;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_XBoxOne;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_PS4;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_PS5 ps5;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_PSM;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_PSVita;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_AmazonFireTV;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_WebGL webGL;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_XboxOne xboxOne;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_GameCore gameCore;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_PS4 ps4;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_NintendoSwitch nintendoSwitch;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Stadia stadia;

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
		private Platform_AppleGCController appleGCController;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int elementIdentifierIdCounter;

		public string ControllerName => controllerName;

		public string EditorControllerName => editorControllerName;

		public Guid Guid => StringTools.ToGuid(controllerGuid);

		public IEnumerable<Guid> TemplateGuids
		{
			[IteratorStateMachine(typeof(xbXWesTnyZRBvUmIyxpoVkAAmhew))]
			get
			{
				return new xbXWesTnyZRBvUmIyxpoVkAAmhew(-2)
				{
					KZyBiGoCHberQtPrGvoUifpeCoUr = this
				};
			}
		}

		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers
		{
			[IteratorStateMachine(typeof(oOdgxiPxdaVbDJLkMOiwmssXfiUe))]
			get
			{
				return new oOdgxiPxdaVbDJLkMOiwmssXfiUe(-2)
				{
					rJNDKniEcjoAjdxIrXnzBgtHSZEJ = this
				};
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
			[IteratorStateMachine(typeof(JjfylEoBspCaFOavSaoWkUQjdgJY))]
			get
			{
				return new JjfylEoBspCaFOavSaoWkUQjdgJY(-2)
				{
					mANZdHuwrDobDEQfwBtypgbfihRG = this
				};
			}
		}

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			[IteratorStateMachine(typeof(oVTvkYFVRTQudDMJqGVewlBtWiQq))]
			get
			{
				return new oVTvkYFVRTQudDMJqGVewlBtWiQq(-2)
				{
					EhmoWZmpTYbBCnjHEBrGGCKlheri = this
				};
			}
		}

		public HardwareJoystickMap()
		{
			if (joystickTypes == null || joystickTypes.Length == 0)
			{
				joystickTypes = new JoystickType[1];
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
			if (appleGCController == null)
			{
				appleGCController = new Platform_AppleGCController();
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
			if (fallback_XBoxOne == null)
			{
				fallback_XBoxOne = new Platform_Fallback();
			}
			if (fallback_AmazonFireTV == null)
			{
				fallback_AmazonFireTV = new Platform_Fallback();
			}
			if (webGL == null)
			{
				webGL = new Platform_WebGL();
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

		public HardwareJoystickMap(HardwareJoystickMap P_0)
			: this()
		{
			controllerGuid = P_0.controllerGuid;
			if (P_0.templateGuids != null)
			{
				int num = P_0.templateGuids.Length;
				templateGuids = new string[num];
				for (int i = 0; i < num; i++)
				{
					templateGuids[i] = templateGuids[i];
				}
			}
			if (P_0.elementIdentifiers != null)
			{
				int num2 = P_0.elementIdentifiers.Length;
				elementIdentifiers = new ControllerElementIdentifier[num2];
				for (int j = 0; j < num2; j++)
				{
					elementIdentifiers[j] = elementIdentifiers[j].Clone();
				}
			}
			elementIdentifierIdCounter = P_0.elementIdentifierIdCounter;
			if (P_0.compoundElements != null)
			{
				int num3 = P_0.compoundElements.Length;
				compoundElements = new CompoundElement[num3];
				for (int k = 0; k < num3; k++)
				{
					compoundElements[k] = P_0.compoundElements[k].DeepClone() as CompoundElement;
				}
			}
			joystickTypes = ArrayTools.ShallowCopy(P_0.joystickTypes);
			if (P_0.directInput != null)
			{
				directInput = MiscTools.DeepClone(P_0.directInput);
			}
			if (P_0.rawInput != null)
			{
				rawInput = MiscTools.DeepClone(rawInput);
			}
			if (P_0.xInput != null)
			{
				xInput = MiscTools.DeepClone(P_0.xInput);
			}
			if (P_0.osx != null)
			{
				osx = MiscTools.DeepClone(P_0.osx);
			}
			if (P_0.appleGCController != null)
			{
				appleGCController = MiscTools.DeepClone(P_0.appleGCController);
			}
			if (P_0.linux != null)
			{
				linux = MiscTools.DeepClone(P_0.linux);
			}
			if (P_0.windowsUWP != null)
			{
				windowsUWP = MiscTools.DeepClone(P_0.windowsUWP);
			}
			if (P_0.fallback_Windows != null)
			{
				fallback_Windows = MiscTools.DeepClone(fallback_Windows);
			}
			if (P_0.fallback_WindowsUWP != null)
			{
				fallback_WindowsUWP = MiscTools.DeepClone(fallback_WindowsUWP);
			}
			if (P_0.fallback_OSX != null)
			{
				fallback_OSX = MiscTools.DeepClone(fallback_OSX);
			}
			if (P_0.fallback_Android != null)
			{
				fallback_Android = MiscTools.DeepClone(fallback_Android);
			}
			if (P_0.fallback_iOS != null)
			{
				fallback_iOS = MiscTools.DeepClone(fallback_iOS);
			}
			if (P_0.fallback_Linux != null)
			{
				fallback_Linux = MiscTools.DeepClone(fallback_Linux);
			}
			if (P_0.fallback_Linux_PreConfigured != null)
			{
				fallback_Linux_PreConfigured = MiscTools.DeepClone(fallback_Linux_PreConfigured);
			}
			if (P_0.fallback_PS4 != null)
			{
				fallback_PS4 = MiscTools.DeepClone(fallback_PS4);
			}
			if (P_0.fallback_PSM != null)
			{
				fallback_PSM = MiscTools.DeepClone(fallback_PSM);
			}
			if (P_0.fallback_PSVita != null)
			{
				fallback_PSVita = MiscTools.DeepClone(fallback_PSVita);
			}
			if (P_0.fallback_XBoxOne != null)
			{
				fallback_XBoxOne = MiscTools.DeepClone(fallback_XBoxOne);
			}
			if (P_0.nintendoSwitch != null)
			{
				nintendoSwitch = MiscTools.DeepClone(P_0.nintendoSwitch);
			}
			if (P_0.stadia != null)
			{
				stadia = MiscTools.DeepClone(P_0.stadia);
			}
			if (P_0.fallback_AmazonFireTV != null)
			{
				fallback_AmazonFireTV = MiscTools.DeepClone(fallback_AmazonFireTV);
			}
			if (P_0.webGL != null)
			{
				webGL = MiscTools.DeepClone(P_0.webGL);
			}
			if (P_0.xboxOne != null)
			{
				xboxOne = MiscTools.DeepClone(P_0.xboxOne);
			}
			if (P_0.gameCore != null)
			{
				gameCore = MiscTools.DeepClone(P_0.gameCore);
			}
			if (P_0.ps4 != null)
			{
				ps4 = MiscTools.DeepClone(P_0.ps4);
			}
			if (P_0.ps5 != null)
			{
				ps5 = MiscTools.DeepClone(P_0.ps5);
			}
			if (P_0.internalDriver != null)
			{
				internalDriver = MiscTools.DeepClone(P_0.internalDriver);
			}
			if (P_0.sdl2_Linux != null)
			{
				sdl2_Linux = MiscTools.DeepClone(P_0.sdl2_Linux);
			}
			if (P_0.sdl2_Windows != null)
			{
				sdl2_Windows = MiscTools.DeepClone(P_0.sdl2_Windows);
			}
			if (P_0.sdl2_OSX != null)
			{
				sdl2_OSX = MiscTools.DeepClone(P_0.sdl2_OSX);
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
			for (int i = 0; i < num; i++)
			{
				array[i] = elementIdentifiers[i].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
			}
			return array;
		}

		string[] IHardwareControllerMap.GetElementIdentifierNames()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetElementIdentifierNames
			return this.GetElementIdentifierNames();
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
			for (int i = 0; i < num; i++)
			{
				array[i] = elementIdentifiers[i].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid;
			}
			return array;
		}

		int[] IHardwareControllerMap.GetElementIdentifierIds()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetElementIdentifierIds
			return this.GetElementIdentifierIds();
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

		bool IHardwareControllerMap.ContainsElementIdentifier(int id)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ContainsElementIdentifier
			return this.ContainsElementIdentifier(id);
		}

		[CustomObfuscation(rename = false)]
		public int GetElementIdentifierInfo(ControllerElementType type, out string[] names, out int[] ids)
		{
			names = null;
			ids = null;
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			if (num == 0)
			{
				return 0;
			}
			List<ControllerElementIdentifier> list = new List<ControllerElementIdentifier>();
			for (int i = 0; i < num; i++)
			{
				if (elementIdentifiers[i] != null && elementIdentifiers[i].elementType == type)
				{
					list.Add(elementIdentifiers[i]);
				}
			}
			int count = list.Count;
			if (count == 0)
			{
				return 0;
			}
			names = new string[count];
			ids = new int[count];
			for (int j = 0; j < count; j++)
			{
				names[j] = list[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
				ids[j] = list[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid;
			}
			return count;
		}

		[CustomObfuscation(rename = false)]
		public int GetMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			names = null;
			ids = null;
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			if (num == 0)
			{
				return 0;
			}
			List<ControllerElementIdentifier> list = new List<ControllerElementIdentifier>();
			for (int i = 0; i < num; i++)
			{
				if (elementIdentifiers[i] != null && InputTools.IsMappableType(elementIdentifiers[i].elementType))
				{
					list.Add(elementIdentifiers[i]);
				}
			}
			int count = list.Count;
			if (count == 0)
			{
				return 0;
			}
			names = new string[count];
			ids = new int[count];
			for (int j = 0; j < count; j++)
			{
				names[j] = list[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
				ids[j] = list[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid;
			}
			return count;
		}

		int IHardwareControllerMap.GetMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetMappableElementIdentifierInfo
			return this.GetMappableElementIdentifierInfo(out names, out ids);
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
			for (int i = 0; i < elementIdentifiers.Length; i++)
			{
				if (elementIdentifiers[i].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid == id)
				{
					return i;
				}
			}
			return -1;
		}

		internal ControllerElementType GetEffectiveElementIdentifierType(HardwareControllerMapIdentifier hardwareMapIdentifier, int elementIdentifierId, bool isDefaultMap)
		{
			ControllerElementIdentifier elementIdentifier = GetElementIdentifier(elementIdentifierId);
			if (elementIdentifier == null)
			{
				return ControllerElementType.Axis;
			}
			return GetSpecificPlatformMap(hardwareMapIdentifier)?.GetEffectiveElementIdentifierType(elementIdentifier) ?? ControllerElementType.Axis;
		}

		internal bool GetEffectiveAxisRange(HardwareControllerMapIdentifier hardwareMapIdentifier, int elementIdentifierId, bool isDefaultMap, out AxisRange axisRange)
		{
			axisRange = AxisRange.Full;
			ControllerElementIdentifier elementIdentifier = GetElementIdentifier(elementIdentifierId);
			if (elementIdentifier == null)
			{
				return false;
			}
			return GetSpecificPlatformMap(hardwareMapIdentifier)?.GetEffectiveAxisRange(elementIdentifier, out axisRange) ?? false;
		}

		internal void GetElementIdentifiersForControllerElements(HardwareControllerMapIdentifier hardwareMapIdentifier, bool isDefaultMap, out int[] buttons, out int[] axes)
		{
			buttons = null;
			axes = null;
			Platform specificPlatformMap = GetSpecificPlatformMap(hardwareMapIdentifier);
			if (specificPlatformMap != null && specificPlatformMap.assignedButtonCount > 0)
			{
				specificPlatformMap.GetGameElementIdentifierIdMappings(out buttons, out axes);
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
			actualInputPlatform = InputPlatform.Unknown;
			variantIndex = -1;
			platformMap = null;
			if (bridgedControllerHWInfo == null)
			{
				return false;
			}
			switch (bridgedControllerHWInfo.inputSource)
			{
			case InputSource.DirectInput:
				if (Matches(directInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					actualInputPlatform = InputPlatform.WindowsDirectInput;
					return true;
				}
				if (Matches(rawInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					actualInputPlatform = InputPlatform.WindowsRawInput;
					return true;
				}
				return false;
			case InputSource.RawInput:
				if (Matches(rawInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					actualInputPlatform = InputPlatform.WindowsRawInput;
					return true;
				}
				if (Matches(directInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					actualInputPlatform = InputPlatform.WindowsDirectInput;
					return true;
				}
				return false;
			case InputSource.XInput:
				if (xInput == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.WindowsXInput;
				return xInput.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.OSX:
				if (osx == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.OSXNative;
				return osx.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.AppleGameController:
				if (appleGCController == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.AppleGameController;
				return appleGCController.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.Linux:
				if (linux == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.LinuxNative;
				return linux.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.WindowsUWP:
				if (windowsUWP == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.WindowsUWP;
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
				actualInputPlatform = InputPlatform.WebGL;
				return webGL.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.XboxOne:
				if (xboxOne == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.XboxOne;
				return xboxOne.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.GameCoreXboxOne:
			case InputSource.GameCoreScarlett:
				if (gameCore == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.GameCore;
				return gameCore.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.PS4:
				if (ps4 == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.PS4;
				return ps4.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.PS5:
				if (ps5 == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.PS5;
				return ps5.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.NintendoSwitch:
				if (nintendoSwitch == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.NintendoSwitch;
				return nintendoSwitch.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.Stadia:
				if (stadia == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.Stadia;
				return stadia.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.InternalDriver:
				if (internalDriver == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.InternalDriver;
				return internalDriver.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.SDL2:
				platformMap = FindSDL2Match(bridgedControllerHWInfo, strictMatch, isDefaultMap, out actualInputPlatform, out variantIndex);
				return platformMap != null;
			case InputSource.Steam:
				actualInputPlatform = InputPlatform.Steam;
				return false;
			default:
				throw new NotImplementedException();
			}
		}

		internal HardwareJoystickMap_InputManager GetDefaultHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			InputSource inputSource = bridgedController.inputSource;
			InputPlatform actualInputPlatform;
			Platform platform;
			int variantIndex;
			switch (inputSource)
			{
			case InputSource.DirectInput:
				actualInputPlatform = InputPlatform.WindowsDirectInput;
				platform = directInput;
				break;
			case InputSource.RawInput:
				actualInputPlatform = InputPlatform.WindowsRawInput;
				platform = rawInput;
				break;
			case InputSource.XInput:
				actualInputPlatform = InputPlatform.WindowsXInput;
				platform = xInput;
				break;
			case InputSource.OSX:
				actualInputPlatform = InputPlatform.OSXNative;
				platform = osx;
				break;
			case InputSource.AppleGameController:
				actualInputPlatform = InputPlatform.AppleGameController;
				platform = appleGCController;
				break;
			case InputSource.Linux:
				actualInputPlatform = InputPlatform.LinuxNative;
				platform = linux;
				break;
			case InputSource.WindowsUWP:
				actualInputPlatform = InputPlatform.WindowsUWP;
				platform = windowsUWP;
				break;
			case InputSource.Fallback:
			case InputSource.Fallback_PreConfigured:
				platform = FindFallbackMap(inputSource, isDefaultMap: true, out actualInputPlatform, out variantIndex);
				break;
			case InputSource.WebGL:
				actualInputPlatform = InputPlatform.WebGL;
				platform = webGL;
				break;
			case InputSource.XboxOne:
				actualInputPlatform = InputPlatform.XboxOne;
				platform = xboxOne;
				break;
			case InputSource.GameCoreXboxOne:
			case InputSource.GameCoreScarlett:
				actualInputPlatform = InputPlatform.GameCore;
				platform = gameCore;
				if (!gameCore.hasData)
				{
					platform = Platform_GameCore.CreateDefaultMap(bridgedController);
				}
				break;
			case InputSource.PS4:
				actualInputPlatform = InputPlatform.PS4;
				platform = ps4;
				break;
			case InputSource.PS5:
				actualInputPlatform = InputPlatform.PS5;
				platform = ps5;
				break;
			case InputSource.NintendoSwitch:
				actualInputPlatform = InputPlatform.NintendoSwitch;
				platform = nintendoSwitch;
				break;
			case InputSource.Stadia:
				actualInputPlatform = InputPlatform.Stadia;
				platform = stadia;
				break;
			case InputSource.InternalDriver:
				actualInputPlatform = InputPlatform.InternalDriver;
				platform = internalDriver;
				break;
			case InputSource.SDL2:
				platform = FindSDL2Map(inputSource, isDefaultMap: true, out actualInputPlatform, out variantIndex);
				break;
			case InputSource.None:
				return null;
			case InputSource.Steam:
			case InputSource.UnityKeyboardAndMouse:
			case InputSource.Custom:
				throw new NotImplementedException();
			default:
				throw new NotImplementedException();
			}
			return platform?.ToHardwareJoystickMap_InputManager(this, inputSource, actualInputPlatform, -1);
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
			switch (UnityTools.editorPlatform)
			{
			case EditorPlatform.Windows:
				platform = Rewired.Platforms.Platform.Windows;
				break;
			case EditorPlatform.OSX:
				platform = Rewired.Platforms.Platform.OSX;
				break;
			case EditorPlatform.Linux:
				platform = Rewired.Platforms.Platform.Linux;
				break;
			}
			switch (platform)
			{
			case Rewired.Platforms.Platform.Windows:
			case Rewired.Platforms.Platform.WindowsAppStore:
			{
				Platform_Fallback_Base mainMap = fallback_Windows;
				actualInputPlatform = InputPlatform.WindowsFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.WindowsUWP:
			{
				Platform_Fallback_Base mainMap = fallback_WindowsUWP;
				actualInputPlatform = InputPlatform.WindowsUWPFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.OSX:
			{
				Platform_Fallback_Base mainMap = fallback_OSX;
				actualInputPlatform = InputPlatform.OSXFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Linux:
			{
				Platform_Fallback_Base mainMap;
				if (inputSource == InputSource.Fallback_PreConfigured)
				{
					mainMap = fallback_Linux_PreConfigured;
					actualInputPlatform = InputPlatform.LinuxFallback_PreConfigured;
					mainMap = TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.LinuxFallback_PreConfigured)
					{
						mainMap = null;
					}
					if (mainMap != null)
					{
						return mainMap;
					}
				}
				mainMap = fallback_Linux;
				actualInputPlatform = InputPlatform.LinuxFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Android:
			{
				Platform_Fallback_Base mainMap = fallback_Android;
				actualInputPlatform = InputPlatform.AndroidFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.iOS:
			case Rewired.Platforms.Platform.tvOS:
			{
				Platform_Fallback_Base mainMap = fallback_iOS;
				actualInputPlatform = InputPlatform.iOSFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.XboxOne:
			{
				Platform_Fallback_Base mainMap = fallback_XBoxOne;
				actualInputPlatform = InputPlatform.XBoxOneFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.PS4:
			{
				Platform_Fallback_Base mainMap = fallback_PS4;
				actualInputPlatform = InputPlatform.PS4Fallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.PSMobile:
			{
				Platform_Fallback_Base mainMap = fallback_PSM;
				actualInputPlatform = InputPlatform.PSMFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.PSVita:
			{
				Platform_Fallback_Base mainMap = fallback_PSVita;
				actualInputPlatform = InputPlatform.PSVitaFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.AmazonFireTV:
			{
				Platform_Fallback_Base mainMap = fallback_AmazonFireTV;
				actualInputPlatform = InputPlatform.AmazonFireTVFallback;
				mainMap = TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
				if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.AmazonFireTVFallback)
				{
					mainMap = null;
				}
				if (mainMap != null)
				{
					return mainMap;
				}
				mainMap = fallback_Android;
				actualInputPlatform = InputPlatform.AndroidFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Webplayer:
				if (UnityTools.webplayerPlatform == WebplayerPlatform.Windows)
				{
					Platform_Fallback_Base mainMap = fallback_Windows;
					actualInputPlatform = InputPlatform.WindowsFallback;
					return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				if (UnityTools.webplayerPlatform == WebplayerPlatform.OSX)
				{
					Platform_Fallback_Base mainMap = fallback_OSX;
					actualInputPlatform = InputPlatform.OSXFallback;
					return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				break;
			}
			if (isDefaultMap)
			{
				return GetUniversalDefaultMap<Platform_Fallback_Base>(out actualInputPlatform, out variantIndex);
			}
			variantIndex = -1;
			actualInputPlatform = InputPlatform.Unknown;
			return null;
		}

		private Platform_Fallback_Base FindFallbackMap(InputSource inputSource, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			Rewired.Platforms.Platform platform = UnityTools.platform;
			switch (UnityTools.editorPlatform)
			{
			case EditorPlatform.Windows:
				platform = Rewired.Platforms.Platform.Windows;
				break;
			case EditorPlatform.OSX:
				platform = Rewired.Platforms.Platform.OSX;
				break;
			case EditorPlatform.Linux:
				platform = Rewired.Platforms.Platform.Linux;
				break;
			}
			switch (platform)
			{
			case Rewired.Platforms.Platform.Windows:
			case Rewired.Platforms.Platform.WindowsAppStore:
			{
				Platform_Fallback_Base mainMap = fallback_Windows;
				actualInputPlatform = InputPlatform.WindowsFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.WindowsUWP:
			{
				Platform_Fallback_Base mainMap = fallback_WindowsUWP;
				actualInputPlatform = InputPlatform.WindowsUWPFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.OSX:
			{
				Platform_Fallback_Base mainMap = fallback_OSX;
				actualInputPlatform = InputPlatform.OSXFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Linux:
			{
				Platform_Fallback_Base mainMap;
				if (inputSource == InputSource.Fallback_PreConfigured)
				{
					mainMap = fallback_Linux_PreConfigured;
					actualInputPlatform = InputPlatform.LinuxFallback_PreConfigured;
					mainMap = TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
					if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.LinuxFallback_PreConfigured)
					{
						mainMap = null;
					}
					if (mainMap != null)
					{
						return mainMap;
					}
				}
				mainMap = fallback_Linux;
				actualInputPlatform = InputPlatform.LinuxFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Android:
			{
				Platform_Fallback_Base mainMap = fallback_Android;
				actualInputPlatform = InputPlatform.AndroidFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.iOS:
			case Rewired.Platforms.Platform.tvOS:
			{
				Platform_Fallback_Base mainMap = fallback_iOS;
				actualInputPlatform = InputPlatform.iOSFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.XboxOne:
			{
				Platform_Fallback_Base mainMap = fallback_XBoxOne;
				actualInputPlatform = InputPlatform.XBoxOneFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.PS4:
			{
				Platform_Fallback_Base mainMap = fallback_PS4;
				actualInputPlatform = InputPlatform.PS4Fallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.PSMobile:
			{
				Platform_Fallback_Base mainMap = fallback_PSM;
				actualInputPlatform = InputPlatform.PSMFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.PSVita:
			{
				Platform_Fallback_Base mainMap = fallback_PSVita;
				actualInputPlatform = InputPlatform.PSVitaFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.AmazonFireTV:
			{
				Platform_Fallback_Base mainMap = fallback_AmazonFireTV;
				actualInputPlatform = InputPlatform.AmazonFireTVFallback;
				mainMap = TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
				if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.AmazonFireTVFallback)
				{
					mainMap = null;
				}
				if (mainMap != null)
				{
					return mainMap;
				}
				mainMap = fallback_Android;
				actualInputPlatform = InputPlatform.AndroidFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Webplayer:
				if (UnityTools.webplayerPlatform == WebplayerPlatform.Windows)
				{
					Platform_Fallback_Base mainMap = fallback_Windows;
					actualInputPlatform = InputPlatform.WindowsFallback;
					return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				if (UnityTools.webplayerPlatform == WebplayerPlatform.OSX)
				{
					Platform_Fallback_Base mainMap = fallback_OSX;
					actualInputPlatform = InputPlatform.OSXFallback;
					return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				break;
			}
			if (isDefaultMap)
			{
				return GetUniversalDefaultMap<Platform_Fallback_Base>(out actualInputPlatform, out variantIndex);
			}
			variantIndex = -1;
			actualInputPlatform = InputPlatform.Unknown;
			return null;
		}

		private Platform_SDL2_Base FindSDL2Match(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			Rewired.Platforms.Platform platform = UnityTools.platform;
			switch (UnityTools.editorPlatform)
			{
			case EditorPlatform.Windows:
				platform = Rewired.Platforms.Platform.Windows;
				break;
			case EditorPlatform.OSX:
				platform = Rewired.Platforms.Platform.OSX;
				break;
			case EditorPlatform.Linux:
				platform = Rewired.Platforms.Platform.Linux;
				break;
			}
			switch (platform)
			{
			case Rewired.Platforms.Platform.Windows:
			{
				Platform_SDL2_Base mainMap = sdl2_Windows;
				actualInputPlatform = InputPlatform.SDL2Windows;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Linux:
			{
				Platform_SDL2_Base mainMap = sdl2_Linux;
				actualInputPlatform = InputPlatform.SDL2Linux;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.OSX:
			{
				Platform_SDL2_Base mainMap = sdl2_OSX;
				actualInputPlatform = InputPlatform.SDL2OSX;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			default:
				if (isDefaultMap)
				{
					GetUniversalDefaultMap<Platform_SDL2_Base>(out actualInputPlatform, out variantIndex);
				}
				actualInputPlatform = InputPlatform.Unknown;
				variantIndex = -1;
				return null;
			}
		}

		private Platform_SDL2_Base FindSDL2Map(InputSource inputSource, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			Rewired.Platforms.Platform platform = UnityTools.platform;
			switch (UnityTools.editorPlatform)
			{
			case EditorPlatform.Windows:
				platform = Rewired.Platforms.Platform.Windows;
				break;
			case EditorPlatform.OSX:
				platform = Rewired.Platforms.Platform.OSX;
				break;
			case EditorPlatform.Linux:
				platform = Rewired.Platforms.Platform.Linux;
				break;
			}
			switch (platform)
			{
			case Rewired.Platforms.Platform.Windows:
			{
				Platform_SDL2_Base mainMap = sdl2_Windows;
				actualInputPlatform = InputPlatform.SDL2Windows;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Linux:
			{
				Platform_SDL2_Base mainMap = sdl2_Linux;
				actualInputPlatform = InputPlatform.SDL2Linux;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.OSX:
			{
				Platform_SDL2_Base mainMap = sdl2_OSX;
				actualInputPlatform = InputPlatform.SDL2OSX;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			default:
				if (isDefaultMap)
				{
					GetUniversalDefaultMap<Platform_SDL2_Base>(out actualInputPlatform, out variantIndex);
				}
				actualInputPlatform = InputPlatform.Unknown;
				variantIndex = -1;
				return null;
			}
		}

		private T TryGetFirstValidMap<T>(T mainMap, bool isDefaultMap, ref InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
		{
			if (isDefaultMap)
			{
				if (mainMap == null || !mainMap.selfOrVariantIsAllowed)
				{
					return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
				}
				if (mainMap.isAllowed)
				{
					variantIndex = -1;
					return mainMap;
				}
				IList<Platform> variants_base = mainMap.variants_base;
				if (variants_base != null)
				{
					for (int i = 0; i < variants_base.Count; i++)
					{
						Platform platform = variants_base[i];
						if (platform != null && platform.isAllowed)
						{
							variantIndex = i;
							return platform as T;
						}
					}
				}
				return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
			}
			if (mainMap == null || !mainMap.selfOrVariantIsValid)
			{
				variantIndex = -1;
				return null;
			}
			return mainMap.GetFirstValidPlatformMap(out variantIndex) as T;
		}

		private T TryGetFirstMatchingMap<T>(T mainMap, BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, ref InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
		{
			Platform platformMap;
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
				variantIndex = -1;
				return null;
			}
			if (mainMap.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return platformMap as T;
			}
			variantIndex = -1;
			return null;
		}

		private T GetUniversalDefaultMap<T>(out InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
		{
			T universalDefaultMapRoot = GetUniversalDefaultMapRoot<T>(typeof(T), out actualInputPlatform);
			actualInputPlatform = InputPlatform.SDL2Windows;
			variantIndex = -1;
			if (universalDefaultMapRoot == null || !universalDefaultMapRoot.selfOrVariantIsAllowed)
			{
				return null;
			}
			if (universalDefaultMapRoot.isAllowed)
			{
				return universalDefaultMapRoot;
			}
			IList<Platform> variants_base = universalDefaultMapRoot.variants_base;
			if (variants_base != null)
			{
				for (int i = 0; i < variants_base.Count; i++)
				{
					if (variants_base[i] != null && variants_base[i].isAllowed)
					{
						variantIndex = i;
						return variants_base[i] as T;
					}
				}
			}
			return null;
		}

		private T GetUniversalDefaultMapRoot<T>(Type type, out InputPlatform actualInputPlatform) where T : Platform
		{
			if ((object)type == typeof(Platform_Fallback_Base))
			{
				actualInputPlatform = InputPlatform.WindowsFallback;
				return fallback_Windows as T;
			}
			if ((object)type == typeof(Platform_SDL2_Base))
			{
				actualInputPlatform = InputPlatform.SDL2Windows;
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
			case InputPlatform.WindowsDirectInput:
				return directInput;
			case InputPlatform.WindowsRawInput:
				return rawInput;
			case InputPlatform.WindowsXInput:
				return xInput;
			case InputPlatform.WindowsFallback:
				return fallback_Windows;
			case InputPlatform.WindowsUWP:
				return windowsUWP;
			case InputPlatform.WindowsUWPFallback:
				return fallback_WindowsUWP;
			case InputPlatform.OSXNative:
				return osx;
			case InputPlatform.AppleGameController:
				return appleGCController;
			case InputPlatform.OSXFallback:
				return fallback_OSX;
			case InputPlatform.LinuxNative:
				return linux;
			case InputPlatform.LinuxFallback:
				return fallback_Linux;
			case InputPlatform.LinuxFallback_PreConfigured:
				return fallback_Linux_PreConfigured;
			case InputPlatform.AndroidFallback:
				return fallback_Android;
			case InputPlatform.AmazonFireTVFallback:
				return fallback_AmazonFireTV;
			case InputPlatform.RazerForgeTVFallback:
				return fallback_Android;
			case InputPlatform.iOSFallback:
				return fallback_iOS;
			case InputPlatform.PS4Fallback:
				return fallback_PS4;
			case InputPlatform.PSMFallback:
				return fallback_PSM;
			case InputPlatform.PSVitaFallback:
				return fallback_PSVita;
			case InputPlatform.XBoxOneFallback:
				return fallback_XBoxOne;
			case InputPlatform.NintendoSwitch:
				return nintendoSwitch;
			case InputPlatform.Stadia:
				return stadia;
			case InputPlatform.Fallback:
				throw new NotImplementedException();
			case InputPlatform.WebGL:
				return webGL;
			case InputPlatform.XboxOne:
				return xboxOne;
			case InputPlatform.GameCore:
				return gameCore;
			case InputPlatform.PS4:
				return ps4;
			case InputPlatform.PS5:
				return ps5;
			case InputPlatform.Custom:
				throw new NotImplementedException();
			case InputPlatform.InternalDriver:
				return internalDriver;
			case InputPlatform.SDL2:
				throw new NotImplementedException();
			case InputPlatform.SDL2Windows:
				return sdl2_Windows;
			case InputPlatform.SDL2OSX:
				return sdl2_OSX;
			case InputPlatform.SDL2Linux:
				return sdl2_Linux;
			case InputPlatform.Unknown:
			case InputPlatform.Steam:
				throw new NotImplementedException();
			default:
				throw new NotImplementedException();
			}
		}
	}
}
