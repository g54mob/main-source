using TMPro;
using UnityEngine;

public class AppControlPanel : MonoBehaviour
{
	[Header("Component Default")]
	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	[Header("Component")]
	public AppBase AppBase;

	[HideInInspector]
	public bool isOpen;

	[Header("GameObject")]
	public GameObject SmallCategories;

	public GameObject BigCategories;

	public TextMeshProUGUI categorySizeText;

	private int currentCategoriesView;

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public void ChangeSizeView()
	{
	}

	public void SetCategories()
	{
	}
}
