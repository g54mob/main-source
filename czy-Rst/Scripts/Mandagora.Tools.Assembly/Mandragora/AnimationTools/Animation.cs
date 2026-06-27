using System;
using System.Globalization;
using UnityEngine;

namespace Mandragora.AnimationTools
{
	[Serializable]
	public class Animation
	{
		public string name;

		public TextAsset timelineData;

		public Frame[] frames;

		private SpritesPool spritesPool;

		public void Initialize(SpritesPool pool = null)
		{
			if (pool != null)
			{
				spritesPool = pool;
			}
			if (timelineData != null && spritesPool != null)
			{
				InitializeAnimation();
			}
		}

		private void InitializeAnimation()
		{
			string[] separator = new string[3]
			{
				"\n",
				"\r\n",
				'\r'.ToString()
			};
			string[] array = timelineData.text.Split(separator, StringSplitOptions.None);
			frames = new Frame[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				frames[i] = new Frame();
				InitializeFrame(frames[i], array[i]);
			}
		}

		private void InitializeFrame(Frame frame, string data)
		{
			string[] array = data.Split(' ');
			frame.img = spritesPool.Get(array[0]);
			frame.x = float.Parse(array[1], CultureInfo.InvariantCulture);
			frame.y = float.Parse(array[2], CultureInfo.InvariantCulture);
			frame.time = float.Parse(array[3], CultureInfo.InvariantCulture);
			if (array.Length > 4)
			{
				InitializeAttachment(frame, array);
			}
		}

		private void InitializeAttachment(Frame frame, string[] frameData)
		{
			int num = int.Parse(frameData[4]);
			frame.attachments = new Attachment[num];
			for (int i = 0; i < num; i++)
			{
				frame.attachments[i] = new Attachment();
				int num2 = 5 + i * 3;
				frame.attachments[i].name = frameData[num2];
				frame.attachments[i].x = float.Parse(frameData[num2 + 1], CultureInfo.InvariantCulture);
				frame.attachments[i].y = float.Parse(frameData[num2 + 2], CultureInfo.InvariantCulture);
			}
		}

		public void CopyEvents(Animation copy)
		{
			if (copy != null && copy.name == name)
			{
				int num = Mathf.Min(copy.frames.Length, frames.Length);
				for (int i = 0; i < num; i++)
				{
					frames[i].eventName = copy.frames[i].eventName;
				}
			}
		}
	}
}
