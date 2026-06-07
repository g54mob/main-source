using System.Collections;
using UnityEngine;

namespace Simulator
{
	public class ObjectStackActivator : ObjectActivator
	{
		private Stack m_stack = new Stack();

		protected object CurrentObj
		{
			get
			{
				if (base.CurrentGameObject != null)
				{
					return base.CurrentGameObject;
				}
				if (base.CurrentActivable != null)
				{
					return base.CurrentActivable;
				}
				return null;
			}
		}

		public bool IsEmpty => CurrentObj == null;

		public void Clear()
		{
			DeactivateCurrent();
			m_stack.Clear();
		}

		public virtual void Init(GameObject go)
		{
			Clear();
			Activate(go);
		}

		public virtual void Init(IActivable activable)
		{
			Clear();
			Activate(activable);
		}

		public override void Activate(GameObject go)
		{
			if (CurrentObj != null)
			{
				m_stack.Push(CurrentObj);
			}
			base.Activate(go);
		}

		public override void Activate(IActivable activable)
		{
			if (CurrentObj != null)
			{
				m_stack.Push(CurrentObj);
			}
			base.Activate(activable);
		}

		public override void DeactivateCurrent()
		{
			base.DeactivateCurrent();
		}

		public virtual bool Back()
		{
			if (m_stack.Count > 0)
			{
				DeactivateCurrent();
				object obj = m_stack.Pop();
				if (obj != null)
				{
					if (obj is GameObject currentGameObject)
					{
						base.CurrentGameObject = currentGameObject;
						base.CurrentGameObject.SetActive(value: true);
					}
					else if (obj is IActivable currentActivable)
					{
						base.CurrentActivable = currentActivable;
						base.CurrentActivable.SetActive(active: true);
					}
				}
				return true;
			}
			return false;
		}
	}
}
