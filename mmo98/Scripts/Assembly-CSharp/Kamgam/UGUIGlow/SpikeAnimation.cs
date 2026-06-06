using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.UGUIGlow
{
	public class SpikeAnimation : GlowAnimation
	{
		protected float _speed = 1f;

		protected float _scale = 3f;

		protected int _frequency = 1;

		protected SinusMode _sinusMode = SinusMode.ClampPositive;

		protected bool _moveInside;

		protected float _progress;

		public float Speed
		{
			get
			{
				return _speed;
			}
			set
			{
				if (_speed != value)
				{
					_speed = value;
					TriggerOnValueChanged();
				}
			}
		}

		public float Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				if (_scale != value)
				{
					_scale = value;
					TriggerOnValueChanged();
				}
			}
		}

		public int Frequency
		{
			get
			{
				return _frequency;
			}
			set
			{
				if (_frequency != value)
				{
					_frequency = value;
					TriggerOnValueChanged();
				}
			}
		}

		public SinusMode SinusMode
		{
			get
			{
				return _sinusMode;
			}
			set
			{
				if (_sinusMode != value)
				{
					_sinusMode = value;
					TriggerOnValueChanged();
				}
			}
		}

		public bool MoveInside
		{
			get
			{
				return _moveInside;
			}
			set
			{
				if (_moveInside != value)
				{
					_moveInside = value;
					TriggerOnValueChanged();
				}
			}
		}

		public override IGlowAnimation Copy()
		{
			SpikeAnimation spikeAnimation = new SpikeAnimation();
			spikeAnimation.CopyValuesFrom(this);
			return spikeAnimation;
		}

		public override void CopyValuesFrom(IGlowAnimation source)
		{
			base.CopyValuesFrom(source);
			SpikeAnimation spikeAnimation = source as SpikeAnimation;
			Speed = spikeAnimation.Speed;
			Frequency = spikeAnimation.Frequency;
			Scale = spikeAnimation.Scale;
			SinusMode = spikeAnimation.SinusMode;
			MoveInside = spikeAnimation.MoveInside;
		}

		protected override void updateAnimation(float deltaTime)
		{
			_progress += deltaTime * Speed;
		}

		protected override void onUpdateMesh(MeshCreator manipulator, List<UIVertex> vertices, List<ushort> triangles, List<ushort> outerIndices, List<ushort> innerIndices, Dictionary<ushort, ushort> outerToInnerIndices)
		{
			int count = outerIndices.Count;
			float num = 1f / ((float)count - 1f);
			ushort num2 = ushort.MaxValue;
			for (int i = 0; i < count; i++)
			{
				float f = Mathf.Sin((float)i * num * 2f * MathF.PI * (float)Frequency + _progress);
				float displacementFactor = (1f - SinusUtils.ApplySinusMode(Mathf.Sin(f), SinusMode)) * Scale;
				Vector3 vector = MeshCreator.DisplaceVertexOutwardsNormalized(vertices, outerToInnerIndices, outerIndices[i], displacementFactor);
				if (MoveInside)
				{
					ushort num3 = outerToInnerIndices[outerIndices[i]];
					if (num3 != num2)
					{
						num2 = num3;
						MeshCreator.DisplaceVertex(vertices, num3, vector);
					}
				}
			}
		}
	}
}
