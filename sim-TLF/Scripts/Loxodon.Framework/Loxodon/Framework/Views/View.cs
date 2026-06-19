using System;
using UnityEngine;

namespace Loxodon.Framework.Views
{
	public class View : MonoBehaviour, IView
	{
		[NonSerialized]
		private IAttributes attributes = new Attributes();

		public virtual string Name
		{
			get
			{
				if (!(base.gameObject != null))
				{
					return null;
				}
				return base.gameObject.name;
			}
			set
			{
				if (!(base.gameObject == null))
				{
					base.gameObject.name = value;
				}
			}
		}

		public virtual Transform Parent
		{
			get
			{
				if (!(base.transform != null))
				{
					return null;
				}
				return base.transform.parent;
			}
		}

		public virtual GameObject Owner => base.gameObject;

		public virtual Transform Transform => base.transform;

		public virtual bool Visibility
		{
			get
			{
				if (!(base.gameObject != null))
				{
					return false;
				}
				return base.gameObject.activeSelf;
			}
			set
			{
				if (!(base.gameObject == null) && base.gameObject.activeSelf != value)
				{
					base.gameObject.SetActive(value);
				}
			}
		}

		public virtual IAttributes ExtraAttributes => attributes;

		protected virtual void OnEnable()
		{
			OnVisibilityChanged();
		}

		protected virtual void OnDisable()
		{
			OnVisibilityChanged();
		}

		protected virtual void OnVisibilityChanged()
		{
		}
	}
}
