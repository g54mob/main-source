using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class SelectionMap_CityStarsVFX : MonoBehaviour
	{
		[SerializeField]
		private GameObject _socle;

		[SerializeField]
		private ParticleSystem _particleSystem;

		[SerializeField]
		private float _timeBeforehardMove;

		[SerializeField]
		private float _timeBeforeFinish;

		private MapSelection _mapSelection;

		private Animator _animator;

		private MeshRenderer _socleMR;

		private List<Material> _allmaterial;

		private Material _glowMaterial;

		private Color baseColor;

		public float maxIntensity = 5f;

		public float pulseSpeed = 2f;

		private float intensity;

		private bool increasing = true;

		private void Start()
		{
			_allmaterial = new List<Material>();
			_animator = GetComponent<Animator>();
			_socleMR = _socle.GetComponent<MeshRenderer>();
			_mapSelection = GetComponent<MapSelection>();
			if (_socleMR != null)
			{
				_allmaterial.AddRange(_socleMR.materials);
				_glowMaterial = _socleMR.GetComponent<MeshRenderer>().material;
			}
			baseColor = _glowMaterial.GetColor("_Color");
			for (int i = 0; i < _allmaterial.Count; i++)
			{
				Material material = _allmaterial[i];
				if (material.HasProperty("_Color"))
				{
					Color value = baseColor * 0f;
					material.SetColor("_Color", value);
				}
			}
			_socleMR.enabled = false;
		}

		[Button(null, EButtonEnableMode.Always)]
		public void Launchfullanim()
		{
			StartCoroutine(ParticuleLaunch());
		}

		private IEnumerator ParticuleLaunch()
		{
			_mapSelection.Animgoing(Anim: false);
			yield return new WaitForSecondsRealtime(0.5f);
			_particleSystem.Play();
			_animator.SetTrigger("StarsActivation");
			yield return new WaitForSecondsRealtime(_timeBeforehardMove);
			_animator.SetTrigger("HardStars");
			yield return new WaitForSecondsRealtime(_timeBeforeFinish);
			_animator.SetTrigger("FinishsStars");
			yield return new WaitForSecondsRealtime(0.2f);
		}

		private IEnumerator Activecolor()
		{
			_socleMR.enabled = true;
			for (int i = 0; i < _allmaterial.Count; i++)
			{
				Material material = _allmaterial[i];
				if (material.HasProperty("_Color"))
				{
					Color value = baseColor * 0f;
					material.SetColor("_Color", value);
				}
			}
			bool NotFinish = false;
			while (!NotFinish)
			{
				if (increasing)
				{
					intensity += Time.deltaTime * pulseSpeed;
					if (intensity >= maxIntensity)
					{
						intensity = maxIntensity;
						increasing = false;
					}
				}
				else
				{
					intensity -= Time.deltaTime * pulseSpeed;
					if (intensity <= 0f)
					{
						intensity = 0f;
						increasing = true;
						NotFinish = true;
					}
				}
				for (int j = 0; j < _allmaterial.Count; j++)
				{
					Material material2 = _allmaterial[j];
					if (material2.HasProperty("_Color"))
					{
						Color value2 = baseColor * intensity;
						material2.SetColor("_Color", value2);
					}
				}
				yield return null;
			}
			_socleMR.enabled = false;
			Debug.Log("finish");
			_mapSelection.Animgoing(Anim: true);
			yield return null;
		}
	}
}
