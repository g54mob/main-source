using System.Collections.Generic;
using System.Reflection;
using GUPS.EasyPerformanceMonitor.Singleton;
using GUPS.EasyPerformanceMonitor.Window;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor
{
	[Obfuscation(Exclude = true)]
	public class PerformanceMonitor : PersistentSingleton<PerformanceMonitor>
	{
		[SerializeField]
		private bool onlyInDevelopmentBuild = true;

		[SerializeField]
		private bool showOnStart = true;

		protected override void Awake()
		{
			base.Awake();
			if (onlyInDevelopmentBuild)
			{
				base.gameObject.SetActive(value: false);
			}
			if (!showOnStart)
			{
				GetMonitorWindows().ForEach(delegate(MonitorWindow var_MonitorWindow)
				{
					var_MonitorWindow.Toggle(_Show: false);
				});
			}
		}

		public List<MonitorWindow> GetMonitorWindows()
		{
			return new List<MonitorWindow>(GetComponentsInChildren<MonitorWindow>());
		}
	}
}
