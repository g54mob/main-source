using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using GUPS.EasyPerformanceMonitor.Observer;
using GUPS.EasyPerformanceMonitor.Persistent;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	[Serializable]
	[Obfuscation(Exclude = true)]
	public abstract class APerformanceProvider : AProvider<PerformanceData>, IPerformanceProvider, IProvider, IObservable<IProvidedData>, IDisposable
	{
		[SerializeField]
		private bool isScaleAble;

		[SerializeField]
		private int scaleFactor = 1;

		[SerializeField]
		private string[] scaleSuffixes = new string[0];

		[SerializeField]
		private int historySize = 25;

		private float[] values = new float[0];

		private float valueMin;

		private float valueMean;

		private float valueMax;

		[SerializeField]
		private float fetchInterval = 0.1f;

		private float lastFetchTime;

		[SerializeField]
		private bool storeValuesInCsvFile;

		private CsvFileWriter csvFileWriter;

		public bool IsScaleAble => isScaleAble;

		public int ScaleFactor => scaleFactor;

		public string[] ScaleSuffixes => scaleSuffixes;

		public abstract string Unit { get; }

		protected override void Awake()
		{
			base.Awake();
			values = new float[historySize];
		}

		protected virtual void Update()
		{
			if (base.IsActive && Time.unscaledTime - lastFetchTime > fetchInterval)
			{
				lastFetchTime = Time.unscaledTime;
				Fetch();
			}
		}

		private void AddValue(float _Value)
		{
			float num = float.MaxValue;
			float num2 = 0f;
			float num3 = 0f;
			int num4 = 0;
			for (int i = 0; i < historySize; i++)
			{
				if (i < historySize - 1)
				{
					values[i] = values[i + 1];
				}
				else
				{
					values[i] = _Value;
				}
				if (values[i] < num)
				{
					num = values[i];
				}
				if (values[i] > num2)
				{
					num2 = values[i];
				}
				if (values[i] > 0f)
				{
					num3 += values[i];
					num4++;
				}
			}
			valueMin = num;
			valueMean = ((num4 > 0) ? (num3 / (float)num4) : 0f);
			valueMax = num2;
			if (storeValuesInCsvFile)
			{
				if (csvFileWriter == null)
				{
					DateTime now = DateTime.Now;
					now.AddSeconds(0f - Time.realtimeSinceStartup);
					string text = now.ToString("yyyy.MM.dd_HH.mm.ss");
					string path = Path.Combine(Application.persistentDataPath, text + "_" + Name + ".csv");
					csvFileWriter = new CsvFileWriter(path);
				}
				Task.Run(async delegate
				{
					await csvFileWriter.AppendAsync(_Value);
				});
			}
		}

		protected abstract float GetNextValue();

		private void Fetch()
		{
			float nextValue = GetNextValue();
			AddValue(nextValue);
			PerformanceData performanceData = new PerformanceData(this, nextValue, valueMin, valueMean, valueMax, historySize);
			foreach (IObserver<IProvidedData> observer in base.ObserverList)
			{
				observer.OnNext(performanceData);
			}
		}

		public virtual void Refresh()
		{
		}
	}
}
