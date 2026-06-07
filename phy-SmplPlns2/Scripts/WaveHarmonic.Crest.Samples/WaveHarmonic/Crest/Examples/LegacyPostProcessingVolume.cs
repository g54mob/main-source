using UnityEngine;
using UnityEngine.SceneManagement;

namespace WaveHarmonic.Crest.Examples
{
	[AddComponentMenu("")]
	[ExecuteAlways]
	internal sealed class LegacyPostProcessingVolume : MonoBehaviour
	{
		[SerializeField]
		private int _Layer;

		private static string s_SceneName;

		private void Awake()
		{
			Scene activeScene = SceneManager.GetActiveScene();
			if (RenderPipelineHelper.IsLegacy && !(s_SceneName == activeScene.name))
			{
				s_SceneName = activeScene.name;
			}
		}

		private void OnEnable()
		{
			if (RenderPipelineHelper.IsLegacy)
			{
				Debug.LogWarning("Crest: This scene requires the post-processing package. Without it the scene will be overexposed.");
			}
		}
	}
}
