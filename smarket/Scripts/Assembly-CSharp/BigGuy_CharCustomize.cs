using UnityEngine;

public class BigGuy_CharCustomize : MonoBehaviour
{
	public enum BodyType
	{
		V1 = 0,
		V2 = 1
	}

	public enum ShirtType
	{
		V1 = 0,
		V2 = 1,
		No = 2
	}

	public enum ShortsType
	{
		V1 = 0,
		V2 = 1
	}

	private int bodyTyp;

	private int shirtTyp;

	private int shortsTyp;

	private BigGuy_AssetsList materialsList;

	private SkinnedMeshRenderer skinnedMeshRenderer;

	public BodyType bodyType;

	public ShirtType shirtType;

	public ShortsType shortsType;

	public float openMouthBS;

	public float closeLeftEyeBS;

	public float closeRightEyeBS;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void charCustomize(int body, int top, int bottom)
	{
	}

	private void OnValidate()
	{
	}
}
