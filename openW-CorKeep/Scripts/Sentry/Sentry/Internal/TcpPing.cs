using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Sentry.Internal
{
	internal class TcpPing : IPing
	{
		private readonly Ping _ping;

		public TcpPing(string hostToCheck, int portToCheck = 443)
		{
			_003ChostToCheck_003EP = hostToCheck;
			_003CportToCheck_003EP = portToCheck;
			_ping = new Ping();
			base._002Ector();
		}

		public async Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
		{
			try
			{
				using TcpClient tcpClient = new TcpClient();
				await tcpClient.ConnectAsync(_003ChostToCheck_003EP, _003CportToCheck_003EP).ConfigureAwait(continueOnCapturedContext: false);
				return true;
			}
			catch (OperationCanceledException)
			{
				throw;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
