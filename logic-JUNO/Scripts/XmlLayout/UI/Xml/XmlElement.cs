using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModApi.Common;
using ModApi.Ui;
using UI.Xml.Tags;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Xml
{
	[Serializable]
	public class XmlElement : MonoBehaviour, IXmlElement, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IDropHandler, ISelectHandler, IDeselectHandler, IPointerDownHandler, IPointerUpHandler
	{
		public enum eAudioMode
		{
			Normal = 0,
			OneShot = 1
		}

		public enum eLocateElementsBy
		{
			Id = 0,
			InternalId = 1
		}

		public enum SelectionState
		{
			Normal = 0,
			Highlighted = 1,
			Pressed = 2,
			Disabled = 3
		}

		[XmlFieldName("vm-DataSource")]
		public string DataSource;

		[SerializeField]
		protected string _tagType;

		[NonSerialized]
		protected ElementTagHandler _tagHandler;

		[SerializeField]
		protected RectTransform _rectTransform;

		[NonSerialized]
		private Selectable _selectable;

		[SerializeField]
		public AttributeDictionary attributes = new AttributeDictionary();

		[SerializeField]
		public List<string> elementAttributes = new List<string>();

		[SerializeField]
		protected XmlLayout xmlLayout;

		[SerializeField]
		public List<XmlElement> childElements = new List<XmlElement>();

		[SerializeField]
		public List<string> classes = new List<string>();

		[SerializeField]
		public List<string> hoverClasses = new List<string>();

		[SerializeField]
		public List<string> selectClasses = new List<string>();

		[SerializeField]
		public List<string> pressClasses = new List<string>();

		[SerializeField]
		public XmlElement parentElement;

		[SerializeField]
		protected string m_id = string.Empty;

		[SerializeField]
		protected string m_internalId = string.Empty;

		public ShowAnimation ShowAnimation;

		public HideAnimation HideAnimation;

		public float AnimationDuration = 0.25f;

		public float ShowAnimationDelay;

		public float HideAnimationDelay;

		[NonSerialized]
		public bool Visible;

		private bool m_hideCalledThisFrame;

		private bool m_showCalledThisFrame;

		private Coroutine HideAnimationCoroutine;

		private Coroutine ShowAnimationCoroutine;

		private bool m_rebuiltThisFrame;

		public float DefaultOpacity = 1f;

		public AudioClip OnClickSound;

		public AudioClip OnMouseEnterSound;

		public AudioClip OnMouseExitSound;

		public AudioClip OnShowSound;

		public AudioClip OnHideSound;

		public float AudioVolume = 1f;

		public eAudioMode AudioMode;

		public string AudioMixerGroup;

		private AudioMixerGroup _AudioMixerGroup;

		private AudioSource m_AudioSource;

		public bool AllowDragging;

		public bool RestrictDraggingToParentBounds = true;

		public bool ReturnToOriginalPositionWhenReleased = true;

		public static XmlElement ElementCurrentlyBeingDragged = null;

		public bool IsDropReceiver;

		public string Tooltip;

		private EventTrigger m_EventTrigger;

		[SerializeField]
		internal List<Action> m_onClickEvents = new List<Action>();

		[SerializeField]
		internal List<Action> m_onMouseEnterEvents = new List<Action>();

		[SerializeField]
		internal List<Action> m_onMouseExitEvents = new List<Action>();

		[SerializeField]
		internal List<Action<XmlElement, XmlElement>> m_onElementDroppedEvents = new List<Action<XmlElement, XmlElement>>();

		[SerializeField]
		internal List<Action> m_onBeginDragEvents = new List<Action>();

		[SerializeField]
		internal List<Action> m_onEndDragEvents = new List<Action>();

		[SerializeField]
		internal List<Action> m_onDragEvents = new List<Action>();

		[SerializeField]
		internal List<Action> m_onSubmitEvents = new List<Action>();

		[SerializeField]
		internal List<Action> m_onShowEvents = new List<Action>();

		[SerializeField]
		internal List<Action> m_onHideEvents = new List<Action>();

		[SerializeField]
		internal List<Action> m_onMouseDownEvents = new List<Action>();

		[SerializeField]
		internal List<Action> m_onMouseUpEvents = new List<Action>();

		[SerializeField]
		internal Queue<Action> m_onEnableEventsOnceOff = new Queue<Action>();

		public XmlLayoutCursorController.CursorInfo cursor;

		public XmlLayoutCursorController.CursorInfo cursorClick;

		[SerializeField]
		internal Vector2 currentOffset = Vector2.zero;

		protected static WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();

		bool IXmlElement.AllowDragging
		{
			get
			{
				return AllowDragging;
			}
			set
			{
				AllowDragging = value;
			}
		}

		float IXmlElement.AnimationDuration
		{
			get
			{
				return AnimationDuration;
			}
			set
			{
				AnimationDuration = value;
			}
		}

		float IXmlElement.DefaultOpacity
		{
			get
			{
				return DefaultOpacity;
			}
			set
			{
				DefaultOpacity = value;
			}
		}

		GameObject IXmlElement.GameObject => base.gameObject;

		float IXmlElement.HideAnimationDelay
		{
			get
			{
				return HideAnimationDelay;
			}
			set
			{
				HideAnimationDelay = value;
			}
		}

		string IXmlElement.Id => id;

		string IXmlElement.InternalId => internalId;

		bool IXmlElement.IsDropReceiver
		{
			get
			{
				return IsDropReceiver;
			}
			set
			{
				IsDropReceiver = value;
			}
		}

		AudioClip IXmlElement.OnClickSound
		{
			get
			{
				return OnClickSound;
			}
			set
			{
				OnClickSound = value;
			}
		}

		AudioClip IXmlElement.OnHideSound
		{
			get
			{
				return OnHideSound;
			}
			set
			{
				OnHideSound = value;
			}
		}

		AudioClip IXmlElement.OnMouseEnterSound
		{
			get
			{
				return OnMouseEnterSound;
			}
			set
			{
				OnMouseEnterSound = value;
			}
		}

		AudioClip IXmlElement.OnMouseExitSound
		{
			get
			{
				return OnMouseExitSound;
			}
			set
			{
				OnMouseExitSound = value;
			}
		}

		AudioClip IXmlElement.OnShowSound
		{
			get
			{
				return OnShowSound;
			}
			set
			{
				OnShowSound = value;
			}
		}

		RectTransform IXmlElement.RectTransform => rectTransform;

		bool IXmlElement.RestrictDraggingToParentBounds
		{
			get
			{
				return RestrictDraggingToParentBounds;
			}
			set
			{
				RestrictDraggingToParentBounds = value;
			}
		}

		bool IXmlElement.ReturnToOriginalPositionWhenReleased
		{
			get
			{
				return ReturnToOriginalPositionWhenReleased;
			}
			set
			{
				ReturnToOriginalPositionWhenReleased = value;
			}
		}

		float IXmlElement.ShowAnimationDelay
		{
			get
			{
				return ShowAnimationDelay;
			}
			set
			{
				ShowAnimationDelay = value;
			}
		}

		string IXmlElement.Tooltip
		{
			get
			{
				return Tooltip;
			}
			set
			{
				Tooltip = value;
			}
		}

		bool IXmlElement.Visible
		{
			get
			{
				return Visible;
			}
			set
			{
				Visible = value;
			}
		}

		IXmlLayout IXmlElement.XmlLayout => xmlLayoutInstance;

		public string tagType
		{
			get
			{
				return _tagType;
			}
			internal set
			{
				_tagType = value;
			}
		}

		public ElementTagHandler tagHandler
		{
			get
			{
				if (_tagHandler == null && tagType != null)
				{
					_tagHandler = XmlLayoutUtilities.GetXmlTagHandler(tagType);
				}
				return _tagHandler;
			}
		}

		public RectTransform rectTransform
		{
			get
			{
				if (_rectTransform == null)
				{
					_rectTransform = GetComponent<RectTransform>();
				}
				return _rectTransform;
			}
		}

		private Selectable selectable
		{
			get
			{
				if (_selectable == null)
				{
					_selectable = GetComponent<Selectable>();
				}
				return _selectable;
			}
		}

		public XmlLayout xmlLayoutInstance => xmlLayout;

		public string id => m_id;

		public string internalId => m_internalId;

		public bool _IsAnimating { get; protected set; }

		public bool IsAnimating
		{
			get
			{
				if (!_IsAnimating)
				{
					return GetCleansedChildElements().Any((XmlElement c) => c.IsAnimating);
				}
				return true;
			}
		}

		protected AudioSource AudioSource
		{
			get
			{
				if (m_AudioSource == null)
				{
					m_AudioSource = GetComponent<AudioSource>();
					if (m_AudioSource == null)
					{
						m_AudioSource = base.gameObject.AddComponent<AudioSource>();
						m_AudioSource.playOnAwake = false;
					}
				}
				return m_AudioSource;
			}
		}

		public EventTrigger EventTrigger
		{
			get
			{
				if (m_EventTrigger == null)
				{
					m_EventTrigger = GetComponent<EventTrigger>();
					if (m_EventTrigger == null)
					{
						m_EventTrigger = base.gameObject.AddComponent<EventTrigger>();
					}
				}
				return m_EventTrigger;
			}
		}

		protected Animator m_Animator
		{
			get
			{
				Animator animator = GetComponent<Animator>();
				if (animator == null)
				{
					animator = base.gameObject.AddComponent<Animator>();
				}
				RuntimeAnimatorController runtimeAnimatorController = "Animation/XmlLayoutAnimationController".ToRuntimeAnimatorController();
				animator.runtimeAnimatorController = runtimeAnimatorController;
				animator.updateMode = AnimatorUpdateMode.UnscaledTime;
				GetCanvasGroup();
				return animator;
			}
		}

		public CanvasGroup CanvasGroup => GetCanvasGroup();

		public SelectionState selectionState { get; protected set; }

		void IXmlElement.AddChildElement(IXmlElement child, bool adjustRectTransform)
		{
			AddChildElement((XmlElement)child, adjustRectTransform);
		}

		void IXmlElement.AddOnElementDroppedEvent(Action<IXmlElement, IXmlElement> action, bool clearExisting)
		{
			AddOnElementDroppedEvent(delegate(XmlElement x, XmlElement y)
			{
				action(x, y);
			}, clearExisting);
		}

		IXmlElement IXmlElement.ApplyAttributes()
		{
			return ApplyAttributes();
		}

		List<IXmlElement> IXmlElement.GetChildElementsWithClass(string name)
		{
			return GetChildElementsWithClass(name).ConvertAll((Converter<XmlElement, IXmlElement>)((XmlElement x) => x));
		}

		IXmlElement IXmlElement.GetElementByInternalId(string internalId)
		{
			return GetElementByInternalId(internalId);
		}

		void IXmlElement.Hide(Action onCompleteCallback, bool forceEvenIfNotVisible)
		{
			Hide(recursiveCall: false, onCompleteCallback, forceEvenIfNotVisible);
		}

		IXmlElement IXmlElement.RemoveAttribute(string name)
		{
			return RemoveAttribute(name);
		}

		void IXmlElement.RemoveChildElement(IXmlElement child, bool destroyChild)
		{
			RemoveChildElement((XmlElement)child, destroyChild);
		}

		IXmlElement IXmlElement.SetAttribute(string name, string value)
		{
			return SetAttribute(name, value);
		}

		void IXmlElement.Show(Action onCompleteCallback, bool forceEvenIfVisible)
		{
			Show(recursiveCall: false, onCompleteCallback, forceEvenIfVisible);
		}

		public void SetValue(string newValue, bool fireEventHandlers = true)
		{
			tagHandler.SetInstance(rectTransform, xmlLayout);
			tagHandler.SetValue(newValue, fireEventHandlers);
		}

		public void SetListData(IObservableList listData)
		{
			tagHandler.SetInstance(rectTransform, xmlLayout);
			tagHandler.SetListData(listData);
		}

		private void Awake()
		{
			m_rebuiltThisFrame = true;
		}

		private void OnEnable()
		{
			Visible = true;
			while (m_onEnableEventsOnceOff.Count > 0)
			{
				m_onEnableEventsOnceOff.Dequeue()();
			}
		}

		private void OnDisable()
		{
			Visible = false;
			if (hoverClasses != null && hoverClasses.Count > 0)
			{
				hoverClasses.ForEach(delegate(string c)
				{
					RemoveClass(c);
				});
			}
		}

		private void LateUpdate()
		{
			m_hideCalledThisFrame = false;
			m_showCalledThisFrame = false;
			m_rebuiltThisFrame = true;
		}

		public void Initialise(XmlLayout xmlLayout, RectTransform rectTransform, ElementTagHandler tagHandler)
		{
			this.xmlLayout = xmlLayout;
			_rectTransform = rectTransform;
			_tagHandler = tagHandler;
			if (this.tagHandler != null)
			{
				_tagType = tagHandler.tagType;
			}
		}

		public XmlElement SetAttribute(string attribute, string value)
		{
			if (attribute == "class")
			{
				Debug.LogWarning("[XmlLayout][XmlElement][SetAttribute]:: Please use 'SetClass', 'AddClass', and/or 'RemoveClass' to manipulate the class attribute.");
				return this;
			}
			if (HasAttribute(attribute))
			{
				attributes[attribute] = value;
			}
			else
			{
				attributes.Add(attribute, value);
			}
			if (!elementAttributes.Contains(attribute))
			{
				elementAttributes.Add(attribute);
			}
			return this;
		}

		public XmlElement RemoveAttribute(string name)
		{
			if (HasAttribute(name))
			{
				attributes.Remove(name);
				elementAttributes.Remove(name);
			}
			return this;
		}

		public string GetAttribute(string name, string defaultValue = null)
		{
			if (HasAttribute(name))
			{
				return attributes[name];
			}
			return defaultValue;
		}

		public bool HasAttribute(string name)
		{
			return attributes.ContainsKey(name);
		}

		public XmlElement ApplyAttributes(Dictionary<string, string> _attributes)
		{
			return ApplyAttributes(new AttributeDictionary(_attributes));
		}

		public XmlElement ApplyAttributes(AttributeDictionary _attributes = null)
		{
			if (_attributes != null)
			{
				if (attributes != null)
				{
					bool flag = false;
					foreach (KeyValuePair<string, string> _attribute in _attributes)
					{
						if (!HasAttribute(_attribute.Key) || GetAttribute(_attribute.Key) != _attribute.Value)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						AttributeDictionary attributeDictionary = attributes.Clone();
						foreach (KeyValuePair<string, string> _attribute2 in _attributes)
						{
							if (attributeDictionary.ContainsKey(_attribute2.Key))
							{
								attributeDictionary[_attribute2.Key] = _attribute2.Value;
							}
							else
							{
								attributeDictionary.Add(_attribute2.Key, _attribute2.Value);
							}
						}
						attributes = attributeDictionary;
					}
				}
				else
				{
					attributes = _attributes;
				}
			}
			else
			{
				_attributes = attributes;
			}
			ProcessInternalIdAttribute(_attributes.GetValue("internalid"));
			ProcessIdAttribute(_attributes.GetValue("id"));
			tagHandler.SetInstance(rectTransform, xmlLayout);
			tagHandler.ApplyAttributes(_attributes);
			return this;
		}

		private void ProcessIdAttribute(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return;
			}
			m_id = value;
			if (xmlLayout.ElementsById.ContainsValue(this))
			{
				string key = xmlLayout.ElementsById.First((KeyValuePair<string, XmlElement> e) => e.Value == this).Key;
				if (key != m_id)
				{
					xmlLayout.ElementsById.Remove(key);
				}
			}
			xmlLayout.ElementsById.SetValue(m_id, this);
		}

		private void ProcessInternalIdAttribute(string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				m_internalId = value;
			}
		}

		public void SetAndApplyAttribute(string name, string value)
		{
			SetAttribute(name, value);
			AttributeDictionary attributeDictionary = new AttributeDictionary();
			attributeDictionary.Add(name, value);
			ProcessIdAttribute(attributeDictionary.GetValue("id"));
			ProcessInternalIdAttribute(attributeDictionary.GetValue("internalid"));
			tagHandler.SetInstance(rectTransform, xmlLayout);
			tagHandler.ApplyAttributes(attributeDictionary);
		}

		public void AddClass(string name)
		{
			if (!classes.Contains(name))
			{
				classes.Add(name);
				attributes.SetValue("class", string.Join(" ", classes.ToArray()));
				ClassChanged();
			}
		}

		public void RemoveClass(string name)
		{
			if (classes.Remove(name))
			{
				attributes.SetValue("class", string.Join(" ", classes.ToArray()));
				ClassRemoved(name);
				ClassChanged();
			}
		}

		public void SetClass(params string[] newClasses)
		{
			string[] classesRemoved = classes.Where((string c) => !newClasses.Contains(c)).ToArray();
			classes.Clear();
			classes.AddRange(newClasses);
			attributes.SetValue("class", string.Join(" ", classes.ToArray()));
			ClassRemoved(classesRemoved);
			ClassChanged();
		}

		protected void ClassChanged()
		{
			tagHandler.SetInstance(rectTransform, xmlLayout);
			tagHandler.ClassChanged();
			foreach (XmlElement childElement in childElements)
			{
				childElement.ClassChanged();
			}
		}

		protected void ClassRemoved(params string[] classesRemoved)
		{
			if (!xmlLayout.defaultAttributeValues.ContainsKey(tagType))
			{
				return;
			}
			List<string> list = new List<string>();
			foreach (string key in classesRemoved)
			{
				if (xmlLayout.defaultAttributeValues[tagType].ContainsKey(key))
				{
					List<string> source = xmlLayout.defaultAttributeValues[tagType][key].Select((KeyValuePair<string, string> a) => a.Key).ToList();
					list.AddRange(source.Where((string a) => !elementAttributes.Contains(a)));
				}
			}
			if (list.Count == 0)
			{
				return;
			}
			List<string> list2 = classes.ToList();
			list2.Insert(0, "all");
			foreach (string item in list2)
			{
				if (xmlLayout.defaultAttributeValues[tagType].ContainsKey(item))
				{
					List<string> attributesDefinedByClass = xmlLayout.defaultAttributeValues[tagType][item].Select((KeyValuePair<string, string> a) => a.Key).ToList();
					list.RemoveAll((string a) => attributesDefinedByClass.Contains(a));
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			AttributeDictionary attributeDictionary = new AttributeDictionary();
			foreach (string item2 in list)
			{
				string defaultValueForAttribute = tagHandler.GetDefaultValueForAttribute(item2);
				attributeDictionary.Add(item2, defaultValueForAttribute);
			}
			if (attributeDictionary.Count > 0)
			{
				ApplyAttributes(attributeDictionary);
			}
		}

		public string GetValue()
		{
			if (tagHandler is IHasXmlFormValue)
			{
				tagHandler.SetInstance(rectTransform, xmlLayout);
				return ((IHasXmlFormValue)tagHandler).GetValue(this);
			}
			return null;
		}

		public bool HasClass(string c)
		{
			if (classes.Count == 0 && HasAttribute("class"))
			{
				classes.AddRange(GetAttribute("class").Split(' ', ','));
			}
			foreach (string @class in classes)
			{
				if (string.Equals(c, @class, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
			return false;
		}

		public XmlElement GetElementByInternalId(string internalId)
		{
			if (childElements.Count == 0)
			{
				return null;
			}
			XmlElement xmlElement = childElements.FirstOrDefault((XmlElement c) => string.Equals(c.internalId, internalId, StringComparison.OrdinalIgnoreCase));
			if (xmlElement != null)
			{
				return xmlElement;
			}
			foreach (XmlElement childElement in childElements)
			{
				XmlElement elementByInternalId = childElement.GetElementByInternalId(internalId);
				if (elementByInternalId != null)
				{
					return elementByInternalId;
				}
			}
			return null;
		}

		public T GetElementByInternalId<T>(string internalId) where T : MonoBehaviour
		{
			XmlElement elementByInternalId = GetElementByInternalId(internalId);
			if (elementByInternalId != null)
			{
				return elementByInternalId.GetComponent<T>();
			}
			return null;
		}

		public List<XmlElement> GetChildElementsWithClass(string _class)
		{
			List<XmlElement> list = new List<XmlElement>();
			foreach (XmlElement childElement in childElements)
			{
				if (childElement.HasClass(_class))
				{
					list.Add(childElement);
				}
				list.AddRange(childElement.GetChildElementsWithClass(_class));
			}
			return list;
		}

		public void AddChildElement(XmlElement child, bool adjustRectTransform = true)
		{
			if (adjustRectTransform)
			{
				child.transform.SetParent(base.transform);
				child.transform.localScale = Vector3.one;
				child.transform.position = new Vector3(child.transform.position.x, child.transform.position.y, 0f);
				child.rectTransform.anchoredPosition3D = Vector3.zero;
				child.transform.localRotation = default(Quaternion);
				child.transform.SetAsLastSibling();
			}
			child.parentElement = this;
			if (!childElements.Contains(child))
			{
				childElements.Add(child);
			}
		}

		public void RemoveChildElement(XmlElement child, bool destroyChild = false)
		{
			if (childElements.Contains(child))
			{
				childElements.Remove(child);
			}
			if (destroyChild)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(child.gameObject);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(child.gameObject);
				}
			}
		}

		private void OnDestroy()
		{
			if (parentElement != null)
			{
				parentElement.childElements.Remove(this);
			}
		}

		public void Show(bool recursiveCall = false, Action onCompleteCallback = null, bool forceEvenIfVisible = false)
		{
			m_showCalledThisFrame = true;
			if (m_hideCalledThisFrame && HideAnimationCoroutine != null)
			{
				StopCoroutine(HideAnimationCoroutine);
				_IsAnimating = false;
				forceEvenIfVisible = true;
			}
			if (m_rebuiltThisFrame)
			{
				forceEvenIfVisible = true;
			}
			if (Visible && !forceEvenIfVisible)
			{
				onCompleteCallback?.Invoke();
				return;
			}
			if (!recursiveCall)
			{
				base.gameObject.SetActive(value: true);
				if (!base.gameObject.activeInHierarchy)
				{
					base.gameObject.SetActive(value: true);
				}
			}
			Visible = base.gameObject.activeInHierarchy;
			if (!Visible)
			{
				return;
			}
			foreach (XmlElement cleansedChildElement in GetCleansedChildElements())
			{
				cleansedChildElement.Show(recursiveCall: true, null, forceEvenIfVisible);
			}
			if (Application.isPlaying)
			{
				PlaySound(OnShowSound);
				if (base.gameObject.activeInHierarchy && ShowAnimation != ShowAnimation.None)
				{
					ShowAnimationCoroutine = StartCoroutine(PlayShowAnimation(ShowAnimation, onCompleteCallback));
				}
				else
				{
					CanvasGroup.alpha = DefaultOpacity;
					ShowAnimationCoroutine = StartCoroutine(WaitForShowAnimationToComplete(onCompleteCallback));
				}
				if (!recursiveCall)
				{
					SetAttribute("active", "true");
				}
			}
		}

		public void Hide(bool recursiveCall = false, Action onCompleteCallback = null, bool forceEvenIfNotVisible = false)
		{
			m_hideCalledThisFrame = true;
			if (m_showCalledThisFrame && ShowAnimationCoroutine != null)
			{
				StopCoroutine(ShowAnimationCoroutine);
				_IsAnimating = false;
				forceEvenIfNotVisible = true;
			}
			if (m_rebuiltThisFrame)
			{
				forceEvenIfNotVisible = true;
			}
			if (!base.gameObject.activeInHierarchy || (!Visible && !forceEvenIfNotVisible))
			{
				Visible = false;
				onCompleteCallback?.Invoke();
				return;
			}
			foreach (XmlElement cleansedChildElement in GetCleansedChildElements())
			{
				cleansedChildElement.Hide(recursiveCall: true, null, forceEvenIfNotVisible);
			}
			PlaySound(OnHideSound);
			if (Application.isPlaying && !XmlLayoutTimer.IsFirstFrame && HideAnimation != HideAnimation.None)
			{
				HideAnimationCoroutine = StartCoroutine(PlayHideAnimation(HideAnimation));
			}
			if (hoverClasses != null && hoverClasses.Count > 0)
			{
				hoverClasses.ForEach(delegate(string c)
				{
					RemoveClass(c);
				});
			}
			xmlLayout.NotifyElementHidden(this);
			if (!recursiveCall)
			{
				if (!Application.isPlaying)
				{
					base.gameObject.SetActive(value: false);
					return;
				}
				HideAnimationCoroutine = StartCoroutine(HideWhenAllAnimationIsComplete(onCompleteCallback));
				SetAttribute("active", "false");
				return;
			}
			Visible = false;
			if (m_onHideEvents.Count > 0)
			{
				m_onHideEvents.ToList().ForEach(delegate(Action he)
				{
					he();
				});
			}
		}

		protected IEnumerator PlayShowAnimation(ShowAnimation animation, Action onCompleteCallback = null)
		{
			while (_IsAnimating)
			{
				yield return WaitForEndOfFrame;
			}
			_IsAnimating = true;
			if (!xmlLayout.IsReady)
			{
				yield return WaitForEndOfFrame;
			}
			CanvasGroup.alpha = 0f;
			if (ShowAnimationDelay > 0f)
			{
				if (xmlLayout.UseUnscaledTime)
				{
					yield return XmlLayoutTimer.GetWaitForSecondsRealtimeInstruction(ShowAnimationDelay);
				}
				else
				{
					yield return XmlLayoutTimer.GetWaitForSecondsInstruction(ShowAnimationDelay);
				}
			}
			yield return WaitForEndOfFrame;
			CanvasGroup.alpha = DefaultOpacity;
			CanvasGroup.blocksRaycasts = true;
			if (animation.IsSlideAnimation())
			{
				m_Animator.enabled = false;
				yield return PlaySlideInAnimation(animation);
			}
			else
			{
				m_Animator.enabled = true;
				m_Animator.updateMode = (xmlLayout.UseUnscaledTime ? AnimatorUpdateMode.UnscaledTime : AnimatorUpdateMode.Normal);
				m_Animator.applyRootMotion = true;
				m_Animator.speed = 0.446f / AnimationDuration;
				m_Animator.Play(animation.ToString());
				yield return WaitForEndOfFrame;
				AnimatorClipInfo[] currentAnimatorClipInfo = m_Animator.GetCurrentAnimatorClipInfo(0);
				m_Animator.speed = currentAnimatorClipInfo[0].clip.length / AnimationDuration;
				bool animationComplete = false;
				while (!animationComplete)
				{
					if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
					{
						animationComplete = true;
					}
					yield return null;
				}
				m_Animator.enabled = false;
			}
			_IsAnimating = false;
			ShowAnimationCoroutine = StartCoroutine(WaitForShowAnimationToComplete(onCompleteCallback));
		}

		protected IEnumerator PlayHideAnimation(HideAnimation animation)
		{
			while (_IsAnimating)
			{
				yield return WaitForEndOfFrame;
			}
			_IsAnimating = true;
			if (HideAnimationDelay > 0f)
			{
				if (xmlLayout.UseUnscaledTime)
				{
					yield return XmlLayoutTimer.GetWaitForSecondsRealtimeInstruction(HideAnimationDelay);
				}
				else
				{
					yield return XmlLayoutTimer.GetWaitForSecondsInstruction(HideAnimationDelay);
				}
			}
			CanvasGroup.blocksRaycasts = false;
			if (animation.IsSlideAnimation())
			{
				m_Animator.enabled = false;
				yield return PlaySlideOutAnimation(animation);
			}
			else
			{
				m_Animator.enabled = true;
				m_Animator.updateMode = (xmlLayout.UseUnscaledTime ? AnimatorUpdateMode.UnscaledTime : AnimatorUpdateMode.Normal);
				m_Animator.speed = 0.446f / AnimationDuration;
				m_Animator.Play(animation.ToString());
				yield return WaitForEndOfFrame;
				AnimatorClipInfo[] currentAnimatorClipInfo = m_Animator.GetCurrentAnimatorClipInfo(0);
				m_Animator.speed = currentAnimatorClipInfo[0].clip.length / AnimationDuration;
				bool animationComplete = false;
				while (!animationComplete)
				{
					if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
					{
						animationComplete = true;
					}
					yield return null;
				}
				m_Animator.enabled = false;
			}
			_IsAnimating = false;
		}

		protected Vector2 GetDistanceForSlideAnimation(SlideDirection direction)
		{
			float x = 0f;
			float y = 0f;
			Vector3[] array = new Vector3[4];
			Vector3[] array2 = new Vector3[4];
			((RectTransform)rectTransform.parent).GetWorldCorners(array);
			rectTransform.GetWorldCorners(array2);
			switch (direction)
			{
			case SlideDirection.Top:
			{
				float y4 = array[2].y;
				float y5 = array2[0].y;
				y = y4 - y5;
				break;
			}
			case SlideDirection.Bottom:
			{
				float y2 = array[3].y;
				float y3 = array2[1].y;
				y = y2 - y3;
				break;
			}
			case SlideDirection.Left:
			{
				float x4 = array[0].x;
				float x5 = array2[3].x;
				x = x4 - x5;
				break;
			}
			case SlideDirection.Right:
			{
				float x2 = array[3].x;
				float x3 = array2[0].x;
				x = x2 - x3;
				break;
			}
			}
			return new Vector2(x, y);
		}

		protected IEnumerator PlaySlideInAnimation(ShowAnimation animation)
		{
			Vector2 distance = GetDistanceForSlideAnimation(animation.ToSlideDirection());
			if (distance.x != 0f)
			{
				yield return MoveDistanceX(distance.x, 0f);
				yield return MoveDistanceX(0f - distance.x, AnimationDuration);
			}
			else if (distance.y != 0f)
			{
				yield return MoveDistanceY(distance.y, 0f);
				yield return MoveDistanceY(0f - distance.y, AnimationDuration);
			}
		}

		protected IEnumerator PlaySlideOutAnimation(HideAnimation animation)
		{
			Vector2 distance = GetDistanceForSlideAnimation(animation.ToSlideDirection());
			if (distance.x != 0f)
			{
				yield return MoveDistanceX(distance.x, AnimationDuration);
				CanvasGroup.alpha = 0f;
				yield return null;
				yield return MoveDistanceX(0f - distance.x, 0f);
			}
			else if (distance.y != 0f)
			{
				yield return MoveDistanceY(distance.y, AnimationDuration);
				CanvasGroup.alpha = 0f;
				yield return null;
				yield return MoveDistanceY(0f - distance.y, 0f);
			}
		}

		protected IEnumerator MoveDistanceX(float distance, float animationDuration = 0.25f)
		{
			float initialX = base.transform.localPosition.x;
			float destinationX = initialX + distance;
			if (animationDuration == 0f)
			{
				base.transform.localPosition = new Vector2(destinationX, base.transform.localPosition.y);
				yield break;
			}
			float rate = 1f / animationDuration;
			float index = 0f;
			while (index < 1f)
			{
				base.transform.localPosition = new Vector2(Mathf.Lerp(initialX, destinationX, index), base.transform.localPosition.y);
				index += rate * (xmlLayout.UseUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime);
				yield return null;
			}
			base.transform.localPosition = new Vector2(destinationX, base.transform.localPosition.y);
		}

		protected IEnumerator MoveDistanceY(float distance, float animationDuration = 0.25f)
		{
			float initialY = base.transform.localPosition.y;
			float destinationY = initialY + distance;
			if (animationDuration == 0f)
			{
				base.transform.localPosition = new Vector2(base.transform.localPosition.x, destinationY);
				yield break;
			}
			float rate = 1f / animationDuration;
			float index = 0f;
			while (index < 1f)
			{
				base.transform.localPosition = new Vector2(base.transform.localPosition.x, Mathf.Lerp(initialY, destinationY, index));
				index += rate * (xmlLayout.UseUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime);
				yield return null;
			}
			base.transform.localPosition = new Vector2(base.transform.localPosition.x, destinationY);
		}

		protected IEnumerator HideWhenAllAnimationIsComplete(Action onCompleteCallback)
		{
			while (IsAnimating)
			{
				yield return WaitForEndOfFrame;
			}
			if (m_onHideEvents.Count > 0)
			{
				m_onHideEvents.ToList().ForEach(delegate(Action he)
				{
					he();
				});
			}
			base.gameObject.SetActive(value: false);
			Visible = false;
			onCompleteCallback?.Invoke();
			yield return WaitForEndOfFrame;
		}

		protected IEnumerator WaitForShowAnimationToComplete(Action onCompleteCallback)
		{
			while (IsAnimating)
			{
				yield return WaitForEndOfFrame;
			}
			if (m_onShowEvents.Count > 0)
			{
				m_onShowEvents.ToList().ForEach(delegate(Action se)
				{
					se();
				});
			}
			onCompleteCallback?.Invoke();
		}

		private CanvasGroup GetCanvasGroup()
		{
			CanvasGroup canvasGroup = base.gameObject.GetComponent<CanvasGroup>();
			if (canvasGroup == null)
			{
				canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
			}
			return canvasGroup;
		}

		private List<XmlElement> GetCleansedChildElements()
		{
			childElements.RemoveAll((XmlElement c) => c == null);
			return childElements;
		}

		public Dictionary<string, string> GetFormData(eLocateElementsBy locateElementsBy = eLocateElementsBy.InternalId)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (tagHandler is IHasXmlFormValue)
			{
				switch (locateElementsBy)
				{
				case eLocateElementsBy.Id:
					if (!string.IsNullOrEmpty(id))
					{
						dictionary.AddIfKeyNotExists(id, GetValue());
					}
					break;
				case eLocateElementsBy.InternalId:
					if (!string.IsNullOrEmpty(internalId))
					{
						dictionary.AddIfKeyNotExists(internalId, GetValue());
					}
					break;
				}
			}
			List<XmlElement> cleansedChildElements = GetCleansedChildElements();
			if (cleansedChildElements.Count == 0)
			{
				return dictionary;
			}
			foreach (XmlElement item in cleansedChildElements)
			{
				Dictionary<string, string> formData = item.GetFormData(locateElementsBy);
				if (formData == null || formData.Count <= 0)
				{
					continue;
				}
				foreach (KeyValuePair<string, string> item2 in formData)
				{
					dictionary.AddIfKeyNotExists(item2.Key, item2.Value);
				}
			}
			return dictionary;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			PlaySound(OnClickSound);
			if (m_onClickEvents != null && m_onClickEvents.Count > 0)
			{
				m_onClickEvents.ToList().ForEach(delegate(Action a)
				{
					a();
				});
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!string.IsNullOrEmpty(Tooltip))
			{
				xmlLayout.ShowTooltip(this, Tooltip);
			}
			if (selectable != null && !selectable.interactable)
			{
				return;
			}
			PlaySound(OnMouseEnterSound);
			if (hoverClasses != null && hoverClasses.Count > 0)
			{
				hoverClasses.ForEach(delegate(string c)
				{
					AddClass(c);
				});
			}
			if (m_onMouseEnterEvents != null && m_onMouseEnterEvents.Count > 0)
			{
				m_onMouseEnterEvents.ToList().ForEach(delegate(Action a)
				{
					a();
				});
			}
			if (cursor != null && cursor.cursor != null)
			{
				XmlLayoutSingleton<XmlLayoutCursorController>.Instance.SetCursorForState(XmlLayoutCursorController.eCursorState.Default, cursor);
			}
			if (cursorClick != null && cursorClick.cursor != null)
			{
				XmlLayoutSingleton<XmlLayoutCursorController>.Instance.SetCursorForState(XmlLayoutCursorController.eCursorState.Click, cursorClick);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			PlaySound(OnMouseExitSound);
			bool num = cursor != null && cursor.cursor != null;
			bool flag = cursorClick != null && cursorClick.cursor != null;
			if (hoverClasses != null && hoverClasses.Count > 0)
			{
				hoverClasses.ForEach(delegate(string c)
				{
					RemoveClass(c);
				});
			}
			if (!string.IsNullOrEmpty(Tooltip))
			{
				xmlLayout.HideTooltip(this);
			}
			if (num && XmlLayoutSingleton<XmlLayoutCursorController>.Instance != null)
			{
				XmlLayoutSingleton<XmlLayoutCursorController>.Instance.ResetCursorToDefaultForState(XmlLayoutCursorController.eCursorState.Default);
			}
			if (flag && XmlLayoutSingleton<XmlLayoutCursorController>.Instance != null)
			{
				XmlLayoutSingleton<XmlLayoutCursorController>.Instance.ResetCursorToDefaultForState(XmlLayoutCursorController.eCursorState.Click);
			}
			if ((!(selectable != null) || selectable.interactable) && m_onMouseExitEvents != null && m_onMouseExitEvents.Count > 0)
			{
				m_onMouseExitEvents.ToList().ForEach(delegate(Action a)
				{
					a();
				});
			}
		}

		public void OnSubmit(BaseEventData eventData)
		{
			if (m_onSubmitEvents != null && m_onSubmitEvents.Count > 0)
			{
				m_onSubmitEvents.ToList().ForEach(delegate(Action m)
				{
					m();
				});
			}
		}

		public void AddOnClickEvent(Action action, bool clearExisting = false)
		{
			if (clearExisting)
			{
				m_onClickEvents.Clear();
			}
			m_onClickEvents.Add(action);
		}

		public void AddOnMouseEnterEvent(Action action, bool clearExisting = false)
		{
			if (clearExisting)
			{
				m_onMouseEnterEvents.Clear();
			}
			m_onMouseEnterEvents.Add(action);
		}

		public void AddOnMouseExitEvent(Action action, bool clearExisting = false)
		{
			if (clearExisting)
			{
				m_onMouseExitEvents.Clear();
			}
			m_onMouseExitEvents.Add(action);
		}

		public void AddOnElementDroppedEvent(Action<XmlElement, XmlElement> action, bool clearExisting = false)
		{
			if (clearExisting)
			{
				m_onElementDroppedEvents.Clear();
			}
			m_onElementDroppedEvents.Add(action);
		}

		public void AddOnBeginDragEvent(Action action, bool clearExisting = false)
		{
			if (clearExisting)
			{
				m_onBeginDragEvents.Clear();
			}
			m_onBeginDragEvents.Add(action);
		}

		public void AddOnEndDragEvent(Action action, bool clearExisting = false)
		{
			if (clearExisting)
			{
				m_onEndDragEvents.Clear();
			}
			m_onEndDragEvents.Add(action);
		}

		public void AddOnDragEvent(Action action, bool clearExisting = false)
		{
			if (clearExisting)
			{
				m_onDragEvents.Clear();
			}
			m_onDragEvents.Add(action);
		}

		public void AddOnSubmitEvent(Action action, bool clearExisting = false)
		{
			if (clearExisting)
			{
				m_onSubmitEvents.Clear();
			}
			m_onSubmitEvents.Add(action);
		}

		public void AddOnShowEvent(Action action, bool clearExisting = false)
		{
			if (clearExisting)
			{
				m_onShowEvents.Clear();
			}
			m_onShowEvents.Add(action);
		}

		public void AddOnHideEvent(Action action, bool clearExisting = false)
		{
			if (clearExisting)
			{
				m_onHideEvents.Clear();
			}
			m_onHideEvents.Add(action);
		}

		public void AddOnMouseDownEvent(Action action, bool clearExisting = false)
		{
			if (clearExisting)
			{
				m_onMouseDownEvents.Clear();
			}
			m_onMouseDownEvents.Add(action);
		}

		public void AddOnMouseUpEvent(Action action, bool clearExisting = false)
		{
			if (clearExisting)
			{
				m_onMouseUpEvents.Clear();
			}
			m_onMouseUpEvents.Add(action);
		}

		public void ExecuteNowOrWhenElementIsEnabled(Action action)
		{
			if (base.gameObject.activeInHierarchy)
			{
				action();
			}
			else
			{
				m_onEnableEventsOnceOff.Enqueue(action);
			}
		}

		public void OnSelect(BaseEventData eventData)
		{
			if (selectClasses != null && selectClasses.Count > 0)
			{
				selectClasses.ForEach(delegate(string c)
				{
					AddClass(c);
				});
			}
		}

		public void OnDeselect(BaseEventData eventData)
		{
			if (selectClasses != null && selectClasses.Count > 0)
			{
				selectClasses.ForEach(delegate(string c)
				{
					RemoveClass(c);
				});
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			Selectable component = GetComponent<Selectable>();
			if (component != null && !component.IsInteractable())
			{
				return;
			}
			if (pressClasses != null && pressClasses.Count > 0)
			{
				pressClasses.ForEach(delegate(string c)
				{
					AddClass(c);
				});
			}
			if (m_onMouseDownEvents != null && m_onMouseDownEvents.Count > 0)
			{
				m_onMouseDownEvents.ToList().ForEach(delegate(Action a)
				{
					a();
				});
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (pressClasses != null && pressClasses.Count > 0)
			{
				pressClasses.ForEach(delegate(string c)
				{
					RemoveClass(c);
				});
			}
			if (m_onMouseUpEvents != null && m_onMouseUpEvents.Count > 0)
			{
				m_onMouseUpEvents.ToList().ForEach(delegate(Action a)
				{
					a();
				});
			}
		}

		public void SetAudioMixerGroup(AudioSource audioSource, string path)
		{
			string[] array = path.Split('|');
			string text = array[0];
			if (array.Length >= 2)
			{
				AudioMixer audioMixer = XmlLayoutUtilities.LoadResource<AudioMixer>(text);
				if (audioMixer != null)
				{
					string text2 = array[1];
					AudioMixerGroup audioMixerGroup = audioMixer.FindMatchingGroups(text2).FirstOrDefault();
					if (audioMixerGroup != null)
					{
						audioSource.outputAudioMixerGroup = audioMixerGroup;
						return;
					}
					Debug.LogWarning("[XmlLayout][XmlElement] Warning: Audio Mixer Group with path '" + text2 + "' was not found in Audio Mixer '" + text + "'.");
				}
				else
				{
					Debug.LogWarning("[XmlLayout][XmlElement] Warning: Audio Mixer '" + text + "' was not found. Please note that the Mixer must be accessible to XmlLayout in a Resources folder or Resource Database.");
				}
			}
			else
			{
				Debug.LogWarning("[XmlLayout][XmlElement] Warning: '" + path + "' is an invalid AudioMixerGroup path. Please specify a path to the Audio Mixer followed by the Group name / path, separated by a pipe operator, e.g. Audio/MyAudioMixer|MyAudioMixerGroup. Please note that the Mixer must be accessible to XmlLayout in a Resources folder or Resource Database.");
			}
		}

		public void PlaySound(AudioClip sound)
		{
			if (sound == null)
			{
				return;
			}
			if (AudioMode == eAudioMode.OneShot)
			{
				PlaySoundOneShot(sound);
				return;
			}
			AudioSource.volume = AudioVolume;
			AudioSource.clip = sound;
			if (!string.IsNullOrEmpty(AudioMixerGroup) && _AudioMixerGroup == null)
			{
				SetAudioMixerGroup(AudioSource, AudioMixerGroup);
			}
			else
			{
				AudioSource.outputAudioMixerGroup = Game.Instance.AudioPlayer.GetUiMixerGroup();
			}
			AudioSource.Play();
		}

		public void PlaySoundOneShot(AudioClip sound)
		{
			GameObject obj = new GameObject(base.name + " Temporary AudioSource");
			obj.transform.position = base.transform.position;
			AudioSource audioSource = obj.AddComponent<AudioSource>();
			audioSource.volume = AudioVolume;
			audioSource.clip = sound;
			audioSource.outputAudioMixerGroup = Game.Instance.AudioPlayer.GetUiMixerGroup();
			if (!string.IsNullOrEmpty(AudioMixerGroup))
			{
				SetAudioMixerGroup(audioSource, AudioMixerGroup);
			}
			audioSource.Play();
			UnityEngine.Object.DontDestroyOnLoad(obj);
			obj.AddComponent<XmlLayoutOneShotAudio>();
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (m_onDragEvents.Count > 0)
			{
				m_onDragEvents.ToList().ForEach(delegate(Action e)
				{
					e();
				});
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (m_onEndDragEvents.Count > 0)
			{
				m_onEndDragEvents.ToList().ForEach(delegate(Action e)
				{
					e();
				});
			}
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (m_onBeginDragEvents.Count > 0)
			{
				m_onBeginDragEvents.ToList().ForEach(delegate(Action e)
				{
					e();
				});
			}
		}

		public void OnDrop(PointerEventData eventData)
		{
			if (IsDropReceiver && eventData != null && !(ElementCurrentlyBeingDragged == null) && m_onElementDroppedEvents != null && m_onElementDroppedEvents.Count > 0)
			{
				m_onElementDroppedEvents.ToList().ForEach(delegate(Action<XmlElement, XmlElement> a)
				{
					a(ElementCurrentlyBeingDragged, this);
				});
			}
		}

		public void SetPivot(Vector2 pivot, RectTransform rectTransform = null)
		{
			if (rectTransform == null)
			{
				rectTransform = this.rectTransform;
			}
			if (!(rectTransform == null))
			{
				Vector2 size = rectTransform.rect.size;
				Vector2 vector = rectTransform.pivot - pivot;
				Vector3 vector2 = new Vector3(vector.x * size.x, vector.y * size.y);
				rectTransform.pivot = pivot;
				rectTransform.localPosition -= vector2;
			}
		}

		public void NotifySelectionStateChanged(SelectionState newSelectionState)
		{
			if (newSelectionState == SelectionState.Highlighted)
			{
				Highlight();
			}
			else if (selectionState == SelectionState.Highlighted && newSelectionState != SelectionState.Pressed)
			{
				RemoveHighlight();
			}
			selectionState = newSelectionState;
		}

		private void Highlight()
		{
			if (!string.IsNullOrEmpty(Tooltip))
			{
				xmlLayout.ShowTooltip(this, Tooltip);
			}
			if (selectable != null && !selectable.interactable)
			{
				return;
			}
			if (selectionState != SelectionState.Pressed)
			{
				PlaySound(OnMouseEnterSound);
			}
			if (hoverClasses != null && hoverClasses.Count > 0)
			{
				hoverClasses.ForEach(delegate(string c)
				{
					AddClass(c);
				});
			}
		}

		private void RemoveHighlight()
		{
			if (!string.IsNullOrEmpty(Tooltip))
			{
				xmlLayout.HideTooltip(this);
			}
			if (selectable != null && !selectable.interactable)
			{
				return;
			}
			PlaySound(OnMouseExitSound);
			if (hoverClasses != null && hoverClasses.Count > 0)
			{
				hoverClasses.ForEach(delegate(string c)
				{
					RemoveClass(c);
				});
			}
		}
	}
}
