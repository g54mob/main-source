using ClockStone;
using TMPro;
using UnityEngine;

public class WorldspaceAudioVisualizer : MonoBehaviour
{
	public TextMeshProUGUI textField;

	public AudioObject associatedObject;

	private float destroyTimer = 1f;

	private bool beingDestroyed;

	private string baseText;

	private void Update()
	{
		if (beingDestroyed)
		{
			destroyTimer -= Time.deltaTime;
			if (destroyTimer <= 0f)
			{
				Object.Destroy(base.gameObject);
			}
		}
		else
		{
			UpdateVolume();
			if (associatedObject == null)
			{
				beingDestroyed = true;
			}
		}
	}

	public void StartDestruction()
	{
		beingDestroyed = true;
	}

	public void SetAudioObject(AudioObject obj)
	{
		associatedObject = obj;
		string audioID = obj.audioID;
		textField.text = audioID;
		baseText = audioID;
		UpdateVolume();
	}

	private void UpdateVolume()
	{
		textField.text = baseText + " (" + MathUtil.Round(associatedObject.volumeTotal, 3) * 100f + "%)";
	}
}
