using System;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintController : MonoBehaviour
{
	public static FootPrintController Instance;

	public GameObject FootPrintPrefab;

	public Material MainFeet;

	public Material ExtraFeet;

	public Material MainFeetProblem;

	public Material ExtraFeetProblem;

	[NonSerialized]
	private List<GameObject> _feetPool = new List<GameObject>();

	[NonSerialized]
	private List<bool> _ignoreCheck = new List<bool>();

	[NonSerialized]
	private int _counter;

	[NonSerialized]
	private int _updateCounter;

	private bool _validOutside;

	[NonSerialized]
	private GameObject _follow;

	public static void Initialize(FurnitureBuilder builder)
	{
		if (Instance != null)
		{
			Instance.Init(builder);
		}
	}

	private void Init(FurnitureBuilder builder)
	{
		base.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
		_feetPool.ForEach(delegate(GameObject x)
		{
			x.gameObject.SetActive(false);
		});
		_counter = 0;
		_updateCounter = 0;
		AddFootPrints(builder.FurnPrefab.GetComponent<Furniture>(), Quaternion.identity, Vector3.zero);
		for (int num = 0; num < builder.Children.Count; num++)
		{
			FurnitureBuilder furnitureBuilder = builder.Children[num];
			AddFootPrints(furnitureBuilder.FurnPrefab.GetComponent<Furniture>(), furnitureBuilder.transform.localRotation, furnitureBuilder.transform.localPosition);
		}
		_follow = builder.gameObject;
		base.gameObject.SetActive(true);
	}

	private void AddFootPrints(Furniture furn, Quaternion rot, Vector3 pos)
	{
		_validOutside = furn.ValidOutside;
		for (int i = 0; i < furn.InteractionPoints.Length; i++)
		{
			InteractionPoint interactionPoint = furn.InteractionPoints[i];
			if (interactionPoint.ShowOnBuild)
			{
				GameObject foot = GetFoot();
				_ignoreCheck[_counter - 1] = interactionPoint.AlwaysValid;
				foot.GetComponentInChildren<MeshRenderer>().sharedMaterial = (interactionPoint.MainAction ? MainFeet : ExtraFeet);
				foot.transform.SetPositionAndRotation((rot * interactionPoint.transform.localPosition + pos).ReplaceY(0f), rot * interactionPoint.transform.localRotation);
			}
		}
		for (int j = 0; j < furn.SnapPoints.Length; j++)
		{
			SnapPoint snapPoint = furn.SnapPoints[j];
			if (snapPoint.UsedByCount <= 0)
			{
				continue;
			}
			foreach (Furniture item in snapPoint.GetAllUsedBy())
			{
				AddFootPrints(item, rot * Quaternion.Inverse(furn.transform.rotation) * item.transform.rotation, pos + rot * snapPoint.transform.localPosition);
			}
		}
	}

	private GameObject GetFoot()
	{
		GameObject gameObject;
		if (_counter >= _feetPool.Count)
		{
			gameObject = UnityEngine.Object.Instantiate(FootPrintPrefab);
			gameObject.transform.SetParent(base.transform);
			_feetPool.Add(gameObject);
			_ignoreCheck.Add(false);
		}
		else
		{
			gameObject = _feetPool[_counter];
		}
		gameObject.gameObject.SetActive(true);
		_counter++;
		return gameObject;
	}

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		base.gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (_follow != null)
		{
			Vector2 vector = _follow.transform.position.FlattenVector3();
			FurnitureBuilder component = _follow.GetComponent<FurnitureBuilder>();
			Room room = null;
			if (component != null)
			{
				room = component.LastRoom;
			}
			if (room == null)
			{
				room = GameSettings.Instance.sRoomManager.GetRoomFromPoint(GameSettings.Instance.ActiveFloor, vector);
			}
			if ((((object)room != null) ? room.AtriumParent : null) != null)
			{
				room = room.FindFloorAtrium(vector);
			}
			if (_counter > 0)
			{
				MeshRenderer componentInChildren = _feetPool[_updateCounter].GetComponentInChildren<MeshRenderer>();
				bool flag = _ignoreCheck[_updateCounter];
				if (!flag)
				{
					Vector2 vector2 = componentInChildren.transform.position.FlattenVector3();
					Room room2 = GameSettings.Instance.sRoomManager.GetRoomFromPoint(GameSettings.Instance.ActiveFloor, vector2);
					if (room2 != null && (!room2.Outside || _validOutside))
					{
						if (room2.AtriumParent != null)
						{
							room2 = room2.FindFloorAtrium(vector2);
						}
						if (room2 == room && !room2.GetNavMeshRunning() && room2.GetNodeAt(vector2, false) != null)
						{
							flag = true;
						}
					}
				}
				if (flag)
				{
					if (componentInChildren.sharedMaterial == ExtraFeetProblem)
					{
						componentInChildren.sharedMaterial = ExtraFeet;
					}
					else if (componentInChildren.sharedMaterial == MainFeetProblem)
					{
						componentInChildren.sharedMaterial = MainFeet;
					}
				}
				else if (componentInChildren.sharedMaterial == ExtraFeet)
				{
					componentInChildren.sharedMaterial = ExtraFeetProblem;
				}
				else if (componentInChildren.sharedMaterial == MainFeet)
				{
					componentInChildren.sharedMaterial = MainFeetProblem;
				}
				_updateCounter = (_updateCounter + 1) % _counter;
			}
			base.transform.SetPositionAndRotation(_follow.transform.position.ReplaceY((room == null) ? ((float)GameSettings.Instance.ActiveFloor) : ((float)room.Floor * 2f)), Quaternion.Euler(0f, _follow.transform.rotation.eulerAngles.y, 0f));
		}
		else
		{
			base.gameObject.SetActive(false);
		}
	}
}
