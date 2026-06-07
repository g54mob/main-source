using System;
using System.Collections;
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.Operator;
using Events.FactoryFloor;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class AutoConnectView : FactoryBehaviorView<ConveyorBehaviour>
	{
		public enum ConnectType
		{
			Straight = 0,
			T = 1,
			X = 2,
			Corner = 3
		}

		[SerializeField]
		private FactoryObjectData _factoryObjectData;

		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private GridLocator _gridLocator;

		[SerializeField]
		private Transform _modelParent;

		[SerializeField]
		private GameObject _straightConnectPiece;

		[SerializeField]
		private GameObject _cornerConnectPiece;

		[SerializeField]
		private GameObject _tConnectPiece;

		[SerializeField]
		private GameObject _xConnectPiece;

		[SerializeField]
		private FactoryObjectSelectedVisuals _selectedVisuals;

		[SerializeField]
		private int _straightRotationOffset;

		[SerializeField]
		private int _cornerRotationOffset;

		[SerializeField]
		private int _tRotationOffset;

		[SerializeField]
		private bool _updateWhilePreviewing = true;

		[SerializeField]
		private bool _updateWhileNotPreviewing = true;

		private Vector3Int _position;

		private FactoryObject _factoryObject;

		private GameObject _currConnectModel;

		private int _rotation;

		private bool _initialized;

		protected override void Init()
		{
			base.Init();
			_currConnectModel = null;
			_factoryObject = _objectView.FactoryObject;
			_position = _factoryObject.Position;
			_rotation = _factoryObject.Rotation;
			_objectView.FactoryObjectReset += base.ResetFactoryObjectView;
			UpdateConnectModel();
			UpdateConnectedViews(_factoryObject.Position);
			_initialized = true;
		}

		protected override void PreviewInit(int objectId, BlueprintViewEventDto blueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto element)
		{
			base.PreviewInit(objectId, blueprintViewEventDto, element);
			_currConnectModel = null;
			if (_updateWhilePreviewing)
			{
				Vector3 worldPosition = element.Position + blueprintViewEventDto.Blueprint.Position;
				_position = _gridLocator.GetCellPosition(worldPosition);
				_rotation = element.Rotation + blueprintViewEventDto.Blueprint.Rotation;
				_objectView.FactoryObjectReset += base.ResetFactoryObjectView;
				GetPreviewConnectModel(blueprintViewEventDto, element);
			}
		}

		protected override void UpdatePreview(BlueprintViewEventDto blueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto element)
		{
			base.UpdatePreview(blueprintViewEventDto, element);
			if (_updateWhilePreviewing)
			{
				Vector3 worldPosition = element.Position + blueprintViewEventDto.Blueprint.Position;
				_position = _gridLocator.GetCellPosition(worldPosition);
				_rotation = element.Rotation + blueprintViewEventDto.Blueprint.Rotation;
				GetPreviewConnectModel(blueprintViewEventDto, element);
			}
		}

		protected override void ResetFactoryObject()
		{
			base.ResetFactoryObject();
			_straightConnectPiece.SetActive(value: false);
			_cornerConnectPiece.SetActive(value: false);
			_tConnectPiece.SetActive(value: false);
			_xConnectPiece.SetActive(value: false);
			_currConnectModel = null;
			if (_initialized)
			{
				UpdateConnectedViewsDelayed(_position);
			}
			_objectView.FactoryObjectReset -= base.ResetFactoryObjectView;
			_initialized = false;
		}

		private void UpdateConnectedViewsDelayed(Vector3Int position)
		{
			foreach (AutoConnectView connectedView in GetConnectedViews(position))
			{
				connectedView.StartCoroutine(connectedView.IDelayedUpdateConnectModel());
			}
		}

		public IEnumerator IDelayedUpdateConnectModel()
		{
			yield return new WaitForFixedUpdate();
			UpdateConnectModel();
		}

		private void UpdateConnectedViews(Vector3Int position)
		{
			foreach (AutoConnectView connectedView in GetConnectedViews(position))
			{
				connectedView.UpdateConnectModel();
			}
		}

		public void UpdateConnectModel()
		{
			bool[] connectedTilesAtPos = GetConnectedTilesAtPos(_factoryObject.Position);
			var (type, rotation) = GetConveyorTypeAndRot(connectedTilesAtPos);
			SetConnectModel(type, rotation);
			_modelParent.parent.localScale = base.transform.localScale;
		}

		private void GetPreviewConnectModel(BlueprintViewEventDto blueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto element)
		{
			Vector3 worldPosition = element.Position + blueprintViewEventDto.Blueprint.Position;
			Vector3Int cellPosition = _gridLocator.GetCellPosition(worldPosition);
			bool[] connectedTilesAtPos = GetConnectedTilesAtPos(cellPosition);
			Vector3Int vector3Int = new Vector3Int(Mathf.RoundToInt(element.Position.x), Mathf.RoundToInt(element.Position.y), Mathf.RoundToInt(element.Position.z));
			if (blueprintViewEventDto.Blueprint.BlueprintViewElementDtoPosLookup.TryGetValue(vector3Int + new Vector3Int(0, 0, 1), out var value))
			{
				connectedTilesAtPos[0] = connectedTilesAtPos[0] || value.ObjectId == _factoryObjectData.ID;
			}
			if (blueprintViewEventDto.Blueprint.BlueprintViewElementDtoPosLookup.TryGetValue(vector3Int + new Vector3Int(1, 0, 0), out value))
			{
				connectedTilesAtPos[1] = connectedTilesAtPos[1] || value.ObjectId == _factoryObjectData.ID;
			}
			if (blueprintViewEventDto.Blueprint.BlueprintViewElementDtoPosLookup.TryGetValue(vector3Int + new Vector3Int(0, 0, -1), out value))
			{
				connectedTilesAtPos[2] = connectedTilesAtPos[2] || value.ObjectId == _factoryObjectData.ID;
			}
			if (blueprintViewEventDto.Blueprint.BlueprintViewElementDtoPosLookup.TryGetValue(vector3Int + new Vector3Int(-1, 0, 0), out value))
			{
				connectedTilesAtPos[3] = connectedTilesAtPos[3] || value.ObjectId == _factoryObjectData.ID;
			}
			var (type, rotation) = GetConveyorTypeAndRot(connectedTilesAtPos);
			SetConnectModel(type, rotation);
		}

		private (ConnectType type, Quaternion rot) GetConveyorTypeAndRot(bool[] connectedTiles)
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (connectedTiles[i])
				{
					num++;
				}
			}
			switch (num)
			{
			case 0:
			case 4:
				return (type: ConnectType.X, rot: Quaternion.identity);
			case 1:
			{
				bool flag3 = connectedTiles[1] || connectedTiles[3];
				return (type: ConnectType.Straight, rot: flag3 ? Quaternion.identity : Quaternion.Euler(0f, 90f, 0f));
			}
			case 2:
			{
				bool flag = connectedTiles[1] && connectedTiles[3];
				bool flag2 = connectedTiles[0] && connectedTiles[2];
				if (flag || flag2)
				{
					return (type: ConnectType.Straight, rot: flag ? Quaternion.Euler(0f, _straightRotationOffset, 0f) : Quaternion.Euler(0f, 90 + _straightRotationOffset, 0f));
				}
				for (int j = 0; j < 4; j++)
				{
					int num2 = ((j != 3) ? (j + 1) : 0);
					if (connectedTiles[j] && connectedTiles[num2])
					{
						return (type: ConnectType.Corner, rot: Quaternion.Euler(0f, 90 * j + _cornerRotationOffset, 0f));
					}
				}
				break;
			}
			}
			if (num == 3)
			{
				for (int k = 0; k < 4; k++)
				{
					if (!connectedTiles[k])
					{
						return (type: ConnectType.T, rot: Quaternion.Euler(0f, 90 * k + _tRotationOffset, 0f));
					}
				}
			}
			return (type: ConnectType.X, rot: Quaternion.identity);
		}

		private bool[] GetConnectedTilesAtPos(Vector3Int position)
		{
			return new bool[4]
			{
				GetPosHasConnectingView(position + new Vector3Int(0, 0, 1)),
				GetPosHasConnectingView(position + new Vector3Int(1, 0, 0)),
				GetPosHasConnectingView(position + new Vector3Int(0, 0, -1)),
				GetPosHasConnectingView(position + new Vector3Int(-1, 0, 0))
			};
		}

		private bool GetPosHasConnectingView(Vector3Int position)
		{
			if (_factoryLayer.TryGetObjectAt(position, out var factoryObject))
			{
				return factoryObject.FactoryObjectData.ID == _factoryObjectData.ID;
			}
			return false;
		}

		private List<AutoConnectView> GetConnectedViews(Vector3Int position)
		{
			List<AutoConnectView> viewsList = new List<AutoConnectView>();
			AddViewsToList(ref viewsList, GetConnectedViewsAtPosition(position + new Vector3Int(0, 0, 1)));
			AddViewsToList(ref viewsList, GetConnectedViewsAtPosition(position + new Vector3Int(1, 0, 0)));
			AddViewsToList(ref viewsList, GetConnectedViewsAtPosition(position + new Vector3Int(0, 0, -1)));
			AddViewsToList(ref viewsList, GetConnectedViewsAtPosition(position + new Vector3Int(-1, 0, 0)));
			return viewsList;
			static void AddViewsToList(ref List<AutoConnectView> reference, AutoConnectView[] views)
			{
				foreach (AutoConnectView item in views)
				{
					reference.Add(item);
				}
			}
		}

		private AutoConnectView[] GetConnectedViewsAtPosition(Vector3Int position)
		{
			if (_factoryLayer.TryGetObjectAt(position, out var factoryObject) && factoryObject.FactoryObjectData.ID == _factoryObjectData.ID && FactoryObjectViewManager.Instance.TryGetFactoryObjectView(factoryObject.CreatedId, out var view))
			{
				return view.GetComponents<AutoConnectView>();
			}
			return Array.Empty<AutoConnectView>();
		}

		private void SetConnectModel(ConnectType type, Quaternion rotation)
		{
			GameObject gameObject = type switch
			{
				ConnectType.T => _tConnectPiece, 
				ConnectType.X => _xConnectPiece, 
				ConnectType.Corner => _cornerConnectPiece, 
				_ => _straightConnectPiece, 
			};
			if (_currConnectModel != gameObject)
			{
				if (_currConnectModel != null)
				{
					_currConnectModel.SetActive(value: false);
				}
				gameObject.SetActive(value: true);
			}
			_currConnectModel = gameObject;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localScale = Vector3.one;
			Vector3 eulerAngles = gameObject.transform.localRotation.eulerAngles;
			Quaternion quaternion = rotation * Quaternion.Euler(0f, -_rotation, 0f);
			gameObject.transform.localRotation = Quaternion.Euler(eulerAngles.x, quaternion.eulerAngles.y, eulerAngles.z);
		}
	}
}
