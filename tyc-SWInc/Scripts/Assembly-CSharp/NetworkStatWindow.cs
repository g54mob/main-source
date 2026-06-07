using System.Collections.Generic;
using System.Linq;
using System.Text;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class NetworkStatWindow : MonoBehaviour
{
	public Text StatLabel;

	public GUIBarChart Chart;

	public GUIWindow Window;

	private StringBuilder _sb;

	private NetworkPlayer _player;

	private void Awake()
	{
		_sb = new StringBuilder();
		Chart.Values = new List<List<float>>
		{
			Utilities.RepeatValue(0f, 136).ToList(),
			Utilities.RepeatValue(0f, 136).ToList()
		};
		Chart.ToolTipFunc = (int i, float f, float arg3) => string.Concat((NetworkMessaging.MessageType)i, ": ", ((uint)arg3).ByteSize());
	}

	public void Init(NetworkPlayer player)
	{
		_player = player;
		Window.NonLocTitle = "Network stats for " + player.Name;
	}

	private void FixedUpdate()
	{
		_sb.Clear();
		_sb.AppendLine(_player.Host ? "Host" : "Client");
		_sb.AppendLine(NetworkLayer.Active.Diagnostics(_player));
		_sb.AppendLine("Sent: " + _player.Sent.ByteSize());
		_sb.AppendLine("Received: " + _player.Received.ByteSize());
		_sb.AppendLine("Overhead: " + _player.Overhead.ByteSize());
		_sb.AppendLine("Queued: " + _player.CurrentQueued.ByteSize());
		_sb.AppendLine("Max queued: " + _player.MaxQueued.ByteSize());
		for (int i = 0; i < 136; i++)
		{
			Chart.Values[0][i] = _player.SentPerType[i];
			Chart.Values[1][i] = _player.ReceivedPerType[i];
		}
		Chart.SetVerticesDirty();
		StatLabel.text = _sb.ToString().TrimEnd();
	}
}
