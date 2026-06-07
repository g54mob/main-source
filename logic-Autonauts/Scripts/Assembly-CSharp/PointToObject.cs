using UnityEngine;

public class PointToObject : Indicator
{
	private BaseClass m_Target;

	private TileCoord m_TargetTile;

	public void Restart()
	{
		base.gameObject.SetActive(false);
	}

	protected new void Awake()
	{
		base.Awake();
		m_Offset = 40f;
	}

	public void SetTarget(BaseClass NewObject)
	{
		m_Target = NewObject;
		if ((bool)m_Target)
		{
			base.gameObject.SetActive(true);
		}
		else
		{
			base.gameObject.SetActive(false);
		}
		UpdatePosition();
	}

	public void SetTargetTile(TileCoord NewCoord)
	{
		m_Target = null;
		m_TargetTile = NewCoord;
		if (m_TargetTile.x != -1)
		{
			base.gameObject.SetActive(true);
		}
		else
		{
			base.gameObject.SetActive(false);
		}
		UpdatePosition();
	}

	private void UpdatePosition()
	{
		if ((bool)m_Target)
		{
			Vector3 worldPosition;
			if ((bool)m_Target.GetComponent<Building>())
			{
				TileCoord TopLeft;
				TileCoord BottomRight;
				m_Target.GetComponent<Building>().GetBoundingRectangle(out TopLeft, out BottomRight);
				worldPosition = (BottomRight.ToWorldPositionTileCentered() + TopLeft.ToWorldPositionTileCentered()) / 2f;
				worldPosition.y += m_Target.GetComponent<Building>().m_LevelHeight;
			}
			else
			{
				Bounds bounds = ObjectUtils.ObjectBounds(m_Target.gameObject);
				worldPosition = new Vector3(bounds.center.x, bounds.center.y + bounds.extents.y, bounds.center.z);
			}
			UpdateTransform(worldPosition);
		}
		else if (m_TargetTile.x != -1)
		{
			UpdateTransform(m_TargetTile.ToWorldPositionTileCentered());
		}
	}

	private void Update()
	{
		UpdatePosition();
	}
}
