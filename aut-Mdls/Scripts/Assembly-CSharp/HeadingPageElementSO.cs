using UnityEngine;

[CreateAssetMenu(fileName = "HeadingPageElementSO", menuName = "Manual/Page Elements/Heading")]
public class HeadingPageElementSO : PageElementSO
{
	[LocaKey]
	[SerializeField]
	private string _headingLocaKey;

	public string HeadingLocaKey => _headingLocaKey;

	public override PageElementType ElementType => PageElementType.Heading;
}
