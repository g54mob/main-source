using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GPUInstancerPro
{
	public class GPUIObjectSwitcher : GPUIInputHandler
	{
		public List<GameObject> gameObjects;

		public Text activeGONameText;

		private GameObject _currentActiveGO;

		private void OnEnable()
		{
			if (gameObjects == null)
			{
				gameObjects = new List<GameObject>();
			}
			if (gameObjects.Count > 0)
			{
				_currentActiveGO = gameObjects[0];
				if (_currentActiveGO != null)
				{
					_currentActiveGO.SetActive(value: true);
					if (activeGONameText != null)
					{
						activeGONameText.text = _currentActiveGO.name;
					}
				}
			}
			for (int i = 1; i < gameObjects.Count; i++)
			{
				GameObject gameObject = gameObjects[i];
				if (!(gameObject == null))
				{
					gameObject.SetActive(value: false);
				}
			}
		}

		private void Update()
		{
			int count = gameObjects.Count;
			int num = -1;
			if (count > 0 && GetKeyDown(KeyCode.Alpha1))
			{
				num = 0;
			}
			else if (count > 1 && GetKeyDown(KeyCode.Alpha2))
			{
				num = 1;
			}
			else if (count > 2 && GetKeyDown(KeyCode.Alpha3))
			{
				num = 2;
			}
			else if (count > 3 && GetKeyDown(KeyCode.Alpha4))
			{
				num = 3;
			}
			else if (count > 4 && GetKeyDown(KeyCode.Alpha5))
			{
				num = 4;
			}
			else if (count > 5 && GetKeyDown(KeyCode.Alpha6))
			{
				num = 5;
			}
			else if (count > 6 && GetKeyDown(KeyCode.Alpha7))
			{
				num = 6;
			}
			else if (count > 7 && GetKeyDown(KeyCode.Alpha8))
			{
				num = 7;
			}
			else if (count > 8 && GetKeyDown(KeyCode.Alpha9))
			{
				num = 8;
			}
			if (num < 0)
			{
				return;
			}
			if (_currentActiveGO != null)
			{
				_currentActiveGO.SetActive(value: false);
			}
			_currentActiveGO = gameObjects[num];
			if (_currentActiveGO != null)
			{
				_currentActiveGO.SetActive(value: true);
				if (activeGONameText != null)
				{
					activeGONameText.text = _currentActiveGO.name;
				}
			}
		}
	}
}
