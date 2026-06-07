using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Ui.Sharing.Upload
{
	public class UploadContentModel
	{
		public string Description { get; set; }

		public bool IsPublic { get; set; }

		public string Name { get; set; }

		public List<Texture2D> Screenshots { get; private set; }

		public bool ValidPhotoChecksums { get; set; }

		public UploadContentModel()
		{
			Screenshots = new List<Texture2D>();
		}
	}
}
