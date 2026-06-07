using System.Diagnostics;
using System.Threading;
using Simulation;
using UnityEngine;
using UnityEngine.UI;

public class CircuitSimulation : MonoBehaviour
{
	public enum Status
	{
		Running = 0,
		Paused = 1,
		Error = 2
	}

	private static CircuitSimulation inst;

	public bool matrixPointers;

	public double rCondTol;

	public bool convergeTest;

	public bool directMatrix;

	public bool multiThread;

	public bool refactor;

	public bool nodeMeshMap;

	public bool preProcessed;

	public bool _KluMode;

	private static double[] _gMinCache;

	[Header("Speed Display")]
	public Text hzText;

	private float hz;

	[Header("Settings")]
	public Slider freqSlider;

	public Text freqDisplay;

	public int freq;

	public Slider tStepSlider;

	public Text tStepDisplay;

	public Text tStepDisplayUnit;

	public Text realtimeValueText;

	public float tStep;

	public AnimationCurve tStepSliderProfile;

	public AnimationCurve tStepSliderProfileInverse;

	public AnimationCurve freqSliderProfile;

	public AnimationCurve freqSliderProfileInverse;

	public Text titleText;

	public bool autoThrottle;

	public Toggle autoThrToggle;

	private static int frameSteps;

	private GUIStyle debugLabelStyle;

	private float realtimeValue;

	public int missedFrames;

	public static float avgMissedFrames;

	private float adjT;

	private Stopwatch sw;

	private int simStepTime;

	private bool endTick;

	[Header("Status")]
	public Image statusImage;

	public Sprite[] statusImages;

	public Color[] statusColors;

	public bool isSimulating;

	public Text statusText;

	public string[] statusMsg;

	public string[] btnMsg;

	public Text speedText;

	public Text buttonText;

	private Status status;

	private float currentSpeed;

	private float missT;

	public float missTolerance;

	private bool throttledLast;

	private long elapsedT;

	private int missFrames;

	private double tickT;

	private long beforeT;

	private Thread simThread;

	private static bool canSim;

	public static double CircuitTime;

	public static float simFrequency;

	public static bool MatrixPointers => false;

	public static double RCondTol => 0.0;

	public static bool ConvergeTest => false;

	public static bool DirectMatrix => false;

	public static bool MultiThread => false;

	public static bool Refactor => false;

	public static bool NodeMeshMap => false;

	public static bool PreProcessed => false;

	public static bool Simulating => false;

	public static bool KluMode => false;

	public static double GMinValue => 0.0;

	public static int Frequency => 0;

	public static float TimeStep => 0f;

	public static float Realtime
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public static bool Throttling
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static Status SimStatus
	{
		get
		{
			return default(Status);
		}
		set
		{
		}
	}

	private void PopulateGMinCache()
	{
	}

	public void OnDestroy()
	{
	}

	public void OnDisable()
	{
	}

	private void Awake()
	{
	}

	public static void Defaults()
	{
	}

	public static string IPC_SettingsRequest()
	{
		return null;
	}

	public static void ApplySettings(int f, float ts, float r, bool t)
	{
	}

	public static void IPC_UpdateSettings(string str)
	{
	}

	public void ToggleThrottle()
	{
	}

	public void OnGUI()
	{
	}

	private void UpdateTitleText(bool throttling = false)
	{
	}

	public static int FrequencyEvaluate(float val)
	{
		return 0;
	}

	public void UpdateFrequency()
	{
	}

	private void ThrottleFrequency()
	{
	}

	public void UpdateTimeStep()
	{
	}

	public void ResetDefaults()
	{
	}

	public static void Set(int f, float t, bool a)
	{
	}

	private void Update()
	{
	}

	private void Start()
	{
	}

	public void AdjustSimSpeed(Slider slider)
	{
	}

	public void ButtonPressed()
	{
	}

	private void Analyzed()
	{
	}

	public static void ErrorState()
	{
	}

	private void Error()
	{
	}

	public static void Pause()
	{
	}

	public static void Reset()
	{
	}

	public static VoltageInput CreateDCSource(BaseComponent c, float v)
	{
		return null;
	}

	public static VoltageInput CreateACSource(BaseComponent c, float v, float f, int mode)
	{
		return null;
	}

	public static T CreateElm<T>(BaseComponent c) where T : class, ICircuitModel
	{
		return null;
	}

	public static TransistorGeneric CreateTransistorElm(BaseComponent c, int t, double beta = 100.0)
	{
		return null;
	}

	public static Simulation.MOSFET CreateMOSFETElm(BaseComponent c, int t)
	{
		return null;
	}

	public static SiliconRectifierModel CreateSCRElm(BaseComponent c)
	{
		return null;
	}

	public static Simulation.Resistor CreateResistorElm(float o, BaseComponent c)
	{
		return null;
	}

	public static DIPSwitchSingle CreateSingleDipSwitch(BaseComponent c)
	{
		return null;
	}

	public static ZenerElm CreateZenerElm(double z, double fV, BaseComponent c)
	{
		return null;
	}

	public static Simulation.Capacitor CreateCapacitorElm(BaseComponent c, double f, bool trap, bool pol)
	{
		return null;
	}

	public static LEDElement CreateLEDElm(BaseComponent c, double fv)
	{
		return null;
	}

	public static void Remove(CircuitModel elm)
	{
	}

	public static void Connect(Circuit.Lead A, Circuit.Lead B)
	{
	}

	private void FixedUpdate()
	{
	}
}
