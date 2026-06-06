using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Controls3D
{
	[RequireComponent(typeof(Collider))]
	public class Bubble3D : MonoBehaviour
	{
		[Header("Animation — Entrance")]
		[SerializeField]
		private TweenConfig entranceAnimation;

		[Header("Animation — Pop")]
		[SerializeField]
		private TweenConfig popAnimation;

		[Tooltip("Scale multiplier for the punch-up before shrinking (1.5 = 150% of original)")]
		[SerializeField]
		private float popPunchScale;

		[Header("Animation — Expire")]
		[SerializeField]
		private TweenConfig expireAnimation;

		private int zone;

		private float timeReward;

		private float lifetime;

		private bool isPopped;

		private Collider cachedCollider;

		private Vector3 targetScale;

		public int Zone => 0;

		public float TimeReward => 0f;

		public bool IsPopped => false;

		public event Action<Bubble3D> OnPopped
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

		public event Action<Bubble3D> OnExpired
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

		public event Action<Bubble3D> OnRecycled
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

		public void Initialize(int zone, float timeReward, float lifetime)
		{
		}

		private void Update()
		{
		}

		public void Pop()
		{
		}

		private void PopPhase2()
		{
		}

		private void Expire()
		{
		}

		private void Recycle()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
