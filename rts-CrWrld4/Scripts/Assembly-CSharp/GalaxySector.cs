using System;
using TMPro;
using UnityEngine;

public class GalaxySector : MonoBehaviour
{
	public GameObject galaxySystemContainer;

	public GalaxySystem[] galaxySystems;

	public GalaxyMissionPanel galaxyMissionPanel;

	public GameObject systemInfo;

	public TextMeshProUGUI systemTitle;

	public GameObject galaxyNavGrid;

	public GameObject showSectorMapButton;

	public TextMeshProUGUI returnButtonText;

	public GameObject rotateInstruction;

	private GalaxySystem zoomedSystem;

	private float lastRotation;

	public GameSpace.CATEGORY category;

	public bool canRotate;

	[NonSerialized]
	public int systemShowing;

	private bool dragRotate;

	private float dragPosition;

	private float dragRotation;

	private float ROTATE_RATE;

	private Quaternion savedCameraRotation;

	private int lastSystem;

	public virtual void Awake()
	{
	}

	public virtual void Start()
	{
	}

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
	}

	private void Update()
	{
	}

	public virtual void Show(bool zoomToLast)
	{
	}

	public void RotateRight()
	{
	}

	public void RotateLeft()
	{
	}

	private void ShowTitles(bool show)
	{
	}

	private void ShowSystem(GalaxySystem gs, int pos = -1)
	{
	}

	public void ShowSystemAndChangeRotation(int pos)
	{
	}

	public void ShowSystem(int pos)
	{
	}

	public void OnSectorMapClicked()
	{
	}

	public void OnReturnClicked()
	{
	}

	public static Vector3 GetBasePixelUnderMouse()
	{
		return default(Vector3);
	}
}
