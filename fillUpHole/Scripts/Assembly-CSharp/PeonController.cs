using System;
using System.Collections.Generic;
using UnityEngine;

public class PeonController : MonoBehaviour
{
	public CharV2 CharacterPrefab;

	private List<CharV2> Characters = new List<CharV2>();

	private List<CharV2> TempCharacters = new List<CharV2>();

	private float _tempCharactersTime;

	private Vector3 _topLeft = new Vector3(9999f, -9999f, 0f);

	private Vector3 _bottomRight = new Vector3(-9999f, 9999f, 0f);

	private void FixedUpdate()
	{
		if (_tempCharactersTime > 0f)
		{
			_tempCharactersTime -= Time.deltaTime;
			if (_tempCharactersTime <= 0f)
			{
				for (int i = 0; i < TempCharacters.Count; i++)
				{
					TempCharacters[i].ResetForSpawn();
					TempCharacters[i].gameObject.SetActive(value: false);
					UnityEngine.Object.Destroy(TempCharacters[i]);
				}
				TempCharacters.Clear();
			}
		}
		for (int num = Characters.Count - 1; num >= 0; num--)
		{
			if (Characters[num].transform.position.x < _topLeft.x)
			{
				RecallCharacter(Characters[num]);
			}
			if (Characters[num].transform.position.x > _bottomRight.x || Characters[num].transform.position.y < _bottomRight.y)
			{
				RecallCharacter(Characters[num]);
			}
		}
		ProcessIdleCharacters();
	}

	public void DropAllGarbage()
	{
		foreach (CharV2 character in Characters)
		{
			character.DropGarbage();
			character.UnreserveGarbage();
		}
	}

	public void SetAllHappy()
	{
		foreach (CharV2 character in Characters)
		{
			character.SetMaxHapiness(showHearth: true);
		}
	}

	public List<CharV2> GetCharacters()
	{
		return Characters;
	}

	public void VerifyPeonDestination()
	{
		foreach (CharV2 character in Characters)
		{
			character.VerifyDestination();
		}
	}

	public void GenerateMultiplePeon(Vector3 location)
	{
		for (int i = 0; i < Characters.Count; i++)
		{
			SpawnTempCharacterAtLocation(new Vector3(Characters[i].transform.position.x, location.y, location.z));
		}
		_tempCharactersTime = 30f;
	}

	public int GetCharacterCount()
	{
		return Characters.Count;
	}

	public int GetCharacterWalkingCount()
	{
		int num = 0;
		foreach (CharV2 character in Characters)
		{
			if (character.CurrentAction != CharV2.ActionEnum.InsideBuilding)
			{
				num++;
			}
		}
		return num;
	}

	public int GetCharacterWorkerCount()
	{
		int num = 0;
		foreach (CharV2 character in Characters)
		{
			if (character.CurrentAction == CharV2.ActionEnum.InsideBuilding)
			{
				num++;
			}
		}
		return num;
	}

	public int GetFreeWorkercount()
	{
		int num = 0;
		foreach (CharV2 character in Characters)
		{
			if (character.Job == null)
			{
				num++;
			}
		}
		return num;
	}

	public void SetBounds(Vector3 topLeft, Vector3 bottomRight)
	{
		_topLeft = topLeft;
		_bottomRight = bottomRight;
	}

	public CharV2 FindWorkerForJob(BaseBuilding building)
	{
		List<CharV2> list = new List<CharV2>();
		foreach (CharV2 character in Characters)
		{
			if (character.Job == null && character.TempJob == null && character.GarbageInHand.Count == 0)
			{
				list.Add(character);
			}
		}
		if (list.Count == 0)
		{
			foreach (CharV2 character2 in Characters)
			{
				if (character2.Job == null && character2.TempJob == null && !character2.HasShardOrBookInHand())
				{
					list.Add(character2);
				}
			}
		}
		if (list.Count == 0)
		{
			foreach (CharV2 character3 in Characters)
			{
				if (character3.Job == null && character3.TempJob == null && character3.HasShardOrBookInHand())
				{
					list.Add(character3);
				}
			}
		}
		CharV2 charV = null;
		if (list.Count > 0)
		{
			charV = list[0];
			float num = Math.Abs(charV.transform.position.x - building.transform.position.x);
			for (int i = 1; i < list.Count; i++)
			{
				float num2 = Math.Abs(list[i].transform.position.x - building.transform.position.x);
				if (num2 < num)
				{
					charV = list[i];
					num = num2;
				}
			}
			charV.DropGarbage();
			charV.UnreserveGarbage();
		}
		return charV;
	}

	private void ProcessIdleCharacters()
	{
		foreach (CharV2 character in Characters)
		{
			bool flag = false;
			Garbage garbage = null;
			ColumnController columnController = null;
			if (character.gameObject.activeSelf && character.CurrentAction == CharV2.ActionEnum.InsideBuilding)
			{
				Debug.Log("SHOULD NOT HAPPEN");
				character.ResetForSpawn();
			}
			if (character.CurrentAction == CharV2.ActionEnum.Idle && !GameController.Instance.IsHoleFilled())
			{
				if (character.GarbageInHand.Count == 0)
				{
					if (character.IsSuperSad)
					{
						columnController = GameController.Instance.ColumnsController.HoleColumn;
						flag = true;
					}
					else if (character.IsSad)
					{
						foreach (ColumnController column in GameController.Instance.ColumnsController.GetColumns())
						{
							if (column.GetBuildingType() == BaseBuilding.BuildingTypeEnum.House && column.CanEnter(character))
							{
								columnController = column;
								flag = true;
							}
						}
					}
				}
				if (columnController == null && character.Job != null && !character.AreHandsFull())
				{
					foreach (ColumnController column2 in GameController.Instance.ColumnsController.GetColumns())
					{
						if (column2.CanEnter(character) && column2.Buildings == character.Job && !character.IsInBreak(column2))
						{
							columnController = column2;
							flag = true;
						}
					}
				}
				if (columnController == null && character.TempJob != null && !character.AreHandsFull())
				{
					foreach (ColumnController column3 in GameController.Instance.ColumnsController.GetColumns())
					{
						if (column3.CanEnter(character) && column3.Buildings == character.TempJob && !character.IsInBreak(column3))
						{
							columnController = column3;
							flag = true;
						}
					}
				}
				if (columnController == null)
				{
					if (!character.AreHandsFull())
					{
						garbage = GameController.Instance.GarbageController.FindFreeGarbage(character.transform.position, character.GarbageInHand.Count == 0);
					}
					if (character.GarbageInHand.Count == 0)
					{
						columnController = GameController.Instance.ColumnsController.FindCloseColumnToEnter(character);
						flag = true;
					}
					else
					{
						columnController = GameController.Instance.ColumnsController.FindCloseColumnToDump(character);
						flag = false;
					}
				}
			}
			if (garbage != null && columnController != null)
			{
				float num = Mathf.Abs(character.transform.position.x - garbage.transform.position.x);
				float num2 = Mathf.Abs(character.transform.position.x - columnController.transform.position.x);
				num = ((!character.IsHappy) ? (num - 7.5f) : (num - 200f));
				if (num <= num2)
				{
					columnController = null;
				}
				else
				{
					garbage = null;
				}
			}
			if (garbage != null && columnController == null)
			{
				character.MoveToGarbage(garbage);
			}
			else if (garbage == null && columnController != null)
			{
				if (flag)
				{
					character.MoveToBuilding(columnController);
				}
				else
				{
					character.MoveToBuildingToDump(columnController);
				}
			}
		}
		foreach (CharV2 tempCharacter in TempCharacters)
		{
			bool flag2 = false;
			Garbage garbage2 = null;
			ColumnController columnController2 = null;
			if (tempCharacter.CurrentAction == CharV2.ActionEnum.Idle && !GameController.Instance.IsHoleFilled() && columnController2 == null)
			{
				if (!tempCharacter.AreHandsFull())
				{
					garbage2 = GameController.Instance.GarbageController.FindFreeGarbage(tempCharacter.transform.position, tempCharacter.GarbageInHand.Count == 0);
				}
				if (tempCharacter.GarbageInHand.Count != 0)
				{
					columnController2 = GameController.Instance.ColumnsController.FindCloseColumnToDump(tempCharacter);
					flag2 = false;
				}
			}
			if (garbage2 != null && columnController2 != null)
			{
				float num3 = Mathf.Abs(tempCharacter.transform.position.x - garbage2.transform.position.x);
				float num4 = Mathf.Abs(tempCharacter.transform.position.x - columnController2.transform.position.x);
				num3 = ((!tempCharacter.IsHappy) ? (num3 - 7.5f) : (num3 - 200f));
				if (num3 <= num4)
				{
					columnController2 = null;
				}
				else
				{
					garbage2 = null;
				}
			}
			if (garbage2 != null && columnController2 == null)
			{
				tempCharacter.MoveToGarbage(garbage2);
			}
			else if (garbage2 == null && columnController2 != null && !flag2)
			{
				tempCharacter.MoveToBuildingToDump(columnController2);
			}
		}
	}

	public void ReSpawnCharacter(CharV2 c)
	{
		c.ResetForSpawn();
		c.transform.position = GameController.Instance.SpawnLocation.transform.position;
	}

	public void RecallCharacter(CharV2 c)
	{
		ReSpawnCharacter(c);
	}

	public void RecallAllCharacters()
	{
		foreach (CharV2 character in Characters)
		{
			if (character.CurrentAction != CharV2.ActionEnum.InsideBuilding)
			{
				RecallCharacter(character);
			}
		}
	}

	public CharV2 SpawnCharacterAtLocation(Vector3 pos)
	{
		CharV2 charV = UnityEngine.Object.Instantiate(CharacterPrefab, pos, Quaternion.identity, base.transform);
		charV.ResetForSpawn();
		charV.SetMaxHapiness();
		Characters.Add(charV);
		return charV;
	}

	public void SpawnTempCharacterAtLocation(Vector3 pos)
	{
		CharV2 charV = UnityEngine.Object.Instantiate(CharacterPrefab, pos, Quaternion.identity, base.transform);
		charV.ResetForSpawn();
		charV.SetMaxHapiness();
		TempCharacters.Add(charV);
	}

	public void RemoveReserveGarbage(Garbage g)
	{
		if (!g.IsReserved)
		{
			return;
		}
		foreach (CharV2 character in Characters)
		{
			if (character.DestinationObject == g.gameObject)
			{
				g.IsReserved = false;
				character.DestinationObject = null;
				character.CurrentAction = CharV2.ActionEnum.Idle;
				break;
			}
		}
		foreach (CharV2 tempCharacter in TempCharacters)
		{
			if (tempCharacter.DestinationObject == g.gameObject)
			{
				g.IsReserved = false;
				tempCharacter.DestinationObject = null;
				tempCharacter.CurrentAction = CharV2.ActionEnum.Idle;
				break;
			}
		}
	}

	public void DestroyCharacter(CharV2 c)
	{
		c.DropGarbage();
		c.UnreserveGarbage();
		c.gameObject.SetActive(value: false);
		Characters.Remove(c);
		UnityEngine.Object.Destroy(c);
	}
}
