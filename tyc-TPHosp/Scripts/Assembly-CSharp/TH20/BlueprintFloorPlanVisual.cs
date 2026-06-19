using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class BlueprintFloorPlanVisual : RoomFloorPlanVisual
	{
		public bool CompletelyInvalid;

		[DontSave]
		private MaterialPropertyBlock _validPropertyBlock;

		[DontSave]
		private MaterialPropertyBlock _invalidPropertyBlock;

		[DontSave]
		private MaterialPropertyBlock _invalidSizePropertyBlock;

		public BlueprintFloorPlanVisual(WorldState worldState, VisualManager visualManager, DataViewManager dataViewManager, RoomItemVisualEdit.Config roomItemEditConfig, BuildEvents buildEvents, string roomName, GameObject floorTilePrefab, RoomWallDefinition wallDefinition, Material materialValid, Material materialInvalid, Material materialInvalidSize)
			: base(worldState, visualManager, roomName, floorTilePrefab, dataViewManager.ValueMaterial, roomItemEditConfig, wallDefinition, buildEvents)
		{
			_validPropertyBlock = new MaterialPropertyBlock();
			_invalidPropertyBlock = new MaterialPropertyBlock();
			_invalidSizePropertyBlock = new MaterialPropertyBlock();
			SetMaterialParams(materialValid, materialInvalid, materialInvalidSize);
		}

		private void SetMaterialParams(Material materialValid, Material materialInvalid, Material materialInvalidSize)
		{
			if (materialValid != null)
			{
				float value = materialValid.GetFloat("_ZBias");
				_validPropertyBlock.SetColor("_Color", materialValid.color);
				_validPropertyBlock.SetTexture("_MainTex", materialValid.mainTexture);
				_validPropertyBlock.SetFloat("_ZBias", value);
			}
			if (materialInvalid != null)
			{
				float value2 = materialInvalid.GetFloat("_ZBias");
				_invalidPropertyBlock.SetColor("_Color", materialInvalid.color);
				_invalidPropertyBlock.SetTexture("_MainTex", materialInvalid.mainTexture);
				_invalidPropertyBlock.SetFloat("_ZBias", value2);
			}
			if (materialInvalidSize != null)
			{
				float value3 = materialInvalidSize.GetFloat("_ZBias");
				_invalidSizePropertyBlock.SetColor("_Color", materialInvalidSize.color);
				_invalidSizePropertyBlock.SetTexture("_MainTex", materialInvalidSize.mainTexture);
				_invalidSizePropertyBlock.SetFloat("_ZBias", value3);
			}
		}

		public void SetAppearance(RoomWallDefinition wallDefinition, Material materialValid, Material materialInvalid)
		{
			if (_wallDefinition != wallDefinition)
			{
				_wallDefinition = wallDefinition;
				SetMaterialParams(materialValid, materialInvalid, null);
			}
		}

		public void SetWallsFloorVisible(bool visible)
		{
			GameObjectUtils.SetActive(_wallsContainer.gameObject, visible);
			GameObjectUtils.SetActive(_floorsContainer.gameObject, visible);
		}

		public override void UpdateFromRoom(FloorPlan floorPlanIn, Vector3 cellOffset = default(Vector3), float rotationOffset = 0f)
		{
			base.UpdateFromRoom(floorPlanIn, cellOffset, rotationOffset);
			if (!(floorPlanIn is BlueprintFloorPlan blueprintFloorPlan))
			{
				return;
			}
			bool flag = !blueprintFloorPlan.ValidRoomSize;
			MaterialPropertyBlock propertyBlock = (flag ? _invalidSizePropertyBlock : _validPropertyBlock);
			foreach (KeyValuePair<Transform, Transform> wallObject in _wallObjects)
			{
				wallObject.Key.GetComponent<MeshRenderer>().SetPropertyBlock(propertyBlock);
			}
			if (blueprintFloorPlan.TileValidity == null)
			{
				return;
			}
			int num = 0;
			bool[,] tileValidity = blueprintFloorPlan.TileValidity;
			for (int i = 0; i < _floorPlan.Height(); i++)
			{
				for (int j = 0; j < _floorPlan.Width(); j++)
				{
					if (_floorPlan[j, i])
					{
						MaterialPropertyBlock propertyBlock2 = ((!tileValidity.ValidIndex(j, i) || !tileValidity[j, i] || CompletelyInvalid) ? _invalidPropertyBlock : ((!flag) ? _validPropertyBlock : _invalidSizePropertyBlock));
						_floorTileObjects[num].GetComponentInChildren<Renderer>().SetPropertyBlock(propertyBlock2);
						num++;
					}
				}
			}
		}
	}
}
