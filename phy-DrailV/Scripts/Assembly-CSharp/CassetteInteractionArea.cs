using System;
using System.Collections;
using DV;
using DV.CabControls;
using DV.Interaction;
using DV.InventorySystem;
using DV.Items;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class CassetteInteractionArea : MonoBehaviour
{
	public GameObject fakeCassette;

	public GameObject door;

	public AudioClip insertCassetteSound;

	public AudioClip removeCassetteSound;

	public AudioClip doorOpenSound;

	public AudioClip doorCloseSound;

	[SerializeField]
	private ItemRendererDynamic[] fakeCassetteDynamicRenderers;

	[SerializeField]
	private ItemMagazine magazine;

	private bool isVR;

	private GameObject usingObject;

	private ControlImplBase doorControl;

	private ControlImplBase areaControl;

	private VRTK_InteractableObject_DV vrtkInteractable;

	private Coroutine initCoro;

	private bool doorOpen;

	private Cassette insertedCassette;

	private LabelableItem fakeLabel;

	private Coroutine storageRemoveCoro;

	private ItemTriggerEnterTarget triggerEnterTarget;

	private bool ignoreMagazineDataChanged;

	private Cassette InsertedCassette
	{
		get
		{
			return insertedCassette;
		}
		set
		{
			if (insertedCassette == value)
			{
				return;
			}
			insertedCassette = value;
			bool flag = insertedCassette != null;
			if (flag)
			{
				(Mesh[] sharedMeshes, Material[][] sharedMaterials) tuple = insertedCassette.RequestSharedMeshesAndMaterials();
				Mesh[] item = tuple.sharedMeshes;
				Material[][] item2 = tuple.sharedMaterials;
				for (int i = 0; i < fakeCassetteDynamicRenderers.Length; i++)
				{
					ItemRendererDynamic itemRendererDynamic = fakeCassetteDynamicRenderers[i];
					if (!(itemRendererDynamic == null))
					{
						itemRendererDynamic.UpdateDynamicMesh(item[i]);
						itemRendererDynamic.UpdateDynamicMaterialsCache(item2[i]);
					}
				}
			}
			else
			{
				this.CassetteRemoved?.Invoke();
			}
			fakeCassette.SetActive(flag);
		}
	}

	public event Action DoorOpened;

	public event Action DoorClosed;

	public event Action CassetteRemoved;

	private void Awake()
	{
		isVR = VRManager.IsVREnabled();
		fakeLabel = fakeCassette.GetComponent<LabelableItem>();
		if (insertCassetteSound == null)
		{
			Debug.LogError("Missing insertCassetteSound reference!");
		}
		if (removeCassetteSound == null)
		{
			Debug.LogError("Missing removeCassetteSound reference!");
		}
		if (doorOpenSound == null)
		{
			Debug.LogError("Missing doorOpenSound reference!");
		}
		if (doorCloseSound == null)
		{
			Debug.LogError("Missing doorCloseSound reference!");
		}
		if (fakeLabel == null)
		{
			Debug.LogError("Missing fakeLabel reference!");
		}
		magazine.ItemContainerDataChanged += OnMagazineDataChanged;
		initCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(Init());
	}

	private void OnMagazineDataChanged(AItemContainer container, int sourceIndex, int destinationIndex)
	{
		if (ignoreMagazineDataChanged || sourceIndex != 0 || destinationIndex != -1)
		{
			return;
		}
		GameObject gameObject = container[sourceIndex];
		Cassette cassette = ((gameObject != null) ? gameObject.GetComponent<Cassette>() : null);
		if (cassette == null)
		{
			InsertedCassette = null;
			areaControl.InteractionAllowed = false;
			fakeLabel.UpdateText(string.Empty);
			if (removeCassetteSound != null)
			{
				if (base.gameObject.activeInHierarchy)
				{
					removeCassetteSound.Play(base.transform.position, 1f, 1f, 0f, 0.2f, 10f, default(AudioSourceCurves), null, base.transform.parent);
				}
				else
				{
					removeCassetteSound.Play2D();
				}
			}
			if (triggerEnterTarget != null)
			{
				triggerEnterTarget.gameObject.SetActive(value: true);
			}
			return;
		}
		InsertedCassette = cassette;
		areaControl.InteractionAllowed = doorOpen;
		base.gameObject.SetActive(value: true);
		LabelableItem component = cassette.GetComponent<LabelableItem>();
		fakeLabel.UpdateText(component ? component.Text : string.Empty);
		if (insertCassetteSound != null)
		{
			if (base.gameObject.activeInHierarchy)
			{
				insertCassetteSound.Play(base.transform.position, 1f, 1f, 0f, 0.2f, 10f, default(AudioSourceCurves), null, base.transform.parent);
			}
			else
			{
				insertCassetteSound.Play2D();
			}
		}
	}

	public void OpenDoor()
	{
		if (!doorOpen)
		{
			doorOpen = true;
			doorControl.SetValue(1f);
			doorControl.InteractionAllowed = true;
			base.gameObject.SetActive(value: true);
			areaControl.InteractionAllowed = InsertedCassette != null;
			if (doorOpenSound != null)
			{
				doorOpenSound.Play(base.transform.position, 1f, 1f, 0f, 0.2f, 10f, default(AudioSourceCurves), null, base.transform.parent);
			}
			if (triggerEnterTarget != null && InsertedCassette == null)
			{
				triggerEnterTarget.gameObject.SetActive(value: true);
			}
			this.DoorOpened?.Invoke();
		}
	}

	public void CloseDoor()
	{
		if (doorOpen)
		{
			doorOpen = false;
			doorControl.InteractionAllowed = false;
			areaControl.InteractionAllowed = false;
			if (triggerEnterTarget != null)
			{
				triggerEnterTarget.gameObject.SetActive(value: false);
			}
			if (InsertedCassette == null)
			{
				base.gameObject.SetActive(value: false);
			}
			if (doorCloseSound != null)
			{
				doorCloseSound.Play(base.transform.position, 1f, 1f, 0f, 0.2f, 10f, default(AudioSourceCurves), null, base.transform.parent);
			}
			this.DoorClosed?.Invoke();
		}
	}

	public void RequestInsertCassette(Cassette cassette, bool removeFromStorage = true)
	{
		magazine.AddItem(cassette.gameObject, 0);
		if (triggerEnterTarget != null)
		{
			triggerEnterTarget.gameObject.SetActive(value: false);
		}
	}

	public Cassette GetInsertedCassette()
	{
		return InsertedCassette;
	}

	public bool IsCassetteInserted()
	{
		return InsertedCassette != null;
	}

	public bool IsDoorOpen()
	{
		return doorOpen;
	}

	private IEnumerator Init()
	{
		yield return null;
		areaControl = GetComponent<ControlImplBase>();
		doorControl = door.GetComponent<ControlImplBase>();
		doorControl.Used += CloseDoor;
		if (areaControl == null)
		{
			Debug.LogError("'CassetteInteractionArea' doesn't have interactable object. This should not happen.", this);
		}
		else if (isVR)
		{
			vrtkInteractable = GetComponent<VRTK_InteractableObject_DV>();
			triggerEnterTarget = GetComponentInChildren<ItemTriggerEnterTarget>();
			if (vrtkInteractable == null)
			{
				Debug.LogError("'CassetteInteractionArea' doesn't have interactable object. This should not happen.", this);
			}
			else
			{
				vrtkInteractable.InteractableObjectUsed += RequestCassetteRemove;
			}
		}
		else
		{
			areaControl.Used += RequestCassetteRemove;
		}
		initCoro = null;
		areaControl.InteractionAllowed = false;
		doorControl.InteractionAllowed = false;
		if (triggerEnterTarget != null && InsertedCassette == null)
		{
			triggerEnterTarget.gameObject.SetActive(value: true);
		}
		base.gameObject.SetActive(value: false);
	}

	private void OnDestroy()
	{
		if (UnloadWatcher.isQuitting)
		{
			return;
		}
		if (vrtkInteractable != null)
		{
			if (initCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(initCoro);
			}
			vrtkInteractable.InteractableObjectUsed -= RequestCassetteRemove;
		}
		if (storageRemoveCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(storageRemoveCoro);
		}
		if (magazine != null)
		{
			magazine.ItemContainerDataChanged -= OnMagazineDataChanged;
		}
	}

	private void RequestCassetteRemove()
	{
		RequestCassetteRemove(null, default(InteractableObjectEventArgs));
	}

	private void RequestCassetteRemove(object _, InteractableObjectEventArgs e)
	{
		if (InsertedCassette == null)
		{
			Debug.LogWarning("CassetteInteractionArea doesn't have a cassette inserted", this);
			return;
		}
		if (!doorOpen)
		{
			Debug.LogWarning("CassetteInteractionArea door is closed, ignoring.", this);
			return;
		}
		int num = -1;
		if (isVR)
		{
			int num2 = (num = (VRTK_DeviceFinder.IsControllerRightHand(e.interactingObject.gameObject) ? 1 : 0));
			if (SingletonBehaviour<Inventory>.Instance.GetEquippedItemAtSlot(num2) == null)
			{
				num = num2;
			}
		}
		else if (SingletonBehaviour<Inventory>.Instance.GetEquippedItemAtSlot(0) == null)
		{
			num = 0;
		}
		if (num >= 0)
		{
			ignoreMagazineDataChanged = true;
			magazine.RemoveItem(0, activateItem: true, dropItem: true);
			ignoreMagazineDataChanged = false;
			areaControl.InteractionAllowed = false;
			SingletonBehaviour<Inventory>.Instance.EquipItem(InsertedCassette.gameObject, num);
			if (removeCassetteSound != null)
			{
				removeCassetteSound.Play(base.transform.position, 1f, 1f, 0f, 0.2f, 10f, default(AudioSourceCurves), null, base.transform.parent);
			}
			if (triggerEnterTarget != null)
			{
				triggerEnterTarget.gameObject.SetActive(value: true);
			}
			InsertedCassette = null;
		}
	}

	public void CassetteRemoveToWorld()
	{
		if (InsertedCassette == null)
		{
			Debug.LogWarning("CassetteInteractionArea doesn't have a cassette inserted", this);
			return;
		}
		if (!doorOpen)
		{
			Debug.LogWarning("CassetteInteractionArea door is closed, ignoring.", this);
			return;
		}
		InsertedCassette = null;
		magazine.RemoveItem(0, activateItem: true, dropItem: true);
		areaControl.InteractionAllowed = false;
		if (triggerEnterTarget != null)
		{
			triggerEnterTarget.gameObject.SetActive(value: true);
		}
	}
}
