using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace ScriptableObjects.ScriptableObjectScripts.Settings
{
	public record LocalizeTextMiscStringKey(string Text) : ILocalizeTextStringKey
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

		public string Text { get; set; }

		public string Key => null;

		public string Pkey => null;

		private static readonly MD5CryptoServiceProvider MD5;

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
		public virtual bool Equals(LocalizeTextMiscStringKey? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected LocalizeTextMiscStringKey(LocalizeTextMiscStringKey original)
		{
		}

		[CompilerGenerated]
		public void Deconstruct(out string Text)
		{
			Text = null;
		}
	}
}
