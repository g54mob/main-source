using UnityEngine;
using UnityEngine.UI;

public class NetworkSocketRJ : MonoBehaviour
{
	[Header("Unique Device ID")]
	public string deviceID;

	[Header("Other")]
	public bool cableCorrect;

	public string socketName;

	public NetworkPatchPanel patchPanel;

	public int patchPanelPort;

	public Object RJ45;

	public int portInDevice;

	[Header("UI")]
	public RectTransform CanvasSocket;

	public Image CanvasPort;

	public Transform Patchcord;

	private void OnValidate()
	{
	}

	[ContextMenu("Clear")]
	public void Clear()
	{
	}
}
