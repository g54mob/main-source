using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public abstract class SgtProcedural : MonoBehaviour
	{
		public enum GenerateType
		{
			Automatically = 0,
			WithRandomSeed = 1,
			WithFixedSeed = 2,
			Manually = 3
		}

		public GenerateType Generate;

		[SgtSeed]
		public int Seed;

		public void GenerateWith(int seed)
		{
		}

		public void GenerateNow()
		{
		}

		protected abstract void DoGenerate();

		protected virtual void Awake()
		{
		}
	}
}
