using System;
using UnityEngine;

namespace Restory.Gameplay.GameCursor
{
	public sealed class CursorSelectionService
	{
		private const string UI_DROPDOWN_BLOCKER_OBJECT_NAME = "Blocker";

		private GameObject detectedGameObject;

		private GameObject blockerGameObject;

		public bool HasDetection => detectedGameObject;

		public GameObject DetectedGameObject => detectedGameObject;

		public event Action OnDetectionStateChanged;

		public void SetDetection(GameObject detectedGameObject, bool uiObjectDetected = false)
		{
			if (!(this.detectedGameObject == detectedGameObject) && !blockerGameObject)
			{
				if (uiObjectDetected && detectedGameObject.name == "Blocker")
				{
					blockerGameObject = detectedGameObject;
					return;
				}
				this.detectedGameObject = detectedGameObject;
				this.OnDetectionStateChanged?.Invoke();
			}
		}

		public void ClearDetection()
		{
			if (!(detectedGameObject == null) && !blockerGameObject)
			{
				detectedGameObject = null;
				this.OnDetectionStateChanged?.Invoke();
			}
		}
	}
}
