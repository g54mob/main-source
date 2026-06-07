using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Interfaces;
using Rewired.Platforms;
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
			private sealed class BgaTzHFFxCCpDTrmtIoNpLlejObJ : IEnumerable<Platform>, IEnumerable, IEnumerator<Platform>, IEnumerator, IDisposable
			{
				private int IlYfXmhECcpSkbqCdxzhsSYwPrwuA;

				private Platform vuwhwwEKJTqWNFzhQPwBFghWywpt;

				private int vsEEmsbSCkTJPPsYyOSCEBBDfoNFB;

				public Platform OrrToCSfkcjnRHgZrnCcnkHpaLut;

				private IList<Platform> PKKLBHhQzXUpdhEdtqvbnezMPQwE;

				private int MjeRANVszPydRDiEFAAyDYWOTUHe;

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
				public BgaTzHFFxCCpDTrmtIoNpLlejObJ(int P_0)
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

			[Tooltip("A description of this platform map. For reference only.")]
			public string description;

			internal abstract InputPlatform platform { get; }

			public abstract int assignedButtonCount { get; }

			public abstract int assignedAxisCount { get; }

			public virtual string controllerNameOverride => null;

			internal abstract Elements_Base elements_base { get; }

			internal virtual bool isAllowed => false;

			internal abstract bool hasData { get; }

			internal abstract bool disabled { get; }

			internal IEnumerable<Platform> Variants
			{
				[IteratorStateMachine(typeof(BgaTzHFFxCCpDTrmtIoNpLlejObJ))]
				get
				{
					return null;
				}
			}

			internal bool hasVariants => false;

			[CustomObfuscation(rename = false)]
			internal int variantCount => 0;

			internal bool selfOrVariantHasData => false;

			internal bool selfOrVariantIsValid => false;

			internal bool selfOrVariantIsAllowed => false;

			internal abstract bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap);

			internal abstract void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes);

			internal abstract bool IsElementIdentifierMapped(int elementIdentifierId);

			public abstract IList<Platform> GetVariants();

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
					return null;
				}

				internal virtual void exBiBCZBWBkkeuUFjcGutHOztZju(ElementCount_Base P_0)
				{
				}

				internal virtual bool LoKzWPLloLQZPPKaXCGMladHLcLr(BridgedControllerHWInfo P_0)
				{
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
						return null;
					}

					internal override void exBiBCZBWBkkeuUFjcGutHOztZju(ElementCount_Base P_0)
					{
					}

					internal override bool LoKzWPLloLQZPPKaXCGMladHLcLr(BridgedControllerHWInfo P_0)
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
					return null;
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
				}

				protected void ImportVars(Button_Base source)
				{
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_DirectInput_Base : Platform_RawOrDirectInput
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Platform_Base
			{
				private sealed class sJPFqYaoQARtgggodjQHHiDwoCnRA : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int fQcxrvhPSiCkijufFmWLyDCseXetA;

					private Axis_Base LfhxklKNnarYCHvJajaEJZwwUTfJ;

					private int HgqOXHxashrNIHdAoottXcMtZhxq;

					public Elements rWceUrFeKvPaghnTukNlZLjmWdTM;

					private int AIONjFrIZMUQTjUnbFfjOXBGiGWi;

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
					public sJPFqYaoQARtgggodjQHHiDwoCnRA(int P_0)
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

				private sealed class bFdmQxknbcdmLrqelFGPVGJWAgEx : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int bfgAsMTALeCzFBjvjBWdHtKdCBPH;

					private Button_Base BloHebceZeUbjoSzJKPIFRQplPlS;

					private int VsWdQQMEjSokpupUOuOJMDAXFJwj;

					public Elements nIaylXJvtKeoaBEhcBzqcDruLtcYA;

					private int FugZPcAauLRpBmgPsAXqggzrAvfcA;

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
					public bFdmQxknbcdmLrqelFGPVGJWAgEx(int P_0)
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

				internal override IEnumerable<Axis_Base> Axes
				{
					[IteratorStateMachine(typeof(sJPFqYaoQARtgggodjQHHiDwoCnRA))]
					get
					{
						return null;
					}
				}

				internal override IEnumerable<Button_Base> Buttons
				{
					[IteratorStateMachine(typeof(bFdmQxknbcdmLrqelFGPVGJWAgEx))]
					get
					{
						return null;
					}
				}

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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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

			private sealed class WkGBOiwkOcdqqQlvAWSvkyCkrycB : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int AMfNbwyaPoIpVNrUhTqywmgHhUnx;

				private Axis_Base iIqsBWTfyvwgQyRlPNijOtcYMFUn;

				private int RZWPjMSqCckMyPoZCKhNxasKvZPr;

				public Platform_DirectInput_Base jwXCCBjINWzaLtpjFITnbiwyRAoj;

				private int afppMPPNnjQMLODonjowGUoruEyOA;

				private int xUDAaNbfjlMhYUpnYzRCqDPsNSyIA;

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
				public WkGBOiwkOcdqqQlvAWSvkyCkrycB(int P_0)
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

			private sealed class nsmnUrCHEfRovuyimMaCYuUSPYOU : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int NXqmlUqutCDkdnmjFfxpygiswCmW;

				private Button_Base GDkUbVfxUgOOQzanQYFhPmClQVO;

				private int PjkxBzBGhlWuAjnDFWqAwsJrIVgt;

				public Platform_DirectInput_Base fCMfeDFtBtxsWDNtmtGdWykotrwLA;

				private int oqwlxQHeoGERVZYuXbIiNPEjnNqM;

				private int sovCxAZoUSzvaFiRuInAkHHXekXL;

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
				public nsmnUrCHEfRovuyimMaCYuUSPYOU(int P_0)
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

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override Elements_Base elements_base => null;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
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

			[IteratorStateMachine(typeof(WkGBOiwkOcdqqQlvAWSvkyCkrycB))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(nsmnUrCHEfRovuyimMaCYuUSPYOU))]
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_DirectInput : Platform_DirectInput_Base
		{
			public Platform_DirectInput_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_RawInput_Base : Platform_RawOrDirectInput
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Platform_Base
			{
				private sealed class TcWTVasrDupOTxyXOKmSlJcpDpUK : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int ufjYaGsJfecDlxeJUoiYVliTVQSi;

					private Axis_Base dOLkechreUyaQKlepaCSAscWiZMoA;

					private int RYfLSqgUuPxmgjJDhXnHVuKSIBvK;

					public Elements zaJDJManBFJoZXdJvmsFiDBUckulA;

					private int rYZAAdhADHLQYOFrCzZXkjrhtIJlA;

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
					public TcWTVasrDupOTxyXOKmSlJcpDpUK(int P_0)
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

				private sealed class eziYOFFSZvgFtUnpCEJWcSHEtWBH : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int xxcAPVFuvbAifUBECjGKVuqtNfoAA;

					private Button_Base ZeaUODZCaPxvGpgKMzkXJWorRBVf;

					private int OxsCNONNNXzhknmPTjiGMQNKoGLG;

					public Elements EVyKmFNYoiMwobOTvVTOHmpJNIQl;

					private int gSLfEQoflkhtaNQLbfEDOjSUZHcd;

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
					public eziYOFFSZvgFtUnpCEJWcSHEtWBH(int P_0)
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

				internal override IEnumerable<Axis_Base> Axes
				{
					[IteratorStateMachine(typeof(TcWTVasrDupOTxyXOKmSlJcpDpUK))]
					get
					{
						return null;
					}
				}

				internal override IEnumerable<Button_Base> Buttons
				{
					[IteratorStateMachine(typeof(eziYOFFSZvgFtUnpCEJWcSHEtWBH))]
					get
					{
						return null;
					}
				}

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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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

			private sealed class JVdMrnlTAlgPSjmCDXKCGwJMskQA : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int ZpNSntOxckHsCjRuKebDcveuTChT;

				private Axis_Base XruhjdvIPFJFxsiNBrMgDMogdBmAA;

				private int BDtCmBgYCJxskUPBkSJCpfMcTHDoA;

				public Platform_RawInput_Base VtxseFhivYFOryFVuihywJWzWanl;

				private int SBxbmydGuozQHBcyjbIdhwnDPKhYb;

				private int qMnqXQmCRtpmSteAihPugfTbZmAl;

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
				public JVdMrnlTAlgPSjmCDXKCGwJMskQA(int P_0)
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

			private sealed class NBPKxgCvWyBnrPwWfkRSBkZzzgEn : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int zmiJkSPyoMtZJONwEhOJouipNCTJ;

				private Button_Base XwCGBTdLOsWbRdGvNzfgiYQpLjoo;

				private int wiLGXoxTvmAQkWfvwdNVupoQCgHGA;

				public Platform_RawInput_Base lcgAckClwiBuZcujMRrSUesIwrgr;

				private int CFXDklgAcogmnvthKmZQkIpZCuXPA;

				private int QvAhTdAuPDfELdeVCtHkifxQKGZBc;

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
				public NBPKxgCvWyBnrPwWfkRSBkZzzgEn(int P_0)
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

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override Elements_Base elements_base => null;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
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

			[IteratorStateMachine(typeof(JVdMrnlTAlgPSjmCDXKCGwJMskQA))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(NBPKxgCvWyBnrPwWfkRSBkZzzgEn))]
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_RawInput : Platform_RawInput_Base
		{
			public Platform_RawInput_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_XInput_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
				}
			}

			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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

				public override object DeepClone()
				{
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			private sealed class kaKgOCFYbVLraBOZbZBAdhXbLZuP : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int IBvZkEYkZWFRzBSjBrzSfIfDpHwuA;

				private Axis WQDcPtgXMNBpJbCTaVeLSfKTWpDyA;

				private int nvAvfVJCcnhwfcXHxhDHjOdspouo;

				public Platform_XInput_Base FwIoszTgYRLTaVDNgIGWwVpMPcMD;

				private int pWdQmRFfptmziCAFuzXDMVeADiqy;

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
				public kaKgOCFYbVLraBOZbZBAdhXbLZuP(int P_0)
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

			private sealed class OAdktSvIfBmaeuOgmWRzYKJvkmTo : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int MTmFlmYFWDqIkqvCTpUdUDJGcmAT;

				private Button FwrDNynyUYDxkXeAssJWloZQdjny;

				private int GxDadkitxUhaPBkBUldBoBeMOYtUA;

				public Platform_XInput_Base IppBiwHqyLoeBuzKxhGuZAPpYQYU;

				private int NqNiVnseRpgTtTKynTcOWFUyLhzy;

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
				public OAdktSvIfBmaeuOgmWRzYKJvkmTo(int P_0)
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

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			[IteratorStateMachine(typeof(kaKgOCFYbVLraBOZbZBAdhXbLZuP))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(OAdktSvIfBmaeuOgmWRzYKJvkmTo))]
			internal IEnumerable<Button> IterateButtons()
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_XInput : Platform_XInput_Base
		{
			public Platform_XInput_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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
						return null;
					}

					internal override void exBiBCZBWBkkeuUFjcGutHOztZju(ElementCount_Base P_0)
					{
					}

					internal override bool LoKzWPLloLQZPPKaXCGMladHLcLr(BridgedControllerHWInfo P_0)
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class BlaDeSDxwyzYENKhVZDNyxQaxbhx : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int jrIFRlsCloGJbiOPKDWGVRctAMgIb;

					private Axis gRyzhoXymUNKhwCejfyJoHPXJZzj;

					private int hcCMyIvOxAHddYVIQltOGROLizPB;

					public Elements NVrJJuePkwaqdHHiNqhcFsfATDBaB;

					private Axis[] soogYIvVuPpKVppOfIKcgknVgIvHb;

					private int jeSTBFYDlTtXzDynLVQicIxYfuPgA;

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
					public BlaDeSDxwyzYENKhVZDNyxQaxbhx(int P_0)
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

				private sealed class erktgmcoKHNylEiMYJHHiEQRgczx : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int lJEvnuHyFvPGqIBFkkYdmKpRMgFd;

					private Button UjRMCiVFwSERMSTbuqiEGhlJbLLY;

					private int tPdsIJJNIwzCXFfYzjtEwKOYFQwV;

					public Elements unmamYmfAGaBSoHGPnvMSBatzRMA;

					private Button[] FAoCZxekBmDoXBYJCOOFYeAubXqY;

					private int gAhEWnadgUAwnPWnOzlmeelZRNpwA;

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
					public erktgmcoKHNylEiMYJHHiEQRgczx(int P_0)
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

				[IteratorStateMachine(typeof(BlaDeSDxwyzYENKhVZDNyxQaxbhx))]
				public IEnumerable<Axis> IterateAxes()
				{
					return null;
				}

				[IteratorStateMachine(typeof(erktgmcoKHNylEiMYJHHiEQRgczx))]
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

				public override object DeepClone()
				{
					return null;
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

				public override object DeepClone()
				{
					return null;
				}
			}

			private sealed class tykPBOPCwceYpkfWLBDzmcnvuVHJ : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int mYBYVhKJOZDZSaQfMjJNNQdiExeF;

				private Axis QigMyFULmOFQGbWfimsDdEudtiuW;

				private int xBvLIrLlniLuiQQGjxIQTkCCHCTi;

				public Platform_OSX_Base EySSYHboMdqssRrZgHeDtsZRITGD;

				private int CwDsZAZDzwLcQxlgKguBcUayaLSHb;

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
				public tykPBOPCwceYpkfWLBDzmcnvuVHJ(int P_0)
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

			private sealed class rHhaFXAUIHjbuDatyiFpdlXBqIVzB : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int DnfvHhwFwVvfOjPoEwcOJEGTlVDW;

				private Button iTYKvoJJovZjSczcGfYeYCeRiXNR;

				private int MMdEGQHGGqUYGiHCsIQKpdZXpuwLA;

				public Platform_OSX_Base dfhiCMADXjVHFqCnaSHxYRCUejKO;

				private int JKJMnwqIDvbpOdAvyJaphHBYrcfib;

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
				public rHhaFXAUIHjbuDatyiFpdlXBqIVzB(int P_0)
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

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			[IteratorStateMachine(typeof(tykPBOPCwceYpkfWLBDzmcnvuVHJ))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(rHhaFXAUIHjbuDatyiFpdlXBqIVzB))]
			internal IEnumerable<Button> IterateButtons()
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_OSX : Platform_OSX_Base
		{
			public Platform_OSX_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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
						return null;
					}

					internal override void exBiBCZBWBkkeuUFjcGutHOztZju(ElementCount_Base P_0)
					{
					}

					internal override bool LoKzWPLloLQZPPKaXCGMladHLcLr(BridgedControllerHWInfo P_0)
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class PpYTTnnvfFDeXIACWgEbFcfDFZUAA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int RaGaLEbNdosyBhvJHpGKPfcyrCJtA;

					private Axis TyGBxxTLytiRwuOVcVqToUDggfxk;

					private int bkITYtKFyXScuGGbLAeZegivhiCjA;

					public Elements StDAFTjjjVNLXHtVydnSDoOKQIXVb;

					private int ixRoOqRxHSvydRkcNjAGUESwVDGd;

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
					public PpYTTnnvfFDeXIACWgEbFcfDFZUAA(int P_0)
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

				private sealed class iLrzFdtikWKVGQtMzReBwgVAfLnQ : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int SrrhgRRTYzJVOQYDtHNZFMCVapbw;

					private Button bBFdjILaVhDcIdPtqWbDRDoLqHMHb;

					private int HtgoMIFQlvPoxhuOXbBKLaoVnVBJ;

					public Elements xmpGYSWshGDdmFposmfIhKDHVxUab;

					private int RoYhZmhQdxpdFhhaFKMDQhsTzwXg;

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
					public iLrzFdtikWKVGQtMzReBwgVAfLnQ(int P_0)
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

				internal IEnumerable<Axis> Axes
				{
					[IteratorStateMachine(typeof(PpYTTnnvfFDeXIACWgEbFcfDFZUAA))]
					get
					{
						return null;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(iLrzFdtikWKVGQtMzReBwgVAfLnQ))]
					get
					{
						return null;
					}
				}

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

				public override object DeepClone()
				{
					return null;
				}

				protected override void ImportVars(Element source)
				{
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

				public override object DeepClone()
				{
					return null;
				}

				protected override void ImportVars(Element source)
				{
				}
			}

			private sealed class QGwSjeBYpRxrTOGAtjpBgQaSkjmj : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int dmCxdhYvTTaxfqBaqMxknjEZtpII;

				private Axis FTmeJXkQijyhvBhHdZVQBJUwDmJR;

				private int clDEUEEhprfxxWXITCnYukrLqLpS;

				public Platform_Linux_Base botzevJfaULrNmwBFnDgTNgTzHAy;

				private int vheLfAEDldMkMYzcslzDtBVUUfEn;

				private int hembSJhakdUUclUuDNuXGopXtlgW;

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
				public QGwSjeBYpRxrTOGAtjpBgQaSkjmj(int P_0)
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

			private sealed class WApFnqonCXrzaxvbrhKTGecOhepN : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int ijKdeObZCzxFDerHvvzErkaiSliTA;

				private Button iEYZxHEDHpyJjDxremiwaAfwmfy;

				private int vlibVitssSSPJsySWISvsDhckttn;

				public Platform_Linux_Base KjqoxDngwjftHqCjczPmKYCncfZK;

				private int YPtLkAHNcHNIFuWnekPzNiJeCYwo;

				private int TUwdPDfVKpkDBnJYuYkjhEJqqWbFb;

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
				public WApFnqonCXrzaxvbrhKTGecOhepN(int P_0)
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

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override Elements_Base elements_base => null;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
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

			[IteratorStateMachine(typeof(QGwSjeBYpRxrTOGAtjpBgQaSkjmj))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(WApFnqonCXrzaxvbrhKTGecOhepN))]
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_Linux : Platform_Linux_Base
		{
			public Platform_Linux_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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
						return null;
					}

					internal override void exBiBCZBWBkkeuUFjcGutHOztZju(ElementCount_Base P_0)
					{
					}

					internal override bool LoKzWPLloLQZPPKaXCGMladHLcLr(BridgedControllerHWInfo P_0)
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

				private bool AnyNameMatches(BridgedControllerHWInfo bridgedControllerHWInfo)
				{
					return false;
				}

				private bool NameMatches(string name, string[] names, bool useRegex)
				{
					return false;
				}

				private bool HasProductName()
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class KDvmVyxcEniRRArjIeALGfsahvXSA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int JlskzvhVxQkyaPTbPtRgiEfBMqUl;

					private Axis MFIzGgGuKrguyMpHuktZgggTzBdk;

					private int DJFEpQctDjIyiTTpFNpJBPwahFQPb;

					public Elements ROzroHhDMSDBRkYcbgMNfthmqXZp;

					private int EBKBmIVyLhQCqRZJpjrKqihVkPCQ;

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
					public KDvmVyxcEniRRArjIeALGfsahvXSA(int P_0)
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

				private sealed class jdgIqjkTAJPKzhdrIFuDqYKWnDlEA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int oTboVvpomXPeVKreHnxjbRGwRCYt;

					private Button cZonkmCqXNbAEdOASgQYOPefPnVhb;

					private int CzndVCCjSqbDzmmZqagDceEqGlYv;

					public Elements JolLeuTxXJeOGOSlkPJhywMilUrh;

					private int BWiSjVWVyEZSKBqYGdIIUIfHOPmC;

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
					public jdgIqjkTAJPKzhdrIFuDqYKWnDlEA(int P_0)
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

				internal IEnumerable<Axis> Axes
				{
					[IteratorStateMachine(typeof(KDvmVyxcEniRRArjIeALGfsahvXSA))]
					get
					{
						return null;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(jdgIqjkTAJPKzhdrIFuDqYKWnDlEA))]
					get
					{
						return null;
					}
				}

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

				public override object DeepClone()
				{
					return null;
				}

				protected override void ImportVars(Element source)
				{
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

				public override object DeepClone()
				{
					return null;
				}

				protected override void ImportVars(Element source)
				{
				}
			}

			public enum DeviceType
			{
				HIDJoystick = 0,
				WGIGamepad = 1
			}

			private sealed class ICLgWufUxtitnIyqqXmnNTTwbMWN : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int DkeoawqvSBaflfRZgNJodWnfnPkE;

				private Axis oKzRJNLdEIfmTJKlVfMkWVgMLNDab;

				private int gOkgBOyVTszbDGgsrboPBajHStoNA;

				public Platform_WindowsUWP_Base eQsYrdhrTSdNEmHgNNYRyEVXcXGG;

				private int XuUSuTdHABJlbvluGByIPjKHaZmbA;

				private int KGQgrKRQwaNtrMZgWRRLicKdgjGW;

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
				public ICLgWufUxtitnIyqqXmnNTTwbMWN(int P_0)
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

			private sealed class EtgniGgBWHHOwcOBsuFUdsesMcXS : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int wQyCsZOzDSAqDnXPeUqWGabbuvTy;

				private Button WFirpwSnUNdqxhMiukBAmuvbIhCY;

				private int KOehUVHdATtbQjlEzFNCZfGlqJSs;

				public Platform_WindowsUWP_Base xPUZBkCQmouMfSmcFUuErlFpvbZV;

				private int sjXVHbMuhVcjhKKFUPUsWuaMShVR;

				private int KnkyCvJddGPfYaFxzVkzcMtuLDKM;

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
				public EtgniGgBWHHOwcOBsuFUdsesMcXS(int P_0)
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

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override Elements_Base elements_base => null;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
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

			[IteratorStateMachine(typeof(ICLgWufUxtitnIyqqXmnNTTwbMWN))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(EtgniGgBWHHOwcOBsuFUdsesMcXS))]
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_WindowsUWP : Platform_WindowsUWP_Base
		{
			public Platform_WindowsUWP_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
					return null;
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
					return null;
				}

				internal override void CopyVars(Element destination)
				{
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
					return null;
				}

				internal override void CopyVars(Element destination)
				{
				}
			}

			private sealed class PTnGrIigbDnBaiBjhGTYLPjfcZypc : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int bVuNqKMIMPQuKPTswjRYKYkYCMgM;

				private Axis nNrLCbwDAZETPesMoDwkPapNYnCDA;

				private int hYHoGWwBmPjStKoKZtBJDiwhlVOX;

				public Platform_Fallback_Base eCfKTCJLAbCcHrFTocTSdeOomxDY;

				private int NLGsemmxiIvzZptGowCQGbloziNj;

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
				public PTnGrIigbDnBaiBjhGTYLPjfcZypc(int P_0)
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

			private sealed class jjrEogGxoZemluDeddcWFGJQLhjdb : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int jUczttTovGCkRlkHhDZOMHJAEIlKA;

				private Button kdyNoLDrRdwgrsbfrjWmNNMnqJRq;

				private int DcrYGZDrcNqJuJVKIMNYXErJbULD;

				public Platform_Fallback_Base XMpzZchGYkbqoyvMZjmtktKXPjbQA;

				private int aCXdiTOBzrteppyLePnZQuURkQeC;

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
				public jjrEogGxoZemluDeddcWFGJQLhjdb(int P_0)
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

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			[IteratorStateMachine(typeof(PTnGrIigbDnBaiBjhGTYLPjfcZypc))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(jjrEogGxoZemluDeddcWFGJQLhjdb))]
			internal IEnumerable<Button> IterateButtons()
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_Fallback : Platform_Fallback_Base
		{
			public Platform_Fallback_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Platform_Custom : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public abstract class MatchingCriteria : MatchingCriteria_Base
			{
				[Tooltip("If enabled, this will match to every controller regardless of other matching criteria.")]
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
					return null;
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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

			private sealed class CbFQQVxoGzPgZeqVbmtbXILmqdxn : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int czLFLSqASurLOOkuGhELQOHuhEmY;

				private Platform_Custom.Axis aeWEsHVIuevlqsWGkYLYXjhGXeLm;

				private int hflZvBUaoUdNDxEelFTjabSKNOYxA;

				public Platform_XboxOne_Base KOBLIOqhtuZPLtjDYaaSwnVCCceX;

				private int izjnLKhRghyrDItzadBJAVlVsPKD;

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
				public CbFQQVxoGzPgZeqVbmtbXILmqdxn(int P_0)
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

			private sealed class wlklOyVpRNwuOnYPAVdPUtgRteOV : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int HLWhZhwqukbvNszKMKixTRZVIOyS;

				private Platform_Custom.Button OjPJqCJbGQcDgDwczowSKbSUNbqk;

				private int RmZgbzFKrNAmrAceGAkBIrGrvakxB;

				public Platform_XboxOne_Base tJLuGnUDUIGlNPmXbCOupmpndjNK;

				private int nmdPrjjpSxHGVXcMNDFHfsghNXfPA;

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
				public wlklOyVpRNwuOnYPAVdPUtgRteOV(int P_0)
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

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			[IteratorStateMachine(typeof(CbFQQVxoGzPgZeqVbmtbXILmqdxn))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(wlklOyVpRNwuOnYPAVdPUtgRteOV))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_XboxOne : Platform_XboxOne_Base
		{
			public Platform_XboxOne_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_PS4_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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

			private sealed class SfmwDDsWNXOiLtddcnbpRlYOAuydA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int nZcIYpsyNkhMrKZHLGHwdGUocahG;

				private Platform_Custom.Axis tsBqCQjnlEPKcjVUoOrwZERGBxWd;

				private int ylpiKipDgxLvphEIuCNLvCSvorjT;

				public Platform_PS4_Base KTpzBaqHbhlXRMDgdvuuTlYIhAEC;

				private int qYSvvYWOJQPNzqSvdcnKIntYUbTR;

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
				public SfmwDDsWNXOiLtddcnbpRlYOAuydA(int P_0)
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

			private sealed class fsHzBFZjYslzEPIjUDsimvQyOJRb : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int AsZYLurMpGAnpHIMGXAzTaLamWsO;

				private Platform_Custom.Button FzHEaeRiJxiAIlVhZmOlngyGCtXjA;

				private int LQdAoyFNVflUQmkiZcDVVPsOIgiw;

				public Platform_PS4_Base AvowkgdcJeUwoqxliAOsjskZwDAr;

				private int OvaSfzXKXZmXTxHdgxMrMIBmxoXE;

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
				public fsHzBFZjYslzEPIjUDsimvQyOJRb(int P_0)
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

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			[IteratorStateMachine(typeof(SfmwDDsWNXOiLtddcnbpRlYOAuydA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(fsHzBFZjYslzEPIjUDsimvQyOJRb))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_PS4 : Platform_PS4_Base
		{
			public Platform_PS4_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_NintendoSwitch_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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

			private sealed class WtDErJhAswuVaSbwnPgplUXHdqGg : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int BXyJRfRbcwCZpfkiHhOfyHdwghjHb;

				private Platform_Custom.Axis xyvtytuoYJEuxzHQkikhMxnLbyZK;

				private int bgRRWZtWxUuxCVsMlntmrdTFzMJD;

				public Platform_NintendoSwitch_Base GNHgObfnizvgvSpeRBfaMMZrhoVh;

				private int ZkciDJhgTWWZWmnnucEzZvwXBRXu;

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
				public WtDErJhAswuVaSbwnPgplUXHdqGg(int P_0)
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

			private sealed class DgPAmiVfxMDMBVrqKIdkNEgRUkUy : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int WPRDzeinBghscDjFJOarxBpPdqTob;

				private Platform_Custom.Button JgTBfaFnrrbLCEypqLfJVQTDgAbYA;

				private int jQpgCdGAdgwvnsynKGqdVsidrDII;

				public Platform_NintendoSwitch_Base iddmRzGYCrHLsBPstcNkatTKDrSs;

				private int NSwFoMfCBzXSMmkYSZKprtKmNFFw;

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
				public DgPAmiVfxMDMBVrqKIdkNEgRUkUy(int P_0)
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

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			[IteratorStateMachine(typeof(WtDErJhAswuVaSbwnPgplUXHdqGg))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(DgPAmiVfxMDMBVrqKIdkNEgRUkUy))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_NintendoSwitch : Platform_NintendoSwitch_Base
		{
			public Platform_NintendoSwitch_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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

			private sealed class gAUGIMpLSpwtzSbfqGwDwYbtmTrO : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int halTJQEySoGYAfCQQmuCKNgKeNFN;

				private Platform_Custom.Axis wZqDIhIEgCeqKifvZpAePMYHRVGSA;

				private int QoGXPylgiAYAINHjaaaCAFxzwnhFA;

				public Platform_GameCore_Base SSvzXdhiAuZGqrxnEOIfYtcXkUdj;

				private int hBJNtwQpwWamwBhxtsgLIVPjXjJlA;

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
				public gAUGIMpLSpwtzSbfqGwDwYbtmTrO(int P_0)
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

			private sealed class FpagQJRVWBtVbTKgpRgGJUWTKWjM : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int WaUxYijddEJcatWToBkXNzEqZYrB;

				private Platform_Custom.Button SmtmyTwAwnAfTqDecbXywWbupexs;

				private int zYYTAminmJfpAknNONvQhqmLPLWWA;

				public Platform_GameCore_Base HDpsZWVRjHmtAPeMQJEbeHCFmUhV;

				private int zwDWmuwfZIuBPnLvWzSYzfydJGhQ;

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
				public FpagQJRVWBtVbTKgpRgGJUWTKWjM(int P_0)
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

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			[IteratorStateMachine(typeof(gAUGIMpLSpwtzSbfqGwDwYbtmTrO))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(FpagQJRVWBtVbTKgpRgGJUWTKWjM))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_GameCore : Platform_GameCore_Base
		{
			public Platform_GameCore_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_PS5_Base : Platform_Custom
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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

			private sealed class jGdgMbAssxNepNuLtpBXjCkffyUzb : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int QJeeNtbKMoCKZJjhdahshqRKGwRH;

				private Platform_Custom.Axis qFOPHEyuetwFACsPaHMVtbommHDX;

				private int OBrLCATJbxMIrkboJBPllXmxwGkt;

				public Platform_PS5_Base kGEqOcjOBrUhpWhsPuQfofSVPVzR;

				private int XkBdtmCVXBSDlBllLKcFfqjGdnpeB;

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
				public jGdgMbAssxNepNuLtpBXjCkffyUzb(int P_0)
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

			private sealed class YCMbNLsNtzXUYKWCXngeARnIIMTz : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int htOEIKexefzOzBZNUDRcHICuwesA;

				private Platform_Custom.Button kLsBRuKZNcJwjbAJrxMaSJoFqOkO;

				private int xlTbEplxKxNcGkCtVcueAdhsOdwAb;

				public Platform_PS5_Base KSxXlOEenJXBpIORAgArzGhpEtZ;

				private int jeQyiQAJlBNZqaJlixcOHUdXjKoF;

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
				public YCMbNLsNtzXUYKWCXngeARnIIMTz(int P_0)
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

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			[IteratorStateMachine(typeof(jGdgMbAssxNepNuLtpBXjCkffyUzb))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(YCMbNLsNtzXUYKWCXngeARnIIMTz))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_PS5 : Platform_PS5_Base
		{
			public Platform_PS5_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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

			private sealed class LaQncOEQdPZRFhgCGPeGggaDfJBK : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int EDtlXVgwdlnOlaDWkzGohzSZUsOE;

				private Platform_Custom.Axis iObATtEGhXtekRBxIKEmdcFfHMGLc;

				private int HaUxfXGNWsJjdaKllEzSvdjvHFAjA;

				public Platform_InternalDriver_Base sFrETYJGumiepjCxUNCyDWhkrimMA;

				private int tbkOQMybUUNpRzwYNuRKnocVoqrn;

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
				public LaQncOEQdPZRFhgCGPeGggaDfJBK(int P_0)
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

			private sealed class VztkrAgCMROmrcHXiRdPDhOjDkhs : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int ZrVWXQYFYTxqgmOuqfkDXtUAqGCJ;

				private Platform_Custom.Button NnxQgYLToftWuaYUadHPDdRzBWOL;

				private int xFWbqMfHKRkOqNYbSePQBUJFXzljB;

				public Platform_InternalDriver_Base LjAGNdSqmczxglwwmoGzQYUChNnE;

				private int rssJWpyFeaIGvSyzcQKuqmlnARrY;

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
				public VztkrAgCMROmrcHXiRdPDhOjDkhs(int P_0)
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

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			[IteratorStateMachine(typeof(LaQncOEQdPZRFhgCGPeGggaDfJBK))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(VztkrAgCMROmrcHXiRdPDhOjDkhs))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_InternalDriver : Platform_InternalDriver_Base
		{
			public Platform_InternalDriver_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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
						return null;
					}

					internal override void exBiBCZBWBkkeuUFjcGutHOztZju(ElementCount_Base P_0)
					{
					}

					internal override bool LoKzWPLloLQZPPKaXCGMladHLcLr(BridgedControllerHWInfo P_0)
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
			public sealed class Elements : Elements_Base
			{
				private sealed class AwTxwQAttCkJPLJIxNfUPInUcaCL : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int wvbvTDhhncPakcvRJPiIfjBARhQg;

					private Axis LPmDUaMAotMPjSykKBQRbxWIAUil;

					private int WFeNprbOFNhkWLxmLqwWiwFDWPau;

					public Elements wfcNaPDulsZvorlVBhNkjMLgaqMD;

					private int FzVlFGwRdjrxNZwoLFCirJcxEYGh;

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
					public AwTxwQAttCkJPLJIxNfUPInUcaCL(int P_0)
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

				private sealed class QMLxscpgunaNZoEBRvruMChFPTJI : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int edQuLlNKhWNGQkkxqffnaMdUEocLA;

					private Button pjEaipPylywvHGxpzDlPgegAsijy;

					private int fRufdFzHsvtqhXrdDJdSvGuqWkNk;

					public Elements DEVJhcIbzDmjseriouPmlhiPFfbx;

					private int sGOMmFxRlOMaLfZmjVzCdtsmdBJb;

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
					public QMLxscpgunaNZoEBRvruMChFPTJI(int P_0)
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

				internal IEnumerable<Axis> Axes
				{
					[IteratorStateMachine(typeof(AwTxwQAttCkJPLJIxNfUPInUcaCL))]
					get
					{
						return null;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(QMLxscpgunaNZoEBRvruMChFPTJI))]
					get
					{
						return null;
					}
				}

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

				public override object DeepClone()
				{
					return null;
				}

				protected override void ImportVars(Element source)
				{
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

				public override object DeepClone()
				{
					return null;
				}

				protected override void ImportVars(Element source)
				{
				}
			}

			private sealed class YYBPmYrPAHPnjjYAhAQQDviZPDkv : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int GlulbxzsFzRCMaPnFdYXVyrSqnLU;

				private Axis LQIjpKPYcwslhEKNrBsGeFeTkNErA;

				private int VeJODzWPMxQpfwUhlVNkvMvdfuEE;

				public Platform_SDL2_Base tJJBsQcmkpvrkifySTKqJMzgPDfw;

				private int dDsMtACIAicZYhCXdtCqSEGjVrHuA;

				private int BYyvSMbkkhAykqUhdjSHjRvMQkcWA;

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
				public YYBPmYrPAHPnjjYAhAQQDviZPDkv(int P_0)
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

			private sealed class jvvFlVkjBxMYDLJvDCXCHXLUOZpd : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int VIngNpDIVQQtClmYAqkBDbXStgFh;

				private Button WkzPsfXUFjYHwodJsZFAixrdPwBF;

				private int UQzulVylpVSGXeGMoPkcQZuTUJob;

				public Platform_SDL2_Base kJqbDdAxRsiiYwPixZigxXofTrORA;

				private int qGOcVpiCbKWtpBfQekwtCSJJlNfMA;

				private int vYmMfWshBUhDJVdSsVzoTjVDasrT;

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
				public jvvFlVkjBxMYDLJvDCXCHXLUOZpd(int P_0)
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

			public override int assignedButtonCount => 0;

			public override int assignedAxisCount => 0;

			internal override Elements_Base elements_base => null;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
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

			[IteratorStateMachine(typeof(YYBPmYrPAHPnjjYAhAQQDviZPDkv))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(jvvFlVkjBxMYDLJvDCXCHXLUOZpd))]
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_SDL2 : Platform_SDL2_Base
		{
			public Platform_SDL2_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Platform_Steam_Base : Platform
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_Steam : Platform_Steam_Base
		{
			public Platform_Steam_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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

			private sealed class JVpcgpAmdRwhWZgBcrsEFBIqQmsT : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int vvgaKKAUvkHphAueiKAOnCHbcGZC;

				private Platform_Custom.Axis DTyRjjEeURADqCDAFKqhZseenXau;

				private int OkeLJICJRoCjTWJSNEgMgGMfqEuO;

				public Platform_WebGL_Base ZTVHuoEdobfjooZmvRTZWSOWcIim;

				private int DjtJNaZosUrdxkGwGgeJNbgvrDjP;

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
				public JVpcgpAmdRwhWZgBcrsEFBIqQmsT(int P_0)
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

			private sealed class gWuEFfDVWdgwWprDVLRtbeNDAdLe : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int rfaaScJelVIbuXGugDFGCNpNwYUK;

				private Platform_Custom.Button lFkFxKnawNIkJxWZJrGMLerkMQIu;

				private int uJCcapDRHHNCgkEVRfzgehTccpnsB;

				public Platform_WebGL_Base SiMpawvTXTeGGmjvFDrEeFxNUyM;

				private int QYcwEwvFzdDkAcnEDRRpdhyyyFOW;

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
				public gWuEFfDVWdgwWprDVLRtbeNDAdLe(int P_0)
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

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			[IteratorStateMachine(typeof(JVpcgpAmdRwhWZgBcrsEFBIqQmsT))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(gWuEFfDVWdgwWprDVLRtbeNDAdLe))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_WebGL : Platform_WebGL_Base
		{
			public Platform_WebGL_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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

			[EditorBrowsable(EditorBrowsableState.Never)]
			public enum AppleGCControllerProfileTypeFlags
			{
				None = 0,
				Generic = 1,
				ExtendedGamepad = 2,
				MicroGamepad = 4,
				Unknown = -2147483648
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

			private sealed class ZmSksmrDfKfkzBKDcxJIstrhwhRFA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int oTimKPRhnjaQJCjPwOdssKMXfvsf;

				private Platform_Custom.Axis IWIvhDdtbIEKOEyCcdNhyVbDTSFL;

				private int YxBvQzhdoYIbsjLmOvEtpaYfTVQG;

				public Platform_AppleGCController_Base qBbPvlODkDdVxrhLeAxpMYoPOoRq;

				private int yNSGkLxsFeFheFXQdjFbvjUhUwLUA;

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
				public ZmSksmrDfKfkzBKDcxJIstrhwhRFA(int P_0)
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

			private sealed class CFmLwRfDvazjRmwlMSCdfnTJedVFA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int RPHGEGFlEfJLDEoEGMJIyyjguaTpb;

				private Platform_Custom.Button kmoEXvdSRMSAyqUPaaVWDYlkAHTKA;

				private int PvDutQSJSHTLpZyfosmKJNPAQJuF;

				public Platform_AppleGCController_Base hZgVJAjsfDSYPsWgNtIVCysKneCS;

				private int PHGNUfWekwpPEWILxjAIcvxYYHGZ;

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
				public CFmLwRfDvazjRmwlMSCdfnTJedVFA(int P_0)
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

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			[IteratorStateMachine(typeof(ZmSksmrDfKfkzBKDcxJIstrhwhRFA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(CFmLwRfDvazjRmwlMSCdfnTJedVFA))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_AppleGCController : Platform_AppleGCController_Base
		{
			public Platform_AppleGCController_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
			[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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
				Gamepad = 1
			}

			private sealed class JhaYnYuKauKYcDdkBdtUEbGMySFBA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int XePKYlfFudBXZtqbfcFqWWIWPrGL;

				private Platform_Custom.Axis PUnpQkXiTJyzmvACkGvkdNTEPPiPA;

				private int NCQfosiHXyFQryvDdmUfGQTrMMvA;

				public Platform_WindowsWGI_Base ELGCSZVdxJjihGnChIRrWnQwYMXW;

				private int cQkasYHazhSZBNBDYjytqbTUyUyl;

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
				public JhaYnYuKauKYcDdkBdtUEbGMySFBA(int P_0)
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

			private sealed class XmsgHdbgDSVePQmpGQWuwxMFRQjB : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int defQZuLSmXUnSaUfYAJbIFiZkHXC;

				private Platform_Custom.Button gnMbmcLJFWozXlKpWKtWREJhhOOFA;

				private int jlKHarnYquVVTwBSBbZBwnbLEjGDA;

				public Platform_WindowsWGI_Base RTYqBUxzlNLWQgAuudllbNPBBghUA;

				private int qgBHfAYJsBrCVSYaJjJAgMmIbnSs;

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
				public XmsgHdbgDSVePQmpGQWuwxMFRQjB(int P_0)
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

			public override IList<Platform> GetVariants()
			{
				return null;
			}

			internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
			{
				variantIndex = default(int);
				platformMap = null;
				return false;
			}

			[IteratorStateMachine(typeof(JhaYnYuKauKYcDdkBdtUEbGMySFBA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(XmsgHdbgDSVePQmpGQWuwxMFRQjB))]
			internal override IEnumerable<Platform_Custom.Button> IterateButtons()
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Platform_WindowsWGI : Platform_WindowsWGI_Base
		{
			public Platform_WindowsWGI_Base[] variants;

			public override IList<Platform> GetVariants()
			{
				return null;
			}

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

			internal static Platform_WindowsWGI CreateDefaultMap(BridgedControllerHWInfo bridgedController)
			{
				return null;
			}
		}

		private sealed class hSflewnGYIuAWjcUxhFrEIQLthEH : IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerable, IEnumerator<IControllerElementIdentifierCommon_Internal>, IEnumerator, IDisposable
		{
			private int ojhVvEllyQiiABvlZPKUJNLoITnK;

			private IControllerElementIdentifierCommon_Internal RekHrkisyaZuGYbxPgssfMIfEcJmA;

			private int tDczrRqWSfTARufGzxyIthEzONKk;

			public HardwareJoystickMap sWmdTkiYaEVXejKNOcHvkLFBOerBA;

			private int fxECageqWvJClRuWTHIyqMDaVxdFA;

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
			public hSflewnGYIuAWjcUxhFrEIQLthEH(int P_0)
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

		private sealed class eUWqsrCeXezQBFTHpkvaghBgwOxg : IEnumerable<ControllerElementIdentifier>, IEnumerable, IEnumerator<ControllerElementIdentifier>, IEnumerator, IDisposable
		{
			private int bWylMuiAYPQAjkYdRlxsOmvrPQiP;

			private ControllerElementIdentifier ZWoXLERxxcMwlMUncNnKsAhotPSt;

			private int CIXKOJOdJBWGPHMNPRQsvEsEvDRx;

			public HardwareJoystickMap fImHDMrVStvFadwStwlpcEUfevhF;

			private int ZJzCWHGoBbmKbHuoGQvEKTsctZGRc;

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
			public eUWqsrCeXezQBFTHpkvaghBgwOxg(int P_0)
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

		private sealed class OObgCHaSfdEgmjrWHAzJQKAAbgNDB : IEnumerable<JoystickType>, IEnumerable, IEnumerator<JoystickType>, IEnumerator, IDisposable
		{
			private int iYdlQjVNjwwiCjRUOVespVUAEjSp;

			private JoystickType pxbuXncIcZREePfVNvNUPYEgVUjJ;

			private int KIWmtIAqQSBtISAFbgzfRJDUkQhV;

			public HardwareJoystickMap GBYtBBElWkxtQEssNmUOSqAzJpPN;

			private int FQlrbyCNWwIOIQCbyHfDGnONxezz;

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
			public OObgCHaSfdEgmjrWHAzJQKAAbgNDB(int P_0)
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

		private sealed class VsLHLrSBzxPEuVCOobRDbXvblOTI : IEnumerable<Guid>, IEnumerable, IEnumerator<Guid>, IEnumerator, IDisposable
		{
			private int lmDFIwPuKmEhmCYjiCETcGWJNzfJ;

			private Guid AxdXukcJgkVOGRFJZgJiNlvMfTMH;

			private int fiOCzzoAgxWsqCJncPEZKrnuGJmS;

			public HardwareJoystickMap JVLeAVbEQeCMulgsSVEEWeWTLBJzA;

			private Guid[] YFCVSGfaklcdUACpbKirVJkcOvrrA;

			private int vZifTBTAFQGwGdKdciSIRbYXwviT;

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
			public VsLHLrSBzxPEuVCOobRDbXvblOTI(int P_0)
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

		private Guid runtimeControllerGuid => default(Guid);

		private Guid[] runtimeTemplateGuids => null;

		public string ControllerName => null;

		public string EditorControllerName => null;

		public Guid Guid => default(Guid);

		public string Key => null;

		public IEnumerable<Guid> TemplateGuids
		{
			[IteratorStateMachine(typeof(VsLHLrSBzxPEuVCOobRDbXvblOTI))]
			get
			{
				return null;
			}
		}

		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers
		{
			[IteratorStateMachine(typeof(eUWqsrCeXezQBFTHpkvaghBgwOxg))]
			get
			{
				return null;
			}
		}

		public int elementIdentifierCount => 0;

		public bool HideInLists => false;

		internal IEnumerable<JoystickType> JoystickTypes
		{
			[IteratorStateMachine(typeof(OObgCHaSfdEgmjrWHAzJQKAAbgNDB))]
			get
			{
				return null;
			}
		}

		Guid IHardwareControllerMap_Internal.typeGuid => default(Guid);

		string IHardwareControllerMap_Internal.typeKey => null;

		ControllerType IHardwareControllerMap_Internal.controllerType => default(ControllerType);

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			[IteratorStateMachine(typeof(hSflewnGYIuAWjcUxhFrEIQLthEH))]
			get
			{
				return null;
			}
		}

		string IHardwareControllerMap_Internal.name => null;

		public HardwareJoystickMap()
		{
		}

		public HardwareJoystickMap(HardwareJoystickMap P_0)
		{
		}

		public int GetTemplateGuids(IList<Guid> results)
		{
			return 0;
		}

		public bool ContainsTemplateGuid(Guid guid)
		{
			return false;
		}

		[CustomObfuscation(rename = false)]
		public string[] GetElementIdentifierNames()
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		public int[] GetElementIdentifierIds()
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		public ControllerElementIdentifier GetElementIdentifier(int id)
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		public ControllerElementIdentifier GetElementIdentifierAtIndex(int index)
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		public bool ContainsElementIdentifier(int id)
		{
			return false;
		}

		[CustomObfuscation(rename = false)]
		public int GetElementIdentifierInfo(ControllerElementType type, out string[] names, out int[] ids)
		{
			names = null;
			ids = null;
			return 0;
		}

		[CustomObfuscation(rename = false)]
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
