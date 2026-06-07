using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Data.Mapping;
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

			internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Button : HardwareJoystickMap.Platform_Custom.Button
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
		public new sealed class Axis : HardwareJoystickMap.Platform_Custom.Axis
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
		public new abstract class MatchingCriteria : HardwareJoystickMap.Platform_Custom.MatchingCriteria
		{
			[Tooltip("If enabled, name strings can contain regular expressions for matching.")]
			public bool nameUseRegex;

			[Tooltip("A list of string names to match on. If defined, any matching name will result in a match.")]
			public string[] name;

			internal override bool hasData => false;

			internal override bool isAllowed => false;

			public virtual bool Matches(object customIdentifier)
			{
				return false;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				return false;
			}

			protected abstract object CreateInstance();

			protected virtual void DeepClone(object destination)
			{
			}

			public override object DeepClone()
			{
				return null;
			}

			internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
			{
			}
		}

		[Tooltip("The list of controller elements.")]
		public Elements elements;

		private HardwareJoystickMap.Platform_Custom.Axis[] _axesOrigGame;

		private HardwareJoystickMap.Platform_Custom.Button[] _buttonsOrigGame;

		public override int assignedButtonCount => 0;

		public override int assignedAxisCount => 0;

		internal override InputPlatform platform => default(InputPlatform);

		internal override HardwareJoystickMap.Platform_Custom.Axis[] Axes => null;

		internal override HardwareJoystickMap.Platform_Custom.Button[] Buttons => null;

		internal Axis[] Axes_orig => null;

		internal Button[] Buttons_orig => null;

		internal override bool hasData => false;

		internal override bool isAllowed => false;

		internal override HardwareJoystickMap.Elements_Base elements_base => null;

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
			return null;
		}

		internal override void CopyVars(HardwareJoystickMap.Platform destination)
		{
		}
	}
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public abstract class HardwareJoystickMapCustomPlatformMap<TMatchingCriteria> : HardwareJoystickMapCustomPlatformMap where TMatchingCriteria : HardwareJoystickMapCustomPlatformMap.MatchingCriteria
	{
		private sealed class uCuAnXDhAuMTZIuPfFfoWEEfmFPPA : IEnumerable<HardwareJoystickMap.Platform_Custom.Axis>, IEnumerable, IEnumerator<HardwareJoystickMap.Platform_Custom.Axis>, IEnumerator, IDisposable
		{
			private int MGcLbTQfOLHSEWawFQjEgcFRGWBl;

			private HardwareJoystickMap.Platform_Custom.Axis iKQTluUgOuzibYEjiHgjIbVvNGkx;

			private int QPNJpZcSCYtUcUvZFpXfFcZrmSmA;

			public HardwareJoystickMapCustomPlatformMap<TMatchingCriteria> cuaLNPyIkiDAmckXNzuEfjVbTtOW;

			private int jYgXCghSFBkTuDndKbnftSHiputy;

			HardwareJoystickMap.Platform_Custom.Axis IEnumerator<HardwareJoystickMap.Platform_Custom.Axis>.Current
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
			public uCuAnXDhAuMTZIuPfFfoWEEfmFPPA(int P_0)
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
			IEnumerator<HardwareJoystickMap.Platform_Custom.Axis> IEnumerable<HardwareJoystickMap.Platform_Custom.Axis>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private sealed class DsAozTUQQrXDeVGPpomqSBOEfERp : IEnumerable<HardwareJoystickMap.Platform_Custom.Button>, IEnumerable, IEnumerator<HardwareJoystickMap.Platform_Custom.Button>, IEnumerator, IDisposable
		{
			private int VNwdDOjqOpkVbpCwQGQXQOTKJVzgA;

			private HardwareJoystickMap.Platform_Custom.Button TiWHlzNDESbyeZUaQmnrnTwZVQzg;

			private int zWAPtxbIsElkrNIerUkokEKkHsfh;

			public HardwareJoystickMapCustomPlatformMap<TMatchingCriteria> scvDsEdEXpjagZkwyWvaxitxYuhE;

			private int jrgtLhdZqLPnHgvYbGxEuMmZNJRV;

			HardwareJoystickMap.Platform_Custom.Button IEnumerator<HardwareJoystickMap.Platform_Custom.Button>.Current
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
			public DsAozTUQQrXDeVGPpomqSBOEfERp(int P_0)
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
			IEnumerator<HardwareJoystickMap.Platform_Custom.Button> IEnumerable<HardwareJoystickMap.Platform_Custom.Button>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[Tooltip("User-defined matching criteria. Determines whether this platform map matches to a particular controller.")]
		public TMatchingCriteria matchingCriteria;

		internal override bool hasData => false;

		internal override bool disabled => false;

		internal override bool isAllowed => false;

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out HardwareJoystickMap.Platform platformMap)
		{
			variantIndex = default(int);
			platformMap = null;
			return false;
		}

		[IteratorStateMachine(typeof(HardwareJoystickMapCustomPlatformMap<>.uCuAnXDhAuMTZIuPfFfoWEEfmFPPA))]
		internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Axis> IterateAxes()
		{
			return null;
		}

		[IteratorStateMachine(typeof(HardwareJoystickMapCustomPlatformMap<>.DsAozTUQQrXDeVGPpomqSBOEfERp))]
		internal override IEnumerable<HardwareJoystickMap.Platform_Custom.Button> IterateButtons()
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

		internal override void CopyVars(HardwareJoystickMap.Platform destination)
		{
		}
	}
}
