using System;
using Libs;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class SceneSwitchCtrl : SingletonMonoBehaviour<SceneSwitchCtrl>
	{
		[Serializable]
		public struct ToSceneImage
		{
			public string name;

			public Sprite sprite;
		}

		public ToSceneImage[] toSceneImages;

		public Button switchButton;

		public CanvasGroup canvasGroup;

		private void Awake()
		{
		}

		public void ToggleInit()
		{
		}

		public void OnSelectDialogGroup()
		{
		}

		public void OnSelectShopGroup()
		{
		}

		public void CancelPadUI()
		{
		}
	}
}
