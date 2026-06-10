using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ComputerController : MonoBehaviour
{
	[Header("Components")]
	public MeshRenderer computerRenderer;

	public MeshRenderer screenRenderer;

	public GameObject screenLightContainer;

	public InteractableController ic;

	public Material lightOffMaterial;

	public Material lightOnMaterial;

	public Canvas osCanvas;

	public GraphicRaycaster raycaster;

	private PointerEventData m_PointerEventData;

	private EventSystem m_EventSystem;

	public RectTransform cursorRect;

	public Image cursorImage;

	public Transform printerParent;

	public LightController screenLight;

	public LayerMask screenMask;

	[Header("Operating System")]
	public CruncherAppPreset currentApp;

	public bool useCursor;

	public bool playerControlled;

	public bool appLoaded;

	public float appLoadProgress;

	public float appTimerProgress;

	public float timedLoading;

	public float timedLoadingDemand;

	public List<GameObject> spawnedContent;

	public Human loggedInAs;

	public float printTimer;

	public Vector3 printOutStartPos;

	public Vector3 printOutEndPos;

	private AudioController.LoopingSoundInfo loadLoop;

	[NonSerialized]
	public Interactable printedDocument;

	[Space(7f)]
	public ComputerOSUIComponent currentHover;

	private MeshCollider _screenCollider;

	public void Setup(InteractableController newController)
	{
	}

	private void OnDestroy()
	{
	}

	public void OnSwitchStateChange()
	{
	}

	public void OnPlayerControlChange()
	{
	}

	public void SetComputerApp(CruncherAppPreset newApp, bool forceUpdate = false)
	{
	}

	public void SetLoggedIn(Human newLogIn)
	{
	}

	public void OnAppLoaded()
	{
	}

	public void OnAppExit()
	{
	}

	public void EnableCursor(bool val)
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	public void SetTimedLoading(float forSeconds, float loadDemand = 0.33f)
	{
	}

	private void UpdateCursor()
	{
	}

	public Vector2 TexToCanvas(Vector2 texCoord)
	{
		return default(Vector2);
	}

	public void OnClickOnOSElement(ComputerOSUIComponent c)
	{
	}

	private void SetPlayerCrunchingDatabase(bool condition)
	{
	}
}
