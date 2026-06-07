using System;
using System.Collections.Generic;
using UnityEngine;

public class FaceLib : ScriptableObject
{
	[Serializable]
	public class Face
	{
		public int index;

		public string id;

		public Sprite spriteHi;

		public Sprite spriteLo;

		public Rect sketchRect;
	}

	private static string kAssetPath = "Assets/Resources/FaceLib.asset";

	public Face blankFace;

	public List<Face> faces = new List<Face>();

	public static FaceLib Load()
	{
		return GeneratedAssets.LoadResource<FaceLib>(kAssetPath);
	}

	public Face Find(string id)
	{
		foreach (Face face in faces)
		{
			if (face.id == id)
			{
				return face;
			}
		}
		return blankFace;
	}
}
