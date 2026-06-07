using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapMarkerScript : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private RectTransform TheMap;

	private GameObject plr;

	private RectTransform MyRect;

	public bool IsPlayer;

	private TextMeshProUGUI CoorText;

	[HideInInspector]
	public Vector2 MyCoors;

	[HideInInspector]
	public float MyAngle;

	public Image MyCheck;

	public bool Status;

	private Image MyImage;

	[HideInInspector]
	public string cheevotext;

	private SteamScript SScript;

	private JoystickCursorScript JoyScript;

	private bool HasJoyCursor;

	private void Start()
	{
		SScript = GameObject.Find("SteamObject").GetComponent<SteamScript>();
		if (IsPlayer)
		{
			plr = GameObject.Find("FakeSub");
		}
		MyRect = GetComponent<RectTransform>();
		TheMap = GameObject.Find("MapBG").GetComponent<RectTransform>();
		JoyScript = GameObject.Find("JoystickCursor").GetComponent<JoystickCursorScript>();
		CoorText = GameObject.Find("MapCoorsText").GetComponent<TextMeshProUGUI>();
		MyImage = GetComponent<Image>();
	}

	private void Update()
	{
		Vector3 position = Terrain.activeTerrain.transform.position;
		Vector3 size = Terrain.activeTerrain.terrainData.size;
		Vector3 vector = (plr.transform.position - position) * (TheMap.rect.width / size.x);
		MyRect.localPosition = new Vector3(vector.x - TheMap.rect.width / 2f, vector.z - TheMap.rect.width / 2f, 0f);
		if (JoyScript.MyRect.localPosition.x < MyRect.rect.xMax + MyRect.localPosition.x && JoyScript.MyRect.localPosition.x > MyRect.rect.xMin + MyRect.localPosition.x && JoyScript.MyRect.localPosition.y < MyRect.rect.yMax + MyRect.localPosition.y && JoyScript.MyRect.localPosition.y > MyRect.rect.yMin + MyRect.localPosition.y)
		{
			if (JoyScript.JoystickCursorActive)
			{
				ShowText();
				HasJoyCursor = true;
			}
		}
		else
		{
			if (HasJoyCursor)
			{
				ClearText();
			}
			HasJoyCursor = false;
		}
	}

	private void FixedUpdate()
	{
		if (Status)
		{
			MyCheck.enabled = true;
			MyImage.enabled = false;
		}
		else
		{
			MyCheck.enabled = false;
		}
	}

	public void SetMarkerSource(GameObject g)
	{
		plr = g;
	}

	private void OnGUI()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		ShowText();
	}

	public void ShowText()
	{
		if (!Status)
		{
			CoorText.text = "x_" + MyCoors.x.ToString("000") + "\ny_" + MyCoors.y.ToString("000") + "\na_" + MyAngle.ToString("000");
		}
	}

	public void ClearText()
	{
		CoorText.text = "";
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		ClearText();
	}

	public void SetStatus(bool b)
	{
		Status = b;
		if (b && cheevotext != "")
		{
			SScript.UnlockCheevo(cheevotext);
		}
	}

	public bool CheckStatus()
	{
		return Status;
	}
}
