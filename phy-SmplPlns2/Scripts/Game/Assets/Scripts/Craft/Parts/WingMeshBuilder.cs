using System.Collections.Generic;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Craft.Parts.Modifiers;
using Unity.Collections;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class WingMeshBuilder
	{
		private PartMaterialScript _partMaterialScript;

		private WingScript _wingScript;

		public WingMeshBuilder(WingScript wingScript, PartMaterialScript partMaterialScript)
		{
			_wingScript = wingScript;
			_partMaterialScript = partMaterialScript;
		}

		public Mesh BuildColliderMesh()
		{
			float num = _wingScript.Wing.BaseChord;
			if (num < 0.0625f)
			{
				num = 0.0625f;
			}
			float num2 = _wingScript.Wing.BaseThickness;
			float num3 = _wingScript.Wing.TipThickness;
			if (num2 == 0f && num3 == 0f)
			{
				num2 = (num3 = 0.01f);
			}
			Mesh mesh = new Mesh();
			mesh.name = "WingColliderMesh";
			BuildSectionMesh(mesh, num2, num3, 0f, _wingScript.Wing.WingSpan, num, _wingScript.Wing.TipChord, 0f, _wingScript.WingSweep, 0f, 1f, Vector3.zero, 0, 0);
			return mesh;
		}

		public void BuildControlSurface(float spanStart, float span, float baseChord, float tipChord, float sweepStart, float sweepEnd, ControlSurfaceScript controlSurface)
		{
			float chordStart = 0f;
			float hingeDistanceFromTrailingEdge = _wingScript.Wing.HingeDistanceFromTrailingEdge;
			Vector3 vector = default(Vector3);
			vector.x = 0f;
			vector.y = spanStart + span / 2f;
			vector.z = sweepStart - baseChord / 2f + hingeDistanceFromTrailingEdge * baseChord;
			float num = sweepStart - baseChord / 2f + hingeDistanceFromTrailingEdge * baseChord;
			float num2 = sweepEnd - tipChord / 2f + hingeDistanceFromTrailingEdge * tipChord;
			vector.z = (num + num2) / 2f;
			Mesh mesh = new Mesh();
			mesh.name = "ControlSurfaceMesh";
			controlSurface.Mesh = mesh;
			BuildSectionMesh(mesh, _wingScript.Wing.BaseThickness, _wingScript.Wing.TipThickness, spanStart, span, baseChord, tipChord, sweepStart, sweepEnd, chordStart, hingeDistanceFromTrailingEdge, vector, _partMaterialScript.MaterialIdSecondary, _wingScript.PartScript.Part.Id);
			controlSurface.transform.localPosition = vector;
			controlSurface.HingeAxis = new Vector3(0f, span, num2 - num);
		}

		public void BuildControlSurfaceHelper(float start, float end, ControlSurfaceScript controlSurface)
		{
			float span = end - start;
			float num = (_wingScript.Wing.TipChord - _wingScript.Wing.BaseChord) / _wingScript.Wing.WingSpan;
			float baseChord = _wingScript.Wing.BaseChord + num * start;
			float tipChord = _wingScript.Wing.BaseChord + num * end;
			float num2 = _wingScript.WingSweep / _wingScript.Wing.WingSpan;
			float sweepStart = num2 * start;
			float sweepEnd = num2 * end;
			BuildControlSurface(start, span, baseChord, tipChord, sweepStart, sweepEnd, controlSurface);
		}

		public void BuildSectionMesh(Mesh mesh, float baseThickness, float tipThickness, float spanStart, float span, float baseChord, float tipChord, float sweepStart, float sweepEnd, float chordStart, float chordEnd, Vector3 center, int materialId, int partId)
		{
			float t = Mathf.InverseLerp(0f, _wingScript.Wing.WingSpan, spanStart);
			float t2 = Mathf.InverseLerp(0f, _wingScript.Wing.WingSpan, spanStart + span);
			float a = 0.1f * baseThickness;
			float b = 0.1f * tipThickness;
			float num = Mathf.Lerp(a, b, t);
			float num2 = Mathf.Lerp(a, b, t2);
			Vector3[] array = new Vector3[8];
			float num3 = baseChord * chordEnd - baseChord / 2f;
			float num4 = baseChord * chordStart - baseChord / 2f;
			array[0] = new Vector3((0f - num) * 0.5f, spanStart, num3 + sweepStart);
			array[1] = new Vector3(num * 0.5f, spanStart, num3 + sweepStart);
			array[2] = new Vector3(num * 0.5f, spanStart, num4 + sweepStart);
			array[3] = new Vector3((0f - num) * 0.5f, spanStart, num4 + sweepStart);
			float num5 = tipChord * chordEnd - tipChord / 2f;
			float num6 = tipChord * chordStart - tipChord / 2f;
			array[4] = new Vector3((0f - num2) * 0.5f, spanStart + span, num5 + sweepEnd);
			array[5] = new Vector3(num2 * 0.5f, spanStart + span, num5 + sweepEnd);
			array[6] = new Vector3(num2 * 0.5f, spanStart + span, num6 + sweepEnd);
			array[7] = new Vector3((0f - num2) * 0.5f, spanStart + span, num6 + sweepEnd);
			for (int i = 0; i < 8; i++)
			{
				array[i] -= center;
			}
			CreateCubeMesh(mesh, array, materialId, partId);
			mesh.RecalculateBounds();
		}

		public void UpdateMesh()
		{
			if (_wingScript.ControlSurfaces.Count > 0)
			{
				List<Mesh> list = new List<Mesh>();
				float num = 0f;
				float num2 = 0f;
				foreach (ControlSurfaceScript controlSurface in _wingScript.ControlSurfaces)
				{
					int num3 = Mathf.Min(controlSurface.ControlSurface.Start, _wingScript.SimulationSectionCount - 1);
					num = (float)num3 / (float)_wingScript.SimulationSectionCount * _wingScript.Wing.WingSpan;
					if (num > num2)
					{
						list.Add(BuildSectionMeshHelper(num2, num, null));
					}
					num2 = (float)Mathf.Min(num3 + controlSurface.ControlSurface.Length, _wingScript.SimulationSectionCount) / (float)_wingScript.SimulationSectionCount * _wingScript.Wing.WingSpan;
					list.Add(BuildSectionMeshHelper(num, num2, controlSurface));
				}
				if (num2 < _wingScript.Wing.WingSpan)
				{
					list.Add(BuildSectionMeshHelper(num2, _wingScript.Wing.WingSpan, null));
				}
				CombineInstance[] array = new CombineInstance[list.Count];
				for (int i = 0; i < list.Count; i++)
				{
					array[i] = default(CombineInstance);
					array[i].transform = Matrix4x4.identity;
					array[i].mesh = list[i];
				}
				Mesh mesh = new Mesh();
				mesh.name = "WingMesh_Combined";
				_wingScript.Mesh = mesh;
				mesh.CombineMeshes(array);
				{
					foreach (Mesh item in list)
					{
						Object.Destroy(item);
					}
					return;
				}
			}
			Mesh mesh2 = new Mesh();
			mesh2.name = "WingMesh";
			_wingScript.Mesh = mesh2;
			BuildSectionMesh(mesh2, _wingScript.Wing.BaseThickness, _wingScript.Wing.TipThickness, 0f, _wingScript.Wing.WingSpan, _wingScript.Wing.BaseChord, _wingScript.Wing.TipChord, 0f, _wingScript.WingSweep, 0f, 1f, Vector3.zero, _partMaterialScript.MaterialIdPrimary, _wingScript.PartScript.Part.Id);
		}

		private static void CreateCubeMesh(Mesh mesh, Vector3[] p, int materialId, int partId)
		{
			Vector3[] vertices = new Vector3[24]
			{
				p[0],
				p[1],
				p[2],
				p[3],
				p[7],
				p[4],
				p[0],
				p[3],
				p[4],
				p[5],
				p[1],
				p[0],
				p[6],
				p[7],
				p[3],
				p[2],
				p[5],
				p[6],
				p[2],
				p[1],
				p[7],
				p[6],
				p[5],
				p[4]
			};
			Vector3 up = Vector3.up;
			Vector3 down = Vector3.down;
			Vector3 forward = Vector3.forward;
			Vector3 back = Vector3.back;
			Vector3 left = Vector3.left;
			Vector3 right = Vector3.right;
			Vector3[] normals = new Vector3[24]
			{
				down, down, down, down, left, left, left, left, forward, forward,
				forward, forward, back, back, back, back, right, right, right, right,
				up, up, up, up
			};
			NativeArray<Vector3> uvs = new NativeArray<Vector3>(24, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < uvs.Length; i++)
			{
				uvs[i] = new Vector3(materialId, DecalLayers.DefaultRenderingLayerFloat, partId);
			}
			int[] triangles = new int[36]
			{
				3, 1, 0, 3, 2, 1, 7, 5, 4, 7,
				6, 5, 11, 9, 8, 11, 10, 9, 15, 13,
				12, 15, 14, 13, 19, 17, 16, 19, 18, 17,
				23, 21, 20, 23, 22, 21
			};
			mesh.vertices = vertices;
			mesh.normals = normals;
			mesh.SetUVs(1, uvs);
			mesh.triangles = triangles;
			mesh.RecalculateBounds();
			uvs.Dispose();
		}

		private Mesh BuildSectionMeshHelper(float start, float end, ControlSurfaceScript controlSurface)
		{
			float span = end - start;
			float num = (_wingScript.Wing.TipChord - _wingScript.Wing.BaseChord) / _wingScript.Wing.WingSpan;
			float baseChord = _wingScript.Wing.BaseChord + num * start;
			float tipChord = _wingScript.Wing.BaseChord + num * end;
			float num2 = _wingScript.WingSweep / _wingScript.Wing.WingSpan;
			float sweepStart = num2 * start;
			float sweepEnd = num2 * end;
			float chordStart = 0f;
			if (controlSurface != null)
			{
				BuildControlSurface(start, span, baseChord, tipChord, sweepStart, sweepEnd, controlSurface);
				chordStart = _wingScript.Wing.HingeDistanceFromTrailingEdge;
			}
			Mesh mesh = new Mesh();
			mesh.name = "WingSectionMesh";
			BuildSectionMesh(mesh, _wingScript.Wing.BaseThickness, _wingScript.Wing.TipThickness, start, span, baseChord, tipChord, sweepStart, sweepEnd, chordStart, 1f, Vector3.zero, _partMaterialScript.MaterialIdPrimary, _wingScript.PartScript.Part.Id);
			return mesh;
		}
	}
}
