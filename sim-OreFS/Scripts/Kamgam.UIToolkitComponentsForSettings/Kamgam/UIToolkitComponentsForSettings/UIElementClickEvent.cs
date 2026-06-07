using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Kamgam.UIToolkitComponentsForSettings
{
	public class UIElementClickEvent : MonoBehaviour
	{
		[Header("Query Criteria")]
		[Tooltip("Only elements of this type are used.")]
		public UIElementType Type;

		[Tooltip("If set then the element will be search by the class name.\nIf an element name is set then both have to match.")]
		public string BindingClass;

		[Tooltip("If set then the element will be search by the element name.\nIf a class name is set then both have to match.")]
		public string BindingName;

		[Tooltip("If enabled then all elements matching the criteria are used.")]
		public bool MultipleResults;

		[Header("Events")]
		public UnityEvent<ClickEvent> OnClick;

		protected UIDocument _document;

		[NonSerialized]
		public List<VisualElement> Elements = new List<VisualElement>();

		public Predicate<VisualElement> BindingPredicate;

		public UIDocument Document
		{
			get
			{
				if (_document == null)
				{
					_document = GetComponentInParent<UIDocument>();
				}
				return _document;
			}
		}

		public virtual void OnEnable()
		{
			RefreshElements();
			RegisterEvents();
		}

		public void RefreshElements()
		{
			if (Document == null || Document.rootVisualElement == null)
			{
				return;
			}
			Elements.Clear();
			if (MultipleResults)
			{
				Document.QueryTypes(Type, string.IsNullOrEmpty(BindingName) ? null : BindingName, string.IsNullOrEmpty(BindingClass) ? null : BindingClass, Elements);
				return;
			}
			VisualElement visualElement = Document.QueryType(Type, string.IsNullOrEmpty(BindingName) ? null : BindingName, string.IsNullOrEmpty(BindingClass) ? null : BindingClass);
			if (visualElement != null)
			{
				Elements.Add(visualElement);
			}
		}

		public virtual void OnDisable()
		{
			UnregisterEvents();
		}

		public virtual void OnDestroy()
		{
			UnregisterEvents();
		}

		public virtual void RegisterEvents()
		{
			if (Elements.Count == 0)
			{
				return;
			}
			foreach (VisualElement element in Elements)
			{
				if (OnClick != null)
				{
					element.RegisterCallback<ClickEvent>(onClick);
				}
			}
		}

		public virtual void UnregisterEvents()
		{
			if (Elements.Count == 0)
			{
				return;
			}
			foreach (VisualElement element in Elements)
			{
				if (OnClick != null)
				{
					element.UnregisterCallback<ClickEvent>(onClick);
				}
			}
		}

		protected virtual void onClick(ClickEvent evt)
		{
			OnClick?.Invoke(evt);
		}
	}
}
