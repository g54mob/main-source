using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PugTilemap.Workshop
{
	public class Workshop
	{
		public class Modification : IDisposable
		{
			private readonly Workshop ed;

			internal readonly string operation;

			internal Modification(Workshop ed, string op)
			{
				this.ed = ed;
				operation = op;
			}

			public void Destroy(GameObject o)
			{
				UnityEngine.Object.DestroyImmediate(o);
			}

			public void Create(UnityEngine.Object o)
			{
			}

			public void StartChange(UnityEngine.Object o)
			{
			}

			public void StartChange(params UnityEngine.Object[] os)
			{
				foreach (UnityEngine.Object o in os)
				{
					StartChange(o);
				}
			}

			public void EndChange(params UnityEngine.Object[] os)
			{
				foreach (UnityEngine.Object o in os)
				{
					EndChange(o);
				}
			}

			public void EndChange(UnityEngine.Object o)
			{
			}

			public void Dispose()
			{
				ed.multiMap.Commit();
				ed.currentModification = null;
			}
		}

		public PugMultiMap multiMap;

		public int currentTileset;

		public TileType tile;

		public int prefabBrush = -1;

		public Dictionary<string, Sprite> sprites;

		public Dictionary<string, Sprite> spritesByTile;

		public const HideFlags junkHideFlags = HideFlags.DontSave | HideFlags.NotEditable;

		private int _toolNumber = -1;

		public List<WorkshopPrefabBank.EdPrefab> activePrefabs;

		private WorkshopPrefabBank _lastUsedPrefabs;

		public bool lastUsedPrefabsHasChanged;

		public Vector2Int tileMouse;

		public bool shift;

		public Tool[] allTools;

		private Modification currentModification;

		public int toolNumber
		{
			get
			{
				return _toolNumber;
			}
			set
			{
				if (value != _toolNumber)
				{
					_toolNumber = value;
					tool?.OnDisable();
					tool = ((value < 0) ? null : allTools[value]);
					tool?.OnEnable();
				}
			}
		}

		public WorkshopPrefabBank LastUsedLastUsedPrefabs
		{
			get
			{
				if (_lastUsedPrefabs == null)
				{
					_lastUsedPrefabs = Resources.Load<WorkshopPrefabBank>("MapWorkshop/LastUsedMapWorkshopPrefabBank");
					if (_lastUsedPrefabs == null)
					{
						_lastUsedPrefabs = ScriptableObject.CreateInstance(typeof(WorkshopPrefabBank)) as WorkshopPrefabBank;
						_lastUsedPrefabs.prefabs = new List<WorkshopPrefabBank.EdPrefab>();
					}
					_lastUsedPrefabs.InitVolatile();
				}
				return _lastUsedPrefabs;
			}
		}

		public Tool tool { get; private set; }

		public PugMapLayer EnsureLayerPresentAt(Vector3 position)
		{
			if (currentTileset == -1 || TilesetTypeUtility.GetTileset(currentTileset).GetDef(tile) == null)
			{
				return null;
			}
			return multiMap.EnsureLayerPresent(position, currentTileset, TilesetTypeUtility.GetTileset(currentTileset).GetDef(tile).layerName);
		}

		public Workshop(PugMultiMap map)
		{
			multiMap = map;
			currentTileset = 0;
			allTools = new Tool[4]
			{
				new Paint(this),
				new PaintPrefab(this),
				new Select(this),
				new Fill(this)
			};
			SetTileBrush(TileType.wall);
		}

		public static IEnumerable<TileType> PhysicalTiles()
		{
			return from TileType q in Enum.GetValues(typeof(TileType))
				where q.IsPaintableEditorTile()
				select q;
		}

		public Modification UndoableModification(string operation)
		{
			if (currentModification != null)
			{
				Debug.LogWarning("A change was already ongoing: " + currentModification.operation);
			}
			currentModification = new Modification(this, operation);
			return currentModification;
		}

		public void SetTileBrush(TileType t)
		{
			tile = t;
		}

		public void SetPrefabBrush(int p)
		{
			prefabBrush = p;
		}

		public void SetActivePrefabs(List<WorkshopPrefabBank.EdPrefab> prefabs)
		{
			activePrefabs = prefabs;
		}

		public void OnMouseMove()
		{
			tool?.OnMouseMove();
		}

		public void OnMouseDown()
		{
			tool?.OnMouseDown();
		}

		public void OnMouseDrag()
		{
			tool?.OnMouseDrag();
		}

		public void OnMouseUp()
		{
			tool?.OnMouseUp();
		}

		public void OnEnable()
		{
			sprites = Resources.LoadAll<Sprite>("MapWorkshop/MapWorkshopIcons").ToDictionary((Sprite q) => q.name, (Sprite q) => q);
			spritesByTile = new Dictionary<string, Sprite>();
			for (int num = 0; num < TilesetTypeUtility.GetNumberOfAvailableTilesets(); num++)
			{
				foreach (TileType item in Enum.GetValues(typeof(TileType)).Cast<TileType>())
				{
					Sprite value = null;
					string text = item.ToString().ToLower() + " " + num;
					if (!sprites.TryGetValue("editor " + text, out value))
					{
						text = item.ToString().ToLower();
						sprites.TryGetValue("editor " + text, out value);
					}
					if (!spritesByTile.ContainsKey(text))
					{
						spritesByTile.Add(text, value);
					}
				}
			}
		}

		public void OnDisable()
		{
			toolNumber = -1;
			foreach (Sprite value in sprites.Values)
			{
				Resources.UnloadAsset(value);
			}
			sprites = null;
			spritesByTile = null;
		}

		public SpriteRenderer CreateFloatingPiece()
		{
			GameObject gameObject = new GameObject("___floatingpiece___");
			SetAsJunk(gameObject, worldPositionStays: false);
			SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
			spriteRenderer.sortingOrder = 32767;
			spriteRenderer.sortingLayerID = SortingLayerID.Front;
			return spriteRenderer;
		}

		public void SetAsJunk(GameObject go, bool worldPositionStays)
		{
			go.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
			go.tag = "EditorJunk";
			go.transform.SetParent(multiMap.transform, worldPositionStays);
		}
	}
}
