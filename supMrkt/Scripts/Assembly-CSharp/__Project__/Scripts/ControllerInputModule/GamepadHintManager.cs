using System.Collections.Generic;
using UnityEngine;

namespace __Project__.Scripts.ControllerInputModule
{
	public class GamepadHintManager : NoktaSingleton<GamepadHintManager>
	{
		[SerializeField]
		private List<GameObject> m_hintObjectList;

		public void Initialize()
		{
		}

		public void SwitchObjects(bool isGamepad)
		{
		}

		public void AddObject(GameObject hintObject)
		{
		}

		public void RemoveObject(GameObject hintObject)
		{
		}
	}
}
