using System;
using UnityEngine;

namespace Coherence.Toolkit
{
	[Serializable]
	public abstract class ComponentAction
	{
		[SerializeField]
		internal Component component;

		public Component Component => null;

		public virtual void OnAuthority()
		{
		}

		public virtual void OnRemote()
		{
		}
	}
}
