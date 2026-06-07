using System;
using System.Collections.Generic;
using UnityEngine;

namespace Coherence.Runtime
{
	internal class Updater : MonoBehaviour
	{
		private static Updater instance;

		private readonly List<WeakReference<IUpdatable>> updateList;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		internal static void Init()
		{
		}

		internal static void RegisterForUpdate(IUpdatable item)
		{
		}

		internal static void DeregisterForUpdate(IUpdatable item)
		{
		}

		internal static void UpdateInstance()
		{
		}

		private void Update()
		{
		}
	}
}
