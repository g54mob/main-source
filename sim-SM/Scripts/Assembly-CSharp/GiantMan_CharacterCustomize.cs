using UnityEngine;

public class GiantMan_CharacterCustomize : MonoBehaviour
{
	public enum FaceType
	{
		FaceV1 = 0,
		FaceV2 = 1
	}

	public enum BodySkin
	{
		BodyV1 = 0,
		BodyV2 = 1
	}

	public enum LegsSkin
	{
		LegsV1 = 0,
		LegsV2 = 1
	}

	public enum TrousersSkin
	{
		TrousersV1 = 0,
		TrousersV2 = 1,
		TrousersV3 = 2,
		TrousersV4 = 3
	}

	public enum SneakersSkin
	{
		SneakersV1 = 0,
		SneakersV2 = 1,
		SneakersV3 = 2,
		SneakersV4 = 3
	}

	public enum TankTopSkin
	{
		None = 0,
		TankTopV1 = 1,
		TankTopV2 = 2,
		TankTopV3 = 3,
		TankTopV4 = 4
	}

	public enum TshirtSkin
	{
		None = 0,
		TshirtV1 = 1,
		TshirtV2 = 2,
		TshirtV3 = 3,
		TshirtV4 = 4
	}

	private int headTyp;

	private int bodyTyp;

	private int trousersTyp;

	private int tanktopTyp;

	private int tshirtTyp;

	private int sneakersTyp;

	private int legsTyp;

	private bool tanktopOld;

	private Transform tshirtT;

	private Transform tanktopT;

	private Transform bodyToHideT;

	private Transform bodyExposedT;

	private Transform trousersT;

	private Transform legsT;

	private Transform sneakerR_T;

	private Transform sneakerL_T;

	private Transform footR_T;

	private Transform footL_T;

	private Transform headT_A;

	private Transform headT_B;

	private Transform headT_C;

	private Transform headT_D;

	private GiantMan_AssetsList materialsList;

	private SkinnedMeshRenderer skinnedMeshRenderer;

	public FaceType faceType;

	public BodySkin bodySkin;

	public LegsSkin legsSkin;

	public TrousersSkin trousersSkin;

	public SneakersSkin sneakersSkin;

	public TankTopSkin tanktopSkin;

	public TshirtSkin tshirtSkin;

	public bool trousersVisible;

	public bool sneakerLeftVisible;

	public bool sneakerRightVisible;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void charCustomize(int body, int trousers, int tanktop, int tshirt, int head, bool trousersV, int sneakers, int legs)
	{
	}

	private void OnValidate()
	{
	}
}
