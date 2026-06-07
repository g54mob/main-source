using System.Collections.Generic;

namespace Tyd
{
	public abstract class TydNode
	{
		protected string _name;

		public int DocLine = -1;

		public int DocIndexEnd = -1;

		public TydNode Parent { get; set; }

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public int LineNumber
		{
			get
			{
				return DocLine;
			}
		}

		public string FullTyd
		{
			get
			{
				return TydToText.Write(this, true);
			}
		}

		public TydNode(string name, int docLine = -1)
		{
			_name = name;
			DocLine = docLine;
		}

		public IEnumerable<string> GetNodeValues()
		{
			TydString tydString;
			if ((tydString = this as TydString) != null)
			{
				yield return tydString.Value;
			}
			else
			{
				TydCollection tydCollection;
				if ((tydCollection = this as TydCollection) == null)
				{
					yield break;
				}
				foreach (string childValue in tydCollection.GetChildValues())
				{
					yield return childValue;
				}
			}
		}

		public abstract TydNode DeepClone();
	}
}
