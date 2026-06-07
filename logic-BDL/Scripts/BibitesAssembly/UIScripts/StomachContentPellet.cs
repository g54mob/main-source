using ManagementScripts;
using SimulationScripts;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UIScripts
{
	public class StomachContentPellet : PoolableItem<StomachContentPellet>
	{
		[SerializeField]
		private Image img;

		[SerializeField]
		private Rigidbody2D rb;

		public MatterMaterial material;

		public float amount;

		private float scaleFactor;

		private float sizeFactor;

		private Vector2 sizeBounds;

		public float radius => 10f * scaleFactor;

		public void InitPellet(Vector3 initialPos, float initialAmount, float initialScale, MatterMaterial mat)
		{
			rb.transform.localPosition = initialPos;
			amount = initialAmount;
			scaleFactor = initialScale;
			material = mat;
			base.transform.localScale = Vector3.one * scaleFactor;
			SelectSprite();
		}

		public float ChangeAmount(float change)
		{
			float num = amount;
			amount += change;
			if (amount <= 0f)
			{
				ReturnToPoolDelayed();
				return 0f - num;
			}
			scaleFactor *= Mathf.Sqrt(amount / num);
			sizeFactor = Mathf.Sqrt(amount / 20f);
			base.transform.localScale = Vector3.one * scaleFactor;
			if (sizeFactor < sizeBounds.x || sizeFactor > sizeBounds.y)
			{
				SelectSprite();
			}
			return change;
		}

		public void ScaleSpeed(float factor)
		{
			rb.linearVelocity *= factor;
		}

		public void Move(Vector2 move)
		{
			rb.position += move;
		}

		public void ApplyForce(Vector2 force, float torque = 0f)
		{
			rb.AddForce(force / Time.timeScale, ForceMode2D.Force);
			rb.AddTorque(torque / Time.timeScale, ForceMode2D.Force);
		}

		private void SelectSprite()
		{
			int sizeIndex = ProceduralSpriteManager.Instance.ClosestSizeIndex(sizeFactor, ProceduralSpriteManager.SizeTypes.PelletSizes);
			img.sprite = ProceduralSpriteManager.Instance.RequestPelletSpriteOfMaterial(material, sizeIndex);
			sizeBounds = ProceduralSpriteManager.Instance.ClosestSizeBounds(sizeFactor, ProceduralSpriteManager.SizeTypes.PelletSizes);
		}
	}
}
