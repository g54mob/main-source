using System;
using UnityEngine;

namespace Lean.Pool.Examples
{
	[AddComponentMenu("Lean/Pool/Lean Pool Debugger")]
	[HelpURL("https://carloswilkes.com/Documentation/LeanCommon#LeanPool#LeanPoolDebugger")]
	[RequireComponent(typeof(Rigidbody))]
	public class LeanPoolDebugger : MonoBehaviour
	{
		[SerializeField]
		private LeanGameObjectPool cachedPool;

		[NonSerialized]
		private bool skip;

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void OnApplicationQuit()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		private bool Exists()
		{
			return false;
		}
	}
}
