using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	[Serializable]
	public class PreviewImage
	{
		public Texture2D Image;

		public PreviewImage(Texture2D image)
		{
			Image = image;
		}
	}
}
