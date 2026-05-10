using UnityEngine;
using UnityEngine.Events;

namespace TinyGiantStudio.Text
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Tiny Giant Studio/Modular 3D Text/Input System/Local Button Input System", 20051)]
	[HelpURL("https://ferdowsur.gitbook.io/modular-3d-text/input/button-key/button-input-system")]
	public class ButtonInputSystemLocal : MonoBehaviour
	{
		public UnityEvent upAxisEvent;

		public UnityEvent downAxisEvent;

		public UnityEvent leftAxisEvent;

		public UnityEvent rightAxisEvent;

		public UnityEvent submitEvent;

		private ButtonInputSystemGlobal buttonInputSystemGlobal;

		private bool useCommonControls;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void GetCommonControlSettings()
		{
		}

		private void SelectThis()
		{
		}

		private void UpdateButtonInputProcessorScript()
		{
		}

		public void SetupInputProcessor()
		{
		}

		private bool CheckIfContains(UnityEvent myEvent, object target, string targetMethodName)
		{
			return false;
		}

		public void UpAxisEvent()
		{
		}

		public void DownAxisEvent()
		{
		}

		public void LeftAxisEvent()
		{
		}

		public void RightAxisEvent()
		{
		}

		public void SubmitEvent()
		{
		}

		private bool IsThereAppropriateTarget()
		{
			return false;
		}
	}
}
