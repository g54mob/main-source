using NSEipix.View.UI;
using TMPro;
using UnityEngine;

namespace NSMedieval.StructurePresets
{
	public class StructurePresetItemView : MonoBehaviour
	{
		public delegate void OnStructureSelect(int index);

		[SerializeField]
		private TextMeshProUGUI TMPtext;

		private int index;

		public OnStructureSelect OnSelect
		{
			set
			{
				OnSelectEvent += value;
			}
		}

		private event OnStructureSelect OnSelectEvent;

		private void Start()
		{
			SoundButton component = GetComponent<SoundButton>();
			if (!(component == null))
			{
				component.onClick.AddListener(OnClick);
			}
		}

		public void Setup(string name, int index)
		{
			TMPtext.text = name;
			this.index = index;
		}

		public void OnClick()
		{
			this.OnSelectEvent?.Invoke(index);
		}
	}
}
