using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThomasGridLayoutGroup : MonoBehaviour
{
	private const int DEFAULT_CELL_SIZE = 100;

	private const int DEFAULT_CELL_SPACING = 30;

	private const int TASKBAR_HEIGHT = 30;

	private static bool[,] filled;

	private RectTransform rt;

	public void Awake()
	{
		rt = base.transform.GetComponent<RectTransform>();
		SetIconLocations();
	}

	private static int GetCellSize()
	{
		return 100;
	}

	private static int GetSpacing()
	{
		return 30;
	}

	public bool IsAspectRatioUpdated(Resolution expectedResolution)
	{
		float width = rt.rect.width;
		float height = rt.rect.height;
		float num = width / height;
		float num2 = (float)expectedResolution.width / (float)expectedResolution.height;
		bool flag = (double)Mathf.Abs(num - num2) <= 0.01;
		base.gameObject.GetComponent<TextMeshProUGUI>().text = $" Mathf.Abs({num} - {num2}) <= .01 = {flag}";
		return flag;
	}

	public void SetIconLocations(bool useSavedLocation = true)
	{
		float num = Screen.width;
		float num2 = Screen.height - 30;
		float screenFixedRatio = UIUtils.GetScreenFixedRatio();
		int num3 = (int)(num * screenFixedRatio / (float)(GetCellSize() + GetSpacing()));
		int num4 = (int)(num2 * screenFixedRatio / (float)(GetCellSize() + GetSpacing()));
		filled = new bool[num4, num3];
		Debug.Log($"parentWidth={num}, parentHeight={num2}, cols={num3}, rows={num4}");
		List<Transform> list = new List<Transform>();
		new List<Vector2Int>();
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Transform child = base.transform.GetChild(i);
			Icon componentInChildren = child.GetComponentInChildren<Icon>();
			if (componentInChildren != null && useSavedLocation && Save.IsIconMoved(child.name))
			{
				Vector2Int iconPosition = Save.GetIconPosition(child.name);
				if (iconPosition.x > -1 && iconPosition.y > -1 && !filled[iconPosition.x, iconPosition.y])
				{
					Debug.Log($"Saved icon position -> {iconPosition}");
					componentInChildren.SetPosition(iconPosition, save: false);
				}
			}
			if (componentInChildren == null || !componentInChildren.HasPosition())
			{
				list.Add(child);
				continue;
			}
			int row = componentInChildren.GetRow();
			int column = componentInChildren.GetColumn();
			if (row >= num4 || column >= num3)
			{
				list.Add(child);
				continue;
			}
			child.localPosition = CoordinatesToScreenSpace(new Vector2Int(row, column));
			filled[row, column] = true;
			Debug.Log($"Set {child} to {row}, {column}");
		}
		foreach (Transform item in list)
		{
			AddIcon(item, useSavedLocation: false);
		}
	}

	public static void AddIcon(Transform icon, bool useSavedLocation = true)
	{
		Icon componentInChildren = icon.GetComponentInChildren<Icon>();
		if (useSavedLocation)
		{
			string iconName = componentInChildren.GetIconName();
			if (componentInChildren != null && Save.IsIconMoved(componentInChildren.GetIconName()))
			{
				Vector2Int iconPosition = Save.GetIconPosition(iconName);
				if (SetIconPosition(icon, iconPosition))
				{
					return;
				}
			}
		}
		for (int i = 0; i < filled.GetLength(1); i++)
		{
			for (int j = 0; j < filled.GetLength(0); j++)
			{
				if (!filled[j, i])
				{
					Vector2Int vector2Int = new Vector2Int(j, i);
					SetIconPosition(icon, vector2Int);
					Save.SaveIconPosition(componentInChildren.GetIconName(), vector2Int);
					return;
				}
			}
		}
	}

	private static bool SetIconPosition(Transform icon, Vector2Int position)
	{
		if (position.x >= filled.GetLength(0) || position.x < 0 || position.y < 0 || position.y >= filled.GetLength(1))
		{
			return false;
		}
		if (filled[position.x, position.y])
		{
			return false;
		}
		icon.transform.localPosition = CoordinatesToScreenSpace(position);
		filled[position.x, position.y] = true;
		icon.GetComponentInChildren<Icon>().SetPosition(position);
		return true;
	}

	public static void ShiftIconsUp(Vector2 removedIconLocalPosition, Transform iconContainer)
	{
		Vector2Int vector2Int = ScreenSpaceToCoordinates(removedIconLocalPosition);
		foreach (Transform item in iconContainer)
		{
			Vector2Int vector2Int2 = ScreenSpaceToCoordinates(item.localPosition);
			if (vector2Int2.y == vector2Int.y && vector2Int2.x == vector2Int.x + 1)
			{
				MoveIconPos(item, vector2Int);
				Save.SaveIconPosition(item.GetComponentInChildren<Icon>().GetIconName(), vector2Int);
				vector2Int = vector2Int2;
			}
		}
	}

	public static void MoveIconPos(Transform icon, Vector2Int newPosition)
	{
		RemoveIconPos(icon.localPosition);
		SetIconPosition(icon, newPosition);
	}

	public static void RemoveIconPos(Vector2 iconPos)
	{
		Vector2Int vector2Int = ScreenSpaceToCoordinates(iconPos);
		filled[vector2Int.x, vector2Int.y] = false;
	}

	public static bool CanMoveIcons(Dictionary<Transform, Vector2> icons)
	{
		HashSet<Vector2> hashSet = new HashSet<Vector2>();
		foreach (Transform key in icons.Keys)
		{
			int num = GetCellSize() / 2;
			Vector2Int vector2Int = new Vector2Int(num, -num);
			Vector2Int vector2Int2 = ScreenSpaceToCoordinates((Vector2)key.localPosition + (Vector2)vector2Int);
			MonoBehaviour.print($"filled: {filled.GetLength(0)}, {filled.GetLength(1)}");
			MonoBehaviour.print($"Checking cords: {vector2Int2}");
			if (hashSet.Contains(vector2Int2) || vector2Int2.x < 0 || vector2Int2.x >= filled.GetLength(0) || vector2Int2.y < 0 || vector2Int2.y >= filled.GetLength(1) || isFilledByNonSelectedIcon(vector2Int2))
			{
				return false;
			}
			hashSet.Add(vector2Int2);
		}
		return true;
		bool isFilledByNonSelectedIcon(Vector2Int cords)
		{
			if (!filled[cords.x, cords.y])
			{
				return false;
			}
			foreach (Vector2 value in icons.Values)
			{
				if (ScreenSpaceToCoordinates(value) == cords)
				{
					return false;
				}
			}
			return true;
		}
	}

	public static void ClampIconPositions(Dictionary<Transform, Vector2> icons)
	{
		foreach (Transform key in icons.Keys)
		{
			Vector2Int vector2Int = ScreenSpaceToCoordinates(icons[key]);
			filled[vector2Int.x, vector2Int.y] = false;
		}
		foreach (Transform key2 in icons.Keys)
		{
			int num = GetCellSize() / 2;
			Vector2Int vector2Int2 = new Vector2Int(num, -num);
			Vector2Int vector2Int3 = ScreenSpaceToCoordinates((Vector2)key2.localPosition + (Vector2)vector2Int2);
			MonoBehaviour.print($"Clamp to cords: {vector2Int3}");
			key2.localPosition = CoordinatesToScreenSpace(vector2Int3);
			filled[vector2Int3.x, vector2Int3.y] = true;
			key2.GetComponentInChildren<Icon>().SetPosition(vector2Int3);
		}
	}

	public static Vector2 CoordinatesToScreenSpace(Vector2Int coordinates)
	{
		float x = GetCellSize() * coordinates.y + GetSpacing() * coordinates.y;
		float num = GetCellSize() * coordinates.x + GetSpacing() * coordinates.x;
		return new Vector2(x, 0f - num);
	}

	public static Vector2Int ScreenSpaceToCoordinates(Vector2 localPos)
	{
		int num = (int)(localPos.y / (float)(GetCellSize() + GetSpacing()));
		int y = (int)(localPos.x / (float)(GetCellSize() + GetSpacing()));
		return new Vector2Int(-num, y);
	}
}
