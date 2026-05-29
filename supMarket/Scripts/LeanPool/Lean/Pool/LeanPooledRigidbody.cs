using UnityEngine;

namespace Lean.Pool
{
	[RequireComponent(typeof(Rigidbody))]
	[HelpURL("https://carloswilkes.com/Documentation/LeanCommon#LeanPool#LeanPooledRigidbody")]
	[AddComponentMenu("Lean/Pool/Lean Pooled Rigidbody")]
	public class LeanPooledRigidbody : MonoBehaviour, IPoolable
	{
		public void OnSpawn()
		{
		}

		public void OnDespawn()
		{
		}
	}
}
