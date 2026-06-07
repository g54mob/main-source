using System;
using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using ScriptHelpers;
using SimulationScripts.BibiteScripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utility;

namespace UIScripts.UIReferences.LineagePanel
{
	public class LineageMesh : MaskableGraphic
	{
		[SerializeField]
		public BibiteGenePreviewer previewer;

		[SerializeField]
		private PolygonCollider2D polygonCollider;

		[SerializeField]
		private UIMeshEventHandler eventHandler;

		[NonSerialized]
		public List<Vector2> corners = new List<Vector2>();

		[NonSerialized]
		public Vector2[] points;

		[NonSerialized]
		public List<SpeciesRungData> rungData = new List<SpeciesRungData>();

		[NonSerialized]
		public bool alive = true;

		[NonSerialized]
		public int order;

		private Mesh mesh;

		public Species species;

		private RectTransform rt;

		private static readonly int Color1 = Shader.PropertyToID("_Color");

		private static readonly int ParentColor = Shader.PropertyToID("_ParentColor");

		private static readonly int BlendHeight = Shader.PropertyToID("_BlendHeight");

		private static readonly int BorderWidth = Shader.PropertyToID("_BorderWidth");

		private static readonly int BorderColor = Shader.PropertyToID("_BorderColor");

		private static readonly int Focus = Shader.PropertyToID("_Focus");

		private float minX;

		private float maxX;

		private float minY;

		private float maxY;

		private Vector2 rectSize;

		private Vector4 borderUVL = new Vector4(1f, 1f, 0f, 0f);

		private Vector4 borderUVR = new Vector4(1f, 0f, 0f, 0f);

		private float borderMeshThickness = 10f;

		private const float minPreviewSize = 50f;

		private const float maxPreviewSize = 400f;

		private bool isFocused;

		private float fadeEndHeight;

		private float absoluteMaxFadeEndHeight;

		private WaitForSecondsRealtime wait = new WaitForSecondsRealtime(0.5f);

		private Coroutine waiting;

		public Vector3 centerPoint => (Vector2)rt.position + rt.lossyScale * rt.rect.size / 2f;

		public float topHeight => rt.localPosition.y + maxY;

		public float bottomHeight => rt.localPosition.y;

		public override Material materialForRendering => material;

		public void InitializeUILineageMesh()
		{
			rt = GetComponent<RectTransform>();
			eventHandler.onHover.AddListener(OnMeshHover);
			eventHandler.onClick.AddListener(OnMeshClick);
			mesh = new Mesh();
			material = new Material(material);
			material.SetFloat(BorderWidth, 5f / borderMeshThickness);
			previewer.InitializePreview();
			base.transform.localPosition = new Vector2(0f, 0f);
		}

		public void AssignSpecies(long id)
		{
			AssignSpecies(GlobalLineageManager.Instance.recordedSpecies.FirstOrDefault((Species s) => s.speciesID == id));
		}

		public void AssignSpecies(Species speciesToAssign)
		{
			species = speciesToAssign;
			alive = true;
			species.onSpeciesChange.AddListener(OnSpeciesInfoChange);
			OnSpeciesInfoChange();
			previewer.UpdateTemplate(species.template);
			Color value = BibiteGenes.GenesToColor(species.template.genes[5], species.template.genes[6], species.template.genes[7]);
			material.SetColor(Color1, value);
			order = GlobalLineageManager.Instance.recordedSpecies.IndexOf(species);
			if (species.parentSpecies != null)
			{
				Color value2 = BibiteGenes.GenesToColor(species.parentSpecies.template.genes[5], species.parentSpecies.template.genes[6], species.parentSpecies.template.genes[7]);
				material.SetColor(ParentColor, value2);
			}
			else
			{
				material.SetColor(ParentColor, value);
			}
		}

		private void OnSpeciesInfoChange()
		{
			previewer.nameText.text = species.name;
			eventHandler.SetTooltip(species.name);
		}

		public void WakeUp()
		{
			base.gameObject.SetActive(value: true);
			FocusMesh(val: false);
		}

		public void Retire()
		{
			base.gameObject.SetActive(value: false);
			species.onSpeciesChange.RemoveListener(OnSpeciesInfoChange);
			corners.Clear();
			rungData.Clear();
		}

		public void AddRung(float y, float x1, float x2, int rungIndex, SpeciesDataPoint? info = null, float totalRungEnergy = 1f, int totalRungCount = 1)
		{
			if (corners.Count < 1)
			{
				minY = y;
				minX = x1;
				maxY = y;
				maxX = x2;
			}
			else
			{
				maxY = y;
				if (x1 < minX)
				{
					minX = x1;
				}
				if (x2 > maxX)
				{
					maxX = x2;
				}
			}
			SpeciesRungData item = ((!info.HasValue) ? SpeciesRungData.EmptyRung(rungIndex) : new SpeciesRungData(info.Value, totalRungEnergy, totalRungCount, rungIndex));
			corners.Add(new Vector2(x1, y));
			corners.Add(new Vector2(x2, y));
			rungData.Add(item);
		}

		public void AddTopCap(float x, float y, int rungIndex, bool parentIsLeft = true)
		{
			AddRung(y, x, x, rungIndex);
			int num = Mathf.Clamp(corners.Count / 5, 1, 5);
			List<Vector2> list = corners;
			absoluteMaxFadeEndHeight = list[list.Count - 3].y;
			float a = absoluteMaxFadeEndHeight;
			List<Vector2> list2 = corners;
			int num2 = 2 * num + 1;
			fadeEndHeight = Mathf.Min(a, list2[list2.Count - num2].y);
			Vector2 vector = new Vector2(minX, minY);
			for (int i = 0; i < corners.Count; i++)
			{
				corners[i] -= vector;
			}
			maxX -= minX;
			minX = 0f;
			maxY -= minY;
			minY = 0f;
			rectSize = new Vector2(maxX, maxY);
			rt.localPosition = vector;
			rt.sizeDelta = rectSize;
			points = corners.ToArray();
			eventHandler.SetBounds(points);
			CalculateDisplayBibite();
		}

		public void AddBottomCap(float x, float y, int rungIndex)
		{
			alive = false;
			AddRung(y, x, x, rungIndex);
		}

		private void CalculateDisplayBibite()
		{
			previewer.gameObject.SetActive(value: false);
			if (rt.rect.width < 50f || rt.rect.height < 50f)
			{
				return;
			}
			Rect rect = new Rect(0f, 0f, 0f, 0f);
			Rect rect2 = new Rect(0f, 0f, 0f, 0f);
			int num = corners.Count / 2;
			for (int i = 0; i < num; i++)
			{
				float num2 = corners[2 * i + 1].x - corners[2 * i].x;
				if (num2 < 50f)
				{
					continue;
				}
				rect2.position = corners[2 * i];
				rect2.width = num2;
				rect2.height = 0f;
				for (int j = i + 1; j < num; j++)
				{
					if (!(rect2.height < rect2.width))
					{
						break;
					}
					if (!(rect2.width > 50f))
					{
						break;
					}
					float num3 = Mathf.Max(rect2.x, corners[2 * j].x);
					float num4 = Mathf.Min(rect2.width, Mathf.Min(rect2.xMax, corners[2 * j + 1].x) - num3);
					float num5 = corners[2 * j].y - rect2.y;
					if (rect2.height > 50f && Mathf.Min(rect2.width, 400f) * rect2.height > num4 * num5)
					{
						break;
					}
					rect2.x = num3;
					rect2.width = num4;
					rect2.height = num5;
				}
				Vector2 center = rect2.center;
				rect2.height = Mathf.Min(rect2.height, rect2.width);
				rect2.width = Mathf.Min(rect2.height, rect2.width);
				rect2.center = center;
				if (rect2.width > 50f && rect2.width > rect.width)
				{
					rect = rect2;
				}
			}
			if (rect.width > 50f)
			{
				previewer.gameObject.SetActive(value: true);
				float num6 = Mathf.Min(rect.width, 400f);
				rect.position += Vector2.one * (rect.width - num6) / 2f;
				rect.width = num6;
				rect.height = num6;
				Transform obj = previewer.transform;
				obj.localPosition = rect.center;
				obj.localScale = new Vector3(num6 / 400f, num6 / 400f, 1f);
			}
		}

		public void AddMaxFadeEnd(float lastHeight)
		{
			fadeEndHeight = Mathf.Clamp(fadeEndHeight, lastHeight, absoluteMaxFadeEndHeight);
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			if (corners.Count >= 1)
			{
				vh.Clear();
				AddShape(vh);
				vh.FillMesh(mesh);
			}
		}

		private void AddShape(VertexHelper vh)
		{
			UIVertex v = new UIVertex
			{
				color = color
			};
			int count = corners.Count;
			int num = count / 2;
			Vector2 pL = corners[0];
			Vector2 pR = corners[1];
			Vector2 vector = corners[2];
			Vector2 vector2 = corners[3];
			if (alive)
			{
				AddVerticesOfRung(vh, pL, vector, new Vector2(vector.x, 2f * pL.y - vector.y), pR, vector2, new Vector2(vector2.x, 2f * pR.y - vector2.y));
			}
			else
			{
				AddVerticesOfRung(vh, pL, vector, vector2, pR, vector2, vector, isBottomCorner: true);
			}
			for (int i = 1; i < num - 1; i++)
			{
				AddVerticesOfRung(vh, corners[2 * i], corners[2 * i + 2], corners[2 * i - 2], corners[2 * i + 1], corners[2 * i + 3], corners[2 * i - 1]);
				int num2 = 4 * i;
				vh.AddTriangle(num2 - 2, num2 + 2, num2 + 3);
				vh.AddTriangle(num2 - 2, num2 + 3, num2 - 1);
				vh.AddTriangle(num2 - 3, num2 + 1, num2 + 2);
				if (i == 1 && !alive)
				{
					vh.AddTriangle(num2 - 4, num2 - 3, num2 - 1);
				}
				else
				{
					vh.AddTriangle(num2 - 3, num2 + 2, num2 - 2);
				}
				vh.AddTriangle(num2 - 4, num2, num2 + 1);
				vh.AddTriangle(num2 - 4, num2 + 1, num2 - 3);
			}
			List<Vector2> list = corners;
			Vector2 vector3 = list[list.Count - 1];
			List<Vector2> list2 = corners;
			Vector2 vector4 = list2[list2.Count - 3];
			List<Vector2> list3 = corners;
			Vector2 vector5 = list3[list3.Count - 4];
			v.position = vector3;
			v.uv0 = vector3 / rectSize;
			v.uv1 = borderUVL;
			vh.AddVert(v);
			Vector3 rightCorner = vector3.GetRightCorner(vector5, vector4, borderMeshThickness, (vector5 + vector4) / 2f, Vector2.left, Vector2.right);
			float z = rightCorner.z;
			rightCorner.z = 0f;
			v.position = rightCorner;
			v.uv0 = rightCorner / rectSize;
			v.uv1 = borderUVL * (1f - z);
			vh.AddVert(v);
			int num3 = 2 * count - 3;
			vh.AddTriangle(num3 - 3, num3, num3 - 2);
			vh.AddTriangle(num3 - 2, num3, num3 - 1);
			vh.AddTriangle(num3 - 4, num3, num3 - 3);
			vh.AddTriangle(num3 - 5, num3 - 1, num3);
			vh.AddTriangle(num3 - 5, num3, num3 - 4);
			float num4 = (topHeight - fadeEndHeight) / maxY;
			material.SetFloat(BlendHeight, (species.parentSpecies != null) ? num4 : 0f);
		}

		private void AddVerticesOfRung(VertexHelper vh, Vector2 pL, Vector2 pLu, Vector2 pLd, Vector2 pR, Vector2 pRu, Vector2 pRd, bool isBottomCorner = false)
		{
			UIVertex v = default(UIVertex);
			Vector2 vector = (isBottomCorner ? ((pLu + pRu) / 2f) : ((pL + pR) / 2f));
			Vector2 dir = (isBottomCorner ? Vector2.left : ((pLu + pRu) / 2f - vector));
			Vector2 dir2 = (isBottomCorner ? Vector2.right : ((pLd + pRd) / 2f - vector));
			_ = (pL - vector).sqrMagnitude;
			v.position = pL;
			v.uv0 = pL / rectSize;
			v.uv1 = borderUVL;
			vh.AddVert(v);
			Vector3 rightCorner = pL.GetRightCorner(pLd, pLu, borderMeshThickness, vector, dir, dir2);
			float z = rightCorner.z;
			rightCorner.z = 0f;
			v.position = rightCorner;
			v.uv0 = rightCorner / rectSize;
			v.uv1 = borderUVL * (1f - z);
			vh.AddVert(v);
			rightCorner = pR.GetLeftCorner(pRd, pRu, borderMeshThickness, vector, dir, dir2);
			z = rightCorner.z;
			rightCorner.z = 0f;
			v.position = rightCorner;
			v.uv0 = rightCorner / rectSize;
			v.uv1 = borderUVR * (1f - z);
			vh.AddVert(v);
			if (!isBottomCorner)
			{
				v.position = pR;
			}
			else
			{
				Vector2 move = pL - pLu;
				Vector2 vector2 = pRu - pR;
				Vector2 start = ((Vector2)rightCorner - pL) / z;
				float b = vector2.KToLine(start, move);
				v.position = pR + vector2 * Mathf.Min(0.95f, b);
			}
			v.uv0 = v.position / rectSize;
			v.uv1 = borderUVR;
			vh.AddVert(v);
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			SetVerticesDirty();
		}

		private void OnMeshHover(PointerEventData eventData)
		{
			float y = rt.InverseTransformPoint(eventData.pointerCurrentRaycast.worldPosition).y;
			if (!(y < 0f) && !(y > maxY))
			{
				int i;
				for (i = 0; i < rungData.Count && !(y < points[2 * i].y); i++)
				{
				}
				int num = Mathf.Max(0, i - 1);
				int num2 = Mathf.Min(i, points.Length / 2 - 1);
				if (points[2 * num2].y - y < Mathf.Abs(y - points[2 * num].y))
				{
					eventHandler.UpdateTooltip(null, rungData[num2].Text());
				}
				else
				{
					eventHandler.UpdateTooltip(null, rungData[num].Text());
				}
			}
		}

		private void OnMeshClick(PointerEventData eventData)
		{
			SpeciesPanel.instance.SelectAndFocusSpecies(species);
		}

		public void FocusMesh(bool val)
		{
			isFocused = val;
			material.SetColor(BorderColor, val ? Color.yellow : Color.black);
			material.SetFloat(BorderWidth, (val ? 10f : 5f) / borderMeshThickness);
			material.SetFloat(Focus, val ? 1f : 0f);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			UnityEngine.Object.Destroy(material);
		}

		private void OnDrawGizmos()
		{
			if (!(mesh == null))
			{
				Vector3[] vertices = mesh.vertices;
				int[] triangles = mesh.triangles;
				Gizmos.color = (isFocused ? Color.magenta : Color.green);
				for (int i = 0; i < triangles.Length / 3; i++)
				{
					Vector3 vector = base.transform.TransformPoint(vertices[triangles[i * 3]]);
					Vector3 vector2 = base.transform.TransformPoint(vertices[triangles[i * 3 + 1]]);
					Vector3 vector3 = base.transform.TransformPoint(vertices[triangles[i * 3 + 2]]);
					Gizmos.DrawLine(vector, vector2);
					Gizmos.DrawLine(vector2, vector3);
					Gizmos.DrawLine(vector3, vector);
				}
			}
		}
	}
}
