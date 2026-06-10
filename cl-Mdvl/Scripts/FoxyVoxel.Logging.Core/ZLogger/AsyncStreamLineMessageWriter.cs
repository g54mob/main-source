using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ZLogger
{
	public class AsyncStreamLineMessageWriter : IAsyncLogProcessor, IAsyncDisposable
	{
		private readonly byte[] newLine;

		private readonly bool crlf;

		private readonly byte newLine1;

		private readonly byte newLine2;

		private readonly Stream stream;

		private readonly Channel<IZLoggerEntry> channel;

		private readonly Task writeLoop;

		private readonly ZLoggerOptions options;

		private readonly CancellationTokenSource cancellationTokenSource;

		public AsyncStreamLineMessageWriter(Stream stream, ZLoggerOptions options)
		{
			newLine = Encoding.UTF8.GetBytes(Environment.NewLine);
			cancellationTokenSource = new CancellationTokenSource();
			if (newLine.Length == 1)
			{
				newLine1 = newLine[0];
				newLine2 = 0;
				crlf = false;
			}
			else
			{
				newLine1 = newLine[0];
				newLine2 = newLine[1];
				crlf = true;
			}
			this.options = options;
			this.stream = stream;
			channel = Channel.CreateUnbounded<IZLoggerEntry>(new UnboundedChannelOptions
			{
				AllowSynchronousContinuations = false,
				SingleWriter = false,
				SingleReader = true
			});
			writeLoop = Task.Run((Func<Task>)WriteLoop);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Post(IZLoggerEntry log)
		{
			channel.Writer.TryWrite(log);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void AppendLine(StreamBufferWriter writer)
		{
			if (writer.TryGetForNewLine(out byte[] rawBuffer, out int rawWritten))
			{
				if (crlf)
				{
					rawBuffer[rawWritten] = newLine1;
					rawBuffer[rawWritten + 1] = newLine2;
					writer.Advance(2);
				}
				else
				{
					rawBuffer[rawWritten] = newLine1;
					writer.Advance(1);
				}
			}
			else
			{
				Span<byte> span = writer.GetSpan(newLine.Length);
				newLine.CopyTo(span);
			}
		}

		private async Task WriteLoop()
		{
			StreamBufferWriter writer = new StreamBufferWriter(stream);
			ChannelReader<IZLoggerEntry> reader = channel.Reader;
			Stopwatch sw = Stopwatch.StartNew();
			try
			{
				while (await reader.WaitToReadAsync().ConfigureAwait(continueOnCapturedContext: false))
				{
					LogInfo info = default(LogInfo);
					try
					{
						IZLoggerEntry item;
						while (reader.TryRead(out item))
						{
							info = item.LogInfo;
							if (options.EnableStructuredLogging)
							{
								Utf8JsonWriter threadStaticUtf8JsonWriter = options.GetThreadStaticUtf8JsonWriter(writer);
								try
								{
									threadStaticUtf8JsonWriter.WriteStartObject();
									item.FormatUtf8(writer, options, threadStaticUtf8JsonWriter);
									item.Return();
									threadStaticUtf8JsonWriter.WriteEndObject();
									threadStaticUtf8JsonWriter.Flush();
								}
								finally
								{
									threadStaticUtf8JsonWriter.Reset();
								}
							}
							else
							{
								item.FormatUtf8(writer, options, null);
								item.Return();
							}
							AppendLine(writer);
						}
						info = default(LogInfo);
						if (options.FlushRate.HasValue && !cancellationTokenSource.IsCancellationRequested)
						{
							sw.Stop();
							TimeSpan timeSpan = options.FlushRate.Value - sw.Elapsed;
							if (timeSpan > TimeSpan.Zero)
							{
								try
								{
									await Task.Delay(timeSpan, cancellationTokenSource.Token).ConfigureAwait(continueOnCapturedContext: false);
								}
								catch (OperationCanceledException)
								{
								}
							}
						}
						writer.Flush();
						sw.Reset();
						sw.Start();
					}
					catch (Exception ex2)
					{
						try
						{
							if (options.InternalErrorLogger != null)
							{
								options.InternalErrorLogger(info, ex2);
							}
							else
							{
								Console.WriteLine(ex2);
							}
						}
						catch
						{
						}
					}
				}
			}
			catch (OperationCanceledException)
			{
			}
			finally
			{
				try
				{
					writer.Flush();
				}
				catch
				{
				}
			}
		}

		public async ValueTask DisposeAsync()
		{
			try
			{
				channel.Writer.Complete();
				cancellationTokenSource.Cancel();
				await writeLoop.ConfigureAwait(continueOnCapturedContext: false);
			}
			finally
			{
				stream.Dispose();
			}
		}
	}
}
