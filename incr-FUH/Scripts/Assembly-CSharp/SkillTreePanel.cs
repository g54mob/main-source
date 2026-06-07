using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreePanel : MonoBehaviour
{
	public TMP_Text MoneyText;

	public TMP_Text ResearchText;

	public TMP_Text RedShardAmount;

	public TMP_Text YellowShardAmount;

	public TMP_Text BlueShardAmount;

	public TMP_Text BookAmount;

	public GameObject RedShardSection;

	public GameObject YellowShardSection;

	public GameObject BlueShardSection;

	public GameObject BookSection;

	public GameObject ViewAllButton;

	public Sprite ViewAllSprite;

	public Sprite ViewPartialSprite;

	public static bool DisplayAllNodes;

	private void Start()
	{
		SetupTopPanel();
	}

	private void FixedUpdate()
	{
		SetupTopPanel();
		ViewAllButton.SetActive(GameController.Instance.SeeAllNodes);
	}

	private void SetupTopPanel()
	{
		if (GameController.Instance.Money.TotalAmount == 0)
		{
			MoneyText.gameObject.SetActive(value: false);
		}
		else
		{
			MoneyText.gameObject.SetActive(value: true);
			MoneyText.text = "<color=yellow>" + GameController.Instance.Money.Amount.ToNumber() + " $</color>";
		}
		if (GameController.Instance.ResearchPoint.TotalAmount == 0)
		{
			ResearchText.gameObject.SetActive(value: false);
		}
		else
		{
			ResearchText.gameObject.SetActive(value: true);
			ResearchText.text = "<color=#FFC0CB>" + GameController.Instance.ResearchPoint.Amount.ToNumber() + " RP</color>";
		}
		if (GameController.Instance.RedPoint.TotalAmount == 0)
		{
			RedShardSection.SetActive(value: false);
		}
		else
		{
			RedShardSection.SetActive(value: true);
			RedShardAmount.text = GameController.Instance.RedPoint.Amount.ToString();
		}
		if (GameController.Instance.BluePoint.TotalAmount == 0)
		{
			BlueShardSection.SetActive(value: false);
		}
		else
		{
			BlueShardSection.SetActive(value: true);
			BlueShardAmount.text = GameController.Instance.BluePoint.Amount.ToString();
		}
		if (GameController.Instance.YellowPoint.TotalAmount == 0)
		{
			YellowShardSection.SetActive(value: false);
		}
		else
		{
			YellowShardSection.SetActive(value: true);
			YellowShardAmount.text = GameController.Instance.YellowPoint.Amount.ToString();
		}
		if (GameController.Instance.Book.TotalAmount == 0)
		{
			BookSection.SetActive(value: false);
		}
		else
		{
			BookSection.SetActive(value: true);
			BookAmount.text = GameController.Instance.Book.Amount.ToString();
		}
		SetViewAllNodesDisplay();
	}

	public void ToggleViewAllNodes()
	{
		GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ui_nodepanel_option_click);
		DisplayAllNodes = !DisplayAllNodes;
		SetViewAllNodesDisplay();
	}

	public void SetViewAllNodesDisplay()
	{
		if (DisplayAllNodes)
		{
			ViewAllButton.GetComponent<Image>().sprite = ViewAllSprite;
		}
		else
		{
			ViewAllButton.GetComponent<Image>().sprite = ViewPartialSprite;
		}
	}
}
