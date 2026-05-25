using TMPro;
using UnityEngine;

namespace Multiplayer
{
	public class NetStats : MonoBehaviour
	{
		public NetGraph sendGraph;

		public NetGraph recvGraph;

		public NetGraph latencyGraph;

		public TextMeshProUGUI recvLabel;

		public TextMeshProUGUI sendLabel;

		public TextMeshProUGUI latencyLabel;

		private float recvSum;

		private float sendSum;

		private int frames;

		private int baseFrameId;

		private void Start()
		{
			Shell.RegisterCommand("netstats", OnNetStats, "netstats\r\nToggle netwok statistics display");
			base.transform.parent.gameObject.SetActive(false);
		}

		private void OnNetStats()
		{
			base.transform.parent.gameObject.SetActive(!base.transform.parent.gameObject.activeSelf);
			if (base.transform.parent.gameObject.activeSelf)
			{
				Shell.Print("netstats on");
			}
			else
			{
				Shell.Print("netstats off");
			}
		}

		private void Update()
		{
			frames++;
			sendSum = NetGame.instance.sendBps.kbps;
			recvSum = NetGame.instance.recvBps.kbps;
			if (frames == 4)
			{
				recvGraph.PushValue(recvSum);
				sendGraph.PushValue(sendSum);
				float max = sendGraph.GetMax();
				float max2 = recvGraph.GetMax();
				float range = Mathf.Max(max, max2);
				recvGraph.SetRange(range);
				sendGraph.SetRange(range);
				recvLabel.text = string.Format("recv \t{0:0.0}kbps \t{1:0.0}kbps", recvSum, max2);
				sendLabel.text = string.Format("send \t{0:0.0}kbps \t{1:0.0}kbps", sendSum, max);
				latencyLabel.text = string.Format("buf \t {0:0.0}frames \tlag \t{1:0.0}ms", NetGame.instance.clientBuffer.latency, NetGame.instance.clientLatency.latency * 1000f / 60f);
				frames = 0;
				sendSum = (recvSum = 0f);
			}
		}

		private void OnGUI()
		{
			if (Shell.visible)
			{
				GUILayout.BeginArea(new Rect(10f, Screen.height / 2, Screen.width - 20, Screen.height / 2));
			}
			GUILayout.BeginVertical();
			GUI.color = Color.black;
			GUIStyle label = GUI.skin.label;
			GUILayout.Label(string.Format("Send: {0:00.0} kbps / Recv: {1:00.0} kbps", NetGame.instance.sendBps.kbps, NetGame.instance.recvBps.kbps), label);
			for (int i = 0; i < NetScope.all.Count; i++)
			{
				NetScope.all[i].RenderGUI(label);
			}
			GUILayout.EndVertical();
			if (Shell.visible)
			{
				GUILayout.EndArea();
			}
		}
	}
}
