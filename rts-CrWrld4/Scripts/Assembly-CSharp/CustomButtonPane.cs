using NBT.Tags;
using UnityEngine;

public class CustomButtonPane : MonoBehaviour
{
	public struct ButtonData
	{
		public bool active;

		public string text;

		public Color color;

		public string msgChannel;

		public string msgData;

		public void ReadData(Tag data)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	public CustomButtonPaneButton[] buttons;

	public void SetButtonData(int slot, ButtonData bd)
	{
	}

	public void ReadData(Tag data)
	{
	}

	public TagCompound WriteData()
	{
		return null;
	}
}
