using System;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.DevTools
{
	public abstract class DTVersionedMonoBehaviour : MonoBehaviour
	{
		[SerializeField]
		[HideInInspector]
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

		[Obsolete("Use ObjectExt.Destroy(...) instead")]
		[UsedImplicitly]
		public void Destroy()
		{
		}
	}
}
