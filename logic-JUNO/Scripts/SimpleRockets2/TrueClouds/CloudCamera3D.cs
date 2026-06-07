using Assets.Scripts.Cameras;
using ModApi.Cameras;
using UnityEngine;

namespace TrueClouds
{
	public class CloudCamera3D : CloudCamera
	{
		private ISceneCamera _sceneCam;

		protected override void Awake()
		{
			base.Awake();
			_sceneCam = GetComponent<SceneCameraScript>();
		}

		[ImageEffectOpaque]
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (_sceneCam.MasterCamera.RenderTextureCraftMask != null)
			{
				RenderTexture renderTextureScene = _sceneCam.MasterCamera.RenderTextureScene;
				RenderClouds(renderTextureScene, destination);
				Graphics.Blit(destination, renderTextureScene);
			}
			else
			{
				RenderClouds(source, destination);
			}
		}
	}
}
