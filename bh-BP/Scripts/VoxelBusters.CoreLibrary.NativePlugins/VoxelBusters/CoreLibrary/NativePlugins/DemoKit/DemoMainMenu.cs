using System;
using UnityEngine;
using UnityEngine.UI;

namespace VoxelBusters.CoreLibrary.NativePlugins.DemoKit
{
	public class DemoMainMenu : DemoPanel
	{
		[Serializable]
		public class MenuOption
		{
			public string displayName;

			public string sceneName;
		}

		[SerializeField]
		private RectTransform m_optionsRect;

		[SerializeField]
		private MenuOption[] m_options;

		[SerializeField]
		private Button m_optionButtonPrefab;

		private void Awake()
		{
		}

		public override void Rebuild()
		{
		}
	}
}
