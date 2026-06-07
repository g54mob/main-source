using UnityEngine;

namespace DV.Debugging
{
	public class TextureSettingsDebugGUI : MonoBehaviour
	{
		private const int MB = 1048576;

		private const int WIN_ID = 101;

		private Rect windowRect = new Rect(40f, 100f, 390f, 375f);

		private TextureStreamingVis vis;

		private void Start()
		{
			vis = base.gameObject.AddComponent<TextureStreamingVis>();
		}

		private void OnGUI()
		{
			GUI.skin = DVGUI.skin;
			windowRect = GUI.Window(101, windowRect, Window, "Texture Settings");
		}

		private void Window(int id)
		{
			QualitySettings.streamingMipmapsActive = GUILayout.Toggle(QualitySettings.streamingMipmapsActive, "Texture Streaming Enabled");
			Texture.allowThreadedTextureCreation = GUILayout.Toggle(Texture.allowThreadedTextureCreation, "Allow Threaded Texture Creation");
			Texture.streamingTextureDiscardUnusedMips = GUILayout.Toggle(Texture.streamingTextureDiscardUnusedMips, "Streaming Texture Discard Unused Mips");
			Texture.streamingTextureForceLoadAll = GUILayout.Toggle(Texture.streamingTextureForceLoadAll, "Streaming Texture Force Load All");
			vis.activateDebugShader = GUILayout.Toggle(vis.activateDebugShader, "Visualize Texture Streaming");
			using (new GUILayout.HorizontalScope())
			{
				GUILayout.Label($"Budget = {QualitySettings.streamingMipmapsMemoryBudget} MB", GUILayout.Width(115f));
				QualitySettings.streamingMipmapsMemoryBudget = Mathf.Round(GUILayout.HorizontalSlider(QualitySettings.streamingMipmapsMemoryBudget, 200f, 4000f, GUILayout.Width(250f)));
			}
			GUILayout.Label($"Current Texture Memory = {Texture.currentTextureMemory / 1048576} MB");
			GUILayout.Label($"Desired Texture Memory = {Texture.desiredTextureMemory / 1048576} MB");
			GUILayout.Label($"Non Streaming Texture Count = {Texture.nonStreamingTextureCount}");
			GUILayout.Label($"Non Streaming Texture Memory = {Texture.nonStreamingTextureMemory / 1048576} MB");
			GUILayout.Label($"Streaming Mipmap Upload Count = {Texture.streamingMipmapUploadCount}");
			GUILayout.Label($"Streaming Renderer Count = {Texture.streamingRendererCount}");
			GUILayout.Label($"Streaming Texture Count = {Texture.streamingTextureCount}");
			GUILayout.Label($"Streaming Texture Loading Count = {Texture.streamingTextureLoadingCount}");
			GUILayout.Label($"Streaming Texture Pending Load Count = {Texture.streamingTexturePendingLoadCount}");
			GUILayout.Label($"Target Texture Memory = {Texture.targetTextureMemory / 1048576} MB");
			GUILayout.Label($"Total Texture Memory = {Texture.totalTextureMemory / 1048576} MB");
			GUI.DragWindow();
		}
	}
}
