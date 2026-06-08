using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Colorful/Vintage")]
public class CC_Vintage : CC_LookupFilter
{
	public enum Filter
	{
		None = 0,
		F1977 = 1,
		Aden = 2,
		Amaro = 3,
		Brannan = 4,
		Crema = 5,
		Earlybird = 6,
		Hefe = 7,
		Hudson = 8,
		Inkwell = 9,
		Kelvin = 10,
		LoFi = 11,
		Ludwig = 12,
		Mayfair = 13,
		Nashville = 14,
		Perpetua = 15,
		Rise = 16,
		Sierra = 17,
		Slumber = 18,
		Sutro = 19,
		Toaster = 20,
		Valencia = 21,
		Walden = 22,
		Willow = 23,
		XProII = 24
	}

	public Filter filter;

	protected override void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (filter == Filter.None)
		{
			lookupTexture = null;
		}
		else
		{
			lookupTexture = Resources.Load<Texture2D>("Instagram/" + filter);
		}
		base.OnRenderImage(source, destination);
	}
}
