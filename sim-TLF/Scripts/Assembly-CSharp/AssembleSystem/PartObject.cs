using System;
using System.Collections.Generic;
using System.Linq;
using AssembleSystem.FSM.Parts;
using AssembleSystem.FallenItems;
using AssembleSystem.Utils;
using Infrastructure.PersistantData;
using Items;
using MyBox;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UniversalInventorySystem;
using Zenject;

namespace AssembleSystem
{
	public class PartObject : MonoBehaviour, IInventoryManagable, ISmoothMovable, IMoveable, IProgressable, IThrowable, IHoldFunctional
	{
		[SerializeField]
		private PartConfig _config;

		[SerializeField]
		private Item _inventoryItem;

		[SerializeField]
		[Range(0f, 2f)]
		[ReadOnly(new string[] { })]
		private float _progress;

		[SerializeField]
		private UnityEvent _onPlaced;

		[SerializeField]
		private UnityEvent _onStateChanged;

		[SerializeField]
		private bool _pickable = true;

		[Inject]
		private IFallenItemsService _fallenItemsService;

		private string _id;

		private PartObjectStateMachine _stateMachine;

		private GameObject _assembleParent;

		private float _smooth = 5f;

		private bool _canProgress;

		public GameObject AssembleParent => _assembleParent;

		public PartConfig Config => _config;

		public Item InventoryItem => _inventoryItem;

		public bool IsPickable => _pickable;

		public bool IsBase => _config.NecessaryAssembleParts.Count == 0;

		public PartObjectStateMachine StateMachine => _stateMachine;

		PartConfig IInventoryManagable.ItemConfig => _config;

		float IProgressable.CurrentProgress => _progress;

		bool IProgressable.CanProgress => _canProgress;

		string IInventoryManagable.ID => _id;

		float ISmoothMovable.Smooth => _smooth;

		ProgressToolType IProgressable.ProgressTool => _config.ToolType;

		private void Awake()
		{
			if (base.transform.parent != null)
			{
				_assembleParent = base.transform.parent.gameObject;
			}
			_id = DateTime.UtcNow.Ticks.ToString();
			_stateMachine = GetComponent<PartObjectStateMachine>();
		}

		private void Start()
		{
			EnableOutlineIfBase();
			_fallenItemsService?.Register(this);
		}

		private void OnDestroy()
		{
			_fallenItemsService?.Unregister(this);
		}

		public void SetCanProgress(bool value)
		{
			_canProgress = value;
		}

		public void SetIsPickable(bool value)
		{
			_pickable = value;
		}

		private void EnableOutlineIfBase()
		{
			if (IsBase && base.isActiveAndEnabled)
			{
				Outline orAddComponent = ComponentHolderProtocol.GetOrAddComponent<Outline>(this);
				orAddComponent.OutlineWidth = 5f;
				orAddComponent.OutlineColor = OutlineData.BASE_PART_OUTLINE_COLOR;
				orAddComponent.OutlineColor = new Color(OutlineData.BASE_PART_OUTLINE_COLOR.r, OutlineData.BASE_PART_OUTLINE_COLOR.g, OutlineData.BASE_PART_OUTLINE_COLOR.b, 0f);
			}
		}

		public void InvokeOnPlaced()
		{
			_onPlaced?.Invoke();
		}

		public void InvokeOnStateChanged()
		{
			_onStateChanged?.Invoke();
		}

		public bool AllNecessaryPartsPlaced()
		{
			return GetNecessaryParts().TrueForAll((PartObject x) => x.GetComponent<PartObjectStateMachine>().Placed);
		}

		public bool AllNecessaryPartsTightened()
		{
			return GetNecessaryParts().TrueForAll((PartObject x) => x.StateMachine.Tightened);
		}

		public List<PartObject> GetNecessaryParts()
		{
			if (_config.NecessaryAssembleParts.Count == 0)
			{
				return new List<PartObject>();
			}
			new List<PartObject>();
			return (from part in AssembleParent.GetComponent<AssembleObjectParent>().Parts
				where _config.NecessaryAssembleParts.Exists((PartConfig item) => part.name == item.Name)
				select part.GetComponent<PartObject>()).ToList();
		}

		public List<PartObject> GetDependantParts()
		{
			List<PartObject> result = new List<PartObject>();
			AssembleObjectParent assembleObjectParent = AssembleParent?.GetComponent<AssembleObjectParent>();
			if (assembleObjectParent == null)
			{
				return result;
			}
			List<PartConfig> dependantPartsConfigs = assembleObjectParent.GetDependantPartsConfigs(_config);
			return assembleObjectParent.GetPartsObjects(dependantPartsConfigs);
		}

		void IMoveable.Move(Vector3 targetPos)
		{
			MeshFilter component = GetComponent<MeshFilter>();
			if (component != null && component.mesh != null)
			{
				Vector3 center = component.mesh.bounds.center;
				Vector3 vector = base.transform.TransformPoint(center);
				Vector3 b = base.transform.position + (targetPos - vector);
				base.transform.position = Vector3.Lerp(base.transform.position, b, _smooth * Time.deltaTime);
			}
			else
			{
				base.transform.position = Vector3.Lerp(base.transform.position, targetPos, _smooth * Time.deltaTime);
			}
		}

		void IInventoryManagable.PickupItem()
		{
			_ = _pickable;
		}

		void IInventoryManagable.RemoveItem()
		{
			_ = _pickable;
		}

		public virtual void AddProgress(float value)
		{
			_progress += value;
			CheckForMaxProgress();
		}

		public virtual void SetProgress(float value)
		{
			_progress = value;
			CheckForMaxProgress();
		}

		private void CheckForMaxProgress()
		{
			_progress = Mathf.Clamp(_progress, 0f, 2f);
			_ = _progress;
			_ = 2f;
		}

		void IThrowable.Throw(Vector3 direction)
		{
			Rigidbody component = GetComponent<Rigidbody>();
			if (component != null)
			{
				component.isKinematic = false;
				component.linearVelocity = Vector3.zero;
				component.AddForce(direction, ForceMode.Impulse);
			}
		}

		void IHoldFunctional.Grab()
		{
			StateMachine.AllNecessaryPartsTightened = AllNecessaryPartsTightened();
		}

		void IHoldFunctional.Release()
		{
			StateMachine.AllNecessaryPartsTightened = false;
			if (_stateMachine.IsInRangeOfTempPart)
			{
				_stateMachine.Placed = true;
			}
		}
	}
}
