using UnityEngine;

namespace DV.Booklets.Testing
{
	public class GravityRemover : MonoBehaviour
	{
		private void Awake()
		{
			Physics.gravity = Vector3.zero;
		}
	}
}
