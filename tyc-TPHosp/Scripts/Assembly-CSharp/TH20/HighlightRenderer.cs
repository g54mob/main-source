using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

namespace TH20
{
	public sealed class HighlightRenderer : PostProcessEffectRenderer<HighlightSettings>
	{
		private List<Renderer> _cachedRenderers = new List<Renderer>(32);

		private Plane[] _cachedCullingPlanes = new Plane[4];

		private string _multisampleKeyword = "MULTISAMPLE";

		private int _pass1_RT_ID;

		private int _pass2_RT_ID;

		private int _mousePosInvRange_ID;

		private int _color_ID;

		private RenderTargetIdentifier _pass1RTIdentifier;

		private RenderTargetIdentifier _pass2RTIdentifier;

		private bool _enableInstancing;

		private Material _highlightApplyPassMaterial;

		private string _sampleName = "Highlight";

		public override void Init()
		{
			base.Init();
			_pass1_RT_ID = Shader.PropertyToID("Highlight Pass 1 RT");
			_pass2_RT_ID = Shader.PropertyToID("Highlight Pass 2 RT");
			_color_ID = Shader.PropertyToID("_Color");
			_pass1RTIdentifier = new RenderTargetIdentifier(_pass1_RT_ID);
			_pass2RTIdentifier = new RenderTargetIdentifier(_pass2_RT_ID);
			_mousePosInvRange_ID = Shader.PropertyToID("_MousePosInvRange");
			_enableInstancing = SystemInfo.supportsInstancing;
		}

		public override void Release()
		{
			base.Release();
			if (_highlightApplyPassMaterial != null)
			{
				Object.Destroy(_highlightApplyPassMaterial);
			}
		}

		public override void Render(PostProcessRenderContext context)
		{
			context.command.BeginSample(_sampleName);
			RuntimeUtilities.CopyTexture(context.command, context.source, context.destination);
			if (context.isSceneView)
			{
				context.command.EndSample(_sampleName);
				return;
			}
			_cachedRenderers.Clear();
			HighlightRendererProxy.Instance.GetRenderers(_cachedRenderers);
			if (_cachedRenderers.Count == 0)
			{
				if (_highlightApplyPassMaterial != null)
				{
					_highlightApplyPassMaterial.SetColor(_color_ID, new Color(1f, 1f, 1f, 0f));
				}
				context.command.EndSample(_sampleName);
				return;
			}
			HighlightRendererResources resources = HighlightRendererProxy.Instance.Resources;
			if (resources == null)
			{
				context.command.EndSample(_sampleName);
				return;
			}
			if (_highlightApplyPassMaterial == null)
			{
				_highlightApplyPassMaterial = new Material(resources.HighlightApplyPassMaterial);
				_highlightApplyPassMaterial.enableInstancing = true;
			}
			float num = (0.5f * (float)context.camera.pixelWidth + 0.5f * (float)context.camera.pixelHeight) * (float)base.settings.HighlightKeyholeSize;
			Vector2 vector = Input.mousePosition;
			_highlightApplyPassMaterial.SetColor(_color_ID, new Color(1f, 1f, 1f, HighlightRendererProxy.Instance.Alpha));
			_highlightApplyPassMaterial.SetVector(_mousePosInvRange_ID, new Vector3(vector.x, vector.y, 1f / num));
			if (context.IsTemporalAntialiasingActive())
			{
				_highlightApplyPassMaterial.EnableKeyword(_multisampleKeyword);
			}
			else
			{
				_highlightApplyPassMaterial.DisableKeyword(_multisampleKeyword);
			}
			Vector3 position = context.camera.transform.position;
			Vector3 up = context.camera.transform.up;
			Vector3 right = context.camera.transform.right;
			Plane plane = new Plane(-Vector3.Cross(up, context.camera.ScreenPointToRay(vector + new Vector2(num, 0f)).direction), position);
			Plane plane2 = new Plane(Vector3.Cross(up, context.camera.ScreenPointToRay(vector + new Vector2(0f - num, 0f)).direction), position);
			Plane plane3 = new Plane(Vector3.Cross(right, context.camera.ScreenPointToRay(vector + new Vector2(0f, num)).direction), position);
			Plane plane4 = new Plane(-Vector3.Cross(right, context.camera.ScreenPointToRay(vector + new Vector2(0f, 0f - num)).direction), position);
			_cachedCullingPlanes[0] = plane;
			_cachedCullingPlanes[1] = plane2;
			_cachedCullingPlanes[2] = plane3;
			_cachedCullingPlanes[3] = plane4;
			context.command.GetTemporaryRT(_pass1_RT_ID, context.camera.pixelWidth, context.camera.pixelHeight, 0, FilterMode.Bilinear, RenderTextureFormat.R8);
			context.command.GetTemporaryRT(_pass2_RT_ID, context.camera.pixelWidth, context.camera.pixelHeight, 0, FilterMode.Bilinear, RenderTextureFormat.R8);
			context.command.SetRenderTarget(_pass1RTIdentifier);
			context.command.ClearRenderTarget(clearDepth: true, clearColor: true, Color.black);
			context.command.SetViewProjectionMatrices(context.camera.worldToCameraMatrix, context.camera.nonJitteredProjectionMatrix);
			RenderHighlightedMesh(context.command, resources.UnlitPassMaterial, _cachedCullingPlanes);
			context.command.Blit(_pass1_RT_ID, _pass2_RT_ID, resources.HighlightExpandPassMaterial);
			context.command.ReleaseTemporaryRT(_pass1_RT_ID);
			context.command.SetRenderTarget(_pass2RTIdentifier);
			RenderHighlightedMesh(context.command, resources.UnlitBlackPassMaterial, _cachedCullingPlanes);
			context.command.Blit(_pass2_RT_ID, context.destination, _highlightApplyPassMaterial);
			context.command.ReleaseTemporaryRT(_pass2_RT_ID);
			context.command.SetRenderTarget(context.destination);
			context.command.SetViewProjectionMatrices(context.camera.worldToCameraMatrix, context.camera.projectionMatrix);
			context.command.EndSample(_sampleName);
		}

		private bool CanBeInstanced(Renderer renderer, int subMeshIndex, out Mesh mesh)
		{
			mesh = null;
			if (!_enableInstancing)
			{
				return false;
			}
			if (subMeshIndex != 0)
			{
				return false;
			}
			MeshRenderer meshRenderer = renderer as MeshRenderer;
			if (meshRenderer == null)
			{
				return false;
			}
			MeshFilter component = meshRenderer.GetComponent<MeshFilter>();
			if (component == null)
			{
				return false;
			}
			mesh = component.sharedMesh;
			return mesh != null;
		}

		private void DrawQueuedMeshes(CommandBuffer commandBuffer, Material material, int count, Mesh mesh, Matrix4x4[] transforms)
		{
			switch (count)
			{
			case 0:
				break;
			case 1:
				commandBuffer.DrawMesh(mesh, transforms[0], material, 0, 0, null);
				break;
			default:
				commandBuffer.DrawMeshInstanced(mesh, 0, material, 0, transforms, count, null);
				break;
			}
		}

		private void RenderHighlightedMesh(CommandBuffer commandBuffer, Material material, Plane[] clipPlanes)
		{
			Mesh mesh = null;
			int num = 0;
			Matrix4x4[] array = new Matrix4x4[64];
			for (int i = 0; i < _cachedRenderers.Count; i++)
			{
				Renderer renderer = _cachedRenderers[i];
				if (renderer == null || !GeometryUtility.TestPlanesAABB(clipPlanes, renderer.bounds))
				{
					continue;
				}
				int num2 = 0;
				SkinnedMeshRenderer skinnedMeshRenderer = renderer as SkinnedMeshRenderer;
				if (skinnedMeshRenderer != null && skinnedMeshRenderer.sharedMesh != null)
				{
					num2 = skinnedMeshRenderer.sharedMesh.subMeshCount;
				}
				else if (renderer is MeshRenderer)
				{
					MeshFilter component = renderer.GetComponent<MeshFilter>();
					if (component != null && component.sharedMesh != null)
					{
						num2 = component.sharedMesh.subMeshCount;
					}
				}
				if (num2 <= 0)
				{
					continue;
				}
				Material[] sharedMaterials = renderer.sharedMaterials;
				for (int j = 0; j < num2; j++)
				{
					if (j >= sharedMaterials.Length || !CanHighlightMaterial(sharedMaterials[j]))
					{
						continue;
					}
					int num3;
					if (TH20Standard.IsTH20Standard(sharedMaterials[j]))
					{
						num3 = ((TH20Standard.GetBlendMode(sharedMaterials[j]) == TH20Standard.BlendMode.Cutout) ? 1 : 0);
						if (num3 != 0)
						{
							commandBuffer.EnableShaderKeyword("HIGHLIGHT_ALPHA");
							commandBuffer.SetGlobalTexture("_MainTex", sharedMaterials[j].GetTexture("_MainTex"));
							goto IL_0138;
						}
					}
					else
					{
						num3 = 0;
					}
					commandBuffer.DisableShaderKeyword("HIGHLIGHT_ALPHA");
					goto IL_0138;
					IL_0138:
					if (num3 != 0 || !CanBeInstanced(renderer, j, out var mesh2))
					{
						commandBuffer.DrawRenderer(renderer, material, j);
						continue;
					}
					if (mesh != mesh2 || num >= 64)
					{
						DrawQueuedMeshes(commandBuffer, material, num, mesh, array);
						num = 0;
						mesh = null;
					}
					mesh = mesh2;
					array[num] = renderer.transform.localToWorldMatrix;
					num++;
				}
			}
			if (num > 0)
			{
				DrawQueuedMeshes(commandBuffer, material, num, mesh, array);
			}
		}

		private bool CanHighlightMaterial(Material material)
		{
			if (material != null)
			{
				if (TH20Standard.IsTH20Standard(material))
				{
					if (!TH20Standard.IsPlayingBuildingEffect(material))
					{
						return TH20Standard.IsHighlightable(material);
					}
					return false;
				}
				return true;
			}
			return false;
		}
	}
}
