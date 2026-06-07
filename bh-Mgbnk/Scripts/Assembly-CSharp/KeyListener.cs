using System;
using System.Collections.Generic;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyListener : MonoBehaviour
{
	public InputSettingNew currentlyChanging;

	public TextMeshProUGUI alertText;

	public TextMeshProUGUI t_countdown;

	public RawImage overlay;

	private float readyForKeyTime;

	private List<InputMapper.Context> contexts;

	public GameObject window;

	private bool result;

	private float timeout;

	public static KeyListener Instance;

	private List<InputMapper> mappers;

	private EventSystem eventSystem;

	private GameObject focusedObject;

	private bool hasSet;

	public static Action A_MapChanged;

	public static bool hasChangedKey;

	public bool justClosed { get; set; }

	public bool isListening { get; private set; }

	private void Awake()
	{
	}

	public void StartListening(InputSettingNew listener, List<InputMapper.Context> contexts)
	{
	}

	private bool CanChange()
	{
		return false;
	}

	private void OnInputMapped(InputMapper.InputMappedEventData mapEvent)
	{
	}

	private void StopMappers()
	{
	}

	private bool OnIsElementAllowed(ControllerPollingInfo info)
	{
		return false;
	}

	private void Update()
	{
	}

	private void StartMappers()
	{
	}

	private void OnDestroy()
	{
	}

	private void CloseListener(ActionElementMap newActionElementMap)
	{
	}

	private void Close()
	{
	}

	private void Cooldown()
	{
	}

	public bool IsListening()
	{
		return false;
	}
}
