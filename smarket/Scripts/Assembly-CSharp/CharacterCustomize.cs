using UnityEngine;

public class CharacterCustomize : MonoBehaviour
{
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
		Pale = 0,
		Old = 1,
		Tanned = 2,
		White = 3,
		Black = 4,
		DarkBrown = 5,
		DarkerOld = 6
	}

	public enum TopColors
	{
		WhiteBlue = 0,
		Blue = 1,
		Grey = 2,
		WhitePurple = 3
	}

	public enum BottomColors
	{
		White = 0,
		Gray = 1,
		Blue = 2,
		Purple = 3
	}

	private int hairCol;

	private int hairTyp;

	private int faceTyp;

	private int eyeCol;

	private int topCol;

	private int btmCol;

	private int skinTyp;

	private MaterialsList materialsList;

	private BlinkController blinkScript;

	private SkinnedMeshRenderer skinnedMeshRenderer;

	public FaceType faceType;

	public SkinType skinType;

	public EyeColor eyeColor;

	public TopColors topColors;

	public BottomColors btmColors;

	public HairType hairType;

	public HairColor hairColor;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void charCustomize(int face, int eye, int top, int bottom, int hairT, int hairC, int skinT)
	{
	}

	private void OnValidate()
	{
	}
}
