using System.Collections;
using DV.CabControls;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace DV.Interaction
{
	public class GenericSwitch : MonoBehaviour
	{
		[Header("Switch")]
		public GameObject controlObject;

		public IndicatorEmission indicator;

		public string persistenceKey;

		public bool defaultState;

		[Header("Components to enable when ON")]
		public Behaviour[] componentsToEnable;

		[Header("Objects to activate when ON")]
		public GameObject[] objectsToActivate;

		[Header("Components to disable when ON")]
		public Behaviour[] componentsToDisable;

		[Header("Objects to deactivate when ON")]
		public GameObject[] objectsToDeactivate;

		[Header("Events")]
		public UnityEvent onTurnedOn;

		public UnityEvent onTurnedOff;

		public UnityEvent onInitializedToOn;

		public UnityEvent onInitializedToOff;

		private ControlImplBase control;

		private bool value;

		public bool IsOn
		{
			get
			{
				return value;
			}
			set
			{
				if (value != this.value)
				{
					this.value = value;
					UpdateVisuals();
					SyncControls();
					UpdateComponents();
					if (value)
					{
						onTurnedOn?.Invoke();
					}
					else
					{
						onTurnedOff?.Invoke();
					}
				}
			}
		}

		private void Start()
		{
			SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(Initialize());
		}

		private IEnumerator Initialize()
		{
			control = controlObject.GetComponent<ControlImplBase>();
			control.ValueChanged += OnValueChanged;
			if (!string.IsNullOrEmpty(persistenceKey))
			{
				JObject jObject = SingletonBehaviour<SaveGameManager>.Instance.data.GetJObject("Generic_switches");
				bool flag = false;
				if (jObject != null && jObject.TryGetValue(persistenceKey, out var jToken))
				{
					value = jToken.Value<bool>();
					flag = true;
				}
				if (!flag)
				{
					value = defaultState;
					SaveStateTo(SingletonBehaviour<SaveGameManager>.Instance.data);
				}
				SingletonBehaviour<SaveGameManager>.Instance.OnInternalDataUpdate += OnDataSaveRequested;
			}
			else
			{
				value = defaultState;
			}
			yield return WaitFor.EndOfFrame;
			if (!control)
			{
				Debug.LogError("There's no ControlImplBase component on " + controlObject.name + ", switch can't function, check setup.", this);
				yield break;
			}
			SyncControls();
			UpdateVisuals();
			UpdateComponents();
			if (value)
			{
				onInitializedToOn?.Invoke();
			}
			else
			{
				onInitializedToOff?.Invoke();
			}
		}

		private void OnDataSaveRequested(SaveGameData data)
		{
			SaveStateTo(data);
		}

		private void OnDisable()
		{
			if (!UnloadWatcher.isUnloading && !string.IsNullOrEmpty(persistenceKey))
			{
				SaveStateTo(SingletonBehaviour<SaveGameManager>.Instance.data);
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<SaveGameManager>.Instance.OnInternalDataUpdate -= OnDataSaveRequested;
			}
		}

		private void SaveStateTo(SaveGameData data)
		{
			if (!string.IsNullOrEmpty(persistenceKey) && !(SingletonBehaviour<SaveGameManager>.Instance == null))
			{
				JObject jObject = SingletonBehaviour<SaveGameManager>.Instance.data.GetJObject("Generic_switches");
				if (jObject == null)
				{
					jObject = new JObject();
				}
				jObject[persistenceKey] = value;
				SingletonBehaviour<SaveGameManager>.Instance.data.SetJObject("Generic_switches", jObject);
			}
		}

		private void OnValueChanged(ValueChangedEventArgs e)
		{
			bool flag = e.newValue > 0.5f;
			if (flag != value)
			{
				value = flag;
				UpdateVisuals();
				UpdateComponents();
				if (value)
				{
					onTurnedOn?.Invoke();
				}
				else
				{
					onTurnedOff?.Invoke();
				}
			}
		}

		private void UpdateComponents()
		{
			Behaviour[] array = componentsToEnable;
			foreach (Behaviour behaviour in array)
			{
				if ((bool)behaviour)
				{
					behaviour.enabled = value;
				}
			}
			array = componentsToDisable;
			foreach (Behaviour behaviour2 in array)
			{
				if ((bool)behaviour2)
				{
					behaviour2.enabled = !value;
				}
			}
			GameObject[] array2 = objectsToActivate;
			foreach (GameObject gameObject in array2)
			{
				if ((bool)gameObject)
				{
					gameObject.SetActive(value);
				}
			}
			array2 = objectsToDeactivate;
			foreach (GameObject gameObject2 in array2)
			{
				if ((bool)gameObject2)
				{
					gameObject2.SetActive(!value);
				}
			}
		}

		private void SyncControls()
		{
			control.SetValue(value ? 1f : 0f);
		}

		private void UpdateVisuals()
		{
			if ((bool)indicator)
			{
				indicator.Value = (value ? 1f : 0f);
			}
		}
	}
}
