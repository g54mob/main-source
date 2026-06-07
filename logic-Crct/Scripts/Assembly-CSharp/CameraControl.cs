using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
	[Header("Viewport Clipping")]
	public bool clipViewport;

	public float clipTop;

	[Header("Movement")]
	public float lookSpeed;

	public float translateSpeed;

	public float zoomSpeed;

	public float returnTime;

	public Vector3 homePos;

	public Vector3 homeRot;

	[Header("Shadow Quality")]
	public Light sceneLight;

	public Image[] checkMarksShadowQ;

	[Header("AA")]
	public Image AAcheckMark;

	private bool AA;

	[Header("AO")]
	public PostProcessProfile ppProfile;

	public Image AOcheckMark;

	private bool AO;

	[Header("Bloom")]
	public Image bloomcheckMark;

	private bool bloom;

	private bool rightClick;

	private bool returnHome;

	private bool wheelClick;

	private Vector3 initialRotation;

	private Vector3 initialPosition;

	private Vector3 targetRotation;

	private Vector3 targetPosition;

	private Vector3 initialMouse;

	private Vector3 pos;

	private float deltaMouseX;

	private float deltaMouseY;

	private float t;

	private Quaternion rot;

	public void ShadowQuality(int n)
	{
	}

	public void ToggleAA()
	{
	}

	public void ToggleAO()
	{
	}

	public void ToggleBloom()
	{
	}

	private void Awake()
	{
	}

	public void Home()
	{
	}

	private void Update()
	{
	}
}
