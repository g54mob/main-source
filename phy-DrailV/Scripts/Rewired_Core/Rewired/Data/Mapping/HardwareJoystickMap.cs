using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
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
			private sealed class UMQrriqSNJwAgnkUSUhggVDRsOQW : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform>, IEnumerator<Platform>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private IList<Platform> sqdtZnNYTpQprDFlTIOXHfXKlJGK;

				private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

				Platform IEnumerator<Platform>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public UMQrriqSNJwAgnkUSUhggVDRsOQW(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform platform = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					if (num != 0)
					{
						if (num != 1)
						{
							return false;
						}
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						goto IL_0077;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					sqdtZnNYTpQprDFlTIOXHfXKlJGK = platform.GetVariants();
					if (sqdtZnNYTpQprDFlTIOXHfXKlJGK == null)
					{
						return false;
					}
					PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
					goto IL_0087;
					IL_0087:
					if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < sqdtZnNYTpQprDFlTIOXHfXKlJGK.Count)
					{
						if (sqdtZnNYTpQprDFlTIOXHfXKlJGK[PrfhaiCANHhjwtWLxlpNIHvkLSmF] != null)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = sqdtZnNYTpQprDFlTIOXHfXKlJGK[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
							return true;
						}
						goto IL_0077;
					}
					return false;
					IL_0077:
					PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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
					UMQrriqSNJwAgnkUSUhggVDRsOQW uMQrriqSNJwAgnkUSUhggVDRsOQW;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						uMQrriqSNJwAgnkUSUhggVDRsOQW = this;
					}
					else
					{
						uMQrriqSNJwAgnkUSUhggVDRsOQW = new UMQrriqSNJwAgnkUSUhggVDRsOQW(0);
						uMQrriqSNJwAgnkUSUhggVDRsOQW.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return uMQrriqSNJwAgnkUSUhggVDRsOQW;
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

			internal IEnumerable<Platform> Variants => new UMQrriqSNJwAgnkUSUhggVDRsOQW(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this
			};

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
					if (elementIdentifiers[i].id == id)
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
					hardwareJoystickMap_InputManager.elementIdentifiers[i] = new ControllerElementIdentifier(elementIdentifiers[i], hardwareJoystickMap_InputManager.map.IsElementIdentifierMapped(elementIdentifiers[i].id), hardwareJoystickMap_InputManager.map.GetEffectiveElementIdentifierType(elementIdentifiers[i]));
				}
				if (inputSource == InputSource.PS4 && (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyDualShock4 || hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4AimController))
				{
					for (int j = 0; j < elementIdentifierCount; j++)
					{
						switch (elementIdentifiers[j].id)
						{
						case 0:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "left stick x";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].positiveName = "left stick right";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].negativeName = "left stick left";
							break;
						case 1:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "left stick y";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].positiveName = "left stick up";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].negativeName = "left stick down";
							break;
						case 2:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "right stick x";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].positiveName = "right stick right";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].negativeName = "right stick left";
							break;
						case 3:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "right stick y";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].positiveName = "right stick up";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].negativeName = "right stick down";
							break;
						case 4:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "L2 button";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].positiveName = "L2 button";
							break;
						case 5:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "R2 button";
							hardwareJoystickMap_InputManager.elementIdentifiers[j].positiveName = "R2 button";
							break;
						case 6:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "cross button";
							break;
						case 7:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "circle button";
							break;
						case 8:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "square button";
							break;
						case 9:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "triangle button";
							break;
						case 10:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "L1 button";
							break;
						case 11:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "R1 button";
							break;
						case 12:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "SHARE button";
							break;
						case 13:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "OPTIONS button";
							break;
						case 14:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "PS button";
							break;
						case 15:
							if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4AimController)
							{
								hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "pad button";
							}
							else
							{
								hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "touch pad button";
							}
							break;
						case 16:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "L3 button";
							break;
						case 17:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "R3 button";
							break;
						case 18:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "up button";
							break;
						case 19:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "right button";
							break;
						case 20:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "down button";
							break;
						case 21:
							hardwareJoystickMap_InputManager.elementIdentifiers[j].name = "left button";
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
							switch (elementIdentifiers[k].id)
							{
							case 0:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "left stick x";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].positiveName = "left stick right";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].negativeName = "left stick left";
								break;
							case 1:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "left stick y";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].positiveName = "left stick up";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].negativeName = "left stick down";
								break;
							case 2:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "right stick x";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].positiveName = "right stick right";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].negativeName = "right stick left";
								break;
							case 3:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "right stick y";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].positiveName = "right stick up";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].negativeName = "right stick down";
								break;
							case 4:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "L2 button";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].positiveName = "L2 button";
								break;
							case 5:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "R2 button";
								hardwareJoystickMap_InputManager.elementIdentifiers[k].positiveName = "R2 button";
								break;
							case 6:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "cross button";
								break;
							case 7:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "circle button";
								break;
							case 8:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "square button";
								break;
							case 9:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "triangle button";
								break;
							case 10:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "L1 button";
								break;
							case 11:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "R1 button";
								break;
							case 12:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "create button";
								break;
							case 13:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "options button";
								break;
							case 14:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "PS button";
								break;
							case 15:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "touch pad button";
								break;
							case 16:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "L3 button";
								break;
							case 17:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "R3 button";
								break;
							case 18:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "up button";
								break;
							case 19:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "right button";
								break;
							case 20:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "down button";
								break;
							case 21:
								hardwareJoystickMap_InputManager.elementIdentifiers[k].name = "left button";
								break;
							}
						}
					}
					else if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4Drums || hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4Guitar || hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4SteeringWheel)
					{
						for (int l = 0; l < elementIdentifierCount; l++)
						{
							switch (elementIdentifiers[l].id)
							{
							case 19:
								hardwareJoystickMap_InputManager.elementIdentifiers[l].name = "create button";
								break;
							case 20:
								hardwareJoystickMap_InputManager.elementIdentifiers[l].name = "options button";
								break;
							}
						}
					}
					else if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4FlightStick)
					{
						for (int m = 0; m < elementIdentifierCount; m++)
						{
							switch (elementIdentifiers[m].id)
							{
							case 21:
								hardwareJoystickMap_InputManager.elementIdentifiers[m].name = "create button";
								break;
							case 22:
								hardwareJoystickMap_InputManager.elementIdentifiers[m].name = "options button";
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
					cVYJEBfLvgYrXDhiJFUgeoqupBRXA(elementCount_Base);
					return elementCount_Base;
				}

				internal virtual void cVYJEBfLvgYrXDhiJFUgeoqupBRXA(ElementCount_Base P_0)
				{
					if (P_0 != null)
					{
						P_0.axisCount = axisCount;
						P_0.buttonCount = buttonCount;
					}
				}

				internal virtual bool TUibHCXgdJpNwgxVPYRazOMZLYAI(BridgedControllerHWInfo P_0)
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
					if (elementCount_Base != null && elementCount_Base.TUibHCXgdJpNwgxVPYRazOMZLYAI(bridgedControllerHWInfo))
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
						cVYJEBfLvgYrXDhiJFUgeoqupBRXA(elementCount);
						return elementCount;
					}

					internal override void cVYJEBfLvgYrXDhiJFUgeoqupBRXA(ElementCount_Base P_0)
					{
						base.cVYJEBfLvgYrXDhiJFUgeoqupBRXA(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal override bool TUibHCXgdJpNwgxVPYRazOMZLYAI(BridgedControllerHWInfo P_0)
					{
						if (!base.TUibHCXgdJpNwgxVPYRazOMZLYAI(P_0))
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
				private sealed class vSjBAnRkoBWfRSOCKdjiattPArQLA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private Axis_Base vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public Elements zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public vSjBAnRkoBWfRSOCKdjiattPArQLA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						Elements elements = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						switch (num)
						{
						default:
							return false;
						case 0:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (elements.axes == null)
							{
								return false;
							}
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
							break;
						case 1:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
							break;
						}
						if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < elements.axes.Length)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
						vSjBAnRkoBWfRSOCKdjiattPArQLA vSjBAnRkoBWfRSOCKdjiattPArQLA2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							vSjBAnRkoBWfRSOCKdjiattPArQLA2 = this;
						}
						else
						{
							vSjBAnRkoBWfRSOCKdjiattPArQLA2 = new vSjBAnRkoBWfRSOCKdjiattPArQLA(0);
							vSjBAnRkoBWfRSOCKdjiattPArQLA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return vSjBAnRkoBWfRSOCKdjiattPArQLA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}
				}

				private sealed class aeTQYAFQVljriZOOYOwiUSxrPxnm : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private Button_Base vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public Elements zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public aeTQYAFQVljriZOOYOwiUSxrPxnm(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						Elements elements = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						switch (num)
						{
						default:
							return false;
						case 0:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
							break;
						case 1:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
							break;
						}
						if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < elements.buttons.Length)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
						aeTQYAFQVljriZOOYOwiUSxrPxnm aeTQYAFQVljriZOOYOwiUSxrPxnm2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							aeTQYAFQVljriZOOYOwiUSxrPxnm2 = this;
						}
						else
						{
							aeTQYAFQVljriZOOYOwiUSxrPxnm2 = new aeTQYAFQVljriZOOYOwiUSxrPxnm(0);
							aeTQYAFQVljriZOOYOwiUSxrPxnm2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return aeTQYAFQVljriZOOYOwiUSxrPxnm2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button_Base>)this).GetEnumerator();
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

				internal override IEnumerable<Axis_Base> Axes => new vSjBAnRkoBWfRSOCKdjiattPArQLA(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};

				internal override IEnumerable<Button_Base> Buttons => new aeTQYAFQVljriZOOYOwiUSxrPxnm(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};

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
						if (axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.id)
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
						if (axes[i].elementIdentifier != elementIdentifier.id)
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

			private sealed class BmogtrJNSjpxVCaPaxlxrzGPRCLEc : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Axis_Base vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_DirectInput_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int CdkttMoAtzQraIsMtDkJCAdHdyAxA;

				private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public BmogtrJNSjpxVCaPaxlxrzGPRCLEc(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_DirectInput_Base platform_DirectInput_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_DirectInput_Base.elements == null || platform_DirectInput_Base.elements.axes == null)
						{
							return false;
						}
						CdkttMoAtzQraIsMtDkJCAdHdyAxA = platform_DirectInput_Base.elements.axes.Length;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
						break;
					}
					if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < CdkttMoAtzQraIsMtDkJCAdHdyAxA)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_DirectInput_Base.elements.axes[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					BmogtrJNSjpxVCaPaxlxrzGPRCLEc bmogtrJNSjpxVCaPaxlxrzGPRCLEc;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						bmogtrJNSjpxVCaPaxlxrzGPRCLEc = this;
					}
					else
					{
						bmogtrJNSjpxVCaPaxlxrzGPRCLEc = new BmogtrJNSjpxVCaPaxlxrzGPRCLEc(0);
						bmogtrJNSjpxVCaPaxlxrzGPRCLEc.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return bmogtrJNSjpxVCaPaxlxrzGPRCLEc;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}
			}

			private sealed class suCeVKzqgycqSGcYBTjrNlidjAfm : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Button_Base vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_DirectInput_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int PPZKIFYQBjAqZdsYLXzIiaPJEZNFA;

				private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public suCeVKzqgycqSGcYBTjrNlidjAfm(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_DirectInput_Base platform_DirectInput_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_DirectInput_Base.elements == null || platform_DirectInput_Base.elements.buttons == null)
						{
							return false;
						}
						PPZKIFYQBjAqZdsYLXzIiaPJEZNFA = platform_DirectInput_Base.elements.buttons.Length;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
						break;
					}
					if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < PPZKIFYQBjAqZdsYLXzIiaPJEZNFA)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_DirectInput_Base.elements.buttons[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					suCeVKzqgycqSGcYBTjrNlidjAfm suCeVKzqgycqSGcYBTjrNlidjAfm2;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						suCeVKzqgycqSGcYBTjrNlidjAfm2 = this;
					}
					else
					{
						suCeVKzqgycqSGcYBTjrNlidjAfm2 = new suCeVKzqgycqSGcYBTjrNlidjAfm(0);
						suCeVKzqgycqSGcYBTjrNlidjAfm2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return suCeVKzqgycqSGcYBTjrNlidjAfm2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button_Base>)this).GetEnumerator();
				}
			}

			public Elements elements;

			internal override InputPlatform platform => InputPlatform.WindowsDirectInput;

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

			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return new BmogtrJNSjpxVCaPaxlxrzGPRCLEc(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};
			}

			internal override IEnumerable<Button_Base> IterateButtons()
			{
				return new suCeVKzqgycqSGcYBTjrNlidjAfm(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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
				private sealed class UisOdFPshhUriJxhvHvdsFKSHazAA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private Axis_Base vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public Elements zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public UisOdFPshhUriJxhvHvdsFKSHazAA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						Elements elements = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						switch (num)
						{
						default:
							return false;
						case 0:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (elements.axes == null)
							{
								return false;
							}
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
							break;
						case 1:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
							break;
						}
						if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < elements.axes.Length)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
						UisOdFPshhUriJxhvHvdsFKSHazAA uisOdFPshhUriJxhvHvdsFKSHazAA;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							uisOdFPshhUriJxhvHvdsFKSHazAA = this;
						}
						else
						{
							uisOdFPshhUriJxhvHvdsFKSHazAA = new UisOdFPshhUriJxhvHvdsFKSHazAA(0);
							uisOdFPshhUriJxhvHvdsFKSHazAA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return uisOdFPshhUriJxhvHvdsFKSHazAA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}
				}

				private sealed class xkAoqoclzcqqAaEBtnwzjfjhfGgv : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private Button_Base vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public Elements zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public xkAoqoclzcqqAaEBtnwzjfjhfGgv(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						Elements elements = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						switch (num)
						{
						default:
							return false;
						case 0:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
							break;
						case 1:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
							break;
						}
						if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < elements.buttons.Length)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
						xkAoqoclzcqqAaEBtnwzjfjhfGgv xkAoqoclzcqqAaEBtnwzjfjhfGgv2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							xkAoqoclzcqqAaEBtnwzjfjhfGgv2 = this;
						}
						else
						{
							xkAoqoclzcqqAaEBtnwzjfjhfGgv2 = new xkAoqoclzcqqAaEBtnwzjfjhfGgv(0);
							xkAoqoclzcqqAaEBtnwzjfjhfGgv2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return xkAoqoclzcqqAaEBtnwzjfjhfGgv2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button_Base>)this).GetEnumerator();
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

				internal override IEnumerable<Axis_Base> Axes => new UisOdFPshhUriJxhvHvdsFKSHazAA(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};

				internal override IEnumerable<Button_Base> Buttons => new xkAoqoclzcqqAaEBtnwzjfjhfGgv(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};

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
						if (axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.id)
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
						if (axes[i].elementIdentifier != elementIdentifier.id)
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

			private sealed class GUzEuUdQfFxooVsQpEejgPSBqNFfB : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Axis_Base vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_RawInput_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int CdkttMoAtzQraIsMtDkJCAdHdyAxA;

				private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public GUzEuUdQfFxooVsQpEejgPSBqNFfB(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_RawInput_Base platform_RawInput_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_RawInput_Base.elements == null || platform_RawInput_Base.elements.axes == null)
						{
							return false;
						}
						CdkttMoAtzQraIsMtDkJCAdHdyAxA = platform_RawInput_Base.elements.axes.Length;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
						break;
					}
					if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < CdkttMoAtzQraIsMtDkJCAdHdyAxA)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_RawInput_Base.elements.axes[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					GUzEuUdQfFxooVsQpEejgPSBqNFfB gUzEuUdQfFxooVsQpEejgPSBqNFfB;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						gUzEuUdQfFxooVsQpEejgPSBqNFfB = this;
					}
					else
					{
						gUzEuUdQfFxooVsQpEejgPSBqNFfB = new GUzEuUdQfFxooVsQpEejgPSBqNFfB(0);
						gUzEuUdQfFxooVsQpEejgPSBqNFfB.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return gUzEuUdQfFxooVsQpEejgPSBqNFfB;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}
			}

			private sealed class GJzHSXhayrriMvakGDsxEnzCcHlQ : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Button_Base vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_RawInput_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int PPZKIFYQBjAqZdsYLXzIiaPJEZNFA;

				private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public GJzHSXhayrriMvakGDsxEnzCcHlQ(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_RawInput_Base platform_RawInput_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_RawInput_Base.elements == null || platform_RawInput_Base.elements.buttons == null)
						{
							return false;
						}
						PPZKIFYQBjAqZdsYLXzIiaPJEZNFA = platform_RawInput_Base.elements.buttons.Length;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
						break;
					}
					if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < PPZKIFYQBjAqZdsYLXzIiaPJEZNFA)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_RawInput_Base.elements.buttons[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					GJzHSXhayrriMvakGDsxEnzCcHlQ gJzHSXhayrriMvakGDsxEnzCcHlQ;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						gJzHSXhayrriMvakGDsxEnzCcHlQ = this;
					}
					else
					{
						gJzHSXhayrriMvakGDsxEnzCcHlQ = new GJzHSXhayrriMvakGDsxEnzCcHlQ(0);
						gJzHSXhayrriMvakGDsxEnzCcHlQ.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return gJzHSXhayrriMvakGDsxEnzCcHlQ;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button_Base>)this).GetEnumerator();
				}
			}

			public Elements elements;

			internal override InputPlatform platform => InputPlatform.WindowsRawInput;

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

			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return new GUzEuUdQfFxooVsQpEejgPSBqNFfB(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};
			}

			internal override IEnumerable<Button_Base> IterateButtons()
			{
				return new GJzHSXhayrriMvakGDsxEnzCcHlQ(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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
						if (axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.id)
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
						if (axes[i].elementIdentifier != elementIdentifier.id)
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

			private sealed class tQyastiDREOnPjqlSfghKgvKTyLnA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Axis vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_XInput_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public tQyastiDREOnPjqlSfghKgvKTyLnA(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_XInput_Base platform_XInput_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_XInput_Base.elements == null || platform_XInput_Base.elements.axes == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_XInput_Base.elements.axes.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_XInput_Base.elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					tQyastiDREOnPjqlSfghKgvKTyLnA tQyastiDREOnPjqlSfghKgvKTyLnA2;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						tQyastiDREOnPjqlSfghKgvKTyLnA2 = this;
					}
					else
					{
						tQyastiDREOnPjqlSfghKgvKTyLnA2 = new tQyastiDREOnPjqlSfghKgvKTyLnA(0);
						tQyastiDREOnPjqlSfghKgvKTyLnA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return tQyastiDREOnPjqlSfghKgvKTyLnA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class NILHWlEGFCEeHONUXosUBInOfHqBA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Button vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_XInput_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public NILHWlEGFCEeHONUXosUBInOfHqBA(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_XInput_Base platform_XInput_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_XInput_Base.elements == null || platform_XInput_Base.elements.buttons == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_XInput_Base.elements.buttons.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_XInput_Base.elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					NILHWlEGFCEeHONUXosUBInOfHqBA nILHWlEGFCEeHONUXosUBInOfHqBA;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						nILHWlEGFCEeHONUXosUBInOfHqBA = this;
					}
					else
					{
						nILHWlEGFCEeHONUXosUBInOfHqBA = new NILHWlEGFCEeHONUXosUBInOfHqBA(0);
						nILHWlEGFCEeHONUXosUBInOfHqBA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return nILHWlEGFCEeHONUXosUBInOfHqBA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
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

			internal override InputPlatform platform => InputPlatform.WindowsXInput;

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

			internal IEnumerable<Axis> IterateAxes()
			{
				return new tQyastiDREOnPjqlSfghKgvKTyLnA(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};
			}

			internal IEnumerable<Button> IterateButtons()
			{
				return new NILHWlEGFCEeHONUXosUBInOfHqBA(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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
						cVYJEBfLvgYrXDhiJFUgeoqupBRXA(elementCount);
						return elementCount;
					}

					internal override void cVYJEBfLvgYrXDhiJFUgeoqupBRXA(ElementCount_Base P_0)
					{
						base.cVYJEBfLvgYrXDhiJFUgeoqupBRXA(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal override bool TUibHCXgdJpNwgxVPYRazOMZLYAI(BridgedControllerHWInfo P_0)
					{
						if (!base.TUibHCXgdJpNwgxVPYRazOMZLYAI(P_0))
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
				private sealed class EBOCCbUCcpYZjnHMgytwbsXVQcUE : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private Axis vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public Elements zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private Axis[] XJDKKrLVzmqpRqpsWNhTQGvqEorq;

					private int LTEsUPlDRPIUwfjPOBEMaAhKHeOx;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public EBOCCbUCcpYZjnHMgytwbsXVQcUE(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						Elements elements = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						switch (num)
						{
						default:
							return false;
						case 0:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (elements.axes == null)
							{
								return false;
							}
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = elements.axes;
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx = 0;
							break;
						case 1:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx++;
							break;
						}
						if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx < XJDKKrLVzmqpRqpsWNhTQGvqEorq.Length)
						{
							Axis axis = XJDKKrLVzmqpRqpsWNhTQGvqEorq[LTEsUPlDRPIUwfjPOBEMaAhKHeOx];
							vjnbYLtrPMftzpjohNfommerCnGo = axis;
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
							return true;
						}
						XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
						return false;
					}

					bool IEnumerator.MoveNext()
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
						EBOCCbUCcpYZjnHMgytwbsXVQcUE eBOCCbUCcpYZjnHMgytwbsXVQcUE;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							eBOCCbUCcpYZjnHMgytwbsXVQcUE = this;
						}
						else
						{
							eBOCCbUCcpYZjnHMgytwbsXVQcUE = new EBOCCbUCcpYZjnHMgytwbsXVQcUE(0);
							eBOCCbUCcpYZjnHMgytwbsXVQcUE.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return eBOCCbUCcpYZjnHMgytwbsXVQcUE;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class vCKSDPNDiQXHMgmudcimfrccvPKDA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private Button vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public Elements zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private Button[] XJDKKrLVzmqpRqpsWNhTQGvqEorq;

					private int LTEsUPlDRPIUwfjPOBEMaAhKHeOx;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public vCKSDPNDiQXHMgmudcimfrccvPKDA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						Elements elements = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						switch (num)
						{
						default:
							return false;
						case 0:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = elements.buttons;
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx = 0;
							break;
						case 1:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx++;
							break;
						}
						if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx < XJDKKrLVzmqpRqpsWNhTQGvqEorq.Length)
						{
							Button button = XJDKKrLVzmqpRqpsWNhTQGvqEorq[LTEsUPlDRPIUwfjPOBEMaAhKHeOx];
							vjnbYLtrPMftzpjohNfommerCnGo = button;
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
							return true;
						}
						XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
						return false;
					}

					bool IEnumerator.MoveNext()
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
						vCKSDPNDiQXHMgmudcimfrccvPKDA vCKSDPNDiQXHMgmudcimfrccvPKDA2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							vCKSDPNDiQXHMgmudcimfrccvPKDA2 = this;
						}
						else
						{
							vCKSDPNDiQXHMgmudcimfrccvPKDA2 = new vCKSDPNDiQXHMgmudcimfrccvPKDA(0);
							vCKSDPNDiQXHMgmudcimfrccvPKDA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return vCKSDPNDiQXHMgmudcimfrccvPKDA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
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
					return new EBOCCbUCcpYZjnHMgytwbsXVQcUE(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}

				public IEnumerable<Button> IterateButtons()
				{
					return new vCKSDPNDiQXHMgmudcimfrccvPKDA(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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
						if (axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.id)
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
						if (axes[i].elementIdentifier != elementIdentifier.id)
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

			private sealed class ilGwbtkDYjjaSQKLuImMjzTWfRoU : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Axis vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_OSX_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public ilGwbtkDYjjaSQKLuImMjzTWfRoU(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_OSX_Base platform_OSX_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_OSX_Base.elements == null || platform_OSX_Base.elements.axes == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_OSX_Base.elements.axes.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_OSX_Base.elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					ilGwbtkDYjjaSQKLuImMjzTWfRoU ilGwbtkDYjjaSQKLuImMjzTWfRoU2;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						ilGwbtkDYjjaSQKLuImMjzTWfRoU2 = this;
					}
					else
					{
						ilGwbtkDYjjaSQKLuImMjzTWfRoU2 = new ilGwbtkDYjjaSQKLuImMjzTWfRoU(0);
						ilGwbtkDYjjaSQKLuImMjzTWfRoU2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return ilGwbtkDYjjaSQKLuImMjzTWfRoU2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class kLRpKatqFQhFZWDSBgyIqnLHtpwD : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Button vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_OSX_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public kLRpKatqFQhFZWDSBgyIqnLHtpwD(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_OSX_Base platform_OSX_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_OSX_Base.elements == null || platform_OSX_Base.elements.buttons == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_OSX_Base.elements.buttons.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_OSX_Base.elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					kLRpKatqFQhFZWDSBgyIqnLHtpwD kLRpKatqFQhFZWDSBgyIqnLHtpwD2;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						kLRpKatqFQhFZWDSBgyIqnLHtpwD2 = this;
					}
					else
					{
						kLRpKatqFQhFZWDSBgyIqnLHtpwD2 = new kLRpKatqFQhFZWDSBgyIqnLHtpwD(0);
						kLRpKatqFQhFZWDSBgyIqnLHtpwD2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return kLRpKatqFQhFZWDSBgyIqnLHtpwD2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
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

			internal override InputPlatform platform => InputPlatform.OSXNative;

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

			internal override Elements_Base elements_base => elements;

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

			internal IEnumerable<Axis> IterateAxes()
			{
				return new ilGwbtkDYjjaSQKLuImMjzTWfRoU(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};
			}

			internal IEnumerable<Button> IterateButtons()
			{
				return new kLRpKatqFQhFZWDSBgyIqnLHtpwD(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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
						cVYJEBfLvgYrXDhiJFUgeoqupBRXA(elementCount);
						return elementCount;
					}

					internal override void cVYJEBfLvgYrXDhiJFUgeoqupBRXA(ElementCount_Base P_0)
					{
						base.cVYJEBfLvgYrXDhiJFUgeoqupBRXA(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal override bool TUibHCXgdJpNwgxVPYRazOMZLYAI(BridgedControllerHWInfo P_0)
					{
						if (!base.TUibHCXgdJpNwgxVPYRazOMZLYAI(P_0))
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
				private sealed class SMsMpWKNRGiVkgKmfYfYGNTgsats : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private Axis vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public Elements zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public SMsMpWKNRGiVkgKmfYfYGNTgsats(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						Elements elements = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						switch (num)
						{
						default:
							return false;
						case 0:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (elements.axes == null)
							{
								return false;
							}
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
							break;
						case 1:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
							break;
						}
						if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < elements.axes.Length)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
						SMsMpWKNRGiVkgKmfYfYGNTgsats sMsMpWKNRGiVkgKmfYfYGNTgsats;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							sMsMpWKNRGiVkgKmfYfYGNTgsats = this;
						}
						else
						{
							sMsMpWKNRGiVkgKmfYfYGNTgsats = new SMsMpWKNRGiVkgKmfYfYGNTgsats(0);
							sMsMpWKNRGiVkgKmfYfYGNTgsats.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return sMsMpWKNRGiVkgKmfYfYGNTgsats;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class vlZxBGOjYHtWteOwGOemlnfrEiWz : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private Button vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public Elements zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public vlZxBGOjYHtWteOwGOemlnfrEiWz(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						Elements elements = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						switch (num)
						{
						default:
							return false;
						case 0:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
							break;
						case 1:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
							break;
						}
						if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < elements.buttons.Length)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
						vlZxBGOjYHtWteOwGOemlnfrEiWz vlZxBGOjYHtWteOwGOemlnfrEiWz2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							vlZxBGOjYHtWteOwGOemlnfrEiWz2 = this;
						}
						else
						{
							vlZxBGOjYHtWteOwGOemlnfrEiWz2 = new vlZxBGOjYHtWteOwGOemlnfrEiWz(0);
							vlZxBGOjYHtWteOwGOemlnfrEiWz2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return vlZxBGOjYHtWteOwGOemlnfrEiWz2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
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

				internal IEnumerable<Axis> Axes => new SMsMpWKNRGiVkgKmfYfYGNTgsats(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};

				internal IEnumerable<Button> Buttons => new vlZxBGOjYHtWteOwGOemlnfrEiWz(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};

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
						if (axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.id)
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
						if (axes[i].elementIdentifier != elementIdentifier.id)
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

			private sealed class FmMjmHmLFGBtiAcyWBUyVdShkXPLA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Axis vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_Linux_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int CdkttMoAtzQraIsMtDkJCAdHdyAxA;

				private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public FmMjmHmLFGBtiAcyWBUyVdShkXPLA(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_Linux_Base platform_Linux_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_Linux_Base.elements == null || platform_Linux_Base.elements.axes == null)
						{
							return false;
						}
						CdkttMoAtzQraIsMtDkJCAdHdyAxA = platform_Linux_Base.elements.axes.Length;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
						break;
					}
					if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < CdkttMoAtzQraIsMtDkJCAdHdyAxA)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_Linux_Base.elements.axes[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					FmMjmHmLFGBtiAcyWBUyVdShkXPLA fmMjmHmLFGBtiAcyWBUyVdShkXPLA;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						fmMjmHmLFGBtiAcyWBUyVdShkXPLA = this;
					}
					else
					{
						fmMjmHmLFGBtiAcyWBUyVdShkXPLA = new FmMjmHmLFGBtiAcyWBUyVdShkXPLA(0);
						fmMjmHmLFGBtiAcyWBUyVdShkXPLA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return fmMjmHmLFGBtiAcyWBUyVdShkXPLA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class TzBOhRRMoEgfRkJBAzGqONWrjLKZA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Button vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_Linux_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int PPZKIFYQBjAqZdsYLXzIiaPJEZNFA;

				private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public TzBOhRRMoEgfRkJBAzGqONWrjLKZA(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_Linux_Base platform_Linux_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_Linux_Base.elements == null || platform_Linux_Base.elements.buttons == null)
						{
							return false;
						}
						PPZKIFYQBjAqZdsYLXzIiaPJEZNFA = platform_Linux_Base.elements.buttons.Length;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
						break;
					}
					if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < PPZKIFYQBjAqZdsYLXzIiaPJEZNFA)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_Linux_Base.elements.buttons[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					TzBOhRRMoEgfRkJBAzGqONWrjLKZA tzBOhRRMoEgfRkJBAzGqONWrjLKZA;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						tzBOhRRMoEgfRkJBAzGqONWrjLKZA = this;
					}
					else
					{
						tzBOhRRMoEgfRkJBAzGqONWrjLKZA = new TzBOhRRMoEgfRkJBAzGqONWrjLKZA(0);
						tzBOhRRMoEgfRkJBAzGqONWrjLKZA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return tzBOhRRMoEgfRkJBAzGqONWrjLKZA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform => InputPlatform.LinuxNative;

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

			internal IEnumerable<Axis> IterateAxes()
			{
				return new FmMjmHmLFGBtiAcyWBUyVdShkXPLA(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};
			}

			internal IEnumerable<Button> IterateButtons()
			{
				return new TzBOhRRMoEgfRkJBAzGqONWrjLKZA(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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
						cVYJEBfLvgYrXDhiJFUgeoqupBRXA(elementCount);
						return elementCount;
					}

					internal override void cVYJEBfLvgYrXDhiJFUgeoqupBRXA(ElementCount_Base P_0)
					{
						base.cVYJEBfLvgYrXDhiJFUgeoqupBRXA(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal override bool TUibHCXgdJpNwgxVPYRazOMZLYAI(BridgedControllerHWInfo P_0)
					{
						if (!base.TUibHCXgdJpNwgxVPYRazOMZLYAI(P_0))
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

				internal override bool hasData
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
				private sealed class TtVjhVABkyeXukjBllWycyOTSiah : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private Axis vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public Elements zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public TtVjhVABkyeXukjBllWycyOTSiah(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						Elements elements = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						switch (num)
						{
						default:
							return false;
						case 0:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (elements.axes == null)
							{
								return false;
							}
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
							break;
						case 1:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
							break;
						}
						if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < elements.axes.Length)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
						TtVjhVABkyeXukjBllWycyOTSiah ttVjhVABkyeXukjBllWycyOTSiah;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							ttVjhVABkyeXukjBllWycyOTSiah = this;
						}
						else
						{
							ttVjhVABkyeXukjBllWycyOTSiah = new TtVjhVABkyeXukjBllWycyOTSiah(0);
							ttVjhVABkyeXukjBllWycyOTSiah.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return ttVjhVABkyeXukjBllWycyOTSiah;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class oIQGUlesYSWGrVBrXBiNJunmmOAA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private Button vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public Elements zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public oIQGUlesYSWGrVBrXBiNJunmmOAA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						Elements elements = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						switch (num)
						{
						default:
							return false;
						case 0:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
							break;
						case 1:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
							break;
						}
						if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < elements.buttons.Length)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
						oIQGUlesYSWGrVBrXBiNJunmmOAA oIQGUlesYSWGrVBrXBiNJunmmOAA2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							oIQGUlesYSWGrVBrXBiNJunmmOAA2 = this;
						}
						else
						{
							oIQGUlesYSWGrVBrXBiNJunmmOAA2 = new oIQGUlesYSWGrVBrXBiNJunmmOAA(0);
							oIQGUlesYSWGrVBrXBiNJunmmOAA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return oIQGUlesYSWGrVBrXBiNJunmmOAA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
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

				internal IEnumerable<Axis> Axes => new TtVjhVABkyeXukjBllWycyOTSiah(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};

				internal IEnumerable<Button> Buttons => new oIQGUlesYSWGrVBrXBiNJunmmOAA(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};

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
						if (axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.id)
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
						if (axes[i].elementIdentifier != elementIdentifier.id)
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

			private sealed class NgdwNldNtyxCPMYwZFURWljFvxUB : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Axis vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_WindowsUWP_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int CdkttMoAtzQraIsMtDkJCAdHdyAxA;

				private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public NgdwNldNtyxCPMYwZFURWljFvxUB(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_WindowsUWP_Base platform_WindowsUWP_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_WindowsUWP_Base.elements == null || platform_WindowsUWP_Base.elements.axes == null)
						{
							return false;
						}
						CdkttMoAtzQraIsMtDkJCAdHdyAxA = platform_WindowsUWP_Base.elements.axes.Length;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
						break;
					}
					if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < CdkttMoAtzQraIsMtDkJCAdHdyAxA)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_WindowsUWP_Base.elements.axes[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					NgdwNldNtyxCPMYwZFURWljFvxUB ngdwNldNtyxCPMYwZFURWljFvxUB;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						ngdwNldNtyxCPMYwZFURWljFvxUB = this;
					}
					else
					{
						ngdwNldNtyxCPMYwZFURWljFvxUB = new NgdwNldNtyxCPMYwZFURWljFvxUB(0);
						ngdwNldNtyxCPMYwZFURWljFvxUB.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return ngdwNldNtyxCPMYwZFURWljFvxUB;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class TdGnHnNqkAuSVGopDmebaIWFLRkM : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Button vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_WindowsUWP_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int PPZKIFYQBjAqZdsYLXzIiaPJEZNFA;

				private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public TdGnHnNqkAuSVGopDmebaIWFLRkM(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_WindowsUWP_Base platform_WindowsUWP_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_WindowsUWP_Base.elements == null || platform_WindowsUWP_Base.elements.buttons == null)
						{
							return false;
						}
						PPZKIFYQBjAqZdsYLXzIiaPJEZNFA = platform_WindowsUWP_Base.elements.buttons.Length;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
						break;
					}
					if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < PPZKIFYQBjAqZdsYLXzIiaPJEZNFA)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_WindowsUWP_Base.elements.buttons[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					TdGnHnNqkAuSVGopDmebaIWFLRkM tdGnHnNqkAuSVGopDmebaIWFLRkM;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						tdGnHnNqkAuSVGopDmebaIWFLRkM = this;
					}
					else
					{
						tdGnHnNqkAuSVGopDmebaIWFLRkM = new TdGnHnNqkAuSVGopDmebaIWFLRkM(0);
						tdGnHnNqkAuSVGopDmebaIWFLRkM.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return tdGnHnNqkAuSVGopDmebaIWFLRkM;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform => InputPlatform.WindowsUWP;

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

			internal IEnumerable<Axis> IterateAxes()
			{
				return new NgdwNldNtyxCPMYwZFURWljFvxUB(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};
			}

			internal IEnumerable<Button> IterateButtons()
			{
				return new TdGnHnNqkAuSVGopDmebaIWFLRkM(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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
						if (productName != null && productName.Length != 0)
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.id)
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
						if (axes[i].elementIdentifier != elementIdentifier.id)
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

			private sealed class ETURnXMFUJTTbkNpIgrKGZNXyBqA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Axis vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_Fallback_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public ETURnXMFUJTTbkNpIgrKGZNXyBqA(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_Fallback_Base platform_Fallback_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_Fallback_Base.elements == null || platform_Fallback_Base.elements.axes == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_Fallback_Base.elements.axes.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_Fallback_Base.elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					ETURnXMFUJTTbkNpIgrKGZNXyBqA eTURnXMFUJTTbkNpIgrKGZNXyBqA;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						eTURnXMFUJTTbkNpIgrKGZNXyBqA = this;
					}
					else
					{
						eTURnXMFUJTTbkNpIgrKGZNXyBqA = new ETURnXMFUJTTbkNpIgrKGZNXyBqA(0);
						eTURnXMFUJTTbkNpIgrKGZNXyBqA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return eTURnXMFUJTTbkNpIgrKGZNXyBqA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class mRTBKPxzCWVaIIcSKxFbJgdtFWQiA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Button vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_Fallback_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public mRTBKPxzCWVaIIcSKxFbJgdtFWQiA(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_Fallback_Base platform_Fallback_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_Fallback_Base.elements == null || platform_Fallback_Base.elements.buttons == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_Fallback_Base.elements.buttons.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_Fallback_Base.elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					mRTBKPxzCWVaIIcSKxFbJgdtFWQiA mRTBKPxzCWVaIIcSKxFbJgdtFWQiA2;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						mRTBKPxzCWVaIIcSKxFbJgdtFWQiA2 = this;
					}
					else
					{
						mRTBKPxzCWVaIIcSKxFbJgdtFWQiA2 = new mRTBKPxzCWVaIIcSKxFbJgdtFWQiA(0);
						mRTBKPxzCWVaIIcSKxFbJgdtFWQiA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return mRTBKPxzCWVaIIcSKxFbJgdtFWQiA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
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

			internal override InputPlatform platform => InputPlatform.Fallback;

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

			internal IEnumerable<Axis> IterateAxes()
			{
				return new ETURnXMFUJTTbkNpIgrKGZNXyBqA(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};
			}

			internal IEnumerable<Button> IterateButtons()
			{
				return new mRTBKPxzCWVaIIcSKxFbJgdtFWQiA(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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

				internal override bool hasData
				{
					get
					{
						if (base.hasData)
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.id)
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
						if (axes[i].elementIdentifier != elementIdentifier.id)
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

			private sealed class RclgoqClmsmfkCjjAiKYYubFHSCr : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Axis vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_XboxOne_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public RclgoqClmsmfkCjjAiKYYubFHSCr(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_XboxOne_Base platform_XboxOne_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_XboxOne_Base.elements == null || platform_XboxOne_Base.elements.axes == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_XboxOne_Base.elements.axes.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_XboxOne_Base.elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					RclgoqClmsmfkCjjAiKYYubFHSCr rclgoqClmsmfkCjjAiKYYubFHSCr;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						rclgoqClmsmfkCjjAiKYYubFHSCr = this;
					}
					else
					{
						rclgoqClmsmfkCjjAiKYYubFHSCr = new RclgoqClmsmfkCjjAiKYYubFHSCr(0);
						rclgoqClmsmfkCjjAiKYYubFHSCr.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return rclgoqClmsmfkCjjAiKYYubFHSCr;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class hNGsCTqytYgMxFohbItuJkWwZRbi : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Button vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_XboxOne_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public hNGsCTqytYgMxFohbItuJkWwZRbi(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_XboxOne_Base platform_XboxOne_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_XboxOne_Base.elements == null || platform_XboxOne_Base.elements.buttons == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_XboxOne_Base.elements.buttons.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_XboxOne_Base.elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					hNGsCTqytYgMxFohbItuJkWwZRbi hNGsCTqytYgMxFohbItuJkWwZRbi2;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						hNGsCTqytYgMxFohbItuJkWwZRbi2 = this;
					}
					else
					{
						hNGsCTqytYgMxFohbItuJkWwZRbi2 = new hNGsCTqytYgMxFohbItuJkWwZRbi(0);
						hNGsCTqytYgMxFohbItuJkWwZRbi2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return hNGsCTqytYgMxFohbItuJkWwZRbi2;
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

			internal override InputPlatform platform => InputPlatform.XboxOne;

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
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
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

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new RclgoqClmsmfkCjjAiKYYubFHSCr(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new hNGsCTqytYgMxFohbItuJkWwZRbi(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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

				internal override bool hasData
				{
					get
					{
						if (base.hasData)
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.id)
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
						if (axes[i].elementIdentifier != elementIdentifier.id)
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

			private sealed class VxEtaaJhzEkRyViTXKKEMsqlJgRi : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Axis vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_PS4_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public VxEtaaJhzEkRyViTXKKEMsqlJgRi(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_PS4_Base platform_PS4_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_PS4_Base.elements == null || platform_PS4_Base.elements.axes == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_PS4_Base.elements.axes.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_PS4_Base.elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					VxEtaaJhzEkRyViTXKKEMsqlJgRi vxEtaaJhzEkRyViTXKKEMsqlJgRi;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						vxEtaaJhzEkRyViTXKKEMsqlJgRi = this;
					}
					else
					{
						vxEtaaJhzEkRyViTXKKEMsqlJgRi = new VxEtaaJhzEkRyViTXKKEMsqlJgRi(0);
						vxEtaaJhzEkRyViTXKKEMsqlJgRi.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return vxEtaaJhzEkRyViTXKKEMsqlJgRi;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class mtMDBkdmLBzzSSzohfsNIhRNwtuRA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Button vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_PS4_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public mtMDBkdmLBzzSSzohfsNIhRNwtuRA(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_PS4_Base platform_PS4_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_PS4_Base.elements == null || platform_PS4_Base.elements.buttons == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_PS4_Base.elements.buttons.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_PS4_Base.elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					mtMDBkdmLBzzSSzohfsNIhRNwtuRA mtMDBkdmLBzzSSzohfsNIhRNwtuRA2;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						mtMDBkdmLBzzSSzohfsNIhRNwtuRA2 = this;
					}
					else
					{
						mtMDBkdmLBzzSSzohfsNIhRNwtuRA2 = new mtMDBkdmLBzzSSzohfsNIhRNwtuRA(0);
						mtMDBkdmLBzzSSzohfsNIhRNwtuRA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return mtMDBkdmLBzzSSzohfsNIhRNwtuRA2;
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

			internal override InputPlatform platform => InputPlatform.PS4;

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
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
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

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new VxEtaaJhzEkRyViTXKKEMsqlJgRi(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new mtMDBkdmLBzzSSzohfsNIhRNwtuRA(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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

				internal override bool hasData
				{
					get
					{
						if (base.hasData)
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.id)
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
						if (axes[i].elementIdentifier != elementIdentifier.id)
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

			private sealed class DSntogYmQhymHoLIIagGmqhoxOty : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Axis vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_NintendoSwitch_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public DSntogYmQhymHoLIIagGmqhoxOty(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_NintendoSwitch_Base platform_NintendoSwitch_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_NintendoSwitch_Base.elements == null || platform_NintendoSwitch_Base.elements.axes == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_NintendoSwitch_Base.elements.axes.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_NintendoSwitch_Base.elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					DSntogYmQhymHoLIIagGmqhoxOty dSntogYmQhymHoLIIagGmqhoxOty;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						dSntogYmQhymHoLIIagGmqhoxOty = this;
					}
					else
					{
						dSntogYmQhymHoLIIagGmqhoxOty = new DSntogYmQhymHoLIIagGmqhoxOty(0);
						dSntogYmQhymHoLIIagGmqhoxOty.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return dSntogYmQhymHoLIIagGmqhoxOty;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class GLjJqPywLVUAytqErfGBYPMwFNfhA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Button vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_NintendoSwitch_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public GLjJqPywLVUAytqErfGBYPMwFNfhA(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_NintendoSwitch_Base platform_NintendoSwitch_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_NintendoSwitch_Base.elements == null || platform_NintendoSwitch_Base.elements.buttons == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_NintendoSwitch_Base.elements.buttons.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_NintendoSwitch_Base.elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					GLjJqPywLVUAytqErfGBYPMwFNfhA gLjJqPywLVUAytqErfGBYPMwFNfhA;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						gLjJqPywLVUAytqErfGBYPMwFNfhA = this;
					}
					else
					{
						gLjJqPywLVUAytqErfGBYPMwFNfhA = new GLjJqPywLVUAytqErfGBYPMwFNfhA(0);
						gLjJqPywLVUAytqErfGBYPMwFNfhA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return gLjJqPywLVUAytqErfGBYPMwFNfhA;
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

			internal override InputPlatform platform => InputPlatform.NintendoSwitch;

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
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
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

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new DSntogYmQhymHoLIIagGmqhoxOty(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new GLjJqPywLVUAytqErfGBYPMwFNfhA(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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

				internal override bool hasData
				{
					get
					{
						if (base.hasData)
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.id)
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
						if (axes[i].elementIdentifier != elementIdentifier.id)
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

			private sealed class drwuXbGFcyBcOizTZAHeroNSkQSl : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Axis vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_GameCore_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public drwuXbGFcyBcOizTZAHeroNSkQSl(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_GameCore_Base platform_GameCore_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_GameCore_Base.elements == null || platform_GameCore_Base.elements.axes == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_GameCore_Base.elements.axes.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_GameCore_Base.elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					drwuXbGFcyBcOizTZAHeroNSkQSl drwuXbGFcyBcOizTZAHeroNSkQSl2;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						drwuXbGFcyBcOizTZAHeroNSkQSl2 = this;
					}
					else
					{
						drwuXbGFcyBcOizTZAHeroNSkQSl2 = new drwuXbGFcyBcOizTZAHeroNSkQSl(0);
						drwuXbGFcyBcOizTZAHeroNSkQSl2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return drwuXbGFcyBcOizTZAHeroNSkQSl2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class AFGdoacrkOGRYxkUYjDfIIocmxEQ : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Button vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_GameCore_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public AFGdoacrkOGRYxkUYjDfIIocmxEQ(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_GameCore_Base platform_GameCore_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_GameCore_Base.elements == null || platform_GameCore_Base.elements.buttons == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_GameCore_Base.elements.buttons.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_GameCore_Base.elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					AFGdoacrkOGRYxkUYjDfIIocmxEQ aFGdoacrkOGRYxkUYjDfIIocmxEQ;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						aFGdoacrkOGRYxkUYjDfIIocmxEQ = this;
					}
					else
					{
						aFGdoacrkOGRYxkUYjDfIIocmxEQ = new AFGdoacrkOGRYxkUYjDfIIocmxEQ(0);
						aFGdoacrkOGRYxkUYjDfIIocmxEQ.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return aFGdoacrkOGRYxkUYjDfIIocmxEQ;
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

			internal override InputPlatform platform => InputPlatform.GameCore;

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
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
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

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new drwuXbGFcyBcOizTZAHeroNSkQSl(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new AFGdoacrkOGRYxkUYjDfIIocmxEQ(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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

				internal override bool hasData
				{
					get
					{
						if (base.hasData)
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.id)
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
						if (axes[i].elementIdentifier != elementIdentifier.id)
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

			private sealed class qfFgUDDQMecQYAxKvwiZPAMCPjnA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Axis vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_PS5_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public qfFgUDDQMecQYAxKvwiZPAMCPjnA(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_PS5_Base platform_PS5_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_PS5_Base.elements == null || platform_PS5_Base.elements.axes == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_PS5_Base.elements.axes.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_PS5_Base.elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					qfFgUDDQMecQYAxKvwiZPAMCPjnA qfFgUDDQMecQYAxKvwiZPAMCPjnA2;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						qfFgUDDQMecQYAxKvwiZPAMCPjnA2 = this;
					}
					else
					{
						qfFgUDDQMecQYAxKvwiZPAMCPjnA2 = new qfFgUDDQMecQYAxKvwiZPAMCPjnA(0);
						qfFgUDDQMecQYAxKvwiZPAMCPjnA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return qfFgUDDQMecQYAxKvwiZPAMCPjnA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class PHuHfgZkPuBYxmUouTDHVGXlSfot : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Button vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_PS5_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public PHuHfgZkPuBYxmUouTDHVGXlSfot(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_PS5_Base platform_PS5_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_PS5_Base.elements == null || platform_PS5_Base.elements.buttons == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_PS5_Base.elements.buttons.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_PS5_Base.elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					PHuHfgZkPuBYxmUouTDHVGXlSfot pHuHfgZkPuBYxmUouTDHVGXlSfot;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						pHuHfgZkPuBYxmUouTDHVGXlSfot = this;
					}
					else
					{
						pHuHfgZkPuBYxmUouTDHVGXlSfot = new PHuHfgZkPuBYxmUouTDHVGXlSfot(0);
						pHuHfgZkPuBYxmUouTDHVGXlSfot.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return pHuHfgZkPuBYxmUouTDHVGXlSfot;
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

			internal override InputPlatform platform => InputPlatform.PS5;

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
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
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

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new qfFgUDDQMecQYAxKvwiZPAMCPjnA(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new PHuHfgZkPuBYxmUouTDHVGXlSfot(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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

				internal override bool hasData
				{
					get
					{
						if (base.hasData)
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.id)
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
						if (axes[i].elementIdentifier != elementIdentifier.id)
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

			private sealed class QjydVfFdmGZRmHDOfDunkvKuvAiFA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Axis vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_InternalDriver_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public QjydVfFdmGZRmHDOfDunkvKuvAiFA(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_InternalDriver_Base platform_InternalDriver_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_InternalDriver_Base.elements == null || platform_InternalDriver_Base.elements.axes == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_InternalDriver_Base.elements.axes.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_InternalDriver_Base.elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					QjydVfFdmGZRmHDOfDunkvKuvAiFA qjydVfFdmGZRmHDOfDunkvKuvAiFA;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						qjydVfFdmGZRmHDOfDunkvKuvAiFA = this;
					}
					else
					{
						qjydVfFdmGZRmHDOfDunkvKuvAiFA = new QjydVfFdmGZRmHDOfDunkvKuvAiFA(0);
						qjydVfFdmGZRmHDOfDunkvKuvAiFA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return qjydVfFdmGZRmHDOfDunkvKuvAiFA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class YTRsUzBmwOAYMYOfNAewCEkWMVAGb : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Button vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_InternalDriver_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public YTRsUzBmwOAYMYOfNAewCEkWMVAGb(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_InternalDriver_Base platform_InternalDriver_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_InternalDriver_Base.elements == null || platform_InternalDriver_Base.elements.buttons == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_InternalDriver_Base.elements.buttons.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_InternalDriver_Base.elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					YTRsUzBmwOAYMYOfNAewCEkWMVAGb yTRsUzBmwOAYMYOfNAewCEkWMVAGb;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						yTRsUzBmwOAYMYOfNAewCEkWMVAGb = this;
					}
					else
					{
						yTRsUzBmwOAYMYOfNAewCEkWMVAGb = new YTRsUzBmwOAYMYOfNAewCEkWMVAGb(0);
						yTRsUzBmwOAYMYOfNAewCEkWMVAGb.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return yTRsUzBmwOAYMYOfNAewCEkWMVAGb;
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

			internal override InputPlatform platform => InputPlatform.InternalDriver;

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
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
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

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new QjydVfFdmGZRmHDOfDunkvKuvAiFA(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new YTRsUzBmwOAYMYOfNAewCEkWMVAGb(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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
						cVYJEBfLvgYrXDhiJFUgeoqupBRXA(elementCount);
						return elementCount;
					}

					internal override void cVYJEBfLvgYrXDhiJFUgeoqupBRXA(ElementCount_Base P_0)
					{
						base.cVYJEBfLvgYrXDhiJFUgeoqupBRXA(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal override bool TUibHCXgdJpNwgxVPYRazOMZLYAI(BridgedControllerHWInfo P_0)
					{
						if (!base.TUibHCXgdJpNwgxVPYRazOMZLYAI(P_0))
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
				private sealed class NOrmVbxNFFbccbUsGGevEhTheHlM : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private Axis vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public Elements zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public NOrmVbxNFFbccbUsGGevEhTheHlM(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						Elements elements = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						switch (num)
						{
						default:
							return false;
						case 0:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (elements.axes == null)
							{
								return false;
							}
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
							break;
						case 1:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
							break;
						}
						if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < elements.axes.Length)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
						NOrmVbxNFFbccbUsGGevEhTheHlM nOrmVbxNFFbccbUsGGevEhTheHlM;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							nOrmVbxNFFbccbUsGGevEhTheHlM = this;
						}
						else
						{
							nOrmVbxNFFbccbUsGGevEhTheHlM = new NOrmVbxNFFbccbUsGGevEhTheHlM(0);
							nOrmVbxNFFbccbUsGGevEhTheHlM.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return nOrmVbxNFFbccbUsGGevEhTheHlM;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}
				}

				private sealed class NmzsJHIJAcOmcIQjwQMLFKJsAkmIA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private Button vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public Elements zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public NmzsJHIJAcOmcIQjwQMLFKJsAkmIA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						Elements elements = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						switch (num)
						{
						default:
							return false;
						case 0:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (elements.buttons == null)
							{
								return false;
							}
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
							break;
						case 1:
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
							break;
						}
						if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < elements.buttons.Length)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
						NmzsJHIJAcOmcIQjwQMLFKJsAkmIA nmzsJHIJAcOmcIQjwQMLFKJsAkmIA;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							nmzsJHIJAcOmcIQjwQMLFKJsAkmIA = this;
						}
						else
						{
							nmzsJHIJAcOmcIQjwQMLFKJsAkmIA = new NmzsJHIJAcOmcIQjwQMLFKJsAkmIA(0);
							nmzsJHIJAcOmcIQjwQMLFKJsAkmIA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return nmzsJHIJAcOmcIQjwQMLFKJsAkmIA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
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

				internal IEnumerable<Axis> Axes => new NOrmVbxNFFbccbUsGGevEhTheHlM(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};

				internal IEnumerable<Button> Buttons => new NmzsJHIJAcOmcIQjwQMLFKJsAkmIA(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};

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
						if (axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.id)
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
						if (axes[i].elementIdentifier != elementIdentifier.id)
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

			private sealed class LArIGvUOuGfuCFdoQvKfINEwmzXh : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Axis vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_SDL2_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int CdkttMoAtzQraIsMtDkJCAdHdyAxA;

				private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public LArIGvUOuGfuCFdoQvKfINEwmzXh(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_SDL2_Base platform_SDL2_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_SDL2_Base.elements == null || platform_SDL2_Base.elements.axes == null)
						{
							return false;
						}
						CdkttMoAtzQraIsMtDkJCAdHdyAxA = platform_SDL2_Base.elements.axes.Length;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
						break;
					}
					if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < CdkttMoAtzQraIsMtDkJCAdHdyAxA)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_SDL2_Base.elements.axes[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					LArIGvUOuGfuCFdoQvKfINEwmzXh lArIGvUOuGfuCFdoQvKfINEwmzXh;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						lArIGvUOuGfuCFdoQvKfINEwmzXh = this;
					}
					else
					{
						lArIGvUOuGfuCFdoQvKfINEwmzXh = new LArIGvUOuGfuCFdoQvKfINEwmzXh(0);
						lArIGvUOuGfuCFdoQvKfINEwmzXh.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return lArIGvUOuGfuCFdoQvKfINEwmzXh;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class sgDpzwVYlqoYybjpqCvjWPtvztMQ : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Button vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_SDL2_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int PPZKIFYQBjAqZdsYLXzIiaPJEZNFA;

				private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public sgDpzwVYlqoYybjpqCvjWPtvztMQ(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_SDL2_Base platform_SDL2_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_SDL2_Base.elements == null || platform_SDL2_Base.elements.buttons == null)
						{
							return false;
						}
						PPZKIFYQBjAqZdsYLXzIiaPJEZNFA = platform_SDL2_Base.elements.buttons.Length;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
						break;
					}
					if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < PPZKIFYQBjAqZdsYLXzIiaPJEZNFA)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_SDL2_Base.elements.buttons[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					sgDpzwVYlqoYybjpqCvjWPtvztMQ sgDpzwVYlqoYybjpqCvjWPtvztMQ2;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						sgDpzwVYlqoYybjpqCvjWPtvztMQ2 = this;
					}
					else
					{
						sgDpzwVYlqoYybjpqCvjWPtvztMQ2 = new sgDpzwVYlqoYybjpqCvjWPtvztMQ(0);
						sgDpzwVYlqoYybjpqCvjWPtvztMQ2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return sgDpzwVYlqoYybjpqCvjWPtvztMQ2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform => InputPlatform.SDL2;

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

			internal IEnumerable<Axis> IterateAxes()
			{
				return new LArIGvUOuGfuCFdoQvKfINEwmzXh(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};
			}

			internal IEnumerable<Button> IterateButtons()
			{
				return new sgDpzwVYlqoYybjpqCvjWPtvztMQ(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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

			internal override InputPlatform platform => InputPlatform.Steam;

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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.id)
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
						if (axes[i].elementIdentifier != elementIdentifier.id)
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

			private sealed class CRJfWAjsNGRvtzUpFKLzMLaDUNZx : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Axis vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_WebGL_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public CRJfWAjsNGRvtzUpFKLzMLaDUNZx(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_WebGL_Base platform_WebGL_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_WebGL_Base.elements == null || platform_WebGL_Base.elements.axes == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_WebGL_Base.elements.axes.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_WebGL_Base.elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					CRJfWAjsNGRvtzUpFKLzMLaDUNZx cRJfWAjsNGRvtzUpFKLzMLaDUNZx;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						cRJfWAjsNGRvtzUpFKLzMLaDUNZx = this;
					}
					else
					{
						cRJfWAjsNGRvtzUpFKLzMLaDUNZx = new CRJfWAjsNGRvtzUpFKLzMLaDUNZx(0);
						cRJfWAjsNGRvtzUpFKLzMLaDUNZx.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return cRJfWAjsNGRvtzUpFKLzMLaDUNZx;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class txWawAiUncEslERHaRkWgRIgexyDA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Button vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_WebGL_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public txWawAiUncEslERHaRkWgRIgexyDA(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_WebGL_Base platform_WebGL_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_WebGL_Base.elements == null || platform_WebGL_Base.elements.buttons == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_WebGL_Base.elements.buttons.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_WebGL_Base.elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					txWawAiUncEslERHaRkWgRIgexyDA txWawAiUncEslERHaRkWgRIgexyDA2;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						txWawAiUncEslERHaRkWgRIgexyDA2 = this;
					}
					else
					{
						txWawAiUncEslERHaRkWgRIgexyDA2 = new txWawAiUncEslERHaRkWgRIgexyDA(0);
						txWawAiUncEslERHaRkWgRIgexyDA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return txWawAiUncEslERHaRkWgRIgexyDA2;
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

			internal override InputPlatform platform => InputPlatform.WebGL;

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
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
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

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new CRJfWAjsNGRvtzUpFKLzMLaDUNZx(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new txWawAiUncEslERHaRkWgRIgexyDA(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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

				internal override bool hasData
				{
					get
					{
						if (base.hasData)
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
						if (axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.id)
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
						if (axes[i].elementIdentifier != elementIdentifier.id)
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

			private sealed class ChqIEJWaBRIiUywbHkqjuGFQmSwn : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Axis vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_AppleGCController_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public ChqIEJWaBRIiUywbHkqjuGFQmSwn(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_AppleGCController_Base platform_AppleGCController_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_AppleGCController_Base.elements == null || platform_AppleGCController_Base.elements.axes == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_AppleGCController_Base.elements.axes.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_AppleGCController_Base.elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					ChqIEJWaBRIiUywbHkqjuGFQmSwn chqIEJWaBRIiUywbHkqjuGFQmSwn;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						chqIEJWaBRIiUywbHkqjuGFQmSwn = this;
					}
					else
					{
						chqIEJWaBRIiUywbHkqjuGFQmSwn = new ChqIEJWaBRIiUywbHkqjuGFQmSwn(0);
						chqIEJWaBRIiUywbHkqjuGFQmSwn.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return chqIEJWaBRIiUywbHkqjuGFQmSwn;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class NMWSxoUNPrvcoGoDhrAScRjeMxwi : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Button vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_AppleGCController_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public NMWSxoUNPrvcoGoDhrAScRjeMxwi(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_AppleGCController_Base platform_AppleGCController_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_AppleGCController_Base.elements == null || platform_AppleGCController_Base.elements.buttons == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_AppleGCController_Base.elements.buttons.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_AppleGCController_Base.elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					NMWSxoUNPrvcoGoDhrAScRjeMxwi nMWSxoUNPrvcoGoDhrAScRjeMxwi;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						nMWSxoUNPrvcoGoDhrAScRjeMxwi = this;
					}
					else
					{
						nMWSxoUNPrvcoGoDhrAScRjeMxwi = new NMWSxoUNPrvcoGoDhrAScRjeMxwi(0);
						nMWSxoUNPrvcoGoDhrAScRjeMxwi.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return nMWSxoUNPrvcoGoDhrAScRjeMxwi;
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

			internal override InputPlatform platform => InputPlatform.AppleGameController;

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
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
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

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new ChqIEJWaBRIiUywbHkqjuGFQmSwn(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new NMWSxoUNPrvcoGoDhrAScRjeMxwi(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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

				internal override bool hasData
				{
					get
					{
						if (base.hasData)
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
					for (int i = 0; i < axisCount; i++)
					{
						if (axes[i].elementIdentifier == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
					}
					for (int j = 0; j < buttonCount; j++)
					{
						if (buttons[j].elementIdentifier == elementIdentifier.id)
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
						if (axes[i].elementIdentifier != elementIdentifier.id)
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

			private sealed class KmGHcrHgKvODZxFCabIdabyfJzyN : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Axis vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_WindowsWGI_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public KmGHcrHgKvODZxFCabIdabyfJzyN(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_WindowsWGI_Base platform_WindowsWGI_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_WindowsWGI_Base.elements == null || platform_WindowsWGI_Base.elements.axes == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_WindowsWGI_Base.elements.axes.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_WindowsWGI_Base.elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					KmGHcrHgKvODZxFCabIdabyfJzyN kmGHcrHgKvODZxFCabIdabyfJzyN;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						kmGHcrHgKvODZxFCabIdabyfJzyN = this;
					}
					else
					{
						kmGHcrHgKvODZxFCabIdabyfJzyN = new KmGHcrHgKvODZxFCabIdabyfJzyN(0);
						kmGHcrHgKvODZxFCabIdabyfJzyN.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return kmGHcrHgKvODZxFCabIdabyfJzyN;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}
			}

			private sealed class MAQFUodOGDKNRhsIefrptjDbsivlc : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int hMnbMujJvihgLcBmOvURwCGCKZDT;

				private Platform_Custom.Button vjnbYLtrPMftzpjohNfommerCnGo;

				private int AyagikQIJAatoHzFlyaifyWyaTktA;

				public Platform_WindowsWGI_Base zITtixdgVFWlEnpDnrTdnZsdTFkt;

				private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return vjnbYLtrPMftzpjohNfommerCnGo;
					}
				}

				[DebuggerHidden]
				public MAQFUodOGDKNRhsIefrptjDbsivlc(int P_0)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
					AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					Platform_WindowsWGI_Base platform_WindowsWGI_Base = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (platform_WindowsWGI_Base.elements == null || platform_WindowsWGI_Base.elements.buttons == null)
						{
							return false;
						}
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
						break;
					}
					if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < platform_WindowsWGI_Base.elements.buttons.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = platform_WindowsWGI_Base.elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
					MAQFUodOGDKNRhsIefrptjDbsivlc mAQFUodOGDKNRhsIefrptjDbsivlc;
					if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
						mAQFUodOGDKNRhsIefrptjDbsivlc = this;
					}
					else
					{
						mAQFUodOGDKNRhsIefrptjDbsivlc = new MAQFUodOGDKNRhsIefrptjDbsivlc(0);
						mAQFUodOGDKNRhsIefrptjDbsivlc.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					}
					return mAQFUodOGDKNRhsIefrptjDbsivlc;
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

			internal override InputPlatform platform => InputPlatform.WindowsWGI;

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
							for (int i = 0; i < axes_orig.Length; i++)
							{
								_axesOrigGame[i] = axes_orig[i];
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

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return new KmGHcrHgKvODZxFCabIdabyfJzyN(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
				};
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return new MAQFUodOGDKNRhsIefrptjDbsivlc(-2)
				{
					zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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

		private sealed class oaFVZFYNyRBwjRXIOOxIBHcgESbX : IDisposable, IEnumerable, IEnumerator, IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerator<IControllerElementIdentifierCommon_Internal>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private IControllerElementIdentifierCommon_Internal vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public HardwareJoystickMap zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public oaFVZFYNyRBwjRXIOOxIBHcgESbX(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				HardwareJoystickMap hardwareJoystickMap = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				switch (num)
				{
				default:
					return false;
				case 0:
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					if (hardwareJoystickMap.elementIdentifiers == null)
					{
						return false;
					}
					XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
					break;
				case 1:
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
					break;
				}
				if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < hardwareJoystickMap.elementIdentifiers.Length)
				{
					vjnbYLtrPMftzpjohNfommerCnGo = hardwareJoystickMap.elementIdentifiers[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
					hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
				oaFVZFYNyRBwjRXIOOxIBHcgESbX oaFVZFYNyRBwjRXIOOxIBHcgESbX2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					oaFVZFYNyRBwjRXIOOxIBHcgESbX2 = this;
				}
				else
				{
					oaFVZFYNyRBwjRXIOOxIBHcgESbX2 = new oaFVZFYNyRBwjRXIOOxIBHcgESbX(0);
					oaFVZFYNyRBwjRXIOOxIBHcgESbX2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				return oaFVZFYNyRBwjRXIOOxIBHcgESbX2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<IControllerElementIdentifierCommon_Internal>)this).GetEnumerator();
			}
		}

		private sealed class xOusCUxhntWryjopSTVXfBpZKXQO : IDisposable, IEnumerable, IEnumerator, IEnumerable<ControllerElementIdentifier>, IEnumerator<ControllerElementIdentifier>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ControllerElementIdentifier vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public HardwareJoystickMap zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

			ControllerElementIdentifier IEnumerator<ControllerElementIdentifier>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public xOusCUxhntWryjopSTVXfBpZKXQO(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				HardwareJoystickMap hardwareJoystickMap = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				switch (num)
				{
				default:
					return false;
				case 0:
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					if (hardwareJoystickMap.elementIdentifiers == null)
					{
						return false;
					}
					XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
					break;
				case 1:
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
					break;
				}
				if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < hardwareJoystickMap.elementIdentifiers.Length)
				{
					vjnbYLtrPMftzpjohNfommerCnGo = hardwareJoystickMap.elementIdentifiers[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
					hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
				xOusCUxhntWryjopSTVXfBpZKXQO xOusCUxhntWryjopSTVXfBpZKXQO2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					xOusCUxhntWryjopSTVXfBpZKXQO2 = this;
				}
				else
				{
					xOusCUxhntWryjopSTVXfBpZKXQO2 = new xOusCUxhntWryjopSTVXfBpZKXQO(0);
					xOusCUxhntWryjopSTVXfBpZKXQO2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				return xOusCUxhntWryjopSTVXfBpZKXQO2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerElementIdentifier>)this).GetEnumerator();
			}
		}

		private sealed class NRcjgvXVmciRNvitSBiTvkUHnaL : IDisposable, IEnumerable, IEnumerator, IEnumerable<JoystickType>, IEnumerator<JoystickType>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private JoystickType vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public HardwareJoystickMap zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

			JoystickType IEnumerator<JoystickType>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public NRcjgvXVmciRNvitSBiTvkUHnaL(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				HardwareJoystickMap hardwareJoystickMap = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				switch (num)
				{
				default:
					return false;
				case 0:
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					if (hardwareJoystickMap.joystickTypes == null)
					{
						return false;
					}
					XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
					break;
				case 1:
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
					break;
				}
				if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < hardwareJoystickMap.joystickTypes.Length)
				{
					vjnbYLtrPMftzpjohNfommerCnGo = hardwareJoystickMap.joystickTypes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
					hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
				NRcjgvXVmciRNvitSBiTvkUHnaL nRcjgvXVmciRNvitSBiTvkUHnaL;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					nRcjgvXVmciRNvitSBiTvkUHnaL = this;
				}
				else
				{
					nRcjgvXVmciRNvitSBiTvkUHnaL = new NRcjgvXVmciRNvitSBiTvkUHnaL(0);
					nRcjgvXVmciRNvitSBiTvkUHnaL.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				return nRcjgvXVmciRNvitSBiTvkUHnaL;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JoystickType>)this).GetEnumerator();
			}
		}

		private sealed class QClMlAruXgbTHlSaLHKamIJUsUiw : IDisposable, IEnumerable, IEnumerator, IEnumerable<Guid>, IEnumerator<Guid>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private Guid vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public HardwareJoystickMap zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private Guid[] lBDsUSdaIvTOeKPDdHeZNxbFmmIE;

			private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

			Guid IEnumerator<Guid>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public QClMlAruXgbTHlSaLHKamIJUsUiw(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				HardwareJoystickMap hardwareJoystickMap = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				switch (num)
				{
				default:
					return false;
				case 0:
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					if (ReInput.isReady)
					{
						lBDsUSdaIvTOeKPDdHeZNxbFmmIE = hardwareJoystickMap.runtimeTemplateGuids;
						if (lBDsUSdaIvTOeKPDdHeZNxbFmmIE == null)
						{
							return false;
						}
						PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
						goto IL_0086;
					}
					if (hardwareJoystickMap.templateGuids == null)
					{
						return false;
					}
					PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
					goto IL_00ea;
				case 1:
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
					goto IL_0086;
				case 2:
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
						goto IL_00ea;
					}
					IL_0086:
					if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < lBDsUSdaIvTOeKPDdHeZNxbFmmIE.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = lBDsUSdaIvTOeKPDdHeZNxbFmmIE[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					lBDsUSdaIvTOeKPDdHeZNxbFmmIE = null;
					break;
					IL_00ea:
					if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < hardwareJoystickMap.templateGuids.Length)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = StringTools.ToGuid(hardwareJoystickMap.templateGuids[PrfhaiCANHhjwtWLxlpNIHvkLSmF]);
						hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
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
				QClMlAruXgbTHlSaLHKamIJUsUiw qClMlAruXgbTHlSaLHKamIJUsUiw;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					qClMlAruXgbTHlSaLHKamIJUsUiw = this;
				}
				else
				{
					qClMlAruXgbTHlSaLHKamIJUsUiw = new QClMlAruXgbTHlSaLHKamIJUsUiw(0);
					qClMlAruXgbTHlSaLHKamIJUsUiw.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				return qClMlAruXgbTHlSaLHKamIJUsUiw;
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string editorControllerName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string description;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string controllerGuid;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string controllerKey;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string[] templateGuids;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool hideInLists;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private JoystickType[] joystickTypes;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerElementIdentifier[] elementIdentifiers;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private CompoundElement[] compoundElements;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_DirectInput directInput;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_RawInput rawInput;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_XInput xInput;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_WindowsWGI windowsWGI;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_WindowsUWP;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_OSX;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_Linux;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_Linux_PreConfigured;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_PSM;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_GameCore gameCore;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_PS4 ps4;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_NintendoSwitch nintendoSwitch;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_InternalDriver internalDriver;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_SDL2 sdl2_Linux;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_SDL2 sdl2_Windows;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_SDL2 sdl2_OSX;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_AppleGCController appleGCController;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		public IEnumerable<Guid> TemplateGuids => new QClMlAruXgbTHlSaLHKamIJUsUiw(-2)
		{
			zITtixdgVFWlEnpDnrTdnZsdTFkt = this
		};

		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers => new xOusCUxhntWryjopSTVXfBpZKXQO(-2)
		{
			zITtixdgVFWlEnpDnrTdnZsdTFkt = this
		};

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

		internal IEnumerable<JoystickType> JoystickTypes => new NRcjgvXVmciRNvitSBiTvkUHnaL(-2)
		{
			zITtixdgVFWlEnpDnrTdnZsdTFkt = this
		};

		Guid IHardwareControllerMap_Internal.typeGuid => Guid;

		string IHardwareControllerMap_Internal.typeKey => controllerKey;

		ControllerType IHardwareControllerMap_Internal.controllerType => ControllerType.Joystick;

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers => new oaFVZFYNyRBwjRXIOOxIBHcgESbX(-2)
		{
			zITtixdgVFWlEnpDnrTdnZsdTFkt = this
		};

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
				array[i] = elementIdentifiers[i].name;
			}
			return array;
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
				array[i] = elementIdentifiers[i].id;
			}
			return array;
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
				names[j] = list[j].name;
				ids[j] = list[j].id;
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
				names[j] = list[j].name;
				ids[j] = list[j].id;
			}
			return count;
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
				if (elementIdentifiers[i].id == id)
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
				if (!xfQMULbDolNOSljfhItZwOwIzFQO.SYETLKcbFhUFoZVjYnuOpkJSSgOW)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.Custom;
				platformMap = xfQMULbDolNOSljfhItZwOwIzFQO.yfaoAUnZOzlFDDNOaSMvsBPbstKq().GetPlatformMap(xfQMULbDolNOSljfhItZwOwIzFQO.KoWxltGMrPwtBkQrjsSOinWhIuLE, Guid);
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
				if (!xfQMULbDolNOSljfhItZwOwIzFQO.SYETLKcbFhUFoZVjYnuOpkJSSgOW)
				{
					return null;
				}
				actualInputPlatform = InputPlatform.Custom;
				platform = xfQMULbDolNOSljfhItZwOwIzFQO.yfaoAUnZOzlFDDNOaSMvsBPbstKq().GetPlatformMap(xfQMULbDolNOSljfhItZwOwIzFQO.KoWxltGMrPwtBkQrjsSOinWhIuLE, Guid);
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
				if (!xfQMULbDolNOSljfhItZwOwIzFQO.SYETLKcbFhUFoZVjYnuOpkJSSgOW)
				{
					throw new Exception("Custom Platform is not set.");
				}
				try
				{
					return xfQMULbDolNOSljfhItZwOwIzFQO.yfaoAUnZOzlFDDNOaSMvsBPbstKq().GetPlatformMap(xfQMULbDolNOSljfhItZwOwIzFQO.KoWxltGMrPwtBkQrjsSOinWhIuLE, Guid);
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
