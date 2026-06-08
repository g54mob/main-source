using Dorfromantik.Area;
using UnityEngine;

public class SceneOrganizer : MonoBehaviour
{
	public static SceneOrganizer Instance;

	[SerializeField]
	private Transform tileContainer;

	[SerializeField]
	private Transform elementGroupContainer;

	[SerializeField]
	private Transform areaSlotContainer;

	[SerializeField]
	private Transform areaContainer;

	[SerializeField]
	private Transform sectionContainer;

	private void Awake()
	{
		Instance = this;
	}

	public void SortInContainer(MonoBehaviour obj)
	{
		if (obj is Tile)
		{
			obj.transform.SetParent(tileContainer);
		}
		else if (obj is ElementGroup)
		{
			obj.transform.SetParent(elementGroupContainer);
		}
		else if (obj is AreaSlot)
		{
			obj.transform.SetParent(areaSlotContainer);
		}
		else if (obj is Area || obj is Section_Area)
		{
			obj.transform.SetParent(areaContainer);
		}
		else if (obj is Section)
		{
			obj.transform.SetParent(sectionContainer);
		}
	}
}
