using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Demos
{
	public class DemoProperties : MonoBehaviour
	{
		[Serializable]
		public class InputItem
		{
			public string InputAlias;

			public string ActionDescription;
		}

		[Tooltip("Demo title")]
		public string Title;

		[Tooltip("Short description of this demo.")]
		[TextArea(8, 16)]
		public string Description;

		[Tooltip("The list of input aliases used in this demo.")]
		public List<InputItem> InputItems;
	}
}
