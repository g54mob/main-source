using System;
using NaisuPorter.CommonScripts;

namespace __Project__.Scripts.Data
{
	[Serializable]
	public class CustomizationData
	{
		public string ShopName;

		public int DoorIndex;

		public SerializableColor ShopNameColor;

		public SerializableColor NameBackGroundColor;

		public float ShopNameSizeX;

		public float ShopNameSizeY;

		public int EntranceVariant;

		public bool IsSignboardDefault;

		public bool IsAnythingChanged => false;

		public void Clear()
		{
		}
	}
}
