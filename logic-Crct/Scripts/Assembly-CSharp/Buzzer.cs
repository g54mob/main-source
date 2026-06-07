using System.Diagnostics;
using Simulation;
using UnityEngine;

public class Buzzer : BaseComponent, IAudioComponent
{
	public Transform[] pinRayTrs;

	public AudioSource audioSource;

	public BuzzerElm bElm;

	public int type;

	public float freq;

	public float maxCurrent;

	public float capacitance;

	private int sampleRate;

	private int timeIndex;

	public float waveLengthInSeconds;

	private float sampleT;

	private float[] clipSamples;

	public Stopwatch filterSw;

	public long filterTime;

	public bool readingBuffer;

	private float dist;

	public float volume;

	public bool active;

	public float frequency;

	public float gain;

	private float increment;

	private float phase;

	private bool pauseWrite;

	public float[] buffer;

	public int writePos;

	public int readPos;

	private int readStep;

	private int readOffset;

	private int lastReadPos;

	private int minDistance;

	private int safeDistance;

	private float avgBufferDistance;

	private float underrunsAvg;

	private bool underrun;

	private int bufferGap;

	private GUIStyle debugLabelStyle;

	private bool waitBuffer;

	private int lastWritePos;

	private int noWriteCount;

	private TiePointID[] tempTiePointIDs { get; set; }

	private void FixedUpdate()
	{
	}

	public override void TickUpdate()
	{
	}

	public int CalculateWrapAroundDistance(int writePosition, int readPosition)
	{
		return 0;
	}

	public int CalculateReadPosition(int offset)
	{
		return 0;
	}

	public int WrapAroundShift(int startPosition, int offset)
	{
		return 0;
	}

	public void OnGUI()
	{
	}

	public void OnDestroy()
	{
	}

	public void RefreshRead()
	{
	}

	public void OnAudioReadSamples(float[] data)
	{
	}

	public override void Awake()
	{
	}

	public override object[] VarData()
	{
		return null;
	}

	public override object[] ReturnSaveData()
	{
		return null;
	}

	public override void ProcessVarData(object[] data)
	{
	}

	public override void ProcessSaveData(object[] data)
	{
	}

	public override bool ValuesChanged(object[] data)
	{
		return false;
	}

	public override void BeginMove()
	{
	}

	public override void CompleteMove()
	{
	}

	public override void CompleteCreate()
	{
	}

	public override void FinishPlacement()
	{
	}

	public override void ParentCalledUpdate(params object[] args)
	{
	}

	public override bool PositionValid(BaseComponent c)
	{
		return false;
	}
}
