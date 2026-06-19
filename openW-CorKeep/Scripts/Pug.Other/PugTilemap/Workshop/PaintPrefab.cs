using Pug.UnityExtensions;
using UnityEngine;

namespace PugTilemap.Workshop
{
	public class PaintPrefab : Tool
	{
		private SpriteRenderer floatingPiece;

		public PaintPrefab(Workshop ed)
			: base(ed, "PntPfb")
		{
		}

		public override void OnEnable()
		{
			floatingPiece = ed.CreateFloatingPiece();
			floatingPiece.transform.eulerAngles = new Vector3(90f, 0f, 0f);
		}

		public override void OnDisable()
		{
			if (floatingPiece != null)
			{
				Object.DestroyImmediate(floatingPiece.gameObject);
			}
		}

		public override void OnMouseDrag()
		{
			if (floatingPiece.transform.Position2D() != ed.tileMouse)
			{
				OnMouseDown();
			}
		}

		public override void OnMouseMove()
		{
			floatingPiece.transform.localPosition = new Vector3(ed.tileMouse.x, 0.1f, ed.tileMouse.y);
			if (ed.prefabBrush < 0)
			{
				floatingPiece.sprite = null;
			}
			else
			{
				floatingPiece.sprite = ed.activePrefabs[ed.prefabBrush].icon;
			}
		}

		public override void OnMouseDown()
		{
			DoMouseDown();
		}

		public void DoMouseDown()
		{
			WorkshopPrefabBank.EdPrefab edPrefab = ed.activePrefabs[ed.prefabBrush];
			bool flag = false;
			for (int i = 0; i < ed.LastUsedLastUsedPrefabs.prefabs.Count; i++)
			{
				if (ed.LastUsedLastUsedPrefabs.prefabs[i].prefab == edPrefab.prefab)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				ed.LastUsedLastUsedPrefabs.AddPrefab(edPrefab);
				ed.lastUsedPrefabsHasChanged = true;
			}
			floatingPiece.gameObject.SetActive(value: false);
			float num = 0.99f;
			IEntityMonoBehaviourData entityMonoBehaviourData = null;
			Vector3Int vector3Int = new Vector3Int(ed.tileMouse.x, 0, ed.tileMouse.y);
			foreach (IEntityMonoBehaviourData @object in ed.multiMap.GetObjects(vector3Int))
			{
				float sqrMagnitude = (vector3Int - @object.Transform.position).sqrMagnitude;
				if (sqrMagnitude <= num)
				{
					num = sqrMagnitude;
					entityMonoBehaviourData = @object;
					if (edPrefab.mainObjectID == @object.ObjectInfo.objectID)
					{
						break;
					}
				}
			}
			if (!ed.shift)
			{
				if (entityMonoBehaviourData == null)
				{
					using (Workshop.Modification modification = ed.UndoableModification("Paint prefab"))
					{
						GameObject gameObject = edPrefab.Instantiate();
						gameObject.transform.localPosition = new Vector3Int(ed.tileMouse.x, 0, ed.tileMouse.y);
						modification.Create(gameObject.gameObject);
						return;
					}
				}
				if (edPrefab.mainObjectID != entityMonoBehaviourData.ObjectInfo.objectID && edPrefab.canShareTileWithOtherPrefabs)
				{
					using (Workshop.Modification modification2 = ed.UndoableModification("Paint prefab"))
					{
						GameObject gameObject2 = edPrefab.Instantiate();
						gameObject2.transform.localPosition = new Vector3Int(ed.tileMouse.x, 0, ed.tileMouse.y);
						modification2.Create(gameObject2.gameObject);
						return;
					}
				}
				if (edPrefab.mainObjectID != entityMonoBehaviourData.ObjectInfo.objectID)
				{
					return;
				}
				Debug.Log($"There's already a {edPrefab.name} near {ed.tileMouse}. Cycling instead (if possible).", entityMonoBehaviourData.GameObject);
				if (entityMonoBehaviourData is MultiVariantPseudoTile multiVariantPseudoTile)
				{
					using Workshop.Modification mod = ed.UndoableModification("Cycle " + edPrefab.name);
					multiVariantPseudoTile.CycleVariant(mod);
				}
			}
			else if (entityMonoBehaviourData != null)
			{
				using (Workshop.Modification modification3 = ed.UndoableModification("Delete prefab"))
				{
					modification3.Destroy(entityMonoBehaviourData.GameObject);
				}
			}
		}

		public override void OnMouseUp()
		{
			floatingPiece.gameObject.SetActive(value: true);
		}
	}
}
