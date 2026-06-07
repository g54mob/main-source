using Bolt;
using DV.CabControls;
using Ludiq;
using UnityEngine;

[UnitTitle("Get Bookmark")]
[TypeIcon(typeof(ScriptableObject))]
[UnitCategory("Interaction")]
[UnitSubtitle("Get transform and offset from a ChapterSelector")]
public class GetChapterSelectorBookmark : Unit
{
	[DoNotSerialize]
	public ValueInput bookletObject;

	[DoNotSerialize]
	public ValueInput chapterIndex;

	[DoNotSerialize]
	public ValueOutput bookmarkAnchor;

	[DoNotSerialize]
	public ValueOutput bookmarkOffset;

	protected override void Definition()
	{
		bookletObject = ValueInput<GameObject>("Booklet", null);
		chapterIndex = ValueInput("Chapter", 0);
		bookmarkAnchor = ValueOutput("Anchor", (Flow flow) => GetTouchscreen(flow.GetValue<GameObject>(bookletObject), out var touchscreen) ? touchscreen.transform.gameObject : null);
		bookmarkOffset = ValueOutput("Offset", delegate(Flow flow)
		{
			if (GetTouchscreen(flow.GetValue<GameObject>(bookletObject), out var touchscreen))
			{
				int value = flow.GetValue<int>(chapterIndex);
				return touchscreen.SectionLocalCenter(new Vector2Int(value, 0));
			}
			return Vector3.zero;
		});
		Requirement(bookletObject, bookmarkAnchor);
		Requirement(bookletObject, bookmarkOffset);
		Requirement(chapterIndex, bookmarkAnchor);
		Requirement(chapterIndex, bookmarkOffset);
	}

	private static bool GetTouchscreen(GameObject booklet, out TouchscreenBase touchscreen)
	{
		ChapterSelector componentInChildren = booklet.GetComponentInChildren<ChapterSelector>();
		if (!componentInChildren)
		{
			Debug.LogError("Object " + booklet.name + " does not have a ChapterSelector component!", booklet);
			touchscreen = null;
			return false;
		}
		touchscreen = componentInChildren.BookmarksTouchscreen;
		if (!componentInChildren)
		{
			Debug.LogError("Object " + booklet.name + " does not have a TouchscreenBase component!", booklet);
			touchscreen = null;
			return false;
		}
		return true;
	}
}
