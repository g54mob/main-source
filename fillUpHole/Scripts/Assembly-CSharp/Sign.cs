using UnityEngine;

public class Sign : MonoBehaviour
{
	public ColumnController ParentColumn;

	public GameObject BuildText;

	public GameObject InfoText;

	private bool? cachedIsBuild;

	private SignChar _charObject;

	public static bool PreventEvent;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
		if (_charObject != null)
		{
			return;
		}
		if (ParentColumn == null)
		{
			if (cachedIsBuild.HasValue)
			{
				cachedIsBuild = null;
				BuildText.SetActive(value: false);
				InfoText.SetActive(value: false);
			}
		}
		else if (ParentColumn.GetBuildingType() == BaseBuilding.BuildingTypeEnum.None)
		{
			if (!cachedIsBuild.HasValue || cachedIsBuild != true)
			{
				cachedIsBuild = true;
				BuildText.SetActive(value: true);
				InfoText.SetActive(value: false);
			}
		}
		else if (!cachedIsBuild.HasValue || cachedIsBuild == true)
		{
			cachedIsBuild = false;
			BuildText.SetActive(value: false);
			InfoText.SetActive(value: true);
		}
	}

	public void SetForChar(SignChar charOBject)
	{
		_charObject = charOBject;
		BuildText.SetActive(value: false);
		InfoText.SetActive(value: true);
	}

	public void OnMouseEnter()
	{
		if (!PreventEvent)
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_hover);
		}
	}

	private void OnMouseDown()
	{
		if (!PreventEvent)
		{
			if (_charObject != null)
			{
				_charObject.HandleClick();
			}
			else if (!CameraController.Instance.IsStopMovement)
			{
				WorldCanvasController.Instance.OpenColumnPanel(ParentColumn);
			}
		}
	}
}
