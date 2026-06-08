using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.Runtime.Endpoints;

namespace Amazon.Runtime.Internal.Endpoints.StandardLibrary
{
	public class Arn : PropertyBag
	{
		public string partition
		{
			get
			{
				return (string)base["partition"];
			}
			set
			{
				base["partition"] = value;
			}
		}

		public string service
		{
			get
			{
				return (string)base["service"];
			}
			set
			{
				base["service"] = value;
			}
		}

		public string region
		{
			get
			{
				return (string)base["region"];
			}
			set
			{
				base["region"] = value;
			}
		}

		public string accountId
		{
			get
			{
				return (string)base["accountId"];
			}
			set
			{
				base["accountId"] = value;
			}
		}

		public List<string> resourceId
		{
			get
			{
				return (List<string>)base["resourceId"];
			}
			set
			{
				base["resourceId"] = value;
			}
		}

		public static bool IsArn(string arn)
		{
			return arn?.StartsWith("arn:") ?? false;
		}

		public static bool TryParse(string arnString, out Arn arn)
		{
			try
			{
				if (IsArn(arnString))
				{
					arn = Parse(arnString);
					return true;
				}
			}
			catch (Exception)
			{
			}
			arn = null;
			return false;
		}

		public static Arn Parse(string arnString)
		{
			if (arnString == null)
			{
				throw new ArgumentNullException("arnString");
			}
			string[] array = arnString.Split(new char[1] { ':' }, 6);
			if (array.Length != 6)
			{
				throw new ArgumentException("ARN is in incorrect format. ARN format is: arn:<partition>:<service>:<region>:<account-id>:<resource>");
			}
			if (array[0] != "arn")
			{
				throw new ArgumentException("ARN is in incorrect format. ARN format is: arn:<partition>:<service>:<region>:<account-id>:<resource>");
			}
			string value = array[1];
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentException("Malformed ARN - no partition specified");
			}
			string value2 = array[2];
			if (string.IsNullOrEmpty(value2))
			{
				throw new ArgumentException("Malformed ARN - no service specified");
			}
			string text = array[3];
			string text2 = array[4];
			string text3 = array[5];
			if (string.IsNullOrEmpty(text3))
			{
				throw new ArgumentException("Malformed ARN - no resource specified");
			}
			Arn arn = new Arn();
			arn.partition = value;
			arn.service = value2;
			arn.region = text;
			arn.accountId = text2;
			arn.resourceId = text3.Split(':', '/').ToList();
			return arn;
		}
	}
}
