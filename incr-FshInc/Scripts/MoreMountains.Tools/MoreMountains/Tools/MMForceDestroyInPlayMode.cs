using UnityEngine;

namespace MoreMountains.Tools
{
	public class MMForceDestroyInPlayMode : MonoBehaviour
	{
		private void Awake()
		{
			if (Application.isPlaying)
			{
				Delete();
			}
		}

		private void Delete()
		{
			Object.DestroyImmediate(base.gameObject);
		}
	}
}
