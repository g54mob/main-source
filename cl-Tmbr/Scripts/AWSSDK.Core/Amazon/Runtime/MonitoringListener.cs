using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime
{
	internal sealed class MonitoringListener : IDisposable
	{
		private static readonly MonitoringListener csmMonitoringListenerInstance;

		private readonly string _host;

		private readonly UdpClient _udpClient;

		private readonly Logger logger;

		private readonly int _port;

		private bool _disposed;

		public static MonitoringListener Instance => csmMonitoringListenerInstance;

		private MonitoringListener()
		{
			_host = DeterminedCSMConfiguration.Instance.CSMConfiguration.Host;
			_port = DeterminedCSMConfiguration.Instance.CSMConfiguration.Port;
			_udpClient = new UdpClient();
			logger = Logger.GetLogger(typeof(MonitoringListener));
		}

		static MonitoringListener()
		{
			csmMonitoringListenerInstance = new MonitoringListener();
		}

		public void PostMessagesOverUDP(string response)
		{
		}

		public async Task PostMessagesOverUDPAsync(string response)
		{
			try
			{
				await _udpClient.SendAsync(Encoding.UTF8.GetBytes(response), Encoding.UTF8.GetBytes(response).Length, _host, _port).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex)
			{
				logger.InfoFormat("Error when posting UDP datagrams. " + ex.Message);
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_udpClient.Dispose();
				}
				_disposed = true;
			}
		}
	}
}
