using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Scenes.Startup;
using Assets.Scripts.Storage;
using UnityEngine;

namespace Assets.Scripts.Net
{
	public static class SingleInstanceTcpServer
	{
		private static TcpListener _tcpListener;

		public static string PortFilePath => GameData.GetPath("port.txt");

		public static void ConnectOrStart()
		{
			if (Connect())
			{
				Application.Quit();
			}
			else
			{
				StartServer();
			}
		}

		private static bool Connect()
		{
			if (File.Exists(PortFilePath))
			{
				try
				{
					ushort num = ushort.Parse(File.ReadAllText(PortFilePath));
					Debug.Log($"Attempting to connect to another instance of the game on port {num}");
					using (TcpClient tcpClient = new TcpClient())
					{
						tcpClient.Connect(IPAddress.Loopback, num);
						byte[] clientMessage = GetClientMessage();
						tcpClient.GetStream().Write(clientMessage, 0, clientMessage.Length);
						tcpClient.Close();
					}
					Debug.Log("Successfully connected to the other game instance. Now shutting down.");
					return true;
				}
				catch (Exception exception)
				{
					Debug.LogError("Failed to connect to existing instance of game.");
					Debug.LogException(exception);
					DeletePortFile();
				}
			}
			return false;
		}

		private static void DeletePortFile()
		{
			string portFilePath = PortFilePath;
			try
			{
				if (File.Exists(portFilePath))
				{
					File.Delete(portFilePath);
				}
			}
			catch (Exception exception)
			{
				Debug.LogError("Failed to delete port file: " + portFilePath);
				Debug.LogException(exception);
			}
		}

		private static byte[] GetClientMessage()
		{
			string s = string.Empty;
			string[] array = System.Environment.GetCommandLineArgs() ?? new string[0];
			for (int i = 1; i < array.Length; i++)
			{
				if (array[i].EndsWith(".splane", StringComparison.InvariantCultureIgnoreCase) || array[i].EndsWith(".sp2-mod", StringComparison.InvariantCultureIgnoreCase))
				{
					s = array[i];
					break;
				}
			}
			byte[] bytes = Encoding.Unicode.GetBytes(s);
			byte[] bytes2 = BitConverter.GetBytes((ushort)bytes.Length);
			byte[] array2 = new byte[bytes2.Length + bytes.Length];
			Buffer.BlockCopy(bytes2, 0, array2, 0, bytes2.Length);
			Buffer.BlockCopy(bytes, 0, array2, bytes2.Length, bytes.Length);
			return array2;
		}

		private static void OnApplicationQuit()
		{
			if (_tcpListener != null)
			{
				try
				{
					_tcpListener.Stop();
				}
				catch (Exception exception)
				{
					Debug.LogError("Unable to stop TCP server");
					Debug.LogException(exception);
				}
			}
			DeletePortFile();
		}

		private static void StartServer()
		{
			try
			{
				Application.quitting += OnApplicationQuit;
				_tcpListener = new TcpListener(IPAddress.Loopback, 0);
				_tcpListener.Start();
				int port = ((IPEndPoint)_tcpListener.LocalEndpoint).Port;
				WritePortToFile(port);
				Debug.Log($"TCP Server started on port {port}");
				Task.Run(delegate
				{
					byte[] array = new byte[2];
					while (true)
					{
						TcpClient tcpClient = _tcpListener.AcceptTcpClient();
						if (tcpClient == null || !tcpClient.Connected)
						{
							break;
						}
						Debug.Log("Connection received from another instance of the game");
						NetworkStream stream = tcpClient.GetStream();
						stream.Read(array, 0, array.Length);
						ushort num = BitConverter.ToUInt16(array, 0);
						byte[] array2 = new byte[num];
						if (num > 0)
						{
							stream.Read(array2, 0, num);
						}
						string text = Encoding.Unicode.GetString(array2) ?? string.Empty;
						Debug.Log("Message recieved from other game instance: " + text);
						UrlHandlerScript.Instance.HandleUrl(text);
					}
					Debug.Log("The TCP server accepted no client connection and stopped running");
				});
			}
			catch (Exception exception)
			{
				Debug.Log("Unable to start TCP server to prevent mulitple instances of the game from running");
				Debug.LogException(exception);
			}
		}

		private static void WritePortToFile(int port)
		{
			string portFilePath = PortFilePath;
			try
			{
				File.WriteAllText(portFilePath, port.ToString());
			}
			catch (Exception exception)
			{
				Debug.LogError("Unable to write port file: " + portFilePath);
				Debug.LogException(exception);
			}
		}
	}
}
