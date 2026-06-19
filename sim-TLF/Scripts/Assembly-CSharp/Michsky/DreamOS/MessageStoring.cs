using System.IO;
using UnityEngine;

namespace Michsky.DreamOS
{
	[AddComponentMenu("DreamOS/Apps/Messaging/Message Storing")]
	public class MessageStoring : MonoBehaviour
	{
		[Header("Resources")]
		public MessagingManager messagingManager;

		[Header("Settings")]
		public string subPath = "DreamOS_Data";

		public string fileName = "StoredMessages";

		public string fileExtension = ".data";

		private string fullPath;

		public void CheckForDataFile()
		{
			string dataPath = Application.dataPath;
			dataPath = dataPath.Replace(Application.productName + "_Data", "");
			fullPath = dataPath + subPath + "//" + fileName + fileExtension;
			if (!File.Exists(fullPath))
			{
				new FileInfo(fullPath).Directory.Create();
				File.WriteAllText(fullPath, "MSG_DATA");
			}
		}

		public void ReadMessageData()
		{
			if (messagingManager == null)
			{
				Debug.LogError("<b>[Message Storing]</b> 'Messaging Manager' is missing.", this);
				return;
			}
			CheckForDataFile();
			string msgID = null;
			string text = null;
			string text2 = null;
			string text3 = null;
			string time = null;
			bool flag = false;
			foreach (string item in File.ReadLines(fullPath))
			{
				if (item.Contains("MessageID: "))
				{
					msgID = item.Replace("MessageID: ", "");
				}
				else if (item.Contains("[Type]"))
				{
					text = item.Replace("[Type] ", "");
				}
				else if (item.Contains("[Author]"))
				{
					text2 = item.Replace("[Author] ", "");
				}
				else if (item.Contains("[Message]"))
				{
					text3 = item.Replace("[Message] ", "");
					flag = true;
				}
				else if (item.Contains("[Time]"))
				{
					time = item.Replace("[Time] ", "");
				}
				else if (item == "}")
				{
					flag = false;
					if (text2 == "self" && text == "standard")
					{
						messagingManager.CreateStoredMessage(msgID, text3, time, isSelf: true);
					}
					else if (text2 == "individual" && text == "standard")
					{
						messagingManager.CreateStoredMessage(msgID, text3, time, isSelf: false);
					}
				}
				else if (flag)
				{
					text3 = text3 + "\n" + item;
				}
			}
		}

		public void ApplyMessageData(string msgID, string msgType, string author, string message, string msgTime)
		{
			File.AppendAllText(fullPath, "\n\nMessageID: " + msgID + "\n{\n[Type] " + msgType + "\n[Author] " + author + "\n[Message] " + message + "\n[Time] " + msgTime + "\n}");
		}

		public void ResetData()
		{
			File.WriteAllText(fullPath, "MSG_DATA");
		}
	}
}
