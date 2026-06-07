using System;
using UnityEngine;

namespace Document
{
	[Serializable]
	public class DocumentElementsColor
	{
		public int holderColorIndex;

		public Color customColor;

		public DocumentColorType colorType
		{
			get
			{
				return default(DocumentColorType);
			}
			private set
			{
			}
		}
	}
}
