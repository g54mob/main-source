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
			private sealed class JZWBIjyeSndRHctxnGCefQlnJbzfb : IEnumerable<Platform>, IEnumerable, IEnumerator<Platform>, IEnumerator, IDisposable
			{
				private int QYctQKhHjNRNsJmXhJbKbXWtJrcU;

				private Platform toGOhQfkiaFTBoKeWyxyuZpDcPhK;

				private int xtaxfEdklPHINhXVunSdrsViHaJmA;

				public Platform WLDQFqxFJTkuTczSxcERIQRiIPks;

				private IList<Platform> FUqcKfCsQayNtSFqfOwCAGxDfRmJA;

				private int ITWAJvaXRcrklqpRVWCPgWHBVnTC;

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
				public JZWBIjyeSndRHctxnGCefQlnJbzfb(int P_0)
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
				[IteratorStateMachine(typeof(JZWBIjyeSndRHctxnGCefQlnJbzfb))]
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

				internal virtual void omppIeegtgVveHoEpxIJQNOoMDvX(ElementCount_Base P_0)
				{
				}

				internal virtual bool TUoBFpatPkDWLGgfZKYvzYlAiuFmA(BridgedControllerHWInfo P_0)
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

			public int intValue0;

			public int elementCount => 0;

			private Axis2DClampType axis2DClampType => default(Axis2DClampType);

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

			internal virtual Axis2DCalibrationData GetAxis2DCalibrationData()
			{
				return default(Axis2DCalibrationData);
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

					internal override void omppIeegtgVveHoEpxIJQNOoMDvX(ElementCount_Base P_0)
					{
					}

					internal override bool TUoBFpatPkDWLGgfZKYvzYlAiuFmA(BridgedControllerHWInfo P_0)
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

				public float axisUpperDeadZone;

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
				private sealed class eYpsbmBSrteoeFQzrfQgZwTvNCtR : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int ftCEgZESnNCzwIZiXqWensCfMBqWA;

					private Axis_Base LXLcuNxzOTkZSaQMexrtwCmjaWhU;

					private int PAKJMbAhTSdIMiuBcInOtsWkOhpNA;

					public Elements jjIqLPknlEEfuIISoqJKForlixZX;

					private int KUkInKAcIrHPxOselTeChXbFmAIh;

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
					public eYpsbmBSrteoeFQzrfQgZwTvNCtR(int P_0)
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

				private sealed class byNarRJhSTbaTFMbtBHaVeHVggYWA : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int fQnNyHsqNUZHDoaChPGDoQwcGZZb;

					private Button_Base XxCpvHNdyREmrEXgVnPpegEcrHhqA;

					private int XokmczhChRbhDXBQFsstIISFZas;

					public Elements pCQCqdhiGvOnkOeswhvXnetrJzclA;

					private int FPYBCUIfLgNmLOFOeUXVJHpwqztdA;

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
					public byNarRJhSTbaTFMbtBHaVeHVggYWA(int P_0)
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
					[IteratorStateMachine(typeof(eYpsbmBSrteoeFQzrfQgZwTvNCtR))]
					get
					{
						return null;
					}
				}

				internal override IEnumerable<Button_Base> Buttons
				{
					[IteratorStateMachine(typeof(byNarRJhSTbaTFMbtBHaVeHVggYWA))]
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

			private sealed class SRuGbaJfRDwNoxmcYSifRPsjbvwf : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int ItXWJYLwoNkpRiePzFoNHUqCdQbY;

				private Axis_Base ydOhQacePOSvUrZqFGcArtmXuZAY;

				private int JgqDyydPzLtVmaDKCpfcQwiLwVZs;

				public Platform_DirectInput_Base jDjNzASwfjeDVYipVODAYgZbNmrc;

				private int yAZkFxosMKfTVvcxprsVrCcoHCubA;

				private int xozXlnGYSKNeSGosIJThiOLbrQsX;

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
				public SRuGbaJfRDwNoxmcYSifRPsjbvwf(int P_0)
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

			private sealed class bQIKNXdmfOerrPVdadcndbWZbAQKA : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int DIMJsoBYOnsvjWHyJGxOEVifESugb;

				private Button_Base AvttJXwhAjBpWnwtlAleICuXIaJl;

				private int LASGGXjsAYszQPYEJfkxlXTeIXieA;

				public Platform_DirectInput_Base tJeVprIngKydAkMgmPMMZHgjHpuAA;

				private int cNMwnesUPdUOBolbDYzJsCSwZGcL;

				private int sOJBKwyYxfogacWGoUGlLlFUqkRF;

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
				public bQIKNXdmfOerrPVdadcndbWZbAQKA(int P_0)
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

			[IteratorStateMachine(typeof(SRuGbaJfRDwNoxmcYSifRPsjbvwf))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(bQIKNXdmfOerrPVdadcndbWZbAQKA))]
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
				private sealed class ZbyQtWHVeRuFFYZAUSFdOqyoRMIh : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int mUBHLyNwqDzQvMEhQqxnkoAQZAEh;

					private Axis_Base vTzmpCEdJjmxQnIfrItvPauFHHSt;

					private int FePAQWVZPwmukIZQhnPoiKOPbIvy;

					public Elements tldYSoWPoaPvLYvWtjweqyXDNsco;

					private int rnhYVZlIkycNSyroCMFaOmfwkIRN;

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
					public ZbyQtWHVeRuFFYZAUSFdOqyoRMIh(int P_0)
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

				private sealed class weSPwrkGyWbnfzkyQGSbTmBPOpZx : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int xLYXAhDqAQDtluADMqMtVpgqdjeZ;

					private Button_Base XIpXnCwNijqIzIVAjtiOiCguXDuA;

					private int IdABfssycogmuGpHLbUxtSTFoFDd;

					public Elements EkQLbrcALXHTgCwUzeRtubhEYTYT;

					private int eKpcsoPKmBubgoeJnbtmpQrVLaij;

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
					public weSPwrkGyWbnfzkyQGSbTmBPOpZx(int P_0)
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
					[IteratorStateMachine(typeof(ZbyQtWHVeRuFFYZAUSFdOqyoRMIh))]
					get
					{
						return null;
					}
				}

				internal override IEnumerable<Button_Base> Buttons
				{
					[IteratorStateMachine(typeof(weSPwrkGyWbnfzkyQGSbTmBPOpZx))]
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

			private sealed class JubBTDUcwjhhDjbXCHitjAsOamaJ : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int LujfaFjnXZbtOuUlUrbcHTgvKCdrA;

				private Axis_Base FmCgyTAroaEnrTyYRMuJongtDPmi;

				private int BiHyzbjOrmdtckQGeGPjUVIlIHHQ;

				public Platform_RawInput_Base DhJnxYGQlpAxHVORwoHcVMlyQvZA;

				private int YJNbdMJlRHmJXSTvrDGOFVbbMIrKc;

				private int sSXbheTWmCasWIOLechRDDBckPADA;

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
				public JubBTDUcwjhhDjbXCHitjAsOamaJ(int P_0)
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

			private sealed class BhfPmCvavPbqhBeBtlJzjsHkmaUXb : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int drUIzeapNdyYPhLtEvFwJyskHzLg;

				private Button_Base JkqNInUFpVhuHSWqPbfLiLIetlqz;

				private int cXtFlGIFQPIHexrysPXuHaeZFmFV;

				public Platform_RawInput_Base jdEfdIdAZZCvPNNaIkpdpngZhlicA;

				private int EGvYxRxoJTkhbQowIPobvBbWeuFS;

				private int AQeUCXXZykkXZNTEjKVDYqxJDQBv;

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
				public BhfPmCvavPbqhBeBtlJzjsHkmaUXb(int P_0)
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

			[IteratorStateMachine(typeof(JubBTDUcwjhhDjbXCHitjAsOamaJ))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(BhfPmCvavPbqhBeBtlJzjsHkmaUXb))]
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

				public float axisUpperDeadZone;

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

			private sealed class ugsPZicKAgageeRKfaDrGYZohVer : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int QiLZvcbWadJMdjvuDrdnzwrAOPcU;

				private Axis AVvzIHuybggmVfQGHVooOwUQqrRo;

				private int piscQzwGFIhlfHMIxWFwOFbxtskn;

				public Platform_XInput_Base RGqjEHaFDqSyiuGioWSlNTtJVVYc;

				private int zLXedpmLOOyyyjrEaCZstMcJGmgx;

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
				public ugsPZicKAgageeRKfaDrGYZohVer(int P_0)
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

			private sealed class GgFpkuSKEwtWkLjjoHPIzrZmwjHK : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int KOIscAdQboiPuTKHNajUilTBQoCEA;

				private Button PnXPCIShtleimfmJyuFxAIBDBjjVA;

				private int SMlXoOMQAlAdHXIYGvfiuemLmAjN;

				public Platform_XInput_Base CoJjASmsFujOVFlJrOPTqxRwWTUh;

				private int FNjvLJFvqUYCzwVnviQhfRClvqzK;

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
				public GgFpkuSKEwtWkLjjoHPIzrZmwjHK(int P_0)
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

			[IteratorStateMachine(typeof(ugsPZicKAgageeRKfaDrGYZohVer))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(GgFpkuSKEwtWkLjjoHPIzrZmwjHK))]
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

					internal override void omppIeegtgVveHoEpxIJQNOoMDvX(ElementCount_Base P_0)
					{
					}

					internal override bool TUoBFpatPkDWLGgfZKYvzYlAiuFmA(BridgedControllerHWInfo P_0)
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
				private sealed class RAKYpcOKDVdFKIuoNfVueTKDnvvfB : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int lsoRIXXcODSMvvCIERExyRsubOaW;

					private Axis kmQqwIipLlUsvJanlpouRVrYZUtd;

					private int ryqTgUYFzlGFtdECGbTYfnHOakbj;

					public Elements HNVmAITNPHppvispLfpVFdjWzRPp;

					private Axis[] msYnRaEzZiBFLIOZpFOXFXfKVSjy;

					private int fEofIdjdGcgQdbiwJOMJkJrLLqZhA;

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
					public RAKYpcOKDVdFKIuoNfVueTKDnvvfB(int P_0)
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

				private sealed class gmQdwCLVfaPMjlSHQgRsZxQEayrT : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int xqwcKBaPPWSaqjWKiuOQPKJEAqTe;

					private Button QTfLqKmfVhEQAbqqsmvzzdjQgJJN;

					private int hqTFBvgPnLlDHmnJzZvpDpSNBUmU;

					public Elements qfNblEVJQrxmVXBUMEpAfMXjjOZk;

					private Button[] XCQUOZTneBtSPiWEWSIgtfEpFSoI;

					private int sjZUPNMeJbEnvEbsKJjBFDzYEPrhb;

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
					public gmQdwCLVfaPMjlSHQgRsZxQEayrT(int P_0)
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

				[IteratorStateMachine(typeof(RAKYpcOKDVdFKIuoNfVueTKDnvvfB))]
				public IEnumerable<Axis> IterateAxes()
				{
					return null;
				}

				[IteratorStateMachine(typeof(gmQdwCLVfaPMjlSHQgRsZxQEayrT))]
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

				public override object DeepClone()
				{
					return null;
				}
			}

			private sealed class fcKCiYcZeFflfBkXTZYlVxfmyJBD : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int oElbNLnNjwSQQBOmSXxqaivlTOet;

				private Axis WaAMphvxNbqRGMNgwdqsKwawdmey;

				private int rYHAaPcQjZCXyfBjjnRjmGMZTMHE;

				public Platform_OSX_Base MBoHfJSNFOzeDaoMcTsJWoMpGEEb;

				private int UmtFGeypUHYdOIUhYkuylesrpVKy;

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
				public fcKCiYcZeFflfBkXTZYlVxfmyJBD(int P_0)
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

			private sealed class hENaUxDnhggqmQLuuTJIsUVtMMXdb : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int VzJCOTFWZcWsUGozOsafsYOUJRRX;

				private Button wMgIeQwHTIPgOXspWMATzjcOBTXS;

				private int OYDxBgpfnRVXUkOHgeWrYXPQBccr;

				public Platform_OSX_Base nbPRVwzpcKaABDgsedHYxUQRelQZ;

				private int PXbkwKBwiOBoKtaocAyCDkBByknKA;

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
				public hENaUxDnhggqmQLuuTJIsUVtMMXdb(int P_0)
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

			[IteratorStateMachine(typeof(fcKCiYcZeFflfBkXTZYlVxfmyJBD))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(hENaUxDnhggqmQLuuTJIsUVtMMXdb))]
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

					internal override void omppIeegtgVveHoEpxIJQNOoMDvX(ElementCount_Base P_0)
					{
					}

					internal override bool TUoBFpatPkDWLGgfZKYvzYlAiuFmA(BridgedControllerHWInfo P_0)
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
				private sealed class BrmAfJAEEeGYXrURAUKUyYrSLDUi : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int HmmaAiJcSRMrVxQELPCrAAmjdQLpB;

					private Axis JfoYkBobVUDbyRVYmfNwVKDtaqtCA;

					private int rToBIXlcVoEXiHjaFYyuTJealeMkA;

					public Elements OSzXYfSXQiBSZScIwuvnBjIFnOJN;

					private int cgrvxqkYTzwKyejfJlBtjEEhPwOG;

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
					public BrmAfJAEEeGYXrURAUKUyYrSLDUi(int P_0)
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

				private sealed class cRDkTgQXYlJUYzJkpRoTFNTVBvab : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int WOVOrvindEQWAdyQvXLoyiEYilrU;

					private Button tDheqeiwcGbYWyRkcdPwmawUVBOG;

					private int JnQfumuiKWGVbQDfJvsrmckUdrFs;

					public Elements baHxJifyGpQsmYonmvnbvnLSDfAFA;

					private int RLosKaAxmSiRCEpLRCwmpqaMxViB;

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
					public cRDkTgQXYlJUYzJkpRoTFNTVBvab(int P_0)
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
					[IteratorStateMachine(typeof(BrmAfJAEEeGYXrURAUKUyYrSLDUi))]
					get
					{
						return null;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(cRDkTgQXYlJUYzJkpRoTFNTVBvab))]
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

				public override object DeepClone()
				{
					return null;
				}

				protected override void ImportVars(Element source)
				{
				}
			}

			private sealed class SYEJAQqaOaevDffVnAfyFQeDEumBA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int tQmCyJxomopzrFItgoUNCnSYPjIw;

				private Axis PPMWShFMNUmarkKCtcTfmpCxEqTS;

				private int ispTiqnROSujzlMHPjstJGhMVonH;

				public Platform_Linux_Base xyHBtDHeVfIoNJvGHbDNIkeIGHWvA;

				private int bZMjugbeKAynSnehmobqWiFRIzKy;

				private int dBONHlEmNSXsoCOzPunwzatOftiG;

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
				public SYEJAQqaOaevDffVnAfyFQeDEumBA(int P_0)
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

			private sealed class OcRCOAFlxarmuQOmjDvyhGcZNafM : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int kauyxkeYhKLYZKJYfNbnXsuvKloT;

				private Button oqoGQXseeabALKxqdovZVtWomLjF;

				private int puCGwIKFVdCDLLyDCGMMLldftJjh;

				public Platform_Linux_Base AuABntCtXIgtRPzmujbBhfWqagFr;

				private int EtFJdkqVDmdHDDxcwuRMaQZvDCgP;

				private int ZQIwAzkRxYYSVcCNquUOjiBxBYpV;

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
				public OcRCOAFlxarmuQOmjDvyhGcZNafM(int P_0)
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

			[IteratorStateMachine(typeof(SYEJAQqaOaevDffVnAfyFQeDEumBA))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(OcRCOAFlxarmuQOmjDvyhGcZNafM))]
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

					internal override void omppIeegtgVveHoEpxIJQNOoMDvX(ElementCount_Base P_0)
					{
					}

					internal override bool TUoBFpatPkDWLGgfZKYvzYlAiuFmA(BridgedControllerHWInfo P_0)
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
				private sealed class IFPmEIIdjAwWNhXwUTAiWDadHbTkA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int XvWMoVGmQjTvogFmJpxJPHtEmYCu;

					private Axis CAqFeMfshSibsxUImCkwRiyEyblN;

					private int BZbxygGfkKzdgihmZwxyixkkCRQr;

					public Elements VoVqdnYHphFETBflliMmhElhKVJBb;

					private int EecflgqLqSJpesnGnvYbZDdUVMAF;

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
					public IFPmEIIdjAwWNhXwUTAiWDadHbTkA(int P_0)
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

				private sealed class tiCudLqRdgrTxGekIrwgdOENSJjT : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int kmRGMRKSNsFtLdpfPOzYEjWroGOs;

					private Button kjGKvSpAakQDOlmFEfUvbsgownDkA;

					private int QgJwLsxPxXAFvHJQmcaoPVEdbHYH;

					public Elements NODSpAgBweEhKrqawvHMLxKbVlxs;

					private int RdQRWltyVfWOYmdKQjDxpOxMExwD;

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
					public tiCudLqRdgrTxGekIrwgdOENSJjT(int P_0)
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
					[IteratorStateMachine(typeof(IFPmEIIdjAwWNhXwUTAiWDadHbTkA))]
					get
					{
						return null;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(tiCudLqRdgrTxGekIrwgdOENSJjT))]
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

			private sealed class UgzwJGjtAQoVrHAzoBkYqnPdfIMM : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int LQWrIKZQvmnEzQUlqPEFIYlmvKaD;

				private Axis eYZfAvybfjujDrTsZEOVcHyBBNHCA;

				private int aXAuKoXHsPlgHvCvdnsmFfdQnbuS;

				public Platform_WindowsUWP_Base upCAFRAusdagQPfhFlTaFkPYFmKu;

				private int NpafbjhQpePyfvKlYJunKeWQARgbb;

				private int OzuNaacRXXdmvtufKoHqThKkpnUX;

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
				public UgzwJGjtAQoVrHAzoBkYqnPdfIMM(int P_0)
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

			private sealed class EMCgUqDlbwRHoBhOakHfAbmjieDeA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int omOpfvbkczxhNGCUqcdthIhsnVTF;

				private Button WdAHeOlSrgNrrQshguZpZYloklSx;

				private int OrSoLlgObcgeKjUDpVLzNgQqZDSFA;

				public Platform_WindowsUWP_Base htmxIStnNHfTvbbzHPmpeGDIqtFoB;

				private int gAjFUBfzYmjslqzEWWUXhnwPxbVfA;

				private int GYOAJDicUbwyYTtipZmOJGbvWZAL;

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
				public EMCgUqDlbwRHoBhOakHfAbmjieDeA(int P_0)
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

			[IteratorStateMachine(typeof(UgzwJGjtAQoVrHAzoBkYqnPdfIMM))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(EMCgUqDlbwRHoBhOakHfAbmjieDeA))]
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

				public float axisUpperDeadZone;

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

			private sealed class JSNukoHbKyQAcwloEHwbycfbcTow : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int tNQgbcvonafvWgXxaqTjzGkBTIuN;

				private Axis nsJjVJLrdgiCNNIPeQyVNZlYElAS;

				private int fEdpVaTlRqRMtrEFFIDyizyiHREW;

				public Platform_Fallback_Base ygRpAiixxYLfDKdMytXpTZMhfdBN;

				private int JrubPIFBJjCuXWKkcPottExhOtZM;

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
				public JSNukoHbKyQAcwloEHwbycfbcTow(int P_0)
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

			private sealed class nXNrfAtJJgDrlCLrncwvAjJcLdjBc : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int zrQbyLDwMtMdHIQWvGXdfqRXaEbJA;

				private Button gAGCObusmMEzvFSidfWPDkEgKZFXA;

				private int JbTVGhqfIufikyiEGIwjqQTSdxBC;

				public Platform_Fallback_Base FYDBOUcYvZMveGXRXomUvCEMxpvfA;

				private int wXpktpzkpWoCpOrgoBcmtdqGmvkI;

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
				public nXNrfAtJJgDrlCLrncwvAjJcLdjBc(int P_0)
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

			[IteratorStateMachine(typeof(JSNukoHbKyQAcwloEHwbycfbcTow))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(nXNrfAtJJgDrlCLrncwvAjJcLdjBc))]
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

				public float axisUpperDeadZone;

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

				public float axisUpperDeadZone;

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

			private sealed class QitGBrGRlUFzHXNUxnvKaPTpOzjm : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int aklsSoLDtBdSIjvlYoAmjlJpFEcYA;

				private Platform_Custom.Axis mkIJdIiTJBwiAHZEeWvWonfFHbDD;

				private int jbFCVxpmTtOuPSDllLEKUySPIYWg;

				public Platform_XboxOne_Base CmrYggFGcFYXuKWCIaglLFiJmzgC;

				private int mDBmAwOkkEpeHtqwgfBsfXsKqxAC;

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
				public QitGBrGRlUFzHXNUxnvKaPTpOzjm(int P_0)
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

			private sealed class sUCIZOgfqujvUKjACGbczZmUpaEU : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int TugOODVePDckRDFBUseYesZIEGqqA;

				private Platform_Custom.Button QvQWaLwrvUpkTifrJmxzbEDURcuA;

				private int HarWsVrkAmFlhgVhIxuymAOuzqcCA;

				public Platform_XboxOne_Base zPbhFLbzivDFTcEHlOwJAnUidsDE;

				private int hxTigBIFrEfHFCsNNfFiqDycZVbcA;

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
				public sUCIZOgfqujvUKjACGbczZmUpaEU(int P_0)
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

			[IteratorStateMachine(typeof(QitGBrGRlUFzHXNUxnvKaPTpOzjm))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(sUCIZOgfqujvUKjACGbczZmUpaEU))]
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

			private sealed class YgYFSzJTmcAfLHAyoJvGUeKBpweOA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int zdYHFZBFLMknOrEFxAPCKYnkqxlA;

				private Platform_Custom.Axis nkpbLqWYEhGleWSHcYiLoGTHTBEh;

				private int qUHlxMQVHYAphWGHmNReKSWsvFfg;

				public Platform_PS4_Base MGHwpELwKCgjPvjGrjRFuWtNzbIl;

				private int kMcCkcAbgdmQxJDmhUhhvzfDvvZCA;

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
				public YgYFSzJTmcAfLHAyoJvGUeKBpweOA(int P_0)
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

			private sealed class tDOqMncbYveXtkZACHvTDvjnMRVe : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int QTnbQIDSCdIybjaRQXYQngLzrWmOA;

				private Platform_Custom.Button LhvFlOqCgCgHYAyeHdQUKkaBbpHKA;

				private int RMTdPQgUwCRvIZbhBBTmimtRuekg;

				public Platform_PS4_Base YOYdrQiEeXdheQToqiGDgMogCREKb;

				private int GHGCPVmXsoCpBCSmubxYbaHtWrXx;

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
				public tDOqMncbYveXtkZACHvTDvjnMRVe(int P_0)
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

			[IteratorStateMachine(typeof(YgYFSzJTmcAfLHAyoJvGUeKBpweOA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(tDOqMncbYveXtkZACHvTDvjnMRVe))]
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

			private sealed class OrwXlQKNLphqzHnnFZMUTZEffUiA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int FjMmIDqFDZrGnDEvJoSWwQjfnXhL;

				private Platform_Custom.Axis hKFFnJgDtgcrxtCNiceWOddYEyPKA;

				private int jZbBMrWhlzgpCIkdtSvJBAxGwbJxA;

				public Platform_NintendoSwitch_Base KqvxVXCaFKFgtjTjZmPBdZZiNxDq;

				private int PyMpMzYzyvQgYXWcmCuQiEmUZrRj;

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
				public OrwXlQKNLphqzHnnFZMUTZEffUiA(int P_0)
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

			private sealed class RzbZdKcgUrFTFwOxKdzTcTuEWgKx : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int UVdWsSIbkDnhySQOSMmWcdfgMuTP;

				private Platform_Custom.Button HavyIKeVUCMzEDbwunjarjTOCEtJ;

				private int nmHnqTrYCPfrlPbcWMmMqYckbSUh;

				public Platform_NintendoSwitch_Base kgTLYLludYSUmooxdZLXJKFJfnCT;

				private int DNGszwOPgSaNUJhREMxKACKbHBVU;

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
				public RzbZdKcgUrFTFwOxKdzTcTuEWgKx(int P_0)
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

			[IteratorStateMachine(typeof(OrwXlQKNLphqzHnnFZMUTZEffUiA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(RzbZdKcgUrFTFwOxKdzTcTuEWgKx))]
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
		public class Platform_NintendoSwitch : Platform_NintendoSwitch_Base
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
		public sealed class Platform_NintendoSwitch2 : Platform_NintendoSwitch
		{
			internal override InputPlatform platform => default(InputPlatform);
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

			private sealed class gicQZaClpMMrrzTkevuqDdbaHNrcA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int zgREQsvUtXTRGGuZEPsnlrqZFJRm;

				private Platform_Custom.Axis cgWPBBxCHxqpQIOmRJGLlYYERlWl;

				private int CvoaEWeYLxyXCcmawktfyBduilhs;

				public Platform_GameCore_Base CkVBoRYdvDuOsOHwUfEEBbsGjahXA;

				private int xhdIcGvOBfRjaCVgbsgiiMTaEhHaA;

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
				public gicQZaClpMMrrzTkevuqDdbaHNrcA(int P_0)
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

			private sealed class RRENJbazxkHChqjbfWeribEKHYjaA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int OCsqKkOJUzIbqOgPoINZuJfdeHUW;

				private Platform_Custom.Button CULJpxTgXOKHVRDfabTBgHtvacdEb;

				private int fkugRIdTHefcAnIQGkrxsPuIlRWjA;

				public Platform_GameCore_Base TcNiOmwAGkzrIggBAhEGcZKCHMdtA;

				private int tprDbAkPwzrUHAWmKZObcGyifGdoA;

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
				public RRENJbazxkHChqjbfWeribEKHYjaA(int P_0)
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

			[IteratorStateMachine(typeof(gicQZaClpMMrrzTkevuqDdbaHNrcA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(RRENJbazxkHChqjbfWeribEKHYjaA))]
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

			private sealed class zfBwFZLaBIgfpGZCjnFsVdoijyCcb : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int YOlrJmGdRqLLwVelYqBSJRPmCRv;

				private Platform_Custom.Axis yamKQgVNFSjKEtoSueMaBSgbqHZUA;

				private int WbPMfcaWYALSnNxtHTCMEsQcQyid;

				public Platform_PS5_Base oziDZKAiaUKyxjMpHRSQBxCSfZjt;

				private int VbzXkIuqwaFAdGOkXkgcuZvccpdUA;

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
				public zfBwFZLaBIgfpGZCjnFsVdoijyCcb(int P_0)
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

			private sealed class CAoIGbHvWCTrQxPVXuBFtFjFWJTG : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int jOVDKuPDKXcqEsGIJTgwaKGTgNyF;

				private Platform_Custom.Button eUWSXAxwvJdCfIIIxSLThqiOYneI;

				private int nutLTDKAnGtDETSqNwxFAOphbuyE;

				public Platform_PS5_Base MFsMLPjkPKQnXvgRPkyrMwWkWFxh;

				private int hsofaYfUkwYgOFyojdhGszGFfyRA;

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
				public CAoIGbHvWCTrQxPVXuBFtFjFWJTG(int P_0)
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

			[IteratorStateMachine(typeof(zfBwFZLaBIgfpGZCjnFsVdoijyCcb))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(CAoIGbHvWCTrQxPVXuBFtFjFWJTG))]
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

			private sealed class DAcacqpjVsMaXGHfGZvxJaaYjDNj : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int GZPelrZRYFslaFMDwhDxKlOUOAUb;

				private Platform_Custom.Axis sWTXMJlvSaJxaoryYuMFFuHMoGWs;

				private int XIkcsxkvjRfibiZmpovfFCvuSFUIb;

				public Platform_InternalDriver_Base aDPUEufRBJmbndKqQaCTfNphlisM;

				private int fhYJZuLdvjBoHBIZNYLhqAoKNobZA;

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
				public DAcacqpjVsMaXGHfGZvxJaaYjDNj(int P_0)
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

			private sealed class DPxheNdYqXFpDMdgHgisBUacEzj : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int TmvBNcngtkqmkNWratxecWMHQiKs;

				private Platform_Custom.Button HwBExkgzLWmasTkXgQpwkVRaGBYR;

				private int dembjeAolkUJgtjsYaRdAxFUtbxBb;

				public Platform_InternalDriver_Base NrmZcDrFXJkxcAnzsqGOdOHRxUzd;

				private int vKIAPHBtJFRrvhxsmCjRBZlmJcnl;

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
				public DPxheNdYqXFpDMdgHgisBUacEzj(int P_0)
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

			[IteratorStateMachine(typeof(DAcacqpjVsMaXGHfGZvxJaaYjDNj))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(DPxheNdYqXFpDMdgHgisBUacEzj))]
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

					internal override void omppIeegtgVveHoEpxIJQNOoMDvX(ElementCount_Base P_0)
					{
					}

					internal override bool TUoBFpatPkDWLGgfZKYvzYlAiuFmA(BridgedControllerHWInfo P_0)
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
				private sealed class QHxwhezFSpArBsNDjYBxeKjPZkOp : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int afNwgfGIoNYvuRoDNDUzUdJPNbIC;

					private Axis VQSPLGrhPKXIdxvbWlSeOfYDTYsr;

					private int IAYieTKDyqdlYdinRqqnuNVEhJeHA;

					public Elements kUGMlrkPpPWwsAeWVllBOUszsGQc;

					private int DbnsQyHyVYeUVglNPJvBCikmASUd;

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
					public QHxwhezFSpArBsNDjYBxeKjPZkOp(int P_0)
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

				private sealed class AbogIACDMibNeFQjDlHWvvJKZPAB : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int aDwfCDylGxCBQHhkgejMzLnPboko;

					private Button nuehNBgLQTciNvBwtGjeHAwNomzW;

					private int niYmobMmoQkBzqhsPDthKPgjCsFG;

					public Elements TxoEMCvYhcfsNBtIckHJOgoIxpfE;

					private int cpsFhUWeaYRwcWoKkLBAAOtlzHDI;

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
					public AbogIACDMibNeFQjDlHWvvJKZPAB(int P_0)
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
					[IteratorStateMachine(typeof(QHxwhezFSpArBsNDjYBxeKjPZkOp))]
					get
					{
						return null;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(AbogIACDMibNeFQjDlHWvvJKZPAB))]
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

				public override object DeepClone()
				{
					return null;
				}

				protected override void ImportVars(Element source)
				{
				}
			}

			private sealed class GHxHfmCQfmbkdGvLzOSfmdsWbFmgA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int MyQIsPSoeUDNWPowTwAkqEbBDhPiA;

				private Axis TsqLyaeJDTiefrLWpenhkGsUGNOr;

				private int BYrNrHxuNOFCdNRXjLXXAKvgraQd;

				public Platform_SDL2_Base zTjfwcVXvQwggHHnOQQNwVzbPmfI;

				private int bFCncerLfNsWYrSErbEVxzMkurNu;

				private int HNCdBiDUHEmbwvBsznMwImnBSmiHb;

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
				public GHxHfmCQfmbkdGvLzOSfmdsWbFmgA(int P_0)
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

			private sealed class lkJQxdZdaQcVRqXIPQQlaMPBKYtL : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int DPjlNmwileVKAGZjUeiZurgZfLeB;

				private Button YsHGhBovdWDWgFOOePDrFdayLqNe;

				private int CJNzgTLkMiZVSDmNyPFBlyFKGPVF;

				public Platform_SDL2_Base qBABKPfSqHybCAedvOeJisodmrKpb;

				private int sCyxGJjdIzmmlKjVgoaQnINErVlM;

				private int dJEkmqLMwtQEBefPwnbZgMDUIwbv;

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
				public lkJQxdZdaQcVRqXIPQQlaMPBKYtL(int P_0)
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

			[IteratorStateMachine(typeof(GHxHfmCQfmbkdGvLzOSfmdsWbFmgA))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(lkJQxdZdaQcVRqXIPQQlaMPBKYtL))]
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

			private sealed class HKPhADnLIamKUiaQkyrzixYvwEqI : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int lQZnpslDnYKKxdNbkYqzSeEwoEDL;

				private Platform_Custom.Axis NUPULhitiSJwdFJZroWgmohVTov;

				private int YyMjYebMmFooPzhPLEgrEXGyyEkOA;

				public Platform_WebGL_Base TJrbSCjUNUWicDKhvjNelzIJniqU;

				private int HWXaKOkwNfSipTOnArgyuUyqbZvo;

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
				public HKPhADnLIamKUiaQkyrzixYvwEqI(int P_0)
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

			private sealed class aDMNQBqcQEnyMAsRJTkGUcCMWIVf : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int vOnpQxmWoNPcpshmQZfNzxAgYKKA;

				private Platform_Custom.Button fAIUmwWeTyWnDOWQVKEzoXpbgUWv;

				private int wBsBrXjgwcHVozpSNUdBtIJbJtpwA;

				public Platform_WebGL_Base USSyOQHCuylWQzLevPJGdcBmhQio;

				private int SGQfqWOCAUixITxNBAPCSPajfZUHA;

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
				public aDMNQBqcQEnyMAsRJTkGUcCMWIVf(int P_0)
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

			[IteratorStateMachine(typeof(HKPhADnLIamKUiaQkyrzixYvwEqI))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(aDMNQBqcQEnyMAsRJTkGUcCMWIVf))]
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

			private sealed class VWwMlUSAEluldbWWgJLtWMxuTfNs : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int iGQnVreMjClDXhfqkWCBZCMGHnqv;

				private Platform_Custom.Axis AjsdapCEUlTZEtYTcbzSBozMNvRk;

				private int OdtodJIOCrHskIAtKdSEKOtsXPEd;

				public Platform_AppleGCController_Base ubPAVLrVPoOXdKEEcjfMxUiEsvNH;

				private int sXmUvtOLeRTwuypRpNHIYLWoDcJJA;

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
				public VWwMlUSAEluldbWWgJLtWMxuTfNs(int P_0)
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

			private sealed class QDCLhrSBYDLoRXXeQjESUEXKAhHEA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int DTluPmGmrQBWRcBHOxRdmHjxtaXRA;

				private Platform_Custom.Button wZSsGBzNupfLoIBMeHTrDfnHzZDdc;

				private int ZdbpavNrkVQzwImyxilcDRPgGoAA;

				public Platform_AppleGCController_Base nJUCOsJAUsNTVXXzNPGkUdoZOcOcb;

				private int RYggLBxPHHaGWruYvdYzAWhRBHAZA;

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
				public QDCLhrSBYDLoRXXeQjESUEXKAhHEA(int P_0)
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

			[IteratorStateMachine(typeof(VWwMlUSAEluldbWWgJLtWMxuTfNs))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(QDCLhrSBYDLoRXXeQjESUEXKAhHEA))]
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

			private sealed class BCCDseeJVPdVkMmrTrrhDUIJqUFpA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int HEfPPDErRQpALMPozZHFtfMNwLSp;

				private Platform_Custom.Axis HmDiJUijsumyuStLgkvHkYVXaPoP;

				private int TjaqQIJEwmOZEVjuDgibnBWICtEL;

				public Platform_WindowsWGI_Base UuaPftuRYcxGtrTRrBcQtMSxYWBE;

				private int iMWhpugJEMSqXyYKAkiIRURXqDok;

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
				public BCCDseeJVPdVkMmrTrrhDUIJqUFpA(int P_0)
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

			private sealed class BBGdrjSaFrCmgdDzQGPdPrdMNDQJ : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int lWJDGhmFtiHqpZsZQWoyrLNOumHj;

				private Platform_Custom.Button msqbTQccklwBXYjeSdntqrNgKsYF;

				private int fXyOtVMiRRJUPZpXDbZwBvfYfcMI;

				public Platform_WindowsWGI_Base XOseSoOSOoaTQFttqKpEkdZMPorU;

				private int mCjruevkTudBFIrdTbDvMNwVnlYeb;

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
				public BBGdrjSaFrCmgdDzQGPdPrdMNDQJ(int P_0)
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

			[IteratorStateMachine(typeof(BCCDseeJVPdVkMmrTrrhDUIJqUFpA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(BBGdrjSaFrCmgdDzQGPdPrdMNDQJ))]
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

		private sealed class KgdDHnjdFhDHZjnCeguAqQrKfGQB : IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerable, IEnumerator<IControllerElementIdentifierCommon_Internal>, IEnumerator, IDisposable
		{
			private int hMJBLFmffUpNOGBeuBesutMpbyLI;

			private IControllerElementIdentifierCommon_Internal zykNEeCTsKELlrXGMoHZqeXZGWfU;

			private int zyHMTZprwzcZfXsWGcRiPtiexFAE;

			public HardwareJoystickMap YoqcoKaqEtaySZhpGJFABRHrppAV;

			private int ohoJrzcqukcjxlQECrodKJDrbzTW;

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
			public KgdDHnjdFhDHZjnCeguAqQrKfGQB(int P_0)
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

		private sealed class DaYPpAnQTWMJLYCYKJdNHOqdydYO : IEnumerable<ControllerElementIdentifier>, IEnumerable, IEnumerator<ControllerElementIdentifier>, IEnumerator, IDisposable
		{
			private int QrPBNGJuLVkoLIkcQIBkObUphNBb;

			private ControllerElementIdentifier AgZzHkgGMDdseafyNmnDhmrOpanbb;

			private int BRbiIOrEmzQUNssUVnxCdZAcRHBn;

			public HardwareJoystickMap fPqbjKLfvGWoPXyFbSkNIZiPYnHF;

			private int airGxpLceCnYIocHmiDkBnwtZbwN;

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
			public DaYPpAnQTWMJLYCYKJdNHOqdydYO(int P_0)
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

		private sealed class gZjaKvFadqRJOVIWduTvtgkKhwGE : IEnumerable<JoystickType>, IEnumerable, IEnumerator<JoystickType>, IEnumerator, IDisposable
		{
			private int TDZMJRmaSODERTmdqGHTdWOnkJIAA;

			private JoystickType SUmwvspjePxZuCigahgPRnsEzbdm;

			private int yJJkCZvwPpnogGhtCGCwJGZGKOHyA;

			public HardwareJoystickMap OZifEcjDvQTIXWJwyaxbjwZUnJttA;

			private int yIsvmIshgjyVlFYxkEkSTPiGKtzU;

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
			public gZjaKvFadqRJOVIWduTvtgkKhwGE(int P_0)
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

		private sealed class ZzNYlpZQuuQOKyFcqurlvaFpgJHg : IEnumerable<Guid>, IEnumerable, IEnumerator<Guid>, IEnumerator, IDisposable
		{
			private int VekpOQNRJPjNSivkZeHNkrDcFvUq;

			private Guid KfALpjZFhKppCPBVdvGifkAciQsO;

			private int cudipWqPeABpILGAWDIzlebmzjXI;

			public HardwareJoystickMap wHHVycRsgXFONVbgCQhcxWEgIWZp;

			private Guid[] pQCxnmMdXyDSEWvNfhEaEcmhcrhW;

			private int tfIQZJvUdJtbNgDqCjLKhnWLjqOM;

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
			public ZzNYlpZQuuQOKyFcqurlvaFpgJHg(int P_0)
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_PS5 ps5;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_PSM;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_Fallback fallback_PSVita;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Platform_Fallback fallback_AmazonFireTV;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Platform_WebGL webGL;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		private Guid runtimeControllerGuid => default(Guid);

		private Guid[] runtimeTemplateGuids => null;

		public string ControllerName => null;

		public string EditorControllerName => null;

		public Guid Guid => default(Guid);

		public string Key => null;

		public IEnumerable<Guid> TemplateGuids
		{
			[IteratorStateMachine(typeof(ZzNYlpZQuuQOKyFcqurlvaFpgJHg))]
			get
			{
				return null;
			}
		}

		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers
		{
			[IteratorStateMachine(typeof(DaYPpAnQTWMJLYCYKJdNHOqdydYO))]
			get
			{
				return null;
			}
		}

		public int elementIdentifierCount => 0;

		public bool HideInLists => false;

		internal IEnumerable<JoystickType> JoystickTypes
		{
			[IteratorStateMachine(typeof(gZjaKvFadqRJOVIWduTvtgkKhwGE))]
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
			[IteratorStateMachine(typeof(KgdDHnjdFhDHZjnCeguAqQrKfGQB))]
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
