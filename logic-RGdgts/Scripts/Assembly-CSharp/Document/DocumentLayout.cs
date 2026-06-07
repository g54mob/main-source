using System.Collections.Generic;
using UnityEngine;

namespace Document
{
	public class DocumentLayout : MonoBehaviour
	{
		public List<DocumentPageLayout> pages;

		public RectTransform frontPages;

		public RectTransform backPages;

		public DocumentText textTemplate;

		public DocumentText retroTextTemplate;

		public DocumentImage imageTemplate;

		public void Init(DocumentData data)
		{
		}

		public void HidePages()
		{
		}
	}
}
