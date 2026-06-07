using NBT.Tags;
using TMPro;
using UnityEngine;

public class CModUnitText : MonoBehaviour
{
	public TextMeshPro textControl;

	private bool _billboard;

	private Camera cam;

	public Color color
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	public float fontSize
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public string text
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool billboard
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}

	public void ReadData(Tag data)
	{
	}

	public TagCompound WriteData()
	{
		return null;
	}
}
