using System.Collections.Generic;
using CLanguage.Compiler;

namespace CLanguage.Types
{
	public class CEnumType : CType
	{
		public string Name { get; set; }

		public List<CEnumMember> Members { get; set; }

		public int NextValue => 0;

		public override int NumValues => 0;

		public override bool IsIntegral => false;

		public override int GetByteSize(EmitContext c)
		{
			return 0;
		}

		public CEnumType(string name)
		{
		}
	}
}
