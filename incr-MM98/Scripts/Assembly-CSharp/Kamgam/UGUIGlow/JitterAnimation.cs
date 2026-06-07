using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.UGUIGlow
{
	public class JitterAnimation : GlowAnimation
	{
		protected float _speed = 1f;

		protected float _scale = 3f;

		protected bool _moveInside;

		protected float _progress;

		protected float _newDisplacementsTimer = -1f;

		public Dictionary<ushort, float> _lastDisplacement = new Dictionary<ushort, float>();

		public Dictionary<ushort, float> _nextDisplacement = new Dictionary<ushort, float>();

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
					_newDisplacementsTimer = -0.1f;
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
			JitterAnimation jitterAnimation = new JitterAnimation();
			jitterAnimation.CopyValuesFrom(this);
			return jitterAnimation;
		}

		public override void CopyValuesFrom(IGlowAnimation source)
		{
			base.CopyValuesFrom(source);
			JitterAnimation jitterAnimation = source as JitterAnimation;
			Speed = jitterAnimation.Speed;
			Scale = jitterAnimation.Scale;
			MoveInside = jitterAnimation.MoveInside;
		}

		protected override void updateAnimation(float deltaTime)
		{
			if (Mathf.Abs(Speed) > 0.001f)
			{
				_newDisplacementsTimer -= deltaTime;
			}
		}

		private float getDisplacementDuration()
		{
			return 1.001f - Speed / 10f;
		}

		protected override void onUpdateMesh(MeshCreator manipulator, List<UIVertex> vertices, List<ushort> triangles, List<ushort> outerIndices, List<ushort> innerIndices, Dictionary<ushort, ushort> outerToInnerIndices)
		{
			if (_lastDisplacement.Count != vertices.Count || _newDisplacementsTimer < 0f)
			{
				_newDisplacementsTimer = getDisplacementDuration();
				newDisplacementValues(vertices);
			}
			int count = outerIndices.Count;
			_ = 1f / ((float)count - 1f);
			ushort num = ushort.MaxValue;
			for (int i = 0; i < count; i++)
			{
				float b = _lastDisplacement[outerIndices[i]];
				float a = _nextDisplacement[outerIndices[i]];
				float t = _newDisplacementsTimer / getDisplacementDuration();
				Vector3 vector = MeshCreator.DisplaceVertexOutwardsNormalized(vertices, outerToInnerIndices, outerIndices[i], Mathf.Lerp(a, b, t));
				if (MoveInside)
				{
					ushort num2 = outerToInnerIndices[outerIndices[i]];
					if (num2 != num)
					{
						num = num2;
						MeshCreator.DisplaceVertex(vertices, num2, vector);
					}
				}
			}
		}

		protected void newDisplacementValues(List<UIVertex> vertices)
		{
			ushort num = (ushort)vertices.Count;
			if (_lastDisplacement.Count != num)
			{
				_lastDisplacement.Clear();
				_nextDisplacement.Clear();
				for (ushort num2 = 0; num2 < num; num2++)
				{
					_lastDisplacement.Add(num2, Random.Range(0f, Scale));
					_nextDisplacement.Add(num2, Random.Range(0f, Scale));
				}
			}
			else
			{
				for (ushort num3 = 0; num3 < num; num3++)
				{
					_lastDisplacement[num3] = _nextDisplacement[num3];
					_nextDisplacement[num3] = Random.Range(0f, Scale);
				}
			}
		}
	}
}
