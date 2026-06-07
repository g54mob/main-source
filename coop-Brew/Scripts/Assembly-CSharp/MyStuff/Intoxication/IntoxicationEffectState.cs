using Brewery.Core;

namespace MyStuff.Intoxication
{
	public class IntoxicationEffectState
	{
		public BrewTag tag;

		public IntoxicationTagProfile profile;

		public float currentIntensity;

		public float remainingTime;

		public float phaseTimer;

		public IntoxicationPhase phase;

		public int drinkCount;

		private float _smoothStackScale;

		private static readonly float[] StackScales;

		public const int MaxDrinkStack = 3;

		public float TargetStackScale => 0f;

		public float StackScale => 0f;

		public float TotalDuration => 0f;

		public bool IsFinished => false;

		public void Init()
		{
		}

		public void Refresh()
		{
		}

		private static float Smoothstep(float t)
		{
			return 0f;
		}

		public void Tick(float dt)
		{
		}
	}
}
