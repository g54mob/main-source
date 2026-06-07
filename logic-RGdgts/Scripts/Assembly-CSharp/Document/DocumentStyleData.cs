using System.Collections.Generic;
using UnityEngine;

namespace Document
{
	[CreateAssetMenu]
	public class DocumentStyleData : ScriptableObject
	{
		public List<TextColor> textColors;

		public int pageColor;

		public int borderUp;

		public int borderDown;

		public int borderInternal;

		public int borderExternal;

		public Sprite pageBackground;
	}
}
