using Battle;
using UnityEngine;

namespace PostProcess
{
	[CreateAssetMenu]
	public class PostProcessSetting : ScriptableObject
	{
		[Header("------------")]
		[Header("インゲーム中のポストプロセス初期設定ファイル")]
		[Header("------------")]
		[Space]
		[Label("初期waight")]
		public float initialWeight;

		[Header("Color Adjustment")]
		[Label("初期Saturation")]
		public float initialSaturation;

		[Label("長考時のsatuationゴール値")]
		public float slowSaturation;

		[Label("初期カラーフィルター")]
		public Color initialColorFilter;
	}
}
