using UnityEngine;

namespace Pug.UnityExtensions
{
	public class DestroyObjectOnPlay : MonoBehaviour
	{
		private void Awake()
		{
			if (Application.isPlaying)
			{
				Object.DestroyImmediate(base.gameObject);
			}
		}
	}
}
