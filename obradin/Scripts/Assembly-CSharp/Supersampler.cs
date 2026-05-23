using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Supersampler.asset", menuName = "Supersampler", order = 42)]
public class Supersampler : ScriptableObject
{
	private class Patch : IDisposable
	{
		public Vector2 viewport0;

		public Vector2 viewport1;

		public Mesh srcMesh;

		public Mesh dstMesh;

		public MaterialPropertyBlock srcBlock;

		public MaterialPropertyBlock dstBlock;

		public Patch(Vector2 viewport0_, Vector2 viewport1_)
		{
			viewport0 = viewport0_;
			viewport1 = viewport1_;
			srcMesh = new Mesh();
			dstMesh = new Mesh();
			srcBlock = new MaterialPropertyBlock();
			dstBlock = new MaterialPropertyBlock();
		}

		public void Dispose()
		{
			if (srcMesh != null)
			{
				UnityEngine.Object.DestroyImmediate(srcMesh);
			}
			if (dstMesh != null)
			{
				UnityEngine.Object.DestroyImmediate(dstMesh);
			}
		}
	}

	public Shader shader;

	private Material supersampleMaterial;

	private CommandBuffer commandBuffer;

	private List<Patch> patches;

	public void Blit(int divisions, RenderTexture src, RenderTexture dst, Material blitMaterial, int blitPass)
	{
		if (supersampleMaterial == null)
		{
			supersampleMaterial = new Material(shader);
			commandBuffer = new CommandBuffer();
		}
		if (patches == null || patches.Count != divisions * divisions)
		{
			CreatePatches(divisions);
		}
		int width = 2 * (src.width / divisions);
		int height = 2 * (src.height / divisions);
		supersampleMaterial.SetVector("_ChannelAverageOrMaximum", new Vector4(0f, 1f, 1f, 1f));
		Matrix4x4 identity = Matrix4x4.identity;
		using (RenderTargetPool.Temp temp = RenderTargetPool.CreateTemp(width, height, RenderTextureFormat.ARGB32, FilterMode.Point))
		{
			commandBuffer.Clear();
			commandBuffer.SetViewProjectionMatrices(Matrix4x4.identity, Matrix4x4.identity);
			foreach (Patch patch in patches)
			{
				patch.srcBlock.SetTexture("_MainTex", src);
				patch.dstBlock.SetTexture("_MainTex", (RenderTexture)temp);
				commandBuffer.SetRenderTarget(temp.rt);
				commandBuffer.SetViewProjectionMatrices(identity, identity);
				commandBuffer.DrawMesh(patch.srcMesh, identity, blitMaterial, 0, blitPass, patch.srcBlock);
				commandBuffer.SetRenderTarget(dst);
				commandBuffer.SetViewProjectionMatrices(identity, identity);
				commandBuffer.SetGlobalVector("_TargetSize", new Vector2(dst.width, dst.height));
				commandBuffer.DrawMesh(patch.dstMesh, identity, supersampleMaterial, 0, 0, patch.dstBlock);
			}
			Graphics.ExecuteCommandBuffer(commandBuffer);
		}
		commandBuffer.Clear();
	}

	private static Vector3 Lerp(Vector3 a, Vector3 b, Vector3 t)
	{
		return new Vector3(Mathf.Lerp(a.x, b.x, t.x), Mathf.Lerp(a.y, b.y, t.y), Mathf.Lerp(a.z, b.z, t.z));
	}

	private static Vector2 Lerp(Vector2 a, Vector2 b, Vector2 t)
	{
		return new Vector2(Mathf.Lerp(a.x, b.x, t.x), Mathf.Lerp(a.y, b.y, t.y));
	}

	private void CreatePatches(int divisions)
	{
		if (patches != null)
		{
			foreach (Patch patch2 in patches)
			{
				patch2.Dispose();
			}
		}
		patches = new List<Patch>();
		Vector3 a = new Vector3(-1f, -1f, 1f);
		Vector3 b = new Vector3(1f, 1f, 1f);
		Vector2 a2 = new Vector2(0f, 0f);
		Vector2 b2 = new Vector2(1f, 1f);
		for (int i = 0; i < divisions; i++)
		{
			float y = (float)i / (float)divisions;
			float y2 = (float)(i + 1) / (float)divisions;
			for (int j = 0; j < divisions; j++)
			{
				float x = (float)j / (float)divisions;
				float x2 = (float)(j + 1) / (float)divisions;
				Patch patch = new Patch(new Vector2(x, y), new Vector2(x2, y2));
				patch.srcMesh.vertices = new Vector3[4]
				{
					Lerp(a, b, new Vector3(0f, 0f, 0f)),
					Lerp(a, b, new Vector3(1f, 0f, 0f)),
					Lerp(a, b, new Vector3(1f, 1f, 0f)),
					Lerp(a, b, new Vector3(0f, 1f, 0f))
				};
				patch.srcMesh.uv = new Vector2[4]
				{
					Lerp(a2, b2, new Vector2(x, y)),
					Lerp(a2, b2, new Vector2(x2, y)),
					Lerp(a2, b2, new Vector2(x2, y2)),
					Lerp(a2, b2, new Vector2(x, y2))
				};
				patch.dstMesh.vertices = new Vector3[4]
				{
					Lerp(a, b, new Vector3(x, y, 0f)),
					Lerp(a, b, new Vector3(x2, y, 0f)),
					Lerp(a, b, new Vector3(x2, y2, 0f)),
					Lerp(a, b, new Vector3(x, y2, 0f))
				};
				patch.dstMesh.uv = new Vector2[4]
				{
					Lerp(a2, b2, new Vector2(0f, 0f)),
					Lerp(a2, b2, new Vector2(1f, 0f)),
					Lerp(a2, b2, new Vector2(1f, 1f)),
					Lerp(a2, b2, new Vector2(0f, 1f))
				};
				patch.srcMesh.triangles = new int[6] { 0, 3, 2, 0, 2, 1 };
				patch.dstMesh.triangles = patch.srcMesh.triangles;
				patch.srcMesh.RecalculateNormals();
				patch.srcMesh.UploadMeshData(true);
				patch.dstMesh.RecalculateNormals();
				patch.dstMesh.UploadMeshData(true);
				patches.Add(patch);
			}
		}
	}
}
