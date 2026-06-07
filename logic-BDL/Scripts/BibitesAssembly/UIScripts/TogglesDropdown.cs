using UnityEngine.Events;

namespace UIScripts
{
	public class TogglesDropdown : MyDropdown
	{
		public UnityEvent<bool[]> onValueChanged = new UnityEvent<bool[]>();

		public override void OnChange(int index = 0)
		{
			bool[] arg = UpdateHandles();
			onValueChanged.Invoke(arg);
		}

		public bool[] UpdateHandles()
		{
			int count = items.Count;
			bool[] array = new bool[count];
			int num = 0;
			for (int i = 0; i < count; i++)
			{
				if (items[i].isOn)
				{
					num++;
				}
				array[i] = items[i].isOn;
			}
			if (num == 0)
			{
				label.text = "None Selected";
			}
			else if (num == count)
			{
				label.text = "All";
			}
			else
			{
				label.text = $"{num} Selected";
			}
			return array;
		}
	}
}
