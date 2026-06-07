using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Controls3D
{
	[RequireComponent(typeof(Draggable3D))]
	public class BlendOutput3D : MonoBehaviour
	{
		[Header("Visual - Mixed Pairs")]
		[SerializeField]
		private GameObject abIcon;

		[SerializeField]
		private GameObject acIcon;

		[SerializeField]
		private GameObject adIcon;

		[SerializeField]
		private GameObject bcIcon;

		[SerializeField]
		private GameObject bdIcon;

		[SerializeField]
		private GameObject cdIcon;

		[Header("Visual - Duplicate Pairs")]
		[SerializeField]
		private GameObject aaIcon;

		[SerializeField]
		private GameObject bbIcon;

		[SerializeField]
		private GameObject ccIcon;

		[SerializeField]
		private GameObject ddIcon;

		[Header("Animation")]
		[SerializeField]
		private TweenConfig appearAnimation;

		[SerializeField]
		private TweenConfig consumeAnimation;

		[SerializeField]
		private TweenConfig rejectAnimation;

		[SerializeField]
		private TweenConfig flyToAnimation;

		[SerializeField]
		private float rejectPopScale;

		private BlendPairType currentPair;

		private Draggable3D draggable;

		private GameObject activeIcon;

		private int scaleTweenId;

		private int moveTweenId;

		private Vector3 restScale;

		private bool isConsumed;

		public BlendPairType CurrentPair => default(BlendPairType);

		public bool IsConsumed => false;

		public bool HasBlend => false;

		public Draggable3D Draggable => null;

		public event Action<BlendOutput3D> OnConsumed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		public void Initialize(BlendPairType pair)
		{
		}

		public void Consume()
		{
		}

		public void Reject()
		{
		}

		public void FlyToAndConsume(Vector3 targetWorldPosition, Action onArrived = null)
		{
		}

		public void Recycle()
		{
		}

		private void HideAllIcons()
		{
		}

		private GameObject GetIconForPair(BlendPairType pair)
		{
			return null;
		}

		private void OnDestroy()
		{
		}
	}
}
