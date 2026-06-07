using Aux;
using UnityEngine;
using UnityEngine.UI;

public class OutroController : ActiveComponent
{
	[SceneBind("ExitButton")]
	private Button exitButton;

	[SceneBind("ContentHolder/Content")]
	private RectTransform contentRectTransform;

	[SceneBind("ContentHolder/Content")]
	private Button runOutro;

	[SceneBind("SpeedLayer")]
	private HotStartSpeedLayerControl speedControl;

	public float baseScrollSpeed;

	public float arrowScrollSpeedRate;

	public float wheelScrollSpeedRate;

	private float height;

	private float BaseScrollSpeed => baseScrollSpeed / contentRectTransform.sizeDelta.y;

	private float ScrollPosition
	{
		get
		{
			return contentRectTransform.anchoredPosition.y / contentRectTransform.sizeDelta.y;
		}
		set
		{
			Vector3 vector = new Vector3(0f, Mathf.Min(1f, Mathf.Max(value, 0f)) * contentRectTransform.sizeDelta.y, 0f);
			contentRectTransform.anchoredPosition = vector;
		}
	}

	public override void Init()
	{
		base.Init();
		ResetScrollViewPosition();
		base.gameObject.SetActive(value: true);
		ActiveComponent.Program.cursor.SetActive(state: false);
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		exitButton.onClick.AddListener(OnExit);
		speedControl.Init(0.5f, 3f, 0.5f);
		runOutro.onClick.AddListener(delegate
		{
			speedControl.Freezed = !speedControl.Freezed;
		});
		Vector3[] worldCorners = Helper.GetWorldCorners(contentRectTransform);
		height = worldCorners[1].y - worldCorners[0].y;
	}

	private void FreezingScroll(float shift)
	{
		speedControl.Freezed = true;
		ScrollPosition -= shift * wheelScrollSpeedRate;
	}

	private void OnExit()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		ActiveComponent.Sound.ActiveMusic("Monokanal/WhileTrueLearn_Music_For_Menu");
		ActiveComponent.Program.cursor.SetPosition(ActiveComponent.Program.mainMenu.outroButton.transform.position);
		base.gameObject.SetActive(value: false);
	}

	private void ResetScrollViewPosition()
	{
		ScrollPosition = 0f;
		speedControl.Freezed = false;
		speedControl.Speed = 1f;
	}

	private void Update()
	{
		if (!base.IsInited)
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			OnExit();
			return;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			FreezingScroll(BaseScrollSpeed * arrowScrollSpeedRate);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			FreezingScroll((0f - BaseScrollSpeed) * arrowScrollSpeedRate);
		}
		ScrollPosition += BaseScrollSpeed * speedControl.Speed;
		if (ActiveComponent.Program.joyInput.bUp)
		{
			if (ActiveComponent.Model.KeyBoardTicks <= 0)
			{
				OnExit();
			}
			return;
		}
		if (ActiveComponent.Program.joyInput.areaMove)
		{
			Vector3 areaMoveDelta = ActiveComponent.Program.joyInput.areaMoveDelta;
			areaMoveDelta.x = 0f;
			ScrollPosition += Logic.ModifySliderMoveDelta(areaMoveDelta).y / height;
			speedControl.Freezed = true;
		}
		else
		{
			ScrollPosition += BaseScrollSpeed * speedControl.Speed;
		}
		if (!ActiveComponent.Program.cursor.Visible())
		{
			speedControl.Freezed = !speedControl.Freezed;
		}
	}
}
