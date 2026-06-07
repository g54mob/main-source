using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Tools
{
	public class MMSaveLoadTester : MonoBehaviour
	{
		[Header("Bindings")]
		[Tooltip("the text to save")]
		public InputField TargetInputField;

		[Header("Save settings")]
		[Tooltip("the chosen save method (json, encrypted json, binary, encrypted binary)")]
		public MMSaveLoadManagerMethods SaveLoadMethod = MMSaveLoadManagerMethods.Binary;

		[Tooltip("the name of the file to save")]
		public string FileName = "TestObject";

		[Tooltip("the name of the destination folder")]
		public string FolderName = "MMTest/";

		[Tooltip("the extension to use")]
		public string SaveFileExtension = ".testObject";

		[Tooltip("the key to use to encrypt the file (if needed)")]
		public string EncryptionKey = "ThisIsTheKey";

		[MMInspectorButton("Save")]
		public bool TestSaveButton;

		[MMInspectorButton("Load")]
		public bool TestLoadButton;

		[MMInspectorButton("Reset")]
		public bool TestResetButton;

		protected IMMSaveLoadManagerMethod _saveLoadManagerMethod;

		public virtual void Save()
		{
			InitializeSaveLoadMethod();
			MMSaveLoadManager.Save(new MMSaveLoadTestObject
			{
				SavedText = TargetInputField.text
			}, FileName + SaveFileExtension, FolderName);
		}

		public virtual void Load()
		{
			InitializeSaveLoadMethod();
			MMSaveLoadTestObject mMSaveLoadTestObject = (MMSaveLoadTestObject)MMSaveLoadManager.Load(typeof(MMSaveLoadTestObject), FileName + SaveFileExtension, FolderName);
			TargetInputField.text = mMSaveLoadTestObject.SavedText;
		}

		protected virtual void Reset()
		{
			MMSaveLoadManager.DeleteSaveFolder(FolderName);
		}

		protected virtual void InitializeSaveLoadMethod()
		{
			switch (SaveLoadMethod)
			{
			case MMSaveLoadManagerMethods.Binary:
				_saveLoadManagerMethod = new MMSaveLoadManagerMethodBinary();
				break;
			case MMSaveLoadManagerMethods.BinaryEncrypted:
				_saveLoadManagerMethod = new MMSaveLoadManagerMethodBinaryEncrypted();
				(_saveLoadManagerMethod as MMSaveLoadManagerEncrypter).Key = EncryptionKey;
				break;
			case MMSaveLoadManagerMethods.Json:
				_saveLoadManagerMethod = new MMSaveLoadManagerMethodJson();
				break;
			case MMSaveLoadManagerMethods.JsonEncrypted:
				_saveLoadManagerMethod = new MMSaveLoadManagerMethodJsonEncrypted();
				(_saveLoadManagerMethod as MMSaveLoadManagerEncrypter).Key = EncryptionKey;
				break;
			}
			MMSaveLoadManager.SaveLoadMethod = _saveLoadManagerMethod;
		}
	}
}
