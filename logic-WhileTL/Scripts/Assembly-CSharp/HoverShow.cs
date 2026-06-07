using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverShow : ActiveComponent, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler
{
	private List<GameObject> showObjects = new List<GameObject>();

	private List<Text> texts = new List<Text>();

	private List<Image> images = new List<Image>();

	[SceneBind("HoverLayer")]
	public Image HoverLayer;

	private bool hover;

	private float timer;

	private bool hide;

	private const float shift = 0.5f;

	public float scale = 0.5f;

	public void Start()
	{
		if (!base.IsInited)
		{
			Init();
		}
	}

	public void Hide(bool flag)
	{
		hide = flag;
	}

	public void ReInit()
	{
		foreach (GameObject showObject in showObjects)
		{
			showObject.gameObject.SetActive(value: true);
		}
		Init();
	}

	public override void Init()
	{
		base.Init();
		SceneBindContainer.BindObjects(this, base.transform);
		foreach (GameObject showObject in showObjects)
		{
			if (showObject != null)
			{
				showObject.gameObject.SetActive(value: true);
			}
		}
		foreach (Text text in texts)
		{
			if (text != null)
			{
				text.gameObject.SetActive(value: true);
			}
		}
		foreach (Image image in images)
		{
			if (image != null)
			{
				image.gameObject.SetActive(value: true);
			}
		}
		Transform[] componentsInChildren = base.transform.GetComponentsInChildren<Transform>();
		showObjects.Clear();
		texts.Clear();
		images.Clear();
		timer = -1f;
		Transform[] array = componentsInChildren;
		foreach (Transform transform in array)
		{
			if (transform.tag == "ShowObject" || transform.parent.tag == "ShowObject")
			{
				showObjects.Add(transform.gameObject);
				if (transform.GetComponent<Image>() != null)
				{
					images.Add(transform.GetComponent<Image>());
				}
				if (transform.GetComponent<Text>() != null)
				{
					texts.Add(transform.GetComponent<Text>());
				}
			}
			if (transform.tag == "ActiveComponent" && transform != base.transform)
			{
				transform.gameObject.GetComponent<ActiveComponent>().Init();
			}
		}
		foreach (GameObject showObject2 in showObjects)
		{
			showObject2.gameObject.SetActive(value: false);
		}
		foreach (Text text2 in texts)
		{
			text2.gameObject.SetActive(value: false);
		}
		foreach (Image image2 in images)
		{
			image2.gameObject.SetActive(value: false);
		}
		hover = false;
	}

	private void Update()
	{
		if (!hover || showObjects.Count <= 0 || showObjects[0].gameObject.activeSelf || !(Time.time - timer > scale))
		{
			return;
		}
		foreach (GameObject showObject in showObjects)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_PopupWindow");
			showObject.gameObject.SetActive(value: true);
		}
	}

	public void Hide()
	{
		Clear();
		foreach (GameObject showObject in showObjects)
		{
			showObject.gameObject.SetActive(value: false);
		}
		Init();
		hover = false;
		hide = true;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void Clear()
	{
		showObjects.RemoveAll((GameObject o) => o == null);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!hide)
		{
			Clear();
			timer = Time.time;
			hover = true;
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hover = false;
		Clear();
		foreach (GameObject showObject in showObjects)
		{
			showObject.gameObject.SetActive(value: false);
		}
	}
}
