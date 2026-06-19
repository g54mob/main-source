using System;
using System.Collections.Generic;
using UnityEngine;

namespace Michsky.DreamOS
{
	[CreateAssetMenu(fileName = "New Profile Picture Library", menuName = "DreamOS/New Profile Picture Library")]
	public class ProfilePictureLibrary : ScriptableObject
	{
		[Serializable]
		public class PPItem
		{
			public string pictureID = "Picture";

			public Sprite pictureSprite;
		}

		public List<PPItem> pictures = new List<PPItem>();
	}
}
