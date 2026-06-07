using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DV.Utils;
using UnityEngine;
using UnityEngine.Rendering;

namespace DV.VFX
{
	public class DeferredDecalRenderer : SingletonBehaviour<DeferredDecalRenderer>
	{
		private const CameraEvent EVENT = CameraEvent.BeforeReflections;

		private const string NAME = "DeferredDecalRenderer";

		private const int MAX_INSTANCING = 1023;

		private List<DeferredDecal> decals = new List<DeferredDecal>();

		private List<Transform> decalTransforms = new List<Transform>();

		private List<Material> closeMaterials = new List<Material>();

		private List<Material> farMaterials = new List<Material>();

		private List<List<DeferredDecal>> decalsPerMaterial = new List<List<DeferredDecal>>();

		private List<List<float>> distancesPerMaterial = new List<List<float>>();

		private int chunks;

		private int cid;

		private List<Matrix4x4[]> matricesChunk = new List<Matrix4x4[]>();

		private static readonly RenderTargetIdentifier[] GBufferTargetsVR = new RenderTargetIdentifier[4]
		{
			BuiltinRenderTextureType.GBuffer0,
			BuiltinRenderTextureType.GBuffer1,
			BuiltinRenderTextureType.GBuffer2,
			BuiltinRenderTextureType.GBuffer3
		};

		private static readonly RenderTargetIdentifier[] GBufferTargetsNonVR = new RenderTargetIdentifier[4]
		{
			BuiltinRenderTextureType.GBuffer0,
			BuiltinRenderTextureType.GBuffer1,
			BuiltinRenderTextureType.GBuffer2,
			BuiltinRenderTextureType.CameraTarget
		};

		private Camera lastCamera;

		private CommandBuffer drawBuffer;

		private Mesh unitCubeMesh;

		private bool vr;

		private int lastInsideBatches;

		private int lastInsideInstances;

		private int lastOutsideBatches;

		private int lastOutsideInstances;

		public new static string AllowAutoCreate()
		{
			return "[DeferredDecalRenderer]";
		}

		protected override void Initialize()
		{
			base.Initialize();
			vr = VRManager.IsVREnabled();
			unitCubeMesh = new Mesh
			{
				vertices = new Vector3[8]
				{
					new Vector3(-0.5f, -0.5f, -0.5f),
					new Vector3(-0.5f, -0.5f, 0.5f),
					new Vector3(-0.5f, 0.5f, -0.5f),
					new Vector3(-0.5f, 0.5f, 0.5f),
					new Vector3(0.5f, -0.5f, -0.5f),
					new Vector3(0.5f, -0.5f, 0.5f),
					new Vector3(0.5f, 0.5f, -0.5f),
					new Vector3(0.5f, 0.5f, 0.5f)
				},
				triangles = new int[36]
				{
					0, 1, 2, 2, 1, 3, 4, 6, 5, 5,
					6, 7, 0, 4, 1, 1, 4, 5, 2, 3,
					6, 6, 3, 7, 0, 2, 4, 4, 2, 6,
					1, 5, 3, 3, 5, 7
				}
			};
			unitCubeMesh.UploadMeshData(markNoLongerReadable: true);
		}

		private void Start()
		{
			if (!SingletonBehaviour<GraphicsOptions>.Instance.IsBlobOcclusionOn)
			{
				base.enabled = false;
			}
		}

		public void RegisterDecal(DeferredDecal decal)
		{
			decals.Add(decal);
			decalTransforms.Add(decal.transform);
			decal.DecalID = decals.Count - 1;
			decal.SquaredBoundingSphere = decal.transform.lossyScale.magnitude * 0.5f + 0.1f;
			decal.SquaredBoundingSphere *= decal.SquaredBoundingSphere;
			int num = closeMaterials.IndexOf(decal.materialClose);
			if (num < 0)
			{
				closeMaterials.Add(decal.materialClose);
				farMaterials.Add(decal.materialFar);
				decalsPerMaterial.Add(new List<DeferredDecal>());
				distancesPerMaterial.Add(new List<float>());
				num = closeMaterials.Count - 1;
			}
			decalsPerMaterial[num].Add(decal);
			distancesPerMaterial[num].Add(0f);
			decal.PerMaterialID = decalsPerMaterial[num].Count - 1;
			decal.MaterialID = num;
		}

		public void UnregisterDecal(DeferredDecal decal)
		{
			decals.Remove(decal);
			decalTransforms.Remove(decal.transform);
			for (int i = decal.DecalID; i < decals.Count; i++)
			{
				decals[i].DecalID = i;
			}
			decalsPerMaterial[decal.MaterialID].RemoveAt(decal.PerMaterialID);
			distancesPerMaterial[decal.MaterialID].RemoveAt(decal.PerMaterialID);
			for (int j = decal.PerMaterialID; j < decalsPerMaterial[decal.MaterialID].Count; j++)
			{
				decalsPerMaterial[decal.MaterialID][j].PerMaterialID = j;
			}
		}

		private void OnEnable()
		{
			lastCamera = null;
			drawBuffer = null;
		}

		private void OnDisable()
		{
			if (lastCamera != null)
			{
				RemoveFromCamera(lastCamera);
				lastCamera = null;
				drawBuffer = null;
			}
		}

		private void RemoveFromCamera(Camera cam)
		{
			foreach (CommandBuffer item in from b in lastCamera.GetCommandBuffers(CameraEvent.BeforeReflections)
				where b.name == "DeferredDecalRenderer"
				select b)
			{
				cam.RemoveCommandBuffer(CameraEvent.BeforeReflections, item);
			}
		}

		private bool CheckCamera()
		{
			Camera main = Camera.main;
			if (main == null)
			{
				return false;
			}
			if (main != lastCamera)
			{
				if (lastCamera != null)
				{
					RemoveFromCamera(lastCamera);
				}
				lastCamera = main;
				drawBuffer = main.GetCommandBuffers(CameraEvent.BeforeReflections).FirstOrDefault((CommandBuffer b) => b.name == "DeferredDecalRenderer");
				if (drawBuffer == null)
				{
					drawBuffer = new CommandBuffer
					{
						name = "DeferredDecalRenderer"
					};
					lastCamera.AddCommandBuffer(CameraEvent.BeforeReflections, drawBuffer);
				}
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static bool FloatSignBit(float f)
		{
			return ((uint)(*(int*)(&f)) & int.MinValue) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Vector3 GetPosition(Matrix4x4 matrix)
		{
			float m = matrix.m03;
			float m2 = matrix.m13;
			float m3 = matrix.m23;
			return new Vector3(m, m2, m3);
		}

		private (int batches, int instances) DrawMaterial(List<Material> materialList, bool negativeSign)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < materialList.Count; i++)
			{
				int num3 = chunks;
				for (int j = 0; j < decalsPerMaterial[i].Count; j++)
				{
					DeferredDecal deferredDecal = decalsPerMaterial[i][j];
					if (FloatSignBit(deferredDecal.SquaredBoundingSphere - deferredDecal.SquaredCenterDistance) == negativeSign)
					{
						if (cid >= 1023)
						{
							chunks++;
							cid = 0;
						}
						while (chunks >= matricesChunk.Count)
						{
							matricesChunk.Add(new Matrix4x4[1023]);
						}
						matricesChunk[chunks][cid] = deferredDecal.LocalToWorld;
						cid++;
					}
				}
				if (cid > 0)
				{
					chunks++;
				}
				for (int k = num3; k < chunks; k++)
				{
					int num4 = ((k < chunks - 1) ? 1023 : cid);
					if (num4 > 0)
					{
						drawBuffer.DrawMeshInstanced(unitCubeMesh, 0, materialList[i], 0, matricesChunk[k], num4);
						num += num4;
						num2++;
					}
				}
				cid = 0;
			}
			return (batches: num2, instances: num);
		}

		private void LateUpdate()
		{
			if (CheckCamera())
			{
				Vector3 position = lastCamera.transform.position;
				for (int i = 0; i < decals.Count; i++)
				{
					decals[i].LocalToWorld = decalTransforms[i].localToWorldMatrix;
					decals[i].SquaredCenterDistance = (position - GetPosition(decals[i].LocalToWorld)).sqrMagnitude;
				}
				drawBuffer.Clear();
				drawBuffer.SetRenderTarget(vr ? GBufferTargetsVR : GBufferTargetsNonVR, BuiltinRenderTextureType.CameraTarget);
				chunks = 0;
				cid = 0;
				(lastInsideBatches, lastInsideInstances) = DrawMaterial(closeMaterials, negativeSign: false);
				(lastOutsideBatches, lastOutsideInstances) = DrawMaterial(farMaterials, negativeSign: true);
			}
		}
	}
}
