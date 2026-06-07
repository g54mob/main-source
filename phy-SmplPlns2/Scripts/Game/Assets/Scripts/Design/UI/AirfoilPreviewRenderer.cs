using System.Collections.Generic;
using Assets.Scripts.Craft.MeshGen;
using Assets.Scripts.Craft.Wings;
using Assets.Scripts.Craft.Wings.Airfoils;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design.UI
{
	public class AirfoilPreviewRenderer : MaskableGraphic
	{
		[BurstCompile]
		private struct BuildMeshJob : IJob, SkeletalInsetter.IProfileProvider
		{
			public NativeAirfoil Airfoil;

			public Color Color;

			public float Inset;

			public float2 Origin;

			public float Scale;

			public NativeList<int3> Triangles;

			public NativeList<UIVertex> Vertices;

			void IJob.Execute()
			{
				NativeArray<float2> inPoints = new NativeArray<float2>(Airfoil.TopPoints.Length + Airfoil.BottomPoints.Length - 2, Allocator.Temp);
				for (int i = 0; i < Airfoil.TopPoints.Length; i++)
				{
					inPoints[i] = Airfoil.TopPoints[i];
				}
				for (int j = 0; j < Airfoil.BottomPoints.Length - 2; j++)
				{
					int index = j + Airfoil.TopPoints.Length;
					ref NativeArray<float2> bottomPoints = ref Airfoil.BottomPoints;
					int num = j + 2;
					inPoints[index] = bottomPoints[bottomPoints.Length - num];
				}
				NativeArray<float> insets = new NativeArray<float>(1, Allocator.Temp);
				insets[0] = Inset;
				NativeMesh mesh = new NativeMesh
				{
					Vertices = new NativeList<Vertex>(inPoints.Length * 3, Allocator.Temp),
					Triangles = Triangles,
					Runs = new NativeList<NativeMesh.TriangleRun>(Allocator.Temp)
				};
				SkeletalInsetter.MakeInsetMesh(inPoints, Allocator.Temp, mesh, insets, ref this);
				inPoints.Dispose();
				insets.Dispose();
				Vertices.Resize(mesh.Vertices.Length, NativeArrayOptions.UninitializedMemory);
				for (int k = 0; k < mesh.Vertices.Length; k++)
				{
					Vertex vertex = mesh.Vertices[k];
					Vertices[k] = new UIVertex
					{
						position = new Vector3(vertex.position.x, vertex.position.y, 0f),
						color = Color,
						uv0 = new Vector4(vertex.position.z, vertex.position.z)
					};
				}
				mesh.Vertices.Dispose();
			}

			readonly float4x3 SkeletalInsetter.IProfileProvider.GetTransform(float inset)
			{
				return new float4x3(new float4(Scale, 0f, 0f, 0f), new float4(0f, Scale, 0f, 0f), new float4(Origin, inset / Inset, 1f));
			}
		}

		private IAirfoil _airfoil;

		private Texture2D _lineTexture;

		[SerializeField]
		private float _lineWidth = 0.025f;

		[SerializeField]
		private float _localWidth = 0.85f;

		[SerializeField]
		[Range(4f, 64f)]
		private int _samples = 16;

		public int AirfoilSamples
		{
			get
			{
				return _samples;
			}
			set
			{
				_samples = value;
				SetVerticesDirty();
			}
		}

		public float LineWidth
		{
			get
			{
				return _lineWidth;
			}
			set
			{
				_lineWidth = value;
				SetVerticesDirty();
			}
		}

		public float LocalWidth
		{
			get
			{
				return _localWidth;
			}
			set
			{
				_localWidth = value;
				SetVerticesDirty();
			}
		}

		public override Texture mainTexture
		{
			get
			{
				if (!(_lineTexture == null))
				{
					return _lineTexture;
				}
				return base.mainTexture;
			}
		}

		public void SetAirfoil(IAirfoil airfoil)
		{
			_airfoil = airfoil;
			SetVerticesDirty();
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			vh.Clear();
			if (_airfoil != null)
			{
				NativeAirfoil section = new NativeAirfoil(_samples, Allocator.TempJob);
				_airfoil.GenerateCrossSection(ref section, _samples);
				NativeList<UIVertex> vertices = new NativeList<UIVertex>(_samples * 3, Allocator.TempJob);
				NativeList<int3> triangles = new NativeList<int3>(_samples * 3, Allocator.TempJob);
				new BuildMeshJob
				{
					Airfoil = section,
					Color = color,
					Vertices = vertices,
					Triangles = triangles,
					Inset = LineWidth,
					Origin = -base.rectTransform.pivot,
					Scale = base.rectTransform.rect.width * _localWidth
				}.Run();
				section.Dispose();
				List<UIVertex> list = new List<UIVertex>(vertices.Length);
				List<int> list2 = new List<int>(triangles.Length * 3);
				NativeArray<UIVertex> nativeArray = vertices.AsArray();
				for (int i = 0; i < nativeArray.Length; i++)
				{
					list.Add(nativeArray[i]);
				}
				NativeArray<int> nativeArray2 = triangles.AsArray().Reinterpret<int>(12);
				for (int j = 0; j < nativeArray2.Length; j++)
				{
					list2.Add(nativeArray2[j]);
				}
				vertices.Dispose();
				triangles.Dispose();
				vh.AddUIVertexStream(list, list2);
			}
		}

		protected override void UpdateMaterial()
		{
			if (_lineTexture == null)
			{
				_lineTexture = Resources.Load<Texture2D>("UI/Sprites/LineTexture");
			}
			base.UpdateMaterial();
		}

		[ContextMenu("Set Test NACA4312")]
		private void SetTest()
		{
			SetAirfoil(AirfoilRegistry.ParseAirfoil("NACA4312"));
		}
	}
}
