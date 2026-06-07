using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Receivables;
using Sirenix.OdinInspector;
using Unity.Collections;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.MiniMap
{
	public class Minimap : BaseSingleton<Minimap>
	{
		public MinimapUIObject Prefab;

		public float Size;

		public float MaxWorldSize = 1200f;

		private Texture2D _fogTexture;

		public bool IsPlanet = true;

		[ShowIf("IsPlanet", true)]
		public UITexture FogTexture;

		[ShowIf("IsPlanet", true)]
		public MinimapPlanet Planet;

		[HideIf("IsPlanet", true)]
		public MinimapObject NimbatusWorldObject;

		[HideIf("IsPlanet", true)]
		public MeshRenderer NimbatusWorldRenderer;

		private MinimapUIObject _nimbatusMapObject;

		private static List<MinimapUIObject> _mapObjects;

		[HideInInspector]
		public Vector2 WorldCenter = Vector2.zero;

		protected override void Awake()
		{
			base.Awake();
			_mapObjects = new List<MinimapUIObject>();
			if (IsPlanet)
			{
				int num = (int)Size + 1;
				_fogTexture = new Texture2D(num, num);
				_fogTexture.Resize(num, num);
				_fogTexture.filterMode = FilterMode.Trilinear;
				_fogTexture.wrapMode = TextureWrapMode.Clamp;
				FogTexture.mainTexture = _fogTexture;
				Planet.Init(this);
				StartCoroutine(UpdateFogTexture());
			}
		}

		public void Register(MinimapObject o)
		{
			MinimapUIObject minimapUIObject = Object.Instantiate(Prefab);
			minimapUIObject.Init(o);
			minimapUIObject.transform.parent = base.transform;
			minimapUIObject.transform.localScale = Vector3.one;
			_mapObjects.Add(minimapUIObject);
			if (!IsPlanet && o == NimbatusWorldObject)
			{
				_nimbatusMapObject = minimapUIObject;
			}
		}

		public void Unregister(MinimapObject o)
		{
			MinimapUIObject minimapUIObject = _mapObjects.FirstOrDefault((MinimapUIObject m) => m.MinimapObject == o);
			if (minimapUIObject != null)
			{
				_mapObjects.Remove(minimapUIObject);
				Object.Destroy(minimapUIObject.gameObject);
			}
		}

		public void Update()
		{
			if (IsPlanet)
			{
				Planet.UpdateRadius(this);
			}
			else if (_mapObjects.Count > 0)
			{
				Vector2 zero = Vector2.zero;
				for (int i = 0; i < _mapObjects.Count; i++)
				{
					zero += (Vector2)_mapObjects[i].MinimapObject.transform.position;
				}
				WorldCenter = zero / _mapObjects.Count;
				if (_nimbatusMapObject != null)
				{
					float num = NimbatusWorldRenderer.bounds.size.x * 2f * (Size / MaxWorldSize);
					_nimbatusMapObject.Texture.SetDimensions((int)num, (int)num);
				}
			}
			foreach (MinimapUIObject mapObject in _mapObjects)
			{
				mapObject.transform.localPosition = mapObject.CalculatePosition(this);
			}
		}

		private IEnumerator UpdateFogTexture()
		{
			int res = (int)Size + 1;
			NativeArray<Color32> textureData = _fogTexture.GetRawTextureData<Color32>();
			bool flag = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(EMothershipUpgradeType.Sensors) >= 1 || !ReceivableHelper.UpgradeAllowed(EMothershipUpgradeType.Sensors);
			Color color = (flag ? Color.clear : Color.white);
			for (int i = 0; i < res; i++)
			{
				for (int j = 0; j < res; j++)
				{
					textureData[j * res + i] = color;
				}
			}
			_fogTexture.Apply();
			if (flag)
			{
				yield break;
			}
			while (true)
			{
				textureData = _fogTexture.GetRawTextureData<Color32>();
				List<MinimapUIObject> mo = _mapObjects.ToList();
				for (int k = 0; k < mo.Count; k++)
				{
					if (mo[k] == null || mo[k].MinimapObject == null)
					{
						_mapObjects.Remove(mo[k]);
						continue;
					}
					Vector3 localPosition = mo[k].transform.localPosition;
					Vector2 a = new Vector2(localPosition.x + Size / 2f, localPosition.y + Size / 2f);
					for (int l = -30; l < 30; l++)
					{
						for (int m = -30; m < 30; m++)
						{
							int num = Mathf.Clamp((int)a.x + l, 0, res - 1);
							int num2 = Mathf.Clamp((int)a.y + m, 0, res - 1);
							if (Vector2.Distance(a, new Vector2(num, num2)) < 29f)
							{
								textureData[num2 * res + num] = new Color(0f, 0f, 0f, 0f);
							}
						}
					}
					yield return true;
				}
				_fogTexture.Apply();
				yield return new WaitForSeconds(0.1f);
			}
		}

		public float GetUncoverPercentage()
		{
			int num = (int)Size + 1;
			float num2 = Mathf.Pow(num - 1, 2f);
			int num3 = 0;
			NativeArray<Color32> rawTextureData = _fogTexture.GetRawTextureData<Color32>();
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num; j++)
				{
					if ((float)(int)rawTextureData[j * num + i].a < 0.5f)
					{
						num3++;
					}
				}
			}
			return (float)num3 / num2 * 100f;
		}
	}
}
