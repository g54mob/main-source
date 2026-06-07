public class SignalGenerator
{
	public enum SignalType
	{
		NONE = 0,
		SINE = 1,
		SQUARE = 2,
		TRIANGLE = 3,
		SAWTOOTH = 4,
		RANDOM = 5,
		CONSTANT = 6
	}

	private SignalType signalType;

	private float frequency;

	private float phase;

	private float amplitude;

	private float offset;

	private float invert;

	private float currentRandom;

	private int currentRandomSlot;

	public SignalType SigType
	{
		get
		{
			return default(SignalType);
		}
		set
		{
		}
	}

	public float Frequency
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float Phase
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float Amplitude
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float Offset
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool Invert
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public SignalGenerator(SignalType initialSignalType)
	{
	}

	public SignalGenerator()
	{
	}

	public float GetValue(float time)
	{
		return 0f;
	}

	public static float GetValue(float time, float frequency, float phase, bool invert, double randSeed, SignalType signalType)
	{
		return 0f;
	}
}
