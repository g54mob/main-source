using System.Collections.Generic;
using UnityEngine;

namespace Michsky.UI.Heat
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Heat UI/Animation/Box Container")]
	public class BoxContainer : MonoBehaviour
	{
		public enum UpdateMode
		{
			DeltaTime = 0,
			UnscaledTime = 1
		}

		[Header("Animation")]
		public AnimationCurve animationCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		[Range(0.5f, 10f)]
		public float curveSpeed = 1f;

		[Range(0f, 5f)]
		public float animationDelay;

		[Header("Fading")]
		[Range(0f, 0.99f)]
		public float fadeAfterScale = 0.75f;

		[Range(0.1f, 10f)]
		public float fadeSpeed = 5f;

		[Header("Settings")]
		public UpdateMode updateMode;

		[Range(0f, 1f)]
		public float itemCooldown = 0.1f;

		public bool playOnce;

		[HideInInspector]
		public bool isPlayedOnce;

		private List<BoxContainerItem> cachedItems = new List<BoxContainerItem>();

		private void Awake()
		{
			foreach (Transform item in base.transform)
			{
				BoxContainerItem boxContainerItem = item.gameObject.AddComponent<BoxContainerItem>();
				boxContainerItem.container = this;
				cachedItems.Add(boxContainerItem);
			}
		}

		private void OnEnable()
		{
			if (animationDelay > 0f)
			{
				Invoke("Animate", animationDelay);
			}
			else
			{
				Animate();
			}
		}

		public void Animate()
		{
			if (playOnce && isPlayedOnce)
			{
				return;
			}
			float num = 0f;
			if (cachedItems.Count > 0)
			{
				foreach (BoxContainerItem cachedItem in cachedItems)
				{
					cachedItem.Process(num);
					num += itemCooldown;
				}
			}
			isPlayedOnce = true;
		}
	}
}
