using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FingerprintScannerController : MonoBehaviour
{
	[Serializable]
	public class Print
	{
		public enum PrintType
		{
			fingerPrint = 0,
			footPrint = 1
		}

		[Header("Serialized")]
		public Vector3 worldPos;

		public Vector3 normal;

		public PrintType type;

		public RoomConfiguration.PrintsSource source;

		[NonSerialized]
		[Header("Non-Serialized")]
		public Transform parentTranform;

		[NonSerialized]
		public NewRoom room;

		[NonSerialized]
		public Interactable interactable;

		[NonSerialized]
		public FurnitureLocation furniture;

		[NonSerialized]
		public Human dynamicOwner;

		public Human GetOwner()
		{
			return null;
		}
	}

	[Header("Components")]
	public TextMeshPro screenText;

	public Transform progressBar;

	public Transform beamRoot;

	public MeshRenderer screen;

	public Transform printTransform;

	public GameObject pixelPrefab;

	private List<GameObject> pixels;

	public List<GameObject> blockedPixelsActive;

	public GameObject screenLight;

	public Light scanLight;

	public bool isOn;

	public float screenOnDelay;

	[Header("Audio")]
	public AudioEvent progressLoop;

	public AudioEvent detect;

	public AudioEvent detectExisting;

	public AudioEvent success;

	public AudioEvent hoverOff;

	private AudioController.LoopingSoundInfo progressLoopEvent;

	[Header("Prints")]
	[Tooltip("List of valid objects being looked at")]
	public List<Transform> lookingAt;

	[Tooltip("Spawned prints")]
	public List<PrintController> spawnedPrints;

	[Tooltip("Hovered over this print")]
	public PrintController hoverPrint;

	[Tooltip("Hovered over this footprint")]
	public FootprintController hoverFootPrint;

	[Tooltip("How fast a print is scanned (seconds)")]
	public float scanSpeed;

	[Tooltip("Flash the screen")]
	private bool flashActive;

	private float flashSpeed;

	[ColorUsage(true, true)]
	public Color flashColour;

	private int cycle;

	private float flashProgress;

	private float flashF;

	private int flashRepeat;

	private Dictionary<Transform, HashSet<Print>> cachedStaticPrints;

	private Dictionary<Interactable, HashSet<Print>> cachedDynamicPrints;

	private void Start()
	{
	}

	public void SetOn(bool val)
	{
	}

	private void OnDestroy()
	{
	}

	private void FixedUpdate()
	{
	}

	public void Flash(int newRepeat, bool colourOverride, Color colour = default(Color), float speed = 10f)
	{
	}

	public void OnHoverOnNewPrint()
	{
	}

	private HashSet<Print> GetDynamicPrints(InteractableController interactable)
	{
		return null;
	}

	private HashSet<Print> GetPrintPoints(Transform checkTransform)
	{
		return null;
	}

	private List<Vector3> GetPrintLocationsOnMeshNonDynamic(MeshFilter meshFilter, float printDensityPerUnit, out List<Vector3> normals, bool useHeightThreshold = false, NewRoom heightThresholdRoom = null)
	{
		normals = null;
		return null;
	}

	private List<Vector3> GetPrintLocationsOnMesh(MeshFilter meshFilter, int prints, out List<Vector3> normals, bool useHeightThreshold = false, NewRoom heightThresholdRoom = null, List<string> seeds = null)
	{
		normals = null;
		return null;
	}

	private float[] GetTriSizes(int[] tris, Vector3[] verts)
	{
		return null;
	}

	private void StartPrintScannerHaptics()
	{
	}

	private void StopPrintScannerHaptics()
	{
	}
}
