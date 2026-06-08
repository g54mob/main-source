using Amazon.Runtime.Endpoints;

namespace Amazon.Runtime.Internal.Endpoints.StandardLibrary
{
	public class URL : PropertyBag
	{
		public string scheme
		{
			get
			{
				return (string)base["scheme"];
			}
			set
			{
				base["scheme"] = value;
			}
		}

		public string authority
		{
			get
			{
				return (string)base["authority"];
			}
			set
			{
				base["authority"] = value;
			}
		}

		public string path
		{
			get
			{
				return (string)base["path"];
			}
			set
			{
				base["path"] = value;
			}
		}

		public string normalizedPath
		{
			get
			{
				return (string)base["normalizedPath"];
			}
			set
			{
				base["normalizedPath"] = value;
			}
		}

		public bool isIp
		{
			get
			{
				return (bool)base["isIp"];
			}
			set
			{
				base["isIp"] = value;
			}
		}
	}
}
