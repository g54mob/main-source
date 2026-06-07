using UnityEngine;
using UnityEngine.UI;

public class FabProductionRow : MonoBehaviour
{
	public RawImage outputImage;

	public Text outputText;

	public Text amtText;

	private int _wareType;

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

	private void SetWareImage(int num, RawImage image)
	{
	}

	public void OnSelected(bool value)
	{
	}
}
