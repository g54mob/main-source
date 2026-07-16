using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interactor : MonoBehaviour
{
	public PlayerController playerController;

	private InteractorStates interactorState;

	private const float INTERACT_RANGE = 0.1f;

	private Interactable[] interactables;

	public RepairMinigame repairMinigame;

	public Interactable ActiveInteractable { get; set; }

	public Interactable InterruptingInteractable { get; set; }

	public Interactable[] whitelist { get; set; }

	public InteractorStates InteractorState
	{
		get
		{
			return interactorState;
		}
		set
		{
			interactorState = value;
			if (interactorState == InteractorStates.Disabled)
			{
				ActiveInteractable?.Deselect(this);
				ActiveInteractable = null;
			}
		}
	}

	private void Awake()
	{
		InteractorState = InteractorStates.Standard;
	}

	private void Start()
	{
		RefreshInteractablesArray();
	}

	private void Update()
	{
		if (Time.deltaTime > 0f)
		{
			FindNearestInteractable();
		}
	}

	private void OnDestroy()
	{
		ClearActiveInteractable();
		ClearInterruptingInteractable();
	}

	public void ClearInteractables()
	{
		interactables = new Interactable[0];
	}

	public void SetWhitelist(Interactable[] interactables)
	{
		whitelist = interactables.ToArray();
	}

	public void RefreshInteractablesArray()
	{
		GameObject[] array = (from i in GameObject.FindGameObjectsWithTag("Interactable")
			where i != null
			select i).ToArray();
		interactables = new Interactable[array.Length];
		for (int num = 0; num < array.Length; num++)
		{
			interactables[num] = array[num].GetComponent<Interactable>();
		}
	}

	public void WhitelistAllInteractables()
	{
		whitelist = interactables.ToArray();
	}

	public void AddInteractableToArray(Interactable interactable)
	{
		interactables = interactables.Concat(new Interactable[1] { interactable }).ToArray();
	}

	public void ForceInteract(Interactable interactable)
	{
		ActiveInteractable = interactable;
	}

	private void SetActiveInteractable(Interactable interactable)
	{
		if (!(interactable == null))
		{
			ActiveInteractable = interactable;
			ActiveInteractable.Interactor = this;
		}
	}

	private void ClearActiveInteractable()
	{
		if ((bool)ActiveInteractable)
		{
			ActiveInteractable.Interactor = null;
			ActiveInteractable = null;
		}
	}

	private void SetInterruptingInteractable(Interactable interactable)
	{
		if (!(interactable == null))
		{
			InterruptingInteractable = interactable;
		}
	}

	private void ClearInterruptingInteractable()
	{
		if ((bool)InterruptingInteractable)
		{
			InterruptingInteractable.Interactor = null;
			InterruptingInteractable = null;
		}
	}

	private void FindNearestInteractable()
	{
		if (interactorState == InteractorStates.Disabled)
		{
			return;
		}
		if (ActiveInteractable != null)
		{
			ActiveInteractable.Deselect(this);
			ActiveInteractable = null;
		}
		if (interactables.Length == 0)
		{
			return;
		}
		float num = 0.1f;
		Interactable interactable = null;
		List<Interactable> list = new List<Interactable>();
		if (whitelist != null && whitelist.Length != 0)
		{
			Interactable[] array = interactables;
			foreach (Interactable interactable2 in array)
			{
				if (whitelist.Contains(interactable2))
				{
					list.Add(interactable2);
				}
			}
		}
		else
		{
			list = new List<Interactable>(interactables);
		}
		list = list.Where((Interactable interactable3) => interactable3 != null && interactable3.gameObject.activeInHierarchy).ToList();
		foreach (Interactable item in list)
		{
			Vector2 b = item.GetComponent<BoxCollider2D>().ClosestPoint(base.transform.position);
			float num2 = Vector2.Distance(base.transform.position, b);
			if (num2 < num)
			{
				num = num2;
				interactable = item;
			}
		}
		if (!interactable)
		{
			playerController.hotkeyTooltip.CloseAll();
			ClearActiveInteractable();
			ClearInterruptingInteractable();
			return;
		}
		if (PlayerManager.Instance.GetAllPlayersActiveInteractables().Contains(interactable))
		{
			if (interactable.IsInterruptable)
			{
				SetInterruptingInteractable(interactable);
				if (interactable.Interactor == null)
				{
					SetActiveInteractable(interactable);
				}
			}
			else
			{
				ClearInterruptingInteractable();
			}
		}
		else
		{
			SetActiveInteractable(interactable);
			ClearInterruptingInteractable();
		}
		if (!ActiveInteractable || !ActiveInteractable.CanInteract())
		{
			return;
		}
		if (interactorState == InteractorStates.Station)
		{
			if ((bool)ActiveInteractable.GetComponent<ModuleFurnace>())
			{
				ActiveInteractable.Select(this);
			}
			else
			{
				ActiveInteractable = null;
			}
		}
		else
		{
			ActiveInteractable.Select(this);
		}
	}
}
