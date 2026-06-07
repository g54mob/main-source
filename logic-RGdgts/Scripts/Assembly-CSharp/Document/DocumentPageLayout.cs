using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Document
{
	[ExecuteInEditMode]
	public class DocumentPageLayout : MonoBehaviour
	{
		public bool setBackground;

		public DocumentImage background;

		[ReadOnly]
		public PageOrientation orientation;

		public int pageNumber;

		public List<DocumentText> pageTexts;

		public List<DocumentImage> pageImages;

		public DocumentPageBorder pageBorder;

		public bool customPage;

		public void SetPageNumberAndOrientationSO(int pageNumber)
		{
		}

		public void InitPageInPrefab(PageData data, DocumentText textTemplate, DocumentText retroTextTemplate, DocumentImage imageTemplate)
		{
		}

		private void SetTextAndImagesInPrefab(PageData data, DocumentText textTemplate, DocumentText retroTextTemplate, DocumentImage imageTemplate)
		{
		}

		private void SetTextInPrefab(PageData data, DocumentText textTemplate, DocumentText retroTextTemplate)
		{
		}

		private void SetImagesInPrefab(PageData data, DocumentImage imageTemplate)
		{
		}
	}
}
