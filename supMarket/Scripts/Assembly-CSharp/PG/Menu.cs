using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PG
{
	public class Menu : MonoBehaviour
	{
		[Serializable]
		public class ButtonScene
		{
			public Button Btn;

			public SceneField Scene;
		}

		public List<ButtonScene> ButtonScenes;

		public bool CanHideMainMenu;

		public GameObject MainParent;

		public GameObject HelpTextGO;

		public CursorLockMode CursorMode;

		private void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
