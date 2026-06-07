using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class SpriteNo : MonoBehaviour
	{
		public enum LayoutType
		{
			Center = 0,
			Left = 1,
			Right = 2
		}

		[Serializable]
		private struct DamageScale
		{
			[Label("ダメージ量")]
			[Tooltip("このダメージ以下ならこの大きさが適用される")]
			public int damage;

			[Label("適用スケール")]
			public float scaleFactor;
		}

		public enum eDamageType
		{
			None = 0,
			Fire = 1,
			Bleeding = 2,
			Shield = 3
		}

		[Header("テキスト設定")]
		[SerializeField]
		private string _text;

		[SerializeField]
		private eDamageType _damageType;

		[SerializeField]
		[HideInInspector]
		protected List<SpriteRenderer> _componentList;

		private int _activeComponentCount;

		[SerializeField]
		private LayoutType _layoutType;

		[SerializeField]
		private float _textSpan;

		[SerializeField]
		private List<Sprite> _normalspriteList;

		[SerializeField]
		private List<Sprite> _firespriteList;

		[SerializeField]
		private List<Sprite> _bleedingspriteList;

		[SerializeField]
		private List<Sprite> _shieldspriteList;

		[SerializeField]
		private string _sortingLayerName;

		[SerializeField]
		private int _sortingOrder;

		[SerializeField]
		private DamageScale[] damageScales;

		[Header("アニメーション設定")]
		[Label("跳ねる量")]
		[SerializeField]
		private float upValue;

		[Label("アニメーション時間")]
		[Tooltip("半分で折り返し")]
		[SerializeField]
		private float duration;

		private List<Sprite> _cachedSpriteList;

		private int _cachedDamageType;

		public int Length => 0;

		protected void InitComponents()
		{
		}

		protected void InitComponent(SpriteRenderer spriteRenderer)
		{
		}

		private void UpdateComponents()
		{
		}

		private void UpdateSprites()
		{
		}

		protected void UpdateComponent(SpriteRenderer spriteRenderer, Sprite sprite)
		{
		}

		private void UpdatePositions()
		{
		}

		public void SetNo(int no, eDamageType damagetype = eDamageType.None)
		{
		}

		public void SetNo(int no, string textFormat, eDamageType damagetype = eDamageType.None)
		{
		}

		private void ApplyDamageScale(int damage)
		{
		}

		private void SetText(string text, bool isForcibly = false, eDamageType damagetype = eDamageType.None)
		{
		}

		private void EnsureComponentCount(int requiredCount)
		{
		}

		private void CreateNewComponent()
		{
		}

		private void SetComponentsActive(int activeCount)
		{
		}

		public List<Sprite> GetSpriteListCached(int damageTypeNum)
		{
			return null;
		}

		public List<Sprite> GetSpriteList(int damageTypeNum)
		{
			return null;
		}

		private void MoveAnimation()
		{
		}
	}
}
