using System;
using UnityEngine;

public class Button3DEvents
{
	private Ray mouseRay;

	private RaycastHit button3DRaycastHit;

	private GameObject currentButton3DObject;

	private GameObject lastButton3DObject;

	private Button3D currentButton3D;

	private Button3D selectedButton3D;

	private Button3D preSelectedButton3D;

	private bool isButton3DSelected;

	private bool shouldCheckButtonId;

	private bool wasClickedDownOverRestrictedZone;

	private bool isRunning;

	public event Action<Button3D> OnButton3DSelected;

	public event Action OnButton3DDeselected;

	public event Func<bool> OnOverRestrictedZone;

	public Button3DEvents(bool shouldCheckButtonId = false)
	{
		this.shouldCheckButtonId = shouldCheckButtonId;
		isRunning = false;
	}

	public void Start()
	{
		isButton3DSelected = false;
		wasClickedDownOverRestrictedZone = false;
	}

	public void Run()
	{
		mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		bool num = Physics.Raycast(mouseRay, out button3DRaycastHit, 100f, LayerNames.Button3DMask);
		bool flag = false;
		if (this.OnOverRestrictedZone != null)
		{
			flag = this.OnOverRestrictedZone();
		}
		if (num && !flag)
		{
			if (button3DRaycastHit.collider.CompareTag("Button3D"))
			{
				currentButton3DObject = button3DRaycastHit.collider.gameObject;
				if (currentButton3DObject != lastButton3DObject)
				{
					Button3D button3D = currentButton3DObject.GetComponent<Button3D>();
					if (button3D == null)
					{
						button3D = currentButton3DObject.GetComponentInParent<Button3D>();
					}
					string id = button3D.Id;
					string text = ((selectedButton3D != null) ? selectedButton3D.Id : "");
					if (currentButton3D != null)
					{
						currentButton3D.SetOriginalColor();
					}
					if (!shouldCheckButtonId || id != text)
					{
						currentButton3D = button3D;
						currentButton3D.SetHighlightedColor();
					}
					currentButton3D = button3D;
				}
				if (Input.GetKeyDown(KeyCode.Mouse0))
				{
					preSelectedButton3D = currentButton3D;
				}
				if (Input.GetKeyUp(KeyCode.Mouse0) && preSelectedButton3D == currentButton3D)
				{
					if (selectedButton3D != null)
					{
						selectedButton3D.UnSelectedColor();
					}
					if (currentButton3D != null)
					{
						selectedButton3D = currentButton3D;
						selectedButton3D.SetSelectedColor();
						this.OnButton3DSelected?.Invoke(selectedButton3D);
						isButton3DSelected = true;
					}
				}
				lastButton3DObject = currentButton3DObject;
			}
		}
		else
		{
			if (currentButton3D != null)
			{
				currentButton3D.SetOriginalColor();
				currentButton3D = null;
			}
			lastButton3DObject = null;
		}
		if (Input.GetKeyDown(KeyCode.Mouse0) && flag)
		{
			wasClickedDownOverRestrictedZone = true;
		}
		if (Input.GetKeyUp(KeyCode.Mouse0) && !isButton3DSelected)
		{
			if (!flag && !wasClickedDownOverRestrictedZone)
			{
				UnSelectButton3D();
			}
			preSelectedButton3D = null;
			wasClickedDownOverRestrictedZone = false;
		}
		isButton3DSelected = false;
		isRunning = true;
	}

	public void Stop()
	{
		if (isRunning)
		{
			if (currentButton3D != null)
			{
				currentButton3D.UnSelectedColor();
			}
			currentButton3D = null;
			UnSelectButton3D();
			preSelectedButton3D = null;
			wasClickedDownOverRestrictedZone = false;
			isRunning = false;
		}
	}

	public void UnSelectButton3D()
	{
		if (selectedButton3D != null)
		{
			selectedButton3D.UnSelectedColor();
			this.OnButton3DDeselected?.Invoke();
			selectedButton3D = null;
		}
	}
}
