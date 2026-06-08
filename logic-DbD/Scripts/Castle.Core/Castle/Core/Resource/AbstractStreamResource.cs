using System.IO;
using System.Text;

namespace Castle.Core.Resource
{
	public abstract class AbstractStreamResource : AbstractResource
	{
		private StreamFactory createStream;

		public StreamFactory CreateStream
		{
			get
			{
				return createStream;
			}
			set
			{
				createStream = value;
			}
		}

		~AbstractStreamResource()
		{
			Dispose(disposing: false);
		}

		public override TextReader GetStreamReader()
		{
			return new StreamReader(CreateStream());
		}

		public override TextReader GetStreamReader(Encoding encoding)
		{
			return new StreamReader(CreateStream(), encoding);
		}
	}
}
