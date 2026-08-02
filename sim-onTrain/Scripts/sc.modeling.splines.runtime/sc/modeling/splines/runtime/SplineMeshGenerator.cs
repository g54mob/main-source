using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Splines;
using UnityEngine.Splines.Interpolators;

namespace sc.modeling.splines.runtime
{
	public static class SplineMeshGenerator
	{
		private static readonly List<Vector3> vertices = new List<Vector3>();

		private static readonly List<Vector3> normals = new List<Vector3>();

		private static readonly List<Vector4> tangents = new List<Vector4>();

		private static readonly List<Vector4> uv0 = new List<Vector4>();

		private static readonly List<List<int>> triangles = new List<List<int>>();

		private static readonly List<Color> colors = new List<Color>();

		private static Vector3[] sourceVertices;

		private static readonly List<int[]> sourceTriangles = new List<int[]>();

		private static Vector3[] sourceNormals;

		private static readonly List<Vector4> sourceUv0 = new List<Vector4>();

		private static Vector4[] sourceTangents;

		private static Color[] sourceColors;

		private static bool hasTangents;

		private static bool hasUV;

		private static bool hasSourceVertexColor;

		private static bool setVertexColor;

		private static readonly List<CombineInstance> combineInstances = new List<CombineInstance>();

		private static Bounds bounds;

		private static float3 boundsMin;

		private static float3 boundsMax;

		private static float4x4 splineLocalToWorld;

		public static readonly LerpFloat FloatInterpolator = default(LerpFloat);

		private static readonly Vector2[] corners = new Vector2[5]
		{
			new Vector2(-0.5f, -0.5f),
			new Vector2(-0.5f, 0.5f),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.5f, -0.5f),
			new Vector2(-0.5f, -0.5f)
		};

		private static int CalculateSegmentCount(Settings settings, float splineLength, float meshLength, bool closed)
		{
			int segments = settings.distribution.segments;
			if (settings.distribution.autoSegmentCount)
			{
				if (closed)
				{
					splineLength += 0.001f;
				}
				if (settings.distribution.stretchToFit)
				{
					return (int)math.ceil(splineLength / meshLength);
				}
				if (settings.distribution.evenOnly)
				{
					return (int)math.floor(splineLength / meshLength);
				}
				return (int)math.ceil(splineLength / meshLength);
			}
			return segments;
		}

		public static Mesh CreateMesh(ref Mesh outputMesh, SplineContainer splineContainer, Mesh sourceMesh, float4x4 worldToLocalMatrix, Settings settings, List<SplineData<float3>> scaleData = null, List<SplineData<float>> rollData = null, List<SplineData<SplineMesher.VertexColorChannel>> redVertexColor = null, List<SplineData<SplineMesher.VertexColorChannel>> greenVertexColor = null, List<SplineData<SplineMesher.VertexColorChannel>> blueVertexColor = null, List<SplineData<SplineMesher.VertexColorChannel>> alphaVertexColor = null)
		{
			int subMeshCount = sourceMesh.subMeshCount;
			int count = splineContainer.Splines.Count;
			combineInstances.Clear();
			boundsMin = Vector3.one * float.NegativeInfinity;
			boundsMax = Vector3.one * float.PositiveInfinity;
			sourceVertices = sourceMesh.vertices;
			int num = sourceVertices.Length;
			sourceNormals = sourceMesh.normals;
			sourceMesh.GetUVs(0, sourceUv0);
			sourceTangents = sourceMesh.tangents;
			sourceColors = sourceMesh.colors;
			bounds = sourceMesh.bounds;
			sourceTriangles.Clear();
			for (int i = 0; i < subMeshCount; i++)
			{
				sourceTriangles.Add(sourceMesh.GetTriangles(i));
			}
			hasUV = sourceUv0.Count > 0;
			hasTangents = sourceTangents.Length != 0;
			hasSourceVertexColor = sourceColors.Length != 0;
			Color black = Color.black;
			setVertexColor = hasSourceVertexColor;
			splineLocalToWorld = splineContainer.transform.localToWorldMatrix;
			int num2 = 0;
			bool flag = scaleData != null;
			bool flag2 = rollData != null;
			bool flag3 = redVertexColor != null;
			bool flag4 = greenVertexColor != null;
			bool flag5 = blueVertexColor != null;
			bool flag6 = alphaVertexColor != null;
			float2 float5 = new float2(settings.distribution.trimStart, settings.distribution.trimEnd);
			for (int j = 0; j < count; j++)
			{
				Spline spline = splineContainer.Splines[j];
				float splineLength = spline.CalculateLength(splineLocalToWorld);
				float2 float6 = new float2(float5.x / splineLength, 1f - float5.y / splineLength);
				float num3 = float5.x + float5.y;
				splineLength -= num3;
				float z = settings.deforming.scale.z;
				float y = bounds.size.y;
				float num4 = math.max(0.1f, bounds.size.z * z);
				float segmentLength = num4 + settings.distribution.spacing;
				if (splineLength <= 0.02f)
				{
					continue;
				}
				_ = splineLength;
				_ = segmentLength;
				int num5 = CalculateSegments();
				if (num5 == 0)
				{
					continue;
				}
				if (settings.distribution.stretchToFit)
				{
					float num6 = (float)num5 * segmentLength;
					float num7 = splineLength / num6;
					z *= num7;
					num4 = math.max(0.1f, bounds.size.z * z);
					segmentLength = num4 + settings.distribution.spacing;
					num5 = CalculateSegments();
					if (num5 == 0)
					{
						continue;
					}
				}
				Mesh mesh = new Mesh();
				mesh.subMeshCount = subMeshCount;
				triangles.Clear();
				for (int k = 0; k < subMeshCount; k++)
				{
					triangles.Add(new List<int>());
				}
				vertices.Clear();
				normals.Clear();
				tangents.Clear();
				uv0.Clear();
				colors.Clear();
				float3 position = 0f;
				float3 tangent = 0f;
				float3 upVector = 0f;
				float3 float7 = 0f;
				float3 float8 = 0f;
				quaternion quaternion2 = quaternion.identity;
				quaternion q = quaternion.identity;
				float3 float9 = new float3(1f);
				for (int l = 0; l < num5; l++)
				{
					float num8 = (float)l * segmentLength;
					float num9 = -1f;
					for (int m = 0; m < num; m++)
					{
						float num10 = (sourceVertices[m].z - bounds.min.z) / (bounds.max.z - bounds.min.z) * num4 + num8;
						float num11 = 0.5f * num4 + num8;
						bool num12 = math.abs(num10 - num9) > 0f;
						if (num12)
						{
							num9 = num10;
						}
						float3 float10 = position;
						float num13 = num10 / splineLength;
						if (num12)
						{
							num13 = math.lerp(float6.x, float6.y, num13);
							num13 = math.clamp(num13, 1E-06f, 0.999999f);
							spline.Evaluate(num13, out position, out tangent, out upVector);
							float7 = math.normalize(tangent);
							float8 = math.cross(upVector, float7);
							quaternion2 = quaternion.LookRotation(float7, upVector);
							if (settings.deforming.ignoreKnotRotation && settings.deforming.rollAngle == 0f)
							{
								quaternion2 = RollCorrectedRotation(float7);
								float8 = math.rotate(quaternion2, math.right());
							}
							if ((settings.deforming.rollAngle != 0f || flag2) && (!settings.conforming.enable || !settings.conforming.align))
							{
								float num14 = ((settings.deforming.rollMode == Settings.Deforming.RollMode.PerSegment) ? (num11 / splineLength) : num13);
								float num15 = ((settings.deforming.rollFrequency > 0f) ? (settings.deforming.rollFrequency * (num14 * splineLength)) : 1f);
								float num16 = settings.deforming.rollAngle * num15;
								if (flag2 && rollData[j].Count > 0)
								{
									num16 += rollData[j].Evaluate(spline, spline.ConvertIndexUnit(num14, PathIndexUnit.Normalized, settings.deforming.rollPathIndexUnit), settings.deforming.rollPathIndexUnit, FloatInterpolator);
								}
								quaternion2 = math.mul(quaternion.AxisAngle(float7, (0f - num16) * (MathF.PI / 180f)), quaternion2);
								float8 = math.mul(quaternion2, math.right());
								upVector = math.mul(quaternion2, math.up());
							}
							float9 = new float3(1f);
							if (flag && scaleData[j].Count > 0)
							{
								SplineMesher.scaleInterpolator.mode = settings.deforming.scaleInterpolation;
								float9 = scaleData[j].Evaluate(spline, spline.ConvertIndexUnit(num10, PathIndexUnit.Distance, settings.deforming.scalePathIndexUnit), settings.deforming.scalePathIndexUnit, SplineMesher.scaleInterpolator);
							}
							float9.x *= settings.deforming.scale.x;
							float9.y *= settings.deforming.scale.y;
							float9.z = 0f;
							float10 = position;
							q = quaternion2;
						}
						black = (hasSourceVertexColor ? sourceColors[m] : Color.clear);
						float t = spline.ConvertIndexUnit(num10, PathIndexUnit.Distance, settings.color.pathIndexUnit);
						if (flag3 && redVertexColor[j].Count > 0)
						{
							black.r = redVertexColor[j].Evaluate(spline, t, settings.color.pathIndexUnit, new SplineMesher.VertexColorChannel.LerpVertexColorData(black.r));
							setVertexColor = true;
						}
						if (flag4 && greenVertexColor[j].Count > 0)
						{
							black.g = greenVertexColor[j].Evaluate(spline, t, settings.color.pathIndexUnit, new SplineMesher.VertexColorChannel.LerpVertexColorData(black.g));
							setVertexColor = true;
						}
						if (flag5 && blueVertexColor[j].Count > 0)
						{
							black.b = blueVertexColor[j].Evaluate(spline, t, settings.color.pathIndexUnit, new SplineMesher.VertexColorChannel.LerpVertexColorData(black.b));
							setVertexColor = true;
						}
						if (flag6 && alphaVertexColor[j].Count > 0)
						{
							black.a = alphaVertexColor[j].Evaluate(spline, t, settings.color.pathIndexUnit, new SplineMesher.VertexColorChannel.LerpVertexColorData(black.a));
							setVertexColor = true;
						}
						if (settings.conforming.enable && PerformConforming(math.transform(splineLocalToWorld, float10), settings.conforming, y, out var hitPosition, out var hitNormal))
						{
							hitPosition = splineContainer.transform.InverseTransformPoint(hitPosition);
							hitNormal = splineContainer.transform.InverseTransformVector(hitNormal);
							float10.y = hitPosition.y;
							quaternion quaternion3 = quaternion.LookRotationSafe(tangent, hitNormal);
							if (settings.conforming.align)
							{
								quaternion2 = quaternion3;
							}
							if (settings.conforming.blendNormal)
							{
								q = quaternion3;
							}
						}
						float10 += float8 * settings.deforming.curveOffset.x;
						float10.y += settings.deforming.curveOffset.y;
						float3 float11 = (float3)sourceVertices[m] + math.forward() * settings.distribution.spacing;
						float11.x += settings.deforming.pivotOffset.x;
						float11.y += settings.deforming.pivotOffset.y;
						float3 float12 = float10 + math.rotate(quaternion2, float11 * float9);
						float3 xyz = math.mul(splineLocalToWorld, new float4(float12, 1f)).xyz;
						xyz = math.mul(worldToLocalMatrix, new float4(xyz, 1f)).xyz;
						if (hasUV)
						{
							Vector4 vector = sourceUv0[m];
							if (settings.uv.stretchMode == Settings.UV.StretchMode.U)
							{
								vector.x = num13;
							}
							if (settings.uv.stretchMode == Settings.UV.StretchMode.V)
							{
								vector.y = num13;
							}
							vector = vector * settings.uv.scale + settings.uv.offset;
							if (settings.mesh.storeGradientsInUV)
							{
								vector.z = num13;
								vector.w = math.abs(float11.y / (y * float9.y));
							}
							uv0.Add(vector);
						}
						float3 float13 = math.rotate(q, sourceNormals[m]);
						if (hasTangents)
						{
							float4 float14 = new float4(sourceTangents[m]);
							float3 xyz2 = math.rotate(q, float14.xyz);
							if (hasUV && settings.uv.scale.y < 0f)
							{
								float14.w *= -1f;
							}
							tangents.Add(new float4(xyz2, float14.w));
						}
						boundsMin = math.min(float12, boundsMin);
						boundsMax = math.max(float12, boundsMax);
						vertices.Add(xyz);
						normals.Add(float13);
						if (setVertexColor)
						{
							colors.Add(black);
						}
					}
					for (int n = 0; n < subMeshCount; n++)
					{
						int num17 = sourceTriangles[n].Length;
						for (int num18 = 0; num18 < num17; num18++)
						{
							triangles[n].Insert(l * num17 + num18, sourceTriangles[n][num18] + num * l);
						}
					}
				}
				int count2 = vertices.Count;
				num2 += count2 * subMeshCount;
				mesh.indexFormat = ((count2 >= 65535) ? IndexFormat.UInt32 : IndexFormat.UInt16);
				mesh.SetVertices(vertices, 0, count2, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontRecalculateBounds);
				mesh.SetNormals(normals, 0, count2, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontRecalculateBounds);
				if (hasTangents)
				{
					mesh.SetTangents(tangents);
				}
				if (hasUV)
				{
					mesh.SetUVs(0, uv0);
				}
				if (setVertexColor)
				{
					mesh.SetColors(colors);
				}
				for (int num19 = 0; num19 < subMeshCount; num19++)
				{
					mesh.SetIndices(triangles[num19], MeshTopology.Triangles, num19, calculateBounds: false);
					CombineInstance item = new CombineInstance
					{
						mesh = mesh,
						subMeshIndex = num19
					};
					combineInstances.Add(item);
				}
				int CalculateSegments()
				{
					return CalculateSegmentCount(settings, splineLength, segmentLength, spline.Closed);
				}
			}
			outputMesh.Clear();
			outputMesh.indexFormat = ((num2 >= 65535) ? IndexFormat.UInt32 : IndexFormat.UInt16);
			outputMesh.CombineMeshes(combineInstances.ToArray(), subMeshCount == 1, useMatrices: false);
			outputMesh.UploadMeshData(!settings.mesh.keepReadable);
			outputMesh.bounds.SetMinMax(boundsMin, boundsMax);
			outputMesh.name = sourceMesh.name + " Spline";
			return outputMesh;
		}

		public static bool PerformConforming(float3 positionWS, Settings.Conforming settings, float objectHeight, out float3 hitPosition, out float3 hitNormal)
		{
			bool flag = false;
			float num = math.max(objectHeight + settings.seekDistance, 1f);
			hitPosition = float3.zero;
			hitNormal = float3.zero;
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(positionWS + math.up() * num, -math.up(), out hitInfo, num * 2f, settings.layerMask, QueryTriggerInteraction.Ignore))
			{
				flag = true;
				if (settings.terrainOnly)
				{
					flag = hitInfo.collider.GetType() == typeof(TerrainCollider);
					if (!flag)
					{
						return false;
					}
				}
				hitPosition = hitInfo.point;
				hitNormal = hitInfo.normal;
			}
			return flag;
		}

		public static Mesh TransformMesh(Mesh input, Vector3 rotation, bool flipX, bool flipY)
		{
			float num = math.abs(math.length(rotation));
			if (num > 0.01f || flipX || flipY)
			{
				Vector3[] array = input.vertices;
				int num2 = array.Length;
				Vector3[] array2 = input.normals;
				int[] array3 = input.triangles;
				int num3 = array3.Length;
				Bounds bounds = input.bounds;
				if (num > 0.01f)
				{
					ref float x = ref rotation.x;
					ref float z = ref rotation.z;
					float z2 = rotation.z;
					float x2 = rotation.x;
					x = z2;
					z = x2;
					bounds = default(Bounds);
					Quaternion quaternion2 = Quaternion.Euler(rotation);
					for (int i = 0; i < num2; i++)
					{
						array[i] = math.rotate(quaternion2, array[i]);
						bounds.Encapsulate(array[i]);
						array2[i] = math.rotate(quaternion2, array2[i]);
					}
				}
				if (flipX || flipY)
				{
					int num4 = num3 / 3;
					for (int j = 0; j < num4; j++)
					{
						ref int reference = ref array3[j * 3];
						ref int reference2 = ref array3[j * 3 + 1];
						int num5 = array3[j * 3 + 1];
						int num6 = array3[j * 3];
						reference = num5;
						reference2 = num6;
					}
					Quaternion quaternion3 = Quaternion.Euler(flipY ? 180f : 0f, flipX ? 180f : 0f, 0f);
					for (int k = 0; k < num2; k++)
					{
						array2[k] = math.rotate(quaternion3, array2[k]);
					}
				}
				Mesh mesh = new Mesh();
				mesh.name = input.name;
				mesh.SetVertices(array, 0, num2, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontRecalculateBounds);
				mesh.triangles = array3;
				mesh.bounds = bounds;
				mesh.uv = input.uv;
				mesh.uv2 = input.uv2;
				mesh.normals = array2;
				mesh.colors = input.colors;
				mesh.tangents = input.tangents;
				mesh.subMeshCount = input.subMeshCount;
				mesh.UploadMeshData(!input.isReadable);
				return mesh;
			}
			return input;
		}

		public static quaternion RollCorrectedRotation(float3 forward)
		{
			return quaternion.LookRotation(forward, math.up());
		}

		public static Mesh CreateBoundsMesh(Mesh sourceMesh, int subdivisions = 0, bool caps = false)
		{
			Bounds bounds = sourceMesh.bounds;
			Mesh mesh = new Mesh();
			mesh.name = sourceMesh.name + " Bounds";
			Vector3 size = bounds.size;
			Vector3 center = bounds.center;
			int num = 4;
			subdivisions = Mathf.Max(0, subdivisions);
			int num2 = subdivisions + 1;
			int num3 = num + 1;
			int num4 = num2 + 1;
			int num5 = num3 * num4;
			List<Vector3> list = new List<Vector3>();
			List<int> list2 = new List<int>();
			float num6 = size.z / (float)num2;
			Vector3 item = default(Vector3);
			for (int i = 0; i < num4; i++)
			{
				for (int j = 0; j < num3; j++)
				{
					item.x = corners[j].x * size.x + center.x;
					item.y = corners[j].y * size.y + center.y;
					item.z = (float)i * num6 - size.z * 0.5f + center.z;
					list.Add(item);
				}
				if (i < num4 - 1)
				{
					for (int k = 0; k < num; k++)
					{
						list2.Insert(0, i * num3 + k);
						list2.Insert(1, (i + 1) * num3 + k);
						list2.Insert(2, i * num3 + k + 1);
						list2.Insert(3, (i + 1) * num3 + k);
						list2.Insert(4, (i + 1) * num3 + k + 1);
						list2.Insert(5, i * num3 + k + 1);
					}
				}
			}
			if (caps)
			{
				list2.Add(1);
				list2.Add(2);
				list2.Add(0);
				list2.Add(2);
				list2.Add(3);
				list2.Add(0);
				list2.Add(num5 - 4);
				list2.Add(num5 - 5);
				list2.Add(num5 - 3);
				list2.Add(num5 - 2);
				list2.Add(num5 - 3);
				list2.Add(num5 - 5);
			}
			mesh.SetVertices(list, 0, num5, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
			mesh.subMeshCount = 1;
			mesh.SetIndices(list2, MeshTopology.Triangles, 0, calculateBounds: false);
			mesh.RecalculateNormals();
			mesh.bounds = bounds;
			return mesh;
		}
	}
}
