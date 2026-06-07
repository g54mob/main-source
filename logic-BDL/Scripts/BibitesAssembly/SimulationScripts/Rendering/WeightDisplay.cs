using ManagementScripts;
using SimulationScripts.BibiteScripts;
using UIScripts.InfoHandles;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace SimulationScripts.Rendering
{
	public class WeightDisplay : PoolableDictItem<Transform, WeightDisplay>
	{
		private Transform target;

		[Header("Properties")]
		public Vector3 offset = new Vector3(-15f, 15f);

		[Header("References")]
		public RectTransform pointer;

		public FloatValueTextHandle weight;

		public FloatValueTextHandle weightPortion;

		public CanvasGroup canvasGroup;

		public Image targetIndicator;

		public Sprite bibiteSprite;

		private Sprite plantSprite;

		private Sprite meatSprite;

		private Sprite eggSprite;

		public const float MinThresholdForVisibility = 0.05f;

		public override void Initialize()
		{
			base.Initialize();
			plantSprite = ProceduralSpriteManager.Instance.RequestPelletSpriteOfMaterial(MatterMaterialManager.Plant, 0);
			meatSprite = ProceduralSpriteManager.Instance.RequestPelletSpriteOfMaterial(MatterMaterialManager.Meat, 0);
			eggSprite = ProceduralSpriteManager.Instance.RequestEggSprite(0);
		}

		public override void AssignKey(Transform newTarget)
		{
			target = newTarget;
			base.transform.position = target.position + offset;
		}

		public void SetTargetType(TargetType type = TargetType.None)
		{
			switch (type)
			{
			case TargetType.Bibite:
				targetIndicator.sprite = bibiteSprite;
				SetOffset(target.localScale.x * 2.5f * 5f);
				break;
			case TargetType.Plant:
				targetIndicator.sprite = plantSprite;
				SetOffset(target.localScale.x * 2f * 2.5f);
				break;
			case TargetType.Meat:
				targetIndicator.sprite = meatSprite;
				SetOffset(target.localScale.x * 2f * 2.5f);
				break;
			case TargetType.Egg:
				targetIndicator.sprite = eggSprite;
				SetOffset(target.localScale.x * 2.5f * 5f);
				break;
			}
		}

		public void SetOffset(float value)
		{
			offset = Mathf.Max(value, 10f) * new Vector3(-1f, 1f);
			pointer.sizeDelta = new Vector2(offset.magnitude, 0.5f);
		}

		public void UpdateWeights(float flatWeight, float relativeWeight, float weightToMax)
		{
			if (SetVisibility(weightToMax))
			{
				weight.UpdateValue(flatWeight);
				weightPortion.UpdateValue(relativeWeight);
			}
		}

		private bool SetVisibility(float value)
		{
			bool flag = value > 0.05f;
			base.gameObject.SetActive(flag);
			if (!flag)
			{
				return false;
			}
			canvasGroup.alpha = Mathf.Sqrt(value);
			return true;
		}

		private void Update()
		{
			if (target == null)
			{
				ReturnToPool();
			}
			else
			{
				base.transform.position = target.position + offset;
			}
		}
	}
}
