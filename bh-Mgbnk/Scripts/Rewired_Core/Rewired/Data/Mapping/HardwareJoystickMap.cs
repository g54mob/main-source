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
			private sealed class CWDFUvdmkoegPYzsWpqEYyxRbtct : IEnumerable<Platform>, IEnumerable, IEnumerator<Platform>, IEnumerator, IDisposable
			{
				private int NrnAgOiFZGasuhtMOPyuxRYJdhnG;

				private Platform kHPfuCqNWdiTFWthxGzGisrvqPeL;

				private int ezrfNGwRLCbeRtImRsaPsRKCmvWd;

				public Platform PeGmOemElIxJLWPZUFmhCVPGHJnhA;

				private IList<Platform> ORhDOjLPqjcVzsedEJGiQezhERxGA;

				private int DCDbAvGdpfzClpQawukbkgExuBCdA;

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
				public CWDFUvdmkoegPYzsWpqEYyxRbtct(int P_0)
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
				[IteratorStateMachine(typeof(CWDFUvdmkoegPYzsWpqEYyxRbtct))]
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

				internal virtual void fawGVkbRLpInulLsYcVvUKbIZWmd(ElementCount_Base P_0)
				{
				}

				internal virtual bool UYlJdvddhvjQNSwgiiFHYxXykEWg(BridgedControllerHWInfo P_0)
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

					internal override void fawGVkbRLpInulLsYcVvUKbIZWmd(ElementCount_Base P_0)
					{
					}

					internal override bool UYlJdvddhvjQNSwgiiFHYxXykEWg(BridgedControllerHWInfo P_0)
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
				private sealed class pNupaiAuPmLmkrlmAktAZIVBEWaG : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int yTHeRGHRcOAgntrAmobIwOMFHKxC;

					private Axis_Base KcMHgDmzyMrDOIwJNPHNsmmPmOwx;

					private int YILYQjRZnThIGQoABNWoyQKYbysj;

					public Elements eKTVnZhTVFAQkasNDfSgaAbJfMOF;

					private int RHfdYrFRUwjgNhsxBQvulzVpvcXyb;

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
					public pNupaiAuPmLmkrlmAktAZIVBEWaG(int P_0)
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

				private sealed class uBQgdPWwaWERZsiwUytYyAJdiyBgA : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int wUZcVchTGEbsLMUnYXvowoWQcUOBA;

					private Button_Base WEFjiJETSEFUlrMlgnnHggQKHPew;

					private int YshfucfggkyKdThMxfWOKtCuCXfRA;

					public Elements mPXqpsvkOkSyPGdRPTpWobQLnxHB;

					private int IuVObSkdZzPFOnXAZdlHLfIEnjcC;

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
					public uBQgdPWwaWERZsiwUytYyAJdiyBgA(int P_0)
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
					[IteratorStateMachine(typeof(pNupaiAuPmLmkrlmAktAZIVBEWaG))]
					get
					{
						return null;
					}
				}

				internal override IEnumerable<Button_Base> Buttons
				{
					[IteratorStateMachine(typeof(uBQgdPWwaWERZsiwUytYyAJdiyBgA))]
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

			private sealed class JAzWSoKvtOfFaLMrpfyXaLmHLtdFA : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int DdClKWSLGYWLNGhQEZEvDiomdUsT;

				private Axis_Base nFOQaqptDtGYKzbceKmOxexEVVxA;

				private int UJbComyANMtiiYlFjILCFQcjvDYGA;

				public Platform_DirectInput_Base mgifXhdTWowHJrqhehuuMWeXnTbMA;

				private int pIYZUbfgqXEcPLfgMYKrdFaCiGxfA;

				private int oBobTnViPLXYxmtXfdBQaNOPKdeB;

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
				public JAzWSoKvtOfFaLMrpfyXaLmHLtdFA(int P_0)
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

			private sealed class sLLPlVwUVTWaxzPuBYpJvaCzEIRw : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int KlNmQsYwogKQpkrvuXEaFqaPQLrF;

				private Button_Base VOaulLxMquGcGkBiUngAuEmlEWWoA;

				private int SBuOXxneHsMGVyNcHAPMBJAgVnDb;

				public Platform_DirectInput_Base scxzrdRJAJSoOUIpFysoFgiHIlvm;

				private int dgDqmezLnuDzNaYyoXkjpsKUGPnLA;

				private int dvGKLatZHaFNsIXPXsmRHFZgIaAt;

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
				public sLLPlVwUVTWaxzPuBYpJvaCzEIRw(int P_0)
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

			[IteratorStateMachine(typeof(JAzWSoKvtOfFaLMrpfyXaLmHLtdFA))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(sLLPlVwUVTWaxzPuBYpJvaCzEIRw))]
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
				private sealed class EYbiYSIXOMSPDgVXngcHKCsGLZVO : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
				{
					private int zvCwLaUTCCoObilTlCOTmuosCLDgA;

					private Axis_Base iccpiKPjzyWnWBdeGGqPDQsrhHRp;

					private int YVAhCKMrvjaLqeyRQFfKqsQhBCow;

					public Elements sKsGVcPGvdAVTmTOKCPEqXXzglnd;

					private int sfgHnVeWDdqsGQfJxjqOEbGAYhEg;

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
					public EYbiYSIXOMSPDgVXngcHKCsGLZVO(int P_0)
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

				private sealed class hVFgNdbRAFqWbZQvpooPJaBbBvChA : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
				{
					private int oePOutSkMJQzxKOvnyaHPmnMxblD;

					private Button_Base MuReZrBjjxlJChoGpSFYowEQuHCVA;

					private int FQDELaBjQfZPiWyqwbTVhnIfHuKGb;

					public Elements FINlFxxgxKscuulLMynBmJfoYTDY;

					private int xRyxucOqsODwwUgCMPrAxdrxBTdx;

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
					public hVFgNdbRAFqWbZQvpooPJaBbBvChA(int P_0)
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
					[IteratorStateMachine(typeof(EYbiYSIXOMSPDgVXngcHKCsGLZVO))]
					get
					{
						return null;
					}
				}

				internal override IEnumerable<Button_Base> Buttons
				{
					[IteratorStateMachine(typeof(hVFgNdbRAFqWbZQvpooPJaBbBvChA))]
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

			private sealed class EPstTVRyQuMKTDOyjPfTlDqyqgnu : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int KoCgPkkjGhIOuacvqPCNLmTNGmq;

				private Axis_Base GeXMkXVCEpIhdalPiKodUgaPQBvCA;

				private int CoUdhdgPrzOgoUNQTvyFQWqTVyQC;

				public Platform_RawInput_Base SCIfbdHFocKzrBzVTzGjhZCUUMkPA;

				private int LIQrYSojdYgeJhgHMcgoFFvaYOyk;

				private int jJKfraQLWDMJWakEFxNbZHDIlXBp;

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
				public EPstTVRyQuMKTDOyjPfTlDqyqgnu(int P_0)
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

			private sealed class AVokLQyVFKJpvMqIKpqZavFUoxTH : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int ajPnOstlzaENHFCcjsPIRQmGoZKP;

				private Button_Base EZrANdDRJWDgRqFbgkLvHiOOupzN;

				private int zUsiDMFseMIuaBkjJrtIRbcjekSDA;

				public Platform_RawInput_Base kjHojGeWdWFEDzcrzbDXjfanFxrOA;

				private int PFkhZLclVQUJnkhgxxEHbgfqmmUi;

				private int LVpCnRWgGhgQHbiTClFbSqxdEKWi;

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
				public AVokLQyVFKJpvMqIKpqZavFUoxTH(int P_0)
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

			[IteratorStateMachine(typeof(EPstTVRyQuMKTDOyjPfTlDqyqgnu))]
			internal override IEnumerable<Axis_Base> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(AVokLQyVFKJpvMqIKpqZavFUoxTH))]
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

			private sealed class tndBPkfOgtVPkQaBEdZTMRZQPadk : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int NHMjfaaYmgzNlDtPaJrXlxvmHOpe;

				private Axis BhuGOTfTlvHPrRZCkYcUCUyijlYC;

				private int oRbJwzjQjJGAnnTLQdrWAFdJtifo;

				public Platform_XInput_Base MpvcnHiftbZlsWIPNIuRaFPJrVJWB;

				private int cQGdhvfrwVPUaZBRZJlOpqebhyxU;

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
				public tndBPkfOgtVPkQaBEdZTMRZQPadk(int P_0)
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

			private sealed class XTOikgVOcdCrkzbcBdrwnAZMeaIG : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int ZDXiaAuMPlyCkhyMgNiylxDfagLl;

				private Button MfAWACPNNyFPeInIXvYZQZMdjekG;

				private int TdicUKDoQcYHTnDJhBVSwmoxApwF;

				public Platform_XInput_Base LVURdAzHxpOOLjQOQdmfqRPQSQTy;

				private int AgeslPObYVuppCnuYzQVfzCTKbcX;

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
				public XTOikgVOcdCrkzbcBdrwnAZMeaIG(int P_0)
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

			[IteratorStateMachine(typeof(tndBPkfOgtVPkQaBEdZTMRZQPadk))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(XTOikgVOcdCrkzbcBdrwnAZMeaIG))]
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

					internal override void fawGVkbRLpInulLsYcVvUKbIZWmd(ElementCount_Base P_0)
					{
					}

					internal override bool UYlJdvddhvjQNSwgiiFHYxXykEWg(BridgedControllerHWInfo P_0)
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
				private sealed class CBBpXuDvRMyGOOlTunOMVKmHlFaC : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int ikvExDMkeArIzJvBfcDPmmwUSvpG;

					private Axis tDTMcGllxcvQpzCySeREJeJaaRuaA;

					private int wlxvJYPRHsnnhPiRxGHwHbBiOskjA;

					public Elements UOSETEWvhEScfYQwuTPfFvVoFFWG;

					private Axis[] zXBJcyFLfnahVenMYqsdFfhuIIsk;

					private int eojBGxeOwzrhdEzfklerFjrlzsSx;

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
					public CBBpXuDvRMyGOOlTunOMVKmHlFaC(int P_0)
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

				private sealed class feZeaGWnLndxlTlArlfIPqQiMmuy : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int qddbeNdWnNcvaBUTBdGihFMymOCXA;

					private Button XZejNAnRjoebOJCpRCUVGbxknPWLA;

					private int oTMcDfjZZMlsTIWIIIZVPBUfcQzx;

					public Elements vQSwnIAciiwUHhcLtyFgbtZFlQWl;

					private Button[] YWRNEZUkWUpEDKJDjEsSErWHbVfJA;

					private int dAQFPBPitiIPpNnnzThxBLrqTNsh;

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
					public feZeaGWnLndxlTlArlfIPqQiMmuy(int P_0)
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

				[IteratorStateMachine(typeof(CBBpXuDvRMyGOOlTunOMVKmHlFaC))]
				public IEnumerable<Axis> IterateAxes()
				{
					return null;
				}

				[IteratorStateMachine(typeof(feZeaGWnLndxlTlArlfIPqQiMmuy))]
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

			private sealed class yXDeUsevxMZGxFjbaoxwcVvKvuYdb : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int rOohLBygXdrdUjkrdQLGaEvXgItgA;

				private Axis PVFvHbeXvikJKuvrFMROYgyKAyhu;

				private int oUKbORcjwEUbcGZUKdFVioEFhJWtb;

				public Platform_OSX_Base JypDJfJLjBtQgOStNjdOzImcpGTEb;

				private int HqmcSexsmOaMOyakpBIMbliRMNPSA;

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
				public yXDeUsevxMZGxFjbaoxwcVvKvuYdb(int P_0)
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

			private sealed class wrEEtrwHyfPatztYXrwzGHMPWKBB : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int YCOYJeAtclNDCokOpIIBqIegDGGF;

				private Button hdhaNAfEhDFTYdQshFshjTeccHAU;

				private int FDQBcgsHNWaISCxQLivTSSTkqybf;

				public Platform_OSX_Base aISTkyaTIPrONlBpRdMetgYltPTI;

				private int EOcwiMMZOVTYYBafXGikkILfAyoT;

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
				public wrEEtrwHyfPatztYXrwzGHMPWKBB(int P_0)
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

			[IteratorStateMachine(typeof(yXDeUsevxMZGxFjbaoxwcVvKvuYdb))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(wrEEtrwHyfPatztYXrwzGHMPWKBB))]
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

					internal override void fawGVkbRLpInulLsYcVvUKbIZWmd(ElementCount_Base P_0)
					{
					}

					internal override bool UYlJdvddhvjQNSwgiiFHYxXykEWg(BridgedControllerHWInfo P_0)
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
				private sealed class SvlJKHJugrsnVVpEjokkqqpmPFJN : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int UqhIgepcSGQCLkHtaotLQyIPSOAd;

					private Axis ClvKIPdXjPDOuzzJLMrOHXHVouiP;

					private int eqvfGLcNtnSosDujckQWFjeYYeDx;

					public Elements FJoSTnJuDvdKJeDmZPHRBEcrUEWF;

					private int jgazdsvLugELiEEaouTVjtUNiDPlA;

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
					public SvlJKHJugrsnVVpEjokkqqpmPFJN(int P_0)
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

				private sealed class zAWCuFHRxoPeYjVOKfnSzRNtjBqDb : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int JEUpuvbJJJbmIDHJEnDYeJIefiml;

					private Button aYgooezMIBFMIArxZdRWCsmoIZJSA;

					private int CjRkbavAuBWrtuqcwsVPuMkaPjAV;

					public Elements aSCRdgiaxmVZamazZZaHdXLubQTC;

					private int WHnGkMHLFVpHLkXcaHsIdrwabzGcb;

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
					public zAWCuFHRxoPeYjVOKfnSzRNtjBqDb(int P_0)
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
					[IteratorStateMachine(typeof(SvlJKHJugrsnVVpEjokkqqpmPFJN))]
					get
					{
						return null;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(zAWCuFHRxoPeYjVOKfnSzRNtjBqDb))]
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

			private sealed class TxJlLYluapbPZPvOEFPKDEgleohCA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int kjvDoZkEApPKpdQaHjmlGZUiqdTy;

				private Axis YDZUktKAdTBcpKrVAnLXwbATfiWu;

				private int vXgMFsiqmTdZhXmAaGFFGBvgYHiuA;

				public Platform_Linux_Base oXCfbZxjswVrJfDjszejekqsRIVl;

				private int muNiogyGaHcASNKiTHRIkIDjhxVlA;

				private int qALrNfDnzZDeeiFikdMSHrnkLdnjA;

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
				public TxJlLYluapbPZPvOEFPKDEgleohCA(int P_0)
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

			private sealed class HHEGEEKwLjGXmkHvYKNYhdyvxair : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int lZlrUkfXQZrbLyNIGFYPFkoTxFlh;

				private Button pJzsSFbuOjcUFuyhYDGjFJUKlcoX;

				private int wBNTAYBQtchxTxWQbFsykTpPEhsxA;

				public Platform_Linux_Base NPHfbnHNpPxLJvnxNkVfhMSWmgWr;

				private int PjEzsivepldsNpVfJAdmymBFgYjL;

				private int EfDALrleVDhKZOIPZGYcnBpDQFcd;

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
				public HHEGEEKwLjGXmkHvYKNYhdyvxair(int P_0)
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

			[IteratorStateMachine(typeof(TxJlLYluapbPZPvOEFPKDEgleohCA))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(HHEGEEKwLjGXmkHvYKNYhdyvxair))]
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

					internal override void fawGVkbRLpInulLsYcVvUKbIZWmd(ElementCount_Base P_0)
					{
					}

					internal override bool UYlJdvddhvjQNSwgiiFHYxXykEWg(BridgedControllerHWInfo P_0)
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
				private sealed class BnMQtCDxRZvmPXgxnCqOMIeDvjYw : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int IyDcXZPJyuEByQZjsVmzTvzgOoPG;

					private Axis JVbEsYwaZFeMiHPFPhOUTHwyWzmZ;

					private int CAowZqTMILCWmQbzkLGOmmXIDRNE;

					public Elements ILYLmfZbRcsrZfCeEOsSIlvLpNIp;

					private int XybPtixJOFDqoCCLWuFVZxziVVTQ;

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
					public BnMQtCDxRZvmPXgxnCqOMIeDvjYw(int P_0)
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

				private sealed class ikVrlNviVdqfdapzdKqUpcKlHSgH : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int vhKdALTnnheGLHTkcIHoHMMTlCLOA;

					private Button bnHjxUqEYdcsUNvAjoTVugmGfSYk;

					private int VFEseayFFYRzthcFRVWSDhCNplRt;

					public Elements IvKjKKfWIhQUIRKpXajafTADRjegb;

					private int UMTyNlkRKiErKCQyzhPTzKMkAWvU;

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
					public ikVrlNviVdqfdapzdKqUpcKlHSgH(int P_0)
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
					[IteratorStateMachine(typeof(BnMQtCDxRZvmPXgxnCqOMIeDvjYw))]
					get
					{
						return null;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(ikVrlNviVdqfdapzdKqUpcKlHSgH))]
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

			private sealed class JTuTzWgyeZNYrhubZMXqoXLFKSVe : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int CdDblCjYstgQtJqVVydlUQIYDlxFb;

				private Axis fuMUvxbFDwiSZNkpwmexwnwfbXMBA;

				private int lYTMkcYFSCVlRBuuUKFYZrQuvfhF;

				public Platform_WindowsUWP_Base jGFjPTXlUcMROnxyeqbYDtNcFmNt;

				private int QbnbxDJWfBjAycbjWgLcKNkTGdD;

				private int HAdaRmhtdIHqfRsqddkOPHKYczZu;

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
				public JTuTzWgyeZNYrhubZMXqoXLFKSVe(int P_0)
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

			private sealed class FgFMccYjRjFiaJfBHNjBEKkFGcUpA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int hXLQnvmNEcGUHaePBaCRdibMNvYU;

				private Button XYRcRAcdFvDGvqCyLkhPRchIwbHX;

				private int PYDBgzlqLrTaEiHUOEhJerUEpJZO;

				public Platform_WindowsUWP_Base oGlOqQybBWyWnDuIoIRTQLhYzEQD;

				private int povGXBmselDfxXDfhuzqhwSnxQUB;

				private int XxRJJDfqvqNMUvvqSUwoVrlJJHHF;

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
				public FgFMccYjRjFiaJfBHNjBEKkFGcUpA(int P_0)
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

			[IteratorStateMachine(typeof(JTuTzWgyeZNYrhubZMXqoXLFKSVe))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(FgFMccYjRjFiaJfBHNjBEKkFGcUpA))]
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

			private sealed class CTWqKkWIsxvjkOSxppKNmRfBLahJ : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int kiLCxomWPxrKGIXkTlRZlVmzSUbi;

				private Axis qHATqDKEHjirDhNOVXGbTBhgRpHU;

				private int ipcpfySYltJopVlMmZhGoqwMhVHV;

				public Platform_Fallback_Base vVSIjedlPFUNNkRRXvaXLeQDfNSI;

				private int ECtLhGSXncCHVySjLKGJvIvDpjSN;

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
				public CTWqKkWIsxvjkOSxppKNmRfBLahJ(int P_0)
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

			private sealed class amAdwQwzuxMednauIGyPtLotdRcC : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int uUNgZwluywETckNVIfNhpJyvUcEB;

				private Button hjVgAdxcANvOzxZvQIizyBQABHUfA;

				private int SbEyRxnIchSvcCcTvIeFcvGaBzSV;

				public Platform_Fallback_Base GXGYcSZRfKUaufEKeCQiEiQghSof;

				private int psaVubumKLoZhuoyFcfKpLmgEyhcA;

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
				public amAdwQwzuxMednauIGyPtLotdRcC(int P_0)
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

			[IteratorStateMachine(typeof(CTWqKkWIsxvjkOSxppKNmRfBLahJ))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(amAdwQwzuxMednauIGyPtLotdRcC))]
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

			private sealed class VDedXnPaTFeIHnUVMELchkNRNbobA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int dmwMKaSuNKpLITWuvwjAhgBDOrzF;

				private Platform_Custom.Axis ztpCZtAvzMKRcXlMBbyBruzdKZCaA;

				private int klWOMvwVduNdDqIiQZbqWsOnBKZn;

				public Platform_XboxOne_Base DHqFIwkQyIDbJvgBrTQLlFBrLgxjb;

				private int rsUdgmXtMTaSJiVdBaFSxlFarwPAA;

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
				public VDedXnPaTFeIHnUVMELchkNRNbobA(int P_0)
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

			private sealed class dpVJlGxEEtjESoZHvlRUlMoqPyBt : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int KVtAULQDhIDPJlUElOpsqfHwANvL;

				private Platform_Custom.Button VCghMkjdBujYmXGwWrYRzEOfXRxW;

				private int CSmiaNwjkvCvbvSerCEIQBYYBuzP;

				public Platform_XboxOne_Base macdfPhqZqKiFcIPWXcpfQngEpWcc;

				private int mfQaWFHDZHgwNEwYypnQRfcARRcq;

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
				public dpVJlGxEEtjESoZHvlRUlMoqPyBt(int P_0)
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

			[IteratorStateMachine(typeof(VDedXnPaTFeIHnUVMELchkNRNbobA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(dpVJlGxEEtjESoZHvlRUlMoqPyBt))]
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

			private sealed class NFBApTQOduMXxwdDTRqUsMppitOA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int czZdZPhGtSkVlSHLkAavXWYLyegAA;

				private Platform_Custom.Axis osoYrcHjayErkEcJHeitGyGejTFPB;

				private int vrInbWVkxJwpvwtCJuhWYQMOsnkv;

				public Platform_PS4_Base RtGzmYGPCFiNDNZRAiPrsElzFhBJA;

				private int jZbmgDaYXazvYltcKLXSxnilfWKB;

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
				public NFBApTQOduMXxwdDTRqUsMppitOA(int P_0)
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

			private sealed class mPDxybtMgyKBfMfYvebfXxhLDQUIA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int DSqYOuHkCgZdxIGBnmbeqVqHMjzd;

				private Platform_Custom.Button YlcIDAjuCDGqYccnkjaeJKsnJrSsA;

				private int OGIQvYfBMPzkArHceUpSctgtaafx;

				public Platform_PS4_Base HEXpCFJObQIsSzlxFgraKwZqVVib;

				private int HmVgZLjkClrCVuShJvJefBJHxvGU;

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
				public mPDxybtMgyKBfMfYvebfXxhLDQUIA(int P_0)
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

			[IteratorStateMachine(typeof(NFBApTQOduMXxwdDTRqUsMppitOA))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(mPDxybtMgyKBfMfYvebfXxhLDQUIA))]
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

			private sealed class NSafLpbZzYyWwDEcCrjcGSBmItBR : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int QQLMtVfqvKhCvfOaaojmwznBfoqF;

				private Platform_Custom.Axis yIMpJkMDzjWzwqISXKwlzhuwmSiB;

				private int cWgfQrRkBuKCUSpyQkJlUDfgOhWw;

				public Platform_NintendoSwitch_Base TZiDhJPEpRBRtaRqucpdrrPKJlGAb;

				private int MeXGJbZLMitkClglDqfqebiaFREW;

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
				public NSafLpbZzYyWwDEcCrjcGSBmItBR(int P_0)
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

			private sealed class UWwlVYbcgsRiPKmgvLJfySwcqNJl : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int HWssmANQhAAJiocVfMQmynhQspSg;

				private Platform_Custom.Button CSspyYnlcVQjUpLlJcVWgpHgEKwzA;

				private int iXGjhZmleWAUfjutfpiwcRyYDdBO;

				public Platform_NintendoSwitch_Base rmWEcXacJJhhwAngMszdRsHrEnVT;

				private int ACNnAyRTEHwPExiUpgmcKROVVAQl;

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
				public UWwlVYbcgsRiPKmgvLJfySwcqNJl(int P_0)
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

			[IteratorStateMachine(typeof(NSafLpbZzYyWwDEcCrjcGSBmItBR))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(UWwlVYbcgsRiPKmgvLJfySwcqNJl))]
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

			private sealed class fofTqkZlXDGpdDGlJCyQFajIRfqK : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int eJKbCqekZWhcKumUpiAVxLsdFTAO;

				private Platform_Custom.Axis dNZXMLgxxmOhWenlcoBrrRYeVBDF;

				private int LYjKHUBhkcqCKYvPNAaLeghMjDgL;

				public Platform_GameCore_Base BgIFyRLnRGTfaaTtnoyglDgypuoo;

				private int gOsqxAkIzucYemPbQdWKiyTWRtYn;

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
				public fofTqkZlXDGpdDGlJCyQFajIRfqK(int P_0)
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

			private sealed class UyPBczrLVdnBlADsQCMHaLIqVAyM : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int XjzwkoPcueTdoizGZbxboShPDFPX;

				private Platform_Custom.Button TpMxErYalFAsXfkmLJjbRrzRCcsbA;

				private int iJxNEqGjdvFUMiVdrLiTDkOgDeJg;

				public Platform_GameCore_Base CXCIWstgyzMpWSCExAymHcOcxUoX;

				private int sGopGSSGzadDsqhFxsDmWasIMoKc;

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
				public UyPBczrLVdnBlADsQCMHaLIqVAyM(int P_0)
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

			[IteratorStateMachine(typeof(fofTqkZlXDGpdDGlJCyQFajIRfqK))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(UyPBczrLVdnBlADsQCMHaLIqVAyM))]
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

			private sealed class cxWLVVQlwVMqrjNJSlWMrqIWatHC : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int FDDjhPKBPUQuFFEnEnUveMZbbIGac;

				private Platform_Custom.Axis pjfQXkMztFpkUTBNPAgQIQmFSBYy;

				private int PKKcEeFfkJEcfudecRtoDKeEkInCA;

				public Platform_PS5_Base pQvZxGPdOTHLvNrsqackDrYoOBgu;

				private int YAmwEYzFQhnxvcrrwArANOhQpByJ;

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
				public cxWLVVQlwVMqrjNJSlWMrqIWatHC(int P_0)
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

			private sealed class BZnOGtSZoNmeCFAWqdSthjzdHGCz : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int kNCuBwYBsKwPUMIPoKzEigEdLudS;

				private Platform_Custom.Button hBPuKYgMKKkGtgWNWtgnrzckrIpN;

				private int yBcTLTLlDHcQKgxvuXGnMSfPkfbsA;

				public Platform_PS5_Base TNzwUFcqzDjVZRBGkEEPKtQUpQyo;

				private int cUjDxsioypVngvtrZNHVDkjiaprhc;

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
				public BZnOGtSZoNmeCFAWqdSthjzdHGCz(int P_0)
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

			[IteratorStateMachine(typeof(cxWLVVQlwVMqrjNJSlWMrqIWatHC))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(BZnOGtSZoNmeCFAWqdSthjzdHGCz))]
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

			private sealed class AZhWagszHxvUZeAgvirBROwizhIM : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int NMODafEGvZiLtJrTZOHpPIdgaWHYA;

				private Platform_Custom.Axis bPQSuNsopjINmWbKjekzXXXeUHJB;

				private int QApcepwFcIRArrixQPVROFlIZSPF;

				public Platform_InternalDriver_Base dWIYDqufjGIsnDfvbwqpvpvTwJdh;

				private int yORTQoGDDsFFJsmUyYdXQcachekY;

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
				public AZhWagszHxvUZeAgvirBROwizhIM(int P_0)
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

			private sealed class IpQfrcBCNthefqzNNlhOHkIUyguSA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int KDiFXmaNHfqDibbaZqHOmOItdcRcA;

				private Platform_Custom.Button EaQFbctLzJaLsroGFyHWmPNCSNVq;

				private int cPpxMorRZnaLoRxGbtCFbiZwnicf;

				public Platform_InternalDriver_Base ASrBPHdujQaDqrmqLDAkDbMAzhqVB;

				private int sIHqYLQRtQkwnVzdVNqfXBdAhLmZ;

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
				public IpQfrcBCNthefqzNNlhOHkIUyguSA(int P_0)
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

			[IteratorStateMachine(typeof(AZhWagszHxvUZeAgvirBROwizhIM))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(IpQfrcBCNthefqzNNlhOHkIUyguSA))]
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

					internal override void fawGVkbRLpInulLsYcVvUKbIZWmd(ElementCount_Base P_0)
					{
					}

					internal override bool UYlJdvddhvjQNSwgiiFHYxXykEWg(BridgedControllerHWInfo P_0)
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
				private sealed class NscKqgarucnCHSiAQTtNmkhdaaDFA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
				{
					private int nOICgbINmCMtkupfuqrTHClxfPDZA;

					private Axis IjFFbAqNzXfHjXEipcVESNErMnfm;

					private int FjXywNLeGjGACCKucAGDjTPmEJpCb;

					public Elements bVJwKfzRpYIrceXpoaVxASQJOoRAA;

					private int IpoxamWZIDsZNQWsoKbpSqyOiSFN;

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
					public NscKqgarucnCHSiAQTtNmkhdaaDFA(int P_0)
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

				private sealed class VWyfcCkXjDwQZVjBcvJrrSnedPMFA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
				{
					private int lMrBQLdziqPkQvpxXlBszdjxNmhM;

					private Button qFxnpThkgKiXDPQvYaVGCJqhnwkHA;

					private int qRHZsrDpCPLPtAZfcDfDWdeLnIYp;

					public Elements IueDGQBcuxlAuXjsHIWtEGoaZjajA;

					private int znjTVWDCGJFemdwDBThgpSfHMvQTA;

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
					public VWyfcCkXjDwQZVjBcvJrrSnedPMFA(int P_0)
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
					[IteratorStateMachine(typeof(NscKqgarucnCHSiAQTtNmkhdaaDFA))]
					get
					{
						return null;
					}
				}

				internal IEnumerable<Button> Buttons
				{
					[IteratorStateMachine(typeof(VWyfcCkXjDwQZVjBcvJrrSnedPMFA))]
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

			private sealed class PckBtuRDNhaVtmxEMIiXIeoemPpsA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int HoRsNDVzUBsWGzdlsoBIejhffrQr;

				private Axis STnoeqtZjGJdhTENCHOXcvsutNTV;

				private int AucvRJwcQVwerhAGEalbAYGIfpTfA;

				public Platform_SDL2_Base oZurzuEXjFxBypuynAelaTtDrTkS;

				private int inBkYowLXIzECTNTQeFbtBQMivOy;

				private int MYBXuMFrCBSGgzxeCiGWaAddovbh;

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
				public PckBtuRDNhaVtmxEMIiXIeoemPpsA(int P_0)
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

			private sealed class acIKCtKhMNMkPSEXwLcXyqNtKCop : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int CcAJjTKdKeqeCjeIAzWYzqzprfUdb;

				private Button NTMaMBixZVZyiMdNJovFMJvKAFGyA;

				private int DkYXdJAqyjDkMlPKZblvfdXeWGAq;

				public Platform_SDL2_Base vuVILTVOUUITAGqjCOpnampSzmFe;

				private int dhnADFmKaqZotafARUholGNkfHoo;

				private int aMXsrsMWMarYDWlGPLElmDByiokx;

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
				public acIKCtKhMNMkPSEXwLcXyqNtKCop(int P_0)
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

			[IteratorStateMachine(typeof(PckBtuRDNhaVtmxEMIiXIeoemPpsA))]
			internal IEnumerable<Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(acIKCtKhMNMkPSEXwLcXyqNtKCop))]
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

			private sealed class MRAsbLwYsxjLMQSTDDEHosWLPqrs : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int qLISxwePVJRrjNRiPTuZYiWEfcWz;

				private Platform_Custom.Axis OTZFCThkLvoqofZKqiWydeyFFHhSB;

				private int NNNYOmmzEUXzHPkEmYgZPNWGUBxi;

				public Platform_WebGL_Base KgwEEGamlHKTcdrmUovSjnGrMqhS;

				private int MFAGIYlJzgSTldfqryYWueuUNDuM;

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
				public MRAsbLwYsxjLMQSTDDEHosWLPqrs(int P_0)
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

			private sealed class lMPxVRxpCHvMWsmzoGjqjYemBSAKA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int gUFChGJtsloyusWwXzrNdhvqFUDlA;

				private Platform_Custom.Button itZiYyRblvYSLwhHgmGLmStHQWJi;

				private int puvtNJjEuzuCcXDKeJmpKDtTbLgD;

				public Platform_WebGL_Base BrLSuEAISjFYUcXjWLfaMhTGqIzY;

				private int RLZjzUXfmVHGAlMSgedwIOuZAHFvA;

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
				public lMPxVRxpCHvMWsmzoGjqjYemBSAKA(int P_0)
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

			[IteratorStateMachine(typeof(MRAsbLwYsxjLMQSTDDEHosWLPqrs))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(lMPxVRxpCHvMWsmzoGjqjYemBSAKA))]
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

			private sealed class QzdlyYFSeeOEfZcLFhhXGxvGTjGq : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int ntTyhzdygDLQTRkhHFshZcIeTnzR;

				private Platform_Custom.Axis LnzGolLnoogkOKXENBFkYZveKDAKA;

				private int RquesJTuomgwwbcTjSXaMXEUDXLaA;

				public Platform_AppleGCController_Base tiGpCXeyhznlpeERZwJijGeiEsWCA;

				private int lyxvMzLSKUXcaMMSIlzyIMhIasWD;

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
				public QzdlyYFSeeOEfZcLFhhXGxvGTjGq(int P_0)
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

			private sealed class VsFbPtFFoQDXTfCrtBoqMqZsadACA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int CaaTYyDGJVrRNnLEfpGFJDrNkiSp;

				private Platform_Custom.Button nSLCCTsKWswXijqLHrmNfojHRgQl;

				private int EUmFdwdeZhezlPInHOWVDoLzeOzKA;

				public Platform_AppleGCController_Base aaREGgBqPzqgFbJocqxClivboCJh;

				private int EbvTVDoghMbtCHtFMmiRYhrdFPVm;

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
				public VsFbPtFFoQDXTfCrtBoqMqZsadACA(int P_0)
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

			[IteratorStateMachine(typeof(QzdlyYFSeeOEfZcLFhhXGxvGTjGq))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(VsFbPtFFoQDXTfCrtBoqMqZsadACA))]
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

			private sealed class CNLkkMQzCAycbGqVqHTtAAFbCWlB : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
			{
				private int MXoNlTDuhFpSZiofSrfdnaMlkDRt;

				private Platform_Custom.Axis GHYBLKjVObMJuaxIZOLxmCVrmZhq;

				private int QjjUcEGGElQnYzKdubAVtZSqlQZu;

				public Platform_WindowsWGI_Base RBvSNdnvizIWjReAGcfofQWZEAWIA;

				private int xGVqnudnqLivNUbZhlScLLRvHofy;

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
				public CNLkkMQzCAycbGqVqHTtAAFbCWlB(int P_0)
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

			private sealed class UiPvtlZyfmLlqVRkxMqJDPzoADDM : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
			{
				private int sdOvZzfxPfoTrfPOzaqSpHLswjIi;

				private Platform_Custom.Button zDjTtGdVKapVLknprFXDhiZEhIHTA;

				private int oEjrkDVQhSrnXnYOexsQLxhobCVi;

				public Platform_WindowsWGI_Base OxldGyNNwhYgQhxaRPHwsKBwRkgS;

				private int hJmkgcyLndwqBZTaoxwZLwsttDHf;

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
				public UiPvtlZyfmLlqVRkxMqJDPzoADDM(int P_0)
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

			[IteratorStateMachine(typeof(CNLkkMQzCAycbGqVqHTtAAFbCWlB))]
			internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
			{
				return null;
			}

			[IteratorStateMachine(typeof(UiPvtlZyfmLlqVRkxMqJDPzoADDM))]
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

		private sealed class DDsFLFDuJkQwNSNsLSWMscMmOrLwA : IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerable, IEnumerator<IControllerElementIdentifierCommon_Internal>, IEnumerator, IDisposable
		{
			private int uFYTBVjIHTITOcjtBKjOeJKLtlQP;

			private IControllerElementIdentifierCommon_Internal eRboPgJECDVdzDMPvNGjsyZlGOwX;

			private int mNACWLBmXyNXRBtxjlKhfFzyOjLDB;

			public HardwareJoystickMap XlhDkQvPwewJMbBcpApqBTBLojVeA;

			private int pOhvSzrgGneSpHiLnFCFkAVDivUYA;

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
			public DDsFLFDuJkQwNSNsLSWMscMmOrLwA(int P_0)
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

		private sealed class QcBlNQqttFsvVoTsjBEtJAyZbmNh : IEnumerable<ControllerElementIdentifier>, IEnumerable, IEnumerator<ControllerElementIdentifier>, IEnumerator, IDisposable
		{
			private int DYiEZJBCYOwZosgfPImxfGbAgnUxB;

			private ControllerElementIdentifier LgOFacnFoINmyRntsVttwPjaukaK;

			private int KYaYkUsDSmelROCXusHqfLWKbTOaA;

			public HardwareJoystickMap qkhTzKSIHPKxDvoQIoqvYdchLCSv;

			private int lekdhzEdYXWnICKAFnrYRHyPaztz;

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
			public QcBlNQqttFsvVoTsjBEtJAyZbmNh(int P_0)
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

		private sealed class fWebeGkUSdkyKIpDAYKPQdgyDdJEb : IEnumerable<JoystickType>, IEnumerable, IEnumerator<JoystickType>, IEnumerator, IDisposable
		{
			private int IOYiUTnEkBCpJbjqPuthNAINHLLXA;

			private JoystickType DpxtmiepOUBUqqmrHKZzVEoqHjiw;

			private int nmIGuJszxmDsscFafsRWWnRcKPIj;

			public HardwareJoystickMap HxYScKNDTdWBbBrNiTPgsHggNcS;

			private int pAdorEzbAkkornioVAMmLcmgdQoK;

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
			public fWebeGkUSdkyKIpDAYKPQdgyDdJEb(int P_0)
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

		private sealed class WkCPSvYqUvmbACUhVuMDpuBVgrQl : IEnumerable<Guid>, IEnumerable, IEnumerator<Guid>, IEnumerator, IDisposable
		{
			private int GynUkWYqpIolASfzghwxgZDIvSHi;

			private Guid ZnXvAjMcNRcAIzVKKgcOtfWMsWdr;

			private int tFungEpLGNuUAdzNnnTLxOzAfXEF;

			public HardwareJoystickMap fUSchqOhWInfZjMdvTWIvJIMGHAL;

			private Guid[] eLLutgLyzrgoQiwWOKFAKrkLBvmV;

			private int sQDNIJwLJKgGFBAvjIdsthInfePzA;

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
			public WkCPSvYqUvmbACUhVuMDpuBVgrQl(int P_0)
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
			[IteratorStateMachine(typeof(WkCPSvYqUvmbACUhVuMDpuBVgrQl))]
			get
			{
				return null;
			}
		}

		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers
		{
			[IteratorStateMachine(typeof(QcBlNQqttFsvVoTsjBEtJAyZbmNh))]
			get
			{
				return null;
			}
		}

		public int elementIdentifierCount => 0;

		public bool HideInLists => false;

		internal IEnumerable<JoystickType> JoystickTypes
		{
			[IteratorStateMachine(typeof(fWebeGkUSdkyKIpDAYKPQdgyDdJEb))]
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
			[IteratorStateMachine(typeof(DDsFLFDuJkQwNSNsLSWMscMmOrLwA))]
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
