using System;
using System.Reflection;
using Unity.Profiling;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	[Serializable]
	[Obfuscation(Exclude = true)]
	public class UnityProfilerProvider : APerformanceProvider
	{
		public const string CName = "Unity Profiler";

		[SerializeField]
		public string Category = ProfilerCategory.Audio.Name;

		[SerializeField]
		public string StatusName = string.Empty;

		[SerializeField]
		public bool IsCustomStatus;

		private ProfilerRecorder recorder;

		public override string Name => "Unity Profiler";

		public override bool IsSupported => true;

		public override string Unit => "";

		protected override void Awake()
		{
			base.Awake();
			ProfilerCategory category = new ProfilerCategory(Category);
			recorder = ProfilerRecorder.StartNew(category, StatusName);
		}

		protected override float GetNextValue()
		{
			return recorder.LastValue;
		}

		public override void Refresh()
		{
			base.Refresh();
			recorder.Stop();
			recorder.Dispose();
			ProfilerCategory category = new ProfilerCategory(Category);
			recorder = ProfilerRecorder.StartNew(category, StatusName);
		}
	}
}
