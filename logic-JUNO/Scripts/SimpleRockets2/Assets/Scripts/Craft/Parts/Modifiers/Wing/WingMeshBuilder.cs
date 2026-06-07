using System;
using System.Collections.Generic;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Wing
{
	public class WingMeshBuilder
	{
		private static int[] _cubeTriangles = CreateCubeTriangles();

		private static List<Vector4> _tempUVList24 = CreateTempUVList(24);

		private static Vector3[] _tempVertexArray24 = new Vector3[24];

		private static Vector3[] _tempVertexArray8 = new Vector3[8];

		private IPartMaterialScript _partMaterialScript;

		private WingScript _wingScript;

		public WingMeshBuilder(WingScript wingScript, IPartMaterialScript partMaterialScript)
		{
			_wingScript = wingScript;
			_partMaterialScript = partMaterialScript;
		}

		public static Mesh BuildSectionMesh(float spanStart, float span, float baseChord, float tipChord, float sweepStart, float sweepEnd, float chordStart, float chordEnd, Vector3 center, float uvwTop, float uvwBottom, float uvwTrailing, float uvwCap, Vector2 uvOffset, float thickness, float thicknessTip, float thicknessOffset, float thicknessDelta, bool isFancy, bool isBulgy, bool collider, float curveLength = 0.3f, float controlSurface = 1f)
		{
			Vector3[] tempVertexArray = _tempVertexArray8;
			thickness *= 0.5f;
			thicknessTip *= 0.5f;
			float num = 0f;
			float num2 = 0f;
			if (controlSurface != 1f)
			{
				num = (thicknessTip - thickness) * thicknessOffset * (1f - controlSurface);
				num2 = thicknessDelta * thicknessOffset / controlSurface;
				thickness *= controlSurface;
				thicknessTip *= controlSurface;
				thicknessDelta /= controlSurface;
			}
			float num3 = baseChord * (chordEnd - 0.5f);
			tempVertexArray[0] = new Vector3(0f - thickness, spanStart, num3 + sweepStart);
			tempVertexArray[1] = new Vector3(thickness, spanStart, num3 + sweepStart);
			float num4 = baseChord * (chordStart - 0.5f);
			tempVertexArray[2] = new Vector3(thickness * (thicknessOffset + thicknessDelta - num2), spanStart, num4 + sweepStart);
			tempVertexArray[3] = new Vector3(thickness * (thicknessOffset - thicknessDelta - num2), spanStart, num4 + sweepStart);
			float num5 = tipChord * (chordEnd - 0.5f);
			tempVertexArray[4] = new Vector3(0f - thicknessTip + num, spanStart + span, num5 + sweepEnd);
			tempVertexArray[5] = new Vector3(thicknessTip + num, spanStart + span, num5 + sweepEnd);
			float num6 = tipChord * (chordStart - 0.5f);
			tempVertexArray[6] = new Vector3(thicknessTip * (thicknessOffset + thicknessDelta - num2) + num, spanStart + span, num6 + sweepEnd);
			tempVertexArray[7] = new Vector3(thicknessTip * (thicknessOffset - thicknessDelta - num2) + num, spanStart + span, num6 + sweepEnd);
			for (int i = 0; i < 8; i++)
			{
				tempVertexArray[i] -= center;
			}
			Mesh mesh = CreateCubeMesh(tempVertexArray, uvwTop, uvwBottom, uvwTrailing, uvwCap, collider, isFancy, isBulgy, uvOffset, controlSurface != 1f, ((controlSurface != 1f) ? chordEnd : chordStart) / (1f - curveLength));
			if (!collider)
			{
				mesh.RecalculateTangents();
			}
			return mesh;
		}

		public Mesh BuildColliderMesh()
		{
			WingData data = _wingScript.Data;
			float num = data.BaseChord;
			if (num < 0.0625f)
			{
				num = 0.0625f;
			}
			return BuildSectionMesh(0f, data.WingSpan, num, data.TipChord, 0f, _wingScript.WingSweep, 0f, 1f, Vector3.zero, 0f, 0f, 0f, 0f, Vector2.zero, data.Thickness, data.ThicknessTip, data.ThicknessOffset * (1f - data.ThicknessDelta), data.ThicknessDelta, isFancy: false, isBulgy: false, collider: true, data.CurveLength);
		}

		public void BuildControlSurface(float spanStart, float span, float baseChord, float tipChord, float sweepStart, float sweepEnd, ControlSurfaceScript controlSurface, bool isFancy, float thicknessStart, float thicknessEnd, float thicknessOffset, float thicknessDelta, float sectionDelta, float curveLength)
		{
			float chordStart = 0f;
			float hingeDistanceFromTrailingEdge = _wingScript.Data.HingeDistanceFromTrailingEdge;
			Vector3 vector = default(Vector3);
			vector.x = 0f;
			vector.y = spanStart + span * 0.5f;
			float num = sweepStart - baseChord * 0.5f + hingeDistanceFromTrailingEdge * baseChord;
			float num2 = sweepEnd - tipChord * 0.5f + hingeDistanceFromTrailingEdge * tipChord;
			vector.z = (num + num2) / 2f;
			float num3 = 10f + _partMaterialScript.GetPartMaterialIndex(1);
			controlSurface.Mesh = BuildSectionMesh(spanStart, span, baseChord, tipChord, sweepStart, sweepEnd, chordStart, hingeDistanceFromTrailingEdge, vector, num3, num3, num3, num3, new Vector2(vector.y, vector.z), thicknessStart, thicknessEnd, thicknessOffset, thicknessDelta, isFancy, _wingScript.Data.LeadingBulge >= 1f, collider: false, curveLength, sectionDelta);
			vector.x = 0.5f * thicknessStart * thicknessOffset * (1f - sectionDelta);
			controlSurface.transform.localPosition = vector;
			controlSurface.HingeAxis = new Vector3(0f, span, num2 - num);
		}

		public void UpdateMesh()
		{
			WingData data = _wingScript.Data;
			float thicknessOffset = data.ThicknessOffset;
			List<Mesh> list = new List<Mesh>();
			if (_wingScript.ControlSurfaces.Count < 1)
			{
				list.Add(BuildSectionMesh(0f, data.WingSpan, data.BaseChord, data.TipChord, 0f, _wingScript.WingSweep, 0f, 1f - (data.IsFancy ? data.CurveLength : 0f), Vector3.zero, _partMaterialScript.GetPartMaterialIndex((data.IsInverted && data.IsFancy) ? 2 : 0), _partMaterialScript.GetPartMaterialIndex((!data.IsInverted && data.IsFancy) ? 2 : 0), _partMaterialScript.GetPartMaterialIndex(0), _partMaterialScript.GetPartMaterialIndex(data.IsFancy ? 3 : 0), Vector2.zero, data.Thickness, data.ThicknessTip, thicknessOffset * (1f - data.ThicknessDelta), data.ThicknessDelta, _wingScript.Data.IsFancy, data.LeadingBulge >= 1f, collider: false, data.CurveLength));
			}
			else
			{
				float num = 0f;
				foreach (ControlSurfaceScript controlSurface in _wingScript.ControlSurfaces)
				{
					int num2 = Mathf.Min(controlSurface.Data.Start, _wingScript.SimulationSectionCount - 1);
					float num3 = (float)num2 / (float)_wingScript.SimulationSectionCount * data.WingSpan;
					if (num3 > num)
					{
						list.Add(BuildSectionMeshHelper(num, num3, null));
					}
					num = (float)Mathf.Min(num2 + controlSurface.Data.Length, _wingScript.SimulationSectionCount) / (float)_wingScript.SimulationSectionCount * data.WingSpan;
					list.Add(BuildSectionMeshHelper(num3, num, controlSurface));
				}
				if (num < data.WingSpan)
				{
					list.Add(BuildSectionMeshHelper(num, data.WingSpan, null));
				}
			}
			if (data.IsFancy)
			{
				Vector3[] normals = list[0].normals;
				float num4 = ((data.BaseChord == data.TipChord) ? 1f : ((data.BaseChord > data.TipChord) ? (data.TipChord / data.BaseChord) : (data.BaseChord / data.TipChord)));
				num4 = ((num4 < 0.1f) ? 0.1f : num4);
				list.Add(CreateLeadingEdge(BuildLeadingCurve(data.BaseChord * 0.5f, 0f, data.BaseChord * data.CurveLength, data.Thickness, thicknessOffset, data.LeadingBulge), BuildLeadingCurve(_wingScript.WingSweep + data.TipChord * 0.5f, data.WingSpan, data.TipChord * data.CurveLength, data.ThicknessTip, thicknessOffset, data.LeadingBulge), _partMaterialScript.GetPartMaterialIndex(3), _partMaterialScript.GetPartMaterialIndex(4), normals[16], normals[5], Mathf.RoundToInt(Mathf.Log(num4, 0.75f))));
			}
			CombineInstance[] array = new CombineInstance[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				array[i] = default(CombineInstance);
				array[i].transform = Matrix4x4.identity;
				array[i].mesh = list[i];
			}
			Mesh mesh = new Mesh();
			mesh.CombineMeshes(array);
			_wingScript.Mesh = mesh;
			_partMaterialScript.UpdateTextureData();
		}

		private static List<Vector3> BuildLeadingCurve(float leadOffset, float spanOffset, float length, float thickness, float offset, float bulge)
		{
			bool flag = bulge < 1f;
			List<Vector3> list = new List<Vector3>(10);
			leadOffset -= length;
			thickness *= 0.5f;
			list.Add(new Vector3(0f - thickness, spanOffset, leadOffset));
			float num = ((thickness <= 0f) ? 0f : (length / thickness));
			float p = 0.5f / bulge;
			float num2 = Mathf.Pow(thickness, 2f * bulge);
			float num3 = offset * thickness;
			float num4 = 1f / (1f - offset * offset);
			for (int i = 1; i < 8; i++)
			{
				float num5 = (float)i * 0.5f / 4f;
				num5 = num5 * num5 * (3f - 2f * num5) * 2f * thickness - thickness;
				float f = Mathf.Max((offset - 1f) * (num5 - num3), (offset + 1f) * (num5 - num3)) * num4;
				f = num * Mathf.Pow(Mathf.Max(0f, num2 - Mathf.Pow(f, 2f * bulge)), p);
				Vector3 item = new Vector3(num5, spanOffset, leadOffset + f);
				list.Add(item);
				if (flag && i == 4)
				{
					list.Add(item);
				}
			}
			list.Add(new Vector3(thickness, spanOffset, leadOffset));
			return list;
		}

		private static Mesh CreateCubeMesh(Vector3[] p, float uvwTop, float uvwBottom, float uvwTrailing, float uvwCap, bool collider, bool isFancy, bool isBulgy, Vector2 uvOffset, bool controlSurface, float hinge)
		{
			Mesh mesh = new Mesh();
			mesh.name = "WingMesh";
			Vector3[] tempVertexArray = _tempVertexArray24;
			tempVertexArray[0] = p[0];
			tempVertexArray[1] = p[1];
			tempVertexArray[2] = p[2];
			tempVertexArray[3] = p[3];
			tempVertexArray[4] = p[4];
			tempVertexArray[5] = p[0];
			tempVertexArray[6] = p[3];
			tempVertexArray[7] = p[7];
			tempVertexArray[8] = p[4];
			tempVertexArray[9] = p[5];
			tempVertexArray[10] = p[1];
			tempVertexArray[11] = p[0];
			tempVertexArray[12] = p[6];
			tempVertexArray[13] = p[7];
			tempVertexArray[14] = p[3];
			tempVertexArray[15] = p[2];
			tempVertexArray[16] = p[5];
			tempVertexArray[17] = p[6];
			tempVertexArray[18] = p[2];
			tempVertexArray[19] = p[1];
			tempVertexArray[20] = p[7];
			tempVertexArray[21] = p[6];
			tempVertexArray[22] = p[5];
			tempVertexArray[23] = p[4];
			mesh.vertices = tempVertexArray;
			mesh.triangles = _cubeTriangles;
			if (!collider)
			{
				List<Vector4> tempUVList = _tempUVList24;
				for (int i = 0; i < tempUVList.Count; i++)
				{
					float w = uvwTop;
					if (isFancy)
					{
						switch (i / 4)
						{
						case 0:
						case 5:
							w = uvwCap;
							break;
						case 3:
							w = uvwTrailing;
							break;
						case 1:
							w = uvwBottom;
							break;
						}
					}
					tempUVList[i] = new Vector4((tempVertexArray[i].y + uvOffset.x) * 0.25f, (tempVertexArray[i].z + uvOffset.y) * 0.25f, 0f, w);
				}
				Vector3[] tempVertexArray2 = _tempVertexArray24;
				tempVertexArray2[0] = (tempVertexArray2[1] = (tempVertexArray2[2] = (tempVertexArray2[3] = -Vector3.up)));
				tempVertexArray2[4] = (tempVertexArray2[5] = (tempVertexArray2[6] = (tempVertexArray2[7] = Vector3.Normalize(Vector3.Cross(tempVertexArray[4] - tempVertexArray[5], tempVertexArray[6] - tempVertexArray[4])))));
				if (isFancy && isBulgy)
				{
					tempVertexArray2[5].z = 0f;
					tempVertexArray2[4] = (tempVertexArray2[5] = Vector3.Normalize(tempVertexArray2[5]));
				}
				tempVertexArray2[8] = (tempVertexArray2[9] = (tempVertexArray2[10] = (tempVertexArray2[11] = Vector3.Normalize(Vector3.Cross(tempVertexArray[9] - tempVertexArray[10], tempVertexArray[9] - tempVertexArray[11])))));
				tempVertexArray2[12] = (tempVertexArray2[13] = (tempVertexArray2[14] = (tempVertexArray2[15] = Vector3.Normalize(Vector3.Cross(tempVertexArray[13] - tempVertexArray[14], tempVertexArray[13] - tempVertexArray[15])))));
				tempVertexArray2[16] = (tempVertexArray2[17] = (tempVertexArray2[18] = (tempVertexArray2[19] = Vector3.Normalize(Vector3.Cross(tempVertexArray[16] - tempVertexArray[19], tempVertexArray[16] - tempVertexArray[18])))));
				if (isFancy && isBulgy)
				{
					tempVertexArray2[16].z = 0f;
					tempVertexArray2[16] = (tempVertexArray2[19] = Vector3.Normalize(tempVertexArray2[16]));
				}
				tempVertexArray2[20] = (tempVertexArray2[21] = (tempVertexArray2[22] = (tempVertexArray2[23] = Vector3.up)));
				if (hinge > 0f && hinge < 1f && isFancy && isBulgy)
				{
					Vector3 vector = Vector3.Lerp(tempVertexArray2[6], tempVertexArray2[5], hinge);
					Vector3 vector2 = Vector3.Lerp(tempVertexArray2[18], tempVertexArray2[19], hinge);
					if (controlSurface)
					{
						tempVertexArray2[4] = (tempVertexArray2[5] = vector);
						tempVertexArray2[16] = (tempVertexArray2[19] = vector2);
					}
					else
					{
						tempVertexArray2[6] = (tempVertexArray2[7] = vector);
						tempVertexArray2[17] = (tempVertexArray2[18] = vector2);
					}
				}
				mesh.normals = tempVertexArray2;
				mesh.SetUVs(0, tempUVList);
			}
			mesh.RecalculateBounds();
			return mesh;
		}

		private static int[] CreateCubeTriangles()
		{
			return new int[36]
			{
				3, 1, 0, 3, 2, 1, 7, 5, 4, 7,
				6, 5, 11, 9, 8, 11, 10, 9, 15, 13,
				12, 15, 14, 13, 19, 17, 16, 19, 18, 17,
				23, 21, 20, 23, 22, 21
			};
		}

		private static Mesh CreateLeadingEdge(List<Vector3> line1, List<Vector3> line2, float uvwCap, float uvwCurve, Vector3 normTop, Vector3 normBottom, int subdivisions = 0)
		{
			if (line1.Count != line2.Count)
			{
				throw new NotSupportedException("Leading edge lines are a different length");
			}
			List<Vector4> uvs = new List<Vector4>();
			List<Vector3> vertices = new List<Vector3>();
			List<int> indices = new List<int>();
			AddLine(line1);
			float num = 1f / (float)(subdivisions + 1);
			for (int i = 0; i < subdivisions; i++)
			{
				AddInterpolatedLine((float)(i + 1) * num);
			}
			AddLine(line2);
			for (int j = 1; j < subdivisions + 2; j++)
			{
				int num2 = (j - 1) * line1.Count;
				int num3 = j * line1.Count;
				for (int k = 1; k < line1.Count; k++)
				{
					indices.Add(num3 + k - 1);
					indices.Add(num2 + k - 1);
					indices.Add(num2 + k);
					indices.Add(num3 + k);
					indices.Add(num3 + k - 1);
					indices.Add(num2 + k);
				}
			}
			List<Vector3> list = line1;
			Vert(list[list.Count - 1], uvwCurve);
			List<Vector3> list2 = line2;
			Vert(list2[list2.Count - 1], uvwCurve);
			EndCap(line1, reverse: false);
			EndCap(line2, reverse: true);
			Mesh mesh = new Mesh();
			mesh.name = "WingMesh";
			mesh.vertices = vertices.ToArray();
			mesh.triangles = indices.ToArray();
			mesh.RecalculateBounds();
			mesh.SetUVs(0, uvs);
			mesh.RecalculateNormals();
			Vector3[] normals = mesh.normals;
			for (int l = 0; l < subdivisions + 2; l++)
			{
				normals[l * line1.Count] = normBottom;
				normals[(l + 1) * line1.Count - 1] = normTop;
			}
			mesh.normals = normals;
			return mesh;
			void AddInterpolatedLine(float t)
			{
				for (int m = 0; m < line1.Count; m++)
				{
					Vert(Vector3.Lerp(line1[m], line2[m], t), uvwCurve);
				}
			}
			void AddLine(List<Vector3> list3)
			{
				for (int m = 0; m < list3.Count; m++)
				{
					Vert(list3[m], uvwCurve);
				}
			}
			void EndCap(List<Vector3> points, bool reverse)
			{
				int count = vertices.Count;
				int num4 = 0;
				Vector3 vector = new Vector3(float.NaN, float.NaN, float.NaN);
				foreach (Vector3 point in points)
				{
					if (point != vector)
					{
						Vert(point, uvwCap);
						vector = point;
						num4++;
					}
				}
				if (num4 < 3)
				{
					while (num4 > 0)
					{
						vertices.RemoveAt(vertices.Count - 1);
						uvs.RemoveAt(uvs.Count - 1);
						num4--;
					}
				}
				else
				{
					int num5 = 0;
					int num6 = num4 - 1;
					while (num5 <= num6)
					{
						if (reverse)
						{
							indices.Add(count + num5++);
							indices.Add(count + num5);
							indices.Add(count + num6);
							if (num5 == num6 - 1)
							{
								break;
							}
							indices.Add(count + num6--);
							indices.Add(count + num5);
							indices.Add(count + num6);
						}
						else
						{
							indices.Add(count + num5++);
							indices.Add(count + num6);
							indices.Add(count + num5);
							if (num5 == num6 - 1)
							{
								break;
							}
							indices.Add(count + num6--);
							indices.Add(count + num6);
							indices.Add(count + num5);
						}
					}
				}
			}
			void Vert(Vector3 pos, float uvw)
			{
				vertices.Add(pos);
				uvs.Add(new Vector4(pos.y * 0.25f, pos.z * 0.25f, 0f, uvw));
			}
		}

		private static List<Vector4> CreateTempUVList(int size)
		{
			List<Vector4> list = new List<Vector4>(size);
			for (int i = 0; i < size; i++)
			{
				list.Add(Vector4.zero);
			}
			return list;
		}

		private Mesh BuildSectionMeshHelper(float start, float end, ControlSurfaceScript controlSurface)
		{
			WingData data = _wingScript.Data;
			float span = end - start;
			float num = (data.TipChord - data.BaseChord) / data.WingSpan;
			float baseChord = data.BaseChord + num * start;
			float tipChord = data.BaseChord + num * end;
			float num2 = _wingScript.WingSweep / data.WingSpan;
			float sweepStart = num2 * start;
			float sweepEnd = num2 * end;
			float num3 = Mathf.Lerp(data.Thickness, data.ThicknessTip, start / data.WingSpan);
			float num4 = Mathf.Lerp(data.Thickness, data.ThicknessTip, end / data.WingSpan);
			float num5 = 1f - (data.IsFancy ? data.CurveLength : 0f);
			float num6 = ((controlSurface != null) ? data.HingeDistanceFromTrailingEdge : 0f);
			float num7 = Mathf.Lerp(data.ThicknessDelta, 1f, num6 / num5);
			float thicknessOffset = data.ThicknessOffset * (1f - num7);
			if (controlSurface != null)
			{
				BuildControlSurface(start, span, baseChord, tipChord, sweepStart, sweepEnd, controlSurface, data.IsFancy, num3, num4, data.ThicknessOffset, data.ThicknessDelta, num7, data.CurveLength);
			}
			return BuildSectionMesh(start, span, baseChord, tipChord, sweepStart, sweepEnd, num6, num5, Vector3.zero, _partMaterialScript.GetPartMaterialIndex((data.IsInverted && data.IsFancy) ? 2 : 0), _partMaterialScript.GetPartMaterialIndex((!data.IsInverted && data.IsFancy) ? 2 : 0), _partMaterialScript.GetPartMaterialIndex(0), _partMaterialScript.GetPartMaterialIndex(data.IsFancy ? 3 : 0), Vector2.zero, num3, num4, thicknessOffset, num7, data.IsFancy, data.LeadingBulge >= 1f, collider: false, data.CurveLength);
		}
	}
}
