using ManagementScripts;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UIScripts
{
	public class UIEgg : PoolableItem<UIEgg>
	{
		[SerializeField]
		private Image img;

		[SerializeField]
		private Rigidbody2D rb;

		[SerializeField]
		private Material eggMaterial;

		private Material mat;

		private float sizeFactor = 1f;

		private float scaleFactor = 1f;

		private Vector2 sizeBounds = Vector2.zero;

		public const float BaseRadius = 5.5f;

		private static readonly int Color1 = Shader.PropertyToID("_Color");

		private static readonly int Growing = Shader.PropertyToID("_growing");

		private static readonly int Absorbing = Shader.PropertyToID("_absorbing");

		public const float BaseAmount = 100f;

		public Vector3 pos
		{
			set
			{
				base.transform.localPosition = value;
			}
		}

		public float rotation
		{
			set
			{
				base.transform.eulerAngles = new Vector3(0f, 0f, value);
			}
		}

		public override void Initialize()
		{
			mat = new Material(eggMaterial);
			img.material = mat;
		}

		public override void Retire()
		{
			base.Retire();
			mat.SetInt(Growing, 0);
			mat.SetInt(Absorbing, 0);
		}

		public void SetGrowing(float val)
		{
			mat.SetInt(Growing, (Mathf.Abs(val) > 0f) ? 1 : 0);
			mat.SetInt(Absorbing, (val < 0f) ? 1 : 0);
		}

		public void SetColor(Color color)
		{
			mat.SetColor(Color1, color);
		}

		public void SetSize(float scale, float amount)
		{
			sizeFactor = Mathf.Sqrt(Mathf.Max(amount, 0f) / 100f);
			scaleFactor = scale;
			rb.transform.localScale = Vector3.one * scaleFactor;
			if (sizeFactor < sizeBounds.x || sizeFactor > sizeBounds.y)
			{
				SelectSprite();
			}
		}

		private void SelectSprite()
		{
			int sizeIndex = ProceduralSpriteManager.Instance.ClosestSizeIndex(sizeFactor, ProceduralSpriteManager.SizeTypes.EggSizes);
			img.sprite = ProceduralSpriteManager.Instance.RequestEggSprite(sizeIndex);
			sizeBounds = ProceduralSpriteManager.Instance.ClosestSizeBounds(sizeFactor, ProceduralSpriteManager.SizeTypes.EggSizes);
		}

		private void OnDestroy()
		{
			Object.Destroy(mat);
		}
	}
}
