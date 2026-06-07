using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
	[SerializeField]
	private Canvas canvas;

	[SerializeField]
	private List<AUI> list_UIReferences;

	[SerializeField]
	private List<CanvasGroup> list_HideCanvasGroupsForCinematic;

	[SerializeField]
	private Transform node_PopupUIAnchor_SystemTopLayer;

	[FormerlySerializedAs("node_PopupUIAnchor_TopLevel")]
	[SerializeField]
	private Transform node_PopupUIAnchor_TopLayer;

	[FormerlySerializedAs("node_PopupUIAnchor_MidLevel")]
	[SerializeField]
	private Transform node_PopupUIAnchor_MidLayer;

	[SerializeField]
	private Transform node_DynamicUIAnchor;

	[SerializeField]
	private List<MonoBehaviour> stack_PopupWindows;

	private Dictionary<string, AUI> dic_UIReferences;

	private bool isInCinematic;

	public Transform PopupUIAnchor_SystemTopLevel => null;

	public Transform PopupUIAnchor_TopLevel => null;

	public Transform PopupUIAnchor_MidLevel => null;

	private void OnValidate()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnSetIsInCinematic(bool isInCinematic)
	{
	}

	protected override void Awake()
	{
	}

	public Transform GetDynamicUIAnchor()
	{
		return null;
	}

	public AUI GetUI(string name)
	{
		return null;
	}

	public T GetUI<T>() where T : AUI
	{
		return null;
	}

	public void RegisterUI(AUI ui)
	{
	}

	public Canvas GetCanvas()
	{
		return null;
	}

	public float GetCanvasScale()
	{
		return 0f;
	}

	public void RegisterUIWindowStack(MonoBehaviour window)
	{
	}

	public void UnregisterUIWindowStack(MonoBehaviour window)
	{
	}

	public bool IsTopPopupWindow(APopupWindow window)
	{
		return false;
	}

	public bool HasAnyPopupWindow()
	{
		return false;
	}

	public static void SelectItem(Selectable item)
	{
	}

	public static void DeselectAllItems()
	{
	}
}
