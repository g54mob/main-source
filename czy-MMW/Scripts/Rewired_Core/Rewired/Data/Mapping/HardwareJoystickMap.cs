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
			private sealed class trsRPhirmNbqjdoIsNHGFgaOGSQm : IEnumerable<Platform>, IEnumerable, IEnumerator<Platform>, IEnumerator, IDisposable
			{
				private int XxhgFAdbMreayicEqYOMWfjLQXaw;

				private Platform XBoNxhWwuKscQZjJbhJyIThIHHRIA;

				private int FarEvUDwmVAGrDLvVeSrcoQDSukFB;

				public Platform RDiiFAKaHqoVdurKybAkVTGWPbYP;

				private IList<Platform> uUVBRaaeyKikindRnznGGJJNwnPV;

				private int mcQUarxVekHuTuiDdHxfJsiQyHeT;

				Platform IEnumerator<Platform>.Current
				{
					[DebuggerHidden]
					get
					{
						return XBoNxhWwuKscQZjJbhJyIThIHHRIA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return XBoNxhWwuKscQZjJbhJyIThIHHRIA;
					}
				}

				[DebuggerHidden]
				public trsRPhirmNbqjdoIsNHGFgaOGSQm(int P_0)
				{
					XxhgFAdbMreayicEqYOMWfjLQXaw = P_0;
					FarEvUDwmVAGrDLvVeSrcoQDSukFB = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int xxhgFAdbMreayicEqYOMWfjLQXaw = XxhgFAdbMreayicEqYOMWfjLQXaw;
					Platform rDiiFAKaHqoVdurKybAkVTGWPbYP = RDiiFAKaHqoVdurKybAkVTGWPbYP;
					if (xxhgFAdbMreayicEqYOMWfjLQXaw != 0)
					{
						if (xxhgFAdbMreayicEqYOMWfjLQXaw != 1)
						{
							return false;
						}
						XxhgFAdbMreayicEqYOMWfjLQXaw = -1;
						goto IL_0077;
					}
					XxhgFAdbMreayicEqYOMWfjLQXaw = -1;
					uUVBRaaeyKikindRnznGGJJNwnPV = rDiiFAKaHqoVdurKybAkVTGWPbYP.variants_base;
					if (uUVBRaaeyKikindRnznGGJJNwnPV == null)
					{
						return false;
					}
					mcQUarxVekHuTuiDdHxfJsiQyHeT = 0;
					goto IL_0087;
					IL_0087:
					if (mcQUarxVekHuTuiDdHxfJsiQyHeT < uUVBRaaeyKikindRnznGGJJNwnPV.Count)
					{
						if (uUVBRaaeyKikindRnznGGJJNwnPV[mcQUarxVekHuTuiDdHxfJsiQyHeT] != null)
						{
							XBoNxhWwuKscQZjJbhJyIThIHHRIA = uUVBRaaeyKikindRnznGGJJNwnPV[mcQUarxVekHuTuiDdHxfJsiQyHeT];
							XxhgFAdbMreayicEqYOMWfjLQXaw = 1;
							return true;
						}
						goto IL_0077;
					}
					return false;
					IL_0077:
					mcQUarxVekHuTuiDdHxfJsiQyHeT++;
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
					trsRPhirmNbqjdoIsNHGFgaOGSQm trsRPhirmNbqjdoIsNHGFgaOGSQm2;
					if (XxhgFAdbMreayicEqYOMWfjLQXaw == -2 && FarEvUDwmVAGrDLvVeSrcoQDSukFB == Environment.CurrentManagedThreadId)
					{
						XxhgFAdbMreayicEqYOMWfjLQXaw = 0;
						trsRPhirmNbqjdoIsNHGFgaOGSQm2 = this;
					}
					else
					{
						trsRPhirmNbqjdoIsNHGFgaOGSQm2 = new trsRPhirmNbqjdoIsNHGFgaOGSQm(0);
						trsRPhirmNbqjdoIsNHGFgaOGSQm2.RDiiFAKaHqoVdurKybAkVTGWPbYP = RDiiFAKaHqoVdurKybAkVTGWPbYP;
					}
					return trsRPhirmNbqjdoIsNHGFgaOGSQm2;
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
				[IteratorStateMachine(typeof(trsRPhirmNbqjdoIsNHGFgaOGSQm))]
				get
				{
					return new trsRPhirmNbqjdoIsNHGFgaOGSQm(-2)
					{
						RDiiFAKaHqoVdurKybAkVTGWPbYP = this
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
					ezQploKyylrjKlUlVimuGHFeFvmcA(elementCount_Base);
					return elementCount_Base;
				}

				object IDeepCloneable.DeepClone()
				{
					//ILSpy generated this explicit interface implementation from .override directive in DeepClone
					return this.DeepClone();
				}

				internal virtual void ezQploKyylrjKlUlVimuGHFeFvmcA(ElementCount_Base P_0)
				{
					if (P_0 != null)
					{
						P_0.axisCount = axisCount;
						P_0.buttonCount = buttonCount;
					}
				}

				internal virtual bool NNJGgfaSIfVWplUEnquSSIiWlKERA(BridgedControllerHWInfo P_0)
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
					if (elementCount_Base != null && elementCount_Base.NNJGgfaSIfVWplUEnquSSIiWlKERA(bridgedControllerHWInfo))
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
						ezQploKyylrjKlUlVimuGHFeFvmcA(elementCount);
						return elementCount;
					}

					internal void cobbLSLOatfHdjEzxAOltIMBzxGl(ElementCount_Base P_0)
					{
						base.ezQploKyylrjKlUlVimuGHFeFvmcA(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool BnXRjWXZKTDgcYQpaUhbbfVOaIhjA(BridgedControllerHWInfo P_0)
					{
						if (!base.NNJGgfaSIfVWplUEnquSSIiWlKERA(P_0))
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
				private sealed class sLMnYylYycuqIfkYByaPTkSdiNkl : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int hqbEFRDusEwfSjlJpKyLCkZfzldYb;

					private Axis_Base JJeBuVNeJOyxkCHjEbTSgvltscuS;

					private int HethlrcmUTYScWCkSuNfaERclPsy;

					public Elements pbrNmZSFmHXdWykxOxGvmXynTrYi;

					private int CeJlxjylfsLJdqROBdehpEIBKHNH;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return JJeBuVNeJOyxkCHjEbTSgvltscuS;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return JJeBuVNeJOyxkCHjEbTSgvltscuS;
						}
					}

					[DebuggerHidden]
					public sLMnYylYycuqIfkYByaPTkSdiNkl(int P_0)
					{
						hqbEFRDusEwfSjlJpKyLCkZfzldYb = P_0;
						HethlrcmUTYScWCkSuNfaERclPsy = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hqbEFRDusEwfSjlJpKyLCkZfzldYb;
						Elements elements = pbrNmZSFmHXdWykxOxGvmXynTrYi;
						switch (num)
						{
						default:
							return false;
						case 0:
							hqbEFRDusEwfSjlJpKyLCkZfzldYb = -1;
							if (elements.axes == null)
							{
								return false;
							}
							CeJlxjylfsLJdqROBdehpEIBKHNH = 0;
							break;
						case 1:
							hqbEFRDusEwfSjlJpKyLCkZfzldYb = -1;
							CeJlxjylfsLJdqROBdehpEIBKHNH++;
							break;
						}
						if (CeJlxjylfsLJdqROBdehpEIBKHNH < elements.axes.Length)
						{
							JJeBuVNeJOyxkCHjEbTSgvltscuS = elements.axes[CeJlxjylfsLJdqROBdehpEIBKHNH];
							hqbEFRDusEwfSjlJpKyLCkZfzldYb = 1;
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
						sLMnYylYycuqIfkYByaPTkSdiNkl sLMnYylYycuqIfkYByaPTkSdiNkl2;
						if (hqbEFRDusEwfSjlJpKyLCkZfzldYb == -2 && HethlrcmUTYScWCkSuNfaERclPsy == Environment.CurrentManagedThreadId)
						{
							hqbEFRDusEwfSjlJpKyLCkZfzldYb = 0;
							sLMnYylYycuqIfkYByaPTkSdiNkl2 = this;
						}
						else
						{
							sLMnYylYycuqIfkYByaPTkSdiNkl2 = new sLMnYylYycuqIfkYByaPTkSdiNkl(0);
							sLMnYylYycuqIfkYByaPTkSdiNkl2.pbrNmZSFmHXdWykxOxGvmXynTrYi = pbrNmZSFmHXdWykxOxGvmXynTrYi;
						}
						return sLMnYylYycuqIfkYByaPTkSdiNkl2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}
				}

				private sealed class zJkaOHtoROFudfqGVKfZEoOFAKPNA : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int zfbwiaQfGAPCpUIZFdRnmKDmyCQi;

					private Button_Base FixOWRhwdKRuBtgNrVnMaPRgBdoQ;

					private int RvHRGwDVCwvpJjmfcKMFrZLIbaxg;

					public Elements nKrfPliEPsWhKiYBQfReKuurdHlRA;

					private int HTpGbCkJShyglifjAopuCZkqfTwEb;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return FixOWRhwdKRuBtgNrVnMaPRgBdoQ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return FixOWRhwdKRuBtgNrVnMaPRgBdoQ;
						}
					}

					[DebuggerHidden]
					public zJkaOHtoROFudfqGVKfZEoOFAKPNA(int P_0)
					{
						zfbwiaQfGAPCpUIZFdRnmKDmyCQi = P_0;
						RvHRGwDVCwvpJjmfcKMFrZLIbaxg = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = zfbwiaQfGAPCpUIZFdRnmKDmyCQi;
						Elements elements = nKrfPliEPsWhKiYBQfReKuurdHlRA;
						switch (num)
						{
						default:
							return false;
						case 0:
							zfbwiaQfGAPCpUIZFdRnmKDmyCQi = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							HTpGbCkJShyglifjAopuCZkqfTwEb = 0;
							break;
						case 1:
							zfbwiaQfGAPCpUIZFdRnmKDmyCQi = -1;
							HTpGbCkJShyglifjAopuCZkqfTwEb++;
							break;
						}
						if (HTpGbCkJShyglifjAopuCZkqfTwEb < elements.buttons.Length)
						{
							FixOWRhwdKRuBtgNrVnMaPRgBdoQ = elements.buttons[HTpGbCkJShyglifjAopuCZkqfTwEb];
							zfbwiaQfGAPCpUIZFdRnmKDmyCQi = 1;
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
						zJkaOHtoROFudfqGVKfZEoOFAKPNA zJkaOHtoROFudfqGVKfZEoOFAKPNA2;
						if (zfbwiaQfGAPCpUIZFdRnmKDmyCQi == -2 && RvHRGwDVCwvpJjmfcKMFrZLIbaxg == Environment.CurrentManagedThreadId)
						{
							zfbwiaQfGAPCpUIZFdRnmKDmyCQi = 0;
							zJkaOHtoROFudfqGVKfZEoOFAKPNA2 = this;
						}
						else
						{
							zJkaOHtoROFudfqGVKfZEoOFAKPNA2 = new zJkaOHtoROFudfqGVKfZEoOFAKPNA(0);
							zJkaOHtoROFudfqGVKfZEoOFAKPNA2.nKrfPliEPsWhKiYBQfReKuurdHlRA = nKrfPliEPsWhKiYBQfReKuurdHlRA;
						}
						return zJkaOHtoROFudfqGVKfZEoOFAKPNA2;
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
					[IteratorStateMachine(typeof(sLMnYylYycuqIfkYByaPTkSdiNkl))]
					get
					{
						return new sLMnYylYycuqIfkYByaPTkSdiNkl(-2)
						{
							pbrNmZSFmHXdWykxOxGvmXynTrYi = this
						};
					}
				}

				IEnumerable<Button_Base> Elements_Platform_Base.Buttons
				{
					[IteratorStateMachine(typeof(zJkaOHtoROFudfqGVKfZEoOFAKPNA))]
					get
					{
						return new zJkaOHtoROFudfqGVKfZEoOFAKPNA(-2)
						{
							nKrfPliEPsWhKiYBQfReKuurdHlRA = this
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

			private sealed class fjwfknqCQGCmJsQlQDBRQiFKRsWN : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int WCqwNcGYWuJAaOiaTiiNUXpfFTxy;

				private Axis_Base QQdeLmVvNBFJqbjsxAuNLQgRscip;

				private int rqdZRoNJiAxcVnKzNcIqJjPRKLoo;

				public Platform_DirectInput_Base bOVtnNhAmzOxGjeUkgmaaJqKDfDk;

				private int jcoiELawaZjanSWupySoXfByLUdc;

				private int FbQseYwgmJFuuFDmjUZvrNSPnZRb;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return QQdeLmVvNBFJqbjsxAuNLQgRscip;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return QQdeLmVvNBFJqbjsxAuNLQgRscip;
					}
				}

				[DebuggerHidden]
				public fjwfknqCQGCmJsQlQDBRQiFKRsWN(int P_0)
				{
					WCqwNcGYWuJAaOiaTiiNUXpfFTxy = P_0;
					rqdZRoNJiAxcVnKzNcIqJjPRKLoo = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int wCqwNcGYWuJAaOiaTiiNUXpfFTxy = WCqwNcGYWuJAaOiaTiiNUXpfFTxy;
					Platform_DirectInput_Base platform_DirectInput_Base = bOVtnNhAmzOxGjeUkgmaaJqKDfDk;
					switch (wCqwNcGYWuJAaOiaTiiNUXpfFTxy)
					{
					default:
						return false;
					case 0:
						WCqwNcGYWuJAaOiaTiiNUXpfFTxy = -1;
						if (platform_DirectInput_Base.elements == null || platform_DirectInput_Base.elements.axes == null)
						{
							return false;
						}
						jcoiELawaZjanSWupySoXfByLUdc = platform_DirectInput_Base.elements.axes.Length;
						FbQseYwgmJFuuFDmjUZvrNSPnZRb = 0;
						break;
					case 1:
						WCqwNcGYWuJAaOiaTiiNUXpfFTxy = -1;
						FbQseYwgmJFuuFDmjUZvrNSPnZRb++;
						break;
					}
					if (FbQseYwgmJFuuFDmjUZvrNSPnZRb < jcoiELawaZjanSWupySoXfByLUdc)
					{
						QQdeLmVvNBFJqbjsxAuNLQgRscip = platform_DirectInput_Base.elements.axes[FbQseYwgmJFuuFDmjUZvrNSPnZRb];
						WCqwNcGYWuJAaOiaTiiNUXpfFTxy = 1;
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
					fjwfknqCQGCmJsQlQDBRQiFKRsWN fjwfknqCQGCmJsQlQDBRQiFKRsWN2;
					if (WCqwNcGYWuJAaOiaTiiNUXpfFTxy == -2 && rqdZRoNJiAxcVnKzNcIqJjPRKLoo == Environment.CurrentManagedThreadId)
					{
						WCqwNcGYWuJAaOiaTiiNUXpfFTxy = 0;
						fjwfknqCQGCmJsQlQDBRQiFKRsWN2 = this;
					}
					else
					{
						fjwfknqCQGCmJsQlQDBRQiFKRsWN2 = new fjwfknqCQGCmJsQlQDBRQiFKRsWN(0);
						fjwfknqCQGCmJsQlQDBRQiFKRsWN2.bOVtnNhAmzOxGjeUkgmaaJqKDfDk = bOVtnNhAmzOxGjeUkgmaaJqKDfDk;
					}
					return fjwfknqCQGCmJsQlQDBRQiFKRsWN2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}
			}

			private sealed class ZrcuTeeFyqAAXWHBtmdWcNOgszkH : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int iKckcJwwHpdahYkoCqfCQLVQpmjy;

				private Button_Base SLnBLtqHguOKNlnWFqPFPxcMziJf;

				private int yXDrIRdwBdGGVEulSeOPceCCdyqBA;

				public Platform_DirectInput_Base RLrGBvAppliySynccXUwKCURoGLqA;

				private int ScKyAGPhEHKslMWgvwAMdxQcIoMC;

				private int SwEHrjqPVJSuSFybqkYGSNuRgwUr;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return SLnBLtqHguOKNlnWFqPFPxcMziJf;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return SLnBLtqHguOKNlnWFqPFPxcMziJf;
					}
				}

				[DebuggerHidden]
				public ZrcuTeeFyqAAXWHBtmdWcNOgszkH(int P_0)
				{
					iKckcJwwHpdahYkoCqfCQLVQpmjy = P_0;
					yXDrIRdwBdGGVEulSeOPceCCdyqBA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = iKckcJwwHpdahYkoCqfCQLVQpmjy;
					Platform_DirectInput_Base rLrGBvAppliySynccXUwKCURoGLqA = RLrGBvAppliySynccXUwKCURoGLqA;
					switch (num)
					{
					default:
						return false;
					case 0:
						iKckcJwwHpdahYkoCqfCQLVQpmjy = -1;
						if (rLrGBvAppliySynccXUwKCURoGLqA.elements == null || rLrGBvAppliySynccXUwKCURoGLqA.elements.buttons == null)
						{
							return false;
						}
						ScKyAGPhEHKslMWgvwAMdxQcIoMC = rLrGBvAppliySynccXUwKCURoGLqA.elements.buttons.Length;
						SwEHrjqPVJSuSFybqkYGSNuRgwUr = 0;
						break;
					case 1:
						iKckcJwwHpdahYkoCqfCQLVQpmjy = -1;
						SwEHrjqPVJSuSFybqkYGSNuRgwUr++;
						break;
					}
					if (SwEHrjqPVJSuSFybqkYGSNuRgwUr < ScKyAGPhEHKslMWgvwAMdxQcIoMC)
					{
						SLnBLtqHguOKNlnWFqPFPxcMziJf = rLrGBvAppliySynccXUwKCURoGLqA.elements.buttons[SwEHrjqPVJSuSFybqkYGSNuRgwUr];
						iKckcJwwHpdahYkoCqfCQLVQpmjy = 1;
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
					ZrcuTeeFyqAAXWHBtmdWcNOgszkH zrcuTeeFyqAAXWHBtmdWcNOgszkH;
					if (iKckcJwwHpdahYkoCqfCQLVQpmjy == -2 && yXDrIRdwBdGGVEulSeOPceCCdyqBA == Environment.CurrentManagedThreadId)
					{
						iKckcJwwHpdahYkoCqfCQLVQpmjy = 0;
						zrcuTeeFyqAAXWHBtmdWcNOgszkH = this;
					}
					else
					{
						zrcuTeeFyqAAXWHBtmdWcNOgszkH = new ZrcuTeeFyqAAXWHBtmdWcNOgszkH(0);
						zrcuTeeFyqAAXWHBtmdWcNOgszkH.RLrGBvAppliySynccXUwKCURoGLqA = RLrGBvAppliySynccXUwKCURoGLqA;
					}
					return zrcuTeeFyqAAXWHBtmdWcNOgszkH;
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

			[IteratorStateMachine(typeof(fjwfknqCQGCmJsQlQDBRQiFKRsWN))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return new fjwfknqCQGCmJsQlQDBRQiFKRsWN(-2)
				{
					bOVtnNhAmzOxGjeUkgmaaJqKDfDk = this
				};
			}

			[IteratorStateMachine(typeof(ZrcuTeeFyqAAXWHBtmdWcNOgszkH))]
			internal override IEnumerable<Button_Base> IterateButtons()
			{
				return new ZrcuTeeFyqAAXWHBtmdWcNOgszkH(-2)
				{
					RLrGBvAppliySynccXUwKCURoGLqA = this
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
				private sealed class VBVBnCxpfWfkfsWvoikOGNbiulBW : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int wEqqHgvAtQlnNsCjaFWIwLbOMbLp;

					private Axis_Base hLARMUsvKqGdkRlCTguOfTfBmrJgA;

					private int PdsdtOdUMdQoGuupPDjXoCNRgowbA;

					public Elements xACwvgqKptUpjombDHSDccKBWUvs;

					private int tuQTsPVPphjBwUOLiQzHInesQeYu;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return hLARMUsvKqGdkRlCTguOfTfBmrJgA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return hLARMUsvKqGdkRlCTguOfTfBmrJgA;
						}
					}

					[DebuggerHidden]
					public VBVBnCxpfWfkfsWvoikOGNbiulBW(int P_0)
					{
						wEqqHgvAtQlnNsCjaFWIwLbOMbLp = P_0;
						PdsdtOdUMdQoGuupPDjXoCNRgowbA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = wEqqHgvAtQlnNsCjaFWIwLbOMbLp;
						Elements elements = xACwvgqKptUpjombDHSDccKBWUvs;
						switch (num)
						{
						default:
							return false;
						case 0:
							wEqqHgvAtQlnNsCjaFWIwLbOMbLp = -1;
							if (elements.axes == null)
							{
								return false;
							}
							tuQTsPVPphjBwUOLiQzHInesQeYu = 0;
							break;
						case 1:
							wEqqHgvAtQlnNsCjaFWIwLbOMbLp = -1;
							tuQTsPVPphjBwUOLiQzHInesQeYu++;
							break;
						}
						if (tuQTsPVPphjBwUOLiQzHInesQeYu < elements.axes.Length)
						{
							hLARMUsvKqGdkRlCTguOfTfBmrJgA = elements.axes[tuQTsPVPphjBwUOLiQzHInesQeYu];
							wEqqHgvAtQlnNsCjaFWIwLbOMbLp = 1;
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
						VBVBnCxpfWfkfsWvoikOGNbiulBW vBVBnCxpfWfkfsWvoikOGNbiulBW;
						if (wEqqHgvAtQlnNsCjaFWIwLbOMbLp == -2 && PdsdtOdUMdQoGuupPDjXoCNRgowbA == Environment.CurrentManagedThreadId)
						{
							wEqqHgvAtQlnNsCjaFWIwLbOMbLp = 0;
							vBVBnCxpfWfkfsWvoikOGNbiulBW = this;
						}
						else
						{
							vBVBnCxpfWfkfsWvoikOGNbiulBW = new VBVBnCxpfWfkfsWvoikOGNbiulBW(0);
							vBVBnCxpfWfkfsWvoikOGNbiulBW.xACwvgqKptUpjombDHSDccKBWUvs = xACwvgqKptUpjombDHSDccKBWUvs;
						}
						return vBVBnCxpfWfkfsWvoikOGNbiulBW;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}
				}

				private sealed class cDxcixCytRirNXjZqbwYPKYHfJMBA : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int xvxSztnwBFvPNMiaaKiQFJhcnDrv;

					private Button_Base XEvgClOWVrancokuyLsToTzedEGD;

					private int OfAskeUnDveQLeQddLcOzJTBEVOE;

					public Elements GrtcCjMVMEPlGacbPdBAmRkGrjVj;

					private int gUQHQezETGwNCYlgLPVNlcsLbdzK;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return XEvgClOWVrancokuyLsToTzedEGD;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return XEvgClOWVrancokuyLsToTzedEGD;
						}
					}

					[DebuggerHidden]
					public cDxcixCytRirNXjZqbwYPKYHfJMBA(int P_0)
					{
						xvxSztnwBFvPNMiaaKiQFJhcnDrv = P_0;
						OfAskeUnDveQLeQddLcOzJTBEVOE = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = xvxSztnwBFvPNMiaaKiQFJhcnDrv;
						Elements grtcCjMVMEPlGacbPdBAmRkGrjVj = GrtcCjMVMEPlGacbPdBAmRkGrjVj;
						switch (num)
						{
						default:
							return false;
						case 0:
							xvxSztnwBFvPNMiaaKiQFJhcnDrv = -1;
							if (grtcCjMVMEPlGacbPdBAmRkGrjVj.buttons == null)
							{
								return false;
							}
							gUQHQezETGwNCYlgLPVNlcsLbdzK = 0;
							break;
						case 1:
							xvxSztnwBFvPNMiaaKiQFJhcnDrv = -1;
							gUQHQezETGwNCYlgLPVNlcsLbdzK++;
							break;
						}
						if (gUQHQezETGwNCYlgLPVNlcsLbdzK < grtcCjMVMEPlGacbPdBAmRkGrjVj.buttons.Length)
						{
							XEvgClOWVrancokuyLsToTzedEGD = grtcCjMVMEPlGacbPdBAmRkGrjVj.buttons[gUQHQezETGwNCYlgLPVNlcsLbdzK];
							xvxSztnwBFvPNMiaaKiQFJhcnDrv = 1;
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
						cDxcixCytRirNXjZqbwYPKYHfJMBA cDxcixCytRirNXjZqbwYPKYHfJMBA2;
						if (xvxSztnwBFvPNMiaaKiQFJhcnDrv == -2 && OfAskeUnDveQLeQddLcOzJTBEVOE == Environment.CurrentManagedThreadId)
						{
							xvxSztnwBFvPNMiaaKiQFJhcnDrv = 0;
							cDxcixCytRirNXjZqbwYPKYHfJMBA2 = this;
						}
						else
						{
							cDxcixCytRirNXjZqbwYPKYHfJMBA2 = new cDxcixCytRirNXjZqbwYPKYHfJMBA(0);
							cDxcixCytRirNXjZqbwYPKYHfJMBA2.GrtcCjMVMEPlGacbPdBAmRkGrjVj = GrtcCjMVMEPlGacbPdBAmRkGrjVj;
						}
						return cDxcixCytRirNXjZqbwYPKYHfJMBA2;
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
					[IteratorStateMachine(typeof(VBVBnCxpfWfkfsWvoikOGNbiulBW))]
					get
					{
						return new VBVBnCxpfWfkfsWvoikOGNbiulBW(-2)
						{
							xACwvgqKptUpjombDHSDccKBWUvs = this
						};
					}
				}

				IEnumerable<Button_Base> Elements_Platform_Base.Buttons
				{
					[IteratorStateMachine(typeof(cDxcixCytRirNXjZqbwYPKYHfJMBA))]
					get
					{
						return new cDxcixCytRirNXjZqbwYPKYHfJMBA(-2)
						{
							GrtcCjMVMEPlGacbPdBAmRkGrjVj = this
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

			private sealed class IanrVkPjuXzTukEQEvqDMDYEuzNR : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int gbobJLFbfwJtHwIZNLmHSjxXtZLG;

				private Axis_Base BqgQJMNrivuLGoJYAMNCWyiarnPL;

				private int mIKMAWcMqhUJQfINTzKDWmFzbHlgA;

				public Platform_RawInput_Base qJYFrvVVJpkdrAhOpAFFEnDysGlU;

				private int acqkkSYwbJUCFnouKDuMYGppYSLI;

				private int SlKjtZdWkGhjyceEEXICABIEheqcA;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return BqgQJMNrivuLGoJYAMNCWyiarnPL;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return BqgQJMNrivuLGoJYAMNCWyiarnPL;
					}
				}

				[DebuggerHidden]
				public IanrVkPjuXzTukEQEvqDMDYEuzNR(int P_0)
				{
					gbobJLFbfwJtHwIZNLmHSjxXtZLG = P_0;
					mIKMAWcMqhUJQfINTzKDWmFzbHlgA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = gbobJLFbfwJtHwIZNLmHSjxXtZLG;
					Platform_RawInput_Base platform_RawInput_Base = qJYFrvVVJpkdrAhOpAFFEnDysGlU;
					switch (num)
					{
					default:
						return false;
					case 0:
						gbobJLFbfwJtHwIZNLmHSjxXtZLG = -1;
						if (platform_RawInput_Base.elements == null || platform_RawInput_Base.elements.axes == null)
						{
							return false;
						}
						acqkkSYwbJUCFnouKDuMYGppYSLI = platform_RawInput_Base.elements.axes.Length;
						SlKjtZdWkGhjyceEEXICABIEheqcA = 0;
						break;
					case 1:
						gbobJLFbfwJtHwIZNLmHSjxXtZLG = -1;
						SlKjtZdWkGhjyceEEXICABIEheqcA++;
						break;
					}
					if (SlKjtZdWkGhjyceEEXICABIEheqcA < acqkkSYwbJUCFnouKDuMYGppYSLI)
					{
						BqgQJMNrivuLGoJYAMNCWyiarnPL = platform_RawInput_Base.elements.axes[SlKjtZdWkGhjyceEEXICABIEheqcA];
						gbobJLFbfwJtHwIZNLmHSjxXtZLG = 1;
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
					IanrVkPjuXzTukEQEvqDMDYEuzNR ianrVkPjuXzTukEQEvqDMDYEuzNR;
					if (gbobJLFbfwJtHwIZNLmHSjxXtZLG == -2 && mIKMAWcMqhUJQfINTzKDWmFzbHlgA == Environment.CurrentManagedThreadId)
					{
						gbobJLFbfwJtHwIZNLmHSjxXtZLG = 0;
						ianrVkPjuXzTukEQEvqDMDYEuzNR = this;
					}
					else
					{
						ianrVkPjuXzTukEQEvqDMDYEuzNR = new IanrVkPjuXzTukEQEvqDMDYEuzNR(0);
						ianrVkPjuXzTukEQEvqDMDYEuzNR.qJYFrvVVJpkdrAhOpAFFEnDysGlU = qJYFrvVVJpkdrAhOpAFFEnDysGlU;
					}
					return ianrVkPjuXzTukEQEvqDMDYEuzNR;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}
			}

			private sealed class qQHdstCCULhFmaZmcIwaKQuCYWppc : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int bfWPjTZlThZllLYcPwHNqQwiQHsn;

				private Button_Base hPFzrktjwBpLSuEUngawYhqfhwjh;

				private int yaGUQEVSTtiJftFAnVQSjCsztUfk;

				public Platform_RawInput_Base amktNGjFgsxNqsQKAxgfEKUGhrex;

				private int UIxkWOLBrSKezBeKSfSJHzOiCJwUA;

				private int DGxDGYAaucnWQAJlKEGgonGWpisx;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return hPFzrktjwBpLSuEUngawYhqfhwjh;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return hPFzrktjwBpLSuEUngawYhqfhwjh;
					}
				}

				[DebuggerHidden]
				public qQHdstCCULhFmaZmcIwaKQuCYWppc(int P_0)
				{
					bfWPjTZlThZllLYcPwHNqQwiQHsn = P_0;
					yaGUQEVSTtiJftFAnVQSjCsztUfk = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = bfWPjTZlThZllLYcPwHNqQwiQHsn;
					Platform_RawInput_Base platform_RawInput_Base = amktNGjFgsxNqsQKAxgfEKUGhrex;
					switch (num)
					{
					default:
						return false;
					case 0:
						bfWPjTZlThZllLYcPwHNqQwiQHsn = -1;
						if (platform_RawInput_Base.elements == null || platform_RawInput_Base.elements.buttons == null)
						{
							return false;
						}
						UIxkWOLBrSKezBeKSfSJHzOiCJwUA = platform_RawInput_Base.elements.buttons.Length;
						DGxDGYAaucnWQAJlKEGgonGWpisx = 0;
						break;
					case 1:
						bfWPjTZlThZllLYcPwHNqQwiQHsn = -1;
						DGxDGYAaucnWQAJlKEGgonGWpisx++;
						break;
					}
					if (DGxDGYAaucnWQAJlKEGgonGWpisx < UIxkWOLBrSKezBeKSfSJHzOiCJwUA)
					{
						hPFzrktjwBpLSuEUngawYhqfhwjh = platform_RawInput_Base.elements.buttons[DGxDGYAaucnWQAJlKEGgonGWpisx];
						bfWPjTZlThZllLYcPwHNqQwiQHsn = 1;
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
					qQHdstCCULhFmaZmcIwaKQuCYWppc qQHdstCCULhFmaZmcIwaKQuCYWppc2;
					if (bfWPjTZlThZllLYcPwHNqQwiQHsn == -2 && yaGUQEVSTtiJftFAnVQSjCsztUfk == Environment.CurrentManagedThreadId)
					{
						bfWPjTZlThZllLYcPwHNqQwiQHsn = 0;
						qQHdstCCULhFmaZmcIwaKQuCYWppc2 = this;
					}
					else
					{
						qQHdstCCULhFmaZmcIwaKQuCYWppc2 = new qQHdstCCULhFmaZmcIwaKQuCYWppc(0);
						qQHdstCCULhFmaZmcIwaKQuCYWppc2.amktNGjFgsxNqsQKAxgfEKUGhrex = amktNGjFgsxNqsQKAxgfEKUGhrex;
					}
					return qQHdstCCULhFmaZmcIwaKQuCYWppc2;
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

			[IteratorStateMachine(typeof(IanrVkPjuXzTukEQEvqDMDYEuzNR))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return new IanrVkPjuXzTukEQEvqDMDYEuzNR(-2)
				{
					qJYFrvVVJpkdrAhOpAFFEnDysGlU = this
				};
			}

			[IteratorStateMachine(typeof(qQHdstCCULhFmaZmcIwaKQuCYWppc))]
			internal override IEnumerable<Button_Base> IterateButtons()
			{
				return new qQHdstCCULhFmaZmcIwaKQuCYWppc(-2)
				{
					amktNGjFgsxNqsQKAxgfEKUGhrex = this
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

			private sealed class PpbILSxVjnleJjtbJPuKKRaMawsp : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int RdXJVdZJbQZvRxNoKvGXMhDqFbop;

				private Axis fdbmcvjqNOaFwjkVZjxmjleXNmhA;

				private int JXhxZTDFDgMGuOrcgCQNfeGZbnoJ;

				public Platform_XInput_Base WTZiFOJZeCTCSdfVzqfecZhOGriI;

				private int ahXBuLuWKHootSJXncTBYbexcsgA;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return fdbmcvjqNOaFwjkVZjxmjleXNmhA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return fdbmcvjqNOaFwjkVZjxmjleXNmhA;
					}
				}

				[DebuggerHidden]
				public PpbILSxVjnleJjtbJPuKKRaMawsp(int P_0)
				{
					RdXJVdZJbQZvRxNoKvGXMhDqFbop = P_0;
					JXhxZTDFDgMGuOrcgCQNfeGZbnoJ = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int rdXJVdZJbQZvRxNoKvGXMhDqFbop = RdXJVdZJbQZvRxNoKvGXMhDqFbop;
					Platform_XInput_Base wTZiFOJZeCTCSdfVzqfecZhOGriI = WTZiFOJZeCTCSdfVzqfecZhOGriI;
					switch (rdXJVdZJbQZvRxNoKvGXMhDqFbop)
					{
					default:
						return false;
					case 0:
						RdXJVdZJbQZvRxNoKvGXMhDqFbop = -1;
						if (wTZiFOJZeCTCSdfVzqfecZhOGriI.elements == null || wTZiFOJZeCTCSdfVzqfecZhOGriI.elements.axes == null)
						{
							return false;
						}
						ahXBuLuWKHootSJXncTBYbexcsgA = 0;
						break;
					case 1:
						RdXJVdZJbQZvRxNoKvGXMhDqFbop = -1;
						ahXBuLuWKHootSJXncTBYbexcsgA++;
						break;
					}
					if (ahXBuLuWKHootSJXncTBYbexcsgA < wTZiFOJZeCTCSdfVzqfecZhOGriI.elements.axes.Length)
					{
						fdbmcvjqNOaFwjkVZjxmjleXNmhA = wTZiFOJZeCTCSdfVzqfecZhOGriI.elements.axes[ahXBuLuWKHootSJXncTBYbexcsgA];
						RdXJVdZJbQZvRxNoKvGXMhDqFbop = 1;
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
					PpbILSxVjnleJjtbJPuKKRaMawsp ppbILSxVjnleJjtbJPuKKRaMawsp;
					if (RdXJVdZJbQZvRxNoKvGXMhDqFbop == -2 && JXhxZTDFDgMGuOrcgCQNfeGZbnoJ == Environment.CurrentManagedThreadId)
					{
						RdXJVdZJbQZvRxNoKvGXMhDqFbop = 0;
						ppbILSxVjnleJjtbJPuKKRaMawsp = this;
					}
					else
					{
						ppbILSxVjnleJjtbJPuKKRaMawsp = new PpbILSxVjnleJjtbJPuKKRaMawsp(0);
						ppbILSxVjnleJjtbJPuKKRaMawsp.WTZiFOJZeCTCSdfVzqfecZhOGriI = WTZiFOJZeCTCSdfVzqfecZhOGriI;
					}
					return ppbILSxVjnleJjtbJPuKKRaMawsp;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class ZtadNkSzgKjcviCHiCaFoYBzIbuJ : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int uPTRVFEsotYSDjsJaCblePkNTXEA;

				private Button UOTewZERRiPnLHcWRApiSjiXmtwCA;

				private int ImlGhlHJaOOlyVNLrXXaTEwoVmAH;

				public Platform_XInput_Base jyUHJNbcvENufHojhEeAVsKiPGgI;

				private int MfYKPoiLHMpQnflUxoLONhaQKhYq;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return UOTewZERRiPnLHcWRApiSjiXmtwCA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return UOTewZERRiPnLHcWRApiSjiXmtwCA;
					}
				}

				[DebuggerHidden]
				public ZtadNkSzgKjcviCHiCaFoYBzIbuJ(int P_0)
				{
					uPTRVFEsotYSDjsJaCblePkNTXEA = P_0;
					ImlGhlHJaOOlyVNLrXXaTEwoVmAH = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = uPTRVFEsotYSDjsJaCblePkNTXEA;
					Platform_XInput_Base platform_XInput_Base = jyUHJNbcvENufHojhEeAVsKiPGgI;
					switch (num)
					{
					default:
						return false;
					case 0:
						uPTRVFEsotYSDjsJaCblePkNTXEA = -1;
						if (platform_XInput_Base.elements == null || platform_XInput_Base.elements.buttons == null)
						{
							return false;
						}
						MfYKPoiLHMpQnflUxoLONhaQKhYq = 0;
						break;
					case 1:
						uPTRVFEsotYSDjsJaCblePkNTXEA = -1;
						MfYKPoiLHMpQnflUxoLONhaQKhYq++;
						break;
					}
					if (MfYKPoiLHMpQnflUxoLONhaQKhYq < platform_XInput_Base.elements.buttons.Length)
					{
						UOTewZERRiPnLHcWRApiSjiXmtwCA = platform_XInput_Base.elements.buttons[MfYKPoiLHMpQnflUxoLONhaQKhYq];
						uPTRVFEsotYSDjsJaCblePkNTXEA = 1;
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
					ZtadNkSzgKjcviCHiCaFoYBzIbuJ ztadNkSzgKjcviCHiCaFoYBzIbuJ;
					if (uPTRVFEsotYSDjsJaCblePkNTXEA == -2 && ImlGhlHJaOOlyVNLrXXaTEwoVmAH == Environment.CurrentManagedThreadId)
					{
						uPTRVFEsotYSDjsJaCblePkNTXEA = 0;
						ztadNkSzgKjcviCHiCaFoYBzIbuJ = this;
					}
					else
					{
						ztadNkSzgKjcviCHiCaFoYBzIbuJ = new ZtadNkSzgKjcviCHiCaFoYBzIbuJ(0);
						ztadNkSzgKjcviCHiCaFoYBzIbuJ.jyUHJNbcvENufHojhEeAVsKiPGgI = jyUHJNbcvENufHojhEeAVsKiPGgI;
					}
					return ztadNkSzgKjcviCHiCaFoYBzIbuJ;
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

			[IteratorStateMachine(typeof(PpbILSxVjnleJjtbJPuKKRaMawsp))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new PpbILSxVjnleJjtbJPuKKRaMawsp(-2)
				{
					WTZiFOJZeCTCSdfVzqfecZhOGriI = this
				};
			}

			[IteratorStateMachine(typeof(ZtadNkSzgKjcviCHiCaFoYBzIbuJ))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new ZtadNkSzgKjcviCHiCaFoYBzIbuJ(-2)
				{
					jyUHJNbcvENufHojhEeAVsKiPGgI = this
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
						ezQploKyylrjKlUlVimuGHFeFvmcA(elementCount);
						return elementCount;
					}

					internal void kAFcebgTXTwgMDBttgKHHuTimkPKB(ElementCount_Base P_0)
					{
						base.ezQploKyylrjKlUlVimuGHFeFvmcA(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool YUlGbRhYJHPBYNfsNPrCsouYRXvm(BridgedControllerHWInfo P_0)
					{
						if (!base.NNJGgfaSIfVWplUEnquSSIiWlKERA(P_0))
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
				private sealed class ZllwQkiPWWfBmSWBhgvFRuLbETaBA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int noRMlHnxTCdMFZdlwXyOsGrcwkbr;

					private Axis cUbLaYETOsEtPxpONFAFFhUGHfev;

					private int jBLqgEyacuMtPDvzmHsfhxIIUMqK;

					public Elements NXorzCvWQUjvXMBObyVuZKmGGjCY;

					private Axis[] uNxnsioeQdUJfcRsZUuiPMeWfgcp;

					private int lZNklvLwJdLQFQaXbxuoRycJGGCs;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return cUbLaYETOsEtPxpONFAFFhUGHfev;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return cUbLaYETOsEtPxpONFAFFhUGHfev;
						}
					}

					[DebuggerHidden]
					public ZllwQkiPWWfBmSWBhgvFRuLbETaBA(int P_0)
					{
						noRMlHnxTCdMFZdlwXyOsGrcwkbr = P_0;
						jBLqgEyacuMtPDvzmHsfhxIIUMqK = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = noRMlHnxTCdMFZdlwXyOsGrcwkbr;
						Elements nXorzCvWQUjvXMBObyVuZKmGGjCY = NXorzCvWQUjvXMBObyVuZKmGGjCY;
						switch (num)
						{
						default:
							return false;
						case 0:
							noRMlHnxTCdMFZdlwXyOsGrcwkbr = -1;
							if (nXorzCvWQUjvXMBObyVuZKmGGjCY.axes == null)
							{
								return false;
							}
							uNxnsioeQdUJfcRsZUuiPMeWfgcp = nXorzCvWQUjvXMBObyVuZKmGGjCY.axes;
							lZNklvLwJdLQFQaXbxuoRycJGGCs = 0;
							break;
						case 1:
							noRMlHnxTCdMFZdlwXyOsGrcwkbr = -1;
							lZNklvLwJdLQFQaXbxuoRycJGGCs++;
							break;
						}
						if (lZNklvLwJdLQFQaXbxuoRycJGGCs < uNxnsioeQdUJfcRsZUuiPMeWfgcp.Length)
						{
							Axis axis = uNxnsioeQdUJfcRsZUuiPMeWfgcp[lZNklvLwJdLQFQaXbxuoRycJGGCs];
							cUbLaYETOsEtPxpONFAFFhUGHfev = axis;
							noRMlHnxTCdMFZdlwXyOsGrcwkbr = 1;
							return true;
						}
						uNxnsioeQdUJfcRsZUuiPMeWfgcp = null;
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
						ZllwQkiPWWfBmSWBhgvFRuLbETaBA zllwQkiPWWfBmSWBhgvFRuLbETaBA;
						if (noRMlHnxTCdMFZdlwXyOsGrcwkbr == -2 && jBLqgEyacuMtPDvzmHsfhxIIUMqK == Environment.CurrentManagedThreadId)
						{
							noRMlHnxTCdMFZdlwXyOsGrcwkbr = 0;
							zllwQkiPWWfBmSWBhgvFRuLbETaBA = this;
						}
						else
						{
							zllwQkiPWWfBmSWBhgvFRuLbETaBA = new ZllwQkiPWWfBmSWBhgvFRuLbETaBA(0);
							zllwQkiPWWfBmSWBhgvFRuLbETaBA.NXorzCvWQUjvXMBObyVuZKmGGjCY = NXorzCvWQUjvXMBObyVuZKmGGjCY;
						}
						return zllwQkiPWWfBmSWBhgvFRuLbETaBA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class cVtFqAxgkdIQRJNaszvVJDFKfYwCA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int njVLjPIeUZQREJIlUKnlRNDSuEYh;

					private Button SNYCyUIVYaMWsDuLCRCQhmoKmfQu;

					private int pSuKypQYiYfXjWvoHKPQTURXWepS;

					public Elements yUkWmYvDBcxrztlCiNfthIJbJrQD;

					private Button[] BDrjbFzgxCGjhEbbwGqLafLhwhnQA;

					private int gYavmFqYQmlvXReTgsHaBLmIifqQ;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return SNYCyUIVYaMWsDuLCRCQhmoKmfQu;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return SNYCyUIVYaMWsDuLCRCQhmoKmfQu;
						}
					}

					[DebuggerHidden]
					public cVtFqAxgkdIQRJNaszvVJDFKfYwCA(int P_0)
					{
						njVLjPIeUZQREJIlUKnlRNDSuEYh = P_0;
						pSuKypQYiYfXjWvoHKPQTURXWepS = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = njVLjPIeUZQREJIlUKnlRNDSuEYh;
						Elements elements = yUkWmYvDBcxrztlCiNfthIJbJrQD;
						switch (num)
						{
						default:
							return false;
						case 0:
							njVLjPIeUZQREJIlUKnlRNDSuEYh = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							BDrjbFzgxCGjhEbbwGqLafLhwhnQA = elements.buttons;
							gYavmFqYQmlvXReTgsHaBLmIifqQ = 0;
							break;
						case 1:
							njVLjPIeUZQREJIlUKnlRNDSuEYh = -1;
							gYavmFqYQmlvXReTgsHaBLmIifqQ++;
							break;
						}
						if (gYavmFqYQmlvXReTgsHaBLmIifqQ < BDrjbFzgxCGjhEbbwGqLafLhwhnQA.Length)
						{
							Button sNYCyUIVYaMWsDuLCRCQhmoKmfQu = BDrjbFzgxCGjhEbbwGqLafLhwhnQA[gYavmFqYQmlvXReTgsHaBLmIifqQ];
							SNYCyUIVYaMWsDuLCRCQhmoKmfQu = sNYCyUIVYaMWsDuLCRCQhmoKmfQu;
							njVLjPIeUZQREJIlUKnlRNDSuEYh = 1;
							return true;
						}
						BDrjbFzgxCGjhEbbwGqLafLhwhnQA = null;
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
						cVtFqAxgkdIQRJNaszvVJDFKfYwCA cVtFqAxgkdIQRJNaszvVJDFKfYwCA2;
						if (njVLjPIeUZQREJIlUKnlRNDSuEYh == -2 && pSuKypQYiYfXjWvoHKPQTURXWepS == Environment.CurrentManagedThreadId)
						{
							njVLjPIeUZQREJIlUKnlRNDSuEYh = 0;
							cVtFqAxgkdIQRJNaszvVJDFKfYwCA2 = this;
						}
						else
						{
							cVtFqAxgkdIQRJNaszvVJDFKfYwCA2 = new cVtFqAxgkdIQRJNaszvVJDFKfYwCA(0);
							cVtFqAxgkdIQRJNaszvVJDFKfYwCA2.yUkWmYvDBcxrztlCiNfthIJbJrQD = yUkWmYvDBcxrztlCiNfthIJbJrQD;
						}
						return cVtFqAxgkdIQRJNaszvVJDFKfYwCA2;
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

				[IteratorStateMachine(typeof(ZllwQkiPWWfBmSWBhgvFRuLbETaBA))]
				public IEnumerable<Axis> IterateAxes()
				{
					return new ZllwQkiPWWfBmSWBhgvFRuLbETaBA(-2)
					{
						NXorzCvWQUjvXMBObyVuZKmGGjCY = this
					};
				}

				[IteratorStateMachine(typeof(cVtFqAxgkdIQRJNaszvVJDFKfYwCA))]
				public IEnumerable<Button> IterateButtons()
				{
					return new cVtFqAxgkdIQRJNaszvVJDFKfYwCA(-2)
					{
						yUkWmYvDBcxrztlCiNfthIJbJrQD = this
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

			private sealed class pGxfqMTRLjRPWnkAobJHbZZzYsSF : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int VEkiVSAlgKFpbuUjUZNmeskHxcML;

				private Axis EPESooXPOVjvLWbIpclGGdYrlYXHA;

				private int IcvQQgFzWmpwliOkxSdHeDPjhAbY;

				public Platform_OSX_Base wkbCzCAOMMsgYcwKmXqgSjtAfrrE;

				private int QvDTPIKaHVcfmEeYZKpZxXDrOaGdA;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return EPESooXPOVjvLWbIpclGGdYrlYXHA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return EPESooXPOVjvLWbIpclGGdYrlYXHA;
					}
				}

				[DebuggerHidden]
				public pGxfqMTRLjRPWnkAobJHbZZzYsSF(int P_0)
				{
					VEkiVSAlgKFpbuUjUZNmeskHxcML = P_0;
					IcvQQgFzWmpwliOkxSdHeDPjhAbY = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int vEkiVSAlgKFpbuUjUZNmeskHxcML = VEkiVSAlgKFpbuUjUZNmeskHxcML;
					Platform_OSX_Base platform_OSX_Base = wkbCzCAOMMsgYcwKmXqgSjtAfrrE;
					switch (vEkiVSAlgKFpbuUjUZNmeskHxcML)
					{
					default:
						return false;
					case 0:
						VEkiVSAlgKFpbuUjUZNmeskHxcML = -1;
						if (platform_OSX_Base.elements == null || platform_OSX_Base.elements.axes == null)
						{
							return false;
						}
						QvDTPIKaHVcfmEeYZKpZxXDrOaGdA = 0;
						break;
					case 1:
						VEkiVSAlgKFpbuUjUZNmeskHxcML = -1;
						QvDTPIKaHVcfmEeYZKpZxXDrOaGdA++;
						break;
					}
					if (QvDTPIKaHVcfmEeYZKpZxXDrOaGdA < platform_OSX_Base.elements.axes.Length)
					{
						EPESooXPOVjvLWbIpclGGdYrlYXHA = platform_OSX_Base.elements.axes[QvDTPIKaHVcfmEeYZKpZxXDrOaGdA];
						VEkiVSAlgKFpbuUjUZNmeskHxcML = 1;
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
					pGxfqMTRLjRPWnkAobJHbZZzYsSF pGxfqMTRLjRPWnkAobJHbZZzYsSF2;
					if (VEkiVSAlgKFpbuUjUZNmeskHxcML == -2 && IcvQQgFzWmpwliOkxSdHeDPjhAbY == Environment.CurrentManagedThreadId)
					{
						VEkiVSAlgKFpbuUjUZNmeskHxcML = 0;
						pGxfqMTRLjRPWnkAobJHbZZzYsSF2 = this;
					}
					else
					{
						pGxfqMTRLjRPWnkAobJHbZZzYsSF2 = new pGxfqMTRLjRPWnkAobJHbZZzYsSF(0);
						pGxfqMTRLjRPWnkAobJHbZZzYsSF2.wkbCzCAOMMsgYcwKmXqgSjtAfrrE = wkbCzCAOMMsgYcwKmXqgSjtAfrrE;
					}
					return pGxfqMTRLjRPWnkAobJHbZZzYsSF2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class CkCbpGlQaZHLCqOdtqZkKFWWYzzb : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int RibWnedrcNxsNTDzMeOZArfLpudfA;

				private Button pmrisGSCAbCazUmQMLrULsSjHhXt;

				private int YsNjoHVHFJtMhVBKZchVvobHxvMW;

				public Platform_OSX_Base jIRntBBkcxsCDmGpzuVPwQWjgMDR;

				private int JPpMwDqKaXKSIqGclqQtfhpzNvxN;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return pmrisGSCAbCazUmQMLrULsSjHhXt;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return pmrisGSCAbCazUmQMLrULsSjHhXt;
					}
				}

				[DebuggerHidden]
				public CkCbpGlQaZHLCqOdtqZkKFWWYzzb(int P_0)
				{
					RibWnedrcNxsNTDzMeOZArfLpudfA = P_0;
					YsNjoHVHFJtMhVBKZchVvobHxvMW = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int ribWnedrcNxsNTDzMeOZArfLpudfA = RibWnedrcNxsNTDzMeOZArfLpudfA;
					Platform_OSX_Base platform_OSX_Base = jIRntBBkcxsCDmGpzuVPwQWjgMDR;
					switch (ribWnedrcNxsNTDzMeOZArfLpudfA)
					{
					default:
						return false;
					case 0:
						RibWnedrcNxsNTDzMeOZArfLpudfA = -1;
						if (platform_OSX_Base.elements == null || platform_OSX_Base.elements.buttons == null)
						{
							return false;
						}
						JPpMwDqKaXKSIqGclqQtfhpzNvxN = 0;
						break;
					case 1:
						RibWnedrcNxsNTDzMeOZArfLpudfA = -1;
						JPpMwDqKaXKSIqGclqQtfhpzNvxN++;
						break;
					}
					if (JPpMwDqKaXKSIqGclqQtfhpzNvxN < platform_OSX_Base.elements.buttons.Length)
					{
						pmrisGSCAbCazUmQMLrULsSjHhXt = platform_OSX_Base.elements.buttons[JPpMwDqKaXKSIqGclqQtfhpzNvxN];
						RibWnedrcNxsNTDzMeOZArfLpudfA = 1;
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
					CkCbpGlQaZHLCqOdtqZkKFWWYzzb ckCbpGlQaZHLCqOdtqZkKFWWYzzb;
					if (RibWnedrcNxsNTDzMeOZArfLpudfA == -2 && YsNjoHVHFJtMhVBKZchVvobHxvMW == Environment.CurrentManagedThreadId)
					{
						RibWnedrcNxsNTDzMeOZArfLpudfA = 0;
						ckCbpGlQaZHLCqOdtqZkKFWWYzzb = this;
					}
					else
					{
						ckCbpGlQaZHLCqOdtqZkKFWWYzzb = new CkCbpGlQaZHLCqOdtqZkKFWWYzzb(0);
						ckCbpGlQaZHLCqOdtqZkKFWWYzzb.jIRntBBkcxsCDmGpzuVPwQWjgMDR = jIRntBBkcxsCDmGpzuVPwQWjgMDR;
					}
					return ckCbpGlQaZHLCqOdtqZkKFWWYzzb;
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

			[IteratorStateMachine(typeof(pGxfqMTRLjRPWnkAobJHbZZzYsSF))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new pGxfqMTRLjRPWnkAobJHbZZzYsSF(-2)
				{
					wkbCzCAOMMsgYcwKmXqgSjtAfrrE = this
				};
			}

			[IteratorStateMachine(typeof(CkCbpGlQaZHLCqOdtqZkKFWWYzzb))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new CkCbpGlQaZHLCqOdtqZkKFWWYzzb(-2)
				{
					jIRntBBkcxsCDmGpzuVPwQWjgMDR = this
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
						ezQploKyylrjKlUlVimuGHFeFvmcA(elementCount);
						return elementCount;
					}

					internal void XGTgKdqajIuoyMyUDYympUQPFJwl(ElementCount_Base P_0)
					{
						base.ezQploKyylrjKlUlVimuGHFeFvmcA(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool VEHCzcPTsXtZblSdwcRSFMzkfZrE(BridgedControllerHWInfo P_0)
					{
						if (!base.NNJGgfaSIfVWplUEnquSSIiWlKERA(P_0))
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
				private sealed class PrHblPqvBtAKhRkiobandaeCdlNDb : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int VxHfdqKITSFxrFidEtsUESpubuYec;

					private Axis RCLEnLArYNnzSnyvKjjHVmWzuGox;

					private int dJRbIPXZChFqMLuRxYhDJcjgeSVP;

					public Elements UOWSbtspPbxKrsDfCXBEHuJLeySR;

					private int muWWxiSTWikKOCOBzPCIbcFvhKZJ;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return RCLEnLArYNnzSnyvKjjHVmWzuGox;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RCLEnLArYNnzSnyvKjjHVmWzuGox;
						}
					}

					[DebuggerHidden]
					public PrHblPqvBtAKhRkiobandaeCdlNDb(int P_0)
					{
						VxHfdqKITSFxrFidEtsUESpubuYec = P_0;
						dJRbIPXZChFqMLuRxYhDJcjgeSVP = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int vxHfdqKITSFxrFidEtsUESpubuYec = VxHfdqKITSFxrFidEtsUESpubuYec;
						Elements uOWSbtspPbxKrsDfCXBEHuJLeySR = UOWSbtspPbxKrsDfCXBEHuJLeySR;
						switch (vxHfdqKITSFxrFidEtsUESpubuYec)
						{
						default:
							return false;
						case 0:
							VxHfdqKITSFxrFidEtsUESpubuYec = -1;
							if (uOWSbtspPbxKrsDfCXBEHuJLeySR.axes == null)
							{
								return false;
							}
							muWWxiSTWikKOCOBzPCIbcFvhKZJ = 0;
							break;
						case 1:
							VxHfdqKITSFxrFidEtsUESpubuYec = -1;
							muWWxiSTWikKOCOBzPCIbcFvhKZJ++;
							break;
						}
						if (muWWxiSTWikKOCOBzPCIbcFvhKZJ < uOWSbtspPbxKrsDfCXBEHuJLeySR.axes.Length)
						{
							RCLEnLArYNnzSnyvKjjHVmWzuGox = uOWSbtspPbxKrsDfCXBEHuJLeySR.axes[muWWxiSTWikKOCOBzPCIbcFvhKZJ];
							VxHfdqKITSFxrFidEtsUESpubuYec = 1;
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
						PrHblPqvBtAKhRkiobandaeCdlNDb prHblPqvBtAKhRkiobandaeCdlNDb;
						if (VxHfdqKITSFxrFidEtsUESpubuYec == -2 && dJRbIPXZChFqMLuRxYhDJcjgeSVP == Environment.CurrentManagedThreadId)
						{
							VxHfdqKITSFxrFidEtsUESpubuYec = 0;
							prHblPqvBtAKhRkiobandaeCdlNDb = this;
						}
						else
						{
							prHblPqvBtAKhRkiobandaeCdlNDb = new PrHblPqvBtAKhRkiobandaeCdlNDb(0);
							prHblPqvBtAKhRkiobandaeCdlNDb.UOWSbtspPbxKrsDfCXBEHuJLeySR = UOWSbtspPbxKrsDfCXBEHuJLeySR;
						}
						return prHblPqvBtAKhRkiobandaeCdlNDb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class gmaJLfyYUuHqcFaqFhLBVAxNhotB : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int QVoOOlCucLHAwXKlFopFwjFWrDeo;

					private Button zBGXcuSbxVxmqMgLKhHXepbCGpLbA;

					private int LqpGuwWbLVGGTugCbhRMstrWfVCaA;

					public Elements zHgZkyBCLyYgCkuKSpJClmCGlTLT;

					private int NrRVCzuiVuaxDsYddoBQrjXOJWvb;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return zBGXcuSbxVxmqMgLKhHXepbCGpLbA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return zBGXcuSbxVxmqMgLKhHXepbCGpLbA;
						}
					}

					[DebuggerHidden]
					public gmaJLfyYUuHqcFaqFhLBVAxNhotB(int P_0)
					{
						QVoOOlCucLHAwXKlFopFwjFWrDeo = P_0;
						LqpGuwWbLVGGTugCbhRMstrWfVCaA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int qVoOOlCucLHAwXKlFopFwjFWrDeo = QVoOOlCucLHAwXKlFopFwjFWrDeo;
						Elements elements = zHgZkyBCLyYgCkuKSpJClmCGlTLT;
						switch (qVoOOlCucLHAwXKlFopFwjFWrDeo)
						{
						default:
							return false;
						case 0:
							QVoOOlCucLHAwXKlFopFwjFWrDeo = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							NrRVCzuiVuaxDsYddoBQrjXOJWvb = 0;
							break;
						case 1:
							QVoOOlCucLHAwXKlFopFwjFWrDeo = -1;
							NrRVCzuiVuaxDsYddoBQrjXOJWvb++;
							break;
						}
						if (NrRVCzuiVuaxDsYddoBQrjXOJWvb < elements.buttons.Length)
						{
							zBGXcuSbxVxmqMgLKhHXepbCGpLbA = elements.buttons[NrRVCzuiVuaxDsYddoBQrjXOJWvb];
							QVoOOlCucLHAwXKlFopFwjFWrDeo = 1;
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
						gmaJLfyYUuHqcFaqFhLBVAxNhotB gmaJLfyYUuHqcFaqFhLBVAxNhotB2;
						if (QVoOOlCucLHAwXKlFopFwjFWrDeo == -2 && LqpGuwWbLVGGTugCbhRMstrWfVCaA == Environment.CurrentManagedThreadId)
						{
							QVoOOlCucLHAwXKlFopFwjFWrDeo = 0;
							gmaJLfyYUuHqcFaqFhLBVAxNhotB2 = this;
						}
						else
						{
							gmaJLfyYUuHqcFaqFhLBVAxNhotB2 = new gmaJLfyYUuHqcFaqFhLBVAxNhotB(0);
							gmaJLfyYUuHqcFaqFhLBVAxNhotB2.zHgZkyBCLyYgCkuKSpJClmCGlTLT = zHgZkyBCLyYgCkuKSpJClmCGlTLT;
						}
						return gmaJLfyYUuHqcFaqFhLBVAxNhotB2;
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
					[IteratorStateMachine(typeof(PrHblPqvBtAKhRkiobandaeCdlNDb))]
					get
					{
						return new PrHblPqvBtAKhRkiobandaeCdlNDb(-2)
						{
							UOWSbtspPbxKrsDfCXBEHuJLeySR = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(gmaJLfyYUuHqcFaqFhLBVAxNhotB))]
					get
					{
						return new gmaJLfyYUuHqcFaqFhLBVAxNhotB(-2)
						{
							zHgZkyBCLyYgCkuKSpJClmCGlTLT = this
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

			private sealed class nLXiIVvJzRAjNInauBduGnuXZiFgA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int dMCLwvZIuZoPNUqMZnipEHpSpnRE;

				private Axis PZtEWUbGHlHSzPkHVMFUAxrezOqbB;

				private int MrlgEGSYXBOFfKUkgNSeGmNhklLd;

				public Platform_Linux_Base htXprBSKZRvCcrwILLuHkTgYjmAg;

				private int spVtkvyWyTqMvKpYmBJuFzRcumgpA;

				private int fBJRIcKdxSRGxqGxXQgqViKxovzN;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return PZtEWUbGHlHSzPkHVMFUAxrezOqbB;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return PZtEWUbGHlHSzPkHVMFUAxrezOqbB;
					}
				}

				[DebuggerHidden]
				public nLXiIVvJzRAjNInauBduGnuXZiFgA(int P_0)
				{
					dMCLwvZIuZoPNUqMZnipEHpSpnRE = P_0;
					MrlgEGSYXBOFfKUkgNSeGmNhklLd = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = dMCLwvZIuZoPNUqMZnipEHpSpnRE;
					Platform_Linux_Base platform_Linux_Base = htXprBSKZRvCcrwILLuHkTgYjmAg;
					switch (num)
					{
					default:
						return false;
					case 0:
						dMCLwvZIuZoPNUqMZnipEHpSpnRE = -1;
						if (platform_Linux_Base.elements == null || platform_Linux_Base.elements.axes == null)
						{
							return false;
						}
						spVtkvyWyTqMvKpYmBJuFzRcumgpA = platform_Linux_Base.elements.axes.Length;
						fBJRIcKdxSRGxqGxXQgqViKxovzN = 0;
						break;
					case 1:
						dMCLwvZIuZoPNUqMZnipEHpSpnRE = -1;
						fBJRIcKdxSRGxqGxXQgqViKxovzN++;
						break;
					}
					if (fBJRIcKdxSRGxqGxXQgqViKxovzN < spVtkvyWyTqMvKpYmBJuFzRcumgpA)
					{
						PZtEWUbGHlHSzPkHVMFUAxrezOqbB = platform_Linux_Base.elements.axes[fBJRIcKdxSRGxqGxXQgqViKxovzN];
						dMCLwvZIuZoPNUqMZnipEHpSpnRE = 1;
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
					nLXiIVvJzRAjNInauBduGnuXZiFgA nLXiIVvJzRAjNInauBduGnuXZiFgA2;
					if (dMCLwvZIuZoPNUqMZnipEHpSpnRE == -2 && MrlgEGSYXBOFfKUkgNSeGmNhklLd == Environment.CurrentManagedThreadId)
					{
						dMCLwvZIuZoPNUqMZnipEHpSpnRE = 0;
						nLXiIVvJzRAjNInauBduGnuXZiFgA2 = this;
					}
					else
					{
						nLXiIVvJzRAjNInauBduGnuXZiFgA2 = new nLXiIVvJzRAjNInauBduGnuXZiFgA(0);
						nLXiIVvJzRAjNInauBduGnuXZiFgA2.htXprBSKZRvCcrwILLuHkTgYjmAg = htXprBSKZRvCcrwILLuHkTgYjmAg;
					}
					return nLXiIVvJzRAjNInauBduGnuXZiFgA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class VHXYWKwaJvJGNStYUSAQbBdDcmFh : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int hPoDYGCaRwChFvSsZyJwHHOprfIx;

				private Button ennBhArbvFIFFvincRBCmDUWDAxj;

				private int aueCEeJKwCiodBNGvOJPXgFhLokCA;

				public Platform_Linux_Base IXTjuXAlGDeqDYSDhZdPcGmlJgAF;

				private int FppbdbQJHJrCNKDsHsQQHKuAnbjT;

				private int WQMAmAjqpHAZAutKcjtFdEWHMDVzb;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ennBhArbvFIFFvincRBCmDUWDAxj;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ennBhArbvFIFFvincRBCmDUWDAxj;
					}
				}

				[DebuggerHidden]
				public VHXYWKwaJvJGNStYUSAQbBdDcmFh(int P_0)
				{
					hPoDYGCaRwChFvSsZyJwHHOprfIx = P_0;
					aueCEeJKwCiodBNGvOJPXgFhLokCA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hPoDYGCaRwChFvSsZyJwHHOprfIx;
					Platform_Linux_Base iXTjuXAlGDeqDYSDhZdPcGmlJgAF = IXTjuXAlGDeqDYSDhZdPcGmlJgAF;
					switch (num)
					{
					default:
						return false;
					case 0:
						hPoDYGCaRwChFvSsZyJwHHOprfIx = -1;
						if (iXTjuXAlGDeqDYSDhZdPcGmlJgAF.elements == null || iXTjuXAlGDeqDYSDhZdPcGmlJgAF.elements.buttons == null)
						{
							return false;
						}
						FppbdbQJHJrCNKDsHsQQHKuAnbjT = iXTjuXAlGDeqDYSDhZdPcGmlJgAF.elements.buttons.Length;
						WQMAmAjqpHAZAutKcjtFdEWHMDVzb = 0;
						break;
					case 1:
						hPoDYGCaRwChFvSsZyJwHHOprfIx = -1;
						WQMAmAjqpHAZAutKcjtFdEWHMDVzb++;
						break;
					}
					if (WQMAmAjqpHAZAutKcjtFdEWHMDVzb < FppbdbQJHJrCNKDsHsQQHKuAnbjT)
					{
						ennBhArbvFIFFvincRBCmDUWDAxj = iXTjuXAlGDeqDYSDhZdPcGmlJgAF.elements.buttons[WQMAmAjqpHAZAutKcjtFdEWHMDVzb];
						hPoDYGCaRwChFvSsZyJwHHOprfIx = 1;
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
					VHXYWKwaJvJGNStYUSAQbBdDcmFh vHXYWKwaJvJGNStYUSAQbBdDcmFh;
					if (hPoDYGCaRwChFvSsZyJwHHOprfIx == -2 && aueCEeJKwCiodBNGvOJPXgFhLokCA == Environment.CurrentManagedThreadId)
					{
						hPoDYGCaRwChFvSsZyJwHHOprfIx = 0;
						vHXYWKwaJvJGNStYUSAQbBdDcmFh = this;
					}
					else
					{
						vHXYWKwaJvJGNStYUSAQbBdDcmFh = new VHXYWKwaJvJGNStYUSAQbBdDcmFh(0);
						vHXYWKwaJvJGNStYUSAQbBdDcmFh.IXTjuXAlGDeqDYSDhZdPcGmlJgAF = IXTjuXAlGDeqDYSDhZdPcGmlJgAF;
					}
					return vHXYWKwaJvJGNStYUSAQbBdDcmFh;
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

			[IteratorStateMachine(typeof(nLXiIVvJzRAjNInauBduGnuXZiFgA))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new nLXiIVvJzRAjNInauBduGnuXZiFgA(-2)
				{
					htXprBSKZRvCcrwILLuHkTgYjmAg = this
				};
			}

			[IteratorStateMachine(typeof(VHXYWKwaJvJGNStYUSAQbBdDcmFh))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new VHXYWKwaJvJGNStYUSAQbBdDcmFh(-2)
				{
					IXTjuXAlGDeqDYSDhZdPcGmlJgAF = this
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
						ezQploKyylrjKlUlVimuGHFeFvmcA(elementCount);
						return elementCount;
					}

					internal void SLfiBStnXXMqOHYNeiytyYOOWtRe(ElementCount_Base P_0)
					{
						base.ezQploKyylrjKlUlVimuGHFeFvmcA(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool XwnTGHeAKRzwjamMdkuSKbmXKJao(BridgedControllerHWInfo P_0)
					{
						if (!base.NNJGgfaSIfVWplUEnquSSIiWlKERA(P_0))
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
				private sealed class OAcThAmXgVBQrJHDuewBALhzEXSO : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int HPzRRDcTXmopCUQPxvRyPgaMGyRdA;

					private Axis QCRNoYVXiHdLUHdnWWHJVDdUKNeU;

					private int ZmYWBomkfVczYhMZbHLZiwbFepXlb;

					public Elements RMaLhzqoswEHfheOFkbNQpojpISJ;

					private int CcDWxoOQtBXOESEjHTnYLCsEFhZy;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return QCRNoYVXiHdLUHdnWWHJVDdUKNeU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return QCRNoYVXiHdLUHdnWWHJVDdUKNeU;
						}
					}

					[DebuggerHidden]
					public OAcThAmXgVBQrJHDuewBALhzEXSO(int P_0)
					{
						HPzRRDcTXmopCUQPxvRyPgaMGyRdA = P_0;
						ZmYWBomkfVczYhMZbHLZiwbFepXlb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int hPzRRDcTXmopCUQPxvRyPgaMGyRdA = HPzRRDcTXmopCUQPxvRyPgaMGyRdA;
						Elements rMaLhzqoswEHfheOFkbNQpojpISJ = RMaLhzqoswEHfheOFkbNQpojpISJ;
						switch (hPzRRDcTXmopCUQPxvRyPgaMGyRdA)
						{
						default:
							return false;
						case 0:
							HPzRRDcTXmopCUQPxvRyPgaMGyRdA = -1;
							if (rMaLhzqoswEHfheOFkbNQpojpISJ.axes == null)
							{
								return false;
							}
							CcDWxoOQtBXOESEjHTnYLCsEFhZy = 0;
							break;
						case 1:
							HPzRRDcTXmopCUQPxvRyPgaMGyRdA = -1;
							CcDWxoOQtBXOESEjHTnYLCsEFhZy++;
							break;
						}
						if (CcDWxoOQtBXOESEjHTnYLCsEFhZy < rMaLhzqoswEHfheOFkbNQpojpISJ.axes.Length)
						{
							QCRNoYVXiHdLUHdnWWHJVDdUKNeU = rMaLhzqoswEHfheOFkbNQpojpISJ.axes[CcDWxoOQtBXOESEjHTnYLCsEFhZy];
							HPzRRDcTXmopCUQPxvRyPgaMGyRdA = 1;
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
						OAcThAmXgVBQrJHDuewBALhzEXSO oAcThAmXgVBQrJHDuewBALhzEXSO;
						if (HPzRRDcTXmopCUQPxvRyPgaMGyRdA == -2 && ZmYWBomkfVczYhMZbHLZiwbFepXlb == Environment.CurrentManagedThreadId)
						{
							HPzRRDcTXmopCUQPxvRyPgaMGyRdA = 0;
							oAcThAmXgVBQrJHDuewBALhzEXSO = this;
						}
						else
						{
							oAcThAmXgVBQrJHDuewBALhzEXSO = new OAcThAmXgVBQrJHDuewBALhzEXSO(0);
							oAcThAmXgVBQrJHDuewBALhzEXSO.RMaLhzqoswEHfheOFkbNQpojpISJ = RMaLhzqoswEHfheOFkbNQpojpISJ;
						}
						return oAcThAmXgVBQrJHDuewBALhzEXSO;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class hDzbCLeYqhCFZFqBkuWZvrJZjnoSA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int oRsGlJonSzpRlTIIbJFnEPNtksNv;

					private Button aapiWKXwxthXkDRgeAqCqrhwFJEcA;

					private int EUoZLcXlqKAUXbNtGCmJXyFtPGJm;

					public Elements HSadhKURxlMtoXnFGRdbRdXhPDyq;

					private int ZAfkHzFmboYbmMoUmXyEvLNYkvli;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return aapiWKXwxthXkDRgeAqCqrhwFJEcA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aapiWKXwxthXkDRgeAqCqrhwFJEcA;
						}
					}

					[DebuggerHidden]
					public hDzbCLeYqhCFZFqBkuWZvrJZjnoSA(int P_0)
					{
						oRsGlJonSzpRlTIIbJFnEPNtksNv = P_0;
						EUoZLcXlqKAUXbNtGCmJXyFtPGJm = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = oRsGlJonSzpRlTIIbJFnEPNtksNv;
						Elements hSadhKURxlMtoXnFGRdbRdXhPDyq = HSadhKURxlMtoXnFGRdbRdXhPDyq;
						switch (num)
						{
						default:
							return false;
						case 0:
							oRsGlJonSzpRlTIIbJFnEPNtksNv = -1;
							if (hSadhKURxlMtoXnFGRdbRdXhPDyq.buttons == null)
							{
								return false;
							}
							ZAfkHzFmboYbmMoUmXyEvLNYkvli = 0;
							break;
						case 1:
							oRsGlJonSzpRlTIIbJFnEPNtksNv = -1;
							ZAfkHzFmboYbmMoUmXyEvLNYkvli++;
							break;
						}
						if (ZAfkHzFmboYbmMoUmXyEvLNYkvli < hSadhKURxlMtoXnFGRdbRdXhPDyq.buttons.Length)
						{
							aapiWKXwxthXkDRgeAqCqrhwFJEcA = hSadhKURxlMtoXnFGRdbRdXhPDyq.buttons[ZAfkHzFmboYbmMoUmXyEvLNYkvli];
							oRsGlJonSzpRlTIIbJFnEPNtksNv = 1;
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
						hDzbCLeYqhCFZFqBkuWZvrJZjnoSA hDzbCLeYqhCFZFqBkuWZvrJZjnoSA2;
						if (oRsGlJonSzpRlTIIbJFnEPNtksNv == -2 && EUoZLcXlqKAUXbNtGCmJXyFtPGJm == Environment.CurrentManagedThreadId)
						{
							oRsGlJonSzpRlTIIbJFnEPNtksNv = 0;
							hDzbCLeYqhCFZFqBkuWZvrJZjnoSA2 = this;
						}
						else
						{
							hDzbCLeYqhCFZFqBkuWZvrJZjnoSA2 = new hDzbCLeYqhCFZFqBkuWZvrJZjnoSA(0);
							hDzbCLeYqhCFZFqBkuWZvrJZjnoSA2.HSadhKURxlMtoXnFGRdbRdXhPDyq = HSadhKURxlMtoXnFGRdbRdXhPDyq;
						}
						return hDzbCLeYqhCFZFqBkuWZvrJZjnoSA2;
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
					[IteratorStateMachine(typeof(OAcThAmXgVBQrJHDuewBALhzEXSO))]
					get
					{
						return new OAcThAmXgVBQrJHDuewBALhzEXSO(-2)
						{
							RMaLhzqoswEHfheOFkbNQpojpISJ = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(hDzbCLeYqhCFZFqBkuWZvrJZjnoSA))]
					get
					{
						return new hDzbCLeYqhCFZFqBkuWZvrJZjnoSA(-2)
						{
							HSadhKURxlMtoXnFGRdbRdXhPDyq = this
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

			private sealed class KTJnnfIfiqVAoQjFLaiFQKQQxTFd : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int JtiIkOKCLrbaEeepxaEcEIGCHbukB;

				private Axis rhXcxBfIYZTQbSDFIsYMfjJdtZHW;

				private int tiMxQYULRvMNthTLLcMCRbLoYGXB;

				public Platform_WindowsUWP_Base KICQESPwgyUZdmJwERlwohLlFPBAA;

				private int kwFOPebsAQfchBCPEmWiigSGOcdBb;

				private int BfQOwUxVChyjNXsafwDzHADkzaCh;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return rhXcxBfIYZTQbSDFIsYMfjJdtZHW;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return rhXcxBfIYZTQbSDFIsYMfjJdtZHW;
					}
				}

				[DebuggerHidden]
				public KTJnnfIfiqVAoQjFLaiFQKQQxTFd(int P_0)
				{
					JtiIkOKCLrbaEeepxaEcEIGCHbukB = P_0;
					tiMxQYULRvMNthTLLcMCRbLoYGXB = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int jtiIkOKCLrbaEeepxaEcEIGCHbukB = JtiIkOKCLrbaEeepxaEcEIGCHbukB;
					Platform_WindowsUWP_Base kICQESPwgyUZdmJwERlwohLlFPBAA = KICQESPwgyUZdmJwERlwohLlFPBAA;
					switch (jtiIkOKCLrbaEeepxaEcEIGCHbukB)
					{
					default:
						return false;
					case 0:
						JtiIkOKCLrbaEeepxaEcEIGCHbukB = -1;
						if (kICQESPwgyUZdmJwERlwohLlFPBAA.elements == null || kICQESPwgyUZdmJwERlwohLlFPBAA.elements.axes == null)
						{
							return false;
						}
						kwFOPebsAQfchBCPEmWiigSGOcdBb = kICQESPwgyUZdmJwERlwohLlFPBAA.elements.axes.Length;
						BfQOwUxVChyjNXsafwDzHADkzaCh = 0;
						break;
					case 1:
						JtiIkOKCLrbaEeepxaEcEIGCHbukB = -1;
						BfQOwUxVChyjNXsafwDzHADkzaCh++;
						break;
					}
					if (BfQOwUxVChyjNXsafwDzHADkzaCh < kwFOPebsAQfchBCPEmWiigSGOcdBb)
					{
						rhXcxBfIYZTQbSDFIsYMfjJdtZHW = kICQESPwgyUZdmJwERlwohLlFPBAA.elements.axes[BfQOwUxVChyjNXsafwDzHADkzaCh];
						JtiIkOKCLrbaEeepxaEcEIGCHbukB = 1;
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
					KTJnnfIfiqVAoQjFLaiFQKQQxTFd kTJnnfIfiqVAoQjFLaiFQKQQxTFd;
					if (JtiIkOKCLrbaEeepxaEcEIGCHbukB == -2 && tiMxQYULRvMNthTLLcMCRbLoYGXB == Environment.CurrentManagedThreadId)
					{
						JtiIkOKCLrbaEeepxaEcEIGCHbukB = 0;
						kTJnnfIfiqVAoQjFLaiFQKQQxTFd = this;
					}
					else
					{
						kTJnnfIfiqVAoQjFLaiFQKQQxTFd = new KTJnnfIfiqVAoQjFLaiFQKQQxTFd(0);
						kTJnnfIfiqVAoQjFLaiFQKQQxTFd.KICQESPwgyUZdmJwERlwohLlFPBAA = KICQESPwgyUZdmJwERlwohLlFPBAA;
					}
					return kTJnnfIfiqVAoQjFLaiFQKQQxTFd;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class wtgbWlbOADZqZnrvfEzYfBFvpYTyA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int rZjAXsXuKfIuYGOPsPaCuxwgsVyjA;

				private Button lGTQPlOZkFesAniKZpVzMlXExNfr;

				private int gFQmmLPrCvTKgCPnhKosKikLiVgz;

				public Platform_WindowsUWP_Base vHJPbqyGGEGKtFtLovEBNqJpTqrP;

				private int gdxdjvETOEzjCShWmhSKbmdImhjkA;

				private int vKtfprgqESaKorWVtazRYxbhAMiN;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return lGTQPlOZkFesAniKZpVzMlXExNfr;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return lGTQPlOZkFesAniKZpVzMlXExNfr;
					}
				}

				[DebuggerHidden]
				public wtgbWlbOADZqZnrvfEzYfBFvpYTyA(int P_0)
				{
					rZjAXsXuKfIuYGOPsPaCuxwgsVyjA = P_0;
					gFQmmLPrCvTKgCPnhKosKikLiVgz = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = rZjAXsXuKfIuYGOPsPaCuxwgsVyjA;
					Platform_WindowsUWP_Base platform_WindowsUWP_Base = vHJPbqyGGEGKtFtLovEBNqJpTqrP;
					switch (num)
					{
					default:
						return false;
					case 0:
						rZjAXsXuKfIuYGOPsPaCuxwgsVyjA = -1;
						if (platform_WindowsUWP_Base.elements == null || platform_WindowsUWP_Base.elements.buttons == null)
						{
							return false;
						}
						gdxdjvETOEzjCShWmhSKbmdImhjkA = platform_WindowsUWP_Base.elements.buttons.Length;
						vKtfprgqESaKorWVtazRYxbhAMiN = 0;
						break;
					case 1:
						rZjAXsXuKfIuYGOPsPaCuxwgsVyjA = -1;
						vKtfprgqESaKorWVtazRYxbhAMiN++;
						break;
					}
					if (vKtfprgqESaKorWVtazRYxbhAMiN < gdxdjvETOEzjCShWmhSKbmdImhjkA)
					{
						lGTQPlOZkFesAniKZpVzMlXExNfr = platform_WindowsUWP_Base.elements.buttons[vKtfprgqESaKorWVtazRYxbhAMiN];
						rZjAXsXuKfIuYGOPsPaCuxwgsVyjA = 1;
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
					wtgbWlbOADZqZnrvfEzYfBFvpYTyA wtgbWlbOADZqZnrvfEzYfBFvpYTyA2;
					if (rZjAXsXuKfIuYGOPsPaCuxwgsVyjA == -2 && gFQmmLPrCvTKgCPnhKosKikLiVgz == Environment.CurrentManagedThreadId)
					{
						rZjAXsXuKfIuYGOPsPaCuxwgsVyjA = 0;
						wtgbWlbOADZqZnrvfEzYfBFvpYTyA2 = this;
					}
					else
					{
						wtgbWlbOADZqZnrvfEzYfBFvpYTyA2 = new wtgbWlbOADZqZnrvfEzYfBFvpYTyA(0);
						wtgbWlbOADZqZnrvfEzYfBFvpYTyA2.vHJPbqyGGEGKtFtLovEBNqJpTqrP = vHJPbqyGGEGKtFtLovEBNqJpTqrP;
					}
					return wtgbWlbOADZqZnrvfEzYfBFvpYTyA2;
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

			[IteratorStateMachine(typeof(KTJnnfIfiqVAoQjFLaiFQKQQxTFd))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new KTJnnfIfiqVAoQjFLaiFQKQQxTFd(-2)
				{
					KICQESPwgyUZdmJwERlwohLlFPBAA = this
				};
			}

			[IteratorStateMachine(typeof(wtgbWlbOADZqZnrvfEzYfBFvpYTyA))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new wtgbWlbOADZqZnrvfEzYfBFvpYTyA(-2)
				{
					vHJPbqyGGEGKtFtLovEBNqJpTqrP = this
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

			private sealed class TZbzFFRyeJuInpNqXZqVRiMVIKGN : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int MtkwWnDLoSiuiFiJMLboxkhzlums;

				private Axis VpuCKnSITRqznAAeqHgHvKqXjqAk;

				private int nDrlmvFJNCBZRAsQUFRBiYIzbupZA;

				public Platform_Fallback_Base SnYDMbBDpeIDUrKmvkhQXlxnjtFnA;

				private int sBbVScOiIeyeCneDQYHeklySLoNp;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return VpuCKnSITRqznAAeqHgHvKqXjqAk;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return VpuCKnSITRqznAAeqHgHvKqXjqAk;
					}
				}

				[DebuggerHidden]
				public TZbzFFRyeJuInpNqXZqVRiMVIKGN(int P_0)
				{
					MtkwWnDLoSiuiFiJMLboxkhzlums = P_0;
					nDrlmvFJNCBZRAsQUFRBiYIzbupZA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int mtkwWnDLoSiuiFiJMLboxkhzlums = MtkwWnDLoSiuiFiJMLboxkhzlums;
					Platform_Fallback_Base snYDMbBDpeIDUrKmvkhQXlxnjtFnA = SnYDMbBDpeIDUrKmvkhQXlxnjtFnA;
					switch (mtkwWnDLoSiuiFiJMLboxkhzlums)
					{
					default:
						return false;
					case 0:
						MtkwWnDLoSiuiFiJMLboxkhzlums = -1;
						if (snYDMbBDpeIDUrKmvkhQXlxnjtFnA.elements == null || snYDMbBDpeIDUrKmvkhQXlxnjtFnA.elements.axes == null)
						{
							return false;
						}
						sBbVScOiIeyeCneDQYHeklySLoNp = 0;
						break;
					case 1:
						MtkwWnDLoSiuiFiJMLboxkhzlums = -1;
						sBbVScOiIeyeCneDQYHeklySLoNp++;
						break;
					}
					if (sBbVScOiIeyeCneDQYHeklySLoNp < snYDMbBDpeIDUrKmvkhQXlxnjtFnA.elements.axes.Length)
					{
						VpuCKnSITRqznAAeqHgHvKqXjqAk = snYDMbBDpeIDUrKmvkhQXlxnjtFnA.elements.axes[sBbVScOiIeyeCneDQYHeklySLoNp];
						MtkwWnDLoSiuiFiJMLboxkhzlums = 1;
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
					TZbzFFRyeJuInpNqXZqVRiMVIKGN tZbzFFRyeJuInpNqXZqVRiMVIKGN;
					if (MtkwWnDLoSiuiFiJMLboxkhzlums == -2 && nDrlmvFJNCBZRAsQUFRBiYIzbupZA == Environment.CurrentManagedThreadId)
					{
						MtkwWnDLoSiuiFiJMLboxkhzlums = 0;
						tZbzFFRyeJuInpNqXZqVRiMVIKGN = this;
					}
					else
					{
						tZbzFFRyeJuInpNqXZqVRiMVIKGN = new TZbzFFRyeJuInpNqXZqVRiMVIKGN(0);
						tZbzFFRyeJuInpNqXZqVRiMVIKGN.SnYDMbBDpeIDUrKmvkhQXlxnjtFnA = SnYDMbBDpeIDUrKmvkhQXlxnjtFnA;
					}
					return tZbzFFRyeJuInpNqXZqVRiMVIKGN;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class MqoRyXSIseCxnFBcjIfweJtAwTntA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int VHhGHIuRQUeqYDvXtdXFsxZBuETqA;

				private Button zoKHvTpoillfbmreQbCwIRmHFfkAb;

				private int XbUAKOnrOWXPOpicwsImADPzccZK;

				public Platform_Fallback_Base mfhByJcTXkacHDMvkTwuXXhBOPqhB;

				private int jXbDVKAaXMdfRfONjVQuqMZVrJDtB;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return zoKHvTpoillfbmreQbCwIRmHFfkAb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return zoKHvTpoillfbmreQbCwIRmHFfkAb;
					}
				}

				[DebuggerHidden]
				public MqoRyXSIseCxnFBcjIfweJtAwTntA(int P_0)
				{
					VHhGHIuRQUeqYDvXtdXFsxZBuETqA = P_0;
					XbUAKOnrOWXPOpicwsImADPzccZK = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int vHhGHIuRQUeqYDvXtdXFsxZBuETqA = VHhGHIuRQUeqYDvXtdXFsxZBuETqA;
					Platform_Fallback_Base platform_Fallback_Base = mfhByJcTXkacHDMvkTwuXXhBOPqhB;
					switch (vHhGHIuRQUeqYDvXtdXFsxZBuETqA)
					{
					default:
						return false;
					case 0:
						VHhGHIuRQUeqYDvXtdXFsxZBuETqA = -1;
						if (platform_Fallback_Base.elements == null || platform_Fallback_Base.elements.buttons == null)
						{
							return false;
						}
						jXbDVKAaXMdfRfONjVQuqMZVrJDtB = 0;
						break;
					case 1:
						VHhGHIuRQUeqYDvXtdXFsxZBuETqA = -1;
						jXbDVKAaXMdfRfONjVQuqMZVrJDtB++;
						break;
					}
					if (jXbDVKAaXMdfRfONjVQuqMZVrJDtB < platform_Fallback_Base.elements.buttons.Length)
					{
						zoKHvTpoillfbmreQbCwIRmHFfkAb = platform_Fallback_Base.elements.buttons[jXbDVKAaXMdfRfONjVQuqMZVrJDtB];
						VHhGHIuRQUeqYDvXtdXFsxZBuETqA = 1;
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
					MqoRyXSIseCxnFBcjIfweJtAwTntA mqoRyXSIseCxnFBcjIfweJtAwTntA;
					if (VHhGHIuRQUeqYDvXtdXFsxZBuETqA == -2 && XbUAKOnrOWXPOpicwsImADPzccZK == Environment.CurrentManagedThreadId)
					{
						VHhGHIuRQUeqYDvXtdXFsxZBuETqA = 0;
						mqoRyXSIseCxnFBcjIfweJtAwTntA = this;
					}
					else
					{
						mqoRyXSIseCxnFBcjIfweJtAwTntA = new MqoRyXSIseCxnFBcjIfweJtAwTntA(0);
						mqoRyXSIseCxnFBcjIfweJtAwTntA.mfhByJcTXkacHDMvkTwuXXhBOPqhB = mfhByJcTXkacHDMvkTwuXXhBOPqhB;
					}
					return mqoRyXSIseCxnFBcjIfweJtAwTntA;
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

			[IteratorStateMachine(typeof(TZbzFFRyeJuInpNqXZqVRiMVIKGN))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new TZbzFFRyeJuInpNqXZqVRiMVIKGN(-2)
				{
					SnYDMbBDpeIDUrKmvkhQXlxnjtFnA = this
				};
			}

			[IteratorStateMachine(typeof(MqoRyXSIseCxnFBcjIfweJtAwTntA))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new MqoRyXSIseCxnFBcjIfweJtAwTntA(-2)
				{
					mfhByJcTXkacHDMvkTwuXXhBOPqhB = this
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

			private sealed class KbuCaiOhTOIRnimOLWtEWzHsOoPs : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int xHrNIwhJfDABYvUwnsyrxkvRBNkk;

				private Platform_Custom.Axis uLiWUcsBkmoXoOeTXaZfnhZdJqqC;

				private int yKwdshvZxZLKlAncWgKbbjVNlfNS;

				public Platform_XboxOne_Base FRrSiyLmsCOgUqhTYHfDQzVNCXhL;

				private int vsFkvibPLpdDcfapgDJrIvqGvDyGA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return uLiWUcsBkmoXoOeTXaZfnhZdJqqC;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return uLiWUcsBkmoXoOeTXaZfnhZdJqqC;
					}
				}

				[DebuggerHidden]
				public KbuCaiOhTOIRnimOLWtEWzHsOoPs(int P_0)
				{
					xHrNIwhJfDABYvUwnsyrxkvRBNkk = P_0;
					yKwdshvZxZLKlAncWgKbbjVNlfNS = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = xHrNIwhJfDABYvUwnsyrxkvRBNkk;
					Platform_XboxOne_Base fRrSiyLmsCOgUqhTYHfDQzVNCXhL = FRrSiyLmsCOgUqhTYHfDQzVNCXhL;
					switch (num)
					{
					default:
						return false;
					case 0:
						xHrNIwhJfDABYvUwnsyrxkvRBNkk = -1;
						if (fRrSiyLmsCOgUqhTYHfDQzVNCXhL.elements == null || fRrSiyLmsCOgUqhTYHfDQzVNCXhL.elements.axes == null)
						{
							return false;
						}
						vsFkvibPLpdDcfapgDJrIvqGvDyGA = 0;
						break;
					case 1:
						xHrNIwhJfDABYvUwnsyrxkvRBNkk = -1;
						vsFkvibPLpdDcfapgDJrIvqGvDyGA++;
						break;
					}
					if (vsFkvibPLpdDcfapgDJrIvqGvDyGA < fRrSiyLmsCOgUqhTYHfDQzVNCXhL.elements.axes.Length)
					{
						uLiWUcsBkmoXoOeTXaZfnhZdJqqC = fRrSiyLmsCOgUqhTYHfDQzVNCXhL.elements.axes[vsFkvibPLpdDcfapgDJrIvqGvDyGA];
						xHrNIwhJfDABYvUwnsyrxkvRBNkk = 1;
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
					KbuCaiOhTOIRnimOLWtEWzHsOoPs kbuCaiOhTOIRnimOLWtEWzHsOoPs;
					if (xHrNIwhJfDABYvUwnsyrxkvRBNkk == -2 && yKwdshvZxZLKlAncWgKbbjVNlfNS == Environment.CurrentManagedThreadId)
					{
						xHrNIwhJfDABYvUwnsyrxkvRBNkk = 0;
						kbuCaiOhTOIRnimOLWtEWzHsOoPs = this;
					}
					else
					{
						kbuCaiOhTOIRnimOLWtEWzHsOoPs = new KbuCaiOhTOIRnimOLWtEWzHsOoPs(0);
						kbuCaiOhTOIRnimOLWtEWzHsOoPs.FRrSiyLmsCOgUqhTYHfDQzVNCXhL = FRrSiyLmsCOgUqhTYHfDQzVNCXhL;
					}
					return kbuCaiOhTOIRnimOLWtEWzHsOoPs;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class LxyCAyziprCvjgrGxUWsJbNqDBFF : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int iBJDFxLdJbWltQmFInEKMTuVBpFX;

				private Platform_Custom.Button hRutYlQfLxHkJOMRlYhXOkYcKNpu;

				private int tllVViSvrnDsFzIfHwVpnlqRBsfj;

				public Platform_XboxOne_Base rabsmAaMfmYyHnOaQtIaCwpebCqQ;

				private int YQwyRymgeSzhnzXsvhlQdbEMHNP;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return hRutYlQfLxHkJOMRlYhXOkYcKNpu;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return hRutYlQfLxHkJOMRlYhXOkYcKNpu;
					}
				}

				[DebuggerHidden]
				public LxyCAyziprCvjgrGxUWsJbNqDBFF(int P_0)
				{
					iBJDFxLdJbWltQmFInEKMTuVBpFX = P_0;
					tllVViSvrnDsFzIfHwVpnlqRBsfj = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = iBJDFxLdJbWltQmFInEKMTuVBpFX;
					Platform_XboxOne_Base platform_XboxOne_Base = rabsmAaMfmYyHnOaQtIaCwpebCqQ;
					switch (num)
					{
					default:
						return false;
					case 0:
						iBJDFxLdJbWltQmFInEKMTuVBpFX = -1;
						if (platform_XboxOne_Base.elements == null || platform_XboxOne_Base.elements.buttons == null)
						{
							return false;
						}
						YQwyRymgeSzhnzXsvhlQdbEMHNP = 0;
						break;
					case 1:
						iBJDFxLdJbWltQmFInEKMTuVBpFX = -1;
						YQwyRymgeSzhnzXsvhlQdbEMHNP++;
						break;
					}
					if (YQwyRymgeSzhnzXsvhlQdbEMHNP < platform_XboxOne_Base.elements.buttons.Length)
					{
						hRutYlQfLxHkJOMRlYhXOkYcKNpu = platform_XboxOne_Base.elements.buttons[YQwyRymgeSzhnzXsvhlQdbEMHNP];
						iBJDFxLdJbWltQmFInEKMTuVBpFX = 1;
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
					LxyCAyziprCvjgrGxUWsJbNqDBFF lxyCAyziprCvjgrGxUWsJbNqDBFF;
					if (iBJDFxLdJbWltQmFInEKMTuVBpFX == -2 && tllVViSvrnDsFzIfHwVpnlqRBsfj == Environment.CurrentManagedThreadId)
					{
						iBJDFxLdJbWltQmFInEKMTuVBpFX = 0;
						lxyCAyziprCvjgrGxUWsJbNqDBFF = this;
					}
					else
					{
						lxyCAyziprCvjgrGxUWsJbNqDBFF = new LxyCAyziprCvjgrGxUWsJbNqDBFF(0);
						lxyCAyziprCvjgrGxUWsJbNqDBFF.rabsmAaMfmYyHnOaQtIaCwpebCqQ = rabsmAaMfmYyHnOaQtIaCwpebCqQ;
					}
					return lxyCAyziprCvjgrGxUWsJbNqDBFF;
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

			[IteratorStateMachine(typeof(KbuCaiOhTOIRnimOLWtEWzHsOoPs))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new KbuCaiOhTOIRnimOLWtEWzHsOoPs(-2)
				{
					FRrSiyLmsCOgUqhTYHfDQzVNCXhL = this
				};
			}

			[IteratorStateMachine(typeof(LxyCAyziprCvjgrGxUWsJbNqDBFF))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new LxyCAyziprCvjgrGxUWsJbNqDBFF(-2)
				{
					rabsmAaMfmYyHnOaQtIaCwpebCqQ = this
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

			private sealed class ahiOVNUMfbqYgQDospwAzBQKHBul : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int NBIgAZndxLyMIypjbYwsWjdhrLGq;

				private Platform_Custom.Axis HPyskgCQAZuiCxfiludDWJqHRtcW;

				private int DevpJVXAyeFeIZsenUgQbZQjzohc;

				public Platform_PS4_Base PSLiOKAVMPyOAbcTCNglIpjXjAJj;

				private int dRTMaLWpRUAXbLkqvfcLAYkFAczEb;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return HPyskgCQAZuiCxfiludDWJqHRtcW;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return HPyskgCQAZuiCxfiludDWJqHRtcW;
					}
				}

				[DebuggerHidden]
				public ahiOVNUMfbqYgQDospwAzBQKHBul(int P_0)
				{
					NBIgAZndxLyMIypjbYwsWjdhrLGq = P_0;
					DevpJVXAyeFeIZsenUgQbZQjzohc = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int nBIgAZndxLyMIypjbYwsWjdhrLGq = NBIgAZndxLyMIypjbYwsWjdhrLGq;
					Platform_PS4_Base pSLiOKAVMPyOAbcTCNglIpjXjAJj = PSLiOKAVMPyOAbcTCNglIpjXjAJj;
					switch (nBIgAZndxLyMIypjbYwsWjdhrLGq)
					{
					default:
						return false;
					case 0:
						NBIgAZndxLyMIypjbYwsWjdhrLGq = -1;
						if (pSLiOKAVMPyOAbcTCNglIpjXjAJj.elements == null || pSLiOKAVMPyOAbcTCNglIpjXjAJj.elements.axes == null)
						{
							return false;
						}
						dRTMaLWpRUAXbLkqvfcLAYkFAczEb = 0;
						break;
					case 1:
						NBIgAZndxLyMIypjbYwsWjdhrLGq = -1;
						dRTMaLWpRUAXbLkqvfcLAYkFAczEb++;
						break;
					}
					if (dRTMaLWpRUAXbLkqvfcLAYkFAczEb < pSLiOKAVMPyOAbcTCNglIpjXjAJj.elements.axes.Length)
					{
						HPyskgCQAZuiCxfiludDWJqHRtcW = pSLiOKAVMPyOAbcTCNglIpjXjAJj.elements.axes[dRTMaLWpRUAXbLkqvfcLAYkFAczEb];
						NBIgAZndxLyMIypjbYwsWjdhrLGq = 1;
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
					ahiOVNUMfbqYgQDospwAzBQKHBul ahiOVNUMfbqYgQDospwAzBQKHBul2;
					if (NBIgAZndxLyMIypjbYwsWjdhrLGq == -2 && DevpJVXAyeFeIZsenUgQbZQjzohc == Environment.CurrentManagedThreadId)
					{
						NBIgAZndxLyMIypjbYwsWjdhrLGq = 0;
						ahiOVNUMfbqYgQDospwAzBQKHBul2 = this;
					}
					else
					{
						ahiOVNUMfbqYgQDospwAzBQKHBul2 = new ahiOVNUMfbqYgQDospwAzBQKHBul(0);
						ahiOVNUMfbqYgQDospwAzBQKHBul2.PSLiOKAVMPyOAbcTCNglIpjXjAJj = PSLiOKAVMPyOAbcTCNglIpjXjAJj;
					}
					return ahiOVNUMfbqYgQDospwAzBQKHBul2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class rFgBFJbhEiiKZhOYEVuHtyYRiUCUb : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int HpmlCYQysbLywzNhqAxoGdNkiStAA;

				private Platform_Custom.Button CkFIbhjMPMclTjWODPUuUMfsQyZj;

				private int TVJbzSaaeJzTijqerWctGOoWtgEp;

				public Platform_PS4_Base xgKHFxoUKNEvEueRhELWfSFlkuMyA;

				private int SMNVvlwujqkpYOQwoQjRdPWvBShHA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return CkFIbhjMPMclTjWODPUuUMfsQyZj;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return CkFIbhjMPMclTjWODPUuUMfsQyZj;
					}
				}

				[DebuggerHidden]
				public rFgBFJbhEiiKZhOYEVuHtyYRiUCUb(int P_0)
				{
					HpmlCYQysbLywzNhqAxoGdNkiStAA = P_0;
					TVJbzSaaeJzTijqerWctGOoWtgEp = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int hpmlCYQysbLywzNhqAxoGdNkiStAA = HpmlCYQysbLywzNhqAxoGdNkiStAA;
					Platform_PS4_Base platform_PS4_Base = xgKHFxoUKNEvEueRhELWfSFlkuMyA;
					switch (hpmlCYQysbLywzNhqAxoGdNkiStAA)
					{
					default:
						return false;
					case 0:
						HpmlCYQysbLywzNhqAxoGdNkiStAA = -1;
						if (platform_PS4_Base.elements == null || platform_PS4_Base.elements.buttons == null)
						{
							return false;
						}
						SMNVvlwujqkpYOQwoQjRdPWvBShHA = 0;
						break;
					case 1:
						HpmlCYQysbLywzNhqAxoGdNkiStAA = -1;
						SMNVvlwujqkpYOQwoQjRdPWvBShHA++;
						break;
					}
					if (SMNVvlwujqkpYOQwoQjRdPWvBShHA < platform_PS4_Base.elements.buttons.Length)
					{
						CkFIbhjMPMclTjWODPUuUMfsQyZj = platform_PS4_Base.elements.buttons[SMNVvlwujqkpYOQwoQjRdPWvBShHA];
						HpmlCYQysbLywzNhqAxoGdNkiStAA = 1;
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
					rFgBFJbhEiiKZhOYEVuHtyYRiUCUb rFgBFJbhEiiKZhOYEVuHtyYRiUCUb2;
					if (HpmlCYQysbLywzNhqAxoGdNkiStAA == -2 && TVJbzSaaeJzTijqerWctGOoWtgEp == Environment.CurrentManagedThreadId)
					{
						HpmlCYQysbLywzNhqAxoGdNkiStAA = 0;
						rFgBFJbhEiiKZhOYEVuHtyYRiUCUb2 = this;
					}
					else
					{
						rFgBFJbhEiiKZhOYEVuHtyYRiUCUb2 = new rFgBFJbhEiiKZhOYEVuHtyYRiUCUb(0);
						rFgBFJbhEiiKZhOYEVuHtyYRiUCUb2.xgKHFxoUKNEvEueRhELWfSFlkuMyA = xgKHFxoUKNEvEueRhELWfSFlkuMyA;
					}
					return rFgBFJbhEiiKZhOYEVuHtyYRiUCUb2;
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

			[IteratorStateMachine(typeof(ahiOVNUMfbqYgQDospwAzBQKHBul))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new ahiOVNUMfbqYgQDospwAzBQKHBul(-2)
				{
					PSLiOKAVMPyOAbcTCNglIpjXjAJj = this
				};
			}

			[IteratorStateMachine(typeof(rFgBFJbhEiiKZhOYEVuHtyYRiUCUb))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new rFgBFJbhEiiKZhOYEVuHtyYRiUCUb(-2)
				{
					xgKHFxoUKNEvEueRhELWfSFlkuMyA = this
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

			private sealed class VZmcPcMYSYlaDkOGLNcPUCfFFVbw : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int wpuAbXtkRvFIoQPMDpHIWfYsyhuT;

				private Platform_Custom.Axis yxlkvQKVZFoiHesghVjOIanSXMfl;

				private int HOHOySOwBoYbTgGwFTqqGrpTRJQD;

				public Platform_NintendoSwitch_Base mkRucXpxZXcqHakuTcCsjlzSeHap;

				private int dtRqxrsMrfrgqmSlqrYfpzisRzRs;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return yxlkvQKVZFoiHesghVjOIanSXMfl;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return yxlkvQKVZFoiHesghVjOIanSXMfl;
					}
				}

				[DebuggerHidden]
				public VZmcPcMYSYlaDkOGLNcPUCfFFVbw(int P_0)
				{
					wpuAbXtkRvFIoQPMDpHIWfYsyhuT = P_0;
					HOHOySOwBoYbTgGwFTqqGrpTRJQD = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = wpuAbXtkRvFIoQPMDpHIWfYsyhuT;
					Platform_NintendoSwitch_Base platform_NintendoSwitch_Base = mkRucXpxZXcqHakuTcCsjlzSeHap;
					switch (num)
					{
					default:
						return false;
					case 0:
						wpuAbXtkRvFIoQPMDpHIWfYsyhuT = -1;
						if (platform_NintendoSwitch_Base.elements == null || platform_NintendoSwitch_Base.elements.axes == null)
						{
							return false;
						}
						dtRqxrsMrfrgqmSlqrYfpzisRzRs = 0;
						break;
					case 1:
						wpuAbXtkRvFIoQPMDpHIWfYsyhuT = -1;
						dtRqxrsMrfrgqmSlqrYfpzisRzRs++;
						break;
					}
					if (dtRqxrsMrfrgqmSlqrYfpzisRzRs < platform_NintendoSwitch_Base.elements.axes.Length)
					{
						yxlkvQKVZFoiHesghVjOIanSXMfl = platform_NintendoSwitch_Base.elements.axes[dtRqxrsMrfrgqmSlqrYfpzisRzRs];
						wpuAbXtkRvFIoQPMDpHIWfYsyhuT = 1;
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
					VZmcPcMYSYlaDkOGLNcPUCfFFVbw vZmcPcMYSYlaDkOGLNcPUCfFFVbw;
					if (wpuAbXtkRvFIoQPMDpHIWfYsyhuT == -2 && HOHOySOwBoYbTgGwFTqqGrpTRJQD == Environment.CurrentManagedThreadId)
					{
						wpuAbXtkRvFIoQPMDpHIWfYsyhuT = 0;
						vZmcPcMYSYlaDkOGLNcPUCfFFVbw = this;
					}
					else
					{
						vZmcPcMYSYlaDkOGLNcPUCfFFVbw = new VZmcPcMYSYlaDkOGLNcPUCfFFVbw(0);
						vZmcPcMYSYlaDkOGLNcPUCfFFVbw.mkRucXpxZXcqHakuTcCsjlzSeHap = mkRucXpxZXcqHakuTcCsjlzSeHap;
					}
					return vZmcPcMYSYlaDkOGLNcPUCfFFVbw;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class LVFBkhyJhzdFjQUBhBtOuqUsXlyI : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int rucdmEbhyIQcwYcjbAykOFUqpTVy;

				private Platform_Custom.Button uJRvIIdCMdhwySqVRanFbZTdSJvu;

				private int utRWGgJaaiEzfmVyIGhDskUiWAaF;

				public Platform_NintendoSwitch_Base JskRQHvvkyJXmHIxGrpTFyprglHI;

				private int HHVqgozDefFngdOzOIlmlTRpHAgo;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return uJRvIIdCMdhwySqVRanFbZTdSJvu;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return uJRvIIdCMdhwySqVRanFbZTdSJvu;
					}
				}

				[DebuggerHidden]
				public LVFBkhyJhzdFjQUBhBtOuqUsXlyI(int P_0)
				{
					rucdmEbhyIQcwYcjbAykOFUqpTVy = P_0;
					utRWGgJaaiEzfmVyIGhDskUiWAaF = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = rucdmEbhyIQcwYcjbAykOFUqpTVy;
					Platform_NintendoSwitch_Base jskRQHvvkyJXmHIxGrpTFyprglHI = JskRQHvvkyJXmHIxGrpTFyprglHI;
					switch (num)
					{
					default:
						return false;
					case 0:
						rucdmEbhyIQcwYcjbAykOFUqpTVy = -1;
						if (jskRQHvvkyJXmHIxGrpTFyprglHI.elements == null || jskRQHvvkyJXmHIxGrpTFyprglHI.elements.buttons == null)
						{
							return false;
						}
						HHVqgozDefFngdOzOIlmlTRpHAgo = 0;
						break;
					case 1:
						rucdmEbhyIQcwYcjbAykOFUqpTVy = -1;
						HHVqgozDefFngdOzOIlmlTRpHAgo++;
						break;
					}
					if (HHVqgozDefFngdOzOIlmlTRpHAgo < jskRQHvvkyJXmHIxGrpTFyprglHI.elements.buttons.Length)
					{
						uJRvIIdCMdhwySqVRanFbZTdSJvu = jskRQHvvkyJXmHIxGrpTFyprglHI.elements.buttons[HHVqgozDefFngdOzOIlmlTRpHAgo];
						rucdmEbhyIQcwYcjbAykOFUqpTVy = 1;
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
					LVFBkhyJhzdFjQUBhBtOuqUsXlyI lVFBkhyJhzdFjQUBhBtOuqUsXlyI;
					if (rucdmEbhyIQcwYcjbAykOFUqpTVy == -2 && utRWGgJaaiEzfmVyIGhDskUiWAaF == Environment.CurrentManagedThreadId)
					{
						rucdmEbhyIQcwYcjbAykOFUqpTVy = 0;
						lVFBkhyJhzdFjQUBhBtOuqUsXlyI = this;
					}
					else
					{
						lVFBkhyJhzdFjQUBhBtOuqUsXlyI = new LVFBkhyJhzdFjQUBhBtOuqUsXlyI(0);
						lVFBkhyJhzdFjQUBhBtOuqUsXlyI.JskRQHvvkyJXmHIxGrpTFyprglHI = JskRQHvvkyJXmHIxGrpTFyprglHI;
					}
					return lVFBkhyJhzdFjQUBhBtOuqUsXlyI;
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

			[IteratorStateMachine(typeof(VZmcPcMYSYlaDkOGLNcPUCfFFVbw))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new VZmcPcMYSYlaDkOGLNcPUCfFFVbw(-2)
				{
					mkRucXpxZXcqHakuTcCsjlzSeHap = this
				};
			}

			[IteratorStateMachine(typeof(LVFBkhyJhzdFjQUBhBtOuqUsXlyI))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new LVFBkhyJhzdFjQUBhBtOuqUsXlyI(-2)
				{
					JskRQHvvkyJXmHIxGrpTFyprglHI = this
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

			private sealed class kTZHPYVDNUsTWejkYBOCkFASKkAiA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int KUaIUqxOaBjoWFVwBleLhqmDrLpaA;

				private Platform_Custom.Axis OiCsbPgzpJCufPegITXekrOAdgpd;

				private int tVCmwsckxPcEvuEsJXCJaFDdHmrH;

				public Platform_Stadia_Base rYBGxPIqhOCFwRywDKersUqxrOcX;

				private int pTXJiNVviWfidfPLcGxDRJoQBQHJA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return OiCsbPgzpJCufPegITXekrOAdgpd;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return OiCsbPgzpJCufPegITXekrOAdgpd;
					}
				}

				[DebuggerHidden]
				public kTZHPYVDNUsTWejkYBOCkFASKkAiA(int P_0)
				{
					KUaIUqxOaBjoWFVwBleLhqmDrLpaA = P_0;
					tVCmwsckxPcEvuEsJXCJaFDdHmrH = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int kUaIUqxOaBjoWFVwBleLhqmDrLpaA = KUaIUqxOaBjoWFVwBleLhqmDrLpaA;
					Platform_Stadia_Base platform_Stadia_Base = rYBGxPIqhOCFwRywDKersUqxrOcX;
					switch (kUaIUqxOaBjoWFVwBleLhqmDrLpaA)
					{
					default:
						return false;
					case 0:
						KUaIUqxOaBjoWFVwBleLhqmDrLpaA = -1;
						if (platform_Stadia_Base.elements == null || platform_Stadia_Base.elements.axes == null)
						{
							return false;
						}
						pTXJiNVviWfidfPLcGxDRJoQBQHJA = 0;
						break;
					case 1:
						KUaIUqxOaBjoWFVwBleLhqmDrLpaA = -1;
						pTXJiNVviWfidfPLcGxDRJoQBQHJA++;
						break;
					}
					if (pTXJiNVviWfidfPLcGxDRJoQBQHJA < platform_Stadia_Base.elements.axes.Length)
					{
						OiCsbPgzpJCufPegITXekrOAdgpd = platform_Stadia_Base.elements.axes[pTXJiNVviWfidfPLcGxDRJoQBQHJA];
						KUaIUqxOaBjoWFVwBleLhqmDrLpaA = 1;
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
					kTZHPYVDNUsTWejkYBOCkFASKkAiA kTZHPYVDNUsTWejkYBOCkFASKkAiA2;
					if (KUaIUqxOaBjoWFVwBleLhqmDrLpaA == -2 && tVCmwsckxPcEvuEsJXCJaFDdHmrH == Environment.CurrentManagedThreadId)
					{
						KUaIUqxOaBjoWFVwBleLhqmDrLpaA = 0;
						kTZHPYVDNUsTWejkYBOCkFASKkAiA2 = this;
					}
					else
					{
						kTZHPYVDNUsTWejkYBOCkFASKkAiA2 = new kTZHPYVDNUsTWejkYBOCkFASKkAiA(0);
						kTZHPYVDNUsTWejkYBOCkFASKkAiA2.rYBGxPIqhOCFwRywDKersUqxrOcX = rYBGxPIqhOCFwRywDKersUqxrOcX;
					}
					return kTZHPYVDNUsTWejkYBOCkFASKkAiA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class KwfdlzLOHrIJrhODmfSSErmhLVflB : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int CDNZbAKhCbrqtYCpiIdNhHhAulymA;

				private Platform_Custom.Button WCogYvrEejhNktnFbjHweuXeoMTUA;

				private int CvHWkcxEaHAyFYZhmFxDPglDUlKl;

				public Platform_Stadia_Base xRzQobqqUJrYUsVsptzTtwIYLWni;

				private int pWkxTVjqYVJVMuIrXhTEJrZUGeHV;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return WCogYvrEejhNktnFbjHweuXeoMTUA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return WCogYvrEejhNktnFbjHweuXeoMTUA;
					}
				}

				[DebuggerHidden]
				public KwfdlzLOHrIJrhODmfSSErmhLVflB(int P_0)
				{
					CDNZbAKhCbrqtYCpiIdNhHhAulymA = P_0;
					CvHWkcxEaHAyFYZhmFxDPglDUlKl = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int cDNZbAKhCbrqtYCpiIdNhHhAulymA = CDNZbAKhCbrqtYCpiIdNhHhAulymA;
					Platform_Stadia_Base platform_Stadia_Base = xRzQobqqUJrYUsVsptzTtwIYLWni;
					switch (cDNZbAKhCbrqtYCpiIdNhHhAulymA)
					{
					default:
						return false;
					case 0:
						CDNZbAKhCbrqtYCpiIdNhHhAulymA = -1;
						if (platform_Stadia_Base.elements == null || platform_Stadia_Base.elements.buttons == null)
						{
							return false;
						}
						pWkxTVjqYVJVMuIrXhTEJrZUGeHV = 0;
						break;
					case 1:
						CDNZbAKhCbrqtYCpiIdNhHhAulymA = -1;
						pWkxTVjqYVJVMuIrXhTEJrZUGeHV++;
						break;
					}
					if (pWkxTVjqYVJVMuIrXhTEJrZUGeHV < platform_Stadia_Base.elements.buttons.Length)
					{
						WCogYvrEejhNktnFbjHweuXeoMTUA = platform_Stadia_Base.elements.buttons[pWkxTVjqYVJVMuIrXhTEJrZUGeHV];
						CDNZbAKhCbrqtYCpiIdNhHhAulymA = 1;
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
					KwfdlzLOHrIJrhODmfSSErmhLVflB kwfdlzLOHrIJrhODmfSSErmhLVflB;
					if (CDNZbAKhCbrqtYCpiIdNhHhAulymA == -2 && CvHWkcxEaHAyFYZhmFxDPglDUlKl == Environment.CurrentManagedThreadId)
					{
						CDNZbAKhCbrqtYCpiIdNhHhAulymA = 0;
						kwfdlzLOHrIJrhODmfSSErmhLVflB = this;
					}
					else
					{
						kwfdlzLOHrIJrhODmfSSErmhLVflB = new KwfdlzLOHrIJrhODmfSSErmhLVflB(0);
						kwfdlzLOHrIJrhODmfSSErmhLVflB.xRzQobqqUJrYUsVsptzTtwIYLWni = xRzQobqqUJrYUsVsptzTtwIYLWni;
					}
					return kwfdlzLOHrIJrhODmfSSErmhLVflB;
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

			[IteratorStateMachine(typeof(kTZHPYVDNUsTWejkYBOCkFASKkAiA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new kTZHPYVDNUsTWejkYBOCkFASKkAiA(-2)
				{
					rYBGxPIqhOCFwRywDKersUqxrOcX = this
				};
			}

			[IteratorStateMachine(typeof(KwfdlzLOHrIJrhODmfSSErmhLVflB))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new KwfdlzLOHrIJrhODmfSSErmhLVflB(-2)
				{
					xRzQobqqUJrYUsVsptzTtwIYLWni = this
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

			private sealed class fuvcgoyudRDcGDsHPgikhcXdNBrvb : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int blDNlhaNlJBLiIVZGlTVBLMhfFPsA;

				private Platform_Custom.Axis fSxZOtOSBZEczetilRVsHNcaIbMEA;

				private int BlFgcSKLLodlPnPigpXlgCuemKyPA;

				public Platform_GameCore_Base ZGEeKpFRemZuCOZsooJApNPwEjqe;

				private int BvvbEjKKcPOMgGRQCVlMGbsizBcRD;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return fSxZOtOSBZEczetilRVsHNcaIbMEA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return fSxZOtOSBZEczetilRVsHNcaIbMEA;
					}
				}

				[DebuggerHidden]
				public fuvcgoyudRDcGDsHPgikhcXdNBrvb(int P_0)
				{
					blDNlhaNlJBLiIVZGlTVBLMhfFPsA = P_0;
					BlFgcSKLLodlPnPigpXlgCuemKyPA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = blDNlhaNlJBLiIVZGlTVBLMhfFPsA;
					Platform_GameCore_Base zGEeKpFRemZuCOZsooJApNPwEjqe = ZGEeKpFRemZuCOZsooJApNPwEjqe;
					switch (num)
					{
					default:
						return false;
					case 0:
						blDNlhaNlJBLiIVZGlTVBLMhfFPsA = -1;
						if (zGEeKpFRemZuCOZsooJApNPwEjqe.elements == null || zGEeKpFRemZuCOZsooJApNPwEjqe.elements.axes == null)
						{
							return false;
						}
						BvvbEjKKcPOMgGRQCVlMGbsizBcRD = 0;
						break;
					case 1:
						blDNlhaNlJBLiIVZGlTVBLMhfFPsA = -1;
						BvvbEjKKcPOMgGRQCVlMGbsizBcRD++;
						break;
					}
					if (BvvbEjKKcPOMgGRQCVlMGbsizBcRD < zGEeKpFRemZuCOZsooJApNPwEjqe.elements.axes.Length)
					{
						fSxZOtOSBZEczetilRVsHNcaIbMEA = zGEeKpFRemZuCOZsooJApNPwEjqe.elements.axes[BvvbEjKKcPOMgGRQCVlMGbsizBcRD];
						blDNlhaNlJBLiIVZGlTVBLMhfFPsA = 1;
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
					fuvcgoyudRDcGDsHPgikhcXdNBrvb fuvcgoyudRDcGDsHPgikhcXdNBrvb2;
					if (blDNlhaNlJBLiIVZGlTVBLMhfFPsA == -2 && BlFgcSKLLodlPnPigpXlgCuemKyPA == Environment.CurrentManagedThreadId)
					{
						blDNlhaNlJBLiIVZGlTVBLMhfFPsA = 0;
						fuvcgoyudRDcGDsHPgikhcXdNBrvb2 = this;
					}
					else
					{
						fuvcgoyudRDcGDsHPgikhcXdNBrvb2 = new fuvcgoyudRDcGDsHPgikhcXdNBrvb(0);
						fuvcgoyudRDcGDsHPgikhcXdNBrvb2.ZGEeKpFRemZuCOZsooJApNPwEjqe = ZGEeKpFRemZuCOZsooJApNPwEjqe;
					}
					return fuvcgoyudRDcGDsHPgikhcXdNBrvb2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class NzRboKdikhJuJABviwujyEFAVosKA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int vlKFbhKBwzizKejHmulXadcdKALoB;

				private Platform_Custom.Button pOTKVydqsNOkSvitqFoBtyTYESFN;

				private int LVdPXULDfgwFUxWbwbovBgFtdaIS;

				public Platform_GameCore_Base HRqIfkIZCynfhkjSrMrezQiEHLYk;

				private int tcRUcXxpYgJaeyQfCbDImlneRMJA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return pOTKVydqsNOkSvitqFoBtyTYESFN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return pOTKVydqsNOkSvitqFoBtyTYESFN;
					}
				}

				[DebuggerHidden]
				public NzRboKdikhJuJABviwujyEFAVosKA(int P_0)
				{
					vlKFbhKBwzizKejHmulXadcdKALoB = P_0;
					LVdPXULDfgwFUxWbwbovBgFtdaIS = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = vlKFbhKBwzizKejHmulXadcdKALoB;
					Platform_GameCore_Base hRqIfkIZCynfhkjSrMrezQiEHLYk = HRqIfkIZCynfhkjSrMrezQiEHLYk;
					switch (num)
					{
					default:
						return false;
					case 0:
						vlKFbhKBwzizKejHmulXadcdKALoB = -1;
						if (hRqIfkIZCynfhkjSrMrezQiEHLYk.elements == null || hRqIfkIZCynfhkjSrMrezQiEHLYk.elements.buttons == null)
						{
							return false;
						}
						tcRUcXxpYgJaeyQfCbDImlneRMJA = 0;
						break;
					case 1:
						vlKFbhKBwzizKejHmulXadcdKALoB = -1;
						tcRUcXxpYgJaeyQfCbDImlneRMJA++;
						break;
					}
					if (tcRUcXxpYgJaeyQfCbDImlneRMJA < hRqIfkIZCynfhkjSrMrezQiEHLYk.elements.buttons.Length)
					{
						pOTKVydqsNOkSvitqFoBtyTYESFN = hRqIfkIZCynfhkjSrMrezQiEHLYk.elements.buttons[tcRUcXxpYgJaeyQfCbDImlneRMJA];
						vlKFbhKBwzizKejHmulXadcdKALoB = 1;
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
					NzRboKdikhJuJABviwujyEFAVosKA nzRboKdikhJuJABviwujyEFAVosKA;
					if (vlKFbhKBwzizKejHmulXadcdKALoB == -2 && LVdPXULDfgwFUxWbwbovBgFtdaIS == Environment.CurrentManagedThreadId)
					{
						vlKFbhKBwzizKejHmulXadcdKALoB = 0;
						nzRboKdikhJuJABviwujyEFAVosKA = this;
					}
					else
					{
						nzRboKdikhJuJABviwujyEFAVosKA = new NzRboKdikhJuJABviwujyEFAVosKA(0);
						nzRboKdikhJuJABviwujyEFAVosKA.HRqIfkIZCynfhkjSrMrezQiEHLYk = HRqIfkIZCynfhkjSrMrezQiEHLYk;
					}
					return nzRboKdikhJuJABviwujyEFAVosKA;
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

			[IteratorStateMachine(typeof(fuvcgoyudRDcGDsHPgikhcXdNBrvb))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new fuvcgoyudRDcGDsHPgikhcXdNBrvb(-2)
				{
					ZGEeKpFRemZuCOZsooJApNPwEjqe = this
				};
			}

			[IteratorStateMachine(typeof(NzRboKdikhJuJABviwujyEFAVosKA))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new NzRboKdikhJuJABviwujyEFAVosKA(-2)
				{
					HRqIfkIZCynfhkjSrMrezQiEHLYk = this
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

			private sealed class AFbhwTgfRtqOFtmvQIYvcCAarVKNA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int PcKLaxyalXVuxwnlrCqZOtvHqitN;

				private Platform_Custom.Axis oqEyaIyiSjFFZDpZMuQahtpFRmvdA;

				private int bHBawPUnPJkrhiJZYvVXXPrNAPEy;

				public Platform_PS5_Base SEQcKSSpjrfSmKeZdhdlEYsrSXzdA;

				private int qBmfmWKWMrHBtWQCjmWGTdmDedSj;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return oqEyaIyiSjFFZDpZMuQahtpFRmvdA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return oqEyaIyiSjFFZDpZMuQahtpFRmvdA;
					}
				}

				[DebuggerHidden]
				public AFbhwTgfRtqOFtmvQIYvcCAarVKNA(int P_0)
				{
					PcKLaxyalXVuxwnlrCqZOtvHqitN = P_0;
					bHBawPUnPJkrhiJZYvVXXPrNAPEy = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int pcKLaxyalXVuxwnlrCqZOtvHqitN = PcKLaxyalXVuxwnlrCqZOtvHqitN;
					Platform_PS5_Base sEQcKSSpjrfSmKeZdhdlEYsrSXzdA = SEQcKSSpjrfSmKeZdhdlEYsrSXzdA;
					switch (pcKLaxyalXVuxwnlrCqZOtvHqitN)
					{
					default:
						return false;
					case 0:
						PcKLaxyalXVuxwnlrCqZOtvHqitN = -1;
						if (sEQcKSSpjrfSmKeZdhdlEYsrSXzdA.elements == null || sEQcKSSpjrfSmKeZdhdlEYsrSXzdA.elements.axes == null)
						{
							return false;
						}
						qBmfmWKWMrHBtWQCjmWGTdmDedSj = 0;
						break;
					case 1:
						PcKLaxyalXVuxwnlrCqZOtvHqitN = -1;
						qBmfmWKWMrHBtWQCjmWGTdmDedSj++;
						break;
					}
					if (qBmfmWKWMrHBtWQCjmWGTdmDedSj < sEQcKSSpjrfSmKeZdhdlEYsrSXzdA.elements.axes.Length)
					{
						oqEyaIyiSjFFZDpZMuQahtpFRmvdA = sEQcKSSpjrfSmKeZdhdlEYsrSXzdA.elements.axes[qBmfmWKWMrHBtWQCjmWGTdmDedSj];
						PcKLaxyalXVuxwnlrCqZOtvHqitN = 1;
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
					AFbhwTgfRtqOFtmvQIYvcCAarVKNA aFbhwTgfRtqOFtmvQIYvcCAarVKNA;
					if (PcKLaxyalXVuxwnlrCqZOtvHqitN == -2 && bHBawPUnPJkrhiJZYvVXXPrNAPEy == Environment.CurrentManagedThreadId)
					{
						PcKLaxyalXVuxwnlrCqZOtvHqitN = 0;
						aFbhwTgfRtqOFtmvQIYvcCAarVKNA = this;
					}
					else
					{
						aFbhwTgfRtqOFtmvQIYvcCAarVKNA = new AFbhwTgfRtqOFtmvQIYvcCAarVKNA(0);
						aFbhwTgfRtqOFtmvQIYvcCAarVKNA.SEQcKSSpjrfSmKeZdhdlEYsrSXzdA = SEQcKSSpjrfSmKeZdhdlEYsrSXzdA;
					}
					return aFbhwTgfRtqOFtmvQIYvcCAarVKNA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class BjQclCmjswKywaUVJSrmjlRnJIQu : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int QbRyTnlIhJVaOAiMvIRdGmphUuXp;

				private Platform_Custom.Button aWQxDjaaDbEPHcztlugXaDRtNHqM;

				private int iYNCHbdIeEAdXDkDcNJMDNtMLYPpB;

				public Platform_PS5_Base SKHycfwhFXquPHXQOLnaFzkszXoc;

				private int aArdprtmJtBmdlNjwgRZkJdvYvRD;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return aWQxDjaaDbEPHcztlugXaDRtNHqM;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return aWQxDjaaDbEPHcztlugXaDRtNHqM;
					}
				}

				[DebuggerHidden]
				public BjQclCmjswKywaUVJSrmjlRnJIQu(int P_0)
				{
					QbRyTnlIhJVaOAiMvIRdGmphUuXp = P_0;
					iYNCHbdIeEAdXDkDcNJMDNtMLYPpB = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int qbRyTnlIhJVaOAiMvIRdGmphUuXp = QbRyTnlIhJVaOAiMvIRdGmphUuXp;
					Platform_PS5_Base sKHycfwhFXquPHXQOLnaFzkszXoc = SKHycfwhFXquPHXQOLnaFzkszXoc;
					switch (qbRyTnlIhJVaOAiMvIRdGmphUuXp)
					{
					default:
						return false;
					case 0:
						QbRyTnlIhJVaOAiMvIRdGmphUuXp = -1;
						if (sKHycfwhFXquPHXQOLnaFzkszXoc.elements == null || sKHycfwhFXquPHXQOLnaFzkszXoc.elements.buttons == null)
						{
							return false;
						}
						aArdprtmJtBmdlNjwgRZkJdvYvRD = 0;
						break;
					case 1:
						QbRyTnlIhJVaOAiMvIRdGmphUuXp = -1;
						aArdprtmJtBmdlNjwgRZkJdvYvRD++;
						break;
					}
					if (aArdprtmJtBmdlNjwgRZkJdvYvRD < sKHycfwhFXquPHXQOLnaFzkszXoc.elements.buttons.Length)
					{
						aWQxDjaaDbEPHcztlugXaDRtNHqM = sKHycfwhFXquPHXQOLnaFzkszXoc.elements.buttons[aArdprtmJtBmdlNjwgRZkJdvYvRD];
						QbRyTnlIhJVaOAiMvIRdGmphUuXp = 1;
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
					BjQclCmjswKywaUVJSrmjlRnJIQu bjQclCmjswKywaUVJSrmjlRnJIQu;
					if (QbRyTnlIhJVaOAiMvIRdGmphUuXp == -2 && iYNCHbdIeEAdXDkDcNJMDNtMLYPpB == Environment.CurrentManagedThreadId)
					{
						QbRyTnlIhJVaOAiMvIRdGmphUuXp = 0;
						bjQclCmjswKywaUVJSrmjlRnJIQu = this;
					}
					else
					{
						bjQclCmjswKywaUVJSrmjlRnJIQu = new BjQclCmjswKywaUVJSrmjlRnJIQu(0);
						bjQclCmjswKywaUVJSrmjlRnJIQu.SKHycfwhFXquPHXQOLnaFzkszXoc = SKHycfwhFXquPHXQOLnaFzkszXoc;
					}
					return bjQclCmjswKywaUVJSrmjlRnJIQu;
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

			[IteratorStateMachine(typeof(AFbhwTgfRtqOFtmvQIYvcCAarVKNA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new AFbhwTgfRtqOFtmvQIYvcCAarVKNA(-2)
				{
					SEQcKSSpjrfSmKeZdhdlEYsrSXzdA = this
				};
			}

			[IteratorStateMachine(typeof(BjQclCmjswKywaUVJSrmjlRnJIQu))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new BjQclCmjswKywaUVJSrmjlRnJIQu(-2)
				{
					SKHycfwhFXquPHXQOLnaFzkszXoc = this
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

			private sealed class vndeTgVSeqpyjCmipfhvhYhyMkae : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int TSabjJODJBhsaBTFRfbUomDSaDsV;

				private Platform_Custom.Axis bHFmSMViqkwgSgIjhICpLbiTRLft;

				private int BahSnctuYYIyQlWmuJQWKXNZHBVv;

				public Platform_InternalDriver_Base FgITSDxWSdrfAUYrktNbwJadAMki;

				private int TVznOJGvRvczLMmvLoLTQcmveufI;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return bHFmSMViqkwgSgIjhICpLbiTRLft;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return bHFmSMViqkwgSgIjhICpLbiTRLft;
					}
				}

				[DebuggerHidden]
				public vndeTgVSeqpyjCmipfhvhYhyMkae(int P_0)
				{
					TSabjJODJBhsaBTFRfbUomDSaDsV = P_0;
					BahSnctuYYIyQlWmuJQWKXNZHBVv = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int tSabjJODJBhsaBTFRfbUomDSaDsV = TSabjJODJBhsaBTFRfbUomDSaDsV;
					Platform_InternalDriver_Base fgITSDxWSdrfAUYrktNbwJadAMki = FgITSDxWSdrfAUYrktNbwJadAMki;
					switch (tSabjJODJBhsaBTFRfbUomDSaDsV)
					{
					default:
						return false;
					case 0:
						TSabjJODJBhsaBTFRfbUomDSaDsV = -1;
						if (fgITSDxWSdrfAUYrktNbwJadAMki.elements == null || fgITSDxWSdrfAUYrktNbwJadAMki.elements.axes == null)
						{
							return false;
						}
						TVznOJGvRvczLMmvLoLTQcmveufI = 0;
						break;
					case 1:
						TSabjJODJBhsaBTFRfbUomDSaDsV = -1;
						TVznOJGvRvczLMmvLoLTQcmveufI++;
						break;
					}
					if (TVznOJGvRvczLMmvLoLTQcmveufI < fgITSDxWSdrfAUYrktNbwJadAMki.elements.axes.Length)
					{
						bHFmSMViqkwgSgIjhICpLbiTRLft = fgITSDxWSdrfAUYrktNbwJadAMki.elements.axes[TVznOJGvRvczLMmvLoLTQcmveufI];
						TSabjJODJBhsaBTFRfbUomDSaDsV = 1;
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
					vndeTgVSeqpyjCmipfhvhYhyMkae vndeTgVSeqpyjCmipfhvhYhyMkae2;
					if (TSabjJODJBhsaBTFRfbUomDSaDsV == -2 && BahSnctuYYIyQlWmuJQWKXNZHBVv == Environment.CurrentManagedThreadId)
					{
						TSabjJODJBhsaBTFRfbUomDSaDsV = 0;
						vndeTgVSeqpyjCmipfhvhYhyMkae2 = this;
					}
					else
					{
						vndeTgVSeqpyjCmipfhvhYhyMkae2 = new vndeTgVSeqpyjCmipfhvhYhyMkae(0);
						vndeTgVSeqpyjCmipfhvhYhyMkae2.FgITSDxWSdrfAUYrktNbwJadAMki = FgITSDxWSdrfAUYrktNbwJadAMki;
					}
					return vndeTgVSeqpyjCmipfhvhYhyMkae2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class QwIuNXXvWcantahBsjJUIKUGoUNdb : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int HVurpVUSZgptYaDeuOTmwkzrXyfR;

				private Platform_Custom.Button qqLCMRKWgOYyAbDTWHTczWrJwcKsA;

				private int lfZbtcooJXpvKecQgMtcTSFBKalX;

				public Platform_InternalDriver_Base vlZddVlRMRYQLYvXJgDHJGUIbiXEA;

				private int RsiQCQgGlriPQVinFqSTvUAEBpQG;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return qqLCMRKWgOYyAbDTWHTczWrJwcKsA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return qqLCMRKWgOYyAbDTWHTczWrJwcKsA;
					}
				}

				[DebuggerHidden]
				public QwIuNXXvWcantahBsjJUIKUGoUNdb(int P_0)
				{
					HVurpVUSZgptYaDeuOTmwkzrXyfR = P_0;
					lfZbtcooJXpvKecQgMtcTSFBKalX = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int hVurpVUSZgptYaDeuOTmwkzrXyfR = HVurpVUSZgptYaDeuOTmwkzrXyfR;
					Platform_InternalDriver_Base platform_InternalDriver_Base = vlZddVlRMRYQLYvXJgDHJGUIbiXEA;
					switch (hVurpVUSZgptYaDeuOTmwkzrXyfR)
					{
					default:
						return false;
					case 0:
						HVurpVUSZgptYaDeuOTmwkzrXyfR = -1;
						if (platform_InternalDriver_Base.elements == null || platform_InternalDriver_Base.elements.buttons == null)
						{
							return false;
						}
						RsiQCQgGlriPQVinFqSTvUAEBpQG = 0;
						break;
					case 1:
						HVurpVUSZgptYaDeuOTmwkzrXyfR = -1;
						RsiQCQgGlriPQVinFqSTvUAEBpQG++;
						break;
					}
					if (RsiQCQgGlriPQVinFqSTvUAEBpQG < platform_InternalDriver_Base.elements.buttons.Length)
					{
						qqLCMRKWgOYyAbDTWHTczWrJwcKsA = platform_InternalDriver_Base.elements.buttons[RsiQCQgGlriPQVinFqSTvUAEBpQG];
						HVurpVUSZgptYaDeuOTmwkzrXyfR = 1;
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
					QwIuNXXvWcantahBsjJUIKUGoUNdb qwIuNXXvWcantahBsjJUIKUGoUNdb;
					if (HVurpVUSZgptYaDeuOTmwkzrXyfR == -2 && lfZbtcooJXpvKecQgMtcTSFBKalX == Environment.CurrentManagedThreadId)
					{
						HVurpVUSZgptYaDeuOTmwkzrXyfR = 0;
						qwIuNXXvWcantahBsjJUIKUGoUNdb = this;
					}
					else
					{
						qwIuNXXvWcantahBsjJUIKUGoUNdb = new QwIuNXXvWcantahBsjJUIKUGoUNdb(0);
						qwIuNXXvWcantahBsjJUIKUGoUNdb.vlZddVlRMRYQLYvXJgDHJGUIbiXEA = vlZddVlRMRYQLYvXJgDHJGUIbiXEA;
					}
					return qwIuNXXvWcantahBsjJUIKUGoUNdb;
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

			[IteratorStateMachine(typeof(vndeTgVSeqpyjCmipfhvhYhyMkae))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new vndeTgVSeqpyjCmipfhvhYhyMkae(-2)
				{
					FgITSDxWSdrfAUYrktNbwJadAMki = this
				};
			}

			[IteratorStateMachine(typeof(QwIuNXXvWcantahBsjJUIKUGoUNdb))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new QwIuNXXvWcantahBsjJUIKUGoUNdb(-2)
				{
					vlZddVlRMRYQLYvXJgDHJGUIbiXEA = this
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
						ezQploKyylrjKlUlVimuGHFeFvmcA(elementCount);
						return elementCount;
					}

					internal void XwDHxNtQSnDzQLSvCzPOXZzldcll(ElementCount_Base P_0)
					{
						base.ezQploKyylrjKlUlVimuGHFeFvmcA(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool AseFVlbUgnrnMJWlaiiWeWjyILFn(BridgedControllerHWInfo P_0)
					{
						if (!base.NNJGgfaSIfVWplUEnquSSIiWlKERA(P_0))
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
				private sealed class CVYBFsDXNcenzSsiBhhIoZsJHODY : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int ssPNjZgNIcUOczBfdxEAOwmVrPNc;

					private Axis NpdlmWNLITeOPBHYuquZGQTRUkpMA;

					private int WDhgHLszbfMngYzYdpQWZtSGfdrn;

					public Elements yEbvJzMQmOUXEaHyrJTeMLotMDVG;

					private int HYCBPonbbVwtrIKGlfgeGfjcceTv;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return NpdlmWNLITeOPBHYuquZGQTRUkpMA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return NpdlmWNLITeOPBHYuquZGQTRUkpMA;
						}
					}

					[DebuggerHidden]
					public CVYBFsDXNcenzSsiBhhIoZsJHODY(int P_0)
					{
						ssPNjZgNIcUOczBfdxEAOwmVrPNc = P_0;
						WDhgHLszbfMngYzYdpQWZtSGfdrn = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = ssPNjZgNIcUOczBfdxEAOwmVrPNc;
						Elements elements = yEbvJzMQmOUXEaHyrJTeMLotMDVG;
						switch (num)
						{
						default:
							return false;
						case 0:
							ssPNjZgNIcUOczBfdxEAOwmVrPNc = -1;
							if (elements.axes == null)
							{
								return false;
							}
							HYCBPonbbVwtrIKGlfgeGfjcceTv = 0;
							break;
						case 1:
							ssPNjZgNIcUOczBfdxEAOwmVrPNc = -1;
							HYCBPonbbVwtrIKGlfgeGfjcceTv++;
							break;
						}
						if (HYCBPonbbVwtrIKGlfgeGfjcceTv < elements.axes.Length)
						{
							NpdlmWNLITeOPBHYuquZGQTRUkpMA = elements.axes[HYCBPonbbVwtrIKGlfgeGfjcceTv];
							ssPNjZgNIcUOczBfdxEAOwmVrPNc = 1;
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
						CVYBFsDXNcenzSsiBhhIoZsJHODY cVYBFsDXNcenzSsiBhhIoZsJHODY;
						if (ssPNjZgNIcUOczBfdxEAOwmVrPNc == -2 && WDhgHLszbfMngYzYdpQWZtSGfdrn == Environment.CurrentManagedThreadId)
						{
							ssPNjZgNIcUOczBfdxEAOwmVrPNc = 0;
							cVYBFsDXNcenzSsiBhhIoZsJHODY = this;
						}
						else
						{
							cVYBFsDXNcenzSsiBhhIoZsJHODY = new CVYBFsDXNcenzSsiBhhIoZsJHODY(0);
							cVYBFsDXNcenzSsiBhhIoZsJHODY.yEbvJzMQmOUXEaHyrJTeMLotMDVG = yEbvJzMQmOUXEaHyrJTeMLotMDVG;
						}
						return cVYBFsDXNcenzSsiBhhIoZsJHODY;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class MPCHISyEEHpOlhpBlPbyrkQElhUG : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int ebTMfLQQLiINkrkLEzNfnuqBuYrr;

					private Button phZKlJYQNOqBtRmDRJpNDspFUrql;

					private int dwbTprodhVwZJMUXhhiQCsrlcMQi;

					public Elements BfEvOxJJHdrUWpUcMUbcWlBKFief;

					private int wKZaIGmdmLXDScrLWvdxIymnJoKe;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return phZKlJYQNOqBtRmDRJpNDspFUrql;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return phZKlJYQNOqBtRmDRJpNDspFUrql;
						}
					}

					[DebuggerHidden]
					public MPCHISyEEHpOlhpBlPbyrkQElhUG(int P_0)
					{
						ebTMfLQQLiINkrkLEzNfnuqBuYrr = P_0;
						dwbTprodhVwZJMUXhhiQCsrlcMQi = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = ebTMfLQQLiINkrkLEzNfnuqBuYrr;
						Elements bfEvOxJJHdrUWpUcMUbcWlBKFief = BfEvOxJJHdrUWpUcMUbcWlBKFief;
						switch (num)
						{
						default:
							return false;
						case 0:
							ebTMfLQQLiINkrkLEzNfnuqBuYrr = -1;
							if (bfEvOxJJHdrUWpUcMUbcWlBKFief.buttons == null)
							{
								return false;
							}
							wKZaIGmdmLXDScrLWvdxIymnJoKe = 0;
							break;
						case 1:
							ebTMfLQQLiINkrkLEzNfnuqBuYrr = -1;
							wKZaIGmdmLXDScrLWvdxIymnJoKe++;
							break;
						}
						if (wKZaIGmdmLXDScrLWvdxIymnJoKe < bfEvOxJJHdrUWpUcMUbcWlBKFief.buttons.Length)
						{
							phZKlJYQNOqBtRmDRJpNDspFUrql = bfEvOxJJHdrUWpUcMUbcWlBKFief.buttons[wKZaIGmdmLXDScrLWvdxIymnJoKe];
							ebTMfLQQLiINkrkLEzNfnuqBuYrr = 1;
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
						MPCHISyEEHpOlhpBlPbyrkQElhUG mPCHISyEEHpOlhpBlPbyrkQElhUG;
						if (ebTMfLQQLiINkrkLEzNfnuqBuYrr == -2 && dwbTprodhVwZJMUXhhiQCsrlcMQi == Environment.CurrentManagedThreadId)
						{
							ebTMfLQQLiINkrkLEzNfnuqBuYrr = 0;
							mPCHISyEEHpOlhpBlPbyrkQElhUG = this;
						}
						else
						{
							mPCHISyEEHpOlhpBlPbyrkQElhUG = new MPCHISyEEHpOlhpBlPbyrkQElhUG(0);
							mPCHISyEEHpOlhpBlPbyrkQElhUG.BfEvOxJJHdrUWpUcMUbcWlBKFief = BfEvOxJJHdrUWpUcMUbcWlBKFief;
						}
						return mPCHISyEEHpOlhpBlPbyrkQElhUG;
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
					[IteratorStateMachine(typeof(CVYBFsDXNcenzSsiBhhIoZsJHODY))]
					get
					{
						return new CVYBFsDXNcenzSsiBhhIoZsJHODY(-2)
						{
							yEbvJzMQmOUXEaHyrJTeMLotMDVG = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(MPCHISyEEHpOlhpBlPbyrkQElhUG))]
					get
					{
						return new MPCHISyEEHpOlhpBlPbyrkQElhUG(-2)
						{
							BfEvOxJJHdrUWpUcMUbcWlBKFief = this
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

			private sealed class GJYGsTzOLdhUjwmQjWRyJxsWddNQ : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int YQAvjaaIZPgyQjjCATrDsdRQLlgb;

				private Axis nqNeEwieFliEYEEmgupVmcqOChvGB;

				private int pTJSFifeyuaIYHkTxtDscMVVdEhmA;

				public Platform_SDL2_Base urQLVgWpxOiDzFadzusDjDKuRYxA;

				private int EcVZXcwpaLnMXxHayoyOwlimvreb;

				private int YLCMaVHCUQtbHVOGDceoKkyqzLSr;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return nqNeEwieFliEYEEmgupVmcqOChvGB;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return nqNeEwieFliEYEEmgupVmcqOChvGB;
					}
				}

				[DebuggerHidden]
				public GJYGsTzOLdhUjwmQjWRyJxsWddNQ(int P_0)
				{
					YQAvjaaIZPgyQjjCATrDsdRQLlgb = P_0;
					pTJSFifeyuaIYHkTxtDscMVVdEhmA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int yQAvjaaIZPgyQjjCATrDsdRQLlgb = YQAvjaaIZPgyQjjCATrDsdRQLlgb;
					Platform_SDL2_Base platform_SDL2_Base = urQLVgWpxOiDzFadzusDjDKuRYxA;
					switch (yQAvjaaIZPgyQjjCATrDsdRQLlgb)
					{
					default:
						return false;
					case 0:
						YQAvjaaIZPgyQjjCATrDsdRQLlgb = -1;
						if (platform_SDL2_Base.elements == null || platform_SDL2_Base.elements.axes == null)
						{
							return false;
						}
						EcVZXcwpaLnMXxHayoyOwlimvreb = platform_SDL2_Base.elements.axes.Length;
						YLCMaVHCUQtbHVOGDceoKkyqzLSr = 0;
						break;
					case 1:
						YQAvjaaIZPgyQjjCATrDsdRQLlgb = -1;
						YLCMaVHCUQtbHVOGDceoKkyqzLSr++;
						break;
					}
					if (YLCMaVHCUQtbHVOGDceoKkyqzLSr < EcVZXcwpaLnMXxHayoyOwlimvreb)
					{
						nqNeEwieFliEYEEmgupVmcqOChvGB = platform_SDL2_Base.elements.axes[YLCMaVHCUQtbHVOGDceoKkyqzLSr];
						YQAvjaaIZPgyQjjCATrDsdRQLlgb = 1;
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
					GJYGsTzOLdhUjwmQjWRyJxsWddNQ gJYGsTzOLdhUjwmQjWRyJxsWddNQ;
					if (YQAvjaaIZPgyQjjCATrDsdRQLlgb == -2 && pTJSFifeyuaIYHkTxtDscMVVdEhmA == Environment.CurrentManagedThreadId)
					{
						YQAvjaaIZPgyQjjCATrDsdRQLlgb = 0;
						gJYGsTzOLdhUjwmQjWRyJxsWddNQ = this;
					}
					else
					{
						gJYGsTzOLdhUjwmQjWRyJxsWddNQ = new GJYGsTzOLdhUjwmQjWRyJxsWddNQ(0);
						gJYGsTzOLdhUjwmQjWRyJxsWddNQ.urQLVgWpxOiDzFadzusDjDKuRYxA = urQLVgWpxOiDzFadzusDjDKuRYxA;
					}
					return gJYGsTzOLdhUjwmQjWRyJxsWddNQ;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class YFtUZXEuRWLPMdjLkfWvHbIVioBK : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int fOChpwChyGsnsYAsBuZOyCtwwsqE;

				private Button PHHrXHQxfENyoduIoPfxnFrtfAaeA;

				private int qNTcpeihkZEeDPEZcClosbDpbehSA;

				public Platform_SDL2_Base gOgHrBZWPKQMIaPCOGbODkhmBeLkA;

				private int mzSAdHorOdctvaDoaqUOeDrUWbjn;

				private int WONjlJEoCyrZcVkQQClabjtKAhVJA;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return PHHrXHQxfENyoduIoPfxnFrtfAaeA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return PHHrXHQxfENyoduIoPfxnFrtfAaeA;
					}
				}

				[DebuggerHidden]
				public YFtUZXEuRWLPMdjLkfWvHbIVioBK(int P_0)
				{
					fOChpwChyGsnsYAsBuZOyCtwwsqE = P_0;
					qNTcpeihkZEeDPEZcClosbDpbehSA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = fOChpwChyGsnsYAsBuZOyCtwwsqE;
					Platform_SDL2_Base platform_SDL2_Base = gOgHrBZWPKQMIaPCOGbODkhmBeLkA;
					switch (num)
					{
					default:
						return false;
					case 0:
						fOChpwChyGsnsYAsBuZOyCtwwsqE = -1;
						if (platform_SDL2_Base.elements == null || platform_SDL2_Base.elements.buttons == null)
						{
							return false;
						}
						mzSAdHorOdctvaDoaqUOeDrUWbjn = platform_SDL2_Base.elements.buttons.Length;
						WONjlJEoCyrZcVkQQClabjtKAhVJA = 0;
						break;
					case 1:
						fOChpwChyGsnsYAsBuZOyCtwwsqE = -1;
						WONjlJEoCyrZcVkQQClabjtKAhVJA++;
						break;
					}
					if (WONjlJEoCyrZcVkQQClabjtKAhVJA < mzSAdHorOdctvaDoaqUOeDrUWbjn)
					{
						PHHrXHQxfENyoduIoPfxnFrtfAaeA = platform_SDL2_Base.elements.buttons[WONjlJEoCyrZcVkQQClabjtKAhVJA];
						fOChpwChyGsnsYAsBuZOyCtwwsqE = 1;
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
					YFtUZXEuRWLPMdjLkfWvHbIVioBK yFtUZXEuRWLPMdjLkfWvHbIVioBK;
					if (fOChpwChyGsnsYAsBuZOyCtwwsqE == -2 && qNTcpeihkZEeDPEZcClosbDpbehSA == Environment.CurrentManagedThreadId)
					{
						fOChpwChyGsnsYAsBuZOyCtwwsqE = 0;
						yFtUZXEuRWLPMdjLkfWvHbIVioBK = this;
					}
					else
					{
						yFtUZXEuRWLPMdjLkfWvHbIVioBK = new YFtUZXEuRWLPMdjLkfWvHbIVioBK(0);
						yFtUZXEuRWLPMdjLkfWvHbIVioBK.gOgHrBZWPKQMIaPCOGbODkhmBeLkA = gOgHrBZWPKQMIaPCOGbODkhmBeLkA;
					}
					return yFtUZXEuRWLPMdjLkfWvHbIVioBK;
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

			[IteratorStateMachine(typeof(GJYGsTzOLdhUjwmQjWRyJxsWddNQ))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new GJYGsTzOLdhUjwmQjWRyJxsWddNQ(-2)
				{
					urQLVgWpxOiDzFadzusDjDKuRYxA = this
				};
			}

			[IteratorStateMachine(typeof(YFtUZXEuRWLPMdjLkfWvHbIVioBK))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new YFtUZXEuRWLPMdjLkfWvHbIVioBK(-2)
				{
					gOgHrBZWPKQMIaPCOGbODkhmBeLkA = this
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

			private sealed class eMICUUStXchUDGRJVuiotClBcSzY : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int YvboNLnXSkTJydlgpxqcIrJaVCVE;

				private Platform_Custom.Axis VqkvwXjmXmZrfRHEOKcnjryUuUJk;

				private int tMlgmpPgltZRTkbAFoRZbbbmuPjd;

				public Platform_WebGL_Base mTjKoCMcoegdzBKKbKHcYpsKLZVEA;

				private int SgOlHgxHNRhiJdBCbWqZMATSaTuM;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return VqkvwXjmXmZrfRHEOKcnjryUuUJk;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return VqkvwXjmXmZrfRHEOKcnjryUuUJk;
					}
				}

				[DebuggerHidden]
				public eMICUUStXchUDGRJVuiotClBcSzY(int P_0)
				{
					YvboNLnXSkTJydlgpxqcIrJaVCVE = P_0;
					tMlgmpPgltZRTkbAFoRZbbbmuPjd = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int yvboNLnXSkTJydlgpxqcIrJaVCVE = YvboNLnXSkTJydlgpxqcIrJaVCVE;
					Platform_WebGL_Base platform_WebGL_Base = mTjKoCMcoegdzBKKbKHcYpsKLZVEA;
					switch (yvboNLnXSkTJydlgpxqcIrJaVCVE)
					{
					default:
						return false;
					case 0:
						YvboNLnXSkTJydlgpxqcIrJaVCVE = -1;
						if (platform_WebGL_Base.elements == null || platform_WebGL_Base.elements.axes == null)
						{
							return false;
						}
						SgOlHgxHNRhiJdBCbWqZMATSaTuM = 0;
						break;
					case 1:
						YvboNLnXSkTJydlgpxqcIrJaVCVE = -1;
						SgOlHgxHNRhiJdBCbWqZMATSaTuM++;
						break;
					}
					if (SgOlHgxHNRhiJdBCbWqZMATSaTuM < platform_WebGL_Base.elements.axes.Length)
					{
						VqkvwXjmXmZrfRHEOKcnjryUuUJk = platform_WebGL_Base.elements.axes[SgOlHgxHNRhiJdBCbWqZMATSaTuM];
						YvboNLnXSkTJydlgpxqcIrJaVCVE = 1;
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
					eMICUUStXchUDGRJVuiotClBcSzY eMICUUStXchUDGRJVuiotClBcSzY2;
					if (YvboNLnXSkTJydlgpxqcIrJaVCVE == -2 && tMlgmpPgltZRTkbAFoRZbbbmuPjd == Environment.CurrentManagedThreadId)
					{
						YvboNLnXSkTJydlgpxqcIrJaVCVE = 0;
						eMICUUStXchUDGRJVuiotClBcSzY2 = this;
					}
					else
					{
						eMICUUStXchUDGRJVuiotClBcSzY2 = new eMICUUStXchUDGRJVuiotClBcSzY(0);
						eMICUUStXchUDGRJVuiotClBcSzY2.mTjKoCMcoegdzBKKbKHcYpsKLZVEA = mTjKoCMcoegdzBKKbKHcYpsKLZVEA;
					}
					return eMICUUStXchUDGRJVuiotClBcSzY2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class xVGfJBUOAQevhVaaxgliLCAIJCHc : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int cXcowfMDtfdwtZqsSXgjaFaKOlvT;

				private Platform_Custom.Button riUsyJSyLCaCCBmlZckIObpFBHEe;

				private int rsxJgabRLAbEMEvVFkJHQwKuvAnV;

				public Platform_WebGL_Base yJoAxIHKjOfFnExVvMbIgSirvzPcA;

				private int GgZmzHhVrlnjzOaJreSYbnDinJmo;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return riUsyJSyLCaCCBmlZckIObpFBHEe;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return riUsyJSyLCaCCBmlZckIObpFBHEe;
					}
				}

				[DebuggerHidden]
				public xVGfJBUOAQevhVaaxgliLCAIJCHc(int P_0)
				{
					cXcowfMDtfdwtZqsSXgjaFaKOlvT = P_0;
					rsxJgabRLAbEMEvVFkJHQwKuvAnV = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = cXcowfMDtfdwtZqsSXgjaFaKOlvT;
					Platform_WebGL_Base platform_WebGL_Base = yJoAxIHKjOfFnExVvMbIgSirvzPcA;
					switch (num)
					{
					default:
						return false;
					case 0:
						cXcowfMDtfdwtZqsSXgjaFaKOlvT = -1;
						if (platform_WebGL_Base.elements == null || platform_WebGL_Base.elements.buttons == null)
						{
							return false;
						}
						GgZmzHhVrlnjzOaJreSYbnDinJmo = 0;
						break;
					case 1:
						cXcowfMDtfdwtZqsSXgjaFaKOlvT = -1;
						GgZmzHhVrlnjzOaJreSYbnDinJmo++;
						break;
					}
					if (GgZmzHhVrlnjzOaJreSYbnDinJmo < platform_WebGL_Base.elements.buttons.Length)
					{
						riUsyJSyLCaCCBmlZckIObpFBHEe = platform_WebGL_Base.elements.buttons[GgZmzHhVrlnjzOaJreSYbnDinJmo];
						cXcowfMDtfdwtZqsSXgjaFaKOlvT = 1;
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
					xVGfJBUOAQevhVaaxgliLCAIJCHc xVGfJBUOAQevhVaaxgliLCAIJCHc2;
					if (cXcowfMDtfdwtZqsSXgjaFaKOlvT == -2 && rsxJgabRLAbEMEvVFkJHQwKuvAnV == Environment.CurrentManagedThreadId)
					{
						cXcowfMDtfdwtZqsSXgjaFaKOlvT = 0;
						xVGfJBUOAQevhVaaxgliLCAIJCHc2 = this;
					}
					else
					{
						xVGfJBUOAQevhVaaxgliLCAIJCHc2 = new xVGfJBUOAQevhVaaxgliLCAIJCHc(0);
						xVGfJBUOAQevhVaaxgliLCAIJCHc2.yJoAxIHKjOfFnExVvMbIgSirvzPcA = yJoAxIHKjOfFnExVvMbIgSirvzPcA;
					}
					return xVGfJBUOAQevhVaaxgliLCAIJCHc2;
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

			[IteratorStateMachine(typeof(eMICUUStXchUDGRJVuiotClBcSzY))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new eMICUUStXchUDGRJVuiotClBcSzY(-2)
				{
					mTjKoCMcoegdzBKKbKHcYpsKLZVEA = this
				};
			}

			[IteratorStateMachine(typeof(xVGfJBUOAQevhVaaxgliLCAIJCHc))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new xVGfJBUOAQevhVaaxgliLCAIJCHc(-2)
				{
					yJoAxIHKjOfFnExVvMbIgSirvzPcA = this
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

			[EditorBrowsable(EditorBrowsableState.Never)]
			[CustomObfuscation(rename = false)]
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

			[EditorBrowsable(EditorBrowsableState.Never)]
			[CustomObfuscation(rename = false)]
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

			private sealed class pdthnsJllpnonDTMWmsjanyjGSpZ : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int OIrXdgsBWuGwQicopvcbjVdZgaZhb;

				private Platform_Custom.Axis OpbTrsliwxdErubcetokEnIsrTbR;

				private int fdQjRAfqCAFtuEumiHOqYgnmGaprA;

				public Platform_AppleGCController_Base KWOKThvNsPWaJCKAtVrVqQNElDho;

				private int iCojhMIiaDZBvFozriIEqCGHSKJNA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return OpbTrsliwxdErubcetokEnIsrTbR;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return OpbTrsliwxdErubcetokEnIsrTbR;
					}
				}

				[DebuggerHidden]
				public pdthnsJllpnonDTMWmsjanyjGSpZ(int P_0)
				{
					OIrXdgsBWuGwQicopvcbjVdZgaZhb = P_0;
					fdQjRAfqCAFtuEumiHOqYgnmGaprA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int oIrXdgsBWuGwQicopvcbjVdZgaZhb = OIrXdgsBWuGwQicopvcbjVdZgaZhb;
					Platform_AppleGCController_Base kWOKThvNsPWaJCKAtVrVqQNElDho = KWOKThvNsPWaJCKAtVrVqQNElDho;
					switch (oIrXdgsBWuGwQicopvcbjVdZgaZhb)
					{
					default:
						return false;
					case 0:
						OIrXdgsBWuGwQicopvcbjVdZgaZhb = -1;
						if (kWOKThvNsPWaJCKAtVrVqQNElDho.elements == null || kWOKThvNsPWaJCKAtVrVqQNElDho.elements.axes == null)
						{
							return false;
						}
						iCojhMIiaDZBvFozriIEqCGHSKJNA = 0;
						break;
					case 1:
						OIrXdgsBWuGwQicopvcbjVdZgaZhb = -1;
						iCojhMIiaDZBvFozriIEqCGHSKJNA++;
						break;
					}
					if (iCojhMIiaDZBvFozriIEqCGHSKJNA < kWOKThvNsPWaJCKAtVrVqQNElDho.elements.axes.Length)
					{
						OpbTrsliwxdErubcetokEnIsrTbR = kWOKThvNsPWaJCKAtVrVqQNElDho.elements.axes[iCojhMIiaDZBvFozriIEqCGHSKJNA];
						OIrXdgsBWuGwQicopvcbjVdZgaZhb = 1;
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
					pdthnsJllpnonDTMWmsjanyjGSpZ pdthnsJllpnonDTMWmsjanyjGSpZ2;
					if (OIrXdgsBWuGwQicopvcbjVdZgaZhb == -2 && fdQjRAfqCAFtuEumiHOqYgnmGaprA == Environment.CurrentManagedThreadId)
					{
						OIrXdgsBWuGwQicopvcbjVdZgaZhb = 0;
						pdthnsJllpnonDTMWmsjanyjGSpZ2 = this;
					}
					else
					{
						pdthnsJllpnonDTMWmsjanyjGSpZ2 = new pdthnsJllpnonDTMWmsjanyjGSpZ(0);
						pdthnsJllpnonDTMWmsjanyjGSpZ2.KWOKThvNsPWaJCKAtVrVqQNElDho = KWOKThvNsPWaJCKAtVrVqQNElDho;
					}
					return pdthnsJllpnonDTMWmsjanyjGSpZ2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class CIDmydJoGquFAjAdwlEjFhBWFMekA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int bZffcQijfwdMXJWgrGJJaJhrHhBPA;

				private Platform_Custom.Button TOcMivqciuYADpQZtDcHaKtiVASnA;

				private int yddDRJkFpfYcnpirbHJIEndZuRDab;

				public Platform_AppleGCController_Base AhAcWInfOGkoVtARyQJBcbrlaMeIA;

				private int byWDeIHDduCTnnGqVgWFkxnmsxVF;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return TOcMivqciuYADpQZtDcHaKtiVASnA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return TOcMivqciuYADpQZtDcHaKtiVASnA;
					}
				}

				[DebuggerHidden]
				public CIDmydJoGquFAjAdwlEjFhBWFMekA(int P_0)
				{
					bZffcQijfwdMXJWgrGJJaJhrHhBPA = P_0;
					yddDRJkFpfYcnpirbHJIEndZuRDab = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = bZffcQijfwdMXJWgrGJJaJhrHhBPA;
					Platform_AppleGCController_Base ahAcWInfOGkoVtARyQJBcbrlaMeIA = AhAcWInfOGkoVtARyQJBcbrlaMeIA;
					switch (num)
					{
					default:
						return false;
					case 0:
						bZffcQijfwdMXJWgrGJJaJhrHhBPA = -1;
						if (ahAcWInfOGkoVtARyQJBcbrlaMeIA.elements == null || ahAcWInfOGkoVtARyQJBcbrlaMeIA.elements.buttons == null)
						{
							return false;
						}
						byWDeIHDduCTnnGqVgWFkxnmsxVF = 0;
						break;
					case 1:
						bZffcQijfwdMXJWgrGJJaJhrHhBPA = -1;
						byWDeIHDduCTnnGqVgWFkxnmsxVF++;
						break;
					}
					if (byWDeIHDduCTnnGqVgWFkxnmsxVF < ahAcWInfOGkoVtARyQJBcbrlaMeIA.elements.buttons.Length)
					{
						TOcMivqciuYADpQZtDcHaKtiVASnA = ahAcWInfOGkoVtARyQJBcbrlaMeIA.elements.buttons[byWDeIHDduCTnnGqVgWFkxnmsxVF];
						bZffcQijfwdMXJWgrGJJaJhrHhBPA = 1;
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
					CIDmydJoGquFAjAdwlEjFhBWFMekA cIDmydJoGquFAjAdwlEjFhBWFMekA;
					if (bZffcQijfwdMXJWgrGJJaJhrHhBPA == -2 && yddDRJkFpfYcnpirbHJIEndZuRDab == Environment.CurrentManagedThreadId)
					{
						bZffcQijfwdMXJWgrGJJaJhrHhBPA = 0;
						cIDmydJoGquFAjAdwlEjFhBWFMekA = this;
					}
					else
					{
						cIDmydJoGquFAjAdwlEjFhBWFMekA = new CIDmydJoGquFAjAdwlEjFhBWFMekA(0);
						cIDmydJoGquFAjAdwlEjFhBWFMekA.AhAcWInfOGkoVtARyQJBcbrlaMeIA = AhAcWInfOGkoVtARyQJBcbrlaMeIA;
					}
					return cIDmydJoGquFAjAdwlEjFhBWFMekA;
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

			[IteratorStateMachine(typeof(pdthnsJllpnonDTMWmsjanyjGSpZ))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new pdthnsJllpnonDTMWmsjanyjGSpZ(-2)
				{
					KWOKThvNsPWaJCKAtVrVqQNElDho = this
				};
			}

			[IteratorStateMachine(typeof(CIDmydJoGquFAjAdwlEjFhBWFMekA))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new CIDmydJoGquFAjAdwlEjFhBWFMekA(-2)
				{
					AhAcWInfOGkoVtARyQJBcbrlaMeIA = this
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

		private sealed class szWHfUAGSjCHgHLWExwtdSdgJGwWA : IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerable, IEnumerator<IControllerElementIdentifierCommon_Internal>, IEnumerator, IDisposable
		{
			private int GIurKoeOMdmoWqOTrpTcxlrmNgaq;

			private IControllerElementIdentifierCommon_Internal arnVVjzjZBBLPjMDYNkTFwlkvfhVA;

			private int rlWHYBFAISTfOEhIIDEVekyOeHFL;

			public HardwareJoystickMap QtpFtvwSsGFkpOAaeXusepoJRsB;

			private int yhHUXLfTrdGajskUqyDEuhArFVee;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
			{
				[DebuggerHidden]
				get
				{
					return arnVVjzjZBBLPjMDYNkTFwlkvfhVA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return arnVVjzjZBBLPjMDYNkTFwlkvfhVA;
				}
			}

			[DebuggerHidden]
			public szWHfUAGSjCHgHLWExwtdSdgJGwWA(int P_0)
			{
				GIurKoeOMdmoWqOTrpTcxlrmNgaq = P_0;
				rlWHYBFAISTfOEhIIDEVekyOeHFL = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gIurKoeOMdmoWqOTrpTcxlrmNgaq = GIurKoeOMdmoWqOTrpTcxlrmNgaq;
				HardwareJoystickMap qtpFtvwSsGFkpOAaeXusepoJRsB = QtpFtvwSsGFkpOAaeXusepoJRsB;
				switch (gIurKoeOMdmoWqOTrpTcxlrmNgaq)
				{
				default:
					return false;
				case 0:
					GIurKoeOMdmoWqOTrpTcxlrmNgaq = -1;
					if (qtpFtvwSsGFkpOAaeXusepoJRsB.elementIdentifiers == null)
					{
						return false;
					}
					yhHUXLfTrdGajskUqyDEuhArFVee = 0;
					break;
				case 1:
					GIurKoeOMdmoWqOTrpTcxlrmNgaq = -1;
					yhHUXLfTrdGajskUqyDEuhArFVee++;
					break;
				}
				if (yhHUXLfTrdGajskUqyDEuhArFVee < qtpFtvwSsGFkpOAaeXusepoJRsB.elementIdentifiers.Length)
				{
					arnVVjzjZBBLPjMDYNkTFwlkvfhVA = qtpFtvwSsGFkpOAaeXusepoJRsB.elementIdentifiers[yhHUXLfTrdGajskUqyDEuhArFVee];
					GIurKoeOMdmoWqOTrpTcxlrmNgaq = 1;
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
				szWHfUAGSjCHgHLWExwtdSdgJGwWA szWHfUAGSjCHgHLWExwtdSdgJGwWA2;
				if (GIurKoeOMdmoWqOTrpTcxlrmNgaq == -2 && rlWHYBFAISTfOEhIIDEVekyOeHFL == Environment.CurrentManagedThreadId)
				{
					GIurKoeOMdmoWqOTrpTcxlrmNgaq = 0;
					szWHfUAGSjCHgHLWExwtdSdgJGwWA2 = this;
				}
				else
				{
					szWHfUAGSjCHgHLWExwtdSdgJGwWA2 = new szWHfUAGSjCHgHLWExwtdSdgJGwWA(0);
					szWHfUAGSjCHgHLWExwtdSdgJGwWA2.QtpFtvwSsGFkpOAaeXusepoJRsB = QtpFtvwSsGFkpOAaeXusepoJRsB;
				}
				return szWHfUAGSjCHgHLWExwtdSdgJGwWA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<IControllerElementIdentifierCommon_Internal>)this).GetEnumerator();
			}
		}

		private sealed class gvibjfQUqIwmIDVKkfxjYPYIXBkI : IEnumerable<ControllerElementIdentifier>, IEnumerable, IEnumerator<ControllerElementIdentifier>, IEnumerator, IDisposable
		{
			private int ddJbXzpNupaeKWAvHbSLOTEKRuxt;

			private ControllerElementIdentifier BJLygVdkXEjpXDIfwcWSOfibJilcA;

			private int PxhXSYmLvufaPVuXhxNuSafOuETU;

			public HardwareJoystickMap vqIdYlrGxFAZqjhFFWyklaXYMsqS;

			private int qhNRnpibEDAOzjauBXfiOOXamooQ;

			ControllerElementIdentifier IEnumerator<ControllerElementIdentifier>.Current
			{
				[DebuggerHidden]
				get
				{
					return BJLygVdkXEjpXDIfwcWSOfibJilcA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return BJLygVdkXEjpXDIfwcWSOfibJilcA;
				}
			}

			[DebuggerHidden]
			public gvibjfQUqIwmIDVKkfxjYPYIXBkI(int P_0)
			{
				ddJbXzpNupaeKWAvHbSLOTEKRuxt = P_0;
				PxhXSYmLvufaPVuXhxNuSafOuETU = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = ddJbXzpNupaeKWAvHbSLOTEKRuxt;
				HardwareJoystickMap hardwareJoystickMap = vqIdYlrGxFAZqjhFFWyklaXYMsqS;
				switch (num)
				{
				default:
					return false;
				case 0:
					ddJbXzpNupaeKWAvHbSLOTEKRuxt = -1;
					if (hardwareJoystickMap.elementIdentifiers == null)
					{
						return false;
					}
					qhNRnpibEDAOzjauBXfiOOXamooQ = 0;
					break;
				case 1:
					ddJbXzpNupaeKWAvHbSLOTEKRuxt = -1;
					qhNRnpibEDAOzjauBXfiOOXamooQ++;
					break;
				}
				if (qhNRnpibEDAOzjauBXfiOOXamooQ < hardwareJoystickMap.elementIdentifiers.Length)
				{
					BJLygVdkXEjpXDIfwcWSOfibJilcA = hardwareJoystickMap.elementIdentifiers[qhNRnpibEDAOzjauBXfiOOXamooQ];
					ddJbXzpNupaeKWAvHbSLOTEKRuxt = 1;
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
				gvibjfQUqIwmIDVKkfxjYPYIXBkI gvibjfQUqIwmIDVKkfxjYPYIXBkI2;
				if (ddJbXzpNupaeKWAvHbSLOTEKRuxt == -2 && PxhXSYmLvufaPVuXhxNuSafOuETU == Environment.CurrentManagedThreadId)
				{
					ddJbXzpNupaeKWAvHbSLOTEKRuxt = 0;
					gvibjfQUqIwmIDVKkfxjYPYIXBkI2 = this;
				}
				else
				{
					gvibjfQUqIwmIDVKkfxjYPYIXBkI2 = new gvibjfQUqIwmIDVKkfxjYPYIXBkI(0);
					gvibjfQUqIwmIDVKkfxjYPYIXBkI2.vqIdYlrGxFAZqjhFFWyklaXYMsqS = vqIdYlrGxFAZqjhFFWyklaXYMsqS;
				}
				return gvibjfQUqIwmIDVKkfxjYPYIXBkI2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerElementIdentifier>)this).GetEnumerator();
			}
		}

		private sealed class VCqfrAbbnLDjEGiJoXRHKkkmYYhd : IEnumerable<JoystickType>, IEnumerable, IEnumerator<JoystickType>, IEnumerator, IDisposable
		{
			private int WtoPwNnMsnLOerPExAoPAOdxPlkcb;

			private JoystickType vzLqTvEgCoCrgzjzbdfIgrflATLJ;

			private int razEMJXLRnmDUPeLMLxtHktxcxnh;

			public HardwareJoystickMap qhMOALvabtbPQYrPWKkjTXEapEzU;

			private int sWVpnoqLbaVjfVSNLfYnGsVvKlQjb;

			JoystickType IEnumerator<JoystickType>.Current
			{
				[DebuggerHidden]
				get
				{
					return vzLqTvEgCoCrgzjzbdfIgrflATLJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vzLqTvEgCoCrgzjzbdfIgrflATLJ;
				}
			}

			[DebuggerHidden]
			public VCqfrAbbnLDjEGiJoXRHKkkmYYhd(int P_0)
			{
				WtoPwNnMsnLOerPExAoPAOdxPlkcb = P_0;
				razEMJXLRnmDUPeLMLxtHktxcxnh = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int wtoPwNnMsnLOerPExAoPAOdxPlkcb = WtoPwNnMsnLOerPExAoPAOdxPlkcb;
				HardwareJoystickMap hardwareJoystickMap = qhMOALvabtbPQYrPWKkjTXEapEzU;
				switch (wtoPwNnMsnLOerPExAoPAOdxPlkcb)
				{
				default:
					return false;
				case 0:
					WtoPwNnMsnLOerPExAoPAOdxPlkcb = -1;
					if (hardwareJoystickMap.joystickTypes == null)
					{
						return false;
					}
					sWVpnoqLbaVjfVSNLfYnGsVvKlQjb = 0;
					break;
				case 1:
					WtoPwNnMsnLOerPExAoPAOdxPlkcb = -1;
					sWVpnoqLbaVjfVSNLfYnGsVvKlQjb++;
					break;
				}
				if (sWVpnoqLbaVjfVSNLfYnGsVvKlQjb < hardwareJoystickMap.joystickTypes.Length)
				{
					vzLqTvEgCoCrgzjzbdfIgrflATLJ = hardwareJoystickMap.joystickTypes[sWVpnoqLbaVjfVSNLfYnGsVvKlQjb];
					WtoPwNnMsnLOerPExAoPAOdxPlkcb = 1;
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
				VCqfrAbbnLDjEGiJoXRHKkkmYYhd vCqfrAbbnLDjEGiJoXRHKkkmYYhd;
				if (WtoPwNnMsnLOerPExAoPAOdxPlkcb == -2 && razEMJXLRnmDUPeLMLxtHktxcxnh == Environment.CurrentManagedThreadId)
				{
					WtoPwNnMsnLOerPExAoPAOdxPlkcb = 0;
					vCqfrAbbnLDjEGiJoXRHKkkmYYhd = this;
				}
				else
				{
					vCqfrAbbnLDjEGiJoXRHKkkmYYhd = new VCqfrAbbnLDjEGiJoXRHKkkmYYhd(0);
					vCqfrAbbnLDjEGiJoXRHKkkmYYhd.qhMOALvabtbPQYrPWKkjTXEapEzU = qhMOALvabtbPQYrPWKkjTXEapEzU;
				}
				return vCqfrAbbnLDjEGiJoXRHKkkmYYhd;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JoystickType>)this).GetEnumerator();
			}
		}

		private sealed class xEKgnyOsfnhicUYXYHEfbNkNvFEo : IEnumerable<Guid>, IEnumerable, IEnumerator<Guid>, IEnumerator, IDisposable
		{
			private int nLhfguICFEDpiSNkuDsxjBvttMPhA;

			private Guid PBljEbaZtuvRBjSFxGXvpyMSgxatA;

			private int NWCldVpuuEAIjKBLzHuNbGHdLBHAA;

			public HardwareJoystickMap AWpdCQvhANFDTxzyuAGPGcBhiSen;

			private int WbOsjoHlKlicTGAtQnMJyWqqeWoNA;

			Guid IEnumerator<Guid>.Current
			{
				[DebuggerHidden]
				get
				{
					return PBljEbaZtuvRBjSFxGXvpyMSgxatA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return PBljEbaZtuvRBjSFxGXvpyMSgxatA;
				}
			}

			[DebuggerHidden]
			public xEKgnyOsfnhicUYXYHEfbNkNvFEo(int P_0)
			{
				nLhfguICFEDpiSNkuDsxjBvttMPhA = P_0;
				NWCldVpuuEAIjKBLzHuNbGHdLBHAA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = nLhfguICFEDpiSNkuDsxjBvttMPhA;
				HardwareJoystickMap aWpdCQvhANFDTxzyuAGPGcBhiSen = AWpdCQvhANFDTxzyuAGPGcBhiSen;
				switch (num)
				{
				default:
					return false;
				case 0:
					nLhfguICFEDpiSNkuDsxjBvttMPhA = -1;
					if (aWpdCQvhANFDTxzyuAGPGcBhiSen.templateGuids == null)
					{
						return false;
					}
					WbOsjoHlKlicTGAtQnMJyWqqeWoNA = 0;
					break;
				case 1:
					nLhfguICFEDpiSNkuDsxjBvttMPhA = -1;
					WbOsjoHlKlicTGAtQnMJyWqqeWoNA++;
					break;
				}
				if (WbOsjoHlKlicTGAtQnMJyWqqeWoNA < aWpdCQvhANFDTxzyuAGPGcBhiSen.templateGuids.Length)
				{
					PBljEbaZtuvRBjSFxGXvpyMSgxatA = StringTools.ToGuid(aWpdCQvhANFDTxzyuAGPGcBhiSen.templateGuids[WbOsjoHlKlicTGAtQnMJyWqqeWoNA]);
					nLhfguICFEDpiSNkuDsxjBvttMPhA = 1;
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
				xEKgnyOsfnhicUYXYHEfbNkNvFEo xEKgnyOsfnhicUYXYHEfbNkNvFEo2;
				if (nLhfguICFEDpiSNkuDsxjBvttMPhA == -2 && NWCldVpuuEAIjKBLzHuNbGHdLBHAA == Environment.CurrentManagedThreadId)
				{
					nLhfguICFEDpiSNkuDsxjBvttMPhA = 0;
					xEKgnyOsfnhicUYXYHEfbNkNvFEo2 = this;
				}
				else
				{
					xEKgnyOsfnhicUYXYHEfbNkNvFEo2 = new xEKgnyOsfnhicUYXYHEfbNkNvFEo(0);
					xEKgnyOsfnhicUYXYHEfbNkNvFEo2.AWpdCQvhANFDTxzyuAGPGcBhiSen = AWpdCQvhANFDTxzyuAGPGcBhiSen;
				}
				return xEKgnyOsfnhicUYXYHEfbNkNvFEo2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Guid>)this).GetEnumerator();
			}
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool hideInLists;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_Android;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_iOS;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Stadia stadia;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_InternalDriver internalDriver;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_SDL2 sdl2_Linux;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_SDL2 sdl2_Windows;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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
			[IteratorStateMachine(typeof(xEKgnyOsfnhicUYXYHEfbNkNvFEo))]
			get
			{
				return new xEKgnyOsfnhicUYXYHEfbNkNvFEo(-2)
				{
					AWpdCQvhANFDTxzyuAGPGcBhiSen = this
				};
			}
		}

		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers
		{
			[IteratorStateMachine(typeof(gvibjfQUqIwmIDVKkfxjYPYIXBkI))]
			get
			{
				return new gvibjfQUqIwmIDVKkfxjYPYIXBkI(-2)
				{
					vqIdYlrGxFAZqjhFFWyklaXYMsqS = this
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
			[IteratorStateMachine(typeof(VCqfrAbbnLDjEGiJoXRHKkkmYYhd))]
			get
			{
				return new VCqfrAbbnLDjEGiJoXRHKkkmYYhd(-2)
				{
					qhMOALvabtbPQYrPWKkjTXEapEzU = this
				};
			}
		}

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			[IteratorStateMachine(typeof(szWHfUAGSjCHgHLWExwtdSdgJGwWA))]
			get
			{
				return new szWHfUAGSjCHgHLWExwtdSdgJGwWA(-2)
				{
					QtpFtvwSsGFkpOAaeXusepoJRsB = this
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
