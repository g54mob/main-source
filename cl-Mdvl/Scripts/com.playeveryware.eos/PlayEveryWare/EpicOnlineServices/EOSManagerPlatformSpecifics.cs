using System;
using UnityEngine;

namespace PlayEveryWare.EpicOnlineServices
{
	public class EOSManagerPlatformSpecifics
	{
		private static IEOSManagerPlatformSpecifics s_platformSpecifics;

		public static IEOSManagerPlatformSpecifics Instance => s_platformSpecifics;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			s_platformSpecifics = null;
		}

		public static void SetEOSManagerPlatformSpecificsInterface(IEOSManagerPlatformSpecifics platformSpecifics)
		{
			if (s_platformSpecifics != null)
			{
				throw new Exception(string.Format("Trying to set the EOSManagerPlatformSpecifics twice: {0} => {1}", s_platformSpecifics.GetType().Name, (platformSpecifics == null) ? "NULL" : platformSpecifics.GetType().Name));
			}
			s_platformSpecifics = platformSpecifics;
		}
	}
}
