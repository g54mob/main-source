using System;
using System.Linq;
using System.Text;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Util;

namespace Amazon
{
	public class Arn
	{
		private string _accountId = string.Empty;

		public string Partition { get; set; }

		public string Service { get; set; }

		public string Region { get; set; }

		public string AccountId
		{
			get
			{
				return _accountId;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					_accountId = string.Empty;
					return;
				}
				if (value != "*" && value.ToCharArray().Any((char x) => !char.IsLetterOrDigit(x) && x != '-'))
				{
					throw new AmazonAccountIdException("AccountId is invalid. The AccountId should be '*' or must only contain alphanumeric characters and dashes.");
				}
				_accountId = value;
			}
		}

		public string Resource { get; set; }

		public static bool IsArn(string arn)
		{
			return arn?.StartsWith("arn:", StringComparison.Ordinal) ?? false;
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
			string text = array[1];
			if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentException("Malformed ARN - no partition specified");
			}
			string text2 = array[2];
			if (string.IsNullOrEmpty(text2))
			{
				throw new ArgumentException("Malformed ARN - no service specified");
			}
			string region = array[3];
			string accountId = array[4];
			string text3 = array[5];
			if (string.IsNullOrEmpty(text3))
			{
				throw new ArgumentException("Malformed ARN - no resource specified");
			}
			return new Arn
			{
				Partition = text,
				Service = text2,
				Region = region,
				AccountId = accountId,
				Resource = text3
			};
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("arn:");
			stringBuilder.Append(Partition);
			stringBuilder.Append(":");
			stringBuilder.Append(Service);
			stringBuilder.Append(":");
			stringBuilder.Append(Region);
			stringBuilder.Append(":");
			stringBuilder.Append(AccountId);
			stringBuilder.Append(":");
			stringBuilder.Append(Resource);
			return stringBuilder.ToString();
		}

		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (!(o is Arn arn))
			{
				return false;
			}
			if (!Partition.Equals(arn.Partition))
			{
				return false;
			}
			if (!Service.Equals(arn.Service))
			{
				return false;
			}
			if (Region != arn.Region)
			{
				return false;
			}
			if (AccountId != arn.AccountId)
			{
				return false;
			}
			return Resource.Equals(arn.Resource);
		}

		public override int GetHashCode()
		{
			return Hashing.Hash(Partition, Service, Region, AccountId, Resource);
		}
	}
}
