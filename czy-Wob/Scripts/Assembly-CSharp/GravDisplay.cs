using TMPro;
using UnityEngine;

public class GravDisplay : MonoBehaviour
{
	private TextMeshProUGUI textRef;

	public RoomEffectAntiGrav gravRef;

	private void Awake()
	{
		textRef = GetComponent<TextMeshProUGUI>();
	}

	private void Update()
	{
		textRef.text = gravRef.GetGravModName();
	}
}
