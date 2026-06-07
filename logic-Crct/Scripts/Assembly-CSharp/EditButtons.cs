using System;
using UnityEngine;
using UnityEngine.UI;

public class EditButtons : MonoBehaviour
{
	[Header("Viewport Mode")]
	public GameObject vpGameObject;

	public Image vpImage;

	public Text vpText;

	public string[] vpStrings;

	public Sprite[] vpSprites;

	private int vpMode;

	[Header("Tool")]
	public GameObject toolContainer;

	public Button method;

	public Button cancel;

	public Button finish;

	public Button color;

	public Button delete;

	public Button properties;

	public Text finishText;

	public Text componentName;

	[Header("Desktop Buttons")]
	public Button tr_cancel;

	public Button tr_finish;

	public Button tr_delete;

	public RectTransform tr_anchor;

	public RectTransform tr_container;

	public Text finishButtonText;

	public static bool Displayed;

	private bool hasWorldAnchor;

	private Vector3 worldAnchor;

	private Action deleteAction;

	private Action cancelAction;

	private Action confirmAction;

	public static float ScalingFactor;

	private static EditButtons inst { get; set; }

	private void Awake()
	{
	}

	public void ToggleViewportMode()
	{
	}

	public void SetViewportMode(int i)
	{
	}

	public static void HideViewportMode()
	{
	}

	public static void ShowViewportMode()
	{
	}

	public static void ShowConfirmCancel(Action finishedAction, Action cancelAction, string text = null, string name = "")
	{
	}

	public static void ShowConfirmCancelProperties(Action finishedAction, Action cancelAction, Action propertyAction, string text = null, string name = "")
	{
	}

	public static void Hide()
	{
	}

	public static void ShowConfirmCancelDelete(Action finishedAction, Action cancelAction, Action deleteAction, string name = "")
	{
	}

	public static void ShowConfirmCancelDeleteProperties(Action finishedAction, Action cancelAction, Action deleteAction, Action propertyAction, string name = "")
	{
	}

	public static void HideConfirmCancelDelete()
	{
	}

	public static void ShowJumperWireCreate(Action methodAction, Action cancelAction, Action finishedAction, Action colorAction, string name = "")
	{
	}

	public static void ShowJumperWireEdit(Action colorAction, Action deleteAction, string name = "")
	{
	}

	public static void HideWireTools()
	{
	}

	public static void ShowPassiveCreate(Action methodAction, Action cancelAction, Action finishedAction, Action propertyAction, string name = "")
	{
	}

	public static void ShowPassiveEdit(Action propertyAction, Action deleteAction, string name = "")
	{
	}

	public static void ShowLEDCreate(Action methodAction, Action colorAction, Action cancelAction, Action finishedAction, Action propertyAction, string name = "")
	{
	}

	public static void ShowLEDEdit(Action colorAction, Action propertyAction, Action deleteAction, string name = "")
	{
	}

	public static void HideTransformButtons()
	{
	}

	public static void ShowTransformCancelFinish(Action confirmAction, Action cancelAction, string finishString = "")
	{
	}

	public static void ShowTransformDeleteCancelFinish(Action confirmAction, Action cancelAction, Action deleteAction)
	{
	}

	public static void ShowWireCancel(Action cancelAction, Vector3 worldAnchorPosition)
	{
	}

	public static void ShowWireDelete(Action deleteAction, Vector3 worldAnchorPosition)
	{
	}

	public static void UpdateWireCancel(Vector3 worldAnchorPosition)
	{
	}

	private void Update()
	{
	}

	public static void DeleteAction()
	{
	}

	public static void CancelAction()
	{
	}

	public static void ConfirmAction()
	{
	}
}
