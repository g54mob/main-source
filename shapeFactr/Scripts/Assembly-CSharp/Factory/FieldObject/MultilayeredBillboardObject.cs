using System.Collections.Generic;
using Libs;
using TMPro;
using UnityEngine;

namespace Factory.FieldObject
{
	public class MultilayeredBillboardObject : MonoBehaviour
	{
		public LayeredBillboardObject[] billboards;

		public LayeredBillboardObject[] signboards;

		public NamedSprites[] minionAdds;

		public NamedSprites[] eliteMinionAdds;

		[Tooltip("アニメーション間隔の調整（秒）")]
		public float minionAddAnimeStep;

		public Sprite resourceCount;

		public TMP_Text countText;

		private Vector2 _signOffset;

		private bool _multiMinion;

		private bool _counter;

		public void Init(LayeredBillboardObjectInit[] inits, Dictionary<string, NamedSprites> spriteDic, Vector2 signOffset, bool signMultiMinion, bool signCounter)
		{
		}

		public void SetViewBillboard(bool view)
		{
		}

		public void SetBillboardOffset(Vector2 billboardOffsetXY, int layer = 0)
		{
		}

		public void PlayAnimation(bool play, string[] partsNames, int? manualIndex = null, bool? loopOnce = null, float? specificRate = null, bool keepIndex = false)
		{
		}

		public void PlayAnimationSeparately(BillboardAnimationSpecificLayer[] animeInfos)
		{
		}

		public void PlayAnimationSpecificLayer(int billboardLayer, bool play, string partsName, int? manualIndex, bool? loopOnce = null, float? specificRate = null, bool keepIndex = false)
		{
		}

		private void InitCounterSignboard()
		{
		}

		public void UpdateCounterSignboard(int count, int max)
		{
		}

		private void InitMinionSignboard()
		{
		}

		public void UpdateMinionSignboard(int minionNum, bool isElite = false)
		{
		}

		public void PlayMinionAnimation(int minionLayer, bool arriveMinion, bool leaveMinion)
		{
		}

		public void EnableCursorMode(bool enable)
		{
		}

		public string ToDump()
		{
			return null;
		}
	}
}
