using UnityEngine;

public class OutsideManagerScript : MonoBehaviour, ISaveObject
{
	public struct OutsideData
	{
		public float Lerp;

		public float HatchLerp;
	}

	public Gradient AmbientTint;

	public Material AmbientMat;

	public float LerpSpeed;

	private float Lerp;

	public float HatchOpenY;

	public float HatchClosedY;

	public float HatchCloseSpeed;

	private float HatchLerp;

	public Transform Hatch;

	public AudioSource HatchCloseSound;

	private OutsideData MyData;

	public string MyID => "Outside_Manager";

	private void Start()
	{
		Lerp = 0f;
	}

	private void Update()
	{
		Lerp += Time.deltaTime * LerpSpeed;
		if (Lerp >= 1f)
		{
			Lerp = 1f;
			if (HatchLerp == 0f)
			{
				HatchCloseSound.Play();
				HatchLerp = 0.01f;
			}
			HatchLerp += Time.deltaTime * HatchCloseSpeed;
			if (HatchLerp > 1f)
			{
				HatchLerp = 1f;
			}
			Hatch.position = new Vector3(Hatch.position.x, Mathf.Lerp(HatchOpenY, HatchClosedY, HatchLerp), Hatch.position.z);
		}
		AmbientMat.SetColor("_Color", AmbientTint.Evaluate(Lerp));
	}

	public object SaveData()
	{
		MyData.Lerp = Lerp;
		MyData.HatchLerp = HatchLerp;
		return MyData;
	}

	public void LoadData(object dataIn)
	{
		MyData = (OutsideData)dataIn;
		HatchLerp = MyData.HatchLerp;
		Lerp = MyData.Lerp;
	}
}
