using System;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using TwitchLib.Communication.Events;
using TwitchLib.Communication.Interfaces;
using TwitchLib.Communication.Models;
using TwitchLib.Communication.Services;

namespace TwitchLib.Communication.Clients
{
	public class TcpClient : IClient
	{
		private readonly string _server = "irc.chat.twitch.tv";

		private StreamReader _reader;

		private StreamWriter _writer;

		private readonly Throttlers _throttlers;

		private CancellationTokenSource _tokenSource = new CancellationTokenSource();

		private bool _stopServices;

		private bool _networkServicesRunning;

		private Task[] _networkTasks;

		private Task _monitorTask;

		public TimeSpan DefaultKeepAliveInterval { get; set; }

		public int SendQueueLength => _throttlers.SendQueue.Count;

		public int WhisperQueueLength => _throttlers.WhisperQueue.Count;

		public bool IsConnected => Client?.Connected ?? false;

		public IClientOptions Options { get; }

		private int Port => (Options != null) ? (Options.UseSsl ? 443 : 80) : 0;

		public System.Net.Sockets.TcpClient Client { get; private set; }

		public event EventHandler<OnConnectedEventArgs> OnConnected;

		public event EventHandler<OnDataEventArgs> OnData;

		public event EventHandler<OnDisconnectedEventArgs> OnDisconnected;

		public event EventHandler<OnErrorEventArgs> OnError;

		public event EventHandler<OnFatalErrorEventArgs> OnFatality;

		public event EventHandler<OnMessageEventArgs> OnMessage;

		public event EventHandler<OnMessageThrottledEventArgs> OnMessageThrottled;

		public event EventHandler<OnWhisperThrottledEventArgs> OnWhisperThrottled;

		public event EventHandler<OnSendFailedEventArgs> OnSendFailed;

		public event EventHandler<OnStateChangedEventArgs> OnStateChanged;

		public event EventHandler<OnReconnectedEventArgs> OnReconnected;

		public TcpClient(IClientOptions options = null)
		{
			Options = options ?? new ClientOptions();
			_throttlers = new Throttlers(this, Options.ThrottlingPeriod, Options.WhisperThrottlingPeriod)
			{
				TokenSource = _tokenSource
			};
			InitializeClient();
		}

		private void InitializeClient()
		{
			Client = new System.Net.Sockets.TcpClient();
			if (_monitorTask == null)
			{
				_monitorTask = StartMonitorTask();
			}
			else if (_monitorTask.IsCompleted)
			{
				_monitorTask = StartMonitorTask();
			}
		}

		public bool Open()
		{
			try
			{
				if (IsConnected)
				{
					return true;
				}
				Task.Run(delegate
				{
					InitializeClient();
					Client.Connect(_server, Port);
					if (Options.UseSsl)
					{
						SslStream sslStream = new SslStream(Client.GetStream(), leaveInnerStreamOpen: false);
						sslStream.AuthenticateAsClient(_server);
						_reader = new StreamReader(sslStream);
						_writer = new StreamWriter(sslStream);
					}
					else
					{
						_reader = new StreamReader(Client.GetStream());
						_writer = new StreamWriter(Client.GetStream());
					}
				}).Wait(10000);
				if (!IsConnected)
				{
					return Open();
				}
				StartNetworkServices();
				return true;
			}
			catch (Exception)
			{
				InitializeClient();
				return false;
			}
		}

		public void Close(bool callDisconnect = true)
		{
			_reader?.Dispose();
			_writer?.Dispose();
			Client?.Close();
			_stopServices = callDisconnect;
			CleanupServices();
			InitializeClient();
			this.OnDisconnected?.Invoke(this, new OnDisconnectedEventArgs());
		}

		public void Reconnect()
		{
			Close();
			Open();
			this.OnReconnected?.Invoke(this, new OnReconnectedEventArgs());
		}

		public bool Send(string message)
		{
			try
			{
				if (!IsConnected || SendQueueLength >= Options.SendQueueCapacity)
				{
					return false;
				}
				_throttlers.SendQueue.Add(new Tuple<DateTime, string>(DateTime.UtcNow, message));
				return true;
			}
			catch (Exception exception)
			{
				this.OnError?.Invoke(this, new OnErrorEventArgs
				{
					Exception = exception
				});
				throw;
			}
		}

		public bool SendWhisper(string message)
		{
			try
			{
				if (!IsConnected || WhisperQueueLength >= Options.WhisperQueueCapacity)
				{
					return false;
				}
				_throttlers.WhisperQueue.Add(new Tuple<DateTime, string>(DateTime.UtcNow, message));
				return true;
			}
			catch (Exception exception)
			{
				this.OnError?.Invoke(this, new OnErrorEventArgs
				{
					Exception = exception
				});
				throw;
			}
		}

		private void StartNetworkServices()
		{
			_networkServicesRunning = true;
			_networkTasks = new Task[3]
			{
				StartListenerTask(),
				_throttlers.StartSenderTask(),
				_throttlers.StartWhisperSenderTask()
			}.ToArray();
			if (_networkTasks.Any((Task c) => c.IsFaulted))
			{
				_networkServicesRunning = false;
				CleanupServices();
			}
		}

		public Task SendAsync(string message)
		{
			return Task.Run(async delegate
			{
				await _writer.WriteLineAsync(message);
				await _writer.FlushAsync();
			});
		}

		private Task StartListenerTask()
		{
			return Task.Run(async delegate
			{
				while (IsConnected && _networkServicesRunning)
				{
					try
					{
						string input = await _reader.ReadLineAsync();
						this.OnMessage?.Invoke(this, new OnMessageEventArgs
						{
							Message = input
						});
					}
					catch (Exception exception)
					{
						this.OnError?.Invoke(this, new OnErrorEventArgs
						{
							Exception = exception
						});
					}
				}
			});
		}

		private Task StartMonitorTask()
		{
			return Task.Run(delegate
			{
				bool flag = false;
				try
				{
					bool isConnected = IsConnected;
					while (!_tokenSource.IsCancellationRequested)
					{
						if (isConnected == IsConnected)
						{
							Thread.Sleep(200);
						}
						else
						{
							this.OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
							{
								IsConnected = IsConnected,
								WasConnected = isConnected
							});
							if (IsConnected)
							{
								this.OnConnected?.Invoke(this, new OnConnectedEventArgs());
							}
							if (!IsConnected && !_stopServices)
							{
								if (isConnected && Options.ReconnectionPolicy != null && !Options.ReconnectionPolicy.AreAttemptsComplete())
								{
									flag = true;
									break;
								}
								this.OnDisconnected?.Invoke(this, new OnDisconnectedEventArgs());
							}
							isConnected = IsConnected;
						}
					}
				}
				catch (Exception exception)
				{
					this.OnError?.Invoke(this, new OnErrorEventArgs
					{
						Exception = exception
					});
				}
				if (flag && !_stopServices)
				{
					Reconnect();
				}
			}, _tokenSource.Token);
		}

		private void CleanupServices()
		{
			_tokenSource.Cancel();
			_tokenSource = new CancellationTokenSource();
			_throttlers.TokenSource = _tokenSource;
			if (_stopServices)
			{
				Task[] networkTasks = _networkTasks;
				if (networkTasks != null && networkTasks.Length != 0 && !Task.WaitAll(_networkTasks, 15000))
				{
					this.OnFatality?.Invoke(this, new OnFatalErrorEventArgs
					{
						Reason = "Fatal network error. Network services fail to shut down."
					});
					_stopServices = false;
					_throttlers.Reconnecting = false;
					_networkServicesRunning = false;
				}
			}
		}

		public void WhisperThrottled(OnWhisperThrottledEventArgs eventArgs)
		{
			this.OnWhisperThrottled?.Invoke(this, eventArgs);
		}

		public void MessageThrottled(OnMessageThrottledEventArgs eventArgs)
		{
			this.OnMessageThrottled?.Invoke(this, eventArgs);
		}

		public void SendFailed(OnSendFailedEventArgs eventArgs)
		{
			this.OnSendFailed?.Invoke(this, eventArgs);
		}

		public void Error(OnErrorEventArgs eventArgs)
		{
			this.OnError?.Invoke(this, eventArgs);
		}

		public void Dispose()
		{
			Close();
			_throttlers.ShouldDispose = true;
			_tokenSource.Cancel();
			Thread.Sleep(500);
			_tokenSource.Dispose();
			Client?.Dispose();
			GC.Collect();
		}
	}
}
