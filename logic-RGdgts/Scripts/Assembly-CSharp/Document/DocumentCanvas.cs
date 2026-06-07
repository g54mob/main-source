using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Document
{
	public class DocumentCanvas : MonoBehaviour
	{
		public Material renderMaterial;

		private Canvas canvas;

		private CanvasScaler canvasScaler;

		private RectTransform rTransform;

		private Camera canvasCamera;

		public Transform scaledRootTransform;

		[HideInInspector]
		public RenderTexture rt;

		public List<DocumentPageContainer> docPageContainers;

		private int nActivePages;

		public DocumentLayout currentDocument;

		private DocumentPageContainer containerLeft;

		private DocumentPageContainer containerRight;

		private bool _init;

		public void Init()
		{
		}

		public void SetDocument(MagazineInfo info)
		{
		}

		private void SetSizePageContainer(int pageWidth, int pageHeight)
		{
		}

		private void ShowPage(int page)
		{
		}

		public void TurnBack()
		{
		}

		public void TurnForward()
		{
		}

		private void OnPagesChange()
		{
		}

		private void SetCameraAndRenderer()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
