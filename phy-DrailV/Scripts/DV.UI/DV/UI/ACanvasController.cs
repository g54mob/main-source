using System;
using System.Collections;
using System.Collections.Generic;
using DV.UIFramework;
using DV.Utils;
using UnityEngine;

namespace DV.UI
{
	public abstract class ACanvasController<T> : NullCheckingSingletonBehaviour<ACanvasController<T>> where T : unmanaged, Enum
	{
		public enum DependencyType
		{
			OnlyCheck = 0,
			ChangeDefaultValue = 1,
			OverrideValue = 2,
			MaintainValue = 3
		}

		public struct DependencyRequirement
		{
			public T type;

			public bool desiredState;

			public DependencyType dependencyType;

			public bool selfState;
		}

		public class Element
		{
			public readonly List<DependencyRequirement> dependencyRequirements = new List<DependencyRequirement>();

			public readonly RequestSystem requestSystem = new RequestSystem(0f);

			public T Type { get; private set; }

			public GameObject reference { get; private set; }

			public bool pointerRequired { get; private set; }

			public bool preloadRequired { get; private set; }

			public bool triggerRepositioning { get; private set; }

			public bool pauseRequired { get; private set; }

			public Element(T type)
			{
				Type = type;
			}

			public bool ContainsOnlyCheckDependency(T type, bool desiredState, out bool selfState)
			{
				foreach (DependencyRequirement dependencyRequirement in dependencyRequirements)
				{
					if (dependencyRequirement.dependencyType == DependencyType.OnlyCheck && dependencyRequirement.desiredState == desiredState)
					{
						T type2 = dependencyRequirement.type;
						if (type2.Equals(type))
						{
							selfState = dependencyRequirement.selfState;
							return true;
						}
					}
				}
				selfState = false;
				return false;
			}

			public bool ContainsDependency(T type, out bool desiredState, out bool selfState)
			{
				foreach (DependencyRequirement dependencyRequirement in dependencyRequirements)
				{
					T type2 = dependencyRequirement.type;
					if (type2.Equals(type))
					{
						selfState = dependencyRequirement.selfState;
						desiredState = dependencyRequirement.desiredState;
						return true;
					}
				}
				selfState = false;
				desiredState = false;
				return false;
			}

			public Element SetReference(GameObject reference)
			{
				this.reference = reference;
				return this;
			}

			public Element Ensure(T type, bool desiredState, DependencyType dependencyType, bool selfState, bool condition = true)
			{
				if (!condition)
				{
					return this;
				}
				dependencyRequirements.Add(new DependencyRequirement
				{
					type = type,
					desiredState = desiredState,
					dependencyType = dependencyType,
					selfState = selfState
				});
				return this;
			}

			public Element RequirePointer(bool condition = true)
			{
				if (!condition)
				{
					return this;
				}
				pointerRequired = true;
				return this;
			}

			public Element RequirePreload()
			{
				preloadRequired = true;
				return this;
			}

			public Element RequireVRRepositioning()
			{
				triggerRepositioning = true;
				return this;
			}

			public Element RequirePause()
			{
				pauseRequired = true;
				return this;
			}
		}

		public Canvas mainCanvas;

		public Transform disabledOptimizedParent;

		public PopupNotificationReferences uiReferences;

		public ACanvasControllerProvider<T> provider;

		private Element[] elements;

		private Dictionary<T, Element> elementDictionary = new Dictionary<T, Element>();

		private List<Action> canSwitchActionList = new List<Action>();

		private T[] enumValues;

		public PopupManager PopupManager => uiReferences.popupManager;

		public NotificationManager NotificationManager => uiReferences.notificationManager;

		public event Action<Element> ElementToggled;

		public new static string AllowAutoCreate()
		{
			return null;
		}

		public abstract Element[] GetElements();

		protected override void Awake()
		{
			base.Awake();
			provider = GetComponent<ACanvasControllerProvider<T>>();
			elements = GetElements();
			Array values = Enum.GetValues(typeof(T));
			enumValues = new T[values.Length];
			values.CopyTo(enumValues, 0);
			Element[] array = elements;
			foreach (Element element in array)
			{
				if (element.reference != null)
				{
					if (!element.reference.TryGetComponent<UIOptimizedEnableDisable>(out var component))
					{
						component = element.reference.AddComponent<UIOptimizedEnableDisable>();
					}
					component.activeParent = mainCanvas.transform;
					component.disabledParent = disabledOptimizedParent;
					component.Enable();
					if (element.reference.TryGetComponent<NestedCanvas>(out var component2))
					{
						component2.ResetRectTransform();
					}
					component.Disable();
				}
				element.requestSystem.ValueChanged += delegate(float value)
				{
					provider.Toggle(element.reference, element.Type, value > 0.5f);
					this.ElementToggled?.Invoke(element);
					TrySetState(element, value > 0.5f);
				};
				Element[] array2 = elements;
				foreach (Element element2 in array2)
				{
					if (element2 != element && element2.ContainsDependency(element.Type, out var desiredState, out var selfState) && !element.ContainsDependency(element2.Type, out var _, out var _))
					{
						element.Ensure(element2.Type, !selfState, DependencyType.OnlyCheck, !desiredState);
					}
				}
				elementDictionary.Add(element.Type, element);
			}
		}

		private IEnumerator Start()
		{
			while (!provider.IsGameLoaded())
			{
				yield return null;
			}
			Element[] array = elements;
			foreach (Element element in array)
			{
				if (!(element.reference == null) && element.preloadRequired && !IsOn(element))
				{
					PreloadElement(element);
				}
			}
		}

		private void PreloadElement(Element element)
		{
			TrySetState(element, on: true);
			TrySetState(element, on: false);
		}

		private void Update()
		{
			Element[] array = elements;
			foreach (Element element in array)
			{
				if (provider.ShouldTryToggle(element.Type))
				{
					TryToggleState(element.Type);
				}
			}
		}

		public bool TryGetElement(T type, out Element element)
		{
			return elementDictionary.TryGetValue(type, out element);
		}

		public bool IsOn(Element element)
		{
			return IsOn(element.Type);
		}

		public bool IsOn(T type)
		{
			T[] array = enumValues;
			foreach (T val in array)
			{
				if (type.HasUnknownFlag(val) && elementDictionary.TryGetValue(val, out var value) && provider.IsOn(value.reference, val))
				{
					return true;
				}
			}
			return false;
		}

		public bool IsPointerRequired()
		{
			Element[] array = elements;
			foreach (Element element in array)
			{
				if (IsOn(element) && element.pointerRequired)
				{
					return true;
				}
			}
			return false;
		}

		public bool TryToggleState(T type)
		{
			return TrySetState(type, !IsOn(type));
		}

		public bool TrySetState(T type, bool on)
		{
			if (elementDictionary.TryGetValue(type, out var value))
			{
				return TrySetState(value, on);
			}
			return false;
		}

		protected bool TrySetState(Element element, bool on)
		{
			int count = canSwitchActionList.Count;
			bool flag = !element.requestSystem.HasRequests;
			foreach (DependencyRequirement dependencyRequirement in element.dependencyRequirements)
			{
				if (!flag)
				{
					break;
				}
				flag &= CheckDependency(dependencyRequirement);
			}
			if (flag)
			{
				for (int i = count; i < canSwitchActionList.Count; i++)
				{
					canSwitchActionList[i]?.Invoke();
				}
				bool flag2 = element.requestSystem.Value > 0.5f;
				element.requestSystem.SetDefaultValue(on ? 1 : 0);
				bool flag3 = false;
				bool flag4 = false;
				Element[] array = elements;
				foreach (Element element2 in array)
				{
					if (IsOn(element2))
					{
						if (!flag3 && element2.pointerRequired)
						{
							flag3 = true;
						}
						if (!flag4 && element2.pauseRequired)
						{
							flag4 = true;
						}
					}
				}
				if (element.requestSystem.Value > 0.5f != flag2)
				{
					provider.RequirePointer(flag3);
					provider.RequirePause(flag4);
					if (on && element.triggerRepositioning && provider.IsVR())
					{
						provider.RepositionVRCanvas();
					}
				}
				array = elements;
				foreach (Element element3 in array)
				{
					if (!element3.Equals(element) && element3.ContainsOnlyCheckDependency(element.Type, !on, out var selfState) && selfState == IsOn(element3))
					{
						TrySetState(element3, !selfState);
					}
				}
			}
			canSwitchActionList.RemoveRange(count, canSwitchActionList.Count - count);
			return flag;
			bool CheckDependency(DependencyRequirement dependencyRequirement)
			{
				if (!elementDictionary.TryGetValue(dependencyRequirement.type, out var dependency))
				{
					return true;
				}
				bool flag5 = on == dependencyRequirement.selfState;
				bool dependencyDesiredState = flag5 == dependencyRequirement.desiredState;
				switch (dependencyRequirement.dependencyType)
				{
				case DependencyType.OnlyCheck:
					if (!flag5)
					{
						return true;
					}
					return IsOn(dependency) == dependencyDesiredState;
				case DependencyType.OverrideValue:
				case DependencyType.MaintainValue:
					if (flag5)
					{
						if (dependencyRequirement.dependencyType == DependencyType.MaintainValue)
						{
							dependencyDesiredState = IsOn(dependency);
						}
						canSwitchActionList.Add(delegate
						{
							dependency.requestSystem.RequestValue(element.Type, dependencyDesiredState ? 1f : 0f);
						});
					}
					else
					{
						canSwitchActionList.Add(delegate
						{
							dependency.requestSystem.RemoveValue(element.Type);
						});
					}
					return true;
				case DependencyType.ChangeDefaultValue:
					if (flag5)
					{
						canSwitchActionList.Add(delegate
						{
							dependency.requestSystem.SetDefaultValue(dependencyDesiredState ? 1f : 0f);
						});
					}
					return true;
				default:
					return false;
				}
			}
		}
	}
}
