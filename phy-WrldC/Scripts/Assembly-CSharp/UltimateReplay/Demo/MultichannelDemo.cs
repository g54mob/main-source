using UltimateReplay.Storage;
using UnityEngine;

namespace UltimateReplay.Demo
{
	public class MultichannelDemo : MonoBehaviour
	{
		private ReplayMultichannelMemoryTarget target;

		public GameObject prefab;

		public void Start()
		{
			target = ReplayManager.Target as ReplayMultichannelMemoryTarget;
		}

		public void OnGUI()
		{
			GUILayout.BeginArea(new Rect(10f, 280f, 180f, 100f), GUI.skin.box);
			GUILayout.Label("Demo");
			if (GUILayout.Button("Spawn"))
			{
				Object.Instantiate(prefab, base.transform.position, Quaternion.identity);
			}
			GUI.enabled = !ReplayManager.IsRecording;
			GUILayout.BeginHorizontal();
			GUILayout.Label($"Active Channel ({target.ActiveChannel}):");
			int num = (int)GUILayout.HorizontalSlider(target.ActiveChannel, 0f, target.ChannelCount - 1);
			if (num != target.ActiveChannel)
			{
				target.SetActiveChannel(num);
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Add Channel"))
			{
				target.AddChannel();
			}
			if (GUILayout.Button("Remove Channel"))
			{
				target.RemoveChannel();
			}
			GUILayout.EndHorizontal();
			GUI.enabled = true;
			GUILayout.EndArea();
		}
	}
}
