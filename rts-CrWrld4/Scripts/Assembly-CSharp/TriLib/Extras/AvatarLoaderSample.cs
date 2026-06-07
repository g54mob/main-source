using UnityEngine;

namespace TriLib.Extras
{
	[ExecuteInEditMode]
	public class AvatarLoaderSample : MonoBehaviour
	{
		public GameObject FreeLookCamPrefab;

		public GameObject ThirdPersonControllerPrefab;

		public GameObject ActiveCameraGameObject;

		public string ModelsDirectory;

		private string[] _files;

		private Rect _windowRect;

		private Vector3 _scrollPosition;

		private AvatarLoader _avatarLoader;

		protected void Start()
		{
		}

		protected void OnGUI()
		{
		}

		private void HandleWindowFunction(int id)
		{
		}

		private void LoadFromMemory(byte[] data, string fileExtension)
		{
		}

		private void LoadFile(string file)
		{
		}
	}
}
