using System.Collections.Generic;
using System.IO;
using Crosstales.Ude.Core;

namespace Crosstales.Ude
{
	public class CharsetDetector : UniversalDetector, ICharsetDetector
	{
		private readonly Dictionary<string, int> codepages = new Dictionary<string, int>
		{
			{ "UTF-8", 65001 },
			{ "UTF-16BE", 1201 },
			{ "UTF-16LE", 1200 },
			{ "UTF-32BE", 12001 },
			{ "UTF-32LE", 12000 },
			{ "EUC-KR", 51949 },
			{ "EUC-JP", 51932 },
			{ "Big-5", 950 },
			{ "gb18030", 54936 },
			{ "windows-1252", 1252 },
			{ "Shift-JIS", 932 },
			{ "ASCII", 20127 }
		};

		private string charset;

		private float confidence;

		public string Charset => charset;

		public float Confidence => confidence;

		public int CodePage
		{
			get
			{
				if (codepages.ContainsKey(Charset))
				{
					return codepages[Charset];
				}
				return 65001;
			}
		}

		public CharsetDetector()
			: base(31)
		{
		}

		public void Feed(Stream stream)
		{
			byte[] array = new byte[1024];
			int len;
			while ((len = stream.Read(array, 0, array.Length)) > 0 && !done)
			{
				Feed(array, 0, len);
			}
		}

		public bool IsDone()
		{
			return done;
		}

		public override void Reset()
		{
			charset = null;
			confidence = 0f;
			base.Reset();
		}

		protected override void Report(string charset, float confidence)
		{
			this.charset = charset;
			this.confidence = confidence;
		}
	}
}
