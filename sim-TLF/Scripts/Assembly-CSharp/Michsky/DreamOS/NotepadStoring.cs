using System.IO;
using UnityEngine;

namespace Michsky.DreamOS
{
	[AddComponentMenu("DreamOS/Apps/Notepad/Notepad Storing")]
	public class NotepadStoring : MonoBehaviour
	{
		[Header("Resources")]
		public NotepadManager notepadManager;

		[Header("Settings")]
		public string subPath = "DreamOS_Data";

		public string fileName = "StoredNotes";

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
				File.WriteAllText(fullPath, "NOTE_DATA");
			}
		}

		public void UpdateData()
		{
			if (notepadManager == null)
			{
				Debug.LogError("<b>[Notepad Storing]</b> 'Notepad Manager' is missing.", this);
				return;
			}
			File.WriteAllText(fullPath, "NOTE_DATA");
			for (int i = 0; i < notepadManager.noteItems.Count; i++)
			{
				if (notepadManager.noteItems[i].isCustom)
				{
					WriteNoteData(i);
				}
			}
		}

		public void WriteNoteData(int tempIndex)
		{
			File.AppendAllText(fullPath, "\n\nNoteID: " + notepadManager.noteItems[tempIndex].noteID + "\n{\n[Title] " + notepadManager.noteItems[tempIndex].noteTitle + "\n[Content] " + notepadManager.noteItems[tempIndex].noteContent + "\n}");
		}

		public void ReadNoteData()
		{
			if (notepadManager == null)
			{
				Debug.LogError("<b>[Notepad Storing]</b> 'Notepad Manager' is missing.", this);
				return;
			}
			CheckForDataFile();
			string noteID = null;
			string title = null;
			string text = null;
			bool flag = false;
			foreach (string item in File.ReadLines(fullPath))
			{
				if (item.Contains("NoteID: "))
				{
					noteID = item.Replace("NoteID: ", "");
				}
				else if (item.Contains("[Title] "))
				{
					title = item.Replace("[Title] ", "");
				}
				else if (item.Contains("[Content] "))
				{
					text = item.Replace("[Content] ", "");
					flag = true;
				}
				else if (item == "}")
				{
					notepadManager.CreateNote(noteID, title, text);
					flag = false;
				}
				else if (flag)
				{
					text = text + "\n" + item;
				}
			}
		}
	}
}
