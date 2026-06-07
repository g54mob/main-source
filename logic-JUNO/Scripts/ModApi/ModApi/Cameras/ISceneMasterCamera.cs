using UnityEngine;

namespace ModApi.Cameras
{
	public interface ISceneMasterCamera
	{
		Camera Camera { get; }

		RenderTexture RenderTextureCraftMask { get; }

		RenderTexture RenderTextureScene { get; }
	}
}
