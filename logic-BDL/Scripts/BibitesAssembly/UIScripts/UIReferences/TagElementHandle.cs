using ManagementScripts;
using SimulationScripts;
using TMPro;
using UIScripts.InfoHandles;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.UIReferences
{
	public class TagElementHandle : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI tagIndex;

		[SerializeField]
		private TextMeshProUGUI tagName;

		[SerializeField]
		private FloatValueTextHandle tagCount;

		[SerializeField]
		private FloatValueTextHandle tagEnergy;

		public string TagText => tagName.text;

		public int count => (int)tagCount.value;

		public float energy => tagEnergy.value;

		public void InitTagElement(string tagLabel)
		{
			tagName.text = tagLabel;
			GetComponent<Button>().onClick.AddListener(ClickOnTag);
		}

		public void UpdateInfo(TagInfo info)
		{
			tagCount.UpdateValue(info.count);
			tagEnergy.UpdateValue(info.totalEnergy);
		}

		public void UpdateIndex(int i)
		{
			tagIndex.text = $"{i}.";
		}

		public void ClickOnTag()
		{
			UserControl.Instance.SelectRandomBibiteOfTag(TagText);
		}
	}
}
