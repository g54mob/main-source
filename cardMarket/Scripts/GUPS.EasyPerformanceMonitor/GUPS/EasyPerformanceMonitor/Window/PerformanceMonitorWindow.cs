using System.Collections.Generic;
using System.Reflection;
using GUPS.EasyPerformanceMonitor.Provider;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Window
{
	[Obfuscation(Exclude = true)]
	public class PerformanceMonitorWindow : MonitorWindow
	{
		protected override void Start()
		{
			base.Start();
			foreach (Transform item in MonitorCanvas.transform)
			{
				GameObject gameObject = item.gameObject;
				if (new List<IProvider>(gameObject.GetComponentsInChildren<IProvider>()).TrueForAll((IProvider var_Provider) => !var_Provider.IsActive))
				{
					gameObject.SetActive(value: false);
				}
			}
			PlaceMonitorElements();
		}
	}
}
