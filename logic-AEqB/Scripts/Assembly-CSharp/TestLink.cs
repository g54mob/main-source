using System;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestLink : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public TMP_Text text;

	public NewMenuManager gm;

	private void Start()
	{
		text = GetComponent<TMP_Text>();
		gm = UnityEngine.Object.FindObjectOfType<NewMenuManager>();
	}

	private void Update()
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		int num = TMP_TextUtilities.FindIntersectingLink(text, Input.mousePosition, null);
		UnityEngine.Debug.Log(num);
		if (num == -1)
		{
			return;
		}
		TMP_LinkInfo tMP_LinkInfo = text.textInfo.linkInfo[num];
		UnityEngine.Debug.Log(num);
		UnityEngine.Debug.Log(tMP_LinkInfo.GetLinkID());
		UnityEngine.Debug.Log(tMP_LinkInfo.GetLinkText());
		if (tMP_LinkInfo.GetLinkID() == "editor")
		{
			gm.g.Editor();
		}
		if (tMP_LinkInfo.GetLinkID() == "link1")
		{
			gm.ChangeDisplay(1);
		}
		if (tMP_LinkInfo.GetLinkID() == "link2")
		{
			gm.ChangeDisplay(2);
		}
		if (tMP_LinkInfo.GetLinkID() == "link3")
		{
			gm.ChangeDisplay(3);
		}
		if (tMP_LinkInfo.GetLinkID() == "link4")
		{
			gm.ChangeDisplay(4);
		}
		if (tMP_LinkInfo.GetLinkID() == "link5")
		{
			gm.ChangeDisplay(5);
		}
		if (tMP_LinkInfo.GetLinkID() == "link6")
		{
			gm.ChangeDisplay(6);
		}
		if (tMP_LinkInfo.GetLinkID() == "editor_menu")
		{
			gm.ChangeDisplay(9);
		}
		if (tMP_LinkInfo.GetLinkID() == "about")
		{
			gm.About();
		}
		if (tMP_LinkInfo.GetLinkID() == "quit")
		{
			gm.Quit();
		}
		if (tMP_LinkInfo.GetLinkID() == "setting")
		{
			gm.Setting();
		}
		if (tMP_LinkInfo.GetLinkID() == "contact")
		{
			gm.Contact();
			return;
		}
		if (tMP_LinkInfo.GetLinkID() == "sandbox")
		{
			gm.g.SandBox();
		}
		if (tMP_LinkInfo.GetLinkID() == "custom")
		{
			gm.ChangeDisplay(8);
			return;
		}
		if (tMP_LinkInfo.GetLinkID() == "minigame")
		{
			gm.ChangeDisplay(7);
		}
		if (tMP_LinkInfo.GetLinkID() == "panguproject")
		{
			gm.Pangu();
		}
		if (tMP_LinkInfo.GetLinkID() == "pangupdf")
		{
			if (gm.g.setting.language == 0)
			{
				gm.g.OpenPDF("PanguProject.pdf");
			}
			else if (gm.g.setting.language == 1)
			{
				gm.g.OpenPDF("Pangu_CHS.pdf");
			}
			else if (gm.g.setting.language == 2)
			{
				gm.g.OpenPDF("Pangu_CHT.pdf");
			}
		}
		if (tMP_LinkInfo.GetLinkID() == "save1")
		{
			gm.g.SetSaveSlot(0);
		}
		if (tMP_LinkInfo.GetLinkID() == "save2")
		{
			gm.g.SetSaveSlot(1);
		}
		if (tMP_LinkInfo.GetLinkID() == "save3")
		{
			gm.g.SetSaveSlot(2);
		}
		if (tMP_LinkInfo.GetLinkID() == "light")
		{
			gm.g.SetTheme(isDark: false);
		}
		if (tMP_LinkInfo.GetLinkID() == "dark")
		{
			gm.g.SetTheme(isDark: true);
		}
		if (tMP_LinkInfo.GetLinkID() == "en")
		{
			gm.g.SetLanguage(0);
		}
		if (tMP_LinkInfo.GetLinkID() == "zh")
		{
			gm.g.SetLanguage(1);
		}
		if (tMP_LinkInfo.GetLinkID() == "cht")
		{
			gm.g.SetLanguage(2);
		}
		if (tMP_LinkInfo.GetLinkID() == "jp")
		{
			gm.g.SetLanguage(3);
		}
		if (tMP_LinkInfo.GetLinkID() == "fullscreen")
		{
			gm.g.SetFullScreen(0);
		}
		if (tMP_LinkInfo.GetLinkID() == "windowed")
		{
			gm.g.SetFullScreen(1);
		}
		if (tMP_LinkInfo.GetLinkID() == "windowed2")
		{
			gm.g.SetFullScreen(2);
		}
		if (tMP_LinkInfo.GetLinkID().StartsWith("c"))
		{
			gm.LoadLevel(tMP_LinkInfo.GetLinkID());
		}
		if (tMP_LinkInfo.GetLinkID().StartsWith("X"))
		{
			int index = Convert.ToInt32(tMP_LinkInfo.GetLinkID().Substring(1));
			gm.g.ChooseCustomLevel(gm.g.custom_levels[index]);
		}
		if (tMP_LinkInfo.GetLinkID().StartsWith("Z"))
		{
			int id = Convert.ToInt32(tMP_LinkInfo.GetLinkID().Substring(1));
			gm.g.Editor(id);
		}
		if (tMP_LinkInfo.GetLinkID().StartsWith("Y"))
		{
			int index2 = Convert.ToInt32(tMP_LinkInfo.GetLinkID().Substring(1));
			gm.g.ChooseCustomLevel(gm.g.custom_levels_workshop[index2]);
		}
		if (tMP_LinkInfo.GetLinkID() == "url")
		{
			Process.Start(tMP_LinkInfo.GetLinkText());
		}
		if (tMP_LinkInfo.GetLinkID().StartsWith("pdf"))
		{
			int num2 = tMP_LinkInfo.GetLinkID()[3] - 48;
			UnityEngine.Debug.Log(num2);
			if (gm.g.setting.language == 0)
			{
				gm.g.OpenPDF("CourseReport" + num2 + ".pdf");
			}
			else if (gm.g.setting.language == 1)
			{
				gm.g.OpenPDF("CourseReport" + num2 + "CHS.pdf");
			}
			else if (gm.g.setting.language == 2)
			{
				gm.g.OpenPDF("CourseReport" + num2 + "CHT.pdf");
			}
			else if (gm.g.setting.language == 3)
			{
				gm.g.OpenPDF("CourseReport" + num2 + "JP.pdf");
			}
		}
		if (tMP_LinkInfo.GetLinkID() == "return")
		{
			gm.ChangeDisplay(gm.g.setting.last_chapter);
		}
	}
}
