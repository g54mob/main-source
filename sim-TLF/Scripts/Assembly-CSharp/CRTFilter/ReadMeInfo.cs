using UnityEngine;

namespace CRTFilter
{
	public class ReadMeInfo : MonoBehaviour
	{
		private static bool _warned;

		private void Start()
		{
			if (_warned)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			_warned = true;
			Debug.LogWarning("Please read the installation instructions in README.md (Documentation folder) to properly configure CRT filter. Then you can safely remove this MonoBehaviour.");
		}
	}
}
