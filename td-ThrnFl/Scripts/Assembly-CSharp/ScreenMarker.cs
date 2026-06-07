using MPUIKIT;
using TMPro;
using UnityEngine;

public class ScreenMarker : MonoBehaviour
{
	[Header("Content")]
	[SerializeField]
	private Sprite showSprite;

	[SerializeField]
	private int showNumber;

	[SerializeField]
	private bool showElite;

	[Header("Setup")]
	[SerializeField]
	private GameObject screenMarkerPrefab;

	private GameObject myUiMarkerGameObject;

	private EnemyScreenMarkerUIHelper uiMarkerData;

	private RectTransform screenMarkerUI;

	private Camera cam;

	private MPImageBasic enemyIcon;

	private TMP_Text enemyNumber;

	private float myRandomVal;

	private Vector2 unclampedScreenPos;

	private Vector2 clampedScreenPos;

	public bool rotateTowardsTargetWhenOffscreen;

	public bool showWhenOnScreen = true;

	public bool showWhenOffScreen = true;

	public Rect checkOnScreenRect;

	private bool onScreen;

	public float MyRandomVal => myRandomVal;

	public Vector2 UnclampedScreenPos
	{
		get
		{
			return unclampedScreenPos;
		}
		set
		{
			unclampedScreenPos = value;
		}
	}

	public Vector2 ClampedScreenPos
	{
		get
		{
			return clampedScreenPos;
		}
		set
		{
			clampedScreenPos = value;
		}
	}

	public bool OnScreen
	{
		get
		{
			return onScreen;
		}
		set
		{
			onScreen = value;
		}
	}

	public Sprite Sprite => showSprite;

	public bool Elite => showElite;

	public int Number => showNumber;

	public Vector2 Position
	{
		get
		{
			if ((bool)screenMarkerUI)
			{
				return screenMarkerUI.localPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if ((bool)screenMarkerUI)
			{
				screenMarkerUI.localPosition = value;
			}
		}
	}

	public float ImageRotation
	{
		get
		{
			return enemyIcon.transform.rotation.z;
		}
		set
		{
			enemyIcon.transform.rotation = Quaternion.Euler(enemyIcon.transform.rotation.x, enemyIcon.transform.rotation.y, value);
		}
	}

	public Rect Rect
	{
		get
		{
			if ((bool)screenMarkerUI)
			{
				return screenMarkerUI.rect;
			}
			return default(Rect);
		}
	}

	private void Start()
	{
		cam = Camera.main;
		myUiMarkerGameObject = Object.Instantiate(screenMarkerPrefab, UIFrameManager.instance.OnScreenMarkerContainer);
		uiMarkerData = myUiMarkerGameObject.GetComponent<EnemyScreenMarkerUIHelper>();
		enemyIcon = uiMarkerData.enemyIcon;
		enemyNumber = uiMarkerData.enemyNumber;
		screenMarkerUI = (RectTransform)myUiMarkerGameObject.transform;
		SetSprite(showSprite);
		SetNumber(showNumber);
		SetElite(showElite);
		ScreenMarkerManager.instance.RegisterScreenMarker(this);
		myRandomVal = Random.value;
		SceneTransitionManager.instance.onSceneChange.AddListener(KillOnSceneChange);
	}

	public void SetSprite(Sprite _sprite)
	{
		if (!(_sprite == null))
		{
			showSprite = _sprite;
			if ((bool)enemyIcon)
			{
				enemyIcon.sprite = _sprite;
			}
		}
	}

	public void Show(bool _show)
	{
		if ((bool)myUiMarkerGameObject && myUiMarkerGameObject.activeSelf != _show)
		{
			myUiMarkerGameObject.SetActive(_show);
		}
	}

	public void SetElite(bool _elite)
	{
		showElite = _elite;
		if ((bool)uiMarkerData)
		{
			uiMarkerData.SetElite(_elite);
		}
	}

	public void SetNumber(int _number)
	{
		showNumber = _number;
		if ((bool)enemyNumber)
		{
			enemyNumber.text = showNumber.ToString();
			enemyNumber.enabled = showNumber > 0;
		}
	}

	private void OnEnable()
	{
		if ((bool)myUiMarkerGameObject)
		{
			myUiMarkerGameObject.SetActive(value: true);
		}
		if ((bool)ScreenMarkerManager.instance)
		{
			ScreenMarkerManager.instance.RegisterScreenMarker(this);
		}
	}

	private void OnDisable()
	{
		if ((bool)myUiMarkerGameObject)
		{
			myUiMarkerGameObject.SetActive(value: false);
		}
		if ((bool)ScreenMarkerManager.instance)
		{
			ScreenMarkerManager.instance.UnregisterScreenMarker(this);
		}
	}

	private void OnDestroy()
	{
		if ((bool)myUiMarkerGameObject)
		{
			Object.Destroy(myUiMarkerGameObject);
		}
		ScreenMarkerManager.instance.UnregisterScreenMarker(this);
	}

	private void KillOnSceneChange()
	{
		Object.Destroy(myUiMarkerGameObject);
		Object.Destroy(base.gameObject);
	}
}
