using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiniGameLink : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public TMP_Text text;

	public MiniGameManager gm;

	private void Start()
	{
		text = GetComponent<TMP_Text>();
		gm = Object.FindObjectOfType<MiniGameManager>();
	}

	private void Update()
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		int num = TMP_TextUtilities.FindIntersectingLink(text, Input.mousePosition, null);
		Debug.Log(num);
		if (num == -1)
		{
			return;
		}
		TMP_LinkInfo tMP_LinkInfo = text.textInfo.linkInfo[num];
		Debug.Log(num);
		Debug.Log(tMP_LinkInfo.GetLinkID());
		Debug.Log(tMP_LinkInfo.GetLinkText());
		if (tMP_LinkInfo.GetLinkID() == "newgame")
		{
			gm.NewGame();
		}
		if (tMP_LinkInfo.GetLinkID() == "pass")
		{
			gm.RoundEnd();
		}
		if (tMP_LinkInfo.GetLinkID() == "rules")
		{
			gm.ShowRules();
		}
		if (tMP_LinkInfo.GetLinkID() == "quit")
		{
			if (gm.testMode)
			{
				gm.NewGame();
			}
			else
			{
				gm.Quit();
			}
		}
	}
}
