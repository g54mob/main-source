using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Rewired.Data.Mapping;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Platforms.Custom
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public abstract class HardwareJoystickMapCustomPlatformMap : HardwareJoystickMap.Platform_Custom
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Elements : HardwareJoystickMap.Platform_Custom.Elements
		{
			[Tooltip("The list of axes in this controller.")]
			public Axis[] axes;

			[Tooltip("The list of buttons in this controller.")]
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

			internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
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
		public new sealed class Button : HardwareJoystickMap.Platform_Custom.Button
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
		public new sealed class Axis : HardwareJoystickMap.Platform_Custom.Axis
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

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new abstract class MatchingCriteria : HardwareJoystickMap.Platform_Custom.MatchingCriteria
		{
			[Tooltip("If enabled, name strings can contain regular expressions for matching.")]
			public bool nameUseRegex;

			[Tooltip("A list of string names to match on. If defined, any matching name will result in a match.")]
			public string[] name;

			internal override bool hasData => true;

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

			public virtual bool Matches(object customIdentifier)
			{
				return false;
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
				if (bridgedControllerHWInfo.userCustomIdentifier != null && Matches(bridgedControllerHWInfo.userCustomIdentifier))
				{
					return true;
				}
				string text = bridgedControllerHWInfo.hw_productName;
				if (text == null)
				{
					text = string.Empty;
				}
				text = text.Trim();
				if (name != null)
				{
					for (int i = 0; i < name.Length; i++)
					{
						string searchFor = name[i];
						if (HardwareJoystickMap.MatchingCriteria_Base.StringMatches(text, searchFor, nameUseRegex))
						{
							return true;
						}
					}
				}
				return false;
			}

			protected abstract object CreateInstance();

			protected virtual void DeepClone(object destination)
			{
			}

			public override object DeepClone()
			{
				object obj = CreateInstance();
				if (obj == null)
				{
					throw new ArgumentNullException("Returned object is null.");
				}
				if (!(obj is MatchingCriteria matchingCriteria))
				{
					throw new Exception("Object does not inherit from " + typeof(MatchingCriteria).Name + ".");
				}
				if (matchingCriteria == this)
				{
					throw new Exception("Returned object is self. This is not supported.");
				}
				DeepClone(obj);
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.nameUseRegex = nameUseRegex;
					matchingCriteria.name = ArrayTools.ShallowCopy(name);
				}
			}
		}

		[Tooltip("The list of controller elements.")]
		public Elements elements;

		private HardwareJoystickMap.Platform_Custom.Axis[] _axesOrigGame;

		private HardwareJoystickMap.Platform_Custom.Button[] _buttonsOrigGame;

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

		internal override InputPlatform platform => InputPlatform.Custom;

		internal override HardwareJoystickMap.Platform_Custom.Axis[] Axes
		{
			get
			{
				if (_axesOrigGame == null)
				{
					Axis[] axes_orig = Axes_orig;
					if (axes_orig != null)
					{
						_axesOrigGame = new HardwareJoystickMap.Platform_Custom.Axis[axes_orig.Length];
						for (int i = 0; i < axes_orig.Length; i++)
						{
							_axesOrigGame[i] = axes_orig[i];
						}
					}
				}
				return _axesOrigGame;
			}
		}

		internal override HardwareJoystickMap.Platform_Custom.Button[] Buttons
		{
			get
			{
				if (_buttonsOrigGame == null)
				{
					Button[] buttons_orig = Buttons_orig;
					if (buttons_orig != null)
					{
						_buttonsOrigGame = new HardwareJoystickMap.Platform_Custom.Button[buttons_orig.Length];
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
				if (assignedButtonCount == 0 && assignedAxisCount == 0)
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

		internal override HardwareJoystickMap.Elements_Base elements_base => elements;

		public override IList<HardwareJoystickMap.Platform> GetVariants()
		{
			return null;
		}

		protected abstract object CreateInstance();

		protected virtual void DeepClone(object destination)
		{
		}

		public override object DeepClone()
		{
			object obj = CreateInstance();
			if (obj == null)
			{
				throw new ArgumentNullException("Returned object is null.");
			}
			if (!(obj is HardwareJoystickMapCustomPlatformMap hardwareJoystickMapCustomPlatformMap))
			{
				throw new Exception("Object does not inherit from " + typeof(HardwareJoystickMapCustomPlatformMap).Name + ".");
			}
			if (hardwareJoystickMapCustomPlatformMap == this)
			{
				throw new Exception("Returned object is self. This is not supported.");
			}
			DeepClone(obj);
			CopyVars(hardwareJoystickMapCustomPlatformMap);
			return hardwareJoystickMapCustomPlatformMap;
		}

		internal override void CopyVars(HardwareJoystickMap.Platform destination)
		{
			base.CopyVars(destination);
			if (destination is HardwareJoystickMapCustomPlatformMap hardwareJoystickMapCustomPlatformMap)
			{
				hardwareJoystickMapCustomPlatformMap.elements = MiscTools.DeepClone(elements);
			}
		}
	}
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public abstract class HardwareJoystickMapCustomPlatformMap<TMatchingCriteria> : HardwareJoystickMapCustomPlatformMap where TMatchingCriteria : HardwareJoystickMapCustomPlatformMap.MatchingCriteria
	{
		private sealed class nImIiAzFhIGEkxdeGGkqydwVoneJ : IDisposable, IEnumerable, IEnumerator, IEnumerable<HardwareJoystickMap.Platform_Custom.Axis>, IEnumerator<HardwareJoystickMap.Platform_Custom.Axis>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private HardwareJoystickMap.Platform_Custom.Axis vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public HardwareJoystickMapCustomPlatformMap<TMatchingCriteria> zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

			HardwareJoystickMap.Platform_Custom.Axis IEnumerator<HardwareJoystickMap.Platform_Custom.Axis>.Current
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
			public nImIiAzFhIGEkxdeGGkqydwVoneJ(int P_0)
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
				HardwareJoystickMapCustomPlatformMap<TMatchingCriteria> hardwareJoystickMapCustomPlatformMap = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				switch (num)
				{
				default:
					return false;
				case 0:
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					if (hardwareJoystickMapCustomPlatformMap.elements == null || hardwareJoystickMapCustomPlatformMap.elements.axes == null)
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
				if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < hardwareJoystickMapCustomPlatformMap.elements.axes.Length)
				{
					vjnbYLtrPMftzpjohNfommerCnGo = hardwareJoystickMapCustomPlatformMap.elements.axes[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
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
			IEnumerator<HardwareJoystickMap.Platform_Custom.Axis> IEnumerable<HardwareJoystickMap.Platform_Custom.Axis>.GetEnumerator()
			{
				nImIiAzFhIGEkxdeGGkqydwVoneJ nImIiAzFhIGEkxdeGGkqydwVoneJ2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					nImIiAzFhIGEkxdeGGkqydwVoneJ2 = this;
				}
				else
				{
					nImIiAzFhIGEkxdeGGkqydwVoneJ2 = new nImIiAzFhIGEkxdeGGkqydwVoneJ(0);
					nImIiAzFhIGEkxdeGGkqydwVoneJ2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				return nImIiAzFhIGEkxdeGGkqydwVoneJ2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<HardwareJoystickMap.Platform_Custom.Axis>)this).GetEnumerator();
			}
		}

		private sealed class OfUEFQORHLEGLIfqGmJukpegblyY : IDisposable, IEnumerable, IEnumerator, IEnumerable<HardwareJoystickMap.Platform_Custom.Button>, IEnumerator<HardwareJoystickMap.Platform_Custom.Button>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private HardwareJoystickMap.Platform_Custom.Button vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public HardwareJoystickMapCustomPlatformMap<TMatchingCriteria> zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

			HardwareJoystickMap.Platform_Custom.Button IEnumerator<HardwareJoystickMap.Platform_Custom.Button>.Current
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
			public OfUEFQORHLEGLIfqGmJukpegblyY(int P_0)
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
				HardwareJoystickMapCustomPlatformMap<TMatchingCriteria> hardwareJoystickMapCustomPlatformMap = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				switch (num)
				{
				default:
					return false;
				case 0:
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					if (hardwareJoystickMapCustomPlatformMap.elements == null || hardwareJoystickMapCustomPlatformMap.elements.buttons == null)
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
				if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < hardwareJoystickMapCustomPlatformMap.elements.buttons.Length)
				{
					vjnbYLtrPMftzpjohNfommerCnGo = hardwareJoystickMapCustomPlatformMap.elements.buttons[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
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
			IEnumerator<HardwareJoystickMap.Platform_Custom.Button> IEnumerable<HardwareJoystickMap.Platform_Custom.Button>.GetEnumerator()
			{
				OfUEFQORHLEGLIfqGmJukpegblyY ofUEFQORHLEGLIfqGmJukpegblyY;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					ofUEFQORHLEGLIfqGmJukpegblyY = this;
				}
				else
				{
					ofUEFQORHLEGLIfqGmJukpegblyY = new OfUEFQORHLEGLIfqGmJukpegblyY(0);
					ofUEFQORHLEGLIfqGmJukpegblyY.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				return ofUEFQORHLEGLIfqGmJukpegblyY;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<HardwareJoystickMap.Platform_Custom.Button>)this).GetEnumerator();
			}
		}

		[Tooltip("User-defined matching criteria. Determines whether this platform map matches to a particular controller.")]
		public TMatchingCriteria matchingCriteria;

		internal override bool hasData
		{
			get
			{
				if (base.hasData)
				{
					return true;
				}
				if (matchingCriteria == null)
				{
					return false;
				}
				if (!matchingCriteria.hasData)
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

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			if (base.hasVariants)
			{
				IList<HardwareJoystickMap.Platform> variants = GetVariants();
				for (int i = 0; i < variants.Count; i++)
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

		internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Axis> IterateAxes()
		{
			return new nImIiAzFhIGEkxdeGGkqydwVoneJ(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this
			};
		}

		internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Button> IterateButtons()
		{
			return new OfUEFQORHLEGLIfqGmJukpegblyY(-2)
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
			Axis[] axes_orig = base.Axes_orig;
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
					if (base.Axes_orig[i].calibrateAxis)
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
				array[i].calibrations = HardwareJoystickMap.AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (base.Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[base.Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[base.Axes_orig.Length];
			for (int i = 0; i < base.Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(base.Axes_orig[i].axisInfo, createIfNull: true);
				if (base.Axes_orig[i].sourceType == 1 || base.Axes_orig[i].sourceType == 100)
				{
					axisRanges[i] = base.Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (base.Axes_orig[i].sourceType == 0)
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
			if (base.Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[base.Buttons_orig.Length];
				for (int i = 0; i < base.Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(base.Buttons_orig[i].buttonInfo, createIfNull: true);
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

		internal override void CopyVars(HardwareJoystickMap.Platform destination)
		{
			base.CopyVars(destination);
			if (destination is HardwareJoystickMapCustomPlatformMap<TMatchingCriteria> hardwareJoystickMapCustomPlatformMap)
			{
				hardwareJoystickMapCustomPlatformMap.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
			}
		}
	}
}
