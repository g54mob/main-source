using System.IO;
using System.Xml.Serialization;
using Lachee.IO;
using UnityEngine;
using UnityEngine.UI;

public class CRUMB_IPC : MonoBehaviour
{
	[XmlRoot]
	public struct IPCData
	{
		[XmlElement]
		public int msgCode;

		[XmlElement]
		public string variables;

		[XmlElement]
		public string stringMsg;
	}

	public static CRUMB_IPC inst;

	public bool desktop;

	private NamedPipeClientStream pipe;

	private NamedPipeClientStream pipeIn;

	private StreamReader reader;

	private StreamWriter writer;

	private XmlSerializer serializer;

	public Canvas mainCanvas;

	public Text messageDebugText;

	private string rawData;

	private IPCData readData;

	public static bool IsDesktop => false;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void TranslateMessage(IPCData data)
	{
	}

	public static void SendData(IPCData data)
	{
	}

	public static void SendData(MessageCode code, string str = "", string var = "")
	{
	}

	private void CreateComponent(IPCData data)
	{
	}

	private void UpdateProperties(IPCData data)
	{
	}
}
