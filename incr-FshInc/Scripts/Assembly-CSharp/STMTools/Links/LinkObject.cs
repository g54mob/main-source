using UnityEngine;
using UnityEngine.Events;

namespace STMTools.Links
{
	public abstract class LinkObject : MonoBehaviour
	{
		public delegate void OnClickAction();

		public delegate void OnEnterAction();

		public delegate void OnExitAction();

		internal Transform t;

		internal GameObject go;

		internal Bounds bounds;

		[SerializeField]
		protected UnityEvent onClick;

		[SerializeField]
		protected UnityEvent onEnter;

		[SerializeField]
		protected UnityEvent onExit;

		internal int linkIndex;

		internal int lastCharacterIndex;

		internal LinkController controller;

		public event OnClickAction OnClickEvent;

		public event OnEnterAction OnEnterEvent;

		public event OnExitAction OnExitEvent;

		internal abstract void Initialize(CharInfo charInfo, LinkController controller, string name, Link link, UnityEvent onEnter, UnityEvent onExit);

		internal abstract void Encapsulate(CharInfo charInfo);

		protected virtual void OnClick()
		{
			if (onClick != null)
			{
				onClick.Invoke();
			}
			if (this.OnClickEvent != null)
			{
				this.OnClickEvent();
			}
		}

		protected virtual void OnEnter()
		{
			controller.EnterLink(linkIndex);
			if (onEnter != null)
			{
				onEnter.Invoke();
			}
			if (this.OnEnterEvent != null)
			{
				this.OnEnterEvent();
			}
		}

		protected virtual void OnExit()
		{
			controller.ExitLink(linkIndex);
			if (onExit != null)
			{
				onExit.Invoke();
			}
			if (this.OnExitEvent != null)
			{
				this.OnExitEvent();
			}
		}
	}
}
