using System;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitchLib.Communication.Enums;
using TwitchLib.Communication.Events;
using TwitchLib.Communication.Interfaces;
using TwitchLib.Communication.Models;
using TwitchLib.Communication.Services;

namespace TwitchLib.Communication.Clients
{
	public class WebSocketClient : IClient
	{
		private readonly Throttlers _throttlers;

		private CancellationTokenSource _tokenSource = new CancellationTokenSource();

		private bool _stopServices;

		private bool _networkServicesRunning;

		private Task[] _networkTasks;

		private Task _monitorTask;

		public TimeSpan DefaultKeepAliveInterval { get; set; }

		public int SendQueueLength => _throttlers.SendQueue.Count;

		public int WhisperQueueLength => _throttlers.WhisperQueue.Count;

		public bool IsConnected
		{
			get
			{
				ClientWebSocket client = Client;
				return client != null && client.State == WebSocketState.Open;
			}
		}

		public IClientOptions Options { get; }

		public ClientWebSocket Client { get; private set; }

		private string Url { get; }

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

		public WebSocketClient(IClientOptions options = null)
		{
			Options = options ?? new ClientOptions();
			switch (Options.ClientType)
			{
			case ClientType.Chat:
				Url = (Options.UseSsl ? "wss://irc-ws.chat.twitch.tv:443" : "ws://irc-ws.chat.twitch.tv:80");
				break;
			case ClientType.PubSub:
				Url = (Options.UseSsl ? "wss://pubsub-edge.twitch.tv:443" : "ws://pubsub-edge.twitch.tv:80");
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			_throttlers = new Throttlers(this, Options.ThrottlingPeriod, Options.WhisperThrottlingPeriod)
			{
				TokenSource = _tokenSource
			};
		}

		private void InitializeClient()
		{
			Client?.Abort();
			Client = new ClientWebSocket();
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
				InitializeClient();
				Client.ConnectAsync(new Uri(Url), _tokenSource.Token).Wait(10000);
				if (!IsConnected)
				{
					return Open();
				}
				StartNetworkServices();
				return true;
			}
			catch (WebSocketException)
			{
				InitializeClient();
				return false;
			}
		}

		public void Close(bool callDisconnect = true)
		{
			Client?.Abort();
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

		public Task SendAsync(byte[] message)
		{
			return Client.SendAsync(new ArraySegment<byte>(message), WebSocketMessageType.Text, endOfMessage: true, _tokenSource.Token);
		}

		private Task StartListenerTask()
		{
			return Task.Run(async delegate
			{
				string message = "";
				while (IsConnected && _networkServicesRunning)
				{
					byte[] buffer = new byte[1024];
					WebSocketReceiveResult result;
					try
					{
						result = await Client.ReceiveAsync(new ArraySegment<byte>(buffer), _tokenSource.Token);
					}
					catch
					{
						InitializeClient();
						break;
					}
					if (result != null)
					{
						switch ((int)result.MessageType)
						{
						case 2:
							Close();
							break;
						case 0:
							if (!result.EndOfMessage)
							{
								message += Encoding.UTF8.GetString(buffer).TrimEnd(default(char));
								continue;
							}
							message += Encoding.UTF8.GetString(buffer).TrimEnd(default(char));
							this.OnMessage?.Invoke(this, new OnMessageEventArgs
							{
								Message = message
							});
							break;
						default:
							throw new ArgumentOutOfRangeException();
						case 1:
							break;
						}
						message = "";
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
								IsConnected = (Client.State == WebSocketState.Open),
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
								if (Client.CloseStatus.HasValue && Client.CloseStatus != WebSocketCloseStatus.NormalClosure)
								{
									this.OnError?.Invoke(this, new OnErrorEventArgs
									{
										Exception = new Exception(string.Concat(Client.CloseStatus, " ", Client.CloseStatusDescription))
									});
								}
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
