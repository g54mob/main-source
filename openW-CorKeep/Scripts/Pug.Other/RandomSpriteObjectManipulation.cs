using System.Collections;
using Pug.Sprite;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(SpriteObject))]
public class RandomSpriteObjectManipulation : MonoBehaviour
{
	[SerializeField]
	private SpriteObject[] m_subObjects;

	[SerializeField]
	private bool m_randomlyFlipX = true;

	[SerializeField]
	private bool m_shuffleZ;

	[SerializeField]
	private bool m_shuffleY;

	[SerializeField]
	private bool m_randomSpriteVariation = true;

	private SpriteObject m_spriteObject;

	private SpriteObject[] m_allSpriteObjects;

	private Vector3[] m_originalPositions;

	private Vector3[] m_originalScales;

	private void Awake()
	{
		m_spriteObject = GetComponent<SpriteObject>();
		if (m_spriteObject == null)
		{
			Debug.LogError("RandomStaticSpriteObjectVariant without SpriteObject");
		}
		else
		{
			if (m_spriteObject.asset == null)
			{
				return;
			}
			int num = 1 + ((m_subObjects != null) ? m_subObjects.Length : 0);
			m_allSpriteObjects = new SpriteObject[num];
			m_allSpriteObjects[0] = m_spriteObject;
			if (m_subObjects != null)
			{
				for (int i = 0; i < m_subObjects.Length; i++)
				{
					m_allSpriteObjects[i + 1] = m_subObjects[i];
				}
			}
			m_originalPositions = new Vector3[num];
			m_originalScales = new Vector3[num];
			for (int j = 0; j < m_allSpriteObjects.Length; j++)
			{
				m_originalPositions[j] = m_allSpriteObjects[j].transform.localPosition;
				m_originalScales[j] = m_allSpriteObjects[j].transform.localScale;
			}
		}
	}

	private void OnEnable()
	{
		if (m_spriteObject != null)
		{
			StartCoroutine(EnableRandomVariation());
		}
	}

	public IEnumerator EnableRandomVariation()
	{
		SpriteAsset asset = m_spriteObject.asset;
		if (asset == null)
		{
			yield break;
		}
		yield return null;
		Unity.Mathematics.Random random = Unity.Mathematics.Random.CreateFromIndex(math.hash(EntityMonoBehaviour.ToWorldFromRender(base.transform.position).RoundToInt().ToInt2()));
		if (m_randomSpriteVariation && asset.staticVariantCount >= 1)
		{
			int variantByIndex = random.NextInt(0, 1 + asset.staticVariantCount);
			for (int i = 0; i < m_allSpriteObjects.Length; i++)
			{
				m_allSpriteObjects[i].SetVariantByIndex(variantByIndex);
			}
		}
		if (m_randomlyFlipX)
		{
			bool flag = random.NextBool();
			for (int j = 0; j < m_allSpriteObjects.Length; j++)
			{
				SpriteObject obj = m_allSpriteObjects[j];
				Vector3 localScale = m_originalScales[j];
				localScale.x *= ((!flag) ? 1 : (-1));
				obj.transform.localScale = localScale;
			}
		}
		if (m_shuffleZ)
		{
			float num = random.NextFloat(-0.03f, 0.03f);
			for (int k = 0; k < m_allSpriteObjects.Length; k++)
			{
				SpriteObject obj2 = m_allSpriteObjects[k];
				Vector3 localPosition = m_originalPositions[k];
				localPosition.z += num;
				obj2.transform.localPosition = localPosition;
			}
		}
		if (m_shuffleY)
		{
			float num2 = random.NextFloat(-0.03f, 0.03f);
			for (int l = 0; l < m_allSpriteObjects.Length; l++)
			{
				SpriteObject obj3 = m_allSpriteObjects[l];
				Vector3 localPosition2 = m_originalPositions[l];
				localPosition2.y += num2;
				obj3.transform.localPosition = localPosition2;
			}
		}
	}
}
