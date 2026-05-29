using UnityEngine;

public class LuggageSettings : ScriptableObject
{
	public const double LuggageStartLine = -0.5;

	public const double LuggageGoalLine = 0.5;

	[Header("主に出口の詰まり判定")]
	public double luggageOverflowLine;

	[Header("インサーターが(コンベアから)ピックアップしてよい位置")]
	public double luggagePickupLine;

	[Header("ラゲッジが機械に入る前に待機させられるライン")]
	public double luggageEntranceLine;

	[Header("Luggage(荷物)のテクスチャのスケール調整")]
	public float luggageTextureScale;

	[Header("Luggage(荷物)のテクスチャのスケール最小値")]
	public float luggageTextureScaleMin;

	[Header("雑に射影時の角度調整")]
	public Quaternion persRotation;

	[Header("ベルトコンベアが詰まった時の色")]
	public Color cloggedColor;

	[Header("色が変わり始めるタイミング。1.5なら1マス遅れの状態")]
	public float cloggedColorStart;

	[Header("最終的に指定色になるタイミング")]
	public float cloggedColorLimit;

	[Header("警笛色")]
	public Color carHornColor;

	public const double CarHornLevelStart = 1.5;

	public const double CarHornLevelMax = 4.0;

	public bool useCloggedColor => false;
}
