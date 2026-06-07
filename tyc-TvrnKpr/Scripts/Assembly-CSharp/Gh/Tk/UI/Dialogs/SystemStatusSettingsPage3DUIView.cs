using System;
using System.Collections.Generic;

namespace Gh.Tk.UI.Dialogs
{
	public class SystemStatusSettingsPage3DUIView : SettingsPage3DUIView
	{
		public SystemStatusVisual3DUIView tabStatusVisual;

		private List<Action> _updateActions;

		private List<Func<SystemStatus.PerformanceState>> _systemStatusItems;

		private bool _isDirty;

		private float _updateDelayDuration;

		protected override void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public override void Init()
		{
		}

		private void MarkDirty(object sender, ValueChangedEventArgs<string> e)
		{
		}

		private void ColliderResized(object sender, EventArgs e)
		{
		}

		public override void Open()
		{
		}

		protected override void Update()
		{
		}

		public void UpdateTabStatusVisual()
		{
		}
	}
}
