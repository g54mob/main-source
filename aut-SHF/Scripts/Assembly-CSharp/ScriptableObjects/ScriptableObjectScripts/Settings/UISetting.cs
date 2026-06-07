using Battle;
using UnityEngine;

namespace ScriptableObjects.ScriptableObjectScripts.Settings
{
	public class UISetting : ScriptableObject
	{
		[Header("Relicバー")]
		[Label("レリック詳細表示待機(s)")]
		public float relicDisplayWaitTime;

		[Header("ヒーローステータス情報")]
		[Label("生産バフ情報表示待機(s)")]
		public float buffInfoDelay;

		[Label("表示最大攻撃力")]
		[Tooltip("ヒーローステータスのバーの最大値。テキストにはバーの値を超えて表示。以下も同じ")]
		public float maxStatusAttackPoint;

		[Label("表示最大スタミナ")]
		public float maxStatusStaminaPoint;

		[Label("表示最大耐久値")]
		public float maxLifePoint;

		[Header("ゲームリザルト画面")]
		[Label("出撃数表示行数")]
		public int displaySallyRowCount;

		[Label("ダメージ数表示行数")]
		public int displayDamageRowCount;
	}
}
