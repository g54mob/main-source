using UnityEngine;

namespace Brewery.Face
{
	public abstract class FaceSource : MonoBehaviour
	{
		[Header("Face Source")]
		[SerializeField]
		protected int priority;

		[SerializeField]
		[Range(0f, 1f)]
		protected float maxWeight;

		[SerializeField]
		protected float fadeInSpeed;

		[SerializeField]
		protected float fadeOutSpeed;

		protected float currentWeight;

		protected FaceDriver driver;

		private int _seenCacheVersion;

		public int Priority => 0;

		public float CurrentWeight => 0f;

		public bool IsActive => false;

		public virtual string DebugName => null;

		internal void Bind(FaceDriver d)
		{
		}

		public void Tick(FaceFrame frame, float dt)
		{
		}

		protected abstract float ComputeTargetWeight(float dt);

		protected abstract void Sample(FaceFrame frame, float dt, float sourceFade);

		protected virtual void OnDriverCacheRefreshed()
		{
		}

		protected int Resolve(string blendshape)
		{
			return 0;
		}
	}
}
