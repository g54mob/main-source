using UnityEngine;

namespace Lean.Pool
{
	[HelpURL("https://carloswilkes.com/Documentation/LeanCommon#LeanPool#LeanPooledRigidbody")]
	[AddComponentMenu("Lean/Pool/Lean Pooled Rigidbody")]
	[RequireComponent(typeof(Rigidbody))]
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
