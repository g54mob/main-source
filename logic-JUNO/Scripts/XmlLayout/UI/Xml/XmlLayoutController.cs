using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ModApi.Ui;
using UI.Xml.Tags;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml
{
	[RequireComponent(typeof(XmlLayout))]
	public class XmlLayoutController : MonoBehaviour, IXmlLayoutController
	{
		private XmlLayout _xmlLayout;

		public bool SuppressEventHandling;

		private List<IXmlElementReference> xmlElementReferences = new List<IXmlElementReference>();

		Action<IXmlLayoutController> IXmlLayoutController.OnLayoutRebuilt { get; set; }

		IXmlLayout IXmlLayoutController.XmlLayout => xmlLayout;

		public XmlLayout xmlLayout
		{
			get
			{
				if (_xmlLayout == null)
				{
					_xmlLayout = GetComponent<XmlLayout>();
				}
				return _xmlLayout;
			}
		}

		public bool LayoutRebuildInProgress { get; set; }

		public object EventTarget { get; set; }

		public Action<XmlLayoutController> OnLayoutRebuilt { get; set; }

		public virtual void ReceiveMessage(string methodName, string value, RectTransform source = null)
		{
			if (SuppressEventHandling)
			{
				return;
			}
			object obj = ((EventTarget != null) ? EventTarget : this);
			MethodInfo method = obj.GetType().GetMethod(methodName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (method == null)
			{
				Debug.LogError("[XmlLayout][XmlLayoutController] No method named '" + methodName + "' has been defined in Event Target '" + obj.GetType().Name + "'!");
				return;
			}
			if (value == null || method.GetParameters().Count() == 0)
			{
				method.Invoke(obj, null);
				return;
			}
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters.Length == 0)
			{
				method.Invoke(obj, null);
				return;
			}
			Type parameterType = parameters.FirstOrDefault().ParameterType;
			if (value == "this" && source != null)
			{
				object obj2 = source;
				if (parameterType.IsSubclassOf(typeof(MonoBehaviour)))
				{
					obj2 = source.GetComponent(parameterType);
					if (obj2 == null)
					{
						obj2 = source.GetComponentInChildren(parameterType);
					}
				}
				method.Invoke(obj, new object[1] { obj2 });
			}
			else
			{
				method.Invoke(obj, new object[1] { value.ChangeToType(parameterType, xmlLayout) });
			}
		}

		public virtual void ReceiveElementDroppedMessage(string methodName, XmlElement item, XmlElement droppedOn)
		{
			if (!SuppressEventHandling)
			{
				MethodInfo method = GetType().GetMethod(methodName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (method == null)
				{
					Debug.LogError("[XmlLayout][XmlLayoutController] No method named '" + methodName + "' has been defined in this XmlLayoutController!");
					return;
				}
				object obj = ((EventTarget != null) ? EventTarget : this);
				method.Invoke(obj, new object[2] { item, droppedOn });
			}
		}

		public virtual void LayoutRebuilt(ParseXmlResult parseResult)
		{
			if (OnLayoutRebuilt != null)
			{
				OnLayoutRebuilt(this);
			}
			((IXmlLayoutController)this).OnLayoutRebuilt?.Invoke(this);
		}

		internal virtual void ViewModelUpdated(bool triggerLayoutRebuild = true)
		{
		}

		public virtual void PreLayoutRebuilt()
		{
			LayoutRebuildInProgress = true;
		}

		public virtual void PostLayoutRebuilt()
		{
			LayoutRebuildInProgress = false;
		}

		internal virtual void ViewModelMemberChanged(string propertyName)
		{
		}

		internal virtual string ProcessViewModel(string xml)
		{
			return xml;
		}

		public virtual void Show()
		{
			xmlLayout.Show();
		}

		public virtual void Hide(Action onCompleteCallback = null)
		{
			xmlLayout.Hide(onCompleteCallback);
		}

		public XmlElementReference<XmlElement> XmlElementReference(string id)
		{
			return XmlElementReference<XmlElement>(id);
		}

		public XmlElementReference<T> XmlElementReference<T>(string id) where T : MonoBehaviour
		{
			XmlElementReference<T> xmlElementReference = new XmlElementReference<T>(xmlLayout, id);
			xmlElementReferences.Add(xmlElementReference);
			return xmlElementReference;
		}

		internal void NotifyXmlElementReferencesOfLayoutRebuild()
		{
			xmlElementReferences.ForEach(delegate(IXmlElementReference x)
			{
				x.ClearElement();
			});
		}
	}
	public class XmlLayoutController<T> : XmlLayoutControllerMVVM where T : XmlLayoutViewModel, new()
	{
		private bool _viewModelUpdatePending;

		private bool _viewModelPrepopulated;

		public bool listenForViewModelChanges = true;

		protected T _viewModel;

		private List<PropertyInfo> _properties;

		public T viewModel
		{
			get
			{
				if (_viewModel == null)
				{
					_viewModel = new T();
					InitialiseViewModelProxy(_viewModel);
					XmlLayoutTimer.AtEndOfFrame(TriggerPrepopulateViewModelData, this, forceEvenIfObjectIsInactive: true);
				}
				return _viewModel;
			}
			set
			{
				_viewModel = value;
				InitialiseViewModelProxy(_viewModel);
				ViewModelUpdated();
			}
		}

		private void InitialiseViewModelProxy(T viewModel)
		{
			_viewModel = XmlLayoutViewModel<T>.Create(_viewModel);
			_viewModel.Initialise(this);
		}

		internal override string ProcessViewModel(string xml)
		{
			if (viewModel == null)
			{
				return xml;
			}
			if (!_viewModelPrepopulated)
			{
				TriggerPrepopulateViewModelData();
			}
			foreach (PropertyInfo property in GetProperties())
			{
				object value = property.GetValue(viewModel, XmlLayoutUtilities.BindingFlags, null, null, null);
				xml = xml.Replace("{" + property.Name + "}", (value != null) ? value.ToString() : string.Empty);
			}
			return xml;
		}

		private List<PropertyInfo> GetProperties()
		{
			if (_properties == null)
			{
				_properties = typeof(T).GetProperties().ToList();
			}
			return _properties;
		}

		public virtual void OnTwoWayBoundViewModelMemberChanged(string memberName)
		{
			ViewModelMemberChanged(memberName);
		}

		public virtual void OnTwoWayBoundViewModelListItemMemberChanged(string listName, int index, string itemProperty = null)
		{
		}

		internal override void ViewModelMemberChanged(string memberName)
		{
			if (!listenForViewModelChanges)
			{
				return;
			}
			if (base.xmlLayout.Xml.Contains("{" + memberName + "}"))
			{
				ViewModelUpdated();
				return;
			}
			List<XmlElement> elementsForDataSource = base.xmlLayout.GetElementsForDataSource(memberName, memberName);
			if (elementsForDataSource.Count <= 0)
			{
				return;
			}
			PropertyInfo property = typeof(T).GetProperty(memberName);
			FieldInfo field = typeof(T).GetField(memberName);
			object value = null;
			if (property != null)
			{
				value = property.GetValue(viewModel, XmlLayoutUtilities.BindingFlags, null, null, null);
			}
			else if (field != null)
			{
				value = field.GetValue(viewModel);
			}
			if (value is IObservableList)
			{
				elementsForDataSource.ForEach(delegate(XmlElement e)
				{
					e.SetListData((IObservableList)value);
				});
			}
			else
			{
				elementsForDataSource.ForEach(delegate(XmlElement e)
				{
					e.SetValue((value != null) ? value.ToString() : null, fireEventHandlers: false);
				});
			}
		}

		internal void UpdateDataSourcePropertyValue(string propertyName)
		{
			if (!listenForViewModelChanges || string.IsNullOrEmpty(propertyName))
			{
				return;
			}
			List<XmlElement> elementsForDataSource = base.xmlLayout.GetElementsForDataSource(propertyName, propertyName);
			if (elementsForDataSource.Count <= 0)
			{
				return;
			}
			PropertyInfo property = typeof(T).GetProperty(propertyName);
			FieldInfo field = typeof(T).GetField(propertyName);
			object value = null;
			if (property != null)
			{
				value = property.GetValue(viewModel, XmlLayoutUtilities.BindingFlags, null, null, null);
			}
			else if (field != null)
			{
				value = field.GetValue(viewModel);
			}
			if (value is IObservableList)
			{
				elementsForDataSource.ForEach(delegate(XmlElement e)
				{
					e.SetListData((IObservableList)value);
				});
			}
			else
			{
				elementsForDataSource.ForEach(delegate(XmlElement e)
				{
					e.SetValue((value != null) ? value.ToString() : null, fireEventHandlers: false);
				});
			}
		}

		internal override void ViewModelUpdated(bool triggerLayoutRebuild = true)
		{
			if (!listenForViewModelChanges || _viewModelUpdatePending)
			{
				return;
			}
			_viewModelUpdatePending = true;
			XmlLayoutTimer.AtEndOfFrame(delegate
			{
				if (triggerLayoutRebuild)
				{
					base.xmlLayout.RebuildLayout(forceEvenIfXmlUnchanged: true);
				}
				if (base.xmlLayout.ElementDataSources.Count > 0)
				{
					(from e in base.xmlLayout.ElementDataSources
						where e is XmlLayoutDropdownDataSource
						select ((XmlLayoutDropdownDataSource)e).OptionsDataSource).Distinct().ToList().ForEach(delegate(string el)
					{
						UpdateDataSourcePropertyValue(el);
					});
					base.xmlLayout.ElementDataSources.Select((XmlElementDataSource e) => e.DataSource).Distinct().ToList()
						.ForEach(delegate(string ed)
						{
							UpdateDataSourcePropertyValue(ed);
						});
				}
				_viewModelUpdatePending = false;
				XmlLayoutTimer.AtEndOfFrame(delegate
				{
					LayoutRebuilder.ForceRebuildLayoutImmediate(base.xmlLayout.transform as RectTransform);
				}, this);
			}, this);
		}

		private void TriggerPrepopulateViewModelData()
		{
			if (!_viewModelPrepopulated)
			{
				bool flag = listenForViewModelChanges;
				listenForViewModelChanges = false;
				PrepopulateViewModelData();
				listenForViewModelChanges = flag;
				_viewModelPrepopulated = true;
			}
		}

		protected virtual void PrepopulateViewModelData()
		{
		}

		public override void SetViewModelValue(string memberName, object newValue, bool fromTwoWayBinding = false)
		{
			viewModel.SetValue(memberName, newValue);
			if (fromTwoWayBinding)
			{
				OnTwoWayBoundViewModelMemberChanged(memberName);
			}
		}

		public override void SetViewModelListItemValue(string listName, int index, string memberName, object newValue, bool fromTwoWayBinding = false)
		{
			viewModel.SetListItemValue(listName, index, memberName, newValue);
			if (fromTwoWayBinding)
			{
				OnTwoWayBoundViewModelListItemMemberChanged(listName, index, memberName);
			}
		}

		public override Type GetViewModelMemberDataType(string memberName)
		{
			MemberInfo memberInfo = viewModel.GetType().GetMember(memberName).FirstOrDefault();
			if (memberInfo != null)
			{
				return memberInfo.GetMemberDataType();
			}
			return null;
		}

		public override void ReceiveMessage(string methodName, string value, RectTransform source = null)
		{
			if (SuppressEventHandling)
			{
				return;
			}
			if (value != null && value.StartsWith("{") && value.EndsWith("}") && value.Contains('.'))
			{
				XmlLayoutListItem componentInParent = source.GetComponentInParent<XmlLayoutListItem>();
				string guid = componentInParent.guid;
				if (componentInParent != null)
				{
					IObservableList list = componentInParent.GetComponentInParent<XmlLayoutList>().list;
					MethodInfo method = GetType().GetMethod(methodName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					if (method != null)
					{
						ParameterInfo[] parameters = method.GetParameters();
						if (parameters.Length != 0)
						{
							Type parameterType = parameters.FirstOrDefault().ParameterType;
							if (parameterType == typeof(int))
							{
								if (value.EndsWith(".index}"))
								{
									value = list.GetIndexByGUID(guid).ToString();
								}
							}
							else if (parameterType == typeof(string))
							{
								if (value.EndsWith(".guid}"))
								{
									value = guid;
								}
							}
							else if (parameterType.IsSubclassOf(typeof(ObservableListItem)) && value.EndsWith(".item}"))
							{
								method.Invoke(this, new object[1] { list.GetItemByGUID(guid) });
								return;
							}
						}
					}
				}
			}
			base.ReceiveMessage(methodName, value, source);
		}
	}
}
