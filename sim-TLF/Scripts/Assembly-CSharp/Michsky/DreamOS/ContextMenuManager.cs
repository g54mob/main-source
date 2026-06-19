using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Michsky.DreamOS
{
	public class ContextMenuManager : MonoBehaviour
	{
		public enum CameraSource
		{
			Main = 0,
			Custom = 1
		}

		public enum CursorBoundHorizontal
		{
			Left = 0,
			Right = 1
		}

		public enum CursorBoundVertical
		{
			Bottom = 0,
			Top = 1
		}

		[SerializeField]
		private Canvas targetCanvas;

		[SerializeField]
		private Camera targetCamera;

		[SerializeField]
		private GameObject menuPreset;

		public GameObject buttonPreset;

		public GameObject separatorPreset;

		public bool enableBlur = true;

		public bool autoSubMenuPosition = true;

		public CameraSource cameraSource;

		public CursorBoundHorizontal horizontalBound;

		public CursorBoundVertical verticalBound = CursorBoundVertical.Top;

		[SerializeField]
		[Range(-50f, 50f)]
		private int vBorderTop = -10;

		[SerializeField]
		[Range(-50f, 50f)]
		private int vBorderBottom = 10;

		[SerializeField]
		[Range(-50f, 50f)]
		private int hBorderLeft = 15;

		[SerializeField]
		[Range(-50f, 50f)]
		private int hBorderRight = -15;

		private Vector2 uiPos;

		private Vector3 cursorPos;

		private Vector3 contentPos = new Vector3(0f, 0f, 0f);

		private Vector3 contextVelocity = Vector3.zero;

		private float cachedStateLength = 0.5f;

		private ContextMenu generatedCM;

		private RectTransform contextRect;

		private Animator contextAnimator;

		private UIBlur contextBlur;

		[HideInInspector]
		public bool isOn;

		[HideInInspector]
		public RectTransform contentRect;

		private void Awake()
		{
			if (targetCanvas == null)
			{
				targetCanvas = base.gameObject.GetComponentInParent<Canvas>();
			}
			if (cameraSource == CameraSource.Main)
			{
				targetCamera = Camera.main;
			}
			GameObject gameObject = Object.Instantiate(menuPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
			gameObject.transform.SetParent(targetCanvas.transform, worldPositionStays: false);
			gameObject.transform.SetAsLastSibling();
			generatedCM = gameObject.GetComponent<ContextMenu>();
			generatedCM.manager = this;
			contextAnimator = generatedCM.animator;
			contextRect = generatedCM.mainRect;
			contentRect = generatedCM.contentRect;
			if (enableBlur && generatedCM.blur != null)
			{
				contextBlur = generatedCM.blur;
			}
			contentPos = new Vector3(vBorderTop, hBorderLeft, 0f);
			cachedStateLength = DreamOSInternalTools.GetAnimatorClipLength(contextAnimator, "ContextMenu_In") + 0.1f;
			generatedCM.gameObject.SetActive(value: false);
		}

		public void CheckForBounds()
		{
			if (uiPos.x <= -100f)
			{
				horizontalBound = CursorBoundHorizontal.Left;
				contentPos = new Vector3(hBorderLeft, contentPos.y, 0f);
				contentRect.pivot = new Vector2(0f, contentRect.pivot.y);
			}
			else if (uiPos.x >= 100f)
			{
				horizontalBound = CursorBoundHorizontal.Right;
				contentPos = new Vector3(hBorderRight, contentPos.y, 0f);
				contentRect.pivot = new Vector2(1f, contentRect.pivot.y);
			}
			else
			{
				horizontalBound = CursorBoundHorizontal.Left;
				contentPos = new Vector3(hBorderLeft, contentPos.y, 0f);
				contentRect.pivot = new Vector2(0f, contentRect.pivot.y);
			}
			if (uiPos.y <= -75f)
			{
				verticalBound = CursorBoundVertical.Bottom;
				contentPos = new Vector3(contentPos.x, vBorderBottom, 0f);
				contentRect.pivot = new Vector2(contentRect.pivot.x, 0f);
			}
			else if (uiPos.y >= 75f)
			{
				verticalBound = CursorBoundVertical.Top;
				contentPos = new Vector3(contentPos.x, vBorderTop, 0f);
				contentRect.pivot = new Vector2(contentRect.pivot.x, 1f);
			}
			else
			{
				verticalBound = CursorBoundVertical.Top;
				contentPos = new Vector3(contentPos.x, vBorderTop, 0f);
				contentRect.pivot = new Vector2(contentRect.pivot.x, 1f);
			}
		}

		public void SetContextMenuPosition()
		{
			cursorPos = Mouse.current.position.ReadValue();
			if (targetCanvas.renderMode == RenderMode.ScreenSpaceCamera || targetCanvas.renderMode == RenderMode.WorldSpace)
			{
				contextRect.position = targetCamera.ScreenToWorldPoint(cursorPos);
				contextRect.localPosition = new Vector3(contextRect.localPosition.x, contextRect.localPosition.y, 0f);
				contentRect.transform.localPosition = Vector3.SmoothDamp(contentRect.transform.localPosition, contentPos, ref contextVelocity, 0f);
			}
			else if (targetCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
			{
				contextRect.position = cursorPos;
				contentRect.transform.position = new Vector3(cursorPos.x + contentPos.x, cursorPos.y + contentPos.y, 0f);
			}
			uiPos = contextRect.anchoredPosition;
			CheckForBounds();
		}

		public void SetFixedPosition()
		{
			cursorPos = Mouse.current.position.ReadValue();
			SetContextMenuPosition();
			if (targetCanvas.renderMode == RenderMode.ScreenSpaceCamera || targetCanvas.renderMode == RenderMode.WorldSpace)
			{
				contextRect.position = targetCamera.ScreenToWorldPoint(cursorPos);
				contextRect.localPosition = new Vector3(contextRect.localPosition.x, contextRect.localPosition.y, 0f);
				contentRect.transform.localPosition = Vector3.SmoothDamp(contentRect.transform.localPosition, contentPos, ref contextVelocity, 0f);
			}
			else if (targetCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
			{
				contextRect.position = cursorPos;
				contentRect.transform.position = new Vector3(cursorPos.x + contentPos.x, cursorPos.y + contentPos.y, 0f);
			}
			uiPos = contextRect.anchoredPosition;
			CheckForBounds();
		}

		private void ProcessContextRect()
		{
			if (targetCanvas.renderMode == RenderMode.ScreenSpaceCamera || targetCanvas.renderMode == RenderMode.WorldSpace)
			{
				contextRect.position = targetCamera.ScreenToWorldPoint(cursorPos);
				contextRect.localPosition = new Vector3(contextRect.localPosition.x, contextRect.localPosition.y, 0f);
				contentRect.transform.localPosition = Vector3.SmoothDamp(contentRect.transform.localPosition, contentPos, ref contextVelocity, 0f);
			}
			else if (targetCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
			{
				contextRect.position = cursorPos;
				contentRect.transform.position = new Vector3(cursorPos.x + contentPos.x, cursorPos.y + contentPos.y, 0f);
			}
		}

		public void Open()
		{
			isOn = true;
			contextAnimator.enabled = true;
			generatedCM.gameObject.SetActive(value: true);
			if (enableBlur && contextBlur != null)
			{
				contextBlur.BlurInAnim();
			}
			contextAnimator.Play("In");
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator", false);
		}

		public void Close()
		{
			isOn = false;
			contextAnimator.enabled = true;
			if (enableBlur && contextBlur != null)
			{
				contextBlur.BlurOutAnim();
			}
			contextAnimator.Play("Out");
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator", true);
		}

		public void OpenInFixedPosition()
		{
			SetFixedPosition();
			Open();
		}

		private IEnumerator DisableAnimator(bool disableObject)
		{
			yield return new WaitForSeconds(cachedStateLength);
			contextAnimator.enabled = false;
			if (disableObject)
			{
				generatedCM.gameObject.SetActive(value: false);
			}
		}
	}
}
