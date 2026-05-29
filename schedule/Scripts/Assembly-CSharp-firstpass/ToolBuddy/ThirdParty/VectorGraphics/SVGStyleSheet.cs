using System.Collections.Generic;

namespace ToolBuddy.ThirdParty.VectorGraphics
{
	internal class SVGStyleSheet
	{
		private List<KeyValuePair<string, SVGPropertySheet>> m_Selectors;

		public SVGPropertySheet this[string key]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IEnumerable<string> selectors => null;

		public int Count => 0;

		public void Clear()
		{
		}
	}
}
