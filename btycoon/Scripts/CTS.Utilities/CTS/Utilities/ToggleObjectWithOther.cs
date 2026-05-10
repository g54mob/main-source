using CTS.Core;
using UnityEngine;

namespace CTS.Utilities
{
	public class ToggleObjectWithOther : CTSBehaviour
	{
		[SerializeField]
		private ObjectStateEvent _objectState;

		[SerializeField]
		private GameObject[] _syncObjects;

		[SerializeField]
		private GameObject[] _inverseSyncObjects;

		protected override void OnAwake()
		{
			base.OnAwake();
			_objectState.ActiveStateChanged += OnActiveStateChanged;
			OnActiveStateChanged(_objectState.isActiveAndEnabled);
		}

		private void OnDestroy()
		{
			_objectState.ActiveStateChanged -= OnActiveStateChanged;
		}

		private void OnActiveStateChanged(bool isActive)
		{
			GameObject[] syncObjects = _syncObjects;
			for (int i = 0; i < syncObjects.Length; i++)
			{
				syncObjects[i].SetActive(isActive);
			}
			syncObjects = _inverseSyncObjects;
			for (int i = 0; i < syncObjects.Length; i++)
			{
				syncObjects[i].SetActive(!isActive);
			}
		}
	}
}
