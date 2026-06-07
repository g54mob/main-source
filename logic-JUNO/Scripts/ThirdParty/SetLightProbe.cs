using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class SetLightProbe : MonoBehaviour
{
	protected bool _bIsVisible;

	protected bool _bSampleLightProbes = true;

	[CleanInspectorName]
	public Transform _trnOptionalFixedSamplePosition;

	protected static int s_iAmbientlightLastUpdate;

	protected static int[] s_iParticleAmbientSHA;

	protected static int[] s_iParticleAmbientSHB;

	protected static int s_iParticleAmbientSHC;

	protected static int[] s_iParticleProbeSHA;

	protected static int[] s_iParticleProbeSHB;

	protected static int s_iParticleProbeSHC;

	protected static bool _bIdsSetUp;

	protected static SphericalHarmonicsL2 s_sphAmbientLightAtLastUpdate;

	private MaterialPropertyBlock _mpbMaterialPropertyBlock;

	private SphericalHarmonicsL2 _sphProbe;

	public bool _bLogDebugOutput;

	public void OnBecameVisible()
	{
		if (_bLogDebugOutput)
		{
			Debug.Log("Became Visible");
		}
		_bIsVisible = true;
	}

	public void OnBecameInvisible()
	{
		if (_bLogDebugOutput)
		{
			Debug.Log("Became Invisible");
		}
		_bIsVisible = false;
	}

	public void Awake()
	{
		UpdateProbeSupport();
	}

	public void UpdateProbeSupport()
	{
		string[] shaderKeywords = GetComponent<Renderer>().sharedMaterial.shaderKeywords;
		_bSampleLightProbes = false;
		string[] array = shaderKeywords;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == "LIGHTPROBE")
			{
				_bSampleLightProbes = true;
				if (_bLogDebugOutput)
				{
					Debug.Log("Setting Light Probes");
				}
				return;
			}
		}
		if (_bLogDebugOutput)
		{
			Debug.Log("Setting Ambient lighting only");
		}
	}

	public void LateUpdate()
	{
		if (!Application.isPlaying)
		{
			UpdateProbeSupport();
		}
		if (!_bIsVisible && Application.isPlaying)
		{
			if (_bLogDebugOutput)
			{
				Debug.Log("Not visible skipping probe set code");
			}
		}
		else if (!_bSampleLightProbes)
		{
			if (Time.frameCount == s_iAmbientlightLastUpdate)
			{
				return;
			}
			SphericalHarmonicsL2 ambientProbe = RenderSettings.ambientProbe;
			if (ambientProbe == default(SphericalHarmonicsL2) && _bLogDebugOutput)
			{
				Debug.Log("No ambinet light found");
			}
			_ = s_sphAmbientLightAtLastUpdate;
			if (ambientProbe == s_sphAmbientLightAtLastUpdate && s_iAmbientlightLastUpdate != 0)
			{
				if (_bLogDebugOutput)
				{
					Debug.Log("Ambient light has not changed skipping lighting update");
				}
				return;
			}
			SetGlobalAmbientSHCoefficients(ambientProbe);
			_ = s_sphAmbientLightAtLastUpdate;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					s_sphAmbientLightAtLastUpdate[i, j] = ambientProbe[i, j];
				}
			}
			s_iAmbientlightLastUpdate = Time.frameCount;
			if (_bLogDebugOutput)
			{
				Debug.Log("Setting Ambient coeficients");
			}
		}
		else if (_bIsVisible || !Application.isPlaying)
		{
			Renderer component = GetComponent<Renderer>();
			if (_mpbMaterialPropertyBlock == null)
			{
				_mpbMaterialPropertyBlock = new MaterialPropertyBlock();
			}
			component.GetPropertyBlock(_mpbMaterialPropertyBlock);
			Vector3 position = ((!(_trnOptionalFixedSamplePosition != null)) ? component.bounds.center : _trnOptionalFixedSamplePosition.transform.position);
			LightProbes.GetInterpolatedProbe(position, component, out _sphProbe);
			SetParticleProbeSHCoefficients(_sphProbe, _mpbMaterialPropertyBlock);
			component.SetPropertyBlock(_mpbMaterialPropertyBlock);
			if (_bLogDebugOutput)
			{
				Debug.Log("Setting light probe coeficients");
			}
		}
	}

	public static void SetGlobalAmbientSHCoefficients(SphericalHarmonicsL2 sphHarmonic)
	{
		InitaliseIDs();
		for (int i = 0; i < 3; i++)
		{
			Shader.SetGlobalVector(s_iParticleAmbientSHA[i], new Vector4(sphHarmonic[i, 3], sphHarmonic[i, 1], sphHarmonic[i, 2], sphHarmonic[i, 0] - sphHarmonic[i, 6]));
		}
		for (int j = 0; j < 3; j++)
		{
			Shader.SetGlobalVector(s_iParticleAmbientSHB[j], new Vector4(sphHarmonic[j, 4], sphHarmonic[j, 6], sphHarmonic[j, 5] * 3f, sphHarmonic[j, 7]));
		}
		Shader.SetGlobalVector(s_iParticleAmbientSHC, new Vector4(sphHarmonic[0, 8], sphHarmonic[2, 8], sphHarmonic[1, 8], 1f));
	}

	public static void SetParticleProbeSHCoefficients(SphericalHarmonicsL2 sphHarmonic, MaterialPropertyBlock mpbMaterialPropertyBlock)
	{
		InitaliseIDs();
		for (int i = 0; i < 3; i++)
		{
			mpbMaterialPropertyBlock.SetVector(s_iParticleProbeSHA[i], new Vector4(sphHarmonic[i, 3], sphHarmonic[i, 1], sphHarmonic[i, 2], sphHarmonic[i, 0] - sphHarmonic[i, 6]));
		}
		for (int j = 0; j < 3; j++)
		{
			mpbMaterialPropertyBlock.SetVector(s_iParticleProbeSHB[j], new Vector4(sphHarmonic[j, 4], sphHarmonic[j, 6], sphHarmonic[j, 5] * 3f, sphHarmonic[j, 7]));
		}
		mpbMaterialPropertyBlock.SetVector(s_iParticleProbeSHC, new Vector4(sphHarmonic[0, 8], sphHarmonic[2, 8], sphHarmonic[1, 8], 1f));
	}

	private static void InitaliseIDs()
	{
		if (!_bIdsSetUp)
		{
			s_iParticleAmbientSHA = new int[3]
			{
				Shader.PropertyToID("Particle_Ambient_SHAr"),
				Shader.PropertyToID("Particle_Ambient_SHAg"),
				Shader.PropertyToID("Particle_Ambient_SHAb")
			};
			s_iParticleAmbientSHB = new int[3]
			{
				Shader.PropertyToID("Particle_Ambient_SHBr"),
				Shader.PropertyToID("Particle_Ambient_SHBg"),
				Shader.PropertyToID("Particle_Ambient_SHBb")
			};
			s_iParticleAmbientSHC = Shader.PropertyToID("Particle_Ambient_SHC");
			s_iParticleProbeSHA = new int[3]
			{
				Shader.PropertyToID("Particle_Probe_SHAr"),
				Shader.PropertyToID("Particle_Probe_SHAg"),
				Shader.PropertyToID("Particle_Probe_SHAb")
			};
			s_iParticleProbeSHB = new int[3]
			{
				Shader.PropertyToID("Particle_Probe_SHBr"),
				Shader.PropertyToID("Particle_Probe_SHBg"),
				Shader.PropertyToID("Particle_Probe_SHBb")
			};
			s_iParticleProbeSHC = Shader.PropertyToID("Particle_Probe_SHC");
		}
	}
}
