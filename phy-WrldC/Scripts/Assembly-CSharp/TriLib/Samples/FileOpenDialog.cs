using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace TriLib.Samples
{
	public class FileOpenDialog : MonoBehaviour
	{
		public string Filter = "*.*";

		[SerializeField]
		private Transform _containerTransform;

		[SerializeField]
		private FileText _fileTextPrefab;

		[SerializeField]
		private GameObject _fileLoaderRenderer;

		[SerializeField]
		private Button _closeButton;

		[SerializeField]
		private Text _headerText;

		private string _directory;

		public static FileOpenDialog Instance { get; private set; }

		public string Title
		{
			get
			{
				return _headerText.text;
			}
			set
			{
				_headerText.text = value;
			}
		}

		public string Directory
		{
			get
			{
				return _directory;
			}
			set
			{
				_directory = value;
			}
		}

		private event FileOpenEventHandle OnFileOpen;

		public void ShowFileOpenDialog(FileOpenEventHandle onFileOpen)
		{
			this.OnFileOpen = onFileOpen;
			ReloadItemNames();
			_fileLoaderRenderer.SetActive(value: true);
		}

		public void HideFileOpenDialog()
		{
			DestroyItems();
			_fileLoaderRenderer.SetActive(value: false);
		}

		public void HandleEvent(ItemType itemType, string filename)
		{
			switch (itemType)
			{
			case ItemType.ParentDirectory:
			{
				DirectoryInfo parent = System.IO.Directory.GetParent(_directory);
				if (parent != null)
				{
					_directory = parent.FullName;
					ReloadItemNames();
				}
				else
				{
					ShowDirectoryNames();
				}
				break;
			}
			case ItemType.Directory:
				_directory = filename;
				ReloadItemNames();
				break;
			default:
				this.OnFileOpen(Path.Combine(_directory, filename));
				HideFileOpenDialog();
				break;
			}
		}

		public void DestroyItems()
		{
			foreach (Transform item in _containerTransform)
			{
				Object.Destroy(item.gameObject);
			}
		}

		protected void Awake()
		{
			_directory = Path.GetDirectoryName(Application.dataPath);
			_closeButton.onClick.AddListener(HideFileOpenDialog);
			Instance = this;
		}

		private void ReloadItemNames()
		{
			DestroyItems();
			CreateItem(ItemType.ParentDirectory, "[Parent Directory]");
			string[] directories = System.IO.Directory.GetDirectories(_directory);
			foreach (string text in directories)
			{
				CreateItem(ItemType.Directory, text);
			}
			string[] array = System.IO.Directory.GetFiles(_directory, "*.*");
			if (!string.IsNullOrEmpty(Filter) && Filter != "*.*")
			{
				array = array.Where((string x) => Filter.Contains(Path.GetExtension(x).ToLower())).ToArray();
			}
			directories = array;
			foreach (string path in directories)
			{
				CreateItem(ItemType.File, Path.GetFileName(path));
			}
		}

		private void ShowDirectoryNames()
		{
			DestroyItems();
			string[] logicalDrives = System.IO.Directory.GetLogicalDrives();
			foreach (string text in logicalDrives)
			{
				CreateItem(ItemType.Directory, text);
			}
		}

		private void CreateItem(ItemType itemType, string text)
		{
			FileText fileText = Object.Instantiate(_fileTextPrefab, _containerTransform);
			fileText.ItemType = itemType;
			fileText.Text = text;
		}
	}
}
