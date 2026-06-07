using Doozy.Engine.UI.Base;
using UnityEngine;

namespace Doozy.Engine.UI.Input
{
	[AddComponentMenu("Doozy/Input/Key To Action", 13)]
	[DefaultExecutionOrder(-100)]
	public class KeyToAction : MonoBehaviour
	{
		public UIAction Actions;

		public bool DebugMode;

		public InputData InputData;

		private bool DebugComponent => false;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void Execute()
		{
		}

		private static KeyToAction AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}
	}
}
