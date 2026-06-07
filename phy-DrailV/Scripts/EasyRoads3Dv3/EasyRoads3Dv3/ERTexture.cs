using System;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERTexture
	{
		public Texture2D texture;

		public float roadWidth = 6f;

		public float leftOffset = 0f;

		public float rightOffset = 1f;

		public float leftInnerOffset = 0.1f;

		public float rightInnerOffset = 0.9f;

		public ERTexture(Texture2D _texture, float _roadWidth, float _leftOffset, float _rightOffset, float _leftInnerOffset, float _rightInnerOffset)
		{
			texture = _texture;
			roadWidth = _roadWidth;
			leftOffset = _leftOffset;
			rightOffset = _rightOffset;
			leftInnerOffset = _leftInnerOffset;
			rightInnerOffset = _rightInnerOffset;
		}

		public static ERTexture GetERTexture(Material mat)
		{
			if (mat == null)
			{
				return null;
			}
			if (mat.mainTexture == null)
			{
				return null;
			}
			GameObject gameObject = Resources.Load("ERSideObjectsLog") as GameObject;
			ERSideObjectLog component = gameObject.GetComponent<ERSideObjectLog>();
			for (int i = 0; i < component.textureData.Count; i++)
			{
				if (component.textureData[i].texture == mat.mainTexture)
				{
					return component.textureData[i];
				}
			}
			return null;
		}
	}
}
