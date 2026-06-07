using System;
using UnityEngine;

namespace DV.UI
{
	public abstract class ACanvasControllerProvider<T> : MonoBehaviour where T : Enum
	{
		public abstract bool IsVR();

		public abstract bool IsGameLoaded();

		public abstract void RepositionVRCanvas();

		public abstract bool ShouldTryToggle(T type);

		public abstract void Toggle(GameObject reference, T type, bool on);

		public abstract bool IsOn(GameObject reference, T type);

		public abstract void RequirePointer(bool on);

		public abstract void RequirePause(bool on);
	}
}
