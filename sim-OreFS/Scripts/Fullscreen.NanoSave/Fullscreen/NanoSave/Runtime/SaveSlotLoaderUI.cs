using System.IO;
using System.Linq;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace Fullscreen.NanoSave.Runtime
{
	[AddComponentMenu("Fullscreen/Save Slots Loader UI")]
	public class SaveSlotLoaderUI : MonoBehaviour
	{
		private enum SortMode
		{
			NewestFirst = 0,
			ByNumber = 1
		}

		[SerializeField]
		private PropertyGetGameObject SaveSlotTemplate;

		[SerializeField]
		private PropertyGetGameObject EmptySaveSlot;

		[SerializeField]
		private PropertyGetGameObject Content;

		[SerializeField]
		private SortMode sortMode;

		private SaveSlotComponent currentHoverSaveSlot;

		public SaveSlotComponent CurrentHoverSaveSlot
		{
			get
			{
				return currentHoverSaveSlot;
			}
			set
			{
				if (currentHoverSaveSlot != value)
				{
					currentHoverSaveSlot = value;
				}
			}
		}

		private void OnEnable()
		{
			LoadSaveSlots();
		}

		public void LoadSaveSlots()
		{
			Transform transform = SaveSlotTemplate.Get<Transform>(base.gameObject);
			Transform transform2 = Content.Get<Transform>(base.gameObject);
			Transform transform3 = ((EmptySaveSlot != null) ? EmptySaveSlot.Get<Transform>(base.gameObject) : null);
			if (transform == null || transform2 == null)
			{
				return;
			}
			GameObject original = transform.gameObject;
			foreach (Transform item in transform2)
			{
				Object.Destroy(item.gameObject);
			}
			if (transform3 != null)
			{
				Object.Instantiate(transform3.gameObject, transform2);
			}
			string path = Path.Combine(Application.persistentDataPath, "Saves");
			if (!Directory.Exists(path))
			{
				return;
			}
			string[] array = (from dir in Directory.GetDirectories(path)
				where IsValidSaveFolder(dir)
				select dir).ToArray();
			if (sortMode == SortMode.NewestFirst)
			{
				array = array.OrderByDescending((string folder) => File.GetLastWriteTime(Path.Combine(folder, "SAVE.GZ"))).ToArray();
			}
			else if (sortMode == SortMode.ByNumber)
			{
				array = array.OrderBy((string folder) => ExtractMiddleNumber(Path.GetFileName(folder))).ToArray();
			}
			string[] array2 = array;
			foreach (string text in array2)
			{
				string fileName = Path.GetFileName(text);
				string text2 = ExtractMiddleNumber(fileName);
				if (!string.IsNullOrEmpty(text2) && text2 != "0000")
				{
					SaveSlotComponent component = Object.Instantiate(original, transform2).GetComponent<SaveSlotComponent>();
					if (component != null)
					{
						component.Initialize(this);
						component.SetSlotNumber(text2);
					}
					else
					{
						Debug.LogWarning("SaveTemplate prefab at " + text + " is missing SaveSlotComponent!");
					}
				}
			}
		}

		public void RefreshUI()
		{
			SaveSlotComponent[] array = Object.FindObjectsByType<SaveSlotComponent>(FindObjectsSortMode.None);
			foreach (SaveSlotComponent saveSlotComponent in array)
			{
				string text = Path.Combine(Application.persistentDataPath, "Saves", "Save_" + saveSlotComponent.slotNumber);
				if (!Directory.Exists(text) || !File.Exists(Path.Combine(text, "SAVE.GZ")))
				{
					Object.Destroy(saveSlotComponent.gameObject);
				}
			}
			LoadSaveSlots();
		}

		private bool IsValidSaveFolder(string folderPath)
		{
			string[] array = Path.GetFileName(folderPath).Split('_');
			if (array.Length != 2)
			{
				return false;
			}
			string text = array[1];
			if (IsNumeric(text) && text != "0000")
			{
				return File.Exists(Path.Combine(folderPath, "SAVE.GZ"));
			}
			return false;
		}

		private string ExtractMiddleNumber(string folderName)
		{
			string[] array = folderName.Split('_');
			if (array.Length != 2 || !IsNumeric(array[1]))
			{
				return string.Empty;
			}
			return array[1];
		}

		private bool IsNumeric(string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				return value.All(char.IsDigit);
			}
			return false;
		}
	}
}
