using System;
using System.IO;
using System.Linq;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace Fullscreen.NanoSave.Runtime
{
	[Serializable]
	[Title("Save Slot Screenshot")]
	[Category("NanoSave/Save Slot Screenshot")]
	[Image(typeof(IconNanoSave), ColorTheme.Type.White)]
	[Description("Gets the screenshot sprite for a specified save slot")]
	public class GetSpriteSaveSlotScreenshot : PropertyTypeGetSprite
	{
		[SerializeField]
		private PropertyGetDecimal m_SlotNumber = new PropertyGetDecimal(1f);

		public override string String
		{
			get
			{
				if (m_SlotNumber == null)
				{
					return "No Slot Selected";
				}
				return $"Slot {m_SlotNumber} Screenshot";
			}
		}

		public override Sprite Get(Args args)
		{
			string slotNumber = ((int)m_SlotNumber.Get(args)).ToString("D4");
			string text = FindScreenshotForSlot(slotNumber);
			if (string.IsNullOrEmpty(text) || !File.Exists(text))
			{
				return null;
			}
			byte[] data = File.ReadAllBytes(text);
			Texture2D texture2D = new Texture2D(2, 2);
			if (texture2D.LoadImage(data))
			{
				return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
			}
			return null;
		}

		public static PropertyGetSprite Create(PropertyGetDecimal slotNumber)
		{
			return new PropertyGetSprite(new GetSpriteSaveSlotScreenshot
			{
				m_SlotNumber = slotNumber
			});
		}

		private string FindScreenshotForSlot(string slotNumber)
		{
			string text = Directory.GetDirectories(Path.Combine(Application.persistentDataPath, "Saves")).FirstOrDefault((string path) => Path.GetFileName(path).EndsWith(slotNumber));
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			string text2 = Path.Combine(text, "Screenshot.png");
			if (!File.Exists(text2))
			{
				return null;
			}
			return text2;
		}
	}
}
