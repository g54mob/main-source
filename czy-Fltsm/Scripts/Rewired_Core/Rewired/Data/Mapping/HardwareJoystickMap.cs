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
			private sealed class XeyvoLPyIdhbIoGFyBVxbRRzATFDA : IEnumerable<Platform>, IEnumerable, IEnumerator<Platform>, IEnumerator, IDisposable
			{
				private int OvYBkiAObLGfjeTjybeBxUsbgPQUA;

				private Platform bMqFfkScSwdiOaMPLthrZFoZQbDf;

				private int pnCJReYbdPjiALexflFeJrfwyYxo;

				public Platform IntesOAWHRfUAQicggDYZlfohfSSA;

				private IList<Platform> TzKTqPveGiLhoWkMaVpTtlVRTrOV;

				private int EYkgeJLfZezDkowVQGNOXqcFxbvP;

				Platform IEnumerator<Platform>.Current
				{
					[DebuggerHidden]
					get
					{
						return bMqFfkScSwdiOaMPLthrZFoZQbDf;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return bMqFfkScSwdiOaMPLthrZFoZQbDf;
					}
				}

				[DebuggerHidden]
				public XeyvoLPyIdhbIoGFyBVxbRRzATFDA(int P_0)
				{
					OvYBkiAObLGfjeTjybeBxUsbgPQUA = P_0;
					pnCJReYbdPjiALexflFeJrfwyYxo = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					TzKTqPveGiLhoWkMaVpTtlVRTrOV = null;
					OvYBkiAObLGfjeTjybeBxUsbgPQUA = -2;
				}

				private bool MoveNext()
				{
					int ovYBkiAObLGfjeTjybeBxUsbgPQUA = OvYBkiAObLGfjeTjybeBxUsbgPQUA;
					Platform intesOAWHRfUAQicggDYZlfohfSSA = IntesOAWHRfUAQicggDYZlfohfSSA;
					if (ovYBkiAObLGfjeTjybeBxUsbgPQUA != 0)
					{
						if (ovYBkiAObLGfjeTjybeBxUsbgPQUA != 1)
						{
							return false;
						}
						OvYBkiAObLGfjeTjybeBxUsbgPQUA = -1;
						goto IL_0077;
					}
					OvYBkiAObLGfjeTjybeBxUsbgPQUA = -1;
					TzKTqPveGiLhoWkMaVpTtlVRTrOV = intesOAWHRfUAQicggDYZlfohfSSA.GetVariants();
					if (TzKTqPveGiLhoWkMaVpTtlVRTrOV == null)
					{
						return false;
					}
					EYkgeJLfZezDkowVQGNOXqcFxbvP = 0;
					goto IL_0087;
					IL_0087:
					if (EYkgeJLfZezDkowVQGNOXqcFxbvP < TzKTqPveGiLhoWkMaVpTtlVRTrOV.Count)
					{
						if (TzKTqPveGiLhoWkMaVpTtlVRTrOV[EYkgeJLfZezDkowVQGNOXqcFxbvP] != null)
						{
							bMqFfkScSwdiOaMPLthrZFoZQbDf = TzKTqPveGiLhoWkMaVpTtlVRTrOV[EYkgeJLfZezDkowVQGNOXqcFxbvP];
							OvYBkiAObLGfjeTjybeBxUsbgPQUA = 1;
							return true;
						}
						goto IL_0077;
					}
					return false;
					IL_0077:
					EYkgeJLfZezDkowVQGNOXqcFxbvP++;
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
					XeyvoLPyIdhbIoGFyBVxbRRzATFDA xeyvoLPyIdhbIoGFyBVxbRRzATFDA;
					if (OvYBkiAObLGfjeTjybeBxUsbgPQUA == -2 && pnCJReYbdPjiALexflFeJrfwyYxo == Environment.CurrentManagedThreadId)
					{
						OvYBkiAObLGfjeTjybeBxUsbgPQUA = 0;
						xeyvoLPyIdhbIoGFyBVxbRRzATFDA = this;
					}
					else
					{
						xeyvoLPyIdhbIoGFyBVxbRRzATFDA = new XeyvoLPyIdhbIoGFyBVxbRRzATFDA(0);
						xeyvoLPyIdhbIoGFyBVxbRRzATFDA.IntesOAWHRfUAQicggDYZlfohfSSA = IntesOAWHRfUAQicggDYZlfohfSSA;
					}
					return xeyvoLPyIdhbIoGFyBVxbRRzATFDA;
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
				[IteratorStateMachine(typeof(XeyvoLPyIdhbIoGFyBVxbRRzATFDA))]
				get
				{
					return new XeyvoLPyIdhbIoGFyBVxbRRzATFDA(-2)
					{
						IntesOAWHRfUAQicggDYZlfohfSSA = this
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
					qJZagAZjhaLZbLstuZlIbkTalFLE(elementCount_Base);
					return elementCount_Base;
				}

				object IDeepCloneable.DeepClone()
				{
					//ILSpy generated this explicit interface implementation from .override directive in DeepClone
					return this.DeepClone();
				}

				internal virtual void qJZagAZjhaLZbLstuZlIbkTalFLE(ElementCount_Base P_0)
				{
					if (P_0 != null)
					{
						P_0.axisCount = axisCount;
						P_0.buttonCount = buttonCount;
					}
				}

				internal virtual bool ZvIfrZHlPaocCwcPMJBmtNPEjEjM(BridgedControllerHWInfo P_0)
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
					if (elementCount_Base != null && elementCount_Base.ZvIfrZHlPaocCwcPMJBmtNPEjEjM(bridgedControllerHWInfo))
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

			public int intValue0;

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

			private Axis2DClampType axis2DClampType => (Axis2DClampType)intValue0;

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
				intValue0 = source.intValue0;
			}

			internal virtual Axis2DCalibrationData GetAxis2DCalibrationData()
			{
				if (type != CompoundControllerElementType.Axis2D)
				{
					Logger.LogError("Compound element type mismatch. Expected " + type.ToString() + ", found " + CompoundControllerElementType.Axis2D.ToString() + ".");
					return default(Axis2DCalibrationData);
				}
				return new Axis2DCalibrationData((DeadZone2DType)(-1), (AxisSensitivity2DType)(-1), axis2DClampType);
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
						qJZagAZjhaLZbLstuZlIbkTalFLE(elementCount);
						return elementCount;
					}

					internal void atwaiqkQhcZDQdRkYilXwAdHRjpbA(ElementCount_Base P_0)
					{
						base.qJZagAZjhaLZbLstuZlIbkTalFLE(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool JUSgwgANcIAJJwgGNUyFCkGMOyAE(BridgedControllerHWInfo P_0)
					{
						if (!base.ZvIfrZHlPaocCwcPMJBmtNPEjEjM(P_0))
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

				public float axisUpperDeadZone;

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
						axisUpperDeadZone = axisUpperDeadZone,
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

				public float axisUpperDeadZone;

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
					axisUpperDeadZone = source.axisUpperDeadZone;
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
				private sealed class kBLFQGgtCjUxELXloBnOcvQnwXiB : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int nnaIHjbujLLevLVSQBZtHBszbAKI;

					private Axis_Base VxnSAlUeOTDCHkmsvYcklTCxGkJHb;

					private int PComQDjHvSoBFidKfaYJLcIeTyFD;

					public Elements boSrdTBzAsNdOLwzWxPBbBbABxQ;

					private int SSQncTrLchftOEYScaCPlCvJFKgpA;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return VxnSAlUeOTDCHkmsvYcklTCxGkJHb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return VxnSAlUeOTDCHkmsvYcklTCxGkJHb;
						}
					}

					[DebuggerHidden]
					public kBLFQGgtCjUxELXloBnOcvQnwXiB(int P_0)
					{
						nnaIHjbujLLevLVSQBZtHBszbAKI = P_0;
						PComQDjHvSoBFidKfaYJLcIeTyFD = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						nnaIHjbujLLevLVSQBZtHBszbAKI = -2;
					}

					private bool MoveNext()
					{
						int num = nnaIHjbujLLevLVSQBZtHBszbAKI;
						Elements elements = boSrdTBzAsNdOLwzWxPBbBbABxQ;
						switch (num)
						{
						default:
							return false;
						case 0:
							nnaIHjbujLLevLVSQBZtHBszbAKI = -1;
							if (elements.axes == null)
							{
								return false;
							}
							SSQncTrLchftOEYScaCPlCvJFKgpA = 0;
							break;
						case 1:
							nnaIHjbujLLevLVSQBZtHBszbAKI = -1;
							SSQncTrLchftOEYScaCPlCvJFKgpA++;
							break;
						}
						if (SSQncTrLchftOEYScaCPlCvJFKgpA < elements.axes.Length)
						{
							VxnSAlUeOTDCHkmsvYcklTCxGkJHb = elements.axes[SSQncTrLchftOEYScaCPlCvJFKgpA];
							nnaIHjbujLLevLVSQBZtHBszbAKI = 1;
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
						kBLFQGgtCjUxELXloBnOcvQnwXiB kBLFQGgtCjUxELXloBnOcvQnwXiB2;
						if (nnaIHjbujLLevLVSQBZtHBszbAKI == -2 && PComQDjHvSoBFidKfaYJLcIeTyFD == Environment.CurrentManagedThreadId)
						{
							nnaIHjbujLLevLVSQBZtHBszbAKI = 0;
							kBLFQGgtCjUxELXloBnOcvQnwXiB2 = this;
						}
						else
						{
							kBLFQGgtCjUxELXloBnOcvQnwXiB2 = new kBLFQGgtCjUxELXloBnOcvQnwXiB(0);
							kBLFQGgtCjUxELXloBnOcvQnwXiB2.boSrdTBzAsNdOLwzWxPBbBbABxQ = boSrdTBzAsNdOLwzWxPBbBbABxQ;
						}
						return kBLFQGgtCjUxELXloBnOcvQnwXiB2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}
				}

				private sealed class fxfuHpkaAFpQGKrFcLGjFepZjWoHA : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int tygRjSJaqFppWscUeJUTTNaiTufr;

					private Button_Base NgaDdsieFsAcRXCUdOeGXwHufDRb;

					private int JKARGAYOGpbRigLzTfxjOGgEpbGgA;

					public Elements tVaCyBPOMnZAjwFUrEuEFQHtbBEn;

					private int RQictuWJJcCwKHtepEvEkMTwXlFj;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return NgaDdsieFsAcRXCUdOeGXwHufDRb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return NgaDdsieFsAcRXCUdOeGXwHufDRb;
						}
					}

					[DebuggerHidden]
					public fxfuHpkaAFpQGKrFcLGjFepZjWoHA(int P_0)
					{
						tygRjSJaqFppWscUeJUTTNaiTufr = P_0;
						JKARGAYOGpbRigLzTfxjOGgEpbGgA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						tygRjSJaqFppWscUeJUTTNaiTufr = -2;
					}

					private bool MoveNext()
					{
						int num = tygRjSJaqFppWscUeJUTTNaiTufr;
						Elements elements = tVaCyBPOMnZAjwFUrEuEFQHtbBEn;
						switch (num)
						{
						default:
							return false;
						case 0:
							tygRjSJaqFppWscUeJUTTNaiTufr = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							RQictuWJJcCwKHtepEvEkMTwXlFj = 0;
							break;
						case 1:
							tygRjSJaqFppWscUeJUTTNaiTufr = -1;
							RQictuWJJcCwKHtepEvEkMTwXlFj++;
							break;
						}
						if (RQictuWJJcCwKHtepEvEkMTwXlFj < elements.buttons.Length)
						{
							NgaDdsieFsAcRXCUdOeGXwHufDRb = elements.buttons[RQictuWJJcCwKHtepEvEkMTwXlFj];
							tygRjSJaqFppWscUeJUTTNaiTufr = 1;
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
						fxfuHpkaAFpQGKrFcLGjFepZjWoHA fxfuHpkaAFpQGKrFcLGjFepZjWoHA2;
						if (tygRjSJaqFppWscUeJUTTNaiTufr == -2 && JKARGAYOGpbRigLzTfxjOGgEpbGgA == Environment.CurrentManagedThreadId)
						{
							tygRjSJaqFppWscUeJUTTNaiTufr = 0;
							fxfuHpkaAFpQGKrFcLGjFepZjWoHA2 = this;
						}
						else
						{
							fxfuHpkaAFpQGKrFcLGjFepZjWoHA2 = new fxfuHpkaAFpQGKrFcLGjFepZjWoHA(0);
							fxfuHpkaAFpQGKrFcLGjFepZjWoHA2.tVaCyBPOMnZAjwFUrEuEFQHtbBEn = tVaCyBPOMnZAjwFUrEuEFQHtbBEn;
						}
						return fxfuHpkaAFpQGKrFcLGjFepZjWoHA2;
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
					[IteratorStateMachine(typeof(kBLFQGgtCjUxELXloBnOcvQnwXiB))]
					get
					{
						return new kBLFQGgtCjUxELXloBnOcvQnwXiB(-2)
						{
							boSrdTBzAsNdOLwzWxPBbBbABxQ = this
						};
					}
				}

				IEnumerable<Button_Base> Elements_Platform_Base.Buttons
				{
					[IteratorStateMachine(typeof(fxfuHpkaAFpQGKrFcLGjFepZjWoHA))]
					get
					{
						return new fxfuHpkaAFpQGKrFcLGjFepZjWoHA(-2)
						{
							tVaCyBPOMnZAjwFUrEuEFQHtbBEn = this
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

			private sealed class QqMEqKiMBXhCzxSEZVNkceKfLTMs : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int YxlwsyyfwBGQKfudaLvOcsGKnuHHA;

				private Axis_Base maoyHGDoPCXMTZeYOllPAwQPnOyl;

				private int BcWAHQOipPpinmjoBHmnlMCXhfhiA;

				public Platform_DirectInput_Base lnVrhHdpgdfSUEfYMgRTCbUbltAXA;

				private int scnhuPFOKCjgWteZulPUCdMcoRCl;

				private int nKBFVZhyKSIyPUbYBSacDlljaRIJ;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return maoyHGDoPCXMTZeYOllPAwQPnOyl;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return maoyHGDoPCXMTZeYOllPAwQPnOyl;
					}
				}

				[DebuggerHidden]
				public QqMEqKiMBXhCzxSEZVNkceKfLTMs(int P_0)
				{
					YxlwsyyfwBGQKfudaLvOcsGKnuHHA = P_0;
					BcWAHQOipPpinmjoBHmnlMCXhfhiA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					YxlwsyyfwBGQKfudaLvOcsGKnuHHA = -2;
				}

				private bool MoveNext()
				{
					int yxlwsyyfwBGQKfudaLvOcsGKnuHHA = YxlwsyyfwBGQKfudaLvOcsGKnuHHA;
					Platform_DirectInput_Base platform_DirectInput_Base = lnVrhHdpgdfSUEfYMgRTCbUbltAXA;
					switch (yxlwsyyfwBGQKfudaLvOcsGKnuHHA)
					{
					default:
						return false;
					case 0:
						YxlwsyyfwBGQKfudaLvOcsGKnuHHA = -1;
						if (platform_DirectInput_Base.elements == null || platform_DirectInput_Base.elements.axes == null)
						{
							return false;
						}
						scnhuPFOKCjgWteZulPUCdMcoRCl = platform_DirectInput_Base.elements.axes.Length;
						nKBFVZhyKSIyPUbYBSacDlljaRIJ = 0;
						break;
					case 1:
						YxlwsyyfwBGQKfudaLvOcsGKnuHHA = -1;
						nKBFVZhyKSIyPUbYBSacDlljaRIJ++;
						break;
					}
					if (nKBFVZhyKSIyPUbYBSacDlljaRIJ < scnhuPFOKCjgWteZulPUCdMcoRCl)
					{
						maoyHGDoPCXMTZeYOllPAwQPnOyl = platform_DirectInput_Base.elements.axes[nKBFVZhyKSIyPUbYBSacDlljaRIJ];
						YxlwsyyfwBGQKfudaLvOcsGKnuHHA = 1;
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
					QqMEqKiMBXhCzxSEZVNkceKfLTMs qqMEqKiMBXhCzxSEZVNkceKfLTMs;
					if (YxlwsyyfwBGQKfudaLvOcsGKnuHHA == -2 && BcWAHQOipPpinmjoBHmnlMCXhfhiA == Environment.CurrentManagedThreadId)
					{
						YxlwsyyfwBGQKfudaLvOcsGKnuHHA = 0;
						qqMEqKiMBXhCzxSEZVNkceKfLTMs = this;
					}
					else
					{
						qqMEqKiMBXhCzxSEZVNkceKfLTMs = new QqMEqKiMBXhCzxSEZVNkceKfLTMs(0);
						qqMEqKiMBXhCzxSEZVNkceKfLTMs.lnVrhHdpgdfSUEfYMgRTCbUbltAXA = lnVrhHdpgdfSUEfYMgRTCbUbltAXA;
					}
					return qqMEqKiMBXhCzxSEZVNkceKfLTMs;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}
			}

			private sealed class tkknIpQdnCVZuJJSnnjmIoRXwWee : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int XJqYQSyGXhZiyGSCGcKZiOZhwCec;

				private Button_Base AbVgTjJtQnWdPxvLcSFdpoKJEwhdA;

				private int TUiaGfFOSGRVRMTsKtuiyhfmhlKf;

				public Platform_DirectInput_Base jkMBFBvBuEmRLyKYluFBuDCxiLQaA;

				private int mvyFSYfJLhnyOXcRGMXKzHgcVtUAA;

				private int sWxVzYXHjtdQxaCgfHZiaknStUvnA;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return AbVgTjJtQnWdPxvLcSFdpoKJEwhdA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return AbVgTjJtQnWdPxvLcSFdpoKJEwhdA;
					}
				}

				[DebuggerHidden]
				public tkknIpQdnCVZuJJSnnjmIoRXwWee(int P_0)
				{
					XJqYQSyGXhZiyGSCGcKZiOZhwCec = P_0;
					TUiaGfFOSGRVRMTsKtuiyhfmhlKf = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					XJqYQSyGXhZiyGSCGcKZiOZhwCec = -2;
				}

				private bool MoveNext()
				{
					int xJqYQSyGXhZiyGSCGcKZiOZhwCec = XJqYQSyGXhZiyGSCGcKZiOZhwCec;
					Platform_DirectInput_Base platform_DirectInput_Base = jkMBFBvBuEmRLyKYluFBuDCxiLQaA;
					switch (xJqYQSyGXhZiyGSCGcKZiOZhwCec)
					{
					default:
						return false;
					case 0:
						XJqYQSyGXhZiyGSCGcKZiOZhwCec = -1;
						if (platform_DirectInput_Base.elements == null || platform_DirectInput_Base.elements.buttons == null)
						{
							return false;
						}
						mvyFSYfJLhnyOXcRGMXKzHgcVtUAA = platform_DirectInput_Base.elements.buttons.Length;
						sWxVzYXHjtdQxaCgfHZiaknStUvnA = 0;
						break;
					case 1:
						XJqYQSyGXhZiyGSCGcKZiOZhwCec = -1;
						sWxVzYXHjtdQxaCgfHZiaknStUvnA++;
						break;
					}
					if (sWxVzYXHjtdQxaCgfHZiaknStUvnA < mvyFSYfJLhnyOXcRGMXKzHgcVtUAA)
					{
						AbVgTjJtQnWdPxvLcSFdpoKJEwhdA = platform_DirectInput_Base.elements.buttons[sWxVzYXHjtdQxaCgfHZiaknStUvnA];
						XJqYQSyGXhZiyGSCGcKZiOZhwCec = 1;
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
					tkknIpQdnCVZuJJSnnjmIoRXwWee tkknIpQdnCVZuJJSnnjmIoRXwWee2;
					if (XJqYQSyGXhZiyGSCGcKZiOZhwCec == -2 && TUiaGfFOSGRVRMTsKtuiyhfmhlKf == Environment.CurrentManagedThreadId)
					{
						XJqYQSyGXhZiyGSCGcKZiOZhwCec = 0;
						tkknIpQdnCVZuJJSnnjmIoRXwWee2 = this;
					}
					else
					{
						tkknIpQdnCVZuJJSnnjmIoRXwWee2 = new tkknIpQdnCVZuJJSnnjmIoRXwWee(0);
						tkknIpQdnCVZuJJSnnjmIoRXwWee2.jkMBFBvBuEmRLyKYluFBuDCxiLQaA = jkMBFBvBuEmRLyKYluFBuDCxiLQaA;
					}
					return tkknIpQdnCVZuJJSnnjmIoRXwWee2;
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
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
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

			[IteratorStateMachine(typeof(QqMEqKiMBXhCzxSEZVNkceKfLTMs))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return new QqMEqKiMBXhCzxSEZVNkceKfLTMs(-2)
				{
					lnVrhHdpgdfSUEfYMgRTCbUbltAXA = this
				};
			}

			[IteratorStateMachine(typeof(tkknIpQdnCVZuJJSnnjmIoRXwWee))]
			internal override IEnumerable<Button_Base> IterateButtons()
			{
				return new tkknIpQdnCVZuJJSnnjmIoRXwWee(-2)
				{
					jkMBFBvBuEmRLyKYluFBuDCxiLQaA = this
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
				private sealed class DCUacsgkcXeKSAEsKPHuolGealyKc : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int wwnItSomyJANyfQwVzhwNZOAQnqHA;

					private Axis_Base ptJVydhNXzLDqjJOgZwkqMRJxoKb;

					private int DEbcaafcJcFStYGwmNQvbDmjDqFDc;

					public Elements pkHamMzIcufZQAIqeEptFqtXOGCO;

					private int dGTdxxUXgenoHovOJEaptgJiJujo;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return ptJVydhNXzLDqjJOgZwkqMRJxoKb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ptJVydhNXzLDqjJOgZwkqMRJxoKb;
						}
					}

					[DebuggerHidden]
					public DCUacsgkcXeKSAEsKPHuolGealyKc(int P_0)
					{
						wwnItSomyJANyfQwVzhwNZOAQnqHA = P_0;
						DEbcaafcJcFStYGwmNQvbDmjDqFDc = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						wwnItSomyJANyfQwVzhwNZOAQnqHA = -2;
					}

					private bool MoveNext()
					{
						int num = wwnItSomyJANyfQwVzhwNZOAQnqHA;
						Elements elements = pkHamMzIcufZQAIqeEptFqtXOGCO;
						switch (num)
						{
						default:
							return false;
						case 0:
							wwnItSomyJANyfQwVzhwNZOAQnqHA = -1;
							if (elements.axes == null)
							{
								return false;
							}
							dGTdxxUXgenoHovOJEaptgJiJujo = 0;
							break;
						case 1:
							wwnItSomyJANyfQwVzhwNZOAQnqHA = -1;
							dGTdxxUXgenoHovOJEaptgJiJujo++;
							break;
						}
						if (dGTdxxUXgenoHovOJEaptgJiJujo < elements.axes.Length)
						{
							ptJVydhNXzLDqjJOgZwkqMRJxoKb = elements.axes[dGTdxxUXgenoHovOJEaptgJiJujo];
							wwnItSomyJANyfQwVzhwNZOAQnqHA = 1;
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
						DCUacsgkcXeKSAEsKPHuolGealyKc dCUacsgkcXeKSAEsKPHuolGealyKc;
						if (wwnItSomyJANyfQwVzhwNZOAQnqHA == -2 && DEbcaafcJcFStYGwmNQvbDmjDqFDc == Environment.CurrentManagedThreadId)
						{
							wwnItSomyJANyfQwVzhwNZOAQnqHA = 0;
							dCUacsgkcXeKSAEsKPHuolGealyKc = this;
						}
						else
						{
							dCUacsgkcXeKSAEsKPHuolGealyKc = new DCUacsgkcXeKSAEsKPHuolGealyKc(0);
							dCUacsgkcXeKSAEsKPHuolGealyKc.pkHamMzIcufZQAIqeEptFqtXOGCO = pkHamMzIcufZQAIqeEptFqtXOGCO;
						}
						return dCUacsgkcXeKSAEsKPHuolGealyKc;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}
				}

				private sealed class oeebtHKZyEkFsIzSHjXqumbRmTdiA : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int niaoxXsCOEbBmkBhRhDyGsIuqNIz;

					private Button_Base TxarjZTjHqAWHCFtHFmjJSmgillKA;

					private int EksLtULMuceKdKKHMOauUduJzYhU;

					public Elements EkwDdRRUNLezlDKoefGeCFNDClqgB;

					private int yHLJOUuDIPLKzcXpgaTzKWNJjFEJ;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return TxarjZTjHqAWHCFtHFmjJSmgillKA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return TxarjZTjHqAWHCFtHFmjJSmgillKA;
						}
					}

					[DebuggerHidden]
					public oeebtHKZyEkFsIzSHjXqumbRmTdiA(int P_0)
					{
						niaoxXsCOEbBmkBhRhDyGsIuqNIz = P_0;
						EksLtULMuceKdKKHMOauUduJzYhU = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						niaoxXsCOEbBmkBhRhDyGsIuqNIz = -2;
					}

					private bool MoveNext()
					{
						int num = niaoxXsCOEbBmkBhRhDyGsIuqNIz;
						Elements ekwDdRRUNLezlDKoefGeCFNDClqgB = EkwDdRRUNLezlDKoefGeCFNDClqgB;
						switch (num)
						{
						default:
							return false;
						case 0:
							niaoxXsCOEbBmkBhRhDyGsIuqNIz = -1;
							if (ekwDdRRUNLezlDKoefGeCFNDClqgB.buttons == null)
							{
								return false;
							}
							yHLJOUuDIPLKzcXpgaTzKWNJjFEJ = 0;
							break;
						case 1:
							niaoxXsCOEbBmkBhRhDyGsIuqNIz = -1;
							yHLJOUuDIPLKzcXpgaTzKWNJjFEJ++;
							break;
						}
						if (yHLJOUuDIPLKzcXpgaTzKWNJjFEJ < ekwDdRRUNLezlDKoefGeCFNDClqgB.buttons.Length)
						{
							TxarjZTjHqAWHCFtHFmjJSmgillKA = ekwDdRRUNLezlDKoefGeCFNDClqgB.buttons[yHLJOUuDIPLKzcXpgaTzKWNJjFEJ];
							niaoxXsCOEbBmkBhRhDyGsIuqNIz = 1;
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
						oeebtHKZyEkFsIzSHjXqumbRmTdiA oeebtHKZyEkFsIzSHjXqumbRmTdiA2;
						if (niaoxXsCOEbBmkBhRhDyGsIuqNIz == -2 && EksLtULMuceKdKKHMOauUduJzYhU == Environment.CurrentManagedThreadId)
						{
							niaoxXsCOEbBmkBhRhDyGsIuqNIz = 0;
							oeebtHKZyEkFsIzSHjXqumbRmTdiA2 = this;
						}
						else
						{
							oeebtHKZyEkFsIzSHjXqumbRmTdiA2 = new oeebtHKZyEkFsIzSHjXqumbRmTdiA(0);
							oeebtHKZyEkFsIzSHjXqumbRmTdiA2.EkwDdRRUNLezlDKoefGeCFNDClqgB = EkwDdRRUNLezlDKoefGeCFNDClqgB;
						}
						return oeebtHKZyEkFsIzSHjXqumbRmTdiA2;
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
					[IteratorStateMachine(typeof(DCUacsgkcXeKSAEsKPHuolGealyKc))]
					get
					{
						return new DCUacsgkcXeKSAEsKPHuolGealyKc(-2)
						{
							pkHamMzIcufZQAIqeEptFqtXOGCO = this
						};
					}
				}

				IEnumerable<Button_Base> Elements_Platform_Base.Buttons
				{
					[IteratorStateMachine(typeof(oeebtHKZyEkFsIzSHjXqumbRmTdiA))]
					get
					{
						return new oeebtHKZyEkFsIzSHjXqumbRmTdiA(-2)
						{
							EkwDdRRUNLezlDKoefGeCFNDClqgB = this
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

			private sealed class VbTipbzvilnTKjiLNBQoaIKKpACTA : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int ToHIjxKpNDFlPOWNPcVniUTbmfNf;

				private Axis_Base LMsCUnHvqwQwwnPuMIDQTTStzzIY;

				private int JivDiHEcdyFBvuLktxGwhqefkjnS;

				public Platform_RawInput_Base NOvrFFzSSzviwTRqvBdOqFmwYsZp;

				private int QBvXayKdPRchUTYByFVDesJYHkZdA;

				private int eqpvROeFwEwAVSSvxHaOqcjkmvqq;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return LMsCUnHvqwQwwnPuMIDQTTStzzIY;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return LMsCUnHvqwQwwnPuMIDQTTStzzIY;
					}
				}

				[DebuggerHidden]
				public VbTipbzvilnTKjiLNBQoaIKKpACTA(int P_0)
				{
					ToHIjxKpNDFlPOWNPcVniUTbmfNf = P_0;
					JivDiHEcdyFBvuLktxGwhqefkjnS = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					ToHIjxKpNDFlPOWNPcVniUTbmfNf = -2;
				}

				private bool MoveNext()
				{
					int toHIjxKpNDFlPOWNPcVniUTbmfNf = ToHIjxKpNDFlPOWNPcVniUTbmfNf;
					Platform_RawInput_Base nOvrFFzSSzviwTRqvBdOqFmwYsZp = NOvrFFzSSzviwTRqvBdOqFmwYsZp;
					switch (toHIjxKpNDFlPOWNPcVniUTbmfNf)
					{
					default:
						return false;
					case 0:
						ToHIjxKpNDFlPOWNPcVniUTbmfNf = -1;
						if (nOvrFFzSSzviwTRqvBdOqFmwYsZp.elements == null || nOvrFFzSSzviwTRqvBdOqFmwYsZp.elements.axes == null)
						{
							return false;
						}
						QBvXayKdPRchUTYByFVDesJYHkZdA = nOvrFFzSSzviwTRqvBdOqFmwYsZp.elements.axes.Length;
						eqpvROeFwEwAVSSvxHaOqcjkmvqq = 0;
						break;
					case 1:
						ToHIjxKpNDFlPOWNPcVniUTbmfNf = -1;
						eqpvROeFwEwAVSSvxHaOqcjkmvqq++;
						break;
					}
					if (eqpvROeFwEwAVSSvxHaOqcjkmvqq < QBvXayKdPRchUTYByFVDesJYHkZdA)
					{
						LMsCUnHvqwQwwnPuMIDQTTStzzIY = nOvrFFzSSzviwTRqvBdOqFmwYsZp.elements.axes[eqpvROeFwEwAVSSvxHaOqcjkmvqq];
						ToHIjxKpNDFlPOWNPcVniUTbmfNf = 1;
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
					VbTipbzvilnTKjiLNBQoaIKKpACTA vbTipbzvilnTKjiLNBQoaIKKpACTA;
					if (ToHIjxKpNDFlPOWNPcVniUTbmfNf == -2 && JivDiHEcdyFBvuLktxGwhqefkjnS == Environment.CurrentManagedThreadId)
					{
						ToHIjxKpNDFlPOWNPcVniUTbmfNf = 0;
						vbTipbzvilnTKjiLNBQoaIKKpACTA = this;
					}
					else
					{
						vbTipbzvilnTKjiLNBQoaIKKpACTA = new VbTipbzvilnTKjiLNBQoaIKKpACTA(0);
						vbTipbzvilnTKjiLNBQoaIKKpACTA.NOvrFFzSSzviwTRqvBdOqFmwYsZp = NOvrFFzSSzviwTRqvBdOqFmwYsZp;
					}
					return vbTipbzvilnTKjiLNBQoaIKKpACTA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}
			}

			private sealed class TYPCIaYfXJSTegbLkKkgDlmcEvoD : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int jRkdoCcHJxbOKllZVwcfWuAwYxzpA;

				private Button_Base VlAuBRbdoBCdSUGAQesWykCiNNIC;

				private int iwPydiroUVSnbhNArgEpimQTlGrrA;

				public Platform_RawInput_Base nimBVoOxBPBXOGJADZiigEATUXABA;

				private int UEZXMbSZRPHecOcSLFIiYDDGsGlV;

				private int KqCbipaQmmaxCNkauRYOdUTTfsly;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return VlAuBRbdoBCdSUGAQesWykCiNNIC;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return VlAuBRbdoBCdSUGAQesWykCiNNIC;
					}
				}

				[DebuggerHidden]
				public TYPCIaYfXJSTegbLkKkgDlmcEvoD(int P_0)
				{
					jRkdoCcHJxbOKllZVwcfWuAwYxzpA = P_0;
					iwPydiroUVSnbhNArgEpimQTlGrrA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					jRkdoCcHJxbOKllZVwcfWuAwYxzpA = -2;
				}

				private bool MoveNext()
				{
					int num = jRkdoCcHJxbOKllZVwcfWuAwYxzpA;
					Platform_RawInput_Base platform_RawInput_Base = nimBVoOxBPBXOGJADZiigEATUXABA;
					switch (num)
					{
					default:
						return false;
					case 0:
						jRkdoCcHJxbOKllZVwcfWuAwYxzpA = -1;
						if (platform_RawInput_Base.elements == null || platform_RawInput_Base.elements.buttons == null)
						{
							return false;
						}
						UEZXMbSZRPHecOcSLFIiYDDGsGlV = platform_RawInput_Base.elements.buttons.Length;
						KqCbipaQmmaxCNkauRYOdUTTfsly = 0;
						break;
					case 1:
						jRkdoCcHJxbOKllZVwcfWuAwYxzpA = -1;
						KqCbipaQmmaxCNkauRYOdUTTfsly++;
						break;
					}
					if (KqCbipaQmmaxCNkauRYOdUTTfsly < UEZXMbSZRPHecOcSLFIiYDDGsGlV)
					{
						VlAuBRbdoBCdSUGAQesWykCiNNIC = platform_RawInput_Base.elements.buttons[KqCbipaQmmaxCNkauRYOdUTTfsly];
						jRkdoCcHJxbOKllZVwcfWuAwYxzpA = 1;
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
					TYPCIaYfXJSTegbLkKkgDlmcEvoD tYPCIaYfXJSTegbLkKkgDlmcEvoD;
					if (jRkdoCcHJxbOKllZVwcfWuAwYxzpA == -2 && iwPydiroUVSnbhNArgEpimQTlGrrA == Environment.CurrentManagedThreadId)
					{
						jRkdoCcHJxbOKllZVwcfWuAwYxzpA = 0;
						tYPCIaYfXJSTegbLkKkgDlmcEvoD = this;
					}
					else
					{
						tYPCIaYfXJSTegbLkKkgDlmcEvoD = new TYPCIaYfXJSTegbLkKkgDlmcEvoD(0);
						tYPCIaYfXJSTegbLkKkgDlmcEvoD.nimBVoOxBPBXOGJADZiigEATUXABA = nimBVoOxBPBXOGJADZiigEATUXABA;
					}
					return tYPCIaYfXJSTegbLkKkgDlmcEvoD;
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
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
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

			[IteratorStateMachine(typeof(VbTipbzvilnTKjiLNBQoaIKKpACTA))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return new VbTipbzvilnTKjiLNBQoaIKKpACTA(-2)
				{
					NOvrFFzSSzviwTRqvBdOqFmwYsZp = this
				};
			}

			[IteratorStateMachine(typeof(TYPCIaYfXJSTegbLkKkgDlmcEvoD))]
			internal override IEnumerable<Button_Base> IterateButtons()
			{
				return new TYPCIaYfXJSTegbLkKkgDlmcEvoD(-2)
				{
					nimBVoOxBPBXOGJADZiigEATUXABA = this
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

				public float axisUpperDeadZone;

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
						axis.axisUpperDeadZone = axisUpperDeadZone;
						axis.calibrateAxis = calibrateAxis;
						axis.axisZero = axisZero;
						axis.axisMin = axisMin;
						axis.axisMax = axisMax;
						axis.axisInfo = MiscTools.DeepClone(axisInfo);
						axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
					}
				}
			}

			private sealed class sIgnQZGKimMbynioDEqFptcqnCpA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int MdtBuSCMoluJazYCCiokIhZIbEWh;

				private Axis ANXAspXllqcEEFtwGLpfWjmKPLzZ;

				private int hiEZIFZFJQQJoDlcsRWnbqZxfGQm;

				public Platform_XInput_Base PlImTxLXVoqoxwkunPBqkllXeliP;

				private int fGdBnLPFAUWNzliypYahUjYVFAKW;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ANXAspXllqcEEFtwGLpfWjmKPLzZ;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ANXAspXllqcEEFtwGLpfWjmKPLzZ;
					}
				}

				[DebuggerHidden]
				public sIgnQZGKimMbynioDEqFptcqnCpA(int P_0)
				{
					MdtBuSCMoluJazYCCiokIhZIbEWh = P_0;
					hiEZIFZFJQQJoDlcsRWnbqZxfGQm = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					MdtBuSCMoluJazYCCiokIhZIbEWh = -2;
				}

				private bool MoveNext()
				{
					int mdtBuSCMoluJazYCCiokIhZIbEWh = MdtBuSCMoluJazYCCiokIhZIbEWh;
					Platform_XInput_Base plImTxLXVoqoxwkunPBqkllXeliP = PlImTxLXVoqoxwkunPBqkllXeliP;
					switch (mdtBuSCMoluJazYCCiokIhZIbEWh)
					{
					default:
						return false;
					case 0:
						MdtBuSCMoluJazYCCiokIhZIbEWh = -1;
						if (plImTxLXVoqoxwkunPBqkllXeliP.elements == null || plImTxLXVoqoxwkunPBqkllXeliP.elements.axes == null)
						{
							return false;
						}
						fGdBnLPFAUWNzliypYahUjYVFAKW = 0;
						break;
					case 1:
						MdtBuSCMoluJazYCCiokIhZIbEWh = -1;
						fGdBnLPFAUWNzliypYahUjYVFAKW++;
						break;
					}
					if (fGdBnLPFAUWNzliypYahUjYVFAKW < plImTxLXVoqoxwkunPBqkllXeliP.elements.axes.Length)
					{
						ANXAspXllqcEEFtwGLpfWjmKPLzZ = plImTxLXVoqoxwkunPBqkllXeliP.elements.axes[fGdBnLPFAUWNzliypYahUjYVFAKW];
						MdtBuSCMoluJazYCCiokIhZIbEWh = 1;
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
					sIgnQZGKimMbynioDEqFptcqnCpA sIgnQZGKimMbynioDEqFptcqnCpA2;
					if (MdtBuSCMoluJazYCCiokIhZIbEWh == -2 && hiEZIFZFJQQJoDlcsRWnbqZxfGQm == Environment.CurrentManagedThreadId)
					{
						MdtBuSCMoluJazYCCiokIhZIbEWh = 0;
						sIgnQZGKimMbynioDEqFptcqnCpA2 = this;
					}
					else
					{
						sIgnQZGKimMbynioDEqFptcqnCpA2 = new sIgnQZGKimMbynioDEqFptcqnCpA(0);
						sIgnQZGKimMbynioDEqFptcqnCpA2.PlImTxLXVoqoxwkunPBqkllXeliP = PlImTxLXVoqoxwkunPBqkllXeliP;
					}
					return sIgnQZGKimMbynioDEqFptcqnCpA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class QZzIfGpCMsJErBPUlQQFIvAmMSfC : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int AhgWymSfYopdgJfBAwAHWlOTGpyC;

				private Button NDlqmmxnHvUlyclVfEuzfpJHLJoc;

				private int QhXAsehEMbARSThuNDazDLSHiTTL;

				public Platform_XInput_Base EXvCFqCJLkNPEbNnmlHQIZzfeakfc;

				private int PvLFXzawwMeikCkLDyjyuIwMxPHDB;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return NDlqmmxnHvUlyclVfEuzfpJHLJoc;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return NDlqmmxnHvUlyclVfEuzfpJHLJoc;
					}
				}

				[DebuggerHidden]
				public QZzIfGpCMsJErBPUlQQFIvAmMSfC(int P_0)
				{
					AhgWymSfYopdgJfBAwAHWlOTGpyC = P_0;
					QhXAsehEMbARSThuNDazDLSHiTTL = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					AhgWymSfYopdgJfBAwAHWlOTGpyC = -2;
				}

				private bool MoveNext()
				{
					int ahgWymSfYopdgJfBAwAHWlOTGpyC = AhgWymSfYopdgJfBAwAHWlOTGpyC;
					Platform_XInput_Base eXvCFqCJLkNPEbNnmlHQIZzfeakfc = EXvCFqCJLkNPEbNnmlHQIZzfeakfc;
					switch (ahgWymSfYopdgJfBAwAHWlOTGpyC)
					{
					default:
						return false;
					case 0:
						AhgWymSfYopdgJfBAwAHWlOTGpyC = -1;
						if (eXvCFqCJLkNPEbNnmlHQIZzfeakfc.elements == null || eXvCFqCJLkNPEbNnmlHQIZzfeakfc.elements.buttons == null)
						{
							return false;
						}
						PvLFXzawwMeikCkLDyjyuIwMxPHDB = 0;
						break;
					case 1:
						AhgWymSfYopdgJfBAwAHWlOTGpyC = -1;
						PvLFXzawwMeikCkLDyjyuIwMxPHDB++;
						break;
					}
					if (PvLFXzawwMeikCkLDyjyuIwMxPHDB < eXvCFqCJLkNPEbNnmlHQIZzfeakfc.elements.buttons.Length)
					{
						NDlqmmxnHvUlyclVfEuzfpJHLJoc = eXvCFqCJLkNPEbNnmlHQIZzfeakfc.elements.buttons[PvLFXzawwMeikCkLDyjyuIwMxPHDB];
						AhgWymSfYopdgJfBAwAHWlOTGpyC = 1;
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
					QZzIfGpCMsJErBPUlQQFIvAmMSfC qZzIfGpCMsJErBPUlQQFIvAmMSfC;
					if (AhgWymSfYopdgJfBAwAHWlOTGpyC == -2 && QhXAsehEMbARSThuNDazDLSHiTTL == Environment.CurrentManagedThreadId)
					{
						AhgWymSfYopdgJfBAwAHWlOTGpyC = 0;
						qZzIfGpCMsJErBPUlQQFIvAmMSfC = this;
					}
					else
					{
						qZzIfGpCMsJErBPUlQQFIvAmMSfC = new QZzIfGpCMsJErBPUlQQFIvAmMSfC(0);
						qZzIfGpCMsJErBPUlQQFIvAmMSfC.EXvCFqCJLkNPEbNnmlHQIZzfeakfc = EXvCFqCJLkNPEbNnmlHQIZzfeakfc;
					}
					return qZzIfGpCMsJErBPUlQQFIvAmMSfC;
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

			[IteratorStateMachine(typeof(sIgnQZGKimMbynioDEqFptcqnCpA))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new sIgnQZGKimMbynioDEqFptcqnCpA(-2)
				{
					PlImTxLXVoqoxwkunPBqkllXeliP = this
				};
			}

			[IteratorStateMachine(typeof(QZzIfGpCMsJErBPUlQQFIvAmMSfC))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new QZzIfGpCMsJErBPUlQQFIvAmMSfC(-2)
				{
					EXvCFqCJLkNPEbNnmlHQIZzfeakfc = this
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
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
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
						qJZagAZjhaLZbLstuZlIbkTalFLE(elementCount);
						return elementCount;
					}

					internal void caOdlVQPSWiYblzmSxQpPAsycgux(ElementCount_Base P_0)
					{
						base.qJZagAZjhaLZbLstuZlIbkTalFLE(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool GRgkmxwGEYnEjzflgBQoPDZUkLIv(BridgedControllerHWInfo P_0)
					{
						if (!base.ZvIfrZHlPaocCwcPMJBmtNPEjEjM(P_0))
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
				private sealed class JUyTJWxaNFCnNcJUQeIjqJevzJZX : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int jICctRyAZByyPnoVRDeARAhsiKQB;

					private Axis qMwCAmEPNxXugbTFqBabuodMYrXKA;

					private int xEIFbcfrrnAuobOeLWcZUmxAbQRKA;

					public Elements TEniFmaZCZPekiJLQsQUybTGxMxF;

					private Axis[] iucjUjpToUlSwKjsINEhkNKYcLdc;

					private int lzWicLWjScgpqcUCGFXUwaDDMApj;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return qMwCAmEPNxXugbTFqBabuodMYrXKA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return qMwCAmEPNxXugbTFqBabuodMYrXKA;
						}
					}

					[DebuggerHidden]
					public JUyTJWxaNFCnNcJUQeIjqJevzJZX(int P_0)
					{
						jICctRyAZByyPnoVRDeARAhsiKQB = P_0;
						xEIFbcfrrnAuobOeLWcZUmxAbQRKA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						iucjUjpToUlSwKjsINEhkNKYcLdc = null;
						jICctRyAZByyPnoVRDeARAhsiKQB = -2;
					}

					private bool MoveNext()
					{
						int num = jICctRyAZByyPnoVRDeARAhsiKQB;
						Elements tEniFmaZCZPekiJLQsQUybTGxMxF = TEniFmaZCZPekiJLQsQUybTGxMxF;
						switch (num)
						{
						default:
							return false;
						case 0:
							jICctRyAZByyPnoVRDeARAhsiKQB = -1;
							if (tEniFmaZCZPekiJLQsQUybTGxMxF.axes == null)
							{
								return false;
							}
							iucjUjpToUlSwKjsINEhkNKYcLdc = tEniFmaZCZPekiJLQsQUybTGxMxF.axes;
							lzWicLWjScgpqcUCGFXUwaDDMApj = 0;
							break;
						case 1:
							jICctRyAZByyPnoVRDeARAhsiKQB = -1;
							lzWicLWjScgpqcUCGFXUwaDDMApj++;
							break;
						}
						if (lzWicLWjScgpqcUCGFXUwaDDMApj < iucjUjpToUlSwKjsINEhkNKYcLdc.Length)
						{
							Axis axis = iucjUjpToUlSwKjsINEhkNKYcLdc[lzWicLWjScgpqcUCGFXUwaDDMApj];
							qMwCAmEPNxXugbTFqBabuodMYrXKA = axis;
							jICctRyAZByyPnoVRDeARAhsiKQB = 1;
							return true;
						}
						iucjUjpToUlSwKjsINEhkNKYcLdc = null;
						return false;
					}

					bool IEnumerator.MoveNext()
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
						JUyTJWxaNFCnNcJUQeIjqJevzJZX jUyTJWxaNFCnNcJUQeIjqJevzJZX;
						if (jICctRyAZByyPnoVRDeARAhsiKQB == -2 && xEIFbcfrrnAuobOeLWcZUmxAbQRKA == Environment.CurrentManagedThreadId)
						{
							jICctRyAZByyPnoVRDeARAhsiKQB = 0;
							jUyTJWxaNFCnNcJUQeIjqJevzJZX = this;
						}
						else
						{
							jUyTJWxaNFCnNcJUQeIjqJevzJZX = new JUyTJWxaNFCnNcJUQeIjqJevzJZX(0);
							jUyTJWxaNFCnNcJUQeIjqJevzJZX.TEniFmaZCZPekiJLQsQUybTGxMxF = TEniFmaZCZPekiJLQsQUybTGxMxF;
						}
						return jUyTJWxaNFCnNcJUQeIjqJevzJZX;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class cnixIqmGrmpgaprlVxMhwQmAQvHK : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int lxKgYjNxZWDidnEgntdPkFyGeqfaA;

					private Button QBRzxcThFttcTjHIrFbugOHQsthAA;

					private int psbljVLifRxhEuGrgyvgsmyHaiSH;

					public Elements miheToesCjkJCHxaJLwLIEzvjFfM;

					private Button[] DFqIcpoQmBcBYHamTbRlxIsnqzGy;

					private int uKhbflfTZpFFaxRCHSsWcVPOntTu;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return QBRzxcThFttcTjHIrFbugOHQsthAA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return QBRzxcThFttcTjHIrFbugOHQsthAA;
						}
					}

					[DebuggerHidden]
					public cnixIqmGrmpgaprlVxMhwQmAQvHK(int P_0)
					{
						lxKgYjNxZWDidnEgntdPkFyGeqfaA = P_0;
						psbljVLifRxhEuGrgyvgsmyHaiSH = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						DFqIcpoQmBcBYHamTbRlxIsnqzGy = null;
						lxKgYjNxZWDidnEgntdPkFyGeqfaA = -2;
					}

					private bool MoveNext()
					{
						int num = lxKgYjNxZWDidnEgntdPkFyGeqfaA;
						Elements elements = miheToesCjkJCHxaJLwLIEzvjFfM;
						switch (num)
						{
						default:
							return false;
						case 0:
							lxKgYjNxZWDidnEgntdPkFyGeqfaA = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							DFqIcpoQmBcBYHamTbRlxIsnqzGy = elements.buttons;
							uKhbflfTZpFFaxRCHSsWcVPOntTu = 0;
							break;
						case 1:
							lxKgYjNxZWDidnEgntdPkFyGeqfaA = -1;
							uKhbflfTZpFFaxRCHSsWcVPOntTu++;
							break;
						}
						if (uKhbflfTZpFFaxRCHSsWcVPOntTu < DFqIcpoQmBcBYHamTbRlxIsnqzGy.Length)
						{
							Button qBRzxcThFttcTjHIrFbugOHQsthAA = DFqIcpoQmBcBYHamTbRlxIsnqzGy[uKhbflfTZpFFaxRCHSsWcVPOntTu];
							QBRzxcThFttcTjHIrFbugOHQsthAA = qBRzxcThFttcTjHIrFbugOHQsthAA;
							lxKgYjNxZWDidnEgntdPkFyGeqfaA = 1;
							return true;
						}
						DFqIcpoQmBcBYHamTbRlxIsnqzGy = null;
						return false;
					}

					bool IEnumerator.MoveNext()
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
						cnixIqmGrmpgaprlVxMhwQmAQvHK cnixIqmGrmpgaprlVxMhwQmAQvHK2;
						if (lxKgYjNxZWDidnEgntdPkFyGeqfaA == -2 && psbljVLifRxhEuGrgyvgsmyHaiSH == Environment.CurrentManagedThreadId)
						{
							lxKgYjNxZWDidnEgntdPkFyGeqfaA = 0;
							cnixIqmGrmpgaprlVxMhwQmAQvHK2 = this;
						}
						else
						{
							cnixIqmGrmpgaprlVxMhwQmAQvHK2 = new cnixIqmGrmpgaprlVxMhwQmAQvHK(0);
							cnixIqmGrmpgaprlVxMhwQmAQvHK2.miheToesCjkJCHxaJLwLIEzvjFfM = miheToesCjkJCHxaJLwLIEzvjFfM;
						}
						return cnixIqmGrmpgaprlVxMhwQmAQvHK2;
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

				[IteratorStateMachine(typeof(JUyTJWxaNFCnNcJUQeIjqJevzJZX))]
				public IEnumerable<Axis> IterateAxes()
				{
					return new JUyTJWxaNFCnNcJUQeIjqJevzJZX(-2)
					{
						TEniFmaZCZPekiJLQsQUybTGxMxF = this
					};
				}

				[IteratorStateMachine(typeof(cnixIqmGrmpgaprlVxMhwQmAQvHK))]
				public IEnumerable<Button> IterateButtons()
				{
					return new cnixIqmGrmpgaprlVxMhwQmAQvHK(-2)
					{
						miheToesCjkJCHxaJLwLIEzvjFfM = this
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

				public float axisUpperDeadZone;

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
						axisUpperDeadZone = axisUpperDeadZone,
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

			private sealed class zdktgMPFDXbZiBLWEeUBhiHmlYrqA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int ulFSzdCSrwecTBtMFhezFkXxEgAHA;

				private Axis EAeNEJKdDrfuREoEdxojzFWoGvOl;

				private int zGxnoxHSMBiXznevmHkiTTyJTpzX;

				public Platform_OSX_Base MDOStHrjTAtLzujMhBIplOWIuomv;

				private int OFZkRGXjGJRqXOHWBxhvCdAvbMkI;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return EAeNEJKdDrfuREoEdxojzFWoGvOl;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return EAeNEJKdDrfuREoEdxojzFWoGvOl;
					}
				}

				[DebuggerHidden]
				public zdktgMPFDXbZiBLWEeUBhiHmlYrqA(int P_0)
				{
					ulFSzdCSrwecTBtMFhezFkXxEgAHA = P_0;
					zGxnoxHSMBiXznevmHkiTTyJTpzX = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					ulFSzdCSrwecTBtMFhezFkXxEgAHA = -2;
				}

				private bool MoveNext()
				{
					int num = ulFSzdCSrwecTBtMFhezFkXxEgAHA;
					Platform_OSX_Base mDOStHrjTAtLzujMhBIplOWIuomv = MDOStHrjTAtLzujMhBIplOWIuomv;
					switch (num)
					{
					default:
						return false;
					case 0:
						ulFSzdCSrwecTBtMFhezFkXxEgAHA = -1;
						if (mDOStHrjTAtLzujMhBIplOWIuomv.elements == null || mDOStHrjTAtLzujMhBIplOWIuomv.elements.axes == null)
						{
							return false;
						}
						OFZkRGXjGJRqXOHWBxhvCdAvbMkI = 0;
						break;
					case 1:
						ulFSzdCSrwecTBtMFhezFkXxEgAHA = -1;
						OFZkRGXjGJRqXOHWBxhvCdAvbMkI++;
						break;
					}
					if (OFZkRGXjGJRqXOHWBxhvCdAvbMkI < mDOStHrjTAtLzujMhBIplOWIuomv.elements.axes.Length)
					{
						EAeNEJKdDrfuREoEdxojzFWoGvOl = mDOStHrjTAtLzujMhBIplOWIuomv.elements.axes[OFZkRGXjGJRqXOHWBxhvCdAvbMkI];
						ulFSzdCSrwecTBtMFhezFkXxEgAHA = 1;
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
					zdktgMPFDXbZiBLWEeUBhiHmlYrqA zdktgMPFDXbZiBLWEeUBhiHmlYrqA2;
					if (ulFSzdCSrwecTBtMFhezFkXxEgAHA == -2 && zGxnoxHSMBiXznevmHkiTTyJTpzX == Environment.CurrentManagedThreadId)
					{
						ulFSzdCSrwecTBtMFhezFkXxEgAHA = 0;
						zdktgMPFDXbZiBLWEeUBhiHmlYrqA2 = this;
					}
					else
					{
						zdktgMPFDXbZiBLWEeUBhiHmlYrqA2 = new zdktgMPFDXbZiBLWEeUBhiHmlYrqA(0);
						zdktgMPFDXbZiBLWEeUBhiHmlYrqA2.MDOStHrjTAtLzujMhBIplOWIuomv = MDOStHrjTAtLzujMhBIplOWIuomv;
					}
					return zdktgMPFDXbZiBLWEeUBhiHmlYrqA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class jebytVEWfgOHtVaIvFQPnXlnuepV : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int FrhoxfmhRuAPVWEXPhsyVhuAnIjm;

				private Button gISIWqTRHMMjDPDfDVvMAQlOvwnE;

				private int UrfxRGGHdDJxFeBflhNuafbCnWIkA;

				public Platform_OSX_Base rxhgKQEqEqRQLGCfOMBYjsBZKkH;

				private int XXFSuyociMKBFjMBtvBJNFhFCoHG;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return gISIWqTRHMMjDPDfDVvMAQlOvwnE;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return gISIWqTRHMMjDPDfDVvMAQlOvwnE;
					}
				}

				[DebuggerHidden]
				public jebytVEWfgOHtVaIvFQPnXlnuepV(int P_0)
				{
					FrhoxfmhRuAPVWEXPhsyVhuAnIjm = P_0;
					UrfxRGGHdDJxFeBflhNuafbCnWIkA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					FrhoxfmhRuAPVWEXPhsyVhuAnIjm = -2;
				}

				private bool MoveNext()
				{
					int frhoxfmhRuAPVWEXPhsyVhuAnIjm = FrhoxfmhRuAPVWEXPhsyVhuAnIjm;
					Platform_OSX_Base platform_OSX_Base = rxhgKQEqEqRQLGCfOMBYjsBZKkH;
					switch (frhoxfmhRuAPVWEXPhsyVhuAnIjm)
					{
					default:
						return false;
					case 0:
						FrhoxfmhRuAPVWEXPhsyVhuAnIjm = -1;
						if (platform_OSX_Base.elements == null || platform_OSX_Base.elements.buttons == null)
						{
							return false;
						}
						XXFSuyociMKBFjMBtvBJNFhFCoHG = 0;
						break;
					case 1:
						FrhoxfmhRuAPVWEXPhsyVhuAnIjm = -1;
						XXFSuyociMKBFjMBtvBJNFhFCoHG++;
						break;
					}
					if (XXFSuyociMKBFjMBtvBJNFhFCoHG < platform_OSX_Base.elements.buttons.Length)
					{
						gISIWqTRHMMjDPDfDVvMAQlOvwnE = platform_OSX_Base.elements.buttons[XXFSuyociMKBFjMBtvBJNFhFCoHG];
						FrhoxfmhRuAPVWEXPhsyVhuAnIjm = 1;
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
					jebytVEWfgOHtVaIvFQPnXlnuepV jebytVEWfgOHtVaIvFQPnXlnuepV2;
					if (FrhoxfmhRuAPVWEXPhsyVhuAnIjm == -2 && UrfxRGGHdDJxFeBflhNuafbCnWIkA == Environment.CurrentManagedThreadId)
					{
						FrhoxfmhRuAPVWEXPhsyVhuAnIjm = 0;
						jebytVEWfgOHtVaIvFQPnXlnuepV2 = this;
					}
					else
					{
						jebytVEWfgOHtVaIvFQPnXlnuepV2 = new jebytVEWfgOHtVaIvFQPnXlnuepV(0);
						jebytVEWfgOHtVaIvFQPnXlnuepV2.rxhgKQEqEqRQLGCfOMBYjsBZKkH = rxhgKQEqEqRQLGCfOMBYjsBZKkH;
					}
					return jebytVEWfgOHtVaIvFQPnXlnuepV2;
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

			[IteratorStateMachine(typeof(zdktgMPFDXbZiBLWEeUBhiHmlYrqA))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new zdktgMPFDXbZiBLWEeUBhiHmlYrqA(-2)
				{
					MDOStHrjTAtLzujMhBIplOWIuomv = this
				};
			}

			[IteratorStateMachine(typeof(jebytVEWfgOHtVaIvFQPnXlnuepV))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new jebytVEWfgOHtVaIvFQPnXlnuepV(-2)
				{
					rxhgKQEqEqRQLGCfOMBYjsBZKkH = this
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
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
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
						qJZagAZjhaLZbLstuZlIbkTalFLE(elementCount);
						return elementCount;
					}

					internal void RXQItRrasXZEDkLTuJfUUOrRoBLu(ElementCount_Base P_0)
					{
						base.qJZagAZjhaLZbLstuZlIbkTalFLE(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool FxQFXIbIzCxPWABsTUXyjgMwObAEA(BridgedControllerHWInfo P_0)
					{
						if (!base.ZvIfrZHlPaocCwcPMJBmtNPEjEjM(P_0))
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
				private sealed class LUAvsnxLGycsCjtfNkFTILVEuxovA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int FEEyvIVNWNFMMAlsIVAmtVQhmEhI;

					private Axis NgKywrLMHCGTbZuujmEncsbnPWZQ;

					private int xaGVynCGTeIvplpOAHzfyJEqlCsy;

					public Elements OKBgXZtvEckJIKQufuviqiiFmmxG;

					private int yKPIBYHeCvhSjKaPURsmDEslidmYA;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return NgKywrLMHCGTbZuujmEncsbnPWZQ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return NgKywrLMHCGTbZuujmEncsbnPWZQ;
						}
					}

					[DebuggerHidden]
					public LUAvsnxLGycsCjtfNkFTILVEuxovA(int P_0)
					{
						FEEyvIVNWNFMMAlsIVAmtVQhmEhI = P_0;
						xaGVynCGTeIvplpOAHzfyJEqlCsy = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						FEEyvIVNWNFMMAlsIVAmtVQhmEhI = -2;
					}

					private bool MoveNext()
					{
						int fEEyvIVNWNFMMAlsIVAmtVQhmEhI = FEEyvIVNWNFMMAlsIVAmtVQhmEhI;
						Elements oKBgXZtvEckJIKQufuviqiiFmmxG = OKBgXZtvEckJIKQufuviqiiFmmxG;
						switch (fEEyvIVNWNFMMAlsIVAmtVQhmEhI)
						{
						default:
							return false;
						case 0:
							FEEyvIVNWNFMMAlsIVAmtVQhmEhI = -1;
							if (oKBgXZtvEckJIKQufuviqiiFmmxG.axes == null)
							{
								return false;
							}
							yKPIBYHeCvhSjKaPURsmDEslidmYA = 0;
							break;
						case 1:
							FEEyvIVNWNFMMAlsIVAmtVQhmEhI = -1;
							yKPIBYHeCvhSjKaPURsmDEslidmYA++;
							break;
						}
						if (yKPIBYHeCvhSjKaPURsmDEslidmYA < oKBgXZtvEckJIKQufuviqiiFmmxG.axes.Length)
						{
							NgKywrLMHCGTbZuujmEncsbnPWZQ = oKBgXZtvEckJIKQufuviqiiFmmxG.axes[yKPIBYHeCvhSjKaPURsmDEslidmYA];
							FEEyvIVNWNFMMAlsIVAmtVQhmEhI = 1;
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
						LUAvsnxLGycsCjtfNkFTILVEuxovA lUAvsnxLGycsCjtfNkFTILVEuxovA;
						if (FEEyvIVNWNFMMAlsIVAmtVQhmEhI == -2 && xaGVynCGTeIvplpOAHzfyJEqlCsy == Environment.CurrentManagedThreadId)
						{
							FEEyvIVNWNFMMAlsIVAmtVQhmEhI = 0;
							lUAvsnxLGycsCjtfNkFTILVEuxovA = this;
						}
						else
						{
							lUAvsnxLGycsCjtfNkFTILVEuxovA = new LUAvsnxLGycsCjtfNkFTILVEuxovA(0);
							lUAvsnxLGycsCjtfNkFTILVEuxovA.OKBgXZtvEckJIKQufuviqiiFmmxG = OKBgXZtvEckJIKQufuviqiiFmmxG;
						}
						return lUAvsnxLGycsCjtfNkFTILVEuxovA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class wQtMKfxgRpDvXFrbmHYtYmvRyfDqA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int OQpZETLhbCarRxupkWejPukEJTTC;

					private Button hEHjMYfJeOoNROoIjqwtaFKUIzggb;

					private int TQeyDKHpSIYquCHHICskIBCCXHtsA;

					public Elements bupdzCGbClhAtGoRvneqMsjSPFiq;

					private int HuAQQwbefMfYMdKHSoXxwQACqZdoA;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return hEHjMYfJeOoNROoIjqwtaFKUIzggb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return hEHjMYfJeOoNROoIjqwtaFKUIzggb;
						}
					}

					[DebuggerHidden]
					public wQtMKfxgRpDvXFrbmHYtYmvRyfDqA(int P_0)
					{
						OQpZETLhbCarRxupkWejPukEJTTC = P_0;
						TQeyDKHpSIYquCHHICskIBCCXHtsA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						OQpZETLhbCarRxupkWejPukEJTTC = -2;
					}

					private bool MoveNext()
					{
						int oQpZETLhbCarRxupkWejPukEJTTC = OQpZETLhbCarRxupkWejPukEJTTC;
						Elements elements = bupdzCGbClhAtGoRvneqMsjSPFiq;
						switch (oQpZETLhbCarRxupkWejPukEJTTC)
						{
						default:
							return false;
						case 0:
							OQpZETLhbCarRxupkWejPukEJTTC = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							HuAQQwbefMfYMdKHSoXxwQACqZdoA = 0;
							break;
						case 1:
							OQpZETLhbCarRxupkWejPukEJTTC = -1;
							HuAQQwbefMfYMdKHSoXxwQACqZdoA++;
							break;
						}
						if (HuAQQwbefMfYMdKHSoXxwQACqZdoA < elements.buttons.Length)
						{
							hEHjMYfJeOoNROoIjqwtaFKUIzggb = elements.buttons[HuAQQwbefMfYMdKHSoXxwQACqZdoA];
							OQpZETLhbCarRxupkWejPukEJTTC = 1;
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
						wQtMKfxgRpDvXFrbmHYtYmvRyfDqA wQtMKfxgRpDvXFrbmHYtYmvRyfDqA2;
						if (OQpZETLhbCarRxupkWejPukEJTTC == -2 && TQeyDKHpSIYquCHHICskIBCCXHtsA == Environment.CurrentManagedThreadId)
						{
							OQpZETLhbCarRxupkWejPukEJTTC = 0;
							wQtMKfxgRpDvXFrbmHYtYmvRyfDqA2 = this;
						}
						else
						{
							wQtMKfxgRpDvXFrbmHYtYmvRyfDqA2 = new wQtMKfxgRpDvXFrbmHYtYmvRyfDqA(0);
							wQtMKfxgRpDvXFrbmHYtYmvRyfDqA2.bupdzCGbClhAtGoRvneqMsjSPFiq = bupdzCGbClhAtGoRvneqMsjSPFiq;
						}
						return wQtMKfxgRpDvXFrbmHYtYmvRyfDqA2;
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
					[IteratorStateMachine(typeof(LUAvsnxLGycsCjtfNkFTILVEuxovA))]
					get
					{
						return new LUAvsnxLGycsCjtfNkFTILVEuxovA(-2)
						{
							OKBgXZtvEckJIKQufuviqiiFmmxG = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(wQtMKfxgRpDvXFrbmHYtYmvRyfDqA))]
					get
					{
						return new wQtMKfxgRpDvXFrbmHYtYmvRyfDqA(-2)
						{
							bupdzCGbClhAtGoRvneqMsjSPFiq = this
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

				public float axisUpperDeadZone;

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
						axisUpperDeadZone = axis.axisUpperDeadZone;
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

			private sealed class IfudxqNUYovUExqboiwrwlKDQSAp : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int pREWUfSRagFVsVvNjJZWjCmYDDsjA;

				private Axis JtkdoVqmDUWXscwauMMuJxidUJnJ;

				private int utFabOHSSSpGgDhdKdoatmNIJdPFb;

				public Platform_Linux_Base lxrLQnBsPdCQCVDsOSASTeQAKzwT;

				private int bByUyIOWeETbLvJDjgKnjEfBIDeq;

				private int rcohvLbvHKnvrtMPUNxduYFCxBKKA;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return JtkdoVqmDUWXscwauMMuJxidUJnJ;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return JtkdoVqmDUWXscwauMMuJxidUJnJ;
					}
				}

				[DebuggerHidden]
				public IfudxqNUYovUExqboiwrwlKDQSAp(int P_0)
				{
					pREWUfSRagFVsVvNjJZWjCmYDDsjA = P_0;
					utFabOHSSSpGgDhdKdoatmNIJdPFb = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					pREWUfSRagFVsVvNjJZWjCmYDDsjA = -2;
				}

				private bool MoveNext()
				{
					int num = pREWUfSRagFVsVvNjJZWjCmYDDsjA;
					Platform_Linux_Base platform_Linux_Base = lxrLQnBsPdCQCVDsOSASTeQAKzwT;
					switch (num)
					{
					default:
						return false;
					case 0:
						pREWUfSRagFVsVvNjJZWjCmYDDsjA = -1;
						if (platform_Linux_Base.elements == null || platform_Linux_Base.elements.axes == null)
						{
							return false;
						}
						bByUyIOWeETbLvJDjgKnjEfBIDeq = platform_Linux_Base.elements.axes.Length;
						rcohvLbvHKnvrtMPUNxduYFCxBKKA = 0;
						break;
					case 1:
						pREWUfSRagFVsVvNjJZWjCmYDDsjA = -1;
						rcohvLbvHKnvrtMPUNxduYFCxBKKA++;
						break;
					}
					if (rcohvLbvHKnvrtMPUNxduYFCxBKKA < bByUyIOWeETbLvJDjgKnjEfBIDeq)
					{
						JtkdoVqmDUWXscwauMMuJxidUJnJ = platform_Linux_Base.elements.axes[rcohvLbvHKnvrtMPUNxduYFCxBKKA];
						pREWUfSRagFVsVvNjJZWjCmYDDsjA = 1;
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
					IfudxqNUYovUExqboiwrwlKDQSAp ifudxqNUYovUExqboiwrwlKDQSAp;
					if (pREWUfSRagFVsVvNjJZWjCmYDDsjA == -2 && utFabOHSSSpGgDhdKdoatmNIJdPFb == Environment.CurrentManagedThreadId)
					{
						pREWUfSRagFVsVvNjJZWjCmYDDsjA = 0;
						ifudxqNUYovUExqboiwrwlKDQSAp = this;
					}
					else
					{
						ifudxqNUYovUExqboiwrwlKDQSAp = new IfudxqNUYovUExqboiwrwlKDQSAp(0);
						ifudxqNUYovUExqboiwrwlKDQSAp.lxrLQnBsPdCQCVDsOSASTeQAKzwT = lxrLQnBsPdCQCVDsOSASTeQAKzwT;
					}
					return ifudxqNUYovUExqboiwrwlKDQSAp;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class AJvTaywalqQGdONGqXyjQbEDbALBA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int ovIXkARavSauACdgqIiwaKWbVRCs;

				private Button spQhmzDCuioLKWQMobhIeoysIXBk;

				private int tbmEeiHfZdtiMbXxBQRXrkLjTHJMA;

				public Platform_Linux_Base AasvHFpEHEXSKLEOzyuEOiwmxIvS;

				private int QmrZbYJgZkzgWLPAdGGFHmfhwzWh;

				private int VRqckJJDhOXcMaQjjhtTQltzzkXx;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return spQhmzDCuioLKWQMobhIeoysIXBk;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return spQhmzDCuioLKWQMobhIeoysIXBk;
					}
				}

				[DebuggerHidden]
				public AJvTaywalqQGdONGqXyjQbEDbALBA(int P_0)
				{
					ovIXkARavSauACdgqIiwaKWbVRCs = P_0;
					tbmEeiHfZdtiMbXxBQRXrkLjTHJMA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					ovIXkARavSauACdgqIiwaKWbVRCs = -2;
				}

				private bool MoveNext()
				{
					int num = ovIXkARavSauACdgqIiwaKWbVRCs;
					Platform_Linux_Base aasvHFpEHEXSKLEOzyuEOiwmxIvS = AasvHFpEHEXSKLEOzyuEOiwmxIvS;
					switch (num)
					{
					default:
						return false;
					case 0:
						ovIXkARavSauACdgqIiwaKWbVRCs = -1;
						if (aasvHFpEHEXSKLEOzyuEOiwmxIvS.elements == null || aasvHFpEHEXSKLEOzyuEOiwmxIvS.elements.buttons == null)
						{
							return false;
						}
						QmrZbYJgZkzgWLPAdGGFHmfhwzWh = aasvHFpEHEXSKLEOzyuEOiwmxIvS.elements.buttons.Length;
						VRqckJJDhOXcMaQjjhtTQltzzkXx = 0;
						break;
					case 1:
						ovIXkARavSauACdgqIiwaKWbVRCs = -1;
						VRqckJJDhOXcMaQjjhtTQltzzkXx++;
						break;
					}
					if (VRqckJJDhOXcMaQjjhtTQltzzkXx < QmrZbYJgZkzgWLPAdGGFHmfhwzWh)
					{
						spQhmzDCuioLKWQMobhIeoysIXBk = aasvHFpEHEXSKLEOzyuEOiwmxIvS.elements.buttons[VRqckJJDhOXcMaQjjhtTQltzzkXx];
						ovIXkARavSauACdgqIiwaKWbVRCs = 1;
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
					AJvTaywalqQGdONGqXyjQbEDbALBA aJvTaywalqQGdONGqXyjQbEDbALBA;
					if (ovIXkARavSauACdgqIiwaKWbVRCs == -2 && tbmEeiHfZdtiMbXxBQRXrkLjTHJMA == Environment.CurrentManagedThreadId)
					{
						ovIXkARavSauACdgqIiwaKWbVRCs = 0;
						aJvTaywalqQGdONGqXyjQbEDbALBA = this;
					}
					else
					{
						aJvTaywalqQGdONGqXyjQbEDbALBA = new AJvTaywalqQGdONGqXyjQbEDbALBA(0);
						aJvTaywalqQGdONGqXyjQbEDbALBA.AasvHFpEHEXSKLEOzyuEOiwmxIvS = AasvHFpEHEXSKLEOzyuEOiwmxIvS;
					}
					return aJvTaywalqQGdONGqXyjQbEDbALBA;
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
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
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

			[IteratorStateMachine(typeof(IfudxqNUYovUExqboiwrwlKDQSAp))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new IfudxqNUYovUExqboiwrwlKDQSAp(-2)
				{
					lxrLQnBsPdCQCVDsOSASTeQAKzwT = this
				};
			}

			[IteratorStateMachine(typeof(AJvTaywalqQGdONGqXyjQbEDbALBA))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new AJvTaywalqQGdONGqXyjQbEDbALBA(-2)
				{
					AasvHFpEHEXSKLEOzyuEOiwmxIvS = this
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
						qJZagAZjhaLZbLstuZlIbkTalFLE(elementCount);
						return elementCount;
					}

					internal void MAkQpimmyQtcvxAZTuLHXBhKBMmjA(ElementCount_Base P_0)
					{
						base.qJZagAZjhaLZbLstuZlIbkTalFLE(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool ZiwPVrvYFSSsUOJTKJYqjwJVVtLH(BridgedControllerHWInfo P_0)
					{
						if (!base.ZvIfrZHlPaocCwcPMJBmtNPEjEjM(P_0))
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
				private sealed class GyzcqTfrMYkAjhWSVXpqzGPlVbrB : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int JWqMpvzCPtNppwWkOcQjyXNUwadc;

					private Axis YdKxOuOdrUeRfGtsnEdrucAMoBDdA;

					private int RVDCRSvgcGARdqCOWAmdAPImmjqGA;

					public Elements HPbEQJAjppbiCXLHeXPpUfLxKlpOA;

					private int SEMHJCeJoGbldXyswfesFmNCHtqoA;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return YdKxOuOdrUeRfGtsnEdrucAMoBDdA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return YdKxOuOdrUeRfGtsnEdrucAMoBDdA;
						}
					}

					[DebuggerHidden]
					public GyzcqTfrMYkAjhWSVXpqzGPlVbrB(int P_0)
					{
						JWqMpvzCPtNppwWkOcQjyXNUwadc = P_0;
						RVDCRSvgcGARdqCOWAmdAPImmjqGA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						JWqMpvzCPtNppwWkOcQjyXNUwadc = -2;
					}

					private bool MoveNext()
					{
						int jWqMpvzCPtNppwWkOcQjyXNUwadc = JWqMpvzCPtNppwWkOcQjyXNUwadc;
						Elements hPbEQJAjppbiCXLHeXPpUfLxKlpOA = HPbEQJAjppbiCXLHeXPpUfLxKlpOA;
						switch (jWqMpvzCPtNppwWkOcQjyXNUwadc)
						{
						default:
							return false;
						case 0:
							JWqMpvzCPtNppwWkOcQjyXNUwadc = -1;
							if (hPbEQJAjppbiCXLHeXPpUfLxKlpOA.axes == null)
							{
								return false;
							}
							SEMHJCeJoGbldXyswfesFmNCHtqoA = 0;
							break;
						case 1:
							JWqMpvzCPtNppwWkOcQjyXNUwadc = -1;
							SEMHJCeJoGbldXyswfesFmNCHtqoA++;
							break;
						}
						if (SEMHJCeJoGbldXyswfesFmNCHtqoA < hPbEQJAjppbiCXLHeXPpUfLxKlpOA.axes.Length)
						{
							YdKxOuOdrUeRfGtsnEdrucAMoBDdA = hPbEQJAjppbiCXLHeXPpUfLxKlpOA.axes[SEMHJCeJoGbldXyswfesFmNCHtqoA];
							JWqMpvzCPtNppwWkOcQjyXNUwadc = 1;
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
						GyzcqTfrMYkAjhWSVXpqzGPlVbrB gyzcqTfrMYkAjhWSVXpqzGPlVbrB;
						if (JWqMpvzCPtNppwWkOcQjyXNUwadc == -2 && RVDCRSvgcGARdqCOWAmdAPImmjqGA == Environment.CurrentManagedThreadId)
						{
							JWqMpvzCPtNppwWkOcQjyXNUwadc = 0;
							gyzcqTfrMYkAjhWSVXpqzGPlVbrB = this;
						}
						else
						{
							gyzcqTfrMYkAjhWSVXpqzGPlVbrB = new GyzcqTfrMYkAjhWSVXpqzGPlVbrB(0);
							gyzcqTfrMYkAjhWSVXpqzGPlVbrB.HPbEQJAjppbiCXLHeXPpUfLxKlpOA = HPbEQJAjppbiCXLHeXPpUfLxKlpOA;
						}
						return gyzcqTfrMYkAjhWSVXpqzGPlVbrB;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class zCiCRtTBhibzeFAYPTbxUWeXsfHCA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int sozkltpjByVCAffDAkcHfqqlBccBA;

					private Button sjkPWoAuScnNZjtPVPIaDMEsFerh;

					private int UnlFYSaIvLjamXNktqlxVqutvJoQA;

					public Elements NWrWwkPxgutNHjTEbOKXuPmbJLRgA;

					private int BfmKxNUcghtsPuvTBkiaUaqELuEV;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return sjkPWoAuScnNZjtPVPIaDMEsFerh;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return sjkPWoAuScnNZjtPVPIaDMEsFerh;
						}
					}

					[DebuggerHidden]
					public zCiCRtTBhibzeFAYPTbxUWeXsfHCA(int P_0)
					{
						sozkltpjByVCAffDAkcHfqqlBccBA = P_0;
						UnlFYSaIvLjamXNktqlxVqutvJoQA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						sozkltpjByVCAffDAkcHfqqlBccBA = -2;
					}

					private bool MoveNext()
					{
						int num = sozkltpjByVCAffDAkcHfqqlBccBA;
						Elements nWrWwkPxgutNHjTEbOKXuPmbJLRgA = NWrWwkPxgutNHjTEbOKXuPmbJLRgA;
						switch (num)
						{
						default:
							return false;
						case 0:
							sozkltpjByVCAffDAkcHfqqlBccBA = -1;
							if (nWrWwkPxgutNHjTEbOKXuPmbJLRgA.buttons == null)
							{
								return false;
							}
							BfmKxNUcghtsPuvTBkiaUaqELuEV = 0;
							break;
						case 1:
							sozkltpjByVCAffDAkcHfqqlBccBA = -1;
							BfmKxNUcghtsPuvTBkiaUaqELuEV++;
							break;
						}
						if (BfmKxNUcghtsPuvTBkiaUaqELuEV < nWrWwkPxgutNHjTEbOKXuPmbJLRgA.buttons.Length)
						{
							sjkPWoAuScnNZjtPVPIaDMEsFerh = nWrWwkPxgutNHjTEbOKXuPmbJLRgA.buttons[BfmKxNUcghtsPuvTBkiaUaqELuEV];
							sozkltpjByVCAffDAkcHfqqlBccBA = 1;
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
						zCiCRtTBhibzeFAYPTbxUWeXsfHCA zCiCRtTBhibzeFAYPTbxUWeXsfHCA2;
						if (sozkltpjByVCAffDAkcHfqqlBccBA == -2 && UnlFYSaIvLjamXNktqlxVqutvJoQA == Environment.CurrentManagedThreadId)
						{
							sozkltpjByVCAffDAkcHfqqlBccBA = 0;
							zCiCRtTBhibzeFAYPTbxUWeXsfHCA2 = this;
						}
						else
						{
							zCiCRtTBhibzeFAYPTbxUWeXsfHCA2 = new zCiCRtTBhibzeFAYPTbxUWeXsfHCA(0);
							zCiCRtTBhibzeFAYPTbxUWeXsfHCA2.NWrWwkPxgutNHjTEbOKXuPmbJLRgA = NWrWwkPxgutNHjTEbOKXuPmbJLRgA;
						}
						return zCiCRtTBhibzeFAYPTbxUWeXsfHCA2;
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
					[IteratorStateMachine(typeof(GyzcqTfrMYkAjhWSVXpqzGPlVbrB))]
					get
					{
						return new GyzcqTfrMYkAjhWSVXpqzGPlVbrB(-2)
						{
							HPbEQJAjppbiCXLHeXPpUfLxKlpOA = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(zCiCRtTBhibzeFAYPTbxUWeXsfHCA))]
					get
					{
						return new zCiCRtTBhibzeFAYPTbxUWeXsfHCA(-2)
						{
							NWrWwkPxgutNHjTEbOKXuPmbJLRgA = this
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

				public float axisUpperDeadZone;

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
						axisUpperDeadZone = axis.axisUpperDeadZone;
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

			private sealed class McFfdeWzKSLIwPiNnirZdPfvOskZ : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int TWkgVianCkwLmGHkxOSCnAkmfRYgA;

				private Axis eSvmsLHfxtPRApWYWVDUViITnGrJ;

				private int qXiawKeJiJSUGxEZqFldanJQVTIm;

				public Platform_WindowsUWP_Base etqzpdxiufwMTNcLYcYbCsbQNGsQA;

				private int VjOTiLhNryCLcWyDDdauLZoCtvQj;

				private int QWnGQTHRLWCkNdXVRAvcakgmZmiA;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return eSvmsLHfxtPRApWYWVDUViITnGrJ;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return eSvmsLHfxtPRApWYWVDUViITnGrJ;
					}
				}

				[DebuggerHidden]
				public McFfdeWzKSLIwPiNnirZdPfvOskZ(int P_0)
				{
					TWkgVianCkwLmGHkxOSCnAkmfRYgA = P_0;
					qXiawKeJiJSUGxEZqFldanJQVTIm = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					TWkgVianCkwLmGHkxOSCnAkmfRYgA = -2;
				}

				private bool MoveNext()
				{
					int tWkgVianCkwLmGHkxOSCnAkmfRYgA = TWkgVianCkwLmGHkxOSCnAkmfRYgA;
					Platform_WindowsUWP_Base platform_WindowsUWP_Base = etqzpdxiufwMTNcLYcYbCsbQNGsQA;
					switch (tWkgVianCkwLmGHkxOSCnAkmfRYgA)
					{
					default:
						return false;
					case 0:
						TWkgVianCkwLmGHkxOSCnAkmfRYgA = -1;
						if (platform_WindowsUWP_Base.elements == null || platform_WindowsUWP_Base.elements.axes == null)
						{
							return false;
						}
						VjOTiLhNryCLcWyDDdauLZoCtvQj = platform_WindowsUWP_Base.elements.axes.Length;
						QWnGQTHRLWCkNdXVRAvcakgmZmiA = 0;
						break;
					case 1:
						TWkgVianCkwLmGHkxOSCnAkmfRYgA = -1;
						QWnGQTHRLWCkNdXVRAvcakgmZmiA++;
						break;
					}
					if (QWnGQTHRLWCkNdXVRAvcakgmZmiA < VjOTiLhNryCLcWyDDdauLZoCtvQj)
					{
						eSvmsLHfxtPRApWYWVDUViITnGrJ = platform_WindowsUWP_Base.elements.axes[QWnGQTHRLWCkNdXVRAvcakgmZmiA];
						TWkgVianCkwLmGHkxOSCnAkmfRYgA = 1;
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
					McFfdeWzKSLIwPiNnirZdPfvOskZ mcFfdeWzKSLIwPiNnirZdPfvOskZ;
					if (TWkgVianCkwLmGHkxOSCnAkmfRYgA == -2 && qXiawKeJiJSUGxEZqFldanJQVTIm == Environment.CurrentManagedThreadId)
					{
						TWkgVianCkwLmGHkxOSCnAkmfRYgA = 0;
						mcFfdeWzKSLIwPiNnirZdPfvOskZ = this;
					}
					else
					{
						mcFfdeWzKSLIwPiNnirZdPfvOskZ = new McFfdeWzKSLIwPiNnirZdPfvOskZ(0);
						mcFfdeWzKSLIwPiNnirZdPfvOskZ.etqzpdxiufwMTNcLYcYbCsbQNGsQA = etqzpdxiufwMTNcLYcYbCsbQNGsQA;
					}
					return mcFfdeWzKSLIwPiNnirZdPfvOskZ;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class EMiCYCDgfsrnfEZehKEmhxYbqYnyA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int eUaeVBBKezVBIIUqhThgmMXmwTvSA;

				private Button WxiKOoKajqZTyMAPjUOimKJoRgik;

				private int CkipZdFxcKGVyYbkSEwaNgiJfsbb;

				public Platform_WindowsUWP_Base xpOwrsOCLTIzwfgTApbczJtsvTnR;

				private int oUZkYjEhWqOzedakRPVEQnKHDWxg;

				private int OWijKpPWYvOvZNdQmrwJqRBlpJim;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return WxiKOoKajqZTyMAPjUOimKJoRgik;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return WxiKOoKajqZTyMAPjUOimKJoRgik;
					}
				}

				[DebuggerHidden]
				public EMiCYCDgfsrnfEZehKEmhxYbqYnyA(int P_0)
				{
					eUaeVBBKezVBIIUqhThgmMXmwTvSA = P_0;
					CkipZdFxcKGVyYbkSEwaNgiJfsbb = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					eUaeVBBKezVBIIUqhThgmMXmwTvSA = -2;
				}

				private bool MoveNext()
				{
					int num = eUaeVBBKezVBIIUqhThgmMXmwTvSA;
					Platform_WindowsUWP_Base platform_WindowsUWP_Base = xpOwrsOCLTIzwfgTApbczJtsvTnR;
					switch (num)
					{
					default:
						return false;
					case 0:
						eUaeVBBKezVBIIUqhThgmMXmwTvSA = -1;
						if (platform_WindowsUWP_Base.elements == null || platform_WindowsUWP_Base.elements.buttons == null)
						{
							return false;
						}
						oUZkYjEhWqOzedakRPVEQnKHDWxg = platform_WindowsUWP_Base.elements.buttons.Length;
						OWijKpPWYvOvZNdQmrwJqRBlpJim = 0;
						break;
					case 1:
						eUaeVBBKezVBIIUqhThgmMXmwTvSA = -1;
						OWijKpPWYvOvZNdQmrwJqRBlpJim++;
						break;
					}
					if (OWijKpPWYvOvZNdQmrwJqRBlpJim < oUZkYjEhWqOzedakRPVEQnKHDWxg)
					{
						WxiKOoKajqZTyMAPjUOimKJoRgik = platform_WindowsUWP_Base.elements.buttons[OWijKpPWYvOvZNdQmrwJqRBlpJim];
						eUaeVBBKezVBIIUqhThgmMXmwTvSA = 1;
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
					EMiCYCDgfsrnfEZehKEmhxYbqYnyA eMiCYCDgfsrnfEZehKEmhxYbqYnyA;
					if (eUaeVBBKezVBIIUqhThgmMXmwTvSA == -2 && CkipZdFxcKGVyYbkSEwaNgiJfsbb == Environment.CurrentManagedThreadId)
					{
						eUaeVBBKezVBIIUqhThgmMXmwTvSA = 0;
						eMiCYCDgfsrnfEZehKEmhxYbqYnyA = this;
					}
					else
					{
						eMiCYCDgfsrnfEZehKEmhxYbqYnyA = new EMiCYCDgfsrnfEZehKEmhxYbqYnyA(0);
						eMiCYCDgfsrnfEZehKEmhxYbqYnyA.xpOwrsOCLTIzwfgTApbczJtsvTnR = xpOwrsOCLTIzwfgTApbczJtsvTnR;
					}
					return eMiCYCDgfsrnfEZehKEmhxYbqYnyA;
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
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
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

			[IteratorStateMachine(typeof(McFfdeWzKSLIwPiNnirZdPfvOskZ))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new McFfdeWzKSLIwPiNnirZdPfvOskZ(-2)
				{
					etqzpdxiufwMTNcLYcYbCsbQNGsQA = this
				};
			}

			[IteratorStateMachine(typeof(EMiCYCDgfsrnfEZehKEmhxYbqYnyA))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new EMiCYCDgfsrnfEZehKEmhxYbqYnyA(-2)
				{
					xpOwrsOCLTIzwfgTApbczJtsvTnR = this
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

				public float axisUpperDeadZone;

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
						axis.axisUpperDeadZone = axisUpperDeadZone;
						axis.calibrateAxis = calibrateAxis;
						axis.axisZero = axisZero;
						axis.axisMin = axisMin;
						axis.axisMax = axisMax;
						axis.axisInfo = MiscTools.DeepClone(axisInfo);
						axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
					}
				}
			}

			private sealed class ZSlAUSgNUidqvIaYFBCmsPZjknEtA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int xMoPlSObbyXxHcuZhOJeYDKJocMm;

				private Axis rnllbloKleuQURkbbvOOcjREXJyj;

				private int hmLaZWysZqgnmFlpQJAfENEKmpasb;

				public Platform_Fallback_Base wYbgIIHtFYLpIKqSfKNkmcFdLXpC;

				private int JzIxDwkYVtCYYYXObihiAmVdBHdM;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return rnllbloKleuQURkbbvOOcjREXJyj;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return rnllbloKleuQURkbbvOOcjREXJyj;
					}
				}

				[DebuggerHidden]
				public ZSlAUSgNUidqvIaYFBCmsPZjknEtA(int P_0)
				{
					xMoPlSObbyXxHcuZhOJeYDKJocMm = P_0;
					hmLaZWysZqgnmFlpQJAfENEKmpasb = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					xMoPlSObbyXxHcuZhOJeYDKJocMm = -2;
				}

				private bool MoveNext()
				{
					int num = xMoPlSObbyXxHcuZhOJeYDKJocMm;
					Platform_Fallback_Base platform_Fallback_Base = wYbgIIHtFYLpIKqSfKNkmcFdLXpC;
					switch (num)
					{
					default:
						return false;
					case 0:
						xMoPlSObbyXxHcuZhOJeYDKJocMm = -1;
						if (platform_Fallback_Base.elements == null || platform_Fallback_Base.elements.axes == null)
						{
							return false;
						}
						JzIxDwkYVtCYYYXObihiAmVdBHdM = 0;
						break;
					case 1:
						xMoPlSObbyXxHcuZhOJeYDKJocMm = -1;
						JzIxDwkYVtCYYYXObihiAmVdBHdM++;
						break;
					}
					if (JzIxDwkYVtCYYYXObihiAmVdBHdM < platform_Fallback_Base.elements.axes.Length)
					{
						rnllbloKleuQURkbbvOOcjREXJyj = platform_Fallback_Base.elements.axes[JzIxDwkYVtCYYYXObihiAmVdBHdM];
						xMoPlSObbyXxHcuZhOJeYDKJocMm = 1;
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
					ZSlAUSgNUidqvIaYFBCmsPZjknEtA zSlAUSgNUidqvIaYFBCmsPZjknEtA;
					if (xMoPlSObbyXxHcuZhOJeYDKJocMm == -2 && hmLaZWysZqgnmFlpQJAfENEKmpasb == Environment.CurrentManagedThreadId)
					{
						xMoPlSObbyXxHcuZhOJeYDKJocMm = 0;
						zSlAUSgNUidqvIaYFBCmsPZjknEtA = this;
					}
					else
					{
						zSlAUSgNUidqvIaYFBCmsPZjknEtA = new ZSlAUSgNUidqvIaYFBCmsPZjknEtA(0);
						zSlAUSgNUidqvIaYFBCmsPZjknEtA.wYbgIIHtFYLpIKqSfKNkmcFdLXpC = wYbgIIHtFYLpIKqSfKNkmcFdLXpC;
					}
					return zSlAUSgNUidqvIaYFBCmsPZjknEtA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class lvpVqAEDHmPeOFFokryLGhJBDHSb : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int bpaKPzDnIxJyWAbkuUDcQobJeuTH;

				private Button agaueTDeiWUTeXUOklDGRmsaaflEA;

				private int PZrktDHzAobVryRwBSXmXCcEpBbx;

				public Platform_Fallback_Base NWnoRyxRrXPYbFbwIrgPxhsGPlXg;

				private int oXBKMPWEqQAIyCORdHEjGEAdYMIMB;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return agaueTDeiWUTeXUOklDGRmsaaflEA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return agaueTDeiWUTeXUOklDGRmsaaflEA;
					}
				}

				[DebuggerHidden]
				public lvpVqAEDHmPeOFFokryLGhJBDHSb(int P_0)
				{
					bpaKPzDnIxJyWAbkuUDcQobJeuTH = P_0;
					PZrktDHzAobVryRwBSXmXCcEpBbx = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					bpaKPzDnIxJyWAbkuUDcQobJeuTH = -2;
				}

				private bool MoveNext()
				{
					int num = bpaKPzDnIxJyWAbkuUDcQobJeuTH;
					Platform_Fallback_Base nWnoRyxRrXPYbFbwIrgPxhsGPlXg = NWnoRyxRrXPYbFbwIrgPxhsGPlXg;
					switch (num)
					{
					default:
						return false;
					case 0:
						bpaKPzDnIxJyWAbkuUDcQobJeuTH = -1;
						if (nWnoRyxRrXPYbFbwIrgPxhsGPlXg.elements == null || nWnoRyxRrXPYbFbwIrgPxhsGPlXg.elements.buttons == null)
						{
							return false;
						}
						oXBKMPWEqQAIyCORdHEjGEAdYMIMB = 0;
						break;
					case 1:
						bpaKPzDnIxJyWAbkuUDcQobJeuTH = -1;
						oXBKMPWEqQAIyCORdHEjGEAdYMIMB++;
						break;
					}
					if (oXBKMPWEqQAIyCORdHEjGEAdYMIMB < nWnoRyxRrXPYbFbwIrgPxhsGPlXg.elements.buttons.Length)
					{
						agaueTDeiWUTeXUOklDGRmsaaflEA = nWnoRyxRrXPYbFbwIrgPxhsGPlXg.elements.buttons[oXBKMPWEqQAIyCORdHEjGEAdYMIMB];
						bpaKPzDnIxJyWAbkuUDcQobJeuTH = 1;
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
					lvpVqAEDHmPeOFFokryLGhJBDHSb lvpVqAEDHmPeOFFokryLGhJBDHSb2;
					if (bpaKPzDnIxJyWAbkuUDcQobJeuTH == -2 && PZrktDHzAobVryRwBSXmXCcEpBbx == Environment.CurrentManagedThreadId)
					{
						bpaKPzDnIxJyWAbkuUDcQobJeuTH = 0;
						lvpVqAEDHmPeOFFokryLGhJBDHSb2 = this;
					}
					else
					{
						lvpVqAEDHmPeOFFokryLGhJBDHSb2 = new lvpVqAEDHmPeOFFokryLGhJBDHSb(0);
						lvpVqAEDHmPeOFFokryLGhJBDHSb2.NWnoRyxRrXPYbFbwIrgPxhsGPlXg = NWnoRyxRrXPYbFbwIrgPxhsGPlXg;
					}
					return lvpVqAEDHmPeOFFokryLGhJBDHSb2;
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

			[IteratorStateMachine(typeof(ZSlAUSgNUidqvIaYFBCmsPZjknEtA))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new ZSlAUSgNUidqvIaYFBCmsPZjknEtA(-2)
				{
					wYbgIIHtFYLpIKqSfKNkmcFdLXpC = this
				};
			}

			[IteratorStateMachine(typeof(lvpVqAEDHmPeOFFokryLGhJBDHSb))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new lvpVqAEDHmPeOFFokryLGhJBDHSb(-2)
				{
					NWnoRyxRrXPYbFbwIrgPxhsGPlXg = this
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
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
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

				public float axisUpperDeadZone;

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
						axisUpperDeadZone = axisUpperDeadZone,
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

				public float axisUpperDeadZone;

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
						axis.axisUpperDeadZone = axisUpperDeadZone;
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

			private sealed class GIBnNTdkhWPCWNDsyIyXRSxlNBXq : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int aFPeEwshZSyDjeZHPitMfbbutUL;

				private Platform_Custom.Axis szWRfBPdJHuIzXbfhSXqXSFNPdlp;

				private int hFnaoLgUVbYyQfETmJUPbxqGDwigc;

				public Platform_XboxOne_Base MTDssGgOWXscYYamVFfecszBmGAVA;

				private int wjjlAApkwSoJOpYYbrcvWlhMTWin;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return szWRfBPdJHuIzXbfhSXqXSFNPdlp;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return szWRfBPdJHuIzXbfhSXqXSFNPdlp;
					}
				}

				[DebuggerHidden]
				public GIBnNTdkhWPCWNDsyIyXRSxlNBXq(int P_0)
				{
					aFPeEwshZSyDjeZHPitMfbbutUL = P_0;
					hFnaoLgUVbYyQfETmJUPbxqGDwigc = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					aFPeEwshZSyDjeZHPitMfbbutUL = -2;
				}

				private bool MoveNext()
				{
					int num = aFPeEwshZSyDjeZHPitMfbbutUL;
					Platform_XboxOne_Base mTDssGgOWXscYYamVFfecszBmGAVA = MTDssGgOWXscYYamVFfecszBmGAVA;
					switch (num)
					{
					default:
						return false;
					case 0:
						aFPeEwshZSyDjeZHPitMfbbutUL = -1;
						if (mTDssGgOWXscYYamVFfecszBmGAVA.elements == null || mTDssGgOWXscYYamVFfecszBmGAVA.elements.axes == null)
						{
							return false;
						}
						wjjlAApkwSoJOpYYbrcvWlhMTWin = 0;
						break;
					case 1:
						aFPeEwshZSyDjeZHPitMfbbutUL = -1;
						wjjlAApkwSoJOpYYbrcvWlhMTWin++;
						break;
					}
					if (wjjlAApkwSoJOpYYbrcvWlhMTWin < mTDssGgOWXscYYamVFfecszBmGAVA.elements.axes.Length)
					{
						szWRfBPdJHuIzXbfhSXqXSFNPdlp = mTDssGgOWXscYYamVFfecszBmGAVA.elements.axes[wjjlAApkwSoJOpYYbrcvWlhMTWin];
						aFPeEwshZSyDjeZHPitMfbbutUL = 1;
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
					GIBnNTdkhWPCWNDsyIyXRSxlNBXq gIBnNTdkhWPCWNDsyIyXRSxlNBXq;
					if (aFPeEwshZSyDjeZHPitMfbbutUL == -2 && hFnaoLgUVbYyQfETmJUPbxqGDwigc == Environment.CurrentManagedThreadId)
					{
						aFPeEwshZSyDjeZHPitMfbbutUL = 0;
						gIBnNTdkhWPCWNDsyIyXRSxlNBXq = this;
					}
					else
					{
						gIBnNTdkhWPCWNDsyIyXRSxlNBXq = new GIBnNTdkhWPCWNDsyIyXRSxlNBXq(0);
						gIBnNTdkhWPCWNDsyIyXRSxlNBXq.MTDssGgOWXscYYamVFfecszBmGAVA = MTDssGgOWXscYYamVFfecszBmGAVA;
					}
					return gIBnNTdkhWPCWNDsyIyXRSxlNBXq;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class mwghMiNiqcJeBUbwVojdCaMKOZwE : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int VSPclAiTBjACCNrIFpHWNdxQeYRb;

				private Platform_Custom.Button IzVOoUBgvtNBtabNuUbkKKkLMpUy;

				private int HuZCIxOcIsQHqTwPTIdddJqmpWIQ;

				public Platform_XboxOne_Base xsRMBnOohvFtGkVgcBBWIpXkgBdwA;

				private int tqfCvffxlOzYEmnaAGHzyEEkdjZH;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return IzVOoUBgvtNBtabNuUbkKKkLMpUy;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return IzVOoUBgvtNBtabNuUbkKKkLMpUy;
					}
				}

				[DebuggerHidden]
				public mwghMiNiqcJeBUbwVojdCaMKOZwE(int P_0)
				{
					VSPclAiTBjACCNrIFpHWNdxQeYRb = P_0;
					HuZCIxOcIsQHqTwPTIdddJqmpWIQ = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					VSPclAiTBjACCNrIFpHWNdxQeYRb = -2;
				}

				private bool MoveNext()
				{
					int vSPclAiTBjACCNrIFpHWNdxQeYRb = VSPclAiTBjACCNrIFpHWNdxQeYRb;
					Platform_XboxOne_Base platform_XboxOne_Base = xsRMBnOohvFtGkVgcBBWIpXkgBdwA;
					switch (vSPclAiTBjACCNrIFpHWNdxQeYRb)
					{
					default:
						return false;
					case 0:
						VSPclAiTBjACCNrIFpHWNdxQeYRb = -1;
						if (platform_XboxOne_Base.elements == null || platform_XboxOne_Base.elements.buttons == null)
						{
							return false;
						}
						tqfCvffxlOzYEmnaAGHzyEEkdjZH = 0;
						break;
					case 1:
						VSPclAiTBjACCNrIFpHWNdxQeYRb = -1;
						tqfCvffxlOzYEmnaAGHzyEEkdjZH++;
						break;
					}
					if (tqfCvffxlOzYEmnaAGHzyEEkdjZH < platform_XboxOne_Base.elements.buttons.Length)
					{
						IzVOoUBgvtNBtabNuUbkKKkLMpUy = platform_XboxOne_Base.elements.buttons[tqfCvffxlOzYEmnaAGHzyEEkdjZH];
						VSPclAiTBjACCNrIFpHWNdxQeYRb = 1;
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
					mwghMiNiqcJeBUbwVojdCaMKOZwE mwghMiNiqcJeBUbwVojdCaMKOZwE2;
					if (VSPclAiTBjACCNrIFpHWNdxQeYRb == -2 && HuZCIxOcIsQHqTwPTIdddJqmpWIQ == Environment.CurrentManagedThreadId)
					{
						VSPclAiTBjACCNrIFpHWNdxQeYRb = 0;
						mwghMiNiqcJeBUbwVojdCaMKOZwE2 = this;
					}
					else
					{
						mwghMiNiqcJeBUbwVojdCaMKOZwE2 = new mwghMiNiqcJeBUbwVojdCaMKOZwE(0);
						mwghMiNiqcJeBUbwVojdCaMKOZwE2.xsRMBnOohvFtGkVgcBBWIpXkgBdwA = xsRMBnOohvFtGkVgcBBWIpXkgBdwA;
					}
					return mwghMiNiqcJeBUbwVojdCaMKOZwE2;
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

			[IteratorStateMachine(typeof(GIBnNTdkhWPCWNDsyIyXRSxlNBXq))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new GIBnNTdkhWPCWNDsyIyXRSxlNBXq(-2)
				{
					MTDssGgOWXscYYamVFfecszBmGAVA = this
				};
			}

			[IteratorStateMachine(typeof(mwghMiNiqcJeBUbwVojdCaMKOZwE))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new mwghMiNiqcJeBUbwVojdCaMKOZwE(-2)
				{
					xsRMBnOohvFtGkVgcBBWIpXkgBdwA = this
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
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
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

			private sealed class EfoocBsReuXIIMrChgnXRBqLEOEp : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int vcyshpedXFBCoHdwEbBGCrofuCNyA;

				private Platform_Custom.Axis niBjRSnKUvPkvQPchjZAHNgXIxwgb;

				private int ozpAFeilPSJoeTYbzpCrmduikJZEb;

				public Platform_PS4_Base EGtjWewGsMsSIxskkKwKNLTZsHky;

				private int emMGwEAxizmFcJtGagwySrJXLfrl;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return niBjRSnKUvPkvQPchjZAHNgXIxwgb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return niBjRSnKUvPkvQPchjZAHNgXIxwgb;
					}
				}

				[DebuggerHidden]
				public EfoocBsReuXIIMrChgnXRBqLEOEp(int P_0)
				{
					vcyshpedXFBCoHdwEbBGCrofuCNyA = P_0;
					ozpAFeilPSJoeTYbzpCrmduikJZEb = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					vcyshpedXFBCoHdwEbBGCrofuCNyA = -2;
				}

				private bool MoveNext()
				{
					int num = vcyshpedXFBCoHdwEbBGCrofuCNyA;
					Platform_PS4_Base eGtjWewGsMsSIxskkKwKNLTZsHky = EGtjWewGsMsSIxskkKwKNLTZsHky;
					switch (num)
					{
					default:
						return false;
					case 0:
						vcyshpedXFBCoHdwEbBGCrofuCNyA = -1;
						if (eGtjWewGsMsSIxskkKwKNLTZsHky.elements == null || eGtjWewGsMsSIxskkKwKNLTZsHky.elements.axes == null)
						{
							return false;
						}
						emMGwEAxizmFcJtGagwySrJXLfrl = 0;
						break;
					case 1:
						vcyshpedXFBCoHdwEbBGCrofuCNyA = -1;
						emMGwEAxizmFcJtGagwySrJXLfrl++;
						break;
					}
					if (emMGwEAxizmFcJtGagwySrJXLfrl < eGtjWewGsMsSIxskkKwKNLTZsHky.elements.axes.Length)
					{
						niBjRSnKUvPkvQPchjZAHNgXIxwgb = eGtjWewGsMsSIxskkKwKNLTZsHky.elements.axes[emMGwEAxizmFcJtGagwySrJXLfrl];
						vcyshpedXFBCoHdwEbBGCrofuCNyA = 1;
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
					EfoocBsReuXIIMrChgnXRBqLEOEp efoocBsReuXIIMrChgnXRBqLEOEp;
					if (vcyshpedXFBCoHdwEbBGCrofuCNyA == -2 && ozpAFeilPSJoeTYbzpCrmduikJZEb == Environment.CurrentManagedThreadId)
					{
						vcyshpedXFBCoHdwEbBGCrofuCNyA = 0;
						efoocBsReuXIIMrChgnXRBqLEOEp = this;
					}
					else
					{
						efoocBsReuXIIMrChgnXRBqLEOEp = new EfoocBsReuXIIMrChgnXRBqLEOEp(0);
						efoocBsReuXIIMrChgnXRBqLEOEp.EGtjWewGsMsSIxskkKwKNLTZsHky = EGtjWewGsMsSIxskkKwKNLTZsHky;
					}
					return efoocBsReuXIIMrChgnXRBqLEOEp;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class njiEIPZeMfXCimkfJeSMboDjNqlwA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int YRXunkhmCrULcalXVTAFDFttmXUj;

				private Platform_Custom.Button FEHYdaJrsEqnVKxUAUJLzTGXNXbV;

				private int NVfGHkiNcULxPFXHKeGhCTYFgUUuA;

				public Platform_PS4_Base YOiBAypgsHDJvJKWlTVSbECAzfoM;

				private int GNaujlHJcsbDMJOGvdkTnKzxRVfiA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return FEHYdaJrsEqnVKxUAUJLzTGXNXbV;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return FEHYdaJrsEqnVKxUAUJLzTGXNXbV;
					}
				}

				[DebuggerHidden]
				public njiEIPZeMfXCimkfJeSMboDjNqlwA(int P_0)
				{
					YRXunkhmCrULcalXVTAFDFttmXUj = P_0;
					NVfGHkiNcULxPFXHKeGhCTYFgUUuA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					YRXunkhmCrULcalXVTAFDFttmXUj = -2;
				}

				private bool MoveNext()
				{
					int yRXunkhmCrULcalXVTAFDFttmXUj = YRXunkhmCrULcalXVTAFDFttmXUj;
					Platform_PS4_Base yOiBAypgsHDJvJKWlTVSbECAzfoM = YOiBAypgsHDJvJKWlTVSbECAzfoM;
					switch (yRXunkhmCrULcalXVTAFDFttmXUj)
					{
					default:
						return false;
					case 0:
						YRXunkhmCrULcalXVTAFDFttmXUj = -1;
						if (yOiBAypgsHDJvJKWlTVSbECAzfoM.elements == null || yOiBAypgsHDJvJKWlTVSbECAzfoM.elements.buttons == null)
						{
							return false;
						}
						GNaujlHJcsbDMJOGvdkTnKzxRVfiA = 0;
						break;
					case 1:
						YRXunkhmCrULcalXVTAFDFttmXUj = -1;
						GNaujlHJcsbDMJOGvdkTnKzxRVfiA++;
						break;
					}
					if (GNaujlHJcsbDMJOGvdkTnKzxRVfiA < yOiBAypgsHDJvJKWlTVSbECAzfoM.elements.buttons.Length)
					{
						FEHYdaJrsEqnVKxUAUJLzTGXNXbV = yOiBAypgsHDJvJKWlTVSbECAzfoM.elements.buttons[GNaujlHJcsbDMJOGvdkTnKzxRVfiA];
						YRXunkhmCrULcalXVTAFDFttmXUj = 1;
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
					njiEIPZeMfXCimkfJeSMboDjNqlwA njiEIPZeMfXCimkfJeSMboDjNqlwA2;
					if (YRXunkhmCrULcalXVTAFDFttmXUj == -2 && NVfGHkiNcULxPFXHKeGhCTYFgUUuA == Environment.CurrentManagedThreadId)
					{
						YRXunkhmCrULcalXVTAFDFttmXUj = 0;
						njiEIPZeMfXCimkfJeSMboDjNqlwA2 = this;
					}
					else
					{
						njiEIPZeMfXCimkfJeSMboDjNqlwA2 = new njiEIPZeMfXCimkfJeSMboDjNqlwA(0);
						njiEIPZeMfXCimkfJeSMboDjNqlwA2.YOiBAypgsHDJvJKWlTVSbECAzfoM = YOiBAypgsHDJvJKWlTVSbECAzfoM;
					}
					return njiEIPZeMfXCimkfJeSMboDjNqlwA2;
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

			[IteratorStateMachine(typeof(EfoocBsReuXIIMrChgnXRBqLEOEp))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new EfoocBsReuXIIMrChgnXRBqLEOEp(-2)
				{
					EGtjWewGsMsSIxskkKwKNLTZsHky = this
				};
			}

			[IteratorStateMachine(typeof(njiEIPZeMfXCimkfJeSMboDjNqlwA))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new njiEIPZeMfXCimkfJeSMboDjNqlwA(-2)
				{
					YOiBAypgsHDJvJKWlTVSbECAzfoM = this
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
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
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

			private sealed class KIDRtBvoBFfNvnnLmBIFzRxCTVqS : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int BeuwFrTHCFugqFJVEPkNRbFjAFTy;

				private Platform_Custom.Axis zkvXybedrgFNaMpftfONCaJMYsdj;

				private int xeTvsPxZjfKDVmLNaboGbrFSbJnX;

				public Platform_NintendoSwitch_Base AQNTXhdMJQPMghWNWESMEgbqDRjdA;

				private int TsXeNjviliqZlNQxqXRXgKWCnvJA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return zkvXybedrgFNaMpftfONCaJMYsdj;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return zkvXybedrgFNaMpftfONCaJMYsdj;
					}
				}

				[DebuggerHidden]
				public KIDRtBvoBFfNvnnLmBIFzRxCTVqS(int P_0)
				{
					BeuwFrTHCFugqFJVEPkNRbFjAFTy = P_0;
					xeTvsPxZjfKDVmLNaboGbrFSbJnX = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					BeuwFrTHCFugqFJVEPkNRbFjAFTy = -2;
				}

				private bool MoveNext()
				{
					int beuwFrTHCFugqFJVEPkNRbFjAFTy = BeuwFrTHCFugqFJVEPkNRbFjAFTy;
					Platform_NintendoSwitch_Base aQNTXhdMJQPMghWNWESMEgbqDRjdA = AQNTXhdMJQPMghWNWESMEgbqDRjdA;
					switch (beuwFrTHCFugqFJVEPkNRbFjAFTy)
					{
					default:
						return false;
					case 0:
						BeuwFrTHCFugqFJVEPkNRbFjAFTy = -1;
						if (aQNTXhdMJQPMghWNWESMEgbqDRjdA.elements == null || aQNTXhdMJQPMghWNWESMEgbqDRjdA.elements.axes == null)
						{
							return false;
						}
						TsXeNjviliqZlNQxqXRXgKWCnvJA = 0;
						break;
					case 1:
						BeuwFrTHCFugqFJVEPkNRbFjAFTy = -1;
						TsXeNjviliqZlNQxqXRXgKWCnvJA++;
						break;
					}
					if (TsXeNjviliqZlNQxqXRXgKWCnvJA < aQNTXhdMJQPMghWNWESMEgbqDRjdA.elements.axes.Length)
					{
						zkvXybedrgFNaMpftfONCaJMYsdj = aQNTXhdMJQPMghWNWESMEgbqDRjdA.elements.axes[TsXeNjviliqZlNQxqXRXgKWCnvJA];
						BeuwFrTHCFugqFJVEPkNRbFjAFTy = 1;
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
					KIDRtBvoBFfNvnnLmBIFzRxCTVqS kIDRtBvoBFfNvnnLmBIFzRxCTVqS;
					if (BeuwFrTHCFugqFJVEPkNRbFjAFTy == -2 && xeTvsPxZjfKDVmLNaboGbrFSbJnX == Environment.CurrentManagedThreadId)
					{
						BeuwFrTHCFugqFJVEPkNRbFjAFTy = 0;
						kIDRtBvoBFfNvnnLmBIFzRxCTVqS = this;
					}
					else
					{
						kIDRtBvoBFfNvnnLmBIFzRxCTVqS = new KIDRtBvoBFfNvnnLmBIFzRxCTVqS(0);
						kIDRtBvoBFfNvnnLmBIFzRxCTVqS.AQNTXhdMJQPMghWNWESMEgbqDRjdA = AQNTXhdMJQPMghWNWESMEgbqDRjdA;
					}
					return kIDRtBvoBFfNvnnLmBIFzRxCTVqS;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class VeRDjuAHWvpxUKgJTveQRXSQFYoSA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int MPPYNideaZaNtIQkLUjNLkLgYrpk;

				private Platform_Custom.Button DzXfGeKNUKvuLqZWlCatGOzYPiHyA;

				private int nuvWZbCWMHANgZlEBbHJfFYiqDaZ;

				public Platform_NintendoSwitch_Base wxdidlYnJQojVmFkqEOYatVLHeSb;

				private int RiuXAKroaCjiDHbHLNPFjiqtfapC;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return DzXfGeKNUKvuLqZWlCatGOzYPiHyA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return DzXfGeKNUKvuLqZWlCatGOzYPiHyA;
					}
				}

				[DebuggerHidden]
				public VeRDjuAHWvpxUKgJTveQRXSQFYoSA(int P_0)
				{
					MPPYNideaZaNtIQkLUjNLkLgYrpk = P_0;
					nuvWZbCWMHANgZlEBbHJfFYiqDaZ = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					MPPYNideaZaNtIQkLUjNLkLgYrpk = -2;
				}

				private bool MoveNext()
				{
					int mPPYNideaZaNtIQkLUjNLkLgYrpk = MPPYNideaZaNtIQkLUjNLkLgYrpk;
					Platform_NintendoSwitch_Base platform_NintendoSwitch_Base = wxdidlYnJQojVmFkqEOYatVLHeSb;
					switch (mPPYNideaZaNtIQkLUjNLkLgYrpk)
					{
					default:
						return false;
					case 0:
						MPPYNideaZaNtIQkLUjNLkLgYrpk = -1;
						if (platform_NintendoSwitch_Base.elements == null || platform_NintendoSwitch_Base.elements.buttons == null)
						{
							return false;
						}
						RiuXAKroaCjiDHbHLNPFjiqtfapC = 0;
						break;
					case 1:
						MPPYNideaZaNtIQkLUjNLkLgYrpk = -1;
						RiuXAKroaCjiDHbHLNPFjiqtfapC++;
						break;
					}
					if (RiuXAKroaCjiDHbHLNPFjiqtfapC < platform_NintendoSwitch_Base.elements.buttons.Length)
					{
						DzXfGeKNUKvuLqZWlCatGOzYPiHyA = platform_NintendoSwitch_Base.elements.buttons[RiuXAKroaCjiDHbHLNPFjiqtfapC];
						MPPYNideaZaNtIQkLUjNLkLgYrpk = 1;
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
					VeRDjuAHWvpxUKgJTveQRXSQFYoSA veRDjuAHWvpxUKgJTveQRXSQFYoSA;
					if (MPPYNideaZaNtIQkLUjNLkLgYrpk == -2 && nuvWZbCWMHANgZlEBbHJfFYiqDaZ == Environment.CurrentManagedThreadId)
					{
						MPPYNideaZaNtIQkLUjNLkLgYrpk = 0;
						veRDjuAHWvpxUKgJTveQRXSQFYoSA = this;
					}
					else
					{
						veRDjuAHWvpxUKgJTveQRXSQFYoSA = new VeRDjuAHWvpxUKgJTveQRXSQFYoSA(0);
						veRDjuAHWvpxUKgJTveQRXSQFYoSA.wxdidlYnJQojVmFkqEOYatVLHeSb = wxdidlYnJQojVmFkqEOYatVLHeSb;
					}
					return veRDjuAHWvpxUKgJTveQRXSQFYoSA;
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

			[IteratorStateMachine(typeof(KIDRtBvoBFfNvnnLmBIFzRxCTVqS))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new KIDRtBvoBFfNvnnLmBIFzRxCTVqS(-2)
				{
					AQNTXhdMJQPMghWNWESMEgbqDRjdA = this
				};
			}

			[IteratorStateMachine(typeof(VeRDjuAHWvpxUKgJTveQRXSQFYoSA))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new VeRDjuAHWvpxUKgJTveQRXSQFYoSA(-2)
				{
					wxdidlYnJQojVmFkqEOYatVLHeSb = this
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
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
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

			private sealed class aWBvArqxKPmulXWxnUrgdLinMZL : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int lBncPWWCjVpMRWEhBKbwUJSFQvln;

				private Platform_Custom.Axis gkIpvKnBhSFPWNQABXQUpyOWhcY;

				private int IVIekyjPFnzNFwFYlrlsZSBuNwVh;

				public Platform_GameCore_Base MJxvIdzSnLIcrYWEHAXVUMYUXSXn;

				private int nFHOMoYTvbDtjIIOwfHnPtseBBre;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return gkIpvKnBhSFPWNQABXQUpyOWhcY;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return gkIpvKnBhSFPWNQABXQUpyOWhcY;
					}
				}

				[DebuggerHidden]
				public aWBvArqxKPmulXWxnUrgdLinMZL(int P_0)
				{
					lBncPWWCjVpMRWEhBKbwUJSFQvln = P_0;
					IVIekyjPFnzNFwFYlrlsZSBuNwVh = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					lBncPWWCjVpMRWEhBKbwUJSFQvln = -2;
				}

				private bool MoveNext()
				{
					int num = lBncPWWCjVpMRWEhBKbwUJSFQvln;
					Platform_GameCore_Base mJxvIdzSnLIcrYWEHAXVUMYUXSXn = MJxvIdzSnLIcrYWEHAXVUMYUXSXn;
					switch (num)
					{
					default:
						return false;
					case 0:
						lBncPWWCjVpMRWEhBKbwUJSFQvln = -1;
						if (mJxvIdzSnLIcrYWEHAXVUMYUXSXn.elements == null || mJxvIdzSnLIcrYWEHAXVUMYUXSXn.elements.axes == null)
						{
							return false;
						}
						nFHOMoYTvbDtjIIOwfHnPtseBBre = 0;
						break;
					case 1:
						lBncPWWCjVpMRWEhBKbwUJSFQvln = -1;
						nFHOMoYTvbDtjIIOwfHnPtseBBre++;
						break;
					}
					if (nFHOMoYTvbDtjIIOwfHnPtseBBre < mJxvIdzSnLIcrYWEHAXVUMYUXSXn.elements.axes.Length)
					{
						gkIpvKnBhSFPWNQABXQUpyOWhcY = mJxvIdzSnLIcrYWEHAXVUMYUXSXn.elements.axes[nFHOMoYTvbDtjIIOwfHnPtseBBre];
						lBncPWWCjVpMRWEhBKbwUJSFQvln = 1;
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
					aWBvArqxKPmulXWxnUrgdLinMZL aWBvArqxKPmulXWxnUrgdLinMZL2;
					if (lBncPWWCjVpMRWEhBKbwUJSFQvln == -2 && IVIekyjPFnzNFwFYlrlsZSBuNwVh == Environment.CurrentManagedThreadId)
					{
						lBncPWWCjVpMRWEhBKbwUJSFQvln = 0;
						aWBvArqxKPmulXWxnUrgdLinMZL2 = this;
					}
					else
					{
						aWBvArqxKPmulXWxnUrgdLinMZL2 = new aWBvArqxKPmulXWxnUrgdLinMZL(0);
						aWBvArqxKPmulXWxnUrgdLinMZL2.MJxvIdzSnLIcrYWEHAXVUMYUXSXn = MJxvIdzSnLIcrYWEHAXVUMYUXSXn;
					}
					return aWBvArqxKPmulXWxnUrgdLinMZL2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class ZiErVjDfyFkwckNeqbusDenOiNGc : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int KFWDYIvREdkgjYgrdNQIFEZjOdqw;

				private Platform_Custom.Button CWpVqBuLbIdVYJDWjITKoPhzYSDe;

				private int jlUddmywLoWqHQicXiqeuoUIlrmu;

				public Platform_GameCore_Base LylaTOPeYqBrXmhTPHELqkqMgLBk;

				private int nOBTCkgeorIwUQdIHILoAnWqpyXZA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return CWpVqBuLbIdVYJDWjITKoPhzYSDe;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return CWpVqBuLbIdVYJDWjITKoPhzYSDe;
					}
				}

				[DebuggerHidden]
				public ZiErVjDfyFkwckNeqbusDenOiNGc(int P_0)
				{
					KFWDYIvREdkgjYgrdNQIFEZjOdqw = P_0;
					jlUddmywLoWqHQicXiqeuoUIlrmu = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					KFWDYIvREdkgjYgrdNQIFEZjOdqw = -2;
				}

				private bool MoveNext()
				{
					int kFWDYIvREdkgjYgrdNQIFEZjOdqw = KFWDYIvREdkgjYgrdNQIFEZjOdqw;
					Platform_GameCore_Base lylaTOPeYqBrXmhTPHELqkqMgLBk = LylaTOPeYqBrXmhTPHELqkqMgLBk;
					switch (kFWDYIvREdkgjYgrdNQIFEZjOdqw)
					{
					default:
						return false;
					case 0:
						KFWDYIvREdkgjYgrdNQIFEZjOdqw = -1;
						if (lylaTOPeYqBrXmhTPHELqkqMgLBk.elements == null || lylaTOPeYqBrXmhTPHELqkqMgLBk.elements.buttons == null)
						{
							return false;
						}
						nOBTCkgeorIwUQdIHILoAnWqpyXZA = 0;
						break;
					case 1:
						KFWDYIvREdkgjYgrdNQIFEZjOdqw = -1;
						nOBTCkgeorIwUQdIHILoAnWqpyXZA++;
						break;
					}
					if (nOBTCkgeorIwUQdIHILoAnWqpyXZA < lylaTOPeYqBrXmhTPHELqkqMgLBk.elements.buttons.Length)
					{
						CWpVqBuLbIdVYJDWjITKoPhzYSDe = lylaTOPeYqBrXmhTPHELqkqMgLBk.elements.buttons[nOBTCkgeorIwUQdIHILoAnWqpyXZA];
						KFWDYIvREdkgjYgrdNQIFEZjOdqw = 1;
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
					ZiErVjDfyFkwckNeqbusDenOiNGc ziErVjDfyFkwckNeqbusDenOiNGc;
					if (KFWDYIvREdkgjYgrdNQIFEZjOdqw == -2 && jlUddmywLoWqHQicXiqeuoUIlrmu == Environment.CurrentManagedThreadId)
					{
						KFWDYIvREdkgjYgrdNQIFEZjOdqw = 0;
						ziErVjDfyFkwckNeqbusDenOiNGc = this;
					}
					else
					{
						ziErVjDfyFkwckNeqbusDenOiNGc = new ZiErVjDfyFkwckNeqbusDenOiNGc(0);
						ziErVjDfyFkwckNeqbusDenOiNGc.LylaTOPeYqBrXmhTPHELqkqMgLBk = LylaTOPeYqBrXmhTPHELqkqMgLBk;
					}
					return ziErVjDfyFkwckNeqbusDenOiNGc;
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

			[IteratorStateMachine(typeof(aWBvArqxKPmulXWxnUrgdLinMZL))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new aWBvArqxKPmulXWxnUrgdLinMZL(-2)
				{
					MJxvIdzSnLIcrYWEHAXVUMYUXSXn = this
				};
			}

			[IteratorStateMachine(typeof(ZiErVjDfyFkwckNeqbusDenOiNGc))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new ZiErVjDfyFkwckNeqbusDenOiNGc(-2)
				{
					LylaTOPeYqBrXmhTPHELqkqMgLBk = this
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
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
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
					axis.axisUpperDeadZone = 0f;
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

			private sealed class nyzclnmqLSfNmNzkiGUjIiGoBKuq : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int CZkoZvbPbXuhQqIKoDtAHljHkwvFA;

				private Platform_Custom.Axis edQkwGgFkAeNVvmoxPEfdGWxxYfi;

				private int GhxmyIXDQKkbcPGNQdSBJpWyUgObA;

				public Platform_PS5_Base swEnlarJoQEpcfaZYZjHgGgIDdHv;

				private int BuDEkoHhmejquAUAGipjgIViCTLkA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return edQkwGgFkAeNVvmoxPEfdGWxxYfi;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return edQkwGgFkAeNVvmoxPEfdGWxxYfi;
					}
				}

				[DebuggerHidden]
				public nyzclnmqLSfNmNzkiGUjIiGoBKuq(int P_0)
				{
					CZkoZvbPbXuhQqIKoDtAHljHkwvFA = P_0;
					GhxmyIXDQKkbcPGNQdSBJpWyUgObA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					CZkoZvbPbXuhQqIKoDtAHljHkwvFA = -2;
				}

				private bool MoveNext()
				{
					int cZkoZvbPbXuhQqIKoDtAHljHkwvFA = CZkoZvbPbXuhQqIKoDtAHljHkwvFA;
					Platform_PS5_Base platform_PS5_Base = swEnlarJoQEpcfaZYZjHgGgIDdHv;
					switch (cZkoZvbPbXuhQqIKoDtAHljHkwvFA)
					{
					default:
						return false;
					case 0:
						CZkoZvbPbXuhQqIKoDtAHljHkwvFA = -1;
						if (platform_PS5_Base.elements == null || platform_PS5_Base.elements.axes == null)
						{
							return false;
						}
						BuDEkoHhmejquAUAGipjgIViCTLkA = 0;
						break;
					case 1:
						CZkoZvbPbXuhQqIKoDtAHljHkwvFA = -1;
						BuDEkoHhmejquAUAGipjgIViCTLkA++;
						break;
					}
					if (BuDEkoHhmejquAUAGipjgIViCTLkA < platform_PS5_Base.elements.axes.Length)
					{
						edQkwGgFkAeNVvmoxPEfdGWxxYfi = platform_PS5_Base.elements.axes[BuDEkoHhmejquAUAGipjgIViCTLkA];
						CZkoZvbPbXuhQqIKoDtAHljHkwvFA = 1;
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
					nyzclnmqLSfNmNzkiGUjIiGoBKuq nyzclnmqLSfNmNzkiGUjIiGoBKuq2;
					if (CZkoZvbPbXuhQqIKoDtAHljHkwvFA == -2 && GhxmyIXDQKkbcPGNQdSBJpWyUgObA == Environment.CurrentManagedThreadId)
					{
						CZkoZvbPbXuhQqIKoDtAHljHkwvFA = 0;
						nyzclnmqLSfNmNzkiGUjIiGoBKuq2 = this;
					}
					else
					{
						nyzclnmqLSfNmNzkiGUjIiGoBKuq2 = new nyzclnmqLSfNmNzkiGUjIiGoBKuq(0);
						nyzclnmqLSfNmNzkiGUjIiGoBKuq2.swEnlarJoQEpcfaZYZjHgGgIDdHv = swEnlarJoQEpcfaZYZjHgGgIDdHv;
					}
					return nyzclnmqLSfNmNzkiGUjIiGoBKuq2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class IdOhyRiuWGTvFSffKNxMsQDBXedaA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int vLxgdUcoQZYQNscaKWYhTdiNASKR;

				private Platform_Custom.Button cbwfswbMqPdViGIkKkJYdGWtGyUhb;

				private int rbTErtDzzGoNPhTAQXzQpfDvhBAdb;

				public Platform_PS5_Base SmWDotGeZEjeWfRlAoruvxwgooJn;

				private int jXUPFQCaOqbopfPWplgwIPNKIXExb;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return cbwfswbMqPdViGIkKkJYdGWtGyUhb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return cbwfswbMqPdViGIkKkJYdGWtGyUhb;
					}
				}

				[DebuggerHidden]
				public IdOhyRiuWGTvFSffKNxMsQDBXedaA(int P_0)
				{
					vLxgdUcoQZYQNscaKWYhTdiNASKR = P_0;
					rbTErtDzzGoNPhTAQXzQpfDvhBAdb = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					vLxgdUcoQZYQNscaKWYhTdiNASKR = -2;
				}

				private bool MoveNext()
				{
					int num = vLxgdUcoQZYQNscaKWYhTdiNASKR;
					Platform_PS5_Base smWDotGeZEjeWfRlAoruvxwgooJn = SmWDotGeZEjeWfRlAoruvxwgooJn;
					switch (num)
					{
					default:
						return false;
					case 0:
						vLxgdUcoQZYQNscaKWYhTdiNASKR = -1;
						if (smWDotGeZEjeWfRlAoruvxwgooJn.elements == null || smWDotGeZEjeWfRlAoruvxwgooJn.elements.buttons == null)
						{
							return false;
						}
						jXUPFQCaOqbopfPWplgwIPNKIXExb = 0;
						break;
					case 1:
						vLxgdUcoQZYQNscaKWYhTdiNASKR = -1;
						jXUPFQCaOqbopfPWplgwIPNKIXExb++;
						break;
					}
					if (jXUPFQCaOqbopfPWplgwIPNKIXExb < smWDotGeZEjeWfRlAoruvxwgooJn.elements.buttons.Length)
					{
						cbwfswbMqPdViGIkKkJYdGWtGyUhb = smWDotGeZEjeWfRlAoruvxwgooJn.elements.buttons[jXUPFQCaOqbopfPWplgwIPNKIXExb];
						vLxgdUcoQZYQNscaKWYhTdiNASKR = 1;
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
					IdOhyRiuWGTvFSffKNxMsQDBXedaA idOhyRiuWGTvFSffKNxMsQDBXedaA;
					if (vLxgdUcoQZYQNscaKWYhTdiNASKR == -2 && rbTErtDzzGoNPhTAQXzQpfDvhBAdb == Environment.CurrentManagedThreadId)
					{
						vLxgdUcoQZYQNscaKWYhTdiNASKR = 0;
						idOhyRiuWGTvFSffKNxMsQDBXedaA = this;
					}
					else
					{
						idOhyRiuWGTvFSffKNxMsQDBXedaA = new IdOhyRiuWGTvFSffKNxMsQDBXedaA(0);
						idOhyRiuWGTvFSffKNxMsQDBXedaA.SmWDotGeZEjeWfRlAoruvxwgooJn = SmWDotGeZEjeWfRlAoruvxwgooJn;
					}
					return idOhyRiuWGTvFSffKNxMsQDBXedaA;
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

			[IteratorStateMachine(typeof(nyzclnmqLSfNmNzkiGUjIiGoBKuq))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new nyzclnmqLSfNmNzkiGUjIiGoBKuq(-2)
				{
					swEnlarJoQEpcfaZYZjHgGgIDdHv = this
				};
			}

			[IteratorStateMachine(typeof(IdOhyRiuWGTvFSffKNxMsQDBXedaA))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new IdOhyRiuWGTvFSffKNxMsQDBXedaA(-2)
				{
					SmWDotGeZEjeWfRlAoruvxwgooJn = this
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
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
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

			private sealed class VaOLEQQUpmwxCUHVVfYyinSMLJrN : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int EevlCPoLZQaUmZGgpsqIvQJCFaip;

				private Platform_Custom.Axis axxwixUfYehXhybGVpRQaydGPeep;

				private int PKUMSDWUtXGmmZdKsmxgdkJkboeh;

				public Platform_InternalDriver_Base eAlDsIUcLNYTunFITFXAEUJrYUOn;

				private int bgmpQUgfXvUTECjmOAFyxImQENJe;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return axxwixUfYehXhybGVpRQaydGPeep;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return axxwixUfYehXhybGVpRQaydGPeep;
					}
				}

				[DebuggerHidden]
				public VaOLEQQUpmwxCUHVVfYyinSMLJrN(int P_0)
				{
					EevlCPoLZQaUmZGgpsqIvQJCFaip = P_0;
					PKUMSDWUtXGmmZdKsmxgdkJkboeh = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					EevlCPoLZQaUmZGgpsqIvQJCFaip = -2;
				}

				private bool MoveNext()
				{
					int eevlCPoLZQaUmZGgpsqIvQJCFaip = EevlCPoLZQaUmZGgpsqIvQJCFaip;
					Platform_InternalDriver_Base platform_InternalDriver_Base = eAlDsIUcLNYTunFITFXAEUJrYUOn;
					switch (eevlCPoLZQaUmZGgpsqIvQJCFaip)
					{
					default:
						return false;
					case 0:
						EevlCPoLZQaUmZGgpsqIvQJCFaip = -1;
						if (platform_InternalDriver_Base.elements == null || platform_InternalDriver_Base.elements.axes == null)
						{
							return false;
						}
						bgmpQUgfXvUTECjmOAFyxImQENJe = 0;
						break;
					case 1:
						EevlCPoLZQaUmZGgpsqIvQJCFaip = -1;
						bgmpQUgfXvUTECjmOAFyxImQENJe++;
						break;
					}
					if (bgmpQUgfXvUTECjmOAFyxImQENJe < platform_InternalDriver_Base.elements.axes.Length)
					{
						axxwixUfYehXhybGVpRQaydGPeep = platform_InternalDriver_Base.elements.axes[bgmpQUgfXvUTECjmOAFyxImQENJe];
						EevlCPoLZQaUmZGgpsqIvQJCFaip = 1;
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
					VaOLEQQUpmwxCUHVVfYyinSMLJrN vaOLEQQUpmwxCUHVVfYyinSMLJrN;
					if (EevlCPoLZQaUmZGgpsqIvQJCFaip == -2 && PKUMSDWUtXGmmZdKsmxgdkJkboeh == Environment.CurrentManagedThreadId)
					{
						EevlCPoLZQaUmZGgpsqIvQJCFaip = 0;
						vaOLEQQUpmwxCUHVVfYyinSMLJrN = this;
					}
					else
					{
						vaOLEQQUpmwxCUHVVfYyinSMLJrN = new VaOLEQQUpmwxCUHVVfYyinSMLJrN(0);
						vaOLEQQUpmwxCUHVVfYyinSMLJrN.eAlDsIUcLNYTunFITFXAEUJrYUOn = eAlDsIUcLNYTunFITFXAEUJrYUOn;
					}
					return vaOLEQQUpmwxCUHVVfYyinSMLJrN;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class XctRRSqnvyfViNCyzQlrBhwgbIZU : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int JMXvhAKqdifEfbHLjnmjfDaNpCwNA;

				private Platform_Custom.Button XwzVAEJbDCSPdPDznimrVexynXcH;

				private int rEQaFSHChoxhldzYNUtwGgzAaJZS;

				public Platform_InternalDriver_Base VzELphWPZVdYxYwRdpQVOfwNGTRM;

				private int ltuFidCcJBefefbIjVZSDeVCwbRXb;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return XwzVAEJbDCSPdPDznimrVexynXcH;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return XwzVAEJbDCSPdPDznimrVexynXcH;
					}
				}

				[DebuggerHidden]
				public XctRRSqnvyfViNCyzQlrBhwgbIZU(int P_0)
				{
					JMXvhAKqdifEfbHLjnmjfDaNpCwNA = P_0;
					rEQaFSHChoxhldzYNUtwGgzAaJZS = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					JMXvhAKqdifEfbHLjnmjfDaNpCwNA = -2;
				}

				private bool MoveNext()
				{
					int jMXvhAKqdifEfbHLjnmjfDaNpCwNA = JMXvhAKqdifEfbHLjnmjfDaNpCwNA;
					Platform_InternalDriver_Base vzELphWPZVdYxYwRdpQVOfwNGTRM = VzELphWPZVdYxYwRdpQVOfwNGTRM;
					switch (jMXvhAKqdifEfbHLjnmjfDaNpCwNA)
					{
					default:
						return false;
					case 0:
						JMXvhAKqdifEfbHLjnmjfDaNpCwNA = -1;
						if (vzELphWPZVdYxYwRdpQVOfwNGTRM.elements == null || vzELphWPZVdYxYwRdpQVOfwNGTRM.elements.buttons == null)
						{
							return false;
						}
						ltuFidCcJBefefbIjVZSDeVCwbRXb = 0;
						break;
					case 1:
						JMXvhAKqdifEfbHLjnmjfDaNpCwNA = -1;
						ltuFidCcJBefefbIjVZSDeVCwbRXb++;
						break;
					}
					if (ltuFidCcJBefefbIjVZSDeVCwbRXb < vzELphWPZVdYxYwRdpQVOfwNGTRM.elements.buttons.Length)
					{
						XwzVAEJbDCSPdPDznimrVexynXcH = vzELphWPZVdYxYwRdpQVOfwNGTRM.elements.buttons[ltuFidCcJBefefbIjVZSDeVCwbRXb];
						JMXvhAKqdifEfbHLjnmjfDaNpCwNA = 1;
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
					XctRRSqnvyfViNCyzQlrBhwgbIZU xctRRSqnvyfViNCyzQlrBhwgbIZU;
					if (JMXvhAKqdifEfbHLjnmjfDaNpCwNA == -2 && rEQaFSHChoxhldzYNUtwGgzAaJZS == Environment.CurrentManagedThreadId)
					{
						JMXvhAKqdifEfbHLjnmjfDaNpCwNA = 0;
						xctRRSqnvyfViNCyzQlrBhwgbIZU = this;
					}
					else
					{
						xctRRSqnvyfViNCyzQlrBhwgbIZU = new XctRRSqnvyfViNCyzQlrBhwgbIZU(0);
						xctRRSqnvyfViNCyzQlrBhwgbIZU.VzELphWPZVdYxYwRdpQVOfwNGTRM = VzELphWPZVdYxYwRdpQVOfwNGTRM;
					}
					return xctRRSqnvyfViNCyzQlrBhwgbIZU;
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

			[IteratorStateMachine(typeof(VaOLEQQUpmwxCUHVVfYyinSMLJrN))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new VaOLEQQUpmwxCUHVVfYyinSMLJrN(-2)
				{
					eAlDsIUcLNYTunFITFXAEUJrYUOn = this
				};
			}

			[IteratorStateMachine(typeof(XctRRSqnvyfViNCyzQlrBhwgbIZU))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new XctRRSqnvyfViNCyzQlrBhwgbIZU(-2)
				{
					VzELphWPZVdYxYwRdpQVOfwNGTRM = this
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
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
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
						qJZagAZjhaLZbLstuZlIbkTalFLE(elementCount);
						return elementCount;
					}

					internal void LLOfYxDmVcwrlTbgxBSmaaIGtfIZB(ElementCount_Base P_0)
					{
						base.qJZagAZjhaLZbLstuZlIbkTalFLE(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal bool UEpQFReFfiJMxldqBJJiNnIcJJmj(BridgedControllerHWInfo P_0)
					{
						if (!base.ZvIfrZHlPaocCwcPMJBmtNPEjEjM(P_0))
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
				private sealed class UITXQGGMUlxDEkrjgfSoDgPJpEms : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int infMYFrLMHPkbRxCGUGwrAXBxtan;

					private Axis RJgjomYDgUcimvBfBDhkhcFXuMpb;

					private int ICcIlxhkVsDpXwFXQnOiandEjTSE;

					public Elements uwcIsPLoTBUmfQHEWnqCnBojrOkn;

					private int NCZJCEyseAGEIaaPYrWIPpQgQqaLA;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return RJgjomYDgUcimvBfBDhkhcFXuMpb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RJgjomYDgUcimvBfBDhkhcFXuMpb;
						}
					}

					[DebuggerHidden]
					public UITXQGGMUlxDEkrjgfSoDgPJpEms(int P_0)
					{
						infMYFrLMHPkbRxCGUGwrAXBxtan = P_0;
						ICcIlxhkVsDpXwFXQnOiandEjTSE = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						infMYFrLMHPkbRxCGUGwrAXBxtan = -2;
					}

					private bool MoveNext()
					{
						int num = infMYFrLMHPkbRxCGUGwrAXBxtan;
						Elements elements = uwcIsPLoTBUmfQHEWnqCnBojrOkn;
						switch (num)
						{
						default:
							return false;
						case 0:
							infMYFrLMHPkbRxCGUGwrAXBxtan = -1;
							if (elements.axes == null)
							{
								return false;
							}
							NCZJCEyseAGEIaaPYrWIPpQgQqaLA = 0;
							break;
						case 1:
							infMYFrLMHPkbRxCGUGwrAXBxtan = -1;
							NCZJCEyseAGEIaaPYrWIPpQgQqaLA++;
							break;
						}
						if (NCZJCEyseAGEIaaPYrWIPpQgQqaLA < elements.axes.Length)
						{
							RJgjomYDgUcimvBfBDhkhcFXuMpb = elements.axes[NCZJCEyseAGEIaaPYrWIPpQgQqaLA];
							infMYFrLMHPkbRxCGUGwrAXBxtan = 1;
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
						UITXQGGMUlxDEkrjgfSoDgPJpEms uITXQGGMUlxDEkrjgfSoDgPJpEms;
						if (infMYFrLMHPkbRxCGUGwrAXBxtan == -2 && ICcIlxhkVsDpXwFXQnOiandEjTSE == Environment.CurrentManagedThreadId)
						{
							infMYFrLMHPkbRxCGUGwrAXBxtan = 0;
							uITXQGGMUlxDEkrjgfSoDgPJpEms = this;
						}
						else
						{
							uITXQGGMUlxDEkrjgfSoDgPJpEms = new UITXQGGMUlxDEkrjgfSoDgPJpEms(0);
							uITXQGGMUlxDEkrjgfSoDgPJpEms.uwcIsPLoTBUmfQHEWnqCnBojrOkn = uwcIsPLoTBUmfQHEWnqCnBojrOkn;
						}
						return uITXQGGMUlxDEkrjgfSoDgPJpEms;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class QvNpCerETCwNAPssMTcIMmVOsphs : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int yZUugxZCRzbhXBbGxsHFQGTTAbSI;

					private Button fwKbNtDDQJCAIdjOeuyrWqMDAWVsA;

					private int xJujKDhriUyUycsKGBSopRIlowjm;

					public Elements PxZPwyUhGuHZrBDRvmrElQQSBLLJA;

					private int iLKgjwfbiUCbjcSqhrMPMfZbHVzEb;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return fwKbNtDDQJCAIdjOeuyrWqMDAWVsA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return fwKbNtDDQJCAIdjOeuyrWqMDAWVsA;
						}
					}

					[DebuggerHidden]
					public QvNpCerETCwNAPssMTcIMmVOsphs(int P_0)
					{
						yZUugxZCRzbhXBbGxsHFQGTTAbSI = P_0;
						xJujKDhriUyUycsKGBSopRIlowjm = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						yZUugxZCRzbhXBbGxsHFQGTTAbSI = -2;
					}

					private bool MoveNext()
					{
						int num = yZUugxZCRzbhXBbGxsHFQGTTAbSI;
						Elements pxZPwyUhGuHZrBDRvmrElQQSBLLJA = PxZPwyUhGuHZrBDRvmrElQQSBLLJA;
						switch (num)
						{
						default:
							return false;
						case 0:
							yZUugxZCRzbhXBbGxsHFQGTTAbSI = -1;
							if (pxZPwyUhGuHZrBDRvmrElQQSBLLJA.buttons == null)
							{
								return false;
							}
							iLKgjwfbiUCbjcSqhrMPMfZbHVzEb = 0;
							break;
						case 1:
							yZUugxZCRzbhXBbGxsHFQGTTAbSI = -1;
							iLKgjwfbiUCbjcSqhrMPMfZbHVzEb++;
							break;
						}
						if (iLKgjwfbiUCbjcSqhrMPMfZbHVzEb < pxZPwyUhGuHZrBDRvmrElQQSBLLJA.buttons.Length)
						{
							fwKbNtDDQJCAIdjOeuyrWqMDAWVsA = pxZPwyUhGuHZrBDRvmrElQQSBLLJA.buttons[iLKgjwfbiUCbjcSqhrMPMfZbHVzEb];
							yZUugxZCRzbhXBbGxsHFQGTTAbSI = 1;
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
						QvNpCerETCwNAPssMTcIMmVOsphs qvNpCerETCwNAPssMTcIMmVOsphs;
						if (yZUugxZCRzbhXBbGxsHFQGTTAbSI == -2 && xJujKDhriUyUycsKGBSopRIlowjm == Environment.CurrentManagedThreadId)
						{
							yZUugxZCRzbhXBbGxsHFQGTTAbSI = 0;
							qvNpCerETCwNAPssMTcIMmVOsphs = this;
						}
						else
						{
							qvNpCerETCwNAPssMTcIMmVOsphs = new QvNpCerETCwNAPssMTcIMmVOsphs(0);
							qvNpCerETCwNAPssMTcIMmVOsphs.PxZPwyUhGuHZrBDRvmrElQQSBLLJA = PxZPwyUhGuHZrBDRvmrElQQSBLLJA;
						}
						return qvNpCerETCwNAPssMTcIMmVOsphs;
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
					[IteratorStateMachine(typeof(UITXQGGMUlxDEkrjgfSoDgPJpEms))]
					get
					{
						return new UITXQGGMUlxDEkrjgfSoDgPJpEms(-2)
						{
							uwcIsPLoTBUmfQHEWnqCnBojrOkn = this
						};
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(QvNpCerETCwNAPssMTcIMmVOsphs))]
					get
					{
						return new QvNpCerETCwNAPssMTcIMmVOsphs(-2)
						{
							PxZPwyUhGuHZrBDRvmrElQQSBLLJA = this
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

				public float axisUpperDeadZone;

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
						axisUpperDeadZone = axis.axisUpperDeadZone;
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

			private sealed class IjVNSKbGbsUgcKMrgHAaNaSGbvUR : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int OXuUmjbgWYpLSJEISXEnNJoZNmje;

				private Axis VPKCQbHBwLYcObiYwpeqZMpMzcMc;

				private int HxNJppMRuQhzmPVdaqEWrNguTPor;

				public Platform_SDL2_Base jBJfDQgoRSDYbYPXFVPGhZHdBpZcb;

				private int zXwCYCMzCHwkBloImBZWYuqcXFxd;

				private int JlwrwKfmFAVnzPNQgPqdVcBXSNSF;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return VPKCQbHBwLYcObiYwpeqZMpMzcMc;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return VPKCQbHBwLYcObiYwpeqZMpMzcMc;
					}
				}

				[DebuggerHidden]
				public IjVNSKbGbsUgcKMrgHAaNaSGbvUR(int P_0)
				{
					OXuUmjbgWYpLSJEISXEnNJoZNmje = P_0;
					HxNJppMRuQhzmPVdaqEWrNguTPor = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					OXuUmjbgWYpLSJEISXEnNJoZNmje = -2;
				}

				private bool MoveNext()
				{
					int oXuUmjbgWYpLSJEISXEnNJoZNmje = OXuUmjbgWYpLSJEISXEnNJoZNmje;
					Platform_SDL2_Base platform_SDL2_Base = jBJfDQgoRSDYbYPXFVPGhZHdBpZcb;
					switch (oXuUmjbgWYpLSJEISXEnNJoZNmje)
					{
					default:
						return false;
					case 0:
						OXuUmjbgWYpLSJEISXEnNJoZNmje = -1;
						if (platform_SDL2_Base.elements == null || platform_SDL2_Base.elements.axes == null)
						{
							return false;
						}
						zXwCYCMzCHwkBloImBZWYuqcXFxd = platform_SDL2_Base.elements.axes.Length;
						JlwrwKfmFAVnzPNQgPqdVcBXSNSF = 0;
						break;
					case 1:
						OXuUmjbgWYpLSJEISXEnNJoZNmje = -1;
						JlwrwKfmFAVnzPNQgPqdVcBXSNSF++;
						break;
					}
					if (JlwrwKfmFAVnzPNQgPqdVcBXSNSF < zXwCYCMzCHwkBloImBZWYuqcXFxd)
					{
						VPKCQbHBwLYcObiYwpeqZMpMzcMc = platform_SDL2_Base.elements.axes[JlwrwKfmFAVnzPNQgPqdVcBXSNSF];
						OXuUmjbgWYpLSJEISXEnNJoZNmje = 1;
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
					IjVNSKbGbsUgcKMrgHAaNaSGbvUR ijVNSKbGbsUgcKMrgHAaNaSGbvUR;
					if (OXuUmjbgWYpLSJEISXEnNJoZNmje == -2 && HxNJppMRuQhzmPVdaqEWrNguTPor == Environment.CurrentManagedThreadId)
					{
						OXuUmjbgWYpLSJEISXEnNJoZNmje = 0;
						ijVNSKbGbsUgcKMrgHAaNaSGbvUR = this;
					}
					else
					{
						ijVNSKbGbsUgcKMrgHAaNaSGbvUR = new IjVNSKbGbsUgcKMrgHAaNaSGbvUR(0);
						ijVNSKbGbsUgcKMrgHAaNaSGbvUR.jBJfDQgoRSDYbYPXFVPGhZHdBpZcb = jBJfDQgoRSDYbYPXFVPGhZHdBpZcb;
					}
					return ijVNSKbGbsUgcKMrgHAaNaSGbvUR;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class bOxycFyMgGazWeleUBuyHgtXjaHq : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int ZarQTrVnebxtHSKrDVhxDiRLANpR;

				private Button IyzmsdVZlCqhhBxilGSsiFLaSnbO;

				private int WQbKDnuqOoqvRLUflDECINvEverp;

				public Platform_SDL2_Base yBoaypjqeXARFwQHuAfQiVYaDXqcb;

				private int gDMiGjQEWxaGoEhrzVtHSslAejXn;

				private int ziiQSSoixdsfKqfkvcLSVlqSAEZG;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return IyzmsdVZlCqhhBxilGSsiFLaSnbO;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return IyzmsdVZlCqhhBxilGSsiFLaSnbO;
					}
				}

				[DebuggerHidden]
				public bOxycFyMgGazWeleUBuyHgtXjaHq(int P_0)
				{
					ZarQTrVnebxtHSKrDVhxDiRLANpR = P_0;
					WQbKDnuqOoqvRLUflDECINvEverp = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					ZarQTrVnebxtHSKrDVhxDiRLANpR = -2;
				}

				private bool MoveNext()
				{
					int zarQTrVnebxtHSKrDVhxDiRLANpR = ZarQTrVnebxtHSKrDVhxDiRLANpR;
					Platform_SDL2_Base platform_SDL2_Base = yBoaypjqeXARFwQHuAfQiVYaDXqcb;
					switch (zarQTrVnebxtHSKrDVhxDiRLANpR)
					{
					default:
						return false;
					case 0:
						ZarQTrVnebxtHSKrDVhxDiRLANpR = -1;
						if (platform_SDL2_Base.elements == null || platform_SDL2_Base.elements.buttons == null)
						{
							return false;
						}
						gDMiGjQEWxaGoEhrzVtHSslAejXn = platform_SDL2_Base.elements.buttons.Length;
						ziiQSSoixdsfKqfkvcLSVlqSAEZG = 0;
						break;
					case 1:
						ZarQTrVnebxtHSKrDVhxDiRLANpR = -1;
						ziiQSSoixdsfKqfkvcLSVlqSAEZG++;
						break;
					}
					if (ziiQSSoixdsfKqfkvcLSVlqSAEZG < gDMiGjQEWxaGoEhrzVtHSslAejXn)
					{
						IyzmsdVZlCqhhBxilGSsiFLaSnbO = platform_SDL2_Base.elements.buttons[ziiQSSoixdsfKqfkvcLSVlqSAEZG];
						ZarQTrVnebxtHSKrDVhxDiRLANpR = 1;
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
					bOxycFyMgGazWeleUBuyHgtXjaHq bOxycFyMgGazWeleUBuyHgtXjaHq2;
					if (ZarQTrVnebxtHSKrDVhxDiRLANpR == -2 && WQbKDnuqOoqvRLUflDECINvEverp == Environment.CurrentManagedThreadId)
					{
						ZarQTrVnebxtHSKrDVhxDiRLANpR = 0;
						bOxycFyMgGazWeleUBuyHgtXjaHq2 = this;
					}
					else
					{
						bOxycFyMgGazWeleUBuyHgtXjaHq2 = new bOxycFyMgGazWeleUBuyHgtXjaHq(0);
						bOxycFyMgGazWeleUBuyHgtXjaHq2.yBoaypjqeXARFwQHuAfQiVYaDXqcb = yBoaypjqeXARFwQHuAfQiVYaDXqcb;
					}
					return bOxycFyMgGazWeleUBuyHgtXjaHq2;
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
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
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

			[IteratorStateMachine(typeof(IjVNSKbGbsUgcKMrgHAaNaSGbvUR))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return new IjVNSKbGbsUgcKMrgHAaNaSGbvUR(-2)
				{
					jBJfDQgoRSDYbYPXFVPGhZHdBpZcb = this
				};
			}

			[IteratorStateMachine(typeof(bOxycFyMgGazWeleUBuyHgtXjaHq))]
			internal IEnumerable<Button> IterateButtons()
			{
				return new bOxycFyMgGazWeleUBuyHgtXjaHq(-2)
				{
					yBoaypjqeXARFwQHuAfQiVYaDXqcb = this
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

			private sealed class PKpFDjBMIaCODAuqHbdkxLacbCApB : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int jprHHWGobGgoqjnDnnPyctaKgOpuB;

				private Platform_Custom.Axis BJcqylAcdgHjdifzCIvXiZGhVtSKA;

				private int UxaqNEGmjLANEzzNWzlaoanekEXc;

				public Platform_WebGL_Base JkTUeqEiBGWKfLiXyaSfKGyNuMWDA;

				private int TTzTayXHJziKiNNHHLzpJCUkCfFN;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return BJcqylAcdgHjdifzCIvXiZGhVtSKA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return BJcqylAcdgHjdifzCIvXiZGhVtSKA;
					}
				}

				[DebuggerHidden]
				public PKpFDjBMIaCODAuqHbdkxLacbCApB(int P_0)
				{
					jprHHWGobGgoqjnDnnPyctaKgOpuB = P_0;
					UxaqNEGmjLANEzzNWzlaoanekEXc = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					jprHHWGobGgoqjnDnnPyctaKgOpuB = -2;
				}

				private bool MoveNext()
				{
					int num = jprHHWGobGgoqjnDnnPyctaKgOpuB;
					Platform_WebGL_Base jkTUeqEiBGWKfLiXyaSfKGyNuMWDA = JkTUeqEiBGWKfLiXyaSfKGyNuMWDA;
					switch (num)
					{
					default:
						return false;
					case 0:
						jprHHWGobGgoqjnDnnPyctaKgOpuB = -1;
						if (jkTUeqEiBGWKfLiXyaSfKGyNuMWDA.elements == null || jkTUeqEiBGWKfLiXyaSfKGyNuMWDA.elements.axes == null)
						{
							return false;
						}
						TTzTayXHJziKiNNHHLzpJCUkCfFN = 0;
						break;
					case 1:
						jprHHWGobGgoqjnDnnPyctaKgOpuB = -1;
						TTzTayXHJziKiNNHHLzpJCUkCfFN++;
						break;
					}
					if (TTzTayXHJziKiNNHHLzpJCUkCfFN < jkTUeqEiBGWKfLiXyaSfKGyNuMWDA.elements.axes.Length)
					{
						BJcqylAcdgHjdifzCIvXiZGhVtSKA = jkTUeqEiBGWKfLiXyaSfKGyNuMWDA.elements.axes[TTzTayXHJziKiNNHHLzpJCUkCfFN];
						jprHHWGobGgoqjnDnnPyctaKgOpuB = 1;
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
					PKpFDjBMIaCODAuqHbdkxLacbCApB pKpFDjBMIaCODAuqHbdkxLacbCApB;
					if (jprHHWGobGgoqjnDnnPyctaKgOpuB == -2 && UxaqNEGmjLANEzzNWzlaoanekEXc == Environment.CurrentManagedThreadId)
					{
						jprHHWGobGgoqjnDnnPyctaKgOpuB = 0;
						pKpFDjBMIaCODAuqHbdkxLacbCApB = this;
					}
					else
					{
						pKpFDjBMIaCODAuqHbdkxLacbCApB = new PKpFDjBMIaCODAuqHbdkxLacbCApB(0);
						pKpFDjBMIaCODAuqHbdkxLacbCApB.JkTUeqEiBGWKfLiXyaSfKGyNuMWDA = JkTUeqEiBGWKfLiXyaSfKGyNuMWDA;
					}
					return pKpFDjBMIaCODAuqHbdkxLacbCApB;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class kfyJndNQsIETXDKGOHGPqlUCWqbJA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int dyeRZeJjSiQbjwaHxaWcaYFWKusaA;

				private Platform_Custom.Button xaiCKJbZhqHkSQaPUDguHTYfgUkE;

				private int ecWAJzZVeoettzcsCfiUkllzZZZaA;

				public Platform_WebGL_Base OymfMqslcaVJDxKGoCINWqdoSmQN;

				private int SEcZHcnOMCsXBFjhIUKTlUYjrngX;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return xaiCKJbZhqHkSQaPUDguHTYfgUkE;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return xaiCKJbZhqHkSQaPUDguHTYfgUkE;
					}
				}

				[DebuggerHidden]
				public kfyJndNQsIETXDKGOHGPqlUCWqbJA(int P_0)
				{
					dyeRZeJjSiQbjwaHxaWcaYFWKusaA = P_0;
					ecWAJzZVeoettzcsCfiUkllzZZZaA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					dyeRZeJjSiQbjwaHxaWcaYFWKusaA = -2;
				}

				private bool MoveNext()
				{
					int num = dyeRZeJjSiQbjwaHxaWcaYFWKusaA;
					Platform_WebGL_Base oymfMqslcaVJDxKGoCINWqdoSmQN = OymfMqslcaVJDxKGoCINWqdoSmQN;
					switch (num)
					{
					default:
						return false;
					case 0:
						dyeRZeJjSiQbjwaHxaWcaYFWKusaA = -1;
						if (oymfMqslcaVJDxKGoCINWqdoSmQN.elements == null || oymfMqslcaVJDxKGoCINWqdoSmQN.elements.buttons == null)
						{
							return false;
						}
						SEcZHcnOMCsXBFjhIUKTlUYjrngX = 0;
						break;
					case 1:
						dyeRZeJjSiQbjwaHxaWcaYFWKusaA = -1;
						SEcZHcnOMCsXBFjhIUKTlUYjrngX++;
						break;
					}
					if (SEcZHcnOMCsXBFjhIUKTlUYjrngX < oymfMqslcaVJDxKGoCINWqdoSmQN.elements.buttons.Length)
					{
						xaiCKJbZhqHkSQaPUDguHTYfgUkE = oymfMqslcaVJDxKGoCINWqdoSmQN.elements.buttons[SEcZHcnOMCsXBFjhIUKTlUYjrngX];
						dyeRZeJjSiQbjwaHxaWcaYFWKusaA = 1;
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
					kfyJndNQsIETXDKGOHGPqlUCWqbJA kfyJndNQsIETXDKGOHGPqlUCWqbJA2;
					if (dyeRZeJjSiQbjwaHxaWcaYFWKusaA == -2 && ecWAJzZVeoettzcsCfiUkllzZZZaA == Environment.CurrentManagedThreadId)
					{
						dyeRZeJjSiQbjwaHxaWcaYFWKusaA = 0;
						kfyJndNQsIETXDKGOHGPqlUCWqbJA2 = this;
					}
					else
					{
						kfyJndNQsIETXDKGOHGPqlUCWqbJA2 = new kfyJndNQsIETXDKGOHGPqlUCWqbJA(0);
						kfyJndNQsIETXDKGOHGPqlUCWqbJA2.OymfMqslcaVJDxKGoCINWqdoSmQN = OymfMqslcaVJDxKGoCINWqdoSmQN;
					}
					return kfyJndNQsIETXDKGOHGPqlUCWqbJA2;
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

			[IteratorStateMachine(typeof(PKpFDjBMIaCODAuqHbdkxLacbCApB))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new PKpFDjBMIaCODAuqHbdkxLacbCApB(-2)
				{
					JkTUeqEiBGWKfLiXyaSfKGyNuMWDA = this
				};
			}

			[IteratorStateMachine(typeof(kfyJndNQsIETXDKGOHGPqlUCWqbJA))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new kfyJndNQsIETXDKGOHGPqlUCWqbJA(-2)
				{
					OymfMqslcaVJDxKGoCINWqdoSmQN = this
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
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
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

			private sealed class JVQHeFdCIbJjglwKhYCqbTlcZXzC : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int aGmKBNBPMIyTUhBKdPZKqViMgLET;

				private Platform_Custom.Axis CMMUOJzSOhwvJbMjpucBitTMndlx;

				private int KkBmOnbZQpJhdWQsRJsJzxowDxeM;

				public Platform_AppleGCController_Base ikhacfKKXalucLMotQmZQMYSAQtAb;

				private int cXUARJxnuPEWnqAnavCZnTccSIzw;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return CMMUOJzSOhwvJbMjpucBitTMndlx;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return CMMUOJzSOhwvJbMjpucBitTMndlx;
					}
				}

				[DebuggerHidden]
				public JVQHeFdCIbJjglwKhYCqbTlcZXzC(int P_0)
				{
					aGmKBNBPMIyTUhBKdPZKqViMgLET = P_0;
					KkBmOnbZQpJhdWQsRJsJzxowDxeM = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					aGmKBNBPMIyTUhBKdPZKqViMgLET = -2;
				}

				private bool MoveNext()
				{
					int num = aGmKBNBPMIyTUhBKdPZKqViMgLET;
					Platform_AppleGCController_Base platform_AppleGCController_Base = ikhacfKKXalucLMotQmZQMYSAQtAb;
					switch (num)
					{
					default:
						return false;
					case 0:
						aGmKBNBPMIyTUhBKdPZKqViMgLET = -1;
						if (platform_AppleGCController_Base.elements == null || platform_AppleGCController_Base.elements.axes == null)
						{
							return false;
						}
						cXUARJxnuPEWnqAnavCZnTccSIzw = 0;
						break;
					case 1:
						aGmKBNBPMIyTUhBKdPZKqViMgLET = -1;
						cXUARJxnuPEWnqAnavCZnTccSIzw++;
						break;
					}
					if (cXUARJxnuPEWnqAnavCZnTccSIzw < platform_AppleGCController_Base.elements.axes.Length)
					{
						CMMUOJzSOhwvJbMjpucBitTMndlx = platform_AppleGCController_Base.elements.axes[cXUARJxnuPEWnqAnavCZnTccSIzw];
						aGmKBNBPMIyTUhBKdPZKqViMgLET = 1;
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
					JVQHeFdCIbJjglwKhYCqbTlcZXzC jVQHeFdCIbJjglwKhYCqbTlcZXzC;
					if (aGmKBNBPMIyTUhBKdPZKqViMgLET == -2 && KkBmOnbZQpJhdWQsRJsJzxowDxeM == Environment.CurrentManagedThreadId)
					{
						aGmKBNBPMIyTUhBKdPZKqViMgLET = 0;
						jVQHeFdCIbJjglwKhYCqbTlcZXzC = this;
					}
					else
					{
						jVQHeFdCIbJjglwKhYCqbTlcZXzC = new JVQHeFdCIbJjglwKhYCqbTlcZXzC(0);
						jVQHeFdCIbJjglwKhYCqbTlcZXzC.ikhacfKKXalucLMotQmZQMYSAQtAb = ikhacfKKXalucLMotQmZQMYSAQtAb;
					}
					return jVQHeFdCIbJjglwKhYCqbTlcZXzC;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class GcgDcPdfILGNCZMRTJbTzEhQLqrH : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int XWJAfEhChMpuYZNnZUYgkHNhvKdq;

				private Platform_Custom.Button wTobmrOAqhVhbXJczGCeQGJdFzrgA;

				private int FiHsBUCCxaTcmomMvgrwBhnVEsWaA;

				public Platform_AppleGCController_Base tkeeXKtSYixTYToJEZkdWQATQOgK;

				private int PtIpLnYXHRyzVzuYgLhelHmHnNie;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return wTobmrOAqhVhbXJczGCeQGJdFzrgA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return wTobmrOAqhVhbXJczGCeQGJdFzrgA;
					}
				}

				[DebuggerHidden]
				public GcgDcPdfILGNCZMRTJbTzEhQLqrH(int P_0)
				{
					XWJAfEhChMpuYZNnZUYgkHNhvKdq = P_0;
					FiHsBUCCxaTcmomMvgrwBhnVEsWaA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					XWJAfEhChMpuYZNnZUYgkHNhvKdq = -2;
				}

				private bool MoveNext()
				{
					int xWJAfEhChMpuYZNnZUYgkHNhvKdq = XWJAfEhChMpuYZNnZUYgkHNhvKdq;
					Platform_AppleGCController_Base platform_AppleGCController_Base = tkeeXKtSYixTYToJEZkdWQATQOgK;
					switch (xWJAfEhChMpuYZNnZUYgkHNhvKdq)
					{
					default:
						return false;
					case 0:
						XWJAfEhChMpuYZNnZUYgkHNhvKdq = -1;
						if (platform_AppleGCController_Base.elements == null || platform_AppleGCController_Base.elements.buttons == null)
						{
							return false;
						}
						PtIpLnYXHRyzVzuYgLhelHmHnNie = 0;
						break;
					case 1:
						XWJAfEhChMpuYZNnZUYgkHNhvKdq = -1;
						PtIpLnYXHRyzVzuYgLhelHmHnNie++;
						break;
					}
					if (PtIpLnYXHRyzVzuYgLhelHmHnNie < platform_AppleGCController_Base.elements.buttons.Length)
					{
						wTobmrOAqhVhbXJczGCeQGJdFzrgA = platform_AppleGCController_Base.elements.buttons[PtIpLnYXHRyzVzuYgLhelHmHnNie];
						XWJAfEhChMpuYZNnZUYgkHNhvKdq = 1;
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
					GcgDcPdfILGNCZMRTJbTzEhQLqrH gcgDcPdfILGNCZMRTJbTzEhQLqrH;
					if (XWJAfEhChMpuYZNnZUYgkHNhvKdq == -2 && FiHsBUCCxaTcmomMvgrwBhnVEsWaA == Environment.CurrentManagedThreadId)
					{
						XWJAfEhChMpuYZNnZUYgkHNhvKdq = 0;
						gcgDcPdfILGNCZMRTJbTzEhQLqrH = this;
					}
					else
					{
						gcgDcPdfILGNCZMRTJbTzEhQLqrH = new GcgDcPdfILGNCZMRTJbTzEhQLqrH(0);
						gcgDcPdfILGNCZMRTJbTzEhQLqrH.tkeeXKtSYixTYToJEZkdWQATQOgK = tkeeXKtSYixTYToJEZkdWQATQOgK;
					}
					return gcgDcPdfILGNCZMRTJbTzEhQLqrH;
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

			[IteratorStateMachine(typeof(JVQHeFdCIbJjglwKhYCqbTlcZXzC))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new JVQHeFdCIbJjglwKhYCqbTlcZXzC(-2)
				{
					ikhacfKKXalucLMotQmZQMYSAQtAb = this
				};
			}

			[IteratorStateMachine(typeof(GcgDcPdfILGNCZMRTJbTzEhQLqrH))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new GcgDcPdfILGNCZMRTJbTzEhQLqrH(-2)
				{
					tkeeXKtSYixTYToJEZkdWQATQOgK = this
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
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
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
					axis.axisUpperDeadZone = 0f;
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

			private sealed class LwwOxEaMRVnglqeFSbayrJkXGktdA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int TVPbjtzTIWkSGAELoMxCUmAPdmud;

				private Platform_Custom.Axis VOlvSwTckeUqlYihnwnYDTbVxuWf;

				private int RHChGwmcgcOwRNEUGNveCdwYYswV;

				public Platform_WindowsWGI_Base SAKgvRCBIaXDstSdcyKREbuvgcpJA;

				private int kwigVABVEUTgAliyRTdHcghLCKIib;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return VOlvSwTckeUqlYihnwnYDTbVxuWf;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return VOlvSwTckeUqlYihnwnYDTbVxuWf;
					}
				}

				[DebuggerHidden]
				public LwwOxEaMRVnglqeFSbayrJkXGktdA(int P_0)
				{
					TVPbjtzTIWkSGAELoMxCUmAPdmud = P_0;
					RHChGwmcgcOwRNEUGNveCdwYYswV = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					TVPbjtzTIWkSGAELoMxCUmAPdmud = -2;
				}

				private bool MoveNext()
				{
					int tVPbjtzTIWkSGAELoMxCUmAPdmud = TVPbjtzTIWkSGAELoMxCUmAPdmud;
					Platform_WindowsWGI_Base sAKgvRCBIaXDstSdcyKREbuvgcpJA = SAKgvRCBIaXDstSdcyKREbuvgcpJA;
					switch (tVPbjtzTIWkSGAELoMxCUmAPdmud)
					{
					default:
						return false;
					case 0:
						TVPbjtzTIWkSGAELoMxCUmAPdmud = -1;
						if (sAKgvRCBIaXDstSdcyKREbuvgcpJA.elements == null || sAKgvRCBIaXDstSdcyKREbuvgcpJA.elements.axes == null)
						{
							return false;
						}
						kwigVABVEUTgAliyRTdHcghLCKIib = 0;
						break;
					case 1:
						TVPbjtzTIWkSGAELoMxCUmAPdmud = -1;
						kwigVABVEUTgAliyRTdHcghLCKIib++;
						break;
					}
					if (kwigVABVEUTgAliyRTdHcghLCKIib < sAKgvRCBIaXDstSdcyKREbuvgcpJA.elements.axes.Length)
					{
						VOlvSwTckeUqlYihnwnYDTbVxuWf = sAKgvRCBIaXDstSdcyKREbuvgcpJA.elements.axes[kwigVABVEUTgAliyRTdHcghLCKIib];
						TVPbjtzTIWkSGAELoMxCUmAPdmud = 1;
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
					LwwOxEaMRVnglqeFSbayrJkXGktdA lwwOxEaMRVnglqeFSbayrJkXGktdA;
					if (TVPbjtzTIWkSGAELoMxCUmAPdmud == -2 && RHChGwmcgcOwRNEUGNveCdwYYswV == Environment.CurrentManagedThreadId)
					{
						TVPbjtzTIWkSGAELoMxCUmAPdmud = 0;
						lwwOxEaMRVnglqeFSbayrJkXGktdA = this;
					}
					else
					{
						lwwOxEaMRVnglqeFSbayrJkXGktdA = new LwwOxEaMRVnglqeFSbayrJkXGktdA(0);
						lwwOxEaMRVnglqeFSbayrJkXGktdA.SAKgvRCBIaXDstSdcyKREbuvgcpJA = SAKgvRCBIaXDstSdcyKREbuvgcpJA;
					}
					return lwwOxEaMRVnglqeFSbayrJkXGktdA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class VGkfPLrvNdmstljXBxLiogVGmfsN : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int pVlfhBLKjsuraFGxLwVbKelOeIpFA;

				private Platform_Custom.Button eyScNehPkxLIQqUULqicSXbiJmygA;

				private int vCaTlqvNXQuYTVpCpClOiVYuFquA;

				public Platform_WindowsWGI_Base HOAibEvIEazSHNIZjudZPjhUWjPH;

				private int mXYUIQFRyfKIzBqEGmMeOCZFogb;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return eyScNehPkxLIQqUULqicSXbiJmygA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return eyScNehPkxLIQqUULqicSXbiJmygA;
					}
				}

				[DebuggerHidden]
				public VGkfPLrvNdmstljXBxLiogVGmfsN(int P_0)
				{
					pVlfhBLKjsuraFGxLwVbKelOeIpFA = P_0;
					vCaTlqvNXQuYTVpCpClOiVYuFquA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					pVlfhBLKjsuraFGxLwVbKelOeIpFA = -2;
				}

				private bool MoveNext()
				{
					int num = pVlfhBLKjsuraFGxLwVbKelOeIpFA;
					Platform_WindowsWGI_Base hOAibEvIEazSHNIZjudZPjhUWjPH = HOAibEvIEazSHNIZjudZPjhUWjPH;
					switch (num)
					{
					default:
						return false;
					case 0:
						pVlfhBLKjsuraFGxLwVbKelOeIpFA = -1;
						if (hOAibEvIEazSHNIZjudZPjhUWjPH.elements == null || hOAibEvIEazSHNIZjudZPjhUWjPH.elements.buttons == null)
						{
							return false;
						}
						mXYUIQFRyfKIzBqEGmMeOCZFogb = 0;
						break;
					case 1:
						pVlfhBLKjsuraFGxLwVbKelOeIpFA = -1;
						mXYUIQFRyfKIzBqEGmMeOCZFogb++;
						break;
					}
					if (mXYUIQFRyfKIzBqEGmMeOCZFogb < hOAibEvIEazSHNIZjudZPjhUWjPH.elements.buttons.Length)
					{
						eyScNehPkxLIQqUULqicSXbiJmygA = hOAibEvIEazSHNIZjudZPjhUWjPH.elements.buttons[mXYUIQFRyfKIzBqEGmMeOCZFogb];
						pVlfhBLKjsuraFGxLwVbKelOeIpFA = 1;
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
					VGkfPLrvNdmstljXBxLiogVGmfsN vGkfPLrvNdmstljXBxLiogVGmfsN;
					if (pVlfhBLKjsuraFGxLwVbKelOeIpFA == -2 && vCaTlqvNXQuYTVpCpClOiVYuFquA == Environment.CurrentManagedThreadId)
					{
						pVlfhBLKjsuraFGxLwVbKelOeIpFA = 0;
						vGkfPLrvNdmstljXBxLiogVGmfsN = this;
					}
					else
					{
						vGkfPLrvNdmstljXBxLiogVGmfsN = new VGkfPLrvNdmstljXBxLiogVGmfsN(0);
						vGkfPLrvNdmstljXBxLiogVGmfsN.HOAibEvIEazSHNIZjudZPjhUWjPH = HOAibEvIEazSHNIZjudZPjhUWjPH;
					}
					return vGkfPLrvNdmstljXBxLiogVGmfsN;
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

			[IteratorStateMachine(typeof(LwwOxEaMRVnglqeFSbayrJkXGktdA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new LwwOxEaMRVnglqeFSbayrJkXGktdA(-2)
				{
					SAKgvRCBIaXDstSdcyKREbuvgcpJA = this
				};
			}

			[IteratorStateMachine(typeof(VGkfPLrvNdmstljXBxLiogVGmfsN))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new VGkfPLrvNdmstljXBxLiogVGmfsN(-2)
				{
					HOAibEvIEazSHNIZjudZPjhUWjPH = this
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
						array[i].upperDeadZone = axes_orig[i].axisUpperDeadZone;
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
					axis.axisUpperDeadZone = 0f;
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

		private sealed class MPFqvbOknxHfQHjNdVrjTDiMbPkvA : IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerable, IEnumerator<IControllerElementIdentifierCommon_Internal>, IEnumerator, IDisposable
		{
			private int njbGjdBLnYLHRKaWfUIdFogtHJrQ;

			private IControllerElementIdentifierCommon_Internal zaIjtGabmGQygIrqDxrQlJtPfmPUA;

			private int pEnMgfMJnbFCCToIFdbCyINoRRav;

			public HardwareJoystickMap UpIwScPqWdMUJBWRFoWTaKfncNut;

			private int kgSPrLXuIuHOyzizHhpehrmfRXjC;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
			{
				[DebuggerHidden]
				get
				{
					return zaIjtGabmGQygIrqDxrQlJtPfmPUA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return zaIjtGabmGQygIrqDxrQlJtPfmPUA;
				}
			}

			[DebuggerHidden]
			public MPFqvbOknxHfQHjNdVrjTDiMbPkvA(int P_0)
			{
				njbGjdBLnYLHRKaWfUIdFogtHJrQ = P_0;
				pEnMgfMJnbFCCToIFdbCyINoRRav = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				njbGjdBLnYLHRKaWfUIdFogtHJrQ = -2;
			}

			private bool MoveNext()
			{
				int num = njbGjdBLnYLHRKaWfUIdFogtHJrQ;
				HardwareJoystickMap upIwScPqWdMUJBWRFoWTaKfncNut = UpIwScPqWdMUJBWRFoWTaKfncNut;
				switch (num)
				{
				default:
					return false;
				case 0:
					njbGjdBLnYLHRKaWfUIdFogtHJrQ = -1;
					if (upIwScPqWdMUJBWRFoWTaKfncNut.elementIdentifiers == null)
					{
						return false;
					}
					kgSPrLXuIuHOyzizHhpehrmfRXjC = 0;
					break;
				case 1:
					njbGjdBLnYLHRKaWfUIdFogtHJrQ = -1;
					kgSPrLXuIuHOyzizHhpehrmfRXjC++;
					break;
				}
				if (kgSPrLXuIuHOyzizHhpehrmfRXjC < upIwScPqWdMUJBWRFoWTaKfncNut.elementIdentifiers.Length)
				{
					zaIjtGabmGQygIrqDxrQlJtPfmPUA = upIwScPqWdMUJBWRFoWTaKfncNut.elementIdentifiers[kgSPrLXuIuHOyzizHhpehrmfRXjC];
					njbGjdBLnYLHRKaWfUIdFogtHJrQ = 1;
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
				MPFqvbOknxHfQHjNdVrjTDiMbPkvA mPFqvbOknxHfQHjNdVrjTDiMbPkvA;
				if (njbGjdBLnYLHRKaWfUIdFogtHJrQ == -2 && pEnMgfMJnbFCCToIFdbCyINoRRav == Environment.CurrentManagedThreadId)
				{
					njbGjdBLnYLHRKaWfUIdFogtHJrQ = 0;
					mPFqvbOknxHfQHjNdVrjTDiMbPkvA = this;
				}
				else
				{
					mPFqvbOknxHfQHjNdVrjTDiMbPkvA = new MPFqvbOknxHfQHjNdVrjTDiMbPkvA(0);
					mPFqvbOknxHfQHjNdVrjTDiMbPkvA.UpIwScPqWdMUJBWRFoWTaKfncNut = UpIwScPqWdMUJBWRFoWTaKfncNut;
				}
				return mPFqvbOknxHfQHjNdVrjTDiMbPkvA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<IControllerElementIdentifierCommon_Internal>)this).GetEnumerator();
			}
		}

		private sealed class TuKXsmSZIHhSTKqJqwUewOtkXijA : IEnumerable<ControllerElementIdentifier>, IEnumerable, IEnumerator<ControllerElementIdentifier>, IEnumerator, IDisposable
		{
			private int UUVOjnuMsFCElYlUbxHArvROSZfq;

			private ControllerElementIdentifier CFdvrMBXMRYwdhUMCijGNHJSkIJT;

			private int ZLNkUuSsitkaUkAuGeiZCWimfgfH;

			public HardwareJoystickMap vPIgHskNxQugUDFdkAVMapCVXynDA;

			private int wIZFLHihcGiFLgUrvWsnwORvNCOh;

			ControllerElementIdentifier IEnumerator<ControllerElementIdentifier>.Current
			{
				[DebuggerHidden]
				get
				{
					return CFdvrMBXMRYwdhUMCijGNHJSkIJT;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return CFdvrMBXMRYwdhUMCijGNHJSkIJT;
				}
			}

			[DebuggerHidden]
			public TuKXsmSZIHhSTKqJqwUewOtkXijA(int P_0)
			{
				UUVOjnuMsFCElYlUbxHArvROSZfq = P_0;
				ZLNkUuSsitkaUkAuGeiZCWimfgfH = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				UUVOjnuMsFCElYlUbxHArvROSZfq = -2;
			}

			private bool MoveNext()
			{
				int uUVOjnuMsFCElYlUbxHArvROSZfq = UUVOjnuMsFCElYlUbxHArvROSZfq;
				HardwareJoystickMap hardwareJoystickMap = vPIgHskNxQugUDFdkAVMapCVXynDA;
				switch (uUVOjnuMsFCElYlUbxHArvROSZfq)
				{
				default:
					return false;
				case 0:
					UUVOjnuMsFCElYlUbxHArvROSZfq = -1;
					if (hardwareJoystickMap.elementIdentifiers == null)
					{
						return false;
					}
					wIZFLHihcGiFLgUrvWsnwORvNCOh = 0;
					break;
				case 1:
					UUVOjnuMsFCElYlUbxHArvROSZfq = -1;
					wIZFLHihcGiFLgUrvWsnwORvNCOh++;
					break;
				}
				if (wIZFLHihcGiFLgUrvWsnwORvNCOh < hardwareJoystickMap.elementIdentifiers.Length)
				{
					CFdvrMBXMRYwdhUMCijGNHJSkIJT = hardwareJoystickMap.elementIdentifiers[wIZFLHihcGiFLgUrvWsnwORvNCOh];
					UUVOjnuMsFCElYlUbxHArvROSZfq = 1;
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
				TuKXsmSZIHhSTKqJqwUewOtkXijA tuKXsmSZIHhSTKqJqwUewOtkXijA;
				if (UUVOjnuMsFCElYlUbxHArvROSZfq == -2 && ZLNkUuSsitkaUkAuGeiZCWimfgfH == Environment.CurrentManagedThreadId)
				{
					UUVOjnuMsFCElYlUbxHArvROSZfq = 0;
					tuKXsmSZIHhSTKqJqwUewOtkXijA = this;
				}
				else
				{
					tuKXsmSZIHhSTKqJqwUewOtkXijA = new TuKXsmSZIHhSTKqJqwUewOtkXijA(0);
					tuKXsmSZIHhSTKqJqwUewOtkXijA.vPIgHskNxQugUDFdkAVMapCVXynDA = vPIgHskNxQugUDFdkAVMapCVXynDA;
				}
				return tuKXsmSZIHhSTKqJqwUewOtkXijA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerElementIdentifier>)this).GetEnumerator();
			}
		}

		private sealed class wFZnWcctyePdDROyuOhsCGMMfJqHA : IEnumerable<JoystickType>, IEnumerable, IEnumerator<JoystickType>, IEnumerator, IDisposable
		{
			private int ZclYmxLkKSsoONqPjAESznybbpgN;

			private JoystickType SAOiWOAfuBOPjEgUvuyUcBSGSHXX;

			private int oixcqjEJihUUbUFRRXJlbnnMqhQc;

			public HardwareJoystickMap AzIgWEqjTUqcYNHMjoOgFfnUhlLR;

			private int glABSaTXwrdxiTBBrzTJoXGWLjXL;

			JoystickType IEnumerator<JoystickType>.Current
			{
				[DebuggerHidden]
				get
				{
					return SAOiWOAfuBOPjEgUvuyUcBSGSHXX;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return SAOiWOAfuBOPjEgUvuyUcBSGSHXX;
				}
			}

			[DebuggerHidden]
			public wFZnWcctyePdDROyuOhsCGMMfJqHA(int P_0)
			{
				ZclYmxLkKSsoONqPjAESznybbpgN = P_0;
				oixcqjEJihUUbUFRRXJlbnnMqhQc = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				ZclYmxLkKSsoONqPjAESznybbpgN = -2;
			}

			private bool MoveNext()
			{
				int zclYmxLkKSsoONqPjAESznybbpgN = ZclYmxLkKSsoONqPjAESznybbpgN;
				HardwareJoystickMap azIgWEqjTUqcYNHMjoOgFfnUhlLR = AzIgWEqjTUqcYNHMjoOgFfnUhlLR;
				switch (zclYmxLkKSsoONqPjAESznybbpgN)
				{
				default:
					return false;
				case 0:
					ZclYmxLkKSsoONqPjAESznybbpgN = -1;
					if (azIgWEqjTUqcYNHMjoOgFfnUhlLR.joystickTypes == null)
					{
						return false;
					}
					glABSaTXwrdxiTBBrzTJoXGWLjXL = 0;
					break;
				case 1:
					ZclYmxLkKSsoONqPjAESznybbpgN = -1;
					glABSaTXwrdxiTBBrzTJoXGWLjXL++;
					break;
				}
				if (glABSaTXwrdxiTBBrzTJoXGWLjXL < azIgWEqjTUqcYNHMjoOgFfnUhlLR.joystickTypes.Length)
				{
					SAOiWOAfuBOPjEgUvuyUcBSGSHXX = azIgWEqjTUqcYNHMjoOgFfnUhlLR.joystickTypes[glABSaTXwrdxiTBBrzTJoXGWLjXL];
					ZclYmxLkKSsoONqPjAESznybbpgN = 1;
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
				wFZnWcctyePdDROyuOhsCGMMfJqHA wFZnWcctyePdDROyuOhsCGMMfJqHA2;
				if (ZclYmxLkKSsoONqPjAESznybbpgN == -2 && oixcqjEJihUUbUFRRXJlbnnMqhQc == Environment.CurrentManagedThreadId)
				{
					ZclYmxLkKSsoONqPjAESznybbpgN = 0;
					wFZnWcctyePdDROyuOhsCGMMfJqHA2 = this;
				}
				else
				{
					wFZnWcctyePdDROyuOhsCGMMfJqHA2 = new wFZnWcctyePdDROyuOhsCGMMfJqHA(0);
					wFZnWcctyePdDROyuOhsCGMMfJqHA2.AzIgWEqjTUqcYNHMjoOgFfnUhlLR = AzIgWEqjTUqcYNHMjoOgFfnUhlLR;
				}
				return wFZnWcctyePdDROyuOhsCGMMfJqHA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JoystickType>)this).GetEnumerator();
			}
		}

		private sealed class BhtAiPkwoyhyBuySredcfGtriUxY : IEnumerable<Guid>, IEnumerable, IEnumerator<Guid>, IEnumerator, IDisposable
		{
			private int NwEuhuwDNDtbBmBGEQMGRCjiZlmJ;

			private Guid OyuBXvmxjARNwXtJuHfNQkfwkGzb;

			private int aWJbWkBHiYkrNhLeZZAevMHaKDdhb;

			public HardwareJoystickMap kAneMKookFPeSLbCVyytMeiakszO;

			private Guid[] hOuGRYhmHyitLGDpizwjbeObPXNU;

			private int dlabwvfGbZMRQYwQXyQNgGqXuIyLA;

			Guid IEnumerator<Guid>.Current
			{
				[DebuggerHidden]
				get
				{
					return OyuBXvmxjARNwXtJuHfNQkfwkGzb;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return OyuBXvmxjARNwXtJuHfNQkfwkGzb;
				}
			}

			[DebuggerHidden]
			public BhtAiPkwoyhyBuySredcfGtriUxY(int P_0)
			{
				NwEuhuwDNDtbBmBGEQMGRCjiZlmJ = P_0;
				aWJbWkBHiYkrNhLeZZAevMHaKDdhb = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				hOuGRYhmHyitLGDpizwjbeObPXNU = null;
				NwEuhuwDNDtbBmBGEQMGRCjiZlmJ = -2;
			}

			private bool MoveNext()
			{
				int nwEuhuwDNDtbBmBGEQMGRCjiZlmJ = NwEuhuwDNDtbBmBGEQMGRCjiZlmJ;
				HardwareJoystickMap hardwareJoystickMap = kAneMKookFPeSLbCVyytMeiakszO;
				switch (nwEuhuwDNDtbBmBGEQMGRCjiZlmJ)
				{
				default:
					return false;
				case 0:
					NwEuhuwDNDtbBmBGEQMGRCjiZlmJ = -1;
					if (ReInput.isReady)
					{
						hOuGRYhmHyitLGDpizwjbeObPXNU = hardwareJoystickMap.runtimeTemplateGuids;
						if (hOuGRYhmHyitLGDpizwjbeObPXNU == null)
						{
							return false;
						}
						dlabwvfGbZMRQYwQXyQNgGqXuIyLA = 0;
						goto IL_0086;
					}
					if (hardwareJoystickMap.templateGuids == null)
					{
						return false;
					}
					dlabwvfGbZMRQYwQXyQNgGqXuIyLA = 0;
					goto IL_00ea;
				case 1:
					NwEuhuwDNDtbBmBGEQMGRCjiZlmJ = -1;
					dlabwvfGbZMRQYwQXyQNgGqXuIyLA++;
					goto IL_0086;
				case 2:
					{
						NwEuhuwDNDtbBmBGEQMGRCjiZlmJ = -1;
						dlabwvfGbZMRQYwQXyQNgGqXuIyLA++;
						goto IL_00ea;
					}
					IL_0086:
					if (dlabwvfGbZMRQYwQXyQNgGqXuIyLA < hOuGRYhmHyitLGDpizwjbeObPXNU.Length)
					{
						OyuBXvmxjARNwXtJuHfNQkfwkGzb = hOuGRYhmHyitLGDpizwjbeObPXNU[dlabwvfGbZMRQYwQXyQNgGqXuIyLA];
						NwEuhuwDNDtbBmBGEQMGRCjiZlmJ = 1;
						return true;
					}
					hOuGRYhmHyitLGDpizwjbeObPXNU = null;
					break;
					IL_00ea:
					if (dlabwvfGbZMRQYwQXyQNgGqXuIyLA < hardwareJoystickMap.templateGuids.Length)
					{
						OyuBXvmxjARNwXtJuHfNQkfwkGzb = StringTools.ToGuid(hardwareJoystickMap.templateGuids[dlabwvfGbZMRQYwQXyQNgGqXuIyLA]);
						NwEuhuwDNDtbBmBGEQMGRCjiZlmJ = 2;
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
				BhtAiPkwoyhyBuySredcfGtriUxY bhtAiPkwoyhyBuySredcfGtriUxY;
				if (NwEuhuwDNDtbBmBGEQMGRCjiZlmJ == -2 && aWJbWkBHiYkrNhLeZZAevMHaKDdhb == Environment.CurrentManagedThreadId)
				{
					NwEuhuwDNDtbBmBGEQMGRCjiZlmJ = 0;
					bhtAiPkwoyhyBuySredcfGtriUxY = this;
				}
				else
				{
					bhtAiPkwoyhyBuySredcfGtriUxY = new BhtAiPkwoyhyBuySredcfGtriUxY(0);
					bhtAiPkwoyhyBuySredcfGtriUxY.kAneMKookFPeSLbCVyytMeiakszO = kAneMKookFPeSLbCVyytMeiakszO;
				}
				return bhtAiPkwoyhyBuySredcfGtriUxY;
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
			[IteratorStateMachine(typeof(BhtAiPkwoyhyBuySredcfGtriUxY))]
			get
			{
				return new BhtAiPkwoyhyBuySredcfGtriUxY(-2)
				{
					kAneMKookFPeSLbCVyytMeiakszO = this
				};
			}
		}

		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers
		{
			[IteratorStateMachine(typeof(TuKXsmSZIHhSTKqJqwUewOtkXijA))]
			get
			{
				return new TuKXsmSZIHhSTKqJqwUewOtkXijA(-2)
				{
					vPIgHskNxQugUDFdkAVMapCVXynDA = this
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
			[IteratorStateMachine(typeof(wFZnWcctyePdDROyuOhsCGMMfJqHA))]
			get
			{
				return new wFZnWcctyePdDROyuOhsCGMMfJqHA(-2)
				{
					AzIgWEqjTUqcYNHMjoOgFfnUhlLR = this
				};
			}
		}

		Guid IHardwareControllerMap_Internal.typeGuid => Guid;

		string IHardwareControllerMap_Internal.typeKey => controllerKey;

		ControllerType IHardwareControllerMap_Internal.controllerType => ControllerType.Joystick;

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			[IteratorStateMachine(typeof(MPFqvbOknxHfQHjNdVrjTDiMbPkvA))]
			get
			{
				return new MPFqvbOknxHfQHjNdVrjTDiMbPkvA(-2)
				{
					UpIwScPqWdMUJBWRFoWTaKfncNut = this
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
				if (!gxyUNwMTjDnpgmNcTiXKrGmaVQZM.FWiaKwjEYfoyrcIdbeowyEloYCbFb)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.Custom;
				platformMap = gxyUNwMTjDnpgmNcTiXKrGmaVQZM.zipUKuWWUnfReUmmxvIdkMxTAHxe().GetPlatformMap(gxyUNwMTjDnpgmNcTiXKrGmaVQZM.JlQentdyeDYMGsjxDqznOlTsakrz, Guid);
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
				if (!gxyUNwMTjDnpgmNcTiXKrGmaVQZM.FWiaKwjEYfoyrcIdbeowyEloYCbFb)
				{
					return null;
				}
				actualInputPlatform = InputPlatform.Custom;
				platform = gxyUNwMTjDnpgmNcTiXKrGmaVQZM.zipUKuWWUnfReUmmxvIdkMxTAHxe().GetPlatformMap(gxyUNwMTjDnpgmNcTiXKrGmaVQZM.JlQentdyeDYMGsjxDqznOlTsakrz, Guid);
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
				if (!gxyUNwMTjDnpgmNcTiXKrGmaVQZM.FWiaKwjEYfoyrcIdbeowyEloYCbFb)
				{
					throw new Exception("Custom Platform is not set.");
				}
				try
				{
					return gxyUNwMTjDnpgmNcTiXKrGmaVQZM.zipUKuWWUnfReUmmxvIdkMxTAHxe().GetPlatformMap(gxyUNwMTjDnpgmNcTiXKrGmaVQZM.JlQentdyeDYMGsjxDqznOlTsakrz, Guid);
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
