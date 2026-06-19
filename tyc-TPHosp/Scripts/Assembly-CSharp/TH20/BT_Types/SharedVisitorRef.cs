using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class SharedVisitorRef : SharedCharacterRef
	{
		public new Visitor Get => (Visitor)base.Value.Get;

		public static implicit operator SharedVisitorRef(VisitorRef value)
		{
			return new SharedVisitorRef
			{
				Value = value
			};
		}
	}
}
