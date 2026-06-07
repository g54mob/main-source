using App.Data;
using Localization;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartupMailController : ActiveComponent, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public bool hover;

	[SceneBind("Name")]
	public Text Name;

	[SceneBind("Audience")]
	public Text Audience;

	[SceneBind("Hover")]
	public Image Hover;

	[SceneBind("LayerRead")]
	public Image LayerRead;

	[SceneBind("ReadBtn")]
	public Button Read;

	[SceneBind("Money")]
	public Text Money;

	[SceneBind("Num")]
	public Text Num;

	[SceneBind("ReworkBtn")]
	public Button ReworkBtn;

	[SceneBind("PatchBtn")]
	public Button PatchBtn;

	public void OnPointerEnter(PointerEventData eventData)
	{
		Hover.gameObject.SetActive(value: true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Hover.gameObject.SetActive(value: false);
	}

	public void Init(Startup st, int id)
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		Name.text = TextResources.GetString(st.Texts + "T");
		Audience.text = Logic.ColorTransform("WARNING", TextResources.GetString(st.AudienceType));
		Num.text = "#" + id;
		Money.text = Logic.ColorTransform("MONEY", st.BaseMoney + "$");
		Hover.gameObject.SetActive(value: false);
		ReworkBtn.gameObject.SetActive(value: false);
		PatchBtn.gameObject.SetActive(value: false);
		bool flag = false;
		StartupScheme startupScheme = null;
		LayerRead.gameObject.SetActive(value: false);
		int hashCode = ActiveComponent.Model.P.startupQueue[id].KeyName.GetHashCode();
		foreach (StartupScheme startup in ActiveComponent.Model.P.Startups)
		{
			if (startup.baseStartup.KeyName.GetHashCode() == hashCode)
			{
				flag = true;
				startupScheme = startup;
				break;
			}
		}
		if (flag)
		{
			if (startupScheme.released == 1)
			{
				PatchBtn.gameObject.SetActive(value: true);
			}
			else
			{
				ReworkBtn.gameObject.SetActive(value: true);
			}
		}
		if (Logic.StartupWasDeleted(ActiveComponent.Model.P.startupQueue[id].KeyName))
		{
			ReworkBtn.gameObject.SetActive(value: false);
			PatchBtn.gameObject.SetActive(value: false);
			Read.gameObject.SetActive(value: false);
			LayerRead.gameObject.SetActive(value: true);
			Money.text = "";
		}
	}
}
