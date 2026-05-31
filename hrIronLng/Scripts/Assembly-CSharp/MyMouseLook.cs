using Rewired;
using UnityEngine;

public class MyMouseLook : MonoBehaviour
{
	public struct MouselookData
	{
		public Vector3 StoredRotation;
	}

	public GameObject mycont;

	[HideInInspector]
	private MyCharacterControllerScript contscript;

	[HideInInspector]
	public GameObject MController;

	public float sensitivity = 1f;

	public int inversion = -1;

	public int maxrot = 90;

	[HideInInspector]
	public Vector3 currentrotation;

	[HideInInspector]
	public Vector3 rotationstorage;

	[HideInInspector]
	public bool lockcursor = true;

	public float RumbleAmount;

	private Vector3 RumbleVector;

	public float RumbleDecrease;

	private PlayerEventScript EventScript;

	private Camera MyCam;

	private PersistScript Persist;

	private InteractScript Inter;

	private Player player;

	private MouselookData MyData;

	private void Awake()
	{
		player = ReInput.players.GetPlayer(0);
	}

	private void Start()
	{
		EventScript = GameObject.Find("PlayerEventManager").GetComponent<PlayerEventScript>();
		contscript = mycont.GetComponent<MyCharacterControllerScript>();
		Inter = GetComponent<InteractScript>();
		rotationstorage = new Vector3(base.transform.eulerAngles.x, contscript.transform.eulerAngles.y, base.transform.eulerAngles.z);
		MyCam = GetComponent<Camera>();
		_ = (bool)GameObject.Find("GameSettings");
		Persist = GameObject.Find("PERSIST").GetComponent<PersistScript>();
		if (Persist.fov > 1)
		{
			sensitivity = Persist.sensitivity;
			if (Persist.invert)
			{
				inversion = 1;
			}
			else
			{
				inversion = -1;
			}
			MyCam.fieldOfView = Persist.fov;
		}
	}

	private void Update()
	{
		DoCursorLock();
		RotateBasedOnInput(ConsiderMouse: true);
		RumbleAmount -= Time.deltaTime * RumbleDecrease;
		if (RumbleAmount < 0f)
		{
			RumbleAmount = 0f;
		}
	}

	private void FixedUpdate()
	{
		RumbleVector = new Vector3(Random.Range(0f - RumbleAmount, RumbleAmount), Random.Range(0f - RumbleAmount, RumbleAmount), 0f);
		RotateBasedOnInput(ConsiderMouse: false);
		RumbleVector = Vector3.zero;
	}

	private void RotateBasedOnInput(bool ConsiderMouse)
	{
		if (lockcursor && Inter.ExitPrompt.alpha != 1f && !EventScript.MyData.DoingFirstPause)
		{
			float num = 0f;
			float num2 = 0f;
			if (ConsiderMouse)
			{
				float num3 = player.GetAxis("JoyX") * Time.deltaTime * 100f;
				float num4 = player.GetAxis("JoyY") * Time.deltaTime * 100f;
				float axis = player.GetAxis("Mouse X");
				float axis2 = player.GetAxis("Mouse Y");
				num = (axis + num3) * sensitivity + RumbleVector.x;
				num2 = (axis2 + num4) * sensitivity + RumbleVector.y;
			}
			else
			{
				num = RumbleVector.x;
				num2 = RumbleVector.y;
			}
			float num5 = rotationstorage.x + num2 * (float)inversion;
			if (num5 > 180f)
			{
				num5 -= 360f;
			}
			if (num5 > (float)maxrot || num5 < (float)(-maxrot))
			{
				num5 = (float)maxrot * Mathf.Sign(num5);
			}
			currentrotation = new Vector3(num5, num + rotationstorage.y, base.transform.localEulerAngles.z);
			rotationstorage = new Vector3(currentrotation.x, currentrotation.y, 0f);
			mycont.transform.localEulerAngles = new Vector3(mycont.transform.localEulerAngles.x, rotationstorage.y, mycont.transform.localEulerAngles.z);
			base.transform.localEulerAngles = new Vector3(rotationstorage.x, base.transform.localEulerAngles.y, base.transform.localEulerAngles.z);
		}
	}

	private void DoCursorLock()
	{
		if (lockcursor)
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
		else
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public void SetCursor(bool b)
	{
		lockcursor = b;
	}
}
