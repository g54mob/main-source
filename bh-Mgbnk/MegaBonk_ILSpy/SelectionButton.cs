using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class SelectionButton : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
{
	public GameObject selectionOverlay;

	public RawImage i_icon;

	public TextMeshProUGUI t_name;

	private Button button;

	protected bool clicked;

	protected bool selected;

	private void Awake()
	{
		Button component = GetComponent<Button>();
		this.button = component;
		Button button = this.button;
		UnityAction call = OnClick;
		button.m_OnClick.AddListener(call);
		Init();
	}

	private void OnDestroy()
	{
		Button button = this.button;
		UnityAction call = OnClick;
		button.m_OnClick.RemoveListener(call);
		Cleanup();
	}

	protected abstract void Init();

	protected abstract void Cleanup();

	private unsafe void Update()
	{
		//IL_0333: Invalid comparison between I4 and F4
		//IL_01de: Expected F4, but got I4
		//IL_01f0: Expected O, but got Ref
		//IL_02ad: Invalid comparison between I4 and F4
		//IL_00dd: Expected F4, but got I4
		//IL_00ef: Expected O, but got Ref
		//IL_0372: Invalid comparison between I4 and F4
		//IL_0277: Expected F4, but got I4
		//IL_0289: Expected O, but got Ref
		//IL_02ec: Invalid comparison between I4 and F4
		float num2 = default(float);
		Transform transform5;
		float num3;
		if (!selected && !clicked)
		{
			Transform transform = i_icon.transform;
			Transform transform2 = i_icon.transform;
			Vector3 localScale = transform2.localScale;
			float deltaTime = Time.deltaTime;
			float num = deltaTime * 6f;
			if (!(0f > num))
			{
				if (num > 1f)
				{
					num = 1f;
				}
			}
			else
			{
				num = 0f;
			}
			transform.localScale = (Vector3)(&num2);
			Transform transform3 = t_name.transform;
			Transform transform4 = t_name.transform;
			Vector3 localScale2 = transform4.localScale;
			float deltaTime2 = Time.deltaTime;
			num3 = deltaTime2 * 10f;
			bool flag = 0f > num3;
			transform5 = transform3;
			if (flag)
			{
				goto IL_026e;
			}
			bool flag2 = !(num3 > 1f);
			transform5 = transform3;
			if (!flag2)
			{
				num3 = 1f;
				transform5 = transform3;
			}
		}
		else
		{
			Transform transform6 = i_icon.transform;
			Transform transform7 = i_icon.transform;
			Vector3 localScale3 = transform7.localScale;
			float deltaTime3 = Time.deltaTime;
			float num4 = deltaTime3 * 6f;
			if (!(0f > num4))
			{
				if (num4 > 1f)
				{
					num4 = 1f;
				}
			}
			else
			{
				num4 = 0f;
			}
			transform6.localScale = (Vector3)(&num2);
			Transform transform8 = t_name.transform;
			Transform transform9 = t_name.transform;
			Vector3 localScale4 = transform9.localScale;
			float deltaTime4 = Time.deltaTime;
			num3 = deltaTime4 * 10f;
			bool flag3 = 0f > num3;
			transform5 = transform8;
			if (flag3)
			{
				goto IL_026e;
			}
			bool flag4 = !(num3 > 1f);
			transform5 = transform8;
			if (!flag4)
			{
				num3 = 1f;
				transform5 = transform8;
			}
		}
		goto IL_027c;
		IL_027c:
		transform5.localScale = (Vector3)(&num2);
		return;
		IL_026e:
		num3 = 0f;
		goto IL_027c;
	}

	public void Enable()
	{
		clicked = false;
		button.interactable = true;
		if (!selected && !clicked)
		{
			selectionOverlay.SetActive(value: false);
		}
		else
		{
			selectionOverlay.SetActive(value: true);
		}
	}

	public void Disable()
	{
		button.interactable = false;
		if (!selected && !clicked)
		{
			selectionOverlay.SetActive(value: false);
		}
		else
		{
			selectionOverlay.SetActive(value: true);
		}
	}

	protected void OnClick()
	{
		clicked = true;
		selectionOverlay.SetActive(value: true);
		OnClicked();
	}

	protected abstract void OnClicked();

	protected void UpdateSelectionOverlay()
	{
		if (!selected && !clicked)
		{
			selectionOverlay.SetActive(value: false);
		}
		else
		{
			selectionOverlay.SetActive(value: true);
		}
	}

	public void OnSelect(BaseEventData eventData)
	{
		selected = true;
		selectionOverlay.SetActive(value: true);
		OnSelectedCharacter();
	}

	public void SelectCharacter()
	{
		selected = true;
		selectionOverlay.SetActive(value: true);
		OnSelectedCharacter();
	}

	protected abstract void OnSelectedCharacter();

	public void OnDeselect(BaseEventData eventData)
	{
		selected = false;
		if (!clicked)
		{
			selectionOverlay.SetActive(value: false);
		}
		else
		{
			selectionOverlay.SetActive(value: true);
		}
	}
}
