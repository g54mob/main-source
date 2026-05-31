using TMPro;
using UnityEngine;

public class MainComputerController : MonoBehaviour, ISaveObject
{
	public struct MainComputerData
	{
		public float HorRot;

		public float VertRot;
	}

	public Material TargetMat;

	public RenderTexture RenderTex;

	public float RotationAmount;

	public GameObject CameraPole;

	public GameObject Camera;

	public Texture2D DefaultTex;

	public TMP_Text HorCoors;

	public TMP_Text VertCoors;

	public float PictureDelay;

	public AudioSource TakePictureSound;

	private NodeManagerScript NMan;

	private SubController SMan;

	private Camera CamComp;

	public Animator VisualAnimator;

	private float PictureDelayTimer;

	private bool TakingPicture;

	private MainComputerData MyData;

	public string MyID => "Main_Computer";

	private void Start()
	{
		NMan = GameObject.Find("NodeManager").GetComponent<NodeManagerScript>();
		SMan = GameObject.Find("FakeSub").GetComponent<SubController>();
		CamComp = Camera.GetComponent<Camera>();
		Camera.SetActive(value: false);
		ResetScreen();
	}

	private void Update()
	{
		MyData.HorRot = 5f;
		Camera.transform.localEulerAngles = new Vector3(MyData.HorRot, Camera.transform.localEulerAngles.y, Camera.transform.localEulerAngles.z);
		CameraPole.transform.localEulerAngles = new Vector3(CameraPole.transform.localEulerAngles.x, MyData.VertRot, CameraPole.transform.localEulerAngles.z);
		if (TakingPicture)
		{
			PictureDelayTimer += Time.deltaTime;
			if (PictureDelayTimer >= PictureDelay)
			{
				PictureDone();
			}
		}
	}

	private void FixedUpdate()
	{
		HorCoors.text = "y - " + (MyData.HorRot * -1f).ToString("000");
		VertCoors.text = "x - " + MyData.VertRot.ToString("000");
	}

	private void PictureDone()
	{
		SetCRTTexture(toTexture2D(RenderTex));
		PictureDelayTimer = 0f;
		TakingPicture = false;
		Vector2 pos = new Vector2(SMan.transform.position.x, SMan.transform.position.z);
		NMan.PictureTaken(pos, SMan.transform.localEulerAngles.y);
		if (!GameObject.Find("RealtimeScreen"))
		{
			Camera.SetActive(value: false);
		}
		CheckEye();
	}

	private void CheckEye()
	{
		if (SMan.DoingEye && SMan.CheckEyeAngle())
		{
			SMan.DoingEye = false;
			SMan.SetMonsterAttack();
		}
	}

	public Texture2D toTexture2D(RenderTexture rTex)
	{
		Texture2D texture2D = new Texture2D(rTex.width, rTex.height, TextureFormat.RGBA32, mipChain: false);
		texture2D.Apply(updateMipmaps: false);
		Graphics.CopyTexture(rTex, texture2D);
		return texture2D;
	}

	public void SetCRTTexture(Texture2D tex)
	{
		TargetMat.SetTexture("_MainTex", tex);
		TargetMat.SetTexture("_EmissionMap", tex);
	}

	public void TakePicture()
	{
		if (!TakingPicture)
		{
			VisualAnimator.SetTrigger("DoPush");
			Camera.SetActive(value: true);
			PictureDelayTimer = 0f;
			ResetScreen();
			TakePictureSound.Play();
			TakingPicture = true;
		}
	}

	public void RotateCam(Vector3 amount)
	{
		ResetScreen();
		float num = MyData.HorRot + amount.x;
		float num2 = MyData.VertRot + amount.y;
		if (num2 > 360f)
		{
			num2 -= 360f;
		}
		if (num2 < 0f)
		{
			num2 += 360f;
		}
		if (num > 90f)
		{
			num = 90f;
		}
		if (num < -90f)
		{
			num = -90f;
		}
		MyData.HorRot = num;
		MyData.VertRot = num2;
	}

	public void ResetScreen()
	{
		SetCRTTexture(DefaultTex);
	}

	public object SaveData()
	{
		return MyData;
	}

	public void LoadData(object dataIn)
	{
		MyData = (MainComputerData)dataIn;
	}
}
