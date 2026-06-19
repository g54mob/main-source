using System;

namespace Loxodon.Framework.Binding.Proxy.Sources.Text
{
	[Serializable]
	public class LiteralSourceDescription : SourceDescription
	{
		public object Literal { get; set; }

		public LiteralSourceDescription()
		{
			IsStatic = true;
		}

		public override string ToString()
		{
			if (Literal != null)
			{
				return "Literal:" + Literal.ToString();
			}
			return "Literal:null";
		}
	}
}
