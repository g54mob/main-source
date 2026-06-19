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
			private sealed class UBAAhkZmQEeMEFbSykVJFgxehTJX : IDisposable, IEnumerator, IEnumerable<Platform>, IEnumerator<Platform>, IEnumerable
			{
				private Platform ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public IList<Platform> ckkdFRNzDyHoCnIPkIPtBlqlNfWa;

				public int RdIkurGWdFFFQblfWBSLBjRihMet;

				Platform IEnumerator<Platform>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform> IEnumerable<Platform>.GetEnumerator()
				{
					UBAAhkZmQEeMEFbSykVJFgxehTJX uBAAhkZmQEeMEFbSykVJFgxehTJX;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						uBAAhkZmQEeMEFbSykVJFgxehTJX = this;
					}
					else
					{
						uBAAhkZmQEeMEFbSykVJFgxehTJX = new UBAAhkZmQEeMEFbSykVJFgxehTJX(0);
						uBAAhkZmQEeMEFbSykVJFgxehTJX.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return uBAAhkZmQEeMEFbSykVJFgxehTJX;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						ckkdFRNzDyHoCnIPkIPtBlqlNfWa = kdBZqupjvsCsVkwJiOeEQzkEDVO.variants_base;
						if (ckkdFRNzDyHoCnIPkIPtBlqlNfWa == null)
						{
							break;
						}
						RdIkurGWdFFFQblfWBSLBjRihMet = 0;
						goto IL_008b;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							goto IL_007d;
						}
						IL_007d:
						RdIkurGWdFFFQblfWBSLBjRihMet++;
						goto IL_008b;
						IL_008b:
						if (RdIkurGWdFFFQblfWBSLBjRihMet >= ckkdFRNzDyHoCnIPkIPtBlqlNfWa.Count)
						{
							break;
						}
						if (ckkdFRNzDyHoCnIPkIPtBlqlNfWa[RdIkurGWdFFFQblfWBSLBjRihMet] != null)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = ckkdFRNzDyHoCnIPkIPtBlqlNfWa[RdIkurGWdFFFQblfWBSLBjRihMet];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							return true;
						}
						goto IL_007d;
					}
					return false;
				}

				bool IEnumerator.MoveNext()
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
				public UBAAhkZmQEeMEFbSykVJFgxehTJX(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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
					UBAAhkZmQEeMEFbSykVJFgxehTJX uBAAhkZmQEeMEFbSykVJFgxehTJX = new UBAAhkZmQEeMEFbSykVJFgxehTJX(-2);
					uBAAhkZmQEeMEFbSykVJFgxehTJX.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return uBAAhkZmQEeMEFbSykVJFgxehTJX;
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
					hardwareJoystickMap_InputManager.elementIdentifiers[i] = new ControllerElementIdentifier(elementIdentifiers[i], hardwareJoystickMap_InputManager.map.IsElementIdentifierMapped(elementIdentifiers[i].id), hardwareJoystickMap_InputManager.map.GetEffectiveElementIdentifierType(elementIdentifiers[i]));
				}
				if ((inputSource == InputSource.PS4 && hardwareJoystickMap.Guid == Consts.joystickGuid_SonyDualShock4) || (inputSource == InputSource.PS4 && hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4AimController))
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
							if (inputSource == InputSource.PS4 && hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4AimController)
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
				for (int k = 0; k < elementIdentifierCount; k++)
				{
					if (hardwareJoystickMap_InputManager.elementIdentifiers[k].elementType == ControllerElementType.Axis)
					{
						if (string.IsNullOrEmpty(hardwareJoystickMap_InputManager.elementIdentifiers[k].positiveName))
						{
							hardwareJoystickMap_InputManager.elementIdentifiers[k].positiveName = hardwareJoystickMap_InputManager.elementIdentifiers[k].name + " +";
						}
						if (string.IsNullOrEmpty(hardwareJoystickMap_InputManager.elementIdentifiers[k].negativeName))
						{
							hardwareJoystickMap_InputManager.elementIdentifiers[k].negativeName = hardwareJoystickMap_InputManager.elementIdentifiers[k].name + " -";
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
					zbOgMCfNPBCiGEaoQdlRAPiXvTpO(elementCount_Base);
					return elementCount_Base;
				}

				internal virtual void zbOgMCfNPBCiGEaoQdlRAPiXvTpO(ElementCount_Base P_0)
				{
					if (P_0 != null)
					{
						P_0.axisCount = axisCount;
						P_0.buttonCount = buttonCount;
					}
				}

				internal virtual bool QuyjPPVLYssrxnLbKpFVOFYkPay(BridgedControllerHWInfo P_0)
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
					if (elementCount_Base != null && elementCount_Base.QuyjPPVLYssrxnLbKpFVOFYkPay(bridgedControllerHWInfo))
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
						zbOgMCfNPBCiGEaoQdlRAPiXvTpO(elementCount);
						return elementCount;
					}

					internal override void zbOgMCfNPBCiGEaoQdlRAPiXvTpO(ElementCount_Base P_0)
					{
						base.zbOgMCfNPBCiGEaoQdlRAPiXvTpO(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal override bool QuyjPPVLYssrxnLbKpFVOFYkPay(BridgedControllerHWInfo P_0)
					{
						if (!base.QuyjPPVLYssrxnLbKpFVOFYkPay(P_0))
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
				private sealed class ZtNjeMZRbjSCjteWXeDSaYPuIJJj : IDisposable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>, IEnumerable
				{
					private Axis_Base ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public Elements kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int JevXmDpRvyjlpjJLKFqXBLhmdVl;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
					{
						ZtNjeMZRbjSCjteWXeDSaYPuIJJj ztNjeMZRbjSCjteWXeDSaYPuIJJj;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							ztNjeMZRbjSCjteWXeDSaYPuIJJj = this;
						}
						else
						{
							ztNjeMZRbjSCjteWXeDSaYPuIJJj = new ZtNjeMZRbjSCjteWXeDSaYPuIJJj(0);
							ztNjeMZRbjSCjteWXeDSaYPuIJJj.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return ztNjeMZRbjSCjteWXeDSaYPuIJJj;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 0:
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							if (kdBZqupjvsCsVkwJiOeEQzkEDVO.axes == null)
							{
								break;
							}
							JevXmDpRvyjlpjJLKFqXBLhmdVl = 0;
							goto IL_006a;
						case 1:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								JevXmDpRvyjlpjJLKFqXBLhmdVl++;
								goto IL_006a;
							}
							IL_006a:
							if (JevXmDpRvyjlpjJLKFqXBLhmdVl < kdBZqupjvsCsVkwJiOeEQzkEDVO.axes.Length)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.axes[JevXmDpRvyjlpjJLKFqXBLhmdVl];
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public ZtNjeMZRbjSCjteWXeDSaYPuIJJj(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class zVFPzMGzTgIgSSmIeFKzCWrzIhL : IDisposable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>, IEnumerable
				{
					private Button_Base ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public Elements kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int ssQiiaNwdhAvfuyazuZzUgdhxCB;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
					{
						zVFPzMGzTgIgSSmIeFKzCWrzIhL zVFPzMGzTgIgSSmIeFKzCWrzIhL2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							zVFPzMGzTgIgSSmIeFKzCWrzIhL2 = this;
						}
						else
						{
							zVFPzMGzTgIgSSmIeFKzCWrzIhL2 = new zVFPzMGzTgIgSSmIeFKzCWrzIhL(0);
							zVFPzMGzTgIgSSmIeFKzCWrzIhL2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return zVFPzMGzTgIgSSmIeFKzCWrzIhL2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button_Base>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 0:
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							if (kdBZqupjvsCsVkwJiOeEQzkEDVO.buttons == null)
							{
								break;
							}
							ssQiiaNwdhAvfuyazuZzUgdhxCB = 0;
							goto IL_006a;
						case 1:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								ssQiiaNwdhAvfuyazuZzUgdhxCB++;
								goto IL_006a;
							}
							IL_006a:
							if (ssQiiaNwdhAvfuyazuZzUgdhxCB < kdBZqupjvsCsVkwJiOeEQzkEDVO.buttons.Length)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.buttons[ssQiiaNwdhAvfuyazuZzUgdhxCB];
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public zVFPzMGzTgIgSSmIeFKzCWrzIhL(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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
						ZtNjeMZRbjSCjteWXeDSaYPuIJJj ztNjeMZRbjSCjteWXeDSaYPuIJJj = new ZtNjeMZRbjSCjteWXeDSaYPuIJJj(-2);
						ztNjeMZRbjSCjteWXeDSaYPuIJJj.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
						return ztNjeMZRbjSCjteWXeDSaYPuIJJj;
					}
				}

				internal override IEnumerable<Button_Base> Buttons
				{
					get
					{
						zVFPzMGzTgIgSSmIeFKzCWrzIhL zVFPzMGzTgIgSSmIeFKzCWrzIhL2 = new zVFPzMGzTgIgSSmIeFKzCWrzIhL(-2);
						zVFPzMGzTgIgSSmIeFKzCWrzIhL2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
						return zVFPzMGzTgIgSSmIeFKzCWrzIhL2;
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

			private sealed class cdWNmsaeilIsZIMnKTZmizXiyAV : IDisposable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>, IEnumerable
			{
				private Axis_Base ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_DirectInput_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int HxiqwYcXKWbizYHjWJmYrIiJMyU;

				public int oVAvBsQpMmIVWcBtKuFcxhhHwKeJ;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
				{
					cdWNmsaeilIsZIMnKTZmizXiyAV cdWNmsaeilIsZIMnKTZmizXiyAV2;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						cdWNmsaeilIsZIMnKTZmizXiyAV2 = this;
					}
					else
					{
						cdWNmsaeilIsZIMnKTZmizXiyAV2 = new cdWNmsaeilIsZIMnKTZmizXiyAV(0);
						cdWNmsaeilIsZIMnKTZmizXiyAV2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return cdWNmsaeilIsZIMnKTZmizXiyAV2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes == null)
						{
							break;
						}
						HxiqwYcXKWbizYHjWJmYrIiJMyU = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes.Length;
						oVAvBsQpMmIVWcBtKuFcxhhHwKeJ = 0;
						goto IL_009c;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							oVAvBsQpMmIVWcBtKuFcxhhHwKeJ++;
							goto IL_009c;
						}
						IL_009c:
						if (oVAvBsQpMmIVWcBtKuFcxhhHwKeJ < HxiqwYcXKWbizYHjWJmYrIiJMyU)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes[oVAvBsQpMmIVWcBtKuFcxhhHwKeJ];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public cdWNmsaeilIsZIMnKTZmizXiyAV(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class qRJectyXuztEFBtYZkuNvJJRiVx : IDisposable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>, IEnumerable
			{
				private Button_Base ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_DirectInput_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int YBAwDYPHBljVmXKZVYtiKDPSgNl;

				public int IBBvFPBAeHgkACAzjHjXyMAdXvK;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
				{
					qRJectyXuztEFBtYZkuNvJJRiVx qRJectyXuztEFBtYZkuNvJJRiVx2;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						qRJectyXuztEFBtYZkuNvJJRiVx2 = this;
					}
					else
					{
						qRJectyXuztEFBtYZkuNvJJRiVx2 = new qRJectyXuztEFBtYZkuNvJJRiVx(0);
						qRJectyXuztEFBtYZkuNvJJRiVx2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return qRJectyXuztEFBtYZkuNvJJRiVx2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button_Base>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons == null)
						{
							break;
						}
						YBAwDYPHBljVmXKZVYtiKDPSgNl = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons.Length;
						IBBvFPBAeHgkACAzjHjXyMAdXvK = 0;
						goto IL_009c;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							IBBvFPBAeHgkACAzjHjXyMAdXvK++;
							goto IL_009c;
						}
						IL_009c:
						if (IBBvFPBAeHgkACAzjHjXyMAdXvK < YBAwDYPHBljVmXKZVYtiKDPSgNl)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons[IBBvFPBAeHgkACAzjHjXyMAdXvK];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public qRJectyXuztEFBtYZkuNvJJRiVx(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public Elements elements;

			internal override InputPlatform platform => InputPlatform.zjuIGPllhlPcayeppPtHSewObGXj;

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
						array[i] = identifiers[num3].name;
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
						array[i] = identifiers[num2].name;
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
						ref AxisCalibrationData reference = ref array[i];
						reference = AxisCalibrationData.Default;
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
						ref AxisCalibrationData reference2 = ref array[i];
						reference2 = AxisCalibrationData.Default;
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
				cdWNmsaeilIsZIMnKTZmizXiyAV cdWNmsaeilIsZIMnKTZmizXiyAV2 = new cdWNmsaeilIsZIMnKTZmizXiyAV(-2);
				cdWNmsaeilIsZIMnKTZmizXiyAV2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return cdWNmsaeilIsZIMnKTZmizXiyAV2;
			}

			internal override IEnumerable<Button_Base> IterateButtons()
			{
				qRJectyXuztEFBtYZkuNvJJRiVx qRJectyXuztEFBtYZkuNvJJRiVx2 = new qRJectyXuztEFBtYZkuNvJJRiVx(-2);
				qRJectyXuztEFBtYZkuNvJJRiVx2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return qRJectyXuztEFBtYZkuNvJJRiVx2;
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

			internal override IList<Platform> variants_base => variants;

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
				private sealed class mmRPAUBCtqbSYjreXkcadTKIpzZP : IDisposable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>, IEnumerable
				{
					private Axis_Base ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public Elements kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int IAufajgTVEfDtIardWDlPljJopAh;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
					{
						mmRPAUBCtqbSYjreXkcadTKIpzZP mmRPAUBCtqbSYjreXkcadTKIpzZP2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							mmRPAUBCtqbSYjreXkcadTKIpzZP2 = this;
						}
						else
						{
							mmRPAUBCtqbSYjreXkcadTKIpzZP2 = new mmRPAUBCtqbSYjreXkcadTKIpzZP(0);
							mmRPAUBCtqbSYjreXkcadTKIpzZP2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return mmRPAUBCtqbSYjreXkcadTKIpzZP2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis_Base>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 0:
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							if (kdBZqupjvsCsVkwJiOeEQzkEDVO.axes == null)
							{
								break;
							}
							IAufajgTVEfDtIardWDlPljJopAh = 0;
							goto IL_006a;
						case 1:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								IAufajgTVEfDtIardWDlPljJopAh++;
								goto IL_006a;
							}
							IL_006a:
							if (IAufajgTVEfDtIardWDlPljJopAh < kdBZqupjvsCsVkwJiOeEQzkEDVO.axes.Length)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.axes[IAufajgTVEfDtIardWDlPljJopAh];
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public mmRPAUBCtqbSYjreXkcadTKIpzZP(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class jSyGytYzUwTLYLKBhxKWOkldrK : IDisposable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>, IEnumerable
				{
					private Button_Base ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public Elements kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int FJiJTYzPgWaMTcQxGUugWslpIvv;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
					{
						jSyGytYzUwTLYLKBhxKWOkldrK jSyGytYzUwTLYLKBhxKWOkldrK2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							jSyGytYzUwTLYLKBhxKWOkldrK2 = this;
						}
						else
						{
							jSyGytYzUwTLYLKBhxKWOkldrK2 = new jSyGytYzUwTLYLKBhxKWOkldrK(0);
							jSyGytYzUwTLYLKBhxKWOkldrK2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return jSyGytYzUwTLYLKBhxKWOkldrK2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button_Base>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 0:
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							if (kdBZqupjvsCsVkwJiOeEQzkEDVO.buttons == null)
							{
								break;
							}
							FJiJTYzPgWaMTcQxGUugWslpIvv = 0;
							goto IL_006a;
						case 1:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								FJiJTYzPgWaMTcQxGUugWslpIvv++;
								goto IL_006a;
							}
							IL_006a:
							if (FJiJTYzPgWaMTcQxGUugWslpIvv < kdBZqupjvsCsVkwJiOeEQzkEDVO.buttons.Length)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.buttons[FJiJTYzPgWaMTcQxGUugWslpIvv];
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public jSyGytYzUwTLYLKBhxKWOkldrK(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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
						mmRPAUBCtqbSYjreXkcadTKIpzZP mmRPAUBCtqbSYjreXkcadTKIpzZP2 = new mmRPAUBCtqbSYjreXkcadTKIpzZP(-2);
						mmRPAUBCtqbSYjreXkcadTKIpzZP2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
						return mmRPAUBCtqbSYjreXkcadTKIpzZP2;
					}
				}

				internal override IEnumerable<Button_Base> Buttons
				{
					get
					{
						jSyGytYzUwTLYLKBhxKWOkldrK jSyGytYzUwTLYLKBhxKWOkldrK2 = new jSyGytYzUwTLYLKBhxKWOkldrK(-2);
						jSyGytYzUwTLYLKBhxKWOkldrK2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
						return jSyGytYzUwTLYLKBhxKWOkldrK2;
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

			private sealed class xNSrCGsMnqCGQBpvyptTWhIhaMp : IDisposable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>, IEnumerable
			{
				private Axis_Base ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_RawInput_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int wZebnuppTZlLbxZZLclcMHaZzMy;

				public int HNRLdhgkUpdGujvtnmHxfirufKDC;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
				{
					xNSrCGsMnqCGQBpvyptTWhIhaMp xNSrCGsMnqCGQBpvyptTWhIhaMp2;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						xNSrCGsMnqCGQBpvyptTWhIhaMp2 = this;
					}
					else
					{
						xNSrCGsMnqCGQBpvyptTWhIhaMp2 = new xNSrCGsMnqCGQBpvyptTWhIhaMp(0);
						xNSrCGsMnqCGQBpvyptTWhIhaMp2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return xNSrCGsMnqCGQBpvyptTWhIhaMp2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes == null)
						{
							break;
						}
						wZebnuppTZlLbxZZLclcMHaZzMy = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes.Length;
						HNRLdhgkUpdGujvtnmHxfirufKDC = 0;
						goto IL_009c;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							HNRLdhgkUpdGujvtnmHxfirufKDC++;
							goto IL_009c;
						}
						IL_009c:
						if (HNRLdhgkUpdGujvtnmHxfirufKDC < wZebnuppTZlLbxZZLclcMHaZzMy)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes[HNRLdhgkUpdGujvtnmHxfirufKDC];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public xNSrCGsMnqCGQBpvyptTWhIhaMp(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class cLUkiMaSZEUWoJTaNLcPZIFLgHUK : IDisposable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>, IEnumerable
			{
				private Button_Base ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_RawInput_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int PAOPxwZyiRlqwgYbcSvaWIGFHos;

				public int XnQtCBoMyoqJfhNgfDIaGWdqbfiE;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
				{
					cLUkiMaSZEUWoJTaNLcPZIFLgHUK cLUkiMaSZEUWoJTaNLcPZIFLgHUK2;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						cLUkiMaSZEUWoJTaNLcPZIFLgHUK2 = this;
					}
					else
					{
						cLUkiMaSZEUWoJTaNLcPZIFLgHUK2 = new cLUkiMaSZEUWoJTaNLcPZIFLgHUK(0);
						cLUkiMaSZEUWoJTaNLcPZIFLgHUK2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return cLUkiMaSZEUWoJTaNLcPZIFLgHUK2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button_Base>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons == null)
						{
							break;
						}
						PAOPxwZyiRlqwgYbcSvaWIGFHos = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons.Length;
						XnQtCBoMyoqJfhNgfDIaGWdqbfiE = 0;
						goto IL_009c;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							XnQtCBoMyoqJfhNgfDIaGWdqbfiE++;
							goto IL_009c;
						}
						IL_009c:
						if (XnQtCBoMyoqJfhNgfDIaGWdqbfiE < PAOPxwZyiRlqwgYbcSvaWIGFHos)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons[XnQtCBoMyoqJfhNgfDIaGWdqbfiE];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public cLUkiMaSZEUWoJTaNLcPZIFLgHUK(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public Elements elements;

			internal override InputPlatform platform => InputPlatform.HnmsmUSKysdUvrNYWdqtigLcwDX;

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
						array[i] = identifiers[num3].name;
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
						array[i] = identifiers[num2].name;
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
						ref AxisCalibrationData reference = ref array[i];
						reference = AxisCalibrationData.Default;
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
						ref AxisCalibrationData reference2 = ref array[i];
						reference2 = AxisCalibrationData.Default;
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
				xNSrCGsMnqCGQBpvyptTWhIhaMp xNSrCGsMnqCGQBpvyptTWhIhaMp2 = new xNSrCGsMnqCGQBpvyptTWhIhaMp(-2);
				xNSrCGsMnqCGQBpvyptTWhIhaMp2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return xNSrCGsMnqCGQBpvyptTWhIhaMp2;
			}

			internal override IEnumerable<Button_Base> IterateButtons()
			{
				cLUkiMaSZEUWoJTaNLcPZIFLgHUK cLUkiMaSZEUWoJTaNLcPZIFLgHUK2 = new cLUkiMaSZEUWoJTaNLcPZIFLgHUK(-2);
				cLUkiMaSZEUWoJTaNLcPZIFLgHUK2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return cLUkiMaSZEUWoJTaNLcPZIFLgHUK2;
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

			internal override IList<Platform> variants_base => variants;

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

			private sealed class iaScNujMufIelzNpdyKZdODhBra : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_XInput_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int tGYIJwRApfBfMvxMICYLngrnSDr;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					iaScNujMufIelzNpdyKZdODhBra iaScNujMufIelzNpdyKZdODhBra2;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						iaScNujMufIelzNpdyKZdODhBra2 = this;
					}
					else
					{
						iaScNujMufIelzNpdyKZdODhBra2 = new iaScNujMufIelzNpdyKZdODhBra(0);
						iaScNujMufIelzNpdyKZdODhBra2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return iaScNujMufIelzNpdyKZdODhBra2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes == null)
						{
							break;
						}
						tGYIJwRApfBfMvxMICYLngrnSDr = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							tGYIJwRApfBfMvxMICYLngrnSDr++;
							goto IL_0084;
						}
						IL_0084:
						if (tGYIJwRApfBfMvxMICYLngrnSDr < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes[tGYIJwRApfBfMvxMICYLngrnSDr];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public iaScNujMufIelzNpdyKZdODhBra(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class XsHdFnfqomxZyffSaOKjhRpeaewE : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_XInput_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int QlZqpgKSwAiFYsdWABHinYlTeBD;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					XsHdFnfqomxZyffSaOKjhRpeaewE xsHdFnfqomxZyffSaOKjhRpeaewE;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						xsHdFnfqomxZyffSaOKjhRpeaewE = this;
					}
					else
					{
						xsHdFnfqomxZyffSaOKjhRpeaewE = new XsHdFnfqomxZyffSaOKjhRpeaewE(0);
						xsHdFnfqomxZyffSaOKjhRpeaewE.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return xsHdFnfqomxZyffSaOKjhRpeaewE;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons == null)
						{
							break;
						}
						QlZqpgKSwAiFYsdWABHinYlTeBD = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							QlZqpgKSwAiFYsdWABHinYlTeBD++;
							goto IL_0084;
						}
						IL_0084:
						if (QlZqpgKSwAiFYsdWABHinYlTeBD < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons[QlZqpgKSwAiFYsdWABHinYlTeBD];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public XsHdFnfqomxZyffSaOKjhRpeaewE(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.JeLygDdKjPUUTKlZIRIVKzQWCev;

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
				iaScNujMufIelzNpdyKZdODhBra iaScNujMufIelzNpdyKZdODhBra2 = new iaScNujMufIelzNpdyKZdODhBra(-2);
				iaScNujMufIelzNpdyKZdODhBra2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return iaScNujMufIelzNpdyKZdODhBra2;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				XsHdFnfqomxZyffSaOKjhRpeaewE xsHdFnfqomxZyffSaOKjhRpeaewE = new XsHdFnfqomxZyffSaOKjhRpeaewE(-2);
				xsHdFnfqomxZyffSaOKjhRpeaewE.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return xsHdFnfqomxZyffSaOKjhRpeaewE;
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
						array[i] = identifiers[elementIdentifier].name;
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
						array[i] = identifiers[num].name;
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
						ref AxisCalibrationData reference = ref array[i];
						reference = AxisCalibrationData.Default;
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
						ref AxisCalibrationData reference2 = ref array[i];
						reference2 = AxisCalibrationData.Default;
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

			internal override IList<Platform> variants_base => variants;

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
						zbOgMCfNPBCiGEaoQdlRAPiXvTpO(elementCount);
						return elementCount;
					}

					internal override void zbOgMCfNPBCiGEaoQdlRAPiXvTpO(ElementCount_Base P_0)
					{
						base.zbOgMCfNPBCiGEaoQdlRAPiXvTpO(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal override bool QuyjPPVLYssrxnLbKpFVOFYkPay(BridgedControllerHWInfo P_0)
					{
						if (!base.QuyjPPVLYssrxnLbKpFVOFYkPay(P_0))
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
				private sealed class kxpsaasOudHirScAOeiriYTzGhSo : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
				{
					private Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public Elements kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public Axis IxnOEosmvRaRGAafoqRhiSgtTua;

					public Axis[] kVCojHdkqOeZCKFJmviKCbaJsI;

					public int HICDgeUNJPwocqlfZAMBlHJsozi;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						kxpsaasOudHirScAOeiriYTzGhSo kxpsaasOudHirScAOeiriYTzGhSo2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							kxpsaasOudHirScAOeiriYTzGhSo2 = this;
						}
						else
						{
							kxpsaasOudHirScAOeiriYTzGhSo2 = new kxpsaasOudHirScAOeiriYTzGhSo(0);
							kxpsaasOudHirScAOeiriYTzGhSo2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return kxpsaasOudHirScAOeiriYTzGhSo2;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (kdBZqupjvsCsVkwJiOeEQzkEDVO.axes == null)
								{
									break;
								}
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								kVCojHdkqOeZCKFJmviKCbaJsI = kdBZqupjvsCsVkwJiOeEQzkEDVO.axes;
								HICDgeUNJPwocqlfZAMBlHJsozi = 0;
								goto IL_0092;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									HICDgeUNJPwocqlfZAMBlHJsozi++;
									goto IL_0092;
								}
								IL_0092:
								if (HICDgeUNJPwocqlfZAMBlHJsozi < kVCojHdkqOeZCKFJmviKCbaJsI.Length)
								{
									IxnOEosmvRaRGAafoqRhiSgtTua = kVCojHdkqOeZCKFJmviKCbaJsI[HICDgeUNJPwocqlfZAMBlHJsozi];
									ajbaQItphrIyqhowgmMTfPkCBvcN = IxnOEosmvRaRGAafoqRhiSgtTua;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								DzYfdjdpfXYkFPSsGTLXlybjuoOM();
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							DzYfdjdpfXYkFPSsGTLXlybjuoOM();
							break;
						}
					}

					[DebuggerHidden]
					public kxpsaasOudHirScAOeiriYTzGhSo(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void DzYfdjdpfXYkFPSsGTLXlybjuoOM()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					}
				}

				private sealed class WslaVLJLtTaofFbJUfwAsVFSCsqA : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
				{
					private Button ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public Elements kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public Button SWAmVUFzsvXCFMEjPJFYxUSkGni;

					public Button[] JjEleBenKIeVJqTlyKwlSJCdSbw;

					public int RRWZSfhaHrvwINlYLiDwdNvNeDE;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						WslaVLJLtTaofFbJUfwAsVFSCsqA wslaVLJLtTaofFbJUfwAsVFSCsqA;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							wslaVLJLtTaofFbJUfwAsVFSCsqA = this;
						}
						else
						{
							wslaVLJLtTaofFbJUfwAsVFSCsqA = new WslaVLJLtTaofFbJUfwAsVFSCsqA(0);
							wslaVLJLtTaofFbJUfwAsVFSCsqA.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return wslaVLJLtTaofFbJUfwAsVFSCsqA;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (kdBZqupjvsCsVkwJiOeEQzkEDVO.buttons == null)
								{
									break;
								}
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								JjEleBenKIeVJqTlyKwlSJCdSbw = kdBZqupjvsCsVkwJiOeEQzkEDVO.buttons;
								RRWZSfhaHrvwINlYLiDwdNvNeDE = 0;
								goto IL_0092;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									RRWZSfhaHrvwINlYLiDwdNvNeDE++;
									goto IL_0092;
								}
								IL_0092:
								if (RRWZSfhaHrvwINlYLiDwdNvNeDE < JjEleBenKIeVJqTlyKwlSJCdSbw.Length)
								{
									SWAmVUFzsvXCFMEjPJFYxUSkGni = JjEleBenKIeVJqTlyKwlSJCdSbw[RRWZSfhaHrvwINlYLiDwdNvNeDE];
									ajbaQItphrIyqhowgmMTfPkCBvcN = SWAmVUFzsvXCFMEjPJFYxUSkGni;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								LdkYtZIsNFeBPpKMfArbUhScGYt();
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							LdkYtZIsNFeBPpKMfArbUhScGYt();
							break;
						}
					}

					[DebuggerHidden]
					public WslaVLJLtTaofFbJUfwAsVFSCsqA(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void LdkYtZIsNFeBPpKMfArbUhScGYt()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
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
					kxpsaasOudHirScAOeiriYTzGhSo kxpsaasOudHirScAOeiriYTzGhSo2 = new kxpsaasOudHirScAOeiriYTzGhSo(-2);
					kxpsaasOudHirScAOeiriYTzGhSo2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return kxpsaasOudHirScAOeiriYTzGhSo2;
				}

				public IEnumerable<Button> IterateButtons()
				{
					WslaVLJLtTaofFbJUfwAsVFSCsqA wslaVLJLtTaofFbJUfwAsVFSCsqA = new WslaVLJLtTaofFbJUfwAsVFSCsqA(-2);
					wslaVLJLtTaofFbJUfwAsVFSCsqA.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return wslaVLJLtTaofFbJUfwAsVFSCsqA;
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
					Button button = new Button();
					button.elementIdentifier = elementIdentifier;
					button.sourceType = sourceType;
					button.sourceButton = sourceButton;
					button.sourceStick = sourceStick;
					button.sourceAxis = sourceAxis;
					button.sourceOtherAxis = sourceOtherAxis;
					button.sourceAxisPole = sourceAxisPole;
					button.axisDeadZone = axisDeadZone;
					button.sourceHat = sourceHat;
					button.sourceHatType = sourceHatType;
					button.sourceHatDirection = sourceHatDirection;
					button.requireMultipleButtons = requireMultipleButtons;
					button.requiredButtons = ArrayTools.ShallowCopy(requiredButtons);
					button.ignoreIfButtonsActive = ignoreIfButtonsActive;
					button.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons);
					button.buttonInfo = MiscTools.DeepClone(buttonInfo);
					return button;
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
					axis.axisZero = axisZero;
					axis.axisMin = axisMin;
					axis.axisMax = axisMax;
					axis.axisInfo = MiscTools.DeepClone(axisInfo);
					axis.sourceButton = sourceButton;
					axis.buttonAxisContribution = buttonAxisContribution;
					axis.sourceHat = sourceHat;
					axis.sourceHatDirection = sourceHatDirection;
					axis.sourceHatRange = sourceHatRange;
					axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
					return axis;
				}
			}

			private sealed class oAsUHIZACWHNtbDUfeFhirhehDsx : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_OSX_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int ERPeDVoJbLlseYxWLUCfACSwsMz;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					oAsUHIZACWHNtbDUfeFhirhehDsx oAsUHIZACWHNtbDUfeFhirhehDsx2;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						oAsUHIZACWHNtbDUfeFhirhehDsx2 = this;
					}
					else
					{
						oAsUHIZACWHNtbDUfeFhirhehDsx2 = new oAsUHIZACWHNtbDUfeFhirhehDsx(0);
						oAsUHIZACWHNtbDUfeFhirhehDsx2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return oAsUHIZACWHNtbDUfeFhirhehDsx2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes == null)
						{
							break;
						}
						ERPeDVoJbLlseYxWLUCfACSwsMz = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							ERPeDVoJbLlseYxWLUCfACSwsMz++;
							goto IL_0084;
						}
						IL_0084:
						if (ERPeDVoJbLlseYxWLUCfACSwsMz < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes[ERPeDVoJbLlseYxWLUCfACSwsMz];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public oAsUHIZACWHNtbDUfeFhirhehDsx(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class ZKwLkFxFwLfDQhtgoYNHwhPpzUO : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_OSX_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int kPiBqlFRBgxpznTZZsdRIlsmMCRO;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					ZKwLkFxFwLfDQhtgoYNHwhPpzUO zKwLkFxFwLfDQhtgoYNHwhPpzUO;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						zKwLkFxFwLfDQhtgoYNHwhPpzUO = this;
					}
					else
					{
						zKwLkFxFwLfDQhtgoYNHwhPpzUO = new ZKwLkFxFwLfDQhtgoYNHwhPpzUO(0);
						zKwLkFxFwLfDQhtgoYNHwhPpzUO.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return zKwLkFxFwLfDQhtgoYNHwhPpzUO;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons == null)
						{
							break;
						}
						kPiBqlFRBgxpznTZZsdRIlsmMCRO = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							kPiBqlFRBgxpznTZZsdRIlsmMCRO++;
							goto IL_0084;
						}
						IL_0084:
						if (kPiBqlFRBgxpznTZZsdRIlsmMCRO < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons[kPiBqlFRBgxpznTZZsdRIlsmMCRO];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public ZKwLkFxFwLfDQhtgoYNHwhPpzUO(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.BNAbWQOUmbdcYxSUpDXHIqmUlal;

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
				oAsUHIZACWHNtbDUfeFhirhehDsx oAsUHIZACWHNtbDUfeFhirhehDsx2 = new oAsUHIZACWHNtbDUfeFhirhehDsx(-2);
				oAsUHIZACWHNtbDUfeFhirhehDsx2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return oAsUHIZACWHNtbDUfeFhirhehDsx2;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				ZKwLkFxFwLfDQhtgoYNHwhPpzUO zKwLkFxFwLfDQhtgoYNHwhPpzUO = new ZKwLkFxFwLfDQhtgoYNHwhPpzUO(-2);
				zKwLkFxFwLfDQhtgoYNHwhPpzUO.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return zKwLkFxFwLfDQhtgoYNHwhPpzUO;
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
						array[i] = identifiers[elementIdentifier].name;
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
						array[i] = identifiers[num].name;
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
						ref AxisCalibrationData reference = ref array[i];
						reference = AxisCalibrationData.Default;
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
						ref AxisCalibrationData reference2 = ref array[i];
						reference2 = AxisCalibrationData.Default;
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

			internal override IList<Platform> variants_base => variants;

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
						zbOgMCfNPBCiGEaoQdlRAPiXvTpO(elementCount);
						return elementCount;
					}

					internal override void zbOgMCfNPBCiGEaoQdlRAPiXvTpO(ElementCount_Base P_0)
					{
						base.zbOgMCfNPBCiGEaoQdlRAPiXvTpO(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal override bool QuyjPPVLYssrxnLbKpFVOFYkPay(BridgedControllerHWInfo P_0)
					{
						if (!base.QuyjPPVLYssrxnLbKpFVOFYkPay(P_0))
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
				private sealed class PbVPpYAUyMrkERDdTVYEDbnZuvJ : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
				{
					private Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public Elements kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int hKAkPsBlDyQPCjSuCBBsYjqQDtv;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						PbVPpYAUyMrkERDdTVYEDbnZuvJ pbVPpYAUyMrkERDdTVYEDbnZuvJ;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							pbVPpYAUyMrkERDdTVYEDbnZuvJ = this;
						}
						else
						{
							pbVPpYAUyMrkERDdTVYEDbnZuvJ = new PbVPpYAUyMrkERDdTVYEDbnZuvJ(0);
							pbVPpYAUyMrkERDdTVYEDbnZuvJ.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return pbVPpYAUyMrkERDdTVYEDbnZuvJ;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 0:
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							if (kdBZqupjvsCsVkwJiOeEQzkEDVO.axes == null)
							{
								break;
							}
							hKAkPsBlDyQPCjSuCBBsYjqQDtv = 0;
							goto IL_006a;
						case 1:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								hKAkPsBlDyQPCjSuCBBsYjqQDtv++;
								goto IL_006a;
							}
							IL_006a:
							if (hKAkPsBlDyQPCjSuCBBsYjqQDtv < kdBZqupjvsCsVkwJiOeEQzkEDVO.axes.Length)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.axes[hKAkPsBlDyQPCjSuCBBsYjqQDtv];
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public PbVPpYAUyMrkERDdTVYEDbnZuvJ(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class zGDfBLDsBDllPuscqrgKzlPWmms : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
				{
					private Button ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public Elements kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int LjAizcSPQCiAOwrINApSEyJuSsu;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						zGDfBLDsBDllPuscqrgKzlPWmms zGDfBLDsBDllPuscqrgKzlPWmms2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							zGDfBLDsBDllPuscqrgKzlPWmms2 = this;
						}
						else
						{
							zGDfBLDsBDllPuscqrgKzlPWmms2 = new zGDfBLDsBDllPuscqrgKzlPWmms(0);
							zGDfBLDsBDllPuscqrgKzlPWmms2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return zGDfBLDsBDllPuscqrgKzlPWmms2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 0:
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							if (kdBZqupjvsCsVkwJiOeEQzkEDVO.buttons == null)
							{
								break;
							}
							LjAizcSPQCiAOwrINApSEyJuSsu = 0;
							goto IL_006a;
						case 1:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								LjAizcSPQCiAOwrINApSEyJuSsu++;
								goto IL_006a;
							}
							IL_006a:
							if (LjAizcSPQCiAOwrINApSEyJuSsu < kdBZqupjvsCsVkwJiOeEQzkEDVO.buttons.Length)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.buttons[LjAizcSPQCiAOwrINApSEyJuSsu];
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public zGDfBLDsBDllPuscqrgKzlPWmms(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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
						PbVPpYAUyMrkERDdTVYEDbnZuvJ pbVPpYAUyMrkERDdTVYEDbnZuvJ = new PbVPpYAUyMrkERDdTVYEDbnZuvJ(-2);
						pbVPpYAUyMrkERDdTVYEDbnZuvJ.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
						return pbVPpYAUyMrkERDdTVYEDbnZuvJ;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					get
					{
						zGDfBLDsBDllPuscqrgKzlPWmms zGDfBLDsBDllPuscqrgKzlPWmms2 = new zGDfBLDsBDllPuscqrgKzlPWmms(-2);
						zGDfBLDsBDllPuscqrgKzlPWmms2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
						return zGDfBLDsBDllPuscqrgKzlPWmms2;
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

			private sealed class XUZCxYeMpzlxBYUyiBGeMFDEKRcM : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_Linux_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int PxkuKhxuTwoCSgpdUcgqgfOBZHD;

				public int XVKCCkbNbZuJqsYhZrbUNvFArnRi;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					XUZCxYeMpzlxBYUyiBGeMFDEKRcM xUZCxYeMpzlxBYUyiBGeMFDEKRcM;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						xUZCxYeMpzlxBYUyiBGeMFDEKRcM = this;
					}
					else
					{
						xUZCxYeMpzlxBYUyiBGeMFDEKRcM = new XUZCxYeMpzlxBYUyiBGeMFDEKRcM(0);
						xUZCxYeMpzlxBYUyiBGeMFDEKRcM.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return xUZCxYeMpzlxBYUyiBGeMFDEKRcM;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes == null)
						{
							break;
						}
						PxkuKhxuTwoCSgpdUcgqgfOBZHD = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes.Length;
						XVKCCkbNbZuJqsYhZrbUNvFArnRi = 0;
						goto IL_009c;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							XVKCCkbNbZuJqsYhZrbUNvFArnRi++;
							goto IL_009c;
						}
						IL_009c:
						if (XVKCCkbNbZuJqsYhZrbUNvFArnRi < PxkuKhxuTwoCSgpdUcgqgfOBZHD)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes[XVKCCkbNbZuJqsYhZrbUNvFArnRi];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public XUZCxYeMpzlxBYUyiBGeMFDEKRcM(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class wmdjEIoDVASULyMdlEDaddxirxF : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_Linux_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int iPwNDLGQAgGqaIDhbkwWctFogNI;

				public int ePsmqxrKBLxuchLWichKNQpxeeNJ;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					wmdjEIoDVASULyMdlEDaddxirxF wmdjEIoDVASULyMdlEDaddxirxF2;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						wmdjEIoDVASULyMdlEDaddxirxF2 = this;
					}
					else
					{
						wmdjEIoDVASULyMdlEDaddxirxF2 = new wmdjEIoDVASULyMdlEDaddxirxF(0);
						wmdjEIoDVASULyMdlEDaddxirxF2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return wmdjEIoDVASULyMdlEDaddxirxF2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons == null)
						{
							break;
						}
						iPwNDLGQAgGqaIDhbkwWctFogNI = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons.Length;
						ePsmqxrKBLxuchLWichKNQpxeeNJ = 0;
						goto IL_009c;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							ePsmqxrKBLxuchLWichKNQpxeeNJ++;
							goto IL_009c;
						}
						IL_009c:
						if (ePsmqxrKBLxuchLWichKNQpxeeNJ < iPwNDLGQAgGqaIDhbkwWctFogNI)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons[ePsmqxrKBLxuchLWichKNQpxeeNJ];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public wmdjEIoDVASULyMdlEDaddxirxF(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform => InputPlatform.ZYWfhkfXgXmhbJlTbCJAdwyQeaH;

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
						array[i] = identifiers[num3].name;
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
						array[i] = identifiers[num2].name;
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
						ref AxisCalibrationData reference = ref array[i];
						reference = AxisCalibrationData.Default;
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
						ref AxisCalibrationData reference2 = ref array[i];
						reference2 = AxisCalibrationData.Default;
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
				XUZCxYeMpzlxBYUyiBGeMFDEKRcM xUZCxYeMpzlxBYUyiBGeMFDEKRcM = new XUZCxYeMpzlxBYUyiBGeMFDEKRcM(-2);
				xUZCxYeMpzlxBYUyiBGeMFDEKRcM.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return xUZCxYeMpzlxBYUyiBGeMFDEKRcM;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				wmdjEIoDVASULyMdlEDaddxirxF wmdjEIoDVASULyMdlEDaddxirxF2 = new wmdjEIoDVASULyMdlEDaddxirxF(-2);
				wmdjEIoDVASULyMdlEDaddxirxF2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return wmdjEIoDVASULyMdlEDaddxirxF2;
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

			internal override IList<Platform> variants_base => variants;

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
						zbOgMCfNPBCiGEaoQdlRAPiXvTpO(elementCount);
						return elementCount;
					}

					internal override void zbOgMCfNPBCiGEaoQdlRAPiXvTpO(ElementCount_Base P_0)
					{
						base.zbOgMCfNPBCiGEaoQdlRAPiXvTpO(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal override bool QuyjPPVLYssrxnLbKpFVOFYkPay(BridgedControllerHWInfo P_0)
					{
						if (!base.QuyjPPVLYssrxnLbKpFVOFYkPay(P_0))
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
				private sealed class xdMUPIDiZmpVOmjHxMIWKTLVBUJ : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
				{
					private Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public Elements kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int grUlGyNAIwkUbEmxPXXNPjACaKw;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						xdMUPIDiZmpVOmjHxMIWKTLVBUJ xdMUPIDiZmpVOmjHxMIWKTLVBUJ2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							xdMUPIDiZmpVOmjHxMIWKTLVBUJ2 = this;
						}
						else
						{
							xdMUPIDiZmpVOmjHxMIWKTLVBUJ2 = new xdMUPIDiZmpVOmjHxMIWKTLVBUJ(0);
							xdMUPIDiZmpVOmjHxMIWKTLVBUJ2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return xdMUPIDiZmpVOmjHxMIWKTLVBUJ2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 0:
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							if (kdBZqupjvsCsVkwJiOeEQzkEDVO.axes == null)
							{
								break;
							}
							grUlGyNAIwkUbEmxPXXNPjACaKw = 0;
							goto IL_006a;
						case 1:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								grUlGyNAIwkUbEmxPXXNPjACaKw++;
								goto IL_006a;
							}
							IL_006a:
							if (grUlGyNAIwkUbEmxPXXNPjACaKw < kdBZqupjvsCsVkwJiOeEQzkEDVO.axes.Length)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.axes[grUlGyNAIwkUbEmxPXXNPjACaKw];
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public xdMUPIDiZmpVOmjHxMIWKTLVBUJ(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class RIhgMMZjbnhWZJjUwBfpBkMyzbFQ : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
				{
					private Button ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public Elements kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int MZIaXvCyBqAGZSfTvOmDYYbwdiQq;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						RIhgMMZjbnhWZJjUwBfpBkMyzbFQ rIhgMMZjbnhWZJjUwBfpBkMyzbFQ;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							rIhgMMZjbnhWZJjUwBfpBkMyzbFQ = this;
						}
						else
						{
							rIhgMMZjbnhWZJjUwBfpBkMyzbFQ = new RIhgMMZjbnhWZJjUwBfpBkMyzbFQ(0);
							rIhgMMZjbnhWZJjUwBfpBkMyzbFQ.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return rIhgMMZjbnhWZJjUwBfpBkMyzbFQ;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 0:
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							if (kdBZqupjvsCsVkwJiOeEQzkEDVO.buttons == null)
							{
								break;
							}
							MZIaXvCyBqAGZSfTvOmDYYbwdiQq = 0;
							goto IL_006a;
						case 1:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								MZIaXvCyBqAGZSfTvOmDYYbwdiQq++;
								goto IL_006a;
							}
							IL_006a:
							if (MZIaXvCyBqAGZSfTvOmDYYbwdiQq < kdBZqupjvsCsVkwJiOeEQzkEDVO.buttons.Length)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.buttons[MZIaXvCyBqAGZSfTvOmDYYbwdiQq];
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public RIhgMMZjbnhWZJjUwBfpBkMyzbFQ(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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
						xdMUPIDiZmpVOmjHxMIWKTLVBUJ xdMUPIDiZmpVOmjHxMIWKTLVBUJ2 = new xdMUPIDiZmpVOmjHxMIWKTLVBUJ(-2);
						xdMUPIDiZmpVOmjHxMIWKTLVBUJ2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
						return xdMUPIDiZmpVOmjHxMIWKTLVBUJ2;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					get
					{
						RIhgMMZjbnhWZJjUwBfpBkMyzbFQ rIhgMMZjbnhWZJjUwBfpBkMyzbFQ = new RIhgMMZjbnhWZJjUwBfpBkMyzbFQ(-2);
						rIhgMMZjbnhWZJjUwBfpBkMyzbFQ.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
						return rIhgMMZjbnhWZJjUwBfpBkMyzbFQ;
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

			private sealed class vVscNJJeSAZHNcdzPyVOdmhZzBCA : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_WindowsUWP_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int XzFbSrnkClYJDYnbjgoCNgpTkfS;

				public int rsQiWFqPDLQjHTPWqeuBgcrKIboB;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					vVscNJJeSAZHNcdzPyVOdmhZzBCA vVscNJJeSAZHNcdzPyVOdmhZzBCA2;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						vVscNJJeSAZHNcdzPyVOdmhZzBCA2 = this;
					}
					else
					{
						vVscNJJeSAZHNcdzPyVOdmhZzBCA2 = new vVscNJJeSAZHNcdzPyVOdmhZzBCA(0);
						vVscNJJeSAZHNcdzPyVOdmhZzBCA2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return vVscNJJeSAZHNcdzPyVOdmhZzBCA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes == null)
						{
							break;
						}
						XzFbSrnkClYJDYnbjgoCNgpTkfS = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes.Length;
						rsQiWFqPDLQjHTPWqeuBgcrKIboB = 0;
						goto IL_009c;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							rsQiWFqPDLQjHTPWqeuBgcrKIboB++;
							goto IL_009c;
						}
						IL_009c:
						if (rsQiWFqPDLQjHTPWqeuBgcrKIboB < XzFbSrnkClYJDYnbjgoCNgpTkfS)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes[rsQiWFqPDLQjHTPWqeuBgcrKIboB];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public vVscNJJeSAZHNcdzPyVOdmhZzBCA(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class fwvBYmGXthRGfgInCGNZfkuAhMd : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_WindowsUWP_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int NDWsdzoSBpLesfjOQXDuYgTagwy;

				public int ZgNBieIVqISnYBuMdPcAmUHsCuh;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					fwvBYmGXthRGfgInCGNZfkuAhMd fwvBYmGXthRGfgInCGNZfkuAhMd2;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						fwvBYmGXthRGfgInCGNZfkuAhMd2 = this;
					}
					else
					{
						fwvBYmGXthRGfgInCGNZfkuAhMd2 = new fwvBYmGXthRGfgInCGNZfkuAhMd(0);
						fwvBYmGXthRGfgInCGNZfkuAhMd2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return fwvBYmGXthRGfgInCGNZfkuAhMd2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons == null)
						{
							break;
						}
						NDWsdzoSBpLesfjOQXDuYgTagwy = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons.Length;
						ZgNBieIVqISnYBuMdPcAmUHsCuh = 0;
						goto IL_009c;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							ZgNBieIVqISnYBuMdPcAmUHsCuh++;
							goto IL_009c;
						}
						IL_009c:
						if (ZgNBieIVqISnYBuMdPcAmUHsCuh < NDWsdzoSBpLesfjOQXDuYgTagwy)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons[ZgNBieIVqISnYBuMdPcAmUHsCuh];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public fwvBYmGXthRGfgInCGNZfkuAhMd(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform => InputPlatform.AbkfUMwvaoaiMbXSNFohhLPkNN;

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
						array[i] = identifiers[num3].name;
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
						array[i] = identifiers[num2].name;
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
						ref AxisCalibrationData reference = ref array[i];
						reference = AxisCalibrationData.Default;
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
						ref AxisCalibrationData reference2 = ref array[i];
						reference2 = AxisCalibrationData.Default;
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
				vVscNJJeSAZHNcdzPyVOdmhZzBCA vVscNJJeSAZHNcdzPyVOdmhZzBCA2 = new vVscNJJeSAZHNcdzPyVOdmhZzBCA(-2);
				vVscNJJeSAZHNcdzPyVOdmhZzBCA2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return vVscNJJeSAZHNcdzPyVOdmhZzBCA2;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				fwvBYmGXthRGfgInCGNZfkuAhMd fwvBYmGXthRGfgInCGNZfkuAhMd2 = new fwvBYmGXthRGfgInCGNZfkuAhMd(-2);
				fwvBYmGXthRGfgInCGNZfkuAhMd2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return fwvBYmGXthRGfgInCGNZfkuAhMd2;
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

			internal override IList<Platform> variants_base => variants;

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

			private sealed class EEFgZXRHLrjoInqjniOccVCHcGjK : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_Fallback_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int fCXIqJGfkdByiijfrOsWrbSQHWcn;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					EEFgZXRHLrjoInqjniOccVCHcGjK eEFgZXRHLrjoInqjniOccVCHcGjK;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						eEFgZXRHLrjoInqjniOccVCHcGjK = this;
					}
					else
					{
						eEFgZXRHLrjoInqjniOccVCHcGjK = new EEFgZXRHLrjoInqjniOccVCHcGjK(0);
						eEFgZXRHLrjoInqjniOccVCHcGjK.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return eEFgZXRHLrjoInqjniOccVCHcGjK;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes == null)
						{
							break;
						}
						fCXIqJGfkdByiijfrOsWrbSQHWcn = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							fCXIqJGfkdByiijfrOsWrbSQHWcn++;
							goto IL_0084;
						}
						IL_0084:
						if (fCXIqJGfkdByiijfrOsWrbSQHWcn < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes[fCXIqJGfkdByiijfrOsWrbSQHWcn];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public EEFgZXRHLrjoInqjniOccVCHcGjK(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class HTHqyenrzYpkCFfewugAjghFHcSJ : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>, IEnumerable
			{
				private Button ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_Fallback_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int fKhKhaFlMTasXOeHyfZDwXlAyrl;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					HTHqyenrzYpkCFfewugAjghFHcSJ hTHqyenrzYpkCFfewugAjghFHcSJ;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						hTHqyenrzYpkCFfewugAjghFHcSJ = this;
					}
					else
					{
						hTHqyenrzYpkCFfewugAjghFHcSJ = new HTHqyenrzYpkCFfewugAjghFHcSJ(0);
						hTHqyenrzYpkCFfewugAjghFHcSJ.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return hTHqyenrzYpkCFfewugAjghFHcSJ;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons == null)
						{
							break;
						}
						fKhKhaFlMTasXOeHyfZDwXlAyrl = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							fKhKhaFlMTasXOeHyfZDwXlAyrl++;
							goto IL_0084;
						}
						IL_0084:
						if (fKhKhaFlMTasXOeHyfZDwXlAyrl < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons[fKhKhaFlMTasXOeHyfZDwXlAyrl];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public HTHqyenrzYpkCFfewugAjghFHcSJ(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.UWCdqzyTIJIwgNgaWEfbEXrlPLun;

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
				EEFgZXRHLrjoInqjniOccVCHcGjK eEFgZXRHLrjoInqjniOccVCHcGjK = new EEFgZXRHLrjoInqjniOccVCHcGjK(-2);
				eEFgZXRHLrjoInqjniOccVCHcGjK.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return eEFgZXRHLrjoInqjniOccVCHcGjK;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				HTHqyenrzYpkCFfewugAjghFHcSJ hTHqyenrzYpkCFfewugAjghFHcSJ = new HTHqyenrzYpkCFfewugAjghFHcSJ(-2);
				hTHqyenrzYpkCFfewugAjghFHcSJ.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return hTHqyenrzYpkCFfewugAjghFHcSJ;
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
						array[i] = identifiers[num].name;
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
						array[i] = identifiers[num].name;
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
						ref AxisCalibrationData reference = ref array[i];
						reference = AxisCalibrationData.Default;
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
						ref AxisCalibrationData reference2 = ref array[i];
						reference2 = AxisCalibrationData.Default;
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

			internal override IList<Platform> variants_base => variants;

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
					if (alwaysMatch)
					{
						return true;
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

			private sealed class yiHjJMOnDGaPvIbuDmMpZZJtLaH : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_Ouya_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int BxBujMtbDcTBxbRQVMunNbwOthv;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					yiHjJMOnDGaPvIbuDmMpZZJtLaH yiHjJMOnDGaPvIbuDmMpZZJtLaH2;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						yiHjJMOnDGaPvIbuDmMpZZJtLaH2 = this;
					}
					else
					{
						yiHjJMOnDGaPvIbuDmMpZZJtLaH2 = new yiHjJMOnDGaPvIbuDmMpZZJtLaH(0);
						yiHjJMOnDGaPvIbuDmMpZZJtLaH2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return yiHjJMOnDGaPvIbuDmMpZZJtLaH2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes == null)
						{
							break;
						}
						BxBujMtbDcTBxbRQVMunNbwOthv = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							BxBujMtbDcTBxbRQVMunNbwOthv++;
							goto IL_0084;
						}
						IL_0084:
						if (BxBujMtbDcTBxbRQVMunNbwOthv < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes[BxBujMtbDcTBxbRQVMunNbwOthv];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public yiHjJMOnDGaPvIbuDmMpZZJtLaH(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class XVSbVNgblwFLurKPMzcJgKGyDVwO : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_Ouya_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int emszvuHNKVCFucyzIzSnkAHSUrWf;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					XVSbVNgblwFLurKPMzcJgKGyDVwO xVSbVNgblwFLurKPMzcJgKGyDVwO;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						xVSbVNgblwFLurKPMzcJgKGyDVwO = this;
					}
					else
					{
						xVSbVNgblwFLurKPMzcJgKGyDVwO = new XVSbVNgblwFLurKPMzcJgKGyDVwO(0);
						xVSbVNgblwFLurKPMzcJgKGyDVwO.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return xVSbVNgblwFLurKPMzcJgKGyDVwO;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons == null)
						{
							break;
						}
						emszvuHNKVCFucyzIzSnkAHSUrWf = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							emszvuHNKVCFucyzIzSnkAHSUrWf++;
							goto IL_0084;
						}
						IL_0084:
						if (emszvuHNKVCFucyzIzSnkAHSUrWf < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons[emszvuHNKVCFucyzIzSnkAHSUrWf];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public XVSbVNgblwFLurKPMzcJgKGyDVwO(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.VVFNMnuwjQktQBuzllCpFfiGHnU;

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
				yiHjJMOnDGaPvIbuDmMpZZJtLaH yiHjJMOnDGaPvIbuDmMpZZJtLaH2 = new yiHjJMOnDGaPvIbuDmMpZZJtLaH(-2);
				yiHjJMOnDGaPvIbuDmMpZZJtLaH2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return yiHjJMOnDGaPvIbuDmMpZZJtLaH2;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				XVSbVNgblwFLurKPMzcJgKGyDVwO xVSbVNgblwFLurKPMzcJgKGyDVwO = new XVSbVNgblwFLurKPMzcJgKGyDVwO(-2);
				xVSbVNgblwFLurKPMzcJgKGyDVwO.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return xVSbVNgblwFLurKPMzcJgKGyDVwO;
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
						array[i] = identifiers[num].name;
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
						array[i] = identifiers[num].name;
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
						ref AxisCalibrationData reference = ref array[i];
						reference = AxisCalibrationData.Default;
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
						ref AxisCalibrationData reference2 = ref array[i];
						reference2 = AxisCalibrationData.Default;
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
				Platform_Ouya_Base platform_Ouya_Base = new Platform_Ouya_Base();
				CopyVars(platform_Ouya_Base);
				return platform_Ouya_Base;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_Ouya_Base platform_Ouya_Base)
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

			internal override IList<Platform> variants_base => variants;

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
				Platform_Ouya platform_Ouya = new Platform_Ouya();
				CopyVars(platform_Ouya);
				return platform_Ouya;
			}

			internal override void CopyVars(Platform destination)
			{
				base.CopyVars(destination);
				if (destination is Platform_Ouya platform_Ouya)
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

			private sealed class NJqjpqasRaJbrBGvoEmufVmOORCC : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_XboxOne_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int VUWwWLeoVOpbkGkhiDuXRKMzHJh;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					NJqjpqasRaJbrBGvoEmufVmOORCC nJqjpqasRaJbrBGvoEmufVmOORCC;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						nJqjpqasRaJbrBGvoEmufVmOORCC = this;
					}
					else
					{
						nJqjpqasRaJbrBGvoEmufVmOORCC = new NJqjpqasRaJbrBGvoEmufVmOORCC(0);
						nJqjpqasRaJbrBGvoEmufVmOORCC.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return nJqjpqasRaJbrBGvoEmufVmOORCC;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes == null)
						{
							break;
						}
						VUWwWLeoVOpbkGkhiDuXRKMzHJh = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							VUWwWLeoVOpbkGkhiDuXRKMzHJh++;
							goto IL_0084;
						}
						IL_0084:
						if (VUWwWLeoVOpbkGkhiDuXRKMzHJh < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes[VUWwWLeoVOpbkGkhiDuXRKMzHJh];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public NJqjpqasRaJbrBGvoEmufVmOORCC(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class FzrrOGCBZwaFgJHUuTOBqUXdqJc : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_XboxOne_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int ieIpKkDPebKaeqkHRGFnkEqhzxwJ;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					FzrrOGCBZwaFgJHUuTOBqUXdqJc fzrrOGCBZwaFgJHUuTOBqUXdqJc;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						fzrrOGCBZwaFgJHUuTOBqUXdqJc = this;
					}
					else
					{
						fzrrOGCBZwaFgJHUuTOBqUXdqJc = new FzrrOGCBZwaFgJHUuTOBqUXdqJc(0);
						fzrrOGCBZwaFgJHUuTOBqUXdqJc.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return fzrrOGCBZwaFgJHUuTOBqUXdqJc;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons == null)
						{
							break;
						}
						ieIpKkDPebKaeqkHRGFnkEqhzxwJ = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							ieIpKkDPebKaeqkHRGFnkEqhzxwJ++;
							goto IL_0084;
						}
						IL_0084:
						if (ieIpKkDPebKaeqkHRGFnkEqhzxwJ < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons[ieIpKkDPebKaeqkHRGFnkEqhzxwJ];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public FzrrOGCBZwaFgJHUuTOBqUXdqJc(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.MKsYfylcxroUpkqMsmDQAiXKRGk;

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
				NJqjpqasRaJbrBGvoEmufVmOORCC nJqjpqasRaJbrBGvoEmufVmOORCC = new NJqjpqasRaJbrBGvoEmufVmOORCC(-2);
				nJqjpqasRaJbrBGvoEmufVmOORCC.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return nJqjpqasRaJbrBGvoEmufVmOORCC;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				FzrrOGCBZwaFgJHUuTOBqUXdqJc fzrrOGCBZwaFgJHUuTOBqUXdqJc = new FzrrOGCBZwaFgJHUuTOBqUXdqJc(-2);
				fzrrOGCBZwaFgJHUuTOBqUXdqJc.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return fzrrOGCBZwaFgJHUuTOBqUXdqJc;
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
						array[i] = identifiers[num].name;
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
						array[i] = identifiers[num].name;
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
						ref AxisCalibrationData reference = ref array[i];
						reference = AxisCalibrationData.Default;
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
						ref AxisCalibrationData reference2 = ref array[i];
						reference2 = AxisCalibrationData.Default;
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

			internal override IList<Platform> variants_base => variants;

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

			private sealed class NrPkjtcUJgoWxDeVYsJWiKmZJaB : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_PS4_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int oRTOXpGHSmYRgbgZuVRqxQLQMHm;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					NrPkjtcUJgoWxDeVYsJWiKmZJaB nrPkjtcUJgoWxDeVYsJWiKmZJaB;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						nrPkjtcUJgoWxDeVYsJWiKmZJaB = this;
					}
					else
					{
						nrPkjtcUJgoWxDeVYsJWiKmZJaB = new NrPkjtcUJgoWxDeVYsJWiKmZJaB(0);
						nrPkjtcUJgoWxDeVYsJWiKmZJaB.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return nrPkjtcUJgoWxDeVYsJWiKmZJaB;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes == null)
						{
							break;
						}
						oRTOXpGHSmYRgbgZuVRqxQLQMHm = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							oRTOXpGHSmYRgbgZuVRqxQLQMHm++;
							goto IL_0084;
						}
						IL_0084:
						if (oRTOXpGHSmYRgbgZuVRqxQLQMHm < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes[oRTOXpGHSmYRgbgZuVRqxQLQMHm];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public NrPkjtcUJgoWxDeVYsJWiKmZJaB(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class RWRVFnpNvueTElrSaXrmvBXZWOp : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_PS4_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int WBzBrdgsEZOoBghKUBKxjgMFmrLa;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					RWRVFnpNvueTElrSaXrmvBXZWOp rWRVFnpNvueTElrSaXrmvBXZWOp;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						rWRVFnpNvueTElrSaXrmvBXZWOp = this;
					}
					else
					{
						rWRVFnpNvueTElrSaXrmvBXZWOp = new RWRVFnpNvueTElrSaXrmvBXZWOp(0);
						rWRVFnpNvueTElrSaXrmvBXZWOp.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return rWRVFnpNvueTElrSaXrmvBXZWOp;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons == null)
						{
							break;
						}
						WBzBrdgsEZOoBghKUBKxjgMFmrLa = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							WBzBrdgsEZOoBghKUBKxjgMFmrLa++;
							goto IL_0084;
						}
						IL_0084:
						if (WBzBrdgsEZOoBghKUBKxjgMFmrLa < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons[WBzBrdgsEZOoBghKUBKxjgMFmrLa];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public RWRVFnpNvueTElrSaXrmvBXZWOp(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.ZSmWcBJLZPZDkzrSGqQUcIqQUvG;

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
				NrPkjtcUJgoWxDeVYsJWiKmZJaB nrPkjtcUJgoWxDeVYsJWiKmZJaB = new NrPkjtcUJgoWxDeVYsJWiKmZJaB(-2);
				nrPkjtcUJgoWxDeVYsJWiKmZJaB.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return nrPkjtcUJgoWxDeVYsJWiKmZJaB;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				RWRVFnpNvueTElrSaXrmvBXZWOp rWRVFnpNvueTElrSaXrmvBXZWOp = new RWRVFnpNvueTElrSaXrmvBXZWOp(-2);
				rWRVFnpNvueTElrSaXrmvBXZWOp.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return rWRVFnpNvueTElrSaXrmvBXZWOp;
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
						array[i] = identifiers[num].name;
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
						array[i] = identifiers[num].name;
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
						ref AxisCalibrationData reference = ref array[i];
						reference = AxisCalibrationData.Default;
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
						ref AxisCalibrationData reference2 = ref array[i];
						reference2 = AxisCalibrationData.Default;
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

			internal override IList<Platform> variants_base => variants;

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

			private sealed class NEvHLFuNxNApovkzZYYzLalEwEx : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_NintendoSwitch_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int MwyvNMDMhGANRTIPUaKDAIVaFPRC;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					NEvHLFuNxNApovkzZYYzLalEwEx nEvHLFuNxNApovkzZYYzLalEwEx;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						nEvHLFuNxNApovkzZYYzLalEwEx = this;
					}
					else
					{
						nEvHLFuNxNApovkzZYYzLalEwEx = new NEvHLFuNxNApovkzZYYzLalEwEx(0);
						nEvHLFuNxNApovkzZYYzLalEwEx.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return nEvHLFuNxNApovkzZYYzLalEwEx;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes == null)
						{
							break;
						}
						MwyvNMDMhGANRTIPUaKDAIVaFPRC = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							MwyvNMDMhGANRTIPUaKDAIVaFPRC++;
							goto IL_0084;
						}
						IL_0084:
						if (MwyvNMDMhGANRTIPUaKDAIVaFPRC < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes[MwyvNMDMhGANRTIPUaKDAIVaFPRC];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public NEvHLFuNxNApovkzZYYzLalEwEx(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class bVHXsJMvyyBhoWBWEbFKFFYQahjM : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_NintendoSwitch_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int keeYpMzGiigJOfmUDFPOgrUrWee;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					bVHXsJMvyyBhoWBWEbFKFFYQahjM bVHXsJMvyyBhoWBWEbFKFFYQahjM2;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						bVHXsJMvyyBhoWBWEbFKFFYQahjM2 = this;
					}
					else
					{
						bVHXsJMvyyBhoWBWEbFKFFYQahjM2 = new bVHXsJMvyyBhoWBWEbFKFFYQahjM(0);
						bVHXsJMvyyBhoWBWEbFKFFYQahjM2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return bVHXsJMvyyBhoWBWEbFKFFYQahjM2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons == null)
						{
							break;
						}
						keeYpMzGiigJOfmUDFPOgrUrWee = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							keeYpMzGiigJOfmUDFPOgrUrWee++;
							goto IL_0084;
						}
						IL_0084:
						if (keeYpMzGiigJOfmUDFPOgrUrWee < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons[keeYpMzGiigJOfmUDFPOgrUrWee];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public bVHXsJMvyyBhoWBWEbFKFFYQahjM(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.KmXpwJBmIkvUmMjyMwPhIQVKxxP;

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
				NEvHLFuNxNApovkzZYYzLalEwEx nEvHLFuNxNApovkzZYYzLalEwEx = new NEvHLFuNxNApovkzZYYzLalEwEx(-2);
				nEvHLFuNxNApovkzZYYzLalEwEx.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return nEvHLFuNxNApovkzZYYzLalEwEx;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				bVHXsJMvyyBhoWBWEbFKFFYQahjM bVHXsJMvyyBhoWBWEbFKFFYQahjM2 = new bVHXsJMvyyBhoWBWEbFKFFYQahjM(-2);
				bVHXsJMvyyBhoWBWEbFKFFYQahjM2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return bVHXsJMvyyBhoWBWEbFKFFYQahjM2;
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
						array[i] = identifiers[num].name;
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
						array[i] = identifiers[num].name;
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
						ref AxisCalibrationData reference = ref array[i];
						reference = AxisCalibrationData.Default;
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
						ref AxisCalibrationData reference2 = ref array[i];
						reference2 = AxisCalibrationData.Default;
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

			internal override IList<Platform> variants_base => variants;

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

			private sealed class tVjhPXHsnEDbcGeZQyZHvVTIbQb : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_Stadia_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int zXRFbcBJVelUmUovubByYArAdwmC;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					tVjhPXHsnEDbcGeZQyZHvVTIbQb tVjhPXHsnEDbcGeZQyZHvVTIbQb2;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						tVjhPXHsnEDbcGeZQyZHvVTIbQb2 = this;
					}
					else
					{
						tVjhPXHsnEDbcGeZQyZHvVTIbQb2 = new tVjhPXHsnEDbcGeZQyZHvVTIbQb(0);
						tVjhPXHsnEDbcGeZQyZHvVTIbQb2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return tVjhPXHsnEDbcGeZQyZHvVTIbQb2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes == null)
						{
							break;
						}
						zXRFbcBJVelUmUovubByYArAdwmC = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							zXRFbcBJVelUmUovubByYArAdwmC++;
							goto IL_0084;
						}
						IL_0084:
						if (zXRFbcBJVelUmUovubByYArAdwmC < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes[zXRFbcBJVelUmUovubByYArAdwmC];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public tVjhPXHsnEDbcGeZQyZHvVTIbQb(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class XszXjjxjSKqSFHixvVxnSTMURNo : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_Stadia_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int MLgMDUyeGYDEOcxMPSztjAqZPLI;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					XszXjjxjSKqSFHixvVxnSTMURNo xszXjjxjSKqSFHixvVxnSTMURNo;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						xszXjjxjSKqSFHixvVxnSTMURNo = this;
					}
					else
					{
						xszXjjxjSKqSFHixvVxnSTMURNo = new XszXjjxjSKqSFHixvVxnSTMURNo(0);
						xszXjjxjSKqSFHixvVxnSTMURNo.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return xszXjjxjSKqSFHixvVxnSTMURNo;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons == null)
						{
							break;
						}
						MLgMDUyeGYDEOcxMPSztjAqZPLI = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							MLgMDUyeGYDEOcxMPSztjAqZPLI++;
							goto IL_0084;
						}
						IL_0084:
						if (MLgMDUyeGYDEOcxMPSztjAqZPLI < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons[MLgMDUyeGYDEOcxMPSztjAqZPLI];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public XszXjjxjSKqSFHixvVxnSTMURNo(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.rjPPkipWWuRRnodJLIuVKeUPVmE;

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
				tVjhPXHsnEDbcGeZQyZHvVTIbQb tVjhPXHsnEDbcGeZQyZHvVTIbQb2 = new tVjhPXHsnEDbcGeZQyZHvVTIbQb(-2);
				tVjhPXHsnEDbcGeZQyZHvVTIbQb2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return tVjhPXHsnEDbcGeZQyZHvVTIbQb2;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				XszXjjxjSKqSFHixvVxnSTMURNo xszXjjxjSKqSFHixvVxnSTMURNo = new XszXjjxjSKqSFHixvVxnSTMURNo(-2);
				xszXjjxjSKqSFHixvVxnSTMURNo.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return xszXjjxjSKqSFHixvVxnSTMURNo;
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
						array[i] = identifiers[num].name;
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
						array[i] = identifiers[num].name;
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
						ref AxisCalibrationData reference = ref array[i];
						reference = AxisCalibrationData.Default;
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
						ref AxisCalibrationData reference2 = ref array[i];
						reference2 = AxisCalibrationData.Default;
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

			internal override IList<Platform> variants_base => variants;

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

			private sealed class XdWCvQAXXEWoyGhNQtrZscwYJdR : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_GameCore_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int WmyoNkQnVzdixkoyyYhYKcxzutIj;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					XdWCvQAXXEWoyGhNQtrZscwYJdR xdWCvQAXXEWoyGhNQtrZscwYJdR;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						xdWCvQAXXEWoyGhNQtrZscwYJdR = this;
					}
					else
					{
						xdWCvQAXXEWoyGhNQtrZscwYJdR = new XdWCvQAXXEWoyGhNQtrZscwYJdR(0);
						xdWCvQAXXEWoyGhNQtrZscwYJdR.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return xdWCvQAXXEWoyGhNQtrZscwYJdR;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes == null)
						{
							break;
						}
						WmyoNkQnVzdixkoyyYhYKcxzutIj = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							WmyoNkQnVzdixkoyyYhYKcxzutIj++;
							goto IL_0084;
						}
						IL_0084:
						if (WmyoNkQnVzdixkoyyYhYKcxzutIj < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes[WmyoNkQnVzdixkoyyYhYKcxzutIj];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public XdWCvQAXXEWoyGhNQtrZscwYJdR(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class kUbnUoOVJULMfVnabICUDSjmPAy : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_GameCore_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int MYEFWsrtKLFDzDwjsbzhRIpCpNZn;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					kUbnUoOVJULMfVnabICUDSjmPAy kUbnUoOVJULMfVnabICUDSjmPAy2;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						kUbnUoOVJULMfVnabICUDSjmPAy2 = this;
					}
					else
					{
						kUbnUoOVJULMfVnabICUDSjmPAy2 = new kUbnUoOVJULMfVnabICUDSjmPAy(0);
						kUbnUoOVJULMfVnabICUDSjmPAy2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return kUbnUoOVJULMfVnabICUDSjmPAy2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons == null)
						{
							break;
						}
						MYEFWsrtKLFDzDwjsbzhRIpCpNZn = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							MYEFWsrtKLFDzDwjsbzhRIpCpNZn++;
							goto IL_0084;
						}
						IL_0084:
						if (MYEFWsrtKLFDzDwjsbzhRIpCpNZn < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons[MYEFWsrtKLFDzDwjsbzhRIpCpNZn];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public kUbnUoOVJULMfVnabICUDSjmPAy(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.GVKDbJYxOtlxBEEweJFxfiMGZit;

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
				XdWCvQAXXEWoyGhNQtrZscwYJdR xdWCvQAXXEWoyGhNQtrZscwYJdR = new XdWCvQAXXEWoyGhNQtrZscwYJdR(-2);
				xdWCvQAXXEWoyGhNQtrZscwYJdR.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return xdWCvQAXXEWoyGhNQtrZscwYJdR;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				kUbnUoOVJULMfVnabICUDSjmPAy kUbnUoOVJULMfVnabICUDSjmPAy2 = new kUbnUoOVJULMfVnabICUDSjmPAy(-2);
				kUbnUoOVJULMfVnabICUDSjmPAy2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return kUbnUoOVJULMfVnabICUDSjmPAy2;
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
						array[i] = identifiers[num].name;
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
						array[i] = identifiers[num].name;
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
						ref AxisCalibrationData reference = ref array[i];
						reference = AxisCalibrationData.Default;
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
						ref AxisCalibrationData reference2 = ref array[i];
						reference2 = AxisCalibrationData.Default;
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

			internal override IList<Platform> variants_base => variants;

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
				int num3 = 2;
				int num4 = num3 * 8;
				elements.buttons = new Button[num2 + num4];
				for (int j = 0; j < num2; j++)
				{
					Button button = new Button();
					elements.buttons[j] = button;
					button.buttonInfo = new HardwareButtonInfo(excludeFromPolling: false, isPressureSensitive: false);
					button.elementIdentifier = 32 + j;
					button.sourceButton = j;
					button.sourceType = 0;
				}
				int num5 = num2;
				int num6 = 160;
				int num7 = 224;
				for (int k = 0; k < 2; k++)
				{
					for (int l = 0; l < 8; l++)
					{
						bool flag = l % 2 == 0;
						Button button2 = new Button();
						elements.buttons[num5++] = button2;
						button2.buttonInfo = new HardwareButtonInfo(excludeFromPolling: false, isPressureSensitive: false);
						button2.elementIdentifier = (flag ? num6++ : num7++);
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

			private sealed class SufoVqVXtbiIfqbrvqVxxlvNFhk : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_PS5_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int XlyAbFXcZKzTcJcJhCUOeIAzgAp;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					SufoVqVXtbiIfqbrvqVxxlvNFhk sufoVqVXtbiIfqbrvqVxxlvNFhk;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						sufoVqVXtbiIfqbrvqVxxlvNFhk = this;
					}
					else
					{
						sufoVqVXtbiIfqbrvqVxxlvNFhk = new SufoVqVXtbiIfqbrvqVxxlvNFhk(0);
						sufoVqVXtbiIfqbrvqVxxlvNFhk.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return sufoVqVXtbiIfqbrvqVxxlvNFhk;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes == null)
						{
							break;
						}
						XlyAbFXcZKzTcJcJhCUOeIAzgAp = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							XlyAbFXcZKzTcJcJhCUOeIAzgAp++;
							goto IL_0084;
						}
						IL_0084:
						if (XlyAbFXcZKzTcJcJhCUOeIAzgAp < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes[XlyAbFXcZKzTcJcJhCUOeIAzgAp];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public SufoVqVXtbiIfqbrvqVxxlvNFhk(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class MrKDHJotXQzHZzizGFiJbZoXGEk : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_PS5_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int TQVpnbpRJVENiGsnXMgDXSkAAeH;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					MrKDHJotXQzHZzizGFiJbZoXGEk mrKDHJotXQzHZzizGFiJbZoXGEk;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						mrKDHJotXQzHZzizGFiJbZoXGEk = this;
					}
					else
					{
						mrKDHJotXQzHZzizGFiJbZoXGEk = new MrKDHJotXQzHZzizGFiJbZoXGEk(0);
						mrKDHJotXQzHZzizGFiJbZoXGEk.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return mrKDHJotXQzHZzizGFiJbZoXGEk;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons == null)
						{
							break;
						}
						TQVpnbpRJVENiGsnXMgDXSkAAeH = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							TQVpnbpRJVENiGsnXMgDXSkAAeH++;
							goto IL_0084;
						}
						IL_0084:
						if (TQVpnbpRJVENiGsnXMgDXSkAAeH < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons[TQVpnbpRJVENiGsnXMgDXSkAAeH];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public MrKDHJotXQzHZzizGFiJbZoXGEk(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.qCrCYaIeXKGNOmBWGyRNKAkvERYH;

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
				SufoVqVXtbiIfqbrvqVxxlvNFhk sufoVqVXtbiIfqbrvqVxxlvNFhk = new SufoVqVXtbiIfqbrvqVxxlvNFhk(-2);
				sufoVqVXtbiIfqbrvqVxxlvNFhk.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return sufoVqVXtbiIfqbrvqVxxlvNFhk;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				MrKDHJotXQzHZzizGFiJbZoXGEk mrKDHJotXQzHZzizGFiJbZoXGEk = new MrKDHJotXQzHZzizGFiJbZoXGEk(-2);
				mrKDHJotXQzHZzizGFiJbZoXGEk.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return mrKDHJotXQzHZzizGFiJbZoXGEk;
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
						array[i] = identifiers[num].name;
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
						array[i] = identifiers[num].name;
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
						ref AxisCalibrationData reference = ref array[i];
						reference = AxisCalibrationData.Default;
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
						ref AxisCalibrationData reference2 = ref array[i];
						reference2 = AxisCalibrationData.Default;
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

			internal override IList<Platform> variants_base => variants;

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
						if (productName != null && productName.Length > 0)
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

			private sealed class EgimqPOEusBKizYIGofFIKacQlo : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_InternalDriver_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int SqbsUAUsrKIBQQgAzPfVIgtjMBb;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					EgimqPOEusBKizYIGofFIKacQlo egimqPOEusBKizYIGofFIKacQlo;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						egimqPOEusBKizYIGofFIKacQlo = this;
					}
					else
					{
						egimqPOEusBKizYIGofFIKacQlo = new EgimqPOEusBKizYIGofFIKacQlo(0);
						egimqPOEusBKizYIGofFIKacQlo.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return egimqPOEusBKizYIGofFIKacQlo;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes == null)
						{
							break;
						}
						SqbsUAUsrKIBQQgAzPfVIgtjMBb = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							SqbsUAUsrKIBQQgAzPfVIgtjMBb++;
							goto IL_0084;
						}
						IL_0084:
						if (SqbsUAUsrKIBQQgAzPfVIgtjMBb < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes[SqbsUAUsrKIBQQgAzPfVIgtjMBb];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public EgimqPOEusBKizYIGofFIKacQlo(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class RVnLnzzmqIBhqILLINNEfwmSzcq : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_InternalDriver_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int izzoHbHfniDUTNwYILTtUBIdEjiK;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					RVnLnzzmqIBhqILLINNEfwmSzcq rVnLnzzmqIBhqILLINNEfwmSzcq;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						rVnLnzzmqIBhqILLINNEfwmSzcq = this;
					}
					else
					{
						rVnLnzzmqIBhqILLINNEfwmSzcq = new RVnLnzzmqIBhqILLINNEfwmSzcq(0);
						rVnLnzzmqIBhqILLINNEfwmSzcq.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return rVnLnzzmqIBhqILLINNEfwmSzcq;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons == null)
						{
							break;
						}
						izzoHbHfniDUTNwYILTtUBIdEjiK = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							izzoHbHfniDUTNwYILTtUBIdEjiK++;
							goto IL_0084;
						}
						IL_0084:
						if (izzoHbHfniDUTNwYILTtUBIdEjiK < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons[izzoHbHfniDUTNwYILTtUBIdEjiK];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public RVnLnzzmqIBhqILLINNEfwmSzcq(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.FhqZiqCHhXxQXjCHQDlDqwTlgOd;

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
				EgimqPOEusBKizYIGofFIKacQlo egimqPOEusBKizYIGofFIKacQlo = new EgimqPOEusBKizYIGofFIKacQlo(-2);
				egimqPOEusBKizYIGofFIKacQlo.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return egimqPOEusBKizYIGofFIKacQlo;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				RVnLnzzmqIBhqILLINNEfwmSzcq rVnLnzzmqIBhqILLINNEfwmSzcq = new RVnLnzzmqIBhqILLINNEfwmSzcq(-2);
				rVnLnzzmqIBhqILLINNEfwmSzcq.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return rVnLnzzmqIBhqILLINNEfwmSzcq;
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
						array[i] = identifiers[num].name;
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
						array[i] = identifiers[num].name;
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
						ref AxisCalibrationData reference = ref array[i];
						reference = AxisCalibrationData.Default;
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
						ref AxisCalibrationData reference2 = ref array[i];
						reference2 = AxisCalibrationData.Default;
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

			internal override IList<Platform> variants_base => variants;

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
						zbOgMCfNPBCiGEaoQdlRAPiXvTpO(elementCount);
						return elementCount;
					}

					internal override void zbOgMCfNPBCiGEaoQdlRAPiXvTpO(ElementCount_Base P_0)
					{
						base.zbOgMCfNPBCiGEaoQdlRAPiXvTpO(P_0);
						if (P_0 is ElementCount elementCount)
						{
							elementCount.hatCount = hatCount;
						}
					}

					internal override bool QuyjPPVLYssrxnLbKpFVOFYkPay(BridgedControllerHWInfo P_0)
					{
						if (!base.QuyjPPVLYssrxnLbKpFVOFYkPay(P_0))
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
				private sealed class hfPKpGIvMagSxuDHVKmjPYrrMXO : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
				{
					private Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public Elements kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int CBDaFuGMxfSNoseXKrBLsxUCnBt;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						hfPKpGIvMagSxuDHVKmjPYrrMXO hfPKpGIvMagSxuDHVKmjPYrrMXO2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							hfPKpGIvMagSxuDHVKmjPYrrMXO2 = this;
						}
						else
						{
							hfPKpGIvMagSxuDHVKmjPYrrMXO2 = new hfPKpGIvMagSxuDHVKmjPYrrMXO(0);
							hfPKpGIvMagSxuDHVKmjPYrrMXO2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return hfPKpGIvMagSxuDHVKmjPYrrMXO2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Axis>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 0:
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							if (kdBZqupjvsCsVkwJiOeEQzkEDVO.axes == null)
							{
								break;
							}
							CBDaFuGMxfSNoseXKrBLsxUCnBt = 0;
							goto IL_006a;
						case 1:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								CBDaFuGMxfSNoseXKrBLsxUCnBt++;
								goto IL_006a;
							}
							IL_006a:
							if (CBDaFuGMxfSNoseXKrBLsxUCnBt < kdBZqupjvsCsVkwJiOeEQzkEDVO.axes.Length)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.axes[CBDaFuGMxfSNoseXKrBLsxUCnBt];
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public hfPKpGIvMagSxuDHVKmjPYrrMXO(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class WYwxDXoHlhgbAUnFylFsFXvDmvJ : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerable, IEnumerator<Button>
				{
					private Button ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public Elements kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public int WoEfuiPPfqvMbOKUPsdrbayKaLD;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						WYwxDXoHlhgbAUnFylFsFXvDmvJ wYwxDXoHlhgbAUnFylFsFXvDmvJ;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							wYwxDXoHlhgbAUnFylFsFXvDmvJ = this;
						}
						else
						{
							wYwxDXoHlhgbAUnFylFsFXvDmvJ = new WYwxDXoHlhgbAUnFylFsFXvDmvJ(0);
							wYwxDXoHlhgbAUnFylFsFXvDmvJ.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return wYwxDXoHlhgbAUnFylFsFXvDmvJ;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<Button>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 0:
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							if (kdBZqupjvsCsVkwJiOeEQzkEDVO.buttons == null)
							{
								break;
							}
							WoEfuiPPfqvMbOKUPsdrbayKaLD = 0;
							goto IL_006a;
						case 1:
							{
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								WoEfuiPPfqvMbOKUPsdrbayKaLD++;
								goto IL_006a;
							}
							IL_006a:
							if (WoEfuiPPfqvMbOKUPsdrbayKaLD < kdBZqupjvsCsVkwJiOeEQzkEDVO.buttons.Length)
							{
								ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.buttons[WoEfuiPPfqvMbOKUPsdrbayKaLD];
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

					void IDisposable.Dispose()
					{
					}

					[DebuggerHidden]
					public WYwxDXoHlhgbAUnFylFsFXvDmvJ(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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
						hfPKpGIvMagSxuDHVKmjPYrrMXO hfPKpGIvMagSxuDHVKmjPYrrMXO2 = new hfPKpGIvMagSxuDHVKmjPYrrMXO(-2);
						hfPKpGIvMagSxuDHVKmjPYrrMXO2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
						return hfPKpGIvMagSxuDHVKmjPYrrMXO2;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					get
					{
						WYwxDXoHlhgbAUnFylFsFXvDmvJ wYwxDXoHlhgbAUnFylFsFXvDmvJ = new WYwxDXoHlhgbAUnFylFsFXvDmvJ(-2);
						wYwxDXoHlhgbAUnFylFsFXvDmvJ.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
						return wYwxDXoHlhgbAUnFylFsFXvDmvJ;
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

			private sealed class PAydUNdTAnhLZVbwZsqhPJCifhRx : IDisposable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>, IEnumerable
			{
				private Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_SDL2_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int bOYehkHXwvubHENgDDhfamzDJGta;

				public int SZuHIRJMHgwbjtpbtyTiLnJWHdA;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					PAydUNdTAnhLZVbwZsqhPJCifhRx pAydUNdTAnhLZVbwZsqhPJCifhRx;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						pAydUNdTAnhLZVbwZsqhPJCifhRx = this;
					}
					else
					{
						pAydUNdTAnhLZVbwZsqhPJCifhRx = new PAydUNdTAnhLZVbwZsqhPJCifhRx(0);
						pAydUNdTAnhLZVbwZsqhPJCifhRx.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return pAydUNdTAnhLZVbwZsqhPJCifhRx;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes == null)
						{
							break;
						}
						bOYehkHXwvubHENgDDhfamzDJGta = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes.Length;
						SZuHIRJMHgwbjtpbtyTiLnJWHdA = 0;
						goto IL_009c;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							SZuHIRJMHgwbjtpbtyTiLnJWHdA++;
							goto IL_009c;
						}
						IL_009c:
						if (SZuHIRJMHgwbjtpbtyTiLnJWHdA < bOYehkHXwvubHENgDDhfamzDJGta)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes[SZuHIRJMHgwbjtpbtyTiLnJWHdA];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public PAydUNdTAnhLZVbwZsqhPJCifhRx(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class ZtSElhWHfhEAhHQBHneOjqTDGOOl : IDisposable, IEnumerator, IEnumerable<Button>, IEnumerable, IEnumerator<Button>
			{
				private Button ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_SDL2_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int SRANgxUVpfgxWDWAXzYaQBCSnqC;

				public int rvQSwtcsjtBBKBdjGxYAfovcNoJ;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					ZtSElhWHfhEAhHQBHneOjqTDGOOl ztSElhWHfhEAhHQBHneOjqTDGOOl;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						ztSElhWHfhEAhHQBHneOjqTDGOOl = this;
					}
					else
					{
						ztSElhWHfhEAhHQBHneOjqTDGOOl = new ZtSElhWHfhEAhHQBHneOjqTDGOOl(0);
						ztSElhWHfhEAhHQBHneOjqTDGOOl.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return ztSElhWHfhEAhHQBHneOjqTDGOOl;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons == null)
						{
							break;
						}
						SRANgxUVpfgxWDWAXzYaQBCSnqC = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons.Length;
						rvQSwtcsjtBBKBdjGxYAfovcNoJ = 0;
						goto IL_009c;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							rvQSwtcsjtBBKBdjGxYAfovcNoJ++;
							goto IL_009c;
						}
						IL_009c:
						if (rvQSwtcsjtBBKBdjGxYAfovcNoJ < SRANgxUVpfgxWDWAXzYaQBCSnqC)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons[rvQSwtcsjtBBKBdjGxYAfovcNoJ];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public ZtSElhWHfhEAhHQBHneOjqTDGOOl(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform => InputPlatform.fMohdktunNVwcKFhaCaZcTOyeuLa;

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
						array[i] = identifiers[num3].name;
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
						array[i] = identifiers[num2].name;
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
						ref AxisCalibrationData reference = ref array[i];
						reference = AxisCalibrationData.Default;
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
						ref AxisCalibrationData reference2 = ref array[i];
						reference2 = AxisCalibrationData.Default;
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
				PAydUNdTAnhLZVbwZsqhPJCifhRx pAydUNdTAnhLZVbwZsqhPJCifhRx = new PAydUNdTAnhLZVbwZsqhPJCifhRx(-2);
				pAydUNdTAnhLZVbwZsqhPJCifhRx.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return pAydUNdTAnhLZVbwZsqhPJCifhRx;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				ZtSElhWHfhEAhHQBHneOjqTDGOOl ztSElhWHfhEAhHQBHneOjqTDGOOl = new ZtSElhWHfhEAhHQBHneOjqTDGOOl(-2);
				ztSElhWHfhEAhHQBHneOjqTDGOOl.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return ztSElhWHfhEAhHQBHneOjqTDGOOl;
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

			internal override IList<Platform> variants_base => variants;

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

			internal override InputPlatform platform => InputPlatform.mvEFVuWpoGVttlHIJFrEMLtxqDF;

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

			internal override IList<Platform> variants_base => variants;

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
						ClientInfo clientInfo = new ClientInfo();
						clientInfo.browser = browser;
						clientInfo.browserVersionMin = browserVersionMin;
						clientInfo.browserVersionMax = browserVersionMax;
						clientInfo.os = os;
						clientInfo.osVersionMin = osVersionMin;
						clientInfo.osVersionMax = osVersionMax;
						return clientInfo;
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
						if (productName != null && productName.Length > 0)
						{
							return true;
						}
						if (mapping != null && mapping.Length > 0)
						{
							return true;
						}
						if (productGUID != null && productGUID.Length > 0)
						{
							return true;
						}
						if (elementCount != null && elementCount.Length > 0)
						{
							return true;
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
					if (this.clientInfo != null && this.clientInfo.Length > 0)
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
					if (elementCount != null && elementCount.Length > 0)
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
					if (mapping != null && mapping.Length > 0)
					{
						bool flag3 = false;
						for (int k = 0; k < mapping.Length; k++)
						{
							int num = mapping[k];
							if (num == (int)bridgedControllerHWInfo.webGL_mappingType)
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
					if (productGUID != null && productGUID.Length > 0 && !ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
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
					if (productName != null && productName.Length > 0)
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

			private sealed class QgMqogdmNEIOyqoLTqQZYYGXMRa : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>, IEnumerable
			{
				private Platform_Custom.Axis ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_WebGL_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int IRsofODZadkLGtQnsPEhNWBgxgX;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					QgMqogdmNEIOyqoLTqQZYYGXMRa qgMqogdmNEIOyqoLTqQZYYGXMRa;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						qgMqogdmNEIOyqoLTqQZYYGXMRa = this;
					}
					else
					{
						qgMqogdmNEIOyqoLTqQZYYGXMRa = new QgMqogdmNEIOyqoLTqQZYYGXMRa(0);
						qgMqogdmNEIOyqoLTqQZYYGXMRa.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return qgMqogdmNEIOyqoLTqQZYYGXMRa;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes == null)
						{
							break;
						}
						IRsofODZadkLGtQnsPEhNWBgxgX = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							IRsofODZadkLGtQnsPEhNWBgxgX++;
							goto IL_0084;
						}
						IL_0084:
						if (IRsofODZadkLGtQnsPEhNWBgxgX < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.axes[IRsofODZadkLGtQnsPEhNWBgxgX];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public QgMqogdmNEIOyqoLTqQZYYGXMRa(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private sealed class jYkccRffgHFjsnMtfFqWdVVZpeMN : IDisposable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>, IEnumerable
			{
				private Platform_Custom.Button ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public Platform_WebGL_Base kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public int aapZdiVJINGucQWpghjpdEtMZZur;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					jYkccRffgHFjsnMtfFqWdVVZpeMN jYkccRffgHFjsnMtfFqWdVVZpeMN2;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						jYkccRffgHFjsnMtfFqWdVVZpeMN2 = this;
					}
					else
					{
						jYkccRffgHFjsnMtfFqWdVVZpeMN2 = new jYkccRffgHFjsnMtfFqWdVVZpeMN(0);
						jYkccRffgHFjsnMtfFqWdVVZpeMN2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					return jYkccRffgHFjsnMtfFqWdVVZpeMN2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elements == null || kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons == null)
						{
							break;
						}
						aapZdiVJINGucQWpghjpdEtMZZur = 0;
						goto IL_0084;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							aapZdiVJINGucQWpghjpdEtMZZur++;
							goto IL_0084;
						}
						IL_0084:
						if (aapZdiVJINGucQWpghjpdEtMZZur < kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons.Length)
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elements.buttons[aapZdiVJINGucQWpghjpdEtMZZur];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public jYkccRffgHFjsnMtfFqWdVVZpeMN(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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

			internal override InputPlatform platform => InputPlatform.sCyBKEhljbhCCaYpdxJkaTHaPFqk;

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
				QgMqogdmNEIOyqoLTqQZYYGXMRa qgMqogdmNEIOyqoLTqQZYYGXMRa = new QgMqogdmNEIOyqoLTqQZYYGXMRa(-2);
				qgMqogdmNEIOyqoLTqQZYYGXMRa.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return qgMqogdmNEIOyqoLTqQZYYGXMRa;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				jYkccRffgHFjsnMtfFqWdVVZpeMN jYkccRffgHFjsnMtfFqWdVVZpeMN2 = new jYkccRffgHFjsnMtfFqWdVVZpeMN(-2);
				jYkccRffgHFjsnMtfFqWdVVZpeMN2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return jYkccRffgHFjsnMtfFqWdVVZpeMN2;
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
						array[i] = identifiers[num].name;
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
						array[i] = identifiers[num].name;
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
						ref AxisCalibrationData reference = ref array[i];
						reference = AxisCalibrationData.Default;
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
						ref AxisCalibrationData reference2 = ref array[i];
						reference2 = AxisCalibrationData.Default;
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

			internal override IList<Platform> variants_base => variants;

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

		private sealed class rEPTIPBLayfotMFwXKhhlvIsUxX : IDisposable, IEnumerator, IEnumerable, IEnumerable<Guid>, IEnumerator<Guid>
		{
			private Guid ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public HardwareJoystickMap kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int ZnnmNXXfsicGEHWXbWxdFbttOhz;

			Guid IEnumerator<Guid>.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			[DebuggerHidden]
			IEnumerator<Guid> IEnumerable<Guid>.GetEnumerator()
			{
				rEPTIPBLayfotMFwXKhhlvIsUxX rEPTIPBLayfotMFwXKhhlvIsUxX2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					rEPTIPBLayfotMFwXKhhlvIsUxX2 = this;
				}
				else
				{
					rEPTIPBLayfotMFwXKhhlvIsUxX2 = new rEPTIPBLayfotMFwXKhhlvIsUxX(0);
					rEPTIPBLayfotMFwXKhhlvIsUxX2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				return rEPTIPBLayfotMFwXKhhlvIsUxX2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Guid>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.templateGuids == null)
					{
						break;
					}
					ZnnmNXXfsicGEHWXbWxdFbttOhz = 0;
					goto IL_006f;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						ZnnmNXXfsicGEHWXbWxdFbttOhz++;
						goto IL_006f;
					}
					IL_006f:
					if (ZnnmNXXfsicGEHWXbWxdFbttOhz < kdBZqupjvsCsVkwJiOeEQzkEDVO.templateGuids.Length)
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = StringTools.ToGuid(kdBZqupjvsCsVkwJiOeEQzkEDVO.templateGuids[ZnnmNXXfsicGEHWXbWxdFbttOhz]);
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public rEPTIPBLayfotMFwXKhhlvIsUxX(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class kGzntHnWxsCpNybpLQmlYDpIXya : IDisposable, IEnumerable<ControllerElementIdentifier>, IEnumerator<ControllerElementIdentifier>, IEnumerator, IEnumerable
		{
			private ControllerElementIdentifier ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public HardwareJoystickMap kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int NsSgtOdQbNGFdoiRiRKKFjIxElgT;

			ControllerElementIdentifier IEnumerator<ControllerElementIdentifier>.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerElementIdentifier> IEnumerable<ControllerElementIdentifier>.GetEnumerator()
			{
				kGzntHnWxsCpNybpLQmlYDpIXya kGzntHnWxsCpNybpLQmlYDpIXya2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					kGzntHnWxsCpNybpLQmlYDpIXya2 = this;
				}
				else
				{
					kGzntHnWxsCpNybpLQmlYDpIXya2 = new kGzntHnWxsCpNybpLQmlYDpIXya(0);
					kGzntHnWxsCpNybpLQmlYDpIXya2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				return kGzntHnWxsCpNybpLQmlYDpIXya2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerElementIdentifier>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elementIdentifiers == null)
					{
						break;
					}
					NsSgtOdQbNGFdoiRiRKKFjIxElgT = 0;
					goto IL_006a;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						NsSgtOdQbNGFdoiRiRKKFjIxElgT++;
						goto IL_006a;
					}
					IL_006a:
					if (NsSgtOdQbNGFdoiRiRKKFjIxElgT < kdBZqupjvsCsVkwJiOeEQzkEDVO.elementIdentifiers.Length)
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elementIdentifiers[NsSgtOdQbNGFdoiRiRKKFjIxElgT];
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public kGzntHnWxsCpNybpLQmlYDpIXya(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class sWKDviIqfMtbWiuURLEHApwrflb : IDisposable, IEnumerator, IEnumerable, IEnumerable<JoystickType>, IEnumerator<JoystickType>
		{
			private JoystickType ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public HardwareJoystickMap kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int MEcCQFHbfgBWbTwXMVopAVVdGLj;

			JoystickType IEnumerator<JoystickType>.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			[DebuggerHidden]
			IEnumerator<JoystickType> IEnumerable<JoystickType>.GetEnumerator()
			{
				sWKDviIqfMtbWiuURLEHApwrflb sWKDviIqfMtbWiuURLEHApwrflb2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					sWKDviIqfMtbWiuURLEHApwrflb2 = this;
				}
				else
				{
					sWKDviIqfMtbWiuURLEHApwrflb2 = new sWKDviIqfMtbWiuURLEHApwrflb(0);
					sWKDviIqfMtbWiuURLEHApwrflb2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				return sWKDviIqfMtbWiuURLEHApwrflb2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JoystickType>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.joystickTypes == null)
					{
						break;
					}
					MEcCQFHbfgBWbTwXMVopAVVdGLj = 0;
					goto IL_006a;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						MEcCQFHbfgBWbTwXMVopAVVdGLj++;
						goto IL_006a;
					}
					IL_006a:
					if (MEcCQFHbfgBWbTwXMVopAVVdGLj < kdBZqupjvsCsVkwJiOeEQzkEDVO.joystickTypes.Length)
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.joystickTypes[MEcCQFHbfgBWbTwXMVopAVVdGLj];
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public sWKDviIqfMtbWiuURLEHApwrflb(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class sEvcOkGUtkhICOmyHiRtwXuQKwqo : IDisposable, IEnumerator, IEnumerable, IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerator<IControllerElementIdentifierCommon_Internal>
		{
			private IControllerElementIdentifierCommon_Internal ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public HardwareJoystickMap kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int CrmObraNoCjFbavVwWtAxcZXGym;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			[DebuggerHidden]
			IEnumerator<IControllerElementIdentifierCommon_Internal> IEnumerable<IControllerElementIdentifierCommon_Internal>.GetEnumerator()
			{
				sEvcOkGUtkhICOmyHiRtwXuQKwqo sEvcOkGUtkhICOmyHiRtwXuQKwqo2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					sEvcOkGUtkhICOmyHiRtwXuQKwqo2 = this;
				}
				else
				{
					sEvcOkGUtkhICOmyHiRtwXuQKwqo2 = new sEvcOkGUtkhICOmyHiRtwXuQKwqo(0);
					sEvcOkGUtkhICOmyHiRtwXuQKwqo2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				return sEvcOkGUtkhICOmyHiRtwXuQKwqo2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<IControllerElementIdentifierCommon_Internal>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.elementIdentifiers == null)
					{
						break;
					}
					CrmObraNoCjFbavVwWtAxcZXGym = 0;
					goto IL_006a;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						CrmObraNoCjFbavVwWtAxcZXGym++;
						goto IL_006a;
					}
					IL_006a:
					if (CrmObraNoCjFbavVwWtAxcZXGym < kdBZqupjvsCsVkwJiOeEQzkEDVO.elementIdentifiers.Length)
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.elementIdentifiers[CrmObraNoCjFbavVwWtAxcZXGym];
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public sEvcOkGUtkhICOmyHiRtwXuQKwqo(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string[] templateGuids;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool hideInLists;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_XInput xInput;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_Blackberry;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_WindowsPhone8;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_XBox360;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_XBoxOne;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_PS3;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_Wii;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_XboxOne xboxOne;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_GameCore gameCore;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_PS4 ps4;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_SDL2 sdl2_Windows;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_SDL2 sdl2_OSX;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int elementIdentifierIdCounter;

		public string ControllerName => controllerName;

		public string EditorControllerName => editorControllerName;

		public Guid Guid => StringTools.ToGuid(controllerGuid);

		public IEnumerable<Guid> TemplateGuids
		{
			get
			{
				rEPTIPBLayfotMFwXKhhlvIsUxX rEPTIPBLayfotMFwXKhhlvIsUxX2 = new rEPTIPBLayfotMFwXKhhlvIsUxX(-2);
				rEPTIPBLayfotMFwXKhhlvIsUxX2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return rEPTIPBLayfotMFwXKhhlvIsUxX2;
			}
		}

		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				kGzntHnWxsCpNybpLQmlYDpIXya kGzntHnWxsCpNybpLQmlYDpIXya2 = new kGzntHnWxsCpNybpLQmlYDpIXya(-2);
				kGzntHnWxsCpNybpLQmlYDpIXya2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return kGzntHnWxsCpNybpLQmlYDpIXya2;
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
				sWKDviIqfMtbWiuURLEHApwrflb sWKDviIqfMtbWiuURLEHApwrflb2 = new sWKDviIqfMtbWiuURLEHApwrflb(-2);
				sWKDviIqfMtbWiuURLEHApwrflb2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return sWKDviIqfMtbWiuURLEHApwrflb2;
			}
		}

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			get
			{
				sEvcOkGUtkhICOmyHiRtwXuQKwqo sEvcOkGUtkhICOmyHiRtwXuQKwqo2 = new sEvcOkGUtkhICOmyHiRtwXuQKwqo(-2);
				sEvcOkGUtkhICOmyHiRtwXuQKwqo2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				return sEvcOkGUtkhICOmyHiRtwXuQKwqo2;
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
			actualInputPlatform = InputPlatform.eDgdySKclHgXmmILffzdHPvUtEi;
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
					actualInputPlatform = InputPlatform.zjuIGPllhlPcayeppPtHSewObGXj;
					return true;
				}
				if (Matches(rawInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					actualInputPlatform = InputPlatform.HnmsmUSKysdUvrNYWdqtigLcwDX;
					return true;
				}
				return false;
			case InputSource.RawInput:
				if (Matches(rawInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					actualInputPlatform = InputPlatform.HnmsmUSKysdUvrNYWdqtigLcwDX;
					return true;
				}
				if (Matches(directInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
				{
					actualInputPlatform = InputPlatform.zjuIGPllhlPcayeppPtHSewObGXj;
					return true;
				}
				return false;
			case InputSource.XInput:
				if (xInput == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.JeLygDdKjPUUTKlZIRIVKzQWCev;
				return xInput.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.OSX:
				if (osx == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.BNAbWQOUmbdcYxSUpDXHIqmUlal;
				return osx.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.Linux:
				if (linux == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.ZYWfhkfXgXmhbJlTbCJAdwyQeaH;
				return linux.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.WindowsUWP:
				if (windowsUWP == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.AbkfUMwvaoaiMbXSNFohhLPkNN;
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
				actualInputPlatform = InputPlatform.sCyBKEhljbhCCaYpdxJkaTHaPFqk;
				return webGL.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.Ouya:
				if (ouya == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.VVFNMnuwjQktQBuzllCpFfiGHnU;
				return ouya.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.XboxOne:
				if (xboxOne == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.MKsYfylcxroUpkqMsmDQAiXKRGk;
				return xboxOne.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.GameCoreXboxOne:
			case InputSource.GameCoreScarlett:
				if (gameCore == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.GVKDbJYxOtlxBEEweJFxfiMGZit;
				return gameCore.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.PS4:
				if (ps4 == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.ZSmWcBJLZPZDkzrSGqQUcIqQUvG;
				return ps4.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.PS5:
				if (ps5 == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.qCrCYaIeXKGNOmBWGyRNKAkvERYH;
				return ps5.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.NintendoSwitch:
				if (nintendoSwitch == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.KmXpwJBmIkvUmMjyMwPhIQVKxxP;
				return nintendoSwitch.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.Stadia:
				if (stadia == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.rjPPkipWWuRRnodJLIuVKeUPVmE;
				return stadia.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.InternalDriver:
				if (internalDriver == null)
				{
					return false;
				}
				actualInputPlatform = InputPlatform.FhqZiqCHhXxQXjCHQDlDqwTlgOd;
				return internalDriver.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			case InputSource.SDL2:
				platformMap = FindSDL2Match(bridgedControllerHWInfo, strictMatch, isDefaultMap, out actualInputPlatform, out variantIndex);
				return platformMap != null;
			case InputSource.Steam:
				actualInputPlatform = InputPlatform.mvEFVuWpoGVttlHIJFrEMLtxqDF;
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
				actualInputPlatform = InputPlatform.zjuIGPllhlPcayeppPtHSewObGXj;
				platform = directInput;
				break;
			case InputSource.RawInput:
				actualInputPlatform = InputPlatform.HnmsmUSKysdUvrNYWdqtigLcwDX;
				platform = rawInput;
				break;
			case InputSource.XInput:
				actualInputPlatform = InputPlatform.JeLygDdKjPUUTKlZIRIVKzQWCev;
				platform = xInput;
				break;
			case InputSource.OSX:
				actualInputPlatform = InputPlatform.BNAbWQOUmbdcYxSUpDXHIqmUlal;
				platform = osx;
				break;
			case InputSource.Linux:
				actualInputPlatform = InputPlatform.ZYWfhkfXgXmhbJlTbCJAdwyQeaH;
				platform = linux;
				break;
			case InputSource.WindowsUWP:
				actualInputPlatform = InputPlatform.AbkfUMwvaoaiMbXSNFohhLPkNN;
				platform = windowsUWP;
				break;
			case InputSource.Fallback:
			case InputSource.Fallback_PreConfigured:
				platform = FindFallbackMap(inputSource, isDefaultMap: true, out actualInputPlatform, out variantIndex);
				break;
			case InputSource.WebGL:
				actualInputPlatform = InputPlatform.sCyBKEhljbhCCaYpdxJkaTHaPFqk;
				platform = webGL;
				break;
			case InputSource.Ouya:
				actualInputPlatform = InputPlatform.VVFNMnuwjQktQBuzllCpFfiGHnU;
				platform = ouya;
				break;
			case InputSource.XboxOne:
				actualInputPlatform = InputPlatform.MKsYfylcxroUpkqMsmDQAiXKRGk;
				platform = xboxOne;
				break;
			case InputSource.GameCoreXboxOne:
			case InputSource.GameCoreScarlett:
				actualInputPlatform = InputPlatform.GVKDbJYxOtlxBEEweJFxfiMGZit;
				platform = gameCore;
				if (!gameCore.hasData)
				{
					platform = Platform_GameCore.CreateDefaultMap(bridgedController);
				}
				break;
			case InputSource.PS4:
				actualInputPlatform = InputPlatform.ZSmWcBJLZPZDkzrSGqQUcIqQUvG;
				platform = ps4;
				break;
			case InputSource.PS5:
				actualInputPlatform = InputPlatform.qCrCYaIeXKGNOmBWGyRNKAkvERYH;
				platform = ps5;
				break;
			case InputSource.NintendoSwitch:
				actualInputPlatform = InputPlatform.KmXpwJBmIkvUmMjyMwPhIQVKxxP;
				platform = nintendoSwitch;
				break;
			case InputSource.Stadia:
				actualInputPlatform = InputPlatform.rjPPkipWWuRRnodJLIuVKeUPVmE;
				platform = stadia;
				break;
			case InputSource.InternalDriver:
				actualInputPlatform = InputPlatform.FhqZiqCHhXxQXjCHQDlDqwTlgOd;
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
				actualInputPlatform = InputPlatform.IiYVPhkBQDWUFMBZApvaoSmlpUY;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.WindowsUWP:
			{
				Platform_Fallback_Base mainMap = fallback_WindowsUWP;
				actualInputPlatform = InputPlatform.sBofcNEzKnXaIaEyuhnelqHavQub;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.OSX:
			{
				Platform_Fallback_Base mainMap = fallback_OSX;
				actualInputPlatform = InputPlatform.CmFFcHIXHWioiDacpcofVIqIKnki;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Linux:
			{
				Platform_Fallback_Base mainMap;
				if (inputSource == InputSource.Fallback_PreConfigured)
				{
					mainMap = fallback_Linux_PreConfigured;
					actualInputPlatform = InputPlatform.oAAdVztUZvdWxWVPVNKSOWxscse;
					mainMap = TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
					if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.oAAdVztUZvdWxWVPVNKSOWxscse)
					{
						mainMap = null;
					}
					if (mainMap != null)
					{
						return mainMap;
					}
				}
				mainMap = fallback_Linux;
				actualInputPlatform = InputPlatform.TEpWdhwRUlPPNMVISBllNtGtAwO;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Android:
			{
				Platform_Fallback_Base mainMap = fallback_Android;
				actualInputPlatform = InputPlatform.EbajLkpIZkVaaIwzohnttmAUeHL;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.iOS:
			case Rewired.Platforms.Platform.tvOS:
			{
				Platform_Fallback_Base mainMap = fallback_iOS;
				actualInputPlatform = InputPlatform.ckuBQjUvyuRajhNeuGaJdHHWMHdh;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Blackberry:
			{
				Platform_Fallback_Base mainMap = fallback_Blackberry;
				actualInputPlatform = InputPlatform.oeLZvcnfCfVnAFmcanoXJuovCEw;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.WindowsPhone8:
			{
				Platform_Fallback_Base mainMap = fallback_WindowsPhone8;
				actualInputPlatform = InputPlatform.tQmIVvHeoAjpHcrHmqhbtoDzCxvS;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Xbox360:
			{
				Platform_Fallback_Base mainMap = fallback_XBox360;
				actualInputPlatform = InputPlatform.oHbUlMhdtaLAdpCdsbKhGJFyFgFC;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.XboxOne:
			{
				Platform_Fallback_Base mainMap = fallback_XBoxOne;
				actualInputPlatform = InputPlatform.PSNJwwaztDiNMFjGOjvxIFDLyJd;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.PS3:
			{
				Platform_Fallback_Base mainMap = fallback_PS3;
				actualInputPlatform = InputPlatform.OEzyclRgujgSqgLXmiwVeSqTQsAQ;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.PS4:
			{
				Platform_Fallback_Base mainMap = fallback_PS4;
				actualInputPlatform = InputPlatform.ZBWPjlQilGRCnkuNNPOjNuWuAB;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.PSMobile:
			{
				Platform_Fallback_Base mainMap = fallback_PSM;
				actualInputPlatform = InputPlatform.scaTCaHtkQSzDycyRVnaiRcAFrbe;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.PSVita:
			{
				Platform_Fallback_Base mainMap = fallback_PSVita;
				actualInputPlatform = InputPlatform.YxuRbqPXGbsbLAmYlsdkeorSxSG;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Wii:
			{
				Platform_Fallback_Base mainMap = fallback_Wii;
				actualInputPlatform = InputPlatform.IPIEqoqwGyabCFWBzLpseQSeKot;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.WiiU:
			{
				Platform_Fallback_Base mainMap = fallback_WiiU;
				actualInputPlatform = InputPlatform.SzozMXAyeBkOriEcFEvEHiSppTj;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.AmazonFireTV:
			{
				Platform_Fallback_Base mainMap = fallback_AmazonFireTV;
				actualInputPlatform = InputPlatform.eHhNCClyhXeSmfduxhLRRekLYkE;
				mainMap = TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
				if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.eHhNCClyhXeSmfduxhLRRekLYkE)
				{
					mainMap = null;
				}
				if (mainMap != null)
				{
					return mainMap;
				}
				mainMap = fallback_Android;
				actualInputPlatform = InputPlatform.EbajLkpIZkVaaIwzohnttmAUeHL;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.RazerForgeTV:
			{
				Platform_Fallback_Base mainMap = fallback_RazerForgeTV;
				actualInputPlatform = InputPlatform.ZiBWcaNXtPGLSnkUxOJdDDUWWor;
				mainMap = TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
				if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.ZiBWcaNXtPGLSnkUxOJdDDUWWor)
				{
					mainMap = null;
				}
				if (mainMap != null)
				{
					return mainMap;
				}
				mainMap = fallback_Android;
				actualInputPlatform = InputPlatform.EbajLkpIZkVaaIwzohnttmAUeHL;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Webplayer:
				if (UnityTools.webplayerPlatform == WebplayerPlatform.Windows)
				{
					Platform_Fallback_Base mainMap = fallback_Windows;
					actualInputPlatform = InputPlatform.IiYVPhkBQDWUFMBZApvaoSmlpUY;
					return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				if (UnityTools.webplayerPlatform == WebplayerPlatform.OSX)
				{
					Platform_Fallback_Base mainMap = fallback_OSX;
					actualInputPlatform = InputPlatform.CmFFcHIXHWioiDacpcofVIqIKnki;
					return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				break;
			}
			if (isDefaultMap)
			{
				return GetUniversalDefaultMap<Platform_Fallback_Base>(out actualInputPlatform, out variantIndex);
			}
			variantIndex = -1;
			actualInputPlatform = InputPlatform.eDgdySKclHgXmmILffzdHPvUtEi;
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
				actualInputPlatform = InputPlatform.IiYVPhkBQDWUFMBZApvaoSmlpUY;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.WindowsUWP:
			{
				Platform_Fallback_Base mainMap = fallback_WindowsUWP;
				actualInputPlatform = InputPlatform.sBofcNEzKnXaIaEyuhnelqHavQub;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.OSX:
			{
				Platform_Fallback_Base mainMap = fallback_OSX;
				actualInputPlatform = InputPlatform.CmFFcHIXHWioiDacpcofVIqIKnki;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Linux:
			{
				Platform_Fallback_Base mainMap;
				if (inputSource == InputSource.Fallback_PreConfigured)
				{
					mainMap = fallback_Linux_PreConfigured;
					actualInputPlatform = InputPlatform.oAAdVztUZvdWxWVPVNKSOWxscse;
					mainMap = TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
					if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.oAAdVztUZvdWxWVPVNKSOWxscse)
					{
						mainMap = null;
					}
					if (mainMap != null)
					{
						return mainMap;
					}
				}
				mainMap = fallback_Linux;
				actualInputPlatform = InputPlatform.TEpWdhwRUlPPNMVISBllNtGtAwO;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Android:
			{
				Platform_Fallback_Base mainMap = fallback_Android;
				actualInputPlatform = InputPlatform.EbajLkpIZkVaaIwzohnttmAUeHL;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.iOS:
			case Rewired.Platforms.Platform.tvOS:
			{
				Platform_Fallback_Base mainMap = fallback_iOS;
				actualInputPlatform = InputPlatform.ckuBQjUvyuRajhNeuGaJdHHWMHdh;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Blackberry:
			{
				Platform_Fallback_Base mainMap = fallback_Blackberry;
				actualInputPlatform = InputPlatform.oeLZvcnfCfVnAFmcanoXJuovCEw;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.WindowsPhone8:
			{
				Platform_Fallback_Base mainMap = fallback_WindowsPhone8;
				actualInputPlatform = InputPlatform.tQmIVvHeoAjpHcrHmqhbtoDzCxvS;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Xbox360:
			{
				Platform_Fallback_Base mainMap = fallback_XBox360;
				actualInputPlatform = InputPlatform.oHbUlMhdtaLAdpCdsbKhGJFyFgFC;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.XboxOne:
			{
				Platform_Fallback_Base mainMap = fallback_XBoxOne;
				actualInputPlatform = InputPlatform.PSNJwwaztDiNMFjGOjvxIFDLyJd;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.PS3:
			{
				Platform_Fallback_Base mainMap = fallback_PS3;
				actualInputPlatform = InputPlatform.OEzyclRgujgSqgLXmiwVeSqTQsAQ;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.PS4:
			{
				Platform_Fallback_Base mainMap = fallback_PS4;
				actualInputPlatform = InputPlatform.ZBWPjlQilGRCnkuNNPOjNuWuAB;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.PSMobile:
			{
				Platform_Fallback_Base mainMap = fallback_PSM;
				actualInputPlatform = InputPlatform.scaTCaHtkQSzDycyRVnaiRcAFrbe;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.PSVita:
			{
				Platform_Fallback_Base mainMap = fallback_PSVita;
				actualInputPlatform = InputPlatform.YxuRbqPXGbsbLAmYlsdkeorSxSG;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Wii:
			{
				Platform_Fallback_Base mainMap = fallback_Wii;
				actualInputPlatform = InputPlatform.IPIEqoqwGyabCFWBzLpseQSeKot;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.WiiU:
			{
				Platform_Fallback_Base mainMap = fallback_WiiU;
				actualInputPlatform = InputPlatform.SzozMXAyeBkOriEcFEvEHiSppTj;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.AmazonFireTV:
			{
				Platform_Fallback_Base mainMap = fallback_AmazonFireTV;
				actualInputPlatform = InputPlatform.eHhNCClyhXeSmfduxhLRRekLYkE;
				mainMap = TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
				if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.eHhNCClyhXeSmfduxhLRRekLYkE)
				{
					mainMap = null;
				}
				if (mainMap != null)
				{
					return mainMap;
				}
				mainMap = fallback_Android;
				actualInputPlatform = InputPlatform.EbajLkpIZkVaaIwzohnttmAUeHL;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.RazerForgeTV:
			{
				Platform_Fallback_Base mainMap = fallback_RazerForgeTV;
				actualInputPlatform = InputPlatform.ZiBWcaNXtPGLSnkUxOJdDDUWWor;
				mainMap = TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
				if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.ZiBWcaNXtPGLSnkUxOJdDDUWWor)
				{
					mainMap = null;
				}
				if (mainMap != null)
				{
					return mainMap;
				}
				mainMap = fallback_Android;
				actualInputPlatform = InputPlatform.EbajLkpIZkVaaIwzohnttmAUeHL;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Webplayer:
				if (UnityTools.webplayerPlatform == WebplayerPlatform.Windows)
				{
					Platform_Fallback_Base mainMap = fallback_Windows;
					actualInputPlatform = InputPlatform.IiYVPhkBQDWUFMBZApvaoSmlpUY;
					return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				if (UnityTools.webplayerPlatform == WebplayerPlatform.OSX)
				{
					Platform_Fallback_Base mainMap = fallback_OSX;
					actualInputPlatform = InputPlatform.CmFFcHIXHWioiDacpcofVIqIKnki;
					return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
				}
				break;
			}
			if (isDefaultMap)
			{
				return GetUniversalDefaultMap<Platform_Fallback_Base>(out actualInputPlatform, out variantIndex);
			}
			variantIndex = -1;
			actualInputPlatform = InputPlatform.eDgdySKclHgXmmILffzdHPvUtEi;
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
				actualInputPlatform = InputPlatform.ejbZpTduacoBQDFXwcokcPpTjtgc;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Linux:
			{
				Platform_SDL2_Base mainMap = sdl2_Linux;
				actualInputPlatform = InputPlatform.VfWORDGmzGhvteBfFSusLWDehlE;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.OSX:
			{
				Platform_SDL2_Base mainMap = sdl2_OSX;
				actualInputPlatform = InputPlatform.DYWhIWXGcQZOVzzgoZhUkCHdMAk;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			default:
				if (isDefaultMap)
				{
					GetUniversalDefaultMap<Platform_SDL2_Base>(out actualInputPlatform, out variantIndex);
				}
				actualInputPlatform = InputPlatform.eDgdySKclHgXmmILffzdHPvUtEi;
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
				actualInputPlatform = InputPlatform.ejbZpTduacoBQDFXwcokcPpTjtgc;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.Linux:
			{
				Platform_SDL2_Base mainMap = sdl2_Linux;
				actualInputPlatform = InputPlatform.VfWORDGmzGhvteBfFSusLWDehlE;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			case Rewired.Platforms.Platform.OSX:
			{
				Platform_SDL2_Base mainMap = sdl2_OSX;
				actualInputPlatform = InputPlatform.DYWhIWXGcQZOVzzgoZhUkCHdMAk;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			default:
				if (isDefaultMap)
				{
					GetUniversalDefaultMap<Platform_SDL2_Base>(out actualInputPlatform, out variantIndex);
				}
				actualInputPlatform = InputPlatform.eDgdySKclHgXmmILffzdHPvUtEi;
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
			actualInputPlatform = InputPlatform.ejbZpTduacoBQDFXwcokcPpTjtgc;
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
			if (object.ReferenceEquals(type, typeof(Platform_Fallback_Base)))
			{
				actualInputPlatform = InputPlatform.IiYVPhkBQDWUFMBZApvaoSmlpUY;
				return fallback_Windows as T;
			}
			if (object.ReferenceEquals(type, typeof(Platform_SDL2_Base)))
			{
				actualInputPlatform = InputPlatform.ejbZpTduacoBQDFXwcokcPpTjtgc;
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
			case InputPlatform.zjuIGPllhlPcayeppPtHSewObGXj:
				return directInput;
			case InputPlatform.HnmsmUSKysdUvrNYWdqtigLcwDX:
				return rawInput;
			case InputPlatform.JeLygDdKjPUUTKlZIRIVKzQWCev:
				return xInput;
			case InputPlatform.IiYVPhkBQDWUFMBZApvaoSmlpUY:
				return fallback_Windows;
			case InputPlatform.AbkfUMwvaoaiMbXSNFohhLPkNN:
				return windowsUWP;
			case InputPlatform.sBofcNEzKnXaIaEyuhnelqHavQub:
				return fallback_WindowsUWP;
			case InputPlatform.BNAbWQOUmbdcYxSUpDXHIqmUlal:
				return osx;
			case InputPlatform.CmFFcHIXHWioiDacpcofVIqIKnki:
				return fallback_OSX;
			case InputPlatform.ZYWfhkfXgXmhbJlTbCJAdwyQeaH:
				return linux;
			case InputPlatform.TEpWdhwRUlPPNMVISBllNtGtAwO:
				return fallback_Linux;
			case InputPlatform.oAAdVztUZvdWxWVPVNKSOWxscse:
				return fallback_Linux_PreConfigured;
			case InputPlatform.EbajLkpIZkVaaIwzohnttmAUeHL:
				return fallback_Android;
			case InputPlatform.eHhNCClyhXeSmfduxhLRRekLYkE:
				return fallback_AmazonFireTV;
			case InputPlatform.ZiBWcaNXtPGLSnkUxOJdDDUWWor:
				return fallback_RazerForgeTV;
			case InputPlatform.ckuBQjUvyuRajhNeuGaJdHHWMHdh:
				return fallback_iOS;
			case InputPlatform.tQmIVvHeoAjpHcrHmqhbtoDzCxvS:
				return fallback_WindowsPhone8;
			case InputPlatform.oeLZvcnfCfVnAFmcanoXJuovCEw:
				return fallback_Blackberry;
			case InputPlatform.OEzyclRgujgSqgLXmiwVeSqTQsAQ:
				return fallback_PS3;
			case InputPlatform.ZBWPjlQilGRCnkuNNPOjNuWuAB:
				return fallback_PS4;
			case InputPlatform.scaTCaHtkQSzDycyRVnaiRcAFrbe:
				return fallback_PSM;
			case InputPlatform.YxuRbqPXGbsbLAmYlsdkeorSxSG:
				return fallback_PSVita;
			case InputPlatform.oHbUlMhdtaLAdpCdsbKhGJFyFgFC:
				return fallback_XBox360;
			case InputPlatform.PSNJwwaztDiNMFjGOjvxIFDLyJd:
				return fallback_XBoxOne;
			case InputPlatform.IPIEqoqwGyabCFWBzLpseQSeKot:
				return fallback_Wii;
			case InputPlatform.SzozMXAyeBkOriEcFEvEHiSppTj:
				return fallback_WiiU;
			case InputPlatform.KmXpwJBmIkvUmMjyMwPhIQVKxxP:
				return nintendoSwitch;
			case InputPlatform.rjPPkipWWuRRnodJLIuVKeUPVmE:
				return stadia;
			case InputPlatform.UWCdqzyTIJIwgNgaWEfbEXrlPLun:
				throw new NotImplementedException();
			case InputPlatform.sCyBKEhljbhCCaYpdxJkaTHaPFqk:
				return webGL;
			case InputPlatform.VVFNMnuwjQktQBuzllCpFfiGHnU:
				return ouya;
			case InputPlatform.MKsYfylcxroUpkqMsmDQAiXKRGk:
				return xboxOne;
			case InputPlatform.GVKDbJYxOtlxBEEweJFxfiMGZit:
				return gameCore;
			case InputPlatform.ZSmWcBJLZPZDkzrSGqQUcIqQUvG:
				return ps4;
			case InputPlatform.qCrCYaIeXKGNOmBWGyRNKAkvERYH:
				return ps5;
			case InputPlatform.zInSlzrVBVvwyryGfBwBMWVhNHQ:
				throw new NotImplementedException();
			case InputPlatform.FhqZiqCHhXxQXjCHQDlDqwTlgOd:
				return internalDriver;
			case InputPlatform.fMohdktunNVwcKFhaCaZcTOyeuLa:
				throw new NotImplementedException();
			case InputPlatform.ejbZpTduacoBQDFXwcokcPpTjtgc:
				return sdl2_Windows;
			case InputPlatform.DYWhIWXGcQZOVzzgoZhUkCHdMAk:
				return sdl2_OSX;
			case InputPlatform.VfWORDGmzGhvteBfFSusLWDehlE:
				return sdl2_Linux;
			case InputPlatform.eDgdySKclHgXmmILffzdHPvUtEi:
			case InputPlatform.mvEFVuWpoGVttlHIJFrEMLtxqDF:
				throw new NotImplementedException();
			default:
				throw new NotImplementedException();
			}
		}
	}
}
