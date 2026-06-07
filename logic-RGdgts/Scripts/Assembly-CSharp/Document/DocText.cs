using System;
using TMPro;
using UI.Utilities;

namespace Document
{
	[Serializable]
	public struct DocText
	{
		public string tableName;

		public string entryName;

		public DocElementPosition position;

		public DocumentElementsColor color;

		public bool createObject;

		public TextComponentType textType;

		public LabelRefTextAlignement textAlignement;

		public TMP_FontAsset font;
	}
}
