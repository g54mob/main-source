using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "ImagePageElementSO", menuName = "Manual/Page Elements/Image")]
public class ImagePageElementSO : PageElementSO
{
	[SerializeField]
	private Sprite _image;

	[SerializeField]
	private bool _hasCaption;

	[SerializeField]
	[LocaKey]
	[ShowIf("_hasCaption")]
	private string _captionLocaKey;

	public Sprite Image => _image;

	public bool HasCaption => _hasCaption;

	public string CaptionLocaKey => _captionLocaKey;

	public override PageElementType ElementType => PageElementType.Image;
}
