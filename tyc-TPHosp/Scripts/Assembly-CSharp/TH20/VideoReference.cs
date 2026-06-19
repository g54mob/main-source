using UnityEngine;
using UnityEngine.Video;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/VideoReference", order = 1025)]
	public class VideoReference : ScriptableObjectWithID
	{
		[SerializeField]
		private VideoClip h264;

		public VideoClip VideoClip => h264;
	}
}
