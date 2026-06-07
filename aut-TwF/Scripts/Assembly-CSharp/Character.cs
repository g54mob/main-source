using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, ISavable
{
	[SerializeField]
	private GameObject defaultController;

	[Savable("controller", false, false)]
	private Controller controller;

	[HideInInspector]
	public MovementComponent movementComponent;

	[HideInInspector]
	public Animator animator;

	private Dictionary<string, object> controllerSavedData;

	public GameObject DefaultController
	{
		get
		{
			return defaultController;
		}
		set
		{
			defaultController = value;
			SpawnDefaultController();
		}
	}

	public Controller Controller => controller;

	protected virtual void Awake()
	{
		movementComponent = GetComponent<MovementComponent>();
		animator = GetComponent<Animator>();
		SpawnDefaultController();
	}

	protected virtual void Start()
	{
	}

	private void SpawnDefaultController()
	{
		if ((bool)controller)
		{
			Object.Destroy(controller.gameObject);
		}
		if ((bool)defaultController)
		{
			controller = Object.Instantiate(defaultController, Vector3.zero, Quaternion.identity, base.transform).GetComponent<Controller>();
			controller.transform.localPosition = Vector3.zero;
			controller.transform.localRotation = Quaternion.identity;
			controller.Possess(this);
			if (controllerSavedData != null)
			{
				SaveSystem.LoadObjectData(controller, controllerSavedData);
				controllerSavedData = null;
			}
		}
	}

	public virtual void OnPosses(Controller controller)
	{
	}

	public virtual void Move(Vector3 direction, bool normalizeDirection = true)
	{
		movementComponent?.Move(direction, Time.deltaTime, normalizeDirection);
	}

	public virtual void MoveToPosition(Vector3 position, bool synchronous = false)
	{
		movementComponent?.MoveToPosition(position, synchronous);
	}

	public virtual void OnSave()
	{
	}

	public virtual void OnPreLoad()
	{
	}

	public virtual void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (hasLoadedSomething && data.ContainsKey("controller"))
		{
			if (controller != null)
			{
				SaveSystem.LoadObjectData(controller, data["controller"] as Dictionary<string, object>);
			}
			else
			{
				controllerSavedData = data["controller"] as Dictionary<string, object>;
			}
		}
	}
}
