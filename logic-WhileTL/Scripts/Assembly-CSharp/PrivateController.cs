using App.Data;
using Localization;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PrivateController : ActiveComponent, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public bool hover;

	[SceneBind("Name")]
	public Text Name;

	[SceneBind("Hover")]
	public Image Hover;

	[SceneBind("ReadBtn")]
	public Button Read;

	[SceneBind("WasReadBtn")]
	public Button WasRead;

	[SceneBind("Money")]
	public Text Money;

	[SceneBind("Num")]
	public Text Num;

	public void OnPointerEnter(PointerEventData eventData)
	{
		Hover.gameObject.SetActive(value: true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Hover.gameObject.SetActive(value: false);
	}

	public void Init(MoneyLetter ml, int id)
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		Name.text = TextResources.GetString(ml.KeyName + "T");
		Money.text = Logic.ColorTransform("MONEY", ml.Money + "$");
		if (ml.used == 1)
		{
			Money.text = "";
			Read.gameObject.SetActive(value: false);
		}
		else
		{
			WasRead.gameObject.SetActive(value: false);
		}
		Num.text = "#" + id;
		Hover.gameObject.SetActive(value: false);
	}
}
