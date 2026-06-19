using System;
using System.Collections.Generic;
using System.Linq;
using AssembleSystem.FSM.ParentObjesct;
using AssembleSystem.Utils;
using UnityEngine;

namespace AssembleSystem
{
	[RequireComponent(typeof(ParentPartStateMachine))]
	public class AssembleObjectParent : MonoBehaviour
	{
		[HideInInspector]
		public List<GameObject> Parts = new List<GameObject>();

		public Transform TestMovingPoint;

		public Action OnUpdate;

		public int TightenedItems;

		[SerializeField]
		private Vector3 _offset;

		[SerializeField]
		private Vector3 _rotationOffset;

		[SerializeField]
		private ParentPartStateMachine _stateMachine;

		[SerializeField]
		private AssembleItemConfig _itemConfig;

		public AssembleItemConfig ItemConfig => _itemConfig;

		public ParentPartStateMachine StateMachine => _stateMachine;

		public Vector3 Offset => _offset;

		public Vector3 RotationOffset => _rotationOffset;

		private void Awake()
		{
			GameObject gameObject = new GameObject("TestMovingPoint_" + base.gameObject.name);
			gameObject.transform.SetParent(base.transform);
			gameObject.transform.SetParent(null);
			gameObject.transform.localPosition = Vector3.zero;
			TestMovingPoint = gameObject.transform;
			for (int i = 0; i < base.transform.childCount; i++)
			{
				Transform child = base.transform.GetChild(i);
				if (_itemConfig.PartsConfig.Any((PartConfig part) => part.Name == child.name))
				{
					Parts.Add(child.gameObject);
				}
			}
		}

		private void Update()
		{
			OnUpdate?.Invoke();
		}

		public List<PartConfig> GetDependantPartsConfigs(PartConfig config)
		{
			List<PartConfig> list = new List<PartConfig>();
			foreach (PartConfig item in _itemConfig.PartsConfig)
			{
				if (item.NecessaryAssembleParts.Contains(config))
				{
					list.Add(item);
				}
			}
			return list;
		}

		public List<PartObject> GetPartsObjects(List<PartConfig> partsConfig)
		{
			List<PartObject> list = new List<PartObject>();
			foreach (PartConfig item in partsConfig)
			{
				foreach (GameObject part in Parts)
				{
					if (!(part.gameObject.name != item.name))
					{
						PartObject component = part.GetComponent<PartObject>();
						if (component != null && component.Config == item)
						{
							list.Add(component);
						}
					}
				}
			}
			return list;
		}
	}
}
