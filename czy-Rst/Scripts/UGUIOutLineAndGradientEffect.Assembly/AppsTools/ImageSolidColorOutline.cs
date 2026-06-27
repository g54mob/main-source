using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AppsTools
{
	[AddComponentMenu("UI/AppsTools/Image Solid Color Outline")]
	[RequireComponent(typeof(Graphic))]
	public class ImageSolidColorOutline : BaseMeshEffect
	{
		public Color OutlineColor = Color.white;

		[Range(0f, 15f)]
		public int OutlineWidth;

		private static List<UIVertex> m_VetexList = new List<UIVertex>();

		private Image image;

		private Sprite previousSprite;

		private Color previousColor;

		private static readonly int OutlineColorProperty = Shader.PropertyToID("_OutlineColor");

		private static readonly int OutlineWidthProperty = Shader.PropertyToID("_OutlineWidth");

		protected override void Start()
		{
			base.Start();
			if (TryGetComponent<Image>(out image))
			{
				previousSprite = image.sprite;
				previousColor = OutlineColor;
			}
			Shader shader = Shader.Find("AppsTools.net/ImageOutline");
			base.graphic.material = new Material(shader);
			Canvas canvas = base.graphic.canvas;
			if (canvas == null)
			{
				canvas = base.graphic.GetComponent<Canvas>();
			}
			if (!(canvas == null))
			{
				AdditionalCanvasShaderChannels additionalShaderChannels = base.graphic.canvas.additionalShaderChannels;
				AdditionalCanvasShaderChannels additionalCanvasShaderChannels = AdditionalCanvasShaderChannels.TexCoord1;
				if ((additionalShaderChannels & additionalCanvasShaderChannels) != additionalCanvasShaderChannels)
				{
					base.graphic.canvas.additionalShaderChannels |= additionalCanvasShaderChannels;
				}
				additionalCanvasShaderChannels = AdditionalCanvasShaderChannels.TexCoord2;
				if ((additionalShaderChannels & additionalCanvasShaderChannels) != additionalCanvasShaderChannels)
				{
					base.graphic.canvas.additionalShaderChannels |= additionalCanvasShaderChannels;
				}
				_Refresh();
			}
		}

		private void Update()
		{
			if ((bool)image)
			{
				if (previousSprite != image.sprite)
				{
					RefreshOutlineWidth();
					previousSprite = image.sprite;
				}
				if (OutlineColor != previousColor)
				{
					base.graphic.material.SetColor(OutlineColorProperty, OutlineColor);
					previousColor = OutlineColor;
				}
			}
		}

		private void _Refresh()
		{
			base.graphic.material.SetColor(OutlineColorProperty, OutlineColor);
			RefreshOutlineWidth();
			base.graphic.SetVerticesDirty();
		}

		public void RefreshOutlineWidth()
		{
			float num = OutlineWidth;
			if ((bool)image && (bool)image.sprite)
			{
				Rect rect = image.sprite.rect;
				float height = rect.height;
				float width = rect.width;
				num *= (height + width) / 150f;
			}
			base.graphic.material.SetInt(OutlineWidthProperty, (int)num);
		}

		public override void ModifyMesh(VertexHelper vh)
		{
			vh.GetUIVertexStream(m_VetexList);
			_ProcessVertices();
			vh.Clear();
			vh.AddUIVertexTriangleStream(m_VetexList);
		}

		private void _ProcessVertices()
		{
			int i = 0;
			for (int num = m_VetexList.Count - 3; i <= num; i += 3)
			{
				UIVertex pVertex = m_VetexList[i];
				UIVertex pVertex2 = m_VetexList[i + 1];
				UIVertex pVertex3 = m_VetexList[i + 2];
				float num2 = _Min(pVertex.position.x, pVertex2.position.x, pVertex3.position.x);
				float num3 = _Min(pVertex.position.y, pVertex2.position.y, pVertex3.position.y);
				float num4 = _Max(pVertex.position.x, pVertex2.position.x, pVertex3.position.x);
				float num5 = _Max(pVertex.position.y, pVertex2.position.y, pVertex3.position.y);
				Vector2 pPosCenter = new Vector2(num2 + num4, num3 + num5) * 0.5f;
				Vector2 vector = pVertex.position;
				Vector2 vector2 = pVertex2.position;
				Vector2 vector3 = pVertex3.position;
				Vector2 pTriangleX;
				Vector2 pTriangleY;
				Vector2 pUVX;
				Vector2 pUVY;
				if (Mathf.Abs(Vector2.Dot((vector2 - vector).normalized, Vector2.right)) > Mathf.Abs(Vector2.Dot((vector3 - vector2).normalized, Vector2.right)))
				{
					pTriangleX = vector2 - vector;
					pTriangleY = vector3 - vector2;
					pUVX = pVertex2.uv0 - pVertex.uv0;
					pUVY = pVertex3.uv0 - pVertex2.uv0;
				}
				else
				{
					pTriangleX = vector3 - vector2;
					pTriangleY = vector2 - vector;
					pUVX = pVertex3.uv0 - pVertex2.uv0;
					pUVY = pVertex2.uv0 - pVertex.uv0;
				}
				Vector2 vector4 = _Min(pVertex.uv0, pVertex2.uv0, pVertex3.uv0);
				Vector2 vector5 = _Max(pVertex.uv0, pVertex2.uv0, pVertex3.uv0);
				Vector4 pUVOrigin = new Vector4(vector4.x, vector4.y, vector5.x, vector5.y);
				pVertex = _SetNewPosAndUV(pVertex, OutlineWidth, pPosCenter, pTriangleX, pTriangleY, pUVX, pUVY, pUVOrigin);
				pVertex2 = _SetNewPosAndUV(pVertex2, OutlineWidth, pPosCenter, pTriangleX, pTriangleY, pUVX, pUVY, pUVOrigin);
				pVertex3 = _SetNewPosAndUV(pVertex3, OutlineWidth, pPosCenter, pTriangleX, pTriangleY, pUVX, pUVY, pUVOrigin);
				m_VetexList[i] = pVertex;
				m_VetexList[i + 1] = pVertex2;
				m_VetexList[i + 2] = pVertex3;
			}
		}

		private static UIVertex _SetNewPosAndUV(UIVertex pVertex, int pOutLineWidth, Vector2 pPosCenter, Vector2 pTriangleX, Vector2 pTriangleY, Vector2 pUVX, Vector2 pUVY, Vector4 pUVOrigin)
		{
			Vector3 position = pVertex.position;
			int num = ((position.x > pPosCenter.x) ? pOutLineWidth : (-pOutLineWidth));
			int num2 = ((position.y > pPosCenter.y) ? pOutLineWidth : (-pOutLineWidth));
			position.x += num;
			position.y += num2;
			pVertex.position = position;
			Vector4 uv = pVertex.uv0;
			Vector2 vector = pUVX / pTriangleX.magnitude * num * ((Vector2.Dot(pTriangleX, Vector2.right) > 0f) ? 1 : (-1));
			Vector2 vector2 = pUVY / pTriangleY.magnitude * num2 * ((Vector2.Dot(pTriangleY, Vector2.up) > 0f) ? 1 : (-1));
			uv.x += vector.x;
			uv.y += vector.y;
			uv.x += vector2.x;
			uv.y += vector2.y;
			pVertex.uv0 = uv;
			pVertex.uv1 = new Vector2(pUVOrigin.x, pUVOrigin.y);
			pVertex.uv2 = new Vector2(pUVOrigin.z, pUVOrigin.w);
			return pVertex;
		}

		private static float _Min(float pA, float pB, float pC)
		{
			return Mathf.Min(Mathf.Min(pA, pB), pC);
		}

		private static float _Max(float pA, float pB, float pC)
		{
			return Mathf.Max(Mathf.Max(pA, pB), pC);
		}

		private static Vector2 _Min(Vector2 pA, Vector2 pB, Vector2 pC)
		{
			return new Vector2(_Min(pA.x, pB.x, pC.x), _Min(pA.y, pB.y, pC.y));
		}

		private static Vector2 _Max(Vector2 pA, Vector2 pB, Vector2 pC)
		{
			return new Vector2(_Max(pA.x, pB.x, pC.x), _Max(pA.y, pB.y, pC.y));
		}

		protected override void OnDestroy()
		{
			base.graphic.material = null;
		}
	}
}
