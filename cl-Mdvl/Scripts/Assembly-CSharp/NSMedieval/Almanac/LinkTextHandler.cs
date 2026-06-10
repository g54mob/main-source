using System.Collections;
using NSEipix.Base;
using NSMedieval.Managers;
using NSMedieval.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NSMedieval.Almanac
{
	public class LinkTextHandler : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler
	{
		private TMP_MeshInfo[] cachedMeshInfoVertexData;

		private Camera cam;

		private Canvas canvas;

		private bool isHoveringLink;

		private Matrix4x4 matrix;

		private TextMeshProUGUI textMeshPro;

		private void Awake()
		{
			textMeshPro = base.gameObject.GetComponent<TextMeshProUGUI>();
			canvas = GetComponentInParent<Canvas>();
			if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
			{
				cam = null;
			}
			else
			{
				cam = canvas.worldCamera;
			}
		}

		private void OnEnable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(OnTextChanged);
		}

		private void OnDisable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(OnTextChanged);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (LinkIndex() != -1)
			{
				TMP_LinkInfo tMP_LinkInfo = textMeshPro.textInfo.linkInfo[LinkIndex()];
				string linkID = tMP_LinkInfo.GetLinkID();
				if (linkID.StartsWith("web_"))
				{
					MonoSingleton<WebLinkManager>.Instance.OpenLinkInBrowser(linkID);
				}
				else
				{
					MonoSingleton<UIController>.Instance.LinkClicked(linkID);
				}
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			StartCoroutine(TrackPointer());
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			isHoveringLink = false;
			StopCoroutine(TrackPointer());
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		private void OnMouseMove()
		{
		}

		private IEnumerator TrackPointer()
		{
			Vector3 mousePos = Vector3.zero;
			while (Application.isPlaying)
			{
				if (Input.mousePosition != mousePos)
				{
					OnMouseMove();
					mousePos = Input.mousePosition;
				}
				yield return 0;
			}
		}

		private int LinkIndex()
		{
			return TMP_TextUtilities.FindIntersectingLink(textMeshPro, Input.mousePosition, cam);
		}

		private void OnTextChanged(Object obj)
		{
			if (!(obj != textMeshPro))
			{
				cachedMeshInfoVertexData = textMeshPro.textInfo.CopyMeshInfoVertexData();
			}
		}
	}
}
