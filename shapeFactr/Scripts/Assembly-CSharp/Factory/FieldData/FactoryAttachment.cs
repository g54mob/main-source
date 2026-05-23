using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Factory.FieldData
{
	public record FactoryAttachment(eAttachment Attachment, string[] Param)
	{
		[CompilerGenerated]
		protected virtual Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public eAttachment Attachment { get; set; }

		public string[] Param { get; set; }

		[CompilerGenerated]
		public override string ToString()
		{
			return null;
		}

		[CompilerGenerated]
		protected virtual bool PrintMembers(StringBuilder builder)
		{
			return false;
		}

		[CompilerGenerated]
		public virtual bool Equals(FactoryAttachment? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected FactoryAttachment(FactoryAttachment original)
		{
		}

		[CompilerGenerated]
		public void Deconstruct(out eAttachment Attachment, out string[] Param)
		{
			Attachment = default(eAttachment);
			Param = null;
		}
	}
}
