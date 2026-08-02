using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace GRP
{
	public class PartThumbnailBuilderItem
	{
		public PartConfig part;

		public JObject data;

		public Quaternion rotation;

		public Highlight highlight;

		public bool showGround;

		public Quaternion cameraRotation;

		public bool useCustomCameraRotation;

		public bool fitResolution;

		public int scene;

		public TaskCompletionSource<Texture2D> tcs;

		public bool IsEqual(PartThumbnailBuilderItem other)
		{
			return false;
		}
	}
}
