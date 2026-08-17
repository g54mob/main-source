using System.Collections.Generic;
using Assets.Scripts._Data.Tomes;
using UnityEngine;
using UnityEngine.UI;

public class TomeSynergiesUi : MonoBehaviour
{
	public RawImage iconPrefab;

	private List<RawImage> iconPrefabs;

	public void Set(ETome eTome)
	{
	}

	public TomeSynergiesUi()
	{
		List<RawImage> list = new List<RawImage>();
		iconPrefabs = list;
		base._002Ector();
	}
}
