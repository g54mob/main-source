using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class RulebookTableOfContents : MonoBehaviour
{
	public int ruleCountPerContentPage;

	public Vector3 startPositionLeft;

	public Vector3 offsetPositionLeft;

	public GameObject linkPrefab;

	public List<ContentScreenData> contentScreens = new List<ContentScreenData>();

	public LocalizedSprite contentsPageSprite0;

	public LocalizedSprite contentsPageSprite1;

	public LocalizedString contentsRuleBreakString;

	public List<RuleBookScreenData> GenerateTableOfContents(List<RuleBookScreenData> ruleBookScreens, Transform bookTransform)
	{
		int num = Mathf.CeilToInt((float)Mathf.CeilToInt((float)ruleBookScreens.Count * 2f / (float)ruleCountPerContentPage) / 2f);
		int num2 = 0;
		int num3 = 0;
		List<RuleBookScreenData> list = new List<RuleBookScreenData>();
		for (int i = 0; i < num; i++)
		{
			RuleBookScreenData ruleBookScreenData = ScriptableObject.CreateInstance<RuleBookScreenData>();
			ruleBookScreenData.isTableOfContents = true;
			List<PageContentLink> list2 = new List<PageContentLink>();
			List<PageContentLink> list3 = new List<PageContentLink>();
			List<PageContentLink> list4 = new List<PageContentLink>();
			for (int j = 0; j < ruleCountPerContentPage * 2; j++)
			{
				if (num3 >= ruleBookScreens.Count * 2)
				{
					break;
				}
				PageContentLink component = Object.Instantiate(linkPrefab, bookTransform.position, Quaternion.identity, bookTransform).GetComponent<PageContentLink>();
				RuleBookPage pageByLinkIndex = GetPageByLinkIndex(num3, ruleBookScreens);
				component.rulebookScreen = GetScreenByLinkIndex(num3, ruleBookScreens);
				component.ruleBookPage = pageByLinkIndex;
				list2.Add(component);
				if (j < ruleCountPerContentPage)
				{
					component.linkSpriteRenderer.sprite = pageByLinkIndex.contentSprites[0];
					list3.Add(component);
				}
				else
				{
					component.linkSpriteRenderer.sprite = pageByLinkIndex.contentSprites[1];
					list4.Add(component);
				}
				num3++;
			}
			for (int k = 0; k < 2; k++)
			{
				RuleBookPage item = GenerateContentPage(num2, k);
				ruleBookScreenData.ruleBookPages.Add(item);
				num2++;
			}
			ContentScreenData item2 = new ContentScreenData(ruleBookScreenData, list2, list3, list4);
			contentScreens.Add(item2);
			list.Add(ruleBookScreenData);
		}
		foreach (ContentScreenData contentScreen in contentScreens)
		{
			PositionLinks(contentScreen.pageContentLinks);
		}
		return list;
	}

	public RuleBookPage GenerateContentPage(int index, int side)
	{
		RuleBookPage ruleBookPage = new RuleBookPage();
		ruleBookPage.pageID = "page_contents_" + index;
		if (side == 0)
		{
			ruleBookPage.localizedSprite = contentsPageSprite0;
		}
		else
		{
			ruleBookPage.localizedSprite = contentsPageSprite1;
		}
		ruleBookPage.ruleCheatReason = ChessMatchManager.ChessCheatReason.Null;
		ruleBookPage.ruleCheatScore = 0;
		ruleBookPage.ruleBreakString = contentsRuleBreakString;
		ruleBookPage.checkForSpecificPiece = false;
		ruleBookPage.ruleSpecificPiece = ChessPieceData.ChessPieceType.Null;
		ruleBookPage.checkForSpecificFogPiece = false;
		ruleBookPage.clearFogPiece = ChessPieceData.ChessPieceType.Null;
		ruleBookPage.turnsToClearFog = 0;
		return ruleBookPage;
	}

	public void PositionLinks(List<PageContentLink> pageContentLinks)
	{
		Vector3 localPosition = startPositionLeft;
		for (int i = 0; i < ruleCountPerContentPage; i++)
		{
			if (i < pageContentLinks.Count)
			{
				pageContentLinks[i].gameObject.transform.localPosition = localPosition;
				pageContentLinks[i].gameObject.SetActive(value: false);
			}
			if (i + ruleCountPerContentPage < pageContentLinks.Count)
			{
				pageContentLinks[i + ruleCountPerContentPage].gameObject.transform.localPosition = new Vector3(0f - localPosition.x, localPosition.y, localPosition.z);
				pageContentLinks[i + ruleCountPerContentPage].gameObject.SetActive(value: false);
			}
			localPosition += offsetPositionLeft;
		}
	}

	public void EnableLinksByScreen(RuleBookScreenData screen, bool doRight)
	{
		ContentScreenData contentScreenData = null;
		foreach (ContentScreenData contentScreen in contentScreens)
		{
			if (contentScreen.screen == screen)
			{
				contentScreenData = contentScreen;
				break;
			}
		}
		if (doRight)
		{
			foreach (PageContentLink rightLink in contentScreenData.rightLinks)
			{
				rightLink.gameObject.SetActive(value: true);
			}
			return;
		}
		foreach (PageContentLink leftLink in contentScreenData.leftLinks)
		{
			leftLink.gameObject.SetActive(value: true);
		}
	}

	public void DisableLinkByScreen(RuleBookScreenData screen, bool doRight)
	{
		ContentScreenData contentScreenData = null;
		foreach (ContentScreenData contentScreen in contentScreens)
		{
			if (contentScreen.screen == screen)
			{
				contentScreenData = contentScreen;
				break;
			}
		}
		if (doRight)
		{
			foreach (PageContentLink rightLink in contentScreenData.rightLinks)
			{
				rightLink.gameObject.SetActive(value: false);
				rightLink.StopHover();
			}
			return;
		}
		foreach (PageContentLink leftLink in contentScreenData.leftLinks)
		{
			leftLink.gameObject.SetActive(value: false);
			leftLink.StopHover();
		}
	}

	private RuleBookPage GetPageByLinkIndex(int index, List<RuleBookScreenData> ruleBookScreens)
	{
		int num = Mathf.FloorToInt((float)index / 2f);
		int index2 = index - num * 2;
		return ruleBookScreens[num].ruleBookPages[index2];
	}

	private RuleBookScreenData GetScreenByLinkIndex(int index, List<RuleBookScreenData> ruleBookScreens)
	{
		int index2 = Mathf.FloorToInt((float)index / 2f);
		return ruleBookScreens[index2];
	}
}
