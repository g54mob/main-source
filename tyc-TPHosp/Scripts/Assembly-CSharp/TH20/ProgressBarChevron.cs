using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ProgressBarChevron : MaskableGraphic
	{
		[SerializeField]
		private Texture _texture;

		[SerializeField]
		private float _uvTile = 1f;

		[SerializeField]
		private float _maxDelta = 0.01f;

		[SerializeField]
		private Color _colorIncrease = Color.green;

		[SerializeField]
		private Color _colorDecrease = Color.red;

		private float _delta;

		private float _velocity;

		private static bool _useChevrons = false;

		private static bool _useVelocityOverride = false;

		private static float _velocityOverride = 8f;

		private static float cMaxVelocity = 8f;

		private static float cDeltaScaleFactor = 100f;

		private static float cVelocityDecrFactor = 1f;

		public override Texture mainTexture => _texture ?? base.mainTexture;

		public float Delta
		{
			set
			{
				_delta = value;
			}
		}

		private void Update()
		{
			if (!_useChevrons)
			{
				return;
			}
			if (_delta < 0f || _delta > 0f)
			{
				_velocity += _delta * cDeltaScaleFactor;
				if (_velocity > cMaxVelocity)
				{
					_velocity = cMaxVelocity;
				}
				else if (_velocity < 0f - cMaxVelocity)
				{
					_velocity = 0f - cMaxVelocity;
				}
			}
			else
			{
				_velocity -= _velocity * Time.deltaTime * cVelocityDecrFactor;
			}
			if (!MathUtils.ApproximatelyZero(_velocity))
			{
				SetVerticesDirty();
			}
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			vh.Clear();
			if (_useChevrons)
			{
				vh.AddUIVertexQuad(BuildQuad(CalcColor(), new Vector2[4]
				{
					new Vector2(0f, 0f),
					new Vector2(0f, 1f),
					new Vector2(1f, 1f),
					new Vector2(1f, 0f)
				}));
			}
		}

		private Color CalcColor()
		{
			Color result = ((_velocity < 0f) ? _colorDecrease : _colorIncrease);
			result.a *= Mathf.Clamp01(Mathf.Abs(_velocity) / cMaxVelocity);
			return result;
		}

		private UIVertex[] BuildQuad(Color quadColor, IList<Vector2> vertices)
		{
			UIVertex[] array = new UIVertex[4];
			float width = base.rectTransform.rect.width;
			float height = base.rectTransform.rect.height;
			float num = (0f - base.rectTransform.pivot.x) * base.rectTransform.rect.width;
			float num2 = (0f - base.rectTransform.pivot.y) * base.rectTransform.rect.height;
			float num3 = Time.time * (0f - Mathf.Abs(_velocity));
			float num4 = width / height * Mathf.Sign(_velocity) * _uvTile;
			for (int i = 0; i < vertices.Count; i++)
			{
				UIVertex simpleVert = UIVertex.simpleVert;
				Vector2 vector = new Vector2(vertices[i].x * width + num, vertices[i].y * height + num2);
				simpleVert.color = quadColor;
				simpleVert.position = vector;
				simpleVert.uv0 = vertices[i];
				simpleVert.uv0.x *= num4;
				simpleVert.uv0.x += num3;
				array[i] = simpleVert;
			}
			return array;
		}
	}
}
