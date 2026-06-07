using System.Text;
using Assets.Scripts.Craft;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.UI.Dialogs
{
	public class PerformanceStatsDialogScript : PanelDialogScript
	{
		private ProfilerRecorder _batchesRecorder;

		private FloatAverage _cpuTime = new FloatAverage(10);

		private FrameTiming[] _frameTimings = new FrameTiming[1];

		private FloatAverage _gpuTime = new FloatAverage(10);

		private int _restoreTargetFramerate;

		private int _restoreVsyncCount;

		private ProfilerRecorder _shadowCastersRecorder;

		private TextWidget _text;

		private ProfilerRecorder _trisRecorder;

		private ProfilerRecorder _vertsRecorder;

		public override bool IsModal => false;

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_text = widget.FindWidget<TextWidget>("text");
		}

		protected void OnDisable()
		{
			QualitySettings.vSyncCount = _restoreVsyncCount;
			Application.targetFrameRate = _restoreTargetFramerate;
			_batchesRecorder.Dispose();
			_trisRecorder.Dispose();
			_vertsRecorder.Dispose();
			_shadowCastersRecorder.Dispose();
		}

		protected void OnEnable()
		{
			_restoreVsyncCount = QualitySettings.vSyncCount;
			_restoreTargetFramerate = Application.targetFrameRate;
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = -1;
			_batchesRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Batches Count");
			_trisRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Triangles Count");
			_vertsRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Vertices Count");
			_shadowCastersRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Shadow Casters Count");
		}

		protected virtual void Update()
		{
			StringBuilder stringBuilder = new StringBuilder();
			FrameTimingManager.CaptureFrameTimings();
			if (FrameTimingManager.GetLatestTimings(1u, _frameTimings) != 0)
			{
				_cpuTime.Add((float)_frameTimings[0].cpuFrameTime);
				_gpuTime.Add((float)_frameTimings[0].gpuFrameTime);
			}
			stringBuilder.AppendLine($"CPU Time: {_cpuTime.Value:n1} ms");
			stringBuilder.AppendLine($"GPU Time: {_gpuTime.Value:n1} ms");
			stringBuilder.AppendLine("Batches: " + Utilities.FriendlyLargeNumber(_batchesRecorder.LastValue));
			stringBuilder.AppendLine("Tris: " + Utilities.FriendlyLargeNumber(_trisRecorder.LastValue));
			stringBuilder.AppendLine("Verts: " + Utilities.FriendlyLargeNumber(_vertsRecorder.LastValue));
			stringBuilder.AppendLine("Shadow Casters: " + Utilities.FriendlyLargeNumber(_shadowCastersRecorder.LastValue));
			stringBuilder.AppendLine();
			_text.Text = stringBuilder.ToString();
		}

		private void OnCloseButtonClicked(Widget widget)
		{
			Close();
		}
	}
}
