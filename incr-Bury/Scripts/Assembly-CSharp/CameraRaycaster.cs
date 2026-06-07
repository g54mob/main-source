using UnityEngine;
using UnityEngine.UI;

public class CameraRaycaster : MonoBehaviour
{
	[SerializeField]
	private LayerMask layerMask;

	[SerializeField]
	private float rayLength;

	[SerializeField]
	private Button aimedAtButton;

	private Button aimedAtButton_Prev;

	[SerializeField]
	private Color activeButtonColor;

	[SerializeField]
	private Color inactiveButtonColor;

	private void Start()
	{
	}

	private void Update()
	{
		RaycastForButtons();
		HandleClicks();
	}

	private void RaycastForButtons()
	{
		if (Physics.Raycast(new Ray(base.transform.position, base.transform.forward), out var hitInfo, rayLength, layerMask, QueryTriggerInteraction.Ignore))
		{
			if (hitInfo.collider.gameObject.CompareTag("WorldButton"))
			{
				Button component = hitInfo.collider.gameObject.GetComponent<Button>();
				if (aimedAtButton == null || aimedAtButton != component)
				{
					aimedAtButton = component;
					ColorBlock colors = aimedAtButton.colors;
					colors.normalColor = activeButtonColor;
					aimedAtButton.colors = colors;
				}
			}
			else
			{
				NoButtonAimedAt();
			}
		}
		else
		{
			NoButtonAimedAt();
		}
		aimedAtButton_Prev = aimedAtButton;
	}

	private void NoButtonAimedAt()
	{
		if ((bool)aimedAtButton)
		{
			ColorBlock colors = aimedAtButton.colors;
			colors.normalColor = inactiveButtonColor;
			aimedAtButton.colors = colors;
		}
		if ((bool)aimedAtButton_Prev)
		{
			ColorBlock colors2 = aimedAtButton_Prev.colors;
			colors2.normalColor = inactiveButtonColor;
			aimedAtButton_Prev.colors = colors2;
		}
		aimedAtButton_Prev = null;
		aimedAtButton = null;
	}

	private void HandleClicks()
	{
		if (InputManager.Singleton.inputActions.PlayerActionMap.Throw.WasPressedThisFrame() && (bool)aimedAtButton)
		{
			aimedAtButton.onClick.Invoke();
		}
	}
}
