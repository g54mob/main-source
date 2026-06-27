using System;
using UnityEngine;

namespace Mandragora.AnimationTools
{
	[Serializable]
	public class AnimationObjectData
	{
		[HideInInspector]
		public AnimationDataAsset dataAsset;

		[HideInInspector]
		public Transform transform;

		[HideInInspector]
		public SpriteRenderer renderer;

		private bool flipX;

		private bool flipY;

		public bool FlipX
		{
			get
			{
				return flipX;
			}
			set
			{
				if (flipX != value)
				{
					flipX = value;
					if (renderer != null)
					{
						renderer.flipX = flipX;
					}
					Vector3 localPosition = transform.localPosition;
					transform.localPosition = new Vector3(-1f * localPosition.x, localPosition.y, localPosition.z);
				}
			}
		}

		public bool FlipY
		{
			get
			{
				return flipY;
			}
			set
			{
				if (flipY != value)
				{
					flipY = value;
					if (renderer != null)
					{
						renderer.flipY = flipY;
					}
					Vector3 localPosition = transform.localPosition;
					transform.localPosition = new Vector3(localPosition.x, -1f * localPosition.y, localPosition.z);
				}
			}
		}

		public void Initialize(Transform transform = null)
		{
			if (transform != null)
			{
				this.transform = transform;
				SpriteRenderer component = transform.GetComponent<SpriteRenderer>();
				if (component != null)
				{
					renderer = component;
				}
			}
		}

		public Animation GetAnimation(string name)
		{
			if (dataAsset == null)
			{
				return null;
			}
			for (int i = 0; i < dataAsset.animations.Count; i++)
			{
				if (dataAsset.animations[i].name == name)
				{
					return dataAsset.animations[i];
				}
			}
			return null;
		}

		public void SetSprite(Sprite sprite)
		{
			if (renderer != null)
			{
				renderer.sprite = sprite;
			}
		}
	}
}
