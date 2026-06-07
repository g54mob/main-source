using UnityEngine;

namespace UltimateReplay.Demo
{
	public class AudioDemo : MonoBehaviour
	{
		public ReplayAudio replayAudio;

		public void Update()
		{
			if (!(replayAudio == null) && Input.GetKeyDown(KeyCode.Space))
			{
				replayAudio.Play();
			}
		}

		public void OnGUI()
		{
			GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.Label("Replay Audio Demo - ");
			GUILayout.Label("Press 'Space' to play audio effect");
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}
	}
}
