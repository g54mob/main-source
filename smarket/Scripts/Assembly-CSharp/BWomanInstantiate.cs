using UnityEngine;

public class BWomanInstantiate : MonoBehaviour
{
	public enum ShoesColor
	{
		Blue = 0,
		Black = 1,
		Gray = 2,
		LightGray = 3,
		Red = 4,
		White = 5
	}

	public enum JacketColor
	{
		Blue = 0,
		Black = 1,
		Gray = 2,
		LightGray = 3,
		Red = 4,
		White = 5
	}

	public enum SkirtColor
	{
		Blue = 0,
		Black = 1,
		Gray = 2,
		LightGray = 3,
		Red = 4,
		White = 5
	}

	public enum PantsColor
	{
		Blue = 0,
		Black = 1,
		Gray = 2,
		LightGray = 3,
		Red = 4,
		White = 5
	}

	public enum ShirtColor
	{
		Blue = 0,
		Black = 1,
		Gray = 2,
		LightBlue = 3,
		Red = 4,
		White = 5
	}

	public enum HairType
	{
		Medium = 0,
		PonyTail = 1,
		FrenchRoll = 2,
		Short = 3,
		Bun = 4
	}

	public enum HairColor
	{
		Blond = 0,
		White = 1,
		Dark = 2,
		Red = 3,
		Brown = 4
	}

	public enum EyeColor
	{
		Brown = 0,
		Blue = 1,
		Green = 2,
		Black = 3,
		DarkBlue = 4,
		LightBrown = 5
	}

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
		Pink = 0,
		Black = 1,
		White = 2,
		Tanned = 3,
		Pale = 4,
		Brown = 5
	}

	public enum TopColors
	{
		WhiteBlue = 0,
		Blue = 1,
		Grey = 2,
		WhitePurple = 3
	}

	public enum TopType
	{
		Shirt = 0,
		Jacket = 1
	}

	public enum BottomType
	{
		Skirt = 0,
		Pants = 1
	}

	private int hairCol;

	private int hairTyp;

	private int faceTyp;

	private int eyeCol;

	private int topCol;

	private int btmCol;

	private int skinTyp;

	private int topTyp;

	private int btmTyp;

	private int jacketCol;

	private int shirtCol;

	private int skirtCol;

	private int pantsCol;

	private int shoesCol;

	public Transform prefabObject;

	public FaceType faceType;

	public SkinType skinType;

	public EyeColor eyeColor;

	public TopType topType;

	public JacketColor jacketColor;

	public ShirtColor shirtColor;

	public BottomType bottomType;

	public PantsColor pantsColor;

	public SkirtColor skirtColor;

	public HairType hairType;

	public HairColor hairColor;

	public ShoesColor shoesColor;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
