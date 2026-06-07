using UnityEngine;
using UnityEngine.UI;

public class UI_Cursor : MonoBehaviour
{
	[SerializeField]
	private Image image_CursorLine_Vertical;

	[SerializeField]
	private Image image_CursorLine_Horizontal;

	[SerializeField]
	private Camera uiCamera;

	[SerializeField]
	private RectTransform canvasTransform;

	[SerializeField]
	private Vector2 offset;

	private bool isCursorSupportLineOn;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnGameSettingChanged()
	{
	}

	private void SetupCursorSupportLine(bool isOn)
	{
	}

	private void Update()
	{
	}
}
