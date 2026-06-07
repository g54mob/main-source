using DG.Tweening;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
	public enum AxesMode
	{
		Both = 0,
		Horizontal = 1,
		Vertical = 2
	}

	public Transform left;

	public Transform right;

	public Transform top;

	public Transform bottom;

	public SpriteRenderer center;

	public int minSize;

	public SpriteRenderer[] renderersT;

	public SpriteRenderer[] renderersI;

	public bool forceHorizontal;

	public bool forceVertical;

	private Sequence tween;

	private BrushGestaltEnum brushEnum;

	private int size;

	private bool showCenter;

	private AxesMode axesMode;

	public void SetAxesMode(AxesMode axesMode)
	{
	}

	public void SetBrush(BrushGestaltEnum brushEnum, int size, bool force = false)
	{
	}

	private Vector2Int MinX(int a, Vector2Int b)
	{
		return default(Vector2Int);
	}

	private Vector2Int MinY(int a, Vector2Int b)
	{
		return default(Vector2Int);
	}

	private Vector2Int MaxX(int a, Vector2Int b)
	{
		return default(Vector2Int);
	}

	private Vector2Int MaxY(int a, Vector2Int b)
	{
		return default(Vector2Int);
	}

	public void ShowCenter(bool showCenter)
	{
	}
}
