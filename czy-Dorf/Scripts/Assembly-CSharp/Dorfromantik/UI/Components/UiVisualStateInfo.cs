using System;
using UnityEngine;

namespace Dorfromantik.UI.Components
{
	[Serializable]
	public class UiVisualStateInfo
	{
		[SerializeField]
		internal bool isAvailable;

		[SerializeField]
		internal bool isCurrentlyActive;

		[SerializeField]
		internal UiState uiState;

		[SerializeField]
		private UiState imitatedUiState;

		[SerializeField]
		internal GameObject groupContainer;

		private UiVisualStateInfo imitatedVisualStateInfo;

		private bool isImitatingOtherVisualStateInfo;

		internal CanvasGroup canvasGroup;

		internal UiVisualStateInfo(UiState uiState)
		{
			this.uiState = uiState;
			if (groupContainer != null)
			{
				canvasGroup = groupContainer.GetComponent<CanvasGroup>();
			}
		}

		internal void Initialize()
		{
			if (groupContainer != null)
			{
				canvasGroup = groupContainer.GetComponent<CanvasGroup>();
			}
		}
	}
}
