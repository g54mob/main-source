using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class GradientModifier : BaseMeshEffect
	{
		public enum Style
		{
			Horizontal = 0,
			Vertical = 1,
			Radial = 2,
			Diamond = 3
		}

		public enum Blend
		{
			Override = 0,
			Add = 1,
			Multiply = 2
		}

		[SerializeField]
		private Style gradientStyle;

		[SerializeField]
		private Blend blend;

		[SerializeField]
		private bool moreVertices = true;

		[SerializeField]
		[Range(-1f, 1f)]
		private float offset;

		[SerializeField]
		[Range(0.1f, 10f)]
		private float scale = 1f;

		[SerializeField]
		private Gradient gradient = new Gradient
		{
			colorKeys = new GradientColorKey[2]
			{
				new GradientColorKey(Color.black, 0f),
				new GradientColorKey(Color.white, 1f)
			}
		};

		private List<UIVertex> vertexList = new List<UIVertex>();

		private List<float> gradientKeysPos = new List<float>();

		private List<int> originIndices = new List<int>(3);

		private List<UIVertex> starts = new List<UIVertex>(3);

		private List<UIVertex> ends = new List<UIVertex>(2);

		private float[] cachedVertexPositions = new float[3];

		public Style GradientStyle
		{
			get
			{
				return gradientStyle;
			}
			set
			{
				if (gradientStyle != value)
				{
					gradientStyle = value;
					base.graphic.SetVerticesDirty();
				}
			}
		}

		public Blend BlendMode
		{
			get
			{
				return blend;
			}
			set
			{
				if (blend != value)
				{
					blend = value;
					base.graphic.SetVerticesDirty();
				}
			}
		}

		public bool MoreVertices
		{
			get
			{
				return moreVertices;
			}
			set
			{
				if (moreVertices != value)
				{
					moreVertices = value;
					base.graphic.SetVerticesDirty();
				}
			}
		}

		public float Offset
		{
			get
			{
				return offset;
			}
			set
			{
				if (offset != value)
				{
					offset = Mathf.Clamp(value, -1f, 1f);
					base.graphic.SetVerticesDirty();
				}
			}
		}

		public float Scale
		{
			get
			{
				return scale;
			}
			set
			{
				if (scale != value)
				{
					scale = Mathf.Clamp(value, 0.1f, 10f);
					base.graphic.SetVerticesDirty();
				}
			}
		}

		public Gradient Gradient
		{
			get
			{
				return gradient;
			}
			set
			{
				gradient = value;
				base.graphic.SetVerticesDirty();
			}
		}

		private Color BlendColor(Color colorA, Color colorB)
		{
			return BlendMode switch
			{
				Blend.Add => colorA + colorB, 
				Blend.Multiply => colorA * colorB, 
				_ => colorB, 
			};
		}

		public override void ModifyMesh(VertexHelper helper)
		{
			if (IsActive() && helper.currentVertCount != 0)
			{
				switch (GradientStyle)
				{
				case Style.Horizontal:
					ModifyMeshForHorizontal(helper);
					break;
				case Style.Vertical:
					ModifyMeshForVertical(helper);
					break;
				case Style.Diamond:
					ModifyMeshForDiamond(helper);
					break;
				case Style.Radial:
					ModifyMeshForRadial(helper);
					break;
				}
			}
		}

		private void ModifyMeshForHorizontal(VertexHelper helper)
		{
			vertexList.Clear();
			helper.GetUIVertexStream(vertexList);
			Rect vertsBounds = GetVertsBounds(vertexList);
			float xMin = vertsBounds.xMin;
			float width = vertsBounds.width;
			float num = ((width == 0f) ? 0f : (1f / width / Scale));
			float num2 = (1f - 1f / Scale) * 0.5f;
			float num3 = Offset * (1f - num2) - num2;
			if (MoreVertices)
			{
				SplitTrianglesAtGradientKeys(vertexList, vertsBounds, num2, helper);
			}
			UIVertex vertex = default(UIVertex);
			for (int i = 0; i < helper.currentVertCount; i++)
			{
				helper.PopulateUIVertex(ref vertex, i);
				vertex.color = BlendColor(vertex.color, Gradient.Evaluate((vertex.position.x - xMin) * num - num3));
				helper.SetUIVertex(vertex, i);
			}
		}

		private void ModifyMeshForVertical(VertexHelper helper)
		{
			vertexList.Clear();
			helper.GetUIVertexStream(vertexList);
			Rect vertsBounds = GetVertsBounds(vertexList);
			float yMin = vertsBounds.yMin;
			float height = vertsBounds.height;
			float num = ((height == 0f) ? 0f : (1f / height / Scale));
			float num2 = (1f - 1f / Scale) * 0.5f;
			float num3 = Offset * (1f - num2) - num2;
			if (MoreVertices)
			{
				SplitTrianglesAtGradientKeys(vertexList, vertsBounds, num2, helper);
			}
			UIVertex vertex = default(UIVertex);
			for (int i = 0; i < helper.currentVertCount; i++)
			{
				helper.PopulateUIVertex(ref vertex, i);
				vertex.color = BlendColor(vertex.color, Gradient.Evaluate((vertex.position.y - yMin) * num - num3));
				helper.SetUIVertex(vertex, i);
			}
		}

		private void ModifyMeshForDiamond(VertexHelper helper)
		{
			vertexList.Clear();
			helper.GetUIVertexStream(vertexList);
			int count = vertexList.Count;
			Rect vertsBounds = GetVertsBounds(vertexList);
			float num = ((vertsBounds.height == 0f) ? 0f : (1f / vertsBounds.height / Scale));
			float num2 = vertsBounds.center.y / 2f;
			Vector3 vector = (Vector3.right + Vector3.up) * num2 + Vector3.forward * vertexList[0].position.z;
			if (MoreVertices)
			{
				helper.Clear();
				for (int i = 0; i < count; i++)
				{
					helper.AddVert(vertexList[i]);
				}
				helper.AddVert(new UIVertex
				{
					position = vector,
					normal = vertexList[0].normal,
					uv0 = new Vector2(0.5f, 0.5f),
					color = Color.white
				});
				for (int j = 1; j < count; j++)
				{
					helper.AddTriangle(j - 1, j, count);
				}
				helper.AddTriangle(0, count - 1, count);
			}
			UIVertex vertex = default(UIVertex);
			for (int k = 0; k < helper.currentVertCount; k++)
			{
				helper.PopulateUIVertex(ref vertex, k);
				vertex.color = BlendColor(vertex.color, Gradient.Evaluate(Vector3.Distance(vertex.position, vector) * num - Offset));
				helper.SetUIVertex(vertex, k);
			}
		}

		private void ModifyMeshForRadial(VertexHelper helper)
		{
			vertexList.Clear();
			helper.GetUIVertexStream(vertexList);
			Rect vertsBounds = GetVertsBounds(vertexList);
			float num = ((vertsBounds.width == 0f) ? 0f : (1f / vertsBounds.width / Scale));
			float num2 = ((vertsBounds.height == 0f) ? 0f : (1f / vertsBounds.height / Scale));
			if (MoreVertices)
			{
				helper.Clear();
				float num3 = vertsBounds.width / 2f;
				float num4 = vertsBounds.height / 2f;
				UIVertex v = new UIVertex
				{
					position = Vector3.right * vertsBounds.center.x + Vector3.up * vertsBounds.center.y + Vector3.forward * vertexList[0].position.z,
					normal = vertexList[0].normal,
					uv0 = new Vector2(0.5f, 0.5f),
					color = Color.white
				};
				int num5 = 64;
				for (int i = 0; i < num5; i++)
				{
					UIVertex v2 = default(UIVertex);
					float num6 = (float)i * 360f / (float)num5;
					float num7 = Mathf.Cos(MathF.PI / 180f * num6);
					float num8 = Mathf.Sin(MathF.PI / 180f * num6);
					v2.position = Vector3.right * num7 * num3 + Vector3.up * num8 * num4 + Vector3.forward * vertexList[0].position.z;
					v2.normal = vertexList[0].normal;
					v2.uv0 = new Vector2((num7 + 1f) * 0.5f, (num8 + 1f) * 0.5f);
					v2.color = Color.white;
					helper.AddVert(v2);
				}
				helper.AddVert(v);
				for (int j = 1; j < num5; j++)
				{
					helper.AddTriangle(j - 1, j, num5);
				}
				helper.AddTriangle(0, num5 - 1, num5);
			}
			UIVertex vertex = default(UIVertex);
			for (int k = 0; k < helper.currentVertCount; k++)
			{
				helper.PopulateUIVertex(ref vertex, k);
				vertex.color = BlendColor(vertex.color, Gradient.Evaluate(Mathf.Sqrt(Mathf.Pow(Mathf.Abs(vertex.position.x - vertsBounds.center.x) * num, 2f) + Mathf.Pow(Mathf.Abs(vertex.position.y - vertsBounds.center.y) * num2, 2f)) * 2f - Offset));
				helper.SetUIVertex(vertex, k);
			}
		}

		private Rect GetVertsBounds(List<UIVertex> vertices)
		{
			float num = vertices[0].position.x;
			float num2 = num;
			float num3 = vertices[0].position.y;
			float num4 = num3;
			for (int num5 = vertices.Count - 1; num5 >= 1; num5--)
			{
				float x = vertices[num5].position.x;
				float y = vertices[num5].position.y;
				if (x > num2)
				{
					num2 = x;
				}
				else if (x < num)
				{
					num = x;
				}
				if (y > num4)
				{
					num4 = y;
				}
				else if (y < num3)
				{
					num3 = y;
				}
			}
			return new Rect(num, num3, num2 - num, num4 - num3);
		}

		private void SplitOneTriangle(List<UIVertex> vertexList, VertexHelper helper, int triangleIndex)
		{
			int num = triangleIndex * 3;
			float[] vertexPositions = GetVertexPositions(vertexList, num);
			originIndices.Clear();
			starts.Clear();
			ends.Clear();
			for (int i = 0; i < gradientKeysPos.Count; i++)
			{
				int currentVertCount = helper.currentVertCount;
				bool flag = ends.Count > 0;
				bool flag2 = false;
				for (int j = 0; j < 3; j++)
				{
					if (!originIndices.Contains(j) && vertexPositions[j] < gradientKeysPos[i])
					{
						int num2 = (j + 1) % 3;
						UIVertex item = vertexList[j + num];
						if (vertexPositions[num2] > gradientKeysPos[i])
						{
							originIndices.Insert(0, j);
							starts.Insert(0, item);
							flag2 = true;
						}
						else
						{
							originIndices.Add(j);
							starts.Add(item);
						}
					}
				}
				if (originIndices.Count == 0)
				{
					continue;
				}
				if (originIndices.Count == 3)
				{
					break;
				}
				foreach (UIVertex start in starts)
				{
					helper.AddVert(start);
				}
				ends.Clear();
				foreach (int originIndex in originIndices)
				{
					int num3 = (originIndex + 1) % 3;
					if (vertexPositions[num3] < gradientKeysPos[i])
					{
						num3 = (num3 + 1) % 3;
					}
					ends.Add(CreateSplitVertex(vertexList[originIndex + num], vertexList[num3 + num], gradientKeysPos[i]));
				}
				if (ends.Count == 1)
				{
					int num4 = (originIndices[0] + 2) % 3;
					ends.Add(CreateSplitVertex(vertexList[originIndices[0] + num], vertexList[num4 + num], gradientKeysPos[i]));
				}
				foreach (UIVertex end in ends)
				{
					helper.AddVert(end);
				}
				if (flag)
				{
					helper.AddTriangle(currentVertCount - 2, currentVertCount, currentVertCount + 1);
					helper.AddTriangle(currentVertCount - 2, currentVertCount + 1, currentVertCount - 1);
					if (starts.Count > 0)
					{
						if (flag2)
						{
							helper.AddTriangle(currentVertCount - 2, currentVertCount + 3, currentVertCount);
						}
						else
						{
							helper.AddTriangle(currentVertCount + 1, currentVertCount + 3, currentVertCount - 1);
						}
					}
				}
				else
				{
					int currentVertCount2 = helper.currentVertCount;
					helper.AddTriangle(currentVertCount, currentVertCount2 - 2, currentVertCount2 - 1);
					if (starts.Count > 1)
					{
						helper.AddTriangle(currentVertCount, currentVertCount2 - 1, currentVertCount + 1);
					}
				}
				starts.Clear();
			}
			if (ends.Count > 0)
			{
				if (starts.Count == 0)
				{
					for (int k = 0; k < 3; k++)
					{
						if (!originIndices.Contains(k) && vertexPositions[k] > gradientKeysPos[gradientKeysPos.Count - 1])
						{
							int num5 = (k + 1) % 3;
							UIVertex item2 = vertexList[k + num];
							if (vertexPositions[num5] > gradientKeysPos[gradientKeysPos.Count - 1])
							{
								starts.Insert(0, item2);
							}
							else
							{
								starts.Add(item2);
							}
						}
					}
				}
				foreach (UIVertex start2 in starts)
				{
					helper.AddVert(start2);
				}
				int currentVertCount3 = helper.currentVertCount;
				if (starts.Count > 1)
				{
					helper.AddTriangle(currentVertCount3 - 4, currentVertCount3 - 2, currentVertCount3 - 1);
					helper.AddTriangle(currentVertCount3 - 4, currentVertCount3 - 1, currentVertCount3 - 3);
				}
				else if (starts.Count > 0)
				{
					helper.AddTriangle(currentVertCount3 - 3, currentVertCount3 - 1, currentVertCount3 - 2);
				}
			}
			else
			{
				helper.AddVert(vertexList[num]);
				helper.AddVert(vertexList[num + 1]);
				helper.AddVert(vertexList[num + 2]);
				int currentVertCount4 = helper.currentVertCount;
				helper.AddTriangle(currentVertCount4 - 3, currentVertCount4 - 2, currentVertCount4 - 1);
			}
		}

		private void SplitTrianglesAtGradientKeys(List<UIVertex> vertexList, Rect bounds, float zoomOffset, VertexHelper helper)
		{
			FindGradientKeysPos(zoomOffset, bounds);
			if (gradientKeysPos.Count != 0)
			{
				helper.Clear();
				int num = vertexList.Count / 3;
				for (int i = 0; i < num; i++)
				{
					SplitOneTriangle(vertexList, helper, i);
				}
			}
		}

		private float[] GetVertexPositions(List<UIVertex> vertexList, int index)
		{
			if (GradientStyle == Style.Horizontal)
			{
				cachedVertexPositions[0] = vertexList[index].position.x;
				cachedVertexPositions[1] = vertexList[index + 1].position.x;
				cachedVertexPositions[2] = vertexList[index + 2].position.x;
			}
			else
			{
				cachedVertexPositions[0] = vertexList[index].position.y;
				cachedVertexPositions[1] = vertexList[index + 1].position.y;
				cachedVertexPositions[2] = vertexList[index + 2].position.y;
			}
			return cachedVertexPositions;
		}

		private void FindGradientKeysPos(float zoomOffset, Rect bounds)
		{
			gradientKeysPos.Clear();
			float num = Offset * (1f - zoomOffset);
			float num2 = zoomOffset - num;
			float num3 = 1f - zoomOffset - num;
			GradientColorKey[] colorKeys = Gradient.colorKeys;
			for (int i = 0; i < colorKeys.Length; i++)
			{
				GradientColorKey gradientColorKey = colorKeys[i];
				if (gradientColorKey.time >= num3)
				{
					break;
				}
				if (gradientColorKey.time > num2)
				{
					gradientKeysPos.Add((gradientColorKey.time - num2) * Scale);
				}
			}
			GradientAlphaKey[] alphaKeys = Gradient.alphaKeys;
			for (int i = 0; i < alphaKeys.Length; i++)
			{
				GradientAlphaKey gradientAlphaKey = alphaKeys[i];
				if (gradientAlphaKey.time >= num3)
				{
					break;
				}
				if (gradientAlphaKey.time > num2)
				{
					gradientKeysPos.Add((gradientAlphaKey.time - num2) * Scale);
				}
			}
			float num4 = bounds.xMin;
			float num5 = bounds.width;
			if (GradientStyle == Style.Vertical)
			{
				num4 = bounds.yMin;
				num5 = bounds.height;
			}
			gradientKeysPos.Sort();
			for (int j = 0; j < gradientKeysPos.Count; j++)
			{
				gradientKeysPos[j] = gradientKeysPos[j] * num5 + num4;
				if (j > 0 && Math.Abs(gradientKeysPos[j] - gradientKeysPos[j - 1]) < 2f)
				{
					gradientKeysPos.RemoveAt(j);
					j--;
				}
			}
		}

		private UIVertex CreateSplitVertex(UIVertex vertex1, UIVertex vertex2, float stop)
		{
			if (GradientStyle == Style.Horizontal)
			{
				float num = vertex1.position.x - stop;
				float num2 = vertex1.position.x - vertex2.position.x;
				float num3 = vertex1.position.y - vertex2.position.y;
				float num4 = vertex1.uv0.x - vertex2.uv0.x;
				float num5 = vertex1.uv0.y - vertex2.uv0.y;
				float num6 = num / num2;
				float y = vertex1.position.y - num3 * num6;
				return new UIVertex
				{
					position = new Vector3(stop, y, vertex1.position.z),
					normal = vertex1.normal,
					uv0 = new Vector2(vertex1.uv0.x - num4 * num6, vertex1.uv0.y - num5 * num6),
					color = Color.white
				};
			}
			float num7 = vertex1.position.y - stop;
			float num8 = vertex1.position.y - vertex2.position.y;
			float num9 = vertex1.position.x - vertex2.position.x;
			float num10 = vertex1.uv0.x - vertex2.uv0.x;
			float num11 = vertex1.uv0.y - vertex2.uv0.y;
			float num12 = num7 / num8;
			float x = vertex1.position.x - num9 * num12;
			return new UIVertex
			{
				position = new Vector3(x, stop, vertex1.position.z),
				normal = vertex1.normal,
				uv0 = new Vector2(vertex1.uv0.x - num10 * num12, vertex1.uv0.y - num11 * num12),
				color = Color.white
			};
		}
	}
}
