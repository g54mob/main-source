using UnityEngine;

namespace PG
{
	public abstract class IGroundEntity : MonoBehaviour
	{
		public abstract GroundConfig GetGroundConfig(Vector3 position);
	}
}
