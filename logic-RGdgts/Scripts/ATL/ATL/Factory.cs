using System.Collections.Generic;

namespace ATL
{
	public abstract class Factory
	{
		public static readonly Format UNKNOWN_FORMAT;

		protected IDictionary<string, IList<Format>> formatListByExt;

		protected IDictionary<string, IList<Format>> formatListByMime;

		protected void addFormat(Format f)
		{
		}

		public IList<Format> getFormatsFromPath(string path)
		{
			return null;
		}

		public IList<Format> getFormatsFromMimeType(string mimeType)
		{
			return null;
		}

		public ICollection<Format> getFormats()
		{
			return null;
		}
	}
}
