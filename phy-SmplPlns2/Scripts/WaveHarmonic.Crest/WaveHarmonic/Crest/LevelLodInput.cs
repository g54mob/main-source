using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Inputs/Crest Water Level Input")]
	public sealed class LevelLodInput : LodInput
	{
		private sealed class Reporter : IReportsHeight
		{
			private readonly LevelLodInput _Input;

			public Reporter(LevelLodInput input)
			{
				_Input = input;
			}

			public bool ReportHeight(WaterRenderer water, ref Rect bounds, ref float minimum, ref float maximum)
			{
				return _Input.ReportHeight(water, ref bounds, ref minimum, ref maximum);
			}
		}

		[Tooltip("Whether to use the manual \"Height Range\" for water chunk culling.\n\nMandatory for non mesh inputs like \"Texture\".")]
		[SerializeField]
		private bool _OverrideHeight;

		[Tooltip("The minimum and maximum height value to report for water chunk culling.")]
		[SerializeField]
		private Vector2 _HeightRange = new Vector2(-100f, 100f);

		private Reporter _Reporter;

		internal override Color GizmoColor => LevelLod.s_GizmoColor;

		private protected override SortedList<int, ILodInput> Inputs => LevelLod.s_Inputs;

		private protected override bool FollowHorizontalMotion => true;

		internal override LodInputMode DefaultMode => LodInputMode.Geometry;

		private protected override int Version => Mathf.Max(base.Version, 1);

		public Vector2 HeightRange
		{
			get
			{
				return _HeightRange;
			}
			set
			{
				_HeightRange = value;
			}
		}

		public bool OverrideHeight
		{
			get
			{
				return _OverrideHeight;
			}
			set
			{
				_OverrideHeight = value;
			}
		}

		private LevelLodInput()
		{
			_FollowHorizontalWaveMotion = true;
		}

		internal override void InferBlend()
		{
			base.InferBlend();
			_Blend = LodInputBlend.Off;
			LodInputMode mode = _Mode;
			if (mode == LodInputMode.Paint || mode == LodInputMode.Texture)
			{
				_Blend = LodInputBlend.Additive;
			}
		}

		private protected override void Initialize()
		{
			base.Initialize();
			if (_Reporter == null)
			{
				_Reporter = new Reporter(this);
			}
			_HeightReporter = _Reporter;
		}

		private protected override void OnDisable()
		{
			base.OnDisable();
			_HeightReporter = null;
		}

		private bool ReportHeight(WaterRenderer water, ref Rect bounds, ref float minimum, ref float maximum)
		{
			if (!Enabled)
			{
				return false;
			}
			if (!base.Data.HasHeightRange && !_OverrideHeight)
			{
				return false;
			}
			Rect rect = base.Data.Rect;
			if (bounds.Overlaps(rect, allowInverse: false))
			{
				Vector2 vector = (_OverrideHeight ? _HeightRange : base.Data.HeightRange);
				vector *= base.Weight;
				vector.x -= water.SeaLevel;
				vector.y -= water.SeaLevel;
				Vector2 vector2 = new Vector2(minimum, maximum);
				vector = _Blend switch
				{
					LodInputBlend.Additive => vector + vector2, 
					LodInputBlend.Minimum => Vector2.Min(vector, vector2), 
					LodInputBlend.Maximum => Vector2.Max(vector, vector2), 
					_ => vector, 
				};
				minimum = Mathf.Min(minimum, vector.x);
				maximum = Mathf.Max(maximum, vector.y);
				return true;
			}
			return false;
		}

		private protected override void OnMigrate()
		{
			base.OnMigrate();
			if (_Version < 1)
			{
				LodInputMode mode = _Mode;
				if (mode == LodInputMode.Spline || mode == LodInputMode.Renderer)
				{
					_Blend = LodInputBlend.Off;
				}
			}
		}
	}
}
