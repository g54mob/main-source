using UnityEngine;
using UnityEngine.Rendering;

public class LightProbeTest : MonoBehaviour
{
	[Button("GetAmbientProbe", "")]
	public bool _bButton1;

	[Button("SetAmbientProbe", "")]
	public bool _bButton2;

	public SphericalHarmonicsL2 _shrHarmonics;

	public Vector3[] _vecHarmonicsValues;

	public void SetAmbientProbe()
	{
		SphericalHarmonicsL2 ambientProbe = default(SphericalHarmonicsL2);
		for (int i = 0; i < _vecHarmonicsValues.Length; i++)
		{
			ambientProbe[0, i] = _vecHarmonicsValues[i].x;
			ambientProbe[1, i] = _vecHarmonicsValues[i].y;
			ambientProbe[2, i] = _vecHarmonicsValues[i].z;
		}
		RenderSettings.ambientProbe = ambientProbe;
	}

	public void GetAmbientProbe()
	{
		_shrHarmonics = RenderSettings.ambientProbe;
		_vecHarmonicsValues = new Vector3[9];
		for (int i = 0; i < _vecHarmonicsValues.Length; i++)
		{
			_vecHarmonicsValues[i] = new Vector3(_shrHarmonics[0, i], _shrHarmonics[1, i], _shrHarmonics[2, i]);
		}
	}
}
