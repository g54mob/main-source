using System;
using UnityEngine;

namespace Deform
{
	[Serializable]
	public class DeformerElement : IComponentElement<Deformer>
	{
		[SerializeField]
		private Deformer component;

		[SerializeField]
		private bool active = true;

		public Deformer Component
		{
			get
			{
				return component;
			}
			set
			{
				component = value;
			}
		}

		public bool Active
		{
			get
			{
				return active;
			}
			set
			{
				active = value;
			}
		}

		public DeformerElement()
			: this(null)
		{
		}

		public DeformerElement(Deformer component, bool active = true)
		{
			this.component = component;
			this.active = active;
		}

		public bool CanProcess()
		{
			if (Active && Component != null)
			{
				return Component.CanProcess();
			}
			return false;
		}
	}
}
