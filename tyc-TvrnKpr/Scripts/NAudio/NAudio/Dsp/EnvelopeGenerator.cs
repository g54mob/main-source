namespace NAudio.Dsp
{
	public class EnvelopeGenerator
	{
		public enum EnvelopeState
		{
			Idle = 0,
			Attack = 1,
			Decay = 2,
			Sustain = 3,
			Release = 4
		}

		private EnvelopeState state;

		private float output;

		private float attackRate;

		private float decayRate;

		private float releaseRate;

		private float attackCoef;

		private float decayCoef;

		private float releaseCoef;

		private float sustainLevel;

		private float targetRatioAttack;

		private float targetRatioDecayRelease;

		private float attackBase;

		private float decayBase;

		private float releaseBase;

		public float AttackRate
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float DecayRate
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ReleaseRate
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float SustainLevel
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public EnvelopeState State => default(EnvelopeState);

		private static float CalcCoef(float rate, float targetRatio)
		{
			return 0f;
		}

		private void SetTargetRatioAttack(float targetRatio)
		{
		}

		private void SetTargetRatioDecayRelease(float targetRatio)
		{
		}

		public float Process()
		{
			return 0f;
		}

		public void Gate(bool gate)
		{
		}

		public void Reset()
		{
		}

		public float GetOutput()
		{
			return 0f;
		}
	}
}
