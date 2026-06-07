using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
	private GraphicRaycaster m_Raycaster;

	private PointerEventData m_PointerEventData;

	private EventSystem m_EventSystem;

	private List<RaycastResult> results = new List<RaycastResult>();

	public int maxDepthCheck = 5;

	private SelectHighlighter selHigh;

	private Transform res;

	private HoverShow hoverShow;

	private HoverObj hoverObj;

	private AlgoBlockDrag drag;

	private LevelTreeController lvl;

	private BuyBlock bb;

	private Selectable sel;

	private BlockData block;

	private LidarBinarySwitch lidarBinraySwitcher;

	private void Start()
	{
		m_Raycaster = GetComponent<GraphicRaycaster>();
		m_EventSystem = GetComponent<EventSystem>();
	}

	public GameObject RayCastFromPoint(Vector3 position, bool dragCheck = false)
	{
		m_PointerEventData = new PointerEventData(m_EventSystem);
		m_PointerEventData.position = position;
		results.Clear();
		m_Raycaster.Raycast(m_PointerEventData, results);
		if (results.Count == 0)
		{
			return null;
		}
		res = results[0].gameObject.transform;
		int num = 0;
		while (res.parent != null)
		{
			if (!res.gameObject.activeInHierarchy)
			{
				return null;
			}
			if (res.gameObject.activeInHierarchy && res.gameObject.layer == 11)
			{
				return null;
			}
			num++;
			if (!dragCheck)
			{
				selHigh = res.gameObject.GetComponent<SelectHighlighter>();
				if (selHigh != null)
				{
					if (selHigh.gameObject.activeInHierarchy && !selHigh.enabled && res.gameObject.layer != 13)
					{
						return null;
					}
					if (selHigh.enabled)
					{
						return res.gameObject;
					}
				}
				hoverShow = res.gameObject.GetComponent<HoverShow>();
				if (hoverShow != null)
				{
					return res.gameObject;
				}
				hoverObj = res.gameObject.GetComponent<HoverObj>();
				if (hoverObj != null)
				{
					return res.gameObject;
				}
				drag = res.gameObject.GetComponent<AlgoBlockDrag>();
				if (drag != null)
				{
					return res.gameObject;
				}
				if (Logic.GetController().Tree.gameObject.activeSelf)
				{
					lvl = res.gameObject.GetComponent<LevelTreeController>();
					if (lvl != null)
					{
						return res.gameObject;
					}
				}
				if (Logic.GetController().buy.gameObject.activeInHierarchy)
				{
					bb = res.gameObject.GetComponent<BuyBlock>();
					if (bb != null)
					{
						return res.gameObject;
					}
				}
			}
			sel = res.gameObject.GetComponent<Selectable>();
			if (sel != null && sel.enabled)
			{
				if (sel.interactable)
				{
					if (dragCheck)
					{
						selHigh = res.gameObject.GetComponent<SelectHighlighter>();
						if (selHigh != null)
						{
							return null;
						}
					}
					return res.gameObject;
				}
				return null;
			}
			if (Logic.GetController().construction.gameObject.activeSelf)
			{
				block = res.gameObject.GetComponent<BlockData>();
				if (block != null && block.enabled && !block.dummy)
				{
					return res.gameObject;
				}
				lidarBinraySwitcher = res.gameObject.GetComponent<LidarBinarySwitch>();
				if (lidarBinraySwitcher != null && lidarBinraySwitcher.enabled && lidarBinraySwitcher.gameObject.activeInHierarchy)
				{
					return res.gameObject;
				}
			}
			res = res.parent;
			if (num >= maxDepthCheck)
			{
				return null;
			}
		}
		return null;
	}
}
