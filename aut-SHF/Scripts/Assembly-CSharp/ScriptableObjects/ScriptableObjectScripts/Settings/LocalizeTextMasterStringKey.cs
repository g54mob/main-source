using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace ScriptableObjects.ScriptableObjectScripts.Settings
{
	public record LocalizeTextMasterStringKey(string Sheet, string Field, string Pkey) : ILocalizeTextStringKey
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

		public string Sheet { get; set; }

		public string Field { get; set; }

		public string Pkey { get; set; }

		public string Key => null;

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
		public virtual bool Equals(LocalizeTextMasterStringKey? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected LocalizeTextMasterStringKey(LocalizeTextMasterStringKey original)
		{
		}

		[CompilerGenerated]
		public void Deconstruct(out string Sheet, out string Field, out string Pkey)
		{
			Sheet = null;
			Field = null;
			Pkey = null;
		}
	}
}
