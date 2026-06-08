using System;
using UnityEngine;

namespace Kitchen.NetworkSupport
{
	public class NetworkTransportStats
	{
		public class Statistic
		{
			public float Value;

			public float Counter;

			public void Report(float amount)
			{
				Counter += amount;
			}

			public void Update(float dt)
			{
				Value += 0.1f * (Counter / dt - Value);
				Counter = 0f;
			}

			public static implicit operator float(Statistic s)
			{
				return s.Value;
			}
		}

		private readonly Statistic BytesUp = new Statistic();

		private readonly Statistic BytesDown = new Statistic();

		private readonly Statistic PacketsUp = new Statistic();

		private readonly Statistic PacketsDown = new Statistic();

		private readonly Statistic BytesRaw = new Statistic();

		private readonly Statistic BytesCompressed = new Statistic();

		private float LastUpdate;

		public string Summary => $"up {Math.Round((float)PacketsUp)}/{Math.Round((float)BytesUp / 1000f, 2)}k, " + $"down {Math.Round((float)PacketsDown)}/{Math.Round((float)BytesDown / 1000f, 2)}k, " + $"compress {Math.Round((1f - (float)BytesCompressed / (float)BytesRaw) * 100f)}%";

		public NetworkTransportStats()
		{
			LastUpdate = Time.realtimeSinceStartup;
		}

		public void ReportPacket(int byte_count, bool is_up, int multiplicity = 1)
		{
			if (is_up)
			{
				BytesUp.Report(byte_count * multiplicity);
				PacketsUp.Report(multiplicity);
			}
			else
			{
				BytesDown.Report(byte_count * multiplicity);
				PacketsDown.Report(multiplicity);
			}
		}

		public void ReportCompression(int bytes_raw, int bytes_compressed)
		{
			BytesRaw.Report(bytes_raw);
			BytesCompressed.Report(bytes_compressed);
		}

		public void Update()
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			float dt = realtimeSinceStartup - LastUpdate;
			BytesUp.Update(dt);
			BytesDown.Update(dt);
			PacketsUp.Update(dt);
			PacketsDown.Update(dt);
			BytesRaw.Update(dt);
			BytesCompressed.Update(dt);
			LastUpdate = realtimeSinceStartup;
		}
	}
}
