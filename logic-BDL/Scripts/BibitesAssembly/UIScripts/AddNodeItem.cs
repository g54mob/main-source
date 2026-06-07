using System;
using SimulationScripts.BibiteScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIScripts
{
	public class AddNodeItem : MonoBehaviour
	{
		public TextMeshProUGUI label;

		public Image img;

		[NonSerialized]
		public int index;

		[NonSerialized]
		public string title;

		[NonSerialized]
		public bool present;

		[NonSerialized]
		public NEATBrain.NodeArchetype archetype;

		public UnityEvent<AddNodeItem> itemClicked = new UnityEvent<AddNodeItem>();

		public void InitItem(int _val, string _title, NEATBrain.NodeArchetype _archetype)
		{
			index = _val;
			title = _title;
			archetype = _archetype;
			if (archetype != NEATBrain.NodeArchetype.Hidden)
			{
				img.sprite = BrainIconHolder.instance.GetIconOfIndex(index + ((archetype == NEATBrain.NodeArchetype.Output) ? NEATBrain.NInputs : 0));
			}
			else
			{
				img.sprite = BrainIconHolder.instance.brainFunctionsIcons[index - 1];
			}
			label.text = _title;
		}

		public bool Filter(string filter)
		{
			bool result = title.Contains(filter, StringComparison.InvariantCultureIgnoreCase);
			SetPresent(result);
			return result;
		}

		public void SetPresent(bool value)
		{
			present = value;
			base.gameObject.SetActive(value);
		}

		public void ClickItem()
		{
			itemClicked.Invoke(this);
		}
	}
}
