using System.Collections.Generic;
using CLanguage.Compiler;

namespace CLanguage.Types
{
	public class CStructType : CType
	{
		public string Name { get; set; }

		public List<CStructMember> Members { get; set; }

		public override int NumValues => 0;

		public CStructType(string name)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override int GetByteSize(EmitContext c)
		{
			return 0;
		}

		public int GetFieldValueOffset(CStructMember member, EmitContext c)
		{
			return 0;
		}
	}
}
