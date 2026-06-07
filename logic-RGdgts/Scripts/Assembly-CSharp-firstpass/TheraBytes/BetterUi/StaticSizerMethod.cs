using System;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class StaticSizerMethod
	{
		[SerializeField]
		private string assemblyName;

		[SerializeField]
		private string typeName;

		[SerializeField]
		private string methodName;

		public float Invoke(Component caller, Vector2 optimizedResolution, Vector2 actualResolution, float optimizedDpi, float actualDpi)
		{
			return 0f;
		}
	}
}
