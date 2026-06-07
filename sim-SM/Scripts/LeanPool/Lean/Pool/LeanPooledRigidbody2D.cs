using UnityEngine;

namespace Lean.Pool
{
	[RequireComponent(typeof(Rigidbody2D))]
	[HelpURL("https://carloswilkes.com/Documentation/LeanCommon#LeanPool#LeanPooledRigidbody2D")]
	[AddComponentMenu("Lean/Pool/Lean Pooled Rigidbody2D")]
	public class LeanPooledRigidbody2D : MonoBehaviour, IPoolable
	{
		public void OnSpawn()
		{
		}

		public void OnDespawn()
		{
		}
	}
}
