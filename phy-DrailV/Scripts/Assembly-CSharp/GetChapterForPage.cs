using Bolt;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(ScriptableObject))]
[UnitCategory("Interaction")]
[UnitSubtitle("Get selectable chapter on a Booklet, for a given page")]
[UnitTitle("Get Chapter")]
public class GetChapterForPage : Unit
{
	[DoNotSerialize]
	public ValueInput bookletObject;

	[DoNotSerialize]
	public ValueInput pageIndex;

	[DoNotSerialize]
	public ValueOutput chapterIndex;

	protected override void Definition()
	{
		bookletObject = ValueInput<GameObject>("Booklet", null);
		pageIndex = ValueInput("Page", 0);
		chapterIndex = ValueOutput("Chapter", delegate(Flow flow)
		{
			GameObject value = flow.GetValue<GameObject>(bookletObject);
			ChapterSelector componentInChildren = value.GetComponentInChildren<ChapterSelector>();
			if (!componentInChildren)
			{
				Debug.LogError("Object " + value.name + " does not have a ChapterSelector component!", value);
				return -1;
			}
			return componentInChildren.GetBookmarkIndexFor(flow.GetValue<int>(pageIndex));
		});
		Requirement(bookletObject, chapterIndex);
		Requirement(pageIndex, chapterIndex);
	}
}
