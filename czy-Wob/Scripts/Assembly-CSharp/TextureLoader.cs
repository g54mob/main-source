using System.Collections.Generic;
using UnityEngine;

public class TextureLoader : MonoBehaviour
{
	private string basePath = "DogTextures/bodyPatterns/";

	private string spotPath = "spots/";

	private string spots_10x10Path = "10x10/";

	private string spots_64x64Path = "64x64/";

	private string spots_128x128Path = "128x128/";

	private string spots_256x256Path = "256x256/";

	private string stripePath = "stripes/";

	private string stripeCaps_TopLeftPath = "Caps_Left/";

	private string stripeCaps_TopMidPath = "Caps_Mid/";

	private string stripeSegs_LeftLeftPath = "Segs_Left_Left/";

	private string stripeSegs_LeftMidPath = "Segs_Left_Mid/";

	private string stripeSegs_LeftRightPath = "Segs_Left_Right/";

	private string stripeSegs_MidMidPath = "Segs_Mid_Mid/";

	private string repeatingPath = "repeating/";

	private string repeatingSpots_64x64Path = "spots/64x64/";

	private string repeatingLeapords_64x64Path = "leapords/64x64";

	private string repeatingLeapords_128x128Path = "leapords/128x128";

	private string repeatingHearts_64x64Path = "hearts/64x64";

	private string repeating90s_64x64Path = "90s/64x64";

	private string repeating90s_128x128Path = "90s/128x128";

	private string repeatingCircles_64x64Path = "circles/64x64";

	public List<Texture2D> spots_10x10 = new List<Texture2D>();

	public List<Texture2D> spots_64x64 = new List<Texture2D>();

	public List<Texture2D> spots_128x128 = new List<Texture2D>();

	public List<Texture2D> spots_256x256 = new List<Texture2D>();

	public List<Texture2D> stripeCaps_TopLeft = new List<Texture2D>();

	public List<Texture2D> stripeCaps_TopMid = new List<Texture2D>();

	public List<Texture2D> stripeSegs_LeftLeft = new List<Texture2D>();

	public List<Texture2D> stripeSegs_LeftMid = new List<Texture2D>();

	public List<Texture2D> stripeSegs_LeftRight = new List<Texture2D>();

	public List<Texture2D> stripeSegs_MidMid = new List<Texture2D>();

	private int numRepeatingTypes = 5;

	public List<Texture2D> repeatingSpots_64x64 = new List<Texture2D>();

	public List<Texture2D> repeatingLeapords_64x64 = new List<Texture2D>();

	public List<Texture2D> repeatingLeapords_128x128 = new List<Texture2D>();

	public List<Texture2D> repeatingHearts_64x64 = new List<Texture2D>();

	public List<Texture2D> repeating90s_64x64 = new List<Texture2D>();

	public List<Texture2D> repeating90s_128x128 = new List<Texture2D>();

	public List<Texture2D> repeatingCircles_64x64 = new List<Texture2D>();

	private void Awake()
	{
		LoadTextures();
	}

	public int GetNumRepeatingTypes()
	{
		return numRepeatingTypes;
	}

	private void LoadTextures()
	{
		string text = basePath + spotPath;
		FillListFromPath(ref spots_10x10, text + spots_10x10Path);
		FillListFromPath(ref spots_64x64, text + spots_64x64Path);
		FillListFromPath(ref spots_128x128, text + spots_128x128Path);
		FillListFromPath(ref spots_256x256, text + spots_256x256Path);
		string text2 = basePath + stripePath;
		FillListFromPath(ref stripeCaps_TopLeft, text2 + stripeCaps_TopLeftPath);
		FillListFromPath(ref stripeCaps_TopMid, text2 + stripeCaps_TopMidPath);
		FillListFromPath(ref stripeSegs_LeftLeft, text2 + stripeSegs_LeftLeftPath);
		FillListFromPath(ref stripeSegs_LeftMid, text2 + stripeSegs_LeftMidPath);
		FillListFromPath(ref stripeSegs_LeftRight, text2 + stripeSegs_LeftRightPath);
		FillListFromPath(ref stripeSegs_MidMid, text2 + stripeSegs_MidMidPath);
		int count = stripeCaps_TopLeft.Count;
		if (stripeCaps_TopMid.Count != count || stripeSegs_LeftLeft.Count != count || stripeSegs_LeftMid.Count != count || stripeSegs_LeftRight.Count != count || stripeSegs_MidMid.Count != count)
		{
			Debug.LogError("Segment counts don't match up, this will break pattern generation.");
		}
		string text3 = basePath + repeatingPath;
		FillListFromPath(ref repeatingSpots_64x64, text3 + repeatingSpots_64x64Path);
		FillListFromPath(ref repeatingLeapords_64x64, text3 + repeatingLeapords_64x64Path);
		FillListFromPath(ref repeatingLeapords_128x128, text3 + repeatingLeapords_128x128Path);
		FillListFromPath(ref repeatingHearts_64x64, text3 + repeatingHearts_64x64Path);
		FillListFromPath(ref repeating90s_64x64, text3 + repeating90s_64x64Path);
		FillListFromPath(ref repeating90s_128x128, text3 + repeating90s_128x128Path);
		FillListFromPath(ref repeatingCircles_64x64, text3 + repeatingCircles_64x64Path);
	}

	private void FillListFromPath(ref List<Texture2D> textureList, string path)
	{
		textureList = new List<Texture2D>();
		Object[] array = Resources.LoadAll(path);
		for (int i = 0; i < array.Length; i++)
		{
			textureList.Add((Texture2D)array[i]);
		}
	}
}
