using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
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
			private sealed class YzNuWhAZpdHhTGTeJwfoCWUUtkXA : IEnumerable<Platform>, IEnumerable, IEnumerator<Platform>, IEnumerator, IDisposable
			{
				private int VjrmgvXVmHuTQhYnNfBTvTzIlrnp;

				private Platform aqLtJvNknsgNfIYSoCShgmEuOwqvA;

				private int astqTtZQgZgAlrnlInwokGoFLuYt;

				public Platform ZVMmyHRKrLeuzMaFDaNIWigTRcdf;

				private IList<Platform> CErsbIiTeoRLJkMQJYHRAQkyPQnE;

				private int HJRarSAsUulOXWRIbygSmhSoFgCF;

				Platform IEnumerator<Platform>.Current
				{
					[DebuggerHidden]
					get
					{
						return aqLtJvNknsgNfIYSoCShgmEuOwqvA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return aqLtJvNknsgNfIYSoCShgmEuOwqvA;
					}
				}

				[DebuggerHidden]
				public YzNuWhAZpdHhTGTeJwfoCWUUtkXA(int P_0)
				{
					VjrmgvXVmHuTQhYnNfBTvTzIlrnp = P_0;
					astqTtZQgZgAlrnlInwokGoFLuYt = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int vjrmgvXVmHuTQhYnNfBTvTzIlrnp = VjrmgvXVmHuTQhYnNfBTvTzIlrnp;
					Platform zVMmyHRKrLeuzMaFDaNIWigTRcdf = ZVMmyHRKrLeuzMaFDaNIWigTRcdf;
					if (vjrmgvXVmHuTQhYnNfBTvTzIlrnp != 0)
					{
						if (vjrmgvXVmHuTQhYnNfBTvTzIlrnp != 1)
						{
							return false;
						}
						VjrmgvXVmHuTQhYnNfBTvTzIlrnp = -1;
						goto IL_0077;
					}
					VjrmgvXVmHuTQhYnNfBTvTzIlrnp = -1;
					CErsbIiTeoRLJkMQJYHRAQkyPQnE = zVMmyHRKrLeuzMaFDaNIWigTRcdf.GetVariants();
					if (CErsbIiTeoRLJkMQJYHRAQkyPQnE == null)
					{
						return false;
					}
					HJRarSAsUulOXWRIbygSmhSoFgCF = 0;
					goto IL_0087;
					IL_0087:
					if (HJRarSAsUulOXWRIbygSmhSoFgCF < CErsbIiTeoRLJkMQJYHRAQkyPQnE.Count)
					{
						if (CErsbIiTeoRLJkMQJYHRAQkyPQnE[HJRarSAsUulOXWRIbygSmhSoFgCF] != null)
						{
							aqLtJvNknsgNfIYSoCShgmEuOwqvA = CErsbIiTeoRLJkMQJYHRAQkyPQnE[HJRarSAsUulOXWRIbygSmhSoFgCF];
							VjrmgvXVmHuTQhYnNfBTvTzIlrnp = 1;
							return true;
						}
						goto IL_0077;
					}
					return false;
					IL_0077:
					HJRarSAsUulOXWRIbygSmhSoFgCF++;
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
					YzNuWhAZpdHhTGTeJwfoCWUUtkXA yzNuWhAZpdHhTGTeJwfoCWUUtkXA;
					if (VjrmgvXVmHuTQhYnNfBTvTzIlrnp == -2 && astqTtZQgZgAlrnlInwokGoFLuYt == Environment.CurrentManagedThreadId)
					{
						VjrmgvXVmHuTQhYnNfBTvTzIlrnp = 0;
						yzNuWhAZpdHhTGTeJwfoCWUUtkXA = this;
					}
					else
					{
						yzNuWhAZpdHhTGTeJwfoCWUUtkXA = new YzNuWhAZpdHhTGTeJwfoCWUUtkXA(0);
						yzNuWhAZpdHhTGTeJwfoCWUUtkXA.ZVMmyHRKrLeuzMaFDaNIWigTRcdf = ZVMmyHRKrLeuzMaFDaNIWigTRcdf;
					}
					return yzNuWhAZpdHhTGTeJwfoCWUUtkXA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform>)this).GetEnumerator();
				}
			}

			[Tooltip("A description of this platform map. For reference only.")]
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

			internal IEnumerable<Platform> Variants
			{
				[IteratorStateMachine(typeof(YzNuWhAZpdHhTGTeJwfoCWUUtkXA))]
				get
				{
					return new YzNuWhAZpdHhTGTeJwfoCWUUtkXA(-2)
					{
						ZVMmyHRKrLeuzMaFDaNIWigTRcdf = this
					};
				}
			}

			internal bool hasVariants => variantCount > 0;

			[CustomObfuscation(rename = false)]
			internal int variantCount
			{
				get
				{
					if (GetVariants() == null)
					{
						return 0;
					}
					return GetVariants().Count;
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

			internal abstract void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes);

			internal abstract bool IsElementIdentifierMapped(int elementIdentifierId);

			public abstract IList<Platform> GetVariants();

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
				IList<Platform> variants = GetVariants();
				if (variants != null)
				{
					for (int i = 0; i < variants.Count; i++)
					{
						Platform platform = variants[i];
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
				IList<Platform> variants = GetVariants();
				if (variantCount <= variantIndex)
				{
					return null;
				}
				return variants[variantIndex];
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
				List<Guid> list = new List<Guid>();
				hardwareJoystickMap.GetTemplateGuids(list);
				DeviceLocalizationInfo deviceLocalizationInfo = new DeviceLocalizationInfo(ControllerType.Joystick, false, hardwareJoystickMap.Guid, new List<string> { hardwareJoystickMap.Key }, list);
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = new HardwareJoystickMap_InputManager(new HardwareControllerMapIdentifier(hardwareJoystickMap.Guid, inputSource, actualInputPlatform, variantIndex), hardwareJoystickMap.joystickTypes, deviceLocalizationInfo, platform, controllerName, platform.assignedButtonCount, platform.assignedAxisCount, hardwareJoystickMap.elementIdentifiers.Length, hardwareJoystickMap.compoundElements);
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
					jxcSgBCAckNrIjPsBFiAMTdHLFuQ(elementCount_Base);
					return elementCount_Base;
				}

				object IDeepCloneable.DeepClone()
				{
					//ILSpy generated this explicit interface implementation from .override directive in DeepClone
					return this.DeepClone();
				}

				internal virtual void jxcSgBCAckNrIjPsBFiAMTdHLFuQ(ElementCount_Base P_0)
				{
					if (P_0 != null)
					{
						P_0.axisCount = axisCount;
						P_0.buttonCount = buttonCount;
					}
				}

				internal virtual bool KhdgjMQnSkGAvAuHpiccCSGlQcYsA(BridgedControllerHWInfo P_0)
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

			[Tooltip("The number of axes reported by the controller. If the value reported by the controller differs from this value, the controller is not a match. [-1 to match to any number of axes]")]
			public int axisCount;

			[Tooltip("The number of buttons reported by the controller. If the value reported by the controller differs from this value, the controller is not a match. [-1 to match to any number of buttons]")]
			public int buttonCount;

			[Tooltip("If checked, this entire platform map will be skipped and will not match to any controller.")]
			public bool disabled;

			[Tooltip("User-defined string. May have functionality on some input sources but not on others.")]
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
					if (elementCount_Base != null && elementCount_Base.KhdgjMQnSkGAvAuHpiccCSGlQcYsA(bridgedControllerHWInfo))
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
						jxcSgBCAckNrIjPsBFiAMTdHLFuQ(elementCount);
						return elementCount;
					}

					internal void bPDgqpPdyaturrisvISNvBmqVMKH(ElementCount_Base P_0)
					{
						base.jxcSgBCAckNrIjPsBFiAMTdHLFuQ(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool EjtUmtTwSMOikIegoWdDvZtjgwtV(BridgedControllerHWInfo P_0)
					{
						if (!base.KhdgjMQnSkGAvAuHpiccCSGlQcYsA(P_0))
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
				private sealed class hLcXPTfLudfqYJtLXWorGTkQNIsIA : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int uPRIOcoiaBWzEnUCrOanoBxCoHfQ;

					private Axis_Base CkESJyZZpXkUkGyqUNLioXLMCycC;

					private int UBZHiAaiSOdWkPIlGQPPgyfFbxwSA;

					public Elements eYJZneALsOhbOoxsMpWRmeYCbxOt;

					private int NKfByGsJbdVJteZUHopVpeiiWqVx;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return CkESJyZZpXkUkGyqUNLioXLMCycC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return CkESJyZZpXkUkGyqUNLioXLMCycC;
						}
					}

					[DebuggerHidden]
					public hLcXPTfLudfqYJtLXWorGTkQNIsIA(int P_0)
					{
						uPRIOcoiaBWzEnUCrOanoBxCoHfQ = P_0;
						UBZHiAaiSOdWkPIlGQPPgyfFbxwSA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = uPRIOcoiaBWzEnUCrOanoBxCoHfQ;
						Elements elements = eYJZneALsOhbOoxsMpWRmeYCbxOt;
						switch (num)
						{
						default:
							return false;
						case 0:
							uPRIOcoiaBWzEnUCrOanoBxCoHfQ = -1;
							if (elements.axes == null)
							{
								return false;
							}
							NKfByGsJbdVJteZUHopVpeiiWqVx = 0;
							break;
						case 1:
							uPRIOcoiaBWzEnUCrOanoBxCoHfQ = -1;
							NKfByGsJbdVJteZUHopVpeiiWqVx++;
							break;
						}
						if (NKfByGsJbdVJteZUHopVpeiiWqVx < elements.axes.Length)
						{
							CkESJyZZpXkUkGyqUNLioXLMCycC = elements.axes[NKfByGsJbdVJteZUHopVpeiiWqVx];
							uPRIOcoiaBWzEnUCrOanoBxCoHfQ = 1;
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
						hLcXPTfLudfqYJtLXWorGTkQNIsIA hLcXPTfLudfqYJtLXWorGTkQNIsIA2;
						if (uPRIOcoiaBWzEnUCrOanoBxCoHfQ == -2 && UBZHiAaiSOdWkPIlGQPPgyfFbxwSA == Environment.CurrentManagedThreadId)
						{
							uPRIOcoiaBWzEnUCrOanoBxCoHfQ = 0;
							hLcXPTfLudfqYJtLXWorGTkQNIsIA2 = this;
						}
						else
						{
							hLcXPTfLudfqYJtLXWorGTkQNIsIA2 = new hLcXPTfLudfqYJtLXWorGTkQNIsIA(0);
							hLcXPTfLudfqYJtLXWorGTkQNIsIA2.eYJZneALsOhbOoxsMpWRmeYCbxOt = eYJZneALsOhbOoxsMpWRmeYCbxOt;
						}
						return hLcXPTfLudfqYJtLXWorGTkQNIsIA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}
				}

				private sealed class mJCDDorJJVmgjykFFjtxuawcwCLl : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int sLPtjFOidJADzKMGPmzZyutFRQEV;

					private Button_Base AoRyDyjatVQmPzcYjtrmujpZULwn;

					private int CZfQKLXBBxChNnhpwhQrjwhpFZlW;

					public Elements qMBfWUSrZvHlGWpGCrZYiZEUDdjU;

					private int QmZgspROCejkhzneKubEHVYLerwx;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return AoRyDyjatVQmPzcYjtrmujpZULwn;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return AoRyDyjatVQmPzcYjtrmujpZULwn;
						}
					}

					[DebuggerHidden]
					public mJCDDorJJVmgjykFFjtxuawcwCLl(int P_0)
					{
						sLPtjFOidJADzKMGPmzZyutFRQEV = P_0;
						CZfQKLXBBxChNnhpwhQrjwhpFZlW = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = sLPtjFOidJADzKMGPmzZyutFRQEV;
						Elements elements = qMBfWUSrZvHlGWpGCrZYiZEUDdjU;
						switch (num)
						{
						default:
							return false;
						case 0:
							sLPtjFOidJADzKMGPmzZyutFRQEV = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							QmZgspROCejkhzneKubEHVYLerwx = 0;
							break;
						case 1:
							sLPtjFOidJADzKMGPmzZyutFRQEV = -1;
							QmZgspROCejkhzneKubEHVYLerwx++;
							break;
						}
						if (QmZgspROCejkhzneKubEHVYLerwx < elements.buttons.Length)
						{
							AoRyDyjatVQmPzcYjtrmujpZULwn = elements.buttons[QmZgspROCejkhzneKubEHVYLerwx];
							sLPtjFOidJADzKMGPmzZyutFRQEV = 1;
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
						mJCDDorJJVmgjykFFjtxuawcwCLl mJCDDorJJVmgjykFFjtxuawcwCLl2;
						if (sLPtjFOidJADzKMGPmzZyutFRQEV == -2 && CZfQKLXBBxChNnhpwhQrjwhpFZlW == Environment.CurrentManagedThreadId)
						{
							sLPtjFOidJADzKMGPmzZyutFRQEV = 0;
							mJCDDorJJVmgjykFFjtxuawcwCLl2 = this;
						}
						else
						{
							mJCDDorJJVmgjykFFjtxuawcwCLl2 = new mJCDDorJJVmgjykFFjtxuawcwCLl(0);
							mJCDDorJJVmgjykFFjtxuawcwCLl2.qMBfWUSrZvHlGWpGCrZYiZEUDdjU = qMBfWUSrZvHlGWpGCrZYiZEUDdjU;
						}
						return mJCDDorJJVmgjykFFjtxuawcwCLl2;
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
					[IteratorStateMachine(typeof(hLcXPTfLudfqYJtLXWorGTkQNIsIA))]
					get
					{
						return new hLcXPTfLudfqYJtLXWorGTkQNIsIA(-2)
						{
							eYJZneALsOhbOoxsMpWRmeYCbxOt = this
						};
					}
				}

				IEnumerable<Button_Base> Elements_Platform_Base.Buttons
				{
					[IteratorStateMachine(typeof(mJCDDorJJVmgjykFFjtxuawcwCLl))]
					get
					{
						return new mJCDDorJJVmgjykFFjtxuawcwCLl(-2)
						{
							qMBfWUSrZvHlGWpGCrZYiZEUDdjU = this
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

			private sealed class TsvqaNbhSRikKXiQcwioFJFQbwnK : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int LfQebfpduBwhAGlZZGQKFBEhQqZb;

				private Axis_Base rBVkeNMeEEafsCnEvPEDDzFceTJDb;

				private int YGbeWZBNoHbJSuYqaQBltARaDBInA;

				public Platform_DirectInput_Base mskdkAyyhlaVxcYUhwZFCZcGPrtC;

				private int lBKhrYjEHKqHtDRDZTMGgxJFROdCc;

				private int gZoOFSufLOLaogkWwbroFsyEdWzpA;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return rBVkeNMeEEafsCnEvPEDDzFceTJDb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return rBVkeNMeEEafsCnEvPEDDzFceTJDb;
					}
				}

				[DebuggerHidden]
				public TsvqaNbhSRikKXiQcwioFJFQbwnK(int P_0)
				{
					LfQebfpduBwhAGlZZGQKFBEhQqZb = P_0;
					YGbeWZBNoHbJSuYqaQBltARaDBInA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int lfQebfpduBwhAGlZZGQKFBEhQqZb = LfQebfpduBwhAGlZZGQKFBEhQqZb;
					Platform_DirectInput_Base platform_DirectInput_Base = mskdkAyyhlaVxcYUhwZFCZcGPrtC;
					switch (lfQebfpduBwhAGlZZGQKFBEhQqZb)
					{
					default:
						return false;
					case 0:
						LfQebfpduBwhAGlZZGQKFBEhQqZb = -1;
						if (platform_DirectInput_Base.elements == null || platform_DirectInput_Base.elements.axes == null)
						{
							return false;
						}
						lBKhrYjEHKqHtDRDZTMGgxJFROdCc = platform_DirectInput_Base.elements.axes.Length;
						gZoOFSufLOLaogkWwbroFsyEdWzpA = 0;
						break;
					case 1:
						LfQebfpduBwhAGlZZGQKFBEhQqZb = -1;
						gZoOFSufLOLaogkWwbroFsyEdWzpA++;
						break;
					}
					if (gZoOFSufLOLaogkWwbroFsyEdWzpA < lBKhrYjEHKqHtDRDZTMGgxJFROdCc)
					{
						rBVkeNMeEEafsCnEvPEDDzFceTJDb = platform_DirectInput_Base.elements.axes[gZoOFSufLOLaogkWwbroFsyEdWzpA];
						LfQebfpduBwhAGlZZGQKFBEhQqZb = 1;
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
					TsvqaNbhSRikKXiQcwioFJFQbwnK tsvqaNbhSRikKXiQcwioFJFQbwnK;
					if (LfQebfpduBwhAGlZZGQKFBEhQqZb == -2 && YGbeWZBNoHbJSuYqaQBltARaDBInA == Environment.CurrentManagedThreadId)
					{
						LfQebfpduBwhAGlZZGQKFBEhQqZb = 0;
						tsvqaNbhSRikKXiQcwioFJFQbwnK = this;
					}
					else
					{
						tsvqaNbhSRikKXiQcwioFJFQbwnK = new TsvqaNbhSRikKXiQcwioFJFQbwnK(0);
						tsvqaNbhSRikKXiQcwioFJFQbwnK.mskdkAyyhlaVxcYUhwZFCZcGPrtC = mskdkAyyhlaVxcYUhwZFCZcGPrtC;
					}
					return tsvqaNbhSRikKXiQcwioFJFQbwnK;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}
			}

			private sealed class wULCjqkPsSwjRDhLCPYwRpzqwCFCA : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int KzZfUBArLvplJXsWdhTDEZLKiClBb;

				private Button_Base FGuVDqEBRjfLuXFZBswrCjLsvUSV;

				private int SnZIgqOSDKGfueeqnxOcXNaPbBlM;

				public Platform_DirectInput_Base aUnmBCylpSbfuQvMUSmRDiVSgnphA;

				private int hnBUpNGOalMVjULqvkEYwvlBRJdE;

				private int zLKpNyEevpwWrWonWuoXFovlgScc;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return FGuVDqEBRjfLuXFZBswrCjLsvUSV;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return FGuVDqEBRjfLuXFZBswrCjLsvUSV;
					}
				}

				[DebuggerHidden]
				public wULCjqkPsSwjRDhLCPYwRpzqwCFCA(int P_0)
				{
					KzZfUBArLvplJXsWdhTDEZLKiClBb = P_0;
					SnZIgqOSDKGfueeqnxOcXNaPbBlM = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int kzZfUBArLvplJXsWdhTDEZLKiClBb = KzZfUBArLvplJXsWdhTDEZLKiClBb;
					Platform_DirectInput_Base platform_DirectInput_Base = aUnmBCylpSbfuQvMUSmRDiVSgnphA;
					switch (kzZfUBArLvplJXsWdhTDEZLKiClBb)
					{
					default:
						return false;
					case 0:
						KzZfUBArLvplJXsWdhTDEZLKiClBb = -1;
						if (platform_DirectInput_Base.elements == null || platform_DirectInput_Base.elements.buttons == null)
						{
							return false;
						}
						hnBUpNGOalMVjULqvkEYwvlBRJdE = platform_DirectInput_Base.elements.buttons.Length;
						zLKpNyEevpwWrWonWuoXFovlgScc = 0;
						break;
					case 1:
						KzZfUBArLvplJXsWdhTDEZLKiClBb = -1;
						zLKpNyEevpwWrWonWuoXFovlgScc++;
						break;
					}
					if (zLKpNyEevpwWrWonWuoXFovlgScc < hnBUpNGOalMVjULqvkEYwvlBRJdE)
					{
						FGuVDqEBRjfLuXFZBswrCjLsvUSV = platform_DirectInput_Base.elements.buttons[zLKpNyEevpwWrWonWuoXFovlgScc];
						KzZfUBArLvplJXsWdhTDEZLKiClBb = 1;
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
					wULCjqkPsSwjRDhLCPYwRpzqwCFCA wULCjqkPsSwjRDhLCPYwRpzqwCFCA2;
					if (KzZfUBArLvplJXsWdhTDEZLKiClBb == -2 && SnZIgqOSDKGfueeqnxOcXNaPbBlM == Environment.CurrentManagedThreadId)
					{
						KzZfUBArLvplJXsWdhTDEZLKiClBb = 0;
						wULCjqkPsSwjRDhLCPYwRpzqwCFCA2 = this;
					}
					else
					{
						wULCjqkPsSwjRDhLCPYwRpzqwCFCA2 = new wULCjqkPsSwjRDhLCPYwRpzqwCFCA(0);
						wULCjqkPsSwjRDhLCPYwRpzqwCFCA2.aUnmBCylpSbfuQvMUSmRDiVSgnphA = aUnmBCylpSbfuQvMUSmRDiVSgnphA;
					}
					return wULCjqkPsSwjRDhLCPYwRpzqwCFCA2;
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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			[IteratorStateMachine(typeof(TsvqaNbhSRikKXiQcwioFJFQbwnK))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return new TsvqaNbhSRikKXiQcwioFJFQbwnK(-2)
				{
					mskdkAyyhlaVxcYUhwZFCZcGPrtC = this
				};
			}

			[IteratorStateMachine(typeof(wULCjqkPsSwjRDhLCPYwRpzqwCFCA))]
			internal override IEnumerable<Button_Base> IterateButtons()
			{
				return new wULCjqkPsSwjRDhLCPYwRpzqwCFCA(-2)
				{
					aUnmBCylpSbfuQvMUSmRDiVSgnphA = this
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

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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
				private sealed class MnarTzxJZyhzwkFcqqeUNELXkLD : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int zhOdfPjmlRnIHokgeUekeFDpiNHN;

					private Axis_Base ykyVBjawMpPluNETVdaqBSLaHFLkA;

					private int CSswxhOkcmhKcfaHpUfmOvoYBgI;

					public Elements sYiQwLyzjkahnoLmZEWdyvksOirV;

					private int oygodmFodyzTiWDYoQfpMLAHjQET;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return ykyVBjawMpPluNETVdaqBSLaHFLkA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ykyVBjawMpPluNETVdaqBSLaHFLkA;
						}
					}

					[DebuggerHidden]
					public MnarTzxJZyhzwkFcqqeUNELXkLD(int P_0)
					{
						zhOdfPjmlRnIHokgeUekeFDpiNHN = P_0;
						CSswxhOkcmhKcfaHpUfmOvoYBgI = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = zhOdfPjmlRnIHokgeUekeFDpiNHN;
						Elements elements = sYiQwLyzjkahnoLmZEWdyvksOirV;
						switch (num)
						{
						default:
							return false;
						case 0:
							zhOdfPjmlRnIHokgeUekeFDpiNHN = -1;
							if (elements.axes == null)
							{
								return false;
							}
							oygodmFodyzTiWDYoQfpMLAHjQET = 0;
							break;
						case 1:
							zhOdfPjmlRnIHokgeUekeFDpiNHN = -1;
							oygodmFodyzTiWDYoQfpMLAHjQET++;
							break;
						}
						if (oygodmFodyzTiWDYoQfpMLAHjQET < elements.axes.Length)
						{
							ykyVBjawMpPluNETVdaqBSLaHFLkA = elements.axes[oygodmFodyzTiWDYoQfpMLAHjQET];
							zhOdfPjmlRnIHokgeUekeFDpiNHN = 1;
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
						MnarTzxJZyhzwkFcqqeUNELXkLD mnarTzxJZyhzwkFcqqeUNELXkLD;
						if (zhOdfPjmlRnIHokgeUekeFDpiNHN == -2 && CSswxhOkcmhKcfaHpUfmOvoYBgI == Environment.CurrentManagedThreadId)
						{
							zhOdfPjmlRnIHokgeUekeFDpiNHN = 0;
							mnarTzxJZyhzwkFcqqeUNELXkLD = this;
						}
						else
						{
							mnarTzxJZyhzwkFcqqeUNELXkLD = new MnarTzxJZyhzwkFcqqeUNELXkLD(0);
							mnarTzxJZyhzwkFcqqeUNELXkLD.sYiQwLyzjkahnoLmZEWdyvksOirV = sYiQwLyzjkahnoLmZEWdyvksOirV;
						}
						return mnarTzxJZyhzwkFcqqeUNELXkLD;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}
				}

				private sealed class lLpNESEtKvNZRApscDqTmuenyGE : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int kxPOoMhjTKynFWonwWmiTMJXGjjDA;

					private Button_Base IlVzmIWCEoEkieQpagVbDmjTqHAPA;

					private int BTNCbZURncVcScyLbOJwhGxexcCs;

					public Elements TvZvaWEgUTZMWiYiXrqyugQtZHDg;

					private int bzaYyFzdDRijSSpdNNennwUkFGvj;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return IlVzmIWCEoEkieQpagVbDmjTqHAPA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return IlVzmIWCEoEkieQpagVbDmjTqHAPA;
						}
					}

					[DebuggerHidden]
					public lLpNESEtKvNZRApscDqTmuenyGE(int P_0)
					{
						kxPOoMhjTKynFWonwWmiTMJXGjjDA = P_0;
						BTNCbZURncVcScyLbOJwhGxexcCs = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = kxPOoMhjTKynFWonwWmiTMJXGjjDA;
						Elements tvZvaWEgUTZMWiYiXrqyugQtZHDg = TvZvaWEgUTZMWiYiXrqyugQtZHDg;
						switch (num)
						{
						default:
							return false;
						case 0:
							kxPOoMhjTKynFWonwWmiTMJXGjjDA = -1;
							if (tvZvaWEgUTZMWiYiXrqyugQtZHDg.buttons == null)
							{
								return false;
							}
							bzaYyFzdDRijSSpdNNennwUkFGvj = 0;
							break;
						case 1:
							kxPOoMhjTKynFWonwWmiTMJXGjjDA = -1;
							bzaYyFzdDRijSSpdNNennwUkFGvj++;
							break;
						}
						if (bzaYyFzdDRijSSpdNNennwUkFGvj < tvZvaWEgUTZMWiYiXrqyugQtZHDg.buttons.Length)
						{
							IlVzmIWCEoEkieQpagVbDmjTqHAPA = tvZvaWEgUTZMWiYiXrqyugQtZHDg.buttons[bzaYyFzdDRijSSpdNNennwUkFGvj];
							kxPOoMhjTKynFWonwWmiTMJXGjjDA = 1;
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
						lLpNESEtKvNZRApscDqTmuenyGE lLpNESEtKvNZRApscDqTmuenyGE2;
						if (kxPOoMhjTKynFWonwWmiTMJXGjjDA == -2 && BTNCbZURncVcScyLbOJwhGxexcCs == Environment.CurrentManagedThreadId)
						{
							kxPOoMhjTKynFWonwWmiTMJXGjjDA = 0;
							lLpNESEtKvNZRApscDqTmuenyGE2 = this;
						}
						else
						{
							lLpNESEtKvNZRApscDqTmuenyGE2 = new lLpNESEtKvNZRApscDqTmuenyGE(0);
							lLpNESEtKvNZRApscDqTmuenyGE2.TvZvaWEgUTZMWiYiXrqyugQtZHDg = TvZvaWEgUTZMWiYiXrqyugQtZHDg;
						}
						return lLpNESEtKvNZRApscDqTmuenyGE2;
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
					[IteratorStateMachine(typeof(MnarTzxJZyhzwkFcqqeUNELXkLD))]
					get
					{
						return new MnarTzxJZyhzwkFcqqeUNELXkLD(-2)
						{
							sYiQwLyzjkahnoLmZEWdyvksOirV = this
						};
					}
				}

				IEnumerable<Button_Base> Elements_Platform_Base.Buttons
				{
					[IteratorStateMachine(typeof(lLpNESEtKvNZRApscDqTmuenyGE))]
					get
					{
						return new lLpNESEtKvNZRApscDqTmuenyGE(-2)
						{
							TvZvaWEgUTZMWiYiXrqyugQtZHDg = this
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

			private sealed class OhmtWisuddlpfLnFkvWmbBFvwBfL : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int KTkiUiVtIXIjseSHydDpTCRGbEiIA;

				private Axis_Base QVHYdsarUkOHRzAsjyfSaNFEPZvf;

				private int GxErRGBCekYpGKMwEZpcMAvKTFOX;

				public Platform_RawInput_Base OTKLKQuaZbBWHjTeMCYEZThNmUsx;

				private int PFKhTpDLWRAVhzYXHbmLXTMptOgy;

				private int bRSTHnvlyMyiGejGURAWJaHNTHVD;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return QVHYdsarUkOHRzAsjyfSaNFEPZvf;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return QVHYdsarUkOHRzAsjyfSaNFEPZvf;
					}
				}

				[DebuggerHidden]
				public OhmtWisuddlpfLnFkvWmbBFvwBfL(int P_0)
				{
					KTkiUiVtIXIjseSHydDpTCRGbEiIA = P_0;
					GxErRGBCekYpGKMwEZpcMAvKTFOX = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int kTkiUiVtIXIjseSHydDpTCRGbEiIA = KTkiUiVtIXIjseSHydDpTCRGbEiIA;
					Platform_RawInput_Base oTKLKQuaZbBWHjTeMCYEZThNmUsx = OTKLKQuaZbBWHjTeMCYEZThNmUsx;
					switch (kTkiUiVtIXIjseSHydDpTCRGbEiIA)
					{
					default:
						return false;
					case 0:
						KTkiUiVtIXIjseSHydDpTCRGbEiIA = -1;
						if (oTKLKQuaZbBWHjTeMCYEZThNmUsx.elements == null || oTKLKQuaZbBWHjTeMCYEZThNmUsx.elements.axes == null)
						{
							return false;
						}
						PFKhTpDLWRAVhzYXHbmLXTMptOgy = oTKLKQuaZbBWHjTeMCYEZThNmUsx.elements.axes.Length;
						bRSTHnvlyMyiGejGURAWJaHNTHVD = 0;
						break;
					case 1:
						KTkiUiVtIXIjseSHydDpTCRGbEiIA = -1;
						bRSTHnvlyMyiGejGURAWJaHNTHVD++;
						break;
					}
					if (bRSTHnvlyMyiGejGURAWJaHNTHVD < PFKhTpDLWRAVhzYXHbmLXTMptOgy)
					{
						QVHYdsarUkOHRzAsjyfSaNFEPZvf = oTKLKQuaZbBWHjTeMCYEZThNmUsx.elements.axes[bRSTHnvlyMyiGejGURAWJaHNTHVD];
						KTkiUiVtIXIjseSHydDpTCRGbEiIA = 1;
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
					OhmtWisuddlpfLnFkvWmbBFvwBfL ohmtWisuddlpfLnFkvWmbBFvwBfL;
					if (KTkiUiVtIXIjseSHydDpTCRGbEiIA == -2 && GxErRGBCekYpGKMwEZpcMAvKTFOX == Environment.CurrentManagedThreadId)
					{
						KTkiUiVtIXIjseSHydDpTCRGbEiIA = 0;
						ohmtWisuddlpfLnFkvWmbBFvwBfL = this;
					}
					else
					{
						ohmtWisuddlpfLnFkvWmbBFvwBfL = new OhmtWisuddlpfLnFkvWmbBFvwBfL(0);
						ohmtWisuddlpfLnFkvWmbBFvwBfL.OTKLKQuaZbBWHjTeMCYEZThNmUsx = OTKLKQuaZbBWHjTeMCYEZThNmUsx;
					}
					return ohmtWisuddlpfLnFkvWmbBFvwBfL;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}
			}

			private sealed class MIsSKrVwqNAmDCjxBSpuojoNeiTfA : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int sQVwcTSKUzwerJzJmXxfDCXBJHIJ;

				private Button_Base IWhUgGotkTGknqjEhiFAHHdHRhzcb;

				private int zcHzxiHNTGVMHbEQfjjIBPuHiUYA;

				public Platform_RawInput_Base uABZWfDISHpthdeOwHAgjVBkhNfk;

				private int HDutTqBDAXgtPGcEqnbaLnAdocQAA;

				private int TNtNmovujcdPrfTwRNvKOTAohQWQ;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return IWhUgGotkTGknqjEhiFAHHdHRhzcb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return IWhUgGotkTGknqjEhiFAHHdHRhzcb;
					}
				}

				[DebuggerHidden]
				public MIsSKrVwqNAmDCjxBSpuojoNeiTfA(int P_0)
				{
					sQVwcTSKUzwerJzJmXxfDCXBJHIJ = P_0;
					zcHzxiHNTGVMHbEQfjjIBPuHiUYA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = sQVwcTSKUzwerJzJmXxfDCXBJHIJ;
					Platform_RawInput_Base platform_RawInput_Base = uABZWfDISHpthdeOwHAgjVBkhNfk;
					switch (num)
					{
					default:
						return false;
					case 0:
						sQVwcTSKUzwerJzJmXxfDCXBJHIJ = -1;
						if (platform_RawInput_Base.elements == null || platform_RawInput_Base.elements.buttons == null)
						{
							return false;
						}
						HDutTqBDAXgtPGcEqnbaLnAdocQAA = platform_RawInput_Base.elements.buttons.Length;
						TNtNmovujcdPrfTwRNvKOTAohQWQ = 0;
						break;
					case 1:
						sQVwcTSKUzwerJzJmXxfDCXBJHIJ = -1;
						TNtNmovujcdPrfTwRNvKOTAohQWQ++;
						break;
					}
					if (TNtNmovujcdPrfTwRNvKOTAohQWQ < HDutTqBDAXgtPGcEqnbaLnAdocQAA)
					{
						IWhUgGotkTGknqjEhiFAHHdHRhzcb = platform_RawInput_Base.elements.buttons[TNtNmovujcdPrfTwRNvKOTAohQWQ];
						sQVwcTSKUzwerJzJmXxfDCXBJHIJ = 1;
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
					MIsSKrVwqNAmDCjxBSpuojoNeiTfA mIsSKrVwqNAmDCjxBSpuojoNeiTfA;
					if (sQVwcTSKUzwerJzJmXxfDCXBJHIJ == -2 && zcHzxiHNTGVMHbEQfjjIBPuHiUYA == Environment.CurrentManagedThreadId)
					{
						sQVwcTSKUzwerJzJmXxfDCXBJHIJ = 0;
						mIsSKrVwqNAmDCjxBSpuojoNeiTfA = this;
					}
					else
					{
						mIsSKrVwqNAmDCjxBSpuojoNeiTfA = new MIsSKrVwqNAmDCjxBSpuojoNeiTfA(0);
						mIsSKrVwqNAmDCjxBSpuojoNeiTfA.uABZWfDISHpthdeOwHAgjVBkhNfk = uABZWfDISHpthdeOwHAgjVBkhNfk;
					}
					return mIsSKrVwqNAmDCjxBSpuojoNeiTfA;
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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			[IteratorStateMachine(typeof(OhmtWisuddlpfLnFkvWmbBFvwBfL))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return new OhmtWisuddlpfLnFkvWmbBFvwBfL(-2)
				{
					OTKLKQuaZbBWHjTeMCYEZThNmUsx = this
				};
			}

			[IteratorStateMachine(typeof(MIsSKrVwqNAmDCjxBSpuojoNeiTfA))]
			internal override IEnumerable<Button_Base> IterateButtons()
			{
				return new MIsSKrVwqNAmDCjxBSpuojoNeiTfA(-2)
				{
					uABZWfDISHpthdeOwHAgjVBkhNfk = this
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

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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

			private sealed class xwtzrFWZHePuMObmXCbobCwPoNdIb : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int REGiVTPnvxPUTPXEtaDqtUMrPRpM;

				private Axis BvyNoyKCakiqzdNghKIpfEjCnbGDc;

				private int wdSAWLAWSBlRalacTxdnMSJUslmc;

				public Platform_XInput_Base ExrBLyYHKyvGIQyyANemJFgotNJx;

				private int oDUdTUWrTUZmCFsoAFxrjsNgecjDA;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return BvyNoyKCakiqzdNghKIpfEjCnbGDc;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return BvyNoyKCakiqzdNghKIpfEjCnbGDc;
					}
				}

				[DebuggerHidden]
				public xwtzrFWZHePuMObmXCbobCwPoNdIb(int P_0)
				{
					REGiVTPnvxPUTPXEtaDqtUMrPRpM = P_0;
					wdSAWLAWSBlRalacTxdnMSJUslmc = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int rEGiVTPnvxPUTPXEtaDqtUMrPRpM = REGiVTPnvxPUTPXEtaDqtUMrPRpM;
					Platform_XInput_Base exrBLyYHKyvGIQyyANemJFgotNJx = ExrBLyYHKyvGIQyyANemJFgotNJx;
					switch (rEGiVTPnvxPUTPXEtaDqtUMrPRpM)
					{
					default:
						return false;
					case 0:
						REGiVTPnvxPUTPXEtaDqtUMrPRpM = -1;
						if (exrBLyYHKyvGIQyyANemJFgotNJx.elements == null || exrBLyYHKyvGIQyyANemJFgotNJx.elements.axes == null)
						{
							return false;
						}
						oDUdTUWrTUZmCFsoAFxrjsNgecjDA = 0;
						break;
					case 1:
						REGiVTPnvxPUTPXEtaDqtUMrPRpM = -1;
						oDUdTUWrTUZmCFsoAFxrjsNgecjDA++;
						break;
					}
					if (oDUdTUWrTUZmCFsoAFxrjsNgecjDA < exrBLyYHKyvGIQyyANemJFgotNJx.elements.axes.Length)
					{
						BvyNoyKCakiqzdNghKIpfEjCnbGDc = exrBLyYHKyvGIQyyANemJFgotNJx.elements.axes[oDUdTUWrTUZmCFsoAFxrjsNgecjDA];
						REGiVTPnvxPUTPXEtaDqtUMrPRpM = 1;
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
					xwtzrFWZHePuMObmXCbobCwPoNdIb xwtzrFWZHePuMObmXCbobCwPoNdIb2;
					if (REGiVTPnvxPUTPXEtaDqtUMrPRpM == -2 && wdSAWLAWSBlRalacTxdnMSJUslmc == Environment.CurrentManagedThreadId)
					{
						REGiVTPnvxPUTPXEtaDqtUMrPRpM = 0;
						xwtzrFWZHePuMObmXCbobCwPoNdIb2 = this;
					}
					else
					{
						xwtzrFWZHePuMObmXCbobCwPoNdIb2 = new xwtzrFWZHePuMObmXCbobCwPoNdIb(0);
						xwtzrFWZHePuMObmXCbobCwPoNdIb2.ExrBLyYHKyvGIQyyANemJFgotNJx = ExrBLyYHKyvGIQyyANemJFgotNJx;
					}
					return xwtzrFWZHePuMObmXCbobCwPoNdIb2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class JhStMZqlJaclSdtRWWnVaroTWmUqA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int RBJXUfZpaaIREatxntJNhhgeMcNxA;

				private Button IyQWudaPahkqUOcdGRhgIqkeifmR;

				private int PwiPAfeIFnbxdlHeweDvCkBoiUcsA;

				public Platform_XInput_Base HMEJctMaWshstbazJyxIudsDYmTK;

				private int EnkVtqtfZWKfJKZtRMwXftBQjcmC;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return IyQWudaPahkqUOcdGRhgIqkeifmR;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return IyQWudaPahkqUOcdGRhgIqkeifmR;
					}
				}

				[DebuggerHidden]
				public JhStMZqlJaclSdtRWWnVaroTWmUqA(int P_0)
				{
					RBJXUfZpaaIREatxntJNhhgeMcNxA = P_0;
					PwiPAfeIFnbxdlHeweDvCkBoiUcsA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int rBJXUfZpaaIREatxntJNhhgeMcNxA = RBJXUfZpaaIREatxntJNhhgeMcNxA;
					Platform_XInput_Base hMEJctMaWshstbazJyxIudsDYmTK = HMEJctMaWshstbazJyxIudsDYmTK;
					switch (rBJXUfZpaaIREatxntJNhhgeMcNxA)
					{
					default:
						return false;
					case 0:
						RBJXUfZpaaIREatxntJNhhgeMcNxA = -1;
						if (hMEJctMaWshstbazJyxIudsDYmTK.elements == null || hMEJctMaWshstbazJyxIudsDYmTK.elements.buttons == null)
						{
							return false;
						}
						EnkVtqtfZWKfJKZtRMwXftBQjcmC = 0;
						break;
					case 1:
						RBJXUfZpaaIREatxntJNhhgeMcNxA = -1;
						EnkVtqtfZWKfJKZtRMwXftBQjcmC++;
						break;
					}
					if (EnkVtqtfZWKfJKZtRMwXftBQjcmC < hMEJctMaWshstbazJyxIudsDYmTK.elements.buttons.Length)
					{
						IyQWudaPahkqUOcdGRhgIqkeifmR = hMEJctMaWshstbazJyxIudsDYmTK.elements.buttons[EnkVtqtfZWKfJKZtRMwXftBQjcmC];
						RBJXUfZpaaIREatxntJNhhgeMcNxA = 1;
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
					JhStMZqlJaclSdtRWWnVaroTWmUqA jhStMZqlJaclSdtRWWnVaroTWmUqA;
					if (RBJXUfZpaaIREatxntJNhhgeMcNxA == -2 && PwiPAfeIFnbxdlHeweDvCkBoiUcsA == Environment.CurrentManagedThreadId)
					{
						RBJXUfZpaaIREatxntJNhhgeMcNxA = 0;
						jhStMZqlJaclSdtRWWnVaroTWmUqA = this;
					}
					else
					{
						jhStMZqlJaclSdtRWWnVaroTWmUqA = new JhStMZqlJaclSdtRWWnVaroTWmUqA(0);
						jhStMZqlJaclSdtRWWnVaroTWmUqA.HMEJctMaWshstbazJyxIudsDYmTK = HMEJctMaWshstbazJyxIudsDYmTK;
					}
					return jhStMZqlJaclSdtRWWnVaroTWmUqA;
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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			[IteratorStateMachine(typeof(xwtzrFWZHePuMObmXCbobCwPoNdIb))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new xwtzrFWZHePuMObmXCbobCwPoNdIb(-2)
				{
					ExrBLyYHKyvGIQyyANemJFgotNJx = this
				};
			}

			[IteratorStateMachine(typeof(JhStMZqlJaclSdtRWWnVaroTWmUqA))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new JhStMZqlJaclSdtRWWnVaroTWmUqA(-2)
				{
					HMEJctMaWshstbazJyxIudsDYmTK = this
				};
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

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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
						jxcSgBCAckNrIjPsBFiAMTdHLFuQ(elementCount);
						return elementCount;
					}

					internal void bepNtSRwBYhkKHYypAWnebjBpEBQ(ElementCount_Base P_0)
					{
						base.jxcSgBCAckNrIjPsBFiAMTdHLFuQ(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool NSJbkoBfTSmXIwRbTNlaeuUdZjzN(BridgedControllerHWInfo P_0)
					{
						if (!base.KhdgjMQnSkGAvAuHpiccCSGlQcYsA(P_0))
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
				private sealed class CPBQBDkVYBbBoEUIjfbfXanQzheq : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int mtzUowxuHPQOXZNyiJeuuPPLCYbP;

					private Axis dVTIChKKSfSDPnlTJTpfJPydHcuH;

					private int kythSreMgdWENFsugPiBxZezgBmj;

					public Elements GcWvwdjiGVMtBIoTnVPKDAEpyREU;

					private Axis[] vQPzhFqeMuXBziKpDXoEHgYtGSsCA;

					private int mgjdeKcDFuSIPjSUDfyEqHKhwyBOE;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return dVTIChKKSfSDPnlTJTpfJPydHcuH;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return dVTIChKKSfSDPnlTJTpfJPydHcuH;
						}
					}

					[DebuggerHidden]
					public CPBQBDkVYBbBoEUIjfbfXanQzheq(int P_0)
					{
						mtzUowxuHPQOXZNyiJeuuPPLCYbP = P_0;
						kythSreMgdWENFsugPiBxZezgBmj = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = mtzUowxuHPQOXZNyiJeuuPPLCYbP;
						Elements gcWvwdjiGVMtBIoTnVPKDAEpyREU = GcWvwdjiGVMtBIoTnVPKDAEpyREU;
						switch (num)
						{
						default:
							return false;
						case 0:
							mtzUowxuHPQOXZNyiJeuuPPLCYbP = -1;
							if (gcWvwdjiGVMtBIoTnVPKDAEpyREU.axes == null)
							{
								return false;
							}
							vQPzhFqeMuXBziKpDXoEHgYtGSsCA = gcWvwdjiGVMtBIoTnVPKDAEpyREU.axes;
							mgjdeKcDFuSIPjSUDfyEqHKhwyBOE = 0;
							break;
						case 1:
							mtzUowxuHPQOXZNyiJeuuPPLCYbP = -1;
							mgjdeKcDFuSIPjSUDfyEqHKhwyBOE++;
							break;
						}
						if (mgjdeKcDFuSIPjSUDfyEqHKhwyBOE < vQPzhFqeMuXBziKpDXoEHgYtGSsCA.Length)
						{
							Axis axis = vQPzhFqeMuXBziKpDXoEHgYtGSsCA[mgjdeKcDFuSIPjSUDfyEqHKhwyBOE];
							dVTIChKKSfSDPnlTJTpfJPydHcuH = axis;
							mtzUowxuHPQOXZNyiJeuuPPLCYbP = 1;
							return true;
						}
						vQPzhFqeMuXBziKpDXoEHgYtGSsCA = null;
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
						CPBQBDkVYBbBoEUIjfbfXanQzheq cPBQBDkVYBbBoEUIjfbfXanQzheq;
						if (mtzUowxuHPQOXZNyiJeuuPPLCYbP == -2 && kythSreMgdWENFsugPiBxZezgBmj == Environment.CurrentManagedThreadId)
						{
							mtzUowxuHPQOXZNyiJeuuPPLCYbP = 0;
							cPBQBDkVYBbBoEUIjfbfXanQzheq = this;
						}
						else
						{
							cPBQBDkVYBbBoEUIjfbfXanQzheq = new CPBQBDkVYBbBoEUIjfbfXanQzheq(0);
							cPBQBDkVYBbBoEUIjfbfXanQzheq.GcWvwdjiGVMtBIoTnVPKDAEpyREU = GcWvwdjiGVMtBIoTnVPKDAEpyREU;
						}
						return cPBQBDkVYBbBoEUIjfbfXanQzheq;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class pVZSxKxggcEXDVrXkbvJHtZhayMb : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int yfrYPeMSWWAVQBsgIUALXIvvFOUS;

					private Button BhihjKEMAdMsuNKaMUcRzMOfDEBc;

					private int sQECvSeQkPzXvCJxJGToATduYIxnA;

					public Elements rTATfjfBHdivthLeiMPPxlyYnUMk;

					private Button[] CeDcQovdNRfrhQaimugzrjiENDrh;

					private int lSSMjkwZUthnLDcGuuLYVnGvMXsP;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return BhihjKEMAdMsuNKaMUcRzMOfDEBc;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return BhihjKEMAdMsuNKaMUcRzMOfDEBc;
						}
					}

					[DebuggerHidden]
					public pVZSxKxggcEXDVrXkbvJHtZhayMb(int P_0)
					{
						yfrYPeMSWWAVQBsgIUALXIvvFOUS = P_0;
						sQECvSeQkPzXvCJxJGToATduYIxnA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = yfrYPeMSWWAVQBsgIUALXIvvFOUS;
						Elements elements = rTATfjfBHdivthLeiMPPxlyYnUMk;
						switch (num)
						{
						default:
							return false;
						case 0:
							yfrYPeMSWWAVQBsgIUALXIvvFOUS = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							CeDcQovdNRfrhQaimugzrjiENDrh = elements.buttons;
							lSSMjkwZUthnLDcGuuLYVnGvMXsP = 0;
							break;
						case 1:
							yfrYPeMSWWAVQBsgIUALXIvvFOUS = -1;
							lSSMjkwZUthnLDcGuuLYVnGvMXsP++;
							break;
						}
						if (lSSMjkwZUthnLDcGuuLYVnGvMXsP < CeDcQovdNRfrhQaimugzrjiENDrh.Length)
						{
							Button bhihjKEMAdMsuNKaMUcRzMOfDEBc = CeDcQovdNRfrhQaimugzrjiENDrh[lSSMjkwZUthnLDcGuuLYVnGvMXsP];
							BhihjKEMAdMsuNKaMUcRzMOfDEBc = bhihjKEMAdMsuNKaMUcRzMOfDEBc;
							yfrYPeMSWWAVQBsgIUALXIvvFOUS = 1;
							return true;
						}
						CeDcQovdNRfrhQaimugzrjiENDrh = null;
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
						pVZSxKxggcEXDVrXkbvJHtZhayMb pVZSxKxggcEXDVrXkbvJHtZhayMb2;
						if (yfrYPeMSWWAVQBsgIUALXIvvFOUS == -2 && sQECvSeQkPzXvCJxJGToATduYIxnA == Environment.CurrentManagedThreadId)
						{
							yfrYPeMSWWAVQBsgIUALXIvvFOUS = 0;
							pVZSxKxggcEXDVrXkbvJHtZhayMb2 = this;
						}
						else
						{
							pVZSxKxggcEXDVrXkbvJHtZhayMb2 = new pVZSxKxggcEXDVrXkbvJHtZhayMb(0);
							pVZSxKxggcEXDVrXkbvJHtZhayMb2.rTATfjfBHdivthLeiMPPxlyYnUMk = rTATfjfBHdivthLeiMPPxlyYnUMk;
						}
						return pVZSxKxggcEXDVrXkbvJHtZhayMb2;
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

				[IteratorStateMachine(typeof(CPBQBDkVYBbBoEUIjfbfXanQzheq))]
				public IEnumerable<Axis> IterateAxes()
				{
					return new CPBQBDkVYBbBoEUIjfbfXanQzheq(-2)
					{
						GcWvwdjiGVMtBIoTnVPKDAEpyREU = this
					};
				}

				[IteratorStateMachine(typeof(pVZSxKxggcEXDVrXkbvJHtZhayMb))]
				public IEnumerable<Button> IterateButtons()
				{
					return new pVZSxKxggcEXDVrXkbvJHtZhayMb(-2)
					{
						rTATfjfBHdivthLeiMPPxlyYnUMk = this
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

			private sealed class cfDonNACOHApZxKMzgpHBNWDOaSm : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int nRwfhuByLyCyvxMDmBfdqWHGElfe;

				private Axis TEPFHGdVKneRaVyKAROnBELBFynbb;

				private int gCAdwwYVJHBSWRKvTfRcgszorJKOA;

				public Platform_OSX_Base NffjSCaGYYDdSKxIWCbhKAFjxMNN;

				private int TdeCgRGXDVehkIaRmmSfCzHMlTLpA;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return TEPFHGdVKneRaVyKAROnBELBFynbb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return TEPFHGdVKneRaVyKAROnBELBFynbb;
					}
				}

				[DebuggerHidden]
				public cfDonNACOHApZxKMzgpHBNWDOaSm(int P_0)
				{
					nRwfhuByLyCyvxMDmBfdqWHGElfe = P_0;
					gCAdwwYVJHBSWRKvTfRcgszorJKOA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = nRwfhuByLyCyvxMDmBfdqWHGElfe;
					Platform_OSX_Base nffjSCaGYYDdSKxIWCbhKAFjxMNN = NffjSCaGYYDdSKxIWCbhKAFjxMNN;
					switch (num)
					{
					default:
						return false;
					case 0:
						nRwfhuByLyCyvxMDmBfdqWHGElfe = -1;
						if (nffjSCaGYYDdSKxIWCbhKAFjxMNN.elements == null || nffjSCaGYYDdSKxIWCbhKAFjxMNN.elements.axes == null)
						{
							return false;
						}
						TdeCgRGXDVehkIaRmmSfCzHMlTLpA = 0;
						break;
					case 1:
						nRwfhuByLyCyvxMDmBfdqWHGElfe = -1;
						TdeCgRGXDVehkIaRmmSfCzHMlTLpA++;
						break;
					}
					if (TdeCgRGXDVehkIaRmmSfCzHMlTLpA < nffjSCaGYYDdSKxIWCbhKAFjxMNN.elements.axes.Length)
					{
						TEPFHGdVKneRaVyKAROnBELBFynbb = nffjSCaGYYDdSKxIWCbhKAFjxMNN.elements.axes[TdeCgRGXDVehkIaRmmSfCzHMlTLpA];
						nRwfhuByLyCyvxMDmBfdqWHGElfe = 1;
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
					cfDonNACOHApZxKMzgpHBNWDOaSm cfDonNACOHApZxKMzgpHBNWDOaSm2;
					if (nRwfhuByLyCyvxMDmBfdqWHGElfe == -2 && gCAdwwYVJHBSWRKvTfRcgszorJKOA == Environment.CurrentManagedThreadId)
					{
						nRwfhuByLyCyvxMDmBfdqWHGElfe = 0;
						cfDonNACOHApZxKMzgpHBNWDOaSm2 = this;
					}
					else
					{
						cfDonNACOHApZxKMzgpHBNWDOaSm2 = new cfDonNACOHApZxKMzgpHBNWDOaSm(0);
						cfDonNACOHApZxKMzgpHBNWDOaSm2.NffjSCaGYYDdSKxIWCbhKAFjxMNN = NffjSCaGYYDdSKxIWCbhKAFjxMNN;
					}
					return cfDonNACOHApZxKMzgpHBNWDOaSm2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class wfCsaMFnegtkWtwUIDnDGnmIsCEO : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int CmKKykdvEmpiaaFPwlAkkXvpgBGt;

				private Button zAfGItfMAUVaaqhPgZwIJzBbeBKAA;

				private int JMQqxRLyeBSLyInjWjukBQmvNaphA;

				public Platform_OSX_Base wbUZdXTEdQBEpFzYKIhXjrvidlNDA;

				private int WmqFQbfftSTuscJWCPURdiqgyueZb;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return zAfGItfMAUVaaqhPgZwIJzBbeBKAA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return zAfGItfMAUVaaqhPgZwIJzBbeBKAA;
					}
				}

				[DebuggerHidden]
				public wfCsaMFnegtkWtwUIDnDGnmIsCEO(int P_0)
				{
					CmKKykdvEmpiaaFPwlAkkXvpgBGt = P_0;
					JMQqxRLyeBSLyInjWjukBQmvNaphA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int cmKKykdvEmpiaaFPwlAkkXvpgBGt = CmKKykdvEmpiaaFPwlAkkXvpgBGt;
					Platform_OSX_Base platform_OSX_Base = wbUZdXTEdQBEpFzYKIhXjrvidlNDA;
					switch (cmKKykdvEmpiaaFPwlAkkXvpgBGt)
					{
					default:
						return false;
					case 0:
						CmKKykdvEmpiaaFPwlAkkXvpgBGt = -1;
						if (platform_OSX_Base.elements == null || platform_OSX_Base.elements.buttons == null)
						{
							return false;
						}
						WmqFQbfftSTuscJWCPURdiqgyueZb = 0;
						break;
					case 1:
						CmKKykdvEmpiaaFPwlAkkXvpgBGt = -1;
						WmqFQbfftSTuscJWCPURdiqgyueZb++;
						break;
					}
					if (WmqFQbfftSTuscJWCPURdiqgyueZb < platform_OSX_Base.elements.buttons.Length)
					{
						zAfGItfMAUVaaqhPgZwIJzBbeBKAA = platform_OSX_Base.elements.buttons[WmqFQbfftSTuscJWCPURdiqgyueZb];
						CmKKykdvEmpiaaFPwlAkkXvpgBGt = 1;
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
					wfCsaMFnegtkWtwUIDnDGnmIsCEO wfCsaMFnegtkWtwUIDnDGnmIsCEO2;
					if (CmKKykdvEmpiaaFPwlAkkXvpgBGt == -2 && JMQqxRLyeBSLyInjWjukBQmvNaphA == Environment.CurrentManagedThreadId)
					{
						CmKKykdvEmpiaaFPwlAkkXvpgBGt = 0;
						wfCsaMFnegtkWtwUIDnDGnmIsCEO2 = this;
					}
					else
					{
						wfCsaMFnegtkWtwUIDnDGnmIsCEO2 = new wfCsaMFnegtkWtwUIDnDGnmIsCEO(0);
						wfCsaMFnegtkWtwUIDnDGnmIsCEO2.wbUZdXTEdQBEpFzYKIhXjrvidlNDA = wbUZdXTEdQBEpFzYKIhXjrvidlNDA;
					}
					return wfCsaMFnegtkWtwUIDnDGnmIsCEO2;
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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			[IteratorStateMachine(typeof(cfDonNACOHApZxKMzgpHBNWDOaSm))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new cfDonNACOHApZxKMzgpHBNWDOaSm(-2)
				{
					NffjSCaGYYDdSKxIWCbhKAFjxMNN = this
				};
			}

			[IteratorStateMachine(typeof(wfCsaMFnegtkWtwUIDnDGnmIsCEO))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new wfCsaMFnegtkWtwUIDnDGnmIsCEO(-2)
				{
					wbUZdXTEdQBEpFzYKIhXjrvidlNDA = this
				};
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

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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
						jxcSgBCAckNrIjPsBFiAMTdHLFuQ(elementCount);
						return elementCount;
					}

					internal void IjbxGScnbBsOwGaJLKJIzBkwBzsJ(ElementCount_Base P_0)
					{
						base.jxcSgBCAckNrIjPsBFiAMTdHLFuQ(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool EHfNSTFssGxKfpcpsmfqJeDPBuji(BridgedControllerHWInfo P_0)
					{
						if (!base.KhdgjMQnSkGAvAuHpiccCSGlQcYsA(P_0))
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
				private sealed class OmbyomwVeeIdhFhPqkfFaMzlLCZc : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int KYnFuNMsPFIlnwfalAgkbORUoAQCA;

					private Axis YBfqmzMUWSxSdfoqGbxuLyoWesDc;

					private int sCtkesVKZwJbKJCWtYpfXBOBuyZe;

					public Elements JSoOyIqoHeLMtwnuGlVyLJnwLMUV;

					private int jscVHBGQPvmkQYtBjLNgxifKfLRv;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return YBfqmzMUWSxSdfoqGbxuLyoWesDc;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return YBfqmzMUWSxSdfoqGbxuLyoWesDc;
						}
					}

					[DebuggerHidden]
					public OmbyomwVeeIdhFhPqkfFaMzlLCZc(int P_0)
					{
						KYnFuNMsPFIlnwfalAgkbORUoAQCA = P_0;
						sCtkesVKZwJbKJCWtYpfXBOBuyZe = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int kYnFuNMsPFIlnwfalAgkbORUoAQCA = KYnFuNMsPFIlnwfalAgkbORUoAQCA;
						Elements jSoOyIqoHeLMtwnuGlVyLJnwLMUV = JSoOyIqoHeLMtwnuGlVyLJnwLMUV;
						switch (kYnFuNMsPFIlnwfalAgkbORUoAQCA)
						{
						default:
							return false;
						case 0:
							KYnFuNMsPFIlnwfalAgkbORUoAQCA = -1;
							if (jSoOyIqoHeLMtwnuGlVyLJnwLMUV.axes == null)
							{
								return false;
							}
							jscVHBGQPvmkQYtBjLNgxifKfLRv = 0;
							break;
						case 1:
							KYnFuNMsPFIlnwfalAgkbORUoAQCA = -1;
							jscVHBGQPvmkQYtBjLNgxifKfLRv++;
							break;
						}
						if (jscVHBGQPvmkQYtBjLNgxifKfLRv < jSoOyIqoHeLMtwnuGlVyLJnwLMUV.axes.Length)
						{
							YBfqmzMUWSxSdfoqGbxuLyoWesDc = jSoOyIqoHeLMtwnuGlVyLJnwLMUV.axes[jscVHBGQPvmkQYtBjLNgxifKfLRv];
							KYnFuNMsPFIlnwfalAgkbORUoAQCA = 1;
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
						OmbyomwVeeIdhFhPqkfFaMzlLCZc ombyomwVeeIdhFhPqkfFaMzlLCZc;
						if (KYnFuNMsPFIlnwfalAgkbORUoAQCA == -2 && sCtkesVKZwJbKJCWtYpfXBOBuyZe == Environment.CurrentManagedThreadId)
						{
							KYnFuNMsPFIlnwfalAgkbORUoAQCA = 0;
							ombyomwVeeIdhFhPqkfFaMzlLCZc = this;
						}
						else
						{
							ombyomwVeeIdhFhPqkfFaMzlLCZc = new OmbyomwVeeIdhFhPqkfFaMzlLCZc(0);
							ombyomwVeeIdhFhPqkfFaMzlLCZc.JSoOyIqoHeLMtwnuGlVyLJnwLMUV = JSoOyIqoHeLMtwnuGlVyLJnwLMUV;
						}
						return ombyomwVeeIdhFhPqkfFaMzlLCZc;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class jSGbOeikKdjNciPrJJxnjLuuiZwEb : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int VRWSZEMccYZSsXveNElfypbpJveM;

					private Button eFgUMNGvfGhmmESyEZolgTAfZVFe;

					private int KFDXPeCBCLSDFsHaxZcBiFifnDWC;

					public Elements iKQlhPHDPdSiCwADMsNarrejffDkA;

					private int ApzAKxeAaQIiniEXfUkfxaLzPzOU;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return eFgUMNGvfGhmmESyEZolgTAfZVFe;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return eFgUMNGvfGhmmESyEZolgTAfZVFe;
						}
					}

					[DebuggerHidden]
					public jSGbOeikKdjNciPrJJxnjLuuiZwEb(int P_0)
					{
						VRWSZEMccYZSsXveNElfypbpJveM = P_0;
						KFDXPeCBCLSDFsHaxZcBiFifnDWC = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int vRWSZEMccYZSsXveNElfypbpJveM = VRWSZEMccYZSsXveNElfypbpJveM;
						Elements elements = iKQlhPHDPdSiCwADMsNarrejffDkA;
						switch (vRWSZEMccYZSsXveNElfypbpJveM)
						{
						default:
							return false;
						case 0:
							VRWSZEMccYZSsXveNElfypbpJveM = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							ApzAKxeAaQIiniEXfUkfxaLzPzOU = 0;
							break;
						case 1:
							VRWSZEMccYZSsXveNElfypbpJveM = -1;
							ApzAKxeAaQIiniEXfUkfxaLzPzOU++;
							break;
						}
						if (ApzAKxeAaQIiniEXfUkfxaLzPzOU < elements.buttons.Length)
						{
							eFgUMNGvfGhmmESyEZolgTAfZVFe = elements.buttons[ApzAKxeAaQIiniEXfUkfxaLzPzOU];
							VRWSZEMccYZSsXveNElfypbpJveM = 1;
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
						jSGbOeikKdjNciPrJJxnjLuuiZwEb jSGbOeikKdjNciPrJJxnjLuuiZwEb2;
						if (VRWSZEMccYZSsXveNElfypbpJveM == -2 && KFDXPeCBCLSDFsHaxZcBiFifnDWC == Environment.CurrentManagedThreadId)
						{
							VRWSZEMccYZSsXveNElfypbpJveM = 0;
							jSGbOeikKdjNciPrJJxnjLuuiZwEb2 = this;
						}
						else
						{
							jSGbOeikKdjNciPrJJxnjLuuiZwEb2 = new jSGbOeikKdjNciPrJJxnjLuuiZwEb(0);
							jSGbOeikKdjNciPrJJxnjLuuiZwEb2.iKQlhPHDPdSiCwADMsNarrejffDkA = iKQlhPHDPdSiCwADMsNarrejffDkA;
						}
						return jSGbOeikKdjNciPrJJxnjLuuiZwEb2;
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
					[IteratorStateMachine(typeof(OmbyomwVeeIdhFhPqkfFaMzlLCZc))]
					get
					{
						return new OmbyomwVeeIdhFhPqkfFaMzlLCZc(-2)
						{
							JSoOyIqoHeLMtwnuGlVyLJnwLMUV = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(jSGbOeikKdjNciPrJJxnjLuuiZwEb))]
					get
					{
						return new jSGbOeikKdjNciPrJJxnjLuuiZwEb(-2)
						{
							iKQlhPHDPdSiCwADMsNarrejffDkA = this
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

			private sealed class PaDfnxIgVcuydLHpVHulVPNoszrH : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int crdMwKBdvotRUdDUMiMnWbknxHLB;

				private Axis KrFlwAlhQCPeFIjqTfrcbexKUeOMA;

				private int fPadVNDaXMqvNZlzpXGeHuEzDTiF;

				public Platform_Linux_Base alKgDyOuIpdubfkybFdWjkHheXHab;

				private int qdZFAPcJHQxlkRLBCPVlfMedcpFCB;

				private int yCZhSUgEKUNPGiZhdKTlrAwfncfE;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return KrFlwAlhQCPeFIjqTfrcbexKUeOMA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return KrFlwAlhQCPeFIjqTfrcbexKUeOMA;
					}
				}

				[DebuggerHidden]
				public PaDfnxIgVcuydLHpVHulVPNoszrH(int P_0)
				{
					crdMwKBdvotRUdDUMiMnWbknxHLB = P_0;
					fPadVNDaXMqvNZlzpXGeHuEzDTiF = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = crdMwKBdvotRUdDUMiMnWbknxHLB;
					Platform_Linux_Base platform_Linux_Base = alKgDyOuIpdubfkybFdWjkHheXHab;
					switch (num)
					{
					default:
						return false;
					case 0:
						crdMwKBdvotRUdDUMiMnWbknxHLB = -1;
						if (platform_Linux_Base.elements == null || platform_Linux_Base.elements.axes == null)
						{
							return false;
						}
						qdZFAPcJHQxlkRLBCPVlfMedcpFCB = platform_Linux_Base.elements.axes.Length;
						yCZhSUgEKUNPGiZhdKTlrAwfncfE = 0;
						break;
					case 1:
						crdMwKBdvotRUdDUMiMnWbknxHLB = -1;
						yCZhSUgEKUNPGiZhdKTlrAwfncfE++;
						break;
					}
					if (yCZhSUgEKUNPGiZhdKTlrAwfncfE < qdZFAPcJHQxlkRLBCPVlfMedcpFCB)
					{
						KrFlwAlhQCPeFIjqTfrcbexKUeOMA = platform_Linux_Base.elements.axes[yCZhSUgEKUNPGiZhdKTlrAwfncfE];
						crdMwKBdvotRUdDUMiMnWbknxHLB = 1;
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
					PaDfnxIgVcuydLHpVHulVPNoszrH paDfnxIgVcuydLHpVHulVPNoszrH;
					if (crdMwKBdvotRUdDUMiMnWbknxHLB == -2 && fPadVNDaXMqvNZlzpXGeHuEzDTiF == Environment.CurrentManagedThreadId)
					{
						crdMwKBdvotRUdDUMiMnWbknxHLB = 0;
						paDfnxIgVcuydLHpVHulVPNoszrH = this;
					}
					else
					{
						paDfnxIgVcuydLHpVHulVPNoszrH = new PaDfnxIgVcuydLHpVHulVPNoszrH(0);
						paDfnxIgVcuydLHpVHulVPNoszrH.alKgDyOuIpdubfkybFdWjkHheXHab = alKgDyOuIpdubfkybFdWjkHheXHab;
					}
					return paDfnxIgVcuydLHpVHulVPNoszrH;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class RzWocjfwlsiWOoWzPNTvnZBgqTeD : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int lNxrBVIFoONGfgYsFKBuZYXCmvnn;

				private Button hRvsioYKbqhkjiJKDAGWJrdFgsof;

				private int ajLsGxqaQbCQzhnvikNNVBUCanwU;

				public Platform_Linux_Base BCNLKUgSBAaPthAMERfAhpoVszWD;

				private int PxODTLjGMytBzqrCSinLnuoGqAzgA;

				private int QsJLoYOGwEASvaEtGAIVFneDYUiwB;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return hRvsioYKbqhkjiJKDAGWJrdFgsof;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return hRvsioYKbqhkjiJKDAGWJrdFgsof;
					}
				}

				[DebuggerHidden]
				public RzWocjfwlsiWOoWzPNTvnZBgqTeD(int P_0)
				{
					lNxrBVIFoONGfgYsFKBuZYXCmvnn = P_0;
					ajLsGxqaQbCQzhnvikNNVBUCanwU = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = lNxrBVIFoONGfgYsFKBuZYXCmvnn;
					Platform_Linux_Base bCNLKUgSBAaPthAMERfAhpoVszWD = BCNLKUgSBAaPthAMERfAhpoVszWD;
					switch (num)
					{
					default:
						return false;
					case 0:
						lNxrBVIFoONGfgYsFKBuZYXCmvnn = -1;
						if (bCNLKUgSBAaPthAMERfAhpoVszWD.elements == null || bCNLKUgSBAaPthAMERfAhpoVszWD.elements.buttons == null)
						{
							return false;
						}
						PxODTLjGMytBzqrCSinLnuoGqAzgA = bCNLKUgSBAaPthAMERfAhpoVszWD.elements.buttons.Length;
						QsJLoYOGwEASvaEtGAIVFneDYUiwB = 0;
						break;
					case 1:
						lNxrBVIFoONGfgYsFKBuZYXCmvnn = -1;
						QsJLoYOGwEASvaEtGAIVFneDYUiwB++;
						break;
					}
					if (QsJLoYOGwEASvaEtGAIVFneDYUiwB < PxODTLjGMytBzqrCSinLnuoGqAzgA)
					{
						hRvsioYKbqhkjiJKDAGWJrdFgsof = bCNLKUgSBAaPthAMERfAhpoVszWD.elements.buttons[QsJLoYOGwEASvaEtGAIVFneDYUiwB];
						lNxrBVIFoONGfgYsFKBuZYXCmvnn = 1;
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
					RzWocjfwlsiWOoWzPNTvnZBgqTeD rzWocjfwlsiWOoWzPNTvnZBgqTeD;
					if (lNxrBVIFoONGfgYsFKBuZYXCmvnn == -2 && ajLsGxqaQbCQzhnvikNNVBUCanwU == Environment.CurrentManagedThreadId)
					{
						lNxrBVIFoONGfgYsFKBuZYXCmvnn = 0;
						rzWocjfwlsiWOoWzPNTvnZBgqTeD = this;
					}
					else
					{
						rzWocjfwlsiWOoWzPNTvnZBgqTeD = new RzWocjfwlsiWOoWzPNTvnZBgqTeD(0);
						rzWocjfwlsiWOoWzPNTvnZBgqTeD.BCNLKUgSBAaPthAMERfAhpoVszWD = BCNLKUgSBAaPthAMERfAhpoVszWD;
					}
					return rzWocjfwlsiWOoWzPNTvnZBgqTeD;
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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			[IteratorStateMachine(typeof(PaDfnxIgVcuydLHpVHulVPNoszrH))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new PaDfnxIgVcuydLHpVHulVPNoszrH(-2)
				{
					alKgDyOuIpdubfkybFdWjkHheXHab = this
				};
			}

			[IteratorStateMachine(typeof(RzWocjfwlsiWOoWzPNTvnZBgqTeD))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new RzWocjfwlsiWOoWzPNTvnZBgqTeD(-2)
				{
					BCNLKUgSBAaPthAMERfAhpoVszWD = this
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

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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
						jxcSgBCAckNrIjPsBFiAMTdHLFuQ(elementCount);
						return elementCount;
					}

					internal void BjDaxfbEfMEIUFWLcfmXIqkdAiToA(ElementCount_Base P_0)
					{
						base.jxcSgBCAckNrIjPsBFiAMTdHLFuQ(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool UZDoTuwAOWtypeZFdaouGWKihIeH(BridgedControllerHWInfo P_0)
					{
						if (!base.KhdgjMQnSkGAvAuHpiccCSGlQcYsA(P_0))
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
					if (deviceType != (DeviceType)bridgedControllerHWInfo.deviceType)
					{
						return false;
					}
					if (!HasProductName() && (productGUID == null || productGUID.Length == 0))
					{
						return true;
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
						matchingCriteria.deviceType = deviceType;
					}
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class JfCVkdewaKUIxXNOgcaxKZZEufWq : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int UlVUIkaRNlsnGAdUlFVQcPUvjGRBA;

					private Axis FYxKfURyAQvKPLoMWAfgNDOzloBc;

					private int COsqQBcmtQCjWUoArdVdBcNXKFTLA;

					public Elements EOUOyKuqvzEDfnFsNqHtAEHEFZCe;

					private int BFlNRHQxTURsEAuqFFGcTUrrTkPd;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return FYxKfURyAQvKPLoMWAfgNDOzloBc;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return FYxKfURyAQvKPLoMWAfgNDOzloBc;
						}
					}

					[DebuggerHidden]
					public JfCVkdewaKUIxXNOgcaxKZZEufWq(int P_0)
					{
						UlVUIkaRNlsnGAdUlFVQcPUvjGRBA = P_0;
						COsqQBcmtQCjWUoArdVdBcNXKFTLA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int ulVUIkaRNlsnGAdUlFVQcPUvjGRBA = UlVUIkaRNlsnGAdUlFVQcPUvjGRBA;
						Elements eOUOyKuqvzEDfnFsNqHtAEHEFZCe = EOUOyKuqvzEDfnFsNqHtAEHEFZCe;
						switch (ulVUIkaRNlsnGAdUlFVQcPUvjGRBA)
						{
						default:
							return false;
						case 0:
							UlVUIkaRNlsnGAdUlFVQcPUvjGRBA = -1;
							if (eOUOyKuqvzEDfnFsNqHtAEHEFZCe.axes == null)
							{
								return false;
							}
							BFlNRHQxTURsEAuqFFGcTUrrTkPd = 0;
							break;
						case 1:
							UlVUIkaRNlsnGAdUlFVQcPUvjGRBA = -1;
							BFlNRHQxTURsEAuqFFGcTUrrTkPd++;
							break;
						}
						if (BFlNRHQxTURsEAuqFFGcTUrrTkPd < eOUOyKuqvzEDfnFsNqHtAEHEFZCe.axes.Length)
						{
							FYxKfURyAQvKPLoMWAfgNDOzloBc = eOUOyKuqvzEDfnFsNqHtAEHEFZCe.axes[BFlNRHQxTURsEAuqFFGcTUrrTkPd];
							UlVUIkaRNlsnGAdUlFVQcPUvjGRBA = 1;
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
						JfCVkdewaKUIxXNOgcaxKZZEufWq jfCVkdewaKUIxXNOgcaxKZZEufWq;
						if (UlVUIkaRNlsnGAdUlFVQcPUvjGRBA == -2 && COsqQBcmtQCjWUoArdVdBcNXKFTLA == Environment.CurrentManagedThreadId)
						{
							UlVUIkaRNlsnGAdUlFVQcPUvjGRBA = 0;
							jfCVkdewaKUIxXNOgcaxKZZEufWq = this;
						}
						else
						{
							jfCVkdewaKUIxXNOgcaxKZZEufWq = new JfCVkdewaKUIxXNOgcaxKZZEufWq(0);
							jfCVkdewaKUIxXNOgcaxKZZEufWq.EOUOyKuqvzEDfnFsNqHtAEHEFZCe = EOUOyKuqvzEDfnFsNqHtAEHEFZCe;
						}
						return jfCVkdewaKUIxXNOgcaxKZZEufWq;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class mhVoNuWmysnNHguWejWzzqlwrJeX : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int lPAbiwjkGypdxAJZCrPPbSjQKQLoc;

					private Button bbJHTlDNniwXsXnvgZwguZLLazMQ;

					private int VRKATVJqmVCeLlwvEMHlHnoSnNPd;

					public Elements EmKgpQUhFitaQXOGQvPnFlWSxksB;

					private int QDDziUJIdhWHoUYJaTjexFlrCWjm;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return bbJHTlDNniwXsXnvgZwguZLLazMQ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return bbJHTlDNniwXsXnvgZwguZLLazMQ;
						}
					}

					[DebuggerHidden]
					public mhVoNuWmysnNHguWejWzzqlwrJeX(int P_0)
					{
						lPAbiwjkGypdxAJZCrPPbSjQKQLoc = P_0;
						VRKATVJqmVCeLlwvEMHlHnoSnNPd = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = lPAbiwjkGypdxAJZCrPPbSjQKQLoc;
						Elements emKgpQUhFitaQXOGQvPnFlWSxksB = EmKgpQUhFitaQXOGQvPnFlWSxksB;
						switch (num)
						{
						default:
							return false;
						case 0:
							lPAbiwjkGypdxAJZCrPPbSjQKQLoc = -1;
							if (emKgpQUhFitaQXOGQvPnFlWSxksB.buttons == null)
							{
								return false;
							}
							QDDziUJIdhWHoUYJaTjexFlrCWjm = 0;
							break;
						case 1:
							lPAbiwjkGypdxAJZCrPPbSjQKQLoc = -1;
							QDDziUJIdhWHoUYJaTjexFlrCWjm++;
							break;
						}
						if (QDDziUJIdhWHoUYJaTjexFlrCWjm < emKgpQUhFitaQXOGQvPnFlWSxksB.buttons.Length)
						{
							bbJHTlDNniwXsXnvgZwguZLLazMQ = emKgpQUhFitaQXOGQvPnFlWSxksB.buttons[QDDziUJIdhWHoUYJaTjexFlrCWjm];
							lPAbiwjkGypdxAJZCrPPbSjQKQLoc = 1;
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
						mhVoNuWmysnNHguWejWzzqlwrJeX mhVoNuWmysnNHguWejWzzqlwrJeX2;
						if (lPAbiwjkGypdxAJZCrPPbSjQKQLoc == -2 && VRKATVJqmVCeLlwvEMHlHnoSnNPd == Environment.CurrentManagedThreadId)
						{
							lPAbiwjkGypdxAJZCrPPbSjQKQLoc = 0;
							mhVoNuWmysnNHguWejWzzqlwrJeX2 = this;
						}
						else
						{
							mhVoNuWmysnNHguWejWzzqlwrJeX2 = new mhVoNuWmysnNHguWejWzzqlwrJeX(0);
							mhVoNuWmysnNHguWejWzzqlwrJeX2.EmKgpQUhFitaQXOGQvPnFlWSxksB = EmKgpQUhFitaQXOGQvPnFlWSxksB;
						}
						return mhVoNuWmysnNHguWejWzzqlwrJeX2;
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
					[IteratorStateMachine(typeof(JfCVkdewaKUIxXNOgcaxKZZEufWq))]
					get
					{
						return new JfCVkdewaKUIxXNOgcaxKZZEufWq(-2)
						{
							EOUOyKuqvzEDfnFsNqHtAEHEFZCe = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(mhVoNuWmysnNHguWejWzzqlwrJeX))]
					get
					{
						return new mhVoNuWmysnNHguWejWzzqlwrJeX(-2)
						{
							EmKgpQUhFitaQXOGQvPnFlWSxksB = this
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

			public enum DeviceType
			{
				HIDJoystick = 0,
				WGIGamepad = 1
			}

			private sealed class VGyLhnFgFMZqVfzDAwKRiiiKgQVR : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int KfRDRpxvRcfTRiMkGdZCIFpRlkvJ;

				private Axis nmUZwYMsmdWxbZFEhyoIuiFkaVWHA;

				private int xLXoeXtObNQyjZNJBSSbPDObmrdy;

				public Platform_WindowsUWP_Base nJOjkHgrpowaFpLtCpzLRwbAiHyA;

				private int IYtiNMqEsgsaLoGJmFWeymlxcTvKA;

				private int HOzzOLYeOFYuVBURaHhrXlxVNfTt;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return nmUZwYMsmdWxbZFEhyoIuiFkaVWHA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return nmUZwYMsmdWxbZFEhyoIuiFkaVWHA;
					}
				}

				[DebuggerHidden]
				public VGyLhnFgFMZqVfzDAwKRiiiKgQVR(int P_0)
				{
					KfRDRpxvRcfTRiMkGdZCIFpRlkvJ = P_0;
					xLXoeXtObNQyjZNJBSSbPDObmrdy = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int kfRDRpxvRcfTRiMkGdZCIFpRlkvJ = KfRDRpxvRcfTRiMkGdZCIFpRlkvJ;
					Platform_WindowsUWP_Base platform_WindowsUWP_Base = nJOjkHgrpowaFpLtCpzLRwbAiHyA;
					switch (kfRDRpxvRcfTRiMkGdZCIFpRlkvJ)
					{
					default:
						return false;
					case 0:
						KfRDRpxvRcfTRiMkGdZCIFpRlkvJ = -1;
						if (platform_WindowsUWP_Base.elements == null || platform_WindowsUWP_Base.elements.axes == null)
						{
							return false;
						}
						IYtiNMqEsgsaLoGJmFWeymlxcTvKA = platform_WindowsUWP_Base.elements.axes.Length;
						HOzzOLYeOFYuVBURaHhrXlxVNfTt = 0;
						break;
					case 1:
						KfRDRpxvRcfTRiMkGdZCIFpRlkvJ = -1;
						HOzzOLYeOFYuVBURaHhrXlxVNfTt++;
						break;
					}
					if (HOzzOLYeOFYuVBURaHhrXlxVNfTt < IYtiNMqEsgsaLoGJmFWeymlxcTvKA)
					{
						nmUZwYMsmdWxbZFEhyoIuiFkaVWHA = platform_WindowsUWP_Base.elements.axes[HOzzOLYeOFYuVBURaHhrXlxVNfTt];
						KfRDRpxvRcfTRiMkGdZCIFpRlkvJ = 1;
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
					VGyLhnFgFMZqVfzDAwKRiiiKgQVR vGyLhnFgFMZqVfzDAwKRiiiKgQVR;
					if (KfRDRpxvRcfTRiMkGdZCIFpRlkvJ == -2 && xLXoeXtObNQyjZNJBSSbPDObmrdy == Environment.CurrentManagedThreadId)
					{
						KfRDRpxvRcfTRiMkGdZCIFpRlkvJ = 0;
						vGyLhnFgFMZqVfzDAwKRiiiKgQVR = this;
					}
					else
					{
						vGyLhnFgFMZqVfzDAwKRiiiKgQVR = new VGyLhnFgFMZqVfzDAwKRiiiKgQVR(0);
						vGyLhnFgFMZqVfzDAwKRiiiKgQVR.nJOjkHgrpowaFpLtCpzLRwbAiHyA = nJOjkHgrpowaFpLtCpzLRwbAiHyA;
					}
					return vGyLhnFgFMZqVfzDAwKRiiiKgQVR;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class PXNOjVxesgVJUztgMpmgCVREygMK : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int hJZFvKBdfthczsaiEUMkpFIZjLYh;

				private Button NhRaQvCLiykjRisVSyzwLvYBGdXr;

				private int LRBznMWMimKaeazdHGpwiXnPbNHX;

				public Platform_WindowsUWP_Base oUbPgtBJIPeNNPvFhQSqSnsZKxQm;

				private int pnikaiHkZcIeTFyeoHwYzdDwcjEkA;

				private int JKJHfkSzZjulynYCBWpDJDGOjXHt;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return NhRaQvCLiykjRisVSyzwLvYBGdXr;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return NhRaQvCLiykjRisVSyzwLvYBGdXr;
					}
				}

				[DebuggerHidden]
				public PXNOjVxesgVJUztgMpmgCVREygMK(int P_0)
				{
					hJZFvKBdfthczsaiEUMkpFIZjLYh = P_0;
					LRBznMWMimKaeazdHGpwiXnPbNHX = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hJZFvKBdfthczsaiEUMkpFIZjLYh;
					Platform_WindowsUWP_Base platform_WindowsUWP_Base = oUbPgtBJIPeNNPvFhQSqSnsZKxQm;
					switch (num)
					{
					default:
						return false;
					case 0:
						hJZFvKBdfthczsaiEUMkpFIZjLYh = -1;
						if (platform_WindowsUWP_Base.elements == null || platform_WindowsUWP_Base.elements.buttons == null)
						{
							return false;
						}
						pnikaiHkZcIeTFyeoHwYzdDwcjEkA = platform_WindowsUWP_Base.elements.buttons.Length;
						JKJHfkSzZjulynYCBWpDJDGOjXHt = 0;
						break;
					case 1:
						hJZFvKBdfthczsaiEUMkpFIZjLYh = -1;
						JKJHfkSzZjulynYCBWpDJDGOjXHt++;
						break;
					}
					if (JKJHfkSzZjulynYCBWpDJDGOjXHt < pnikaiHkZcIeTFyeoHwYzdDwcjEkA)
					{
						NhRaQvCLiykjRisVSyzwLvYBGdXr = platform_WindowsUWP_Base.elements.buttons[JKJHfkSzZjulynYCBWpDJDGOjXHt];
						hJZFvKBdfthczsaiEUMkpFIZjLYh = 1;
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
					PXNOjVxesgVJUztgMpmgCVREygMK pXNOjVxesgVJUztgMpmgCVREygMK;
					if (hJZFvKBdfthczsaiEUMkpFIZjLYh == -2 && LRBznMWMimKaeazdHGpwiXnPbNHX == Environment.CurrentManagedThreadId)
					{
						hJZFvKBdfthczsaiEUMkpFIZjLYh = 0;
						pXNOjVxesgVJUztgMpmgCVREygMK = this;
					}
					else
					{
						pXNOjVxesgVJUztgMpmgCVREygMK = new PXNOjVxesgVJUztgMpmgCVREygMK(0);
						pXNOjVxesgVJUztgMpmgCVREygMK.oUbPgtBJIPeNNPvFhQSqSnsZKxQm = oUbPgtBJIPeNNPvFhQSqSnsZKxQm;
					}
					return pXNOjVxesgVJUztgMpmgCVREygMK;
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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			[IteratorStateMachine(typeof(VGyLhnFgFMZqVfzDAwKRiiiKgQVR))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new VGyLhnFgFMZqVfzDAwKRiiiKgQVR(-2)
				{
					nJOjkHgrpowaFpLtCpzLRwbAiHyA = this
				};
			}

			[IteratorStateMachine(typeof(PXNOjVxesgVJUztgMpmgCVREygMK))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new PXNOjVxesgVJUztgMpmgCVREygMK(-2)
				{
					oUbPgtBJIPeNNPvFhQSqSnsZKxQm = this
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

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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

				internal virtual void CopyVars(Element destination)
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

				internal override void CopyVars(Element destination)
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

			private sealed class GQENMFfVTwsEIYEYqDbebcSYlPjAb : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int aQHcNTKFiaebkYUHCWpgOjBwpMrRA;

				private Axis qVEDbeJlcohAnSpzOtUANBCrPhLnA;

				private int eskFULlhImBDPDgzzCdrwULRIBVR;

				public Platform_Fallback_Base hjASoPWDeCqxnoogEpxwNuhWgtWr;

				private int MEzZjotGDfunHuMeQWgUhAAAraUC;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return qVEDbeJlcohAnSpzOtUANBCrPhLnA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return qVEDbeJlcohAnSpzOtUANBCrPhLnA;
					}
				}

				[DebuggerHidden]
				public GQENMFfVTwsEIYEYqDbebcSYlPjAb(int P_0)
				{
					aQHcNTKFiaebkYUHCWpgOjBwpMrRA = P_0;
					eskFULlhImBDPDgzzCdrwULRIBVR = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = aQHcNTKFiaebkYUHCWpgOjBwpMrRA;
					Platform_Fallback_Base platform_Fallback_Base = hjASoPWDeCqxnoogEpxwNuhWgtWr;
					switch (num)
					{
					default:
						return false;
					case 0:
						aQHcNTKFiaebkYUHCWpgOjBwpMrRA = -1;
						if (platform_Fallback_Base.elements == null || platform_Fallback_Base.elements.axes == null)
						{
							return false;
						}
						MEzZjotGDfunHuMeQWgUhAAAraUC = 0;
						break;
					case 1:
						aQHcNTKFiaebkYUHCWpgOjBwpMrRA = -1;
						MEzZjotGDfunHuMeQWgUhAAAraUC++;
						break;
					}
					if (MEzZjotGDfunHuMeQWgUhAAAraUC < platform_Fallback_Base.elements.axes.Length)
					{
						qVEDbeJlcohAnSpzOtUANBCrPhLnA = platform_Fallback_Base.elements.axes[MEzZjotGDfunHuMeQWgUhAAAraUC];
						aQHcNTKFiaebkYUHCWpgOjBwpMrRA = 1;
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
					GQENMFfVTwsEIYEYqDbebcSYlPjAb gQENMFfVTwsEIYEYqDbebcSYlPjAb;
					if (aQHcNTKFiaebkYUHCWpgOjBwpMrRA == -2 && eskFULlhImBDPDgzzCdrwULRIBVR == Environment.CurrentManagedThreadId)
					{
						aQHcNTKFiaebkYUHCWpgOjBwpMrRA = 0;
						gQENMFfVTwsEIYEYqDbebcSYlPjAb = this;
					}
					else
					{
						gQENMFfVTwsEIYEYqDbebcSYlPjAb = new GQENMFfVTwsEIYEYqDbebcSYlPjAb(0);
						gQENMFfVTwsEIYEYqDbebcSYlPjAb.hjASoPWDeCqxnoogEpxwNuhWgtWr = hjASoPWDeCqxnoogEpxwNuhWgtWr;
					}
					return gQENMFfVTwsEIYEYqDbebcSYlPjAb;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class sJYXTfDTUiinXfNJDPCoxheyNjeN : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int cnHhOsKBNnlbveFiDaxyjmmeBEeDA;

				private Button vVHeDEAxGAbsBdYmHyJUwnuJLAKd;

				private int ADUhTSMiNsbaMAwwyicoubdtEfOs;

				public Platform_Fallback_Base SKOggpwvuLljIpJrpWvVGzldnJcG;

				private int ljaYxSZFdYeiJqJTUfdrhlTngNbm;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vVHeDEAxGAbsBdYmHyJUwnuJLAKd;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vVHeDEAxGAbsBdYmHyJUwnuJLAKd;
					}
				}

				[DebuggerHidden]
				public sJYXTfDTUiinXfNJDPCoxheyNjeN(int P_0)
				{
					cnHhOsKBNnlbveFiDaxyjmmeBEeDA = P_0;
					ADUhTSMiNsbaMAwwyicoubdtEfOs = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = cnHhOsKBNnlbveFiDaxyjmmeBEeDA;
					Platform_Fallback_Base sKOggpwvuLljIpJrpWvVGzldnJcG = SKOggpwvuLljIpJrpWvVGzldnJcG;
					switch (num)
					{
					default:
						return false;
					case 0:
						cnHhOsKBNnlbveFiDaxyjmmeBEeDA = -1;
						if (sKOggpwvuLljIpJrpWvVGzldnJcG.elements == null || sKOggpwvuLljIpJrpWvVGzldnJcG.elements.buttons == null)
						{
							return false;
						}
						ljaYxSZFdYeiJqJTUfdrhlTngNbm = 0;
						break;
					case 1:
						cnHhOsKBNnlbveFiDaxyjmmeBEeDA = -1;
						ljaYxSZFdYeiJqJTUfdrhlTngNbm++;
						break;
					}
					if (ljaYxSZFdYeiJqJTUfdrhlTngNbm < sKOggpwvuLljIpJrpWvVGzldnJcG.elements.buttons.Length)
					{
						vVHeDEAxGAbsBdYmHyJUwnuJLAKd = sKOggpwvuLljIpJrpWvVGzldnJcG.elements.buttons[ljaYxSZFdYeiJqJTUfdrhlTngNbm];
						cnHhOsKBNnlbveFiDaxyjmmeBEeDA = 1;
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
					sJYXTfDTUiinXfNJDPCoxheyNjeN sJYXTfDTUiinXfNJDPCoxheyNjeN2;
					if (cnHhOsKBNnlbveFiDaxyjmmeBEeDA == -2 && ADUhTSMiNsbaMAwwyicoubdtEfOs == Environment.CurrentManagedThreadId)
					{
						cnHhOsKBNnlbveFiDaxyjmmeBEeDA = 0;
						sJYXTfDTUiinXfNJDPCoxheyNjeN2 = this;
					}
					else
					{
						sJYXTfDTUiinXfNJDPCoxheyNjeN2 = new sJYXTfDTUiinXfNJDPCoxheyNjeN(0);
						sJYXTfDTUiinXfNJDPCoxheyNjeN2.SKOggpwvuLljIpJrpWvVGzldnJcG = SKOggpwvuLljIpJrpWvVGzldnJcG;
					}
					return sJYXTfDTUiinXfNJDPCoxheyNjeN2;
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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			[IteratorStateMachine(typeof(GQENMFfVTwsEIYEYqDbebcSYlPjAb))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new GQENMFfVTwsEIYEYqDbebcSYlPjAb(-2)
				{
					hjASoPWDeCqxnoogEpxwNuhWgtWr = this
				};
			}

			[IteratorStateMachine(typeof(sJYXTfDTUiinXfNJDPCoxheyNjeN))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new sJYXTfDTUiinXfNJDPCoxheyNjeN(-2)
				{
					SKOggpwvuLljIpJrpWvVGzldnJcG = this
				};
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

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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
				[Tooltip("If enabled, this will match to every controller regardless of other matching criteria.")]
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

			private sealed class DwyAnWjkiOsfvcdsHqPReycYjrgDb : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int daeauJxWwXEOuNUHizcdxGuUxKvt;

				private Platform_Custom.Axis vktteOAzANkpSlCdEioeysCqRZYr;

				private int yXIiUOJFKvOntefXNhDPGOxwCfNJ;

				public Platform_XboxOne_Base HOcqIXdvNLIyryPesMjmBeggHixP;

				private int nvGdSFupxInFnBBMMhZdbOklfsPs;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vktteOAzANkpSlCdEioeysCqRZYr;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vktteOAzANkpSlCdEioeysCqRZYr;
					}
				}

				[DebuggerHidden]
				public DwyAnWjkiOsfvcdsHqPReycYjrgDb(int P_0)
				{
					daeauJxWwXEOuNUHizcdxGuUxKvt = P_0;
					yXIiUOJFKvOntefXNhDPGOxwCfNJ = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = daeauJxWwXEOuNUHizcdxGuUxKvt;
					Platform_XboxOne_Base hOcqIXdvNLIyryPesMjmBeggHixP = HOcqIXdvNLIyryPesMjmBeggHixP;
					switch (num)
					{
					default:
						return false;
					case 0:
						daeauJxWwXEOuNUHizcdxGuUxKvt = -1;
						if (hOcqIXdvNLIyryPesMjmBeggHixP.elements == null || hOcqIXdvNLIyryPesMjmBeggHixP.elements.axes == null)
						{
							return false;
						}
						nvGdSFupxInFnBBMMhZdbOklfsPs = 0;
						break;
					case 1:
						daeauJxWwXEOuNUHizcdxGuUxKvt = -1;
						nvGdSFupxInFnBBMMhZdbOklfsPs++;
						break;
					}
					if (nvGdSFupxInFnBBMMhZdbOklfsPs < hOcqIXdvNLIyryPesMjmBeggHixP.elements.axes.Length)
					{
						vktteOAzANkpSlCdEioeysCqRZYr = hOcqIXdvNLIyryPesMjmBeggHixP.elements.axes[nvGdSFupxInFnBBMMhZdbOklfsPs];
						daeauJxWwXEOuNUHizcdxGuUxKvt = 1;
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
					DwyAnWjkiOsfvcdsHqPReycYjrgDb dwyAnWjkiOsfvcdsHqPReycYjrgDb;
					if (daeauJxWwXEOuNUHizcdxGuUxKvt == -2 && yXIiUOJFKvOntefXNhDPGOxwCfNJ == Environment.CurrentManagedThreadId)
					{
						daeauJxWwXEOuNUHizcdxGuUxKvt = 0;
						dwyAnWjkiOsfvcdsHqPReycYjrgDb = this;
					}
					else
					{
						dwyAnWjkiOsfvcdsHqPReycYjrgDb = new DwyAnWjkiOsfvcdsHqPReycYjrgDb(0);
						dwyAnWjkiOsfvcdsHqPReycYjrgDb.HOcqIXdvNLIyryPesMjmBeggHixP = HOcqIXdvNLIyryPesMjmBeggHixP;
					}
					return dwyAnWjkiOsfvcdsHqPReycYjrgDb;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class zHJGpjJWfydnwUsiiyZvFtHpXwXlA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int CThyiulWOZwwvhwdcYzJkaexCElK;

				private Platform_Custom.Button ZJucvJIDyzdhIGdLRKSqrpfsRwzL;

				private int KKalEqTJJeIvZfuLykYvOSlZdsbw;

				public Platform_XboxOne_Base wRibTsTJwzuDzEKgHByIGRMDljWS;

				private int qoAfOmBeyWJNxdCfjlbrpRJGDNytb;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ZJucvJIDyzdhIGdLRKSqrpfsRwzL;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ZJucvJIDyzdhIGdLRKSqrpfsRwzL;
					}
				}

				[DebuggerHidden]
				public zHJGpjJWfydnwUsiiyZvFtHpXwXlA(int P_0)
				{
					CThyiulWOZwwvhwdcYzJkaexCElK = P_0;
					KKalEqTJJeIvZfuLykYvOSlZdsbw = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int cThyiulWOZwwvhwdcYzJkaexCElK = CThyiulWOZwwvhwdcYzJkaexCElK;
					Platform_XboxOne_Base platform_XboxOne_Base = wRibTsTJwzuDzEKgHByIGRMDljWS;
					switch (cThyiulWOZwwvhwdcYzJkaexCElK)
					{
					default:
						return false;
					case 0:
						CThyiulWOZwwvhwdcYzJkaexCElK = -1;
						if (platform_XboxOne_Base.elements == null || platform_XboxOne_Base.elements.buttons == null)
						{
							return false;
						}
						qoAfOmBeyWJNxdCfjlbrpRJGDNytb = 0;
						break;
					case 1:
						CThyiulWOZwwvhwdcYzJkaexCElK = -1;
						qoAfOmBeyWJNxdCfjlbrpRJGDNytb++;
						break;
					}
					if (qoAfOmBeyWJNxdCfjlbrpRJGDNytb < platform_XboxOne_Base.elements.buttons.Length)
					{
						ZJucvJIDyzdhIGdLRKSqrpfsRwzL = platform_XboxOne_Base.elements.buttons[qoAfOmBeyWJNxdCfjlbrpRJGDNytb];
						CThyiulWOZwwvhwdcYzJkaexCElK = 1;
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
					zHJGpjJWfydnwUsiiyZvFtHpXwXlA zHJGpjJWfydnwUsiiyZvFtHpXwXlA2;
					if (CThyiulWOZwwvhwdcYzJkaexCElK == -2 && KKalEqTJJeIvZfuLykYvOSlZdsbw == Environment.CurrentManagedThreadId)
					{
						CThyiulWOZwwvhwdcYzJkaexCElK = 0;
						zHJGpjJWfydnwUsiiyZvFtHpXwXlA2 = this;
					}
					else
					{
						zHJGpjJWfydnwUsiiyZvFtHpXwXlA2 = new zHJGpjJWfydnwUsiiyZvFtHpXwXlA(0);
						zHJGpjJWfydnwUsiiyZvFtHpXwXlA2.wRibTsTJwzuDzEKgHByIGRMDljWS = wRibTsTJwzuDzEKgHByIGRMDljWS;
					}
					return zHJGpjJWfydnwUsiiyZvFtHpXwXlA2;
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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			[IteratorStateMachine(typeof(DwyAnWjkiOsfvcdsHqPReycYjrgDb))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new DwyAnWjkiOsfvcdsHqPReycYjrgDb(-2)
				{
					HOcqIXdvNLIyryPesMjmBeggHixP = this
				};
			}

			[IteratorStateMachine(typeof(zHJGpjJWfydnwUsiiyZvFtHpXwXlA))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new zHJGpjJWfydnwUsiiyZvFtHpXwXlA(-2)
				{
					wRibTsTJwzuDzEKgHByIGRMDljWS = this
				};
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

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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

			private sealed class FDLLcWlpfcXftspMMtZBmAvoCojIA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int ggPvqyrXMTqPTHFgvcvQYtfAsmoi;

				private Platform_Custom.Axis szgHHJywPfKlMgGsUIsKwmvcKHDS;

				private int jeGJtdiBOQUfByuzMbGvKOjDlxcH;

				public Platform_PS4_Base ZvIEbvzNrIqLhNjoHIFIcmOyhdNdA;

				private int nWvFKTDkbxyODrOIFiLcllUyEtGkA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return szgHHJywPfKlMgGsUIsKwmvcKHDS;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return szgHHJywPfKlMgGsUIsKwmvcKHDS;
					}
				}

				[DebuggerHidden]
				public FDLLcWlpfcXftspMMtZBmAvoCojIA(int P_0)
				{
					ggPvqyrXMTqPTHFgvcvQYtfAsmoi = P_0;
					jeGJtdiBOQUfByuzMbGvKOjDlxcH = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = ggPvqyrXMTqPTHFgvcvQYtfAsmoi;
					Platform_PS4_Base zvIEbvzNrIqLhNjoHIFIcmOyhdNdA = ZvIEbvzNrIqLhNjoHIFIcmOyhdNdA;
					switch (num)
					{
					default:
						return false;
					case 0:
						ggPvqyrXMTqPTHFgvcvQYtfAsmoi = -1;
						if (zvIEbvzNrIqLhNjoHIFIcmOyhdNdA.elements == null || zvIEbvzNrIqLhNjoHIFIcmOyhdNdA.elements.axes == null)
						{
							return false;
						}
						nWvFKTDkbxyODrOIFiLcllUyEtGkA = 0;
						break;
					case 1:
						ggPvqyrXMTqPTHFgvcvQYtfAsmoi = -1;
						nWvFKTDkbxyODrOIFiLcllUyEtGkA++;
						break;
					}
					if (nWvFKTDkbxyODrOIFiLcllUyEtGkA < zvIEbvzNrIqLhNjoHIFIcmOyhdNdA.elements.axes.Length)
					{
						szgHHJywPfKlMgGsUIsKwmvcKHDS = zvIEbvzNrIqLhNjoHIFIcmOyhdNdA.elements.axes[nWvFKTDkbxyODrOIFiLcllUyEtGkA];
						ggPvqyrXMTqPTHFgvcvQYtfAsmoi = 1;
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
					FDLLcWlpfcXftspMMtZBmAvoCojIA fDLLcWlpfcXftspMMtZBmAvoCojIA;
					if (ggPvqyrXMTqPTHFgvcvQYtfAsmoi == -2 && jeGJtdiBOQUfByuzMbGvKOjDlxcH == Environment.CurrentManagedThreadId)
					{
						ggPvqyrXMTqPTHFgvcvQYtfAsmoi = 0;
						fDLLcWlpfcXftspMMtZBmAvoCojIA = this;
					}
					else
					{
						fDLLcWlpfcXftspMMtZBmAvoCojIA = new FDLLcWlpfcXftspMMtZBmAvoCojIA(0);
						fDLLcWlpfcXftspMMtZBmAvoCojIA.ZvIEbvzNrIqLhNjoHIFIcmOyhdNdA = ZvIEbvzNrIqLhNjoHIFIcmOyhdNdA;
					}
					return fDLLcWlpfcXftspMMtZBmAvoCojIA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class iSZWAOQDFlBuRYGrcCpSADWMLMMbb : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int HPkhwdefTjoyBOUpkwcBacmUvQty;

				private Platform_Custom.Button UcspjwGzAINsNqQpniPVWNEyvAbb;

				private int SNURKjOloOBqovPcrdlrgHDcamnE;

				public Platform_PS4_Base XMTeXzkJrBJrEzzUAhmYACLzyHNT;

				private int ZTHffqEdmobhdugCUHpVzvyYbVIJ;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return UcspjwGzAINsNqQpniPVWNEyvAbb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return UcspjwGzAINsNqQpniPVWNEyvAbb;
					}
				}

				[DebuggerHidden]
				public iSZWAOQDFlBuRYGrcCpSADWMLMMbb(int P_0)
				{
					HPkhwdefTjoyBOUpkwcBacmUvQty = P_0;
					SNURKjOloOBqovPcrdlrgHDcamnE = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int hPkhwdefTjoyBOUpkwcBacmUvQty = HPkhwdefTjoyBOUpkwcBacmUvQty;
					Platform_PS4_Base xMTeXzkJrBJrEzzUAhmYACLzyHNT = XMTeXzkJrBJrEzzUAhmYACLzyHNT;
					switch (hPkhwdefTjoyBOUpkwcBacmUvQty)
					{
					default:
						return false;
					case 0:
						HPkhwdefTjoyBOUpkwcBacmUvQty = -1;
						if (xMTeXzkJrBJrEzzUAhmYACLzyHNT.elements == null || xMTeXzkJrBJrEzzUAhmYACLzyHNT.elements.buttons == null)
						{
							return false;
						}
						ZTHffqEdmobhdugCUHpVzvyYbVIJ = 0;
						break;
					case 1:
						HPkhwdefTjoyBOUpkwcBacmUvQty = -1;
						ZTHffqEdmobhdugCUHpVzvyYbVIJ++;
						break;
					}
					if (ZTHffqEdmobhdugCUHpVzvyYbVIJ < xMTeXzkJrBJrEzzUAhmYACLzyHNT.elements.buttons.Length)
					{
						UcspjwGzAINsNqQpniPVWNEyvAbb = xMTeXzkJrBJrEzzUAhmYACLzyHNT.elements.buttons[ZTHffqEdmobhdugCUHpVzvyYbVIJ];
						HPkhwdefTjoyBOUpkwcBacmUvQty = 1;
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
					iSZWAOQDFlBuRYGrcCpSADWMLMMbb iSZWAOQDFlBuRYGrcCpSADWMLMMbb2;
					if (HPkhwdefTjoyBOUpkwcBacmUvQty == -2 && SNURKjOloOBqovPcrdlrgHDcamnE == Environment.CurrentManagedThreadId)
					{
						HPkhwdefTjoyBOUpkwcBacmUvQty = 0;
						iSZWAOQDFlBuRYGrcCpSADWMLMMbb2 = this;
					}
					else
					{
						iSZWAOQDFlBuRYGrcCpSADWMLMMbb2 = new iSZWAOQDFlBuRYGrcCpSADWMLMMbb(0);
						iSZWAOQDFlBuRYGrcCpSADWMLMMbb2.XMTeXzkJrBJrEzzUAhmYACLzyHNT = XMTeXzkJrBJrEzzUAhmYACLzyHNT;
					}
					return iSZWAOQDFlBuRYGrcCpSADWMLMMbb2;
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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			[IteratorStateMachine(typeof(FDLLcWlpfcXftspMMtZBmAvoCojIA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new FDLLcWlpfcXftspMMtZBmAvoCojIA(-2)
				{
					ZvIEbvzNrIqLhNjoHIFIcmOyhdNdA = this
				};
			}

			[IteratorStateMachine(typeof(iSZWAOQDFlBuRYGrcCpSADWMLMMbb))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new iSZWAOQDFlBuRYGrcCpSADWMLMMbb(-2)
				{
					XMTeXzkJrBJrEzzUAhmYACLzyHNT = this
				};
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

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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

			private sealed class RZspkSofKBAbINAFLpbRAXgnkzLN : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int GzHtocQXYXMYPhPFnwsVsQMUAjmt;

				private Platform_Custom.Axis yWMkJsrBcgxhTqNhYOTXbGIhesKS;

				private int yzouGGcaYnhgUSVqZRSaOKcrzWKb;

				public Platform_NintendoSwitch_Base HMoLdsqAXSyQDNXKxvCOvsOPfEKh;

				private int QnBXcGmczjyCazkKCegBchLrtNQq;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return yWMkJsrBcgxhTqNhYOTXbGIhesKS;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return yWMkJsrBcgxhTqNhYOTXbGIhesKS;
					}
				}

				[DebuggerHidden]
				public RZspkSofKBAbINAFLpbRAXgnkzLN(int P_0)
				{
					GzHtocQXYXMYPhPFnwsVsQMUAjmt = P_0;
					yzouGGcaYnhgUSVqZRSaOKcrzWKb = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int gzHtocQXYXMYPhPFnwsVsQMUAjmt = GzHtocQXYXMYPhPFnwsVsQMUAjmt;
					Platform_NintendoSwitch_Base hMoLdsqAXSyQDNXKxvCOvsOPfEKh = HMoLdsqAXSyQDNXKxvCOvsOPfEKh;
					switch (gzHtocQXYXMYPhPFnwsVsQMUAjmt)
					{
					default:
						return false;
					case 0:
						GzHtocQXYXMYPhPFnwsVsQMUAjmt = -1;
						if (hMoLdsqAXSyQDNXKxvCOvsOPfEKh.elements == null || hMoLdsqAXSyQDNXKxvCOvsOPfEKh.elements.axes == null)
						{
							return false;
						}
						QnBXcGmczjyCazkKCegBchLrtNQq = 0;
						break;
					case 1:
						GzHtocQXYXMYPhPFnwsVsQMUAjmt = -1;
						QnBXcGmczjyCazkKCegBchLrtNQq++;
						break;
					}
					if (QnBXcGmczjyCazkKCegBchLrtNQq < hMoLdsqAXSyQDNXKxvCOvsOPfEKh.elements.axes.Length)
					{
						yWMkJsrBcgxhTqNhYOTXbGIhesKS = hMoLdsqAXSyQDNXKxvCOvsOPfEKh.elements.axes[QnBXcGmczjyCazkKCegBchLrtNQq];
						GzHtocQXYXMYPhPFnwsVsQMUAjmt = 1;
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
					RZspkSofKBAbINAFLpbRAXgnkzLN rZspkSofKBAbINAFLpbRAXgnkzLN;
					if (GzHtocQXYXMYPhPFnwsVsQMUAjmt == -2 && yzouGGcaYnhgUSVqZRSaOKcrzWKb == Environment.CurrentManagedThreadId)
					{
						GzHtocQXYXMYPhPFnwsVsQMUAjmt = 0;
						rZspkSofKBAbINAFLpbRAXgnkzLN = this;
					}
					else
					{
						rZspkSofKBAbINAFLpbRAXgnkzLN = new RZspkSofKBAbINAFLpbRAXgnkzLN(0);
						rZspkSofKBAbINAFLpbRAXgnkzLN.HMoLdsqAXSyQDNXKxvCOvsOPfEKh = HMoLdsqAXSyQDNXKxvCOvsOPfEKh;
					}
					return rZspkSofKBAbINAFLpbRAXgnkzLN;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class QZofAdWfFfBmtGGRkaBOoXBfBgPr : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int ZuqQEtittZObAuewicKHdiMFkqKIA;

				private Platform_Custom.Button YjsUrhQNTQUacbOqOJibnmbhUdwF;

				private int iJGNoKPLjLhDCpYCaeeNiRZNlfZd;

				public Platform_NintendoSwitch_Base zeEWqcJSiCjQIOsHDGlSVKcubnPN;

				private int SaLXRZeujSpTsrtzaRiDWgfScZQY;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return YjsUrhQNTQUacbOqOJibnmbhUdwF;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return YjsUrhQNTQUacbOqOJibnmbhUdwF;
					}
				}

				[DebuggerHidden]
				public QZofAdWfFfBmtGGRkaBOoXBfBgPr(int P_0)
				{
					ZuqQEtittZObAuewicKHdiMFkqKIA = P_0;
					iJGNoKPLjLhDCpYCaeeNiRZNlfZd = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int zuqQEtittZObAuewicKHdiMFkqKIA = ZuqQEtittZObAuewicKHdiMFkqKIA;
					Platform_NintendoSwitch_Base platform_NintendoSwitch_Base = zeEWqcJSiCjQIOsHDGlSVKcubnPN;
					switch (zuqQEtittZObAuewicKHdiMFkqKIA)
					{
					default:
						return false;
					case 0:
						ZuqQEtittZObAuewicKHdiMFkqKIA = -1;
						if (platform_NintendoSwitch_Base.elements == null || platform_NintendoSwitch_Base.elements.buttons == null)
						{
							return false;
						}
						SaLXRZeujSpTsrtzaRiDWgfScZQY = 0;
						break;
					case 1:
						ZuqQEtittZObAuewicKHdiMFkqKIA = -1;
						SaLXRZeujSpTsrtzaRiDWgfScZQY++;
						break;
					}
					if (SaLXRZeujSpTsrtzaRiDWgfScZQY < platform_NintendoSwitch_Base.elements.buttons.Length)
					{
						YjsUrhQNTQUacbOqOJibnmbhUdwF = platform_NintendoSwitch_Base.elements.buttons[SaLXRZeujSpTsrtzaRiDWgfScZQY];
						ZuqQEtittZObAuewicKHdiMFkqKIA = 1;
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
					QZofAdWfFfBmtGGRkaBOoXBfBgPr qZofAdWfFfBmtGGRkaBOoXBfBgPr;
					if (ZuqQEtittZObAuewicKHdiMFkqKIA == -2 && iJGNoKPLjLhDCpYCaeeNiRZNlfZd == Environment.CurrentManagedThreadId)
					{
						ZuqQEtittZObAuewicKHdiMFkqKIA = 0;
						qZofAdWfFfBmtGGRkaBOoXBfBgPr = this;
					}
					else
					{
						qZofAdWfFfBmtGGRkaBOoXBfBgPr = new QZofAdWfFfBmtGGRkaBOoXBfBgPr(0);
						qZofAdWfFfBmtGGRkaBOoXBfBgPr.zeEWqcJSiCjQIOsHDGlSVKcubnPN = zeEWqcJSiCjQIOsHDGlSVKcubnPN;
					}
					return qZofAdWfFfBmtGGRkaBOoXBfBgPr;
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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			[IteratorStateMachine(typeof(RZspkSofKBAbINAFLpbRAXgnkzLN))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new RZspkSofKBAbINAFLpbRAXgnkzLN(-2)
				{
					HMoLdsqAXSyQDNXKxvCOvsOPfEKh = this
				};
			}

			[IteratorStateMachine(typeof(QZofAdWfFfBmtGGRkaBOoXBfBgPr))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new QZofAdWfFfBmtGGRkaBOoXBfBgPr(-2)
				{
					zeEWqcJSiCjQIOsHDGlSVKcubnPN = this
				};
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

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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
						if (!HasProductName() && (vidPid == null || vidPid.Length == 0))
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

			private sealed class jxjYzZwewOplBPkGOFUpJAWLgVmiA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int iGAdwXAJcFpLcPslggOgMjPqMLIdb;

				private Platform_Custom.Axis hWPzxkJwOzStwiKCrCeQbzplWBTpA;

				private int BhjiqzqqQxnLyCiGIDCgotMNdjgz;

				public Platform_GameCore_Base PSOOaoeqOXEMvgEVwuVIrBmjckNB;

				private int kXiGKvDNGnItMamEITYhtwgfJfWpB;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return hWPzxkJwOzStwiKCrCeQbzplWBTpA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return hWPzxkJwOzStwiKCrCeQbzplWBTpA;
					}
				}

				[DebuggerHidden]
				public jxjYzZwewOplBPkGOFUpJAWLgVmiA(int P_0)
				{
					iGAdwXAJcFpLcPslggOgMjPqMLIdb = P_0;
					BhjiqzqqQxnLyCiGIDCgotMNdjgz = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = iGAdwXAJcFpLcPslggOgMjPqMLIdb;
					Platform_GameCore_Base pSOOaoeqOXEMvgEVwuVIrBmjckNB = PSOOaoeqOXEMvgEVwuVIrBmjckNB;
					switch (num)
					{
					default:
						return false;
					case 0:
						iGAdwXAJcFpLcPslggOgMjPqMLIdb = -1;
						if (pSOOaoeqOXEMvgEVwuVIrBmjckNB.elements == null || pSOOaoeqOXEMvgEVwuVIrBmjckNB.elements.axes == null)
						{
							return false;
						}
						kXiGKvDNGnItMamEITYhtwgfJfWpB = 0;
						break;
					case 1:
						iGAdwXAJcFpLcPslggOgMjPqMLIdb = -1;
						kXiGKvDNGnItMamEITYhtwgfJfWpB++;
						break;
					}
					if (kXiGKvDNGnItMamEITYhtwgfJfWpB < pSOOaoeqOXEMvgEVwuVIrBmjckNB.elements.axes.Length)
					{
						hWPzxkJwOzStwiKCrCeQbzplWBTpA = pSOOaoeqOXEMvgEVwuVIrBmjckNB.elements.axes[kXiGKvDNGnItMamEITYhtwgfJfWpB];
						iGAdwXAJcFpLcPslggOgMjPqMLIdb = 1;
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
					jxjYzZwewOplBPkGOFUpJAWLgVmiA jxjYzZwewOplBPkGOFUpJAWLgVmiA2;
					if (iGAdwXAJcFpLcPslggOgMjPqMLIdb == -2 && BhjiqzqqQxnLyCiGIDCgotMNdjgz == Environment.CurrentManagedThreadId)
					{
						iGAdwXAJcFpLcPslggOgMjPqMLIdb = 0;
						jxjYzZwewOplBPkGOFUpJAWLgVmiA2 = this;
					}
					else
					{
						jxjYzZwewOplBPkGOFUpJAWLgVmiA2 = new jxjYzZwewOplBPkGOFUpJAWLgVmiA(0);
						jxjYzZwewOplBPkGOFUpJAWLgVmiA2.PSOOaoeqOXEMvgEVwuVIrBmjckNB = PSOOaoeqOXEMvgEVwuVIrBmjckNB;
					}
					return jxjYzZwewOplBPkGOFUpJAWLgVmiA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class QrJzpECEoeeCZgSXVHYiecfdvMqbc : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int HbtMpLoBPvfUQiDdEsnUiLCUCHFR;

				private Platform_Custom.Button PiAFHEfjWSKDzFlHSDrYtPKWCeiwA;

				private int iXxjfndxIgRucoeciETghDLhEPRZA;

				public Platform_GameCore_Base SFKagPbOByKpyxCfqwePbThnqMmNA;

				private int ipgEVbhKvjeKfsqEwHoqbORZcUcfb;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return PiAFHEfjWSKDzFlHSDrYtPKWCeiwA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return PiAFHEfjWSKDzFlHSDrYtPKWCeiwA;
					}
				}

				[DebuggerHidden]
				public QrJzpECEoeeCZgSXVHYiecfdvMqbc(int P_0)
				{
					HbtMpLoBPvfUQiDdEsnUiLCUCHFR = P_0;
					iXxjfndxIgRucoeciETghDLhEPRZA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int hbtMpLoBPvfUQiDdEsnUiLCUCHFR = HbtMpLoBPvfUQiDdEsnUiLCUCHFR;
					Platform_GameCore_Base sFKagPbOByKpyxCfqwePbThnqMmNA = SFKagPbOByKpyxCfqwePbThnqMmNA;
					switch (hbtMpLoBPvfUQiDdEsnUiLCUCHFR)
					{
					default:
						return false;
					case 0:
						HbtMpLoBPvfUQiDdEsnUiLCUCHFR = -1;
						if (sFKagPbOByKpyxCfqwePbThnqMmNA.elements == null || sFKagPbOByKpyxCfqwePbThnqMmNA.elements.buttons == null)
						{
							return false;
						}
						ipgEVbhKvjeKfsqEwHoqbORZcUcfb = 0;
						break;
					case 1:
						HbtMpLoBPvfUQiDdEsnUiLCUCHFR = -1;
						ipgEVbhKvjeKfsqEwHoqbORZcUcfb++;
						break;
					}
					if (ipgEVbhKvjeKfsqEwHoqbORZcUcfb < sFKagPbOByKpyxCfqwePbThnqMmNA.elements.buttons.Length)
					{
						PiAFHEfjWSKDzFlHSDrYtPKWCeiwA = sFKagPbOByKpyxCfqwePbThnqMmNA.elements.buttons[ipgEVbhKvjeKfsqEwHoqbORZcUcfb];
						HbtMpLoBPvfUQiDdEsnUiLCUCHFR = 1;
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
					QrJzpECEoeeCZgSXVHYiecfdvMqbc qrJzpECEoeeCZgSXVHYiecfdvMqbc;
					if (HbtMpLoBPvfUQiDdEsnUiLCUCHFR == -2 && iXxjfndxIgRucoeciETghDLhEPRZA == Environment.CurrentManagedThreadId)
					{
						HbtMpLoBPvfUQiDdEsnUiLCUCHFR = 0;
						qrJzpECEoeeCZgSXVHYiecfdvMqbc = this;
					}
					else
					{
						qrJzpECEoeeCZgSXVHYiecfdvMqbc = new QrJzpECEoeeCZgSXVHYiecfdvMqbc(0);
						qrJzpECEoeeCZgSXVHYiecfdvMqbc.SFKagPbOByKpyxCfqwePbThnqMmNA = SFKagPbOByKpyxCfqwePbThnqMmNA;
					}
					return qrJzpECEoeeCZgSXVHYiecfdvMqbc;
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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			[IteratorStateMachine(typeof(jxjYzZwewOplBPkGOFUpJAWLgVmiA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new jxjYzZwewOplBPkGOFUpJAWLgVmiA(-2)
				{
					PSOOaoeqOXEMvgEVwuVIrBmjckNB = this
				};
			}

			[IteratorStateMachine(typeof(QrJzpECEoeeCZgSXVHYiecfdvMqbc))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new QrJzpECEoeeCZgSXVHYiecfdvMqbc(-2)
				{
					SFKagPbOByKpyxCfqwePbThnqMmNA = this
				};
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

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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

			private sealed class sfQLtuxtICKfXxiwRkjnhEBNdkZJA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int JKFaDiuhmVgRbhEGJaKGdGobaUUlb;

				private Platform_Custom.Axis lcdHwJivQWnSwMVuAgkloYLYhZEOA;

				private int ZcQegXWtTCFPLbFJvdlXhAHDlIpIA;

				public Platform_PS5_Base tNlBpfjwrMPeDcPDxWqLBLzjIXakA;

				private int YOmrMpONxuDIDmiKjSKjNdMPcrqcA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return lcdHwJivQWnSwMVuAgkloYLYhZEOA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return lcdHwJivQWnSwMVuAgkloYLYhZEOA;
					}
				}

				[DebuggerHidden]
				public sfQLtuxtICKfXxiwRkjnhEBNdkZJA(int P_0)
				{
					JKFaDiuhmVgRbhEGJaKGdGobaUUlb = P_0;
					ZcQegXWtTCFPLbFJvdlXhAHDlIpIA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int jKFaDiuhmVgRbhEGJaKGdGobaUUlb = JKFaDiuhmVgRbhEGJaKGdGobaUUlb;
					Platform_PS5_Base platform_PS5_Base = tNlBpfjwrMPeDcPDxWqLBLzjIXakA;
					switch (jKFaDiuhmVgRbhEGJaKGdGobaUUlb)
					{
					default:
						return false;
					case 0:
						JKFaDiuhmVgRbhEGJaKGdGobaUUlb = -1;
						if (platform_PS5_Base.elements == null || platform_PS5_Base.elements.axes == null)
						{
							return false;
						}
						YOmrMpONxuDIDmiKjSKjNdMPcrqcA = 0;
						break;
					case 1:
						JKFaDiuhmVgRbhEGJaKGdGobaUUlb = -1;
						YOmrMpONxuDIDmiKjSKjNdMPcrqcA++;
						break;
					}
					if (YOmrMpONxuDIDmiKjSKjNdMPcrqcA < platform_PS5_Base.elements.axes.Length)
					{
						lcdHwJivQWnSwMVuAgkloYLYhZEOA = platform_PS5_Base.elements.axes[YOmrMpONxuDIDmiKjSKjNdMPcrqcA];
						JKFaDiuhmVgRbhEGJaKGdGobaUUlb = 1;
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
					sfQLtuxtICKfXxiwRkjnhEBNdkZJA sfQLtuxtICKfXxiwRkjnhEBNdkZJA2;
					if (JKFaDiuhmVgRbhEGJaKGdGobaUUlb == -2 && ZcQegXWtTCFPLbFJvdlXhAHDlIpIA == Environment.CurrentManagedThreadId)
					{
						JKFaDiuhmVgRbhEGJaKGdGobaUUlb = 0;
						sfQLtuxtICKfXxiwRkjnhEBNdkZJA2 = this;
					}
					else
					{
						sfQLtuxtICKfXxiwRkjnhEBNdkZJA2 = new sfQLtuxtICKfXxiwRkjnhEBNdkZJA(0);
						sfQLtuxtICKfXxiwRkjnhEBNdkZJA2.tNlBpfjwrMPeDcPDxWqLBLzjIXakA = tNlBpfjwrMPeDcPDxWqLBLzjIXakA;
					}
					return sfQLtuxtICKfXxiwRkjnhEBNdkZJA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class JBzkTYvXzUTiwVbIlKiYxKvuWGOB : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int gQUdrRhLTPwegUusjhvfoqtasTzE;

				private Platform_Custom.Button lIRaCnDgjBhGNaImLkkUnRDpNIvT;

				private int cjujGkqhiEvscpHKtObSOmKYfozF;

				public Platform_PS5_Base LVvacyVzWGGWtHHldAEiOQtVCZyF;

				private int ylfXqRHZFoCSUvEYIPJwaMEnxlfL;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return lIRaCnDgjBhGNaImLkkUnRDpNIvT;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return lIRaCnDgjBhGNaImLkkUnRDpNIvT;
					}
				}

				[DebuggerHidden]
				public JBzkTYvXzUTiwVbIlKiYxKvuWGOB(int P_0)
				{
					gQUdrRhLTPwegUusjhvfoqtasTzE = P_0;
					cjujGkqhiEvscpHKtObSOmKYfozF = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = gQUdrRhLTPwegUusjhvfoqtasTzE;
					Platform_PS5_Base lVvacyVzWGGWtHHldAEiOQtVCZyF = LVvacyVzWGGWtHHldAEiOQtVCZyF;
					switch (num)
					{
					default:
						return false;
					case 0:
						gQUdrRhLTPwegUusjhvfoqtasTzE = -1;
						if (lVvacyVzWGGWtHHldAEiOQtVCZyF.elements == null || lVvacyVzWGGWtHHldAEiOQtVCZyF.elements.buttons == null)
						{
							return false;
						}
						ylfXqRHZFoCSUvEYIPJwaMEnxlfL = 0;
						break;
					case 1:
						gQUdrRhLTPwegUusjhvfoqtasTzE = -1;
						ylfXqRHZFoCSUvEYIPJwaMEnxlfL++;
						break;
					}
					if (ylfXqRHZFoCSUvEYIPJwaMEnxlfL < lVvacyVzWGGWtHHldAEiOQtVCZyF.elements.buttons.Length)
					{
						lIRaCnDgjBhGNaImLkkUnRDpNIvT = lVvacyVzWGGWtHHldAEiOQtVCZyF.elements.buttons[ylfXqRHZFoCSUvEYIPJwaMEnxlfL];
						gQUdrRhLTPwegUusjhvfoqtasTzE = 1;
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
					JBzkTYvXzUTiwVbIlKiYxKvuWGOB jBzkTYvXzUTiwVbIlKiYxKvuWGOB;
					if (gQUdrRhLTPwegUusjhvfoqtasTzE == -2 && cjujGkqhiEvscpHKtObSOmKYfozF == Environment.CurrentManagedThreadId)
					{
						gQUdrRhLTPwegUusjhvfoqtasTzE = 0;
						jBzkTYvXzUTiwVbIlKiYxKvuWGOB = this;
					}
					else
					{
						jBzkTYvXzUTiwVbIlKiYxKvuWGOB = new JBzkTYvXzUTiwVbIlKiYxKvuWGOB(0);
						jBzkTYvXzUTiwVbIlKiYxKvuWGOB.LVvacyVzWGGWtHHldAEiOQtVCZyF = LVvacyVzWGGWtHHldAEiOQtVCZyF;
					}
					return jBzkTYvXzUTiwVbIlKiYxKvuWGOB;
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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			[IteratorStateMachine(typeof(sfQLtuxtICKfXxiwRkjnhEBNdkZJA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new sfQLtuxtICKfXxiwRkjnhEBNdkZJA(-2)
				{
					tNlBpfjwrMPeDcPDxWqLBLzjIXakA = this
				};
			}

			[IteratorStateMachine(typeof(JBzkTYvXzUTiwVbIlKiYxKvuWGOB))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new JBzkTYvXzUTiwVbIlKiYxKvuWGOB(-2)
				{
					LVvacyVzWGGWtHHldAEiOQtVCZyF = this
				};
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

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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

			private sealed class IBlQAVNqiwCVtugLonkgNoZvxbCG : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int BZADKUfBKWpiHtWsUPVUYZGniWBR;

				private Platform_Custom.Axis xiSrkoDjHqEdGCYGumkUEPwboEJIA;

				private int YShFCYJNeNbsZpnMZCBwIGKLyDPt;

				public Platform_InternalDriver_Base tECnkDVLEPPfJBjWqdaCFxSATmhQA;

				private int cyNfpVlvmzYkdgIzfJpkClPlQkyU;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return xiSrkoDjHqEdGCYGumkUEPwboEJIA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return xiSrkoDjHqEdGCYGumkUEPwboEJIA;
					}
				}

				[DebuggerHidden]
				public IBlQAVNqiwCVtugLonkgNoZvxbCG(int P_0)
				{
					BZADKUfBKWpiHtWsUPVUYZGniWBR = P_0;
					YShFCYJNeNbsZpnMZCBwIGKLyDPt = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int bZADKUfBKWpiHtWsUPVUYZGniWBR = BZADKUfBKWpiHtWsUPVUYZGniWBR;
					Platform_InternalDriver_Base platform_InternalDriver_Base = tECnkDVLEPPfJBjWqdaCFxSATmhQA;
					switch (bZADKUfBKWpiHtWsUPVUYZGniWBR)
					{
					default:
						return false;
					case 0:
						BZADKUfBKWpiHtWsUPVUYZGniWBR = -1;
						if (platform_InternalDriver_Base.elements == null || platform_InternalDriver_Base.elements.axes == null)
						{
							return false;
						}
						cyNfpVlvmzYkdgIzfJpkClPlQkyU = 0;
						break;
					case 1:
						BZADKUfBKWpiHtWsUPVUYZGniWBR = -1;
						cyNfpVlvmzYkdgIzfJpkClPlQkyU++;
						break;
					}
					if (cyNfpVlvmzYkdgIzfJpkClPlQkyU < platform_InternalDriver_Base.elements.axes.Length)
					{
						xiSrkoDjHqEdGCYGumkUEPwboEJIA = platform_InternalDriver_Base.elements.axes[cyNfpVlvmzYkdgIzfJpkClPlQkyU];
						BZADKUfBKWpiHtWsUPVUYZGniWBR = 1;
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
					IBlQAVNqiwCVtugLonkgNoZvxbCG blQAVNqiwCVtugLonkgNoZvxbCG;
					if (BZADKUfBKWpiHtWsUPVUYZGniWBR == -2 && YShFCYJNeNbsZpnMZCBwIGKLyDPt == Environment.CurrentManagedThreadId)
					{
						BZADKUfBKWpiHtWsUPVUYZGniWBR = 0;
						blQAVNqiwCVtugLonkgNoZvxbCG = this;
					}
					else
					{
						blQAVNqiwCVtugLonkgNoZvxbCG = new IBlQAVNqiwCVtugLonkgNoZvxbCG(0);
						blQAVNqiwCVtugLonkgNoZvxbCG.tECnkDVLEPPfJBjWqdaCFxSATmhQA = tECnkDVLEPPfJBjWqdaCFxSATmhQA;
					}
					return blQAVNqiwCVtugLonkgNoZvxbCG;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class IbUDRLfHqqdPVfpkKdxtsYrTawgG : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int UvorXNVaPskMYzNBKLrqkjMcsPoc;

				private Platform_Custom.Button QnWDZNAKIGzgItxlQxNfccmLvPRIA;

				private int cDdrNRALwgATQBXGqlvubxohTbawA;

				public Platform_InternalDriver_Base OfvcxwNTWFcmKkzNIGfPxxhodKsJ;

				private int alFynyfOYNHTnBYQQwSODEYTDgFB;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return QnWDZNAKIGzgItxlQxNfccmLvPRIA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return QnWDZNAKIGzgItxlQxNfccmLvPRIA;
					}
				}

				[DebuggerHidden]
				public IbUDRLfHqqdPVfpkKdxtsYrTawgG(int P_0)
				{
					UvorXNVaPskMYzNBKLrqkjMcsPoc = P_0;
					cDdrNRALwgATQBXGqlvubxohTbawA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int uvorXNVaPskMYzNBKLrqkjMcsPoc = UvorXNVaPskMYzNBKLrqkjMcsPoc;
					Platform_InternalDriver_Base ofvcxwNTWFcmKkzNIGfPxxhodKsJ = OfvcxwNTWFcmKkzNIGfPxxhodKsJ;
					switch (uvorXNVaPskMYzNBKLrqkjMcsPoc)
					{
					default:
						return false;
					case 0:
						UvorXNVaPskMYzNBKLrqkjMcsPoc = -1;
						if (ofvcxwNTWFcmKkzNIGfPxxhodKsJ.elements == null || ofvcxwNTWFcmKkzNIGfPxxhodKsJ.elements.buttons == null)
						{
							return false;
						}
						alFynyfOYNHTnBYQQwSODEYTDgFB = 0;
						break;
					case 1:
						UvorXNVaPskMYzNBKLrqkjMcsPoc = -1;
						alFynyfOYNHTnBYQQwSODEYTDgFB++;
						break;
					}
					if (alFynyfOYNHTnBYQQwSODEYTDgFB < ofvcxwNTWFcmKkzNIGfPxxhodKsJ.elements.buttons.Length)
					{
						QnWDZNAKIGzgItxlQxNfccmLvPRIA = ofvcxwNTWFcmKkzNIGfPxxhodKsJ.elements.buttons[alFynyfOYNHTnBYQQwSODEYTDgFB];
						UvorXNVaPskMYzNBKLrqkjMcsPoc = 1;
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
					IbUDRLfHqqdPVfpkKdxtsYrTawgG ibUDRLfHqqdPVfpkKdxtsYrTawgG;
					if (UvorXNVaPskMYzNBKLrqkjMcsPoc == -2 && cDdrNRALwgATQBXGqlvubxohTbawA == Environment.CurrentManagedThreadId)
					{
						UvorXNVaPskMYzNBKLrqkjMcsPoc = 0;
						ibUDRLfHqqdPVfpkKdxtsYrTawgG = this;
					}
					else
					{
						ibUDRLfHqqdPVfpkKdxtsYrTawgG = new IbUDRLfHqqdPVfpkKdxtsYrTawgG(0);
						ibUDRLfHqqdPVfpkKdxtsYrTawgG.OfvcxwNTWFcmKkzNIGfPxxhodKsJ = OfvcxwNTWFcmKkzNIGfPxxhodKsJ;
					}
					return ibUDRLfHqqdPVfpkKdxtsYrTawgG;
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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			[IteratorStateMachine(typeof(IBlQAVNqiwCVtugLonkgNoZvxbCG))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new IBlQAVNqiwCVtugLonkgNoZvxbCG(-2)
				{
					tECnkDVLEPPfJBjWqdaCFxSATmhQA = this
				};
			}

			[IteratorStateMachine(typeof(IbUDRLfHqqdPVfpkKdxtsYrTawgG))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new IbUDRLfHqqdPVfpkKdxtsYrTawgG(-2)
				{
					OfvcxwNTWFcmKkzNIGfPxxhodKsJ = this
				};
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

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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
						jxcSgBCAckNrIjPsBFiAMTdHLFuQ(elementCount);
						return elementCount;
					}

					internal void OxlCsinSsmFUORsDIbHoTiFIZspH(ElementCount_Base P_0)
					{
						base.jxcSgBCAckNrIjPsBFiAMTdHLFuQ(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool RzKcYKhRooatMBBgeBwqGyPeLvVLb(BridgedControllerHWInfo P_0)
					{
						if (!base.KhdgjMQnSkGAvAuHpiccCSGlQcYsA(P_0))
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
				private sealed class VqVERsFJlKpjYUnJBxmUeOsLwLtA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int fWAcCAaqTFYSUxlGvsluIIUmzPXs;

					private Axis MsVWnfZpWOBYTDyJyFsjIDdsUApn;

					private int BcLjQuBsbaslasUDlKOqgHwIpJhkB;

					public Elements bHJofWSMAXCyAqwMlZFESqbUgATK;

					private int IbaGmTfOdKkmlQcVzgtAGLJJjQRr;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return MsVWnfZpWOBYTDyJyFsjIDdsUApn;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return MsVWnfZpWOBYTDyJyFsjIDdsUApn;
						}
					}

					[DebuggerHidden]
					public VqVERsFJlKpjYUnJBxmUeOsLwLtA(int P_0)
					{
						fWAcCAaqTFYSUxlGvsluIIUmzPXs = P_0;
						BcLjQuBsbaslasUDlKOqgHwIpJhkB = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = fWAcCAaqTFYSUxlGvsluIIUmzPXs;
						Elements elements = bHJofWSMAXCyAqwMlZFESqbUgATK;
						switch (num)
						{
						default:
							return false;
						case 0:
							fWAcCAaqTFYSUxlGvsluIIUmzPXs = -1;
							if (elements.axes == null)
							{
								return false;
							}
							IbaGmTfOdKkmlQcVzgtAGLJJjQRr = 0;
							break;
						case 1:
							fWAcCAaqTFYSUxlGvsluIIUmzPXs = -1;
							IbaGmTfOdKkmlQcVzgtAGLJJjQRr++;
							break;
						}
						if (IbaGmTfOdKkmlQcVzgtAGLJJjQRr < elements.axes.Length)
						{
							MsVWnfZpWOBYTDyJyFsjIDdsUApn = elements.axes[IbaGmTfOdKkmlQcVzgtAGLJJjQRr];
							fWAcCAaqTFYSUxlGvsluIIUmzPXs = 1;
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
						VqVERsFJlKpjYUnJBxmUeOsLwLtA vqVERsFJlKpjYUnJBxmUeOsLwLtA;
						if (fWAcCAaqTFYSUxlGvsluIIUmzPXs == -2 && BcLjQuBsbaslasUDlKOqgHwIpJhkB == Environment.CurrentManagedThreadId)
						{
							fWAcCAaqTFYSUxlGvsluIIUmzPXs = 0;
							vqVERsFJlKpjYUnJBxmUeOsLwLtA = this;
						}
						else
						{
							vqVERsFJlKpjYUnJBxmUeOsLwLtA = new VqVERsFJlKpjYUnJBxmUeOsLwLtA(0);
							vqVERsFJlKpjYUnJBxmUeOsLwLtA.bHJofWSMAXCyAqwMlZFESqbUgATK = bHJofWSMAXCyAqwMlZFESqbUgATK;
						}
						return vqVERsFJlKpjYUnJBxmUeOsLwLtA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class RNmOSpabYMdbdpCujFXEatQfNNMyA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int tEvcsgkWTzhBavnQCiFNLbSaNkjHA;

					private Button mIfZNkMgJJsvdToSJZbrBlPoseyH;

					private int uYXWcQkOlCwVVEgIhpeuAlTAOoQG;

					public Elements ElaopjJDDaklIhGVSLIMSSLzplaQ;

					private int vqrvRrcljCBhMyBoUGvRKxUKcfUr;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return mIfZNkMgJJsvdToSJZbrBlPoseyH;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return mIfZNkMgJJsvdToSJZbrBlPoseyH;
						}
					}

					[DebuggerHidden]
					public RNmOSpabYMdbdpCujFXEatQfNNMyA(int P_0)
					{
						tEvcsgkWTzhBavnQCiFNLbSaNkjHA = P_0;
						uYXWcQkOlCwVVEgIhpeuAlTAOoQG = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = tEvcsgkWTzhBavnQCiFNLbSaNkjHA;
						Elements elaopjJDDaklIhGVSLIMSSLzplaQ = ElaopjJDDaklIhGVSLIMSSLzplaQ;
						switch (num)
						{
						default:
							return false;
						case 0:
							tEvcsgkWTzhBavnQCiFNLbSaNkjHA = -1;
							if (elaopjJDDaklIhGVSLIMSSLzplaQ.buttons == null)
							{
								return false;
							}
							vqrvRrcljCBhMyBoUGvRKxUKcfUr = 0;
							break;
						case 1:
							tEvcsgkWTzhBavnQCiFNLbSaNkjHA = -1;
							vqrvRrcljCBhMyBoUGvRKxUKcfUr++;
							break;
						}
						if (vqrvRrcljCBhMyBoUGvRKxUKcfUr < elaopjJDDaklIhGVSLIMSSLzplaQ.buttons.Length)
						{
							mIfZNkMgJJsvdToSJZbrBlPoseyH = elaopjJDDaklIhGVSLIMSSLzplaQ.buttons[vqrvRrcljCBhMyBoUGvRKxUKcfUr];
							tEvcsgkWTzhBavnQCiFNLbSaNkjHA = 1;
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
						RNmOSpabYMdbdpCujFXEatQfNNMyA rNmOSpabYMdbdpCujFXEatQfNNMyA;
						if (tEvcsgkWTzhBavnQCiFNLbSaNkjHA == -2 && uYXWcQkOlCwVVEgIhpeuAlTAOoQG == Environment.CurrentManagedThreadId)
						{
							tEvcsgkWTzhBavnQCiFNLbSaNkjHA = 0;
							rNmOSpabYMdbdpCujFXEatQfNNMyA = this;
						}
						else
						{
							rNmOSpabYMdbdpCujFXEatQfNNMyA = new RNmOSpabYMdbdpCujFXEatQfNNMyA(0);
							rNmOSpabYMdbdpCujFXEatQfNNMyA.ElaopjJDDaklIhGVSLIMSSLzplaQ = ElaopjJDDaklIhGVSLIMSSLzplaQ;
						}
						return rNmOSpabYMdbdpCujFXEatQfNNMyA;
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
					[IteratorStateMachine(typeof(VqVERsFJlKpjYUnJBxmUeOsLwLtA))]
					get
					{
						return new VqVERsFJlKpjYUnJBxmUeOsLwLtA(-2)
						{
							bHJofWSMAXCyAqwMlZFESqbUgATK = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(RNmOSpabYMdbdpCujFXEatQfNNMyA))]
					get
					{
						return new RNmOSpabYMdbdpCujFXEatQfNNMyA(-2)
						{
							ElaopjJDDaklIhGVSLIMSSLzplaQ = this
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

			private sealed class XuuZTZgFsoVaRckzTtsasCHpaXlZ : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int ZLBhCykcpSvVonrAhowbTwQaUpKmA;

				private Axis WQbwQNKaGXiyDgBeBoOkRoHxvLJZ;

				private int WKyrWmRdbYLeDfZvBjgEINnNznTH;

				public Platform_SDL2_Base sGkTjLbgIWsaYdCBuuRKudAEiZaM;

				private int qfPUMBXswJmKcProHGcWHvdTrlYab;

				private int QVPEnBwrGEnbKrMAJcsxoNSyXufP;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return WQbwQNKaGXiyDgBeBoOkRoHxvLJZ;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return WQbwQNKaGXiyDgBeBoOkRoHxvLJZ;
					}
				}

				[DebuggerHidden]
				public XuuZTZgFsoVaRckzTtsasCHpaXlZ(int P_0)
				{
					ZLBhCykcpSvVonrAhowbTwQaUpKmA = P_0;
					WKyrWmRdbYLeDfZvBjgEINnNznTH = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int zLBhCykcpSvVonrAhowbTwQaUpKmA = ZLBhCykcpSvVonrAhowbTwQaUpKmA;
					Platform_SDL2_Base platform_SDL2_Base = sGkTjLbgIWsaYdCBuuRKudAEiZaM;
					switch (zLBhCykcpSvVonrAhowbTwQaUpKmA)
					{
					default:
						return false;
					case 0:
						ZLBhCykcpSvVonrAhowbTwQaUpKmA = -1;
						if (platform_SDL2_Base.elements == null || platform_SDL2_Base.elements.axes == null)
						{
							return false;
						}
						qfPUMBXswJmKcProHGcWHvdTrlYab = platform_SDL2_Base.elements.axes.Length;
						QVPEnBwrGEnbKrMAJcsxoNSyXufP = 0;
						break;
					case 1:
						ZLBhCykcpSvVonrAhowbTwQaUpKmA = -1;
						QVPEnBwrGEnbKrMAJcsxoNSyXufP++;
						break;
					}
					if (QVPEnBwrGEnbKrMAJcsxoNSyXufP < qfPUMBXswJmKcProHGcWHvdTrlYab)
					{
						WQbwQNKaGXiyDgBeBoOkRoHxvLJZ = platform_SDL2_Base.elements.axes[QVPEnBwrGEnbKrMAJcsxoNSyXufP];
						ZLBhCykcpSvVonrAhowbTwQaUpKmA = 1;
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
					XuuZTZgFsoVaRckzTtsasCHpaXlZ xuuZTZgFsoVaRckzTtsasCHpaXlZ;
					if (ZLBhCykcpSvVonrAhowbTwQaUpKmA == -2 && WKyrWmRdbYLeDfZvBjgEINnNznTH == Environment.CurrentManagedThreadId)
					{
						ZLBhCykcpSvVonrAhowbTwQaUpKmA = 0;
						xuuZTZgFsoVaRckzTtsasCHpaXlZ = this;
					}
					else
					{
						xuuZTZgFsoVaRckzTtsasCHpaXlZ = new XuuZTZgFsoVaRckzTtsasCHpaXlZ(0);
						xuuZTZgFsoVaRckzTtsasCHpaXlZ.sGkTjLbgIWsaYdCBuuRKudAEiZaM = sGkTjLbgIWsaYdCBuuRKudAEiZaM;
					}
					return xuuZTZgFsoVaRckzTtsasCHpaXlZ;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class wOOgQpdrGLBpyEmxFkeXwimCQwDb : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int GjMaBmOijbDJehwzsEKnPyCkLpMY;

				private Button BGGckwAheSVVSxteKHlgLlOZDPKV;

				private int LmATwgpdVsXhmfZvAjhUvOydKLCf;

				public Platform_SDL2_Base zdPQcmqFfPrzkMCDZAICIwTZQxRIA;

				private int zZnRicFwNzpsJgyhMJAVdkgvsLqu;

				private int aALiAXfpxlPSbREpKfXYimuxdisBb;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return BGGckwAheSVVSxteKHlgLlOZDPKV;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return BGGckwAheSVVSxteKHlgLlOZDPKV;
					}
				}

				[DebuggerHidden]
				public wOOgQpdrGLBpyEmxFkeXwimCQwDb(int P_0)
				{
					GjMaBmOijbDJehwzsEKnPyCkLpMY = P_0;
					LmATwgpdVsXhmfZvAjhUvOydKLCf = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int gjMaBmOijbDJehwzsEKnPyCkLpMY = GjMaBmOijbDJehwzsEKnPyCkLpMY;
					Platform_SDL2_Base platform_SDL2_Base = zdPQcmqFfPrzkMCDZAICIwTZQxRIA;
					switch (gjMaBmOijbDJehwzsEKnPyCkLpMY)
					{
					default:
						return false;
					case 0:
						GjMaBmOijbDJehwzsEKnPyCkLpMY = -1;
						if (platform_SDL2_Base.elements == null || platform_SDL2_Base.elements.buttons == null)
						{
							return false;
						}
						zZnRicFwNzpsJgyhMJAVdkgvsLqu = platform_SDL2_Base.elements.buttons.Length;
						aALiAXfpxlPSbREpKfXYimuxdisBb = 0;
						break;
					case 1:
						GjMaBmOijbDJehwzsEKnPyCkLpMY = -1;
						aALiAXfpxlPSbREpKfXYimuxdisBb++;
						break;
					}
					if (aALiAXfpxlPSbREpKfXYimuxdisBb < zZnRicFwNzpsJgyhMJAVdkgvsLqu)
					{
						BGGckwAheSVVSxteKHlgLlOZDPKV = platform_SDL2_Base.elements.buttons[aALiAXfpxlPSbREpKfXYimuxdisBb];
						GjMaBmOijbDJehwzsEKnPyCkLpMY = 1;
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
					wOOgQpdrGLBpyEmxFkeXwimCQwDb wOOgQpdrGLBpyEmxFkeXwimCQwDb2;
					if (GjMaBmOijbDJehwzsEKnPyCkLpMY == -2 && LmATwgpdVsXhmfZvAjhUvOydKLCf == Environment.CurrentManagedThreadId)
					{
						GjMaBmOijbDJehwzsEKnPyCkLpMY = 0;
						wOOgQpdrGLBpyEmxFkeXwimCQwDb2 = this;
					}
					else
					{
						wOOgQpdrGLBpyEmxFkeXwimCQwDb2 = new wOOgQpdrGLBpyEmxFkeXwimCQwDb(0);
						wOOgQpdrGLBpyEmxFkeXwimCQwDb2.zdPQcmqFfPrzkMCDZAICIwTZQxRIA = zdPQcmqFfPrzkMCDZAICIwTZQxRIA;
					}
					return wOOgQpdrGLBpyEmxFkeXwimCQwDb2;
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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			[IteratorStateMachine(typeof(XuuZTZgFsoVaRckzTtsasCHpaXlZ))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new XuuZTZgFsoVaRckzTtsasCHpaXlZ(-2)
				{
					sGkTjLbgIWsaYdCBuuRKudAEiZaM = this
				};
			}

			[IteratorStateMachine(typeof(wOOgQpdrGLBpyEmxFkeXwimCQwDb))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new wOOgQpdrGLBpyEmxFkeXwimCQwDb(-2)
				{
					zdPQcmqFfPrzkMCDZAICIwTZQxRIA = this
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

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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

			private sealed class QYGTscNDTkeLeWiOMItemzgKoNvE : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int iTQLmLDLqEQgZFbNUeyoADdBIcEiA;

				private Platform_Custom.Axis SALAuwRJkmQTGFtzvjOPiGNQuTnQ;

				private int FLZFwTdVbHIopLVtrwEosZjVmWjiA;

				public Platform_WebGL_Base YSsitVDEpCiSBfFiDpHrbvJsybnC;

				private int IISkBpWQQtyONnZueYSbkXlPBRie;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return SALAuwRJkmQTGFtzvjOPiGNQuTnQ;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return SALAuwRJkmQTGFtzvjOPiGNQuTnQ;
					}
				}

				[DebuggerHidden]
				public QYGTscNDTkeLeWiOMItemzgKoNvE(int P_0)
				{
					iTQLmLDLqEQgZFbNUeyoADdBIcEiA = P_0;
					FLZFwTdVbHIopLVtrwEosZjVmWjiA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = iTQLmLDLqEQgZFbNUeyoADdBIcEiA;
					Platform_WebGL_Base ySsitVDEpCiSBfFiDpHrbvJsybnC = YSsitVDEpCiSBfFiDpHrbvJsybnC;
					switch (num)
					{
					default:
						return false;
					case 0:
						iTQLmLDLqEQgZFbNUeyoADdBIcEiA = -1;
						if (ySsitVDEpCiSBfFiDpHrbvJsybnC.elements == null || ySsitVDEpCiSBfFiDpHrbvJsybnC.elements.axes == null)
						{
							return false;
						}
						IISkBpWQQtyONnZueYSbkXlPBRie = 0;
						break;
					case 1:
						iTQLmLDLqEQgZFbNUeyoADdBIcEiA = -1;
						IISkBpWQQtyONnZueYSbkXlPBRie++;
						break;
					}
					if (IISkBpWQQtyONnZueYSbkXlPBRie < ySsitVDEpCiSBfFiDpHrbvJsybnC.elements.axes.Length)
					{
						SALAuwRJkmQTGFtzvjOPiGNQuTnQ = ySsitVDEpCiSBfFiDpHrbvJsybnC.elements.axes[IISkBpWQQtyONnZueYSbkXlPBRie];
						iTQLmLDLqEQgZFbNUeyoADdBIcEiA = 1;
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
					QYGTscNDTkeLeWiOMItemzgKoNvE qYGTscNDTkeLeWiOMItemzgKoNvE;
					if (iTQLmLDLqEQgZFbNUeyoADdBIcEiA == -2 && FLZFwTdVbHIopLVtrwEosZjVmWjiA == Environment.CurrentManagedThreadId)
					{
						iTQLmLDLqEQgZFbNUeyoADdBIcEiA = 0;
						qYGTscNDTkeLeWiOMItemzgKoNvE = this;
					}
					else
					{
						qYGTscNDTkeLeWiOMItemzgKoNvE = new QYGTscNDTkeLeWiOMItemzgKoNvE(0);
						qYGTscNDTkeLeWiOMItemzgKoNvE.YSsitVDEpCiSBfFiDpHrbvJsybnC = YSsitVDEpCiSBfFiDpHrbvJsybnC;
					}
					return qYGTscNDTkeLeWiOMItemzgKoNvE;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class hDBnmqEppGhYwwIMzlgVUEBhEQGP : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int cLRRljIGPwINYMnFGpdofLQdMSZs;

				private Platform_Custom.Button mcHXKXspEeCppsHatqemqwQOJMVQ;

				private int tdxqFqGShaNvQLfsdiHIMUiQOxeT;

				public Platform_WebGL_Base PDVOYhfxrghIuLnMZvwRngsXEWfe;

				private int NCDTbwePAKdaqjfMfhLvGBCIXHwB;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return mcHXKXspEeCppsHatqemqwQOJMVQ;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return mcHXKXspEeCppsHatqemqwQOJMVQ;
					}
				}

				[DebuggerHidden]
				public hDBnmqEppGhYwwIMzlgVUEBhEQGP(int P_0)
				{
					cLRRljIGPwINYMnFGpdofLQdMSZs = P_0;
					tdxqFqGShaNvQLfsdiHIMUiQOxeT = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = cLRRljIGPwINYMnFGpdofLQdMSZs;
					Platform_WebGL_Base pDVOYhfxrghIuLnMZvwRngsXEWfe = PDVOYhfxrghIuLnMZvwRngsXEWfe;
					switch (num)
					{
					default:
						return false;
					case 0:
						cLRRljIGPwINYMnFGpdofLQdMSZs = -1;
						if (pDVOYhfxrghIuLnMZvwRngsXEWfe.elements == null || pDVOYhfxrghIuLnMZvwRngsXEWfe.elements.buttons == null)
						{
							return false;
						}
						NCDTbwePAKdaqjfMfhLvGBCIXHwB = 0;
						break;
					case 1:
						cLRRljIGPwINYMnFGpdofLQdMSZs = -1;
						NCDTbwePAKdaqjfMfhLvGBCIXHwB++;
						break;
					}
					if (NCDTbwePAKdaqjfMfhLvGBCIXHwB < pDVOYhfxrghIuLnMZvwRngsXEWfe.elements.buttons.Length)
					{
						mcHXKXspEeCppsHatqemqwQOJMVQ = pDVOYhfxrghIuLnMZvwRngsXEWfe.elements.buttons[NCDTbwePAKdaqjfMfhLvGBCIXHwB];
						cLRRljIGPwINYMnFGpdofLQdMSZs = 1;
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
					hDBnmqEppGhYwwIMzlgVUEBhEQGP hDBnmqEppGhYwwIMzlgVUEBhEQGP2;
					if (cLRRljIGPwINYMnFGpdofLQdMSZs == -2 && tdxqFqGShaNvQLfsdiHIMUiQOxeT == Environment.CurrentManagedThreadId)
					{
						cLRRljIGPwINYMnFGpdofLQdMSZs = 0;
						hDBnmqEppGhYwwIMzlgVUEBhEQGP2 = this;
					}
					else
					{
						hDBnmqEppGhYwwIMzlgVUEBhEQGP2 = new hDBnmqEppGhYwwIMzlgVUEBhEQGP(0);
						hDBnmqEppGhYwwIMzlgVUEBhEQGP2.PDVOYhfxrghIuLnMZvwRngsXEWfe = PDVOYhfxrghIuLnMZvwRngsXEWfe;
					}
					return hDBnmqEppGhYwwIMzlgVUEBhEQGP2;
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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			[IteratorStateMachine(typeof(QYGTscNDTkeLeWiOMItemzgKoNvE))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new QYGTscNDTkeLeWiOMItemzgKoNvE(-2)
				{
					YSsitVDEpCiSBfFiDpHrbvJsybnC = this
				};
			}

			[IteratorStateMachine(typeof(hDBnmqEppGhYwwIMzlgVUEBhEQGP))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new hDBnmqEppGhYwwIMzlgVUEBhEQGP(-2)
				{
					PDVOYhfxrghIuLnMZvwRngsXEWfe = this
				};
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

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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

				public bool productName_useRegex;

				public string[] productName;

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
						if (productName != null && productName.Length != 0)
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
					bool flag = HasProductName();
					bool flag2 = HasProductCategory();
					bool result = false;
					if (primaryProfileType != AppleGCControllerProfileTypeFlags.None)
					{
						if (((uint)bridgedControllerHWInfo.deviceType & (uint)primaryProfileType) == 0)
						{
							return false;
						}
						if (profileSubTypes != null && profileSubTypes.Length != 0)
						{
							bool flag3 = false;
							for (int i = 0; i < profileSubTypes.Length; i++)
							{
								if (profileSubTypes[i] == (AppleGCControllerProfileSubType)bridgedControllerHWInfo.hw_xInputSubType)
								{
									flag3 = true;
									break;
								}
							}
							if (!flag3)
							{
								return false;
							}
						}
						result = true;
					}
					bool flag4 = false;
					if (flag2)
					{
						flag4 = true;
						if (!string.IsNullOrEmpty(bridgedControllerHWInfo.hw_systemDeviceName) && ProductCategoryMatches(bridgedControllerHWInfo.hw_systemDeviceName.Trim()))
						{
							return true;
						}
					}
					if (flag)
					{
						flag4 = true;
						if (!string.IsNullOrEmpty(bridgedControllerHWInfo.hw_productName) && ProductNameMatches(bridgedControllerHWInfo.hw_productName.Trim()))
						{
							return true;
						}
					}
					if (flag4)
					{
						return false;
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
						matchingCriteria.productName_useRegex = productName_useRegex;
						matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
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

			private sealed class CMvUNzsSNfWbRZIkCRlsOFILvnIw : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int vvFNxCCBHQdUlVDKAwWWRzMjdXre;

				private Platform_Custom.Axis DvvEAWsJEhZwkDpEUXlJLCJtJhQd;

				private int NtuCGmmvTrFZOiPgeJLRQtnJgTHR;

				public Platform_AppleGCController_Base daWkEcZNGcImZydwOTYNfsPpyOGi;

				private int xllNVGgDnZWeAUejXWhTSqtZceObA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return DvvEAWsJEhZwkDpEUXlJLCJtJhQd;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return DvvEAWsJEhZwkDpEUXlJLCJtJhQd;
					}
				}

				[DebuggerHidden]
				public CMvUNzsSNfWbRZIkCRlsOFILvnIw(int P_0)
				{
					vvFNxCCBHQdUlVDKAwWWRzMjdXre = P_0;
					NtuCGmmvTrFZOiPgeJLRQtnJgTHR = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = vvFNxCCBHQdUlVDKAwWWRzMjdXre;
					Platform_AppleGCController_Base platform_AppleGCController_Base = daWkEcZNGcImZydwOTYNfsPpyOGi;
					switch (num)
					{
					default:
						return false;
					case 0:
						vvFNxCCBHQdUlVDKAwWWRzMjdXre = -1;
						if (platform_AppleGCController_Base.elements == null || platform_AppleGCController_Base.elements.axes == null)
						{
							return false;
						}
						xllNVGgDnZWeAUejXWhTSqtZceObA = 0;
						break;
					case 1:
						vvFNxCCBHQdUlVDKAwWWRzMjdXre = -1;
						xllNVGgDnZWeAUejXWhTSqtZceObA++;
						break;
					}
					if (xllNVGgDnZWeAUejXWhTSqtZceObA < platform_AppleGCController_Base.elements.axes.Length)
					{
						DvvEAWsJEhZwkDpEUXlJLCJtJhQd = platform_AppleGCController_Base.elements.axes[xllNVGgDnZWeAUejXWhTSqtZceObA];
						vvFNxCCBHQdUlVDKAwWWRzMjdXre = 1;
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
					CMvUNzsSNfWbRZIkCRlsOFILvnIw cMvUNzsSNfWbRZIkCRlsOFILvnIw;
					if (vvFNxCCBHQdUlVDKAwWWRzMjdXre == -2 && NtuCGmmvTrFZOiPgeJLRQtnJgTHR == Environment.CurrentManagedThreadId)
					{
						vvFNxCCBHQdUlVDKAwWWRzMjdXre = 0;
						cMvUNzsSNfWbRZIkCRlsOFILvnIw = this;
					}
					else
					{
						cMvUNzsSNfWbRZIkCRlsOFILvnIw = new CMvUNzsSNfWbRZIkCRlsOFILvnIw(0);
						cMvUNzsSNfWbRZIkCRlsOFILvnIw.daWkEcZNGcImZydwOTYNfsPpyOGi = daWkEcZNGcImZydwOTYNfsPpyOGi;
					}
					return cMvUNzsSNfWbRZIkCRlsOFILvnIw;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class VgHgHKgoZDMotDrQkZcBJSuhWfAvA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int SigNbZoimKaIjlZjcxvwRiQOgmSX;

				private Platform_Custom.Button vKBnisTlrheZStkgAHzotqMKQFWr;

				private int MWyBFRPxmwWsHQoCKCDysCoqIQdS;

				public Platform_AppleGCController_Base isXEyLaYPgZNnxZXvyEhjqJosqRK;

				private int EphGlmPXCDyWwZumHLagObCwtNBS;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vKBnisTlrheZStkgAHzotqMKQFWr;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vKBnisTlrheZStkgAHzotqMKQFWr;
					}
				}

				[DebuggerHidden]
				public VgHgHKgoZDMotDrQkZcBJSuhWfAvA(int P_0)
				{
					SigNbZoimKaIjlZjcxvwRiQOgmSX = P_0;
					MWyBFRPxmwWsHQoCKCDysCoqIQdS = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int sigNbZoimKaIjlZjcxvwRiQOgmSX = SigNbZoimKaIjlZjcxvwRiQOgmSX;
					Platform_AppleGCController_Base platform_AppleGCController_Base = isXEyLaYPgZNnxZXvyEhjqJosqRK;
					switch (sigNbZoimKaIjlZjcxvwRiQOgmSX)
					{
					default:
						return false;
					case 0:
						SigNbZoimKaIjlZjcxvwRiQOgmSX = -1;
						if (platform_AppleGCController_Base.elements == null || platform_AppleGCController_Base.elements.buttons == null)
						{
							return false;
						}
						EphGlmPXCDyWwZumHLagObCwtNBS = 0;
						break;
					case 1:
						SigNbZoimKaIjlZjcxvwRiQOgmSX = -1;
						EphGlmPXCDyWwZumHLagObCwtNBS++;
						break;
					}
					if (EphGlmPXCDyWwZumHLagObCwtNBS < platform_AppleGCController_Base.elements.buttons.Length)
					{
						vKBnisTlrheZStkgAHzotqMKQFWr = platform_AppleGCController_Base.elements.buttons[EphGlmPXCDyWwZumHLagObCwtNBS];
						SigNbZoimKaIjlZjcxvwRiQOgmSX = 1;
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
					VgHgHKgoZDMotDrQkZcBJSuhWfAvA vgHgHKgoZDMotDrQkZcBJSuhWfAvA;
					if (SigNbZoimKaIjlZjcxvwRiQOgmSX == -2 && MWyBFRPxmwWsHQoCKCDysCoqIQdS == Environment.CurrentManagedThreadId)
					{
						SigNbZoimKaIjlZjcxvwRiQOgmSX = 0;
						vgHgHKgoZDMotDrQkZcBJSuhWfAvA = this;
					}
					else
					{
						vgHgHKgoZDMotDrQkZcBJSuhWfAvA = new VgHgHKgoZDMotDrQkZcBJSuhWfAvA(0);
						vgHgHKgoZDMotDrQkZcBJSuhWfAvA.isXEyLaYPgZNnxZXvyEhjqJosqRK = isXEyLaYPgZNnxZXvyEhjqJosqRK;
					}
					return vgHgHKgoZDMotDrQkZcBJSuhWfAvA;
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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			[IteratorStateMachine(typeof(CMvUNzsSNfWbRZIkCRlsOFILvnIw))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new CMvUNzsSNfWbRZIkCRlsOFILvnIw(-2)
				{
					daWkEcZNGcImZydwOTYNfsPpyOGi = this
				};
			}

			[IteratorStateMachine(typeof(VgHgHKgoZDMotDrQkZcBJSuhWfAvA))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new VgHgHKgoZDMotDrQkZcBJSuhWfAvA(-2)
				{
					isXEyLaYPgZNnxZXvyEhjqJosqRK = this
				};
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

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_WindowsWGI_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				public VidPid[] vidPid;

				public DeviceType deviceType;

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
					if ((!string.IsNullOrEmpty(bridgedControllerHWInfo.definitionMatchTag) || !string.IsNullOrEmpty(tag)) && !string.Equals(bridgedControllerHWInfo.definitionMatchTag, tag, StringComparison.OrdinalIgnoreCase))
					{
						return false;
					}
					if (deviceType != DeviceType.None)
					{
						if (deviceType != (DeviceType)bridgedControllerHWInfo.deviceType)
						{
							return false;
						}
						if (!HasProductName() && (vidPid == null || vidPid.Length == 0))
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
								if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_pidVid.vendorId))
								{
									string name = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
									if (!ProductNameMatches(name))
									{
										return false;
									}
								}
								if ((vendorId < 0 || bridgedControllerHWInfo.hw_pidVid.vendorId == vendorId) && (productId < 0 || bridgedControllerHWInfo.hw_pidVid.productId == productId))
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
				Gamepad = 1
			}

			private sealed class GKPeUHbbSDrNKKnNvBRgEAdwTKSWA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int CgsSjqaiMGMEporKBKhIfDtysBZW;

				private Platform_Custom.Axis WPOZpdCSbasmAsppIATUbyoaSTrsA;

				private int EwpEnvplpeIkqhKCvUQytlfjWpDh;

				public Platform_WindowsWGI_Base VItbaSULwobfXDafZpQLndjUWkIL;

				private int boXLNLEXVWWqrQiJyCgVJuuqkohd;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return WPOZpdCSbasmAsppIATUbyoaSTrsA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return WPOZpdCSbasmAsppIATUbyoaSTrsA;
					}
				}

				[DebuggerHidden]
				public GKPeUHbbSDrNKKnNvBRgEAdwTKSWA(int P_0)
				{
					CgsSjqaiMGMEporKBKhIfDtysBZW = P_0;
					EwpEnvplpeIkqhKCvUQytlfjWpDh = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int cgsSjqaiMGMEporKBKhIfDtysBZW = CgsSjqaiMGMEporKBKhIfDtysBZW;
					Platform_WindowsWGI_Base vItbaSULwobfXDafZpQLndjUWkIL = VItbaSULwobfXDafZpQLndjUWkIL;
					switch (cgsSjqaiMGMEporKBKhIfDtysBZW)
					{
					default:
						return false;
					case 0:
						CgsSjqaiMGMEporKBKhIfDtysBZW = -1;
						if (vItbaSULwobfXDafZpQLndjUWkIL.elements == null || vItbaSULwobfXDafZpQLndjUWkIL.elements.axes == null)
						{
							return false;
						}
						boXLNLEXVWWqrQiJyCgVJuuqkohd = 0;
						break;
					case 1:
						CgsSjqaiMGMEporKBKhIfDtysBZW = -1;
						boXLNLEXVWWqrQiJyCgVJuuqkohd++;
						break;
					}
					if (boXLNLEXVWWqrQiJyCgVJuuqkohd < vItbaSULwobfXDafZpQLndjUWkIL.elements.axes.Length)
					{
						WPOZpdCSbasmAsppIATUbyoaSTrsA = vItbaSULwobfXDafZpQLndjUWkIL.elements.axes[boXLNLEXVWWqrQiJyCgVJuuqkohd];
						CgsSjqaiMGMEporKBKhIfDtysBZW = 1;
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
					GKPeUHbbSDrNKKnNvBRgEAdwTKSWA gKPeUHbbSDrNKKnNvBRgEAdwTKSWA;
					if (CgsSjqaiMGMEporKBKhIfDtysBZW == -2 && EwpEnvplpeIkqhKCvUQytlfjWpDh == Environment.CurrentManagedThreadId)
					{
						CgsSjqaiMGMEporKBKhIfDtysBZW = 0;
						gKPeUHbbSDrNKKnNvBRgEAdwTKSWA = this;
					}
					else
					{
						gKPeUHbbSDrNKKnNvBRgEAdwTKSWA = new GKPeUHbbSDrNKKnNvBRgEAdwTKSWA(0);
						gKPeUHbbSDrNKKnNvBRgEAdwTKSWA.VItbaSULwobfXDafZpQLndjUWkIL = VItbaSULwobfXDafZpQLndjUWkIL;
					}
					return gKPeUHbbSDrNKKnNvBRgEAdwTKSWA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class EaFHLAqGGnbEGZkBuxcqHiYrXiPl : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int klGbXQCuasVNZbgfiuWbpbmlioWo;

				private Platform_Custom.Button hgxBhjYIdfwUlsASyHoaaioHStVJ;

				private int sNvyFyemIZGOlJlxlmttVHQpJbXzA;

				public Platform_WindowsWGI_Base WpzdcHJsJiMLkWvTUYNVdaalnouY;

				private int dCaAAJATUqtXtVgXhxhcHrJeejPN;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return hgxBhjYIdfwUlsASyHoaaioHStVJ;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return hgxBhjYIdfwUlsASyHoaaioHStVJ;
					}
				}

				[DebuggerHidden]
				public EaFHLAqGGnbEGZkBuxcqHiYrXiPl(int P_0)
				{
					klGbXQCuasVNZbgfiuWbpbmlioWo = P_0;
					sNvyFyemIZGOlJlxlmttVHQpJbXzA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = klGbXQCuasVNZbgfiuWbpbmlioWo;
					Platform_WindowsWGI_Base wpzdcHJsJiMLkWvTUYNVdaalnouY = WpzdcHJsJiMLkWvTUYNVdaalnouY;
					switch (num)
					{
					default:
						return false;
					case 0:
						klGbXQCuasVNZbgfiuWbpbmlioWo = -1;
						if (wpzdcHJsJiMLkWvTUYNVdaalnouY.elements == null || wpzdcHJsJiMLkWvTUYNVdaalnouY.elements.buttons == null)
						{
							return false;
						}
						dCaAAJATUqtXtVgXhxhcHrJeejPN = 0;
						break;
					case 1:
						klGbXQCuasVNZbgfiuWbpbmlioWo = -1;
						dCaAAJATUqtXtVgXhxhcHrJeejPN++;
						break;
					}
					if (dCaAAJATUqtXtVgXhxhcHrJeejPN < wpzdcHJsJiMLkWvTUYNVdaalnouY.elements.buttons.Length)
					{
						hgxBhjYIdfwUlsASyHoaaioHStVJ = wpzdcHJsJiMLkWvTUYNVdaalnouY.elements.buttons[dCaAAJATUqtXtVgXhxhcHrJeejPN];
						klGbXQCuasVNZbgfiuWbpbmlioWo = 1;
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
					EaFHLAqGGnbEGZkBuxcqHiYrXiPl eaFHLAqGGnbEGZkBuxcqHiYrXiPl;
					if (klGbXQCuasVNZbgfiuWbpbmlioWo == -2 && sNvyFyemIZGOlJlxlmttVHQpJbXzA == Environment.CurrentManagedThreadId)
					{
						klGbXQCuasVNZbgfiuWbpbmlioWo = 0;
						eaFHLAqGGnbEGZkBuxcqHiYrXiPl = this;
					}
					else
					{
						eaFHLAqGGnbEGZkBuxcqHiYrXiPl = new EaFHLAqGGnbEGZkBuxcqHiYrXiPl(0);
						eaFHLAqGGnbEGZkBuxcqHiYrXiPl.WpzdcHJsJiMLkWvTUYNVdaalnouY = WpzdcHJsJiMLkWvTUYNVdaalnouY;
					}
					return eaFHLAqGGnbEGZkBuxcqHiYrXiPl;
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

			InputPlatform Platform.platform => InputPlatform.WindowsWGI;

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

			public override IList<Platform> GetVariants()
			{
				return null;
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

			[IteratorStateMachine(typeof(GKPeUHbbSDrNKKnNvBRgEAdwTKSWA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new GKPeUHbbSDrNKKnNvBRgEAdwTKSWA(-2)
				{
					VItbaSULwobfXDafZpQLndjUWkIL = this
				};
			}

			[IteratorStateMachine(typeof(EaFHLAqGGnbEGZkBuxcqHiYrXiPl))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new EaFHLAqGGnbEGZkBuxcqHiYrXiPl(-2)
				{
					WpzdcHJsJiMLkWvTUYNVdaalnouY = this
				};
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
				Platform_WindowsWGI_Base platform_WindowsWGI_Base = new Platform_WindowsWGI_Base();
				CopyVars(platform_WindowsWGI_Base);
				return platform_WindowsWGI_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_WindowsWGI_Base platform_WindowsWGI_Base)
				{
					platform_WindowsWGI_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
					platform_WindowsWGI_Base.elements = MiscTools.DeepClone(elements);
					platform_WindowsWGI_Base.controllerName = controllerName;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_WindowsWGI : Platform_WindowsWGI_Base
		{
			public Platform_WindowsWGI_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return variants;
			}

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
				Platform_WindowsWGI platform_WindowsWGI = new Platform_WindowsWGI();
				CopyVars(platform_WindowsWGI);
				return platform_WindowsWGI;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_WindowsWGI platform_WindowsWGI)
				{
					platform_WindowsWGI.variants = MiscTools.DeepClone(variants);
				}
			}

			internal static Platform_WindowsWGI CreateDefaultMap(BridgedControllerHWInfo bridgedController)
			{
				Platform_WindowsWGI platform_WindowsWGI = new Platform_WindowsWGI();
				_ = Consts.unknownJoystickElementIdentifiers_orig;
				platform_WindowsWGI.controllerName = "Unknown Controller";
				platform_WindowsWGI.description = "";
				Elements elements = (platform_WindowsWGI.elements = new Elements());
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
				int num3 = 16 * 8;
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
				for (int k = 0; k < 16; k++)
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
				platform_WindowsWGI.matchingCriteria = matchingCriteria;
				platform_WindowsWGI.variants = new Platform_WindowsWGI_Base[0];
				return platform_WindowsWGI;
			}
		}

		private sealed class uoSUifqzertDkypJNTzZbfKrlfRh : IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerable, IEnumerator<IControllerElementIdentifierCommon_Internal>, IEnumerator, IDisposable
		{
			private int tnSJMRoDQxQrsMkMfpmisQsGhGuv;

			private IControllerElementIdentifierCommon_Internal GDLOOhnDUBJraJrWxUSSlidNMkOs;

			private int cKTUJArigYHGfbgrLRDaEobZMwPL;

			public HardwareJoystickMap fpLMkhBwYrQCOaUcoChJaHglaycHA;

			private int eqhnFjhTaGNTVpdrvGkCnqyKnfuM;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
			{
				[DebuggerHidden]
				get
				{
					return GDLOOhnDUBJraJrWxUSSlidNMkOs;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return GDLOOhnDUBJraJrWxUSSlidNMkOs;
				}
			}

			[DebuggerHidden]
			public uoSUifqzertDkypJNTzZbfKrlfRh(int P_0)
			{
				tnSJMRoDQxQrsMkMfpmisQsGhGuv = P_0;
				cKTUJArigYHGfbgrLRDaEobZMwPL = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = tnSJMRoDQxQrsMkMfpmisQsGhGuv;
				HardwareJoystickMap hardwareJoystickMap = fpLMkhBwYrQCOaUcoChJaHglaycHA;
				switch (num)
				{
				default:
					return false;
				case 0:
					tnSJMRoDQxQrsMkMfpmisQsGhGuv = -1;
					if (hardwareJoystickMap.elementIdentifiers == null)
					{
						return false;
					}
					eqhnFjhTaGNTVpdrvGkCnqyKnfuM = 0;
					break;
				case 1:
					tnSJMRoDQxQrsMkMfpmisQsGhGuv = -1;
					eqhnFjhTaGNTVpdrvGkCnqyKnfuM++;
					break;
				}
				if (eqhnFjhTaGNTVpdrvGkCnqyKnfuM < hardwareJoystickMap.elementIdentifiers.Length)
				{
					GDLOOhnDUBJraJrWxUSSlidNMkOs = hardwareJoystickMap.elementIdentifiers[eqhnFjhTaGNTVpdrvGkCnqyKnfuM];
					tnSJMRoDQxQrsMkMfpmisQsGhGuv = 1;
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
				uoSUifqzertDkypJNTzZbfKrlfRh uoSUifqzertDkypJNTzZbfKrlfRh2;
				if (tnSJMRoDQxQrsMkMfpmisQsGhGuv == -2 && cKTUJArigYHGfbgrLRDaEobZMwPL == Environment.CurrentManagedThreadId)
				{
					tnSJMRoDQxQrsMkMfpmisQsGhGuv = 0;
					uoSUifqzertDkypJNTzZbfKrlfRh2 = this;
				}
				else
				{
					uoSUifqzertDkypJNTzZbfKrlfRh2 = new uoSUifqzertDkypJNTzZbfKrlfRh(0);
					uoSUifqzertDkypJNTzZbfKrlfRh2.fpLMkhBwYrQCOaUcoChJaHglaycHA = fpLMkhBwYrQCOaUcoChJaHglaycHA;
				}
				return uoSUifqzertDkypJNTzZbfKrlfRh2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<IControllerElementIdentifierCommon_Internal>)this).GetEnumerator();
			}
		}

		private sealed class lwtFGkNbbFjehQCoZDKSGPqKSygEA : IEnumerable<ControllerElementIdentifier>, IEnumerable, IEnumerator<ControllerElementIdentifier>, IEnumerator, IDisposable
		{
			private int szZetxavyufVVPrGjEVIrtYJNOrgb;

			private ControllerElementIdentifier UARiuHKbBDCnPjVYUKJkARAcOBRwb;

			private int HEcGrMBsbgfFlbWkhnmKKYRudFQOA;

			public HardwareJoystickMap qGZyThmejOwDOirzJKRDRdKBevce;

			private int KoSrhAtarIgTNGvDipLgEuDHcFVFb;

			ControllerElementIdentifier IEnumerator<ControllerElementIdentifier>.Current
			{
				[DebuggerHidden]
				get
				{
					return UARiuHKbBDCnPjVYUKJkARAcOBRwb;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return UARiuHKbBDCnPjVYUKJkARAcOBRwb;
				}
			}

			[DebuggerHidden]
			public lwtFGkNbbFjehQCoZDKSGPqKSygEA(int P_0)
			{
				szZetxavyufVVPrGjEVIrtYJNOrgb = P_0;
				HEcGrMBsbgfFlbWkhnmKKYRudFQOA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = szZetxavyufVVPrGjEVIrtYJNOrgb;
				HardwareJoystickMap hardwareJoystickMap = qGZyThmejOwDOirzJKRDRdKBevce;
				switch (num)
				{
				default:
					return false;
				case 0:
					szZetxavyufVVPrGjEVIrtYJNOrgb = -1;
					if (hardwareJoystickMap.elementIdentifiers == null)
					{
						return false;
					}
					KoSrhAtarIgTNGvDipLgEuDHcFVFb = 0;
					break;
				case 1:
					szZetxavyufVVPrGjEVIrtYJNOrgb = -1;
					KoSrhAtarIgTNGvDipLgEuDHcFVFb++;
					break;
				}
				if (KoSrhAtarIgTNGvDipLgEuDHcFVFb < hardwareJoystickMap.elementIdentifiers.Length)
				{
					UARiuHKbBDCnPjVYUKJkARAcOBRwb = hardwareJoystickMap.elementIdentifiers[KoSrhAtarIgTNGvDipLgEuDHcFVFb];
					szZetxavyufVVPrGjEVIrtYJNOrgb = 1;
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
				lwtFGkNbbFjehQCoZDKSGPqKSygEA lwtFGkNbbFjehQCoZDKSGPqKSygEA2;
				if (szZetxavyufVVPrGjEVIrtYJNOrgb == -2 && HEcGrMBsbgfFlbWkhnmKKYRudFQOA == Environment.CurrentManagedThreadId)
				{
					szZetxavyufVVPrGjEVIrtYJNOrgb = 0;
					lwtFGkNbbFjehQCoZDKSGPqKSygEA2 = this;
				}
				else
				{
					lwtFGkNbbFjehQCoZDKSGPqKSygEA2 = new lwtFGkNbbFjehQCoZDKSGPqKSygEA(0);
					lwtFGkNbbFjehQCoZDKSGPqKSygEA2.qGZyThmejOwDOirzJKRDRdKBevce = qGZyThmejOwDOirzJKRDRdKBevce;
				}
				return lwtFGkNbbFjehQCoZDKSGPqKSygEA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerElementIdentifier>)this).GetEnumerator();
			}
		}

		private sealed class PLModCVlJOTzWoxhkMFxlSdBlmSQ : IEnumerable<JoystickType>, IEnumerable, IEnumerator<JoystickType>, IEnumerator, IDisposable
		{
			private int bZAGnsjQTRZzoTqpeRCMPGxovzRuA;

			private JoystickType wsMLOwbAsyBSCSkstPSmyGhQDPkT;

			private int ZexfMNBZqznQaGXwXmTFnisoVKwbA;

			public HardwareJoystickMap PItDcUhPyDxqaJLRjOmkyttThfWtA;

			private int WrQCErHxaVbJkfNKQkBluAzzsiofA;

			JoystickType IEnumerator<JoystickType>.Current
			{
				[DebuggerHidden]
				get
				{
					return wsMLOwbAsyBSCSkstPSmyGhQDPkT;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return wsMLOwbAsyBSCSkstPSmyGhQDPkT;
				}
			}

			[DebuggerHidden]
			public PLModCVlJOTzWoxhkMFxlSdBlmSQ(int P_0)
			{
				bZAGnsjQTRZzoTqpeRCMPGxovzRuA = P_0;
				ZexfMNBZqznQaGXwXmTFnisoVKwbA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = bZAGnsjQTRZzoTqpeRCMPGxovzRuA;
				HardwareJoystickMap pItDcUhPyDxqaJLRjOmkyttThfWtA = PItDcUhPyDxqaJLRjOmkyttThfWtA;
				switch (num)
				{
				default:
					return false;
				case 0:
					bZAGnsjQTRZzoTqpeRCMPGxovzRuA = -1;
					if (pItDcUhPyDxqaJLRjOmkyttThfWtA.joystickTypes == null)
					{
						return false;
					}
					WrQCErHxaVbJkfNKQkBluAzzsiofA = 0;
					break;
				case 1:
					bZAGnsjQTRZzoTqpeRCMPGxovzRuA = -1;
					WrQCErHxaVbJkfNKQkBluAzzsiofA++;
					break;
				}
				if (WrQCErHxaVbJkfNKQkBluAzzsiofA < pItDcUhPyDxqaJLRjOmkyttThfWtA.joystickTypes.Length)
				{
					wsMLOwbAsyBSCSkstPSmyGhQDPkT = pItDcUhPyDxqaJLRjOmkyttThfWtA.joystickTypes[WrQCErHxaVbJkfNKQkBluAzzsiofA];
					bZAGnsjQTRZzoTqpeRCMPGxovzRuA = 1;
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
				PLModCVlJOTzWoxhkMFxlSdBlmSQ pLModCVlJOTzWoxhkMFxlSdBlmSQ;
				if (bZAGnsjQTRZzoTqpeRCMPGxovzRuA == -2 && ZexfMNBZqznQaGXwXmTFnisoVKwbA == Environment.CurrentManagedThreadId)
				{
					bZAGnsjQTRZzoTqpeRCMPGxovzRuA = 0;
					pLModCVlJOTzWoxhkMFxlSdBlmSQ = this;
				}
				else
				{
					pLModCVlJOTzWoxhkMFxlSdBlmSQ = new PLModCVlJOTzWoxhkMFxlSdBlmSQ(0);
					pLModCVlJOTzWoxhkMFxlSdBlmSQ.PItDcUhPyDxqaJLRjOmkyttThfWtA = PItDcUhPyDxqaJLRjOmkyttThfWtA;
				}
				return pLModCVlJOTzWoxhkMFxlSdBlmSQ;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JoystickType>)this).GetEnumerator();
			}
		}

		private sealed class MxwwdeHhHOUAMYTrQDMfOHCRCbUP : IEnumerable<Guid>, IEnumerable, IEnumerator<Guid>, IEnumerator, IDisposable
		{
			private int uMwoGpSwWPLvMJRvKuWvZLlhXMaf;

			private Guid DDWoQlxzMXCTkMosjEIEeJMqdkTG;

			private int qgdCqgjKOQdpSTGZQibnbAnYTddD;

			public HardwareJoystickMap UNklfANHcTvLEnMTyDgoFivbaJUDA;

			private Guid[] PzxJnFczSETwiTPIJjKDemFQbdmZ;

			private int aDLYvQApuxxseeWBUmpwotCvvPhC;

			Guid IEnumerator<Guid>.Current
			{
				[DebuggerHidden]
				get
				{
					return DDWoQlxzMXCTkMosjEIEeJMqdkTG;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return DDWoQlxzMXCTkMosjEIEeJMqdkTG;
				}
			}

			[DebuggerHidden]
			public MxwwdeHhHOUAMYTrQDMfOHCRCbUP(int P_0)
			{
				uMwoGpSwWPLvMJRvKuWvZLlhXMaf = P_0;
				qgdCqgjKOQdpSTGZQibnbAnYTddD = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = uMwoGpSwWPLvMJRvKuWvZLlhXMaf;
				HardwareJoystickMap uNklfANHcTvLEnMTyDgoFivbaJUDA = UNklfANHcTvLEnMTyDgoFivbaJUDA;
				switch (num)
				{
				default:
					return false;
				case 0:
					uMwoGpSwWPLvMJRvKuWvZLlhXMaf = -1;
					if (ReInput.isReady)
					{
						PzxJnFczSETwiTPIJjKDemFQbdmZ = uNklfANHcTvLEnMTyDgoFivbaJUDA.runtimeTemplateGuids;
						if (PzxJnFczSETwiTPIJjKDemFQbdmZ == null)
						{
							return false;
						}
						aDLYvQApuxxseeWBUmpwotCvvPhC = 0;
						goto IL_0086;
					}
					if (uNklfANHcTvLEnMTyDgoFivbaJUDA.templateGuids == null)
					{
						return false;
					}
					aDLYvQApuxxseeWBUmpwotCvvPhC = 0;
					goto IL_00ea;
				case 1:
					uMwoGpSwWPLvMJRvKuWvZLlhXMaf = -1;
					aDLYvQApuxxseeWBUmpwotCvvPhC++;
					goto IL_0086;
				case 2:
					{
						uMwoGpSwWPLvMJRvKuWvZLlhXMaf = -1;
						aDLYvQApuxxseeWBUmpwotCvvPhC++;
						goto IL_00ea;
					}
					IL_0086:
					if (aDLYvQApuxxseeWBUmpwotCvvPhC < PzxJnFczSETwiTPIJjKDemFQbdmZ.Length)
					{
						DDWoQlxzMXCTkMosjEIEeJMqdkTG = PzxJnFczSETwiTPIJjKDemFQbdmZ[aDLYvQApuxxseeWBUmpwotCvvPhC];
						uMwoGpSwWPLvMJRvKuWvZLlhXMaf = 1;
						return true;
					}
					PzxJnFczSETwiTPIJjKDemFQbdmZ = null;
					break;
					IL_00ea:
					if (aDLYvQApuxxseeWBUmpwotCvvPhC < uNklfANHcTvLEnMTyDgoFivbaJUDA.templateGuids.Length)
					{
						DDWoQlxzMXCTkMosjEIEeJMqdkTG = StringTools.ToGuid(uNklfANHcTvLEnMTyDgoFivbaJUDA.templateGuids[aDLYvQApuxxseeWBUmpwotCvvPhC]);
						uMwoGpSwWPLvMJRvKuWvZLlhXMaf = 2;
						return true;
					}
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

			[DebuggerHidden]
			IEnumerator<Guid> IEnumerable<Guid>.GetEnumerator()
			{
				MxwwdeHhHOUAMYTrQDMfOHCRCbUP mxwwdeHhHOUAMYTrQDMfOHCRCbUP;
				if (uMwoGpSwWPLvMJRvKuWvZLlhXMaf == -2 && qgdCqgjKOQdpSTGZQibnbAnYTddD == Environment.CurrentManagedThreadId)
				{
					uMwoGpSwWPLvMJRvKuWvZLlhXMaf = 0;
					mxwwdeHhHOUAMYTrQDMfOHCRCbUP = this;
				}
				else
				{
					mxwwdeHhHOUAMYTrQDMfOHCRCbUP = new MxwwdeHhHOUAMYTrQDMfOHCRCbUP(0);
					mxwwdeHhHOUAMYTrQDMfOHCRCbUP.UNklfANHcTvLEnMTyDgoFivbaJUDA = UNklfANHcTvLEnMTyDgoFivbaJUDA;
				}
				return mxwwdeHhHOUAMYTrQDMfOHCRCbUP;
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
		private string controllerKey;

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
		private Platform_WindowsWGI windowsWGI;

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

		[NonSerialized]
		private Guid? __runtimeControllerGuidCache;

		[NonSerialized]
		private Guid[] __runtimeTemplateGuidCache;

		private Guid runtimeControllerGuid
		{
			get
			{
				if (!__runtimeControllerGuidCache.HasValue || !__runtimeControllerGuidCache.HasValue)
				{
					__runtimeControllerGuidCache = StringTools.ToGuid(controllerGuid);
				}
				return __runtimeControllerGuidCache.Value;
			}
		}

		private Guid[] runtimeTemplateGuids
		{
			get
			{
				if (__runtimeTemplateGuidCache == null && templateGuids != null)
				{
					__runtimeTemplateGuidCache = new Guid[templateGuids.Length];
					for (int i = 0; i < templateGuids.Length; i++)
					{
						__runtimeTemplateGuidCache[i] = StringTools.ToGuid(templateGuids[i]);
					}
				}
				return __runtimeTemplateGuidCache;
			}
		}

		public string ControllerName => controllerName;

		public string EditorControllerName => editorControllerName;

		public Guid Guid
		{
			get
			{
				if (!ReInput.isReady)
				{
					return StringTools.ToGuid(controllerGuid);
				}
				return runtimeControllerGuid;
			}
		}

		public string Key => controllerKey;

		public IEnumerable<Guid> TemplateGuids
		{
			[IteratorStateMachine(typeof(MxwwdeHhHOUAMYTrQDMfOHCRCbUP))]
			get
			{
				return new MxwwdeHhHOUAMYTrQDMfOHCRCbUP(-2)
				{
					UNklfANHcTvLEnMTyDgoFivbaJUDA = this
				};
			}
		}

		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers
		{
			[IteratorStateMachine(typeof(lwtFGkNbbFjehQCoZDKSGPqKSygEA))]
			get
			{
				return new lwtFGkNbbFjehQCoZDKSGPqKSygEA(-2)
				{
					qGZyThmejOwDOirzJKRDRdKBevce = this
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
			[IteratorStateMachine(typeof(PLModCVlJOTzWoxhkMFxlSdBlmSQ))]
			get
			{
				return new PLModCVlJOTzWoxhkMFxlSdBlmSQ(-2)
				{
					PItDcUhPyDxqaJLRjOmkyttThfWtA = this
				};
			}
		}

		Guid IHardwareControllerMap_Internal.typeGuid => Guid;

		string IHardwareControllerMap_Internal.typeKey => controllerKey;

		ControllerType IHardwareControllerMap_Internal.controllerType => ControllerType.Joystick;

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			[IteratorStateMachine(typeof(uoSUifqzertDkypJNTzZbfKrlfRh))]
			get
			{
				return new uoSUifqzertDkypJNTzZbfKrlfRh(-2)
				{
					fpLMkhBwYrQCOaUcoChJaHglaycHA = this
				};
			}
		}

		string IHardwareControllerMap_Internal.name => base.name;

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
			if (windowsWGI == null)
			{
				windowsWGI = new Platform_WindowsWGI();
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
			if (P_0.windowsWGI != null)
			{
				windowsWGI = MiscTools.DeepClone(P_0.windowsWGI);
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

		public int GetTemplateGuids(IList<Guid> results)
		{
			int num = 0;
			if (ReInput.isReady)
			{
				Guid[] array = runtimeTemplateGuids;
				if (array == null)
				{
					return 0;
				}
				int num2 = array.Length;
				for (int i = 0; i < num2; i++)
				{
					results.Add(array[i]);
					num++;
				}
			}
			else
			{
				if (templateGuids == null)
				{
					return 0;
				}
				for (int j = 0; j < templateGuids.Length; j++)
				{
					results.Add(StringTools.ToGuid(templateGuids[j]));
					num++;
				}
			}
			return num;
		}

		public bool ContainsTemplateGuid(Guid guid)
		{
			if (ReInput.isReady)
			{
				Guid[] array = runtimeTemplateGuids;
				if (array == null)
				{
					return false;
				}
				int num = array.Length;
				for (int i = 0; i < num; i++)
				{
					if (guid == array[i])
					{
						return true;
					}
				}
			}
			else
			{
				if (templateGuids == null)
				{
					return false;
				}
				for (int j = 0; j < templateGuids.Length; j++)
				{
					if (guid == StringTools.ToGuid(templateGuids[j]))
					{
						return true;
					}
				}
			}
			return false;
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
		public ControllerElementIdentifier GetElementIdentifierAtIndex(int index)
		{
			if (index < 0 || index >= elementIdentifiers.Length)
			{
				return null;
			}
			return elementIdentifiers[index];
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
			case InputSource.WindowsGamingInput:
				if (windowsWGI == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.WindowsWGI;
				return windowsWGI.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
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
			case InputSource.Custom:
				if (!pEDFtRXsVNNJtQauegEJObAFaioB.SINAvtVjZlMAWkyjXPhqxZwrawWF)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.Custom;
				platformMap = pEDFtRXsVNNJtQauegEJObAFaioB.wtSSMzPWPhPTFiKeMUYjXeXiscIr().GetPlatformMap(pEDFtRXsVNNJtQauegEJObAFaioB.OupvxepflTwTrLhYoAopbWNFIRID, Guid);
				if (platformMap != null)
				{
					return platformMap.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
				}
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
			case InputSource.WindowsGamingInput:
				actualInputPlatform = InputPlatform.WindowsWGI;
				platform = windowsWGI;
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
			case InputSource.InternalDriver:
				actualInputPlatform = InputPlatform.InternalDriver;
				platform = internalDriver;
				break;
			case InputSource.SDL2:
				platform = FindSDL2Map(inputSource, isDefaultMap: true, out actualInputPlatform, out variantIndex);
				break;
			case InputSource.Custom:
				if (!pEDFtRXsVNNJtQauegEJObAFaioB.SINAvtVjZlMAWkyjXPhqxZwrawWF)
				{
					return null;
				}
				actualInputPlatform = InputPlatform.Custom;
				platform = pEDFtRXsVNNJtQauegEJObAFaioB.wtSSMzPWPhPTFiKeMUYjXeXiscIr().GetPlatformMap(pEDFtRXsVNNJtQauegEJObAFaioB.OupvxepflTwTrLhYoAopbWNFIRID, Guid);
				break;
			case InputSource.None:
				return null;
			case InputSource.Steam:
			case InputSource.UnityKeyboardAndMouse:
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
				IList<Platform> variants = mainMap.GetVariants();
				if (variants != null)
				{
					for (int i = 0; i < variants.Count; i++)
					{
						Platform platform = variants[i];
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
			IList<Platform> variants = universalDefaultMapRoot.GetVariants();
			if (variants != null)
			{
				for (int i = 0; i < variants.Count; i++)
				{
					if (variants[i] != null && variants[i].isAllowed)
					{
						variantIndex = i;
						return variants[i] as T;
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
			case InputPlatform.WindowsWGI:
				return windowsWGI;
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
				if (!pEDFtRXsVNNJtQauegEJObAFaioB.SINAvtVjZlMAWkyjXPhqxZwrawWF)
				{
					throw new Exception("Custom Platform is not set.");
				}
				try
				{
					return pEDFtRXsVNNJtQauegEJObAFaioB.wtSSMzPWPhPTFiKeMUYjXeXiscIr().GetPlatformMap(pEDFtRXsVNNJtQauegEJObAFaioB.OupvxepflTwTrLhYoAopbWNFIRID, Guid);
				}
				catch (Exception msg)
				{
					Logger.LogError(msg);
					return null;
				}
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
