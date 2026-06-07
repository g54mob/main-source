using System.Collections.Generic;

public class ContentScreenData
{
	public RuleBookScreenData screen;

	public List<PageContentLink> pageContentLinks;

	public List<PageContentLink> leftLinks;

	public List<PageContentLink> rightLinks;

	public ContentScreenData(RuleBookScreenData screen, List<PageContentLink> pageContentLinks, List<PageContentLink> leftLinks, List<PageContentLink> rightLinks)
	{
		this.screen = screen;
		this.pageContentLinks = pageContentLinks;
		this.leftLinks = leftLinks;
		this.rightLinks = rightLinks;
	}
}
