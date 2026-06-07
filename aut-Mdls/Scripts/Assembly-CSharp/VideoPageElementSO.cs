using UnityEngine;

[CreateAssetMenu(fileName = "VideoPageElementSO", menuName = "Manual/Page Elements/Video")]
public class VideoPageElementSO : PageElementSO
{
	[SerializeField]
	private string _videoName;

	public string VideoName => _videoName;

	public override PageElementType ElementType => PageElementType.Video;
}
