using System;
using UnityEngine;

namespace Rewired.UI.ControlMapper
{
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
	}
}
