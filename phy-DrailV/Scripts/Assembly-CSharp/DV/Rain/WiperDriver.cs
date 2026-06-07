using System;
using DV.Utils;
using UnityEngine;

namespace DV.Rain
{
	[ExecuteBefore(typeof(DefaultOrder))]
	public class WiperDriver : MonoBehaviour
	{
		public WiperDriver master;

		public Wiper wiper;

		public float speed;

		public float timeBetweenWipes;

		[NonSerialized]
		public bool direction;

		[NonSerialized]
		public float currentPos;

		private float lastWipeTime;

		private void Awake()
		{
			speed = 0f;
			wiper.driver = this;
		}

		public void RestartTimer()
		{
			lastWipeTime = float.MinValue;
		}

		protected virtual void FixedUpdate()
		{
			if ((bool)master)
			{
				currentPos = master.currentPos;
				wiper.releaseDroplets = master.wiper.releaseDroplets;
				wiper.disableCollision = master.wiper.disableCollision;
				speed = master.speed;
				timeBetweenWipes = master.timeBetweenWipes;
				direction = master.direction;
				return;
			}
			currentPos += Time.fixedDeltaTime * speed * (float)(direction ? 1 : (-1));
			currentPos = Mathf.Clamp(currentPos, -0.001f, 1.001f);
			if (speed > 0f)
			{
				if (currentPos > 1f && direction)
				{
					direction = false;
					wiper.ReleaseDroplets();
				}
				else if (currentPos < 0f && !direction && Time.time - lastWipeTime > timeBetweenWipes)
				{
					direction = true;
					wiper.ReleaseDroplets();
					lastWipeTime = Time.time;
				}
			}
			wiper.disableCollision = (direction ? (currentPos < 0.05f) : (1f - currentPos < 0.05f));
		}
	}
}
