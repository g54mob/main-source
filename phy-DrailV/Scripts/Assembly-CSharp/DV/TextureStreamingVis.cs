using UnityEngine;

namespace DV
{
	public class TextureStreamingVis : MonoBehaviour
	{
		public bool activateDebugShader;

		private bool debugShaderActive;

		private RenderingPath originalRenderingPath;

		private Shader shader;

		private Camera cam;

		private void Start()
		{
			shader = Shader.Find("Hidden/DV/Texture Streaming Visualization");
			if (!shader)
			{
				Debug.LogError("[TextureStreamingVis] Could not find shader", this);
			}
		}

		private void Cleanup()
		{
			if (!cam)
			{
				Debug.LogWarning("Camera already cleaned up (it's null)");
				return;
			}
			cam.renderingPath = originalRenderingPath;
			cam.ResetReplacementShader();
			cam = null;
		}

		private void Setup()
		{
			if ((bool)cam)
			{
				Debug.LogWarning("Camera already set up");
			}
			cam = Camera.main;
			originalRenderingPath = cam.renderingPath;
			cam.renderingPath = RenderingPath.Forward;
			cam.SetReplacementShader(shader, "RenderType");
		}

		private void Update()
		{
			if (!shader)
			{
				return;
			}
			if ((bool)Camera.main && (bool)cam && cam != Camera.main)
			{
				Debug.Log("[TextureStreamingVis] Camera.main changed from " + cam.name + " to " + Camera.main.name);
				Cleanup();
				Setup();
			}
			if (activateDebugShader != debugShaderActive)
			{
				if (activateDebugShader)
				{
					Setup();
				}
				else
				{
					Cleanup();
				}
				debugShaderActive = activateDebugShader;
			}
			if (debugShaderActive)
			{
				Texture.SetStreamingTextureMaterialDebugProperties();
			}
		}
	}
}
