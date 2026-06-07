using System;
using System.Collections.Generic;
using UI.Common;
using UI.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Elements
{
	public class UIButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
	{
		[NonSerialized]
		[HideInInspector]
		public Button button;

		public UIText buttonName;

		public Image buttonIcon;

		public List<RetroTextParameters> lableParametersList;

		public List<ImageParameters> imageParametersList;

		public Dictionary<ElementParameters, UIText> lableParameters;

		public Dictionary<ElementParameters, Image> imageParameters;

		protected Sprite defaultButtonWorkshopStatusIcon;

		protected Dictionary<ElementParameters, Sprite> defaultImage;

		private Dictionary<int, Action> singleClickDict;

		private Dictionary<int, Action> doubleClickDict;

		[NonSerialized]
		[HideInInspector]
		public bool mouseInsideButton;

		[NonSerialized]
		[HideInInspector]
		public Action ButtonPointerEnter;

		[NonSerialized]
		[HideInInspector]
		public Action ButtonPointerExit;

		[NonSerialized]
		[HideInInspector]
		public Action PointerEnter;

		[NonSerialized]
		[HideInInspector]
		public Action PointerExit;

		[NonSerialized]
		[HideInInspector]
		public Action PointerUp;

		[SerializeField]
		protected bool hasDoubleClick;

		protected float dclick_threshold;

		protected float sclick_threshold;

		protected double timerdclick;

		private IUIButtonModule[] buttonModules;

		public bool isSelected;

		private bool _init;

		[HideInInspector]
		public Action SingleClick
		{
			set
			{
			}
		}

		[HideInInspector]
		public Action DoubleClick
		{
			set
			{
			}
		}

		private void _Init()
		{
		}

		public virtual void Init(ButtonParameters? buttonP = null)
		{
		}

		protected virtual void WaitDoubleClick()
		{
		}

		public void InvokeActions(UIButtonsActions actionType)
		{
		}

		public void AddActionToDict(int priority, Action action, UIButtonsActions actionType)
		{
		}

		public void RemoveActionFromDict(int priority, Action action, UIButtonsActions actionType)
		{
		}

		public virtual void Enable()
		{
		}

		public virtual void Disable()
		{
		}

		public virtual void SetSelected()
		{
		}

		public virtual void SetNotSelected()
		{
		}

		public virtual void SetActive(bool active)
		{
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
		}

		public virtual void InvokeOnPointerDown()
		{
		}

		public virtual void OnPointerDown(PointerEventData eventData)
		{
		}

		public virtual void OnPointerUp(PointerEventData eventData)
		{
		}

		public void ResetModules()
		{
		}

		public void OnButtonDestroy()
		{
		}
	}
}
