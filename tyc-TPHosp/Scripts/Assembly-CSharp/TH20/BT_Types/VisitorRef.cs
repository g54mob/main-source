using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class VisitorRef : CharacterRef
	{
		public VisitorRef()
		{
		}

		public VisitorRef(Visitor visitor)
			: base(visitor)
		{
		}
	}
}
