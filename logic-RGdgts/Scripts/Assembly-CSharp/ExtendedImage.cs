using UnityEngine;
using UnityEngine.UI;

public class ExtendedImage : Image
{
	public Graphic[] applyColorTo;

	public override Color color
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}
}
