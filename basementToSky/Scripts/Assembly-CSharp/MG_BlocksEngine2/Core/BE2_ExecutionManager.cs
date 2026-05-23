using System.Collections.Generic;
using MG_BlocksEngine2.DragDrop;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace MG_BlocksEngine2.Core
{
	public class BE2_ExecutionManager : MonoBehaviour
	{
		private List<I_BE2_TargetObject> _targetObjectsList;

		private List<I_BE2_ProgrammingEnv> _programmingEnvsList;

		public I_BE2_BlocksStack[] blocksStacksArray;

		private static BE2_ExecutionManager _instance;

		private BE2_Pointer _pointer;

		private I_BE2_InputManager _inputManager;

		private List<UnityAction> _actions = new List<UnityAction>();

		private UnityEvent OnUpdate = new UnityEvent();

		private UnityEvent OnLateUpdate = new UnityEvent();

		public List<I_BE2_ProgrammingEnv> ProgrammingEnvsList => _programmingEnvsList;

		public static BE2_ExecutionManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = Object.FindObjectOfType<BE2_ExecutionManager>();
				}
				return _instance;
			}
			set
			{
				_instance = value;
			}
		}

		public void AddToUpdate(UnityAction action)
		{
			if (!_actions.Contains(action))
			{
				OnUpdate.AddListener(action);
				_actions.Add(action);
			}
		}

		public void RemoveFromUpdate(UnityAction action)
		{
			if (_actions.Contains(action))
			{
				OnUpdate.RemoveListener(action);
				_actions.Remove(action);
			}
		}

		public void AddToLateUpdate(UnityAction action)
		{
			if (!_actions.Contains(action))
			{
				OnLateUpdate.AddListener(action);
				_actions.Add(action);
			}
		}

		public void RemoveFromLateUpdate(UnityAction action)
		{
			if (_actions.Contains(action))
			{
				OnLateUpdate.RemoveListener(action);
				_actions.Remove(action);
			}
		}

		private void Awake()
		{
			_pointer = BE2_Pointer.Instance;
			_inputManager = BE2_InputManager.Instance;
			UpdateTargetObjects();
			UpdateProgrammingEnvsList();
			Instance = this;
		}

		private void Start()
		{
			UpdateBlocksStackList();
			BusStopUI.OnRocketRetrived += BusStopUI_OnRocketRetrived;
		}

		private void OnDestroy()
		{
			BusStopUI.OnRocketRetrived -= BusStopUI_OnRocketRetrived;
		}

		private void BusStopUI_OnRocketRetrived()
		{
			Stop();
		}

		private void Update()
		{
			_pointer.OnUpdate();
			_inputManager.OnUpdate();
			OnUpdate.Invoke();
		}

		private void LateUpdate()
		{
			OnLateUpdate.Invoke();
		}

		public void Play()
		{
			BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnPlay);
			EventSystem.current.SetSelectedGameObject(null);
		}

		public void Stop()
		{
			BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnStop);
			EventSystem.current.SetSelectedGameObject(null);
		}

		public void UpdateBlocksStackList()
		{
			blocksStacksArray = new I_BE2_BlocksStack[0];
			int count = _programmingEnvsList.Count;
			for (int i = 0; i < count; i++)
			{
				I_BE2_ProgrammingEnv i_BE2_ProgrammingEnv = _programmingEnvsList[i];
				int childCount = i_BE2_ProgrammingEnv.Transform.childCount;
				for (int j = 0; j < childCount; j++)
				{
					I_BE2_BlocksStack component = i_BE2_ProgrammingEnv.Transform.GetChild(j).GetComponent<I_BE2_BlocksStack>();
					if (component != null)
					{
						BE2_ArrayUtils.Add(ref blocksStacksArray, component);
						component.TargetObject = i_BE2_ProgrammingEnv.TargetObject;
						AddToUpdate(component.Execute);
					}
				}
			}
			BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnBlocksStackArrayUpdate);
		}

		public void AddToBlocksStackArray(I_BE2_BlocksStack blocksStack, I_BE2_TargetObject targetObject)
		{
			if (BE2_ArrayUtils.FindAll(ref blocksStacksArray, (I_BE2_BlocksStack x) => x == blocksStack).Length == 0)
			{
				BE2_ArrayUtils.Add(ref blocksStacksArray, blocksStack);
				blocksStack.TargetObject = targetObject;
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnBlocksStackArrayUpdate);
				AddToUpdate(blocksStack.Execute);
			}
		}

		public void RemoveFromBlocksStackList(I_BE2_BlocksStack blocksStack)
		{
			if (BE2_ArrayUtils.FindAll(ref blocksStacksArray, (I_BE2_BlocksStack x) => x == blocksStack).Length != 0)
			{
				BE2_ArrayUtils.Remove(ref blocksStacksArray, blocksStack);
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnBlocksStackArrayUpdate);
				RemoveFromUpdate(blocksStack.Execute);
			}
		}

		private void UpdateTargetObjects()
		{
			_targetObjectsList = new List<I_BE2_TargetObject>();
			GameObject[] array = Object.FindObjectsOfType<GameObject>();
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				I_BE2_TargetObject component = array[i].GetComponent<I_BE2_TargetObject>();
				if (component != null)
				{
					_targetObjectsList.Add(component);
				}
			}
		}

		public void UpdateProgrammingEnvsList()
		{
			_programmingEnvsList = new List<I_BE2_ProgrammingEnv>();
			GameObject[] array = Object.FindObjectsOfType<GameObject>();
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				I_BE2_ProgrammingEnv component = array[i].GetComponent<I_BE2_ProgrammingEnv>();
				if (component != null)
				{
					_programmingEnvsList.Add(component);
				}
			}
		}
	}
}
