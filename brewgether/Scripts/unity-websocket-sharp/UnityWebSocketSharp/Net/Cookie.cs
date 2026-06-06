using System;

namespace UnityWebSocketSharp.Net
{
	[Serializable]
	internal sealed class Cookie
	{
		private string _comment;

		private Uri _commentUri;

		private bool _discard;

		private string _domain;

		private static readonly int[] _emptyPorts;

		private DateTime _expires;

		private bool _httpOnly;

		private string _name;

		private string _path;

		private string _port;

		private int[] _ports;

		private static readonly char[] _reservedCharsForValue;

		private string _sameSite;

		private bool _secure;

		private DateTime _timeStamp;

		private string _value;

		private int _version;

		internal bool ExactDomain => false;

		internal int MaxAge
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal int[] Ports => null;

		internal string SameSite
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Comment
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public Uri CommentUri
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public bool Discard
		{
			get
			{
				return false;
			}
			internal set
			{
			}
		}

		public string Domain
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool Expired
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public DateTime Expires
		{
			get
			{
				return default(DateTime);
			}
			set
			{
			}
		}

		public bool HttpOnly
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Path
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Port
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public bool Secure
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public DateTime TimeStamp => default(DateTime);

		public string Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Version
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		static Cookie()
		{
		}

		internal Cookie()
		{
		}

		public Cookie(string name, string value)
		{
		}

		public Cookie(string name, string value, string path)
		{
		}

		public Cookie(string name, string value, string path, string domain)
		{
		}

		private static int hash(int i, int j, int k, int l, int m)
		{
			return 0;
		}

		private void init(string name, string value, string path, string domain)
		{
		}

		private string toResponseStringVersion0()
		{
			return null;
		}

		private string toResponseStringVersion1()
		{
			return null;
		}

		private static bool tryCreatePorts(string value, out int[] result)
		{
			result = null;
			return false;
		}

		internal bool EqualsWithoutValue(Cookie cookie)
		{
			return false;
		}

		internal bool EqualsWithoutValueAndVersion(Cookie cookie)
		{
			return false;
		}

		internal string ToRequestString(Uri uri)
		{
			return null;
		}

		internal string ToResponseString()
		{
			return null;
		}

		internal static bool TryCreate(string name, string value, out Cookie result)
		{
			result = null;
			return false;
		}

		public override bool Equals(object comparand)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
