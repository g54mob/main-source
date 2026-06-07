using UnityEngine;

[CreateAssetMenu(fileName = "TitlePageElementSO", menuName = "Manual/Page Elements/Title")]
public class TitlePageElementSO : PageElementSO
{
	[LocaKey]
	[SerializeField]
	private string _titleLocaKey;

	public string TitleLocaKey => _titleLocaKey;

	public override PageElementType ElementType => PageElementType.Title;
}
