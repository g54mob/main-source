using System.Collections;
using Coherence.Toolkit.Internal;
using UnityEngine;

namespace Coherence.Toolkit
{
	internal sealed class CoroutineRunner : CoherenceSharedBehaviour<CoroutineRunner>
	{
		public new static Coroutine StartCoroutine(IEnumerator coroutine)
		{
			return null;
		}
	}
}
