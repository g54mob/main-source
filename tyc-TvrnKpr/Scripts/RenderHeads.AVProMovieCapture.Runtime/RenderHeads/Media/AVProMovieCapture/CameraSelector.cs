using UnityEngine;
using UnityEngine.SceneManagement;

namespace RenderHeads.Media.AVProMovieCapture
{
	[AddComponentMenu("AVPro Movie Capture/Utils/Camera Selector", 300)]
	public class CameraSelector : MonoBehaviour
	{
		public enum SelectByMode
		{
			HighestDepthCamera = 0,
			MainCameraTag = 1,
			EditorSceneView = 2,
			Tag = 3,
			Name = 4,
			Manual = 5
		}

		public enum ScanFrequencyMode
		{
			Manual = 0,
			SceneLoad = 1,
			Frame = 2
		}

		[SerializeField]
		private SelectByMode _selectBy;

		[SerializeField]
		private ScanFrequencyMode _scanFrequency;

		[SerializeField]
		private bool _scanHiddenCameras;

		[SerializeField]
		private string _tag;

		[SerializeField]
		private string _name;

		[SerializeField]
		private Camera _camera;

		private Camera[] _cameraCache;

		private int _cameraCount;

		private int _cameraCacheFrame;

		private bool _selectionDirty;

		public Camera Camera
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SelectByMode SelectBy
		{
			get
			{
				return default(SelectByMode);
			}
			set
			{
			}
		}

		public ScanFrequencyMode ScanFrequency
		{
			get
			{
				return default(ScanFrequencyMode);
			}
			set
			{
			}
		}

		public bool ScanHiddenCameras
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string SelectTag
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string SelectName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnValidate()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		private void ResetSceneLoading()
		{
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		public bool ScanForCameraChange()
		{
			return false;
		}

		private Camera FindCamera()
		{
			return null;
		}

		public void UpdateCameraCache(bool forceScanHiddenCameras = false)
		{
		}

		private static Camera FindCameraByHighestDepth(int cameraCount, Camera[] cameras)
		{
			return null;
		}

		private static Camera FindCameraByTag(int cameraCount, Camera[] cameras, string tag)
		{
			return null;
		}

		private static Camera FindCameraByName(int cameraCount, Camera[] cameras, string name)
		{
			return null;
		}
	}
}
