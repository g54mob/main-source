using System;
using System.Text;
using UnityEngine;

public class NetworkSessionStatistics
{
	private class NetworkChannelStatistics
	{
		private int _sentMessagesCount;

		private int _sentBytesTotal;

		private int _receivedMessagesCount;

		private int _receivedBytesTotal;

		private int _largestSentPackage;

		private int _largestReceivedPackage;

		public void PrintStatistics(ref StringBuilder stringBuilder, double durationInSeconds)
		{
			stringBuilder.AppendLine($"Total messages sent: {_sentMessagesCount}");
			stringBuilder.AppendLine($"Total bytes sent: {_sentBytesTotal}");
			stringBuilder.AppendLine($"Average bytes sent per message: {((_sentMessagesCount != 0) ? (_sentBytesTotal / _sentMessagesCount) : 0)}");
			stringBuilder.AppendLine($"Average messages sent per second: {((durationInSeconds == 0.0) ? 0.0 : ((double)_sentMessagesCount / durationInSeconds))}");
			stringBuilder.AppendLine($"Average bytes sent per second: {((durationInSeconds == 0.0) ? 0.0 : ((double)_sentBytesTotal / durationInSeconds))}");
			stringBuilder.AppendLine($"Largest single package sent bytes: {_largestSentPackage}");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine($"Total messages received: {_receivedMessagesCount}");
			stringBuilder.AppendLine($"Total bytes received: {_receivedBytesTotal}");
			stringBuilder.AppendLine($"Average bytes received per message: {((_receivedMessagesCount != 0) ? (_receivedBytesTotal / _receivedMessagesCount) : 0)}");
			stringBuilder.AppendLine($"Average messages received per second: {((durationInSeconds == 0.0) ? 0.0 : ((double)_receivedMessagesCount / durationInSeconds))}");
			stringBuilder.AppendLine($"Average bytes received per second: {((durationInSeconds == 0.0) ? 0.0 : ((double)_receivedBytesTotal / durationInSeconds))}");
			stringBuilder.AppendLine($"Largest single received bytes: {_largestReceivedPackage}");
		}

		public void AddMessage(bool sent, int bytes)
		{
			if (sent)
			{
				_sentMessagesCount++;
				_sentBytesTotal += bytes;
				_largestSentPackage = Math.Max(_largestSentPackage, bytes);
			}
			else
			{
				_receivedMessagesCount++;
				_receivedBytesTotal += bytes;
				_largestReceivedPackage = Math.Max(_largestReceivedPackage, bytes);
			}
		}
	}

	public enum Channel
	{
		Main = 0,
		Side = 1,
		Custom = 2
	}

	private NetworkChannelStatistics _mainChannelStats;

	private NetworkChannelStatistics _sideChannelStats;

	private NetworkChannelStatistics _customChannelStats;

	private DateTime _startTime;

	private readonly string _sessionName;

	public NetworkSessionStatistics(string sessionName)
	{
		_mainChannelStats = new NetworkChannelStatistics();
		_sideChannelStats = new NetworkChannelStatistics();
		_customChannelStats = new NetworkChannelStatistics();
		_sessionName = sessionName;
		_startTime = DateTime.Now;
	}

	public void TrackMessage(bool sent, bool sideChannel, int bytes)
	{
		if (sideChannel)
		{
			TrackMessage(sent, Channel.Side, bytes);
		}
		else
		{
			TrackMessage(sent, Channel.Main, bytes);
		}
	}

	public void TrackMessage(bool sent, Channel channel, int bytes)
	{
		switch (channel)
		{
		case Channel.Main:
			_mainChannelStats.AddMessage(sent, bytes);
			break;
		case Channel.Side:
			_sideChannelStats.AddMessage(sent, bytes);
			break;
		case Channel.Custom:
			_customChannelStats.AddMessage(sent, bytes);
			break;
		}
	}

	public void PrintStatistics()
	{
		double num = Math.Max((DateTime.Now - _startTime).TotalSeconds, 1.0);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"Network traffic statistics for session {_sessionName} which started on {_startTime}");
		stringBuilder.AppendLine($"Session duration: {TimeSpan.FromSeconds(num)}");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Main channel:");
		_mainChannelStats.PrintStatistics(ref stringBuilder, num);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Side channel:");
		_sideChannelStats.PrintStatistics(ref stringBuilder, num);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Custom channel:");
		_customChannelStats.PrintStatistics(ref stringBuilder, num);
		stringBuilder.AppendLine();
		Debug.Log(stringBuilder.ToString());
	}
}
