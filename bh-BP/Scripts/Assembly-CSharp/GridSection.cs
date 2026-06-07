using UnityEngine;
using UnityEngine.UI;

public class GridSection : MonoBehaviour
{
	public CoolButton[][] NavGrid;

	public GridLayoutGroup TgtGridLayoutGroup;

	public RectTransform Xfm;

	public int NumCols;

	public void Init()
	{
	}

	public void InitNavGrid()
	{
	}

	public void ReCalculateNumCols()
	{
	}

	public CoolButton GetBtnAt(int x, int y)
	{
		return null;
	}

	public int GetNumCols()
	{
		return 0;
	}

	public int GetNumRows()
	{
		return 0;
	}

	public CoolButton GetTopBtn(int x)
	{
		return null;
	}

	public CoolButton GetBotBtn(int x)
	{
		return null;
	}

	public void StitchNav(GridSection prevSection)
	{
	}
}
