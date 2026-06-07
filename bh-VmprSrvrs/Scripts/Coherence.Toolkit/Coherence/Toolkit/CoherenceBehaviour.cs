using System.Runtime.CompilerServices;
using UnityEngine;

namespace Coherence.Toolkit
{
	public abstract class CoherenceBehaviour : MonoBehaviour
	{
		internal delegate void ResetDelegate(CoherenceBehaviour behaviour);

		internal static event ResetDelegate OnReset
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected virtual void Reset()
		{
		}
	}
}
