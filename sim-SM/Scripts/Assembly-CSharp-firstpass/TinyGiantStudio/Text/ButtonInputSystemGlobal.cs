using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace TinyGiantStudio.Text
{
	[AddComponentMenu("Tiny Giant Studio/Modular 3D Text/Input System/Global Button Input System", 20050)]
	[HelpURL("https://ferdowsur.gitbook.io/modular-3d-text/input/button-key/button-input-system")]
	public class ButtonInputSystemGlobal : MonoBehaviour
	{
		public enum ButtonInputProcessorStyle
		{
			IndividualPlayerInputComponents = 0,
			CommonInputController = 1,
			Custom = 2
		}

		public static ButtonInputSystemGlobal Instance;

		[SerializeField]
		private ButtonInputProcessorStyle _buttonInputProcessorStyle;

		public InputActionAsset inputActionAsset;

		public ButtonInputSystemLocal selectedInputSystem;

		public bool debugLogs;

		public ButtonInputProcessorStyle MyButtonInputProcessorStyle
		{
			get
			{
				return default(ButtonInputProcessorStyle);
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		public void Select(ButtonInputSystemLocal buttonInputSystem)
		{
		}

		public void DeSelect(ButtonInputSystemLocal buttonInputSystem)
		{
		}

		public void UpdateButtonInputProcessorScript(bool alsoDoSetup = true)
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

		private void ImportantLog(string msg)
		{
		}
	}
}
