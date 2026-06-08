using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Events;
using TwitchLib.Communication.Interfaces;

namespace TwitchLib.Communication.Services
{
	public class Throttlers
	{
		public readonly BlockingCollection<Tuple<DateTime, string>> SendQueue = new BlockingCollection<Tuple<DateTime, string>>();

		public readonly BlockingCollection<Tuple<DateTime, string>> WhisperQueue = new BlockingCollection<Tuple<DateTime, string>>();

		public bool ResetThrottlerRunning;

		public bool ResetWhisperThrottlerRunning;

		public int SentCount = 0;

		public int WhispersSent = 0;

		public Task ResetThrottler;

		public Task ResetWhisperThrottler;

		private readonly TimeSpan _throttlingPeriod;

		private readonly TimeSpan _whisperThrottlingPeriod;

		private readonly IClient _client;

		public bool Reconnecting { get; set; } = false;

		public bool ShouldDispose { get; set; } = false;

		public CancellationTokenSource TokenSource { get; set; }

		public Throttlers(IClient client, TimeSpan throttlingPeriod, TimeSpan whisperThrottlingPeriod)
		{
			_throttlingPeriod = throttlingPeriod;
			_whisperThrottlingPeriod = whisperThrottlingPeriod;
			_client = client;
		}

		public void StartThrottlingWindowReset()
		{
			ResetThrottler = Task.Run(async delegate
			{
				ResetThrottlerRunning = true;
				while (!ShouldDispose && !Reconnecting)
				{
					Interlocked.Exchange(ref SentCount, 0);
					await Task.Delay(_throttlingPeriod, TokenSource.Token);
				}
				ResetThrottlerRunning = false;
				return Task.CompletedTask;
			});
		}

		public void StartWhisperThrottlingWindowReset()
		{
			ResetWhisperThrottler = Task.Run(async delegate
			{
				ResetWhisperThrottlerRunning = true;
				while (!ShouldDispose && !Reconnecting)
				{
					Interlocked.Exchange(ref WhispersSent, 0);
					await Task.Delay(_whisperThrottlingPeriod, TokenSource.Token);
				}
				ResetWhisperThrottlerRunning = false;
				return Task.CompletedTask;
			});
		}

		public void IncrementSentCount()
		{
			Interlocked.Increment(ref SentCount);
		}

		public void IncrementWhisperCount()
		{
			Interlocked.Increment(ref WhispersSent);
		}

		public Task StartSenderTask()
		{
			StartThrottlingWindowReset();
			return Task.Run(async delegate
			{
				try
				{
					while (!ShouldDispose)
					{
						await Task.Delay(_client.Options.SendDelay);
						if (SentCount == _client.Options.MessagesAllowedInPeriod)
						{
							_client.MessageThrottled(new OnMessageThrottledEventArgs
							{
								Message = "Message Throttle Occured. Too Many Messages within the period specified in WebsocketClientOptions.",
								AllowedInPeriod = _client.Options.MessagesAllowedInPeriod,
								Period = _client.Options.ThrottlingPeriod,
								SentMessageCount = Interlocked.CompareExchange(ref SentCount, 0, 0)
							});
						}
						else if (_client.IsConnected && !ShouldDispose)
						{
							Tuple<DateTime, string> msg = SendQueue.Take(TokenSource.Token);
							if (!(msg.Item1.Add(_client.Options.SendCacheItemTimeout) < DateTime.UtcNow))
							{
								try
								{
									IClient client = _client;
									IClient client2 = client;
									if (client2 != null)
									{
										WebSocketClient webSocketClient2;
										WebSocketClient webSocketClient = (webSocketClient2 = client2 as WebSocketClient);
										if (webSocketClient2 == null)
										{
											TcpClient tcpClient2;
											TcpClient tcpClient = (tcpClient2 = client2 as TcpClient);
											if (tcpClient2 != null)
											{
												TcpClient tcp = tcpClient;
												await tcp.SendAsync(msg.Item2);
											}
										}
										else
										{
											WebSocketClient ws = webSocketClient;
											await ws.SendAsync(Encoding.UTF8.GetBytes(msg.Item2));
										}
									}
									IncrementSentCount();
								}
								catch (Exception ex)
								{
									Exception ex2 = ex;
									_client.SendFailed(new OnSendFailedEventArgs
									{
										Data = msg.Item2,
										Exception = ex2
									});
									break;
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					Exception ex3 = ex;
					_client.SendFailed(new OnSendFailedEventArgs
					{
						Data = "",
						Exception = ex3
					});
					_client.Error(new OnErrorEventArgs
					{
						Exception = ex3
					});
				}
			});
		}

		public Task StartWhisperSenderTask()
		{
			StartWhisperThrottlingWindowReset();
			return Task.Run(async delegate
			{
				try
				{
					while (!ShouldDispose)
					{
						await Task.Delay(_client.Options.SendDelay);
						if (WhispersSent == _client.Options.WhispersAllowedInPeriod)
						{
							_client.WhisperThrottled(new OnWhisperThrottledEventArgs
							{
								Message = "Whisper Throttle Occured. Too Many Whispers within the period specified in ClientOptions.",
								AllowedInPeriod = _client.Options.WhispersAllowedInPeriod,
								Period = _client.Options.WhisperThrottlingPeriod,
								SentWhisperCount = Interlocked.CompareExchange(ref WhispersSent, 0, 0)
							});
						}
						else if (_client.IsConnected && !ShouldDispose)
						{
							Tuple<DateTime, string> msg = WhisperQueue.Take(TokenSource.Token);
							if (!(msg.Item1.Add(_client.Options.SendCacheItemTimeout) < DateTime.UtcNow))
							{
								try
								{
									IClient client = _client;
									IClient client2 = client;
									if (client2 != null)
									{
										WebSocketClient webSocketClient2;
										WebSocketClient webSocketClient = (webSocketClient2 = client2 as WebSocketClient);
										if (webSocketClient2 == null)
										{
											TcpClient tcpClient2;
											TcpClient tcpClient = (tcpClient2 = client2 as TcpClient);
											if (tcpClient2 != null)
											{
												TcpClient tcp = tcpClient;
												await tcp.SendAsync(msg.Item2);
											}
										}
										else
										{
											WebSocketClient ws = webSocketClient;
											await ws.SendAsync(Encoding.UTF8.GetBytes(msg.Item2));
										}
									}
									IncrementSentCount();
								}
								catch (Exception ex)
								{
									Exception ex2 = ex;
									_client.SendFailed(new OnSendFailedEventArgs
									{
										Data = msg.Item2,
										Exception = ex2
									});
									break;
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					Exception ex3 = ex;
					_client.SendFailed(new OnSendFailedEventArgs
					{
						Data = "",
						Exception = ex3
					});
					_client.Error(new OnErrorEventArgs
					{
						Exception = ex3
					});
				}
			});
		}
	}
}
