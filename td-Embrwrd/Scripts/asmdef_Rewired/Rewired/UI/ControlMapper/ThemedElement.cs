using System;
using UnityEngine;

namespace Rewired.UI.ControlMapper
{
	[AddComponentMenu(null)]
	public class ThemedElement : MonoBehaviour
	{
		[Serializable]
		public class ElementInfo
		{
			[SerializeField]
			private string _themeClass;

			[SerializeField]
			private Component _component;

			public string themeClass => null;

			public Component component => null;
		}

		[SerializeField]
		private ElementInfo[] _elements;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void ApplyTheme()
		{
		}
	}
}
