using UnityEngine;

namespace SkywardRay.FileBrowser
{
	public class SfbEntryWrapper : MonoBehaviour
	{
		public SfbFileSystemEntry fileSystemEntry;

		public RectTransform rectTransform;

		public SfbPanel parent;

		public bool interactable;

		private bool selected;

		private bool pressed;

		private SfbEntry browserEntry;

		public SfbEntry BrowserEntry
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool EntryActive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Selected
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Pressed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static SfbEntryWrapper CreateEmpty(float height)
		{
			return null;
		}
	}
}
