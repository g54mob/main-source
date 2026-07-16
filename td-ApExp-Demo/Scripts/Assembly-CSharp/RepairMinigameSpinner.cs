using UnityEngine;
using UnityEngine.UI;

public class RepairMinigameSpinner : RepairMinigame
{
	[SerializeField]
	private Transform greenRing;

	[SerializeField]
	private Sprite greenRingUpgraded;

	[SerializeField]
	private Transform handleTf;

	[SerializeField]
	private Image handleImage;

	[SerializeField]
	private Hotkey hotkey;

	private float goalAngle = 30f;

	private bool isRotatingCW;

	private bool eligible;

	[SerializeField]
	private float rotationSpeed;

	public override void InteractKey(Interactor interactor)
	{
		if (Time.timeScale != 0f)
		{
			if (eligible)
			{
				base.transform.GetChild(0).gameObject.SetActive(value: false);
				MinigameComplete(interactor);
			}
			else
			{
				ResetMinigame(interactor);
			}
		}
	}

	public override void ResetMinigame(Interactor interactor)
	{
		base.ResetMinigame(interactor);
		hotkey.UpdateIconAndKey(interactor.playerController.InputHandler.controllerType);
		base.transform.GetChild(0).gameObject.SetActive(value: true);
		if (greenRing != null)
		{
			isRotatingCW = Random.Range(0, 2) == 0;
			Quaternion rotation = Quaternion.LookRotation(Vector3.forward, -handleTf.transform.up);
			greenRing.rotation = rotation;
		}
	}

	private void Update()
	{
		if (Time.timeScale != 0f)
		{
			handleTf.Rotate(new Vector3(0f, 0f, rotationSpeed * (float)(isRotatingCW ? 1 : (-1)) * Time.deltaTime));
			float z = handleTf.rotation.eulerAngles.z;
			float z2 = greenRing.rotation.eulerAngles.z;
			float num = Mathf.Abs(z - z2);
			if (num > 180f)
			{
				num = 360f - num;
			}
			if (num < goalAngle)
			{
				eligible = true;
				handleImage.color = Color.green;
				handleImage.transform.localScale = Vector3.one * 1.25f;
				hotkey.GetComponent<Outline>().SetOutline(isActive: true, Color.green);
			}
			else
			{
				eligible = false;
				handleImage.color = Color.white;
				handleImage.transform.localScale = Vector3.one;
				hotkey.GetComponent<Outline>().SetOutline(isActive: false, Color.white);
			}
		}
	}

	public override void OnMinigameUpgrade()
	{
		goalAngle += 30f;
		greenRing.GetComponent<Image>().sprite = greenRingUpgraded;
	}
}
