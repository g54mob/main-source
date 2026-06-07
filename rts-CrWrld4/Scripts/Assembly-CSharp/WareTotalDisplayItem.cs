using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class WareTotalDisplayItem : MonoBehaviour
{
	public RawImage wareImage;

	public Text amtText;

	private int _wareType;

	private int _amt;

	public int initWareType;

	public int wareType
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int amt
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}
}
