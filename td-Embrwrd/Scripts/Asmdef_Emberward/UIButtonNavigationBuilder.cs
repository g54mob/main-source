using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[ExecuteAlways]
public class UIButtonNavigationBuilder : MonoBehaviour
{
	public enum LayoutDirection
	{
		Vertical = 0,
		Horizontal = 1
	}

	[Header("按鈕列表")]
	[Tooltip("把這個選單裡『可能會被選到』的按鈕都丟進來")]
	[FormerlySerializedAs("buttons")]
	public List<Selectable> list_Selectables;

	[Header("排列方式")]
	public LayoutDirection direction;

	[Header("是否限制ControlScheme")]
	public bool restrictControlScheme;

	public eControlScheme controlScheme;

	[Tooltip("如果為 true，第一個按鈕往上會選到最後一個；最後一個往下會選到第一個")]
	[Header("是否循環選擇")]
	public bool loop;

	[Tooltip("若為 true，會自動略過 inactive 或不可互動的按鈕")]
	[Header("過濾條件")]
	public bool skipInactiveOrNonInteractable;

	[Header("如果有指定的話，左邊的目標會放這個物件")]
	public List<Selectable> list_leftSelectables;

	public List<Selectable> list_rightSelectables;

	public List<Selectable> list_downSelectables;

	public List<Selectable> list_upSelectables;

	private int lastRebuildActiveItemCount;

	public void Rebuild()
	{
	}

	private Selectable GetItemWithClosestX(Selectable origin, List<Selectable> list_Candidates)
	{
		return null;
	}

	private Selectable GetItemWithClosestY(Selectable origin, List<Selectable> list_Candidates)
	{
		return null;
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}
}
