using UnityEngine;

namespace AeLa.EasyFeedback.Utility
{
	[RequireComponent(typeof(FeedbackForm))]
	public class ShowHideMouse : MonoBehaviour
	{
		private FeedbackForm form;

		private CursorLockMode previousLockState;

		private bool previousVisibility;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void FormOpened()
		{
		}

		private void FormClosed()
		{
		}
	}
}
