using System;
using UnityEngine;

namespace Factory.FieldObject
{
	[Serializable]
	public class LayeredBillboardObjectInit
	{
		[Header("このレイヤーに配置されるParts")]
		public string[] layerParts;

		[Tooltip("ビルボードのXYの調整")]
		public Vector2 billboardOffsetXY;

		[Tooltip("アニメーション間隔の調整（秒）")]
		public float billboardAnimationStep;

		[Tooltip("アニメーションを一度だけ再生する")]
		public bool billboardAnimationLoopOnce;

		[Tooltip("ビルボードをタイルに対し平行に添わせる")]
		public bool billboardParallelToTile;
	}
}
