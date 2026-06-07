using UnityEngine;

namespace CTS
{
	public class DeleteOnBuild : MonoBehaviour
	{
		private void Awake()
		{
			Object.Destroy(base.gameObject);
		}
	}
}
