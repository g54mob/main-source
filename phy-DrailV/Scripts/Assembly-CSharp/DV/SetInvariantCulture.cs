using System.Globalization;
using System.Threading;
using UnityEngine;

namespace DV
{
	public static class SetInvariantCulture
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void SetCulture()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
			CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
		}
	}
}
