using UnityEngine;

[CreateAssetMenu(fileName = "TextPageElementSO", menuName = "Manual/Page Elements/Text")]
public class TextPageElementSO : PageElementSO
{
	[LocaKey]
	[SerializeField]
	private string _textLocaKey;

	public string TextLocaKey => _textLocaKey;

	public override PageElementType ElementType => PageElementType.Text;
}
