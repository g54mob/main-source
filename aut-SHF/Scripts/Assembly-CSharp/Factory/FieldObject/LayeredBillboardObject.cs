using System.Collections.Generic;
using Libs;
using UnityEngine;

namespace Factory.FieldObject
{
	public class LayeredBillboardObject : MonoBehaviour
	{
		public SpriteAnimeCtrl spriteAnimeCtrl;

		private SpriteAnimeCtrl _grandChildSpriteAnimeCtrl;

		public BillboardObjectAttachedTile billboardObjectAttachedTile;

		private readonly Vector3 _p;

		private readonly float _da;

		private readonly float _dl;

		private void InitComponent()
		{
		}

		private void Awake()
		{
		}

		public void Init(LayeredBillboardObjectInit init, Dictionary<string, NamedSprites> spriteDic)
		{
		}

		public void SetView(bool view)
		{
		}

		public void PlayAnimation(bool play, string partsName, int? manualIndex = null, bool? loopOnce = null, float? specificRate = null, bool keepIndex = false)
		{
		}

		public void PlayMinionAnimation(bool arriveMinion, bool leaveMinion)
		{
		}

		public SpriteAnimeCtrl GetGrandChildSpriteAnimeCtrl(string objectName)
		{
			return null;
		}
	}
}
