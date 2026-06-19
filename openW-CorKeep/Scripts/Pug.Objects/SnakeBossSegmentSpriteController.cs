using System;
using Pug.Sprite;
using UnityEngine;

[ExecuteInEditMode]
public class SnakeBossSegmentSpriteController : MonoBehaviour
{
	[Serializable]
	public enum SpriteAngles
	{
		_90 = 90,
		_180 = 180
	}

	[Serializable]
	public class DirectionalVariant
	{
		public string name;

		public GameObject activeObject;
	}

	[SerializeField]
	private SpriteAngles m_spriteAngles = SpriteAngles._90;

	[Range(-180f, 180f)]
	public float m_clockwiseAngle;

	[SerializeField]
	private DirectionalVariant[] m_directionalVariants = new DirectionalVariant[6]
	{
		new DirectionalVariant
		{
			name = "Default"
		},
		new DirectionalVariant
		{
			name = "18"
		},
		new DirectionalVariant
		{
			name = "36"
		},
		new DirectionalVariant
		{
			name = "54"
		},
		new DirectionalVariant
		{
			name = "72"
		},
		new DirectionalVariant
		{
			name = "90"
		}
	};

	public SpriteObject spriteObject;

	private int[] m_directions;

	private GameObject[] m_activeObjects;

	private GameObject m_prevActiveObject;

	private int[] m_remapArray;

	private bool m_initialized;

	private int m_virtualDirectionCount;

	private int m_virtualIndex;

	private int m_prevVirtualIndex;

	[SerializeField]
	private bool m_debugChildFlipping;

	public float clockwiseAngle
	{
		get
		{
			return m_clockwiseAngle;
		}
		set
		{
			m_clockwiseAngle = value;
			UpdateAngle();
		}
	}

	public GameObject activeDirectionalObject { get; private set; }

	public SpriteAngles spriteAngles => m_spriteAngles;

	private void Awake()
	{
		spriteObject = GetComponent<SpriteObject>();
		if (!m_initialized)
		{
			Initialize();
		}
	}

	private void OnEnable()
	{
		m_prevVirtualIndex = -1;
	}

	private float nfmod(float a, float b)
	{
		return a - b * Mathf.Floor(a / b);
	}

	private void Initialize()
	{
		m_directions = new int[m_directionalVariants.Length];
		m_activeObjects = new GameObject[m_directionalVariants.Length];
		for (int i = 0; i < m_directionalVariants.Length; i++)
		{
			m_directions[i] = SpriteAsset.StringToHash(m_directionalVariants[i].name);
			m_activeObjects[i] = m_directionalVariants[i].activeObject;
		}
		m_virtualDirectionCount = (m_directions.Length - 1) * 4;
		m_remapArray = new int[m_virtualDirectionCount];
		int num = 0;
		for (int j = 0; j < m_directions.Length; j++)
		{
			m_remapArray[num++] = j;
		}
		for (int num2 = m_directions.Length - 2; num2 >= 0; num2--)
		{
			m_remapArray[num++] = num2;
		}
		for (int k = 1; k < m_directions.Length; k++)
		{
			m_remapArray[num++] = k;
		}
		for (int num3 = m_directions.Length - 2; num3 > 0; num3--)
		{
			m_remapArray[num++] = num3;
		}
		m_initialized = true;
	}

	public bool ShouldFlipChildren()
	{
		if (spriteAngles == SpriteAngles._90)
		{
			return m_virtualIndex >= m_virtualDirectionCount / 2;
		}
		return base.transform.localScale.x < 0f;
	}

	private void OnDrawGizmos()
	{
		if (m_debugChildFlipping)
		{
			bool flag = ShouldFlipChildren();
			Vector3 position = activeDirectionalObject.transform.GetChild(flag ? 1 : 0).position;
			Vector3 position2 = activeDirectionalObject.transform.GetChild((!flag) ? 1 : 0).position;
			Gizmos.color = Color.red;
			Gizmos.DrawWireCube(position, Vector3.one * 0.25f);
			Gizmos.color = Color.green;
			Gizmos.DrawWireCube(position2, Vector3.one * 0.25f);
		}
	}

	private void UpdateAngle()
	{
		if (!m_initialized)
		{
			Initialize();
		}
		float num = nfmod(m_clockwiseAngle, 360f);
		if (m_spriteAngles == SpriteAngles._180)
		{
			num /= 2f;
		}
		m_virtualIndex = Mathf.Clamp(Mathf.FloorToInt(nfmod(num, 360f) / 360f * (float)m_virtualDirectionCount), 0, m_virtualDirectionCount - 1);
		if (m_virtualIndex == m_prevVirtualIndex)
		{
			return;
		}
		m_prevVirtualIndex = m_virtualIndex;
		if (m_debugChildFlipping)
		{
			Debug.Log("Virtual index: " + m_virtualIndex + " out of " + m_remapArray.Length);
		}
		int num2 = m_remapArray[m_virtualIndex];
		int variant = m_directions[num2];
		spriteObject.SetVariant(variant);
		activeDirectionalObject = m_activeObjects[num2];
		if (activeDirectionalObject != m_prevActiveObject)
		{
			if (m_prevActiveObject != null)
			{
				m_prevActiveObject.SetActive(value: false);
			}
			if (activeDirectionalObject != null)
			{
				activeDirectionalObject.SetActive(value: true);
			}
		}
		m_prevActiveObject = activeDirectionalObject;
		bool flag = (num > 90f && num < 180f) || (num > 270f && num < 360f);
		base.transform.localScale = new Vector3((!flag) ? 1 : (-1), 1f, 1f);
	}

	private void OnValidate()
	{
		if (!Application.isPlaying)
		{
			spriteObject = GetComponent<SpriteObject>();
			Initialize();
			UpdateAngle();
		}
	}
}
