using UnityEngine;

public class TiledBox : MonoBehaviour
{
	private static Vector3Int[] _sizes;

	private int _boxes = 1;

	public Renderer Rend;

	public int Boxes
	{
		get
		{
			return _boxes;
		}
	}

	private static void InitializeSizes()
	{
		if (_sizes != null)
		{
			return;
		}
		_sizes = new Vector3Int[108];
		Vector3Int vector3Int = Vector3Int.one;
		for (int i = 0; i < _sizes.Length; i++)
		{
			int k = i + 1;
			Vector3Int? vector3Int2 = GetSize(k, true) ?? GetSize(k, false);
			if (vector3Int2.HasValue)
			{
				vector3Int = (_sizes[i] = vector3Int2.Value);
			}
			else
			{
				_sizes[i] = vector3Int;
			}
		}
	}

	public void SetBoxes(int boxes, bool highlight)
	{
		_boxes = boxes;
		SizeBox(highlight);
	}

	public static Vector3Int GetBoxSize(int boxes)
	{
		InitializeSizes();
		return _sizes[Mathf.Clamp(boxes - 1, 0, _sizes.Length - 1)];
	}

	private static Vector3Int? GetSize(int k, bool low)
	{
		int num = k;
		int lowest = GetLowest(k, 6, low);
		if (lowest > 6 || k % lowest != 0)
		{
			return null;
		}
		k /= lowest;
		int lowest2 = GetLowest(k, 6, low);
		if (lowest2 > 6 || k % lowest2 != 0)
		{
			return null;
		}
		k /= lowest2;
		int lowest3 = GetLowest(k, 3, low);
		if (k % lowest3 != 0 || lowest3 > 3 || lowest * lowest3 * lowest2 != num)
		{
			return null;
		}
		return new Vector3Int(lowest, lowest3, lowest2);
	}

	private static int GetLowest(int value, int max, bool low)
	{
		if (low)
		{
			for (int i = 2; i <= max; i++)
			{
				if (i <= value && (i == value || value % i == 0))
				{
					return i;
				}
			}
		}
		else
		{
			for (int num = max; num > 0; num--)
			{
				if (num <= value && (num == value || value % num == 0))
				{
					return num;
				}
			}
		}
		return value;
	}

	public void SizeBox(bool highlight)
	{
		Vector3Int boxSize = GetBoxSize(Boxes);
		base.transform.localScale = boxSize;
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		materialPropertyBlock.SetVector("_Tile", new Vector4(boxSize.x, boxSize.y, boxSize.z, highlight ? 1 : 0));
		Rend.SetPropertyBlock(materialPropertyBlock);
	}
}
