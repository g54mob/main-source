using System.Collections.Generic;
using SoulGames.Utilities;
using UnityEngine;

namespace SoulGames.EasyGridBuilderPro
{
	[CreateAssetMenu(menuName = "SoulGames/Easy Grid Builder Pro/BuildableGridObjectTypeSO", order = 0)]
	public class BuildableGridObjectTypeSO : ScriptableObject
	{
		public enum Dir
		{
			Down = 0,
			Left = 1,
			Up = 2,
			Right = 3
		}

		[Space]
		[Tooltip("Name of the buildable object.")]
		[Rename("Unique Object Name")]
		public string objectName;

		[Tooltip("Provide a Buildable Object Type Category SO asset. \n(This is used in UI to categorize the icons.)")]
		public BuildableObjectTypeCategorySO buildableCategorySO;

		[Tooltip("Leave these empty for now. These will be used in future updates.)")]
		[TextArea(4, 5)]
		public string objectDescription;

		[Tooltip("Leave these empty for now. These will be used in future updates.")]
		[TextArea(2, 2)]
		public string objectToolTipDescription;

		[Tooltip("Sprite image of the object's icon. \n(This is used in UI to display the icons.)")]
		public Sprite objectIcon;

		[Space]
		[Tooltip("Buildable object prefab. This is the prefab that will be spawned. \n(If use multiple objects, a random one will be choose to spawn.)")]
		public Transform[] objectPrefab;

		[Tooltip("Buildable object visual. This is used to display a temparary ghost visual before spawn the object. If this is empty, Prefab's first object will be used instead")]
		public Transform ghostPrefab;

		[Tooltip("A custome material to be used in temparary ghost object, when object is placeable. \n(If nested children objects exist, check upto 4 nested levels). If this is empty, 'Visual' objects defualt materials will be used.")]
		public Material placeableGhostMaterial;

		[Tooltip("A custome material to be used in temparary ghost object, when object is not placeable. \n(If nested children objects exist, check upto 4 nested levels). If this is empty, 'placeableVisualMaterial' materials will be used.")]
		public Material notPlaceableGhostMaterial;

		[Tooltip("If enabled you can set the layer of the spawnning object.)")]
		public bool setBuiltObjectLayer;

		[Tooltip("This layer will be set to the spawnned buildable objetct.")]
		public LayerMask builtObjectLayer;

		[Space]
		[Tooltip("If this is enabled, provided canvas grid will displayed under the object.")]
		public bool showGridBelowObject;

		[Tooltip("Drag and drop the provided Canvas Grid prefab.")]
		public Canvas objectGridCanvas;

		[Tooltip("Drag and drop a provided sprite to use as the grid visual.)")]
		public Sprite gridImageSprite;

		[Tooltip("Canvas grid image will take this color when it is placeable.)")]
		public Color gridImagePlaceableColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		[Tooltip("Canvas grid image will take this color when it is not placeable.)")]
		public Color gridImageNotPlaceableColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		[Space]
		[Tooltip("Enable hold and place objects on grid. \n(Can be used to hold click and paint objects on grid instead of click each time to spawn objects.) \n(Doesn't work with 'placeAndDeselect'. Only use one at a time.)")]
		[Rename("Hold Key To Place")]
		public bool holdToPlace;

		[Tooltip("Enable deselect object automatically after placing it. \n(Doesn't work with 'holdToPlace'. Only use one at a time.)")]
		[Rename("Place & Auto Deselect")]
		public bool placeAndDeselect;

		[Space]
		[Tooltip("Enable using build conditions for the object type. \n(Can add build conditions via script. Check documentation.)")]
		public bool enableBuildCondition;

		[Tooltip("If 'Build Condition' is enabled, provide a Build Conditon SO asset. \n('Build Condition' must be enabled to use this.)")]
		public BuildConditionSO buildConditionSO;

		public static Dir GetNextDirRight(Dir dir)
		{
			return dir switch
			{
				Dir.Left => Dir.Up, 
				Dir.Up => Dir.Right, 
				Dir.Right => Dir.Down, 
				_ => Dir.Left, 
			};
		}

		public static Dir GetNextDirLeft(Dir dir)
		{
			return dir switch
			{
				Dir.Left => Dir.Down, 
				Dir.Up => Dir.Left, 
				Dir.Right => Dir.Up, 
				_ => Dir.Right, 
			};
		}

		public static Vector2Int GetDirForwardVector(Dir dir)
		{
			return dir switch
			{
				Dir.Left => new Vector2Int(-1, 0), 
				Dir.Up => new Vector2Int(0, 1), 
				Dir.Right => new Vector2Int(1, 0), 
				_ => new Vector2Int(0, -1), 
			};
		}

		public static Dir GetDir(Vector2Int from, Vector2Int to)
		{
			if (from.x < to.x)
			{
				return Dir.Right;
			}
			if (from.x > to.x)
			{
				return Dir.Left;
			}
			if (from.y < to.y)
			{
				return Dir.Up;
			}
			return Dir.Down;
		}

		public int GetRotationAngle(Dir dir)
		{
			return dir switch
			{
				Dir.Left => 90, 
				Dir.Up => 180, 
				Dir.Right => 270, 
				_ => 0, 
			};
		}

		public Vector2Int GetRotationOffset(Dir dir, float cellSize)
		{
			Vector2Int vector2Int = CalculatePlacedObjectSize(cellSize);
			return dir switch
			{
				Dir.Left => new Vector2Int(0, vector2Int.x), 
				Dir.Up => new Vector2Int(vector2Int.x, vector2Int.y), 
				Dir.Right => new Vector2Int(vector2Int.y, 0), 
				_ => new Vector2Int(0, 0), 
			};
		}

		public Vector2Int CalculatePlacedObjectSize(float cellSize)
		{
			int num = 0;
			float x = objectPrefab[0].GetComponent<BuildableGridObject>().GetObjectScale().x;
			float y = objectPrefab[0].GetComponent<BuildableGridObject>().GetObjectScale().y;
			int x2 = (int)Mathf.Ceil(x / cellSize);
			num = (int)Mathf.Ceil(y / cellSize);
			return new Vector2Int(x2, num);
		}

		public List<Vector2Int> GetGridPositionList(Vector2Int offset, Dir dir, float cellSize)
		{
			Vector2Int vector2Int = CalculatePlacedObjectSize(cellSize);
			List<Vector2Int> list = new List<Vector2Int>();
			switch (dir)
			{
			default:
			{
				for (int k = 0; k < vector2Int.x; k++)
				{
					for (int l = 0; l < vector2Int.y; l++)
					{
						list.Add(offset + new Vector2Int(k, l));
					}
				}
				break;
			}
			case Dir.Left:
			case Dir.Right:
			{
				for (int i = 0; i < vector2Int.y; i++)
				{
					for (int j = 0; j < vector2Int.x; j++)
					{
						list.Add(offset + new Vector2Int(i, j));
					}
				}
				break;
			}
			}
			return list;
		}
	}
}
