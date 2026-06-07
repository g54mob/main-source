namespace Tyd
{
	public class TydList : TydCollection
	{
		public TydList(string name, int docLine = -1)
			: base(name, docLine)
		{
		}

		public TydList(string name, params TydNode[] children)
			: base(name)
		{
			AddChildren(children);
		}

		public TydList(string name, params string[] children)
			: base(name)
		{
			for (int i = 0; i < children.Length; i++)
			{
				AddChild(new TydString(null, children[i]));
			}
		}

		public override TydNode DeepClone()
		{
			TydList tydList = new TydList(_name, DocLine);
			CopyDataFrom(tydList);
			return tydList;
		}

		public override string ToString()
		{
			return string.Format("{0}({1}, {2})", base.Name, "TydList", base.Count);
		}
	}
}
