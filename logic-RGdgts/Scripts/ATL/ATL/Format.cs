using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ATL
{
	public class Format : IEnumerable
	{
		public delegate bool CheckHeaderDelegate(byte[] data);

		public delegate bool SearchHeaderDelegate(Stream data);

		protected IDictionary<string, int> mimeList;

		protected IDictionary<string, int> extList;

		public string Name { get; set; }

		public string ShortName { get; set; }

		public int ID { get; set; }

		public CheckHeaderDelegate CheckHeader { get; set; }

		public SearchHeaderDelegate SearchHeader { get; set; }

		public ICollection<string> MimeList => null;

		public bool Readable { get; set; }

		public Format(int id, string name, string shortName = "")
		{
		}

		public Format(Format f)
		{
		}

		protected void copyFrom(Format f)
		{
		}

		protected void init(int id, string name, string shortName = "")
		{
		}

		public IEnumerator GetEnumerator()
		{
			return null;
		}

		public void AddMimeType(string mimeType)
		{
		}

		public void AddExtension(string ext)
		{
		}
	}
}
