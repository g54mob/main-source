using System;
using System.Reflection;
using GUPS.EasyPerformanceMonitor.Observer;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	[Serializable]
	[Obfuscation(Exclude = true)]
	public class OperatingSystemProvider : AProvider<IProvidedData<string>>
	{
		public const string CName = "Operating System";

		public override string Name => "Operating System";

		public override bool IsSupported => true;

		protected virtual void Start()
		{
			if (!base.IsActive)
			{
				return;
			}
			string operatingSystem = SystemInfo.operatingSystem;
			foreach (IObserver<IProvidedData> observer in base.ObserverList)
			{
				observer.OnNext(new ProvidedData<string>(this, operatingSystem));
			}
		}
	}
}
