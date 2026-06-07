using ModApi.Scenes;
using UnityEngine;

namespace ModApi.GameLoop
{
	public readonly struct FrameData
	{
		public readonly float DeltaTime;

		public readonly float DeltaTimeUnscaled;

		public readonly int FrameCount;

		public readonly bool InDesignerScene;

		public readonly bool InFlightScene;

		public readonly bool InMenuScene;

		public FrameData(ISceneManager sceneManager)
		{
			FrameCount = Time.frameCount;
			DeltaTime = Time.deltaTime;
			DeltaTimeUnscaled = Time.unscaledDeltaTime;
			InFlightScene = sceneManager.InFlightScene;
			InDesignerScene = sceneManager.InDesignerScene;
			InMenuScene = sceneManager.InMenuScene;
		}
	}
}
