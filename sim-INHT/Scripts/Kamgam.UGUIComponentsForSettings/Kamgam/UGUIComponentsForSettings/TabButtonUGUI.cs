using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Kamgam.UGUIComponentsForSettings
{
	public class TabButtonUGUI : MonoBehaviour
	{
		public int GroupID;

		public GameObject Normal;

		public GameObject Active;

		public GameObject Content;

		public TextMeshProUGUI NormalTextTf;

		public TextMeshProUGUI ActiveTextTf;

		public bool IsActive => false;

		public string Text
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void SetActive(bool active)
		{
		}

		public void SetActive(bool active, bool includeInactiveSiblings)
		{
		}

		protected void setActiveInternal(bool active)
		{
		}

		public void UpdateSiblings(bool includeInactive = false)
		{
		}

		public List<TabButtonUGUI> FindSiblings(bool includeInactive = false)
		{
			return null;
		}
	}
}
