namespace GAudio
{
	public class GATActiveSampleBank : GATSampleBank
	{
		private GATProcessedSamplesCache _cache;

		public virtual IGATProcessedSample GetProcessedSample(string sampleName, GATEnvelope envelope, double pitch = 1.0)
		{
			return _cache.GetProcessedSample(_samplesByName[sampleName], pitch, envelope);
		}

		public virtual IGATProcessedSample GetProcessedSample(int indexInBank, GATEnvelope envelope, double pitch = 1.0)
		{
			return _cache.GetProcessedSample(_allSamples[indexInBank], pitch, envelope);
		}

		public void FlushCacheForEnvelope(GATEnvelope envelope)
		{
			if (_cache != null)
			{
				_cache.FlushCacheForEnvelope(envelope);
			}
		}

		public override void AddSample(GATData data, string sampleName)
		{
			base.AddSample(data, sampleName);
			if (_cache == null)
			{
				_cache = new GATProcessedSamplesCache(_totalCapacity);
			}
			_cache.AddSample(data);
		}

		public override void RemoveSample(string name)
		{
			GATData sample = _samplesByName[name];
			base.RemoveSample(name);
			_cache.RemoveSample(sample);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			CleanUpCache();
		}

		protected virtual void CleanUpCache()
		{
			if (_cache != null)
			{
				_cache.Dispose();
				_cache = null;
			}
		}
	}
}
