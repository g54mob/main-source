using System;
using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Inputs/Crest Animated Waves Input")]
	public sealed class AnimatedWavesLodInput : LodInput
	{
		private sealed class Reporter : IReportsDisplacement, IReportWaveDisplacement
		{
			private readonly AnimatedWavesLodInput _Input;

			public Reporter(AnimatedWavesLodInput input)
			{
				_Input = input;
			}

			public bool ReportDisplacement(WaterRenderer water, ref Rect bounds, ref float horizontal, ref float vertical)
			{
				return _Input.ReportDisplacement(water, ref bounds, ref horizontal, ref vertical);
			}

			public float ReportWaveDisplacement(WaterRenderer water, float displacement)
			{
				return _Input.ReportWaveDisplacement(water, displacement);
			}
		}

		[Tooltip("When to render the input into the displacement data.")]
		[SerializeField]
		private DisplacementPass _DisplacementPass = DisplacementPass.LodIndependent;

		[Tooltip("Whether to filter this input by wavelength.\n\nIf disabled, it will render to all LODs.")]
		[SerializeField]
		private bool _FilterByWavelength;

		[Tooltip("Which octave to render into.\n\nFor example, set this to 2 to render into the 2m-4m octave. These refer to the same octaves as the wave spectrum editor.")]
		[SerializeField]
		private float _OctaveWavelength = 512f;

		[Header("Culling")]
		[Tooltip("Inform the system how much this input will displace the water surface vertically.\n\nThis is used to set bounding box heights for the water chunks.")]
		[SerializeField]
		private float _MaximumDisplacementVertical;

		[Tooltip("Inform the system how much this input will displace the water surface horizontally.\n\nThis is used to set bounding box widths for the water chunks.")]
		[SerializeField]
		private float _MaximumDisplacementHorizontal;

		[Tooltip("Use the bounding box of an attached renderer component to determine the maximum vertical displacement.")]
		[SerializeField]
		private bool _ReportRendererBounds;

		private Reporter _Reporter;

		[Obsolete("Please use DisplacementPass instead.")]
		[Tooltip("When to render the input into the displacement data.\n\nIf enabled, it renders into all LODs of the simulation after the combine step rather than before with filtering. Furthermore, it will also affect dynamic waves.")]
		[SerializeField]
		[HideInInspector]
		private bool _RenderPostCombine = true;

		internal override LodInputMode DefaultMode => LodInputMode.Renderer;

		internal override int Pass => (int)_DisplacementPass;

		private protected override int Version => Mathf.Max(base.Version, 1);

		internal override Color GizmoColor => AnimatedWavesLod.s_GizmoColor;

		private protected override SortedList<int, ILodInput> Inputs => AnimatedWavesLod.s_Inputs;

		public DisplacementPass DisplacementPass
		{
			get
			{
				return _DisplacementPass;
			}
			set
			{
				_DisplacementPass = value;
			}
		}

		public bool FilterByWavelength
		{
			get
			{
				return _FilterByWavelength;
			}
			set
			{
				_FilterByWavelength = value;
			}
		}

		public float MaximumDisplacementHorizontal
		{
			get
			{
				return _MaximumDisplacementHorizontal;
			}
			set
			{
				_MaximumDisplacementHorizontal = value;
			}
		}

		public float MaximumDisplacementVertical
		{
			get
			{
				return _MaximumDisplacementVertical;
			}
			set
			{
				_MaximumDisplacementVertical = value;
			}
		}

		public float OctaveWavelength
		{
			get
			{
				return _OctaveWavelength;
			}
			set
			{
				_OctaveWavelength = value;
			}
		}

		[Obsolete("Please use DisplacementPass instead.")]
		public bool RenderPostCombine
		{
			get
			{
				return _RenderPostCombine;
			}
			set
			{
				SetRenderPostCombine(_RenderPostCombine, _RenderPostCombine = value);
			}
		}

		public bool ReportRendererBounds
		{
			get
			{
				return _ReportRendererBounds;
			}
			set
			{
				_ReportRendererBounds = value;
			}
		}

		internal AnimatedWavesLodInput()
		{
			_FollowHorizontalWaveMotion = true;
		}

		private protected override void Initialize()
		{
			base.Initialize();
			if (_Reporter == null)
			{
				_Reporter = new Reporter(this);
			}
			_DisplacementReporter = _Reporter;
		}

		private protected override void OnDisable()
		{
			base.OnDisable();
			_DisplacementReporter = null;
		}

		internal override float Filter(WaterRenderer water, int slice)
		{
			return AnimatedWavesLod.FilterByWavelength(water, slice, _FilterByWavelength ? _OctaveWavelength : 0f, water.AnimatedWavesLod.Resolution);
		}

		private bool ReportDisplacement(WaterRenderer water, ref Rect bounds, ref float horizontal, ref float vertical)
		{
			if (!Enabled)
			{
				return false;
			}
			float num = _MaximumDisplacementVertical;
			if (_ReportRendererBounds)
			{
				Vector2 heightRange = base.Data.HeightRange;
				float x = heightRange.x;
				float y = heightRange.y;
				float seaLevel = water.SeaLevel;
				num = Mathf.Max(num, Mathf.Abs(seaLevel - x), Mathf.Abs(seaLevel - y));
			}
			Rect rect = base.Data.Rect;
			if (bounds.Overlaps(rect, allowInverse: false))
			{
				horizontal += _MaximumDisplacementHorizontal;
				vertical += num;
				return true;
			}
			return false;
		}

		private float ReportWaveDisplacement(WaterRenderer water, float displacement)
		{
			return displacement;
		}

		[Obsolete]
		private void SetRenderPostCombine(bool previous, bool current, bool force = false)
		{
			if (previous != current || force)
			{
				_DisplacementPass = (current ? DisplacementPass.LodIndependent : DisplacementPass.LodDependent);
			}
		}

		private protected override void OnMigrate()
		{
			base.OnMigrate();
			if (_Version < 1)
			{
				SetRenderPostCombine(_RenderPostCombine, _RenderPostCombine, force: true);
			}
		}
	}
}
