using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultResearchGroup : MonoBehaviour
{
	[SerializeField]
	private Image _mainIcon;

	[SerializeField]
	private TMP_Text _unlockCount;

	[SerializeField]
	private TMP_Text _useResearchPoint;

	[SerializeField]
	private TMP_Text _useRedResearchPoint;

	public void InitComponent(string iconPath, int unlockCount, int treeCount, int usePoint, int useRedPoint)
	{
	}
}
