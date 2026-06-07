namespace Tyd
{
	public class TydTable : TydCollection
	{
		public string this[string name]
		{
			get
			{
				return GetChildValue(name);
			}
			set
			{
				AddChild(new TydString(name, value));
			}
		}

		public TydTable(string name, int docLine = -1)
			: base(name, docLine)
		{
		}

		public TydTable(string name, params TydNode[] children)
			: base(name)
		{
			AddChildren(children);
		}

		public TydTable(string name, params string[] children)
			: base(name)
		{
			for (int i = 0; i < children.Length; i++)
			{
				AddChild(new TydString(null, children[i]));
			}
		}

		public override TydNode DeepClone()
		{
			TydTable tydTable = new TydTable(_name, DocLine);
			CopyDataFrom(tydTable);
			return tydTable;
		}

		public override string ToString()
		{
			return string.Format("{0}({1}, {2})", base.Name, "TydTable", base.Count);
		}
	}
}
