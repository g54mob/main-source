using UnityEngine;

namespace Brewery.Localization
{
	public class LocBinderAutoAttach : MonoBehaviour
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void AutoAttach()
		{
		}

		private static void AttachToAllUIDocuments()
		{
		}
	}
}
