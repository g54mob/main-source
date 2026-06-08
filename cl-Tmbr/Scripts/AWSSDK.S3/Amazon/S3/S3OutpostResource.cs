using System.Linq;
using System.Text;
using Amazon.Runtime;

namespace Amazon.S3
{
	public class S3OutpostResource
	{
		private Arn _arn;

		private string _outpostId = string.Empty;

		public string OutpostId
		{
			get
			{
				return _outpostId;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					_outpostId = string.Empty;
					return;
				}
				if (value.Length > 63 || value.Length < 1 || value.ToCharArray().Any((char x) => !char.IsLetterOrDigit(x) && x != '-'))
				{
					throw new AmazonClientException("Invalid outpost ID: " + value + ". ID must contain only alphanumeric characters and dashes");
				}
				_outpostId = value;
			}
		}

		public string AccessPointName { get; set; }

		public string Key { get; set; }

		public string FullAccessPointName
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				string[] array = _arn.Resource.Split(':', '/');
				for (int i = 0; i < 4; i++)
				{
					if (i != 0)
					{
						stringBuilder.Append(_arn.Resource.Substring(stringBuilder.Length, 1));
					}
					stringBuilder.Append(array[i]);
				}
				return $"arn:{_arn.Partition}:{_arn.Service}:{_arn.Region}:{_arn.AccountId}:{stringBuilder}";
			}
		}

		public S3OutpostResource(Arn arn)
		{
			_arn = arn;
		}
	}
}
