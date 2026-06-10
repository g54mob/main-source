using System;
using System.Threading.Tasks;

namespace ModIO
{
	public struct ExternalAuthenticationToken
	{
		public string url;

		public string autoUrl;

		public string code;

		public Task<Result> task;

		public DateTime expiryTime;

		internal Action cancel { get; set; }

		public void Cancel()
		{
		}
	}
}
