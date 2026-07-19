using System;
using UnityEngine;
using UnityEngine.UI;

namespace Kengine
{
	[AddComponentMenu("Kengine/Modifier/Counter")]
	[RequireComponent(typeof(Text))]
	public class Counter : MonoBehaviour
	{
		public float timeBetweenUpdates = 1f;

		private Text text;

		private DateTime timeOfLastCount;

		private float leftover;

		private float frameCount;

		private void Start()
		{
			text = GetComponent<Text>();
			timeOfLastCount = DateTime.Now;
			leftover = 0f;
		}

		private void Update()
		{
			frameCount += 1f;
			float num = (float)(DateTime.Now - timeOfLastCount).TotalSeconds + leftover;
			if (num > timeBetweenUpdates)
			{
				leftover = num - timeBetweenUpdates;
				timeOfLastCount = DateTime.Now;
				float num2 = frameCount * (1f / timeBetweenUpdates);
				text.text = num2.ToString("00");
				frameCount = 0f;
			}
		}
	}
}
