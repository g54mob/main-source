using UnityEngine;
using UnityEngine.UI;

public class RocketPadPayloadControl : MonoBehaviour
{
	public Image image;

	public Dropdown dropdown;

	public Toggle autoToggle;

	public RocketPadPane rocketPadPane;

	private Payload.PAYLOAD_TYPE _payloadType;

	public Payload.PAYLOAD_TYPE payloadType
	{
		get
		{
			return default(Payload.PAYLOAD_TYPE);
		}
		set
		{
		}
	}

	public void Awake()
	{
	}

	public void OnDropDownChange(int val)
	{
	}
}
