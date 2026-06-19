using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[DontSave]
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class HospitalPlotFootprintVisual : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public Color InnerColor = Color.white;

			public Color EdgeColor = Color.red;

			public int PixelsPerTile = 2;

			public float OffsetY = 0.1f;

			public float DeselectedAlpha = 0.25f;

			public GameObject TilePreviewPrefab;
		}

		private readonly Config _config;

		private readonly HospitalPlot _hospitalPlot;

		private readonly GameObject _gameObject;

		private readonly Texture2D _texture;

		private Material _material;

		private float _alpha;

		public HospitalPlotFootprintVisual(Config config, HospitalPlot hospitalPlot)
		{
			_config = config;
			_hospitalPlot = hospitalPlot;
			_texture = CreateTexture(hospitalPlot.HospitalMap);
			_gameObject = Object.Instantiate(_config.TilePreviewPrefab);
			_gameObject.transform.position = new Vector3(-1f, _config.OffsetY + hospitalPlot.Definition.FootprintYOffset, -1f);
			_gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
			if (hospitalPlot.HospitalMap == null)
			{
				_gameObject.transform.localScale = Vector3.zero;
			}
			else
			{
				_gameObject.transform.localScale = new Vector3((float)hospitalPlot.HospitalMap.Width / 5f, 1f, (float)hospitalPlot.HospitalMap.Height / 5f);
			}
			_material = _gameObject.GetComponent<MeshRenderer>().material;
			_material.mainTexture = _texture;
			_material.SetTexture("_EmissionMap", _texture);
		}

		public override void Destroy()
		{
			Object.Destroy(_gameObject);
			Object.Destroy(_texture);
			base.Destroy();
		}

		private Texture2D CreateTexture(HospitalMap hospitalMap)
		{
			FloorPlan floorPlan = hospitalMap.FloorPlan;
			int num = hospitalMap.Width * _config.PixelsPerTile;
			int num2 = hospitalMap.Height * _config.PixelsPerTile;
			Texture2D texture2D = new Texture2D(num, num2, TextureFormat.RGBA32, mipChain: false);
			for (int i = 0; i < floorPlan.Height(); i++)
			{
				for (int j = 0; j < floorPlan.Width(); j++)
				{
					int num3 = j * _config.PixelsPerTile;
					int num4 = i * _config.PixelsPerTile;
					Color color = (floorPlan[j, i] ? _config.InnerColor : Color.clear);
					for (int k = 0; k < _config.PixelsPerTile; k++)
					{
						for (int l = 0; l < _config.PixelsPerTile; l++)
						{
							texture2D.SetPixel(num3 + l, num4 + k, color);
						}
					}
				}
			}
			Color32[] pixels = texture2D.GetPixels32();
			for (int m = 1; m < num2 - 1; m++)
			{
				for (int n = 1; n < num - 1; n++)
				{
					int num5 = n + m * num;
					Color32 color2 = pixels[num5];
					if (color2.a != 0)
					{
						if (pixels[num5 + 1].a == 0)
						{
							color2 = _config.EdgeColor;
						}
						else if (pixels[num5 - 1].a == 0)
						{
							color2 = _config.EdgeColor;
						}
						else if (pixels[num5 - num].a == 0)
						{
							color2 = _config.EdgeColor;
						}
						else if (pixels[num5 + num].a == 0)
						{
							color2 = _config.EdgeColor;
						}
						else if (pixels[num5 + 1 + num].a == 0)
						{
							color2 = _config.EdgeColor;
						}
						else if (pixels[num5 - 1 + num].a == 0)
						{
							color2 = _config.EdgeColor;
						}
						else if (pixels[num5 + 1 - num].a == 0)
						{
							color2 = _config.EdgeColor;
						}
						else if (pixels[num5 - 1 - num].a == 0)
						{
							color2 = _config.EdgeColor;
						}
						pixels[num5] = color2;
					}
				}
			}
			texture2D.SetPixels32(pixels);
			texture2D.Apply();
			return texture2D;
		}

		public void SetSelected(HospitalPlot plot)
		{
		}

		public void Update(HospitalPlot selectedPlot, bool highlightingAmbulanceBay)
		{
			if ((_hospitalPlot.Built && !highlightingAmbulanceBay) || _hospitalPlot.IsHidden())
			{
				GameObjectUtils.SetActive(_gameObject, isActive: false);
				return;
			}
			float num = 0f;
			if (selectedPlot != null)
			{
				bool num2 = selectedPlot == _hospitalPlot;
				float num3 = _config.DeselectedAlpha;
				if (highlightingAmbulanceBay && _hospitalPlot.Definition.BuiltRoomDefinition == null)
				{
					num3 = 0f;
				}
				num = (num2 ? 1f : num3);
				if (highlightingAmbulanceBay && _hospitalPlot.ContainsAmbulances())
				{
					num = 0f;
				}
			}
			if (num < _alpha)
			{
				_alpha = Mathf.Max(_alpha - 2f * GameTime.unscaledDeltaTime, num);
			}
			else
			{
				_alpha = Mathf.Min(_alpha + 3f * GameTime.unscaledDeltaTime, num);
			}
			_material.color = new Color(1f, 1f, 1f, _alpha);
			GameObjectUtils.SetActive(_gameObject, isActive: true);
		}
	}
}
