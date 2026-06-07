using Rewired;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class CenterTargetInScrollView : MonoBehaviour
{
	[SerializeField]
	private ScrollRect scrollRect;

	[SerializeField]
	private Canvas canvas;

	[SerializeField]
	private RawImage mapImage;

	private Material mat_Map;

	private Vector3 startScreenPos;

	private Vector3 curScreenPos;

	private float screenRatio;

	private float screenMoveSpeed;

	private bool isKeydown;

	public float scrollSpeed;

	private GameObject lastSelected;

	private Vector2 scrollRectTargetAnchorPos;

	private bool doLockToSelectedNode;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnInputSourceChanged(ControllerType type)
	{
	}

	private void Update()
	{
	}

	public void CenterOnItem(RectTransform target, bool isImmediate = false)
	{
	}
}
