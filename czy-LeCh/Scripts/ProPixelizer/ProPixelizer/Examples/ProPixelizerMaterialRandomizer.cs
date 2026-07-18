using System.Collections.Generic;
using UnityEngine;

namespace ProPixelizer.Examples
{
	public class ProPixelizerMaterialRandomizer : MonoBehaviour
	{
		public List<Texture2D> PaletteLUTs;

		public List<Texture2D> LightRamps;

		public List<Color> OutlineColors;

		[Tooltip("Interval between material randomisation, seconds.")]
		public float Interval = 5f;

		private float _Timer;

		public ProPixelizerMaterialRandomizer()
		{
			PaletteLUTs = new List<Texture2D>();
			LightRamps = new List<Texture2D>();
		}

		private void Start()
		{
			_Timer = Interval;
		}

		private void Update()
		{
			_Timer -= Time.deltaTime;
			if (_Timer < 0f)
			{
				_Timer = Interval;
				Randomize();
			}
		}

		public void Randomize()
		{
			Material material = GetComponent<MeshRenderer>().material;
			Texture2D value = PaletteLUTs[Random.Range(0, PaletteLUTs.Count)];
			Texture2D value2 = LightRamps[Random.Range(0, LightRamps.Count)];
			material.SetTexture("_PaletteLUT", value);
			material.SetTexture("_LightingRamp", value2);
			int num = Random.Range(2, 6);
			material.SetFloat("_PixelSize", num);
			Color value3 = OutlineColors[Random.Range(0, OutlineColors.Count)];
			Color value4 = OutlineColors[Random.Range(0, OutlineColors.Count)];
			material.SetColor("_OutlineColor", value3);
			material.SetColor("_EdgeHighlightColor", value4);
		}
	}
}
