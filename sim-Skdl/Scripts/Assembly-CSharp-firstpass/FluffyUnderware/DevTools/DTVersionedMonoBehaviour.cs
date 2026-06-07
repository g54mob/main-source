using System;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.DevTools
{
	public abstract class DTVersionedMonoBehaviour : MonoBehaviour
	{
		[HideInInspector]
		[SerializeField]
		private string m_Version;

		public string Version
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		protected bool IsActiveAndEnabled { get; private set; }

		protected virtual void OnEnable()
		{
		}

		protected virtual void ResetOnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnValidate()
		{
		}

		protected virtual void Reset()
		{
		}

		[UsedImplicitly]
		[Obsolete("Use ObjectExt.Destroy(...) instead")]
		public void Destroy()
		{
		}
	}
}
