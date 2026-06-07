using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.XR;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft
{
	public class GlassGroupScript : PartGroupScript
	{
		[BurstCompile(CompileSynchronously = true, DisableSafetyChecks = true)]
		private struct CombineJobGlass : IJob
		{
			public Mesh.MeshData DestinationMesh;

			[ReadOnly]
			[NoAlias]
			public NativeArray<Matrix4x4> Matrices;

			[ReadOnly]
			public Mesh.MeshDataArray SourceMeshes;

			[ReadOnly]
			public int VertexCount;

			public void Execute()
			{
				NativeArray<CombinedMeshVertex> vertexData = DestinationMesh.GetVertexData<CombinedMeshVertex>();
				int num = 0;
				int length = SourceMeshes.Length;
				for (int i = 0; i < length; i++)
				{
					Mesh.MeshData meshData = SourceMeshes[i];
					Matrix4x4 matrix4x = Matrices[i];
					int vertexCount = meshData.vertexCount;
					NativeArray<Vector3> outVertices = new NativeArray<Vector3>(vertexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					NativeArray<Vector3> outNormals = new NativeArray<Vector3>(vertexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					NativeArray<Vector2> outUVs = new NativeArray<Vector2>(vertexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					NativeArray<Vector3> outUVs2 = new NativeArray<Vector3>(vertexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					NativeArray<Vector3> outUVs3 = new NativeArray<Vector3>(vertexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					NativeArray<Vector3> outUVs4 = new NativeArray<Vector3>(vertexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					meshData.GetVertices(outVertices);
					meshData.GetNormals(outNormals);
					if (meshData.HasVertexAttribute(VertexAttribute.TexCoord0))
					{
						meshData.GetUVs(0, outUVs);
					}
					if (meshData.HasVertexAttribute(VertexAttribute.TexCoord1))
					{
						meshData.GetUVs(1, outUVs2);
					}
					if (meshData.HasVertexAttribute(VertexAttribute.TexCoord2))
					{
						meshData.GetUVs(2, outUVs3);
					}
					if (meshData.HasVertexAttribute(VertexAttribute.TexCoord3))
					{
						meshData.GetUVs(3, outUVs4);
					}
					for (int j = 0; j < vertexCount; j++)
					{
						vertexData[j + num] = new CombinedMeshVertex
						{
							Position = matrix4x.MultiplyPoint3x4(outVertices[j]),
							Normal = matrix4x.MultiplyVector(outNormals[j]).normalized,
							UV0 = outUVs[j],
							UV1 = outUVs2[j],
							UV2 = outUVs3[j],
							UV3 = outUVs4[j]
						};
					}
					outVertices.Dispose();
					outNormals.Dispose();
					outUVs.Dispose();
					outUVs2.Dispose();
					outUVs3.Dispose();
					outUVs4.Dispose();
					num += vertexCount;
				}
			}
		}

		protected class PartMeshGlass : PartMesh
		{
			public int[] Indices { get; set; }

			public int[] IndicesSecondary { get; set; }
		}

		private static class ShaderPropertyIds
		{
			public static readonly int Alpha = Shader.PropertyToID("_Alpha");

			public static readonly int WaterHeight = Shader.PropertyToID("_WaterHeight");
		}

		private static GameObject _shatterResource;

		private bool _isHollow;

		private MeshRenderer _renderer;

		private bool _shattered;

		private ThemeScript _theme;

		private Material _transparentMaterial;

		private Material _transparentMaterialZWrite;

		public float Opacity { get; set; }

		public PartMaterial PartMaterial => base.Body.Aircraft.Theme.Theme.GetMaterial(PartMaterialIndex);

		public int PartMaterialIndex { get; set; }

		public List<TransparencyData> TransparencyModifiers { get; private set; }

		public void InitFrom(PartData part, TransparencyData modifier)
		{
			_theme = part.PartScript.Aircraft.Theme;
			Opacity = modifier.Opacity;
			PartMaterialIndex = 0;
			_isHollow = modifier.Fuselage.IsHollow;
			if (part.MaterialIds.Count > 0)
			{
				PartMaterialIndex = part.MaterialIds[0];
			}
		}

		public bool IsCompatibleWith(PartData part, TransparencyData modifier)
		{
			if (part.MaterialIds.Count != 0 && part.MaterialIds[0] == PartMaterialIndex && modifier.IsTransparent && modifier.Opacity == Opacity)
			{
				return modifier.Fuselage.IsHollow == _isHollow;
			}
			return false;
		}

		public void Shatter()
		{
			if (!_shattered)
			{
				_shattered = true;
				if (_shatterResource == null)
				{
					_shatterResource = Resources.Load<GameObject>("ParticleEffects/GlassShatterParticles");
				}
				if (!TryGetComponent<MeshFilter>(out var component))
				{
					component = GetComponentInChildren<MeshFilter>();
				}
				Transform transform = component.transform;
				GameObject obj = UnityEngine.Object.Instantiate(_shatterResource);
				obj.SetActive(value: true);
				obj.transform.SetPositionAndRotation(transform.position, transform.rotation);
				ParticleSystem component2 = obj.GetComponent<ParticleSystem>();
				ParticleSystem.ShapeModule shape = component2.shape;
				shape.mesh = component.mesh;
				Material material = component2.GetComponent<ParticleSystemRenderer>().material;
				PartMaterial partMaterial = PartMaterial;
				material.SetFloat("_Metallic", partMaterial.PrimaryColorMetallic * Opacity);
				material.SetFloat("_Glossiness", partMaterial.PrimaryColorSmoothness + partMaterial.SmoothnessModifier);
				Color primaryColor = partMaterial.PrimaryColor;
				primaryColor.a = Mathf.Clamp(Opacity, 0.1f, 1f);
				material.color = primaryColor;
				Rigidbody rigidbody = obj.AddComponent<Rigidbody>();
				rigidbody.linearVelocity = base.Body.RigidBody.GetPointVelocity(transform.position);
				rigidbody.linearDamping = 0.4f;
				component2.Play();
				UnityEngine.Object.Destroy(obj, component2.main.duration);
			}
		}

		protected override void Awake()
		{
			base.Awake();
			TransparencyModifiers = new List<TransparencyData>();
		}

		protected override void CombineMeshes()
		{
			if (_partMeshSurvey.PartMeshes.Count == 0)
			{
				return;
			}
			bool flag = !_isHollow || _partMeshSurvey.IndexCountSecondary == 0;
			Mesh mesh = new Mesh();
			mesh.name = $"GlassPartGroup_{base.Id}_CombinedMesh";
			Mesh.MeshDataArray data = Mesh.AllocateWritableMeshData(1);
			Mesh.MeshData destinationMesh = data[0];
			destinationMesh.SetIndexBufferParams(_partMeshSurvey.IndexCount + _partMeshSurvey.IndexCountSecondary, IndexFormat.UInt16);
			destinationMesh.SetVertexBufferParams(_partMeshSurvey.VertexCount, new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0), new VertexAttributeDescriptor(VertexAttribute.Normal), new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 2), new VertexAttributeDescriptor(VertexAttribute.TexCoord1), new VertexAttributeDescriptor(VertexAttribute.TexCoord2), new VertexAttributeDescriptor(VertexAttribute.TexCoord3));
			NativeArray<Matrix4x4> matrices = new NativeArray<Matrix4x4>(_partMeshSurvey.PartMeshes.Select((PartMesh x) => x.TransformMatrix).ToArray(), Allocator.TempJob);
			try
			{
				new CombineJobGlass
				{
					SourceMeshes = _partMeshSurvey.MeshData.Value,
					DestinationMesh = destinationMesh,
					Matrices = matrices,
					VertexCount = _partMeshSurvey.VertexCount
				}.Schedule().Complete();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				throw;
			}
			matrices.Dispose();
			int num = 0;
			int num2 = 0;
			int num3 = _partMeshSurvey.IndexCount;
			NativeArray<ushort> indexData = destinationMesh.GetIndexData<ushort>();
			foreach (PartMeshGlass partMesh in _partMeshSurvey.PartMeshes)
			{
				int[] indices = partMesh.Indices;
				int indexCount = partMesh.IndexCount;
				for (int num4 = 0; num4 < indexCount; num4++)
				{
					indexData[num2 + num4] = (ushort)(indices[num4] + num);
				}
				if (!flag)
				{
					int[] indicesSecondary = partMesh.IndicesSecondary;
					if (indicesSecondary != null)
					{
						int num5 = indicesSecondary.Length;
						for (int num6 = 0; num6 < num5; num6++)
						{
							indexData[num3 + num6] = (ushort)(indicesSecondary[num6] + num);
						}
						num3 += num5;
					}
				}
				num += partMesh.VertexCount;
				num2 += indexCount;
			}
			destinationMesh.subMeshCount = (flag ? 1 : 2);
			destinationMesh.SetSubMesh(0, new SubMeshDescriptor(0, _partMeshSurvey.IndexCount));
			if (!flag)
			{
				destinationMesh.SetSubMesh(1, new SubMeshDescriptor(_partMeshSurvey.IndexCount, _partMeshSurvey.IndexCountSecondary));
			}
			Mesh.ApplyAndDisposeWritableMeshData(data, mesh);
			mesh.RecalculateBounds();
			num2 = 0;
			_combinedParts = new List<CombinedMeshPart>(_partMeshSurvey.PartMeshes.Count);
			foreach (PartMeshGlass partMesh2 in _partMeshSurvey.PartMeshes)
			{
				int indexCount2 = partMesh2.IndexCount;
				int[] indicesSecondary2 = partMesh2.IndicesSecondary;
				int num7 = indexCount2 + ((indicesSecondary2 != null) ? indicesSecondary2.Length : 0);
				_combinedParts.Add(new CombinedMeshPart(partMesh2.Part, partMesh2.Renderer, num2, num7));
				num2 += num7;
			}
			_combinedMesh = mesh;
		}

		protected virtual void LateUpdate()
		{
			float value = GameWorld.Instance.FloatingOriginSeaLevel ?? float.NegativeInfinity;
			_transparentMaterialZWrite?.SetFloat(ShaderPropertyIds.WaterHeight, value);
			_transparentMaterial?.SetFloat(ShaderPropertyIds.WaterHeight, value);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_theme.ReleaseTransparentPartMaterialInstance(_transparentMaterialZWrite);
			_theme.ReleaseTransparentPartMaterialInstance(_transparentMaterial);
			if (Game.Instance.Device.IsVRBuild)
			{
				Game.Instance.XRDeviceManager.HmdActiveChanged -= OnHmdActiveChanged;
			}
		}

		protected override PartMeshSurvey SurveyPartMeshes()
		{
			Matrix4x4 worldToLocalMatrix = base.transform.worldToLocalMatrix;
			PartMeshSurvey partMeshSurvey = new PartMeshSurvey();
			List<Mesh> list = new List<Mesh>();
			foreach (TransparencyData transparencyModifier in TransparencyModifiers)
			{
				PartData part = transparencyModifier.Part;
				PartScript partScript = transparencyModifier.Part.PartScript;
				TransparencyScript modifier = partScript.GetModifier<TransparencyScript>();
				ulong levelMask = modifier.LevelVisibilityMask;
				ulong secondaryLevelMask = modifier.SecondaryMaterialLevelMask;
				if (!part.PartType.CombineMeshes)
				{
					continue;
				}
				foreach (PartMaterialScript.RendererMaterialMap rendererMap in partScript.PartMaterialScript.RendererMaps)
				{
					MeshRenderer renderer = rendererMap.Renderer;
					MeshFilter component = renderer.GetComponent<MeshFilter>();
					int[] levelMap = rendererMap.SubmeshToLevelMap;
					Mesh mesh = component.mesh;
					int vertexCount = mesh.vertexCount;
					if (vertexCount + partMeshSurvey.VertexCount >= 65000)
					{
						continue;
					}
					int sourceSubmeshCount = mesh.subMeshCount;
					uint num = 0u;
					uint num2 = 0u;
					for (int i = 0; i < sourceSubmeshCount; i++)
					{
						int level = GetLevel(i);
						if (IsRendered(level))
						{
							if (IsSecondary(level))
							{
								num2 += mesh.GetIndexCount(i);
							}
							else
							{
								num += mesh.GetIndexCount(i);
							}
						}
					}
					int[] array = new int[num];
					int num3 = 0;
					int[] array2 = ((num2 == 0) ? null : new int[num2]);
					int num4 = 0;
					int num5 = 0;
					for (int j = 0; j < sourceSubmeshCount; j++)
					{
						int level2 = GetLevel(j);
						if (!IsRendered(level2))
						{
							continue;
						}
						int[] indices = mesh.GetIndices(j);
						if (IsSecondary(level2))
						{
							if (array2 == null)
							{
								continue;
							}
							Array.Copy(indices, 0, array2, num4, indices.Length);
							num4 += indices.Length;
						}
						else
						{
							Array.Copy(indices, 0, array, num3, indices.Length);
							num3 += indices.Length;
						}
						num5++;
					}
					partMeshSurvey.VertexCount += vertexCount;
					partMeshSurvey.IndexCount += (int)num;
					partMeshSurvey.IndexCountSecondary += (int)num2;
					partMeshSurvey.SubmeshCount += num5;
					partMeshSurvey.PartMeshes.Add(new PartMeshGlass
					{
						VertexCount = vertexCount,
						IndexCount = (int)num,
						Indices = array,
						IndicesSecondary = array2,
						TransformMatrix = worldToLocalMatrix * component.transform.localToWorldMatrix,
						Part = part.PartScript,
						Renderer = renderer,
						DragType = part.DragType
					});
					list.Add(mesh);
					int GetLevel(int submeshIndex)
					{
						if (levelMap != null)
						{
							if (submeshIndex >= levelMap.Length)
							{
								return -1;
							}
							return levelMap[submeshIndex];
						}
						if (submeshIndex < sourceSubmeshCount)
						{
							return submeshIndex;
						}
						return -1;
					}
				}
				bool IsRendered(int num6)
				{
					if (num6 >= 0)
					{
						return ((ulong)(1L << num6) & levelMask) != 0;
					}
					return false;
				}
				bool IsSecondary(int num6)
				{
					return ((ulong)(1L << num6) & secondaryLevelMask) != 0;
				}
			}
			if (list.Count > 0)
			{
				partMeshSurvey.MeshData = Mesh.AcquireReadOnlyMeshData(list);
			}
			return partMeshSurvey;
		}

		protected override MeshRenderer SwitchToCombinedMesh()
		{
			_renderer = base.SwitchToCombinedMesh();
			_transparentMaterialZWrite = _theme.RequestTransparentPartMaterialInstance(_isHollow);
			_transparentMaterialZWrite.SetFloat(ShaderPropertyIds.Alpha, Opacity);
			if (_isHollow)
			{
				_transparentMaterial = _theme.RequestTransparentPartMaterialInstance(zwrite: false);
				_transparentMaterial.SetFloat(ShaderPropertyIds.Alpha, Opacity);
				_renderer.sharedMaterials = new Material[2] { _transparentMaterialZWrite, _transparentMaterial };
			}
			else
			{
				_renderer.sharedMaterial = _transparentMaterialZWrite;
			}
			if (Game.Instance.Device.IsVRBuild)
			{
				XRDeviceManager xRDeviceManager = Game.Instance.XRDeviceManager;
				UpdateRendererProperties(xRDeviceManager.HmdActive);
				xRDeviceManager.HmdActiveChanged += OnHmdActiveChanged;
			}
			return _renderer;
		}

		private void OnHmdActiveChanged(bool active)
		{
			UpdateRendererProperties(active);
		}

		private void UpdateRendererProperties(bool vrEnabled)
		{
			MeshRenderer renderer = _renderer;
			renderer.shadowCastingMode = ShadowCastingMode.Off;
			if (vrEnabled)
			{
				renderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
				renderer.lightProbeUsage = LightProbeUsage.Off;
			}
			else
			{
				renderer.reflectionProbeUsage = ReflectionProbeUsage.BlendProbes;
				renderer.lightProbeUsage = LightProbeUsage.BlendProbes;
			}
		}
	}
}
