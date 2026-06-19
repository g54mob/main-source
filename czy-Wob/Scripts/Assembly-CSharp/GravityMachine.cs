using UnityEngine;

public class GravityMachine : MonoBehaviour
{
	public GameObject gravityMachineGUI;

	public Animator selfAnimator;

	private string machineOnBool = "IsOn";

	private float currentGravMod = 1f;

	private ulong associatedUID;

	private RoomBase associatedRoom;

	private BoundingBoxComponent bbcRef;

	private void Start()
	{
		bbcRef = GetComponent<BoundingBoxComponent>();
		associatedUID = GetComponent<PlacedObjectID>().GetUID();
		DogHome globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		ulong? num = bbcRef.GetRoomUID();
		if (!num.HasValue)
		{
			Debug.LogError("No valid room found for Grav Machine.");
			num = 0uL;
		}
		associatedRoom = globalComponent.GetRoomForUID(num.Value);
		SetGravMod(currentGravMod);
	}

	public void SaveObject(SaveablePlacedObject data)
	{
		data.floatList.Add(currentGravMod);
	}

	public void LoadObject(SaveablePlacedObject data)
	{
		if (data.floatList.Count > 0)
		{
			SetGravMod(data.floatList[0]);
		}
	}

	private void OnDestroy()
	{
		if (associatedRoom != null)
		{
			associatedRoom.RemoveGravMod(associatedUID);
		}
	}

	public void SetGravMod(float newMod)
	{
		currentGravMod = newMod;
		if (associatedRoom != null)
		{
			associatedRoom.AddGravMod(associatedUID, currentGravMod);
		}
		if (currentGravMod == 1f)
		{
			selfAnimator.SetBool(machineOnBool, value: false);
		}
		else
		{
			selfAnimator.SetBool(machineOnBool, value: true);
		}
	}

	public void OnClick()
	{
		Object.Instantiate(gravityMachineGUI, Vector3.zero, Quaternion.identity).GetComponent<GravityMachineGUIController>().SetGravMachineRef(this, currentGravMod);
	}
}
