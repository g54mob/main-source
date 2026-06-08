using System;
using System.IO;
using System.Text;

namespace Castle.Core.Resource
{
	public class StaticContentResource : AbstractResource
	{
		private readonly string contents;

		public StaticContentResource(string contents)
		{
			this.contents = contents;
		}

		public override TextReader GetStreamReader()
		{
			return new StringReader(contents);
		}

		public override TextReader GetStreamReader(Encoding encoding)
		{
			throw new NotImplementedException();
		}

		public override IResource CreateRelative(string relativePath)
		{
			throw new NotImplementedException();
		}
	}
}
