using System.Collections.Generic;

namespace Tyd
{
	public class TydDocument : TydTable
	{
		public TydDocument()
			: base(null)
		{
			_nodes = new List<TydNode>();
		}

		public TydDocument(IEnumerable<TydNode> nodes)
			: base(null)
		{
			_nodes = new List<TydNode>();
			_nodes.AddRange(nodes);
		}

		public override string ToString()
		{
			return string.Format("{0}({1}, {2})", base.Name, "TydDocument", base.Count);
		}
	}
}
