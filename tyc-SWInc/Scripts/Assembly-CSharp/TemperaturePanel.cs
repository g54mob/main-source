using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class TemperaturePanel : MonoBehaviour
{
	public GUIProgressBar HeatProg;

	public GUIProgressBar CoolProg;

	public RectTransform Self;

	public RectTransform MainProg;

	public RectTransform sProg;

	private Room _activeRoom;

	private Furniture _activeFurn;

	public float ProgDiameter;

	private float _rad;

	private float _lastPerc;

	private float _turnOff = -1f;

	private void Awake()
	{
		_rad = (float)Math.PI * Mathf.Pow(ProgDiameter / 2f, 2f);
	}

	private void Update()
	{
		if (_turnOff > 0f)
		{
			_turnOff -= Time.deltaTime;
			if (_turnOff <= 0f)
			{
				SetRoom(null, null);
				return;
			}
		}
		Self.anchoredPosition = new Vector2(Input.mousePosition.x + 64f, Input.mousePosition.y - (float)Screen.height) * (1f / Options.UISize);
		if (_activeRoom == null)
		{
			SetPercent(0f, 0f);
			return;
		}
		Room mainAtriumParentOrSelf = _activeRoom.GetMainAtriumParentOrSelf();
		float num = mainAtriumParentOrSelf.GetAtriumArea() * mainAtriumParentOrSelf.Insulation;
		float num2 = ((mainAtriumParentOrSelf.Floor >= 0) ? TimeOfDay.Instance.CurrentWeather.MinimumTemperature : 5f);
		float? heatEx = null;
		float? coolEx = null;
		float num4;
		if (num2 < 21f)
		{
			float num3 = num * Room.TemperatureAreaScale(num2);
			num4 = Mathf.Clamp01(mainAtriumParentOrSelf.TheoHeatingControlArea / num3);
			if (_activeFurn != null && _activeFurn.TempControlType == Furniture.TemperatureType.Heating)
			{
				heatEx = Mathf.Clamp01(num4 + _activeFurn.HeatCoolArea / num3);
			}
		}
		else
		{
			num4 = 1f;
		}
		float num6;
		if (mainAtriumParentOrSelf.Floor >= 0 && TimeOfDay.Instance.CurrentWeather.MaximumTemperature > 21f)
		{
			float num5 = num * Room.TemperatureAreaScale(TimeOfDay.Instance.CurrentWeather.MaximumTemperature);
			num6 = Mathf.Clamp01(mainAtriumParentOrSelf.TheoCoolingControlArea / num5);
			if (_activeFurn != null && _activeFurn.TempControlType == Furniture.TemperatureType.Cooling)
			{
				coolEx = Mathf.Clamp01(num6 + _activeFurn.HeatCoolArea / num5);
			}
		}
		else
		{
			num6 = 1f;
		}
		HUD.Instance.TempPanel.SetPercent(num4, num6, heatEx, coolEx);
	}

	private void SetPercent(float heat, float cool, float? heatEx = null, float? coolEx = null)
	{
		HeatProg.Value = heat;
		HeatProg.AltValue = heatEx;
		CoolProg.Value = cool;
		CoolProg.AltValue = coolEx;
		float num = (heat + cool) / 2f;
		if (_lastPerc != num)
		{
			float num2 = Mathf.Sqrt(num * _rad / (float)Math.PI) * 2f;
			MainProg.DOSizeDelta(new Vector2(num2, num2), 0.5f).SetEase(Ease.OutBounce);
			if (_lastPerc < 1f && num == 1f)
			{
				sProg.DOSizeDelta(new Vector2(52f, 52f), 0.75f);
			}
			else
			{
				sProg.sizeDelta = new Vector2(0f, 0f);
			}
			_lastPerc = num;
		}
	}

	public void SetRoom(Room r, Furniture furn)
	{
		_turnOff = -1f;
		if (base.gameObject.activeSelf || !(r == null))
		{
			_activeFurn = furn;
			if (_activeRoom != r)
			{
				MainProg.DOKill();
				sProg.DOKill();
				sProg.sizeDelta = new Vector2(0f, 0f);
				MainProg.sizeDelta = new Vector2(0f, 0f);
				CoolProg.Animated = (HeatProg.Animated = false);
				HeatProg.Value = 0f;
				CoolProg.Value = 0f;
				CoolProg.Animated = (HeatProg.Animated = true);
				_activeRoom = r;
				_lastPerc = 0f;
			}
			base.gameObject.SetActive(r != null);
		}
	}

	public void StartDeactivate()
	{
		_turnOff = 2f;
	}

	private IEnumerator DisableTimer()
	{
		yield return new WaitForSecondsRealtime(2f);
		SetRoom(null, null);
	}
}
