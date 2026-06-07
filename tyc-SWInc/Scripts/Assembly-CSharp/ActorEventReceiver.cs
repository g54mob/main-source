using UnityEngine;

public class ActorEventReceiver : MonoBehaviour
{
	public Actor Parent;

	public bool Active = true;

	public void TakeItemNow(string item)
	{
		if (Active)
		{
			Parent.GetItem(item, true);
		}
	}

	public void HammerHit()
	{
		if (Active && Parent.MayPlaySound())
		{
			Parent.AudioComp.PlayOneShot(Parent.HammerHitSFX);
		}
	}

	public void Interact()
	{
		if (Active && Parent.UsingPoint != null)
		{
			Parent.UsingPoint.Parent.InteractStart();
		}
	}

	public void OpenVanDoor()
	{
	}

	public void CloseCarDoor()
	{
	}

	public void OpenCarDoor()
	{
	}

	public void CarEntered()
	{
	}

	public void OnBike()
	{
	}

	public void InBed()
	{
	}

	private int GetFootID()
	{
		if (Parent.IsOnRoad())
		{
			return 3;
		}
		if (!(Parent.currentRoom == null))
		{
			return (int)Parent.currentRoom.SFXType;
		}
		return 1;
	}

	public void FirstFoot()
	{
		if (Active && GameSettings.GameSpeed == 1f && Parent.MayPlaySound())
		{
			Parent.AudioComp.clip = Parent.FeetSFX[GetFootID() * 4 + Random.Range(0, 2)];
			Parent.AudioComp.Play();
		}
	}

	public void SecondFoot()
	{
		if (Active && GameSettings.GameSpeed == 1f && Parent.MayPlaySound())
		{
			Parent.AudioComp.clip = Parent.FeetSFX[GetFootID() * 4 + Random.Range(2, 4)];
			Parent.AudioComp.Play();
		}
	}
}
