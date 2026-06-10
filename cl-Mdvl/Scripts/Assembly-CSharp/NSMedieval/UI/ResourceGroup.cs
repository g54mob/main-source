using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ResourceGroup : MonoBehaviour
	{
		[SerializeField]
		private Localize groupName;

		[SerializeField]
		private TMP_Text toggleSprite;

		[SerializeField]
		private Button groupExpandTogle;

		private ResourceGroup parentGroup;

		private bool groupExpanded;

		private bool hasResource;

		private int groupDepth;

		private List<ResourceGroup> immediateGroupChidlren = new List<ResourceGroup>();

		private List<ResourceCount> immediateResourceChildren = new List<ResourceCount>();

		public List<ResourceGroup> ImmediateGroupChidlren
		{
			get
			{
				return immediateGroupChidlren;
			}
			set
			{
				immediateGroupChidlren = value;
			}
		}

		public List<ResourceCount> ImmediateResourceChildren
		{
			get
			{
				return immediateResourceChildren;
			}
			set
			{
				immediateResourceChildren = value;
			}
		}

		public bool HasResource => hasResource;

		public void UpdateGroup()
		{
			int num = 0;
			foreach (ResourceCount immediateResourceChild in immediateResourceChildren)
			{
				if (immediateResourceChild.Count > 0)
				{
					num++;
				}
			}
			foreach (ResourceGroup item in immediateGroupChidlren)
			{
				if (item.HasResource)
				{
					num++;
				}
			}
			hasResource = num > 0;
			if (parentGroup != null && hasResource)
			{
				parentGroup.UpdateGroup();
			}
			if (groupDepth == 0 && hasResource)
			{
				base.gameObject.SetActive(value: true);
			}
			UpdateChildren();
		}

		public void SetActive(bool active)
		{
			if (!(!hasResource && active))
			{
				base.gameObject.SetActive(active);
			}
		}

		public void SetupGroup(string group, int depth, ResourceGroup parent)
		{
			parentGroup = parent;
			groupDepth = depth;
			toggleSprite.text = AssetUtils.GetSpriteAsset(ToggleSprite());
			groupName.Term = "resource_group_" + group;
			GetComponent<VerticalLayoutGroup>().padding = new RectOffset(15 * (depth + 1), 0, 0, 0);
			groupExpandTogle.onClick.AddListener(delegate
			{
				StartCoroutine(OnExpansionChange());
			});
			SetActive(active: false);
		}

		private string ToggleSprite()
		{
			if (!groupExpanded)
			{
				return "plus";
			}
			return "minus";
		}

		private IEnumerator OnExpansionChange()
		{
			groupExpanded = !groupExpanded;
			toggleSprite.text = AssetUtils.GetSpriteAsset(ToggleSprite());
			UpdateChildren();
			yield return new WaitForSecondsRealtime(0.01f);
		}

		private void UpdateChildren()
		{
			foreach (ResourceGroup item in immediateGroupChidlren)
			{
				item.SetActive(groupExpanded);
			}
			foreach (ResourceCount immediateResourceChild in immediateResourceChildren)
			{
				immediateResourceChild.SetActive(groupExpanded);
			}
		}
	}
}
