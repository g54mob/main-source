using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using __Project__.Scripts.UI;

public class CategorySignIconController : MonoBehaviour
{
	[SerializeField]
	private CategoryNameOverlay m_CategoryNameOverlay;

	[SerializeField]
	private Vector3 m_IconMargin;

	[SerializeField]
	private RectTransform m_IconHolderTransform;

	[SerializeField]
	private float m_TweenTime;

	[SerializeField]
	private Ease easetype;

	public List<Sprite> iconList;

	public GameObject iconPrefab;

	public int currentIcon;

	private Vector3 targetPos;

	private void Awake()
	{
	}

	private void GenerateIconObjects()
	{
	}

	public void Next()
	{
	}

	public void Previous()
	{
	}

	public void MoveIcon()
	{
	}

	public void SetIconPosition()
	{
	}

	public Vector2Int CalculatePosition(int index)
	{
		return default(Vector2Int);
	}

	public void SetCurrentIcon(Vector2Int atlasPosition)
	{
	}
}
