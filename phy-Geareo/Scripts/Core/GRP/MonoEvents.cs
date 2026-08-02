using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace GRP
{
	public class MonoEvents : MonoBehaviour
	{
		public event Action update
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

		public event Action lateUpdate
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

		public event Action fixedUpdate
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

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void FixedUpdate()
		{
		}
	}
}
