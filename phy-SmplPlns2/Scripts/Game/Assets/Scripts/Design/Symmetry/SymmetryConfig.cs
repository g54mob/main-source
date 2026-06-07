using System;
using Assets.Scripts.Design.Symmetry.Events;
using Jundroo.Common.Settings;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using UnityEngine;

namespace Assets.Scripts.Design.Symmetry
{
	public class SymmetryConfig
	{
		private Unity.Mathematics.Geometry.Plane _mirrorPlane;

		private SymmetryMode _mode;

		private (float3 Axis, float3 Point) _radialAxis;

		private bool _symmetryDisabledForNewParts;

		private BoolSetting _symmetryDisabledSetting;

		public Unity.Mathematics.Geometry.Plane MirrorPlane
		{
			get
			{
				return _mirrorPlane;
			}
			set
			{
				if (math.any(_mirrorPlane.NormalAndDistance != value.NormalAndDistance))
				{
					Unity.Mathematics.Geometry.Plane mirrorPlane = _mirrorPlane;
					this.MirrorPlaneChanging?.Invoke(this, new SymmetryMirrorPlaneChangeEventArgs(mirrorPlane, value));
					_mirrorPlane = value;
					this.MirrorPlaneChanged?.Invoke(this, new SymmetryMirrorPlaneChangeEventArgs(mirrorPlane, value));
				}
			}
		}

		public SymmetryMode Mode
		{
			get
			{
				return _mode;
			}
			set
			{
				if (_mode != value)
				{
					SymmetryMode mode = _mode;
					this.SymmetryModeChanging?.Invoke(this, new SymmetryModeChangeEventArgs(mode, value));
					_mode = value;
					this.SymmetryModeChanged?.Invoke(this, new SymmetryModeChangeEventArgs(mode, value));
				}
			}
		}

		public (float3 Axis, float3 Point) RadialAxis
		{
			get
			{
				return _radialAxis;
			}
			set
			{
				if (math.any(_radialAxis.Axis != value.Axis) || math.any(_radialAxis.Point != value.Point))
				{
					(float3, float3) radialAxis = _radialAxis;
					this.RadialAxisChanging?.Invoke(this, new SymmetryRadialAxisChangeEventArgs(radialAxis, value));
					_radialAxis = value;
					this.RadialAxisChanged?.Invoke(this, new SymmetryRadialAxisChangeEventArgs(radialAxis, value));
				}
			}
		}

		public bool SymmetryDisabledForNewParts
		{
			get
			{
				if (!_symmetryDisabledForNewParts)
				{
					return _mode == SymmetryMode.Disabled;
				}
				return true;
			}
			set
			{
				if (_symmetryDisabledForNewParts != value)
				{
					this.SymmetryDisabledForNewPartsChanging?.Invoke(this, EventArgs.Empty);
					_symmetryDisabledForNewParts = value;
					_symmetryDisabledSetting.Value = value;
					_symmetryDisabledSetting.CommitChanges();
					this.SymmetryDisabledForNewPartsChanged?.Invoke(this, EventArgs.Empty);
				}
			}
		}

		public event EventHandler<SymmetryMirrorPlaneChangeEventArgs> MirrorPlaneChanged;

		public event EventHandler<SymmetryMirrorPlaneChangeEventArgs> MirrorPlaneChanging;

		public event EventHandler<SymmetryRadialAxisChangeEventArgs> RadialAxisChanged;

		public event EventHandler<SymmetryRadialAxisChangeEventArgs> RadialAxisChanging;

		public event EventHandler<EventArgs> SymmetryDisabledForNewPartsChanged;

		public event EventHandler<EventArgs> SymmetryDisabledForNewPartsChanging;

		public event EventHandler<SymmetryModeChangeEventArgs> SymmetryModeChanged;

		public event EventHandler<SymmetryModeChangeEventArgs> SymmetryModeChanging;

		public SymmetryConfig()
		{
			_mode = SymmetryMode.Mirrored;
			_mirrorPlane = new Unity.Mathematics.Geometry.Plane(new float3(1f, 0f, 0f), 0f);
			_radialAxis = (Axis: new float3(0f, 0f, 1f), Point: float3.zero);
			_symmetryDisabledSetting = Game.Instance.Settings.Gameplay.Designer.SymmetryDisabled;
			_symmetryDisabledForNewParts = _symmetryDisabledSetting.Value;
		}

		public SymmetryConfig Clone()
		{
			return new SymmetryConfig
			{
				_mode = _mode,
				_mirrorPlane = _mirrorPlane,
				_radialAxis = _radialAxis,
				_symmetryDisabledSetting = _symmetryDisabledSetting,
				_symmetryDisabledForNewParts = _symmetryDisabledForNewParts
			};
		}

		public SymmetryConfig Clone(SymmetryMode symmetryMode)
		{
			SymmetryConfig symmetryConfig = Clone();
			symmetryConfig.Mode = symmetryMode;
			return symmetryConfig;
		}

		public void UpdateConfig(Vector3 symmetricOrigin, Vector3 mirrorPlaneNormal, float mirrorPlaneOffset, Vector3 radialAxis)
		{
			MirrorPlane = new Unity.Mathematics.Geometry.Plane(mirrorPlaneNormal, symmetricOrigin + mirrorPlaneNormal * mirrorPlaneOffset);
			RadialAxis = (Axis: radialAxis, Point: symmetricOrigin);
		}
	}
}
