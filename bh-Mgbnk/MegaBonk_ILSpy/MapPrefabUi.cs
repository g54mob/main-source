using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapPrefabUi : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	public RawImage i_map;

	public TextMeshProUGUI t_name;

	private MapData mapData;

	public static Action<MapData> A_SelectMap;

	public void SetMap(MapData mapData)
	{
		this.mapData = mapData;
		i_map.texture = mapData.icon;
		string text = mapData.GetName();
		t_name.text = text;
	}

	public void OnSelect(BaseEventData eventData)
	{
		Action<MapData> a_SelectMap = A_SelectMap;
		if (A_SelectMap != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v29 @ rax_v3 (System.Action`1<MapData>)+18] (should have been resolved before IL gen)");
		}
	}
}
