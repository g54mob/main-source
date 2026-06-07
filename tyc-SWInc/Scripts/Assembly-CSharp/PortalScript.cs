using System;
using UnityEngine;

public class PortalScript : FurnitureInteractScript
{
	public Furniture Furn;

	public PipLight Light;

	public MeshRenderer Portal;

	public Material PortalOn;

	public Material PortalOff;

	public Material PortalInactive;

	public Color LightColorOn;

	public Color LightColorOff;

	private float _portalState;

	private bool _wasActive = true;

	[NonSerialized]
	private Material _lastMat;

	public override void Interact()
	{
		_portalState = 2f;
	}

	private void Awake()
	{
		Material lastMat = (Portal.sharedMaterial = new Material(Portal.sharedMaterial));
		_lastMat = lastMat;
	}

	private void OnDestroy()
	{
		if (_lastMat != null)
		{
			UnityEngine.Object.Destroy(_lastMat);
		}
	}

	private void FixedUpdate()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if ((Light.shadowType == LightShadows.Hard) ^ Options.MoreShadow)
		{
			Light.shadowType = (Options.MoreShadow ? LightShadows.Hard : LightShadows.None);
		}
		bool isOn = Furn.IsOn;
		if (_wasActive != isOn)
		{
			_wasActive = isOn;
			Light.enabled = isOn;
			if (_lastMat != null)
			{
				UnityEngine.Object.Destroy(_lastMat);
			}
			Material lastMat = (Portal.sharedMaterial = new Material(isOn ? PortalOff : PortalInactive));
			_lastMat = lastMat;
			if (!isOn)
			{
				_portalState = 0f;
			}
		}
		if (isOn && _portalState > -1f)
		{
			_portalState = Mathf.Max(0f, _portalState - Time.deltaTime * GameSettings.GameSpeed);
			float t = Mathf.Min(_portalState, 1f);
			Light.color = Color.Lerp(LightColorOff, LightColorOn, t);
			_lastMat.SetVector("_GradientScale", Vector4.Lerp(PortalOff.GetVector("_GradientScale"), PortalOn.GetVector("_GradientScale"), t));
			_lastMat.SetVector("_GradientScale2", Vector4.Lerp(PortalOff.GetVector("_GradientScale2"), PortalOn.GetVector("_GradientScale2"), t));
			_lastMat.SetVector("_TurnSpeed", Vector4.Lerp(PortalOff.GetVector("_TurnSpeed"), PortalOn.GetVector("_TurnSpeed"), t));
			_lastMat.SetFloat("_MorphSpeed", Mathf.Lerp(PortalOff.GetFloat("_MorphSpeed"), PortalOn.GetFloat("_MorphSpeed"), t));
			_lastMat.SetFloat("_Emission", Mathf.Lerp(PortalOff.GetFloat("_Emission"), PortalOn.GetFloat("_Emission"), t));
			_lastMat.SetColor("_Color", Color.Lerp(PortalOff.GetColor("_Color"), PortalOn.GetColor("_Color"), t));
			_lastMat.SetColor("_Color2", Color.Lerp(PortalOff.GetColor("_Color2"), PortalOn.GetColor("_Color2"), t));
			_lastMat.SetColor("_Color3", Color.Lerp(PortalOff.GetColor("_Color3"), PortalOn.GetColor("_Color3"), t));
			_lastMat.SetColor("_BackColor", Color.Lerp(PortalOff.GetColor("_BackColor"), PortalOn.GetColor("_BackColor"), t));
			if (_portalState == 0f)
			{
				_portalState = -1f;
			}
		}
	}
}
