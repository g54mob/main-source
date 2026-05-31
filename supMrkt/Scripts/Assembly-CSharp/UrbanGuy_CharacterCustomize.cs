using UnityEngine;

public class UrbanGuy_CharacterCustomize : MonoBehaviour
{
	public enum BodySkin
	{
		V1 = 0,
		V2 = 1,
		V3 = 2,
		V4 = 3,
		V5 = 4
	}

	public enum TrousersSkin
	{
		V1 = 0,
		V2 = 1,
		V3 = 2,
		V4 = 3,
		V5 = 4
	}

	public enum TankTopSkin
	{
		None = 0,
		V1 = 1,
		V2 = 2,
		V3 = 3,
		V4 = 4,
		V5 = 5,
		V6 = 6
	}

	public enum HoodieSkin
	{
		None = 0,
		V1 = 1,
		V2 = 2,
		V3 = 3,
		V4 = 4,
		V5 = 5,
		V6 = 6
	}

	public enum HatSkin
	{
		None = 0,
		V1 = 1,
		V2 = 2,
		V3 = 3,
		V4 = 4,
		V5 = 5
	}

	private int bodyTyp;

	private int trousersTyp;

	private int tanktopTyp;

	private int hoodieTyp;

	private int hatTyp;

	private bool tanktopOld;

	private Transform hoodieT;

	private Transform tanktopT;

	private Transform bodyToHideT;

	private Transform hatT;

	private Transform hatFlipT;

	private Transform bodyT_A;

	private Transform bodyT_B;

	private UrbanGuy_AssetsList materialsList;

	private SkinnedMeshRenderer skinnedMeshRenderer;

	public BodySkin bodyType;

	public TrousersSkin trousersType;

	public TankTopSkin tanktopType;

	public HoodieSkin hoodieType;

	public HatSkin hatType;

	public bool hatFlip;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void charCustomize(int body, int trousers, int tanktop, int hoodie, int hat, bool hatflip)
	{
	}

	private void OnValidate()
	{
	}
}
