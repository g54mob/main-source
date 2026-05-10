using UnityEngine;

public class BigGuy_Char_Instantiate : MonoBehaviour
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

	public Transform prefabObject;

	public BodyType bodyType;

	public ShirtType shirtType;

	public ShortsType shortsType;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
