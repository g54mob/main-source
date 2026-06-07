using UnityEngine;

public class CModsManager : MonoBehaviour
{
	public GameObject cModRowPrefab;

	public GameObject modListContent;

	public CModSectionManager cModSection;

	public CModPreview cModPreview;

	private CMod _activeCMod;

	public CMod activeCMod
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void OnAdd()
	{
	}

	public void OnClone()
	{
	}

	public void OnSelectRow(CMod mod)
	{
	}

	public void RefreshRowName(CMod mod, string val)
	{
	}

	public void Refresh()
	{
	}

	public static void DestroyChildren(Transform transform)
	{
	}
}
