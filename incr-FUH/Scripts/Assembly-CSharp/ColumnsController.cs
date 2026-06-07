using System.Collections.Generic;
using UnityEngine;

public class ColumnsController : MonoBehaviour
{
	public ColumnController ColumnTemplate;

	private List<ColumnController> Columns = new List<ColumnController>();

	public ColumnController HoleColumn;

	public void Init()
	{
		HoleColumn.Distance = 0;
		ColumnTemplate.gameObject.SetActive(value: false);
		Columns.Add(HoleColumn);
	}

	public List<ColumnController> GetColumns()
	{
		return Columns;
	}

	public void UpdateColumnUpdatedByPower()
	{
		for (int i = 0; i < Columns.Count; i++)
		{
			if (Columns[i].Buildings != null)
			{
				Columns[i].Buildings.AffectedByPower.Clear();
			}
		}
		for (int j = 0; j < Columns.Count; j++)
		{
			if (!(Columns[j].Buildings != null) || !(Columns[j].Buildings is Power))
			{
				continue;
			}
			int num = 1;
			if (((Power)Columns[j].Buildings).HasIncreaseRangeAttribute.IsEnabled)
			{
				num++;
			}
			for (int k = 1; k <= num; k++)
			{
				int num2 = j + k;
				if (num2 > 0 && num2 < Columns.Count - 1 && Columns[num2].Buildings != null)
				{
					Columns[num2].Buildings.AffectedByPower.Add((Power)Columns[j].Buildings);
				}
				num2 = j - k;
				if (num2 > 0 && num2 < Columns.Count - 1 && Columns[num2].Buildings != null)
				{
					Columns[num2].Buildings.AffectedByPower.Add((Power)Columns[j].Buildings);
				}
			}
		}
	}

	public void ProcessAllCompressor()
	{
		foreach (ColumnController column in Columns)
		{
			if (column.Buildings is Compressor)
			{
				((Compressor)column.Buildings).ProcessAll();
			}
		}
	}

	public void ProcessAllCatapult()
	{
		foreach (ColumnController column in Columns)
		{
			if (column.Buildings is Catapult)
			{
				((Catapult)column.Buildings).ProcessAll();
			}
		}
	}

	public void LowerAllDurability(float percentage)
	{
		foreach (ColumnController column in Columns)
		{
			column.LowerStability(percentage);
		}
	}

	public float GetLowestColumnX()
	{
		float num = 0f;
		foreach (ColumnController column in Columns)
		{
			if (column.gameObject.transform.position.x < num)
			{
				num = column.gameObject.transform.position.x;
			}
		}
		return num;
	}

	public int GetLevelBuildingSum(BaseBuilding.BuildingTypeEnum buildingType)
	{
		int num = 0;
		foreach (ColumnController column in Columns)
		{
			if (column.Buildings != null && column.Buildings.BuildingType == buildingType)
			{
				num += ((House)column.Buildings).GetLevel();
			}
		}
		return num;
	}

	public int GetBuildingCount(BaseBuilding.BuildingTypeEnum buildingType)
	{
		int num = 0;
		foreach (ColumnController column in Columns)
		{
			if (column.Buildings != null && column.Buildings.BuildingType == buildingType)
			{
				num++;
			}
		}
		return num;
	}

	public ColumnController AddEmptyColumn()
	{
		ColumnController columnController = Object.Instantiate(ColumnTemplate, ColumnTemplate.transform.position - new Vector3(7f, 0f, 0f) * (Columns.Count - 1), Quaternion.identity, ColumnTemplate.transform.parent);
		columnController.gameObject.SetActive(value: true);
		columnController.Distance = Columns.Count;
		Columns.Add(columnController);
		return columnController;
	}

	public void VerifyAndAddNewcolumn(bool addRocks = true)
	{
		bool flag = false;
		if (Columns.Count < 5)
		{
			if (Columns[Columns.Count - 1].Buildings != null)
			{
				flag = true;
			}
		}
		else if (Columns[Columns.Count - 1].Buildings == null)
		{
			flag = true;
		}
		if (Columns.Count >= 13)
		{
			flag = false;
			GameController.Instance.Golem.StartMovement();
		}
		if (!flag)
		{
			return;
		}
		ColumnController columnController = AddEmptyColumn();
		if (addRocks && Columns.Count >= 5)
		{
			int life = 50;
			if (Columns.Count > 5)
			{
				life = 250 * (Columns.Count - 5);
			}
			if (Columns.Count > 6)
			{
				life = 700 * (Columns.Count - 5);
			}
			columnController.CreateFirstBuilding(BaseBuilding.BuildingTypeEnum.Rock);
			((Rock)columnController.Buildings).SetLife(life);
		}
	}

	public ColumnController FindCloseColumnToEnter(CharV2 c)
	{
		ColumnController result = null;
		float num = 99999f;
		foreach (ColumnController column in Columns)
		{
			if (column.CanEnter(c))
			{
				Vector3 enterLocation = column.GetEnterLocation();
				if (Mathf.Abs(enterLocation.x - c.transform.position.x) < num)
				{
					num = Mathf.Abs(enterLocation.x - c.transform.position.x);
					result = column;
				}
			}
		}
		return result;
	}

	public ColumnController FindCloseColumnToDump(CharV2 c)
	{
		ColumnController result = null;
		float num = 99999f;
		foreach (ColumnController column in Columns)
		{
			if (column.CanDumbGarbage(c.GarbageInHand[0]))
			{
				Vector3 enterLocation = column.GetEnterLocation();
				if (Mathf.Abs(enterLocation.x - c.transform.position.x) < num)
				{
					num = Mathf.Abs(enterLocation.x - c.transform.position.x);
					result = column;
				}
			}
		}
		return result;
	}

	public void ToggleBuildingOnTop(bool areBuildingOnTop)
	{
		foreach (ColumnController column in Columns)
		{
			if (column.Buildings != null)
			{
				column.Buildings.ChangeIsOnTop(areBuildingOnTop);
			}
		}
	}

	public bool CanGolemHit(float locX)
	{
		foreach (ColumnController column in Columns)
		{
			if (column.transform.position.x - 1f < locX && column.transform.position.x + 1f > locX && column.Buildings != null && column.Buildings.BuildingType != BaseBuilding.BuildingTypeEnum.Hole && column.Buildings.BuildingType != BaseBuilding.BuildingTypeEnum.Rock && column.Buildings.BuildingType != BaseBuilding.BuildingTypeEnum.Temple)
			{
				return true;
			}
		}
		return false;
	}

	public void DoGolemHit(float locX)
	{
		foreach (ColumnController column in Columns)
		{
			if (column.transform.position.x - 1f < locX && column.transform.position.x + 1f > locX && column.Buildings != null && column.Buildings.BuildingType != BaseBuilding.BuildingTypeEnum.Hole && column.Buildings.BuildingType != BaseBuilding.BuildingTypeEnum.Rock && column.Buildings.BuildingType != BaseBuilding.BuildingTypeEnum.Temple)
			{
				column.Buildings.DoGolemHit();
			}
		}
	}

	public int GetNewUniqueIndex()
	{
		int num = 0;
		foreach (ColumnController column in Columns)
		{
			if (column.Buildings != null && num < column.Buildings.UniqueNumber)
			{
				num = column.Buildings.UniqueNumber;
			}
		}
		return num + 1;
	}

	public bool IsFirst(BaseBuilding b)
	{
		int num = 9999;
		foreach (ColumnController column in Columns)
		{
			if (column.Buildings != null && column.Buildings.BuildingType == b.BuildingType && num > column.Buildings.UniqueNumber)
			{
				num = column.Buildings.UniqueNumber;
			}
		}
		return b.UniqueNumber == num;
	}

	public void RemoveWorkingWorker(CharV2 c)
	{
		foreach (ColumnController column in Columns)
		{
			if (column.Buildings != null)
			{
				column.Buildings.RemoveWorker(c);
			}
		}
	}
}
