using UnityEngine;

namespace Coherence.Toolkit
{
	public interface IHashable
	{
		Hash128 ComputeHash();
	}
}
