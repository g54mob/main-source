using UnityEngine;
using UnityEngine.UI;

public class OrbitalIndicator : MonoBehaviour
{
	public GameObject model;

	public Text orbitalName;

	public Text orbitalCount;

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

	public void OnDeployClicked()
	{
	}
}
