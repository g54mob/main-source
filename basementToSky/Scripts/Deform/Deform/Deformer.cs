using Unity.Jobs;
using UnityEngine;

namespace Deform
{
	public abstract class Deformer : MonoBehaviour, IDeformer<MeshData>
	{
		public const bool COMPILE_SYNCHRONOUSLY = true;

		public const int DEFAULT_BATCH_COUNT = 64;

		public bool update = true;

		public virtual bool RequiresUpdatedBounds { get; }

		public abstract DataFlags DataFlags { get; }

		public virtual void PreProcess()
		{
		}

		public abstract JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle));

		public virtual bool CanProcess()
		{
			if (update && base.gameObject.activeInHierarchy)
			{
				return base.enabled;
			}
			return false;
		}
	}
}
