using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[AddComponentMenu("UI/Extensions/Primitives/UIBeamRenderer")]
	public class UIBeamRenderer : MaskableGraphic
	{
		private static readonly float TOP = 0.5f;

		private static readonly float BOTTOM = -0.5f;

		private static readonly float LEFT = -0.5f;

		private static readonly float RIGHT = 0.5f;

		private static readonly Vector2[] Corners = new Vector2[4]
		{
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero
		};

		private static readonly Vector3[] Mappings = new Vector3[4]
		{
			new Vector3(-0.5f, -0.5f, 0f),
			new Vector3(0.5f, -0.5f, 0f),
			new Vector3(0.5f, 0.5f, 0f),
			new Vector3(-0.5f, 0.5f, 0f)
		};

		private static Vector2[] UVs = new Vector2[4]
		{
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero
		};

		[SerializeField]
		private Texture m_Texture;

		[SerializeField]
		private Rect m_UVRect = new Rect(0f, 0f, 1f, 1f);

		[SerializeField]
		private Vector2 _spotOrigin;

		[SerializeField]
		private Vector2 _spotTarget;

		[SerializeField]
		private float _beamScale = 1f;

		[SerializeField]
		private float _beamDist = 1f;

		public Vector2 SpotOrigin
		{
			get
			{
				return _spotOrigin;
			}
			set
			{
				if (!(_spotOrigin == value))
				{
					_spotOrigin = value;
					SetVerticesDirty();
				}
			}
		}

		public Vector2 SpotTarget
		{
			get
			{
				return _spotTarget;
			}
			set
			{
				if (!(_spotTarget == value))
				{
					_spotTarget = value;
					SetVerticesDirty();
				}
			}
		}

		public float BeamScale
		{
			get
			{
				return _beamScale;
			}
			set
			{
				if (_beamScale != value)
				{
					_beamScale = value;
					SetVerticesDirty();
				}
			}
		}

		public float BeamDist
		{
			get
			{
				return _beamDist;
			}
			set
			{
				if (_beamDist != value)
				{
					_beamDist = value;
					SetVerticesDirty();
				}
			}
		}

		public override Texture mainTexture => m_Texture ?? Graphic.s_WhiteTexture;

		public Texture texture
		{
			get
			{
				return m_Texture;
			}
			set
			{
				if (!(m_Texture == value))
				{
					m_Texture = value;
					SetVerticesDirty();
					SetMaterialDirty();
				}
			}
		}

		public Rect uvRect
		{
			get
			{
				return m_UVRect;
			}
			set
			{
				if (!(m_UVRect == value))
				{
					m_UVRect = value;
					SetVerticesDirty();
				}
			}
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			vh.Clear();
			float width = base.rectTransform.rect.width;
			float height = base.rectTransform.rect.height;
			float num = width / height;
			float num2 = _beamScale * 0.5f * num;
			float num3 = _beamScale * 0.5f;
			Corners[0].Set(LEFT * width, TOP * height);
			Corners[1].Set(RIGHT * width, TOP * height);
			Corners[2].Set(RIGHT * width, BOTTOM * height);
			Corners[3].Set(LEFT * width, BOTTOM * height);
			Vector3 vector = (Vector3)SpotOrigin + Vector3.back * BeamDist;
			Vector3 vector2 = SpotTarget;
			Quaternion quaternion = Quaternion.FromToRotation(Vector3.forward, vector2 - vector);
			Plane plane = new Plane(Vector3.back, Vector2.zero);
			Ray ray = new Ray(vector, Vector3.forward);
			for (int i = 0; i < 4; i++)
			{
				ray.direction = quaternion * (Mappings[i] - Vector3.back * BeamDist);
				if (plane.Raycast(ray, out var enter))
				{
					Vector3 point = ray.GetPoint(enter);
					UVs[i] = new Vector2(0.5f + point.x * num2, 0.5f + point.y * num3);
				}
			}
			vh.AddUIVertexQuad(SetVbo(Corners, UVs));
		}

		private UIVertex[] SetVbo(Vector2[] vertices, Vector2[] uvs)
		{
			UIVertex[] array = new UIVertex[4];
			for (int i = 0; i < vertices.Length; i++)
			{
				UIVertex simpleVert = UIVertex.simpleVert;
				simpleVert.color = color;
				simpleVert.position = vertices[i];
				simpleVert.uv0 = uvs[i];
				array[i] = simpleVert;
			}
			return array;
		}
	}
}
