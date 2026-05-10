using UnityEngine;

public class BmanCustomize : MonoBehaviour
{
	public enum FaceType
	{
		FaceA = 0,
		FaceB = 1,
		FaceC = 2,
		FaceD = 3,
		FaceE = 4
	}

	public enum SkinType
	{
		SkinA = 0,
		SkinB = 1,
		SkinC = 2,
		SkinD = 3,
		SkinE = 4
	}

	public enum EyeColor
	{
		Brown = 0,
		Blue = 1,
		Green = 2,
		Black = 3,
		Gray = 4,
		LightBrown = 5
	}

	public enum Hair
	{
		HairA = 0,
		HairB = 1,
		HairC = 2,
		HairD = 3,
		HairE = 4,
		HairF = 5,
		HairG = 6,
		HairH = 7,
		HairI = 8
	}

	public enum HairColor
	{
		Blond = 0,
		Brown = 1,
		Gray = 2,
		Brunete = 3,
		Black = 4
	}

	public enum Glasses
	{
		No = 0,
		Glasses = 1,
		SunGlasses = 2
	}

	public enum Tie
	{
		Tie = 0,
		Butterfly = 1,
		No = 2
	}

	public enum Jacket
	{
		Open = 0,
		Closed = 1,
		No = 2
	}

	public enum Waistcoat
	{
		Yes = 0,
		No = 1
	}

	public enum Belt
	{
		Yes = 0,
		No = 1
	}

	public enum Handkerchief
	{
		Yes = 0,
		No = 1
	}

	public enum JacketColor
	{
		Black = 0,
		Charcoal = 1,
		Navy = 2,
		Grey = 3,
		LightGray = 4,
		White = 5,
		Vintage = 6,
		Blue = 7,
		Tan = 8,
		Brown = 9
	}

	public enum ShirtColor
	{
		Black = 0,
		Charcoal = 1,
		Navy = 2,
		Grey = 3,
		LightGray = 4,
		White = 5,
		LightBlue = 6,
		Blue = 7
	}

	public enum WaistcoatColor
	{
		Black = 0,
		Charcoal = 1,
		Navy = 2,
		Grey = 3,
		LightGray = 4,
		White = 5,
		Vintage = 6,
		Blue = 7,
		Tan = 8,
		Brown = 9
	}

	public enum TieColor
	{
		Black = 0,
		White = 1,
		Blue = 2,
		RedBlue = 3,
		Red = 4,
		BlueB = 5,
		Purple = 6,
		LightBlue = 7,
		Gray = 8,
		Brown = 9
	}

	public enum PantsColor
	{
		Black = 0,
		Charcoal = 1,
		Navy = 2,
		Grey = 3,
		LightGray = 4,
		White = 5,
		Vintage = 6,
		Blue = 7,
		Tan = 8,
		Brown = 9
	}

	public enum ShoesColor
	{
		Black = 0,
		Brown = 1,
		RedBrown = 2,
		White = 3
	}

	public enum HandkerchiefColor
	{
		Black = 0,
		White = 1,
		Gray = 2,
		Purple = 3,
		Red = 4,
		Blue = 5
	}

	private int faceT;

	private int skinT;

	private int eyeC;

	private int hairT;

	private int hairC;

	private int glassesT;

	private int jacketT;

	private int waistcoatT;

	private int handkerchiefT;

	private int tieT;

	private int beltT;

	private int jacketC;

	private int shirtC;

	private int waistcoatC;

	private int tieC;

	private int pantsC;

	private int shoesC;

	private int handkerchiefC;

	private BmanAssetsList assetsList;

	private SkinnedMeshRenderer skinnedMeshRenderer;

	public FaceType faceType;

	public SkinType skinType;

	public EyeColor eyeCol;

	public Glasses glasses;

	public Hair hair;

	public HairColor hairCol;

	public Jacket jacket;

	public Waistcoat waistcoat;

	public Tie tie;

	public Belt belt;

	public Handkerchief handkerchief;

	public JacketColor jacketCol;

	public ShirtColor shirtCol;

	public WaistcoatColor waistcoatCol;

	public TieColor tieCol;

	public PantsColor pantsCol;

	public ShoesColor shoesCol;

	public HandkerchiefColor handkerchiefCol;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void charCustomize(int faceTy, int skinTy, int eyeCo, int glassesTy, int hairTy, int hairCo, int jacketTy, int waistcoatTy, int tieTy, int beltTy, int handkerchiefTy, int jacketCo, int shirtCo, int waistcoatCo, int tieCo, int pantsCo, int shoesCo, int handkerchiefCo)
	{
	}

	private void OnValidate()
	{
	}
}
