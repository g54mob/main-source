using System;
using UnityEngine;

namespace DV.VR
{
	public class VREventSystemProblemDebugger : MonoBehaviour
	{
		private void OnDisable()
		{
			if (!UnloadWatcher.isUnloading)
			{
				Debug.LogError("VRTK Event system got disabled at runtime! Stacktrace: ");
				Debug.LogError(Environment.StackTrace);
			}
		}
	}
}
