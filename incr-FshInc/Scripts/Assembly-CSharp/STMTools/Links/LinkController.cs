using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;

namespace STMTools.Links
{
	[ExecuteInEditMode]
	public class LinkController : MonoBehaviour
	{
		public SuperTextMesh superTextMesh;

		[Tooltip("If this value is set to 'link', this means that the full tag will be '<link=myLinkLabel>")]
		public string linkString = "link";

		[Tooltip("Additional style to be applied automatically to link text. If set to anything besides an empty string, all tags will be cleared after a link.")]
		public string tagStyle = "<c=blue>";

		[Tooltip("Additional space added to collider size.")]
		public Vector2 padding = new Vector2(0.1f, 0f);

		[Tooltip("These labels will be matched, and objects with the specified UnityEvent will be created.")]
		public List<Link> links = new List<Link>();

		private List<LinkObject> linkObjects = new List<LinkObject>();

		private LinkObject currentLinkObject;

		public UnityEvent onEnter;

		public UnityEvent onExit;

		private int hoverThis = -1;

		public void PreparseTags(STMTextContainer x)
		{
			string pattern = "<(?<label>" + linkString + ")=(?<tag>.+?)>";
			string text = "<e2=${label},${tag}>";
			string pattern2 = "</(?<label>" + linkString + ")>";
			string text2 = "</e2>";
			if (tagStyle.Length > 0)
			{
				text += tagStyle;
				text2 += "<clear>";
			}
			x.text = Regex.Replace(x.text, pattern, text, RegexOptions.Multiline);
			x.text = Regex.Replace(x.text, pattern2, text2, RegexOptions.Multiline);
		}

		internal void EnterLink(int index)
		{
			hoverThis = index;
		}

		internal void ExitLink(int index)
		{
			hoverThis = -1;
		}

		private void Reset()
		{
			superTextMesh = GetComponent<SuperTextMesh>();
		}

		private void OnEnable()
		{
			superTextMesh.OnPreParse += PreparseTags;
			if (Application.isPlaying)
			{
				superTextMesh.OnCustomEvent += GenerateLink;
				superTextMesh.OnRebuildEvent += ClearLinks;
			}
		}

		private void OnDisable()
		{
			superTextMesh.OnPreParse -= PreparseTags;
			if (Application.isPlaying)
			{
				superTextMesh.OnCustomEvent -= GenerateLink;
				superTextMesh.OnRebuildEvent -= ClearLinks;
			}
		}

		public void ClearLinks()
		{
			for (int i = 0; i < linkObjects.Count; i++)
			{
				Object.Destroy(linkObjects[i].go);
			}
			linkObjects.Clear();
			currentLinkObject = null;
		}

		public void GenerateLink(string text, STMTextInfo info)
		{
			string[] splitText = text.Split(',');
			if (splitText.Length != 2 || !(splitText[0] == "link"))
			{
				return;
			}
			Link link = links.Find((Link x) => x.label == splitText[1]);
			if (link == null)
			{
				Debug.Log("No link with tag '" + splitText[1] + "' found!");
				return;
			}
			int num = links.IndexOf(link);
			float num2 = superTextMesh.lineHeights[info.line];
			CharInfo charInfo = new CharInfo(info.pos.x - padding.x, info.pos.y - padding.y, info.BottomRightVert.x + padding.x, info.pos.y + num2 + padding.y, info.line, num, info.rawIndex);
			if (currentLinkObject != null)
			{
				if (currentLinkObject.bounds.min.y == charInfo.bounds.min.y && currentLinkObject.lastCharacterIndex == info.rawIndex - 1 && currentLinkObject.linkIndex == num)
				{
					currentLinkObject.Encapsulate(charInfo);
				}
				else
				{
					currentLinkObject = null;
				}
			}
			if (currentLinkObject == null)
			{
				GameObject gameObject = new GameObject();
				LinkObject linkObject = ((!superTextMesh.uiMode) ? ((LinkObject)gameObject.AddComponent<LinkCollider2D>()) : ((LinkObject)gameObject.AddComponent<LinkObjectUI>()));
				linkObject.Initialize(charInfo, this, "Link for tag '" + splitText[1] + "' at index " + info.rawIndex + " with character " + info.character, links[num], onEnter, onExit);
				linkObjects.Add(linkObject);
				currentLinkObject = linkObject;
			}
		}
	}
}
