using UnityEngine;

namespace Crosstales.Common.Util
{
	public class CTHelper : MonoBehaviour
	{
		public static CTHelper Instance { get; private set; }

		[RuntimeInitializeOnLoadMethod]
		private static void initialize()
		{
		}

		[RuntimeInitializeOnLoadMethod]
		private static void create()
		{
		}

		private void Awake()
		{
		}

		private void OnApplicationQuit()
		{
		}
	}
}
