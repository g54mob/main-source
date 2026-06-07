using System;
using TMPro;
using UI.ThreeDimensional;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModelBrowserButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public UIObject3D obj3d;

	[NonSerialized]
	public ModelBrowser modelBrowser;

	public GameObject selectedImage;

	public TextMeshProUGUI text;

	private string _meshName;

	private bool _selected;

	public string meshName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool selected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void OnClick()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void OnDisable()
	{
	}
}
