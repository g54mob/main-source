using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using UnityEngine;

namespace NSMedieval
{
	public static class DebugEventTypeId
	{
		private static Dictionary<byte, Type> idToType;

		[RuntimeInitializeOnLoadMethod]
		public static void OnDomainReload()
		{
			idToType = null;
		}

		public static IDebugEvent CreateObject(byte typeId)
		{
			if (idToType == null)
			{
				idToType = new Dictionary<byte, Type>();
				Type interfaceType = typeof(IDebugEvent);
				foreach (Type item in from t in Assembly.GetExecutingAssembly().GetTypes()
					where interfaceType.IsAssignableFrom(t) && !t.IsInterface
					select t)
				{
					IDebugEvent debugEvent = (IDebugEvent)Activator.CreateInstance(item);
					if (!idToType.TryAdd(debugEvent.TypeId, item))
					{
						bool isEnabled;
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(112, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugEventTracker\\DebugEventTypeId.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Duplicate TypeId for debug event '");
							messageBuilder.AppendFormatted(item.Name);
							messageBuilder.AppendLiteral("' - TypeId must be unique among all types that implement IDebugEvent interface");
						}
						Log.Error(messageBuilder);
						return null;
					}
				}
				if (idToType.Count > 256)
				{
					Log.Error("More than 256 distinct debug event types, this is not supported", "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugEventTracker\\DebugEventTypeId.cs");
					return null;
				}
			}
			return (IDebugEvent)Activator.CreateInstance(idToType[typeId]);
		}
	}
}
