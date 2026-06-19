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
			private sealed class FaquuIlLkjefoJddfbYUdaFENQFfA : IEnumerable<Platform>, IEnumerable, IEnumerator<Platform>, IEnumerator, IDisposable
			{
				private int WQYoxRaPHdxHkaFlmhifVcGYOGIb;

				private Platform lLkLSbizWihTsJUkGcRMGnXaFYBj;

				private int lNUZduaPiHmajiTvaYDlQrNTNbxb;

				public Platform UOjJoBsGlHxGoNmIxIGfAilLsiAHA;

				private IList<Platform> RvWPoUVRqcfVUfFmxIamuLDuIqKhA;

				private int SWcbaEgfteABMpDhNcWjEYkiqwnzA;

				Platform IEnumerator<Platform>.Current
				{
					[DebuggerHidden]
					get
					{
						return lLkLSbizWihTsJUkGcRMGnXaFYBj;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return lLkLSbizWihTsJUkGcRMGnXaFYBj;
					}
				}

				[DebuggerHidden]
				public FaquuIlLkjefoJddfbYUdaFENQFfA(int P_0)
				{
					WQYoxRaPHdxHkaFlmhifVcGYOGIb = P_0;
					lNUZduaPiHmajiTvaYDlQrNTNbxb = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					RvWPoUVRqcfVUfFmxIamuLDuIqKhA = null;
					WQYoxRaPHdxHkaFlmhifVcGYOGIb = -2;
				}

				private bool MoveNext()
				{
					int wQYoxRaPHdxHkaFlmhifVcGYOGIb = WQYoxRaPHdxHkaFlmhifVcGYOGIb;
					Platform uOjJoBsGlHxGoNmIxIGfAilLsiAHA = UOjJoBsGlHxGoNmIxIGfAilLsiAHA;
					if (wQYoxRaPHdxHkaFlmhifVcGYOGIb != 0)
					{
						if (wQYoxRaPHdxHkaFlmhifVcGYOGIb != 1)
						{
							return false;
						}
						WQYoxRaPHdxHkaFlmhifVcGYOGIb = -1;
						goto IL_0077;
					}
					WQYoxRaPHdxHkaFlmhifVcGYOGIb = -1;
					RvWPoUVRqcfVUfFmxIamuLDuIqKhA = uOjJoBsGlHxGoNmIxIGfAilLsiAHA.GetVariants();
					if (RvWPoUVRqcfVUfFmxIamuLDuIqKhA == null)
					{
						return false;
					}
					SWcbaEgfteABMpDhNcWjEYkiqwnzA = 0;
					goto IL_0087;
					IL_0087:
					if (SWcbaEgfteABMpDhNcWjEYkiqwnzA < RvWPoUVRqcfVUfFmxIamuLDuIqKhA.Count)
					{
						if (RvWPoUVRqcfVUfFmxIamuLDuIqKhA[SWcbaEgfteABMpDhNcWjEYkiqwnzA] != null)
						{
							lLkLSbizWihTsJUkGcRMGnXaFYBj = RvWPoUVRqcfVUfFmxIamuLDuIqKhA[SWcbaEgfteABMpDhNcWjEYkiqwnzA];
							WQYoxRaPHdxHkaFlmhifVcGYOGIb = 1;
							return true;
						}
						goto IL_0077;
					}
					return false;
					IL_0077:
					SWcbaEgfteABMpDhNcWjEYkiqwnzA++;
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
					FaquuIlLkjefoJddfbYUdaFENQFfA faquuIlLkjefoJddfbYUdaFENQFfA;
					if (WQYoxRaPHdxHkaFlmhifVcGYOGIb == -2 && lNUZduaPiHmajiTvaYDlQrNTNbxb == Environment.CurrentManagedThreadId)
					{
						WQYoxRaPHdxHkaFlmhifVcGYOGIb = 0;
						faquuIlLkjefoJddfbYUdaFENQFfA = this;
					}
					else
					{
						faquuIlLkjefoJddfbYUdaFENQFfA = new FaquuIlLkjefoJddfbYUdaFENQFfA(0);
						faquuIlLkjefoJddfbYUdaFENQFfA.UOjJoBsGlHxGoNmIxIGfAilLsiAHA = UOjJoBsGlHxGoNmIxIGfAilLsiAHA;
					}
					return faquuIlLkjefoJddfbYUdaFENQFfA;
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
				[IteratorStateMachine(typeof(FaquuIlLkjefoJddfbYUdaFENQFfA))]
				get
				{
					return new FaquuIlLkjefoJddfbYUdaFENQFfA(-2)
					{
						UOjJoBsGlHxGoNmIxIGfAilLsiAHA = this
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
				switch (inputSource)
				{
				case InputSource.PS4:
				{
					if (!(hardwareJoystickMap.Guid == Consts.joystickGuid_SonyDualShock4) && !(hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4AimController))
					{
						break;
					}
					for (int m = 0; m < elementIdentifierCount; m++)
					{
						switch (elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
						{
						case 0:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "left stick x";
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "left stick right";
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName = "left stick left";
							break;
						case 1:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "left stick y";
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "left stick up";
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName = "left stick down";
							break;
						case 2:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "right stick x";
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "right stick right";
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName = "right stick left";
							break;
						case 3:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "right stick y";
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "right stick up";
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName = "right stick down";
							break;
						case 4:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "L2 button";
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "L2 button";
							break;
						case 5:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "R2 button";
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName = "R2 button";
							break;
						case 6:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "cross button";
							break;
						case 7:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "circle button";
							break;
						case 8:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "square button";
							break;
						case 9:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "triangle button";
							break;
						case 10:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "L1 button";
							break;
						case 11:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "R1 button";
							break;
						case 12:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "SHARE button";
							break;
						case 13:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "OPTIONS button";
							break;
						case 14:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "PS button";
							break;
						case 15:
							if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4AimController)
							{
								hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "pad button";
							}
							else
							{
								hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "touch pad button";
							}
							break;
						case 16:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "L3 button";
							break;
						case 17:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "R3 button";
							break;
						case 18:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "up button";
							break;
						case 19:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "right button";
							break;
						case 20:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "down button";
							break;
						case 21:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "left button";
							break;
						}
					}
					break;
				}
				case InputSource.PS5:
					if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyDualSense)
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
								hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "create button";
								break;
							case 13:
								hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "options button";
								break;
							case 14:
								hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "PS button";
								break;
							case 15:
								hardwareJoystickMap_InputManager.elementIdentifiers[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "touch pad button";
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
					else if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4Drums || hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4Guitar || hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4SteeringWheel)
					{
						for (int k = 0; k < elementIdentifierCount; k++)
						{
							switch (elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
							{
							case 19:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "create button";
								break;
							case 20:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "options button";
								break;
							}
						}
					}
					else
					{
						if (!(hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4FlightStick))
						{
							break;
						}
						for (int l = 0; l < elementIdentifierCount; l++)
						{
							switch (elementIdentifiers[l].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid)
							{
							case 21:
								hardwareJoystickMap_InputManager.elementIdentifiers[l].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "create button";
								break;
							case 22:
								hardwareJoystickMap_InputManager.elementIdentifiers[l].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = "options button";
								break;
							}
						}
					}
					break;
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
					ajTmuZrfJgNWFabMneWjcfeLLiVW(elementCount_Base);
					return elementCount_Base;
				}

				object IDeepCloneable.DeepClone()
				{
					//ILSpy generated this explicit interface implementation from .override directive in DeepClone
					return this.DeepClone();
				}

				internal virtual void ajTmuZrfJgNWFabMneWjcfeLLiVW(ElementCount_Base P_0)
				{
					if (P_0 != null)
					{
						P_0.axisCount = axisCount;
						P_0.buttonCount = buttonCount;
					}
				}

				internal virtual bool ZRIzpYvxiqqesJvpPGVJiNbpPZlD(BridgedControllerHWInfo P_0)
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
					if (elementCount_Base != null && elementCount_Base.ZRIzpYvxiqqesJvpPGVJiNbpPZlD(bridgedControllerHWInfo))
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
						ajTmuZrfJgNWFabMneWjcfeLLiVW(elementCount);
						return elementCount;
					}

					internal void cvcisjkqVcpDqwtWBkxcDdjcEizq(ElementCount_Base P_0)
					{
						base.ajTmuZrfJgNWFabMneWjcfeLLiVW(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool HSCaKveFzAAGvBIOOjRyJNufgZSP(BridgedControllerHWInfo P_0)
					{
						if (!base.ZRIzpYvxiqqesJvpPGVJiNbpPZlD(P_0))
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
				private sealed class mwLcXZICJhdYXeejrWYATpjENjTCA : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int fPwWbgJHLJRtHaxqXKTGWGyIyaQH;

					private Axis_Base ZAfRGqksyTrArXUEcRlNOEIUlpHX;

					private int DaossULKnYiItFnRklMuSLqPMjVj;

					public Elements tjkCpibPTAFVHhGSmnXwEpZGnCxp;

					private int IXKVaYDZGfqlkvlyhBJwdXbqHJcNA;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return ZAfRGqksyTrArXUEcRlNOEIUlpHX;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ZAfRGqksyTrArXUEcRlNOEIUlpHX;
						}
					}

					[DebuggerHidden]
					public mwLcXZICJhdYXeejrWYATpjENjTCA(int P_0)
					{
						fPwWbgJHLJRtHaxqXKTGWGyIyaQH = P_0;
						DaossULKnYiItFnRklMuSLqPMjVj = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						fPwWbgJHLJRtHaxqXKTGWGyIyaQH = -2;
					}

					private bool MoveNext()
					{
						int num = fPwWbgJHLJRtHaxqXKTGWGyIyaQH;
						Elements elements = tjkCpibPTAFVHhGSmnXwEpZGnCxp;
						switch (num)
						{
						default:
							return false;
						case 0:
							fPwWbgJHLJRtHaxqXKTGWGyIyaQH = -1;
							if (elements.axes == null)
							{
								return false;
							}
							IXKVaYDZGfqlkvlyhBJwdXbqHJcNA = 0;
							break;
						case 1:
							fPwWbgJHLJRtHaxqXKTGWGyIyaQH = -1;
							IXKVaYDZGfqlkvlyhBJwdXbqHJcNA++;
							break;
						}
						if (IXKVaYDZGfqlkvlyhBJwdXbqHJcNA < elements.axes.Length)
						{
							ZAfRGqksyTrArXUEcRlNOEIUlpHX = elements.axes[IXKVaYDZGfqlkvlyhBJwdXbqHJcNA];
							fPwWbgJHLJRtHaxqXKTGWGyIyaQH = 1;
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
						mwLcXZICJhdYXeejrWYATpjENjTCA mwLcXZICJhdYXeejrWYATpjENjTCA2;
						if (fPwWbgJHLJRtHaxqXKTGWGyIyaQH == -2 && DaossULKnYiItFnRklMuSLqPMjVj == Environment.CurrentManagedThreadId)
						{
							fPwWbgJHLJRtHaxqXKTGWGyIyaQH = 0;
							mwLcXZICJhdYXeejrWYATpjENjTCA2 = this;
						}
						else
						{
							mwLcXZICJhdYXeejrWYATpjENjTCA2 = new mwLcXZICJhdYXeejrWYATpjENjTCA(0);
							mwLcXZICJhdYXeejrWYATpjENjTCA2.tjkCpibPTAFVHhGSmnXwEpZGnCxp = tjkCpibPTAFVHhGSmnXwEpZGnCxp;
						}
						return mwLcXZICJhdYXeejrWYATpjENjTCA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}
				}

				private sealed class jAjqDkUayVOOchhbrXPWAgpkGZogA : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int fbevxZhoKFCtwZJynNgaMcwLfxfP;

					private Button_Base FvyHQgAiQTgCKiMqHiVBYjqVUoVV;

					private int LNQSWJmqqlONGkgBGIuWPTidFyIfA;

					public Elements xxsWsIhecnXRNPuUqdJpCZBYWKQE;

					private int BmseNdelPaKAmuUEaJNttXdNYaHf;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return FvyHQgAiQTgCKiMqHiVBYjqVUoVV;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return FvyHQgAiQTgCKiMqHiVBYjqVUoVV;
						}
					}

					[DebuggerHidden]
					public jAjqDkUayVOOchhbrXPWAgpkGZogA(int P_0)
					{
						fbevxZhoKFCtwZJynNgaMcwLfxfP = P_0;
						LNQSWJmqqlONGkgBGIuWPTidFyIfA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						fbevxZhoKFCtwZJynNgaMcwLfxfP = -2;
					}

					private bool MoveNext()
					{
						int num = fbevxZhoKFCtwZJynNgaMcwLfxfP;
						Elements elements = xxsWsIhecnXRNPuUqdJpCZBYWKQE;
						switch (num)
						{
						default:
							return false;
						case 0:
							fbevxZhoKFCtwZJynNgaMcwLfxfP = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							BmseNdelPaKAmuUEaJNttXdNYaHf = 0;
							break;
						case 1:
							fbevxZhoKFCtwZJynNgaMcwLfxfP = -1;
							BmseNdelPaKAmuUEaJNttXdNYaHf++;
							break;
						}
						if (BmseNdelPaKAmuUEaJNttXdNYaHf < elements.buttons.Length)
						{
							FvyHQgAiQTgCKiMqHiVBYjqVUoVV = elements.buttons[BmseNdelPaKAmuUEaJNttXdNYaHf];
							fbevxZhoKFCtwZJynNgaMcwLfxfP = 1;
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
						jAjqDkUayVOOchhbrXPWAgpkGZogA jAjqDkUayVOOchhbrXPWAgpkGZogA2;
						if (fbevxZhoKFCtwZJynNgaMcwLfxfP == -2 && LNQSWJmqqlONGkgBGIuWPTidFyIfA == Environment.CurrentManagedThreadId)
						{
							fbevxZhoKFCtwZJynNgaMcwLfxfP = 0;
							jAjqDkUayVOOchhbrXPWAgpkGZogA2 = this;
						}
						else
						{
							jAjqDkUayVOOchhbrXPWAgpkGZogA2 = new jAjqDkUayVOOchhbrXPWAgpkGZogA(0);
							jAjqDkUayVOOchhbrXPWAgpkGZogA2.xxsWsIhecnXRNPuUqdJpCZBYWKQE = xxsWsIhecnXRNPuUqdJpCZBYWKQE;
						}
						return jAjqDkUayVOOchhbrXPWAgpkGZogA2;
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
					[IteratorStateMachine(typeof(mwLcXZICJhdYXeejrWYATpjENjTCA))]
					get
					{
						return new mwLcXZICJhdYXeejrWYATpjENjTCA(-2)
						{
							tjkCpibPTAFVHhGSmnXwEpZGnCxp = this
						};
					}
				}

				IEnumerable<Button_Base> Elements_Platform_Base.Buttons
				{
					[IteratorStateMachine(typeof(jAjqDkUayVOOchhbrXPWAgpkGZogA))]
					get
					{
						return new jAjqDkUayVOOchhbrXPWAgpkGZogA(-2)
						{
							xxsWsIhecnXRNPuUqdJpCZBYWKQE = this
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

			private sealed class MVSeqVBQlDCYHUKqIoYBvfAAKSAFA : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int ITdlkhGjGBxMoTiHxYaxtBQpovRT;

				private Axis_Base aXquPFxBhMPmfoFwVgGoBnQgsEyJ;

				private int TgKEBTgURNfzFXLSSdDYiaWcgetU;

				public Platform_DirectInput_Base xJRvzAFbGfpMefuyTuYscbIYhwEo;

				private int ebdrYOzVsMlpyAPxvctjXhCNtpWL;

				private int jlRLhIVcxEYpxzkdUXVxIxbIvkId;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return aXquPFxBhMPmfoFwVgGoBnQgsEyJ;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return aXquPFxBhMPmfoFwVgGoBnQgsEyJ;
					}
				}

				[DebuggerHidden]
				public MVSeqVBQlDCYHUKqIoYBvfAAKSAFA(int P_0)
				{
					ITdlkhGjGBxMoTiHxYaxtBQpovRT = P_0;
					TgKEBTgURNfzFXLSSdDYiaWcgetU = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					ITdlkhGjGBxMoTiHxYaxtBQpovRT = -2;
				}

				private bool MoveNext()
				{
					int iTdlkhGjGBxMoTiHxYaxtBQpovRT = ITdlkhGjGBxMoTiHxYaxtBQpovRT;
					Platform_DirectInput_Base platform_DirectInput_Base = xJRvzAFbGfpMefuyTuYscbIYhwEo;
					switch (iTdlkhGjGBxMoTiHxYaxtBQpovRT)
					{
					default:
						return false;
					case 0:
						ITdlkhGjGBxMoTiHxYaxtBQpovRT = -1;
						if (platform_DirectInput_Base.elements == null || platform_DirectInput_Base.elements.axes == null)
						{
							return false;
						}
						ebdrYOzVsMlpyAPxvctjXhCNtpWL = platform_DirectInput_Base.elements.axes.Length;
						jlRLhIVcxEYpxzkdUXVxIxbIvkId = 0;
						break;
					case 1:
						ITdlkhGjGBxMoTiHxYaxtBQpovRT = -1;
						jlRLhIVcxEYpxzkdUXVxIxbIvkId++;
						break;
					}
					if (jlRLhIVcxEYpxzkdUXVxIxbIvkId < ebdrYOzVsMlpyAPxvctjXhCNtpWL)
					{
						aXquPFxBhMPmfoFwVgGoBnQgsEyJ = platform_DirectInput_Base.elements.axes[jlRLhIVcxEYpxzkdUXVxIxbIvkId];
						ITdlkhGjGBxMoTiHxYaxtBQpovRT = 1;
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
					MVSeqVBQlDCYHUKqIoYBvfAAKSAFA mVSeqVBQlDCYHUKqIoYBvfAAKSAFA;
					if (ITdlkhGjGBxMoTiHxYaxtBQpovRT == -2 && TgKEBTgURNfzFXLSSdDYiaWcgetU == Environment.CurrentManagedThreadId)
					{
						ITdlkhGjGBxMoTiHxYaxtBQpovRT = 0;
						mVSeqVBQlDCYHUKqIoYBvfAAKSAFA = this;
					}
					else
					{
						mVSeqVBQlDCYHUKqIoYBvfAAKSAFA = new MVSeqVBQlDCYHUKqIoYBvfAAKSAFA(0);
						mVSeqVBQlDCYHUKqIoYBvfAAKSAFA.xJRvzAFbGfpMefuyTuYscbIYhwEo = xJRvzAFbGfpMefuyTuYscbIYhwEo;
					}
					return mVSeqVBQlDCYHUKqIoYBvfAAKSAFA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}
			}

			private sealed class tNmzYimPVYVaAgwzymYLJVkidycf : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int XiqGsLKoojNQIvUkNdcuxsCGddAi;

				private Button_Base CbPIJqKxmvfzruMxjMEScmWdqtfnb;

				private int VWogacbcqIHGlbXUFapVxCbVwUKG;

				public Platform_DirectInput_Base fDELEiTMZOFbhDwumCsflIeEMgIC;

				private int uPkgMBdQnxDagdNvDbQjNIiFfoGLA;

				private int qRfnlBbWHvfONZTGyvWTfAtfMBrS;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return CbPIJqKxmvfzruMxjMEScmWdqtfnb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return CbPIJqKxmvfzruMxjMEScmWdqtfnb;
					}
				}

				[DebuggerHidden]
				public tNmzYimPVYVaAgwzymYLJVkidycf(int P_0)
				{
					XiqGsLKoojNQIvUkNdcuxsCGddAi = P_0;
					VWogacbcqIHGlbXUFapVxCbVwUKG = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					XiqGsLKoojNQIvUkNdcuxsCGddAi = -2;
				}

				private bool MoveNext()
				{
					int xiqGsLKoojNQIvUkNdcuxsCGddAi = XiqGsLKoojNQIvUkNdcuxsCGddAi;
					Platform_DirectInput_Base platform_DirectInput_Base = fDELEiTMZOFbhDwumCsflIeEMgIC;
					switch (xiqGsLKoojNQIvUkNdcuxsCGddAi)
					{
					default:
						return false;
					case 0:
						XiqGsLKoojNQIvUkNdcuxsCGddAi = -1;
						if (platform_DirectInput_Base.elements == null || platform_DirectInput_Base.elements.buttons == null)
						{
							return false;
						}
						uPkgMBdQnxDagdNvDbQjNIiFfoGLA = platform_DirectInput_Base.elements.buttons.Length;
						qRfnlBbWHvfONZTGyvWTfAtfMBrS = 0;
						break;
					case 1:
						XiqGsLKoojNQIvUkNdcuxsCGddAi = -1;
						qRfnlBbWHvfONZTGyvWTfAtfMBrS++;
						break;
					}
					if (qRfnlBbWHvfONZTGyvWTfAtfMBrS < uPkgMBdQnxDagdNvDbQjNIiFfoGLA)
					{
						CbPIJqKxmvfzruMxjMEScmWdqtfnb = platform_DirectInput_Base.elements.buttons[qRfnlBbWHvfONZTGyvWTfAtfMBrS];
						XiqGsLKoojNQIvUkNdcuxsCGddAi = 1;
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
					tNmzYimPVYVaAgwzymYLJVkidycf tNmzYimPVYVaAgwzymYLJVkidycf2;
					if (XiqGsLKoojNQIvUkNdcuxsCGddAi == -2 && VWogacbcqIHGlbXUFapVxCbVwUKG == Environment.CurrentManagedThreadId)
					{
						XiqGsLKoojNQIvUkNdcuxsCGddAi = 0;
						tNmzYimPVYVaAgwzymYLJVkidycf2 = this;
					}
					else
					{
						tNmzYimPVYVaAgwzymYLJVkidycf2 = new tNmzYimPVYVaAgwzymYLJVkidycf(0);
						tNmzYimPVYVaAgwzymYLJVkidycf2.fDELEiTMZOFbhDwumCsflIeEMgIC = fDELEiTMZOFbhDwumCsflIeEMgIC;
					}
					return tNmzYimPVYVaAgwzymYLJVkidycf2;
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
						if (axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = Axes_orig[i].calibrateAxis;
						}
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

			[IteratorStateMachine(typeof(MVSeqVBQlDCYHUKqIoYBvfAAKSAFA))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return new MVSeqVBQlDCYHUKqIoYBvfAAKSAFA(-2)
				{
					xJRvzAFbGfpMefuyTuYscbIYhwEo = this
				};
			}

			[IteratorStateMachine(typeof(tNmzYimPVYVaAgwzymYLJVkidycf))]
			internal override IEnumerable<Button_Base> IterateButtons()
			{
				return new tNmzYimPVYVaAgwzymYLJVkidycf(-2)
				{
					fDELEiTMZOFbhDwumCsflIeEMgIC = this
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
				private sealed class RDUpyhEwOHSQmzpSSjCLiLAZAywO : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int kAxdjRfOYNkPQIjYYBcJnAUxpicSA;

					private Axis_Base dRDPivJcztVnxKGjfDGVbLMyIggp;

					private int ThvoclSqvoaIXtWMhHBKEZuscdRw;

					public Elements hFXaDLXOfkJjmxMFbozEMpMiNDKd;

					private int thJrAyiKMyfDbHkSGJIKeBVRzbxd;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return dRDPivJcztVnxKGjfDGVbLMyIggp;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return dRDPivJcztVnxKGjfDGVbLMyIggp;
						}
					}

					[DebuggerHidden]
					public RDUpyhEwOHSQmzpSSjCLiLAZAywO(int P_0)
					{
						kAxdjRfOYNkPQIjYYBcJnAUxpicSA = P_0;
						ThvoclSqvoaIXtWMhHBKEZuscdRw = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						kAxdjRfOYNkPQIjYYBcJnAUxpicSA = -2;
					}

					private bool MoveNext()
					{
						int num = kAxdjRfOYNkPQIjYYBcJnAUxpicSA;
						Elements elements = hFXaDLXOfkJjmxMFbozEMpMiNDKd;
						switch (num)
						{
						default:
							return false;
						case 0:
							kAxdjRfOYNkPQIjYYBcJnAUxpicSA = -1;
							if (elements.axes == null)
							{
								return false;
							}
							thJrAyiKMyfDbHkSGJIKeBVRzbxd = 0;
							break;
						case 1:
							kAxdjRfOYNkPQIjYYBcJnAUxpicSA = -1;
							thJrAyiKMyfDbHkSGJIKeBVRzbxd++;
							break;
						}
						if (thJrAyiKMyfDbHkSGJIKeBVRzbxd < elements.axes.Length)
						{
							dRDPivJcztVnxKGjfDGVbLMyIggp = elements.axes[thJrAyiKMyfDbHkSGJIKeBVRzbxd];
							kAxdjRfOYNkPQIjYYBcJnAUxpicSA = 1;
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
						RDUpyhEwOHSQmzpSSjCLiLAZAywO rDUpyhEwOHSQmzpSSjCLiLAZAywO;
						if (kAxdjRfOYNkPQIjYYBcJnAUxpicSA == -2 && ThvoclSqvoaIXtWMhHBKEZuscdRw == Environment.CurrentManagedThreadId)
						{
							kAxdjRfOYNkPQIjYYBcJnAUxpicSA = 0;
							rDUpyhEwOHSQmzpSSjCLiLAZAywO = this;
						}
						else
						{
							rDUpyhEwOHSQmzpSSjCLiLAZAywO = new RDUpyhEwOHSQmzpSSjCLiLAZAywO(0);
							rDUpyhEwOHSQmzpSSjCLiLAZAywO.hFXaDLXOfkJjmxMFbozEMpMiNDKd = hFXaDLXOfkJjmxMFbozEMpMiNDKd;
						}
						return rDUpyhEwOHSQmzpSSjCLiLAZAywO;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}
				}

				private sealed class ahynnYxPACqZGMPcGNONtgfsPWpU : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int nIqyHGAwXQDnKXDASMPLpKYHGvYD;

					private Button_Base HBwWbYbinsMItfsXASjOUQsDtkvW;

					private int UIgZnXhzCmgUXxMdBctZITocGVbGb;

					public Elements EKoIfSpJxNsfFdRWlvDFWQJbXssy;

					private int ynXZUTORsNAwXLCNrjuYBgVodsOW;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return HBwWbYbinsMItfsXASjOUQsDtkvW;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return HBwWbYbinsMItfsXASjOUQsDtkvW;
						}
					}

					[DebuggerHidden]
					public ahynnYxPACqZGMPcGNONtgfsPWpU(int P_0)
					{
						nIqyHGAwXQDnKXDASMPLpKYHGvYD = P_0;
						UIgZnXhzCmgUXxMdBctZITocGVbGb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						nIqyHGAwXQDnKXDASMPLpKYHGvYD = -2;
					}

					private bool MoveNext()
					{
						int num = nIqyHGAwXQDnKXDASMPLpKYHGvYD;
						Elements eKoIfSpJxNsfFdRWlvDFWQJbXssy = EKoIfSpJxNsfFdRWlvDFWQJbXssy;
						switch (num)
						{
						default:
							return false;
						case 0:
							nIqyHGAwXQDnKXDASMPLpKYHGvYD = -1;
							if (eKoIfSpJxNsfFdRWlvDFWQJbXssy.buttons == null)
							{
								return false;
							}
							ynXZUTORsNAwXLCNrjuYBgVodsOW = 0;
							break;
						case 1:
							nIqyHGAwXQDnKXDASMPLpKYHGvYD = -1;
							ynXZUTORsNAwXLCNrjuYBgVodsOW++;
							break;
						}
						if (ynXZUTORsNAwXLCNrjuYBgVodsOW < eKoIfSpJxNsfFdRWlvDFWQJbXssy.buttons.Length)
						{
							HBwWbYbinsMItfsXASjOUQsDtkvW = eKoIfSpJxNsfFdRWlvDFWQJbXssy.buttons[ynXZUTORsNAwXLCNrjuYBgVodsOW];
							nIqyHGAwXQDnKXDASMPLpKYHGvYD = 1;
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
						ahynnYxPACqZGMPcGNONtgfsPWpU ahynnYxPACqZGMPcGNONtgfsPWpU2;
						if (nIqyHGAwXQDnKXDASMPLpKYHGvYD == -2 && UIgZnXhzCmgUXxMdBctZITocGVbGb == Environment.CurrentManagedThreadId)
						{
							nIqyHGAwXQDnKXDASMPLpKYHGvYD = 0;
							ahynnYxPACqZGMPcGNONtgfsPWpU2 = this;
						}
						else
						{
							ahynnYxPACqZGMPcGNONtgfsPWpU2 = new ahynnYxPACqZGMPcGNONtgfsPWpU(0);
							ahynnYxPACqZGMPcGNONtgfsPWpU2.EKoIfSpJxNsfFdRWlvDFWQJbXssy = EKoIfSpJxNsfFdRWlvDFWQJbXssy;
						}
						return ahynnYxPACqZGMPcGNONtgfsPWpU2;
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
					[IteratorStateMachine(typeof(RDUpyhEwOHSQmzpSSjCLiLAZAywO))]
					get
					{
						return new RDUpyhEwOHSQmzpSSjCLiLAZAywO(-2)
						{
							hFXaDLXOfkJjmxMFbozEMpMiNDKd = this
						};
					}
				}

				IEnumerable<Button_Base> Elements_Platform_Base.Buttons
				{
					[IteratorStateMachine(typeof(ahynnYxPACqZGMPcGNONtgfsPWpU))]
					get
					{
						return new ahynnYxPACqZGMPcGNONtgfsPWpU(-2)
						{
							EKoIfSpJxNsfFdRWlvDFWQJbXssy = this
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

			private sealed class BAHirugFIbkJuRKlGNDNERYvQFSgA : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int HQBErugClTJXfpLpYhaKlVUGxbJI;

				private Axis_Base NOykKaJdEuIeSAyYTXOvQGAWaaGCA;

				private int JCzXiQyVDuXTRPEbyHoHecuKarbd;

				public Platform_RawInput_Base LMrvDCDGqlyyMeyOybmtxriRmrDr;

				private int MepHlboxXDtSwwlohUrsjRShteTd;

				private int stbRRPIhWAMGnpIRcuxblApBMwqO;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return NOykKaJdEuIeSAyYTXOvQGAWaaGCA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return NOykKaJdEuIeSAyYTXOvQGAWaaGCA;
					}
				}

				[DebuggerHidden]
				public BAHirugFIbkJuRKlGNDNERYvQFSgA(int P_0)
				{
					HQBErugClTJXfpLpYhaKlVUGxbJI = P_0;
					JCzXiQyVDuXTRPEbyHoHecuKarbd = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					HQBErugClTJXfpLpYhaKlVUGxbJI = -2;
				}

				private bool MoveNext()
				{
					int hQBErugClTJXfpLpYhaKlVUGxbJI = HQBErugClTJXfpLpYhaKlVUGxbJI;
					Platform_RawInput_Base lMrvDCDGqlyyMeyOybmtxriRmrDr = LMrvDCDGqlyyMeyOybmtxriRmrDr;
					switch (hQBErugClTJXfpLpYhaKlVUGxbJI)
					{
					default:
						return false;
					case 0:
						HQBErugClTJXfpLpYhaKlVUGxbJI = -1;
						if (lMrvDCDGqlyyMeyOybmtxriRmrDr.elements == null || lMrvDCDGqlyyMeyOybmtxriRmrDr.elements.axes == null)
						{
							return false;
						}
						MepHlboxXDtSwwlohUrsjRShteTd = lMrvDCDGqlyyMeyOybmtxriRmrDr.elements.axes.Length;
						stbRRPIhWAMGnpIRcuxblApBMwqO = 0;
						break;
					case 1:
						HQBErugClTJXfpLpYhaKlVUGxbJI = -1;
						stbRRPIhWAMGnpIRcuxblApBMwqO++;
						break;
					}
					if (stbRRPIhWAMGnpIRcuxblApBMwqO < MepHlboxXDtSwwlohUrsjRShteTd)
					{
						NOykKaJdEuIeSAyYTXOvQGAWaaGCA = lMrvDCDGqlyyMeyOybmtxriRmrDr.elements.axes[stbRRPIhWAMGnpIRcuxblApBMwqO];
						HQBErugClTJXfpLpYhaKlVUGxbJI = 1;
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
					BAHirugFIbkJuRKlGNDNERYvQFSgA bAHirugFIbkJuRKlGNDNERYvQFSgA;
					if (HQBErugClTJXfpLpYhaKlVUGxbJI == -2 && JCzXiQyVDuXTRPEbyHoHecuKarbd == Environment.CurrentManagedThreadId)
					{
						HQBErugClTJXfpLpYhaKlVUGxbJI = 0;
						bAHirugFIbkJuRKlGNDNERYvQFSgA = this;
					}
					else
					{
						bAHirugFIbkJuRKlGNDNERYvQFSgA = new BAHirugFIbkJuRKlGNDNERYvQFSgA(0);
						bAHirugFIbkJuRKlGNDNERYvQFSgA.LMrvDCDGqlyyMeyOybmtxriRmrDr = LMrvDCDGqlyyMeyOybmtxriRmrDr;
					}
					return bAHirugFIbkJuRKlGNDNERYvQFSgA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}
			}

			private sealed class XeJGWzgDDZEEQPPPbgJFkElRqPcz : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int hTqKoTtMzdEOeOglGppMryQLPyzP;

				private Button_Base NJKauMTkHHIIurBkRjjnHleLRIWYA;

				private int mXPndrZPeHItJMlaouPMvIAmALheA;

				public Platform_RawInput_Base zDkjJtwZdVFHakDcGcjRkPOafWKOA;

				private int CAPBbkulVPTJSbyoUDqJBPkvHHfD;

				private int OIAyycUSotfmWmSxZXhAoTyPtdJA;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return NJKauMTkHHIIurBkRjjnHleLRIWYA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return NJKauMTkHHIIurBkRjjnHleLRIWYA;
					}
				}

				[DebuggerHidden]
				public XeJGWzgDDZEEQPPPbgJFkElRqPcz(int P_0)
				{
					hTqKoTtMzdEOeOglGppMryQLPyzP = P_0;
					mXPndrZPeHItJMlaouPMvIAmALheA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					hTqKoTtMzdEOeOglGppMryQLPyzP = -2;
				}

				private bool MoveNext()
				{
					int num = hTqKoTtMzdEOeOglGppMryQLPyzP;
					Platform_RawInput_Base platform_RawInput_Base = zDkjJtwZdVFHakDcGcjRkPOafWKOA;
					switch (num)
					{
					default:
						return false;
					case 0:
						hTqKoTtMzdEOeOglGppMryQLPyzP = -1;
						if (platform_RawInput_Base.elements == null || platform_RawInput_Base.elements.buttons == null)
						{
							return false;
						}
						CAPBbkulVPTJSbyoUDqJBPkvHHfD = platform_RawInput_Base.elements.buttons.Length;
						OIAyycUSotfmWmSxZXhAoTyPtdJA = 0;
						break;
					case 1:
						hTqKoTtMzdEOeOglGppMryQLPyzP = -1;
						OIAyycUSotfmWmSxZXhAoTyPtdJA++;
						break;
					}
					if (OIAyycUSotfmWmSxZXhAoTyPtdJA < CAPBbkulVPTJSbyoUDqJBPkvHHfD)
					{
						NJKauMTkHHIIurBkRjjnHleLRIWYA = platform_RawInput_Base.elements.buttons[OIAyycUSotfmWmSxZXhAoTyPtdJA];
						hTqKoTtMzdEOeOglGppMryQLPyzP = 1;
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
					XeJGWzgDDZEEQPPPbgJFkElRqPcz xeJGWzgDDZEEQPPPbgJFkElRqPcz;
					if (hTqKoTtMzdEOeOglGppMryQLPyzP == -2 && mXPndrZPeHItJMlaouPMvIAmALheA == Environment.CurrentManagedThreadId)
					{
						hTqKoTtMzdEOeOglGppMryQLPyzP = 0;
						xeJGWzgDDZEEQPPPbgJFkElRqPcz = this;
					}
					else
					{
						xeJGWzgDDZEEQPPPbgJFkElRqPcz = new XeJGWzgDDZEEQPPPbgJFkElRqPcz(0);
						xeJGWzgDDZEEQPPPbgJFkElRqPcz.zDkjJtwZdVFHakDcGcjRkPOafWKOA = zDkjJtwZdVFHakDcGcjRkPOafWKOA;
					}
					return xeJGWzgDDZEEQPPPbgJFkElRqPcz;
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
						if (axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = Axes_orig[i].calibrateAxis;
						}
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

			[IteratorStateMachine(typeof(BAHirugFIbkJuRKlGNDNERYvQFSgA))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return new BAHirugFIbkJuRKlGNDNERYvQFSgA(-2)
				{
					LMrvDCDGqlyyMeyOybmtxriRmrDr = this
				};
			}

			[IteratorStateMachine(typeof(XeJGWzgDDZEEQPPPbgJFkElRqPcz))]
			internal override IEnumerable<Button_Base> IterateButtons()
			{
				return new XeJGWzgDDZEEQPPPbgJFkElRqPcz(-2)
				{
					zDkjJtwZdVFHakDcGcjRkPOafWKOA = this
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

			private sealed class yFUcvJpFauYSJFlMvRRVcLjJIsSO : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int AElZrBaEfbwNUMuGRdzZFNWhkJAe;

				private Axis IpXqcihRTyYKaAAxHkaAykJxEqtC;

				private int tKYLWKvtjKGZEmDGlfBUcKRCsJUN;

				public Platform_XInput_Base BkYxPahabgEoDkXQgZOPdrtuMcecb;

				private int rjrVdMlsyKMNZIEXwDfALCUoDRUI;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return IpXqcihRTyYKaAAxHkaAykJxEqtC;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return IpXqcihRTyYKaAAxHkaAykJxEqtC;
					}
				}

				[DebuggerHidden]
				public yFUcvJpFauYSJFlMvRRVcLjJIsSO(int P_0)
				{
					AElZrBaEfbwNUMuGRdzZFNWhkJAe = P_0;
					tKYLWKvtjKGZEmDGlfBUcKRCsJUN = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					AElZrBaEfbwNUMuGRdzZFNWhkJAe = -2;
				}

				private bool MoveNext()
				{
					int aElZrBaEfbwNUMuGRdzZFNWhkJAe = AElZrBaEfbwNUMuGRdzZFNWhkJAe;
					Platform_XInput_Base bkYxPahabgEoDkXQgZOPdrtuMcecb = BkYxPahabgEoDkXQgZOPdrtuMcecb;
					switch (aElZrBaEfbwNUMuGRdzZFNWhkJAe)
					{
					default:
						return false;
					case 0:
						AElZrBaEfbwNUMuGRdzZFNWhkJAe = -1;
						if (bkYxPahabgEoDkXQgZOPdrtuMcecb.elements == null || bkYxPahabgEoDkXQgZOPdrtuMcecb.elements.axes == null)
						{
							return false;
						}
						rjrVdMlsyKMNZIEXwDfALCUoDRUI = 0;
						break;
					case 1:
						AElZrBaEfbwNUMuGRdzZFNWhkJAe = -1;
						rjrVdMlsyKMNZIEXwDfALCUoDRUI++;
						break;
					}
					if (rjrVdMlsyKMNZIEXwDfALCUoDRUI < bkYxPahabgEoDkXQgZOPdrtuMcecb.elements.axes.Length)
					{
						IpXqcihRTyYKaAAxHkaAykJxEqtC = bkYxPahabgEoDkXQgZOPdrtuMcecb.elements.axes[rjrVdMlsyKMNZIEXwDfALCUoDRUI];
						AElZrBaEfbwNUMuGRdzZFNWhkJAe = 1;
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
					yFUcvJpFauYSJFlMvRRVcLjJIsSO yFUcvJpFauYSJFlMvRRVcLjJIsSO2;
					if (AElZrBaEfbwNUMuGRdzZFNWhkJAe == -2 && tKYLWKvtjKGZEmDGlfBUcKRCsJUN == Environment.CurrentManagedThreadId)
					{
						AElZrBaEfbwNUMuGRdzZFNWhkJAe = 0;
						yFUcvJpFauYSJFlMvRRVcLjJIsSO2 = this;
					}
					else
					{
						yFUcvJpFauYSJFlMvRRVcLjJIsSO2 = new yFUcvJpFauYSJFlMvRRVcLjJIsSO(0);
						yFUcvJpFauYSJFlMvRRVcLjJIsSO2.BkYxPahabgEoDkXQgZOPdrtuMcecb = BkYxPahabgEoDkXQgZOPdrtuMcecb;
					}
					return yFUcvJpFauYSJFlMvRRVcLjJIsSO2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class QfjEvFVyceBrTmariXTqZfbXHDbj : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int WmmcQdqxLwudFmMNXthqHBtqCHuhA;

				private Button BkrcgzDjLnFYTLAViBDTmqnsHYPv;

				private int CjLMipZishHVkeKnSdASSEKafkDg;

				public Platform_XInput_Base WQfFDfrdxuOResuDlfIjQzrFwrcY;

				private int TPNiLkMfYSuqKPodvYaNLqeWvABX;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return BkrcgzDjLnFYTLAViBDTmqnsHYPv;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return BkrcgzDjLnFYTLAViBDTmqnsHYPv;
					}
				}

				[DebuggerHidden]
				public QfjEvFVyceBrTmariXTqZfbXHDbj(int P_0)
				{
					WmmcQdqxLwudFmMNXthqHBtqCHuhA = P_0;
					CjLMipZishHVkeKnSdASSEKafkDg = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					WmmcQdqxLwudFmMNXthqHBtqCHuhA = -2;
				}

				private bool MoveNext()
				{
					int wmmcQdqxLwudFmMNXthqHBtqCHuhA = WmmcQdqxLwudFmMNXthqHBtqCHuhA;
					Platform_XInput_Base wQfFDfrdxuOResuDlfIjQzrFwrcY = WQfFDfrdxuOResuDlfIjQzrFwrcY;
					switch (wmmcQdqxLwudFmMNXthqHBtqCHuhA)
					{
					default:
						return false;
					case 0:
						WmmcQdqxLwudFmMNXthqHBtqCHuhA = -1;
						if (wQfFDfrdxuOResuDlfIjQzrFwrcY.elements == null || wQfFDfrdxuOResuDlfIjQzrFwrcY.elements.buttons == null)
						{
							return false;
						}
						TPNiLkMfYSuqKPodvYaNLqeWvABX = 0;
						break;
					case 1:
						WmmcQdqxLwudFmMNXthqHBtqCHuhA = -1;
						TPNiLkMfYSuqKPodvYaNLqeWvABX++;
						break;
					}
					if (TPNiLkMfYSuqKPodvYaNLqeWvABX < wQfFDfrdxuOResuDlfIjQzrFwrcY.elements.buttons.Length)
					{
						BkrcgzDjLnFYTLAViBDTmqnsHYPv = wQfFDfrdxuOResuDlfIjQzrFwrcY.elements.buttons[TPNiLkMfYSuqKPodvYaNLqeWvABX];
						WmmcQdqxLwudFmMNXthqHBtqCHuhA = 1;
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
					QfjEvFVyceBrTmariXTqZfbXHDbj qfjEvFVyceBrTmariXTqZfbXHDbj;
					if (WmmcQdqxLwudFmMNXthqHBtqCHuhA == -2 && CjLMipZishHVkeKnSdASSEKafkDg == Environment.CurrentManagedThreadId)
					{
						WmmcQdqxLwudFmMNXthqHBtqCHuhA = 0;
						qfjEvFVyceBrTmariXTqZfbXHDbj = this;
					}
					else
					{
						qfjEvFVyceBrTmariXTqZfbXHDbj = new QfjEvFVyceBrTmariXTqZfbXHDbj(0);
						qfjEvFVyceBrTmariXTqZfbXHDbj.WQfFDfrdxuOResuDlfIjQzrFwrcY = WQfFDfrdxuOResuDlfIjQzrFwrcY;
					}
					return qfjEvFVyceBrTmariXTqZfbXHDbj;
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

			[IteratorStateMachine(typeof(yFUcvJpFauYSJFlMvRRVcLjJIsSO))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new yFUcvJpFauYSJFlMvRRVcLjJIsSO(-2)
				{
					BkYxPahabgEoDkXQgZOPdrtuMcecb = this
				};
			}

			[IteratorStateMachine(typeof(QfjEvFVyceBrTmariXTqZfbXHDbj))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new QfjEvFVyceBrTmariXTqZfbXHDbj(-2)
				{
					WQfFDfrdxuOResuDlfIjQzrFwrcY = this
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
						if (axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = Axes_orig[i].calibrateAxis;
						}
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
						ajTmuZrfJgNWFabMneWjcfeLLiVW(elementCount);
						return elementCount;
					}

					internal void wIjOmomsYUDTWISXyAaOmLJvkcc(ElementCount_Base P_0)
					{
						base.ajTmuZrfJgNWFabMneWjcfeLLiVW(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool GokeQyATmOffHKBNnBBRAiBrdIOu(BridgedControllerHWInfo P_0)
					{
						if (!base.ZRIzpYvxiqqesJvpPGVJiNbpPZlD(P_0))
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
				private sealed class FvgTLKLdcJhpYLsrVFKSvaBQSFcc : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int xOKBkcYNaJvyOCYEQnIJYPQPCxQV;

					private Axis youkCxlMxbsQEgjplDrExlvlbqLaA;

					private int deOfhtfFDtLiKjMYISleEHzjlTNjA;

					public Elements XkruFdIgfTcBKTujFndxzaHtywnQ;

					private Axis[] qRsxWTNbdiDrwfjTbMClfDXxGrVgA;

					private int xBSaxGgJaoabKJyaHCAdzWDuVotF;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return youkCxlMxbsQEgjplDrExlvlbqLaA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return youkCxlMxbsQEgjplDrExlvlbqLaA;
						}
					}

					[DebuggerHidden]
					public FvgTLKLdcJhpYLsrVFKSvaBQSFcc(int P_0)
					{
						xOKBkcYNaJvyOCYEQnIJYPQPCxQV = P_0;
						deOfhtfFDtLiKjMYISleEHzjlTNjA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						qRsxWTNbdiDrwfjTbMClfDXxGrVgA = null;
						xOKBkcYNaJvyOCYEQnIJYPQPCxQV = -2;
					}

					private bool MoveNext()
					{
						int num = xOKBkcYNaJvyOCYEQnIJYPQPCxQV;
						Elements xkruFdIgfTcBKTujFndxzaHtywnQ = XkruFdIgfTcBKTujFndxzaHtywnQ;
						switch (num)
						{
						default:
							return false;
						case 0:
							xOKBkcYNaJvyOCYEQnIJYPQPCxQV = -1;
							if (xkruFdIgfTcBKTujFndxzaHtywnQ.axes == null)
							{
								return false;
							}
							qRsxWTNbdiDrwfjTbMClfDXxGrVgA = xkruFdIgfTcBKTujFndxzaHtywnQ.axes;
							xBSaxGgJaoabKJyaHCAdzWDuVotF = 0;
							break;
						case 1:
							xOKBkcYNaJvyOCYEQnIJYPQPCxQV = -1;
							xBSaxGgJaoabKJyaHCAdzWDuVotF++;
							break;
						}
						if (xBSaxGgJaoabKJyaHCAdzWDuVotF < qRsxWTNbdiDrwfjTbMClfDXxGrVgA.Length)
						{
							Axis axis = qRsxWTNbdiDrwfjTbMClfDXxGrVgA[xBSaxGgJaoabKJyaHCAdzWDuVotF];
							youkCxlMxbsQEgjplDrExlvlbqLaA = axis;
							xOKBkcYNaJvyOCYEQnIJYPQPCxQV = 1;
							return true;
						}
						qRsxWTNbdiDrwfjTbMClfDXxGrVgA = null;
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
						FvgTLKLdcJhpYLsrVFKSvaBQSFcc fvgTLKLdcJhpYLsrVFKSvaBQSFcc;
						if (xOKBkcYNaJvyOCYEQnIJYPQPCxQV == -2 && deOfhtfFDtLiKjMYISleEHzjlTNjA == Environment.CurrentManagedThreadId)
						{
							xOKBkcYNaJvyOCYEQnIJYPQPCxQV = 0;
							fvgTLKLdcJhpYLsrVFKSvaBQSFcc = this;
						}
						else
						{
							fvgTLKLdcJhpYLsrVFKSvaBQSFcc = new FvgTLKLdcJhpYLsrVFKSvaBQSFcc(0);
							fvgTLKLdcJhpYLsrVFKSvaBQSFcc.XkruFdIgfTcBKTujFndxzaHtywnQ = XkruFdIgfTcBKTujFndxzaHtywnQ;
						}
						return fvgTLKLdcJhpYLsrVFKSvaBQSFcc;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class apoQArIiLsdyYIHLYLFQjzglVSLm : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int vwCbEwzRnKcwXOtCuEkiFvkjBprXA;

					private Button KWDLnbfvjjecpWbggEqTKHDpOodmA;

					private int nqxvZQviDLlWcHdTzzURpusqfFQI;

					public Elements oilgLzCWclhTcuyQIgxilXpEvYnkA;

					private Button[] FFwgeyQFWBPDyBgSOCYYDLkMcuYjA;

					private int yfztwMZtJtPQSYapSnpcpLlbaRqc;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return KWDLnbfvjjecpWbggEqTKHDpOodmA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return KWDLnbfvjjecpWbggEqTKHDpOodmA;
						}
					}

					[DebuggerHidden]
					public apoQArIiLsdyYIHLYLFQjzglVSLm(int P_0)
					{
						vwCbEwzRnKcwXOtCuEkiFvkjBprXA = P_0;
						nqxvZQviDLlWcHdTzzURpusqfFQI = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						FFwgeyQFWBPDyBgSOCYYDLkMcuYjA = null;
						vwCbEwzRnKcwXOtCuEkiFvkjBprXA = -2;
					}

					private bool MoveNext()
					{
						int num = vwCbEwzRnKcwXOtCuEkiFvkjBprXA;
						Elements elements = oilgLzCWclhTcuyQIgxilXpEvYnkA;
						switch (num)
						{
						default:
							return false;
						case 0:
							vwCbEwzRnKcwXOtCuEkiFvkjBprXA = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							FFwgeyQFWBPDyBgSOCYYDLkMcuYjA = elements.buttons;
							yfztwMZtJtPQSYapSnpcpLlbaRqc = 0;
							break;
						case 1:
							vwCbEwzRnKcwXOtCuEkiFvkjBprXA = -1;
							yfztwMZtJtPQSYapSnpcpLlbaRqc++;
							break;
						}
						if (yfztwMZtJtPQSYapSnpcpLlbaRqc < FFwgeyQFWBPDyBgSOCYYDLkMcuYjA.Length)
						{
							Button kWDLnbfvjjecpWbggEqTKHDpOodmA = FFwgeyQFWBPDyBgSOCYYDLkMcuYjA[yfztwMZtJtPQSYapSnpcpLlbaRqc];
							KWDLnbfvjjecpWbggEqTKHDpOodmA = kWDLnbfvjjecpWbggEqTKHDpOodmA;
							vwCbEwzRnKcwXOtCuEkiFvkjBprXA = 1;
							return true;
						}
						FFwgeyQFWBPDyBgSOCYYDLkMcuYjA = null;
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
						apoQArIiLsdyYIHLYLFQjzglVSLm apoQArIiLsdyYIHLYLFQjzglVSLm2;
						if (vwCbEwzRnKcwXOtCuEkiFvkjBprXA == -2 && nqxvZQviDLlWcHdTzzURpusqfFQI == Environment.CurrentManagedThreadId)
						{
							vwCbEwzRnKcwXOtCuEkiFvkjBprXA = 0;
							apoQArIiLsdyYIHLYLFQjzglVSLm2 = this;
						}
						else
						{
							apoQArIiLsdyYIHLYLFQjzglVSLm2 = new apoQArIiLsdyYIHLYLFQjzglVSLm(0);
							apoQArIiLsdyYIHLYLFQjzglVSLm2.oilgLzCWclhTcuyQIgxilXpEvYnkA = oilgLzCWclhTcuyQIgxilXpEvYnkA;
						}
						return apoQArIiLsdyYIHLYLFQjzglVSLm2;
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

				[IteratorStateMachine(typeof(FvgTLKLdcJhpYLsrVFKSvaBQSFcc))]
				public IEnumerable<Axis> IterateAxes()
				{
					return new FvgTLKLdcJhpYLsrVFKSvaBQSFcc(-2)
					{
						XkruFdIgfTcBKTujFndxzaHtywnQ = this
					};
				}

				[IteratorStateMachine(typeof(apoQArIiLsdyYIHLYLFQjzglVSLm))]
				public IEnumerable<Button> IterateButtons()
				{
					return new apoQArIiLsdyYIHLYLFQjzglVSLm(-2)
					{
						oilgLzCWclhTcuyQIgxilXpEvYnkA = this
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

			private sealed class rHiWwNzGdRrHAcowFRTavPVRoBhv : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int whHrleyEXwQepwIiWslEGKJOUlMu;

				private Axis OXgFVCmpvdnJnlRcwqmUmBWHNlQk;

				private int jelbogdhsFtwBQMLjfbLvWaiTmbvA;

				public Platform_OSX_Base AiUwlYPfpCiVBDHaolLAmoQrqhiEb;

				private int GkXkYLhJoTPqbpKfMmoGNTQGiaqH;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return OXgFVCmpvdnJnlRcwqmUmBWHNlQk;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return OXgFVCmpvdnJnlRcwqmUmBWHNlQk;
					}
				}

				[DebuggerHidden]
				public rHiWwNzGdRrHAcowFRTavPVRoBhv(int P_0)
				{
					whHrleyEXwQepwIiWslEGKJOUlMu = P_0;
					jelbogdhsFtwBQMLjfbLvWaiTmbvA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					whHrleyEXwQepwIiWslEGKJOUlMu = -2;
				}

				private bool MoveNext()
				{
					int num = whHrleyEXwQepwIiWslEGKJOUlMu;
					Platform_OSX_Base aiUwlYPfpCiVBDHaolLAmoQrqhiEb = AiUwlYPfpCiVBDHaolLAmoQrqhiEb;
					switch (num)
					{
					default:
						return false;
					case 0:
						whHrleyEXwQepwIiWslEGKJOUlMu = -1;
						if (aiUwlYPfpCiVBDHaolLAmoQrqhiEb.elements == null || aiUwlYPfpCiVBDHaolLAmoQrqhiEb.elements.axes == null)
						{
							return false;
						}
						GkXkYLhJoTPqbpKfMmoGNTQGiaqH = 0;
						break;
					case 1:
						whHrleyEXwQepwIiWslEGKJOUlMu = -1;
						GkXkYLhJoTPqbpKfMmoGNTQGiaqH++;
						break;
					}
					if (GkXkYLhJoTPqbpKfMmoGNTQGiaqH < aiUwlYPfpCiVBDHaolLAmoQrqhiEb.elements.axes.Length)
					{
						OXgFVCmpvdnJnlRcwqmUmBWHNlQk = aiUwlYPfpCiVBDHaolLAmoQrqhiEb.elements.axes[GkXkYLhJoTPqbpKfMmoGNTQGiaqH];
						whHrleyEXwQepwIiWslEGKJOUlMu = 1;
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
					rHiWwNzGdRrHAcowFRTavPVRoBhv rHiWwNzGdRrHAcowFRTavPVRoBhv2;
					if (whHrleyEXwQepwIiWslEGKJOUlMu == -2 && jelbogdhsFtwBQMLjfbLvWaiTmbvA == Environment.CurrentManagedThreadId)
					{
						whHrleyEXwQepwIiWslEGKJOUlMu = 0;
						rHiWwNzGdRrHAcowFRTavPVRoBhv2 = this;
					}
					else
					{
						rHiWwNzGdRrHAcowFRTavPVRoBhv2 = new rHiWwNzGdRrHAcowFRTavPVRoBhv(0);
						rHiWwNzGdRrHAcowFRTavPVRoBhv2.AiUwlYPfpCiVBDHaolLAmoQrqhiEb = AiUwlYPfpCiVBDHaolLAmoQrqhiEb;
					}
					return rHiWwNzGdRrHAcowFRTavPVRoBhv2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class tyhoGEsNQkQVRkuFmDfaqrtGxwjD : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int HtjuGaAHjgGOdpDzAmrZEeqvkWpd;

				private Button aMIKbpzxjSYPvitnKIZlZnIrkrfi;

				private int WtxfVHmLnTzzBXJPcWHLqvLfJAEc;

				public Platform_OSX_Base hblBjBinCIYokulccLtwNvcoMxiI;

				private int BVFGwzGKOWUYfMboseggABpkDXDk;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return aMIKbpzxjSYPvitnKIZlZnIrkrfi;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return aMIKbpzxjSYPvitnKIZlZnIrkrfi;
					}
				}

				[DebuggerHidden]
				public tyhoGEsNQkQVRkuFmDfaqrtGxwjD(int P_0)
				{
					HtjuGaAHjgGOdpDzAmrZEeqvkWpd = P_0;
					WtxfVHmLnTzzBXJPcWHLqvLfJAEc = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					HtjuGaAHjgGOdpDzAmrZEeqvkWpd = -2;
				}

				private bool MoveNext()
				{
					int htjuGaAHjgGOdpDzAmrZEeqvkWpd = HtjuGaAHjgGOdpDzAmrZEeqvkWpd;
					Platform_OSX_Base platform_OSX_Base = hblBjBinCIYokulccLtwNvcoMxiI;
					switch (htjuGaAHjgGOdpDzAmrZEeqvkWpd)
					{
					default:
						return false;
					case 0:
						HtjuGaAHjgGOdpDzAmrZEeqvkWpd = -1;
						if (platform_OSX_Base.elements == null || platform_OSX_Base.elements.buttons == null)
						{
							return false;
						}
						BVFGwzGKOWUYfMboseggABpkDXDk = 0;
						break;
					case 1:
						HtjuGaAHjgGOdpDzAmrZEeqvkWpd = -1;
						BVFGwzGKOWUYfMboseggABpkDXDk++;
						break;
					}
					if (BVFGwzGKOWUYfMboseggABpkDXDk < platform_OSX_Base.elements.buttons.Length)
					{
						aMIKbpzxjSYPvitnKIZlZnIrkrfi = platform_OSX_Base.elements.buttons[BVFGwzGKOWUYfMboseggABpkDXDk];
						HtjuGaAHjgGOdpDzAmrZEeqvkWpd = 1;
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
					tyhoGEsNQkQVRkuFmDfaqrtGxwjD tyhoGEsNQkQVRkuFmDfaqrtGxwjD2;
					if (HtjuGaAHjgGOdpDzAmrZEeqvkWpd == -2 && WtxfVHmLnTzzBXJPcWHLqvLfJAEc == Environment.CurrentManagedThreadId)
					{
						HtjuGaAHjgGOdpDzAmrZEeqvkWpd = 0;
						tyhoGEsNQkQVRkuFmDfaqrtGxwjD2 = this;
					}
					else
					{
						tyhoGEsNQkQVRkuFmDfaqrtGxwjD2 = new tyhoGEsNQkQVRkuFmDfaqrtGxwjD(0);
						tyhoGEsNQkQVRkuFmDfaqrtGxwjD2.hblBjBinCIYokulccLtwNvcoMxiI = hblBjBinCIYokulccLtwNvcoMxiI;
					}
					return tyhoGEsNQkQVRkuFmDfaqrtGxwjD2;
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

			[IteratorStateMachine(typeof(rHiWwNzGdRrHAcowFRTavPVRoBhv))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new rHiWwNzGdRrHAcowFRTavPVRoBhv(-2)
				{
					AiUwlYPfpCiVBDHaolLAmoQrqhiEb = this
				};
			}

			[IteratorStateMachine(typeof(tyhoGEsNQkQVRkuFmDfaqrtGxwjD))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new tyhoGEsNQkQVRkuFmDfaqrtGxwjD(-2)
				{
					hblBjBinCIYokulccLtwNvcoMxiI = this
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
						if (axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = Axes_orig[i].calibrateAxis;
						}
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
						ajTmuZrfJgNWFabMneWjcfeLLiVW(elementCount);
						return elementCount;
					}

					internal void HDYDnCHJEHlYnPZjxHohmJzuhWDDb(ElementCount_Base P_0)
					{
						base.ajTmuZrfJgNWFabMneWjcfeLLiVW(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool RWMFHRuHFQeRcmwCUBQDxDWBqeEt(BridgedControllerHWInfo P_0)
					{
						if (!base.ZRIzpYvxiqqesJvpPGVJiNbpPZlD(P_0))
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
				private sealed class VQImkuHngwskmGQTENKkEXTfoekN : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int PFEysRjyxFPCuxOXJCVRkEKExJrC;

					private Axis RHSnikhzjMDNJidQiZRKdpzMBTLBA;

					private int fwKRgkeRtgSnVKaoZuqCbGIRxFoW;

					public Elements QMRcHAHkkcmAypGDolrXvebyjNfD;

					private int wIXDBJKpkpoENcPzfLnRSLmEKscSB;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return RHSnikhzjMDNJidQiZRKdpzMBTLBA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RHSnikhzjMDNJidQiZRKdpzMBTLBA;
						}
					}

					[DebuggerHidden]
					public VQImkuHngwskmGQTENKkEXTfoekN(int P_0)
					{
						PFEysRjyxFPCuxOXJCVRkEKExJrC = P_0;
						fwKRgkeRtgSnVKaoZuqCbGIRxFoW = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						PFEysRjyxFPCuxOXJCVRkEKExJrC = -2;
					}

					private bool MoveNext()
					{
						int pFEysRjyxFPCuxOXJCVRkEKExJrC = PFEysRjyxFPCuxOXJCVRkEKExJrC;
						Elements qMRcHAHkkcmAypGDolrXvebyjNfD = QMRcHAHkkcmAypGDolrXvebyjNfD;
						switch (pFEysRjyxFPCuxOXJCVRkEKExJrC)
						{
						default:
							return false;
						case 0:
							PFEysRjyxFPCuxOXJCVRkEKExJrC = -1;
							if (qMRcHAHkkcmAypGDolrXvebyjNfD.axes == null)
							{
								return false;
							}
							wIXDBJKpkpoENcPzfLnRSLmEKscSB = 0;
							break;
						case 1:
							PFEysRjyxFPCuxOXJCVRkEKExJrC = -1;
							wIXDBJKpkpoENcPzfLnRSLmEKscSB++;
							break;
						}
						if (wIXDBJKpkpoENcPzfLnRSLmEKscSB < qMRcHAHkkcmAypGDolrXvebyjNfD.axes.Length)
						{
							RHSnikhzjMDNJidQiZRKdpzMBTLBA = qMRcHAHkkcmAypGDolrXvebyjNfD.axes[wIXDBJKpkpoENcPzfLnRSLmEKscSB];
							PFEysRjyxFPCuxOXJCVRkEKExJrC = 1;
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
						VQImkuHngwskmGQTENKkEXTfoekN vQImkuHngwskmGQTENKkEXTfoekN;
						if (PFEysRjyxFPCuxOXJCVRkEKExJrC == -2 && fwKRgkeRtgSnVKaoZuqCbGIRxFoW == Environment.CurrentManagedThreadId)
						{
							PFEysRjyxFPCuxOXJCVRkEKExJrC = 0;
							vQImkuHngwskmGQTENKkEXTfoekN = this;
						}
						else
						{
							vQImkuHngwskmGQTENKkEXTfoekN = new VQImkuHngwskmGQTENKkEXTfoekN(0);
							vQImkuHngwskmGQTENKkEXTfoekN.QMRcHAHkkcmAypGDolrXvebyjNfD = QMRcHAHkkcmAypGDolrXvebyjNfD;
						}
						return vQImkuHngwskmGQTENKkEXTfoekN;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class aUdVWaJgzxdhjIIDviJEmhtyiaTDb : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int QOrVSIbbHWgtpWEUzdZACFctJOFS;

					private Button jENGOBfpIUfPpJxigexCcMShiysSA;

					private int DnmpBRbduCWoOjphDQbHMeUhAGdHA;

					public Elements nltdZqoktNCFLjhwklLjDpCpYckb;

					private int PRUWMtPeHKdEmdRpHFMOcBAvLYtBb;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return jENGOBfpIUfPpJxigexCcMShiysSA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return jENGOBfpIUfPpJxigexCcMShiysSA;
						}
					}

					[DebuggerHidden]
					public aUdVWaJgzxdhjIIDviJEmhtyiaTDb(int P_0)
					{
						QOrVSIbbHWgtpWEUzdZACFctJOFS = P_0;
						DnmpBRbduCWoOjphDQbHMeUhAGdHA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						QOrVSIbbHWgtpWEUzdZACFctJOFS = -2;
					}

					private bool MoveNext()
					{
						int qOrVSIbbHWgtpWEUzdZACFctJOFS = QOrVSIbbHWgtpWEUzdZACFctJOFS;
						Elements elements = nltdZqoktNCFLjhwklLjDpCpYckb;
						switch (qOrVSIbbHWgtpWEUzdZACFctJOFS)
						{
						default:
							return false;
						case 0:
							QOrVSIbbHWgtpWEUzdZACFctJOFS = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							PRUWMtPeHKdEmdRpHFMOcBAvLYtBb = 0;
							break;
						case 1:
							QOrVSIbbHWgtpWEUzdZACFctJOFS = -1;
							PRUWMtPeHKdEmdRpHFMOcBAvLYtBb++;
							break;
						}
						if (PRUWMtPeHKdEmdRpHFMOcBAvLYtBb < elements.buttons.Length)
						{
							jENGOBfpIUfPpJxigexCcMShiysSA = elements.buttons[PRUWMtPeHKdEmdRpHFMOcBAvLYtBb];
							QOrVSIbbHWgtpWEUzdZACFctJOFS = 1;
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
						aUdVWaJgzxdhjIIDviJEmhtyiaTDb aUdVWaJgzxdhjIIDviJEmhtyiaTDb2;
						if (QOrVSIbbHWgtpWEUzdZACFctJOFS == -2 && DnmpBRbduCWoOjphDQbHMeUhAGdHA == Environment.CurrentManagedThreadId)
						{
							QOrVSIbbHWgtpWEUzdZACFctJOFS = 0;
							aUdVWaJgzxdhjIIDviJEmhtyiaTDb2 = this;
						}
						else
						{
							aUdVWaJgzxdhjIIDviJEmhtyiaTDb2 = new aUdVWaJgzxdhjIIDviJEmhtyiaTDb(0);
							aUdVWaJgzxdhjIIDviJEmhtyiaTDb2.nltdZqoktNCFLjhwklLjDpCpYckb = nltdZqoktNCFLjhwklLjDpCpYckb;
						}
						return aUdVWaJgzxdhjIIDviJEmhtyiaTDb2;
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
					[IteratorStateMachine(typeof(VQImkuHngwskmGQTENKkEXTfoekN))]
					get
					{
						return new VQImkuHngwskmGQTENKkEXTfoekN(-2)
						{
							QMRcHAHkkcmAypGDolrXvebyjNfD = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(aUdVWaJgzxdhjIIDviJEmhtyiaTDb))]
					get
					{
						return new aUdVWaJgzxdhjIIDviJEmhtyiaTDb(-2)
						{
							nltdZqoktNCFLjhwklLjDpCpYckb = this
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

			private sealed class SzkIlvdXaqbMoYYZxEtMbZKqtREQ : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int huKqOyyBAmPNAmupyiQpoiytrCcY;

				private Axis FMggYzAjBEYKzBWMvJBWWcQYDvfb;

				private int gvLHfTkmmMdWSGqFVdvBflTfUgXuA;

				public Platform_Linux_Base fsbVnmjjsdUTwuWOZLulEKfnqWoe;

				private int lYoSBHmhaAcZlOsbyUxUuSxiSAkp;

				private int dcshnSVizSDhZdxzNqoKFlFrLEUW;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return FMggYzAjBEYKzBWMvJBWWcQYDvfb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return FMggYzAjBEYKzBWMvJBWWcQYDvfb;
					}
				}

				[DebuggerHidden]
				public SzkIlvdXaqbMoYYZxEtMbZKqtREQ(int P_0)
				{
					huKqOyyBAmPNAmupyiQpoiytrCcY = P_0;
					gvLHfTkmmMdWSGqFVdvBflTfUgXuA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					huKqOyyBAmPNAmupyiQpoiytrCcY = -2;
				}

				private bool MoveNext()
				{
					int num = huKqOyyBAmPNAmupyiQpoiytrCcY;
					Platform_Linux_Base platform_Linux_Base = fsbVnmjjsdUTwuWOZLulEKfnqWoe;
					switch (num)
					{
					default:
						return false;
					case 0:
						huKqOyyBAmPNAmupyiQpoiytrCcY = -1;
						if (platform_Linux_Base.elements == null || platform_Linux_Base.elements.axes == null)
						{
							return false;
						}
						lYoSBHmhaAcZlOsbyUxUuSxiSAkp = platform_Linux_Base.elements.axes.Length;
						dcshnSVizSDhZdxzNqoKFlFrLEUW = 0;
						break;
					case 1:
						huKqOyyBAmPNAmupyiQpoiytrCcY = -1;
						dcshnSVizSDhZdxzNqoKFlFrLEUW++;
						break;
					}
					if (dcshnSVizSDhZdxzNqoKFlFrLEUW < lYoSBHmhaAcZlOsbyUxUuSxiSAkp)
					{
						FMggYzAjBEYKzBWMvJBWWcQYDvfb = platform_Linux_Base.elements.axes[dcshnSVizSDhZdxzNqoKFlFrLEUW];
						huKqOyyBAmPNAmupyiQpoiytrCcY = 1;
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
					SzkIlvdXaqbMoYYZxEtMbZKqtREQ szkIlvdXaqbMoYYZxEtMbZKqtREQ;
					if (huKqOyyBAmPNAmupyiQpoiytrCcY == -2 && gvLHfTkmmMdWSGqFVdvBflTfUgXuA == Environment.CurrentManagedThreadId)
					{
						huKqOyyBAmPNAmupyiQpoiytrCcY = 0;
						szkIlvdXaqbMoYYZxEtMbZKqtREQ = this;
					}
					else
					{
						szkIlvdXaqbMoYYZxEtMbZKqtREQ = new SzkIlvdXaqbMoYYZxEtMbZKqtREQ(0);
						szkIlvdXaqbMoYYZxEtMbZKqtREQ.fsbVnmjjsdUTwuWOZLulEKfnqWoe = fsbVnmjjsdUTwuWOZLulEKfnqWoe;
					}
					return szkIlvdXaqbMoYYZxEtMbZKqtREQ;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class IfxqevIaJatYXvlgdLrWDJCaRBZQ : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int wWOLDfnLZUcoxzIirdDebSvACUpB;

				private Button wVOEquadCgyToNpahLglOlsNhZDuA;

				private int lUyEanTLtxGucbgZIrSghnJGiGVxA;

				public Platform_Linux_Base YWwrBYFOpQxMyerosnbhLgwFvHrr;

				private int KqhJgZnEpedvcgPaycDiEDvERzUl;

				private int NlkoQSzZDIwinRPCaugqJdDUzJcc;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return wVOEquadCgyToNpahLglOlsNhZDuA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return wVOEquadCgyToNpahLglOlsNhZDuA;
					}
				}

				[DebuggerHidden]
				public IfxqevIaJatYXvlgdLrWDJCaRBZQ(int P_0)
				{
					wWOLDfnLZUcoxzIirdDebSvACUpB = P_0;
					lUyEanTLtxGucbgZIrSghnJGiGVxA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					wWOLDfnLZUcoxzIirdDebSvACUpB = -2;
				}

				private bool MoveNext()
				{
					int num = wWOLDfnLZUcoxzIirdDebSvACUpB;
					Platform_Linux_Base yWwrBYFOpQxMyerosnbhLgwFvHrr = YWwrBYFOpQxMyerosnbhLgwFvHrr;
					switch (num)
					{
					default:
						return false;
					case 0:
						wWOLDfnLZUcoxzIirdDebSvACUpB = -1;
						if (yWwrBYFOpQxMyerosnbhLgwFvHrr.elements == null || yWwrBYFOpQxMyerosnbhLgwFvHrr.elements.buttons == null)
						{
							return false;
						}
						KqhJgZnEpedvcgPaycDiEDvERzUl = yWwrBYFOpQxMyerosnbhLgwFvHrr.elements.buttons.Length;
						NlkoQSzZDIwinRPCaugqJdDUzJcc = 0;
						break;
					case 1:
						wWOLDfnLZUcoxzIirdDebSvACUpB = -1;
						NlkoQSzZDIwinRPCaugqJdDUzJcc++;
						break;
					}
					if (NlkoQSzZDIwinRPCaugqJdDUzJcc < KqhJgZnEpedvcgPaycDiEDvERzUl)
					{
						wVOEquadCgyToNpahLglOlsNhZDuA = yWwrBYFOpQxMyerosnbhLgwFvHrr.elements.buttons[NlkoQSzZDIwinRPCaugqJdDUzJcc];
						wWOLDfnLZUcoxzIirdDebSvACUpB = 1;
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
					IfxqevIaJatYXvlgdLrWDJCaRBZQ ifxqevIaJatYXvlgdLrWDJCaRBZQ;
					if (wWOLDfnLZUcoxzIirdDebSvACUpB == -2 && lUyEanTLtxGucbgZIrSghnJGiGVxA == Environment.CurrentManagedThreadId)
					{
						wWOLDfnLZUcoxzIirdDebSvACUpB = 0;
						ifxqevIaJatYXvlgdLrWDJCaRBZQ = this;
					}
					else
					{
						ifxqevIaJatYXvlgdLrWDJCaRBZQ = new IfxqevIaJatYXvlgdLrWDJCaRBZQ(0);
						ifxqevIaJatYXvlgdLrWDJCaRBZQ.YWwrBYFOpQxMyerosnbhLgwFvHrr = YWwrBYFOpQxMyerosnbhLgwFvHrr;
					}
					return ifxqevIaJatYXvlgdLrWDJCaRBZQ;
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
						if (axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = Axes_orig[i].calibrateAxis;
						}
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

			[IteratorStateMachine(typeof(SzkIlvdXaqbMoYYZxEtMbZKqtREQ))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new SzkIlvdXaqbMoYYZxEtMbZKqtREQ(-2)
				{
					fsbVnmjjsdUTwuWOZLulEKfnqWoe = this
				};
			}

			[IteratorStateMachine(typeof(IfxqevIaJatYXvlgdLrWDJCaRBZQ))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new IfxqevIaJatYXvlgdLrWDJCaRBZQ(-2)
				{
					YWwrBYFOpQxMyerosnbhLgwFvHrr = this
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
						ajTmuZrfJgNWFabMneWjcfeLLiVW(elementCount);
						return elementCount;
					}

					internal void IxiupjYKEMHcNBWtIrGavMnhANgxA(ElementCount_Base P_0)
					{
						base.ajTmuZrfJgNWFabMneWjcfeLLiVW(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool LkeDewDfgAWBmjjgDYzVmLswCaND(BridgedControllerHWInfo P_0)
					{
						if (!base.ZRIzpYvxiqqesJvpPGVJiNbpPZlD(P_0))
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
				private sealed class UclgFfLEPIkkaQDcGPMKoZAQwInW : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int XUaSJmNAwrHHNJFoZGhjftXrjleKA;

					private Axis WaOtSzidZCeLBiAOqqiEhlOcvMZvB;

					private int DWVAXXBEGUZHmHciTjJKYCnZqaoE;

					public Elements TrbJMUVERfssmqDtxNCKocHKZmpp;

					private int EEGiTNxiOGDpDdPOxPnNlfJxIoeBb;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return WaOtSzidZCeLBiAOqqiEhlOcvMZvB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WaOtSzidZCeLBiAOqqiEhlOcvMZvB;
						}
					}

					[DebuggerHidden]
					public UclgFfLEPIkkaQDcGPMKoZAQwInW(int P_0)
					{
						XUaSJmNAwrHHNJFoZGhjftXrjleKA = P_0;
						DWVAXXBEGUZHmHciTjJKYCnZqaoE = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						XUaSJmNAwrHHNJFoZGhjftXrjleKA = -2;
					}

					private bool MoveNext()
					{
						int xUaSJmNAwrHHNJFoZGhjftXrjleKA = XUaSJmNAwrHHNJFoZGhjftXrjleKA;
						Elements trbJMUVERfssmqDtxNCKocHKZmpp = TrbJMUVERfssmqDtxNCKocHKZmpp;
						switch (xUaSJmNAwrHHNJFoZGhjftXrjleKA)
						{
						default:
							return false;
						case 0:
							XUaSJmNAwrHHNJFoZGhjftXrjleKA = -1;
							if (trbJMUVERfssmqDtxNCKocHKZmpp.axes == null)
							{
								return false;
							}
							EEGiTNxiOGDpDdPOxPnNlfJxIoeBb = 0;
							break;
						case 1:
							XUaSJmNAwrHHNJFoZGhjftXrjleKA = -1;
							EEGiTNxiOGDpDdPOxPnNlfJxIoeBb++;
							break;
						}
						if (EEGiTNxiOGDpDdPOxPnNlfJxIoeBb < trbJMUVERfssmqDtxNCKocHKZmpp.axes.Length)
						{
							WaOtSzidZCeLBiAOqqiEhlOcvMZvB = trbJMUVERfssmqDtxNCKocHKZmpp.axes[EEGiTNxiOGDpDdPOxPnNlfJxIoeBb];
							XUaSJmNAwrHHNJFoZGhjftXrjleKA = 1;
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
						UclgFfLEPIkkaQDcGPMKoZAQwInW uclgFfLEPIkkaQDcGPMKoZAQwInW;
						if (XUaSJmNAwrHHNJFoZGhjftXrjleKA == -2 && DWVAXXBEGUZHmHciTjJKYCnZqaoE == Environment.CurrentManagedThreadId)
						{
							XUaSJmNAwrHHNJFoZGhjftXrjleKA = 0;
							uclgFfLEPIkkaQDcGPMKoZAQwInW = this;
						}
						else
						{
							uclgFfLEPIkkaQDcGPMKoZAQwInW = new UclgFfLEPIkkaQDcGPMKoZAQwInW(0);
							uclgFfLEPIkkaQDcGPMKoZAQwInW.TrbJMUVERfssmqDtxNCKocHKZmpp = TrbJMUVERfssmqDtxNCKocHKZmpp;
						}
						return uclgFfLEPIkkaQDcGPMKoZAQwInW;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class xuRlinIVatfWrlkKisOBhqciqXh : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int qmteRmZvteLPaIpdPxpggYmEtgqI;

					private Button cGkDYhisAmzlzAoRAIPBKfKHUSrF;

					private int GhniEFgFFTRaQiPQkSgQtAcSdIwfA;

					public Elements XRjLkhzxImQTtIEeoZLonWsWuOZU;

					private int JJqAlAakYfyklnRjQHfXmLyjGtMtA;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return cGkDYhisAmzlzAoRAIPBKfKHUSrF;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return cGkDYhisAmzlzAoRAIPBKfKHUSrF;
						}
					}

					[DebuggerHidden]
					public xuRlinIVatfWrlkKisOBhqciqXh(int P_0)
					{
						qmteRmZvteLPaIpdPxpggYmEtgqI = P_0;
						GhniEFgFFTRaQiPQkSgQtAcSdIwfA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						qmteRmZvteLPaIpdPxpggYmEtgqI = -2;
					}

					private bool MoveNext()
					{
						int num = qmteRmZvteLPaIpdPxpggYmEtgqI;
						Elements xRjLkhzxImQTtIEeoZLonWsWuOZU = XRjLkhzxImQTtIEeoZLonWsWuOZU;
						switch (num)
						{
						default:
							return false;
						case 0:
							qmteRmZvteLPaIpdPxpggYmEtgqI = -1;
							if (xRjLkhzxImQTtIEeoZLonWsWuOZU.buttons == null)
							{
								return false;
							}
							JJqAlAakYfyklnRjQHfXmLyjGtMtA = 0;
							break;
						case 1:
							qmteRmZvteLPaIpdPxpggYmEtgqI = -1;
							JJqAlAakYfyklnRjQHfXmLyjGtMtA++;
							break;
						}
						if (JJqAlAakYfyklnRjQHfXmLyjGtMtA < xRjLkhzxImQTtIEeoZLonWsWuOZU.buttons.Length)
						{
							cGkDYhisAmzlzAoRAIPBKfKHUSrF = xRjLkhzxImQTtIEeoZLonWsWuOZU.buttons[JJqAlAakYfyklnRjQHfXmLyjGtMtA];
							qmteRmZvteLPaIpdPxpggYmEtgqI = 1;
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
						xuRlinIVatfWrlkKisOBhqciqXh xuRlinIVatfWrlkKisOBhqciqXh2;
						if (qmteRmZvteLPaIpdPxpggYmEtgqI == -2 && GhniEFgFFTRaQiPQkSgQtAcSdIwfA == Environment.CurrentManagedThreadId)
						{
							qmteRmZvteLPaIpdPxpggYmEtgqI = 0;
							xuRlinIVatfWrlkKisOBhqciqXh2 = this;
						}
						else
						{
							xuRlinIVatfWrlkKisOBhqciqXh2 = new xuRlinIVatfWrlkKisOBhqciqXh(0);
							xuRlinIVatfWrlkKisOBhqciqXh2.XRjLkhzxImQTtIEeoZLonWsWuOZU = XRjLkhzxImQTtIEeoZLonWsWuOZU;
						}
						return xuRlinIVatfWrlkKisOBhqciqXh2;
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
					[IteratorStateMachine(typeof(UclgFfLEPIkkaQDcGPMKoZAQwInW))]
					get
					{
						return new UclgFfLEPIkkaQDcGPMKoZAQwInW(-2)
						{
							TrbJMUVERfssmqDtxNCKocHKZmpp = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(xuRlinIVatfWrlkKisOBhqciqXh))]
					get
					{
						return new xuRlinIVatfWrlkKisOBhqciqXh(-2)
						{
							XRjLkhzxImQTtIEeoZLonWsWuOZU = this
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

			private sealed class ADBvlEgelKMECetnaqyhEnfEleLb : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int HwcbLzjIiwPPSjdSBeHfMuyGTWCUD;

				private Axis qvviyOrfFbNFqEyaVItlIaIksWpF;

				private int ymgeLNKKNJQqGEppAaKbvDfuGAAb;

				public Platform_WindowsUWP_Base ePaopcTJUbMSrcTlNQXYzlhdhNkt;

				private int NLSBPQHbToMAMxjzSFkHORmfDqQP;

				private int UzWaWHfbxFBYEAKrOPRMotoNYWmGA;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return qvviyOrfFbNFqEyaVItlIaIksWpF;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return qvviyOrfFbNFqEyaVItlIaIksWpF;
					}
				}

				[DebuggerHidden]
				public ADBvlEgelKMECetnaqyhEnfEleLb(int P_0)
				{
					HwcbLzjIiwPPSjdSBeHfMuyGTWCUD = P_0;
					ymgeLNKKNJQqGEppAaKbvDfuGAAb = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					HwcbLzjIiwPPSjdSBeHfMuyGTWCUD = -2;
				}

				private bool MoveNext()
				{
					int hwcbLzjIiwPPSjdSBeHfMuyGTWCUD = HwcbLzjIiwPPSjdSBeHfMuyGTWCUD;
					Platform_WindowsUWP_Base platform_WindowsUWP_Base = ePaopcTJUbMSrcTlNQXYzlhdhNkt;
					switch (hwcbLzjIiwPPSjdSBeHfMuyGTWCUD)
					{
					default:
						return false;
					case 0:
						HwcbLzjIiwPPSjdSBeHfMuyGTWCUD = -1;
						if (platform_WindowsUWP_Base.elements == null || platform_WindowsUWP_Base.elements.axes == null)
						{
							return false;
						}
						NLSBPQHbToMAMxjzSFkHORmfDqQP = platform_WindowsUWP_Base.elements.axes.Length;
						UzWaWHfbxFBYEAKrOPRMotoNYWmGA = 0;
						break;
					case 1:
						HwcbLzjIiwPPSjdSBeHfMuyGTWCUD = -1;
						UzWaWHfbxFBYEAKrOPRMotoNYWmGA++;
						break;
					}
					if (UzWaWHfbxFBYEAKrOPRMotoNYWmGA < NLSBPQHbToMAMxjzSFkHORmfDqQP)
					{
						qvviyOrfFbNFqEyaVItlIaIksWpF = platform_WindowsUWP_Base.elements.axes[UzWaWHfbxFBYEAKrOPRMotoNYWmGA];
						HwcbLzjIiwPPSjdSBeHfMuyGTWCUD = 1;
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
					ADBvlEgelKMECetnaqyhEnfEleLb aDBvlEgelKMECetnaqyhEnfEleLb;
					if (HwcbLzjIiwPPSjdSBeHfMuyGTWCUD == -2 && ymgeLNKKNJQqGEppAaKbvDfuGAAb == Environment.CurrentManagedThreadId)
					{
						HwcbLzjIiwPPSjdSBeHfMuyGTWCUD = 0;
						aDBvlEgelKMECetnaqyhEnfEleLb = this;
					}
					else
					{
						aDBvlEgelKMECetnaqyhEnfEleLb = new ADBvlEgelKMECetnaqyhEnfEleLb(0);
						aDBvlEgelKMECetnaqyhEnfEleLb.ePaopcTJUbMSrcTlNQXYzlhdhNkt = ePaopcTJUbMSrcTlNQXYzlhdhNkt;
					}
					return aDBvlEgelKMECetnaqyhEnfEleLb;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class AngkCNMGRcFlHIqKuMHJuqIUfDtpA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int ipueNIqkExLsmlHAiAgXXCDRrUjv;

				private Button IawGGrkMHgPIWhtrgZuZtaZHAWiI;

				private int UruApGnvJeHUlfCHluLRCaiBNisO;

				public Platform_WindowsUWP_Base jqMyDvgnMXhKSKhMVwFPmDzFYKrg;

				private int qWDsHmchouEwSMIIOAWpTTGoWgxH;

				private int YSozVohapjAzlmaMduOolXCGyNod;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return IawGGrkMHgPIWhtrgZuZtaZHAWiI;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return IawGGrkMHgPIWhtrgZuZtaZHAWiI;
					}
				}

				[DebuggerHidden]
				public AngkCNMGRcFlHIqKuMHJuqIUfDtpA(int P_0)
				{
					ipueNIqkExLsmlHAiAgXXCDRrUjv = P_0;
					UruApGnvJeHUlfCHluLRCaiBNisO = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					ipueNIqkExLsmlHAiAgXXCDRrUjv = -2;
				}

				private bool MoveNext()
				{
					int num = ipueNIqkExLsmlHAiAgXXCDRrUjv;
					Platform_WindowsUWP_Base platform_WindowsUWP_Base = jqMyDvgnMXhKSKhMVwFPmDzFYKrg;
					switch (num)
					{
					default:
						return false;
					case 0:
						ipueNIqkExLsmlHAiAgXXCDRrUjv = -1;
						if (platform_WindowsUWP_Base.elements == null || platform_WindowsUWP_Base.elements.buttons == null)
						{
							return false;
						}
						qWDsHmchouEwSMIIOAWpTTGoWgxH = platform_WindowsUWP_Base.elements.buttons.Length;
						YSozVohapjAzlmaMduOolXCGyNod = 0;
						break;
					case 1:
						ipueNIqkExLsmlHAiAgXXCDRrUjv = -1;
						YSozVohapjAzlmaMduOolXCGyNod++;
						break;
					}
					if (YSozVohapjAzlmaMduOolXCGyNod < qWDsHmchouEwSMIIOAWpTTGoWgxH)
					{
						IawGGrkMHgPIWhtrgZuZtaZHAWiI = platform_WindowsUWP_Base.elements.buttons[YSozVohapjAzlmaMduOolXCGyNod];
						ipueNIqkExLsmlHAiAgXXCDRrUjv = 1;
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
					AngkCNMGRcFlHIqKuMHJuqIUfDtpA angkCNMGRcFlHIqKuMHJuqIUfDtpA;
					if (ipueNIqkExLsmlHAiAgXXCDRrUjv == -2 && UruApGnvJeHUlfCHluLRCaiBNisO == Environment.CurrentManagedThreadId)
					{
						ipueNIqkExLsmlHAiAgXXCDRrUjv = 0;
						angkCNMGRcFlHIqKuMHJuqIUfDtpA = this;
					}
					else
					{
						angkCNMGRcFlHIqKuMHJuqIUfDtpA = new AngkCNMGRcFlHIqKuMHJuqIUfDtpA(0);
						angkCNMGRcFlHIqKuMHJuqIUfDtpA.jqMyDvgnMXhKSKhMVwFPmDzFYKrg = jqMyDvgnMXhKSKhMVwFPmDzFYKrg;
					}
					return angkCNMGRcFlHIqKuMHJuqIUfDtpA;
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
						if (axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = Axes_orig[i].calibrateAxis;
						}
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

			[IteratorStateMachine(typeof(ADBvlEgelKMECetnaqyhEnfEleLb))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new ADBvlEgelKMECetnaqyhEnfEleLb(-2)
				{
					ePaopcTJUbMSrcTlNQXYzlhdhNkt = this
				};
			}

			[IteratorStateMachine(typeof(AngkCNMGRcFlHIqKuMHJuqIUfDtpA))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new AngkCNMGRcFlHIqKuMHJuqIUfDtpA(-2)
				{
					jqMyDvgnMXhKSKhMVwFPmDzFYKrg = this
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

			private sealed class RlHKRfAcsmgBeHmHSJXJWJhOcAQc : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int jKsDpVynTsPNnZNxkJMDHhKavsOi;

				private Axis xsddecSjHoiowsOToUcfhjJtsOuU;

				private int zhHkFJYXlyJrMMfXRaPCKUEJHsciA;

				public Platform_Fallback_Base eDneuZzzPKTNqvcMoDxZvqUSMXnD;

				private int XuSLHtQYnbCIuppqiHkFHBJCNIho;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return xsddecSjHoiowsOToUcfhjJtsOuU;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return xsddecSjHoiowsOToUcfhjJtsOuU;
					}
				}

				[DebuggerHidden]
				public RlHKRfAcsmgBeHmHSJXJWJhOcAQc(int P_0)
				{
					jKsDpVynTsPNnZNxkJMDHhKavsOi = P_0;
					zhHkFJYXlyJrMMfXRaPCKUEJHsciA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					jKsDpVynTsPNnZNxkJMDHhKavsOi = -2;
				}

				private bool MoveNext()
				{
					int num = jKsDpVynTsPNnZNxkJMDHhKavsOi;
					Platform_Fallback_Base platform_Fallback_Base = eDneuZzzPKTNqvcMoDxZvqUSMXnD;
					switch (num)
					{
					default:
						return false;
					case 0:
						jKsDpVynTsPNnZNxkJMDHhKavsOi = -1;
						if (platform_Fallback_Base.elements == null || platform_Fallback_Base.elements.axes == null)
						{
							return false;
						}
						XuSLHtQYnbCIuppqiHkFHBJCNIho = 0;
						break;
					case 1:
						jKsDpVynTsPNnZNxkJMDHhKavsOi = -1;
						XuSLHtQYnbCIuppqiHkFHBJCNIho++;
						break;
					}
					if (XuSLHtQYnbCIuppqiHkFHBJCNIho < platform_Fallback_Base.elements.axes.Length)
					{
						xsddecSjHoiowsOToUcfhjJtsOuU = platform_Fallback_Base.elements.axes[XuSLHtQYnbCIuppqiHkFHBJCNIho];
						jKsDpVynTsPNnZNxkJMDHhKavsOi = 1;
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
					RlHKRfAcsmgBeHmHSJXJWJhOcAQc rlHKRfAcsmgBeHmHSJXJWJhOcAQc;
					if (jKsDpVynTsPNnZNxkJMDHhKavsOi == -2 && zhHkFJYXlyJrMMfXRaPCKUEJHsciA == Environment.CurrentManagedThreadId)
					{
						jKsDpVynTsPNnZNxkJMDHhKavsOi = 0;
						rlHKRfAcsmgBeHmHSJXJWJhOcAQc = this;
					}
					else
					{
						rlHKRfAcsmgBeHmHSJXJWJhOcAQc = new RlHKRfAcsmgBeHmHSJXJWJhOcAQc(0);
						rlHKRfAcsmgBeHmHSJXJWJhOcAQc.eDneuZzzPKTNqvcMoDxZvqUSMXnD = eDneuZzzPKTNqvcMoDxZvqUSMXnD;
					}
					return rlHKRfAcsmgBeHmHSJXJWJhOcAQc;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class xWrbJbiqrifFMelfjAwBBPxqUEBSA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int bLkWLyjesxXccnWJvVcTFerutfRI;

				private Button yCmqaOxDASvNEgDojyMxUioVnitt;

				private int HebdpYpTyqvLJVHSGFYRSUwfbWxiA;

				public Platform_Fallback_Base JtfoOhFTCJXaHmKZJkteeAmrOIZf;

				private int iDVCSEDsEIzUAnuziXLKFEOvIZIcA;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return yCmqaOxDASvNEgDojyMxUioVnitt;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return yCmqaOxDASvNEgDojyMxUioVnitt;
					}
				}

				[DebuggerHidden]
				public xWrbJbiqrifFMelfjAwBBPxqUEBSA(int P_0)
				{
					bLkWLyjesxXccnWJvVcTFerutfRI = P_0;
					HebdpYpTyqvLJVHSGFYRSUwfbWxiA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					bLkWLyjesxXccnWJvVcTFerutfRI = -2;
				}

				private bool MoveNext()
				{
					int num = bLkWLyjesxXccnWJvVcTFerutfRI;
					Platform_Fallback_Base jtfoOhFTCJXaHmKZJkteeAmrOIZf = JtfoOhFTCJXaHmKZJkteeAmrOIZf;
					switch (num)
					{
					default:
						return false;
					case 0:
						bLkWLyjesxXccnWJvVcTFerutfRI = -1;
						if (jtfoOhFTCJXaHmKZJkteeAmrOIZf.elements == null || jtfoOhFTCJXaHmKZJkteeAmrOIZf.elements.buttons == null)
						{
							return false;
						}
						iDVCSEDsEIzUAnuziXLKFEOvIZIcA = 0;
						break;
					case 1:
						bLkWLyjesxXccnWJvVcTFerutfRI = -1;
						iDVCSEDsEIzUAnuziXLKFEOvIZIcA++;
						break;
					}
					if (iDVCSEDsEIzUAnuziXLKFEOvIZIcA < jtfoOhFTCJXaHmKZJkteeAmrOIZf.elements.buttons.Length)
					{
						yCmqaOxDASvNEgDojyMxUioVnitt = jtfoOhFTCJXaHmKZJkteeAmrOIZf.elements.buttons[iDVCSEDsEIzUAnuziXLKFEOvIZIcA];
						bLkWLyjesxXccnWJvVcTFerutfRI = 1;
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
					xWrbJbiqrifFMelfjAwBBPxqUEBSA xWrbJbiqrifFMelfjAwBBPxqUEBSA2;
					if (bLkWLyjesxXccnWJvVcTFerutfRI == -2 && HebdpYpTyqvLJVHSGFYRSUwfbWxiA == Environment.CurrentManagedThreadId)
					{
						bLkWLyjesxXccnWJvVcTFerutfRI = 0;
						xWrbJbiqrifFMelfjAwBBPxqUEBSA2 = this;
					}
					else
					{
						xWrbJbiqrifFMelfjAwBBPxqUEBSA2 = new xWrbJbiqrifFMelfjAwBBPxqUEBSA(0);
						xWrbJbiqrifFMelfjAwBBPxqUEBSA2.JtfoOhFTCJXaHmKZJkteeAmrOIZf = JtfoOhFTCJXaHmKZJkteeAmrOIZf;
					}
					return xWrbJbiqrifFMelfjAwBBPxqUEBSA2;
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

			[IteratorStateMachine(typeof(RlHKRfAcsmgBeHmHSJXJWJhOcAQc))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new RlHKRfAcsmgBeHmHSJXJWJhOcAQc(-2)
				{
					eDneuZzzPKTNqvcMoDxZvqUSMXnD = this
				};
			}

			[IteratorStateMachine(typeof(xWrbJbiqrifFMelfjAwBBPxqUEBSA))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new xWrbJbiqrifFMelfjAwBBPxqUEBSA(-2)
				{
					JtfoOhFTCJXaHmKZJkteeAmrOIZf = this
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
						if (axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = Axes_orig[i].calibrateAxis;
						}
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

			private sealed class GfNbRMDWZGRPeqNSthioMEpEbCTO : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int ghPceNSTLDEihWNvKjQKNszAlrUn;

				private Platform_Custom.Axis ecUvbEzdlNrYLyNJuGSTEqFuRafq;

				private int dbbkmYktdxNeyfHbtCVmsWoecjeZ;

				public Platform_XboxOne_Base UrZVkHANcVhaojtACQeBzvxebHQjb;

				private int wGzyIBVlQOBXkEaukctMaFdlqXcbA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ecUvbEzdlNrYLyNJuGSTEqFuRafq;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ecUvbEzdlNrYLyNJuGSTEqFuRafq;
					}
				}

				[DebuggerHidden]
				public GfNbRMDWZGRPeqNSthioMEpEbCTO(int P_0)
				{
					ghPceNSTLDEihWNvKjQKNszAlrUn = P_0;
					dbbkmYktdxNeyfHbtCVmsWoecjeZ = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					ghPceNSTLDEihWNvKjQKNszAlrUn = -2;
				}

				private bool MoveNext()
				{
					int num = ghPceNSTLDEihWNvKjQKNszAlrUn;
					Platform_XboxOne_Base urZVkHANcVhaojtACQeBzvxebHQjb = UrZVkHANcVhaojtACQeBzvxebHQjb;
					switch (num)
					{
					default:
						return false;
					case 0:
						ghPceNSTLDEihWNvKjQKNszAlrUn = -1;
						if (urZVkHANcVhaojtACQeBzvxebHQjb.elements == null || urZVkHANcVhaojtACQeBzvxebHQjb.elements.axes == null)
						{
							return false;
						}
						wGzyIBVlQOBXkEaukctMaFdlqXcbA = 0;
						break;
					case 1:
						ghPceNSTLDEihWNvKjQKNszAlrUn = -1;
						wGzyIBVlQOBXkEaukctMaFdlqXcbA++;
						break;
					}
					if (wGzyIBVlQOBXkEaukctMaFdlqXcbA < urZVkHANcVhaojtACQeBzvxebHQjb.elements.axes.Length)
					{
						ecUvbEzdlNrYLyNJuGSTEqFuRafq = urZVkHANcVhaojtACQeBzvxebHQjb.elements.axes[wGzyIBVlQOBXkEaukctMaFdlqXcbA];
						ghPceNSTLDEihWNvKjQKNszAlrUn = 1;
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
					GfNbRMDWZGRPeqNSthioMEpEbCTO gfNbRMDWZGRPeqNSthioMEpEbCTO;
					if (ghPceNSTLDEihWNvKjQKNszAlrUn == -2 && dbbkmYktdxNeyfHbtCVmsWoecjeZ == Environment.CurrentManagedThreadId)
					{
						ghPceNSTLDEihWNvKjQKNszAlrUn = 0;
						gfNbRMDWZGRPeqNSthioMEpEbCTO = this;
					}
					else
					{
						gfNbRMDWZGRPeqNSthioMEpEbCTO = new GfNbRMDWZGRPeqNSthioMEpEbCTO(0);
						gfNbRMDWZGRPeqNSthioMEpEbCTO.UrZVkHANcVhaojtACQeBzvxebHQjb = UrZVkHANcVhaojtACQeBzvxebHQjb;
					}
					return gfNbRMDWZGRPeqNSthioMEpEbCTO;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class mUwtYjjWGwXitngWMrxYFGUlBZqS : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int ZuKmRsAhfXfAkesNIAumAXbbIpGV;

				private Platform_Custom.Button UWTsoVvELzZHZNxndJwDLRgeaqUW;

				private int PVSSaMkymNXYMobGfoCZuaFzRQoA;

				public Platform_XboxOne_Base nwJVHkacJpDlscXCxmIbsyBJUYhSA;

				private int tTxELwBTBIngaFaRFCXSpaADNqNq;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return UWTsoVvELzZHZNxndJwDLRgeaqUW;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return UWTsoVvELzZHZNxndJwDLRgeaqUW;
					}
				}

				[DebuggerHidden]
				public mUwtYjjWGwXitngWMrxYFGUlBZqS(int P_0)
				{
					ZuKmRsAhfXfAkesNIAumAXbbIpGV = P_0;
					PVSSaMkymNXYMobGfoCZuaFzRQoA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					ZuKmRsAhfXfAkesNIAumAXbbIpGV = -2;
				}

				private bool MoveNext()
				{
					int zuKmRsAhfXfAkesNIAumAXbbIpGV = ZuKmRsAhfXfAkesNIAumAXbbIpGV;
					Platform_XboxOne_Base platform_XboxOne_Base = nwJVHkacJpDlscXCxmIbsyBJUYhSA;
					switch (zuKmRsAhfXfAkesNIAumAXbbIpGV)
					{
					default:
						return false;
					case 0:
						ZuKmRsAhfXfAkesNIAumAXbbIpGV = -1;
						if (platform_XboxOne_Base.elements == null || platform_XboxOne_Base.elements.buttons == null)
						{
							return false;
						}
						tTxELwBTBIngaFaRFCXSpaADNqNq = 0;
						break;
					case 1:
						ZuKmRsAhfXfAkesNIAumAXbbIpGV = -1;
						tTxELwBTBIngaFaRFCXSpaADNqNq++;
						break;
					}
					if (tTxELwBTBIngaFaRFCXSpaADNqNq < platform_XboxOne_Base.elements.buttons.Length)
					{
						UWTsoVvELzZHZNxndJwDLRgeaqUW = platform_XboxOne_Base.elements.buttons[tTxELwBTBIngaFaRFCXSpaADNqNq];
						ZuKmRsAhfXfAkesNIAumAXbbIpGV = 1;
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
					mUwtYjjWGwXitngWMrxYFGUlBZqS mUwtYjjWGwXitngWMrxYFGUlBZqS2;
					if (ZuKmRsAhfXfAkesNIAumAXbbIpGV == -2 && PVSSaMkymNXYMobGfoCZuaFzRQoA == Environment.CurrentManagedThreadId)
					{
						ZuKmRsAhfXfAkesNIAumAXbbIpGV = 0;
						mUwtYjjWGwXitngWMrxYFGUlBZqS2 = this;
					}
					else
					{
						mUwtYjjWGwXitngWMrxYFGUlBZqS2 = new mUwtYjjWGwXitngWMrxYFGUlBZqS(0);
						mUwtYjjWGwXitngWMrxYFGUlBZqS2.nwJVHkacJpDlscXCxmIbsyBJUYhSA = nwJVHkacJpDlscXCxmIbsyBJUYhSA;
					}
					return mUwtYjjWGwXitngWMrxYFGUlBZqS2;
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

			[IteratorStateMachine(typeof(GfNbRMDWZGRPeqNSthioMEpEbCTO))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new GfNbRMDWZGRPeqNSthioMEpEbCTO(-2)
				{
					UrZVkHANcVhaojtACQeBzvxebHQjb = this
				};
			}

			[IteratorStateMachine(typeof(mUwtYjjWGwXitngWMrxYFGUlBZqS))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new mUwtYjjWGwXitngWMrxYFGUlBZqS(-2)
				{
					nwJVHkacJpDlscXCxmIbsyBJUYhSA = this
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
						if (axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = Axes_orig[i].calibrateAxis;
						}
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

			private sealed class QAsojGAFGoNYwrbesfquWdasGNCq : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int xgewbiIPzZzAYKhCFGOpAcqQlDVMA;

				private Platform_Custom.Axis rNNbPJJHytOsFDrYcSMpeKmsTaavA;

				private int gUlKBjJPxOwmKhxHgrLUexiHGMXU;

				public Platform_PS4_Base UmfBKbbYSGpKqNICrUrnHULsTGcJA;

				private int shUKeLqKKpaxCedefnzBNRZoQvzH;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return rNNbPJJHytOsFDrYcSMpeKmsTaavA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return rNNbPJJHytOsFDrYcSMpeKmsTaavA;
					}
				}

				[DebuggerHidden]
				public QAsojGAFGoNYwrbesfquWdasGNCq(int P_0)
				{
					xgewbiIPzZzAYKhCFGOpAcqQlDVMA = P_0;
					gUlKBjJPxOwmKhxHgrLUexiHGMXU = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					xgewbiIPzZzAYKhCFGOpAcqQlDVMA = -2;
				}

				private bool MoveNext()
				{
					int num = xgewbiIPzZzAYKhCFGOpAcqQlDVMA;
					Platform_PS4_Base umfBKbbYSGpKqNICrUrnHULsTGcJA = UmfBKbbYSGpKqNICrUrnHULsTGcJA;
					switch (num)
					{
					default:
						return false;
					case 0:
						xgewbiIPzZzAYKhCFGOpAcqQlDVMA = -1;
						if (umfBKbbYSGpKqNICrUrnHULsTGcJA.elements == null || umfBKbbYSGpKqNICrUrnHULsTGcJA.elements.axes == null)
						{
							return false;
						}
						shUKeLqKKpaxCedefnzBNRZoQvzH = 0;
						break;
					case 1:
						xgewbiIPzZzAYKhCFGOpAcqQlDVMA = -1;
						shUKeLqKKpaxCedefnzBNRZoQvzH++;
						break;
					}
					if (shUKeLqKKpaxCedefnzBNRZoQvzH < umfBKbbYSGpKqNICrUrnHULsTGcJA.elements.axes.Length)
					{
						rNNbPJJHytOsFDrYcSMpeKmsTaavA = umfBKbbYSGpKqNICrUrnHULsTGcJA.elements.axes[shUKeLqKKpaxCedefnzBNRZoQvzH];
						xgewbiIPzZzAYKhCFGOpAcqQlDVMA = 1;
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
					QAsojGAFGoNYwrbesfquWdasGNCq qAsojGAFGoNYwrbesfquWdasGNCq;
					if (xgewbiIPzZzAYKhCFGOpAcqQlDVMA == -2 && gUlKBjJPxOwmKhxHgrLUexiHGMXU == Environment.CurrentManagedThreadId)
					{
						xgewbiIPzZzAYKhCFGOpAcqQlDVMA = 0;
						qAsojGAFGoNYwrbesfquWdasGNCq = this;
					}
					else
					{
						qAsojGAFGoNYwrbesfquWdasGNCq = new QAsojGAFGoNYwrbesfquWdasGNCq(0);
						qAsojGAFGoNYwrbesfquWdasGNCq.UmfBKbbYSGpKqNICrUrnHULsTGcJA = UmfBKbbYSGpKqNICrUrnHULsTGcJA;
					}
					return qAsojGAFGoNYwrbesfquWdasGNCq;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class fJuGWEDfchJAOhHXUKXfzzBGcndHb : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int EoPoLtNcMjWKXVRGEYmsIzeOtBED;

				private Platform_Custom.Button BhBldbjSCAGtfrAuFgKykuUsKQdSA;

				private int VprGVztBMQzjliBhZrJUWNSkJSCl;

				public Platform_PS4_Base ElsVUbTOnLNxVeepiQwtwOUtwPuD;

				private int UKmqzkhlCerBkdzostjiPIxAtUvU;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return BhBldbjSCAGtfrAuFgKykuUsKQdSA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return BhBldbjSCAGtfrAuFgKykuUsKQdSA;
					}
				}

				[DebuggerHidden]
				public fJuGWEDfchJAOhHXUKXfzzBGcndHb(int P_0)
				{
					EoPoLtNcMjWKXVRGEYmsIzeOtBED = P_0;
					VprGVztBMQzjliBhZrJUWNSkJSCl = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					EoPoLtNcMjWKXVRGEYmsIzeOtBED = -2;
				}

				private bool MoveNext()
				{
					int eoPoLtNcMjWKXVRGEYmsIzeOtBED = EoPoLtNcMjWKXVRGEYmsIzeOtBED;
					Platform_PS4_Base elsVUbTOnLNxVeepiQwtwOUtwPuD = ElsVUbTOnLNxVeepiQwtwOUtwPuD;
					switch (eoPoLtNcMjWKXVRGEYmsIzeOtBED)
					{
					default:
						return false;
					case 0:
						EoPoLtNcMjWKXVRGEYmsIzeOtBED = -1;
						if (elsVUbTOnLNxVeepiQwtwOUtwPuD.elements == null || elsVUbTOnLNxVeepiQwtwOUtwPuD.elements.buttons == null)
						{
							return false;
						}
						UKmqzkhlCerBkdzostjiPIxAtUvU = 0;
						break;
					case 1:
						EoPoLtNcMjWKXVRGEYmsIzeOtBED = -1;
						UKmqzkhlCerBkdzostjiPIxAtUvU++;
						break;
					}
					if (UKmqzkhlCerBkdzostjiPIxAtUvU < elsVUbTOnLNxVeepiQwtwOUtwPuD.elements.buttons.Length)
					{
						BhBldbjSCAGtfrAuFgKykuUsKQdSA = elsVUbTOnLNxVeepiQwtwOUtwPuD.elements.buttons[UKmqzkhlCerBkdzostjiPIxAtUvU];
						EoPoLtNcMjWKXVRGEYmsIzeOtBED = 1;
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
					fJuGWEDfchJAOhHXUKXfzzBGcndHb fJuGWEDfchJAOhHXUKXfzzBGcndHb2;
					if (EoPoLtNcMjWKXVRGEYmsIzeOtBED == -2 && VprGVztBMQzjliBhZrJUWNSkJSCl == Environment.CurrentManagedThreadId)
					{
						EoPoLtNcMjWKXVRGEYmsIzeOtBED = 0;
						fJuGWEDfchJAOhHXUKXfzzBGcndHb2 = this;
					}
					else
					{
						fJuGWEDfchJAOhHXUKXfzzBGcndHb2 = new fJuGWEDfchJAOhHXUKXfzzBGcndHb(0);
						fJuGWEDfchJAOhHXUKXfzzBGcndHb2.ElsVUbTOnLNxVeepiQwtwOUtwPuD = ElsVUbTOnLNxVeepiQwtwOUtwPuD;
					}
					return fJuGWEDfchJAOhHXUKXfzzBGcndHb2;
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

			[IteratorStateMachine(typeof(QAsojGAFGoNYwrbesfquWdasGNCq))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new QAsojGAFGoNYwrbesfquWdasGNCq(-2)
				{
					UmfBKbbYSGpKqNICrUrnHULsTGcJA = this
				};
			}

			[IteratorStateMachine(typeof(fJuGWEDfchJAOhHXUKXfzzBGcndHb))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new fJuGWEDfchJAOhHXUKXfzzBGcndHb(-2)
				{
					ElsVUbTOnLNxVeepiQwtwOUtwPuD = this
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
						if (axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = Axes_orig[i].calibrateAxis;
						}
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

			private sealed class MMLSnUDydXcVPSAlxNPyiIfbkSmr : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int JIicFodhtDCsUwupDvWiOQPYACPW;

				private Platform_Custom.Axis nHfBUwEAPaDCArfBmAmeJHJlqZvm;

				private int faVTqMNNBpKFnFQnlmjpulZzNGjw;

				public Platform_NintendoSwitch_Base YsBNHyRIpKBSCACbZNXneFljRErLB;

				private int HVqcUKBbKbsTvcgumfSgAEIvtqhW;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return nHfBUwEAPaDCArfBmAmeJHJlqZvm;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return nHfBUwEAPaDCArfBmAmeJHJlqZvm;
					}
				}

				[DebuggerHidden]
				public MMLSnUDydXcVPSAlxNPyiIfbkSmr(int P_0)
				{
					JIicFodhtDCsUwupDvWiOQPYACPW = P_0;
					faVTqMNNBpKFnFQnlmjpulZzNGjw = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					JIicFodhtDCsUwupDvWiOQPYACPW = -2;
				}

				private bool MoveNext()
				{
					int jIicFodhtDCsUwupDvWiOQPYACPW = JIicFodhtDCsUwupDvWiOQPYACPW;
					Platform_NintendoSwitch_Base ysBNHyRIpKBSCACbZNXneFljRErLB = YsBNHyRIpKBSCACbZNXneFljRErLB;
					switch (jIicFodhtDCsUwupDvWiOQPYACPW)
					{
					default:
						return false;
					case 0:
						JIicFodhtDCsUwupDvWiOQPYACPW = -1;
						if (ysBNHyRIpKBSCACbZNXneFljRErLB.elements == null || ysBNHyRIpKBSCACbZNXneFljRErLB.elements.axes == null)
						{
							return false;
						}
						HVqcUKBbKbsTvcgumfSgAEIvtqhW = 0;
						break;
					case 1:
						JIicFodhtDCsUwupDvWiOQPYACPW = -1;
						HVqcUKBbKbsTvcgumfSgAEIvtqhW++;
						break;
					}
					if (HVqcUKBbKbsTvcgumfSgAEIvtqhW < ysBNHyRIpKBSCACbZNXneFljRErLB.elements.axes.Length)
					{
						nHfBUwEAPaDCArfBmAmeJHJlqZvm = ysBNHyRIpKBSCACbZNXneFljRErLB.elements.axes[HVqcUKBbKbsTvcgumfSgAEIvtqhW];
						JIicFodhtDCsUwupDvWiOQPYACPW = 1;
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
					MMLSnUDydXcVPSAlxNPyiIfbkSmr mMLSnUDydXcVPSAlxNPyiIfbkSmr;
					if (JIicFodhtDCsUwupDvWiOQPYACPW == -2 && faVTqMNNBpKFnFQnlmjpulZzNGjw == Environment.CurrentManagedThreadId)
					{
						JIicFodhtDCsUwupDvWiOQPYACPW = 0;
						mMLSnUDydXcVPSAlxNPyiIfbkSmr = this;
					}
					else
					{
						mMLSnUDydXcVPSAlxNPyiIfbkSmr = new MMLSnUDydXcVPSAlxNPyiIfbkSmr(0);
						mMLSnUDydXcVPSAlxNPyiIfbkSmr.YsBNHyRIpKBSCACbZNXneFljRErLB = YsBNHyRIpKBSCACbZNXneFljRErLB;
					}
					return mMLSnUDydXcVPSAlxNPyiIfbkSmr;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class HaXlvzlegzRhuDgvMlpfUlYdLvol : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int IqXMlPBAjNDFrpSIKmeuWLEJHypD;

				private Platform_Custom.Button XZBFYphrcOQgfypuqCrOJFftdlHZA;

				private int bPfLHyuHeDbTCaoeMPOyQMUXECkO;

				public Platform_NintendoSwitch_Base wCvuokwxLQgyVHJhbTBbbYhqGXaf;

				private int XnccVBTMYCwznmQJKSEquDgOcwrEA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return XZBFYphrcOQgfypuqCrOJFftdlHZA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return XZBFYphrcOQgfypuqCrOJFftdlHZA;
					}
				}

				[DebuggerHidden]
				public HaXlvzlegzRhuDgvMlpfUlYdLvol(int P_0)
				{
					IqXMlPBAjNDFrpSIKmeuWLEJHypD = P_0;
					bPfLHyuHeDbTCaoeMPOyQMUXECkO = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					IqXMlPBAjNDFrpSIKmeuWLEJHypD = -2;
				}

				private bool MoveNext()
				{
					int iqXMlPBAjNDFrpSIKmeuWLEJHypD = IqXMlPBAjNDFrpSIKmeuWLEJHypD;
					Platform_NintendoSwitch_Base platform_NintendoSwitch_Base = wCvuokwxLQgyVHJhbTBbbYhqGXaf;
					switch (iqXMlPBAjNDFrpSIKmeuWLEJHypD)
					{
					default:
						return false;
					case 0:
						IqXMlPBAjNDFrpSIKmeuWLEJHypD = -1;
						if (platform_NintendoSwitch_Base.elements == null || platform_NintendoSwitch_Base.elements.buttons == null)
						{
							return false;
						}
						XnccVBTMYCwznmQJKSEquDgOcwrEA = 0;
						break;
					case 1:
						IqXMlPBAjNDFrpSIKmeuWLEJHypD = -1;
						XnccVBTMYCwznmQJKSEquDgOcwrEA++;
						break;
					}
					if (XnccVBTMYCwznmQJKSEquDgOcwrEA < platform_NintendoSwitch_Base.elements.buttons.Length)
					{
						XZBFYphrcOQgfypuqCrOJFftdlHZA = platform_NintendoSwitch_Base.elements.buttons[XnccVBTMYCwznmQJKSEquDgOcwrEA];
						IqXMlPBAjNDFrpSIKmeuWLEJHypD = 1;
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
					HaXlvzlegzRhuDgvMlpfUlYdLvol haXlvzlegzRhuDgvMlpfUlYdLvol;
					if (IqXMlPBAjNDFrpSIKmeuWLEJHypD == -2 && bPfLHyuHeDbTCaoeMPOyQMUXECkO == Environment.CurrentManagedThreadId)
					{
						IqXMlPBAjNDFrpSIKmeuWLEJHypD = 0;
						haXlvzlegzRhuDgvMlpfUlYdLvol = this;
					}
					else
					{
						haXlvzlegzRhuDgvMlpfUlYdLvol = new HaXlvzlegzRhuDgvMlpfUlYdLvol(0);
						haXlvzlegzRhuDgvMlpfUlYdLvol.wCvuokwxLQgyVHJhbTBbbYhqGXaf = wCvuokwxLQgyVHJhbTBbbYhqGXaf;
					}
					return haXlvzlegzRhuDgvMlpfUlYdLvol;
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

			[IteratorStateMachine(typeof(MMLSnUDydXcVPSAlxNPyiIfbkSmr))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new MMLSnUDydXcVPSAlxNPyiIfbkSmr(-2)
				{
					YsBNHyRIpKBSCACbZNXneFljRErLB = this
				};
			}

			[IteratorStateMachine(typeof(HaXlvzlegzRhuDgvMlpfUlYdLvol))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new HaXlvzlegzRhuDgvMlpfUlYdLvol(-2)
				{
					wCvuokwxLQgyVHJhbTBbbYhqGXaf = this
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
						if (axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = Axes_orig[i].calibrateAxis;
						}
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
		public class Platform_NintendoSwitch : Platform_NintendoSwitch_Base
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
		public sealed class Platform_NintendoSwitch2 : Platform_NintendoSwitch
		{
			InputPlatform Platform_NintendoSwitch_Base.platform => InputPlatform.NintendoSwitch2;
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

			private sealed class yfWCpVXaTOmFQAfqwoyCnAZXgwNcA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int dgvytTkdBHrLjtYHOimRXeEchslO;

				private Platform_Custom.Axis igqcpmsLrpcZlevkJaOtNDkfjcyHb;

				private int ORGauhDfShfpvRemgglNEZKXUCDe;

				public Platform_GameCore_Base MnzRYcNuRFTcHtneINSmJYCbEVRo;

				private int zeXKYhctbbDNPrUgzsQUWhbJQxti;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return igqcpmsLrpcZlevkJaOtNDkfjcyHb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return igqcpmsLrpcZlevkJaOtNDkfjcyHb;
					}
				}

				[DebuggerHidden]
				public yfWCpVXaTOmFQAfqwoyCnAZXgwNcA(int P_0)
				{
					dgvytTkdBHrLjtYHOimRXeEchslO = P_0;
					ORGauhDfShfpvRemgglNEZKXUCDe = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					dgvytTkdBHrLjtYHOimRXeEchslO = -2;
				}

				private bool MoveNext()
				{
					int num = dgvytTkdBHrLjtYHOimRXeEchslO;
					Platform_GameCore_Base mnzRYcNuRFTcHtneINSmJYCbEVRo = MnzRYcNuRFTcHtneINSmJYCbEVRo;
					switch (num)
					{
					default:
						return false;
					case 0:
						dgvytTkdBHrLjtYHOimRXeEchslO = -1;
						if (mnzRYcNuRFTcHtneINSmJYCbEVRo.elements == null || mnzRYcNuRFTcHtneINSmJYCbEVRo.elements.axes == null)
						{
							return false;
						}
						zeXKYhctbbDNPrUgzsQUWhbJQxti = 0;
						break;
					case 1:
						dgvytTkdBHrLjtYHOimRXeEchslO = -1;
						zeXKYhctbbDNPrUgzsQUWhbJQxti++;
						break;
					}
					if (zeXKYhctbbDNPrUgzsQUWhbJQxti < mnzRYcNuRFTcHtneINSmJYCbEVRo.elements.axes.Length)
					{
						igqcpmsLrpcZlevkJaOtNDkfjcyHb = mnzRYcNuRFTcHtneINSmJYCbEVRo.elements.axes[zeXKYhctbbDNPrUgzsQUWhbJQxti];
						dgvytTkdBHrLjtYHOimRXeEchslO = 1;
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
					yfWCpVXaTOmFQAfqwoyCnAZXgwNcA yfWCpVXaTOmFQAfqwoyCnAZXgwNcA2;
					if (dgvytTkdBHrLjtYHOimRXeEchslO == -2 && ORGauhDfShfpvRemgglNEZKXUCDe == Environment.CurrentManagedThreadId)
					{
						dgvytTkdBHrLjtYHOimRXeEchslO = 0;
						yfWCpVXaTOmFQAfqwoyCnAZXgwNcA2 = this;
					}
					else
					{
						yfWCpVXaTOmFQAfqwoyCnAZXgwNcA2 = new yfWCpVXaTOmFQAfqwoyCnAZXgwNcA(0);
						yfWCpVXaTOmFQAfqwoyCnAZXgwNcA2.MnzRYcNuRFTcHtneINSmJYCbEVRo = MnzRYcNuRFTcHtneINSmJYCbEVRo;
					}
					return yfWCpVXaTOmFQAfqwoyCnAZXgwNcA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class BrgalMvmRcToYPofbcgViIqnfxRjA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int MFQgIBdHmtQwHldHokVzUARSiysgb;

				private Platform_Custom.Button QTpHSSIMnItrasCfcJqhfARWFFPO;

				private int lhOzKtGkdyCPttUGWxYPvpYvgzyD;

				public Platform_GameCore_Base ZcjmLJhQamBUbVkDAGeyvmqzvWHj;

				private int hJLVxnMWrzikczwjCEjXcAtPjcPe;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return QTpHSSIMnItrasCfcJqhfARWFFPO;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return QTpHSSIMnItrasCfcJqhfARWFFPO;
					}
				}

				[DebuggerHidden]
				public BrgalMvmRcToYPofbcgViIqnfxRjA(int P_0)
				{
					MFQgIBdHmtQwHldHokVzUARSiysgb = P_0;
					lhOzKtGkdyCPttUGWxYPvpYvgzyD = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					MFQgIBdHmtQwHldHokVzUARSiysgb = -2;
				}

				private bool MoveNext()
				{
					int mFQgIBdHmtQwHldHokVzUARSiysgb = MFQgIBdHmtQwHldHokVzUARSiysgb;
					Platform_GameCore_Base zcjmLJhQamBUbVkDAGeyvmqzvWHj = ZcjmLJhQamBUbVkDAGeyvmqzvWHj;
					switch (mFQgIBdHmtQwHldHokVzUARSiysgb)
					{
					default:
						return false;
					case 0:
						MFQgIBdHmtQwHldHokVzUARSiysgb = -1;
						if (zcjmLJhQamBUbVkDAGeyvmqzvWHj.elements == null || zcjmLJhQamBUbVkDAGeyvmqzvWHj.elements.buttons == null)
						{
							return false;
						}
						hJLVxnMWrzikczwjCEjXcAtPjcPe = 0;
						break;
					case 1:
						MFQgIBdHmtQwHldHokVzUARSiysgb = -1;
						hJLVxnMWrzikczwjCEjXcAtPjcPe++;
						break;
					}
					if (hJLVxnMWrzikczwjCEjXcAtPjcPe < zcjmLJhQamBUbVkDAGeyvmqzvWHj.elements.buttons.Length)
					{
						QTpHSSIMnItrasCfcJqhfARWFFPO = zcjmLJhQamBUbVkDAGeyvmqzvWHj.elements.buttons[hJLVxnMWrzikczwjCEjXcAtPjcPe];
						MFQgIBdHmtQwHldHokVzUARSiysgb = 1;
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
					BrgalMvmRcToYPofbcgViIqnfxRjA brgalMvmRcToYPofbcgViIqnfxRjA;
					if (MFQgIBdHmtQwHldHokVzUARSiysgb == -2 && lhOzKtGkdyCPttUGWxYPvpYvgzyD == Environment.CurrentManagedThreadId)
					{
						MFQgIBdHmtQwHldHokVzUARSiysgb = 0;
						brgalMvmRcToYPofbcgViIqnfxRjA = this;
					}
					else
					{
						brgalMvmRcToYPofbcgViIqnfxRjA = new BrgalMvmRcToYPofbcgViIqnfxRjA(0);
						brgalMvmRcToYPofbcgViIqnfxRjA.ZcjmLJhQamBUbVkDAGeyvmqzvWHj = ZcjmLJhQamBUbVkDAGeyvmqzvWHj;
					}
					return brgalMvmRcToYPofbcgViIqnfxRjA;
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

			[IteratorStateMachine(typeof(yfWCpVXaTOmFQAfqwoyCnAZXgwNcA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new yfWCpVXaTOmFQAfqwoyCnAZXgwNcA(-2)
				{
					MnzRYcNuRFTcHtneINSmJYCbEVRo = this
				};
			}

			[IteratorStateMachine(typeof(BrgalMvmRcToYPofbcgViIqnfxRjA))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new BrgalMvmRcToYPofbcgViIqnfxRjA(-2)
				{
					ZcjmLJhQamBUbVkDAGeyvmqzvWHj = this
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
						if (axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = Axes_orig[i].calibrateAxis;
						}
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

			private sealed class bhVpkbAnHSJYjgAvhLAgPGmZZyVb : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int SwouJmTNRZexifTerCqfQexiTvreA;

				private Platform_Custom.Axis saIkzZUNtKmkbIyEuKpGyeSKmNhm;

				private int QepxgZlmqOTfEidpLcZsfeIRKjOCA;

				public Platform_PS5_Base uzClCvLTQIGcWKDxBOrsbbgbBaJu;

				private int NVTArWhOMaeQkrqwBsEBrFDHAbHC;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return saIkzZUNtKmkbIyEuKpGyeSKmNhm;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return saIkzZUNtKmkbIyEuKpGyeSKmNhm;
					}
				}

				[DebuggerHidden]
				public bhVpkbAnHSJYjgAvhLAgPGmZZyVb(int P_0)
				{
					SwouJmTNRZexifTerCqfQexiTvreA = P_0;
					QepxgZlmqOTfEidpLcZsfeIRKjOCA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					SwouJmTNRZexifTerCqfQexiTvreA = -2;
				}

				private bool MoveNext()
				{
					int swouJmTNRZexifTerCqfQexiTvreA = SwouJmTNRZexifTerCqfQexiTvreA;
					Platform_PS5_Base platform_PS5_Base = uzClCvLTQIGcWKDxBOrsbbgbBaJu;
					switch (swouJmTNRZexifTerCqfQexiTvreA)
					{
					default:
						return false;
					case 0:
						SwouJmTNRZexifTerCqfQexiTvreA = -1;
						if (platform_PS5_Base.elements == null || platform_PS5_Base.elements.axes == null)
						{
							return false;
						}
						NVTArWhOMaeQkrqwBsEBrFDHAbHC = 0;
						break;
					case 1:
						SwouJmTNRZexifTerCqfQexiTvreA = -1;
						NVTArWhOMaeQkrqwBsEBrFDHAbHC++;
						break;
					}
					if (NVTArWhOMaeQkrqwBsEBrFDHAbHC < platform_PS5_Base.elements.axes.Length)
					{
						saIkzZUNtKmkbIyEuKpGyeSKmNhm = platform_PS5_Base.elements.axes[NVTArWhOMaeQkrqwBsEBrFDHAbHC];
						SwouJmTNRZexifTerCqfQexiTvreA = 1;
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
					bhVpkbAnHSJYjgAvhLAgPGmZZyVb bhVpkbAnHSJYjgAvhLAgPGmZZyVb2;
					if (SwouJmTNRZexifTerCqfQexiTvreA == -2 && QepxgZlmqOTfEidpLcZsfeIRKjOCA == Environment.CurrentManagedThreadId)
					{
						SwouJmTNRZexifTerCqfQexiTvreA = 0;
						bhVpkbAnHSJYjgAvhLAgPGmZZyVb2 = this;
					}
					else
					{
						bhVpkbAnHSJYjgAvhLAgPGmZZyVb2 = new bhVpkbAnHSJYjgAvhLAgPGmZZyVb(0);
						bhVpkbAnHSJYjgAvhLAgPGmZZyVb2.uzClCvLTQIGcWKDxBOrsbbgbBaJu = uzClCvLTQIGcWKDxBOrsbbgbBaJu;
					}
					return bhVpkbAnHSJYjgAvhLAgPGmZZyVb2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class KdShgESgmAYhbMGJNCstIZNeYjpM : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int zstgzTfKiPFKtyVUJSRUBQmyLTYEA;

				private Platform_Custom.Button uuaFknglKNkFMvvInvWjRRAtNjEN;

				private int nUPElcJhDAcPbhkcHYstuRHIyIIT;

				public Platform_PS5_Base UlQgsgAerUWakARHPawLfygTzpDbA;

				private int xBOwZNmagyAmRjgymmfZsGPtCYEXA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return uuaFknglKNkFMvvInvWjRRAtNjEN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return uuaFknglKNkFMvvInvWjRRAtNjEN;
					}
				}

				[DebuggerHidden]
				public KdShgESgmAYhbMGJNCstIZNeYjpM(int P_0)
				{
					zstgzTfKiPFKtyVUJSRUBQmyLTYEA = P_0;
					nUPElcJhDAcPbhkcHYstuRHIyIIT = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					zstgzTfKiPFKtyVUJSRUBQmyLTYEA = -2;
				}

				private bool MoveNext()
				{
					int num = zstgzTfKiPFKtyVUJSRUBQmyLTYEA;
					Platform_PS5_Base ulQgsgAerUWakARHPawLfygTzpDbA = UlQgsgAerUWakARHPawLfygTzpDbA;
					switch (num)
					{
					default:
						return false;
					case 0:
						zstgzTfKiPFKtyVUJSRUBQmyLTYEA = -1;
						if (ulQgsgAerUWakARHPawLfygTzpDbA.elements == null || ulQgsgAerUWakARHPawLfygTzpDbA.elements.buttons == null)
						{
							return false;
						}
						xBOwZNmagyAmRjgymmfZsGPtCYEXA = 0;
						break;
					case 1:
						zstgzTfKiPFKtyVUJSRUBQmyLTYEA = -1;
						xBOwZNmagyAmRjgymmfZsGPtCYEXA++;
						break;
					}
					if (xBOwZNmagyAmRjgymmfZsGPtCYEXA < ulQgsgAerUWakARHPawLfygTzpDbA.elements.buttons.Length)
					{
						uuaFknglKNkFMvvInvWjRRAtNjEN = ulQgsgAerUWakARHPawLfygTzpDbA.elements.buttons[xBOwZNmagyAmRjgymmfZsGPtCYEXA];
						zstgzTfKiPFKtyVUJSRUBQmyLTYEA = 1;
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
					KdShgESgmAYhbMGJNCstIZNeYjpM kdShgESgmAYhbMGJNCstIZNeYjpM;
					if (zstgzTfKiPFKtyVUJSRUBQmyLTYEA == -2 && nUPElcJhDAcPbhkcHYstuRHIyIIT == Environment.CurrentManagedThreadId)
					{
						zstgzTfKiPFKtyVUJSRUBQmyLTYEA = 0;
						kdShgESgmAYhbMGJNCstIZNeYjpM = this;
					}
					else
					{
						kdShgESgmAYhbMGJNCstIZNeYjpM = new KdShgESgmAYhbMGJNCstIZNeYjpM(0);
						kdShgESgmAYhbMGJNCstIZNeYjpM.UlQgsgAerUWakARHPawLfygTzpDbA = UlQgsgAerUWakARHPawLfygTzpDbA;
					}
					return kdShgESgmAYhbMGJNCstIZNeYjpM;
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

			[IteratorStateMachine(typeof(bhVpkbAnHSJYjgAvhLAgPGmZZyVb))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new bhVpkbAnHSJYjgAvhLAgPGmZZyVb(-2)
				{
					uzClCvLTQIGcWKDxBOrsbbgbBaJu = this
				};
			}

			[IteratorStateMachine(typeof(KdShgESgmAYhbMGJNCstIZNeYjpM))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new KdShgESgmAYhbMGJNCstIZNeYjpM(-2)
				{
					UlQgsgAerUWakARHPawLfygTzpDbA = this
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
						if (axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = Axes_orig[i].calibrateAxis;
						}
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

			private sealed class ZFAeYNwRDeymohuvIRRJlXWfJGtM : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int ECtYCOAKzYJKWooGudfxecXlBxeYA;

				private Platform_Custom.Axis aRtciywiWoHNVHwDCQTdfdVrzSmD;

				private int DgKICIeILJEnKehivrXXcbPBaQeF;

				public Platform_InternalDriver_Base mapcXrmhlJZOzIkMUIhLNREKXDQe;

				private int rEunsNATFjEucjWJHPUJwbUtRiFH;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return aRtciywiWoHNVHwDCQTdfdVrzSmD;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return aRtciywiWoHNVHwDCQTdfdVrzSmD;
					}
				}

				[DebuggerHidden]
				public ZFAeYNwRDeymohuvIRRJlXWfJGtM(int P_0)
				{
					ECtYCOAKzYJKWooGudfxecXlBxeYA = P_0;
					DgKICIeILJEnKehivrXXcbPBaQeF = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					ECtYCOAKzYJKWooGudfxecXlBxeYA = -2;
				}

				private bool MoveNext()
				{
					int eCtYCOAKzYJKWooGudfxecXlBxeYA = ECtYCOAKzYJKWooGudfxecXlBxeYA;
					Platform_InternalDriver_Base platform_InternalDriver_Base = mapcXrmhlJZOzIkMUIhLNREKXDQe;
					switch (eCtYCOAKzYJKWooGudfxecXlBxeYA)
					{
					default:
						return false;
					case 0:
						ECtYCOAKzYJKWooGudfxecXlBxeYA = -1;
						if (platform_InternalDriver_Base.elements == null || platform_InternalDriver_Base.elements.axes == null)
						{
							return false;
						}
						rEunsNATFjEucjWJHPUJwbUtRiFH = 0;
						break;
					case 1:
						ECtYCOAKzYJKWooGudfxecXlBxeYA = -1;
						rEunsNATFjEucjWJHPUJwbUtRiFH++;
						break;
					}
					if (rEunsNATFjEucjWJHPUJwbUtRiFH < platform_InternalDriver_Base.elements.axes.Length)
					{
						aRtciywiWoHNVHwDCQTdfdVrzSmD = platform_InternalDriver_Base.elements.axes[rEunsNATFjEucjWJHPUJwbUtRiFH];
						ECtYCOAKzYJKWooGudfxecXlBxeYA = 1;
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
					ZFAeYNwRDeymohuvIRRJlXWfJGtM zFAeYNwRDeymohuvIRRJlXWfJGtM;
					if (ECtYCOAKzYJKWooGudfxecXlBxeYA == -2 && DgKICIeILJEnKehivrXXcbPBaQeF == Environment.CurrentManagedThreadId)
					{
						ECtYCOAKzYJKWooGudfxecXlBxeYA = 0;
						zFAeYNwRDeymohuvIRRJlXWfJGtM = this;
					}
					else
					{
						zFAeYNwRDeymohuvIRRJlXWfJGtM = new ZFAeYNwRDeymohuvIRRJlXWfJGtM(0);
						zFAeYNwRDeymohuvIRRJlXWfJGtM.mapcXrmhlJZOzIkMUIhLNREKXDQe = mapcXrmhlJZOzIkMUIhLNREKXDQe;
					}
					return zFAeYNwRDeymohuvIRRJlXWfJGtM;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class LGbtTNMZXktMQwbWaVRGOYsHFXNf : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int HOZRxJyrHcqADihnwnbQGJcygDeCA;

				private Platform_Custom.Button TSdNFHfNbWCdTmrXepkCEbtNymeL;

				private int jaOXMLvLhmpXRGgqYHmDLdrhIhHC;

				public Platform_InternalDriver_Base ZWSzraccpBPIXfqlcwkqJTgaJULN;

				private int pNogykMqtXkvQEdsoAOvjnHHpkHZ;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return TSdNFHfNbWCdTmrXepkCEbtNymeL;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return TSdNFHfNbWCdTmrXepkCEbtNymeL;
					}
				}

				[DebuggerHidden]
				public LGbtTNMZXktMQwbWaVRGOYsHFXNf(int P_0)
				{
					HOZRxJyrHcqADihnwnbQGJcygDeCA = P_0;
					jaOXMLvLhmpXRGgqYHmDLdrhIhHC = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					HOZRxJyrHcqADihnwnbQGJcygDeCA = -2;
				}

				private bool MoveNext()
				{
					int hOZRxJyrHcqADihnwnbQGJcygDeCA = HOZRxJyrHcqADihnwnbQGJcygDeCA;
					Platform_InternalDriver_Base zWSzraccpBPIXfqlcwkqJTgaJULN = ZWSzraccpBPIXfqlcwkqJTgaJULN;
					switch (hOZRxJyrHcqADihnwnbQGJcygDeCA)
					{
					default:
						return false;
					case 0:
						HOZRxJyrHcqADihnwnbQGJcygDeCA = -1;
						if (zWSzraccpBPIXfqlcwkqJTgaJULN.elements == null || zWSzraccpBPIXfqlcwkqJTgaJULN.elements.buttons == null)
						{
							return false;
						}
						pNogykMqtXkvQEdsoAOvjnHHpkHZ = 0;
						break;
					case 1:
						HOZRxJyrHcqADihnwnbQGJcygDeCA = -1;
						pNogykMqtXkvQEdsoAOvjnHHpkHZ++;
						break;
					}
					if (pNogykMqtXkvQEdsoAOvjnHHpkHZ < zWSzraccpBPIXfqlcwkqJTgaJULN.elements.buttons.Length)
					{
						TSdNFHfNbWCdTmrXepkCEbtNymeL = zWSzraccpBPIXfqlcwkqJTgaJULN.elements.buttons[pNogykMqtXkvQEdsoAOvjnHHpkHZ];
						HOZRxJyrHcqADihnwnbQGJcygDeCA = 1;
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
					LGbtTNMZXktMQwbWaVRGOYsHFXNf lGbtTNMZXktMQwbWaVRGOYsHFXNf;
					if (HOZRxJyrHcqADihnwnbQGJcygDeCA == -2 && jaOXMLvLhmpXRGgqYHmDLdrhIhHC == Environment.CurrentManagedThreadId)
					{
						HOZRxJyrHcqADihnwnbQGJcygDeCA = 0;
						lGbtTNMZXktMQwbWaVRGOYsHFXNf = this;
					}
					else
					{
						lGbtTNMZXktMQwbWaVRGOYsHFXNf = new LGbtTNMZXktMQwbWaVRGOYsHFXNf(0);
						lGbtTNMZXktMQwbWaVRGOYsHFXNf.ZWSzraccpBPIXfqlcwkqJTgaJULN = ZWSzraccpBPIXfqlcwkqJTgaJULN;
					}
					return lGbtTNMZXktMQwbWaVRGOYsHFXNf;
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

			[IteratorStateMachine(typeof(ZFAeYNwRDeymohuvIRRJlXWfJGtM))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new ZFAeYNwRDeymohuvIRRJlXWfJGtM(-2)
				{
					mapcXrmhlJZOzIkMUIhLNREKXDQe = this
				};
			}

			[IteratorStateMachine(typeof(LGbtTNMZXktMQwbWaVRGOYsHFXNf))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new LGbtTNMZXktMQwbWaVRGOYsHFXNf(-2)
				{
					ZWSzraccpBPIXfqlcwkqJTgaJULN = this
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
						if (axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = Axes_orig[i].calibrateAxis;
						}
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
						ajTmuZrfJgNWFabMneWjcfeLLiVW(elementCount);
						return elementCount;
					}

					internal void JMIFCyUFbydjLhSOcsXTAvMWloWDb(ElementCount_Base P_0)
					{
						base.ajTmuZrfJgNWFabMneWjcfeLLiVW(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool GJzAUSORDuTYLSeOIYmTWTIPSUuF(BridgedControllerHWInfo P_0)
					{
						if (!base.ZRIzpYvxiqqesJvpPGVJiNbpPZlD(P_0))
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
				private sealed class EkBnQHoouxMFcDmJxRXNCdTibBaFA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int mKnXIWLHsFBsPHaqNAJDiuFGugmWB;

					private Axis VqucpbylxGerOMhxKEGCcgewUbCw;

					private int IaaQamFfGkGZbDUbJNyJjBthYoGs;

					public Elements mAcDiEkzlHHqLlpaZzzzshwODPabA;

					private int BhNZADWgGUeYqBJjVPRrXyYHCnkYA;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return VqucpbylxGerOMhxKEGCcgewUbCw;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return VqucpbylxGerOMhxKEGCcgewUbCw;
						}
					}

					[DebuggerHidden]
					public EkBnQHoouxMFcDmJxRXNCdTibBaFA(int P_0)
					{
						mKnXIWLHsFBsPHaqNAJDiuFGugmWB = P_0;
						IaaQamFfGkGZbDUbJNyJjBthYoGs = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						mKnXIWLHsFBsPHaqNAJDiuFGugmWB = -2;
					}

					private bool MoveNext()
					{
						int num = mKnXIWLHsFBsPHaqNAJDiuFGugmWB;
						Elements elements = mAcDiEkzlHHqLlpaZzzzshwODPabA;
						switch (num)
						{
						default:
							return false;
						case 0:
							mKnXIWLHsFBsPHaqNAJDiuFGugmWB = -1;
							if (elements.axes == null)
							{
								return false;
							}
							BhNZADWgGUeYqBJjVPRrXyYHCnkYA = 0;
							break;
						case 1:
							mKnXIWLHsFBsPHaqNAJDiuFGugmWB = -1;
							BhNZADWgGUeYqBJjVPRrXyYHCnkYA++;
							break;
						}
						if (BhNZADWgGUeYqBJjVPRrXyYHCnkYA < elements.axes.Length)
						{
							VqucpbylxGerOMhxKEGCcgewUbCw = elements.axes[BhNZADWgGUeYqBJjVPRrXyYHCnkYA];
							mKnXIWLHsFBsPHaqNAJDiuFGugmWB = 1;
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
						EkBnQHoouxMFcDmJxRXNCdTibBaFA ekBnQHoouxMFcDmJxRXNCdTibBaFA;
						if (mKnXIWLHsFBsPHaqNAJDiuFGugmWB == -2 && IaaQamFfGkGZbDUbJNyJjBthYoGs == Environment.CurrentManagedThreadId)
						{
							mKnXIWLHsFBsPHaqNAJDiuFGugmWB = 0;
							ekBnQHoouxMFcDmJxRXNCdTibBaFA = this;
						}
						else
						{
							ekBnQHoouxMFcDmJxRXNCdTibBaFA = new EkBnQHoouxMFcDmJxRXNCdTibBaFA(0);
							ekBnQHoouxMFcDmJxRXNCdTibBaFA.mAcDiEkzlHHqLlpaZzzzshwODPabA = mAcDiEkzlHHqLlpaZzzzshwODPabA;
						}
						return ekBnQHoouxMFcDmJxRXNCdTibBaFA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class StJtEzDOrSYTimFOTGtraPPrNkdEb : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int adAiayzlmfzGzutiuhmgJDZcDbYH;

					private Button vWCgPcdIgNiYwGKyxxnQvtKadZTv;

					private int fOecQSFTYUHKKbVyXhZZZyOAyjfP;

					public Elements DBLwibwwioFJTyKrqAehmvInpKBW;

					private int msYFtrHHYQazNYlWatFkDmJILUdTA;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return vWCgPcdIgNiYwGKyxxnQvtKadZTv;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vWCgPcdIgNiYwGKyxxnQvtKadZTv;
						}
					}

					[DebuggerHidden]
					public StJtEzDOrSYTimFOTGtraPPrNkdEb(int P_0)
					{
						adAiayzlmfzGzutiuhmgJDZcDbYH = P_0;
						fOecQSFTYUHKKbVyXhZZZyOAyjfP = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						adAiayzlmfzGzutiuhmgJDZcDbYH = -2;
					}

					private bool MoveNext()
					{
						int num = adAiayzlmfzGzutiuhmgJDZcDbYH;
						Elements dBLwibwwioFJTyKrqAehmvInpKBW = DBLwibwwioFJTyKrqAehmvInpKBW;
						switch (num)
						{
						default:
							return false;
						case 0:
							adAiayzlmfzGzutiuhmgJDZcDbYH = -1;
							if (dBLwibwwioFJTyKrqAehmvInpKBW.buttons == null)
							{
								return false;
							}
							msYFtrHHYQazNYlWatFkDmJILUdTA = 0;
							break;
						case 1:
							adAiayzlmfzGzutiuhmgJDZcDbYH = -1;
							msYFtrHHYQazNYlWatFkDmJILUdTA++;
							break;
						}
						if (msYFtrHHYQazNYlWatFkDmJILUdTA < dBLwibwwioFJTyKrqAehmvInpKBW.buttons.Length)
						{
							vWCgPcdIgNiYwGKyxxnQvtKadZTv = dBLwibwwioFJTyKrqAehmvInpKBW.buttons[msYFtrHHYQazNYlWatFkDmJILUdTA];
							adAiayzlmfzGzutiuhmgJDZcDbYH = 1;
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
						StJtEzDOrSYTimFOTGtraPPrNkdEb stJtEzDOrSYTimFOTGtraPPrNkdEb;
						if (adAiayzlmfzGzutiuhmgJDZcDbYH == -2 && fOecQSFTYUHKKbVyXhZZZyOAyjfP == Environment.CurrentManagedThreadId)
						{
							adAiayzlmfzGzutiuhmgJDZcDbYH = 0;
							stJtEzDOrSYTimFOTGtraPPrNkdEb = this;
						}
						else
						{
							stJtEzDOrSYTimFOTGtraPPrNkdEb = new StJtEzDOrSYTimFOTGtraPPrNkdEb(0);
							stJtEzDOrSYTimFOTGtraPPrNkdEb.DBLwibwwioFJTyKrqAehmvInpKBW = DBLwibwwioFJTyKrqAehmvInpKBW;
						}
						return stJtEzDOrSYTimFOTGtraPPrNkdEb;
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
					[IteratorStateMachine(typeof(EkBnQHoouxMFcDmJxRXNCdTibBaFA))]
					get
					{
						return new EkBnQHoouxMFcDmJxRXNCdTibBaFA(-2)
						{
							mAcDiEkzlHHqLlpaZzzzshwODPabA = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(StJtEzDOrSYTimFOTGtraPPrNkdEb))]
					get
					{
						return new StJtEzDOrSYTimFOTGtraPPrNkdEb(-2)
						{
							DBLwibwwioFJTyKrqAehmvInpKBW = this
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

			private sealed class KhTDkFLSTeSwSxITxYDPEdMxbsUt : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int CvsCByPxUYxuxoaxFCjMYCHcKxhf;

				private Axis VpKEQRfZjFKdMEgQnFoZWPMnWmgw;

				private int LBXcpyCiKOhdSuyDldRdmVeXdOefA;

				public Platform_SDL2_Base nwFfZFAwjKxCPwafUmYrUoXKRsBS;

				private int dCyCIDaDVBdinIwWhtItLeoVHSrkA;

				private int JHuvgRFlwYDdXefojCVQCFXgVNQG;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return VpKEQRfZjFKdMEgQnFoZWPMnWmgw;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return VpKEQRfZjFKdMEgQnFoZWPMnWmgw;
					}
				}

				[DebuggerHidden]
				public KhTDkFLSTeSwSxITxYDPEdMxbsUt(int P_0)
				{
					CvsCByPxUYxuxoaxFCjMYCHcKxhf = P_0;
					LBXcpyCiKOhdSuyDldRdmVeXdOefA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					CvsCByPxUYxuxoaxFCjMYCHcKxhf = -2;
				}

				private bool MoveNext()
				{
					int cvsCByPxUYxuxoaxFCjMYCHcKxhf = CvsCByPxUYxuxoaxFCjMYCHcKxhf;
					Platform_SDL2_Base platform_SDL2_Base = nwFfZFAwjKxCPwafUmYrUoXKRsBS;
					switch (cvsCByPxUYxuxoaxFCjMYCHcKxhf)
					{
					default:
						return false;
					case 0:
						CvsCByPxUYxuxoaxFCjMYCHcKxhf = -1;
						if (platform_SDL2_Base.elements == null || platform_SDL2_Base.elements.axes == null)
						{
							return false;
						}
						dCyCIDaDVBdinIwWhtItLeoVHSrkA = platform_SDL2_Base.elements.axes.Length;
						JHuvgRFlwYDdXefojCVQCFXgVNQG = 0;
						break;
					case 1:
						CvsCByPxUYxuxoaxFCjMYCHcKxhf = -1;
						JHuvgRFlwYDdXefojCVQCFXgVNQG++;
						break;
					}
					if (JHuvgRFlwYDdXefojCVQCFXgVNQG < dCyCIDaDVBdinIwWhtItLeoVHSrkA)
					{
						VpKEQRfZjFKdMEgQnFoZWPMnWmgw = platform_SDL2_Base.elements.axes[JHuvgRFlwYDdXefojCVQCFXgVNQG];
						CvsCByPxUYxuxoaxFCjMYCHcKxhf = 1;
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
					KhTDkFLSTeSwSxITxYDPEdMxbsUt khTDkFLSTeSwSxITxYDPEdMxbsUt;
					if (CvsCByPxUYxuxoaxFCjMYCHcKxhf == -2 && LBXcpyCiKOhdSuyDldRdmVeXdOefA == Environment.CurrentManagedThreadId)
					{
						CvsCByPxUYxuxoaxFCjMYCHcKxhf = 0;
						khTDkFLSTeSwSxITxYDPEdMxbsUt = this;
					}
					else
					{
						khTDkFLSTeSwSxITxYDPEdMxbsUt = new KhTDkFLSTeSwSxITxYDPEdMxbsUt(0);
						khTDkFLSTeSwSxITxYDPEdMxbsUt.nwFfZFAwjKxCPwafUmYrUoXKRsBS = nwFfZFAwjKxCPwafUmYrUoXKRsBS;
					}
					return khTDkFLSTeSwSxITxYDPEdMxbsUt;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class xKfPcEOLMGMjwJbETlCVOvtiGdJp : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int PxnULqpmUbGljktHWsgAPCDmyIdfA;

				private Button MVpXoyrxJSSbLcFEqSZXtwPNuibi;

				private int OpvCBkAGqoAjjnyDkdJjeVljidvOA;

				public Platform_SDL2_Base uwwsyuBWEDPJhXppxyzoMMePEfke;

				private int szSeqOyaItOWHhRnyymAVlHhyFjb;

				private int phaKvLONMdoYwHpXunUpGMhzBoXK;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return MVpXoyrxJSSbLcFEqSZXtwPNuibi;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return MVpXoyrxJSSbLcFEqSZXtwPNuibi;
					}
				}

				[DebuggerHidden]
				public xKfPcEOLMGMjwJbETlCVOvtiGdJp(int P_0)
				{
					PxnULqpmUbGljktHWsgAPCDmyIdfA = P_0;
					OpvCBkAGqoAjjnyDkdJjeVljidvOA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					PxnULqpmUbGljktHWsgAPCDmyIdfA = -2;
				}

				private bool MoveNext()
				{
					int pxnULqpmUbGljktHWsgAPCDmyIdfA = PxnULqpmUbGljktHWsgAPCDmyIdfA;
					Platform_SDL2_Base platform_SDL2_Base = uwwsyuBWEDPJhXppxyzoMMePEfke;
					switch (pxnULqpmUbGljktHWsgAPCDmyIdfA)
					{
					default:
						return false;
					case 0:
						PxnULqpmUbGljktHWsgAPCDmyIdfA = -1;
						if (platform_SDL2_Base.elements == null || platform_SDL2_Base.elements.buttons == null)
						{
							return false;
						}
						szSeqOyaItOWHhRnyymAVlHhyFjb = platform_SDL2_Base.elements.buttons.Length;
						phaKvLONMdoYwHpXunUpGMhzBoXK = 0;
						break;
					case 1:
						PxnULqpmUbGljktHWsgAPCDmyIdfA = -1;
						phaKvLONMdoYwHpXunUpGMhzBoXK++;
						break;
					}
					if (phaKvLONMdoYwHpXunUpGMhzBoXK < szSeqOyaItOWHhRnyymAVlHhyFjb)
					{
						MVpXoyrxJSSbLcFEqSZXtwPNuibi = platform_SDL2_Base.elements.buttons[phaKvLONMdoYwHpXunUpGMhzBoXK];
						PxnULqpmUbGljktHWsgAPCDmyIdfA = 1;
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
					xKfPcEOLMGMjwJbETlCVOvtiGdJp xKfPcEOLMGMjwJbETlCVOvtiGdJp2;
					if (PxnULqpmUbGljktHWsgAPCDmyIdfA == -2 && OpvCBkAGqoAjjnyDkdJjeVljidvOA == Environment.CurrentManagedThreadId)
					{
						PxnULqpmUbGljktHWsgAPCDmyIdfA = 0;
						xKfPcEOLMGMjwJbETlCVOvtiGdJp2 = this;
					}
					else
					{
						xKfPcEOLMGMjwJbETlCVOvtiGdJp2 = new xKfPcEOLMGMjwJbETlCVOvtiGdJp(0);
						xKfPcEOLMGMjwJbETlCVOvtiGdJp2.uwwsyuBWEDPJhXppxyzoMMePEfke = uwwsyuBWEDPJhXppxyzoMMePEfke;
					}
					return xKfPcEOLMGMjwJbETlCVOvtiGdJp2;
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
						if (axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = Axes_orig[i].calibrateAxis;
						}
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

			[IteratorStateMachine(typeof(KhTDkFLSTeSwSxITxYDPEdMxbsUt))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new KhTDkFLSTeSwSxITxYDPEdMxbsUt(-2)
				{
					nwFfZFAwjKxCPwafUmYrUoXKRsBS = this
				};
			}

			[IteratorStateMachine(typeof(xKfPcEOLMGMjwJbETlCVOvtiGdJp))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new xKfPcEOLMGMjwJbETlCVOvtiGdJp(-2)
				{
					uwwsyuBWEDPJhXppxyzoMMePEfke = this
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

			private sealed class BKlFBowxsyjMdFRKiGeJUymQBROs : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int puzEVNfgJUniUDUbCeEZqwqePJDjd;

				private Platform_Custom.Axis DMiTeoyBVqEtDGMXVHooqAGYroIVA;

				private int UVoiCDiCCNcCkINNDowRrDoTNfQs;

				public Platform_WebGL_Base LmNrerojlMKUFqPbpqBQPskemRES;

				private int HxvNiztgznSUQklhMXsWUWKVccHM;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return DMiTeoyBVqEtDGMXVHooqAGYroIVA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return DMiTeoyBVqEtDGMXVHooqAGYroIVA;
					}
				}

				[DebuggerHidden]
				public BKlFBowxsyjMdFRKiGeJUymQBROs(int P_0)
				{
					puzEVNfgJUniUDUbCeEZqwqePJDjd = P_0;
					UVoiCDiCCNcCkINNDowRrDoTNfQs = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					puzEVNfgJUniUDUbCeEZqwqePJDjd = -2;
				}

				private bool MoveNext()
				{
					int num = puzEVNfgJUniUDUbCeEZqwqePJDjd;
					Platform_WebGL_Base lmNrerojlMKUFqPbpqBQPskemRES = LmNrerojlMKUFqPbpqBQPskemRES;
					switch (num)
					{
					default:
						return false;
					case 0:
						puzEVNfgJUniUDUbCeEZqwqePJDjd = -1;
						if (lmNrerojlMKUFqPbpqBQPskemRES.elements == null || lmNrerojlMKUFqPbpqBQPskemRES.elements.axes == null)
						{
							return false;
						}
						HxvNiztgznSUQklhMXsWUWKVccHM = 0;
						break;
					case 1:
						puzEVNfgJUniUDUbCeEZqwqePJDjd = -1;
						HxvNiztgznSUQklhMXsWUWKVccHM++;
						break;
					}
					if (HxvNiztgznSUQklhMXsWUWKVccHM < lmNrerojlMKUFqPbpqBQPskemRES.elements.axes.Length)
					{
						DMiTeoyBVqEtDGMXVHooqAGYroIVA = lmNrerojlMKUFqPbpqBQPskemRES.elements.axes[HxvNiztgznSUQklhMXsWUWKVccHM];
						puzEVNfgJUniUDUbCeEZqwqePJDjd = 1;
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
					BKlFBowxsyjMdFRKiGeJUymQBROs bKlFBowxsyjMdFRKiGeJUymQBROs;
					if (puzEVNfgJUniUDUbCeEZqwqePJDjd == -2 && UVoiCDiCCNcCkINNDowRrDoTNfQs == Environment.CurrentManagedThreadId)
					{
						puzEVNfgJUniUDUbCeEZqwqePJDjd = 0;
						bKlFBowxsyjMdFRKiGeJUymQBROs = this;
					}
					else
					{
						bKlFBowxsyjMdFRKiGeJUymQBROs = new BKlFBowxsyjMdFRKiGeJUymQBROs(0);
						bKlFBowxsyjMdFRKiGeJUymQBROs.LmNrerojlMKUFqPbpqBQPskemRES = LmNrerojlMKUFqPbpqBQPskemRES;
					}
					return bKlFBowxsyjMdFRKiGeJUymQBROs;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class yjmZvcjsCIvLddqiJIDuKiWbntvkA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int pAkvJfvHyqddFJJzmhTTaZZbjlgUB;

				private Platform_Custom.Button vamEQTZLjiAZedcSVbORbALEhnaVA;

				private int owWDBexEustCFMYSLrClatkOGeXd;

				public Platform_WebGL_Base MyafShJMOieVnPKczNNgJQrRcjIz;

				private int ShwLZfTDmWHJzuqDXFJuJeIUcgsvA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vamEQTZLjiAZedcSVbORbALEhnaVA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vamEQTZLjiAZedcSVbORbALEhnaVA;
					}
				}

				[DebuggerHidden]
				public yjmZvcjsCIvLddqiJIDuKiWbntvkA(int P_0)
				{
					pAkvJfvHyqddFJJzmhTTaZZbjlgUB = P_0;
					owWDBexEustCFMYSLrClatkOGeXd = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					pAkvJfvHyqddFJJzmhTTaZZbjlgUB = -2;
				}

				private bool MoveNext()
				{
					int num = pAkvJfvHyqddFJJzmhTTaZZbjlgUB;
					Platform_WebGL_Base myafShJMOieVnPKczNNgJQrRcjIz = MyafShJMOieVnPKczNNgJQrRcjIz;
					switch (num)
					{
					default:
						return false;
					case 0:
						pAkvJfvHyqddFJJzmhTTaZZbjlgUB = -1;
						if (myafShJMOieVnPKczNNgJQrRcjIz.elements == null || myafShJMOieVnPKczNNgJQrRcjIz.elements.buttons == null)
						{
							return false;
						}
						ShwLZfTDmWHJzuqDXFJuJeIUcgsvA = 0;
						break;
					case 1:
						pAkvJfvHyqddFJJzmhTTaZZbjlgUB = -1;
						ShwLZfTDmWHJzuqDXFJuJeIUcgsvA++;
						break;
					}
					if (ShwLZfTDmWHJzuqDXFJuJeIUcgsvA < myafShJMOieVnPKczNNgJQrRcjIz.elements.buttons.Length)
					{
						vamEQTZLjiAZedcSVbORbALEhnaVA = myafShJMOieVnPKczNNgJQrRcjIz.elements.buttons[ShwLZfTDmWHJzuqDXFJuJeIUcgsvA];
						pAkvJfvHyqddFJJzmhTTaZZbjlgUB = 1;
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
					yjmZvcjsCIvLddqiJIDuKiWbntvkA yjmZvcjsCIvLddqiJIDuKiWbntvkA2;
					if (pAkvJfvHyqddFJJzmhTTaZZbjlgUB == -2 && owWDBexEustCFMYSLrClatkOGeXd == Environment.CurrentManagedThreadId)
					{
						pAkvJfvHyqddFJJzmhTTaZZbjlgUB = 0;
						yjmZvcjsCIvLddqiJIDuKiWbntvkA2 = this;
					}
					else
					{
						yjmZvcjsCIvLddqiJIDuKiWbntvkA2 = new yjmZvcjsCIvLddqiJIDuKiWbntvkA(0);
						yjmZvcjsCIvLddqiJIDuKiWbntvkA2.MyafShJMOieVnPKczNNgJQrRcjIz = MyafShJMOieVnPKczNNgJQrRcjIz;
					}
					return yjmZvcjsCIvLddqiJIDuKiWbntvkA2;
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

			[IteratorStateMachine(typeof(BKlFBowxsyjMdFRKiGeJUymQBROs))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new BKlFBowxsyjMdFRKiGeJUymQBROs(-2)
				{
					LmNrerojlMKUFqPbpqBQPskemRES = this
				};
			}

			[IteratorStateMachine(typeof(yjmZvcjsCIvLddqiJIDuKiWbntvkA))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new yjmZvcjsCIvLddqiJIDuKiWbntvkA(-2)
				{
					MyafShJMOieVnPKczNNgJQrRcjIz = this
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
						if (axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = Axes_orig[i].calibrateAxis;
						}
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

			private sealed class HTABKlDEctiZMWUSceXFiiHPvIjq : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int qmqAFAityWgLeLYyyVUpNdwzxIGQA;

				private Platform_Custom.Axis AJQQOAPRojgjrJKFwEraLpTfjcvkA;

				private int GIZzUsXMsfHbFxLOExzmujkFgyeo;

				public Platform_AppleGCController_Base selkcmsdfmZiWvAUiUzoDBKxDTldA;

				private int kMLPIoPSNOGDmRDzSPmWmgNmBtib;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return AJQQOAPRojgjrJKFwEraLpTfjcvkA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return AJQQOAPRojgjrJKFwEraLpTfjcvkA;
					}
				}

				[DebuggerHidden]
				public HTABKlDEctiZMWUSceXFiiHPvIjq(int P_0)
				{
					qmqAFAityWgLeLYyyVUpNdwzxIGQA = P_0;
					GIZzUsXMsfHbFxLOExzmujkFgyeo = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					qmqAFAityWgLeLYyyVUpNdwzxIGQA = -2;
				}

				private bool MoveNext()
				{
					int num = qmqAFAityWgLeLYyyVUpNdwzxIGQA;
					Platform_AppleGCController_Base platform_AppleGCController_Base = selkcmsdfmZiWvAUiUzoDBKxDTldA;
					switch (num)
					{
					default:
						return false;
					case 0:
						qmqAFAityWgLeLYyyVUpNdwzxIGQA = -1;
						if (platform_AppleGCController_Base.elements == null || platform_AppleGCController_Base.elements.axes == null)
						{
							return false;
						}
						kMLPIoPSNOGDmRDzSPmWmgNmBtib = 0;
						break;
					case 1:
						qmqAFAityWgLeLYyyVUpNdwzxIGQA = -1;
						kMLPIoPSNOGDmRDzSPmWmgNmBtib++;
						break;
					}
					if (kMLPIoPSNOGDmRDzSPmWmgNmBtib < platform_AppleGCController_Base.elements.axes.Length)
					{
						AJQQOAPRojgjrJKFwEraLpTfjcvkA = platform_AppleGCController_Base.elements.axes[kMLPIoPSNOGDmRDzSPmWmgNmBtib];
						qmqAFAityWgLeLYyyVUpNdwzxIGQA = 1;
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
					HTABKlDEctiZMWUSceXFiiHPvIjq hTABKlDEctiZMWUSceXFiiHPvIjq;
					if (qmqAFAityWgLeLYyyVUpNdwzxIGQA == -2 && GIZzUsXMsfHbFxLOExzmujkFgyeo == Environment.CurrentManagedThreadId)
					{
						qmqAFAityWgLeLYyyVUpNdwzxIGQA = 0;
						hTABKlDEctiZMWUSceXFiiHPvIjq = this;
					}
					else
					{
						hTABKlDEctiZMWUSceXFiiHPvIjq = new HTABKlDEctiZMWUSceXFiiHPvIjq(0);
						hTABKlDEctiZMWUSceXFiiHPvIjq.selkcmsdfmZiWvAUiUzoDBKxDTldA = selkcmsdfmZiWvAUiUzoDBKxDTldA;
					}
					return hTABKlDEctiZMWUSceXFiiHPvIjq;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class CAeBPGVdoLEXamIaMDSswwhpPEfq : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int TBBxJmFTALewHyRiYPLwnVfABrmb;

				private Platform_Custom.Button ystocMmOdszZdaSgZJPsTFUbufTA;

				private int VKXtFRscFcVeEBOigteXCXlsvtCM;

				public Platform_AppleGCController_Base zgmkfJTggkfDswefVeGQPZCiWFgr;

				private int RyAvneyvjDoxpUFAnCDZwqFmmxeH;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ystocMmOdszZdaSgZJPsTFUbufTA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ystocMmOdszZdaSgZJPsTFUbufTA;
					}
				}

				[DebuggerHidden]
				public CAeBPGVdoLEXamIaMDSswwhpPEfq(int P_0)
				{
					TBBxJmFTALewHyRiYPLwnVfABrmb = P_0;
					VKXtFRscFcVeEBOigteXCXlsvtCM = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					TBBxJmFTALewHyRiYPLwnVfABrmb = -2;
				}

				private bool MoveNext()
				{
					int tBBxJmFTALewHyRiYPLwnVfABrmb = TBBxJmFTALewHyRiYPLwnVfABrmb;
					Platform_AppleGCController_Base platform_AppleGCController_Base = zgmkfJTggkfDswefVeGQPZCiWFgr;
					switch (tBBxJmFTALewHyRiYPLwnVfABrmb)
					{
					default:
						return false;
					case 0:
						TBBxJmFTALewHyRiYPLwnVfABrmb = -1;
						if (platform_AppleGCController_Base.elements == null || platform_AppleGCController_Base.elements.buttons == null)
						{
							return false;
						}
						RyAvneyvjDoxpUFAnCDZwqFmmxeH = 0;
						break;
					case 1:
						TBBxJmFTALewHyRiYPLwnVfABrmb = -1;
						RyAvneyvjDoxpUFAnCDZwqFmmxeH++;
						break;
					}
					if (RyAvneyvjDoxpUFAnCDZwqFmmxeH < platform_AppleGCController_Base.elements.buttons.Length)
					{
						ystocMmOdszZdaSgZJPsTFUbufTA = platform_AppleGCController_Base.elements.buttons[RyAvneyvjDoxpUFAnCDZwqFmmxeH];
						TBBxJmFTALewHyRiYPLwnVfABrmb = 1;
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
					CAeBPGVdoLEXamIaMDSswwhpPEfq cAeBPGVdoLEXamIaMDSswwhpPEfq;
					if (TBBxJmFTALewHyRiYPLwnVfABrmb == -2 && VKXtFRscFcVeEBOigteXCXlsvtCM == Environment.CurrentManagedThreadId)
					{
						TBBxJmFTALewHyRiYPLwnVfABrmb = 0;
						cAeBPGVdoLEXamIaMDSswwhpPEfq = this;
					}
					else
					{
						cAeBPGVdoLEXamIaMDSswwhpPEfq = new CAeBPGVdoLEXamIaMDSswwhpPEfq(0);
						cAeBPGVdoLEXamIaMDSswwhpPEfq.zgmkfJTggkfDswefVeGQPZCiWFgr = zgmkfJTggkfDswefVeGQPZCiWFgr;
					}
					return cAeBPGVdoLEXamIaMDSswwhpPEfq;
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

			[IteratorStateMachine(typeof(HTABKlDEctiZMWUSceXFiiHPvIjq))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new HTABKlDEctiZMWUSceXFiiHPvIjq(-2)
				{
					selkcmsdfmZiWvAUiUzoDBKxDTldA = this
				};
			}

			[IteratorStateMachine(typeof(CAeBPGVdoLEXamIaMDSswwhpPEfq))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new CAeBPGVdoLEXamIaMDSswwhpPEfq(-2)
				{
					zgmkfJTggkfDswefVeGQPZCiWFgr = this
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
						if (axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = Axes_orig[i].calibrateAxis;
						}
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

			private sealed class XYgQLNErSXtaVPxYTvcRmiAuhtjd : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int NBJjwqXCfWFouvvmnjTdHgquscgt;

				private Platform_Custom.Axis RlhtmrtOSwKqXzXkanibKAfmcKQg;

				private int TMYGAjCMWwlgzlisZMsNDRubIpmGA;

				public Platform_WindowsWGI_Base EUGenGprisHWKAiFbRvaVeeWJdfW;

				private int cPcGNJtKqMiwyFfCKLmgpttgJPKy;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return RlhtmrtOSwKqXzXkanibKAfmcKQg;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return RlhtmrtOSwKqXzXkanibKAfmcKQg;
					}
				}

				[DebuggerHidden]
				public XYgQLNErSXtaVPxYTvcRmiAuhtjd(int P_0)
				{
					NBJjwqXCfWFouvvmnjTdHgquscgt = P_0;
					TMYGAjCMWwlgzlisZMsNDRubIpmGA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					NBJjwqXCfWFouvvmnjTdHgquscgt = -2;
				}

				private bool MoveNext()
				{
					int nBJjwqXCfWFouvvmnjTdHgquscgt = NBJjwqXCfWFouvvmnjTdHgquscgt;
					Platform_WindowsWGI_Base eUGenGprisHWKAiFbRvaVeeWJdfW = EUGenGprisHWKAiFbRvaVeeWJdfW;
					switch (nBJjwqXCfWFouvvmnjTdHgquscgt)
					{
					default:
						return false;
					case 0:
						NBJjwqXCfWFouvvmnjTdHgquscgt = -1;
						if (eUGenGprisHWKAiFbRvaVeeWJdfW.elements == null || eUGenGprisHWKAiFbRvaVeeWJdfW.elements.axes == null)
						{
							return false;
						}
						cPcGNJtKqMiwyFfCKLmgpttgJPKy = 0;
						break;
					case 1:
						NBJjwqXCfWFouvvmnjTdHgquscgt = -1;
						cPcGNJtKqMiwyFfCKLmgpttgJPKy++;
						break;
					}
					if (cPcGNJtKqMiwyFfCKLmgpttgJPKy < eUGenGprisHWKAiFbRvaVeeWJdfW.elements.axes.Length)
					{
						RlhtmrtOSwKqXzXkanibKAfmcKQg = eUGenGprisHWKAiFbRvaVeeWJdfW.elements.axes[cPcGNJtKqMiwyFfCKLmgpttgJPKy];
						NBJjwqXCfWFouvvmnjTdHgquscgt = 1;
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
					XYgQLNErSXtaVPxYTvcRmiAuhtjd xYgQLNErSXtaVPxYTvcRmiAuhtjd;
					if (NBJjwqXCfWFouvvmnjTdHgquscgt == -2 && TMYGAjCMWwlgzlisZMsNDRubIpmGA == Environment.CurrentManagedThreadId)
					{
						NBJjwqXCfWFouvvmnjTdHgquscgt = 0;
						xYgQLNErSXtaVPxYTvcRmiAuhtjd = this;
					}
					else
					{
						xYgQLNErSXtaVPxYTvcRmiAuhtjd = new XYgQLNErSXtaVPxYTvcRmiAuhtjd(0);
						xYgQLNErSXtaVPxYTvcRmiAuhtjd.EUGenGprisHWKAiFbRvaVeeWJdfW = EUGenGprisHWKAiFbRvaVeeWJdfW;
					}
					return xYgQLNErSXtaVPxYTvcRmiAuhtjd;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class JhgfREGHznukHfEtGhCRlxPpuaiY : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int hchfxAxjJcEnOgwVGVSEEHzrBHvCb;

				private Platform_Custom.Button ctUETttyKzOSoxocGHhVkYfPwlwhA;

				private int xUCNvoDYhZsnyaXDVHZMhPJdUJaI;

				public Platform_WindowsWGI_Base TmUufHNvcovczuJbapqyWslnDZPg;

				private int oZHGrBablmfrqIDfBmDRnOKsDIoT;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ctUETttyKzOSoxocGHhVkYfPwlwhA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ctUETttyKzOSoxocGHhVkYfPwlwhA;
					}
				}

				[DebuggerHidden]
				public JhgfREGHznukHfEtGhCRlxPpuaiY(int P_0)
				{
					hchfxAxjJcEnOgwVGVSEEHzrBHvCb = P_0;
					xUCNvoDYhZsnyaXDVHZMhPJdUJaI = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					hchfxAxjJcEnOgwVGVSEEHzrBHvCb = -2;
				}

				private bool MoveNext()
				{
					int num = hchfxAxjJcEnOgwVGVSEEHzrBHvCb;
					Platform_WindowsWGI_Base tmUufHNvcovczuJbapqyWslnDZPg = TmUufHNvcovczuJbapqyWslnDZPg;
					switch (num)
					{
					default:
						return false;
					case 0:
						hchfxAxjJcEnOgwVGVSEEHzrBHvCb = -1;
						if (tmUufHNvcovczuJbapqyWslnDZPg.elements == null || tmUufHNvcovczuJbapqyWslnDZPg.elements.buttons == null)
						{
							return false;
						}
						oZHGrBablmfrqIDfBmDRnOKsDIoT = 0;
						break;
					case 1:
						hchfxAxjJcEnOgwVGVSEEHzrBHvCb = -1;
						oZHGrBablmfrqIDfBmDRnOKsDIoT++;
						break;
					}
					if (oZHGrBablmfrqIDfBmDRnOKsDIoT < tmUufHNvcovczuJbapqyWslnDZPg.elements.buttons.Length)
					{
						ctUETttyKzOSoxocGHhVkYfPwlwhA = tmUufHNvcovczuJbapqyWslnDZPg.elements.buttons[oZHGrBablmfrqIDfBmDRnOKsDIoT];
						hchfxAxjJcEnOgwVGVSEEHzrBHvCb = 1;
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
					JhgfREGHznukHfEtGhCRlxPpuaiY jhgfREGHznukHfEtGhCRlxPpuaiY;
					if (hchfxAxjJcEnOgwVGVSEEHzrBHvCb == -2 && xUCNvoDYhZsnyaXDVHZMhPJdUJaI == Environment.CurrentManagedThreadId)
					{
						hchfxAxjJcEnOgwVGVSEEHzrBHvCb = 0;
						jhgfREGHznukHfEtGhCRlxPpuaiY = this;
					}
					else
					{
						jhgfREGHznukHfEtGhCRlxPpuaiY = new JhgfREGHznukHfEtGhCRlxPpuaiY(0);
						jhgfREGHznukHfEtGhCRlxPpuaiY.TmUufHNvcovczuJbapqyWslnDZPg = TmUufHNvcovczuJbapqyWslnDZPg;
					}
					return jhgfREGHznukHfEtGhCRlxPpuaiY;
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

			[IteratorStateMachine(typeof(XYgQLNErSXtaVPxYTvcRmiAuhtjd))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new XYgQLNErSXtaVPxYTvcRmiAuhtjd(-2)
				{
					EUGenGprisHWKAiFbRvaVeeWJdfW = this
				};
			}

			[IteratorStateMachine(typeof(JhgfREGHznukHfEtGhCRlxPpuaiY))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new JhgfREGHznukHfEtGhCRlxPpuaiY(-2)
				{
					TmUufHNvcovczuJbapqyWslnDZPg = this
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
						if (axes_orig[i].axisInfo.dataFormat == AxisCoordinateMode.Relative)
						{
							array[i].applyRangeCalibration = Axes_orig[i].calibrateAxis;
						}
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

		private sealed class ImBwnakLRxtzyAvzcluGELybqUyx : IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerable, IEnumerator<IControllerElementIdentifierCommon_Internal>, IEnumerator, IDisposable
		{
			private int fPpgzctJDSXBbbBukTJOAciAsKtP;

			private IControllerElementIdentifierCommon_Internal xbGGpLTBCIVeIKSYYochIsjgxpNX;

			private int tcfXyyytLjiEoooeCpwhbTLNiSgu;

			public HardwareJoystickMap WrWPKvzmwdwKrmCrKaZqddtIzIkeA;

			private int gEKPuKjQIuFKYClMGajZgWfOKIfj;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
			{
				[DebuggerHidden]
				get
				{
					return xbGGpLTBCIVeIKSYYochIsjgxpNX;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return xbGGpLTBCIVeIKSYYochIsjgxpNX;
				}
			}

			[DebuggerHidden]
			public ImBwnakLRxtzyAvzcluGELybqUyx(int P_0)
			{
				fPpgzctJDSXBbbBukTJOAciAsKtP = P_0;
				tcfXyyytLjiEoooeCpwhbTLNiSgu = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				fPpgzctJDSXBbbBukTJOAciAsKtP = -2;
			}

			private bool MoveNext()
			{
				int num = fPpgzctJDSXBbbBukTJOAciAsKtP;
				HardwareJoystickMap wrWPKvzmwdwKrmCrKaZqddtIzIkeA = WrWPKvzmwdwKrmCrKaZqddtIzIkeA;
				switch (num)
				{
				default:
					return false;
				case 0:
					fPpgzctJDSXBbbBukTJOAciAsKtP = -1;
					if (wrWPKvzmwdwKrmCrKaZqddtIzIkeA.elementIdentifiers == null)
					{
						return false;
					}
					gEKPuKjQIuFKYClMGajZgWfOKIfj = 0;
					break;
				case 1:
					fPpgzctJDSXBbbBukTJOAciAsKtP = -1;
					gEKPuKjQIuFKYClMGajZgWfOKIfj++;
					break;
				}
				if (gEKPuKjQIuFKYClMGajZgWfOKIfj < wrWPKvzmwdwKrmCrKaZqddtIzIkeA.elementIdentifiers.Length)
				{
					xbGGpLTBCIVeIKSYYochIsjgxpNX = wrWPKvzmwdwKrmCrKaZqddtIzIkeA.elementIdentifiers[gEKPuKjQIuFKYClMGajZgWfOKIfj];
					fPpgzctJDSXBbbBukTJOAciAsKtP = 1;
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
				ImBwnakLRxtzyAvzcluGELybqUyx imBwnakLRxtzyAvzcluGELybqUyx;
				if (fPpgzctJDSXBbbBukTJOAciAsKtP == -2 && tcfXyyytLjiEoooeCpwhbTLNiSgu == Environment.CurrentManagedThreadId)
				{
					fPpgzctJDSXBbbBukTJOAciAsKtP = 0;
					imBwnakLRxtzyAvzcluGELybqUyx = this;
				}
				else
				{
					imBwnakLRxtzyAvzcluGELybqUyx = new ImBwnakLRxtzyAvzcluGELybqUyx(0);
					imBwnakLRxtzyAvzcluGELybqUyx.WrWPKvzmwdwKrmCrKaZqddtIzIkeA = WrWPKvzmwdwKrmCrKaZqddtIzIkeA;
				}
				return imBwnakLRxtzyAvzcluGELybqUyx;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<IControllerElementIdentifierCommon_Internal>)this).GetEnumerator();
			}
		}

		private sealed class VxuJwtaDrOAvwtVSQRrbnbYIWYgm : IEnumerable<ControllerElementIdentifier>, IEnumerable, IEnumerator<ControllerElementIdentifier>, IEnumerator, IDisposable
		{
			private int QrTsbmMlIFpAXtXuuJOzioPnhYbBA;

			private ControllerElementIdentifier MZvjJwxyPkANfEoFPttbIDnjRFkc;

			private int BrFsLneVUvsIaDVSVrIyPGgVbubo;

			public HardwareJoystickMap nvWFXlEMDAJwuFcDlmYnceKuLblHA;

			private int wfTLrIOtEEgUlNcPuRqMhJKAQbIi;

			ControllerElementIdentifier IEnumerator<ControllerElementIdentifier>.Current
			{
				[DebuggerHidden]
				get
				{
					return MZvjJwxyPkANfEoFPttbIDnjRFkc;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return MZvjJwxyPkANfEoFPttbIDnjRFkc;
				}
			}

			[DebuggerHidden]
			public VxuJwtaDrOAvwtVSQRrbnbYIWYgm(int P_0)
			{
				QrTsbmMlIFpAXtXuuJOzioPnhYbBA = P_0;
				BrFsLneVUvsIaDVSVrIyPGgVbubo = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				QrTsbmMlIFpAXtXuuJOzioPnhYbBA = -2;
			}

			private bool MoveNext()
			{
				int qrTsbmMlIFpAXtXuuJOzioPnhYbBA = QrTsbmMlIFpAXtXuuJOzioPnhYbBA;
				HardwareJoystickMap hardwareJoystickMap = nvWFXlEMDAJwuFcDlmYnceKuLblHA;
				switch (qrTsbmMlIFpAXtXuuJOzioPnhYbBA)
				{
				default:
					return false;
				case 0:
					QrTsbmMlIFpAXtXuuJOzioPnhYbBA = -1;
					if (hardwareJoystickMap.elementIdentifiers == null)
					{
						return false;
					}
					wfTLrIOtEEgUlNcPuRqMhJKAQbIi = 0;
					break;
				case 1:
					QrTsbmMlIFpAXtXuuJOzioPnhYbBA = -1;
					wfTLrIOtEEgUlNcPuRqMhJKAQbIi++;
					break;
				}
				if (wfTLrIOtEEgUlNcPuRqMhJKAQbIi < hardwareJoystickMap.elementIdentifiers.Length)
				{
					MZvjJwxyPkANfEoFPttbIDnjRFkc = hardwareJoystickMap.elementIdentifiers[wfTLrIOtEEgUlNcPuRqMhJKAQbIi];
					QrTsbmMlIFpAXtXuuJOzioPnhYbBA = 1;
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
				VxuJwtaDrOAvwtVSQRrbnbYIWYgm vxuJwtaDrOAvwtVSQRrbnbYIWYgm;
				if (QrTsbmMlIFpAXtXuuJOzioPnhYbBA == -2 && BrFsLneVUvsIaDVSVrIyPGgVbubo == Environment.CurrentManagedThreadId)
				{
					QrTsbmMlIFpAXtXuuJOzioPnhYbBA = 0;
					vxuJwtaDrOAvwtVSQRrbnbYIWYgm = this;
				}
				else
				{
					vxuJwtaDrOAvwtVSQRrbnbYIWYgm = new VxuJwtaDrOAvwtVSQRrbnbYIWYgm(0);
					vxuJwtaDrOAvwtVSQRrbnbYIWYgm.nvWFXlEMDAJwuFcDlmYnceKuLblHA = nvWFXlEMDAJwuFcDlmYnceKuLblHA;
				}
				return vxuJwtaDrOAvwtVSQRrbnbYIWYgm;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerElementIdentifier>)this).GetEnumerator();
			}
		}

		private sealed class aDFbEtKCSekbvLcUzakLuJAnfCsEb : IEnumerable<JoystickType>, IEnumerable, IEnumerator<JoystickType>, IEnumerator, IDisposable
		{
			private int DexKuolIkCCqkcwhilLvCqqEumslA;

			private JoystickType KbKiKLAcCPXPHlbmwdtvydKvtGNIA;

			private int ahnaVauqxlAsJnjfCICQyslljszI;

			public HardwareJoystickMap OwAqrJWLtKkdykqvavEXEcpxsoRI;

			private int kFKChUtSsnxAfubNyqujtGddGLtB;

			JoystickType IEnumerator<JoystickType>.Current
			{
				[DebuggerHidden]
				get
				{
					return KbKiKLAcCPXPHlbmwdtvydKvtGNIA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return KbKiKLAcCPXPHlbmwdtvydKvtGNIA;
				}
			}

			[DebuggerHidden]
			public aDFbEtKCSekbvLcUzakLuJAnfCsEb(int P_0)
			{
				DexKuolIkCCqkcwhilLvCqqEumslA = P_0;
				ahnaVauqxlAsJnjfCICQyslljszI = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				DexKuolIkCCqkcwhilLvCqqEumslA = -2;
			}

			private bool MoveNext()
			{
				int dexKuolIkCCqkcwhilLvCqqEumslA = DexKuolIkCCqkcwhilLvCqqEumslA;
				HardwareJoystickMap owAqrJWLtKkdykqvavEXEcpxsoRI = OwAqrJWLtKkdykqvavEXEcpxsoRI;
				switch (dexKuolIkCCqkcwhilLvCqqEumslA)
				{
				default:
					return false;
				case 0:
					DexKuolIkCCqkcwhilLvCqqEumslA = -1;
					if (owAqrJWLtKkdykqvavEXEcpxsoRI.joystickTypes == null)
					{
						return false;
					}
					kFKChUtSsnxAfubNyqujtGddGLtB = 0;
					break;
				case 1:
					DexKuolIkCCqkcwhilLvCqqEumslA = -1;
					kFKChUtSsnxAfubNyqujtGddGLtB++;
					break;
				}
				if (kFKChUtSsnxAfubNyqujtGddGLtB < owAqrJWLtKkdykqvavEXEcpxsoRI.joystickTypes.Length)
				{
					KbKiKLAcCPXPHlbmwdtvydKvtGNIA = owAqrJWLtKkdykqvavEXEcpxsoRI.joystickTypes[kFKChUtSsnxAfubNyqujtGddGLtB];
					DexKuolIkCCqkcwhilLvCqqEumslA = 1;
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
				aDFbEtKCSekbvLcUzakLuJAnfCsEb aDFbEtKCSekbvLcUzakLuJAnfCsEb2;
				if (DexKuolIkCCqkcwhilLvCqqEumslA == -2 && ahnaVauqxlAsJnjfCICQyslljszI == Environment.CurrentManagedThreadId)
				{
					DexKuolIkCCqkcwhilLvCqqEumslA = 0;
					aDFbEtKCSekbvLcUzakLuJAnfCsEb2 = this;
				}
				else
				{
					aDFbEtKCSekbvLcUzakLuJAnfCsEb2 = new aDFbEtKCSekbvLcUzakLuJAnfCsEb(0);
					aDFbEtKCSekbvLcUzakLuJAnfCsEb2.OwAqrJWLtKkdykqvavEXEcpxsoRI = OwAqrJWLtKkdykqvavEXEcpxsoRI;
				}
				return aDFbEtKCSekbvLcUzakLuJAnfCsEb2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JoystickType>)this).GetEnumerator();
			}
		}

		private sealed class NChKsYSoUsmcfNyssrsDLMvIaZfN : IEnumerable<Guid>, IEnumerable, IEnumerator<Guid>, IEnumerator, IDisposable
		{
			private int HcGqvlIInXjzlRDcJXDpMQhLBScP;

			private Guid SCuLnYUGNWcDfiZTreCWXNuLexEr;

			private int wWBgGbhmGStUvoaSIeLDNTJZOKdU;

			public HardwareJoystickMap yBzGLFOIATcieoawYdYJFoeJveje;

			private Guid[] duaGRJcHtsrlfGxLplzQkQSGcSXHA;

			private int zfgIieeQJNgJoBNiQkReePajeVmgc;

			Guid IEnumerator<Guid>.Current
			{
				[DebuggerHidden]
				get
				{
					return SCuLnYUGNWcDfiZTreCWXNuLexEr;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return SCuLnYUGNWcDfiZTreCWXNuLexEr;
				}
			}

			[DebuggerHidden]
			public NChKsYSoUsmcfNyssrsDLMvIaZfN(int P_0)
			{
				HcGqvlIInXjzlRDcJXDpMQhLBScP = P_0;
				wWBgGbhmGStUvoaSIeLDNTJZOKdU = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				duaGRJcHtsrlfGxLplzQkQSGcSXHA = null;
				HcGqvlIInXjzlRDcJXDpMQhLBScP = -2;
			}

			private bool MoveNext()
			{
				int hcGqvlIInXjzlRDcJXDpMQhLBScP = HcGqvlIInXjzlRDcJXDpMQhLBScP;
				HardwareJoystickMap hardwareJoystickMap = yBzGLFOIATcieoawYdYJFoeJveje;
				switch (hcGqvlIInXjzlRDcJXDpMQhLBScP)
				{
				default:
					return false;
				case 0:
					HcGqvlIInXjzlRDcJXDpMQhLBScP = -1;
					if (ReInput.isReady)
					{
						duaGRJcHtsrlfGxLplzQkQSGcSXHA = hardwareJoystickMap.runtimeTemplateGuids;
						if (duaGRJcHtsrlfGxLplzQkQSGcSXHA == null)
						{
							return false;
						}
						zfgIieeQJNgJoBNiQkReePajeVmgc = 0;
						goto IL_0086;
					}
					if (hardwareJoystickMap.templateGuids == null)
					{
						return false;
					}
					zfgIieeQJNgJoBNiQkReePajeVmgc = 0;
					goto IL_00ea;
				case 1:
					HcGqvlIInXjzlRDcJXDpMQhLBScP = -1;
					zfgIieeQJNgJoBNiQkReePajeVmgc++;
					goto IL_0086;
				case 2:
					{
						HcGqvlIInXjzlRDcJXDpMQhLBScP = -1;
						zfgIieeQJNgJoBNiQkReePajeVmgc++;
						goto IL_00ea;
					}
					IL_0086:
					if (zfgIieeQJNgJoBNiQkReePajeVmgc < duaGRJcHtsrlfGxLplzQkQSGcSXHA.Length)
					{
						SCuLnYUGNWcDfiZTreCWXNuLexEr = duaGRJcHtsrlfGxLplzQkQSGcSXHA[zfgIieeQJNgJoBNiQkReePajeVmgc];
						HcGqvlIInXjzlRDcJXDpMQhLBScP = 1;
						return true;
					}
					duaGRJcHtsrlfGxLplzQkQSGcSXHA = null;
					break;
					IL_00ea:
					if (zfgIieeQJNgJoBNiQkReePajeVmgc < hardwareJoystickMap.templateGuids.Length)
					{
						SCuLnYUGNWcDfiZTreCWXNuLexEr = StringTools.ToGuid(hardwareJoystickMap.templateGuids[zfgIieeQJNgJoBNiQkReePajeVmgc]);
						HcGqvlIInXjzlRDcJXDpMQhLBScP = 2;
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
				NChKsYSoUsmcfNyssrsDLMvIaZfN nChKsYSoUsmcfNyssrsDLMvIaZfN;
				if (HcGqvlIInXjzlRDcJXDpMQhLBScP == -2 && wWBgGbhmGStUvoaSIeLDNTJZOKdU == Environment.CurrentManagedThreadId)
				{
					HcGqvlIInXjzlRDcJXDpMQhLBScP = 0;
					nChKsYSoUsmcfNyssrsDLMvIaZfN = this;
				}
				else
				{
					nChKsYSoUsmcfNyssrsDLMvIaZfN = new NChKsYSoUsmcfNyssrsDLMvIaZfN(0);
					nChKsYSoUsmcfNyssrsDLMvIaZfN.yBzGLFOIATcieoawYdYJFoeJveje = yBzGLFOIATcieoawYdYJFoeJveje;
				}
				return nChKsYSoUsmcfNyssrsDLMvIaZfN;
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
		private Platform_NintendoSwitch2 nintendoSwitch2;

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
			[IteratorStateMachine(typeof(NChKsYSoUsmcfNyssrsDLMvIaZfN))]
			get
			{
				return new NChKsYSoUsmcfNyssrsDLMvIaZfN(-2)
				{
					yBzGLFOIATcieoawYdYJFoeJveje = this
				};
			}
		}

		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers
		{
			[IteratorStateMachine(typeof(VxuJwtaDrOAvwtVSQRrbnbYIWYgm))]
			get
			{
				return new VxuJwtaDrOAvwtVSQRrbnbYIWYgm(-2)
				{
					nvWFXlEMDAJwuFcDlmYnceKuLblHA = this
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
			[IteratorStateMachine(typeof(aDFbEtKCSekbvLcUzakLuJAnfCsEb))]
			get
			{
				return new aDFbEtKCSekbvLcUzakLuJAnfCsEb(-2)
				{
					OwAqrJWLtKkdykqvavEXEcpxsoRI = this
				};
			}
		}

		Guid IHardwareControllerMap_Internal.typeGuid => Guid;

		string IHardwareControllerMap_Internal.typeKey => controllerKey;

		ControllerType IHardwareControllerMap_Internal.controllerType => ControllerType.Joystick;

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			[IteratorStateMachine(typeof(ImBwnakLRxtzyAvzcluGELybqUyx))]
			get
			{
				return new ImBwnakLRxtzyAvzcluGELybqUyx(-2)
				{
					WrWPKvzmwdwKrmCrKaZqddtIzIkeA = this
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
			if (nintendoSwitch2 == null)
			{
				nintendoSwitch2 = new Platform_NintendoSwitch2();
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
			if (P_0.nintendoSwitch2 != null)
			{
				nintendoSwitch2 = MiscTools.DeepClone(P_0.nintendoSwitch2);
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
			case InputSource.NintendoSwitch2:
				if (nintendoSwitch2 == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.NintendoSwitch2;
				return nintendoSwitch2.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
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
				if (!mtomRtgTRNntCRDCGTAlowoDhPZo.BxgHUpymmvRaFbsNhjtTNtpbaJviA)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.Custom;
				platformMap = mtomRtgTRNntCRDCGTAlowoDhPZo.nHjQWlufwlhNQzeEihcAhtYesXns().GetPlatformMap(mtomRtgTRNntCRDCGTAlowoDhPZo.ZLGJvaSvYTcOiQFBKGoGCRHFLhlnA, Guid);
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
			case InputSource.NintendoSwitch2:
				actualInputPlatform = InputPlatform.NintendoSwitch2;
				platform = nintendoSwitch2;
				break;
			case InputSource.InternalDriver:
				actualInputPlatform = InputPlatform.InternalDriver;
				platform = internalDriver;
				break;
			case InputSource.SDL2:
				platform = FindSDL2Map(inputSource, isDefaultMap: true, out actualInputPlatform, out variantIndex);
				break;
			case InputSource.Custom:
				if (!mtomRtgTRNntCRDCGTAlowoDhPZo.BxgHUpymmvRaFbsNhjtTNtpbaJviA)
				{
					return null;
				}
				actualInputPlatform = InputPlatform.Custom;
				platform = mtomRtgTRNntCRDCGTAlowoDhPZo.nHjQWlufwlhNQzeEihcAhtYesXns().GetPlatformMap(mtomRtgTRNntCRDCGTAlowoDhPZo.ZLGJvaSvYTcOiQFBKGoGCRHFLhlnA, Guid);
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
			case InputPlatform.NintendoSwitch2:
				return nintendoSwitch2;
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
				if (!mtomRtgTRNntCRDCGTAlowoDhPZo.BxgHUpymmvRaFbsNhjtTNtpbaJviA)
				{
					throw new Exception("Custom Platform is not set.");
				}
				try
				{
					return mtomRtgTRNntCRDCGTAlowoDhPZo.nHjQWlufwlhNQzeEihcAhtYesXns().GetPlatformMap(mtomRtgTRNntCRDCGTAlowoDhPZo.ZLGJvaSvYTcOiQFBKGoGCRHFLhlnA, Guid);
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
