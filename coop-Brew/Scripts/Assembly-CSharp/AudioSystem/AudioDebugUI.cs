using UnityEngine;

namespace AudioSystem
{
	public class AudioDebugUI : MonoBehaviour
	{
		[Header("Settings")]
		[Tooltip("Key to toggle the debug UI.")]
		[SerializeField]
		private KeyCode toggleKey;

		[Tooltip("Only show in development builds.")]
		[SerializeField]
		private bool devBuildsOnly;

		private bool _isVisible;

		private Vector2 _scrollPosition;

		private Vector2 _musicScrollPosition;

		private Rect _mainWindowRect;

		private Rect _volumeWindowRect;

		private string _testEventId;

		private GUIStyle _boldStyle;

		private GUIStyle _errorStyle;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnGUI()
		{
		}

		private void DrawMainWindow(int windowId)
		{
		}

		private void DrawVolumeWindow(int windowId)
		{
		}

		private GUIStyle GetBoldStyle()
		{
			return null;
		}

		private GUIStyle GetErrorStyle()
		{
			return null;
		}
	}
}
