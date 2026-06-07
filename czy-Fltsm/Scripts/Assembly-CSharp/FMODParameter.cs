using System;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

[Serializable]
public class FMODParameter
{
	[ParamRef]
	[SerializeField]
	private string _parameter;

	private RESULT _result;

	private PARAMETER_DESCRIPTION _parameterDescription;

	private bool Initialize()
	{
		if (string.IsNullOrEmpty(_parameterDescription.name))
		{
			if (_result == RESULT.OK)
			{
				_result = RuntimeManager.StudioSystem.getParameterDescriptionByName(_parameter, out _parameterDescription);
				if (_result == RESULT.OK)
				{
					return true;
				}
				UnityEngine.Debug.LogErrorFormat("Initialization of FMODParameter '{0}' intialization failed with result: {1}", _parameter, _result);
			}
			return false;
		}
		return true;
	}

	public void SetValue(float value)
	{
		if (Initialize())
		{
			RuntimeManager.StudioSystem.setParameterByID(_parameterDescription.id, value);
		}
	}
}
