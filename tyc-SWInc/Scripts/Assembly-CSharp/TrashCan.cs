using System;
using UnityEngine;

public class TrashCan : MonoBehaviour, IFurnitureSerialization
{
	public Furniture Furn;

	public int MaxTrash;

	[NonSerialized]
	private int _currentTrash;

	public Transform TrashPile;

	public Transform TrashStart;

	public Transform TrashEnd;

	public int CurrentTrash
	{
		get
		{
			return _currentTrash;
		}
	}

	public bool IsFull()
	{
		return _currentTrash >= MaxTrash;
	}

	public bool NeedsEmpty()
	{
		return (float)_currentTrash > (float)MaxTrash * 0.25f;
	}

	public void AddTrash()
	{
		if (!IsFull())
		{
			_currentTrash++;
			UpdateTrash();
			if (NeedsEmpty())
			{
				GameSettings.Instance.FullTrashCans.Add(this);
			}
		}
	}

	public void Empty()
	{
		_currentTrash = 0;
		UpdateTrash();
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.Instance.FullTrashCans.Remove(this);
		}
	}

	private void OnDestroy()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (Furn != null && Furn.Parent != null && _currentTrash > 0)
		{
			for (int i = 0; i < _currentTrash; i++)
			{
				Furn.Parent.AddDirt(base.transform.position.FlattenVector3() + UnityEngine.Random.insideUnitCircle * 0.5f, 1f, null, 1);
			}
		}
		GameSettings.Instance.FullTrashCans.Remove(this);
	}

	private void Start()
	{
		UpdateTrash();
	}

	private void UpdateTrash()
	{
		if (_currentTrash == 0)
		{
			TrashPile.gameObject.SetActive(false);
			return;
		}
		if (!TrashPile.gameObject.activeSelf)
		{
			TrashPile.gameObject.SetActive(true);
		}
		float t = (float)_currentTrash / (float)MaxTrash;
		TrashPile.position = Vector3.Lerp(TrashStart.position, TrashEnd.position, t);
		TrashPile.localScale = Vector3.Lerp(TrashStart.localScale, TrashEnd.localScale, t);
		TrashPile.rotation = Quaternion.Lerp(TrashStart.rotation, TrashEnd.rotation, t);
	}

	public void Serialize(WriteDictionary dict)
	{
		dict["TrashLevel"] = _currentTrash;
	}

	public void Deserialize(WriteDictionary dict, bool loading)
	{
		_currentTrash = (loading ? dict.Get("TrashLevel", 0) : 0);
		UpdateTrash();
		if (NeedsEmpty())
		{
			GameSettings.Instance.FullTrashCans.Add(this);
		}
	}

	public void PostDeserialize()
	{
	}
}
