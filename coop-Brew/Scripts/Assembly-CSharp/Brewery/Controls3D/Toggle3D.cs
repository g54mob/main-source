using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Controls3D
{
	[RequireComponent(typeof(Collider))]
	public class Toggle3D : MonoBehaviour
	{
		[Header("Configuration")]
		[SerializeField]
		private float offPositionX;

		[SerializeField]
		private float onPositionX;

		[SerializeField]
		private float snapSpeed;

		[Header("State")]
		[SerializeField]
		private bool isOn;

		private Collider cachedCollider;

		public bool IsOn
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float Value => 0f;

		public event Action<bool> OnToggled
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

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void SetStateWithoutNotify(bool on)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
