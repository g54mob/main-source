using System;
using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class CmsProcessableInputStream : CmsProcessable, CmsReadable
	{
		private readonly Stream input;

		private bool used;

		public CmsProcessableInputStream(Stream input)
		{
		}

		public virtual Stream GetInputStream()
		{
			return null;
		}

		public virtual void Write(Stream output)
		{
		}

		[Obsolete]
		public virtual object GetContent()
		{
			return null;
		}

		protected virtual void CheckSingleUsage()
		{
		}
	}
}
