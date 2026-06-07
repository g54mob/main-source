using System.IO;
using System.Linq;
using UnityEngine;

namespace TriLib.Extras
{
	[ExecuteInEditMode]
	public class AvatarLoaderSample : MonoBehaviour
	{
		public GameObject FreeLookCamPrefab;

		public GameObject ThirdPersonControllerPrefab;

		public GameObject ActiveCameraGameObject;

		public string ModelsDirectory = "Models";

		private string[] _files;

		private Rect _windowRect;

		private Vector3 _scrollPosition;

		private AvatarLoader _avatarLoader;

		protected void Start()
		{
			_avatarLoader = Object.FindObjectOfType<AvatarLoader>();
			if (!(_avatarLoader == null))
			{
				string path = Path.Combine(Path.GetFullPath("."), ModelsDirectory);
				string supportedExtensions = AssetLoaderBase.GetSupportedFileExtensions();
				_files = (from x in Directory.GetFiles(path, "*.*")
					where supportedExtensions.Contains("*" + FileUtils.GetFileExtension(x) + ";")
					select x).ToArray();
				_windowRect = new Rect(20f, 20f, 240f, Screen.height - 40);
			}
		}

		protected void OnGUI()
		{
			if (_files != null && !(_avatarLoader == null) && !(FreeLookCamPrefab == null) && !(ThirdPersonControllerPrefab == null))
			{
				_windowRect = GUI.Window(0, _windowRect, HandleWindowFunction, "Available Models");
			}
		}

		private void HandleWindowFunction(int id)
		{
			GUILayout.BeginVertical();
			_scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
			string[] files = _files;
			foreach (string text in files)
			{
				if (GUILayout.Button(Path.GetFileName(text)))
				{
					LoadFile(text);
				}
			}
			GUILayout.EndScrollView();
			GUILayout.EndVertical();
		}

		private void LoadFromMemory(byte[] data, string fileExtension)
		{
			GameObject gameObject = Object.Instantiate(ThirdPersonControllerPrefab);
			gameObject.transform.DestroyChildren(destroyImmediate: true);
			if (_avatarLoader.LoadAvatarFromMemory(data, fileExtension, gameObject))
			{
				if (ActiveCameraGameObject != null)
				{
					Object.Destroy(ActiveCameraGameObject.gameObject);
				}
				ActiveCameraGameObject = Object.Instantiate(FreeLookCamPrefab);
			}
			else
			{
				if (ActiveCameraGameObject != null)
				{
					Object.Destroy(ActiveCameraGameObject.gameObject);
				}
				Object.Destroy(gameObject);
			}
		}

		private void LoadFile(string file)
		{
			GameObject gameObject = Object.Instantiate(ThirdPersonControllerPrefab);
			gameObject.transform.DestroyChildren(destroyImmediate: true);
			if (_avatarLoader.LoadAvatar(file, gameObject))
			{
				if (ActiveCameraGameObject != null)
				{
					Object.Destroy(ActiveCameraGameObject.gameObject);
				}
				ActiveCameraGameObject = Object.Instantiate(FreeLookCamPrefab);
			}
			else
			{
				if (ActiveCameraGameObject != null)
				{
					Object.Destroy(ActiveCameraGameObject.gameObject);
				}
				Object.Destroy(gameObject);
			}
		}
	}
}
