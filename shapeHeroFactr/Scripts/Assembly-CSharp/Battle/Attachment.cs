using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Battle
{
	public record Attachment
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

		public eAttachment attachementType { get; set; }

		public double rate { get; set; }

		public Attachment(List<string> param)
		{
		}

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
		public virtual bool Equals(Attachment? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected Attachment(Attachment original)
		{
		}
	}
}
