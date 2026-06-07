using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	[RequireComponent(typeof(Camera))]
	public class SetMainCamera : MonoBehaviour
	{
		private void Start()
		{
			if (RuntimeGlobals.RunningMode == ERunningMode.Menu && RuntimeGlobals.MainCamera == null)
			{
				RuntimeGlobals.MainCamera = GetComponent<Camera>();
			}
		}
	}
}
