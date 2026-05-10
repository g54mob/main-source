using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Generic
{
	[Serializable]
	public class HighlightedSubject
	{
		[field: SerializeField]
		public Graphic Graphic { get; private set; }

		[field: SerializeField]
		public bool DefaultIsInitial { get; private set; }

		[field: SerializeField]
		public Color DefaultColor { get; private set; }

		[field: SerializeField]
		public Color HighlightedColor { get; private set; }

		public void dvf()
		{
		}
	}
}
