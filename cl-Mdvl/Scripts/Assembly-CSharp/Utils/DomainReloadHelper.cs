using System;
using System.Reflection;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using UnityEngine;

namespace Utils
{
	public static class DomainReloadHelper
	{
		public static Action OnDomainReloadEvent;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnDomainReload()
		{
			if (OnDomainReloadEvent != null)
			{
				Delegate[] invocationList = OnDomainReloadEvent.GetInvocationList();
				foreach (Delegate obj in invocationList)
				{
					if ((object)obj != null)
					{
						bool isEnabled;
						FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(18, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Utils\\DomainReloadHelper.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral(" Calling method: ");
							messageBuilder.AppendFormatted(obj.GetMethodInfo().DeclaringType);
							messageBuilder.AppendLiteral(".");
							messageBuilder.AppendFormatted(obj.Method.Name);
						}
						Log.Trace(messageBuilder);
						obj.DynamicInvoke();
					}
				}
			}
			OnDomainReloadEvent = null;
		}
	}
}
