using UnityEngine;

namespace Assets.Scripts.Flight.GameView.Planet
{
	public class CloudsScript : MonoBehaviour
	{
		private class PerlinScriptCSharp
		{
			private float[] GRADIENT3 = new float[48]
			{
				1f, 1f, 0f, -1f, 1f, 0f, 1f, -1f, 0f, -1f,
				-1f, 0f, 1f, 0f, 1f, -1f, 0f, 1f, 1f, 0f,
				-1f, -1f, 0f, -1f, 0f, 1f, 1f, 0f, -1f, 1f,
				0f, 1f, -1f, 0f, -1f, -1f, 1f, 1f, 0f, 0f,
				-1f, 1f, -1f, 1f, 0f, 0f, -1f, -1f
			};

			private Texture2D m_gradient3D;

			private int[] m_perm = new int[512];

			private Texture2D m_permTable2D;

			private int SIZE = 256;

			public PerlinScriptCSharp(int seed)
			{
				m_permTable2D = LoadPermTable2D();
				m_gradient3D = LoadGradient3D();
				Random.InitState(seed);
				int i;
				for (i = 0; i < SIZE; i++)
				{
					m_perm[i] = i;
				}
				while (--i != 0)
				{
					int num = m_perm[i];
					int num2 = Random.Range(0, SIZE);
					m_perm[i] = m_perm[num2];
					m_perm[num2] = num;
				}
				for (i = 0; i < SIZE; i++)
				{
					m_perm[SIZE + i] = m_perm[i];
				}
			}

			public Texture2D LoadGradient3D()
			{
				m_gradient3D = new Texture2D(SIZE, 1, TextureFormat.RGB24, mipChain: false, linear: true);
				m_gradient3D.filterMode = FilterMode.Point;
				m_gradient3D.wrapMode = TextureWrapMode.Repeat;
				for (int i = 0; i < SIZE; i++)
				{
					int num = m_perm[i] % 16;
					float r = (GRADIENT3[num * 3] + 1f) * 0.5f;
					float g = (GRADIENT3[num * 3 + 1] + 1f) * 0.5f;
					float b = (GRADIENT3[num * 3 + 2] + 1f) * 0.5f;
					m_gradient3D.SetPixel(i, 0, new Color(r, g, b, 1f));
				}
				m_gradient3D.Apply();
				return m_gradient3D;
			}

			public Texture2D LoadPermTable2D()
			{
				m_permTable2D = new Texture2D(SIZE, SIZE, TextureFormat.ARGB32, mipChain: false, linear: true);
				m_permTable2D.filterMode = FilterMode.Point;
				m_permTable2D.wrapMode = TextureWrapMode.Repeat;
				for (int i = 0; i < SIZE; i++)
				{
					for (int j = 0; j < SIZE; j++)
					{
						int num = m_perm[i] + j;
						int num2 = m_perm[num];
						int num3 = m_perm[num + 1];
						int num4 = m_perm[i + 1] + j;
						int num5 = m_perm[num4];
						int num6 = m_perm[num4 + 1];
						m_permTable2D.SetPixel(i, j, new Color((float)num2 / 255f, (float)num3 / 255f, (float)num5 / 255f, (float)num6 / 255f));
					}
				}
				m_permTable2D.Apply();
				return m_permTable2D;
			}

			public void LoadResourcesFor3DNoise()
			{
				LoadPermTable2D();
				LoadGradient3D();
			}
		}

		private bool _cloudMorph;

		[SerializeField]
		private float _cloudMovementSpeed = 0.1f;

		[SerializeField]
		private float _cloudRotationSpeed = 0.2f;

		private Material _material;

		public void UpdateLight(Vector3 lightDirection)
		{
			_material.SetVector("_LightDirection", lightDirection);
		}

		protected virtual void Awake()
		{
			float value = 3f;
			float value2 = 3f;
			PerlinScriptCSharp perlinScriptCSharp = new PerlinScriptCSharp(1);
			perlinScriptCSharp.LoadResourcesFor3DNoise();
			_material = GetComponent<Renderer>().material;
			_material.SetFloat("_isClouds", 1f);
			_material.SetTexture("_CloudPermTable2D", perlinScriptCSharp.LoadPermTable2D());
			_material.SetTexture("_CloudGradient3D", perlinScriptCSharp.LoadGradient3D());
			_material.SetFloat("_CloudFrequency", value);
			_material.SetFloat("_CloudLacunarity", value2);
			_cloudMorph = true;
		}

		protected virtual void Update()
		{
			float num = _material.GetFloat("_CloudFrequency");
			float num2 = _material.GetFloat("_CloudRotation");
			float num3 = (float)FlightSceneScript.Instance.TimeManager.CurrentMode.TimeMultiplier * Time.deltaTime;
			num2 += _cloudRotationSpeed / 1000f * num3;
			_material.SetFloat("_CloudRotation", num2);
			if (num < 5.5f && _cloudMorph)
			{
				num += _cloudMovementSpeed / 1000f * num3;
				_material.SetFloat("_CloudFrequency", num);
				if (num > 5f)
				{
					_cloudMorph = false;
				}
			}
			else if (num > 1.5f && !_cloudMorph)
			{
				num -= _cloudMovementSpeed / 1000f * num3;
				_material.SetFloat("_CloudFrequency", num);
				if (num < 2f)
				{
					_cloudMorph = true;
				}
			}
		}
	}
}
