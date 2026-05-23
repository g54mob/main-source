using System;
using UnityEngine;

public class OptionSettings : ScriptableObject
{
	[Serializable]
	public struct OptionSliderSettings
	{
		[Header("最小値(Int)")]
		public int min;

		[Header("最大値(Int)")]
		public int max;

		[Header("最小値(String)")]
		public string minText;

		[Header("中間値(String)")]
		public string midText;

		[Header("最大値(String)")]
		public string maxText;

		[Header("デフォルト値")]
		public int defaultValue;

		[Header("メモリ分割数")]
		public int splitCount;
	}

	[Header("マウスカーソルの速度設定")]
	public OptionSliderSettings cursorSpeed;

	[Header("カメラの距離設定")]
	public OptionSliderSettings cameraDistance;

	[Header("カメラの移動速度設定")]
	public OptionSliderSettings cameraSpeed;
}
