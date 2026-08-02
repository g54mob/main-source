using System;
using UnityEngine;

namespace GRP
{
	[Serializable]
	public struct TextPartVisualOptions
	{
		[TextArea(3, 10)]
		public string text;

		public float depth;

		public float size;

		public float horizontal;

		public float vertical;
	}
}
