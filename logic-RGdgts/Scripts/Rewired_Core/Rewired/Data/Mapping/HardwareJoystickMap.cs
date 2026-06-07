using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	[CustomClassObfuscation]
	public sealed class HardwareJoystickMap : ScriptableObject, IHardwareControllerMap, IHardwareControllerMap_Internal
	{
		[Serializable]
		[CustomClassObfuscation]
		public abstract class Platform : IDeepCloneable
		{
			private sealed class DXUDjmOSaTFEjuoIkYBiqbjBdih : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform>, IEnumerator<Platform>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private IList<Platform> BhfSqqvTbrttFaMZsacrARwJflWF;

				private int eolRghqutZOOIGqvOFTzJOGfYTsn;

				Platform IEnumerator<Platform>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public DXUDjmOSaTFEjuoIkYBiqbjBdih(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform> IEnumerable<Platform>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public string description;

			internal abstract InputPlatform platform { get; }

			public abstract int assignedButtonCount { get; }

			public abstract int assignedAxisCount { get; }

			public virtual string controllerNameOverride => null;

			internal abstract Elements_Base elements_base { get; }

			internal virtual bool isAllowed => false;

			internal abstract bool hasData { get; }

			internal abstract bool disabled { get; }

			internal abstract IList<Platform> variants_base { get; }

			internal IEnumerable<Platform> Variants => null;

			internal bool hasVariants => false;

			[CustomObfuscation]
			internal int variantCount => 0;

			internal bool selfOrVariantHasData => false;

			internal bool selfOrVariantIsValid => false;

			internal bool selfOrVariantIsAllowed => false;

			internal abstract bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap);

			internal abstract string[] GetAxisNames(ControllerElementIdentifier[] identifiers);

			internal abstract string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers);

			internal abstract void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes);

			internal abstract bool IsElementIdentifierMapped(int elementIdentifierId);

			internal Platform GetFirstValidPlatformMap(out int variantIndex)
			{
				variantIndex = default(int);
				return null;
			}

			internal int IndexOfElementIdentifier(ControllerElementIdentifier[] elementIdentifiers, int id)
			{
				return 0;
			}

			internal abstract AxisCalibrationData[] GetAxisCalibrationData();

			internal abstract void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos);

			internal abstract void GetButtonData(out HardwareButtonInfo[] buttonInfos);

			internal abstract ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier);

			internal abstract bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange);

			internal Platform GetPlatformMap(int variantIndex)
			{
				return null;
			}

			internal HardwareJoystickMap_InputManager ToHardwareJoystickMap_InputManager(HardwareJoystickMap hardwareJoystickMap, InputSource inputSource, InputPlatform actualInputPlatform, int variantIndex)
			{
				return null;
			}

			public abstract object DeepClone();

			internal abstract void CopyVars(Platform destination);
		}

		[Serializable]
		[CustomClassObfuscation]
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
		[CustomClassObfuscation]
		public abstract class MatchingCriteria_Base : IDeepCloneable
		{
			[Serializable]
			public class ElementCount_Base : IDeepCloneable
			{
				public int axisCount;

				public int buttonCount;

				public virtual object DeepClone()
				{
					return null;
				}

				internal virtual void VYGHMqVLHaGfLwIBumGKxFdvXZWB(ElementCount_Base P_0)
				{
				}

				internal virtual bool eRcrgXtiJZnEILPhcaiUyTnAFTCn(BridgedControllerHWInfo P_0)
				{
					return false;
				}
			}

			public int axisCount;

			public int buttonCount;

			public bool disabled;

			public string tag;

			internal abstract bool hasData { get; }

			internal virtual bool isAllowed => false;

			internal abstract int alternateElementCount { get; }

			internal virtual bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch)
			{
				return false;
			}

			internal abstract ElementCount_Base GetAlternateElementCount(int index);

			internal virtual bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
			{
				alternateMatched = default(bool);
				return false;
			}

			internal virtual void CopyVars(MatchingCriteria_Base destination)
			{
			}

			internal static bool StringMatches(string searchIn, string searchFor, bool useRegex)
			{
				return false;
			}

			public abstract object DeepClone();
		}

		[Serializable]
		[CustomClassObfuscation]
		public class CompoundElement : IDeepCloneable
		{
			public CompoundControllerElementType type;

			public int elementIdentifier;

			public int[] componentElementIdentifiers;

			public int elementCount => 0;

			public CompoundElement()
			{
			}

			public CompoundElement(CompoundElement P_0)
			{
			}

			public int GetComponentElementIdentifierId(int index)
			{
				return 0;
			}

			public virtual object DeepClone()
			{
				return null;
			}

			protected virtual void ImportVars(CompoundElement source)
			{
			}

			internal static void SortHatElementsClockwise(CompoundElement element)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class VidPid
		{
			public int vendorId;

			public int productId;
		}

		[Serializable]
		[CustomClassObfuscation]
		public class AxisCalibrationInfoEntry : IDeepCloneable
		{
			[SerializeField]
			internal AlternateAxisCalibrationType key;

			[SerializeField]
			internal AxisCalibrationInfo calibration;

			public AxisCalibrationInfoEntry(AxisCalibrationInfoEntry P_0)
			{
			}

			public virtual object DeepClone()
			{
				return null;
			}

			protected virtual void ImportVars(AxisCalibrationInfoEntry source)
			{
			}

			public static Dictionary<int, AxisCalibrationInfo> ToDictionary(AxisCalibrationInfoEntry[] calibrations, bool deepClone)
			{
				return null;
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public abstract class Platform_RawOrDirectInput : Platform
		{
			[Serializable]
			[CustomClassObfuscation]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				[Serializable]
				public sealed class ElementCount : ElementCount_Base
				{
					public int hatCount;

					public override object DeepClone()
					{
						return null;
					}

					internal override void VYGHMqVLHaGfLwIBumGKxFdvXZWB(ElementCount_Base P_0)
					{
					}

					internal override bool eRcrgXtiJZnEILPhcaiUyTnAFTCn(BridgedControllerHWInfo P_0)
					{
						return false;
					}
				}

				public int hatCount;

				public ElementCount[] alternateElementCounts;

				public bool productName_useRegex;

				public string[] productName;

				public string[] productGUID;

				public int[] productId;

				public DeviceType deviceType;

				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override int alternateElementCount => 0;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					alternateMatched = default(bool);
					return false;
				}

				private bool ProductNameMatches(BridgedControllerHWInfo controller)
				{
					return false;
				}

				private bool ProductNameMatches(string name)
				{
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public abstract class Elements_Platform_Base : Elements_Base
			{
				internal abstract IEnumerable<Axis_Base> Axes { get; }

				internal abstract IEnumerable<Button_Base> Buttons { get; }

				internal abstract Axis_Base GetAxis(int axisIndex);
			}

			[Serializable]
			[CustomClassObfuscation]
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
					return null;
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public abstract class Element : IDeepCloneable
			{
				public CustomCalculation customCalculation;

				public CustomCalculationSourceData[] customCalculationSourceData;

				public abstract object DeepClone();

				protected void ImportVars(Element source)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
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
				}

				protected void ImportVars(Button_Base source)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
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
				}

				protected void ImportVars(Axis_Base source)
				{
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

			internal override bool hasData => false;

			internal override bool disabled => false;

			internal override bool isAllowed => false;

			internal abstract IEnumerable<Axis_Base> IterateAxes();

			internal abstract IEnumerable<Button_Base> IterateButtons();

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class Platform_DirectInput_Base : Platform_RawOrDirectInput
		{
			[Serializable]
			[CustomClassObfuscation]
			public sealed class Elements : Elements_Platform_Base
			{
				private sealed class IcrgZiAdMDJWnVdkhgDEUsGEajEFb : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private Axis_Base USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public Elements GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					public IcrgZiAdMDJWnVdkhgDEUsGEajEFb(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					[DebuggerHidden]
					IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}
				}

				private sealed class NUBRvPvBprUqCgMetWpKZCYiHhlL : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private Button_Base USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public Elements GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					public NUBRvPvBprUqCgMetWpKZCYiHhlL(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					[DebuggerHidden]
					IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount => 0;

				public override int axisCount => 0;

				internal override IEnumerable<Axis_Base> Axes => null;

				internal override IEnumerable<Button_Base> Buttons => null;

				internal override Axis_Base GetAxis(int axisIndex)
				{
					return null;
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public sealed class Button : Button_Base
			{
				public override object DeepClone()
				{
					return null;
				}

				private void ImportVars(Button source)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public sealed class Axis : Axis_Base
			{
				public override object DeepClone()
				{
					return null;
				}

				private void ImportVars(Axis source)
				{
				}
			}

			private sealed class TTNcFzkcEtUWyuTAcwEQzNhjzkTc : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Axis_Base USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_DirectInput_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int jgqarFEeHzMrAfFgGEVjBjOGiPSL;

				private int eolRghqutZOOIGqvOFTzJOGfYTsn;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public TTNcFzkcEtUWyuTAcwEQzNhjzkTc(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class dENafeqUEZCugALpBuVPVjSVgpYfA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Button_Base USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_DirectInput_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int sgJTDKufSjBJzKFqoVXwnusUNhZL;

				private int eolRghqutZOOIGqvOFTzJOGfYTsn;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public dENafeqUEZCugALpBuVPVjSVgpYfA(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public Elements elements;

			internal override InputPlatform platform => default(InputPlatform);

			internal Axis[] Axes_orig => null;

			internal Button[] Buttons_orig => null;

			internal override IList<Platform> variants_base => null;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override Elements_Base elements_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return null;
			}

			internal override IEnumerable<Button_Base> IterateButtons()
			{
				return null;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_DirectInput : Platform_DirectInput_Base
		{
			public Platform_DirectInput_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class Platform_RawInput_Base : Platform_RawOrDirectInput
		{
			[Serializable]
			[CustomClassObfuscation]
			public sealed class Elements : Elements_Platform_Base
			{
				private sealed class fLeolIjHkvWcGgPEGTdLdGtXyttj : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private Axis_Base USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public Elements GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

					Axis_Base IEnumerator<Axis_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					public fLeolIjHkvWcGgPEGTdLdGtXyttj(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					[DebuggerHidden]
					IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}
				}

				private sealed class CNSvtzONAgLasLJpEZRPurIyWcaL : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private Button_Base USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public Elements GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

					Button_Base IEnumerator<Button_Base>.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					public CNSvtzONAgLasLJpEZRPurIyWcaL(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					[DebuggerHidden]
					IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount => 0;

				public override int axisCount => 0;

				internal override IEnumerable<Axis_Base> Axes => null;

				internal override IEnumerable<Button_Base> Buttons => null;

				internal override Axis_Base GetAxis(int axisIndex)
				{
					return null;
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public sealed class Button : Button_Base
			{
				public int sourceOtherAxis;

				public override object DeepClone()
				{
					return null;
				}

				private void ImportVars(Button source)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public sealed class Axis : Axis_Base
			{
				public int sourceOtherAxis;

				public override object DeepClone()
				{
					return null;
				}

				private void ImportVars(Axis source)
				{
				}
			}

			private sealed class mnKBQuiHYyYxReeqoHBCHzCtRkfKA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis_Base>, IEnumerator<Axis_Base>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Axis_Base USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_RawInput_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int jgqarFEeHzMrAfFgGEVjBjOGiPSL;

				private int eolRghqutZOOIGqvOFTzJOGfYTsn;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public mnKBQuiHYyYxReeqoHBCHzCtRkfKA(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class MDiSrlQxayvWFBhKuEHndOkdnZNS : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button_Base>, IEnumerator<Button_Base>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Button_Base USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_RawInput_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int sgJTDKufSjBJzKFqoVXwnusUNhZL;

				private int eolRghqutZOOIGqvOFTzJOGfYTsn;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public MDiSrlQxayvWFBhKuEHndOkdnZNS(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public Elements elements;

			internal override InputPlatform platform => default(InputPlatform);

			internal Axis[] Axes_orig => null;

			internal Button[] Buttons_orig => null;

			internal override IList<Platform> variants_base => null;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override Elements_Base elements_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return null;
			}

			internal override IEnumerable<Button_Base> IterateButtons()
			{
				return null;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_RawInput : Platform_RawInput_Base
		{
			public Platform_RawInput_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class Platform_XInput_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				public XInputDeviceSubType[] subType;

				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override int alternateElementCount => 0;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					alternateMatched = default(bool);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public sealed class Elements : Elements_Base
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount => 0;

				public override int axisCount => 0;

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}
			}

			[Serializable]
			[CustomClassObfuscation]
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
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public sealed class Button : Element
			{
				public Pole sourceAxisPole;

				public HardwareButtonInfo buttonInfo;

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
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

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			private sealed class bEWvQMhRNGOKolzLfTZRhCqpAhIAA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_XInput_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public bEWvQMhRNGOKolzLfTZRhCqpAhIAA(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class bhFbsaOpBxgRWqchAclAgBJOCPUGb : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_XInput_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public bhFbsaOpBxgRWqchAclAgBJOCPUGb(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override InputPlatform platform => default(InputPlatform);

			internal Axis[] Axes_orig => null;

			internal Button[] Buttons_orig => null;

			internal override bool hasData => false;

			internal override bool disabled => false;

			internal override bool isAllowed => false;

			internal override Elements_Base elements_base => null;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				return null;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_XInput : Platform_XInput_Base
		{
			public Platform_XInput_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class Platform_OSX_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				[Serializable]
				public sealed class ElementCount : ElementCount_Base
				{
					public int hatCount;

					public override object DeepClone()
					{
						return null;
					}

					internal override void VYGHMqVLHaGfLwIBumGKxFdvXZWB(ElementCount_Base P_0)
					{
					}

					internal override bool eRcrgXtiJZnEILPhcaiUyTnAFTCn(BridgedControllerHWInfo P_0)
					{
						return false;
					}
				}

				public int hatCount;

				public ElementCount[] alternateElementCounts;

				public bool productName_useRegex;

				public string[] productName;

				public string[] manufacturer;

				public int[] productId;

				public int[] vendorId;

				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override int alternateElementCount => 0;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					alternateMatched = default(bool);
					return false;
				}

				private bool ProductNameMatches(string name)
				{
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public sealed class Elements : Elements_Base
			{
				private sealed class vyAKXqeWulsvFEEhDcUUgkVYPCQMA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public Elements GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private Axis[] otVuTclWHkLrdVIElDnnPoApusjv;

					private int kdOQxMRxfBprWWxzhobszTGNskAP;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					public vyAKXqeWulsvFEEhDcUUgkVYPCQMA(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					[DebuggerHidden]
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}
				}

				private sealed class AgUOQYdbEQuZkPLMUKmOuIBjKNKM : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public Elements GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private Button[] otVuTclWHkLrdVIElDnnPoApusjv;

					private int kdOQxMRxfBprWWxzhobszTGNskAP;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					public AgUOQYdbEQuZkPLMUKmOuIBjKNKM(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					[DebuggerHidden]
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount => 0;

				public override int axisCount => 0;

				public IEnumerable<Axis> IterateAxes()
				{
					return null;
				}

				public IEnumerable<Button> IterateButtons()
				{
					return null;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public abstract class Element : IDeepCloneable
			{
				public abstract object DeepClone();
			}

			[Serializable]
			[CustomClassObfuscation]
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

				public override object DeepClone()
				{
					return null;
				}
			}

			[Serializable]
			[CustomClassObfuscation]
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

				public override object DeepClone()
				{
					return null;
				}
			}

			private sealed class NrAagKLtqWldpjcIIEnAENuYHAoD : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_OSX_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public NrAagKLtqWldpjcIIEnAENuYHAoD(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class ujXwtbnQqktmecGiBbRWjeTxgDBaA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_OSX_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public ujXwtbnQqktmecGiBbRWjeTxgDBaA(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override InputPlatform platform => default(InputPlatform);

			internal Button[] Buttons_orig => null;

			internal Axis[] Axes_orig => null;

			internal override bool hasData => false;

			internal override bool disabled => false;

			internal override bool isAllowed => false;

			internal override Elements_Base elements_base => null;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				return null;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_OSX : Platform_OSX_Base
		{
			public Platform_OSX_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class Platform_Linux_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				[Serializable]
				public sealed class ElementCount : ElementCount_Base
				{
					public int hatCount;

					public override object DeepClone()
					{
						return null;
					}

					internal override void VYGHMqVLHaGfLwIBumGKxFdvXZWB(ElementCount_Base P_0)
					{
					}

					internal override bool eRcrgXtiJZnEILPhcaiUyTnAFTCn(BridgedControllerHWInfo P_0)
					{
						return false;
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

				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override int alternateElementCount => 0;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					alternateMatched = default(bool);
					return false;
				}

				private bool AnyNameMatches(BridgedControllerHWInfo bridgedControllerHWInfo)
				{
					return false;
				}

				private bool NameMatches(string name, string[] names, bool useRegex)
				{
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public sealed class Elements : Elements_Base
			{
				private sealed class xdaqATsElYmwIJKEILDmHIcfHuvW : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public Elements GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					public xdaqATsElYmwIJKEILDmHIcfHuvW(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					[DebuggerHidden]
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}
				}

				private sealed class GcFMmPsfkXClLFyKrkYAmFImQoOs : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public Elements GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					public GcFMmPsfkXClLFyKrkYAmFImQoOs(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					[DebuggerHidden]
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount => 0;

				public override int axisCount => 0;

				internal IEnumerable<Axis> Axes => null;

				internal IEnumerable<Button> Buttons => null;

				internal Axis GetAxis(int axisIndex)
				{
					return null;
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public abstract class Element : IDeepCloneable
			{
				public abstract object DeepClone();

				protected virtual void ImportVars(Element source)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
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

				public override object DeepClone()
				{
					return null;
				}

				protected override void ImportVars(Element source)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
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

				public override object DeepClone()
				{
					return null;
				}

				protected override void ImportVars(Element source)
				{
				}
			}

			private sealed class NBaBTNaxZyYPaKtGYFMnBMawWrjiA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_Linux_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int jgqarFEeHzMrAfFgGEVjBjOGiPSL;

				private int eolRghqutZOOIGqvOFTzJOGfYTsn;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public NBaBTNaxZyYPaKtGYFMnBMawWrjiA(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class tsaDQnsbjIpgaMaJyxVJOlyutlKB : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_Linux_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int sgJTDKufSjBJzKFqoVXwnusUNhZL;

				private int eolRghqutZOOIGqvOFTzJOGfYTsn;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public tsaDQnsbjIpgaMaJyxVJOlyutlKB(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform => default(InputPlatform);

			internal override bool hasData => false;

			internal override bool disabled => false;

			internal override bool isAllowed => false;

			internal Axis[] Axes_orig => null;

			internal Button[] Buttons_orig => null;

			internal override IList<Platform> variants_base => null;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override Elements_Base elements_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				return null;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_Linux : Platform_Linux_Base
		{
			public Platform_Linux_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class Platform_WindowsUWP_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				[Serializable]
				public sealed class ElementCount : ElementCount_Base
				{
					public int hatCount;

					public override object DeepClone()
					{
						return null;
					}

					internal override void VYGHMqVLHaGfLwIBumGKxFdvXZWB(ElementCount_Base P_0)
					{
					}

					internal override bool eRcrgXtiJZnEILPhcaiUyTnAFTCn(BridgedControllerHWInfo P_0)
					{
						return false;
					}
				}

				public int hatCount;

				public ElementCount[] alternateElementCounts;

				public bool manufacturer_useRegex;

				public bool productName_useRegex;

				public string[] manufacturer;

				public string[] productName;

				public string[] productGUID;

				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override int alternateElementCount => 0;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					alternateMatched = default(bool);
					return false;
				}

				private bool AnyNameMatches(BridgedControllerHWInfo bridgedControllerHWInfo)
				{
					return false;
				}

				private bool NameMatches(string name, string[] names, bool useRegex)
				{
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public sealed class Elements : Elements_Base
			{
				private sealed class aqBegUEmScieGwFbSZTWsxtMSEenA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public Elements GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					public aqBegUEmScieGwFbSZTWsxtMSEenA(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					[DebuggerHidden]
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}
				}

				private sealed class FqUiLPGESIsfmaHxESrWGiZayiOV : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public Elements GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					public FqUiLPGESIsfmaHxESrWGiZayiOV(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					[DebuggerHidden]
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount => 0;

				public override int axisCount => 0;

				internal IEnumerable<Axis> Axes => null;

				internal IEnumerable<Button> Buttons => null;

				internal Axis GetAxis(int axisIndex)
				{
					return null;
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public abstract class Element : IDeepCloneable
			{
				public abstract object DeepClone();

				protected virtual void ImportVars(Element source)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
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

				public override object DeepClone()
				{
					return null;
				}

				protected override void ImportVars(Element source)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
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

				public override object DeepClone()
				{
					return null;
				}

				protected override void ImportVars(Element source)
				{
				}
			}

			private sealed class aNkwuxIUZDnLfKQTnZPWzpIzijdG : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_WindowsUWP_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int jgqarFEeHzMrAfFgGEVjBjOGiPSL;

				private int eolRghqutZOOIGqvOFTzJOGfYTsn;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public aNkwuxIUZDnLfKQTnZPWzpIzijdG(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class UDVRNnYAyoIKonNNHbQFdaNCMRnYA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_WindowsUWP_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int sgJTDKufSjBJzKFqoVXwnusUNhZL;

				private int eolRghqutZOOIGqvOFTzJOGfYTsn;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public UDVRNnYAyoIKonNNHbQFdaNCMRnYA(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform => default(InputPlatform);

			internal override bool hasData => false;

			internal override bool disabled => false;

			internal override bool isAllowed => false;

			internal Axis[] Axes_orig => null;

			internal Button[] Buttons_orig => null;

			internal override IList<Platform> variants_base => null;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override Elements_Base elements_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				return null;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_WindowsUWP : Platform_WindowsUWP_Base
		{
			public Platform_WindowsUWP_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class Platform_Fallback_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation]
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

				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override int alternateElementCount => 0;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					alternateMatched = default(bool);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public sealed class Elements : Elements_Base
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount => 0;

				public override int axisCount => 0;

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public class CustomCalculationSourceData : IDeepCloneable
			{
				public int sourceType;

				public int sourceElement;

				public AxisRange sourceAxisRange;

				public float deadzone;

				public bool invert;

				public object DeepClone()
				{
					return null;
				}
			}

			[Serializable]
			[CustomClassObfuscation]
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
				}
			}

			[Serializable]
			[CustomClassObfuscation]
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
					return null;
				}

				protected override void CopyVars(Element destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
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
					return null;
				}

				protected override void CopyVars(Element destination)
				{
				}
			}

			private sealed class tJUiSJDRMkVqKpkUhEDQcFSaEXacA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_Fallback_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public tJUiSJDRMkVqKpkUhEDQcFSaEXacA(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class oFZddFaSAThZKvDYJHIbQifhVKHTA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_Fallback_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public oFZddFaSAThZKvDYJHIbQifhVKHTA(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override InputPlatform platform => default(InputPlatform);

			internal Axis[] Axes_orig => null;

			internal Button[] Buttons_orig => null;

			internal override bool hasData => false;

			internal override bool disabled => false;

			internal override bool isAllowed => false;

			internal override Elements_Base elements_base => null;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				return null;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_Fallback : Platform_Fallback_Base
		{
			public Platform_Fallback_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public abstract class Platform_Custom : Platform
		{
			[Serializable]
			[CustomClassObfuscation]
			public abstract class MatchingCriteria : MatchingCriteria_Base
			{
				public bool alwaysMatch;

				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override int alternateElementCount => 0;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					alternateMatched = default(bool);
					return false;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public abstract class Elements : Elements_Base
			{
			}

			[Serializable]
			[CustomClassObfuscation]
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
					return null;
				}
			}

			[Serializable]
			[CustomClassObfuscation]
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
				}

				public abstract object DeepClone();
			}

			[Serializable]
			[CustomClassObfuscation]
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
				}
			}

			[Serializable]
			[CustomClassObfuscation]
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
		[CustomClassObfuscation]
		public class Platform_XboxOne_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount => 0;

				public override int axisCount => 0;

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Button : Platform_Custom.Button
			{
				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			private sealed class uBcHaEOdzehEPyshIYXfVJTXtxx : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_XboxOne_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public uBcHaEOdzehEPyshIYXfVJTXtxx(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class pkVXMyrKYGmMUyOTFdJbeIxRHItv : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_XboxOne_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public pkVXMyrKYGmMUyOTFdJbeIxRHItv(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override InputPlatform platform => default(InputPlatform);

			internal override Platform_Custom.Axis[] Axes => null;

			internal override Platform_Custom.Button[] Buttons => null;

			internal Axis[] Axes_orig => null;

			internal Button[] Buttons_orig => null;

			internal override bool hasData => false;

			internal override bool disabled => false;

			internal override bool isAllowed => false;

			internal override Elements_Base elements_base => null;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return null;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_XboxOne : Platform_XboxOne_Base
		{
			public Platform_XboxOne_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class Platform_PS4_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount => 0;

				public override int axisCount => 0;

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Button : Platform_Custom.Button
			{
				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			private sealed class IHQFBuQPYHMFxOSUNUJSSWxbSCQA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_PS4_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public IHQFBuQPYHMFxOSUNUJSSWxbSCQA(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class DtLOINhOuTNyuKOwhCLKRKCBgHwEA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_PS4_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public DtLOINhOuTNyuKOwhCLKRKCBgHwEA(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override InputPlatform platform => default(InputPlatform);

			internal override Platform_Custom.Axis[] Axes => null;

			internal override Platform_Custom.Button[] Buttons => null;

			internal Axis[] Axes_orig => null;

			internal Button[] Buttons_orig => null;

			internal override bool hasData => false;

			internal override bool disabled => false;

			internal override bool isAllowed => false;

			internal override Elements_Base elements_base => null;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return null;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_PS4 : Platform_PS4_Base
		{
			public Platform_PS4_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class Platform_NintendoSwitch_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount => 0;

				public override int axisCount => 0;

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Button : Platform_Custom.Button
			{
				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			private sealed class tkPfqiIFkxZQsogmdofMfQjwSIJf : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_NintendoSwitch_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public tkPfqiIFkxZQsogmdofMfQjwSIJf(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class pIaGVxqBXQNhOEbrXEuDHNOXwQCn : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_NintendoSwitch_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public pIaGVxqBXQNhOEbrXEuDHNOXwQCn(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override InputPlatform platform => default(InputPlatform);

			internal override Platform_Custom.Axis[] Axes => null;

			internal override Platform_Custom.Button[] Buttons => null;

			internal Axis[] Axes_orig => null;

			internal Button[] Buttons_orig => null;

			internal override bool hasData => false;

			internal override bool disabled => false;

			internal override bool isAllowed => false;

			internal override Elements_Base elements_base => null;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return null;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_NintendoSwitch : Platform_NintendoSwitch_Base
		{
			public Platform_NintendoSwitch_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class Platform_Stadia_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount => 0;

				public override int axisCount => 0;

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Button : Platform_Custom.Button
			{
				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			private sealed class WIiTAQJKjzrbvkeYgrdHcrErevmu : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_Stadia_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public WIiTAQJKjzrbvkeYgrdHcrErevmu(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class siMievNcfUhtWSIdUbHXCwqkOZDE : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_Stadia_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public siMievNcfUhtWSIdUbHXCwqkOZDE(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public string controllerName;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			public override string controllerNameOverride => null;

			internal override InputPlatform platform => default(InputPlatform);

			internal override Platform_Custom.Axis[] Axes => null;

			internal override Platform_Custom.Button[] Buttons => null;

			internal Axis[] Axes_orig => null;

			internal Button[] Buttons_orig => null;

			internal override bool hasData => false;

			internal override bool disabled => false;

			internal override bool isAllowed => false;

			internal override Elements_Base elements_base => null;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return null;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_Stadia : Platform_Stadia_Base
		{
			public Platform_Stadia_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class Platform_GameCore_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				public VidPid[] vidPid;

				public DeviceType deviceType;

				public GamepadSubType gamepadSubType;

				public int hatCount;

				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					alternateMatched = default(bool);
					return false;
				}

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}

				private bool HasProductName()
				{
					return false;
				}

				private bool ProductNameMatches(string name)
				{
					return false;
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount => 0;

				public override int axisCount => 0;

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Button : Platform_Custom.Button
			{
				public int sourceHat;

				public HatDirection sourceHatDirection;

				public HatType sourceHatType;

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public int sourceHat;

				public AxisDirection sourceHatDirection;

				public HatType sourceHatType;

				public AxisRange sourceHatRange;

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
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

			private sealed class FeOLvqwSZmSshwCxnRLdTXXgYQLH : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_GameCore_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public FeOLvqwSZmSshwCxnRLdTXXgYQLH(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class jmesvYwxQWKxeFIFWDTsdxHvPnUr : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_GameCore_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public jmesvYwxQWKxeFIFWDTsdxHvPnUr(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public string controllerName;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			public override string controllerNameOverride => null;

			internal override InputPlatform platform => default(InputPlatform);

			internal override Platform_Custom.Axis[] Axes => null;

			internal override Platform_Custom.Button[] Buttons => null;

			internal Axis[] Axes_orig => null;

			internal Button[] Buttons_orig => null;

			internal override bool hasData => false;

			internal override bool disabled => false;

			internal override bool isAllowed => false;

			internal override Elements_Base elements_base => null;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return null;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_GameCore : Platform_GameCore_Base
		{
			public Platform_GameCore_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}

			internal static Platform_GameCore CreateDefaultMap(BridgedControllerHWInfo bridgedController)
			{
				return null;
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class Platform_PS5_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount => 0;

				public override int axisCount => 0;

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Button : Platform_Custom.Button
			{
				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			private sealed class yRKMlTlmtAEyoypLkjrwEdOJqGsMA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_PS5_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public yRKMlTlmtAEyoypLkjrwEdOJqGsMA(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class lSneuKiEVXAqRerZhYpzWVPQXCee : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_PS5_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public lSneuKiEVXAqRerZhYpzWVPQXCee(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public string controllerName;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			public override string controllerNameOverride => null;

			internal override InputPlatform platform => default(InputPlatform);

			internal override Platform_Custom.Axis[] Axes => null;

			internal override Platform_Custom.Button[] Buttons => null;

			internal Axis[] Axes_orig => null;

			internal Button[] Buttons_orig => null;

			internal override bool hasData => false;

			internal override bool disabled => false;

			internal override bool isAllowed => false;

			internal override Elements_Base elements_base => null;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return null;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_PS5 : Platform_PS5_Base
		{
			public Platform_PS5_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class Platform_InternalDriver_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productName_useRegex;

				public string[] productName;

				public VidPid[] vidPid;

				public int hatCount;

				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					alternateMatched = default(bool);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}

				private bool ProductNameMatches(string name)
				{
					return false;
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount => 0;

				public override int axisCount => 0;

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Button : Platform_Custom.Button
			{
				public int sourceHat;

				public HatDirection sourceHatDirection;

				public HatType sourceHatType;

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public int sourceHat;

				public AxisDirection sourceHatDirection;

				public HatType sourceHatType;

				public AxisRange sourceHatRange;

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			private sealed class NJKldJRzgHNNTGEMTWocKsAJFqCK : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_InternalDriver_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public NJKldJRzgHNNTGEMTWocKsAJFqCK(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class mjlJYDLcyVNVKoslUmVTzzCbPIrl : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_InternalDriver_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public mjlJYDLcyVNVKoslUmVTzzCbPIrl(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override InputPlatform platform => default(InputPlatform);

			internal override Platform_Custom.Axis[] Axes => null;

			internal override Platform_Custom.Button[] Buttons => null;

			internal Axis[] Axes_orig => null;

			internal Button[] Buttons_orig => null;

			internal override bool hasData => false;

			internal override bool disabled => false;

			internal override bool isAllowed => false;

			internal override Elements_Base elements_base => null;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return null;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_InternalDriver : Platform_InternalDriver_Base
		{
			public Platform_InternalDriver_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class Platform_SDL2_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				[Serializable]
				public sealed class ElementCount : ElementCount_Base
				{
					public int hatCount;

					public override object DeepClone()
					{
						return null;
					}

					internal override void VYGHMqVLHaGfLwIBumGKxFdvXZWB(ElementCount_Base P_0)
					{
					}

					internal override bool eRcrgXtiJZnEILPhcaiUyTnAFTCn(BridgedControllerHWInfo P_0)
					{
						return false;
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

				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override int alternateElementCount => 0;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					alternateMatched = default(bool);
					return false;
				}

				private bool AnyNameMatches(BridgedControllerHWInfo bridgedControllerHWInfo)
				{
					return false;
				}

				private bool NameMatches(string name, string[] names, bool useRegex)
				{
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public sealed class Elements : Elements_Base
			{
				private sealed class mfhUyeBpgPPeYEbIpIvFDCcqJydH : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public Elements GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

					Axis IEnumerator<Axis>.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					public mfhUyeBpgPPeYEbIpIvFDCcqJydH(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					[DebuggerHidden]
					IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}
				}

				private sealed class qCnYnQuTuyHCUnxBPuknQeRrwyqC : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public Elements GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

					Button IEnumerator<Button>.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return null;
						}
					}

					[DebuggerHidden]
					public qCnYnQuTuyHCUnxBPuknQeRrwyqC(int P_0)
					{
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
					}

					private bool MoveNext()
					{
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
					}

					[DebuggerHidden]
					IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
					{
						return null;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return null;
					}
				}

				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount => 0;

				public override int axisCount => 0;

				internal IEnumerable<Axis> Axes => null;

				internal IEnumerable<Button> Buttons => null;

				internal Axis GetAxis(int axisIndex)
				{
					return null;
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public abstract class Element : IDeepCloneable
			{
				public abstract object DeepClone();

				protected virtual void ImportVars(Element source)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
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

				public override object DeepClone()
				{
					return null;
				}

				protected override void ImportVars(Element source)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
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

				public override object DeepClone()
				{
					return null;
				}

				protected override void ImportVars(Element source)
				{
				}
			}

			private sealed class gZfXhRjKtWkoCeguHkczoVatlkhp : IDisposable, IEnumerable, IEnumerator, IEnumerable<Axis>, IEnumerator<Axis>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_SDL2_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int jgqarFEeHzMrAfFgGEVjBjOGiPSL;

				private int eolRghqutZOOIGqvOFTzJOGfYTsn;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public gZfXhRjKtWkoCeguHkczoVatlkhp(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class yEABDLSfrjzxyfvCaCqFyYkJxtbb : IDisposable, IEnumerable, IEnumerator, IEnumerable<Button>, IEnumerator<Button>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_SDL2_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int sgJTDKufSjBJzKFqoVXwnusUNhZL;

				private int eolRghqutZOOIGqvOFTzJOGfYTsn;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public yEABDLSfrjzxyfvCaCqFyYkJxtbb(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			internal override InputPlatform platform => default(InputPlatform);

			internal override bool hasData => false;

			internal override bool disabled => false;

			internal override bool isAllowed => false;

			internal Axis[] Axes_orig => null;

			internal Button[] Buttons_orig => null;

			internal override IList<Platform> variants_base => null;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override Elements_Base elements_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			internal IEnumerable<Button> IterateButtons()
			{
				return null;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_SDL2 : Platform_SDL2_Base
		{
			public Platform_SDL2_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class Platform_Steam_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation]
			public sealed class MatchingCriteria : MatchingCriteria_Base
			{
				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override int alternateElementCount => 0;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				internal override ElementCount_Base GetAlternateElementCount(int index)
				{
					return null;
				}

				internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
				{
					alternateMatched = default(bool);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public sealed class Elements : Elements_Base
			{
				public override int buttonCount => 0;

				public override int axisCount => 0;

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override InputPlatform platform => default(InputPlatform);

			internal override bool hasData => false;

			internal override bool disabled => false;

			internal override bool isAllowed => false;

			internal override Elements_Base elements_base => null;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_Steam : Platform_Steam_Base
		{
			public Platform_Steam_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class Platform_WebGL_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation]
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
						return null;
					}
				}

				public bool productName_useRegex;

				public string[] productName;

				public string[] productGUID;

				public int[] mapping;

				public ElementCount_Base[] elementCount;

				public ClientInfo[] clientInfo;

				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				private static bool CheckBrowserVersion(int browser, string versionMin, string versionMax, string[] currentVersion)
				{
					return false;
				}

				private static bool CheckOSVersion(string versionMin, string versionMax, string[] currentVersion)
				{
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				public override int buttonCount => 0;

				public override int axisCount => 0;

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Button : Platform_Custom.Button
			{
				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			private sealed class CzfZUKEjETgtwCjMhNGrKxxoRLXe : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_WebGL_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public CzfZUKEjETgtwCjMhNGrKxxoRLXe(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class ZzuooBGuwdAlCVTAAZeuyZCpGvij : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_WebGL_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public ZzuooBGuwdAlCVTAAZeuyZCpGvij(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override InputPlatform platform => default(InputPlatform);

			internal override Platform_Custom.Axis[] Axes => null;

			internal override Platform_Custom.Button[] Buttons => null;

			internal Axis[] Axes_orig => null;

			internal Button[] Buttons_orig => null;

			internal override bool hasData => false;

			internal override bool disabled => false;

			internal override bool isAllowed => false;

			internal override Elements_Base elements_base => null;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return null;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_WebGL : Platform_WebGL_Base
		{
			public Platform_WebGL_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public class Platform_AppleGCController_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation]
			public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
			{
				public bool productCategory_useRegex;

				public string[] productCategory;

				public AppleGCControllerProfileTypeFlags primaryProfileType;

				public AppleGCControllerProfileSubType[] profileSubTypes;

				internal override bool hasData => false;

				internal override bool isAllowed => false;

				internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
				{
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(MatchingCriteria_Base destination)
				{
				}

				private bool HasProductCategory()
				{
					return false;
				}

				private bool ProductCategoryMatches(string name)
				{
					return false;
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Elements : Platform_Custom.Elements
			{
				public Axis[] axes;

				public Button[] buttons;

				public CompoundElement[] compoundElements;

				public override int buttonCount => 0;

				public override int axisCount => 0;

				public int compoundElementCount => 0;

				internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
				{
					return default(ControllerElementType);
				}

				internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
				{
					axisRange = default(AxisRange);
					return false;
				}

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Elements_Base destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Button : Platform_Custom.Button
			{
				public AppleGCControllerElementIdentifier sourceElementId;

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public new sealed class Axis : Platform_Custom.Axis
			{
				public AppleGCControllerElementIdentifier sourceElementId;

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			[Serializable]
			[CustomClassObfuscation]
			public sealed class CompoundElement : IDeepCloneable
			{
				public int elementIdentifier;

				public int sourceElementIndex;

				public AppleGCControllerElementIdentifierCompoundElements sourceElementId;

				internal void CopyVars(CompoundElement destination)
				{
				}

				public object DeepClone()
				{
					return null;
				}
			}

			public enum AppleGCControllerProfileTypeFlags
			{
				None = 0,
				Generic = 1,
				ExtendedGamepad = 2,
				MicroGamepad = 4,
				Unknown = int.MinValue
			}

			public enum AppleGCControllerProfileSubType
			{
				None = 0,
				Xbox = 1,
				DualShock = 2,
				DualSense = 3,
				Unknown = -1
			}

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

			public enum AppleGCControllerElementIdentifierCompoundElements
			{
				None = 0,
				IndexedStick = 31,
				IndexedDPad = 32,
				LeftStick = 33,
				RightStick = 34,
				DPad = 35
			}

			[CustomObfuscation]
			internal enum AppleGCControllerElementIdentifierAxes
			{
				[CustomObfuscation]
				None = 0,
				[CustomObfuscation]
				LeftStickX = 16,
				[CustomObfuscation]
				LeftStickY = 17,
				[CustomObfuscation]
				RightStickX = 18,
				[CustomObfuscation]
				RightStickY = 19,
				[CustomObfuscation]
				DPadVertical = 22,
				[CustomObfuscation]
				DPadHorizontal = 23,
				[CustomObfuscation]
				IndexedAxis = 30
			}

			[CustomObfuscation]
			internal enum AppleGCControllerElementIdentifierButtons
			{
				[CustomObfuscation]
				None = 0,
				[CustomObfuscation]
				A = 1,
				[CustomObfuscation]
				B = 2,
				[CustomObfuscation]
				X = 3,
				[CustomObfuscation]
				Y = 4,
				[CustomObfuscation]
				LeftShoulder = 5,
				[CustomObfuscation]
				RightShoulder = 6,
				[CustomObfuscation]
				Menu = 7,
				[CustomObfuscation]
				Options = 8,
				[CustomObfuscation]
				Home = 9,
				[CustomObfuscation]
				LeftStickButton = 10,
				[CustomObfuscation]
				RightStickButton = 11,
				[CustomObfuscation]
				DPadUp = 12,
				[CustomObfuscation]
				DPadRight = 13,
				[CustomObfuscation]
				DPadDown = 14,
				[CustomObfuscation]
				DPadLeft = 15,
				[CustomObfuscation]
				LeftTrigger = 20,
				[CustomObfuscation]
				RightTrigger = 21,
				[CustomObfuscation]
				TouchpadButton = 24,
				[CustomObfuscation]
				Paddle1 = 25,
				[CustomObfuscation]
				Paddle2 = 26,
				[CustomObfuscation]
				Paddle3 = 27,
				[CustomObfuscation]
				Paddle4 = 28,
				[CustomObfuscation]
				IndexedButton = 29
			}

			private sealed class HrKzosBdRAAGSEZuotZwDKcMERZcA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Axis>, IEnumerator<Platform_Custom.Axis>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Axis USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_AppleGCController_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public HrKzosBdRAAGSEZuotZwDKcMERZcA(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class uwiCbpgXgZujvfvDEGlsloJlRJIeA : IDisposable, IEnumerable, IEnumerator, IEnumerable<Platform_Custom.Button>, IEnumerator<Platform_Custom.Button>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private Platform_Custom.Button USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public Platform_AppleGCController_Base GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

				Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public uwiCbpgXgZujvfvDEGlsloJlRJIeA(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			public MatchingCriteria matchingCriteria;

			public Elements elements;

			public string controllerName;

			private Platform_Custom.Axis[] _axesOrigGame;

			private Platform_Custom.Button[] _buttonsOrigGame;

			private CompoundElement[] _compoundElementsOrigGame;

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			public override string controllerNameOverride => null;

			internal override InputPlatform platform => default(InputPlatform);

			internal override Platform_Custom.Axis[] Axes => null;

			internal override Platform_Custom.Button[] Buttons => null;

			internal CompoundElement[] CompoundElements => null;

			internal Axis[] Axes_orig => null;

			internal Button[] Buttons_orig => null;

			internal CompoundElement[] CompoundElements_orig => null;

			internal override bool hasData => false;

			internal override bool disabled => false;

			internal override bool isAllowed => false;

			internal override Elements_Base elements_base => null;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
			{
				return null;
			}

			internal override string[] GetAxisNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override string[] GetEffectiveButtonNames(ControllerElementIdentifier[] identifiers)
			{
				return null;
			}

			internal override bool IsElementIdentifierMapped(int elementIdentifierId)
			{
				return false;
			}

			internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
			{
				buttons = null;
				axes = null;
			}

			internal override AxisCalibrationData[] GetAxisCalibrationData()
			{
				return null;
			}

			internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
			{
				axisRanges = null;
				axisInfos = null;
			}

			internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
			{
				buttonInfos = null;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return default(ControllerElementType);
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = default(AxisRange);
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		public sealed class Platform_AppleGCController : Platform_AppleGCController_Base
		{
			public Platform_AppleGCController_Base[] variants;

			internal override IList<Platform> variants_base => null;

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(Platform destination)
			{
			}

			internal static Platform_AppleGCController CreateDefaultMap(BridgedControllerHWInfo bridgedController)
			{
				return null;
			}
		}

		private sealed class GmhTiAOnwCgbVDDwwNPaErpeFNSAB : IDisposable, IEnumerable, IEnumerator, IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerator<IControllerElementIdentifierCommon_Internal>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private IControllerElementIdentifierCommon_Internal USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public HardwareJoystickMap GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public GmhTiAOnwCgbVDDwwNPaErpeFNSAB(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<IControllerElementIdentifierCommon_Internal> IEnumerable<IControllerElementIdentifierCommon_Internal>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private sealed class GJywxSaStHIjBMeUnMirLUzvCMn : IDisposable, IEnumerable, IEnumerator, IEnumerable<ControllerElementIdentifier>, IEnumerator<ControllerElementIdentifier>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ControllerElementIdentifier USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public HardwareJoystickMap GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

			ControllerElementIdentifier IEnumerator<ControllerElementIdentifier>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public GJywxSaStHIjBMeUnMirLUzvCMn(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<ControllerElementIdentifier> IEnumerable<ControllerElementIdentifier>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private sealed class xqJAmEzzRiLvdWsOEcoAbbqBiPZTA : IDisposable, IEnumerable, IEnumerator, IEnumerable<JoystickType>, IEnumerator<JoystickType>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private JoystickType USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public HardwareJoystickMap GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

			JoystickType IEnumerator<JoystickType>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(JoystickType);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public xqJAmEzzRiLvdWsOEcoAbbqBiPZTA(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<JoystickType> IEnumerable<JoystickType>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private sealed class XUdyqwYNJOIOTIrraMpiANuesIas : IDisposable, IEnumerable, IEnumerator, IEnumerable<Guid>, IEnumerator<Guid>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private Guid USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public HardwareJoystickMap GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

			Guid IEnumerator<Guid>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(Guid);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public XUdyqwYNJOIOTIrraMpiANuesIas(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<Guid> IEnumerable<Guid>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CustomObfuscation]
		[SerializeField]
		private string controllerName;

		[SerializeField]
		[CustomObfuscation]
		private string editorControllerName;

		[CustomObfuscation]
		[SerializeField]
		private string description;

		[CustomObfuscation]
		[SerializeField]
		private string controllerGuid;

		[CustomObfuscation]
		[SerializeField]
		private string[] templateGuids;

		[CustomObfuscation]
		[SerializeField]
		private bool hideInLists;

		[SerializeField]
		[CustomObfuscation]
		private JoystickType[] joystickTypes;

		[CustomObfuscation]
		[SerializeField]
		private ControllerElementIdentifier[] elementIdentifiers;

		[SerializeField]
		[CustomObfuscation]
		private CompoundElement[] compoundElements;

		[CustomObfuscation]
		[SerializeField]
		private Platform_DirectInput directInput;

		[SerializeField]
		[CustomObfuscation]
		private Platform_RawInput rawInput;

		[SerializeField]
		[CustomObfuscation]
		private Platform_XInput xInput;

		[SerializeField]
		[CustomObfuscation]
		private Platform_OSX osx;

		[CustomObfuscation]
		[SerializeField]
		private Platform_Linux linux;

		[SerializeField]
		[CustomObfuscation]
		private Platform_WindowsUWP windowsUWP;

		[CustomObfuscation]
		[SerializeField]
		private Platform_Fallback fallback_Windows;

		[CustomObfuscation]
		[SerializeField]
		private Platform_Fallback fallback_WindowsUWP;

		[CustomObfuscation]
		[SerializeField]
		private Platform_Fallback fallback_OSX;

		[SerializeField]
		[CustomObfuscation]
		private Platform_Fallback fallback_Linux;

		[CustomObfuscation]
		[SerializeField]
		private Platform_Fallback fallback_Linux_PreConfigured;

		[SerializeField]
		[CustomObfuscation]
		private Platform_Fallback fallback_Android;

		[CustomObfuscation]
		[SerializeField]
		private Platform_Fallback fallback_iOS;

		[SerializeField]
		[CustomObfuscation]
		private Platform_Fallback fallback_XBoxOne;

		[SerializeField]
		[CustomObfuscation]
		private Platform_Fallback fallback_PS4;

		[CustomObfuscation]
		[SerializeField]
		private Platform_PS5 ps5;

		[CustomObfuscation]
		[SerializeField]
		private Platform_Fallback fallback_PSM;

		[CustomObfuscation]
		[SerializeField]
		private Platform_Fallback fallback_PSVita;

		[SerializeField]
		[CustomObfuscation]
		private Platform_Fallback fallback_AmazonFireTV;

		[SerializeField]
		[CustomObfuscation]
		private Platform_WebGL webGL;

		[SerializeField]
		[CustomObfuscation]
		private Platform_XboxOne xboxOne;

		[CustomObfuscation]
		[SerializeField]
		private Platform_GameCore gameCore;

		[CustomObfuscation]
		[SerializeField]
		private Platform_PS4 ps4;

		[CustomObfuscation]
		[SerializeField]
		private Platform_NintendoSwitch nintendoSwitch;

		[SerializeField]
		[CustomObfuscation]
		private Platform_Stadia stadia;

		[SerializeField]
		[CustomObfuscation]
		private Platform_InternalDriver internalDriver;

		[SerializeField]
		[CustomObfuscation]
		private Platform_SDL2 sdl2_Linux;

		[SerializeField]
		[CustomObfuscation]
		private Platform_SDL2 sdl2_Windows;

		[SerializeField]
		[CustomObfuscation]
		private Platform_SDL2 sdl2_OSX;

		[CustomObfuscation]
		[SerializeField]
		private Platform_AppleGCController appleGCController;

		[SerializeField]
		[CustomObfuscation]
		private int elementIdentifierIdCounter;

		public string ControllerName => null;

		public string EditorControllerName => null;

		public Guid Guid => default(Guid);

		public IEnumerable<Guid> TemplateGuids => null;

		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers => null;

		public int elementIdentifierCount => 0;

		public bool HideInLists => false;

		internal IEnumerable<JoystickType> JoystickTypes => null;

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers => null;

		public HardwareJoystickMap()
		{
		}

		public HardwareJoystickMap(HardwareJoystickMap P_0)
		{
		}

		[CustomObfuscation]
		public string[] GetElementIdentifierNames()
		{
			return null;
		}

		[CustomObfuscation]
		public int[] GetElementIdentifierIds()
		{
			return null;
		}

		[CustomObfuscation]
		public ControllerElementIdentifier GetElementIdentifier(int id)
		{
			return null;
		}

		[CustomObfuscation]
		public bool ContainsElementIdentifier(int id)
		{
			return false;
		}

		[CustomObfuscation]
		public int GetElementIdentifierInfo(ControllerElementType type, out string[] names, out int[] ids)
		{
			names = null;
			ids = null;
			return 0;
		}

		[CustomObfuscation]
		public int GetMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			names = null;
			ids = null;
			return 0;
		}

		internal HardwareJoystickMap Clone()
		{
			return null;
		}

		internal int IndexOfElementIdentifier(int id)
		{
			return 0;
		}

		internal ControllerElementType GetEffectiveElementIdentifierType(HardwareControllerMapIdentifier hardwareMapIdentifier, int elementIdentifierId, bool isDefaultMap)
		{
			return default(ControllerElementType);
		}

		internal bool GetEffectiveAxisRange(HardwareControllerMapIdentifier hardwareMapIdentifier, int elementIdentifierId, bool isDefaultMap, out AxisRange axisRange)
		{
			axisRange = default(AxisRange);
			return false;
		}

		internal void GetElementIdentifiersForControllerElements(HardwareControllerMapIdentifier hardwareMapIdentifier, bool isDefaultMap, out int[] buttons, out int[] axes)
		{
			buttons = null;
			axes = null;
		}

		internal static bool Matches(Platform platform, BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = default(int);
			platformMap = null;
			return false;
		}

		internal bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex, out Platform platformMap)
		{
			actualInputPlatform = default(InputPlatform);
			variantIndex = default(int);
			platformMap = null;
			return false;
		}

		internal HardwareJoystickMap_InputManager GetDefaultHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return null;
		}

		internal string[] GetTemplateGuidsOrig()
		{
			return null;
		}

		IControllerElementIdentifierCommon_Internal IHardwareControllerMap_Internal.GetElementIdentifier(int id)
		{
			return null;
		}

		private Platform_Fallback_Base FindFallbackMatch(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			actualInputPlatform = default(InputPlatform);
			variantIndex = default(int);
			return null;
		}

		private Platform_Fallback_Base FindFallbackMap(InputSource inputSource, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			actualInputPlatform = default(InputPlatform);
			variantIndex = default(int);
			return null;
		}

		private Platform_SDL2_Base FindSDL2Match(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			actualInputPlatform = default(InputPlatform);
			variantIndex = default(int);
			return null;
		}

		private Platform_SDL2_Base FindSDL2Map(InputSource inputSource, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
		{
			actualInputPlatform = default(InputPlatform);
			variantIndex = default(int);
			return null;
		}

		private T TryGetFirstValidMap<T>(T mainMap, bool isDefaultMap, ref InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
		{
			variantIndex = default(int);
			return null;
		}

		private T TryGetFirstMatchingMap<T>(T mainMap, BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, ref InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
		{
			variantIndex = default(int);
			return null;
		}

		private T GetUniversalDefaultMap<T>(out InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
		{
			actualInputPlatform = default(InputPlatform);
			variantIndex = default(int);
			return null;
		}

		private T GetUniversalDefaultMapRoot<T>(Type type, out InputPlatform actualInputPlatform) where T : Platform
		{
			actualInputPlatform = default(InputPlatform);
			return null;
		}

		private Platform GetSpecificPlatformMap(HardwareControllerMapIdentifier hardwareMapIdentifier)
		{
			return null;
		}

		private Platform GetSpecificPlatformRoot(InputPlatform exactInputPlatform)
		{
			return null;
		}
	}
}
